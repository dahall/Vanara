namespace Vanara.PInvoke;

/// <summary>Items from the OleDb.dll.</summary>
public static partial class OleDb
{
	/// <summary>Undocumented.</summary>
	public const uint IDENTIFIER_SDK_ERROR = 0x10000000;

	/// <summary>Undocumented.</summary>
	public const uint IDENTIFIER_SDK_MASK = 0xF0000000;

	private const string Lib_OleDb = "OleDb.dll";

	/// <summary>Whether <c>IConvertType::CanConvert</c> is to determine if the conversion is supported on the rowset or on the command.</summary>
	[PInvokeData("oledb.h")]
	[Flags]
	public enum DBCONVERTFLAGS
	{
		/// <summary>
		/// <c>IConvertType::CanConvert</c> is to determine whether the conversion is supported when setting, getting, finding, filtering, or
		/// seeking on columns of the rowset or row. This flag is mutually exclusive with DBCONVERTFLAGS_PARAMETER.
		/// </summary>
		DBCONVERTFLAGS_COLUMN = 0,

		/// <summary><c>IConvertType::CanConvert</c> is to determine whether the conversion is supported on the parameters of the command.</summary>
		DBCONVERTFLAGS_PARAMETER = 0x1,

		/// <summary>
		/// <c>IConvertType::CanConvert</c> is to determine whether the long version of the DBTYPE specified in the <c>dwFromType</c> can be
		/// converted to the DBTYPE specified in <c>wToType</c>. This flag is valid only when used in conjunction with a variable-length
		/// DBTYPE. This flag can coexist with either DBCONVERTFLAGS_COLUMN or DBCONVERTFLAGS_PARAMETER. This flag is supported only by OLE
		/// DB version 2.0 or later providers.
		/// </summary>
		DBCONVERTFLAGS_ISLONG = 0x2,

		/// <summary>
		/// <c>IConvertType::CanConvert</c> is to determine whether a fixed-length value of the DBTYPE specified in the <c>dwFromType</c> can
		/// be converted to the DBTYPE specified in <c>wToType</c>. This flag can coexist with either DBCONVERTFLAGS_COLUMN or
		/// DBCONVERTFLAGS_PARAMETER. This flag is supported only by OLE DB version 2.0 or later providers.
		/// </summary>
		DBCONVERTFLAGS_ISFIXEDLENGTH = 0x4,

		/// <summary>
		/// The DBTYPE specified in the <c>wFromType</c> represents a type within a VARIANT. <c>IConvertType::CanConvert</c> returns whether
		/// the conversion from a VARIANT of that type to the type specified in <c>wToType</c> is allowed. For providers that support
		/// PROPVARIANT, this applies to conversions from PROPVARIANT as well.
		/// </summary>
		DBCONVERTFLAGS_FROMVARIANT = 0x8
	}

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
	/// <para>The <c>IAlterIndex</c> interface exposes methods to alter indexes.</para>
	/// </summary>
	// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/ms714943(v=vs.85)
	[PInvokeData("oledb.h")]
	[ComImport, Guid("0c733aa6-2a1c-11ce-ade5-00aa0044773d"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IAlterIndex
	{
		/// <summary>Alters the ID and/or properties associated with an index.</summary>
		/// <param name="pTableId">[in] The DBID of the indexed base table.</param>
		/// <param name="pIndexId">[in] The DBID of the existing index to alter.</param>
		/// <param name="pNewIndexId">
		/// [in] The new DBID of the index. If this is the same as pIndexID or is a null pointer, the ID of the index is unchanged.
		/// </param>
		/// <param name="cPropertySets">
		/// [in] The number of DBPROPSET structures in rgPropertySets. If this is zero, the provider ignores rgPropertySets.
		/// </param>
		/// <param name="rgPropertySets">
		/// [in/out] An array of DBPROPSET structures containing properties and values to be set. The properties specified in these
		/// structures must belong to the index property set.
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
		/// DB_S_ERRORSOCCURRED The index was altered but one or more properties ? for which the dwOptions element of the DBPROP structure
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
		/// <para>E_INVALIDARG pTableID was a null pointer.</para>
		/// <para>pIndexID was a null pointer.</para>
		/// <para>cPropertySets was not zero, and rgPropertySets was a null pointer.</para>
		/// <para>In an element of rgPropertySets, cProperties was not zero and rgProperties was a null pointer.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_E_BADINDEXID *pIndexID or *pNewIndexID was an invalid index ID.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_E_BADTABLEID *pTableID was an invalid table ID.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_E_DUPLICATEINDEXID The index specified in *pNewIndexID already exists in the data store and is not the same as pIndexID.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// DB_E_ERRORSOCCURRED The index was not altered because one or more properties ? for which the dwOptions element of the DBPROP
		/// structure was DBPROPOPTIONS_REQUIRED or an invalid value ? were not set. The consumer checks dwStatus in the DBPROP structures to
		/// determine which properties were not set. None of the satisfiable properties are remembered. The method can fail to set properties
		/// for any of the reasons specified in DB_S_ERRORSOCCURRED, except the reason that states that it was not possible to set the property.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_E_INDEXINUSE The specified index was in use.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_E_NOINDEX The index specified in *pIndexID does not exist in the data store or does not apply to the specified table.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_E_NOTABLE The table specified in *pTableID does not exist in the data store.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_E_TABLEINUSE The specified table was in use, and the provider could not modify the index with the table open.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_SEC_E_PERMISSIONDENIED The consumer did not have sufficient permission to alter the index.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// XACT_E_XTIONEXISTS The provider supports transactional DDL, the session is participating in a transaction, and the value of
		/// DBPROP_SUPPORTEDTXNDDL is DBPROPVAL_TC_DML.
		/// </para>
		/// </description>
		/// </item>
		/// </list>
		/// </returns>
		// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/ms714965(v=vs.85) HRESULT AlterIndex( DBID *pTableID, DBID
		// *pIndexID, DBID *pNewIndexID, ULONG cPropertySets, DBPROPSET rgPropertySets[]);
		[PreserveSig]
		HRESULT AlterIndex(in DBID pTableId, in DBID pIndexId, in DBID pNewIndexId, uint cPropertySets, [In] SafeDBPROPSETListHandle rgPropertySets);
	}

	/// <summary>
	/// <para>The <c>IAlterTable</c> interface exposes methods to alter the definition of tables and columns.</para>
	/// <para>Providers that implement <c>IAlterTable</c> should expose the data source information property DBPROP_ALTERCOLUMN.</para>
	/// </summary>
	// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/ms719764(v=vs.85)
	[PInvokeData("oledb.h")]
	[ComImport, Guid("0c733aa5-2a1c-11ce-ade5-00aa0044773d"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IAlterTable
	{
		/// <summary>Alters the column ID and/or properties associated with a column in a table.</summary>
		/// <param name="pTableId">[in] The DBID of the base table containing the column to alter.</param>
		/// <param name="pColumnId">[in] The current DBID of the column to alter.</param>
		/// <param name="dwColumnDescFlags">
		/// <para>
		/// [in] Values as described in the enumeration DBCOLUMNDESCFLAGS. As illustrated in the following table, these bits define which
		/// portions of the DBCOLUMNDESC structure defined in pColumnDesc should be used when altering the column. A provider returns values
		/// it supports in the DBPROP_ALTERCOLUMN property. For more information about this field, please see the Comments section.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <description>DBCOLUMNDESCFLAGS values</description>
		/// <description>Associated portion of DBCOLUMNDESC</description>
		/// </listheader>
		/// <item>
		/// <description>DBCOLUMNDESCFLAGS_TYPENAME</description>
		/// <description><c>pwszTypeName</c></description>
		/// </item>
		/// <item>
		/// <description>DBCOLUMNDESCFLAGS_ITYPEINFO</description>
		/// <description><c>ITypeInfo *</c></description>
		/// </item>
		/// <item>
		/// <description>DBCOLUMNDESCFLAGS_PROPERTIES</description>
		/// <description><c>rgPropertySets</c> AND <c>cPropertySets</c></description>
		/// </item>
		/// <item>
		/// <description>DBCOLUMNDESCFLAGS_CLSID</description>
		/// <description><c>pclsid</c></description>
		/// </item>
		/// <item>
		/// <description>DBCOLUMNDESCFLAGS_COLSIZE</description>
		/// <description><c>ulColumnSize</c></description>
		/// </item>
		/// <item>
		/// <description>DBCOLUMNDESCFLAGS_DBCID</description>
		/// <description><c>dbcid</c></description>
		/// </item>
		/// <item>
		/// <description>DBCOLUMNDESCFLAGS_WTYPE</description>
		/// <description><c>wType</c></description>
		/// </item>
		/// <item>
		/// <description>DBCOLUMNDESCFLAGS_PRECISION</description>
		/// <description><c>bPrecision</c></description>
		/// </item>
		/// <item>
		/// <description>DBCOLUMNDESCFLAGS_SCALE</description>
		/// <description><c>bScale</c></description>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="pColumnDesc">
		/// [in] A pointer to a DBCOLUMNDESCstructure defining new values for the columns. Only the values defined in dwColumnDescFlags are
		/// used ? the provider ignores other fields in the structure. For a description of the DBCOLUMNDESC structure, please refer to <c>ITableDefinition::CreateTable</c>.
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
		/// DB_S_ERRORSOCCURRED The column was altered, but one or more properties ? for which the dwOptions element of the DBPROP structure
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
		/// <para>E_INVALIDARG pTableID or pColumnID was a null pointer.</para>
		/// <para>pColumnDesc was a null pointer.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_E_ALTERRESTRICTED The provider could not alter the column because it was referenced by a constraint.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_E_BADCOLUMNID The dbcid member of *pColumnDesc was invalid.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_E_BADPRECISION The bPrecision member of *pColumnDesc was invalid.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_E_BADSCALE The bScale member of *pColumnDesc was invalid.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// DB_E_BADTYPE One or more of the wType, pwszTypeName, or *pTypeInfo members of *pColumnDesc was invalid, or the provider was
		/// unable to change the existing column type to the new column type.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_E_DUPLICATECOLUMNID The column ID specified in the dbcid member of *pColumnDesc was the same as an existing column ID.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// DB_E_ERRORSOCCURRED The column was not altered because one or more properties ? for which the dwOptions element of the DBPROP
		/// structure was DBPROPOPTIONS_REQUIRED or an invalid value ? could not be set. The consumer checks dwStatus in the DBPROP
		/// structures to determine which properties were not set. The method can fail to set properties for any of the reasons specified in DB_S_ERRORSOCCURRED.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_E_NOCOLUMN The column specified in *pColumnID does not exist in the specified table.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_E_NOTABLE The specified table does not exist in the data store.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_E_NOTSUPPORTED dwColumnDescFlags was an invalid value. Providers return valid values in the property DBPROP_ALTERCOLUMN.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_E_TABLEINUSE The specified table was in use, and the provider could not alter the column while the table was open.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_SEC_E_PERMISSIONDENIED The consumer did not have sufficient permission to alter the columns of this table.</para>
		/// </description>
		/// </item>
		/// </list>
		/// </returns>
		// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/ms711636(v=vs.85) HRESULT AlterColumn( DBID *pTableID, DBID
		// *pColumnID, DBCOLUMNDESCFLAGS dwColumnDescFlags, DBCOLUMNDESC *pColumnDesc);
		[PreserveSig]
		HRESULT AlterColumn(in DBID pTableId, in DBID pColumnId, DBCOLUMNDESCFLAGS dwColumnDescFlags, in DBCOLUMNDESC pColumnDesc);

		/// <summary>Alters the ID and/or properties associated with a table.</summary>
		/// <param name="pTableId">[in] The DBID of the base table to alter.</param>
		/// <param name="pNewTableId">
		/// [in] The new DBID of the base table. If this is the same as pTableID or is a null pointer, the ID of the table is unchanged.
		/// </param>
		/// <param name="cPropertySets">
		/// [in] The number of DBPROPSET structures in rgPropertySets. If this is zero, the provider ignores rgPropertySets.
		/// </param>
		/// <param name="rgPropertySets">
		/// [in/out] An array of DBPROPSET structures containing properties and values to be set. The properties specified in these
		/// structures must belong to the table property set.
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
		/// DB_S_ERRORSOCCURRED The table was altered, but one or more properties ? for which the dwOptions element of the DBPROP structure
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
		/// <para>E_INVALIDARG pTableID was a null pointer.</para>
		/// <para>cPropertySets was not zero and rgPropertySets was a null pointer.</para>
		/// <para>In an element of rgPropertySets, cProperties was not zero and rgProperties was a null pointer.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_E_ALTERRESTRICTED The provider could not alter the table because it was referenced by a constraint.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_E_BADTABLEID *pNewTableID was an invalid table ID.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_DUPLICATETABLEID The table specified in *pNewTableID already exists in the data store.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// DB_E_ERRORSOCCURRED The table was not altered because one or more properties ? for which the dwOptions element of the DBPROP
		/// structure was DBPROPOPTIONS_REQUIRED or an invalid value ? could not be set. The consumer checks dwStatus in the DBPROP
		/// structures to determine which properties were not set. The method can fail to set properties for any of the reasons specified in DB_S_ERRORSOCCURRED.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_E_NOTABLE The table specified in *pTableID does not exist in the data store.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_E_TABLEINUSE The specified table was in use, and the provider could not alter the table while it was open.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_SEC_E_PERMISSIONDENIED The consumer did not have sufficient permission to alter the table or index.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// XACT_E_XTIONEXISTS The provider supports transactional DDL, the session is participating in a transaction, and the value of
		/// DBPROP_SUPPORTEDTXNDDL is DBPROPVAL_TC_DML.
		/// </para>
		/// </description>
		/// </item>
		/// </list>
		/// </returns>
		// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/ms725407(v=vs.85) HRESULT AlterTable( DBID *pTableID, DBID
		// *pNewTableID, ULONG cPropertySets, DBPROPSET rgPropertySets[]);
		[PreserveSig]
		HRESULT AlterTable(in DBID pTableId, in DBID pNewTableId, uint cPropertySets, [In, Out] SafeDBPROPSETListHandle rgPropertySets);
	}

	/// <summary>
	/// <para>
	/// <c>IBindResource</c> binds to an object named by a URL and returns a data source, session, rowset, row, command, or stream object.
	/// </para>
	/// <para>
	/// <para>Note</para>
	/// <para>The term "resource" in the name of this interface refers to the use of URLs to name OLE DB objects.</para>
	/// </para>
	/// </summary>
	// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/ms714936(v=vs.85)
	[PInvokeData("oledb.h")]
	[ComImport, Guid("0c733ab1-2a1c-11ce-ade5-00aa0044773d"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IBindResource
	{
		/// <summary>
		/// Binds to an object named by a URL. When implemented on a row object, binds to a tree-structured namespace, such as a file system
		/// directory, named by the URL. Returns a data source, session, rowset, row, command, or stream object.
		/// </summary>
		/// <param name="pUnkOuter">
		/// <para>
		/// [in] If the returned object is to be aggregated, pUnkOuter is an interface pointer to the controlling <c>IUnknown</c>. Otherwise,
		/// it is a null pointer.
		/// </para>
		/// <para>
		/// <para>Note</para>
		/// <para>
		/// When <c>IBindResource</c> is implemented on an object other than a binder and <c>Bind</c> is requesting a data source or session
		/// object, pUnkOuter must be a null pointer because the data source and session objects have already been created.
		/// </para>
		/// </para>
		/// </param>
		/// <param name="pwszURL">[in] The canonical URL of the object for which an OLE DB object is to be returned.</param>
		/// <param name="dwBindURLFlags">
		/// <para>[in] Bitmask of bind flags that control how the OLE DB object is opened.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Flag</description>
		/// <description>Meaning</description>
		/// </listheader>
		/// <item>
		/// <description>DBBINDURLFLAG_READ</description>
		/// <description>Open object for reading only.</description>
		/// </item>
		/// <item>
		/// <description>DBBINDURLFLAG_WRITE</description>
		/// <description>Open object for writing only. See note above for DBBINDURLFLAG_READ.</description>
		/// </item>
		/// <item>
		/// <description>DBBINDURLFLAG_READWRITE</description>
		/// <description>Open object for reading and writing. See note above for DBBINDURLFLAG_READ.</description>
		/// </item>
		/// <item>
		/// <description>DBBINDURLFLAG_SHARE_DENY_READ</description>
		/// <description>Deny others read access.</description>
		/// </item>
		/// <item>
		/// <description>DBBINDURLFLAG_SHARE_DENY_WRITE</description>
		/// <description>
		/// Deny others write access. See the notes for SHARE_DENY_READ for information about the behavior of providers that do not support
		/// this type of DENY semantics.
		/// </description>
		/// </item>
		/// <item>
		/// <description>DBBINDURLFLAG_SHARE_EXCLUSIVE</description>
		/// <description>
		/// Deny others read and write access. See the notes for SHARE_DENY_READ for information about the behavior of providers that do not
		/// support this type of DENY semantics.
		/// </description>
		/// </item>
		/// <item>
		/// <description>DBBINDURLFLAG_SHARE_DENY_NONE</description>
		/// <description>Do not deny others read or write access (equivalent to the omission of SHARE_DENY_READ and SHARE_DENY_WRITE).</description>
		/// </item>
		/// <item>
		/// <description>DBBINDURLFLAG_RECURSIVE</description>
		/// <description>
		/// Modifies DBBINDURLFLAG_SHARE_*. Propagate sharing restrictions to all objects in the subtree. Has no effect when binding to leaf
		/// nodes. Specifying this flag with only DBBINDURLFLAG_SHARE_DENY_NONE (or equivalently, with no SHARE_DENY flags) will result in E_INVALIDARG.
		/// </description>
		/// </item>
		/// <item>
		/// <description>DBBINDURLFLAG_OUTPUT</description>
		/// <description>
		/// Bind to the resource's executed output rather than its source. For example, this will retrieve the HTML generated by an ASP file
		/// rather than its source. This flag is ignored on binds to collections.
		/// </description>
		/// </item>
		/// <item>
		/// <description>DBBINDURLFLAG_ASYNCHRONOUS</description>
		/// <description>
		/// Return immediately and perform the binding on a separate thread. If DBBINDURLFLAG_WAITFORINIT is not specified, this flag affects
		/// the behavior of the <c>IBindResource::Bind</c> or <c>ICreateRow::CreateRow</c> call. If DBBINDURLFLAG_WAITFORINIT is specified,
		/// this flag affects the behavior of the <c>IDBInitialize::Initialize</c> call. For more information, see the "Comments" section below.
		/// </description>
		/// </item>
		/// <item>
		/// <description>DBBINDURLFLAG_WAITFORINIT</description>
		/// <description>
		/// Return an interface supported on an uninitialized object, but do not initiate the bind. Used in the following cases: The consumer
		/// may ask only for interfaces supported on uninitialized objects. The provider returns E_NOINTERFACE if any other interface is requested.
		/// </description>
		/// </item>
		/// <item>
		/// <description>DBBINDURLFLAG_DELAYFETCHSTREAM</description>
		/// <description>
		/// On a bind to a row, overrides the consumer's intent to immediately open the default stream. Absence of this flag is a hint to the
		/// provider to instantiate the default stream object and prefetch its contents.
		/// </description>
		/// </item>
		/// <item>
		/// <description>DBBINDURLFLAG_DELAYFETCHCOLUMNS</description>
		/// <description>
		/// On a bind to a row, this flag overrides the consumer's intent to immediately access the row's columns. Absence of this flag is a
		/// hint to the provider to download or prefetch the row's columns.
		/// </description>
		/// </item>
		/// </list>
		/// <para>
		/// Most of the options specified by these flags can also be specified by setting DBPROP_INIT_MODE or DBPROP_INIT_BINDFLAGS
		/// initialization properties. (See " <c>IBindResource::Bind</c> Flags and Initialization Property Flags" below.) If any flags are
		/// specified in dwBindURLFlags (that is, dwBindURLFlags does not equal zero), this set of flags overrides any flags that are
		/// specified in DBPROP_INIT_MODE or DBPROP_INIT_BINDFLAGS. If dwBindURLFlags is zero, the flags specified in DBPROP_INIT_MODE and
		/// DBPROP_INIT_BINDFLAGS are used instead.
		/// </para>
		/// <para>
		/// If dwBindURLFlags is zero and DBPROP_INIT_MODE is not explicitly set on the bind, the provider returns E_INVALIDARG because one
		/// of DBBINDURLFLAG_READ or DBBINDURLFLAG_WRITE was not set. If dwBindURLFlags is zero and DBPROP_INIT_BINDFLAGS is not explicitly
		/// set, DBPROP_INIT_BINDFLAGS defaults to zero (no options set).
		/// </para>
		/// <para>
		/// <para>Note</para>
		/// <para>
		/// The sets of flags that can be specified in DBPROP_INIT_MODE and DBPROP_INIT_BINDFLAGS are deliberately disjoint so that flags
		/// from both sets can be used in the same call to <c>IBindResource::Bind</c>. Nevertheless, the division of flags between the two
		/// properties specified below in " <c>IBindResource::Bind</c> Flags and Initialization Property Flags" must be honored. If the
		/// client specifies flags from DBPROP_INIT_MODE in the DBPROP_INIT_BINDFLAGS property, or vice versa, they will be ignored.
		/// </para>
		/// </para>
		/// <para>
		/// Not all bind flags may be used with all object types (as specified in the rguid parameter). The following table describes the
		/// restrictions. If a client does not adhere to these restrictions, the bind will fail with E_INVALIDARG.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <description>Object type</description>
		/// <description>Restrictions</description>
		/// </listheader>
		/// <item>
		/// <description>DBGUID_DSO</description>
		/// <description>Only the following flags may be used:</description>
		/// </item>
		/// <item>
		/// <description>DBGUID_SESSION</description>
		/// <description>Only the following flag may be used:</description>
		/// </item>
		/// <item>
		/// <description>DBGUID_COMMAND</description>
		/// <description>Only the following flags may be used:</description>
		/// </item>
		/// <item>
		/// <description>DBGUID_ROW</description>
		/// <description>No restrictions. All flags are allowed.</description>
		/// </item>
		/// <item>
		/// <description>DBGUID_ROWSET</description>
		/// <description>The following flags are disallowed: A consumer may bind to a rowset object, but the behavior is provider-specific.</description>
		/// </item>
		/// <item>
		/// <description>DBGUID_STREAM</description>
		/// <description>The following flags are disallowed:</description>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="rguid">
		/// <para>[in] A pointer to a GUID indicating the type of OLE DB object to be returned. The GUID must be one of the following values:</para>
		/// <list type="bullet">
		/// <item>
		/// <description>
		/// <para>DBGUID_DSO</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DBGUID_SESSION</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DBGUID_COMMAND</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DBGUID_ROW</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DBGUID_ROWSET</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DBGUID_STREAM</para>
		/// </description>
		/// </item>
		/// </list>
		/// <para>
		/// <para>Note</para>
		/// <para>When implemented on a row object, the GUID must be set to one of the following values:</para>
		/// <para>DBGUID_ROW</para>
		/// <para>DBGUID_ROWSET (can be requested only if the row represents a collection)</para>
		/// <para>DBGUID_STREAM</para>
		/// </para>
		/// </param>
		/// <param name="riid">[in] Interface ID of the interface pointer to be returned.</param>
		/// <param name="pAuthenticate">
		/// [in] Optional pointer to the caller's <c>IAuthenticate</c> interface. If supplied, it is provider-specific whether the
		/// <c>IAuthenticate</c> credentials are used before or after anonymous or default login credentials are used.
		/// </param>
		/// <param name="pImplSession">
		/// <para>
		/// [in/out] A pointer to a DBIMPLICITSESSION structure used to request and return aggregation information for the implicit session
		/// object. If the bind fails and pImplSession is not a null pointer, pImplSession-&gt;pSession should be set to NULL. The
		/// DBIMPLICITSESSION structure is defined as follows:
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <description>Element</description>
		/// <description>Description</description>
		/// </listheader>
		/// <item>
		/// <description><c>pUnkOuter</c></description>
		/// <description>
		/// If the implicit session object is to be aggregated, <c>pUnkOuter</c> is an interface pointer to the controlling <c>IUnknown</c>.
		/// Otherwise, it is a null pointer.
		/// </description>
		/// </item>
		/// <item>
		/// <description><c>piid</c></description>
		/// <description>
		/// A pointer to the IID of the interface (on the implicit session) on which to return a pointer. Cannot be NULL. If <c>pUnkOuter</c>
		/// is not a null pointer, this IID must be IID_IUnknown.
		/// </description>
		/// </item>
		/// <item>
		/// <description><c>pSession</c></description>
		/// <description>
		/// An interface pointer to the implicit session object returned by the provider. If the session object is aggregated, this is a
		/// pointer to the <c>IUnknown</c> interface of the inner object.
		/// </description>
		/// </item>
		/// </list>
		/// <para>
		/// <para>Note</para>
		/// <para>
		/// <c>IBindResource::Bind</c> uses pImplSession only when implemented on a binder object and binding to a row, rowset, or stream
		/// object (rguid is DBGUID_ROW, DBGUID_ROWSET, or DBGUID_STREAM). When binding to a data source or session object (rguid is
		/// DBGUID_DSO or DBGUID_SESSION), the provider ignores pImplSession because no recursive backing session is created. If implemented
		/// on any other object (for example, a session or row object), the provider ignores pImplSession because the existing object already
		/// has a session context.
		/// </para>
		/// </para>
		/// </param>
		/// <param name="pdwBindStatus">
		/// <para>
		/// [out] A pointer to memory in which to return a bitmask containing warning status values for the requested bind flags. If
		/// pdwBindStatus is a null pointer, no status values are returned. If <c>IBindResource::Bind</c> returns a result other than
		/// DB_S_ERRORSOCCURRED and pdwBindStatus is not a null pointer, the provider returns DBBINDURLSTATUS_S_OK. The values described in
		/// the following table may be returned.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <description>Status value</description>
		/// <description>Description</description>
		/// </listheader>
		/// <item>
		/// <description>DBBINDURLSTATUS_S_ DENYNOTSUPPORTED</description>
		/// <description>
		/// The bind succeeded, but the provider does not support any DENY semantics. No lock was obtained. If the consumer requires the
		/// lock, it should release the object and report that a lock could not be obtained.
		/// </description>
		/// </item>
		/// <item>
		/// <description>DBBINDURLSTATUS_S_ DENYTYPENOTSUPPORTED</description>
		/// <description>
		/// The bind succeeded, but the provider does not support the requested kind of DENY semantics. For example, the provider may support
		/// only DENY_WRITE or DENY_EXCLUSIVE. No lock was obtained. If the consumer requires the lock type, it should release the object and
		/// report that the type of lock could not be obtained.
		/// </description>
		/// </item>
		/// <item>
		/// <description>DBBINDURLSTATUS_S_REDIRECTED</description>
		/// <description>
		/// The bind was successful, but the server for the object indicated that its URL has changed. The client should query the
		/// RESOURCE_ABSOLUTEPARSENAME column on the returned object to determine the new URL. This column is available on the resource
		/// rowset, so this status should be used only by document source providers. (DBPROP_DATASOURCE_TYPE is DBPROPVAL_DST_DOCSOURCE.)
		/// </description>
		/// </item>
		/// <item>
		/// <description>DBBINDURLSTATUS_S_OK</description>
		/// <description>
		/// The bind was successful and the status is reported as OK, because the provider returned a result other than DB_S_ERRORSOCCURRED
		/// and <c>pdwBindStatus</c> was not a null pointer.
		/// </description>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="ppUnk">
		/// [out] A pointer to memory in which to return an interface pointer on the requested object. If <c>IBindResource::Bind</c> fails,
		/// *ppUnk is set to a null pointer.
		/// </param>
		/// <returns>
		/// <list type="bullet">
		/// <item>
		/// <description>
		/// <para>S_OK The bind succeeded.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// DB_S_ASYNCHRONOUS The call to <c>IBindResource::Bind</c> has initiated asynchronous binding to the data source, rowset, or row.
		/// The consumer can call <c>IDBAsynchStatus::GetStatus</c> to poll for status or can register for notifications of asynchronous
		/// processing. Until asynchronous processing completes, the data source, rowset, row, or stream object remains in an uninitialized state.
		/// </para>
		/// <para>DB_S_ASYNCHRONOUS should be returned before DB_S_ERRORSOCCURRED.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// DB_S_ERRORSOCCURRED The bind succeeded, but some bind flags or properties were not satisfied. The consumer should examine the
		/// bind status reported in *pdwBindStatus.
		/// </para>
		/// <para>
		/// DB_S_ASYNCHRONOUS should be returned before DB_S_ERRORSOCCURRED. Once rowset population is complete, the consumer can see
		/// DB_S_ERRORSOCCURRED either by calling <c>IDBAsynchStatus::GetStatus</c> or by receiving <c>IDBAsynchNotify::OnStop</c>.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_E_ASYNCNOTSUPPORTED The provider does not support asynchronous binding.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_E_CANNOTCONNECT The provider could not connect to the server for this object.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_E_NOAGGREGATION pUnkOuter was not a null pointer, and the object being created does not support aggregation.</para>
		/// <para>pUnkOuter was not a null pointer, and riid was not IID_IUnknown.</para>
		/// <para>
		/// pImplSession was not a null pointer, pImplSession-&gt;pUnkOuter was not a null pointer, and pImplSession-&gt;piid did not point
		/// to IID_IUnknown.
		/// </para>
		/// <para>
		/// pImplSession was not a null pointer, pImplSession-&gt;pUnkOuter was not a null pointer, and the object being created does not
		/// support aggregation.
		/// </para>
		/// <para>
		/// <c>IBindResource</c> was implemented on an object other than a binder, rguid was DBGUID_DSO or DBGUID_SESSION, and pUnkOuter was
		/// not a null pointer.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// DB_E_NOTCOLLECTION The client requested an object type that is valid only for a collection (such as a rowset), but the resource
		/// at the specified URL is not a collection.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_E_NOTFOUND The provider was unable to locate an object named by the specified URL.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// DB_E_NOTSUPPORTED The provider supports direct binding to OLE DB objects but does not support the object type requested in rguid.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_E_OBJECTMISMATCH The object named by rguid does not represent the resource named by pwszURL.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// DB_E_OBJECTOPEN The provider would have to open a new connection to support this operation, and DBPROP_MULTIPLECONNECTIONS is set
		/// to VARIANT_FALSE.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_E_READONLY The caller requested write access to a read-only object.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// DB_E_RESOURCELOCKED One or more other processes using the DBBINDURLFLAG_SHARE_* flag have locked the OLE DB object represented by
		/// this URL. If a provider supports extended error information, <c>IErrorInfo::GetDescription</c> returns a string consisting of
		/// user names separated by semicolons. These are the names of the users who have the object locked.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// DB_E_RESOURCEOUTOFSCOPE <c>IBindResource</c> is implemented on a session object, and the caller tried to bind to a URL that is
		/// not within the scope of this session.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_E_TIMEOUT The attempt to bind to the object timed out.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_SEC_E_PERMISSIONDENIED The caller's authentication context does not permit access to the object.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_SEC_E_SAFEMODE_DENIED The provider was called within a safe mode or context, and pwszURL specified an unsafe URL.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>REGDB_E_CLASSNOTREG The root binder was unable to instantiate the provider binder.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>E_FAIL A provider-specific error occurred.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>E_INVALIDARG pwszURL or ppUnk was null.</para>
		/// <para>pImplSession was not a null pointer, and pImplSession-&gt;piid was null.</para>
		/// <para>
		/// dwBindURLFlags contained a flag labeled "Modifies DBBINDURLFLAG_*" in the table above but did not contain the flag to be modified.
		/// </para>
		/// <para>The provider does not support one or more values of dwBindURLFlags.</para>
		/// <para>
		/// One of more of the bind flags in dwBindURLFlags are either not supported by the provider or disallowed for the object type
		/// denoted by rguid. For flags allowed for each object type, see the table in the reference entry for <c>IBindResource::Bind</c>.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>E_NOINTERFACE The object did not support the interface specified in riid, or riid was IID_NULL.</para>
		/// <para>The provider binder did not implement <c>IBindResource</c>.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// E_UNEXPECTED <c>IBindResource::Bind</c> is implemented on a row object; <c>ITransaction::Commit</c> or <c>ITransaction::Abort</c>
		/// was called; and the object is in a zombie state.
		/// </para>
		/// </description>
		/// </item>
		/// </list>
		/// </returns>
		// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/ms721010(v=vs.85)
		[PreserveSig]
		HRESULT Bind([In, Optional, MarshalAs(UnmanagedType.IUnknown)] object? pUnkOuter, [In, MarshalAs(UnmanagedType.LPWStr)] string pwszURL, DBBINDURLFLAG dwBindURLFlags,
			in Guid rguid, in Guid riid, [In, Optional, MarshalAs(UnmanagedType.IUnknown)] object? pAuthenticate, [In, Out, Optional] IntPtr pImplSession,
			out DBBINDURLSTATUS pdwBindStatus, [MarshalAs(UnmanagedType.IUnknown)] out object? ppUnk);
	}

	/// <summary><c>IChapteredRowset</c> is the interface that allows consumers to manage chapters.</summary>
	// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/ms718180(v=vs.85)
	[PInvokeData("oledb.h")]
	[ComImport, Guid("0c733a93-2a1c-11ce-ade5-00aa0044773d"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IChapteredRowset
	{
		/// <summary>Adds a reference count to an existing chapter.</summary>
		/// <param name="hChapter">[in] The handle of the chapter for which to increment the reference count.</param>
		/// <param name="pcRefCount">
		/// [out] A pointer to memory in which to return the reference count of the chapter handle. If pcRefCount is a null pointer, no
		/// reference count is returned.
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
		/// <para>DB_E_BADCHAPTER hChapter was invalid.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>E_UNEXPECTED <c>ITransaction::Commit</c> or <c>ITransaction::Abort</c> was called, and the object is in a zombie state.</para>
		/// </description>
		/// </item>
		/// </list>
		/// </returns>
		// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/ms719762(v=vs.85) HRESULT AddRefChapter ( HCHAPTER hChapter,
		// DBREFCOUNT *pcRefCount);
		[PreserveSig]
		HRESULT AddRefChapter(HCHAPTER hChapter, out DBREFCOUNT pcRefCount);

		/// <summary>Releases a chapter.</summary>
		/// <param name="hChapter">[in] The chapter handle.</param>
		/// <param name="pcRefCount">
		/// [out] A pointer to memory in which to return the reference count of the chapter handle. If pcRefCount is a null pointer, no
		/// reference count is returned.
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
		/// <para>E_INVALIDARG The rowset was not chaptered.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_E_BADCHAPTER hChapter was invalid.</para>
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
		// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/ms715966(v=vs.85) HRESULT ReleaseChapter ( HCHAPTER hChapter,
		// DBREFCOUNT *pcRefCount);
		[PreserveSig]
		HRESULT ReleaseChapter(HCHAPTER hChapter, out DBREFCOUNT pcRefCount);
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
		// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/ms722704(v=vs.85) HRESULT GetColumnInfo ( DBORDINAL
		// *pcColumns, DBCOLUMNINFO **prgInfo, OLECHAR **ppStringsBuffer);
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
		// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/ms722704(v=vs.85) HRESULT GetColumnInfo ( DBORDINAL
		// *pcColumns, DBCOLUMNINFO **prgInfo, OLECHAR **ppStringsBuffer);
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
	/// This interface supplies complete information about columns in a rowset. The methods in it can be called from a rowset or a command.
	/// </summary>
	// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/ms722657(v=vs.85)
	[PInvokeData("oledb.h")]
	[ComImport, Guid("0c733a10-2a1c-11ce-ade5-00aa0044773d"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IColumnsRowset
	{
		/// <summary>Returns a list of optional metadata columns that can be supplied in a column metadata rowset.</summary>
		/// <param name="pcOptColumns">
		/// [out] A pointer to memory in which to return the count of the elements in *prgOptColumns. If an error occurs, *pcOptColumns is
		/// set to zero.
		/// </param>
		/// <param name="prgOptColumns">
		/// [out] A pointer to memory in which to return an array of the optional columns this provider can supply. In addition to the
		/// optional columns listed in <c>IColumnsRowset::GetColumnsRowset</c>, the provider can return provider-specific columns. The rowset
		/// or command allocates memory for the structures and returns the address to this memory; the consumer releases this memory with
		/// <c>IMalloc::Free</c> when it no longer needs the list of columns. If *pcOptColumns is zero on output or an error occurs, the
		/// provider does not allocate any memory and ensures that *prgOptColumns is a null pointer on output.
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
		/// <para>E_INVALIDARG pcOptColumns or prgOptColumns was a null pointer.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>E_OUTOFMEMORY The provider was unable to allocate sufficient memory in which to return the column IDs.</para>
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
		/// <para>DB_E_NOCOMMAND No command text was set. This error can be returned only when this method is called from the command object.</para>
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
		/// <para>DB_SEC_E_PERMISSIONDENIED The consumer did not have sufficient permission to retrieve the available optional metadata columns.</para>
		/// </description>
		/// </item>
		/// </list>
		/// </returns>
		// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/ms718245(v=vs.85) HRESULT GetAvailableColumns ( DBORDINAL
		// *pcOptColumns, DBID **prgOptColumns);
		[PreserveSig]
		HRESULT GetAvailableColumns(out DBORDINAL pcOptColumns, out SafeIMallocHandle prgOptColumns);

		/// <summary>
		/// Returns a rowset containing metadata about each column in the current rowset. This rowset is known as the column metadata rowset
		/// and is read-only.
		/// </summary>
		/// <param name="pUnkOuter">
		/// [in] A pointer to the controlling <c>IUnknown</c> interface if the column metadata rowset is being created as part of an
		/// aggregate. It is a null pointer if the rowset is not part of an aggregate.
		/// </param>
		/// <param name="cOptColumns">
		/// [in] The number of the elements in rgOptColumns. If cOptColumns is zero, rgOptColumns is ignored and the provider returns all
		/// available columns in the columns rowset.
		/// </param>
		/// <param name="rgOptColumns">
		/// [in] An array that specifies the optional columns to return. In addition to the optional columns listed below, the consumer can
		/// request provider-specific columns.
		/// </param>
		/// <param name="riid">
		/// [in] The IID of the requested rowset interface. This interface is conceptually added to the list of required interfaces on the
		/// resulting rowset, and the method fails (E_NOINTERFACE) if that interface cannot be supported on the resulting rowset.
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
		/// C. For information about the DBPROPSET and DBPROP structures, see DBPROPSET Structure and DBPROP Structure.
		/// </para>
		/// </param>
		/// <param name="ppColRowset">
		/// [out] A pointer to memory in which to return the requested interface pointer on the column metadata rowset. If an error occurs,
		/// the returned pointer is null. If <c>IColumnsRowset::GetColumnsRowset</c> is called on a command that does not return rows, the
		/// column metadata rowset will be empty.
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
		/// any other interfaces may fail, and the full set of interfaces may not be available on the object until asynchronous
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
		/// were not set. The method can fail to set properties for a number of reasons, including:
		/// </para>
		/// <para>
		/// DB_S_ASYNCHRONOUS should be returned before DB_S_ERRORSOCCURRED. Once rowset population is complete, the consumer can see
		/// DB_S_ERRORSOCCURRED either by calling IDBAsynchStatus::GetStatus or by receiving IDBAsynchNotify::OnStop. Of course, the
		/// properties-in-error are not available, but for any properties that could not be set, the provider should report that status in
		/// the property array passed to <c>IColumnsRowset::GetColumnsRowset</c>.Thisassumes that property failures can all be determined
		/// ahead of rowset population.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// DB_S_NOTSINGLETON The provider supports returning row objects on <c>IColumnsRowset::GetColumnsRowset</c>, and the consumer
		/// requested a row object but the result was not a singleton. A row object of the first row of the rowset is returned if the
		/// provider supports returning the row object. Because returning this result may be expensive, providers are not required to do so.
		/// If DB_S_ERRORSOCCURRED also applies to the execution of this method, it takes precedence over DB_S_NOTSINGLETON.
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
		/// <para>E_INVALIDARG ppColRowset was a null pointer.</para>
		/// <para>cPropertySets was greater than zero, and rgPropertySets was a null pointer.</para>
		/// <para>In an element of rgPropertySets, cProperties was not zero and rgProperties was a null pointer.</para>
		/// <para>cOptColumns was greater than zero, and rgOptColumns was a null pointer.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>E_NOINTERFACE The column metadata rowset did not support the interface specified in riid.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// E_UNEXPECTED ITransaction::Commit or ITransaction::Abort was called, and the object is in a zombie state. This error can be
		/// returned only when the method is called on a rowset.
		/// </para>
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
		/// <para>DB_E_BADCOLUMNID An element of rgOptColumns was an invalid DBID.</para>
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
		/// <para>DB_E_NOCOMMAND No command text was set. This error can be returned only when this method is called from the command object.</para>
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
		/// DB_E_NOTPREPARED The command exposed ICommandPrepare, and the command text was set but the command was not prepared. This error
		/// can be returned only when this method is called from the command object.
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
		/// <para>DB_SEC_E_PERMISSIONDENIED The consumer did not have sufficient permission to create the column metadata rowset.</para>
		/// </description>
		/// </item>
		/// </list>
		/// </returns>
		// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/ms712925(v=vs.85) HRESULT GetColumnsRowset ( IUnknown
		// *pUnkOuter, DBORDINAL cOptColumns, const DBID rgOptColumns[], REFIID riid, ULONG cPropertySets, DBPROPSET rgPropertySets[],
		// IUnknown **ppColRowset);
		[PreserveSig]
		HRESULT GetColumnsRowset([In, Optional, MarshalAs(UnmanagedType.IUnknown)] object? pUnkOuter, DBORDINAL cOptColumns,
			[In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] DBID[] rgOptColumns, in Guid riid, uint cPropertySets,
			[In, Out] SafeDBPROPSETListHandle rgPropertySets, [MarshalAs(UnmanagedType.IUnknown)] out object? ppColRowset);
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
	/// Command objects support <c>ICommandPersist</c> for persisting the state of a command object. Persisting a command object does not
	/// persist any active rowsets that may have resulted from the execution of the command object, nor does it persist accessors, property
	/// settings, or parameter information associated with the command object.
	/// </para>
	/// <para>
	/// Persisted commands can be enumerated through the PROCEDURES rowset. Persisted commands that can act as the source of a new command
	/// (that is, a table in an SQL <c>FROM</c> clause) can be enumerated through the VIEWS rowset.
	/// </para>
	/// </summary>
	// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/ms722664(v=vs.85)
	[PInvokeData("oledb.h")]
	[ComImport, Guid("0c733aa7-2a1c-11ce-ade5-00aa0044773d"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ICommandPersist
	{
		/// <summary>Deletes a persisted command definition.</summary>
		/// <param name="pCommandID">[in] The DBID of the command to be deleted.</param>
		/// <returns>
		/// <list type="bullet">
		/// <item>
		/// <description>
		/// <para>S_OK The command was successfully deleted.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_E_BADCOMMANDID The command specified in *pCommandID does not exist.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// DB_E_OBJECTOPEN An attempt was made to delete a command(view) used to create one or more open rowsets. The provider determines if
		/// the DeleteCommand succeeds.
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
		/// <para>E_INVALIDARG pCommandID was a null pointer.</para>
		/// </description>
		/// </item>
		/// </list>
		/// </returns>
		// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/ms723766(v=vs.85) HRESULT DeleteCommand( DBID *pCommandID);
		[PreserveSig]
		HRESULT DeleteCommand(in DBID pCommandID);

		/// <summary>Returns the DBID of the current command.</summary>
		/// <param name="ppCommandID">[out] A pointer to memory in which to return the pointer to the DBID of the current command.</param>
		/// <returns>
		/// <list type="bullet">
		/// <item>
		/// <description>
		/// <para>S_OK The DBID of the command was successfully returned.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>E_OUTOFMEMORY There is not enough memory to successfully return the command's DBID.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_E_COMMANDNOTPERSISTED The current command does not yet have a DBID.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>E_FAIL A provider-specific error occurred.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>E_INVALIDARG ppCommandID was a null pointer.</para>
		/// </description>
		/// </item>
		/// </list>
		/// </returns>
		// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/ms716792(v=vs.85) HRESULT GetCurrentCommand( DBID **ppCommandID);
		[PreserveSig]
		HRESULT GetCurrentCommand(out IntPtr ppCommandID);

		/// <summary>Loads a persisted command definition.</summary>
		/// <param name="pCommandID">[in] The DBID of the command to load.</param>
		/// <param name="dwFlags">[in] Reserved for future use. Consumers should set this value to zero. Providers should ignore this argument.</param>
		/// <returns>
		/// <list type="bullet">
		/// <item>
		/// <description>
		/// <para>S_OK The command was successfully loaded.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>E_OUTOFMEMORY There is not enough memory to successfully load the command.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_E_OBJECTOPEN A rowset was open on the command.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_E_BADCOMMANDID The command specified in *pCommandID does not exist.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>E_FAIL A provider-specific error occurred.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>E_INVALIDARG pCommandID was a null pointer, or dwFlags was not zero.</para>
		/// </description>
		/// </item>
		/// </list>
		/// </returns>
		// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/ms714946(v=vs.85) HRESULT LoadCommand( DBID *pCommandID, DWORD dwFlags);
		[PreserveSig]
		HRESULT LoadCommand(in DBID pCommandID, uint dwFlags = 0);

		/// <summary>Persists the current command definition.</summary>
		/// <param name="pCommandID">
		/// [in] The DBID to assign to the persisted command. If this is a null pointer and the command already has a DBID, the provider
		/// saves the current version with the same DBID. If this is a null pointer and the command does not already have a DBID, the
		/// provider assigns an ID to the command. The ID must be unique.
		/// </param>
		/// <param name="dwFlags">
		/// <para>[in] Options for persisting command definition. The following flags are possible:</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Flag</description>
		/// <description>Description</description>
		/// </listheader>
		/// <item>
		/// <description>DBCOMMANDPERSISTFLAG_NOSAVE</description>
		/// <description>
		/// You can use DBCOMMANDPERSISTFLAG_NOSAVE to associate or obtain a new DBID for the command without actually persisting the definition.
		/// </description>
		/// </item>
		/// <item>
		/// <description>DBCOMMANDPERSISTFLAG_PERSISTVIEW</description>
		/// <description>
		/// The command is to be persisted as a view. Views are row-returning objects that do not contain parameters or return values and can
		/// generally be used anywhere a base table is used. Views can be enumerated through the DBSCHEMA_VIEWS schema rowset.
		/// </description>
		/// </item>
		/// <item>
		/// <description>DBCOMMANDPERSISTFLAG_PERSISTPROCEDURE</description>
		/// <description>
		/// The command is to be persisted as a procedure. Procedures may or may not return rows and may or may not contain parameters or
		/// return values. Procedures can be enumerated through the DBSCHEMA_PROCEDURES schema rowset.
		/// </description>
		/// </item>
		/// <item>
		/// <description>DBCOMMANDPERSISTFLAG_DEFAULT</description>
		/// <description>The behavior of DBCOMMANDPERSISTFLAGS_DEFAULT is provider specific.</description>
		/// </item>
		/// </list>
		/// <para>
		/// DBCOMMANDPERSISTFLAG_PERSISTVIEW and DBCOMMANDPERSISTFLAG_PERSISTPROCEDURE are mutually exclusive. If neither is specified, the
		/// provider persists the command as a default type.
		/// </para>
		/// </param>
		/// <returns>
		/// <list type="bullet">
		/// <item>
		/// <description>
		/// <para>S_OK The command was successfully saved.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_E_BADCOMMANDID The DBID specified in *pCommandID was invalid.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_E_BADCOMMANDFLAGS dwFlags was invalid.</para>
		/// <para>In dwFlags, both DBCOMMANDPERSISTFLAG_PERSISTVIEW and DBCOMMANDPERSISTFLAG_PERSISTPROCEDURE were specified.</para>
		/// <para>DBCOMMANDPERSISTFLAG_PERSISTVIEW was specified, and the command could not be persisted as a view.</para>
		/// <para>DBCOMMANDPERSISTFLAG_PERSISTPROCEDURE was specified, and the command could not be persisted as a procedure.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// DB_E_DUPLICATEID The specified DBID already exists. If the provider supports the use of persisted commands as a source in a new
		/// command definition, DBIDs must be unique across persisted commands, procedures, tables, and views.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_E_ERRORSINCOMMAND An invalid command has been set using ICommandText::SetCommandText().</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_E_NOCOMMAND SaveCommand() called without setting the command text.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>E_FAIL A provider-specific error occurred.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>E_INVALIDARG Should never be returned by ICommandPersist::SaveCommand(). See Comments below.</para>
		/// </description>
		/// </item>
		/// </list>
		/// </returns>
		// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/ms712917(v=vs.85) HRESULT SaveCommand( DBID *pCommandID, DWORD dwFlags);
		[PreserveSig]
		HRESULT SaveCommand(in DBID pCommandID, DBCOMMANDPERSISTFLAG dwFlags);
	}

	/// <summary>
	/// <para>
	/// This optional interface encapsulates command optimization, a separation of compile time and run time, as found in traditional
	/// relational database systems. The result of this optimization is a command execution plan.
	/// </para>
	/// <para>
	/// If the provider supports command preparation, by supporting this interface, commands must be in a prepared state prior to calling the
	/// following methods:
	/// </para>
	/// </summary>
	// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/ms713621(v=vs.85)
	[PInvokeData("oledb.h")]
	[ComImport, Guid("0c733a26-2a1c-11ce-ade5-00aa0044773d"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ICommandPrepare
	{
		/// <summary>Validates and optimizes the current command.</summary>
		/// <param name="cExpectedRuns">
		/// [in] Using this parameter, the consumer can indicate how often the command execution plan, which is produced by
		/// ICommandPrepare::Prepare, will be used ? that is, how often the command is likely to be executed without renewed optimization.
		/// This guides the optimizer in determining trade-offs between search effort and run-time processing effort. A value of zero
		/// indicates that the consumer is unable to provide an estimate and leaves it to the optimizer to choose a default value.
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
		/// DB_S_ERRORSOCCURRED The command was prepared but one or more properties ? for which the dwOptions element of the DBPROP structure
		/// was DBPROPOPTIONS_OPTIONAL ? were not set. The consumer calls <c>ICommandProperties::GetProperties</c> to determine which
		/// properties were set.
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
		/// <para>E_OUTOFMEMORY The provider ran out of memory while preparing the command.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// DB_E_ABORTLIMITREACHED Preparation has been aborted because a resource limit has been reached. For example, the preparation timed out.
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
		/// <para>
		/// DB_E_ERRORSOCCURRED The command was not prepared because one or more properties ? for which the dwOptions element of the DBPROP
		/// structure was DBPROPOPTIONS_REQUIRED ? were not set. The consumer calls <c>ICommandProperties::GetProperties</c> to determine
		/// which properties were not set.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_E_NOCOMMAND No command text was currently set on the command object.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_E_NOTABLE The specific table or view does not exist in the data store.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_E_OBJECTOPEN A rowset was open on the command.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_SEC_E_PERMISSIONDENIED The consumer did not have sufficient permission to prepare the command.</para>
		/// </description>
		/// </item>
		/// </list>
		/// </returns>
		// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/ms718370(v=vs.85) HRESULT Prepare ( ULONG cExpectedRuns);
		[PreserveSig]
		HRESULT Prepare(uint cExpectedRuns);

		/// <summary>Discards the current command execution plan.</summary>
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
		/// <para>DB_E_OBJECTOPEN A rowset was open on the command.</para>
		/// </description>
		/// </item>
		/// </list>
		/// </returns>
		// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/ms719635(v=vs.85) HRESULT Unprepare();
		[PreserveSig]
		HRESULT Unprepare();
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
	/// <c>ICommandStream</c>, while similar to ICommandText, passes a command as a stream object rather than as a string.
	/// <c>ICommandStream</c> is not a mandatory interface.
	/// </summary>
	// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/ms724412(v=vs.85)
	[PInvokeData("oledb.h")]
	[ComImport, Guid("0c733abf-2a1c-11ce-ade5-00aa0044773d"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ICommandStream
	{
		/// <summary>Returns the currently set interface pointer of a stream object containing a command.</summary>
		/// <param name="piid">
		/// <para>[out]</para>
		/// <para>A pointer to memory where the provider returns an IID that specifies the type of object referenced by *ppCommandStream.</para>
		/// <para>If piid is a null pointer on input, the provider does not return the IID.</para>
		/// <para>If this method returns an error, *piid is set to IID_NULL.</para>
		/// </param>
		/// <param name="pguidDialect">
		/// <para>[in/out]</para>
		/// <para>
		/// A pointer to memory containing a GUID that specifies the syntax and general rules for parsing the command stream ? that is, the
		/// dialect that will be used by the provider to interpret the statement. This is usually the dialect specified in ICommandStream::SetCommandStream.
		/// </para>
		/// <para>
		/// However, if DBGUID_DEFAULT is specified in <c>SetCommandStream</c>, the provider returns the particular dialect that it will use
		/// to interpret the statement. If the provider must choose between multiple dialects at execution time for a command that has been
		/// set with DBGUID_DEFAULT or if the provider is returning some provider-specific syntax that might be different from the command
		/// set in <c>ICommandStream::SetCommandStream</c>, it returns DBGUID_DEFAULT. Providers can define GUIDs for their own dialects.
		/// </para>
		/// <para>If <c>ICommandStream::GetCommandStream</c> returns an error, *pguidDialect is set to DB_NULLGUID.</para>
		/// <para>If pguidDialect is a null pointer on input, the provider does not return the dialect.</para>
		/// </param>
		/// <param name="ppCommandStream">
		/// <para>[out]</para>
		/// <para>
		/// A pointer to memory where the command stream interface pointer is returned. If <c>ICommandStream::GetCommandStream</c> returns an
		/// error, *ppCommandStream is set to a null pointer.
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
		/// DB_S_DIALECTIGNORED The method succeeded, but the input value of pguidDialect was ignored. The text is returned in the dialect
		/// specified in <c>ICommandStream::SetCommandStream</c> or in a provider-specific dialect. The value returned in *pguidDialect
		/// represents that dialect.
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
		/// <para>E_INVALIDARG ppCommandStream was a null pointer.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>E_OUTOFMEMORY The provider was unable to allocate sufficient memory to return the command stream.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_E_NOCOMMAND No command was currently set on the command object.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_E_CANTTRANSLATE The last command was set using <c>ICommandText::SetCommandText</c>, not <c>ICommandStream::SetCommandStream</c>.</para>
		/// </description>
		/// </item>
		/// </list>
		/// </returns>
		// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/ms724347(v=vs.85) HRESULT GetCommandStream ( IID *piid, GUID
		// *pguidDialect, IUnknown **ppCommandStream);
		[PreserveSig]
		HRESULT GetCommandStream(out Guid piid, [In, Out, Optional] GuidPtr pguidDialect, [MarshalAs(UnmanagedType.IUnknown)] out object? ppCommandStream);

		/// <summary>Sets the interface pointer of a stream object containing a command.</summary>
		/// <param name="riid">
		/// <para>[in]</para>
		/// <para>Specifies the type of stream object representing the command.</para>
		/// </param>
		/// <param name="rguidDialect">
		/// <para>[in]</para>
		/// <para>Specifies the dialect of the command.</para>
		/// <para>If this parameter is set to DBGUID_DEFAULT, the provider uses its default dialect.</para>
		/// </param>
		/// <param name="pCommandStream">
		/// <para>[in]</para>
		/// <para>Pointer to a stream object of a type specified by riid.</para>
		/// <para>
		/// If pCommandStream is a null pointer, the specification of the current command stream object is cleared and the command is put in
		/// an initial state.
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
		/// <para>E_NOINTERFACE One of the following occurred:</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_E_DIALECTNOTSUPPORTED The provider did not support the dialect specified in rguidDialect.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// DB_E_OBJECTOPEN The output stream returned by a previous call to <c>ICommand::Execute</c> is still open. Release that stream
		/// before calling this method.
		/// </para>
		/// </description>
		/// </item>
		/// </list>
		/// </returns>
		// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/ms722625(v=vs.85) HRESULT SetCommandStream ( REFIID riid,
		// REFGUID rguidDialect, IUnknown *pCommandStream);
		[PreserveSig]
		HRESULT SetCommandStream(in Guid riid, in Guid rguidDialect, [In, Optional, MarshalAs(UnmanagedType.IUnknown)] object? pCommandStream);
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
	/// <c>Applies to:</c> SQL Server Azure SQL Database Azure SQL Managed Instance Azure Synapse Analytics Analytics Platform System (PDW)
	/// </para>
	/// <para>Download OLE DB driver</para>
	/// <para>
	/// Improvements in the database engine beginning with SQL Server 2012 (11.x) allow ICommandWithParameters::GetParameterInfo to obtain
	/// more accurate descriptions of the expected results. These more accurate results may differ from the values returned by
	/// CommandWithParameters::GetParameterInfo in previous versions of SQL Server. For more information, see Metadata Discovery.
	/// </para>
	/// <para>
	/// Also beginning in SQL Server 2012 (11.x), when calling ICommandWithParameters::SetParameterInfo, the value passed to the pwszName
	/// parameter must be a valid identifier. For more information, see Database Identifiers.
	/// </para>
	/// </summary>
	// https://learn.microsoft.com/en-us/sql/connect/oledb/ole-db-interfaces/icommandwithparameters?view=sql-server-ver16
	[PInvokeData("oledb.h")]
	[ComImport, Guid("0c733a64-2a1c-11ce-ade5-00aa0044773d"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ICommandWithParameters
	{
		/// <summary>Gets a list of the parameters for the command, the parameter names, and the parameter types.</summary>
		/// <param name="pcParams">
		/// <para>[out]</para>
		/// <para>
		/// A pointer to memory in which to return the number of parameters in the command. If an error occurs, *pcParams is set to zero.
		/// </para>
		/// </param>
		/// <param name="prgParamInfo">
		/// <para>[out]</para>
		/// <para>
		/// A pointer to memory in which to return an array of parameter information structures. The command allocates memory for the array,
		/// as well as the strings, and returns the address to this memory. The consumer releases the array memory with <c>IMalloc::Free</c>
		/// when it no longer needs the parameter information. If *pcParams is zero on output or an error occurs, the provider does not
		/// allocate any memory and ensures that *prgParamInfo is a null pointer on output. Parameters are returned in ascending order
		/// according to the iOrdinal element of the PARAMINFO structure.
		/// </para>
		/// <para>Here is the DBPARAMINFO structure:</para>
		/// <para>The elements of this structure are used as described in the following table.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Element</description>
		/// <description>Description</description>
		/// </listheader>
		/// <item>
		/// <description><c>dwFlags</c></description>
		/// <description>A bitmask describing parameter characteristics; these values have the following meaning:</description>
		/// </item>
		/// <item>
		/// <description><c>iOrdinal</c></description>
		/// <description>
		/// The ordinal of the parameter. Parameters are numbered from left to right as they appear in the command, with the first parameter
		/// in the command having an <c>iOrdinal</c> value of 1.
		/// </description>
		/// </item>
		/// <item>
		/// <description><c>pwszName</c></description>
		/// <description>
		/// The name of the parameter; it is a null pointer if there is no name. Names are normal names. The colon prefix (where used within
		/// SQL text) is stripped.
		/// </description>
		/// </item>
		/// <item>
		/// <description><c>pTypeInfo</c></description>
		/// <description><c>ITypeInfo</c> describes the type, if <c>pTypeInfo</c> is not a null pointer.</description>
		/// </item>
		/// <item>
		/// <description><c>ulParamSize</c></description>
		/// <description>
		/// The maximum possible length of a value in the parameter. For parameters that use a fixed-length data type, this is the size of
		/// the data type. For parameters that use a variable-length data type, this is one of the following: For data types that do not have
		/// a length, this is set to ~0 (bitwise, the value is not 0; all bits are set to 1).
		/// </description>
		/// </item>
		/// <item>
		/// <description><c>wType</c></description>
		/// <description>
		/// The indicator of the parameter's data type, or a type from which the data can be converted for the parameter if the provider
		/// cannot determine the exact data type of the parameter.
		/// </description>
		/// </item>
		/// <item>
		/// <description><c>bPrecision</c></description>
		/// <description>
		/// If <c>wType</c> is a numeric type or DBTYPE_DBTIMESTAMP, <c>bPrecision</c> is the maximum number of digits, expressed in base 10.
		/// Otherwise, this is ~0 (bitwise, the value is not 0; all bits are set to 1).
		/// </description>
		/// </item>
		/// <item>
		/// <description><c>bScale</c></description>
		/// <description>
		/// If <c>wType</c> is a numeric type with a fixed scale or if <c>wType</c> is DBTYPE_DBTIMESTAMP, <c>bScale</c> is the number of
		/// digits to the right (if <c>bScale</c> is positive) or left (if <c>bScale</c> is negative) of the decimal point. Otherwise, this
		/// is ~0 (bitwise, the value is not 0; all bits are set to 1).
		/// </description>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="ppNamesBuffer">
		/// <para>[out]</para>
		/// <para>
		/// A pointer to memory in which to store all string values (names used within the *pwszName element of the DBPARAMINFO structures)
		/// with a single, globally allocated buffer. Specifying a null pointer for ppNamesBuffer suspends the return of parameter names. The
		/// command allocates memory for the buffer and returns the address to this memory. The consumer releases the memory with
		/// <c>IMalloc::Free</c> when it no longer needs the parameter information. If *pcParams is zero on output or an error occurs, the
		/// provider does not allocate any memory and ensures that *ppNamesBuffer is a null pointer on output. (The following two sentences
		/// have been joined to this Definition paragraph to pass conversion) Each of the individual string values stored in this buffer is
		/// terminated by a null-termination character. Therefore, the buffer may contain one or more strings, each with its own
		/// null-termination character, and may contain embedded null termination characters.
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
		/// <para>E_INVALIDARG pcParams or prgParamInfo was a null pointer.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// E_OUTOFMEMORY The provider was unable to allocate sufficient memory in which to return the parameter data array or parameter names.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// DB_E_NOCOMMAND The provider can derive parameter information. However, no command text was currently set on the command object
		/// and no parameter information had been specified with <c>ICommandWithParameters::SetParameterInfo</c>.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// DB_E_NOTPREPARED The provider can derive parameter information, and it supports command preparation. However, the command was in
		/// an unprepared state and no parameter information was specified with <c>ICommandWithParameters::SetParameterInfo</c>.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// DB_E_PARAMUNAVAILABLE The provider cannot derive parameter information from the command, and
		/// <c>ICommandWithParameters::SetParameterInfo</c> has not been called.
		/// </para>
		/// </description>
		/// </item>
		/// </list>
		/// <para>Comments</para>
		/// <para>This method makes no logical change to the state of the object.</para>
		/// <para>
		/// If <c>ICommandWithParameters::SetParameterInfo</c> has not been called for any parameters or
		/// <c>ICommandWithParameters::SetParameterInfo</c> has been called with cParams equal to zero,
		/// <c>ICommandWithParameters::GetParameterInfo</c> returns information about the parameters only if the provider can derive
		/// parameter information. If the provider cannot derive parameter information, <c>ICommandWithParameters::GetParameterInfo</c>
		/// returns DB_E_PARAMUNAVAILABLE.
		/// </para>
		/// <para>
		/// If <c>ICommandWithParameters::SetParameterInfo</c> has been called for at least one parameter,
		/// <c>ICommandWithParameters::GetParameterInfo</c> returns the parameter information only for those parameters for which
		/// <c>SetParameterInfo</c> has been called. The provider does not return a warning in this case because it often cannot determine
		/// the number of parameters and therefore cannot determine whether it has returned information for all parameters. It is
		/// provider-specific whether or not the provider also returns derived information about the parameters for which
		/// <c>ICommandWithParameters::SetParameterInfo</c> was not called. For performance reasons, even providers that can derive this
		/// additional parameter information will usually return only the information that was specified when
		/// <c>ICommandWithParameters::SetParameterInfo</c> was called.
		/// </para>
		/// <para>
		/// <para>Note</para>
		/// <para>
		/// Providers are permitted to overwrite parameter information set by the consumer with the actual parameter information for the
		/// statement or stored procedure. However, they are not encouraged to do so if such validation requires a round-trip to the server.
		/// Consumers must not rely on providers to validate parameter information in this manner.
		/// </para>
		/// </para>
		/// </returns>
		// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/ms714917(v=vs.85) HRESULT GetParameterInfo ( DB_UPARAMS
		// *pcParams, DBPARAMINFO **prgParamInfo, OLECHAR **ppNamesBuffer);
		[PreserveSig]
		HRESULT GetParameterInfo(out DB_UPARAMS pcParams, out SafeIMallocHandle prgParamInfo, out SafeIMallocHandle ppNamesBuffer);

		/// <summary>Returns an array of parameter ordinals when given named parameters.</summary>
		/// <param name="cParamNames">
		/// [in] The number of parameter names to map. If cParamNames is zero, <c>ICommandWithParameters::MapParameterNames</c> does nothing
		/// and returns S_OK.
		/// </param>
		/// <param name="rgParamNames">
		/// [in] An array of parameter names of which to determine the parameter ordinals. If a parameter name is not found, the
		/// corresponding element of rgParamOrdinals is set to zero and the method returns DB_S_ERRORSOCCURRED.
		/// </param>
		/// <param name="rgParamOrdinals">
		/// [out] An array of cParamNames ordinals of the parameters identified by the elements of rgParamNames. The consumer allocates (but
		/// is not required to initialize) memory for this array and passes the address of this memory to the provider. The provider returns
		/// the parameter ordinals in the array.
		/// </param>
		/// <returns>
		/// <list type="bullet">
		/// <item>
		/// <description>
		/// <para>S_OK The method succeeded. Each element of rgParamOrdinals is set to a nonzero value.</para>
		/// <para>
		/// cParamNames was zero; the method succeeded but did nothing. This return code supersedes E_INVALIDARG if cParamNames was zero and
		/// either or both rgParamNames and rgParamOrdinals was a null pointer.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_S_ERRORSOCCURRED An element of rgParamNames was invalid. The corresponding element of rgParamOrdinals is set to zero.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>E_FAIL A provider-specific error occurred.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>E_INVALIDARG cParamNames was not zero, and rgParamNames or rgParamOrdinals was a null pointer.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_E_ERRORSOCCURRED All elements of rgParamNames were invalid. All elements of rgParamOrdinals are set to zero.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// DB_E_NOCOMMAND No command text was currently set on the command object, and no parameter information had been specified with <c>ICommandWithParameters::SetParameterInfo</c>.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// DB_E_NOTPREPARED The provider can derive parameter information and supports command preparation. However, the command was in an
		/// unprepared state and no parameter information had been specified with <c>ICommandWithParameters::SetParameterInfo</c>.
		/// </para>
		/// </description>
		/// </item>
		/// </list>
		/// </returns>
		// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/ms725394(v=vs.85) HRESULT MapParameterNames ( DB_UPARAMS
		// cParamNames, const OLECHAR *rgParamNames[], DB_LPARAMS rgParamOrdinals[]);
		[PreserveSig]
		HRESULT MapParameterNames(DB_UPARAMS cParamNames,
			[In, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPWStr, SizeParamIndex = 0)] string[] rgParamNames,
			[Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] DB_LPARAMS[] rgParamOrdinals);

		/// <summary>Specifies the native data type of each parameter.</summary>
		/// <param name="cParams">
		/// [in] The number of parameters for which to set type information. If cParams is zero, the type information for all parameters is
		/// discarded and rgParamOrdinals and rgParamBindInfo are ignored.
		/// </param>
		/// <param name="rgParamOrdinals">
		/// [in] An array of cParams ordinals. These are the ordinals of the parameters for which to set type information. Type information
		/// for parameters whose ordinals are not specified is not affected.
		/// </param>
		/// <param name="rgParamBindInfo">
		/// <para>
		/// [in] An array of cParams DBPARAMBINDINFO structures. If rgParamBindInfo is a null pointer, the type information for the
		/// parameters specified by the ordinals in rgParamOrdinals is discarded.
		/// </para>
		/// <para>The DBPARAMBINDINFO structure is:</para>
		/// <para>The elements of this structure are used as described in the following table.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Element</description>
		/// <description>Description</description>
		/// </listheader>
		/// <item>
		/// <description><c>pwszDataSourceType</c></description>
		/// <description>
		/// A pointer to the provider-specific name of the parameter's data type or a standard data type name. This name is not returned by
		/// <c>ICommandWithParameters::GetParameterInfo</c>; instead, the provider maps the data type specified by this name to an OLE DB
		/// type indicator and returns that type indicator. For a list of standard data type names, see "Comments" below. If
		/// <c>pwszDataSourceType</c> is null, the provider attempts a default conversion from the data type specified in the binding for the
		/// parameter or returns E_INVALIDARG if it cannot perform default parameter conversions.
		/// </description>
		/// </item>
		/// <item>
		/// <description><c>pwszName</c></description>
		/// <description>
		/// The name of the parameter. This is a null pointer if the parameter does not have a name. The consumer must specify a name for all
		/// or none of the parameters set at any time. If the provider does not support named parameters, this argument is ignored and the
		/// provider is not required to verify that all or none of the parameters are named.
		/// </description>
		/// </item>
		/// <item>
		/// <description><c>ulParamSize</c></description>
		/// <description>
		/// The maximum possible length of a value in the parameter. For parameters that use a fixed-length data type, this is the size of
		/// the data type. For parameters that use a variable-length data type, this is one of the following: For data types that do not have
		/// a length, this is set to ~0 (bitwise, the value is not 0; all bits are set to 1). This argument is ignored if
		/// <c>pwszDataSourceType</c> is null.
		/// </description>
		/// </item>
		/// <item>
		/// <description><c>dwFlags</c></description>
		/// <description>See the <c>dwFlags</c> element of the DBPARAMINFO structure in GetParameterInfo.</description>
		/// </item>
		/// <item>
		/// <description><c>bPrecision</c></description>
		/// <description>
		/// If <c>pwszDataSourceType</c> is DBTYPE_DBTIMESTAMP or a numeric type, <c>bPrecision</c> is the maximum number of digits,
		/// expressed in base 10. Otherwise, it is ignored. This argument is ignored if <c>pwszDataSourceType</c> is null.
		/// </description>
		/// </item>
		/// <item>
		/// <description><c>bScale</c></description>
		/// <description>
		/// If <c>pwszDataSourceType</c> is a numeric type with a fixed scale or if <c>wType</c> is DBTYPE_DBTIMESTAMP, <c>bScale</c> is the
		/// number of digits to the right (if <c>bScale</c> is positive) or left (if <c>bScale</c> is negative) of the decimal point.
		/// Otherwise, it is ignored. This argument is ignored if <c>pwszDataSourceType</c> is null.
		/// </description>
		/// </item>
		/// </list>
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
		/// DB_S_TYPEINFOOVERRIDDEN The provider was capable of deriving the parameter type information, and
		/// <c>ICommandWithParameters::SetParameterInfo</c> was called. The parameter type information specified in
		/// <c>ICommandWithParameters::SetParameterInfo</c> was used.
		/// </para>
		/// <para><c>ICommandWithParameters::SetParameterInfo</c> replaced parameter type information specified in a previous call to <c>SetParameterInfo</c>.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>E_FAIL A provider-specific error occurred.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>E_INVALIDARG cParams was not zero, and rgParamOrdinals was a null pointer.</para>
		/// <para>An element of rgParamOrdinals was zero.</para>
		/// <para>
		/// In an element of rgParamBindInfo, the pwszDataSourceType element was a null pointer, and the provider does not support default
		/// parameter conversions.
		/// </para>
		/// <para>In an element of rgParamBindInfo, the dwFlags element was invalid.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_E_BADORDINAL An element of rgParamOrdinals was invalid.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// DB_E_BADPARAMETERNAME In an element of rgParamBindInfo, the pwszName element specified an invalid parameter name. The provider
		/// does not check whether the name was correct for the specified parameter, just whether it was a valid parameter name.
		/// </para>
		/// <para>In one or more (but not all) elements of rgParamBindInfo, pwszName was null.</para>
		/// <para>
		/// In one or more elements of rgParamBindInfo, pwszName was null and one or more parameters previously set and not overridden were
		/// specified with a non-null pwszName.
		/// </para>
		/// <para>
		/// In one or more elements of rgParamBindInfo, pwszName was non-null and one or more parameters previously set and not overridden
		/// were specified with a null pwszName.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// DB_E_BADTYPENAME In an element of rgParamBindInfo, the pwszDataSourceType element specified an invalid data type name. The
		/// provider does not check whether the data type was correct for the specified parameter, just whether it was a data type name
		/// supported by the provider.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_E_OBJECTOPEN A rowset was open on the command.</para>
		/// </description>
		/// </item>
		/// </list>
		/// </returns>
		// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/ms725393(v=vs.85) HRESULT SetParameterInfo ( DB_UPARAMS
		// cParams, const DB_UPARAMS rgParamOrdinals[], const DBPARAMBINDINFO rgParamBindInfo[]);
		[PreserveSig]
		HRESULT SetParameterInfo(DB_UPARAMS cParams, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] DB_UPARAMS[]? rgParamOrdinals,
			[In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] DBPARAMBINDINFO[]? rgParamBindInfo);
	}

	/// <summary>
	/// <para>This interface is mandatory on commands, rowsets, index rowsets, and rows.</para>
	/// <para>
	/// This interface contains a single method that gives information about the availability of type conversions on a command, a rowset, or
	/// a row.
	/// </para>
	/// </summary>
	// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/ms715926(v=vs.85)
	[PInvokeData("oledb.h")]
	[ComImport, Guid("0c733a88-2a1c-11ce-ade5-00aa0044773d"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IConvertType
	{
		/// <summary>Gives information about the availability of type conversions on a command, a rowset, or a row.</summary>
		/// <param name="wFromType">[in] The source type of the conversion.</param>
		/// <param name="wToType">[in] The target type of the conversion.</param>
		/// <param name="dwConvertFlags">
		/// <para>
		/// [in] Whether <c>IConvertType::CanConvert</c> is to determine if the conversion is supported on the rowset or on the command.
		/// These flags have the following meaning:
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <description>Value</description>
		/// <description>Description</description>
		/// </listheader>
		/// <item>
		/// <description>DBCONVERTFLAGS_COLUMN</description>
		/// <description>
		/// <c>IConvertType::CanConvert</c> is to determine whether the conversion is supported when setting, getting, finding, filtering, or
		/// seeking on columns of the rowset or row. This flag is mutually exclusive with DBCONVERTFLAGS_PARAMETER.
		/// </description>
		/// </item>
		/// <item>
		/// <description>DBCONVERTFLAGS_ISFIXEDLENGTH</description>
		/// <description>
		/// <c>IConvertType::CanConvert</c> is to determine whether a fixed-length value of the DBTYPE specified in the <c>dwFromType</c> can
		/// be converted to the DBTYPE specified in <c>wToType</c>. This flag can coexist with either DBCONVERTFLAGS_COLUMN or
		/// DBCONVERTFLAGS_PARAMETER. This flag is supported only by OLE DB version 2.0 or later providers.
		/// </description>
		/// </item>
		/// <item>
		/// <description>DBCONVERTFLAGS_ISLONG</description>
		/// <description>
		/// <c>IConvertType::CanConvert</c> is to determine whether the long version of the DBTYPE specified in the <c>dwFromType</c> can be
		/// converted to the DBTYPE specified in <c>wToType</c>. This flag is valid only when used in conjunction with a variable-length
		/// DBTYPE. This flag can coexist with either DBCONVERTFLAGS_COLUMN or DBCONVERTFLAGS_PARAMETER. This flag is supported only by OLE
		/// DB version 2.0 or later providers.
		/// </description>
		/// </item>
		/// <item>
		/// <description>DBCONVERTFLAGS_PARAMETER</description>
		/// <description>
		/// <c>IConvertType::CanConvert</c> is to determine whether the conversion is supported on the parameters of the command.
		/// </description>
		/// </item>
		/// <item>
		/// <description>DBCONVERTFLAGS_FROMVARIANT</description>
		/// <description>
		/// The DBTYPE specified in the <c>wFromType</c> represents a type within a VARIANT. <c>IConvertType::CanConvert</c> returns whether
		/// the conversion from a VARIANT of that type to the type specified in <c>wToType</c> is allowed. For providers that support
		/// PROPVARIANT, this applies to conversions from PROPVARIANT as well.
		/// </description>
		/// </item>
		/// </list>
		/// </param>
		/// <returns>
		/// <list type="bullet">
		/// <item>
		/// <description>
		/// <para>S_OK The requested conversion is available.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>S_FALSE The requested conversion is not available.</para>
		/// <para>wFromType or wToType was not a valid type for the provider, and the provider was a version 2.0 or later provider.</para>
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
		/// E_INVALIDARG The provider was an OLE DB 1.x provider, and wFromType or wToType was not a valid type indicator for OLE DB 1.x.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_E_BADCONVERTFLAG dwConvert flags was invalid.</para>
		/// <para>
		/// The method was called on a command, and its flags inquired about a conversion on a rowset but the property
		/// DBPROP_ROWSETCONVERSIONSONCOMMAND was VARIANT_FALSE.
		/// </para>
		/// <para>The DBCONVERTFLAG_PARAMETER bit was set, and <c>IConvertType::CanConvert</c> was called on a rowset or row.</para>
		/// <para>
		/// The DBCONVERTFLAGS_PARAMETER bit was set, and <c>IConvertType::CanConvert</c> was called on a command (whether from a provider or
		/// not) that does not support parameters.
		/// </para>
		/// <para>DBCONVERTFLAGS_ISLONG was specified, and the DBTYPE specified in dwFromType was not a variable-length DBTYPE.</para>
		/// <para>DBCONVERTFLAGS_ISLONG was specified, and the provider was an OLE DB 1.x provider.</para>
		/// <para>DBCONVERTFLAGS_ISFIXEDLENGTH was specified, and the provider was an OLE DB 1.x provider.</para>
		/// <para>DBCONVERTFLAGS_COLUMN and DBCONVERTFLAGS_PARAMETER were both specified. (These two flags are mutually exclusive.)</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_E_BADTYPE DBCONVERTFLAGS_FROMVARIANT was specified, and the type specified in wFromType was not a VARIANT type.</para>
		/// </description>
		/// </item>
		/// </list>
		/// </returns>
		// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/ms711224(v=vs.85) HRESULT CanConvert ( DBTYPE wFromType,
		// DBTYPE wToType, DBCONVERTFLAGS dwConvertFlags);
		[PreserveSig]
		HRESULT CanConvert(DBTYPE wFromType, DBTYPE wToType, DBCONVERTFLAGS dwConvertFlags);
	}

	/// <summary><c>ICreateRow</c> creates and binds to an object named by a URL.</summary>
	// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/ms716832(v=vs.85)
	[PInvokeData("oledb.h")]
	[ComImport, Guid("0c733ab2-2a1c-11ce-ade5-00aa0044773d"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ICreateRow
	{
		/// <summary>Creates and binds to an object named by a URL and returns the requested interface pointer.</summary>
		/// <param name="pUnkOuter">
		/// [in] If the returned object is to be aggregated, pUnkOuter is an interface pointer to the controlling <c>IUnknown</c>. Otherwise,
		/// it is a null pointer.
		/// </param>
		/// <param name="pwszURL">
		/// [in] The canonical URL naming the object to be created. If DBPROP_GENERATEURL is DBPROPVAL_GU_SUFFIX, this string defines the
		/// path to the new object and the provider will generate the URL suffix.
		/// </param>
		/// <param name="dwBindURLFlags">
		/// <para>
		/// [in] Bitmask of bind flags that control how the object is to be bound. For more information, see the dwBindURLFlags value table
		/// in the reference entry for IBindResource::Bind.
		/// </para>
		/// <para>
		/// <para>Note</para>
		/// <para>
		/// Creating a row requires DBBINDURLFLAG_WRITE be set. This is independent of whether a row, rowset, or stream view of the resource
		/// is requested.
		/// </para>
		/// </para>
		/// <para>
		/// The flag values listed in the following table are also available on <c>ICreateRow::CreateRow</c>, in addition to the bind flags
		/// defined in <c>IBindResource::Bind</c>.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <description>Flags</description>
		/// <description>Meaning</description>
		/// </listheader>
		/// <item>
		/// <description>DBBINDURLFLAG_COLLECTION</description>
		/// <description>Creates the object as a collection.</description>
		/// </item>
		/// <item>
		/// <description>DBBINDURLFLAG_ISSTRUCTUREDDOCUMENT</description>
		/// <description>Creates the object as a structured document.</description>
		/// </item>
		/// <item>
		/// <description>DBBINDURLFLAG_OPENIFEXISTS</description>
		/// <description>
		/// If the resource exists and is not a collection, it is opened and S_OK is returned. If it exists and is a collection,
		/// DB_E_RESOURCEEXISTS is returned. If the resource does not exist, it is created. This flag may not be used with DBBINDURLFLAG_OVERWRITE.
		/// </description>
		/// </item>
		/// <item>
		/// <description>DBBINDURLFLAG_OVERWRITE</description>
		/// <description>Deletes and re-creates a named object if it exists. This flag may not be used with DBBINDURLFLAG_OPENIFEXISTS.</description>
		/// </item>
		/// <item>
		/// <description>DBBINDURLFLAG_COLLECTION | DBBINDURLFLAG_OPENIFEXISTS</description>
		/// <description>
		/// If the resource is not a collection, DB_E_NOTCOLLECTION is returned. If the resource exists and is a collection, it is opened and
		/// S_OK is returned. If the resource does not exist, it is created.
		/// </description>
		/// </item>
		/// </list>
		/// <para>
		/// Not all bind flags may be used with all object types (as specified in the rguid parameter). The following table describes the
		/// restrictions. If a client does not adhere to these restrictions, the bind will fail with E_INVALIDARG.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <description>Object type</description>
		/// <description>Restrictions</description>
		/// </listheader>
		/// <item>
		/// <description>DBGUID_ROW</description>
		/// <description>All flags are allowed. DBBINDURLFLAG_OPENIFEXISTS and DBBINDURLFLAG_OVERWRITE may not be used together.</description>
		/// </item>
		/// <item>
		/// <description>DBGUID_ROWSET</description>
		/// <description>
		/// DBBINDURLFLAG_COLLECTION must be specified. DBBINDURLFLAG_OPENIFEXISTS and DBBINDURLFLAG_OVERWRITE may not be used together. In
		/// addition, the following flags are disallowed:
		/// </description>
		/// </item>
		/// <item>
		/// <description>DBGUID_STREAM</description>
		/// <description>
		/// DBBINDURLFLAG_OPENIFEXISTS and DBBINDURLFLAG_OVERWRITE may not be used together. In addition, the following flags are disallowed:
		/// </description>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="rguid">
		/// <para>
		/// [in] A pointer to a GUID indicating the type of OLE DB object to be returned. The GUID must be set to one of the following values:
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <description>
		/// <para>DBGUID_ROW</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DBGUID_ROWSET</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DBGUID_STREAM</para>
		/// </description>
		/// </item>
		/// </list>
		/// <para>
		/// <para>Note</para>
		/// <para>DBGUID_ROWSET can be requested only if the row represents a collection (that is, dwBindURLFlags set to DBBINDURLFLAG_COLLECTION).</para>
		/// </para>
		/// </param>
		/// <param name="riid">[in] Interface ID of the interface pointer to be returned.</param>
		/// <param name="pAuthenticate">
		/// [in] Optional pointer to the caller's <c>IAuthenticate</c> i nterface. If supplied, it is provider-specific whether the
		/// <c>IAuthenticate</c> credentials are used before or after anonymous or default login credentials are used.
		/// </param>
		/// <param name="pImplSession">
		/// <para>
		/// [in/out] A pointer to a DBIMPLICITSESSION structure used to request and return aggregation information for the implicit session
		/// object. The DBIMPLICITSESSION structure is defined in the reference entry for IBindResource::Bind. If
		/// <c>ICreateRow::CreateRow</c> fails and pImplSession is not a null pointer, pImplSession-&gt;pSession should be set to NULL.
		/// </para>
		/// <para>
		/// <para>Note</para>
		/// <para>
		/// <c>ICreateRow::CreateRow</c> uses pImplSession only when implemented on a binder object and binding to a row, rowset, or stream
		/// object (rguid is DBGUID_ROW, DBGUID_ROWSET, or DBGUID_STREAM). If implemented on any other object (for example, a session or row
		/// object), the provider ignores pImplSession because the existing object already has a session context.
		/// </para>
		/// </para>
		/// </param>
		/// <param name="pdwBindStatus">
		/// [out] A pointer to memory in which to return a bitmask that describes warning status for requested bind flags. If pdwBindStatus
		/// is a null pointer, no status is returned. The bind status values are listed in the table for pdwBindStatus for
		/// IBindResource::Bind. This parameter should be set to NULL if an error code is returned.
		/// </param>
		/// <param name="ppwszNewURL">
		/// [out] A pointer to memory in which to return a string containing a provider-generated canonical URL that names the created row.
		/// If DBPROP_GENERATEURL is DBPROPVAL_GU_SUFFIX, callers are required to pass this pointer. If DBPROP_GENERATEURL is
		/// DBPROPVAL_GU_NOTSUPPORTED and the caller passes a null value, the provider does not return the absolute URL of the created row.
		/// If the caller passes this pointer, the provider must return the absolute URL of the created row. The provider allocates the
		/// memory for this string. The consumer should free the memory with <c>IMalloc::Free</c>. If <c>ICreateRow::CreateRow</c> fails and
		/// ppwszNewURL is not a null pointer, *ppwszNewURL is set to NULL.
		/// </param>
		/// <param name="ppUnk">
		/// [out] A pointer to memory in which to return an interface pointer on the requested object. If <c>ICreateRow::CreateRow</c> fails,
		/// *ppUnk is set to a null pointer.
		/// </param>
		/// <returns>
		/// <list type="bullet">
		/// <item>
		/// <description>
		/// <para>S_OK The method succeeded, the object named by the URL was created and bound, and the requested interface pointer was returned.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>E_INVALIDARG pwszURL or ppUnk was a null pointer.</para>
		/// <para>rguid was DBGUID_ROWSET, but the DBBINDURLFLAG_COLLECTION bit of dwBindURLFlags was not set.</para>
		/// <para>pImplSession was not a null pointer, and pImplSession-&gt;piid was a null pointer.</para>
		/// <para>
		/// dwBindURLFlags contained a flag labeled "Modifies DBBINDURLFLAG_*" in the dwBindURLFlags value table in the reference entry for
		/// IBindResource::Bind but did not contain the flag to be modified.
		/// </para>
		/// <para>dwBindURLFlags contained both DBBINDURLFLAG_OPENIFEXISTS and DBBINDURLFLAG_OVERWRITE.</para>
		/// <para>The provider does not support one or more values of dwBindURLFlags.</para>
		/// <para>
		/// One of more of the bind flags in dwBindURLFlags are either not supported by the provider or disallowed for the object type
		/// denoted by rguid. For flags allowed for each object type, see the table in the reference entry for <c>IBindResource::Bind</c>.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// DB_S_ASYNCHRONOUS The method has initiated asynchronous creation of an object. The consumer can call
		/// <c>IDBAsynchStatus::GetStatus</c> to poll for status or can register for notifications of asynchronous processing. Until
		/// asynchronous processing is complete, the object is not populated.
		/// </para>
		/// <para>DB_S_ASYNCHRONOUS should be returned before DB_S_ERRORSOCCURRED.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// DB_S_ERRORSOCCURRED The bind succeeded, but some bind flags or properties were not satisfied. The consumer should examine the
		/// bind status returned in the parameter pdwBindStatus of IBindResource::Bind.
		/// </para>
		/// <para>
		/// DB_S_ASYNCHRONOUS should be returned before DB_S_ERRORSOCCURRED. Once rowset population is complete, the consumer can see
		/// DB_S_ERRORSOCCURRED either by calling <c>IDBAsynchStatus::GetStatus</c> or by receiving <c>IDBAsynchNotify::OnStop</c>.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// DB_S_ERRORSOCCURRED <c>IDBProperties::SetProperties</c> is invoked on the root binder object prior to calling
		/// <c>ICreateRow::CreateRow</c> method, with unsupported properties that have the dwoptions parameter set to DBPROPOPTIONS_REQUIRED.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_E_OBJECTMISMATCH The object named by rguid does not represent the resource named by pwszURL.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// DB_E_OBJECTOPEN The provider would have to open a new connection to support this operation, and DBPROP_MULTIPLECONNECTIONS is set
		/// to VARIANT_FALSE.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// DB_E_RESOURCELOCKED One or more other processes using the DBBINDURLFLAG_SHARE_* flag have locked the OLE DB object represented by
		/// this URL. <c>IErrorInfo::GetDescription</c> returns a string consisting of user names separated by semicolons. These are the
		/// names of the users who have the object locked.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// DB_E_RESOURCENOTSUPPORTED The consumer attempted to create a type of row not supported by the provider. For example,
		/// DBBINDURLFLAG_ISSTRUCTUREDDOCUMENT was set but the provider does not support structured documents.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// DB_E_RESOURCEOUTOFSCOPE <c>ICreateRow</c> is implemented on a session or row object, and the caller tried to bind to an object
		/// that is not within the scope of this session or row object, respectively.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// DB_SEC_E_PERMISSIONDENIED The caller's authentication context does not permit access to the object.
		/// <c>IErrorInfo::GetDescription</c> returns the default error string.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_SEC_E_SAFEMODE_DENIED The provider was called within a safe mode or context, and pwszURL specified an unsafe URL.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_E_READONLY The caller requested write access to a read-only object.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_E_ASYNCNOTSUPPORTED The provider does not support asynchronous binding.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_E_CANNOTCONNECT The provider could not connect to the server for this object.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_E_NOAGGREGATION pUnkOuter was not a null pointer, and the object being created does not support aggregation.</para>
		/// <para>pUnkOuter was not a null pointer, and riid was not IID_IUnknown.</para>
		/// <para>
		/// pImplSession was not a null pointer, pImplSession-&gt;pUnkOuter was not a null pointer, and pImplSession-&gt;piid did not point
		/// to IID_IUnknown.
		/// </para>
		/// <para>
		/// pImplSession was not a null pointer, pImplSession-&gt;pUnkOuter was not a null pointer, and the object being created does not
		/// support aggregation.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// DB_E_OUTOFSPACE The provider was unable to create an object at this URL using <c>ICreateRow::CreateRow</c> because the server was
		/// out of physical storage.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_E_NOTCOLLECTION The provider was unable to create an object with the specified URL because the parent URL is not a collection.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_E_NOTFOUND The provider was unable to create an object with the specified URL because the parent URL does not exist.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// DB_E_NOTSUPPORTED The provider supports direct binding to OLE DB objects but does not support the object type requested in rguid.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_E_TIMEOUT The attempt to bind to the object timed out.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// DB_E_RESOURCEEXISTS The provider was unable to create an object at this URL because an object named by this URL already exists
		/// and either the caller did not specify OPENIFEXISTS or OVERWRITE or the provider does not support this behavior on object creation.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>REGDB_E_CLASSNOTREG The root binder was unable to instantiate the provider binder object.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>E_FAIL A provider-specific error occurred.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>E_NOINTERFACE The object did not support the interface specified in riid, or riid was IID_NULL.</para>
		/// <para>The provider does not allow the creation of resources via <c>ICreateRow</c>.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// E_UNEXPECTED <c>ICreateRow::CreateRow</c> is implemented on a row object, <c>ITransaction::Commit</c> or
		/// <c>ITransaction::Abort</c> was called, and the object is in a zombie state.
		/// </para>
		/// </description>
		/// </item>
		/// </list>
		/// </returns>
		// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/ms723937(v=vs.85) HRESULT CreateRow( IUnknown * pUnkOuter,
		// LPCOLESTR pwszURL, DBBINDURLFLAG dwBindURLFlags, REFGUID rguid, REFIID riid, IAuthenticate * pAuthenticate, DBIMPLICITSESSION *
		// pImplSession, DBBINDURLSTATUS * pdwBindStatus, LPOLESTR * ppwszNewURL, IUnknown ** ppUnk );
		[PreserveSig]
		HRESULT CreateRow([In, Optional, MarshalAs(UnmanagedType.IUnknown)] object? pUnkOuter, [In, MarshalAs(UnmanagedType.LPWStr)] string pwszURL,
			DBBINDURLFLAG dwBindURLFlags, in Guid rguid, in Guid riid, [In, Optional, MarshalAs(UnmanagedType.IUnknown)] object? pAuthenticate,
			[In, Out, Optional] IntPtr pImplSession, out DBBINDURLSTATUS pdwBindStatus, out SafeIMallocHandle ppwszNewURL,
			[Optional, MarshalAs(UnmanagedType.IUnknown)] out object? ppUnk);
	}

	/// <summary>Creates and binds to an object named by a URL and returns the requested interface pointer.</summary>
	/// <typeparam name="T">The type of interface to return.</typeparam>
	/// <param name="cr">The <see cref="ICreateRow"/> instance.</param>
	/// <param name="pwszURL">
	/// [in] The canonical URL naming the object to be created. If DBPROP_GENERATEURL is DBPROPVAL_GU_SUFFIX, this string defines the path to
	/// the new object and the provider will generate the URL suffix.
	/// </param>
	/// <param name="dwBindURLFlags">
	/// <para>
	/// [in] Bitmask of bind flags that control how the object is to be bound. For more information, see the dwBindURLFlags value table in
	/// the reference entry for IBindResource::Bind.
	/// </para>
	/// <para>
	/// <para>Note</para>
	/// <para>
	/// Creating a row requires DBBINDURLFLAG_WRITE be set. This is independent of whether a row, rowset, or stream view of the resource is requested.
	/// </para>
	/// </para>
	/// <para>
	/// The flag values listed in the following table are also available on <c>ICreateRow::CreateRow</c>, in addition to the bind flags
	/// defined in <c>IBindResource::Bind</c>.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <description>Flags</description>
	/// <description>Meaning</description>
	/// </listheader>
	/// <item>
	/// <description>DBBINDURLFLAG_COLLECTION</description>
	/// <description>Creates the object as a collection.</description>
	/// </item>
	/// <item>
	/// <description>DBBINDURLFLAG_ISSTRUCTUREDDOCUMENT</description>
	/// <description>Creates the object as a structured document.</description>
	/// </item>
	/// <item>
	/// <description>DBBINDURLFLAG_OPENIFEXISTS</description>
	/// <description>
	/// If the resource exists and is not a collection, it is opened and S_OK is returned. If it exists and is a collection,
	/// DB_E_RESOURCEEXISTS is returned. If the resource does not exist, it is created. This flag may not be used with DBBINDURLFLAG_OVERWRITE.
	/// </description>
	/// </item>
	/// <item>
	/// <description>DBBINDURLFLAG_OVERWRITE</description>
	/// <description>Deletes and re-creates a named object if it exists. This flag may not be used with DBBINDURLFLAG_OPENIFEXISTS.</description>
	/// </item>
	/// <item>
	/// <description>DBBINDURLFLAG_COLLECTION | DBBINDURLFLAG_OPENIFEXISTS</description>
	/// <description>
	/// If the resource is not a collection, DB_E_NOTCOLLECTION is returned. If the resource exists and is a collection, it is opened and
	/// S_OK is returned. If the resource does not exist, it is created.
	/// </description>
	/// </item>
	/// </list>
	/// <para>
	/// Not all bind flags may be used with all object types (as specified in the rguid parameter). The following table describes the
	/// restrictions. If a client does not adhere to these restrictions, the bind will fail with E_INVALIDARG.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <description>Object type</description>
	/// <description>Restrictions</description>
	/// </listheader>
	/// <item>
	/// <description>DBGUID_ROW</description>
	/// <description>All flags are allowed. DBBINDURLFLAG_OPENIFEXISTS and DBBINDURLFLAG_OVERWRITE may not be used together.</description>
	/// </item>
	/// <item>
	/// <description>DBGUID_ROWSET</description>
	/// <description>
	/// DBBINDURLFLAG_COLLECTION must be specified. DBBINDURLFLAG_OPENIFEXISTS and DBBINDURLFLAG_OVERWRITE may not be used together. In
	/// addition, the following flags are disallowed:
	/// </description>
	/// </item>
	/// <item>
	/// <description>DBGUID_STREAM</description>
	/// <description>
	/// DBBINDURLFLAG_OPENIFEXISTS and DBBINDURLFLAG_OVERWRITE may not be used together. In addition, the following flags are disallowed:
	/// </description>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="rguid">
	/// <para>
	/// [in] A pointer to a GUID indicating the type of OLE DB object to be returned. The GUID must be set to one of the following values:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <description>
	/// <para>DBGUID_ROW</para>
	/// </description>
	/// </item>
	/// <item>
	/// <description>
	/// <para>DBGUID_ROWSET</para>
	/// </description>
	/// </item>
	/// <item>
	/// <description>
	/// <para>DBGUID_STREAM</para>
	/// </description>
	/// </item>
	/// </list>
	/// <para>
	/// <para>Note</para>
	/// <para>DBGUID_ROWSET can be requested only if the row represents a collection (that is, dwBindURLFlags set to DBBINDURLFLAG_COLLECTION).</para>
	/// </para>
	/// </param>
	/// <param name="pImplSession">
	/// <para>
	/// [in/out] A pointer to a DBIMPLICITSESSION structure used to request and return aggregation information for the implicit session
	/// object. The DBIMPLICITSESSION structure is defined in the reference entry for IBindResource::Bind. If <c>ICreateRow::CreateRow</c>
	/// fails and pImplSession is not a null pointer, pImplSession-&gt;pSession should be set to NULL.
	/// </para>
	/// <para>
	/// <para>Note</para>
	/// <para>
	/// <c>ICreateRow::CreateRow</c> uses pImplSession only when implemented on a binder object and binding to a row, rowset, or stream
	/// object (rguid is DBGUID_ROW, DBGUID_ROWSET, or DBGUID_STREAM). If implemented on any other object (for example, a session or row
	/// object), the provider ignores pImplSession because the existing object already has a session context.
	/// </para>
	/// </para>
	/// </param>
	/// <param name="pUnkOuter">
	/// [in] If the returned object is to be aggregated, pUnkOuter is an interface pointer to the controlling <c>IUnknown</c>. Otherwise, it
	/// is a null pointer.
	/// </param>
	/// <param name="pAuthenticate">
	/// [in] Optional pointer to the caller's <c>IAuthenticate</c> i nterface. If supplied, it is provider-specific whether the
	/// <c>IAuthenticate</c> credentials are used before or after anonymous or default login credentials are used.
	/// </param>
	/// <param name="pdwBindStatus">
	/// [out] A pointer to memory in which to return a bitmask that describes warning status for requested bind flags. If pdwBindStatus is a
	/// null pointer, no status is returned. The bind status values are listed in the table for pdwBindStatus for IBindResource::Bind. This
	/// parameter should be set to NULL if an error code is returned.
	/// </param>
	/// <param name="ppwszNewURL">
	/// [out] A pointer to memory in which to return a string containing a provider-generated canonical URL that names the created row. If
	/// DBPROP_GENERATEURL is DBPROPVAL_GU_SUFFIX, callers are required to pass this pointer. If DBPROP_GENERATEURL is
	/// DBPROPVAL_GU_NOTSUPPORTED and the caller passes a null value, the provider does not return the absolute URL of the created row. If
	/// the caller passes this pointer, the provider must return the absolute URL of the created row. The provider allocates the memory for
	/// this string. The consumer should free the memory with <c>IMalloc::Free</c>. If <c>ICreateRow::CreateRow</c> fails and ppwszNewURL is
	/// not a null pointer, *ppwszNewURL is set to NULL.
	/// </param>
	/// <param name="ppUnk">
	/// [out] A pointer to memory in which to return an interface pointer on the requested object. If <c>ICreateRow::CreateRow</c> fails,
	/// *ppUnk is set to a null pointer.
	/// </param>
	/// <returns>
	/// <list type="bullet">
	/// <item>
	/// <description>
	/// <para>S_OK The method succeeded, the object named by the URL was created and bound, and the requested interface pointer was returned.</para>
	/// </description>
	/// </item>
	/// <item>
	/// <description>
	/// <para>E_INVALIDARG pwszURL or ppUnk was a null pointer.</para>
	/// <para>rguid was DBGUID_ROWSET, but the DBBINDURLFLAG_COLLECTION bit of dwBindURLFlags was not set.</para>
	/// <para>pImplSession was not a null pointer, and pImplSession-&gt;piid was a null pointer.</para>
	/// <para>
	/// dwBindURLFlags contained a flag labeled "Modifies DBBINDURLFLAG_*" in the dwBindURLFlags value table in the reference entry for
	/// IBindResource::Bind but did not contain the flag to be modified.
	/// </para>
	/// <para>dwBindURLFlags contained both DBBINDURLFLAG_OPENIFEXISTS and DBBINDURLFLAG_OVERWRITE.</para>
	/// <para>The provider does not support one or more values of dwBindURLFlags.</para>
	/// <para>
	/// One of more of the bind flags in dwBindURLFlags are either not supported by the provider or disallowed for the object type denoted by
	/// rguid. For flags allowed for each object type, see the table in the reference entry for <c>IBindResource::Bind</c>.
	/// </para>
	/// </description>
	/// </item>
	/// <item>
	/// <description>
	/// <para>
	/// DB_S_ASYNCHRONOUS The method has initiated asynchronous creation of an object. The consumer can call
	/// <c>IDBAsynchStatus::GetStatus</c> to poll for status or can register for notifications of asynchronous processing. Until asynchronous
	/// processing is complete, the object is not populated.
	/// </para>
	/// <para>DB_S_ASYNCHRONOUS should be returned before DB_S_ERRORSOCCURRED.</para>
	/// </description>
	/// </item>
	/// <item>
	/// <description>
	/// <para>
	/// DB_S_ERRORSOCCURRED The bind succeeded, but some bind flags or properties were not satisfied. The consumer should examine the bind
	/// status returned in the parameter pdwBindStatus of IBindResource::Bind.
	/// </para>
	/// <para>
	/// DB_S_ASYNCHRONOUS should be returned before DB_S_ERRORSOCCURRED. Once rowset population is complete, the consumer can see
	/// DB_S_ERRORSOCCURRED either by calling <c>IDBAsynchStatus::GetStatus</c> or by receiving <c>IDBAsynchNotify::OnStop</c>.
	/// </para>
	/// </description>
	/// </item>
	/// <item>
	/// <description>
	/// <para>
	/// DB_S_ERRORSOCCURRED <c>IDBProperties::SetProperties</c> is invoked on the root binder object prior to calling
	/// <c>ICreateRow::CreateRow</c> method, with unsupported properties that have the dwoptions parameter set to DBPROPOPTIONS_REQUIRED.
	/// </para>
	/// </description>
	/// </item>
	/// <item>
	/// <description>
	/// <para>DB_E_OBJECTMISMATCH The object named by rguid does not represent the resource named by pwszURL.</para>
	/// </description>
	/// </item>
	/// <item>
	/// <description>
	/// <para>
	/// DB_E_OBJECTOPEN The provider would have to open a new connection to support this operation, and DBPROP_MULTIPLECONNECTIONS is set to VARIANT_FALSE.
	/// </para>
	/// </description>
	/// </item>
	/// <item>
	/// <description>
	/// <para>
	/// DB_E_RESOURCELOCKED One or more other processes using the DBBINDURLFLAG_SHARE_* flag have locked the OLE DB object represented by
	/// this URL. <c>IErrorInfo::GetDescription</c> returns a string consisting of user names separated by semicolons. These are the names of
	/// the users who have the object locked.
	/// </para>
	/// </description>
	/// </item>
	/// <item>
	/// <description>
	/// <para>
	/// DB_E_RESOURCENOTSUPPORTED The consumer attempted to create a type of row not supported by the provider. For example,
	/// DBBINDURLFLAG_ISSTRUCTUREDDOCUMENT was set but the provider does not support structured documents.
	/// </para>
	/// </description>
	/// </item>
	/// <item>
	/// <description>
	/// <para>
	/// DB_E_RESOURCEOUTOFSCOPE <c>ICreateRow</c> is implemented on a session or row object, and the caller tried to bind to an object that
	/// is not within the scope of this session or row object, respectively.
	/// </para>
	/// </description>
	/// </item>
	/// <item>
	/// <description>
	/// <para>
	/// DB_SEC_E_PERMISSIONDENIED The caller's authentication context does not permit access to the object. <c>IErrorInfo::GetDescription</c>
	/// returns the default error string.
	/// </para>
	/// </description>
	/// </item>
	/// <item>
	/// <description>
	/// <para>DB_SEC_E_SAFEMODE_DENIED The provider was called within a safe mode or context, and pwszURL specified an unsafe URL.</para>
	/// </description>
	/// </item>
	/// <item>
	/// <description>
	/// <para>DB_E_READONLY The caller requested write access to a read-only object.</para>
	/// </description>
	/// </item>
	/// <item>
	/// <description>
	/// <para>DB_E_ASYNCNOTSUPPORTED The provider does not support asynchronous binding.</para>
	/// </description>
	/// </item>
	/// <item>
	/// <description>
	/// <para>DB_E_CANNOTCONNECT The provider could not connect to the server for this object.</para>
	/// </description>
	/// </item>
	/// <item>
	/// <description>
	/// <para>DB_E_NOAGGREGATION pUnkOuter was not a null pointer, and the object being created does not support aggregation.</para>
	/// <para>pUnkOuter was not a null pointer, and riid was not IID_IUnknown.</para>
	/// <para>
	/// pImplSession was not a null pointer, pImplSession-&gt;pUnkOuter was not a null pointer, and pImplSession-&gt;piid did not point to IID_IUnknown.
	/// </para>
	/// <para>
	/// pImplSession was not a null pointer, pImplSession-&gt;pUnkOuter was not a null pointer, and the object being created does not support aggregation.
	/// </para>
	/// </description>
	/// </item>
	/// <item>
	/// <description>
	/// <para>
	/// DB_E_OUTOFSPACE The provider was unable to create an object at this URL using <c>ICreateRow::CreateRow</c> because the server was out
	/// of physical storage.
	/// </para>
	/// </description>
	/// </item>
	/// <item>
	/// <description>
	/// <para>DB_E_NOTCOLLECTION The provider was unable to create an object with the specified URL because the parent URL is not a collection.</para>
	/// </description>
	/// </item>
	/// <item>
	/// <description>
	/// <para>DB_E_NOTFOUND The provider was unable to create an object with the specified URL because the parent URL does not exist.</para>
	/// </description>
	/// </item>
	/// <item>
	/// <description>
	/// <para>
	/// DB_E_NOTSUPPORTED The provider supports direct binding to OLE DB objects but does not support the object type requested in rguid.
	/// </para>
	/// </description>
	/// </item>
	/// <item>
	/// <description>
	/// <para>DB_E_TIMEOUT The attempt to bind to the object timed out.</para>
	/// </description>
	/// </item>
	/// <item>
	/// <description>
	/// <para>
	/// DB_E_RESOURCEEXISTS The provider was unable to create an object at this URL because an object named by this URL already exists and
	/// either the caller did not specify OPENIFEXISTS or OVERWRITE or the provider does not support this behavior on object creation.
	/// </para>
	/// </description>
	/// </item>
	/// <item>
	/// <description>
	/// <para>REGDB_E_CLASSNOTREG The root binder was unable to instantiate the provider binder object.</para>
	/// </description>
	/// </item>
	/// <item>
	/// <description>
	/// <para>E_FAIL A provider-specific error occurred.</para>
	/// </description>
	/// </item>
	/// <item>
	/// <description>
	/// <para>E_NOINTERFACE The object did not support the interface specified in riid, or riid was IID_NULL.</para>
	/// <para>The provider does not allow the creation of resources via <c>ICreateRow</c>.</para>
	/// </description>
	/// </item>
	/// <item>
	/// <description>
	/// <para>
	/// E_UNEXPECTED <c>ICreateRow::CreateRow</c> is implemented on a row object, <c>ITransaction::Commit</c> or <c>ITransaction::Abort</c>
	/// was called, and the object is in a zombie state.
	/// </para>
	/// </description>
	/// </item>
	/// </list>
	/// </returns>
	// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/ms723937(v=vs.85) HRESULT CreateRow( IUnknown * pUnkOuter,
	// LPCOLESTR pwszURL, DBBINDURLFLAG dwBindURLFlags, REFGUID rguid, REFIID riid, IAuthenticate * pAuthenticate, DBIMPLICITSESSION *
	// pImplSession, DBBINDURLSTATUS * pdwBindStatus, LPOLESTR * ppwszNewURL, IUnknown ** ppUnk );
	public static HRESULT CreateRow<T>(this ICreateRow cr, [In, MarshalAs(UnmanagedType.LPWStr)] string pwszURL,
		DBBINDURLFLAG dwBindURLFlags, in Guid rguid, [In, Out, Optional] DBIMPLICITSESSION? pImplSession, [In, Optional, MarshalAs(UnmanagedType.IUnknown)] object? pUnkOuter, [In, Optional, MarshalAs(UnmanagedType.IUnknown)] object? pAuthenticate,
		out DBBINDURLSTATUS pdwBindStatus, out string? ppwszNewURL,
		out T? ppUnk) where T : class
	{
		SafeCoTaskMemStruct<DBIMPLICITSESSION> pis = pImplSession;
		var hr = cr.CreateRow(pUnkOuter, pwszURL, dwBindURLFlags, rguid, typeof(T).GUID, pAuthenticate, pis, out pdwBindStatus, out var p, out var pp);
#pragma warning disable IDE0059 // Unnecessary assignment of a value
		pImplSession = pis;
#pragma warning restore IDE0059 // Unnecessary assignment of a value
		ppwszNewURL = p?.ToString();
		ppUnk = pp as T;
		return hr;
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
	/// <param name="prgInfo">
	/// [out] A pointer to memory in which to return an array of DBCOLUMNINFO structures. One structure is returned for each column in the
	/// rowset. The provider allocates memory for the structures and returns the address to this memory; the consumer releases this memory
	/// with <c>IMalloc::Free</c> when it no longer needs the column information. If *pcColumns is 0 on output or terminates due to an error,
	/// the provider does not allocate any memory and ensures that *prgInfo is a null pointer on output. For more information, see
	/// "DBCOLUMNINFO Structures" in the Comments section.
	/// </param>
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

	/// <summary>Gets a list of the parameters for the command, the parameter names, and the parameter types.</summary>
	/// <param name="cwp">The <see cref="ICommandWithParameters"/> instance.</param>
	/// <param name="prgParamInfo">
	/// <para>[out]</para>
	/// <para>
	/// A pointer to memory in which to return an array of parameter information structures. The command allocates memory for the array, as
	/// well as the strings, and returns the address to this memory. The consumer releases the array memory with <c>IMalloc::Free</c> when it
	/// no longer needs the parameter information. If *pcParams is zero on output or an error occurs, the provider does not allocate any
	/// memory and ensures that *prgParamInfo is a null pointer on output. Parameters are returned in ascending order according to the
	/// iOrdinal element of the PARAMINFO structure.
	/// </para>
	/// <para>Here is the DBPARAMINFO structure:</para>
	/// <para>The elements of this structure are used as described in the following table.</para>
	/// <list type="table">
	/// <listheader>
	/// <description>Element</description>
	/// <description>Description</description>
	/// </listheader>
	/// <item>
	/// <description><c>dwFlags</c></description>
	/// <description>A bitmask describing parameter characteristics; these values have the following meaning:</description>
	/// </item>
	/// <item>
	/// <description><c>iOrdinal</c></description>
	/// <description>
	/// The ordinal of the parameter. Parameters are numbered from left to right as they appear in the command, with the first parameter in
	/// the command having an <c>iOrdinal</c> value of 1.
	/// </description>
	/// </item>
	/// <item>
	/// <description><c>pwszName</c></description>
	/// <description>
	/// The name of the parameter; it is a null pointer if there is no name. Names are normal names. The colon prefix (where used within SQL
	/// text) is stripped.
	/// </description>
	/// </item>
	/// <item>
	/// <description><c>pTypeInfo</c></description>
	/// <description><c>ITypeInfo</c> describes the type, if <c>pTypeInfo</c> is not a null pointer.</description>
	/// </item>
	/// <item>
	/// <description><c>ulParamSize</c></description>
	/// <description>
	/// The maximum possible length of a value in the parameter. For parameters that use a fixed-length data type, this is the size of the
	/// data type. For parameters that use a variable-length data type, this is one of the following: For data types that do not have a
	/// length, this is set to ~0 (bitwise, the value is not 0; all bits are set to 1).
	/// </description>
	/// </item>
	/// <item>
	/// <description><c>wType</c></description>
	/// <description>
	/// The indicator of the parameter's data type, or a type from which the data can be converted for the parameter if the provider cannot
	/// determine the exact data type of the parameter.
	/// </description>
	/// </item>
	/// <item>
	/// <description><c>bPrecision</c></description>
	/// <description>
	/// If <c>wType</c> is a numeric type or DBTYPE_DBTIMESTAMP, <c>bPrecision</c> is the maximum number of digits, expressed in base 10.
	/// Otherwise, this is ~0 (bitwise, the value is not 0; all bits are set to 1).
	/// </description>
	/// </item>
	/// <item>
	/// <description><c>bScale</c></description>
	/// <description>
	/// If <c>wType</c> is a numeric type with a fixed scale or if <c>wType</c> is DBTYPE_DBTIMESTAMP, <c>bScale</c> is the number of digits
	/// to the right (if <c>bScale</c> is positive) or left (if <c>bScale</c> is negative) of the decimal point. Otherwise, this is ~0
	/// (bitwise, the value is not 0; all bits are set to 1).
	/// </description>
	/// </item>
	/// </list>
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
	/// <para>E_INVALIDARG pcParams or prgParamInfo was a null pointer.</para>
	/// </description>
	/// </item>
	/// <item>
	/// <description>
	/// <para>
	/// E_OUTOFMEMORY The provider was unable to allocate sufficient memory in which to return the parameter data array or parameter names.
	/// </para>
	/// </description>
	/// </item>
	/// <item>
	/// <description>
	/// <para>
	/// DB_E_NOCOMMAND The provider can derive parameter information. However, no command text was currently set on the command object and no
	/// parameter information had been specified with <c>ICommandWithParameters::SetParameterInfo</c>.
	/// </para>
	/// </description>
	/// </item>
	/// <item>
	/// <description>
	/// <para>
	/// DB_E_NOTPREPARED The provider can derive parameter information, and it supports command preparation. However, the command was in an
	/// unprepared state and no parameter information was specified with <c>ICommandWithParameters::SetParameterInfo</c>.
	/// </para>
	/// </description>
	/// </item>
	/// <item>
	/// <description>
	/// <para>
	/// DB_E_PARAMUNAVAILABLE The provider cannot derive parameter information from the command, and
	/// <c>ICommandWithParameters::SetParameterInfo</c> has not been called.
	/// </para>
	/// </description>
	/// </item>
	/// </list>
	/// <para>Comments</para>
	/// <para>This method makes no logical change to the state of the object.</para>
	/// <para>
	/// If <c>ICommandWithParameters::SetParameterInfo</c> has not been called for any parameters or
	/// <c>ICommandWithParameters::SetParameterInfo</c> has been called with cParams equal to zero,
	/// <c>ICommandWithParameters::GetParameterInfo</c> returns information about the parameters only if the provider can derive parameter
	/// information. If the provider cannot derive parameter information, <c>ICommandWithParameters::GetParameterInfo</c> returns DB_E_PARAMUNAVAILABLE.
	/// </para>
	/// <para>
	/// If <c>ICommandWithParameters::SetParameterInfo</c> has been called for at least one parameter,
	/// <c>ICommandWithParameters::GetParameterInfo</c> returns the parameter information only for those parameters for which
	/// <c>SetParameterInfo</c> has been called. The provider does not return a warning in this case because it often cannot determine the
	/// number of parameters and therefore cannot determine whether it has returned information for all parameters. It is provider-specific
	/// whether or not the provider also returns derived information about the parameters for which
	/// <c>ICommandWithParameters::SetParameterInfo</c> was not called. For performance reasons, even providers that can derive this
	/// additional parameter information will usually return only the information that was specified when
	/// <c>ICommandWithParameters::SetParameterInfo</c> was called.
	/// </para>
	/// <para>
	/// <para>Note</para>
	/// <para>
	/// Providers are permitted to overwrite parameter information set by the consumer with the actual parameter information for the
	/// statement or stored procedure. However, they are not encouraged to do so if such validation requires a round-trip to the server.
	/// Consumers must not rely on providers to validate parameter information in this manner.
	/// </para>
	/// </para>
	/// </returns>
	// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/ms714917(v=vs.85) HRESULT GetParameterInfo ( DB_UPARAMS *pcParams,
	// DBPARAMINFO **prgParamInfo, OLECHAR **ppNamesBuffer);
	public static HRESULT GetParameterInfo(this ICommandWithParameters cwp, out DBPARAMINFO[] prgParamInfo)
	{
		var hr = cwp.GetParameterInfo(out var pcParams, out var p, out var names);
		prgParamInfo = hr.Succeeded ? p.ToArray<DBPARAMINFO>((int)pcParams) : [];
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

	/// <summary>Structure for <see cref="ICommandWithParameters.SetParameterInfo(DB_DWRESERVE, DB_DWRESERVE[], DBPARAMBINDINFO[])"/>.</summary>
	[PInvokeData("oledb.h")]
	[StructLayout(LayoutKind.Sequential)]
	public struct DBPARAMBINDINFO
	{
		/// <summary>
		/// <para>
		/// A pointer to the provider-specific name of the parameter's data type or a standard data type name. This name is not returned by
		/// ICommandWithParameters::GetParameterInfo; instead, the provider maps the data type specified by this name to an OLE DB type
		/// indicator and returns that type indicator. For a list of standard data type names, see "Comments" below.
		/// </para>
		/// <para>
		/// If pwszDataSourceType is null, the provider attempts a default conversion from the data type specified in the binding for the
		/// parameter or returns E_INVALIDARG if it cannot perform default parameter conversions.
		/// </para>
		/// </summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string? pwszDataSourceType;

		/// <summary>
		/// <para>The name of the parameter. This is a null pointer if the parameter does not have a name.</para>
		/// <para>
		/// The consumer must specify a name for all or none of the parameters set at any time. If the provider does not support named
		/// parameters, this argument is ignored and the provider is not required to verify that all or none of the parameters are named.
		/// </para>
		/// </summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string? pwszName;

		/// <summary>
		/// <para>
		/// The maximum possible length of a value in the parameter. For parameters that use a fixed-length data type, this is the size of
		/// the data type. For parameters that use a variable-length data type, this is one of the following:
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// The maximum length of the parameters in characters (for DBTYPE_STR and DBTYPE_WSTR) or in bytes (for DBTYPE_BYTES and
		/// DBTYPE_VARNUMERIC), if one is defined. For example, a parameter for a CHAR(5) column in an SQL table has a maximum length of 5.
		/// </item>
		/// <item>
		/// The maximum length of the data type in characters (for DBTYPE_STR and DBTYPE_WSTR) or in bytes (for DBTYPE_BYTES and
		/// DBTYPE_VARNUMERIC), if the parameter does not have a defined length.
		/// </item>
		/// <item>
		/// ~0 (bitwise, the value is not 0; all bits are set to 1) if neither the parameter nor the data type has a defined maximum length.
		/// </item>
		/// </list>
		/// <para>For data types that do not have a length, this is set to ~0 (bitwise, the value is not 0; all bits are set to 1).</para>
		/// <para>This argument is ignored if pwszDataSourceType is null.</para>
		/// </summary>
		public DBLENGTH ulParamSize;

		/// <summary>See the dwFlags element of the DBPARAMINFO structure in GetParameterInfo.</summary>
		public DBPARAMFLAGS dwFlags;

		/// <summary>
		/// <para>
		/// If pwszDataSourceType is DBTYPE_DBTIMESTAMP or a numeric type, bPrecision is the maximum number of digits, expressed in base 10.
		/// Otherwise, it is ignored.
		/// </para>
		/// <para>This argument is ignored if pwszDataSourceType is null.</para>
		/// </summary>
		public byte bPrecision;

		/// <summary>
		/// <para>
		/// If pwszDataSourceType is a numeric type with a fixed scale or if wType is DBTYPE_DBTIMESTAMP, bScale is the number of digits to
		/// the right (if bScale is positive) or left (if bScale is negative) of the decimal point. Otherwise, it is ignored.
		/// </para>
		/// <para>This argument is ignored if pwszDataSourceType is null.</para>
		/// </summary>
		public byte bScale;
	}
}