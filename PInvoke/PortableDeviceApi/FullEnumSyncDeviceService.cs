#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
using static Vanara.PInvoke.Ole32;

namespace Vanara.PInvoke;

public static partial class PortableDeviceApi
{
	/*****************************************************************************
		Full Enumeration Sync Service Info
	******************************************************************************/

	public static Guid SERVICE_FullEnumSync => new(0x28d3aac9, 0xc075, 0x44be, 0x88, 0x81, 0x65, 0xf3, 0x8d, 0x30, 0x59, 0x09);

	public const string NAME_FullEnumSyncSvc = "FullEnumSync";
	public const int TYPE_FullEnumSyncSvc = 1;


	/*****************************************************************************
		Full Enumeration Sync Service Properties
	******************************************************************************/

	public static Guid NAMESPACE_FullEnumSyncSvc => new(0x63b10e6c, 0x4f3a, 0x456d, 0x95, 0xcb, 0x98, 0x94, 0xed, 0xec, 0x9f, 0xa5);


	/// <summary> PKEY_FullEnumSyncSvc_VersionProps
	/// Provides information about change units and version properties. The
	/// format for the dataset is
	/// 
	/// UINT32 Number of change units
	/// UINT128 Namespace GUID for first change unit property key
	/// UINT32 Namespace ID for the first change unit property key
	/// UINT32 Number of properties associated with this change unit
	/// UINT128 Namespace GUID for first property key in change unit
	/// UINT32 Namespace ID for first property key in change unit
	/// ... Repeat for number of property keys
	/// ... Repeat for number of change units
	/// 
	/// NOTE: If all change units use the same property key specify a namespace
	/// GUID of GUID_NULL (all 0's) and a namespace ID of 0.
	/// 
	/// Type: AUInt8
	/// Form: None
	/// </summary> 
	[CorrespondingType(typeof(byte))]
	public static PROPERTYKEY PKEY_FullEnumSyncSvc_VersionProps => new(new(0x63b10e6c, 0x4f3a, 0x456d, 0x95, 0xcb, 0x98, 0x94, 0xed, 0xec, 0x9f, 0xa5), 3);

	public const string NAME_FullEnumSyncSvc_VersionProps = "FullEnumVersionProps";


	/// <summary> PKEY_FullEnumSyncSvc_ReplicaID
	/// Contains the GUID representing this replica in the sync community.
	/// 
	/// Type: UInt128
	/// Form: None
	/// </summary> 
#if NET7_0_OR_GREATER
 	[CorrespondingType(typeof(UInt128))]
#endif
	public static PROPERTYKEY PKEY_FullEnumSyncSvc_ReplicaID => new(new(0x63b10e6c, 0x4f3a, 0x456d, 0x95, 0xcb, 0x98, 0x94, 0xed, 0xec, 0x9f, 0xa5), 4);

	public const string NAME_FullEnumSyncSvc_ReplicaID = "FullEnumReplicaID";


	/// <summary> PKEY_FullEnumSyncSvc_KnowledgeObjectID
	/// Object ID to be used for the knowledge object
	/// 
	/// Type: UInt32
	/// Form: ObjectID
	/// </summary> 
	[CorrespondingType(typeof(uint))]
	public static PROPERTYKEY PKEY_FullEnumSyncSvc_KnowledgeObjectID => new(new(0x63b10e6c, 0x4f3a, 0x456d, 0x95, 0xcb, 0x98, 0x94, 0xed, 0xec, 0x9f, 0xa5), 7);

	public const string NAME_FullEnumSyncSvc_KnowledgeObjectID = "FullEnumKnowledgeObjectID";


	/// <summary> PKEY_FullEnumSyncSvc_LastSyncProxyID
	/// Contains a GUID indicating the last sync proxy to perform a sync operation
	/// 
	/// Type: UInt128
	/// Form: None
	/// </summary> 
#if NET7_0_OR_GREATER
 	[CorrespondingType(typeof(UInt128))]
#endif
	public static PROPERTYKEY PKEY_FullEnumSyncSvc_LastSyncProxyID => new(new(0x63b10e6c, 0x4f3a, 0x456d, 0x95, 0xcb, 0x98, 0x94, 0xed, 0xec, 0x9f, 0xa5), 8);

	public const string NAME_FullEnumSyncSvc_LastSyncProxyID = "FullEnumLastSyncProxyID";


	/// <summary> PKEY_FullEnumSyncSvc_ProviderVersion
	/// Contains a device defined value giving the version of the provider
	/// currently in use on the device. This version must be incremented whenever
	/// new properties are added to the device implementation so that they will
	/// be recognized and managed as part of synchronization. 0 is reserved.
	/// 
	/// Type: UInt16
	/// Form: None
	/// </summary> 
	[CorrespondingType(typeof(ushort))]
	public static PROPERTYKEY PKEY_FullEnumSyncSvc_ProviderVersion => new(new(0x63b10e6c, 0x4f3a, 0x456d, 0x95, 0xcb, 0x98, 0x94, 0xed, 0xec, 0x9f, 0xa5), 9);

	public const string NAME_FullEnumSyncSvc_ProviderVersion = "FullEnumProviderVersion";


	/// <summary> PKEY_FullEnumSyncSvc_SyncFormat
	/// Indicates the format GUID for the object format that is to be used in the
	/// sync operation.
	/// 
	/// Type: UInt128
	/// Form: None
	/// </summary> 
#if NET7_0_OR_GREATER
 	[CorrespondingType(typeof(UInt128))]
#endif
	public static PROPERTYKEY PKEY_FullEnumSyncSvc_SyncFormat => PKEY_SyncSvc_SyncFormat;
	public const string NAME_FullEnumSyncSvc_SyncFormat = NAME_SyncSvc_SyncFormat;

	/// <summary> PKEY_FullEnumSyncSvc_LocalOnlyDelete
	/// Boolean flag indicating whether deletes of objects on the service host
	/// should be treated as "local only" and not propogated to other sync
	/// participants. The alternative is "true sync" in which deletes on the
	/// service host are propogated to all other sync participants.
	/// 
	/// Type: UInt8
	/// Form: None
	/// </summary> 
	[CorrespondingType(typeof(byte))]
	public static PROPERTYKEY PKEY_FullEnumSyncSvc_LocalOnlyDelete => PKEY_SyncSvc_LocalOnlyDelete;
	public const string NAME_FullEnumSyncSvc_LocalOnlyDelete = NAME_SyncSvc_LocalOnlyDelete;

	/// <summary> PKEY_FullEnumSyncSvc_FilterType
	/// Type: UInt8
	/// Form: None
	/// </summary> 
	[CorrespondingType(typeof(byte))]
	public static PROPERTYKEY PKEY_FullEnumSyncSvc_FilterType => PKEY_SyncSvc_FilterType;
	public const string NAME_FullEnumSyncSvc_FilterType = NAME_SyncSvc_FilterType;

	/*****************************************************************************
		Full Enumeration Sync Service Object Formats
	******************************************************************************/

	/// <summary> FORMAT_FullEnumSyncKnowledge
	/// 
	/// Knowledge object format
	/// 
	/// </summary> 

	public static Guid FORMAT_FullEnumSyncKnowledge => new(0x221bce32, 0x221b, 0x4f45, 0xb4, 0x8b, 0x80, 0xde, 0x9a, 0x93, 0xa4, 0x4a);

	public const string NAME_FullEnumSyncKnowledge = "FullEnumSyncKnowledge";

	/*****************************************************************************
		Full Enumeration Sync Service Methods
	******************************************************************************/


	/*  Inherited methods */

	public static Guid METHOD_FullEnumSyncSvc_BeginSync => METHOD_SyncSvc_BeginSync;
	public const string NAME_FullEnumSyncSvc_BeginSync = NAME_SyncSvc_BeginSync;

	public static Guid METHOD_FullEnumSyncSvc_EndSync => METHOD_SyncSvc_EndSync;
	public const string NAME_FullEnumSyncSvc_EndSync = NAME_SyncSvc_EndSync;
}