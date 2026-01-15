#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;

namespace Vanara.PInvoke;

/// <summary>Items from the OleDb.dll.</summary>
public static partial class OleDb
{
	public const int DB_COUNTUNAVAILABLE = -1;

	public const int DB_LOCAL_EXCLUSIVE = 0x03;

	public const int DB_LOCAL_SHARED = 0x02;

	public const int DB_REMOTE = 0x01;

	public const int DBWATCHREGION_NULL = default;

	public const DBCOUNTITEM MDAXIS_CHAPTERS = 0x00000004;

	public const DBCOUNTITEM MDAXIS_COLUMNS = 0x00000000;

	public const DBCOUNTITEM MDAXIS_PAGES = 0x00000002;

	//public static PMDAXISINFO_GETAT(MDAXISINFO[] rgAxisInfo, int iAxis) => ((MDAXISINFO*)(((BYTE*)rgAxisInfo) + iAxis * rgAxisInfo[0].cbSize));
	//#define MDAXISINFO_GETAT(rgAxisInfo, iAxis) (*PMDAXISINFO_GETAT((rgAxisInfo), (iAxis)))
	public const DBCOUNTITEM MDAXIS_ROWS = 0x00000001;

	public const DBCOUNTITEM MDAXIS_SECTIONS = 0x00000003;

	public const DBCOUNTITEM MDAXIS_SLICERS = 0xffffffff;

	public const int MDDISPINFO_DRILLED_DOWN = 0x00010000;

	public const int MDDISPINFO_PARENT_SAME_AS_PREV = 0x00020000;

	public const int MDPROP_CELL = 0x02;

	public const int MDPROP_MEMBER = 0x01;

	public const int STD_BOOKMARKLENGTH = 1;

	public static readonly IntPtr DB_INVALID_HACCESSOR = IntPtr.Zero;

	public static readonly IntPtr DB_INVALID_HCHAPTER = IntPtr.Zero;

	public static readonly nint DB_INVALIDCOLUMN = unchecked(IntPtr.Size == 8 ? (nint)long.MaxValue : int.MaxValue);

	public static readonly IntPtr DB_NULL_HACCESSOR = IntPtr.Zero;

	public static readonly IntPtr DB_NULL_HCHAPTER = IntPtr.Zero;

	// deprecated; use DB_INVALID_HACCESSOR instead
	public static readonly IntPtr DB_NULL_HROW = IntPtr.Zero;

	public static readonly Guid DB_NULLGUID = Guid.Empty;

	public static readonly DBID DB_NULLID = new(DB_NULLGUID, 0, 0);

	public static readonly Guid DBCIDGUID = new(0x0C733A81, 0x2A1C, 0x11CE, 0xAD, 0xE5, 0x00, 0xAA, 0x00, 0x44, 0x77, 0x3D);

	public static readonly Guid DBCOL_SELFCOLUMNS = new(0xc8b52231, 0x5cf3, 0x11ce, 0xad, 0xe5, 0x00, 0xaa, 0x00, 0x44, 0x77, 0x3d);

	public static readonly Guid DBCOL_SPECIALCOL = new(0xc8b52232, 0x5cf3, 0x11ce, 0xad, 0xe5, 0x00, 0xaa, 0x00, 0x44, 0x77, 0x3d);

	public static readonly DBID DBCOLUMN_BASECATALOGNAME = new(DBCIDGUID, DBKIND.DBKIND_GUID_PROPID, 23);

	public static readonly DBID DBCOLUMN_BASECOLUMNNAME = new(DBCIDGUID, DBKIND.DBKIND_GUID_PROPID, 10);

	public static readonly DBID DBCOLUMN_BASESCHEMANAME = new(DBCIDGUID, DBKIND.DBKIND_GUID_PROPID, 24);

	public static readonly DBID DBCOLUMN_BASETABLENAME = new(DBCIDGUID, DBKIND.DBKIND_GUID_PROPID, 11);

	public static readonly DBID DBCOLUMN_CLSID = new(DBCIDGUID, DBKIND.DBKIND_GUID_PROPID, 38);

	public static readonly DBID DBCOLUMN_COLLATINGSEQUENCE = new(DBCIDGUID, DBKIND.DBKIND_GUID_PROPID, 12);

	public static readonly DBID DBCOLUMN_COLUMNSIZE = new(DBCIDGUID, DBKIND.DBKIND_GUID_PROPID, 37);

	public static readonly DBID DBCOLUMN_COMPUTEMODE = new(DBCIDGUID, DBKIND.DBKIND_GUID_PROPID, 13);

	public static readonly DBID DBCOLUMN_DATETIMEPRECISION = new(DBCIDGUID, DBKIND.DBKIND_GUID_PROPID, 34);

	public static readonly DBID DBCOLUMN_DEFAULTVALUE = new(DBCIDGUID, DBKIND.DBKIND_GUID_PROPID, 14);

	public static readonly DBID DBCOLUMN_DERIVEDCOLUMNNAME = new(DBCIDGUID, DBKIND.DBKIND_GUID_PROPID, 43);

	public static readonly DBID DBCOLUMN_DOMAINCATALOG = new(DBCIDGUID, DBKIND.DBKIND_GUID_PROPID, 32);

	public static readonly DBID DBCOLUMN_DOMAINNAME = new(DBCIDGUID, DBKIND.DBKIND_GUID_PROPID, 15);

	public static readonly DBID DBCOLUMN_DOMAINSCHEMA = new(DBCIDGUID, DBKIND.DBKIND_GUID_PROPID, 33);

	public static readonly DBID DBCOLUMN_FLAGS = new(DBCIDGUID, DBKIND.DBKIND_GUID_PROPID, 9);

	public static readonly DBID DBCOLUMN_GUID = new(DBCIDGUID, DBKIND.DBKIND_GUID_PROPID, 29);

	public static readonly DBID DBCOLUMN_HASDEFAULT = new(DBCIDGUID, DBKIND.DBKIND_GUID_PROPID, 16);

	public static readonly DBID DBCOLUMN_IDNAME = new(DBCIDGUID, DBKIND.DBKIND_GUID_PROPID, 2);

	public static readonly DBID DBCOLUMN_ISAUTOINCREMENT = new(DBCIDGUID, DBKIND.DBKIND_GUID_PROPID, 17);

	public static readonly DBID DBCOLUMN_ISCASESENSITIVE = new(DBCIDGUID, DBKIND.DBKIND_GUID_PROPID, 18);

	public static readonly DBID DBCOLUMN_ISSEARCHABLE = new(DBCIDGUID, DBKIND.DBKIND_GUID_PROPID, 20);

	public static readonly DBID DBCOLUMN_ISUNIQUE = new(DBCIDGUID, DBKIND.DBKIND_GUID_PROPID, 21);

	public static readonly DBID DBCOLUMN_MAYSORT = new(DBCIDGUID, DBKIND.DBKIND_GUID_PROPID, 39);

	public static readonly DBID DBCOLUMN_NAME = new(DBCIDGUID, DBKIND.DBKIND_GUID_PROPID, 3);

	public static readonly DBID DBCOLUMN_NUMBER = new(DBCIDGUID, DBKIND.DBKIND_GUID_PROPID, 4);

	public static readonly DBID DBCOLUMN_NUMERICPRECISIONRADIX = new(DBCIDGUID, DBKIND.DBKIND_GUID_PROPID, 35);

	public static readonly DBID DBCOLUMN_OCTETLENGTH = new(DBCIDGUID, DBKIND.DBKIND_GUID_PROPID, 36);

	public static readonly DBID DBCOLUMN_PRECISION = new(DBCIDGUID, DBKIND.DBKIND_GUID_PROPID, 7);

	public static readonly DBID DBCOLUMN_PROPID = new(DBCIDGUID, DBKIND.DBKIND_GUID_PROPID, 30);

	public static readonly DBID DBCOLUMN_SCALE = new(DBCIDGUID, DBKIND.DBKIND_GUID_PROPID, 8);

	public static readonly DBID DBCOLUMN_TYPE = new(DBCIDGUID, DBKIND.DBKIND_GUID_PROPID, 5);

	public static readonly DBID DBCOLUMN_TYPEINFO = new(DBCIDGUID, DBKIND.DBKIND_GUID_PROPID, 31);

	public static readonly Guid DBGUID_COMMAND = new(0xc8b522f8, 0x5cf3, 0x11ce, 0xad, 0xe5, 0x00, 0xaa, 0x00, 0x44, 0x77, 0x3d);

	public static readonly Guid DBGUID_CONTAINEROBJECT = new(0xc8b522fb, 0x5cf3, 0x11ce, 0xad, 0xe5, 0x00, 0xaa, 0x00, 0x44, 0x77, 0x3d);

	public static readonly Guid DBGUID_DBSQL = new(0xc8b521fb, 0x5cf3, 0x11ce, 0xad, 0xe5, 0x00, 0xaa, 0x00, 0x44, 0x77, 0x3d);

	public static readonly Guid DBGUID_DEFAULT = new(0xc8b521fb, 0x5cf3, 0x11ce, 0xad, 0xe5, 0x00, 0xaa, 0x00, 0x44, 0x77, 0x3d);

	public static readonly Guid DBGUID_DSO = new(0xc8b522f4, 0x5cf3, 0x11ce, 0xad, 0xe5, 0x00, 0xaa, 0x00, 0x44, 0x77, 0x3d);

	public static readonly Guid DBGUID_HISTOGRAM_ROWSET = new(0xc8b52300, 0x5cf3, 0x11ce, 0xad, 0xe5, 0x00, 0xaa, 0x00, 0x44, 0x77, 0x3d);

	public static readonly Guid DBGUID_MDX = new(0xa07cccd0, 0x8148, 0x11d0, 0x87, 0xbb, 0x00, 0xc0, 0x4f, 0xc3, 0x39, 0x42);

	public static readonly Guid DBGUID_ROW = new(0xc8b522f7, 0x5cf3, 0x11ce, 0xad, 0xe5, 0x00, 0xaa, 0x00, 0x44, 0x77, 0x3d);

	public static readonly Guid DBGUID_ROWDEFAULTSTREAM = new(0x0C733AB7, 0x2A1C, 0x11CE, 0xAD, 0xE5, 0x00, 0xAA, 0x00, 0x44, 0x77, 0x3D);

	public static readonly Guid DBGUID_ROWSET = new(0xc8b522f6, 0x5cf3, 0x11ce, 0xad, 0xe5, 0x00, 0xaa, 0x00, 0x44, 0x77, 0x3d);

	public static readonly Guid DBGUID_ROWURL = new(0x0C733AB6, 0x2A1C, 0x11CE, 0xAD, 0xE5, 0x00, 0xAA, 0x00, 0x44, 0x77, 0x3D);

	public static readonly Guid DBGUID_SESSION = new(0xc8b522f5, 0x5cf3, 0x11ce, 0xad, 0xe5, 0x00, 0xaa, 0x00, 0x44, 0x77, 0x3d);

	public static readonly Guid DBGUID_SQL = new(0xc8b522d7, 0x5cf3, 0x11ce, 0xad, 0xe5, 0x00, 0xaa, 0x00, 0x44, 0x77, 0x3d);

	public static readonly Guid DBGUID_STREAM = new(0xc8b522f9, 0x5cf3, 0x11ce, 0xad, 0xe5, 0x00, 0xaa, 0x00, 0x44, 0x77, 0x3d);

	public static readonly Guid DBOBJECT_CHARACTERSET = new(0xc8b522ed, 0x5cf3, 0x11ce, 0xad, 0xe5, 0x00, 0xaa, 0x00, 0x44, 0x77, 0x3d);

	public static readonly Guid DBOBJECT_COLLATION = new(0xc8b522ea, 0x5cf3, 0x11ce, 0xad, 0xe5, 0x00, 0xaa, 0x00, 0x44, 0x77, 0x3d);

	public static readonly Guid DBOBJECT_COLUMN = new(0xc8b522e4, 0x5cf3, 0x11ce, 0xad, 0xe5, 0x00, 0xaa, 0x00, 0x44, 0x77, 0x3d);

	public static readonly Guid DBOBJECT_DATABASE = new(0xc8b522e5, 0x5cf3, 0x11ce, 0xad, 0xe5, 0x00, 0xaa, 0x00, 0x44, 0x77, 0x3d);

	public static readonly Guid DBOBJECT_DOMAIN = new(0xc8b522e9, 0x5cf3, 0x11ce, 0xad, 0xe5, 0x00, 0xaa, 0x00, 0x44, 0x77, 0x3d);

	public static readonly Guid DBOBJECT_PROCEDURE = new(0xc8b522e6, 0x5cf3, 0x11ce, 0xad, 0xe5, 0x00, 0xaa, 0x00, 0x44, 0x77, 0x3d);

	public static readonly Guid DBOBJECT_SCHEMA = new(0xc8b522e8, 0x5cf3, 0x11ce, 0xad, 0xe5, 0x00, 0xaa, 0x00, 0x44, 0x77, 0x3d);

	public static readonly Guid DBOBJECT_SCHEMAROWSET = new(0xc8b522ec, 0x5cf3, 0x11ce, 0xad, 0xe5, 0x00, 0xaa, 0x00, 0x44, 0x77, 0x3d);

	public static readonly Guid DBOBJECT_TABLE = new(0xc8b522e2, 0x5cf3, 0x11ce, 0xad, 0xe5, 0x00, 0xaa, 0x00, 0x44, 0x77, 0x3d);

	public static readonly Guid DBOBJECT_TRANSLATION = new(0xc8b522ee, 0x5cf3, 0x11ce, 0xad, 0xe5, 0x00, 0xaa, 0x00, 0x44, 0x77, 0x3d);

	public static readonly Guid DBOBJECT_TRUSTEE = new(0xc8b522eb, 0x5cf3, 0x11ce, 0xad, 0xe5, 0x00, 0xaa, 0x00, 0x44, 0x77, 0x3d);

	public static readonly Guid DBOBJECT_VIEW = new(0xc8b522e7, 0x5cf3, 0x11ce, 0xad, 0xe5, 0x00, 0xaa, 0x00, 0x44, 0x77, 0x3d);

	/// <summary>Properties used to create and describe columns.</summary>
	public static readonly Guid DBPROPSET_COLUMN = new(0xc8b522b9, 0x5cf3, 0x11ce, 0xad, 0xe5, 0x00, 0xaa, 0x00, 0x44, 0x77, 0x3d);

	/// <summary>Returns all properties in the Column property group, including provider-specific properties.</summary>
	public static readonly Guid DBPROPSET_COLUMNALL = new(0xc8b522f0, 0x5cf3, 0x11ce, 0xad, 0xe5, 0x00, 0xaa, 0x00, 0x44, 0x77, 0x3d);

	/// <summary>Returns all properties in the Constraint property group, including provider-specific properties.</summary>
	public static readonly Guid DBPROPSET_CONSTRAINTALL = new(0xc8b522fa, 0x5cf3, 0x11ce, 0xad, 0xe5, 0x00, 0xaa, 0x00, 0x44, 0x77, 0x3d);

	/// <summary>Properties that apply to data source objects. These properties can be set for some providers.</summary>
	public static readonly Guid DBPROPSET_DATASOURCE = new(0xc8b522ba, 0x5cf3, 0x11ce, 0xad, 0xe5, 0x00, 0xaa, 0x00, 0x44, 0x77, 0x3d);

	/// <summary>Returns all properties in the Data Source property group, including provider-specific properties.</summary>
	public static readonly Guid DBPROPSET_DATASOURCEALL = new(0xc8b522c0, 0x5cf3, 0x11ce, 0xad, 0xe5, 0x00, 0xaa, 0x00, 0x44, 0x77, 0x3d);

	/// <summary>
	/// Properties that describe data source objects. These properties are read-only for all providers and constitute a set of static
	/// information about the provider and data source object.
	/// </summary>
	public static readonly Guid DBPROPSET_DATASOURCEINFO = new(0xc8b522bb, 0x5cf3, 0x11ce, 0xad, 0xe5, 0x00, 0xaa, 0x00, 0x44, 0x77, 0x3d);

	/// <summary>Returns all properties in the Data Source Information property group, including provider-specific properties.</summary>
	public static readonly Guid DBPROPSET_DATASOURCEINFOALL = new(0xc8b522c1, 0x5cf3, 0x11ce, 0xad, 0xe5, 0x00, 0xaa, 0x00, 0x44, 0x77, 0x3d);

	/// <summary>Properties used to initialize the data source object or enumerator.</summary>
	public static readonly Guid DBPROPSET_DBINIT = new(0xc8b522bc, 0x5cf3, 0x11ce, 0xad, 0xe5, 0x00, 0xaa, 0x00, 0x44, 0x77, 0x3d);

	/// <summary>Returns all properties in the Initialization property group, including provider-specific properties.</summary>
	public static readonly Guid DBPROPSET_DBINITALL = new(0xc8b522ca, 0x5cf3, 0x11ce, 0xad, 0xe5, 0x00, 0xaa, 0x00, 0x44, 0x77, 0x3d);

	/// <summary>Properties used to create and describe indexes.</summary>
	public static readonly Guid DBPROPSET_INDEX = new(0xc8b522bd, 0x5cf3, 0x11ce, 0xad, 0xe5, 0x00, 0xaa, 0x00, 0x44, 0x77, 0x3d);

	/// <summary>Returns all properties in the Index property group, including provider-specific properties.</summary>
	public static readonly Guid DBPROPSET_INDEXALL = new(0xc8b522f1, 0x5cf3, 0x11ce, 0xad, 0xe5, 0x00, 0xaa, 0x00, 0x44, 0x77, 0x3d);

	/// <summary>
	/// <para>
	/// If ICommand::Execute, ICommandPrepare::Prepare, IDBInitialize::Initialize, IBindResource::Bind, or ICreateRow::CreateRow returns
	/// DB_S_ERRORSOCCURRED or DB_E_ERRORSOCCURRED, the consumer can immediately call ICommandProperties::GetProperties or
	/// IDBProperties::GetProperties with a single DBPROPIDSET structure to return all the properties that were in error. This property set
	/// is not returned by IDBProperties::GetPropertyInfo.
	/// </para>
	/// <para>
	/// In the DBPROPIDSET structure, the consumer sets guidPropertySet to DBPROPSET_PROPERTIESINERROR, cPropertyIDs to 0, and rgPropertyIDs
	/// to a null pointer. If the consumer fails to set any of these correctly, GetProperties returns E_INVALIDARG.
	/// </para>
	/// <para>
	/// It is an error to pass this property set to any method that sets properties. The method returns the same error it would for any other
	/// unsupported property set. Methods that return information about properties do not return information about this property set. If any
	/// other property sets are passed to GetProperties with this property set, GetProperties returns E_INVALIDARG. Calling GetProperties
	/// with DBPROPSET_PROPERTIESINERROR at a time other than immediately after the call that returns DB_S_ERRORSOCCURRED or
	/// DB_E_ERRORSOCCURRED might yield inconsistent results, because the consumer's actions might have caused the provider to clear or alter
	/// the list of properties in error.
	/// </para>
	/// </summary>
	public static readonly Guid DBPROPSET_PROPERTIESINERROR = new(0xc8b522d4, 0x5cf3, 0x11ce, 0xad, 0xe5, 0x00, 0xaa, 0x00, 0x44, 0x77, 0x3d);

	/// <summary>Properties that apply to rowsets.</summary>
	public static readonly Guid DBPROPSET_ROWSET = new(0xc8b522be, 0x5cf3, 0x11ce, 0xad, 0xe5, 0x00, 0xaa, 0x00, 0x44, 0x77, 0x3d);

	/// <summary>Returns all properties in the Rowset property group, including provider-specific properties.</summary>
	public static readonly Guid DBPROPSET_ROWSETALL = new(0xc8b522c2, 0x5cf3, 0x11ce, 0xad, 0xe5, 0x00, 0xaa, 0x00, 0x44, 0x77, 0x3d);

	/// <summary>Properties that apply to sessions.</summary>
	public static readonly Guid DBPROPSET_SESSION = new(0xc8b522c6, 0x5cf3, 0x11ce, 0xad, 0xe5, 0x00, 0xaa, 0x00, 0x44, 0x77, 0x3d);

	/// <summary>Returns all properties in the Session property group, including provider-specific properties.</summary>
	public static readonly Guid DBPROPSET_SESSIONALL = new(0xc8b522c7, 0x5cf3, 0x11ce, 0xad, 0xe5, 0x00, 0xaa, 0x00, 0x44, 0x77, 0x3d);

	/// <summary>Properties that apply to streams.</summary>
	public static readonly Guid DBPROPSET_STREAM = new(0xc8b522fd, 0x5cf3, 0x11ce, 0xad, 0xe5, 0x00, 0xaa, 0x00, 0x44, 0x77, 0x3d);

	/// <summary>Returns all properties of the Stream property group, including provider-specific properties.</summary>
	public static readonly Guid DBPROPSET_STREAMALL = new(0xc8b522fe, 0x5cf3, 0x11ce, 0xad, 0xe5, 0x00, 0xaa, 0x00, 0x44, 0x77, 0x3d);

	/// <summary>Properties used to create and describe tables.</summary>
	public static readonly Guid DBPROPSET_TABLE = new(0xc8b522bf, 0x5cf3, 0x11ce, 0xad, 0xe5, 0x00, 0xaa, 0x00, 0x44, 0x77, 0x3d);

	/// <summary>Returns all properties in the Table property group, including provider-specific properties.</summary>
	public static readonly Guid DBPROPSET_TABLEALL = new(0xc8b522f2, 0x5cf3, 0x11ce, 0xad, 0xe5, 0x00, 0xaa, 0x00, 0x44, 0x77, 0x3d);

	public static readonly Guid DBPROPSET_TRUSTEE = new(0xc8b522e1, 0x5cf3, 0x11ce, 0xad, 0xe5, 0x00, 0xaa, 0x00, 0x44, 0x77, 0x3d);

	/// <summary>Returns all properties in the Trustee property group, including provider-specific properties.</summary>
	public static readonly Guid DBPROPSET_TRUSTEEALL = new(0xc8b522f3, 0x5cf3, 0x11ce, 0xad, 0xe5, 0x00, 0xaa, 0x00, 0x44, 0x77, 0x3d);

	/// <summary>Properties used to create views.</summary>
	public static readonly Guid DBPROPSET_VIEW = new(0xc8b522df, 0x5cf3, 0x11ce, 0xad, 0xe5, 0x00, 0xaa, 0x00, 0x44, 0x77, 0x3d);

	/// <summary>Returns all properties in the View property group, including provider-specific properties.</summary>
	public static readonly Guid DBPROPSET_VIEWALL = new(0xc8b522fc, 0x5cf3, 0x11ce, 0xad, 0xe5, 0x00, 0xaa, 0x00, 0x44, 0x77, 0x3d);

	public static readonly Guid DBSCHEMA_ASSERTIONS = new(0xc8b52210, 0x5cf3, 0x11ce, 0xad, 0xe5, 0x00, 0xaa, 0x00, 0x44, 0x77, 0x3d);

	public static readonly Guid DBSCHEMA_CATALOGS = new(0xc8b52211, 0x5cf3, 0x11ce, 0xad, 0xe5, 0x00, 0xaa, 0x00, 0x44, 0x77, 0x3d);

	public static readonly Guid DBSCHEMA_CHARACTER_SETS = new(0xc8b52212, 0x5cf3, 0x11ce, 0xad, 0xe5, 0x00, 0xaa, 0x00, 0x44, 0x77, 0x3d);

	public static readonly Guid DBSCHEMA_CHECK_CONSTRAINTS = new(0xc8b52215, 0x5cf3, 0x11ce, 0xad, 0xe5, 0x00, 0xaa, 0x00, 0x44, 0x77, 0x3d);

	public static readonly Guid DBSCHEMA_CHECK_CONSTRAINTS_BY_TABLE = new(0xc8b52301, 0x5cf3, 0x11ce, 0xad, 0xe5, 0x00, 0xaa, 0x00, 0x44, 0x77, 0x3d);

	public static readonly Guid DBSCHEMA_COLLATIONS = new(0xc8b52213, 0x5cf3, 0x11ce, 0xad, 0xe5, 0x00, 0xaa, 0x00, 0x44, 0x77, 0x3d);

	public static readonly Guid DBSCHEMA_COLUMN_DOMAIN_USAGE = new(0xc8b5221b, 0x5cf3, 0x11ce, 0xad, 0xe5, 0x00, 0xaa, 0x00, 0x44, 0x77, 0x3d);

	public static readonly Guid DBSCHEMA_COLUMN_PRIVILEGES = new(0xc8b52221, 0x5cf3, 0x11ce, 0xad, 0xe5, 0x00, 0xaa, 0x00, 0x44, 0x77, 0x3d);

	public static readonly Guid DBSCHEMA_COLUMNS = new(0xc8b52214, 0x5cf3, 0x11ce, 0xad, 0xe5, 0x00, 0xaa, 0x00, 0x44, 0x77, 0x3d);

	public static readonly Guid DBSCHEMA_CONSTRAINT_COLUMN_USAGE = new(0xc8b52216, 0x5cf3, 0x11ce, 0xad, 0xe5, 0x00, 0xaa, 0x00, 0x44, 0x77, 0x3d);

	public static readonly Guid DBSCHEMA_CONSTRAINT_TABLE_USAGE = new(0xc8b52217, 0x5cf3, 0x11ce, 0xad, 0xe5, 0x00, 0xaa, 0x00, 0x44, 0x77, 0x3d);

	public static readonly Guid DBSCHEMA_FOREIGN_KEYS = new(0xc8b522c4, 0x5cf3, 0x11ce, 0xad, 0xe5, 0x00, 0xaa, 0x00, 0x44, 0x77, 0x3d);

	public static readonly Guid DBSCHEMA_INDEXES = new(0xc8b5221e, 0x5cf3, 0x11ce, 0xad, 0xe5, 0x00, 0xaa, 0x00, 0x44, 0x77, 0x3d);

	public static readonly Guid DBSCHEMA_KEY_COLUMN_USAGE = new(0xc8b52218, 0x5cf3, 0x11ce, 0xad, 0xe5, 0x00, 0xaa, 0x00, 0x44, 0x77, 0x3d);

	public static readonly Guid DBSCHEMA_PRIMARY_KEYS = new(0xc8b522c5, 0x5cf3, 0x11ce, 0xad, 0xe5, 0x00, 0xaa, 0x00, 0x44, 0x77, 0x3d);

	public static readonly Guid DBSCHEMA_PROCEDURE_COLUMNS = new(0xc8b522c9, 0x5cf3, 0x11ce, 0xad, 0xe5, 0x00, 0xaa, 0x00, 0x44, 0x77, 0x3d);

	public static readonly Guid DBSCHEMA_PROCEDURE_PARAMETERS = new(0xc8b522b8, 0x5cf3, 0x11ce, 0xad, 0xe5, 0x00, 0xaa, 0x00, 0x44, 0x77, 0x3d);

	public static readonly Guid DBSCHEMA_PROCEDURES = new(0xc8b52224, 0x5cf3, 0x11ce, 0xad, 0xe5, 0x00, 0xaa, 0x00, 0x44, 0x77, 0x3d);

	public static readonly Guid DBSCHEMA_PROVIDER_TYPES = new(0xc8b5222c, 0x5cf3, 0x11ce, 0xad, 0xe5, 0x00, 0xaa, 0x00, 0x44, 0x77, 0x3d);

	public static readonly Guid DBSCHEMA_REFERENTIAL_CONSTRAINTS = new(0xc8b52219, 0x5cf3, 0x11ce, 0xad, 0xe5, 0x00, 0xaa, 0x00, 0x44, 0x77, 0x3d);

	public static readonly Guid DBSCHEMA_SCHEMATA = new(0xc8b52225, 0x5cf3, 0x11ce, 0xad, 0xe5, 0x00, 0xaa, 0x00, 0x44, 0x77, 0x3d);

	public static readonly Guid DBSCHEMA_SQL_LANGUAGES = new(0xc8b52226, 0x5cf3, 0x11ce, 0xad, 0xe5, 0x00, 0xaa, 0x00, 0x44, 0x77, 0x3d);

	public static readonly Guid DBSCHEMA_STATISTICS = new(0xc8b52227, 0x5cf3, 0x11ce, 0xad, 0xe5, 0x00, 0xaa, 0x00, 0x44, 0x77, 0x3d);

	public static readonly Guid DBSCHEMA_TABLE_CONSTRAINTS = new(0xc8b5221a, 0x5cf3, 0x11ce, 0xad, 0xe5, 0x00, 0xaa, 0x00, 0x44, 0x77, 0x3d);

	public static readonly Guid DBSCHEMA_TABLE_PRIVILEGES = new(0xc8b52222, 0x5cf3, 0x11ce, 0xad, 0xe5, 0x00, 0xaa, 0x00, 0x44, 0x77, 0x3d);

	public static readonly Guid DBSCHEMA_TABLE_STATISTICS = new(0xc8b522ff, 0x5cf3, 0x11ce, 0xad, 0xe5, 0x00, 0xaa, 0x00, 0x44, 0x77, 0x3d);

	public static readonly Guid DBSCHEMA_TABLES = new(0xc8b52229, 0x5cf3, 0x11ce, 0xad, 0xe5, 0x00, 0xaa, 0x00, 0x44, 0x77, 0x3d);

	public static readonly Guid DBSCHEMA_TABLES_INFO = new(0xc8b522e0, 0x5cf3, 0x11ce, 0xad, 0xe5, 0x00, 0xaa, 0x00, 0x44, 0x77, 0x3d);

	public static readonly Guid DBSCHEMA_TRANSLATIONS = new(0xc8b5222a, 0x5cf3, 0x11ce, 0xad, 0xe5, 0x00, 0xaa, 0x00, 0x44, 0x77, 0x3d);

	public static readonly Guid DBSCHEMA_TRUSTEE = new(0xc8b522ef, 0x5cf3, 0x11ce, 0xad, 0xe5, 0x00, 0xaa, 0x00, 0x44, 0x77, 0x3d);

	public static readonly Guid DBSCHEMA_USAGE_PRIVILEGES = new(0xc8b52223, 0x5cf3, 0x11ce, 0xad, 0xe5, 0x00, 0xaa, 0x00, 0x44, 0x77, 0x3d);

	public static readonly Guid DBSCHEMA_VIEW_COLUMN_USAGE = new(0xc8b5222e, 0x5cf3, 0x11ce, 0xad, 0xe5, 0x00, 0xaa, 0x00, 0x44, 0x77, 0x3d);

	public static readonly Guid DBSCHEMA_VIEW_TABLE_USAGE = new(0xc8b5222f, 0x5cf3, 0x11ce, 0xad, 0xe5, 0x00, 0xaa, 0x00, 0x44, 0x77, 0x3d);

	public static readonly Guid DBSCHEMA_VIEWS = new(0xc8b5222d, 0x5cf3, 0x11ce, 0xad, 0xe5, 0x00, 0xaa, 0x00, 0x44, 0x77, 0x3d);

	public static readonly Guid MDGUID_MDX = new(0xa07cccd0, 0x8148, 0x11d0, 0x87, 0xbb, 0x00, 0xc0, 0x4f, 0xc3, 0x39, 0x42);

	public static readonly Guid MDSCHEMA_ACTIONS = new(0xa07ccd08, 0x8148, 0x11d0, 0x87, 0xbb, 0x00, 0xc0, 0x4f, 0xc3, 0x39, 0x42);

	public static readonly Guid MDSCHEMA_COMMANDS = new(0xa07ccd09, 0x8148, 0x11d0, 0x87, 0xbb, 0x00, 0xc0, 0x4f, 0xc3, 0x39, 0x42);

	public static readonly Guid MDSCHEMA_CUBES = new(0xc8b522d8, 0x5cf3, 0x11ce, 0xad, 0xe5, 0x00, 0xaa, 0x00, 0x44, 0x77, 0x3d);

	public static readonly Guid MDSCHEMA_DIMENSIONS = new(0xc8b522d9, 0x5cf3, 0x11ce, 0xad, 0xe5, 0x00, 0xaa, 0x00, 0x44, 0x77, 0x3d);

	public static readonly Guid MDSCHEMA_FUNCTIONS = new(0xa07ccd07, 0x8148, 0x11d0, 0x87, 0xbb, 0x00, 0xc0, 0x4f, 0xc3, 0x39, 0x42);

	public static readonly Guid MDSCHEMA_HIERARCHIES = new(0xc8b522da, 0x5cf3, 0x11ce, 0xad, 0xe5, 0x00, 0xaa, 0x00, 0x44, 0x77, 0x3d);

	public static readonly Guid MDSCHEMA_LEVELS = new(0xc8b522db, 0x5cf3, 0x11ce, 0xad, 0xe5, 0x00, 0xaa, 0x00, 0x44, 0x77, 0x3d);

	public static readonly Guid MDSCHEMA_MEASURES = new(0xc8b522dc, 0x5cf3, 0x11ce, 0xad, 0xe5, 0x00, 0xaa, 0x00, 0x44, 0x77, 0x3d);

	public static readonly Guid MDSCHEMA_MEMBERS = new(0xc8b522de, 0x5cf3, 0x11ce, 0xad, 0xe5, 0x00, 0xaa, 0x00, 0x44, 0x77, 0x3d);

	public static readonly Guid MDSCHEMA_PROPERTIES = new(0xc8b522dd, 0x5cf3, 0x11ce, 0xad, 0xe5, 0x00, 0xaa, 0x00, 0x44, 0x77, 0x3d);

	public static readonly Guid MDSCHEMA_SETS = new(0xa07ccd0b, 0x8148, 0x11d0, 0x87, 0xbb, 0x00, 0xc0, 0x4f, 0xc3, 0x39, 0x42);

	public static readonly Guid PSGUID_QUERY = new(0x49691c90, 0x7e17, 0x101a, 0xa9, 0x1c, 0x08, 0x00, 0x2b, 0x2e, 0xcd, 0xa9);

	public static DBID DBCOLUMN_BASETABLEVERSION = new(DBCIDGUID, DBKIND.DBKIND_GUID_PROPID, 40);

	public static DBID DBCOLUMN_KEYCOLUMN = new(DBCIDGUID, DBKIND.DBKIND_GUID_PROPID, 41);

	public static DBID DBROWCOL_ABSOLUTEPARSENAME = new(DBGUID_ROWURL, DBKIND.DBKIND_GUID_PROPID, 4);

	public static DBID DBROWCOL_CONTENTCLASS = new(DBGUID_ROWURL, DBKIND.DBKIND_GUID_PROPID, 8);

	public static DBID DBROWCOL_CONTENTLANGUAGE = new(DBGUID_ROWURL, DBKIND.DBKIND_GUID_PROPID, 9);

	public static DBID DBROWCOL_CONTENTTYPE = new(DBGUID_ROWURL, DBKIND.DBKIND_GUID_PROPID, 7);

	public static DBID DBROWCOL_CREATIONTIME = new(DBGUID_ROWURL, DBKIND.DBKIND_GUID_PROPID, 10);

	public static DBID DBROWCOL_DEFAULTDOCUMENT = new(DBGUID_ROWURL, DBKIND.DBKIND_GUID_PROPID, 16);

	public static DBID DBROWCOL_DEFAULTSTREAM = new(DBGUID_ROWDEFAULTSTREAM, DBKIND.DBKIND_GUID_PROPID, 0);

	public static DBID DBROWCOL_DISPLAYNAME = new(DBGUID_ROWURL, DBKIND.DBKIND_GUID_PROPID, 17);

	public static DBID DBROWCOL_ISCOLLECTION = new(DBGUID_ROWURL, DBKIND.DBKIND_GUID_PROPID, 14);

	public static DBID DBROWCOL_ISHIDDEN = new(DBGUID_ROWURL, DBKIND.DBKIND_GUID_PROPID, 5);

	public static DBID DBROWCOL_ISREADONLY = new(DBGUID_ROWURL, DBKIND.DBKIND_GUID_PROPID, 6);

	public static DBID DBROWCOL_ISROOT = new(DBGUID_ROWURL, DBKIND.DBKIND_GUID_PROPID, 18);

	public static DBID DBROWCOL_ISSTRUCTUREDDOCUMENT = new(DBGUID_ROWURL, DBKIND.DBKIND_GUID_PROPID, 15);

	public static DBID DBROWCOL_LASTACCESSTIME = new(DBGUID_ROWURL, DBKIND.DBKIND_GUID_PROPID, 11);

	public static DBID DBROWCOL_LASTWRITETIME = new(DBGUID_ROWURL, DBKIND.DBKIND_GUID_PROPID, 12);

	public static DBID DBROWCOL_PARENTNAME = new(DBGUID_ROWURL, DBKIND.DBKIND_GUID_PROPID, 3);

	public static DBID DBROWCOL_PARSENAME = new(DBGUID_ROWURL, DBKIND.DBKIND_GUID_PROPID, 2);

	public static DBID DBROWCOL_ROWURL = new(DBGUID_ROWURL, DBKIND.DBKIND_GUID_PROPID, 0);

	public static DBID DBROWCOL_STREAMSIZE = new(DBGUID_ROWURL, DBKIND.DBKIND_GUID_PROPID, 13);

	public enum BMK_DURABILITY
	{
		BMK_DURABILITY_INTRANSACTION = DBPROPVAL_BD.DBPROPVAL_BD_INTRANSACTION,
		BMK_DURABILITY_REORGANIZATION = DBPROPVAL_BD.DBPROPVAL_BD_REORGANIZATION,
		BMK_DURABILITY_ROWSET = DBPROPVAL_BD.DBPROPVAL_BD_ROWSET,
		BMK_DURABILITY_XTRANSACTION = DBPROPVAL_BD.DBPROPVAL_BD_XTRANSACTION,
	}

	/// <summary>A bitmask specifying flags that modify the behavior of the URL binding operation.</summary>
	[Flags]
	public enum DB_BINDFLAGS
	{
		/// <summary>Creates the object as a collection.</summary>
		DB_BINDFLAGS_COLLECTION = 0x00000010,

		/// <summary>
		/// On a bind to a row object, this flag overrides the consumer's intent to immediately access the row's columns. Absence of this
		/// flag is a hint to the provider to download or prefetch the row's columns.
		/// </summary>
		DB_BINDFLAGS_DELAYFETCHCOLUMNS = 0x00000001,

		/// <summary>
		/// On a bind to a row object, this flag overrides the consumer's intent to immediately open the default stream. Absence of this flag
		/// is a hint to the provider to instantiate the default stream object and prefetch its contents.
		/// </summary>
		DB_BINDFLAGS_DELAYFETCHSTREAM = 0x00000002,

		/// <summary>Creates the object as a structured document.</summary>
		DB_BINDFLAGS_ISSTRUCTUREDDOCUMENT = 0x00000080,

		/// <summary>If the resource exists and is not a collection, it is opened. If the resource does not exist, it is created.</summary>
		DB_BINDFLAGS_OPENIFEXISTS = 0x00000020,

		/// <summary>
		/// Bind to the resource's executed output rather than its source. (For example, this will retrieve the HTML generated by an ASP file
		/// rather than its source.) This flag is ignored on binds to collections.
		/// </summary>
		DB_BINDFLAGS_OUTPUT = 0x00000008,

		/// <summary>The database bindflags overwrite</summary>
		DB_BINDFLAGS_OVERWRITE = 0x00000040,

		/// <summary>The database bindflags recursive</summary>
		DB_BINDFLAGS_RECURSIVE = 0x00000004,
	}

	/// <summary>The INDEXES COLLATION identifies the indexes defined in the catalog that are owned by a given user.</summary>
	public enum DB_COLLATION : short
	{
		/// <summary>The sort sequence for the column is ascending.</summary>
		DB_COLLATION_ASC = 0x01,

		/// <summary>The sort sequence for the column is descending.</summary>
		DB_COLLATION_DESC = 0x02,
	}
	/// <summary>
	/// Indicates the level of impersonation that the server is allowed to use when impersonating the client. This property applies only to
	/// network connections other than Remote Procedure Call (RPC) connections; these impersonation levels are similar to those provided by RPC.
	/// </summary>
	public enum DB_IMP_LEVEL
	{
		/// <summary>
		/// The client is anonymous to the server. The server process cannot obtain identification information about the client and cannot
		/// impersonate the client.
		/// </summary>
		DB_IMP_LEVEL_ANONYMOUS = 0x00,

		/// <summary>
		/// The process can impersonate the client's security context while acting on behalf of the client. The server process can also make
		/// outgoing calls to other servers while acting on behalf of the client.
		/// </summary>
		DB_IMP_LEVEL_DELEGATE = 0x03,

		/// <summary>
		/// The server can obtain the client's identity. The server can impersonate the client for ACL checking but cannot access system
		/// objects as the client.
		/// </summary>
		DB_IMP_LEVEL_IDENTIFY = 0x01,

		/// <summary>
		/// The server process can impersonate the client's security context while acting on behalf of the client. This information is
		/// obtained when the connection is established, not on every call.
		/// </summary>
		DB_IMP_LEVEL_IMPERSONATE = 0x02,
	}

	/// <summary>A bitmask specifying access permissions.</summary>
	[Flags]
	public enum DB_MODE : int
	{
		/// <summary>Read-only.</summary>
		DB_MODE_READ = 0x01,

		/// <summary>Read/write (DB_MODE_READ | DB_MODE_WRITE).</summary>
		DB_MODE_READWRITE = 0x03,

		/// <summary>Neither read nor write access can be denied to others.</summary>
		DB_MODE_SHARE_DENY_NONE = 0x10,

		/// <summary>Prevents others from opening in read mode.</summary>
		DB_MODE_SHARE_DENY_READ = 0x04,

		/// <summary>Prevents others from opening in write mode.</summary>
		DB_MODE_SHARE_DENY_WRITE = 0x08,

		/// <summary>Prevents others from opening in read/write mode (DB_MODE_SHARE_DENY_READ | DB_MODE_SHARE_DENY_WRITE).</summary>
		DB_MODE_SHARE_EXCLUSIVE = 0x0c,

		/// <summary>Write-only.</summary>
		DB_MODE_WRITE = 0x02,
	}

	/// <summary>
	/// Indicates the level of protection of data sent between client and server. This property applies only to network connections other
	/// than RPC connections; these protection levels are similar to those provided by RPC.
	/// </summary>
	public enum DB_PROT_LEVEL
	{
		/// <summary>Authenticates the source of the data at the beginning of each request from the client to the server.</summary>
		DB_PROT_LEVEL_CALL = 0x02,

		/// <summary>Authenticates only when the client establishes the connection with the server.</summary>
		DB_PROT_LEVEL_CONNECT = 0x01,

		/// <summary>Performs no authentication of data sent to the server.</summary>
		DB_PROT_LEVEL_NONE = 0x00,

		/// <summary>Authenticates that all data received is from the client.</summary>
		DB_PROT_LEVEL_PKT = 0x03,

		/// <summary>Authenticates that all data received is from the client and that it has not been changed in transit.</summary>
		DB_PROT_LEVEL_PKT_INTEGRITY = 0x04,

		/// <summary>
		/// Authenticates that all data received is from the client, that it has not been changed in transit, and protects the privacy of the
		/// data by encrypting it.
		/// </summary>
		DB_PROT_LEVEL_PKT_PRIVACY = 0x05,
	}

	/// <summary>PROCEDURE_TYPE enumeration values are returned by the PROCEDURE_TYPE column of the IColumnsRowset interface.</summary>
	public enum DB_PT : short
	{
		/// <summary>Function; there is a returned value.</summary>
		DB_PT_FUNCTION = 0x03,

		/// <summary>Procedure; there is no returned value.</summary>
		DB_PT_PROCEDURE = 0x02,

		/// <summary>It is not known whether there is a returned value.</summary>
		DB_PT_UNKNOWN = 0x01,
	}


	/// <summary>An integer indicating how the data type can be used in searches if the provider supports ICommandText; otherwise, NULL.</summary>
	public enum DB_SEARCHABLE
	{
		/// <summary>indicates that the data type can be used in a WHERE clause with all comparison operators except LIKE.</summary>
		DB_ALL_EXCEPT_LIKE = 0x03,

		/// <summary>indicates that the data type can be used in a WHERE clause only with the LIKE predicate.</summary>
		DB_LIKE_ONLY = 0x02,

		/// <summary>indicates that the data type can be used in a WHERE clause with any comparison operator.</summary>
		DB_SEARCHABLE = 0x04,

		/// <summary>indicates that the data type cannot be used in a WHERE clause.</summary>
		DB_UNSEARCHABLE = 0x01,
	}

	[Flags]
	public enum DBACCESSORFLAGS
	{
		DBACCESSOR_INVALID,
		DBACCESSOR_PASSBYREF = 0x1,
		DBACCESSOR_ROWDATA = 0x2,
		DBACCESSOR_PARAMETERDATA = 0x4,
		DBACCESSOR_OPTIMIZED = 0x8,
		DBACCESSOR_INHERITED = 0x10
	}

	public enum DBASYNCHOP
	{
		DBASYNCHOP_OPEN
	}

	public enum DBASYNCHPHASE
	{
		DBASYNCHPHASE_INITIALIZATION,
		DBASYNCHPHASE_POPULATION = DBASYNCHPHASE_INITIALIZATION + 1,
		DBASYNCHPHASE_COMPLETE = DBASYNCHPHASE_POPULATION + 1,
		DBASYNCHPHASE_CANCELED = DBASYNCHPHASE_COMPLETE + 1
	}

	public enum DBBINDFLAG
	{
		DBBINDFLAG_HTML = 0x1
	}

	public enum DBBINDSTATUS
	{
		DBBINDSTATUS_OK,
		DBBINDSTATUS_BADORDINAL = 1,
		DBBINDSTATUS_UNSUPPORTEDCONVERSION = 2,
		DBBINDSTATUS_BADBINDINFO = 3,
		DBBINDSTATUS_BADSTORAGEFLAGS = 4,
		DBBINDSTATUS_NOINTERFACE = 5,
		DBBINDSTATUS_MULTIPLESTORAGE = 6
	}

	[Flags]
	public enum DBBINDURLFLAG
	{
		DBBINDURLFLAG_READ = 0x1,
		DBBINDURLFLAG_WRITE = 0x2,
		DBBINDURLFLAG_READWRITE = 0x3,
		DBBINDURLFLAG_SHARE_DENY_READ = 0x4,
		DBBINDURLFLAG_SHARE_DENY_WRITE = 0x8,
		DBBINDURLFLAG_SHARE_EXCLUSIVE = 0xc,
		DBBINDURLFLAG_SHARE_DENY_NONE = 0x10,
		DBBINDURLFLAG_ASYNCHRONOUS = 0x1000,
		DBBINDURLFLAG_COLLECTION = 0x2000,
		DBBINDURLFLAG_DELAYFETCHSTREAM = 0x4000,
		DBBINDURLFLAG_DELAYFETCHCOLUMNS = 0x8000,
		DBBINDURLFLAG_RECURSIVE = 0x400000,
		DBBINDURLFLAG_OUTPUT = 0x800000,
		DBBINDURLFLAG_WAITFORINIT = 0x1000000,
		DBBINDURLFLAG_OPENIFEXISTS = 0x2000000,
		DBBINDURLFLAG_OVERWRITE = 0x4000000,
		DBBINDURLFLAG_ISSTRUCTUREDDOCUMENT = 0x8000000,
	}

	[Flags]
	public enum DBBINDURLSTATUS
	{
		DBBINDURLSTATUS_S_OK = 0,
		DBBINDURLSTATUS_S_DENYNOTSUPPORTED = 0x1,
		DBBINDURLSTATUS_S_DENYTYPENOTSUPPORTED = 0x4,
		DBBINDURLSTATUS_S_REDIRECTED = 0x8,
	}

	public enum DBBOOKMARK
	{
		DBBMK_INVALID,
		DBBMK_FIRST = DBBMK_INVALID + 1,
		DBBMK_LAST = DBBMK_FIRST + 1
	}

	[Flags]
	public enum DBCOLUMNDESCFLAGS
	{
		DBCOLUMNDESCFLAGS_TYPENAME = 0x1,
		DBCOLUMNDESCFLAGS_ITYPEINFO = 0x2,
		DBCOLUMNDESCFLAGS_PROPERTIES = 0x4,
		DBCOLUMNDESCFLAGS_CLSID = 0x8,
		DBCOLUMNDESCFLAGS_COLSIZE = 0x10,
		DBCOLUMNDESCFLAGS_DBCID = 0x20,
		DBCOLUMNDESCFLAGS_WTYPE = 0x40,
		DBCOLUMNDESCFLAGS_PRECISION = 0x80,
		DBCOLUMNDESCFLAGS_SCALE = 0x100
	}

	[Flags]
	public enum DBCOLUMNFLAGS
	{
		DBCOLUMNFLAGS_ISBOOKMARK = 0x1,
		DBCOLUMNFLAGS_MAYDEFER = 0x2,
		DBCOLUMNFLAGS_WRITE = 0x4,
		DBCOLUMNFLAGS_WRITEUNKNOWN = 0x8,
		DBCOLUMNFLAGS_ISFIXEDLENGTH = 0x10,
		DBCOLUMNFLAGS_ISNULLABLE = 0x20,
		DBCOLUMNFLAGS_MAYBENULL = 0x40,
		DBCOLUMNFLAGS_ISLONG = 0x80,
		DBCOLUMNFLAGS_ISROWID = 0x100,
		DBCOLUMNFLAGS_ISROWVER = 0x200,
		DBCOLUMNFLAGS_CACHEDEFERRED = 0x1000,
		DBCOLUMNFLAGS_ISCHAPTER = 0x2000,

		[Obsolete]
		DBCOLUMNFLAGS_KEYCOLUMN = 0x8000,

		DBCOLUMNFLAGS_SCALEISNEGATIVE = 0x4000,
		DBCOLUMNFLAGS_RESERVED = 0x8000,
		DBCOLUMNFLAGS_ISROWURL = 0x10000,
		DBCOLUMNFLAGS_ISDEFAULTSTREAM = 0x20000,
		DBCOLUMNFLAGS_ISCOLLECTION = 0x40000,
		DBCOLUMNFLAGS_ISSTREAM = 0x80000,
		DBCOLUMNFLAGS_ISROWSET = 0x100000,
		DBCOLUMNFLAGS_ISROW = 0x200000,
		DBCOLUMNFLAGS_ROWSPECIFICCOLUMN = 0x400000
	}

	/// <summary>Options for persisting command definition.</summary>
	[Flags]
	public enum DBCOMMANDPERSISTFLAG
	{
		/// <summary>The behavior of DBCOMMANDPERSISTFLAGS_DEFAULT is provider specific.</summary>
		DBCOMMANDPERSISTFLAG_DEFAULT = 0,
		/// <summary>You can use DBCOMMANDPERSISTFLAG_NOSAVE to associate or obtain a new DBID for the command without actually persisting the definition.</summary>
		DBCOMMANDPERSISTFLAG_NOSAVE = 0x1,
		/// <summary>The command is to be persisted as a view. Views are row-returning objects that do not contain parameters or return values and can generally be used anywhere a base table is used. Views can be enumerated through the DBSCHEMA_VIEWS schema rowset.</summary>
		DBCOMMANDPERSISTFLAG_PERSISTVIEW = 0x2,
		/// <summary>The command is to be persisted as a procedure. Procedures may or may not return rows and may or may not contain parameters or return values. Procedures can be enumerated through the DBSCHEMA_PROCEDURES schema rowset.</summary>
		DBCOMMANDPERSISTFLAG_PERSISTPROCEDURE = 0x4
	}

	/// <summary>
	/// Operation to use in comparing the row values.
	/// </summary>
	[PInvokeData("oledb.h")]
	public enum DBCOMPAREOPS
	{
		/// <summary>Match the first value that is less than the search value.</summary>
		DBCOMPAREOPS_LT,
		/// <summary>Match the first value that is less than or equal to the search value.</summary>
		DBCOMPAREOPS_LE = 1,
		/// <summary>Match the first value that is equal to the search value.</summary>
		DBCOMPAREOPS_EQ = 2,
		/// <summary>Match the first value that is greater than or equal to the search value.</summary>
		DBCOMPAREOPS_GE = 3,
		/// <summary>Match the first value that is greater than the search value.</summary>
		DBCOMPAREOPS_GT = 4,
		/// <summary>Match the first value that has the search value as its first characters. This is valid only for values bound as string data types.</summary>
		DBCOMPAREOPS_BEGINSWITH = 5,
		/// <summary>Match the first value that contains the search value. This is valid only for values bound as string data types.</summary>
		DBCOMPAREOPS_CONTAINS = 6,
		/// <summary>Match the first value that is not equal to the search value. If the search value is NULL, this matches the first non-NULL value. If the search value is non-NULL, this matches the first non-NULL value that is not equal to the search value.</summary>
		DBCOMPAREOPS_NE = 7,
		/// <summary>
		///   <para>Ignore the corresponding value.</para>
		///   <para>The provider ignores <em>pFindValue</em> and returns the next <em>cRows</em> rows starting from the row indicated by <em>pBookmark</em>, skipping the number of rows indicated by <em>lRowsOffset</em>.</para>
		/// </summary>
		DBCOMPAREOPS_IGNORE = 8,
		/// <summary>
		///   <para>Specify whether the search is case-sensitive or case-insensitive.</para>
		///   <para>You can join DBCOMPAREOPS_CASESENSITIVE or DBCOMPAREOPS_CASEINSENSITIVE with any of the other DBCOMPAREOPS values in a bitwise OR operation. If neither is used, the search is handled according to the provider's implementation. Both DBCOMPAREOPS_CASESENSITIVE and DBCOMPAREOPS_CASEINSENSITIVE are ignored when searching for nonstring values.</para>
		/// </summary>
		DBCOMPAREOPS_CASESENSITIVE = 0x1000,
		/// <summary>
		///   <para>Specify whether the search is case-sensitive or case-insensitive.</para>
		///   <para>You can join DBCOMPAREOPS_CASESENSITIVE or DBCOMPAREOPS_CASEINSENSITIVE with any of the other DBCOMPAREOPS values in a bitwise OR operation. If neither is used, the search is handled according to the provider's implementation. Both DBCOMPAREOPS_CASESENSITIVE and DBCOMPAREOPS_CASEINSENSITIVE are ignored when searching for nonstring values.</para>
		/// </summary>
		DBCOMPAREOPS_CASEINSENSITIVE = 0x2000,
		/// <summary>Match the first value that does not have the search value as its first characters. This is valid only for values bound as string data types.</summary>
		DBCOMPAREOPS_NOTBEGINSWITH = 9,
		/// <summary>Match the first value that does not contain the search value. This is valid only for values bound as string data types.</summary>
		DBCOMPAREOPS_NOTCONTAINS = 10
	}

	/// <summary>
	/// Whether the column is computed when the row is inserted or updated, and the column is recomputed when any column in the expression changes.
	/// </summary>
	public enum DBCOMPUTEMODE
	{
		/// <summary>The column is computed when the row is inserted or updated.</summary>
		DBCOMPUTEMODE_COMPUTED = 0x01,

		/// <summary>
		/// The column is computed when the row is inserted or updated, and the column is recomputed when any column in the expression changes.
		/// </summary>
		DBCOMPUTEMODE_DYNAMIC = 0x02,

		/// <summary>The column is not computed.</summary>
		DBCOMPUTEMODE_NOTCOMPUTED = 0x03,
	}

	public enum DBCONSTRAINTTYPE
	{
		DBCONSTRAINTTYPE_UNIQUE,
		DBCONSTRAINTTYPE_FOREIGNKEY = 0x1,
		DBCONSTRAINTTYPE_PRIMARYKEY = 0x2,
		DBCONSTRAINTTYPE_CHECK = 0x3
	}

	public enum DBDEFERRABILITY
	{
		DBDEFERRABILITY_DEFERRED = 0x1,
		DBDEFERRABILITY_DEFERRABLE = 0x2
	}

	public enum DBEVENTPHASE
	{
		DBEVENTPHASE_OKTODO,
		DBEVENTPHASE_ABOUTTODO = DBEVENTPHASE_OKTODO + 1,
		DBEVENTPHASE_SYNCHAFTER = DBEVENTPHASE_ABOUTTODO + 1,
		DBEVENTPHASE_FAILEDTODO = DBEVENTPHASE_SYNCHAFTER + 1,
		DBEVENTPHASE_DIDEVENT = DBEVENTPHASE_FAILEDTODO + 1
	}

	public enum DBINDEX_COL_ORDER
	{
		DBINDEX_COL_ORDER_ASC,
		DBINDEX_COL_ORDER_DESC = DBINDEX_COL_ORDER_ASC + 1
	}

	/// <summary/>
	// https://learn.microsoft.com/en-us/windows/win32/api/oledbguid/ne-oledbguid-dbkindenum typedef enum DBKIND { DBKIND_GUID_NAME = 0,
	// DBKIND_GUID_PROPID, DBKIND_NAME, DBKIND_PGUID_NAME, DBKIND_PGUID_PROPID, DBKIND_PROPID, DBKIND_GUID } ;
	[PInvokeData("oledbguid.h", MSDNShortId = "NE:oledbguid.DBKINDENUM")]
	public enum DBKIND
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0</para>
		/// </summary>
		DBKIND_GUID_NAME,

		/// <summary/>
		DBKIND_GUID_PROPID,

		/// <summary/>
		DBKIND_NAME,

		/// <summary/>
		DBKIND_PGUID_NAME,

		/// <summary/>
		DBKIND_PGUID_PROPID,

		/// <summary/>
		DBKIND_PROPID,

		/// <summary/>
		DBKIND_GUID,
	}

	public enum DBMATCHTYPE
	{
		DBMATCHTYPE_FULL,
		DBMATCHTYPE_NONE = 0x1,
		DBMATCHTYPE_PARTIAL = 0x2
	}

	public enum DBMEMOWNER
	{
		DBMEMOWNER_CLIENTOWNED,
		DBMEMOWNER_PROVIDEROWNED = 0x1
	}

	[Flags]
	public enum DBPARAMFLAGS : uint
	{
		DBPARAMFLAGS_ISINPUT = 0x1,
		DBPARAMFLAGS_ISOUTPUT = 0x2,
		DBPARAMFLAGS_ISSIGNED = 0x10,
		DBPARAMFLAGS_ISNULLABLE = 0x40,
		DBPARAMFLAGS_SCALEISNEGATIVE = 0x100
	}

	public enum DBPARAMIO
	{
		DBPARAMIO_NOTPARAM,
		DBPARAMIO_INPUT = 0x1,
		DBPARAMIO_OUTPUT = 0x2
	}

	/// <summary>The PROCEDURE_PARAMETERS PARAMETER_TYPE returns information about the parameters and return codes of procedures.</summary>
	public enum DBPARAMTYPE : short
	{
		/// <summary>The parameter is an input parameter.</summary>
		DBPARAMTYPE_INPUT = 0x01,

		/// <summary>The parameter is an input/output parameter.</summary>
		DBPARAMTYPE_INPUTOUTPUT = 0x02,

		/// <summary>The parameter is an output parameter.</summary>
		DBPARAMTYPE_OUTPUT = 0x03,

		/// <summary>
		/// The parameter is a procedure return value. For example, in the following ODBC SQL statement to call a procedure, the question
		/// mark marks a procedure return value:
		/// </summary>
		DBPARAMTYPE_RETURNVALUE = 0x04,
	}
	[Flags]
	public enum DBPART
	{
		DBPART_INVALID,
		DBPART_VALUE = 0x1,
		DBPART_LENGTH = 0x2,
		DBPART_STATUS = 0x4
	}

	/// <summary>Indicates whether to prompt the user during initialization.</summary>
	public enum DBPROMPT : short
	{
		/// <summary>Prompt the user only if more information is needed.</summary>
		DBPROMPT_COMPLETE = 0x02,

		/// <summary>Prompt the user only if more information is needed. Do not allow the user to enter optional information.</summary>
		DBPROMPT_COMPLETEREQUIRED = 0x03,

		/// <summary>Do not prompt the user.</summary>
		DBPROMPT_NOPROMPT = 0x04,

		/// <summary>Always prompt the user for initialization information.</summary>
		DBPROMPT_PROMPT = 0x01,
	}

	/// <summary>
	/// <para>VARIANT_TRUE</para>
	/// <para>The consumer can perform a binary comparison of two row handles to determine whether they point to the same row.</para>
	/// <para>VARIANT_FALSE</para>
	/// <para>The consumer must call IRowsetIdentity::IsSameRow to determine whether two row handles point to the same row.</para>
	/// <para>
	/// If DBPROP_LITERALIDENTITY is set to VARIANT_FALSE, multiple different concurrently held row handles can represent the same row in the
	/// underlying data store. To the rowset, these generally appear as separate rows. Therefore, a change made (either in immediate mode or
	/// via IRowsetUpdate) to a retrieved column value (for example, a nondeferred column or a deferred column with DBPROP_CACHEDEFERRED set
	/// to VARIANT_TRUE) is not reflected when retrieving the row through a second row handle. Calling IRowsetRefresh::RefreshVisibleData,
	/// IRowsetUpdate::Undo, or IRowsetUpdate::Update affects only changes made through the specified row handle.
	/// </para>
	/// </summary>
	public enum DBPROPENUM
	{
		/// <summary>Preserve on Abort</summary>
		[CorrespondingType(typeof(bool))]
		DBPROP_ABORTPRESERVE = 0x2,

		/// <summary>
		/// Sets the order in which columns must be accessed by methods (such as IRowset::GetData, IRow::GetColumns, and IRow::Open) that
		/// operate on rowsets, rows, and streams.
		/// </summary>
		[CorrespondingType(typeof(DBPROPVAL_AO))]
		DBPROP_ACCESSORDER = 0xe7,

		/// <summary>The maximum number of session objects that can be active at one time.</summary>
		[CorrespondingType(typeof(int))]
		DBPROP_ACTIVESESSIONS = 0x3,

		/// <summary>Comprises a bitmask describing which portions of the DBCOLUMNDESC structure can be used in a call to IAlterTable::AlterColumn.</summary>
		[CorrespondingType(typeof(DBCOLUMNDESCFLAGS), CorrespondingAction.Get)]
		DBPROP_ALTERCOLUMN = 0xf5,

		/// <summary>
		/// A rowset opened with this property set to VARIANT_TRUE will be initially empty and will be populated only by those rows inserted
		/// through the rowset. Append-only rowsets are used for adding records to a table without having to get a rowset over existing rows.
		/// </summary>
		[CorrespondingType(typeof(bool))]
		DBPROP_APPENDONLY = 0xbb,

		/// <summary>Indicates whether transactions can be aborted asynchronously.</summary>
		[CorrespondingType(typeof(bool), CorrespondingAction.Get)]
		DBPROP_ASYNCTXNABORT = 0xa8,

		/// <summary>Indicates whether transactions can be committed asynchronously.</summary>
		[CorrespondingType(typeof(bool), CorrespondingAction.Get)]
		DBPROP_ASYNCTXNCOMMIT = 0x4,

		/// <summary>Cache Authentication</summary>
		[CorrespondingType(typeof(bool))]
		DBPROP_AUTH_CACHE_AUTHINFO = 0x5,

		/// <summary>Encrypt Password</summary>
		[CorrespondingType(typeof(bool))]
		DBPROP_AUTH_ENCRYPT_PASSWORD = 0x6,

		/// <summary>
		/// A string containing the name of the authentication service used by the server to identify the user using the identity provided by
		/// an authentication domain. For example, for Microsoft? Windows NT?/Windows? 2000 Integrated Security, this is "SSPI" (Security
		/// Support Provider Interface). If the BSTR is a null pointer, the default authentication service should be used. When this property
		/// is used, no other DBPROP_AUTH* properties are needed and if provided, their values are ignored.
		/// </summary>
		[CorrespondingType(typeof(string))]
		DBPROP_AUTH_INTEGRATED = 0x7,

		/// <summary>The consumer requires that the password be sent to the data source object or enumerator in a masked form.</summary>
		[CorrespondingType(typeof(bool))]
		DBPROP_AUTH_MASK_PASSWORD = 0x8,

		/// <summary>
		/// Indicates the password to be used when connecting to the data source object or enumerator. When the value of this property is
		/// retrieved with IDBProperties::GetProperties, the provider might return a mask such as "******" or an empty string instead of the
		/// actual password. The password is still set internally and is used when IDBInitialize::Initialize is called.
		/// </summary>
		[CorrespondingType(typeof(string))]
		DBPROP_AUTH_PASSWORD = 0x9,

		/// <summary>
		/// The consumer requires that the data source object persist sensitive authentication information, such as a password, in encrypted form.
		/// </summary>
		[CorrespondingType(typeof(bool))]
		DBPROP_AUTH_PERSIST_ENCRYPTED = 0xa,

		/// <summary>
		/// The data source object is allowed to persist sensitive authentication information such as a password along with other
		/// authentication information.
		/// </summary>
		[CorrespondingType(typeof(bool))]
		DBPROP_AUTH_PERSIST_SENSITIVE_AUTHINFO = 0xb,

		/// <summary>Indicates the user ID to be used when connecting to the data source object or enumerator.</summary>
		[CorrespondingType(typeof(string))]
		DBPROP_AUTH_USERID = 0xc,

		/// <summary>Indicates whether storage objects might prevent use of other methods on the rowset.</summary>
		[CorrespondingType(typeof(bool))]
		DBPROP_BLOCKINGSTORAGEOBJECTS = 0xd,

		/// <summary>A bitmask specifying additional information about bookmarks over the rowset.</summary>
		[CorrespondingType(typeof(DBPROPVAL_BI), CorrespondingAction.Get)]
		DBPROP_BOOKMARKINFO = 0xe8,

		/// <summary>Indicates whether the rowset supports bookmarks.</summary>
		[CorrespondingType(typeof(bool))]
		DBPROP_BOOKMARKS = 0xe,

		/// <summary>
		/// Indicates whether the rowset allows IRowsetLocate::GetRowsAt, IRowsetScroll::GetApproximatePosition, or IRowsetFind::FindNextRow
		/// to continue if a bookmark row was deleted; contains a bookmarked row to which the consumer does not have access rights; contains
		/// a bookmark identifying a row not in the chapter; or contains a bookmarked row that is no longer a member of the rowset.
		/// </summary>
		[CorrespondingType(typeof(bool))]
		DBPROP_BOOKMARKSKIPPED = 0xf,

		/// <summary>Indicates the bookmark type supported by the rowset.</summary>
		[CorrespondingType(typeof(DBPROPVAL_BMK))]
		DBPROP_BOOKMARKTYPE = 0x10,

		/// <summary>
		/// Indicates whether the provider supports the DBACCESSOR_PASSBYREF flag in IAccessor::CreateAccessor. This applies both to row and
		/// to parameter accessors.
		/// </summary>
		[CorrespondingType(typeof(bool), CorrespondingAction.Get)]
		DBPROP_BYREFACCESSORS = 0x78,

		/// <summary>
		/// The provider caches the value of a deferred column when the consumer first gets a value from that column. When the consumer later
		/// gets a value from the column, the provider returns the value in the cache. The contents of the cache can be overwritten by
		/// IRowsetChange::SetData or IRowsetRefresh::RefreshVisibleData. The cached value is released when the row is released.
		/// </summary>
		[CorrespondingType(typeof(bool))]
		DBPROP_CACHEDEFERRED = 0x11,

		/// <summary>Indicates whether the rowset can fetch backward.</summary>
		[CorrespondingType(typeof(bool))]
		DBPROP_CANFETCHBACKWARDS = 0x12,

		/// <summary>
		/// The rowset allows the consumer to retrieve more rows or change the next fetch position, while holding previously fetched rows or
		/// rows with pending changes.
		/// </summary>
		[CorrespondingType(typeof(bool))]
		DBPROP_CANHOLDROWS = 0x13,

		/// <summary>Indicates whether the rowset can scroll backward.</summary>
		[CorrespondingType(typeof(bool))]
		DBPROP_CANSCROLLBACKWARDS = 0x15,

		/// <summary>Indicates the position of the catalog name in a qualified table name in a text command.</summary>
		[CorrespondingType(typeof(DBPROPVAL_CL), CorrespondingAction.Get)]
		DBPROP_CATALOGLOCATION = 0x16,

		/// <summary>
		/// Indicates the name the data source object uses for a catalog ? for example, "catalog", "database", or "directory". This is used
		/// for building user interfaces.
		/// </summary>
		[CorrespondingType(typeof(string), CorrespondingAction.Get)]
		DBPROP_CATALOGTERM = 0x17,

		/// <summary>A bitmask specifying how catalog names can be used in text commands.</summary>
		[CorrespondingType(typeof(DBPROPVAL_CU), CorrespondingAction.Get)]
		DBPROP_CATALOGUSAGE = 0x18,

		/// <summary>The consumer can call IRowsetChange::DeleteRows or IRowsetChange::SetData for newly inserted rows.</summary>
		[CorrespondingType(typeof(bool))]
		DBPROP_CHANGEINSERTEDROWS = 0xbc,

		/// <summary>
		/// DBPROP_CLIENTCURSOR requires a provider to materialize a cursor-capable rowset on the client. This property overrides other
		/// rowset properties used to determine where to materialize a cursor. Providers may support this property if they offer client
		/// cursor capability. The Client Cursor Engine, an OLE DB service component that provides scrolling and find support over OLE DB
		/// rowsets, implements DBPROP_CLIENTCURSOR.
		/// </summary>
		[CorrespondingType(typeof(bool))]
		DBPROP_CLIENTCURSOR = 0x104,

		/// <summary>Indicates whether the values of the column are autoincrementing.</summary>
		[CorrespondingType(typeof(bool))]
		DBPROP_COL_AUTOINCREMENT = 0x1a,

		/// <summary>
		/// A VARIANT specifying the default value for an object ? typically a domain or column. If the default value is a string, the string
		/// must be quoted so that it can be distinguished from an object of the same name. If the provider supports the PROVIDER_TYPES
		/// schema rowset, quoting should use the LITERAL_PREFIX and LITERAL_SUFFIX characters. For example, 'Salary' is a string, but Salary
		/// is an object, such as a column.
		/// </summary>
		[CorrespondingType(typeof(object))]
		DBPROP_COL_DEFAULT = 0x1b,

		/// <summary>A string specifying a human-readable description of the specified column.</summary>
		[CorrespondingType(typeof(string))]
		DBPROP_COL_DESCRIPTION = 0x1c,

		/// <summary>Indicates whether a column is fixed-length or variable-length.</summary>
		[CorrespondingType(typeof(bool))]
		DBPROP_COL_FIXEDLENGTH = 0xa7,

		/// <summary>A VARIANT specifying the increment value for a numeric column.</summary>
		[CorrespondingType(typeof(object))]
		DBPROP_COL_INCREMENT = 0x11b,

		/// <summary>The dbprop col islong</summary>
		[CorrespondingType(typeof(bool))]
		DBPROP_COL_ISLONG = 0x119,

		/// <summary>Indicates whether or not the consumer can set the column to NULL.</summary>
		[CorrespondingType(typeof(bool))]
		DBPROP_COL_NULLABLE = 0x1d,

		/// <summary>Indicates whether the column is part of the primary key.</summary>
		[CorrespondingType(typeof(bool))]
		DBPROP_COL_PRIMARYKEY = 0x1e,

		/// <summary>A VARIANT specifying the seed value for a numeric column.</summary>
		[CorrespondingType(typeof(object))]
		DBPROP_COL_SEED = 0x11a,

		/// <summary>Indicates whether values of the column must be unique within the table.</summary>
		[CorrespondingType(typeof(bool))]
		DBPROP_COL_UNIQUE = 0x1f,

		/// <summary>A bitmask defining the valid clauses for the definition of a column.</summary>
		[CorrespondingType(typeof(DBPROPVAL_CD), CorrespondingAction.Get)]
		DBPROP_COLUMNDEFINITION = 0x20,

		/// <summary>Indicates the locale ID of the column.</summary>
		[CorrespondingType(typeof(LCID), CorrespondingAction.Get)]
		DBPROP_COLUMNLCID = 0xf6,

		/// <summary>
		/// Access rights are restricted on a column-by-column basis. If the rowset exposes IRowsetChange, IRowsetChange::SetData cannot be
		/// called for at least one column. A provider must not execute a query that would specify a column for which the consumer has no
		/// read access rights.
		/// </summary>
		[CorrespondingType(typeof(bool), CorrespondingAction.Get)]
		DBPROP_COLUMNRESTRICT = 0x21,

		/// <summary>The number of seconds before a command times out. A value of 0 indicates an infinite time-out.</summary>
		[CorrespondingType(typeof(int))]
		DBPROP_COMMANDTIMEOUT = 0x22,

		/// <summary>
		/// After committing a transaction, the rowset remains active. That is, it is possible to fetch new rows; update, delete, and insert
		/// rows; and so on.
		/// </summary>
		[CorrespondingType(typeof(bool))]
		DBPROP_COMMITPRESERVE = 0x23,

		/// <summary>A bitmask specifying the provider's support for COM services.</summary>
		[CorrespondingType(typeof(DBPROPVAL_CM), CorrespondingAction.Get)]
		DBPROP_COMSERVICES = 0x11d,

		/// <summary>
		/// Indicates how the data source object handles the concatenation of NULL-valued character data type columns with non?NULL-valued
		/// character data type columns.
		/// </summary>
		[CorrespondingType(typeof(DBPROPVAL_CNB), CorrespondingAction.Get)]
		DBPROP_CONCATNULLBEHAVIOR = 0x24,

		/// <summary>Indicates the status of the current connection.</summary>
		[CorrespondingType(typeof(DBPROPVAL_CS), CorrespondingAction.Get)]
		DBPROP_CONNECTIONSTATUS = 0xf4,

		/// <summary>The name of the current catalog. The consumer can use the CATALOGS schema rowset to enumerate catalogs.</summary>
		[CorrespondingType(typeof(string))]
		DBPROP_CURRENTCATALOG = 0x25,

		/// <summary>Data Source Type</summary>
		[CorrespondingType(typeof(DBPROPVAL_DST), CorrespondingAction.Get)]
		DBPROP_DATASOURCE_TYPE = 0xfb,

		/// <summary>Indicates the name of the data source object. This might be used during the connection process.</summary>
		[CorrespondingType(typeof(string), CorrespondingAction.Get)]
		DBPROP_DATASOURCENAME = 0x26,

		/// <summary><see langword="true"/> if the data store is read-only; <see langword="false"/> if updatable.</summary>
		[CorrespondingType(typeof(bool), CorrespondingAction.Get)]
		DBPROP_DATASOURCEREADONLY = 0x27,

		/// <summary>The name of the product accessed by the provider ? for example, "ORACLE Server" or, for Microsoft? Excel, "Excel".</summary>
		[CorrespondingType(typeof(string), CorrespondingAction.Get)]
		DBPROP_DBMSNAME = 0x28,

		/// <summary>
		/// Indicates the version of the product accessed by the provider. The version is of the form ##.##.####, where the first two digits
		/// are the major version, the next two digits are the minor version, and the last four digits are the release version. The provider
		/// must render the product version in this form but can also append the product-specific version ? for example, "04.01.0000 Rdb 4.1".
		/// </summary>
		[CorrespondingType(typeof(string), CorrespondingAction.Get)]
		DBPROP_DBMSVER = 0x29,

		/// <summary>The data in the column is not fetched until an accessor is used on the column.</summary>
		[CorrespondingType(typeof(bool))]
		DBPROP_DEFERRED = 0x2a,

		/// <summary>
		/// <para>
		/// In delayed update mode, if the value of this property is VARIANT_TRUE, storage objects are also used in delayed update mode. In particular:
		/// </para>
		/// <para>Changes to the object are not transmitted to the data source object until IRowsetUpdate::Update is called.</para>
		/// <list type="bullet">
		/// <item>IRowsetUpdate::Undo undoes any pending changes.</item>
		/// <item>
		/// IRowsetUpdate::GetOriginalData retrieves the original value of the object ? that is, the object's value when the row was last
		/// fetched or updated and excluding any changes made since then.
		/// </item>
		/// </list>
		/// <para>
		/// In delayed update mode, if the value of this property is VARIANT_FALSE, storage objects are used in immediate update mode. In particular:
		/// </para>
		/// <list type="bullet">
		/// <item>Changes to the object are immediately transmitted to the data source object.</item>
		/// <item>IRowsetUpdate::Update has no effect on the object.</item>
		/// <item>IRowsetUpdate::Undo does not undo changes made to the object since the row was last fetched or updated.</item>
		/// <item>
		/// IRowsetUpdate::GetOriginalData retrieves the current value of the object, including changes made since the row was last fetched
		/// or updated.
		/// </item>
		/// </list>
		/// <para>In immediate update mode, this property has no effect on storage objects.</para>
		/// </summary>
		[CorrespondingType(typeof(bool))]
		DBPROP_DELAYSTORAGEOBJECTS = 0x2b,

		/// <summary>A bitmask specifying the threading models supported by the data source object.</summary>
		[CorrespondingType(typeof(DBPROPVAL_RT), CorrespondingAction.Get)]
		DBPROP_DSOTHREADMODEL = 0xa9,

		/// <summary>A bitmask describing the comparison operations supported by IViewFilter for a particular column.</summary>
		[CorrespondingType(typeof(DBPROPVAL_CO), CorrespondingAction.Get)]
		DBPROP_FILTERCOMPAREOPS = 0xd1,

		/// <summary>
		/// A bitmask describing the comparison operations supported by IRowsetFind for a particular column. If no column is specified, the
		/// full set of comparison operators that may be supported.
		/// </summary>
		[CorrespondingType(typeof(DBPROPVAL_CO), CorrespondingAction.Get)]
		DBPROP_FINDCOMPAREOPS = 0xd2,

		/// <summary>A bitmask indicating whether the provider requires data store is generated URLs for row creation and scoped operations.</summary>
		[CorrespondingType(typeof(DBPROPVAL_GU), CorrespondingAction.Get)]
		DBPROP_GENERATEURL = 0x111,

		/// <summary>Indicates the relationship between the columns in a GROUP BY clause and the nonaggregated columns in the select list.</summary>
		[CorrespondingType(typeof(DBPROPVAL_GB), CorrespondingAction.Get)]
		DBPROP_GROUPBY = 0x2c,

		/// <summary>A bitmask specifying whether the provider can join tables from different catalogs or providers.</summary>
		[CorrespondingType(typeof(DBPROPVAL_HT), CorrespondingAction.Get)]
		DBPROP_HETEROGENEOUSTABLES = 0x2d,

		/// <summary>
		/// <para>
		/// If DBPROP_UNIQUEROWS is VARIANT_TRUE, the DBPROP_HIDDENCOLUMNS property returns the number of additional "hidden" columns added
		/// by the provider to uniquely identify rows within the rowset. These columns are returned by IColumnsInfo::GetColumnInfo and
		/// IColumnsRowset::GetColumnsRowset. However, they are not included in the count of rows returned by the pcColumns argument returned
		/// by IColumnsInfo::GetColumnInfo.
		/// </para>
		/// <para>
		/// To determine the total number of columns represented in the prgInfo structure returned by IColumnsInfo::GetColumnInfo, including
		/// hidden columns, the consumer adds the value of DBPROP_HIDDENCOLUMNS to the count of columns returned from
		/// IColumnsInfo::GetColumnInfo in pcColumns. If DBPROP_UNIQUEROWS is VARIANT_FALSE, DBPROP_HIDDENCOLUMNS is zero.
		/// </para>
		/// </summary>
		[CorrespondingType(typeof(int), CorrespondingAction.Get)]
		DBPROP_HIDDENCOLUMNS = 0x102,

		/// <summary>
		/// The value of this property is read-only and is always set to VARIANT_TRUE, indicating that the rowset supports the specified
		/// interface. The value of this property cannot be set to VARIANT_FALSE. (This is also true of DBPROP_IColumnsInfo,
		/// DBPROP_IConvertType, DBPROP_IRowset, and DBPROP_IRowsetInfo.) If the consumer does not set the value of this property to true,
		/// the resulting rowset supports IAccessor.
		/// </summary>
		[CorrespondingType(typeof(bool), CorrespondingAction.Get)]
		DBPROP_IAccessor = 0x79,

		/// <summary>The rowset supports the specified interface.</summary>
		[CorrespondingType(typeof(bool))]
		DBPROP_IBindResource = 0x10c,

		/// <summary>The rowset supports the specified interface.</summary>
		[CorrespondingType(typeof(bool))]
		DBPROP_IChapteredRowset = 0xca,

		/// <summary>
		/// The value of this property is read-only and is always set to VARIANT_TRUE, indicating that the rowset supports the specified
		/// interface. The value of this property cannot be set to VARIANT_FALSE. (This is also true of DBPROP_IAccessor,
		/// DBPROP_IConvertType, DBPROP_IRowset, and DBPROP_IRowsetInfo.) If the consumer does not set the value of this property to true,
		/// the resulting rowset supports IColumnsInfo.
		/// </summary>
		[CorrespondingType(typeof(bool), CorrespondingAction.Get)]
		DBPROP_IColumnsInfo = 0x7a,

		/// <summary>The rowset supports the specified interface.</summary>
		[CorrespondingType(typeof(bool))]
		DBPROP_IColumnsInfo2 = 0x113,

		/// <summary>The rowset supports the specified interface.</summary>
		[CorrespondingType(typeof(bool))]
		DBPROP_IColumnsRowset = 0x7b,

		/// <summary>The rowset supports the specified interface.</summary>
		[CorrespondingType(typeof(bool))]
		DBPROP_IConnectionPointContainer = 0x7c,

		/// <summary>
		/// The value of this property is read-only and is always set to VARIANT_TRUE, indicating that the rowset supports the specified
		/// interface. The value of this property cannot be set to VARIANT_FALSE. (This is also true of DBPROP_IAccessor,
		/// DBPROP_IColumnsInfo, DBPROP_IRowset, and DBPROP_IRowsetInfo.) If the consumer does not set the value of this property to true,
		/// the resulting rowset supports IConvertType.
		/// </summary>
		[CorrespondingType(typeof(bool), CorrespondingAction.Get)]
		DBPROP_IConvertType = 0xc2,

		/// <summary>The rowset supports the specified interface.</summary>
		[CorrespondingType(typeof(bool))]
		DBPROP_ICreateRow = 0x10d,

		/// <summary>The rowset supports the specified interface.</summary>
		[CorrespondingType(typeof(bool))]
		DBPROP_IDBAsynchStatus = 0xcb,

		/// <summary>The rowset supports the specified interface.</summary>
		[CorrespondingType(typeof(bool))]
		DBPROP_IDBBinderProperties = 0x112,

		/// <summary>
		/// Indicates how identifiers treat case in data definition commands or interfaces (such as IIndexDefinition, IAlterTable,
		/// IAlterIndex, ITableCreation, ITableDefinition, and ITableDefinitionWithConstraints). For SQL providers, this refers to SQL data
		/// definition commands and storage in system catalogs.
		/// </summary>
		[CorrespondingType(typeof(DBPROPVAL_IC), CorrespondingAction.Get)]
		DBPROP_IDENTIFIERCASE = 0x2e,

		/// <summary>The rowset supports the specified interface.</summary>
		[CorrespondingType(typeof(bool))]
		DBPROP_IGetRow = 0x10a,

		/// <summary>The rowset supports the specified interface.</summary>
		[CorrespondingType(typeof(bool))]
		DBPROP_IGetSession = 0x115,

		/// <summary>The rowset supports the specified interface.</summary>
		[CorrespondingType(typeof(bool))]
		DBPROP_IGetSourceRow = 0x116,

		/// <summary>
		/// <para>
		/// If the value of this property is set to VARIANT_TRUE, the rowset is capable of manipulating the contents of columns as a storage
		/// object supporting the specified interface. The provider reports its ability to enable this property on a per-column basis by
		/// setting the flag DBPROPFLAGS_COLUMNOK. A provider that does not have the ability to turn the property on/off on a per-column
		/// basis does not set DBPROPFLAGS_COLUMNOK.
		/// </para>
		/// <para>
		/// Whether or not the property is supported in the rowset as a whole or on a per-column basis, the ability to manipulate a column
		/// value as a storage object depends on whether the provider supports the coercion from the column's native type (BLOB or non-BLOB)
		/// to the particular storage interface.
		/// </para>
		/// </summary>
		[CorrespondingType(typeof(bool))]
		DBPROP_ILockBytes = 0x88,

		/// <summary>
		/// <para>VARIANT_TRUE</para>
		/// <para>
		/// The rowset will not reorder inserted or updated rows. For IRowsetChange::InsertRow, rows will appear at the end of the rowset.
		/// </para>
		/// <para>VARIANT_FALSE</para>
		/// <para>
		/// If the rowset is ordered, inserted rows and updated rows (where one or more of the columns in the ordering criteria are updated)
		/// obey the ordering criteria of the rowset. If the rowset is not ordered, inserted rows are not guaranteed to appear in a
		/// determinate position and the position of updated rows is not changed.
		/// </para>
		/// </summary>
		[CorrespondingType(typeof(bool))]
		DBPROP_IMMOBILEROWS = 0x2f,

		/// <summary>
		/// <para>VARIANT_TRUE</para>
		/// <para>
		/// Executing the command or opening the rowset returns a multiple results object (supporting IMultipleResults) in place of the
		/// rowset. This multiple results object can be used to obtain a series of results generated from a single method call.
		/// </para>
		/// <para>VARIANT_FALSE</para>
		/// <para>
		/// Executing the command or opening the rowset returns a rowset object. If a series of results are generated from the method call,
		/// only the first such result is available.
		/// </para>
		/// </summary>
		[CorrespondingType(typeof(bool))]
		DBPROP_IMultipleResults = 0xd9,

		/// <summary>Indicates whether the index is maintained automatically when changes are made to the corresponding base table.</summary>
		[CorrespondingType(typeof(bool))]
		DBPROP_INDEX_AUTOUPDATE = 0x30,

		/// <summary>
		/// <para>VARIANT_TRUE</para>
		/// <para>The leaf nodes of the index contain full rows, not bookmarks. This is a way to represent a table clustered by key value.</para>
		/// <para>VARIANT_FALSE</para>
		/// <para>
		/// The leaf nodes of the index contain bookmarks of the base table rows whose key value matches the key value of the index entry.
		/// </para>
		/// </summary>
		[CorrespondingType(typeof(bool))]
		DBPROP_INDEX_CLUSTERED = 0x31,

		/// <summary>
		/// For a B+-tree index, this property represents the storage utilization factor of page nodes during the creation of the index. The
		/// value is an integer from 1 to 100, representing the percentage of use of an index node. For a linear hash index, this property
		/// represents the storage utilization of the entire hash structure (the ratio of the used area to the total allocated area) before a
		/// file structure expansion occurs.
		/// </summary>
		[CorrespondingType(typeof(int))]
		DBPROP_INDEX_FILLFACTOR = 0x32,

		/// <summary>Indicates the total number of bytes allocated to this structure at creation time.</summary>
		[CorrespondingType(typeof(int))]
		DBPROP_INDEX_INITIALSIZE = 0x33,

		/// <summary>Indicates how NULLs are collated in the index.</summary>
		[CorrespondingType(typeof(DBPROPVAL_NC))]
		DBPROP_INDEX_NULLCOLLATION = 0x34,

		/// <summary>Indicates whether NULL keys are allowed.</summary>
		[CorrespondingType(typeof(DBPROPVAL_IN))]
		DBPROP_INDEX_NULLS = 0x35,

		/// <summary>Indicates whether the index represents the primary key on the table.</summary>
		[CorrespondingType(typeof(bool))]
		DBPROP_INDEX_PRIMARYKEY = 0x36,

		/// <summary>Indicates how the index treats repeated keys.</summary>
		[CorrespondingType(typeof(bool))]
		DBPROP_INDEX_SORTBOOKMARKS = 0x37,

		/// <summary>Indicates whether the index is temporary.</summary>
		[CorrespondingType(typeof(bool))]
		DBPROP_INDEX_TEMPINDEX = 0xa3,

		/// <summary>Indicates the type of the index.</summary>
		[CorrespondingType(typeof(DBPROPVAL_IT))]
		DBPROP_INDEX_TYPE = 0x38,

		/// <summary>Indicates whether index keys must be unique.</summary>
		[CorrespondingType(typeof(bool))]
		DBPROP_INDEX_UNIQUE = 0x39,

		/// <summary>A bitmask specifying the asynchronous processing performed on the data source object.</summary>
		[CorrespondingType(typeof(DBPROPVAL_ASYNCH))]
		DBPROP_INIT_ASYNCH = 0xc8,

		/// <summary>A bitmask specifying flags that modify the behavior of the URL binding operation.</summary>
		[CorrespondingType(typeof(DB_BINDFLAGS))]
		DBPROP_INIT_BINDFLAGS = 0x10e,

		/// <summary>
		/// Indicates the name of the initial (or default) catalog to use when connecting to the data source object. If the provider supports
		/// changing the catalog for an initialized object, the consumer can specify a different catalog name through the
		/// DBPROP_CURRENTCATALOG property in the DBPROPSET_DATASOURCE property set after initialization.
		/// </summary>
		[CorrespondingType(typeof(string))]
		DBPROP_INIT_CATALOG = 0xe9,

		/// <summary>
		/// Indicates the name of the database or enumerator to connect to. DBPROP_INIT_DATASOURCE is used to identify the data source object
		/// to connect to ? for example, a relational database server or a local file. If the provider uses two-part naming to identify the
		/// data source object, the data source object name is qualified with the location specified in DBPROP_INIT_LOCATION.
		/// </summary>
		[CorrespondingType(typeof(string))]
		DBPROP_INIT_DATASOURCE = 0x3b,

		/// <summary>
		/// Indicates the number of seconds before a request, other than data source initialization and command execution, times out. A value
		/// of 0 indicates an infinite time-out. Providers that work over network connections or in distributed or transacted scenarios can
		/// support this property to advise an enlisted component to time-out in the event of a long-running request. Time-outs for data
		/// source initialization and command execution remain governed by DBPROP_INIT_TIMEOUT and DBPROP_COMMANDTIMEOUT, respectively.
		/// </summary>
		[CorrespondingType(typeof(int))]
		DBPROP_INIT_GENERALTIMEOUT = 0x11c,

		/// <summary>Indicates the window handle to be used if the data source object or enumerator needs to prompt for additional information.</summary>
		[CorrespondingType(typeof(HWND))]
		DBPROP_INIT_HWND = 0x3c,

		/// <summary>
		/// Indicates the level of impersonation that the server is allowed to use when impersonating the client. This property applies only
		/// to network connections other than Remote Procedure Call (RPC) connections; these impersonation levels are similar to those
		/// provided by RPC.
		/// </summary>
		[CorrespondingType(typeof(DB_IMP_LEVEL))]
		DBPROP_INIT_IMPERSONATION_LEVEL = 0x3d,

		/// <summary>
		/// Indicates the locale ID of preference for the consumer. Consumers specify the LCID at initialization. This provides a method for
		/// the server to determine the consumer's LCID of choice in cases where it can use this information. This property does not
		/// guarantee that all text returned to the consumer will be translated according to the LCID.
		/// </summary>
		[CorrespondingType(typeof(LCID))]
		DBPROP_INIT_LCID = 0xba,

		/// <summary>
		/// Indicates the location of the data source object or enumerator to connect to. Typically, this will be a server name.
		/// DBPROP_INIT_LOCATION is used as the first part of a two-part name to qualify the data source object specified in the
		/// DBPROP_INIT_DATASOURCE property. For example, if the data source object is defined on a different machine, this might be the
		/// machine name on which to look for the data source object definition. This is typically not used if the provider can identify the
		/// data source object by using a single name, such as the name of an RDBMS server, that the consumer can use to identify the data
		/// source object directly.
		/// </summary>
		[CorrespondingType(typeof(string))]
		DBPROP_INIT_LOCATION = 0x3e,

		/// <summary>
		/// Indicates the string that the client wants displayed as its identifier when other clients attempt to access this resource. This
		/// property is ignored unless DBBINDURLFLAG_SHARE_* is specified. If DBPROP_INIT_LOCKOWNER is not specified, is NULL, or is empty,
		/// the provider should use the currently logged-in user name as the lock owner string.
		/// </summary>
		[CorrespondingType(typeof(string))]
		DBPROP_INIT_LOCKOWNER = 0x10f,

		/// <summary>A bitmask specifying access permissions.</summary>
		[CorrespondingType(typeof(DB_MODE))]
		DBPROP_INIT_MODE = 0x3f,

		/// <summary>
		/// A bitmask specifying OLE DB services to enable or disable. To use this property, the provider must support service components and
		/// must have been invoked with IDataInitialize on the OLE DB Initialization core service. For more information about OLE DB
		/// services, see OLE DB Services. This property overrides the settings of the OLEDB_SERVICES registration key. For more information
		/// about these settings, see Overriding Provider Service Defaults and related topics.
		/// </summary>
		[CorrespondingType(typeof(DBPROPVAL_OS))]
		DBPROP_INIT_OLEDBSERVICES = 0xf8,

		/// <summary>Indicates whether to prompt the user during initialization.</summary>
		[CorrespondingType(typeof(DBPROMPT))]
		DBPROP_INIT_PROMPT = 0x40,

		/// <summary>
		/// Indicates the level of protection of data sent between client and server. This property applies only to network connections other
		/// than RPC connections; these protection levels are similar to those provided by RPC.
		/// </summary>
		[CorrespondingType(typeof(DB_PROT_LEVEL))]
		DBPROP_INIT_PROTECTION_LEVEL = 0x41,

		/// <summary>
		/// A string containing provider-specific, extended connection information. Use of this property implies that the consumer knows how
		/// this string will be interpreted and used by the provider. Consumers should use this property only for provider-specific
		/// connection information that cannot be explicitly described through the property mechanism.
		/// </summary>
		[CorrespondingType(typeof(string))]
		DBPROP_INIT_PROVIDERSTRING = 0xa0,

		/// <summary>Indicates the amount of time (in seconds) to wait for initialization to complete.</summary>
		[CorrespondingType(typeof(int))]
		DBPROP_INIT_TIMEOUT = 0x42,

		/// <summary>The rowset supports the specified interface.</summary>
		[CorrespondingType(typeof(bool))]
		DBPROP_IParentRowset = 0x101,

		DBPROP_IRegisterProvider = 0x114,

		/// <summary>The provider creates a row object instead of a rowset object when opening a rowset or executing a command.</summary>
		[CorrespondingType(typeof(bool))]
		DBPROP_IRow = 0x107,

		/// <summary>The rowset supports the specified interface.</summary>
		[CorrespondingType(typeof(bool))]
		DBPROP_IRowChange = 0x108,

		/// <summary>The rowset supports the specified interface.</summary>
		[CorrespondingType(typeof(bool))]
		DBPROP_IRowSchemaChange = 0x109,

		/// <summary>
		/// The value of this property is read-only and is always set to VARIANT_TRUE, indicating that the rowset supports the specified
		/// interface. The value of this property cannot be set to VARIANT_FALSE. (This is also true of DBPROP_IAccessor,
		/// DBPROP_IColumnsInfo, DBPROP_IConvertType, and DBPROP_IRowsetInfo.) If the consumer does not set the value of this property to
		/// true, the resulting rowset supports IRowset.
		/// </summary>
		[CorrespondingType(typeof(bool), CorrespondingAction.Get)]
		DBPROP_IRowset = 0x7e,

		/// <summary>
		/// The rowset supports the specified interface. This setting implicitly causes the created rowset to support bookmarks, and
		/// IRowsetInfo::GetProperties will return VARIANT_TRUE for the property DBPROP_BOOKMARKS.
		/// </summary>
		[CorrespondingType(typeof(bool))]
		DBPROP_IRowsetBookmark = 0x124,

		/// <summary>The rowset supports the specified interface.</summary>
		[CorrespondingType(typeof(bool))]
		DBPROP_IRowsetChange = 0x7f,

		/// <summary>The rowset supports the specified interface.</summary>
		[CorrespondingType(typeof(bool))]
		DBPROP_IRowsetCurrentIndex = 0x117,

		/// <summary>The rowset supports the specified interface.</summary>
		[CorrespondingType(typeof(bool))]
		DBPROP_IRowsetFind = 0xcc,

		/// <summary>The rowset supports the specified interface.</summary>
		[CorrespondingType(typeof(bool))]
		DBPROP_IRowsetIdentity = 0x80,

		/// <summary>The rowset supports the specified interface.</summary>
		[CorrespondingType(typeof(bool))]
		DBPROP_IRowsetIndex = 0x9f,

		/// <summary>
		/// The value of this property is read-only and is always set to VARIANT_TRUE, indicating that the rowset supports the specified
		/// interface. The value of this property cannot be set to VARIANT_FALSE. (This is also true of DBPROP_IAccessor,
		/// DBPROP_IColumnsInfo, DBPROP_IConvertType, and DBPROP_IRowset.) If the consumer does not set the value of this property to true,
		/// the resulting rowset supports IRowsetInfo.
		/// </summary>
		[CorrespondingType(typeof(bool), CorrespondingAction.Get)]
		DBPROP_IRowsetInfo = 0x81,

		/// <summary>
		/// The rowset supports the specified interface. This setting implicitly causes the created rowset to support bookmarks, and
		/// IRowsetInfo::GetProperties will return VARIANT_TRUE for the property DBPROP_BOOKMARKS.
		/// </summary>
		[CorrespondingType(typeof(bool))]
		DBPROP_IRowsetLocate = 0x82,

		/// <summary>The rowset supports the specified interface.</summary>
		[CorrespondingType(typeof(bool))]
		DBPROP_IRowsetRefresh = 0xf9,

		[CorrespondingType(typeof(bool))]
		DBPROP_IRowsetResynch = 0x84,

		/// <summary>The rowset supports the specified interface.</summary>
		[CorrespondingType(typeof(bool))]
		DBPROP_IRowsetScroll = 0x85,

		/// <summary>The rowset supports the specified interface.</summary>
		[CorrespondingType(typeof(bool))]
		DBPROP_IRowsetUpdate = 0x86,

		/// <summary>The rowset supports the specified interface.</summary>
		[CorrespondingType(typeof(bool))]
		DBPROP_IRowsetView = 0xd4,

		/// <summary>The rowset supports the specified interface.</summary>
		[CorrespondingType(typeof(bool))]
		DBPROP_IScopedOperations = 0x10b,

		/// <summary>
		/// If the value of this property is set to VARIANT_TRUE, the rowset is capable of manipulating the contents of columns as a storage
		/// object supporting the specified interface. The provider reports its ability to enable this property on a per-column basis by
		/// setting the flag DBPROPFLAGS_COLUMNOK. A provider that does not have the ability to turn the property on/off on a per-column
		/// basis does not set DBPROPFLAGS_COLUMNOK.
		/// </summary>
		[CorrespondingType(typeof(bool))]
		DBPROP_ISequentialStream = 0x89,

		/// <summary>
		/// If the value of this property is set to VARIANT_TRUE, the rowset is capable of manipulating the contents of columns as a storage
		/// object supporting the specified interface. The provider reports its ability to enable this property on a per-column basis by
		/// setting the flag DBPROPFLAGS_COLUMNOK. A provider that does not have the ability to turn the property on/off on a per-column
		/// basis does not set DBPROPFLAGS_COLUMNOK.
		/// </summary>
		[CorrespondingType(typeof(bool))]
		DBPROP_IStorage = 0x8a,

		[CorrespondingType(typeof(bool))]
		DBPROP_IStream = 0x8b,

		/// <summary>The rowset supports the specified interface.</summary>
		[CorrespondingType(typeof(bool))]
		DBPROP_ISupportErrorInfo = 0x87,

		/// <summary>
		/// For all methods returning a Rowset or View object, in addition to Rowset properties, DBPROPSET_VIEW should be set before creating
		/// a view.
		/// </summary>
		[CorrespondingType(typeof(bool))]
		DBPROP_IViewChapter = 0xd5,

		/// <summary>
		/// For all methods returning a Rowset or View object, in addition to Rowset properties, DBPROPSET_VIEW should be set before creating
		/// a view. Providers that support this interface (and thereby support view filters) must support setting this property to true.
		/// </summary>
		[CorrespondingType(typeof(bool))]
		DBPROP_IViewFilter = 0xd6,

		/// <summary>
		/// For all methods returning a Rowset or View object, in addition to Rowset properties, DBPROPSET_VIEW should be set before creating
		/// a view.
		/// </summary>
		[CorrespondingType(typeof(bool))]
		DBPROP_IViewRowset = 0xd7,

		/// <summary>
		/// For all methods returning a Rowset or View object, in addition to Rowset properties, DBPROPSET_VIEW should be set before creating
		/// a view.
		/// </summary>
		[CorrespondingType(typeof(bool))]
		DBPROP_IViewSort = 0xd8,

		/// <summary>
		/// <para>VARIANT_TRUE</para>
		/// <para>The consumer can perform a binary comparison of two row handles to determine whether they point to the same row.</para>
		/// <para>VARIANT_FALSE</para>
		/// <para>The consumer must call IRowsetIdentity::IsSameRow to determine whether two row handles point to the same row.</para>
		/// <para>
		/// If DBPROP_LITERALIDENTITY is set to VARIANT_FALSE, multiple different concurrently held row handles can represent the same row in
		/// the underlying data store. To the rowset, these generally appear as separate rows. Therefore, a change made (either in immediate
		/// mode or via IRowsetUpdate) to a retrieved column value (for example, a nondeferred column or a deferred column with
		/// DBPROP_CACHEDEFERRED set to VARIANT_TRUE) is not reflected when retrieving the row through a second row handle. Calling
		/// IRowsetRefresh::RefreshVisibleData, IRowsetUpdate::Undo, or IRowsetUpdate::Update affects only changes made through the specified
		/// row handle.
		/// </para>
		/// </summary>
		[CorrespondingType(typeof(bool), CorrespondingAction.Get)]
		DBPROP_LITERALBOOKMARKS = 0x43,

		/// <summary>
		/// <para>VARIANT_TRUE</para>
		/// <para>The consumer can perform a binary comparison of two row handles to determine whether they point to the same row.</para>
		/// <para>VARIANT_FALSE</para>
		/// <para>The consumer must call IRowsetIdentity::IsSameRow to determine whether two row handles point to the same row.</para>
		/// <para>
		/// If DBPROP_LITERALIDENTITY is set to VARIANT_FALSE, multiple different concurrently held row handles can represent the same row in
		/// the underlying data store. To the rowset, these generally appear as separate rows. Therefore, a change made (either in immediate
		/// mode or via IRowsetUpdate) to a retrieved column value (for example, a nondeferred column or a deferred column with
		/// DBPROP_CACHEDEFERRED set to VARIANT_TRUE) is not reflected when retrieving the row through a second row handle. Calling
		/// IRowsetRefresh::RefreshVisibleData, IRowsetUpdate::Undo, or IRowsetUpdate::Update affects only changes made through the specified
		/// row handle.
		/// </para>
		/// </summary>
		[CorrespondingType(typeof(bool), CorrespondingAction.Get)]
		DBPROP_LITERALIDENTITY = 0x44,

		/// <summary>Indicates the level of locking performed by the rowset.</summary>
		[CorrespondingType(typeof(DBPROPVAL_LM))]
		DBPROP_LOCKMODE = 0xec,

		/// <summary>
		/// Indicates the maximum number of bytes allowed in the combined columns of an index. If there is no specified limit or the limit is
		/// unknown, this value is set to zero.
		/// </summary>
		[CorrespondingType(typeof(int), CorrespondingAction.Get)]
		DBPROP_MAXINDEXSIZE = 0x46,

		/// <summary>
		/// <para>Indicates the maximum number of chapters that can be open at any time.</para>
		/// <para>
		/// If a chapter must be released before a new chapter can be opened, this value is 1; if the provider has no limit on the number of
		/// open chapters or does not support chapters, this value is 0.
		/// </para>
		/// </summary>
		[CorrespondingType(typeof(int), CorrespondingAction.Get)]
		DBPROP_MAXOPENCHAPTERS = 0xc7,

		/// <summary>
		/// <para>
		/// Indicates the maximum number of rows that can be active at the same time. This limit does not reflect resource limitations such
		/// as RAM but does apply if the rowset implementation uses some strategy that results in a limit.
		/// </para>
		/// <para>
		/// If there is no limit, the value of this property is zero. The provider is free to support a greater number of active rows than
		/// the maximum specified by the consumer. In this case, the provider will return its actual maximum number of active rows instead of
		/// the value specified by the consumer.
		/// </para>
		/// </summary>
		[CorrespondingType(typeof(int))]
		DBPROP_MAXOPENROWS = 0x47,

		/// <summary>
		/// <para>
		/// Indicates the maximum number of disjoint conditions that can be supported in a view filter. Multiple conditions (rows) of a view
		/// filter are joined in a logical OR. Providers that do not support joining multiple conditions return a value of 1. If there is no
		/// specified limit or the limit is unknown, the provider returns 0.
		/// </para>
		/// <para>
		/// This value applies only to the conditions that can be joined in a logical OR in a call to IViewFilter::SetFilter; it does not
		/// imply the maximum number of OR conditions that may exist in a command.
		/// </para>
		/// </summary>
		[CorrespondingType(typeof(int), CorrespondingAction.Get)]
		DBPROP_MAXORSINFILTER = 0xcd,

		/// <summary>
		/// Indicates the maximum number of rows that can have pending changes at the same time. This limit does not reflect resource
		/// limitations such as Random Access Memory (RAM) but does apply if the rowset implementation uses some strategy that results in a
		/// limit. If there is no limit, this value is zero. The provider is free to support a greater number of pending rows than the
		/// maximum specified by the consumer. In this case, the provider will return its actual maximum number of pending rows instead of
		/// the value specified by the consumer.
		/// </summary>
		[CorrespondingType(typeof(int))]
		DBPROP_MAXPENDINGROWS = 0x48,

		/// <summary>
		/// Indicates the maximum number of rows that can be returned in a rowset. If there is no limit, this value is zero. If the provider
		/// supports setting DBPROP_MAXROWS, at initial rowset population the provider must ensure that the rowset never contains more than
		/// the specified number of rows. If the consumer attempts to fetch beyond DBPROP_MAXROWS number of rows in a rowset, the rowset
		/// behaves as if the table contained or the query returned only DBPROP_MAXROWS, and the provider returns DB_S_ENDOFROWSET. Pending
		/// deletes do not count against the rowset limit set by DBPROP_MAXROWS. Providers are not required to check DBPROP_MAXROWS when
		/// inserting or deleting rows.
		/// </summary>
		[CorrespondingType(typeof(int))]
		DBPROP_MAXROWS = 0x49,

		/// <summary>
		/// Indicates the maximum length of a single row in a table. If there is no specified limit or the limit is unknown, this value is
		/// set to zero.
		/// </summary>
		[CorrespondingType(typeof(int), CorrespondingAction.Get)]
		DBPROP_MAXROWSIZE = 0x4a,

		/// <summary>
		/// <para>VARIANT_TRUE</para>
		/// <para>The maximum row size returned for the DBPROP_MAXROWSIZE property includes the length of all BLOB data.</para>
		/// <para>VARIANT_FALSE</para>
		/// <para>The maximum row size does not include the length of all BLOB data.</para>
		/// </summary>
		[CorrespondingType(typeof(bool), CorrespondingAction.Get)]
		DBPROP_MAXROWSIZEINCLUDESBLOB = 0x4b,

		/// <summary>
		/// <para>
		/// Indicates the maximum number of columns that can be supported in a View Sort. If there is no specified limit or the limit is
		/// unknown, this value is set to zero.
		/// </para>
		/// <para>
		/// This value applies only to the number of sort columns that can be specified in a call to IViewSort::SetSortOrder; it does not
		/// imply the maximum number of columns that can be used to sort in a command.
		/// </para>
		/// </summary>
		[CorrespondingType(typeof(int), CorrespondingAction.Get)]
		DBPROP_MAXSORTCOLUMNS = 0xce,

		/// <summary>
		/// Indicates the maximum number of tables allowed in the FROM clause of a SELECT statement. If there is no specified limit or the
		/// limit is unknown, this value is set to zero.
		/// </summary>
		[CorrespondingType(typeof(int), CorrespondingAction.Get)]
		DBPROP_MAXTABLESINSELECT = 0x4c,

		/// <summary>
		/// Indicates whether or not a particular column is writable. This property can be set implicitly through the command used to create
		/// the rowset. For example, if the rowset is created by the SQL statement SELECT A, B FROM MyTable FOR UPDATE OF A, this property is
		/// VARIANT_TRUE for column A and VARIANT_FALSE for column B.
		/// </summary>
		[CorrespondingType(typeof(bool))]
		DBPROP_MAYWRITECOLUMN = 0x4d,

		/// <summary>
		/// This property estimates the amount of memory that can be used by the rowset. If it is 0, the rowset can use unlimited memory. If
		/// it is between 1 and 99 inclusive, the rowset can use the specified percentage of total available virtual memory (physical and
		/// page file). If it is greater than or equal to 100, the rowset can use up to the specified number of kilobytes of memory.
		/// </summary>
		[CorrespondingType(typeof(int))]
		DBPROP_MEMORYUSAGE = 0x4e,

		/// <summary>
		/// Some providers may have to spawn multiple connections to the database in order to support multiple concurrent command, session,
		/// and rowset objects. Such providers may expose DBPROP_MULTIPLECONNECTIONS in order to let the consumer disable making additional
		/// connections under the covers. Providers that can support multiple concurrent command, session, and rowset objects without
		/// spawning multiple connections do not support this property.
		/// </summary>
		[CorrespondingType(typeof(bool))]
		DBPROP_MULTIPLECONNECTIONS = 0xed,

		/// <summary>
		/// <para>VARIANT_TRUE</para>
		/// <para>The provider supports multiple parameter sets.</para>
		/// <para>VARIANT_FALSE</para>
		/// <para>The provider supports only a single set of parameters per execution.</para>
		/// </summary>
		[CorrespondingType(typeof(bool), CorrespondingAction.Get)]
		DBPROP_MULTIPLEPARAMSETS = 0xbf,

		/// <summary>
		/// A bitmask specifying whether the provider supports multiple results objects and what restrictions it places on these objects.
		/// </summary>
		[CorrespondingType(typeof(DBPROPVAL_MR))]
		DBPROP_MULTIPLERESULTS = 0xc4,

		/// <summary>
		/// <para>VARIANT_TRUE</para>
		/// <para>The provider supports multiple, open storage objects at the same time.</para>
		/// <para>VARIANT_FALSE</para>
		/// <para>
		/// The provider supports only one open storage object at a time. Any method that attempts to open a second storage object returns a
		/// status of DBSTATUS_E_CANTCREATE for the column on which it attempted to open the second storage object, whether or not the
		/// objects are constructed over the same column, different columns in the same row, or different rows.
		/// </para>
		/// </summary>
		[CorrespondingType(typeof(bool), CorrespondingAction.Get)]
		DBPROP_MULTIPLESTORAGEOBJECTS = 0x50,

		/// <summary>
		/// <para>VARIANT_TRUE</para>
		/// <para>The provider can update rowsets derived from multiple tables.</para>
		/// <para>VARIANT_FALSE</para>
		/// <para>The provider cannot update rowsets derived from multiple tables.</para>
		/// </summary>
		[CorrespondingType(typeof(bool), CorrespondingAction.Get)]
		DBPROP_MULTITABLEUPDATE = 0x51,

		/// <summary>Notification Granularity</summary>
		[CorrespondingType(typeof(DBPROPVAL_NT))]
		DBPROP_NOTIFICATIONGRANULARITY = 0xc6,

		/// <summary>A bitmask specifying the notification phases supported by the provider.</summary>
		[CorrespondingType(typeof(DBPROPVAL_NP), CorrespondingAction.Get)]
		DBPROP_NOTIFICATIONPHASES = 0x52,

		/// <summary>A bitmask specifying whether the notification phase is cancelable.</summary>
		[CorrespondingType(typeof(DBPROPVAL_NP), CorrespondingAction.Get)]
		DBPROP_NOTIFYCOLUMNSET = 0xab,

		/// <summary>A bitmask specifying whether the notification phase is cancelable.</summary>
		[CorrespondingType(typeof(DBPROPVAL_NP), CorrespondingAction.Get)]
		DBPROP_NOTIFYROWDELETE = 0xad,

		/// <summary>A bitmask specifying whether the notification phase is cancelable.</summary>
		[CorrespondingType(typeof(DBPROPVAL_NP), CorrespondingAction.Get)]
		DBPROP_NOTIFYROWFIRSTCHANGE = 0xae,

		/// <summary>A bitmask specifying whether the notification phase is cancelable.</summary>
		[CorrespondingType(typeof(DBPROPVAL_NP), CorrespondingAction.Get)]
		DBPROP_NOTIFYROWINSERT = 0xaf,

		/// <summary>A bitmask specifying whether the notification phase is cancelable.</summary>
		[CorrespondingType(typeof(DBPROPVAL_NP), CorrespondingAction.Get)]
		DBPROP_NOTIFYROWRESYNCH = 0xb1,

		/// <summary>A bitmask specifying whether the notification phase is cancelable.</summary>
		[CorrespondingType(typeof(DBPROPVAL_NP), CorrespondingAction.Get)]
		DBPROP_NOTIFYROWSETCHANGED = 0xd3,

		/// <summary>A bitmask specifying whether the notification phase is cancelable.</summary>
		[CorrespondingType(typeof(DBPROPVAL_NP), CorrespondingAction.Get)]
		DBPROP_NOTIFYROWSETFETCHPOSITIONCHANGE = 0xb3,

		/// <summary>A bitmask specifying whether the notification phase is cancelable.</summary>
		[CorrespondingType(typeof(DBPROPVAL_NP), CorrespondingAction.Get)]
		DBPROP_NOTIFYROWSETRELEASE = 0xb2,

		/// <summary>A bitmask specifying whether the notification phase is cancelable.</summary>
		[CorrespondingType(typeof(DBPROPVAL_NP), CorrespondingAction.Get)]
		DBPROP_NOTIFYROWUNDOCHANGE = 0xb4,

		/// <summary>A bitmask specifying whether the notification phase is cancelable.</summary>
		[CorrespondingType(typeof(DBPROPVAL_NP), CorrespondingAction.Get)]
		DBPROP_NOTIFYROWUNDODELETE = 0xb5,

		/// <summary>A bitmask specifying whether the notification phase is cancelable.</summary>
		[CorrespondingType(typeof(DBPROPVAL_NP), CorrespondingAction.Get)]
		DBPROP_NOTIFYROWUNDOINSERT = 0xb6,

		/// <summary>A bitmask specifying whether the notification phase is cancelable.</summary>
		[CorrespondingType(typeof(DBPROPVAL_NP), CorrespondingAction.Get)]
		DBPROP_NOTIFYROWUPDATE = 0xb7,

		/// <summary>Indicates where NULLs are sorted in a list.</summary>
		[CorrespondingType(typeof(DBPROPVAL_NC), CorrespondingAction.Get)]
		DBPROP_NULLCOLLATION = 0x53,

		/// <summary>A bitmask specifying the ways in which the provider supports access to BLOBs and COM objects stored in columns.</summary>
		[CorrespondingType(typeof(DBPROPVAL_OO), CorrespondingAction.Get)]
		DBPROP_OLEOBJECTS = 0x54,

		/// <summary>A bitmask describing support for opening objects through IOpenRowset.</summary>
		[CorrespondingType(typeof(DBPROPVAL_ORS), CorrespondingAction.Get)]
		DBPROP_OPENROWSETSUPPORT = 0x118,

		/// <summary>
		/// <para>VARIANT_TRUE</para>
		/// <para>Columns in an ORDER BY clause must be in the select list.</para>
		/// <para>VARIANT_FALSE</para>
		/// <para>Columns in an ORDER BY clause are not required to be in the select list.</para>
		/// </summary>
		[CorrespondingType(typeof(bool), CorrespondingAction.Get)]
		DBPROP_ORDERBYCOLUMNSINSELECT = 0x55,

		/// <summary>
		/// <para>VARIANT_TRUE</para>
		/// <para>Bookmarks can be compared to determine the relative position of their associated rows in the rowset.</para>
		/// <para>Setting the value of this property to VARIANT_TRUE automatically sets the value of DBPROP_BOOKMARKS to VARIANT_TRUE.</para>
		/// <para>VARIANT_FALSE</para>
		/// <para>Bookmarks can be compared only for equality.</para>
		/// </summary>
		[CorrespondingType(typeof(bool))]
		DBPROP_ORDEREDBOOKMARKS = 0x56,

		/// <summary>
		/// <para>VARIANT_TRUE</para>
		/// <para>
		/// Rows inserted by a consumer or process other than a consumer of the rowset are visible. That is, any consumer of the rowset will
		/// see those rows the next time it fetches a set of rows containing the changed rows, whatever process changed that row. This
		/// includes rows inserted in the same transaction as well as rows inserted outside the transaction by others.
		/// </para>
		/// <para>VARIANT_FALSE</para>
		/// <para>Inserts to the rowset made by other consumers of the rowset are not visible unless the command is reexecuted.</para>
		/// </summary>
		[CorrespondingType(typeof(bool))]
		DBPROP_OTHERINSERT = 0x57,

		/// <summary>
		/// <para>VARIANT_TRUE</para>
		/// <para>
		/// Rows modified (updated or deleted) by a consumer or process other than a consumer of the rowset are visible. For example, suppose
		/// this other process or consumer updates the data underlying a row or deletes the row. If the row is released completely, any
		/// consumer of the rowset will see that change the next time it fetches the row. This includes updates and deletes made by others in
		/// the same transaction as well as updates and deletes made by others outside the transaction.
		/// </para>
		/// <para>VARIANT_FALSE</para>
		/// <para>
		/// Changes to the rowset (updates and deletes) made by other consumers of the rowset are not visible unless the command is reexecuted.
		/// </para>
		/// </summary>
		[CorrespondingType(typeof(bool))]
		DBPROP_OTHERUPDATEDELETE = 0x58,

		/// <summary>
		/// <para>Specifies the encoding to be used in the stream returned by ICommand::Execute.</para>
		/// <list type="bullet">
		/// <item>The values for this property are provider-specific.</item>
		/// <item>If the value of this property is NULL, the default encoding used in the stream is provider-specific.</item>
		/// <item>The provider optionally can prefix the output stream with a header to identify the encoding used.</item>
		/// </list>
		/// </summary>
		[CorrespondingType(typeof(string))]
		DBPROP_OUTPUTENCODING = 0x11f,

		/// <summary>Indicates the time at which output parameter values become available.</summary>
		[CorrespondingType(typeof(DBPROPVAL_OA), CorrespondingAction.Get)]
		DBPROP_OUTPUTPARAMETERAVAILABILITY = 0xb8,

		/// <summary>
		/// The value passed in this property is a Variant containing a pointer to either IStream or ISequentialStream. When this property is
		/// set, ICommand::Execute will return results in the stream specified by this property. Each successive execution of the Execute
		/// method will append its results to the specified stream.
		/// </summary>
		[CorrespondingType(typeof(IntPtr))]
		DBPROP_OUTPUTSTREAM = 0x11e,

		/// <summary>
		/// <para>VARIANT_TRUE</para>
		/// <para>
		/// The inserts to the rowset are visible. That is, if a consumer of a rowset inserts a row, that row will be visible to any consumer
		/// of the rowset the next time that consumer fetches a set of rows containing that row. This ability is independent of the
		/// transaction isolation level because all consumers of the rowset share the same transaction.
		/// </para>
		/// <para>VARIANT_FALSE</para>
		/// <para>Changes to the rowset (updates and deletes) made by consumers of the rowset are not visible unless the command is reexecuted.</para>
		/// </summary>
		[CorrespondingType(typeof(bool))]
		DBPROP_OWNINSERT = 0x59,

		/// <summary>
		/// <para>VARIANT_TRUE</para>
		/// <para>
		/// The updates and deletes made by the rowset consumer are visible. For example, suppose a consumer of the rowset updates or deletes
		/// a row. If the row is released completely, the update or delete will be visible to any consumer of the rowset the next time it
		/// fetches that row. This ability is independent of the transaction isolation level because all consumers of the rowset share the
		/// same transaction.
		/// </para>
		/// <para>VARIANT_FALSE</para>
		/// <para>Changes to the rowset (updates and deletes) made by consumers of the rowset are not visible unless the command is reexecuted.</para>
		/// </summary>
		[CorrespondingType(typeof(bool))]
		DBPROP_OWNUPDATEDELETE = 0x5a,

		/// <summary>
		/// An integer specifying the type of DBID that the provider uses when persisting DBIDs that name entities in the data store, such as
		/// tables, indexes, columns, commands, or constraints. This is generally the type of DBID that the provider considers the most
		/// permanent under schema changes and physical data reorganizations.
		/// </summary>
		[CorrespondingType(typeof(DBPROPVAL_PT), CorrespondingAction.Get)]
		DBPROP_PERSISTENTIDTYPE = 0xb9,

		/// <summary>Indicates how aborting a transaction affects prepared commands.</summary>
		[CorrespondingType(typeof(DBPROPVAL_CB), CorrespondingAction.Get)]
		DBPROP_PREPAREABORTBEHAVIOR = 0x5b,

		/// <summary>Indicates how committing a transaction affects prepared commands.</summary>
		[CorrespondingType(typeof(DBPROPVAL_CB), CorrespondingAction.Get)]
		DBPROP_PREPARECOMMITBEHAVIOR = 0x5c,

		/// <summary>
		/// A character string with the data store vendor's name for a procedure ? for example, "database procedure", "stored procedure", or
		/// "procedure". This is used for building user interfaces.
		/// </summary>
		[CorrespondingType(typeof(string), CorrespondingAction.Get)]
		DBPROP_PROCEDURETERM = 0x5d,

		/// <summary>
		/// Indicates the file name of the provider ? for example, "Myprvdr.dll". Prior to MDAC 2.5, this property was named DBPROP_PROVIDERNAME.
		/// </summary>
		[CorrespondingType(typeof(string), CorrespondingAction.Get)]
		DBPROP_PROVIDERFILENAME = DBPROP_PROVIDERNAME,

		/// <summary>Indicates the friendly name of the provider ? for example, "Microsoft OLE DB Provider for ODBC Drivers".</summary>
		[CorrespondingType(typeof(string), CorrespondingAction.Get)]
		DBPROP_PROVIDERFRIENDLYNAME = 0xeb,

		/// <summary>Indicates whether the provider supports provider-owned memory.</summary>
		[CorrespondingType(typeof(bool), CorrespondingAction.Get)]
		DBPROP_PROVIDERMEMORY = 0x103,

		[CorrespondingType(typeof(string), CorrespondingAction.Get)]
		DBPROP_PROVIDERNAME = 0x60,

		/// <summary>
		/// Indicates the version of OLE DB supported by the provider. The version is of the form ##.##, where the first two digits are the
		/// major version and the next two digits are the minor version. For example, OLE DB providers conforming to the 2.1 specification
		/// would return "02.10".
		/// </summary>
		[CorrespondingType(typeof(string), CorrespondingAction.Get)]
		DBPROP_PROVIDEROLEDBVER = 0x61,

		/// <summary>
		/// <para>
		/// Indicates the version of the provider. The version is of the form ##.##.####, where the first two digits are the major version,
		/// the next two digits are the minor version, and the last four digits are the release version. The provider can append a
		/// description of the provider.
		/// </para>
		/// <para>
		/// This is the same as DBPROP_DBMSVER if the DBMS is the same as the provider ? that is, if the DBMS supports OLE DB interfaces
		/// directly. It is different if the provider is separate from the DBMS, such as when the provider accesses the DBMS through ODBC.
		/// </para>
		/// </summary>
		[CorrespondingType(typeof(string), CorrespondingAction.Get)]
		DBPROP_PROVIDERVER = 0x62,

		/// <summary>
		/// <para>VARIANT_TRUE</para>
		/// <para>
		/// IRowset::RestartPosition is relatively quick to execute. In particular, it does not reexecute the command that created the rowset.
		/// </para>
		/// <para>VARIANT_FALSE</para>
		/// <para>RestartPosition is expensive to execute and requires reexecuting the command that created the rowset.</para>
		/// </summary>
		[CorrespondingType(typeof(bool))]
		DBPROP_QUICKRESTART = 0x63,

		/// <summary>Indicates how quoted identifiers treat case.</summary>
		[CorrespondingType(typeof(DBPROPVAL_IC), CorrespondingAction.Get)]
		DBPROP_QUOTEDIDENTIFIERCASE = 0x64,

		/// <summary>
		/// <para>VARIANT_TRUE</para>
		/// <para>
		/// The provider supports reentrancy during callbacks to the IRowsetNotify interface. The provider might not support reentrancy on
		/// all rowset methods. These methods return DB_E_NOTREENTRANT.
		/// </para>
		/// <para>VARIANT_FALSE</para>
		/// <para>The provider does not support such reentrancy. The provider returns DB_E_NOTREENTRANT on methods called during the notification.</para>
		/// </summary>
		[CorrespondingType(typeof(bool), CorrespondingAction.Get)]
		DBPROP_REENTRANTEVENTS = 0x65,

		/// <summary>
		/// <para>VARIANT_TRUE</para>
		/// <para>
		/// The provider removes rows it detects as having been deleted from the rowset. That is, fetching a block of rows that formerly
		/// included a deleted row does not return a handle to that row.
		/// </para>
		/// <para>VARIANT_FALSE</para>
		/// <para>
		/// The provider deletes the rows, but does not remove them from the rowset. If the user fetches a block of rows containing a deleted
		/// row, that row will have a handle that shows up in the rowset.
		/// </para>
		/// <para>Any method that retrieves a row using the handle of a deleted row will return a code of DB_E_DELETEDROW.</para>
		/// <para>
		/// The manner in which deleted rows are presented to the consumer is provider-specific. Some providers will not show the deleted
		/// rows, and some will show all rows.
		/// </para>
		/// </summary>
		[CorrespondingType(typeof(bool))]
		DBPROP_REMOVEDELETED = 0x66,

		/// <summary>
		/// <para>VARIANT_TRUE</para>
		/// <para>
		/// An update or delete can affect multiple rows, and the provider can detect that multiple rows have been updated or deleted. This
		/// happens when a provider cannot uniquely identify a row. For example, the provider might use the values of all the columns in the
		/// row to identify the row; if these columns do not include a unique key, an update or delete might affect more than one row.
		/// </para>
		/// <para>VARIANT_FALSE</para>
		/// <para>An update or delete always affects a single row, or the provider cannot detect whether it affects multiple rows.</para>
		/// </summary>
		[CorrespondingType(typeof(bool), CorrespondingAction.Get)]
		DBPROP_REPORTMULTIPLECHANGES = 0x67,

		/// <summary>Indicates the data source object state should be reset.</summary>
		[CorrespondingType(typeof(DBPROPVAL_RD), CorrespondingAction.Set)]
		DBPROP_RESETDATASOURCE = 0xf7,

		/// <summary>
		/// <para>VARIANT_TRUE</para>
		/// <para>
		/// The methods that fetch rows, such as IRowset::GetNextRows, can return pending insert rows ? that is, rows that have been inserted
		/// in delayed update mode but for which IRowsetUpdate::Update has not yet been called.
		/// </para>
		/// <para>VARIANT_FALSE</para>
		/// <para>The methods that fetch rows cannot return pending insert rows.</para>
		/// </summary>
		[CorrespondingType(typeof(bool), CorrespondingAction.Get)]
		DBPROP_RETURNPENDINGINSERTS = 0xbd,

		/// <summary>
		/// A bitmask describing optimizations that a provider may take for updates to the rowset. These optimizations are usually used for
		/// things like bulk loading of a table. The following values can be specified and are usually set as OPTIONAL properties because
		/// they are hints to the provider. Additional bits may be defined in the future; providers should be prepared to handle new bits in
		/// this bitmask by ignoring them if the property is set as optional or by returning an error if the property is set as required.
		/// </summary>
		[CorrespondingType(typeof(DBPROPVAL_BO), CorrespondingAction.Get)]
		DBPROP_ROW_BULKOPS = 0xea,

		/// <summary>
		/// <para>VARIANT_TRUE</para>
		/// <para>
		/// Access rights are restricted on a row-by-row basis. If the rowset supports IRowsetChange, IRowsetChange::SetData can be called
		/// for some but not all rows. A rowset must never count or return a handle for a row for which the consumer does not have read
		/// access rights.
		/// </para>
		/// <para>VARIANT_FALSE</para>
		/// <para>
		/// Access rights are not restricted on a row-by-row basis. If the rowset supports IRowsetChange, IRowsetChange::SetData can be
		/// called for any row.
		/// </para>
		/// </summary>
		[CorrespondingType(typeof(bool), CorrespondingAction.Get)]
		DBPROP_ROWRESTRICT = 0x68,

		/// <summary>A bitmask specifying the asynchronous processing performed on the rowset.</summary>
		[CorrespondingType(typeof(DBPROPVAL_ASYNCH))]
		DBPROP_ROWSET_ASYNCH = 0xc9,

		/// <summary>
		/// <para>VARIANT_TRUE</para>
		/// <para>Callers to IConvertType::CanConvert can inquire on a command about conversions supported on rowsets generated by the command.</para>
		/// <para>VARIANT_FALSE</para>
		/// <para>Callers can inquire on a command only about conversions supported by the command.</para>
		/// </summary>
		[CorrespondingType(typeof(bool), CorrespondingAction.Get)]
		DBPROP_ROWSETCONVERSIONSONCOMMAND = 0xc0,

		/// <summary>A bitmask specifying the threading models supported by the rowset.</summary>
		[CorrespondingType(typeof(DBPROPVAL_RT))]
		DBPROP_ROWTHREADMODEL = 0x69,

		/// <summary>
		/// The name the data source object uses for a schema ? for example, "schema" or "owner". This is used for building user interfaces.
		/// </summary>
		[CorrespondingType(typeof(string), CorrespondingAction.Get)]
		DBPROP_SCHEMATERM = 0x6a,

		/// <summary>A bitmask specifying how schema names can be used in text commands.</summary>
		[CorrespondingType(typeof(DBPROPVAL_SU), CorrespondingAction.Get)]
		DBPROP_SCHEMAUSAGE = 0x6b,

		/// <summary>
		/// Indicates the name of the server. This may be the same as the DBPROP_INIT_DATASOURCE property if the server name is used to
		/// define the data source object that the user specifies when connecting, or may be the actual name of the server if the provider
		/// connects through "friendly" data source object names.
		/// </summary>
		[CorrespondingType(typeof(string), CorrespondingAction.Get)]
		DBPROP_SERVER_NAME = DBPROP_SERVERNAME,

		/// <summary>
		/// DBPROP_SERVERCURSOR works in conjunction with other cursor properties, including DBPROP_CLIENTCURSOR, to determine where a
		/// cursor, if required, is materialized.
		/// </summary>
		[CorrespondingType(typeof(bool))]
		DBPROP_SERVERCURSOR = 0x6c,

		/// <summary>
		/// <para>VARIANT_TRUE</para>
		/// <para>
		/// After an insert is transmitted to the server (when IRowsetChange::InsertRow is called in immediate mode or when
		/// IRowsetUpdate::Update is called for an inserted row in deferred update mode), the consumer can call IRowset::GetData to retrieve
		/// the actual values that appeared in the data store, including calculated columns and defaults not explicitly set in the call to IRowsetChange::InsertRow.
		/// </para>
		/// <para>VARIANT_FALSE</para>
		/// <para>
		/// The provider does not retrieve values from the data store for newly inserted rows. The consumer can retrieve only data values
		/// explicitly set in the call to IRowsetChange::InsertRow or by calls to IRowsetChange::SetData for the hRow returned by InsertRow.
		/// </para>
		/// </summary>
		[CorrespondingType(typeof(bool))]
		DBPROP_SERVERDATAONINSERT = 0xef,

		/// <summary>
		/// Indicates the name of the server. This may be the same as the DBPROP_INIT_DATASOURCE property if the server name is used to
		/// define the data source object that the user specifies when connecting, or may be the actual name of the server if the provider
		/// connects through "friendly" data source object names.
		/// </summary>
		[CorrespondingType(typeof(string), CorrespondingAction.Get)]
		DBPROP_SERVERNAME = 0xfa,

		/// <summary>A bitmask specifying the transaction isolation level while in auto-commit mode.</summary>
		[CorrespondingType(typeof(DBPROPVAL_TI))]
		DBPROP_SESS_AUTOCOMMITISOLEVELS = 0xbe,

		/// <summary>
		/// When set, requires a provider that supports multiple results to either return or skip control row count results on calls to
		/// IMultipleResults::GetResult. Providers that support multiple results but do not support this property return results for each statement.
		/// </summary>
		[CorrespondingType(typeof(bool))]
		DBPROP_SKIPROWCOUNTRESULTS = 0x123,

		/// <summary>
		/// <para>VARIANT_TRUE</para>
		/// <para>The provider supports IViewSort::SetSortOrder only for columns contained in an index.</para>
		/// <para>VARIANT_FALSE</para>
		/// <para>
		/// The provider does not require columns to be indexed in order to be specified in IViewSort::SetSortOrder, or the provider does not
		/// support IViewSort::SetSortOrder.
		/// </para>
		/// </summary>
		[CorrespondingType(typeof(bool), CorrespondingAction.Get)]
		DBPROP_SORTONINDEX = 0xcf,

		/// <summary>A bitmask specifying the level of support for SQL.</summary>
		[CorrespondingType(typeof(DBPROPVAL_SQL), CorrespondingAction.Get)]
		DBPROP_SQLSUPPORT = 0x6d,

		/// <summary/>
		DBPROP_STORAGEFLAGS = 0xf0,

		/// <summary>
		/// <para>VARIANT_TRUE</para>
		/// <para>The handles of newly inserted rows can be compared as specified by DBPROP_LITERALIDENTITY.</para>
		/// <para>VARIANT_FALSE</para>
		/// <para>
		/// There is no guarantee that the handles of newly inserted rows can be compared successfully. In this case,
		/// IRowsetIdentity::IsSameRow might return DB_E_NEWLYINSERTED.
		/// </para>
		/// </summary>
		[CorrespondingType(typeof(bool), CorrespondingAction.Get)]
		DBPROP_STRONGIDENTITY = 0x77,

		/// <summary>
		/// A bitmask specifying what interfaces the rowset supports on storage objects. If a provider can support any of these interfaces,
		/// it is also required to support ISequentialStream
		/// </summary>
		[CorrespondingType(typeof(DBPROPVAL_SS), CorrespondingAction.Get)]
		DBPROP_STRUCTUREDSTORAGE = 0x6f,

		/// <summary>A bitmask specifying the predicates in text commands that support subqueries.</summary>
		[CorrespondingType(typeof(DBPROPVAL_SQ), CorrespondingAction.Get)]
		DBPROP_SUBQUERIES = 0x70,

		/// <summary>Indicates the relationship of transactions to table and index modification data definition language (DDL) statements.</summary>
		[CorrespondingType(typeof(DBPROPVAL_TC), CorrespondingAction.Get)]
		DBPROP_SUPPORTEDTXNDDL = 0xa1,

		/// <summary>A bitmask specifying the supported transaction isolation levels.</summary>
		[CorrespondingType(typeof(DBPROPVAL_TI), CorrespondingAction.Get)]
		DBPROP_SUPPORTEDTXNISOLEVELS = 0x71,

		/// <summary>A bitmask specifying the supported transaction isolation retention levels.</summary>
		[CorrespondingType(typeof(DBPROPVAL_TR), CorrespondingAction.Get)]
		DBPROP_SUPPORTEDTXNISORETAIN = 0x72,

		/// <summary>Bitmask indicating statistics support.</summary>
		[CorrespondingType(typeof(DBPROPVAL_TS), CorrespondingAction.Get)]
		DBPROP_TABLESTATISTICS = 0x120,

		/// <summary>
		/// Indicates the name the data source object uses for a table ? for example, "table" or "file". This is used for building user interfaces.
		/// </summary>
		[CorrespondingType(typeof(string), CorrespondingAction.Get)]
		DBPROP_TABLETERM = 0x73,

		/// <summary>Indicates whether the table is temporary.</summary>
		[CorrespondingType(typeof(bool))]
		DBPROP_TBL_TEMPTABLE = 0x8c,

		/// <summary>
		/// <para>VARIANT_TRUE</para>
		/// <para>
		/// Any object created on the specified column is transacted. That is, data made visible to the data store through the object can be
		/// committed with ITransaction::Commit or aborted with ITransaction::Abort.
		/// </para>
		/// <para>VARIANT_FALSE</para>
		/// <para>
		/// Any object created on the specified column is not transacted. That is, all changes to the object are permanent once they are made
		/// visible to the data store.
		/// </para>
		/// </summary>
		[CorrespondingType(typeof(bool))]
		DBPROP_TRANSACTEDOBJECT = 0x74,

		/// <summary/>
		DBPROP_TRUSTEE_AUTHENTICATION = 0xf2,

		/// <summary/>
		DBPROP_TRUSTEE_NEWAUTHENTICATION = 0xf3,

		/// <summary/>
		DBPROP_TRUSTEE_USERNAME = 0xf1,

		/// <summary>Indicates if each row is uniquely identified by its column values.</summary>
		[CorrespondingType(typeof(bool))]
		DBPROP_UNIQUEROWS = 0xee,

		/// <summary>A bitmask specifying the supported methods on IRowsetChange.</summary>
		[CorrespondingType(typeof(DBPROPVAL_UP))]
		DBPROP_UPDATABILITY = 0x75,

		/// <summary>A character string with the name used in a particular database, which can be different than a login name.</summary>
		[CorrespondingType(typeof(string), CorrespondingAction.Get)]
		DBPROP_USERNAME = 0x76,

		/// <summary>This is an OLE DB for OLAP property.</summary>
		[CorrespondingType(typeof(MDPROPVAL_AU), CorrespondingAction.Get)]
		MDPROP_AGGREGATECELL_UPDATE = 0xe6,

		/// <summary>
		/// This is an OLE DB for OLAP property. The value of this property is the maximum number of axes that the provider supports in the
		/// dataset. To be compliant with OLE DB for OLAP, this value must be at least 3.
		/// </summary>
		[CorrespondingType(typeof(int), CorrespondingAction.Get)]
		MDPROP_AXES = 0xfc,

		/// <summary>This is an OLE DB for OLAP property.</summary>
		[CorrespondingType(typeof(MDPROPVAL_FS), CorrespondingAction.Get)]
		MDPROP_FLATTENING_SUPPORT = 0xfd,

		/// <summary>This is an OLE DB for OLAP property.</summary>
		[CorrespondingType(typeof(MDPROPVAL_AU), CorrespondingAction.Get)]
		MDPROP_MDX_AGGREGATECELL_UPDATE = MDPROP_AGGREGATECELL_UPDATE,

		/// <summary>This is an OLE DB for OLAP property. A bitmask that specifies the support in a provider for case statements.</summary>
		[CorrespondingType(typeof(MDPROPVAL_MC), CorrespondingAction.Get)]
		MDPROP_MDX_CASESUPPORT = 0xde,

		MDPROP_MDX_CUBEQUALIFICATION = 0xdb,

		/// <summary>Support for various &lt;desc flag&gt; values in the DESCENDANTS function. This is an OLE DB for OLAP property.</summary>
		[CorrespondingType(typeof(MDPROPVAL_MD), CorrespondingAction.Get)]
		MDPROP_MDX_DESCFLAGS = 0xe1,

		/// <summary>Support for creation of named sets and calculated members</summary>
		[CorrespondingType(typeof(MDPROPVAL_MF), CorrespondingAction.Get)]
		MDPROP_MDX_FORMULAS = 0xe5,

		/// <summary>Support for query joining multiple cubes</summary>
		[CorrespondingType(typeof(MDPROPVAL_MJC), CorrespondingAction.Get)]
		MDPROP_MDX_JOINCUBES = 0xfe,

		/// <summary>Support for various member functions</summary>
		[CorrespondingType(typeof(MDPROPVAL_MMF), CorrespondingAction.Get)]
		MDPROP_MDX_MEMBER_FUNCTIONS = 0xe3,

		/// <summary>The capabilities in the &lt;numeric_value_expression&gt; argument of set functions</summary>
		[CorrespondingType(typeof(MDPROPVAL_NME), CorrespondingAction.Get)]
		MDPROP_MDX_NONMEASURE_EXPRESSIONS = 0x106,

		/// <summary>Support for various numeric functions</summary>
		[CorrespondingType(typeof(MDPROPVAL_MNF), CorrespondingAction.Get)]
		MDPROP_MDX_NUMERIC_FUNCTIONS = 0xe4,

		/// <summary>A bitmask specifying how multidimensional schema object names can be qualified in an MDX statement.</summary>
		[CorrespondingType(typeof(MDPROPVAL_MOQ), CorrespondingAction.Get)]
		MDPROP_MDX_OBJQUALIFICATION = 0x105,

		/// <summary>Support for outer reference in an MDX statement</summary>
		MDPROP_MDX_OUTERREFERENCE = 0xdc,

		/// <summary>Support for querying by property values in an MDX statement</summary>
		[CorrespondingType(typeof(bool), CorrespondingAction.Get)]
		MDPROP_MDX_QUERYBYPROPERTY = 0xdd,

		/// <summary>Support for various set functions.</summary>
		[CorrespondingType(typeof(MDPROPVAL_MSF), CorrespondingAction.Get)]
		MDPROP_MDX_SET_FUNCTIONS = 0xe2,

		/// <summary>The capabilities in the WHERE clause of an MDX statement</summary>
		[CorrespondingType(typeof(MDPROPVAL_MS), CorrespondingAction.Get)]
		MDPROP_MDX_SLICER = 0xda,

		/// <summary>Support for string comparison operators other than equals and not-equals operators</summary>
		[CorrespondingType(typeof(MDPROPVAL_MSC), CorrespondingAction.Get)]
		MDPROP_MDX_STRING_COMPOP = 0xe0,

		/// <summary>A bitmask specifying whether the provider supports named levels and/or numbered levels.</summary>
		[CorrespondingType(typeof(MDPROPVAL_NL), CorrespondingAction.Get)]
		MDPROP_NAMED_LEVELS = 0xff,

		/// <summary>Support for cell updates</summary>
		[CorrespondingType(typeof(MDPROPVAL_RR), CorrespondingAction.Get)]
		MDPROP_RANGEROWSET = 0x100,

		/// <summary>
		/// Indicates whether the provider is to calculate visual totals, which dynamically totals child members of parent members specified
		/// in a set. When visual totals mode is on, displayed aggregate values are equal to the sum of the displayed values being
		/// aggregated. Can be one or more of the values described in the following table.
		/// </summary>
		[CorrespondingType(typeof(MDPROPVAL_VISUAL_MODE), CorrespondingAction.Set)]
		MDPROP_VISUALMODE = 0x125,
	}

	[Flags]
	public enum DBPROPFLAGS : uint
	{
		DBPROPFLAGS_NOTSUPPORTED,
		DBPROPFLAGS_COLUMN = 0x1,
		DBPROPFLAGS_DATASOURCE = 0x2,
		DBPROPFLAGS_DATASOURCECREATE = 0x4,
		DBPROPFLAGS_DATASOURCEINFO = 0x8,
		DBPROPFLAGS_DBINIT = 0x10,
		DBPROPFLAGS_INDEX = 0x20,
		DBPROPFLAGS_ROWSET = 0x40,
		DBPROPFLAGS_TABLE = 0x80,
		DBPROPFLAGS_COLUMNOK = 0x100,
		DBPROPFLAGS_READ = 0x200,
		DBPROPFLAGS_WRITE = 0x400,
		DBPROPFLAGS_REQUIRED = 0x800,
		DBPROPFLAGS_SESSION = 0x1000,
		DBPROPFLAGS_TRUSTEE = 0x2000,
		DBPROPFLAGS_VIEW = 0x4000,
		DBPROPFLAGS_STREAM = 0x8000
	}

	[Flags]
	public enum DBPROPOPTIONS : uint
	{
		DBPROPOPTIONS_REQUIRED,
		DBPROPOPTIONS_SETIFCHEAP = 0x1,
		DBPROPOPTIONS_OPTIONAL = 0x1
	}

	// DBPROPOPTIONS_SETIFCHEAP is deprecated; use DBPROPOPTIONS_OPTIONAL instead.
	public enum DBPROPSTATUS
	{
		DBPROPSTATUS_OK,
		DBPROPSTATUS_NOTSUPPORTED = 1,
		DBPROPSTATUS_BADVALUE = 2,
		DBPROPSTATUS_BADOPTION = 3,
		DBPROPSTATUS_BADCOLUMN = 4,
		DBPROPSTATUS_NOTALLSETTABLE = 5,
		DBPROPSTATUS_NOTSETTABLE = 6,
		DBPROPSTATUS_NOTSET = 7,
		DBPROPSTATUS_CONFLICTING = 8,
		DBPROPSTATUS_NOTAVAILABLE = 9
	}

	/// <summary>Values for <see cref="DBPROPENUM.DBPROP_ACCESSORDER"/> property.</summary>
	public enum DBPROPVAL_AO
	{
		/// <summary>Columns can be accessed in any order.</summary>
		DBPROPVAL_AO_RANDOM = 0x00000002,

		/// <summary>
		/// <para>
		/// All columns must be accessed in sequential order determined by the column ordinal. Further, all columns from one row must be
		/// retrieved before calling IRowset::GetData on any columns in any subsequent row. Calling IRowset::GetData returns
		/// DBSTATUS_E_UNAVAILABLE for any columns for which any of the following are true:
		/// </para>
		/// <list type="bullet">
		/// <item>The column is bound as a storage object, and columns beyond it are specified in the accessor.</item>
		/// <item>Columns beyond the bound column have been accessed in a previous call to IRowset::GetData for that row.</item>
		/// <item>IRowset::GetData has been called for any columns on a row returned after the specified row.</item>
		/// </list>
		/// <para>
		/// Providers that never impose restrictions on column access ordering return DBPROPSTATUS_S_OK when this value is set. However, they
		/// upgrade the property to DBPROPVAL_AO_RANDOM such that calling IRowsetInfo::GetProperties continues to return DBPROPVAL_AO_RANDOM
		/// for this property.
		/// </para>
		/// <para>
		/// Providers may be able to optimize how data is retrieved if they know it will be read in column order. For instance, the provider
		/// may be able to read directly from a stream over the data if it knows the columns will be read in strictly sequential order, but
		/// may not be able to do so efficiently if the columns contain BLOBs that may be read in a random order.
		/// </para>
		/// </summary>
		DBPROPVAL_AO_SEQUENTIAL = 0x00000000,

		/// <summary>
		/// <para>
		/// Columns bound as storage objects can be accessed only in sequential order as determined by the column ordinal. Further, storage
		/// objects from one row must be retrieved before calling IRowset::GetData on any columns in any subsequent row. Calling
		/// IRowset::GetData on a column bound as a storage object returns DBSTATUS_E_UNAVAILABLE for any columns bound as storage objects if
		/// any of the following are true:
		/// </para>
		/// <list type="bullet">
		/// <item>Columns beyond the column bound as a storage object are specified in the accessor.</item>
		/// <item>
		/// Columns beyond the column bound as a storage object have been accessed in a previous call to IRowset::GetData for that row.
		/// </item>
		/// <item>IRowset::GetData has been called for any columns on a row returned after the specified row.</item>
		/// </list>
		/// <para>
		/// Providers that never impose restrictions on column access ordering return DBPROPSTATUS_S_OK when this value is set. However, they
		/// upgrade the property to DBPROPVAL_AO_RANDOM such that calling IRowsetInfo::GetProperties continues to return DBPROPVAL_AO_RANDOM
		/// for this property.
		/// </para>
		/// </summary>
		DBPROPVAL_AO_SEQUENTIALSTORAGEOBJECTS = 0x00000001,
	}

	/// <summary>A bitmask specifying the asynchronous processing performed on the data source object or rowset.</summary>
	[Flags]
	public enum DBPROPVAL_ASYNCH
	{
		/// <summary>
		/// The rowset is to be populated asynchronously in the background. The rowset supports IDBAsynchStatus to get information about the
		/// population of the rowset or abort background population and may support the connection point for IDBAsynchNotify to give status
		/// of the background population. DBPROPVAL_ASYNCH_BACKGROUNDPOPULATION is implied by DBPROPVAL_ASYNCH_SEQUENTIALPOPULATION and
		/// DBPROPVAL_ASYNCH_RANDOMPOPULATION; however, if DBPROPVAL_ASYNCH_SEQUENTIALPOPULATION or DBPROPVAL_ASYNCH_RANDOMPOPULATION is not
		/// also set, the rowset appears to the consumer as if it were being populated synchronously in that requesting rows will always
		/// block until the requested number of hRows are obtained or the end of the rowset is reached.
		/// </summary>
		DBPROPVAL_ASYNCH_BACKGROUNDPOPULATION = 0x00000008,

		/// <summary>
		/// <para>For DBPROPSET_DBINIT:</para>
		/// <para>
		/// IDBInitialize::Initialize returns immediately, but the actual initialization of the data source object is done asynchronously.
		/// The data source object behaves as an uninitialized data source object prior to completing the initialization process, except that
		/// any call to IDBInitialize returns E_UNEXPECTED.
		/// </para>
		/// <para>For DBPROPSET_ROWSET:</para>
		/// <para>
		/// The rowset is initialized asynchronously. The method requesting the rowset returns immediately, but attempting to call any
		/// interface other than IConnectionPointContainer to obtain the IID_IDBAsynchNotify connection point may fail and the full set of
		/// interfaces may not be available on the rowset until asynchronous initialization has completed.
		/// </para>
		/// </summary>
		DBPROPVAL_ASYNCH_INITIALIZE = 0x00000001,

		/// <summary>
		/// The consumer prefers to optimize for getting each individual request for data returned as quickly as possible. This is a hint to
		/// the provider to populate the rowset as the data is fetched. DBPROPVAL_ASYNCH_POPULATEONDEMAND is only a hint to the provider; the
		/// provider should never fail opening the rowset based on the setting of this flag and need not return it to the consumer, even if
		/// the rowset is populated on demand.
		/// </summary>
		DBPROPVAL_ASYNCH_POPULATEONDEMAND = 0x00000020,

		/// <summary>
		/// The consumer prefers to optimize for retrieving all data when the rowset is materialized. This is a hint to the provider to fetch
		/// all of the data up-front. DBPROPVAL_ASYNCH_PREPOPULATE is only a hint to the provider; the provider should never fail opening the
		/// rowset based on the setting of this flag and need not return it to the consumer, even if the rowset is prepopulated.
		/// </summary>
		DBPROPVAL_ASYNCH_PREPOPULATE = 0x00000010,

		/// <summary>
		/// <para>
		/// The rowset is randomly asynchronously populated; requests for rows may return DB_S_ENDOFROWSET before the end of the rowset is
		/// actually reached. Asynchronously populated rows may be inserted anywhere in the rowset.
		/// </para>
		/// <para>
		/// The consumer may set both DBPROPVAL_ASYNCH_SEQUENTIALPOPULATION and DBPROPVAL_ASYNCH_RANDOMPOPULATION bits to request that the
		/// rowset be asynchronously populated either sequentially or randomly. The consumer is prepared for asynchronous notifications in
		/// IRowsetNotify::OnRowChange as well as from IDBAsynchStatus. Only one property is returned by the rowset; if the rowset is
		/// asynchronously populated, it returns either DBPROPVAL_ASYNCH_RANDOMPOPULATION or DBPROPVAL_ASYNCH_SEQUENTIALPOPULATION.
		/// </para>
		/// <para>
		/// If no bits are set (the default), the rowset is initialized and populated synchronously. All requested interfaces are available
		/// when the method requesting the rowset returns, and requesting rows block until the requested number of hRows are obtained or the
		/// end of the rowset is reached.
		/// </para>
		/// </summary>
		DBPROPVAL_ASYNCH_RANDOMPOPULATION = 0x00000004,

		/// <summary>
		/// The rowset is sequentially asynchronously populated; requests for rows may return DB_S_ENDOFROWSET before the end of the rowset
		/// is actually reached. Asynchronously populated rows are always added to the end of the rowset.
		/// </summary>
		DBPROPVAL_ASYNCH_SEQUENTIALPOPULATION = 0x00000002,
	}

	public enum DBPROPVAL_BD
	{
		DBPROPVAL_BD_INTRANSACTION = 0x00000001,
		DBPROPVAL_BD_REORGANIZATION = 0x00000003,
		DBPROPVAL_BD_ROWSET = 0x00000000,
		DBPROPVAL_BD_XTRANSACTION = 0x00000002,
	}

	/// <summary>Values for <see cref="DBPROPENUM.DBPROP_BOOKMARKINFO"/></summary>
	public enum DBPROPVAL_BI
	{
		/// <summary>
		/// If set, bookmark values returned by this rowset are valid across rowsets with the same metadata. If not set, bookmark values are
		/// specific to this rowset and are not guaranteed to return the same values in other rowsets, even those resulting from the same specification.
		/// </summary>
		DBPROPVAL_BI_CROSSROWSET = 0x00000001
	}

	/// <summary>Values for <see cref="DBPROPENUM.DBPROP_BOOKMARKTYPE"/></summary>
	public enum DBPROPVAL_BMK
	{
		/// <summary>
		/// The bookmark type is key. Key bookmarks are based on the values of one or more of the row's columns; these values form a unique
		/// key for each row. A key bookmark may be left dangling if the key values of the corresponding row are changed.
		/// </summary>
		DBPROPVAL_BMK_KEY = 0x00000002,

		/// <summary>
		/// The bookmark type is numeric. Numeric bookmarks are based on a row property that is not dependent on the values of the row's
		/// columns. For example, they can be based on the absolute position of the row within a rowset or on a row ID that the storage
		/// engine assigned to a tuple at its creation. The validity of numeric bookmarks is not changed by modifying the row's columns.
		/// </summary>
		DBPROPVAL_BMK_NUMERIC = 0x00000001
	}

	/// <summary>
	/// A bitmask describing optimizations that a provider may take for updates to the rowset. These optimizations are usually used for
	/// things like bulk loading of a table. The following values can be specified and are usually set as OPTIONAL properties because they
	/// are hints to the provider. Additional bits may be defined in the future; providers should be prepared to handle new bits in this
	/// bitmask by ignoring them if the property is set as optional or by returning an error if the property is set as required.
	/// </summary>
	public enum DBPROPVAL_BO
	{
		/// <summary>
		/// The provider is not required to update indexes based on inserts or changes to the rowset. Any indexes need to be re-created
		/// following changes made through the rowset.
		/// </summary>
		DBPROPVAL_BO_NOINDEXUPDATE = 0x00000001,

		/// <summary>The provider is not required to log inserts or changes to the rowset.</summary>
		DBPROPVAL_BO_NOLOG = 0x00000000,

		/// <summary>Referential Integrity constraints do not need to be checked or enforced for changes made through the rowset.</summary>
		DBPROPVAL_BO_REFINTEGRITY = 0x00000002,
	}

	/// <summary>Indicates how aborting a transaction affects prepared commands.</summary>
	public enum DBPROPVAL_CB
	{
		/// <summary>Aborting a transaction deletes prepared commands. The application must reprepare commands before executing them.</summary>
		DBPROPVAL_CB_DELETE = 0x00000001,

		/// <summary>Aborting a transaction preserves prepared commands. The application can reexecute commands without repreparing them.</summary>
		DBPROPVAL_CB_PRESERVE = 0x00000002,
	}

	/// <summary>A bitmask defining the valid clauses for the definition of a column</summary>
	public enum DBPROPVAL_CD
	{
		/// <summary>
		/// Columns can be created non-nullable. For providers that support the SQL CREATE TABLE statement, this implies that the NOT NULL
		/// clause is supported in general. Individual provider data types may or may not support non-nullable behavior, and the consumer
		/// should consult the PROVIDER_TYPES schema rowset for more information.
		/// </summary>
		DBPROPVAL_CD_NOTNULL = 0x00000001,
	}

	/// <summary>Indicates the position of the catalog name in a qualified table name in a text command.</summary>
	public enum DBPROPVAL_CL
	{
		/// <summary>
		/// The catalog name is at the end of the fully qualified name. For example, an Oracle? server provider returns DBPROPVAL_CL_END
		/// because the catalog name is at the end of the table name, as in "mailto: ADMIN.EMP@EMPDATA".
		/// </summary>
		DBPROPVAL_CL_END = 0x00000002,

		/// <summary>
		/// The catalog name is at the start of the fully qualified name. For example, a dBASE? provider returns DBPROPVAL_CL_START because
		/// the directory (catalog name) is at the start of the table name ? for example, "\EMPDATA\Emp.dbf".
		/// </summary>
		DBPROPVAL_CL_START = 0x00000001,
	}

	/// <summary>A bitmask specifying the provider's support for COM services.</summary>
	[Flags]
	public enum DBPROPVAL_CM
	{
		/// <summary>
		/// The provider enlists in COM+ transactions directly. The provider either does not implement ITransactionLocal or returns
		/// XACT_E_XTIONEXISTS when ITransactionLocal::StartTransaction is called. The consumer can use this value to determine whether to
		/// use OLE DB or COM+ methods to commit or abort a transaction.
		/// </summary>
		DBPROPVAL_CM_TRANSACTIONS = 0x00000001,
	}

	/// <summary>
	/// Indicates how the data source object handles the concatenation of NULL-valued character data type columns with non?NULL-valued
	/// character data type columns.
	/// </summary>
	public enum DBPROPVAL_CNB
	{
		/// <summary>The result is NULL valued.</summary>
		DBPROPVAL_CB_NULL = 0x00000001,

		/// <summary>The result is the concatenation of the non?NULL-valued column or columns.</summary>
		DBPROPVAL_CB_NON_NULL = 0x00000002,
	}

	/// <summary>A bitmask describing the comparison operations supported by IViewFilter for a particular column.</summary>
	[Flags]
	public enum DBPROPVAL_CO
	{
		/// <summary>
		/// <para>Provider supports the following comparison operators:</para>
		/// <list type="bullet">
		/// <item>DBCOMPAREOPS_BEGINSWITH</item>
		/// <item>DBCOMPAREOPS_NOTBEGINSWITH</item>
		/// </list>
		/// </summary>
		DBPROPVAL_CO_BEGINSWITH = 0x00000020,

		/// <summary>Provider supports the DBCOMPAREOPS_CASEINSENSITIVE modifier.</summary>
		DBPROPVAL_CO_CASEINSENSITIVE = 0x00000008,

		/// <summary>Provider supports the DBCOMPAREOPS_CASESENSITIVE modifier.</summary>
		DBPROPVAL_CO_CASESENSITIVE = 0x00000004,

		/// <summary>
		/// <para>Provider supports the following comparison operators:</para>
		/// <list type="bullet">
		/// <item>DBCOMPAREOPS_CONTAINS</item>
		/// <item>DBCOMPAREOPS_NOTCONTAINS</item>
		/// </list>
		/// </summary>
		DBPROPVAL_CO_CONTAINS = 0x00000010,

		/// <summary>
		/// <para>Provider supports the following comparison operators:</para>
		/// <list type="bullet">
		/// <item>DBCOMPAREOPS_LT</item>
		/// <item>DBCOMPAREOPS_LE</item>
		/// <item>DBCOMPAREOPS_EQ</item>
		/// <item>DBCOMPAREOPS_GE</item>
		/// <item>DBCOMPAREOPS_GT</item>
		/// <item>DBCOMPAREOPS_NE</item>
		/// </list>
		/// </summary>
		DBPROPVAL_CO_EQUALITY = 0x00000001,

		/// <summary>Provider supports the comparison operator DBCOMPAREOPS_BEGINSWITH.</summary>
		DBPROPVAL_CO_STRING = 0x00000002,
	}

	/// <summary>Indicates the status of the current connection.</summary>
	public enum DBPROPVAL_CS
	{
		/// <summary>The data source object is unable to communicate with the data store.</summary>
		DBPROPVAL_CS_COMMUNICATIONFAILURE = 0x00000002,

		/// <summary>The data source object is in an initialized state and able to communicate with the data store.</summary>
		DBPROPVAL_CS_INITIALIZED = 0x00000001,

		/// <summary>The data source object is in an uninitialized state and unable to communicate with the data store.</summary>
		DBPROPVAL_CS_UNINITIALIZED = 0x00000000,
	}

	/// <summary>A bitmask specifying how catalog names can be used in text commands.</summary>
	[Flags]
	public enum DBPROPVAL_CU
	{
		/// <summary>Catalog names are supported in all data manipulation language (DML) statements.</summary>
		DBPROPVAL_CU_DML_STATEMENTS = 0x00000001,

		/// <summary>
		/// Catalog names are supported in all index definition statements and may apply only to the table name, not the index name,
		/// depending on the SQL implementation.
		/// </summary>
		DBPROPVAL_CU_INDEX_DEFINITION = 0x00000004,

		/// <summary>Catalog names are supported in all privilege definition statements.</summary>
		DBPROPVAL_CU_PRIVILEGE_DEFINITION = 0x00000008,

		/// <summary>Catalog names are supported in all table definition statements.</summary>
		DBPROPVAL_CU_TABLE_DEFINITION = 0x00000002,
	}

	public enum DBPROPVAL_DF
	{
		DBPROPVAL_DF_INITIALLY_DEFERRED = 0x01,
		DBPROPVAL_DF_INITIALLY_IMMEDIATE = 0x02,
		DBPROPVAL_DF_NOT_DEFERRABLE = 0x03,
	}

	/// <summary>Data Source Type</summary>
	public enum DBPROPVAL_DST
	{
		/// <summary>
		/// <para>
		/// The provider supports direct URL binding and is a document source provider. A consumer can expect a document source provider to
		/// exhibit the following behavior:
		/// </para>
		/// <list type="bullet">
		/// <item>When binding to a collection and requesting a rowset, the resource rowset defines the shape of that rowset.</item>
		/// <item>
		/// When creating a new row via ICreateRow::CreateRow, the container class is defined to be a folder and the default columns of the
		/// new row are the columns of the resource rowset.
		/// </item>
		/// </list>
		/// </summary>
		DBPROPVAL_DST_DOCSOURCE = 0x00000004,

		/// <summary>The provider is a multidimensional provider.</summary>
		DBPROPVAL_DST_MDP = 0x00000002,

		/// <summary>The provider is a tabular data provider.</summary>
		DBPROPVAL_DST_TDP = 0x00000001,

		/// <summary>The provider is both a TDP and an MDP.</summary>
		DBPROPVAL_DST_TDPANDMDP = 0x00000003,
	}

	public enum DBPROPVAL_FU
	{
		DBPROPVAL_FU_CATALOG = 0x00000008,
		DBPROPVAL_FU_COLUMN = 0x00000002,
		DBPROPVAL_FU_NOT_SUPPORTED = 0x00000001,
		DBPROPVAL_FU_TABLE = 0x00000004,
	}

	/// <summary>Indicates the relationship between the columns in a GROUP BY clause and the nonaggregated columns in the select list.</summary>
	[Flags]
	public enum DBPROPVAL_GB
	{
		/// <summary>A COLLATE clause can be specified at the end of each grouping column.</summary>
		DBPROPVAL_GB_COLLATE = 0x00000010,

		/// <summary>
		/// The GROUP BY clause must contain all nonaggregated columns in the select list. It can contain columns that are not in the select
		/// list ? for example, SELECT DEPT, MAX(SALARY) FROM EMPLOYEE GROUP BY DEPT, AGE.
		/// </summary>
		DBPROPVAL_GB_CONTAINS_SELECT = 0x00000004,

		/// <summary>
		/// The GROUP BY clause must contain all nonaggregated columns in the select list. It cannot contain any other columns ? for example,
		/// SELECT DEPT, MAX(SALARY) FROM EMPLOYEE GROUP BY DEPT.
		/// </summary>
		DBPROPVAL_GB_EQUALS_SELECT = 0x00000002,

		/// <summary>
		/// The columns in the GROUP BY clause and the select list are not related. The meaning of nongrouped, nonaggregated columns in the
		/// select list is data source object?dependent ? for example, SELECT DEPT, SALARY FROM EMPLOYEE GROUP BY DEPT, AGE.
		/// </summary>
		DBPROPVAL_GB_NO_RELATION = 0x00000008,

		/// <summary/>
		DBPROPVAL_GB_NOT_SUPPORTED = 0x00000001,
	}

	/// <summary>A bitmask indicating whether the provider requires data store?generated URLs for row creation and scoped operations.</summary>
	[Flags]
	public enum DBPROPVAL_GU
	{
		/// <summary>Consumers must specify full URLs of created rows or destinations for copy and move operations.</summary>
		DBPROPVAL_GU_NOTSUPPORTED = 0x00000001,

		/// <summary>The provider generates the URL suffix. Consumers must specify a path.</summary>
		DBPROPVAL_GU_SUFFIX = 0x00000002,
	}

	/// <summary>A bitmask specifying whether the provider can join tables from different catalogs or providers.</summary>
	[Flags]
	public enum DBPROPVAL_HT
	{
		/// <summary/>
		DBPROPVAL_HT_DIFFERENT_CATALOGS = 0x00000001,

		/// <summary/>
		DBPROPVAL_HT_DIFFERENT_PROVIDERS = 0x00000002,
	}

	/// <summary>
	/// Indicates how identifiers treat case in data definition commands or interfaces (such as IIndexDefinition, IAlterTable, IAlterIndex,
	/// ITableCreation, ITableDefinition, and ITableDefinitionWithConstraints). For SQL providers, this refers to SQL data definition
	/// commands and storage in system catalogs.
	/// </summary>
	public enum DBPROPVAL_IC
	{
		/// <summary>Identifiers in SQL are case-insensitive and are stored in lowercase.</summary>
		DBPROPVAL_IC_LOWER = 0x00000002,

		/// <summary>Identifiers in SQL are case-insensitive and are stored in mixed case.</summary>
		DBPROPVAL_IC_MIXED = 0x00000008,

		/// <summary>Identifiers in SQL are case-sensitive and are stored in mixed case.</summary>
		DBPROPVAL_IC_SENSITIVE = 0x00000004,

		/// <summary>Identifiers in SQL are case-insensitive and are stored in uppercase.</summary>
		DBPROPVAL_IC_UPPER = 0x00000001,
	}

	/// <summary>Indicates whether NULL keys are allowed.</summary>
	public enum DBPROPVAL_IN
	{
		/// <summary>The index allows entries where the key columns are NULL and sorts according to the collation described by DBPROP_INDEX_NULLCOLLATION.</summary>
		DBPROPVAL_IN_ALLOWNULL = 0x00000000,

		/// <summary>
		/// The index does not allow entries where the key columns are NULL. If the consumer attempts to insert an index entry with a NULL
		/// key, the provider returns an error.
		/// </summary>
		DBPROPVAL_IN_DISALLOWNULL = 0x00000001,

		/// <summary>
		/// The index does not insert entries where some column key has a NULL value. For an index having a multicolumn search key, if the
		/// consumer inserts an index entry with NULL value in some column of the search key, the provider ignores that entry and no error
		/// code is returned.
		/// </summary>
		DBPROPVAL_IN_IGNOREANYNULL = 0x00000004,

		/// <summary>
		/// The index does not insert entries containing NULL keys. If the consumer attempts to insert an index entry with a NULL key, the
		/// provider ignores that entry and no error code is returned.
		/// </summary>
		DBPROPVAL_IN_IGNORENULL = 0x00000002,
	}

	/// <summary>Indicates the type of the index.</summary>
	public enum DBPROPVAL_IT
	{
		/// <summary>The index is a B+-tree.</summary>
		DBPROPVAL_IT_BTREE = 0x00000001,

		/// <summary>The index is a content index.</summary>
		DBPROPVAL_IT_CONTENT = 0x00000003,

		/// <summary>The index is a hash file using linear or extensible hashing.</summary>
		DBPROPVAL_IT_HASH = 0x00000002,

		/// <summary>The index is some other type of index.</summary>
		DBPROPVAL_IT_OTHER = 0x00000004,
	}

	/// <summary>Indicates the level of locking performed by the rowset.</summary>
	public enum DBPROPVAL_LM
	{
		/// <summary/>
		DBPROPVAL_LM_INTENT = 0x00000004,

		/// <summary>
		/// The provider is not required to lock rows at any time to ensure successful updates. Updates may fail when sent to the server for
		/// reasons of concurrency (for example, if someone else has updated the row).
		/// </summary>
		DBPROPVAL_LM_NONE = 0x00000001,

		/// <summary/>
		DBPROPVAL_LM_READ = 0x00000002,

		/// <summary/>
		DBPROPVAL_LM_RITE = 0x00000008,

		/// <summary>
		/// The provider uses the minimum level of locking necessary to ensure that changes successfully written to a single row returned by
		/// the most recent fetch will not fail due to a concurrency violation. Therefore, when using deferred update mode,
		/// IRowsetUpdate::Update will not fail due to a concurrency violation. This may mean that the provider takes a lock on the row when
		/// IRowsetChange::SetData is first called on the row, but the provider may lock the row as early as when it is read in order to
		/// guarantee that operations on the row, such as updates, will succeed. The implications of DBPROPVAL_LM_SINGLEROW, and
		/// DBPROP_LOCKMODE in general, are the same in both immediate and deferred update modes.
		/// </summary>
		DBPROPVAL_LM_SINGLEROW = 0x00000002,
	}

	/// <summary>
	/// A bitmask specifying whether the provider supports multiple results objects and what restrictions it places on these objects.
	/// </summary>
	[Flags]
	public enum DBPROPVAL_MR
	{
		/// <summary>
		/// More than one rowset created by the same multiple results object can exist concurrently. If this bit is not set, the consumer
		/// must release the current rowset before calling IMultipleResults::GetResult to get the next result.
		/// </summary>
		DBPROPVAL_MR_CONCURRENT = 0x00000002,

		/// <summary>The provider does not support multiple results objects.</summary>
		DBPROPVAL_MR_NOTSUPPORTED = 0x00000000,

		/// <summary>The provider supports multiple results objects.</summary>
		DBPROPVAL_MR_SUPPORTED = 0x00000001,
	}

	/// <summary>Indicates how NULLs are collated in the index or sorted in a list.</summary>
	public enum DBPROPVAL_NC
	{
		/// <summary>NULLs are collated/sorted at the end of the list, regardless of the collation/sort order.</summary>
		DBPROPVAL_NC_END = 0x00000001,

		/// <summary>NULLs are collated/sorted at the high end of the list.</summary>
		DBPROPVAL_NC_HIGH = 0x00000002,

		/// <summary>NULLs are collated/sorted at the low end of the list.</summary>
		DBPROPVAL_NC_LOW = 0x00000004,

		/// <summary>NULLs are collated/sorted at the start of the list, regardless of the collation/sort order.</summary>
		DBPROPVAL_NC_START = 0x00000008,
	}

	/// <summary>A bitmask specifying the notification phases supported by the provider.</summary>
	[Flags]
	public enum DBPROPVAL_NP
	{
		/// <summary/>
		DBPROPVAL_NP_ABOUTTODO = 0x00000002,

		/// <summary/>
		DBPROPVAL_NP_DIDEVENT = 0x00000010,

		/// <summary/>
		DBPROPVAL_NP_FAILEDTODO = 0x00000008,

		/// <summary/>
		DBPROPVAL_NP_OKTODO = 0x00000001,

		/// <summary/>
		DBPROPVAL_NP_SYNCHAFTER = 0x00000004,
	}

	/// <summary>Notification Granularity</summary>
	public enum DBPROPVAL_NT
	{
		/// <summary>
		/// For each phase, and for methods that operate on multiple rows and generate multi-phased notifications, the provider calls
		/// OnRowChange once for all rows that succeed and once for all rows that fail. This separation can occur at each phase where a
		/// change can fail. For example, if IRowsetChange::DeleteRows deletes some rows and fails to delete others during the Preliminary
		/// Work phase, it calls OnRowChange twice: once with DBEVENTPHASE_SYNCHAFTER and the array of handles of rows that it deleted, and
		/// once with DBEVENTPHASE_FAILEDTODO and the array of handles of rows it failed to delete. A cancellation affects all rows with
		/// handles that were passed to OnRowChange.
		/// </summary>
		DBPROPVAL_NT_MULTIPLEROWS = 0x00000002,

		/// <summary>
		/// For methods that operate on multiple rows and generate multi-phased notifications, the provider calls IRowsetNotify::OnRowChange
		/// separately for each phase for each row. A cancellation affects a single row; it does not affect the other rows, and notifications
		/// are still sent for these rows.
		/// </summary>
		DBPROPVAL_NT_SINGLEROW = 0x00000001,
	}

	/// <summary>Indicates the time at which output parameter values become available.</summary>
	public enum DBPROPVAL_OA
	{
		/// <summary>Output parameter data is available immediately after ICommand::Execute returns.</summary>
		DBPROPVAL_OA_ATEXECUTE = 0x00000002,

		/// <summary>
		/// If a command returns a single result that is a rowset, output parameter data is available at the time the rowset is completely
		/// released. If a command returns multiple results, output parameter data is available when IMultipleResults::GetResult returns
		/// DB_S_NORESULT or the multiple results object is completely released, whichever occurs first. Before the output parameter data is
		/// available, the consumer's bound memory is in an indeterminate state. For more information about multiple results, see Multiple Results.
		/// </summary>
		DBPROPVAL_OA_ATROWRELEASE = 0x00000004,

		/// <summary>Output parameters are not supported.</summary>
		DBPROPVAL_OA_NOTSUPPORTED = 0x00000001,
	}

	/// <summary>A bitmask specifying the ways in which the provider supports access to BLOBs and COM objects stored in columns.</summary>
	[Flags]
	public enum DBPROPVAL_OO
	{
		/// <summary>
		/// The provider supports access to BLOBs as structured storage objects. A consumer determines what interfaces are supported through DBPROP_STRUCTUREDSTORAGE.
		/// </summary>
		DBPROPVAL_OO_BLOB = 0x00000001,

		/// <summary>
		/// The provider supports direct binding. If this bit is set, the IBindResource and ICreateRow interfaces are supported on the
		/// session object and the provider implements a provider binder object.
		/// </summary>
		DBPROPVAL_OO_DIRECTBIND = 0x00000010,

		/// <summary>The provider supports access to COM objects through IPersistStream, IPersistStreamInit, or IPersistStorage.</summary>
		DBPROPVAL_OO_IPERSIST = 0x00000002,

		/// <summary>
		/// The provider supports row objects. IGetRow is supported on rowsets. Row objects support the mandatory interfaces IRow,
		/// IGetSession, IColumnsInfo, and IConvertType. If the provider supports direct URL binding, it must support binding to row objects
		/// by passing DBGUID_ROW in IBindResource::Bind and, if supported, ICreateRow::CreateRow.
		/// </summary>
		DBPROPVAL_OO_ROWOBJECT = 0x00000004,

		/// <summary>Indicates that row objects implement IScopedOperations.</summary>
		DBPROPVAL_OO_SCOPED = 0x00000008,

		/// <summary>
		/// The provider supports singleton selects. The provider supports the return of row objects on ICommand::Execute and IOpenRowset::OpenRowset.
		/// </summary>
		DBPROPVAL_OO_SINGLETON = 0x00000020,
	}

	[Flags]
	public enum DBPROPVAL_OP
	{
		DBPROPVAL_OP_EQUAL = 0x00000001,
		DBPROPVAL_OP_RELATIVE = 0x00000002,
		DBPROPVAL_OP_STRING = 0x00000004,
	}

	/// <summary>A bitmask describing support for opening objects through IOpenRowset.</summary>
	[Flags]
	public enum DBPROPVAL_ORS
	{
		/// <summary>
		/// The provider supports opening a histogram rowset through the IOpenRowset::OpenRowset method. Providers supporting histograms
		/// should set this bit, as well as DBPROPVAL_TS_HISTOGRAM, in the DBPROP_TABLESTATISTICS property.
		/// </summary>
		DBPROPVAL_ORS_HISTOGRAM = 0x00000008,

		/// <summary>The provider supports specifying an index through IOpenRowset.</summary>
		DBPROPVAL_ORS_INDEX = 0x00000001,

		/// <summary>
		/// The provider supports specifying both a table and an index in the same call to IOpenRowset::OpenRowset in order to open the
		/// rowset using the specified index.
		/// </summary>
		DBPROPVAL_ORS_INTEGRATEDINDEX = 0x00000002,

		/// <summary>
		/// The provider supports opening a rowset over stored procedures by specifying the stored procedure name in TableID. For more
		/// information about TableID, see Rowset Creation Example.
		/// </summary>
		DBPROPVAL_ORS_STOREDPROC = 0x00000004,

		/// <summary>The provider supports opening tables through IOpenRowset (true for all providers).</summary>
		DBPROPVAL_ORS_TABLE = 0x00000000,
	}

	/// <summary>
	/// A bitmask specifying OLE DB services to enable or disable. To use this property, the provider must support service components and
	/// must have been invoked with IDataInitialize on the OLE DB Initialization core service. For more information about OLE DB services,
	/// see OLE DB Services. This property overrides the settings of the OLEDB_SERVICES registration key. For more information about these
	/// settings, see Overriding Provider Service Defaults and related topics.
	/// </summary>
	[Flags]
	public enum DBPROPVAL_OS
	{
		/// <summary>
		/// Indicates support for services operating beyond the session level, such as the Client Cursor Engine. For maximum performance,
		/// consumers should not set this bit if such services are not required. The setting for DBPROPVAL_OS_AGR_AFTERSESSION will be
		/// ignored if contraindicated by another bit setting. For example, if DBPROPVAL_OS_CLIENTCURSOR is set, the value for
		/// DBPROPVAL_OS_AGR_AFTERSESSION is ignored.
		/// </summary>
		DBPROPVAL_OS_AGR_AFTERSESSION = 0x00000008,

		/// <summary>
		/// Enables the Client Cursor Engine as needed, to support rowset behavior requested by the consumer and not implemented by the
		/// native provider. When this bit is set, the value for DBPROPVAL_OS_AGR_AFTERSESSION is ignored.
		/// </summary>
		DBPROPVAL_OS_CLIENTCURSOR = 0x00000004,

		/// <summary>All services should be disabled.</summary>
		DBPROPVAL_OS_DISABLEALL = 0x00000000,

		/// <summary>
		/// All services should be invoked. By default, all services are enabled and invoked as requested. Individual services can be
		/// deselected by specifying the bitwise-AND of DBPROPVAL_OS_ENABLEALL along with the bitwise complement of any services to be
		/// deselected. For example, DBPROPVAL_OS_ENABLEALL &amp;~DBPROPVAL_OS_TXNENLISTMENT enables all services except automatic
		/// transaction enlistment in the Component Services environment.
		/// </summary>
		DBPROPVAL_OS_ENABLEALL = unchecked((int)0xffffffff),

		/// <summary>Resources should be pooled.</summary>
		DBPROPVAL_OS_RESOURCEPOOLING = 0x00000001,

		/// <summary>
		/// Sessions in a Component Services (or MTS, if you are using Microsoft? Windows NT?) environment should automatically be enlisted
		/// in a global transaction where required.
		/// </summary>
		DBPROPVAL_OS_TXNENLISTMENT = 0x00000002,
	}

	/// <summary>
	/// An integer specifying the type of DBID that the provider uses when persisting DBIDs that name entities in the data store, such as
	/// tables, indexes, columns, commands, or constraints. This is generally the type of DBID that the provider considers the most permanent
	/// under schema changes and physical data reorganizations.
	/// </summary>
	public enum DBPROPVAL_PT
	{
		/// <summary/>
		DBPROPVAL_PT_GUID = 0x00000008,

		/// <summary/>
		DBPROPVAL_PT_GUID_NAME = 0x00000001,

		/// <summary/>
		DBPROPVAL_PT_GUID_PROPID = 0x00000002,

		/// <summary/>
		DBPROPVAL_PT_NAME = 0x00000004,

		/// <summary/>
		DBPROPVAL_PT_PGUID_NAME = 0x00000020,

		/// <summary/>
		DBPROPVAL_PT_PGUID_PROPID = 0x00000040,

		/// <summary/>
		DBPROPVAL_PT_PROPID = 0x00000010,
	}

	/// <summary>Indicates the data source object state should be reset.</summary>
	public enum DBPROPVAL_RD
	{
		/// <summary>
		/// The provider should reset all initialization properties and other states associated with the data source and session objects to
		/// their values at initialization time, with the exception that any transactions, including distributed transactions, remain active.
		/// Any open rowsets or commands must be released by the consumer prior to setting this property, or the provider may return
		/// DBPROPSTATUS_NOTSETTABLE. After successfully setting DBPROP_RESETDATASOURCE to DBPROPVAL_RD_RESETALL, the data source object
		/// appears as it did when initialized, with the exception that any open session objects and their transaction states are maintained.
		/// </summary>
		DBPROPVAL_RD_RESETALL = unchecked((int)0xffffffff),
	}

	/// <summary>A bitmask specifying the threading models supported by the data source object.</summary>
	[Flags]
	public enum DBPROPVAL_RT
	{
		/// <summary/>
		DBPROPVAL_RT_APTMTTHREAD = 0x00000002,

		/// <summary/>
		DBPROPVAL_RT_FREETHREAD = 0x00000001,

		/// <summary/>
		DBPROPVAL_RT_SINGLETHREAD = 0x00000004,
	}

	/// <summary>A bitmask specifying the predicates in text commands that support subqueries.</summary>
	[Flags]
	public enum DBPROPVAL_SQ
	{
		/// <summary/>
		DBPROPVAL_SQ_COMPARISON = 0x00000002,

		/// <summary>Indicates that all predicates that support subqueries support correlated subqueries.</summary>
		DBPROPVAL_SQ_CORRELATEDSUBQUERIES = 0x00000001,

		/// <summary/>
		DBPROPVAL_SQ_EXISTS = 0x00000004,

		/// <summary/>
		DBPROPVAL_SQ_IN = 0x00000008,

		/// <summary/>
		DBPROPVAL_SQ_QUANTIFIED = 0x00000010,

		/// <summar>Indicates that subqueries are supported in place of tables (for example, in the FROM clause of an SQL statement).</summar>
		DBPROPVAL_SQ_TABLE = 0x00000020,
	}

	/// <summary>A bitmask specifying the level of support for SQL.</summary>
	[Flags]
	public enum DBPROPVAL_SQL
	{
		/// <summary>The provider supports the ANSI89 Integrity Enhancement Facility.</summary>
		DBPROPVAL_SQL_ANSI89_IEF = 0x00000008,

		/// <summary/>
		DBPROPVAL_SQL_ANSI92_ENTRY = 0x00000010,

		/// <summary>
		/// These levels correspond to the levels in ANSI SQL-92. These levels are cumulative. That is, if the provider supports one level,
		/// it also sets the bits for all lower levels.
		/// </summary>
		DBPROPVAL_SQL_ANSI92_FULL = 0x00000080,

		/// <summary/>
		DBPROPVAL_SQL_ANSI92_INTERMEDIATE = 0x00000040,

		/// <summary>The provider supports the ODBC escape clause syntax.</summary>
		DBPROPVAL_SQL_ESCAPECLAUSES = 0x00000100,

		/// <summary/>
		DBPROPVAL_SQL_FIPS_TRANSITIONAL = 0x00000020,

		/// <summary>SQL is not supported.</summary>
		DBPROPVAL_SQL_NONE = 0x00000000,

		/// <summary/>
		DBPROPVAL_SQL_ODBC_CORE = 0x00000002,

		/// <summary>
		/// These levels correspond to the levels of SQL conformance defined in ODBC version 2.5. These levels are cumulative. That is, if
		/// the provider supports one level, it also sets the bits for all lower levels. For example, if the provider sets the
		/// DBPROPVAL_SQL_ODBC_CORE bit, it also sets the DBPROPVAL_SQL_ODBC_MINIMUM bit.
		/// </summary>
		DBPROPVAL_SQL_ODBC_EXTENDED = 0x00000004,

		/// <summary/>
		DBPROPVAL_SQL_ODBC_MINIMUM = 0x00000001,

		/// <summary>
		/// The provider supports the DBGUID_SQL dialect and parses the command text according to SQL rules but does not support either the
		/// minimum ODBC level or the ANSI SQL-92 Entry level. This level is not cumulative; providers that support at least the minimal ODBC
		/// Level or ANSI SQL-92 Entry Level do not set this bit. OLE DB consumers can determine whether or not the provider supports the
		/// DBGUID_SQL dialect by verifying that the DBPROPVAL_SQL_NONE bit is not set.
		/// </summary>
		DBPROPVAL_SQL_SUBMINIMUM = 0x00000200,
	}

	/// <summary>
	/// A bitmask specifying what interfaces the rowset supports on storage objects. If a provider can support any of these interfaces, it is
	/// also required to support ISequentialStream
	/// </summary>
	[Flags]
	public enum DBPROPVAL_SS
	{
		/// <summary/>
		DBPROPVAL_SS_ILOCKBYTES = 0x00000008,

		/// <summary/>
		DBPROPVAL_SS_ISEQUENTIALSTREAM = 0x00000001,

		/// <summary/>
		DBPROPVAL_SS_ISTORAGE = 0x00000004,

		/// <summary/>
		DBPROPVAL_SS_ISTREAM = 0x00000002,
	}

	[Flags]
	public enum DBPROPVAL_STGM
	{
		DBPROPVAL_STGM_CONVERT = 0x00040000,
		DBPROPVAL_STGM_CREATE = (int)Kernel32.OpenFileAction.OF_CREATE,
		DBPROPVAL_STGM_DELETEONRELEASE = 0x00200000,
		DBPROPVAL_STGM_DIRECT = 0x00010000,
		DBPROPVAL_STGM_FAILIFTHERE = 0x00080000,
		DBPROPVAL_STGM_PRIORITY = 0x00100000,
		DBPROPVAL_STGM_READ = (int)Kernel32.OpenFileAction.OF_READ,
		DBPROPVAL_STGM_READWRITE = (int)Kernel32.OpenFileAction.OF_READWRITE,
		DBPROPVAL_STGM_SHARE_DENY_NONE = (int)Kernel32.OpenFileAction.OF_SHARE_DENY_NONE,
		DBPROPVAL_STGM_SHARE_DENY_READ = (int)Kernel32.OpenFileAction.OF_SHARE_DENY_READ,
		DBPROPVAL_STGM_SHARE_DENY_WRITE = (int)Kernel32.OpenFileAction.OF_SHARE_DENY_WRITE,
		DBPROPVAL_STGM_SHARE_EXCLUSIVE = (int)Kernel32.OpenFileAction.OF_SHARE_EXCLUSIVE,
		DBPROPVAL_STGM_TRANSACTED = 0x00020000,
		DBPROPVAL_STGM_WRITE = (int)Kernel32.OpenFileAction.OF_WRITE,
	}

	/// <summary>A bitmask specifying how schema names can be used in text commands.</summary>
	[Flags]
	public enum DBPROPVAL_SU
	{
		/// <summary>Schema names are supported in all data manipulation language (DML) statements.</summary>
		DBPROPVAL_SU_DML_STATEMENTS = 0x00000001,

		/// <summary>
		/// Schema names are supported in all index definition statements and may apply only to the table name, not the index name, depending
		/// on the SQL implementation.
		/// </summary>
		DBPROPVAL_SU_INDEX_DEFINITION = 0x00000004,

		/// <summary>Schema names are supported in all privilege definition statements.</summary>
		DBPROPVAL_SU_PRIVILEGE_DEFINITION = 0x00000008,

		/// <summary>Schema names are supported in all table definition statements.</summary>
		DBPROPVAL_SU_TABLE_DEFINITION = 0x00000002,
	}

	/// <summary>Indicates the relationship of transactions to table and index modification data definition language (DDL) statements.</summary>
	[Flags]
	public enum DBPROPVAL_TC
	{
		/// <summary>Transactions can contain DML statements, as well as table or index modifications, in any order.</summary>
		DBPROPVAL_TC_ALL = 0x00000008,

		/// <summary>
		/// Transactions can contain only DML statements. Modifying tables or indexes within a transaction causes the transaction to be
		/// committed. The provider's commit mode remains unchanged in accordance with the value of DBPROP_COMMITPRESERVE. If the provider
		/// was in auto-commit mode, it remains in auto-commit mode, and likewise for manual-commit mode.
		/// </summary>
		DBPROPVAL_TC_DDL_COMMIT = 0x00000002,

		/// <summary>Transactions can contain only DML statements. Attempts to modify tables or indexes within a transaction are ignored.</summary>
		DBPROPVAL_TC_DDL_IGNORE = 0x00000004,

		/// <summary>
		/// Transactions can contain both DML and table or index modifications, but modifying a table or index within a transaction causes
		/// the table or index to be locked until the transaction completes.
		/// </summary>
		DBPROPVAL_TC_DDL_LOCK = 0x00000010,

		/// <summary>
		/// Transactions can contain only data manipulation language (DML) statements. Attempting to modify tables or indexes within a
		/// transaction causes an error.
		/// </summary>
		DBPROPVAL_TC_DML = 0x00000001,

		/// <summary>Transactions are not supported.</summary>
		DBPROPVAL_TC_NONE = 0x00000000,
	}

	/// <summary>A bitmask specifying the supported transaction isolation levels.</summary>
	[Flags]
	public enum DBPROPVAL_TI
	{
		/// <summary/>
		DBPROPVAL_TI_BROWSE = 0x00000100,

		/// <summary/>
		DBPROPVAL_TI_CHAOS = 0x00000010,

		/// <summary/>
		DBPROPVAL_TI_CURSORSTABILITY = 0x00001000,

		/// <summary/>
		DBPROPVAL_TI_ISOLATED = 0x00100000,

		/// <summary/>
		DBPROPVAL_TI_READCOMMITTED = 0x00001000,

		/// <summary/>
		DBPROPVAL_TI_READUNCOMMITTED = 0x00000100,

		/// <summary/>
		DBPROPVAL_TI_REPEATABLEREAD = 0x00010000,

		/// <summary/>
		DBPROPVAL_TI_SERIALIZABLE = 0x00100000,
	}

	/// <summary>A bitmask specifying the supported transaction isolation retention levels.</summary>
	[Flags]
	public enum DBPROPVAL_TR
	{
		/// <summary>The transaction preserves its isolation context across a retaining abort.</summary>
		DBPROPVAL_TR_ABORT = 0x00000010,

		/// <summary>The transaction may either preserve or dispose of isolation context across a retaining abort.</summary>
		DBPROPVAL_TR_ABORT_DC = 0x00000008,

		/// <summary>The transaction is explicitly not to preserve isolation across a retaining abort.</summary>
		DBPROPVAL_TR_ABORT_NO = 0x00000020,

		/// <summary>Isolation is preserved across both a retaining commit and a retaining abort.</summary>
		DBPROPVAL_TR_BOTH = 0x00000080,

		/// <summary>
		/// The transaction preserves its isolation context (that is, it preserves its locks, if that is how isolation is implemented) across
		/// a retaining commit.
		/// </summary>
		DBPROPVAL_TR_COMMIT = 0x00000002,

		/// <summary>The transaction may either preserve or dispose of isolation context across a retaining commit.</summary>
		DBPROPVAL_TR_COMMIT_DC = 0x00000001,

		/// <summary>The transaction is explicitly not to preserve isolation across a retaining commit.</summary>
		DBPROPVAL_TR_COMMIT_NO = 0x00000004,

		/// <summary>The transaction may preserve or dispose of isolation context across a retaining commit or abort. This is the default.</summary>
		DBPROPVAL_TR_DONTCARE = 0x00000040,

		/// <summary>Isolation is explicitly not to be retained across either a retaining commit or a retaining abort.</summary>
		DBPROPVAL_TR_NONE = 0x00000100,

		/// <summary>
		/// Optimistic concurrency control is to be used. If DBPROPVAL_TR_OPTIMISTIC is specified, and then whatever isolation technology is
		/// in place (such as locking), it must be the case that other transactions' ability to make changes to the data and resources
		/// manipulated by this transaction is not in any way affected by the data read or updated by this transaction. That is, optimistic
		/// control is to be used for all data in the transaction.
		/// </summary>
		DBPROPVAL_TR_OPTIMISTIC = 0x00000200,
	}

	/// <summary>Bitmask indicating statistics support.</summary>
	public enum DBPROPVAL_TS
	{
		/// <summary>Supports column and tuple cardinality information on columns in a statistic.</summary>
		DBPROPVAL_TS_CARDINALITY = 0x00000001,

		/// <summary>
		/// Supports histogram information on the first column of a statistic. Providers supporting histograms should set this bit, as well
		/// as DBPROPVAL_ORS_HISTOGRAM, in the DBPROP_OPENROWSETSUPPORT property.
		/// </summary>
		DBPROPVAL_TS_HISTOGRAM = 0x00000002,
	}

	/// <summary>A bitmask specifying the supported methods on IRowsetChange.</summary>
	[Flags]
	public enum DBPROPVAL_UP
	{
		/// <summary>IRowsetChange::SetData is supported.</summary>
		DBPROPVAL_UP_CHANGE = 0x00000001,

		/// <summary>IRowsetChange::DeleteRows is supported.</summary>
		DBPROPVAL_UP_DELETE = 0x00000002,

		/// <summary>IRowsetChange::InsertRow is supported.</summary>
		DBPROPVAL_UP_INSERT = 0x00000004,
	}

	public enum DBREASON
	{
		DBREASON_ROWSET_FETCHPOSITIONCHANGE,
		DBREASON_ROWSET_RELEASE = DBREASON_ROWSET_FETCHPOSITIONCHANGE + 1,
		DBREASON_COLUMN_SET = DBREASON_ROWSET_RELEASE + 1,
		DBREASON_COLUMN_RECALCULATED = DBREASON_COLUMN_SET + 1,
		DBREASON_ROW_ACTIVATE = DBREASON_COLUMN_RECALCULATED + 1,
		DBREASON_ROW_RELEASE = DBREASON_ROW_ACTIVATE + 1,
		DBREASON_ROW_DELETE = DBREASON_ROW_RELEASE + 1,
		DBREASON_ROW_FIRSTCHANGE = DBREASON_ROW_DELETE + 1,
		DBREASON_ROW_INSERT = DBREASON_ROW_FIRSTCHANGE + 1,
		DBREASON_ROW_RESYNCH = DBREASON_ROW_INSERT + 1,
		DBREASON_ROW_UNDOCHANGE = DBREASON_ROW_RESYNCH + 1,
		DBREASON_ROW_UNDOINSERT = DBREASON_ROW_UNDOCHANGE + 1,
		DBREASON_ROW_UNDODELETE = DBREASON_ROW_UNDOINSERT + 1,
		DBREASON_ROW_UPDATE = DBREASON_ROW_UNDODELETE + 1,
		DBREASON_ROWSET_CHANGED = DBREASON_ROW_UPDATE + 1,
		DBREASON_ROWPOSITION_CHANGED = DBREASON_ROWSET_CHANGED + 1,
		DBREASON_ROWPOSITION_CHAPTERCHANGED = DBREASON_ROWPOSITION_CHANGED + 1,
		DBREASON_ROWPOSITION_CLEARED = DBREASON_ROWPOSITION_CHAPTERCHANGED + 1,
		DBREASON_ROW_ASYNCHINSERT = DBREASON_ROWPOSITION_CLEARED + 1
	}

	public enum DBROWSTATUS
	{
		DBROWSTATUS_S_OK,
		DBROWSTATUS_S_MULTIPLECHANGES = 2,
		DBROWSTATUS_S_PENDINGCHANGES = 3,
		DBROWSTATUS_E_CANCELED = 4,
		DBROWSTATUS_E_CANTRELEASE = 6,
		DBROWSTATUS_E_CONCURRENCYVIOLATION = 7,
		DBROWSTATUS_E_DELETED = 8,
		DBROWSTATUS_E_PENDINGINSERT = 9,
		DBROWSTATUS_E_NEWLYINSERTED = 10,
		DBROWSTATUS_E_INTEGRITYVIOLATION = 11,
		DBROWSTATUS_E_INVALID = 12,
		DBROWSTATUS_E_MAXPENDCHANGESEXCEEDED = 13,
		DBROWSTATUS_E_OBJECTOPEN = 14,
		DBROWSTATUS_E_OUTOFMEMORY = 15,
		DBROWSTATUS_E_PERMISSIONDENIED = 16,
		DBROWSTATUS_E_LIMITREACHED = 17,
		DBROWSTATUS_E_SCHEMAVIOLATION = 18,
		DBROWSTATUS_E_FAIL = 19,
		DBROWSTATUS_S_NOCHANGE = 20,
	}

	public enum DBSORT
	{
		DBSORT_ASCENDING,
		DBSORT_DESCENDING = DBSORT_ASCENDING + 1
	}

	public enum DBSTATUS
	{
		DBSTATUS_S_OK,
		DBSTATUS_E_BADACCESSOR = 1,
		DBSTATUS_E_CANTCONVERTVALUE = 2,
		DBSTATUS_S_ISNULL = 3,
		DBSTATUS_S_TRUNCATED = 4,
		DBSTATUS_E_SIGNMISMATCH = 5,
		DBSTATUS_E_DATAOVERFLOW = 6,
		DBSTATUS_E_CANTCREATE = 7,
		DBSTATUS_E_UNAVAILABLE = 8,
		DBSTATUS_E_PERMISSIONDENIED = 9,
		DBSTATUS_E_INTEGRITYVIOLATION = 10,
		DBSTATUS_E_SCHEMAVIOLATION = 11,
		DBSTATUS_E_BADSTATUS = 12,
		DBSTATUS_S_DEFAULT = 13,
		MDSTATUS_S_CELLEMPTY = 14,
		DBSTATUS_S_IGNORE = 15,
		DBSTATUS_E_DOESNOTEXIST = 16,
		DBSTATUS_E_INVALIDURL = 17,
		DBSTATUS_E_RESOURCELOCKED = 18,
		DBSTATUS_E_RESOURCEEXISTS = 19,
		DBSTATUS_E_CANNOTCOMPLETE = 20,
		DBSTATUS_E_VOLUMENOTFOUND = 21,
		DBSTATUS_E_OUTOFSPACE = 22,
		DBSTATUS_S_CANNOTDELETESOURCE = 23,
		DBSTATUS_E_READONLY = 24,
		DBSTATUS_E_RESOURCEOUTOFSCOPE = 25,
		DBSTATUS_S_ALREADYEXISTS = 26,
		DBSTATUS_E_CANCELED = 27,
		DBSTATUS_E_NOTCOLLECTION = 28,
		DBSTATUS_S_ROWSETCOLUMN = 29
	}

	[Flags]
	public enum DBTABLESTATISTICSTYPE26
	{
		DBSTAT_HISTOGRAM = 0x1,
		DBSTAT_COLUMN_CARDINALITY = 0x2,
		DBSTAT_TUPLE_CARDINALITY = 0x4
	}

	public enum DBTYPE : ushort
	{
		DBTYPE_EMPTY,
		DBTYPE_NULL = 1,
		DBTYPE_I2 = 2,
		DBTYPE_I4 = 3,
		DBTYPE_R4 = 4,
		DBTYPE_R8 = 5,
		DBTYPE_CY = 6,
		DBTYPE_DATE = 7,
		DBTYPE_BSTR = 8,
		DBTYPE_IDISPATCH = 9,
		DBTYPE_ERROR = 10,
		DBTYPE_BOOL = 11,
		DBTYPE_VARIANT = 12,
		DBTYPE_IUNKNOWN = 13,
		DBTYPE_DECIMAL = 14,
		DBTYPE_UI1 = 17,
		DBTYPE_ARRAY = 0x2000,
		DBTYPE_BYREF = 0x4000,
		DBTYPE_I1 = 16,
		DBTYPE_UI2 = 18,
		DBTYPE_UI4 = 19,
		DBTYPE_I8 = 20,
		DBTYPE_UI8 = 21,
		DBTYPE_GUID = 72,
		DBTYPE_VECTOR = 0x1000,
		DBTYPE_RESERVED = 0x8000,
		DBTYPE_BYTES = 128,
		DBTYPE_STR = 129,
		DBTYPE_WSTR = 130,
		DBTYPE_NUMERIC = 131,
		DBTYPE_UDT = 132,
		DBTYPE_DBDATE = 133,
		DBTYPE_DBTIME = 134,
		DBTYPE_DBTIMESTAMP = 135,
		DBTYPE_HCHAPTER = 136,
		DBTYPE_FILETIME = 64,
		DBTYPE_PROPVARIANT = 138,
		DBTYPE_VARNUMERIC = 139,
	}

	public enum DBUPDELRULE
	{
		DBUPDELRULE_NOACTION,
		DBUPDELRULE_CASCADE = 0x1,
		DBUPDELRULE_SETNULL = 0x2,
		DBUPDELRULE_SETDEFAULT = 0x3
	}

	/// <summary>MDSCHEMA_DIMENSIONS DIMENSION_TYPE</summary>
	public enum MD_DIMTYPE : short
	{
		MD_DIMTYPE_UNKNOWN = 0,
		MD_DIMTYPE_TIME = 1,
		MD_DIMTYPE_MEASURE = 2,
		MD_DIMTYPE_OTHER = 3,
		MD_DIMTYPE_QUANTITATIVE = 5,
		MD_DIMTYPE_ACCOUNTS = 6,
		MD_DIMTYPE_CUSTOMERS = 7,
		MD_DIMTYPE_PRODUCTS = 8,
		MD_DIMTYPE_SCENARIO = 9,
		MD_DIMTYPE_UTILIY = 10,
		MD_DIMTYPE_CURRENCY = 11,
		MD_DIMTYPE_RATES = 12,
		MD_DIMTYPE_CHANNEL = 13,
		MD_DIMTYPE_PROMOTION = 14,
		MD_DIMTYPE_ORGANIZATION = 15,
		MD_DIMTYPE_BILL_OF_MATERIALS = 16,
		MD_DIMTYPE_GEOGRAPHY = 17,
	}

	/// <summary>The bitmask detailing effects on the font. </summary>
	[Flags]
	public enum MDFF
	{
		MDFF_BOLD = 0x01,
		MDFF_ITALIC = 0x02,
		MDFF_STRIKEOUT = 0x08,
		MDFF_UNDERLINE = 0x04,
	}

	/// <summary>LEVELS rowset LEVEL_TYPE</summary>
	[Flags]
	public enum MDLEVEL_TYPE
	{
		MDLEVEL_TYPE_ALL = 0x0001,
		MDLEVEL_TYPE_CALCULATED = 0x0002,
		MDLEVEL_TYPE_REGULAR = 0x0000,
		MDLEVEL_TYPE_RESERVED1 = 0x0008,
		MDLEVEL_TYPE_TIME = 0x0004,
		MDLEVEL_TYPE_TIME_DAYS = 0x0204,
		MDLEVEL_TYPE_TIME_HALF_YEAR = 0x0024,
		MDLEVEL_TYPE_TIME_HOURS = 0x0304,
		MDLEVEL_TYPE_TIME_MINUTES = 0x0404,
		MDLEVEL_TYPE_TIME_MONTHS = 0x0084,
		MDLEVEL_TYPE_TIME_QUARTERS = 0x0044,
		MDLEVEL_TYPE_TIME_SECONDS = 0x0804,
		MDLEVEL_TYPE_TIME_UNDEFINED = 0x1004,
		MDLEVEL_TYPE_TIME_WEEKS = 0x0104,
		MDLEVEL_TYPE_TIME_YEARS = 0x0014,
		MDLEVEL_TYPE_UNKNOWN = 0x0000,
	}

	/// <summary>MEASURES rowset MEASURE_AGGREGATOR</summary>
	public enum MDMEASURE_AGGR
	{
		MDMEASURE_AGGR_AVG = 0x05,
		MDMEASURE_AGGR_CALCULATED = 0x7f,
		MDMEASURE_AGGR_COUNT = 0x02,
		MDMEASURE_AGGR_MAX = 0x04,
		MDMEASURE_AGGR_MIN = 0x03,
		MDMEASURE_AGGR_STD = 0x07,
		MDMEASURE_AGGR_SUM = 0x01,
		MDMEASURE_AGGR_UNKNOWN = 0x00,
		MDMEASURE_AGGR_VAR = 0x06,
	}

	/// <summary>MDSCHEMA_MEMBERS rowset MEMBER_TYPE</summary>
	public enum MDMEMBER_TYPE
	{
		MDMEMBER_TYPE_ALL = 0x02,
		MDMEMBER_TYPE_FORMULA = 0x04,
		MDMEMBER_TYPE_MEASURE = 0x03,
		MDMEMBER_TYPE_REGULAR = 0x01,
		MDMEMBER_TYPE_RESERVE1 = 0x05,
		MDMEMBER_TYPE_RESERVE2 = 0x06,
		MDMEMBER_TYPE_RESERVE3 = 0x07,
		MDMEMBER_TYPE_RESERVE4 = 0x08,
		MDMEMBER_TYPE_UNKNOWN = 0x00,
	}

	/// <summary>This is an OLE DB for OLAP property.</summary>
	public enum MDPROPVAL_AU
	{
		/// <summary>The provider supports updating of aggregated cells, but the value of cells beneath an aggregated cell remains unchanged.</summary>
		MDPROPVAL_AU_UNCHANGED = 0x00000001,

		/// <summary>The provider supports updating of aggregated cells, but the value of cells beneath an aggregated cell remains undefined.</summary>
		MDPROPVAL_AU_UNKNOWN = 0x00000002,

		/// <summary>The provider does not support updating nonatomic cells.</summary>
		MDPROPVAL_AU_UNSUPPORTED = 0x00000000,
	}

	/// <summary>This is an OLE DB for OLAP property.</summary>
	public enum MDPROPVAL_FS
	{
		/// <summary>The provider supports flattening as described in Flattening a Dataset to Produce a Rowset.</summary>
		MDPROPVAL_FS_FULL_SUPPORT = 0x00000001,

		/// <summary>The provider supports flattening by using dummy names, as described in Support Level for Named Levels.</summary>
		MDPROPVAL_FS_GENERATED_COLUMN = 0x00000002,

		/// <summary>The provider supports flattening by generating one column per dimension as described in Support Level for Named Levels.</summary>
		MDPROPVAL_FS_GENERATED_DIMENSION = 0x00000003,

		/// <summary>
		/// The provider does not support flattening. For such a provider, calling ICommand::Execute with a language dialect of MDGUID_MDX
		/// and asking for the IRowset interface returns an error (E_NOINTERFACE).
		/// </summary>
		MDPROPVAL_FS_NO_SUPPORT = 0x00000004,
	}

	/// <summary>This is an OLE DB for OLAP property. A bitmask that specifies the support in a provider for case statements.</summary>
	[Flags]
	public enum MDPROPVAL_MC
	{
		/// <summary>The provider supports a searched case expression.</summary>
		MDPROPVAL_MC_SEARCHEDCASE = 0x00000002,

		/// <summary>The provider supports a simple case expression.</summary>
		MDPROPVAL_MC_SINGLECASE = 0x00000001,
	}

	/// <summary>Support for various &lt;desc flag&gt; values in the DESCENDANTS function. This is an OLE DB for OLAP property.</summary>
	[Flags]
	public enum MDPROPVAL_MD
	{
		/// <summary>The provider supports the flag AFTER.</summary>
		MDPROPVAL_MD_AFTER = 0x00000004,

		/// <summary>The provider supports the flag BEFORE.</summary>
		MDPROPVAL_MD_BEFORE = 0x00000002,

		/// <summary>The provider supports the flag SELF. This bit must be set by all providers because support for SELF is mandatory.</summary>
		MDPROPVAL_MD_SELF = 0x00000001,
	}

	/// <summary>Support for creation of named sets and calculated members</summary>
	[Flags]
	public enum MDPROPVAL_MF
	{
		/// <summary>The provider supports the creation of named calculated members by using the CREATE clause.</summary>
		MDPROPVAL_MF_CREATE_CALCMEMBERS = 0x00000004,

		/// <summary>The provider supports the creation of named sets by using the CREATE clause.</summary>
		MDPROPVAL_MF_CREATE_NAMEDSETS = 0x00000008,

		/// <summary>The provider supports the scope value of GLOBAL during the creation of named sets and calculated members.</summary>
		MDPROPVAL_MF_SCOPE_GLOBAL = 0x00000020,

		/// <summary>The provider supports the scope value of SESSION during the creation of named sets and calculated members.</summary>
		MDPROPVAL_MF_SCOPE_SESSION = 0x00000010,

		/// <summary>The provider supports the creation of calculated members by using the WITH clause before a SELECT.</summary>
		MDPROPVAL_MF_WITH_CALCMEMBERS = 0x00000001,

		/// <summary>The provider supports the creation of named sets by using the WITH clause before a SELECT.</summary>
		MDPROPVAL_MF_WITH_NAMEDSETS = 0x00000002,
	}

	/// <summary>Support for query joining multiple cubes</summary>
	[Flags]
	public enum MDPROPVAL_MJC
	{
		/// <summary>The provider supports an empty FROM clause. The cube is implicitly resolved by the axis and slicer dimensions.</summary>
		MDPROPVAL_MJC_IMPLICITCUBE = 0x00000004,

		/// <summary>The provider supports more than one cube in the FROM clause of the MDX statement.</summary>
		MDPROPVAL_MJC_MULTICUBES = 0x00000002,

		/// <summary>The provider supports only one cube in the FROM clause of the MDX statement.</summary>
		MDPROPVAL_MJC_SINGLECUBE = 0x00000001,
	}

	/// <summary>Support for various member functions</summary>
	[Flags]
	public enum MDPROPVAL_MMF
	{
		/// <summary>The provider supports the function CLOSINGPERIOD.</summary>
		MDPROPVAL_MMF_CLOSINGPERIOD = 0x00000008,

		/// <summary>The provider supports the function COUSIN.</summary>
		MDPROPVAL_MMF_COUSIN = 0x00000001,

		/// <summary>The provider supports the function OPENINGPERIOD.</summary>
		MDPROPVAL_MMF_OPENINGPERIOD = 0x00000004,

		/// <summary>The provider supports the function PARALLELPERIOD.</summary>
		MDPROPVAL_MMF_PARALLELPERIOD = 0x00000002,
	}

	/// <summary>Support for various numeric functions</summary>
	[Flags]
	public enum MDPROPVAL_MNF
	{
		/// <summary>The provider supports the function AGGREGATE.</summary>
		MDPROPVAL_MNF_AGGREGATE = 0x00000010,

		/// <summary>The provider supports the function CORRELATION.</summary>
		MDPROPVAL_MNF_CORRELATION = 0x00000040,

		/// <summary>The provider supports the function COVARIANCE.</summary>
		MDPROPVAL_MNF_COVARIANCE = 0x00000020,

		/// <summary>The provider supports the function DRILLDOWNLEVEL.</summary>
		MDPROPVAL_MNF_DRILLDOWNLEVEL = 0x00000800,

		/// <summary>The provider supports the function DRILLDOWNLEVELBOTTOM.</summary>
		MDPROPVAL_MNF_DRILLDOWNLEVELBOTTOM = 0x00008000,

		/// <summary>The provider supports the function DRILLDOWNLEVELTOP.</summary>
		MDPROPVAL_MNF_DRILLDOWNLEVELTOP = 0x00004000,

		/// <summary>The provider supports the function DRILLDOWNMEMBERBOTTOM.</summary>
		MDPROPVAL_MNF_DRILLDOWNMEMBERBOTTOM = 0x00002000,

		/// <summary>The provider supports the function DRILLDOWNMEMBERTOP.</summary>
		MDPROPVAL_MNF_DRILLDOWNMEMBERTOP = 0x00001000,

		/// <summary>The provider supports the function DRILLUPLEVEL.</summary>
		MDPROPVAL_MNF_DRILLUPLEVEL = 0x00020000,

		/// <summary>The provider supports the function DRILLUPMEMBER.</summary>
		MDPROPVAL_MNF_DRILLUPMEMBER = 0x00010000,

		/// <summary>The provider supports the function LINREG2.</summary>
		MDPROPVAL_MNF_LINREG2 = 0x00000200,

		/// <summary>The provider supports the function LINREGPOINT.</summary>
		MDPROPVAL_MNF_LINREGPOINT = 0x00000400,

		/// <summary>The provider supports the function LINREGSLOPE.</summary>
		MDPROPVAL_MNF_LINREGSLOPE = 0x00000080,

		/// <summary>The provider supports the function LINREGVARIANCE.</summary>
		MDPROPVAL_MNF_LINREGVARIANCE = 0x00000100,

		/// <summary>The provider supports the function MEDIAN.</summary>
		MDPROPVAL_MNF_MEDIAN = 0x00000001,

		/// <summary>The provider supports the function RANK.</summary>
		MDPROPVAL_MNF_RANK = 0x00000008,

		/// <summary>The provider supports the function STDDEV.</summary>
		MDPROPVAL_MNF_STDDEV = 0x00000004,

		/// <summary>The provider supports the function VAR.</summary>
		MDPROPVAL_MNF_VAR = 0x00000002,
	}

	/// <summary>A bitmask specifying how multidimensional schema object names can be qualified in an MDX statement.</summary>
	[Flags]
	public enum MDPROPVAL_MOQ
	{
		/// <summary>Cubes can be qualified by the catalog name.</summary>
		MDPROPVAL_MOQ_CATALOG_CUBE = 0x00000002,

		/// <summary>Dimensions can be qualified by cube name.</summary>
		MDPROPVAL_MOQ_CUBE_DIM = 0x00000008,

		/// <summary>Cubes can be qualified by the data source name.</summary>
		MDPROPVAL_MOQ_DATASOURCE_CUBE = 0x00000001,

		/// <summary>Hierarchies can be qualified by dimension names.</summary>
		MDPROPVAL_MOQ_DIM_HIER = 0x00000010,

		/// <summary>
		/// Levels can be qualified by the dimension name and/or hierarchy name. This property applies only if named levels are supported,
		/// which can be checked by the property.
		/// </summary>
		MDPROPVAL_MOQ_DIMHIER_LEVEL = 0x00000020,

		/// <summary>Members can be qualified by a dimension name and/or a hierarchy name.</summary>
		MDPROPVAL_MOQ_DIMHIER_MEMBER = 0x00000100,

		/// <summary>Members can be qualified by a level name.</summary>
		MDPROPVAL_MOQ_LEVEL_MEMBER = 0x00000040,

		/// <summary>The mdpropval moq member member</summary>
		MDPROPVAL_MOQ_MEMBER_MEMBER = 0x00000080,

		/// <summary>Members can be qualified by their ancestor names.</summary>
		MDPROPVAL_MOQ_OUTERREFERENCE = 0x00000001,

		/// <summary>Cubes can be qualified by the schema name.</summary>
		MDPROPVAL_MOQ_SCHEMA_CUBE = 0x00000004,

		/// <summary>If named levels are not supported, this bit must be set.</summary>
		MDPROP_NAMED_LEVELS = 0xff,
	}

	/// <summary>The capabilities in the WHERE clause of an MDX statement</summary>
	public enum MDPROPVAL_MS
	{
		/// <summary>The provider supports more than one tuple in the WHERE clause.</summary>
		MDPROPVAL_MS_MULTIPLETUPLES = 0x00000001,

		/// <summary>The provider supports only one tuple in the WHERE clause.</summary>
		MDPROPVAL_MS_SINGLETUPLE = 0x00000002,
	}

	/// <summary>Support for string comparison operators other than equals and not-equals operators</summary>
	[Flags]
	public enum MDPROPVAL_MSC
	{
		/// <summary>The provider supports the greater-than operator.</summary>
		MDPROPVAL_MSC_GREATERTHAN = 0x00000002,

		/// <summary>The provider supports the greater-than-or-equal-to operator.</summary>
		MDPROPVAL_MSC_GREATERTHANEQUAL = 0x00000008,

		/// <summary>The provider supports the less-than operator.</summary>
		MDPROPVAL_MSC_LESSTHAN = 0x00000001,

		/// <summary>The provider supports the less-than-or-equal-to operator.</summary>
		MDPROPVAL_MSC_LESSTHANEQUAL = 0x00000004,
	}

	/// <summary>Support for various set functions.</summary>
	[Flags]
	public enum MDPROPVAL_MSF
	{
		/// <summary>The provider supports the function BOTTOMPERCENT.</summary>
		MDPROPVAL_MSF_BOTTOMPERCENT = 0x00000002,

		/// <summary>The provider supports the function BOTTOMSUM.</summary>
		MDPROPVAL_MSF_BOTTOMSUM = 0x00000008,

		/// <summary>The provider supports the function DRILLDOWNLEVEL.</summary>
		MDPROPVAL_MSF_DRILLDOWNLEVEL = 0x00000800,

		/// <summary>The provider supports the function DRILLDOWNLEVELBOTTOM.</summary>
		MDPROPVAL_MSF_DRILLDOWNLEVELBOTTOM = 0x00008000,

		/// <summary>The provider supports the function DRILLDOWNLEVELTOP.</summary>
		MDPROPVAL_MSF_DRILLDOWNLEVELTOP = 0x00004000,

		/// <summary>The provider supports the function DRILLDOWNMEMBBER.</summary>
		MDPROPVAL_MSF_DRILLDOWNMEMBBER = 0x00000400,

		/// <summary>The provider supports the function DRILLDOWNMEMBERBOTTOM.</summary>
		MDPROPVAL_MSF_DRILLDOWNMEMBERBOTTOM = 0x00002000,

		/// <summary>The provider supports the function DRILLDOWNMEMBERTOP.</summary>
		MDPROPVAL_MSF_DRILLDOWNMEMBERTOP = 0x00001000,

		/// <summary>The provider supports the function DRILLUPLEVEL.</summary>
		MDPROPVAL_MSF_DRILLUPLEVEL = 0x00020000,

		/// <summary>The provider supports the function DRILLUPMEMBER.</summary>
		MDPROPVAL_MSF_DRILLUPMEMBER = 0x00010000,

		/// <summary>The provider supports the function LASTPERIODS.</summary>
		MDPROPVAL_MSF_LASTPERIODS = 0x00000020,

		/// <summary>The provider supports the function MTD.</summary>
		MDPROPVAL_MSF_MTD = 0x00000100,

		/// <summary>The provider supports the function PERIODSTODATE.</summary>
		MDPROPVAL_MSF_PERIODSTODATE = 0x00000010,

		/// <summary>The provider supports the function QTD.</summary>
		MDPROPVAL_MSF_QTD = 0x00000080,

		/// <summary>The provider supports the function TOGGLEDRILLSTATE.</summary>
		MDPROPVAL_MSF_TOGGLEDRILLSTATE = 0x00040000,

		/// <summary>The provider supports the function TOPPERCENT.</summary>
		MDPROPVAL_MSF_TOPPERCENT = 0x00000001,

		/// <summary>The provider supports the function TOPSUM.</summary>
		MDPROPVAL_MSF_TOPSUM = 0x00000004,

		/// <summary>The provider supports the function WTD.</summary>
		MDPROPVAL_MSF_WTD = 0x00000200,

		/// <summary>The provider supports the function YTD.</summary>
		MDPROPVAL_MSF_YTD = 0x00000040,
	}

	/// <summary>A bitmask specifying whether the provider supports named levels and/or numbered levels.</summary>
	[Flags]
	public enum MDPROPVAL_NL
	{
		/// <summary>The provider supports named levels.</summary>
		MDPROPVAL_NL_NAMEDLEVELS = 0x00000001,

		/// <summary>The provider supports numbered levels using the LEVELS(n) function.</summary>
		MDPROPVAL_NL_NUMBEREDLEVELS = 0x00000002,

		/// <summary>
		/// The provider supports "dummy" named levels. These level names are for display only and are frequently just provider-generated
		/// names for a given level number. These names cannot be used in an MDX statement (such as in &lt;level_name&gt;.MEMBERS). These
		/// names appear in the LEVEL_NAME and LEVEL_UNIQUE_NAME columns of the schema rowset; providers may choose to have the same name in
		/// both the columns, or they can generate LEVEL_UNIQUE_NAME by appropriately qualifying the LEVEL_NAME. It is provider-specific
		/// whether these dummy names also appear in the LEVEL_UNIQUE_NAME column of the MEMBERS and PROPERTIES rowsets.
		/// </summary>
		MDPROPVAL_NL_SCHEMAONLY = 0x00000004,
	}

	/// <summary>The capabilities in the &lt;numeric_value_expression&gt; argument of set functions</summary>
	public enum MDPROPVAL_NME
	{
		/// <summary>The provider supports expressions involving members from any dimension.</summary>
		MDPROPVAL_NME_ALLDIMENSIONS = 0x00000000,

		/// <summary>The provider supports only expressions involving Measures dimension members.</summary>
		MDPROPVAL_NME_MEASURESONLY = 0x00000001,
	}

	/// <summary>Support for cell updates</summary>
	public enum MDPROPVAL_RR
	{
		/// <summary>The provider does not support IMDRangeRowset.</summary>
		MDPROPVAL_RR_NORANGEROWSET = 0x00000001,

		/// <summary>The provider supports a read-only range rowset.</summary>
		MDPROPVAL_RR_READONLY = 0x00000002,

		/// <summary>The provider supports an updatable range rowset.</summary>
		MDPROPVAL_RR_UPDATE = 0x00000004,
	}

	/// <summary>
	/// Indicates whether the provider is to calculate visual totals, which dynamically totals child members of parent members specified in a
	/// set. When visual totals mode is on, displayed aggregate values are equal to the sum of the displayed values being aggregated. Can be
	/// one or more of the values described in the following table.
	/// </summary>
	[Flags]
	public enum MDPROPVAL_VISUAL_MODE
	{
		/// <summary>Default mode, provider-specific</summary>
		MDPROPVAL_VISUAL_MODE_DEFAULT = 0x00000000,

		/// <summary>Visual totals on</summary>
		MDPROPVAL_VISUAL_MODE_VISUAL = 0x00000001,

		/// <summary>Visual totals off</summary>
		MDPROPVAL_VISUAL_MODE_VISUAL_OFF = 0x00000002,
	}

	/// <summary>MDSCHEMA_MEMBERS rowset TREE_OP</summary>
	public enum MDTREEOP : uint
	{
		MDTREEOP_CHILDREN = 0x01,
		MDTREEOP_SIBLINGS = 0x02,
		MDTREEOP_PARENT = 0x04,
		MDTREEOP_SELF = 0x08,
		MDTREEOP_DESCENDANTS = 0x10,
		MDTREEOP_ANCESTORS = 0x20,
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct DB_VARNUMERIC
	{
		public byte precision;
		public sbyte scale;
		public byte sign;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
		public byte[] val;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct DBBINDEXT
	{
		public IntPtr pExtension;
		public DBCOUNTITEM ulExtension;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct DBBINDING
	{
		public DBORDINAL iOrdinal;
		public DBBYTEOFFSET obValue;
		public DBBYTEOFFSET obLength;
		public DBBYTEOFFSET obStatus;
		public IntPtr pTypeInfo;
		public IntPtr pObject;
		public IntPtr pBindExt;
		public DBPART dwPart;
		public DBMEMOWNER dwMemOwner;
		public DBPARAMIO eParamIO;
		public DBLENGTH cbMaxLen;
		public uint dwFlags;
		public DBTYPE wType;
		public byte bPrecision;
		public byte bScale;
	}

	/// <summary>Gets or sets the value of the specified column in the rowset.</summary>
	[PInvokeData("oledb.h")]
	[StructLayout(LayoutKind.Sequential)]
	public struct DBCOLUMNACCESS
	{
		/// <summary>
		///   <para>Pointer of type wType to caller-allocated storage. On return, the area of storage contains the value stored in the column specified by columnid. The provider should attempt to coerce the column value to type wType. If wType is DBTYPE_VARIANT, the provider is responsible for allocating any variable-length storage pointed to by the VARIANT. If the caller passes a null pointer, the provider returns only the untruncated length (cbDataLen) and status (dwStatus) and does not return a data value.</para>
		///   <para>If the row is in immediate mode and a row-specific columns has been deleted, the provider returns DBSTATUS_E_DOESNOTEXIST. If the row is in deferred mode and a row-specific column has been deleted, the provider returns a null value and DBSTATUS_S_ISNULL.</para>
		///   <para>For more information, see Getting and Setting Data.</para>
		/// </summary>
		public IntPtr pData;
		/// <summary>columnid is a DBID that identifies the column to be accessed. columnid values must be unique within a row.</summary>
		public DBID columnid;
		/// <summary>The returned length of the value contained in *pData. If the length of the column value is greater than cbMaxLen, the provider truncates the data to fit the buffer, returns the full data size in cbDataLen, and sets dwStatus to DBSTATUS_S_TRUNCATED.</summary>
		public DBLENGTH cbDataLen;
		/// <summary>A DBSTATUS status field set by the provider on return, indicating whether pData or some other value should be used. On return, dwStatus indicates whether the field was successfully retrieved and provides other information about this column. For more information about status values, see Status in Getting and Setting Data.</summary>
		public DBSTATUS dwStatus;
		/// <summary>The maximum length of the caller-initialized memory pointed to by pData. For more information on cbMaxLen in the binding structure, see DBBINDING Structures in Getting and Setting Data.</summary>
		public DBLENGTH cbMaxLen;
		/// <summary>Reserved. Consumers should set this parameter to zero.</summary>
		public DB_DWRESERVE dwReserved;
		/// <summary>
		///   <para>On input, wType identifies the data type requested by the consumer. The provider attempts to convert the value from the type of the column to this type.</para>
		///   <para>wType should not change on return; if the provider could not convert, a status of DBSTATUS_E_CANTCONVERTVALUE would be returned.</para>
		/// </summary>
		public DBTYPE wType;
		/// <summary>The maximum precision to use when getting data and wType is DBTYPE_NUMERIC. bPrecision is ignored when setting data or if wType is not DBTYPE_NUMERIC. For more information, see Conversions Involving DBTYPE_NUMERIC or DBTYPE_DECIMAL in Appendix A: Data Types.</summary>
		public byte bPrecision;
		/// <summary>The scale to use when getting data and wType is DBTYPE_NUMERIC or DBTYPE_DECIMAL. This is ignored when setting data. It is also ignored if wType is not DBTYPE_NUMERIC or DBTYPE_DECIMAL. For more information, see Conversions Involving DBTYPE_NUMERIC or DBTYPE_DECIMAL in Appendix A: Data Types.</summary>
		public byte bScale;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct DBCOLUMNDESC
	{
		public LPWSTR pwszTypeName;
		public IntPtr pTypeInfo;
		public IntPtr rgPropertySets;
		public GuidPtr pclsid;
		public uint cPropertySets;
		public DBLENGTH ulColumnSize;
		public DBID dbcid;
		public DBTYPE wType;
		public byte bPrecision;
		public byte bScale;
	}

	/// <summary>
	/// Defines the columns of a row object.
	/// </summary>
	[PInvokeData("oledb.h")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct DBCOLUMNINFO
	{
		/// <summary>
		///   <para>Pointer to the name of the column; this might not be unique. If this cannot be determined, a null pointer is returned.</para>
		///   <para>The name can be different from the string part of the column ID if the column has been renamed by the command text. This name always reflects the most recent renaming of the column in the current view or command text.</para>
		/// </summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string? pwszName;
		/// <summary>Reserved for future use. Providers should return a null pointer in pTypeInfo.</summary>
		public IntPtr pTypeInfo;
		/// <summary>The ordinal of the column. This is zero for the bookmark column of the row, if any. Other columns are numbered starting from one.</summary>
		public DBORDINAL iOrdinal;
		/// <summary>A bitmask that describes consumer-specified row column characteristics. The DBCOLUMNFLAGS enumerated type specifies the bits in the bitmask, which are described in the reference entry for IColumnsInfo::GetColumnInfo.</summary>
		public DBCOLUMNFLAGS dwFlags;
		/// <summary>Minimum size required to store the consumer's largest data for this column. For fixed-length data types, this is the size of the data type in bytes. For variable-length data types, this is the maximum number of bytes (for DBTYPE_BYTES) or characters (for DBTYPE_STR or DBTYPE_WSTR). For more information, see the description of DBCOLUMNINFO in the reference entry for IColumnsInfo::GetColumnInfo.</summary>
		public DBLENGTH ulColumnSize;
		/// <summary>Requested DBTYPE data type for this column.</summary>
		public DBTYPE wType;
		/// <summary>Maximum precision of the column.</summary>
		public byte bPrecision;
		/// <summary>Number of digits to the right of the decimal point.</summary>
		public byte bScale;
		/// <summary>Unique DBID used to name this row column. For example, if columns are named (eKind is DBKIND_NAME), uName.pwszName points to the column name.</summary>
		public DBID columnid;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct DBCONSTRAINTDESC
	{
		public IntPtr pConstraintID;
		public DBCONSTRAINTTYPE ConstraintType;
		public DBORDINAL cColumns;
		public IntPtr rgColumnList;
		public IntPtr pReferencedTableID;
		public DBORDINAL cForeignKeyColumns;
		public IntPtr rgForeignKeyColumnList;
		public LPWSTR pwszConstraintText;
		public DBUPDELRULE UpdateRule;
		public DBUPDELRULE DeleteRule;
		public DBMATCHTYPE MatchType;
		public DBDEFERRABILITY Deferrability;
		public DB_URESERVE cReserved;
		public IntPtr rgReserved;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct DBFAILUREINFO
	{
		public IntPtr hRow;
		public DBORDINAL iColumn;
		public HRESULT failure;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct DBID
	{
		public UGUID uGuid;
		public DBKIND eKind;
		public UNAME uName;

		[StructLayout(LayoutKind.Explicit)]
		public struct UGUID
		{
			[FieldOffset(0)]
			public Guid guid;

			[FieldOffset(0)]
			public GuidPtr pguid;
		}

		[StructLayout(LayoutKind.Explicit)]
		public struct UNAME
		{
			[FieldOffset(0)]
			public LPWSTR pwszName;

			[FieldOffset(0)]
			public uint ulPropid;
		}

		public DBID(Guid guid, DBKIND kind, uint propId)
		{
			uGuid.guid = guid;
			eKind = kind;
			uName.ulPropid = propId;
		}
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct DBIMPLICITSESSION
	{
		public IntPtr pUnkOuter;
		public GuidPtr piid;
		public IntPtr pSession;
	}

	/// <summary>Describes how to construct the index.</summary>
	[PInvokeData("dbs.h")]
	[StructLayout(LayoutKind.Sequential)]
	public struct DBINDEXCOLUMNDESC
	{
		/// <summary>A pointer to the ID of the base table column.</summary>
		public IntPtr pColumnID;

		/// <summary>
		///   <para>Whether the index is ascending or descending in this column.</para>
		///   <list type="bullet">
		///     <item>DBINDEX_COL_ORDER_ASC ? Ascending</item>
		///     <item>DBINDEX_COL_ORDER_DESC ? Descending</item>
		///   </list>
		/// </summary>
		public DBINDEX_COL_ORDER eIndexColOrder;

		/// <summary>The ID of the base table column.</summary>
		public readonly DBID? ColumnId => pColumnID.ToNullableStructure<DBID>();
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct DBOBJECT
	{
		public uint dwFlags;
		public Guid iid;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct DBPARAMINFO
	{
		/// <summary>
		/// <para>A bitmask describing parameter characteristics; these values have the following meaning:</para>
		/// <list type="bullet">
		/// <item>DBPARAMFLAGS_ISINPUT ? Whether a parameter accepts values on input. Not set if this is unknown.</item>
		/// <item>
		/// DBPARAMFLAGS_ISOUTPUT ? Whether a parameter returns values on output. Not set if this is unknown. Providers support only those
		/// parameter types that make sense for their data store.
		/// </item>
		/// <item>
		/// DBPARAMFLAGS_ISSIGNED ? Whether a parameter is signed. This is ignored if the type is inherently signed, such as DBTYPE_I2 or if
		/// the sign does not apply to the type, such as DBTYPE_BSTR. It is generally used in ICommandWithParameters::SetParameterInfo so
		/// that the consumer can tell the provider if a provider-specific type name refers to a signed or unsigned type.
		/// </item>
		/// <item>DBPARAMFLAGS_ISNULLABLE ? Whether a parameter accepts NULLs. If nullability is unknown, this flag is set.</item>
		/// <item>
		/// <para>
		/// DBPARAMFLAGS_ISLONG ? Whether a parameter contains a BLOB that contains very long data. The definition of very long data is
		/// provider specific. The flag setting corresponds to the value of the IS_LONG column in the PROVIDER_TYPES schema rowset for the
		/// data type.
		/// </para>
		/// <para>
		/// When this flag is set, the BLOB is best manipulated through one of the storage interfaces. Although such BLOBs can be sent in a
		/// single piece with ICommand::Execute, there can be provider-specific problems in doing so. For example, the BLOB might be
		/// truncated due to machine limits on memory. Furthermore, when this flag is set, the provider might not be able to accurately
		/// return the maximum length of the BLOB data in ulParamSize in ICommandWithParameters::GetParameterInfo.
		/// </para>
		/// <para>When this flag is not set, the BLOB can be accessed either through ICommand::Execute or through a storage interface.</para>
		/// <para>For more information, see Accessing BLOB Data.</para>
		/// </item>
		/// <item>
		/// DBPARAMFLAGS_SCALEISNEGATIVE ? Set if the parameter type is DBTYPE_VARNUMERIC and bScale represents the absolute value of the
		/// negative scale of the parameter. This flag is used when setting data in a DBTYPE_VARNUMERIC parameter. For more information,
		/// refer to Conversions Involving DBTYPE_NUMERIC or DBTYPE_DECIMAL in Appendix A.
		/// </item>
		/// </list>
		/// </summary>
		public DBPARAMFLAGS dwFlags;
		/// <summary>The ordinal of the parameter. Parameters are numbered from left to right as they appear in the command, with the first parameter in the command having an iOrdinal value of 1.</summary>
		public DBORDINAL iOrdinal;
		/// <summary>The name of the parameter; it is a null pointer if there is no name. Names are normal names. The colon prefix (where used within SQL text) is stripped.</summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string? pwszName;
		/// <summary>ITypeInfo describes the type, if pTypeInfo is not a null pointer.</summary>
		[MarshalAs(UnmanagedType.IUnknown)]
		public ITypeInfo? pTypeInfo;
		/// <summary>
		///   <para>The maximum possible length of a value in the parameter. For parameters that use a fixed-length data type, this is the size of the data type. For parameters that use a variable-length data type, this is one of the following:</para>
		///   <list type="bullet">
		///     <item>The maximum length of the parameters in characters (for DBTYPE_STR and DBTYPE_WSTR) or in bytes (for DBTYPE_BYTES and DBTYPE_VARNUMERIC), if one is defined. For example, a parameter for a CHAR(5) column in an SQL table has a maximum length of 5.</item>
		///     <item>The maximum length of the data type in characters (for DBTYPE_STR and DBTYPE_WSTR) or in bytes (for DBTYPE_BYTES and DBTYPE_VARNUMERIC), if the parameter does not have a defined length.</item>
		///     <item>~0 (bitwise, the value is not 0; all bits are set to 1) if neither the parameter nor the data type has a defined maximum length.</item>
		///   </list>
		///   <para>For data types that do not have a length, this is set to ~0 (bitwise, the value is not 0; all bits are set to 1).</para>
		/// </summary>
		public DBLENGTH ulParamSize;
		/// <summary>The indicator of the parameter's data type, or a type from which the data can be converted for the parameter if the provider cannot determine the exact data type of the parameter.</summary>
		public DBTYPE wType;
		/// <summary>If wType is a numeric type or DBTYPE_DBTIMESTAMP, bPrecision is the maximum number of digits, expressed in base 10. Otherwise, this is ~0 (bitwise, the value is not 0; all bits are set to 1).</summary>
		public byte bPrecision;
		/// <summary>If wType is a numeric type with a fixed scale or if wType is DBTYPE_DBTIMESTAMP, bScale is the number of digits to the right (if bScale is positive) or left (if bScale is negative) of the decimal point. Otherwise, this is ~0 (bitwise, the value is not 0; all bits are set to 1).</summary>
		public byte bScale;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct DBPROP
	{
		public DBPROPENUM dwPropertyID;
		public DBPROPOPTIONS dwOptions;
		public DBPROPSTATUS dwStatus;
		public DBID colid;

		[MarshalAs(UnmanagedType.Struct)]
		public object? vValue;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct DBPROPINFO
	{
		[MarshalAs(UnmanagedType.LPWStr)]
		public string pwszDescription;

		public DBPROPENUM dwPropertyID;
		public DBPROPFLAGS dwFlags;
		public VARTYPE vtType;

		[MarshalAs(UnmanagedType.Struct)]
		public object vValues;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct DBVECTOR
	{
		public DBLENGTH size;
		public IntPtr ptr;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct MDAXISINFO
	{
		public DBLENGTH cbSize;
		public DBCOUNTITEM iAxis;
		public DBCOUNTITEM cDimensions;
		public DBCOUNTITEM cCoordinates;
		public IntPtr rgcColumns;
		public IntPtr rgpwszDimensionNames;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct RMTPACK
	{
		[MarshalAs(UnmanagedType.IUnknown)]
		public ISequentialStream pISeqStream;

		public uint cbData;
		public uint cBSTR;
		public IntPtr rgBSTR;
		public uint cVARIANT;
		public IntPtr rgVARIANT;
		public uint cIDISPATCH;
		public IntPtr rgIDISPATCH;
		public uint cIUNKNOWN;
		public IntPtr rgIUNKNOWN;
		public uint cPROPVARIANT;
		public IntPtr rgPROPVARIANT;
		public uint cArray;
		public IntPtr rgArray;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct SEC_OBJECT
	{
		public uint cObjects;
		public IntPtr prgObjects;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct SEC_OBJECT_ELEMENT
	{
		public Guid guidObjectType;
		public DBID ObjectID;
	}

	[StructLayout(LayoutKind.Sequential, Pack = 4)]
	internal struct DBSET_INTERNAL
	{
		public IntPtr rgProperties;
		public uint cProperties;
		public Guid guidPropertySet;
	}

	public class DBCOLUMNINFO_MGD
	{
		public byte bPrecision { get; internal set; }
		public byte bScale { get; internal set; }
		public DBID columnid { get; internal set; }
		public DBCOLUMNFLAGS dwFlags { get; internal set; }
		public DBORDINAL iOrdinal { get; internal set; }
		public ITypeInfo? pTypeInfo { get; internal set; }
		public string? pwszName { get; internal set; }
		public DBLENGTH ulColumnSize { get; internal set; }
		public DBTYPE wType { get; internal set; }

		public static explicit operator DBCOLUMNINFO_MGD(DBCOLUMNINFO info) => new()
		{
			pwszName = (string?)info.pwszName,
			pTypeInfo = info.pTypeInfo == IntPtr.Zero ? null : (ITypeInfo)Marshal.GetObjectForIUnknown(info.pTypeInfo),
			iOrdinal = info.iOrdinal,
			dwFlags = info.dwFlags,
			ulColumnSize = info.ulColumnSize,
			wType = info.wType,
			bPrecision = info.bPrecision,
			bScale = info.bScale,
			columnid = info.columnid
		};
	}

	// deprecated; use DB_NULL_HCHAPTER instead
	[StructLayout(LayoutKind.Sequential)]
	public class DBPARAMS
	{
		public IntPtr pData;
		public DB_UPARAMS cParamSets;
		public HACCESSOR hAccessor;
	}

	public class DBPROPIDSET : DBSET<DBPROPENUM>
	{
		public DBPROPENUM[] rgPropertyIDs { get => properties; set => properties = value; }
	}

	public class DBPROPINFOSET : DBSET<DBPROPINFO>
	{
		public DBPROPINFO[] rgPropertyInfos { get => properties; set => properties = value; }
	}

	public class DBPROPSET : DBSET<DBPROP>
	{
		public DBPROP[] rgProperties { get => properties; set => properties = value; }
	}

	public class DBSET<T> : IEquatable<DBSET<T>> where T : struct
	{
		public Guid guidPropertySet { get; set; }
		internal T[] properties { get; set; } = [];

		public bool Equals(DBSET<T>? other) => guidPropertySet == other?.guidPropertySet && properties.SequenceEqual(other?.properties ?? []);
	}

	public class SafeDBPROPIDSETListHandle : SafeDBSETListHandle<DBPROPIDSET, DBPROPENUM>
	{
		public SafeDBPROPIDSETListHandle(IEnumerable<DBPROPIDSET> props) : base(props)
		{
		}

		internal SafeDBPROPIDSETListHandle() : base()
		{
		}

		public static implicit operator DBPROPIDSET[](SafeDBPROPIDSETListHandle props) => props.ToArray();

		public static implicit operator SafeDBPROPIDSETListHandle(DBPROPIDSET[]? props) => new(props ?? []);
	}

	public class SafeDBPROPINFOSETListHandle : SafeDBSETListHandle<DBPROPINFOSET, DBPROPINFO>
	{
		public SafeDBPROPINFOSETListHandle(IEnumerable<DBPROPINFOSET> props) : base(props)
		{
		}

		internal SafeDBPROPINFOSETListHandle() : base()
		{
		}

		public static implicit operator DBPROPINFOSET[](SafeDBPROPINFOSETListHandle props) => props.ToArray();

		public static implicit operator SafeDBPROPINFOSETListHandle(DBPROPINFOSET[]? props) => new(props ?? []);
	}

	public class SafeDBPROPSETListHandle : SafeDBSETListHandle<DBPROPSET, DBPROP>
	{
		public SafeDBPROPSETListHandle(IEnumerable<DBPROPSET> props) : base(props)
		{
		}

		internal SafeDBPROPSETListHandle() : base()
		{
		}

		public static implicit operator DBPROPSET[](SafeDBPROPSETListHandle props) => props.ToArray();

		public static implicit operator SafeDBPROPSETListHandle(DBPROPSET[]? props) => new(props ?? []);
	}

	public abstract class SafeDBSETListHandle<T, TElem> : SafeIMallocHandle, IList<T> where TElem : struct where T : DBSET<TElem>, new()
	{
		private static readonly int elemSize = Marshal.SizeOf(typeof(DBSET_INTERNAL));

		public SafeDBSETListHandle(IEnumerable<T> props) : base(props.Count() * Marshal.SizeOf(typeof(DBSET_INTERNAL)))
		{
			var l = props.ToList();
			for (int i = 0; i < l.Count; i++)
				((IList<T>)this)[i] = l[i];
		}

		[ExcludeFromCodeCoverage]
		internal SafeDBSETListHandle() : base(0) { }

		public int Count { get; set; }
		bool ICollection<T>.IsReadOnly => false;
		public T this[int index]
		{ get => I2T(ToStructure<DBSET_INTERNAL>(elemSize * index)); set { Write(T2I(value, out var h), true, elemSize * index); AddSubReference(h); } }

		public void Add(T item) => this[Count++] = item;

		public void Clear() => Size = Count = 0;

		public bool Contains(T item) => GetEnum().Contains(item);

		public void CopyTo(T[] array, int arrayIndex) => GetEnum().ToArray().CopyTo(array, arrayIndex);

		public IEnumerator<T> GetEnumerator() => GetEnum().GetEnumerator();

		public int IndexOf(T item)
		{
			int i = -1;
			return GetEnum().Any(x => { i++; return x.Equals(item); }) ? i : -1;
		}

		public void Insert(int index, T item)
		{
			if (index < 0 || index > Count) throw new ArgumentOutOfRangeException(nameof(index));
			var newSz = ++Count * elemSize;
			var newPtr = mm.AllocMem(newSz);
			var insertPt = index * elemSize;
			if (index > 0)
				CopyTo(newPtr, 0, insertPt);
			newPtr.Write(item, insertPt, newSz);
			if (index < Count - 1)
				CopyTo(newPtr.Offset(insertPt + elemSize), insertPt, Size - insertPt);
			mm.FreeMem(handle);
			SetHandle(newPtr);
			sz = newSz;
		}

		public bool Remove(T item)
		{
			var idx = IndexOf(item);
			if (idx == -1) return false;
			RemoveAt(idx);
			return true;
		}

		public void RemoveAt(int index)
		{
			var rmvPt = elemSize * index;
			Count--;
			var newSz = Count * elemSize;
			CopyTo(handle.Offset(rmvPt), rmvPt + elemSize, newSz - rmvPt);
			Size -= elemSize;
		}

		IEnumerator IEnumerable.GetEnumerator() => ((IEnumerable<T>)this).GetEnumerator();

		internal static T I2T(in DBSET_INTERNAL i) =>
			new() { properties = i.rgProperties.ToArray<TElem>((int)i.cProperties) ?? [], guidPropertySet = i.guidPropertySet };

		internal static DBSET_INTERNAL T2I(in T i, out SafeIMallocHandle hSub)
		{
			hSub = CreateFromList(i.properties);
			return new() { rgProperties = hSub, cProperties = (uint)i.properties.Length, guidPropertySet = i.guidPropertySet };
		}

		protected void CopyTo(IntPtr ptr, int start = 0, int length = -1)
		{
			if (start > Size) throw new ArgumentOutOfRangeException();
			if (length == -1) length = Size - start;
			if (length + start > Size || length + start < 0) throw new ArgumentOutOfRangeException();
			handle.CopyTo(start, ptr, length);
		}

		protected IEnumerable<T> GetEnum() => ToEnumerable<DBSET_INTERNAL>(Count).Select(p => I2T(p));
	}
}