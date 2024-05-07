namespace Vanara.PInvoke;

/// <summary>Items from the OleDb.dll.</summary>
public static partial class OleDb
{
	/// <summary>The literal described in the structure. For more information, see the following section.</summary>
	[PInvokeData("oledb.h")]
	public enum DBLITERAL
	{
		/// <summary>An invalid value.</summary>
		DBLITERAL_INVALID,

		/// <summary>A binary literal in a text command.</summary>
		DBLITERAL_BINARY_LITERAL,

		/// <summary>A catalog name in a text command.</summary>
		DBLITERAL_CATALOG_NAME,

		/// <summary>The character that separates the catalog name from the rest of the identifier in a text command.</summary>
		DBLITERAL_CATALOG_SEPARATOR,

		/// <summary>A character literal in a text command.</summary>
		DBLITERAL_CHAR_LITERAL,

		/// <summary>A column alias in a text command.</summary>
		DBLITERAL_COLUMN_ALIAS,

		/// <summary>A column name used in a text command or in a data-definition interface.</summary>
		DBLITERAL_COLUMN_NAME,

		/// <summary>A correlation name (table alias) in a text command.</summary>
		DBLITERAL_CORRELATION_NAME,

		/// <summary>A cursor name in a text command.</summary>
		DBLITERAL_CURSOR_NAME,

		/// <summary>
		/// The character used in a LIKE clause to escape the character returned for the DBLITERAL_LIKE_PERCENT literal. For example, if a
		/// percent sign (%) is used to match zero or more characters and this is a backslash (\), the characters "abc\%%" match all
		/// character values that start with "abc%".
		/// <para>Some SQL dialects support a clause (the ESCAPE clause) that can be used to override this value.</para>
		/// </summary>
		DBLITERAL_ESCAPE_PERCENT_PREFIX,

		/// <summary>
		/// The character used in a LIKE clause to escape the character returned for the DBLITERAL_LIKE_UNDERSCORE literal. For example, if
		/// an underscore (_) is used to match exactly one character and this is a backslash (\), the characters "abc\_ _" match all
		/// character values that are five characters long and start with "abc_".
		/// <para>Some SQL dialects support a clause (the ESCAPE clause) that can be used to override this value.</para>
		/// </summary>
		DBLITERAL_ESCAPE_UNDERSCORE_PREFIX,

		/// <summary>An index name used in a text command or in a data-definition interface.</summary>
		DBLITERAL_INDEX_NAME,

		/// <summary>
		/// The character used in a LIKE clause to match zero or more characters. For example, if this is a percent sign (%), the characters
		/// "abc%" match all character values that start with "abc".
		/// </summary>
		DBLITERAL_LIKE_PERCENT,

		/// <summary>
		/// The character used in a LIKE clause to match exactly one character. For example, if this is an underscore (_), the characters
		/// "abc_" match all character values that are four characters long and start with "abc".
		/// </summary>
		DBLITERAL_LIKE_UNDERSCORE,

		/// <summary>A procedure name in a text command.</summary>
		DBLITERAL_PROCEDURE_NAME,

		/// <summary>The character used in a text command as the opening quote for quoting identifiers that contain special characters.</summary>
		DBLITERAL_QUOTE_PREFIX,

		/// <summary>A schema name in a text command.</summary>
		DBLITERAL_SCHEMA_NAME,

		/// <summary>A table name used in a text command or in a data-definition interface.</summary>
		DBLITERAL_TABLE_NAME,

		/// <summary>A text command, such as an SQL statement.</summary>
		DBLITERAL_TEXT_COMMAND,

		/// <summary>A user name in a text command.</summary>
		DBLITERAL_USER_NAME,

		/// <summary>A view name in a text command.</summary>
		DBLITERAL_VIEW_NAME,

		/// <summary/>
		DBLITERAL_CUBE_NAME,

		/// <summary/>
		DBLITERAL_DIMENSION_NAME,

		/// <summary/>
		DBLITERAL_HIERARCHY_NAME,

		/// <summary/>
		DBLITERAL_LEVEL_NAME,

		/// <summary/>
		DBLITERAL_MEMBER_NAME,

		/// <summary/>
		DBLITERAL_PROPERTY_NAME,

		/// <summary>The character that separates the schema name from the rest of the identifier in a text command.</summary>
		DBLITERAL_SCHEMA_SEPARATOR,

		/// <summary>
		/// The character used in a text command as the closing quote for quoting identifiers that contain special characters. 1.x providers
		/// that use the same character as the prefix and suffix may not return this literal value and can set the lt member of the DBLITERAL
		/// structure to DBLITERAL_INVALID if requested.
		/// </summary>
		DBLITERAL_QUOTE_SUFFIX,

		/// <summary>
		/// The escape character, if any, used to suffix the character returned for the DBLITERAL_LIKE_PERCENT literal. For example, if a
		/// percent sign (%) is used to match zero or more characters and percent signs are escaped by enclosing in open and close square
		/// brackets, DBLITERAL_ESCAPE_PERCENT_PREFIX is "[", DBLITERAL_ESCAPE_PERCENT_SUFFIX is "]", and the characters "abc[%]%" match all
		/// character values that start with "abc%". Providers that do not use a suffix character to escape the DBLITERAL_ESCAPE_PERCENT
		/// character do not return this literal value and can set the lt member of the DBLITERAL structure to DBLITERAL_INVALID if requested.
		/// </summary>
		DBLITERAL_ESCAPE_PERCENT_SUFFIX,

		/// <summary>
		/// The escape character, if any, used to suffix the character returned for the DBLITERAL_LIKE_UNDERSCORE literal. For example, if an
		/// underscore (_) is used to match exactly one character and underscores are escaped by enclosing in open and close square brackets,
		/// DBLITERAL_ESCAPE_UNDERSCORE_PREFIX is "[", DBLITERAL_ESCAPE_UNDERSCORE_SUFFIX is "]", and the characters "abc[_]_" match all
		/// character values that are five characters long and start with "abc_". Providers that do not use a suffix character to escape the
		/// DBLITERAL_ESCAPE_UNDERSCORE character do not return this literal value and can set the lt member of the DBLITERAL structure to
		/// DBLITERAL_INVALID if requested.
		/// </summary>
		DBLITERAL_ESCAPE_UNDERSCORE_SUFFIX,
	}

	/// <summary>Result flags for <see cref="IMultipleResults.GetResult"/>.</summary>
	[PInvokeData("oledb.h")]
	public enum DBRESULTFLAG
	{
		/// <summary>
		/// The type of the returned object is defined by riid or by properties set on the command object. If this is ambiguous, the provider
		/// should return a rowset. Prior to OLE DB 2.6, providers were required to return E_INVALIDARG when lResultFlag was not zero.
		/// Consumers should not pass nonzero values unless the provider is a 2.6 or later provider and has added support for lResultFlag.
		/// </summary>
		DBRESULTFLAG_DEFAULT = 0,

		/// <summary>The consumer explicitly requests a rowset object.</summary>
		DBRESULTFLAG_ROWSET = 1,

		/// <summary>The consumer explicitly requests a row object.</summary>
		DBRESULTFLAG_ROW = 2
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

	/// <summary><c>IDBBinderProperties</c> allows a consumer to get, set, and reset direct binding properties.</summary>
	// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/ms720917(v=vs.85)
	[PInvokeData("oledb.h")]
	[ComImport, Guid("0c733ab3-2a1c-11ce-ade5-00aa0044773d"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IDBBinderProperties : IDBProperties
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
		new HRESULT GetProperties(uint cPropertyIDSets, [In, Optional] SafeDBPROPIDSETListHandle rgPropertyIDSets,
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
		new HRESULT GetPropertyInfo(uint cPropertyIDSets, [In, Optional] SafeDBPROPIDSETListHandle rgPropertyIDSets,
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
		new HRESULT SetProperties(uint cPropertySets, [In, Out] SafeDBPROPSETListHandle? rgPropertySets);

		/// <summary>
		/// Clears any properties set on a binder object. If the binder object has any properties with defaults, <c>Reset</c> returns them to
		/// their default values.
		/// </summary>
		// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/ms723076(v=vs.85) HRESULT Reset();
		void Reset();
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
	/// <para><c>IDBDataSourceAdmin</c> is an optional interface for creating, destroying, and modifying data stores.</para>
	/// <para>
	/// It is important to distinguish between the data store and the data source object. The data store is the actual source of data, such
	/// as a server database, a file in a directory, or an e-mail system. The data source object is the object that represents, and is used
	/// by the consumer code to interact with, the data store.
	/// </para>
	/// <para>
	/// The methods in this interface are intended to affect a data store, although OLE DB objects, such as the data source object, may
	/// incidentally be affected as well.
	/// </para>
	/// </summary>
	// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/ms722667(v=vs.85)
	[PInvokeData("oledb.h")]
	[ComImport, Guid("0c733a7a-2a1c-11ce-ade5-00aa0044773d"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IDBDataSourceAdmin
	{
		/// <summary>Creates and initializes a new data store.</summary>
		/// <param name="cPropertySets">
		/// [in] The number of DBPROPSET structures in rgPropertySets. If this is zero, the provider ignores rgPropertySets and the method
		/// does not do anything.
		/// </param>
		/// <param name="rgPropertySets">
		/// <para>
		/// [in/out] An array of DBPROPSET structures containing properties and values to be set. The properties specified in these
		/// structures must belong to the Data Source Creation or Initialization property groups; Initialization properties must be supported
		/// by the provider for use in data store creation. If the same property is specified more than once in rgPropertySets, the value
		/// used is provider-specific. If a provider cannot support a property, the property is ignored. If cPropertySets is zero, this
		/// argument is ignored.
		/// </para>
		/// <para>
		/// The properties specified in these structures must belong to the Data Source Creation, Initialization property or Session Property
		/// group. If one of these groups is specified and ppSession is not specified, the session properties are ignored
		/// </para>
		/// <para>
		/// For information about the properties in the Data Source Creation and Initialization property groups that are defined by OLE DB,
		/// see Data Source Creation Property Group, Initialization Property Group, and Session Property Group in Appendix C. For information
		/// about the DBPROPSET and DBPROP structures, see DBPROPSET Structure and DBPROP Structure.
		/// </para>
		/// </param>
		/// <param name="pUnkOuter">
		/// [in] A pointer to the controlling <c>IUnknown</c> interface if a session is desired and is to be created as part of an aggregate.
		/// Otherwise, it is a null pointer.
		/// </param>
		/// <param name="riid">[in] The requested interface for the session returned in *ppSession. Ignored if ppSession is a null pointer.</param>
		/// <param name="ppDBSession">
		/// [in/out] A pointer to memory in which to return the pointer to the session. If ppSession is a null pointer, no session is created.
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
		/// DB_S_ERRORSOCCURRED The new data store was created, but one or more properties ? for which the dwOptions element of the DBPROP
		/// structure was DBPROPOPTIONS_OPTIONAL ? were not set. The consumer checks dwStatus in the DBPROP structures to determine which
		/// properties were not set. The method can fail to set properties for a number of reasons, including the following:
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
		/// <para>E_INVALIDARG cPropertySets was not zero, and rgPropertySets was a null pointer.</para>
		/// <para>In an element of rgPropertySets, cProperties was not zero and rgProperties was a null pointer.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>E_NOINTERFACE The session did not support the interface specified in riid.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>E_OUTOFMEMORY The provider was unable to allocate sufficient memory to create the new data store.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// DB_E_ALREADYINITIALIZED <c>IDBInitialize::Initialize</c> had already been called for the data source object, and an intervening
		/// call to <c>IDBInitialize::Uninitialize</c> had not been made.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// DB_E_CANCELED The provider prompted the user for additional information, and the user selected Cancel. A data store was not
		/// created and the data source was not initialized.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_E_DUPLICATEDATASOURCE A data store with the same name already exists.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// DB_E_ERRORSOCCURRED The data store was not created because one or more properties ? for which the dwOptions element of the DBPROP
		/// structure was DBPROPOPTIONS_REQUIRED or an invalid value ? were not set. The consumer checks dwStatus in the DBPROP structures to
		/// determine which properties were not set. None of the satisfiable properties are remembered. The method can fail to set properties
		/// for a number of reasons, including the following:
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// DB_E_NOAGGREGATION pUnkOuter was not a null pointer, and the provider is an OLE DB 1.0 or 1.1 provider that does not support
		/// aggregation of the data source object being created.
		/// </para>
		/// <para>pUnkOuter was not a null pointer, and riid was not IID_IUnknown.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_SEC_E_AUTH_FAILED The provider required initialization, but an authentication failed. The data store was not created.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_SEC_E_PERMISSIONDENIED The consumer did not have permission to create a new data store.</para>
		/// </description>
		/// </item>
		/// </list>
		/// </returns>
		// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/ms725438(v=vs.85) HRESULT CreateDataSource( ULONG
		// cPropertySets, DBPROPSET rgPropertySets[], IUnknown *pUnkOuter, REFIID riid, IUnknown **ppSession);
		[PreserveSig]
		HRESULT CreateDataSource(uint cPropertySets, [In, Out] SafeDBPROPSETListHandle rgPropertySets, [In, Optional, MarshalAs(UnmanagedType.IUnknown)] object? pUnkOuter,
			in Guid riid, [Optional, MarshalAs(UnmanagedType.IUnknown)] out object? ppDBSession);

		/// <summary>Destroys the current data store.</summary>
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
		/// <para>E_UNEXPECTED The data source object was in an uninitialized state.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_E_NOTSUPPORTED The provider does not support this method.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_SEC_E_PERMISSIONDENIED The consumer did not have permission to destroy the current data store.</para>
		/// </description>
		/// </item>
		/// </list>
		/// </returns>
		// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/ms725446(v=vs.85) HRESULT DestroyDataSource ();
		[PreserveSig]
		HRESULT DestroyDataSource();

		/// <summary>Returns information about the data store creation properties that are supported by the data provider.</summary>
		/// <param name="cPropertyIDSets">
		/// <para>[in] The number of DBPROPIDSET structures in rgPropertyIDSets.</para>
		/// <para>
		/// If cPropertyIDSets is zero, the provider ignores rgPropertyIDSets and returns information about all of the properties in the Data
		/// Source Creation property group it supports and about all of the properties in the Initialization property group it supports for
		/// use in creating data stores.
		/// </para>
		/// <para>
		/// If cPropertyIDSets is not zero, the provider returns information about the requested properties. If a property is not supported
		/// or if a property in the Initialization property group cannot be used to create data stores, the returned value of dwStatus in the
		/// returned DBPROPINFO structure for that property is DBPROPFLAGS_NOTSUPPORTED and the values of the pwszDescription, vtType, and
		/// vValues elements are undefined.
		/// </para>
		/// </param>
		/// <param name="rgPropertyIDSets">
		/// <para>
		/// [in] An array of cPropertyIDSets DBPROPIDSET structures. The properties specified in these structures must belong to the Data
		/// Source Creation property group or belong to the Initialization property group and be supported for use in creating data stores.
		/// The provider returns information about the properties specified in these structures. If cPropertyIDSets is zero, this parameter
		/// is ignored.
		/// </para>
		/// <para>
		/// For information about the properties in the Data Source Creation and Initialization property groups that are defined by OLE DB,
		/// see Data Source Creation Property Group, Initialization Property Group, and Session Property Group in Appendix C. For information
		/// about the DBPROPIDSET structure, see DBPROPIDSET Structure.
		/// </para>
		/// </param>
		/// <param name="pcPropertyInfoSets">
		/// [out] A pointer to memory in which to return the number of DBPROPINFOSET structures returned in *prgPropertyInfoSets. If
		/// cPropertyIDSets is zero, *pcPropertyInfoSets is the total number of property sets for which the provider supports at least one
		/// property in the Data Source Creation or Initialization property group. If cPropertyIDSets is greater than zero,
		/// *pcPropertyInfoSets is set to cPropertyIDSets. If an error occurs, *pcPropertyInfoSets is set to zero.
		/// </param>
		/// <param name="prgPropertyInfoSets">
		/// <para>
		/// [out] A pointer to memory in which to return an array of DBPROPINFOSET structures. If cPropertyIDSets is zero, one structure is
		/// returned for each property set that contains at least one property belonging to the Data Source Creation or Initialization
		/// property group. If cPropertyIDSets is not zero, one structure is returned for each property set specified in rgPropertyIDSets.
		/// </para>
		/// <para>
		/// If cPropertyIDSets is not zero, the DBPROPINFOSET structures in *prgPropertyInfoSets are returned in the same order as the
		/// DBPROPIDSET structures in rgPropertyIDSets; that is, for corresponding elements of each array, the guidPropertySet elements are
		/// the same. If cPropertyIDs, in an element of rgPropertyIDSets, is not zero, the DBPROPINFO structures in the corresponding element
		/// of *prgPropertyInfoSets are returned in the same order as the DBPROPID values in rgPropertyIDs; that is, for corresponding
		/// elements of each array, the property IDs are the same.
		/// </para>
		/// <para>
		/// The provider allocates memory for the structures and returns the address to this memory; the consumer releases this memory with
		/// <c>IMalloc::Free</c> when it no longer needs the structures. Before calling <c>IMalloc::Free</c> for *prgPropertyInfoSets, the
		/// consumer should call <c>IMalloc::Free</c> for the rgPropertyInfos element in each element of *prgPropertyInfoSets. If
		/// *pcPropertyInfoSets is zero on output or an error occurs, *prgPropertyInfoSets must be a null pointer on output.
		/// </para>
		/// <para>For information about the DBPROPINFOSET and DBPROPINFO structures, see DBPROPINFOSET Structure and DBPROPINFO Structure.</para>
		/// </param>
		/// <param name="ppDescBuffer">
		/// [out] A pointer to memory in which to return a pointer to storage for all string values returned in the pwszDescription element
		/// of the DBPROPINFO structure. The provider allocates this memory with <c>IMalloc</c>, and the consumer frees it with
		/// <c>IMalloc::Free</c> when it no longer needs the property descriptions. If ppDescBuffer is a null pointer on input,
		/// <c>IDBDataSourceAdmin::GetCreationProperties</c> does not return the property descriptions. If *pcPropertyInfoSets is zero on
		/// output or an error occurs, the provider does not allocate any memory and ensures that *ppDescBuffer is a null pointer on output.
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
		/// DB_S_ERRORSOCCURRED One or more properties specified in rgPropertyIDSets were not supported by the provider. The dwFlags element
		/// of the DBPROPINFO structure for such properties is set to DBPROPFLAGS_NOTSUPPORTED.
		/// </para>
		/// <para>
		/// One or more properties specified in rgPropertyIDSets were not in the Data Source Creation or Initialization property group. The
		/// dwFlags element of the DBPROPINFO structure for such properties is set to DBPROPFLAGS_NOTSUPPORTED.
		/// </para>
		/// <para>
		/// One or more properties specified in rgPropertyIDSets were in the Initialization property group but could not be used to create
		/// data stores. The dwFlags element of the DBPROPINFO structure for such properties is set to DBPROPFLAGS_NOTSUPPORTED.
		/// </para>
		/// <para>
		/// One or more property sets specified in rgPropertyIDSets were not supported by the provider. The dwFlags element of the DBPROPINFO
		/// structure for all specified properties in these sets is set to DBPROPFLAGS_NOTSUPPORTED. If cPropertyIDs in the DBPROPIDSET
		/// structure for the property set was zero, the provider cannot set dwStatus in the DBPROP structure because it does not know the
		/// IDs of any properties in the property set. Instead, it sets cProperties to zero in the DBPROPSET structure returned for the
		/// property set.
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
		/// DB_E_ERRORSOCCURRED Values were not returned for any properties. The provider allocates memory for *prgPropertySets, and the
		/// consumer checks dwStatus in the DBPROP structures to determine why properties were not returned. The consumer frees this memory
		/// when it no longer needs the information.
		/// </para>
		/// </description>
		/// </item>
		/// </list>
		/// </returns>
		// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/ms712991(v=vs.85) HRESULT GetCreationProperties ( ULONG
		// cPropertyIDSets, const DBPROPIDSET rgPropertyIDSets[], ULONG *pcPropertyInfoSets, DBPROPINFOSET **prgPropertyInfoSets, OLECHAR **ppDescBuffer);
		HRESULT GetCreationProperties(uint cPropertyIDSets, [In] SafeDBPROPIDSETListHandle rgPropertyIDSets, out uint pcPropertyInfoSets,
			out SafeDBPROPINFOSETListHandle prgPropertyInfoSets, out SafeIMallocHandle ppDescBuffer);

		/// <summary>Modifies the current data store.</summary>
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
		/// DB_S_ERRORSOCCURRED The data store was modified, but one or more properties ? for which the dwOptions element of the DBPROP
		/// structure was DBPROPOPTIONS_OPTIONAL ? were not set. The consumer checks dwStatus in the DBPROP structures to determine which
		/// properties were not set. The method can fail to set properties for a number of reasons, including the following:
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
		/// <para>E_INVALIDARG cPropertySets was not zero, and rgPropertySets was a null pointer.</para>
		/// <para>In an element of rgPropertySets, cProperties was not zero and rgProperties was a null pointer.</para>
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
		/// DB_E_ERRORSOCCURRED The data store was not modified because one or more properties ? for which the dwOptions element of the
		/// DBPROP structure was DBPROPOPTIONS_REQUIRED ? were not set. The consumer checks dwStatus in the DBPROP structures to determine
		/// which properties were not set. None of the satisfiable properties are remembered. The method can fail to set properties for a
		/// number of reasons, including the following:
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
		/// <para>DB_SEC_E_PERMISSIONDENIED The consumer did not have permission to modify the current data store.</para>
		/// </description>
		/// </item>
		/// </list>
		/// </returns>
		// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/ms712958(v=vs.85) HRESULT ModifyDataSource ( ULONG
		// cPropertySets, DBPROPSET rgPropertySets[]);
		HRESULT ModifyDataSource(uint cPropertySets, [In, Out] SafeDBPROPSETListHandle rgPropertySets);
	}

	/// <summary>
	/// <para>
	/// <c>IDBInfo</c> returns information about the keywords and literals a provider supports. It is an optional interface on the data
	/// source objects.
	/// </para>
	/// </summary>
	// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/ms713663(v=vs.85)
	[PInvokeData("oledb.h")]
	[ComImport, Guid("0c733a89-2a1c-11ce-ade5-00aa0044773d"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IDBInfo
	{
		/// <summary>Returns a list of provider-specific keywords.</summary>
		/// <returns>
		/// <para>
		/// [out] A pointer to memory in which to return the address of a string. The string contains a comma-separated list of all keywords
		/// unique to this provider ? that is, a comma-separated list of keywords that are not in the list in the Comments section. If there
		/// are no keywords unique to this provider or if an error occurs, the provider sets *ppwszKeywords to a null pointer.
		/// </para>
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
		/// <para>E_INVALIDARG ppwszKeywords was a null pointer.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>E_OUTOFMEMORY The provider was unable to allocate sufficient memory in which to return the keywords.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>E_UNEXPECTED The data source object was in an uninitialized state.</para>
		/// </description>
		/// </item>
		/// </list>
		/// <para><c>Comments</c></para>
		/// <para>The following is a list of the keywords from OLE DB:</para>
		/// <list type="table">
		/// <listheader>
		/// <description>ABSOLUTE</description>
		/// <description>ESCAPE</description>
		/// <description>OUTPUT</description>
		/// </listheader>
		/// <item>
		/// <description>ACTION</description>
		/// <description>EXCEPT</description>
		/// <description>OVERLAPS</description>
		/// </item>
		/// <item>
		/// <description>ADD</description>
		/// <description>EXCEPTION</description>
		/// <description>PARTIAL</description>
		/// </item>
		/// <item>
		/// <description>ALL</description>
		/// <description>EXEC</description>
		/// <description>POSITION</description>
		/// </item>
		/// <item>
		/// <description>ALLOCATE</description>
		/// <description>EXECUTE</description>
		/// <description>PRECISION</description>
		/// </item>
		/// <item>
		/// <description>ALTER</description>
		/// <description>EXISTS</description>
		/// <description>PREPARE</description>
		/// </item>
		/// <item>
		/// <description>AND</description>
		/// <description>EXTERNAL</description>
		/// <description>PRESERVE</description>
		/// </item>
		/// <item>
		/// <description>ANY</description>
		/// <description>EXTRACT</description>
		/// <description>PRIMARY</description>
		/// </item>
		/// <item>
		/// <description>ARE</description>
		/// <description>FALSE</description>
		/// <description>PRIOR</description>
		/// </item>
		/// <item>
		/// <description>AS</description>
		/// <description>FETCH</description>
		/// <description>PRIVILEGES</description>
		/// </item>
		/// <item>
		/// <description>ASC</description>
		/// <description>FIRST</description>
		/// <description>PROCEDURE</description>
		/// </item>
		/// <item>
		/// <description>ASSERTION</description>
		/// <description>FLOAT</description>
		/// <description>PUBLIC</description>
		/// </item>
		/// <item>
		/// <description>AT</description>
		/// <description>FOR</description>
		/// <description>READ</description>
		/// </item>
		/// <item>
		/// <description>AUTHORIZATION</description>
		/// <description>FOREIGN</description>
		/// <description>REAL</description>
		/// </item>
		/// <item>
		/// <description>AVG</description>
		/// <description>FOUND</description>
		/// <description>REFERENCES</description>
		/// </item>
		/// <item>
		/// <description>BEGIN</description>
		/// <description>FROM</description>
		/// <description>RELATIVE</description>
		/// </item>
		/// <item>
		/// <description>BETWEEN</description>
		/// <description>FULL</description>
		/// <description>RESTRICT</description>
		/// </item>
		/// <item>
		/// <description>BIT</description>
		/// <description>GET</description>
		/// <description>REVOKE</description>
		/// </item>
		/// <item>
		/// <description>BIT_LENGTH</description>
		/// <description>GLOBAL</description>
		/// <description>RIGHT</description>
		/// </item>
		/// <item>
		/// <description>BOTH</description>
		/// <description>GO</description>
		/// <description>ROLLBACK</description>
		/// </item>
		/// <item>
		/// <description>BY</description>
		/// <description>GOTO</description>
		/// <description>ROWS</description>
		/// </item>
		/// <item>
		/// <description>CASCADE</description>
		/// <description>GRANT</description>
		/// <description>SCHEMA</description>
		/// </item>
		/// <item>
		/// <description>CASCADED</description>
		/// <description>GROUP</description>
		/// <description>SCROLL</description>
		/// </item>
		/// <item>
		/// <description>CASE</description>
		/// <description>HAVING</description>
		/// <description>SECOND</description>
		/// </item>
		/// <item>
		/// <description>CAST</description>
		/// <description>HOUR</description>
		/// <description>SECTION</description>
		/// </item>
		/// <item>
		/// <description>CATALOG</description>
		/// <description>IDENTITY</description>
		/// <description>SELECT</description>
		/// </item>
		/// <item>
		/// <description>CHAR</description>
		/// <description>IMMEDIATE</description>
		/// <description>SESSION</description>
		/// </item>
		/// <item>
		/// <description>CHAR_LENGTH</description>
		/// <description>IN</description>
		/// <description>SESSION_USER</description>
		/// </item>
		/// <item>
		/// <description>CHARACTER</description>
		/// <description>INDICATOR</description>
		/// <description>SET</description>
		/// </item>
		/// <item>
		/// <description>CHARACTER_LENGTH</description>
		/// <description>INITIALLY</description>
		/// <description>SIZE</description>
		/// </item>
		/// <item>
		/// <description>CHECK</description>
		/// <description>INNER</description>
		/// <description>SMALLINT</description>
		/// </item>
		/// <item>
		/// <description>CLOSE</description>
		/// <description>INPUT</description>
		/// <description>SOME</description>
		/// </item>
		/// <item>
		/// <description>COALESCE</description>
		/// <description>INSENSITIVE</description>
		/// <description>SQL</description>
		/// </item>
		/// <item>
		/// <description>COLLATE</description>
		/// <description>INSERT</description>
		/// <description>SQLCODE</description>
		/// </item>
		/// <item>
		/// <description>COLLATION</description>
		/// <description>INT</description>
		/// <description>SQLERROR</description>
		/// </item>
		/// <item>
		/// <description>COLUMN</description>
		/// <description>INTEGER</description>
		/// <description>SQLSTATE</description>
		/// </item>
		/// <item>
		/// <description>COMMIT</description>
		/// <description>INTERSECT</description>
		/// <description>SUBSTRING</description>
		/// </item>
		/// <item>
		/// <description>CONNECT</description>
		/// <description>INTERVAL</description>
		/// <description>SUM</description>
		/// </item>
		/// <item>
		/// <description>CONNECTION</description>
		/// <description>INTO</description>
		/// <description>SYSTEM_USER</description>
		/// </item>
		/// <item>
		/// <description>CONSTRAINT</description>
		/// <description>IS</description>
		/// <description>TABLE</description>
		/// </item>
		/// <item>
		/// <description>CONSTRAINTS</description>
		/// <description>ISOLATION</description>
		/// <description>TEMPORARY</description>
		/// </item>
		/// <item>
		/// <description>CONTINUE</description>
		/// <description>JOIN</description>
		/// <description>THEN</description>
		/// </item>
		/// <item>
		/// <description>CONVERT</description>
		/// <description>KEY</description>
		/// <description>TIME</description>
		/// </item>
		/// <item>
		/// <description>CORRESPONDING</description>
		/// <description>LANGUAGE</description>
		/// <description>TIMESTAMP</description>
		/// </item>
		/// <item>
		/// <description>COUNT</description>
		/// <description>LAST</description>
		/// <description>TIMEZONE_HOUR</description>
		/// </item>
		/// <item>
		/// <description>CREATE</description>
		/// <description>LEADING</description>
		/// <description>TIMEZONE_MINUTE</description>
		/// </item>
		/// <item>
		/// <description>CROSS</description>
		/// <description>LEFT</description>
		/// <description>TO</description>
		/// </item>
		/// <item>
		/// <description>CURRENT</description>
		/// <description>LEVEL</description>
		/// <description>TRAILING</description>
		/// </item>
		/// <item>
		/// <description>CURRENT_DATE</description>
		/// <description>LIKE</description>
		/// <description>TRANSACTION</description>
		/// </item>
		/// <item>
		/// <description>CURRENT_TIME</description>
		/// <description>LOCAL</description>
		/// <description>TRANSLATE</description>
		/// </item>
		/// <item>
		/// <description>CURRENT_TIMESTAMP</description>
		/// <description>LOWER</description>
		/// <description>TRANSLATION</description>
		/// </item>
		/// <item>
		/// <description>CURRENT_USER</description>
		/// <description>MATCH</description>
		/// <description>TRIGGER</description>
		/// </item>
		/// <item>
		/// <description>CURSOR</description>
		/// <description>MAX</description>
		/// <description>TRIM</description>
		/// </item>
		/// <item>
		/// <description>DATE</description>
		/// <description>MIN</description>
		/// <description>TRUE</description>
		/// </item>
		/// <item>
		/// <description>DAY</description>
		/// <description>MINUTE</description>
		/// <description>UNION</description>
		/// </item>
		/// <item>
		/// <description>DEALLOCATE</description>
		/// <description>MODULE</description>
		/// <description>UNIQUE</description>
		/// </item>
		/// <item>
		/// <description>DEC</description>
		/// <description>MONTH</description>
		/// <description>UNKNOWN</description>
		/// </item>
		/// <item>
		/// <description>DECIMAL</description>
		/// <description>NAMES</description>
		/// <description>UPDATE</description>
		/// </item>
		/// <item>
		/// <description>DECLARE</description>
		/// <description>NATIONAL</description>
		/// <description>UPPER</description>
		/// </item>
		/// <item>
		/// <description>DEFAULT</description>
		/// <description>NATURAL</description>
		/// <description>USAGE</description>
		/// </item>
		/// <item>
		/// <description>DEFERRABLE</description>
		/// <description>NCHAR</description>
		/// <description>USER</description>
		/// </item>
		/// <item>
		/// <description>DEFERRED</description>
		/// <description>NEXT</description>
		/// <description>USING</description>
		/// </item>
		/// <item>
		/// <description>DELETE</description>
		/// <description>NO</description>
		/// <description>VALUE</description>
		/// </item>
		/// <item>
		/// <description>DESC</description>
		/// <description>NOT</description>
		/// <description>VALUES</description>
		/// </item>
		/// <item>
		/// <description>DESCRIBE</description>
		/// <description>NULL</description>
		/// <description>VARCHAR</description>
		/// </item>
		/// <item>
		/// <description>DESCRIPTOR</description>
		/// <description>NULLIF</description>
		/// <description>VARYING</description>
		/// </item>
		/// <item>
		/// <description>DIAGNOSTICS</description>
		/// <description>NUMERIC</description>
		/// <description>VIEW</description>
		/// </item>
		/// <item>
		/// <description>DISCONNECT</description>
		/// <description>OCTET_LENGTH</description>
		/// <description>WHEN</description>
		/// </item>
		/// <item>
		/// <description>DISTINCT</description>
		/// <description>OF</description>
		/// <description>WHENEVER</description>
		/// </item>
		/// <item>
		/// <description>DISTINCTROW</description>
		/// <description>ON</description>
		/// <description>WHERE</description>
		/// </item>
		/// <item>
		/// <description>DOMAIN</description>
		/// <description>ONLY</description>
		/// <description>WITH</description>
		/// </item>
		/// <item>
		/// <description>DOUBLE</description>
		/// <description>OPEN</description>
		/// <description>WORK</description>
		/// </item>
		/// <item>
		/// <description>DROP</description>
		/// <description>OPTION</description>
		/// <description>WRITE</description>
		/// </item>
		/// <item>
		/// <description>ELSE</description>
		/// <description>OR</description>
		/// <description>YEAR</description>
		/// </item>
		/// <item>
		/// <description>END</description>
		/// <description>ORDER</description>
		/// <description>ZONE</description>
		/// </item>
		/// <item>
		/// <description>END-EXEC</description>
		/// <description>OUTER</description>
		/// <description/>
		/// </item>
		/// </list>
		/// </returns>
		// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/ms712923(v=vs.85) HRESULT GetKeywords( LPOLESTR *ppwszKeywords);
		[return: MarshalAs(UnmanagedType.LPWStr)]
		string GetKeywords();

		/// <summary>
		/// Returns information about literals used in text commands, <c>ITableDefinition</c>, <c>IIndexDefinition</c>, and
		/// <c>IOpenRowset</c>, or any interface that takes DBIDs as arguments.
		/// </summary>
		/// <param name="cLiterals">
		/// [in] The number of literals being asked about. If this is 0, the provider ignores rgLiterals and returns information about all
		/// the literals it supports.
		/// </param>
		/// <param name="rgLiterals">
		/// <para>
		/// [in] An array of cLiterals literals about which to return information. If the consumer specifies an invalid DBLITERAL value in
		/// this array, <c>IDBInfo::GetLiteralInfo</c> returns FALSE in fSupported in the corresponding element of the *prgLiteralInfo array.
		/// </para>
		/// <para>If cLiterals is 0, this parameter is ignored.</para>
		/// </param>
		/// <param name="pcLiteralInfo">
		/// [out] A pointer to memory in which to return the number of literals for which information was returned. If cLiterals is 0, this
		/// is the total number of literals supported by the provider. If an error other than DB_E_ERRORSOCCURRED occurs, *pcLiteralInfo is
		/// set to 0.
		/// </param>
		/// <param name="prgLiteralInfo">
		/// [out] A pointer to memory in which to return a pointer to an array of DBLITERALINFO structures. One structure is returned for
		/// each literal. The provider allocates memory for the structures and returns the address to this memory; the consumer releases this
		/// memory with <c>IMalloc::Free</c> when it no longer needs the structures. If *pcLiteralInfo is 0 on output or if an error other
		/// than DB_E_ERRORSOCCURRED occurs, the provider does not allocate any memory and ensures that *prgLiteralInfo is a null pointer on
		/// output. For information about DBLITERALINFO structures, see the Comments section.
		/// </param>
		/// <param name="ppCharBuffer">
		/// [out] A pointer to memory in which to return a pointer for all string values (pwszLiteralValue, pwszInvalidChars, and
		/// pwszInvalidStartingChars) within a single allocation block. The provider allocates this memory, and the consumer releases it with
		///                           <c>IMalloc::Free</c> when it no longer needs it. If *pcLiteralInfo is 0 on output or an error occurs,
		///                           the provider does not allocate any memory and ensures that *ppCharBuffer is a null pointer on output.
		/// Each of the individual string values stored in this buffer is terminated by a null-termination character. Therefore, the buffer
		/// may contain one or more strings, each with its own null-termination character, and may contain embedded null-termination characters.
		/// </param>
		/// <returns>
		/// <list type="bullet">
		/// <item>
		/// <description>
		/// <para>S_OK The method succeeded. In each structure returned in *prgLiteralInfo, the fSupported element is set to TRUE.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// DB_S_ERRORSOCCURRED rgLiterals contained at least one unsupported or invalid literal. In the structures returned in
		/// *prgLiteralInfo for unsupported or invalid literals, the fSupported element is set to FALSE.
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
		/// <para>E_INVALIDARG cLiterals was not equal to zero, and rgLiterals was a null pointer.</para>
		/// <para>pcLiteralInfo, prgLiteralInfo, or ppCharBuffer was a null pointer.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// E_OUTOFMEMORY The provider was unable to allocate sufficient memory in which to return the DBLITERALINFO structures or the
		/// strings containing the valid and starting characters.
		/// </para>
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
		/// DB_E_ERRORSOCCURRED All literals were either invalid or unsupported. The provider allocates memory for *prgLiteralInfo and sets
		/// the value of the fSupported element in all of the structures to FALSE. The consumer frees this memory when it no longer needs the information.
		/// </para>
		/// </description>
		/// </item>
		/// </list>
		/// </returns>
		// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/ms712896(v=vs.85) HRESULT GetLiteralInfo( ULONG cLiterals,
		// const DBLITERAL rgLiterals[], ULONG *pcLiteralInfo, DBLITERALINFO **prgLiteralInfo, OLECHAR **ppCharBuffer);
		HRESULT GetLiteralInfo(uint cLiterals, [In, MarshalAs(UnmanagedType.LPArray)] DBLITERAL[] rgLiterals, out uint pcLiteralInfo,
			out SafeIMallocHandle prgLiteralInfo, out SafeIMallocHandle ppCharBuffer);
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

	/// <summary>
	/// <para>This is a mandatory interface on the session for obtaining an interface pointer to the data source object.</para>
	/// </summary>
	// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/ms709721(v=vs.85)
	[PInvokeData("oledb.h")]
	[ComImport, Guid("0c733a75-2a1c-11ce-ade5-00aa0044773d"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IGetDataSource
	{
		/// <summary>Returns an interface pointer on the data source object that created the session.</summary>
		/// <param name="riid">[in] The IID of the interface on which to return a pointer.</param>
		/// <returns>
		/// A pointer to memory in which to return the interface pointer. If <c>IGetDataSource::GetDataSource</c> fails, it must attempt to
		/// set *ppDataSource to a null pointer.
		/// </returns>
		// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/ms725443(v=vs.85) HRESULT GetDataSource ( REFIID riid,
		// IUnknown **ppDataSource);
		[return: MarshalAs(UnmanagedType.IUnknown)]
		object? GetDataSource(in Guid riid);
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
	/// The <c>IGetSession</c> interface returns an interface pointer on the session object within whose context the row object was created.
	/// </para>
	/// <para>
	/// Every row object is created within the context of a session object. When a consumer creates a row object from a rowset by calling
	/// <c>IGetRow::GetRowFromHROW</c>, the row object exists within the context of the session associated with that rowset. When the
	/// consumer instantiates a row directly by calling a method such as <c>IBindResource::Bind</c>, the provider creates an implicit session
	/// object first and then instantiates the row object in the context of that session.
	/// </para>
	/// <para>
	/// For many operations, such as creating a containing rowset, creating views, and transacting scoped operations, the consumer needs an
	/// interface on the session object within whose context the row exists. The <c>IGetSession</c> interface has a single method that
	/// returns the desired interface on the session object associated with a row.
	/// </para>
	/// </summary>
	// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/ms711603(v=vs.85)
	[PInvokeData("oledb.h")]
	[ComImport, Guid("0c733aba-2a1c-11ce-ade5-00aa0044773d"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IGetSession
	{
		/// <summary>Returns an interface pointer on the session object associated with the row object.</summary>
		/// <param name="riid">[in] The interface ID (IID) of the requested interface to return in ppSession.</param>
		/// <returns>
		/// A pointer to memory in which to return the interface pointer on the session. If the provider does not have a session object as
		/// the context for the row, it sets *ppSession to a null pointer. If <c>IGetSession::GetSession</c> fails and ppSession is not a
		/// null pointer, the provider must attempt to set *ppSession to a null pointer.
		/// </returns>
		// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/ms720926(v=vs.85) HRESULT GetSession( REFIID riid, IUnknown
		// **ppSession );
		[return: MarshalAs(UnmanagedType.IUnknown)]
		object? GetSession(in Guid riid);
	}

	/// <summary>The <c>IGetSourceRow</c> interface returns an interface on the row object within whose context a stream object was created.</summary>
	// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/ms719690(v=vs.85)
	[PInvokeData("oledb.h")]
	[ComImport, Guid("0c733abb-2a1c-11ce-ade5-00aa0044773d"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IGetSourceRow
	{
		/// <summary>Returns an interface pointer on the row object associated with the stream object.</summary>
		/// <param name="riid">[in] The IID of the interface on which to return a pointer.</param>
		/// <returns>
		/// A pointer to memory in which to return the interface pointer. If the provider does not have a row object as the context for the
		/// stream object, it sets *ppRow to a null pointer. If <c>IGetSourceRow::GetSourceRow</c> fails, the provider must attempt to set
		/// *ppRow to a null pointer.
		/// </returns>
		// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/ms716759(v=vs.85) HRESULT GetSourceRow( REFIID riid, IUnknown
		// ** ppRow );
		[return: MarshalAs(UnmanagedType.IUnknown)]
		object? GetSourceRow(in Guid riid);
	}

	/// <summary><c>IIndexDefinition</c> exposes simple methods to create and drop indexes from the data store.</summary>
	// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/ms711593(v=vs.85)
	[PInvokeData("oledb.h")]
	[ComImport, Guid("0c733a68-2a1c-11ce-ade5-00aa0044773d"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IIndexDefinition
	{
		/// <summary>Adds a new index to a base table.</summary>
		/// <param name="pTableID">[in] A pointer to the DBID of the table for which to create an index.</param>
		/// <param name="pIndexID">
		/// [in] A pointer to the ID of the new index to create. If this is a null pointer, the provider assigns an ID to the index. The ID
		/// must be unique.
		/// </param>
		/// <param name="cIndexColumnDescs">[in] The count of DBINDEXCOLUMNSDESC structures in rgIndexColumnDescs.</param>
		/// <param name="rgIndexColumnDescs">
		/// [in] An array of DBINDEXCOLUMNDESC structures that describe how to construct the index. The order of the DBINDEXCOLUMNDESC
		/// structures in rgIndexColumnDescs determines the order of the columns in the index key. That is, the column identified by the
		/// first element of this array is the most significant column in the index key and the column identified by the last element is the
		/// least significant column. When the index is opened as a rowset, the key columns occur in order of most significant column to
		/// least significant column.
		/// </param>
		/// <param name="cPropertySets">
		/// [in] The number of DBPROPSET structures in rgPropertySets. If this is zero, the provider ignores rgPropertySets.
		/// </param>
		/// <param name="rgPropertySets">
		/// [in/out] An array of DBPROPSET structures containing properties and values to be set. The properties specified in these
		/// structures must belong to the Index property group. If the same property is specified more than once in rgPropertySets, it is
		/// provider-specific which value is used. If cPropertySets is zero, this argument is ignored.
		/// <para>
		/// For information about the properties in the Index property group that are defined by OLE DB, see Index Property Group in Appendix
		/// C.For information about the DBPROPSET and DBPROP structures, see DBPROPSET Structure and DBPROP Structure.
		/// </para>
		/// </param>
		/// <param name="ppIndexID">
		/// [out] A pointer to memory in which to return a pointer to the DBID of a newly created index. If ppIndexID is a null pointer, no
		/// DBID is returned.
		/// </param>
		/// <returns>
		/// <list type="bullet">
		/// <item>
		/// <description>
		/// <para>
		/// S_OK The method succeeded, and the new index has been created. In all DBPROP structures passed to the method, dwStatus is set to DBPROPSTATUS_OK.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// DB_S_ERRORSOCCURRED The index was created, but one or more properties ? for which the dwOptions element of the DBPROP structure
		/// was DBPROPOPTIONS_OPTIONAL ? were not set. The consumer checks dwStatus in the DBPROP structures to determine which properties
		/// were not set. The method can fail to set properties for a number of reasons, including the following:
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_E_TABLEINUSE The specified table was in use, and the provider could not create the index with the table open.</para>
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
		/// <para>pIndexID and ppIndexID were both null pointers.</para>
		/// <para>cIndexColumnDescs was zero.</para>
		/// <para>rgIndexColumnDescs was a null pointer.</para>
		/// <para>eIndexColOrder in an element of rgIndexColumnDescs was not a valid value.</para>
		/// <para>cPropertySets was not zero, and rgPropertySets was a null pointer.</para>
		/// <para>In an element of rgPropertySets, cProperties was not zero and rgProperties was a null pointer.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_E_BADINDEXID *pIndexID was an invalid index ID.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_E_DUPLICATEINDEXID The specified index already exists in the data store.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// DB_E_ERRORSOCCURRED No index was created because one or more properties ? for which the dwOptions element of the DBPROP structure
		/// was DBPROPOPTIONS_REQUIRED or an invalid value ? were not set. The consumer checks dwStatus in the DBPROP structures to determine
		/// which properties were not set. None of the satisfiable properties are remembered. The method can fail to set properties for any
		/// of the reasons specified in DB_S_ERRORSOCCURRED.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_E_NOCOLUMN A column specified by *pColumnIDin an element of rgIndexColumnDescs does not exist in the specified table.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_E_NOTABLE The specified table does not exist in the data store.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_SEC_E_PERMISSIONDENIED The consumer did not have sufficient permission to create the index.</para>
		/// </description>
		/// </item>
		/// </list>
		/// </returns>
		// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/ms712936(v=vs.85) HRESULT CreateIndex( DBID *pTableID, DBID
		// *pIndexID, DBORDINAL cIndexColumnDescs, const DBINDEXCOLUMNDESC rgIndexColumnDescs[], ULONG cPropertySets, DBPROPSET
		// rgPropertySets[], DBID **ppIndexID);
		[PreserveSig]
		HRESULT CreateIndex(in DBID pTableID, [In, Optional] IntPtr pIndexID, DBORDINAL cIndexColumnDescs,
			[In, MarshalAs(UnmanagedType.LPArray)] DBINDEXCOLUMNDESC[] rgIndexColumnDescs, uint cPropertySets,
			[In, Out] SafeDBPROPSETListHandle rgPropertySets, out SafeIMallocHandle ppIndexID);

		/// <summary>Drops an index from the base table.</summary>
		/// <param name="pTableID">[in] A pointer to the DBID of the base table.</param>
		/// <param name="pIndexID">
		/// [in] A pointer to the DBID of the index to drop. This must be an index on the table specified with pTableID. If pIndexId is a
		/// null pointer, all indexes for the table specified with pTableID are dropped.
		/// </param>
		/// <returns>
		/// <list type="bullet">
		/// <item>
		/// <description>
		/// <para>S_OK The method succeeded, and the index has been dropped from the base table.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// DB_S_ERRORSOCCURRED pIndexID was a null pointer, at least one index was successfully dropped, but one or more indexes for the
		/// specified table could not be dropped. The consumer can determine the set of indexes not dropped through the INDEXES schema rowset.
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
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_E_ERRORSOCCURRED pIndexID was a null pointer, but none of the indexes for the specified table could be dropped.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_E_INDEXINUSE The specified index was in use.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_E_NOINDEX The specified index does not exist in the current data store or did not apply to the specified table.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_E_NOTABLE The specified table does not exist in the current data store.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_E_TABLEINUSE The specified table was in use, and the provider could not drop the index with the table open.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_SEC_E_PERMISSIONDENIED The consumer did not have sufficient permission to drop the index.</para>
		/// </description>
		/// </item>
		/// </list>
		/// </returns>
		// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/ms722733(v=vs.85) HRESULT DropIndex( DBID *pTableID, DBID *pIndexID);
		[PreserveSig]
		HRESULT DropIndex(in DBID pTableID, [In, Optional] IntPtr pIndexID);
	}

	/// <summary>
	/// <c>IMultipleResults</c> is used to retrieve multiple results (row counts, rowset objects, or row objects) created by a command. For
	/// more information, see Multiple Results.
	/// </summary>
	// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/ms721289(v=vs.85)
	[PInvokeData("oledb.h")]
	[ComImport, Guid("0c733a90-2a1c-11ce-ade5-00aa0044773d"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IMultipleResults
	{
		/// <summary>Returns the next in a series of multiple results from the provider.</summary>
		/// <param name="pUnkOuter">
		/// [in] A pointer to the controlling <c>IUnknown</c> interface if the object is being created as part of an aggregate; otherwise, it
		/// is a null pointer.
		/// </param>
		/// <param name="lResultFlag">
		/// <para>
		/// [in] This flag is ignored when returning row counts. When returning result objects (for example, rowset or row objects), the
		/// values described in the following table apply.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <description>Enum</description>
		/// <description>Description</description>
		/// </listheader>
		/// <item>
		/// <description>DBRESULTFLAG_DEFAULT</description>
		/// <description>
		/// The type of the returned object is defined by <c>riid</c> or by properties set on the command object. If this is ambiguous, the
		/// provider should return a rowset. Prior to OLE DB 2.6, providers were required to return E_INVALIDARG when <c>lResultFlag</c> was
		/// not zero. Consumers should not pass nonzero values unless the provider is a 2.6 or later provider and has added support for <c>lResultFlag</c>.
		/// </description>
		/// </item>
		/// <item>
		/// <description>DBRESULTFLAG_ROWSET</description>
		/// <description>The consumer explicitly requests a rowset object.</description>
		/// </item>
		/// <item>
		/// <description>DBRESULTFLAG_ROW</description>
		/// <description>The consumer explicitly requests a row object.</description>
		/// </item>
		/// </list>
		/// <para>
		/// Providers that support the return of row objects from <c>ICommand::Execute</c> and also support multiple results should support
		/// returning row objects from calls to <c>IMultipleResults::GetResult</c>, as described by the flag values in the preceding table.
		/// </para>
		/// <para>
		/// As in <c>ICommand::Execute</c>, when returning a row object from <c>IMultipleResults::GetResult</c>, if the statement would have
		/// returned multiple rows, the provider is encouraged, but not required, to return DB_S_NOTSINGLETON.
		/// </para>
		/// <para>If lResultFlag is not zero and the riid does not match the requested object type, the provider should return E_NOINTERFACE.</para>
		/// <para>
		/// If lResultFlag is not zero and a command property (for example, DBPROP_IRow or DBPROP_IRowset) conflicts with the requested
		/// object type, the provider should return DB_S_ERRORSOCCURRED with a suitable DBPROPSTATUS value, such as DBPROPSTATUS_CONFLICTING
		/// if the property is optional, or DB_E_ERRORSOCCURRED if the property is required.
		/// </para>
		/// </param>
		/// <param name="riid">
		/// <para>
		/// [in] The requested interface to return in *ppRowset. This interface is conceptually added to the list of required interfaces on
		/// the resulting rowset, and the method fails (E_NOINTERFACE) if that interface cannot be supported on the resulting rowset.
		/// </para>
		/// <para>If this is IID_NULL, ppRowset is ignored and no rowset is returned, even if one exists.</para>
		/// </param>
		/// <param name="pcRowsAffected">
		/// <para>
		/// [out] A pointer to memory in which to return the count of rows affected by an update, delete, or insert. If the value of
		/// cParamSets passed into <c>ICommand::Execute</c> was greater than 1, *pcRowsAffected is the total number of rows affected by all
		/// of the sets of parameters represented by the current result. If the count of affected rows is not available, *pcRowsAffected is
		/// set to DB_COUNTUNAVAILABLE on output. If the result is not a count of rows affected by an update, delete, or insert,
		/// *pcRowsAffected is undefined on output. If an error occurs, *pcRowsAffected is set to DB_COUNTUNAVAILABLE. If pcRowsAffected is a
		/// null pointer, no count of affected rows is returned.
		/// </para>
		/// <para>
		/// Some providers do not support returning individual counts of rows but instead return an overall count of the total rows affected
		/// by the call to <c>ICommand::Execute</c>, or they do not return row counts at all. Such providers set *pcRowsAffected to
		/// DB_COUNTUNAVAILABLE when the count of affected rows is not available.
		/// </para>
		/// </param>
		/// <param name="ppRowset">
		/// <para>
		/// [out] A pointer to memory in which to return the interface for the next result. If the next result is not a rowset (for example,
		/// if it is the count of the rows affected by an update, delete, or insert), this is set to a null pointer. If an error occurs,
		/// *ppRowset is set to a null pointer.
		/// </para>
		/// <para>If ppRowset is a null pointer, no rowset is created.</para>
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
		/// <para>DB_S_ERRORSOCCURRED This can be returned for either of the following reasons:</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// DB_S_NOTSINGLETON The provider supports returning row objects on <c>IMultipleResults::GetResult</c>, and the consumer requested a
		/// row object but the result was not a singleton. A row object of the first row of the rowset is returned if the provider supports
		/// returning the row object. Because returning this result may be expensive, providers are not required to do so. If
		/// DB_S_ERRORSOCCURRED also applies to the execution of this method, it takes precedence over DB_S_NOTSINGLETON.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_S_NORESULT There are no more results. *ppRowset is set to a null pointer, and *pcRowsAffected is set to ?1.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// DB_S_STOPLIMITREACHED Execution has been stopped because a resource limit has been reached. The results obtained so far have been
		/// returned. Calling <c>IMultipleResults::GetResult</c> again returns information for the next result or returns DB_S_NORESULT if no
		/// more results can be obtained, either because they do not exist or because the resource limit applies across multiple results.
		/// </para>
		/// <para>
		/// This return code takes precedence over DB_S_ERRORSOCCURRED. That is, if the conditions described here and those described in
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
		/// <para>E_INVALIDARG The value passed in for lResultFlag was invalid or not supported.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>E_NOINTERFACE The interface specified in riid was not supported on the rowset.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>E_OUTOFMEMORY The provider was unable to allocate sufficient memory in which to create the rowset.</para>
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
		/// DB_E_ABORTLIMITREACHED Execution has been aborted because a resource limit has been reached. No results have been returned.
		/// Calling <c>IMultipleResults::GetResult</c> again returns information for the next result or returns DB_S_NORESULT if no more
		/// results can be obtained, either because they do not exist or because the resource limit applies across multiple results.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// DB_E_CANTCONVERTVALUE A literal value in the command text associated with the next result could not be converted to the type of
		/// the associated column for reasons other than data overflow.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// DB_E_DATAOVERFLOW A literal value in the command text associated with the next result overflowed the type specified by the
		/// associated column.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// DB_E_ERRORSINCOMMAND The command text associated with the next result contained one or more errors. Providers should use OLE DB
		/// error objects to return details about the errors.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// DB_E_ERRORSOCCURRED The method failed due to one or more invalid input parameter values associated with the next result. To
		/// determine which input parameter values were invalid, the consumer checks the status values. For a list of status values that can
		/// be returned by this method, see "Status Values Used When Setting Data" in Status.
		/// </para>
		/// <para>
		/// The rowset was not returned because one or more properties ? for which the dwOptions element of the DBPROP structure was
		/// DBPROPOPTIONS_REQUIRED or an invalid value ? could not be satisfied.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// DB_E_INTEGRITYVIOLATION A literal value in the command text associated with the next result violated the integrity constraints
		/// for the column.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// DB_E_NOAGGREGATION pUnkOuter was not a null pointer, and the provider is an OLE DB 1.0 or 1.1 provider that does not support
		/// aggregation of the object being created.
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
		/// DB_E_OBJECTOPEN The previous rowset is still open, and the provider does not support multiple open results simultaneously.
		/// (DBPROP_MULTIPLERESULTS is DBPROPVAL_MR_SUPPORTED.)
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_SEC_E_PERMISSIONDENIED The consumer did not have sufficient permission to get the next result.</para>
		/// </description>
		/// </item>
		/// </list>
		/// </returns>
		// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/ms723081(v=vs.85) HRESULT GetResult( IUnknown *pUnkOuter,
		// DBRESULTFLAG lResultFlag, REFIID riid, DBROWCOUNT *pcRowsAffected, IUnknown **ppRowset);
		[PreserveSig]
		HRESULT GetResult([In, Optional, MarshalAs(UnmanagedType.IUnknown)] object? pUnkOuter, DBRESULTFLAG lResultFlag, in Guid riid,
			out DBROWCOUNT pcRowsAffected, [MarshalAs(UnmanagedType.IUnknown)] out object? ppRowset);
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
	/// <c>IParentRowset</c> is used to retrieve child rowsets from a hierarchical rowset. For more information, see Hierarchical Rowsets.
	/// </summary>
	// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/ms723109(v=vs.85)
	[PInvokeData("oledb.h")]
	[ComImport, Guid("0c733aaa-2a1c-11ce-ade5-00aa0044773d"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IParentRowset
	{
		/// <summary>Returns the child rowset corresponding to a chapter-valued column in the parent rowset.</summary>
		/// <param name="pUnkOuter">
		/// [in] A pointer to the controlling <c>IUnknown</c> interface if the object is being created as part of an aggregate; otherwise, it
		/// is a null pointer.
		/// </param>
		/// <param name="iOrdinal">[in] The ordinal of the chapter-valued column in the parent rowset.</param>
		/// <param name="riid">[in] The requested interface to return in *ppRowset.</param>
		/// <param name="ppRowset">
		/// [out] A pointer to memory in which to return the interface for the child rowset. If an error occurs, *ppRowset is set to a null pointer.
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
		/// <para>E_INVALIDARG ppRowset was a null pointer.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>E_NOINTERFACE The interface specified in riid was not supported on the rowset.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>E_OUTOFMEMORY The provider was unable to allocate sufficient memory in which to create the rowset.</para>
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
		/// aggregation of the rowset object being created.
		/// </para>
		/// <para>pUnkOuter was not a null pointer, and riid was not IID_IUnknown.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_E_OBJECTOPEN The referenced rowset has already been opened.</para>
		/// <para>The provider is single-chaptered, and a child rowset is still open.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_E_BADORDINAL The column specified by iOrdinal was not a chapter-valued column or did not exist.</para>
		/// </description>
		/// </item>
		/// </list>
		/// </returns>
		// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/ms711213(v=vs.85) HRESULT GetChildRowset( IUnknown *pUnkOuter,
		// DBORDINAL iOrdinal, REFIID riid, IUnknown **ppRowset);
		[PreserveSig]
		HRESULT GetChildRowset([In, Optional, MarshalAs(UnmanagedType.IUnknown)] object? pUnkOuter, DBORDINAL iOrdinal, in Guid riid,
			[Optional, MarshalAs(UnmanagedType.IUnknown)] out object? ppRowset);
	}

	/// <summary>The root binder's <c>IRegisterProvider</c> interface manages the mapping of URL schemes and prefixes to OLE DB providers.</summary>
	// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/ms716923(v=vs.85)
	[PInvokeData("oledb.h")]
	[ComImport, Guid("0c733ab9-2a1c-11ce-ade5-00aa0044773d"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IRegisterProvider
	{
		/// <summary>Returns the CLSID of the provider binder object that is mapped to a URL scheme or scheme and prefix.</summary>
		/// <param name="pwszURL">[in] The canonical URL scheme or scheme and prefix whose mapping is to be returned.</param>
		/// <param name="dwReserved">[in] Reserved for future use; caller should set this to zero.</param>
		/// <param name="pclsidProvider">
		/// [out] A pointer to the CLSID of the provider binder object that is mapped to this URL scheme or scheme and prefix.
		/// *pclsidProvider is set to DB_NULLGUID if an error code is returned.
		/// </param>
		/// <returns>
		/// <list type="bullet">
		/// <item>
		/// <description>
		/// <para>S_OK The method succeeded. pclsidProvider points to the CLSID of the provider binder object.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>S_FALSE No provider binder object was mapped to this URL scheme or scheme and prefix. *pclsidProvider is set to DB_NULLGUID.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>E_FAIL A provider-specific error occurred.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>E_INVALIDARG pwszURL or pclsidProvider was a null pointer.</para>
		/// <para>dwReserved was not 0.</para>
		/// </description>
		/// </item>
		/// </list>
		/// </returns>
		// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/ms718099(v=vs.85) HRESULT GetURLMapping( LPCOLESTR pwszURL,
		// DB_DWRESERVE dwReserved, CLSID *pclsidProvider );
		[PreserveSig]
		HRESULT GetURLMapping([In, MarshalAs(UnmanagedType.LPWStr)] string pwszURL, [In, Optional] DB_DWRESERVE dwReserved, out Guid pclsidProvider);

		/// <summary>Registers the ability of a provider binder object to process a particular URL scheme or scheme and prefix.</summary>
		/// <param name="pwszURL">[in] The canonical URL scheme or scheme and prefix to be mapped.</param>
		/// <param name="dwReserved">[in] Reserved for future use; providers should set this to zero.</param>
		/// <param name="rclsidProvider">
		/// [in] A reference to the CLSID of the provider binder object, which is to be mapped to this URL scheme or scheme and prefix.
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
		/// <para>DB_E_RESOURCEEXISTS The URL scheme or scheme and prefix combination was already mapped to a different provider binder object.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_SEC_E_PERMISSIONDENIED The caller did not have permission to register this URL mapping.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>E_FAIL A provider-specific error occurred.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>E_INVALIDARG pwszURL was a null pointer or pointed to an invalid URL.</para>
		/// <para>dwReserved was not 0.</para>
		/// </description>
		/// </item>
		/// </list>
		/// </returns>
		// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/ms719610(v=vs.85) HRESULT SetURLMapping( LPCOLESTR pwszURL,
		// DB_DWRESERVE dwReserved, REFCLSID rclsidProvider );
		[PreserveSig]
		HRESULT SetURLMapping([In, Optional] string? pwszURL, [In, Optional] DB_DWRESERVE dwReserved, [In, Optional] GuidPtr rclsidProvider);

		/// <summary>Unregisters one or more URL mappings for a provider binder object.</summary>
		/// <param name="pwszURL">
		/// [in] The canonical URL scheme or scheme and prefix to be unmapped for the provider designated by rclsidProvider. If pwszURL is a
		/// null pointer, all URL scheme or scheme and prefix combinations are unmapped for this provider.
		/// </param>
		/// <param name="dwReserved">[in] Reserved for future use; providers should set this to zero.</param>
		/// <param name="rclsidProvider">
		/// [in] A reference to the CLSID of the provider binder object for which the root binder will unregister the named URL mapping. This
		/// CLSID must be provided and is never ignored.
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
		/// <para>S_FALSE *pwszURL is a null pointer, and no scheme/prefix combinations were mapped to rclsidProvider.</para>
		/// <para>*pwszURL was specified, and no matching scheme/prefix combinations were found or were mapped to rclsidProvider.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_SEC_E_PERMISSIONDENIED The caller did not have permission to unregister URL mappings.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>E_FAIL A provider-specific error occurred.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>E_INVALIDARG pwszURL was not a well-formed or canonical URL.</para>
		/// <para>dwReserved was not 0.</para>
		/// </description>
		/// </item>
		/// </list>
		/// </returns>
		// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/ms712849(v=vs.85) HRESULT UnregisterProvider( LPCOLESTR
		// pwszURL, DB_DWRESERVE dwReserved, REFCLSID rclsidProvider );
		[PreserveSig]
		HRESULT UnregisterProvider([In, Optional] string? pwszURL, [In, Optional] DB_DWRESERVE dwReserved, [In, Optional] GuidPtr rclsidProvider);
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

	/// <summary>Information about literals is returned in the DBLITERALINFO structure.</summary>
	[PInvokeData("oledb.h")]
	[StructLayout(LayoutKind.Sequential)]
	public struct DBLITERALINFO
	{
		/// <summary>
		/// <para>A pointer to a string in the *ppCharBuffer buffer containing the actual literal value.</para>
		/// <para>
		/// For example, if lt is DBLITERAL_LIKE_PERCENT and the percent character (%) is used to match zero or more characters in a LIKE
		/// clause, this would be "%". This is used for DBLITERAL_CATALOG_SEPARATOR, DBLITERAL_ESCAPE_PERCENT_PREFIX,
		/// DBLITERAL_ESCAPE_UNDERSCORE_PREFIX, DBLITERAL_LIKE_PERCENT, DBLITERAL_LIKE_UNDERSCORE, DBLITERAL_QUOTE_PREFIX, and
		/// DBLITERAL_SCHEMA_SEPARATOR. For all other DBLITERAL values, pwszLiteralValue is not used and is set to a null pointer.
		/// </para>
		/// </summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string pwszLiteralValue;

		/// <summary>
		/// <para>A pointer to a string in the *ppCharBuffer buffer containing the characters that are not valid in the literal.</para>
		/// <para>
		/// For example, if table names can contain anything other than a numeric character, this would be "0123456789" when lt is
		/// DBLITERAL_TABLE_NAME. If the literal can contain any valid character, this is a null pointer. This is not used for
		/// DBLITERAL_CATALOG_SEPARATOR, DBLITERAL_ESCAPE_PERCENT_PREFIX, DBLITERAL_ESCAPE_UNDERSCORE_PREFIX, DBLITERAL_LIKE_PERCENT,
		/// DBLITERAL_LIKE_UNDERSCORE, DBLITERAL_QUOTE_PREFIX, and DBLITERAL_SCHEMA_SEPARATOR; pwszInvalidChars is set to a null pointer for
		/// these DBLITERAL values.
		/// </para>
		/// </summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string pwszInvalidChars;

		/// <summary>
		/// <para>
		/// A pointer to a string in the *ppCharBuffer buffer containing the characters that are not valid as the first character of the
		/// literal. If the literal can start with any valid character, this is a null pointer.
		/// </para>
		/// <para>
		/// For example, if table names can begin with anything other than a numeric character, this would be "0123456789" when lt is
		/// DBLITERAL_TABLE_NAME. This is not used for DBLITERAL_CATALOG_SEPARATOR, DBLITERAL_ESCAPE_PERCENT_PREFIX,
		/// DBLITERAL_ESCAPE_UNDERSCORE_PREFIX, DBLITERAL_LIKE_PERCENT, DBLITERAL_LIKE_UNDERSCORE, DBLITERAL_QUOTE_PREFIX, and
		/// DBLITERAL_SCHEMA_SEPARATOR; pwszInvalidStartingChars is set to a null pointer for these DBLITERAL values.
		/// </para>
		/// </summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string pwszInvalidStartingChars;

		/// <summary>The literal described in the structure. For more information, see the following section.</summary>
		public DBLITERAL lt;

		/// <summary>
		/// <para>
		/// TRUE if the provider supports the literal specified by lt. If cLiterals is 0, this is always TRUE because IDBInfo::GetLiteralInfo
		/// returns information only about literals it supports in this case.
		/// </para>
		/// <para>
		/// FALSE if the provider does not support the literal, or the value of the corresponding element of the rgLiterals array was not a
		/// valid value in the DBLITERAL enumerated type.
		/// </para>
		/// </summary>
		[MarshalAs(UnmanagedType.Bool)]
		public bool fSupported;

		/// <summary>
		/// The maximum number of characters in the literal. If there is no maximum or the maximum is unknown, cchMaxLen is set to ~0
		/// (bitwise, the value is not 0; all bits are set to 1). For DBLITERAL_CATALOG_SEPARATOR, DBLITERAL_ESCAPE_PERCENT_PREFIX,
		/// DBLITERAL_ESCAPE_UNDERSCORE_PREFIX, DBLITERAL_LIKE_PERCENT, DBLITERAL_LIKE_UNDERSCORE, DBLITERAL_QUOTE_PREFIX, and
		/// DBLITERAL_SCHEMA_SEPARATOR, this is the actual number of characters in the literal.
		/// </summary>
		public uint cchMaxLen;
	}
}