#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
namespace Vanara.PInvoke;

public static partial class OleDb
{
	public const int CI_VERSION_WDS30 = 0x102; // 258
	public const int CI_VERSION_WDS40 = 0x109; // 265
	public const int CI_VERSION_WIN70 = 0x700; // 1792

	//
	// Use this path for the null catalog, one that doesn't have an index.
	// Use it to search for properties of files that are not indexed.
	//

	public const string CINULLCATALOG = "::_noindex_::";

	//
	// Use this path to connect to the server for administration work
	// (i.e. DocStoreAdmin.) No catalog is associated with the connection
	//

	public const string CIADMIN = "::_nodocstore_::";

	// The Index Server Data Source Object Guid

	public static readonly Guid CLSID_INDEX_SERVER_DSO = new(0xF9AE8980, 0x7E52, 0x11d0, 0x89, 0x64, 0x00, 0xC0, 0x4F, 0xD6, 0x11, 0xD7);


	// The filename PKEY_Filename property set
	public static readonly Guid PSGUID_FILENAME = new(0x41CF5AE0, 0xF75A, 0x4806, 0xBD, 0x87, 0x59, 0xC7, 0xD9, 0x24, 0x8E, 0xB9);
	public const int PID_FILENAME = 100;


	// File System Content Index Framework property set

	public static readonly Guid DBPROPSET_FSCIFRMWRK_EXT = new(0xA9BD1526, 0x6A80, 0x11D0, 0x8C, 0x9D, 0x00, 0x20, 0xAF, 0x1D, 0x74, 0x0E);

	public const int DBPROP_CI_CATALOG_NAME = 2;
	public const int DBPROP_CI_INCLUDE_SCOPES = 3;
	public const int DBPROP_CI_DEPTHS = 4; // obsolete
	public const int DBPROP_CI_SCOPE_FLAGS = 4;
	public const int DBPROP_CI_EXCLUDE_SCOPES = 5;
	public const int DBPROP_CI_SECURITY_ID = 6;
	public const int DBPROP_CI_QUERY_TYPE = 7;
	public const int DBPROP_CI_PROVIDER = 8;

	// The VT_UI4 value of DBPROP_CI_PROVIDER

	public const uint CI_PROVIDER_MSSEARCH = 1; // Only try MSSearch
	public const uint CI_PROVIDER_INDEXING_SERVICE = 2; // Only try Indexing Service
	public const uint CI_PROVIDER_ALL = 0xffffffff; // Try all -- the default

	// Session level Query Extension property set

	public static readonly Guid DBPROPSET_SESS_QUERYEXT = new(0x63623309, 0x2d8b, 0x4d17, 0xb1, 0x52, 0x6e, 0x29, 0x56, 0xc2, 0x6a, 0x70);

	public const int DBPROP_DEFAULT_EQUALS_BEHAVIOR = 2;

	// Query Extension property set

	public static readonly Guid DBPROPSET_QUERYEXT = new(0xA7AC77ED, 0xF8D7, 0x11CE, 0xA7, 0x98, 0x00, 0x20, 0xF8, 0x00, 0x80, 0x25);

	public const int DBPROP_USECONTENTINDEX = 2;
	public const int DBPROP_DEFERNONINDEXEDTRIMMING = 3;
	public const int DBPROP_USEEXTENDEDDBTYPES = 4;
	public const int DBPROP_IGNORENOISEONLYCLAUSES = 5;
	public const int DBPROP_GENERICOPTIONS_STRING = 6;
	public const int DBPROP_FIRSTROWS = 7;
	public const int DBPROP_DEFERCATALOGVERIFICATION = 8;
	public const int DBPROP_CATALOGLISTID = 9;
	public const int DBPROP_GENERATEPARSETREE = 10;
	public const int DBPROP_APPLICATION_NAME = 11;
	public const int DBPROP_FREETEXTANYTERM = 12;
	public const int DBPROP_FREETEXTUSESTEMMING = 13;
	public const int DBPROP_IGNORESBRI = 14;
	public const int DBPROP_DONOTCOMPUTEEXPENSIVEPROPS = 15;
	public const int DBPROP_ENABLEROWSETEVENTS = 16;

	// Content Index Framework Core property set

	public static readonly Guid DBPROPSET_CIFRMWRKCORE_EXT = new(0xafafaca5, 0xb5d1, 0x11d0, 0x8c, 0x62, 0x00, 0xc0, 0x4f, 0xc2, 0xdb, 0x8d);

	public const int DBPROP_MACHINE = 2;
	public const int DBPROP_CLIENT_CLSID = 3;

	// MSIDXS Rowset property set

	public static readonly Guid DBPROPSET_MSIDXS_ROWSETEXT = new(0xaa6ee6b0, 0xe828, 0x11d0, 0xb2, 0x3e, 0x00, 0xaa, 0x00, 0x47, 0xfc, 0x01);

	public const int MSIDXSPROP_ROWSETQUERYSTATUS = 2;
	public const int MSIDXSPROP_COMMAND_LOCALE_STRING = 3;
	public const int MSIDXSPROP_QUERY_RESTRICTION = 4;
	public const int MSIDXSPROP_PARSE_TREE = 5;
	public const int MSIDXSPROP_MAX_RANK = 6;
	public const int MSIDXSPROP_RESULTS_FOUND = 7;
	public const int MSIDXSPROP_WHEREID = 8;
	public const int MSIDXSPROP_SERVER_VERSION = 9;
	public const int MSIDXSPROP_SERVER_WINVER_MAJOR = 10;
	public const int MSIDXSPROP_SERVER_WINVER_MINOR = 11;
	public const int MSIDXSPROP_SERVER_NLSVERSION = 12;
	public const int MSIDXSPROP_SERVER_NLSVER_DEFINED = 13;
	public const int MSIDXSPROP_SAME_SORTORDER_USED = 14;

	//
	// Query status values returned by MSIDXSPROP_ROWSETQUERYSTATUS
	//
	// Bits Effect
	// ----- -----------------------------------------------------
	// 00-02 Fill Status: How data is being updated, if at all.
	// 03-15 Bitfield query reliability: How accurate the result is

	public const uint STAT_BUSY = 0;
	public const uint STAT_ERROR = 0x1;
	public const uint STAT_DONE = 0x2;
	public const uint STAT_REFRESH = 0x3;
	public const uint STAT_PARTIAL_SCOPE = 0x8;
	public const uint STAT_NOISE_WORDS = 0x10;
	public const uint STAT_CONTENT_OUT_OF_DATE = 0x20;
	public const uint STAT_REFRESH_INCOMPLETE = 0x40;
	public const uint STAT_CONTENT_QUERY_INCOMPLETE = 0x80;
	public const uint STAT_TIME_LIMIT_EXCEEDED = 0x100;
	public const uint STAT_SHARING_VIOLATION = 0x200;
	public const uint STAT_MISSING_RELDOC = 0x400;
	public const uint STAT_MISSING_PROP_IN_RELDOC = 0x800;
	public const uint STAT_RELDOC_ACCESS_DENIED = 0x1000;
	public const uint STAT_COALESCE_COMP_ALL_NOISE = 0x2000;

	public static uint QUERY_FILL_STATUS(uint x) => x & 0x7;
	public static uint QUERY_RELIABILITY_STATUS(uint x) => x & 0xFFF8;

	// Scope flags

	public const int QUERY_SHALLOW = 0;
	public const int QUERY_DEEP = 1;
	public const int QUERY_PHYSICAL_PATH = 0;
	public const int QUERY_VIRTUAL_PATH = 2;

	// query property set (PSGUID_QUERY) properties not defined in oledb.h

	public const int PROPID_QUERY_WORKID = 5;
	public const int PROPID_QUERY_UNFILTERED = 7;
	public const int PROPID_QUERY_VIRTUALPATH = 9;
	public const int PROPID_QUERY_LASTSEENTIME = 10;

	//
	// Change or get the current state of a catalog specified.
	//
	public const int CICAT_STOPPED = 0x1;
	public const int CICAT_READONLY = 0x2;
	public const int CICAT_WRITABLE = 0x4;
	public const int CICAT_NO_QUERY = 0x8;
	public const int CICAT_GET_STATE = 0x10;
	public const int CICAT_ALL_OPENED = 0x20;

	//
	// Query catalog state
	//

	public const int CI_STATE_SHADOW_MERGE = 0x0001; // Index is performing a shadow merge
	public const int CI_STATE_MASTER_MERGE = 0x0002; // Index is performing a master merge
	public const int CI_STATE_CONTENT_SCAN_REQUIRED = 0x0004; // Index is likely corrupt, and a rescan is required
	public const int CI_STATE_ANNEALING_MERGE = 0x0008; // Index is performing an annealing (optimizing) merge
	public const int CI_STATE_SCANNING = 0x0010; // Scans are in-progress
	public const int CI_STATE_RECOVERING = 0x0020; // Index metadata is being recovered
	public const int CI_STATE_INDEX_MIGRATION_MERGE = 0x0040; // Reserved for future use
	public const int CI_STATE_LOW_MEMORY = 0x0080; // Indexing is paused due to low memory availability
	public const int CI_STATE_HIGH_IO = 0x0100; // Indexing is paused due to a high rate of I/O
	public const int CI_STATE_MASTER_MERGE_PAUSED = 0x0200; // Master merge is paused
	public const int CI_STATE_READ_ONLY = 0x0400; // Indexing has been manually paused (read-only)
	public const int CI_STATE_BATTERY_POWER = 0x0800; // Indexing is paused to conserve battery life
	public const int CI_STATE_USER_ACTIVE = 0x1000; // Indexing is paused due to high user activity (keyboard/mouse)
	public const int CI_STATE_STARTING = 0x2000; // Index is still starting up
	public const int CI_STATE_READING_USNS = 0x4000; // USNs on NTFS volumes are being processed
	public const int CI_STATE_DELETION_MERGE = 0x8000; // Index is performing a deletion merge
	public const int CI_STATE_LOW_DISK = 0x10000; // Index is paused due to low disk availability
	public const int CI_STATE_HIGH_CPU = 0x20000; // Index is paused due to high CPU
	public const int CI_STATE_BATTERY_POLICY = 0x40000; // Indexing is paused due to backoff on battery policy

	[StructLayout(LayoutKind.Sequential)]
	public struct CI_STATE
	{
		public uint cbStruct;
		public uint cWordList;
		public uint cPersistentIndex;
		public uint cQueries;
		public uint cDocuments;
		public uint cFreshTest;
		public uint dwMergeProgress;
		public uint eState;
		public uint cFilteredDocuments;
		public uint cTotalDocuments;
		public uint cPendingScans;
		public uint dwIndexSize;
		public uint cUniqueKeys;
		public uint cSecQDocuments;
		public uint dwPropCacheSize;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct CIPROPERTYDEF
	{
		public string wcsFriendlyName;
		public uint dbType;
		public DBID dbCol;
	}
}
