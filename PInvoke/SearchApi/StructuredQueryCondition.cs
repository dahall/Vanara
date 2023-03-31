using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using static Vanara.PInvoke.Ole32;

namespace Vanara.PInvoke;

public static partial class SearchApi
{
	/// <summary>
	/// Provides a set of flags to be used with following methods to indicate the operation in ICondition::GetComparisonInfo,
	/// ICondition2::GetLeafConditionInfo, IConditionFactory::MakeLeaf, IConditionFactory2::CreateBooleanLeaf,
	/// IConditionFactory2::CreateIntegerLeaf, IConditionFactory2::MakeLeaf, IConditionFactory2::CreateStringLeaf, and IConditionGenerator::GenerateForLeaf.
	/// </summary>
	/// <remarks>
	/// <para>
	/// Provides a set of flags to be used with following methods to indicate the operation in ICondition::GetComparisonInfo,
	/// ICondition2::GetLeafConditionInfo, IConditionFactory::MakeLeaf, IConditionFactory2::CreateBooleanLeaf,
	/// IConditionFactory2::CreateIntegerLeaf, IConditionFactory2::MakeLeaf, IConditionFactory2::CreateStringLeaf, and IConditionGenerator::GenerateForLeaf.
	/// </para>
	/// <para>
	/// In Windows 7, this enumeration is defined in structuredquerycondition.idl and structuredquerycondition.h. Prior to Windows 7 this
	/// enumeration was declared in structuredquery.h and structuredquery.idl.
	/// </para>
	/// </remarks>
	[PInvokeData("structuredquerycondition.h")]
	public enum CONDITION_OPERATION
	{
		/// <summary>
		/// An implicit comparison between the value of the property and the value of the constant. For an unresolved condition,
		/// COP_IMPLICIT means that a user did not type an operation. In contrast, a resolved condition will always have a condition
		/// other than the COP_IMPLICIT operation.
		/// </summary>
		COP_IMPLICIT,

		/// <summary>The value of the property and the value of the constant must be equal.</summary>
		COP_EQUAL,

		/// <summary>The value of the property and the value of the constant must not be equal.</summary>
		COP_NOTEQUAL,

		/// <summary>The value of the property must be less than the value of the constant.</summary>
		COP_LESSTHAN,

		/// <summary>The value of the property must be greater than the value of the constant.</summary>
		COP_GREATERTHAN,

		/// <summary>The value of the property must be less than or equal to the value of the constant.</summary>
		COP_LESSTHANOREQUAL,

		/// <summary>The value of the property must be greater than or equal to the value of the constant.</summary>
		COP_GREATERTHANOREQUAL,

		/// <summary>The value of the property must begin with the value of the constant.</summary>
		COP_VALUE_STARTSWITH,

		/// <summary>The value of the property must end with the value of the constant.</summary>
		COP_VALUE_ENDSWITH,

		/// <summary>The value of the property must contain the value of the constant.</summary>
		COP_VALUE_CONTAINS,

		/// <summary>The value of the property must not contain the value of the constant.</summary>
		COP_VALUE_NOTCONTAINS,

		/// <summary>
		/// The value of the property must match the value of the constant, where '?' matches any single character and '*' matches any
		/// sequence of characters.
		/// </summary>
		COP_DOSWILDCARDS,

		/// <summary>The value of the property must contain a word that is the value of the constant.</summary>
		COP_WORD_EQUAL,

		/// <summary>The value of the property must contain a word that begins with the value of the constant.</summary>
		COP_WORD_STARTSWITH,

		/// <summary>The application is free to interpret this in any suitable way.</summary>
		COP_APPLICATION_SPECIFIC,
	}

	/// <summary>
	/// Provides a set of flags to be used with the following methods to indicate the type of condition tree node:
	/// ICondition::GetConditionType, IConditionFactory::MakeAndOr, IConditionFactory2::CreateCompoundFromArray, and IConditionFactory2::CreateCompoundFromObjectArray.
	/// </summary>
	/// <remarks>
	/// <para>
	/// In Windows 7, this enumeration is defined in structuredquerycondition.idl and structuredquerycondition.h. Prior to Windows 7 this
	/// enumeration was declared in structuredquery.h and structuredquery.idl.
	/// </para>
	/// <para>
	/// The StructuredQuerySample code sample, available on Code Gallery and the Windows 7 SDK, demonstrates how to read lines from the
	/// console, parse them using the system schema, and display the resulting condition trees.
	/// </para>
	/// </remarks>
	[PInvokeData("structuredquerycondition.h")]
	public enum CONDITION_TYPE
	{
		/// <summary>Indicates that the values of the subterms are combined by "AND".</summary>
		CT_AND_CONDITION,

		/// <summary>Indicates that the values of the subterms are combined by "OR".</summary>
		CT_OR_CONDITION,

		/// <summary>Indicates a "NOT" comparison of subterms.</summary>
		CT_NOT_CONDITION,

		/// <summary>Indicates that the node is a comparison between a property and a constant value using a CONDITION_OPERATION.</summary>
		CT_LEAF_CONDITION,
	}

	/// <summary>
	/// Provides methods for retrieving information about a search condition. An <c>ICondition</c> object represents the result of
	/// parsing an input string (using methods such as IQueryParser::Parse or IQuerySolution::GetQuery) into a tree of search condition
	/// nodes. A node can be a logical AND, OR, or NOT for comparing subnodes, or it can be a leaf node comparing a property and a
	/// constant value.
	/// </summary>
	/// <remarks>
	/// <para>
	/// Prior to Windows 7, this interface was only declared in structuredquery.h and structuredquery.idl. In Windows 7, this interface
	/// is also defined in structuredquerycondition.idl and structuredquerycondition.h.
	/// </para>
	/// <para>
	/// The StructuredQuerySample code sample, available on Code Gallery and the Windows 7 SDK, demonstrates how to read lines from the
	/// console, parse them using the system schema, and display the resulting condition trees.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/structuredquerycondition/nn-structuredquerycondition-icondition
	[PInvokeData("structuredquerycondition.h")]
	[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("0FC988D4-C935-4b97-A973-46282EA175C8")]
	public interface ICondition : IPersistStream
	{
		/// <summary>Retrieves the class identifier (CLSID) of the object.</summary>
		/// <returns>
		/// <para>
		/// A pointer to the location that receives the CLSID on return. The CLSID is a globally unique identifier (GUID) that uniquely
		/// represents an object class that defines the code that can manipulate the object's data.
		/// </para>
		/// <para>If the method succeeds, the return value is S_OK. Otherwise, it is E_FAIL.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The <c>GetClassID</c> method retrieves the class identifier (CLSID) for an object, used in later operations to load
		/// object-specific code into the caller's context.
		/// </para>
		/// <para>Notes to Callers</para>
		/// <para>
		/// A container application might call this method to retrieve the original CLSID of an object that it is treating as a different
		/// class. Such a call would be necessary if a user performed an editing operation that required the object to be saved. If the
		/// container were to save it using the treat-as CLSID, the original application would no longer be able to edit the object.
		/// Typically, in this case, the container calls the OleSave helper function, which performs all the necessary steps. For this
		/// reason, most container applications have no need to call this method directly.
		/// </para>
		/// <para>
		/// The exception would be a container that provides an object handler for certain objects. In particular, a container
		/// application should not get an object's CLSID and then use it to retrieve class specific information from the registry.
		/// Instead, the container should use IOleObject and IDataObject interfaces to retrieve such class-specific information directly
		/// from the object.
		/// </para>
		/// <para>Notes to Implementers</para>
		/// <para>
		/// Typically, implementations of this method simply supply a constant CLSID for an object. If, however, the object's
		/// <c>TreatAs</c> registry key has been set by an application that supports emulation (and so is treating the object as one of a
		/// different class), a call to <c>GetClassID</c> must supply the CLSID specified in the <c>TreatAs</c> key. For more information
		/// on emulation, see CoTreatAsClass.
		/// </para>
		/// <para>
		/// When an object is in the running state, the default handler calls an implementation of <c>GetClassID</c> that delegates the
		/// call to the implementation in the object. When the object is not running, the default handler instead calls the ReadClassStg
		/// function to read the CLSID that is saved in the object's storage.
		/// </para>
		/// <para>
		/// If you are writing a custom object handler for your object, you might want to simply delegate this method to the default
		/// handler implementation (see OleCreateDefaultHandler).
		/// </para>
		/// <para>URL Moniker Notes</para>
		/// <para>This method returns CLSID_StdURLMoniker.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/objidl/nf-objidl-ipersist-getclassid HRESULT GetClassID( CLSID *pClassID );
		new Guid GetClassID();

		/// <summary>Determines whether an object has changed since it was last saved to its stream.</summary>
		/// <returns>This method returns S_OK to indicate that the object has changed. Otherwise, it returns S_FALSE.</returns>
		/// <remarks>
		/// <para>
		/// Use this method to determine whether an object should be saved before closing it. The dirty flag for an object is
		/// conditionally cleared in the IPersistStream::Save method.
		/// </para>
		/// <para>Notes to Callers</para>
		/// <para>
		/// You should treat any error return codes as an indication that the object has changed. Unless this method explicitly returns
		/// S_FALSE, assume that the object must be saved.
		/// </para>
		/// <para>
		/// Note that the OLE-provided implementations of the <c>IPersistStream::IsDirty</c> method in the OLE-provided moniker
		/// interfaces always return S_FALSE because their internal state never changes.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/objidl/nf-objidl-ipersiststream-isdirty HRESULT IsDirty( );
		[PreserveSig]
		new HRESULT IsDirty();

		/// <summary>Initializes an object from the stream where it was saved previously.</summary>
		/// <param name="pstm">The PSTM.</param>
		/// <remarks>
		/// <para>
		/// This method loads an object from its associated stream. The seek pointer is set as it was in the most recent
		/// IPersistStream::Save method. This method can seek and read from the stream, but cannot write to it.
		/// </para>
		/// <para>Notes to Callers</para>
		/// <para>
		/// Rather than calling <c>IPersistStream::Load</c> directly, you typically call the OleLoadFromStream function does the following:
		/// </para>
		/// <list type="number">
		/// <item>
		/// <term>Calls the ReadClassStm function to get the class identifier from the stream.</term>
		/// </item>
		/// <item>
		/// <term>Calls the CoCreateInstance function to create an instance of the object.</term>
		/// </item>
		/// <item>
		/// <term>Queries the instance for IPersistStream.</term>
		/// </item>
		/// <item>
		/// <term>Calls <c>IPersistStream::Load</c>.</term>
		/// </item>
		/// </list>
		/// <para>
		/// The OleLoadFromStream function assumes that objects are stored in the stream with a class identifier followed by the object
		/// data. This storage pattern is used by the generic, composite-moniker implementation provided by OLE.
		/// </para>
		/// <para>If the objects are not stored using this pattern, you must call the methods separately yourself.</para>
		/// <para>URL Moniker Notes</para>
		/// <para>
		/// Initializes an URL moniker from data within a stream, usually stored there previously using its IPersistStream::Save (using
		/// OleSaveToStream). The binary format of the URL moniker is its URL string in Unicode (may be a full or partial URL string, see
		/// CreateURLMonikerEx for details). This is represented as a <c>ULONG</c> count of characters followed by that many Unicode characters.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/objidl/nf-objidl-ipersiststream-load HRESULT Load( IStream *pStm );
		new void Load([In, MarshalAs(UnmanagedType.Interface)] IStream pstm);

		/// <summary>Saves an object to the specified stream.</summary>
		/// <param name="pstm">The PSTM.</param>
		/// <param name="fClearDirty">
		/// Indicates whether to clear the dirty flag after the save is complete. If <c>TRUE</c>, the flag should be cleared. If
		/// <c>FALSE</c>, the flag should be left unchanged.
		/// </param>
		/// <remarks>
		/// <para>
		/// <c>IPersistStream::Save</c> saves an object into the specified stream and indicates whether the object should reset its dirty flag.
		/// </para>
		/// <para>
		/// The seek pointer is positioned at the location in the stream at which the object should begin writing its data. The object
		/// calls the ISequentialStream::Write method to write its data.
		/// </para>
		/// <para>
		/// On exit, the seek pointer must be positioned immediately past the object data. The position of the seek pointer is undefined
		/// if an error returns.
		/// </para>
		/// <para>Notes to Callers</para>
		/// <para>
		/// Rather than calling <c>IPersistStream::Save</c> directly, you typically call the OleSaveToStream helper function which does
		/// the following:
		/// </para>
		/// <list type="number">
		/// <item>
		/// <term>Calls GetClassID to get the object's CLSID.</term>
		/// </item>
		/// <item>
		/// <term>Calls the WriteClassStm function to write the object's CLSID to the stream.</term>
		/// </item>
		/// <item>
		/// <term>Calls <c>IPersistStream::Save</c>.</term>
		/// </item>
		/// </list>
		/// <para>If you call these methods directly, you can write other data into the stream after the CLSID before calling <c>IPersistStream::Save</c>.</para>
		/// <para>The OLE-provided implementation of IPersistStream follows this same pattern.</para>
		/// <para>Notes to Implementers</para>
		/// <para>
		/// The <c>IPersistStream::Save</c> method does not write the CLSID to the stream. The caller is responsible for writing the CLSID.
		/// </para>
		/// <para>
		/// The <c>IPersistStream::Save</c> method can read from, write to, and seek in the stream; but it must not seek to a location in
		/// the stream before that of the seek pointer on entry.
		/// </para>
		/// <para>URL Moniker Notes</para>
		/// <para>
		/// Saves an URL moniker to a stream. The binary format of URL moniker is its URL string in Unicode (may be a full or partial URL
		/// string, see CreateURLMonikerEx for details). This is represented as a <c>ULONG</c> count of characters followed by that many
		/// Unicode characters.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/objidl/nf-objidl-ipersiststream-save HRESULT Save( IStream *pStm, BOOL
		// fClearDirty );
		new void Save([In, MarshalAs(UnmanagedType.Interface)] IStream pstm, [In, MarshalAs(UnmanagedType.Bool)] bool fClearDirty);

		/// <summary>Retrieves the size of the stream needed to save the object.</summary>
		/// <returns>The size in bytes of the stream needed to save this object, in bytes.</returns>
		/// <remarks>
		/// <para>
		/// This method returns the size needed to save an object. You can call this method to determine the size and set the necessary
		/// buffers before calling the IPersistStream::Save method.
		/// </para>
		/// <para>Notes to Implementers</para>
		/// <para>
		/// The <c>GetSizeMax</c> implementation should return a conservative estimate of the necessary size because the caller might
		/// call the IPersistStream::Save method with a non-growable stream.
		/// </para>
		/// <para>URL Moniker Notes</para>
		/// <para>
		/// This method retrieves the maximum number of bytes in the stream that will be required by a subsequent call to
		/// IPersistStream::Save. This value is sizeof(ULONG)==4 plus sizeof(WCHAR)*n where n is the length of the full or partial URL
		/// string, including the NULL terminator.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/objidl/nf-objidl-ipersiststream-getsizemax HRESULT GetSizeMax(
		// ULARGE_INTEGER *pcbSize );
		new ulong GetSizeMax();

		/// <summary>
		/// Retrieves the condition type for this search condition node, identifying it as a logical AND, OR, or NOT, or as a leaf node.
		/// </summary>
		/// <returns>
		/// <para>Type: <c>CONDITION_TYPE*</c></para>
		/// <para>Receives the CONDITION_TYPE enumeration for this node.</para>
		/// </returns>
		/// <remarks>
		/// The StructuredQuerySample code sample, available on Code Gallery and the Windows 7 SDK, demonstrates how to read lines from
		/// the console, parse them using the system schema, and display the resulting condition trees.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/structuredquerycondition/nf-structuredquerycondition-icondition-getconditiontype
		// HRESULT GetConditionType( CONDITION_TYPE *pNodeType );
		CONDITION_TYPE GetConditionType();

		/// <summary>
		/// Retrieves a collection of the subconditions of the search condition node and the IID of the interface for enumerating the collection.
		/// </summary>
		/// <param name="riid">
		/// <para>Type: <c>REFIID</c></para>
		/// <para>
		/// The desired IID of the enumerating interface: either IID_IEnumUnknown, IID_IEnumVARIANT or (for a negation condition) IID_ICondition.
		/// </para>
		/// </param>
		/// <returns>
		/// Receives a collection of zero or more ICondition objects. Each object is a subcondition of this condition node. If <paramref
		/// name="riid"/> was IID_ICondition and this is a negation condition, this parameter receives the single subcondition.
		/// </returns>
		/// <remarks>
		/// <para>
		/// The <paramref name="riid"/> parameter must be the <c>GUID</c> of an IEnumUnknown or IEnumVARIANT interface or in the case of
		/// a negation node, IID_ICondition.
		/// </para>
		/// <para>If the subcondition is a negation node, the return value is set to an enumeration of one element.</para>
		/// <para>If the node is a conjunction or disjunction node, the return value is set to an enumeration of the subconditions.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/structuredquerycondition/nf-structuredquerycondition-icondition-getsubconditions
		// HRESULT GetSubConditions( REFIID riid, void **ppv );
		[return: MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 0)]
		object GetSubConditions(in Guid riid);

		/// <summary>Retrieves the property name, operation, and value from a leaf search condition node.</summary>
		/// <param name="ppszPropertyName">
		/// <para>Type: <c>LPWSTR*</c></para>
		/// <para>Receives the name of the property of the leaf condition as a Unicode string.</para>
		/// </param>
		/// <param name="pcop">
		/// <para>Type: <c>CONDITION_OPERATION*</c></para>
		/// <para>Receives the operation of the leaf condition as a CONDITION_OPERATION enumeration.</para>
		/// </param>
		/// <param name="ppropvar">
		/// <para>Type: <c>PROPVARIANT*</c></para>
		/// <para>Receives the value of the leaf condition as a PROPVARIANT.</para>
		/// </param>
		/// <remarks>Any or all of the three parameters can be <c>NULL</c>.</remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/structuredquerycondition/nf-structuredquerycondition-icondition-getcomparisoninfo
		// HRESULT GetComparisonInfo( LPWSTR *ppszPropertyName, CONDITION_OPERATION *pcop, PROPVARIANT *ppropvar );
		void GetComparisonInfo([Out, MarshalAs(UnmanagedType.LPWStr)] out string ppszPropertyName, out CONDITION_OPERATION pcop, [In, Out] PROPVARIANT ppropvar);

		/// <summary>Retrieves the semantic type of the value of the search condition node.</summary>
		/// <returns>
		/// <para>Type: <c>LPWSTR*</c></para>
		/// <para>Receives either a pointer to the semantic type of the value as a Unicode string or <c>NULL</c>.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/structuredquerycondition/nf-structuredquerycondition-icondition-getvaluetype
		// HRESULT GetValueType( LPWSTR *ppszValueTypeName );
		[return: MarshalAs(UnmanagedType.LPWStr)]
		string GetValueType();

		/// <summary>Retrieves the character-normalized value of the search condition node.</summary>
		/// <returns>
		/// <para>Type: <c>LPWSTR*</c></para>
		/// <para>Receives a pointer to a Unicode string representation of the value.</para>
		/// </returns>
		/// <remarks>
		/// In <c>Windows 7 and later</c>, if the value of the leaf node is <c>VT_EMPTY</c>, ppwszNormalization points to an empty
		/// string. If the value is a string, such as VT_LPWSTR, VT_BSTR or VT_LPSTR, then ppwszNormalization is set to a
		/// character-normalized form of the value. In other cases, ppwszNormalization is set to some other character-normalized string
		/// representation of the value.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/structuredquerycondition/nf-structuredquerycondition-icondition-getvaluenormalization
		// HRESULT GetValueNormalization( LPWSTR *ppszNormalization );
		[return: MarshalAs(UnmanagedType.LPWStr)]
		string GetValueNormalization();

		/// <summary>
		/// For a leaf node, <c>ICondition::GetInputTerms</c> retrieves information about what parts (or ranges) of the input string
		/// produced the property, the operation, and the value for the search condition node.
		/// </summary>
		/// <param name="ppPropertyTerm">
		/// <para>Type: <c>IRichChunk**</c></para>
		/// <para>
		/// Receives a pointer to an IRichChunk interface that provides information about what part of the input string produced the
		/// property of the leaf node, if that can be determined; otherwise, this parameter is set to <c>NULL</c>.
		/// </para>
		/// </param>
		/// <param name="ppOperationTerm">
		/// <para>Type: <c>IRichChunk**</c></para>
		/// <para>
		/// Receives a pointer to an IRichChunk interface that provides information about what part of the input string produced the
		/// operation of the leaf node, if that can be determined; otherwise, this parameter is set to <c>NULL</c>.
		/// </para>
		/// </param>
		/// <param name="ppValueTerm">
		/// <para>Type: <c>IRichChunk**</c></para>
		/// <para>
		/// Receives a pointer to an IRichChunk interface that provides information about what part of the input string produced the
		/// value of the leaf node, if that can be determined; otherwise, this parameter is set to <c>NULL</c>.
		/// </para>
		/// </param>
		/// <remarks>
		/// <para>Any or all of the parameters ppPropertyTerm, ppOperationTerm and ppValueTerm can be <c>NULL</c>.</para>
		/// <para>
		/// Each IRichChunk object retrieved by this method represents a range of tokens from the input string. The range tokens
		/// identifies the substring that produced the property, operation, or value of the input string. The <c>IRichChunk</c>'s
		/// PROPVARIANT out parameter is not used.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/structuredquerycondition/nf-structuredquerycondition-icondition-getinputterms
		// HRESULT GetInputTerms( IRichChunk **ppPropertyTerm, IRichChunk **ppOperationTerm, IRichChunk **ppValueTerm );
		void GetInputTerms(out IRichChunk ppPropertyTerm, out IRichChunk ppOperationTerm, out IRichChunk ppValueTerm);

		/// <summary>Creates a deep copy of this ICondition object.</summary>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		/// <remarks>
		/// Because there are no methods for modifying an ICondition, there are few occasions when this method is necessary. In many
		/// cases it is adequate to call the IUnknown::QueryInterface method on the <c>ICondition</c> to obtain an additional reference
		/// to the same object.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/structuredquerycondition/nf-structuredquerycondition-icondition-clone
		// HRESULT Clone( ICondition **ppc );
		ICondition Clone();
	}

	/// <summary>
	/// Extends the functionality of the ICondition interface. <c>ICondition2</c> provides methods for retrieving information about a search condition.
	/// </summary>
	/// <seealso cref="ICondition" />
	/// <remarks>
	/// The StructuredQuerySample code sample, available on Code Gallery and the Windows 7 SDK, demonstrates how to read lines from the console, parse them using the system schema, and display the resulting condition trees.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/structuredquerycondition/nn-structuredquerycondition-icondition2
	[PInvokeData("structuredquerycondition.h", MSDNShortId = "")]
	[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("0DB8851D-2E5B-47eb-9208-D28C325A01D7")]
	public interface ICondition2 : ICondition
	{
		/// <summary>Retrieves the class identifier (CLSID) of the object.</summary>
		/// <returns>
		/// <para>
		/// A pointer to the location that receives the CLSID on return. The CLSID is a globally unique identifier (GUID) that uniquely
		/// represents an object class that defines the code that can manipulate the object's data.
		/// </para>
		/// <para>If the method succeeds, the return value is S_OK. Otherwise, it is E_FAIL.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The <c>GetClassID</c> method retrieves the class identifier (CLSID) for an object, used in later operations to load
		/// object-specific code into the caller's context.
		/// </para>
		/// <para>Notes to Callers</para>
		/// <para>
		/// A container application might call this method to retrieve the original CLSID of an object that it is treating as a different
		/// class. Such a call would be necessary if a user performed an editing operation that required the object to be saved. If the
		/// container were to save it using the treat-as CLSID, the original application would no longer be able to edit the object.
		/// Typically, in this case, the container calls the OleSave helper function, which performs all the necessary steps. For this
		/// reason, most container applications have no need to call this method directly.
		/// </para>
		/// <para>
		/// The exception would be a container that provides an object handler for certain objects. In particular, a container
		/// application should not get an object's CLSID and then use it to retrieve class specific information from the registry.
		/// Instead, the container should use IOleObject and IDataObject interfaces to retrieve such class-specific information directly
		/// from the object.
		/// </para>
		/// <para>Notes to Implementers</para>
		/// <para>
		/// Typically, implementations of this method simply supply a constant CLSID for an object. If, however, the object's
		/// <c>TreatAs</c> registry key has been set by an application that supports emulation (and so is treating the object as one of a
		/// different class), a call to <c>GetClassID</c> must supply the CLSID specified in the <c>TreatAs</c> key. For more information
		/// on emulation, see CoTreatAsClass.
		/// </para>
		/// <para>
		/// When an object is in the running state, the default handler calls an implementation of <c>GetClassID</c> that delegates the
		/// call to the implementation in the object. When the object is not running, the default handler instead calls the ReadClassStg
		/// function to read the CLSID that is saved in the object's storage.
		/// </para>
		/// <para>
		/// If you are writing a custom object handler for your object, you might want to simply delegate this method to the default
		/// handler implementation (see OleCreateDefaultHandler).
		/// </para>
		/// <para>URL Moniker Notes</para>
		/// <para>This method returns CLSID_StdURLMoniker.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/objidl/nf-objidl-ipersist-getclassid HRESULT GetClassID( CLSID *pClassID );
		new Guid GetClassID();

		/// <summary>Determines whether an object has changed since it was last saved to its stream.</summary>
		/// <returns>This method returns S_OK to indicate that the object has changed. Otherwise, it returns S_FALSE.</returns>
		/// <remarks>
		/// <para>
		/// Use this method to determine whether an object should be saved before closing it. The dirty flag for an object is
		/// conditionally cleared in the IPersistStream::Save method.
		/// </para>
		/// <para>Notes to Callers</para>
		/// <para>
		/// You should treat any error return codes as an indication that the object has changed. Unless this method explicitly returns
		/// S_FALSE, assume that the object must be saved.
		/// </para>
		/// <para>
		/// Note that the OLE-provided implementations of the <c>IPersistStream::IsDirty</c> method in the OLE-provided moniker
		/// interfaces always return S_FALSE because their internal state never changes.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/objidl/nf-objidl-ipersiststream-isdirty HRESULT IsDirty( );
		[PreserveSig]
		new HRESULT IsDirty();

		/// <summary>Initializes an object from the stream where it was saved previously.</summary>
		/// <param name="pstm">The PSTM.</param>
		/// <remarks>
		/// <para>
		/// This method loads an object from its associated stream. The seek pointer is set as it was in the most recent
		/// IPersistStream::Save method. This method can seek and read from the stream, but cannot write to it.
		/// </para>
		/// <para>Notes to Callers</para>
		/// <para>
		/// Rather than calling <c>IPersistStream::Load</c> directly, you typically call the OleLoadFromStream function does the following:
		/// </para>
		/// <list type="number">
		/// <item>
		/// <term>Calls the ReadClassStm function to get the class identifier from the stream.</term>
		/// </item>
		/// <item>
		/// <term>Calls the CoCreateInstance function to create an instance of the object.</term>
		/// </item>
		/// <item>
		/// <term>Queries the instance for IPersistStream.</term>
		/// </item>
		/// <item>
		/// <term>Calls <c>IPersistStream::Load</c>.</term>
		/// </item>
		/// </list>
		/// <para>
		/// The OleLoadFromStream function assumes that objects are stored in the stream with a class identifier followed by the object
		/// data. This storage pattern is used by the generic, composite-moniker implementation provided by OLE.
		/// </para>
		/// <para>If the objects are not stored using this pattern, you must call the methods separately yourself.</para>
		/// <para>URL Moniker Notes</para>
		/// <para>
		/// Initializes an URL moniker from data within a stream, usually stored there previously using its IPersistStream::Save (using
		/// OleSaveToStream). The binary format of the URL moniker is its URL string in Unicode (may be a full or partial URL string, see
		/// CreateURLMonikerEx for details). This is represented as a <c>ULONG</c> count of characters followed by that many Unicode characters.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/objidl/nf-objidl-ipersiststream-load HRESULT Load( IStream *pStm );
		new void Load([In, MarshalAs(UnmanagedType.Interface)] IStream pstm);

		/// <summary>Saves an object to the specified stream.</summary>
		/// <param name="pstm">The PSTM.</param>
		/// <param name="fClearDirty">
		/// Indicates whether to clear the dirty flag after the save is complete. If <c>TRUE</c>, the flag should be cleared. If
		/// <c>FALSE</c>, the flag should be left unchanged.
		/// </param>
		/// <remarks>
		/// <para>
		/// <c>IPersistStream::Save</c> saves an object into the specified stream and indicates whether the object should reset its dirty flag.
		/// </para>
		/// <para>
		/// The seek pointer is positioned at the location in the stream at which the object should begin writing its data. The object
		/// calls the ISequentialStream::Write method to write its data.
		/// </para>
		/// <para>
		/// On exit, the seek pointer must be positioned immediately past the object data. The position of the seek pointer is undefined
		/// if an error returns.
		/// </para>
		/// <para>Notes to Callers</para>
		/// <para>
		/// Rather than calling <c>IPersistStream::Save</c> directly, you typically call the OleSaveToStream helper function which does
		/// the following:
		/// </para>
		/// <list type="number">
		/// <item>
		/// <term>Calls GetClassID to get the object's CLSID.</term>
		/// </item>
		/// <item>
		/// <term>Calls the WriteClassStm function to write the object's CLSID to the stream.</term>
		/// </item>
		/// <item>
		/// <term>Calls <c>IPersistStream::Save</c>.</term>
		/// </item>
		/// </list>
		/// <para>If you call these methods directly, you can write other data into the stream after the CLSID before calling <c>IPersistStream::Save</c>.</para>
		/// <para>The OLE-provided implementation of IPersistStream follows this same pattern.</para>
		/// <para>Notes to Implementers</para>
		/// <para>
		/// The <c>IPersistStream::Save</c> method does not write the CLSID to the stream. The caller is responsible for writing the CLSID.
		/// </para>
		/// <para>
		/// The <c>IPersistStream::Save</c> method can read from, write to, and seek in the stream; but it must not seek to a location in
		/// the stream before that of the seek pointer on entry.
		/// </para>
		/// <para>URL Moniker Notes</para>
		/// <para>
		/// Saves an URL moniker to a stream. The binary format of URL moniker is its URL string in Unicode (may be a full or partial URL
		/// string, see CreateURLMonikerEx for details). This is represented as a <c>ULONG</c> count of characters followed by that many
		/// Unicode characters.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/objidl/nf-objidl-ipersiststream-save HRESULT Save( IStream *pStm, BOOL
		// fClearDirty );
		new void Save([In, MarshalAs(UnmanagedType.Interface)] IStream pstm, [In, MarshalAs(UnmanagedType.Bool)] bool fClearDirty);

		/// <summary>Retrieves the size of the stream needed to save the object.</summary>
		/// <returns>The size in bytes of the stream needed to save this object, in bytes.</returns>
		/// <remarks>
		/// <para>
		/// This method returns the size needed to save an object. You can call this method to determine the size and set the necessary
		/// buffers before calling the IPersistStream::Save method.
		/// </para>
		/// <para>Notes to Implementers</para>
		/// <para>
		/// The <c>GetSizeMax</c> implementation should return a conservative estimate of the necessary size because the caller might
		/// call the IPersistStream::Save method with a non-growable stream.
		/// </para>
		/// <para>URL Moniker Notes</para>
		/// <para>
		/// This method retrieves the maximum number of bytes in the stream that will be required by a subsequent call to
		/// IPersistStream::Save. This value is sizeof(ULONG)==4 plus sizeof(WCHAR)*n where n is the length of the full or partial URL
		/// string, including the NULL terminator.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/objidl/nf-objidl-ipersiststream-getsizemax HRESULT GetSizeMax(
		// ULARGE_INTEGER *pcbSize );
		new ulong GetSizeMax();

		/// <summary>
		/// Retrieves the condition type for this search condition node, identifying it as a logical AND, OR, or NOT, or as a leaf node.
		/// </summary>
		/// <returns>
		/// <para>Type: <c>CONDITION_TYPE*</c></para>
		/// <para>Receives the CONDITION_TYPE enumeration for this node.</para>
		/// </returns>
		/// <remarks>
		/// The StructuredQuerySample code sample, available on Code Gallery and the Windows 7 SDK, demonstrates how to read lines from
		/// the console, parse them using the system schema, and display the resulting condition trees.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/structuredquerycondition/nf-structuredquerycondition-icondition-getconditiontype
		// HRESULT GetConditionType( CONDITION_TYPE *pNodeType );
		new CONDITION_TYPE GetConditionType();

		/// <summary>
		/// Retrieves a collection of the subconditions of the search condition node and the IID of the interface for enumerating the collection.
		/// </summary>
		/// <param name="riid">
		/// <para>Type: <c>REFIID</c></para>
		/// <para>
		/// The desired IID of the enumerating interface: either IID_IEnumUnknown, IID_IEnumVARIANT or (for a negation condition) IID_ICondition.
		/// </para>
		/// </param>
		/// <returns>
		/// Receives a collection of zero or more ICondition objects. Each object is a subcondition of this condition node. If <paramref
		/// name="riid"/> was IID_ICondition and this is a negation condition, this parameter receives the single subcondition.
		/// </returns>
		/// <remarks>
		/// <para>
		/// The <paramref name="riid"/> parameter must be the <c>GUID</c> of an IEnumUnknown or IEnumVARIANT interface or in the case of
		/// a negation node, IID_ICondition.
		/// </para>
		/// <para>If the subcondition is a negation node, the return value is set to an enumeration of one element.</para>
		/// <para>If the node is a conjunction or disjunction node, the return value is set to an enumeration of the subconditions.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/structuredquerycondition/nf-structuredquerycondition-icondition-getsubconditions
		// HRESULT GetSubConditions( REFIID riid, void **ppv );
		[return: MarshalAs(UnmanagedType.IUnknown)]
		new object GetSubConditions(in Guid riid);

		/// <summary>Retrieves the property name, operation, and value from a leaf search condition node.</summary>
		/// <param name="ppszPropertyName">
		/// <para>Type: <c>LPWSTR*</c></para>
		/// <para>Receives the name of the property of the leaf condition as a Unicode string.</para>
		/// </param>
		/// <param name="pcop">
		/// <para>Type: <c>CONDITION_OPERATION*</c></para>
		/// <para>Receives the operation of the leaf condition as a CONDITION_OPERATION enumeration.</para>
		/// </param>
		/// <param name="ppropvar">
		/// <para>Type: <c>PROPVARIANT*</c></para>
		/// <para>Receives the value of the leaf condition as a PROPVARIANT.</para>
		/// </param>
		/// <remarks>Any or all of the three parameters can be <c>NULL</c>.</remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/structuredquerycondition/nf-structuredquerycondition-icondition-getcomparisoninfo
		// HRESULT GetComparisonInfo( LPWSTR *ppszPropertyName, CONDITION_OPERATION *pcop, PROPVARIANT *ppropvar );
		new void GetComparisonInfo([Out, MarshalAs(UnmanagedType.LPWStr)] out string ppszPropertyName, out CONDITION_OPERATION pcop, [In, Out] PROPVARIANT ppropvar);

		/// <summary>Retrieves the semantic type of the value of the search condition node.</summary>
		/// <returns>
		/// <para>Type: <c>LPWSTR*</c></para>
		/// <para>Receives either a pointer to the semantic type of the value as a Unicode string or <c>NULL</c>.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/structuredquerycondition/nf-structuredquerycondition-icondition-getvaluetype
		// HRESULT GetValueType( LPWSTR *ppszValueTypeName );
		[return: MarshalAs(UnmanagedType.LPWStr)]
		new string GetValueType();

		/// <summary>Retrieves the character-normalized value of the search condition node.</summary>
		/// <returns>
		/// <para>Type: <c>LPWSTR*</c></para>
		/// <para>Receives a pointer to a Unicode string representation of the value.</para>
		/// </returns>
		/// <remarks>
		/// In <c>Windows 7 and later</c>, if the value of the leaf node is <c>VT_EMPTY</c>, ppwszNormalization points to an empty
		/// string. If the value is a string, such as VT_LPWSTR, VT_BSTR or VT_LPSTR, then ppwszNormalization is set to a
		/// character-normalized form of the value. In other cases, ppwszNormalization is set to some other character-normalized string
		/// representation of the value.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/structuredquerycondition/nf-structuredquerycondition-icondition-getvaluenormalization
		// HRESULT GetValueNormalization( LPWSTR *ppszNormalization );
		[return: MarshalAs(UnmanagedType.LPWStr)]
		new string GetValueNormalization();

		/// <summary>
		/// For a leaf node, <c>ICondition::GetInputTerms</c> retrieves information about what parts (or ranges) of the input string
		/// produced the property, the operation, and the value for the search condition node.
		/// </summary>
		/// <param name="ppPropertyTerm">
		/// <para>Type: <c>IRichChunk**</c></para>
		/// <para>
		/// Receives a pointer to an IRichChunk interface that provides information about what part of the input string produced the
		/// property of the leaf node, if that can be determined; otherwise, this parameter is set to <c>NULL</c>.
		/// </para>
		/// </param>
		/// <param name="ppOperationTerm">
		/// <para>Type: <c>IRichChunk**</c></para>
		/// <para>
		/// Receives a pointer to an IRichChunk interface that provides information about what part of the input string produced the
		/// operation of the leaf node, if that can be determined; otherwise, this parameter is set to <c>NULL</c>.
		/// </para>
		/// </param>
		/// <param name="ppValueTerm">
		/// <para>Type: <c>IRichChunk**</c></para>
		/// <para>
		/// Receives a pointer to an IRichChunk interface that provides information about what part of the input string produced the
		/// value of the leaf node, if that can be determined; otherwise, this parameter is set to <c>NULL</c>.
		/// </para>
		/// </param>
		/// <remarks>
		/// <para>Any or all of the parameters ppPropertyTerm, ppOperationTerm and ppValueTerm can be <c>NULL</c>.</para>
		/// <para>
		/// Each IRichChunk object retrieved by this method represents a range of tokens from the input string. The range tokens
		/// identifies the substring that produced the property, operation, or value of the input string. The <c>IRichChunk</c>'s
		/// PROPVARIANT out parameter is not used.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/structuredquerycondition/nf-structuredquerycondition-icondition-getinputterms
		// HRESULT GetInputTerms( IRichChunk **ppPropertyTerm, IRichChunk **ppOperationTerm, IRichChunk **ppValueTerm );
		new void GetInputTerms(out IRichChunk ppPropertyTerm, out IRichChunk ppOperationTerm, out IRichChunk ppValueTerm);

		/// <summary>Creates a deep copy of this ICondition object.</summary>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		/// <remarks>
		/// Because there are no methods for modifying an ICondition, there are few occasions when this method is necessary. In many
		/// cases it is adequate to call the IUnknown::QueryInterface method on the <c>ICondition</c> to obtain an additional reference
		/// to the same object.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/structuredquerycondition/nf-structuredquerycondition-icondition-clone
		// HRESULT Clone( ICondition **ppc );
		new ICondition Clone();

		/// <summary>
		/// <para>Retrieves the property name, operation, and value from a leaf search condition node.</para>
		/// </summary>
		/// <returns>
		/// <para>Type: <c>LPWSTR*</c></para>
		/// <para>Receives the name of the locale of the leaf condition as a Unicode string. This parameter can be <c>NULL</c>.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/structuredquerycondition/nf-structuredquerycondition-icondition2-getlocale
		// HRESULT GetLocale( LPWSTR *ppszLocaleName );
		[PInvokeData("structuredquerycondition.h", MSDNShortId = "")]
		string GetLocale();

		/// <summary>
		/// Retrieves the property name, operation, and value from a leaf search condition node.
		/// </summary>
		/// <param name="ppropkey"><para>Type: <c>PROPERTYKEY*</c></para><para>Receives the name of the property of the leaf condition as a PROPERTYKEY.</para></param>
		/// <param name="pcop"><para>Type: <c>CONDITION_OPERATION*</c></para><para>Receives the operation of the leaf condition as a CONDITION_OPERATION enumeration.</para></param>
		/// <param name="ppropvar"><para>Type: <c>PROPVARIANT*</c></para><para>Receives the property value of the leaf condition as a PROPVARIANT.</para></param>
		/// <remarks>
		///   <para>Any or all of the three parameters can be <c>NULL</c>.</para><para>The StructuredQuerySample code sample, available on Code Gallery and the Windows 7 SDK, demonstrates how to read lines from the console, parse them using the system schema, and display the resulting condition trees.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/structuredquerycondition/nf-structuredquerycondition-icondition2-getleafconditioninfo
		// HRESULT GetLeafConditionInfo( PROPERTYKEY *ppropkey, CONDITION_OPERATION *pcop, PROPVARIANT *ppropvar );
		[PInvokeData("structuredquerycondition.h", MSDNShortId = "")]
		void GetLeafConditionInfo(out PROPERTYKEY ppropkey, out CONDITION_OPERATION pcop, [Out] PROPVARIANT ppropvar);
	}

	/// <summary>Represents a chunk of data as a string and a PROPVARIANT value.</summary>
	/// <remarks>
	/// In Windows 7, this interface is defined in structuredquerycondition.idl and structuredquerycondition.h. Prior to Windows 7 this
	/// interface was declared in structuredquery.h and structuredquery.idl.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/structuredquerycondition/nn-structuredquerycondition-irichchunk
	[PInvokeData("structuredquerycondition.h")]
	[ComImport, Guid("4FDEF69C-DBC9-454e-9910-B34F3C64B510"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IRichChunk
	{
		/// <summary>
		/// <para>Retrieves the PROPVARIANT and input string that represents a chunk of data.</para>
		/// </summary>
		/// <param name="pFirstPos">
		/// <para>Type: <c>ULONG*</c></para>
		/// <para>Receives the zero-based starting position of the range. This parameter can be <c>NULL</c>.</para>
		/// </param>
		/// <param name="pLength">
		/// <para>Type: <c>ULONG*</c></para>
		/// <para>Receives the length of the range. This parameter can be <c>NULL</c>.</para>
		/// </param>
		/// <param name="ppsz">
		/// <para>Type: <c>LPWSTR*</c></para>
		/// <para>Receives the associated Unicode string value, or <c>NULL</c> if not available.</para>
		/// </param>
		/// <param name="pValue">
		/// <para>Type: <c>PROPVARIANT*</c></para>
		/// <para>Receives the associated PROPVARIANT value, or <c>VT_EMPTY</c> if not available. This parameter can be <c>NULL</c>.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		/// <remarks>
		/// <para>Prior to Windows 7, this was declared in structuredquery.idl and structuredquery.h.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/structuredquerycondition/nf-structuredquerycondition-irichchunk-getdata
		// HRESULT GetData( ULONG *pFirstPos, ULONG *pLength, LPWSTR *ppsz, PROPVARIANT *pValue );
		void GetData(out uint pFirstPos, out uint pLength, [Out, MarshalAs(UnmanagedType.LPWStr)] out string ppsz, [In, Out] PROPVARIANT pValue);
	}

	/// <summary>
	/// Retrieves a collection of the subconditions of the search condition node and the IID of the interface for enumerating the collection.
	/// </summary>
	/// <typeparam name="T">
	/// The desired type of the enumerating interface: either IID_IEnumUnknown, IID_IEnumVARIANT or (for a negation condition) IID_ICondition.
	/// </typeparam>
	/// <param name="c">The <see cref="ICondition"/> instance.</param>
	/// <returns>
	/// Receives a collection of zero or more ICondition objects. Each object is a subcondition of this condition node. If
	/// <typeparamref name="T"/> was IID_ICondition and this is a negation condition, this parameter receives the single subcondition.
	/// </returns>
	/// <remarks>
	/// <para>If the subcondition is a negation node, the return value is set to an enumeration of one element.</para>
	/// <para>If the node is a conjunction or disjunction node, the return value is set to an enumeration of the subconditions.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/structuredquerycondition/nf-structuredquerycondition-icondition-getsubconditions
	// HRESULT GetSubConditions( REFIID riid, void **ppv );
	public static T GetSubConditions<T>(this ICondition c) where T : class => (T)c.GetSubConditions(typeof(T).GUID);
}