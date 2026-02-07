#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
using static Vanara.PInvoke.Ole32;

namespace Vanara.PInvoke;

public static partial class PortableDeviceApi
{
	/*****************************************************************************
		 Service Properties
	******************************************************************************/

	public static Guid NAMESPACE_SyncSvc => new(0x703d392c, 0x532c, 0x4607, 0x91, 0x58, 0x9c, 0xea, 0x74, 0x2f, 0x3a, 0x16);


	/// <summary> PKEY_SyncSvc_SyncFormat
	/// Indicates the format GUID for the object format that is to be used in the
	/// sync operation.
	/// 
	/// Type: UInt128
	/// Form: None
	/// </summary>
#if NET7_0_OR_GREATER
 	[CorrespondingType(typeof(UInt128))]
#endif
	public static PROPERTYKEY PKEY_SyncSvc_SyncFormat = new(new(0x703d392c, 0x532c, 0x4607, 0x91, 0x58, 0x9c, 0xea, 0x74, 0x2f, 0x3a, 0x16), 2);

	public const string NAME_SyncSvc_SyncFormat = "SyncFormat";


	/// <summary> PKEY_SyncSvc_LocalOnlyDelete
	/// Boolean flag indicating whether deletes of objects on the service host
	/// should be treated as "local only" and not propogated to other sync
	/// participants. The alternative is "true sync" in which deletes on the
	/// service host are propogated to all other sync participants.
	/// 
	/// Type: UInt8
	/// Form: None
	/// </summary>
	[CorrespondingType(typeof(byte))]
	public static PROPERTYKEY PKEY_SyncSvc_LocalOnlyDelete = new(new(0x703d392c, 0x532c, 0x4607, 0x91, 0x58, 0x9c, 0xea, 0x74, 0x2f, 0x3a, 0x16), 3);

	public const string NAME_SyncSvc_LocalOnlyDelete = "LocalOnlyDelete";


	/// <summary> PKEY_SyncSvc_FilterType
	/// Value describing type of the filter
	/// 
	/// Type: UInt8
	/// Form: None
	/// </summary>
	[CorrespondingType(typeof(SYNCSVC_FILTER))]
	public static PROPERTYKEY PKEY_SyncSvc_FilterType = new(new(0x703d392c, 0x532c, 0x4607, 0x91, 0x58, 0x9c, 0xea, 0x74, 0x2f, 0x3a, 0x16), 4);

	public const string NAME_SyncSvc_FilterType = "FilterType";

	public enum SYNCSVC_FILTER : byte
	{
		/// <summary> No filter is applied.</summary>
		SYNCSVC_FILTER_NONE = 0,
		/// <summary> Filter for contacts with phone numbers.</summary>
		SYNCSVC_FILTER_CONTACTS_WITH_PHONE = 1,
		/// <summary> Filter for active tasks.</summary>
		SYNCSVC_FILTER_TASK_ACTIVE = 2,
		/// <summary> Filter for calendar windows with recurrence.</summary>
		SYNCSVC_FILTER_CALENDAR_WINDOW_WITH_RECURRENCE = 3
	}

	/// <summary> PKEY_SyncSvc_SyncObjectReferences
	/// Value describing whether object references should be included as part of
	/// the sync process or not
	/// 
	/// Type: UInt8
	/// Form: Enum
	/// </summary>
	[CorrespondingType(typeof(ENUM_SyncSvc_SyncObjectReferences))]
	public static PROPERTYKEY PKEY_SyncSvc_SyncObjectReferences = new(new(0x703d392c, 0x532c, 0x4607, 0x91, 0x58, 0x9c, 0xea, 0x74, 0x2f, 0x3a, 0x16), 5);

	public const string NAME_SyncSvc_SyncObjectReferences = "SyncObjectReferences";

	public enum ENUM_SyncSvc_SyncObjectReferences : byte
	{
		/// <summary> Object references are not included in the sync process.</summary>
		Disabled = 0x00,
		/// <summary> Object references are included in the sync process.</summary>
		Enabled = 0xff
	}

	/*****************************************************************************
		 Service Object Property Keys
	******************************************************************************/

	public static Guid NAMESPACE_SyncObj => new(0x37364f58, 0x2f74, 0x4981, 0x99, 0xa5, 0x7a, 0xe2, 0x8a, 0xee, 0xe3, 0x19);


	/// <summary> SyncObj.LastAuthorProxyID
	/// Contains a GUID indicating the proxy ID of the last proxy to author the
	/// object
	/// 
	/// Type: UInt128
	/// Form: None
	/// </summary>
#if NET7_0_OR_GREATER
 	[CorrespondingType(typeof(UInt128))]
#endif
	public static PROPERTYKEY PKEY_SyncObj_LastAuthorProxyID = new(new(0x37364f58, 0x2f74, 0x4981, 0x99, 0xa5, 0x7a, 0xe2, 0x8a, 0xee, 0xe3, 0x19), 2);

	public const string NAME_SyncObj_LastAuthorProxyID = "LastAuthorProxyID";


	/*****************************************************************************
		 Service Methods
	******************************************************************************/


	/// <summary> METHOD_SyncSvc_BeginSync
	/// </summary>

	public static Guid METHOD_SyncSvc_BeginSync => new(0x63803e07, 0xc713, 0x45d3, 0x81, 0x19, 0x34, 0x79, 0xb3, 0x1d, 0x35, 0x92);

	public const string NAME_SyncSvc_BeginSync = "BeginSync";

	/// <summary> METHOD_SyncSvc_EndSync
	/// </summary>

	public static Guid METHOD_SyncSvc_EndSync => new(0x40f3f0f7, 0xa539, 0x422e, 0x98, 0xdd, 0xfd, 0x8d, 0x38, 0x5c, 0x88, 0x49);
	public const string NAME_SyncSvc_EndSync = "EndSync";
}