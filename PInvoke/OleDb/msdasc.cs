namespace Vanara.PInvoke;

public static partial class OleDb
{
	/// <summary/>
	public static readonly Guid CLSID_EXTENDEDERRORINFO = new(0xc8b522cf, 0x5cf3, 0x11ce, 0xad, 0xe5, 0x00, 0xaa, 0x00, 0x44, 0x77, 0x3d);

	/// <summary/>
	public static readonly Guid CLSID_MSDAVTM = new(0x0c733a8e, 0x2a1c, 0x11ce, 0xad, 0xe5, 0x00, 0xaa, 0x00, 0x44, 0x77, 0x3d);

	/// <summary/>
	public static readonly Guid CLSID_OLEDB_CONVERSIONLIBRARY = new(0xc8b522d1, 0x5cf3, 0x11ce, 0xad, 0xe5, 0x00, 0xaa, 0x00, 0x44, 0x77, 0x3d);

	/// <summary/>
	public static readonly Guid CLSID_OLEDB_ENUMERATOR = new(0xc8b522d0, 0x5cf3, 0x11ce, 0xad, 0xe5, 0x00, 0xaa, 0x00, 0x44, 0x77, 0x3d);

	/// <summary/>
	public static readonly Guid CLSID_OLEDB_ROWPOSITIONLIBRARY = new(0x2048eee6, 0x7fa2, 0x11d0, 0x9e, 0x6a, 0x00, 0xa0, 0xc9, 0x13, 0x8c, 0x29);

	/// <summary/>
	public static readonly Guid OLEDB_SVC_DSLPropertyPages = new(0x51740c02, 0x7e8e, 0x11d2, 0xa0, 0x2d, 0x00, 0xc0, 0x4f, 0xa3, 0x73, 0x48);

	/// <summary/>
	public static readonly Guid IID_ISQLRequestDiagFields = new(0x228972f0, 0xb5ff, 0x11d0, 0x8a, 0x80, 0x0, 0xc0, 0x4f, 0xd6, 0x11, 0xcd);

	/// <summary/>
	public static readonly Guid IID_ISQLGetDiagField = new(0x228972f1, 0xb5ff, 0x11d0, 0x8a, 0x80, 0x0, 0xc0, 0x4f, 0xd6, 0x11, 0xcd);

	/// <summary/>
	public static readonly Guid IID_IRowsetChangeExtInfo = new(0x0C733A8F, 0x2A1C, 0x11CE, 0xAD, 0xE5, 0x00, 0xAA, 0x00, 0x44, 0x77, 0x3D);

	/// <summary/>
	public static readonly Guid CLSID_MSDASQL = new(0xC8B522CB, 0x5CF3, 0x11CE, 0xAD, 0xE5, 0x00, 0xAA, 0x00, 0x44, 0x77, 0x3D);

	/// <summary/>
	public static readonly Guid CLSID_MSDASQL_ENUMERATOR = new(0xC8B522CD, 0x5CF3, 0x11CE, 0xAD, 0xE5, 0x00, 0xAA, 0x00, 0x44, 0x77, 0x3D);

	/// <summary/>
	public static readonly Guid DBPROPSET_PROVIDERDATASOURCEINFO = new(0x497c60e0, 0x7123, 0x11cf, 0xb1, 0x71, 0x0, 0xaa, 0x0, 0x57, 0x59, 0x9e);

	/// <summary/>
	public static readonly Guid DBPROPSET_PROVIDERROWSET = new(0x497c60e1, 0x7123, 0x11cf, 0xb1, 0x71, 0x0, 0xaa, 0x0, 0x57, 0x59, 0x9e);

	/// <summary/>
	public static readonly Guid DBPROPSET_PROVIDERDBINIT = new(0x497c60e2, 0x7123, 0x11cf, 0xb1, 0x71, 0x0, 0xaa, 0x0, 0x57, 0x59, 0x9e);

	/// <summary/>
	public static readonly Guid DBPROPSET_PROVIDERSTMTATTR = new(0x497c60e3, 0x7123, 0x11cf, 0xb1, 0x71, 0x0, 0xaa, 0x0, 0x57, 0x59, 0x9e);

	/// <summary/>
	public static readonly Guid DBPROPSET_PROVIDERCONNATTR = new(0x497c60e4, 0x7123, 0x11cf, 0xb1, 0x71, 0x0, 0xaa, 0x0, 0x57, 0x59, 0x9e);

	/// <summary>Specifies whether to prompt with the Create New Data Link wizard or the Data Link Properties dialog box.</summary>
	[Flags]
	[PInvokeData("msdasc.h")]
	public enum DBPROMPTOPTIONS
	{
		/// <summary/>
		DBPROMPTOPTIONS_NONE = 0,

		/// <summary>Deprecated. Retained for backward compatibility only.</summary>
		DBPROMPTOPTIONS_WIZARDSHEET = 0x1,

		/// <summary>Prompt with Data Link Properties dialog box.</summary>
		DBPROMPTOPTIONS_PROPERTYSHEET = 0x2,

		/// <summary/>
		DBPROMPTOPTIONS_BROWSEONLY = 0x8,

		/// <summary>
		/// Do not prompt for provider selection. Valid only if *ppDataSource is a pointer to an existing data source object. Setting this
		/// flag without specifying a valid data source object in ppDataSource on input returns the error E_INVALIDARG.
		/// </summary>
		DBPROMPTOPTIONS_DISABLE_PROVIDER_SELECTION = 0x10,

		/// <summary>
		/// Disables the "Allow Saving password" checkbox. When set, the value of the property DBPROP_AUTH_PERSIST_SENSITIVE_AUTHINFO is set
		/// to VARIANT_FALSE on the provider.
		/// </summary>
		DBPROMPTOPTIONS_DISABLESAVEPASSWORD = 0x20
	}

	/// <summary>Types of providers to display in the Provider selection tab</summary>
	[PInvokeData("msdasc.h")]
	public enum DBSOURCETYPE : uint
	{
		/// <summary>OLE DB tabular data provider</summary>
		DBSOURCETYPE_DATASOURCE_TDP = 1,

		/// <summary/>
		DBSOURCETYPE_ENUMERATOR,

		/// <summary>OLE DB multidimensional data provider</summary>
		DBSOURCETYPE_DATASOURCE_MDP,

		/// <summary/>
		DBSOURCETYPE_BINDER,
	}

	/// <summary>
	/// <para>
	/// Use the <c>IDataInitialize</c> interface to create a data source object using a connection string. You can also retrieve a connection
	/// string from an existing data source object.
	/// </para>
	/// <para>
	/// To build a connection string, use the prompting user interface available through the IDBPromptInitialize interface and then use
	/// <c>IDataInitialize</c> to get a data source object based on that connection string.
	/// </para>
	/// <para>For more information, see Creating Data Source Objects.</para>
	/// </summary>
	// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/ms714296(v=vs.85)
	[PInvokeData("msdasc.h")]
	[ComImport, Guid("2206CCB1-19C1-11D1-89E0-00C04FD7A829"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown), CoClass(typeof(MSDAINITIALIZE))]
	public interface IDataInitialize
	{
		/// <summary>Given a connection string, instantiates and returns an uninitialized data source object.</summary>
		/// <param name="pUnkOuter">
		/// A pointer to the controlling <c>IUnknown</c> interface if the data source object is being created as a part of an aggregate;
		/// otherwise, it is a null pointer.
		/// </param>
		/// <param name="dwClsCtx">
		/// CLSCTX values. CLSCTX_ALL, CLSCTX_SERVER, and CLSCTX_INPROC_SERVER are acceptable values, but the service components will always
		/// attempt to load the provider in-process. Ignored if *ppDataSource is not NULL.
		/// </param>
		/// <param name="pwszInitializationString">
		/// <para>
		/// A pointer to a connection string containing the information to be used for creating and setting initialization properties on a
		/// data source object. Initialization properties are those in DBPROPSET_DBINIT, as well as provider-specific properties. If
		/// pwszInitializationString is NULL, an instance of the OLE DB provider for ODBC data is returned with default properties set.
		/// </para>
		/// <para>
		/// When run in a 32-bit application, if pwszInitializationString is NULL, an instance of the OLE DB provider for ODBC data is
		/// returned with default properties set.
		/// </para>
		/// <para>
		/// When run in a 64-bit application, if pwszInitializationString is NULL, an instance of the SQLOLEDB provider is returned with
		/// default properties set.
		/// </para>
		/// </param>
		/// <param name="riid">The requested IID for the data source object returned in *ppDataSource.</param>
		/// <param name="ppDataSource">
		/// <para>A pointer to a data source object.</para>
		/// <para>
		/// If *ppDataSource is null on entry, <c>IDataInitialize::GetDataSource</c> generates a new data source object based on the
		/// information in pwszInitializationString and returns a pointer to that data source object in *ppDataSource.
		/// </para>
		/// <para>
		/// When run in a 32-bit application, if *ppDataSource is null and no provider is specified in pwszInitializationString, OLE DB Core
		/// Services returns a data source instance of OLE DB Provider for ODBC.
		/// </para>
		/// <para>
		/// When run in a 64-bit application, if *ppDataSource is null and no provider is specified in pwszInitializationString, OLE DB Core
		/// Services returns a data source instance of SQLOLEDB.
		/// </para>
		/// <para>
		/// If *ppDataSource is null and no provider is specified in pwszInitializationString, the data source object will be defaulted to
		/// the OLE DB Provider for ODBC.
		/// </para>
		/// <para>
		/// If *ppDataSource is non-null and no provider is specified in pwszInitializationString, the data source specified by *ppDataSource
		/// will be used.
		/// </para>
		/// <para>
		/// If *ppDataSource is non-null on entry and a provider is specified in pwszInitializationString,
		/// <c>IDataInitialize::GetDataSource</c> checks to see whether the specified provider matches the data source object passed in
		/// *ppDataSource. If so, <c>GetDataSource</c> sets the specified properties on the existing data source object. If not,
		///  <c>GetDataSource</c> returns an error and leaves *ppDataSource untouched.
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
		/// <para>E_NOINTERFACE The data source did not support the interface specified in riid.</para>
		/// <para>riid was IID_NULL.</para>
		/// <para>*ppDataSource was not null and did not indicate an OLE DB data source object.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>E_UNEXPECTED The data source object cannot return the requested interface because the data source object is not initialized.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// DB_E_MISMATCHEDPROVIDER The data source object specified by *ppDataSource did not match the data source object specified in pwszInitializationString.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// DB_E_NOAGGREGATION pwszInitializationString specified a provider, pUnkOuter was not a null pointer, and riid was something other
		/// than <c>IID_IUnknown</c>.
		/// </para>
		/// <para>pwszInitializationString specified a provider, pUnkOuter was not a null pointer, and the provider does not support aggregation.</para>
		/// <para>dwClsCtx required out-of-process operation, which is not supported.</para>
		/// <para>The provider does not support in-process operation and cannot be aggregated.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>E_INVALIDARG pwszInitializationString specified a provider, and dwClsCtx was not a valid value.</para>
		/// <para>ppDataSource was a null pointer.</para>
		/// <para>
		/// *ppDataSource and pUnkOuter were both non-null. *ppDataSource cannot be aggregated in *pUnkOuter because it has already been created.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>REGDB_E_CLASSNOTREG The provider indicated in pwszInitializationString was not found.</para>
		/// <para>dwClsCtx indicated a server type not supported by the provider specified in pwszInitializationString.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_E_ERRORSOCCURRED A property specified in pwszInitializationString was not supported by the provider.</para>
		/// <para>Properties were specified in pwszInitializationString but *ppDataSource indicated a data source that was already initialized.</para>
		/// <para>
		/// A property specified in pwszInitializationString was a read-only property, and the property was not set to its default value.
		/// </para>
		/// <para>It was not possible to set a property specified in pwszInitializationString.</para>
		/// <para>One or more properties specified in pwszInitializationString conflicted with an existing property or with one another.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_E_BADINITSTRING A property or value specified in pwszInitializationString was invalid or not supported by the provider.</para>
		/// </description>
		/// </item>
		/// </list>
		/// </returns>
		// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/ms725368(v=vs.85)
		void GetDataSource([In, MarshalAs(UnmanagedType.IUnknown)] object? pUnkOuter, CLSCTX dwClsCtx, string? pwszInitializationString,
			in Guid riid, [MarshalAs(UnmanagedType.IUnknown)] ref object? ppDataSource);

		/// <summary>Given a data source object, returns a connection string.</summary>
		/// <param name="pDataSource">A pointer to a data source object.</param>
		/// <param name="fIncludePassword">
		/// Whether or not to include the password property, if specified, in the returned initialization string. If
		/// DBPROP_AUTH_PERSIST_SENSITIVE_AUTHINFO is set to VARIANT_FALSE, the password is not returned, even if fIncludePassword is true.
		/// To include the password in the returned initialization string, consumers should make sure that
		/// DBPROP_AUTH_PERSIST_SENSITIVE_AUTHINFO is set to VARIANT_TRUE.
		/// </param>
		/// <returns>Returned connection string containing information necessary to re-create the data source object and current properties.</returns>
		// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/ms714195(v=vs.85)
		[return: MarshalAs(UnmanagedType.LPWStr)]
		string GetInitializationString([In, MarshalAs(UnmanagedType.IUnknown)] object? pDataSource, BOOLEAN fIncludePassword);

		/// <summary>Creates a data source object; analogous to <c>CoCreateInstance</c>.</summary>
		/// <param name="clsidProvider">The CLSID of the provider to instantiate.</param>
		/// <param name="pUnkOuter">
		/// A pointer to the controlling <c>IUnknown</c> interface if the data source object is being created as a part of an aggregate;
		/// otherwise, it is a null pointer.
		/// </param>
		/// <param name="dwClsCtx">
		/// CLSCTX values. CLSCTX_ALL, CLSCTX_SERVER, and CLSCTX_INPROC_SERVER are acceptable values, but the service components will always
		/// attempt to load the provider in-process. Ignored if *ppDataSource is not NULL.
		/// </param>
		/// <param name="pwszReserved">Reserved for future use; must be NULL.</param>
		/// <param name="riid">Interface requested on the data source.</param>
		/// <param name="ppDataSource">A pointer to memory in which to return the interface pointer on the newly created data source.</param>
		// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/ms723098(v=vs.85) HRESULT CreateDBInstance( REFCLSID
		// clsidProvider, IUnknown * pUnkOuter, DWORD dwClsCtx, LPOLESTR pwszReserved, REFIID riid, IUnknown ** ppDataSource);
		void CreateDBInstance(in Guid clsidProvider, [In, Optional, MarshalAs(UnmanagedType.IUnknown)] object? pUnkOuter, CLSCTX dwClsCtx,
			[In, Optional] string? pwszReserved, in Guid riid, [MarshalAs(UnmanagedType.IUnknown)] out object? ppDataSource);

		/// <summary>Creates a data source object; analogous to <c>CoCreateInstanceEx</c>.</summary>
		/// <param name="clsidProvider">The CLSID of the provider to instantiate.</param>
		/// <param name="pUnkOuter">
		/// A pointer to the controlling <c>IUnknown</c> interface if the data source object is being created as a part of an aggregate;
		/// otherwise, it is a null pointer.
		/// </param>
		/// <param name="dwClsCtx">
		/// CLSCTX values. CLSCTX_ALL, CLSCTX_SERVER, and CLSCTX_INPROC_SERVER are acceptable values, but the service components will always
		/// attempt to load the provider in-process. Ignored if *ppDataSource is not NULL.
		/// </param>
		/// <param name="pwszReserved">Reserved for future use; must be NULL.</param>
		/// <param name="pServerInfo">Machine on which the data source objects are to be instantiated.</param>
		/// <param name="cmq">Number of MULTI_QI structures in rgmqResults.</param>
		/// <param name="rgmqResults [in,out]">Array of MULTI_QI structures.</param>
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
		/// CO_S_NOTALLINTERFACES At least one, but not all, of the interfaces requested in the rgmqResults array were successfully retrieved.
		/// </para>
		/// <para>
		/// The hr field of each of the MULTI_QI structures in rgmqResults indicates with S_OK or E_NOINTERFACE whether the specific
		/// interface was returned.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>E_NOINTERFACE The data source did not support the interface specified in riid.</para>
		/// <para>riid was IID_NULL.</para>
		/// <para>The object indicated by clsidProvider was not an OLE DB provider.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>E_UNEXPECTED The data source object cannot return the requested interface because the data source object is not initialized.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_E_NOAGGREGATION pUnkOuter was not a null pointer, and riid was something other than <c>IID_IUnknown</c>.</para>
		/// <para>pUnkOuter was not a null pointer, and the provider does not support aggregation.</para>
		/// <para>dwClsCtx required out-of-process operation, which is not supported.</para>
		/// <para>The provider does not support in-process operation and cannot be aggregated.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>E_INVALIDARG dwClsCtx was not a valid value.</para>
		/// <para>ppDataSource was a null pointer.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>REGDB_E_CLASSNOTREG The provider indicated by clsidProvider was not found.</para>
		/// <para>dwClsCtx indicated a server type not supported by the provider.</para>
		/// </description>
		/// </item>
		/// </list>
		/// </returns>
		// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/ms712946(v=vs.85) HRESULT CreateDBInstanceEx( REFCLSID
		// clsidProvider, IUnknown * pUnkOuter, DWORD dwClsCtx, LPOLESTR pwszReserved, COSERVERINFO * pServerInfo, ULONG cmq, MULTI_QI * rgmqResults);
		[PreserveSig]
		HRESULT CreateDBInstanceEx(in Guid clsidProvider, [In, Optional, MarshalAs(UnmanagedType.IUnknown)] object? pUnkOuter, CLSCTX dwClsCtx,
			[In, Optional] string? pwszReserved, in COSERVERINFO pServerInfo, uint cmq, [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 5)] MULTI_QI[] rgmqResults);

		/// <summary>Loads a connection string.</summary>
		/// <param name="pwszFileName">Name of the file.</param>
		/// <returns>On exit, *ppwszInitializationString will contain the connection string.</returns>
		// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/ms713667(v=vs.85) HRESULT LoadStringFromStorage( LPCOLESTR
		// pwszFileName, LPCOLESTR * ppwszInitializationString);
		[return: MarshalAs(UnmanagedType.LPWStr)]
		string LoadStringFromStorage([In, Optional] string? pwszFileName);

		/// <summary>Writes a connection string.</summary>
		/// <param name="pwszFileName">Name of the file.</param>
		/// <param name="pwszInitializationString">Connection string to write.</param>
		/// <param name="dwCreationDisposition">
		/// Flags controlling the write operation. Same as Win32? <c>CreateFile</c> dwCreationDisposition (CREATE_NEW, CREATE_ALWAYS,
		/// OPEN_EXISTING, OPEN_ALWAYS, TRUNCATE_EXISTING).
		/// </param>
		// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/ms725461(v=vs.85) HRESULT WriteStringToStorage( LPCOLESTR
		// pwszFileName, LPCOLESTR pwszInitializationString, DWORD dwCreationDisposition);
		void WriteStringToStorage([In, Optional] string? pwszFileName, [In, Optional] string? pwszInitializationString, Kernel32.CreationOption dwCreationDisposition);
	}

	/// <summary>
	/// <para>Created for reference use in Visual Basic. Provides implementation for the <c>promptNew</c> and <c>promptEdit</c> methods.</para>
	/// </summary>
	// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/ms722628(v=vs.85)
	[ComImport, Guid("2206CCB2-19C1-11D1-89E0-00C04FD7A829"), InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
	public interface IDataSourceLocator
	{
		/// <summary>The parent window handle for dialog boxes to be displayed. The dialog box will always be centered within this window. Returns the currently assigned window handle.</summary>
		/// <value>A HWND value. The handle of the parent window where the dialog will be displayed.</value>
		public HWND hWnd { get; set; }

		/// <summary>
		/// Opens the <c>Data Link Properties</c> window. Allows the user to select the properties for a new connection. The properties are returned in a connection string.
		/// </summary>
		/// <returns>An ADO connection object. Contains preset connection properties that will be displayed in the Data Link Properties window.</returns>
		// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/ms725384(v=vs.85)
		[return: MarshalAs(UnmanagedType.IDispatch)]
		object? PromptNew();

		/// <summary>
		/// Opens the <c>Data Link Properties</c> window. Allows the user to change the properties for an existing ADO connection object. The
		/// properties for the connection object are changed directly at the connection object.
		/// </summary>
		/// <param name="ppADOConnection">
		/// An ADO connection object. Contains preset connection properties that will be displayed in the Data Link Properties window.
		/// </param>
		/// <returns>A Boolean value. True if user pressed <c>OK</c> in the Data Link Properties window; False if <c>Cancel</c> was pressed.</returns>
		// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/ms709747(v=vs.85)
		[return: MarshalAs(UnmanagedType.Bool)]
		bool PromptEdit([MarshalAs(UnmanagedType.IDispatch)] ref object? ppADOConnection);
	}

	/// <summary>
	/// <para>
	/// The <c>IDBPromptInitialize</c> interface allows the display of the data link dialog boxes programmatically. Using the data link user
	/// interface, users can build a connection string dynamically or select an existing data link (.udl) file.
	/// </para>
	/// <para>
	/// A data source object can then be obtained based on the resulting connection string or .udl file name using the IDataInitialize interface.
	/// </para>
	/// <para>For more information, see Creating Data Source Objects.</para>
	/// </summary>
	// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/ms723046(v=vs.85)
	[PInvokeData("msdasc.h")]
	[ComImport, Guid("2206CCB0-19C1-11D1-89E0-00C04FD7A829"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown), CoClass(typeof(DataLinks))]
	public interface IDBPromptInitialize
	{
		/// <summary>
		/// Opens the <c>Data Link Properties</c> dialog box. Returns an uninitialized data source object with the specified properties set.
		/// </summary>
		/// <param name="pUnkOuter">
		/// A pointer to the controlling <c>IUnknown</c> interface if the data source object is being created as a part of an aggregate;
		/// otherwise, it is a null pointer.
		/// </param>
		/// <param name="hWndParent">
		/// The parent window handle for dialog boxes to be displayed. The dialog box will always be centered within this window.
		/// </param>
		/// <param name="dwPromptOptions">
		/// <para>Specifies whether to prompt with the <c>Create New Data Link</c> wizard or the <c>Data Link Properties</c> dialog box.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Value</description>
		/// <description>Meaning</description>
		/// </listheader>
		/// <item>
		/// <description>DBPROMPTOPTIONS_DISABLE_PROVIDER_SELECTION</description>
		/// <description>
		/// Do not prompt for provider selection. Valid only if <c>*ppDataSource</c> is a pointer to an existing data source object. Setting
		/// this flag without specifying a valid data source object in <c>ppDataSource</c> on input returns the error E_INVALIDARG.
		/// </description>
		/// </item>
		/// <item>
		/// <description>DBPROMPTOPTIONS_DISABLESAVEPASSWORD</description>
		/// <description>
		/// Disables the "Allow Saving password" checkbox. When set, the value of the property DBPROP_AUTH_PERSIST_SENSITIVE_AUTHINFO is set
		/// to VARIANT_FALSE on the provider.
		/// </description>
		/// </item>
		/// <item>
		/// <description>DBPROMPTOPTIONS_PROPERTYSHEET</description>
		/// <description>Prompt with <c>Data Link Properties</c> dialog box.</description>
		/// </item>
		/// <item>
		/// <description>DBPROMPTOPTIONS_WIZARDSHEET</description>
		/// <description>Deprecated. Retained for backward compatibility only.</description>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="cSourceTypeFilter">
		/// Number of DBSOURCETYPE values in rgSourceTypeFilter. If cSourceTypeFilter is zero, the value of rgSourceTypeFilter is ignored and
		/// the <c>Provider</c> selection tab will list standard tabular OLE DB providers.
		/// </param>
		/// <param name="rgSourceTypeFilter">
		/// <para>
		/// Types of providers to display in the <c>Provider</c> selection tab. Must point to a valid array of DBSOURCETYPE values. Valid
		/// source types include the values described in the following table.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <description>Value</description>
		/// <description>Meaning</description>
		/// </listheader>
		/// <item>
		/// <description>DBSOURCETYPE_DATASOURCE_TDP</description>
		/// <description>OLE DB tabular data provider</description>
		/// </item>
		/// <item>
		/// <description>DBSOURCETYPE_DATASOURCE_MDP</description>
		/// <description>OLE DB multidimensional data provider</description>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="pwszszzProviderFilter">
		/// <para>A double null-terminated string of ProgIDs.</para>
		/// <para>
		/// This parameter must be a null pointer or must point to a valid string. If it is non-null, the providers presented to the user
		/// will be limited to those that match the providers' ProgIDs specified in pwszszzProviderFilter. If only one provider is specified,
		/// the dialog is created with the connection tab displayed. If more than one provider is specified, the provider selection tab is
		/// displayed first.
		/// </para>
		/// <para>
		/// Providers specified in pwszszzProviderFilter that are not registered on the machine are ignored. If none of the providers are
		/// registered, an error is returned.
		/// </para>
		/// </param>
		/// <param name="riid">The requested interface for the data link returned in *ppDataSource.</param>
		/// <param name="ppDataSource">
		/// <para>A pointer to a data source object.</para>
		/// <para>
		/// If *ppDataSource is null on entry, <c>IDBPromptInitialize::PromptDataSource</c> generates a new data source object based on the
		/// information specified by the user and returns a pointer to that data source object in *ppDataSource.
		/// </para>
		/// <para>
		/// If *ppDataSource is non-null on entry, <c>IDBPromptInitialize::PromptDataSource</c> uses the properties returned by
		/// <c>IProperties::GetProperties</c> as initial values. If the user selects a different provider, <c>PromptDataSource</c> will
		/// release the original *ppDataSource and create a new data source object. On exit, *ppDataSource will be set to a pointer to the
		/// interface specified by riid. If the user selects the same provider but requests a different interface by supplying a different
		/// value for riid, the output value of *ppDataSource will be a pointer to the required interface on the existing data source object.
		/// </para>
		/// <para>
		/// If *ppDataSource is non-null on entry and the call returns an error, *ppDataSource is untouched. The caller is strongly advised
		/// to check the return value when calling <c>IDBPromptInitialize::PromptDataSource</c> on an existing data source object.
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
		/// <para>DB_E_CANCELED The user canceled the dialog.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>E_NOINTERFACE The data source object did not support the interface specified in riid.</para>
		/// <para>riid was IID_NULL.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>DB_E_NOAGGREGATION pUnkOuter was not a null pointer, and riid was something other than <c>IID_IUnknown</c>.</para>
		/// <para>pUnkOuter was not a null pointer, and the provider does not support aggregation.</para>
		/// <para>pUnkOuter and *ppDataSource were both non-null.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>E_INVALIDARG ppDataSource was a null pointer.</para>
		/// <para>cSourceTypeFilter was not zero, and rgSourceTypeFilter was a null pointer.</para>
		/// <para>An element in rgSourceTypeFilter was not a valid filter.</para>
		/// <para>dwPromptOptions was an invalid value.</para>
		/// <para>*ppDataSource was a null pointer, and DBPROMPTOPTIONS_DISABLE_PROVIDER_SELECTION was specified in dwPromptOptions.</para>
		/// <para>*ppDataSource did not refer to a valid data source object.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// DB_E_NOPROVIDERSREGISTERED No OLE DB providers of the type specified in rgSourceTypeFilter and matching the filter, if any,
		/// specified in pwszszzProviderFilter were found on the machine.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>E_UNEXPECTED The data source object cannot return the requested interface because the data source object is not initialized.</para>
		/// </description>
		/// </item>
		/// </list>
		/// </returns>
		// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/ms725392(v=vs.85) HRESULT PromptDataSource( IUnknown *
		// pUnkOuter, HWND hWndParent, DBPROMPTOPTIONS dwPromptOptions, ULONG cSourceTypeFilter, DBSOURCETYPE * rgSourceTypeFilter, LPCOLESTR
		// pwszszzProviderFilter, REFIID riid, IUnknown ** ppDataSource);
		HRESULT PromptDataSource([In, Optional, MarshalAs(UnmanagedType.IUnknown)] object? pUnkOuter, HWND hWndParent, DBPROMPTOPTIONS dwPromptOptions, uint cSourceTypeFilter,
			[In, Optional, MarshalAs(UnmanagedType.LPArray)] DBSOURCETYPE[]? rgSourceTypeFilter, [In, Optional, MarshalAs(UnmanagedType.LPWStr)] string? pwszszzProviderFilter,
			in Guid riid, [In, Out, MarshalAs(UnmanagedType.IUnknown)] ref object? ppDataSource);

		/// <summary>
		/// Opens the <c>Select Data Link</c> dialog box. Allows the user to browse and organize .udl files. Returns a fully qualified path
		/// to the user-selected .udl file.
		/// </summary>
		/// <param name="hWndParent">
		/// The parent window handle for dialog boxes to be displayed. The dialog box will always be centered within this window.
		/// </param>
		/// <param name="dwPromptOptions">
		/// <para>Specifies the dialog box options.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Value</description>
		/// <description>Meaning</description>
		/// </listheader>
		/// <item>
		/// <description>DBPROMPTOPTIONS_BROWSEONLY</description>
		/// <description>Prevents the user from creating new data link files.</description>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="pwszInitialDirectory">
		/// A pointer to a string containing the initial directory for the dialog box. If NULL, the default path "&lt;Program Files\Common
		/// Files&gt;\System\OLE DB\Data Links" is used. The exact value for &lt;Program Files\Common Files&gt; is system dependent. It can
		/// be determined from the "CommonFilesDir" registry entry, at "HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion".
		/// </param>
		/// <param name="pwszInitialFile">
		/// A pointer to a string containing the initial file for the file name edit box of the dialog box. Wildcard characters ("*", "?")
		/// may be used to form a filtering expression.
		/// </param>
		/// <param name="ppwszSelectedFile">
		/// *ppwszSelectedFile points to a string containing the full path to the file the user selected. ppwszSelectedFile cannot be null.
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
		/// <para>DB_E_CANCELED The user canceled the dialog.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>E_INVALIDARG ppwszSelectedFile was a null pointer.</para>
		/// <para>dwPromptOptions was an invalid value.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>STG_E_FILENOTFOUND pwszInitialFile could not be located. The file name may be too long or contain invalid characters.</para>
		/// </description>
		/// </item>
		/// </list>
		/// </returns>
		// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/ms722600(v=vs.85) HRESULT PromptFileName( HWND hWndParent,
		// DBPROMPTOPTIONS dwPromptOptions, LPCOLESTR pwszInitialDirectory, LPCOLESTR pwszInitialFile, LPCOLESTR * ppwszSelectedFile);
		HRESULT PromptFileName(HWND hWndParent, DBPROMPTOPTIONS dwPromptOptions, [In, Optional, MarshalAs(UnmanagedType.LPWStr)] string? pwszInitialDirectory,
			[In, MarshalAs(UnmanagedType.LPWStr)] string pwszInitialFile, [MarshalAs(UnmanagedType.LPWStr)] out string ppwszSelectedFile);
	}

	/// <summary/>
	[PInvokeData("msdasc.h")]
	[ComImport, Guid("06210E88-01F5-11D1-B512-0080C781C384"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IService
	{
		/// <summary/>
		/// <param name="pUnkInner"/>
		/// <returns/>
		[PreserveSig]
		HRESULT InvokeService([In, MarshalAs(UnmanagedType.IUnknown)] object pUnkInner);
	}

	/// <summary>Creates a data source object; analogous to <c>CoCreateInstance</c>.</summary>
	/// <typeparam name="T">The interface type to create.</typeparam>
	/// <param name="dataInit">The <see cref="IDataInitialize"/> instance.</param>
	/// <param name="clsidProvider">The CLSID of the provider to instantiate.</param>
	/// <returns>The interface pointer on the newly created data source.</returns>
	// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/ms723098(v=vs.85) HRESULT CreateDBInstance( REFCLSID
	// clsidProvider, IUnknown * pUnkOuter, DWORD dwClsCtx, LPOLESTR pwszReserved, REFIID riid, IUnknown ** ppDataSource);
	public static T CreateDBInstance<T>(this IDataInitialize dataInit, in Guid clsidProvider) where T : class
	{
		dataInit.CreateDBInstance(clsidProvider, null, CLSCTX.CLSCTX_INPROC_SERVER, null, typeof(T).GUID, out var obj);
		return (T)obj!;
	}

	/// <summary>
	/// Opens the <c>Data Link Properties</c> dialog box. Returns an uninitialized data source object with the specified properties set.
	/// </summary>
	/// <typeparam name="T">The requested interface for the data link returned in *ppDataSource.</typeparam>
	/// <param name="pi">The <see cref="IDBPromptInitialize"/> instance.</param>
	/// <param name="hWndParent">
	/// The parent window handle for dialog boxes to be displayed. The dialog box will always be centered within this window.
	/// </param>
	/// <param name="ppDataSource">
	/// <para>A pointer to a data source object.</para>
	/// <para>
	/// If *ppDataSource is null on entry, <c>IDBPromptInitialize::PromptDataSource</c> generates a new data source object based on the
	/// information specified by the user and returns a pointer to that data source object in *ppDataSource.
	/// </para>
	/// <para>
	/// If *ppDataSource is non-null on entry, <c>IDBPromptInitialize::PromptDataSource</c> uses the properties returned by
	/// <c>IProperties::GetProperties</c> as initial values. If the user selects a different provider, <c>PromptDataSource</c> will release
	/// the original *ppDataSource and create a new data source object. On exit, *ppDataSource will be set to a pointer to the interface
	/// specified by riid. If the user selects the same provider but requests a different interface by supplying a different value for riid,
	/// the output value of *ppDataSource will be a pointer to the required interface on the existing data source object.
	/// </para>
	/// <para>
	/// If *ppDataSource is non-null on entry and the call returns an error, *ppDataSource is untouched. The caller is strongly advised to
	/// check the return value when calling <c>IDBPromptInitialize::PromptDataSource</c> on an existing data source object.
	/// </para>
	/// </param>
	/// <param name="dwPromptOptions">
	/// <para>Specifies whether to prompt with the <c>Create New Data Link</c> wizard or the <c>Data Link Properties</c> dialog box.</para>
	/// <list type="table">
	/// <listheader>
	/// <description>Value</description>
	/// <description>Meaning</description>
	/// </listheader>
	/// <item>
	/// <description>DBPROMPTOPTIONS_DISABLE_PROVIDER_SELECTION</description>
	/// <description>
	/// Do not prompt for provider selection. Valid only if <c>*ppDataSource</c> is a pointer to an existing data source object. Setting this
	/// flag without specifying a valid data source object in <c>ppDataSource</c> on input returns the error E_INVALIDARG.
	/// </description>
	/// </item>
	/// <item>
	/// <description>DBPROMPTOPTIONS_DISABLESAVEPASSWORD</description>
	/// <description>
	/// Disables the "Allow Saving password" checkbox. When set, the value of the property DBPROP_AUTH_PERSIST_SENSITIVE_AUTHINFO is set to
	/// VARIANT_FALSE on the provider.
	/// </description>
	/// </item>
	/// <item>
	/// <description>DBPROMPTOPTIONS_PROPERTYSHEET</description>
	/// <description>Prompt with <c>Data Link Properties</c> dialog box.</description>
	/// </item>
	/// <item>
	/// <description>DBPROMPTOPTIONS_WIZARDSHEET</description>
	/// <description>Deprecated. Retained for backward compatibility only.</description>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="rgSourceTypeFilter">
	/// <para>
	/// Types of providers to display in the <c>Provider</c> selection tab. Must point to a valid array of DBSOURCETYPE values. Valid source
	/// types include the values described in the following table.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <description>Value</description>
	/// <description>Meaning</description>
	/// </listheader>
	/// <item>
	/// <description>DBSOURCETYPE_DATASOURCE_TDP</description>
	/// <description>OLE DB tabular data provider</description>
	/// </item>
	/// <item>
	/// <description>DBSOURCETYPE_DATASOURCE_MDP</description>
	/// <description>OLE DB multidimensional data provider</description>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="pUnkOuter">
	/// A pointer to the controlling <c>IUnknown</c> interface if the data source object is being created as a part of an aggregate;
	/// otherwise, it is a null pointer.
	/// </param>
	/// <param name="pwszszzProviderFilter">
	/// <para>A double null-terminated string of ProgIDs.</para>
	/// <para>
	/// This parameter must be a null pointer or must point to a valid string. If it is non-null, the providers presented to the user will be
	/// limited to those that match the providers' ProgIDs specified in pwszszzProviderFilter. If only one provider is specified, the dialog
	/// is created with the connection tab displayed. If more than one provider is specified, the provider selection tab is displayed first.
	/// </para>
	/// <para>
	/// Providers specified in pwszszzProviderFilter that are not registered on the machine are ignored. If none of the providers are
	/// registered, an error is returned.
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
	/// <para>DB_E_CANCELED The user canceled the dialog.</para>
	/// </description>
	/// </item>
	/// <item>
	/// <description>
	/// <para>E_NOINTERFACE The data source object did not support the interface specified in riid.</para>
	/// <para>riid was IID_NULL.</para>
	/// </description>
	/// </item>
	/// <item>
	/// <description>
	/// <para>DB_E_NOAGGREGATION pUnkOuter was not a null pointer, and riid was something other than <c>IID_IUnknown</c>.</para>
	/// <para>pUnkOuter was not a null pointer, and the provider does not support aggregation.</para>
	/// <para>pUnkOuter and *ppDataSource were both non-null.</para>
	/// </description>
	/// </item>
	/// <item>
	/// <description>
	/// <para>E_INVALIDARG ppDataSource was a null pointer.</para>
	/// <para>cSourceTypeFilter was not zero, and rgSourceTypeFilter was a null pointer.</para>
	/// <para>An element in rgSourceTypeFilter was not a valid filter.</para>
	/// <para>dwPromptOptions was an invalid value.</para>
	/// <para>*ppDataSource was a null pointer, and DBPROMPTOPTIONS_DISABLE_PROVIDER_SELECTION was specified in dwPromptOptions.</para>
	/// <para>*ppDataSource did not refer to a valid data source object.</para>
	/// </description>
	/// </item>
	/// <item>
	/// <description>
	/// <para>
	/// DB_E_NOPROVIDERSREGISTERED No OLE DB providers of the type specified in rgSourceTypeFilter and matching the filter, if any, specified
	/// in pwszszzProviderFilter were found on the machine.
	/// </para>
	/// </description>
	/// </item>
	/// <item>
	/// <description>
	/// <para>E_UNEXPECTED The data source object cannot return the requested interface because the data source object is not initialized.</para>
	/// </description>
	/// </item>
	/// </list>
	/// </returns>
	// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/ms725392(v=vs.85) HRESULT PromptDataSource( IUnknown *
	// pUnkOuter, HWND hWndParent, DBPROMPTOPTIONS dwPromptOptions, ULONG cSourceTypeFilter, DBSOURCETYPE * rgSourceTypeFilter, LPCOLESTR
	// pwszszzProviderFilter, REFIID riid, IUnknown ** ppDataSource);
	public static HRESULT PromptDataSource<T>(this IDBPromptInitialize pi, HWND hWndParent, out T? ppDataSource,
		DBPROMPTOPTIONS dwPromptOptions = DBPROMPTOPTIONS.DBPROMPTOPTIONS_PROPERTYSHEET, [In] DBSOURCETYPE[]? rgSourceTypeFilter = null,
		object? pUnkOuter = null, string? pwszszzProviderFilter = null) where T : class
	{
		object? obj = null;
		var hr = pi.PromptDataSource(pUnkOuter, hWndParent, dwPromptOptions, (uint)(rgSourceTypeFilter?.Length ?? 0), rgSourceTypeFilter, pwszszzProviderFilter, typeof(T).GUID, ref obj);
		ppDataSource = (T?)obj;
		return hr;
	}

	/// <summary>CLSID_DataLinks</summary>
	[ComImport, Guid("2206CDB2-19C1-11D1-89E0-00C04FD7A829"), ClassInterface(ClassInterfaceType.None)]
	public class DataLinks { }

	/// <summary>CLSID_MSDAINITIALIZE</summary>
	[ComImport, Guid("2206CDB0-19C1-11D1-89E0-00C04FD7A829"), ClassInterface(ClassInterfaceType.None)]
	public class MSDAINITIALIZE { }

	/// <summary>CLSID_OLEDB_ENUMERATOR</summary>
	[ComImport, Guid("C8B522D0-5CF3-11CE-ADE5-00AA0044773D"), ClassInterface(ClassInterfaceType.None)]
	public class OleDbRootEnumerator { }

	/// <summary>CLSID_PDPO</summary>
	[ComImport, Guid("CCB4EC60-B9DC-11D1-AC80-00A0C9034873"), ClassInterface(ClassInterfaceType.None)]
	public class PDPO { }

	/// <summary>CLSID_RootBinder</summary>
	[ComImport, Guid("FF151822-B0BF-11D1-A80D-000000000000"), ClassInterface(ClassInterfaceType.None)]
	public class RootBinder { }
}