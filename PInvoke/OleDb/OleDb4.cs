namespace Vanara.PInvoke;

/// <summary>Items from the OleDb.dll.</summary>
public static partial class OleDb
{
	/// <summary><c>IRowsetFind</c> is the interface that allows consumers to find a row within the rowset matching a specified value.</summary>
	// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/ms724221(v=vs.85)
	[PInvokeData("oledb.h")]
	[ComImport, Guid("0c733a9d-2a1c-11ce-ade5-00aa0044773d"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IRowsetFind
	{
		/// <summary>Begins at the specified bookmark and finds the next row matching the specified value.</summary>
		/// <param name="hChapter">
		/// [in] The chapter handle designating the rows to find. For nonchaptered rowsets, the caller must set hChapter to DB_NULL_HCHAPTER.
		/// For chaptered rowsets, DB_NULL_HCHAPTER designates the entire rowset.
		/// </param>
		/// <param name="hAccessor">
		/// <para>
		/// [in] Accessor describing the value to be matched. This accessor must describe only a single column. If it describes more than one
		/// column, <c>IRowsetFind::FindNextRow</c> returns DB_E_BADBINDINFO.
		/// </para>
		/// <para>Valid coercions for <c>IRowsetFind::FindNextRow</c> are the same as those for <c>IRowsetChange::SetData</c>.</para>
		/// </param>
		/// <param name="pFindValue">
		/// [in] Pointer to the value to be matched. If this indicates a null value (a variant of type VT_NULL or a status value of
		/// DBSTATUS_ISNULL), it is compared equal to null values and not equal to non-null values, within the rowset. It is
		/// provider-specific whether null values are compared greater than or less than non-null values.
		/// </param>
		/// <param name="CompareOp">
		/// <para>
		/// [in] Operation to use in comparing the row values. The consumer should check DBPROP_FINDCOMPAREOPS to determine which comparison
		/// operators the provider supports.
		/// </para>
		/// <para>Only DBCOMPAREOPS_EQ, DBCOMPAREOPS_NE, and DBCOMPAREOPS_IGNORE are valid for the following values of CompareOp:</para>
		/// <list type="bullet">
		/// <item>
		/// <description>
		/// <para>DBTYPE_BOOL</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DBTYPE_ERROR</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DBTYPE_GUID</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DBTYPE_IDISPATCH</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DBTYPE_IUNKNOWN</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DBTYPE_BYTES</para>
		/// </description>
		/// </item>
		/// </list>
		/// <para>The values in DBCOMPAREOPSENUM have the meanings described in the following table.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Value</description>
		/// <description>Description</description>
		/// </listheader>
		/// <item>
		/// <description>DBCOMPAREOPS_LT</description>
		/// <description>Match the first value that is less than the search value.</description>
		/// </item>
		/// <item>
		/// <description>DBCOMPAREOPS_LE</description>
		/// <description>Match the first value that is less than or equal to the search value.</description>
		/// </item>
		/// <item>
		/// <description>DBCOMPAREOPS_EQ</description>
		/// <description>Match the first value that is equal to the search value.</description>
		/// </item>
		/// <item>
		/// <description>DBCOMPAREOPS_GE</description>
		/// <description>Match the first value that is greater than or equal to the search value.</description>
		/// </item>
		/// <item>
		/// <description>DBCOMPAREOPS_GT</description>
		/// <description>Match the first value that is greater than the search value.</description>
		/// </item>
		/// <item>
		/// <description>DBCOMPAREOPS_BEGINSWITH</description>
		/// <description>
		/// Match the first value that has the search value as its first characters. This is valid only for values bound as string data types.
		/// </description>
		/// </item>
		/// <item>
		/// <description>DBCOMPAREOPS_NOTBEGINSWITH</description>
		/// <description>
		/// Match the first value that does not have the search value as its first characters. This is valid only for values bound as string
		/// data types.
		/// </description>
		/// </item>
		/// <item>
		/// <description>DBCOMPAREOPS_CONTAINS</description>
		/// <description>
		/// Match the first value that contains the search value. This is valid only for values bound as string data types.
		/// </description>
		/// </item>
		/// <item>
		/// <description>DBCOMPAREOPS_NOTCONTAINS</description>
		/// <description>
		/// Match the first value that does not contain the search value. This is valid only for values bound as string data types.
		/// </description>
		/// </item>
		/// <item>
		/// <description>DBCOMPAREOPS_NE</description>
		/// <description>
		/// Match the first value that is not equal to the search value. If the search value is NULL, this matches the first non-NULL value.
		/// If the search value is non-NULL, this matches the first non-NULL value that is not equal to the search value.
		/// </description>
		/// </item>
		/// <item>
		/// <description>DBCOMPAREOPS_IGNORE</description>
		/// <description>
		/// Ignore the corresponding value. The provider ignores <c>pFindValue</c> and returns the next <c>cRows</c> rows starting from the
		/// row indicated by <c>pBookmark</c>, skipping the number of rows indicated by <c>lRowsOffset</c>.
		/// </description>
		/// </item>
		/// <item>
		/// <description>DBCOMPAREOPS_CASESENSITIVE and DBCOMPAREOPS_CASEINSENSITIVE</description>
		/// <description>
		/// Specify whether the search is case-sensitive or case-insensitive. You can join DBCOMPAREOPS_CASESENSITIVE or
		/// DBCOMPAREOPS_CASEINSENSITIVE with any of the other DBCOMPAREOPS values in a bitwise <c>OR</c> operation. If neither is used, the
		/// search is handled according to the provider's implementation. Both DBCOMPAREOPS_CASESENSITIVE and DBCOMPAREOPS_CASEINSENSITIVE
		/// are ignored when searching for nonstring values.
		/// </description>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="cbBookmark">
		/// [in] Length in bytes of the bookmark, or zero to start from the next fetch location. (See the description of pBookmark.)
		/// </param>
		/// <param name="pBookmark">
		/// <para>
		/// [in] Pointer to a bookmark that, in combination with lRowsOffset, identifies the row from which to start searching for a match.
		/// The consumer is not required to have access rights to this row. However, if this row matches the seek criteria, the provider
		/// cannot return it unless the consumer has read permission for it.
		/// </para>
		/// <para>
		/// To request that the find occur starting with the next fetch location, the consumer can specify a cbBookmark value of zero and set
		/// pBookmark to null. The next fetch location is the same as the next fetch position used by <c>IRowset::GetNextRows</c>.
		/// </para>
		/// <para>If cbBookmark equals zero, the provider ignores pBookmark.</para>
		/// <para>
		/// If the rowset does not support <c>IRowsetLocate</c>, only the special bookmarks DBBMK_FIRST and DBBMK_LAST, and the null value,
		/// may be used.
		/// </para>
		/// <para>If the rowset does not support scrolling backward, only the null bookmark value may be used.</para>
		/// <para>If the rowset is chaptered, the identified row must fall within the specified chapter.</para>
		/// </param>
		/// <param name="lRowsOffset">
		/// [in] The signed count of rows from the origin bookmark to the row at which to start searching for a match. The first row checked
		/// is determined by the bookmark and this offset. For example, if lRowsOffset is 0, the first row checked is the bookmarked row; if
		/// lRowsOffset is 1, the first row checked is the row after the bookmarked row; if lRowsOffset is -1, the first row checked is the
		/// row before the bookmarked row. This can be a negative number only if the value of the DBPROP_CANSCROLLBACKWARDS property is VARIANT_TRUE.
		/// </param>
		/// <param name="cRows">
		/// <para>
		/// [in] The number of rows to fetch from the rowset, starting with the first row found. A negative number indicates a backward
		/// fetch. The consumer can determine whether the provider supports fetching backward by checking the value of the
		/// DBPROP_CANFETCHBACKWARDS property returned by <c>IRowsetInfo::GetProperties</c>.
		/// </para>
		/// <para>
		/// The search direction is the same as the fetch direction, so a negative count searches backward from the starting position and
		/// returns successively earlier rows as subsequent obtained rows. If cRows is zero and there are no other errors, no rows are
		/// fetched. In this case, if cbBookmark is zero, the next fetch position is moved to the same position as if calling
		/// <c>IRowsetFind::FindNextRow</c> with cRows equal to 1 and releasing the retrieved row. In general, consumers should avoid calling
		/// <c>IRowsetFind::FindNextRow</c> with cRows equal to zero.
		/// </para>
		/// <para>
		/// <para>Note</para>
		/// <para>
		/// Calling <c>IRowsetFind::FindNextRow</c> with a cbBookmark value of zero searches for a column value relative to the current
		/// <c>IRowset::GetNextRows</c> position. Following the call to <c>IRowsetFind::FindNextRow</c>, the fetch for
		/// <c>IRowset::GetNextRows</c> is also moved. Calling <c>IRowsetFind::FindNextRow</c> with a cbBookmark value of zero and a cRows
		/// value of zero is defined as setting the next fetch position to the same location as by calling <c>IRowsetFind::FindNextRow</c>
		/// with a cbBookmark value of zero and a cRows value of one.
		/// </para>
		/// <para>
		/// In general, it is not useful to call <c>IRowsetFind::FindNextRow</c> with a cRows value of zero. Due to ambiguity in the previous
		/// versions of the OLE DB Programmer's Reference, some providers may not implement the next fetch position as defined, and consumers
		/// should not rely on the next fetch position following a call to <c>IRowsetFind::FindNextRow</c> with a cbBookmark value of zero
		/// and a cRows value of zero.
		/// </para>
		/// </para>
		/// </param>
		/// <param name="pcRowsObtained">[out] A pointer to memory in which to return the actual number of fetched rows.</param>
		/// <param name="prghRows">
		/// [out] A pointer to memory in which to return an array of handles of the retrieved rows. If *prghRows is not a null pointer on
		/// input, it must be a pointer to memory large enough to return the handles of the requested number of rows. If *prghRows is a null
		/// pointer on input, the rowset allocates memory for the row handles and returns the address to this memory; the consumer releases
		/// this memory with <c>IMalloc::Free</c> after it releases the row handles. If *prghRows was a null pointer on input and
		/// *pcRowsObtained is 0 on output, the provider does not allocate any memory and ensures that *prghRows is a null pointer on output.
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
		/// DB_S_ENDOFROWSET <c>IRowsetFind::FindNextRow</c> reached the start or the end of the rowset or (in a hierarchical rowset) the
		/// start or the end of the chapter and could not fetch all requested rows because the count extended beyond the end. The next fetch
		/// position is before the start or after the end of the rowset. The number of rows actually returned is returned in *pcRowsObtained;
		/// this will be less than cRows.
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
		/// DB_S_STOPLIMITREACHED Returning rows required further execution of the command, such as when the rowset uses a server-side
		/// cursor. Execution has been stopped because a resource limit has been reached. The number of rows that were actually fetched is
		/// returned in *pcRowsObtained. Execution cannot be resumed.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// DB_S_BOOKMARKSKIPPED The following behavior is supported only on rowsets that set the DBPROP_BOOKMARKSKIPPED property to
		/// VARIANT_TRUE. If this property is VARIANT_FALSE, this return code is never returned.
		/// </para>
		/// <para>
		/// The row specified by *pBookmark was deleted, is no longer a member of the rowset, or is a row to which the consumer does not have
		/// access rights. <c>IRowsetFind::FindNextRow</c> skipped that row and began searching with the next row in the direction indicated
		/// by cRows.
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
		/// <para>E_FAIL A provider-specific error occurred.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>E_INVALIDARG pcRowsObtained or prghRows was a null pointer.</para>
		/// <para>cbBookmark was not 0, and pBookmark was a null pointer.</para>
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
		/// <para>DB_E_BADBINDINFO The specified accessor specified binding information for more than one column.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_E_BADBOOKMARK *pBookmark was invalid; for example, it was incorrectly formed.</para>
		/// <para>
		/// *pBookmark did not match any rows in the rowset. This includes the case when the row corresponding to the bookmark has been
		/// deleted and DBPROP_BOOKMARKSKIPPED was VARIANT_FALSE.
		/// </para>
		/// <para>*pBookmark was not a null value, and the rowset does not support scrolling backward.</para>
		/// <para>*pBookmark was not DBBMK_FIRST, DBBMK_LAST, or a null value, and the rowset does not support <c>IRowsetLocate</c>.</para>
		/// <para>The rowset was chaptered, and *pBookmark did not apply to the specified chapter.</para>
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
		/// <para>DB_E_BADCOMPAREOP CompareOp was an invalid value*.*</para>
		/// <para>CompareOp was DBCOMPAREOPS_BEGINSWITH or DBCOMPAREOPS_CONTAINS,and pFindValue was not bound as a string value.</para>
		/// <para>Both DBCOMPAREOPS_CASESENSITIVE and DBCOMPAREOPS_CASEINSENSITIVE were used in the same operation.</para>
		/// <para>The specified CompareOp could not be supported on the column, or the column was not searchable.</para>
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
		/// <para>DB_E_CANTSCROLLBACKWARDS A bookmark value of DBBMK_FIRST or DBBMK_LAST was specified, and the rowset cannot scroll backward.</para>
		/// <para>lRowsOffset was negative, and the rowset cannot scroll backward.</para>
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
		/// DB_E_ROWSNOTRELEASED The provider requires release of prior HROWs before new ones can be obtained. (See
		/// <c>IDBProperties::GetPropertyInfo</c>, DBPROP_CANHOLDROWS.)
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_SEC_E_PERMISSIONDENIED The consumer did not have sufficient permission to get the rows.</para>
		/// </description>
		/// </item>
		/// </list>
		/// </returns>
		// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/ms723091(v=vs.85) HRESULT FindNextRow ( HCHAPTER hChapter,
		// HACCESSOR hAccessor, void *pFindValue, DBCOMPAREOP CompareOp, DBBKMARK cbBookmark, const BYTE *pBookmark, DBROWOFFSET lRowsOffset,
		// DBROWCOUNT cRows, DBCOUNTITEM *pcRowsObtained, HROW **prghRows);
		[PreserveSig]
		HRESULT FindNextRow([In] HCHAPTER hChapter, [In] HACCESSOR hAccessor, [In] IntPtr pFindValue, DBCOMPAREOPS CompareOp, DBBKMARK cbBookmark,
			[In] IntPtr pBookmark, DBROWOFFSET lRowsOffset, DBROWCOUNT cRows, out DBCOUNTITEM pcRowsObtained, out SafeIMallocHandle prghRows);
	}

	/// <summary>
	/// <para>
	/// <c>IRowsetIdentity</c> is the interface that indicates row instance identity is implemented on the rowset and enables testing for row
	/// identity. If a rowset supports this interface, any two row handles representing the same underlying row will always reflect the same
	/// data and state.
	/// </para>
	/// <para><c>IRowsetIdentity</c> depends on <c>IRowset</c>.</para>
	/// </summary>
	// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/ms715913(v=vs.85)
	[PInvokeData("oledb.h")]
	[ComImport, Guid("0c733a09-2a1c-11ce-ade5-00aa0044773d"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IRowsetIdentity
	{
		/// <summary>Compares two row handles to see whether they refer to the same row instance.</summary>
		/// <param name="hThisRow">[in] The handle of an active row.</param>
		/// <param name="hThatRow">[in] The handle of an active row.</param>
		/// <returns>
		/// <list type="bullet">
		/// <item>
		/// <description>
		/// <para>S_FALSE The method succeeded, and the row handles do not refer to the same row instance.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>S_OK The method succeeded, and the row handles do refer to the same row instance.</para>
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
		/// <para>DB_E_BADROWHANDLE hRowThis or hRowThat was invalid.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_E_DELETEDROW hRowThis or hRowThat referred to a row for which a deletion had been transmitted to the data store.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// DB_E_NEWLYINSERTED The provider is unable to determine identity for a row for which an insertion had been transmitted to the data
		/// store. This condition can occur when DBPROP_STRONGIDENTITY is set to VARIANT_FALSE.
		/// </para>
		/// </description>
		/// </item>
		/// </list>
		/// </returns>
		// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/ms719629(v=vs.85) HRESULT IsSameRow ( HROW hThisRow, HROW hThatRow);
		[PreserveSig]
		HRESULT IsSameRow([In] HROW hThisRow, [In] HROW hThatRow);
	}

	/// <summary>
	/// <c>IRowsetIndex</c> is the primary interface for exposing index functionality in OLE DB. For a complete description of indexes, see
	/// Index Rowsets, and Integrated Indexes.
	/// </summary>
	// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/ms719604(v=vs.85)
	[PInvokeData("oledb.h")]
	[ComImport, Guid("0c733a82-2a1c-11ce-ade5-00aa0044773d"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IRowsetIndex
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
		HRESULT GetIndexInfo(out DBORDINAL pcKeyColumns, out SafeIMallocHandle prgIndexColumnDesc, out uint pcIndexPropertySets, out SafeIMallocHandle prgIndexPropertySets);

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
		HRESULT Seek([In] HACCESSOR hAccessor, DBORDINAL cKeyValues, [In] IntPtr pData, DBSEEK dwSeekOptions);

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
		HRESULT SetRange([In] HACCESSOR hAccessor, DBORDINAL cStartKeyColumns, [In] IntPtr pStartData, DBORDINAL cEndKeyColumns, [In] IntPtr pEndData, DBRANGE dwRangeOptions);
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
	/// <c>IRowsetLocate</c> is the interface for fetching arbitrary rows of a rowset. A rowset that does not implement this interface is a
	/// sequential rowset. <c>IRowsetLocate</c> is a prerequisite for <c>IRowsetScroll</c>.
	/// </para>
	/// <para>
	/// When <c>IRowsetLocate</c> or one of its direct descendants is present on a rowset, column 0 is the bookmark for the rows. Reading
	/// this column will obtain a bookmark value that can be used to reposition to the same row.
	/// </para>
	/// </summary>
	// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/ms721190(v=vs.85)
	[PInvokeData("oledb.h")]
	[ComImport, Guid("0c733a7d-2a1c-11ce-ade5-00aa0044773d"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IRowsetLocate : IRowset
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
		HRESULT Compare([In] HCHAPTER hChapter, DBBKMARK cbBookmark1, [In] IntPtr pBookmark1, DBBKMARK cbBookmark2, [In] IntPtr pBookmark2, out DBCOMPARE pComparison);

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
		/// deleted and DBPROP_BOOKMARKSKIPPED was VARIANT_FALSE.
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
		HRESULT GetRowsAt([In, Optional] HWATCHREGION hReserved1, [In] HCHAPTER hChapter, DBBKMARK cbBookmark, [In] IntPtr pBookmark,
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
		HRESULT GetRowsByBookmark([In] HCHAPTER hChapter, DBCOUNTITEM cRows, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] DBBKMARK[] rgcbBookmarks,
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
		HRESULT Hash([In] HCHAPTER hChapter, DBBKMARK cBookmarks, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] DBBKMARK[] rgcbBookmarks,
			[In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] IntPtr[] rgpBookmarks,
			[Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] DBHASHVALUE[] rgHashedValues,
			[Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] DBROWSTATUS[] rgBookmarkStatus);
	}

	/// <summary>
	/// <para>
	/// <c>IRowsetNotify</c> is the callback interface that a consumer must support to connect to local notifications provided by a rowset
	/// object. The notifications are intended to synchronize objects that are attached to the same rowset instance. The notifications do not
	/// reflect changes in underlying shared tables that occur through other programs or users.
	/// </para>
	/// <para>
	/// The notifications use the standard COM connection point scheme for operations or events on rowset objects. A rowset object supports
	/// IConnectionPointContainer, and the consumer calls <c>FindConnectionPoint</c> for IID_IRowsetNotify to obtain the correct
	/// <c>IConnectionPoint</c> interface. The consumer then advises that connection point to connect and supplies a pointer to the
	/// consumer's <c>IRowsetNotify</c> interface.
	/// </para>
	/// <para>Providers are required to support all notifications for which they have the underlying functionality.</para>
	/// <para>For more information about notifications, see OLE DB Object Notifications.</para>
	/// </summary>
	// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/ms712959(v=vs.85)
	[PInvokeData("oledb.h")]
	[ComImport, Guid("0c733a83-2a1c-11ce-ade5-00aa0044773d"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IRowsetNotify
	{
		/// <summary>Notifies the consumer of any change to the value of a column.</summary>
		/// <param name="pRowset">
		/// [in] A pointer to the rowset, because the consumer may be receiving notifications from multiple rowsets and this identifies which
		/// one is calling.
		/// </param>
		/// <param name="hRow">
		/// [in] The handle of the row in which the column value was changed. After this method returns, the reference count of this row will
		/// be unchanged unless the consumer explicitly changes it. This is different from other methods that return rows to the consumer, in
		/// which the provider explicitly increments the reference count. Therefore, if the consumer wants to guarantee that this row handle
		/// is valid after this method returns, it must call <c>IRowset::AddRefRows</c> for the row while it is processing this method.
		/// </param>
		/// <param name="cColumns">[in] The count of columns in rgColumns.</param>
		/// <param name="rgColumns">[in] An array of columns in the row for which the value was changed.</param>
		/// <param name="eReason">
		/// [in] The reason for the change as indicated by the value of DBREASON. If this value is not recognized by the method, the method
		/// returns S_OK or DB_S_UNWANTEDREASON.
		/// </param>
		/// <param name="ePhase">[in] The phase of this notification.</param>
		/// <param name="fCantDeny">
		/// [in] When this flag is set to TRUE, the consumer cannot veto the event by returning S_FALSE because the provider cannot undo the event.
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
		/// S_FALSE The notification, expressed by the value of DBREASON or DBEVENTPHASE or both, is vetoed by reason of logical objection or
		/// a failure to be able to implement.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// DB_S_UNWANTEDPHASE The consumer is not interested in receiving this phase for this reason. The provider can optimize by making no
		/// further calls with this reason and phase. The phases for other reasons are unaffected.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// DB_S_UNWANTEDREASON The consumer is not interested in receiving any phases for this reason. The provider can optimize by making
		/// no further calls with this reason.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>E_FAIL A consumer-specific error occurred. The provider continues the operation.</para>
		/// </description>
		/// </item>
		/// </list>
		/// </returns>
		// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/ms715961(v=vs.85) HRESULT OnFieldChange ( IRowset *pRowset,
		// HROW hRow, DBORDINAL cColumns, DBORDINAL rgColumns[], DBREASON eReason, DBEVENTPHASE ePhase, BOOL fCantDeny);
		[PreserveSig]
		HRESULT OnFieldChange([In] IRowset pRowset, [In] HROW hRow, DBORDINAL cColumns, [In, MarshalAs(UnmanagedType.LPArray)] DBORDINAL[] rgColumns,
			DBREASON eReason, DBEVENTPHASE ePhase, bool fCantDeny);

		/// <summary>Notifies the consumer of the first change to a row or of any change that affects the entire row.</summary>
		/// <param name="pRowset">
		/// [in] A pointer to the rowset, because the consumer may be receiving notifications from multiple rowsets and this identifies which
		/// one is calling.
		/// </param>
		/// <param name="cRows">[in] The count of row handles in rghRows.</param>
		/// <param name="rghRows">
		/// <para>
		/// [in] An array of handles of rows that are changing. This array belongs to the caller (rowset) and must not be freed or used
		/// beyond the duration of the method call.
		/// </para>
		/// <para>
		/// After this method returns, the reference count of these rows will be unchanged unless the consumer explicitly changes them. This
		/// is different from other methods that return rows to the consumer, in which the provider explicitly increments the reference
		/// counts. Therefore, if the consumer wants to guarantee that these row handles are valid after this method returns, it must call
		/// <c>IRowset::AddRefRows</c> for these rows while it is processing this method.
		/// </para>
		/// </param>
		/// <param name="eReason">
		/// [in] The reason for the change as indicated by the value of DBREASON. If this value is not recognized by the method, the method
		/// returns S_OK or DB_S_UNWANTEDREASON.
		/// </param>
		/// <param name="ePhase">[in] The phase of this notification.</param>
		/// <param name="fCantDeny">
		/// [in] When this flag is set to TRUE, the consumer cannot veto the event by returning S_FALSE because the provider cannot undo the event.
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
		/// S_FALSE The notification, expressed by the value of DBREASON or DBEVENTPHASE or both, is vetoed by reason of logical objection or
		/// a failure to be able to implement, as permitted for the phase.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// DB_S_UNWANTEDPHASE The consumer is not interested in receiving this phase for this reason. The provider can optimize by making no
		/// further calls with this reason and phase. The phases for other reasons are unaffected.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// DB_S_UNWANTEDREASON The consumer is not interested in receiving any phases for this reason. The provider can optimize by making
		/// no further calls with this reason.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>E_FAIL A consumer-specific error occurred. The provider continues the operation.</para>
		/// </description>
		/// </item>
		/// </list>
		/// </returns>
		// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/ms722694(v=vs.85)?redirectedfrom=MSDN HRESULT OnRowChange (
		// IRowset *pRowset, DBCOUNTITEM cRows, const HROW rghRows[], DBREASON eReason, DBEVENTPHASE ePhase, BOOL fCantDeny);
		[PreserveSig]
		HRESULT OnRowChange([In] IRowset pRowset, DBCOUNTITEM cRows, [In, MarshalAs(UnmanagedType.LPArray)] HROW[] rghRows, DBREASON eReason,
			DBEVENTPHASE ePhase, bool fCantDeny);

		/// <summary>Notifies the consumer of any change affecting the entire rowset.</summary>
		/// <param name="pRowset">
		/// [in] A pointer to the rowset, because the consumer may be receiving notifications from multiple rowsets and this identifies which
		/// one is calling.
		/// </param>
		/// <param name="eReason">
		/// [in] The reason for the change as indicated by the value of DBREASON. If this value is not recognized by the method, the method
		/// returns S_OK or DB_S_UNWANTEDREASON.
		/// </param>
		/// <param name="ePhase">[in] The phase of this notification.</param>
		/// <param name="fCantDeny">
		/// [in] When this flag is set to TRUE, the consumer cannot veto the event by returning S_FALSE because the provider cannot undo the event.
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
		/// S_FALSE The notification, expressed by the value of DBREASON or DBEVENTPHASE or both, is vetoed by reason of logical objection or
		/// a failure to be able to implement.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// DB_S_UNWANTEDPHASE The consumer is not interested in receiving this phase for this reason. The provider can optimize by making no
		/// further calls with this reason and phase. The phases for other reasons are unaffected.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// DB_S_UNWANTEDREASON The consumer is not interested in receiving any phases for this reason. The provider can optimize by making
		/// no further calls with this reason.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>E_FAIL A consumer-specific error occurred. The provider continues the operation.</para>
		/// </description>
		/// </item>
		/// </list>
		/// </returns>
		// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/ms722669(v=vs.85) HRESULT OnRowsetChange ( IRowset * pRowset,
		// DBREASON eReason, DBEVENTPHASE ePhase, BOOL fCantDeny);
		[PreserveSig]
		HRESULT OnRowsetChange([In] IRowset pRowset, DBREASON eReason, DBEVENTPHASE ePhase, bool fCantDeny);
	}

	/// <summary><c>IRowsetRefresh</c> is used to retrieve the values for rows that are currently visible to the transaction.</summary>
	// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/ms714892(v=vs.85)
	[PInvokeData("oledb.h")]
	[ComImport, Guid("0c733aa9-2a1c-11ce-ade5-00aa0044773d"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IRowsetRefresh
	{
		/// <summary>Retrieves the data values from the data store that are visible to the transaction for the specified rows.</summary>
		/// <param name="hChapter">
		/// [in] The chapter handle designating the rows to refresh. For nonchaptered rowsets, the caller must set hChapter to
		/// DB_NULL_HCHAPTER. For chaptered rowsets, DB_NULL_HCHAPTER designates the entire rowset.
		/// </param>
		/// <param name="cRows">
		/// [in] The count of rows to refresh. If cRows is zero, <c>IRowsetRefresh::RefreshVisibleData</c> ignores rghRows and reads in
		/// current values for all active rows.
		/// </param>
		/// <param name="rghRows">[in] An array of cRows row handles to be refreshed. If cRows is zero, this argument is ignored.</param>
		/// <param name="fOverwrite">
		/// [in] TRUE if the provider should discard any pending changes to a given row and accept the visible values as the new current
		/// values; FALSE otherwise.
		/// </param>
		/// <param name="pcRowsRefreshed">
		/// [out] A pointer to memory in which to return the number of rows the method attempted to refresh. This is still the case if
		/// DB_S_ERRORSOCCURRED or DB_E_ERRORSOCCURRED is returned. If any other error occurs, the provider sets *pcRowsRefreshed to zero. If
		/// this is a null pointer, no count of rows is returned.
		/// </param>
		/// <param name="prghRowsRefreshed">
		/// <para>
		/// [out] A pointer to memory in which to return the array of row handles the method attempted to refresh. If cRows is not zero, the
		/// elements of this array are in one-to-one correspondence with those of rghRows. If cRows is zero, the elements of this array are
		/// the handles of all rows that have been updated by the operation. In this case, <c>IRowsetRefresh::RefreshVisibleData</c> will add
		/// to the reference count of the rows whose handles are returned in prghRowsRefreshed.
		/// </para>
		/// <para>
		/// The rowset allocates memory for the handles and the client should release this memory with <c>IMalloc::Free</c> when no longer
		/// needed. This argument is ignored if pcRowsRefreshed is a null pointer and must not be a null pointer otherwise. If
		/// *pcRowsRefreshed is zero on output or the method fails, the provider does not allocate any memory and ensures that
		/// *prghRowsRefreshed is a null pointer on output.
		/// </para>
		/// </param>
		/// <param name="prgRowStatus">
		/// <para>
		/// [out] A pointer to memory in which to return an array of row status values. The elements of this array correspond one-to-one with
		/// the elements of *prghRowsRefreshed. If no errors occur while refreshing a row, the corresponding element of *prgRowStatus is set
		/// to DBROWSTATUS_S_OK if the row is successfully resynchronized, or to DBROWSTATUS_S_NOCHANGE if the provider can easily determine
		/// that there was no change to the value. If an error occurs while refreshing a row, the corresponding element is set as specified
		/// in DB_S_ERRORSOCCURRED. If prgRowStatus is a null pointer, no row status values are returned.
		/// </para>
		/// <para>
		/// The rowset allocates memory for the row status values and returns the address to this memory; the client releases this memory
		/// with <c>IMalloc::Free</c> when it is no longer needed. This argument is ignored if pcRowsRefreshed is a null pointer. If
		/// *pcRowsRefreshed is zero on output or the method fails, the provider does not allocate any memory and ensures that *prgRowStatus
		/// is a null pointer on output.
		/// </para>
		/// </param>
		/// <returns>
		/// <list type="bullet">
		/// <item>
		/// <description>
		/// <para>S_OK The method succeeded. All rows were successfully processed. For each row, prgRowStatus contains one of the following:</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// DB_S_ERRORSOCCURRED An error occurred while refreshing a row, but at least one row was successfully refreshed. Successes can
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
		/// <para>E_INVALIDARG cRows was not zero, and rghRows was a null pointer.</para>
		/// <para>pcRowsRefreshed was not a null pointer, and prghRowsRefreshed was a null pointer.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>E_UNEXPECTED <c>ITransaction::Commit</c> or <c>ITransaction::Abort</c> was called, and the object is in a zombie state.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_E_ERRORSOCCURRED Errors occurred while refreshing all of the rows. Errors can occur for the reasons listed under DB_S_ERRORSOCCURRED.</para>
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
		/// <para>DB_SEC_E_PERMISSIONDENIED The consumer did not have sufficient permission to refresh the rows.</para>
		/// </description>
		/// </item>
		/// </list>
		/// </returns>
		// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/ms714369(v=vs.85) HRESULT RefreshVisibleData ( HCHAPTER
		// hChapter, DBCOUNTITEM cRows, const HROW rghRows[], BOOL fOverwrite, DBCOUNTITEM *pcRowsRefreshed, HROW **prghRowsRefreshed,
		// DBROWSTATUS **prgRowStatus);
		[PreserveSig]
		HRESULT RefreshVisibleData([In] HCHAPTER hChapter, DBCOUNTITEM cRows, [In, MarshalAs(UnmanagedType.LPArray)] HROW[] rghRows, bool fOverwrite,
			out DBCOUNTITEM pcRowsRefreshed, out SafeIMallocHandle prghRowsRefreshed, out SafeIMallocHandle prgRowStatus);

		/// <summary>
		/// Gets the most recent data either from the provider-implemented data cache that is visible to the transaction or from the data store.
		/// </summary>
		/// <param name="hRow">
		/// [in] The handle of the row with pending changes for which to get the latest data. This can be the handle of a row with a pending delete.
		/// </param>
		/// <param name="hAccessor">
		/// [in] The handle of the accessor to use. If hAccessor is the handle of a null accessor (cBindings in
		/// <c>IAccessor::CreateAccessor</c> was zero), <c>IRowsetRefresh::GetLastVisibleData</c> does not get any data values.
		/// </param>
		/// <param name="pData">[out] A pointer to a buffer in which to return the data. The consumer allocates memory for this buffer.</param>
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
		/// <para>E_INVALIDARG pData was a null pointer, and hAccessor was not a null accessor.</para>
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
		/// DB_E_BADACCESSORHANDLE hAccessor was invalid. It is possible for a reference accessor or an accessor that has a binding that uses
		/// provider-owned memory to be invalid for use with this method, even if the accessor is valid for use with <c>IRowset::GetData</c>
		/// or <c>IRowsetChange::SetData</c>.
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
		/// <para>DB_E_BADROWHANDLE hRow was invalid.</para>
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
		/// <para>DB_E_PENDINGINSERT The rowset was in delayed update mode, and hRow referred to a pending insert row.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_SEC_E_PERMISSIONDENIED The consumer did not have sufficient permission to retrieve the rows from the data store.</para>
		/// </description>
		/// </item>
		/// </list>
		/// </returns>
		// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/ms719662(v=vs.85) HRESULT GetLastVisibleData ( HROW hRow,
		// HACCESSOR hAccessor, void *pData);
		[PreserveSig]
		HRESULT GetLastVisibleData([In] HROW hRow, [In] HACCESSOR hAccessor, [Out] IntPtr pData);
	}

	/// <summary>
	/// <c>IRowsetResynch</c> allows consumers to retrieve the current values for rows that may have been changed in the data store since retrieved.
	/// </summary>
	// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/ms723082(v=vs.85)
	[PInvokeData("oledb.h")]
	[ComImport, Guid("0c733a84-2a1c-11ce-ade5-00aa0044773d"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IRowsetResynch
	{
		/// <summary>Gets the data in the data store that is visible to the transaction for the specified row.</summary>
		/// <param name="hRow">
		/// [in] The handle of the row for which to get the visible data. This can be the handle of a row with a pending delete.
		/// </param>
		/// <param name="hAccessor">
		/// [in] The handle of the accessor to use. If hAccessor is the handle of a null accessor (cBindings in
		/// <c>IAccessor::CreateAccessor</c> was zero), <c>IRowsetResynch::GetVisibleData</c> does not get any data values.
		/// </param>
		/// <param name="pData">[out] A pointer to a buffer in which to return the data. The consumer allocates memory for this buffer.</param>
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
		/// least one column.
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
		/// <para>E_UNEXPECTED <c>ITransaction::Commit</c> or <c>ITransaction::Abort</c> was called, and the object is in a zombie state.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// DB_E_BADACCESSORHANDLE hAccessor was invalid. It is possible for a reference accessor or an accessor that has a binding that uses
		/// provider-owned memory to be invalid for use with this method, even if the accessor is valid for use with <c>IRowset::GetData</c>
		/// or <c>IRowsetChange::SetData</c>.
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
		/// <para>DB_E_BADROWHANDLE hRow was invalid.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_E_DELETEDROW hRow referred to a row for which a deletion had been transmitted to the data store.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// DB_E_ERRORSOCCURRED Errors occurred while returning data for all columns. To determine what errors occurred, the consumer checks
		/// the status values.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// DB_E_ABORTLIMITREACHED The provider was unable to retrieve the visible data due to reaching a limit on the server, such as a
		/// query execution timing out.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// DB_E_NEWLYINSERTED DBPROP_STRONGIDENTITY was VARIANT_FALSE, and hRow referred to a row for which an insertion had been
		/// transmitted to the data store.
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
		/// <para>DB_E_PENDINGINSERT The rowset was in delayed update mode, and hRow referred to a pending insert row.</para>
		/// </description>
		/// </item>
		/// </list>
		/// </returns>
		// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/ms725455(v=vs.85) HRESULT GetVisibleData (HROW hRow, HACCESSOR
		// hAccessor, void *pData);
		[PreserveSig]
		HRESULT GetVisibleData([In] HROW hRow, [In] HACCESSOR hAccessor, [Out] IntPtr pData);

		/// <summary>
		/// Gets the data in the data store that is visible to the transaction for the specified rows and updates the rowset's copies of
		/// those rows.
		/// </summary>
		/// <param name="cRows">
		/// [in] The count of rows to resynchronize. If cRows is zero, <c>IRowsetResynch::ResynchRows</c> ignores rghRows and reads the
		/// current value of all active rows.
		/// </param>
		/// <param name="rghRows">[in] An array of cRows row handles to be resynchronized. If cRows is zero, this argument is ignored.</param>
		/// <param name="pcRowsResynched">
		/// [out] A pointer to memory in which to return the number of rows the method attempted to resynchronize. The caller may supply a
		/// null pointer if no list is desired. If the method fails with an error other than DB_E_ERRORSOCCURRED, the provider sets
		/// *pcRowsResynched to zero.
		/// </param>
		/// <param name="prghRowsResynched">
		/// <para>
		/// [out] A pointer to memory in which to return the array of row handles the method attempted to resynchronize. If cRows is not
		/// zero, the elements of this array are in one-to-one correspondence with those of rghRows. If cRows is zero, the elements of this
		/// array are the handles of all active rows in the rowset. When cRows is zero, <c>IRowsetResynch::ResynchRows</c> will add to the
		/// reference count of the rows whose handles are returned in prghRowsResynched.
		/// </para>
		/// <para>
		/// The rowset allocates memory for the handles and the client should release this memory with <c>IMalloc::Free</c> when no longer
		/// needed. This argument is ignored if pcRowsResynched is a null pointer and must not be a null pointer otherwise. If
		/// *pcRowsResynched is zero on output or the method fails, the provider does not allocate any memory and ensures that
		/// *prghRowsResynched is a null pointer on output.
		/// </para>
		/// <para>If pcRowsResynched is a null pointer, prghRowsResynched and prgRowStatus are ignored.</para>
		/// <para>
		/// If pcRowsResynched is not a null pointer and if *pcRowsResynched is zero on output or the method fails, the provider does not
		/// allocate any memory and ensures that *prghRowsResynched and *prgRowStatus are null pointers on output.
		/// </para>
		/// </param>
		/// <param name="prgRowStatus">
		/// <para>
		/// [out] A pointer to memory in which to return an array of row status values. The elements of this array correspond one-to-one with
		/// the elements of *prghRowsResynched. If no errors occur while resynchronizing a row, the corresponding element of *prgRowStatus is
		/// set to DBROWSTATUS_S_OK. If the method fails while resynchronizing a row, the corresponding element is set as specified in
		/// DB_S_ERRORSOCCURRED. If prgRowStatus is a null pointer, no row status values are returned.
		/// </para>
		/// <para>
		/// The rowset allocates memory for the row status values and returns the address to this memory; the client releases this memory
		/// with <c>IMalloc::Free</c> when it is no longer needed. This argument is ignored if pcRowsResynched is a null pointer. If
		/// *pcRowsResynched is zero on output or if the method fails with an error other than DB_E_ERRORSOCCURRED, the provider does not
		/// allocate any memory and ensures that *prgRowStatus is a null pointer on output.
		/// </para>
		/// <para>If pcRowsResynched is a null pointer, prghRowsResynched and prgRowStatus are ignored.</para>
		/// <para>
		/// If pcRowsResynched is not a null pointer and if *pcRowsResynched is zero on output or the method fails, the provider does not
		/// allocate any memory and ensures that *prghRowsResynched and *prgRowStatus are null pointers on output.
		/// </para>
		/// </param>
		/// <returns>
		/// <list type="bullet">
		/// <item>
		/// <description>
		/// <para>S_OK The method succeeded. All rows were successfully resynchronized. The following value can be returned in *prgRowStatus:</para>
		/// <para>The row was successfully resynchronized. The corresponding element of *prgRowStatus contains DBROWSTATUS_S_OK.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// DB_S_ERRORSOCCURRED An error occurred while resynchronizing a row, but at least one row was successfully resynchronized.
		/// Successes can occur for the reason listed under S_OK. The following errors can occur:
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
		/// E_INVALIDARG cRows was not zero, and rghRows was a null pointer. pcRowsResynched was not a null pointer, and prghRowsResynched
		/// was a null pointer.
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
		/// <para>
		/// DB_E_ERRORSOCCURRED Errors occurred while resynchronizing all of the rows. Errors can occur for the reasons listed under DB_S_ERRORSOCCURRED.
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
		/// <para>DB_SEC_E_PERMISSIONDENIED The consumer did not have sufficient permission to resynchronize the rows.</para>
		/// </description>
		/// </item>
		/// </list>
		/// </returns>
		// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/ms717937(v=vs.85) HRESULT ResynchRows ( DBCOUNTITEM cRows,
		// const HROW rghRows[], DBCOUNTITEM *pcRowsResynched, HROW **prghRowsResynched, DBROWSTATUS **prgRowStatus);
		[PreserveSig]
		HRESULT ResynchRows(DBCOUNTITEM cRows, [In, MarshalAs(UnmanagedType.LPArray)] HROW[] rghRows,
			out DBCOUNTITEM pcRowsResynched, out SafeIMallocHandle prghRowsResynched, out SafeIMallocHandle prgRowStatus);
	}

	/// <summary><c>IRowsetScroll</c> enables consumers to fetch rows at approximate positions in the rowset.</summary>
	// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/ms712984(v=vs.85)
	[PInvokeData("oledb.h")]
	[ComImport, Guid("0c733a7e-2a1c-11ce-ade5-00aa0044773d"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IRowsetScroll : IRowsetLocate
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
		/// deleted and DBPROP_BOOKMARKSKIPPED was VARIANT_FALSE.
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
		/// deleted and either DBPROP_BOOKMARKSKIPPED was VARIANT_FALSE or the provider is a 1.x provider that does not support getting the
		/// approximate position of a deleted row.
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
		HRESULT GetApproximatePosition([In] HCHAPTER hChapter, DBBKMARK cbBookmark, [In] IntPtr pBookmark, out DBCOUNTITEM pulPosition, out DBCOUNTITEM pcRows);

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
		HRESULT GetRowsAtRatio([In, Optional] HWATCHREGION hReserved1, [In] HCHAPTER hChapter, DBCOUNTITEM ulNumerator, DBCOUNTITEM ulDenominator,
			DBROWCOUNT cRows, out DBCOUNTITEM pcRowsObtained, out SafeIMallocHandle prghRows);
	}
}