namespace Vanara.PInvoke;

/// <summary>Items from the OleDb.dll.</summary>
public static partial class OleDb
{
	/// <summary>A flag that specifies the result of the comparison.</summary>
	[PInvokeData("oledb.h")]
	public enum DBCOMPARE
	{
		/// <summary>The first bookmark is before the second.</summary>
		DBCOMPARE_LT = 0,
		/// <summary>The two bookmarks are equal.</summary>
		DBCOMPARE_EQ = (DBCOMPARE_LT + 1),
		/// <summary>The first bookmark is after the second.</summary>
		DBCOMPARE_GT = (DBCOMPARE_EQ + 1),
		/// <summary>The bookmarks are not equal and not ordered.</summary>
		DBCOMPARE_NE = (DBCOMPARE_GT + 1),
		/// <summary>
		/// <para>The two bookmarks cannot be compared. When to return DBCOMPARE_NOTCOMPARABLE:</para>
		/// <list type="bullet">
		/// <item>
		/// When calling IRowsetLocate::Compare, the consumer passed a bookmark for a row that does not belong to the chapter designated by
		/// hChapter. This bookmark could have been handed out on the base rowset or on another chapter for this rowset.
		/// </item>
		/// <item>
		/// The provider supports key value bookmarks, and one of the bookmarks passed to IRowsetLocate::Compare is now disassociated from
		/// the row due to a prior update of a key value.
		/// </item>
		/// </list>
		/// </summary>
		DBCOMPARE_NOTCOMPARABLE = (DBCOMPARE_NE + 1)
	}

	/// <summary>A bitmask describing the options of the range.</summary>
	[PInvokeData("oledb.h")]
	[Flags]
	public enum DBRANGE : uint
	{
		/// <summary>The start boundary is inclusive (the default).</summary>
		DBRANGE_INCLUSIVESTART = 0,
		/// <summary>The end boundary is inclusive (the default).</summary>
		DBRANGE_INCLUSIVEEND = 0,
		/// <summary>The start boundary is exclusive.</summary>
		DBRANGE_EXCLUSIVESTART = 0x1,
		/// <summary>The end boundary is exclusive.</summary>
		DBRANGE_EXCLUSIVEEND = 0x2,
		/// <summary>Exclude NULLs from the range.</summary>
		DBRANGE_EXCLUDENULLS = 0x4,
		/// <summary>
		/// Use *pStartData as a prefix. pEndData must be a null pointer. Prefix matching can be specified entirely using the inclusive and
		/// exclusive flags. However, because prefix matching is an important common case, this flag enables the consumer to specify only the
		/// *pStartData values and enables the provider to interpret this request quickly.
		/// </summary>
		DBRANGE_PREFIX = 0x8,
		/// <summary>
		/// Set the range to all keys that match *pStartData. *pStartData must specify a full key. pEndData must be a null pointer. Used for
		/// fast equality match.
		/// </summary>
		DBRANGE_MATCH = 0x10,
		/// <summary>Equal to 24 to indicate the number of bits to shift to get the number N.</summary>
		DBRANGE_MATCH_N_SHIFT = 0x18,
		/// <summary>Equal to 0xff.</summary>
		DBRANGE_MATCH_N_MASK = 0xff
	}

	/// <summary>A bitmask describing the options for the IRowsetIndex::Seek method.</summary>
	[PInvokeData("oledb.h")]
	[Flags]
	public enum DBSEEK : uint
	{
		/// <summary/>
		DBSEEK_INVALID = 0,
		/// <summary>First key with values equal to the values in *pData, in index order.</summary>
		DBSEEK_FIRSTEQ = 0x1,
		/// <summary>Last key with values equal to the values in *pData.</summary>
		DBSEEK_LASTEQ = 0x2,
		/// <summary>
		/// Last key with values equal to the values in *pData or, if there are no keys equal to the values in *pData, first key with values
		/// after the values in *pData, in index order.
		/// </summary>
		DBSEEK_AFTEREQ = 0x4,
		/// <summary>First key with values following the values in *pData, in index order.</summary>
		DBSEEK_AFTER = 0x8,
		/// <summary>
		/// First key with values equal to the values in *pData or, if there are no keys equal to the values in *pData, last key with values
		/// before the values in *pData, in index order.
		/// </summary>
		DBSEEK_BEFOREEQ = 0x10,
		/// <summary>Last key with values before the values in *pData, in index order.</summary>
		DBSEEK_BEFORE = 0x20
	}

	/// <summary>
	/// The <c>IRow</c> interface allows a consumer to read column data from a row object or to obtain the source rowset of the row object.
	/// </summary>
	// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/ms721261(v=vs.85)
	[ComImport, Guid("0c733ab4-2a1c-11ce-ade5-00aa0044773d"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IRow
	{
		/// <summary>Retrieves the values of one or more named columns from the row object.</summary>
		/// <param name="cColumns">
		/// [in] Count of columns specified in the rgColumns array. If cColumns is zero, no columns are created or updated.
		/// </param>
		/// <param name="rgColumns">
		/// [in/out] A caller-supplied array of DBCOLUMNACCESS structures. The DBCOLUMNACCESS structure is defined as follows:
		/// </param>
		/// <returns>
		/// <list type="bullet">
		/// <item>
		/// <description>
		/// <para>S_OK The provider successfully retrieved all of the columns.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>E_INVALIDARG rgColumns was a null pointer, and cColumns was not zero.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_SEC_E_PERMISSIONDENIED The provider was unable to access any of the columns.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// DB_E_ERRORSOCCURRED The provider was unable to retrieve any of the specified columns. The caller should check dwStatus of each
		/// element of rgColumns to determine why each column was not retrieved.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// DB_S_ERRORSOCCURRED The provider was unable to retrieve some of the specified columns. The caller should check dwStatus of each
		/// element of rgColumns to determine whether a column was retrieved.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// DB_E_DELETEDROW The row was either a pending delete row or a row for which a deletion had already been transmitted to the data store.
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
		/// <para>E_UNEXPECTED <c>ITransaction::Commit</c> or <c>ITransaction::Abort</c> was called, and the object is in a zombie state.</para>
		/// </description>
		/// </item>
		/// </list>
		/// </returns>
		// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/ms718107(v=vs.85) HRESULT GetColumns( DBORDINAL cColumns,
		// DBCOLUMNACCESS rgColumns[ ] );
		[PreserveSig]
		HRESULT GetColumns(DBORDINAL cColumns, [In, Out] DBCOLUMNACCESS[] rgColumns);

		/// <summary>Returns an interface pointer on the rowset that contains the row represented by a row object.</summary>
		/// <param name="riid">
		/// [in] The interface ID (IID) of the requested interface to return in ppRowset. This argument is ignored if ppRowset is a null pointer.
		/// </param>
		/// <param name="ppRowset">
		/// [out] A pointer to memory in which to return the interface for the rowset. If the caller sets ppRowset to a null pointer, no
		/// rowset is returned. If the provider does not have a rowset object as the source for the row, it sets *ppRowset to a null pointer.
		/// If <c>IRow::GetSourceRowset</c> fails, the provider must attempt to set *ppRowset to a null pointer.
		/// </param>
		/// <param name="phRow">
		/// [out] A pointer to memory in which to return the row handle of this row within the source rowset. If phRow is a null pointer, no
		/// row handle is returned. If the provider does not have a rowset object as the source for the row, it sets *phRow to NULL. If
		/// <c>IRow::GetSourceRowset</c> fails, the provider must attempt to set *phRow to NULL.
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
		/// DB_E_DELETEDROW The row was either a pending delete row or a row for which a deletion had already been transmitted to the data store.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// DB_E_NOSOURCEOBJECT The provider did not have a rowset object as the source for the row. Therefore, it set *ppRowset and *phRow
		/// to NULL.
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
		/// <para>E_INVALIDARG ppRowSet and phRow were null pointers.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>E_NOINTERFACE The rowset did not support the interface specified in riid.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>E_UNEXPECTED <c>ITransaction::Commit</c> or <c>ITransaction::Abort</c> was called, and the object is in a zombie state.</para>
		/// </description>
		/// </item>
		/// </list>
		/// </returns>
		// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/ms725450(v=vs.85) HRESULT GetSourceRowset( REFIID riid,
		// IUnknown **ppRowset, HROW *phRow );
		[PreserveSig]
		HRESULT GetSourceRowset(in Guid riid, [MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 0)] out object? ppRowset, out HROW phRow);

		/// <summary>
		/// Returns an interface pointer to be used to access an object-valued column. <c>IRow::Open</c> will generally return a rowset, row,
		/// or stream object, allowing the provider to create the appropriate object for tabular columns and streams. The returned object
		/// inherits the access privileges from the original flags used for binding to the row. <c>IRow::Open</c> can also return an
		/// interface pointer to a child rowset when called on a chapter-valued column.
		/// </summary>
		/// <param name="pUnkOuter">
		/// [in] The controlling <c>IUnknown</c> if the returned interface is to be aggregated; otherwise, a null pointer.
		/// </param>
		/// <param name="pColumnID">
		/// [in] A pointer to a DBID containing the name of the column to open. Must not be a null pointer. When a chapter-valued column,
		/// rguidColumnType must be DBGUID_ROWSET and riid should be a rowset interface.
		/// </param>
		/// <param name="rguidColumnType">
		/// <para>
		/// [in] A pointer to a GUID that identifies the type of object to be opened from this column. If the GUID does not match the column
		/// type, DB_E_OBJECTMISMATCH is returned. Possible values are described in the following table.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <description>Object type</description>
		/// <description>Description</description>
		/// </listheader>
		/// <item>
		/// <description>DBGUID_STREAM</description>
		/// <description>Column contains a stream of binary data. Use <c>IStream</c> or <c>ISequentialStream</c>.</description>
		/// </item>
		/// <item>
		/// <description>DBGUID_ROW</description>
		/// <description>Column contains a nested collection of columns. Use <c>IRow</c>.</description>
		/// </item>
		/// <item>
		/// <description>DBGUID_ROWSET</description>
		/// <description>Column contains a nested rowset. Use <c>IRowset</c>.</description>
		/// </item>
		/// <item>
		/// <description>GUID_NULL</description>
		/// <description>Column contains a COM object. Open the object as its native type, and return the interface specified by <c>riid</c>.</description>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="dwBindFlags">[in] Reserved for flags to control the open operation. Must be zero.</param>
		/// <param name="riid">[in] Interface ID of the interface pointer to be returned.</param>
		/// <param name="ppUnk">
		/// [out] A pointer to memory in which to return the requested interface pointer. If an error code is returned and ppUnk is not a
		/// null pointer, *ppUnk should be set to NULL.
		/// </param>
		/// <returns>
		/// <list type="bullet">
		/// <item>
		/// <description>
		/// <para>S_OK The object was successfully opened. The caller becomes responsible for releasing the returned interface pointer.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// DB_E_BADCOLUMNID pColumnID was an invalid DBID or a shortcut DBID, such as DBROWCOL_DEFAULTSTREAM, that does not exist on this row.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// DB_E_COLUMNUNAVAILABLE Requested column is valid, but could not be retrieved. The caller should check that the DBPROP_ACCESSORDER
		/// property is compatible with this operation.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// DB_E_DELETEDROW The row is either a pending delete row or a row for which a deletion had already been transmitted to the data store.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_E_NOAGGREGATION pUnkOuter was not a null pointer, and riid was not IID_IUnknown.</para>
		/// <para>The provider does not support aggregation.</para>
		/// <para>The object has already been created.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_E_NOTFOUND The data value of this column is NULL.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_E_OBJECTMISMATCH rguidColumnType pointed to a GUID that did not match the object type of this column.</para>
		/// <para>pcolumnID is a chapter-valued column, and rguidColumnType is not DBGUID_ROWSET.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// DB_E_OBJECTOPEN The provider can support only a single open storage object at a time (DBPROP_MULTIPLESTORAGEOBJECTS =
		/// VARIANT_FALSE) and already has a storage object open.
		/// </para>
		/// <para>The provider would have to open a new connection to support the operation, and DBPROP_MULTIPLECONNECTIONS is set to VARIANT_FALSE.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>E_FAIL A provider-specific error occurred.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>E_INVALIDARG pColumnID or ppUnk was a null pointer.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>E_NOINTERFACE The object does not support the interface requested in riid, or riid was IID_NULL.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>E_UNEXPECTED <c>ITransaction::Commit</c> or <c>ITransaction::Abort</c> was called, and the object is in a zombie state.</para>
		/// </description>
		/// </item>
		/// </list>
		/// </returns>
		// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/ms716947(v=vs.85) HRESULT Open( IUnknown *pUnkOuter, DBID
		// *pColumnID, REFGUID rguidColumnType, DWORD dwFlags, REFIID riid, IUnknown **ppUnk );
		[PreserveSig]
		HRESULT Open([In, Optional, MarshalAs(UnmanagedType.IUnknown)] object? pUnkOuter, in DBID pColumnID, in Guid rguidColumnType,
			[In, Optional] uint dwBindFlags, in Guid riid, [MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 4)] out object? ppUnk);
	}

	/// <summary>The <c>IRowChange</c> interface allows a consumer to quickly set columns of a row.</summary>
	// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/ms716799(v=vs.85)
	[PInvokeData("oledb.h")]
	[ComImport, Guid("0c733ab5-2a1c-11ce-ade5-00aa0044773d"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IRowChange
	{
		/// <summary>Sets the values of one or more named columns of a row object.</summary>
		/// <param name="cColumns">[in] Count of columns specified in the rgColumns array. If cColumns is zero, no columns are set.</param>
		/// <param name="rgColumns">
		/// <para>
		/// [ ] [in/out] A caller-supplied array of DBCOLUMNACCESS structures. The DBCOLUMNACCESS structure is described in the reference
		/// entry for IRow::GetColumns.
		/// </para>
		/// <para>
		/// For setting column values, the elements of each DBCOLUMNACCESS structure are used in the manner described in the following table.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <description>Element</description>
		/// <description>Description</description>
		/// </listheader>
		/// <item>
		/// <description><c>columnid</c></description>
		/// <description>Unique DBID that identifies the column to be accessed.</description>
		/// </item>
		/// <item>
		/// <description><c>wType</c></description>
		/// <description>Identifies the type of the value pointed to by <c>pData</c>.</description>
		/// </item>
		/// <item>
		/// <description><c>pData</c></description>
		/// <description>
		/// Caller-allocated pointer to storage of the data type specified by <c>wType</c>. On input, the area pointed to contains the value
		/// of the column specified by <c>columnid</c>. The caller must allocate and initialize the area of storage pointed to by
		/// <c>pData</c>. The provider should attempt to coerce the value from <c>wType</c> to the underlying value of the column. If
		/// <c>wType</c> is DBTYPE_VARIANT, the provider is responsible for allocating any variable-length storage pointed to by the VARIANT.
		/// </description>
		/// </item>
		/// <item>
		/// <description><c>cbMaxLen</c></description>
		/// <description>
		/// The maximum length of the caller-initialized memory pointed to by <c>pData</c>. The provider checks the length in bytes of
		/// variable-length data types against <c>cbMaxLen</c>. If the length is greater than <c>cbMaxLen</c>, this is an error and the
		/// provider sets the status to DBSTATUS_E_CANTCONVERTVALUE.
		/// </description>
		/// </item>
		/// <item>
		/// <description><c>bPrecision</c></description>
		/// <description>Indicates the precision of the value stored in <c>*pData</c> for data types equiring precision.</description>
		/// </item>
		/// <item>
		/// <description><c>bScale</c></description>
		/// <description>Indicates the scale of the value stored in <c>*pData</c> for data types requiring scale.</description>
		/// </item>
		/// <item>
		/// <description><c>dwStatus</c></description>
		/// <description>
		/// On input, <c>dwStatus</c> indicates whether <c>pData</c> or some other value should be used. When value DBSTATUS_S_ISNULL is used
		/// to set the column to null, other fields ( <c>wType</c>, <c>pData</c>, <c>cbDataLen</c>) are ignored. On return, <c>dwStatus</c>
		/// indicates whether the field was successfully set. The following status values may apply when setting column values. For more
		/// information, see Status.
		/// </description>
		/// </item>
		/// <item>
		/// <description><c>cbDataLen</c></description>
		/// <description>On input, the length of the data value pointed to by <c>pData</c>. Ignored for fixed-length types.</description>
		/// </item>
		/// </list>
		/// </param>
		/// <returns>
		/// <list type="bullet">
		/// <item>
		/// <description>
		/// <para>S_OK The provider successfully set all of the columns.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>E_INVALIDARG cColumns was not zero, and rgColumns was a null pointer.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>E_OUTOFMEMORY The provider was unable to allocate sufficient memory for this operation.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// DB_S_ERRORSOCCURRED The provider was able to set at least one column but was unable to set at least one column. The caller should
		/// examine dwStatus of each element of rgColumns to determine whether, and why, an individual column was not set.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// DB_E_DELETEDROW The row is either a pending delete row or a row for which a deletion had already been transmitted to the data store.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// DB_E_ERRORSOCCURRED An error occurred while setting data for one or more columns, and data was not successfully set for any
		/// columns. The caller should examine dwStatus of each element of rgColumns to determine why each individual column was not set.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// DB_E_NEWLYINSERTED The value of the DBPROP_CHANGEINSERTEDROWS property on the source rowset was VARIANT_FALSE, and the method was
		/// called on a row for which the insertion has been transmitted to the data store.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_SEC_E_PERMISSIONDENIED The provider was unable to set any columns because of a permission failure.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>E_FAIL A provider-specific error occurred. No columns were set.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>E_UNEXPECTED <c>ITransaction::Commit</c> or <c>ITransaction::Abort</c> was called, and the object is in a zombie state.</para>
		/// </description>
		/// </item>
		/// </list>
		/// </returns>
		// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/ms714307(v=vs.85) HRESULT SetColumns( DBORDINAL cColumns,
		// DBCOLUMNACCESS rgColumns[ ] );
		[PreserveSig]
		HRESULT SetColumns(DBORDINAL cColumns, [In, MarshalAs(UnmanagedType.LPArray)] DBCOLUMNACCESS[] rgColumns);
	}

	/// <summary/>
	[PInvokeData("oledb.h")]
	[ComImport, Guid("0c733aae-2a1c-11ce-ade5-00aa0044773d"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IRowSchemaChange : IRowChange
	{
		/// <summary>Sets the values of one or more named columns of a row object.</summary>
		/// <param name="cColumns">[in] Count of columns specified in the rgColumns array. If cColumns is zero, no columns are set.</param>
		/// <param name="rgColumns">
		/// <para>
		/// [ ] [in/out] A caller-supplied array of DBCOLUMNACCESS structures. The DBCOLUMNACCESS structure is described in the reference
		/// entry for IRow::GetColumns.
		/// </para>
		/// <para>
		/// For setting column values, the elements of each DBCOLUMNACCESS structure are used in the manner described in the following table.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <description>Element</description>
		/// <description>Description</description>
		/// </listheader>
		/// <item>
		/// <description><c>columnid</c></description>
		/// <description>Unique DBID that identifies the column to be accessed.</description>
		/// </item>
		/// <item>
		/// <description><c>wType</c></description>
		/// <description>Identifies the type of the value pointed to by <c>pData</c>.</description>
		/// </item>
		/// <item>
		/// <description><c>pData</c></description>
		/// <description>
		/// Caller-allocated pointer to storage of the data type specified by <c>wType</c>. On input, the area pointed to contains the value
		/// of the column specified by <c>columnid</c>. The caller must allocate and initialize the area of storage pointed to by
		/// <c>pData</c>. The provider should attempt to coerce the value from <c>wType</c> to the underlying value of the column. If
		/// <c>wType</c> is DBTYPE_VARIANT, the provider is responsible for allocating any variable-length storage pointed to by the VARIANT.
		/// </description>
		/// </item>
		/// <item>
		/// <description><c>cbMaxLen</c></description>
		/// <description>
		/// The maximum length of the caller-initialized memory pointed to by <c>pData</c>. The provider checks the length in bytes of
		/// variable-length data types against <c>cbMaxLen</c>. If the length is greater than <c>cbMaxLen</c>, this is an error and the
		/// provider sets the status to DBSTATUS_E_CANTCONVERTVALUE.
		/// </description>
		/// </item>
		/// <item>
		/// <description><c>bPrecision</c></description>
		/// <description>Indicates the precision of the value stored in <c>*pData</c> for data types equiring precision.</description>
		/// </item>
		/// <item>
		/// <description><c>bScale</c></description>
		/// <description>Indicates the scale of the value stored in <c>*pData</c> for data types requiring scale.</description>
		/// </item>
		/// <item>
		/// <description><c>dwStatus</c></description>
		/// <description>
		/// On input, <c>dwStatus</c> indicates whether <c>pData</c> or some other value should be used. When value DBSTATUS_S_ISNULL is used
		/// to set the column to null, other fields ( <c>wType</c>, <c>pData</c>, <c>cbDataLen</c>) are ignored. On return, <c>dwStatus</c>
		/// indicates whether the field was successfully set. The following status values may apply when setting column values. For more
		/// information, see Status.
		/// </description>
		/// </item>
		/// <item>
		/// <description><c>cbDataLen</c></description>
		/// <description>On input, the length of the data value pointed to by <c>pData</c>. Ignored for fixed-length types.</description>
		/// </item>
		/// </list>
		/// </param>
		/// <returns>
		/// <list type="bullet">
		/// <item>
		/// <description>
		/// <para>S_OK The provider successfully set all of the columns.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>E_INVALIDARG cColumns was not zero, and rgColumns was a null pointer.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>E_OUTOFMEMORY The provider was unable to allocate sufficient memory for this operation.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// DB_S_ERRORSOCCURRED The provider was able to set at least one column but was unable to set at least one column. The caller should
		/// examine dwStatus of each element of rgColumns to determine whether, and why, an individual column was not set.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// DB_E_DELETEDROW The row is either a pending delete row or a row for which a deletion had already been transmitted to the data store.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// DB_E_ERRORSOCCURRED An error occurred while setting data for one or more columns, and data was not successfully set for any
		/// columns. The caller should examine dwStatus of each element of rgColumns to determine why each individual column was not set.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// DB_E_NEWLYINSERTED The value of the DBPROP_CHANGEINSERTEDROWS property on the source rowset was VARIANT_FALSE, and the method was
		/// called on a row for which the insertion has been transmitted to the data store.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_SEC_E_PERMISSIONDENIED The provider was unable to set any columns because of a permission failure.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>E_FAIL A provider-specific error occurred. No columns were set.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>E_UNEXPECTED <c>ITransaction::Commit</c> or <c>ITransaction::Abort</c> was called, and the object is in a zombie state.</para>
		/// </description>
		/// </item>
		/// </list>
		/// </returns>
		// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/ms714307(v=vs.85) HRESULT SetColumns( DBORDINAL cColumns,
		// DBCOLUMNACCESS rgColumns[ ] );
		[PreserveSig]
		new HRESULT SetColumns(DBORDINAL cColumns, [In, MarshalAs(UnmanagedType.LPArray)] DBCOLUMNACCESS[] rgColumns);

		/// <summary>
		/// Deletes one or more named columns from a row. For row-specific columns of a row that is in immediate update mode, this is an
		/// immediate schema operation.
		/// </summary>
		/// <param name="cColumns">
		/// [in] Count of column names specified in the rgColumnIDs array. If cColumns is zero, no column values are deleted.
		/// </param>
		/// <param name="rgColumnIDs">
		/// [ ] [in] Consumer-allocated array of cColumns names of the columns to be deleted. It is not necessary to specify columns in any
		/// particular order in the array. If cColumns is zero, rgColumnIDs is ignored. If cColumns is not zero and rgColumnIDs is a null
		/// pointer, the provider returns E_INVALIDARG. It is not an error if a column name is specified more than once.
		/// </param>
		/// <param name="rgdwStatus">
		/// <para>
		/// [ ] [in/out] Optional consumer-allocated array of cColumns status fields indicating whether the value of the corresponding
		/// element of rgColumnIDs was deleted*.* Consumers not interested in receiving status may set rgdwStatus to null. The status fields
		/// described in the following table apply to the deletion of column values.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <description>Status field</description>
		/// <description>Description</description>
		/// </listheader>
		/// <item>
		/// <description>DBSTATUS_S_OK</description>
		/// <description>Indicates that the column value was deleted.</description>
		/// </item>
		/// <item>
		/// <description>DBROWSTATUS_S_ROWSETCOLUMN</description>
		/// <description>
		/// Providers may return this status flag when asked to delete a rowset column from a row. The value is actually nulled, but the
		/// column remains in the row and rowset.
		/// </description>
		/// </item>
		/// <item>
		/// <description>DBSTATUS_E_DOESNOTEXIST</description>
		/// <description>Indicates that the column does not exist on this row.</description>
		/// </item>
		/// <item>
		/// <description>DBSTATUS_E_PERMISSIONDENIED</description>
		/// <description>The consumer did not have sufficient permission to delete the column.</description>
		/// </item>
		/// </list>
		/// <para>The order of status elements must match the order of the column names in rgColumnIDs.</para>
		/// <para>For more information, see Status.</para>
		/// </param>
		/// <returns>
		/// <list type="bullet">
		/// <item>
		/// <description>
		/// <para>S_OK The provider successfully deleted values for all of the requested column names.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>E_INVALIDARG cColumns was not zero, and rgColumnIDs was a null pointer.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_SEC_E_PERMISSIONDENIED The provider was unable to delete any column values because of a permission failure.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// DB_S_ERRORSOCCURRED The provider was able to delete at least one column value but was unable to delete at least one column value.
		/// The caller should examine each element of rgdwStatus to determine whether, and why, an individual column was not set.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_E_DELETEDROW The row has been deleted or moved. (A delete either is pending or has been transmitted to the data store.)</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// DB_E_ERRORSOCCURRED The provider was unable to delete values of any of the named columns. The caller should examine each element
		/// of rgdwStatus to determine why each individual column was not set.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// DB_E_NEWLYINSERTED DBPROP_CHANGEINSERTEDROWS on the source rowset was VARIANT_FALSE, and the method was called on a row for which
		/// the insertion has been transmitted to the data store.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>E_FAIL A provider-specific error occurred. No columns were deleted.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>E_UNEXPECTED <c>ITransaction::Commit</c> or <c>ITransaction::Abort</c> was called, and the object is in a zombie state.</para>
		/// </description>
		/// </item>
		/// </list>
		/// </returns>
		// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/ms718065(v=vs.85) HRESULT DeleteColumns( DBORDINAL cColumns,
		// const DBID rgColumnIDs[ ], DBSTATUS rgdwStatus[ ] );
		[PreserveSig]
		HRESULT DeleteColumns(DBORDINAL cColumns, [In, Optional] DBID[]? rgColumnIDs, [In, Out, Optional] DBSTATUS[]? rgdwStatus);

		/// <summary>
		/// Creates or sets the values of one or more named columns of a row object. If the columns do not already exist, they are created.
		/// </summary>
		/// <param name="cColumns">
		/// [in] Count of columns specified in the rgNewColumnInfo array. If cColumns is zero, no columns are created or set.
		/// </param>
		/// <param name="rgNewColumnInfo">
		/// <para>
		/// [in] A consumer-allocated array of cColumns DBCOLUMNINFO structures that define the additional columns to be added to the row
		/// object. If cColumns is zero, rgNewColumnInfo is ignored. The order of columns in rgColumns must match the order of columns in rgNewColumnInfo.
		/// </para>
		/// <para>
		/// <para>Note</para>
		/// <para>For information about DBCOLUMNINFO structures, see IColumnsInfo::GetColumnInfo.</para>
		/// </para>
		/// <para>The following table lists special instructions for defining row columns using DBCOLUMNINFO.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Element</description>
		/// <description>Instructions for row columns</description>
		/// </listheader>
		/// <item>
		/// <description><c>pwszName</c></description>
		/// <description>Ignored on input when creating columns with <c>AddColumns</c>.</description>
		/// </item>
		/// <item>
		/// <description><c>iOrdinal</c></description>
		/// <description>Ignored on input when creating columns with <c>AddColumns</c>.</description>
		/// </item>
		/// <item>
		/// <description><c>dwFlags</c></description>
		/// <description>
		/// A bitmask that describes consumer-specified row column characteristics. The DBCOLUMNFLAGS enumerated type specifies the bits in
		/// the bitmask, which are described in the reference entry for IColumnsInfo::GetColumnInfo. The following flag values may apply when
		/// creating row columns:
		/// </description>
		/// </item>
		/// <item>
		/// <description><c>ulColumnSize</c></description>
		/// <description>
		/// Minimum size required to store the consumer's largest data for this column. For fixed-length data types, this is the size of the
		/// data type in bytes. For variable-length data types, this is the maximum number of bytes (for DBTYPE_BYTES) or characters (for
		/// DBTYPE_STR or DBTYPE_WSTR). For more information, see the description of DBCOLUMNINFO in the reference entry for IColumnsInfo::GetColumnInfo.
		/// </description>
		/// </item>
		/// <item>
		/// <description><c>wType</c></description>
		/// <description>Requested DBTYPE data type for this column.</description>
		/// </item>
		/// <item>
		/// <description><c>bPrecision</c></description>
		/// <description>Maximum precision of the column.</description>
		/// </item>
		/// <item>
		/// <description><c>bScale</c></description>
		/// <description>Number of digits to the right of the decimal point.</description>
		/// </item>
		/// <item>
		/// <description><c>columnid</c></description>
		/// <description>
		/// Unique DBID used to name this row column. For example, if columns are named ( <c>eKind</c> is DBKIND_NAME), <c>uName.pwszName</c>
		/// points to the column name.
		/// </description>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="rgColumns">
		/// <para>[in/out] An optional consumer-allocated array of cColumns DBCOLUMNACCESS structures.</para>
		/// <para>
		/// <para>Note</para>
		/// <para>The DBCOLUMNACCESS structure is described in the reference entry for IRow::GetColumns.</para>
		/// </para>
		/// <para>
		/// The order of columns in rgColumns must match the order of columns in rgNewColumnInfo. If rgColumns is a null pointer, new columns
		/// are created but no values are set (except for default values defined by the provider).
		/// </para>
		/// <para>
		/// For setting column values, the elements of each DBCOLUMNACCESS structure are used in the manner described in the following table.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <description>Element</description>
		/// <description>Description</description>
		/// </listheader>
		/// <item>
		/// <description><c>columnid</c></description>
		/// <description>
		/// This element is ignored by <c>AddColumns</c>. The column DBID is designated by the <c>columnid</c> element of the corresponding
		/// member of <c>rgNewColumnInfo</c>. (This is done so that consumers do not need to allocate two sets of DBIDs.)
		/// </description>
		/// </item>
		/// <item>
		/// <description><c>wType</c></description>
		/// <description>Identifies the type of the value pointed to by <c>pData</c>.</description>
		/// </item>
		/// <item>
		/// <description><c>pData</c></description>
		/// <description>
		/// Caller-allocated pointer to storage of the DBTYPE defined by <c>wType</c>. On input, the area pointed to contains the value of
		/// the column specified by the <c>columnid</c> element of <c>rgNewColumnInfo</c>. The caller must allocate and initialize the area
		/// of storage pointed to by <c>pData</c>. The provider should attempt to coerce the value from <c>wType</c> to the underlying value
		/// of the column. If <c>wType</c> is DBTYPE_VARIANT, the provider is responsible for allocating any variable-length storage pointed
		/// to by the VARIANT.
		/// </description>
		/// </item>
		/// <item>
		/// <description><c>cbMaxLen</c></description>
		/// <description>
		/// The maximum length of the caller-initialized memory pointed to by <c>pData</c>. The provider checks the length in bytes of
		/// variable-length data types against <c>cbMaxLen</c>. If the length is greater than <c>cbMaxLen</c>, this is an error and the
		/// provider sets the status to DBSTATUS_E_CANTCONVERTVALUE.
		/// </description>
		/// </item>
		/// <item>
		/// <description><c>bPrecision</c></description>
		/// <description>Indicates the precision of the value stored in <c>*pData</c> for data types requiring precision.</description>
		/// </item>
		/// <item>
		/// <description><c>bScale</c></description>
		/// <description>Indicates the scale of the value stored in <c>*pData</c> for data types requiring scale.</description>
		/// </item>
		/// <item>
		/// <description><c>dwStatus</c></description>
		/// <description>
		/// On input, <c>dwStatus</c> indicates whether <c>pData</c> or some other value should be used. All status values used in OLE DB for
		/// rowset columns apply to row columns. On input, if <c>dwStatus</c> is DBSTATUS_S_DEFAULT or DBSTATUS_S_IGNORE, the provider skips
		/// this column when setting data. On return, <c>dwStatus</c> indicates whether the field was successfully set. The following status
		/// values may apply when updating column values. Standard status values when setting data do apply in addition to those listed in
		/// the following table. For more information about Status, see Getting and Setting Data.)
		/// </description>
		/// </item>
		/// <item>
		/// <description><c>cbDataLen</c></description>
		/// <description>On input, the length of the data value pointed to by <c>pData</c>. Ignored for fixed-length types.</description>
		/// </item>
		/// </list>
		/// </param>
		/// <returns>
		/// <list type="bullet">
		/// <item>
		/// <description>
		/// <para>S_OK The provider successfully created or set the values of all of the columns.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>E_INVALIDARG cColumns was not zero, and rgNewColumnInfo was a null pointer.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>E_OUTOFMEMORY The provider was unable to allocate sufficient memory for this operation.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// DB_S_ERRORSOCCURRED The provider was able to add or set the value of at least one column but was unable to do so for at least one
		/// column. The caller should examine the dwStatus value of each element of rgColumns to determine whether, and why, an individual
		/// column was not set.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// DB_E_DELETEDROW The row is either a pending delete row or a row for which a deletion had already been transmitted to the data store.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// DB_E_ERRORSOCCURRED An error occurred while setting data for one or more columns, and data was not successfully set for any
		/// columns. The caller should examine the dwStatus value of each element of rgColumns to determine whether, and why, an individual
		/// column was not set.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// DB_E_NEWLYINSERTED DBPROP_CHANGEINSERTEDROWS on the source rowset was VARIANT_FALSE, and the method was called on a row for which
		/// the insertion has been transmitted to the data store.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_E_NOTSUPPORTED The provider does not support this method.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_SEC_E_PERMISSIONDENIED The provider was unable to set any columns due to a permission failure.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>E_FAIL A provider-specific error occurred. No columns were added.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>E_UNEXPECTED <c>ITransaction::Commit</c> or <c>ITransaction::Abort</c> was called, and the object is in a zombie state.</para>
		/// </description>
		/// </item>
		/// </list>
		/// </returns>
		// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/ms709723(v=vs.85) HRESULT AddColumns( DBORDINAL cColumns,
		// const DBCOLUMNINFO rgNewColumnInfo[ ], DBCOLUMNACCESS rgColumns[ ] );
		[PreserveSig]
		HRESULT AddColumns(DBORDINAL cColumns, [In, Optional] DBCOLUMNINFO[]? rgNewColumnInfo, [In, Out, Optional] DBCOLUMNACCESS[]? rgColumns);

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

	/// <summary>
	/// <para>
	/// <c>IRowsetBookmark</c> is an optional interface on the TRowset cotype that enables rowsets that support bookmarks to set the next
	/// fetch position based on a bookmark.
	/// </para>
	/// <para>
	/// When <c>IRowsetBookmark</c> is present on a rowset, column 0 is the bookmark for the rows. Reading this column will obtain a bookmark
	/// value that can be used to reposition to the same row. Support for <c>IRowsetBookmark</c> does not imply that <c>IRowsetLocate</c> is
	/// supported on the rowset, although it does not preclude it.
	/// </para>
	/// </summary>
	// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/ms714246(v=vs.85)
	[PInvokeData("oledb.h")]
	[ComImport, Guid("0c733ac2-2a1c-11ce-ade5-00aa0044773d"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IRowsetBookmark
	{
		/// <summary>Sets the next fetch position for the rowset to be immediately before the specified bookmark.</summary>
		/// <param name="hChapter">[in] The chapter handle. For nonchaptered rowsets, the caller must set hChapter to DB_NULL_HCHAPTER.</param>
		/// <param name="cbBookmark">[in] The length in bytes of the bookmark.</param>
		/// <param name="pBookmark">
		/// [in] A pointer to a bookmark that identifies the row to be used. The bookmark can be for a designated row or either DBBMK_FIRST
		/// or DBBMK_LAST.
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
		/// <para>E_INVALIDARG cbBookmark was zero.</para>
		/// <para>pBookmark was a null pointer.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>E_UNEXPECTED ITransaction::Commit or ITransaction::Abort was called, and the object is in a zombie state.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_E_BADBOOKMARK *pBookmark was invalid, incorrectly formed, or DBBMK_INVALID.</para>
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
		/// DB_E_NOTREENTRANT The provider called a method from IRowsetNotify (in the consumer) that had not yet returned, and the provider
		/// does not support reentrancy in this method.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// DB_E_ROWSNOTRELEASED The provider requires release of existing rows before new ones can be fetched. For more information, see
		/// DBPROP_CANHOLDROWS in Appendix C, "OLE DB Properties."
		/// </para>
		/// </description>
		/// </item>
		/// </list>
		/// </returns>
		// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/ms714382(v=vs.85) HRESULT PositionOnBookmark ( HCHAPTER
		// hChapter, DBBKMARK cbBookmark, const BYTE *pBookmark);
		[PreserveSig]
		HRESULT PositionOnBookmark(HCHAPTER hChapter, DBBKMARK cbBookmark, [In] IntPtr pBookmark);
	}

	/// <summary>
	/// <para>
	/// The methods in <c>IRowsetChange</c> are used to update the values of columns in existing rows, delete existing rows, and insert new rows.
	/// </para>
	/// <para><c>IRowsetChange</c> requires <c>IAccessor</c> and <c>IRowset</c>.</para>
	/// </summary>
	// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/ms715790(v=vs.85)
	[PInvokeData("oledb.h")]
	[ComImport, Guid("0c733a05-2a1c-11ce-ade5-00aa0044773d"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IRowsetChange
	{
		/// <summary>Deletes rows.</summary>
		/// <param name="hChapter">
		/// [in] The chapter handle. Providers are allowed to ignore this argument. For maximum interoperability, consumers should set
		/// hChapter to DB_NULL_HCHAPTER.
		/// </param>
		/// <param name="cRows">[in] The number of rows to be deleted. If cRows is zero, <c>IRowsetChange::DeleteRows</c> does not do anything.</param>
		/// <param name="rghRows">
		/// <para>[in] An array of handles of the rows to be deleted.</para>
		/// <para>
		/// If rghRows includes a duplicate row handle, <c>IRowsetChange::DeleteRows</c> behaves as follows. If the row handle is valid, it
		/// is provider-specific whether the returned row status information for each row or a single instance of the row is set to
		/// DBROWSTATUS_S_OK. If the row handle is invalid, the row status information for each occurrence of the row contains the
		/// appropriate error.
		/// </para>
		/// </param>
		/// <param name="rgRowStatus">
		/// [out] An array with cRows elements in which to return values indicating the status of each row specified in rghRows. If no errors
		/// or warnings occur while deleting a row, the corresponding element of rgRowStatus is set to DBROWSTATUS_S_OK. If a warning occurs
		/// while deleting a row, the corresponding element is set as specified in S_OK. If an error occurs while deleting a row, the
		/// corresponding element is set as specified in DB_S_ERRORSOCCURRED. The consumer allocates memory for this array. If rgRowStatus is
		/// a null pointer, no row status information is returned.
		/// </param>
		/// <returns>
		/// <list type="bullet">
		/// <item>
		/// <description>
		/// <para>S_OK The method succeeded. All rows were successfully deleted. The following values can be returned in rgRowStatus:</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// DB_S_ERRORSOCCURRED An error occurred while deleting a row, but at least one row was successfully deleted. Successes and warnings
		/// can occur for the reasons listed under S_OK. The following errors can occur:
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
		/// <para>E_INVALIDARG rghRows was a null pointer, and cRows was greater than or equal to one.</para>
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
		/// DB_E_ABORTLIMITREACHED The rowset was in immediate update mode, and the row was not deleted due to reaching a limit on the
		/// server, such as a query execution timing out.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_E_ERRORSOCCURRED Errors occurred while deleting all of the rows. Errors can occur for the reasons listed under DB_S_ERRORSOCCURRED.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// DB_E_NOTREENTRANT The consumer called this method while it was processing a notification, and it is an error to call this method
		/// while processing the specified DBREASON value.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_E_NOTSUPPORTED The provider does not support this method, or the corresponding bit of DBPROP_UPDATABILITY is not set.</para>
		/// </description>
		/// </item>
		/// </list>
		/// </returns>
		// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/ms724362(v=vs.85) HRESULT DeleteRows ( HCHAPTER hChapter,
		// DBCOUNTITEM cRows, const HROW rghRows[], DBROWSTATUS rgRowStatus[]);
		[PreserveSig]
		HRESULT DeleteRows(HCHAPTER hChapter, DBCOUNTITEM cRows, [In, MarshalAs(UnmanagedType.LPArray)] HROW[] rghRows,
			[Out, Optional, MarshalAs(UnmanagedType.LPArray)] DBROWSTATUS[]? rgRowStatus);

		/// <summary>
		/// <para>Sets data values in one or more columns in a row.</para>
		/// <para>
		/// <para>Note</para>
		/// <para><c>IRowsetChange::SetData</c> does not work in multi-threaded environments.</para>
		/// </para>
		/// </summary>
		/// <param name="hRow">[in] The handle of the row in which to set data.</param>
		/// <param name="hAccessor">
		/// [in] The handle of the accessor to use. If hAccessor is the handle of a null accessor (cBindings in
		/// <c>IAccessor::CreateAccessor</c> was zero), <c>IRowsetChange::SetData</c> does not set any data values.
		/// </param>
		/// <param name="pData">
		/// [in] A pointer to memory containing the new data values, at offsets that correspond to the bindings in the accessor.
		/// </param>
		/// <returns>
		/// <list type="bullet">
		/// <item>
		/// <description>
		/// <para>S_OK The method succeeded. The status of all columns bound by the accessor is set to DBSTATUS_S_OK or DBSTATUS_S_ISNULL.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// DB_S_ERRORSOCCURRED An error occurred while setting data for one or more columns, but data was successfully set for at least one
		/// column. To determine the columns for which data was returned, the consumer checks the status values. For a list of status values
		/// that can be returned by this method, see "Status Values Used When Setting Data" in Status.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// DB_S_MULTIPLECHANGES The rowset was in immediate update mode, and updating the row caused more than one row to be updated in the
		/// data store. For more information, see DBPROP_REPORTMULTIPLECHANGES in Rowset Property Group in Appendix C.
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
		/// DB_E_ABORTLIMITREACHED The rowset was in immediate update mode, and the row was not updated due to reaching a limit on the
		/// server, such as a query execution timing out.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_E_BADACCESSORHANDLE hAccessor was invalid.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// DB_E_BADACCESSORTYPE The specified accessor was not a row accessor or was a reference accessor. Some providers may return
		/// DB_E_BADACCESSORHANDLE instead of this error code when command accessors are passed to the rowset.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_E_BADROWHANDLE hRow was invalid.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_E_CANCELED The change was canceled during notification. No columns are changed.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// DB_E_CANTCONVERTVALUE The data value for one or more columns couldn't be converted for reasons other than sign mismatch or data
		/// overflow, and the provider was unable to determine which columns couldn't be converted. Providers that can detect which columns
		/// could not be converted return DB_S_ERRORSOCCURRED and set the status flag for the columns that couldn't be converted to DBSTATUS_E_CANTCONVERTVALUE.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// DB_E_CONCURRENCYVIOLATION The rowset was using optimistic concurrency and the value of a column has been changed since the
		/// containing row was last fetched or resynchronized. <c>IRowsetChange::SetData</c> returns this error only when the rowset is in
		/// immediate update mode.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// DB_E_DATAOVERFLOW Conversion failed because the data value for one or more columns overflowed the type used by the provider and
		/// the provider was unable to determine which columns caused the overflow. Providers that can detect which columns caused the
		/// overflow return DB_S_ERRORSOCCURRED and set the status flag for the columns in violation to DBSTATUS_E_DATAOVERFLOW.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_E_DELETEDROW hRow referred to a row with a pending delete or for which a deletion had been transmitted to the data store.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// DB_E_ERRORSOCCURRED An error occurred while setting data for one or more columns, and data was not successfully set for any
		/// columns. To determine the columns for which values were invalid, the consumer checks the status values. For a list of status
		/// values that can be returned by this method, see "Status Values Used When Setting Data" in Status.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// DB_E_INTEGRITYVIOLATION The data violated the integrity constraints for one or more columns of the rowset, and the provider was
		/// unable to determine which columns violated the integrity constraints. Providers that can detect which columns violated the
		/// integrity constraints return DB_S_ERRORSOCCURRED and set the status flag for the columns in violation to DBSTATUS_E_INTEGRITYVIOLATION.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// DB_E_MAXPENDCHANGESEXCEEDED The number of rows that have pending changes has exceeded the limit specified by the
		/// DBPROP_MAXPENDINGROWS property.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// DB_E_NEWLYINSERTED DBPROP_CHANGEINSERTEDROWS was VARIANT_FALSE, and hRow referred to a row for which the insertion has been
		/// transmitted to the data store.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// DB_E_NOTREENTRANT The consumer called this method while it was processing a notification, and it is an error to call this method
		/// while processing the specified DBREASON value.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_E_NOTSUPPORTED The provider does not support this method, or the corresponding bit of DBPROP_UPDATABILITY is not set.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// DB_SEC_E_PERMISSIONDENIED The consumer did not have sufficient permission to update the row, or the row was not in a state
		/// suitable for updating. (Typical reasons for returning this code are the row is read-only, or changes have not yet been committed
		/// on a rowset in delayed update mode.)
		/// </para>
		/// </description>
		/// </item>
		/// </list>
		/// </returns>
		// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/ms721232(v=vs.85) HRESULT SetData ( HROW hRow, HACCESSOR
		// hAccessor, void *pData);
		[PreserveSig]
		HRESULT SetData([In] HROW hRow, [In] HACCESSOR hAccessor, [In] IntPtr pData);

		/// <summary>Creates and initializes a new row.</summary>
		/// <param name="hChapter">
		/// [in] The chapter handle. Providers are allowed to ignore this argument. For maximum interoperability, consumers should set
		/// hChapter to DB_NULL_HCHAPTER.
		/// </param>
		/// <param name="hAccessor">
		/// <para>[in] The handle of the accessor to use.</para>
		/// <para>
		/// If hAccessor is a null accessor (that is, an accessor for which cBindings in <c>IAccessor::CreateAccessor</c> was zero), pData is
		/// ignored and the rows are initialized as specified in the Comments. Thus, the role of a null accessor is to construct a default
		/// row; it is a convenient way for a consumer to obtain a handle for a new row without having to set any values in that row
		/// initially. Passing an accessor with all columns set to DB_S_IGNORE is equivalent to passing a null accessor.
		/// </para>
		/// </param>
		/// <param name="pData">
		/// [in] A pointer to memory containing the new data values, at offsets that correspond to the bindings in the accessor.
		/// </param>
		/// <param name="phRow">
		/// <para>
		/// [out] A pointer to memory in which to return the handle of the new row. If this is a null pointer, no reference count is held on
		/// the row. Consumers should set this to null if they do not require the ability to make further changes to, or retrieve data from,
		/// the newly inserted row. Whether or not default or computed values from the server are available when calling
		/// <c>IRowset::GetData</c> for this row handle depends on the setting of the DBPROP_SERVERDATAONINSERT. If
		/// <c>IRowsetChange::InsertRow</c> returns an error and phRow is not a null pointer on input, *phRow is set to null on output and no
		/// row handle is returned.
		/// </para>
		/// <para>
		/// <para>Note</para>
		/// <para>
		/// Passing in a null pointer for phRow or releasing the row handle returned in *phRow does not release the row until the change is
		/// transmitted to the data store. If DBPROP_CANHOLDROWS is VARIANT_FALSE and the rowset is in deferred update mode, then, in
		/// addition to freeing any reference counts on the row handle, the consumer must call <c>IRowsetUpdate::Update</c> in order to
		/// transmit the pending change to the data store before attempting to insert or retrieve any additional rows.
		/// </para>
		/// </para>
		/// </param>
		/// <returns>
		/// <list type="bullet">
		/// <item>
		/// <description>
		/// <para>S_OK The method succeeded. The status of all columns bound by the accessor is set to DBSTATUS_S_OK or DBSTATUS_S_ISNULL.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// DB_S_ERRORSOCCURRED An error occurred while setting data for one or more columns, but data was successfully set for at least one
		/// column. To determine the columns for which values were invalid, the consumer checks the status values. For a list of status
		/// values that can be returned by this method, see "Status Values Used When Setting Data" in Status.
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
		/// <para>E_INVALIDARG pData was a null pointer, and hAccessor was not a null accessor.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>E_OUTOFMEMORY The provider was unable to allocate sufficient memory in which to instantiate the row.</para>
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
		/// DB_E_ABORTLIMITREACHED The rowset was in immediate update mode, and the row was not inserted due to reaching a limit on the
		/// server, such as a query execution timing out.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_E_BADACCESSORHANDLE hAccessor was invalid.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// DB_E_BADACCESSORTYPE The specified accessor was not a row accessor or was a reference accessor. Some providers may return
		/// DB_E_BADACCESSORHANDLE instead of this error code when command accessors are passed to the rowset.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_E_CANCELED The insertion was canceled during notification. The row was not inserted.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// DB_E_CANTCONVERTVALUE The data value for one or more columns could not be converted for reasons other than sign mismatch or data
		/// overflow, and the provider was unable to determine which columns couldn't be converted. Providers that can detect which columns
		/// could not be converted return DB_S_ERRORSOCCURRED and set the status flag for the columns that couldn't be converted to DBSTATUS_E_CANTCONVERTVALUE.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// DB_E_DATAOVERFLOW Conversion failed because the data value for one or more columns overflowed the type used by the provider and
		/// the provider was unable to determine which columns caused the overflow. Providers that can detect which columns caused the
		/// overflow return DB_S_ERRORSOCCURRED and set the status flag for the columns in violation to DBSTATUS_E_DATAOVERFLOW.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// DB_E_ERRORSOCCURRED An error occurred while setting data for one or more columns, and data was not successfully set for any
		/// columns. To determine the columns for which values were invalid, the consumer checks the status values. For a list of status
		/// values that can be returned by this method, see "Status Values Used When Setting Data" in Status.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// DB_E_INTEGRITYVIOLATION The data violated the integrity constraints for one or more columns of the rowset, and the provider was
		/// unable to determine which columns violated the integrity constraints. Providers that can detect which columns violated the
		/// integrity constraints return DB_S_ERRORSOCCURRED and set the status flag for the columns in violation to DBSTATUS_E_INTEGRITYVIOLATION.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// DB_E_MAXPENDCHANGESEXCEEDED The number of rows that have pending changes has exceeded the limit specified by the
		/// DBPROP_MAXPENDINGROWS property.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_E_NOTREENTRANT The provider called a method from <c>IRowsetNotify</c> in the consumer, and the method has not yet returned.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_E_NOTSUPPORTED The provider does not support this method, or the corresponding bit of DBPROP_UPDATABILITY is not set.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_E_ROWLIMITEXCEEDED Creating another row would have exceeded the total number of active rows supported by the rowset.</para>
		/// <para>
		/// The provider does not allow a rowset containing more than DBPROP_MAXROWS rows, and the insert would cause the rowset to exceed
		/// this limit.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// DB_E_ROWSNOTRELEASED The consumer attempted to insert a new row before releasing previously retrieved row handles or transmitting
		/// pending changes to the data store, and DBPROP_CANHOLDROWS is VARIANT_FALSE.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// DB_SEC_E_PERMISSIONDENIED The consumer did not have sufficient permission to insert a new row. If the rowset is in delayed update
		/// mode, this error might not be returned until <c>IRowsetUpdate::Update</c> is called.
		/// </para>
		/// </description>
		/// </item>
		/// </list>
		/// </returns>
		// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/ms716921(v=vs.85) HRESULT InsertRow ( HCHAPTER hChapter,
		// HACCESSOR hAccessor, void *pData, HROW *phRow);
		[PreserveSig]
		HRESULT InsertRow([In] HCHAPTER hChapter, [In] HACCESSOR hAccessor, [In] IntPtr pData, out HROW phRow);
	}

	/// <summary>The <c>IRowsetChapterMember</c> interface detects whether or not a row is a member of a chapter.</summary>
	// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/ms725430(v=vs.85)
	[PInvokeData("oledb.h")]
	[ComImport, Guid("0c733aa8-2a1c-11ce-ade5-00aa0044773d"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IRowsetChapterMember
	{
		/// <summary>Determines whether or not a row is a member of a chapter.</summary>
		/// <param name="hChapter">
		/// [in] The chapter handle identifying the chapter in which the row is to be tested for membership. Providers should return S_OK if
		/// hRow is a member of the rowset identified by hChapter. An hChapter value of DB_NULL_HCHAPTER refers to the entire rowset. For a
		/// chaptered rowset, such as one involved in a hierarchy or in a filter or sort operation, this includes hRows that are members of
		/// any chapter of the rowset. Providers that do not support access to the unchaptered rowset may return DB_E_BADCHAPTER.
		/// </param>
		/// <param name="hRow">[in] The row handle.</param>
		/// <returns>
		/// <list type="bullet">
		/// <item>
		/// <description>
		/// <para>S_FALSE The method succeeded, and the row handle is not a member of this chapter.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>S_OK The method succeeded, and the row handle is a member of the chapter.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>E_FAIL A provider-specific error occurred.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>E_UNEXPECTED <c>ITransaction::Commit</c> or <c>ITransaction::Abort</c> was called, and the object is in a zombie state.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_E_BADROWHANDLE hRow is invalid.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_E_BADCHAPTER hChapter is invalid.</para>
		/// <para>
		/// The rowset was single-chaptered, and the specified chapter was not the currently open chapter. The consumer must use the
		/// currently open chapter or release the currently open chapter before specifying a new chapter.
		/// </para>
		/// </description>
		/// </item>
		/// </list>
		/// </returns>
		// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/ms722631(v=vs.85) HRESULT IsRowInChapter ( HCHAPTER hChapter,
		// HROW hRow);
		[PreserveSig]
		HRESULT IsRowInChapter([In] HCHAPTER hChapter, [In] HROW hRow);
	}

	/// <summary>
	/// <c>IRowsetCurrentIndex</c> is the interface for determining and selecting a specific index for a rowset. This is limited to rowsets
	/// that expose <c>IRowsetIndex</c>. <c>IRowsetCurrentIndex</c> provides a mechanism for providers to reorder their rows without
	/// reopening the rowset. This interface can be effective for both integrated and nonintegrated indexes. For a complete description of
	/// indexes, see Index Rowsets and Integrated Indexes.
	/// </summary>
	// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/ms709700(v=vs.85)
	[PInvokeData("oledb.h")]
	[ComImport, Guid("0c733abd-2a1c-11ce-ade5-00aa0044773d"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IRowsetCurrentIndex : IRowsetIndex
	{
		/// <summary>Returns information about the index rowset capabilities.</summary>
		/// <param name="pcKeyColumns">[out] A pointer to memory in which to return the number of key columns in the index.</param>
		/// <param name="prgIndexColumnDesc">
		/// <para>
		/// [out] A pointer to memory in which to return an array of DBINDEXCOLUMNDESC structures in key column order. The size of the array
		/// is equal to *pcKeyColumns.
		/// </para>
		/// <para>
		/// The provider allocates memory for the structures and returns the address to this memory; the consumer releases this memory with
		/// <c>IMalloc::Free</c> when it no longer needs the structures. If *pcKeyColumns is zero on output or if an error occurs, the
		/// provider does not allocate any memory and ensures that *prgIndexColumnDesc is a null pointer on output.
		/// </para>
		/// <para>For more information, see IIndexDefinition::CreateIndex.</para>
		/// </param>
		/// <param name="pcIndexPropertySets">
		/// [out] A pointer to memory in which to return the number of DBPROPSET structures returned in *prgIndexPropertySets.
		/// *pcIndexPropertySets is the total number of property sets for which the provider supports at least one property in the Index
		/// property group. If an error occurs, *pcIndexPropertySets is set to zero.
		/// </param>
		/// <param name="prgIndexPropertySets">
		/// <para>
		/// [out] A pointer to memory in which to return an array of DBPROPSET structures. One structure is returned for each property set
		/// that contains at least one property belonging to the Index property group. For information about the properties in the Index
		/// property group that are defined by OLE DB, see Index Property Group in Appendix C.
		/// </para>
		/// <para>
		/// The provider allocates memory for the structures and returns the address to this memory; the consumer releases this memory with
		/// <c>IMalloc::Free</c> when it no longer needs the structures. Before calling <c>IMalloc::Free</c> for *prgPropertySets, the
		/// consumer should call <c>IMalloc::Free</c> for the rgProperties element within each element of *prgPropertySets. The consumer must
		/// also call <c>VariantClear</c> for the vValue member of each DBPROP structure in order to prevent a memory leak in cases where the
		/// variant contains a reference type (such as a BSTR.) If *pcIndexPropertySets is zero on output or if an error occurs, the provider
		/// does not allocate any memory and ensures that *prgIndexPropertySets is a null pointer on output.
		/// </para>
		/// <para>For information about the DBPROPSET and DBPROP structures, see DBPROPSET Structure and DBPROP Structure.</para>
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
		/// <para>E_INVALIDARG pcKeyColumns, prgIndexColumnDesc, pcIndexPropertySets, or prgIndexPropertySets was a null pointer.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// E_OUTOFMEMORY The provider was unable to allocate sufficient memory in which to return the column description structures or
		/// properties of the index.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_E_NOINDEX The rowset uses integrated indexes, and there is no current index.</para>
		/// </description>
		/// </item>
		/// </list>
		/// </returns>
		// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/ms713717(v=vs.85)
		[PreserveSig]
		new HRESULT GetIndexInfo(out DBORDINAL pcKeyColumns, out SafeIMallocHandle prgIndexColumnDesc, out uint pcIndexPropertySets, out SafeIMallocHandle prgIndexPropertySets);

		/// <summary>
		/// Allows direct positioning at a key value within the current range established by the <c>IRowsetIndex::SetRange</c> method.
		/// </summary>
		/// <param name="hAccessor">
		/// <para>
		/// [in] The handle of the accessor to use. This accessor must meet the following criteria, which are illustrated with a key that
		/// consists of columns A, B, and C, where A is the most significant column and C is the least significant column:
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <description>
		/// <para>
		/// For each key column this accessor binds, it must also bind all more significant key columns. For example, the accessor can bind
		/// column A, columns A and B, or columns A, B, and C.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// Key columns must be bound in order from most significant key column to least significant key column. For example, if the accessor
		/// binds columns A and B, the first binding must bind column A and the second binding must bind column B.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// If the accessor binds any non-key columns, key columns must be bound first. For example, if the accessor binds columns A, B, and
		/// the bookmark column, the first binding must bind column A, the second binding must bind column B, and the third binding must bind
		/// the bookmark column.
		/// </para>
		/// </description>
		/// </item>
		/// </list>
		/// <para>
		/// If the accessor does not meet these criteria, the method returns DB_E_BADBINDINFO or a status of DBSTATUS_E_BADACCESSOR for the
		/// offending column.
		/// </para>
		/// <para>
		/// If hAccessor is the handle of a null accessor (cBindings in <c>IAccessor::CreateAccessor</c> was zero), <c>IRowsetIndex::Seek</c>
		/// does not change the next fetch position.
		/// </para>
		/// </param>
		/// <param name="cKeyValues">
		/// [in] The number of bindings in hAccessor for which *pData contains valid data. <c>IRowsetIndex::Seek</c> retrieves data from the
		/// first cKeyValues key columns from *pData. For example, suppose the accessor binds columns A, B, and C of the key in the previous
		/// example and cKeyValues is 2. <c>IRowsetIndex::Seek</c> retrieves data for columns A and B.
		/// </param>
		/// <param name="pData">
		/// [in] A pointer to a buffer containing the key values to which to seek, at offsets that correspond to the bindings in the accessor.
		/// </param>
		/// <param name="dwSeekOptions">
		/// <para>
		/// [in] A bitmask describing the options for the <c>IRowsetIndex::Seek</c> method. The values in DBSEEKENUM have the meanings
		/// described in the following table.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <description>Value</description>
		/// <description>Description</description>
		/// </listheader>
		/// <item>
		/// <description>DBSEEK_FIRSTEQ</description>
		/// <description>First key with values equal to the values in * <c>pData</c>, in index order.</description>
		/// </item>
		/// <item>
		/// <description>DBSEEK_LASTEQ</description>
		/// <description>Last key with values equal to the values in * <c>pData</c>.</description>
		/// </item>
		/// <item>
		/// <description>DBSEEK_AFTEREQ</description>
		/// <description>
		/// Last key with values equal to the values in * <c>pData</c> or, if there are no keys equal to the values in * <c>pData</c>, first
		/// key with values after the values in * <c>pData</c>, in index order.
		/// </description>
		/// </item>
		/// <item>
		/// <description>DBSEEK_AFTER</description>
		/// <description>First key with values following the values in * <c>pData</c>, in index order.</description>
		/// </item>
		/// <item>
		/// <description>DBSEEK_BEFOREEQ</description>
		/// <description>
		/// First key with values equal to the values in * <c>pData</c> or, if there are no keys equal to the values in * <c>pData</c>, last
		/// key with values before the values in * <c>pData</c>, in index order.
		/// </description>
		/// </item>
		/// <item>
		/// <description>DBSEEK_BEFORE</description>
		/// <description>Last key with values before the values in * <c>pData</c>, in index order.</description>
		/// </item>
		/// </list>
		/// <para><c>dwSeekOptions examples</c></para>
		/// <para>The following table shows the expected results when given the columns and index value for the DBSEEK predicates above.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Col 1</description>
		/// <description>Col 2</description>
		/// <description>Col 3</description>
		/// <description>With index setting of</description>
		/// <description>Predicate</description>
		/// <description>Result</description>
		/// </listheader>
		/// <item>
		/// <description>0 1 2 3</description>
		/// <description/>
		/// <description/>
		/// <description>index = col1 asc</description>
		/// <description>BEFORE (2) BEFOREEQ (2)</description>
		/// <description>(1) (2)</description>
		/// </item>
		/// <item>
		/// <description>1 2 2 3</description>
		/// <description>1 2 3 4</description>
		/// <description/>
		/// <description>index = (col1 asc)</description>
		/// <description>BEFOREEQ (2) AFTEREQ (2)</description>
		/// <description>(2,2) (2,3)</description>
		/// </item>
		/// <item>
		/// <description>1 3 3 4</description>
		/// <description>4 3 3 1</description>
		/// <description>0 1 2 3</description>
		/// <description>index = (col1 asc, col2 desc)</description>
		/// <description>BEFOREEQ (3,3) AFTEREQ (3,3)</description>
		/// <description>(3,3,1) (3,3,2)</description>
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
		/// <para>E_INVALIDARG dwSeekOptions was invalid.</para>
		/// <para>hAccessor was the handle of a null accessor.</para>
		/// <para>cKeyValues was zero or was greater than the number of bindings specified in hAccessor.</para>
		/// <para>pData was a null pointer.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_E_BADACCESSORHANDLE hAccessor was invalid.</para>
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
		/// DB_E_ERRORSOCCURRED An error occurred while transferring data for one or more key columns. To determine the columns for which
		/// values were invalid, the consumer checks the status values. For a list of status values that can be returned by this method, see
		/// "Status Values Used When Setting Data" in Status.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_E_NOINDEX The rowset uses integrated indexes, and there is no current index.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_E_NOTFOUND No key value matching the described characteristics could be found within the current range.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// DB_E_NOTREENTRANT The consumer called this method while it was processing a notification, and it is an error to call this method
		/// while processing the specified DBREASON value.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// DB_E_ROWSNOTRELEASED The provider requires release of existing rows before new ones can be fetched. For more information, see
		/// DBPROP_CANHOLDROWS in Appendix C: OLE DB Properties.
		/// </para>
		/// </description>
		/// </item>
		/// </list>
		/// </returns>
		// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/ms723942(v=vs.85)
		[PreserveSig]
		new HRESULT Seek([In] HACCESSOR hAccessor, DBORDINAL cKeyValues, [In] IntPtr pData, DBSEEK dwSeekOptions);

		/// <summary>Restricts the set of row entries visible through calls to <c>IRowset::GetNextRows</c> and <c>IRowsetIndex::Seek</c>.</summary>
		/// <param name="hAccessor">
		/// <para>[in]</para>
		/// <para>
		/// The handle of the accessor to use for both *pStartData and *pEndData. This accessor must meet the following criteria, which are
		/// illustrated with a key that consists of columns A, B, and C, where A is the most significant column and C is the least
		/// significant column:
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <description>
		/// <para>
		/// For each key column this accessor binds, it must also bind all more significant key columns. For example, the accessor can bind
		/// column A, columns A and B, or columns A, B, and C.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// Key columns must be bound in order from most significant key column to least significant key column. For example, if the accessor
		/// binds columns A and B, the first binding must bind column A and the second binding must bind column B.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// If the accessor binds any non-key columns, key columns must be bound first. For example, if the accessor binds columns A, B, and
		/// the bookmark column, the first binding must bind column A, the second binding must bind column B, and the third binding must bind
		/// the bookmark column.
		/// </para>
		/// </description>
		/// </item>
		/// </list>
		/// <para>
		/// If the accessor does not meet these criteria, the method returns DB_E_BADBINDINFO or a status of DBSTATUS_E_BADACCESSOR for the
		/// offending column.
		/// </para>
		/// <para>
		/// If hAccessor is the handle of a null accessor (cBindings in <c>IAccessor::CreateAccessor</c> was zero),
		/// <c>IRowsetIndex::SetRange</c> does not set a range.
		/// </para>
		/// </param>
		/// <param name="cStartKeyColumns">
		/// <para>[in]</para>
		/// <para>
		/// The number of bindings in hAccessor for which *pStartData contains valid data. <c>IRowsetIndex::SetRange</c> retrieves data from
		/// the first cStartKeyValues key columns from *pStartData. For example, suppose the accessor binds columns A, B, and C of the key in
		/// the previous example and that cStartKeyValues is 2. <c>IRowsetIndex::SetRange</c> retrieves data for columns A and B.
		/// </para>
		/// </param>
		/// <param name="pStartData">
		/// <para>[in]</para>
		/// <para>
		/// A pointer to a buffer containing the starting key values of the range, at offsets that correspond to the bindings in the accessor.
		/// </para>
		/// </param>
		/// <param name="cEndKeyColumns">
		/// <para>[in]</para>
		/// <para>
		/// The number of bindings in hAccessor for which *pEndData contains valid data. <c>IRowsetIndex::SetRange</c> retrieves data from
		/// the first cEndKeyValues key columns from *pEndData. For example, suppose the accessor binds columns A, B, and C of the key in the
		/// previous example and that cEndKeyValues is 2. <c>IRowsetIndex::SetRange</c> retrieves data for columns A and B.
		/// </para>
		/// </param>
		/// <param name="pEndData">
		/// <para>[in]</para>
		/// <para>
		/// A pointer to a buffer containing the ending key values of the range, at offsets that correspond to the bindings in the accessor.
		/// </para>
		/// </param>
		/// <param name="dwRangeOptions">
		/// <para>[in]</para>
		/// <para>A bitmask describing the options of the range. The values in DBRANGEENUM have the meanings described in the following table.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Value</description>
		/// <description>Description</description>
		/// </listheader>
		/// <item>
		/// <description>DBRANGE_INCLUSIVESTART</description>
		/// <description>The start boundary is inclusive (the default).</description>
		/// </item>
		/// <item>
		/// <description>DBRANGE_EXCLUSIVESTART</description>
		/// <description>The start boundary is exclusive.</description>
		/// </item>
		/// <item>
		/// <description>DBRANGE_INCLUSIVEEND</description>
		/// <description>The end boundary is inclusive (the default).</description>
		/// </item>
		/// <item>
		/// <description>DBRANGE_EXCLUSIVEEND</description>
		/// <description>The end boundary is exclusive.</description>
		/// </item>
		/// <item>
		/// <description>DBRANGE_EXCLUDENULLS</description>
		/// <description>Exclude NULLs from the range.</description>
		/// </item>
		/// <item>
		/// <description>DBRANGE_PREFIX</description>
		/// <description>
		/// Use * <c>pStartData</c> as a prefix. <c>pEndData</c> must be a null pointer. Prefix matching can be specified entirely using the
		/// inclusive and exclusive flags. However, because prefix matching is an important common case, this flag enables the consumer to
		/// specify only the * <c>pStartData</c> values and enables the provider to interpret this request quickly.
		/// </description>
		/// </item>
		/// <item>
		/// <description>DBRANGE_MATCH</description>
		/// <description>
		/// Set the range to all keys that match * <c>pStartData</c>. * <c>pStartData</c> must specify a full key. <c>pEndData</c> must be a
		/// null pointer. Used for fast equality match.
		/// </description>
		/// </item>
		/// <item>
		/// <description>DBRANGE_MATCH_N_MASK</description>
		/// <description>Equal to 0xff.</description>
		/// </item>
		/// <item>
		/// <description>DBRANGE_MATCH_N_SHIFT</description>
		/// <description>Equal to 24 to indicate the number of bits to shift to get the number <c>N</c>.</description>
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
		/// <para>E_INVALIDARG dwRangeOptions was invalid.</para>
		/// <para>dwRangeOptions included DBRANGE_PREFIX or DBRANGE_MATCH, and pEndData was not a NULL pointer.</para>
		/// <para>
		/// dwRangeOptions was DBRANGE_MATCH_N, and the provider did not support that option. For more information about DBRANGE_MATCH_N, see
		/// "Equality Matching."
		/// </para>
		/// <para>cStartKeyValues was not zero, and pStartData was a null pointer.</para>
		/// <para>cEndKeyValues was not zero, and pEndData was a null pointer.</para>
		/// <para>hAccessor was the handle of a null accessor.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_E_BADACCESSORHANDLE hAccessor was invalid.</para>
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
		/// DB_E_ERRORSOCCURRED An error occurred while transferring data for one or more key columns. To determine the columns for which
		/// values were invalid, the consumer checks the status values. For a list of status values that can be returned by this method, see
		/// "Status Values Used When Setting Data" in Status.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_E_NOINDEX The rowset uses integrated indexes, and there is no current index.</para>
		/// </description>
		/// </item>
		/// </list>
		/// <para>Comments</para>
		/// <para>
		/// If this method performs deferred accessor validation and that validation takes place before any data is transferred, it can also
		/// return any of the following return codes for the reasons listed in the corresponding DBBINDSTATUS values in <c>IAccessor::CreateAccessor</c>:
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <description>
		/// <para>E_NOINTERFACE</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_E_BADBINDINFO</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_E_BADORDINAL</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_E_BADSTORAGEFLAGS</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_E_UNSUPPORTEDCONVERSION</para>
		/// </description>
		/// </item>
		/// </list>
		/// <para>
		/// A range defines a view in the index containing a contiguous set of key values. The *pStartData and *pEndData values always
		/// specify the starting and ending positions in the range, respectively. Therefore, for an ascending index, *pStartData contains the
		/// smaller value and *pEndData contains the larger value; for a descending index, *pStartData contains the larger value and
		/// *pEndData contains the smaller value.
		/// </para>
		/// <para>
		/// As long as the *pStartData and *pEndData values specified are valid for the column, <c>IRowsetIndex::SetRange</c> should succeed,
		/// even if the start and end values are outside of the range of values contained in the index. If the index does not contain any
		/// rows within the range, calling <c>IRowset::GetNextRows</c> after the call to <c>IRowsetIndex::SetRange</c> should return DB_S_ENDOFROWSET.
		/// </para>
		/// <para>
		/// A range on the entire index is defined by calling <c>IRowsetIndex::SetRange</c> (hAcc, 0, NULL, 0, NULL, 0). When a range is set,
		/// <c>IRowsetIndex::Seek</c> can position only to rows in the current range.
		/// </para>
		/// <para>For information about how <c>IRowsetIndex::SetRange</c> transfers data from *pDataStart and *pDataEnd, see Setting Data.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/ms725416(v=vs.85) HRESULT SetRange ( HACCESSOR hAccessor,
		// DBORDINAL cStartKeyColumns, void *pStartData, DBORDINAL cEndKeyColumns, void *pEndData, DBRANGE dwRangeOptions);
		[PreserveSig]
		new HRESULT SetRange([In] HACCESSOR hAccessor, DBORDINAL cStartKeyColumns, [In] IntPtr pStartData, DBORDINAL cEndKeyColumns, [In] IntPtr pEndData, DBRANGE dwRangeOptions);

		/// <summary>Gets the current index on the rowset.</summary>
		/// <param name="ppIndexID">[out] The DBID of the active index on the base table.</param>
		/// <returns>
		/// <list type="bullet">
		/// <item>
		/// <description>
		/// <para>S_OK The method succeeded. If there is no current index, ppIndexID is set to NULL.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>E_INVALIDARG ppIndexID was a null pointer.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>E_OUTOFMEMORY The provider was unable to allocate sufficient memory in which to return ppIndexID.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>E_FAIL A provider-specific error occurred.</para>
		/// </description>
		/// </item>
		/// </list>
		/// </returns>
		// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/ms715829(v=vs.85) HRESULT GetIndex ( DBID **ppIndexID);
		[PreserveSig]
		HRESULT GetIndex(out IntPtr ppIndexID);

		/// <summary>Sets the current index on the rowset.</summary>
		/// <param name="pIndexID">[in] The DBID of the current index on the rowset.</param>
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
		/// DB_S_COLUMNSCHANGED The metadata for the rowset changed based on the index selected. The provider had to reexecute the command
		/// for the newly selected index, and the order of the columns changed.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>E_INVALIDARG pIndexID was a null pointer.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_E_BADINDEXID *pIndexID was an invalid index ID.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// DB_E_ROWSNOTRELEASED The provider requires release of existing rows before changing the index because the rowset will be
		/// regenerated. This may be required even if the provider supports a value of VARIANT_TRUE for DBPROP_CANHOLDROWS. For more
		/// information, see DBPROP_CANHOLDROWS in Appendix C.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_E_NOINDEX The index specified in pIndexID did not exist.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>E_FAIL A provider-specific error occurred.</para>
		/// </description>
		/// </item>
		/// </list>
		/// </returns>
		// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/ms709703(v=vs.85) HRESULT SetIndex ( DBID *pIndexID);
		[PreserveSig]
		HRESULT SetIndex(in DBID pIndexID);

	}

	/// <summary>Gives an exact position and and exact rowcount for a given bookmark into the Rowset.</summary>
	// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/aa965357(v=vs.85)
	[PInvokeData("oledb.h")]
	[ComImport, Guid("0c733a7f-2a1c-11ce-ade5-00aa0044773d"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IRowsetExactScroll : IRowsetScroll
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
		new HRESULT AddRefRows(DBCOUNTITEM cRows, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] HROW[] rghRows,
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
		new HRESULT GetData([In] HROW hRow, [In] HACCESSOR hAccessor, [Out] IntPtr pData);

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
		new HRESULT GetNextRows([In] HCHAPTER hChapter, DBROWOFFSET lRowsOffset, DBROWCOUNT cRows, out DBCOUNTITEM pcRowsObtained, out SafeIMallocHandle prghRows);

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
		new HRESULT ReleaseRows(DBCOUNTITEM cRows, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] HROW[] rghRows,
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
		new HRESULT RestartPosition(HCHAPTER hReserved);

		/// <summary>Compares two bookmarks.</summary>
		/// <param name="hChapter">
		/// <para>[in] The chapter handle. For nonchaptered rowsets or to designate the root rowset, the caller must set hChapter to DB_NULL_HCHAPTER.</para>
		/// <para>
		/// When comparing literal bookmarks and hChapter is DB_NULL_HCHAPTER, <c>IRowsetLocate::Compare</c> must return the same ordering as
		/// an arithmetic comparison. If hChapter is not DB_NULL_HCHAPTER, <c>IRowsetLocate::Compare</c> must reflect the ordering within
		/// that chapter. Also, the row designated by the special bookmarks DBBMK_FIRST or DBBMK_LAST depends on the chapter.
		/// </para>
		/// </param>
		/// <param name="cbBookmark1">[in] The length in bytes of the first bookmark.</param>
		/// <param name="pBookmark1">[in] A pointer to the first bookmark. This can be a pointer to DBBMK_FIRST or DBBMK_LAST.</param>
		/// <param name="cbBookmark2">[in] The length in bytes of the second bookmark.</param>
		/// <param name="pBookmark2">[in] A pointer to the second bookmark. This can be a pointer to DBBMK_FIRST or DBBMK_LAST.</param>
		/// <param name="pComparison">
		/// <para>
		/// [out] A pointer to memory in which to return a flag that specifies the result of the comparison. The returned flag will be one of
		/// the values in the following table.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <description>Value</description>
		/// <description>Description</description>
		/// </listheader>
		/// <item>
		/// <description>DBCOMPARE_LT</description>
		/// <description>The first bookmark is before the second.</description>
		/// </item>
		/// <item>
		/// <description>DBCOMPARE_EQ</description>
		/// <description>The two bookmarks are equal.</description>
		/// </item>
		/// <item>
		/// <description>DBCOMPARE_GT</description>
		/// <description>The first bookmark is after the second.</description>
		/// </item>
		/// <item>
		/// <description>DBCOMPARE_NE</description>
		/// <description>The bookmarks are not equal and not ordered.</description>
		/// </item>
		/// <item>
		/// <description>DBCOMPARE_NOTCOMPARABLE</description>
		/// <description>The two bookmarks cannot be compared. When to return DBCOMPARE_NOTCOMPARABLE:</description>
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
		/// <para>E_INVALIDARG cbBookmark1 or cbBookmark2 was zero.</para>
		/// <para>pBookmark1, pBookmark2, or pComparison was a null pointer.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>E_UNEXPECTED <c>ITransaction::Commit</c> or <c>ITransaction::Abort</c> was called, and the object is in a zombie state.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_E_BADBOOKMARK *pBookmark1 or *pBookmark2 was invalid, incorrectly formed, or DBBMK_INVALID.</para>
		/// </description>
		/// </item>
		/// </list>
		/// <para>
		/// <para>Note</para>
		/// <para>
		/// Consumers should attempt to use only bookmarks that they have received from the provider. The provider is guaranteed to handle
		/// only bookmarks it gives out in a predictable manner. Attempting to use a random value as a bookmark is undefined; the provider
		/// may return DB_E_BADBOOKMARK, may return an unexpected row, or may terminate abnormally.
		/// </para>
		/// </para>
		/// <list type="bullet">
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
		/// DB_E_NOTREENTRANT The provider called a method from <c>IRowsetNotify</c> in the consumer that had not yet returned, and the
		/// provider does not support reentrancy in this method.
		/// </para>
		/// </description>
		/// </item>
		/// </list>
		/// </returns>
		// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/ms709539(v=vs.85) HRESULT Compare ( HCHAPTER hChapter,
		// DBBKMARK cbBookmark1, const BYTE *pBookmark1, DBBKMARK cbBookmark2, const BYTE *pBookmark2, DBCOMPARE *pComparison);
		[PreserveSig]
		new HRESULT Compare([In] HCHAPTER hChapter, DBBKMARK cbBookmark1, [In] IntPtr pBookmark1, DBBKMARK cbBookmark2, [In] IntPtr pBookmark2, out DBCOMPARE pComparison);

		/// <summary>Fetches rows starting with the row specified by an offset from a bookmark.</summary>
		/// <param name="hReserved1">[in] Reserved for future use. Providers ignore this parameter.</param>
		/// <param name="hChapter">
		/// [in] The chapter handle. For nonchaptered rowsets or to designate the root rowset, the caller must set hChapter to DB_NULL_HCHAPTER.
		/// </param>
		/// <param name="cbBookmark">[in] The length in bytes of the bookmark. This must not be zero.</param>
		/// <param name="pBookmark">
		/// [in] A pointer to a bookmark that identifies the base row to be used. This can be a pointer to DBBMK_FIRST or DBBMK_LAST. If
		/// lRowsOffset is zero, the provider fetches this row first; otherwise, the provider skips this and subsequent rows up to the count
		/// specified in the offset and then fetches the following rows.
		/// </param>
		/// <param name="lRowsOffset">
		/// <para>
		/// [in] The signed count of rows from the origin bookmark to the target row. Deleted rows that the provider has removed from the
		/// rowset are not counted in the skip. The first row fetched is determined by the bookmark and this offset. For example, if
		/// lRowsOffset is zero, the first row fetched is the bookmarked row; if lRowsOffset is 1, the first row fetched is the row after the
		/// bookmarked row; if lRowsOffset is ?1, the first row fetched is the row before the bookmarked row.
		/// </para>
		/// <para>lRowsOffset can be a negative number only if the value of the DBPROP_CANSCROLLBACKWARDS property is VARIANT_TRUE.</para>
		/// </param>
		/// <param name="cRows">
		/// <para>
		/// [in] The number of rows to fetch. A negative number means to fetch backward. cRows can be a negative number only if the value of
		/// the DBPROP_CANFETCHBACKWARDS property is VARIANT_TRUE.
		/// </para>
		/// <para>
		/// If cRows is zero, no rows are fetched; the fetch direction and the next fetch position are unchanged, and the provider performs
		/// no processing, returning immediately from the method invocation. Specifically, lRowsOffset is ignored in this situation.
		/// </para>
		/// <para>
		/// If the provider does not discover any other errors, the method returns S_OK; whether the provider checks for any other errors is provider-specific.
		/// </para>
		/// <para>See the Comments section for a full description of the semantics of lRowsOffset and cRows parameters.</para>
		/// </param>
		/// <param name="pcRowsObtained">
		/// [out] A pointer to memory in which to return the actual number of fetched rows. If the consumer has insufficient permission to
		/// fetch all rows, <c>IRowsetLocate::GetRowsAt</c> fetches all rows for which the consumer has sufficient permission and skips all
		/// other rows. If the method fails, *pcRowsObtained is set to zero.
		/// </param>
		/// <param name="prghRows">
		/// [in/out] A pointer to memory in which to return an array of handles of the fetched rows. If *prghRows is not a null pointer on
		/// input, it must be a pointer to memory large enough to return the handles of the requested number of rows. If *prghRows is a null
		/// pointer on input, the rowset allocates memory for the row handles and returns the address to this memory. The consumer releases
		/// this memory with <c>IMalloc::Free</c> after it releases the row handles. If *prghRows was a null pointer on input and
		/// *pcRowsObtained is zero on output or if the method fails, the provider does not allocate any memory and ensures that *prghRows is
		/// a null pointer on output.
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
		/// DB_S_BOOKMARKSKIPPED The following behavior is supported only on rowsets that set the DBPROP_BOOKMARKSKIPPED property to
		/// VARIANT_TRUE. If this property is VARIANT_FALSE, this return code is never returned.
		/// </para>
		/// <para>
		/// lRowsOffset was zero and the row specified by *pBookmark was deleted or is no longer a member of the rowset, or the row specified
		/// by the combination of *pBookmark and lRowsOffset is a row to which the consumer does not have access rights.
		/// <c>IRowsetLocate::GetRowsAt</c> skipped that row. The full count of actual rows (cRows) will be met if there are enough rows
		/// available. The array of returned row handles does not have gaps for missing rows; the returned count is the number of rows
		/// actually fetched.
		/// </para>
		/// <para>
		/// If a row is skipped, it is counted as one of the rows to be skipped for lRowsOffset. For example, if an offset of 1 is requested
		/// and the bookmark points to a row that is now missing, the offset is decremented by 1 and the provider begins by fetching the next row.
		/// </para>
		/// <para>
		/// If this condition occurs along with another warning condition, the method returns the code for the other warning condition.
		/// Therefore, whenever a consumer receives the return code for another warning condition, it should check to see whether this
		/// condition occurred.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// DB_S_ENDOFROWSET <c>IRowsetLocate::GetRowsAt</c> reached the start or the end of the rowset or chapter and could not fetch all of
		/// the requested rows because the count extended beyond the end. The number of rows actually fetched is returned in *pcRowsObtained;
		/// this will be less than cRows.
		/// </para>
		/// <para>
		/// The rowset is being populated asynchronously, and no additional rows are available at this time. To determine whether additional
		/// rows may be available, the consumer should call <c>IDBAsynchStatus::GetStatus</c> or listen for the
		/// <c>IDBAsynchNotify::OnStop</c> notification.
		/// </para>
		/// <para>
		/// lRowsOffset indicated a position either more than one row before the first row of the rowset or more than one row after the last
		/// row, and the provider was a version 2.0 or later provider. *pcRowsObtained is set to zero, and no rows are returned.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// DB_S_ROWLIMITEXCEEDED Fetching the number of rows specified in cRows would have exceeded the total number of active rows
		/// supported by the rowset. The number of rows that were actually fetched is returned in *pcRowsObtained. This condition can occur
		/// only when there are more rows available than can be handled by the rowset. Therefore, this condition never conflicts with those
		/// described in DB_S_ENDOFROWSET and DB_S_STOPLIMITREACHED, both of which imply that no more rows were available.
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
		/// <para>E_INVALIDARG cbBookmark was zero, or pBookmark was a null pointer.</para>
		/// <para>pcRowsObtained or prghRows was a null pointer.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// E_OUTOFMEMORY The provider was unable to allocate sufficient memory in which to instantiate the rows or return the row handles.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>E_UNEXPECTED <c>ITransaction::Commit</c> or <c>ITransaction::Abort</c> was called, and the object is in a zombie state.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_E_BADBOOKMARK *pBookmark was invalid, incorrectly formed, or DBBMK_INVALID.</para>
		/// <para>
		/// *pBookmark did not match any rows in the rowset. This includes the case when the row corresponding to the bookmark has been
		///  deleted and DBPROP_BOOKMARKSKIPPED was VARIANT_FALSE.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_E_BADCHAPTER The rowset was chaptered, and hChapter was invalid.</para>
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
		/// DB_E_NOTREENTRANT The provider called a method from <c>IRowsetNotify</c> in the consumer that had not yet returned, and the
		/// provider does not support reentrancy in this method.
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
		// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/ms723031(v=vs.85) HRESULT GetRowsAt ( HWATCHREGION hReserved1,
		// HCHAPTER hChapter, DBBKMARK cbBookmark, const BYTE *pBookmark, DBROWOFFSET lRowsOffset, DBROWCOUNT cRows, DBCOUNTITEM
		// *pcRowsObtained, HROW **prghRows);
		[PreserveSig]
		new HRESULT GetRowsAt([In, Optional] HWATCHREGION hReserved1, [In] HCHAPTER hChapter, DBBKMARK cbBookmark, [In] IntPtr pBookmark,
			DBROWOFFSET lRowsOffset, DBROWCOUNT cRows, out DBCOUNTITEM pcRowsObtained, out SafeIMallocHandle prghRows);

		/// <summary>Fetches the rows that match the specified bookmarks.</summary>
		/// <param name="hChapter">
		/// [in] The chapter handle. For nonchaptered rowsets or to designate the root rowset, the caller must set hChapter to DB_NULL_HCHAPTER.
		/// </param>
		/// <param name="cRows">
		/// <para>[in] The number of rows to fetch.</para>
		/// <para>
		/// If cRows is zero, no rows are fetched; the fetch direction and the next fetch position are unchanged, and the provider performs
		/// no processing, returning immediately from the method invocation.
		/// </para>
		/// <para>
		/// If the provider does not discover any other errors, the method returns S_OK; whether the provider checks for any other errors is provider-specific.
		/// </para>
		/// </param>
		/// <param name="rgcbBookmarks">[in] An array containing the length in bytes of each bookmark.</param>
		/// <param name="rgpBookmarks">
		/// [in] An array containing a pointer to the bookmark of each row sought. These cannot be pointers to a standard bookmark
		/// (DBBMK_FIRST, DBBMK_LAST, DBBMK_INVALID). If rgpBookmarks contains a duplicate bookmark, the corresponding row is fetched and the
		/// reference count incremented once for each occurrence of the bookmark.
		/// </param>
		/// <param name="rghRows">
		/// [out] An array with cRows elements in which to return the handles of the fetched rows. The consumer allocates this array but is
		/// not required to initialize the elements of it. In each element of this array, if the row was fetched, the provider returns the
		/// handle of the row identified by the bookmark in the corresponding element of rgpBookmarks. If the row was not fetched, the
		/// provider returns DB_NULL_HROW.
		/// </param>
		/// <param name="rgRowStatus">
		/// [out] An array with cRows elements in which to return values indicating the status of each row specified in rgpBookmarks. If no
		/// errors or warnings occur while fetching a row, the corresponding element of rgRowStatus is set to DBROWSTATUS_S_OK. If an error
		/// occurs while fetching a row, the corresponding element is set as specified in DB_S_ERRORSOCCURRED. The consumer allocates memory
		/// for this array but is not required to initialize it. If rgRowStatus is a null pointer, no row statuses are returned.
		/// </param>
		/// <returns>
		/// <list type="bullet">
		/// <item>
		/// <description>
		/// <para>S_OK The method succeeded. All rows were successfully fetched. The following value can be returned in rgRowStatus:</para>
		/// <para>The row was successfully fetched. The corresponding element of rgRowStatus contains DBROWSTATUS_S_OK.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// DB_S_ERRORSOCCURRED An error occurred while fetching a row, but at least one row was successfully fetched. Successes can occur
		/// for the reasons listed under S_OK. The following errors can occur:
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
		/// <para>E_INVALIDARG rghRows was a null pointer.</para>
		/// <para>rgcbBookmarks or rgpBookmarks was a null pointer.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>E_OUTOFMEMORY The provider was unable to allocate sufficient memory in which to return the row handles.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>E_UNEXPECTED <c>ITransaction::Commit</c> or <c>ITransaction::Abort</c> was called, and the object is in a zombie state.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_E_BADCHAPTER The rowset was chaptered, and hChapter was invalid.</para>
		/// <para>
		/// The rowset was single-chaptered, and the specified chapter was not the currently open chapter. The consumer must use the
		/// currently open chapter or release the currently open chapter before specifying a new chapter.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_E_ERRORSOCCURRED Errors occurred while fetching all of the rows. Errors can occur for the reasons listed under DB_S_ERRORSOCCURRED.</para>
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
		/// DB_E_ROWSNOTRELEASED The provider requires release of existing rows before new ones can be fetched. For more information, see
		/// DBPROP_CANHOLDROWS in Rowset Properties in Appendix C.
		/// </para>
		/// </description>
		/// </item>
		/// </list>
		/// </returns>
		// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/ms725420(v=vs.85) HRESULT GetRowsByBookmark ( HCHAPTER
		// hChapter, DBCOUNTITEM cRows, const DBBKMARK rgcbBookmarks[], const BYTE *rgpBookmarks[], HROW rghRows[], DBROWSTATUS rgRowStatus[]);
		[PreserveSig]
		new HRESULT GetRowsByBookmark([In] HCHAPTER hChapter, DBCOUNTITEM cRows, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] DBBKMARK[] rgcbBookmarks,
			[In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] IntPtr[] rgpBookmarks, [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] HROW[] rghRows,
			[Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] DBROWSTATUS[] rgRowStatus);

		/// <summary>Returns hash values for the specified bookmarks.</summary>
		/// <param name="hChapter">
		/// [in] The chapter handle. hChapter is ignored. For maximum interoperability, consumers should set hChapter to DB_NULL_HCHAPTER.
		/// </param>
		/// <param name="cBookmarks">
		/// [in] The number of bookmarks to hash. If cBookmarks is zero, <c>IRowsetLocate::Hash</c> does not do anything.
		/// </param>
		/// <param name="rgcbBookmarks">[in] An array containing the length in bytes for each bookmark.</param>
		/// <param name="rgpBookmarks">
		/// <para>
		/// [in] An array of pointers to bookmarks. The bookmarks cannot be standard bookmarks (DBBMK_FIRST, DBBMK_LAST, DBBMK_INVALID). If
		/// rgpBookmarks contains a duplicate bookmark, a hash value is returned once for each occurrence of the bookmark.
		/// </para>
		/// <para>
		/// <para>Warning</para>
		/// <para>
		/// The consumer must ensure that all bookmarks in rgpBookmarks are valid. The provider is not required to validate bookmarks before
		/// hashing them. Therefore, hash values might be returned for invalid bookmarks.
		/// </para>
		/// </para>
		/// </param>
		/// <param name="rgHashedValues">
		/// [out] An array of cBookmarks hash values corresponding to the elements of rgpBookmarks. The consumer allocates, but is not
		/// required to initialize, memory for this array and passes the address of this memory to the provider. The provider returns the
		/// hash values in the array.
		/// </param>
		/// <param name="rgBookmarkStatus">
		/// [out] An array with cBookmarks elements in which to return values indicating the status of each bookmark specified in
		/// rgpBookmarks. If no errors occur while hashing a bookmark, the corresponding element of rgBookmarkStatus is set to
		/// DBROWSTATUS_S_OK. If an error occurs while hashing a bookmark, the corresponding element is set as specified in
		/// DB_S_ERRORSOCCURRED. The consumer allocates memory for this array but is not required to initialize it. If rgBookmarkStatus is a
		/// null pointer, no bookmark statuses are returned.
		/// </param>
		/// <returns>
		/// <list type="bullet">
		/// <item>
		/// <description>
		/// <para>S_OK The method succeeded. All bookmarks were successfully hashed. The following value can be returned in rgRowStatus:</para>
		/// <para>The bookmark was successfully hashed. The corresponding element of rgRowStatus contains DBROWSTATUS_S_OK.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// DB_S_ERRORSOCCURRED An error occurred while hashing a bookmark, but at least one bookmark was successfully hashed. Successes can
		/// occur for the reason listed under S_OK. The following errors can occur:
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
		/// <para>E_INVALIDARG cBookmarks was not zero, and rgcbBookmarks or rgpBookmarks was a null pointer.</para>
		/// <para>rgHashedValues was a null pointer.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>E_UNEXPECTED <c>ITransaction::Commit</c> or <c>ITransaction::Abort</c> was called, and the object is in a zombie state.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_E_BADCHAPTER The rowset was chaptered, and hChapter was invalid.</para>
		/// <para>
		/// The rowset was single-chaptered, and the specified chapter was not the currently open chapter. The consumer must use the
		/// currently open chapter or release the currently open chapter before specifying a new chapter.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_E_ERRORSOCCURRED Errors occurred while hashing all of the bookmarks. Errors can occur for the reasons listed under DB_S_ERRORSOCCURRED.</para>
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
		// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/ms709697(v=vs.85) HRESULT Hash ( HCHAPTER hChapter, DBBKMARK
		// cBookmarks, const DBBKMARK rgcbBookmarks[], const BYTE *rgpBookmarks[], DBHASHVALUE rgHashedValues[], DBROWSTATUS rgBookmarkStatus[]);
		[PreserveSig]
		new HRESULT Hash([In] HCHAPTER hChapter, DBBKMARK cBookmarks, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] DBBKMARK[] rgcbBookmarks,
			[In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] IntPtr[] rgpBookmarks,
			[Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] DBHASHVALUE[] rgHashedValues,
			[Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] DBROWSTATUS[] rgBookmarkStatus);

		/// <summary>Gets the approximate position of a row corresponding to a specified bookmark.</summary>
		/// <param name="hChapter">
		/// [in] The chapter handle designating the rows on which to position. For nonchaptered rowsets, the caller must set hChapter to
		/// DB_NULL_HCHAPTER. For chaptered rowsets, DB_NULL_HCHAPTER designates the entire rowset.
		/// </param>
		/// <param name="cbBookmark">
		/// [in] The length in bytes of the bookmark. If this is zero, pBookmark is ignored, *pcRows is set to the count of rows, and no
		/// position is returned in *pulPosition.
		/// </param>
		/// <param name="pBookmark">
		/// [in] A pointer to a bookmark that identifies the row of which to find the position. This can be a pointer to DBBMK_FIRST or
		/// DBBMK_LAST. The consumer is not required to have permission to read the row.
		/// </param>
		/// <param name="pulPosition">
		/// [out] A pointer to memory in which to return the position of the row identified by the bookmark. The returned number is
		/// one-based; that is, the first row in the rowset is 1 and the last row is equal to *pcRows. If *pcRows is zero, the provider sets
		/// *pulPosition to zero also, regardless of the bookmark that was passed. If pulPosition is a null pointer, no position is returned.
		/// In case of error, *pulPosition is not changed.
		/// </param>
		/// <param name="pcRows">
		/// [out] A pointer to memory in which to return the total number of rows. This number is zero if there are no rows. If pcRows is a
		/// null pointer, no count of rows is returned. In case of error, *pcRows is not changed.
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
		/// <para>E_INVALIDARG cbBookmark was not zero, and pBookmark was a null pointer.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>E_UNEXPECTED <c>ITransaction::Commit</c> or <c>ITransaction::Abort</c> was called and the object is in a zombie state.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_E_BADBOOKMARK *pBookmark was invalid, incorrectly formed, or DBBMK_INVALID.</para>
		/// <para>
		/// *pBookmark did not match any of the rows in the rowset. This includes the case when the row corresponding to the bookmark was
		///  deleted and either DBPROP_BOOKMARKSKIPPED was VARIANT_FALSE or the provider is a 1.x provider that does not support getting the
		///  approximate position of a deleted row.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_E_BADCHAPTER The rowset was chaptered, and hChapter was invalid.</para>
		/// <para>
		/// The rowset was single-chaptered, and the specified chapter was not the currently open chapter. The consumer must use the
		/// currently open chapter or release the currently open chapter before specifying a new chapter.
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
		// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/ms712901(v=vs.85) HRESULT GetApproximatePosition ( HCHAPTER
		// hChapter, DBBKMARK cbBookmark, const BYTE *pBookmark, DBCOUNTITEM *pulPosition, DBCOUNTITEM *pcRows);
		[PreserveSig]
		new HRESULT GetApproximatePosition([In] HCHAPTER hChapter, DBBKMARK cbBookmark, [In] IntPtr pBookmark, out DBCOUNTITEM pulPosition, out DBCOUNTITEM pcRows);

		/// <summary>Fetches rows starting from a fractional position in the rowset.</summary>
		/// <param name="hReserved1">[in] Reserved for future use. Providers ignore this parameter.</param>
		/// <param name="hChapter">[in] The chapter handle. For nonchaptered rowsets, the caller must set hChapter to DB_NULL_HCHAPTER.</param>
		/// <param name="ulNumerator">[in] See ulDenominator below.</param>
		/// <param name="ulDenominator">
		/// <para>[in] The provider determines the first row to fetch from the ratio of ulNumerator to ulDenominator, roughly using the formula:</para>
		/// <para>
		/// If the rowset is being populated asynchronously, ulNumerator and ulDenominator specify the relative position within the rows
		/// fetched so far.
		/// </para>
		/// <para>
		/// How accurately the provider applies this ratio is provider-specific. For example, if ulNumerator is 1 and ulDenominator is 2,
		/// some providers will fetch rows starting exactly halfway through the rowset while other providers will fetch rows starting 40
		/// percent of the way through the rowset.
		/// </para>
		/// <para>However, all providers must handle the following conditions correctly.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Condition</description>
		/// <description>IRowsetScroll::GetRowsAtRatio action</description>
		/// </listheader>
		/// <item>
		/// <description>( <c>ulNumerator</c> = 0) AND ( <c>cRows</c> &gt; 0)</description>
		/// <description>Fetches rows starting with the first row in the rowset.</description>
		/// </item>
		/// <item>
		/// <description>( <c>ulNumerator</c> = 0) AND ( <c>cRows</c> &lt; 0)</description>
		/// <description>Returns DB_S_ENDOFROWSET.</description>
		/// </item>
		/// <item>
		/// <description>( <c>ulNumerator</c> = <c>ulDenominator</c>) AND ( <c>cRows</c> &gt; 0)</description>
		/// <description>Returns DB_S_ENDOFROWSET.</description>
		/// </item>
		/// <item>
		/// <description>( <c>ulNumerator</c> = <c>ulDenominator</c>) AND ( <c>cRows</c> &lt; 0)</description>
		/// <description>Fetches rows starting with the last row in the rowset.</description>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="cRows">
		/// <para>
		/// [in] The number of rows to fetch. A negative number means to fetch backward. cRows can be a negative number only if the value of
		/// the DBPROP_CANFETCHBACKWARDS property is VARIANT_TRUE. The rows are returned in rowset-traversal order ? that is, the direction
		/// in which they were fetched.
		/// </para>
		/// <para>
		/// If cRows is zero, no rows are fetched. If the provider does not discover any other errors, the method returns S_OK; whether the
		/// provider checks for any other errors is provider-specific.
		/// </para>
		/// </param>
		/// <param name="pcRowsObtained">
		/// [out] A pointer to memory in which to return the number of rows fetched. If the consumer has insufficient permissions to return
		/// all rows, <c>IRowsetScroll::GetRowsAtRatio</c> fetches all rows for which the consumer has sufficient permission and skips all
		/// other rows. If the method fails, *pcRowsObtained is set to 0.
		/// </param>
		/// <param name="prghRows">
		/// [in/out] A pointer to memory in which to return an array of handles of the fetched rows. If *prghRows is not a null pointer on
		/// input, it must be a pointer to memory large enough to return the handles of the requested number of rows. If *prghRows is a null
		/// pointer on input, the rowset allocates memory for the row handles and returns the address to this memory; the consumer releases
		/// this memory with <c>IMalloc::Free</c> after it releases the row handles. If *prghRows was a null pointer on input and
		/// *pcRowsObtained is zero on output or the method fails, the provider does not allocate any memory and ensures that *prghRows is a
		/// null pointer on output.
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
		/// DB_S_ENDOFROWSET <c>IRowsetScroll::GetRowsAtRatio</c> reached the start or the end of the rowset or chapter and could not fetch
		/// all requested rows because the count extended beyond the end. The number of rows actually fetched is returned in *pcRowsObtained;
		/// this will be less than cRows.
		/// </para>
		/// <para>
		/// The rowset is being populated asynchronously, and no additional rows are available at this time. To determine whether additional
		/// rows may be available, the consumer should call <c>IDBAsynchStatus::GetStatus</c> or listen for the
		/// <c>IDBAsynchNotify::OnStop</c> notification.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// DB_S_ROWLIMITEXCEEDED Fetching the number of rows specified in cRows would have exceeded the total number of active rows
		/// supported by the rowset. The number of rows that were actually fetched is returned in *pcRowsObtained. This condition can occur
		/// only when there are more rows available than can be handled by the rowset. Therefore, this condition never conflicts with those
		/// described in DB_S_ENDOFROWSET and DB_S_STOPLIMITREACHED, both of which imply that no more rows were available.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// DB_S_STOPLIMITREACHED Fetching rows required further execution of the command, such as when the rowset uses a server-side cursor.
		/// Execution was stopped because a resource limit was reached. The number of rows that were actually fetched is returned in *pcRowsObtained.
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
		/// <para>
		/// E_OUTOFMEMORY The provider was unable to allocate sufficient memory in which to instantiate the rows or return the row handles.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>E_UNEXPECTED <c>ITransaction::Commit</c> or <c>ITransaction::Abort</c> was called, and the object is in a zombie state.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_E_BADCHAPTER The rowset was chaptered, and hChapter was invalid.</para>
		/// <para>
		/// The rowset was single-chaptered, and the specified chapter was not the currently open chapter. The consumer must use the
		/// currently open chapter or release the currently open chapter before specifying a new chapter.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_E_BADRATIO ulNumerator was greater than ulDenominator.</para>
		/// <para>ulDenominator was zero.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_E_CANTFETCHBACKWARDS cRows was negative, and the rowset cannot fetch backward.</para>
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
		// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/ms709602(v=vs.85) HRESULT GetRowsAtRatio ( HWATCHREGION
		// hReserved1, HCHAPTER hChapter, DBCOUNTITEM ulNumerator, DBCOUNTITEM ulDenominator, DBROWCOUNT cRows, DBCOUNTITEM *pcRowsObtained,
		// HROW **prghRows);
		[PreserveSig]
		new HRESULT GetRowsAtRatio([In, Optional] HWATCHREGION hReserved1, [In] HCHAPTER hChapter, DBCOUNTITEM ulNumerator, DBCOUNTITEM ulDenominator,
			DBROWCOUNT cRows, out DBCOUNTITEM pcRowsObtained, out SafeIMallocHandle prghRows);

		/// <summary>Returns the exact position of the specified bookmark and the exact rowcount.</summary>
		/// <param name="hChapter">[in] A chapter handle, used to limit the scope of the operations to the relevant rows.</param>
		/// <param name="cbBookmark">
		/// [in] The number of bytes in the data of the bookmark. This will be a 32-bit field on 32-bit platform and a 64-bit field on 64-bit platforms.
		/// </param>
		/// <param name="pBookmark">[in] Pointer to the bookmark data (a opaque sequence of bytes).</param>
		/// <param name="pulPosition">
		/// [out] Pointer to an unsigned field (32 bits on 32-bit platforms and 64 bits on 64-bit platforms) that returns the exact position
		/// of the bookmark relative to the beginning.
		/// </param>
		/// <param name="pcRows">
		/// [out] Pointer to an unsigned field (32 bits on 32-bit platforms and 64 bits on 64-bit platforms) that returns the number of rows
		/// in the rowset.
		/// </param>
		/// <returns></returns>
		// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/aa965358(v=vs.85) HRESULT GetExactPosition( HCHAPTER hChapter,
		// DBBKMARK cbBookmark, const BYTE *pBookmark, DBCOUNTITEM *pulPosition, DBCOUNTITEM *pcRows );
		[PreserveSig]
		HRESULT GetExactPosition([In] HCHAPTER hChapter, DBBKMARK cbBookmark, [In] IntPtr pBookmark, out DBCOUNTITEM pulPosition, out DBCOUNTITEM pcRows);
	}
}