namespace Vanara.PInvoke;

/// <summary>Items from the OleDb.dll.</summary>
public static partial class OleDb
{
	/// <summary>Flags describing additional semantics for the copy operation</summary>
	[PInvokeData("oledb.h")]
	[Flags]
	public enum DBCOPYFLAGS
	{
		/// <summary>
		/// The copy operation is performed asynchronously. Progress and notifications are available by using IDBAsynchStatus and
		/// IDBAsynchNotify callbacks. Implementations that do not support asynchronous behavior should block and return a warning.
		/// </summary>
		DBCOPY_ASYNC = 0x100,

		/// <summary>
		/// The copy operation succeeds even if a target object already exists at the destination URL. Otherwise, the copy fails if a target
		/// object already exists.
		/// </summary>
		DBCOPY_REPLACE_EXISTING = 0x200,

		/// <summary>
		/// If this flag is set and the attempt to copy the tree or subtree fails because the destination URL is on a different server or
		/// serviced by a different provider than the source, the provider is requested to attempt to simulate the copy using download and
		/// upload operations. When moving entities between providers, this may cause increased latency or data loss due to different
		/// provider capabilities.
		/// </summary>
		DBCOPY_ALLOW_EMULATION = 0x400,

		/// <summary>If this flag is set, only the root node of the tree is copied; no child nodes are copied.</summary>
		DBCOPY_NON_RECURSIVE = 0x800,

		/// <summary>
		/// Either all trees or subtrees are copied successfully or none are copied. Whether all parts of an atomic operation are attempted
		/// if one part fails is provider-specific.
		/// </summary>
		DBCOPY_ATOMIC = 0x1000
	}

	/// <summary>A bitmask of flags that control additional semantics for the delete operation</summary>
	[PInvokeData("oledb.h")]
	[Flags]
	public enum DBDELETEFLAGS
	{
		/// <summary>
		/// The delete operation is performed asynchronously. Progress and notifications are available via IDBAsynchStatus and
		/// IDBAsynchNotify callbacks. Implementations that do not support asynchronous behavior should block and return a warning. If
		/// DBDELETE_ASYNC is not specified, the operation is synchronous. A value of 0 is allowed.
		/// </summary>
		DBDELETE_ASYNC = 0x100,

		/// <summary>
		/// Either all trees and subtrees are deleted or none are deleted. Whether all parts of an atomic operation are attempted if one part
		/// fails is provider-specific. If DBDELETE_ATOMIC is not specified, the operation is non-atomic. A value of 0 is allowed.
		/// </summary>
		DBDELETE_ATOMIC = 0x1000
	}

	/// <summary>Flags describing additional semantics for the move operation</summary>
	[PInvokeData("oledb.h")]
	[Flags]
	public enum DBMOVEFLAGS
	{
		/// <summary>
		/// The move operation succeeds, even if a target object exists. Without this value, the move will fail if the target object already exists.
		/// </summary>
		DBMOVE_REPLACE_EXISTING = 0x1,

		/// <summary>
		/// The move operation is performed asynchronously. Progress and notifications are available via IDBAsynchStatus and IDBAsynchNotify
		/// callbacks. Implementations that do not support asynchronous behavior should block and return a warning.
		/// </summary>
		DBMOVE_ASYNC = 0x100,

		/// <summary>
		/// <para>Request the server not to update links contained in an object on a move.</para>
		/// <para>
		/// If this flag is not specified, the default behavior is to do what the server specifies. By default, IScopedOperations::Move will
		/// update links if the server is capable and if the option is turned on. If the server does not have the ability to fix up links or
		/// if the option is turned off, this call will still return S_OK.
		/// </para>
		/// </summary>
		DBMOVE_DONT_UPDATE_LINKS = 0x200,

		/// <summary>
		/// If the attempt to move the row fails because the destination URL is on a different server or serviced by a different provider
		/// than the source, the provider is requested to attempt to simulate the move using download, upload, and delete operations. When
		/// moving resources between providers, this may cause increased latency or data loss due to different provider capabilities.
		/// </summary>
		DBMOVE_ALLOW_EMULATION = 0x400,

		/// <summary>
		/// Either all sources are moved successfully or no sources are moved. Whether all parts of an atomic operation are attempted if one
		/// part fails is provider-specific.
		/// </summary>
		DBMOVE_ATOMIC = 0x1000
	}

	/// <summary>Indicates whether consumers want rows with pending updates, deletes, or inserts.</summary>
	[PInvokeData("oledb.h")]
	[Flags]
	public enum DBPENDINGSTATUS : uint
	{
		/// <summary>The row has a pending insert.</summary>
		DBPENDINGSTATUS_NEW = 0x1,

		/// <summary>The row has a deferred change.</summary>
		DBPENDINGSTATUS_CHANGED = 0x2,

		/// <summary>The row has a pending delete. This state is sometimes called soft delete.</summary>
		DBPENDINGSTATUS_DELETED = 0x4,

		/// <summary>No changes have been made to the row, or changes that were made to the row have been transmitted or undone.</summary>
		DBPENDINGSTATUS_UNCHANGED = 0x8,

		/// <summary>
		/// The row has been deleted and that deletion has been transmitted to the data store. This status is also used when a row handle
		/// passed to IRowsetUpdate::GetRowStatus was invalid. This state is sometimes called hard delete.
		/// </summary>
		DBPENDINGSTATUS_INVALIDROW = 0x10
	}

	/// <summary>
	/// <para>
	/// <c>IRowsetUpdate</c> enables consumers to delay the transmission of changes made with <c>IRowsetChange</c> to the data store. This
	/// interface also enables consumers to undo changes before transmission.
	/// </para>
	/// <para><c>IRowsetUpdate</c> is optional.</para>
	/// </summary>
	// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/ms714401(v=vs.85)
	[PInvokeData("oledb.h")]
	[ComImport, Guid("0c733a6d-2a1c-11ce-ade5-00aa0044773d"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IRowsetUpdate : IRowsetChange
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
		new HRESULT DeleteRows(HCHAPTER hChapter, DBCOUNTITEM cRows, [In, MarshalAs(UnmanagedType.LPArray)] HROW[] rghRows,
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
		new HRESULT SetData([In] HROW hRow, [In] HACCESSOR hAccessor, [In] IntPtr pData);

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
		new HRESULT InsertRow([In] HCHAPTER hChapter, [In] HACCESSOR hAccessor, [In] IntPtr pData, out HROW phRow);

		/// <summary>Gets the data most recently fetched from or transmitted to the data store. Does not get values based on pending changes.</summary>
		/// <param name="hRow">
		/// [in] The handle of the row for which to get the original data. This can be the handle of a row with a pending change or delete.
		/// </param>
		/// <param name="hAccessor">
		/// [in] The handle of the accessor to use. If hAccessor is the handle of a null accessor (cBindingsin
		/// <c>IAccessor::CreateAccessor</c> was zero), <c>IRowsetUpdate::GetOriginalData</c> does not get any data values.
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
		/// DB_S_ERRORSOCCURRED A row handle in rghRows referred to a row on which a storage or other object was open. The corresponding
		/// element of *prgRowStatus contains DBROWSTATUS_E_OBJECTOPEN.
		/// </para>
		/// <para>
		/// An error occurred while returning data for one or more columns, but data was successfully returned for at least one column. To
		/// determine the columns for which data was returned, the consumer checks the status values. For a list of status values that can be
		/// returned by this method, see "Status Values Used When Getting Data" in Status.
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
		/// <para>E_UNEXPECTED ITransaction::Commit or ITransaction::Abort was called, and the object is in a zombie state.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// DB_E_BADACCESSORHANDLE hAccessor was invalid. It is possible for a reference accessor or an accessor that has a binding that uses
		/// provider-owned memory to be invalid for use with this method, even if the accessor is valid for use with IRowset::GetData or IRowsetChange::SetData.
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
		/// the status values. For a list of status values that can be returned by this method, see "Status Values Used When Getting Data" in Status.
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
		/// </list>
		/// </returns>
		// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/ms709947(v=vs.85) HRESULT GetOriginalData ( HROW hRow,
		// HACCESSOR hAccessor, void *pData);
		[PreserveSig]
		HRESULT GetOriginalData([In] HROW hRow, [In] HACCESSOR hAccessor, [Out] IntPtr pData);

		/// <summary>Returns a list of rows with pending changes.</summary>
		/// <param name="hReserved">[in] Reserved for future use. Must be DB_NULL_HCHAPTER.</param>
		/// <param name="dwRowStatus">
		/// <para>
		/// [in] Indicates whether consumers want rows with pending updates, deletes, or inserts. The following DBPENDINGSTATUS values are
		/// valid and can be combined:
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <description>
		/// <para>DBPENDINGSTATUS_NEW</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DBPENDINGSTATUS_CHANGED</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DBPENDINGSTATUS_DELETED</para>
		/// </description>
		/// </item>
		/// </list>
		/// <para>For information about the DBPENDINGSTATUS type, see Row States in Deferred Update Mode.</para>
		/// </param>
		/// <param name="pcPendingRows">
		/// [out] A pointer to memory in which to return the number of rows with pending changes. If this is a null pointer, prgPendingRows
		/// and prgPendingStatus are ignored. This is useful when the consumer wants to check the returned return code to determine whether
		/// there are any pending changes. If an error occurs, *pcPendingRows is set to zero.
		/// </param>
		/// <param name="prgPendingRows">
		/// [out] A pointer to memory in which to return an array of handles of rows with pending changes. If this is a null pointer, no row
		/// handles are returned. The rowset allocates memory for the row handles and returns the address to this memory; the consumer
		/// releases this memory with <c>IMalloc::Free</c> when it no longer needs the row handles. This argument is ignored if pcPendingRows
		/// is a null pointer. If *pcPendingRows is zero on output or an error occurs, the provider does not allocate any memory and ensures
		/// that *prgPendingRows is a null pointer on output.
		/// </param>
		/// <param name="prgPendingStatus">
		/// <para>
		/// [out] A pointer to memory in which to return an array of DBPENDINGSTATUS values. These values are in one-to-one correspondence
		/// with the row handles returned in *prgPendingRows and indicate the type of pending change. For information about the
		/// DBPENDINGSTATUS type, see Row States in Deferred Update Mode. If this is a null pointer, no status information is returned.
		/// </para>
		/// <para>
		/// The rowset allocates memory for the row statuses and returns the address to this memory; the consumer releases this memory with
		/// <c>IMalloc::Free</c> when it no longer needs the row statuses. This argument is ignored if pcPendingRows is a null pointer. If
		/// *pcPendingRows is zero on output or an error occurs, the provider does not allocate any memory and ensures that *prgPendingStatus
		/// is a null pointer on output.
		/// </para>
		/// </param>
		/// <returns>
		/// <list type="bullet">
		/// <item>
		/// <description>
		/// <para>S_OK The method succeeded, and changes were pending.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>S_FALSE The method succeeded, and no changes were pending.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>E_FAIL A provider-specific error occurred.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>E_INVALIDARG dwRowStatus was DBPENDINGSTATUS_INVALIDROW, DBPENDINGSTATUS_UNCHANGED, or any other invalid value.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// E_OUTOFMEMORY The provider was unable to allocate sufficient memory in which to return the handles of rows with pending changes
		/// or the array of DBPENDINGSTATUS values.
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
		/// <para>DB_E_BADCHAPTER The rowset was chaptered, and hReserved was invalid.</para>
		/// <para>
		/// The rowset was single-chaptered, and the specified chapter was not the currently open chapter. The consumer must use the
		/// currently open chapter or release the currently open chapter before specifying a new chapter.
		/// </para>
		/// </description>
		/// </item>
		/// </list>
		/// </returns>
		// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/ms719626(v=vs.85) HRESULT GetPendingRows ( HCHAPTER hReserved,
		// DBPENDINGSTATUS dwRowStatus, DBCOUNTITEM *pcPendingRows, HROW **prgPendingRows, DBPENDINGSTATUS **prgPendingStatus);
		[PreserveSig]
		HRESULT GetPendingRows([In] HCHAPTER hReserved, DBPENDINGSTATUS dwRowStatus, out DBCOUNTITEM pcPendingRows,
			out SafeIMallocHandle prgPendingRows, out SafeIMallocHandle prgPendingStatus);

		/// <summary>Returns the status of rows.</summary>
		/// <param name="hReserved">[in] Reserved for future use. Must be DB_NULL_HCHAPTER.</param>
		/// <param name="cRows">
		/// [in] The count of elements in rghRows and rgPendingStatus. If this value is zero, <c>IRowsetUpdate::GetRowStatus</c> ignores
		/// rghRows and rgPendingStatus and does not return any status.
		/// </param>
		/// <param name="rghRows">
		/// [in] An array of handles of rows for which to return the status. This array is allocated by the consumer and must not be freed by
		/// the provider.
		/// </param>
		/// <param name="rgPendingStatus">
		/// <para>
		/// [out] An array of DBPENDINGSTATUS values. <c>IRowsetUpdate::GetRowStatus</c> returns the DBPENDINGSTATUS values for all rows
		/// specified in the rghRows array. The DBPENDINGSTATUS_INVALIDROW value is used to indicate an invalid row handle. For information
		/// about the DBPENDINGSTATUS type, see Row States in Deferred Update Mode.
		/// </para>
		/// <para>The rgPendingStatus array is allocated, but not necessarily initialized, by the caller and must not be freed by the provider.</para>
		/// </param>
		/// <returns>
		/// <list type="bullet">
		/// <item>
		/// <description>
		/// <para>
		/// S_OK The method succeeded. Status values were successfully retrieved for all rows, and each element of rgPendingStatus is set to
		/// DBPENDINGSTATUS_NEW, DBPENDINGSTATUS_CHANGED, DBPENDINGSTATUS_DELETED, or DBPENDINGSTATUS_UNCHANGED.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// DB_S_ERRORSOCCURRED An error occurred while getting the status of a row, but the status of at least one row was successfully
		/// retrieved. Successes can occur for the reasons listed under S_OK. The following error can occur:
		/// </para>
		/// <para>A row handle in rghRows was invalid. The corresponding element of rgRowStatus contains DBPENDINGSTATUS_INVALIDROW.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>E_FAIL A provider-specific error occurred.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>E_INVALIDARG cRows was greater than zero, and either rghRows was a null pointer or rgPendingStatus was a null pointer.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>E_UNEXPECTED <c>ITransaction::Commit</c> or <c>ITransaction::Abort</c> was called, and the object is in a zombie state.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_E_BADCHAPTER The rowset was chaptered, and hReserved was invalid.</para>
		/// <para>
		/// The rowset was single-chaptered, and the specified chapter was not the currently open chapter. The consumer must use the
		/// currently open chapter or release the currently open chapter before specifying a new chapter.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// DB_E_ERRORSOCCURRED Errors occurred getting the status of all of the rows. Errors can occur for the reason listed under DB_S_ERRORSOCCURRED.
		/// </para>
		/// </description>
		/// </item>
		/// </list>
		/// </returns>
		// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/ms724377(v=vs.85) HRESULT GetRowStatus( HCHAPTER hReserved,
		// DBCOUNTITEM cRows, const HROW rghRows[], DBPENDINGSTATUS rgPendingStatus[]);
		[PreserveSig]
		HRESULT GetRowStatus([In] HCHAPTER hReserved, DBCOUNTITEM cRows, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] HROW[] rghRows,
			[Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] DBPENDINGSTATUS[] rgPendingStatus);

		/// <summary>Undoes any changes made to a row since it was last fetched or <c>IRowsetUpdate::Update</c> was called for it.</summary>
		/// <param name="hReserved">[in] Reserved for future use. Must be DB_NULL_HCHAPTER.</param>
		/// <param name="cRows">
		/// [in] The count of rows to undo. If cRows is nonzero, <c>IRowsetUpdate::Undo</c> undoes all pending changes in the rows specified
		/// in rghRows. If cRows is zero, <c>IRowsetUpdate::Undo</c> ignores rghRows and undoes all pending changes to all rows in the rowset.
		/// </param>
		/// <param name="rghRows">
		/// <para>[in] An array of handles of the rows to undo. Elements of this array can refer to rows with pending deletes.</para>
		/// <para>
		/// If rghRows includes a row that does not have any pending changes, <c>IRowsetUpdate::Undo</c> does not return an error. Instead,
		/// the row remains unchanged from its original state ? which is the intention of <c>IRowsetUpdate::Undo</c> ? and its row status is
		/// set to DBROWSTATUS_S_OK.
		/// </para>
		/// <para>
		/// If rghRows includes a duplicate row, <c>IRowsetUpdate::Undo</c> treats the occurrences as if the row were passed to the method
		/// two times sequentially. Therefore, on the first occurrence, <c>IRowsetUpdate::Undo</c> undoes any pending changes. On the second
		/// occurrence, <c>IRowsetUpdate::Undo</c> treats the row as a row with no pending changes and leaves it in its current (now
		/// original) state.
		/// </para>
		/// </param>
		/// <param name="pcRowsUndone">
		/// [out] A pointer to memory in which to return the number of rows <c>IRowsetUpdate::Undo</c> attempted to undo. If this is a null
		/// pointer, no count of rows is returned. If the method fails with an error other than DB_E_ERRORSOCCURRED, *pcRows is set to zero.
		/// </param>
		/// <param name="prgRowsUndone">
		/// <para>
		/// [out] A pointer to memory in which to return an array containing the handles of all the rows <c>IRowsetUpdate::Undo</c> attempted
		/// to undo. If rghRows is not a null pointer, the elements of this array are in one-to-one correspondence with those in rghRows. For
		/// example, if a row appears twice in rghRows, it appears twice in *prgRows. When rghRows is not a null pointer,
		/// <c>IRowsetUpdate::Undo</c> does not add to the reference count of the rows it returns in *prgRows, because the consumer already
		/// has these row handles.
		/// </para>
		/// <para>
		/// If rghRows is a null pointer, the elements of this array are the handles of all the rows that had pending changes, whether or not
		/// <c>IRowsetUpdate::Undo</c> was successful at undoing those changes. The consumer checks *prgRowStatus to determine which rows
		/// were undone. When rghRows is a null pointer, <c>IRowsetUpdate::Undo</c> adds to the reference count of the rows it returns in
		/// *prgRows, because the consumer is not guaranteed to already have these row handles. A side effect of this is that rows with a
		/// reference count of zero, but with pending changes at the time <c>IRowsetUpdate::Undo</c> is called, are brought back into
		/// existence; that is, their reference count is increased to 1 and they must be rereleased.
		/// </para>
		/// <para>
		/// The rowset allocates memory for the array of handles and returns the address to this memory; the consumer releases this memory
		/// with <c>IMalloc::Free</c> when it no longer needs the handles. This argument is ignored if pcRows is a null pointer and must not
		/// be a null pointer otherwise. If *pcRows is zero on output or the method fails with an error other than DB_E_ERRORSOCCURRED, the
		/// provider does not allocate any memory and ensures that *prgRows is a null pointer on output.
		/// </para>
		/// </param>
		/// <param name="prgRowStatus">
		/// <para>
		/// [out] A pointer to memory in which to return an array of row status values. The elements of this array correspond one-to-one with
		/// the elements of rghRows (if rghRows is not a null pointer) or *prgRows (if rghRows is a null pointer). If no errors occur while
		/// undoing a row, the corresponding element of *prgRowStatus is set to DBROWSTATUS_S_OK. If an error occurs while undoing a row, the
		/// corresponding element is set as specified in DB_S_ERRORSOCCURRED. If prgRowStatus is a null pointer, no row status values are returned.
		/// </para>
		/// <para>
		/// The rowset allocates memory for the row status values and returns the address to this memory; the consumer releases this memory
		/// with <c>IMalloc::Free</c> when it no longer needs the row status values. This argument is ignored if cRows is zero and pcRows is
		/// a null pointer. If <c>IRowsetUpdate::Undo</c> does not attempt to undo any rows or the method fails with an error other than
		/// DB_E_ERRORSOCCURRED, the provider does not allocate any memory and ensures that *prgRowStatus is a null pointer on output.
		/// </para>
		/// </param>
		/// <returns>
		/// <list type="bullet">
		/// <item>
		/// <description>
		/// <para>S_OK The method succeeded. The changes in all rows were successfully undone. The following value can be returned in *prgRowStatus:</para>
		/// <para>The changes in the row were successfully undone. The corresponding element of *prgRowStatus contains DBROWSTATUS_S_OK.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// DB_S_ERRORSOCCURRED An error occurred while undoing the changes in a row, but the changes in at least one row were successfully
		/// undone. Successes can occur for the reasons listed under S_OK. The following errors can occur:
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
		/// <para>E_INVALIDARG cRows was not 0, and rghRows was a null pointer.</para>
		/// <para>pcRows was not a null pointer, and prgRows was a null pointer.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// E_OUTOFMEMORY The provider was unable to allocate sufficient memory in which to return either the handles of the rows
		/// <c>IRowsetUpdate::Undo</c> attempted to undo or the array of row status values.
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
		/// <para>DB_E_BADCHAPTER The rowset was chaptered, and hReserved was invalid.</para>
		/// <para>
		/// The rowset was single-chaptered, and the specified chapter was not the currently open chapter. The consumer must use the
		/// currently open chapter or release the currently open chapter before specifying a new chapter.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// DB_E_ERRORSOCCURRED Errors occurred while undoing all of the rows. The provider allocates memory for *prgRows and *prgRowStatus,
		/// and the consumer checks the values in *prgRowStatus to determine why the pending changes were not undone. The consumer frees this
		/// memory when it no longer needs the information. Errors can occur for the reasons listed under DB_S_ERRORSOCCURRED.
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
		// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/ms719655(v=vs.85) HRESULT Undo ( HCHAPTER hReserved,
		// DBCOUNTITEM cRows, const HROW rghRows[], DBCOUNTITEM *pcRows, HROW **prgRows, DBROWSTATUS **prgRowStatus);
		[PreserveSig]
		HRESULT Undo([In] HCHAPTER hReserved, DBCOUNTITEM cRows, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] HROW[] rghRows,
			out DBCOUNTITEM pcRowsUndone, out SafeIMallocHandle prgRowsUndone, out SafeIMallocHandle prgRowStatus);

		/// <summary>
		/// Transmits any changes made to an existing row since it was last fetched or <c>IRowsetUpdate::Update</c> was called for it.
		/// Transmits a newly created row that is pending insert.
		/// </summary>
		/// <param name="hReserved">[in] Reserved for future use. Must be DB_NULL_HCHAPTER.</param>
		/// <param name="cRows">
		/// [in] The count of rows to update. If cRows is nonzero, <c>IRowsetUpdate::Update</c> updates all pending changes in the rows
		/// specified in rghRows. If cRows is zero, <c>IRowsetUpdate::Update</c> ignores rghRows and updates all pending changes to all rows
		/// in the rowset.
		/// </param>
		/// <param name="rghRows">
		/// <para>[in] An array of handles of the rows to update.</para>
		/// <para>
		/// If rghRows includes a row that does not have any pending changes, <c>IRowsetUpdate::Update</c> does not return an error. Instead,
		/// the row remains unchanged and hence has no pending changes after <c>Update</c> returns ? which is the intention of <c>Update</c>
		/// ? and the row status value associated with that row is DBROWSTATUS_S_OK. Furthermore, <c>IRowsetUpdate::Update</c> guarantees not
		/// to transmit any value for the row to the data store.
		/// </para>
		/// <para>
		/// If rghRows includes a duplicate row, <c>IRowsetUpdate::Update</c> behaves as follows. If the row handle is valid, no errors occur
		/// and *prgRowStatus contains DBROWSTATUS_S_OK for each occurrence. If the row handle is invalid, *prgRowStatus contains the
		/// appropriate error for each occurrence.
		/// </para>
		/// </param>
		/// <param name="pcRows">
		/// [out] A pointer to memory in which to return the number of rows <c>IRowsetUpdate::Update</c> attempted to update. If this is a
		/// null pointer, no count of rows is returned. If the method fails with an error other than DB_E_ERRORSOCCURRED, *pcRows is set to zero.
		/// </param>
		/// <param name="prgRows">
		/// <para>
		/// [out] A pointer to memory in which to return an array containing the handles of all the rows <c>IRowsetUpdate::Update</c>
		/// attempted to update. If rghRows is not a null pointer, the elements of this array are in one-to-one correspondence with those in
		/// rghRows. For example, if a row appears twice in rghRows, it appears twice in *prgRows. When rghRows is not a null pointer,
		/// <c>IRowsetUpdate::Update</c> does not add to the reference count of the rows it returns in *prgRows; the reason is that the
		/// consumer already has these row handles.
		/// </para>
		/// <para>
		/// If rghRows is a null pointer, the elements of this array are handles of all the rows that had pending changes, whether or not
		/// <c>IRowsetUpdate::Update</c> was successful at transmitting those changes to the data store. The consumer checks *prgRowStatus to
		/// determine which rows were updated. When rghRows is a null pointer, <c>IRowsetUpdate::Update</c> adds to the reference count of
		/// the rows it returns in *prgRows; the reason is that the consumer is not guaranteed to already have these row handles. A side
		/// effect of this is that rows with a reference count of zero, but with pending changes at the time <c>IRowsetUpdate::Update</c> is
		/// called, are brought back into existence; that is, their reference count is increased to 1 and they must be rereleased.
		/// </para>
		/// <para>
		/// The rowset allocates memory for the array of handles and returns the address to this memory; the consumer releases this memory
		/// with <c>IMalloc::Free</c> when it no longer needs the handles. This argument is ignored if pcRows is a null pointer and must not
		/// be a null pointer otherwise. If *pcRows is zero on output or the method fails with an error other than DB_E_ERRORSOCCURRED, the
		/// provider does not allocate any memory and ensures that *prgRows is a null pointer on output.
		/// </para>
		/// </param>
		/// <param name="prgRowStatus">
		/// <para>
		/// [out] A pointer to memory in which to return an array of row status values. The elements of this array correspond one-to-one with
		/// the elements of rghRows (if rghRows is not a null pointer) or *prgRows (if rghRows is a null pointer). If no errors or warnings
		/// occur while updating a row, the corresponding element of *prgRowStatus is set to DBROWSTATUS_S_OK. If an error or warning occurs
		/// while updating a row, the corresponding element is set as specified in DB_S_ERRORSOCCURRED. If prgRowStatus is a null pointer, no
		/// row status values are returned.
		/// </para>
		/// <para>
		/// The rowset allocates memory for the row status values and returns the address to this memory; the consumer releases this memory
		/// with <c>IMalloc::Free</c> when it no longer needs the row status values. This argument is ignored if cRows is zero and pcRows is
		/// a null pointer. If <c>IRowsetUpdate::Update</c> does not attempt to update any rows or the method fails with an error other than
		/// DB_E_ERRORSOCCURRED, the provider does not allocate any memory and ensures that *prgRowStatus is a null pointer on output.
		/// </para>
		/// </param>
		/// <returns>
		/// <list type="bullet">
		/// <item>
		/// <description>
		/// <para>S_OK The method succeeded. The changes in all rows were successfully updated. The following values can be returned in *prgRowStatus:</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// DB_S_ERRORSOCCURRED An error occurred while updating a row, but at least one row was successfully updated. Successes can occur
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
		/// <para>E_INVALIDARG cRows was not zero, and rghRows was a null pointer.</para>
		/// <para>pcRows was not a null pointer, and prgRows was a null pointer on input.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// E_OUTOFMEMORY The provider was unable to allocate sufficient memory in which to return either the handles of the rows
		/// <c>IRowsetUpdate::Update</c> attempted to update or the array of row status values.
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
		/// <para>DB_E_BADCHAPTER The rowset was chaptered, and hReserved was invalid.</para>
		/// <para>
		/// The rowset was single-chaptered, and the specified chapter was not the currently open chapter. The consumer must use the
		/// currently open chapter or release the currently open chapter before specifying a new chapter.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// DB_E_ERRORSOCCURRED Errors occurred while updating all of the rows. The provider allocates memory for *prgRows and *prgRowStatus,
		/// and the consumer checks the values in *prgRowStatus to determine why the pending changes were not updated. The consumer frees
		/// this memory when it no longer needs the information. Errors can occur for the reasons listed under DB_S_ERRORSOCCURRED.
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
		// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/ms719709(v=vs.85) HRESULT Update ( HCHAPTER hReserved,
		// DBCOUNTITEM cRows, const HROW rghRows[], DBCOUNTITEM *pcRows, HROW **prgRows, DBROWSTATUS **prgRowStatus);
		[PreserveSig]
		HRESULT Update([In] HCHAPTER hReserved, DBCOUNTITEM cRows, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] HROW[] rghRows,
			out DBCOUNTITEM pcRows, out SafeIMallocHandle prgRows, out SafeIMallocHandle prgRowStatus);
	}

	/// <summary><c>IRowsetView</c> enables the consumer to create or apply a view to an existing rowset.</summary>
	// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/ms709755(v=vs.85)
	[PInvokeData("oledb.h")]
	[ComImport, Guid("0c733a99-2a1c-11ce-ade5-00aa0044773d"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IRowsetView
	{
		/// <summary>Creates a view.</summary>
		/// <param name="pUnkOuter">
		/// [in] A pointer to the controlling <c>IUnknown</c> interface if the view is being created as part of an aggregate. It is a null
		/// pointer if the view is not part of an aggregate.
		/// </param>
		/// <param name="riid">[in] The IID of the interface requested on the view.</param>
		/// <param name="ppView">[out] A pointer to memory in which to return the interface pointer on the newly created view.</param>
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
		/// <para>E_INVALIDARG ppView was a null pointer.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>E_NOINTERFACE The view did not support the interface specified in riid.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>E_OUTOFMEMORY The provider did not have enough memory to create the view.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// DB_E_NOAGGREGATION pUnkOuter was not a null pointer, and the provider is an OLE DB 1.0 or 1.1 provider that does not support
		/// aggregation of the view object being created.
		/// </para>
		/// <para>pUnkOuter was not a null pointer, and riid was not IID_IUnknown.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>E_UNEXPECTED <c>ITransaction::Commit</c> or <c>ITransaction::Abort</c> was called, and the object is in a zombie state.</para>
		/// </description>
		/// </item>
		/// </list>
		/// </returns>
		// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/ms723074(v=vs.85) HRESULT CreateView ( IUnknown *pUnkOuter,
		// REFIID riid, IUnknown **ppView);
		[PreserveSig]
		HRESULT CreateView([In, Optional, MarshalAs(UnmanagedType.IUnknown)] object? pUnkOuter, in Guid riid, [MarshalAs(UnmanagedType.IUnknown)] out object? ppView);

		/// <summary>Returns a new view describing conditions applied to the specified chapter.</summary>
		/// <param name="hChapter">[in] The chapter from which to return the view conditions.</param>
		/// <param name="riid">[in] The IID of the interface on which to return a pointer.</param>
		/// <param name="phChapterSource">[out] The chapter handle to which the view was applied to create the new chapter.</param>
		/// <param name="ppView">
		/// [out] A pointer to memory in which to return the interface pointer. If <c>IRowsetView::GetView</c> fails, it must attempt to set
		/// *ppView to a null pointer.
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
		/// <para>E_NOINTERFACE The view did not support the interface specified in riid.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>E_OUTOFMEMORY The provider was unable to allocate sufficient memory in which to return the view information.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_E_BADCHAPTER hChapter was invalid.</para>
		/// </description>
		/// </item>
		/// </list>
		/// </returns>
		// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/ms711261(v=vs.85) HRESULT GetView ( HCHAPTER hChapter, REFIID
		// riid, HCHAPTER *phChapterSource, IUnknown **ppView);
		[PreserveSig]
		HRESULT GetView([In] HCHAPTER hChapter, in Guid riid, out HCHAPTER phChapterSource, [MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 1)] out object? ppView);
	}

	/// <summary>
	/// <para>
	/// The <c>IScopedOperations</c> interface supports recursive operations on a tree-structured namespace, such as a file system, that is
	/// bound to an OLE DB row object. The scope of the row object is defined by the tree or subtree whose root node is bound to the row
	/// object. Each node in the tree can be bound to its own row object. One of the columns in each row object can be a rowset containing a
	/// row for each child of the node that is bound to the row object. The entire tree can thus be bound by a structure of row and rowset objects.
	/// </para>
	/// <para>
	/// In tree-structured namespaces such as a file system or an e-mail system, each row object can be associated with a default stream
	/// column that stores the contents of a file or an e-mail message. On the row object, the default stream column is identified by a
	/// special constant column ID (DBID). The consumer passes this column ID as an argument to <c>IRow::Open</c> to get the default stream.
	/// After the application has obtained the default stream from a row, it can return to the containing row by calling <c>IGetSourceRow::GetSourceRow</c>.
	/// </para>
	/// </summary>
	// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/ms715006(v=vs.85)
	[PInvokeData("oledb.h")]
	[ComImport, Guid("0c733ab0-2a1c-11ce-ade5-00aa0044773d"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IScopedOperations : IBindResource
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
		new HRESULT Bind([In, Optional, MarshalAs(UnmanagedType.IUnknown)] object? pUnkOuter, [In, MarshalAs(UnmanagedType.LPWStr)] string pwszURL, DBBINDURLFLAG dwBindURLFlags,
			in Guid rguid, in Guid riid, [In, Optional, MarshalAs(UnmanagedType.IUnknown)] object? pAuthenticate, [In, Out, Optional] IntPtr pImplSession,
			out DBBINDURLSTATUS pdwBindStatus, [MarshalAs(UnmanagedType.IUnknown)] out object? ppUnk);

		/// <summary>
		/// Copies trees or subtrees, designated by an array of source URLs, to the locations designated by a corresponding array of
		/// destination URLs.
		/// </summary>
		/// <param name="cRows">
		/// [in] Count of trees and subtrees named by the rgpwszSourceURLs and rgpwszDestURLs arrays. If cRows is zero, all other arguments
		/// are ignored and the method returns S_OK.
		/// </param>
		/// <param name="rgpwszSourceURLs">
		/// [in] Array of canonical URLs naming the source trees or subtrees to be copied. If cRows is greater than zero and an element of
		/// rgpwszSourceURLs is an empty string (L""), the current row object is copied.
		/// </param>
		/// <param name="rgpwszDestURLs">
		/// [in] Array of canonical URLs naming the destination trees or subtrees. The elements of rgpwszDestURLs correspond to the elements
		/// of rgpwszSourceURLs. If DBPROP_GENERATEURL is DBPROPVAL_GU_SUFFIX, this array contains URL paths and the provider generates the
		/// URL suffixes.
		/// </param>
		/// <param name="dwCopyFlags">
		/// <para>[in] Flags describing additional semantics for the copy operation as described in the following table.</para>
		/// <para>
		/// <para>Note</para>
		/// <para>Some of these flags are similar to the flags used in the Microsoft? Windows? <c>CopyFileEx</c> file I/O function.</para>
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <description>Flag value</description>
		/// <description>Description</description>
		/// </listheader>
		/// <item>
		/// <description>DBCOPY_ALLOW_EMULATION</description>
		/// <description>
		/// If this flag is set and the attempt to copy the tree or subtree fails because the destination URL is on a different server or
		/// serviced by a different provider than the source, the provider is requested to attempt to simulate the copy using download and
		/// upload operations. When moving entities between providers, this may cause increased latency or data loss due to different
		/// provider capabilities.
		/// </description>
		/// </item>
		/// <item>
		/// <description>DBCOPY_ASYNC</description>
		/// <description>
		/// The copy operation is performed asynchronously. Progress and notifications are available by using <c>IDBAsynchStatus</c> and
		/// <c>IDBAsynchNotify</c> callbacks. Implementations that do not support asynchronous behavior should block and return a warning.
		/// </description>
		/// </item>
		/// <item>
		/// <description>DBCOPY_ATOMIC</description>
		/// <description>
		/// Either all trees or subtrees are copied successfully or none are copied. Whether all parts of an atomic operation are attempted
		/// if one part fails is provider-specific.
		/// </description>
		/// </item>
		/// <item>
		/// <description>DBCOPY_NON_RECURSIVE</description>
		/// <description>If this flag is set, only the root node of the tree is copied; no child nodes are copied.</description>
		/// </item>
		/// <item>
		/// <description>DBCOPY_REPLACE_EXISTING</description>
		/// <description>
		/// The copy operation succeeds even if a target object already exists at the destination URL. Otherwise, the copy fails if a target
		/// object already exists.
		/// </description>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="pAuthenticate">
		/// [in] Optional pointer to the caller's <c>IAuthenticate</c> interface. If supplied, it is provider-specific whether the
		/// <c>IAuthenticate</c> credentials are used before or after anonymous or default login credentials are used.
		/// </param>
		/// <param name="rgdwStatus">
		/// <para>
		/// [out] Array of DBSTATUS status fields indicating whether each element of rgpwszSourceURLs was copied to rgpwszDestURLs. Whether
		/// the status fields are set for return codes other than DB_S_ERRORSOCCURRED or DB_E_ERRORSOCCURRED is provider-specific. The status
		/// fields described in the following table apply.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <description>Status field</description>
		/// <description>Description</description>
		/// </listheader>
		/// <item>
		/// <description>DBSTATUS_S_OK</description>
		/// <description>Indicates that the tree or subtree was successfully copied.</description>
		/// </item>
		/// <item>
		/// <description>DBSTATUS_E_CANCELED</description>
		/// <description>The operation was canceled, and the provider did not complete the copy operation for this resource.</description>
		/// </item>
		/// <item>
		/// <description>DBSTATUS_E_CANNOTCOMPLETE</description>
		/// <description>
		/// The server that owns the source URL cannot complete the operation. The provider may return this error for one of the following reasons:
		/// </description>
		/// </item>
		/// <item>
		/// <description>DBSTATUS_E_DOESNOTEXIST</description>
		/// <description>Indicates that either the source URL or the parent of the destination URL does not exist.</description>
		/// </item>
		/// <item>
		/// <description>DBSTATUS_E_INVALIDURL</description>
		/// <description>A source or destination URL string contains invalid characters.</description>
		/// </item>
		/// <item>
		/// <description>DBSTATUS_E_NOTCOLLECTION</description>
		/// <description>
		/// The destination URL contained in <c>rgpwszDestURLs</c> did not specify a path or collection as required by the operation.
		/// </description>
		/// </item>
		/// <item>
		/// <description>DBSTATUS_E_OUTOFSPACE</description>
		/// <description>The provider is unable to obtain enough storage space to complete the copy operation.</description>
		/// </item>
		/// <item>
		/// <description>DBSTATUS_E_PERMISSIONDENIED</description>
		/// <description>Unable to access a tree or subtree because of a permissions failure.</description>
		/// </item>
		/// <item>
		/// <description>DBSTATUS_E_RESOURCEEXISTS</description>
		/// <description>
		/// The provider was unable to perform the copy because an object already exists at the destination URL and the
		/// DBCOPY_REPLACE_EXISTING flag was not set.
		/// </description>
		/// </item>
		/// <item>
		/// <description>DBSTATUS_E_RESOURCELOCKED</description>
		/// <description>
		/// One or more other processes using the DBBINDURLFLAG_SHARE_* flag have locked the object named by this URL. If supported,
		/// <c>IErrorInfo::GetDescription</c> returns a string consisting of user names separated by semicolons. These are the names of the
		/// users who have the object locked.
		/// </description>
		/// </item>
		/// <item>
		/// <description>DBSTATUS_E_RESOURCEOUTOFSCOPE</description>
		/// <description>A source or destination URL is outside the scope of the current row object.</description>
		/// </item>
		/// <item>
		/// <description>DBSTATUS_E_UNAVAILABLE</description>
		/// <description>An atomic operation failed to complete, and status was unavailable for this part of the operation.</description>
		/// </item>
		/// <item>
		/// <description>DBSTATUS_E_VOLUMENOTFOUND</description>
		/// <description>The provider is unable to locate the storage volume indicated by a URL.</description>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="rgpwszNewURLs">
		/// [in/out] Optional consumer-allocated array of cRows pointers to the provider-assigned and allocated canonical destination URLs.
		/// The caller may pass a null value to indicate it does not want the provider to return destination URLs. This parameter should be
		/// set to NULL if an error code is returned.
		/// </param>
		/// <param name="ppStringsBuffer">
		/// [out] A pointer to memory in which to return a pointer to storage for all generated URL strings within a single allocation block.
		/// When it is finished working with the URLs, the consumer should free this buffer. Each of the individual string values stored in
		/// this buffer is terminated by a null character. If cRows is zero or this method terminates due to an error, the provider sets
		/// ppStringsBuffer to a null pointer. If rgpwszNewURLs is a null pointer, the consumer must set ppStringsBuffer to NULL as well.
		/// </param>
		/// <returns>
		/// <list type="bullet">
		/// <item>
		/// <description>
		/// <para>S_OK All requested copy operations succeeded. All elements of rgdwStatus passed to the method are set to DBPROPSTATUS_OK.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// DB_S_ASYNCHRONOUS The method has initiated an asynchronous copy operation. The consumer can call
		/// <c>IDBAsynchStatus::GetStatus</c> to poll for status or can register for notifications of asynchronous processing.
		/// </para>
		/// <para>DB_S_ASYNCHRONOUS should be returned before DB_S_ERRORSOCCURRED.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_S_BUFFERFULL All copy operations succeeded, but the provider was unable to allocate ppStringsBuffer.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// DB_S_ERRORSOCCURRED DBCOPY_ATOMIC was not set, and the provider failed to copy from one or more source URL. The caller should
		/// examine rgdwStatus to determine which source URLs were not copied and why.
		/// </para>
		/// <para>
		/// DB_S_ASYNCHRONOUS should be returned before DB_S_ERRORSOCCURRED. Once rowset population is complete, the consumer can see
		/// DB_S_ERRORSOCCURRED either by calling <c>IDBAsynchStatus::GetStatus</c> or by receiving <c>IDBAsynchNotify::OnStop</c>.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_E_ASYNCNOTSUPPORTED The provider does not support asynchronous copy operations.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// DB_E_CANCELED The operation was called synchronously and, before it completed, was canceled by a call to
		/// <c>IDBAsynchStatus::Abort</c>. The consumer can examine rgdwStatus for a status of DBSTATUS_E_CANCELED to determine whether an
		/// individual URL was copied.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// DB_E_ERRORSOCCURRED DBCOPY_ATOMIC was set, and the provider failed to copy one or more source URLs. The caller should examine
		/// rgdwStatus to determine which URLs were not copied and why.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_E_NOTSUPPORTED The provider does not support the value of dwCopyFlags.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_SEC_E_SAFEMODE_DENIED The provider was called within a safe mode or context, and one of the URLs specified was unsafe.</para>
		/// </description>
		/// </item>
		/// </list>
		/// <para>
		/// <para>Note</para>
		/// <para>
		/// When failing one of multiple operations, the status of the failing operation is DBSTATUS_E_CANNOTCOMPLETE and the status of any
		/// remaining uncompleted operations is DBSTATUS_E_UNAVAILABLE.
		/// </para>
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <description>
		/// <para>E_FAIL A provider-specific error occurred.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>E_INVALIDARG cRows is not zero; and rgpwszSourceURLs,rgpwszDestURLs, or rgdwStatus is a null pointer.</para>
		/// <para>cRows is not zero, andone of rgpwszNewURLs and ppStringsBuffer, but not both,are null pointers.</para>
		/// <para>cRows is not zero, and an element of rgpwszSourceURLs or rgpwszDestURLs is a null pointer.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>E_OUTOFMEMORY The provider did not have enough memory to complete the operation.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// E_UNEXPECTED <c>ITransaction::Commit</c>, <c>ITransaction::Abort</c>, or <c>IScopedOperations::Delete</c> (on this row) was
		/// called, and the object is in a zombie state.
		/// </para>
		/// </description>
		/// </item>
		/// </list>
		/// </returns>
		// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/ms711633(v=vs.85) HRESULT Copy ( DBCOUNTITEM cRows, LPCOLESTR
		// rgpwszSourceURLs[ ], LPCOLESTR rgpwszDestURLs[ ], DBCOPYFLAGS dwCopyFlags, IAuthenticate *pAuthenticate, DBSTATUS rgdwStatus[ ],
		// LPOLESTR rgpwszNewURLs[ ], OLECHAR **ppStringsBuffer );
		[PreserveSig]
		HRESULT Copy(DBCOUNTITEM cRows, [In, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPWStr, SizeParamIndex = 0)] string[] rgpwszSourceURLs,
			[In, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPWStr, SizeParamIndex = 0)] string[] rgpwszDestURLs, DBCOPYFLAGS dwCopyFlags,
			[In, Optional, MarshalAs(UnmanagedType.IUnknown)] object? pAuthenticate, [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] DBSTATUS[] rgdwStatus,
			[Out, Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] LPWSTR[]? rgpwszNewURLs, out SafeIMallocHandle ppStringsBuffer);

		/// <summary>
		/// Moves trees or subtrees that are represented by OLE DB row objects. The trees or subtrees are designated by an array of source
		/// URLs and are moved to the locations designated by a corresponding array of destination URLs.
		/// </summary>
		/// <param name="cRows">
		/// [in] Count of rows named by the rgpwszSourceURLs and rgpwszDestURLs arrays. If cRows is zero, all other arguments are ignored and
		/// the method returns S_OK.
		/// </param>
		/// <param name="rgpwszSourceURLs">
		/// [in] Array of canonical URLs naming the trees or subtrees to be moved from the source location. If cRows is greater than zero and
		/// an element of rgpwszSourceURLs is an empty string (L""), the current row object is moved.
		/// </param>
		/// <param name="rgpwszDestURLs">
		/// [in] Array of canonical URLs naming the destination to which the trees or subtrees are to be moved. The elements of
		/// rgpwszDestURLs correspond to the elements of rgpwszSourceURLs. If DBPROP_GENERATEURL is DBPROPVAL_GU_SUFFIX, this array contains
		/// URL paths and the provider generates the URL suffixes. If DBPROP_GENERATEURL is DBPROPVAL_GU_NOTSUPPORTED and the caller passes a
		/// null value, the provider does not return the absolute URLs of the moved URLs.
		/// </param>
		/// <param name="dwMoveFlags">
		/// <para>[in] Flags describing additional semantics for the move operation as described in the following table.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Flag value</description>
		/// <description>Description</description>
		/// </listheader>
		/// <item>
		/// <description>DBMOVE_ALLOW_EMULATION</description>
		/// <description>
		/// If the attempt to move the row fails because the destination URL is on a different server or serviced by a different provider
		/// than the source, the provider is requested to attempt to simulate the move using download, upload, and delete operations. When
		/// moving resources between providers, this may cause increased latency or data loss due to different provider capabilities.
		/// </description>
		/// </item>
		/// <item>
		/// <description>DBMOVE_ASYNC</description>
		/// <description>
		/// The move operation is performed asynchronously. Progress and notifications are available via <c>IDBAsynchStatus</c> and
		/// <c>IDBAsynchNotify</c> callbacks. Implementations that do not support asynchronous behavior should block and return a warning.
		/// </description>
		/// </item>
		/// <item>
		/// <description>DBMOVE_ATOMIC</description>
		/// <description>
		/// Either all sources are moved successfully or no sources are moved. Whether all parts of an atomic operation are attempted if one
		/// part fails is provider-specific.
		/// </description>
		/// </item>
		/// <item>
		/// <description>DBMOVE_DONT_UPDATE_LINKS</description>
		/// <description>
		/// Request the server not to update links contained in an object on a move. If this flag is not specified, the default behavior is
		/// to do what the server specifies. By default, <c>IScopedOperations::Move</c> will update links if the server is capable and if the
		/// option is turned on. If the server does not have the ability to fix up links or if the option is turned off, this call will still
		/// return S_OK.
		/// </description>
		/// </item>
		/// <item>
		/// <description>DBMOVE_REPLACE_EXISTING</description>
		/// <description>
		/// The move operation succeeds, even if a target object exists. Without this value, the move will fail if the target object already exists.
		/// </description>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="pAuthenticate">
		/// [in] Optional pointer to the <c>IAuthenticate</c> interface. If supplied, it is provider-specific whether the
		/// <c>IAuthenticate</c> credentials are used before or after anonymous or default login credentials are used.
		/// </param>
		/// <param name="rgdwStatus">
		/// <para>
		/// [out] Array of DBSTATUS status fields indicating whether each element of rgpwszSourceURLs was moved to rgpwszDestURLs. Whether
		/// the status fields are set for return codes other than DB_S_ERRORSOCCURRED or DB_E_ERRORSOCCURRED is provider-specific. The status
		/// fields described in the following table apply to the move operations.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <description>Status field</description>
		/// <description>Description</description>
		/// </listheader>
		/// <item>
		/// <description>DBSTATUS_S_OK</description>
		/// <description>Indicates that a tree or subtree was successfully moved.</description>
		/// </item>
		/// <item>
		/// <description>DBSTATUS_E_CANCELED</description>
		/// <description>The operation was canceled, and the provider did not complete the move operation for this resource.</description>
		/// </item>
		/// <item>
		/// <description>DBSTATUS_S_CANNOTDELETESOURCE</description>
		/// <description>A tree or subtree was moved to a new location, but the source tree or subtree could not be deleted.</description>
		/// </item>
		/// <item>
		/// <description>DBSTATUS_E_CANNOTCOMPLETE</description>
		/// <description>
		/// The server that owns the source URL cannot complete the operation. The provider may return this error for one of the following reasons:
		/// </description>
		/// </item>
		/// <item>
		/// <description>DBSTATUS_E_DOESNOTEXIST</description>
		/// <description>Indicates that either the source URL or the parent of the destination URL does not exist.</description>
		/// </item>
		/// <item>
		/// <description>DBSTATUS_E_INVALIDURL</description>
		/// <description>A source or destination URL string contains invalid characters.</description>
		/// </item>
		/// <item>
		/// <description>DBSTATUS_E_NOTCOLLECTION</description>
		/// <description>
		/// The destination URL contained in <c>rgpwszDestURLs</c> did not specify a path or collection as required by the operation.
		/// </description>
		/// </item>
		/// <item>
		/// <description>DBSTATUS_E_OUTOFSPACE</description>
		/// <description>The provider is unable to obtain enough storage space to complete the move operation.</description>
		/// </item>
		/// <item>
		/// <description>DBSTATUS_E_PERMISSIONDENIED</description>
		/// <description>Unable to access a tree or subtree because of a permissions failure.</description>
		/// </item>
		/// <item>
		/// <description>DBSTATUS_E_RESOURCEEXISTS</description>
		/// <description>
		/// The provider was unable to perform the move because an object already exists at the destination URL and the
		/// DBMOVE_REPLACE_EXISTING flag was not set.
		/// </description>
		/// </item>
		/// <item>
		/// <description>DBSTATUS_E_RESOURCELOCKED</description>
		/// <description>
		/// One or more other processes using the DBBINDURLFLAG_SHARE_* flag have locked the object named by this URL. If supported,
		/// <c>IErrorInfo::GetDescription</c> returns a string consisting of user names separated by semicolons. These are the names of the
		/// users who have the object locked.
		/// </description>
		/// </item>
		/// <item>
		/// <description>DBSTATUS_E_RESOURCEOUTOFSCOPE</description>
		/// <description>A source or destination URL is outside the scope of the current row object.</description>
		/// </item>
		/// <item>
		/// <description>DBSTATUS_E_UNAVAILABLE</description>
		/// <description>An atomic operation failed to complete, and status was unavailable for this part of the operation.</description>
		/// </item>
		/// <item>
		/// <description>DBSTATUS_E_VOLUMENOTFOUND</description>
		/// <description>The provider is unable to locate the storage volume indicated by a URL.</description>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="rgpwszNewURLs">
		/// [in/out] Optional consumer-allocated array of cRows pointers to the provider-assigned and allocated canonical destination URLs.
		/// The caller may pass a null value to indicate it does not want the provider to return destination URLs. This parameter should be
		/// set to NULL if an error code is returned.
		/// </param>
		/// <param name="ppStringsBuffer">
		/// [out] A pointer to memory in which to return a pointer to storage for all generated URL strings within a single allocation block.
		/// When it is finished working with the URLs, the consumer should free this buffer. Each of the individual string values stored in
		/// this buffer is terminated by a null character. If cRows is zero or this method terminates due to an error, the provider sets
		/// ppStringsBuffer to a null pointer. If rgpwszNewURLs is a null pointer, the consumer must set ppStringsBuffer to NULL as well.
		/// </param>
		/// <returns>
		/// <list type="bullet">
		/// <item>
		/// <description>
		/// <para>S_OK All requested move operations succeeded. All elements of rgdwStatus passed to the method are set to DBPROPSTATUS_OK.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// DB_S_ASYNCHRONOUS The method has initiated an asynchronous move operation. The consumer can call
		/// <c>IDBAsynchStatus::GetStatus</c> to poll for status or can register for notifications of asynchronous processing.
		/// </para>
		/// <para>DB_S_ASYNCHRONOUS should be returned before DB_S_ERRORSOCCURRED.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_S_BUFFERFULL All move operations succeeded, but the provider was unable to allocate ppStringsBuffer.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// DB_S_ERRORSOCCURRED DBMOVE_ATOMIC was not set, and the provider failed to move one or more source URLs. The caller should examine
		/// rgdwStatus to determine which source URLs were not copied from and why.
		/// </para>
		/// <para>
		/// DB_S_ASYNCHRONOUS should be returned before DB_S_ERRORSOCCURRED. Once rowset population is complete, the consumer can see
		/// DB_S_ERRORSOCCURRED either by calling <c>IDBAsynchStatus::GetStatus</c> or by receiving <c>IDBAsynchNotify::OnStop</c>.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_E_ASYNCNOTSUPPORTED The provider does not support asynchronous moves.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// DB_E_CANCELED The operation was called synchronously and, before it completed, was canceled by a call to
		/// <c>IDBAsynchStatus::Abort</c>. The consumer can examine rgdwStatus for a status of DBSTATUS_E_CANCELED to determine whether an
		/// individual URL was moved.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// DB_E_ERRORSOCCURRED DBMOVE_ATOMIC was set, and the provider failed to move one or more source URLs. The caller should examine
		/// rgdwStatus to determine which URLs were not moved and why.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_E_NOTSUPPORTED The provider does not support the value of dwMoveFlags.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_SEC_E_SAFEMODE_DENIED The provider was called within a safe mode or context, and one of the URLs specified was unsafe.</para>
		/// </description>
		/// </item>
		/// </list>
		/// <para>
		/// <para>Note</para>
		/// <para>
		/// When failing one of multiple operations, the status of the failing operation is DBSTATUS_E_CANNOTCOMPLETE and the status of any
		/// remaining, uncompleted operations is DBSTATUS_E_UNAVAILABLE.
		/// </para>
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <description>
		/// <para>E_FAIL A provider-specific error occurred.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>E_INVALIDARG cRows is not zero; and rgpwszSourceURLs,rgpwszDestURLs, or rgdwStatus is a null pointer.</para>
		/// <para>cRows is not zero, and one of rgpwszNewURLs and ppStringsBuffer, but not both, are null pointers.</para>
		/// <para>cRows is not zero, and an element of rgpwszSourceURLs or rgpwszDestURLs is a null pointer.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>E_OUTOFMEMORY The provider did not have enough memory to complete the operation.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// E_UNEXPECTED <c>ITransaction::Commit</c>, <c>ITransaction::Abort</c>, or <c>IScopedOperations::Delete</c> (on this row) was
		/// called, and the object is in a zombie state..
		/// </para>
		/// </description>
		/// </item>
		/// </list>
		/// </returns>
		// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/ms720893(v=vs.85) HRESULT Move ( DBCOUNTITEM cRows, LPCOLESTR
		// rgpwszSourceURLs[ ], LPCOLESTR rgpwszDestURLs[ ], DBMOVEFLAGS dwMoveFlags, IAuthenticate *pAuthenticate, DBSTATUS rgdwStatus[ ],
		// LPOLESTR rgpwszNewURLs[ ], OLECHAR **ppStringsBuffer );
		[PreserveSig]
		HRESULT Move(DBCOUNTITEM cRows, [In, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPWStr, SizeParamIndex = 0)] string[] rgpwszSourceURLs,
			[In, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPWStr, SizeParamIndex = 0)] string[] rgpwszDestURLs, DBMOVEFLAGS dwMoveFlags,
			[In, Optional, MarshalAs(UnmanagedType.IUnknown)] object? pAuthenticate, [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] DBSTATUS[] rgdwStatus,
			[Out, Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] LPWSTR[]? rgpwszNewURLs, out SafeIMallocHandle ppStringsBuffer);

		/// <summary>
		/// Deletes the trees or subtrees named by an array of URLs. The URLs must all be within the scope of the current row object.
		/// </summary>
		/// <param name="cRows">
		/// [in] Count of trees and subtrees named by the rgpwszURLs array. If cRows is zero, all other arguments are ignored and the method
		/// returns S_OK.
		/// </param>
		/// <param name="rgpwszURLs">
		/// [in] Array of canonical URLs naming the trees or subtrees to be deleted. If cRows is greater than zero and an element of
		/// rgpwszURLs is an empty string (L""), the current row object is deleted.
		/// </param>
		/// <param name="dwDeleteFlags">
		/// <para>[in] A bitmask of flags that control additional semantics for the delete operation, as described in the following table.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Flag value</description>
		/// <description>Description</description>
		/// </listheader>
		/// <item>
		/// <description>DBDELETE_ASYNC</description>
		/// <description>
		/// The delete operation is performed asynchronously. Progress and notifications are available via <c>IDBAsynchStatus</c> and
		/// <c>IDBAsynchNotify</c> callbacks. Implementations that do not support asynchronous behavior should block and return a warning. If
		/// DBDELETE_ASYNC is not specified, the operation is synchronous. A value of 0 is allowed.
		/// </description>
		/// </item>
		/// <item>
		/// <description>DBDELETE_ATOMIC</description>
		/// <description>
		/// Either all trees and subtrees are deleted or none are deleted. Whether all parts of an atomic operation are attempted if one part
		/// fails is provider-specific. If DBDELETE_ATOMIC is not specified, the operation is non-atomic. A value of 0 is allowed.
		/// </description>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="rgdwStatus">
		/// <para>
		/// [out] Array of DBSTATUS status fields indicating, for each element of rgpwszURLs, whether the tree or subtree named by that
		/// element was deleted. Whether the status fields are set for return codes other than DB_S_ERRORSOCCURRED or DB_E_ERRORSOCCURRED is
		/// provider-specific. The status fields described in the following table apply.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <description>Status field</description>
		/// <description>Description</description>
		/// </listheader>
		/// <item>
		/// <description>DBSTATUS_S_OK</description>
		/// <description>Indicates that the tree or subtree was deleted.</description>
		/// </item>
		/// <item>
		/// <description>DBSTATUS_E_CANCELED</description>
		/// <description>The operation was canceled, and the provider did not complete the delete operation for this resource.</description>
		/// </item>
		/// <item>
		/// <description>DBSTATUS_E_DOESNOTEXIST</description>
		/// <description>Indicates that the tree or subtree named by this URL did not exist.</description>
		/// </item>
		/// <item>
		/// <description>DBSTATUS_E_INVALIDURL</description>
		/// <description>A URL string contained invalid characters.</description>
		/// </item>
		/// <item>
		/// <description>DBSTATUS_E_PERMISSIONDENIED</description>
		/// <description>Unable to access a tree or subtree due to a permissions failure.</description>
		/// </item>
		/// <item>
		/// <description>DBSTATUS_E_RESOURCELOCKED</description>
		/// <description>
		/// One or more other processes using the DBBINDURLFLAG_SHARE_* flag have locked the object named by this URL. If supported,
		/// <c>IErrorInfo::GetDescription</c> returns a string consisting of user names separated by semicolons. These are the names of the
		/// users who have the object locked.
		/// </description>
		/// </item>
		/// <item>
		/// <description>DBSTATUS_E_RESOURCEOUTOFSCOPE</description>
		/// <description>A URL to be deleted is outside the scope of the current row object.</description>
		/// </item>
		/// <item>
		/// <description>DBSTATUS_E_UNAVAILABLE</description>
		/// <description>An atomic operation failed to complete, and status was unavailable for this part of the operation.</description>
		/// </item>
		/// <item>
		/// <description>DBSTATUS_E_VOLUMENOTFOUND</description>
		/// <description>The provider is unable to locate the storage volume named by a URL.</description>
		/// </item>
		/// </list>
		/// </param>
		/// <returns>
		/// <list type="bullet">
		/// <item>
		/// <description>
		/// <para>S_OK All requested deletions succeeded. All elements of rgdwStatus passed to the method are set to DBPROPSTATUS_OK.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// DB_S_ASYNCHRONOUS The method has initiated an asynchronous delete operation. The consumer can call
		/// <c>IDBAsynchStatus::GetStatus</c> to poll for status or can register for notifications of asynchronous processing.
		/// </para>
		/// <para>DB_S_ASYNCHRONOUS should be returned before DB_S_ERRORSOCCURRED.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// DB_S_ERRORSOCCURRED DBDELETE_ATOMIC was not set, and the provider failed to delete one or more URLs. The caller should examine
		/// rgdwStatus to determine which URLs were not deleted and why.
		/// </para>
		/// <para>
		/// DB_S_ASYNCHRONOUS should be returned before DB_S_ERRORSOCCURRED. Once rowset population is complete, the consumer can see
		/// DB_S_ERRORSOCCURRED either by calling <c>IDBAsynchStatus::GetStatus</c> or by receiving <c>IDBAsynchNotify::OnStop</c>.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_E_ASYNCNOTSUPPORTED The provider does not support asynchronous deletions.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// DB_E_CANCELED The operation was called synchronously and, before it completed, was canceled by a call to
		/// <c>IDBAsynchStatus::Abort</c>. The consumer can examine rgdwStatus for a status of DBSTATUS_E_CANCELED to determine whether an
		/// individual URL was deleted.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// DB_E_ERRORSOCCURRED DBDELETE_ATOMIC was set, and the provider failed to delete one or more URLs. The caller should examine
		/// rgdwStatus to determine which URLs were not deleted and why.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_E_NOTSUPPORTED The provider does not support the value of dwDeleteFlags.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_SEC_E_SAFEMODE_DENIED The provider was called within a safe mode or context, and one of the URLs specified was unsafe.</para>
		/// </description>
		/// </item>
		/// </list>
		/// <para>
		/// <para>Note</para>
		/// <para>
		/// When failing one of multiple operations, the status of the failing operation is DBSTATUS_E_CANNOTCOMPLETE and the status of any
		/// remaining, uncompleted operations is DBSTATUS_E_UNAVAILABLE.
		/// </para>
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <description>
		/// <para>E_FAIL A provider-specific error occurred.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>E_INVALIDARG cRows is not zero, and rgpwszURLs or rgdwStatus is a null pointer.</para>
		/// <para>cRows is not zero, and an element of rgpwszURLs is a null pointer.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>E_OUTOFMEMORY The provider did not have enough memory to complete the operation.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>E_UNEXPECTED <c>ITransaction::Commit</c> or <c>ITransaction::Abort</c> was called, and the object is in a zombie state.</para>
		/// </description>
		/// </item>
		/// </list>
		/// </returns>
		// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/ms724355(v=vs.85) HRESULT Delete ( DBCOUNTITEM cRows,
		// LPCOLESTR rgpwszURLs[ ], DBDELETEFLAGS dwDeleteFlags, DBSTATUS rgdwStatus[ ] );
		[PreserveSig]
		HRESULT Delete(DBCOUNTITEM cRows, [In, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPWStr, SizeParamIndex = 0)] string[] rgpwszURLs,
			DBDELETEFLAGS dwDeleteFlags, [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] DBSTATUS[] rgdwStatus);

		/// <summary>
		/// Opens and returns a rowset containing the child rows of the current row or of a URL-named row within the scope of the current
		/// row. Due to interface and method factoring, <c>IScopedOperations::OpenRowset</c> is not inherited from <c>IOpenRowset</c>.
		/// However, it is the very same method, adapted for direct binding within the scope of the current row.
		/// </summary>
		/// <param name="pUnkOuter">
		/// [in] If the rowset is to be aggregated, pUnkOuter is an interface pointer to the controlling <c>IUnknown</c>. Otherwise, it is a
		/// null pointer.
		/// </param>
		/// <param name="pTableID">
		/// <para>
		/// [in] The table ID (DBID) of the table to open. When implemented on row objects, this is an absolute or relative URL within the
		/// scope of the current row. If one of the following is true, pTableID designates the current row and the rowset will contain the
		/// child rows of this row:
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <description>
		/// <para>pTableID is NULL.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>pTableID is not NULL, pTableID-&gt;eKind is DBKIND_NAME, and pTableID-&gt;uName.pwszName is NULL.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>pTableID is not null, pTableID-&gt;eKind is DBKIND_NAME, and pTableID-&gt;uName.pwszName is L"".</para>
		/// </description>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="pIndexID">
		/// [in] The DBID of the index to open. Not currently used in <c>IScopedOperations</c>. Consumers must set pIndexID to NULL. For more
		/// information, see the "Comments" section.
		/// </param>
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
		/// [in/out] An array of DBPROPSET structures containing properties and values to be set. The properties in these structures must
		/// belong to the rowset property group. If the same property is specified more than once in rgPropertySets, the value used is
		/// provider-specific. If cPropertySets is zero, this argument is ignored.
		/// </para>
		/// <para>
		/// For information about the rowset properties, see the rowset property group in Appendix C: OLE DB Properties. For information
		/// about the DBPROPSET and DBPROP structures, see DBPROPSET Structure and DBPROP Structure.
		/// </para>
		/// </param>
		/// <param name="ppRowset">
		/// [in/out] A pointer to memory in which to return the interface pointer to the created rowset. If ppRowset is a null pointer, no
		/// rowset is created; properties are verified, and if a required property cannot be set, DB_E_ERRORSOCCURRED is returned. If
		/// <c>IScopedOperations::OpenRowset</c> fails, *ppRowset is set to a null pointer.
		/// </param>
		/// <returns>
		/// <list type="bullet">
		/// <item>
		/// <description>
		/// <para>S_OK The method succeeded, and the rowset was opened.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// DB_S_ASYNCHRONOUS The method has initiated asynchronous creation of the rowset. The consumer can call <c>IDBAsynchStatus</c> to
		/// poll for status or can call <c>IConnectionPointContainer</c> to obtain the <c>IID_IDBAsynchNotify</c> connection point.
		/// Attempting to call any other interfaces might fail, and the full set of interfaces might not be available on the object until
		/// asynchronous initialization of the rowset has completed. DB_S_ASYNCHRONOUS should be returned before DB_S_ERRORSOCCURRED.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// DB_S_ERRORSOCCURRED The rowset was opened, but one or more properties ? for which the dwOptions element of the DBPROP structure
		/// was DBPROPOPTIONS_OPTIONAL ? were not set. The consumer checks dwStatus in the DBPROP structures to determine which properties
		/// were not set. The method can fail to set properties for a number of reasons, including:
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// DB_S_STOPLIMITREACHED Execution has been stopped because a resource limit has been reached. The results obtained so far have been
		/// returned. This return code takes precedence over DB_S_ERRORSOCCURRED; that is, if the conditions described here and those
		/// described in DB_S_ERRORSOCCURRED both occur, the provider returns this code. When the consumer receives this return code, it
		/// should also check for the conditions described in DB_S_ERRORSOCCURRED.
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
		/// <para>The provider does not support opening indexes through <c>IScopedOperations</c>.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_E_NOTABLE The specified URL does not exist in the data store or does not reside within the scope of the current row.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_E_NOTCOLLECTION pTableID specified a URL that does not name a collection.</para>
		/// <para>pTableID was a null pointer or specified an empty string, and the current row is not a collection.</para>
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
		/// <para>DB_E_RESOURCEOUTOFSCOPE pTableID named a URL that is not within the scope of the current row.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// DB_SEC_E_PERMISSIONDENIED The consumer did not have sufficient permission to open the rowset object. For example, the rowset
		/// might have included a column for which the consumer does not have read permission.
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
		/// <para>E_INVALIDARG pTableID is not NULL, and pTableID-&gt;eKind is not DBKIND_NAME.</para>
		/// <para>ppRowset was a null pointer.</para>
		/// <para>cPropertySets was not zero, and rgPropertySets was a null pointer.</para>
		/// <para>In an element of rgPropertySets, cPropertieswas not zero and rgProperties was a null pointer.</para>
		/// <para>pIndexID was not NULL.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>E_NOINTERFACE The rowset did not support the interface specified in riid, or riid was IID_NULL.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>E_OUTOFMEMORY The provider did not have enough memory to create the rowset.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// E_UNEXPECTED <c>ITransaction::Commit</c>, <c>ITransaction::Abort</c>, or <c>IScopedOperations::Delete</c> (on this row) was
		/// called, and the object is in a zombie state.
		/// </para>
		/// </description>
		/// </item>
		/// </list>
		/// </returns>
		// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/ms717916(v=vs.85) HRESULT OpenRowset ( IUnknown *pUnkOuter,
		// DBID *pTableID, DBID *pIndexID, REFIID riid, ULONG cPropertySets, DBPROPSET rgPropertySets[ ], IUnknown **ppRowset );
		[PreserveSig]
		HRESULT OpenRowset([In, Optional, MarshalAs(UnmanagedType.IUnknown)] object? pUnkOuter, [In, Optional] StructPointer<DBID> pTableID, [In, Optional] StructPointer<DBID> pIndexID,
			in Guid riid, uint cPropertySets, [In, Out] SafeDBPROPSETListHandle rgPropertySets, [Out, MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 3)] out object? ppRowset);
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

	/// <summary>
	/// The <c>ITableCreation</c> extends <c>ITableDefinition</c> to provide a full set of methods to create or describe the complete set of
	/// table definition information.
	/// </summary>
	// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/ms713639(v=vs.85)
	[PInvokeData("oledb.h")]
	[ComImport, Guid("0c733abc-2a1c-11ce-ade5-00aa0044773d"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ITableCreation : ITableDefinition
	{
		/// <summary>Creates a new base table in the data store.</summary>
		/// <param name="pUnkOuter">[in] The controlling unknown if the rowset is to be aggregated; otherwise, a null pointer.</param>
		/// <param name="pTableID">
		/// [in] A pointer to the ID of the table to create. If this is a null pointer, the provider must assign a unique ID to the table.
		/// </param>
		/// <param name="cColumnDescs">
		/// [in] The number of DBCOLUMNDESC structures in the rgColumnDescs array. This can be zero if the provider allows the creation of
		/// tables with no columns.
		/// </param>
		/// <param name="rgColumnDescs">
		/// <para>[in/out] An array of DBCOLUMNDESC structures that describe the columns of the table.</para>
		/// <para>
		/// The elements of this structure are used as follows. The consumer decides the values to use in the nonproperties elements of this
		/// structure based on values from the PROVIDER_TYPES schema rowset.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <description>Element</description>
		/// <description>Description</description>
		/// </listheader>
		/// <item>
		/// <description><c>pwszTypeName</c></description>
		/// <description>
		/// The provider-specific name of the data type of the column. This name corresponds to a value in the TYPE_NAME column in the
		/// PROVIDER_TYPES schema rowset. In most cases, there is no reason for a consumer to specify a value for <c>pwszTypeName</c> that is
		/// different from the values listed in the PROVIDER_TYPES schema rowset. If <c>pwszTypeName</c> is NULL, the provider determines the
		/// type of the column based upon <c>wType</c> and <c>ulColumnSize</c>, as well as any column properties, such as DBPROP_COL_ISLONG
		/// and DBPROP_COL_FIXEDLENGTH, passed in <c>rgPropertySets</c>. There may be some types that can only be created by specifying the
		/// name in <c>pwszTypeName</c> because they cannot be unambiguously determined based on the <c>wType</c>, <c>ulColumnSize</c>, and
		/// property values specified.
		/// </description>
		/// </item>
		/// <item>
		/// <description><c>pTypeInfo</c></description>
		/// <description>
		/// If <c>pTypeInfo</c> is not a null pointer, the data type of the column is an abstract data type (ADT) and values in this column
		/// are actually instances of the type described by the type library. <c>wType</c> may be either DBTYPE_BYTES, with a length of at
		/// least 4, or DBTYPE_IUNKNOWN. The instance values are required to be COM objects derived from <c>IUnknown</c>.
		/// </description>
		/// </item>
		/// <item>
		/// <description><c>rgPropertySets</c></description>
		/// <description>
		/// An array of DBPROPSET structures containing properties and values to be set. The properties specified in these structures must
		/// belong to the Column property group. All properties specified in <c>rgPropertySets</c> for this element of <c>rgColumnDescs</c>
		/// apply to the column specified by <c>dbcid</c>; the <c>colid</c> element in the DBPROP structure for specified properties is
		/// ignored. If the same property is specified more than once in <c>rgPropertySets</c>, it is provider-specific which value is used.
		/// If <c>cPropertySets</c> is zero, this argument is ignored. For information about the properties in the Column property group that
		/// are defined by OLE DB, see "Column Property Group" in Appendix C. For information about the DBPROPSET and DBPROP structures, see
		/// DBPROPSET Structure and DBPROP Structure.
		/// </description>
		/// </item>
		/// <item>
		/// <description><c>pclsid</c></description>
		/// <description>
		/// If the column contains COM objects, a pointer to the class ID of those objects. If more than one class of objects can reside in
		/// the column, * <c>pclsid</c> is set to IID_NULL. If the column does not contain COM objects, this is ignored and <c>pclsid</c>
		/// should be a null pointer.
		/// </description>
		/// </item>
		/// <item>
		/// <description><c>cPropertySets</c></description>
		/// <description>The number of DBPROPSET structures in <c>rgPropertySets</c>. If this is zero, the provider ignores <c>rgPropertySets</c>.</description>
		/// </item>
		/// <item>
		/// <description><c>ulColumnSize</c></description>
		/// <description>
		/// The maximum length in characters for values in this column if <c>wType</c> is DBTYPE_STR or DBTYPE_WSTR, or in bytes if
		/// <c>wType</c> is DBTYPE_BYTES. If <c>ulColumnSize</c> is zero and a default maximum column length is defined, the provider creates
		/// a column of that length. If no default is defined, the length of the created column is provider-specific. For all other values of
		/// <c>wType</c>, <c>ulColumnSize</c> is ignored. Providers that do not require a length argument in the specification of the
		/// provider type ( <c>pwszTypeName</c>) ignore this element.
		/// </description>
		/// </item>
		/// <item>
		/// <description><c>dbcid</c></description>
		/// <description>The column ID of the column.</description>
		/// </item>
		/// <item>
		/// <description><c>wType</c></description>
		/// <description>
		/// The type indicator for the data type of the column. This name corresponds to a value in the DATA_TYPE column in the
		/// PROVIDER_TYPES schema rowset. In most cases, there is no reason for a consumer to specify a value for <c>wType</c> that is
		/// different from the values listed in the PROVIDER_TYPES schema rowset.
		/// </description>
		/// </item>
		/// <item>
		/// <description><c>bPrecision</c></description>
		/// <description>
		/// The maximum precision of data values in the column when <c>wType</c> is the indicator for DBTYPE_NUMERIC or DBTYPE_VARNUMERIC; it
		/// is ignored for all other data types. This must be within the limits specified for the type in the COLUMN_SIZE column in the
		/// PROVIDER_TYPES schema rowset. For information about the precision of numeric data types, see Precision of Numeric Data Types in
		/// Appendix A.
		/// </description>
		/// </item>
		/// <item>
		/// <description><c>bScale</c></description>
		/// <description>
		/// The scale of data values in the column when <c>wType</c> is DBTYPE_NUMERIC, DBTYPE_VARNUMERIC, or DBTYPE_DECIMAL; it is ignored
		/// for all other data types. This must be within the limits specified for the type in the MINIMUM_SCALE and MAXIMUM_SCALE columns in
		/// the PROVIDER_TYPES schema rowset.
		/// </description>
		/// </item>
		/// </list>
		/// <para>
		/// <para>Note</para>
		/// <para>
		/// The provider does not modify any elements of the DBCOLUMNDESC structures. However, upon a return code of S_OK,
		/// DB_S_ERRORSOCCURRED, or DB_E_ERRORSOCCURRED, the dwStatus element in the DBPROP structure for each column property indicates
		/// whether or not that column property was set (DBPROPSTATUS_OK).
		/// </para>
		/// </para>
		/// </param>
		/// <param name="riid">
		/// [in] The IID of the interface to be returned for the resulting rowset; this is ignored if ppRowset is a null pointer.
		/// </param>
		/// <param name="cPropertySets">
		/// [in] The number of DBPROPSET structures in rgPropertySets. If this is zero, the provider ignores rgPropertySets.
		/// </param>
		/// <param name="rgPropertySets">
		/// <para>
		/// [in/out] An array of DBPROPSET structures containing properties and values to be set. The properties specified in these
		/// structures must belong to the Rowset property group (for properties that apply to the rowset returned in *ppRowset) or the Table
		/// property group (for properties that apply to the table). If the same property is specified more than once in rgPropertySets, it
		/// is provider-specific which value is used. If cPropertySets is zero, this argument is ignored.
		/// </para>
		/// <para>
		/// <para>Note</para>
		/// <para>
		/// The colid element of every DBPROP structure passed to the method must be set either to a valid DBID value or to DB_NULLID. For
		/// rowset properties, the colid element of the DBPROP structure must be set either to the ID of the rowset column to which the
		/// property applies or to DB_NULLID if the property applies to the entire rowset. For table properties, the property applies to the
		/// entire table and therefore the colid element of the DBPROP structure must be set to DB_NULLID.
		/// </para>
		/// <para>
		/// For information about the properties in the Rowset and Tables property groups that are defined by OLE DB, see Rowset Property
		/// Group and Table Property Group in Appendix C. For information about the DBPROPSET and DBPROP structures, see DBPROPSET Structure
		/// and DBPROP Structure.
		/// </para>
		/// </para>
		/// </param>
		/// <param name="ppTableID">
		/// <para>
		/// [out] A pointer to memory in which to return the DBID of the newly created table. If ppTableID is a null pointer, no DBID is returned.
		/// </para>
		/// <para>
		/// <para>Note</para>
		/// <para>
		/// The contents of *ppTableID might not exactly match the passed pTableID. (For example, it might contain additional version or
		/// other information.) The consumer should use *ppTableID to identify the newly created table. If ppTableID is NULL on input and the
		/// provider cannot create a table that exactly matches pTableID, <c>ITableDefinition::CreateTable</c> should fail with DB_E_BADTABLEID.
		/// </para>
		/// </para>
		/// </param>
		/// <param name="ppRowset">
		/// [out] A pointer to memory in which to return the requested interface pointer on an empty rowset opened on the newly created
		/// table. If ppRowset is a null pointer, no rowset is created.
		/// </param>
		/// <returns>
		/// <list type="bullet">
		/// <item>
		/// <description>
		/// <para>
		/// S_OK The method succeeded and the table is created and opened. In all DBPROP structures passed to the method, dwStatus is set to DBPROPSTATUS_OK.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// DB_S_ERRORSOCCURRED The table was created and the rowset was opened, but one or more properties ? for which the dwOptions element
		/// of the DBPROP structure was DBPROPOPTIONS_OPTIONAL ? were not set. The consumer checks dwStatus in the DBPROP structures to
		/// determine which properties were not set. The method can fail to set properties for a number of reasons, including the following:
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
		/// <para>E_INVALIDARG pTableID and ppTableID were both null pointers.</para>
		/// <para>
		/// cColumnDesc was not zero, or rgColumnDescs was a null pointer. cColumnDesc was zero, and the provider does not support creating
		/// tables with no columns.
		/// </para>
		/// <para>cPropertySets was not zero, and rgPropertySets was a null pointer.</para>
		/// <para>In an element of rgPropertySets, cProperties was not zero and rgProperties was a null pointer.</para>
		/// <para>In an element of rgColumnDescs, cPropertySets was not zero and rgPropertySets was a null pointer.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>E_NOINTERFACE The rowset did not support the interface specified in riid.</para>
		/// <para>riid was IID_NULL, and ppRowset was not a null pointer.</para>
		/// <para>DB_E_BADCOLUMNIDdbcid in an element of rgColumnDescs was an invalid column ID.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_E_BADTABLEID *pTableID was an invalid table ID.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_E_BADPRECISION The precision in an element of rgColumnDescs was invalid.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_E_BADSCALE The scale in an element of rgColumnDescs was invalid.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_E_BADTYPE The wType, pwszTypeName, or pTypeInfo element, in an element of rgColumnDescs was invalid.</para>
		/// <para>In an element of rgColumnDescs, pwszTypeName was non-null and implied a DBTYPE other than the type specified by wType.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_E_DUPLICATECOLUMNID dbcid was the same in two or more elements of rgColumnDescs.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_E_DUPLICATETABLEID The specified table already exists in the current data store.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// DB_E_ERRORSOCCURRED The table was not created, and no rowset was returned because one or more properties ? for which the
		/// dwOptions element of the DBPROP structure was DBPROPOPTIONS_REQUIRED or an invalid value ? could not be set. The consumer checks
		/// dwStatus in the DBPROP structures to determine which properties were not set. The method can fail to set properties for any of
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
		/// <para>DB_SEC_E_PERMISSIONDENIED The consumer did not have sufficient permission to create the table.</para>
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
		/// <para>
		/// XACT_E_XTIONEXISTS The provider supports transactional DDL, the session is participating in a transaction, and the value of
		/// DBPROP_SUPPORTEDTXNDDL is DBPROPVAL_TC_DML.
		/// </para>
		/// </description>
		/// </item>
		/// </list>
		/// </returns>
		// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/ms719598(v=vs.85) HRESULT CreateTable( IUnknown *pUnkOuter,
		// DBID *pTableID, DBORDINAL cColumnDescs, const DBCOLUMNDESC rgColumnDescs[], REFIID riid, ULONG cPropertySets, DBPROPSET
		// rgPropertySets[], DBID **ppTableID, IUnknown **ppRowset);
		[PreserveSig]
		new HRESULT CreateTable([In, Optional, MarshalAs(UnmanagedType.IUnknown)] object? pUnkOuter, [In, Optional] IntPtr pTableID,
			DBORDINAL cColumnDescs, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] DBCOLUMNDESC[]? rgColumnDescs,
			in Guid riid, uint cPropertySets, [In] SafeDBPROPSETListHandle rgPropertySets,
			out IntPtr ppTableID, [MarshalAs(UnmanagedType.IUnknown)] out object? ppRowset);

		/// <summary>Drops a base table in the data store.</summary>
		/// <returns>
		/// <list type="bullet">
		/// <item>
		/// <description>
		/// <para>S_OK The method succeeded and the table is dropped.</para>
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
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_E_DROPRESTRICTED The provider could not drop the table because pTableID was referenced in a view definition.</para>
		/// <para>The provider could not drop the table because pTableID was referenced in a constraint belonging to a table other than pTableID.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_E_NOTABLE The specified table does not exist in the current data store.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_E_TABLEINUSE The specified table was in use and could not be dropped.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_SEC_E_PERMISSIONDENIED The consumer did not have sufficient permission to drop the table.</para>
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
		// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/ms713664(v=vs.85) HRESULT DropTable ( DBID *pTableID);
		[PreserveSig]
		new HRESULT DropTable(in DBID pTableID);

		/// <summary>Adds a new column to a base table.</summary>
		/// <param name="pTableID">[in] A pointer to the DBID of the table to which the column is to be added.</param>
		/// <param name="pColumnDesc">
		/// [in/out] A pointer to the DBCOLUMNDESC structure that describes the new column. For more information about the DBCOLUMNDESC
		/// structure, see ITableDefinition::CreateTable.
		/// </param>
		/// <param name="ppColumnID">
		/// <para>
		/// [out] A pointer to memory in which to return the returned DBID of a newly created column. If this is a null pointer, no DBID is
		/// returned. If ppColumnID is non-null, the provider allocates memory for the DBID and overwrites *ppColumnID with a pointer to this
		/// new DBID without regard for its current value.
		/// </para>
		/// <para>
		/// <para>Note</para>
		/// <para>
		/// The contents of *ppColumnID might not exactly match the passed dbcid in *pColumnDesc. The consumer should use *ppColumnID to
		/// identify the newly created column. If ppColumnID is NULL on input and the provider cannot create a column that exactly matches
		/// dbcid in *pColumnDesc, <c>AddColumn</c> should fail with DB_E_BADCOLUMNID.
		/// </para>
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
		/// DB_S_ERRORSOCCURRED The column was added, but one or more properties ? for which the dwOptions element of the DBPROP structure
		/// was DBPROPOPTIONS_OPTIONAL ? were not set. The consumer checks dwStatus in the DBPROP structures to determine which properties
		/// were not set. The method can fail to set properties for a number of reasons, including:
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
		/// <para>E_INVALIDARG pTableID or pColumnDesc was a null pointer.</para>
		/// <para>cPropertySets was not zero, and rgPropertySets was a null pointer in the DBCOLUMNDESC structure.</para>
		/// <para>In an element of rgPropertySets, cProperties was not zero and rgProperties was a null pointer.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_E_BADCOLUMNID dbcid in *pColumnDesc was an invalid column ID.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_E_BADPRECISION The precision in *pColumnDesc was invalid.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_E_BADSCALE The scale in *pColumnDesc was invalid.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_E_BADTYPE The wType, pwszTypeName, or pTypeInfo element, in an element of rgColumnDescs was invalid.</para>
		/// <para>In an element of rgColumnDescs, pwszTypeName was non-null and implied a DBTYPE other than the type specified by wType.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_E_DUPLICATECOLUMNID dbcid in *pColumnDesc was the same as an existing column ID.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// DB_E_ERRORSOCCURRED The column was not added because one or more properties ? for which the dwOptions element of the DBPROP
		/// structure was DBPROPOPTIONS_REQUIRED or an invalid value ? could not be set. The consumer checks dwStatus in the DBPROP
		/// structures to determine which properties were not set. The method can fail to set properties for any of the reasons specified in DB_S_ERRORSOCCURRED.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_E_NOTABLE The specified table does not exist in the current data store.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_E_TABLEINUSE The specified table was in use.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_SEC_E_PERMISSIONDENIED The consumer did not have sufficient permission to add a column.</para>
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
		// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/ms712851(v=vs.85) HRESULT AddColumn( DBID *pTableID,
		// DBCOLUMNDESC *pColumnDesc, DBID **ppColumnID);
		[PreserveSig]
		new HRESULT AddColumn(in DBID pTableID, in DBCOLUMNDESC pColumnDesc, [Optional] out IntPtr ppColumnID);

		/// <summary>Drops a column from the base table.</summary>
		/// <param name="pTableID">[in] A pointer to the DBID of the table from which to drop the column.</param>
		/// <param name="pColumnID">[in] A pointer to the DBID of the column to drop.</param>
		/// <returns>
		/// <list type="bullet">
		/// <item>
		/// <description>
		/// <para>S_OK The method succeeded, and the column was dropped from the base table.</para>
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
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_E_NOCOLUMN The column specified in *pColumnID does not exist in the specified table.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_E_DROPRESTRICTED The provider could not drop the column because pColumnID was referenced in a view definition.</para>
		/// <para>
		/// The provider could not drop the column because pColumnID was referenced in a constraint belonging to a table other than pTableID.
		/// </para>
		/// <para>
		/// The provider could not drop the column because pColumnID was referenced, along with one or more other columns, in a constraint
		/// definition on pTableID.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_E_NOTABLE The specified table does not exist in the current data store.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_E_TABLEINUSE The specified table was in use.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_SEC_E_PERMISSIONDENIED The consumer did not have sufficient permission to drop the column.</para>
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
		// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/ms715924(v=vs.85) HRESULT DropColumn( DBID *pTableID, DBID *pColumnID);
		[PreserveSig]
		new HRESULT DropColumn(in DBID pTableID, in DBID pColumnID);

		/// <summary>Returns creation information for a table.</summary>
		/// <param name="pTableID">[in] A pointer to the ID of the table to describe.</param>
		/// <param name="pcColumnDescs">
		/// [out] A pointer to the number of DBCOLUMNDESC structures in the prgColumnDescs array. If pcColumnDescs is NULL, the provider
		/// ignores prgColumnDescs and does not return any column descriptions.
		/// </param>
		/// <param name="prgColumnDescs">
		/// [out] A pointer to an array of DBCOLUMNDESC structures that describe the columns of the table, or NULL if the consumer is not
		/// interested in getting back column descriptions. For more information on the DBCOLUMNDESC structure, see ITableDefinition::CreateTable.
		/// </param>
		/// <param name="pcPropertySets">
		/// [out] A pointer to the number of DBPROPSET structures in prgPropertySets. If this is NULL, the provider ignores prgPropertySets
		/// and does not return any table creation properties.
		/// </param>
		/// <param name="prgPropertySets">
		/// <para>
		/// [out] A pointer to an array of DBPROPSET structures containing properties and values used in creation of the table, or NULL if
		/// the consumer is not interested in getting back table creation properties. The properties returned in these structures belong to
		/// the Table property group.
		/// </para>
		/// <para>
		/// For information about the properties in the Tables property groups that are defined by OLE DB, see Table Property Group in
		/// Appendix C: OLE DB Properties. For information about the DBPROPSET and DBPROP structures, see DBPROPSET Structure and DBPROP Structure.
		/// </para>
		/// </param>
		/// <param name="pcConstraintDescs">
		/// [out] A pointer to the number of DBCONSTRAINTDESC structures in the prgConstraintDescs array. If this is NULL, the provider
		/// ignores the value of prgConstraintDescs and does not return any column descriptions.
		/// </param>
		/// <param name="prgConstraintDescs">
		/// [out] A pointer to an array of DBCONSTRAINTDESC structures that describe the columns of the table, or NULL if no constraint
		/// definitions are to be returned to the consumer. For more information on DBCONSTRAINTDESC structure, see ITableDefinitionWithConstraints::AddConstraint.
		/// </param>
		/// <param name="ppwszStringBuffer">
		/// [out] A pointer to memory in which to return a pointer to storage for all string values returned in the pwszTypeName element of
		/// DBCOLUMNDESC structure or the pwszConstraintText element of the DBCONSTRAINTDESC structure. The provider allocates this memory
		/// with <c>IMalloc</c>, and the consumer frees it with <c>IMalloc::Free</c> when it no longer needs the descriptions. If
		/// ppwszStringBuffer is a null pointer on input, <c>ITableCreation::GetTableDefinition</c> does not return the string values. If no
		/// shared memory is allocated for pwszTypeName or pwszConstraintText for any elements of prgColumnDescs or prgConstraintDescs,
		/// respectively, or if an error occurs, the provider does not allocate any memory and ensures that *ppwszStringBuffer is a null
		/// pointer on output. Each of the individual string values stored in this buffer is terminated by a null-termination character.
		/// Therefore, the buffer may contain one or more strings, each with its own null-termination character, and may contain embedded
		/// null-termination characters.
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
		/// <para>E_INVALIDARG pTableID was a null pointer.</para>
		/// <para>pcColumnDescs was not null, and prgColumnDescs was a null pointer.</para>
		/// <para>pcPropertySets was not null, and prgPropertySets was a null pointer.</para>
		/// <para>pcConstraintDescs was not null, and prgConstraintDescs was a null pointer.</para>
		/// <para>pcColumnDescs, pcPropertySets, and pcConstraintDescs were all null pointers.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_E_NOTABLE The table specified in pTableID does not exist in the current data source.</para>
		/// </description>
		/// </item>
		/// </list>
		/// </returns>
		// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/ms714993(v=vs.85) HRESULT GetTableDefinition( DBID *pTableID,
		// DBORDINAL *pcColumnDescs, DBCOLUMNDESC *prgColumnDescs[], ULONG *pcPropertySets, DBPROPSET *prgPropertySets[], ULONG
		// *pcConstraintDescs, DBCONSTRAINTDESC *prgConstraintDescs[], OLECHAR **ppwszStringBuffer);
		[PreserveSig]
		HRESULT GetTableDefinition(in DBID pTableID, out DBORDINAL pcColumnDescs, out SafeIMallocHandle prgColumnDescs, out uint pcPropertySets,
			out SafeDBPROPSETListHandle prgPropertySets, out uint pcConstraintDescs, out SafeIMallocHandle prgConstraintDescs,
			out SafeIMallocHandle ppwszStringBuffer);
	}

	/// <summary>The <c>ITableDefinition</c> interface exposes simple methods to create, drop, and alter tables on the data store.</summary>
	// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/ms714277(v=vs.85)
	[PInvokeData("oledb.h")]
	[ComImport, Guid("0c733a86-2a1c-11ce-ade5-00aa0044773d"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ITableDefinition
	{
		/// <summary>Creates a new base table in the data store.</summary>
		/// <param name="pUnkOuter">[in] The controlling unknown if the rowset is to be aggregated; otherwise, a null pointer.</param>
		/// <param name="pTableID">
		/// [in] A pointer to the ID of the table to create. If this is a null pointer, the provider must assign a unique ID to the table.
		/// </param>
		/// <param name="cColumnDescs">
		/// [in] The number of DBCOLUMNDESC structures in the rgColumnDescs array. This can be zero if the provider allows the creation of
		/// tables with no columns.
		/// </param>
		/// <param name="rgColumnDescs">
		/// <para>[in/out] An array of DBCOLUMNDESC structures that describe the columns of the table.</para>
		/// <para>
		/// The elements of this structure are used as follows. The consumer decides the values to use in the nonproperties elements of this
		/// structure based on values from the PROVIDER_TYPES schema rowset.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <description>Element</description>
		/// <description>Description</description>
		/// </listheader>
		/// <item>
		/// <description><c>pwszTypeName</c></description>
		/// <description>
		/// The provider-specific name of the data type of the column. This name corresponds to a value in the TYPE_NAME column in the
		/// PROVIDER_TYPES schema rowset. In most cases, there is no reason for a consumer to specify a value for <c>pwszTypeName</c> that is
		/// different from the values listed in the PROVIDER_TYPES schema rowset. If <c>pwszTypeName</c> is NULL, the provider determines the
		/// type of the column based upon <c>wType</c> and <c>ulColumnSize</c>, as well as any column properties, such as DBPROP_COL_ISLONG
		/// and DBPROP_COL_FIXEDLENGTH, passed in <c>rgPropertySets</c>. There may be some types that can only be created by specifying the
		/// name in <c>pwszTypeName</c> because they cannot be unambiguously determined based on the <c>wType</c>, <c>ulColumnSize</c>, and
		/// property values specified.
		/// </description>
		/// </item>
		/// <item>
		/// <description><c>pTypeInfo</c></description>
		/// <description>
		/// If <c>pTypeInfo</c> is not a null pointer, the data type of the column is an abstract data type (ADT) and values in this column
		/// are actually instances of the type described by the type library. <c>wType</c> may be either DBTYPE_BYTES, with a length of at
		/// least 4, or DBTYPE_IUNKNOWN. The instance values are required to be COM objects derived from <c>IUnknown</c>.
		/// </description>
		/// </item>
		/// <item>
		/// <description><c>rgPropertySets</c></description>
		/// <description>
		/// An array of DBPROPSET structures containing properties and values to be set. The properties specified in these structures must
		/// belong to the Column property group. All properties specified in <c>rgPropertySets</c> for this element of <c>rgColumnDescs</c>
		/// apply to the column specified by <c>dbcid</c>; the <c>colid</c> element in the DBPROP structure for specified properties is
		/// ignored. If the same property is specified more than once in <c>rgPropertySets</c>, it is provider-specific which value is used.
		/// If <c>cPropertySets</c> is zero, this argument is ignored. For information about the properties in the Column property group that
		/// are defined by OLE DB, see "Column Property Group" in Appendix C. For information about the DBPROPSET and DBPROP structures, see
		/// DBPROPSET Structure and DBPROP Structure.
		/// </description>
		/// </item>
		/// <item>
		/// <description><c>pclsid</c></description>
		/// <description>
		/// If the column contains COM objects, a pointer to the class ID of those objects. If more than one class of objects can reside in
		/// the column, * <c>pclsid</c> is set to IID_NULL. If the column does not contain COM objects, this is ignored and <c>pclsid</c>
		/// should be a null pointer.
		/// </description>
		/// </item>
		/// <item>
		/// <description><c>cPropertySets</c></description>
		/// <description>The number of DBPROPSET structures in <c>rgPropertySets</c>. If this is zero, the provider ignores <c>rgPropertySets</c>.</description>
		/// </item>
		/// <item>
		/// <description><c>ulColumnSize</c></description>
		/// <description>
		/// The maximum length in characters for values in this column if <c>wType</c> is DBTYPE_STR or DBTYPE_WSTR, or in bytes if
		/// <c>wType</c> is DBTYPE_BYTES. If <c>ulColumnSize</c> is zero and a default maximum column length is defined, the provider creates
		/// a column of that length. If no default is defined, the length of the created column is provider-specific. For all other values of
		/// <c>wType</c>, <c>ulColumnSize</c> is ignored. Providers that do not require a length argument in the specification of the
		/// provider type ( <c>pwszTypeName</c>) ignore this element.
		/// </description>
		/// </item>
		/// <item>
		/// <description><c>dbcid</c></description>
		/// <description>The column ID of the column.</description>
		/// </item>
		/// <item>
		/// <description><c>wType</c></description>
		/// <description>
		/// The type indicator for the data type of the column. This name corresponds to a value in the DATA_TYPE column in the
		/// PROVIDER_TYPES schema rowset. In most cases, there is no reason for a consumer to specify a value for <c>wType</c> that is
		/// different from the values listed in the PROVIDER_TYPES schema rowset.
		/// </description>
		/// </item>
		/// <item>
		/// <description><c>bPrecision</c></description>
		/// <description>
		/// The maximum precision of data values in the column when <c>wType</c> is the indicator for DBTYPE_NUMERIC or DBTYPE_VARNUMERIC; it
		/// is ignored for all other data types. This must be within the limits specified for the type in the COLUMN_SIZE column in the
		/// PROVIDER_TYPES schema rowset. For information about the precision of numeric data types, see Precision of Numeric Data Types in
		/// Appendix A.
		/// </description>
		/// </item>
		/// <item>
		/// <description><c>bScale</c></description>
		/// <description>
		/// The scale of data values in the column when <c>wType</c> is DBTYPE_NUMERIC, DBTYPE_VARNUMERIC, or DBTYPE_DECIMAL; it is ignored
		/// for all other data types. This must be within the limits specified for the type in the MINIMUM_SCALE and MAXIMUM_SCALE columns in
		/// the PROVIDER_TYPES schema rowset.
		/// </description>
		/// </item>
		/// </list>
		/// <para>
		/// <para>Note</para>
		/// <para>
		/// The provider does not modify any elements of the DBCOLUMNDESC structures. However, upon a return code of S_OK,
		/// DB_S_ERRORSOCCURRED, or DB_E_ERRORSOCCURRED, the dwStatus element in the DBPROP structure for each column property indicates
		/// whether or not that column property was set (DBPROPSTATUS_OK).
		/// </para>
		/// </para>
		/// </param>
		/// <param name="riid">
		/// [in] The IID of the interface to be returned for the resulting rowset; this is ignored if ppRowset is a null pointer.
		/// </param>
		/// <param name="cPropertySets">
		/// [in] The number of DBPROPSET structures in rgPropertySets. If this is zero, the provider ignores rgPropertySets.
		/// </param>
		/// <param name="rgPropertySets">
		/// <para>
		/// [in/out] An array of DBPROPSET structures containing properties and values to be set. The properties specified in these
		/// structures must belong to the Rowset property group (for properties that apply to the rowset returned in *ppRowset) or the Table
		/// property group (for properties that apply to the table). If the same property is specified more than once in rgPropertySets, it
		/// is provider-specific which value is used. If cPropertySets is zero, this argument is ignored.
		/// </para>
		/// <para>
		/// <para>Note</para>
		/// <para>
		/// The colid element of every DBPROP structure passed to the method must be set either to a valid DBID value or to DB_NULLID. For
		/// rowset properties, the colid element of the DBPROP structure must be set either to the ID of the rowset column to which the
		/// property applies or to DB_NULLID if the property applies to the entire rowset. For table properties, the property applies to the
		/// entire table and therefore the colid element of the DBPROP structure must be set to DB_NULLID.
		/// </para>
		/// <para>
		/// For information about the properties in the Rowset and Tables property groups that are defined by OLE DB, see Rowset Property
		/// Group and Table Property Group in Appendix C. For information about the DBPROPSET and DBPROP structures, see DBPROPSET Structure
		/// and DBPROP Structure.
		/// </para>
		/// </para>
		/// </param>
		/// <param name="ppTableID">
		/// <para>
		/// [out] A pointer to memory in which to return the DBID of the newly created table. If ppTableID is a null pointer, no DBID is returned.
		/// </para>
		/// <para>
		/// <para>Note</para>
		/// <para>
		/// The contents of *ppTableID might not exactly match the passed pTableID. (For example, it might contain additional version or
		/// other information.) The consumer should use *ppTableID to identify the newly created table. If ppTableID is NULL on input and the
		/// provider cannot create a table that exactly matches pTableID, <c>ITableDefinition::CreateTable</c> should fail with DB_E_BADTABLEID.
		/// </para>
		/// </para>
		/// </param>
		/// <param name="ppRowset">
		/// [out] A pointer to memory in which to return the requested interface pointer on an empty rowset opened on the newly created
		/// table. If ppRowset is a null pointer, no rowset is created.
		/// </param>
		/// <returns>
		/// <list type="bullet">
		/// <item>
		/// <description>
		/// <para>
		/// S_OK The method succeeded and the table is created and opened. In all DBPROP structures passed to the method, dwStatus is set to DBPROPSTATUS_OK.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// DB_S_ERRORSOCCURRED The table was created and the rowset was opened, but one or more properties ? for which the dwOptions element
		/// of the DBPROP structure was DBPROPOPTIONS_OPTIONAL ? were not set. The consumer checks dwStatus in the DBPROP structures to
		/// determine which properties were not set. The method can fail to set properties for a number of reasons, including the following:
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
		/// <para>E_INVALIDARG pTableID and ppTableID were both null pointers.</para>
		/// <para>
		/// cColumnDesc was not zero, or rgColumnDescs was a null pointer. cColumnDesc was zero, and the provider does not support creating
		/// tables with no columns.
		/// </para>
		/// <para>cPropertySets was not zero, and rgPropertySets was a null pointer.</para>
		/// <para>In an element of rgPropertySets, cProperties was not zero and rgProperties was a null pointer.</para>
		/// <para>In an element of rgColumnDescs, cPropertySets was not zero and rgPropertySets was a null pointer.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>E_NOINTERFACE The rowset did not support the interface specified in riid.</para>
		/// <para>riid was IID_NULL, and ppRowset was not a null pointer.</para>
		/// <para>DB_E_BADCOLUMNIDdbcid in an element of rgColumnDescs was an invalid column ID.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_E_BADTABLEID *pTableID was an invalid table ID.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_E_BADPRECISION The precision in an element of rgColumnDescs was invalid.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_E_BADSCALE The scale in an element of rgColumnDescs was invalid.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_E_BADTYPE The wType, pwszTypeName, or pTypeInfo element, in an element of rgColumnDescs was invalid.</para>
		/// <para>In an element of rgColumnDescs, pwszTypeName was non-null and implied a DBTYPE other than the type specified by wType.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_E_DUPLICATECOLUMNID dbcid was the same in two or more elements of rgColumnDescs.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_E_DUPLICATETABLEID The specified table already exists in the current data store.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// DB_E_ERRORSOCCURRED The table was not created, and no rowset was returned because one or more properties ? for which the
		/// dwOptions element of the DBPROP structure was DBPROPOPTIONS_REQUIRED or an invalid value ? could not be set. The consumer checks
		/// dwStatus in the DBPROP structures to determine which properties were not set. The method can fail to set properties for any of
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
		/// <para>DB_SEC_E_PERMISSIONDENIED The consumer did not have sufficient permission to create the table.</para>
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
		/// <para>
		/// XACT_E_XTIONEXISTS The provider supports transactional DDL, the session is participating in a transaction, and the value of
		/// DBPROP_SUPPORTEDTXNDDL is DBPROPVAL_TC_DML.
		/// </para>
		/// </description>
		/// </item>
		/// </list>
		/// </returns>
		// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/ms719598(v=vs.85) HRESULT CreateTable( IUnknown *pUnkOuter,
		// DBID *pTableID, DBORDINAL cColumnDescs, const DBCOLUMNDESC rgColumnDescs[], REFIID riid, ULONG cPropertySets, DBPROPSET
		// rgPropertySets[], DBID **ppTableID, IUnknown **ppRowset);
		[PreserveSig]
		HRESULT CreateTable([In, Optional, MarshalAs(UnmanagedType.IUnknown)] object? pUnkOuter, [In, Optional] IntPtr pTableID,
			DBORDINAL cColumnDescs, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] DBCOLUMNDESC[]? rgColumnDescs,
			in Guid riid, uint cPropertySets, [In] SafeDBPROPSETListHandle rgPropertySets,
			out IntPtr ppTableID, [MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 4)] out object? ppRowset);

		/// <summary>Drops a base table in the data store.</summary>
		/// <returns>
		/// <list type="bullet">
		/// <item>
		/// <description>
		/// <para>S_OK The method succeeded and the table is dropped.</para>
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
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_E_DROPRESTRICTED The provider could not drop the table because pTableID was referenced in a view definition.</para>
		/// <para>The provider could not drop the table because pTableID was referenced in a constraint belonging to a table other than pTableID.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_E_NOTABLE The specified table does not exist in the current data store.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_E_TABLEINUSE The specified table was in use and could not be dropped.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_SEC_E_PERMISSIONDENIED The consumer did not have sufficient permission to drop the table.</para>
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
		// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/ms713664(v=vs.85) HRESULT DropTable ( DBID *pTableID);
		[PreserveSig]
		HRESULT DropTable(in DBID pTableID);

		/// <summary>Adds a new column to a base table.</summary>
		/// <param name="pTableID">[in] A pointer to the DBID of the table to which the column is to be added.</param>
		/// <param name="pColumnDesc">
		/// [in/out] A pointer to the DBCOLUMNDESC structure that describes the new column. For more information about the DBCOLUMNDESC
		/// structure, see ITableDefinition::CreateTable.
		/// </param>
		/// <param name="ppColumnID">
		/// <para>
		/// [out] A pointer to memory in which to return the returned DBID of a newly created column. If this is a null pointer, no DBID is
		/// returned. If ppColumnID is non-null, the provider allocates memory for the DBID and overwrites *ppColumnID with a pointer to this
		/// new DBID without regard for its current value.
		/// </para>
		/// <para>
		/// <para>Note</para>
		/// <para>
		/// The contents of *ppColumnID might not exactly match the passed dbcid in *pColumnDesc. The consumer should use *ppColumnID to
		/// identify the newly created column. If ppColumnID is NULL on input and the provider cannot create a column that exactly matches
		/// dbcid in *pColumnDesc, <c>AddColumn</c> should fail with DB_E_BADCOLUMNID.
		/// </para>
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
		/// DB_S_ERRORSOCCURRED The column was added, but one or more properties ? for which the dwOptions element of the DBPROP structure
		/// was DBPROPOPTIONS_OPTIONAL ? were not set. The consumer checks dwStatus in the DBPROP structures to determine which properties
		/// were not set. The method can fail to set properties for a number of reasons, including:
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
		/// <para>E_INVALIDARG pTableID or pColumnDesc was a null pointer.</para>
		/// <para>cPropertySets was not zero, and rgPropertySets was a null pointer in the DBCOLUMNDESC structure.</para>
		/// <para>In an element of rgPropertySets, cProperties was not zero and rgProperties was a null pointer.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_E_BADCOLUMNID dbcid in *pColumnDesc was an invalid column ID.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_E_BADPRECISION The precision in *pColumnDesc was invalid.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_E_BADSCALE The scale in *pColumnDesc was invalid.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_E_BADTYPE The wType, pwszTypeName, or pTypeInfo element, in an element of rgColumnDescs was invalid.</para>
		/// <para>In an element of rgColumnDescs, pwszTypeName was non-null and implied a DBTYPE other than the type specified by wType.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_E_DUPLICATECOLUMNID dbcid in *pColumnDesc was the same as an existing column ID.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// DB_E_ERRORSOCCURRED The column was not added because one or more properties ? for which the dwOptions element of the DBPROP
		/// structure was DBPROPOPTIONS_REQUIRED or an invalid value ? could not be set. The consumer checks dwStatus in the DBPROP
		/// structures to determine which properties were not set. The method can fail to set properties for any of the reasons specified in DB_S_ERRORSOCCURRED.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_E_NOTABLE The specified table does not exist in the current data store.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_E_TABLEINUSE The specified table was in use.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_SEC_E_PERMISSIONDENIED The consumer did not have sufficient permission to add a column.</para>
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
		// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/ms712851(v=vs.85) HRESULT AddColumn( DBID *pTableID,
		// DBCOLUMNDESC *pColumnDesc, DBID **ppColumnID);
		[PreserveSig]
		HRESULT AddColumn(in DBID pTableID, in DBCOLUMNDESC pColumnDesc, [Optional] out IntPtr ppColumnID);

		/// <summary>Drops a column from the base table.</summary>
		/// <param name="pTableID">[in] A pointer to the DBID of the table from which to drop the column.</param>
		/// <param name="pColumnID">[in] A pointer to the DBID of the column to drop.</param>
		/// <returns>
		/// <list type="bullet">
		/// <item>
		/// <description>
		/// <para>S_OK The method succeeded, and the column was dropped from the base table.</para>
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
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_E_NOCOLUMN The column specified in *pColumnID does not exist in the specified table.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_E_DROPRESTRICTED The provider could not drop the column because pColumnID was referenced in a view definition.</para>
		/// <para>
		/// The provider could not drop the column because pColumnID was referenced in a constraint belonging to a table other than pTableID.
		/// </para>
		/// <para>
		/// The provider could not drop the column because pColumnID was referenced, along with one or more other columns, in a constraint
		/// definition on pTableID.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_E_NOTABLE The specified table does not exist in the current data store.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_E_TABLEINUSE The specified table was in use.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_SEC_E_PERMISSIONDENIED The consumer did not have sufficient permission to drop the column.</para>
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
		// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/ms715924(v=vs.85) HRESULT DropColumn( DBID *pTableID, DBID *pColumnID);
		[PreserveSig]
		HRESULT DropColumn(in DBID pTableID, in DBID pColumnID);
	}

	/// <summary>
	/// <para>
	/// The <c>ITableDefinitionWithConstraints</c> interface exposes simple methods to create, drop, and alter tables on the data store. It
	/// also provides a mechanism to create and delete multitable and multicolumn constraints on tables.
	/// </para>
	/// <para>
	/// <c>ITableDefinitionWithConstraints</c> extends <c>ITableCreation</c> by adding the ability to create and drop constraints from the
	/// base table and create base tables with constraints in one, atomic operation.
	/// </para>
	/// </summary>
	// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/ms720947(v=vs.85)
	[PInvokeData("oledb.h")]
	[ComImport, Guid("0c733aab-2a1c-11ce-ade5-00aa0044773d"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ITableDefinitionWithConstraints : ITableCreation
	{
		/// <summary>Creates a new base table in the data store.</summary>
		/// <param name="pUnkOuter">[in] The controlling unknown if the rowset is to be aggregated; otherwise, a null pointer.</param>
		/// <param name="pTableID">
		/// [in] A pointer to the ID of the table to create. If this is a null pointer, the provider must assign a unique ID to the table.
		/// </param>
		/// <param name="cColumnDescs">
		/// [in] The number of DBCOLUMNDESC structures in the rgColumnDescs array. This can be zero if the provider allows the creation of
		/// tables with no columns.
		/// </param>
		/// <param name="rgColumnDescs">
		/// <para>[in/out] An array of DBCOLUMNDESC structures that describe the columns of the table.</para>
		/// <para>
		/// The elements of this structure are used as follows. The consumer decides the values to use in the nonproperties elements of this
		/// structure based on values from the PROVIDER_TYPES schema rowset.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <description>Element</description>
		/// <description>Description</description>
		/// </listheader>
		/// <item>
		/// <description><c>pwszTypeName</c></description>
		/// <description>
		/// The provider-specific name of the data type of the column. This name corresponds to a value in the TYPE_NAME column in the
		/// PROVIDER_TYPES schema rowset. In most cases, there is no reason for a consumer to specify a value for <c>pwszTypeName</c> that is
		/// different from the values listed in the PROVIDER_TYPES schema rowset. If <c>pwszTypeName</c> is NULL, the provider determines the
		/// type of the column based upon <c>wType</c> and <c>ulColumnSize</c>, as well as any column properties, such as DBPROP_COL_ISLONG
		/// and DBPROP_COL_FIXEDLENGTH, passed in <c>rgPropertySets</c>. There may be some types that can only be created by specifying the
		/// name in <c>pwszTypeName</c> because they cannot be unambiguously determined based on the <c>wType</c>, <c>ulColumnSize</c>, and
		/// property values specified.
		/// </description>
		/// </item>
		/// <item>
		/// <description><c>pTypeInfo</c></description>
		/// <description>
		/// If <c>pTypeInfo</c> is not a null pointer, the data type of the column is an abstract data type (ADT) and values in this column
		/// are actually instances of the type described by the type library. <c>wType</c> may be either DBTYPE_BYTES, with a length of at
		/// least 4, or DBTYPE_IUNKNOWN. The instance values are required to be COM objects derived from <c>IUnknown</c>.
		/// </description>
		/// </item>
		/// <item>
		/// <description><c>rgPropertySets</c></description>
		/// <description>
		/// An array of DBPROPSET structures containing properties and values to be set. The properties specified in these structures must
		/// belong to the Column property group. All properties specified in <c>rgPropertySets</c> for this element of <c>rgColumnDescs</c>
		/// apply to the column specified by <c>dbcid</c>; the <c>colid</c> element in the DBPROP structure for specified properties is
		/// ignored. If the same property is specified more than once in <c>rgPropertySets</c>, it is provider-specific which value is used.
		/// If <c>cPropertySets</c> is zero, this argument is ignored. For information about the properties in the Column property group that
		/// are defined by OLE DB, see "Column Property Group" in Appendix C. For information about the DBPROPSET and DBPROP structures, see
		/// DBPROPSET Structure and DBPROP Structure.
		/// </description>
		/// </item>
		/// <item>
		/// <description><c>pclsid</c></description>
		/// <description>
		/// If the column contains COM objects, a pointer to the class ID of those objects. If more than one class of objects can reside in
		/// the column, * <c>pclsid</c> is set to IID_NULL. If the column does not contain COM objects, this is ignored and <c>pclsid</c>
		/// should be a null pointer.
		/// </description>
		/// </item>
		/// <item>
		/// <description><c>cPropertySets</c></description>
		/// <description>The number of DBPROPSET structures in <c>rgPropertySets</c>. If this is zero, the provider ignores <c>rgPropertySets</c>.</description>
		/// </item>
		/// <item>
		/// <description><c>ulColumnSize</c></description>
		/// <description>
		/// The maximum length in characters for values in this column if <c>wType</c> is DBTYPE_STR or DBTYPE_WSTR, or in bytes if
		/// <c>wType</c> is DBTYPE_BYTES. If <c>ulColumnSize</c> is zero and a default maximum column length is defined, the provider creates
		/// a column of that length. If no default is defined, the length of the created column is provider-specific. For all other values of
		/// <c>wType</c>, <c>ulColumnSize</c> is ignored. Providers that do not require a length argument in the specification of the
		/// provider type ( <c>pwszTypeName</c>) ignore this element.
		/// </description>
		/// </item>
		/// <item>
		/// <description><c>dbcid</c></description>
		/// <description>The column ID of the column.</description>
		/// </item>
		/// <item>
		/// <description><c>wType</c></description>
		/// <description>
		/// The type indicator for the data type of the column. This name corresponds to a value in the DATA_TYPE column in the
		/// PROVIDER_TYPES schema rowset. In most cases, there is no reason for a consumer to specify a value for <c>wType</c> that is
		/// different from the values listed in the PROVIDER_TYPES schema rowset.
		/// </description>
		/// </item>
		/// <item>
		/// <description><c>bPrecision</c></description>
		/// <description>
		/// The maximum precision of data values in the column when <c>wType</c> is the indicator for DBTYPE_NUMERIC or DBTYPE_VARNUMERIC; it
		/// is ignored for all other data types. This must be within the limits specified for the type in the COLUMN_SIZE column in the
		/// PROVIDER_TYPES schema rowset. For information about the precision of numeric data types, see Precision of Numeric Data Types in
		/// Appendix A.
		/// </description>
		/// </item>
		/// <item>
		/// <description><c>bScale</c></description>
		/// <description>
		/// The scale of data values in the column when <c>wType</c> is DBTYPE_NUMERIC, DBTYPE_VARNUMERIC, or DBTYPE_DECIMAL; it is ignored
		/// for all other data types. This must be within the limits specified for the type in the MINIMUM_SCALE and MAXIMUM_SCALE columns in
		/// the PROVIDER_TYPES schema rowset.
		/// </description>
		/// </item>
		/// </list>
		/// <para>
		/// <para>Note</para>
		/// <para>
		/// The provider does not modify any elements of the DBCOLUMNDESC structures. However, upon a return code of S_OK,
		/// DB_S_ERRORSOCCURRED, or DB_E_ERRORSOCCURRED, the dwStatus element in the DBPROP structure for each column property indicates
		/// whether or not that column property was set (DBPROPSTATUS_OK).
		/// </para>
		/// </para>
		/// </param>
		/// <param name="riid">
		/// [in] The IID of the interface to be returned for the resulting rowset; this is ignored if ppRowset is a null pointer.
		/// </param>
		/// <param name="cPropertySets">
		/// [in] The number of DBPROPSET structures in rgPropertySets. If this is zero, the provider ignores rgPropertySets.
		/// </param>
		/// <param name="rgPropertySets">
		/// <para>
		/// [in/out] An array of DBPROPSET structures containing properties and values to be set. The properties specified in these
		/// structures must belong to the Rowset property group (for properties that apply to the rowset returned in *ppRowset) or the Table
		/// property group (for properties that apply to the table). If the same property is specified more than once in rgPropertySets, it
		/// is provider-specific which value is used. If cPropertySets is zero, this argument is ignored.
		/// </para>
		/// <para>
		/// <para>Note</para>
		/// <para>
		/// The colid element of every DBPROP structure passed to the method must be set either to a valid DBID value or to DB_NULLID. For
		/// rowset properties, the colid element of the DBPROP structure must be set either to the ID of the rowset column to which the
		/// property applies or to DB_NULLID if the property applies to the entire rowset. For table properties, the property applies to the
		/// entire table and therefore the colid element of the DBPROP structure must be set to DB_NULLID.
		/// </para>
		/// <para>
		/// For information about the properties in the Rowset and Tables property groups that are defined by OLE DB, see Rowset Property
		/// Group and Table Property Group in Appendix C. For information about the DBPROPSET and DBPROP structures, see DBPROPSET Structure
		/// and DBPROP Structure.
		/// </para>
		/// </para>
		/// </param>
		/// <param name="ppTableID">
		/// <para>
		/// [out] A pointer to memory in which to return the DBID of the newly created table. If ppTableID is a null pointer, no DBID is returned.
		/// </para>
		/// <para>
		/// <para>Note</para>
		/// <para>
		/// The contents of *ppTableID might not exactly match the passed pTableID. (For example, it might contain additional version or
		/// other information.) The consumer should use *ppTableID to identify the newly created table. If ppTableID is NULL on input and the
		/// provider cannot create a table that exactly matches pTableID, <c>ITableDefinition::CreateTable</c> should fail with DB_E_BADTABLEID.
		/// </para>
		/// </para>
		/// </param>
		/// <param name="ppRowset">
		/// [out] A pointer to memory in which to return the requested interface pointer on an empty rowset opened on the newly created
		/// table. If ppRowset is a null pointer, no rowset is created.
		/// </param>
		/// <returns>
		/// <list type="bullet">
		/// <item>
		/// <description>
		/// <para>
		/// S_OK The method succeeded and the table is created and opened. In all DBPROP structures passed to the method, dwStatus is set to DBPROPSTATUS_OK.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// DB_S_ERRORSOCCURRED The table was created and the rowset was opened, but one or more properties ? for which the dwOptions element
		/// of the DBPROP structure was DBPROPOPTIONS_OPTIONAL ? were not set. The consumer checks dwStatus in the DBPROP structures to
		/// determine which properties were not set. The method can fail to set properties for a number of reasons, including the following:
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
		/// <para>E_INVALIDARG pTableID and ppTableID were both null pointers.</para>
		/// <para>
		/// cColumnDesc was not zero, or rgColumnDescs was a null pointer. cColumnDesc was zero, and the provider does not support creating
		/// tables with no columns.
		/// </para>
		/// <para>cPropertySets was not zero, and rgPropertySets was a null pointer.</para>
		/// <para>In an element of rgPropertySets, cProperties was not zero and rgProperties was a null pointer.</para>
		/// <para>In an element of rgColumnDescs, cPropertySets was not zero and rgPropertySets was a null pointer.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>E_NOINTERFACE The rowset did not support the interface specified in riid.</para>
		/// <para>riid was IID_NULL, and ppRowset was not a null pointer.</para>
		/// <para>DB_E_BADCOLUMNIDdbcid in an element of rgColumnDescs was an invalid column ID.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_E_BADTABLEID *pTableID was an invalid table ID.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_E_BADPRECISION The precision in an element of rgColumnDescs was invalid.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_E_BADSCALE The scale in an element of rgColumnDescs was invalid.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_E_BADTYPE The wType, pwszTypeName, or pTypeInfo element, in an element of rgColumnDescs was invalid.</para>
		/// <para>In an element of rgColumnDescs, pwszTypeName was non-null and implied a DBTYPE other than the type specified by wType.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_E_DUPLICATECOLUMNID dbcid was the same in two or more elements of rgColumnDescs.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_E_DUPLICATETABLEID The specified table already exists in the current data store.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// DB_E_ERRORSOCCURRED The table was not created, and no rowset was returned because one or more properties ? for which the
		/// dwOptions element of the DBPROP structure was DBPROPOPTIONS_REQUIRED or an invalid value ? could not be set. The consumer checks
		/// dwStatus in the DBPROP structures to determine which properties were not set. The method can fail to set properties for any of
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
		/// <para>DB_SEC_E_PERMISSIONDENIED The consumer did not have sufficient permission to create the table.</para>
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
		/// <para>
		/// XACT_E_XTIONEXISTS The provider supports transactional DDL, the session is participating in a transaction, and the value of
		/// DBPROP_SUPPORTEDTXNDDL is DBPROPVAL_TC_DML.
		/// </para>
		/// </description>
		/// </item>
		/// </list>
		/// </returns>
		// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/ms719598(v=vs.85) HRESULT CreateTable( IUnknown *pUnkOuter,
		// DBID *pTableID, DBORDINAL cColumnDescs, const DBCOLUMNDESC rgColumnDescs[], REFIID riid, ULONG cPropertySets, DBPROPSET
		// rgPropertySets[], DBID **ppTableID, IUnknown **ppRowset);
		[PreserveSig]
		new HRESULT CreateTable([In, Optional, MarshalAs(UnmanagedType.IUnknown)] object? pUnkOuter, [In, Optional] IntPtr pTableID,
			DBORDINAL cColumnDescs, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] DBCOLUMNDESC[]? rgColumnDescs,
			in Guid riid, uint cPropertySets, [In] SafeDBPROPSETListHandle rgPropertySets,
			out IntPtr ppTableID, [MarshalAs(UnmanagedType.IUnknown)] out object? ppRowset);

		/// <summary>Drops a base table in the data store.</summary>
		/// <returns>
		/// <list type="bullet">
		/// <item>
		/// <description>
		/// <para>S_OK The method succeeded and the table is dropped.</para>
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
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_E_DROPRESTRICTED The provider could not drop the table because pTableID was referenced in a view definition.</para>
		/// <para>The provider could not drop the table because pTableID was referenced in a constraint belonging to a table other than pTableID.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_E_NOTABLE The specified table does not exist in the current data store.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_E_TABLEINUSE The specified table was in use and could not be dropped.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_SEC_E_PERMISSIONDENIED The consumer did not have sufficient permission to drop the table.</para>
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
		// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/ms713664(v=vs.85) HRESULT DropTable ( DBID *pTableID);
		[PreserveSig]
		new HRESULT DropTable(in DBID pTableID);

		/// <summary>Adds a new column to a base table.</summary>
		/// <param name="pTableID">[in] A pointer to the DBID of the table to which the column is to be added.</param>
		/// <param name="pColumnDesc">
		/// [in/out] A pointer to the DBCOLUMNDESC structure that describes the new column. For more information about the DBCOLUMNDESC
		/// structure, see ITableDefinition::CreateTable.
		/// </param>
		/// <param name="ppColumnID">
		/// <para>
		/// [out] A pointer to memory in which to return the returned DBID of a newly created column. If this is a null pointer, no DBID is
		/// returned. If ppColumnID is non-null, the provider allocates memory for the DBID and overwrites *ppColumnID with a pointer to this
		/// new DBID without regard for its current value.
		/// </para>
		/// <para>
		/// <para>Note</para>
		/// <para>
		/// The contents of *ppColumnID might not exactly match the passed dbcid in *pColumnDesc. The consumer should use *ppColumnID to
		/// identify the newly created column. If ppColumnID is NULL on input and the provider cannot create a column that exactly matches
		/// dbcid in *pColumnDesc, <c>AddColumn</c> should fail with DB_E_BADCOLUMNID.
		/// </para>
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
		/// DB_S_ERRORSOCCURRED The column was added, but one or more properties ? for which the dwOptions element of the DBPROP structure
		/// was DBPROPOPTIONS_OPTIONAL ? were not set. The consumer checks dwStatus in the DBPROP structures to determine which properties
		/// were not set. The method can fail to set properties for a number of reasons, including:
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
		/// <para>E_INVALIDARG pTableID or pColumnDesc was a null pointer.</para>
		/// <para>cPropertySets was not zero, and rgPropertySets was a null pointer in the DBCOLUMNDESC structure.</para>
		/// <para>In an element of rgPropertySets, cProperties was not zero and rgProperties was a null pointer.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_E_BADCOLUMNID dbcid in *pColumnDesc was an invalid column ID.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_E_BADPRECISION The precision in *pColumnDesc was invalid.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_E_BADSCALE The scale in *pColumnDesc was invalid.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_E_BADTYPE The wType, pwszTypeName, or pTypeInfo element, in an element of rgColumnDescs was invalid.</para>
		/// <para>In an element of rgColumnDescs, pwszTypeName was non-null and implied a DBTYPE other than the type specified by wType.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_E_DUPLICATECOLUMNID dbcid in *pColumnDesc was the same as an existing column ID.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// DB_E_ERRORSOCCURRED The column was not added because one or more properties ? for which the dwOptions element of the DBPROP
		/// structure was DBPROPOPTIONS_REQUIRED or an invalid value ? could not be set. The consumer checks dwStatus in the DBPROP
		/// structures to determine which properties were not set. The method can fail to set properties for any of the reasons specified in DB_S_ERRORSOCCURRED.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_E_NOTABLE The specified table does not exist in the current data store.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_E_TABLEINUSE The specified table was in use.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_SEC_E_PERMISSIONDENIED The consumer did not have sufficient permission to add a column.</para>
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
		// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/ms712851(v=vs.85) HRESULT AddColumn( DBID *pTableID,
		// DBCOLUMNDESC *pColumnDesc, DBID **ppColumnID);
		[PreserveSig]
		new HRESULT AddColumn(in DBID pTableID, in DBCOLUMNDESC pColumnDesc, [Optional] out IntPtr ppColumnID);

		/// <summary>Drops a column from the base table.</summary>
		/// <param name="pTableID">[in] A pointer to the DBID of the table from which to drop the column.</param>
		/// <param name="pColumnID">[in] A pointer to the DBID of the column to drop.</param>
		/// <returns>
		/// <list type="bullet">
		/// <item>
		/// <description>
		/// <para>S_OK The method succeeded, and the column was dropped from the base table.</para>
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
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_E_NOCOLUMN The column specified in *pColumnID does not exist in the specified table.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_E_DROPRESTRICTED The provider could not drop the column because pColumnID was referenced in a view definition.</para>
		/// <para>
		/// The provider could not drop the column because pColumnID was referenced in a constraint belonging to a table other than pTableID.
		/// </para>
		/// <para>
		/// The provider could not drop the column because pColumnID was referenced, along with one or more other columns, in a constraint
		/// definition on pTableID.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_E_NOTABLE The specified table does not exist in the current data store.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_E_TABLEINUSE The specified table was in use.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_SEC_E_PERMISSIONDENIED The consumer did not have sufficient permission to drop the column.</para>
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
		// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/ms715924(v=vs.85) HRESULT DropColumn( DBID *pTableID, DBID *pColumnID);
		[PreserveSig]
		new HRESULT DropColumn(in DBID pTableID, in DBID pColumnID);

		/// <summary>Returns creation information for a table.</summary>
		/// <param name="pTableID">[in] A pointer to the ID of the table to describe.</param>
		/// <param name="pcColumnDescs">
		/// [out] A pointer to the number of DBCOLUMNDESC structures in the prgColumnDescs array. If pcColumnDescs is NULL, the provider
		/// ignores prgColumnDescs and does not return any column descriptions.
		/// </param>
		/// <param name="prgColumnDescs">
		/// [out] A pointer to an array of DBCOLUMNDESC structures that describe the columns of the table, or NULL if the consumer is not
		/// interested in getting back column descriptions. For more information on the DBCOLUMNDESC structure, see ITableDefinition::CreateTable.
		/// </param>
		/// <param name="pcPropertySets">
		/// [out] A pointer to the number of DBPROPSET structures in prgPropertySets. If this is NULL, the provider ignores prgPropertySets
		/// and does not return any table creation properties.
		/// </param>
		/// <param name="prgPropertySets">
		/// <para>
		/// [out] A pointer to an array of DBPROPSET structures containing properties and values used in creation of the table, or NULL if
		/// the consumer is not interested in getting back table creation properties. The properties returned in these structures belong to
		/// the Table property group.
		/// </para>
		/// <para>
		/// For information about the properties in the Tables property groups that are defined by OLE DB, see Table Property Group in
		/// Appendix C: OLE DB Properties. For information about the DBPROPSET and DBPROP structures, see DBPROPSET Structure and DBPROP Structure.
		/// </para>
		/// </param>
		/// <param name="pcConstraintDescs">
		/// [out] A pointer to the number of DBCONSTRAINTDESC structures in the prgConstraintDescs array. If this is NULL, the provider
		/// ignores the value of prgConstraintDescs and does not return any column descriptions.
		/// </param>
		/// <param name="prgConstraintDescs">
		/// [out] A pointer to an array of DBCONSTRAINTDESC structures that describe the columns of the table, or NULL if no constraint
		/// definitions are to be returned to the consumer. For more information on DBCONSTRAINTDESC structure, see ITableDefinitionWithConstraints::AddConstraint.
		/// </param>
		/// <param name="ppwszStringBuffer">
		/// [out] A pointer to memory in which to return a pointer to storage for all string values returned in the pwszTypeName element of
		/// DBCOLUMNDESC structure or the pwszConstraintText element of the DBCONSTRAINTDESC structure. The provider allocates this memory
		/// with <c>IMalloc</c>, and the consumer frees it with <c>IMalloc::Free</c> when it no longer needs the descriptions. If
		/// ppwszStringBuffer is a null pointer on input, <c>ITableCreation::GetTableDefinition</c> does not return the string values. If no
		/// shared memory is allocated for pwszTypeName or pwszConstraintText for any elements of prgColumnDescs or prgConstraintDescs,
		/// respectively, or if an error occurs, the provider does not allocate any memory and ensures that *ppwszStringBuffer is a null
		/// pointer on output. Each of the individual string values stored in this buffer is terminated by a null-termination character.
		/// Therefore, the buffer may contain one or more strings, each with its own null-termination character, and may contain embedded
		/// null-termination characters.
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
		/// <para>E_INVALIDARG pTableID was a null pointer.</para>
		/// <para>pcColumnDescs was not null, and prgColumnDescs was a null pointer.</para>
		/// <para>pcPropertySets was not null, and prgPropertySets was a null pointer.</para>
		/// <para>pcConstraintDescs was not null, and prgConstraintDescs was a null pointer.</para>
		/// <para>pcColumnDescs, pcPropertySets, and pcConstraintDescs were all null pointers.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_E_NOTABLE The table specified in pTableID does not exist in the current data source.</para>
		/// </description>
		/// </item>
		/// </list>
		/// </returns>
		// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/ms714993(v=vs.85) HRESULT GetTableDefinition( DBID *pTableID,
		// DBORDINAL *pcColumnDescs, DBCOLUMNDESC *prgColumnDescs[], ULONG *pcPropertySets, DBPROPSET *prgPropertySets[], ULONG
		// *pcConstraintDescs, DBCONSTRAINTDESC *prgConstraintDescs[], OLECHAR **ppwszStringBuffer);
		[PreserveSig]
		new HRESULT GetTableDefinition(in DBID pTableID, out DBORDINAL pcColumnDescs, out SafeIMallocHandle prgColumnDescs, out uint pcPropertySets,
			out SafeDBPROPSETListHandle prgPropertySets, out uint pcConstraintDescs, out SafeIMallocHandle prgConstraintDescs,
			out SafeIMallocHandle ppwszStringBuffer);

		/// <summary>Adds a new constraint to a base table.</summary>
		/// <param name="pTableID">[in] A pointer to the DBID of the table to which the constraint is to be added.</param>
		/// <param name="pConstraintDesc">
		/// <para>[in] A pointer to the DBCONSTRAINTDESC structure that describes the new constraint. DBCONSTRAINTDESC is defined as follows:</para>
		/// <para>The elements of this structure are used as described in the following table.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Element</description>
		/// <description>Description</description>
		/// </listheader>
		/// <item>
		/// <description><c>pConstraintID</c></description>
		/// <description>
		/// The constraint identifier. If this is null, the provider generates a unique ID for the constraint. This ID is not returned to the
		/// consumer through the DBCONSTRAINTDESC structure. Consumers should generally specify a value for the constraint and not set
		/// <c>pConstraintID</c> to null, because there is no easy way to get back the ID for the added constraint.
		/// </description>
		/// </item>
		/// <item>
		/// <description><c>ConstraintType</c></description>
		/// <description>The type of the constraint as defined in the <c>DBCONSTRAINTTYPE</c> enum. One of the following values:</description>
		/// </item>
		/// <item>
		/// <description><c>cColumns</c></description>
		/// <description>
		/// The number of elements in the array passed in <c>rgColumnList</c>. For check constraints, this is always zero. If <c>cColumns</c>
		/// is zero, <c>rgColumnList</c> is ignored.
		/// </description>
		/// </item>
		/// <item>
		/// <description><c>rgColumnList</c></description>
		/// <description>
		/// For unique and primary key constraints, this contains the list of columns that comprise the constraint. For foreign key
		/// constraints, this defines the list of column IDs (DBIDs in the referenced table) that make up the referenced key in a
		/// relationship. The order of the elements in this array comprise the key columns in descending order of significance. As such, the
		/// first element is the most significant key column and the last element in the array is the least significant key column.
		/// </description>
		/// </item>
		/// <item>
		/// <description><c>pReferencedTableID</c></description>
		/// <description>
		/// For foreign keys, this contains the referenced table in a relationship. For all other types of constraints, this is null.
		/// </description>
		/// </item>
		/// <item>
		/// <description><c>cForeignKeyColumns</c></description>
		/// <description>
		/// The number of elements in the array passed in <c>rgForeignKeyColumnList</c>. If <c>cForeignKeyColumns</c> is zero,
		/// <c>rgForeignKeyColumnList</c> is ignored. This field must be zero if <c>pReferencedTableID</c> is a null pointer.
		/// </description>
		/// </item>
		/// <item>
		/// <description><c>rgForeignKeyColumnList</c></description>
		/// <description>
		/// The columns (DBIDs in the base table) that comprise the foreign key in a relationship. The order of the elements in this array
		/// comprise the key columns in descending order of significance. As such, the first element is the most significant key column and
		/// the last element in the array is the least significant key column. This field is ignored if <c>cForeignKeyColumns</c> is zero.
		/// </description>
		/// </item>
		/// <item>
		/// <description><c>pwszConstraintText</c></description>
		/// <description>The constraint clause. If <c>ConstraintType</c> is not DBCONSTRAINTTYPE_CHECK, this must be a null pointer.</description>
		/// </item>
		/// <item>
		/// <description><c>UpdateRule</c></description>
		/// <description>
		/// The update rule (as defined in SQL-92). One of the following values: This field is ignored unless <c>ConstraintType</c> is DBCONSTRAINTTYPE_FOREIGNKEY.
		/// </description>
		/// </item>
		/// <item>
		/// <description><c>DeleteRule</c></description>
		/// <description>
		/// The delete rule (as defined in SQL-92). One of the following values: This field is ignored unless <c>ConstraintType</c> is DBCONSTRAINTTYPE_FOREIGNKEY.
		/// </description>
		/// </item>
		/// <item>
		/// <description><c>MatchType</c></description>
		/// <description>
		/// The match type (as defined in SQL-92). This field is ignored unless <c>ConstraintType</c> is DBCONSTRAINTTYPE_FOREIGNKEY. One of
		/// the following values:
		/// </description>
		/// </item>
		/// <item>
		/// <description><c>Deferrability</c></description>
		/// <description>
		/// A bitmask that describes whether application or checking of the constraint is immediate or deferred. Values are as follows: Not
		/// specifying DBDEFERRABILITY_DEFERRED implies that the constraint is immediate. Not specifying DBDEFERRABILITY_ DEFERRABLE implies
		/// that the constraint is not deferrable. If DBDEFERRABILITY_DEFERRABLE is not specified, the DBDEFERRABILITY_DEFERRED bit is
		/// ignored and the constraint is immediate. If the constraint is immediate, the constraint is applied or checked at the end of each
		/// SQL statement. If the constraint is deferred, the constraint is applied or checked when the constraint is changed to immediate,
		/// either explicitly by command execution or implicitly at the end of the current transaction.
		/// </description>
		/// </item>
		/// <item>
		/// <description><c>cReserved</c></description>
		/// <description>
		/// The number of DBPROPSET structures in <c>rgReserved</c>. If this is zero, the provider ignores <c>rgReserved</c>. This parameter
		/// applies to constraint properties, and consumers should set this element to 0.
		/// </description>
		/// </item>
		/// <item>
		/// <description><c>rgReserved</c></description>
		/// <description>
		/// An array of DBPROPSET structures containing properties and values to be set. If <c>cReserved</c> is zero, this argument is
		/// ignored. This parameter applies to constraint properties, and consumers should set this element to NULL.
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
		/// <para>E_INVALIDARG pTableID or pConstraintDesc was a null pointer.</para>
		/// <para>cForeignKeyColumns was not zero, and rgForeignKeyColumnList was null.</para>
		/// <para>cForeignKeyColumns was not zero and was not equal to cColumns.</para>
		/// <para>cColumns was not zero, and rgColumnList was null.</para>
		/// <para>cReserved was not zero, or rgReserved was not a null pointer.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// DB_E_NOCOLUMN The DBCONSTRAINTDESC structure contained a reference to a column ID, either in rgForeignKeyColumnList, when
		/// rgForeignKeyColumnList is not ignored, or in rgColumnList, and the column was not found. This error can also be returned when the
		/// column referred to by pwszConstraintText does not exist.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_E_BADCONSTRAINTFORM ConstraintType was not DBCONSTRAINTTYPE_FOREIGNKEY, and cForeignKeyColumns was not zero.</para>
		/// <para>ConstraintType was not DBCONSTRAINTTYPE_FOREIGNKEY, and pReferencedTableID was not a null pointer.</para>
		/// <para>ConstraintType was DBCONSTRAINTTYPE_FOREIGNKEY, and pReferencedTableID was NULL.</para>
		/// <para>The type of the constraint was not a check constraint, and pwszConstraintText was not NULL.</para>
		/// <para>ConstraintType wasDBCONSTRAINTTYPE_CHECK, and pwszConstraintText was a null pointer.</para>
		/// <para>ConstraintType was DBCONSTRAINTTYPE_CHECK, and cColumns was not zero.</para>
		/// <para>ConstraintType was DBCONSTRAINTTYPE_FOREIGNKEY, and cForeignKeyColumns was zero.</para>
		/// <para>
		/// ConstraintType was DBCONSTRAINTTYPE_FOREIGNKEY, and the column type of a column in rgForeignKeyColumnList does not match the type
		/// of the corresponding column in rgColumnList.
		/// </para>
		/// <para>
		/// ConstraintType was DBCONSTRAINTTYPE_FOREIGNKEY, DBCONSTRAINTTYPE_PRIMARYKEY, or DBCONSTRAINTTYPE_UNIQUE; and cColumns was zero.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_E_BADCONSTRAINTID pConstraintID was invalid.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_E_BADCONSTRAINTTYPE ConstraintType was invalid or not supported by the provider.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_E_BADDEFERRABILITY Deferrability was invalid, or the value was not supported by the provider.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_E_BADMATCHTYPE MatchType was not ignored and was invalid, or the value was not supported by the provider.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// DB_E_BADUPDATEDELETERULE UpdateRule or DeleteRule was not ignored and was invalid, or the value was not supported by the provider.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_E_DUPLICATECONSTRAINTID pConstraintID was the same as an existing constraint.</para>
		/// <para>ConstraintType was DBCONSTRAINTTYPE_PRIMARYKEY, and the base table already had a primary key.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_E_NOTABLE The table specified by *pTableID does not exist in the data store.</para>
		/// <para>The table specified by *pReferencedTableID in the DBCONSTRAINTDESC structure does not exist.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// DB_E_SCHEMAVIOLATION The type of the constraint conflicted with an attribute (for example, column type) of the referenced column.
		/// </para>
		/// <para>The constraint conflicts with current contents of the table.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_E_TABLEINUSE The specified table was in use, and the provider could not add a constraint as a result.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_SEC_E_PERMISSIONDENIED The consumer did not have sufficient permission to add a constraint.</para>
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
		// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/ms711562(v=vs.85) HRESULT AddConstraint( DBID *pTableID,
		// DBCONSTRAINTDESC *pConstraintDesc);
		[PreserveSig]
		HRESULT AddConstraint(in DBID pTableID, in DBCONSTRAINTDESC pConstraintDesc);

		/// <summary>Creates a new base table in the data store.</summary>
		/// <param name="pUnkOuter">[in] The controlling unknown if the rowset is to be aggregated; otherwise, a null pointer.</param>
		/// <param name="pTableID">
		/// [in] A pointer to the ID of the table to create. If this is a null pointer, the provider must assign a unique ID to the table.
		/// </param>
		/// <param name="cColumnDescs">
		/// [in] The number of DBCOLUMNDESC structures in the rgColumnDescs array. This can be zero if the provider allows the creation of
		/// tables with no columns.
		/// </param>
		/// <param name="rgColumnDescs">
		/// [in/out] An array of DBCOLUMNDESC structures that describe the columns of the table. For more information on the DBCOLUMNDESC
		/// structure, please refer to ITableDefinition::CreateTable.
		/// </param>
		/// <param name="cConstraintDescs">
		/// [in] The number of DBCONSTRAINTDESC structures in the rgConstraintDescs array. If this is zero, rgConstraintDescs is ignored.
		/// </param>
		/// <param name="rgConstraintDescs">
		/// [in] An array of DBCONSTRAINTDESC structures that describe constraints to be created on the table. For more information on this
		/// structure, please refer to ITableDefinitionWithConstraints::AddConstraint.
		/// </param>
		/// <param name="riid">
		/// [in] The IID of the interface to be returned for the resulting rowset; this is ignored if ppRowset is a null pointer.
		/// </param>
		/// <param name="cPropertySets">
		/// [in] The number of DBPROPSET structures in rgPropertySets. If this is zero, the provider ignores rgPropertySets.
		/// </param>
		/// <param name="rgPropertySets">
		/// <para>
		/// [in/out] An array of DBPROPSET structures containing properties and values to be set. The properties specified in these
		/// structures must belong to the Rowset property group (for properties that apply to the rowset returned in *ppRowset) or the Table
		/// property group (for properties that apply to the table). If the same property is specified more than once in rgPropertySets, it
		/// is provider-specific which value is used. If cPropertySets is zero, this argument is ignored.
		/// </para>
		/// <para>
		/// For information about the properties in the Rowset and Tables property groups that are defined by OLE DB, see Rowset Property
		/// Group and Table Property Group in Appendix C. For information about the DBPROPSET and DBPROP structures, see DBPROPSET Structure
		/// and DBPROP Structure.
		/// </para>
		/// </param>
		/// <param name="ppTableID">
		/// [out] A pointer to memory in which to return the DBID of the newly created table. If ppTableID is a null pointer, no DBID is returned.
		/// </param>
		/// <param name="ppRowset">
		/// [out] A pointer to memory in which to return the requested interface pointer on an empty rowset opened on the newly created
		/// table. If ppRowset is a null pointer, no rowset is created.
		/// </param>
		/// <returns>
		/// <list type="bullet">
		/// <item>
		/// <description>
		/// <para>
		/// S_OK The method succeeded, and the table is created and opened. In all DBPROP structures passed to the method, dwStatus is set to DBPROPSTATUS_OK.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// DB_S_ERRORSOCCURRED The table was created and the rowset was opened, but one or more properties ? for which the dwOptions element
		/// of the DBPROP structure was DBPROPOPTIONS_OPTIONAL ? were not set. The consumer checks dwStatus in the DBPROP structures to
		/// determine which properties were not set. The method can fail to set properties for a number of reasons, including the following:
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
		/// <para>E_INVALIDARG pTableID and ppTableID were both null pointers.</para>
		/// <para>
		/// cColumnDesc was not zero, or rgColumnDescs was a null pointer. cColumnDesc was zero, and the provider does not support creating
		/// tables with no columns.
		/// </para>
		/// <para>cPropertySets was not zero, and rgPropertySets was a null pointer.</para>
		/// <para>In an element of rgPropertySets, cProperties was not zero and rgProperties was a null pointer.</para>
		/// <para>In an element of rgColumnDescs, cPropertySets was not zero and rgPropertySets was a null pointer.</para>
		/// <para>cConstraintDescs was not zero, and rgConstraintDescs was a null pointer.</para>
		/// <para>In an element of rgConstraintDescs, cForeignKeyColumns was not zero and rgForeignKeyColumnList was null.</para>
		/// <para>In an element of rgConstraintDescs, cForeignKeyColumns was not zero and was not equal to cColumns.</para>
		/// <para>In an element of rgConstraintDescs, cColumns was not zero and rgColumnList was null.</para>
		/// <para>In an element of rgConstraintDescs, cPropertySets was not zero and rgPropertySets was a null pointer.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_E_BADCOLUMNID dbcid in an element of rgColumnDescs was an invalid column ID.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// DB_E_NOCOLUMN The DBCONSTRAINTDESC structure contained a reference to a column ID, either in rgForeignKeyColumnList, when
		/// rgForeignKeyColumnList is not ignored, or in rgColumnList, and the column was not found.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_E_BADCONSTRAINTFORM ConstraintType was not DBCONSTRAINTTYPE_FOREIGNKEY, and cForeignKeyColumns was not zero.</para>
		/// <para>ConstraintType was not DBCONSTRAINTTYPE_FOREIGNKEY, and pReferencedTableID was not a null pointer.</para>
		/// <para>ConstraintType was DBCONSTRAINTTYPE_FOREIGNKEY, and pReferencedTableID was NULL.</para>
		/// <para>The type of the constraint was not a check constraint, and pwszConstraintText was not NULL.</para>
		/// <para>ConstraintType wasDBCONSTRAINTTYPE_CHECK, and pwszConstraintText was a null pointer.</para>
		/// <para>ConstraintType was DBCONSTRAINTTYPE_CHECK, and cColumns was not zero.</para>
		/// <para>ConstraintType was DBCONSTRAINTTYPE_FOREIGNKEY, and cForeignKeyColumns was zero.</para>
		/// <para>
		/// ConstraintType was DBCONSTRAINTTYPE_FOREIGNKEY, DBCONSTRAINTTYPE_PRIMARYKEY, or DBCONSTRAINTTYPE_UNIQUE and cColumns was zero.
		/// </para>
		/// <para>
		/// In an element of rgColumnDescs, ConstraintType was DBCONSTRAINTTYPE_FOREIGNKEY, and the column type of a column in
		/// rgForeignKeyColumnList does not match the type of the corresponding column in rgColumnList.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_E_BADCONSTRAINTID In an element of rgConstraintDescs, *pConstraintID was invalid.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_E_BADCONSTRAINTTYPE In an element of rgConstraintDescs, ConstraintType was invalid or not supported by the provider.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// DB_E_BADDEFERRABILITY In an element of rgConstraintDescs, Deferrability was invalid or the value was not supported by the provider.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// DB_E_BADMATCHTYPE In an element of rgConstraintDescs, MatchType was not ignored and was invalid or the value was not supported by
		/// the provider.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_E_BADPRECISION The precision in an element of rgColumnDescs was invalid.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_E_BADPROPERTYVALUE The value of a property was invalid.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_E_BADSCALE The scale in an element of rgColumnDescs was invalid.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_E_BADTABLEID *pTableID was an invalid table ID.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_E_BADTYPE One or more of the wType, pwszTypeName, and pTypeInfo elements in an element of rgColumnDescs was invalid.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// DB_E_BADUPDATEDELETERULE In an element of rgConstraintDescs, UpdateRule or DeleteRule was not ignored and was invalid or the
		/// value was not supported by the provider.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_E_DUPLICATECOLUMNID dbcid was the same in two or more elements of rgColumnDescs.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// DB_E_DUPLICATECONSTRAINTID In an element of rgConstraintDescs, the constraint was the same as an existing constraint, or the
		/// constraint ID was the same in two or more elements.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_E_DUPLICATETABLEID The specified table already exists in the data store.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// DB_E_ERRORSOCCURRED The table was not created and no rowset was returned because one or more properties ? for which the dwOptions
		/// element of the DBPROP structure was DBPROPOPTIONS_REQUIRED or an invalid value ? were not set. The consumer checks dwStatus in
		/// the DBPROP structures to determine which properties were not set. None of the satisfiable properties are remembered. The method
		/// can fail to set properties for any of the reasons specified in DB_S_ERRORSOCCURRED, except the reason that states that it was not
		/// possible to set the property.
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
		/// <para>DB_E_NOTABLE In one or more elements of rgConstraintDescs, the table referenced by *pReferencedTableID does not exist.</para>
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
		/// <para>
		/// DB_E_SCHEMAVIOLATION The type of the constraint conflicted with an attribute (for example, column type) of the referenced column.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_SEC_E_PERMISSIONDENIED The consumer did not have sufficient permission to create the table.</para>
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
		// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/ms709819(v=vs.85) HRESULT CreateTableWithConstraints( IUnknown
		// *pUnkOuter, DBID *pTableID, DBORDINAL cColumnDescs, const DBCOLUMNDESC rgColumnDescs[], ULONG cConstraintDescs, DBCONSTRAINTDESC
		// rgConstraintDescs[], REFIID riid, ULONG cPropertySets, DBPROPSET rgPropertySets[], DBID **ppTableID, IUnknown **ppRowset);
		[PreserveSig]
		HRESULT CreateTableWithConstraints([In, Optional, MarshalAs(UnmanagedType.IUnknown)] object? pUnkOuter, [In, Optional] IntPtr pTableID,
			DBORDINAL cColumnDescs, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] DBCOLUMNDESC[] rgColumnDescs, uint cConstraintDescs,
			[In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 4)] DBCONSTRAINTDESC[] rgConstraintDescs, in Guid riid, uint cPropertySets,
			[In] SafeDBPROPSETListHandle rgPropertySets, out DBID ppTableID, [Optional, MarshalAs(UnmanagedType.IUnknown)] out object? ppRowset);

		/// <summary>Drops a constraint from a base table.</summary>
		/// <remarks>
		/// <para><c>Parameters</c></para>
		/// <list type="bullet">
		/// <item>
		/// <description>
		/// <para>pTableID [in] A pointer to the DBID of the table from which to drop the constraint.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>pConstraintID [in] A pointer to the DBID of the constraint to drop.</para>
		/// </description>
		/// </item>
		/// </list>
		/// <para><c>Return Code</c></para>
		/// <list type="bullet">
		/// <item>
		/// <description>
		/// <para>S_OK The method succeeded, and the constraint was dropped from the base table.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>E_FAIL A provider-specific error occurred.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>E_INVALIDARG pTableID or pConstraintID was a null pointer.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_E_BADTABLEID The constraint specified in *pConstraintID does not exist in the table specified in *pTableID.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// DB_E_DROPRESTRICTED The provider could not drop the constraint because there were one or more table constraints dependent on pConstraintID.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_E_NOCONSTRAINT pConstraintID did not exist in the data store.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_E_NOTABLE The specified table does not exist in the data store.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_E_TABLEINUSE The specified table was in use, and the provider could not drop the constraint as a result.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_SEC_E_PERMISSIONDENIED The consumer did not have sufficient permission to drop the constraint.</para>
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
		/// </remarks>
		// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/ms709695(v=vs.85) HRESULT DropConstraint( DBID *pTableID, DBID *pConstraintID);
		[PreserveSig]
		HRESULT DropConstraint(in DBID pTableID, in DBID pConstraintID);
	}

	/// <summary>
	/// <para>
	/// <c>ITransactionJoin</c> is exposed only by providers that support distributed transactions. The consumer calls <c>QueryInterface</c>
	/// for <c>ITransactionJoin</c> to determine whether the provider supports distributed transactions. For more information about
	/// transactions, see Transactions (OLE DB).
	/// </para>
	/// </summary>
	// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/ms718071(v=vs.85)
	[PInvokeData("oledb.h")]
	[ComImport, Guid("0c733a5e-2a1c-11ce-ade5-00aa0044773d"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ITransactionJoin
	{
		/// <summary>Returns an object that can be used to specify configuration options for a subsequent call to <c>ITransactionJoin::JoinTransaction</c>.</summary>
		/// <param name="ppOptions">
		/// [out] A pointer to memory in which to return a pointer to the object that can be used to set extended transaction options.
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
		/// <para>E_FAIL An unknown error occurred.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>E_INVALIDARG ppOptions was a null pointer.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>E_OUTOFMEMORY Unable to allocate memory.</para>
		/// </description>
		/// </item>
		/// </list>
		/// </returns>
		// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/ms714338(v=vs.85) HRESULT GetOptionsObject (
		// ITransactionOptions **ppOptions);
		[PreserveSig]
		HRESULT GetOptionsObject(out ITransactionOptions ppOptions);

		/// <summary>Requests that the session enlist in a coordinated transaction.</summary>
		/// <param name="punkTransactionCoord">
		/// [in] A pointer to the controlling <c>IUnknown</c> of the transaction coordinator, or NULL to unenlist from the coordinated
		/// transaction. If non-null, <c>QueryInterface</c> can be called for <c>ITransaction</c> on the transaction coordinator. If NULL,
		/// the remaining arguments to the method are ignored.
		/// </param>
		/// <param name="isoLevel">[in] The isolation level to be used with this transaction. For more information, see ITransactionLocal::StartTransaction.</param>
		/// <param name="isoFlags">[in] Must be zero.</param>
		/// <param name="pOtherOptions">
		/// [in] Optionally a null pointer. If this is not a null pointer, it is a pointer to an object previously returned from
		/// <c>ITransactionJoin::GetOptionsObject</c> called on this session.
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
		/// DB_E_OBJECTOPEN There were open Commands or Rowsets on the Session object, and the provider requires closing open objects before
		/// changing transaction enlistment.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>E_FAIL An unknown error occurred.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>E_INVALIDARG punkTransactionCoord was a null pointer, and the provider doesn't support unenlisting from a coordinated transaction.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>E_UNEXPECTED An unknown provider-specific error occurred.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>XACT_E_CONNECTION_DOWN The connection to the transaction manager failed.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>XACT_E_CONNECTION_REQUEST_DENIED The transaction manager did not accept a connection request.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// XACT_E_ISOLATIONLEVEL Neither the requested isolation level nor a strengthening of it can be supported by this transaction
		/// implementation, or isoLevel was not valid.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>XACT_E_LOGFULL Unable to begin a new transaction because the log file is full.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>XACT_E_NOENLIST A transaction coordinator was specified, but the new transaction was unable to enlist therein.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// XACT_E_NOISORETAIN The requested semantics of retention of isolation across retaining commit and abort boundaries cannot be
		/// supported by this transaction implementation, or isoFlags was not equal to zero.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>XACT_E_NOTIMEOUT A time-out was specified, but time-outs are not supported.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>XACT_E_TMNOTAVAILABLE Unable to connect to the transaction manager, or the transaction manager is unavailable.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>XACT_E_XTIONEXISTS The enlistment request failed for one of the following reasons:</para>
		/// </description>
		/// </item>
		/// </list>
		/// </returns>
		// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/ms709749(v=vs.85) HRESULT JoinTransaction ( IUnknown
		// *punkTransactionCoord, ISOLEVEL isoLevel, ULONG isoFlags, ITransactionOptions *pOtherOptions);
		[PreserveSig]
		HRESULT JoinTransaction([In, Optional, MarshalAs(UnmanagedType.IUnknown)] object? punkTransactionCoord, ISOLEVEL isoLevel,
			[Optional] uint isoFlags, [In, Optional] ITransactionOptions? pOtherOptions);
	}

	/// <summary>
	/// <c>ITransactionLocal</c> is an optional interface on sessions. It is used to start, commit, and abort transactions on the session.
	/// For more information, see Simple Transactions.
	/// </summary>
	/// <seealso cref="Vanara.PInvoke.OleDb.ITransaction"/>
	// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/ms714893(v=vs.85)
	[PInvokeData("oledb.h")]
	[ComImport, Guid("0c733a5f-2a1c-11ce-ade5-00aa0044773d"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ITransactionLocal : ITransaction
	{
		/// <summary>Commits a transaction.</summary>
		/// <param name="fRetaining">
		/// <para>[in] Whether the commit is retaining or nonretaining.</para>
		/// <para>
		/// <para>Note</para>
		/// <para>
		/// A retaining commit or abort should not change the characteristics (isolation level, isolation flags, transaction options) of the
		/// transaction. The new unit of work retains the same characteristics as the committed work.
		/// </para>
		/// </para>
		/// </param>
		/// <param name="grfTC">
		/// <para>
		/// [in] Values taken from the enumeration XACTTC. Values that may be specified in grfTC are as follows. These values are mutually exclusive.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <description>Flag</description>
		/// <description>Description</description>
		/// </listheader>
		/// <item>
		/// <description>XACTTC_ASYNC_PHASEONE</description>
		/// <description>When this flag is specified, an asynchronous commit is performed.</description>
		/// </item>
		/// <item>
		/// <description>XACTTC_SYNC_PHASEONE</description>
		/// <description>
		/// When this flag is specified, the call to <c>ITransaction::Commit</c> returns after phase one of the two-phase commit protocol.
		/// </description>
		/// </item>
		/// <item>
		/// <description>XACTTC_SYNC_PHASETWO</description>
		/// <description>
		/// When this flag is specified, the call to <c>ITransaction::Commit</c> returns after phase two of the two-phase commit protocol.
		/// </description>
		/// </item>
		/// <item>
		/// <description>XACTTC_SYNC</description>
		/// <description>Synonym for XACTTC_SYNC_PHASETWO.</description>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="grfRM">[in] Must be zero.</param>
		/// <returns>
		/// <list type="bullet">
		/// <item>
		/// <description>
		/// <para>S_OK The transaction was successfully committed.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// XACT_S_ASYNC An asynchronous commit was specified. The commit operation has begun, but its outcome is not yet known. When the
		/// transaction is complete, notification will be sent by <c>ITransactionOutcomeEvents</c>.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>E_FAIL A provider-specific error occurred. The transaction was aborted.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>E_UNEXPECTED An unexpected error occurred. The transaction status is unknown.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>XACT_E_ABORTED The transaction was implicitly aborted before <c>ITransaction::Commit</c> was called.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>XACT_E_ALREADYINPROGRESS A commit or abort operation was already in progress. This call was ignored.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// XACT_E_CANTRETAIN Retaining commit is not supported, or a new unit of work could not be created. The commit succeeded and the
		/// session is in auto-commit mode.
		/// </para>
		/// <para>Commit was called on a distributed transaction with fRetaining set to TRUE.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>XACT_E_COMMITFAILED The transaction failed to commit for an unknown reason. The transaction was aborted.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>XACT_E_CONNECTION_DOWN The connection to the transaction manager failed. The transaction was aborted.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// XACT_E_INDOUBT The transaction status is in doubt. A communication failure occurred, or a transaction manager or resource manager
		/// has failed.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// XACT_E_NOTRANSACTION Unable to commit the transaction because it had already been explicitly committed or aborted. This call was ignored.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// XACT_E_NOTSUPPORTED An invalid combination of commit flags was specified, or grfRM was not equal to zero. This call was ignored.
		/// </para>
		/// </description>
		/// </item>
		/// </list>
		/// </returns>
		// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/ms713008(v=vs.85) HRESULT Commit( BOOL fRetaining, DWORD
		// grfTC, DWORD grfRM);
		[PreserveSig]
		new HRESULT Commit(bool fRetaining, XACTTC grfTC, uint grfRM = 0);

		/// <summary>
		/// <para></para>
		/// <para>
		/// Applies To: Windows 10, Windows 7, Windows 8, Windows 8.1, Windows Server 2008, Windows Server 2008 R2, Windows Server 2012,
		/// Windows Server 2012 R2, Windows Server Technical Preview, Windows Vista
		/// </para>
		/// <para>This method aborts the transaction.</para>
		/// </summary>
		/// <param name="pboidReason">
		/// [in] An optional BOID that indicates why the transaction is being aborted. This argument may be NULL indicating that no abort
		/// reason is provided.
		/// </param>
		/// <param name="fRetaining">[in] Must be FALSE.</param>
		/// <param name="fAsync">
		/// [in] When fAsync is TRUE, an asynchronous abort is performed and the caller must use <c>ITransactionOutcomeEvents</c> to learn
		/// the outcome of the transaction.
		/// </param>
		/// <returns></returns>
		/// <remarks>
		/// <para>The initiator of the transaction may abort the transaction as may any resource manager enlisted on the transaction.</para>
		/// <para>
		/// <c>Abort</c> may be invoked on a transaction repeatedly. XACT_S_ABORTING HRESULT will be returned following the first invocation
		/// of <c>Abort</c>.
		/// </para>
		/// <para>If a communication failure occurs during a call to <c>Commit</c> or <c>Abort</c>, the status of the transaction is unknown.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/ms688267(v=vs.85) HRESULT Abort( BOID * pboidReason, BOOL
		// fRetaining, BOOL fAsync);
		[PreserveSig]
		new HRESULT Abort([In, Optional] IntPtr pboidReason, bool fRetaining, bool fAsync);

		/// <summary>Returns information regarding a transaction.</summary>
		/// <param name="pInfo">
		/// <para>
		/// [out] A pointer to the caller-allocated XACTTRANSINFO structure in which the method returns information about the transaction.
		/// pInfo must not be a null pointer.
		/// </para>
		/// <para>The elements of this structure are used as described in the following table.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Element</description>
		/// <description>Description</description>
		/// </listheader>
		/// <item>
		/// <description><c>uow</c></description>
		/// <description>The unit of work associated with this transaction. Cannot be NULL and must be unique per transaction.</description>
		/// </item>
		/// <item>
		/// <description><c>isoLevel</c></description>
		/// <description>
		/// The isolation level associated with this transaction. ISOLATIONLEVEL_UNSPECIFIED indicates that no isolation level was specified.
		/// For more information, see ITransactionLocal::StartTransaction.
		/// </description>
		/// </item>
		/// <item>
		/// <description><c>isoFlags</c></description>
		/// <description>Will be zero.</description>
		/// </item>
		/// <item>
		/// <description><c>grfTCSupported</c></description>
		/// <description>This bitmask indicates the XACTTC flags that this transaction implementation supports.</description>
		/// </item>
		/// <item>
		/// <description><c>grfRMSupported</c></description>
		/// <description>Will be zero.</description>
		/// </item>
		/// <item>
		/// <description><c>grfTCSupportedRetaining</c></description>
		/// <description>Will be zero.</description>
		/// </item>
		/// <item>
		/// <description><c>grfRMSupportedRetaining</c></description>
		/// <description>Will be zero.</description>
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
		/// <para>E_INVALIDARG pInfo was a null pointer.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>E_UNEXPECTED An unknown error occurred. No information is returned.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// XACT_E_NOTRANSACTION Unable to retrieve information for the transaction because it was already completed. No information is returned.
		/// </para>
		/// </description>
		/// </item>
		/// </list>
		/// </returns>
		// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/ms714975(v=vs.85) HRESULT GetTransactionInfo( XACTTRANSINFO *pInfo);
		[PreserveSig]
		new HRESULT GetTransactionInfo(out XACTTRANSINFO pInfo);

		/// <summary>Returns an object that can be used to specify configuration options for a subsequent call to <c>ITransactionLocal::StartTransaction</c>.</summary>
		/// <param name="ppOptions">
		/// [out] A pointer to memory in which to return a pointer to the object that can be used to set extended transaction options.
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
		/// DB_E_NOTSUPPORTED The provider does not support ITransactionOptions. A call to <c>ITransactionLocal::GetOptionsObject</c> should
		/// return DB_E_NOTSUPPORTED for 2.6-compliant providers and later. For earlier providers, the return code is unspecified.
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
		/// <para>E_INVALIDARG ppOptions was a null pointer.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>E_OUTOFMEMORY Unable to allocate memory.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>E_UNEXPECTED An unknown error occurred, and the method failed.</para>
		/// </description>
		/// </item>
		/// </list>
		/// </returns>
		// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/ms713719(v=vs.85) HRESULT GetOptionsObject (
		// ITransactionOptions **ppOptions);
		[PreserveSig]
		HRESULT GetOptionsObject(out ITransactionOptions ppOptions);

		/// <summary>Begins a new transaction.</summary>
		/// <param name="isoLevel">
		/// <para>[in] The isolation level to be used with this transaction. For more information, see Isolation Levels in OLE DB.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Value</description>
		/// <description>Description</description>
		/// </listheader>
		/// <item>
		/// <description>ISOLATIONLEVEL_UNSPECIFIED</description>
		/// <description>
		/// Applicable only to ITransactionJoin::JoinTransaction. Invalid for <c>ITransactionLocal</c> or for setting isolation level while
		/// in auto-commit mode.
		/// </description>
		/// </item>
		/// <item>
		/// <description>ISOLATIONLEVEL_CHAOS</description>
		/// <description>Cannot overwrite the dirty data of other transactions at higher isolation levels.</description>
		/// </item>
		/// <item>
		/// <description>ISOLATIONLEVEL_READUNCOMMITTED</description>
		/// <description>Read Uncommitted.</description>
		/// </item>
		/// <item>
		/// <description>ISOLATIONLEVEL_BROWSE</description>
		/// <description>Synonym for ISOLATIONLEVEL_READUNCOMMITTED.</description>
		/// </item>
		/// <item>
		/// <description>ISOLATIONLEVEL_READCOMMITTED</description>
		/// <description>Read Committed.</description>
		/// </item>
		/// <item>
		/// <description>ISOLATIONLEVEL_CURSORSTABILITY</description>
		/// <description>Synonym for ISOLATIONLEVEL_READCOMMITTED.</description>
		/// </item>
		/// <item>
		/// <description>ISOLATIONLEVEL_REPEATABLEREAD</description>
		/// <description>Repeatable Read.</description>
		/// </item>
		/// <item>
		/// <description>ISOLATIONLEVEL_SERIALIZABLE</description>
		/// <description>Serializable.</description>
		/// </item>
		/// <item>
		/// <description>ISOLATIONLEVEL_ISOLATED</description>
		/// <description>Synonym for ISOLATIONLEVEL_SERIALIZABLE.</description>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="isoFlags">[in] Must be zero.</param>
		/// <param name="pOtherOptions">
		/// [in] Optionally a null pointer. If this is not a null pointer, it is a pointer to an object previously returned from
		/// ITransactionLocal::GetOptionsObject called on this session instance.
		/// </param>
		/// <param name="pulTransactionLevel">
		/// [out] A pointer to memory in which to return the level of the new transaction. The value of the top-level transaction is 1. If
		/// pulTransactionLevel is a null pointer, the level is not returned.
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
		/// DB_E_OBJECTOPEN A rowset object was open, and the provider does not support starting a new transaction with existing open rowset objects.
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
		/// <para>E_UNEXPECTED An unknown error occurred, and the method failed.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// XACT_E_CONNECTION_DENIED This session could not create a new transaction at the present time due to unspecified capacity issues.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>XACT_E_CONNECTION_DOWN This session is having communication difficulties with its internal implementation.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// XACT_E_ISOLATIONLEVEL Neither the requested isolation level nor a strengthening of it can be supported by this transaction
		/// implementation, or isoLevel was not valid.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// XACT_E_LOGFULL A transaction could not be created because this session specifies logging to a device that lacks available space.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// XACT_E_NOISORETAIN The requested semantics of retention of isolation across retaining commit and abort boundaries cannot be
		/// supported by this transaction implementation, or isoFlags was not equal to zero.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>XACT_E_NOTIMEOUT A noninfinite time-out value was requested, but time-outs are not supported by this transaction.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>XACT_E_XTIONEXISTS This session can handle only one extant transaction at a time, and there is presently such a transaction.</para>
		/// <para>The session supports a limited number of nested transactions, and that limit has been reached.</para>
		/// </description>
		/// </item>
		/// </list>
		/// </returns>
		// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/ms709786(v=vs.85) HRESULT StartTransaction ( ISOLEVEL
		// isoLevel, ULONG isoFlags, ITransactionOptions *pOtherOptions, ULONG *pulTransactionLevel);
		[PreserveSig]
		HRESULT StartTransaction(ISOLEVEL isoLevel, [Optional] ISOFLAG isoFlags, [In, Optional] ITransactionOptions? pOtherOptions, out uint pulTransactionLevel);
	}

	/// <summary>
	/// <c>ITransactionObject</c> enables consumers to obtain the transaction object associated with a particular transaction level. For more
	/// information, see ITransaction Object.
	/// </summary>
	// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/ms713659(v=vs.85)
	[PInvokeData("oledb.h")]
	[ComImport, Guid("0c733a60-2a1c-11ce-ade5-00aa0044773d"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ITransactionObject
	{
		/// <summary>Returns an interface pointer on the transaction object.</summary>
		/// <param name="ulTransactionLevel">[in] The level of the transaction.</param>
		/// <param name="ppTransactionObject">[out] A pointer to memory in which to return a pointer to the returned transaction object.</param>
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
		/// <para>E_INVALIDARG ulTransactionLevel was zero, or ppTransactionObject was a null pointer.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>E_UNEXPECTED An unknown error occurred, and the method failed.</para>
		/// </description>
		/// </item>
		/// </list>
		/// </returns>
		// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/ms712995(v=vs.85) HRESULT GetTransactionObject ( ULONG
		// ulTransactionLevel, ITransaction **ppTransactionObject);
		[PreserveSig]
		HRESULT GetTransactionObject(uint ulTransactionLevel, out ITransaction? ppTransactionObject);
	}

	/// <summary><c>IViewChapter</c> enables the consumer to create or apply a view to an existing rowset.</summary>
	// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/ms724248(v=vs.85)
	[PInvokeData("oledb.h")]
	[ComImport, Guid("0c733a98-2a1c-11ce-ade5-00aa0044773d"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IViewChapter
	{
		/// <summary>Returns the rowset from which the view was created.</summary>
		/// <param name="riid">[in] The IID of the interface on which to return a pointer.</param>
		/// <param name="ppRowset">
		/// [out] A pointer to memory in which to return the interface pointer. If <c>IViewChapter::GetSpecification</c> fails, it must
		/// attempt to set *ppRowset to a null pointer.
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
		/// <para>E_NOINTERFACE The view did not support the interface specified in riid.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>E_OUTOFMEMORY The provider was unable to allocate sufficient memory in which to return the rowset information.</para>
		/// </description>
		/// </item>
		/// </list>
		/// </returns>
		// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/ms716976(v=vs.85) HRESULT GetSpecification ( REFIID riid,
		// IUnknown **ppRowset);
		[PreserveSig]
		HRESULT GetSpecification(in Guid riid, [MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 0)] out object? ppRowset);

		/// <summary>Returns a chapter for the rows meeting the specified view conditions.</summary>
		/// <param name="hSource">
		/// [in] A chapter defining the set of rows on which to apply the view. To apply a view to the root rowset, the consumer must use DB_NULL_HCHAPTER.
		/// </param>
		/// <param name="phViewChapter">
		/// [out] A chapter reflecting the specified view conditions, or NULL to indicate that the view conditions should be applied to hSource.
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
		/// <para>DB_E_BADCHAPTER hSource was invalid.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// DB_E_CANTFILTER The described filter could not be opened. The provider may have limitations on the columns used in a filter or a
		/// limitation on the complexity of the filter.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// DB_E_CANTORDER The described order could not be opened. The provider may have limitations on the columns used in an order or a
		/// limitation on the complexity of the order.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_E_BADCOMPAREOP A specified comparison operator was invalid.</para>
		/// </description>
		/// </item>
		/// </list>
		/// </returns>
		// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/ms716852(v=vs.85) HRESULT OpenViewChapter ( HCHAPTER hSource,
		// HCHAPTER *phViewChapter);
		[PreserveSig]
		HRESULT OpenViewChapter([In] HCHAPTER hSource, [Optional] IntPtr phViewChapter);
	}

	/// <summary><c>IViewFilter</c> enables consumers to restrict the contents of a rowset to rows matching a set of conditions.</summary>
	// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/ms722601(v=vs.85)
	[PInvokeData("oledb.h")]
	[ComImport, Guid("0c733a9b-2a1c-11ce-ade5-00aa0044773d"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IViewFilter
	{
		/// <summary>Retrieves the filter applied to a view.</summary>
		/// <param name="hAccessor">
		/// [in] A row data accessor describing the data to be written to ppCriteriaData. The same column may appear more than one time in
		/// the criteria.
		/// </param>
		/// <param name="pcRows">
		/// [out] A pointer to memory in which to write the number of rows in the criteria table, where the criteria described by each row is
		/// joined in a logical <c>OR</c> with the other rows. If pcRows is greater than one, the cbRowSize argument used in the call to
		/// <c>IAccessor::CreateAccessor</c> is used to specify the offset between each set of row values.
		/// </param>
		/// <param name="pCompareOps">
		/// <para>
		/// [out] A pointer to memory in which to write a two-dimensional array of comparisons operators. The two-dimensional array contains
		/// pcRows by cBindings comparison operators in pcRows-major format, where cBindings is the number of columns represented in
		/// hAccessor, and is written in row-major format. Each comparison operator in the cBindings dimension refers to a column in
		/// pCriteriaData, and each set of columns in the pcRows dimension refers to a row in pCriteriaData. Columns within a row are joined
		/// together in a logical <c>AND</c>, and each row is joined in a logical <c>OR</c> with another row. For information about the
		/// DBCOMPAREOP enumerated type, see IRowsetFind::FindNextRow.
		/// </para>
		/// <para>
		/// <para>Note</para>
		/// <para>
		/// If the consumer set the filter using <c>IViewFilter::SetFilter</c>, it knows the maximum size of the comparison operator array
		/// and can allocate memory for it accordingly. If the consumer was passed the view, it needs to allocate sufficiently large buffers
		/// to hold these arrays.
		/// </para>
		/// </para>
		/// </param>
		/// <param name="pCriteriaData">
		/// <para>[out] A pointer to a buffer in which to return the criteria data.</para>
		/// <para>
		/// <para>Note</para>
		/// <para>
		/// If the consumer set the filter using <c>IViewFilter::SetFilter</c>, it knows the maximum size of the criteria data array and can
		/// allocate memory for it accordingly. If the consumer was passed the view, it needs to allocate sufficiently large buffers to hold
		/// these arrays.
		/// </para>
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
		/// <para>E_OUTOFMEMORY The provider was unable to allocate sufficient memory in which to return the filter information.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_E_BADACCESSORHANDLE hAccessor was invalid. Providers are required to check for this condition in this method.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_E_BADACCESSORTYPE The specified accessor was not a row accessor.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_E_BADCOMPAREOP In an element of pCompareOps, both DBCOMPAREOPS_CASESENSITIVE and DBCOMPAREOPS_CASEINSENSITIVE were specified.</para>
		/// <para>The provider was asked for an option that it does not support.</para>
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
		// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/ms709726(v=vs.85) HRESULT GetFilter ( HACCESSOR hAccessor,
		// DBCOUNTITEM *pcRows, DBCOMPAREOP *pCompareOps[], void *pCriteriaData);
		[PreserveSig]
		HRESULT GetFilter(HACCESSOR hAccessor, out DBCOUNTITEM pcRows, [Out, MarshalAs(UnmanagedType.LPArray)] DBCOMPAREOPS[,] pCompareOps, [Out] IntPtr pCriteriaData);

		/// <summary>Retrieves the bindings used to describe the filter conditions associated with a view.</summary>
		/// <param name="pcBindings">
		/// [out] A pointer to memory in which to return the number of bindings used to describe the filter criteria. If this method fails or
		/// if no filter has been applied to the view, *pcBindings is set to zero.
		/// </param>
		/// <param name="prgBindings">
		/// [out] A pointer to memory in which to return an array of DBBINDING structures. One structure is returned for each binding used to
		/// describe the filter criteria. The provider allocates memory for the structures and returns the address to this memory; the
		/// consumer releases this memory with <c>IMalloc::Free</c> when it no longer needs the bindings. If *pcBindings is zero on output or
		/// the method fails, the provider does not allocate any memory and ensures that *prgBindings is a null pointer on output. For
		/// information about bindings, see DBBINDING Structures.
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
		/// <para>E_INVALIDARG pcBindings or prgBindings was a null pointer.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>E_OUTOFMEMORY The provider was unable to allocate sufficient memory in which to return the binding structures.</para>
		/// </description>
		/// </item>
		/// </list>
		/// </returns>
		// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/ms723078(v=vs.85) HRESULT GetFilterBindings( DBCOUNTITEM
		// *pcBindings, DBBINDING **prgBindings);
		[PreserveSig]
		HRESULT GetFilterBindings(out DBCOUNTITEM pcBindings, out SafeIMallocHandle prgBindings);

		/// <summary>Specifies a filter condition for a view.</summary>
		/// <param name="hAccessor">
		/// [in] The handle of the accessor that describes the data in pCriteriaData. The same column may appear more than once in the criteria.
		/// </param>
		/// <param name="cRows">
		/// [in] The number of rows in the criteria table, where the criteria described by each row is joined in a logical OR with the other
		/// rows. Some providers may have limits on the number of rows (OR conditions) that can be expressed in the criteria.
		/// </param>
		/// <param name="CompareOps">
		/// <para>
		/// [in] A two-dimensional array containing cRows by cBindings comparison operators in cRows-major format, where cBindings is the
		/// number of columns represented in hAccessor. Each comparison operator in the cBindings dimension refers to a column in
		/// pCriteriaData, and each set of columns in the pcRows dimension refers to a row in pCriteriaData. Columns within a row are joined
		/// together in a logical AND, and each row is joined in a logical OR with another row. The consumer should check
		/// DBPROP_FINDCOMPAREOPS to determine which comparison operators the provider supports. For information about the DBCOMPAREOP
		/// enumerated type, see IRowsetFind::FindNextRow.
		/// </para>
		/// <para>
		/// <para>Note</para>
		/// <para>The expression column DBCOMPAREOPS_IGNORE value always resolves to TRUE when used with the <c>IViewFilter::SetFilter</c>.</para>
		/// </para>
		/// </param>
		/// <param name="pCriteriaData">
		/// [in] A pointer to memory containing the data values, at offsets that correspond to the bindings in the accessor that, in
		/// conjunction with the array of comparison operators, define the criteria.
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
		/// <para>DB_E_BADCOMPAREOP In an element of CompareOps, both DBCOMPAREOPS_CASESENSITIVE and DBCOMPAREOPS_CASEINSENSITIVE were specified.</para>
		/// <para>The provider was asked for an option that it does not support.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// DB_E_CANTFILTER The described filter could not be applied. The provider may have limitations on the columns used in a filter or a
		/// limitation on the complexity of the filter.
		/// </para>
		/// </description>
		/// </item>
		/// </list>
		/// </returns>
		// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/ms719693(v=vs.85) HRESULT SetFilter ( HACCESSOR hAccessor,
		// DBCOUNTITEM cRows, DBCOMPAREOP CompareOps[], void *pCriteriaData);
		[PreserveSig]
		HRESULT SetFilter([In] HACCESSOR hAccessor, DBCOUNTITEM cRows, [In, MarshalAs(UnmanagedType.LPArray)] DBCOMPAREOPS[] CompareOps, [In] IntPtr pCriteriaData);
	}

	/// <summary><c>IViewRowset</c> enables the consumer to create or apply view operations when opening a rowset.</summary>
	// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/ms713657(v=vs.85)
	[PInvokeData("oledb.h")]
	[ComImport, Guid("0c733a97-2a1c-11ce-ade5-00aa0044773d"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IViewRowset
	{
		/// <summary>Returns the object from which the view was created.</summary>
		/// <param name="riid">
		/// [in] The IID of the interface to be returned. This interface is conceptually added to the list of required interfaces on the
		/// resulting rowset, and the method fails (E_NOINTERFACE) if that interface cannot be supported on the resulting rowset.
		/// </param>
		/// <param name="ppObject">
		/// [out] A pointer to memory in which to return the interface pointer. If <c>IViewRowset::GetSpecification</c> fails, it must
		/// attempt to set *ppObject to a null pointer.
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
		/// <para>E_NOINTERFACE The view did not support the interface specified in riid.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>E_OUTOFMEMORY The provider was unable to allocate sufficient memory in which to return the object information.</para>
		/// </description>
		/// </item>
		/// </list>
		/// </returns>
		// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/ms716967(v=vs.85) HRESULT GetSpecification ( REFIID riid,
		// IUnknown **ppObject);
		[PreserveSig]
		HRESULT GetSpecification(in Guid riid, [MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 0)] out object? ppObject);

		/// <summary>Creates a rowset from a view.</summary>
		/// <param name="pUnkOuter">
		/// [in] A pointer to the controlling <c>IUnknown</c> interface if the new rowset is being created as part of an aggregate. It is a
		/// null pointer if the rowset is not part of an aggregate.
		/// </param>
		/// <param name="riid">[in] The IID of the interface requested on the rowset.</param>
		/// <param name="ppRowset">
		/// [out] A pointer to memory in which to return the interface pointer on the newly created rowset. If
		/// <c>IViewRowset::OpenViewRowset</c> fails, *ppRowset is set to a null pointer.
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
		/// <para>E_INVALIDARG ppRowset was a null pointer.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>E_NOINTERFACE The rowset did not support the interface specified in riid.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>E_OUTOFMEMORY The provider did not have enough memory to create the rowset.</para>
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
		/// </list>
		/// </returns>
		// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/ms723079(v=vs.85) HRESULT OpenViewRowset ( IUnknown
		// *pUnkOuter, REFIID riid, IUnknown **ppRowset);
		[PreserveSig]
		HRESULT OpenViewRowset([In, Optional, MarshalAs(UnmanagedType.IUnknown)] object? pUnkOuter, in Guid riid, [MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 1)] out object? ppRowset);
	}

	/// <summary><c>IViewSort</c> enables the consumer to apply a sort order to a view.</summary>
	// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/ms714371(v=vs.85)
	[PInvokeData("oledb.h")]
	[ComImport, Guid("0c733a9a-2a1c-11ce-ade5-00aa0044773d"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IViewSort
	{
		/// <summary>Retrieves the sort order applied to a view.</summary>
		/// <param name="pcColumns">[out] Count of the number of columns in the sort order.</param>
		/// <param name="prgColumns">
		/// [out] The ordinals of the columns used to describe the sort. The order of the columns in the list defines the precedence of the
		/// columns in the sort.
		/// </param>
		/// <param name="prgOrders">[out] The sort order for the corresponding column in the prgColumns list.</param>
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
		/// <para>E_INVALIDARG pcColumns, prgColumns, or prgOrders was NULL.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>E_OUTOFMEMORY The provider was unable to allocate sufficient memory in which to return the sort information.</para>
		/// </description>
		/// </item>
		/// </list>
		/// </returns>
		// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/ms722756(v=vs.85) HRESULT GetSortOrder ( DBORDINAL *pcColumns,
		// DBORDINAL *prgColumns[], DBSORT *prgOrders[]);
		[PreserveSig]
		HRESULT GetSortOrder(out DBORDINAL pcColumns, out SafeIMallocHandle prgColumns, out SafeIMallocHandle prgOrders);

		/// <summary>Specifies a sort order to be applied to a view.</summary>
		/// <param name="cColumns">
		/// [in] Count of the number of columns to be used in specifying the order, or zero to clear any sort order previously set on the view.
		/// </param>
		/// <param name="rgColumns">
		/// [in] The ordinals of the columns used to describe the sort. The order of the columns in the list defines the precedence of the
		/// columns in the sort. This argument is ignored if cColumns is zero.
		/// </param>
		/// <param name="rgOrders">
		/// <para>[in] The sort order for the corresponding column in the rgColumns list. This argument is ignored if cColumns is zero.</para>
		/// <para>The DBSORT structure is as follows:</para>
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
		/// <para>E_INVALIDARG rgColumns was NULL, and cColumns was not equal to zero.</para>
		/// <para>rgOrders was NULL, and cColumns was not equal to zero.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// DB_E_CANTORDER The described order could not be opened. The provider may have limitations on the columns used in an order or a
		/// limitation on the complexity of the order.
		/// </para>
		/// <para>The same column ordinal appeared multiple times in rgColumns.</para>
		/// </description>
		/// </item>
		/// </list>
		/// </returns>
		// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/ms722623(v=vs.85) HRESULT SetSortOrder ( DBORDINAL cColumns,
		// const DBORDINAL rgColumns[], const DBSORT rgOrders[]);
		[PreserveSig]
		HRESULT SetSortOrder(DBORDINAL cColumns, [In, MarshalAs(UnmanagedType.LPArray)] DBORDINAL[]? rgColumns, [In, MarshalAs(UnmanagedType.LPArray)] DBSORT[]? rgOrders);
	}

	/// <summary>Creates a new base table in the data store.</summary>
	/// <typeparam name="T">The type of the rowset interface to return.</typeparam>
	/// <param name="td">The <see cref="ITableDefinition"/> instance.</param>
	/// <param name="pUnkOuter">[in] The controlling unknown if the rowset is to be aggregated; otherwise, a null pointer.</param>
	/// <param name="pTableID">
	/// [in] A pointer to the ID of the table to create. If this is a null pointer, the provider must assign a unique ID to the table.
	/// </param>
	/// <param name="rgColumnDescs">
	/// <para>[in/out] An array of DBCOLUMNDESC structures that describe the columns of the table.</para>
	/// <para>
	/// The elements of this structure are used as follows. The consumer decides the values to use in the nonproperties elements of this
	/// structure based on values from the PROVIDER_TYPES schema rowset.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <description>Element</description>
	/// <description>Description</description>
	/// </listheader>
	/// <item>
	/// <description><c>pwszTypeName</c></description>
	/// <description>
	/// The provider-specific name of the data type of the column. This name corresponds to a value in the TYPE_NAME column in the
	/// PROVIDER_TYPES schema rowset. In most cases, there is no reason for a consumer to specify a value for <c>pwszTypeName</c> that is
	/// different from the values listed in the PROVIDER_TYPES schema rowset. If <c>pwszTypeName</c> is NULL, the provider determines the
	/// type of the column based upon <c>wType</c> and <c>ulColumnSize</c>, as well as any column properties, such as DBPROP_COL_ISLONG and
	/// DBPROP_COL_FIXEDLENGTH, passed in <c>rgPropertySets</c>. There may be some types that can only be created by specifying the name in
	/// <c>pwszTypeName</c> because they cannot be unambiguously determined based on the <c>wType</c>, <c>ulColumnSize</c>, and property
	/// values specified.
	/// </description>
	/// </item>
	/// <item>
	/// <description><c>pTypeInfo</c></description>
	/// <description>
	/// If <c>pTypeInfo</c> is not a null pointer, the data type of the column is an abstract data type (ADT) and values in this column are
	/// actually instances of the type described by the type library. <c>wType</c> may be either DBTYPE_BYTES, with a length of at least 4,
	/// or DBTYPE_IUNKNOWN. The instance values are required to be COM objects derived from <c>IUnknown</c>.
	/// </description>
	/// </item>
	/// <item>
	/// <description><c>rgPropertySets</c></description>
	/// <description>
	/// An array of DBPROPSET structures containing properties and values to be set. The properties specified in these structures must belong
	/// to the Column property group. All properties specified in <c>rgPropertySets</c> for this element of <c>rgColumnDescs</c> apply to the
	/// column specified by <c>dbcid</c>; the <c>colid</c> element in the DBPROP structure for specified properties is ignored. If the same
	/// property is specified more than once in <c>rgPropertySets</c>, it is provider-specific which value is used. If <c>cPropertySets</c>
	/// is zero, this argument is ignored. For information about the properties in the Column property group that are defined by OLE DB, see
	/// "Column Property Group" in Appendix C. For information about the DBPROPSET and DBPROP structures, see DBPROPSET Structure and DBPROP Structure.
	/// </description>
	/// </item>
	/// <item>
	/// <description><c>pclsid</c></description>
	/// <description>
	/// If the column contains COM objects, a pointer to the class ID of those objects. If more than one class of objects can reside in the
	/// column, * <c>pclsid</c> is set to IID_NULL. If the column does not contain COM objects, this is ignored and <c>pclsid</c> should be a
	/// null pointer.
	/// </description>
	/// </item>
	/// <item>
	/// <description><c>cPropertySets</c></description>
	/// <description>The number of DBPROPSET structures in <c>rgPropertySets</c>. If this is zero, the provider ignores <c>rgPropertySets</c>.</description>
	/// </item>
	/// <item>
	/// <description><c>ulColumnSize</c></description>
	/// <description>
	/// The maximum length in characters for values in this column if <c>wType</c> is DBTYPE_STR or DBTYPE_WSTR, or in bytes if <c>wType</c>
	/// is DBTYPE_BYTES. If <c>ulColumnSize</c> is zero and a default maximum column length is defined, the provider creates a column of that
	/// length. If no default is defined, the length of the created column is provider-specific. For all other values of <c>wType</c>,
	/// <c>ulColumnSize</c> is ignored. Providers that do not require a length argument in the specification of the provider type (
	/// <c>pwszTypeName</c>) ignore this element.
	/// </description>
	/// </item>
	/// <item>
	/// <description><c>dbcid</c></description>
	/// <description>The column ID of the column.</description>
	/// </item>
	/// <item>
	/// <description><c>wType</c></description>
	/// <description>
	/// The type indicator for the data type of the column. This name corresponds to a value in the DATA_TYPE column in the PROVIDER_TYPES
	/// schema rowset. In most cases, there is no reason for a consumer to specify a value for <c>wType</c> that is different from the values
	/// listed in the PROVIDER_TYPES schema rowset.
	/// </description>
	/// </item>
	/// <item>
	/// <description><c>bPrecision</c></description>
	/// <description>
	/// The maximum precision of data values in the column when <c>wType</c> is the indicator for DBTYPE_NUMERIC or DBTYPE_VARNUMERIC; it is
	/// ignored for all other data types. This must be within the limits specified for the type in the COLUMN_SIZE column in the
	/// PROVIDER_TYPES schema rowset. For information about the precision of numeric data types, see Precision of Numeric Data Types in
	/// Appendix A.
	/// </description>
	/// </item>
	/// <item>
	/// <description><c>bScale</c></description>
	/// <description>
	/// The scale of data values in the column when <c>wType</c> is DBTYPE_NUMERIC, DBTYPE_VARNUMERIC, or DBTYPE_DECIMAL; it is ignored for
	/// all other data types. This must be within the limits specified for the type in the MINIMUM_SCALE and MAXIMUM_SCALE columns in the
	/// PROVIDER_TYPES schema rowset.
	/// </description>
	/// </item>
	/// </list>
	/// <para>
	/// <para>Note</para>
	/// <para>
	/// The provider does not modify any elements of the DBCOLUMNDESC structures. However, upon a return code of S_OK, DB_S_ERRORSOCCURRED,
	/// or DB_E_ERRORSOCCURRED, the dwStatus element in the DBPROP structure for each column property indicates whether or not that column
	/// property was set (DBPROPSTATUS_OK).
	/// </para>
	/// </para>
	/// </param>
	/// <param name="rgPropertySets">
	/// <para>
	/// [in/out] An array of DBPROPSET structures containing properties and values to be set. The properties specified in these structures
	/// must belong to the Rowset property group (for properties that apply to the rowset returned in *ppRowset) or the Table property group
	/// (for properties that apply to the table). If the same property is specified more than once in rgPropertySets, it is provider-specific
	/// which value is used. If cPropertySets is zero, this argument is ignored.
	/// </para>
	/// <para>
	/// <para>Note</para>
	/// <para>
	/// The colid element of every DBPROP structure passed to the method must be set either to a valid DBID value or to DB_NULLID. For rowset
	/// properties, the colid element of the DBPROP structure must be set either to the ID of the rowset column to which the property applies
	/// or to DB_NULLID if the property applies to the entire rowset. For table properties, the property applies to the entire table and
	/// therefore the colid element of the DBPROP structure must be set to DB_NULLID.
	/// </para>
	/// <para>
	/// For information about the properties in the Rowset and Tables property groups that are defined by OLE DB, see Rowset Property Group
	/// and Table Property Group in Appendix C. For information about the DBPROPSET and DBPROP structures, see DBPROPSET Structure and DBPROP Structure.
	/// </para>
	/// </para>
	/// </param>
	/// <param name="ppTableID">
	/// <para>
	/// [out] A pointer to memory in which to return the DBID of the newly created table. If ppTableID is a null pointer, no DBID is returned.
	/// </para>
	/// <para>
	/// <para>Note</para>
	/// <para>
	/// The contents of *ppTableID might not exactly match the passed pTableID. (For example, it might contain additional version or other
	/// information.) The consumer should use *ppTableID to identify the newly created table. If ppTableID is NULL on input and the provider
	/// cannot create a table that exactly matches pTableID, <c>ITableDefinition::CreateTable</c> should fail with DB_E_BADTABLEID.
	/// </para>
	/// </para>
	/// </param>
	/// <param name="ppRowset">
	/// [out] A pointer to memory in which to return the requested interface pointer on an empty rowset opened on the newly created table. If
	/// ppRowset is a null pointer, no rowset is created.
	/// </param>
	/// <returns>
	/// <list type="bullet">
	/// <item>
	/// <description>
	/// <para>
	/// S_OK The method succeeded and the table is created and opened. In all DBPROP structures passed to the method, dwStatus is set to DBPROPSTATUS_OK.
	/// </para>
	/// </description>
	/// </item>
	/// <item>
	/// <description>
	/// <para>
	/// DB_S_ERRORSOCCURRED The table was created and the rowset was opened, but one or more properties ? for which the dwOptions element of
	/// the DBPROP structure was DBPROPOPTIONS_OPTIONAL ? were not set. The consumer checks dwStatus in the DBPROP structures to determine
	/// which properties were not set. The method can fail to set properties for a number of reasons, including the following:
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
	/// <para>E_INVALIDARG pTableID and ppTableID were both null pointers.</para>
	/// <para>
	/// cColumnDesc was not zero, or rgColumnDescs was a null pointer. cColumnDesc was zero, and the provider does not support creating
	/// tables with no columns.
	/// </para>
	/// <para>cPropertySets was not zero, and rgPropertySets was a null pointer.</para>
	/// <para>In an element of rgPropertySets, cProperties was not zero and rgProperties was a null pointer.</para>
	/// <para>In an element of rgColumnDescs, cPropertySets was not zero and rgPropertySets was a null pointer.</para>
	/// </description>
	/// </item>
	/// <item>
	/// <description>
	/// <para>E_NOINTERFACE The rowset did not support the interface specified in riid.</para>
	/// <para>riid was IID_NULL, and ppRowset was not a null pointer.</para>
	/// <para>DB_E_BADCOLUMNIDdbcid in an element of rgColumnDescs was an invalid column ID.</para>
	/// </description>
	/// </item>
	/// <item>
	/// <description>
	/// <para>DB_E_BADTABLEID *pTableID was an invalid table ID.</para>
	/// </description>
	/// </item>
	/// <item>
	/// <description>
	/// <para>DB_E_BADPRECISION The precision in an element of rgColumnDescs was invalid.</para>
	/// </description>
	/// </item>
	/// <item>
	/// <description>
	/// <para>DB_E_BADSCALE The scale in an element of rgColumnDescs was invalid.</para>
	/// </description>
	/// </item>
	/// <item>
	/// <description>
	/// <para>DB_E_BADTYPE The wType, pwszTypeName, or pTypeInfo element, in an element of rgColumnDescs was invalid.</para>
	/// <para>In an element of rgColumnDescs, pwszTypeName was non-null and implied a DBTYPE other than the type specified by wType.</para>
	/// </description>
	/// </item>
	/// <item>
	/// <description>
	/// <para>DB_E_DUPLICATECOLUMNID dbcid was the same in two or more elements of rgColumnDescs.</para>
	/// </description>
	/// </item>
	/// <item>
	/// <description>
	/// <para>DB_E_DUPLICATETABLEID The specified table already exists in the current data store.</para>
	/// </description>
	/// </item>
	/// <item>
	/// <description>
	/// <para>
	/// DB_E_ERRORSOCCURRED The table was not created, and no rowset was returned because one or more properties ? for which the dwOptions
	/// element of the DBPROP structure was DBPROPOPTIONS_REQUIRED or an invalid value ? could not be set. The consumer checks dwStatus in
	/// the DBPROP structures to determine which properties were not set. The method can fail to set properties for any of the reasons
	/// specified in DB_S_ERRORSOCCURRED.
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
	/// <para>DB_SEC_E_PERMISSIONDENIED The consumer did not have sufficient permission to create the table.</para>
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
	/// <para>
	/// XACT_E_XTIONEXISTS The provider supports transactional DDL, the session is participating in a transaction, and the value of
	/// DBPROP_SUPPORTEDTXNDDL is DBPROPVAL_TC_DML.
	/// </para>
	/// </description>
	/// </item>
	/// </list>
	/// </returns>
	public static HRESULT CreateTable<T>(this ITableDefinition td, [In, Optional] object? pUnkOuter, [In, Optional] DBID? pTableID,
		[In, Optional] DBCOLUMNDESC[]? rgColumnDescs, [In, Optional] DBPROPSET[]? rgPropertySets, out DBID? ppTableID, out T? ppRowset) where T : class
	{
		var hr = td.CreateTable(pUnkOuter, (SafeCoTaskMemStruct<DBID>)pTableID, (uint)(rgColumnDescs?.Length ?? 0), rgColumnDescs, typeof(T).GUID,
			(uint)(rgPropertySets?.Length ?? 0), rgPropertySets, out var ptid, out object? rowset);
		ppTableID = ptid.ToNullableStructure<DBID>();
		ppRowset = (T?)rowset;
		return hr;
	}

	/// <summary>Returns information about the index rowset capabilities.</summary>
	/// <param name="ri">The <see cref="IRowsetIndex"/> instance.</param>
	/// <param name="prgIndexColumnDesc">
	/// <para>
	/// [out] A pointer to memory in which to return an array of DBINDEXCOLUMNDESC structures in key column order. The size of the array is
	/// equal to *pcKeyColumns.
	/// </para>
	/// <para>
	/// The provider allocates memory for the structures and returns the address to this memory; the consumer releases this memory with
	/// <c>IMalloc::Free</c> when it no longer needs the structures. If *pcKeyColumns is zero on output or if an error occurs, the provider
	/// does not allocate any memory and ensures that *prgIndexColumnDesc is a null pointer on output.
	/// </para>
	/// <para>For more information, see IIndexDefinition::CreateIndex.</para>
	/// </param>
	/// <param name="prgIndexPropertySets">
	/// <para>
	/// [out] A pointer to memory in which to return an array of DBPROPSET structures. One structure is returned for each property set that
	/// contains at least one property belonging to the Index property group. For information about the properties in the Index property
	/// group that are defined by OLE DB, see Index Property Group in Appendix C.
	/// </para>
	/// <para>
	/// The provider allocates memory for the structures and returns the address to this memory; the consumer releases this memory with
	/// <c>IMalloc::Free</c> when it no longer needs the structures. Before calling <c>IMalloc::Free</c> for *prgPropertySets, the consumer
	/// should call <c>IMalloc::Free</c> for the rgProperties element within each element of *prgPropertySets. The consumer must also call
	/// <c>VariantClear</c> for the vValue member of each DBPROP structure in order to prevent a memory leak in cases where the variant
	/// contains a reference type (such as a BSTR.) If *pcIndexPropertySets is zero on output or if an error occurs, the provider does not
	/// allocate any memory and ensures that *prgIndexPropertySets is a null pointer on output.
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
	public static HRESULT GetIndexInfo(this IRowsetIndex ri, out DBINDEXCOLUMNDESC[] prgIndexColumnDesc, out DBPROPSET[] prgIndexPropertySets)
	{
		HRESULT hr = ri.GetIndexInfo(out var pcKeyColumns, out var pIndexColumnDesc, out var pcIndexPropertySets, out var pIndexPropertySets);
		prgIndexColumnDesc = pcKeyColumns == 0 ? [] : pIndexColumnDesc.ToArray<DBINDEXCOLUMNDESC>((int)pcKeyColumns);
		prgIndexPropertySets = pcIndexPropertySets == 0 ? [] : pIndexPropertySets.ToArray<DBPROPSET>((int)pcIndexPropertySets);
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
}