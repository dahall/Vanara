namespace Vanara.PInvoke;

/// <summary>Items from the Msi.dll</summary>
public static partial class Msi
{
	/// <summary>
	/// A value returned from <see cref="MsiRecordGetInteger"/> when the field is null or if the field is a string that cannot be
	/// converted to an integer.
	/// </summary>
	public const int MSI_NULL_INTEGER = unchecked((int)0x80000000);

	/// <summary>Create a new database, transact mode read/write.</summary>
	public static readonly IntPtr MSIDBOPEN_CREATE = (IntPtr)3;

	/// <summary>Create a new database, direct mode read/write.</summary>
	public static readonly IntPtr MSIDBOPEN_CREATEDIRECT = (IntPtr)4;

	/// <summary>Open a database direct read/write without transaction.</summary>
	public static readonly IntPtr MSIDBOPEN_DIRECT = (IntPtr)2;

	/// <summary>Add this flag to indicate a patch file.</summary>
	public static readonly IntPtr MSIDBOPEN_PATCHFILE = (IntPtr)(32 / IntPtr.Size);

	/// <summary>Open a database read-only, no persistent changes.</summary>
	public static readonly IntPtr MSIDBOPEN_READONLY = (IntPtr)0;

	/// <summary>Open a database read/write in transaction mode.</summary>
	public static readonly IntPtr MSIDBOPEN_TRANSACT = (IntPtr)1;

	/// <summary>Specifies a flag indicating what type of information is needed.</summary>
	[PInvokeData("msiquery.h")]
	public enum MSICOLINFO
	{
		/// <summary>Column names are returned.</summary>
		MSICOLINFO_NAMES = 0,  // return column names

		/// <summary>Definitions are returned.</summary>
		MSICOLINFO_TYPES = 1,  // return column definitions, datatype code followed by width
	}

	/// <summary>Evaluation result of a conditional expression.</summary>
	[PInvokeData("msiquery.h")]
	public enum MSICONDITION
	{
		/// <summary>Expression evaluates to False</summary>
		MSICONDITION_FALSE = 0,  // expression evaluates to False

		/// <summary>Expression evaluates to True</summary>
		MSICONDITION_TRUE = 1,  // expression evaluates to True

		/// <summary>No expression present</summary>
		MSICONDITION_NONE = 2,  // no expression present

		/// <summary>Syntax error in expression</summary>
		MSICONDITION_ERROR = 3,  // syntax error in expression
	}

	/// <summary>Specifies the value the function uses to determine disk space requirements.</summary>
	[PInvokeData("msiquery.h")]
	public enum MSICOSTTREE
	{
		/// <summary>The feature only is included in the cost.</summary>
		MSICOSTTREE_SELFONLY = 0,

		/// <summary>The children of the indicated feature are included in the cost.</summary>
		MSICOSTTREE_CHILDREN = 1,

		/// <summary>he parent features of the indicated feature are included in the cost.</summary>
		MSICOSTTREE_PARENTS = 2,

		/// <summary>Reserved for future use</summary>
		MSICOSTTREE_RESERVED = 3,   // Reserved for future use
	}

	/// <summary>The error that occurred in the MsiViewModify function.</summary>
	[PInvokeData("msiquery.h")]
	public enum MSIDBERROR
	{
		/// <summary>An argument was invalid.</summary>
		MSIDBERROR_INVALIDARG = -3, //  invalid argument

		/// <summary>The buffer was too small to receive data.</summary>
		MSIDBERROR_MOREDATA = -2, //  buffer too small

		/// <summary>The function failed.</summary>
		MSIDBERROR_FUNCTIONERROR = -1, //  function error

		/// <summary>The function completed successfully with no errors.</summary>
		MSIDBERROR_NOERROR = 0,  //  no error

		/// <summary>The new record duplicates primary keys of the existing record in a table.</summary>
		MSIDBERROR_DUPLICATEKEY = 1,  //  new record duplicates primary keys of existing record in table

		/// <summary>There are no null values allowed; or the column is about to be deleted, but is referenced by another row.</summary>
		MSIDBERROR_REQUIRED = 2,  //  non-nullable column, no null values allowed

		/// <summary>The corresponding record in a foreign table was not found.</summary>
		MSIDBERROR_BADLINK = 3,  //  corresponding record in foreign table not found

		/// <summary>The data is greater than the maximum value allowed.</summary>
		MSIDBERROR_OVERFLOW = 4,  //  data greater than maximum value allowed

		/// <summary>The data is less than the minimum value allowed.</summary>
		MSIDBERROR_UNDERFLOW = 5,  //  data less than minimum value allowed

		/// <summary>The data is not a member of the values permitted in the set.</summary>
		MSIDBERROR_NOTINSET = 6,  //  data not a member of the values permitted in the set

		/// <summary>An invalid version string was supplied.</summary>
		MSIDBERROR_BADVERSION = 7,  //  invalid version string

		/// <summary>The case was invalid. The case must be all uppercase or all lowercase.</summary>
		MSIDBERROR_BADCASE = 8,  //  invalid case, must be all upper-case or all lower-case

		/// <summary>An invalid GUID was supplied.</summary>
		MSIDBERROR_BADGUID = 9,  //  invalid GUID

		/// <summary>An invalid wildcard file name was supplied, or the use of wildcards was invalid.</summary>
		MSIDBERROR_BADWILDCARD = 10, //  invalid wildcardfilename or use of wildcards

		/// <summary>An invalid identifier was supplied.</summary>
		MSIDBERROR_BADIDENTIFIER = 11, //  bad identifier

		/// <summary>Invalid language IDs were supplied.</summary>
		MSIDBERROR_BADLANGUAGE = 12, //  bad language Id(s)

		/// <summary>An invalid file name was supplied.</summary>
		MSIDBERROR_BADFILENAME = 13, //  bad filename

		/// <summary>An invalid path was supplied.</summary>
		MSIDBERROR_BADPATH = 14, //  bad path

		/// <summary>An invalid conditional statement was supplied.</summary>
		MSIDBERROR_BADCONDITION = 15, //  bad conditional statement

		/// <summary>An invalid format string was supplied.</summary>
		MSIDBERROR_BADFORMATTED = 16, //  bad format string

		/// <summary>An invalid template string was supplied.</summary>
		MSIDBERROR_BADTEMPLATE = 17, //  bad template string

		/// <summary>An invalid string was supplied in the DefaultDir column of the Directory table.</summary>
		MSIDBERROR_BADDEFAULTDIR = 18, //  bad string in DefaultDir column of Directory table

		/// <summary>An invalid registry path string was supplied.</summary>
		MSIDBERROR_BADREGPATH = 19, //  bad registry path string

		/// <summary>An invalid string was supplied in the CustomSource column of the CustomAction table.</summary>
		MSIDBERROR_BADCUSTOMSOURCE = 20, //  bad string in CustomSource column of CustomAction table

		/// <summary>An invalid property string was supplied.</summary>
		MSIDBERROR_BADPROPERTY = 21, //  bad property string

		/// <summary>The _Validation table is missing a reference to a column.</summary>
		MSIDBERROR_MISSINGDATA = 22, //  _Validation table missing reference to column

		/// <summary>The category column of the _Validation table for the column is invalid.</summary>
		MSIDBERROR_BADCATEGORY = 23, //  Category column of _Validation table for column is invalid

		/// <summary>An invalid cabinet name was supplied.</summary>
		MSIDBERROR_BADKEYTABLE = 24, //  table in KeyTable column of _Validation table could not be found/loaded

		/// <summary>The table in the Keytable column of the _Validation table was not found or loaded.</summary>
		MSIDBERROR_BADMAXMINVALUES = 25, //  value in MaxValue column of _Validation table is less than value in MinValue column

		/// <summary>The value in the MaxValue column of the _Validation table is less than the value in the MinValue column.</summary>
		MSIDBERROR_BADCABINET = 26, //  bad cabinet name

		/// <summary>An invalid shortcut target name was supplied.</summary>
		MSIDBERROR_BADSHORTCUT = 27, //  bad shortcut target

		/// <summary>The string is too long for the length specified by the column definition.</summary>
		MSIDBERROR_STRINGOVERFLOW = 28, //  string overflow (greater than length allowed in column def)

		/// <summary>An invalid localization attribute was supplied. (Primary keys cannot be localized.)</summary>
		MSIDBERROR_BADLOCALIZEATTRIB = 29  //  invalid localization attribute (primary keys cannot be localized)
	}

	/// <summary>The state of the database.</summary>
	[PInvokeData("msiquery.h")]
	public enum MSIDBSTATE
	{
		/// <summary>Invalid database handle</summary>
		MSIDBSTATE_ERROR = -1,  // invalid database handle

		/// <summary>Database open read-only, no persistent changes</summary>
		MSIDBSTATE_READ = 0,  // database open read-only, no persistent changes

		/// <summary>The database is readable and updatable.</summary>
		MSIDBSTATE_WRITE = 1,  // database readable and updatable
	}

	/// <summary>Specifies the modify mode.</summary>
	[PInvokeData("msiquery.h")]
	public enum MSIMODIFY
	{
		/// <summary>
		/// Refreshes the information in the supplied record without changing the position in the result set and without affecting
		/// subsequent fetch operations. The record may then be used for subsequent Update, Delete, and Refresh. All primary key columns
		/// of the table must be in the query and the record must have at least as many fields as the query. Seek cannot be used with
		/// multi-table queries. This mode cannot be used with a view containing joins. See also the remarks.
		/// </summary>
		MSIMODIFY_SEEK = -1,  // reposition to current record primary key

		/// <summary>
		/// Refreshes the information in the record. Must first call MsiViewFetch with the same record. Fails for a deleted row. Works
		/// with read-write and read-only records.
		/// </summary>
		MSIMODIFY_REFRESH = 0,  // refetch current record data

		/// <summary>
		/// Inserts a record. Fails if a row with the same primary keys exists. Fails with a read-only database. This mode cannot be
		/// used with a view containing joins.
		/// </summary>
		MSIMODIFY_INSERT = 1,  // insert new record, fails if matching key exists

		/// <summary>
		/// Updates an existing record. Nonprimary keys only. Must first call MsiViewFetch. Fails with a deleted record. Works only with
		/// read-write records.
		/// </summary>
		MSIMODIFY_UPDATE = 2,  // update existing non-key data of fetched record

		/// <summary>
		/// Writes current data in the cursor to a table row. Updates record if the primary keys match an existing row and inserts if
		/// they do not match. Fails with a read-only database. This mode cannot be used with a view containing joins.
		/// </summary>
		MSIMODIFY_ASSIGN = 3,  // insert record, replacing any existing record

		/// <summary>
		/// Updates or deletes and inserts a record into a table. Must first call MsiViewFetch with the same record. Updates record if
		/// the primary keys are unchanged. Deletes old row and inserts new if primary keys have changed. Fails with a read-only
		/// database. This mode cannot be used with a view containing joins.
		/// </summary>
		MSIMODIFY_REPLACE = 4,  // update record, delete old if primary key edit

		/// <summary>
		/// Inserts or validates a record in a table. Inserts if primary keys do not match any row and validates if there is a match.
		/// Fails if the record does not match the data in the table. Fails if there is a record with a duplicate key that is not
		/// identical. Works only with read-write records. This mode cannot be used with a view containing joins.
		/// </summary>
		MSIMODIFY_MERGE = 5,  // fails if record with duplicate key not identical

		/// <summary>
		/// Remove a row from the table. You must first call the MsiViewFetch function with the same record. Fails if the row has been
		/// deleted. Works only with read-write records. This mode cannot be used with a view containing joins.
		/// </summary>
		MSIMODIFY_DELETE = 6,  // remove row referenced by this record from table

		/// <summary>
		/// Inserts a temporary record. The information is not persistent. Fails if a row with the same primary key exists. Works only
		/// with read-write records. This mode cannot be used with a view containing joins.
		/// </summary>
		MSIMODIFY_INSERT_TEMPORARY = 7,  // insert a temporary record

		/// <summary>
		/// Validates a record. Does not validate across joins. You must first call the MsiViewFetch function with the same record.
		/// Obtain validation errors with MsiViewGetError. Works with read-write and read-only records. This mode cannot be used with a
		/// view containing joins.
		/// </summary>
		MSIMODIFY_VALIDATE = 8,  // validate a fetched record

		/// <summary>
		/// Validate a new record. Does not validate across joins. Checks for duplicate keys. Obtain validation errors by calling
		/// MsiViewGetError. Works with read-write and read-only records. This mode cannot be used with a view containing joins.
		/// </summary>
		MSIMODIFY_VALIDATE_NEW = 9,  // validate a new record

		/// <summary>
		/// Validates fields of a fetched or new record. Can validate one or more fields of an incomplete record. Obtain validation
		/// errors by calling MsiViewGetError. Works with read-write and read-only records. This mode cannot be used with a view
		/// containing joins.
		/// </summary>
		MSIMODIFY_VALIDATE_FIELD = 10, // validate field(s) of an incomplete record

		/// <summary>
		/// Validates a record that will be deleted later. You must first call MsiViewFetch. Fails if another row refers to the primary
		/// keys of this row. Validation does not check for the existence of the primary keys of this row in properties or strings. Does
		/// not check if a column is a foreign key to multiple tables. Obtain validation errors by calling MsiViewGetError. Works with
		/// read-write and read-only records. This mode cannot be used with a view that contains joins.
		/// </summary>
		MSIMODIFY_VALIDATE_DELETE = 11, // validate before deleting record
	}

	/// <summary>Specifies the run mode.</summary>
	[PInvokeData("msiquery.h")]
	public enum MSIRUNMODE
	{
		/// <summary>The administrative mode is installing, or the product is installing.</summary>
		MSIRUNMODE_ADMIN = 0, // admin mode install, else product install

		/// <summary>The advertisements are installing or the product is installing or updating.</summary>
		MSIRUNMODE_ADVERTISE = 1, // installing advertisements, else installing or updating product

		/// <summary>An existing installation is being modified or there is a new installation.</summary>
		MSIRUNMODE_MAINTENANCE = 2, // modifying an existing installation, else new installation

		/// <summary>Rollback is enabled.</summary>
		MSIRUNMODE_ROLLBACKENABLED = 3, // rollback is enabled

		/// <summary>The log file is active. It was enabled prior to the installation session.</summary>
		MSIRUNMODE_LOGENABLED = 4, // log file active, enabled prior to install session

		/// <summary>Execute operations are in the determination phase.</summary>
		MSIRUNMODE_OPERATIONS = 5, // spooling execute operations, else in determination phase

		/// <summary>A reboot is necessary after a successful installation (settable).</summary>
		MSIRUNMODE_REBOOTATEND = 6, // reboot needed after successful installation (settable)

		/// <summary>A reboot is necessary to continue the installation (settable).</summary>
		MSIRUNMODE_REBOOTNOW = 7, // reboot needed to continue installation (settable)

		/// <summary>Files from cabinets and Media table files are installing.</summary>
		MSIRUNMODE_CABINET = 8, // installing files from cabinets and files using Media table

		/// <summary>The source LongFileNames is suppressed through the PID_MSISOURCE summary property.</summary>
		MSIRUNMODE_SOURCESHORTNAMES = 9, // source LongFileNames suppressed via PID_MSISOURCE summary property

		/// <summary>The target LongFileNames is suppressed through the SHORTFILENAMES property.</summary>
		MSIRUNMODE_TARGETSHORTNAMES = 10, // target LongFileNames suppressed via SHORTFILENAMES property

		/// <summary>Reserved for future use.</summary>
		MSIRUNMODE_RESERVED11 = 11, // future use

		/// <summary>The operating system is a 9x version.</summary>
		MSIRUNMODE_WINDOWS9X = 12, // operating systems is Windows9?, else Windows NT

		/// <summary>The operating system supports demand installation.</summary>
		MSIRUNMODE_ZAWENABLED = 13, // operating system supports demand installation

		/// <summary>Reserved for future use.</summary>
		MSIRUNMODE_RESERVED14 = 14, // future use

		/// <summary>Reserved for future use.</summary>
		MSIRUNMODE_RESERVED15 = 15, // future use

		/// <summary>A custom action called from install script execution.</summary>
		MSIRUNMODE_SCHEDULED = 16, // custom action call from install script execution

		/// <summary>A custom action called from rollback execution script.</summary>
		MSIRUNMODE_ROLLBACK = 17, // custom action call from rollback execution script

		/// <summary>A custom action called from commit execution script.</summary>
		MSIRUNMODE_COMMIT = 18, // custom action call from commit execution script
	}

	/// <summary>The error conditions that should be suppressed when the transform is applied.</summary>
	[PInvokeData("msiquery.h", MSDNShortId = "NF:msiquery.MsiCreateTransformSummaryInfoA")]
	[Flags]
	public enum MSITRANSFORM_ERROR
	{
		/// <summary>Adding a row that exists.</summary>
		MSITRANSFORM_ERROR_ADDEXISTINGROW = 0x00000001,

		/// <summary>Deleting a row that does not exist.</summary>
		MSITRANSFORM_ERROR_DELMISSINGROW = 0x00000002,

		/// <summary>Adding a table that exists.</summary>
		MSITRANSFORM_ERROR_ADDEXISTINGTABLE = 0x00000004,

		/// <summary>Deleting a table that does not exist.</summary>
		MSITRANSFORM_ERROR_DELMISSINGTABLE = 0x00000008,

		/// <summary>Updating a row that does not exist.</summary>
		MSITRANSFORM_ERROR_UPDATEMISSINGROW = 0x00000010,

		/// <summary>Transform and database code pages do not match, and their code pages are neutral.</summary>
		MSITRANSFORM_ERROR_CHANGECODEPAGE = 0x00000020,

		/// <summary>Create the temporary _TransformView table.</summary>
		MSITRANSFORM_ERROR_VIEWTRANSFORM = 0x00000100,
	}

	// Note: INSTALLMESSAGE_ERROR, INSTALLMESSAGE_WARNING, INSTALLMESSAGE_USER are to or'd with a message box style to indicate the
	// buttons to display and return: MB_OK,MB_OKCANCEL,MB_ABORTRETRYIGNORE,MB_YESNOCANCEL,MB_YESNO,MB_RETRYCANCEL the default button
	// (MB_DEFBUTTON1 is normal default): MB_DEFBUTTON1, MB_DEFBUTTON2, MB_DEFBUTTON3 and optionally an icon style: MB_ICONERROR,
	// MB_ICONQUESTION, MB_ICONWARNING, MB_ICONINFORMATION
	/// <summary>Specifies the properties to be validated to verify that the transform can be applied to the database.</summary>
	[PInvokeData("msiquery.h", MSDNShortId = "NF:msiquery.MsiCreateTransformSummaryInfoA")]
	[Flags]
	public enum MSITRANSFORM_VALIDATE
	{
		/// <summary>Default language must match base database.</summary>
		MSITRANSFORM_VALIDATE_LANGUAGE = 0x00000001,

		/// <summary>Product must match base database.</summary>
		MSITRANSFORM_VALIDATE_PRODUCT = 0x00000002,

		/// <summary/>
		MSITRANSFORM_VALIDATE_PLATFORM = 0x00000004,

		/// <summary>Check major version only.</summary>
		MSITRANSFORM_VALIDATE_MAJORVERSION = 0x00000008,

		/// <summary>Check major and minor versions only.</summary>
		MSITRANSFORM_VALIDATE_MINORVERSION = 0x00000010,

		/// <summary>Check major, minor, and update versions.</summary>
		MSITRANSFORM_VALIDATE_UPDATEVERSION = 0x00000020,

		/// <summary>Installed version &lt; base version.</summary>
		MSITRANSFORM_VALIDATE_NEWLESSBASEVERSION = 0x00000040,

		/// <summary>Installed version &lt;= base version.</summary>
		MSITRANSFORM_VALIDATE_NEWLESSEQUALBASEVERSION = 0x00000080,

		/// <summary>Installed version = base version.</summary>
		MSITRANSFORM_VALIDATE_NEWEQUALBASEVERSION = 0x00000100,

		/// <summary>Installed version &gt;= base version.</summary>
		MSITRANSFORM_VALIDATE_NEWGREATEREQUALBASEVERSION = 0x00000200,

		/// <summary>Installed version &gt; base version.</summary>
		MSITRANSFORM_VALIDATE_NEWGREATERBASEVERSION = 0x00000400,

		/// <summary>UpgradeCode must match base database.</summary>
		MSITRANSFORM_VALIDATE_UPGRADECODE = 0x00000800,
	}

	/// <summary>
	/// The <c>MsiCreateRecord</c> function creates a new record object with the specified number of fields. This function returns a
	/// handle that should be closed using MsiCloseHandle.
	/// </summary>
	/// <param name="cParams">
	/// Specifies the number of fields the record will have. The maximum number of fields in a record is limited to 65535.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is handle to a new record object.</para>
	/// <para>If the function fails, the return value is null.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// Field 0 of the record object created by the <c>MsiCreateRecord</c> function is used for format strings and operation codes and
	/// is not included in the count specified by cParams. All fields are initialized to null.
	/// </para>
	/// <para>
	/// Note that it is recommended to use variables of type PMSIHANDLE because the installer closes PMSIHANDLE objects as they go out
	/// of scope, whereas you must close MSIHANDLE objects by calling MsiCloseHandle. For more information see Use PMSIHANDLE instead of
	/// HANDLE section in the Windows Installer Best Practices.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/msiquery/nf-msiquery-msicreaterecord MSIHANDLE MsiCreateRecord( UINT cParams );
	[DllImport(Lib_Msi, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("msiquery.h", MSDNShortId = "NF:msiquery.MsiCreateRecord")]
	public static extern PMSIHANDLE MsiCreateRecord(uint cParams);

	/// <summary>
	/// The <c>MsiCreateTransformSummaryInfo</c> function creates summary information of an existing transform to include validation and
	/// error conditions. Execution of this function sets the error record, which is accessible by using MsiGetLastErrorRecord.
	/// </summary>
	/// <param name="hDatabase">The handle to the database that contains the new database summary information.</param>
	/// <param name="hDatabaseReference">The handle to the database that contains the original summary information.</param>
	/// <param name="szTransformFile">The name of the transform to which the summary information is added.</param>
	/// <param name="iErrorConditions">
	/// <para>The error conditions that should be suppressed when the transform is applied. Use one or more of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Error condition</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>none 0x00000000</term>
	/// <term>None of the following conditions.</term>
	/// </item>
	/// <item>
	/// <term>MSITRANSFORM_ERROR_ADDEXISTINGROW 0x00000001</term>
	/// <term>Adding a row that exists.</term>
	/// </item>
	/// <item>
	/// <term>MSITRANSFORM_ERROR_DELMISSINGROW 0x00000002</term>
	/// <term>Deleting a row that does not exist.</term>
	/// </item>
	/// <item>
	/// <term>MSITRANSFORM_ERROR_ADDEXISTINGTABLE 0x00000004</term>
	/// <term>Adding a table that exists.</term>
	/// </item>
	/// <item>
	/// <term>MSITRANSFORM_ERROR_DELMISSINGTABLE 0x00000008</term>
	/// <term>Deleting a table that does not exist.</term>
	/// </item>
	/// <item>
	/// <term>MSITRANSFORM_ERROR_UPDATEMISSINGROW 0x00000010</term>
	/// <term>Updating a row that does not exist.</term>
	/// </item>
	/// <item>
	/// <term>MSITRANSFORM_ERROR_CHANGECODEPAGE 0x00000020</term>
	/// <term>Transform and database code pages do not match, and their code pages are neutral.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="iValidation">
	/// <para>
	/// Specifies the properties to be validated to verify that the transform can be applied to the database. This parameter can be one
	/// or more of the following values.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Validation flag</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>none 0x00000000</term>
	/// <term>Do not validate properties.</term>
	/// </item>
	/// <item>
	/// <term>MSITRANSFORM_VALIDATE_LANGUAGE 0x00000001</term>
	/// <term>Default language must match base database.</term>
	/// </item>
	/// <item>
	/// <term>MSITRANSFORM_VALIDATE_PRODUCT 0x00000002</term>
	/// <term>Product must match base database.</term>
	/// </item>
	/// </list>
	/// <para>Validate product version flags.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Validation flag</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>MSITRANSFORM_VALIDATE_MAJORVERSION 0x00000008</term>
	/// <term>Check major version only.</term>
	/// </item>
	/// <item>
	/// <term>MSITRANSFORM_VALIDATE_MINORVERSION 0x00000010</term>
	/// <term>Check major and minor versions only.</term>
	/// </item>
	/// <item>
	/// <term>MSITRANSFORM_VALIDATE_UPDATEVERSION 0x00000020</term>
	/// <term>Check major, minor, and update versions.</term>
	/// </item>
	/// </list>
	/// <para>
	/// Product version relationship flags. In the following table the installed version is the version of the package that is being
	/// transformed, and the base version is the version of the package that is used to create the transform.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Validation flag</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>MSITRANSFORM_VALIDATE_NEWLESSBASEVERSION 0x00000040</term>
	/// <term>Installed version &lt; base version.</term>
	/// </item>
	/// <item>
	/// <term>MSITRANSFORM_VALIDATE_NEWLESSEQUALBASEVERSION 0x00000080</term>
	/// <term>Installed version &lt;= base version.</term>
	/// </item>
	/// <item>
	/// <term>MSITRANSFORM_VALIDATE_NEWEQUALBASEVERSION 0x00000100</term>
	/// <term>Installed version = base version.</term>
	/// </item>
	/// <item>
	/// <term>MSITRANSFORM_VALIDATE_NEWGREATEREQUALBASEVERSION 0x00000200</term>
	/// <term>Installed version &gt;= base version.</term>
	/// </item>
	/// <item>
	/// <term>MSITRANSFORM_VALIDATE_NEWGREATERBASEVERSION 0x00000400</term>
	/// <term>Installed version &gt; base version.</term>
	/// </item>
	/// </list>
	/// <para>Upgrade code validation flags.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Validation flag</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>MSITRANSFORM_VALIDATE_UPGRADECODE 0x00000800</term>
	/// <term>UpgradeCode must match base database.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <returns>This function returns UINT.</returns>
	/// <remarks>
	/// <para>
	/// The ProductCode Property and ProductVersion Property must be defined in the Property Table of both the base and reference
	/// databases. If MSITRANSFORM_VALIDATE_UPGRADECODE is used, the UpgradeCode Property must also be defined in both databases. If
	/// these conditions are not met, <c>MsiCreateTransformSummaryInfo</c> returns ERROR_INSTALL_PACKAGE_INVALID.
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>Do not use the semicolon for filenames or paths, because it is used as a list delimiter for transforms, sources, and patches.</term>
	/// </item>
	/// <item>
	/// <term>
	/// This function cannot be called from custom actions. A call to this function from a custom action causes the function to fail.
	/// </term>
	/// </item>
	/// </list>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/msiquery/nf-msiquery-msicreatetransformsummaryinfoa UINT
	// MsiCreateTransformSummaryInfoA( MSIHANDLE hDatabase, MSIHANDLE hDatabaseReference, LPCSTR szTransformFile, int iErrorConditions,
	// int iValidation );
	[DllImport(Lib_Msi, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("msiquery.h", MSDNShortId = "NF:msiquery.MsiCreateTransformSummaryInfoA")]
	public static extern Win32Error MsiCreateTransformSummaryInfo(MSIHANDLE hDatabase, MSIHANDLE hDatabaseReference, [MarshalAs(UnmanagedType.LPTStr)] string szTransformFile,
		MSITRANSFORM_ERROR iErrorConditions, MSITRANSFORM_VALIDATE iValidation);

	/// <summary>The <c>MsiDatabaseApplyTransform</c> function applies a transform to a database.</summary>
	/// <param name="hDatabase">Handle to the database obtained from MsiOpenDatabase to the transform.</param>
	/// <param name="szTransformFile">Specifies the name of the transform file to apply.</param>
	/// <param name="iErrorConditions">
	/// <para>Error conditions that should be suppressed. This parameter is a bit field that can contain the following bits.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Error condition</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>MSITRANSFORM_ERROR_ADDEXISTINGROW 0x0001</term>
	/// <term>Adding a row that already exists.</term>
	/// </item>
	/// <item>
	/// <term>MSITRANSFORM_ERROR_DELMISSINGROW 0x0002</term>
	/// <term>Deleting a row that does not exist.</term>
	/// </item>
	/// <item>
	/// <term>MSITRANSFORM_ERROR_ADDEXISTINGTABLE 0x0004</term>
	/// <term>Adding a table that already exists.</term>
	/// </item>
	/// <item>
	/// <term>MSITRANSFORM_ERROR_DELMISSINGTABLE 0x0008</term>
	/// <term>Deleting a table that does not exist.</term>
	/// </item>
	/// <item>
	/// <term>MSITRANSFORM_ERROR_UPDATEMISSINGROW 0x0010</term>
	/// <term>Updating a row that does not exist.</term>
	/// </item>
	/// <item>
	/// <term>MSITRANSFORM_ERROR_CHANGECODEPAGE 0x0020</term>
	/// <term>Transform and database code pages do not match and neither has a neutral code page.</term>
	/// </item>
	/// <item>
	/// <term>MSITRANSFORM_ERROR_VIEWTRANSFORM 0x0100</term>
	/// <term>Create the temporary _TransformView table.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <returns>The <c>MsiDatabaseApplyTransform</c> function returns one of the following values:</returns>
	/// <remarks>
	/// <para>
	/// The <c>MsiDatabaseApplyTransform</c> function delays transforming tables until it is necessary. Any tables to be added or
	/// dropped are processed immediately. However, changes to the existing table are delayed until the table is loaded or the database
	/// is committed.
	/// </para>
	/// <para>An error occurs if <c>MsiDatabaseApplyTransform</c> is called when tables have already been loaded and saved to storage.</para>
	/// <para>
	/// Because the list delimiter for transforms, sources and patches is a semicolon, this character should not be used for filenames
	/// or paths.
	/// </para>
	/// <para>
	/// This function cannot be called from custom actions. A call to this function from a custom action causes the function to fail.
	/// </para>
	/// <para>If the function fails, you can obtain extended error information by using MsiGetLastErrorRecord.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/msiquery/nf-msiquery-msidatabaseapplytransforma UINT
	// MsiDatabaseApplyTransformA( MSIHANDLE hDatabase, LPCSTR szTransformFile, int iErrorConditions );
	[DllImport(Lib_Msi, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("msiquery.h", MSDNShortId = "NF:msiquery.MsiDatabaseApplyTransformA")]
	public static extern Win32Error MsiDatabaseApplyTransform(MSIHANDLE hDatabase, [MarshalAs(UnmanagedType.LPTStr)] string szTransformFile, MSITRANSFORM_ERROR iErrorConditions);

	/// <summary>The <c>MsiDatabaseCommit</c> function commits changes to a database.</summary>
	/// <param name="hDatabase">Handle to the database obtained from MsiOpenDatabase.</param>
	/// <returns>The <c>MsiDatabaseCommit</c> function returns one of the following values:</returns>
	/// <remarks>
	/// <para>
	/// The <c>MsiDatabaseCommit</c> function finalizes the persistent form of the database. All persistent data is then written to the
	/// writable database. No temporary columns or rows are written. The <c>MsiDatabaseCommit</c> function has no effect on a database
	/// that is opened as read-only. You can call this function multiple times to save the current state of tables loaded into memory.
	/// When the database is finally closed, any changes made after the database is committed are rolled back. This function is normally
	/// called prior to shutdown when all database changes have been finalized.
	/// </para>
	/// <para>If the function fails, you can obtain extended error information by using MsiGetLastErrorRecord.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/msiquery/nf-msiquery-msidatabasecommit UINT MsiDatabaseCommit( MSIHANDLE
	// hDatabase );
	[DllImport(Lib_Msi, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("msiquery.h", MSDNShortId = "NF:msiquery.MsiDatabaseCommit")]
	public static extern Win32Error MsiDatabaseCommit(MSIHANDLE hDatabase);

	/// <summary>
	/// The <c>MsiDatabaseExport</c> function exports a Microsoft Installer table from an open database to a Text Archive File.
	/// </summary>
	/// <param name="hDatabase">The handle to a database from MsiOpenDatabase.</param>
	/// <param name="szTableName">The name of the table to export.</param>
	/// <param name="szFolderPath">The name of the folder that contains archive files.</param>
	/// <param name="szFileName">The name of the exported table archive file.</param>
	/// <returns>
	/// <para>The <c>MsiDatabaseExport</c> function returns one of the following values:</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_BAD_PATHNAME</term>
	/// <term>An invalid path is passed to the function.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_FUNCTION_FAILED</term>
	/// <term>The function fails.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_HANDLE</term>
	/// <term>An invalid or inactive handle is supplied.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_PARAMETER</term>
	/// <term>An invalid parameter is passed to the function.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_SUCCESS</term>
	/// <term>The function succeeds.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>If a table contains streams, <c>MsiDatabaseExport</c> exports each stream to a separate file.</para>
	/// <para>For more information, see MsiDatabaseImport.</para>
	/// <para>
	/// This function cannot be called from custom actions. A call to this function from a custom action causes the function to fail.
	/// </para>
	/// <para>If the function fails, you can get extended error information by using MsiGetLastErrorRecord.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/msiquery/nf-msiquery-msidatabaseexporta UINT MsiDatabaseExportA( MSIHANDLE
	// hDatabase, LPCSTR szTableName, LPCSTR szFolderPath, LPCSTR szFileName );
	[DllImport(Lib_Msi, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("msiquery.h", MSDNShortId = "NF:msiquery.MsiDatabaseExportA")]
	public static extern Win32Error MsiDatabaseExport(MSIHANDLE hDatabase, [MarshalAs(UnmanagedType.LPTStr)] string szTableName,
		[MarshalAs(UnmanagedType.LPTStr)] string szFolderPath, [MarshalAs(UnmanagedType.LPTStr)] string szFileName);

	/// <summary>
	/// The <c>MsiDatabaseGenerateTransform</c> function generates a transform file of differences between two databases. A transform is
	/// a way of recording changes to a database without altering the original database. You can also use
	/// <c>MsiDatabaseGenerateTransform</c> to test whether two databases are identical without creating a transform.
	/// </summary>
	/// <param name="hDatabase">Handle to the database obtained from MsiOpenDatabase that includes the changes.</param>
	/// <param name="hDatabaseReference">Handle to the database obtained from MsiOpenDatabase that does not include the changes.</param>
	/// <param name="szTransformFile">
	/// A null-terminated string that specifies the name of the transform file being generated. This parameter can be null. If
	/// szTransformFile is null, you can use <c>MsiDatabaseGenerateTransform</c> to test whether two databases are identical without
	/// creating a transform. If the databases are identical, the function returns ERROR_NO_DATA. If the databases are different the
	/// function returns NOERROR.
	/// </param>
	/// <param name="iReserved1">This is a reserved argument and must be set to 0.</param>
	/// <param name="iReserved2">This is a reserved argument and must be set to 0.</param>
	/// <returns>The <c>MsiDatabaseGenerateTransform</c> function returns one of the following values:</returns>
	/// <remarks>
	/// <para>
	/// To generate a difference file between two databases, use the <c>MsiDatabaseGenerateTransform</c> function. A transform contains
	/// information regarding insertion and deletion of columns and rows. The validation flags are stored in the summary information
	/// stream of the transform file.
	/// </para>
	/// <para>
	/// For tables that exist in both databases, the only difference between the two schemas that is allowed is the addition of columns
	/// to the end of the reference table. You cannot add primary key columns to a table or change the order or names or column
	/// definitions of the existing columns as defined in the base table. In other words, if neither table contains data and columns are
	/// removed from the reference table, the resulting table is identical to the base table.
	/// </para>
	/// <para>
	/// Because the list delimiter for transforms, sources and patches is a semicolon, this character should not be used for filenames
	/// or paths.
	/// </para>
	/// <para>
	/// This function does not generate a Summary Information stream. Use MsiCreateTransformSummaryInfo to create the stream for an
	/// existing transform.
	/// </para>
	/// <para>
	/// If szTransformFile is null, you can test whether two databases are identical without creating a transform. If the databases are
	/// identical, ERROR_NO_DATA is returned, NOERROR is returned if differences are found.
	/// </para>
	/// <para>
	/// This function cannot be called from custom actions. A call to this function from a custom action causes the function to fail.
	/// </para>
	/// <para>If the function fails, you can obtain extended error information by using MsiGetLastErrorRecord.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/msiquery/nf-msiquery-msidatabasegeneratetransforma UINT
	// MsiDatabaseGenerateTransformA( MSIHANDLE hDatabase, MSIHANDLE hDatabaseReference, LPCSTR szTransformFile, int iReserved1, int
	// iReserved2 );
	[DllImport(Lib_Msi, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("msiquery.h", MSDNShortId = "NF:msiquery.MsiDatabaseGenerateTransformA")]
	public static extern Win32Error MsiDatabaseGenerateTransform(MSIHANDLE hDatabase, MSIHANDLE hDatabaseReference, [Optional, MarshalAs(UnmanagedType.LPTStr)] string? szTransformFile,
		int iReserved1 = 0, int iReserved2 = 0);

	/// <summary>
	/// The <c>MsiDatabaseGetPrimaryKeys</c> function returns a record containing the names of all the primary key columns for a
	/// specified table. This function returns a handle that should be closed using MsiCloseHandle.
	/// </summary>
	/// <param name="hDatabase">Handle to the database. See Obtaining a Database Handle.</param>
	/// <param name="szTableName">Specifies the name of the table from which to obtain primary key names.</param>
	/// <param name="phRecord">Pointer to the handle of the record that holds the primary key names.</param>
	/// <returns>This function returns UINT.</returns>
	/// <remarks>
	/// <para>
	/// The field count of the returned record is the count of primary key columns returned by the <c>MsiDatabaseGetPrimaryKeys</c>
	/// function. The returned record contains the table name in Field (0) and the column names that make up the primary key names in
	/// succeeding fields. These primary key names correspond to the column numbers for the fields.
	/// </para>
	/// <para>This function cannot be used with the _Tables table or the _Columns table.</para>
	/// <para>
	/// Note that it is recommended to use variables of type PMSIHANDLE because the installer closes PMSIHANDLE objects as they go out
	/// of scope, whereas you must close MSIHANDLE objects by calling MsiCloseHandle. For more information see Use PMSIHANDLE instead of
	/// HANDLE section in the Windows Installer Best Practices.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/msiquery/nf-msiquery-msidatabasegetprimarykeysa UINT
	// MsiDatabaseGetPrimaryKeysA( MSIHANDLE hDatabase, LPCSTR szTableName, MSIHANDLE *phRecord );
	[DllImport(Lib_Msi, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("msiquery.h", MSDNShortId = "NF:msiquery.MsiDatabaseGetPrimaryKeysA")]
	public static extern Win32Error MsiDatabaseGetPrimaryKeys(MSIHANDLE hDatabase, [MarshalAs(UnmanagedType.LPTStr)] string szTableName, out PMSIHANDLE phRecord);

	/// <summary>The <c>MsiDatabaseImport</c> function imports an installer text archive file into an open database table.</summary>
	/// <param name="hDatabase">Handle to the database obtained from MsiOpenDatabase.</param>
	/// <param name="szFolderPath">Specifies the path to the folder that contains archive files.</param>
	/// <param name="szFileName">Specifies the name of the file to import.</param>
	/// <returns>The <c>MsiDatabaseImport</c> function returns one of the following values:</returns>
	/// <remarks>
	/// <para>
	/// When you use the <c>MsiDatabaseImport</c> function to import a text archive table named _SummaryInformation into an installer
	/// database, you write the "05SummaryInformation" stream. This stream contains standard properties that can be viewed using Windows
	/// Explorer and are defined by COM. The rows of the table are written to the property stream as pairs of property ID numbers and
	/// corresponding data values. See Summary Information Stream Property Set. Date and time in _SummaryInformation are in the format:
	/// YYYY/MM/DD hh::mm::ss. For example, 1999/03/22 15:25:45. If the table contains binary streams, the name of the stream is in the
	/// data field, and the actual stream is retrieved from a file of that name in a subfolder with the same name as the table.
	/// </para>
	/// <para>
	/// Text archive files that are exported from a database by MsiDatabaseExport are intended for use with version control systems, and
	/// are not intended to be used as a means of editing data. Use the database API functions and tools designed for that purpose. Note
	/// that control characters in text archive files are translated to avoid conflicts with file delimiters. If a text archive file
	/// contains non-ASCII data, it is stamped with the code page of the data, and can only be imported into a database of that exact
	/// code page, or into a neutral database. Neutral databases are set to the code page of the imported file. A database can be
	/// unconditionally set to a particular code page by importing a pseudo table named: _ForceCodepage. The format of such a file is:
	/// Two blank lines, followed by a line that contains the numeric code page, a tab delimiter and the exact string: _ForceCodepage
	/// </para>
	/// <para>
	/// This function cannot be called from custom actions. A call to this function from a custom action causes the function to fail.
	/// </para>
	/// <para>If the function fails, you can obtain extended error information by using MsiGetLastErrorRecord.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/msiquery/nf-msiquery-msidatabaseimporta UINT MsiDatabaseImportA( MSIHANDLE
	// hDatabase, LPCSTR szFolderPath, LPCSTR szFileName );
	[DllImport(Lib_Msi, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("msiquery.h", MSDNShortId = "NF:msiquery.MsiDatabaseImportA")]
	public static extern Win32Error MsiDatabaseImport(MSIHANDLE hDatabase, [MarshalAs(UnmanagedType.LPTStr)] string szFolderPath,
		[MarshalAs(UnmanagedType.LPTStr)] string szFileName);

	/// <summary>The <c>MsiDatabaseIsTablePersistent</c> function returns an enumeration that describes the state of a specific table.</summary>
	/// <param name="hDatabase">
	/// Handle to the database that belongs to the relevant table. For more information, see Obtaining a Database Handle.
	/// </param>
	/// <param name="szTableName">Specifies the name of the relevant table.</param>
	/// <returns>This function returns MSICONDITION.</returns>
	/// <remarks/>
	// https://docs.microsoft.com/en-us/windows/win32/api/msiquery/nf-msiquery-msidatabaseistablepersistenta MSICONDITION
	// MsiDatabaseIsTablePersistentA( MSIHANDLE hDatabase, LPCSTR szTableName );
	[DllImport(Lib_Msi, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("msiquery.h", MSDNShortId = "NF:msiquery.MsiDatabaseIsTablePersistentA")]
	public static extern MSICONDITION MsiDatabaseIsTablePersistent(MSIHANDLE hDatabase, [MarshalAs(UnmanagedType.LPTStr)] string szTableName);

	/// <summary>The <c>MsiDatabaseMerge</c> function merges two databases together, which allows duplicate rows.</summary>
	/// <param name="hDatabase">The handle to the database obtained from MsiOpenDatabase.</param>
	/// <param name="hDatabaseMerge">The handle to the database obtained from MsiOpenDatabase to merge into the base database.</param>
	/// <param name="szTableName">The name of the table to receive merge conflict information.</param>
	/// <returns>
	/// <para>The <c>MsiDatabaseMerge</c> function returns one of the following values:</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_FUNCTION_FAILED</term>
	/// <term>Row merge conflicts were reported.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_HANDLE</term>
	/// <term>An invalid or inactive handle was supplied.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_TABLE</term>
	/// <term>An invalid table was supplied.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_SUCCESS</term>
	/// <term>The function succeeded.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_DATATYPE_MISMATCH</term>
	/// <term>Schema difference between the two databases.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The <c>MsiDatabaseMerge</c> function and the Merge method of the Database object cannot be used to merge a module that is
	/// included in the installation package. They should not be used to merge Merge Modules into a Windows Installer package. To
	/// include a merge module in an installation package, authors of installation packages should follow the guidelines that are
	/// described in the Applying Merge Modules topic.
	/// </para>
	/// <para>
	/// <c>MsiDatabaseMerge</c> does not copy over embedded Cabinet Files or embedded transforms from the reference database into the
	/// target database. Embedded data streams that are listed in the Binary Table or Icon Table are copied from the reference database
	/// to the target database. Storage embedded in the reference database are not copied to the target database.
	/// </para>
	/// <para>
	/// The <c>MsiDatabaseMerge</c> function merges the data of two databases. These databases must have the same code page.
	/// <c>MsiDatabaseMerge</c> fails if any tables or rows in the databases conflict. A conflict exists if the data in any row in the
	/// first database differs from the data in the corresponding row of the second database. Corresponding rows are in the same table
	/// of both databases and have the same primary key in both databases. The tables of non-conflicting databases must have the same
	/// number of primary keys, same number of columns, same column types, same column names, and the same data in rows with identical
	/// primary keys. Temporary columns however don't matter in the column count and corresponding tables can have a different number of
	/// temporary columns without creating conflict as long as the persistent columns match.
	/// </para>
	/// <para>
	/// If the number, type, or name of columns in corresponding tables are different, the schema of the two databases are incompatible
	/// and the installer stops processing tables and the merge fails. The installer checks that the two databases have the same schema
	/// before checking for row merge conflicts. If ERROR_DATATYPE_MISMATCH is returned, you are guaranteed that the databases have not
	/// been changed.
	/// </para>
	/// <para>
	/// If the data in particular rows differ, this is a row merge conflict, the installer returns ERROR_FUNCTION_FAILED and creates a
	/// new table named szTableName. The first column of this table is the name of the table having the conflict. The second column
	/// gives the number of rows in the table having the conflict. The table that reports conflicts appears as follows.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Column</term>
	/// <term>Type</term>
	/// <term>Key</term>
	/// <term>Nullable</term>
	/// </listheader>
	/// <item>
	/// <term>Table</term>
	/// <term>Text</term>
	/// <term>Y</term>
	/// <term>N</term>
	/// </item>
	/// <item>
	/// <term>NumRowMergeConflicts</term>
	/// <term>Integer</term>
	/// <term/>
	/// <term>N</term>
	/// </item>
	/// </list>
	/// <para>
	/// This function cannot be called from custom actions. A call to this function from a custom action causes the function to fail.
	/// </para>
	/// <para>If the function fails, you can obtain extended error information by using MsiGetLastErrorRecord.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/msiquery/nf-msiquery-msidatabasemergea UINT MsiDatabaseMergeA( MSIHANDLE
	// hDatabase, MSIHANDLE hDatabaseMerge, LPCSTR szTableName );
	[DllImport(Lib_Msi, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("msiquery.h", MSDNShortId = "NF:msiquery.MsiDatabaseMergeA")]
	public static extern Win32Error MsiDatabaseMerge(MSIHANDLE hDatabase, MSIHANDLE hDatabaseMerge, [MarshalAs(UnmanagedType.LPTStr)] string szTableName);

	/// <summary>
	/// The <c>MsiDatabaseOpenView</c> function prepares a database query and creates a view object. This function returns a handle that
	/// should be closed using MsiCloseHandle.
	/// </summary>
	/// <param name="hDatabase">
	/// Handle to the database to which you want to open a view object. You can get the handle as described in Obtaining a Database Handle.
	/// </param>
	/// <param name="szQuery">Specifies a SQL query string for querying the database. For correct syntax, see SQL Syntax.</param>
	/// <param name="phView">Pointer to a handle for the returned view.</param>
	/// <returns>The <c>MsiDatabaseOpenView</c> function returns one of the following values:</returns>
	/// <remarks>
	/// <para>
	/// The <c>MsiDatabaseOpenView</c> function opens a view object for a database. You must open a view object for a database before
	/// performing any execution or fetching.
	/// </para>
	/// <para>If an error occurs, you can call MsiGetLastErrorRecord for more information.</para>
	/// <para>
	/// Note that it is recommended to use variables of type PMSIHANDLE because the installer closes PMSIHANDLE objects as they go out
	/// of scope, whereas you must close MSIHANDLE objects by calling MsiCloseHandle. For more information see Use PMSIHANDLE instead of
	/// HANDLE section in the Windows Installer Best Practices.
	/// </para>
	/// <para>If the function fails, you can obtain extended error information by using MsiGetLastErrorRecord.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/msiquery/nf-msiquery-msidatabaseopenviewa UINT MsiDatabaseOpenViewA( MSIHANDLE
	// hDatabase, LPCSTR szQuery, MSIHANDLE *phView );
	[DllImport(Lib_Msi, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("msiquery.h", MSDNShortId = "NF:msiquery.MsiDatabaseOpenViewA")]
	public static extern Win32Error MsiDatabaseOpenView(MSIHANDLE hDatabase, [MarshalAs(UnmanagedType.LPTStr)] string szQuery, out PMSIHANDLE phView);

	/// <summary>The <c>MsiDoAction</c> function executes a built-in action, custom action, or user-interface wizard action.</summary>
	/// <param name="hInstall">
	/// Handle to the installation provided to a DLL custom action or obtained through MsiOpenPackage, MsiOpenPackageEx, or MsiOpenProduct.
	/// </param>
	/// <param name="szAction">Specifies the action to execute.</param>
	/// <returns>This function returns UINT.</returns>
	/// <remarks>
	/// <para>
	/// The <c>MsiDoAction</c> function executes the action that corresponds to the name supplied. If the name is not recognized by the
	/// installer as a built-in action or as a custom action in the CustomAction table, the name is passed to the user-interface handler
	/// object, which can invoke a function or a dialog box. If a null action name is supplied, the installer uses the upper-case value
	/// of the ACTION property as the action to perform. If no property value is defined, the default action is performed, defined as "INSTALL".
	/// </para>
	/// <para>
	/// Actions that update the system, such as the InstallFiles and WriteRegistryValues actions, cannot be run by calling
	/// <c>MsiDoAction</c>. The exception to this rule is if <c>MsiDoAction</c> is called from a custom action that is scheduled in the
	/// InstallExecuteSequence table between the InstallInitialize and InstallFinalize actions. Actions that do not update the system,
	/// such as AppSearch or CostInitialize, can be called.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/msiquery/nf-msiquery-msidoactiona UINT MsiDoActionA( MSIHANDLE hInstall,
	// LPCSTR szAction );
	[DllImport(Lib_Msi, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("msiquery.h", MSDNShortId = "NF:msiquery.MsiDoActionA")]
	public static extern Win32Error MsiDoAction(MSIHANDLE hInstall, [MarshalAs(UnmanagedType.LPTStr)] string? szAction);

	/// <summary>
	/// The <c>MsiEnableUIPreview</c> function enables preview mode of the user interface to facilitate authoring of user-interface
	/// dialog boxes. This function returns a handle that should be closed using MsiCloseHandle.
	/// </summary>
	/// <param name="hDatabase">Handle to the database.</param>
	/// <param name="phPreview">Pointer to a returned handle for user-interface preview capability.</param>
	/// <returns>This function returns UINT.</returns>
	/// <remarks>
	/// Note that it is recommended to use variables of type PMSIHANDLE because the installer closes PMSIHANDLE objects as they go out
	/// of scope, whereas you must close MSIHANDLE objects by calling MsiCloseHandle. For more information see Use PMSIHANDLE instead of
	/// HANDLE section in the Windows Installer Best Practices.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/msiquery/nf-msiquery-msienableuipreview UINT MsiEnableUIPreview( MSIHANDLE
	// hDatabase, MSIHANDLE *phPreview );
	[DllImport(Lib_Msi, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("msiquery.h", MSDNShortId = "NF:msiquery.MsiEnableUIPreview")]
	public static extern Win32Error MsiEnableUIPreview(MSIHANDLE hDatabase, out PMSIHANDLE phPreview);

	/// <summary>
	/// <para>
	/// The <c>MsiEnumComponentCosts</c> function enumerates the disk-space per drive required to install a component. This information
	/// is needed to display the disk-space cost required for all drives in the user interface. The returned disk-space costs are
	/// expressed in multiples of 512 bytes.
	/// </para>
	/// <para>
	/// <c>MsiEnumComponentCosts</c> should only be run after the installer has completed file costing and after the CostFinalize
	/// action. For more information, see File Costing.
	/// </para>
	/// </summary>
	/// <param name="hInstall">
	/// Handle to the installation provided to a DLL custom action or obtained through MsiOpenPackage, MsiOpenPackageEx, or MsiOpenProduct.
	/// </param>
	/// <param name="szComponent">
	/// A null-terminated string specifying the component's name as it is listed in the Component column of the Component table. This
	/// parameter can be null. If szComponent is null or an empty string, <c>MsiEnumComponentCosts</c> enumerates the total disk-space
	/// per drive used during the installation. In this case, iState is ignored. The costs of the installer include those costs for
	/// caching the database in the secure folder as well as the cost to create the installation script. Note that the total disk-space
	/// used during the installation may be larger than the space used after the component is installed.
	/// </param>
	/// <param name="dwIndex">
	/// 0-based index for drives. This parameter should be zero for the first call to the <c>MsiEnumComponentCosts</c> function and then
	/// incremented for subsequent calls.
	/// </param>
	/// <param name="iState">
	/// Requested component state to be enumerated. If szComponent is passed as Null or an empty string, the installer ignores the
	/// iState parameter.
	/// </param>
	/// <param name="szDriveBuf">
	/// Buffer that holds the drive name including the null terminator. This is an empty string in case of an error.
	/// </param>
	/// <param name="pcchDriveBuf">
	/// Pointer to a variable that specifies the size, in TCHARs, of the buffer pointed to by the lpDriveBuf parameter. This size should
	/// include the terminating null character. If the buffer provided is too small, the variable pointed to by pcchDriveBuf contains
	/// the count of characters not including the null terminator.
	/// </param>
	/// <param name="piCost">
	/// Cost of the component per drive expressed in multiples of 512 bytes. This value is 0 if an error has occurred. The value
	/// returned in piCost is final disk-space used by the component after installation. If szComponent is passed as Null or an empty
	/// string, the installer sets the value at piCost to 0.
	/// </param>
	/// <param name="piTempCost">
	/// The component cost per drive for the duration of the installation, or 0 if an error occurred. The value in *piTempCost
	/// represents the temporary space requirements for the duration of the installation. This temporary space requirement is space
	/// needed only for the duration of the installation. This does not affect the final disk space requirement.
	/// </param>
	/// <returns>
	/// <list type="table">
	/// <listheader>
	/// <term>Return Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_INVALID_HANDLE_STATE</term>
	/// <term>The configuration data is corrupt.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_PARAMETER</term>
	/// <term>An invalid parameter was passed to the function.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_NO_MORE_ITEMS</term>
	/// <term>There are no more drives to return.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_SUCCESS</term>
	/// <term>A value was enumerated.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_UNKNOWN_COMPONENT</term>
	/// <term>The component is missing.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_FUNCTION_NOT_CALLED</term>
	/// <term>Costing is not complete.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_MORE_DATA</term>
	/// <term>Buffer not large enough for the drive name.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_HANDLE</term>
	/// <term>The supplied handle is invalid or inactive.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The recommended method for enumerating the disk-space costs per drive is as follows. Start with the dwIndex set to 0 and
	/// increment it by one after each call. Continue the enumeration as long as <c>MsiEnumComponentCosts</c> returns ERROR_SUCCESS.
	/// </para>
	/// <para><c>MsiEnumComponentCosts</c> may be called from custom actions.</para>
	/// <para>
	/// The total final disk cost for the installation is the sum of the costs of all components plus the cost of the Windows Installer
	/// (szComponent = null).
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/msiquery/nf-msiquery-msienumcomponentcostsa UINT MsiEnumComponentCostsA(
	// MSIHANDLE hInstall, LPCSTR szComponent, DWORD dwIndex, INSTALLSTATE iState, PSTR szDriveBuf, LPDWORD pcchDriveBuf, LPINT piCost,
	// LPINT piTempCost );
	[DllImport(Lib_Msi, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("msiquery.h", MSDNShortId = "NF:msiquery.MsiEnumComponentCostsA")]
	public static extern Win32Error MsiEnumComponentCosts(MSIHANDLE hInstall, [Optional, MarshalAs(UnmanagedType.LPTStr)] string? szComponent, uint dwIndex,
		INSTALLSTATE iState, [Out, MarshalAs(UnmanagedType.LPTStr)] StringBuilder szDriveBuf, ref uint pcchDriveBuf, out int piCost, out int piTempCost);

	/// <summary>The <c>MsiEvaluateCondition</c> function evaluates a conditional expression containing property names and values.</summary>
	/// <param name="hInstall">
	/// Handle to the installation provided to a DLL custom action or obtained through MsiOpenPackage, MsiOpenPackageEx, or MsiOpenProduct.
	/// </param>
	/// <param name="szCondition">
	/// Specifies the conditional expression. This parameter must not be <c>NULL</c>. For the syntax of conditional expressions see
	/// Conditional Statement Syntax.
	/// </param>
	/// <returns>This function returns MSICONDITION.</returns>
	/// <remarks>
	/// <para>
	/// The following table shows the feature and component state values used by the <c>MsiEvaluateCondition</c> function. These states
	/// are not set until MsiSetInstallLevel is called, either directly or by the CostFinalize action. Therefore, state checking is
	/// generally only useful for conditional expressions in an action sequence table.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>INSTALLSTATE_ABSENT</term>
	/// <term>Feature or component not present.</term>
	/// </item>
	/// <item>
	/// <term>INSTALLSTATE_LOCAL</term>
	/// <term>Feature or component on local computer.</term>
	/// </item>
	/// <item>
	/// <term>INSTALLSTATE_SOURCE</term>
	/// <term>Feature or component run from source.</term>
	/// </item>
	/// <item>
	/// <term>(null value)</term>
	/// <term>No action to be taken on feature or component.</term>
	/// </item>
	/// </list>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/msiquery/nf-msiquery-msievaluateconditiona MSICONDITION MsiEvaluateConditionA(
	// MSIHANDLE hInstall, LPCSTR szCondition );
	[DllImport(Lib_Msi, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("msiquery.h", MSDNShortId = "NF:msiquery.MsiEvaluateConditionA")]
	public static extern MSICONDITION MsiEvaluateCondition(MSIHANDLE hInstall, [MarshalAs(UnmanagedType.LPTStr)] string szCondition);

	/// <summary>The <c>MsiFormatRecord</c> function formats record field data and properties using a format string.</summary>
	/// <param name="hInstall">
	/// Handle to the installation. This may be omitted, in which case only the record field parameters are processed and properties are
	/// not available for substitution.
	/// </param>
	/// <param name="hRecord">
	/// Handle to the record to format. The template string must be stored in record field 0 followed by referenced data parameters.
	/// </param>
	/// <param name="szResultBuf">
	/// Pointer to the buffer that receives the null terminated formatted string. Do not attempt to determine the size of the buffer by
	/// passing in a null (value=0) for szResultBuf. You can get the size of the buffer by passing in an empty string (for example "").
	/// The function then returns <c>ERROR_MORE_DATA</c> and pcchResultBuf contains the required buffer size in <c>TCHAR</c> s, not
	/// including the terminating null character. On return of <c>ERROR_SUCCESS</c>, pcchResultBuf contains the number of <c>TCHAR</c> s
	/// written to the buffer, not including the terminating null character.
	/// </param>
	/// <param name="pcchResultBuf">
	/// Pointer to the variable that specifies the size, in <c>TCHAR</c> s, of the buffer pointed to by the variable szResultBuf. When
	/// the function returns <c>ERROR_SUCCESS</c>, this variable contains the size of the data copied to szResultBuf, not including the
	/// terminating null character. If szResultBuf is not large enough, the function returns <c>ERROR_MORE_DATA</c> and stores the
	/// required size, not including the terminating null character, in the variable pointed to by pcchResultBuf.
	/// </param>
	/// <returns>The <c>MsiFormatRecord</c> function returns one of the following values:</returns>
	/// <remarks>
	/// <para>The <c>MsiFormatRecord</c> function uses the following format process.</para>
	/// <para>
	/// Parameters that are to be formatted are enclosed in square brackets [...]. The square brackets can be iterated because the
	/// substitutions are resolved from the inside out.
	/// </para>
	/// <para>
	/// If a part of the string is enclosed in curly braces { } and contains no square brackets, it is left unchanged, including the
	/// curly braces.
	/// </para>
	/// <para>
	/// If a part of the string is enclosed in curly braces { } and contains one or more property names, and if all the properties are
	/// found, the text (with the resolved substitutions) is displayed without the curly braces. If any of the properties is not found,
	/// all the text in the braces and the braces themselves are removed.
	/// </para>
	/// <para>
	/// Note in the case of deferred execution custom actions, <c>MsiFormatRecord</c> only supports <c>CustomActionData</c> and
	/// ProductCode properties. For more information, see Obtaining Context Information for Deferred Execution Custom Actions.
	/// </para>
	/// <para>The following steps describe how to format strings using the <c>MsiFormatRecord</c> function:</para>
	/// <para><c>To format strings using the MsiFormatRecord function</c></para>
	/// <list type="number">
	/// <item>
	/// <term>
	/// The numeric parameters are substituted by replacing the marker with the value of the corresponding record field, with missing or
	/// null values producing no text.
	/// </term>
	/// </item>
	/// <item>
	/// <term>The resultant string is processed by replacing the nonrecord parameters with the corresponding values, described next.</term>
	/// </item>
	/// </list>
	/// <para>
	/// If <c>ERROR_MORE_DATA</c> is returned, the parameter which is a pointer gives the size of the buffer required to hold the
	/// string. If <c>ERROR_SUCCESS</c> is returned, it gives the number of characters written to the string buffer. Therefore you can
	/// get the size of the buffer by passing in an empty string (for example "") for the parameter that specifies the buffer. Do not
	/// attempt to determine the size of the buffer by passing in a Null (value=0).
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/msiquery/nf-msiquery-msiformatrecorda UINT MsiFormatRecordA( MSIHANDLE
	// hInstall, MSIHANDLE hRecord, PSTR szResultBuf, LPDWORD pcchResultBuf );
	[DllImport(Lib_Msi, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("msiquery.h", MSDNShortId = "NF:msiquery.MsiFormatRecordA")]
	public static extern Win32Error MsiFormatRecord([Optional] MSIHANDLE hInstall, MSIHANDLE hRecord,
		[MarshalAs(UnmanagedType.LPTStr)] StringBuilder szResultBuf, ref uint pcchResultBuf);

	/// <summary>
	/// The <c>MsiGetActiveDatabase</c> function returns the active database for the installation. This function returns a read-only
	/// handle that should be closed using MsiCloseHandle.
	/// </summary>
	/// <param name="hInstall">
	/// Handle to the installation provided to a DLL custom action or obtained through MsiOpenPackage, MsiOpenPackageEx, or MsiOpenProduct.
	/// </param>
	/// <returns>
	/// If the function succeeds, it returns a read-only handle to the database currently in use by the installer. If the function
	/// fails, the function returns zero, 0.
	/// </returns>
	/// <remarks>
	/// <para>The <c>MsiGetActiveDatabase</c> function accesses the database in use by the running the installation.</para>
	/// <para>
	/// Note that it is recommended to use variables of type PMSIHANDLE because the installer closes PMSIHANDLE objects as they go out
	/// of scope, whereas you must close MSIHANDLE objects by calling MsiCloseHandle. For more information see Use PMSIHANDLE instead of
	/// HANDLE section in the Windows Installer Best Practices.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/msiquery/nf-msiquery-msigetactivedatabase MSIHANDLE MsiGetActiveDatabase(
	// MSIHANDLE hInstall );
	[DllImport(Lib_Msi, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("msiquery.h", MSDNShortId = "NF:msiquery.MsiGetActiveDatabase")]
	public static extern PMSIHANDLE MsiGetActiveDatabase(MSIHANDLE hInstall);

	/// <summary>The <c>MsiGetComponentState</c> function obtains the state of a component.</summary>
	/// <param name="hInstall">
	/// Handle to the installation provided to a DLL custom action or obtained through MsiOpenPackage, MsiOpenPackageEx, or MsiOpenProduct.
	/// </param>
	/// <param name="szComponent">A null-terminated string that specifies the component name within the product.</param>
	/// <param name="piInstalled">
	/// <para>Receives the current installed state. This parameter must not be null. This parameter can be one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>INSTALLSTATE_ABSENT</term>
	/// <term>The component is not installed.</term>
	/// </item>
	/// <item>
	/// <term>INSTALLSTATE_DEFAULT</term>
	/// <term>The component is installed in the default location: local or source.</term>
	/// </item>
	/// <item>
	/// <term>INSTALLSTATE_LOCAL</term>
	/// <term>The component is installed on the local drive.</term>
	/// </item>
	/// <item>
	/// <term>INSTALLSTATE_REMOVED</term>
	/// <term>The component is being removed. In action state and not settable.</term>
	/// </item>
	/// <item>
	/// <term>INSTALLSTATE_SOURCE</term>
	/// <term>The component runs from the source, CD-ROM, or network.</term>
	/// </item>
	/// <item>
	/// <term>INSTALLSTATE_UNKNOWN</term>
	/// <term>An unrecognized product or feature name was passed to the function.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="piAction">
	/// Receives the action taken during the installation. This parameter must not be null. For return values, see piInstalled.
	/// </param>
	/// <returns>The <c>MsiGetComponentState</c> function returns the following values:</returns>
	/// <remarks>
	/// <para>If the function fails, you can obtain extended error information by using MsiGetLastErrorRecord.</para>
	/// <para>For more information, see Calling Database Functions From Programs.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/msiquery/nf-msiquery-msigetcomponentstatea UINT MsiGetComponentStateA(
	// MSIHANDLE hInstall, LPCSTR szComponent, INSTALLSTATE *piInstalled, INSTALLSTATE *piAction );
	[DllImport(Lib_Msi, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("msiquery.h", MSDNShortId = "NF:msiquery.MsiGetComponentStateA")]
	public static extern Win32Error MsiGetComponentState(MSIHANDLE hInstall, [MarshalAs(UnmanagedType.LPTStr)] string szComponent,
		out INSTALLSTATE piInstalled, out INSTALLSTATE piAction);

	/// <summary>The <c>MsiGetDatabaseState</c> function returns the state of the database.</summary>
	/// <param name="hDatabase">Handle to the database obtained from MsiOpenDatabase.</param>
	/// <returns>This function returns MSIDBSTATE.</returns>
	/// <remarks>The <c>MsiGetDatabaseState</c> function returns the update state of the database.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/msiquery/nf-msiquery-msigetdatabasestate MSIDBSTATE MsiGetDatabaseState(
	// MSIHANDLE hDatabase );
	[DllImport(Lib_Msi, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("msiquery.h", MSDNShortId = "NF:msiquery.MsiGetDatabaseState")]
	public static extern MSIDBSTATE MsiGetDatabaseState(MSIHANDLE hDatabase);

	/// <summary>
	/// The <c>MsiGetFeatureCost</c> function returns the disk space required by a feature and its selected children and parent features.
	/// </summary>
	/// <param name="hInstall">
	/// Handle to the installation provided to a DLL custom action or obtained through MsiOpenPackage, MsiOpenPackageEx, or MsiOpenProduct.
	/// </param>
	/// <param name="szFeature">Specifies the name of the feature.</param>
	/// <param name="iCostTree">
	/// <para>
	/// Specifies the value the function uses to determine disk space requirements. This parameter can be one of the following values.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>MSICOSTTREE_CHILDREN</term>
	/// <term>The children of the indicated feature are included in the cost.</term>
	/// </item>
	/// <item>
	/// <term>MSICOSTTREE_PARENTS</term>
	/// <term>The parent features of the indicated feature are included in the cost.</term>
	/// </item>
	/// <item>
	/// <term>MSICOSTTREE_SELFONLY</term>
	/// <term>The feature only is included in the cost.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="iState">
	/// <para>Specifies the installation state. This parameter can be one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>INSTALLSTATE_UNKNOWN</term>
	/// <term>The product or feature is unrecognized.</term>
	/// </item>
	/// <item>
	/// <term>INSTALLSTATE_ABSENT</term>
	/// <term>The product or feature is uninstalled.</term>
	/// </item>
	/// <item>
	/// <term>INSTALLSTATE_LOCAL</term>
	/// <term>The product or feature is installed on the local drive.</term>
	/// </item>
	/// <item>
	/// <term>INSTALLSTATE_SOURCE</term>
	/// <term>The product or feature is installed to run from source, CD, or network.</term>
	/// </item>
	/// <item>
	/// <term>INSTALLSTATE_DEFAULT</term>
	/// <term>The product or feature will be installed to use the default location: local or source.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="piCost">Receives the disk space requirements in units of 512 bytes. This parameter must not be null.</param>
	/// <returns>The <c>MsiGetFeatureCost</c> function returns the following values:</returns>
	/// <remarks>
	/// <para>See Calling Database Functions From Programs.</para>
	/// <para>
	/// With the <c>MsiGetFeatureCost</c> function, the MSICOSTTREE_SELFONLY value indicates the total amount of disk space (in units of
	/// 512 bytes) required by the specified feature only. This returned value does not include the children or the parent features of
	/// the specified feature. This total cost is made up of the disk costs attributed to every component linked to the feature.
	/// </para>
	/// <para>
	/// The MSICOSTTREE_CHILDREN value indicates the total amount of disk space (in units of 512 bytes) required by the specified
	/// feature and its children. For each feature, the total cost is made up of the disk costs attributed to every component linked to
	/// the feature.
	/// </para>
	/// <para>
	/// The MSICOSTTREE_PARENTS value indicates the total amount of disk space (in units of 512 bytes) required by the specified feature
	/// and its parent features (up to the root of the Feature table). For each feature, the total cost is made up of the disk costs
	/// attributed to every component linked to the feature.
	/// </para>
	/// <para>
	/// <c>MsiGetFeatureCost</c> is dependent upon several other functions to be successful. The following example demonstrates the
	/// order in which these functions must be called:
	/// </para>
	/// <para>
	/// <code>MSIHANDLE hInstall; //product handle, must be closed int iCost; //cost returned by MsiGetFeatureCost MsiOpenPackage("Path to package....",&amp;hInstall); //"Path to package...." should be replaced with the full path to the package to be opened MsiDoAction(hInstall,"CostInitialize"); // MsiDoAction(hInstall,"FileCost"); MsiDoAction(hInstall,"CostFinalize"); MsiDoAction(hInstall,"InstallValidate"); MsiGetFeatureCost(hInstall,"FeatureName",MSICOSTTREE_SELFONLY,INSTALLSTATE_ABSENT,&amp;iCost); MsiCloseHandle(hInstall); //close the open product handle</code>
	/// </para>
	/// <para>The process to query the cost of features scheduled to be removed is slightly different:</para>
	/// <para>
	/// <code>MSIHANDLE hInstall; //product handle, must be closed int iCost; //cost returned by MsiGetFeatureCost MsiOpenPackage("Path to package....",&amp;hInstall); //"Path to package...." should be replaced with the full path to the package to be opened MsiDoAction(hInstall,"CostInitialize"); // MsiDoAction(hInstall,"FileCost"); MsiDoAction(hInstall,"CostFinalize"); MsiSetFeatureState(hInstall,"FeatureName",INSTALLSTATE_ABSENT); //set the feature's state to "not installed" MsiDoAction(hInstall,"InstallValidate"); MsiGetFeatureCost(hInstall,"FeatureName",MSICOSTTREE_SELFONLY,INSTALLSTATE_ABSENT,&amp;iCost); MsiCloseHandle(hInstall); //close the open product handle</code>
	/// </para>
	/// <para>If the function fails, you can obtain extended error information by using MsiGetLastErrorRecord.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/msiquery/nf-msiquery-msigetfeaturecosta UINT MsiGetFeatureCostA( MSIHANDLE
	// hInstall, LPCSTR szFeature, MSICOSTTREE iCostTree, INSTALLSTATE iState, LPINT piCost );
	[DllImport(Lib_Msi, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("msiquery.h", MSDNShortId = "NF:msiquery.MsiGetFeatureCostA")]
	public static extern Win32Error MsiGetFeatureCost(MSIHANDLE hInstall, [MarshalAs(UnmanagedType.LPTStr)] string szFeature, MSICOSTTREE iCostTree,
		INSTALLSTATE iState, out int piCost);

	/// <summary>The <c>MsiGetFeatureState</c> function gets the requested state of a feature.</summary>
	/// <param name="hInstall">
	/// Handle to the installation provided to a DLL custom action or obtained through MsiOpenPackage, MsiOpenPackageEx, or MsiOpenProduct.
	/// </param>
	/// <param name="szFeature">Specifies the feature name within the product.</param>
	/// <param name="piInstalled">
	/// <para>
	/// Specifies the returned current installed state. This parameter must not be null. This parameter can be one of the following values.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>INSTALLSTATE_BADCONFIG</term>
	/// <term>The configuration data is corrupt.</term>
	/// </item>
	/// <item>
	/// <term>INSTALLSTATE_INCOMPLETE</term>
	/// <term>The installation is suspended or in progress.</term>
	/// </item>
	/// <item>
	/// <term>INSTALLSTATE_SOURCEABSENT</term>
	/// <term>The feature must run from the source, and the source is unavailable.</term>
	/// </item>
	/// <item>
	/// <term>INSTALLSTATE_MOREDATA</term>
	/// <term>The return buffer is full.</term>
	/// </item>
	/// <item>
	/// <term>INSTALLSTATE_INVALIDARG</term>
	/// <term>An invalid parameter was passed to the function.</term>
	/// </item>
	/// <item>
	/// <term>INSTALLSTATE_UNKNOWN</term>
	/// <term>An unrecognized product or feature was specified.</term>
	/// </item>
	/// <item>
	/// <term>INSTALLSTATE_BROKEN</term>
	/// <term>The feature is broken.</term>
	/// </item>
	/// <item>
	/// <term>INSTALLSTATE_ADVERTISED</term>
	/// <term>The advertised feature.</term>
	/// </item>
	/// <item>
	/// <term>INSTALLSTATE_ABSENT</term>
	/// <term>The feature was uninstalled.</term>
	/// </item>
	/// <item>
	/// <term>INSTALLSTATE_LOCAL</term>
	/// <term>The feature was installed on the local drive.</term>
	/// </item>
	/// <item>
	/// <term>INSTALLSTATE_SOURCE</term>
	/// <term>The feature must run from the source, CD-ROM, or network.</term>
	/// </item>
	/// <item>
	/// <term>INSTALLSTATE_DEFAULT</term>
	/// <term>The feature is installed in the default location: local or source.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="piAction">
	/// Receives the action taken during the installation session. This parameter must not be null. For return values, see piInstalled.
	/// </param>
	/// <returns>The <c>MsiGetFeatureState</c> function returns the following values:</returns>
	/// <remarks>
	/// <para>See Calling Database Functions From Programs.</para>
	/// <para>If the function fails, you can obtain extended error information by using MsiGetLastErrorRecord.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/msiquery/nf-msiquery-msigetfeaturestatea UINT MsiGetFeatureStateA( MSIHANDLE
	// hInstall, LPCSTR szFeature, INSTALLSTATE *piInstalled, INSTALLSTATE *piAction );
	[DllImport(Lib_Msi, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("msiquery.h", MSDNShortId = "NF:msiquery.MsiGetFeatureStateA")]
	public static extern Win32Error MsiGetFeatureState(MSIHANDLE hInstall, [MarshalAs(UnmanagedType.LPTStr)] string szFeature,
		out INSTALLSTATE piInstalled, out INSTALLSTATE piAction);

	/// <summary>The <c>MsiGetFeatureValidStates</c> function returns a valid installation state.</summary>
	/// <param name="hInstall">
	/// Handle to the installation provided to a DLL custom action or obtained through MsiOpenPackage, MsiOpenPackageEx, or MsiOpenProduct.
	/// </param>
	/// <param name="szFeature">Specifies the feature name.</param>
	/// <param name="lpInstallStates">
	/// <para>
	/// Receives the location to hold the valid installation states. For each valid installation state, the installer sets pInstallState
	/// to a combination of the following values. This parameter should not be null.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Decimal Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>2 INSTALLSTATE_ADVERTISED</term>
	/// <term>The feature can be advertised.</term>
	/// </item>
	/// <item>
	/// <term>4 INSTALLSTATE_ABSENT</term>
	/// <term>The feature can be absent.</term>
	/// </item>
	/// <item>
	/// <term>8 INSTALLSTATE_LOCAL</term>
	/// <term>The feature can be installed on the local drive.</term>
	/// </item>
	/// <item>
	/// <term>16 INSTALLSTATE_SOURCE</term>
	/// <term>The feature can be configured to run from source, CD-ROM, or network.</term>
	/// </item>
	/// <item>
	/// <term>32 INSTALLSTATE_DEFAULT</term>
	/// <term>The feature can be configured to use the default location: local or source.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <returns>The <c>MsiGetFeatureValidStates</c> function returns the following values:</returns>
	/// <remarks>
	/// <para>See Calling Database Functions From Programs.</para>
	/// <para>
	/// The <c>MsiGetFeatureValidStates</c> function determines state validity by querying all components that are linked to the
	/// specified feature without taking into account the current installed state of any component.
	/// </para>
	/// <para>The possible valid states for a feature are determined as follows:</para>
	/// <list type="bullet">
	/// <item>
	/// <term>If the feature does not contain components, both INSTALLSTATE_LOCAL and INSTALLSTATE_SOURCE are valid states for the feature.</term>
	/// </item>
	/// <item>
	/// <term>
	/// If at least one component of the feature has an attribute of msidbComponentAttributesLocalOnly or
	/// msidbComponentAttributesOptional, INSTALLSTATE_LOCAL is a valid state for the feature.
	/// </term>
	/// </item>
	/// <item>
	/// <term>
	/// If at least one component of the feature has an attribute of msidbComponentAttributesSourceOnly or
	/// msidbComponentAttributesOptional, INSTALLSTATE_SOURCE is a valid state for the feature.
	/// </term>
	/// </item>
	/// <item>
	/// <term>
	/// If a file of a component that belongs to the feature is patched or from a compressed source, then INSTALLSTATE_SOURCE is not
	/// included as a valid state for the feature.
	/// </term>
	/// </item>
	/// <item>
	/// <term>
	/// INSTALLSTATE_ADVERTISE is not a valid state if the feature disallows advertisement (msidbFeatureAttributesDisallowAdvertise) or
	/// the feature requires platform support for advertisement (msidbFeatureAttributesNoUnsupportedAdvertise) and the platform does not
	/// support it.
	/// </term>
	/// </item>
	/// <item>
	/// <term>INSTALLSTATE_ABSENT is a valid state for the feature if its attributes do not include msidbFeatureAttributesUIDisallowAbsent.</term>
	/// </item>
	/// <item>
	/// <term>
	/// Valid states for child features marked to follow the parent feature (msidbFeatureAttributesFollowParent) are based upon the
	/// parent feature's action or installed state.
	/// </term>
	/// </item>
	/// </list>
	/// <para>
	/// After calling <c>MsiGetFeatureValidStates</c> a conditional statement may then be used to test the valid installation states of
	/// a feature. For example, the following call to <c>MsiGetFeatureValidStates</c> gets the installation state of Feature1.
	/// </para>
	/// <para>
	/// <code>MsiGetFeatureValidStates(hProduct, "Feature1", &amp;dwValidStates);</code>
	/// </para>
	/// <para>
	/// If Feature1 has attributes of value 0 (favor local), and Feature1 has one component with attributes of value 0 (local only), the
	/// value of dwValidStates after the call is 14. This indicates that INSTALLSTATE_LOCAL, INSTALLSTATE_ABSENT,and
	/// INSTALLSTATE_ADVERTISED are valid states for Feature1. The following conditional statement evaluates to True if local is a valid
	/// state for this feature.
	/// </para>
	/// <para>( ( dwValidStates &amp; ( 1 &lt;&lt; INSTALLSTATE_LOCAL ) ) == ( 1 &lt;&lt; INSTALLSTATE_LOCAL ) )</para>
	/// <para>If the function fails, you can obtain extended error information by using MsiGetLastErrorRecord.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/msiquery/nf-msiquery-msigetfeaturevalidstatesw UINT MsiGetFeatureValidStatesW(
	// MSIHANDLE hInstall, LPCWSTR szFeature, LPDWORD lpInstallStates );
	[DllImport(Lib_Msi, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("msiquery.h", MSDNShortId = "NF:msiquery.MsiGetFeatureValidStatesW")]
	public static extern Win32Error MsiGetFeatureValidStates(MSIHANDLE hInstall, [MarshalAs(UnmanagedType.LPTStr)] string szFeature, out INSTALLSTATE lpInstallStates);

	/// <summary>The <c>MsiGetLanguage</c> function returns the numeric language of the installation that is currently running.</summary>
	/// <param name="hInstall">
	/// Handle to the installation provided to a DLL custom action or obtained through MsiOpenPackage, MsiOpenPackageEx, or MsiOpenProduct.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is the numeric LANGID for the install.</para>
	/// <para>If the function fails, the return value can be the following value.</para>
	/// </returns>
	/// <remarks>The <c>MsiGetLanguage</c> function returns 0 if an installation is not running.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/msiquery/nf-msiquery-msigetlanguage LANGID MsiGetLanguage( MSIHANDLE hInstall );
	[DllImport(Lib_Msi, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("msiquery.h", MSDNShortId = "NF:msiquery.MsiGetLanguage")]
	public static extern ushort MsiGetLanguage(MSIHANDLE hInstall);

	/// <summary>
	/// The <c>MsiGetLastErrorRecord</c> function returns the error record that was last returned for the calling process. This function
	/// returns a handle that should be closed using MsiCloseHandle.
	/// </summary>
	/// <returns>A handle to the error record. If the last function was successful, <c>MsiGetLastErrorRecord</c> returns a null <c>MSIHANDLE</c>.</returns>
	/// <remarks>
	/// <para>
	/// With the <c>MsiGetLastErrorRecord</c> function, field 1 of the record contains the installer error code. Other fields contain
	/// data specific to the particular error. The error record is released internally after this function is run.
	/// </para>
	/// <para>
	/// If the record is passed to MsiProcessMessage, it is formatted by looking up the string in the current database. If there is no
	/// installation session but a product database is open, the format string may be obtained by a query on the Error table using the
	/// error code, followed by a call to MsiFormatRecord. If the error code is known, the parameters may be individually interpreted.
	/// </para>
	/// <para>
	/// The following functions set the per-process error record or reset it to null if no error occurred. <c>MsiGetLastErrorRecord</c>
	/// also clears the error record after returning it.
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>MsiOpenDatabase</term>
	/// </item>
	/// <item>
	/// <term>MsiDatabaseCommit</term>
	/// </item>
	/// <item>
	/// <term>MsiDatabaseOpenView</term>
	/// </item>
	/// <item>
	/// <term>MsiDatabaseImport</term>
	/// </item>
	/// <item>
	/// <term>MsiDatabaseExport</term>
	/// </item>
	/// <item>
	/// <term>MsiDatabaseMerge</term>
	/// </item>
	/// <item>
	/// <term>MsiDatabaseGenerateTransform</term>
	/// </item>
	/// <item>
	/// <term>MsiDatabaseApplyTransform</term>
	/// </item>
	/// <item>
	/// <term>MsiViewExecute</term>
	/// </item>
	/// <item>
	/// <term>MsiViewModify</term>
	/// </item>
	/// <item>
	/// <term>MsiRecordSetStream</term>
	/// </item>
	/// <item>
	/// <term>MsiGetSummaryInformation</term>
	/// </item>
	/// <item>
	/// <term>MsiGetSourcePath</term>
	/// </item>
	/// <item>
	/// <term>MsiGetTargetPath</term>
	/// </item>
	/// <item>
	/// <term>MsiSetTargetPath</term>
	/// </item>
	/// <item>
	/// <term>MsiGetComponentState</term>
	/// </item>
	/// <item>
	/// <term>MsiSetComponentState</term>
	/// </item>
	/// <item>
	/// <term>MsiGetFeatureState</term>
	/// </item>
	/// <item>
	/// <term>MsiSetFeatureState</term>
	/// </item>
	/// <item>
	/// <term>MsiGetFeatureCost</term>
	/// </item>
	/// <item>
	/// <term>MsiGetFeatureValidStates</term>
	/// </item>
	/// <item>
	/// <term>MsiSetInstallLevel</term>
	/// </item>
	/// </list>
	/// <para>
	/// Note that it is recommended to use variables of type PMSIHANDLE because the installer closes PMSIHANDLE objects as they go out
	/// of scope, whereas you must close MSIHANDLE objects by calling MsiCloseHandle. For more information see Use PMSIHANDLE instead of
	/// HANDLE section in the Windows Installer Best Practices.
	/// </para>
	/// <para>
	/// The following sample uses a call to MsiDatabaseOpenView to show how to obtain extended error information from one of the Windows
	/// Installer functions that supports <c>MsiGetLastErrorRecord</c>. The example, OpenViewOnDatabase, attempts to open a view on a
	/// database handle. The hDatabase handle can be obtained by a call to MsiOpenDatabase. If opening the view fails, the function then
	/// tries to obtain extended error information by using <c>MsiGetLastErrorRecord</c>.
	/// </para>
	/// <para>
	/// <code>#include &lt;windows.h&gt; #include &lt;Msiquery.h&gt; #pragma comment(lib, "msi.lib") //-------------------------------------------------------------------
	/// // Function: OpenViewOnDatabase // // Arguments: hDatabase - handle to a MSI package obtained // via a call to MsiOpenDatabase //
	/// // Returns: UINT status code. ERROR_SUCCESS for success. //--------------------------------------------------------------------------------------------------
	/// UINT __stdcall OpenViewOnDatabase(MSIHANDLE hDatabase) { if (!hDatabase) return ERROR_INVALID_PARAMETER; PMSIHANDLE hView = 0;
	/// UINT uiReturn = MsiDatabaseOpenView(hDatabase, TEXT("SELECT * FROM `UnknownTable`"), &amp;hView); if (ERROR_SUCCESS != uiReturn)
	/// { // try to obtain extended error information. PMSIHANDLE hLastErrorRec = MsiGetLastErrorRecord(); TCHAR* szExtendedError = NULL;
	/// DWORD cchExtendedError = 0; if (hLastErrorRec) { // Since we are not currently calling MsiFormatRecord during an 
	/// // install session, hInstall is NULL. If MsiFormatRecord was called // via a DLL custom action, the hInstall handle provided to the DLL
	/// // custom action entry point could be used to further resolve // properties that might be contained within the error record.
	/// // To determine the size of the buffer required for the text, // szResultBuf must be provided as an empty string with
	/// // *pcchResultBuf set to 0. UINT uiStatus = MsiFormatRecord(NULL, hLastErrorRec, TEXT(""), &amp;cchExtendedError);
	/// if (ERROR_MORE_DATA == uiStatus) { // returned size does not include null terminator. cchExtendedError++;
	/// szExtendedError = new TCHAR[cchExtendedError]; if (szExtendedError) { uiStatus = MsiFormatRecord(NULL, hLastErrorRec, szExtendedError, &amp;cchExtendedError);
	/// if (ERROR_SUCCESS == uiStatus) { // We now have an extended error // message to report. // PLACE ADDITIONAL CODE HERE
	/// // TO LOG THE ERROR MESSAGE // IN szExtendedError. } delete [] szExtendedError; szExtendedError = NULL; } } } } return uiReturn; }</code>
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/msiquery/nf-msiquery-msigetlasterrorrecord MSIHANDLE MsiGetLastErrorRecord();
	[DllImport(Lib_Msi, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("msiquery.h", MSDNShortId = "NF:msiquery.MsiGetLastErrorRecord")]
	public static extern PMSIHANDLE MsiGetLastErrorRecord();

	/// <summary>
	/// The <c>MsiGetMode</c> function is used to determine whether the installer is currently running in a specified mode, as listed in
	/// the table. The function returns a Boolean value of <c>TRUE</c> or <c>FALSE</c>, indicating whether the specific property passed
	/// into the function is currently set ( <c>TRUE</c>) or not set ( <c>FALSE</c>).
	/// </summary>
	/// <param name="hInstall">
	/// Handle to the installation provided to a DLL custom action or obtained through MsiOpenPackage, MsiOpenPackageEx, or MsiOpenProduct.
	/// </param>
	/// <param name="eRunMode">
	/// <para>Specifies the run mode. This parameter must have one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>MSIRUNMODE_ADMIN</term>
	/// <term>The administrative mode is installing, or the product is installing.</term>
	/// </item>
	/// <item>
	/// <term>MSIRUNMODE_ADVERTISE</term>
	/// <term>The advertisements are installing or the product is installing or updating.</term>
	/// </item>
	/// <item>
	/// <term>MSIRUNMODE_MAINTENANCE</term>
	/// <term>An existing installation is being modified or there is a new installation.</term>
	/// </item>
	/// <item>
	/// <term>MSIRUNMODE_ROLLBACKENABLED</term>
	/// <term>Rollback is enabled.</term>
	/// </item>
	/// <item>
	/// <term>MSIRUNMODE_LOGENABLED</term>
	/// <term>The log file is active. It was enabled prior to the installation session.</term>
	/// </item>
	/// <item>
	/// <term>MSIRUNMODE_OPERATIONS</term>
	/// <term>Execute operations are in the determination phase.</term>
	/// </item>
	/// <item>
	/// <term>MSIRUNMODE_REBOOTATEND</term>
	/// <term>A reboot is necessary after a successful installation (settable).</term>
	/// </item>
	/// <item>
	/// <term>MSIRUNMODE_REBOOTNOW</term>
	/// <term>A reboot is necessary to continue the installation (settable).</term>
	/// </item>
	/// <item>
	/// <term>MSIRUNMODE_CABINET</term>
	/// <term>Files from cabinets and Media table files are installing.</term>
	/// </item>
	/// <item>
	/// <term>MSIRUNMODE_SOURCESHORTNAMES</term>
	/// <term>The source LongFileNames is suppressed through the PID_MSISOURCE summary property.</term>
	/// </item>
	/// <item>
	/// <term>MSIRUNMODE_TARGETSHORTNAMES</term>
	/// <term>The target LongFileNames is suppressed through the SHORTFILENAMES property.</term>
	/// </item>
	/// <item>
	/// <term>MSIRUNMODE_RESERVED11</term>
	/// <term>Reserved for future use.</term>
	/// </item>
	/// <item>
	/// <term>MSIRUNMODE_WINDOWS9X</term>
	/// <term>The operating system is a 9x version.</term>
	/// </item>
	/// <item>
	/// <term>MSIRUNMODE_ZAWENABLED</term>
	/// <term>The operating system supports demand installation.</term>
	/// </item>
	/// <item>
	/// <term>MSIRUNMODE_RESERVED14</term>
	/// <term>Reserved for future use.</term>
	/// </item>
	/// <item>
	/// <term>MSIRUNMODE_RESERVED15</term>
	/// <term>Reserved for future use.</term>
	/// </item>
	/// <item>
	/// <term>MSIRUNMODE_SCHEDULED</term>
	/// <term>A custom action called from install script execution.</term>
	/// </item>
	/// <item>
	/// <term>MSIRUNMODE_ROLLBACK</term>
	/// <term>A custom action called from rollback execution script.</term>
	/// </item>
	/// <item>
	/// <term>MSIRUNMODE_COMMIT</term>
	/// <term>A custom action called from commit execution script.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <returns>
	/// <para><c>TRUE</c> indicates the specific property passed into the function is currently set.</para>
	/// <para><c>FALSE</c> indicates the specific property passed into the function is currently not set.</para>
	/// </returns>
	/// <remarks>
	/// Note that not all the run mode values of iRunMode are available when calling <c>MsiGetMode</c> from a deferred custom action.
	/// For details, see Obtaining Context Information for Deferred Execution Custom Actions.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/msiquery/nf-msiquery-msigetmode BOOL MsiGetMode( MSIHANDLE hInstall,
	// MSIRUNMODE eRunMode );
	[DllImport(Lib_Msi, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("msiquery.h", MSDNShortId = "NF:msiquery.MsiGetMode")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool MsiGetMode(MSIHANDLE hInstall, MSIRUNMODE eRunMode);

	/// <summary>The <c>MsiGetProperty</c> function gets the value for an installer property.</summary>
	/// <param name="hInstall">
	/// Handle to the installation provided to a DLL custom action or obtained through MsiOpenPackage, MsiOpenPackageEx, or MsiOpenProduct.
	/// </param>
	/// <param name="szName">A null-terminated string that specifies the name of the property.</param>
	/// <param name="szValueBuf">
	/// Pointer to the buffer that receives the null terminated string containing the value of the property. Do not attempt to determine the
	/// size of the buffer by passing in a null (value=0) for szValueBuf. You can get the size of the buffer by passing in an empty string
	/// (for example ""). The function will then return ERROR_MORE_DATA and pchValueBuf will contain the required buffer size in TCHARs, not
	/// including the terminating null character. On return of ERROR_SUCCESS, pcchValueBuf contains the number of TCHARs written to the
	/// buffer, not including the terminating null character.
	/// </param>
	/// <param name="pcchValueBuf">
	/// Pointer to the variable that specifies the size, in TCHARs, of the buffer pointed to by the variable szValueBuf. When the function
	/// returns ERROR_SUCCESS, this variable contains the size of the data copied to szValueBuf, not including the terminating null
	/// character. If szValueBuf is not large enough, the function returns ERROR_MORE_DATA and stores the required size, not including the
	/// terminating null character, in the variable pointed to by pchValueBuf.
	/// </param>
	/// <returns>This function returns UINT.</returns>
	/// <remarks>
	/// <para>
	/// If the value for the property retrieved by the <c>MsiGetProperty</c> function is not defined, it is equivalent to a 0-length value.
	/// It is not an error.
	/// </para>
	/// <para>
	/// If ERROR_MORE_DATA is returned, the parameter which is a pointer gives the size of the buffer required to hold the string. If
	/// ERROR_SUCCESS is returned, it gives the number of characters written to the string buffer. Therefore you can get the size of the
	/// buffer by passing in an empty string (for example "") for the parameter that specifies the buffer. Do not attempt to determine the
	/// size of the buffer by passing in a Null (value=0).
	/// </para>
	/// <para>
	/// The following example shows how a DLL custom action could access the value of a property by dynamically determining the size of the
	/// value buffer.
	/// </para>
	/// <para>
	/// <code>UINT __stdcall MyCustomAction(MSIHANDLE hInstall) { TCHAR* szValueBuf = NULL; DWORD cchValueBuf = 0; UINT uiStat = MsiGetProperty(hInstall, TEXT("MyProperty"), TEXT(""), &amp;cchValueBuf); //cchValueBuf now contains the size of the property's string, without null termination if (ERROR_MORE_DATA == uiStat) { ++cchValueBuf; // add 1 for null termination szValueBuf = new TCHAR[cchValueBuf]; if (szValueBuf) { uiStat = MsiGetProperty(hInstall, TEXT("MyProperty"), szValueBuf, &amp;cchValueBuf); } } if (ERROR_SUCCESS != uiStat) { if (szValueBuf != NULL) delete[] szValueBuf; return ERROR_INSTALL_FAILURE; } // custom action uses MyProperty // ... delete[] szValueBuf; return ERROR_SUCCESS; }</code>
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/msiquery/nf-msiquery-msigetpropertya UINT MsiGetPropertyA( MSIHANDLE hInstall,
	// LPCSTR szName, PSTR szValueBuf, LPDWORD pcchValueBuf );
	[DllImport(Lib_Msi, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("msiquery.h", MSDNShortId = "NF:msiquery.MsiGetPropertyA")]
	public static extern Win32Error MsiGetProperty(MSIHANDLE hInstall, [MarshalAs(UnmanagedType.LPTStr)] string szName,
		[Out, MarshalAs(UnmanagedType.LPTStr)] StringBuilder szValueBuf, ref uint pcchValueBuf);

	/// <summary>The <c>MsiGetSourcePath</c> function returns the full source path for a folder in the Directory table.</summary>
	/// <param name="hInstall">
	/// Handle to the installation provided to a DLL custom action or obtained through MsiOpenPackage, MsiOpenPackageEx, or MsiOpenProduct.
	/// </param>
	/// <param name="szFolder">
	/// A null-terminated string that specifies a record of the Directory table. If the directory is a root directory, this can be a
	/// value from the DefaultDir column. Otherwise it must be a value from the Directory column.
	/// </param>
	/// <param name="szPathBuf">
	/// Pointer to the buffer that receives the null terminated full source path. Do not attempt to determine the size of the buffer by
	/// passing in a null (value=0) for szPathBuf. You can get the size of the buffer by passing in an empty string (for example "").
	/// The function then returns ERROR_MORE_DATA and pcchPathBuf contains the required buffer size in TCHARs, not including the
	/// terminating null character. On return of ERROR_SUCCESS, pcchPathBuf contains the number of TCHARs written to the buffer, not
	/// including the terminating null character.
	/// </param>
	/// <param name="pcchPathBuf">
	/// Pointer to the variable that specifies the size, in TCHARs, of the buffer pointed to by the variable szPathBuf. When the
	/// function returns ERROR_SUCCESS, this variable contains the size of the data copied to szPathBuf, not including the terminating
	/// null character. If szPathBuf is not large enough, the function returns ERROR_MORE_DATA and stores the required size, not
	/// including the terminating null character, in the variable pointed to by pcchPathBuf.
	/// </param>
	/// <returns>The <c>MsiGetSourcePath</c> function returns the following values:</returns>
	/// <remarks>
	/// <para>
	/// Before calling this function, the installer must first run the CostInitialize action, FileCost action, and CostFinalize action.
	/// For more information, see Calling Database Functions from Programs.
	/// </para>
	/// <para>
	/// If ERROR_MORE_DATA is returned, the parameter which is a pointer gives the size of the buffer required to hold the string. If
	/// ERROR_SUCCESS is returned, it gives the number of characters written to the string buffer. Therefore you can get the size of the
	/// buffer by passing in an empty string (for example "") for the parameter that specifies the buffer. Do not attempt to determine
	/// the size of the buffer by passing in a Null (value=0).
	/// </para>
	/// <para>If the function fails, you can obtain extended error information by using MsiGetLastErrorRecord.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/msiquery/nf-msiquery-msigetsourcepatha UINT MsiGetSourcePathA( MSIHANDLE
	// hInstall, LPCSTR szFolder, PSTR szPathBuf, LPDWORD pcchPathBuf );
	[DllImport(Lib_Msi, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("msiquery.h", MSDNShortId = "NF:msiquery.MsiGetSourcePathA")]
	public static extern Win32Error MsiGetSourcePath(MSIHANDLE hInstall, [MarshalAs(UnmanagedType.LPTStr)] string szFolder,
		[Out, MarshalAs(UnmanagedType.LPTStr)] StringBuilder szPathBuf, ref uint pcchPathBuf);

	/// <summary>
	/// The <c>MsiGetSummaryInformation</c> function obtains a handle to the _SummaryInformation stream for an installer database. This
	/// function returns a handle that should be closed using MsiCloseHandle.
	/// </summary>
	/// <param name="hDatabase">Handle to the database.</param>
	/// <param name="szDatabasePath">Specifies the path to the database.</param>
	/// <param name="uiUpdateCount">Specifies the maximum number of updated values.</param>
	/// <param name="phSummaryInfo">Pointer to the location from which to receive the summary information handle.</param>
	/// <returns>The <c>MsiGetSummaryInformation</c> function returns the following values:</returns>
	/// <remarks>
	/// <para>
	/// If the database specified by the <c>MsiGetSummaryInformation</c> function is not open, you must specify 0 for hDatabase and
	/// specify the path to the database in szDatabasePath. If the database is open, you must set szDatabasePath to 0.
	/// </para>
	/// <para>
	/// If a value of uiUpdateCount greater than 0 is used to open an existing summary information stream, MsiSummaryInfoPersist must be
	/// called before closing the phSummaryInfo handle. Failing to do this will lose the existing stream information.
	/// </para>
	/// <para>
	/// To view the summary information of a patch using <c>MsiGetSummaryInformation</c>, set szDatabasePath to the path to the patch.
	/// Alternately, you can create a handle to the patch using MsiOpenDatabase and then pass that handle to
	/// <c>MsiGetSummaryInformation</c> as the hDatabase parameter.
	/// </para>
	/// <para>
	/// Note that it is recommended to use variables of type PMSIHANDLE because the installer closes PMSIHANDLE objects as they go out
	/// of scope, whereas you must close MSIHANDLE objects by calling MsiCloseHandle. For more information see Use PMSIHANDLE instead of
	/// HANDLE section in the Windows Installer Best Practices.
	/// </para>
	/// <para>If the function fails, you can obtain extended error information by using MsiGetLastErrorRecord.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/msiquery/nf-msiquery-msigetsummaryinformationw UINT MsiGetSummaryInformationW(
	// MSIHANDLE hDatabase, LPCWSTR szDatabasePath, UINT uiUpdateCount, MSIHANDLE *phSummaryInfo );
	[DllImport(Lib_Msi, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("msiquery.h", MSDNShortId = "NF:msiquery.MsiGetSummaryInformationW")]
	public static extern Win32Error MsiGetSummaryInformation(MSIHANDLE hDatabase, [MarshalAs(UnmanagedType.LPTStr)] string szDatabasePath,
		uint uiUpdateCount, out PMSIHANDLE phSummaryInfo);

	/// <summary>The <c>MsiGetTargetPath</c> function returns the full target path for a folder in the Directory table.</summary>
	/// <param name="hInstall">
	/// Handle to the installation provided to a DLL custom action or obtained through MsiOpenPackage, MsiOpenPackageEx, or MsiOpenProduct.
	/// </param>
	/// <param name="szFolder">
	/// A null-terminated string that specifies a record of the Directory table. If the directory is a root directory, this can be a
	/// value from the DefaultDir column. Otherwise it must be a value from the Directory column.
	/// </param>
	/// <param name="szPathBuf">
	/// Pointer to the buffer that receives the null terminated full target path. Do not attempt to determine the size of the buffer by
	/// passing in a null (value=0) for szPathBuf. You can get the size of the buffer by passing in an empty string (for example "").
	/// The function then returns ERROR_MORE_DATA and pcchPathBuf contains the required buffer size in TCHARs, not including the
	/// terminating null character. On return of ERROR_SUCCESS, pcchPathBuf contains the number of TCHARs written to the buffer, not
	/// including the terminating null character.
	/// </param>
	/// <param name="pcchPathBuf">
	/// Pointer to the variable that specifies the size, in <c>TCHARs</c>, of the buffer pointed to by the variable szPathBuf When the
	/// function returns ERROR_SUCCESS, this variable contains the size of the data copied to szPathBuf, not including the terminating
	/// null character. If szPathBuf is not large enough, the function returns ERROR_MORE_DATA and stores the required size, not
	/// including the terminating null character, in the variable pointed to by pcchPathBuf.
	/// </param>
	/// <returns>The <c>MsiGetTargetPath</c> function returns the following values:</returns>
	/// <remarks>
	/// <para>
	/// If ERROR_MORE_DATA is returned, the parameter which is a pointer gives the size of the buffer required to hold the string. If
	/// ERROR_SUCCESS is returned, it gives the number of characters written to the string buffer. Therefore you can get the size of the
	/// buffer by passing in an empty string (for example "") for the parameter that specifies the buffer. Do not attempt to determine
	/// the size of the buffer by passing in a Null (value=0).
	/// </para>
	/// <para>
	/// Before calling this function, the installer must first run the CostInitialize action, FileCost action, and CostFinalize action.
	/// For more information, see Calling Database Functions from Programs.
	/// </para>
	/// <para>
	/// <c>MsiGetTargetPath</c> returns the default path of the target directory authored in the package if the target's current
	/// location is unavailable for an installation. For example, if during a Maintenance Installation a target directory at a network
	/// location is unavailable, the installer resets the target directory paths back to their defaults. To get the actual path of the
	/// target directory in this case call MsiProvideComponent for a component that is known to have been previously installed into the
	/// searched for directory and set dwInstallMode to INSTALLMODE_NODETECTION.
	/// </para>
	/// <para>For more information, see Calling Database Functions From Programs.</para>
	/// <para>If the function fails, you can obtain extended error information by using MsiGetLastErrorRecord.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/msiquery/nf-msiquery-msigettargetpatha UINT MsiGetTargetPathA( MSIHANDLE
	// hInstall, LPCSTR szFolder, PSTR szPathBuf, LPDWORD pcchPathBuf );
	[DllImport(Lib_Msi, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("msiquery.h", MSDNShortId = "NF:msiquery.MsiGetTargetPathA")]
	public static extern Win32Error MsiGetTargetPath(MSIHANDLE hInstall, [MarshalAs(UnmanagedType.LPTStr)] string szFolder,
		[Out, MarshalAs(UnmanagedType.LPTStr)] StringBuilder szPathBuf, ref uint pcchPathBuf);

	/// <summary>
	/// The <c>MsiOpenDatabase</c> function opens a database file for data access. This function returns a handle that should be closed
	/// using MsiCloseHandle.
	/// </summary>
	/// <param name="szDatabasePath">Specifies the full path or relative path to the database file.</param>
	/// <param name="szPersist">
	/// <para>
	/// Receives the full path to the file or the persistence mode. You can use the szPersist parameter to direct the persistent output
	/// to a new file or to specify one of the following predefined persistence modes.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>MSIDBOPEN_CREATEDIRECT</term>
	/// <term>Create a new database, direct mode read/write.</term>
	/// </item>
	/// <item>
	/// <term>MSIDBOPEN_CREATE</term>
	/// <term>Create a new database, transact mode read/write.</term>
	/// </item>
	/// <item>
	/// <term>MSIDBOPEN_DIRECT</term>
	/// <term>Open a database direct read/write without transaction.</term>
	/// </item>
	/// <item>
	/// <term>MSIDBOPEN_READONLY</term>
	/// <term>Open a database read-only, no persistent changes.</term>
	/// </item>
	/// <item>
	/// <term>MSIDBOPEN_TRANSACT</term>
	/// <term>Open a database read/write in transaction mode.</term>
	/// </item>
	/// <item>
	/// <term>MSIDBOPEN_PATCHFILE</term>
	/// <term>Add this flag to indicate a patch file.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="phDatabase">Pointer to the location of the returned database handle.</param>
	/// <returns>The <c>MsiOpenDatabase</c> function returns the following values:</returns>
	/// <remarks>
	/// <para>
	/// To make and save changes to a database first open the database in transaction (MSIDBOPEN_TRANSACT), create (MSIDBOPEN_CREATE or
	/// MSIDBOPEN_CREATEDIRECT), or direct (MSIDBOPEN_DIRECT) mode. After making the changes, always call MsiDatabaseCommit before
	/// closing the database handle. <c>MsiDatabaseCommit</c> flushes all buffers.
	/// </para>
	/// <para>
	/// Always call MsiDatabaseCommit on a database that has been opened in direct mode (MSIDBOPEN_DIRECT or MSIDBOPEN_CREATEDIRECT)
	/// before closing the database's handle. Failure to do this may corrupt the database.
	/// </para>
	/// <para>Because <c>MsiOpenDatabase</c> initiates database access, it cannot be used with a running installation.</para>
	/// <para>
	/// Note that it is recommended to use variables of type PMSIHANDLE because the installer closes PMSIHANDLE objects as they go out
	/// of scope, whereas you must close MSIHANDLE objects by calling MsiCloseHandle. For more information see Use PMSIHANDLE instead of
	/// HANDLE section in the Windows Installer Best Practices.
	/// </para>
	/// <para>
	/// <c>Note</c> When a database is opened as the output of another database, the summary information stream of the output database
	/// is actually a read-only mirror of the original database, and, thus, cannot be changed. Additionally, it is not persisted with
	/// the database. To create or modify the summary information for the output database, it must be closed and reopened.
	/// </para>
	/// <para>If the function fails, you can obtain extended error information by using MsiGetLastErrorRecord.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/msiquery/nf-msiquery-msiopendatabasea UINT MsiOpenDatabaseA( LPCSTR
	// szDatabasePath, LPCSTR szPersist, MSIHANDLE *phDatabase );
	[DllImport(Lib_Msi, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("msiquery.h", MSDNShortId = "NF:msiquery.MsiOpenDatabaseA")]
	public static extern Win32Error MsiOpenDatabase([MarshalAs(UnmanagedType.LPTStr)] string szDatabasePath,
		[MarshalAs(UnmanagedType.LPTStr)] string szPersist, out PMSIHANDLE phDatabase);

	/// <summary>
	/// The <c>MsiOpenDatabase</c> function opens a database file for data access. This function returns a handle that should be closed
	/// using MsiCloseHandle.
	/// </summary>
	/// <param name="szDatabasePath">Specifies the full path or relative path to the database file.</param>
	/// <param name="szPersist">
	/// <para>
	/// Receives the full path to the file or the persistence mode. You can use the szPersist parameter to direct the persistent output
	/// to a new file or to specify one of the following predefined persistence modes.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>MSIDBOPEN_CREATEDIRECT</term>
	/// <term>Create a new database, direct mode read/write.</term>
	/// </item>
	/// <item>
	/// <term>MSIDBOPEN_CREATE</term>
	/// <term>Create a new database, transact mode read/write.</term>
	/// </item>
	/// <item>
	/// <term>MSIDBOPEN_DIRECT</term>
	/// <term>Open a database direct read/write without transaction.</term>
	/// </item>
	/// <item>
	/// <term>MSIDBOPEN_READONLY</term>
	/// <term>Open a database read-only, no persistent changes.</term>
	/// </item>
	/// <item>
	/// <term>MSIDBOPEN_TRANSACT</term>
	/// <term>Open a database read/write in transaction mode.</term>
	/// </item>
	/// <item>
	/// <term>MSIDBOPEN_PATCHFILE</term>
	/// <term>Add this flag to indicate a patch file.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="phDatabase">Pointer to the location of the returned database handle.</param>
	/// <returns>The <c>MsiOpenDatabase</c> function returns the following values:</returns>
	/// <remarks>
	/// <para>
	/// To make and save changes to a database first open the database in transaction (MSIDBOPEN_TRANSACT), create (MSIDBOPEN_CREATE or
	/// MSIDBOPEN_CREATEDIRECT), or direct (MSIDBOPEN_DIRECT) mode. After making the changes, always call MsiDatabaseCommit before
	/// closing the database handle. <c>MsiDatabaseCommit</c> flushes all buffers.
	/// </para>
	/// <para>
	/// Always call MsiDatabaseCommit on a database that has been opened in direct mode (MSIDBOPEN_DIRECT or MSIDBOPEN_CREATEDIRECT)
	/// before closing the database's handle. Failure to do this may corrupt the database.
	/// </para>
	/// <para>Because <c>MsiOpenDatabase</c> initiates database access, it cannot be used with a running installation.</para>
	/// <para>
	/// Note that it is recommended to use variables of type PMSIHANDLE because the installer closes PMSIHANDLE objects as they go out
	/// of scope, whereas you must close MSIHANDLE objects by calling MsiCloseHandle. For more information see Use PMSIHANDLE instead of
	/// HANDLE section in the Windows Installer Best Practices.
	/// </para>
	/// <para>
	/// <c>Note</c> When a database is opened as the output of another database, the summary information stream of the output database
	/// is actually a read-only mirror of the original database, and, thus, cannot be changed. Additionally, it is not persisted with
	/// the database. To create or modify the summary information for the output database, it must be closed and reopened.
	/// </para>
	/// <para>If the function fails, you can obtain extended error information by using MsiGetLastErrorRecord.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/msiquery/nf-msiquery-msiopendatabasea UINT MsiOpenDatabaseA( LPCSTR
	// szDatabasePath, LPCSTR szPersist, MSIHANDLE *phDatabase );
	[DllImport(Lib_Msi, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("msiquery.h", MSDNShortId = "NF:msiquery.MsiOpenDatabaseA")]
	public static extern Win32Error MsiOpenDatabase([MarshalAs(UnmanagedType.LPTStr)] string szDatabasePath,
		[In] IntPtr szPersist, out PMSIHANDLE phDatabase);

	/// <summary>The <c>MsiPreviewBillboard</c> function displays a billboard with the host control in the displayed dialog box.</summary>
	/// <param name="hPreview">Handle to the preview.</param>
	/// <param name="szControlName">Specifies the name of the host control.</param>
	/// <param name="szBillboard">Specifies the name of the billboard to display.</param>
	/// <returns>This function returns UINT.</returns>
	/// <remarks>Supplying a null billboard name in the <c>MsiPreviewBillboard</c> function removes any billboard displayed.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/msiquery/nf-msiquery-msipreviewbillboarda UINT MsiPreviewBillboardA( MSIHANDLE
	// hPreview, LPCSTR szControlName, LPCSTR szBillboard );
	[DllImport(Lib_Msi, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("msiquery.h", MSDNShortId = "NF:msiquery.MsiPreviewBillboardA")]
	public static extern Win32Error MsiPreviewBillboard(MSIHANDLE hPreview, [MarshalAs(UnmanagedType.LPTStr)] string szControlName,
		[Optional, MarshalAs(UnmanagedType.LPTStr)] string? szBillboard);

	/// <summary>The <c>MsiPreviewDialog</c> function displays a dialog box as modeless and inactive.</summary>
	/// <param name="hPreview">Handle to the preview.</param>
	/// <param name="szDialogName">Specifies the name of the dialog box to preview.</param>
	/// <returns>This function returns UINT.</returns>
	/// <remarks>Supplying a null name in the <c>MsiPreviewDialog</c> function removes any current dialog box.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/msiquery/nf-msiquery-msipreviewdialogw UINT MsiPreviewDialogW( MSIHANDLE
	// hPreview, LPCWSTR szDialogName );
	[DllImport(Lib_Msi, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("msiquery.h", MSDNShortId = "NF:msiquery.MsiPreviewDialogW")]
	public static extern Win32Error MsiPreviewDialog(MSIHANDLE hPreview, [MarshalAs(UnmanagedType.LPTStr)] string? szDialogName);

	/// <summary>The <c>MsiProcessMessage</c> function sends an error record to the installer for processing.</summary>
	/// <param name="hInstall">
	/// Handle to the installation provided to a DLL custom action or obtained through MsiOpenPackage, MsiOpenPackageEx, or MsiOpenProduct.
	/// </param>
	/// <param name="eMessageType">
	/// <para>
	/// The eMessage parameter must be a value specifying one of the following message types. To display a message box with push buttons
	/// or icons, use OR-operators to add INSTALLMESSAGE_ERROR, INSTALLMESSAGE_WARNING, or INSTALLMESSAGE_USER to the standard message
	/// box styles used by the MessageBox and MessageBoxEx functions. For more information, see the Remarks below.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>INSTALLMESSAGE_FATALEXIT</term>
	/// <term>Premature termination, possibly fatal out of memory.</term>
	/// </item>
	/// <item>
	/// <term>INSTALLMESSAGE_ERROR</term>
	/// <term>Formatted error message,[1] is message number in Error table.</term>
	/// </item>
	/// <item>
	/// <term>INSTALLMESSAGE_WARNING</term>
	/// <term>Formatted warning message,[1] is message number in Error table.</term>
	/// </item>
	/// <item>
	/// <term>INSTALLMESSAGE_USER</term>
	/// <term>User request message,[1] is message number in Error table.</term>
	/// </item>
	/// <item>
	/// <term>INSTALLMESSAGE_INFO</term>
	/// <term>Informative message for log,not to be displayed.</term>
	/// </item>
	/// <item>
	/// <term>INSTALLMESSAGE_FILESINUSE</term>
	/// <term>List of files currently in use that must be closed before being replaced.</term>
	/// </item>
	/// <item>
	/// <term>INSTALLMESSAGE_RESOLVESOURCE</term>
	/// <term>Request to determine a valid source location.</term>
	/// </item>
	/// <item>
	/// <term>INSTALLMESSAGE_RMFILESINUSE</term>
	/// <term>
	/// List of files currently in use that must be closed before being replaced. Available beginning with Windows Installer version
	/// 4.0. For more information about this message see Using Restart Manager with an External UI.
	/// </term>
	/// </item>
	/// <item>
	/// <term>INSTALLMESSAGE_OUTOFDISKSPACE</term>
	/// <term>Insufficient disk space message.</term>
	/// </item>
	/// <item>
	/// <term>INSTALLMESSAGE_ACTIONSTART</term>
	/// <term>Progress: start of action,[1] action name,[2] description,[3] template for ACTIONDATA messages.</term>
	/// </item>
	/// <item>
	/// <term>INSTALLMESSAGE_ACTIONDATA</term>
	/// <term>Action data. Record fields correspond to the template of ACTIONSTART message.</term>
	/// </item>
	/// <item>
	/// <term>INSTALLMESSAGE_PROGRESS</term>
	/// <term>Progress bar information. See the description of record fields below.</term>
	/// </item>
	/// <item>
	/// <term>INSTALLMESSAGE_COMMONDATA</term>
	/// <term>To enable the Cancel button set [1] to 2 and [2] to 1. To disable the Cancel button set [1] to 2 and [2] to 0</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="hRecord">Handle to a record containing message format and data.</param>
	/// <returns>This function returns int.</returns>
	/// <remarks>
	/// <para>
	/// The <c>MsiProcessMessage</c> function performs any enabled logging operations and defers execution. You can selectively enable
	/// logging for various message types.
	/// </para>
	/// <para>
	/// For INSTALLMESSAGE_FATALEXIT, INSTALLMESSAGE_ERROR, INSTALLMESSAGE_WARNING, and INSTALLMESSAGE_USER messages, if field 0 is not
	/// set field 1 must be set to the error code corresponding to the error message in the Error table. Then, the message is formatted
	/// using the template from the Error table before passing it to the user-interface handler for display.
	/// </para>
	/// <para>Record Fields for Progress Bar Messages</para>
	/// <para>
	/// The following describes the record fields when eMessageType is set to INSTALLMESSAGE_PROGRESS. Field 1 specifies the type of the
	/// progress message. The meaning of the other fields depend upon the value in this field. The possible values that can be set into
	/// Field 1 are as follows.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Field 1 value</term>
	/// <term>Field 1 description</term>
	/// </listheader>
	/// <item>
	/// <term>0</term>
	/// <term>Resets progress bar and sets the expected total number of ticks in the bar.</term>
	/// </item>
	/// <item>
	/// <term>1</term>
	/// <term>Provides information related to progress messages to be sent by the current action.</term>
	/// </item>
	/// <item>
	/// <term>2</term>
	/// <term>Increments the progress bar.</term>
	/// </item>
	/// <item>
	/// <term>3</term>
	/// <term>Enables an action (such as CustomAction) to add ticks to the expected total number of progress of the progress bar.</term>
	/// </item>
	/// </list>
	/// <para>The meaning of Field 2 depends upon the value in Field 1 as follows.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Field 1 value</term>
	/// <term>Field 2 description</term>
	/// </listheader>
	/// <item>
	/// <term>0</term>
	/// <term>Expected total number of ticks in the progress bar.</term>
	/// </item>
	/// <item>
	/// <term>1</term>
	/// <term>
	/// Number of ticks the progress bar moves for each ActionData message that is sent by the current action. This field is ignored if
	/// Field 3 is 0.
	/// </term>
	/// </item>
	/// <item>
	/// <term>2</term>
	/// <term>Number of ticks the progress bar has moved.</term>
	/// </item>
	/// <item>
	/// <term>3</term>
	/// <term>Number of ticks to add to total expected progress.</term>
	/// </item>
	/// </list>
	/// <para>The meaning of Field 3 depends upon the value in Field 1 as follows.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Field 1 value</term>
	/// <term>Field 3 value</term>
	/// <term>Field 3 description</term>
	/// </listheader>
	/// <item>
	/// <term>0</term>
	/// <term>0</term>
	/// <term>Forward progress bar (left to right)</term>
	/// </item>
	/// <item>
	/// <term/>
	/// <term>1</term>
	/// <term>Backward progress bar (right to left)</term>
	/// </item>
	/// <item>
	/// <term>1</term>
	/// <term>0</term>
	/// <term>The current action will send explicit ProgressReport messages.</term>
	/// </item>
	/// <item>
	/// <term/>
	/// <term>1</term>
	/// <term>
	/// Increment the progress bar by the number of ticks specified in Field 2 each time an ActionData message is sent by the current action.
	/// </term>
	/// </item>
	/// <item>
	/// <term>2</term>
	/// <term>Unused</term>
	/// <term/>
	/// </item>
	/// <item>
	/// <term>3</term>
	/// <term>Unused</term>
	/// <term/>
	/// </item>
	/// </list>
	/// <para>The meaning of Field 4 depends upon the value in Field 1 as follows.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Field 1 value</term>
	/// <term>Field 4 value</term>
	/// <term>Field 4 description</term>
	/// </listheader>
	/// <item>
	/// <term>0</term>
	/// <term>0</term>
	/// <term>Execution is in progress. In this case, the UI could calculate and display the time remaining.</term>
	/// </item>
	/// <item>
	/// <term/>
	/// <term>1</term>
	/// <term>
	/// Creating the execution script. In this case, the UI could display a message to please wait while the installer finishes
	/// preparing the installation.
	/// </term>
	/// </item>
	/// <item>
	/// <term>1</term>
	/// <term>Unused</term>
	/// <term/>
	/// </item>
	/// <item>
	/// <term>2</term>
	/// <term>Unused</term>
	/// <term/>
	/// </item>
	/// <item>
	/// <term>3</term>
	/// <term>Unused</term>
	/// <term/>
	/// </item>
	/// </list>
	/// <para>For more information and a code sample, see Adding Custom Actions to the ProgressBar.</para>
	/// <para>Display of Message Boxes</para>
	/// <para>
	/// To display a message box with push buttons or icons, use OR-operators to add INSTALLMESSAGE_ERROR, INSTALLMESSAGE_WARNING, or
	/// INSTALLMESSAGE_USER with the message box options used by MessageBox and MessageBoxEx. The available push button options are
	/// MB_OK, MB_OKCANCEL, MB_ABORTRETRYIGNORE, MB_YESNOCANCEL, MB_YESNO, and MB_RETRYCANCEL. The available default button options are
	/// MB_DEFBUTTON1, MB_DEFBUTTON2, and MB_DEFBUTTON3. The available icon options are MB_ICONERROR, MB_ICONQUESTION, MB_ICONWARNING,
	/// and MB_ICONINFORMATION. If no icon options is specified, Windows Installer chooses a default icon style based upon the message type.
	/// </para>
	/// <para>
	/// For example, the following call to <c>MsiProcessMessage</c> sends an INSTALLMESSAGE_ERROR message with the MB_ICONWARNING icon
	/// and the MB_ABORTRETRYCANCEL buttons.
	/// </para>
	/// <para>
	/// <code>PMSIHANDLE hInstall; PMSIHANDLE hRec; MsiProcessMessage(hInstall, INSTALLMESSAGE(INSTALLMESSAGE_ERROR|MB_ABORTRETRYIGNORE|MB_ICONWARNING), hRec);</code>
	/// </para>
	/// <para>
	/// If a custom action calls <c>MsiProcessMessage</c>, the custom action should be capable of handling a cancellation by the user
	/// and should return ERROR_INSTALL_USEREXIT.
	/// </para>
	/// <para>
	/// For more information on sending messages with <c>MsiProcessMessage</c>, see the Sending Messages to Windows Installer Using MsiProcessMessage.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/msiquery/nf-msiquery-msiprocessmessage int MsiProcessMessage( MSIHANDLE
	// hInstall, INSTALLMESSAGE eMessageType, MSIHANDLE hRecord );
	[DllImport(Lib_Msi, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("msiquery.h", MSDNShortId = "NF:msiquery.MsiProcessMessage")]
	public static extern int MsiProcessMessage(MSIHANDLE hInstall, INSTALLMESSAGE eMessageType, MSIHANDLE hRecord);

	/// <summary>The <c>MsiRecordClearData</c> function sets all fields in a record to null.</summary>
	/// <param name="hRecord">Handle to the record.</param>
	/// <returns>This function returns UINT.</returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/msiquery/nf-msiquery-msirecordcleardata UINT MsiRecordClearData( MSIHANDLE
	// hRecord );
	[DllImport(Lib_Msi, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("msiquery.h", MSDNShortId = "NF:msiquery.MsiRecordClearData")]
	public static extern Win32Error MsiRecordClearData(MSIHANDLE hRecord);

	/// <summary>
	/// The <c>MsiRecordDataSize</c> function returns the length of a record field. The count does not include the terminating null character.
	/// </summary>
	/// <param name="hRecord">Handle to the record.</param>
	/// <param name="iField">Specifies a field of the record.</param>
	/// <returns>
	/// <para>
	/// The <c>MsiRecordDataSize</c> function returns 0 if the field is null, nonexistent, or an internal object pointer. The function
	/// also returns 0 if the handle is not a valid record handle.
	/// </para>
	/// <para>If the data is in integer format, the function returns sizeof(int).</para>
	/// <para>If the data is in string format, the function returns the character count (not including the null character).</para>
	/// <para>If the data is in stream format, the function returns the byte count.</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/msiquery/nf-msiquery-msirecorddatasize UINT MsiRecordDataSize( MSIHANDLE
	// hRecord, UINT iField );
	[DllImport(Lib_Msi, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("msiquery.h", MSDNShortId = "NF:msiquery.MsiRecordDataSize")]
	public static extern uint MsiRecordDataSize(MSIHANDLE hRecord, uint iField);

	/// <summary>The <c>MsiRecordGetFieldCount</c> function returns the number of fields in a record.</summary>
	/// <param name="hRecord">Handle to a record.</param>
	/// <returns>If the function succeeds, the return value is the number of fields in the record.</returns>
	/// <remarks>
	/// The count returned by the <c>MsiRecordGetFieldCount</c> parameter does not include field 0. Read access to fields beyond this
	/// count returns null values. Write access fails.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/msiquery/nf-msiquery-msirecordgetfieldcount UINT MsiRecordGetFieldCount(
	// MSIHANDLE hRecord );
	[DllImport(Lib_Msi, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("msiquery.h", MSDNShortId = "NF:msiquery.MsiRecordGetFieldCount")]
	public static extern uint MsiRecordGetFieldCount(MSIHANDLE hRecord);

	/// <summary>The <c>MsiRecordGetInteger</c> function returns the integer value from a record field.</summary>
	/// <param name="hRecord">Handle to a record.</param>
	/// <param name="iField">Specifies the field of the record from which to obtain the value.</param>
	/// <returns>If the function succeeds, the return value is the integer value of the field.</returns>
	/// <remarks>
	/// The <c>MsiRecordGetInteger</c> function returns <c>MSI_NULL_INTEGER</c> if the field is null or if the field is a string that
	/// cannot be converted to an integer.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/msiquery/nf-msiquery-msirecordgetinteger int MsiRecordGetInteger( MSIHANDLE
	// hRecord, UINT iField );
	[DllImport(Lib_Msi, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("msiquery.h", MSDNShortId = "NF:msiquery.MsiRecordGetInteger")]
	public static extern int MsiRecordGetInteger(MSIHANDLE hRecord, uint iField);

	/// <summary>The <c>MsiRecordGetString</c> function returns the string value of a record field.</summary>
	/// <param name="hRecord">Handle to the record.</param>
	/// <param name="iField">Specifies the field requested.</param>
	/// <param name="szValueBuf">
	/// Pointer to the buffer that receives the null terminated string containing the value of the record field. Do not attempt to
	/// determine the size of the buffer by passing in a null (value=0) for szValueBuf. You can get the size of the buffer by passing in
	/// an empty string (for example ""). The function then returns <c>ERROR_MORE_DATA</c> and pcchValueBuf contains the required buffer
	/// size in TCHARs, not including the terminating null character. On return of <c>ERROR_SUCCESS</c>, pcchValueBuf contains the
	/// number of <c>TCHARs</c> written to the buffer, not including the terminating null character.
	/// </param>
	/// <param name="pcchValueBuf">
	/// Pointer to the variable that specifies the size, in <c>TCHAR</c> s, of the buffer pointed to by the variable szValueBuf. When
	/// the function returns <c>ERROR_SUCCESS</c>, this variable contains the size of the data copied to szValueBuf, not including the
	/// terminating null character. If szValueBuf is not large enough, the function returns <c>ERROR_MORE_DATA</c> and stores the
	/// required size, not including the terminating null character, in the variable pointed to by pcchValueBuf.
	/// </param>
	/// <returns>The <c>MsiRecordGetString</c> function returns one of the following values:</returns>
	/// <remarks>
	/// If <c>ERROR_MORE_DATA</c> is returned, the parameter which is a pointer gives the size of the buffer required to hold the
	/// string. If <c>ERROR_SUCCESS</c> is returned, it gives the number of characters written to the string buffer. To get the size of
	/// the buffer, pass in the address of a 1 character buffer as szValueBuf and specify the size of the buffer with pcchValueBuf as 0.
	/// This ensures that no string value returned by the function fits into the buffer. Do not attempt to determine the size of the
	/// buffer by passing in a Null (value=0).
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/msiquery/nf-msiquery-msirecordgetstringa UINT MsiRecordGetStringA( MSIHANDLE
	// hRecord, UINT iField, PSTR szValueBuf, LPDWORD pcchValueBuf );
	[DllImport(Lib_Msi, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("msiquery.h", MSDNShortId = "NF:msiquery.MsiRecordGetStringA")]
	public static extern Win32Error MsiRecordGetString(MSIHANDLE hRecord, uint iField, [Out, MarshalAs(UnmanagedType.LPTStr)] StringBuilder szValueBuf, ref uint pcchValueBuf);

	/// <summary>The <c>MsiRecordIsNull</c> function reports a null record field.</summary>
	/// <param name="hRecord">Handle to a record.</param>
	/// <param name="iField">Specifies the field to check.</param>
	/// <returns>This function returns BOOL.</returns>
	/// <remarks>The iField parameter is based on 1 (one).</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/msiquery/nf-msiquery-msirecordisnull BOOL MsiRecordIsNull( MSIHANDLE hRecord,
	// UINT iField );
	[DllImport(Lib_Msi, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("msiquery.h", MSDNShortId = "NF:msiquery.MsiRecordIsNull")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool MsiRecordIsNull(MSIHANDLE hRecord, uint iField);

	/// <summary>The <c>MsiRecordReadStream</c> function reads bytes from a record stream field into a buffer.</summary>
	/// <param name="hRecord">Handle to the record.</param>
	/// <param name="iField">Specifies the field of the record.</param>
	/// <param name="szDataBuf">
	/// A buffer to receive the stream field. You should ensure the destination buffer is the same size or larger than the source
	/// buffer. See the Remarks section.
	/// </param>
	/// <param name="pcbDataBuf">
	/// Specifies the in and out buffer count. On input, this is the full size of the buffer. On output, this is the number of bytes
	/// that were actually written to the buffer. See the Remarks section.
	/// </param>
	/// <returns>This function returns UINT.</returns>
	/// <remarks>
	/// <para>
	/// To read a stream, set pcbDataBuf to the number of bytes that are to be transferred from stream to buffer each time the function
	/// is called. On return, the <c>MsiRecordReadStream</c> resets pcbDataBuf to the number of bytes that were actually transferred. If
	/// the buffer is smaller than the stream, the stream is repositioned when the buffer becomes full such that the next data in the
	/// stream is transferred by the next call to the function. When no more bytes are available, <c>MsiRecordReadStream</c> returns ERROR_SUCCESS.
	/// </para>
	/// <para>If you pass 0 for szDataBuf then pcbDataBuf is reset to the number of bytes in the stream remaining to be read.</para>
	/// <para>
	/// The following code sample reads from a stream that is in field 1 of a record specified by hRecord and reads the entire stream 8
	/// bytes at a time.
	/// </para>
	/// <para>
	/// <code>char szBuffer[8]; PMSIHANDLE hRecord; DWORD cbBuf = sizeof(szBuffer); do { if (MsiRecordReadStream(hRecord, 1, szBuffer, &amp;cbBuf) != ERROR_SUCCESS) break; /* error */ } while (cbBuf == 8); //continue reading the stream while you receive a full buffer //cbBuf will be less once you reach the end of the stream and cannot fill your //buffer with stream data</code>
	/// </para>
	/// <para>See also OLE Limitations on Streams.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/msiquery/nf-msiquery-msirecordreadstream UINT MsiRecordReadStream( MSIHANDLE
	// hRecord, UINT iField, char *szDataBuf, LPDWORD pcbDataBuf );
	[DllImport(Lib_Msi, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("msiquery.h", MSDNShortId = "NF:msiquery.MsiRecordReadStream")]
	public static extern Win32Error MsiRecordReadStream(MSIHANDLE hRecord, uint iField, [Out] IntPtr szDataBuf, ref uint pcbDataBuf);

	/// <summary>The <c>MsiRecordSetInteger</c> function sets a record field to an integer field.</summary>
	/// <param name="hRecord">Handle to the record.</param>
	/// <param name="iField">Specifies the field of the record to set.</param>
	/// <param name="iValue">Specifies the value to which to set the field.</param>
	/// <returns>This function returns UINT.</returns>
	/// <remarks>
	/// <para>
	/// In the <c>MsiRecordSetInteger</c> function, attempting to store a value in a nonexistent field causes an error. Note that the
	/// following code returns <c>ERROR_INVALID_PARAMETER</c>.
	/// </para>
	/// <para>
	/// <code>MSIHANDLE hRecord; UINT lReturn; //create an msirecord with no fields hRecord = MsiCreateRecord(0); //attempting to set the first field's value gives you ERROR_INVALID_PARAMETER lReturn = MsiRecordSetInteger(hRecord, 1, 0);</code>
	/// </para>
	/// <para>To set a record integer field to <c>NULL_INTEGER</c>, set iValue to <c>MSI_NULL_INTEGER</c>.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/msiquery/nf-msiquery-msirecordsetinteger UINT MsiRecordSetInteger( MSIHANDLE
	// hRecord, UINT iField, int iValue );
	[DllImport(Lib_Msi, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("msiquery.h", MSDNShortId = "NF:msiquery.MsiRecordSetInteger")]
	public static extern Win32Error MsiRecordSetInteger(MSIHANDLE hRecord, uint iField, int iValue);

	/// <summary>
	/// The <c>MsiRecordSetStream</c> function sets a record stream field from a file. Stream data cannot be inserted into temporary fields.
	/// </summary>
	/// <param name="hRecord">Handle to the record.</param>
	/// <param name="iField">Specifies the field of the record to set.</param>
	/// <param name="szFilePath">Specifies the path to the file containing the stream.</param>
	/// <returns>The <c>MsiRecordSetStream</c> function returns the following values:</returns>
	/// <remarks>
	/// <para>
	/// The contents of the file specified in the <c>MsiRecordSetStream</c> function is read into a stream object. The stream persists
	/// if the record is inserted into the database and the database is committed.
	/// </para>
	/// <para>
	/// To reset the stream to its beginning you must pass in a Null pointer for szFilePath. Do not pass a pointer to an empty string,
	/// "", to reset the stream.
	/// </para>
	/// <para>See also OLE Limitations on Streams.</para>
	/// <para>If the function fails, you can obtain extended error information by using MsiGetLastErrorRecord.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/msiquery/nf-msiquery-msirecordsetstreama UINT MsiRecordSetStreamA( MSIHANDLE
	// hRecord, UINT iField, LPCSTR szFilePath );
	[DllImport(Lib_Msi, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("msiquery.h", MSDNShortId = "NF:msiquery.MsiRecordSetStreamA")]
	public static extern Win32Error MsiRecordSetStream(MSIHANDLE hRecord, uint iField, [MarshalAs(UnmanagedType.LPTStr)] string? szFilePath);

	/// <summary>The <c>MsiRecordSetString</c> function copies a string into the designated field.</summary>
	/// <param name="hRecord">Handle to the record.</param>
	/// <param name="iField">Specifies the field of the record to set.</param>
	/// <param name="szValue">Specifies the string value of the field.</param>
	/// <returns>This function returns UINT.</returns>
	/// <remarks>
	/// <para>
	/// In the <c>MsiRecordSetString</c> function, a null string pointer and an empty string both set the field to null. Attempting to
	/// store a value in a nonexistent field causes an error.
	/// </para>
	/// <para>To set a record string field to null, set szValue to either a null string or an empty string.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/msiquery/nf-msiquery-msirecordsetstringa UINT MsiRecordSetStringA( MSIHANDLE
	// hRecord, UINT iField, LPCSTR szValue );
	[DllImport(Lib_Msi, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("msiquery.h", MSDNShortId = "NF:msiquery.MsiRecordSetStringA")]
	public static extern Win32Error MsiRecordSetString(MSIHANDLE hRecord, uint iField, [MarshalAs(UnmanagedType.LPTStr)] string? szValue);

	/// <summary>The <c>MsiSequence</c> function executes another action sequence, as described in the specified table.</summary>
	/// <param name="hInstall">
	/// Handle to the installation provided to a DLL custom action or obtained through MsiOpenPackage, MsiOpenPackageEx, or MsiOpenProduct.
	/// </param>
	/// <param name="szTable">Specifies the name of the table containing the action sequence.</param>
	/// <param name="iSequenceMode">This parameter is currently unimplemented. It is reserved for future use and must be 0.</param>
	/// <returns>This function returns UINT.</returns>
	/// <remarks>
	/// <para>
	/// The <c>MsiSequence</c> function queries the specified table, ordering the actions by the numbers in the Sequence column. For
	/// each row retrieved, an action is executed, provided that any supplied condition expression does not evaluate to FALSE.
	/// </para>
	/// <para>
	/// An action sequence containing any actions that update the system, such as the InstallFiles and WriteRegistryValues actions,
	/// cannot be run by calling <c>MsiSequence</c>. The exception to this rule is if <c>MsiSequence</c> is called from a custom action
	/// that is scheduled in the InstallExecuteSequence table between the InstallInitialize and InstallFinalize actions. Actions that do
	/// not update the system, such as AppSearch or CostInitialize, can be called.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/msiquery/nf-msiquery-msisequencew UINT MsiSequenceW( MSIHANDLE hInstall,
	// LPCWSTR szTable, INT iSequenceMode );
	[DllImport(Lib_Msi, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("msiquery.h", MSDNShortId = "NF:msiquery.MsiSequenceW")]
	public static extern Win32Error MsiSequence(MSIHANDLE hInstall, [MarshalAs(UnmanagedType.LPTStr)] string szTable, int iSequenceMode = 0);

	/// <summary>The <c>MsiSetComponentState</c> function sets a component to the requested state.</summary>
	/// <param name="hInstall">
	/// Handle to the installation provided to a DLL custom action or obtained through MsiOpenPackage, MsiOpenPackageEx, or MsiOpenProduct.
	/// </param>
	/// <param name="szComponent">Specifies the name of the component.</param>
	/// <param name="iState">
	/// <para>Specifies the state to set. This parameter can be one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>INSTALLSTATE_ABSENT</term>
	/// <term>The component was uninstalled.</term>
	/// </item>
	/// <item>
	/// <term>INSTALLSTATE_LOCAL</term>
	/// <term>The component was installed on the local drive.</term>
	/// </item>
	/// <item>
	/// <term>INSTALLSTATE_SOURCE</term>
	/// <term>The component will run from source, CD, or network.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <returns>The <c>MsiSetComponentState</c> function returns the following values:</returns>
	/// <remarks>
	/// <para>The <c>MsiSetComponentState</c> function requests a change in the Action state of a record in the Component table.</para>
	/// <para>For more information, see Calling Database Functions From Programs.</para>
	/// <para>If the function fails, you can obtain extended error information by using MsiGetLastErrorRecord.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/msiquery/nf-msiquery-msisetcomponentstatea UINT MsiSetComponentStateA(
	// MSIHANDLE hInstall, LPCSTR szComponent, INSTALLSTATE iState );
	[DllImport(Lib_Msi, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("msiquery.h", MSDNShortId = "NF:msiquery.MsiSetComponentStateA")]
	public static extern Win32Error MsiSetComponentState(MSIHANDLE hInstall, [MarshalAs(UnmanagedType.LPTStr)] string szComponent, INSTALLSTATE iState);

	/// <summary>
	/// The <c>MsiSetFeatureAttributes</c> function can modify the default attributes of a feature at runtime. Note that the default
	/// attributes of features are authored in the Attributes column of the Feature table.
	/// </summary>
	/// <param name="hInstall">
	/// Handle to the installation provided to a DLL custom action or obtained through MsiOpenPackage, MsiOpenPackageEx, or MsiOpenProduct.
	/// </param>
	/// <param name="szFeature">Specifies the feature name within the product.</param>
	/// <param name="dwAttributes">
	/// <para>Feature attributes specified at run time as a set of bit flags:</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Constant</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>INSTALLFEATUREATTRIBUTE_FAVORLOCAL 1</term>
	/// <term>
	/// Modifies default feature attributes to msidbFeatureAttributesFavorLocal at run time. See Attributes column of the Feature table
	/// for a description.
	/// </term>
	/// </item>
	/// <item>
	/// <term>INSTALLFEATUREATTRIBUTE_FAVORSOURCE 2</term>
	/// <term>
	/// Modifies default feature attributes to msidbFeatureAttributesFavorSource at run time. See Attributes column of the Feature table
	/// for a description.
	/// </term>
	/// </item>
	/// <item>
	/// <term>INSTALLFEATUREATTRIBUTE_FOLLOWPARENT 4</term>
	/// <term>
	/// Modifies default feature attributes to msidbFeatureAttributesFollowParent at run time. Note that this is not a valid attribute
	/// to be set for top-level features. See Attributes column of the Feature table for a description.
	/// </term>
	/// </item>
	/// <item>
	/// <term>INSTALLFEATUREATTRIBUTE_FAVORADVERTISE 8</term>
	/// <term>
	/// Modifies default feature attributes to msidbFeatureAttributesFavorAdvertise at run time. See Attributes column of the Feature
	/// table for a description.
	/// </term>
	/// </item>
	/// <item>
	/// <term>INSTALLFEATUREATTRIBUTE_DISALLOWADVERTISE 16</term>
	/// <term>
	/// Modifies default feature attributes to msidbFeatureAttributesDisallowAdvertise at run time. See Attributes column of the Feature
	/// table for a description.
	/// </term>
	/// </item>
	/// <item>
	/// <term>INSTALLFEATUREATTRIBUTE_NOUNSUPPORTEDADVERTISE 32</term>
	/// <term>
	/// Modifies default feature attributes to msidbFeatureAttributesNoUnsupportedAdvertise at run time. See Attributes column of the
	/// Feature table for a description.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <returns>This function returns UINT.</returns>
	/// <remarks>
	/// <para>
	/// <c>MsiSetFeatureAttributes</c> must be called after CostInitialize action and before CostFinalize action. The function returns
	/// ERROR_FUNCTION_FAILED if called at any other time.
	/// </para>
	/// <para>
	/// The INSTALLFEATUREATTRIBUTE_FAVORLOCAL, INSTALLFEATUREATTRIBUTE_FAVORSOURCE, and INSTALLFEATUREATTRIBUTE_FOLLOWPARENT flags are
	/// mutually exclusive. Only one of these bits can be set for any feature. If more than one of these flags is set, the behavior of
	/// that feature is undefined.
	/// </para>
	/// <para>See Calling Database Functions From Programs.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/msiquery/nf-msiquery-msisetfeatureattributesa UINT MsiSetFeatureAttributesA(
	// MSIHANDLE hInstall, LPCSTR szFeature, DWORD dwAttributes );
	[DllImport(Lib_Msi, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("msiquery.h", MSDNShortId = "NF:msiquery.MsiSetFeatureAttributesA")]
	public static extern Win32Error MsiSetFeatureAttributes(MSIHANDLE hInstall, [MarshalAs(UnmanagedType.LPTStr)] string szFeature, INSTALLFEATUREATTRIBUTE dwAttributes);

	/// <summary>The <c>MsiSetFeatureState</c> function sets a feature to a specified state.</summary>
	/// <param name="hInstall">
	/// Handle to the installation provided to a DLL custom action or obtained through MsiOpenPackage, MsiOpenPackageEx, or MsiOpenProduct.
	/// </param>
	/// <param name="szFeature">Specifies the name of the feature.</param>
	/// <param name="iState">
	/// <para>Specifies the state to set. This parameter can be one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>INSTALLSTATE_ABSENT</term>
	/// <term>The feature is not installed.</term>
	/// </item>
	/// <item>
	/// <term>INSTALLSTATE_LOCAL</term>
	/// <term>The feature is installed on the local drive.</term>
	/// </item>
	/// <item>
	/// <term>INSTALLSTATE_SOURCE</term>
	/// <term>The feature is run from the source, CD, or network.</term>
	/// </item>
	/// <item>
	/// <term>INSTALLSTATE_ADVERTISED</term>
	/// <term>The feature is advertised.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <returns>The <c>MsiSetFeatureState</c> function returns the following values:</returns>
	/// <remarks>
	/// <para>
	/// The <c>MsiSetFeatureState</c> function requests a change in the select state of a feature in the Feature table and its children.
	/// In turn, the action state of all the components linked to the changed feature records are also updated appropriately, based on
	/// the new feature select state.
	/// </para>
	/// <para>The MsiSetInstallLevel function must be called before calling <c>MsiSetFeatureState</c>.</para>
	/// <para>
	/// When <c>MsiSetFeatureState</c> is called, the installer attempts to set the action state of each component tied to the specified
	/// feature to the specified state. However, there are common situations when the request cannot be fully implemented. For example,
	/// if a feature is tied to two components, component A and component B, through the FeatureComponents table, and component A has
	/// the <c>msidbComponentAttributesLocalOnly</c> attribute and component B has the <c>msidbComponentAttributesSourceOnly</c>
	/// attribute. In this case, if <c>MsiSetFeatureState</c> is called with a requested state of either INSTALLSTATE_LOCAL or
	/// INSTALLSTATE_SOURCE, the request cannot be fully implemented for both components. In this case, both components are turned ON,
	/// with component A set to Local and component B set to Source.
	/// </para>
	/// <para>
	/// If more than one feature is linked to a single component (a common scenario), the final action state of that component is
	/// determined as follows:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>If at least one feature requires the component to be installed locally, the feature is installed with a state of local.</term>
	/// </item>
	/// <item>
	/// <term>If at least one feature requires the component to be run from the source, the feature is installed with a state of source.</term>
	/// </item>
	/// <item>
	/// <term>If at least one feature requires the removal of the component, the action state is absent.</term>
	/// </item>
	/// </list>
	/// <para>See Calling Database Functions from Programs.</para>
	/// <para>If the function fails, you can obtain extended error information by using MsiGetLastErrorRecord.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/msiquery/nf-msiquery-msisetfeaturestatea UINT MsiSetFeatureStateA( MSIHANDLE
	// hInstall, LPCSTR szFeature, INSTALLSTATE iState );
	[DllImport(Lib_Msi, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("msiquery.h", MSDNShortId = "NF:msiquery.MsiSetFeatureStateA")]
	public static extern Win32Error MsiSetFeatureState(MSIHANDLE hInstall, [MarshalAs(UnmanagedType.LPTStr)] string szFeature, INSTALLSTATE iState);

	/// <summary>The <c>MsiSetInstallLevel</c> function sets the installation level for a full product installation.</summary>
	/// <param name="hInstall">
	/// Handle to the installation that is provided to a DLL custom action or obtained by using MsiOpenPackage, MsiOpenPackageEx, or MsiOpenProduct.
	/// </param>
	/// <param name="iInstallLevel">The installation level.</param>
	/// <returns>The <c>MsiSetInstallLevel</c> function returns one of the following values:</returns>
	/// <remarks>
	/// <para>The <c>MsiSetInstallLevel</c> function sets the following:</para>
	/// <list type="bullet">
	/// <item>
	/// <term>The installation level for the current installation to a specified value.</term>
	/// </item>
	/// <item>
	/// <term>The Select and Installed states for all features in the Feature table.</term>
	/// </item>
	/// <item>
	/// <term>The Action state of each component in the Component table, based on the new level.</term>
	/// </item>
	/// </list>
	/// <para>
	/// For any installation, there is a defined install level, which is an integral value from 1 to 32,767. The initial value is
	/// determined by the INSTALLLEVEL property, which is set in the Property Table.
	/// </para>
	/// <para>
	/// If 0 (zero) or a negative number is passed in the iInstallLevel parameter, the current installation level does not change, but
	/// all features are still updated based on the current installation level. For more information, see Calling Database Functions
	/// From Programs.
	/// </para>
	/// <para>If the function fails, you can obtain extended error information by using MsiGetLastErrorRecord.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/msiquery/nf-msiquery-msisetinstalllevel UINT MsiSetInstallLevel( MSIHANDLE
	// hInstall, int iInstallLevel );
	[DllImport(Lib_Msi, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("msiquery.h", MSDNShortId = "NF:msiquery.MsiSetInstallLevel")]
	public static extern Win32Error MsiSetInstallLevel(MSIHANDLE hInstall, int iInstallLevel);

	/// <summary>The <c>MsiSetMode</c> function sets an internal engine Boolean state.</summary>
	/// <param name="hInstall">
	/// Handle to the installation provided to a DLL custom action or obtained through MsiOpenPackage, MsiOpenPackageEx, or MsiOpenProduct.
	/// </param>
	/// <param name="eRunMode">
	/// <para>
	/// Specifies the run mode. This parameter must be one of the following values. While there are many values for this parameter, as
	/// described in MsiGetMode, only one of the following values can be set.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>MSIRUNMODE_REBOOTATEND</term>
	/// <term>A reboot is necessary after a successful installation.</term>
	/// </item>
	/// <item>
	/// <term>MSIRUNMODE_REBOOTNOW</term>
	/// <term>A reboot is necessary to continue installation.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="fState">Specifies the state to set to <c>TRUE</c> or <c>FALSE</c>.</param>
	/// <returns>This function returns UINT.</returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/msiquery/nf-msiquery-msisetmode UINT MsiSetMode( MSIHANDLE hInstall,
	// MSIRUNMODE eRunMode, BOOL fState );
	[DllImport(Lib_Msi, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("msiquery.h", MSDNShortId = "NF:msiquery.MsiSetMode")]
	public static extern Win32Error MsiSetMode(MSIHANDLE hInstall, MSIRUNMODE eRunMode, [MarshalAs(UnmanagedType.Bool)] bool fState);

	/// <summary>The <c>MsiSetProperty</c> function sets the value for an installation property.</summary>
	/// <param name="hInstall">
	/// Handle to the installation provided to a DLL custom action or obtained through MsiOpenPackage, MsiOpenPackageEx, or MsiOpenProduct.
	/// </param>
	/// <param name="szName">Specifies the name of the property.</param>
	/// <param name="szValue">Specifies the value of the property.</param>
	/// <returns>This function returns UINT.</returns>
	/// <remarks>
	/// If the property is not defined, it is created by the <c>MsiSetProperty</c> function. If the value is null or an empty string,
	/// the property is removed.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/msiquery/nf-msiquery-msisetpropertya UINT MsiSetPropertyA( MSIHANDLE hInstall,
	// LPCSTR szName, LPCSTR szValue );
	[DllImport(Lib_Msi, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("msiquery.h", MSDNShortId = "NF:msiquery.MsiSetPropertyA")]
	public static extern Win32Error MsiSetProperty(MSIHANDLE hInstall, [MarshalAs(UnmanagedType.LPTStr)] string szName,
		[Optional, MarshalAs(UnmanagedType.LPTStr)] string? szValue);

	/// <summary>The <c>MsiSetTargetPath</c> function sets the full target path for a folder in the Directory table.</summary>
	/// <param name="hInstall">
	/// Handle to the installation provided to a DLL custom action or obtained through MsiOpenPackage, MsiOpenPackageEx, or MsiOpenProduct.
	/// </param>
	/// <param name="szFolder">Specifies the folder identifier. This is a primary key in the Directory table.</param>
	/// <param name="szFolderPath">Specifies the full path for the folder, ending in a directory separator.</param>
	/// <returns>The <c>MsiSetTargetPath</c> function returns the following values:</returns>
	/// <remarks>
	/// <para>
	/// The <c>MsiSetTargetPath</c> function changes the path specification for the target directory named in the in-memory Directory
	/// table. Also, the path specifications of all other path objects in the table that are either subordinate or equivalent to the
	/// changed path are updated to reflect the change. The properties for each affected path are also updated.
	/// </para>
	/// <para><c>MsiSetTargetPath</c> fails if the selected directory is read only.</para>
	/// <para>
	/// If an error occurs in this function, all updated paths and properties revert to their previous values. Therefore, it is safe to
	/// treat errors returned by this function as nonfatal.
	/// </para>
	/// <para>
	/// Do not attempt to configure the target path if the components using those paths are already installed for the current user or
	/// for a different user. Check the ProductState property before calling <c>MsiSetTargetPath</c> to determine if the product
	/// containing this component is installed.
	/// </para>
	/// <para>See Calling Database Functions From Programs.</para>
	/// <para>If the function fails, you can obtain extended error information by using MsiGetLastErrorRecord.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/msiquery/nf-msiquery-msisettargetpatha UINT MsiSetTargetPathA( MSIHANDLE
	// hInstall, LPCSTR szFolder, LPCSTR szFolderPath );
	[DllImport(Lib_Msi, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("msiquery.h", MSDNShortId = "NF:msiquery.MsiSetTargetPathA")]
	public static extern Win32Error MsiSetTargetPath(MSIHANDLE hInstall, [MarshalAs(UnmanagedType.LPTStr)] string szFolder,
		[MarshalAs(UnmanagedType.LPTStr)] string szFolderPath);

	/// <summary>
	/// <para>The <c>MsiSummaryInfoGetProperty</c> function gets a single property from the summary information stream.</para>
	/// <para>
	/// <c>Note</c> The meaning of the property value depends on whether the summary information stream is for an installation database
	/// (.msi file), transform (.mst file) or patch (.msp file). See Summary Property Descriptions and Summary Information Stream
	/// Property Set for more information about summary information properties.
	/// </para>
	/// </summary>
	/// <param name="hSummaryInfo">Handle to summary information.</param>
	/// <param name="uiProperty">
	/// Specifies the property ID of the summary property. This parameter can be a property ID listed in the Summary Information Stream
	/// Property Set. This function does not return values for PID_DICTIONARY OR PID_THUMBNAIL property.
	/// </param>
	/// <param name="puiDataType">
	/// Receives the returned property type. This parameter can be a type listed in the Summary Information Stream Property Set.
	/// </param>
	/// <param name="piValue">Receives the returned integer property data.</param>
	/// <param name="pftValue">Pointer to a file value.</param>
	/// <param name="szValueBuf">
	/// Pointer to the buffer that receives the null terminated summary information property value. Do not attempt to determine the size
	/// of the buffer by passing in a null (value=0) for szValueBuf. You can get the size of the buffer by passing in an empty string
	/// (for example ""). The function then returns ERROR_MORE_DATA and pcchValueBuf contains the required buffer size in <c>TCHARs</c>,
	/// not including the terminating null character. On return of ERROR_SUCCESS, pcchValueBuf contains the number of <c>TCHARs</c>
	/// written to the buffer, not including the terminating null character. This parameter is an empty string if there are no errors.
	/// </param>
	/// <param name="pcchValueBuf">
	/// Pointer to the variable that specifies the size, in <c>TCHARs</c>, of the buffer pointed to by the variable szValueBuf. When the
	/// function returns ERROR_SUCCESS, this variable contains the size of the data copied to szValueBuf, not including the terminating
	/// null character. If szValueBuf is not large enough, the function returns ERROR_MORE_DATA and stores the required size, not
	/// including the terminating null character, in the variable pointed to by pcchValueBuf.
	/// </param>
	/// <returns>The <c>MsiSummaryInfoGetProperty</c> function returns one of the following values:</returns>
	/// <remarks>
	/// <para>
	/// If ERROR_MORE_DATA is returned, the parameter which is a pointer gives the size of the buffer required to hold the string. If
	/// ERROR_SUCCESS is returned, it gives the number of characters written to the string buffer. Therefore you can get the size of the
	/// buffer by passing in an empty string (for example "") for the parameter that specifies the buffer. Do not attempt to determine
	/// the size of the buffer by passing in a Null (value=0).
	/// </para>
	/// <para>
	/// Windows Installer functions that return data in a user provided memory location should not be called with null as the value for
	/// the pointer. These functions return a string or return data as integer pointers, but return inconsistent values when passing
	/// null as the value for the output argument. For more information, see Passing Null as the Argument of Windows Installer Functions.
	/// </para>
	/// <para>
	/// The property information returned by the <c>MsiSummaryInfoGetProperty</c> function is received by the piValue, pftValue, or
	/// szValueBuf parameter depending upon the type of property value that has been specified in the puiDataType parameter.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/msiquery/nf-msiquery-msisummaryinfogetpropertya UINT
	// MsiSummaryInfoGetPropertyA( MSIHANDLE hSummaryInfo, UINT uiProperty, PUINT puiDataType, LPINT piValue, FILETIME *pftValue, PSTR
	// szValueBuf, LPDWORD pcchValueBuf );
	[DllImport(Lib_Msi, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("msiquery.h", MSDNShortId = "NF:msiquery.MsiSummaryInfoGetPropertyA")]
	public static extern Win32Error MsiSummaryInfoGetProperty(MSIHANDLE hSummaryInfo, uint uiProperty, out uint puiDataType, out int piValue,
		out FILETIME pftValue, [Out, Optional, MarshalAs(UnmanagedType.LPTStr)] StringBuilder szValueBuf, ref uint pcchValueBuf);

	/// <summary>
	/// The <c>MsiSummaryInfoGetPropertyCount</c> function returns the number of existing properties in the summary information stream.
	/// </summary>
	/// <param name="hSummaryInfo">Handle to summary information.</param>
	/// <param name="puiPropertyCount">Location to receive the total property count.</param>
	/// <returns>This function returns UINT.</returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/msiquery/nf-msiquery-msisummaryinfogetpropertycount UINT
	// MsiSummaryInfoGetPropertyCount( MSIHANDLE hSummaryInfo, PUINT puiPropertyCount );
	[DllImport(Lib_Msi, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("msiquery.h", MSDNShortId = "NF:msiquery.MsiSummaryInfoGetPropertyCount")]
	public static extern Win32Error MsiSummaryInfoGetPropertyCount(MSIHANDLE hSummaryInfo, out uint puiPropertyCount);

	/// <summary>The <c>MsiSummaryInfoPersist</c> function writes changed summary information back to the summary information stream.</summary>
	/// <param name="hSummaryInfo">Handle to summary information.</param>
	/// <returns>This function returns UINT.</returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/msiquery/nf-msiquery-msisummaryinfopersist UINT MsiSummaryInfoPersist(
	// MSIHANDLE hSummaryInfo );
	[DllImport(Lib_Msi, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("msiquery.h", MSDNShortId = "NF:msiquery.MsiSummaryInfoPersist")]
	public static extern Win32Error MsiSummaryInfoPersist(MSIHANDLE hSummaryInfo);

	/// <summary>
	/// <para>The <c>MsiSummaryInfoSetProperty</c> function sets a single summary information property.</para>
	/// <para>
	/// <c>Note</c> The meaning of the property value depends on whether the summary information stream is for an installation database
	/// (.msi file), transform (.mst file) or patch (.msp file). See Summary Property Descriptions and Summary Information Stream
	/// Property Set for more information about summary information properties.
	/// </para>
	/// </summary>
	/// <param name="hSummaryInfo">Handle to summary information.</param>
	/// <param name="uiProperty">
	/// Specifies the property ID of the summary property being set. This parameter can be a property ID listed in the Summary
	/// Information Stream Property Set. This function does not set values for PID_DICTIONARY OR PID_THUMBNAIL property.
	/// </param>
	/// <param name="uiDataType">
	/// Specifies the type of property to set. This parameter can be a type listed in the Summary Information Stream Property Set.
	/// </param>
	/// <param name="iValue">Specifies the integer value.</param>
	/// <param name="pftValue">Specifies the file-time value.</param>
	/// <param name="szValue">Specifies the text value.</param>
	/// <returns>The <c>MsiSummaryInfoSetProperty</c> function returns the following values:</returns>
	/// <remarks/>
	// https://docs.microsoft.com/en-us/windows/win32/api/msiquery/nf-msiquery-msisummaryinfosetpropertya UINT
	// MsiSummaryInfoSetPropertyA( MSIHANDLE hSummaryInfo, UINT uiProperty, UINT uiDataType, INT iValue, FILETIME *pftValue, LPCSTR
	// szValue );
	[DllImport(Lib_Msi, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("msiquery.h", MSDNShortId = "NF:msiquery.MsiSummaryInfoSetPropertyA")]
	public static extern Win32Error MsiSummaryInfoSetProperty(MSIHANDLE hSummaryInfo, uint uiProperty, uint uiDataType, [Optional] int iValue,
		in FILETIME pftValue, [Optional, MarshalAs(UnmanagedType.LPTStr)] string? szValue);

	/// <summary>
	/// <para>The <c>MsiSummaryInfoSetProperty</c> function sets a single summary information property.</para>
	/// <para>
	/// <c>Note</c> The meaning of the property value depends on whether the summary information stream is for an installation database
	/// (.msi file), transform (.mst file) or patch (.msp file). See Summary Property Descriptions and Summary Information Stream
	/// Property Set for more information about summary information properties.
	/// </para>
	/// </summary>
	/// <param name="hSummaryInfo">Handle to summary information.</param>
	/// <param name="uiProperty">
	/// Specifies the property ID of the summary property being set. This parameter can be a property ID listed in the Summary
	/// Information Stream Property Set. This function does not set values for PID_DICTIONARY OR PID_THUMBNAIL property.
	/// </param>
	/// <param name="uiDataType">
	/// Specifies the type of property to set. This parameter can be a type listed in the Summary Information Stream Property Set.
	/// </param>
	/// <param name="iValue">Specifies the integer value.</param>
	/// <param name="pftValue">Specifies the file-time value.</param>
	/// <param name="szValue">Specifies the text value.</param>
	/// <returns>The <c>MsiSummaryInfoSetProperty</c> function returns the following values:</returns>
	/// <remarks/>
	// https://docs.microsoft.com/en-us/windows/win32/api/msiquery/nf-msiquery-msisummaryinfosetpropertya UINT
	// MsiSummaryInfoSetPropertyA( MSIHANDLE hSummaryInfo, UINT uiProperty, UINT uiDataType, INT iValue, FILETIME *pftValue, LPCSTR
	// szValue );
	[DllImport(Lib_Msi, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("msiquery.h", MSDNShortId = "NF:msiquery.MsiSummaryInfoSetPropertyA")]
	public static extern Win32Error MsiSummaryInfoSetProperty(MSIHANDLE hSummaryInfo, uint uiProperty, uint uiDataType, [Optional] int iValue,
		[In, Optional] IntPtr pftValue, [Optional, MarshalAs(UnmanagedType.LPTStr)] string? szValue);

	/// <summary>The <c>MsiVerifyDiskSpace</c> function checks to see if sufficient disk space is present for the current installation.</summary>
	/// <param name="hInstall">
	/// Handle to the installation provided to a DLL custom action or obtained through MsiOpenPackage, MsiOpenPackageEx, or MsiOpenProduct.
	/// </param>
	/// <returns>This function returns UINT.</returns>
	/// <remarks>See Calling Database Functions From Programs.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/msiquery/nf-msiquery-msiverifydiskspace UINT MsiVerifyDiskSpace( MSIHANDLE
	// hInstall );
	[DllImport(Lib_Msi, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("msiquery.h", MSDNShortId = "NF:msiquery.MsiVerifyDiskSpace")]
	public static extern Win32Error MsiVerifyDiskSpace(MSIHANDLE hInstall);

	/// <summary>The <c>MsiViewClose</c> function releases the result set for an executed view.</summary>
	/// <param name="hView">Handle to a view that is set to release.</param>
	/// <returns>Note that in low memory situations, this function can raise a STATUS_NO_MEMORY exception.</returns>
	/// <remarks>
	/// The <c>MsiViewClose</c> function must be called before the MsiViewExecute function is called again on the view, unless all rows
	/// of the result set have been obtained with the MsiViewFetch function.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/msiquery/nf-msiquery-msiviewclose UINT MsiViewClose( MSIHANDLE hView );
	[DllImport(Lib_Msi, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("msiquery.h", MSDNShortId = "NF:msiquery.MsiViewClose")]
	public static extern Win32Error MsiViewClose(MSIHANDLE hView);

	/// <summary>
	/// The <c>MsiViewExecute</c> function executes a SQL view query and supplies any required parameters. The query uses the question
	/// mark token to represent parameters as described in SQL Syntax. The values of these parameters are passed in as the corresponding
	/// fields of a parameter record.
	/// </summary>
	/// <param name="hView">Handle to the view upon which to execute the query.</param>
	/// <param name="hRecord">
	/// Handle to a record that supplies the parameters. This parameter contains values to replace the parameter tokens in the SQL
	/// query. It is optional, so hRecord can be zero. For a reference on syntax, see SQL Syntax.
	/// </param>
	/// <returns>Note that in low memory situations, this function can raise a STATUS_NO_MEMORY exception.</returns>
	/// <remarks>
	/// <para>The <c>MsiViewExecute</c> function must be called before any calls to MsiViewFetch.</para>
	/// <para>
	/// If the SQL query specifies values with parameter markers (?), a record must be supplied that contains all of the replacement
	/// values in the exact order and of compatible data types. When used with INSERT and UPDATE queries all the parameterized values
	/// must precede all nonparameterized values.
	/// </para>
	/// <para>For example, these queries are valid.</para>
	/// <para>UPDATE {table-list} SET {column}= ? , {column}= {constant}</para>
	/// <para>INSERT INTO {table} ({column-list}) VALUES (?, {constant-list})</para>
	/// <para>However these queries are invalid.</para>
	/// <para>UPDATE {table-list} SET {column}= {constant}, {column}=?</para>
	/// <para>INSERT INTO {table} ({column-list}) VALUES ({constant-list}, ? )</para>
	/// <para>If the function fails, you can obtain extended error information by using MsiGetLastErrorRecord.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/msiquery/nf-msiquery-msiviewexecute UINT MsiViewExecute( MSIHANDLE hView,
	// MSIHANDLE hRecord );
	[DllImport(Lib_Msi, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("msiquery.h", MSDNShortId = "NF:msiquery.MsiViewExecute")]
	public static extern Win32Error MsiViewExecute(MSIHANDLE hView, [Optional] MSIHANDLE hRecord);

	/// <summary>
	/// The <c>MsiViewFetch</c> function fetches the next sequential record from the view. This function returns a handle that should be
	/// closed using MsiCloseHandle.
	/// </summary>
	/// <param name="hView">Handle to the view to fetch from.</param>
	/// <param name="phRecord">Pointer to the handle for the fetched record.</param>
	/// <returns>Note that in low memory situations, this function can raise a STATUS_NO_MEMORY exception.</returns>
	/// <remarks>
	/// <para>
	/// If the <c>MsiViewFetch</c> function returns ERROR_FUNCTION_FAILED, it is possible that the MsiViewExecute function was not
	/// called first. If more rows are available in the result set, <c>MsiViewFetch</c> returns phRecord as a handle to a record
	/// containing the requested column data, or phRecord is 0. For maximum performance, the same record should be used for all
	/// retrievals, or the record should be released by going out of scope.
	/// </para>
	/// <para>
	/// Note that it is recommended to use variables of type PMSIHANDLE because the installer closes PMSIHANDLE objects as they go out
	/// of scope, whereas you must close MSIHANDLE objects by calling MsiCloseHandle. For more information see Use PMSIHANDLE instead of
	/// HANDLE section in the Windows Installer Best Practices.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/msiquery/nf-msiquery-msiviewfetch UINT MsiViewFetch( MSIHANDLE hView,
	// MSIHANDLE *phRecord );
	[DllImport(Lib_Msi, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("msiquery.h", MSDNShortId = "NF:msiquery.MsiViewFetch")]
	public static extern Win32Error MsiViewFetch(MSIHANDLE hView, out PMSIHANDLE phRecord);

	/// <summary>
	/// The <c>MsiViewGetColumnInfo</c> function returns a record containing column names or definitions. This function returns a handle
	/// that should be closed using MsiCloseHandle.
	/// </summary>
	/// <param name="hView">Handle to the view from which to obtain column information.</param>
	/// <param name="eColumnInfo">
	/// <para>Specifies a flag indicating what type of information is needed. This parameter must be one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>MSICOLINFO_NAMES</term>
	/// <term>Column names are returned.</term>
	/// </item>
	/// <item>
	/// <term>MSICOLINFO_TYPES</term>
	/// <term>Definitions are returned.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="phRecord">Pointer to a handle to receive the column information data record.</param>
	/// <returns>Note that in low memory situations, this function can raise a STATUS_NO_MEMORY exception.</returns>
	/// <remarks>
	/// <para>
	/// The column description returned by <c>MsiViewGetColumnInfo</c> is in the format described in the section: Column Definition
	/// Format. Each column is described by a string in the corresponding record field. The definition string consists of a single
	/// letter representing the data type followed by the width of the column (in characters when applicable, bytes otherwise). A width
	/// of zero designates an unbounded width (for example, long text fields and streams). An uppercase letter indicates that null
	/// values are allowed in the column.
	/// </para>
	/// <para>
	/// Note that it is recommended to use variables of type PMSIHANDLE because the installer closes PMSIHANDLE objects as they go out
	/// of scope, whereas you must close MSIHANDLE objects by calling MsiCloseHandle. For more information see Use PMSIHANDLE instead of
	/// HANDLE section in the Windows Installer Best Practices.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/msiquery/nf-msiquery-msiviewgetcolumninfo UINT MsiViewGetColumnInfo( MSIHANDLE
	// hView, MSICOLINFO eColumnInfo, MSIHANDLE *phRecord );
	[DllImport(Lib_Msi, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("msiquery.h", MSDNShortId = "NF:msiquery.MsiViewGetColumnInfo")]
	public static extern Win32Error MsiViewGetColumnInfo(MSIHANDLE hView, MSICOLINFO eColumnInfo, out PMSIHANDLE phRecord);

	/// <summary>The <c>MsiViewGetError</c> function returns the error that occurred in the MsiViewModify function.</summary>
	/// <param name="hView">Handle to the view.</param>
	/// <param name="szColumnNameBuffer">
	/// Pointer to the buffer that receives the null-terminated column name. Do not attempt to determine the size of the buffer by
	/// passing in a null (value=0) for szColumnName. You can get the size of the buffer by passing in an empty string (for example "").
	/// The function then returns MSIDBERROR_MOREDATA and pcchBuf contains the required buffer size in TCHARs, not including the
	/// terminating null character. On return of MSIDBERROR_NOERROR, pcchBuf contains the number of TCHARs written to the buffer, not
	/// including the terminating null character. This parameter is an empty string if there are no errors.
	/// </param>
	/// <param name="pcchBuf">
	/// Pointer to the variable that specifies the size, in TCHARs, of the buffer pointed to by the variable szColumnNameBuffer. When
	/// the function returns MSIDBERROR_NOERROR, this variable contains the size of the data copied to szColumnNameBuffer, not including
	/// the terminating null character. If szColumnNameBuffer is not large enough, the function returns MSIDBERROR_MOREDATA and stores
	/// the required size, not including the terminating null character, in the variable pointed to by pcchBuf.
	/// </param>
	/// <returns>
	/// <para>This function returns one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Error code</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>MSIDBERROR_INVALIDARG</term>
	/// <term>An argument was invalid.</term>
	/// </item>
	/// <item>
	/// <term>MSIDBERROR_MOREDATA</term>
	/// <term>The buffer was too small to receive data.</term>
	/// </item>
	/// <item>
	/// <term>MSIDBERROR_FUNCTIONERROR</term>
	/// <term>The function failed.</term>
	/// </item>
	/// <item>
	/// <term>MSIDBERROR_NOERROR</term>
	/// <term>The function completed successfully with no errors.</term>
	/// </item>
	/// <item>
	/// <term>MSIDBERROR_DUPLICATEKEY</term>
	/// <term>The new record duplicates primary keys of the existing record in a table.</term>
	/// </item>
	/// <item>
	/// <term>MSIDBERROR_REQUIRED</term>
	/// <term>There are no null values allowed; or the column is about to be deleted, but is referenced by another row.</term>
	/// </item>
	/// <item>
	/// <term>MSIDBERROR_BADLINK</term>
	/// <term>The corresponding record in a foreign table was not found.</term>
	/// </item>
	/// <item>
	/// <term>MSIDBERROR_OVERFLOW</term>
	/// <term>The data is greater than the maximum value allowed.</term>
	/// </item>
	/// <item>
	/// <term>MSIDBERROR_UNDERFLOW</term>
	/// <term>The data is less than the minimum value allowed.</term>
	/// </item>
	/// <item>
	/// <term>MSIDBERROR_NOTINSET</term>
	/// <term>The data is not a member of the values permitted in the set.</term>
	/// </item>
	/// <item>
	/// <term>MSIDBERROR_BADVERSION</term>
	/// <term>An invalid version string was supplied.</term>
	/// </item>
	/// <item>
	/// <term>MSIDBERROR_BADCASE</term>
	/// <term>The case was invalid. The case must be all uppercase or all lowercase.</term>
	/// </item>
	/// <item>
	/// <term>MSIDBERROR_BADGUID</term>
	/// <term>An invalid GUID was supplied.</term>
	/// </item>
	/// <item>
	/// <term>MSIDBERROR_BADWILDCARD</term>
	/// <term>An invalid wildcard file name was supplied, or the use of wildcards was invalid.</term>
	/// </item>
	/// <item>
	/// <term>MSIDBERROR_BADIDENTIFIER</term>
	/// <term>An invalid identifier was supplied.</term>
	/// </item>
	/// <item>
	/// <term>MSIDBERROR_BADLANGUAGE</term>
	/// <term>Invalid language IDs were supplied.</term>
	/// </item>
	/// <item>
	/// <term>MSIDBERROR_BADFILENAME</term>
	/// <term>An invalid file name was supplied.</term>
	/// </item>
	/// <item>
	/// <term>MSIDBERROR_BADPATH</term>
	/// <term>An invalid path was supplied.</term>
	/// </item>
	/// <item>
	/// <term>MSIDBERROR_BADCONDITION</term>
	/// <term>An invalid conditional statement was supplied.</term>
	/// </item>
	/// <item>
	/// <term>MSIDBERROR_BADFORMATTED</term>
	/// <term>An invalid format string was supplied.</term>
	/// </item>
	/// <item>
	/// <term>MSIDBERROR_BADTEMPLATE</term>
	/// <term>An invalid template string was supplied.</term>
	/// </item>
	/// <item>
	/// <term>MSIDBERROR_BADDEFAULTDIR</term>
	/// <term>An invalid string was supplied in the DefaultDir column of the Directory table.</term>
	/// </item>
	/// <item>
	/// <term>MSIDBERROR_BADREGPATH</term>
	/// <term>An invalid registry path string was supplied.</term>
	/// </item>
	/// <item>
	/// <term>MSIDBERROR_BADCUSTOMSOURCE</term>
	/// <term>An invalid string was supplied in the CustomSource column of the CustomAction table.</term>
	/// </item>
	/// <item>
	/// <term>MSIDBERROR_BADPROPERTY</term>
	/// <term>An invalid property string was supplied.</term>
	/// </item>
	/// <item>
	/// <term>MSIDBERROR_MISSINGDATA</term>
	/// <term>The _Validation table is missing a reference to a column.</term>
	/// </item>
	/// <item>
	/// <term>MSIDBERROR_BADCATEGORY</term>
	/// <term>The category column of the _Validation table for the column is invalid.</term>
	/// </item>
	/// <item>
	/// <term>MSIDBERROR_BADCABINET</term>
	/// <term>An invalid cabinet name was supplied.</term>
	/// </item>
	/// <item>
	/// <term>MSIDBERROR_BADKEYTABLE</term>
	/// <term>The table in the Keytable column of the _Validation table was not found or loaded.</term>
	/// </item>
	/// <item>
	/// <term>MSIDBERROR_BADMAXMINVALUES</term>
	/// <term>The value in the MaxValue column of the _Validation table is less than the value in the MinValue column.</term>
	/// </item>
	/// <item>
	/// <term>MSIDBERROR_BADSHORTCUT</term>
	/// <term>An invalid shortcut target name was supplied.</term>
	/// </item>
	/// <item>
	/// <term>MSIDBERROR_STRINGOVERFLOW</term>
	/// <term>The string is too long for the length specified by the column definition.</term>
	/// </item>
	/// <item>
	/// <term>MSIDBERROR_BADLOCALIZEATTRIB</term>
	/// <term>An invalid localization attribute was supplied. (Primary keys cannot be localized.)</term>
	/// </item>
	/// </list>
	/// <para>Note that in low memory situations, this function can raise a STATUS_NO_MEMORY exception.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// You should only call the <c>MsiViewGetError</c> function when MsiViewModify returns ERROR_INVALID_DATA, indicating that the data
	/// is invalid. Errors are only recorded for MSIMODIFY_VALIDATE, MSIMODIFY_VALIDATE_NEW, and MSIMODIFY_VALIDATEFIELD.
	/// </para>
	/// <para>
	/// If ERROR_MORE_DATA is returned, the parameter that is a pointer gives the size of the buffer required to hold the string. Upon
	/// success, it gives the number of characters written to the string buffer. Therefore you can get the required size of the buffer
	/// by passing a small buffer (one character minimum) and examining the value at pcchPathBuf when the function returns
	/// MSIDBERROR_MOREDATA. Do not attempt to determine the size of the buffer by passing in null as szColumnNameBuffer or a buffer
	/// size of 0 in the <c>DWORD</c> referenced by pcchBuf.
	/// </para>
	/// <para>
	/// Once MSIDBERROR_NOERROR is returned, no more validation errors remain. The MSIDBERROR return value indicates the type of
	/// validation error that occurred for the value located in the column identified by the szColumnNameBuffer.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/msiquery/nf-msiquery-msiviewgeterrorw MSIDBERROR MsiViewGetErrorW( MSIHANDLE
	// hView, PWSTR szColumnNameBuffer, LPDWORD pcchBuf );
	[DllImport(Lib_Msi, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("msiquery.h", MSDNShortId = "NF:msiquery.MsiViewGetErrorW")]
	public static extern MSIDBERROR MsiViewGetError(MSIHANDLE hView, [MarshalAs(UnmanagedType.LPTStr)] StringBuilder szColumnNameBuffer, ref uint pcchBuf);

	/// <summary>The <c>MsiViewModify</c> function updates a fetched record.</summary>
	/// <param name="hView">Handle to a view.</param>
	/// <param name="eModifyMode">
	/// <para>Specifies the modify mode. This parameter can be one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>MSIMODIFY_SEEK -1</term>
	/// <term>
	/// Refreshes the information in the supplied record without changing the position in the result set and without affecting
	/// subsequent fetch operations. The record may then be used for subsequent Update, Delete, and Refresh. All primary key columns of
	/// the table must be in the query and the record must have at least as many fields as the query. Seek cannot be used with
	/// multi-table queries. This mode cannot be used with a view containing joins. See also the remarks.
	/// </term>
	/// </item>
	/// <item>
	/// <term>MSIMODIFY_REFRESH 0</term>
	/// <term>
	/// Refreshes the information in the record. Must first call MsiViewFetch with the same record. Fails for a deleted row. Works with
	/// read-write and read-only records.
	/// </term>
	/// </item>
	/// <item>
	/// <term>MSIMODIFY_INSERT 1</term>
	/// <term>
	/// Inserts a record. Fails if a row with the same primary keys exists. Fails with a read-only database. This mode cannot be used
	/// with a view containing joins.
	/// </term>
	/// </item>
	/// <item>
	/// <term>MSIMODIFY_UPDATE 2</term>
	/// <term>
	/// Updates an existing record. Nonprimary keys only. Must first call MsiViewFetch. Fails with a deleted record. Works only with
	/// read-write records.
	/// </term>
	/// </item>
	/// <item>
	/// <term>MSIMODIFY_ASSIGN 3</term>
	/// <term>
	/// Writes current data in the cursor to a table row. Updates record if the primary keys match an existing row and inserts if they
	/// do not match. Fails with a read-only database. This mode cannot be used with a view containing joins.
	/// </term>
	/// </item>
	/// <item>
	/// <term>MSIMODIFY_REPLACE 4</term>
	/// <term>
	/// Updates or deletes and inserts a record into a table. Must first call MsiViewFetch with the same record. Updates record if the
	/// primary keys are unchanged. Deletes old row and inserts new if primary keys have changed. Fails with a read-only database. This
	/// mode cannot be used with a view containing joins.
	/// </term>
	/// </item>
	/// <item>
	/// <term>MSIMODIFY_MERGE 5</term>
	/// <term>
	/// Inserts or validates a record in a table. Inserts if primary keys do not match any row and validates if there is a match. Fails
	/// if the record does not match the data in the table. Fails if there is a record with a duplicate key that is not identical. Works
	/// only with read-write records. This mode cannot be used with a view containing joins.
	/// </term>
	/// </item>
	/// <item>
	/// <term>MSIMODIFY_DELETE 6</term>
	/// <term>
	/// Remove a row from the table. You must first call the MsiViewFetch function with the same record. Fails if the row has been
	/// deleted. Works only with read-write records. This mode cannot be used with a view containing joins.
	/// </term>
	/// </item>
	/// <item>
	/// <term>MSIMODIFY_INSERT_TEMPORARY 7</term>
	/// <term>
	/// Inserts a temporary record. The information is not persistent. Fails if a row with the same primary key exists. Works only with
	/// read-write records. This mode cannot be used with a view containing joins.
	/// </term>
	/// </item>
	/// <item>
	/// <term>MSIMODIFY_VALIDATE 8</term>
	/// <term>
	/// Validates a record. Does not validate across joins. You must first call the MsiViewFetch function with the same record. Obtain
	/// validation errors with MsiViewGetError. Works with read-write and read-only records. This mode cannot be used with a view
	/// containing joins.
	/// </term>
	/// </item>
	/// <item>
	/// <term>MSIMODIFY_VALIDATE_NEW 9</term>
	/// <term>
	/// Validate a new record. Does not validate across joins. Checks for duplicate keys. Obtain validation errors by calling
	/// MsiViewGetError. Works with read-write and read-only records. This mode cannot be used with a view containing joins.
	/// </term>
	/// </item>
	/// <item>
	/// <term>MSIMODIFY_VALIDATE_FIELD 10</term>
	/// <term>
	/// Validates fields of a fetched or new record. Can validate one or more fields of an incomplete record. Obtain validation errors
	/// by calling MsiViewGetError. Works with read-write and read-only records. This mode cannot be used with a view containing joins.
	/// </term>
	/// </item>
	/// <item>
	/// <term>MSIMODIFY_VALIDATE_DELETE 11</term>
	/// <term>
	/// Validates a record that will be deleted later. You must first call MsiViewFetch. Fails if another row refers to the primary keys
	/// of this row. Validation does not check for the existence of the primary keys of this row in properties or strings. Does not
	/// check if a column is a foreign key to multiple tables. Obtain validation errors by calling MsiViewGetError. Works with
	/// read-write and read-only records. This mode cannot be used with a view that contains joins.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="hRecord">Handle to the record to modify.</param>
	/// <returns>
	/// <para>The <c>MsiViewModify</c> function returns the following values:</para>
	/// <para>Note that in low memory situations, this function can raise a STATUS_NO_MEMORY exception.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The MSIMODIFY_VALIDATE, MSIMODIFY_VALIDATE_NEW, MSIMODIFY_VALIDATE_FIELD, and MSIMODIFY_VALIDATE_DELETE values of the
	/// <c>MsiViewModify</c> function do not perform actual updates; they ensure that the data in the record is valid. Use of these
	/// validation enumerations requires that the database contains the _Validation table.
	/// </para>
	/// <para>
	/// You can call MSIMODIFY_UPDATE or MSIMODIFY_DELETE with a record immediately after using MSIMODIFY_INSERT,
	/// MSIMODIFY_INSERT_TEMPORARY, or MSIMODIFY_SEEK provided you have NOT modified the 0th field of the inserted or sought record.
	/// </para>
	/// <para>
	/// To execute any SQL statement, a view must be created. However, a view that does not create a result set, such as CREATE TABLE,
	/// or INSERT INTO, cannot be used with <c>MsiViewModify</c> to update tables though the view.
	/// </para>
	/// <para>
	/// You cannot fetch a record that contains binary data from one database and then use that record to insert the data into another
	/// database. To move binary data from one database to another, you should export the data to a file and then import it into the new
	/// database using a query and the MsiRecordSetStream. This ensures that each database has its own copy of the binary data.
	/// </para>
	/// <para>
	/// Note that custom actions can only add, modify, or remove temporary rows, columns, or tables from a database. Custom actions
	/// cannot modify persistent data in a database, such as data that is a part of the database stored on disk. For more information,
	/// see Accessing the Current Installer Session from Inside a Custom Action.
	/// </para>
	/// <para>If the function fails, you can obtain extended error information by using MsiGetLastErrorRecord.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/msiquery/nf-msiquery-msiviewmodify UINT MsiViewModify( MSIHANDLE hView,
	// MSIMODIFY eModifyMode, MSIHANDLE hRecord );
	[DllImport(Lib_Msi, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("msiquery.h", MSDNShortId = "NF:msiquery.MsiViewModify")]
	public static extern Win32Error MsiViewModify(MSIHANDLE hView, MSIMODIFY eModifyMode, MSIHANDLE hRecord);
}