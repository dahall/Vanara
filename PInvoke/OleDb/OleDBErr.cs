using static Vanara.PInvoke.OleAut32;

namespace Vanara.PInvoke;

public static partial class OleDb
{
	static OleDb()
	{
		StaticFieldValueHash.AddFields<HRESULT, int, OleDbErr>(Lib_OleDb);
		ErrorHelper.AddErrorMessageLookupFunction<OleDbErr>(GetOleDbErrMsg);
	}

	private static string GetOleDbErrMsg(uint val, string? lib)
	{
		try
		{
			// Obtain the current Error object, if any, by using the OLE Automation GetErrorInfo function, which will give us back an
			// IErrorInfo interface pointer if successful
			GetErrorInfo(0, out var pIErrorInfo).ThrowIfFailed();

			// We've got the IErrorInfo interface pointer on the Error object
			if (pIErrorInfo is not null)
			{
				// OLE DB extends the OLE Automation error model by allowing Error objects to support the IErrorRecords interface; this
				// interface can expose information on multiple errors.
				//IErrorRecords? pIErrorRecords = pIErrorInfo as IErrorRecords;
				//if (pIErrorRecords is not null)
				//{
				//	StringBuilder sb = new(1024);
				//	// Loop through the set of error records and display the error information for each one
				//	for (uint iRecord = 0; iRecord < pIErrorRecords.GetRecordCount(); iRecord++)
				//	{
				//		pIErrorInfo = pIErrorRecords.GetErrorInfo(iRecord, LCID.LOCALE_USER_DEFAULT);
				//		pIErrorInfo.GetDescription(out var bstrDescription).ThrowIfFailed();
				//		sb.AppendLine(bstrDescription);
				//	}
				//	return sb.ToString();
				//}
				// The object didn't support IErrorRecords; display the error information for this single error
				//else
				//{
					// Get the description of the error
					pIErrorInfo.GetDescription(out var bstrDescription).ThrowIfFailed();
					return bstrDescription;
				//}
			}
		}
		catch
		{
		}

		return "";
	}

	private static void myDisplayErrorRecord(HRESULT hrReturned, uint iRecord, IErrorRecords pIErrorRecords)
	{
	}

	private static void myGetSqlErrorInfo(uint iRecord, IErrorRecords pIErrorRecords, out string? pBstr, out int plNativeError)
	{
		// Attempt to get the ISQLErrorInfo interface for this error record through GetCustomErrorObject. Note that ISQLErrorInfo is not
		// mandatory, so failure is acceptable here
		pIErrorRecords.GetCustomErrorObject(iRecord, //iRecord
			typeof(ISQLErrorInfo).GUID, //riid
			out var pISQLErrorInfo); //ppISQLErrorInfo

		// If we obtained the ISQLErrorInfo interface, get the SQL error string and native error code for this error
		if (pISQLErrorInfo is not null)
			((ISQLErrorInfo)pISQLErrorInfo).GetSQLInfo(out pBstr, out plNativeError);
		else { pBstr = null; plNativeError = 0; }
	}

	/// <summary>HRESULT values for OLE DB errors. These values are returned by OLE DB methods.</summary>
	[PInvokeData("oledberr.h")]
	public enum OleDbErr
	{
		/// <summary>Accessor is invalid.</summary>
		DB_E_BADACCESSORHANDLE = unchecked((int)0x80040E00),

		/// <summary>Row could not be inserted into the rowset without exceeding provider's maximum number of active rows.</summary>
		DB_E_ROWLIMITEXCEEDED = unchecked((int)0x80040E01),

		/// <summary>Accessor is read-only. Operation failed.</summary>
		DB_E_READONLYACCESSOR = unchecked((int)0x80040E02),

		/// <summary>Values violate the database schema.</summary>
		DB_E_SCHEMAVIOLATION = unchecked((int)0x80040E03),

		/// <summary>Row handle is invalid.</summary>
		DB_E_BADROWHANDLE = unchecked((int)0x80040E04),

		/// <summary>Object was open.</summary>
		DB_E_OBJECTOPEN = unchecked((int)0x80040E05),

		/// <summary>Chapter is invalid.</summary>
		DB_E_BADCHAPTER = unchecked((int)0x80040E06),

		/// <summary>
		/// Data or literal value could not be converted to the type of the column in the data source, and the provider was unable to
		/// determine which columns could not be converted. Data overflow or sign mismatch was not the cause.
		/// </summary>
		DB_E_CANTCONVERTVALUE = unchecked((int)0x80040E07),

		/// <summary>Binding information is invalid.</summary>
		DB_E_BADBINDINFO = unchecked((int)0x80040E08),

		/// <summary>Permission denied.</summary>
		DB_SEC_E_PERMISSIONDENIED = unchecked((int)0x80040E09),

		/// <summary>Column does not contain bookmarks or chapters.</summary>
		DB_E_NOTAREFERENCECOLUMN = unchecked((int)0x80040E0A),

		/// <summary>Cost limits were rejected.</summary>
		DB_E_LIMITREJECTED = unchecked((int)0x80040E0B),

		/// <summary>Command text was not set for the command object.</summary>
		DB_E_NOCOMMAND = unchecked((int)0x80040E0C),

		/// <summary>Query plan within the cost limit cannot be found.</summary>
		DB_E_COSTLIMIT = unchecked((int)0x80040E0D),

		/// <summary>Bookmark is invalid.</summary>
		DB_E_BADBOOKMARK = unchecked((int)0x80040E0E),

		/// <summary>Lock mode is invalid.</summary>
		DB_E_BADLOCKMODE = unchecked((int)0x80040E0F),

		/// <summary>No value given for one or more required parameters.</summary>
		DB_E_PARAMNOTOPTIONAL = unchecked((int)0x80040E10),

		/// <summary>Column ID is invalid.</summary>
		DB_E_BADCOLUMNID = unchecked((int)0x80040E11),

		/// <summary>Numerator was greater than denominator. Values must express ratio between zero and 1.</summary>
		DB_E_BADRATIO = unchecked((int)0x80040E12),

		/// <summary>Value is invalid.</summary>
		DB_E_BADVALUES = unchecked((int)0x80040E13),

		/// <summary>One or more errors occurred during processing of command.</summary>
		DB_E_ERRORSINCOMMAND = unchecked((int)0x80040E14),

		/// <summary>Command cannot be canceled.</summary>
		DB_E_CANTCANCEL = unchecked((int)0x80040E15),

		/// <summary>Command dialect is not supported by this provider.</summary>
		DB_E_DIALECTNOTSUPPORTED = unchecked((int)0x80040E16),

		/// <summary>Data source object could not be created because the named data source already exists.</summary>
		DB_E_DUPLICATEDATASOURCE = unchecked((int)0x80040E17),

		/// <summary>Rowset position cannot be restarted.</summary>
		DB_E_CANNOTRESTART = unchecked((int)0x80040E18),

		/// <summary>Object or data matching the name, range, or selection criteria was not found within the scope of this operation.</summary>
		DB_E_NOTFOUND = unchecked((int)0x80040E19),

		/// <summary>Identity cannot be determined for newly inserted rows.</summary>
		DB_E_NEWLYINSERTED = unchecked((int)0x80040E1B),

		/// <summary>Provider has ownership of this tree.</summary>
		DB_E_CANNOTFREE = unchecked((int)0x80040E1A),

		/// <summary>Goal was rejected because no nonzero weights were specified for any goals supported. Current goal was not changed.</summary>
		DB_E_GOALREJECTED = unchecked((int)0x80040E1C),

		/// <summary>Requested conversion is not supported.</summary>
		DB_E_UNSUPPORTEDCONVERSION = unchecked((int)0x80040E1D),

		/// <summary>No rows were returned because the offset value moves the position before the beginning or after the end of the rowset.</summary>
		DB_E_BADSTARTPOSITION = unchecked((int)0x80040E1E),

		/// <summary>Information was requested for a query and the query was not set.</summary>
		DB_E_NOQUERY = unchecked((int)0x80040E1F),

		/// <summary>Consumer's event handler called a non-reentrant method in the provider.</summary>
		DB_E_NOTREENTRANT = unchecked((int)0x80040E20),

		/// <summary>Multiple-step OLE DB operation generated errors. Check each OLE DB status value, if available. No work was done.</summary>
		DB_E_ERRORSOCCURRED = unchecked((int)0x80040E21),

		/// <summary>
		/// Non-NULL controlling IUnknown was specified, and either the requested interface was not IUnknown, or the provider does not
		/// support COM aggregation.
		/// </summary>
		DB_E_NOAGGREGATION = unchecked((int)0x80040E22),

		/// <summary>Row handle referred to a deleted row or a row marked for deletion.</summary>
		DB_E_DELETEDROW = unchecked((int)0x80040E23),

		/// <summary>Rowset does not support fetching backward.</summary>
		DB_E_CANTFETCHBACKWARDS = unchecked((int)0x80040E24),

		/// <summary>Row handles must all be released before new ones can be obtained.</summary>
		DB_E_ROWSNOTRELEASED = unchecked((int)0x80040E25),

		/// <summary>One or more storage flags are not supported.</summary>
		DB_E_BADSTORAGEFLAG = unchecked((int)0x80040E26),

		/// <summary>Comparison operator is invalid.</summary>
		DB_E_BADCOMPAREOP = unchecked((int)0x80040E27),

		/// <summary>Status flag was neither DBCOLUMNSTATUS_OK nor DBCOLUMNSTATUS_ISNULL.</summary>
		DB_E_BADSTATUSVALUE = unchecked((int)0x80040E28),

		/// <summary>Rowset does not support scrolling backward.</summary>
		DB_E_CANTSCROLLBACKWARDS = unchecked((int)0x80040E29),

		/// <summary>Region handle is invalid.</summary>
		DB_E_BADREGIONHANDLE = unchecked((int)0x80040E2A),

		/// <summary>Set of rows is not contiguous to, or does not overlap, the rows in the watch region.</summary>
		DB_E_NONCONTIGUOUSRANGE = unchecked((int)0x80040E2B),

		/// <summary>Transition from ALL* to MOVE* or EXTEND* was specified.</summary>
		DB_E_INVALIDTRANSITION = unchecked((int)0x80040E2C),

		/// <summary>Region is not a proper subregion of the region identified by the watch region handle.</summary>
		DB_E_NOTASUBREGION = unchecked((int)0x80040E2D),

		/// <summary>Multiple-statement commands are not supported by this provider.</summary>
		DB_E_MULTIPLESTATEMENTS = unchecked((int)0x80040E2E),

		/// <summary>Value violated the integrity constraints for a column or table.</summary>
		DB_E_INTEGRITYVIOLATION = unchecked((int)0x80040E2F),

		/// <summary>Type name is invalid.</summary>
		DB_E_BADTYPENAME = unchecked((int)0x80040E30),

		/// <summary>Execution stopped because a resource limit was reached. No results were returned.</summary>
		DB_E_ABORTLIMITREACHED = unchecked((int)0x80040E31),

		/// <summary>Command object whose command tree contains a rowset or rowsets cannot be cloned.</summary>
		DB_E_ROWSETINCOMMAND = unchecked((int)0x80040E32),

		/// <summary>Current tree cannot be represented as text.</summary>
		DB_E_CANTTRANSLATE = unchecked((int)0x80040E33),

		/// <summary>Index already exists.</summary>
		DB_E_DUPLICATEINDEXID = unchecked((int)0x80040E34),

		/// <summary>Index does not exist.</summary>
		DB_E_NOINDEX = unchecked((int)0x80040E35),

		/// <summary>Index is in use.</summary>
		DB_E_INDEXINUSE = unchecked((int)0x80040E36),

		/// <summary>Table does not exist.</summary>
		DB_E_NOTABLE = unchecked((int)0x80040E37),

		/// <summary>Rowset used optimistic concurrency and the value of a column has changed since it was last read.</summary>
		DB_E_CONCURRENCYVIOLATION = unchecked((int)0x80040E38),

		/// <summary>Errors detected during the copy.</summary>
		DB_E_BADCOPY = unchecked((int)0x80040E39),

		/// <summary>Precision is invalid.</summary>
		DB_E_BADPRECISION = unchecked((int)0x80040E3A),

		/// <summary>Scale is invalid.</summary>
		DB_E_BADSCALE = unchecked((int)0x80040E3B),

		/// <summary>Table ID is invalid.</summary>
		DB_E_BADTABLEID = unchecked((int)0x80040E3C),

		/// <summary>Type is invalid.</summary>
		DB_E_BADTYPE = unchecked((int)0x80040E3D),

		/// <summary>Column ID already exists or occurred more than once in the array of columns.</summary>
		DB_E_DUPLICATECOLUMNID = unchecked((int)0x80040E3E),

		/// <summary>Table already exists.</summary>
		DB_E_DUPLICATETABLEID = unchecked((int)0x80040E3F),

		/// <summary>Table is in use.</summary>
		DB_E_TABLEINUSE = unchecked((int)0x80040E40),

		/// <summary>Locale ID is not supported.</summary>
		DB_E_NOLOCALE = unchecked((int)0x80040E41),

		/// <summary>Record number is invalid.</summary>
		DB_E_BADRECORDNUM = unchecked((int)0x80040E42),

		/// <summary>Form of bookmark is valid, but no row was found to match it.</summary>
		DB_E_BOOKMARKSKIPPED = unchecked((int)0x80040E43),

		/// <summary>Property value is invalid.</summary>
		DB_E_BADPROPERTYVALUE = unchecked((int)0x80040E44),

		/// <summary>Rowset is not chaptered.</summary>
		DB_E_INVALID = unchecked((int)0x80040E45),

		/// <summary>One or more accessor flags were invalid.</summary>
		DB_E_BADACCESSORFLAGS = unchecked((int)0x80040E46),

		/// <summary>One or more storage flags are invalid.</summary>
		DB_E_BADSTORAGEFLAGS = unchecked((int)0x80040E47),

		/// <summary>Reference accessors are not supported by this provider.</summary>
		DB_E_BYREFACCESSORNOTSUPPORTED = unchecked((int)0x80040E48),

		/// <summary>Null accessors are not supported by this provider.</summary>
		DB_E_NULLACCESSORNOTSUPPORTED = unchecked((int)0x80040E49),

		/// <summary>Command was not prepared.</summary>
		DB_E_NOTPREPARED = unchecked((int)0x80040E4A),

		/// <summary>Accessor is not a parameter accessor.</summary>
		DB_E_BADACCESSORTYPE = unchecked((int)0x80040E4B),

		/// <summary>Accessor is write-only.</summary>
		DB_E_WRITEONLYACCESSOR = unchecked((int)0x80040E4C),

		/// <summary>Authentication failed.</summary>
		DB_SEC_E_AUTH_FAILED = unchecked((int)0x80040E4D),

		/// <summary>Operation was canceled.</summary>
		DB_E_CANCELED = unchecked((int)0x80040E4E),

		/// <summary>Rowset is single-chaptered. The chapter was not released.</summary>
		DB_E_CHAPTERNOTRELEASED = unchecked((int)0x80040E4F),

		/// <summary>Source handle is invalid.</summary>
		DB_E_BADSOURCEHANDLE = unchecked((int)0x80040E50),

		/// <summary>Provider cannot derive parameter information and SetParameterInfo has not been called.</summary>
		DB_E_PARAMUNAVAILABLE = unchecked((int)0x80040E51),

		/// <summary>Data source object is already initialized.</summary>
		DB_E_ALREADYINITIALIZED = unchecked((int)0x80040E52),

		/// <summary>Method is not supported by this provider.</summary>
		DB_E_NOTSUPPORTED = unchecked((int)0x80040E53),

		/// <summary>Number of rows with pending changes exceeded the limit.</summary>
		DB_E_MAXPENDCHANGESEXCEEDED = unchecked((int)0x80040E54),

		/// <summary>Column does not exist.</summary>
		DB_E_BADORDINAL = unchecked((int)0x80040E55),

		/// <summary>Pending changes exist on a row with a reference count of zero.</summary>
		DB_E_PENDINGCHANGES = unchecked((int)0x80040E56),

		/// <summary>Literal value in the command exceeded the range of the type of the associated column.</summary>
		DB_E_DATAOVERFLOW = unchecked((int)0x80040E57),

		/// <summary>HRESULT is invalid.</summary>
		DB_E_BADHRESULT = unchecked((int)0x80040E58),

		/// <summary>Lookup ID is invalid.</summary>
		DB_E_BADLOOKUPID = unchecked((int)0x80040E59),

		/// <summary>DynamicError ID is invalid.</summary>
		DB_E_BADDYNAMICERRORID = unchecked((int)0x80040E5A),

		/// <summary>Most recent data for a newly inserted row could not be retrieved because the insert is pending.</summary>
		DB_E_PENDINGINSERT = unchecked((int)0x80040E5B),

		/// <summary>Conversion flag is invalid.</summary>
		DB_E_BADCONVERTFLAG = unchecked((int)0x80040E5C),

		/// <summary>Parameter name is unrecognized.</summary>
		DB_E_BADPARAMETERNAME = unchecked((int)0x80040E5D),

		/// <summary>Multiple storage objects cannot be open simultaneously.</summary>
		DB_E_MULTIPLESTORAGE = unchecked((int)0x80040E5E),

		/// <summary>Filter cannot be opened.</summary>
		DB_E_CANTFILTER = unchecked((int)0x80040E5F),

		/// <summary>Order cannot be opened.</summary>
		DB_E_CANTORDER = unchecked((int)0x80040E60),

		/// <summary>Tuple is invalid.</summary>
		MD_E_BADTUPLE = unchecked((int)0x80040E61),

		/// <summary>Coordinate is invalid.</summary>
		MD_E_BADCOORDINATE = unchecked((int)0x80040E62),

		/// <summary>Axis is invalid.</summary>
		MD_E_INVALIDAXIS = unchecked((int)0x80040E63),

		/// <summary>One or more cell ordinals is invalid.</summary>
		MD_E_INVALIDCELLRANGE = unchecked((int)0x80040E64),

		/// <summary>Column ID is invalid.</summary>
		DB_E_NOCOLUMN = unchecked((int)0x80040E65),

		/// <summary>Command does not have a DBID.</summary>
		DB_E_COMMANDNOTPERSISTED = unchecked((int)0x80040E67),

		/// <summary>DBID already exists.</summary>
		DB_E_DUPLICATEID = unchecked((int)0x80040E68),

		/// <summary>
		/// Session cannot be created because maximum number of active sessions was already reached. Consumer must release one or more
		/// sessions before creating a new session object.
		/// </summary>
		DB_E_OBJECTCREATIONLIMITREACHED = unchecked((int)0x80040E69),

		/// <summary>Index ID is invalid.</summary>
		DB_E_BADINDEXID = unchecked((int)0x80040E72),

		/// <summary>Format of the initialization string does not conform to the OLE DB specification.</summary>
		DB_E_BADINITSTRING = unchecked((int)0x80040E73),

		/// <summary>No OLE DB providers of this source type are registered.</summary>
		DB_E_NOPROVIDERSREGISTERED = unchecked((int)0x80040E74),

		/// <summary>Initialization string specifies a provider that does not match the active provider.</summary>
		DB_E_MISMATCHEDPROVIDER = unchecked((int)0x80040E75),

		/// <summary>DBID is invalid.</summary>
		DB_E_BADCOMMANDID = unchecked((int)0x80040E76),

		/// <summary>Trustee is invalid.</summary>
		SEC_E_BADTRUSTEEID = unchecked((int)0x80040E6A),

		/// <summary>Trustee was not recognized for this data source.</summary>
		SEC_E_NOTRUSTEEID = unchecked((int)0x80040E6B),

		/// <summary>Trustee does not support memberships or collections.</summary>
		SEC_E_NOMEMBERSHIPSUPPORT = unchecked((int)0x80040E6C),

		/// <summary>Object is invalid or unknown to the provider.</summary>
		SEC_E_INVALIDOBJECT = unchecked((int)0x80040E6D),

		/// <summary>Object does not have an owner.</summary>
		SEC_E_NOOWNER = unchecked((int)0x80040E6E),

		/// <summary>Access entry list is invalid.</summary>
		SEC_E_INVALIDACCESSENTRYLIST = unchecked((int)0x80040E6F),

		/// <summary>Trustee supplied as owner is invalid or unknown to the provider.</summary>
		SEC_E_INVALIDOWNER = unchecked((int)0x80040E70),

		/// <summary>Permission in the access entry list is invalid.</summary>
		SEC_E_INVALIDACCESSENTRY = unchecked((int)0x80040E71),

		/// <summary>ConstraintType is invalid or not supported by the provider.</summary>
		DB_E_BADCONSTRAINTTYPE = unchecked((int)0x80040E77),

		/// <summary>ConstraintType is not DBCONSTRAINTTYPE_FOREIGNKEY and cForeignKeyColumns is not zero.</summary>
		DB_E_BADCONSTRAINTFORM = unchecked((int)0x80040E78),

		/// <summary>Specified deferrability flag is invalid or not supported by the provider.</summary>
		DB_E_BADDEFERRABILITY = unchecked((int)0x80040E79),

		/// <summary>MatchType is invalid or the value is not supported by the provider.</summary>
		DB_E_BADMATCHTYPE = unchecked((int)0x80040E80),

		/// <summary>Constraint update rule or delete rule is invalid.</summary>
		DB_E_BADUPDATEDELETERULE = unchecked((int)0x80040E8A),

		/// <summary>Constraint ID is invalid.</summary>
		DB_E_BADCONSTRAINTID = unchecked((int)0x80040E8B),

		/// <summary>Command persistence flag is invalid.</summary>
		DB_E_BADCOMMANDFLAGS = unchecked((int)0x80040E8C),

		/// <summary>rguidColumnType points to a GUID that does not match the object type of this column, or this column was not set.</summary>
		DB_E_OBJECTMISMATCH = unchecked((int)0x80040E8D),

		/// <summary>Source row does not exist.</summary>
		DB_E_NOSOURCEOBJECT = unchecked((int)0x80040E91),

		/// <summary>OLE DB object represented by this URL is locked by one or more other processes.</summary>
		DB_E_RESOURCELOCKED = unchecked((int)0x80040E92),

		/// <summary>Client requested an object type that is valid only for a collection.</summary>
		DB_E_NOTCOLLECTION = unchecked((int)0x80040E93),

		/// <summary>Caller requested write access to a read-only object.</summary>
		DB_E_READONLY = unchecked((int)0x80040E94),

		/// <summary>Asynchronous binding is not supported by this provider.</summary>
		DB_E_ASYNCNOTSUPPORTED = unchecked((int)0x80040E95),

		/// <summary>Connection to the server for this URL cannot be established.</summary>
		DB_E_CANNOTCONNECT = unchecked((int)0x80040E96),

		/// <summary>Timeout occurred when attempting to bind to the object.</summary>
		DB_E_TIMEOUT = unchecked((int)0x80040E97),

		/// <summary>Object cannot be created at this URL because an object named by this URL already exists.</summary>
		DB_E_RESOURCEEXISTS = unchecked((int)0x80040E98),

		/// <summary>URL is outside of scope.</summary>
		DB_E_RESOURCEOUTOFSCOPE = unchecked((int)0x80040E8E),

		/// <summary>Column or constraint could not be dropped because it is referenced by a dependent view or constraint.</summary>
		DB_E_DROPRESTRICTED = unchecked((int)0x80040E90),

		/// <summary>Constraint already exists.</summary>
		DB_E_DUPLICATECONSTRAINTID = unchecked((int)0x80040E99),

		/// <summary>Object cannot be created at this URL because the server is out of physical storage.</summary>
		DB_E_OUTOFSPACE = unchecked((int)0x80040E9A),

		/// <summary>Safety settings on this computer prohibit accessing a data source on another domain.</summary>
		DB_SEC_E_SAFEMODE_DENIED = unchecked((int)0x80040E9B),

		/// <summary>
		/// The specified statistic does not exist in the current data source or did not apply to the specified table or it does not support
		/// a histogram.
		/// </summary>
		DB_E_NOSTATISTIC = unchecked((int)0x80040E9C),

		/// <summary>Column or table could not be altered because it is referenced by a constraint.</summary>
		DB_E_ALTERRESTRICTED = unchecked((int)0x80040E9D),

		/// <summary>Requested object type is not supported by the provider.</summary>
		DB_E_RESOURCENOTSUPPORTED = unchecked((int)0x80040E9E),

		/// <summary>Constraint does not exist.</summary>
		DB_E_NOCONSTRAINT = unchecked((int)0x80040E9F),

		/// <summary>
		/// Requested column is valid, but could not be retrieved. This could be due to a forward only cursor attempting to go backwards in a row.
		/// </summary>
		DB_E_COLUMNUNAVAILABLE = unchecked((int)0x80040EA0),

		/// <summary>Fetching requested number of rows will exceed total number of active rows supported by the rowset.</summary>
		DB_S_ROWLIMITEXCEEDED = unchecked(0x00040EC0),

		/// <summary>One or more column types are incompatible. Conversion errors will occur during copying.</summary>
		DB_S_COLUMNTYPEMISMATCH = unchecked(0x00040EC1),

		/// <summary>Parameter type information was overridden by caller.</summary>
		DB_S_TYPEINFOOVERRIDDEN = unchecked(0x00040EC2),

		/// <summary>Bookmark was skipped for deleted or nonmember row.</summary>
		DB_S_BOOKMARKSKIPPED = unchecked(0x00040EC3),

		/// <summary>No more rowsets.</summary>
		DB_S_NONEXTROWSET = unchecked(0x00040EC5),

		/// <summary>Start or end of rowset or chapter was reached.</summary>
		DB_S_ENDOFROWSET = unchecked(0x00040EC6),

		/// <summary>Command was reexecuted.</summary>
		DB_S_COMMANDREEXECUTED = unchecked(0x00040EC7),

		/// <summary>Operation succeeded, but status array or string buffer could not be allocated.</summary>
		DB_S_BUFFERFULL = unchecked(0x00040EC8),

		/// <summary>No more results.</summary>
		DB_S_NORESULT = unchecked(0x00040EC9),

		/// <summary>Server cannot release or downgrade a lock until the end of the transaction.</summary>
		DB_S_CANTRELEASE = unchecked(0x00040ECA),

		/// <summary>Weight is not supported or exceeded the supported limit, and was set to 0 or the supported limit.</summary>
		DB_S_GOALCHANGED = unchecked(0x00040ECB),

		/// <summary>Consumer does not want to receive further notification calls for this operation.</summary>
		DB_S_UNWANTEDOPERATION = unchecked(0x00040ECC),

		/// <summary>Input dialect was ignored and command was processed using default dialect.</summary>
		DB_S_DIALECTIGNORED = unchecked(0x00040ECD),

		/// <summary>Consumer does not want to receive further notification calls for this phase.</summary>
		DB_S_UNWANTEDPHASE = unchecked(0x00040ECE),

		/// <summary>Consumer does not want to receive further notification calls for this reason.</summary>
		DB_S_UNWANTEDREASON = unchecked(0x00040ECF),

		/// <summary>Operation is being processed asynchronously.</summary>
		DB_S_ASYNCHRONOUS = unchecked(0x00040ED0),

		/// <summary>
		/// Command was executed to reposition to the start of the rowset. Either the order of the columns changed, or columns were added to
		/// or removed from the rowset.
		/// </summary>
		DB_S_COLUMNSCHANGED = unchecked(0x00040ED1),

		/// <summary>Method had some errors, which were returned in the error array.</summary>
		DB_S_ERRORSRETURNED = unchecked(0x00040ED2),

		/// <summary>Row handle is invalid.</summary>
		DB_S_BADROWHANDLE = unchecked(0x00040ED3),

		/// <summary>Row handle referred to a deleted row.</summary>
		DB_S_DELETEDROW = unchecked(0x00040ED4),

		/// <summary>
		/// Provider cannot keep track of all the changes. Client must refetch the data associated with the watch region by using another method.
		/// </summary>
		DB_S_TOOMANYCHANGES = unchecked(0x00040ED5),

		/// <summary>
		/// Execution stopped because a resource limit was reached. Results obtained so far were returned, but execution cannot resume.
		/// </summary>
		DB_S_STOPLIMITREACHED = unchecked(0x00040ED6),

		/// <summary>Lock was upgraded from the value specified.</summary>
		DB_S_LOCKUPGRADED = unchecked(0x00040ED8),

		/// <summary>One or more properties were changed as allowed by provider.</summary>
		DB_S_PROPERTIESCHANGED = unchecked(0x00040ED9),

		/// <summary>Multiple-step operation completed with one or more errors. Check each status value.</summary>
		DB_S_ERRORSOCCURRED = unchecked(0x00040EDA),

		/// <summary>Parameter is invalid.</summary>
		DB_S_PARAMUNAVAILABLE = unchecked(0x00040EDB),

		/// <summary>Updating a row caused more than one row to be updated in the data source.</summary>
		DB_S_MULTIPLECHANGES = unchecked(0x00040EDC),

		/// <summary>Row object was requested on a non-singleton result. First row was returned.</summary>
		DB_S_NOTSINGLETON = unchecked(0x00040ED7),

		/// <summary>Row has no row-specific columns.</summary>
		DB_S_NOROWSPECIFICCOLUMNS = unchecked(0x00040EDD),
	}
}