![Vanara](https://raw.githubusercontent.com/dahall/Vanara/master/docs/icons/VanaraHeading.png)
### **Vanara.PInvoke.Odbc32 NuGet Package**
[![Version](https://img.shields.io/nuget/v/Vanara.PInvoke.Odbc32?label=NuGet&style=flat-square)](https://github.com/dahall/Vanara/releases)
[![Build status](https://img.shields.io/appveyor/build/dahall/vanara?label=AppVeyor%20build&style=flat-square)](https://ci.appveyor.com/project/dahall/vanara)

PInvoke API (methods, structures and constants) imported from Windows Odbc32.dll.

### **What is Vanara?**

[Vanara](https://github.com/dahall/Vanara) is a community project that contains various .NET assemblies which have P/Invoke functions, interfaces, enums and structures from Windows libraries. Each assembly is associated with one or a few tightly related libraries.

### **Issues?**

First check if it's already fixed by trying the [AppVeyor build](https://ci.appveyor.com/nuget/vanara-prerelease).
If you're still running into problems, file an [issue](https://github.com/dahall/Vanara/issues).

### **Included in Vanara.PInvoke.Odbc32**

Functions | Enumerations | Structures
--- | --- | ---
SQLAllocHandle SQLBindCol SQLBindParameter SQLBrowseConnect SQLBulkOperations SQLCancel SQLCancelHandle SQLCloseCursor SQLColAttribute SQLColumnPrivileges SQLColumns SQLConnect SQLCopyDesc SQLDataSources SQLDescribeCol SQLDescribeParam SQLDisconnect SQLDriverConnect SQLDrivers SQLEndTran SQLExecDirect SQLExecute SQLFetch SQLFetchScroll SQLForeignKeys SQLFreeHandle SQLFreeStmt SQLGetConnectAttr SQLGetCursorName SQLGetData SQLGetDescField SQLGetDescRec SQLGetDiagField SQLGetDiagRec SQLGetEnvAttr SQLGetFunctions SQLGetInfo SQLGetStmtAttr SQLGetTypeInfo SQLMoreResults SQLNativeSql SQLNumParams SQLNumResultCols SQLParamData SQLPrepare SQLPrimaryKeys SQLProcedureColumns SQLProcedures SQLPutData SQLRowCount SQLSetConnectAttr SQLSetCursorName SQLSetDescField SQLSetDescRec SQLSetEnvAttr SQLSetPos SQLSetStmtAttr SQLSpecialColumns SQLStatistics SQLTablePrivileges SQLTables                                                           | SQL_AD SQL_AF SQL_AM SQL_API SQL_ASYNC_DBC SQL_ASYNC_NOTIFICATION SQL_AT SQL_ATTR SQL_BOOL SQL_BP SQL_BRC SQL_BS SQL_C SQL_CA SQL_CA1 SQL_CA2 SQL_CB SQL_CCB SQL_CCOL SQL_CCS SQL_CDO SQL_CL SQL_CN SQL_COLID SQL_COLUMN SQL_COMMIT SQL_CP SQL_CP_MATCH SQL_CS SQL_CT SQL_CTR SQL_CU SQL_CURSOR SQL_CV SQL_CVT SQL_DA SQL_DC SQL_DCS SQL_DD SQL_DESC SQL_DI SQL_DIAG_ID SQL_DL SQL_DRIVER SQL_DRIVER_AWARE_POOLING SQL_DS SQL_DT SQL_DTC SQL_DTR SQL_DV SQL_FCODE SQL_FD SQL_FETCH SQL_FETCH_DIRECTION SQL_FILE SQL_FN_CVT SQL_FN_NUM SQL_FN_STR SQL_FN_SYS SQL_FN_TD SQL_FN_TSI SQL_GB SQL_GD SQL_HANDLE SQL_IC SQL_IK SQL_INDEX SQL_INDEX_TYPE SQL_INFO SQL_IS SQL_ISV SQL_LCK SQL_LOCK SQL_NC SQL_NNC SQL_NULLABILITY SQL_OAC SQL_OIC SQL_OJ SQL_OSC SQL_OSCC SQL_OU SQL_OV SQL_PARC SQL_PAS SQL_POS SQL_PS SQL_QL SQL_QU SQL_RES SQL_SC SQL_SCC SQL_SCCO SQL_SCOPE SQL_SDF SQL_SFKD SQL_SFKU SQL_SG SQL_SNVF SQL_SO SQL_SP SQL_SQ SQL_SR SQL_SRJO SQL_SRVC SQL_SS SQL_SSF SQL_STMT SQL_SU SQL_SVE SQL_TC SQL_TXN SQL_TYPE SQL_U SQL_US SQLBulkOperation SQLINTERVAL SQLRETURN  | SQLHDBC SQLHDESC SQLHENV SQLHSTMT DATE_STRUCT SQL_DAY_SECOND SQL_INTERVAL_STRUCT SQL_NUMERIC_STRUCT SQL_YEAR_MONTH TIME_STRUCT TIMESTAMP_STRUCT INTVAL                                                                                                           
