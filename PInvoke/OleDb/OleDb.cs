global using static Vanara.PInvoke.Ole32;
global using HWATCHREGION = System.IntPtr;
global using HACCESSOR = System.IntPtr;
global using HROW = System.IntPtr;
global using HCHAPTER = System.IntPtr;
global using DB_DWRESERVE = nuint;
global using DB_LORDINAL = nint;
global using DB_LPARAMS = nint;
global using DB_LRESERVE = nint;
global using DB_UPARAMS = nuint;
global using DB_URESERVE = nuint;
global using DBBKMARK = nuint;
global using DBBYTEOFFSET = nuint;
global using DBCOUNTITEM = nuint;
global using DBKIND = uint;
global using DBHASHVALUE = uint;
global using DBLENGTH = nuint;
global using DBNUMBERIC = Vanara.PInvoke.Odbc32.SQL_NUMERIC_STRUCT;
global using DBDATE = Vanara.PInvoke.Odbc32.DATE_STRUCT;
global using DBTIME = Vanara.PInvoke.Odbc32.TIME_STRUCT;
global using DBTIMESTAMP = Vanara.PInvoke.Odbc32.TIMESTAMP_STRUCT;
global using DBORDINAL = nuint;
global using DBREFCOUNT = uint;
global using DBROWCOUNT = nint;
global using DBROWOFFSET = nint;
global using DISPPARAMS = System.Runtime.InteropServices.ComTypes.DISPPARAMS;
using System.Linq;

namespace Vanara.PInvoke;

/// <summary>Items from the OleDb.dll.</summary>
public static partial class OleDb
{
	/// <summary>Undocumented.</summary>
	public const uint IDENTIFIER_SDK_ERROR = 0x10000000;
	/// <summary>Undocumented.</summary>
	public const uint IDENTIFIER_SDK_MASK = 0xF0000000;
	private const string Lib_OleDb = "OleDb.dll";

	/// <summary>
	/// IAccessor provides methods for accessor management. For information about accessors, see the section about Accessors in Getting and
	/// Setting Data.
	/// </summary>
	// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/ms719672(v=vs.85)
	[PInvokeData("oledb.h")]
	[ComImport, Guid("0c733a8c-2a1c-11ce-ade5-00aa0044773d"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IAccessor
	{
		/// <summary>Adds a reference count to an existing accessor.</summary>
		/// <param name="hAccessor">[in] The handle of the accessor for which to increment the reference count.</param>
		/// <param name="pcRefCount">
		/// [out] A pointer to memory in which to return the reference count of the accessor handle. If pcRefCount is a null pointer, no
		/// reference count is returned.
		/// </param>
		// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/ms714978(v=vs.85) HRESULT AddRefAccessor ( HACCESSOR
		// hAccessor, DBREFCOUNT *pcRefCount);
		void AddRefAccessor(HACCESSOR hAccessor, out DBREFCOUNT pcRefCount);

		/// <summary>Creates an accessor from a set of bindings.</summary>
		/// <param name="dwAccessorFlags">
		/// <para>[in] A bitmask that describes the properties of the accessor and how it is to be used. These flags have the following meanings.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Value</description>
		/// <description>Description</description>
		/// </listheader>
		/// <item>
		/// <description>DBACCESSOR_INVALID</description>
		/// <description>This flag is used by <c>IAccessor::GetBindings</c> to indicate that the method failed.</description>
		/// </item>
		/// <item>
		/// <description>DBACCESSOR_PASSBYREF</description>
		/// <description>
		/// The accessor is a reference accessor. The value passed in the consumer buffer is a pointer to the passer's internal buffer. This
		/// pointer need not point to the start of the internal buffer as long as the relative offsets of all elements of the buffer align
		/// with the offsets specified in the accessor. The passee must know the internal structure of the passer's buffer in order to read
		/// information from it. The passee must not free the buffer at the pointer nor may it write to this buffer. For row accessors, this
		/// buffer is the rowset's copy of the row. The consumer reads information directly from this copy of the row at a later point in
		/// time, so the provider must guarantee that the pointer remains valid. For parameter accessors, this buffer is the consumer's
		/// buffer. The provider reads data from this buffer only when <c>ICommand::Execute</c> is called; therefore, the pointer is not
		/// required to remain valid after <c>Execute</c> returns. Support for this flag is optional. A consumer determines whether a
		/// provider supports this bit by calling <c>IDBProperties::GetProperties</c> for the DBPROP_BYREFACCESSORS property. When this flag
		/// is used, the <c>dwMemOwner</c> in the DBBINDING structure is ignored. If the accessor is used for row data, the accessor refers
		/// to the provider's memory; the consumer must not write to or free this memory. If the accessor is used for input parameters, the
		/// provider copies the row of data without assuming ownership. It is an error to specify an output or input/output parameter in a
		/// reference accessor. For more information, see Reference Accessors in Getting and Setting Data (OLE DB).
		/// </description>
		/// </item>
		/// <item>
		/// <description>DBACCESSOR_ROWDATA</description>
		/// <description>
		/// The accessor is a row accessor and describes bindings to columns in the rowset. An accessor may be a row accessor, a parameter
		/// accessor, or both.
		/// </description>
		/// </item>
		/// <item>
		/// <description>DBACCESSOR_PARAMETERDATA</description>
		/// <description>
		/// The accessor is a parameter accessor and describes bindings to parameters in the command text. In a parameter accessor, it is an
		/// error to bind an input or an input/output parameter more than one time.
		/// </description>
		/// </item>
		/// <item>
		/// <description>DBACCESSOR_OPTIMIZED</description>
		/// <description>
		/// The row accessor is to be optimized. This hint may affect how a provider structures its internal buffers. A particular column can
		/// be bound by only one optimized accessor. The column can also be bound by other, nonoptimized accessors, but the types specified
		/// in the nonoptimized accessors must be convertible from the type in the optimized accessor. All optimized accessors must be
		/// created before the first row is fetched with <c>IRowset::GetNextRows</c>, <c>IRowsetLocate::GetRowsAt</c>,
		/// <c>IRowsetLocate::GetRowsByBookmark</c>, or <c>IRowsetScroll::GetRowsAtRatio</c>. This flag is ignored for parameter accessors
		/// and may be ignored by providers that do not provide further optimizations or restrictions based on its setting. Providers that
		/// enforce restrictions, such as limiting the number or types of columns bound in optimized accessors, must set this flag when
		/// <c>IAccessor::GetBindings</c> is called on an optimized accessor. Providers that do not impose any restrictions on optimized
		/// accessors or that ignore this flag entirely are not required to return this flag when <c>IAccessor::GetBindings</c> is called.
		/// </description>
		/// </item>
		/// <item>
		/// <description>DBACCESSOR_INHERITED</description>
		/// <description>
		/// Indicates an accessor on a command should be inherited by a rowset when the rowset implementation is in a separate component from
		/// the command object. <c>IAccessor::CreateAccessor</c> is then used to pass an existing command accessor to the rowset
		/// implementation. When DBACCESSOR_INHERITED is specified, <c>phAccessor</c> is used as an [in] argument and contains a pointer to
		/// the value of the existing accessor handle. The rowset component then creates an internal accessor according to the specified
		/// bindings for this handle value.
		/// </description>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="cBindings">
		/// <para>[in] The number of bindings in the accessor.</para>
		/// <para>
		/// If cBindings is zero, <c>IAccessor::CreateAccessor</c> creates a null accessor. Null accessors are used only by
		/// <c>IRowsetChange::InsertRow</c> to create a new row in which each column is set to its default value, NULL, or a status of
		/// DBSTATUS_E_UNAVAILABLE. Providers that support <c>IRowsetChange::InsertRow</c> must support the creation of null accessors. For
		/// more information, see InsertRow.
		/// </para>
		/// </param>
		/// <param name="rgBindings">[in] An array of DBBINDING structures. For more information, see DBBINDING Structures.</param>
		/// <param name="cbRowSize">
		/// <para>[in] The number of bytes allocated for a single set of parameters or criteria values in the consumer's buffer.</para>
		/// <para>
		/// cbRowSize is used by <c>ICommand::Execute</c> to process multiple sets of parameters and by <c>IViewFilter::GetFilter</c> and
		/// <c>IViewFilter::SetFilter</c> to get and set multiple OR conditions in criteria. In either case, a single accessor may describe
		/// multiple sets of values. cbRowSize is generally the size of the structure that contains a single set of parameter or criteria
		/// values and is used as the offset to the start of the next set of values within the array of structures. For example, if
		/// cParamSets is greater than 1 in the DBPARAMS structure passed to <c>ICommand::Execute</c>, the provider assumes that the pData
		/// element of this structure points to an array of structures containing parameter values, each cbRowSize bytes in size. Similarly,
		/// if cRows is greater than 1 in <c>IViewFilter::SetFilter</c>, the provider assumes that the pCriteriaData argument points to an
		/// array of structures containing criteria values, each cbRowSize bytes in size.
		/// </para>
		/// <para>
		/// cbRowSize must be large enough to contain the structure defined by the bindings in rgBindings. The provider is not required to
		/// verify this, although it may.
		/// </para>
		/// <para>cbRowSize is not used when fetching rowset data.</para>
		/// </param>
		/// <param name="phAccessor">
		/// [out] A pointer to memory in which to return the handle of the created accessor. If <c>IAccessor::CreateAccessor</c> fails, it
		/// must attempt to set *phAccessor to a null handle.
		/// </param>
		/// <param name="rgStatus">
		/// <para>
		/// [out] An array of cBindings DBBINDSTATUS values in which <c>IAccessor::CreateAccessor</c> returns the status of each binding ?
		/// that is, whether or not it was successfully validated. If rgStatus is a null pointer, no bind status values are returned. The
		/// consumer allocates and owns the memory for this array. The bind status values are returned for the reasons described in the
		/// following table.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <description>Value</description>
		/// <description>Description</description>
		/// </listheader>
		/// <item>
		/// <description>DBBINDSTATUS_OK</description>
		/// <description>
		/// No errors were found in the binding. Because accessor validation can be deferred, a status of DBBINDSTATUS_OK does not
		/// necessarily mean that the binding was successfully validated.
		/// </description>
		/// </item>
		/// <item>
		/// <description>DBBINDSTATUS_BADORDINAL</description>
		/// <description>
		/// A parameter ordinal was zero in a parameter accessor. If the accessor is validated against the metadata when
		/// <c>IAccessor::CreateAccessor</c> is called, DBBINDSTATUS_BADORDINAL can be returned for the following reasons: These reasons
		/// cause a status value of DBSTATUS_E_BADACCESSOR to be returned if the accessor is validated when used. Some providers may support
		/// binding more parameters than the number of parameters in the command text, and such providers do not return
		/// DBBINDSTATUS_BADORDINAL in this case.
		/// </description>
		/// </item>
		/// <item>
		/// <description>DBBINDSTATUS_UNSUPPORTEDCONVERSION</description>
		/// <description>
		/// If the accessor is validated against the metadata when <c>IAccessor::CreateAccessor</c> is called,
		/// DBBINDSTATUS_UNSUPPORTEDCONVERSION can be returned for the following reasons: These reasons cause a status value of
		/// DBSTATUS_E_BADACCESSOR to be returned if the accessor is validated when used.
		/// </description>
		/// </item>
		/// <item>
		/// <description>DBBINDSTATUS_BADBINDINFO</description>
		/// <description>
		/// <c>dwPart</c> in a binding was not a combination of two or more of the following: DBPART_VALUE DBPART_LENGTH DBPART_STATUS
		/// <c>eParamIO</c> in a binding in a parameter accessor was not one of the following: DBPARAMIO_INPUT DBPARAMIO_OUTPUT
		/// DBPARAMIO_INPUT | DBPARAMIO_OUTPUT A row accessor was optimized, and a column ordinal in a binding was already used in another
		/// optimized accessor. In a parameter accessor, two or more bindings contained the same ordinal for an input or input/output
		/// parameter. <c>wType</c> in a binding was DBTYPE_EMPTY or DBTYPE_NULL. <c>wType</c> in a binding was one of the following:
		/// DBTYPE_BYREF | DBTYPE _EMPTY, DBTYPE_BYREF | DBTYPE_NULL, or DBTYPE_BYREF | DBTYPE_RESERVED. <c>wType</c> in a binding was used
		/// with more than one of the following mutually exclusive type indicators: DBTYPE_BYREF, DBTYPE_ARRAY, or DBTYPE_VECTOR.
		/// <c>wType</c> in a binding was DBTYPE_IUNKNOWN, <c>pObject</c> in the same binding was a null pointer, and the provider did not
		/// assume that the bound interface is <c>IID_IUnknown</c>. Provider-owned memory was specified for a nonpointer type in a
		/// nonreference row accessor. Provider-owned memory was specified for a column, and the provider does not support binding to
		/// provider-owned memory for this column. Provider-owned memory was specified for a column for which
		/// <c>IColumnsInfo::GetColumnInfo</c> returned DBCOLUMNFLAGS_ISLONG, and the provider does not support binding long data to provider
		/// owned memory. In a nonreference parameter accessor, a binding specified provider-owned memory. An output or input/output
		/// parameter was specified in a parameter reference accessor. <c>dwFlags</c> in a binding was set to DBBINDFLAG_HTML, and
		/// <c>wType</c> for the same binding was not a string value. The provider is an OLE DB 2.5 or later provider, and <c>dwFlags</c> was
		/// set to an unknown or invalid value. <c>dwMemOwner</c> was invalid. Providers are not required to return DBBINDSTATUS_BADBINDINFO.
		/// If they ignore an invalid value of <c>dwMemOwner</c>, they must default to DBMEMOWNER_CLIENTOWNED. If the accessor is validated
		/// against the metadata when <c>IAccessor::CreateAccessor</c> is called, DBBINDSTATUS_BADBINDINFO can be returned for the following reasons:
		/// </description>
		/// </item>
		/// <item>
		/// <description>DBBINDSTATUS_BADSTORAGEFLAGS</description>
		/// <description>
		/// <c>dwFlags</c>, in the DBOBJECT structure pointed to by a binding, specified invalid storage flags. If the accessor is validated
		/// against the metadata when <c>IAccessor::CreateAccessor</c> is called, DBBINDSTATUS_BADSTORAGEFLAGS can be returned if
		/// <c>dwFlags</c>, in the DBOBJECT structure pointed to by a binding, specified a valid storage flag that was not supported by the
		/// object. This causes a status value of DBSTATUS_E_BADACCESSOR to be returned if the accessor is validated when used.
		/// </description>
		/// </item>
		/// <item>
		/// <description>DBBINDSTATUS_NOINTERFACE</description>
		/// <description>
		/// If the accessor is validated against the metadata when <c>IAccessor::CreateAccessor</c> is called, DBBINDSTATUS_NOINTERFACE can
		/// be returned for the following reasons: These reasons cause a status value of DBSTATUS_E_BADACCESSOR to be returned if the
		/// accessor is validated when used.
		/// </description>
		/// </item>
		/// </list>
		/// </param>
		/// <returns>
		/// <list type="bullet">
		/// <item>
		/// <description>
		/// <para>S_OK The method succeeded. If rgStatus is not a null pointer, each element is set to DBBINDSTATUS_OK.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>E_FAIL A provider-specific error occurred.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>E_INVALIDARG phAccessor was a null pointer.</para>
		/// <para>cBindings was not zero, and rgBindings was a null pointer.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// E_UNEXPECTED <c>ITransaction::Commit</c> or <c>ITransaction::Abort</c> was called, and the object is in a zombie state. This
		/// error can be returned only when the method is called on a rowset.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_E_BADACCESSORFLAGS dwAccessorFlags was invalid.</para>
		/// <para>The DBACCESSOR_PARAMETERDATA bit was set in dwAccessorFlags, and the provider does not support parameters.</para>
		/// <para>Neither the DBACCESSOR_PARAMETERDATA bit nor the DBACCESSOR_ROWDATA bit was set in dwAccessorFlags.</para>
		/// <para>
		/// A method that fetches rows ( <c>IRowset::GetNextRows</c>, <c>IRowsetLocate::GetRowsAt</c>,
		/// <c>IRowsetLocate::GetRowsByBookmark</c>, or <c>IRowsetScroll::GetRowsAtRatio</c>) had already been called, and the
		/// DBACCESSOR_OPTIMIZED bit in dwAccessorFlags was set.
		/// </para>
		/// <para>The DBACCESSOR_ PARAMETERDATA bit was set, and <c>IAccessor::CreateAccessor</c> was called on a rowset.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// DB_E_BYREFACCESSORNOTSUPPORTED dwAccessorFlags was DBACCESSOR_PASSBYREF, and the value of the DBPROP_BYREFACCESSORS property is VARIANT_FALSE.
		/// </para>
		/// <para>
		/// Consumers should always check to see whether the provider supports the property DBPROP_BYREFACCESSORS and call
		/// <c>IAccessor::CreateAccessor</c> with the DBACCESSOR_PASSBYREF flag only if the provider supports this property. For performance
		/// reasons, some service providers might be unable to detect whether the underlying data provider supports DBACCESSOR_PASSBYREF on
		/// the <c>CreateAccessor</c> call and might return DB_E_BYREFACCESSORNOTSUPPORTED.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// DB_E_ERRORSOCCURRED Accessor validation failed. To determine which bindings failed, the consumer checks the values returned in
		/// rgStatus, at least one of which is not DBBINDSTATUS_OK.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// DB_E_NOTREENTRANT The provider called a method from <c>IRowsetNotify</c> in the consumer that had not yet returned, and the
		/// provider does not support reentrancy in this method.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// DB_E_NULLACCESSORNOTSUPPORTED cBindings was zero, and either the rowset does not expose <c>IRowsetChange::InsertRow</c> or
		/// <c>IAccessor::CreateAccessor</c> was called on a command.
		/// </para>
		/// </description>
		/// </item>
		/// </list>
		/// </returns>
		// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/ms720969(v=vs.85) HRESULT CreateAccessor ( DBACCESSORFLAGS
		// dwAccessorFlags, DBCOUNTITEM cBindings, const DBBINDING rgBindings[], DBLENGTH cbRowSize, HACCESSOR *phAccessor, DBBINDSTATUS rgStatus[]);
		[PreserveSig]
		HRESULT CreateAccessor(DBACCESSORFLAGS dwAccessorFlags, DBCOUNTITEM cBindings, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] DBBINDING[] rgBindings,
			[Optional] DBLENGTH cbRowSize, out HACCESSOR phAccessor, [In, Out, Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] DBBINDSTATUS[]? rgStatus);

		/// <summary>Returns the bindings in an accessor.</summary>
		/// <param name="hAccessor">[in] The handle of the accessor for which to return the bindings.</param>
		/// <param name="pdwAccessorFlags">
		/// [out] A pointer to memory in which to return a bitmask that describes the properties of the accessor and how it is intended to be
		/// used. For more information, see dwAccessorFlags in CreateAccessor. If this method fails, *pdwAccessorFlags is set to DBACCESSOR_INVALID.
		/// </param>
		/// <param name="pcBindings">
		/// [out] A pointer to memory in which to return the number of bindings in the accessor. If this method fails, *pcBindings is set to zero.
		/// </param>
		/// <param name="prgBindings">
		/// [out] A pointer to memory in which to return an array of DBBINDING structures. One DBBINDING structure is returned for each
		/// binding in the accessor. The provider allocates memory for these structures and any structures pointed to by elements of these
		/// structures; for example, if pObject in a binding structure is not a null pointer, the provider allocates a DBOBJECT structure for
		/// return to the consumer. The provider returns the address to the memory for these structures; the consumer releases the memory for
		/// these structures with <c>IMalloc::Free</c> when it no longer needs the bindings. If *pcBindings is zero on output or the method
		/// fails, the provider does not allocate any memory and ensures that *prgBindings is a null pointer on output. For information about
		/// bindings, see DBBINDING Structures.
		/// </param>
		// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/ms721253(v=vs.85) HRESULT GetBindings ( HACCESSOR hAccessor,
		// DBACCESSORFLAGS *pdwAccessorFlags, DBCOUNTITEM *pcBindings, DBBINDING **prgBindings);
		void GetBindings(HACCESSOR hAccessor, out DBACCESSORFLAGS pdwAccessorFlags, out DBCOUNTITEM pcBindings,
			out SafeIMallocHandle prgBindings);

		/// <summary>Releases an accessor.</summary>
		/// <param name="hAccessor">[in] The handle of the accessor to release.</param>
		/// <param name="pcRefCount">
		/// [out] A pointer to memory in which to return the remaining reference count of the accessor handle. If pcRefCount is a null
		/// pointer, no reference count is returned.
		/// </param>
		// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/ms719717(v=vs.85) HRESULT ReleaseAccessor ( HACCESSOR
		// hAccessor, DBREFCOUNT *pcRefCount);
		void ReleaseAccessor(HACCESSOR hAccessor, out DBREFCOUNT pcRefCount);
	}

	/// <summary>
	/// <c>IColumnsInfo</c> is the simpler of two interfaces that can be used to expose information about columns of a rowset or prepared
	/// command. It provides a limited set of information in an array.
	/// </summary>
	// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/ms725401(v=vs.85)
	[PInvokeData("oledb.h")]
	[ComImport, Guid("0c733a11-2a1c-11ce-ade5-00aa0044773d"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IColumnsInfo
	{
		/// <summary>Returns the column metadata needed by most consumers.</summary>
		/// <param name="pcColumns">
		/// [out] A pointer to memory in which to return the number of columns in the rowset; this number includes the bookmark column, if
		/// there is one. If <c>IColumnsInfo::GetColumnInfo</c> is called on a command that does not return rows, *pcColumns is set to zero.
		/// If this method terminates due to an error, *pcColumns is set to zero.
		/// </param>
		/// <param name="prgInfo">
		/// [out] A pointer to memory in which to return an array of DBCOLUMNINFO structures. One structure is returned for each column in
		/// the rowset. The provider allocates memory for the structures and returns the address to this memory; the consumer releases this
		/// memory with <c>IMalloc::Free</c> when it no longer needs the column information. If *pcColumns is 0 on output or terminates due
		/// to an error, the provider does not allocate any memory and ensures that *prgInfo is a null pointer on output. For more
		/// information, see "DBCOLUMNINFO Structures" in the Comments section.
		/// </param>
		/// <param name="ppStringsBuffer">
		/// [out] A pointer to memory in which to return a pointer to storage for all string values (names used either within columnid or for
		/// pwszName) within a single allocation block. If no returned columns have either form of string name or if this method terminates
		/// due to error, this parameter returns a null pointer. If there are any string names, this will be a buffer containing all the
		/// values of those names. The consumer should free the buffer with <c>IMalloc::Free</c> when finished working with the names. If
		/// *pcColumns is zero on output, the provider does not allocate any memory and ensures that *ppStringsBuffer is a null pointer on
		/// output. Each of the individual string values stored in this buffer is terminated by a null-termination character. Therefore, the
		/// buffer may contain one or more strings, each with its own null-termination character, and may contain embedded null-termination characters.
		/// </param>
		/// <returns>
		/// <list type="bullet">
		/// <item>
		/// <description>
		/// <para>S_OK The method succeeded.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>E_FAIL A provider-specific error occurred.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>E_INVALIDARG pcColumns, prgInfo, or ppStringsBuffer was a null pointer.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>E_OUTOFMEMORY The provider was unable to allocate sufficient memory in which to return the column information structures.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// E_UNEXPECTED <c>ITransaction::Commit</c> or <c>ITransaction::Abort</c> was called, and the object is in a zombie state. This
		/// error can be returned only when the method is called on a rowset.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// DB_E_ERRORSINCOMMAND The command text contained one or more errors. Providers should use OLE DB error objects to return details
		/// about the errors.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_E_NOCOMMAND No command text was set. This error can be returned only when this method is called from the command object.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_E_NOTABLE <c>ICommandPrepare</c> was not implemented, and the specific table or view does not exist in the data store.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// DB_E_NOTPREPARED The command exposed <c>ICommandPrepare</c>, and the command text was set but the command was not prepared. This
		/// error can be returned only when this method is called from the command object.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// DB_E_NOTREENTRANT The provider called a method from <c>IRowsetNotify</c> in the consumer that had not yet returned, and the
		/// provider does not support reentrancy in this method.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_SEC_E_PERMISSIONDENIED The consumer did not have sufficient permission to retrieve the column information.</para>
		/// </description>
		/// </item>
		/// </list>
		/// </returns>
		// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/ms722704(v=vs.85)
		// HRESULT GetColumnInfo ( DBORDINAL *pcColumns, DBCOLUMNINFO **prgInfo, OLECHAR **ppStringsBuffer);
		[PreserveSig]
		HRESULT GetColumnInfo(out DBORDINAL pcColumns, out SafeIMallocHandle prgInfo, out SafeIMallocHandle ppStringsBuffer);

		/// <summary>Returns an array of ordinals of the columns in a rowset that are identified by the specified column IDs.</summary>
		/// <param name="cColumnIDs">
		/// [in] The number of column IDs to map. If cColumnIDs is 0, <c>IColumnsInfo::MapColumnIDs</c> does nothing and returns S_OK.
		/// </param>
		/// <param name="rgColumnIDs">
		/// [in] An array of IDs of the columns of which to determine the column ordinals. If rgColumnIDs contains a duplicate column ID, a
		/// column ordinal is returned once for each occurrence of the column ID. If the column ID is invalid, the corresponding element of
		/// rgColumns is set to DB_INVALIDCOLUMN.
		/// </param>
		/// <param name="rgColumns">
		/// [out] An array of cColumnIDs ordinals of the columns identified by the elements of rgColumnIDs. The consumer allocates, but is
		/// not required to initialize, memory for this array and passes the address of this memory to the provider. The provider returns the
		/// column IDs in the array.
		/// </param>
		/// <returns>
		/// <list type="bullet">
		/// <item>
		/// <description>
		/// <para>S_OK The method succeeded. All elements of rgColumns are set to values other than DB_INVALIDCOLUMN.</para>
		/// <para>
		/// cColumnIDs was zero; the method succeeded but did nothing. This return code supersedes E_INVALIDARG if cColumnIDs was zero and
		/// either or both rgColumnIDs and rgColumns was a null pointer.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// DB_S_ERRORSOCCURRED An element of rgColumnIDs was invalid. If the column ID is invalid, the corresponding element of rgColumns is
		/// set to DB_INVALIDCOLUMN.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>E_FAIL A provider-specific error occurred.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>E_INVALIDARG cColumnIDs was not 0, and rgColumnIDs was a null pointer.</para>
		/// <para>rgColumns was a null pointer.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// E_UNEXPECTED <c>ITransaction::Commit</c> or <c>ITransaction::Abort</c> was called, and the object is in a zombie state. This
		/// error can be returned only when the method is called on a rowset.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_E_ERRORSOCCURRED All elements of rgColumnIDs were invalid. All elements of rgColumns are set to DB_INVALIDCOLUMN.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_E_NOCOMMAND No command text was set. This error can be returned only when this method is called from the command object.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_E_NOTABLE <c>ICommandPrepare</c> was not implemented, and the specific table or view does not exist in the data store.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// DB_E_NOTPREPARED The command exposed <c>ICommandPrepare</c>, and the command text was set but the command was not prepared. This
		/// error can be returned only when this method is called from the command object.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// DB_E_NOTREENTRANT The provider called a method from <c>IRowsetNotify</c> in the consumer that had not yet returned, and the
		/// provider does not support reentrancy in this method.
		/// </para>
		/// </description>
		/// </item>
		/// </list>
		/// </returns>
		// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/ms714200(v=vs.85) HRESULT MapColumnIDs ( DBORDINAL cColumnIDs,
		// const DBID rgColumnIDs[], DBORDINAL rgColumns[]);
		[PreserveSig]
		HRESULT MapColumnIDs(DBORDINAL cColumnIDs, [In, Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] DBID[]? rgColumnIDs,
			[Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] DBORDINAL[]? rgColumns);
	}

	/// <summary>The <c>IColumnsInfo2</c> interface allows a consumer to obtain column names or metadata for the columns in a row or rowset.</summary>
	// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/ms712953(v=vs.85)
	[PInvokeData("oledb.h")]
	[ComImport, Guid("0c733ab8-2a1c-11ce-ade5-00aa0044773d"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IColumnsInfo2 : IColumnsInfo
	{
		/// <summary>Returns the column metadata needed by most consumers.</summary>
		/// <param name="pcColumns">
		/// [out] A pointer to memory in which to return the number of columns in the rowset; this number includes the bookmark column, if
		/// there is one. If <c>IColumnsInfo::GetColumnInfo</c> is called on a command that does not return rows, *pcColumns is set to zero.
		/// If this method terminates due to an error, *pcColumns is set to zero.
		/// </param>
		/// <param name="prgInfo">
		/// [out] A pointer to memory in which to return an array of DBCOLUMNINFO structures. One structure is returned for each column in
		/// the rowset. The provider allocates memory for the structures and returns the address to this memory; the consumer releases this
		/// memory with <c>IMalloc::Free</c> when it no longer needs the column information. If *pcColumns is 0 on output or terminates due
		/// to an error, the provider does not allocate any memory and ensures that *prgInfo is a null pointer on output. For more
		/// information, see "DBCOLUMNINFO Structures" in the Comments section.
		/// </param>
		/// <param name="ppStringsBuffer">
		/// [out] A pointer to memory in which to return a pointer to storage for all string values (names used either within columnid or for
		/// pwszName) within a single allocation block. If no returned columns have either form of string name or if this method terminates
		/// due to error, this parameter returns a null pointer. If there are any string names, this will be a buffer containing all the
		/// values of those names. The consumer should free the buffer with <c>IMalloc::Free</c> when finished working with the names. If
		/// *pcColumns is zero on output, the provider does not allocate any memory and ensures that *ppStringsBuffer is a null pointer on
		/// output. Each of the individual string values stored in this buffer is terminated by a null-termination character. Therefore, the
		/// buffer may contain one or more strings, each with its own null-termination character, and may contain embedded null-termination characters.
		/// </param>
		/// <returns>
		/// <list type="bullet">
		/// <item>
		/// <description>
		/// <para>S_OK The method succeeded.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>E_FAIL A provider-specific error occurred.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>E_INVALIDARG pcColumns, prgInfo, or ppStringsBuffer was a null pointer.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>E_OUTOFMEMORY The provider was unable to allocate sufficient memory in which to return the column information structures.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// E_UNEXPECTED <c>ITransaction::Commit</c> or <c>ITransaction::Abort</c> was called, and the object is in a zombie state. This
		/// error can be returned only when the method is called on a rowset.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// DB_E_ERRORSINCOMMAND The command text contained one or more errors. Providers should use OLE DB error objects to return details
		/// about the errors.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_E_NOCOMMAND No command text was set. This error can be returned only when this method is called from the command object.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_E_NOTABLE <c>ICommandPrepare</c> was not implemented, and the specific table or view does not exist in the data store.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// DB_E_NOTPREPARED The command exposed <c>ICommandPrepare</c>, and the command text was set but the command was not prepared. This
		/// error can be returned only when this method is called from the command object.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// DB_E_NOTREENTRANT The provider called a method from <c>IRowsetNotify</c> in the consumer that had not yet returned, and the
		/// provider does not support reentrancy in this method.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_SEC_E_PERMISSIONDENIED The consumer did not have sufficient permission to retrieve the column information.</para>
		/// </description>
		/// </item>
		/// </list>
		/// </returns>
		// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/ms722704(v=vs.85)
		// HRESULT GetColumnInfo ( DBORDINAL *pcColumns, DBCOLUMNINFO **prgInfo, OLECHAR **ppStringsBuffer);
		[PreserveSig]
		new HRESULT GetColumnInfo(out DBORDINAL pcColumns, out SafeIMallocHandle prgInfo, out SafeIMallocHandle ppStringsBuffer);

		/// <summary>Returns an array of ordinals of the columns in a rowset that are identified by the specified column IDs.</summary>
		/// <param name="cColumnIDs">
		/// [in] The number of column IDs to map. If cColumnIDs is 0, <c>IColumnsInfo::MapColumnIDs</c> does nothing and returns S_OK.
		/// </param>
		/// <param name="rgColumnIDs">
		/// [in] An array of IDs of the columns of which to determine the column ordinals. If rgColumnIDs contains a duplicate column ID, a
		/// column ordinal is returned once for each occurrence of the column ID. If the column ID is invalid, the corresponding element of
		/// rgColumns is set to DB_INVALIDCOLUMN.
		/// </param>
		/// <param name="rgColumns">
		/// [out] An array of cColumnIDs ordinals of the columns identified by the elements of rgColumnIDs. The consumer allocates, but is
		/// not required to initialize, memory for this array and passes the address of this memory to the provider. The provider returns the
		/// column IDs in the array.
		/// </param>
		/// <returns>
		/// <list type="bullet">
		/// <item>
		/// <description>
		/// <para>S_OK The method succeeded. All elements of rgColumns are set to values other than DB_INVALIDCOLUMN.</para>
		/// <para>
		/// cColumnIDs was zero; the method succeeded but did nothing. This return code supersedes E_INVALIDARG if cColumnIDs was zero and
		/// either or both rgColumnIDs and rgColumns was a null pointer.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// DB_S_ERRORSOCCURRED An element of rgColumnIDs was invalid. If the column ID is invalid, the corresponding element of rgColumns is
		/// set to DB_INVALIDCOLUMN.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>E_FAIL A provider-specific error occurred.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>E_INVALIDARG cColumnIDs was not 0, and rgColumnIDs was a null pointer.</para>
		/// <para>rgColumns was a null pointer.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// E_UNEXPECTED <c>ITransaction::Commit</c> or <c>ITransaction::Abort</c> was called, and the object is in a zombie state. This
		/// error can be returned only when the method is called on a rowset.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_E_ERRORSOCCURRED All elements of rgColumnIDs were invalid. All elements of rgColumns are set to DB_INVALIDCOLUMN.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_E_NOCOMMAND No command text was set. This error can be returned only when this method is called from the command object.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_E_NOTABLE <c>ICommandPrepare</c> was not implemented, and the specific table or view does not exist in the data store.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// DB_E_NOTPREPARED The command exposed <c>ICommandPrepare</c>, and the command text was set but the command was not prepared. This
		/// error can be returned only when this method is called from the command object.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// DB_E_NOTREENTRANT The provider called a method from <c>IRowsetNotify</c> in the consumer that had not yet returned, and the
		/// provider does not support reentrancy in this method.
		/// </para>
		/// </description>
		/// </item>
		/// </list>
		/// </returns>
		// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/ms714200(v=vs.85) HRESULT MapColumnIDs ( DBORDINAL cColumnIDs,
		// const DBID rgColumnIDs[], DBORDINAL rgColumns[]);
		[PreserveSig]
		new HRESULT MapColumnIDs(DBORDINAL cColumnIDs, [In, Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] DBID[]? rgColumnIDs,
			[Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] DBORDINAL[]? rgColumns);

		/// <summary>
		/// <para>
		/// Retrieves column names or column metadata for a row or rowset. Column names are returned in an array of column IDs (DBIDs).
		/// Column metadata is returned in an array of DBCOLUMNINFO structures.
		/// </para>
		/// <para>For information about column IDs, see Column IDs. For information about DBCOLUMNINFO structures, see IColumnsInfo::GetColumnInfo.</para>
		/// </summary>
		/// <param name="cColumnIDMasks">
		/// [in] The count of column name masks in rgColumnIDMasks. If cColumnIDMasks is zero, IColumnsInfo2::GetRestrictedColumnInfo
		/// enumerates all columns in the row.
		/// </param>
		/// <param name="rgColumnIDMasks">
		/// [in] An array of cColumnIDMasks column name masks used to restrict the set of columns enumerated. All columns whose DBID matches
		/// the elements of rgColumnIDMasks or whose names begin with the string contained in the pwszName element of any of the DBIDs in
		/// this array will be returned in the enumeration. If cColumnIDMasks is zero, rgColumnIDMasks is ignored.
		/// </param>
		/// <param name="dwFlags">[in] Reserved. Must be zero.</param>
		/// <param name="pcColumns">
		/// [out] A pointer to memory in which to return a count of the column names and DBCOLUMNINFO structures returned in prgColumnIDs and
		/// prgColumnInfo, respectively. If no columns are described or if the method terminates with an error, ***pcColumns is set to zero.
		/// </param>
		/// <param name="prgColumnIDs">
		/// [out] A pointer to memory in which to return an array of column IDs (DBIDs) containing the requested column names.
		/// IColumnsInfo2::GetRestrictedColumnInfo returns either all columns or the columns selected by rgColumnIDMasks. This argument
		/// duplicates the DBIDs provided in the prgColumnInfo argument but is provided for direct use with methods such as
		/// IRowSchemaChange::DeleteColumns that require an array of DBIDs. The provider allocates memory for the DBIDs. The consumer is
		/// responsible for releasing this memory with IMalloc::Free. If an error code is returned and prgColumnIDs is not a null pointer,
		/// ***prgColumnIDs should be set to NULL.
		/// </param>
		/// <param name="prgColumnInfo">
		/// [out] A pointer to memory in which to return an array of DBCOLUMNINFO structures containing the requested column names.
		/// IColumnsInfo2::GetRestrictedColumnInfo returns either all columns or the columns selected by rgColumnIDMasks. The provider
		/// allocates memory for the DBCOLUMNINFO structures. The consumer is responsible for releasing this memory with IMalloc::Free. If an
		/// error code is returned and prgColumnInfo is not a null pointer, ***prgColumnInfo should be set to NULL.
		/// </param>
		/// <param name="ppStringsBuffer">
		/// [out] A pointer to memory in which to return a pointer to storage for all string values (names used with either columnid or
		/// *pwszName of the DBCOLUMNINFO structure) within a single allocation block. If no columns are returned, ppStringsBuffer should be
		/// set to NULL. If there are any string names, ppStringsBuffer points to a buffer containing all the values of those names. The
		/// consumer is responsible for releasing this memory with IMalloc::Free. If an error code is returned and ppStringsBuffer is not a
		/// null pointer, ***ppStringsBuffer should be set to NULL.
		/// </param>
		/// <returns>
		/// <list type="bullet">
		/// <item>
		/// <description>
		/// <para>S_OK The requested columns were successfully enumerated.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_E_BADCOLUMNID An element of rgColumnIDMasks was an invalid DBID.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_E_DELETEDROW The row was deleted or moved.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// DB_E_NOCOLUMN No columns matched the mask criteria. The provider sets ***pcColumns to zero and other output arguments to NULL.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// DB_E_NOTREENTRANT The provider called a method from IRowsetNotify in the consumer that had not yet returned, and the provider
		/// does not support reentrancy in this method.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_SEC_E_PERMISSIONDENIED The consumer did not have sufficient permission to retrieve the column information.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>E_INVALIDARG cColumnIDMasks was not zero, and rgColumnIDMasks was a null pointer.</para>
		/// <para>pcColumns was a null pointer.</para>
		/// <para>ppStringsBuffer was a null pointer.</para>
		/// <para>prgColumnIDs and prgColumnInfo are both null pointers.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>E_FAIL A provider-specific error occurred.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// E_OUTOFMEMORY The provider was unable to allocate sufficient memory in which to return the column information structures or
		/// string buffer.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>E_UNEXPECTED ITransaction::Commit or ITransaction::Abort was called, and the object is in a zombie state.</para>
		/// </description>
		/// </item>
		/// </list>
		/// </returns>
		// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/ms712988(v=vs.85) HRESULT GetRestrictedColumnInfo( DBORDINAL
		// cColumnIDMasks, const DBID rgColumnIDMasks[ ], DWORD dwFlags, DBORDINAL *pcColumns, DBID **prgColumnIDs, DBCOLUMNINFO
		// **prgColumnInfo, OLECHAR **ppStringsBuffer);
		void GetRestrictedColumnInfo(DBORDINAL cColumnIDMasks, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] DBID[]? rgColumnIDMasks,
			[Optional] uint dwFlags, out DBORDINAL pcColumns, out SafeIMallocHandle prgColumnIDs, out SafeIMallocHandle prgColumnInfo, out SafeIMallocHandle ppStringsBuffer);
	}

	/// <summary>
	/// <para>
	/// <c>ICommand</c> contains methods to execute commands. A command can be executed many times, and the parameter values can vary. This
	/// interface is mandatory on commands.
	/// </para>
	/// <para>A command object contains a single text command, which is specified through <c>ICommandText</c></para>
	/// </summary>
	// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/ms709737(v=vs.85)
	[PInvokeData("")]
	[ComImport, Guid("0c733a63-2a1c-11ce-ade5-00aa0044773d"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ICommand
	{
		/// <summary>Cancels the current command execution.</summary>
		// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/ms714402(v=vs.85) HRESULT Cancel();
		void Cancel();

		/// <summary>Executes the command.</summary>
		/// <param name="pUnkOuter">
		/// [in] A pointer to the controlling <c>IUnknown</c> interface if the rowset is being created as part of an aggregate; otherwise, it
		/// is null.
		/// </param>
		/// <param name="riid">
		/// <para>
		/// [in] The requested IID for the rowset returned in *ppRowset. This interface is conceptually added to the list of required
		/// interfaces on the resulting rowset, and the method fails (E_NOINTERFACE) if that interface cannot be supported on the resulting
		/// rowset. If the command has any open rowsets, requesting an interface that is not supported on those open rowsets will generally
		/// return E_NOINTERFACE as it is not possible to change the properties supported on a command with open rowsets. In addition,
		/// specifying the IID of a nonmandatory interface that has not been explicitly requested through rowset properties set on a prepared
		/// command might reduce the provider's ability to optimize the command, because the provider might have to rebuild the access plan
		/// to satisfy the additional interface.
		/// </para>
		/// <para>
		/// If this is IID_NULL, ppRowset is ignored and no rowset is returned, even if the command would otherwise generate a rowset.
		/// Specifying IID_NULL is useful in the case of text commands that do not generate rowsets, such as data definition commands, as a
		/// hint to the provider that no rowset properties need to be verified.
		/// </para>
		/// <para>
		/// If riid is <c>IID_IMultipleResults</c>, the provider creates a multiple results object and returns a pointer to it in *ppRowset;
		/// it does this even if the command generates a single result. If the provider supports multiple results and the command generates
		/// multiple results but riid is not <c>IID_IMultipleResults</c>, the provider returns the first result and discards any remaining
		/// results. If riid is <c>IID_IMultipleResults</c> and the provider does not support multiple results, <c>ICommand::Execute</c>
		/// returns E_NOINTERFACE.
		/// </para>
		/// </param>
		/// <param name="pParams">
		/// <para>
		/// [in/out] A pointer to a DBPARAMS structure that specifies the values for one or more parameters. In text commands that use
		/// parameters, if no value is specified for a parameter through pParams, an error occurs.
		/// </para>
		/// <para>The elements of this structure are used as described in the following table.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Element</description>
		/// <description>Description</description>
		/// </listheader>
		/// <item>
		/// <description><c>pData</c></description>
		/// <description>
		/// Pointer to a buffer from which the provider retrieves input parameter data and to which the provider returns output parameter
		/// data, according to the bindings specified by <c>hAccessor</c>. This pointer must be a valid pointer to a contiguous block of
		/// consumer-owned memory for the input and output parameter values. For more information, see Getting Data and Setting Data. When
		/// output parameter data is available to the consumer depends on the DBPROP_OUTPUTPARAMETERAVAILABILITY property.
		/// </description>
		/// </item>
		/// <item>
		/// <description><c>cParamSets</c></description>
		/// <description>
		/// The number of sets of parameters in * <c>pData</c>. If <c>cParamSets</c> is greater than one, the bindings described by
		/// <c>hAccessor</c> define the offsets within * <c>pData</c> for each set of parameters and <c>cbRowSize</c> (as specified in
		/// <c>IAccessor::CreateAccessor</c>) defines a single fixed offset between each of those values and the corresponding values for the
		/// next set of parameters. Sets of multiple parameters ( <c>cParamSets</c> is greater than one) can be specified only if
		/// DBPROP_MULTIPLEPARAMSETS is VARIANT_TRUE and the command does not return any rowsets.
		/// </description>
		/// </item>
		/// <item>
		/// <description><c>hAccessor</c></description>
		/// <description>
		/// Handle of the accessor to use. If <c>hAccessor</c> is the handle of a null accessor ( <c>cBindings</c> in
		/// <c>IAccessor::CreateAccessor</c> was 0), <c>ICommand::Execute</c> does not retrieve or return any parameter values.
		/// </description>
		/// </item>
		/// </list>
		/// <para>
		/// If the provider is able to determine the number of parameters in the command and the command text does not include parameters,
		/// the provider ignores this argument.
		/// </para>
		/// </param>
		/// <param name="pcRowsAffected">
		/// <para>
		/// [out] A pointer to memory in which to return the count of rows affected by a command that updates, deletes, or inserts rows. If
		/// cParamSets is greater than one, *pcRowsAffected is the total number of rows affected by all of the sets of parameters specified
		/// in the execution. If the number of affected rows is not available, *pcRowsAffected is set to DB_COUNTUNAVAILABLE on output. If
		/// riid is <c>IID_IMultipleResults</c>, the value returned in *pcRowsAffected is either DB_COUNTUNAVAILABLE or the total number of
		/// rows affected by the entire command; to retrieve individual row counts, the consumer calls <c>IMultipleResults::GetResult</c>. If
		/// the command does not update, delete, or insert rows, *pcRowsAffected is undefined on output. If pcRowsAffected is a null pointer,
		/// no count of rows is returned.
		/// </para>
		/// <para>
		/// pcRowsAffected is undefined if <c>ICommand::Execute</c> returns DB_S_ASYNCHRONOUS. For asynchronously executed commands, the
		/// consumer should call <c>IDBAsynchStatus::GetStatus</c> to obtain the number of rows affected in pulProgress.
		/// </para>
		/// </param>
		/// <param name="ppRowset">
		/// <para>
		/// [in/out] A pointer to the memory in which to return the rowset's pointer. If ppRowset is a null pointer, no rowset is created.
		/// However, if the DBPROP_OUTPUTSTREAM property is set and the result of <c>ICommand::Execute</c> is a stream object, a null pointer
		/// is an acceptable value.
		/// </para>
		/// <para>
		/// If ppRowset is not a null pointer and an interface on a stream object was requested, the provider returns to *ppRowset the
		/// interface pointer set in the DBPROP_OUTPUTSTREAM property. The consumer must release the interface pointer in *ppRowset when it
		/// is no longer needed.
		/// </para>
		/// <para>If *ppRowset is a null pointer, the provider did not write any results to the stream specified in DBPROP_OUTPUTSTREAM.</para>
		/// </param>
		/// <returns>
		/// <list type="bullet">
		/// <item>
		/// <description>
		/// <para>
		/// S_OK The method succeeded. In all DBPROP structures returned by the method, dwStatus is set to DBPROPSTATUS_OK; the status of all
		/// input parameters bound by the accessor is set to DBSTATUS_S_OK or DBSTATUS_S_ISNULL; and the status of all output parameters
		/// bound by the accessor is set to DBSTATUS_S_OK, DBSTATUS_S_ISNULL, or DBSTATUS_S_TRUNCATED ? or is unknown because the parameter
		/// value has not been returned yet.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// DB_S_ASYNCHRONOUS The method has initiated asynchronous creation of the rowset. The consumer can call <c>IDBAsynchStatus</c> to
		/// poll for status or <c>IConnectionPointContainer</c> to obtain the IID_IDBAsynchNotify connection point. Attempting to call any
		/// other interfaces may fail, and the full set of interfaces may not be available on the object until asynchronous initialization of
		/// the rowset has completed. DB_S_ASYNCHRONOUS should be returned before DB_S_ERRORSOCCURRED.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_S_ERRORSOCCURRED This can be returned for any of the following reasons:</para>
		/// <para>
		/// DB_S_ASYNCHRONOUS should be returned before DB_S_ERRORSOCCURRED. Once rowset population is complete, the consumer can see
		/// DB_S_ERRORSOCCURRED either by calling <c>IDBAsynchStatus::GetStatus</c> or by receiving <c>IDBAsynchNotify::OnStop</c>.
		/// </para>
		/// <para>
		/// DB_S_ERRORSOCCURRED should be returned before DB_S_NOTSINGLETON because the status values can be checked, and providers are not
		/// required to return DB_S_NOTSINGLETON.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// DB_S_NOTSINGLETON The provider supports returning row objects on <c>ICommand::Execute</c>, and the consumer requested a row
		/// object but the result was not a singleton. A row object of the first row of the rowset is returned. Returning this result may be
		/// expensive, so providers are not required to do so. If DB_S_ERRORSOCCURRED also applies to the execution of this method, it takes
		/// precedence over DB_S_NOTSINGLETON.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// DB_S_STOPLIMITREACHED Execution has been stopped because a resource limit has been reached. The results obtained so far have been
		/// returned. Execution cannot be resumed.
		/// </para>
		/// <para>
		/// Multiple sets of parameters were specified, and one or more (but not all) of the parameters have been processed prior to the
		/// command being canceled by <c>ICommand::Cancel</c> or <c>IDBAsynchStatus::Abort</c>.
		/// </para>
		/// <para>
		/// This return code takes precedence over DB_S_ERRORSOCCURRED. That is, if the conditions described here and in those described in
		/// DB_S_ERRORSOCCURRED both occur, the provider returns this code. When the consumer receives this return code, it should also check
		/// for the conditions described in DB_S_ERRORSOCCURRED.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>E_FAIL A provider-specific error occurred.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// E_INVALIDARG riid was not IID_NULL, and ppRowset was a null pointer. Any streams used to pass input parameters are not released.
		/// </para>
		/// <para>
		/// The parameter information was invalid. Parameter information may be invalid for any of the following reasons. In all cases, any
		/// streams used to pass input parameters are not released.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>E_NOINTERFACE The rowset did not support the interface specified in riid.</para>
		/// <para>riid was <c>IID_IMultipleResults</c>, and the provider did not support multiple results objects.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// DB_E_ABORTLIMITREACHED Execution has been aborted because a resource limit has been reached. For example, a query timed out. No
		/// results have been returned.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// DB_E_BADACCESSORHANDLE pParams was not ignored, and hAccessor in the DBPARAMS structure pointed to by pParams was invalid. Any
		/// streams used to pass input parameters are not released.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// DB_E_BADACCESSORTYPE hAccessor in the DBPARAMS structure pointed to by pParams was not the handle of a parameter accessor. Any
		/// streams used to pass input parameters are not released.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_E_CANCELED The command was canceled by a call to <c>ICommand::Cancel</c> on another thread. No records were affected.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// DB_E_CANTCONVERTVALUE A literal value in the command text could not be converted to the type of the associated column for reasons
		/// other than data overflow.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_E_DATAOVERFLOW A literal value in the command text overflowed the type specified by the associated column.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// DB_E_ERRORSINCOMMAND The command text contained one or more errors. Providers should use OLE DB error objects to return details
		/// about the errors.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// DB_E_ERRORSOCCURRED The method failed due to one or more nonvalid input parameter values. To determine which input parameter
		/// values were not valid, the consumer checks the status values. (For a list of status values that can be returned by this method,
		/// see "Status Values Used When Setting Data" in Status.) If any streams were used to pass input parameters, only those with the
		/// status value equal to DBSTATUS_S_OK on input are released; otherwise, no attempt is made to release the stream. If the consumer
		/// provides storage objects for additional bound parameters that are not used by the current command, it is a consumer programming
		/// error and the provider does not attempt to release these parameters.
		/// </para>
		/// <para>
		/// The command was not executed, and no rowset was returned because one or more properties ? for which the dwOptions element of the
		/// DBPROP structure was DBPROPOPTIONS_REQUIRED ? were not set.
		/// </para>
		/// <para>Multiple parameter sets were passed with a command that returns a rowset. (Some providers might not return this error.)</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_E_INTEGRITYVIOLATION A literal value in the command text violated the integrity constraints for the column.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// DB_E_NOAGGREGATION pUnkOuter was not a null pointer, and the provider is an OLE DB 1.0 or 1.1 provider that does not support
		/// aggregation of the rowset object being created. Any streams used to pass input parameters are not released.
		/// </para>
		/// <para>
		/// pUnkOuter was not a null pointer, and riid was not <c>IID_IUnknown</c>. Any streams used to pass input parameters are not released.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// DB_E_NOCOMMAND No command text was currently set on the command object. Any streams used to pass input parameters are not released.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_E_NOTABLE The specific table or view does not exist in the data store.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// DB_E_NOTFOUND The provider supports row objects, a row was requested via riid or DBPROP_IRow, and no rows satisfied the selection
		/// criteria of the command.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_E_PARAMNOTOPTIONAL A value was not supplied for a required parameter.</para>
		/// <para>The command text used parameters and pParams was a null pointer.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// DB_E_PARAMUNAVAILABLE Provider cannot derive parameter information, and <c>ICommandWithParameters::SetParameterInfo</c> has not
		/// been called.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// DB_SEC_E_PERMISSIONDENIED The consumer did not have sufficient permission to execute the command. For example, a rowset-returning
		/// command specified a column for which the consumer does not have read permission, or an update command specified a column for
		/// which the consumer does not have write permission.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// DB_E_OBJECTOPEN The provider would have to open a new connection to support the operation, and DBPROP_MULTIPLECONNECTIONS is set
		/// to VARIANT_FALSE. Any streams used to pass input parameters are not released.
		/// </para>
		/// <para>
		/// If a session is enlisted in a global transaction and a command requires the creation of an additional connection, the provider
		/// should return DB_E_OBJECTOPEN. Providers written prior to OLE DB 2.6 may return E_FAIL.
		/// </para>
		/// </description>
		/// </item>
		/// </list>
		/// </returns>
		// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/ms718095(v=vs.85) HRESULT Execute ( IUnknown *pUnkOuter,
		// REFIID riid, DBPARAMS *pParams, DBROWCOUNT *pcRowsAffected, IUnknown **ppRowset);
		[PreserveSig]
		HRESULT Execute([In, Optional, MarshalAs(UnmanagedType.IUnknown)] object? pUnkOuter, in Guid riid, [In, Out, Optional] DBPARAMS? pParams,
			out DBROWCOUNT pcRowsAffected, [MarshalAs(UnmanagedType.IUnknown)] out object? ppRowset);

		/// <summary>Returns an interface pointer to the session that created the command.</summary>
		/// <param name="riid">[in] The IID of the interface on which to return a pointer.</param>
		/// <param name="ppSession">
		/// [out] A pointer to memory in which to return the interface pointer. If the provider does not have an object that created the
		/// command, it sets *ppSession to a null pointer. If <c>ICommand::GetDBSession</c> fails, it must attempt to set *ppSession to a
		/// null pointer.
		/// </param>
		/// <returns>
		/// <list type="bullet">
		/// <item>
		/// <description>
		/// <para>S_OK The method succeeded.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>S_FALSE The provider did not have an object that created the command. Therefore, it set *ppSession to a null pointer.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>E_FAIL A provider-specific error occurred.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>E_INVALIDARG ppSession was a null pointer.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>E_NOINTERFACE The session did not support the interface specified in riid.</para>
		/// </description>
		/// </item>
		/// </list>
		/// </returns>
		// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/ms719622(v=vs.85) HRESULT GetDBSession ( REFIID riid, IUnknown **ppSession);
		[PreserveSig]
		HRESULT GetDBSession(in Guid riid, [MarshalAs(UnmanagedType.IUnknown)] out object? ppSession);
	}

	/// <summary>
	/// <para>
	/// <c>ICommandProperties</c> specifies to the command the properties from the Rowset property group that must be supported by the
	/// rowsets returned by <c>ICommand::Execute</c>. A special case of these properties, and the ones most commonly requested, are the
	/// interfaces the rowset must support. In addition to interfaces, the consumer can request properties that modify the behavior of the
	/// rowset or interfaces.
	/// </para>
	/// <para>
	/// All rowsets must support <c>IRowset</c>, <c>IAccessor</c>, <c>IColumnsInfo</c>, <c>IRowsetInfo</c>, and <c>IConvertType</c>.
	/// Providers may choose to return rowsets supporting other interfaces if doing so is possible and if the support for the returned
	/// interfaces does not affect consumer code that is not expecting them. The riid parameter of <c>ICommand::Execute</c> should be one of
	/// the interfaces returned by <c>IRowsetInfo::GetProperties</c>.
	/// </para>
	/// <para>This interface is mandatory on commands.</para>
	/// </summary>
	// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/ms723044(v=vs.85)
	[PInvokeData("")]
	[ComImport, Guid("0c733a79-2a1c-11ce-ade5-00aa0044773d"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ICommandProperties
	{
		/// <summary>Returns the list of properties in the Rowset property group that are currently requested for the rowset.</summary>
		/// <param name="cPropertyIDSets">
		/// <para>[in] The number of DBPROPIDSET structures in rgPropertyIDSets.</para>
		/// <para>
		/// If cPropertyIDSets is zero, the provider ignores rgPropertyIDSets and returns the values of all properties in the Rowset property
		/// group for which values have been set or defaults exist. It does not return the values of properties in the Rowset property group
		/// for which values have not been set and no defaults exist nor does it return the values of properties for which no value has been
		/// set, no default exists, and for which a value will be set automatically because a value for another property in the Rowset
		/// property group has been set.
		/// </para>
		/// <para>
		/// If cPropertyIDSets is not zero, the provider returns the values of the requested properties. If a property is not supported, the
		/// returned value of dwStatus in the returned DBPROP structure for that property is DBPROPSTATUS_NOTSUPPORTED and the value of
		/// dwOptions is undefined.
		/// </para>
		/// </param>
		/// <param name="rgPropertyIDSets">
		/// <para>
		/// [in] An array of cPropertyIDSets DBPROPIDSET structures. The properties specified in these structures must belong to the Rowset
		/// property group. The provider returns the values of the properties specified in these structures. If cPropertyIDSets is zero, this
		/// parameter is ignored.
		/// </para>
		/// <para>
		/// For information about the properties in the Rowset property group that are defined by OLE DB, see Rowset Properties in Appendix
		/// C. For information about the DBPROPIDSET structure, see DBPROPIDSET Structure.
		/// </para>
		/// </param>
		/// <param name="pcPropertySets">
		/// [out] A pointer to memory in which to return the number of DBPROPSET structures returned in *prgPropertySets. If cPropertyIDSets
		/// is zero, *pcPropertySets is the total number of property sets for which the provider supports at least one property in the Rowset
		/// property group. If cPropertyIDSets is greater than zero, *pcPropertySets is set to cPropertyIDSets. If an error other than
		/// DB_E_ERRORSOCCURRED occurs, *pcPropertySets is set to zero.
		/// </param>
		/// <param name="prgPropertySets">
		/// <para>
		/// [out] A pointer to memory in which to return an array of DBPROPSET structures. If cPropertyIDSets is zero, one structure is
		/// returned for each property set that contains at least one property belonging to the Rowset property group. If cPropertyIDSets is
		/// not zero, one structure is returned for each property set specified in rgPropertyIDSets.
		/// </para>
		/// <para>
		/// If cPropertyIDSets is not zero, the DBPROPSET structures in *prgPropertySets are returned in the same order as the DBPROPIDSET
		/// structures in rgPropertyIDSets; that is, for corresponding elements of each array, the guidPropertySet elements are the same. If
		/// cPropertyIDs in an element of rgPropertyIDSets is not zero, the DBPROP structures in the corresponding element of
		/// *prgPropertySets are returned in the same order as the DBPROPID values in rgPropertyIDs. Therefore, in the case where no column
		/// properties are specified in rgPropertyIDSets, corresponding elements of the input rgPropertyIDs and the returned rgProperties
		/// have the same property ID. However, if a column property is requested in rgPropertyIDSets, multiple properties may be returned,
		/// one for each column, in rgProperties. In this case, corresponding elements of rgPropertyIDs and rgProperties will not have the
		/// same property ID and rgProperties will contain more elements than rgPropertyIDs.
		/// </para>
		/// <para>
		/// The provider allocates memory for the structures and returns the address to this memory; the consumer releases this memory with
		/// <c>IMalloc::Free</c> when it no longer needs the structures. Before calling <c>IMalloc::Free</c> for *prgPropertySets, the
		/// consumer should call <c>IMalloc::Free</c> for the rgProperties element within each element of *prgPropertySets. The consumer must
		/// also call <c>VariantClear</c> for the vValue member of each DBPROP structure in order to prevent a memory leak in cases where the
		/// variant contains a reference type (such as a BSTR.) If *pcPropertySets is zero on output or an error other than
		/// DB_E_ERRORSOCCURRED occurs, the provider does not allocate any memory and ensures that *prgPropertySets is a null pointer on output.
		/// </para>
		/// <para>For information about the DBPROPSET and DBPROP structures, see DBPROPSET Structure and DBPROP Structure.</para>
		/// </param>
		/// <returns>
		/// <list type="bullet">
		/// <item>
		/// <description>
		/// <para>S_OK The method succeeded. In all DBPROP structures returned by the method, dwStatus is set to DBPROPSTATUS_OK.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// DB_S_ERRORSOCCURRED No value was returned for one or more properties. The consumer checks dwStatus in the DBPROP structure to
		/// determine the properties for which values were not returned. <c>ICommandProperties::GetProperties</c> can fail to return
		/// properties for a number of reasons, including:
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>E_FAIL A provider-specific error occurred.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>E_INVALIDARG cPropertyIDSets was not equal to zero, and rgPropertyIDSets was a null pointer.</para>
		/// <para>pcPropertySets or prgPropertySets was a null pointer.</para>
		/// <para>In an element of rgPropertyIDSets, cPropertyIDs was not zero and rgPropertyIDs was a null pointer.</para>
		/// <para>
		/// In an element of rgPropertyIDSets, guidPropertySet was DBPROPSET_PROPERTIESINERROR and cPropertyIDs was not zero, or
		/// rgPropertyIDs was not a null pointer.
		/// </para>
		/// <para>cPropertyIDSets was greater than one, and in an element of rgPropertyIDSets, guidPropertySet was DBPROPSET_PROPERTIESINERROR.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>E_OUTOFMEMORY The provider was unable to allocate sufficient memory in which to return the DBPROPSET or DBPROP structures.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// DB_E_ERRORSOCCURRED No values were returned for any properties. The provider allocates memory for *prgPropertySets, and the
		/// consumer checks dwStatus in the DBPROP structures to determine why properties were not returned. The consumer frees this memory
		/// when it no longer needs the information.
		/// </para>
		/// </description>
		/// </item>
		/// </list>
		/// </returns>
		// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/ms723119(v=vs.85) HRESULT GetProperties ( const ULONG
		// cPropertyIDSets, const DBPROPIDSET rgPropertyIDSets[], ULONG * pcPropertySets, DBPROPSET ** prgPropertySets);
		[PreserveSig]
		HRESULT GetProperties(uint cPropertyIDSets, [In] SafeDBPROPIDSETListHandle rgPropertyIDSets,
			out uint pcPropertySets, out SafeDBPROPSETListHandle prgPropertySets);

		/// <summary>Sets properties in the Rowset property group.</summary>
		/// <param name="cPropertySets">
		/// [in] The number of DBPROPSET structures in rgPropertySets. If this is zero, the provider ignores rgPropertySets and the method
		/// does not do anything.
		/// </param>
		/// <param name="rgPropertySets">
		/// [in/out] An array of DBPROPSET structures containing properties and values to be set. The properties specified in these
		/// structures must belong to the Rowset property group. If the same property is specified more than once in rgPropertySets, the
		/// value is used is provider-specific. If cPropertySets is zero, this parameter is ignored.
		/// <para>
		/// For information about the properties in the Rowset property group that are defined by OLE DB, see Rowset Properties in Appendix
		/// C.For information about the DBPROPSET and DBPROP structures, see DBPROPSET Structure and DBPROP Structure.
		/// </para>
		/// </param>
		/// <returns>
		/// <list type="bullet">
		/// <item>
		/// <description>
		/// <para>S_OK The method succeeded. In all DBPROP structures passed to the method, dwStatus is set to DBPROPSTATUS_OK.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// DB_S_ERRORSOCCURRED One or more properties were not set. Properties not in error remain set. The consumer checks dwStatus in the
		/// DBPROP structures to determine which properties were not set. <c>ICommandProperties::SetProperties</c> can fail to set properties
		/// for a number of reasons, including the following:
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>E_FAIL A provider-specific error occurred.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>E_INVALIDARG cPropertySets was not equal to zero, and rgPropertySets was a null pointer.</para>
		/// <para>In an element of rgPropertySets, cProperties was not zero and rgProperties was a null pointer.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// DB_E_ERRORSOCCURRED All property values were invalid and no properties were set. The consumer checks dwStatus in the DBPROP
		/// structures to determine why properties were not set. The method can fail to set properties for any of the reasons specified in DB_S_ERRORSOCCURRED.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_E_OBJECTOPEN Properties cannot be set while there is an open rowset.</para>
		/// </description>
		/// </item>
		/// </list>
		/// </returns>
		// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/ms711497(v=vs.85) HRESULT SetProperties ( ULONG cPropertySets,
		// DBPROPSET rgPropertySets[]);
		[PreserveSig]
		HRESULT SetProperties(uint cPropertySets, [In] SafeDBPROPSETListHandle? rgPropertySets);
	}

	/// <summary>
	/// <para>This interface is mandatory on commands.</para>
	/// <para>
	/// A command object can have only one text command. When the command text is specified through <c>ICommandText::SetCommandText</c>, it
	/// replaces the existing command text.
	/// </para>
	/// </summary>
	// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/ms714914(v=vs.85)
	[PInvokeData("")]
	[ComImport, Guid("0c733a27-2a1c-11ce-ade5-00aa0044773d"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ICommandText : ICommand
	{
		/// <summary>Cancels the current command execution.</summary>
		// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/ms714402(v=vs.85) HRESULT Cancel();
		new void Cancel();

		/// <summary>Executes the command.</summary>
		/// <param name="pUnkOuter">
		/// [in] A pointer to the controlling <c>IUnknown</c> interface if the rowset is being created as part of an aggregate; otherwise, it
		/// is null.
		/// </param>
		/// <param name="riid">
		/// <para>
		/// [in] The requested IID for the rowset returned in *ppRowset. This interface is conceptually added to the list of required
		/// interfaces on the resulting rowset, and the method fails (E_NOINTERFACE) if that interface cannot be supported on the resulting
		/// rowset. If the command has any open rowsets, requesting an interface that is not supported on those open rowsets will generally
		/// return E_NOINTERFACE as it is not possible to change the properties supported on a command with open rowsets. In addition,
		/// specifying the IID of a nonmandatory interface that has not been explicitly requested through rowset properties set on a prepared
		/// command might reduce the provider's ability to optimize the command, because the provider might have to rebuild the access plan
		/// to satisfy the additional interface.
		/// </para>
		/// <para>
		/// If this is IID_NULL, ppRowset is ignored and no rowset is returned, even if the command would otherwise generate a rowset.
		/// Specifying IID_NULL is useful in the case of text commands that do not generate rowsets, such as data definition commands, as a
		/// hint to the provider that no rowset properties need to be verified.
		/// </para>
		/// <para>
		/// If riid is <c>IID_IMultipleResults</c>, the provider creates a multiple results object and returns a pointer to it in *ppRowset;
		/// it does this even if the command generates a single result. If the provider supports multiple results and the command generates
		/// multiple results but riid is not <c>IID_IMultipleResults</c>, the provider returns the first result and discards any remaining
		/// results. If riid is <c>IID_IMultipleResults</c> and the provider does not support multiple results, <c>ICommand::Execute</c>
		/// returns E_NOINTERFACE.
		/// </para>
		/// </param>
		/// <param name="pParams">
		/// <para>
		/// [in/out] A pointer to a DBPARAMS structure that specifies the values for one or more parameters. In text commands that use
		/// parameters, if no value is specified for a parameter through pParams, an error occurs.
		/// </para>
		/// <para>The elements of this structure are used as described in the following table.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Element</description>
		/// <description>Description</description>
		/// </listheader>
		/// <item>
		/// <description><c>pData</c></description>
		/// <description>
		/// Pointer to a buffer from which the provider retrieves input parameter data and to which the provider returns output parameter
		/// data, according to the bindings specified by <c>hAccessor</c>. This pointer must be a valid pointer to a contiguous block of
		/// consumer-owned memory for the input and output parameter values. For more information, see Getting Data and Setting Data. When
		/// output parameter data is available to the consumer depends on the DBPROP_OUTPUTPARAMETERAVAILABILITY property.
		/// </description>
		/// </item>
		/// <item>
		/// <description><c>cParamSets</c></description>
		/// <description>
		/// The number of sets of parameters in * <c>pData</c>. If <c>cParamSets</c> is greater than one, the bindings described by
		/// <c>hAccessor</c> define the offsets within * <c>pData</c> for each set of parameters and <c>cbRowSize</c> (as specified in
		/// <c>IAccessor::CreateAccessor</c>) defines a single fixed offset between each of those values and the corresponding values for the
		/// next set of parameters. Sets of multiple parameters ( <c>cParamSets</c> is greater than one) can be specified only if
		/// DBPROP_MULTIPLEPARAMSETS is VARIANT_TRUE and the command does not return any rowsets.
		/// </description>
		/// </item>
		/// <item>
		/// <description><c>hAccessor</c></description>
		/// <description>
		/// Handle of the accessor to use. If <c>hAccessor</c> is the handle of a null accessor ( <c>cBindings</c> in
		/// <c>IAccessor::CreateAccessor</c> was 0), <c>ICommand::Execute</c> does not retrieve or return any parameter values.
		/// </description>
		/// </item>
		/// </list>
		/// <para>
		/// If the provider is able to determine the number of parameters in the command and the command text does not include parameters,
		/// the provider ignores this argument.
		/// </para>
		/// </param>
		/// <param name="pcRowsAffected">
		/// <para>
		/// [out] A pointer to memory in which to return the count of rows affected by a command that updates, deletes, or inserts rows. If
		/// cParamSets is greater than one, *pcRowsAffected is the total number of rows affected by all of the sets of parameters specified
		/// in the execution. If the number of affected rows is not available, *pcRowsAffected is set to DB_COUNTUNAVAILABLE on output. If
		/// riid is <c>IID_IMultipleResults</c>, the value returned in *pcRowsAffected is either DB_COUNTUNAVAILABLE or the total number of
		/// rows affected by the entire command; to retrieve individual row counts, the consumer calls <c>IMultipleResults::GetResult</c>. If
		/// the command does not update, delete, or insert rows, *pcRowsAffected is undefined on output. If pcRowsAffected is a null pointer,
		/// no count of rows is returned.
		/// </para>
		/// <para>
		/// pcRowsAffected is undefined if <c>ICommand::Execute</c> returns DB_S_ASYNCHRONOUS. For asynchronously executed commands, the
		/// consumer should call <c>IDBAsynchStatus::GetStatus</c> to obtain the number of rows affected in pulProgress.
		/// </para>
		/// </param>
		/// <param name="ppRowset">
		/// <para>
		/// [in/out] A pointer to the memory in which to return the rowset's pointer. If ppRowset is a null pointer, no rowset is created.
		/// However, if the DBPROP_OUTPUTSTREAM property is set and the result of <c>ICommand::Execute</c> is a stream object, a null pointer
		/// is an acceptable value.
		/// </para>
		/// <para>
		/// If ppRowset is not a null pointer and an interface on a stream object was requested, the provider returns to *ppRowset the
		/// interface pointer set in the DBPROP_OUTPUTSTREAM property. The consumer must release the interface pointer in *ppRowset when it
		/// is no longer needed.
		/// </para>
		/// <para>If *ppRowset is a null pointer, the provider did not write any results to the stream specified in DBPROP_OUTPUTSTREAM.</para>
		/// </param>
		/// <returns>
		/// <list type="bullet">
		/// <item>
		/// <description>
		/// <para>
		/// S_OK The method succeeded. In all DBPROP structures returned by the method, dwStatus is set to DBPROPSTATUS_OK; the status of all
		/// input parameters bound by the accessor is set to DBSTATUS_S_OK or DBSTATUS_S_ISNULL; and the status of all output parameters
		/// bound by the accessor is set to DBSTATUS_S_OK, DBSTATUS_S_ISNULL, or DBSTATUS_S_TRUNCATED ? or is unknown because the parameter
		/// value has not been returned yet.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// DB_S_ASYNCHRONOUS The method has initiated asynchronous creation of the rowset. The consumer can call <c>IDBAsynchStatus</c> to
		/// poll for status or <c>IConnectionPointContainer</c> to obtain the IID_IDBAsynchNotify connection point. Attempting to call any
		/// other interfaces may fail, and the full set of interfaces may not be available on the object until asynchronous initialization of
		/// the rowset has completed. DB_S_ASYNCHRONOUS should be returned before DB_S_ERRORSOCCURRED.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_S_ERRORSOCCURRED This can be returned for any of the following reasons:</para>
		/// <para>
		/// DB_S_ASYNCHRONOUS should be returned before DB_S_ERRORSOCCURRED. Once rowset population is complete, the consumer can see
		/// DB_S_ERRORSOCCURRED either by calling <c>IDBAsynchStatus::GetStatus</c> or by receiving <c>IDBAsynchNotify::OnStop</c>.
		/// </para>
		/// <para>
		/// DB_S_ERRORSOCCURRED should be returned before DB_S_NOTSINGLETON because the status values can be checked, and providers are not
		/// required to return DB_S_NOTSINGLETON.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// DB_S_NOTSINGLETON The provider supports returning row objects on <c>ICommand::Execute</c>, and the consumer requested a row
		/// object but the result was not a singleton. A row object of the first row of the rowset is returned. Returning this result may be
		/// expensive, so providers are not required to do so. If DB_S_ERRORSOCCURRED also applies to the execution of this method, it takes
		/// precedence over DB_S_NOTSINGLETON.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// DB_S_STOPLIMITREACHED Execution has been stopped because a resource limit has been reached. The results obtained so far have been
		/// returned. Execution cannot be resumed.
		/// </para>
		/// <para>
		/// Multiple sets of parameters were specified, and one or more (but not all) of the parameters have been processed prior to the
		/// command being canceled by <c>ICommand::Cancel</c> or <c>IDBAsynchStatus::Abort</c>.
		/// </para>
		/// <para>
		/// This return code takes precedence over DB_S_ERRORSOCCURRED. That is, if the conditions described here and in those described in
		/// DB_S_ERRORSOCCURRED both occur, the provider returns this code. When the consumer receives this return code, it should also check
		/// for the conditions described in DB_S_ERRORSOCCURRED.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>E_FAIL A provider-specific error occurred.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// E_INVALIDARG riid was not IID_NULL, and ppRowset was a null pointer. Any streams used to pass input parameters are not released.
		/// </para>
		/// <para>
		/// The parameter information was invalid. Parameter information may be invalid for any of the following reasons. In all cases, any
		/// streams used to pass input parameters are not released.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>E_NOINTERFACE The rowset did not support the interface specified in riid.</para>
		/// <para>riid was <c>IID_IMultipleResults</c>, and the provider did not support multiple results objects.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// DB_E_ABORTLIMITREACHED Execution has been aborted because a resource limit has been reached. For example, a query timed out. No
		/// results have been returned.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// DB_E_BADACCESSORHANDLE pParams was not ignored, and hAccessor in the DBPARAMS structure pointed to by pParams was invalid. Any
		/// streams used to pass input parameters are not released.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// DB_E_BADACCESSORTYPE hAccessor in the DBPARAMS structure pointed to by pParams was not the handle of a parameter accessor. Any
		/// streams used to pass input parameters are not released.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_E_CANCELED The command was canceled by a call to <c>ICommand::Cancel</c> on another thread. No records were affected.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// DB_E_CANTCONVERTVALUE A literal value in the command text could not be converted to the type of the associated column for reasons
		/// other than data overflow.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_E_DATAOVERFLOW A literal value in the command text overflowed the type specified by the associated column.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// DB_E_ERRORSINCOMMAND The command text contained one or more errors. Providers should use OLE DB error objects to return details
		/// about the errors.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// DB_E_ERRORSOCCURRED The method failed due to one or more nonvalid input parameter values. To determine which input parameter
		/// values were not valid, the consumer checks the status values. (For a list of status values that can be returned by this method,
		/// see "Status Values Used When Setting Data" in Status.) If any streams were used to pass input parameters, only those with the
		/// status value equal to DBSTATUS_S_OK on input are released; otherwise, no attempt is made to release the stream. If the consumer
		/// provides storage objects for additional bound parameters that are not used by the current command, it is a consumer programming
		/// error and the provider does not attempt to release these parameters.
		/// </para>
		/// <para>
		/// The command was not executed, and no rowset was returned because one or more properties ? for which the dwOptions element of the
		/// DBPROP structure was DBPROPOPTIONS_REQUIRED ? were not set.
		/// </para>
		/// <para>Multiple parameter sets were passed with a command that returns a rowset. (Some providers might not return this error.)</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_E_INTEGRITYVIOLATION A literal value in the command text violated the integrity constraints for the column.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// DB_E_NOAGGREGATION pUnkOuter was not a null pointer, and the provider is an OLE DB 1.0 or 1.1 provider that does not support
		/// aggregation of the rowset object being created. Any streams used to pass input parameters are not released.
		/// </para>
		/// <para>
		/// pUnkOuter was not a null pointer, and riid was not <c>IID_IUnknown</c>. Any streams used to pass input parameters are not released.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// DB_E_NOCOMMAND No command text was currently set on the command object. Any streams used to pass input parameters are not released.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_E_NOTABLE The specific table or view does not exist in the data store.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// DB_E_NOTFOUND The provider supports row objects, a row was requested via riid or DBPROP_IRow, and no rows satisfied the selection
		/// criteria of the command.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_E_PARAMNOTOPTIONAL A value was not supplied for a required parameter.</para>
		/// <para>The command text used parameters and pParams was a null pointer.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// DB_E_PARAMUNAVAILABLE Provider cannot derive parameter information, and <c>ICommandWithParameters::SetParameterInfo</c> has not
		/// been called.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// DB_SEC_E_PERMISSIONDENIED The consumer did not have sufficient permission to execute the command. For example, a rowset-returning
		/// command specified a column for which the consumer does not have read permission, or an update command specified a column for
		/// which the consumer does not have write permission.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// DB_E_OBJECTOPEN The provider would have to open a new connection to support the operation, and DBPROP_MULTIPLECONNECTIONS is set
		/// to VARIANT_FALSE. Any streams used to pass input parameters are not released.
		/// </para>
		/// <para>
		/// If a session is enlisted in a global transaction and a command requires the creation of an additional connection, the provider
		/// should return DB_E_OBJECTOPEN. Providers written prior to OLE DB 2.6 may return E_FAIL.
		/// </para>
		/// </description>
		/// </item>
		/// </list>
		/// </returns>
		// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/ms718095(v=vs.85) HRESULT Execute ( IUnknown *pUnkOuter,
		// REFIID riid, DBPARAMS *pParams, DBROWCOUNT *pcRowsAffected, IUnknown **ppRowset);
		[PreserveSig]
		new HRESULT Execute([In, Optional, MarshalAs(UnmanagedType.IUnknown)] object? pUnkOuter, in Guid riid, [In, Out, Optional] DBPARAMS? pParams,
			out DBROWCOUNT pcRowsAffected, [MarshalAs(UnmanagedType.IUnknown)] out object? ppRowset);

		/// <summary>Returns an interface pointer to the session that created the command.</summary>
		/// <param name="riid">[in] The IID of the interface on which to return a pointer.</param>
		/// <param name="ppSession">
		/// [out] A pointer to memory in which to return the interface pointer. If the provider does not have an object that created the
		/// command, it sets *ppSession to a null pointer. If <c>ICommand::GetDBSession</c> fails, it must attempt to set *ppSession to a
		/// null pointer.
		/// </param>
		/// <returns>
		/// <list type="bullet">
		/// <item>
		/// <description>
		/// <para>S_OK The method succeeded.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>S_FALSE The provider did not have an object that created the command. Therefore, it set *ppSession to a null pointer.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>E_FAIL A provider-specific error occurred.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>E_INVALIDARG ppSession was a null pointer.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>E_NOINTERFACE The session did not support the interface specified in riid.</para>
		/// </description>
		/// </item>
		/// </list>
		/// </returns>
		// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/ms719622(v=vs.85) HRESULT GetDBSession ( REFIID riid, IUnknown **ppSession);
		[PreserveSig]
		new HRESULT GetDBSession(in Guid riid, [MarshalAs(UnmanagedType.IUnknown)] out object? ppSession);

		/// <summary>Returns the text command set by the last call to <c>ICommandText::SetCommandText</c>.</summary>
		/// <param name="pguidDialect">
		/// <para>
		/// [in/out] A pointer to memory containing a GUID that specifies the syntax and general rules for parsing the command text ? that
		/// is, the dialect that will be used by the provider to interpret the statement. This is usually the dialect specified in ICommandText::SetCommandText.
		/// </para>
		/// <para>
		/// However, if DBGUID_DEFAULT is specified in <c>SetCommandText</c>, the provider returns the particular dialect that it will use to
		/// interpret the statement. If the provider must choose between multiple dialects at execution time for a command that has been set
		/// with DBGUID_DEFAULT or if the provider is returning some provider-specific syntax that may be different from the command set in
		/// <c>ICommandText::SetCommandText</c>, it returns DBGUID_DEFAULT. Providers can define GUIDs for their own dialects.
		/// </para>
		/// <para>If pguidDialect is a null pointer on input, the provider does not return the dialect.</para>
		/// <para>If <c>ICommandText::GetCommandText</c> returns an error, *pguidDialect is set to DB_NULLGUID.</para>
		/// <para>For more information about dialects, see Using Commands.</para>
		/// </param>
		/// <param name="ppwszCommand">
		/// [out] A pointer to memory in which to return the command text. The command object allocates memory for the command text and
		/// returns the address to this memory. The consumer releases this memory with <c>IMalloc::Free</c> when it no longer needs the text.
		/// If <c>ICommandText::GetCommandText</c> returns an error, *ppwszCommand is set to a null pointer.
		/// </param>
		/// <returns>
		/// <list type="bullet">
		/// <item>
		/// <description>
		/// <para>S_OK The method succeeded.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// DB_S_DIALECTIGNORED The method succeeded, but the input value of pguidDialect was ignored. The text is returned in the dialect
		/// specified in <c>ICommandText::SetCommandText</c> or in the dialect that makes the most sense to the provider. The value returned
		/// in *pguidDialect represents that dialect.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>E_FAIL A provider-specific error occurred.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>E_INVALIDARG ppwszCommand was a null pointer.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>E_OUTOFMEMORY The provider was unable to allocate sufficient memory in which to return the command text.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_E_CANTTRANSLATE The last command was set using <c>ICommandStream::SetCommandStream</c>, not <c>ICommandText::SetCommandText</c>.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_E_NOCOMMAND No command text was currently set on the command object.</para>
		/// </description>
		/// </item>
		/// </list>
		/// </returns>
		// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/ms709825(v=vs.85) HRESULT GetCommandText ( GUID *pguidDialect,
		// LPOLESTR *ppwszCommand);
		[PreserveSig]
		HRESULT GetCommandText([In, Out, Optional] ref Guid pguidDialect, out string ppwszCommand);

		/// <summary>Sets the command text, replacing the existing command text.</summary>
		/// <param name="rguidDialect">
		/// [in] A GUID that specifies the syntax and general rules for the provider to use in parsing the command text. For a complete
		/// description of dialects, see GetCommandText.
		/// </param>
		/// <param name="pwszCommand">
		/// <para>[in] A pointer to the text of the command.</para>
		/// <para>
		/// If *pwszCommand is an empty string ("") or pwszCommand is a null pointer, the current command text (and command stream object, if
		/// it exists) is cleared and the command is put in an initial state. Any properties that have been set on the command are
		/// unaffected; that is, they retain their current values. Methods that require a command, such as <c>ICommand::Execute</c>,
		/// <c>ICommandPrepare::Prepare</c>, or <c>IColumnsInfo::GetColumnInfo</c>, will return DB_E_NOCOMMAND until a new command text is set.
		/// </para>
		/// </param>
		/// <returns>
		/// <list type="bullet">
		/// <item>
		/// <description>
		/// <para>S_OK The method succeeded.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>E_FAIL A provider-specific error occurred.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_E_DIALECTNOTSUPPORTED The provider did not support the dialect specified in rguidDialect.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_E_OBJECTOPEN A rowset was open on the command.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// DB_SEC_E_SAFEMODE_DENIED The provider was called within a safe mode or context, and the command text specified a FROM SCOPE=
		/// clause with an unsafe URL.
		/// </para>
		/// </description>
		/// </item>
		/// </list>
		/// </returns>
		// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/ms709757(v=vs.85) HRESULT SetCommandText ( REFGUID
		// rguidDialect, LPCOLESTR pwszCommand);
		[PreserveSig]
		HRESULT SetCommandText(in Guid rguidDialect, [In, Optional, MarshalAs(UnmanagedType.LPWStr)] string? pwszCommand);
	}

	/// <summary>
	/// <para>
	/// <c>IDBAsynchNotify</c> is the callback interface that a consumer must support to get notified of the progress of asynchronous
	/// operations such as initializing a data source object or opening or populating a rowset.
	/// </para>
	/// <para>
	/// The notifications use the standard OLE connection point scheme for events. The object being created, initialized, or populated
	/// supports <c>IConnectionPointContainer</c>, and the consumer calls <c>FindConnectionPoint</c><c>for IID_IDBAsynchNotify</c> to obtain
	/// the correct <c>IConnectionPoint</c> interface. The consumer then advises that connection point to connect and supplies a pointer to
	/// the consumer's <c>IDBAsynchNotify</c> interface.
	/// </para>
	/// </summary>
	// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/ms718270(v=vs.85)
	[PInvokeData("oledb.h")]
	[ComImport, Guid("0c733a96-2a1c-11ce-ade5-00aa0044773d"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IDBAsynchNotify
	{
		/// <summary>Called when low resources are detected by the provider.</summary>
		/// <returns>
		/// <list type="bullet">
		/// <item>
		/// <description>
		/// <para>S_OK The method succeeded.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>E_FAIL A consumer-specific error occurred.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// E_NOTIMPL The consumer is not interested in receiving this notification. The provider can optimize by making no further calls to
		/// this method for this listener. Notifications for other methods are unaffected.
		/// </para>
		/// </description>
		/// </item>
		/// </list>
		/// </returns>
		// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/ms711235(v=vs.85) HRESULT OnLowResource( DB_DWRESERVE dwReserved);
		[PreserveSig]
		HRESULT OnLowResource(DB_DWRESERVE dwReserved = 0);

		/// <summary>Returns the progress of an asynchronous method call. This method makes no logical change to the state of the object.</summary>
		/// <param name="hChapter">
		/// [in] The chapter handle. If the object calling this method is not a rowset or the operation does not apply to chapters, the
		/// caller must set hChapter to DB_NULL_HCHAPTER.
		/// </param>
		/// <param name="ulOperation">
		/// <para>[in] The operation about which status is being returned. Must be set to the following value:</para>
		/// <para>
		/// DBASYNCHOP_OPEN ? The information applies to the asynchronous opening or population of a rowset or the asynchronous
		/// initialization of a data source object.
		/// </para>
		/// </param>
		/// <param name="ulProgress">
		/// [in] Current progress of the asynchronous execution relative to the expected maximum indicated in the ulProgressMax parameter.
		/// </param>
		/// <param name="ulProgressMax">
		/// [in] The expected maximum value of the ulProgress parameter for the duration of calls to <c>IDBAsynchNotify::OnProgress</c> for
		/// this phase. This value may change across calls to this method.
		/// </param>
		/// <param name="ulAsynchPhase">
		/// <para>[in] Additional information regarding the progress of the asynchronous operation. Valid values include:</para>
		/// <para>
		/// DBASYNCHPHASE_CANCELED ? A consumer has requested that the operation be canceled by calling <c>IDBAsynchStatus::Abort</c>. The
		/// listener can attempt to deny the cancellation by returning S_FALSE from the notification. If no listeners deny the cancellation,
		/// the provider will call <c>IDBAsynchNotify::OnStop</c> for all registered listeners with an hrStatus of DB_E_CANCELED.
		/// </para>
		/// <para>
		/// DBASYNCHPHASE_INITIALIZATION ? The object is in an initialization phase. The arguments ulProgress and ulProgressMax indicate an
		/// estimated ratio of completion. The object is not yet fully materialized. Attempting to call any other interfaces may fail, and
		/// the full set of interfaces may not be available on the object.
		/// </para>
		/// <para>
		/// If the asynchronous operation is a result of calling <c>ICommand::Execute</c> for a command that updates, deletes, or inserts
		/// rows, and if cParamSets is greater than 1, ulProgress and ulProgressMax may indicate the progress for a single set of parameters
		/// or for the full array of parameter sets.
		/// </para>
		/// <para>
		/// DBASYNCHPHASE_POPULATION ? The object is in a population phase. Although the rowset is fully initialized and the full range of
		/// interfaces is available on the object, there may be additional rows not yet populated into the rowset.
		/// </para>
		/// <para>
		/// While ulProgress and ulProgressMax can be based on the number of rows populated, they are generally based on the time or effort
		/// required to populate the rowset. A caller would therefore be better off using this information as a rough guide to how long the
		/// process might take, not the eventual row count.
		/// </para>
		/// <para>
		/// This phase is returned only during population of a rowset. It is never returned in the initialization of a data source object or
		/// by the execution of a command that updates, deletes, or inserts rows.
		/// </para>
		/// <para>
		/// DBASYNCHPHASE_COMPLETE ? All asynchronous processing of the object has completed. If the asynchronous operation was a result of
		/// calling <c>ICommand::Execute</c> for a command that updates, deletes, or inserts rows, ulProgress and ulProgressMax are equal to
		/// the total number of rows affected by the command. If cParamSets is greater than 1, this is the total number of rows affected by
		/// all of the sets of parameters specified in the execution.
		/// </para>
		/// </param>
		/// <param name="pwszStatusText">
		/// <para>
		/// [in] Textual information indicating additional information about the asynchronous operation, or NULL if no status text is available.
		/// </para>
		/// <para>
		/// The provider owns the memory for pwszStatusText. The consumer can copy the text to its own memory but must not attempt to free
		/// pwszStatusText nor to reference it once it has returned from <c>IDBAsynchNotify::OnProgress</c>.
		/// </para>
		/// </param>
		/// <returns>
		/// <list type="bullet">
		/// <item>
		/// <description>
		/// <para>S_OK The method succeeded.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// S_FALSE The ulAsynchPhase was DBASYNCHPHASE_CANCELED, and the cancellation of the asynchronous operation was vetoed by the consumer.
		/// </para>
		/// <para>
		/// The listener wants to cancel the asynchronous operation. The provider calls each listener's <c>IDBAsynchNotify::OnProgress</c>
		/// with a ulAsynchPhase of DBASYNCHPHASE_CANCELED. If none of the listeners deny the cancellation by returning S_FALSE to that
		/// notification, the asynchronous operation is canceled and <c>IDBAsynchNotify::OnStop</c> is called for each listener with an
		/// hrStatus of DB_E_CANCELED.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// DB_S_UNWANTEDPHASE The consumer is not interested in receiving this phase. The provider can optimize by making no further calls
		/// with this phase.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// DB_S_UNWANTEDOPERATION The consumer is not interested in receiving notifications for this operation. The provider can optimize by
		/// making no further calls to this method with this operation for this listener. Notifications for other operations are unaffected.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// E_NOTIMPL The consumer is not interested in receiving this notification. The provider can optimize by making no further calls to
		/// this method for this listener. Notifications for other methods are unaffected.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>E_FAIL A consumer-specific error occurred.</para>
		/// </description>
		/// </item>
		/// </list>
		/// </returns>
		// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/ms713718(v=vs.85) HRESULT OnProgress ( HCHAPTER hChapter,
		// DBASYNCHOP ulOperation, DBCOUNTITEM ulProgress, DBCOUNTITEM ulProgressMax, DBASYNCHPHASE ulAsynchPhase, LPOLESTR pwszStatusText);
		[PreserveSig]
		HRESULT OnProgress(HCHAPTER hChapter, DBASYNCHOP ulOperation, DBCOUNTITEM ulProgress, DBCOUNTITEM ulProgressMax, DBASYNCHPHASE ulAsynchPhase,
			[In, Optional, MarshalAs(UnmanagedType.LPWStr)] string? pwszStatusText);

		/// <summary>Called by the provider to indicate that asynchronous processing has stopped.</summary>
		/// <param name="hChapter">
		/// [in] The chapter for which the operation has stopped. If the object calling this method is not a rowset or the operation does not
		/// apply to chapters, the caller must set hChapter to DB_NULL_HCHAPTER.
		/// </param>
		/// <param name="ulOperation">
		/// <para>[in] The operation that has stopped.</para>
		/// <para>
		/// DBASYNCHOP_OPEN ? The completion information applies to the asynchronous opening or population of a rowset or to the asynchronous
		/// initialization of a data source object.
		/// </para>
		/// </param>
		/// <param name="hrStatus">
		/// <para>
		/// [in] Status code indicating the completion result of the asynchronous operation. This may be one of the following status codes or
		/// some result specific to the asynchronous operation being executed:
		/// </para>
		/// <para>S_OK ? The asynchronous operation completed successfully.</para>
		/// <para>DB_E_CANCELED ? The asynchronous operation was canceled.</para>
		/// <para>E_OUTOFMEMORY ? The provider ran out of memory attempting to execute the asynchronous operation.</para>
		/// <para>E_FAIL ? The asynchronous operation failed for a provider-specific reason.</para>
		/// </param>
		/// <param name="pwszStatusText">
		/// <para>
		/// [in] Additional information about the error or about the resource associated with the error. If no additional information is
		/// available, this string is empty.
		/// </para>
		/// <para>
		/// The provider owns the memory for pwszStatusText. The consumer can copy the text to its own memory but must not attempt to free
		/// pwszStatusText nor to reference it after it has returned from <c>IDBAsynchNotify::OnStop</c>.
		/// </para>
		/// </param>
		/// <returns>
		/// <list type="bullet">
		/// <item>
		/// <description>
		/// <para>S_OK The method succeeded.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// DB_S_UNWANTEDOPERATION The consumer is not interested in receiving notifications for this operation. The provider can optimize by
		/// making no further calls to this method with this operation for this listener. Notifications for other operations are unaffected.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// E_NOTIMPL The consumer is not interested in receiving this notification. The provider can optimize by making no further calls to
		/// this method for this listener. Notifications for other methods are unaffected.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>E_FAIL A consumer-specific error occurred.</para>
		/// </description>
		/// </item>
		/// </list>
		/// </returns>
		// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/ms709824(v=vs.85) HRESULT OnStop ( HCHAPTER hChapter,
		// DBASYNCHOP ulOperation, HRESULT hrStatus, LPOLESTR pwszStatusText);
		[PreserveSig]
		HRESULT OnStop(HCHAPTER hChapter, DBASYNCHOP ulOperation, HRESULT hrStatus, [In, Optional, MarshalAs(UnmanagedType.LPWStr)] string? pwszStatusText);
	}

	/// <summary>
	/// Consumers requiring asynchronous data source object initialization or asynchronous rowset generation or population can poll for
	/// status or cancel the asynchronous operation by requesting <c>IDBAsynchStatus</c> on the object being initialized, generated, or populated.
	/// </summary>
	// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/ms709832(v=vs.85)
	[PInvokeData("oledb.h")]
	[ComImport, Guid("0c733a95-2a1c-11ce-ade5-00aa0044773d"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IDBAsynchStatus
	{
		/// <summary>Cancels an asynchronously executing operation.</summary>
		/// <param name="hChapter">
		/// [in] The handle of the chapter for which to abort the operation. If the object being called is not a rowset object or the
		/// operation does not apply to a chapter, the caller must set hChapter to DB_NULL_HCHAPTER.
		/// </param>
		/// <param name="ulOperation">
		/// <para>[in] The operation to abort. This should be the following value:</para>
		/// <para>
		/// DBASYNCHOP_OPEN ? The request to cancel applies to the asynchronous opening or population of a rowset or to the asynchronous
		/// initialization of a data source object.
		/// </para>
		/// </param>
		/// <returns>
		/// <list type="bullet">
		/// <item>
		/// <description>
		/// <para>
		/// S_OK The request to cancel the asynchronous operation was processed. This does not guarantee that the operation itself was
		/// canceled. To determine whether the operation was canceled, the consumer should call <c>IDBAsynchStatus::GetStatus</c> and check
		/// for DB_E_CANCELED; however, it might not be returned in the very next call.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_E_CANTCANCEL The asynchronous operation cannot be canceled.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// DB_E_CANCELED The request to abort the asynchronous operation was canceled during notifications. The operation is still being
		/// executed asynchronously.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>E_FAIL A provider-specific error occurred.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// E_UNEXPECTED <c>IDBAsynchStatus::Abort</c> was called on a data source object on which <c>IDBInitialize::Initialize</c> has not
		/// been called.
		/// </para>
		/// <para>
		/// <c>IDBAsynchStatus::Abort</c> was called on a data source object on which <c>IDBInitialize::Initialize</c> was called but
		/// subsequently canceled prior to initialization. The data source object is still uninitialized.
		/// </para>
		/// <para>
		/// <c>IDBAsynchStatus::Abort</c> was called on a rowset on which <c>ITransaction::Commit</c> or <c>ITransaction::Abort</c> was
		/// previously called, and the rowset did not survive the commit or abort and is in a zombie state.
		/// </para>
		/// <para>
		/// <c>IDBAsynchStatus::Abort</c> was called on a rowset that was asynchronously canceled in its initialization phase. The rowset is
		/// in a zombie state.
		/// </para>
		/// </description>
		/// </item>
		/// </list>
		/// </returns>
		// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/ms724494(v=vs.85) HRESULT Abort( HCHAPTER hChapter, ULONG ulOperation);
		[PreserveSig]
		HRESULT Abort(HCHAPTER hChapter, DBASYNCHOP ulOperation);

		/// <summary>Returns the status of an asynchronously executing operation.</summary>
		/// <param name="hChapter">
		/// [in] The chapter handle. If the object being polled is not a rowset object or the operation does not apply to a chapter, this
		/// should be set to DB_NULL_HCHAPTER, which is ignored by the provider.
		/// </param>
		/// <param name="ulOperation">
		/// <para>[in] The operation for which the asynchronous status is being requested. This should be the following value:</para>
		/// <para>
		/// DBASYNCHOP_OPEN ? The consumer requests information about the asynchronous opening or population of a rowset or about the
		/// asynchronous initialization of a data source object. If the provider is an OLE DB 2.5-compliant provider that supports direct URL
		/// binding, the consumer requests information about the asynchronous initialization or population of a data source, rowset, row, or
		/// stream object.
		/// </para>
		/// </param>
		/// <param name="pulProgress">
		/// <para>
		/// [out] A pointer to memory in which to return the current progress of the asynchronous operation relative to the expected maximum
		/// indicated in the pulProgressMax parameter. For more information about the meaning of pulProgress, see the description of pulAsynchPhase.
		/// </para>
		/// <para>If pulProgress is a null pointer, no progress is returned.</para>
		/// </param>
		/// <param name="pulProgressMax">
		/// <para>
		/// [out] A pointer to memory in which to return the expected maximum value of the pulProgress parameter. This value may change
		/// across calls to this method. For more information about the meaning of pulProgressMax, see the description of pulAsynchPhase.
		/// </para>
		/// <para>If pulProgressMax is a null pointer, no expected maximum value is returned.</para>
		/// </param>
		/// <param name="peAsynchPhase">
		/// <para>
		/// [out] A pointer to memory in which to return additional information regarding the progress of the asynchronous operation. Valid
		/// values include:
		/// </para>
		/// <para>
		/// DBASYNCHPHASE_INITIALIZATION ? The object is in an initialization phase. The arguments pulProgress and pulProgressMax indicate an
		/// estimated ratio of completion. The object is not yet fully materialized. Attempting to call any other interfaces may fail, and
		/// the full set of interfaces may not be available on the object. If the asynchronous operation was a result of calling
		/// <c>ICommand::Execute</c> for a command that updates, deletes, or inserts rows and if cParamSets is greater than 1, pulProgress
		/// and pulProgressMax may indicate the progress for a single set of parameters or for the full array of parameter sets.
		/// </para>
		/// <para>
		/// DBASYNCHPHASE_POPULATION ? The object is in a population phase. Although the rowset is fully initialized and the full range of
		/// interfaces is available on the object, there may be additional rows not yet populated into the rowset. While pulProgress and
		/// pulProgressMax can be based on the number of rows populated, they are generally based on the time or effort required to populate
		/// the rowset. A caller should therefore use this information as a rough estimate of how long the process might take, not the
		/// eventual row count. This phase is returned only during population of a rowset; it is never returned in the initialization of a
		/// data source object or by the execution of a command that updates, deletes, or inserts rows.
		/// </para>
		/// <para>
		/// DBASYNCHPHASE_COMPLETE ? All asynchronous processing of the object has completed. <c>IDBAsynchStatus::GetStatus</c> returns an
		/// HRESULT indicating the outcome of the operation. Typically, this will be the HRESULT that would have been returned had the
		/// operation been called synchronously. If the asynchronous operation was a result of calling <c>ICommand::Execute</c> for a command
		/// that updates, deletes, or inserts rows, pulProgress and pulProgressMax are equal to the total number of rows affected by the
		/// command. If cParamSets is greater than 1, this is the total number of rows affected by all of the sets of parameters specified in
		/// the execution. If pulAsynchPhase is a null pointer, no status code is returned.
		/// </para>
		/// <para>
		/// DBASYNCHPHASE_CANCELED ? Asynchronous processing of the object was aborted. <c>IDBAsynchStatus::GetStatus</c> returns
		/// DB_E_CANCELED. If the asynchronous operation was a result of calling <c>ICommand::Execute</c> for a command that updates,
		/// deletes, or inserts rows, pulProgress is equal to the total number of rows, for all parameter sets, affected by the command prior
		/// to cancellation.
		/// </para>
		/// </param>
		/// <param name="ppwszStatusText">
		/// <para>
		/// [in/out] A pointer to memory containing additional information about the operation. A provider may use this value to distinguish
		/// between different elements of an operation ? for example, different resources being accessed. This string is localized according
		/// to the DBPROP_INIT_LCID property on the data source object.
		/// </para>
		/// <para>
		/// If *ppwszStatusText is non-null on input, the provider returns status associated with the particular element identified by
		/// *ppwszStatusText. If *ppwszStatusText does not indicate an element of ulOperation, the provider returns S_OK with pulProgress and
		/// pulProgressMax set to the same value. If the provider does not distinguish between elements based on a textual identifier, it
		/// sets *ppwszStatusText to NULL and returns information about the operation as a whole; otherwise, if *ppwszStatusText is non-null
		/// on input, the provider leaves *ppwszStatusText untouched.
		/// </para>
		/// <para>
		/// If *ppwszStatusText is null on input, the provider sets *ppwszStatusText to a value indicating more information about the
		/// operation, or NULL if no such information is available or if <c>IDBAsynchStatus::GetStatus</c> returns an error. When
		/// *ppwszStatusText is null on input, the provider allocates memory for the status string and returns the address to this memory.
		/// The consumer releases this memory with <c>IMalloc::Free</c> when it no longer needs the string.
		/// </para>
		/// <para>
		/// If ppwszStatusText is NULL on input, no status string is returned and the provider returns information about any element of the
		/// operation or about the operation in general.
		/// </para>
		/// </param>
		/// <returns>
		/// <list type="bullet">
		/// <item>
		/// <description>
		/// <para>S_OK The method returned successfully.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// DB_E_CANCELED Asynchronous processing was canceled during rowset population. Population stops, but the rowset remains valid for
		/// the rows already populated.
		/// </para>
		/// <para>
		/// Asynchronous processing was canceled during data source object initialization. The data source object is in an uninitialized state.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// E_UNEXPECTED <c>IDBAsynchStatus::GetStatus</c> was called on a data source object, and <c>IDBInitialize::Initialize</c> has not
		/// been called on the data source object.
		/// </para>
		/// <para>
		/// <c>IDBAsynchStatus::GetStatus</c> was called on a rowset, <c>ITransaction::Commit</c> or <c>ITransaction::Abort</c> was called,
		/// and the object is in a zombie state.
		/// </para>
		/// <para>
		/// <c>IDBAsynchStatus::GetStatus</c> was called on a rowset that was asynchronously canceled in its initialization phase. The rowset
		/// is in a zombie state.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>E_FAIL A provider-specific error occurred.</para>
		/// </description>
		/// </item>
		/// </list>
		/// </returns>
		// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/ms711542(v=vs.85) HRESULT GetStatus ( HCHAPTER hChapter, ULONG
		// ulOperation, DBCOUNTITEM *pulProgress, DBCOUNTITEM *pulProgressMax, DBASYNCHPHASE* peAsynchPhase, LPOLESTR *ppwszStatusText);
		HRESULT GetStatus(HCHAPTER hChapter, DBASYNCHOP ulOperation, out DBCOUNTITEM pulProgress, out DBCOUNTITEM pulProgressMax,
			out DBASYNCHPHASE peAsynchPhase, [In, Out, Optional, MarshalAs(UnmanagedType.LPWStr)] ref StringBuilder? ppwszStatusText);
	}

	/// <summary>Consumers call <c>IDBCreateCommand::CreateCommand</c> on a session to obtain a new command.</summary>
	// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/ms711625(v=vs.85)
	[PInvokeData("oledb.h")]
	[ComImport, Guid("0c733a1d-2a1c-11ce-ade5-00aa0044773d"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IDBCreateCommand
	{
		/// <summary>Creates a new command.</summary>
		/// <param name="pUnkOuter">
		/// [in] A pointer to the controlling <c>IUnknown</c> interface if the new command is being created as part of an aggregate. It is a
		/// null pointer if the command is not part of an aggregate.
		/// </param>
		/// <param name="riid">[in] The IID of the interface requested on the command.</param>
		/// <param name="ppCommand">[out] A pointer to memory in which to return the interface pointer on the newly created command.</param>
		/// <returns>
		/// <list type="bullet">
		/// <item>
		/// <description>
		/// <para>S_OK The method succeeded.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>E_FAIL A provider-specific error occurred.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>E_INVALIDARG ppCommand was a null pointer.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>E_NOINTERFACE The command did not support the interface specified in riid.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>E_OUTOFMEMORY The provider did not have enough memory to create the command.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>E_UNEXPECTED <c>ITransaction::Commit</c> or <c>ITransaction::Abort</c> was called, and the object is in a zombie state.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// DB_E_NOAGGREGATION pUnkOuter was not a null pointer, and the provider is an OLE DB 1.0 or 1.1 provider that does not support
		/// aggregation of the command object being created.
		/// </para>
		/// <para>pUnkOuter was not a null pointer, and riid was not IID_IUnknown.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// DB_E_OBJECTOPEN The provider would have to open a new connection to support the operation, and DBPROP_MULTIPLECONNECTIONS is set
		/// to VARIANT_FALSE.
		/// </para>
		/// </description>
		/// </item>
		/// </list>
		/// </returns>
		// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/ms709772(v=vs.85) HRESULT CreateCommand( IUnknown *pUnkOuter,
		// REFIID riid, IUnknown **ppCommand);
		[PreserveSig]
		HRESULT CreateCommand([In, Optional, MarshalAs(UnmanagedType.IUnknown)] object? pUnkOuter, in Guid riid, [MarshalAs(UnmanagedType.IUnknown)] out object? ppCommand);
	}

	/// <summary>Consumers call <c>IDBCreateSession::CreateSession</c> on a data source object to obtain a new session.</summary>
	// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/ms724076(v=vs.85)
	[PInvokeData("oledb.h")]
	[ComImport, Guid("0c733a5d-2a1c-11ce-ade5-00aa0044773d"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IDBCreateSession
	{
		/// <summary>Creates a new session from the data source object and returns the requested interface on the newly created session.</summary>
		/// <param name="pUnkOuter">
		/// [in] A pointer to the controlling <c>IUnknown</c> interface if the new session is being created as part of an aggregate. It is a
		/// null pointer if the session is not part of an aggregate.
		/// </param>
		/// <param name="riid">[in] The IID of the interface.</param>
		/// <param name="ppDBSession">[out] A pointer to memory in which to return the interface pointer.</param>
		/// <returns>
		/// <list type="bullet">
		/// <item>
		/// <description>
		/// <para>S_OK The method succeeded.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>E_FAIL A provider-specific error occurred.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>E_INVALIDARG ppDBSession was a null pointer.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>E_NOINTERFACE The session did not support the interface specified in riid.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>E_OUTOFMEMORY The provider did not have enough memory to create the session.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>E_UNEXPECTED The data source object was in an uninitialized state.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// DB_E_NOAGGREGATION pUnkOuter was not a null pointer, and the provider is an OLE DB 1.0 or 1.1 provider that does not support
		/// aggregation of the session object being created.
		/// </para>
		/// <para>pUnkOuter was not a null pointer, and riid was not IID_IUnknown.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// DB_E_OBJECTCREATIONLIMITREACHED The maximum number of sessions supported by the provider has already been created. The consumer
		/// must release one or more currently held sessions before obtaining a new session object. This error is returned only by providers
		/// that have a fixed maximum number of sessions as returned by DBPROP_ACTIVESESSIONS. It is not returned due to other resource
		/// constraints, such as available memory (for which the provider returns E_OUTOFMEMORY).
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// DB_E_OBJECTOPEN The provider would have to open a new connection to support the operation, and DBPROP_MULTIPLECONNECTIONS is set
		/// to VARIANT_FALSE.
		/// </para>
		/// </description>
		/// </item>
		/// </list>
		/// </returns>
		// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/ms714942(v=vs.85) HRESULT CreateSession ( IUnknown *pUnkOuter,
		// REFIID riid, IUnknown **ppDBSession);
		[PreserveSig]
		HRESULT CreateSession([In, Optional, MarshalAs(UnmanagedType.IUnknown)] object? pUnkOuter, in Guid riid, [MarshalAs(UnmanagedType.IUnknown)] out object? ppDBSession);
	}

	/// <summary>
	/// IDBInitialize is used to initialize and uninitialize data source objects and enumerators. It is a mandatory interface on data source
	/// objects and an optional interface on enumerators.
	/// </summary>
	[PInvokeData("oledb.h")]
	[ComImport, Guid("0c733a8b-2a1c-11ce-ade5-00aa0044773d"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IDBInitialize
	{
		/// <summary>Initializes a data source object or enumerator.</summary>
		/// <returns>
		/// <list type="bullet">
		/// <item>
		/// <description>
		/// <para>S_OK The method succeeded.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// DB_S_ASYNCHRONOUS The method has initiated asynchronous initialization of the data source object. The consumer can call
		/// <c>IDBAsynchStatus::GetStatus</c> to poll for status or can register for notifications of asynchronous processing. Until
		/// asynchronous processing completes, the data source object remains in an uninitialized state.
		/// </para>
		/// <para>DB_S_ASYNCHRONOUS should be returned before DB_S_ERRORSOCCURRED.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// DB_S_ERRORSOCCURRED The data source object or enumerator was initialized, but one or more properties ? for which the dwOptions
		/// element of the DBPROP structure was DBPROPOPTIONS_OPTIONAL ? were not set. To return properties in error, the provider uses
		/// DBPROPSET_PROPERTIESINERROR. The method can fail to set properties for a number of reasons, including the following:
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>E_FAIL A provider-specific error occurred.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>E_OUTOFMEMORY The provider was unable to allocate sufficient memory to initialize the data source object or enumerator.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// E_UNEXPECTED The data source object is in the process of being initialized asynchronously. To cancel asynchronous execution, call <c>IDBAsynchStatus::Abort</c>.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// DB_E_ALREADYINITIALIZED <c>IDBInitialize::Initialize</c> had already been called for the data source object or enumerator, and an
		/// intervening call to <c>IDBInitialize::Uninitialize</c> had not been made.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_E_CANCELED The provider prompted for additional information and the user selected <c>Cancel</c>.</para>
		/// <para>The value passed for DBPROP_INIT_HWND was not a valid <c>HWND</c>.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// DB_E_ERRORSOCCURRED The data source object was not initialized due to conflicting properties. DB_E_ERRORSOCCURED can be returned
		/// if two optional properties conflict or if two required properties conflict. To return properties in error, the provider uses
		/// DBPROPSET_PROPERTIESINERROR. The method can fail to set properties for a number of reasons, including the following:
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// DB_SEC_E_AUTH_FAILED Authentication of the consumer to the data source object or enumerator failed. The data source object or
		/// enumerator remains in the uninitialized state.
		/// </para>
		/// </description>
		/// </item>
		/// </list>
		/// </returns>
		// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/ms718026(v=vs.85) HRESULT Initialize();
		[PreserveSig]
		HRESULT Initialize();

		/// <summary>Returns the data source object or enumerator to an uninitialized state.</summary>
		/// <returns>
		/// <list type="bullet">
		/// <item>
		/// <description>
		/// <para>S_OK The method succeeded.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>E_FAIL A provider-specific error occurred.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// E_UNEXPECTED The data source object is in the process of being initialized asynchronously. To cancel asynchronous initialization,
		/// call <c>IDBAsynchStatus::Abort</c>.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_E_OBJECTOPEN There were open sessions, commands, or rowsets on the data source object.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_S_ASYNCHRONOUS The method will be completed asynchronously.</para>
		/// </description>
		/// </item>
		/// </list>
		/// </returns>
		// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/ms719648(v=vs.85) HRESULT Uninitialize();
		[PreserveSig]
		HRESULT Uninitialize();
	}

	/// <summary>
	/// <para>
	/// <c>IDBProperties</c> is used to set and get the values of properties on the data source object or enumerator and to get information
	/// about all properties supported by the provider. For OLE DB 2.5 providers that support direct URL binding, this interface is
	/// implemented on binder objects via <c>IDBBinderProperties</c>, which is derived from <c>IDBProperties</c>.
	/// </para>
	/// <para>
	/// A data source object or enumerator that has not been initialized or that has been uninitialized is in an uninitialized state. When a
	/// data source object or enumerator is in this state, the consumer can work only with properties of that object that belong to the
	/// Initialization property group.
	/// </para>
	/// <para>
	/// After the data source object or enumerator is initialized, it is in an initialized state (until it is uninitialized). When the data
	/// source object or enumerator is in this state, the consumer can work with properties of that object that belong to the Initialization,
	/// Data Source, and Data Source Information property groups. However, the consumer cannot set the value of properties in the
	/// Initialization property group.
	/// </para>
	/// <para>
	/// Only properties in the Initialization property group are guaranteed to survive uninitialization. That is, if the consumer
	/// uninitializes and reinitializes a data source object or enumerator, it might need to reset the values of properties in groups other
	/// than Initialization.
	/// </para>
	/// <para>
	/// <c>IDBProperties</c> is a mandatory interface for data source objects and an optional interface for enumerators. However, if an
	/// enumerator exposes <c>IDBInitialize</c>, it must expose <c>IDBProperties</c>.
	/// </para>
	/// </summary>
	// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/ms719607(v=vs.85)
	[PInvokeData("oledb.h")]
	[ComImport, Guid("0c733a8a-2a1c-11ce-ade5-00aa0044773d"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IDBProperties
	{
		/// <summary>
		/// Returns the values of properties in the Data Source, Data Source Information, and Initialization property groups that are
		/// currently set on the data source object, or returns the values of properties in the Initialization property group that are
		/// currently set on the enumerator.
		/// </summary>
		/// <param name="cPropertyIDSets">
		/// <para>[in] The number of DBPROPIDSET structures in rgPropertyIDSets.</para>
		/// <para>
		/// If cPropertyIDSets is zero, the provider ignores rgPropertyIDSets. If the data source object or enumerator is in an uninitialized
		/// state, the provider returns the values of all properties in the Initialization property group for which values have been set or
		/// defaults exist. This should include any provider-specific properties belonging to this group. If the data source object or
		/// enumerator is in an initialized state, the provider returns the values of all properties in the Data Source, Data Source
		/// Information, and Initialization property groups (for data source objects) or just in the Initialization property group (for
		/// enumerators), for which values have been set or defaults exist. The provider does not return the values of properties in any of
		/// these property groups for which values have not been set and no defaults exist.
		/// </para>
		/// <para>
		/// If cPropertyIDSets is not zero, the provider returns the values of the requested properties. If a property is not supported or if
		/// the data source object or enumerator is not initialized and the value of a property in a group other than the Initialization
		/// property group is requested, the returned value of dwStatus in the returned DBPROP structure for that property is
		/// DBPROPSTATUS_NOTSUPPORTED and the value of dwOptions is undefined.
		/// </para>
		/// </param>
		/// <param name="rgPropertyIDSets">
		/// <para>
		/// [in] An array of cPropertyIDSets DBPROPIDSET structures. If the data source object or enumerator has not been initialized, the
		/// properties specified in these structures must belong to the Initialization property group. If the data source object or
		/// enumerator has been initialized, the properties specified in these structures must belong to the Data Source, Data Source
		/// Information, or Initialization property group, for data source objects, or to the Initialization property group, for enumerators.
		/// The provider returns the values of the properties specified in these structures. If cPropertyIDSets is zero, this argument is ignored.
		/// </para>
		/// <para>
		/// For information about the properties in the Data Source, Data Source Information, and Initialization property groups that are
		/// defined by OLE DB, see Data Source Property Group, Data Source Information Property Group, and Initialization Properties in
		/// Appendix C. For information about the DBPROPIDSET structure, see DBPROPIDSET Structure.
		/// </para>
		/// </param>
		/// <param name="pcPropertySets">
		/// [out] A pointer to memory in which to return the number of DBPROPSET structures returned in *prgPropertySets. If cPropertyIDSets
		/// is zero, *pcPropertySets is the total number of property sets for which the provider supports at least one property in the Data
		/// Source, Data Source Information, or Initialization property group, for data source objects, or in the Initialization property
		/// group, for enumerators. If cPropertyIDSets is greater than zero, *pcPropertySets is set to cPropertyIDSets. If an error other
		/// than DB_E_ERRORSOCCURRED occurs, *pcPropertySets is set to zero.
		/// </param>
		/// <param name="prgPropertySets">
		/// <para>
		/// [out] A pointer to memory in which to return an array of DBPROPSET structures. If cPropertyIDSets is zero, one structure is
		/// returned for each property set that contains at least one property belonging to the Initialization property group (if the data
		/// source object or enumerator is not initialized), the Data Source, Data Source Information, or Initialization property group (if
		/// the data source object is initialized), or to the Initialization property group (if the enumerator is initialized). If
		/// cPropertyIDSets is not zero, one structure is returned for each property set specified in rgPropertyIDSets.
		/// </para>
		/// <para>
		/// In the case of properties in the Initialization property group and for a previously persisted data source object, those
		/// properties related to sensitive authentication information such as password will be returned in an encrypted form if
		/// DBPROP_AUTH_PERSIST_ENCRYPTED is VARIANT_TRUE.
		/// </para>
		/// <para>
		/// If cPropertyIDSets is not zero, the DBPROPSET structures in *prgPropertySets are returned in the same order as the DBPROPIDSET
		/// structures in rgPropertyIDSets; that is, for corresponding elements of each array, the guidPropertySet elements are the same. If
		/// cPropertyIDs, in an element of rgPropertyIDSets, is not zero, the DBPROP structures in the corresponding element of
		/// *prgPropertySets are returned in the same order as the DBPROPID values in rgPropertyIDs; that is, for corresponding elements of
		/// each array, the property IDs are the same.
		/// </para>
		/// <para>
		/// The provider allocates memory for the structures and returns the address to this memory; the consumer releases this memory with
		/// <c>IMalloc::Free</c> when it no longer needs the structures. Before calling <c>IMalloc::Free</c> for *prgPropertySets, the
		/// consumer should call <c>IMalloc::Free</c> for the rgProperties element within each element of *prgPropertySets. The consumer must
		/// also call <c>VariantClear</c> for the vValue member of each DBPROP structure in order to prevent a memory leak in cases where the
		/// variant contains a reference type (such as a BSTR.) If *pcPropertySets is zero on output or an error other than
		/// DB_E_ERRORSOCCURRED occurs, the provider does not allocate any memory and ensures that *prgPropertySets is a null pointer on output.
		/// </para>
		/// <para>For information about the DBPROPSET and DBPROP structures, see DBPROPSET Structure and DBPROP Structure.</para>
		/// </param>
		/// <returns>
		/// <list type="bullet">
		/// <item>
		/// <description>
		/// <para>
		/// S_OK The method succeeded. For property sets other than DBPROPSET_PROPERTIESINERROR, dwStatus is set to DBPROPSTATUS_OK in all
		/// DBPROP structures returned. If the requested property set is DBPROPSET_PROPERTIESINERROR, dwStatus reflects the individual error
		/// for each DBPROP structure returned from the method.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// DB_S_ERRORSOCCURRED No value was returned for one or more properties. The consumer checks dwStatus in the DBPROP structure to
		/// determine the properties for which values were not returned. IDBProperties::GetProperties can fail to return properties for a
		/// number of reasons, including the following:
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>E_FAIL A provider-specific error occurred.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>E_INVALIDARG cPropertyIDSets was not equal to zero, and rgPropertyIDSets was a null pointer.</para>
		/// <para>pcPropertySets or prgPropertySets was a null pointer.</para>
		/// <para>In an element of rgPropertyIDSets, cPropertyIDs was not zero and rgPropertyIDs was a null pointer.</para>
		/// <para>
		/// In an element of rgPropertyIDSets, guidPropertySet was DBPROPSET_PROPERTIESINERROR and cPropertyIDs was not zero or rgPropertyIDs
		/// was not a null pointer.
		/// </para>
		/// <para>cPropertyIDSets was greater than 1, and in an element of rgPropertyIDSets, guidPropertySet was DBPROPSET_PROPERTIESINERROR.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>E_OUTOFMEMORY The provider was unable to allocate sufficient memory in which to return the DBPROPSET or DBPROP structures.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// DB_E_ERRORSOCCURRED Values were not returned for any properties. The provider allocates memory for *prgPropertySets, and the
		/// consumer checks dwStatus in the DBPROP structures to determine why properties were not returned. The consumer frees this memory
		/// when it no longer needs the information.
		/// </para>
		/// </description>
		/// </item>
		/// </list>
		/// </returns>
		// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/ms714344(v=vs.85) HRESULT GetProperties ( ULONG
		// cPropertyIDSets, const DBPROPIDSET rgPropertyIDSets[], ULONG *pcPropertySets, DBPROPSET **prgPropertySets);
		[PreserveSig]
		HRESULT GetProperties(uint cPropertyIDSets, [In, Optional] SafeDBPROPIDSETListHandle rgPropertyIDSets,
			out uint pcPropertySets, out SafeDBPROPSETListHandle prgPropertySets);

		/// <summary>Returns information about all properties supported by the provider.</summary>
		/// <param name="cPropertyIDSets">
		/// <para>[in] The number of DBPROPIDSET structures in rgPropertyIDSets.</para>
		/// <para>
		/// If cPropertyIDSets is zero, the provider ignores rgPropertyIDSets. When called on the enumerator, the provider returns
		/// information about all properties in the Initialization property group. When called on the data source object, if the data source
		/// object is in an uninitialized state, the provider returns information about all properties in the Initialization property group.
		/// This should include any provider-specific properties belonging to this group. If the data source object is in an initialized
		/// state, the provider returns information about all of the properties in all of the property sets it supports.
		/// </para>
		/// <para>
		/// If cPropertyIDSets is not zero, the provider returns information about the requested properties. If a property is not supported
		/// or if the method is called on an enumerator or an uninitialized data source object and the value of a property in a group other
		/// than the Initialization property group is requested, the returned value of dwStatus in the returned DBPROPINFO structure for that
		/// property is DBPROPFLAGS_NOTSUPPORTED and the values of the pwszDescription, vtType, and vValues elements are undefined. For
		/// information about the DBPROPINFO structure, see DBPROPINFO Structure.
		/// </para>
		/// </param>
		/// <param name="rgPropertyIDSets">
		/// <para>
		/// [in] An array of cPropertyIDSets DBPROPIDSET structures. When called on the enumerator, the properties specified in these
		/// structures must belong to the Initialization property group. When called on the data source object, if the data source object has
		/// not been initialized, the properties must belong to the Initialization property group. If the data source object has been
		/// initialized, the properties can belong to any property group. The provider returns information about the properties specified in
		/// these structures. If cPropertyIDSets is zero, this parameter is ignored. For information about the DBPROPIDSET structure, see
		/// DBPROPIDSET Structure.
		/// </para>
		/// <para>
		/// The following special GUIDs are defined for use with <c>IDBProperties::GetPropertyInfo</c>. All of these GUIDs can be used on
		/// data source objects; only the DBPROPSET_DBINITALL GUID can be used on enumerators. If any of these GUIDs are specified in the
		/// guidPropertySet element of a DBPROPIDSET structure, the cPropertyIDs and rgPropertyIDs elements of that structure are ignored.
		/// However, the consumer should set these to zero and a null pointer, respectively, because the provider might attempt to verify
		/// that they are valid values. Consumers cannot pass special GUIDs and the GUIDs of other property sets in the same call to
		/// <c>IDBProperties::GetPropertyInfo</c>. That is, if one element of rgPropertyIDSets contains a special GUID, all elements of
		/// rgPropertyIDSets must contain special GUIDs. These GUIDs are not returned in the guidPropertySet element of the DBPROPINFOSET
		/// structures returned in prgPropertyInfoSets. Instead, the GUID of the property set to which the property belongs is returned.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <description>Property set GUID</description>
		/// <description>Description</description>
		/// </listheader>
		/// <item>
		/// <description>DBPROPSET_COLUMNALL</description>
		/// <description>Returns all properties in the Column property group, including provider-specific properties.</description>
		/// </item>
		/// <item>
		/// <description>DBPROPSET_CONSTRAINTALL</description>
		/// <description>Returns all properties in the Constraint property group, including provider-specific properties.</description>
		/// </item>
		/// <item>
		/// <description>DBPROPSET_DATASOURCEALL</description>
		/// <description>Returns all properties in the Data Source property group, including provider-specific properties.</description>
		/// </item>
		/// <item>
		/// <description>DBPROPSET_DATASOURCEINFOALL</description>
		/// <description>Returns all properties in the Data Source Information property group, including provider-specific properties.</description>
		/// </item>
		/// <item>
		/// <description>DBPROPSET_DBINITALL</description>
		/// <description>Returns all properties in the Initialization property group, including provider-specific properties.</description>
		/// </item>
		/// <item>
		/// <description>DBPROPSET_INDEXALL</description>
		/// <description>Returns all properties in the Index property group, including provider-specific properties.</description>
		/// </item>
		/// <item>
		/// <description>DBPROPSET_ROWSETALL</description>
		/// <description>Returns all properties in the Rowset property group, including provider-specific properties.</description>
		/// </item>
		/// <item>
		/// <description>DBPROPSET_SESSIONALL</description>
		/// <description>Returns all properties in the Session property group, including provider-specific properties.</description>
		/// </item>
		/// <item>
		/// <description>DBPROPSET_STREAMALL</description>
		/// <description>Returns all properties of the Stream property group, including provider-specific properties.</description>
		/// </item>
		/// <item>
		/// <description>DBPROPSET_TABLEALL</description>
		/// <description>Returns all properties in the Table property group, including provider-specific properties.</description>
		/// </item>
		/// <item>
		/// <description>DBPROPSET_TRUSTEEALL</description>
		/// <description>Returns all properties in the Trustee property group, including provider-specific properties.</description>
		/// </item>
		/// <item>
		/// <description>DBPROPSET_VIEWALL</description>
		/// <description>Returns all properties in the View property group, including provider-specific properties.</description>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="pcPropertyInfoSets">
		/// [out] A pointer to memory in which to return the number of DBPROPINFOSET structures returned in *prgPropertyInfoSets. If
		/// cPropertyIDSets is zero, *pcPropertyInfoSets is the total number of property sets for which the provider supports at least one
		/// property. If *pcPropertyInfoSets is not zero and one of the special GUIDs listed in rgPropertyIDSets was used,
		/// *pcPropertyInfoSets may differ from cPropertyIDSets. If an error other than DB_E_ERRORSOCCURRED occurs, *pcPropertyInfoSets is
		/// set to zero.
		/// </param>
		/// <param name="prgPropertyInfoSets">
		/// <para>
		/// [out] A pointer to memory in which to return an array of DBPROPINFOSET structures. If cPropertyIDSets is zero, one structure is
		/// returned for each property set that contains at least one property supported by the provider. If cPropertyIDSets is not zero, one
		/// structure is returned for each property set specified in rgPropertyIDSets.
		/// </para>
		/// <para>
		/// If cPropertyIDSets is not zero, the DBPROPINFOSET structures in *prgPropertyInfoSets are returned in the same order as the
		/// DBPROPIDSET structures in rgPropertyIDSets; that is, for corresponding elements of each array, the guidPropertySet elements are
		/// the same. If cPropertyIDs, in an element of rgPropertyIDSets, is not zero, the DBPROPINFO structures in the corresponding element
		/// of *prgPropertyInfoSets are returned in the same order as the DBPROPID values in rgPropertyIDs; that is, for corresponding
		/// elements of each array, the property IDs are the same. The only exception to these rules is when one of the special GUIDs listed
		/// in rgPropertyIDSets was used. In this case, the order of the property information returned may differ from the order specified in rgPropertyIDSets.
		/// </para>
		/// <para>
		/// The provider allocates memory for the structures and returns the address to this memory; the consumer releases this memory with
		/// <c>IMalloc::Free</c> when it no longer needs the structures. Before calling <c>IMalloc::Free</c> for *prgPropertyInfoSets, the
		/// consumer should call <c>IMalloc::Free</c> for the rgPropertyInfos element within each element of *prgPropertyInfoSets. The
		/// consumer must also call <c>VariantClear</c> for the vValue member of each DBPROP structure in order to prevent a memory leak in
		/// cases where the variant contains a reference type (such as a BSTR.) If *pcPropertyInfoSets is zero on output or if an error other
		/// than DB_E_ERRORSOCCURRED occurs, *prgPropertyInfoSets must be a null pointer on output.
		/// </para>
		/// <para>For information about the DBPROPINFOSET and DBPROPINFO structures, see DBPROPINFOSET Structure and DBPROPINFO Structure.</para>
		/// </param>
		/// <param name="ppDescBuffer">
		/// [out] A pointer to memory in which to return a pointer to storage for all string values returned in the pwszDescription element
		/// of the DBPROPINFO structure. The provider allocates this memory with <c>IMalloc</c>, and the consumer frees it with
		/// <c>IMalloc::Free</c> when it no longer needs the property descriptions. If ppDescBuffer is a null pointer on input,
		/// <c>IDBProperties::GetPropertyInfo</c> does not return the property descriptions. If *pcPropertyInfoSets is zero on output or if
		/// an error occurs, the provider does not allocate any memory and ensures that *ppDescBuffer is a null pointer on output. Each of
		/// the individual string values stored in this buffer is terminated by a null-termination character. Therefore, the buffer may
		/// contain one or more strings, each with its own null-termination character, and may contain embedded null-termination characters.
		/// </param>
		/// <returns>
		/// <list type="bullet">
		/// <item>
		/// <description>
		/// <para>S_OK The method succeeded. In all DBPROPINFO structures returned by the method, dwFlags is set to a value other than DBPROPFLAGS_NOTSUPPORTED.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// DB_S_ERRORSOCCURRED Information was successfully returned for at least one property. However, one of the following errors occurred:
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>E_FAIL A provider-specific error occurred.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>E_INVALIDARG pcPropertyInfoSets or prgPropertyInfoSets was a null pointer.</para>
		/// <para>cPropertyIDSets was not equal to zero, and rgPropertyIDSets was a null pointer.</para>
		/// <para>In an element of rgPropertyIDSets, cPropertyIDs was not zero and rgPropertyIDs was a null pointer.</para>
		/// <para>
		/// In one element of rgPropertyIDSets, guidPropertySet specified one of the special GUIDs listed in the description of
		/// rgPropertyIDSets. In a different element of rgPropertyIDSets, guidPropertySet specified the GUID of a normal property set.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// E_OUTOFMEMORY The provider was unable to allocate sufficient memory in which to return the DBPROPINFOSET or DBPROPINFO structures
		/// or the property descriptions.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// DB_E_ERRORSOCCURRED Errors occurred while attempting to return information about all properties. No property information was
		/// returned. The provider allocates memory for *prgPropertyInfoSets, and the consumer checks dwFlags in the DBPROPINFO structures to
		/// determine why information about each property was not returned. The consumer frees this memory when it no longer needs the
		/// information. The method can fail to return information about properties for any of the reasons specified in DB_S_ERRORSOCCURRED.
		/// </para>
		/// </description>
		/// </item>
		/// </list>
		/// </returns>
		// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/ms718175(v=vs.85) HRESULT GetPropertyInfo( ULONG
		// cPropertyIDSets, const DBPROPIDSET rgPropertyIDSets[], ULONG *pcPropertyInfoSets, DBPROPINFOSET **prgPropertyInfoSets, OLECHAR **ppDescBuffer);
		[PreserveSig]
		HRESULT GetPropertyInfo(uint cPropertyIDSets, [In, Optional] SafeDBPROPIDSETListHandle rgPropertyIDSets,
			out uint pcPropertyInfoSets, out SafeIMallocHandle prgPropertyInfoSets, out SafeIMallocHandle ppDescBuffer);

		/// <summary>
		/// Sets properties in the Data Source and Initialization property groups, for data source objects, or in the Initialization property
		/// group, for enumerators.
		/// </summary>
		/// <param name="cPropertySets">
		/// [in] The number of DBPROPSET structures in rgPropertySets. If this is zero, the provider ignores rgPropertySets and the method
		/// does not do anything except return S_OK.
		/// </param>
		/// <param name="rgPropertySets">
		/// <para>
		/// [in/out] An array of DBPROPSET structures containing properties and values to be set. If the data source object or enumerator is
		/// uninitialized, the properties specified in these structures must belong to the Initialization property group. If the data source
		/// object is initialized, the properties must belong to the Data Source property group. If the enumerator is initialized, it is an
		/// error to call this method. If the same property is specified more than once in rgPropertySets, the value used is
		/// provider-specific. If cPropertySets is zero, this parameter is ignored.
		/// </para>
		/// <para>
		/// For information about the properties in the Data Source and Initialization property groups that are defined by OLE DB, see Data
		/// Source Property Group and Initialization Property Group in Appendix C. For information about the DBPROPSET and DBPROP structures,
		/// see DBPROPSET Structure and DBPROP Structure.
		/// </para>
		/// </param>
		/// <returns>
		/// <list type="bullet">
		/// <item>
		/// <description>
		/// <para>S_OK The method succeeded. In all DBPROP structures passed to the method, dwStatus is set to DBPROPSTATUS_OK.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// DB_S_ERRORSOCCURRED One or more properties were not set. Properties not in error remain set. The consumer checks dwStatus in the
		/// DBPROP structures to determine which properties were not set. <c>IDBProperties::SetProperties</c> can fail to set properties for
		/// a number of reasons, including the following:
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>E_FAIL A provider-specific error occurred.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>E_INVALIDARG cPropertySets was not equal to zero, and rgPropertySets was a null pointer.</para>
		/// <para>In an element of rgPropertySets, cProperties was not zero and rgProperties was a null pointer.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_E_ALREADYINITIALIZED The method was called on the enumerator, and the enumerator was already initialized.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// DB_E_ERRORSOCCURRED All property values were invalid and no properties were set. The consumer checks dwStatus in the DBPROP
		/// structures to determine why properties were not set. The method can fail to set properties for any of the reasons specified in DB_S_ERRORSOCCURRED.
		/// </para>
		/// </description>
		/// </item>
		/// </list>
		/// </returns>
		// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/ms723049(v=vs.85) HRESULT SetProperties ( ULONG cPropertySets,
		// DBPROPSET rgPropertySets[]);
		[PreserveSig]
		HRESULT SetProperties(uint cPropertySets, [In, Out] SafeDBPROPSETListHandle? rgPropertySets);
	}

	/// <summary>
	/// <para><c>IDBSchemaRowset</c> is an optional interface on sessions. It is used to provide advanced schema information.</para>
	/// <para>
	/// Consumers can get information about a data store without knowing its structure by using the <c>IDBSchemaRowset</c> methods. For
	/// example, the data store might be one of the following types:
	/// </para>
	/// <para>The schemas of each of the preceding data stores can be exposed to the consumer by using the methods of <c>IDBSchemaRowset</c>.</para>
	/// <para>
	/// Schema rowsets in OLE DB are identified by GUIDs and have predefined restriction columns. The restrictions allow the consumer to
	/// limit the set of rows returned by the schema rowset but does not define the format for those restrictions.
	/// </para>
	/// <para>
	/// <c>IDBSchemaRowset::GetSchemas</c> returns to the consumer a list of schema rowsets, identified by their GUIDs, that are accessible
	/// by <c>IDBSchemaRowset::GetRowset</c>. Also returned is a pointer to descriptions of the restriction columns supported for that schema rowset.
	/// </para>
	/// <para>
	/// <c>IDBSchemaRowset::GetRowset</c> allows the consumer to retrieve the specified schema rowset by passing in the GUID identifying the
	/// rowset and the count of restriction columns or an array of restriction values. Each schema rowset will return all of the columns in
	/// the order indicated by that rowset's respective table in Appendix B: Schema Rowsets.
	/// </para>
	/// <para>
	/// Specifying restriction columns allows the consumer to limit the returned rowset to only those rows in the data store whose columns
	/// and values match the values specified in rgRestrictions. These values are applied in the same order as the restriction columns.
	/// </para>
	/// <para>
	/// <para>Note</para>
	/// <para>
	/// The number of restriction columns for each schema rowset is defined as a constant prefixed with CRESTRICTIONS_ in the header files.
	/// Restriction values are treated as literals rather than as search patterns. For example, the restriction value "A_C" matches "A_C" but
	/// not "ABC".
	/// </para>
	/// </para>
	/// </summary>
	// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/ms713686(v=vs.85)
	[PInvokeData("oledb.h")]
	[ComImport, Guid("0c733a7b-2a1c-11ce-ade5-00aa0044773d"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IDBSchemaRowset
	{
		/// <summary>Returns a schema rowset.</summary>
		/// <param name="pUnkOuter">
		/// [in] A pointer to the controlling <c>IUnknown</c> interface if the rowset is being created as part of an aggregate. If the
		/// <c>IDBSchemaRowset</c> interface is not being aggregated, it is a null pointer.
		/// </param>
		/// <param name="rguidSchema">[in] A GUID identifying the schema rowset. For more information, see the "Comments" section and IDBSchemaRowset.</param>
		/// <param name="cRestrictions">[in] The count of restriction values.</param>
		/// <param name="rgRestrictions">
		/// [in] An array of restriction values. These are applied in the order of the restriction columns. That is, the first restriction
		/// value applies to the first restriction column, the second restriction value applies to the second restriction column, and so on.
		/// For more information, see the "Comments" section.
		/// </param>
		/// <param name="riid">
		/// [in] The IID of the requested rowset interface. This interface is conceptually added to the list of required interfaces on the
		/// resulting rowset, and the method fails (E_NOINTERFACE) if that interface cannot be supported on the resulting rowset.
		/// </param>
		/// <param name="cPropertySets">[in] The number of DBPROPSET structures in rgPropertySets. If this is 0, the provider ignores rgPropertySets.</param>
		/// <param name="rgPropertySets">
		/// <para>
		/// [in/out] An array of DBPROPSET structures containing properties and values to be set. The properties specified in these
		/// structures must belong to the Rowset property group. If the same property is specified more than once in rgPropertySets, it is
		/// provider-specific which value is used. If cPropertySets is 0, this argument is ignored.
		/// </para>
		/// <para>
		/// For information about the properties in the Rowset property group that are defined by OLE DB, see Rowset Property Group in
		/// Appendix C. For information about the DBPROPSET and DBPROP structures, see DBPROPSET Structure and DBPROP Structure.
		/// </para>
		/// </param>
		/// <param name="ppRowset">
		/// [out] A pointer to memory in which to return the requested interface pointer on the schema rowset. This rowset is read-only. If
		/// no applicable schema information exists, an empty rowset is returned.
		/// </param>
		/// <returns>
		/// <list type="bullet">
		/// <item>
		/// <description>
		/// <para>S_OK The method succeeded. In all DBPROP structures passed to the method, dwStatus is set to DBPROPSTATUS_OK.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// DB_S_ASYNCHRONOUS The method has initiated asynchronous creation of the rowset. The consumer can call <c>IDBAsynchStatus</c> to
		/// poll for status or <c>IConnectionPointContainer</c> to obtain the <c>IID_IDBAsynchNotify</c> connection point. Attempting to call
		/// any other interfaces might fail, and the full set of interfaces might not be available on the object until asynchronous
		/// initialization of the rowset has completed.
		/// </para>
		/// <para>DB_S_ASYNCHRONOUS should be returned before DB_S_ERRORSOCCURRED.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// DB_S_ERRORSOCCURRED The rowset was opened, but one or more properties ? for which the dwOptions element of the DBPROP structure
		/// was DBPROPOPTIONS_OPTIONAL ? were not set. The consumer checks dwStatus in the DBPROP structures to determine which properties
		/// were not set. The method can fail to set properties for a number of reasons, including the following:
		/// </para>
		/// <para>
		/// DB_S_ASYNCHRONOUS should be returned before DB_S_ERRORSOCCURRED. Once rowset population is complete, the consumer can see
		/// DB_S_ERRORSOCCURRED either by calling <c>IDBAsynchStatus::GetStatus</c> or by receiving <c>IDBAsynchNotify::OnStop</c>. Of
		/// course, the properties-in-error are not available, but for any properties that could not be set, the provider should report that
		/// status in the property array passed to <c>IDBSchemaRowset::GetRowset</c> (assuming that property failures can all be determined
		/// ahead of rowset population).
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// DB_S_NOTSINGLETON The provider supports returning row objects on <c>IDBSchemaRowset::GetRowset</c>, and the consumer requested a
		/// row object but the result was not a singleton. A row object of the first row of the rowset is returned if the provider supports
		/// returning the row object. Because returning this result can be expensive, providers are not required to do so. If
		/// DB_S_ERRORSOCCURRED also applies to the execution of this method, it takes precedence over DB_S_NOTSINGLETON.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>E_FAIL A provider-specific error occurred.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>E_INVALIDARG rguidSchema was invalid.</para>
		/// <para>rguidSchema specified a schema rowset that was not supported by the provider.</para>
		/// <para>In one or more restriction values specified in rgRestrictions, the vt element of the VARIANT was the incorrect type.</para>
		/// <para>cRestrictions was greater than zero, and rgRestrictions was a null pointer.</para>
		/// <para>ppRowset was a null pointer.</para>
		/// <para>In an element of rgPropertySets, cProperties was not 0 and rgProperties was a null pointer.</para>
		/// <para>cPropertySets was greater than zero, and rgPropertySets was a null pointer.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>E_NOINTERFACE The schema rowset did not support the interface specified in riid.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>E_OUTOFMEMORY The provider was unable to allocate sufficient memory in which to create the rowset.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// DB_E_ABORTLIMITREACHED The method failed because a resource limit has been reached. For example, a query used to implement the
		/// method timed out. No rowset is returned.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// DB_E_ERRORSOCCURRED No rowset was returned because one or more properties ? for which the dwOptions element of the DBPROP
		/// structure was DBPROPOPTIONS_REQUIRED or an invalid value ? were not set. The consumer checks dwStatus in the DBPROP structures to
		/// determine which properties were not set. None of the satisfiable properties are remembered. The method can fail to set properties
		/// for any of the reasons specified in DB_S_ERRORSOCCURRED.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// DB_E_NOAGGREGATION pUnkOuter was not a null pointer, and the provider is an OLE DB 1.0 or 1.1 provider that does not support
		/// aggregation of the rowset object being created.
		/// </para>
		/// <para>pUnkOuter was not a null pointer, and riid was not IID_IUnknown.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// DB_E_NOTFOUND The provider supports the return of singleton row objects on a method that typically returns a rowset, a row was
		/// requested via riid or DBPROP_IRow, and no rows existed in the rowset.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// DB_E_NOTSUPPORTED In an element of rgRestrictions, the vt element of the VARIANT was not VT_EMPTY and the provider did not
		/// support the corresponding restriction. Some providers may also return E_INVALIDARG for this case, particularly if the restriction
		/// was added in a later version of the specification.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_SEC_E_PERMISSIONDENIED The consumer did not have sufficient permission to create the schema rowset.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// DB_E_OBJECTOPEN The provider would have to open a new connection to support the operation, and DBPROP_MULTIPLECONNECTIONS is set
		/// to VARIANT_FALSE.
		/// </para>
		/// </description>
		/// </item>
		/// </list>
		/// </returns>
		// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/ms722634(v=vs.85) HRESULT GetRowset ( IUnknown *pUnkOuter,
		// REFGUID rguidSchema, ULONG cRestrictions, const VARIANT rgRestrictions[], REFIID riid, ULONG cPropertySets, DBPROPSET
		// rgPropertySets[], IUnknown **ppRowset);
		[PreserveSig]
		HRESULT GetRowset([In, Optional, MarshalAs(UnmanagedType.IUnknown)] object? pUnkOuter, in Guid rguidSchema, [Optional] uint cRestrictions,
			[In, Optional, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.Struct, SizeParamIndex = 2)] object[]? rgRestrictions,
			in Guid riid, uint cPropertySets, [In, Out, Optional] SafeDBPROPSETListHandle? rgPropertySets,
			[MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 4)] out object? ppRowset);

		/// <summary>Returns a list of schema rowsets accessible by <c>IDBSchemaRowset::GetRowset</c>.</summary>
		/// <param name="pcSchemas">
		/// [out] A pointer to memory in which to return the number of GUIDs in *prgSchemas. The returned count of schema GUIDs is always at
		/// least 3, because all providers must support the TABLES, COLUMNS, and PROVIDER_TYPES schema rowsets. If an error occurs,
		/// *pcSchemas is set to 0.
		/// </param>
		/// <param name="prgSchemas">
		/// [out] A pointer to memory in which to return an array of GUIDs identifying supported schema rowsets. For more information, see
		/// IDBSchemaRowset. The session allocates memory for the GUIDs and returns the address to this memory. The consumer releases this
		/// memory with <c>IMalloc::Free</c> when it no longer needs the list of GUIDs. If an error occurs, *prgSchemas is set to a null pointer.
		/// </param>
		/// <param name="prgRestrictionSupport">
		/// <para>
		/// [out] A pointer to memory in which to return an array of ULONGs, one element for each supported schema rowset, describing the
		/// restriction columns supported for that schema rowset. For a given schema rowset, the array element corresponding to the schema
		/// rowset will have the appropriate bit set if the provider implements a restriction on that column. Bits that do not correspond to
		/// currently defined restriction columns should not be set.
		/// </para>
		/// <para>
		/// The value of prgRestrictionSupport reflects on which of the columns listed as restriction columns the provider supports
		/// restrictions. The table of GUID restriction columns earlier in the overview of <c>IDBSchemaRowset</c> indicates the array of
		/// possible restriction columns to which this bitmask applies.
		/// </para>
		/// <para>
		/// For example, the GUID table at the beginning of this reference entry lists three restriction columns for the schema
		/// DBSCHEMA_ASSERTIONS. The array element corresponding to this schema will represent the CONSTRAINT_CATALOG column in bit 0, the
		/// CONSTRAINT_SCHEMA column in bit 1, and the CONSTRAINT_NAME column in bit 2. The following code shows how the consumer might
		/// determine whether a restriction on the CONSTRAINT_CATALOG column is supported on the ASSERTIONS schema rowset.
		/// </para>
		/// <para>
		/// The session allocates memory for the restrictions and returns the address to this memory. The consumer releases this memory with
		/// <c>IMalloc::Free</c> when it no longer needs the list of restrictions. If an error occurs, *prgRestrictionSupport is set to a
		/// null pointer.
		/// </para>
		/// <para>If prgRestrictionSupport is a null pointer, the session does not allocate any memory or return any restrictions.</para>
		/// </param>
		/// <returns>
		/// <list type="bullet">
		/// <item>
		/// <description>
		/// <para>S_OK The method succeeded.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>E_FAIL A provider-specific error occurred.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>E_INVALIDARG pcSchemas or prgSchemas was a null pointer.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// E_OUTOFMEMORY The provider was unable to allocate sufficient memory in which to return the array of schema GUIDs or restriction
		/// support information.
		/// </para>
		/// </description>
		/// </item>
		/// </list>
		/// </returns>
		// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/ms719605(v=vs.85) HRESULT GetSchemas ( ULONG *pcSchemas, GUID
		// **prgSchemas, ULONG **prgRestrictionSupport);
		void GetSchemas(out uint pcSchemas, out SafeIMallocHandle prgSchemas, out SafeIMallocHandle prgRestrictionSupport);
	}

	/// <summary>
	/// <para>
	/// <c>IErrorLookup</c> is used by OLE DB error objects to determine the values of the error message, source, Help file path, and context
	/// ID based on the return code and a provider-specific error number.
	/// </para>
	/// <para>
	/// <c>IErrorLookup</c> is exposed by a provider-specific error lookup service that is mandatory for all providers that return OLE DB
	/// error objects.
	/// </para>
	/// <para>
	/// The OLE DB error object code?that is, the code that implements OLE DB error objects?is included in the Windows SDK for Vista Beta 2
	/// and later. It was previously included in the Microsoft Data Access Components (MDAC) SDK.
	/// </para>
	/// </summary>
	// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/ms723039(v=vs.85)
	[PInvokeData("oledb.h")]
	[ComImport, Guid("0c733a66-2a1c-11ce-ade5-00aa0044773d"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IErrorLookup
	{
		/// <summary>Returns the error message and source, based on the return code and the provider-specific error number.</summary>
		/// <param name="hrError">[in] The code returned by the method that caused the error.</param>
		/// <param name="dwLookupID">[in] The provider-specific number of the error.</param>
		/// <param name="pdispparams">[in] The parameters of the error.</param>
		/// <param name="lcid">[in] The locale ID for which to return the description and source.</param>
		/// <param name="pbstrSource">
		/// [out] A pointer to memory in which to return a pointer to the name of the component that generated the error. If an error occurs,
		/// *pbstrSource is set to a null pointer. The memory for this string is allocated by the provider and must be freed by the consumer
		/// with a call to <c>SysFreeString</c>.
		/// </param>
		/// <param name="pbstrDescription">
		/// [out] A pointer to memory in which to return a pointer to a string that describes the error. If pdispparams was not a null
		/// pointer, the error parameters are integrated into this description. If there is no error description or an error occurs, the
		/// returned value (*pbstrDescription) is a null pointer. The memory for this string is allocated by the provider and must be freed
		/// by the consumer with a call to <c>SysFreeString</c>.
		/// </param>
		/// <returns>
		/// <list type="bullet">
		/// <item>
		/// <description>
		/// <para>S_OK The method succeeded.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>E_FAIL A provider-specific error occurred.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>E_INVALIDARG pbstrSource or pbstrDescription was a null pointer.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>E_OUTOFMEMORY The provider was unable to allocate sufficient memory in which to return the error source or description.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_E_BADHRESULT hrError was invalid.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_E_BADLOOKUPID dwLookupID was invalid.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_E_NOLOCALE The locale ID specified in lcid was not supported by the provider.</para>
		/// </description>
		/// </item>
		/// </list>
		/// </returns>
		// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/ms724398(v=vs.85) HRESULT GetErrorDescription ( HRESULT
		// hrError, DWORD dwLookupID, DISPPARAMS *pdispparams, LCID lcid, BSTR *pbstrSource, BSTR *pbstrDescription);
		void GetErrorDescription(HRESULT hrError, uint dwLookupID, in DISPPARAMS pdispparams, LCID lcid, [MarshalAs(UnmanagedType.BStr)] out string pbstrSource,
			[MarshalAs(UnmanagedType.BStr)] out string pbstrDescription);

		/// <summary>Returns the path of the Help file and the context ID of the topic that explains the error.</summary>
		/// <param name="hrError">[in] The code returned by the method that caused the error.</param>
		/// <param name="dwLookupID">[in] The provider-specific number of the error.</param>
		/// <param name="lcid">[in] The locale ID for which to return the Help file path and context ID.</param>
		/// <param name="pbstrHelpFile">
		/// [out] A pointer to memory in which to return a pointer to a string containing the fully qualified path of the Help file. If there
		/// is no Help file or an error occurs, the returned value (*pbstrHelpFile) is a null pointer. The memory for this string is
		/// allocated by the provider and must be freed by the consumer with a call to <c>SysFreeString</c>.
		/// </param>
		/// <param name="pdwHelpContext">
		/// [out] A pointer to memory in which to return the Help context ID for the error. If there is no Help file (*pbstrHelpFile is a
		/// null pointer), the returned value has no meaning.
		/// </param>
		/// <returns>
		/// <list type="bullet">
		/// <item>
		/// <description>
		/// <para>S_OK The method succeeded.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>E_FAIL A provider-specific error occurred.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>E_INVALIDARG pbstrHelpFile or pdwHelpContext was a null pointer.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>E_OUTOFMEMORY The provider was unable to allocate sufficient memory in which to return the Help file path.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_E_BADHRESULT hrError was invalid.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_E_BADLOOKUPID dwLookupID was invalid.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_E_NOLOCALE The locale ID specified in lcid was not supported by the provider.</para>
		/// </description>
		/// </item>
		/// </list>
		/// </returns>
		// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/ms714235(v=vs.85) HRESULT GetHelpInfo ( HRESULT hrError, DWORD
		// dwLookupID, LCID lcid, BSTR * pbstrHelpFile, DWORD * pdwHelpContext);
		void GetHelpInfo(HRESULT hrError, uint dwLookupID, LCID lcid, [MarshalAs(UnmanagedType.BStr)] out string pbstrHelpFile, out uint pdwHelpContext);

		/// <summary>Releases any dynamic error information associated with a dynamic error ID.</summary>
		/// <returns>
		/// <list type="bullet">
		/// <item>
		/// <description>
		/// <para>S_OK The method succeeded.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>E_FAIL A provider-specific error occurred.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_E_BADDYNAMICERRORID dwDynamicErrorID was invalid.</para>
		/// </description>
		/// </item>
		/// </list>
		/// </returns>
		// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/ms725437(v=vs.85) HRESULT ReleaseErrors ( const DWORD dwDynamicErrorID);
		void ReleaseErrors(uint dwDynamicErrorID);
	}

	/// <summary>
	/// <c>IErrorRecords</c> is defined by OLE DB. It is used to add and retrieve records in an OLE DB error object. Information is passed to
	/// and from OLE DB error objects in an ERRORINFO structure. For information about this structure, see Error Records.
	/// </summary>
	// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/ms718112(v=vs.85)
	[PInvokeData("oledb.h")]
	[ComImport, Guid("0c733a67-2a1c-11ce-ade5-00aa0044773d"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IErrorRecords
	{
		/// <summary>Adds a record to an OLE DB error object.</summary>
		/// <param name="pErrorInfo">
		/// [in] A pointer to an ERRORINFO structure containing information about the error. This structure is allocated and freed by the
		/// consumer. For more information, see Error Records.
		/// </param>
		/// <param name="dwLookupID">
		/// [in] The value used by the provider's error lookup service in conjunction with the return code to identify the error description,
		/// Help file, and context ID for an error. This can be a provider-specific value, such as the dwMinor element of *pErrorInfo. It can
		/// also be a special value, IDENTIFIER_SDK_ERROR, that tells the data access <c>IerrorInfo</c> implementation to ignore the
		/// provider's lookup service and use the description supplied in the data access error resource DLL.
		/// </param>
		/// <param name="pdispparams">
		/// [in] A pointer to the parameters for the error. This is a null pointer if there are no error parameters. The error parameters are
		/// inserted into the error text by the error lookup service. This structure is allocated and freed by the consumer. For more
		/// information, see "Error Parameters" in Error Records.
		/// </param>
		/// <param name="punkCustomError">
		/// [in] An interface pointer to the custom error object. This is a null pointer if there is no custom object for the error. For more
		/// information, see OLE DB Error Objects.
		/// </param>
		/// <param name="dwDynamicErrorID">
		/// <para>
		/// [in] If the error lookup service uses static errors ? that is, error information that is hard-coded in the lookup service ?
		/// dwDynamicErrorID is zero.
		/// </para>
		/// <para>
		/// If the error lookup service uses dynamic errors ? that is, error information that is created at run time ? dwDynamicErrorID is
		/// the ID of the error record. This ID is used to release the error information when the OLE DB error object is released. Although
		/// it is not required, it is more efficient for all error records in a single OLE DB error object to have the same dynamic error ID.
		/// </para>
		/// <para>For more information, see Error Lookup Services.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/ms725362(v=vs.85) HRESULT AddErrorRecord ( ERRORINFO
		// *pErrorInfo, DWORD dwLookupID, DISPPARAMS *pdispparams, IUnknown *punkCustomError, DWORD dwDynamicErrorID);
		void AddErrorRecord(in ERRORINFO pErrorInfo, uint dwLookupID, [In, Optional] IntPtr /* DISPPARAMS* */ pdispparams,
			[In, Optional, MarshalAs(UnmanagedType.IUnknown)] object? punkCustomError, uint dwDynamicErrorID);

		/// <summary>Returns basic information about the error, such as the return code and provider-specific error number.</summary>
		/// <param name="ulRecordNum">[in] The zero-based number of the record for which to return information.</param>
		/// <returns>
		/// [out] A pointer to an ERRORINFO structure in which to return basic error information. This structure is allocated and freed by
		/// the consumer. For more information, see Error Records.
		/// </returns>
		// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/ms723907(v=vs.85) HRESULT GetBasicErrorInfo ( ULONG
		// ulRecordNum, ERRORINFO *pErrorInfo);
		ERRORINFO GetBasicErrorInfo(uint ulRecordNum);

		/// <summary>Returns a pointer to an interface on the custom error object.</summary>
		/// <param name="ulRecordNum">[in] The zero-based number of the record for which to return a custom error object.</param>
		/// <param name="riid">[in] The IID of the interface to return.</param>
		/// <param name="ppObject">
		/// [out] A pointer to memory in which to return an interface pointer on the custom error object. If there is no custom error object,
		/// a null pointer is returned; that is, *ppObject is a null pointer.
		/// </param>
		// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/ms725417(v=vs.85) HRESULT GetCustomErrorObject ( ULONG
		// ulRecordNum, REFIID riid, IUnknown **ppObject);
		void GetCustomErrorObject(uint ulRecordNum, in Guid riid, [Optional, MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 1)] out object? ppObject);

		/// <summary>Returns an IErrorInfo interface pointer on the specified record.</summary>
		/// <param name="ulRecordNum">[in] The zero-based number of the record for which to return an <c>IErrorInfo</c> interface pointer.</param>
		/// <param name="lcid">
		/// [in] The locale ID for which to return error information. This parameter is checked when it is passed to methods in <c>IErrorInfo</c>.
		/// </param>
		/// <returns>
		/// [out] A pointer to memory in which to return a pointer to an <c>IErrorInfo</c> interface on the specified record. This
		/// <c>IErrorInfo</c> interface pointer is different from the <c>IErrorInfo</c> interface pointer exposed on the OLE DB error object
		/// with <c>QueryInterface</c>. For more information, see OLE DB Error Objects.
		/// </returns>
		// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/ms711230(v=vs.85) HRESULT GetErrorInfo ( ULONG ulRecordNum,
		// LCID lcid, IErrorInfo **ppErrorInfo);
		OleAut32.IErrorInfo GetErrorInfo(uint ulRecordNum, LCID lcid);

		/// <summary>Returns the error parameters.</summary>
		/// <param name="ulRecordNum">[in] The zero-based number of the record for which to return parameters.</param>
		/// <returns>
		/// [out] A pointer to a DISPPARAMS structure in which to return the error parameters. The consumer allocates the memory for the
		/// DISPPARAMS structure itself, but the provider allocates the memory for any arrays pointed to by elements of the DISPPARAMS structure.
		/// </returns>
		// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/ms715793(v=vs.85) HRESULT GetErrorParameters ( ULONG
		// ulRecordNum, DISPPARAMS * pdispparams);
		DISPPARAMS GetErrorParameters(uint ulRecordNum);

		/// <summary>Returns the count of records in the OLE DB error object.</summary>
		// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/ms722724(v=vs.85) HRESULT GetRecordCount ( ULONG * pcRecords);
		uint GetRecordCount();
	}

	/// <summary>Consumers use the <c>IGetRow</c> interface to get a row object or URL for a row in a rowset.</summary>
	// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/ms718047(v=vs.85)
	[PInvokeData("oledb.h")]
	[ComImport, Guid("0c733aaf-2a1c-11ce-ade5-00aa0044773d"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IGetRow
	{
		/// <summary>Creates a new row object from a row in a rowset and returns an interface pointer on the newly created row object.</summary>
		/// <param name="pUnkOuter">
		/// [in] If the row object is to be aggregated, pUnkOuter is an interface pointer to the controlling <c>IUnknown</c>. Otherwise, it
		/// is a null pointer.
		/// </param>
		/// <param name="hRow">
		/// <para>[in] The handle of the row from which the row object is to be created.</para>
		/// <para>
		/// <para>Warning</para>
		/// <para>
		/// The consumer must ensure that hRow contains a valid row handle because the provider might not validate hRow before using it. The
		/// result of passing the handle of a deleted row is provider-specific, although the provider must not terminate abnormally. For
		/// example, the provider might return DB_E_BADROWHANDLE or DB_E_DELETEDROW, or it might get data from a different row. The result of
		/// passing an invalid row handle in hRow is undefined.
		/// </para>
		/// </para>
		/// </param>
		/// <param name="riid">[in] The IID of the interface for which to return a pointer on the newly created row object.</param>
		/// <param name="ppUnk">
		/// [out] A pointer to memory in which to return an interface pointer on the row object. If <c>IGetRow::GetRowFromHROW</c> fails, the
		/// provider must attempt to set *ppUnk to a null pointer.
		/// </param>
		/// <returns>
		/// <list type="bullet">
		/// <item>
		/// <description>
		/// <para>S_OK The row object was created, and the interface pointer was successfully returned.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// DB_S_NOROWSPECIFICCOLUMNS The row object does not contain any row-specific columns. Providers are encouraged (but not required)
		/// to return this warning as a performance hint to consumers. As a result, the consumer can avoid the overhead of calling
		/// <c>IColumnsInfo::GetColumnInfo</c> for each row and allocating column access structures for row columns.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>E_FAIL A provider-specific error occurred.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>E_INVALIDARG ppUnk was a null pointer.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>E_NOINTERFACE The row object did not support the interface specified in riid, or riid was IID_NULL.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// DB_E_BADROWHANDLE hRow was invalid. Providers are not required to check for this condition, because doing so might slow the
		/// method significantly.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_E_NOAGGREGATION pUnkOuter was not a null pointer, and riid was not IID_IUnknown.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// DB_E_DELETEDROW hRow referred to a pending delete row or to a row for which a deletion had already been transmitted to the data store.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// DB_E_OBJECTOPEN The provider would have to open a new connection to support the operation, and DBPROP_MULTIPLECONNECTIONS is set
		/// to VARIANT_FALSE.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>E_UNEXPECTED <c>ITransaction::Commit</c> or <c>ITransaction::Abort</c> was called, and the row object is in a zombie state.</para>
		/// </description>
		/// </item>
		/// </list>
		/// </returns>
		// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/ms718237(v=vs.85) HRESULT GetRowFromHROW( IUnknown
		// **pUnkOuter, HROW hRow, REFIID riid, IUnknown **ppUnk); }
		[PreserveSig]
		HRESULT GetRowFromHROW([In, Optional, MarshalAs(UnmanagedType.IUnknown)] object? pUnkOuter, HROW hRow, in Guid riid, [MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 2)] out object? ppUnk);

		/// <summary>Given a handle of a row in a rowset, <c>IGetRow::GetURLFromHROW</c> returns the URL for that row.</summary>
		/// <param name="hRow">
		/// <para>[in] The row handle (HROW).</para>
		/// <para>
		/// <para>Warning</para>
		/// <para>
		/// The consumer must ensure that hRow contains a valid row handle because the provider might not validate hRow before using it. The
		/// result of passing the handle of a deleted row is provider-specific, although the provider must not terminate abnormally. For
		/// example, the provider might return DB_E_BADROWHANDLE or DB_E_DELETEDROW, or it might get data from a different row. The result of
		/// passing an invalid row handle in hRow is undefined.
		/// </para>
		/// </para>
		/// </param>
		/// <returns>[out] A pointer to provider-allocated memory in which to return the canonical URL for the row.</returns>
		// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/ms721234(v=vs.85) HRESULT GetURLFromHROW( HROW hRow, LPOLESTR
		// *ppwszURL); }
		[return: MarshalAs(UnmanagedType.LPWStr)]
		string? GetURLFromHROW(HROW hRow);
	}

	/// <summary>
	/// <para>
	/// <c>IOpenRowset</c> is a required interface on the session. It can be supported by providers that do not support creating rowsets
	/// through commands.
	/// </para>
	/// <para>
	/// The <c>IOpenRowset</c> model enables consumers to open and work directly with individual tables or indexes in a data store by using
	/// <c>IOpenRowset::OpenRowset</c>, which generates a rowset of all rows in the table or index.
	/// </para>
	/// </summary>
	// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/ms716946(v=vs.85)
	[PInvokeData("oledb.h")]
	[ComImport, Guid("0c733a69-2a1c-11ce-ade5-00aa0044773d"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IOpenRowset
	{
		/// <summary>Opens and returns a rowset that includes all rows from a single base table or index.</summary>
		/// <param name="pUnkOuter">[in] The controlling <c>IUnknown</c> if the rowset is to be aggregated; otherwise, a null pointer.</param>
		/// <param name="pTableID">[in] The DBID of the table to open. For more information, see the "Comments" section.</param>
		/// <param name="pIndexID">[in] The DBID of the index to open. For more information, see the "Comments" section.</param>
		/// <param name="riid">
		/// [in] The IID of the interface to return in *ppRowset. This interface is conceptually added to the list of required interfaces on
		/// the resulting rowset, and the method fails (E_NOINTERFACE) if that interface cannot be supported on the resulting rowset. This
		/// must be an interface that the rowset supports, even when ppRowset is set to a null pointer and no rowset is created.
		/// </param>
		/// <param name="cPropertySets">
		/// [in] The number of DBPROPSET structures in rgPropertySets. If this is zero, the provider ignores rgPropertySets.
		/// </param>
		/// <param name="rgPropertySets">
		/// <para>
		/// [in/out] An array of DBPROPSET structures containing properties and values to be set. The properties specified in these
		/// structures must belong to the Rowset property group. If the same property is specified more than once in rgPropertySets, it is
		/// provider-specific which value is used. If cPropertySets is zero, this argument is ignored.
		/// </para>
		/// <para>
		/// For information about the properties in the Rowset property group that are defined by OLE DB, see Rowset Properties in Appendix
		/// C. For information about the DBPROPSET and DBPROP structures, see DBPROPSET Structureand DBPROP Structure.
		/// </para>
		/// </param>
		/// <param name="ppRowset">
		/// [in/out] A pointer to memory in which to return the interface pointer to the created rowset. If ppRowset is a null pointer, no
		/// rowset is created; properties are verified and if a required property cannot be set, DB_E_ERRORSOCCURRED is returned. If
		/// <c>IOpenRowset::OpenRowset</c> fails, *ppRowset is set to a null pointer.
		/// </param>
		/// <returns>
		/// <list type="bullet">
		/// <item>
		/// <description>
		/// <para>S_OK The method succeeded and the rowset is opened. In all DBPROP structures passed to the method, dwStatus is set to DBPROPSTATUS_OK.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// DB_S_ASYNCHRONOUS The method has initiated asynchronous creation of the rowset. The consumer can call <c>IDBAsynchStatus</c> to
		/// poll for status or <c>IConnectionPointContainer</c> to obtain the <c>IID_IDBAsynchNotify</c> connection point. Attempting to call
		/// any other interfaces may fail, and the full set of interfaces might not be available on the object until asynchronous
		/// initialization of the rowset has completed. DB_S_ASYNCHRONOUS should be returned before DB_S_ERRORSOCCURRED.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// DB_S_ERRORSOCCURRED The rowset was opened, but one or more properties ? for which the dwOptions element of the DBPROP structure
		/// was DBPROPOPTIONS_OPTIONAL ? were not set. The consumer checks dwStatus in the DBPROP structures to determine which properties
		/// were not set. The method can fail to set properties for a number of reasons, including the following:
		/// </para>
		/// <para>
		/// DB_S_ASYNCHRONOUS should be returned before DB_S_ERRORSOCCURRED. Once rowset population is complete, the consumer can see
		/// DB_S_ERRORSOCCURRED either by calling <c>IDBAsynchStatus::GetStatus</c> or by receiving <c>IDBAsynchNotify::OnStop</c>. Of
		/// course, the properties-in-error are not available, but for any properties that could not be set, the provider should report that
		/// status in the property array passed to <c>IOpenRowset::OpenRowset</c> (assuming that property failures can all be determined
		/// ahead of rowset population).
		/// </para>
		/// <para>
		/// DB_S_ERRORSOCCURRED should be returned before DB_S_NOTSINGLETON because the status values can be checked, and providers are not
		/// required to return DB_S_NOTSINGLETON.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// DB_S_NOTSINGLETON The provider supports returning row objects on <c>IOpenRowset::OpenRowset</c>, and the consumer requested a row
		/// object but the result was not a singleton. A row object of the first row of the rowset is returned. Returning this result may be
		/// expensive, so providers are not required to do so. If DB_S_ERRORSOCCURRED also applies to the execution of this method, it takes
		/// precedence over DB_S_NOTSINGLETON.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// DB_S_STOPLIMITREACHED Execution has been stopped because a resource limit has been reached. The results obtained so far have been
		/// returned. This return code takes precedence over DB_S_ERRORSOCCURRED; that is, if the conditions described here and in those
		/// described in DB_S_ERRORSOCCURRED both occur, the provider returns this code. When the consumer receives this return code, it
		/// should also check for the conditions described in DB_S_ERRORSOCCURRED.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>E_FAIL A provider-specific error occurred.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>E_INVALIDARG pTableID and pIndexID were both null pointers.</para>
		/// <para>cPropertySets was not zero, and rgPropertySets was a null pointer.</para>
		/// <para>In an element of rgPropertySets, cProperties was not zero and rgProperties was a null pointer.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>E_NOINTERFACE The rowset did not support the interface specified in riid or riid was IID_NULL.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// DB_E_ABORTLIMITREACHED The method failed because a resource limit has been reached. For example, a query used to implement the
		/// method timed out. No rowset is returned.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// DB_E_ERRORSOCCURRED No rowset was returned because one or more properties ? for which the dwOptions element of the DBPROP
		/// structure was DBPROPOPTIONS_REQUIRED or an invalid value ? were not set. The consumer checks dwStatus in the DBPROP structures to
		/// determine which properties were not set. None of the satisfiable properties are remembered. The method can fail to set properties
		/// for any of the reasons specified in DB_S_ERRORSOCCURRED.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// DB_E_NOAGGREGATION pUnkOuter was not a null pointer, and the provider is an OLE DB 1.0 or 1.1 provider that does not support
		/// aggregation of the rowset object being created.
		/// </para>
		/// <para>pUnkOuter was not a null pointer, and riid was not IID_IUnknown.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_E_NOINDEX The specified index does not exist in the current data store or did not apply to the specified table.</para>
		/// <para>The provider does not support opening indexes through <c>IOpenRowset</c>.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// DB_E_NOSTATISTIC The specified statistic does not exist in the current data source or did not apply to the specified table, or it
		/// does not support a histogram.
		/// </para>
		/// <para>Providers that do not support histograms do not have to return this code.</para>
		/// <para>
		/// Providers that are unable to easily detect whether a histogram is available for the specified table are allowed to return S_OK
		/// and an empty histogram rowset.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_E_NOTABLE The specified table does not exist in the data store.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// DB_E_NOTFOUND The provider supports row objects, a row was requested via riid or DBPROP_IRow, and no rows existed in the rowset.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// DB_E_OBJECTOPEN The provider would have to open a new connection to support the operation, and DBPROP_MULTIPLECONNECTIONS is set
		/// to VARIANT_FALSE.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_E_PARAMNOTOPTIONAL The table specified by pTableID is a procedure that requires one or more parameters.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// DB_SEC_E_PERMISSIONDENIED The consumer did not have sufficient permission to open the rowset. For example, a rowset included a
		/// column for which the consumer does not have read permission.
		/// </para>
		/// </description>
		/// </item>
		/// </list>
		/// </returns>
		// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/ms716724(v=vs.85) HRESULT OpenRowset( IUnknown *pUnkOuter,
		// DBID *pTableID, DBID *pIndexID, REFIID riid, ULONG cPropertySets, DBPROPSET rgPropertySets[], IUnknown **ppRowset);
		[PreserveSig]
		HRESULT OpenRowset([In, Optional, MarshalAs(UnmanagedType.IUnknown)] object? pUnkOuter, [In, Optional] IntPtr pTableID,
			[In, Optional] IntPtr pIndexID, in Guid riid, uint cPropertySets, [In, Out] SafeDBPROPSETListHandle rgPropertySets,
			[Optional, MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 3)] out object? ppRowset);
	}

	/// <summary>
	/// <para>
	/// <c>IRowset</c> is the base rowset interface. It provides methods for fetching rows sequentially, getting the data from those rows,
	/// and managing rows.
	/// </para>
	/// <para><c>IRowset</c> requires <c>IAccessor</c> and <c>IRowsetInfo</c>.</para>
	/// </summary>
	// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/ms720986(v=vs.85)
	[PInvokeData("oledb.h")]
	[ComImport, Guid("0c733a7c-2a1c-11ce-ade5-00aa0044773d"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IRowset
	{
		/// <summary>Adds a reference count to an existing row handle.</summary>
		/// <param name="cRows">[in] The number of rows for which to increment the reference count.</param>
		/// <param name="rghRows">
		/// [in] An array of row handles for which to increment the reference count. The reference count of row handles is incremented by one
		/// for each time they appear in the array.
		/// </param>
		/// <param name="rgRefCounts">
		/// [out] An array with cRows elements in which to return the new reference count for each row handle. The consumer allocates memory
		/// for this array. If rgRefCounts is a null pointer, no reference counts are returned.
		/// </param>
		/// <param name="rgRowStatus">
		/// [out] An array with cRows elements in which to return values indicating the status of each row specified in rghRows. If no errors
		/// occur while incrementing the reference count of a row, the corresponding element of rgRowStatus is set to DBROWSTATUS_S_OK. If an
		/// error occurs while incrementing the reference count of a row, the corresponding element is set as specified in
		/// DB_S_ERRORSOCCURRED. The consumer allocates memory for this array. If rgRowStatus is a null pointer, no row statuses are returned.
		/// </param>
		/// <returns>
		/// <list type="bullet">
		/// <item>
		/// <description>
		/// <para>
		/// S_OK The method succeeded. The reference count of all rows was successfully incremented. The following value can be returned in *prgRowStatus:
		/// </para>
		/// <para>The reference count of the row was successfully incremented. The corresponding element of *prgRowStatus contains DBROWSTATUS_S_OK.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// DB_S_ERRORSOCCURRED An error occurred while incrementing the reference count of a row, but the reference count of at least one
		/// row was incremented. Successes can occur for the reason listed under S_OK. The following errors can occur:
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>E_FAIL A provider-specific error occurred.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>E_INVALIDARG rghRows was a null pointer, and cRows was not zero.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>E_UNEXPECTED <c>ITransaction::Commit</c> or <c>ITransaction::Abort</c> was called, and the object is in a zombie state.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// DB_E_ERRORSOCCURRED Errors occurred while incrementing the reference count of all of the rows. Errors can occur for the reasons
		/// listed under DB_S_ERRORSOCCURRED.
		/// </para>
		/// </description>
		/// </item>
		/// </list>
		/// </returns>
		// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/ms719619(v=vs.85) HRESULT AddRefRows( DBCOUNTITEM cRows, const
		// HROW rghRows[], DBREFCOUNT rgRefCounts[], DBROWSTATUS rgRowStatus[]);
		[PreserveSig]
		HRESULT AddRefRows(DBCOUNTITEM cRows, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] HROW[] rghRows,
			[Out, Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] DBREFCOUNT[]? rgRefCounts,
			[Out, Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] DBROWSTATUS[]? rgRowStatus);

		/// <summary>Retrieves data from the rowset's copy of the row.</summary>
		/// <param name="hRow">
		/// <para>[in] The handle of the row from which to get the data.</para>
		/// <para>
		/// <para>Warning</para>
		/// <para>
		/// The consumer must ensure that hRow contains a valid row handle; the provider might not validate hRow before using it. The result
		/// of passing the handle of a deleted row is provider-specific, although the provider cannot terminate abnormally. For example, the
		/// provider might return DB_E_BADROWHANDLE, DB_E_DELETEDROW, or it might get data from a different row. The result of passing an
		/// invalid row handle in hRow is undefined.
		/// </para>
		/// </para>
		/// </param>
		/// <param name="hAccessor">
		/// <para>
		/// [in] The handle of the accessor to use. If hAccessor is the handle of a null accessor (cBindings in
		/// <c>IAccessor::CreateAccessor</c> was zero), <c>IRowset::GetData</c> does not get any data values.
		/// </para>
		/// <para>
		/// <para>Warning</para>
		/// <para>
		/// The consumer must ensure that hAccessor contains a valid accessor handle; the provider might not validate hAccessor before using
		/// it. The result of passing an invalid accessor handle in hAccessor is undefined.
		/// </para>
		/// </para>
		/// </param>
		/// <param name="pData">
		/// [out] A pointer to a buffer in which to return the data. The consumer allocates memory for this buffer. This pointer must be a
		/// valid pointer to a contiguous block of consumer-owned memory into which the data will be written.
		/// </param>
		/// <returns>
		/// <list type="bullet">
		/// <item>
		/// <description>
		/// <para>
		/// S_OK The method succeeded. The status of all columns bound by the accessor is set to DBSTATUS_S_OK, DBSTATUS_S_ISNULL, or DBSTATUS_S_TRUNCATED.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// DB_S_ERRORSOCCURRED An error occurred while returning data for one or more columns, but data was successfully returned for at
		/// least one column. To determine the columns for which data was returned, the consumer checks the status values. For a list of
		/// status values that can be returned by this method, see "Status Values Used When Getting Data" in Status.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>E_FAIL A provider-specific error occurred.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>E_INVALIDARG pData was a null pointer, and the accessor was not a null accessor.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>E_UNEXPECTED <c>ITransaction::Commit</c> or <c>ITransaction::Abort</c> was called, and the object is in a zombie state.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// DB_E_BADACCESSORHANDLE hAccessor was invalid. Providers are not required to check for this condition, because doing so might slow
		/// the method significantly.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// DB_E_BADACCESSORTYPE The specified accessor was not a row accessor. Some providers may return DB_E_BADACCESSORHANDLE instead of
		/// this error code when command accessors are passed to the rowset.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// DB_E_BADROWHANDLE hRow was invalid. Providers are not required to check for this condition, because doing so might slow the
		/// method significantly.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// DB_E_DELETEDROW hRow referred to a pending delete row or a row for which a deletion had been transmitted to the data store.
		/// Providers are not required to check for this condition, because doing so might slow the method significantly.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// DB_E_ERRORSOCCURRED Errors occurred while returning data for all columns. To determine what errors occurred, the consumer checks
		/// the status values. For a list of status values that can be returned by this method, see "Status Values Used When Getting Data" in Status.
		/// </para>
		/// </description>
		/// </item>
		/// </list>
		/// </returns>
		// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/ms716988(v=vs.85) HRESULT GetData ( HROW hRow, HACCESSOR
		// hAccessor, void *pData);
		[PreserveSig]
		HRESULT GetData([In] HROW hRow, [In] HACCESSOR hAccessor, [Out] IntPtr pData);

		/// <summary>Fetches rows sequentially, remembering the previous position.</summary>
		/// <param name="hChapter">
		/// [in] The chapter handle designating the rows to fetch. For nonchaptered rowsets, the caller must set hChapter to
		/// DB_NULL_HCHAPTER. For chaptered rowsets, DB_NULL_HCHAPTER designates the entire rowset.
		/// </param>
		/// <param name="lRowsOffset">
		/// <para>
		/// [in] The signed count of rows to skip before fetching rows. Deleted rows that the provider has removed from the rowset are not
		/// counted in the skip. If this value is zero and cRows continues in the same direction as the previous call either to
		/// <c>IRowset::GetNextRows</c> or to IRowsetFind::FindNextRow with a null pBookmark value, the first row fetched will be the next
		/// row after the last one fetched in the previous call. If this value is zero and cRows reverses direction, the first row fetched
		/// will be the last one fetched in the previous call.
		/// </para>
		/// <para>
		/// lRowsOffset can be a negative number only if the value of the DBPROP_CANSCROLLBACKWARDS property is VARIANT_TRUE. A negative
		/// value means skipping the rows in a backward direction. There is no guarantee that skipping rows is done efficiently on a
		/// sequential rowset. If the data store resides on a remote server, there may be remote support for skipping without transferring
		/// the intervening records across the network but this is not guaranteed. For information about how the provider implements
		/// skipping, see the documentation for the provider.
		/// </para>
		/// </param>
		/// <param name="cRows">
		/// <para>
		/// [in] The number of rows to fetch. A negative number means to fetch backward. cRows can be a negative number only if the value of
		/// the DBPROP_CANFETCHBACKWARDS property is VARIANT_TRUE.
		/// </para>
		/// <para>
		/// If cRows is zero, the provider sets *pcRowsObtained to zero and performs no further processing, returning immediately from the
		/// method invocation. No rows are fetched, the fetch direction and the next fetch position are unchanged, and lRowsOffset is ignored.
		/// </para>
		/// <para>
		/// If the provider does not discover any other errors, the method returns S_OK; whether the provider checks for any other errors is provider-specific.
		/// </para>
		/// </param>
		/// <param name="pcRowsObtained">
		/// [out] A pointer to memory in which to return the actual number of fetched rows. If a warning condition occurs, this number may be
		/// less than the number of rows available or requested and is the number of rows actually fetched before the warning condition
		/// occurred. If the consumer has insufficient permission to fetch all rows, <c>IRowset::GetNextRows</c> fetches all rows for which
		/// the consumer has sufficient permission and skips all other rows. If the method fails, *pcRowsObtained is set to zero.
		/// </param>
		/// <param name="prghRows">
		/// <para>[out] A pointer to memory in which to return an array of handles of the fetched rows.</para>
		/// <para>
		/// If *prghRows is not a null pointer on input, it must be a pointer to consumer-allocated memory large enough to return the handles
		/// of the requested number of rows. If the consumer-allocated memory is larger than needed, the provider fills in as many row
		/// handles as specified by pcRowsObtained; the contents of the remaining memory are undefined.
		/// </para>
		/// <para>
		/// If *prghRows is a null pointer on input, the rowset allocates memory for the row handles and returns the address to this memory;
		/// the consumer releases this memory with <c>IMalloc::Free</c> after it releases the row handles. If *prghRows is a null pointer on
		/// input and *pcRowsObtained is zero on output or if the method fails, the provider does not allocate any memory and ensures that
		/// *prghRows is a null pointer on output.
		/// </para>
		/// </param>
		/// <returns>
		/// <list type="bullet">
		/// <item>
		/// <description>
		/// <para>S_OK The method succeeded.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// DB_S_ENDOFROWSET <c>IRowset::GetNextRows</c> reached the start or the end of the rowset or chapter or the start or end of the
		/// range on an index rowset and could not fetch all requested rows because the count extended beyond the end. The next fetch
		/// position is before the start or after the end of the rowset. The number of rows actually fetched is returned in *pcRowsObtained;
		/// this will be less than cRows.
		/// </para>
		/// <para>
		/// The rowset is being populated asynchronously, and no additional rows are available at this time. To determine whether additional
		/// rows may be available, the consumer should call IDBAsynchStatus::GetStatus or listen for the IDBAsynchNotify::OnStop notification.
		/// </para>
		/// <para>
		/// lRowsOffset indicated a position either more than one row before the first row of the rowset or more than one row after the last
		/// row, and the provider was a version 2.0 or greater provider. *pcRowsObtained is set to zero, and no rows are returned.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// DB_S_ROWLIMITEXCEEDED Fetching the number of rows specified in cRows would have exceeded the total number of active rows
		/// supported by the rowset, as reported by DBPROP_MAXOPENROWS. The number of rows that were actually fetched is returned in *pcRowsObtained.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// DB_S_STOPLIMITREACHED Fetching rows required further execution of the command, such as when the rowset uses a server-side cursor.
		/// Execution has been stopped because a resource limit has been reached. The number of rows that were actually fetched is returned
		/// in *pcRowsObtained.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>E_FAIL A provider-specific error occurred.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>E_INVALIDARG pcRowsObtained or prghRows was a null pointer.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>E_OUTOFMEMORY The provider was unable to allocate sufficient memory to complete the request.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>E_UNEXPECTED ITransaction::Commit or ITransaction::Abort was called, and the object is in a zombie state.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_E_BADCHAPTER The rowset was chaptered and hChapter was invalid.</para>
		/// <para>
		/// The rowset was single-chaptered, and the specified chapter was not the currently open chapter. The consumer must use the
		/// currently open chapter or release the currently open chapter before specifying a new chapter.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// DB_E_BADSTARTPOSITION lRowsOffset indicated a position either more than one row before the first row of the rowset or more than
		/// one row after the last row, and the provider was a 1.x provider.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_E_CANCELED Fetching rows was canceled during notification. No rows were fetched.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_E_CANTFETCHBACKWARDS cRows was negative, and the rowset cannot fetch backward.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_E_CANTSCROLLBACKWARDS lRowsOffset was negative, and the rowset cannot scroll backward.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// DB_E_NOTREENTRANT The provider called a method from IRowsetNotify in the consumer that had not yet returned, and the provider
		/// does not support reentrancy in this method.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// DB_E_ROWSNOTRELEASED The provider requires release of existing rows before new ones can be fetched. For more information, see
		/// DBPROP_CANHOLDROWS in Rowset Properties in Appendix C.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_SEC_E_PERMISSIONDENIED The consumer did not have sufficient permission to fetch any of the rows; no rows were fetched.</para>
		/// </description>
		/// </item>
		/// </list>
		/// </returns>
		// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/ms709827(v=vs.85) HRESULT GetNextRows ( HCHAPTER hChapter,
		// DBROWOFFSET lRowsOffset, DBROWCOUNT cRows, DBCOUNTITEM *pcRowsObtained, HROW **prghRows);
		[PreserveSig]
		HRESULT GetNextRows([In] HCHAPTER hChapter, DBROWOFFSET lRowsOffset, DBROWCOUNT cRows, out DBCOUNTITEM pcRowsObtained, out SafeIMallocHandle prghRows);

		/// <summary>Releases rows.</summary>
		/// <param name="cRows">[in] The number of rows to release. If cRows is zero, <c>IRowset::ReleaseRows</c> does not do anything.</param>
		/// <param name="rghRows">
		/// [in] An array of handles of the rows to be released. The row handles need not form a logical cluster; they may have been obtained
		/// at separate times and need not be for contiguous underlying rows. Row handles are decremented by one reference count for each
		/// time they appear in the array.
		/// </param>
		/// <param name="rgRowOptions">
		/// [in] An array of cRows elements containing bitmasks indicating additional options to be specified when releasing a row. This
		/// parameter is reserved for future use and should be set to a null pointer.
		/// </param>
		/// <param name="rgRefCounts">
		/// [out] An array with cRows elements in which to return the new reference count of each row. If rgRefCounts is a null pointer, no
		/// counts are returned. The consumer allocates, but is not required to initialize, memory for this array and passes the address of
		/// this memory to the provider. The provider returns the reference counts in the array.
		/// </param>
		/// <param name="rgRowStatus">
		/// [out] An array with cRows elements in which to return values indicating the status of each row specified in rghRows. If no errors
		/// or warnings occur while releasing a row, the corresponding element of rgRowStatus is set to DBROWSTATUS_S_OK. If an error or
		/// warning occurs while releasing a row, the corresponding element is set as specified in DB_S_ERRORSOCCURRED. The consumer
		/// allocates memory for this array. If rgRowStatus is a null pointer, no row statuses are returned.
		/// </param>
		/// <returns>
		/// <list type="bullet">
		/// <item>
		/// <description>
		/// <para>S_OK The method succeeded. All rows were successfully released. The following values can be returned in *prgRowStatus:</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// DB_S_ERRORSOCCURRED An error occurred while releasing a row, but at least one row was successfully released. Successes and
		/// warnings can occur for the reasons listed under S_OK. The following errors can occur:
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>E_FAIL A provider-specific error occurred.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>E_INVALIDARG rghRows was a null pointer, and cRows was not equal to zero.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// E_UNEXPECTED DBPROP_BLOCKINGSTORAGEOBJECTS is VARIANT_TRUE, and <c>IRowset::ReleaseRows</c> is called on a row with an open
		/// storage object. If the consumer, on cleanup, encounters an error while releasing the row, it should release the storage object first.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_E_ERRORSOCCURRED Errors occurred while releasing all of the rows. Errors can occur for the reasons listed under DB_S_ERRORSOCCURRED.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// DB_E_NOTREENTRANT The provider called a method from <c>IRowsetNotify</c> in the consumer that had not yet returned, and the
		/// provider does not support reentrancy in this method.
		/// </para>
		/// </description>
		/// </item>
		/// </list>
		/// </returns>
		// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/ms719771(v=vs.85) HRESULT ReleaseRows ( DBCOUNTITEM cRows,
		// const HROW rghRows[], DBROWOPTIONS rgRowOptions[], DBREFCOUNT rgRefCounts[], DBROWSTATUS rgRowStatus[]);
		[PreserveSig]
		HRESULT ReleaseRows(DBCOUNTITEM cRows, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] HROW[] rghRows,
			[In, Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] uint[]? rgRowOptions,
			[Out, Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] DBREFCOUNT[]? rgRefCounts,
			[Out, Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] DBROWSTATUS[]? rgRowStatus);

		/// <summary>
		/// Repositions the next fetch position used by IRowset::GetNextRows or IRowsetFind::FindNextRow to its initial position ? that is,
		/// its position when the rowset was first created.
		/// </summary>
		/// <returns>
		/// <list type="bullet">
		/// <item>
		/// <description>
		/// <para>
		/// S_OK The method succeeded. The provider did not have to re-execute the command, either because the rowset supports positioning on
		/// the first row without re-executing the command or because the rowset is already positioned on the first row.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// DB_S_COLUMNSCHANGED The order of the columns was not specified in the object that created the rowset. The provider had to
		/// re-execute the command to reposition the next fetch position to its initial position, and the order of the columns changed.
		/// </para>
		/// <para>
		/// The provider had to re-execute the command to reposition the next fetch position to its initial position, and columns were added
		/// or removed from the rowset. This is generally due to a change in the underlying schema and is extremely uncommon.
		/// </para>
		/// <para>
		/// This return code takes precedence over DB_S_COMMANDREEXECUTED. That is, if the conditions described here and in those described
		/// in DB_S_COMMANDREEXECUTED both occur, the provider returns this code. A change to the columns generally implies that the command
		/// was re-executed.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// DB_S_COMMANDREEXECUTED The command associated with this rowset was re-executed. If the properties DBPROP_OWNINSERT and
		/// DBPROP_OWNUPDATEDELETE are VARIANT_TRUE, the consumer will see its own changes. If the properties DBPROP_OWNINSERT or
		/// DBPROP_OWNUPDATEDELETE are VARIANT_FALSE, the rowset may see its changes. The order of the columns remains unchanged.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>E_FAIL A provider-specific error occurred.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>E_UNEXPECTED ITransaction::Commit or ITransaction::Abort was called, and the object is in a zombie state.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_E_BADCHAPTER The rowset was chaptered and hChapter was invalid.</para>
		/// <para>
		/// The rowset was single-chaptered, and the specified chapter was not the currently open chapter. The consumer must use the
		/// currently open chapter or release the currently open chapter before specifying a new chapter.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_E_CANCELED IRowset::RestartPosition was canceled during notification. The next fetch position remains unmodified.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// DB_E_CANNOTRESTART The rowset was built over a live data stream (for example, a stock feed), and the position cannot be restarted.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// DB_E_NOTREENTRANT The provider called a method from IRowsetNotify in the consumer that had not yet returned, and the provider
		/// does not support reentrancy in this method.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// DB_E_ROWSNOTRELEASED The provider requires release of existing rows before restarting because the rowset will be regenerated.
		/// This may be required even if the provider supports a value of VARIANT_TRUE for DBPROP_CANHOLDROWS. For more information, see
		/// DBPROP_CANHOLDROWS and DBPROP_QUICKRESTART in Rowset Properties in Appendix C.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_SEC_E_PERMISSIONDENIED The consumer did not have sufficient permission to reposition the next fetch position.</para>
		/// </description>
		/// </item>
		/// </list>
		/// </returns>
		// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/ms712877(v=vs.85) HRESULT RestartPosition ( HCHAPTER hChapter);
		[PreserveSig]
		HRESULT RestartPosition(HCHAPTER hReserved);
	}

	/// <summary><c>IRowsetInfo</c> provides information about a rowset.</summary>
	// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/ms724541(v=vs.85)
	[PInvokeData("oledb.h")]
	[ComImport, Guid("0c733a55-2a1c-11ce-ade5-00aa0044773d"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IRowsetInfo
	{
		/// <summary>Returns the current settings of all properties supported by the rowset.</summary>
		/// <param name="cPropertyIDSets">
		/// <para>[in] The number of DBPROPIDSET structures in rgPropertyIDSets.</para>
		/// <para>
		/// If cPropertySets is zero, the provider ignores rgPropertyIDSets and returns the values of all properties in the Rowset property
		/// group for which values exist, including properties for which values were not set but for which defaults exist, and also including
		/// properties for which values were set automatically because values were set for other properties.
		/// </para>
		/// <para>
		/// If cPropertyIDSets is not zero, the provider returns the values of the requested properties. If a property is not supported, the
		/// returned value of dwStatus in the returned DBPROP structure for that property is DBPROPSTATUS_NOTSUPPORTED and the value of
		/// dwOptions is undefined.
		/// </para>
		/// </param>
		/// <param name="rgPropertyIDSets">
		/// <para>
		/// [in] An array of cPropertyIDSets DBPROPIDSET structures. The properties specified in these structures must belong to the Rowset
		/// property group. The provider returns the values of the properties specified in these structures. If cPropertyIDSets is zero, this
		/// parameter is ignored.
		/// </para>
		/// <para>
		/// For information about the properties in the Rowset property group that are defined by OLE DB, see Rowset Properties in Appendix
		/// C. For information about the DBPROPIDSET structure, see DBPROPIDSET Structure.
		/// </para>
		/// </param>
		/// <param name="pcPropertySets">
		/// [out] A pointer to memory in which to return the number of DBPROPSET structures returned in *prgPropertySets. If cPropertyIDSets
		/// is zero, *pcPropertySets is the total number of property sets for which the provider supports at least one property in the Rowset
		/// property group. If cPropertyIDSets is greater than zero, *pcPropertySets is set to cPropertyIDSets. If an error other than
		/// DB_E_ERRORSOCCURRED occurs, *pcPropertySets is set to zero.
		/// </param>
		/// <param name="prgPropertySets">
		/// <para>
		/// [out] A pointer to memory in which to return an array of DBPROPSET structures. If cPropertyIDSets is zero, one structure is
		/// returned for each property set that contains at least one property belonging to the Rowset property group. If cPropertyIDSets is
		/// not zero, one structure is returned for each property set specified in rgPropertyIDSets.
		/// </para>
		/// <para>
		/// If cPropertyIDSets is not zero, the DBPROPSET structures in *prgPropertySets are returned in the same order as the DBPROPIDSET
		/// structures in rgPropertyIDSets; that is, for corresponding elements of each array, the guidPropertySet elements are the same. If
		/// cPropertyIDs, in an element of rgPropertyIDSets, is not zero, the DBPROP structures in the corresponding element of
		/// *prgPropertySets are returned in the same order as the DBPROPID values in rgPropertyIDs. Therefore, in the case where no column
		/// properties are specified in rgPropertyIDSets, corresponding elements of the input rgPropertyIDs and the returned rgProperties
		/// have the same property ID. However, if a column property is requested in rgPropertyIDSets, multiple properties may be returned,
		/// one for each column, in rgProperties. In this case, corresponding elements of rgPropertyIDs and rgProperties will not have the
		/// same property ID and rgProperties will contain more elements than rgPropertyIDs.
		/// </para>
		/// <para>
		/// The provider allocates memory for the structures and returns the address to this memory; the consumer releases this memory with
		/// <c>IMalloc::Free</c> when it no longer needs the structures. Before calling <c>IMalloc::Free</c> for *prgPropertySets, the
		/// consumer should call <c>IMalloc::Free</c> for the rgProperties element within each element of *prgPropertySets. The consumer must
		/// also call <c>VariantClear</c> for the vValue member of each DBPROP structure in order to prevent a memory leak in cases where the
		/// variant contains a reference type (such as a BSTR.) If *pcPropertySets is zero on output or if an error other than
		/// DB_E_ERRORSOCCURRED occurs, the provider does not allocate any memory and ensures that *prgPropertySets is a null pointer on output.
		/// </para>
		/// <para>For information about the DBPROPSET and DBPROP structures, see DBPROPSET Structure and DBPROP Structure.</para>
		/// </param>
		/// <returns>
		/// <list type="bullet">
		/// <item>
		/// <description>
		/// <para>S_OK The method succeeded. In all DBPROP structures returned by the method, dwStatus is set to DBPROPSTATUS_OK.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// DB_S_ERRORSOCCURRED No value was returned for one or more properties. The consumer checks dwStatus in the DBPROP structure to
		/// determine the properties for which values were not returned. <c>IRowsetInfo::GetProperties</c> can fail to return properties for
		/// a number of reasons, including the following:
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>E_FAIL A provider-specific error occurred.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>E_INVALIDARG cPropertyIDSets was not equal to zero, and rgPropertyIDSets was a null pointer.</para>
		/// <para>pcPropertySets or prgPropertySets was a null pointer.</para>
		/// <para>In an element of rgPropertyIDSets, cPropertyIDs was not zero and rgPropertyIDs was a null pointer.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>E_OUTOFMEMORY The provider was unable to allocate sufficient memory in which to return the DBPROPSET or DBPROP structures.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>E_UNEXPECTED <c>ITransaction::Commit</c> or <c>ITransaction::Abort</c> was called, and the object is in a zombie state.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// DB_E_ERRORSOCCURRED Values were not returned for any properties. The provider allocates memory for *prgPropertySets, and the
		/// consumer checks dwStatus in the DBPROP structures to determine why properties were not returned. The consumer frees this memory
		/// when it no longer needs the information.
		/// </para>
		/// </description>
		/// </item>
		/// </list>
		/// </returns>
		// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/ms719611(v=vs.85) HRESULT GetProperties ( const ULONG
		// cPropertyIDSets, const DBPROPIDSET rgPropertyIDSets[], ULONG *pcPropertySets, DBPROPSET **prgPropertySets);
		[PreserveSig]
		HRESULT GetProperties(uint cPropertyIDSets, [In] SafeDBPROPIDSETListHandle rgPropertyIDSets,
			out uint pcPropertySets, out SafeDBPROPSETListHandle prgPropertySets);

		/// <summary>Returns an interface pointer to the rowset to which a bookmark or chapter applies.</summary>
		/// <param name="iOrdinal">[in] The bookmark or chapter column for which to get the related rowset.</param>
		/// <param name="riid">
		/// [in] The IID of the interface pointer to return in *ppReferencedRowset. This interface is conceptually added to the list of
		/// required interfaces on the resulting rowset, and the method fails (E_NOINTERFACE) if that interface cannot be supported on the
		/// resulting rowset.
		/// </param>
		/// <param name="ppReferencedRowset">
		/// [out] A pointer to memory in which to return an <c>IUnknown</c> interface pointer on the rowset that interprets values from this
		/// column. If this is not a reference column, *ppReferencedRowset is set to a null pointer.
		/// </param>
		// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/ms721145(v=vs.85) HRESULT GetReferencedRowset ( DBORDINAL
		// iOrdinal, REFIID riid, IUnknown **ppReferencedRowset);
		void GetReferencedRowset(DBORDINAL iOrdinal, in Guid riid, [MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 1)] out object? ppReferencedRowset);

		/// <summary>Returns an interface pointer on the object (command or session) that created this rowset.</summary>
		/// <param name="riid">[in] The IID of the interface on which to return a pointer.</param>
		/// <param name="ppSpecification">
		/// [out] A pointer to memory in which to return the interface pointer. If the provider does not have an object that created the
		/// rowset, it sets *ppSpecification to a null pointer and returns S_FALSE. If <c>IRowsetInfo::GetSpecification</c> fails, it must
		/// attempt to set *ppSpecification to a null pointer.
		/// </param>
		/// <returns>
		/// <list type="bullet">
		/// <item>
		/// <description>
		/// <para>S_OK The method succeeded.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>S_FALSE The provider does not have an object that created the rowset.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>E_FAIL A provider-specific error occurred.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>E_INVALIDARG ppSpecification was a null pointer.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>E_NOINTERFACE The object that created this rowset did not support the interface specified in riid.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>E_UNEXPECTED <c>ITransaction::Commit</c> or <c>ITransaction::Abort</c> was called, and the object is in a zombie state.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// DB_E_NOTREENTRANT The provider called a method from <c>IRowsetNotify</c> in the consumer that had not yet returned, and the
		/// provider does not support reentrancy in this method.
		/// </para>
		/// </description>
		/// </item>
		/// </list>
		/// </returns>
		// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/ms716746(v=vs.85) HRESULT GetSpecification ( REFIID riid,
		// IUnknown **ppSpecification);
		[PreserveSig]
		HRESULT GetSpecification(in Guid riid, [MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 0)] out object? ppSpecification);
	}

	/// <summary>
	/// <para>
	/// <c>ISessionProperties</c> returns information about the properties a session supports and the current settings of those properties.
	/// It is a mandatory interface on sessions.
	/// </para>
	/// </summary>
	// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/ms713721(v=vs.85)
	[PInvokeData("oledb.h")]
	[ComImport, Guid("0c733a85-2a1c-11ce-ade5-00aa0044773d"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ISessionProperties
	{
		/// <summary>Returns the list of properties in the Session property group that are currently set on the session.</summary>
		/// <param name="cPropertyIDSets">
		/// <para>[in] The number of DBPROPIDSET structures in rgPropertyIDSets.</para>
		/// <para>
		/// If cPropertyIDSets is zero, the provider ignores rgPropertyIDSets and returns the values of all properties in the Session
		/// property group for which values have been set or defaults exist. It does not return the values of properties in the Session
		/// property group for which values have not been set and no defaults exist.
		/// </para>
		/// <para>
		/// If cPropertyIDSets is not zero, the provider returns the values of the requested properties. If a property is not supported, the
		/// returned value of dwStatus in the returned DBPROP structure for that property is DBPROPSTATUS_NOTSUPPORTED and the value of
		/// dwOptions is undefined.
		/// </para>
		/// </param>
		/// <param name="rgPropertyIDSets">
		/// <para>
		/// [in] An array of cPropertyIDSets DBPROPIDSET structures. The properties specified in these structures must belong to the Session
		/// property group. The provider returns the values of information about the properties specified in these structures. If
		/// cPropertyIDSets is zero, this parameter is ignored.
		/// </para>
		/// <para>
		/// For information about the properties in the Session property group that are defined by OLE DB, see Session Properties in Appendix
		/// C. For information about the DBPROPIDSET structure, see DBPROPIDSET Structure.
		/// </para>
		/// </param>
		/// <param name="pcPropertySets">
		/// [out] A pointer to memory in which to return the number of DBPROPSET structures returned in *prgPropertySets. If cPropertyIDSets
		/// is zero, *pcPropertySets is the total number of property sets for which the provider supports at least one property in the
		/// Session property group. If cPropertyIDSets is greater than zero, *pcPropertySets is set to cPropertyIDSets. If an error other
		/// than DB_E_ERRORSOCCURRED occurs, *pcPropertySets is set to zero.
		/// </param>
		/// <param name="prgPropertySets">
		/// <para>
		/// [out] A pointer to memory in which to return an array of DBPROPSET structures. If cPropertyIDSets is zero, one structure is
		/// returned for each property set that contains at least one property belonging to the Session property group. If cPropertyIDSets is
		/// not zero, one structure is returned for each property set specified in rgPropertyIDSets.
		/// </para>
		/// <para>
		/// If cPropertyIDSets is not zero, the DBPROPSET structures in *prgPropertySets are returned in the same order as the DBPROPIDSET
		/// structures in rgPropertyIDSets; that is, for corresponding elements of each array, the guidPropertySet elements are the same. If
		/// cPropertyIDs, in an element of rgPropertyIDSets, is not zero, the DBPROP structures in the corresponding element of
		/// *prgPropertySets are returned in the same order as the DBPROPID values in rgPropertyIDs; that is, for corresponding elements of
		/// each array, the property IDs are the same.
		/// </para>
		/// <para>
		/// The provider allocates memory for the structures and returns the address to this memory; the consumer releases this memory with
		/// <c>IMalloc::Free</c> when it no longer needs the structures. Before calling <c>IMalloc::Free</c> for *prgPropertySets, the
		/// consumer should call <c>IMalloc::Free</c> for the rgProperties element within each element of *prgPropertySets. The consumer must
		/// also call <c>VariantClear</c> for the vValue member of each DBPROP structure in order to prevent a memory leak in cases where the
		/// variant contains a reference type (such as a BSTR.) If *pcPropertySets is zero on output or if an error other than
		/// DB_E_ERRORSOCCURRED occurs, the provider does not allocate any memory and ensures that *prgPropertySets is a null pointer on output.
		/// </para>
		/// <para>For information about the DBPROPSET and DBPROP structures, see DBPROPSET Structure and DBPROP Structure.</para>
		/// </param>
		/// <returns>
		/// <list type="bullet">
		/// <item>
		/// <description>
		/// <para>S_OK The method succeeded. In all DBPROP structures returned by the method, dwStatus is set to DBPROPSTATUS_OK.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// DB_S_ERRORSOCCURRED No value was returned for one or more properties. The consumer checks dwStatus in the DBPROP structure to
		/// determine the properties for which values were not returned. <c>ISessionProperties::GetProperties</c> can fail to return
		/// properties for a number of reasons, including the following:
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>E_FAIL A provider-specific error occurred.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>E_INVALIDARG cPropertyIDSets was not equal to zero, and rgPropertyIDSets was a null pointer.</para>
		/// <para>pcPropertySets or prgPropertySets was a null pointer.</para>
		/// <para>In an element of rgPropertyIDSets, cPropertyIDs was not zero and rgPropertyIDs was a null pointer.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>E_OUTOFMEMORY The provider was unable to allocate sufficient memory in which to return the DBPROPSET or DBPROP structures.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// DB_E_ERRORSOCCURRED Values were not returned for any properties. The provider allocates memory for *prgPropertySets, and the
		/// consumer checks dwStatus in the DBPROP structures to determine why properties were not returned. The consumer frees this memory
		/// when it no longer needs the information.
		/// </para>
		/// </description>
		/// </item>
		/// </list>
		/// </returns>
		// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/ms723643(v=vs.85) HRESULT GetProperties ( ULONG
		// cPropertyIDSets, const DBPROPIDSET rgPropertyIDSets[], ULONG *pcPropertySets, DBPROPSET **prgPropertySets);
		[PreserveSig]
		HRESULT GetProperties(uint cPropertyIDSets, [In] SafeDBPROPIDSETListHandle rgPropertyIDSets,
			out uint pcPropertySets, out SafeDBPROPSETListHandle prgPropertySets);

		/// <summary>Sets properties in the Session property group.</summary>
		/// <param name="cPropertySets">
		/// [in] The number of DBPROPSET structures in rgPropertySets. If this is zero, the provider ignores rgPropertySets and the method
		/// does not do anything.
		/// </param>
		/// <param name="rgPropertySets">
		/// <para>
		/// [in/out] An array of DBPROPSET structures containing properties and values to be set. The properties specified in these
		/// structures must belong to the Session property group. If the same property is specified more than once in rgPropertySets, the
		/// value used is provider-specific. If cPropertySets is zero, this parameter is ignored.
		/// </para>
		/// <para>
		/// For information about the properties in the Session property group that are defined by OLE DB, see Session Properties in Appendix
		/// C. For information about the DBPROPSET and DBPROP structures, see DBPROPSET Structure and DBPROP Structure.
		/// </para>
		/// </param>
		/// <returns>
		/// <list type="bullet">
		/// <item>
		/// <description>
		/// <para>S_OK The method succeeded. In all DBPROP structures passed to the method, dwStatus is set to DBPROPSTATUS_OK.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// DB_S_ERRORSOCCURRED One or more properties were not set. Properties not in error remain set. The consumer checks dwStatus in the
		/// DBPROP structures to determine which properties were not set. <c>ISessionProperties::SetProperties</c> can fail to set properties
		/// for a number of reasons, including the following:
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>E_FAIL A provider-specific error occurred.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>E_INVALIDARG cPropertySets was not equal to zero, and rgPropertySets was a null pointer.</para>
		/// <para>In an element of rgPropertySets, cProperties was not zero and rgProperties was a null pointer.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// DB_E_ERRORSOCCURRED All property values were invalid, and no properties were set. The consumer checks dwStatus in the DBPROP
		/// structures to determine why properties were not set.
		/// </para>
		/// </description>
		/// </item>
		/// </list>
		/// </returns>
		// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/ms714405(v=vs.85) HRESULT SetProperties ( ULONG cPropertySets,
		// DBPROPSET rgPropertySets[]);
		[PreserveSig]
		HRESULT SetProperties(uint cPropertySets, [In, Out] SafeDBPROPSETListHandle? rgPropertySets);
	}

	/// <summary>
	/// <para>
	/// <c>ISourcesRowset</c> returns a rowset of data source objects and enumerators visible from the current enumerator. For more
	/// information about enumerators, see Enumerators.
	/// </para>
	/// </summary>
	// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/ms715969(v=vs.85)
	[PInvokeData("")]
	[ComImport, Guid("0c733a1e-2a1c-11ce-ade5-00aa0044773d"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ISourcesRowset
	{
		/// <summary>Returns a rowset of the data source objects and enumerators visible from the current enumerator.</summary>
		/// <param name="pUnkOuter">
		/// [in] A pointer to the controlling <c>IUnknown</c> interface if the sources rowset is being created as part of an aggregate. If
		/// the rowset is not part of an aggregate, this must be set to a null pointer.
		/// </param>
		/// <param name="riid">
		/// [in] The IID of the interface on which to return a pointer. This interface is conceptually added to the list of required
		/// interfaces on the resulting rowset, and the method fails (E_NOINTERFACE) if that interface cannot be supported on the resulting rowset.
		/// </param>
		/// <param name="cPropertySets">
		/// [in] The number of DBPROPSET structures in rgPropertySets. If this is zero, the provider ignores rgPropertySets.
		/// </param>
		/// <param name="rgPropertySets">
		/// <para>
		/// [in/out] An array of DBPROPSET structures containing properties and values to be set. The properties specified in these
		/// structures must belong to the Rowset property group. If the same property is specified more than once in rgPropertySets, it is
		/// provider-specific which value is used. If cPropertySets is 0, this argument is ignored.
		/// </para>
		/// <para>
		/// For information about the properties in the Rowset property group that are defined by OLE DB, see Rowset Properties in Appendix
		/// C. For information about the DBPROPSET and DBPROP structures, see DBPROPSET Structure and DBPROP Structure.
		/// </para>
		/// </param>
		/// <param name="ppSourcesRowset">
		/// [in] A pointer to memory in which to return the requested interface pointer on the rowset. If an error occurs, the returned
		/// pointer is null.
		/// </param>
		/// <returns>
		/// <list type="bullet">
		/// <item>
		/// <description>
		/// <para>S_OK The method succeeded. In all DBPROP structures passed to the method, dwStatus is set to DBPROPSTATUS_OK.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// DB_S_ERRORSOCCURRED The rowset was opened, but one or more properties ? for which the dwOptions element of the DBPROP structure
		/// was DBPROPOPTIONS_OPTIONAL ? were not set. The consumer checks dwStatus in the DBPROP structures to determine which properties
		/// were not set. The method can fail to set properties for a number of reasons, including the following:
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>E_FAIL A provider-specific error occurred.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>E_INVALIDARG ppSourcesRowset was a null pointer.</para>
		/// <para>cPropertySets was not 0, and rgPropertySets was a null pointer.</para>
		/// <para>In an element of rgPropertySets, cProperties was not 0 and rgProperties was a null pointer.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>E_NOINTERFACE The rowset did not support the interface specified in riid, or riid is IID_NULL.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>E_OUTOFMEMORY The provider did not have enough memory to create the rowset object.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>E_UNEXPECTED The enumerator object was in an uninitialized state.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// DB_E_ABORTLIMITREACHED The method failed because a resource limit has been reached. For example, a query used to implement the
		/// method timed out. No rowset is returned.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// DB_E_ERRORSOCCURRED No rowset was returned because one or more properties ? for which the dwOptions element of the DBPROP
		/// structure was DBPROPOPTIONS_REQUIRED or an invalid value ? were not set. The consumer checks dwStatus in the DBPROP structures to
		/// determine which properties were not set. None of the properties are remembered. The method can fail to set properties for any of
		/// the reasons specified in DB_S_ERRORSOCCURRED.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// DB_E_NOAGGREGATION pUnkOuter was not a null pointer, and the provider is an OLE DB 1.0 or 1.1 provider that does not support
		/// aggregation of the rowset object being created.
		/// </para>
		/// <para>pUnkOuter was not a null pointer, and riid was not IID_IUnknown.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// DB_E_NOTFOUND The provider supports the return of singleton row objects on a method that typically returns a rowset, a row was
		/// requested via riid or DBPROP_IRow, and no rows existed in the rowset.
		/// </para>
		/// </description>
		/// </item>
		/// </list>
		/// </returns>
		// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/ms711200(v=vs.85) HRESULT GetSourcesRowset( IUnknown
		// *pUnkOuter, REFIID riid, ULONG cPropertySets, DBPROPSET rgPropertySets[], IUnknown **ppSourcesRowset);
		[PreserveSig]
		HRESULT GetSourcesRowset([In, Optional, MarshalAs(UnmanagedType.IUnknown)] object? pUnkOuter, in Guid riid, uint cPropertySets,
			[In, Out] SafeDBPROPSETListHandle? rgPropertySets, [MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 1)] out object? ppSourcesRowset);
	}

	/// <summary><c>ISQLErrorInfo</c> is used to return the SQLSTATE and native error code.</summary>
	// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/ms711569(v=vs.85)
	[PInvokeData("oledb.h")]
	[ComImport, Guid("0c733a74-2a1c-11ce-ade5-00aa0044773d"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ISQLErrorInfo
	{
		/// <summary>Returns the SQLSTATE and native error code associated with an error.</summary>
		/// <param name="pbstrSQLState">
		/// [out] A pointer to memory in which to return a pointer to a string that contains the SQLSTATE. An SQLSTATE is a 5-character
		/// string defined by the ANSI SQL standard. The memory for this string is allocated by the provider and must be freed by the
		/// consumer with a call to <c>SysFreeString</c>. If an error occurs, *pbstrSQLState is set to a null pointer.
		/// </param>
		/// <param name="plNativeError">
		/// [out] A pointer to memory in which to return a provider-specific, native error code. *plNativeError is not necessarily the same
		/// as the dwMinor element in the ERRORINFO structure returned by <c>IErrorRecords::GetErrorInfo</c>. The combination of the hrError
		/// and dwMinor elements of the ERRORINFO structure is used to identify an error to the error lookup service, whereas *plNativeError
		/// has no such restrictions.
		/// </param>
		// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/ms718195(v=vs.85) HRESULT GetSQLInfo ( BSTR *pbstrSQLState,
		// LONG *plNativeError);
		void GetSQLInfo([MarshalAs(UnmanagedType.BStr)] out string pbstrSQLState, out int plNativeError);
	}

	/// <summary>Creates a new command.</summary>
	/// <typeparam name="T">The type of the interface being requested.</typeparam>
	/// <param name="cmd">The command interface.</param>
	/// <param name="pUnkOuter">
	/// [in] A pointer to the controlling <c>IUnknown</c> interface if the new command is being created as part of an aggregate. It is a null
	/// pointer if the command is not part of an aggregate.
	/// </param>
	/// <returns>[out] A pointer to memory in which to return the interface pointer on the newly created command.</returns>
	public static T CreateCommand<T>([In] this IDBCreateCommand cmd, [In, Optional, MarshalAs(UnmanagedType.IUnknown)] object? pUnkOuter)
	{
		cmd.CreateCommand(pUnkOuter, typeof(T).GUID, out var obj).ThrowIfFailed();
		return (T)obj!;
	}

	/// <summary>Creates a new session from the data source object and returns the requested interface on the newly created session.</summary>
	/// <typeparam name="T">The type of the interface being requested.</typeparam>
	/// <param name="session">The session interface.</param>
	/// <param name="pUnkOuter">
	/// [in] An optional pointer to the controlling <c>IUnknown</c> interface if the new session is being created as part of an aggregate. It
	/// is a null pointer if the session is not part of an aggregate.
	/// </param>
	/// <returns>The interface refrence.</returns>
	public static T CreateSession<T>([In] this IDBCreateSession session, [In, Optional, MarshalAs(UnmanagedType.IUnknown)] object? pUnkOuter) where T : class
	{
		session.CreateSession(pUnkOuter, typeof(T).GUID, out var obj).ThrowIfFailed();
		return (T)obj!;
	}

	/// <summary>Returns the bindings in an accessor.</summary>
	/// <param name="a">The <see cref="IAccessor"/> instance.</param>
	/// <param name="hAccessor">[in] The handle of the accessor for which to return the bindings.</param>
	/// <param name="pdwAccessorFlags">
	/// [out] A pointer to memory in which to return a bitmask that describes the properties of the accessor and how it is intended to be
	/// used. For more information, see dwAccessorFlags in CreateAccessor. If this method fails, *pdwAccessorFlags is set to DBACCESSOR_INVALID.
	/// </param>
	/// <param name="prgBindings">
	/// [out] A pointer to memory in which to return an array of DBBINDING structures. One DBBINDING structure is returned for each binding
	/// in the accessor. The provider allocates memory for these structures and any structures pointed to by elements of these structures;
	/// for example, if pObject in a binding structure is not a null pointer, the provider allocates a DBOBJECT structure for return to the
	/// consumer. The provider returns the address to the memory for these structures; the consumer releases the memory for these structures
	/// with <c>IMalloc::Free</c> when it no longer needs the bindings. If *pcBindings is zero on output or the method fails, the provider
	/// does not allocate any memory and ensures that *prgBindings is a null pointer on output. For information about bindings, see DBBINDING Structures.
	/// </param>
	/// <returns></returns>
	// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/ms721253(v=vs.85) HRESULT GetBindings ( HACCESSOR hAccessor,
	// DBACCESSORFLAGS *pdwAccessorFlags, DBCOUNTITEM *pcBindings, DBBINDING **prgBindings);
	public static void GetBindings(this IAccessor a, HACCESSOR hAccessor, out DBACCESSORFLAGS pdwAccessorFlags, out DBBINDING[] prgBindings)
	{
		a.GetBindings(hAccessor, out pdwAccessorFlags, out var c, out var p);
		prgBindings = c == 0 ? [] : p.ToArray<DBBINDING>((int)c);
	}

	/// <summary>Returns the column metadata needed by most consumers.</summary>
	/// <param name="ci">The <see cref="IColumnsInfo"/> instance.</param>
	/// <param name="prgInfo">[out] A pointer to memory in which to return an array of DBCOLUMNINFO structures. One structure is returned for each column in
	/// the rowset. The provider allocates memory for the structures and returns the address to this memory; the consumer releases this
	/// memory with <c>IMalloc::Free</c> when it no longer needs the column information. If *pcColumns is 0 on output or terminates due
	/// to an error, the provider does not allocate any memory and ensures that *prgInfo is a null pointer on output. For more
	/// information, see "DBCOLUMNINFO Structures" in the Comments section.</param>
	/// <returns></returns>
	// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/ms722704(v=vs.85) HRESULT GetColumnInfo ( DBORDINAL
	// *pcColumns, DBCOLUMNINFO **prgInfo, OLECHAR **ppStringsBuffer);
	public static HRESULT GetColumnInfo(this IColumnsInfo ci, out DBCOLUMNINFO_MGD[] prgInfo)
	{
		var hr = ci.GetColumnInfo(out var c, out var p, out var pp);
		prgInfo = c == 0 || hr.Failed ? [] : Array.ConvertAll(p.ToArray<DBCOLUMNINFO>((int)c), u => (DBCOLUMNINFO_MGD)u);
		//IMallocMemoryMethods.Instance.FreeMem(p);
		//IMallocMemoryMethods.Instance.FreeMem(pp);
		return hr;
	}

	/// <summary>Returns the list of properties in the Rowset property group that are currently requested for the rowset.</summary>
	/// <param name="icp">The <see cref="ICommandProperties"/> instance.</param>
	/// <param name="rgPropertyIDSets">
	/// <para>
	/// [in] An array of DBPROPIDSET structures. The properties specified in these structures must belong to the Rowset property group. The
	/// provider returns the values of the properties specified in these structures.
	/// </para>
	/// <para>
	/// For information about the properties in the Rowset property group that are defined by OLE DB, see Rowset Properties in Appendix C.
	/// For information about the DBPROPIDSET structure, see DBPROPIDSET Structure.
	/// </para>
	/// </param>
	/// <param name="prgPropertySets">
	/// <para>
	/// [out] An array of DBPROPSET structures. If rgPropertyIDSets is zero length, one structure is returned for each property set that
	/// contains at least one property belonging to the Rowset property group. If rgPropertyIDSets is not zero length, one structure is
	/// returned for each property set specified in rgPropertyIDSets.
	/// </para>
	/// <para>
	/// If rgPropertyIDSets is not zero lenght, the DBPROPSET structures in *prgPropertySets are returned in the same order as the
	/// DBPROPIDSET structures in rgPropertyIDSets; that is, for corresponding elements of each array, the guidPropertySet elements are the
	/// same. If cPropertyIDs in an element of rgPropertyIDSets is not zero, the DBPROP structures in the corresponding element of
	/// *prgPropertySets are returned in the same order as the DBPROPID values in rgPropertyIDs. Therefore, in the case where no column
	/// properties are specified in rgPropertyIDSets, corresponding elements of the input rgPropertyIDs and the returned rgProperties have
	/// the same property ID. However, if a column property is requested in rgPropertyIDSets, multiple properties may be returned, one for
	/// each column, in rgProperties. In this case, corresponding elements of rgPropertyIDs and rgProperties will not have the same property
	/// ID and rgProperties will contain more elements than rgPropertyIDs.
	/// </para>
	/// <para>
	/// The provider allocates memory for the structures and returns the address to this memory; the consumer releases this memory with
	/// <c>IMalloc::Free</c> when it no longer needs the structures. Before calling <c>IMalloc::Free</c> for *prgPropertySets, the consumer
	/// should call <c>IMalloc::Free</c> for the rgProperties element within each element of *prgPropertySets. The consumer must also call
	/// <c>VariantClear</c> for the vValue member of each DBPROP structure in order to prevent a memory leak in cases where the variant
	/// contains a reference type (such as a BSTR.) If *pcPropertySets is zero on output or an error other than DB_E_ERRORSOCCURRED occurs,
	/// the provider does not allocate any memory and ensures that *prgPropertySets is a null pointer on output.
	/// </para>
	/// <para>For information about the DBPROPSET and DBPROP structures, see DBPROPSET Structure and DBPROP Structure.</para>
	/// </param>
	/// <returns>
	/// <list type="bullet">
	/// <item>
	/// <description>
	/// <para>S_OK The method succeeded. In all DBPROP structures returned by the method, dwStatus is set to DBPROPSTATUS_OK.</para>
	/// </description>
	/// </item>
	/// <item>
	/// <description>
	/// <para>
	/// DB_S_ERRORSOCCURRED No value was returned for one or more properties. The consumer checks dwStatus in the DBPROP structure to
	/// determine the properties for which values were not returned. <c>ICommandProperties::GetProperties</c> can fail to return properties
	/// for a number of reasons, including:
	/// </para>
	/// </description>
	/// </item>
	/// <item>
	/// <description>
	/// <para>E_FAIL A provider-specific error occurred.</para>
	/// </description>
	/// </item>
	/// <item>
	/// <description>
	/// <para>E_INVALIDARG cPropertyIDSets was not equal to zero, and rgPropertyIDSets was a null pointer.</para>
	/// <para>pcPropertySets or prgPropertySets was a null pointer.</para>
	/// <para>In an element of rgPropertyIDSets, cPropertyIDs was not zero and rgPropertyIDs was a null pointer.</para>
	/// <para>
	/// In an element of rgPropertyIDSets, guidPropertySet was DBPROPSET_PROPERTIESINERROR and cPropertyIDs was not zero, or rgPropertyIDs
	/// was not a null pointer.
	/// </para>
	/// <para>cPropertyIDSets was greater than one, and in an element of rgPropertyIDSets, guidPropertySet was DBPROPSET_PROPERTIESINERROR.</para>
	/// </description>
	/// </item>
	/// <item>
	/// <description>
	/// <para>E_OUTOFMEMORY The provider was unable to allocate sufficient memory in which to return the DBPROPSET or DBPROP structures.</para>
	/// </description>
	/// </item>
	/// <item>
	/// <description>
	/// <para>
	/// DB_E_ERRORSOCCURRED No values were returned for any properties. The provider allocates memory for *prgPropertySets, and the consumer
	/// checks dwStatus in the DBPROP structures to determine why properties were not returned. The consumer frees this memory when it no
	/// longer needs the information.
	/// </para>
	/// </description>
	/// </item>
	/// </list>
	/// </returns>
	// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/ms723119(v=vs.85) HRESULT GetProperties ( const ULONG
	// cPropertyIDSets, const DBPROPIDSET rgPropertyIDSets[], ULONG * pcPropertySets, DBPROPSET ** prgPropertySets);
	public static HRESULT GetProperties(this ICommandProperties icp, DBPROPIDSET[] rgPropertyIDSets, out DBPROPSET[] prgPropertySets)
	{
		var hr = icp.GetProperties((uint)rgPropertyIDSets.Length, rgPropertyIDSets, out var c, out var mem);
		mem.Count = (int)c;
		prgPropertySets = c > 0 && !mem.IsInvalid ? mem : [];
		return hr;
	}

	/// <summary>
	/// Returns the values of properties in the Data Source, Data Source Information, and Initialization property groups that are currently
	/// set on the data source object, or returns the values of properties in the Initialization property group that are currently set on the enumerator.
	/// </summary>
	/// <param name="ip">The <see cref="IDBProperties"/> instance.</param>
	/// <param name="rgPropertyIDSets">
	/// <para>
	/// [in] An array of DBPROPIDSET structures. If the data source object or enumerator has not been initialized, the properties specified
	/// in these structures must belong to the Initialization property group. If the data source object or enumerator has been initialized,
	/// the properties specified in these structures must belong to the Data Source, Data Source Information, or Initialization property
	/// group, for data source objects, or to the Initialization property group, for enumerators. The provider returns the values of the
	/// properties specified in these structures. If length is zero, this argument is ignored.
	/// </para>
	/// <para>
	/// For information about the properties in the Data Source, Data Source Information, and Initialization property groups that are defined
	/// by OLE DB, see Data Source Property Group, Data Source Information Property Group, and Initialization Properties in Appendix C. For
	/// information about the DBPROPIDSET structure, see DBPROPIDSET Structure.
	/// </para>
	/// </param>
	/// <param name="prgPropertySets">
	/// <para>
	/// [out] A pointer to memory in which to return an array of DBPROPSET structures. If rgPropertyIDSets length is zero, one structure is
	/// returned for each property set that contains at least one property belonging to the Initialization property group (if the data source
	/// object or enumerator is not initialized), the Data Source, Data Source Information, or Initialization property group (if the data
	/// source object is initialized), or to the Initialization property group (if the enumerator is initialized). If rgPropertyIDSets length
	/// is not zero, one structure is returned for each property set specified in rgPropertyIDSets.
	/// </para>
	/// <para>
	/// In the case of properties in the Initialization property group and for a previously persisted data source object, those properties
	/// related to sensitive authentication information such as password will be returned in an encrypted form if
	/// DBPROP_AUTH_PERSIST_ENCRYPTED is VARIANT_TRUE.
	/// </para>
	/// <para>
	/// If rgPropertyIDSets length is not zero, the DBPROPSET structures in *prgPropertySets are returned in the same order as the
	/// DBPROPIDSET structures in rgPropertyIDSets; that is, for corresponding elements of each array, the guidPropertySet elements are the
	/// same. If cPropertyIDs, in an element of rgPropertyIDSets, is not zero, the DBPROP structures in the corresponding element of
	/// *prgPropertySets are returned in the same order as the DBPROPID values in rgPropertyIDs; that is, for corresponding elements of each
	/// array, the property IDs are the same.
	/// </para>
	/// <para>
	/// The provider allocates memory for the structures and returns the address to this memory; the consumer releases this memory with
	/// <c>IMalloc::Free</c> when it no longer needs the structures. Before calling <c>IMalloc::Free</c> for *prgPropertySets, the consumer
	/// should call <c>IMalloc::Free</c> for the rgProperties element within each element of *prgPropertySets. The consumer must also call
	/// <c>VariantClear</c> for the vValue member of each DBPROP structure in order to prevent a memory leak in cases where the variant
	/// contains a reference type (such as a BSTR.) If *pcPropertySets is zero on output or an error other than DB_E_ERRORSOCCURRED occurs,
	/// the provider does not allocate any memory and ensures that *prgPropertySets is a null pointer on output.
	/// </para>
	/// <para>For information about the DBPROPSET and DBPROP structures, see DBPROPSET Structure and DBPROP Structure.</para>
	/// </param>
	/// <returns>
	/// <list type="bullet">
	/// <item>
	/// <description>
	/// <para>
	/// S_OK The method succeeded. For property sets other than DBPROPSET_PROPERTIESINERROR, dwStatus is set to DBPROPSTATUS_OK in all DBPROP
	/// structures returned. If the requested property set is DBPROPSET_PROPERTIESINERROR, dwStatus reflects the individual error for each
	/// DBPROP structure returned from the method.
	/// </para>
	/// </description>
	/// </item>
	/// <item>
	/// <description>
	/// <para>
	/// DB_S_ERRORSOCCURRED No value was returned for one or more properties. The consumer checks dwStatus in the DBPROP structure to
	/// determine the properties for which values were not returned. IDBProperties::GetProperties can fail to return properties for a number
	/// of reasons, including the following:
	/// </para>
	/// </description>
	/// </item>
	/// <item>
	/// <description>
	/// <para>E_FAIL A provider-specific error occurred.</para>
	/// </description>
	/// </item>
	/// <item>
	/// <description>
	/// <para>E_INVALIDARG cPropertyIDSets was not equal to zero, and rgPropertyIDSets was a null pointer.</para>
	/// <para>pcPropertySets or prgPropertySets was a null pointer.</para>
	/// <para>In an element of rgPropertyIDSets, cPropertyIDs was not zero and rgPropertyIDs was a null pointer.</para>
	/// <para>
	/// In an element of rgPropertyIDSets, guidPropertySet was DBPROPSET_PROPERTIESINERROR and cPropertyIDs was not zero or rgPropertyIDs was
	/// not a null pointer.
	/// </para>
	/// <para>cPropertyIDSets was greater than 1, and in an element of rgPropertyIDSets, guidPropertySet was DBPROPSET_PROPERTIESINERROR.</para>
	/// </description>
	/// </item>
	/// <item>
	/// <description>
	/// <para>E_OUTOFMEMORY The provider was unable to allocate sufficient memory in which to return the DBPROPSET or DBPROP structures.</para>
	/// </description>
	/// </item>
	/// <item>
	/// <description>
	/// <para>
	/// DB_E_ERRORSOCCURRED Values were not returned for any properties. The provider allocates memory for *prgPropertySets, and the consumer
	/// checks dwStatus in the DBPROP structures to determine why properties were not returned. The consumer frees this memory when it no
	/// longer needs the information.
	/// </para>
	/// </description>
	/// </item>
	/// </list>
	/// </returns>
	public static HRESULT GetProperties(this IDBProperties ip, DBPROPIDSET[]? rgPropertyIDSets, out DBPROPSET[] prgPropertySets)
	{
		var hr = ip.GetProperties((uint)(rgPropertyIDSets?.Length ?? 0), rgPropertyIDSets, out var c, out var mem);
		mem.Count = (int)c;
		prgPropertySets = c > 0 && !mem.IsInvalid ? mem : [];
		return hr;
	}

	/// <summary>Returns the current settings of all properties supported by the rowset.</summary>
	/// <param name="i">The <see cref="IRowsetInfo"/> instance.</param>
	/// <param name="rgPropertyIDSets">
	/// <para>
	/// [in] An array of cPropertyIDSets DBPROPIDSET structures. The properties specified in these structures must belong to the Rowset
	/// property group. The provider returns the values of the properties specified in these structures. If cPropertyIDSets is zero, this
	/// parameter is ignored.
	/// </para>
	/// <para>
	/// For information about the properties in the Rowset property group that are defined by OLE DB, see Rowset Properties in Appendix C.
	/// For information about the DBPROPIDSET structure, see DBPROPIDSET Structure.
	/// </para>
	/// </param>
	/// <param name="prgPropertySets">
	/// <para>
	/// [out] A pointer to memory in which to return an array of DBPROPSET structures. If cPropertyIDSets is zero, one structure is returned
	/// for each property set that contains at least one property belonging to the Rowset property group. If cPropertyIDSets is not zero, one
	/// structure is returned for each property set specified in rgPropertyIDSets.
	/// </para>
	/// <para>
	/// If cPropertyIDSets is not zero, the DBPROPSET structures in *prgPropertySets are returned in the same order as the DBPROPIDSET
	/// structures in rgPropertyIDSets; that is, for corresponding elements of each array, the guidPropertySet elements are the same. If
	/// cPropertyIDs, in an element of rgPropertyIDSets, is not zero, the DBPROP structures in the corresponding element of *prgPropertySets
	/// are returned in the same order as the DBPROPID values in rgPropertyIDs. Therefore, in the case where no column properties are
	/// specified in rgPropertyIDSets, corresponding elements of the input rgPropertyIDs and the returned rgProperties have the same property
	/// ID. However, if a column property is requested in rgPropertyIDSets, multiple properties may be returned, one for each column, in
	/// rgProperties. In this case, corresponding elements of rgPropertyIDs and rgProperties will not have the same property ID and
	/// rgProperties will contain more elements than rgPropertyIDs.
	/// </para>
	/// <para>
	/// The provider allocates memory for the structures and returns the address to this memory; the consumer releases this memory with
	/// <c>IMalloc::Free</c> when it no longer needs the structures. Before calling <c>IMalloc::Free</c> for *prgPropertySets, the consumer
	/// should call <c>IMalloc::Free</c> for the rgProperties element within each element of *prgPropertySets. The consumer must also call
	/// <c>VariantClear</c> for the vValue member of each DBPROP structure in order to prevent a memory leak in cases where the variant
	/// contains a reference type (such as a BSTR.) If *pcPropertySets is zero on output or if an error other than DB_E_ERRORSOCCURRED
	/// occurs, the provider does not allocate any memory and ensures that *prgPropertySets is a null pointer on output.
	/// </para>
	/// <para>For information about the DBPROPSET and DBPROP structures, see DBPROPSET Structure and DBPROP Structure.</para>
	/// </param>
	/// <returns>
	/// <list type="bullet">
	/// <item>
	/// <description>
	/// <para>S_OK The method succeeded. In all DBPROP structures returned by the method, dwStatus is set to DBPROPSTATUS_OK.</para>
	/// </description>
	/// </item>
	/// <item>
	/// <description>
	/// <para>
	/// DB_S_ERRORSOCCURRED No value was returned for one or more properties. The consumer checks dwStatus in the DBPROP structure to
	/// determine the properties for which values were not returned. <c>IRowsetInfo::GetProperties</c> can fail to return properties for a
	/// number of reasons, including the following:
	/// </para>
	/// </description>
	/// </item>
	/// <item>
	/// <description>
	/// <para>E_FAIL A provider-specific error occurred.</para>
	/// </description>
	/// </item>
	/// <item>
	/// <description>
	/// <para>E_INVALIDARG cPropertyIDSets was not equal to zero, and rgPropertyIDSets was a null pointer.</para>
	/// <para>pcPropertySets or prgPropertySets was a null pointer.</para>
	/// <para>In an element of rgPropertyIDSets, cPropertyIDs was not zero and rgPropertyIDs was a null pointer.</para>
	/// </description>
	/// </item>
	/// <item>
	/// <description>
	/// <para>E_OUTOFMEMORY The provider was unable to allocate sufficient memory in which to return the DBPROPSET or DBPROP structures.</para>
	/// </description>
	/// </item>
	/// <item>
	/// <description>
	/// <para>E_UNEXPECTED <c>ITransaction::Commit</c> or <c>ITransaction::Abort</c> was called, and the object is in a zombie state.</para>
	/// </description>
	/// </item>
	/// <item>
	/// <description>
	/// <para>
	/// DB_E_ERRORSOCCURRED Values were not returned for any properties. The provider allocates memory for *prgPropertySets, and the consumer
	/// checks dwStatus in the DBPROP structures to determine why properties were not returned. The consumer frees this memory when it no
	/// longer needs the information.
	/// </para>
	/// </description>
	/// </item>
	/// </list>
	/// </returns>
	// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/ms719611(v=vs.85) HRESULT GetProperties ( const ULONG
	// cPropertyIDSets, const DBPROPIDSET rgPropertyIDSets[], ULONG *pcPropertySets, DBPROPSET **prgPropertySets);
	public static HRESULT GetProperties(this IRowsetInfo i, DBPROPIDSET[] rgPropertyIDSets, out DBPROPSET[] prgPropertySets)
	{
		var hr = i.GetProperties((uint)rgPropertyIDSets.Length, rgPropertyIDSets, out var c, out var mem);
		mem.Count = (int)c;
		prgPropertySets = c > 0 && !mem.IsInvalid ? mem : [];
		return hr;
	}

	/// <summary>Returns the list of properties in the Session property group that are currently set on the session.</summary>
	/// <param name="sp">The <see cref="ISessionProperties"/> instance.</param>
	/// <param name="rgPropertyIDSets">
	/// <para>
	/// [in] An array of cPropertyIDSets DBPROPIDSET structures. The properties specified in these structures must belong to the Session
	/// property group. The provider returns the values of information about the properties specified in these structures. If cPropertyIDSets
	/// is zero, this parameter is ignored.
	/// </para>
	/// <para>
	/// For information about the properties in the Session property group that are defined by OLE DB, see Session Properties in Appendix C.
	/// For information about the DBPROPIDSET structure, see DBPROPIDSET Structure.
	/// </para>
	/// </param>
	/// <param name="prgPropertySets">
	/// <para>
	/// [out] A pointer to memory in which to return an array of DBPROPSET structures. If cPropertyIDSets is zero, one structure is returned
	/// for each property set that contains at least one property belonging to the Session property group. If cPropertyIDSets is not zero,
	/// one structure is returned for each property set specified in rgPropertyIDSets.
	/// </para>
	/// <para>
	/// If cPropertyIDSets is not zero, the DBPROPSET structures in *prgPropertySets are returned in the same order as the DBPROPIDSET
	/// structures in rgPropertyIDSets; that is, for corresponding elements of each array, the guidPropertySet elements are the same. If
	/// cPropertyIDs, in an element of rgPropertyIDSets, is not zero, the DBPROP structures in the corresponding element of *prgPropertySets
	/// are returned in the same order as the DBPROPID values in rgPropertyIDs; that is, for corresponding elements of each array, the
	/// property IDs are the same.
	/// </para>
	/// <para>
	/// The provider allocates memory for the structures and returns the address to this memory; the consumer releases this memory with
	/// <c>IMalloc::Free</c> when it no longer needs the structures. Before calling <c>IMalloc::Free</c> for *prgPropertySets, the consumer
	/// should call <c>IMalloc::Free</c> for the rgProperties element within each element of *prgPropertySets. The consumer must also call
	/// <c>VariantClear</c> for the vValue member of each DBPROP structure in order to prevent a memory leak in cases where the variant
	/// contains a reference type (such as a BSTR.) If *pcPropertySets is zero on output or if an error other than DB_E_ERRORSOCCURRED
	/// occurs, the provider does not allocate any memory and ensures that *prgPropertySets is a null pointer on output.
	/// </para>
	/// <para>For information about the DBPROPSET and DBPROP structures, see DBPROPSET Structure and DBPROP Structure.</para>
	/// </param>
	/// <returns>
	/// <list type="bullet">
	/// <item>
	/// <description>
	/// <para>S_OK The method succeeded. In all DBPROP structures returned by the method, dwStatus is set to DBPROPSTATUS_OK.</para>
	/// </description>
	/// </item>
	/// <item>
	/// <description>
	/// <para>
	/// DB_S_ERRORSOCCURRED No value was returned for one or more properties. The consumer checks dwStatus in the DBPROP structure to
	/// determine the properties for which values were not returned. <c>ISessionProperties::GetProperties</c> can fail to return properties
	/// for a number of reasons, including the following:
	/// </para>
	/// </description>
	/// </item>
	/// <item>
	/// <description>
	/// <para>E_FAIL A provider-specific error occurred.</para>
	/// </description>
	/// </item>
	/// <item>
	/// <description>
	/// <para>E_INVALIDARG cPropertyIDSets was not equal to zero, and rgPropertyIDSets was a null pointer.</para>
	/// <para>pcPropertySets or prgPropertySets was a null pointer.</para>
	/// <para>In an element of rgPropertyIDSets, cPropertyIDs was not zero and rgPropertyIDs was a null pointer.</para>
	/// </description>
	/// </item>
	/// <item>
	/// <description>
	/// <para>E_OUTOFMEMORY The provider was unable to allocate sufficient memory in which to return the DBPROPSET or DBPROP structures.</para>
	/// </description>
	/// </item>
	/// <item>
	/// <description>
	/// <para>
	/// DB_E_ERRORSOCCURRED Values were not returned for any properties. The provider allocates memory for *prgPropertySets, and the consumer
	/// checks dwStatus in the DBPROP structures to determine why properties were not returned. The consumer frees this memory when it no
	/// longer needs the information.
	/// </para>
	/// </description>
	/// </item>
	/// </list>
	/// </returns>
	// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/ms723643(v=vs.85) HRESULT GetProperties ( ULONG cPropertyIDSets,
	// const DBPROPIDSET rgPropertyIDSets[], ULONG *pcPropertySets, DBPROPSET **prgPropertySets);
	public static HRESULT GetProperties(this ISessionProperties sp, DBPROPIDSET[] rgPropertyIDSets, out DBPROPSET[] prgPropertySets)
	{
		var hr = sp.GetProperties((uint)rgPropertyIDSets.Length, rgPropertyIDSets, out var c, out var mem);
		mem.Count = (int)c;
		prgPropertySets = c > 0 && !mem.IsInvalid ? mem : [];
		return hr;
	}

	/// <summary>Opens and returns a rowset that includes all rows from a single base table or index.</summary>
	/// <typeparam name="T">The type of <paramref name="pRowset"/> to return.</typeparam>
	/// <param name="rs">The <see cref="IOpenRowset"/> instance.</param>
	/// <param name="pUnkOuter">[in] The controlling <c>IUnknown</c> if the rowset is to be aggregated; otherwise, a null pointer.</param>
	/// <param name="pTableID">[in] The DBID of the table to open. For more information, see the "Comments" section.</param>
	/// <param name="pIndexID">[in] The DBID of the index to open. For more information, see the "Comments" section.</param>
	/// <param name="rgPropertySets">
	/// <para>
	/// [in/out] An array of DBPROPSET structures containing properties and values to be set. The properties specified in these structures
	/// must belong to the Rowset property group. If the same property is specified more than once in rgPropertySets, it is provider-specific
	/// which value is used. If cPropertySets is zero, this argument is ignored.
	/// </para>
	/// <para>
	/// For information about the properties in the Rowset property group that are defined by OLE DB, see Rowset Properties in Appendix C.
	/// For information about the DBPROPSET and DBPROP structures, see DBPROPSET Structureand DBPROP Structure.
	/// </para>
	/// </param>
	/// <param name="pRowset">
	/// [in/out] A pointer to memory in which to return the interface pointer to the created rowset. If ppRowset is a null pointer, no rowset
	/// is created; properties are verified and if a required property cannot be set, DB_E_ERRORSOCCURRED is returned. If
	/// <c>IOpenRowset::OpenRowset</c> fails, *ppRowset is set to a null pointer.
	/// </param>
	/// <returns>
	/// <list type="bullet">
	/// <item>
	/// <description>
	/// <para>S_OK The method succeeded and the rowset is opened. In all DBPROP structures passed to the method, dwStatus is set to DBPROPSTATUS_OK.</para>
	/// </description>
	/// </item>
	/// <item>
	/// <description>
	/// <para>
	/// DB_S_ASYNCHRONOUS The method has initiated asynchronous creation of the rowset. The consumer can call <c>IDBAsynchStatus</c> to poll
	/// for status or <c>IConnectionPointContainer</c> to obtain the <c>IID_IDBAsynchNotify</c> connection point. Attempting to call any
	/// other interfaces may fail, and the full set of interfaces might not be available on the object until asynchronous initialization of
	/// the rowset has completed. DB_S_ASYNCHRONOUS should be returned before DB_S_ERRORSOCCURRED.
	/// </para>
	/// </description>
	/// </item>
	/// <item>
	/// <description>
	/// <para>
	/// DB_S_ERRORSOCCURRED The rowset was opened, but one or more properties ? for which the dwOptions element of the DBPROP structure was
	/// DBPROPOPTIONS_OPTIONAL ? were not set. The consumer checks dwStatus in the DBPROP structures to determine which properties were not
	/// set. The method can fail to set properties for a number of reasons, including the following:
	/// </para>
	/// <para>
	/// DB_S_ASYNCHRONOUS should be returned before DB_S_ERRORSOCCURRED. Once rowset population is complete, the consumer can see
	/// DB_S_ERRORSOCCURRED either by calling <c>IDBAsynchStatus::GetStatus</c> or by receiving <c>IDBAsynchNotify::OnStop</c>. Of course,
	/// the properties-in-error are not available, but for any properties that could not be set, the provider should report that status in
	/// the property array passed to <c>IOpenRowset::OpenRowset</c> (assuming that property failures can all be determined ahead of rowset population).
	/// </para>
	/// <para>
	/// DB_S_ERRORSOCCURRED should be returned before DB_S_NOTSINGLETON because the status values can be checked, and providers are not
	/// required to return DB_S_NOTSINGLETON.
	/// </para>
	/// </description>
	/// </item>
	/// <item>
	/// <description>
	/// <para>
	/// DB_S_NOTSINGLETON The provider supports returning row objects on <c>IOpenRowset::OpenRowset</c>, and the consumer requested a row
	/// object but the result was not a singleton. A row object of the first row of the rowset is returned. Returning this result may be
	/// expensive, so providers are not required to do so. If DB_S_ERRORSOCCURRED also applies to the execution of this method, it takes
	/// precedence over DB_S_NOTSINGLETON.
	/// </para>
	/// </description>
	/// </item>
	/// <item>
	/// <description>
	/// <para>
	/// DB_S_STOPLIMITREACHED Execution has been stopped because a resource limit has been reached. The results obtained so far have been
	/// returned. This return code takes precedence over DB_S_ERRORSOCCURRED; that is, if the conditions described here and in those
	/// described in DB_S_ERRORSOCCURRED both occur, the provider returns this code. When the consumer receives this return code, it should
	/// also check for the conditions described in DB_S_ERRORSOCCURRED.
	/// </para>
	/// </description>
	/// </item>
	/// <item>
	/// <description>
	/// <para>E_FAIL A provider-specific error occurred.</para>
	/// </description>
	/// </item>
	/// <item>
	/// <description>
	/// <para>E_INVALIDARG pTableID and pIndexID were both null pointers.</para>
	/// <para>cPropertySets was not zero, and rgPropertySets was a null pointer.</para>
	/// <para>In an element of rgPropertySets, cProperties was not zero and rgProperties was a null pointer.</para>
	/// </description>
	/// </item>
	/// <item>
	/// <description>
	/// <para>E_NOINTERFACE The rowset did not support the interface specified in riid or riid was IID_NULL.</para>
	/// </description>
	/// </item>
	/// <item>
	/// <description>
	/// <para>
	/// DB_E_ABORTLIMITREACHED The method failed because a resource limit has been reached. For example, a query used to implement the method
	/// timed out. No rowset is returned.
	/// </para>
	/// </description>
	/// </item>
	/// <item>
	/// <description>
	/// <para>
	/// DB_E_ERRORSOCCURRED No rowset was returned because one or more properties ? for which the dwOptions element of the DBPROP structure
	/// was DBPROPOPTIONS_REQUIRED or an invalid value ? were not set. The consumer checks dwStatus in the DBPROP structures to determine
	/// which properties were not set. None of the satisfiable properties are remembered. The method can fail to set properties for any of
	/// the reasons specified in DB_S_ERRORSOCCURRED.
	/// </para>
	/// </description>
	/// </item>
	/// <item>
	/// <description>
	/// <para>
	/// DB_E_NOAGGREGATION pUnkOuter was not a null pointer, and the provider is an OLE DB 1.0 or 1.1 provider that does not support
	/// aggregation of the rowset object being created.
	/// </para>
	/// <para>pUnkOuter was not a null pointer, and riid was not IID_IUnknown.</para>
	/// </description>
	/// </item>
	/// <item>
	/// <description>
	/// <para>DB_E_NOINDEX The specified index does not exist in the current data store or did not apply to the specified table.</para>
	/// <para>The provider does not support opening indexes through <c>IOpenRowset</c>.</para>
	/// </description>
	/// </item>
	/// <item>
	/// <description>
	/// <para>
	/// DB_E_NOSTATISTIC The specified statistic does not exist in the current data source or did not apply to the specified table, or it
	/// does not support a histogram.
	/// </para>
	/// <para>Providers that do not support histograms do not have to return this code.</para>
	/// <para>
	/// Providers that are unable to easily detect whether a histogram is available for the specified table are allowed to return S_OK and an
	/// empty histogram rowset.
	/// </para>
	/// </description>
	/// </item>
	/// <item>
	/// <description>
	/// <para>DB_E_NOTABLE The specified table does not exist in the data store.</para>
	/// </description>
	/// </item>
	/// <item>
	/// <description>
	/// <para>DB_E_NOTFOUND The provider supports row objects, a row was requested via riid or DBPROP_IRow, and no rows existed in the rowset.</para>
	/// </description>
	/// </item>
	/// <item>
	/// <description>
	/// <para>
	/// DB_E_OBJECTOPEN The provider would have to open a new connection to support the operation, and DBPROP_MULTIPLECONNECTIONS is set to VARIANT_FALSE.
	/// </para>
	/// </description>
	/// </item>
	/// <item>
	/// <description>
	/// <para>DB_E_PARAMNOTOPTIONAL The table specified by pTableID is a procedure that requires one or more parameters.</para>
	/// </description>
	/// </item>
	/// <item>
	/// <description>
	/// <para>
	/// DB_SEC_E_PERMISSIONDENIED The consumer did not have sufficient permission to open the rowset. For example, a rowset included a column
	/// for which the consumer does not have read permission.
	/// </para>
	/// </description>
	/// </item>
	/// </list>
	/// </returns>
	// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/ms716724(v=vs.85) HRESULT OpenRowset( IUnknown *pUnkOuter, DBID
	// *pTableID, DBID *pIndexID, REFIID riid, ULONG cPropertySets, DBPROPSET rgPropertySets[], IUnknown **ppRowset);
	public static HRESULT OpenRowset<T>(this IOpenRowset rs, [In, Optional] object? pUnkOuter, [In, Optional] DBID? pTableID, [In, Optional] DBID? pIndexID,
		[In, Out, Optional] DBPROPSET[]? rgPropertySets, out T? pRowset) where T : class
	{
		using SafeDBPROPSETListHandle h = rgPropertySets ?? [];
		var hr = rs.OpenRowset(pUnkOuter, (SafeCoTaskMemStruct<DBID>)pTableID, (SafeCoTaskMemStruct<DBID>)pIndexID, typeof(T).GUID,
			(uint)h.Count, h, out var ppRowset);
		rgPropertySets = h;
		pRowset = hr.Succeeded ? (T?)ppRowset : null;
		return hr;
	}

	/// <summary>Basic information about the error, such as the return code and provider-specific error number.</summary>
	[PInvokeData("oledb.h")]
	[StructLayout(LayoutKind.Sequential)]
	public struct ERRORINFO
	{
		/// <summary>Undocumented.</summary>
		public HRESULT hrError;
		/// <summary>Undocumented.</summary>
		public uint dwMinor;
		/// <summary>Undocumented.</summary>
		public Guid clsid;
		/// <summary>Undocumented.</summary>
		public Guid iid;
		/// <summary>Undocumented.</summary>
		public int dispid;
	}

	/*IADOConnectionConstruction
	IADOSecurity
	IAlterIndex
	IAlterTable
	IBindResource
	IChapteredRowset
	IColumnsInfo
	IColumnsInfo2
	IColumnsRowset
	ICommandPersist
	ICommandPrepare
	ICommandStream
	ICommandWithParameters
	IConvertType
	IcreateRow
	IDataSourceLocator
	IDBAsynchNotify
	IDBAsynchStatus
	IDBBinderProperties
	IDBDataSourceAdmin
	IDBInfo
	IDBSchemaRowset
	IGetDataSource
	IGetSession
	IGetSourceRow
	IIndexDefinition
	IMultipleResults
	IOpenRowset
	IParentRowset
	IRegisterProvider
	IRow
	IRowChange
	IRowSchemaChange
	IRowsetBookmark
	IRowsetChange
	IRowsetChapterMember
	IRowsetCurrentIndex
	IRowsetExactScroll
	IRowsetFind
	IRowsetIdentity
	IRowsetIndex
	IRowsetLocate
	IRowsetNotify
	IRowsetRefresh
	IRowsetResynch
	IRowsetScroll
	IRowsetUpdate
	IRowsetView
	IScopedOperations
	ISourcesRowset
	ISQLXMLHelper
	ITableCreation
	ITableDefinition
	ITableDefinitionWithConstraints
	ITransaction
	ITransactionJoin
	ITransactionLocal
	ITransactionObject
	ITransactionOptions
	IViewChapter
	IViewFilter
	IViewRowset
	IViewSort
	*/
}