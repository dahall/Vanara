namespace Vanara.PInvoke
{
	public partial struct HRESULT
	{
		/// <summary>Success</summary>
		public const uint S_OK = 0;

		/// <summary>False</summary>
		public const uint S_FALSE = 1;

		/// <summary></summary>
		public const uint COR_E_OBJECTDISPOSED = 0x80131622;

		/// <summary></summary>
		public const uint DESTS_E_NO_MATCHING_ASSOC_HANDLER = 0x80040f03;

		/// <summary></summary>
		public const uint SCRIPT_E_REPORTED = 0x80020101;

		/// <summary></summary>
		public const uint WC_E_GREATERTHAN = 0xc00cee23;

		/// <summary></summary>
		public const uint WC_E_SYNTAX = 0xc00cee2d;

		/// <summary>The underlying file was converted to compound file format.</summary>
		public const uint STG_S_CONVERTED = 0x00030200;

		/// <summary>The storage operation should block until more data is available.</summary>
		public const uint STG_S_BLOCK = 0x00030201;

		/// <summary>The storage operation should retry immediately.</summary>
		public const uint STG_S_RETRYNOW = 0x00030202;

		/// <summary>The notified event sink will not influence the storage operation.</summary>
		public const uint STG_S_MONITORING = 0x00030203;

		/// <summary>Multiple opens prevent consolidated (commit succeeded).</summary>
		public const uint STG_S_MULTIPLEOPENS = 0x00030204;

		/// <summary>Consolidation of the storage file failed (commit succeeded).</summary>
		public const uint STG_S_CONSOLIDATIONFAILED = 0x00030205;

		/// <summary>Consolidation of the storage file is inappropriate (commit succeeded).</summary>
		public const uint STG_S_CANNOTCONSOLIDATE = 0x00030206;

		/// <summary>Use the registry database to provide the requested information.</summary>
		public const uint OLE_S_USEREG = 0x00040000;

		/// <summary>Success, but static.</summary>
		public const uint OLE_S_STATIC = 0x00040001;

		/// <summary>Macintosh clipboard format.</summary>
		public const uint OLE_S_MAC_CLIPFORMAT = 0x00040002;

		/// <summary>Successful drop took place.</summary>
		public const uint DRAGDROP_S_DROP = 0x00040100;

		/// <summary>Drag-drop operation canceled.</summary>
		public const uint DRAGDROP_S_CANCEL = 0x00040101;

		/// <summary>Use the default cursor.</summary>
		public const uint DRAGDROP_S_USEDEFAULTCURSORS = 0x00040102;

		/// <summary>Data has same FORMATETC.</summary>
		public const uint DATA_S_SAMEFORMATETC = 0x00040130;

		/// <summary>View is already frozen.</summary>
		public const uint VIEW_S_ALREADY_FROZEN = 0x00040140;

		/// <summary>FORMATETC not supported.</summary>
		public const uint CACHE_S_FORMATETC_NOTSUPPORTED = 0x00040170;

		/// <summary>Same cache.</summary>
		public const uint CACHE_S_SAMECACHE = 0x00040171;

		/// <summary>Some caches are not updated.</summary>
		public const uint CACHE_S_SOMECACHES_NOTUPDATED = 0x00040172;

		/// <summary>Invalid verb for OLE object.</summary>
		public const uint OLEOBJ_S_INVALIDVERB = 0x00040180;

		/// <summary>Verb number is valid but verb cannot be done now.</summary>
		public const uint OLEOBJ_S_CANNOT_DOVERB_NOW = 0x00040181;

		/// <summary>Invalid window handle passed.</summary>
		public const uint OLEOBJ_S_INVALIDHWND = 0x00040182;

		/// <summary>Message is too long; some of it had to be truncated before displaying.</summary>
		public const uint INPLACE_S_TRUNCATED = 0x000401A0;

		/// <summary>Unable to convert OLESTREAM to IStorage.</summary>
		public const uint CONVERT10_S_NO_PRESENTATION = 0x000401C0;

		/// <summary>Moniker reduced to itself.</summary>
		public const uint MK_S_REDUCED_TO_SELF = 0x000401E2;

		/// <summary>Common prefix is this moniker.</summary>
		public const uint MK_S_ME = 0x000401E4;

		/// <summary>Common prefix is input moniker.</summary>
		public const uint MK_S_HIM = 0x000401E5;

		/// <summary>Common prefix is both monikers.</summary>
		public const uint MK_S_US = 0x000401E6;

		/// <summary>Moniker is already registered in running object table.</summary>
		public const uint MK_S_MONIKERALREADYREGISTERED = 0x000401E7;

		/// <summary>An event was able to invoke some, but not all, of the subscribers.</summary>
		public const uint EVENT_S_SOME_SUBSCRIBERS_FAILED = 0x00040200;

		/// <summary>An event was delivered, but there were no subscribers.</summary>
		public const uint EVENT_S_NOSUBSCRIBERS = 0x00040202;

		/// <summary>The task is ready to run at its next scheduled time.</summary>
		public const uint SCHED_S_TASK_READY = 0x00041300;

		/// <summary>The task is currently running.</summary>
		public const uint SCHED_S_TASK_RUNNING = 0x00041301;

		/// <summary>The task will not run at the scheduled times because it has been disabled.</summary>
		public const uint SCHED_S_TASK_DISABLED = 0x00041302;

		/// <summary>The task has not yet run.</summary>
		public const uint SCHED_S_TASK_HAS_NOT_RUN = 0x00041303;

		/// <summary>There are no more runs scheduled for this task.</summary>
		public const uint SCHED_S_TASK_NO_MORE_RUNS = 0x00041304;

		/// <summary>One or more of the properties that are needed to run this task on a schedule have not been set.</summary>
		public const uint SCHED_S_TASK_NOT_SCHEDULED = 0x00041305;

		/// <summary>The last run of the task was terminated by the user.</summary>
		public const uint SCHED_S_TASK_TERMINATED = 0x00041306;

		/// <summary>Either the task has no triggers, or the existing triggers are disabled or not set.</summary>
		public const uint SCHED_S_TASK_NO_VALID_TRIGGERS = 0x00041307;

		/// <summary>Event triggers do not have set run times.</summary>
		public const uint SCHED_S_EVENT_TRIGGER = 0x00041308;

		/// <summary>The task is registered, but not all specified triggers will start the task.</summary>
		public const uint SCHED_S_SOME_TRIGGERS_FAILED = 0x0004131B;

		/// <summary>The task is registered, but it might fail to start. Batch logon privilege needs to be enabled for the task principal.</summary>
		public const uint SCHED_S_BATCH_LOGON_PROBLEM = 0x0004131C;

		/// <summary>An asynchronous operation was specified. The operation has begun, but its outcome is not known yet.</summary>
		public const uint XACT_S_ASYNC = 0x0004D000;

		/// <summary>The method call succeeded because the transaction was read-only.</summary>
		public const uint XACT_S_READONLY = 0x0004D002;

		/// <summary>The transaction was successfully aborted. However, this is a coordinated transaction, and a number of enlisted resources were aborted outright because they could not support abort-retaining semantics.</summary>
		public const uint XACT_S_SOMENORETAIN = 0x0004D003;

		/// <summary>No changes were made during this call, but the sink wants another chance to look if any other sinks make further changes.</summary>
		public const uint XACT_S_OKINFORM = 0x0004D004;

		/// <summary>The sink is content and wants the transaction to proceed. Changes were made to one or more resources during this call.</summary>
		public const uint XACT_S_MADECHANGESCONTENT = 0x0004D005;

		/// <summary>The sink is for the moment and wants the transaction to proceed, but if other changes are made following this return by other event sinks, this sink wants another chance to look.</summary>
		public const uint XACT_S_MADECHANGESINFORM = 0x0004D006;

		/// <summary>The transaction was successfully aborted. However, the abort was nonretaining.</summary>
		public const uint XACT_S_ALLNORETAIN = 0x0004D007;

		/// <summary>An abort operation was already in progress.</summary>
		public const uint XACT_S_ABORTING = 0x0004D008;

		/// <summary>The resource manager has performed a single-phase commit of the transaction.</summary>
		public const uint XACT_S_SINGLEPHASE = 0x0004D009;

		/// <summary>The local transaction has not aborted.</summary>
		public const uint XACT_S_LOCALLY_OK = 0x0004D00A;

		/// <summary>The resource manager has requested to be the coordinator (last resource manager) for the transaction.</summary>
		public const uint XACT_S_LASTRESOURCEMANAGER = 0x0004D010;

		/// <summary>Not all the requested interfaces were available.</summary>
		public const uint CO_S_NOTALLINTERFACES = 0x00080012;

		/// <summary>The specified machine name was not found in the cache.</summary>
		public const uint CO_S_MACHINENAMENOTFOUND = 0x00080013;

		/// <summary>The function completed successfully, but it must be called again to complete the context.</summary>
		public const uint SEC_I_CONTINUE_NEEDED = 0x00090312;

		/// <summary>The function completed successfully, but CompleteToken must be called.</summary>
		public const uint SEC_I_COMPLETE_NEEDED = 0x00090313;

		/// <summary>The function completed successfully, but both CompleteToken and this function must be called to complete the context.</summary>
		public const uint SEC_I_COMPLETE_AND_CONTINUE = 0x00090314;

		/// <summary>The logon was completed, but no network authority was available. The logon was made using locally known information.</summary>
		public const uint SEC_I_LOCAL_LOGON = 0x00090315;

		/// <summary>The context has expired and can no longer be used.</summary>
		public const uint SEC_I_CONTEXT_EXPIRED = 0x00090317;

		/// <summary>The credentials supplied were not complete and could not be verified. Additional information can be returned from the context.</summary>
		public const uint SEC_I_INCOMPLETE_CREDENTIALS = 0x00090320;

		/// <summary>The context data must be renegotiated with the peer.</summary>
		public const uint SEC_I_RENEGOTIATE = 0x00090321;

		/// <summary>There is no LSA mode context associated with this context.</summary>
		public const uint SEC_I_NO_LSA_CONTEXT = 0x00090323;

		/// <summary>A signature operation must be performed before the user can authenticate.</summary>
		public const uint SEC_I_SIGNATURE_NEEDED = 0x0009035C;

		/// <summary>The protected data needs to be reprotected.</summary>
		public const uint CRYPT_I_NEW_PROTECTION_REQUIRED = 0x00091012;

		/// <summary>The requested operation is pending completion.</summary>
		public const uint NS_S_CALLPENDING = 0x000D0000;

		/// <summary>The requested operation was aborted by the client.</summary>
		public const uint NS_S_CALLABORTED = 0x000D0001;

		/// <summary>The stream was purposefully stopped before completion.</summary>
		public const uint NS_S_STREAM_TRUNCATED = 0x000D0002;

		/// <summary>The requested operation has caused the source to rebuffer.</summary>
		public const uint NS_S_REBUFFERING = 0x000D0BC8;

		/// <summary>The requested operation has caused the source to degrade codec quality.</summary>
		public const uint NS_S_DEGRADING_QUALITY = 0x000D0BC9;

		/// <summary>The transcryptor object has reached end of file.</summary>
		public const uint NS_S_TRANSCRYPTOR_EOF = 0x000D0BDB;

		/// <summary>An upgrade is needed for the theme manager to correctly show this skin. Skin reports version: %.1f.</summary>
		public const uint NS_S_WMP_UI_VERSIONMISMATCH = 0x000D0FE8;

		/// <summary>An error occurred in one of the UI components.</summary>
		public const uint NS_S_WMP_EXCEPTION = 0x000D0FE9;

		/// <summary>Successfully loaded a GIF file.</summary>
		public const uint NS_S_WMP_LOADED_GIF_IMAGE = 0x000D1040;

		/// <summary>Successfully loaded a PNG file.</summary>
		public const uint NS_S_WMP_LOADED_PNG_IMAGE = 0x000D1041;

		/// <summary>Successfully loaded a BMP file.</summary>
		public const uint NS_S_WMP_LOADED_BMP_IMAGE = 0x000D1042;

		/// <summary>Successfully loaded a JPG file.</summary>
		public const uint NS_S_WMP_LOADED_JPG_IMAGE = 0x000D1043;

		/// <summary>Drop this frame.</summary>
		public const uint NS_S_WMG_FORCE_DROP_FRAME = 0x000D104F;

		/// <summary>The specified stream has already been rendered.</summary>
		public const uint NS_S_WMR_ALREADYRENDERED = 0x000D105F;

		/// <summary>The specified type partially matches this pin type.</summary>
		public const uint NS_S_WMR_PINTYPEPARTIALMATCH = 0x000D1060;

		/// <summary>The specified type fully matches this pin type.</summary>
		public const uint NS_S_WMR_PINTYPEFULLMATCH = 0x000D1061;

		/// <summary>The timestamp is late compared to the current render position. Advise dropping this frame.</summary>
		public const uint NS_S_WMG_ADVISE_DROP_FRAME = 0x000D1066;

		/// <summary>The timestamp is severely late compared to the current render position. Advise dropping everything up to the next key frame.</summary>
		public const uint NS_S_WMG_ADVISE_DROP_TO_KEYFRAME = 0x000D1067;

		/// <summary>No burn rights. You will be prompted to buy burn rights when you try to burn this file to an audio CD.</summary>
		public const uint NS_S_NEED_TO_BUY_BURN_RIGHTS = 0x000D10DB;

		/// <summary>Failed to clear playlist because it was aborted by user.</summary>
		public const uint NS_S_WMPCORE_PLAYLISTCLEARABORT = 0x000D10FE;

		/// <summary>Failed to remove item in the playlist since it was aborted by user.</summary>
		public const uint NS_S_WMPCORE_PLAYLISTREMOVEITEMABORT = 0x000D10FF;

		/// <summary>Playlist is being generated asynchronously.</summary>
		public const uint NS_S_WMPCORE_PLAYLIST_CREATION_PENDING = 0x000D1102;

		/// <summary>Validation of the media is pending.</summary>
		public const uint NS_S_WMPCORE_MEDIA_VALIDATION_PENDING = 0x000D1103;

		/// <summary>Encountered more than one Repeat block during ASX processing.</summary>
		public const uint NS_S_WMPCORE_PLAYLIST_REPEAT_SECONDARY_SEGMENTS_IGNORED = 0x000D1104;

		/// <summary>Current state of WMP disallows calling this method or property.</summary>
		public const uint NS_S_WMPCORE_COMMAND_NOT_AVAILABLE = 0x000D1105;

		/// <summary>Name for the playlist has been auto generated.</summary>
		public const uint NS_S_WMPCORE_PLAYLIST_NAME_AUTO_GENERATED = 0x000D1106;

		/// <summary>The imported playlist does not contain all items from the original.</summary>
		public const uint NS_S_WMPCORE_PLAYLIST_IMPORT_MISSING_ITEMS = 0x000D1107;

		/// <summary>The M3U playlist has been ignored because it only contains one item.</summary>
		public const uint NS_S_WMPCORE_PLAYLIST_COLLAPSED_TO_SINGLE_MEDIA = 0x000D1108;

		/// <summary>The open for the child playlist associated with this media is pending.</summary>
		public const uint NS_S_WMPCORE_MEDIA_CHILD_PLAYLIST_OPEN_PENDING = 0x000D1109;

		/// <summary>More nodes support the interface requested, but the array for returning them is full.</summary>
		public const uint NS_S_WMPCORE_MORE_NODES_AVAIABLE = 0x000D110A;

		/// <summary>Backup or Restore successful!.</summary>
		public const uint NS_S_WMPBR_SUCCESS = 0x000D1135;

		/// <summary>Transfer complete with limitations.</summary>
		public const uint NS_S_WMPBR_PARTIALSUCCESS = 0x000D1136;

		/// <summary>Request to the effects control to change transparency status to transparent.</summary>
		public const uint NS_S_WMPEFFECT_TRANSPARENT = 0x000D1144;

		/// <summary>Request to the effects control to change transparency status to opaque.</summary>
		public const uint NS_S_WMPEFFECT_OPAQUE = 0x000D1145;

		/// <summary>The requested application pane is performing an operation and will not be released.</summary>
		public const uint NS_S_OPERATION_PENDING = 0x000D114E;

		/// <summary>The file is only available for purchase when you buy the entire album.</summary>
		public const uint NS_S_TRACK_BUY_REQUIRES_ALBUM_PURCHASE = 0x000D1359;

		/// <summary>There were problems completing the requested navigation. There are identifiers missing in the catalog.</summary>
		public const uint NS_S_NAVIGATION_COMPLETE_WITH_ERRORS = 0x000D135E;

		/// <summary>Track already downloaded.</summary>
		public const uint NS_S_TRACK_ALREADY_DOWNLOADED = 0x000D1361;

		/// <summary>The publishing point successfully started, but one or more of the requested data writer plug-ins failed.</summary>
		public const uint NS_S_PUBLISHING_POINT_STARTED_WITH_FAILED_SINKS = 0x000D1519;

		/// <summary>Status message: The license was acquired.</summary>
		public const uint NS_S_DRM_LICENSE_ACQUIRED = 0x000D2726;

		/// <summary>Status message: The security upgrade has been completed.</summary>
		public const uint NS_S_DRM_INDIVIDUALIZED = 0x000D2727;

		/// <summary>Status message: License monitoring has been canceled.</summary>
		public const uint NS_S_DRM_MONITOR_CANCELLED = 0x000D2746;

		/// <summary>Status message: License acquisition has been canceled.</summary>
		public const uint NS_S_DRM_ACQUIRE_CANCELLED = 0x000D2747;

		/// <summary>The track is burnable and had no playlist burn limit.</summary>
		public const uint NS_S_DRM_BURNABLE_TRACK = 0x000D276E;

		/// <summary>The track is burnable but has a playlist burn limit.</summary>
		public const uint NS_S_DRM_BURNABLE_TRACK_WITH_PLAYLIST_RESTRICTION = 0x000D276F;

		/// <summary>A security upgrade is required to perform the operation on this media file.</summary>
		public const uint NS_S_DRM_NEEDS_INDIVIDUALIZATION = 0x000D27DE;

		/// <summary>Installation was successful; however, some file cleanup is not complete. For best results, restart your computer.</summary>
		public const uint NS_S_REBOOT_RECOMMENDED = 0x000D2AF8;

		/// <summary>Installation was successful; however, some file cleanup is not complete. To continue, you must restart your computer.</summary>
		public const uint NS_S_REBOOT_REQUIRED = 0x000D2AF9;

		/// <summary>EOS hit during rewinding.</summary>
		public const uint NS_S_EOSRECEDING = 0x000D2F09;

		/// <summary>Internal.</summary>
		public const uint NS_S_CHANGENOTICE = 0x000D2F0D;

		/// <summary>The IO was completed by a filter.</summary>
		public const uint ERROR_FLT_IO_COMPLETE = 0x001F0001;

		/// <summary>No mode is pinned on the specified VidPN source or target.</summary>
		public const uint ERROR_GRAPHICS_MODE_NOT_PINNED = 0x00262307;

		/// <summary>Specified mode set does not specify preference for one of its modes.</summary>
		public const uint ERROR_GRAPHICS_NO_PREFERRED_MODE = 0x0026231E;

		/// <summary>Specified data set (for example, mode set, frequency range set, descriptor set, and topology) is empty.</summary>
		public const uint ERROR_GRAPHICS_DATASET_IS_EMPTY = 0x0026234B;

		/// <summary>Specified data set (for example, mode set, frequency range set, descriptor set, and topology) does not contain any more elements.</summary>
		public const uint ERROR_GRAPHICS_NO_MORE_ELEMENTS_IN_DATASET = 0x0026234C;

		/// <summary>Specified content transformation is not pinned on the specified VidPN present path.</summary>
		public const uint ERROR_GRAPHICS_PATH_CONTENT_GEOMETRY_TRANSFORMATION_NOT_PINNED = 0x00262351;

		/// <summary>Property value will be ignored.</summary>
		public const uint PLA_S_PROPERTY_IGNORED = 0x00300100;

		/// <summary>The request will be completed later by a Network Driver Interface Specification (NDIS) status indication.</summary>
		public const uint ERROR_NDIS_INDICATION_REQUIRED = 0x00340001;

		/// <summary>The VolumeSequenceNumber of a MOVE_NOTIFICATION request is incorrect.</summary>
		public const uint TRK_S_OUT_OF_SYNC = 0x0DEAD100;

		/// <summary>The VolumeID in a request was not found in the server's ServerVolumeTable.</summary>
		public const uint TRK_VOLUME_NOT_FOUND = 0x0DEAD102;

		/// <summary>A notification was sent to the LnkSvrMessage method, but the RequestMachine for the request was not the VolumeOwner for a VolumeID in the request.</summary>
		public const uint TRK_VOLUME_NOT_OWNED = 0x0DEAD103;

		/// <summary>The server received a MOVE_NOTIFICATION request, but the FileTable size limit has already been reached.</summary>
		public const uint TRK_S_NOTIFICATION_QUOTA_EXCEEDED = 0x0DEAD107;

		/// <summary>The Title Server %1 is running.</summary>
		public const uint NS_I_TIGER_START = 0x400D004F;

		/// <summary>Content Server %1 (%2) is starting.</summary>
		public const uint NS_I_CUB_START = 0x400D0051;

		/// <summary>Content Server %1 (%2) is running.</summary>
		public const uint NS_I_CUB_RUNNING = 0x400D0052;

		/// <summary>Disk %1 ( %2 ) on Content Server %3, is running.</summary>
		public const uint NS_I_DISK_START = 0x400D0054;

		/// <summary>Started rebuilding disk %1 ( %2 ) on Content Server %3.</summary>
		public const uint NS_I_DISK_REBUILD_STARTED = 0x400D0056;

		/// <summary>Finished rebuilding disk %1 ( %2 ) on Content Server %3.</summary>
		public const uint NS_I_DISK_REBUILD_FINISHED = 0x400D0057;

		/// <summary>Aborted rebuilding disk %1 ( %2 ) on Content Server %3.</summary>
		public const uint NS_I_DISK_REBUILD_ABORTED = 0x400D0058;

		/// <summary>A NetShow administrator at network location %1 set the data stream limit to %2 streams.</summary>
		public const uint NS_I_LIMIT_FUNNELS = 0x400D0059;

		/// <summary>A NetShow administrator at network location %1 started disk %2.</summary>
		public const uint NS_I_START_DISK = 0x400D005A;

		/// <summary>A NetShow administrator at network location %1 stopped disk %2.</summary>
		public const uint NS_I_STOP_DISK = 0x400D005B;

		/// <summary>A NetShow administrator at network location %1 stopped Content Server %2.</summary>
		public const uint NS_I_STOP_CUB = 0x400D005C;

		/// <summary>A NetShow administrator at network location %1 aborted user session %2 from the system.</summary>
		public const uint NS_I_KILL_USERSESSION = 0x400D005D;

		/// <summary>A NetShow administrator at network location %1 aborted obsolete connection %2 from the system.</summary>
		public const uint NS_I_KILL_CONNECTION = 0x400D005E;

		/// <summary>A NetShow administrator at network location %1 started rebuilding disk %2.</summary>
		public const uint NS_I_REBUILD_DISK = 0x400D005F;

		/// <summary>Event initialization failed, there will be no MCM events.</summary>
		public const uint MCMADM_I_NO_EVENTS = 0x400D0069;

		/// <summary>The logging operation failed.</summary>
		public const uint NS_I_LOGGING_FAILED = 0x400D006E;

		/// <summary>A NetShow administrator at network location %1 set the maximum bandwidth limit to %2 bps.</summary>
		public const uint NS_I_LIMIT_BANDWIDTH = 0x400D0070;

		/// <summary>Content Server %1 (%2) has established its link to Content Server %3.</summary>
		public const uint NS_I_CUB_UNFAIL_LINK = 0x400D0191;

		/// <summary>Restripe operation has started.</summary>
		public const uint NS_I_RESTRIPE_START = 0x400D0193;

		/// <summary>Restripe operation has completed.</summary>
		public const uint NS_I_RESTRIPE_DONE = 0x400D0194;

		/// <summary>Content disk %1 (%2) on Content Server %3 has been restriped out.</summary>
		public const uint NS_I_RESTRIPE_DISK_OUT = 0x400D0196;

		/// <summary>Content server %1 (%2) has been restriped out.</summary>
		public const uint NS_I_RESTRIPE_CUB_OUT = 0x400D0197;

		/// <summary>Disk %1 ( %2 ) on Content Server %3, has been offlined.</summary>
		public const uint NS_I_DISK_STOP = 0x400D0198;

		/// <summary>The playlist change occurred while receding.</summary>
		public const uint NS_I_PLAYLIST_CHANGE_RECEDING = 0x400D14BE;

		/// <summary>The client is reconnected.</summary>
		public const uint NS_I_RECONNECTED = 0x400D2EFF;

		/// <summary>Forcing a switch to a pending header on start.</summary>
		public const uint NS_I_NOLOG_STOP = 0x400D2F01;

		/// <summary>There is already an existing packetizer plugin for the stream.</summary>
		public const uint NS_I_EXISTING_PACKETIZER = 0x400D2F03;

		/// <summary>The proxy setting is manual.</summary>
		public const uint NS_I_MANUAL_PROXY = 0x400D2F04;

		/// <summary>The kernel driver detected a version mismatch between it and the user mode driver.</summary>
		public const uint ERROR_GRAPHICS_DRIVER_MISMATCH = 0x40262009;

		/// <summary>Child device presence was not reliably detected.</summary>
		public const uint ERROR_GRAPHICS_UNKNOWN_CHILD_STATUS = 0x4026242F;

		/// <summary>Starting the lead-link adapter has been deferred temporarily.</summary>
		public const uint ERROR_GRAPHICS_LEADLINK_START_DEFERRED = 0x40262437;

		/// <summary>The display adapter is being polled for children too frequently at the same polling level.</summary>
		public const uint ERROR_GRAPHICS_POLLING_TOO_FREQUENTLY = 0x40262439;

		/// <summary>Starting the adapter has been deferred temporarily.</summary>
		public const uint ERROR_GRAPHICS_START_DEFERRED = 0x4026243A;

		/// <summary>The data necessary to complete this operation is not yet available.</summary>
		public const uint E_PENDING = 0x8000000A;

		/// <summary>The operation attempted to access data outside the valid range</summary>
		public const uint E_BOUNDS = 0x8000000B;

		/// <summary>A concurrent or interleaved operation changed the state of the object, invalidating this operation.</summary>
		public const uint E_CHANGED_STATE = 0x8000000C;

		/// <summary>An illegal state change was requested.</summary>
		public const uint E_ILLEGAL_STATE_CHANGE = 0x8000000D;

		/// <summary>A method was called at an unexpected time.</summary>
		public const uint E_ILLEGAL_METHOD_CALL = 0x8000000E;

		/// <summary>Typename or Namespace was not found in metadata file.</summary>
		public const uint RO_E_METADATA_NAME_NOT_FOUND = 0x8000000F;

		/// <summary>Name is an existing namespace rather than a typename.</summary>
		public const uint RO_E_METADATA_NAME_IS_NAMESPACE = 0x80000010;

		/// <summary>Typename has an invalid format.</summary>
		public const uint RO_E_METADATA_INVALID_TYPE_FORMAT = 0x80000011;

		/// <summary>Metadata file is invalid or corrupted.</summary>
		public const uint RO_E_INVALID_METADATA_FILE = 0x80000012;

		/// <summary>The object has been closed.</summary>
		public const uint RO_E_CLOSED = 0x80000013;

		/// <summary>Only one thread may access the object during a write operation.</summary>
		public const uint RO_E_EXCLUSIVE_WRITE = 0x80000014;

		/// <summary>Operation is prohibited during change notification.</summary>
		public const uint RO_E_CHANGE_NOTIFICATION_IN_PROGRESS = 0x80000015;
		
		/// <summary>The text associated with this error code could not be found.</summary>
		public const uint RO_E_ERROR_STRING_NOT_FOUND = 0x80000016;
		
		/// <summary>String not null terminated.</summary>
		public const uint E_STRING_NOT_NULL_TERMINATED = 0x80000017;
		
		/// <summary>A delegate was assigned when not allowed.</summary>
		public const uint E_ILLEGAL_DELEGATE_ASSIGNMENT = 0x80000018;
		
		/// <summary>An async operation was not properly started.</summary>
		public const uint E_ASYNC_OPERATION_NOT_STARTED = 0x80000019;
		
		/// <summary>The application is exiting and cannot service this request.</summary>
		public const uint E_APPLICATION_EXITING = 0x8000001A;
		
		/// <summary>The application view is exiting and cannot service this request.</summary>
		public const uint E_APPLICATION_VIEW_EXITING = 0x8000001B;
		
		/// <summary>The object must support the IAgileObject interface.</summary>
		public const uint RO_E_MUST_BE_AGILE = 0x8000001C;
		
		/// <summary>Activating a single-threaded class from MTA is not supported.</summary>
		public const uint RO_E_UNSUPPORTED_FROM_MTA = 0x8000001D;
		
		/// <summary>The object has been committed.</summary>
		public const uint RO_E_COMMITTED = 0x8000001E;

		/// <summary>Not implemented.</summary>
		public const uint E_NOTIMPL = 0x80004001;

		/// <summary>No such interface supported.</summary>
		public const uint E_NOINTERFACE = 0x80004002;

		/// <summary>Invalid pointer.</summary>
		public const uint E_POINTER = 0x80004003;

		/// <summary>Operation aborted.</summary>
		public const uint E_ABORT = 0x80004004;

		/// <summary>Unspecified error.</summary>
		public const uint E_FAIL = 0x80004005;

		/// <summary>Thread local storage failure.</summary>
		public const uint CO_E_INIT_TLS = 0x80004006;

		/// <summary>Get shared memory allocator failure.</summary>
		public const uint CO_E_INIT_SHARED_ALLOCATOR = 0x80004007;

		/// <summary>Get memory allocator failure.</summary>
		public const uint CO_E_INIT_MEMORY_ALLOCATOR = 0x80004008;

		/// <summary>Unable to initialize class cache.</summary>
		public const uint CO_E_INIT_CLASS_CACHE = 0x80004009;

		/// <summary>Unable to initialize remote procedure call (RPC) services.</summary>
		public const uint CO_E_INIT_RPC_CHANNEL = 0x8000400A;

		/// <summary>Cannot set thread local storage channel control.</summary>
		public const uint CO_E_INIT_TLS_SET_CHANNEL_CONTROL = 0x8000400B;

		/// <summary>Could not allocate thread local storage channel control.</summary>
		public const uint CO_E_INIT_TLS_CHANNEL_CONTROL = 0x8000400C;

		/// <summary>The user-supplied memory allocator is unacceptable.</summary>
		public const uint CO_E_INIT_UNACCEPTED_USER_ALLOCATOR = 0x8000400D;

		/// <summary>The OLE service mutex already exists.</summary>
		public const uint CO_E_INIT_SCM_MUTEX_EXISTS = 0x8000400E;

		/// <summary>The OLE service file mapping already exists.</summary>
		public const uint CO_E_INIT_SCM_FILE_MAPPING_EXISTS = 0x8000400F;

		/// <summary>Unable to map view of file for OLE service.</summary>
		public const uint CO_E_INIT_SCM_MAP_VIEW_OF_FILE = 0x80004010;

		/// <summary>Failure attempting to launch OLE service.</summary>
		public const uint CO_E_INIT_SCM_EXEC_FAILURE = 0x80004011;

		/// <summary>There was an attempt to call CoInitialize a second time while single-threaded.</summary>
		public const uint CO_E_INIT_ONLY_SINGLE_THREADED = 0x80004012;

		/// <summary>A Remote activation was necessary but was not allowed.</summary>
		public const uint CO_E_CANT_REMOTE = 0x80004013;

		/// <summary>A Remote activation was necessary, but the server name provided was invalid.</summary>
		public const uint CO_E_BAD_SERVER_NAME = 0x80004014;

		/// <summary>The class is configured to run as a security ID different from the caller.</summary>
		public const uint CO_E_WRONG_SERVER_IDENTITY = 0x80004015;

		/// <summary>Use of OLE1 services requiring Dynamic Data Exchange (DDE) Windows is disabled.</summary>
		public const uint CO_E_OLE1DDE_DISABLED = 0x80004016;

		/// <summary>A RunAs specification must be &lt;domain name&gt;\&lt;user name&gt; or simply &lt;user name&gt;.</summary>
		public const uint CO_E_RUNAS_SYNTAX = 0x80004017;

		/// <summary>The server process could not be started. The path name might be incorrect.</summary>
		public const uint CO_E_CREATEPROCESS_FAILURE = 0x80004018;

		/// <summary>The server process could not be started as the configured identity. The path name might be incorrect or unavailable.</summary>
		public const uint CO_E_RUNAS_CREATEPROCESS_FAILURE = 0x80004019;

		/// <summary>The server process could not be started because the configured identity is incorrect. Check the user name and password.</summary>
		public const uint CO_E_RUNAS_LOGON_FAILURE = 0x8000401A;

		/// <summary>The client is not allowed to launch this server.</summary>
		public const uint CO_E_LAUNCH_PERMSSION_DENIED = 0x8000401B;

		/// <summary>The service providing this server could not be started.</summary>
		public const uint CO_E_START_SERVICE_FAILURE = 0x8000401C;

		/// <summary>This computer was unable to communicate with the computer providing the server.</summary>
		public const uint CO_E_REMOTE_COMMUNICATION_FAILURE = 0x8000401D;

		/// <summary>The server did not respond after being launched.</summary>
		public const uint CO_E_SERVER_START_TIMEOUT = 0x8000401E;

		/// <summary>The registration information for this server is inconsistent or incomplete.</summary>
		public const uint CO_E_CLSREG_INCONSISTENT = 0x8000401F;

		/// <summary>The registration information for this interface is inconsistent or incomplete.</summary>
		public const uint CO_E_IIDREG_INCONSISTENT = 0x80004020;

		/// <summary>The operation attempted is not supported.</summary>
		public const uint CO_E_NOT_SUPPORTED = 0x80004021;

		/// <summary>A DLL must be loaded.</summary>
		public const uint CO_E_RELOAD_DLL = 0x80004022;

		/// <summary>A Microsoft Software Installer error was encountered.</summary>
		public const uint CO_E_MSI_ERROR = 0x80004023;

		/// <summary>The specified activation could not occur in the client context as specified.</summary>
		public const uint CO_E_ATTEMPT_TO_CREATE_OUTSIDE_CLIENT_CONTEXT = 0x80004024;

		/// <summary>Activations on the server are paused.</summary>
		public const uint CO_E_SERVER_PAUSED = 0x80004025;

		/// <summary>Activations on the server are not paused.</summary>
		public const uint CO_E_SERVER_NOT_PAUSED = 0x80004026;

		/// <summary>The component or application containing the component has been disabled.</summary>
		public const uint CO_E_CLASS_DISABLED = 0x80004027;

		/// <summary>The common language runtime is not available.</summary>
		public const uint CO_E_CLRNOTAVAILABLE = 0x80004028;

		/// <summary>The thread-pool rejected the submitted asynchronous work.</summary>
		public const uint CO_E_ASYNC_WORK_REJECTED = 0x80004029;

		/// <summary>The server started, but it did not finish initializing in a timely fashion.</summary>
		public const uint CO_E_SERVER_INIT_TIMEOUT = 0x8000402A;

		/// <summary>Unable to complete the call because there is no COM+ security context inside IObjectControl.Activate.</summary>
		public const uint CO_E_NO_SECCTX_IN_ACTIVATE = 0x8000402B;

		/// <summary>The provided tracker configuration is invalid.</summary>
		public const uint CO_E_TRACKER_CONFIG = 0x80004030;

		/// <summary>The provided thread pool configuration is invalid.</summary>
		public const uint CO_E_THREADPOOL_CONFIG = 0x80004031;

		/// <summary>The provided side-by-side configuration is invalid.</summary>
		public const uint CO_E_SXS_CONFIG = 0x80004032;

		/// <summary>The server principal name (SPN) obtained during security negotiation is malformed.</summary>
		public const uint CO_E_MALFORMED_SPN = 0x80004033;

		/// <summary>Catastrophic failure.</summary>
		public const uint E_UNEXPECTED = 0x8000FFFF;

		/// <summary>Call was rejected by callee.</summary>
		public const uint RPC_E_CALL_REJECTED = 0x80010001;

		/// <summary>Call was canceled by the message filter.</summary>
		public const uint RPC_E_CALL_CANCELED = 0x80010002;

		/// <summary>The caller is dispatching an intertask SendMessage call and cannot call out via PostMessage.</summary>
		public const uint RPC_E_CANTPOST_INSENDCALL = 0x80010003;

		/// <summary>The caller is dispatching an asynchronous call and cannot make an outgoing call on behalf of this call.</summary>
		public const uint RPC_E_CANTCALLOUT_INASYNCCALL = 0x80010004;

		/// <summary>It is illegal to call out while inside message filter.</summary>
		public const uint RPC_E_CANTCALLOUT_INEXTERNALCALL = 0x80010005;

		/// <summary>The connection terminated or is in a bogus state and can no longer be used. Other connections are still valid.</summary>
		public const uint RPC_E_CONNECTION_TERMINATED = 0x80010006;

		/// <summary>The callee (the server, not the server application) is not available and disappeared; all connections are invalid. The call might have executed.</summary>
		public const uint RPC_E_SERVER_DIED = 0x80010007;

		/// <summary>The caller (client) disappeared while the callee (server) was processing a call.</summary>
		public const uint RPC_E_CLIENT_DIED = 0x80010008;

		/// <summary>The data packet with the marshaled parameter data is incorrect.</summary>
		public const uint RPC_E_INVALID_DATAPACKET = 0x80010009;

		/// <summary>The call was not transmitted properly; the message queue was full and was not emptied after yielding.</summary>
		public const uint RPC_E_CANTTRANSMIT_CALL = 0x8001000A;

		/// <summary>The client RPC caller cannot marshal the parameter data due to errors (such as low memory).</summary>
		public const uint RPC_E_CLIENT_CANTMARSHAL_DATA = 0x8001000B;

		/// <summary>The client RPC caller cannot unmarshal the return data due to errors (such as low memory).</summary>
		public const uint RPC_E_CLIENT_CANTUNMARSHAL_DATA = 0x8001000C;

		/// <summary>The server RPC callee cannot marshal the return data due to errors (such as low memory).</summary>
		public const uint RPC_E_SERVER_CANTMARSHAL_DATA = 0x8001000D;

		/// <summary>The server RPC callee cannot unmarshal the parameter data due to errors (such as low memory).</summary>
		public const uint RPC_E_SERVER_CANTUNMARSHAL_DATA = 0x8001000E;

		/// <summary>Received data is invalid. The data might be server or client data.</summary>
		public const uint RPC_E_INVALID_DATA = 0x8001000F;

		/// <summary>A particular parameter is invalid and cannot be (un)marshaled.</summary>
		public const uint RPC_E_INVALID_PARAMETER = 0x80010010;

		/// <summary>There is no second outgoing call on same channel in DDE conversation.</summary>
		public const uint RPC_E_CANTCALLOUT_AGAIN = 0x80010011;

		/// <summary>The callee (the server, not the server application) is not available and disappeared; all connections are invalid. The call did not execute.</summary>
		public const uint RPC_E_SERVER_DIED_DNE = 0x80010012;

		/// <summary>System call failed.</summary>
		public const uint RPC_E_SYS_CALL_FAILED = 0x80010100;

		/// <summary>Could not allocate some required resource (such as memory or events)</summary>
		public const uint RPC_E_OUT_OF_RESOURCES = 0x80010101;

		/// <summary>Attempted to make calls on more than one thread in single-threaded mode.</summary>
		public const uint RPC_E_ATTEMPTED_MULTITHREAD = 0x80010102;

		/// <summary>The requested interface is not registered on the server object.</summary>
		public const uint RPC_E_NOT_REGISTERED = 0x80010103;

		/// <summary>RPC could not call the server or could not return the results of calling the server.</summary>
		public const uint RPC_E_FAULT = 0x80010104;

		/// <summary>The server threw an exception.</summary>
		public const uint RPC_E_SERVERFAULT = 0x80010105;

		/// <summary>Cannot change thread mode after it is set.</summary>
		public const uint RPC_E_CHANGED_MODE = 0x80010106;

		/// <summary>The method called does not exist on the server.</summary>
		public const uint RPC_E_INVALIDMETHOD = 0x80010107;

		/// <summary>The object invoked has disconnected from its clients.</summary>
		public const uint RPC_E_DISCONNECTED = 0x80010108;

		/// <summary>The object invoked chose not to process the call now. Try again later.</summary>
		public const uint RPC_E_RETRY = 0x80010109;

		/// <summary>The message filter indicated that the application is busy.</summary>
		public const uint RPC_E_SERVERCALL_RETRYLATER = 0x8001010A;

		/// <summary>The message filter rejected the call.</summary>
		public const uint RPC_E_SERVERCALL_REJECTED = 0x8001010B;

		/// <summary>A call control interface was called with invalid data.</summary>
		public const uint RPC_E_INVALID_CALLDATA = 0x8001010C;

		/// <summary>An outgoing call cannot be made because the application is dispatching an input-synchronous call.</summary>
		public const uint RPC_E_CANTCALLOUT_ININPUTSYNCCALL = 0x8001010D;

		/// <summary>The application called an interface that was marshaled for a different thread.</summary>
		public const uint RPC_E_WRONG_THREAD = 0x8001010E;

		/// <summary>CoInitialize has not been called on the current thread.</summary>
		public const uint RPC_E_THREAD_NOT_INIT = 0x8001010F;

		/// <summary>The version of OLE on the client and server machines does not match.</summary>
		public const uint RPC_E_VERSION_MISMATCH = 0x80010110;

		/// <summary>OLE received a packet with an invalid header.</summary>
		public const uint RPC_E_INVALID_HEADER = 0x80010111;

		/// <summary>OLE received a packet with an invalid extension.</summary>
		public const uint RPC_E_INVALID_EXTENSION = 0x80010112;

		/// <summary>The requested object or interface does not exist.</summary>
		public const uint RPC_E_INVALID_IPID = 0x80010113;

		/// <summary>The requested object does not exist.</summary>
		public const uint RPC_E_INVALID_OBJECT = 0x80010114;

		/// <summary>OLE has sent a request and is waiting for a reply.</summary>
		public const uint RPC_S_CALLPENDING = 0x80010115;

		/// <summary>OLE is waiting before retrying a request.</summary>
		public const uint RPC_S_WAITONTIMER = 0x80010116;

		/// <summary>Call context cannot be accessed after call completed.</summary>
		public const uint RPC_E_CALL_COMPLETE = 0x80010117;

		/// <summary>Impersonate on unsecure calls is not supported.</summary>
		public const uint RPC_E_UNSECURE_CALL = 0x80010118;

		/// <summary>Security must be initialized before any interfaces are marshaled or unmarshaled. It cannot be changed after initialized.</summary>
		public const uint RPC_E_TOO_LATE = 0x80010119;

		/// <summary>No security packages are installed on this machine, the user is not logged on, or there are no compatible security packages between the client and server.</summary>
		public const uint RPC_E_NO_GOOD_SECURITY_PACKAGES = 0x8001011A;

		/// <summary>Access is denied.</summary>
		public const uint RPC_E_ACCESS_DENIED = 0x8001011B;

		/// <summary>Remote calls are not allowed for this process.</summary>
		public const uint RPC_E_REMOTE_DISABLED = 0x8001011C;

		/// <summary>The marshaled interface data packet (OBJREF) has an invalid or unknown format.</summary>
		public const uint RPC_E_INVALID_OBJREF = 0x8001011D;

		/// <summary>No context is associated with this call. This happens for some custom marshaled calls and on the client side of the call.</summary>
		public const uint RPC_E_NO_CONTEXT = 0x8001011E;

		/// <summary>This operation returned because the time-out period expired.</summary>
		public const uint RPC_E_TIMEOUT = 0x8001011F;

		/// <summary>There are no synchronize objects to wait on.</summary>
		public const uint RPC_E_NO_SYNC = 0x80010120;

		/// <summary>Full subject issuer chain Secure Sockets Layer (SSL) principal name expected from the server.</summary>
		public const uint RPC_E_FULLSIC_REQUIRED = 0x80010121;

		/// <summary>Principal name is not a valid Microsoft standard (msstd) name.</summary>
		public const uint RPC_E_INVALID_STD_NAME = 0x80010122;

		/// <summary>Unable to impersonate DCOM client.</summary>
		public const uint CO_E_FAILEDTOIMPERSONATE = 0x80010123;

		/// <summary>Unable to obtain server's security context.</summary>
		public const uint CO_E_FAILEDTOGETSECCTX = 0x80010124;

		/// <summary>Unable to open the access token of the current thread.</summary>
		public const uint CO_E_FAILEDTOOPENTHREADTOKEN = 0x80010125;

		/// <summary>Unable to obtain user information from an access token.</summary>
		public const uint CO_E_FAILEDTOGETTOKENINFO = 0x80010126;

		/// <summary>The client who called IAccessControl::IsAccessPermitted was not the trustee provided to the method.</summary>
		public const uint CO_E_TRUSTEEDOESNTMATCHCLIENT = 0x80010127;

		/// <summary>Unable to obtain the client's security blanket.</summary>
		public const uint CO_E_FAILEDTOQUERYCLIENTBLANKET = 0x80010128;

		/// <summary>Unable to set a discretionary access control list (ACL) into a security descriptor.</summary>
		public const uint CO_E_FAILEDTOSETDACL = 0x80010129;

		/// <summary>The system function AccessCheck returned false.</summary>
		public const uint CO_E_ACCESSCHECKFAILED = 0x8001012A;

		/// <summary>Either NetAccessDel or NetAccessAdd returned an error code.</summary>
		public const uint CO_E_NETACCESSAPIFAILED = 0x8001012B;

		/// <summary>One of the trustee strings provided by the user did not conform to the &lt;Domain&gt;\&lt;Name&gt; syntax and it was not the *" string".</summary>
		public const uint CO_E_WRONGTRUSTEENAMESYNTAX = 0x8001012C;

		/// <summary>One of the security identifiers provided by the user was invalid.</summary>
		public const uint CO_E_INVALIDSID = 0x8001012D;

		/// <summary>Unable to convert a wide character trustee string to a multiple-byte trustee string.</summary>
		public const uint CO_E_CONVERSIONFAILED = 0x8001012E;

		/// <summary>Unable to find a security identifier that corresponds to a trustee string provided by the user.</summary>
		public const uint CO_E_NOMATCHINGSIDFOUND = 0x8001012F;

		/// <summary>The system function LookupAccountSID failed.</summary>
		public const uint CO_E_LOOKUPACCSIDFAILED = 0x80010130;

		/// <summary>Unable to find a trustee name that corresponds to a security identifier provided by the user.</summary>
		public const uint CO_E_NOMATCHINGNAMEFOUND = 0x80010131;

		/// <summary>The system function LookupAccountName failed.</summary>
		public const uint CO_E_LOOKUPACCNAMEFAILED = 0x80010132;

		/// <summary>Unable to set or reset a serialization handle.</summary>
		public const uint CO_E_SETSERLHNDLFAILED = 0x80010133;

		/// <summary>Unable to obtain the Windows directory.</summary>
		public const uint CO_E_FAILEDTOGETWINDIR = 0x80010134;

		/// <summary>Path too long.</summary>
		public const uint CO_E_PATHTOOLONG = 0x80010135;

		/// <summary>Unable to generate a UUID.</summary>
		public const uint CO_E_FAILEDTOGENUUID = 0x80010136;

		/// <summary>Unable to create file.</summary>
		public const uint CO_E_FAILEDTOCREATEFILE = 0x80010137;

		/// <summary>Unable to close a serialization handle or a file handle.</summary>
		public const uint CO_E_FAILEDTOCLOSEHANDLE = 0x80010138;

		/// <summary>The number of access control entries (ACEs) in an ACL exceeds the system limit.</summary>
		public const uint CO_E_EXCEEDSYSACLLIMIT = 0x80010139;

		/// <summary>Not all the DENY_ACCESS ACEs are arranged in front of the GRANT_ACCESS ACEs in the stream.</summary>
		public const uint CO_E_ACESINWRONGORDER = 0x8001013A;

		/// <summary>The version of ACL format in the stream is not supported by this implementation of IAccessControl.</summary>
		public const uint CO_E_INCOMPATIBLESTREAMVERSION = 0x8001013B;

		/// <summary>Unable to open the access token of the server process.</summary>
		public const uint CO_E_FAILEDTOOPENPROCESSTOKEN = 0x8001013C;

		/// <summary>Unable to decode the ACL in the stream provided by the user.</summary>
		public const uint CO_E_DECODEFAILED = 0x8001013D;

		/// <summary>The COM IAccessControl object is not initialized.</summary>
		public const uint CO_E_ACNOTINITIALIZED = 0x8001013F;

		/// <summary>Call Cancellation is disabled.</summary>
		public const uint CO_E_CANCEL_DISABLED = 0x80010140;

		/// <summary>An internal error occurred.</summary>
		public const uint RPC_E_UNEXPECTED = 0x8001FFFF;

		/// <summary>Unknown interface.</summary>
		public const uint DISP_E_UNKNOWNINTERFACE = 0x80020001;

		/// <summary>Member not found.</summary>
		public const uint DISP_E_MEMBERNOTFOUND = 0x80020003;

		/// <summary>Parameter not found.</summary>
		public const uint DISP_E_PARAMNOTFOUND = 0x80020004;

		/// <summary>Type mismatch.</summary>
		public const uint DISP_E_TYPEMISMATCH = 0x80020005;

		/// <summary>Unknown name.</summary>
		public const uint DISP_E_UNKNOWNNAME = 0x80020006;

		/// <summary>No named arguments.</summary>
		public const uint DISP_E_NONAMEDARGS = 0x80020007;

		/// <summary>Bad variable type.</summary>
		public const uint DISP_E_BADVARTYPE = 0x80020008;

		/// <summary>Exception occurred.</summary>
		public const uint DISP_E_EXCEPTION = 0x80020009;

		/// <summary>Out of present range.</summary>
		public const uint DISP_E_OVERFLOW = 0x8002000A;

		/// <summary>Invalid index.</summary>
		public const uint DISP_E_BADINDEX = 0x8002000B;

		/// <summary>Unknown language.</summary>
		public const uint DISP_E_UNKNOWNLCID = 0x8002000C;

		/// <summary>Memory is locked.</summary>
		public const uint DISP_E_ARRAYISLOCKED = 0x8002000D;

		/// <summary>Invalid number of parameters.</summary>
		public const uint DISP_E_BADPARAMCOUNT = 0x8002000E;

		/// <summary>Parameter not optional.</summary>
		public const uint DISP_E_PARAMNOTOPTIONAL = 0x8002000F;

		/// <summary>Invalid callee.</summary>
		public const uint DISP_E_BADCALLEE = 0x80020010;

		/// <summary>Does not support a collection.</summary>
		public const uint DISP_E_NOTACOLLECTION = 0x80020011;

		/// <summary>Division by zero.</summary>
		public const uint DISP_E_DIVBYZERO = 0x80020012;

		/// <summary>Buffer too small.</summary>
		public const uint DISP_E_BUFFERTOOSMALL = 0x80020013;

		/// <summary>Buffer too small.</summary>
		public const uint TYPE_E_BUFFERTOOSMALL = 0x80028016;

		/// <summary>Field name not defined in the record.</summary>
		public const uint TYPE_E_FIELDNOTFOUND = 0x80028017;

		/// <summary>Old format or invalid type library.</summary>
		public const uint TYPE_E_INVDATAREAD = 0x80028018;

		/// <summary>Old format or invalid type library.</summary>
		public const uint TYPE_E_UNSUPFORMAT = 0x80028019;

		/// <summary>Error accessing the OLE registry.</summary>
		public const uint TYPE_E_REGISTRYACCESS = 0x8002801C;

		/// <summary>Library not registered.</summary>
		public const uint TYPE_E_LIBNOTREGISTERED = 0x8002801D;

		/// <summary>Bound to unknown type.</summary>
		public const uint TYPE_E_UNDEFINEDTYPE = 0x80028027;

		/// <summary>Qualified name disallowed.</summary>
		public const uint TYPE_E_QUALIFIEDNAMEDISALLOWED = 0x80028028;

		/// <summary>Invalid forward reference, or reference to uncompiled type.</summary>
		public const uint TYPE_E_INVALIDSTATE = 0x80028029;

		/// <summary>Type mismatch.</summary>
		public const uint TYPE_E_WRONGTYPEKIND = 0x8002802A;

		/// <summary>Element not found.</summary>
		public const uint TYPE_E_ELEMENTNOTFOUND = 0x8002802B;

		/// <summary>Ambiguous name.</summary>
		public const uint TYPE_E_AMBIGUOUSNAME = 0x8002802C;

		/// <summary>Name already exists in the library.</summary>
		public const uint TYPE_E_NAMECONFLICT = 0x8002802D;

		/// <summary>Unknown language code identifier (LCID).</summary>
		public const uint TYPE_E_UNKNOWNLCID = 0x8002802E;

		/// <summary>Function not defined in specified DLL.</summary>
		public const uint TYPE_E_DLLFUNCTIONNOTFOUND = 0x8002802F;

		/// <summary>Wrong module kind for the operation.</summary>
		public const uint TYPE_E_BADMODULEKIND = 0x800288BD;

		/// <summary>Size cannot exceed 64 KB.</summary>
		public const uint TYPE_E_SIZETOOBIG = 0x800288C5;

		/// <summary>Duplicate ID in inheritance hierarchy.</summary>
		public const uint TYPE_E_DUPLICATEID = 0x800288C6;

		/// <summary>Incorrect inheritance depth in standard OLE hmember.</summary>
		public const uint TYPE_E_INVALIDID = 0x800288CF;

		/// <summary>Type mismatch.</summary>
		public const uint TYPE_E_TYPEMISMATCH = 0x80028CA0;

		/// <summary>Invalid number of arguments.</summary>
		public const uint TYPE_E_OUTOFBOUNDS = 0x80028CA1;

		/// <summary>I/O error.</summary>
		public const uint TYPE_E_IOERROR = 0x80028CA2;

		/// <summary>Error creating unique .tmp file.</summary>
		public const uint TYPE_E_CANTCREATETMPFILE = 0x80028CA3;

		/// <summary>Error loading type library or DLL.</summary>
		public const uint TYPE_E_CANTLOADLIBRARY = 0x80029C4A;

		/// <summary>Inconsistent property functions.</summary>
		public const uint TYPE_E_INCONSISTENTPROPFUNCS = 0x80029C83;

		/// <summary>Circular dependency between types and modules.</summary>
		public const uint TYPE_E_CIRCULARTYPE = 0x80029C84;

		/// <summary>Unable to perform requested operation.</summary>
		public const uint STG_E_INVALIDFUNCTION = 0x80030001;

		/// <summary>%1 could not be found.</summary>
		public const uint STG_E_FILENOTFOUND = 0x80030002;

		/// <summary>The path %1 could not be found.</summary>
		public const uint STG_E_PATHNOTFOUND = 0x80030003;

		/// <summary>There are insufficient resources to open another file.</summary>
		public const uint STG_E_TOOMANYOPENFILES = 0x80030004;

		/// <summary>Access denied.</summary>
		public const uint STG_E_ACCESSDENIED = 0x80030005;

		/// <summary>Attempted an operation on an invalid object.</summary>
		public const uint STG_E_INVALIDHANDLE = 0x80030006;

		/// <summary>There is insufficient memory available to complete operation.</summary>
		public const uint STG_E_INSUFFICIENTMEMORY = 0x80030008;

		/// <summary>Invalid pointer error.</summary>
		public const uint STG_E_INVALIDPOINTER = 0x80030009;

		/// <summary>There are no more entries to return.</summary>
		public const uint STG_E_NOMOREFILES = 0x80030012;

		/// <summary>Disk is write-protected.</summary>
		public const uint STG_E_DISKISWRITEPROTECTED = 0x80030013;

		/// <summary>An error occurred during a seek operation.</summary>
		public const uint STG_E_SEEKERROR = 0x80030019;

		/// <summary>A disk error occurred during a write operation.</summary>
		public const uint STG_E_WRITEFAULT = 0x8003001D;

		/// <summary>A disk error occurred during a read operation.</summary>
		public const uint STG_E_READFAULT = 0x8003001E;

		/// <summary>A share violation has occurred.</summary>
		public const uint STG_E_SHAREVIOLATION = 0x80030020;

		/// <summary>A lock violation has occurred.</summary>
		public const uint STG_E_LOCKVIOLATION = 0x80030021;

		/// <summary>%1 already exists.</summary>
		public const uint STG_E_FILEALREADYEXISTS = 0x80030050;

		/// <summary>Invalid parameter error.</summary>
		public const uint STG_E_INVALIDPARAMETER = 0x80030057;

		/// <summary>There is insufficient disk space to complete operation.</summary>
		public const uint STG_E_MEDIUMFULL = 0x80030070;

		/// <summary>Illegal write of non-simple property to simple property set.</summary>
		public const uint STG_E_PROPSETMISMATCHED = 0x800300F0;

		/// <summary>An application programming interface (API) call exited abnormally.</summary>
		public const uint STG_E_ABNORMALAPIEXIT = 0x800300FA;

		/// <summary>The file %1 is not a valid compound file.</summary>
		public const uint STG_E_INVALIDHEADER = 0x800300FB;

		/// <summary>The name %1 is not valid.</summary>
		public const uint STG_E_INVALIDNAME = 0x800300FC;

		/// <summary>An unexpected error occurred.</summary>
		public const uint STG_E_UNKNOWN = 0x800300FD;

		/// <summary>That function is not implemented.</summary>
		public const uint STG_E_UNIMPLEMENTEDFUNCTION = 0x800300FE;

		/// <summary>Invalid flag error.</summary>
		public const uint STG_E_INVALIDFLAG = 0x800300FF;

		/// <summary>Attempted to use an object that is busy.</summary>
		public const uint STG_E_INUSE = 0x80030100;

		/// <summary>The storage has been changed since the last commit.</summary>
		public const uint STG_E_NOTCURRENT = 0x80030101;

		/// <summary>Attempted to use an object that has ceased to exist.</summary>
		public const uint STG_E_REVERTED = 0x80030102;

		/// <summary>Cannot save.</summary>
		public const uint STG_E_CANTSAVE = 0x80030103;

		/// <summary>The compound file %1 was produced with an incompatible version of storage.</summary>
		public const uint STG_E_OLDFORMAT = 0x80030104;

		/// <summary>The compound file %1 was produced with a newer version of storage.</summary>
		public const uint STG_E_OLDDLL = 0x80030105;

		/// <summary>Share.exe or equivalent is required for operation.</summary>
		public const uint STG_E_SHAREREQUIRED = 0x80030106;

		/// <summary>Illegal operation called on non-file based storage.</summary>
		public const uint STG_E_NOTFILEBASEDSTORAGE = 0x80030107;

		/// <summary>Illegal operation called on object with extant marshalings.</summary>
		public const uint STG_E_EXTANTMARSHALLINGS = 0x80030108;

		/// <summary>The docfile has been corrupted.</summary>
		public const uint STG_E_DOCFILECORRUPT = 0x80030109;

		/// <summary>OLE32.DLL has been loaded at the wrong address.</summary>
		public const uint STG_E_BADBASEADDRESS = 0x80030110;

		/// <summary>The compound file is too large for the current implementation.</summary>
		public const uint STG_E_DOCFILETOOLARGE = 0x80030111;

		/// <summary>The compound file was not created with the STGM_SIMPLE flag.</summary>
		public const uint STG_E_NOTSIMPLEFORMAT = 0x80030112;

		/// <summary>The file download was aborted abnormally. The file is incomplete.</summary>
		public const uint STG_E_INCOMPLETE = 0x80030201;

		/// <summary>The file download has been terminated.</summary>
		public const uint STG_E_TERMINATED = 0x80030202;

		/// <summary>Generic Copy Protection Error.</summary>
		public const uint STG_E_STATUS_COPY_PROTECTION_FAILURE = 0x80030305;

		/// <summary>Copy Protection Error—DVD CSS Authentication failed.</summary>
		public const uint STG_E_CSS_AUTHENTICATION_FAILURE = 0x80030306;

		/// <summary>Copy Protection Error—The given sector does not have a valid CSS key.</summary>
		public const uint STG_E_CSS_KEY_NOT_PRESENT = 0x80030307;

		/// <summary>Copy Protection Error—DVD session key not established.</summary>
		public const uint STG_E_CSS_KEY_NOT_ESTABLISHED = 0x80030308;

		/// <summary>Copy Protection Error—The read failed because the sector is encrypted.</summary>
		public const uint STG_E_CSS_SCRAMBLED_SECTOR = 0x80030309;

		/// <summary>Copy Protection Error—The current DVD's region does not correspond to the region setting of the drive.</summary>
		public const uint STG_E_CSS_REGION_MISMATCH = 0x8003030A;

		/// <summary>Copy Protection Error—The drive's region setting might be permanent or the number of user resets has been exhausted.</summary>
		public const uint STG_E_RESETS_EXHAUSTED = 0x8003030B;

		/// <summary>Invalid OLEVERB structure.</summary>
		public const uint OLE_E_OLEVERB = 0x80040000;

		/// <summary>Invalid advise flags.</summary>
		public const uint OLE_E_ADVF = 0x80040001;

		/// <summary>Cannot enumerate any more because the associated data is missing.</summary>
		public const uint OLE_E_ENUM_NOMORE = 0x80040002;

		/// <summary>This implementation does not take advises.</summary>
		public const uint OLE_E_ADVISENOTSUPPORTED = 0x80040003;

		/// <summary>There is no connection for this connection ID.</summary>
		public const uint OLE_E_NOCONNECTION = 0x80040004;

		/// <summary>Need to run the object to perform this operation.</summary>
		public const uint OLE_E_NOTRUNNING = 0x80040005;

		/// <summary>There is no cache to operate on.</summary>
		public const uint OLE_E_NOCACHE = 0x80040006;

		/// <summary>Uninitialized object.</summary>
		public const uint OLE_E_BLANK = 0x80040007;

		/// <summary>Linked object's source class has changed.</summary>
		public const uint OLE_E_CLASSDIFF = 0x80040008;

		/// <summary>Not able to get the moniker of the object.</summary>
		public const uint OLE_E_CANT_GETMONIKER = 0x80040009;

		/// <summary>Not able to bind to the source.</summary>
		public const uint OLE_E_CANT_BINDTOSOURCE = 0x8004000A;

		/// <summary>Object is static; operation not allowed.</summary>
		public const uint OLE_E_STATIC = 0x8004000B;

		/// <summary>User canceled out of the Save dialog box.</summary>
		public const uint OLE_E_PROMPTSAVECANCELLED = 0x8004000C;

		/// <summary>Invalid rectangle.</summary>
		public const uint OLE_E_INVALIDRECT = 0x8004000D;

		/// <summary>compobj.dll is too old for the ole2.dll initialized.</summary>
		public const uint OLE_E_WRONGCOMPOBJ = 0x8004000E;

		/// <summary>Invalid window handle.</summary>
		public const uint OLE_E_INVALIDHWND = 0x8004000F;

		/// <summary>Object is not in any of the inplace active states.</summary>
		public const uint OLE_E_NOT_INPLACEACTIVE = 0x80040010;

		/// <summary>Not able to convert object.</summary>
		public const uint OLE_E_CANTCONVERT = 0x80040011;

		/// <summary>Not able to perform the operation because object is not given storage yet.</summary>
		public const uint OLE_E_NOSTORAGE = 0x80040012;

		/// <summary>Invalid FORMATETC structure.</summary>
		public const uint DV_E_FORMATETC = 0x80040064;

		/// <summary>Invalid DVTARGETDEVICE structure.</summary>
		public const uint DV_E_DVTARGETDEVICE = 0x80040065;

		/// <summary>Invalid STDGMEDIUM structure.</summary>
		public const uint DV_E_STGMEDIUM = 0x80040066;

		/// <summary>Invalid STATDATA structure.</summary>
		public const uint DV_E_STATDATA = 0x80040067;

		/// <summary>Invalid lindex.</summary>
		public const uint DV_E_LINDEX = 0x80040068;

		/// <summary>Invalid TYMED structure.</summary>
		public const uint DV_E_TYMED = 0x80040069;

		/// <summary>Invalid clipboard format.</summary>
		public const uint DV_E_CLIPFORMAT = 0x8004006A;

		/// <summary>Invalid aspects.</summary>
		public const uint DV_E_DVASPECT = 0x8004006B;

		/// <summary>The tdSize parameter of the DVTARGETDEVICE structure is invalid.</summary>
		public const uint DV_E_DVTARGETDEVICE_SIZE = 0x8004006C;

		/// <summary>Object does not support IViewObject interface.</summary>
		public const uint DV_E_NOIVIEWOBJECT = 0x8004006D;

		/// <summary>Trying to revoke a drop target that has not been registered.</summary>
		public const uint DRAGDROP_E_NOTREGISTERED = 0x80040100;

		/// <summary>This window has already been registered as a drop target.</summary>
		public const uint DRAGDROP_E_ALREADYREGISTERED = 0x80040101;

		/// <summary>Invalid window handle.</summary>
		public const uint DRAGDROP_E_INVALIDHWND = 0x80040102;

		/// <summary>Class does not support aggregation (or class object is remote).</summary>
		public const uint CLASS_E_NOAGGREGATION = 0x80040110;

		/// <summary>ClassFactory cannot supply requested class.</summary>
		public const uint CLASS_E_CLASSNOTAVAILABLE = 0x80040111;

		/// <summary>Class is not licensed for use.</summary>
		public const uint CLASS_E_NOTLICENSED = 0x80040112;

		/// <summary>Error drawing view.</summary>
		public const uint VIEW_E_DRAW = 0x80040140;

		/// <summary>Could not read key from registry.</summary>
		public const uint REGDB_E_READREGDB = 0x80040150;

		/// <summary>Could not write key to registry.</summary>
		public const uint REGDB_E_WRITEREGDB = 0x80040151;

		/// <summary>Could not find the key in the registry.</summary>
		public const uint REGDB_E_KEYMISSING = 0x80040152;

		/// <summary>Invalid value for registry.</summary>
		public const uint REGDB_E_INVALIDVALUE = 0x80040153;

		/// <summary>Class not registered.</summary>
		public const uint REGDB_E_CLASSNOTREG = 0x80040154;

		/// <summary>Interface not registered.</summary>
		public const uint REGDB_E_IIDNOTREG = 0x80040155;

		/// <summary>Threading model entry is not valid.</summary>
		public const uint REGDB_E_BADTHREADINGMODEL = 0x80040156;

		/// <summary>CATID does not exist.</summary>
		public const uint CAT_E_CATIDNOEXIST = 0x80040160;

		/// <summary>Description not found.</summary>
		public const uint CAT_E_NODESCRIPTION = 0x80040161;

		/// <summary>No package in the software installation data in Active Directory meets this criteria.</summary>
		public const uint CS_E_PACKAGE_NOTFOUND = 0x80040164;

		/// <summary>Deleting this will break the referential integrity of the software installation data in Active Directory.</summary>
		public const uint CS_E_NOT_DELETABLE = 0x80040165;

		/// <summary>The CLSID was not found in the software installation data in Active Directory.</summary>
		public const uint CS_E_CLASS_NOTFOUND = 0x80040166;

		/// <summary>The software installation data in Active Directory is corrupt.</summary>
		public const uint CS_E_INVALID_VERSION = 0x80040167;

		/// <summary>There is no software installation data in Active Directory.</summary>
		public const uint CS_E_NO_CLASSSTORE = 0x80040168;

		/// <summary>There is no software installation data object in Active Directory.</summary>
		public const uint CS_E_OBJECT_NOTFOUND = 0x80040169;

		/// <summary>The software installation data object in Active Directory already exists.</summary>
		public const uint CS_E_OBJECT_ALREADY_EXISTS = 0x8004016A;

		/// <summary>The path to the software installation data in Active Directory is not correct.</summary>
		public const uint CS_E_INVALID_PATH = 0x8004016B;

		/// <summary>A network error interrupted the operation.</summary>
		public const uint CS_E_NETWORK_ERROR = 0x8004016C;

		/// <summary>The size of this object exceeds the maximum size set by the administrator.</summary>
		public const uint CS_E_ADMIN_LIMIT_EXCEEDED = 0x8004016D;

		/// <summary>The schema for the software installation data in Active Directory does not match the required schema.</summary>
		public const uint CS_E_SCHEMA_MISMATCH = 0x8004016E;

		/// <summary>An error occurred in the software installation data in Active Directory.</summary>
		public const uint CS_E_INTERNAL_ERROR = 0x8004016F;

		/// <summary>Cache not updated.</summary>
		public const uint CACHE_E_NOCACHE_UPDATED = 0x80040170;

		/// <summary>No verbs for OLE object.</summary>
		public const uint OLEOBJ_E_NOVERBS = 0x80040180;

		/// <summary>Invalid verb for OLE object.</summary>
		public const uint OLEOBJ_E_INVALIDVERB = 0x80040181;

		/// <summary>Undo is not available.</summary>
		public const uint INPLACE_E_NOTUNDOABLE = 0x800401A0;

		/// <summary>Space for tools is not available.</summary>
		public const uint INPLACE_E_NOTOOLSPACE = 0x800401A1;

		/// <summary>OLESTREAM Get method failed.</summary>
		public const uint CONVERT10_E_OLESTREAM_GET = 0x800401C0;

		/// <summary>OLESTREAM Put method failed.</summary>
		public const uint CONVERT10_E_OLESTREAM_PUT = 0x800401C1;

		/// <summary>Contents of the OLESTREAM not in correct format.</summary>
		public const uint CONVERT10_E_OLESTREAM_FMT = 0x800401C2;

		/// <summary>There was an error in a Windows GDI call while converting the bitmap to a device-independent bitmap (DIB).</summary>
		public const uint CONVERT10_E_OLESTREAM_BITMAP_TO_DIB = 0x800401C3;

		/// <summary>Contents of the IStorage not in correct format.</summary>
		public const uint CONVERT10_E_STG_FMT = 0x800401C4;

		/// <summary>Contents of IStorage is missing one of the standard streams.</summary>
		public const uint CONVERT10_E_STG_NO_STD_STREAM = 0x800401C5;

		/// <summary>There was an error in a Windows Graphics Device Interface (GDI) call while converting the DIB to a bitmap.</summary>
		public const uint CONVERT10_E_STG_DIB_TO_BITMAP = 0x800401C6;

		/// <summary>OpenClipboard failed.</summary>
		public const uint CLIPBRD_E_CANT_OPEN = 0x800401D0;

		/// <summary>EmptyClipboard failed.</summary>
		public const uint CLIPBRD_E_CANT_EMPTY = 0x800401D1;

		/// <summary>SetClipboard failed.</summary>
		public const uint CLIPBRD_E_CANT_SET = 0x800401D2;

		/// <summary>Data on clipboard is invalid.</summary>
		public const uint CLIPBRD_E_BAD_DATA = 0x800401D3;

		/// <summary>CloseClipboard failed.</summary>
		public const uint CLIPBRD_E_CANT_CLOSE = 0x800401D4;

		/// <summary>Moniker needs to be connected manually.</summary>
		public const uint MK_E_CONNECTMANUALLY = 0x800401E0;

		/// <summary>Operation exceeded deadline.</summary>
		public const uint MK_E_EXCEEDEDDEADLINE = 0x800401E1;

		/// <summary>Moniker needs to be generic.</summary>
		public const uint MK_E_NEEDGENERIC = 0x800401E2;

		/// <summary>Operation unavailable.</summary>
		public const uint MK_E_UNAVAILABLE = 0x800401E3;

		/// <summary>Invalid syntax.</summary>
		public const uint MK_E_SYNTAX = 0x800401E4;

		/// <summary>No object for moniker.</summary>
		public const uint MK_E_NOOBJECT = 0x800401E5;

		/// <summary>Bad extension for file.</summary>
		public const uint MK_E_INVALIDEXTENSION = 0x800401E6;

		/// <summary>Intermediate operation failed.</summary>
		public const uint MK_E_INTERMEDIATEINTERFACENOTSUPPORTED = 0x800401E7;

		/// <summary>Moniker is not bindable.</summary>
		public const uint MK_E_NOTBINDABLE = 0x800401E8;

		/// <summary>Moniker is not bound.</summary>
		public const uint MK_E_NOTBOUND = 0x800401E9;

		/// <summary>Moniker cannot open file.</summary>
		public const uint MK_E_CANTOPENFILE = 0x800401EA;

		/// <summary>User input required for operation to succeed.</summary>
		public const uint MK_E_MUSTBOTHERUSER = 0x800401EB;

		/// <summary>Moniker class has no inverse.</summary>
		public const uint MK_E_NOINVERSE = 0x800401EC;

		/// <summary>Moniker does not refer to storage.</summary>
		public const uint MK_E_NOSTORAGE = 0x800401ED;

		/// <summary>No common prefix.</summary>
		public const uint MK_E_NOPREFIX = 0x800401EE;

		/// <summary>Moniker could not be enumerated.</summary>
		public const uint MK_E_ENUMERATION_FAILED = 0x800401EF;

		/// <summary>CoInitialize has not been called.</summary>
		public const uint CO_E_NOTINITIALIZED = 0x800401F0;

		/// <summary>CoInitialize has already been called.</summary>
		public const uint CO_E_ALREADYINITIALIZED = 0x800401F1;

		/// <summary>Class of object cannot be determined.</summary>
		public const uint CO_E_CANTDETERMINECLASS = 0x800401F2;

		/// <summary>Invalid class string.</summary>
		public const uint CO_E_CLASSSTRING = 0x800401F3;

		/// <summary>Invalid interface string.</summary>
		public const uint CO_E_IIDSTRING = 0x800401F4;

		/// <summary>Application not found.</summary>
		public const uint CO_E_APPNOTFOUND = 0x800401F5;

		/// <summary>Application cannot be run more than once.</summary>
		public const uint CO_E_APPSINGLEUSE = 0x800401F6;

		/// <summary>Some error in application.</summary>
		public const uint CO_E_ERRORINAPP = 0x800401F7;

		/// <summary>DLL for class not found.</summary>
		public const uint CO_E_DLLNOTFOUND = 0x800401F8;

		/// <summary>Error in the DLL.</summary>
		public const uint CO_E_ERRORINDLL = 0x800401F9;

		/// <summary>Wrong operating system or operating system version for application.</summary>
		public const uint CO_E_WRONGOSFORAPP = 0x800401FA;

		/// <summary>Object is not registered.</summary>
		public const uint CO_E_OBJNOTREG = 0x800401FB;

		/// <summary>Object is already registered.</summary>
		public const uint CO_E_OBJISREG = 0x800401FC;

		/// <summary>Object is not connected to server.</summary>
		public const uint CO_E_OBJNOTCONNECTED = 0x800401FD;

		/// <summary>Application was launched, but it did not register a class factory.</summary>
		public const uint CO_E_APPDIDNTREG = 0x800401FE;

		/// <summary>Object has been released.</summary>
		public const uint CO_E_RELEASED = 0x800401FF;

		/// <summary>An event was unable to invoke any of the subscribers.</summary>
		public const uint EVENT_E_ALL_SUBSCRIBERS_FAILED = 0x80040201;

		/// <summary>A syntax error occurred trying to evaluate a query string.</summary>
		public const uint EVENT_E_QUERYSYNTAX = 0x80040203;

		/// <summary>An invalid field name was used in a query string.</summary>
		public const uint EVENT_E_QUERYFIELD = 0x80040204;

		/// <summary>An unexpected exception was raised.</summary>
		public const uint EVENT_E_INTERNALEXCEPTION = 0x80040205;

		/// <summary>An unexpected internal error was detected.</summary>
		public const uint EVENT_E_INTERNALERROR = 0x80040206;

		/// <summary>The owner security identifier (SID) on a per-user subscription does not exist.</summary>
		public const uint EVENT_E_INVALID_PER_USER_SID = 0x80040207;

		/// <summary>A user-supplied component or subscriber raised an exception.</summary>
		public const uint EVENT_E_USER_EXCEPTION = 0x80040208;

		/// <summary>An interface has too many methods to fire events from.</summary>
		public const uint EVENT_E_TOO_MANY_METHODS = 0x80040209;

		/// <summary>A subscription cannot be stored unless its event class already exists.</summary>
		public const uint EVENT_E_MISSING_EVENTCLASS = 0x8004020A;

		/// <summary>Not all the objects requested could be removed.</summary>
		public const uint EVENT_E_NOT_ALL_REMOVED = 0x8004020B;

		/// <summary>COM+ is required for this operation, but it is not installed.</summary>
		public const uint EVENT_E_COMPLUS_NOT_INSTALLED = 0x8004020C;

		/// <summary>Cannot modify or delete an object that was not added using the COM+ Administrative SDK.</summary>
		public const uint EVENT_E_CANT_MODIFY_OR_DELETE_UNCONFIGURED_OBJECT = 0x8004020D;

		/// <summary>Cannot modify or delete an object that was added using the COM+ Administrative SDK.</summary>
		public const uint EVENT_E_CANT_MODIFY_OR_DELETE_CONFIGURED_OBJECT = 0x8004020E;

		/// <summary>The event class for this subscription is in an invalid partition.</summary>
		public const uint EVENT_E_INVALID_EVENT_CLASS_PARTITION = 0x8004020F;

		/// <summary>The owner of the PerUser subscription is not logged on to the system specified.</summary>
		public const uint EVENT_E_PER_USER_SID_NOT_LOGGED_ON = 0x80040210;

		/// <summary>Trigger not found.</summary>
		public const uint SCHED_E_TRIGGER_NOT_FOUND = 0x80041309;

		/// <summary>One or more of the properties that are needed to run this task have not been set.</summary>
		public const uint SCHED_E_TASK_NOT_READY = 0x8004130A;

		/// <summary>There is no running instance of the task.</summary>
		public const uint SCHED_E_TASK_NOT_RUNNING = 0x8004130B;

		/// <summary>The Task Scheduler service is not installed on this computer.</summary>
		public const uint SCHED_E_SERVICE_NOT_INSTALLED = 0x8004130C;

		/// <summary>The task object could not be opened.</summary>
		public const uint SCHED_E_CANNOT_OPEN_TASK = 0x8004130D;

		/// <summary>The object is either an invalid task object or is not a task object.</summary>
		public const uint SCHED_E_INVALID_TASK = 0x8004130E;

		/// <summary>No account information could be found in the Task Scheduler security database for the task indicated.</summary>
		public const uint SCHED_E_ACCOUNT_INFORMATION_NOT_SET = 0x8004130F;

		/// <summary>Unable to establish existence of the account specified.</summary>
		public const uint SCHED_E_ACCOUNT_NAME_NOT_FOUND = 0x80041310;

		/// <summary>Corruption was detected in the Task Scheduler security database; the database has been reset.</summary>
		public const uint SCHED_E_ACCOUNT_DBASE_CORRUPT = 0x80041311;

		/// <summary>Task Scheduler security services are available only on Windows NT operating system.</summary>
		public const uint SCHED_E_NO_SECURITY_SERVICES = 0x80041312;

		/// <summary>The task object version is either unsupported or invalid.</summary>
		public const uint SCHED_E_UNKNOWN_OBJECT_VERSION = 0x80041313;

		/// <summary>The task has been configured with an unsupported combination of account settings and run-time options.</summary>
		public const uint SCHED_E_UNSUPPORTED_ACCOUNT_OPTION = 0x80041314;

		/// <summary>The Task Scheduler service is not running.</summary>
		public const uint SCHED_E_SERVICE_NOT_RUNNING = 0x80041315;

		/// <summary>The task XML contains an unexpected node.</summary>
		public const uint SCHED_E_UNEXPECTEDNODE = 0x80041316;

		/// <summary>The task XML contains an element or attribute from an unexpected namespace.</summary>
		public const uint SCHED_E_NAMESPACE = 0x80041317;

		/// <summary>The task XML contains a value that is incorrectly formatted or out of range.</summary>
		public const uint SCHED_E_INVALIDVALUE = 0x80041318;

		/// <summary>The task XML is missing a required element or attribute.</summary>
		public const uint SCHED_E_MISSINGNODE = 0x80041319;

		/// <summary>The task XML is malformed.</summary>
		public const uint SCHED_E_MALFORMEDXML = 0x8004131A;

		/// <summary>The task XML contains too many nodes of the same type.</summary>
		public const uint SCHED_E_TOO_MANY_NODES = 0x8004131D;

		/// <summary>The task cannot be started after the trigger's end boundary.</summary>
		public const uint SCHED_E_PAST_END_BOUNDARY = 0x8004131E;

		/// <summary>An instance of this task is already running.</summary>
		public const uint SCHED_E_ALREADY_RUNNING = 0x8004131F;

		/// <summary>The task will not run because the user is not logged on.</summary>
		public const uint SCHED_E_USER_NOT_LOGGED_ON = 0x80041320;

		/// <summary>The task image is corrupt or has been tampered with.</summary>
		public const uint SCHED_E_INVALID_TASK_HASH = 0x80041321;

		/// <summary>The Task Scheduler service is not available.</summary>
		public const uint SCHED_E_SERVICE_NOT_AVAILABLE = 0x80041322;

		/// <summary>The Task Scheduler service is too busy to handle your request. Try again later.</summary>
		public const uint SCHED_E_SERVICE_TOO_BUSY = 0x80041323;

		/// <summary>The Task Scheduler service attempted to run the task, but the task did not run due to one of the constraints in the task definition.</summary>
		public const uint SCHED_E_TASK_ATTEMPTED = 0x80041324;

		/// <summary>Another single phase resource manager has already been enlisted in this transaction.</summary>
		public const uint XACT_E_ALREADYOTHERSINGLEPHASE = 0x8004D000;

		/// <summary>A retaining commit or abort is not supported.</summary>
		public const uint XACT_E_CANTRETAIN = 0x8004D001;

		/// <summary>The transaction failed to commit for an unknown reason. The transaction was aborted.</summary>
		public const uint XACT_E_COMMITFAILED = 0x8004D002;

		/// <summary>Cannot call commit on this transaction object because the calling application did not initiate the transaction.</summary>
		public const uint XACT_E_COMMITPREVENTED = 0x8004D003;

		/// <summary>Instead of committing, the resource heuristically aborted.</summary>
		public const uint XACT_E_HEURISTICABORT = 0x8004D004;

		/// <summary>Instead of aborting, the resource heuristically committed.</summary>
		public const uint XACT_E_HEURISTICCOMMIT = 0x8004D005;

		/// <summary>Some of the states of the resource were committed while others were aborted, likely because of heuristic decisions.</summary>
		public const uint XACT_E_HEURISTICDAMAGE = 0x8004D006;

		/// <summary>Some of the states of the resource might have been committed while others were aborted, likely because of heuristic decisions.</summary>
		public const uint XACT_E_HEURISTICDANGER = 0x8004D007;

		/// <summary>The requested isolation level is not valid or supported.</summary>
		public const uint XACT_E_ISOLATIONLEVEL = 0x8004D008;

		/// <summary>The transaction manager does not support an asynchronous operation for this method.</summary>
		public const uint XACT_E_NOASYNC = 0x8004D009;

		/// <summary>Unable to enlist in the transaction.</summary>
		public const uint XACT_E_NOENLIST = 0x8004D00A;

		/// <summary>The requested semantics of retention of isolation across retaining commit and abort boundaries cannot be supported by this transaction implementation, or isoFlags was not equal to 0.</summary>
		public const uint XACT_E_NOISORETAIN = 0x8004D00B;

		/// <summary>There is no resource presently associated with this enlistment.</summary>
		public const uint XACT_E_NORESOURCE = 0x8004D00C;

		/// <summary>The transaction failed to commit due to the failure of optimistic concurrency control in at least one of the resource managers.</summary>
		public const uint XACT_E_NOTCURRENT = 0x8004D00D;

		/// <summary>The transaction has already been implicitly or explicitly committed or aborted.</summary>
		public const uint XACT_E_NOTRANSACTION = 0x8004D00E;

		/// <summary>An invalid combination of flags was specified.</summary>
		public const uint XACT_E_NOTSUPPORTED = 0x8004D00F;

		/// <summary>The resource manager ID is not associated with this transaction or the transaction manager.</summary>
		public const uint XACT_E_UNKNOWNRMGRID = 0x8004D010;

		/// <summary>This method was called in the wrong state.</summary>
		public const uint XACT_E_WRONGSTATE = 0x8004D011;

		/// <summary>The indicated unit of work does not match the unit of work expected by the resource manager.</summary>
		public const uint XACT_E_WRONGUOW = 0x8004D012;

		/// <summary>An enlistment in a transaction already exists.</summary>
		public const uint XACT_E_XTIONEXISTS = 0x8004D013;

		/// <summary>An import object for the transaction could not be found.</summary>
		public const uint XACT_E_NOIMPORTOBJECT = 0x8004D014;

		/// <summary>The transaction cookie is invalid.</summary>
		public const uint XACT_E_INVALIDCOOKIE = 0x8004D015;

		/// <summary>The transaction status is in doubt. A communication failure occurred, or a transaction manager or resource manager has failed.</summary>
		public const uint XACT_E_INDOUBT = 0x8004D016;

		/// <summary>A time-out was specified, but time-outs are not supported.</summary>
		public const uint XACT_E_NOTIMEOUT = 0x8004D017;

		/// <summary>The requested operation is already in progress for the transaction.</summary>
		public const uint XACT_E_ALREADYINPROGRESS = 0x8004D018;

		/// <summary>The transaction has already been aborted.</summary>
		public const uint XACT_E_ABORTED = 0x8004D019;

		/// <summary>The Transaction Manager returned a log full error.</summary>
		public const uint XACT_E_LOGFULL = 0x8004D01A;

		/// <summary>The transaction manager is not available.</summary>
		public const uint XACT_E_TMNOTAVAILABLE = 0x8004D01B;

		/// <summary>A connection with the transaction manager was lost.</summary>
		public const uint XACT_E_CONNECTION_DOWN = 0x8004D01C;

		/// <summary>A request to establish a connection with the transaction manager was denied.</summary>
		public const uint XACT_E_CONNECTION_DENIED = 0x8004D01D;

		/// <summary>Resource manager reenlistment to determine transaction status timed out.</summary>
		public const uint XACT_E_REENLISTTIMEOUT = 0x8004D01E;

		/// <summary>The transaction manager failed to establish a connection with another Transaction Internet Protocol (TIP) transaction manager.</summary>
		public const uint XACT_E_TIP_CONNECT_FAILED = 0x8004D01F;

		/// <summary>The transaction manager encountered a protocol error with another TIP transaction manager.</summary>
		public const uint XACT_E_TIP_PROTOCOL_ERROR = 0x8004D020;

		/// <summary>The transaction manager could not propagate a transaction from another TIP transaction manager.</summary>
		public const uint XACT_E_TIP_PULL_FAILED = 0x8004D021;

		/// <summary>The transaction manager on the destination machine is not available.</summary>
		public const uint XACT_E_DEST_TMNOTAVAILABLE = 0x8004D022;

		/// <summary>The transaction manager has disabled its support for TIP.</summary>
		public const uint XACT_E_TIP_DISABLED = 0x8004D023;

		/// <summary>The transaction manager has disabled its support for remote or network transactions.</summary>
		public const uint XACT_E_NETWORK_TX_DISABLED = 0x8004D024;

		/// <summary>The partner transaction manager has disabled its support for remote or network transactions.</summary>
		public const uint XACT_E_PARTNER_NETWORK_TX_DISABLED = 0x8004D025;

		/// <summary>The transaction manager has disabled its support for XA transactions.</summary>
		public const uint XACT_E_XA_TX_DISABLED = 0x8004D026;

		/// <summary>Microsoft Distributed Transaction Coordinator (MSDTC) was unable to read its configuration information.</summary>
		public const uint XACT_E_UNABLE_TO_READ_DTC_CONFIG = 0x8004D027;

		/// <summary>MSDTC was unable to load the DTC proxy DLL.</summary>
		public const uint XACT_E_UNABLE_TO_LOAD_DTC_PROXY = 0x8004D028;

		/// <summary>The local transaction has aborted.</summary>
		public const uint XACT_E_ABORTING = 0x8004D029;

		/// <summary>The specified CRM clerk was not found. It might have completed before it could be held.</summary>
		public const uint XACT_E_CLERKNOTFOUND = 0x8004D080;

		/// <summary>The specified CRM clerk does not exist.</summary>
		public const uint XACT_E_CLERKEXISTS = 0x8004D081;

		/// <summary>Recovery of the CRM log file is still in progress.</summary>
		public const uint XACT_E_RECOVERYINPROGRESS = 0x8004D082;

		/// <summary>The transaction has completed, and the log records have been discarded from the log file. They are no longer available.</summary>
		public const uint XACT_E_TRANSACTIONCLOSED = 0x8004D083;

		/// <summary>lsnToRead is outside of the current limits of the log</summary>
		public const uint XACT_E_INVALIDLSN = 0x8004D084;

		/// <summary>The COM+ Compensating Resource Manager has records it wishes to replay.</summary>
		public const uint XACT_E_REPLAYREQUEST = 0x8004D085;

		/// <summary>The request to connect to the specified transaction coordinator was denied.</summary>
		public const uint XACT_E_CONNECTION_REQUEST_DENIED = 0x8004D100;

		/// <summary>The maximum number of enlistments for the specified transaction has been reached.</summary>
		public const uint XACT_E_TOOMANY_ENLISTMENTS = 0x8004D101;

		/// <summary>A resource manager with the same identifier is already registered with the specified transaction coordinator.</summary>
		public const uint XACT_E_DUPLICATE_GUID = 0x8004D102;

		/// <summary>The prepare request given was not eligible for single-phase optimizations.</summary>
		public const uint XACT_E_NOTSINGLEPHASE = 0x8004D103;

		/// <summary>RecoveryComplete has already been called for the given resource manager.</summary>
		public const uint XACT_E_RECOVERYALREADYDONE = 0x8004D104;

		/// <summary>The interface call made was incorrect for the current state of the protocol.</summary>
		public const uint XACT_E_PROTOCOL = 0x8004D105;

		/// <summary>The xa_open call failed for the XA resource.</summary>
		public const uint XACT_E_RM_FAILURE = 0x8004D106;

		/// <summary>The xa_recover call failed for the XA resource.</summary>
		public const uint XACT_E_RECOVERY_FAILED = 0x8004D107;

		/// <summary>The logical unit of work specified cannot be found.</summary>
		public const uint XACT_E_LU_NOT_FOUND = 0x8004D108;

		/// <summary>The specified logical unit of work already exists.</summary>
		public const uint XACT_E_DUPLICATE_LU = 0x8004D109;

		/// <summary>Subordinate creation failed. The specified logical unit of work was not connected.</summary>
		public const uint XACT_E_LU_NOT_CONNECTED = 0x8004D10A;

		/// <summary>A transaction with the given identifier already exists.</summary>
		public const uint XACT_E_DUPLICATE_TRANSID = 0x8004D10B;

		/// <summary>The resource is in use.</summary>
		public const uint XACT_E_LU_BUSY = 0x8004D10C;

		/// <summary>The LU Recovery process is down.</summary>
		public const uint XACT_E_LU_NO_RECOVERY_PROCESS = 0x8004D10D;

		/// <summary>The remote session was lost.</summary>
		public const uint XACT_E_LU_DOWN = 0x8004D10E;

		/// <summary>The resource is currently recovering.</summary>
		public const uint XACT_E_LU_RECOVERING = 0x8004D10F;

		/// <summary>There was a mismatch in driving recovery.</summary>
		public const uint XACT_E_LU_RECOVERY_MISMATCH = 0x8004D110;

		/// <summary>An error occurred with the XA resource.</summary>
		public const uint XACT_E_RM_UNAVAILABLE = 0x8004D111;

		/// <summary>The root transaction wanted to commit, but the transaction aborted.</summary>
		public const uint CONTEXT_E_ABORTED = 0x8004E002;

		/// <summary>The COM+ component on which the method call was made has a transaction that has already aborted or is in the process of aborting.</summary>
		public const uint CONTEXT_E_ABORTING = 0x8004E003;

		/// <summary>There is no Microsoft Transaction Server (MTS) object context.</summary>
		public const uint CONTEXT_E_NOCONTEXT = 0x8004E004;

		/// <summary>The component is configured to use synchronization, and this method call would cause a deadlock to occur.</summary>
		public const uint CONTEXT_E_WOULD_DEADLOCK = 0x8004E005;

		/// <summary>The component is configured to use synchronization, and a thread has timed out waiting to enter the context.</summary>
		public const uint CONTEXT_E_SYNCH_TIMEOUT = 0x8004E006;

		/// <summary>You made a method call on a COM+ component that has a transaction that has already committed or aborted.</summary>
		public const uint CONTEXT_E_OLDREF = 0x8004E007;

		/// <summary>The specified role was not configured for the application.</summary>
		public const uint CONTEXT_E_ROLENOTFOUND = 0x8004E00C;

		/// <summary>COM+ was unable to talk to the MSDTC.</summary>
		public const uint CONTEXT_E_TMNOTAVAILABLE = 0x8004E00F;

		/// <summary>An unexpected error occurred during COM+ activation.</summary>
		public const uint CO_E_ACTIVATIONFAILED = 0x8004E021;

		/// <summary>COM+ activation failed. Check the event log for more information.</summary>
		public const uint CO_E_ACTIVATIONFAILED_EVENTLOGGED = 0x8004E022;

		/// <summary>COM+ activation failed due to a catalog or configuration error.</summary>
		public const uint CO_E_ACTIVATIONFAILED_CATALOGERROR = 0x8004E023;

		/// <summary>COM+ activation failed because the activation could not be completed in the specified amount of time.</summary>
		public const uint CO_E_ACTIVATIONFAILED_TIMEOUT = 0x8004E024;

		/// <summary>COM+ activation failed because an initialization function failed. Check the event log for more information.</summary>
		public const uint CO_E_INITIALIZATIONFAILED = 0x8004E025;

		/// <summary>The requested operation requires that just-in-time (JIT) be in the current context, and it is not.</summary>
		public const uint CONTEXT_E_NOJIT = 0x8004E026;

		/// <summary>The requested operation requires that the current context have a transaction, and it does not.</summary>
		public const uint CONTEXT_E_NOTRANSACTION = 0x8004E027;

		/// <summary>The components threading model has changed after install into a COM+ application. Re-install component.</summary>
		public const uint CO_E_THREADINGMODEL_CHANGED = 0x8004E028;

		/// <summary>Internet Information Services (IIS) intrinsics not available. Start your work with IIS.</summary>
		public const uint CO_E_NOIISINTRINSICS = 0x8004E029;

		/// <summary>An attempt to write a cookie failed.</summary>
		public const uint CO_E_NOCOOKIES = 0x8004E02A;

		/// <summary>An attempt to use a database generated a database-specific error.</summary>
		public const uint CO_E_DBERROR = 0x8004E02B;

		/// <summary>The COM+ component you created must use object pooling to work.</summary>
		public const uint CO_E_NOTPOOLED = 0x8004E02C;

		/// <summary>The COM+ component you created must use object construction to work correctly.</summary>
		public const uint CO_E_NOTCONSTRUCTED = 0x8004E02D;

		/// <summary>The COM+ component requires synchronization, and it is not configured for it.</summary>
		public const uint CO_E_NOSYNCHRONIZATION = 0x8004E02E;

		/// <summary>The TxIsolation Level property for the COM+ component being created is stronger than the TxIsolationLevel for the root.</summary>
		public const uint CO_E_ISOLEVELMISMATCH = 0x8004E02F;

		/// <summary>The component attempted to make a cross-context call between invocations of EnterTransactionScope and ExitTransactionScope. This is not allowed. Cross-context calls cannot be made while inside a transaction scope.</summary>
		public const uint CO_E_CALL_OUT_OF_TX_SCOPE_NOT_ALLOWED = 0x8004E030;

		/// <summary>The component made a call to EnterTransactionScope, but did not make a corresponding call to ExitTransactionScope before returning.</summary>
		public const uint CO_E_EXIT_TRANSACTION_SCOPE_NOT_CALLED = 0x8004E031;

		/// <summary>General access denied error.</summary>
		public const uint E_ACCESSDENIED = 0x80070005;

		/// <summary>The server does not have enough memory for the new channel.</summary>
		public const uint E_OUTOFMEMORY = 0x8007000E;

		/// <summary>The server cannot support a client request for a dynamic virtual channel.</summary>
		public const uint ERROR_NOT_SUPPORTED = 0x80070032;

		/// <summary>One or more arguments are invalid.</summary>
		public const uint E_INVALIDARG = 0x80070057;

		/// <summary>There is not enough space on the disk.</summary>
		public const uint ERROR_DISK_FULL = 0x80070070;

		/// <summary>Attempt to create a class object failed.</summary>
		public const uint CO_E_CLASS_CREATE_FAILED = 0x80080001;

		/// <summary>OLE service could not bind object.</summary>
		public const uint CO_E_SCM_ERROR = 0x80080002;

		/// <summary>RPC communication failed with OLE service.</summary>
		public const uint CO_E_SCM_RPC_FAILURE = 0x80080003;

		/// <summary>Bad path to object.</summary>
		public const uint CO_E_BAD_PATH = 0x80080004;

		/// <summary>Server execution failed.</summary>
		public const uint CO_E_SERVER_EXEC_FAILURE = 0x80080005;

		/// <summary>OLE service could not communicate with the object server.</summary>
		public const uint CO_E_OBJSRV_RPC_FAILURE = 0x80080006;

		/// <summary>Moniker path could not be normalized.</summary>
		public const uint MK_E_NO_NORMALIZED = 0x80080007;

		/// <summary>Object server is stopping when OLE service contacts it.</summary>
		public const uint CO_E_SERVER_STOPPING = 0x80080008;

		/// <summary>An invalid root block pointer was specified.</summary>
		public const uint MEM_E_INVALID_ROOT = 0x80080009;

		/// <summary>An allocation chain contained an invalid link pointer.</summary>
		public const uint MEM_E_INVALID_LINK = 0x80080010;

		/// <summary>The requested allocation size was too large.</summary>
		public const uint MEM_E_INVALID_SIZE = 0x80080011;

		/// <summary>The activation requires a display name to be present under the class identifier (CLSID) key.</summary>
		public const uint CO_E_MISSING_DISPLAYNAME = 0x80080015;

		/// <summary>The activation requires that the RunAs value for the application is Activate As Activator.</summary>
		public const uint CO_E_RUNAS_VALUE_MUST_BE_AAA = 0x80080016;

		/// <summary>The class is not configured to support elevated activation.</summary>
		public const uint CO_E_ELEVATION_DISABLED = 0x80080017;

		/// <summary>Bad UID.</summary>
		public const uint NTE_BAD_UID = 0x80090001;

		/// <summary>Bad hash.</summary>
		public const uint NTE_BAD_HASH = 0x80090002;

		/// <summary>Bad key.</summary>
		public const uint NTE_BAD_KEY = 0x80090003;

		/// <summary>Bad length.</summary>
		public const uint NTE_BAD_LEN = 0x80090004;

		/// <summary>Bad data.</summary>
		public const uint NTE_BAD_DATA = 0x80090005;

		/// <summary>Invalid signature.</summary>
		public const uint NTE_BAD_SIGNATURE = 0x80090006;

		/// <summary>Bad version of provider.</summary>
		public const uint NTE_BAD_VER = 0x80090007;

		/// <summary>Invalid algorithm specified.</summary>
		public const uint NTE_BAD_ALGID = 0x80090008;

		/// <summary>Invalid flags specified.</summary>
		public const uint NTE_BAD_FLAGS = 0x80090009;

		/// <summary>Invalid type specified.</summary>
		public const uint NTE_BAD_TYPE = 0x8009000A;

		/// <summary>Key not valid for use in specified state.</summary>
		public const uint NTE_BAD_KEY_STATE = 0x8009000B;

		/// <summary>Hash not valid for use in specified state.</summary>
		public const uint NTE_BAD_HASH_STATE = 0x8009000C;

		/// <summary>Key does not exist.</summary>
		public const uint NTE_NO_KEY = 0x8009000D;

		/// <summary>Insufficient memory available for the operation.</summary>
		public const uint NTE_NO_MEMORY = 0x8009000E;

		/// <summary>Object already exists.</summary>
		public const uint NTE_EXISTS = 0x8009000F;

		/// <summary>Access denied.</summary>
		public const uint NTE_PERM = 0x80090010;

		/// <summary>Object was not found.</summary>
		public const uint NTE_NOT_FOUND = 0x80090011;

		/// <summary>Data already encrypted.</summary>
		public const uint NTE_DOUBLE_ENCRYPT = 0x80090012;

		/// <summary>Invalid provider specified.</summary>
		public const uint NTE_BAD_PROVIDER = 0x80090013;

		/// <summary>Invalid provider type specified.</summary>
		public const uint NTE_BAD_PROV_TYPE = 0x80090014;

		/// <summary>Provider's public key is invalid.</summary>
		public const uint NTE_BAD_PUBLIC_KEY = 0x80090015;

		/// <summary>Key set does not exist.</summary>
		public const uint NTE_BAD_KEYSET = 0x80090016;

		/// <summary>Provider type not defined.</summary>
		public const uint NTE_PROV_TYPE_NOT_DEF = 0x80090017;

		/// <summary>The provider type, as registered, is invalid.</summary>
		public const uint NTE_PROV_TYPE_ENTRY_BAD = 0x80090018;

		/// <summary>The key set is not defined.</summary>
		public const uint NTE_KEYSET_NOT_DEF = 0x80090019;

		/// <summary>The key set, as registered, is invalid.</summary>
		public const uint NTE_KEYSET_ENTRY_BAD = 0x8009001A;

		/// <summary>Provider type does not match registered value.</summary>
		public const uint NTE_PROV_TYPE_NO_MATCH = 0x8009001B;

		/// <summary>The digital signature file is corrupt.</summary>
		public const uint NTE_SIGNATURE_FILE_BAD = 0x8009001C;

		/// <summary>Provider DLL failed to initialize correctly.</summary>
		public const uint NTE_PROVIDER_DLL_FAIL = 0x8009001D;

		/// <summary>Provider DLL could not be found.</summary>
		public const uint NTE_PROV_DLL_NOT_FOUND = 0x8009001E;

		/// <summary>The keyset parameter is invalid.</summary>
		public const uint NTE_BAD_KEYSET_PARAM = 0x8009001F;

		/// <summary>An internal error occurred.</summary>
		public const uint NTE_FAIL = 0x80090020;

		/// <summary>A base error occurred.</summary>
		public const uint NTE_SYS_ERR = 0x80090021;

		/// <summary>Provider could not perform the action because the context was acquired as silent.</summary>
		public const uint NTE_SILENT_CONTEXT = 0x80090022;

		/// <summary>The security token does not have storage space available for an additional container.</summary>
		public const uint NTE_TOKEN_KEYSET_STORAGE_FULL = 0x80090023;

		/// <summary>The profile for the user is a temporary profile.</summary>
		public const uint NTE_TEMPORARY_PROFILE = 0x80090024;

		/// <summary>The key parameters could not be set because the configuration service provider (CSP) uses fixed parameters.</summary>
		public const uint NTE_FIXEDPARAMETER = 0x80090025;

		/// <summary>The supplied handle is invalid.</summary>
		public const uint NTE_INVALID_HANDLE = 0x80090026;

		/// <summary>The parameter is incorrect.</summary>
		public const uint NTE_INVALID_PARAMETER = 0x80090027;

		/// <summary>The buffer supplied to a function was too small.</summary>
		public const uint NTE_BUFFER_TOO_SMALL = 0x80090028;

		/// <summary>The requested operation is not supported.</summary>
		public const uint NTE_NOT_SUPPORTED = 0x80090029;

		/// <summary>No more data is available.</summary>
		public const uint NTE_NO_MORE_ITEMS = 0x8009002A;

		/// <summary>The supplied buffers overlap incorrectly.</summary>
		public const uint NTE_BUFFERS_OVERLAP = 0x8009002B;

		/// <summary>The specified data could not be decrypted.</summary>
		public const uint NTE_DECRYPTION_FAILURE = 0x8009002C;

		/// <summary>An internal consistency check failed.</summary>
		public const uint NTE_INTERNAL_ERROR = 0x8009002D;

		/// <summary>This operation requires input from the user.</summary>
		public const uint NTE_UI_REQUIRED = 0x8009002E;

		/// <summary>The cryptographic provider does not support Hash Message Authentication Code (HMAC).</summary>
		public const uint NTE_HMAC_NOT_SUPPORTED = 0x8009002F;

		/// <summary>Not enough memory is available to complete this request.</summary>
		public const uint SEC_E_INSUFFICIENT_MEMORY = 0x80090300;

		/// <summary>The handle specified is invalid.</summary>
		public const uint SEC_E_INVALID_HANDLE = 0x80090301;

		/// <summary>The function requested is not supported.</summary>
		public const uint SEC_E_UNSUPPORTED_FUNCTION = 0x80090302;

		/// <summary>The specified target is unknown or unreachable.</summary>
		public const uint SEC_E_TARGET_UNKNOWN = 0x80090303;

		/// <summary>The Local Security Authority (LSA) cannot be contacted.</summary>
		public const uint SEC_E_INTERNAL_ERROR = 0x80090304;

		/// <summary>The requested security package does not exist.</summary>
		public const uint SEC_E_SECPKG_NOT_FOUND = 0x80090305;

		/// <summary>The caller is not the owner of the desired credentials.</summary>
		public const uint SEC_E_NOT_OWNER = 0x80090306;

		/// <summary>The security package failed to initialize and cannot be installed.</summary>
		public const uint SEC_E_CANNOT_INSTALL = 0x80090307;

		/// <summary>The token supplied to the function is invalid.</summary>
		public const uint SEC_E_INVALID_TOKEN = 0x80090308;

		/// <summary>The security package is not able to marshal the logon buffer, so the logon attempt has failed.</summary>
		public const uint SEC_E_CANNOT_PACK = 0x80090309;

		/// <summary>The per-message quality of protection is not supported by the security package.</summary>
		public const uint SEC_E_QOP_NOT_SUPPORTED = 0x8009030A;

		/// <summary>The security context does not allow impersonation of the client.</summary>
		public const uint SEC_E_NO_IMPERSONATION = 0x8009030B;

		/// <summary>The logon attempt failed.</summary>
		public const uint SEC_E_LOGON_DENIED = 0x8009030C;

		/// <summary>The credentials supplied to the package were not recognized.</summary>
		public const uint SEC_E_UNKNOWN_CREDENTIALS = 0x8009030D;

		/// <summary>No credentials are available in the security package.</summary>
		public const uint SEC_E_NO_CREDENTIALS = 0x8009030E;

		/// <summary>The message or signature supplied for verification has been altered.</summary>
		public const uint SEC_E_MESSAGE_ALTERED = 0x8009030F;

		/// <summary>The message supplied for verification is out of sequence.</summary>
		public const uint SEC_E_OUT_OF_SEQUENCE = 0x80090310;

		/// <summary>No authority could be contacted for authentication.</summary>
		public const uint SEC_E_NO_AUTHENTICATING_AUTHORITY = 0x80090311;

		/// <summary>The requested security package does not exist.</summary>
		public const uint SEC_E_BAD_PKGID = 0x80090316;

		/// <summary>The context has expired and can no longer be used.</summary>
		public const uint SEC_E_CONTEXT_EXPIRED = 0x80090317;

		/// <summary>The supplied message is incomplete. The signature was not verified.</summary>
		public const uint SEC_E_INCOMPLETE_MESSAGE = 0x80090318;

		/// <summary>The credentials supplied were not complete and could not be verified. The context could not be initialized.</summary>
		public const uint SEC_E_INCOMPLETE_CREDENTIALS = 0x80090320;

		/// <summary>The buffers supplied to a function was too small.</summary>
		public const uint SEC_E_BUFFER_TOO_SMALL = 0x80090321;

		/// <summary>The target principal name is incorrect.</summary>
		public const uint SEC_E_WRONG_PRINCIPAL = 0x80090322;

		/// <summary>The clocks on the client and server machines are skewed.</summary>
		public const uint SEC_E_TIME_SKEW = 0x80090324;

		/// <summary>The certificate chain was issued by an authority that is not trusted.</summary>
		public const uint SEC_E_UNTRUSTED_ROOT = 0x80090325;

		/// <summary>The message received was unexpected or badly formatted.</summary>
		public const uint SEC_E_ILLEGAL_MESSAGE = 0x80090326;

		/// <summary>An unknown error occurred while processing the certificate.</summary>
		public const uint SEC_E_CERT_UNKNOWN = 0x80090327;

		/// <summary>The received certificate has expired.</summary>
		public const uint SEC_E_CERT_EXPIRED = 0x80090328;

		/// <summary>The specified data could not be encrypted.</summary>
		public const uint SEC_E_ENCRYPT_FAILURE = 0x80090329;

		/// <summary>The specified data could not be decrypted.</summary>
		public const uint SEC_E_DECRYPT_FAILURE = 0x80090330;

		/// <summary>The client and server cannot communicate because they do not possess a common algorithm.</summary>
		public const uint SEC_E_ALGORITHM_MISMATCH = 0x80090331;

		/// <summary>The security context could not be established due to a failure in the requested quality of service (for example, mutual authentication or delegation).</summary>
		public const uint SEC_E_SECURITY_QOS_FAILED = 0x80090332;

		/// <summary>A security context was deleted before the context was completed. This is considered a logon failure.</summary>
		public const uint SEC_E_UNFINISHED_CONTEXT_DELETED = 0x80090333;

		/// <summary>The client is trying to negotiate a context and the server requires user-to-user but did not send a ticket granting ticket (TGT) reply.</summary>
		public const uint SEC_E_NO_TGT_REPLY = 0x80090334;

		/// <summary>Unable to accomplish the requested task because the local machine does not have an IP addresses.</summary>
		public const uint SEC_E_NO_IP_ADDRESSES = 0x80090335;

		/// <summary>The supplied credential handle does not match the credential associated with the security context.</summary>
		public const uint SEC_E_WRONG_CREDENTIAL_HANDLE = 0x80090336;

		/// <summary>The cryptographic system or checksum function is invalid because a required function is unavailable.</summary>
		public const uint SEC_E_CRYPTO_SYSTEM_INVALID = 0x80090337;

		/// <summary>The number of maximum ticket referrals has been exceeded.</summary>
		public const uint SEC_E_MAX_REFERRALS_EXCEEDED = 0x80090338;

		/// <summary>The local machine must be a Kerberos domain controller (KDC), and it is not.</summary>
		public const uint SEC_E_MUST_BE_KDC = 0x80090339;

		/// <summary>The other end of the security negotiation requires strong cryptographics, but it is not supported on the local machine.</summary>
		public const uint SEC_E_STRONG_CRYPTO_NOT_SUPPORTED = 0x8009033A;

		/// <summary>The KDC reply contained more than one principal name.</summary>
		public const uint SEC_E_TOO_MANY_PRINCIPALS = 0x8009033B;

		/// <summary>Expected to find PA data for a hint of what etype to use, but it was not found.</summary>
		public const uint SEC_E_NO_PA_DATA = 0x8009033C;

		/// <summary>The client certificate does not contain a valid user principal name (UPN), or does not match the client name in the logon request. Contact your administrator.</summary>
		public const uint SEC_E_PKINIT_NAME_MISMATCH = 0x8009033D;

		/// <summary>Smart card logon is required and was not used.</summary>
		public const uint SEC_E_SMARTCARD_LOGON_REQUIRED = 0x8009033E;

		/// <summary>A system shutdown is in progress.</summary>
		public const uint SEC_E_SHUTDOWN_IN_PROGRESS = 0x8009033F;

		/// <summary>An invalid request was sent to the KDC.</summary>
		public const uint SEC_E_KDC_INVALID_REQUEST = 0x80090340;

		/// <summary>The KDC was unable to generate a referral for the service requested.</summary>
		public const uint SEC_E_KDC_UNABLE_TO_REFER = 0x80090341;

		/// <summary>The encryption type requested is not supported by the KDC.</summary>
		public const uint SEC_E_KDC_UNKNOWN_ETYPE = 0x80090342;

		/// <summary>An unsupported pre-authentication mechanism was presented to the Kerberos package.</summary>
		public const uint SEC_E_UNSUPPORTED_PREAUTH = 0x80090343;

		/// <summary>The requested operation cannot be completed. The computer must be trusted for delegation, and the current user account must be configured to allow delegation.</summary>
		public const uint SEC_E_DELEGATION_REQUIRED = 0x80090345;

		/// <summary>Client's supplied Security Support Provider Interface (SSPI) channel bindings were incorrect.</summary>
		public const uint SEC_E_BAD_BINDINGS = 0x80090346;

		/// <summary>The received certificate was mapped to multiple accounts.</summary>
		public const uint SEC_E_MULTIPLE_ACCOUNTS = 0x80090347;

		/// <summary>No Kerberos key was found.</summary>
		public const uint SEC_E_NO_KERB_KEY = 0x80090348;

		/// <summary>The certificate is not valid for the requested usage.</summary>
		public const uint SEC_E_CERT_WRONG_USAGE = 0x80090349;

		/// <summary>The system detected a possible attempt to compromise security. Ensure that you can contact the server that authenticated you.</summary>
		public const uint SEC_E_DOWNGRADE_DETECTED = 0x80090350;

		/// <summary>The smart card certificate used for authentication has been revoked. Contact your system administrator. The event log might contain additional information.</summary>
		public const uint SEC_E_SMARTCARD_CERT_REVOKED = 0x80090351;

		/// <summary>An untrusted certification authority (CA) was detected while processing the smart card certificate used for authentication. Contact your system administrator.</summary>
		public const uint SEC_E_ISSUING_CA_UNTRUSTED = 0x80090352;

		/// <summary>The revocation status of the smart card certificate used for authentication could not be determined. Contact your system administrator.</summary>
		public const uint SEC_E_REVOCATION_OFFLINE_C = 0x80090353;

		/// <summary>The smart card certificate used for authentication was not trusted. Contact your system administrator.</summary>
		public const uint SEC_E_PKINIT_CLIENT_FAILURE = 0x80090354;

		/// <summary>The smart card certificate used for authentication has expired. Contact your system administrator.</summary>
		public const uint SEC_E_SMARTCARD_CERT_EXPIRED = 0x80090355;

		/// <summary>The Kerberos subsystem encountered an error. A service for user protocol requests was made against a domain controller that does not support services for users.</summary>
		public const uint SEC_E_NO_S4U_PROT_SUPPORT = 0x80090356;

		/// <summary>An attempt was made by this server to make a Kerberos-constrained delegation request for a target outside the server's realm. This is not supported and indicates a misconfiguration on this server's allowed-to-delegate-to list. Contact your administrator.</summary>
		public const uint SEC_E_CROSSREALM_DELEGATION_FAILURE = 0x80090357;

		/// <summary>The revocation status of the domain controller certificate used for smart card authentication could not be determined. The system event log contains additional information. Contact your system administrator.</summary>
		public const uint SEC_E_REVOCATION_OFFLINE_KDC = 0x80090358;

		/// <summary>An untrusted CA was detected while processing the domain controller certificate used for authentication. The system event log contains additional information. Contact your system administrator.</summary>
		public const uint SEC_E_ISSUING_CA_UNTRUSTED_KDC = 0x80090359;

		/// <summary>The domain controller certificate used for smart card logon has expired. Contact your system administrator with the contents of your system event log.</summary>
		public const uint SEC_E_KDC_CERT_EXPIRED = 0x8009035A;

		/// <summary>The domain controller certificate used for smart card logon has been revoked. Contact your system administrator with the contents of your system event log.</summary>
		public const uint SEC_E_KDC_CERT_REVOKED = 0x8009035B;

		/// <summary>One or more of the parameters passed to the function were invalid.</summary>
		public const uint SEC_E_INVALID_PARAMETER = 0x8009035D;

		/// <summary>The client policy does not allow credential delegation to the target server.</summary>
		public const uint SEC_E_DELEGATION_POLICY = 0x8009035E;

		/// <summary>The client policy does not allow credential delegation to the target server with NLTM only authentication.</summary>
		public const uint SEC_E_POLICY_NLTM_ONLY = 0x8009035F;

		/// <summary>An error occurred while performing an operation on a cryptographic message.</summary>
		public const uint CRYPT_E_MSG_ERROR = 0x80091001;

		/// <summary>Unknown cryptographic algorithm.</summary>
		public const uint CRYPT_E_UNKNOWN_ALGO = 0x80091002;

		/// <summary>The object identifier is poorly formatted.</summary>
		public const uint CRYPT_E_OID_FORMAT = 0x80091003;

		/// <summary>Invalid cryptographic message type.</summary>
		public const uint CRYPT_E_INVALID_MSG_TYPE = 0x80091004;

		/// <summary>Unexpected cryptographic message encoding.</summary>
		public const uint CRYPT_E_UNEXPECTED_ENCODING = 0x80091005;

		/// <summary>The cryptographic message does not contain an expected authenticated attribute.</summary>
		public const uint CRYPT_E_AUTH_ATTR_MISSING = 0x80091006;

		/// <summary>The hash value is not correct.</summary>
		public const uint CRYPT_E_HASH_VALUE = 0x80091007;

		/// <summary>The index value is not valid.</summary>
		public const uint CRYPT_E_INVALID_INDEX = 0x80091008;

		/// <summary>The content of the cryptographic message has already been decrypted.</summary>
		public const uint CRYPT_E_ALREADY_DECRYPTED = 0x80091009;

		/// <summary>The content of the cryptographic message has not been decrypted yet.</summary>
		public const uint CRYPT_E_NOT_DECRYPTED = 0x8009100A;

		/// <summary>The enveloped-data message does not contain the specified recipient.</summary>
		public const uint CRYPT_E_RECIPIENT_NOT_FOUND = 0x8009100B;

		/// <summary>Invalid control type.</summary>
		public const uint CRYPT_E_CONTROL_TYPE = 0x8009100C;

		/// <summary>Invalid issuer or serial number.</summary>
		public const uint CRYPT_E_ISSUER_SERIALNUMBER = 0x8009100D;

		/// <summary>Cannot find the original signer.</summary>
		public const uint CRYPT_E_SIGNER_NOT_FOUND = 0x8009100E;

		/// <summary>The cryptographic message does not contain all of the requested attributes.</summary>
		public const uint CRYPT_E_ATTRIBUTES_MISSING = 0x8009100F;

		/// <summary>The streamed cryptographic message is not ready to return data.</summary>
		public const uint CRYPT_E_STREAM_MSG_NOT_READY = 0x80091010;

		/// <summary>The streamed cryptographic message requires more data to complete the decode operation.</summary>
		public const uint CRYPT_E_STREAM_INSUFFICIENT_DATA = 0x80091011;

		/// <summary>The length specified for the output data was insufficient.</summary>
		public const uint CRYPT_E_BAD_LEN = 0x80092001;

		/// <summary>An error occurred during the encode or decode operation.</summary>
		public const uint CRYPT_E_BAD_ENCODE = 0x80092002;

		/// <summary>An error occurred while reading or writing to a file.</summary>
		public const uint CRYPT_E_FILE_ERROR = 0x80092003;

		/// <summary>Cannot find object or property.</summary>
		public const uint CRYPT_E_NOT_FOUND = 0x80092004;

		/// <summary>The object or property already exists.</summary>
		public const uint CRYPT_E_EXISTS = 0x80092005;

		/// <summary>No provider was specified for the store or object.</summary>
		public const uint CRYPT_E_NO_PROVIDER = 0x80092006;

		/// <summary>The specified certificate is self-signed.</summary>
		public const uint CRYPT_E_SELF_SIGNED = 0x80092007;

		/// <summary>The previous certificate or certificate revocation list (CRL) context was deleted.</summary>
		public const uint CRYPT_E_DELETED_PREV = 0x80092008;

		/// <summary>Cannot find the requested object.</summary>
		public const uint CRYPT_E_NO_MATCH = 0x80092009;

		/// <summary>The certificate does not have a property that references a private key.</summary>
		public const uint CRYPT_E_UNEXPECTED_MSG_TYPE = 0x8009200A;

		/// <summary>Cannot find the certificate and private key for decryption.</summary>
		public const uint CRYPT_E_NO_KEY_PROPERTY = 0x8009200B;

		/// <summary>Cannot find the certificate and private key to use for decryption.</summary>
		public const uint CRYPT_E_NO_DECRYPT_CERT = 0x8009200C;

		/// <summary>Not a cryptographic message or the cryptographic message is not formatted correctly.</summary>
		public const uint CRYPT_E_BAD_MSG = 0x8009200D;

		/// <summary>The signed cryptographic message does not have a signer for the specified signer index.</summary>
		public const uint CRYPT_E_NO_SIGNER = 0x8009200E;

		/// <summary>Final closure is pending until additional frees or closes.</summary>
		public const uint CRYPT_E_PENDING_CLOSE = 0x8009200F;

		/// <summary>The certificate is revoked.</summary>
		public const uint CRYPT_E_REVOKED = 0x80092010;

		/// <summary>No DLL or exported function was found to verify revocation.</summary>
		public const uint CRYPT_E_NO_REVOCATION_DLL = 0x80092011;

		/// <summary>The revocation function was unable to check revocation for the certificate.</summary>
		public const uint CRYPT_E_NO_REVOCATION_CHECK = 0x80092012;

		/// <summary>The revocation function was unable to check revocation because the revocation server was offline.</summary>
		public const uint CRYPT_E_REVOCATION_OFFLINE = 0x80092013;

		/// <summary>The certificate is not in the revocation server's database.</summary>
		public const uint CRYPT_E_NOT_IN_REVOCATION_DATABASE = 0x80092014;

		/// <summary>The string contains a non-numeric character.</summary>
		public const uint CRYPT_E_INVALID_NUMERIC_STRING = 0x80092020;

		/// <summary>The string contains a nonprintable character.</summary>
		public const uint CRYPT_E_INVALID_PRINTABLE_STRING = 0x80092021;

		/// <summary>The string contains a character not in the 7-bit ASCII character set.</summary>
		public const uint CRYPT_E_INVALID_IA5_STRING = 0x80092022;

		/// <summary>The string contains an invalid X500 name attribute key, object identifier (OID), value, or delimiter.</summary>
		public const uint CRYPT_E_INVALID_X500_STRING = 0x80092023;

		/// <summary>The dwValueType for the CERT_NAME_VALUE is not one of the character strings. Most likely it is either a CERT_RDN_ENCODED_BLOB or CERT_TDN_OCTED_STRING.</summary>
		public const uint CRYPT_E_NOT_CHAR_STRING = 0x80092024;

		/// <summary>The Put operation cannot continue. The file needs to be resized. However, there is already a signature present. A complete signing operation must be done.</summary>
		public const uint CRYPT_E_FILERESIZED = 0x80092025;

		/// <summary>The cryptographic operation failed due to a local security option setting.</summary>
		public const uint CRYPT_E_SECURITY_SETTINGS = 0x80092026;

		/// <summary>No DLL or exported function was found to verify subject usage.</summary>
		public const uint CRYPT_E_NO_VERIFY_USAGE_DLL = 0x80092027;

		/// <summary>The called function was unable to perform a usage check on the subject.</summary>
		public const uint CRYPT_E_NO_VERIFY_USAGE_CHECK = 0x80092028;

		/// <summary>The called function was unable to complete the usage check because the server was offline.</summary>
		public const uint CRYPT_E_VERIFY_USAGE_OFFLINE = 0x80092029;

		/// <summary>The subject was not found in a certificate trust list (CTL).</summary>
		public const uint CRYPT_E_NOT_IN_CTL = 0x8009202A;

		/// <summary>None of the signers of the cryptographic message or certificate trust list is trusted.</summary>
		public const uint CRYPT_E_NO_TRUSTED_SIGNER = 0x8009202B;

		/// <summary>The public key's algorithm parameters are missing.</summary>
		public const uint CRYPT_E_MISSING_PUBKEY_PARA = 0x8009202C;

		/// <summary>OSS Certificate encode/decode error code base.</summary>
		public const uint CRYPT_E_OSS_ERROR = 0x80093000;

		/// <summary>OSS ASN.1 Error: Output Buffer is too small.</summary>
		public const uint OSS_MORE_BUF = 0x80093001;

		/// <summary>OSS ASN.1 Error: Signed integer is encoded as a unsigned integer.</summary>
		public const uint OSS_NEGATIVE_UINTEGER = 0x80093002;

		/// <summary>OSS ASN.1 Error: Unknown ASN.1 data type.</summary>
		public const uint OSS_PDU_RANGE = 0x80093003;

		/// <summary>OSS ASN.1 Error: Output buffer is too small; the decoded data has been truncated.</summary>
		public const uint OSS_MORE_INPUT = 0x80093004;

		/// <summary>OSS ASN.1 Error: Invalid data.</summary>
		public const uint OSS_DATA_ERROR = 0x80093005;

		/// <summary>OSS ASN.1 Error: Invalid argument.</summary>
		public const uint OSS_BAD_ARG = 0x80093006;

		/// <summary>OSS ASN.1 Error: Encode/Decode version mismatch.</summary>
		public const uint OSS_BAD_VERSION = 0x80093007;

		/// <summary>OSS ASN.1 Error: Out of memory.</summary>
		public const uint OSS_OUT_MEMORY = 0x80093008;

		/// <summary>OSS ASN.1 Error: Encode/Decode error.</summary>
		public const uint OSS_PDU_MISMATCH = 0x80093009;

		/// <summary>OSS ASN.1 Error: Internal error.</summary>
		public const uint OSS_LIMITED = 0x8009300A;

		/// <summary>OSS ASN.1 Error: Invalid data.</summary>
		public const uint OSS_BAD_PTR = 0x8009300B;

		/// <summary>OSS ASN.1 Error: Invalid data.</summary>
		public const uint OSS_BAD_TIME = 0x8009300C;

		/// <summary>OSS ASN.1 Error: Unsupported BER indefinite-length encoding.</summary>
		public const uint OSS_INDEFINITE_NOT_SUPPORTED = 0x8009300D;

		/// <summary>OSS ASN.1 Error: Access violation.</summary>
		public const uint OSS_MEM_ERROR = 0x8009300E;

		/// <summary>OSS ASN.1 Error: Invalid data.</summary>
		public const uint OSS_BAD_TABLE = 0x8009300F;

		/// <summary>OSS ASN.1 Error: Invalid data.</summary>
		public const uint OSS_TOO_LONG = 0x80093010;

		/// <summary>OSS ASN.1 Error: Invalid data.</summary>
		public const uint OSS_CONSTRAINT_VIOLATED = 0x80093011;

		/// <summary>OSS ASN.1 Error: Internal error.</summary>
		public const uint OSS_FATAL_ERROR = 0x80093012;

		/// <summary>OSS ASN.1 Error: Multithreading conflict.</summary>
		public const uint OSS_ACCESS_SERIALIZATION_ERROR = 0x80093013;

		/// <summary>OSS ASN.1 Error: Invalid data.</summary>
		public const uint OSS_NULL_TBL = 0x80093014;

		/// <summary>OSS ASN.1 Error: Invalid data.</summary>
		public const uint OSS_NULL_FCN = 0x80093015;

		/// <summary>OSS ASN.1 Error: Invalid data.</summary>
		public const uint OSS_BAD_ENCRULES = 0x80093016;

		/// <summary>OSS ASN.1 Error: Encode/Decode function not implemented.</summary>
		public const uint OSS_UNAVAIL_ENCRULES = 0x80093017;

		/// <summary>OSS ASN.1 Error: Trace file error.</summary>
		public const uint OSS_CANT_OPEN_TRACE_WINDOW = 0x80093018;

		/// <summary>OSS ASN.1 Error: Function not implemented.</summary>
		public const uint OSS_UNIMPLEMENTED = 0x80093019;

		/// <summary>OSS ASN.1 Error: Program link error.</summary>
		public const uint OSS_OID_DLL_NOT_LINKED = 0x8009301A;

		/// <summary>OSS ASN.1 Error: Trace file error.</summary>
		public const uint OSS_CANT_OPEN_TRACE_FILE = 0x8009301B;

		/// <summary>OSS ASN.1 Error: Trace file error.</summary>
		public const uint OSS_TRACE_FILE_ALREADY_OPEN = 0x8009301C;

		/// <summary>OSS ASN.1 Error: Invalid data.</summary>
		public const uint OSS_TABLE_MISMATCH = 0x8009301D;

		/// <summary>OSS ASN.1 Error: Invalid data.</summary>
		public const uint OSS_TYPE_NOT_SUPPORTED = 0x8009301E;

		/// <summary>OSS ASN.1 Error: Program link error.</summary>
		public const uint OSS_REAL_DLL_NOT_LINKED = 0x8009301F;

		/// <summary>OSS ASN.1 Error: Program link error.</summary>
		public const uint OSS_REAL_CODE_NOT_LINKED = 0x80093020;

		/// <summary>OSS ASN.1 Error: Program link error.</summary>
		public const uint OSS_OUT_OF_RANGE = 0x80093021;

		/// <summary>OSS ASN.1 Error: Program link error.</summary>
		public const uint OSS_COPIER_DLL_NOT_LINKED = 0x80093022;

		/// <summary>OSS ASN.1 Error: Program link error.</summary>
		public const uint OSS_CONSTRAINT_DLL_NOT_LINKED = 0x80093023;

		/// <summary>OSS ASN.1 Error: Program link error.</summary>
		public const uint OSS_COMPARATOR_DLL_NOT_LINKED = 0x80093024;

		/// <summary>OSS ASN.1 Error: Program link error.</summary>
		public const uint OSS_COMPARATOR_CODE_NOT_LINKED = 0x80093025;

		/// <summary>OSS ASN.1 Error: Program link error.</summary>
		public const uint OSS_MEM_MGR_DLL_NOT_LINKED = 0x80093026;

		/// <summary>OSS ASN.1 Error: Program link error.</summary>
		public const uint OSS_PDV_DLL_NOT_LINKED = 0x80093027;

		/// <summary>OSS ASN.1 Error: Program link error.</summary>
		public const uint OSS_PDV_CODE_NOT_LINKED = 0x80093028;

		/// <summary>OSS ASN.1 Error: Program link error.</summary>
		public const uint OSS_API_DLL_NOT_LINKED = 0x80093029;

		/// <summary>OSS ASN.1 Error: Program link error.</summary>
		public const uint OSS_BERDER_DLL_NOT_LINKED = 0x8009302A;

		/// <summary>OSS ASN.1 Error: Program link error.</summary>
		public const uint OSS_PER_DLL_NOT_LINKED = 0x8009302B;

		/// <summary>OSS ASN.1 Error: Program link error.</summary>
		public const uint OSS_OPEN_TYPE_ERROR = 0x8009302C;

		/// <summary>OSS ASN.1 Error: System resource error.</summary>
		public const uint OSS_MUTEX_NOT_CREATED = 0x8009302D;

		/// <summary>OSS ASN.1 Error: Trace file error.</summary>
		public const uint OSS_CANT_CLOSE_TRACE_FILE = 0x8009302E;

		/// <summary>ASN1 Certificate encode/decode error code base.</summary>
		public const uint CRYPT_E_ASN1_ERROR = 0x80093100;

		/// <summary>ASN1 internal encode or decode error.</summary>
		public const uint CRYPT_E_ASN1_INTERNAL = 0x80093101;

		/// <summary>ASN1 unexpected end of data.</summary>
		public const uint CRYPT_E_ASN1_EOD = 0x80093102;

		/// <summary>ASN1 corrupted data.</summary>
		public const uint CRYPT_E_ASN1_CORRUPT = 0x80093103;

		/// <summary>ASN1 value too large.</summary>
		public const uint CRYPT_E_ASN1_LARGE = 0x80093104;

		/// <summary>ASN1 constraint violated.</summary>
		public const uint CRYPT_E_ASN1_CONSTRAINT = 0x80093105;

		/// <summary>ASN1 out of memory.</summary>
		public const uint CRYPT_E_ASN1_MEMORY = 0x80093106;

		/// <summary>ASN1 buffer overflow.</summary>
		public const uint CRYPT_E_ASN1_OVERFLOW = 0x80093107;

		/// <summary>ASN1 function not supported for this protocol data unit (PDU).</summary>
		public const uint CRYPT_E_ASN1_BADPDU = 0x80093108;

		/// <summary>ASN1 bad arguments to function call.</summary>
		public const uint CRYPT_E_ASN1_BADARGS = 0x80093109;

		/// <summary>ASN1 bad real value.</summary>
		public const uint CRYPT_E_ASN1_BADREAL = 0x8009310A;

		/// <summary>ASN1 bad tag value met.</summary>
		public const uint CRYPT_E_ASN1_BADTAG = 0x8009310B;

		/// <summary>ASN1 bad choice value.</summary>
		public const uint CRYPT_E_ASN1_CHOICE = 0x8009310C;

		/// <summary>ASN1 bad encoding rule.</summary>
		public const uint CRYPT_E_ASN1_RULE = 0x8009310D;

		/// <summary>ASN1 bad Unicode (UTF8).</summary>
		public const uint CRYPT_E_ASN1_UTF8 = 0x8009310E;

		/// <summary>ASN1 bad PDU type.</summary>
		public const uint CRYPT_E_ASN1_PDU_TYPE = 0x80093133;

		/// <summary>ASN1 not yet implemented.</summary>
		public const uint CRYPT_E_ASN1_NYI = 0x80093134;

		/// <summary>ASN1 skipped unknown extensions.</summary>
		public const uint CRYPT_E_ASN1_EXTENDED = 0x80093201;

		/// <summary>ASN1 end of data expected.</summary>
		public const uint CRYPT_E_ASN1_NOEOD = 0x80093202;

		/// <summary>The request subject name is invalid or too long.</summary>
		public const uint CERTSRV_E_BAD_REQUESTSUBJECT = 0x80094001;

		/// <summary>The request does not exist.</summary>
		public const uint CERTSRV_E_NO_REQUEST = 0x80094002;

		/// <summary>The request's current status does not allow this operation.</summary>
		public const uint CERTSRV_E_BAD_REQUESTSTATUS = 0x80094003;

		/// <summary>The requested property value is empty.</summary>
		public const uint CERTSRV_E_PROPERTY_EMPTY = 0x80094004;

		/// <summary>The CA's certificate contains invalid data.</summary>
		public const uint CERTSRV_E_INVALID_CA_CERTIFICATE = 0x80094005;

		/// <summary>Certificate service has been suspended for a database restore operation.</summary>
		public const uint CERTSRV_E_SERVER_SUSPENDED = 0x80094006;

		/// <summary>The certificate contains an encoded length that is potentially incompatible with older enrollment software.</summary>
		public const uint CERTSRV_E_ENCODING_LENGTH = 0x80094007;

		/// <summary>The operation is denied. The user has multiple roles assigned, and the CA is configured to enforce role separation.</summary>
		public const uint CERTSRV_E_ROLECONFLICT = 0x80094008;

		/// <summary>The operation is denied. It can only be performed by a certificate manager that is allowed to manage certificates for the current requester.</summary>
		public const uint CERTSRV_E_RESTRICTEDOFFICER = 0x80094009;

		/// <summary>Cannot archive private key. The CA is not configured for key archival.</summary>
		public const uint CERTSRV_E_KEY_ARCHIVAL_NOT_CONFIGURED = 0x8009400A;

		/// <summary>Cannot archive private key. The CA could not verify one or more key recovery certificates.</summary>
		public const uint CERTSRV_E_NO_VALID_KRA = 0x8009400B;

		/// <summary>The request is incorrectly formatted. The encrypted private key must be in an unauthenticated attribute in an outermost signature.</summary>
		public const uint CERTSRV_E_BAD_REQUEST_KEY_ARCHIVAL = 0x8009400C;

		/// <summary>At least one security principal must have the permission to manage this CA.</summary>
		public const uint CERTSRV_E_NO_CAADMIN_DEFINED = 0x8009400D;

		/// <summary>The request contains an invalid renewal certificate attribute.</summary>
		public const uint CERTSRV_E_BAD_RENEWAL_CERT_ATTRIBUTE = 0x8009400E;

		/// <summary>An attempt was made to open a CA database session, but there are already too many active sessions. The server needs to be configured to allow additional sessions.</summary>
		public const uint CERTSRV_E_NO_DB_SESSIONS = 0x8009400F;

		/// <summary>A memory reference caused a data alignment fault.</summary>
		public const uint CERTSRV_E_ALIGNMENT_FAULT = 0x80094010;

		/// <summary>The permissions on this CA do not allow the current user to enroll for certificates.</summary>
		public const uint CERTSRV_E_ENROLL_DENIED = 0x80094011;

		/// <summary>The permissions on the certificate template do not allow the current user to enroll for this type of certificate.</summary>
		public const uint CERTSRV_E_TEMPLATE_DENIED = 0x80094012;

		/// <summary>The contacted domain controller cannot support signed Lightweight Directory Access Protocol (LDAP) traffic. Update the domain controller or configure Certificate Services to use SSL for Active Directory access.</summary>
		public const uint CERTSRV_E_DOWNLEVEL_DC_SSL_OR_UPGRADE = 0x80094013;

		/// <summary>The requested certificate template is not supported by this CA.</summary>
		public const uint CERTSRV_E_UNSUPPORTED_CERT_TYPE = 0x80094800;

		/// <summary>The request contains no certificate template information.</summary>
		public const uint CERTSRV_E_NO_CERT_TYPE = 0x80094801;

		/// <summary>The request contains conflicting template information.</summary>
		public const uint CERTSRV_E_TEMPLATE_CONFLICT = 0x80094802;

		/// <summary>The request is missing a required Subject Alternate name extension.</summary>
		public const uint CERTSRV_E_SUBJECT_ALT_NAME_REQUIRED = 0x80094803;

		/// <summary>The request is missing a required private key for archival by the server.</summary>
		public const uint CERTSRV_E_ARCHIVED_KEY_REQUIRED = 0x80094804;

		/// <summary>The request is missing a required SMIME capabilities extension.</summary>
		public const uint CERTSRV_E_SMIME_REQUIRED = 0x80094805;

		/// <summary>The request was made on behalf of a subject other than the caller. The certificate template must be configured to require at least one signature to authorize the request.</summary>
		public const uint CERTSRV_E_BAD_RENEWAL_SUBJECT = 0x80094806;

		/// <summary>The request template version is newer than the supported template version.</summary>
		public const uint CERTSRV_E_BAD_TEMPLATE_VERSION = 0x80094807;

		/// <summary>The template is missing a required signature policy attribute.</summary>
		public const uint CERTSRV_E_TEMPLATE_POLICY_REQUIRED = 0x80094808;

		/// <summary>The request is missing required signature policy information.</summary>
		public const uint CERTSRV_E_SIGNATURE_POLICY_REQUIRED = 0x80094809;

		/// <summary>The request is missing one or more required signatures.</summary>
		public const uint CERTSRV_E_SIGNATURE_COUNT = 0x8009480A;

		/// <summary>One or more signatures did not include the required application or issuance policies. The request is missing one or more required valid signatures.</summary>
		public const uint CERTSRV_E_SIGNATURE_REJECTED = 0x8009480B;

		/// <summary>The request is missing one or more required signature issuance policies.</summary>
		public const uint CERTSRV_E_ISSUANCE_POLICY_REQUIRED = 0x8009480C;

		/// <summary>The UPN is unavailable and cannot be added to the Subject Alternate name.</summary>
		public const uint CERTSRV_E_SUBJECT_UPN_REQUIRED = 0x8009480D;

		/// <summary>The Active Directory GUID is unavailable and cannot be added to the Subject Alternate name.</summary>
		public const uint CERTSRV_E_SUBJECT_DIRECTORY_GUID_REQUIRED = 0x8009480E;

		/// <summary>The Domain Name System (DNS) name is unavailable and cannot be added to the Subject Alternate name.</summary>
		public const uint CERTSRV_E_SUBJECT_DNS_REQUIRED = 0x8009480F;

		/// <summary>The request includes a private key for archival by the server, but key archival is not enabled for the specified certificate template.</summary>
		public const uint CERTSRV_E_ARCHIVED_KEY_UNEXPECTED = 0x80094810;

		/// <summary>The public key does not meet the minimum size required by the specified certificate template.</summary>
		public const uint CERTSRV_E_KEY_LENGTH = 0x80094811;

		/// <summary>The email name is unavailable and cannot be added to the Subject or Subject Alternate name.</summary>
		public const uint CERTSRV_E_SUBJECT_EMAIL_REQUIRED = 0x80094812;

		/// <summary>One or more certificate templates to be enabled on this CA could not be found.</summary>
		public const uint CERTSRV_E_UNKNOWN_CERT_TYPE = 0x80094813;

		/// <summary>The certificate template renewal period is longer than the certificate validity period. The template should be reconfigured or the CA certificate renewed.</summary>
		public const uint CERTSRV_E_CERT_TYPE_OVERLAP = 0x80094814;

		/// <summary>The certificate template requires too many return authorization (RA) signatures. Only one RA signature is allowed.</summary>
		public const uint CERTSRV_E_TOO_MANY_SIGNATURES = 0x80094815;

		/// <summary>The key used in a renewal request does not match one of the certificates being renewed.</summary>
		public const uint CERTSRV_E_RENEWAL_BAD_PUBLIC_KEY = 0x80094816;

		/// <summary>The endorsement key certificate is not valid.</summary>
		public const uint CERTSRV_E_INVALID_EK = 0x80094817;

		/// <summary>Key attestation did not succeed.</summary>
		public const uint CERTSRV_E_KEY_ATTESTATION = 0x8009481A;

		/// <summary>The key is not exportable.</summary>
		public const uint XENROLL_E_KEY_NOT_EXPORTABLE = 0x80095000;

		/// <summary>You cannot add the root CA certificate into your local store.</summary>
		public const uint XENROLL_E_CANNOT_ADD_ROOT_CERT = 0x80095001;

		/// <summary>The key archival hash attribute was not found in the response.</summary>
		public const uint XENROLL_E_RESPONSE_KA_HASH_NOT_FOUND = 0x80095002;

		/// <summary>An unexpected key archival hash attribute was found in the response.</summary>
		public const uint XENROLL_E_RESPONSE_UNEXPECTED_KA_HASH = 0x80095003;

		/// <summary>There is a key archival hash mismatch between the request and the response.</summary>
		public const uint XENROLL_E_RESPONSE_KA_HASH_MISMATCH = 0x80095004;

		/// <summary>Signing certificate cannot include SMIME extension.</summary>
		public const uint XENROLL_E_KEYSPEC_SMIME_MISMATCH = 0x80095005;

		/// <summary>A system-level error occurred while verifying trust.</summary>
		public const uint TRUST_E_SYSTEM_ERROR = 0x80096001;

		/// <summary>The certificate for the signer of the message is invalid or not found.</summary>
		public const uint TRUST_E_NO_SIGNER_CERT = 0x80096002;

		/// <summary>One of the counter signatures was invalid.</summary>
		public const uint TRUST_E_COUNTER_SIGNER = 0x80096003;

		/// <summary>The signature of the certificate cannot be verified.</summary>
		public const uint TRUST_E_CERT_SIGNATURE = 0x80096004;

		/// <summary>The time-stamp signature or certificate could not be verified or is malformed.</summary>
		public const uint TRUST_E_TIME_STAMP = 0x80096005;

		/// <summary>The digital signature of the object did not verify.</summary>
		public const uint TRUST_E_BAD_DIGEST = 0x80096010;

		/// <summary>A certificate's basic constraint extension has not been observed.</summary>
		public const uint TRUST_E_BASIC_CONSTRAINTS = 0x80096019;

		/// <summary>The certificate does not meet or contain the Authenticode financial extensions.</summary>
		public const uint TRUST_E_FINANCIAL_CRITERIA = 0x8009601E;

		/// <summary>Tried to reference a part of the file outside the proper range.</summary>
		public const uint MSSIPOTF_E_OUTOFMEMRANGE = 0x80097001;

		/// <summary>Could not retrieve an object from the file.</summary>
		public const uint MSSIPOTF_E_CANTGETOBJECT = 0x80097002;

		/// <summary>Could not find the head table in the file.</summary>
		public const uint MSSIPOTF_E_NOHEADTABLE = 0x80097003;

		/// <summary>The magic number in the head table is incorrect.</summary>
		public const uint MSSIPOTF_E_BAD_MAGICNUMBER = 0x80097004;

		/// <summary>The offset table has incorrect values.</summary>
		public const uint MSSIPOTF_E_BAD_OFFSET_TABLE = 0x80097005;

		/// <summary>Duplicate table tags or the tags are out of alphabetical order.</summary>
		public const uint MSSIPOTF_E_TABLE_TAGORDER = 0x80097006;

		/// <summary>A table does not start on a long word boundary.</summary>
		public const uint MSSIPOTF_E_TABLE_LONGWORD = 0x80097007;

		/// <summary>First table does not appear after header information.</summary>
		public const uint MSSIPOTF_E_BAD_FIRST_TABLE_PLACEMENT = 0x80097008;

		/// <summary>Two or more tables overlap.</summary>
		public const uint MSSIPOTF_E_TABLES_OVERLAP = 0x80097009;

		/// <summary>Too many pad bytes between tables, or pad bytes are not 0.</summary>
		public const uint MSSIPOTF_E_TABLE_PADBYTES = 0x8009700A;

		/// <summary>File is too small to contain the last table.</summary>
		public const uint MSSIPOTF_E_FILETOOSMALL = 0x8009700B;

		/// <summary>A table checksum is incorrect.</summary>
		public const uint MSSIPOTF_E_TABLE_CHECKSUM = 0x8009700C;

		/// <summary>The file checksum is incorrect.</summary>
		public const uint MSSIPOTF_E_FILE_CHECKSUM = 0x8009700D;

		/// <summary>The signature does not have the correct attributes for the policy.</summary>
		public const uint MSSIPOTF_E_FAILED_POLICY = 0x80097010;

		/// <summary>The file did not pass the hints check.</summary>
		public const uint MSSIPOTF_E_FAILED_HINTS_CHECK = 0x80097011;

		/// <summary>The file is not an OpenType file.</summary>
		public const uint MSSIPOTF_E_NOT_OPENTYPE = 0x80097012;

		/// <summary>Failed on a file operation (such as open, map, read, or write).</summary>
		public const uint MSSIPOTF_E_FILE = 0x80097013;

		/// <summary>A call to a CryptoAPI function failed.</summary>
		public const uint MSSIPOTF_E_CRYPT = 0x80097014;

		/// <summary>There is a bad version number in the file.</summary>
		public const uint MSSIPOTF_E_BADVERSION = 0x80097015;

		/// <summary>The structure of the DSIG table is incorrect.</summary>
		public const uint MSSIPOTF_E_DSIG_STRUCTURE = 0x80097016;

		/// <summary>A check failed in a partially constant table.</summary>
		public const uint MSSIPOTF_E_PCONST_CHECK = 0x80097017;

		/// <summary>Some kind of structural error.</summary>
		public const uint MSSIPOTF_E_STRUCTURE = 0x80097018;

		/// <summary>The requested credential requires confirmation.</summary>
		public const uint ERROR_CRED_REQUIRES_CONFIRMATION = 0x80097019;

		/// <summary>Unknown trust provider.</summary>
		public const uint TRUST_E_PROVIDER_UNKNOWN = 0x800B0001;

		/// <summary>The trust verification action specified is not supported by the specified trust provider.</summary>
		public const uint TRUST_E_ACTION_UNKNOWN = 0x800B0002;

		/// <summary>The form specified for the subject is not one supported or known by the specified trust provider.</summary>
		public const uint TRUST_E_SUBJECT_FORM_UNKNOWN = 0x800B0003;

		/// <summary>The subject is not trusted for the specified action.</summary>
		public const uint TRUST_E_SUBJECT_NOT_TRUSTED = 0x800B0004;

		/// <summary>Error due to problem in ASN.1 encoding process.</summary>
		public const uint DIGSIG_E_ENCODE = 0x800B0005;

		/// <summary>Error due to problem in ASN.1 decoding process.</summary>
		public const uint DIGSIG_E_DECODE = 0x800B0006;

		/// <summary>Reading/writing extensions where attributes are appropriate, and vice versa.</summary>
		public const uint DIGSIG_E_EXTENSIBILITY = 0x800B0007;

		/// <summary>Unspecified cryptographic failure.</summary>
		public const uint DIGSIG_E_CRYPTO = 0x800B0008;

		/// <summary>The size of the data could not be determined.</summary>
		public const uint PERSIST_E_SIZEDEFINITE = 0x800B0009;

		/// <summary>The size of the indefinite-sized data could not be determined.</summary>
		public const uint PERSIST_E_SIZEINDEFINITE = 0x800B000A;

		/// <summary>This object does not read and write self-sizing data.</summary>
		public const uint PERSIST_E_NOTSELFSIZING = 0x800B000B;

		/// <summary>No signature was present in the subject.</summary>
		public const uint TRUST_E_NOSIGNATURE = 0x800B0100;

		/// <summary>A required certificate is not within its validity period when verifying against the current system clock or the time stamp in the signed file.</summary>
		public const uint CERT_E_EXPIRED = 0x800B0101;

		/// <summary>The validity periods of the certification chain do not nest correctly.</summary>
		public const uint CERT_E_VALIDITYPERIODNESTING = 0x800B0102;

		/// <summary>A certificate that can only be used as an end entity is being used as a CA or vice versa.</summary>
		public const uint CERT_E_ROLE = 0x800B0103;

		/// <summary>A path length constraint in the certification chain has been violated.</summary>
		public const uint CERT_E_PATHLENCONST = 0x800B0104;

		/// <summary>A certificate contains an unknown extension that is marked "critical".</summary>
		public const uint CERT_E_CRITICAL = 0x800B0105;

		/// <summary>A certificate is being used for a purpose other than the ones specified by its CA.</summary>
		public const uint CERT_E_PURPOSE = 0x800B0106;

		/// <summary>A parent of a given certificate did not issue that child certificate.</summary>
		public const uint CERT_E_ISSUERCHAINING = 0x800B0107;

		/// <summary>A certificate is missing or has an empty value for an important field, such as a subject or issuer name.</summary>
		public const uint CERT_E_MALFORMED = 0x800B0108;

		/// <summary>A certificate chain processed, but terminated in a root certificate that is not trusted by the trust provider.</summary>
		public const uint CERT_E_UNTRUSTEDROOT = 0x800B0109;

		/// <summary>A certificate chain could not be built to a trusted root authority.</summary>
		public const uint CERT_E_CHAINING = 0x800B010A;

		/// <summary>Generic trust failure.</summary>
		public const uint TRUST_E_FAIL = 0x800B010B;

		/// <summary>A certificate was explicitly revoked by its issuer.</summary>
		public const uint CERT_E_REVOKED = 0x800B010C;

		/// <summary>The certification path terminates with the test root that is not trusted with the current policy settings.</summary>
		public const uint CERT_E_UNTRUSTEDTESTROOT = 0x800B010D;

		/// <summary>The revocation process could not continue—the certificates could not be checked.</summary>
		public const uint CERT_E_REVOCATION_FAILURE = 0x800B010E;

		/// <summary>The certificate's CN name does not match the passed value.</summary>
		public const uint CERT_E_CN_NO_MATCH = 0x800B010F;

		/// <summary>The certificate is not valid for the requested usage.</summary>
		public const uint CERT_E_WRONG_USAGE = 0x800B0110;

		/// <summary>The certificate was explicitly marked as untrusted by the user.</summary>
		public const uint TRUST_E_EXPLICIT_DISTRUST = 0x800B0111;

		/// <summary>A certification chain processed correctly, but one of the CA certificates is not trusted by the policy provider.</summary>
		public const uint CERT_E_UNTRUSTEDCA = 0x800B0112;

		/// <summary>The certificate has invalid policy.</summary>
		public const uint CERT_E_INVALID_POLICY = 0x800B0113;

		/// <summary>The certificate has an invalid name. The name is not included in the permitted list or is explicitly excluded.</summary>
		public const uint CERT_E_INVALID_NAME = 0x800B0114;

		/// <summary>The maximum filebitrate value specified is greater than the server's configured maximum bandwidth.</summary>
		public const uint NS_W_SERVER_BANDWIDTH_LIMIT = 0x800D0003;

		/// <summary>The maximum bandwidth value specified is less than the maximum filebitrate.</summary>
		public const uint NS_W_FILE_BANDWIDTH_LIMIT = 0x800D0004;

		/// <summary>Unknown %1 event encountered.</summary>
		public const uint NS_W_UNKNOWN_EVENT = 0x800D0060;

		/// <summary>Disk %1 ( %2 ) on Content Server %3, will be failed because it is catatonic.</summary>
		public const uint NS_I_CATATONIC_FAILURE = 0x800D0199;

		/// <summary>Disk %1 ( %2 ) on Content Server %3, auto online from catatonic state.</summary>
		public const uint NS_I_CATATONIC_AUTO_UNFAIL = 0x800D019A;

		/// <summary>A non-empty line was encountered in the INF before the start of a section.</summary>
		public const uint SPAPI_E_EXPECTED_SECTION_NAME = 0x800F0000;

		/// <summary>A section name marker in the information file (INF) is not complete or does not exist on a line by itself.</summary>
		public const uint SPAPI_E_BAD_SECTION_NAME_LINE = 0x800F0001;

		/// <summary>An INF section was encountered whose name exceeds the maximum section name length.</summary>
		public const uint SPAPI_E_SECTION_NAME_TOO_LONG = 0x800F0002;

		/// <summary>The syntax of the INF is invalid.</summary>
		public const uint SPAPI_E_GENERAL_SYNTAX = 0x800F0003;

		/// <summary>The style of the INF is different than what was requested.</summary>
		public const uint SPAPI_E_WRONG_INF_STYLE = 0x800F0100;

		/// <summary>The required section was not found in the INF.</summary>
		public const uint SPAPI_E_SECTION_NOT_FOUND = 0x800F0101;

		/// <summary>The required line was not found in the INF.</summary>
		public const uint SPAPI_E_LINE_NOT_FOUND = 0x800F0102;

		/// <summary>The files affected by the installation of this file queue have not been backed up for uninstall.</summary>
		public const uint SPAPI_E_NO_BACKUP = 0x800F0103;

		/// <summary>The INF or the device information set or element does not have an associated install class.</summary>
		public const uint SPAPI_E_NO_ASSOCIATED_CLASS = 0x800F0200;

		/// <summary>The INF or the device information set or element does not match the specified install class.</summary>
		public const uint SPAPI_E_CLASS_MISMATCH = 0x800F0201;

		/// <summary>An existing device was found that is a duplicate of the device being manually installed.</summary>
		public const uint SPAPI_E_DUPLICATE_FOUND = 0x800F0202;

		/// <summary>There is no driver selected for the device information set or element.</summary>
		public const uint SPAPI_E_NO_DRIVER_SELECTED = 0x800F0203;

		/// <summary>The requested device registry key does not exist.</summary>
		public const uint SPAPI_E_KEY_DOES_NOT_EXIST = 0x800F0204;

		/// <summary>The device instance name is invalid.</summary>
		public const uint SPAPI_E_INVALID_DEVINST_NAME = 0x800F0205;

		/// <summary>The install class is not present or is invalid.</summary>
		public const uint SPAPI_E_INVALID_CLASS = 0x800F0206;

		/// <summary>The device instance cannot be created because it already exists.</summary>
		public const uint SPAPI_E_DEVINST_ALREADY_EXISTS = 0x800F0207;

		/// <summary>The operation cannot be performed on a device information element that has not been registered.</summary>
		public const uint SPAPI_E_DEVINFO_NOT_REGISTERED = 0x800F0208;

		/// <summary>The device property code is invalid.</summary>
		public const uint SPAPI_E_INVALID_REG_PROPERTY = 0x800F0209;

		/// <summary>The INF from which a driver list is to be built does not exist.</summary>
		public const uint SPAPI_E_NO_INF = 0x800F020A;

		/// <summary>The device instance does not exist in the hardware tree.</summary>
		public const uint SPAPI_E_NO_SUCH_DEVINST = 0x800F020B;

		/// <summary>The icon representing this install class cannot be loaded.</summary>
		public const uint SPAPI_E_CANT_LOAD_CLASS_ICON = 0x800F020C;

		/// <summary>The class installer registry entry is invalid.</summary>
		public const uint SPAPI_E_INVALID_CLASS_INSTALLER = 0x800F020D;

		/// <summary>The class installer has indicated that the default action should be performed for this installation request.</summary>
		public const uint SPAPI_E_DI_DO_DEFAULT = 0x800F020E;

		/// <summary>The operation does not require any files to be copied.</summary>
		public const uint SPAPI_E_DI_NOFILECOPY = 0x800F020F;

		/// <summary>The specified hardware profile does not exist.</summary>
		public const uint SPAPI_E_INVALID_HWPROFILE = 0x800F0210;

		/// <summary>There is no device information element currently selected for this device information set.</summary>
		public const uint SPAPI_E_NO_DEVICE_SELECTED = 0x800F0211;

		/// <summary>The operation cannot be performed because the device information set is locked.</summary>
		public const uint SPAPI_E_DEVINFO_LIST_LOCKED = 0x800F0212;

		/// <summary>The operation cannot be performed because the device information element is locked.</summary>
		public const uint SPAPI_E_DEVINFO_DATA_LOCKED = 0x800F0213;

		/// <summary>The specified path does not contain any applicable device INFs.</summary>
		public const uint SPAPI_E_DI_BAD_PATH = 0x800F0214;

		/// <summary>No class installer parameters have been set for the device information set or element.</summary>
		public const uint SPAPI_E_NO_CLASSINSTALL_PARAMS = 0x800F0215;

		/// <summary>The operation cannot be performed because the file queue is locked.</summary>
		public const uint SPAPI_E_FILEQUEUE_LOCKED = 0x800F0216;

		/// <summary>A service installation section in this INF is invalid.</summary>
		public const uint SPAPI_E_BAD_SERVICE_INSTALLSECT = 0x800F0217;

		/// <summary>There is no class driver list for the device information element.</summary>
		public const uint SPAPI_E_NO_CLASS_DRIVER_LIST = 0x800F0218;

		/// <summary>The installation failed because a function driver was not specified for this device instance.</summary>
		public const uint SPAPI_E_NO_ASSOCIATED_SERVICE = 0x800F0219;

		/// <summary>There is presently no default device interface designated for this interface class.</summary>
		public const uint SPAPI_E_NO_DEFAULT_DEVICE_INTERFACE = 0x800F021A;

		/// <summary>The operation cannot be performed because the device interface is currently active.</summary>
		public const uint SPAPI_E_DEVICE_INTERFACE_ACTIVE = 0x800F021B;

		/// <summary>The operation cannot be performed because the device interface has been removed from the system.</summary>
		public const uint SPAPI_E_DEVICE_INTERFACE_REMOVED = 0x800F021C;

		/// <summary>An interface installation section in this INF is invalid.</summary>
		public const uint SPAPI_E_BAD_INTERFACE_INSTALLSECT = 0x800F021D;

		/// <summary>This interface class does not exist in the system.</summary>
		public const uint SPAPI_E_NO_SUCH_INTERFACE_CLASS = 0x800F021E;

		/// <summary>The reference string supplied for this interface device is invalid.</summary>
		public const uint SPAPI_E_INVALID_REFERENCE_STRING = 0x800F021F;

		/// <summary>The specified machine name does not conform to Universal Naming Convention (UNCs).</summary>
		public const uint SPAPI_E_INVALID_MACHINENAME = 0x800F0220;

		/// <summary>A general remote communication error occurred.</summary>
		public const uint SPAPI_E_REMOTE_COMM_FAILURE = 0x800F0221;

		/// <summary>The machine selected for remote communication is not available at this time.</summary>
		public const uint SPAPI_E_MACHINE_UNAVAILABLE = 0x800F0222;

		/// <summary>The Plug and Play service is not available on the remote machine.</summary>
		public const uint SPAPI_E_NO_CONFIGMGR_SERVICES = 0x800F0223;

		/// <summary>The property page provider registry entry is invalid.</summary>
		public const uint SPAPI_E_INVALID_PROPPAGE_PROVIDER = 0x800F0224;

		/// <summary>The requested device interface is not present in the system.</summary>
		public const uint SPAPI_E_NO_SUCH_DEVICE_INTERFACE = 0x800F0225;

		/// <summary>The device's co-installer has additional work to perform after installation is complete.</summary>
		public const uint SPAPI_E_DI_POSTPROCESSING_REQUIRED = 0x800F0226;

		/// <summary>The device's co-installer is invalid.</summary>
		public const uint SPAPI_E_INVALID_COINSTALLER = 0x800F0227;

		/// <summary>There are no compatible drivers for this device.</summary>
		public const uint SPAPI_E_NO_COMPAT_DRIVERS = 0x800F0228;

		/// <summary>There is no icon that represents this device or device type.</summary>
		public const uint SPAPI_E_NO_DEVICE_ICON = 0x800F0229;

		/// <summary>A logical configuration specified in this INF is invalid.</summary>
		public const uint SPAPI_E_INVALID_INF_LOGCONFIG = 0x800F022A;

		/// <summary>The class installer has denied the request to install or upgrade this device.</summary>
		public const uint SPAPI_E_DI_DONT_INSTALL = 0x800F022B;

		/// <summary>One of the filter drivers installed for this device is invalid.</summary>
		public const uint SPAPI_E_INVALID_FILTER_DRIVER = 0x800F022C;

		/// <summary>The driver selected for this device does not support Windows XP operating system.</summary>
		public const uint SPAPI_E_NON_WINDOWS_NT_DRIVER = 0x800F022D;

		/// <summary>The driver selected for this device does not support Windows.</summary>
		public const uint SPAPI_E_NON_WINDOWS_DRIVER = 0x800F022E;

		/// <summary>The third-party INF does not contain digital signature information.</summary>
		public const uint SPAPI_E_NO_CATALOG_FOR_OEM_INF = 0x800F022F;

		/// <summary>An invalid attempt was made to use a device installation file queue for verification of digital signatures relative to other platforms.</summary>
		public const uint SPAPI_E_DEVINSTALL_QUEUE_NONNATIVE = 0x800F0230;

		/// <summary>The device cannot be disabled.</summary>
		public const uint SPAPI_E_NOT_DISABLEABLE = 0x800F0231;

		/// <summary>The device could not be dynamically removed.</summary>
		public const uint SPAPI_E_CANT_REMOVE_DEVINST = 0x800F0232;

		/// <summary>Cannot copy to specified target.</summary>
		public const uint SPAPI_E_INVALID_TARGET = 0x800F0233;

		/// <summary>Driver is not intended for this platform.</summary>
		public const uint SPAPI_E_DRIVER_NONNATIVE = 0x800F0234;

		/// <summary>Operation not allowed in WOW64.</summary>
		public const uint SPAPI_E_IN_WOW64 = 0x800F0235;

		/// <summary>The operation involving unsigned file copying was rolled back, so that a system restore point could be set.</summary>
		public const uint SPAPI_E_SET_SYSTEM_RESTORE_POINT = 0x800F0236;

		/// <summary>An INF was copied into the Windows INF directory in an improper manner.</summary>
		public const uint SPAPI_E_INCORRECTLY_COPIED_INF = 0x800F0237;

		/// <summary>The Security Configuration Editor (SCE) APIs have been disabled on this embedded product.</summary>
		public const uint SPAPI_E_SCE_DISABLED = 0x800F0238;

		/// <summary>An unknown exception was encountered.</summary>
		public const uint SPAPI_E_UNKNOWN_EXCEPTION = 0x800F0239;

		/// <summary>A problem was encountered when accessing the Plug and Play registry database.</summary>
		public const uint SPAPI_E_PNP_REGISTRY_ERROR = 0x800F023A;

		/// <summary>The requested operation is not supported for a remote machine.</summary>
		public const uint SPAPI_E_REMOTE_REQUEST_UNSUPPORTED = 0x800F023B;

		/// <summary>The specified file is not an installed original equipment manufacturer (OEM) INF.</summary>
		public const uint SPAPI_E_NOT_AN_INSTALLED_OEM_INF = 0x800F023C;

		/// <summary>One or more devices are presently installed using the specified INF.</summary>
		public const uint SPAPI_E_INF_IN_USE_BY_DEVICES = 0x800F023D;

		/// <summary>The requested device install operation is obsolete.</summary>
		public const uint SPAPI_E_DI_FUNCTION_OBSOLETE = 0x800F023E;

		/// <summary>A file could not be verified because it does not have an associated catalog signed via Authenticode.</summary>
		public const uint SPAPI_E_NO_AUTHENTICODE_CATALOG = 0x800F023F;

		/// <summary>Authenticode signature verification is not supported for the specified INF.</summary>
		public const uint SPAPI_E_AUTHENTICODE_DISALLOWED = 0x800F0240;

		/// <summary>The INF was signed with an Authenticode catalog from a trusted publisher.</summary>
		public const uint SPAPI_E_AUTHENTICODE_TRUSTED_PUBLISHER = 0x800F0241;

		/// <summary>The publisher of an Authenticode-signed catalog has not yet been established as trusted.</summary>
		public const uint SPAPI_E_AUTHENTICODE_TRUST_NOT_ESTABLISHED = 0x800F0242;

		/// <summary>The publisher of an Authenticode-signed catalog was not established as trusted.</summary>
		public const uint SPAPI_E_AUTHENTICODE_PUBLISHER_NOT_TRUSTED = 0x800F0243;

		/// <summary>The software was tested for compliance with Windows logo requirements on a different version of Windows and might not be compatible with this version.</summary>
		public const uint SPAPI_E_SIGNATURE_OSATTRIBUTE_MISMATCH = 0x800F0244;

		/// <summary>The file can be validated only by a catalog signed via Authenticode.</summary>
		public const uint SPAPI_E_ONLY_VALIDATE_VIA_AUTHENTICODE = 0x800F0245;

		/// <summary>One of the installers for this device cannot perform the installation at this time.</summary>
		public const uint SPAPI_E_DEVICE_INSTALLER_NOT_READY = 0x800F0246;

		/// <summary>A problem was encountered while attempting to add the driver to the store.</summary>
		public const uint SPAPI_E_DRIVER_STORE_ADD_FAILED = 0x800F0247;

		/// <summary>The installation of this device is forbidden by system policy. Contact your system administrator.</summary>
		public const uint SPAPI_E_DEVICE_INSTALL_BLOCKED = 0x800F0248;

		/// <summary>The installation of this driver is forbidden by system policy. Contact your system administrator.</summary>
		public const uint SPAPI_E_DRIVER_INSTALL_BLOCKED = 0x800F0249;

		/// <summary>The specified INF is the wrong type for this operation.</summary>
		public const uint SPAPI_E_WRONG_INF_TYPE = 0x800F024A;

		/// <summary>The hash for the file is not present in the specified catalog file. The file is likely corrupt or the victim of tampering.</summary>
		public const uint SPAPI_E_FILE_HASH_NOT_IN_CATALOG = 0x800F024B;

		/// <summary>A problem was encountered while attempting to delete the driver from the store.</summary>
		public const uint SPAPI_E_DRIVER_STORE_DELETE_FAILED = 0x800F024C;

		/// <summary>An unrecoverable stack overflow was encountered.</summary>
		public const uint SPAPI_E_UNRECOVERABLE_STACK_OVERFLOW = 0x800F0300;

		/// <summary>No installed components were detected.</summary>
		public const uint SPAPI_E_ERROR_NOT_INSTALLED = 0x800F1000;

		/// <summary>An internal consistency check failed.</summary>
		public const uint SCARD_F_INTERNAL_ERROR = 0x80100001;

		/// <summary>The action was canceled by an SCardCancel request.</summary>
		public const uint SCARD_E_CANCELLED = 0x80100002;

		/// <summary>The supplied handle was invalid.</summary>
		public const uint SCARD_E_INVALID_HANDLE = 0x80100003;

		/// <summary>One or more of the supplied parameters could not be properly interpreted.</summary>
		public const uint SCARD_E_INVALID_PARAMETER = 0x80100004;

		/// <summary>Registry startup information is missing or invalid.</summary>
		public const uint SCARD_E_INVALID_TARGET = 0x80100005;

		/// <summary>Not enough memory available to complete this command.</summary>
		public const uint SCARD_E_NO_MEMORY = 0x80100006;

		/// <summary>An internal consistency timer has expired.</summary>
		public const uint SCARD_F_WAITED_TOO_LONG = 0x80100007;

		/// <summary>The data buffer to receive returned data is too small for the returned data.</summary>
		public const uint SCARD_E_INSUFFICIENT_BUFFER = 0x80100008;

		/// <summary>The specified reader name is not recognized.</summary>
		public const uint SCARD_E_UNKNOWN_READER = 0x80100009;

		/// <summary>The user-specified time-out value has expired.</summary>
		public const uint SCARD_E_TIMEOUT = 0x8010000A;

		/// <summary>The smart card cannot be accessed because of other connections outstanding.</summary>
		public const uint SCARD_E_SHARING_VIOLATION = 0x8010000B;

		/// <summary>The operation requires a smart card, but no smart card is currently in the device.</summary>
		public const uint SCARD_E_NO_SMARTCARD = 0x8010000C;

		/// <summary>The specified smart card name is not recognized.</summary>
		public const uint SCARD_E_UNKNOWN_CARD = 0x8010000D;

		/// <summary>The system could not dispose of the media in the requested manner.</summary>
		public const uint SCARD_E_CANT_DISPOSE = 0x8010000E;

		/// <summary>The requested protocols are incompatible with the protocol currently in use with the smart card.</summary>
		public const uint SCARD_E_PROTO_MISMATCH = 0x8010000F;

		/// <summary>The reader or smart card is not ready to accept commands.</summary>
		public const uint SCARD_E_NOT_READY = 0x80100010;

		/// <summary>One or more of the supplied parameters values could not be properly interpreted.</summary>
		public const uint SCARD_E_INVALID_VALUE = 0x80100011;

		/// <summary>The action was canceled by the system, presumably to log off or shut down.</summary>
		public const uint SCARD_E_SYSTEM_CANCELLED = 0x80100012;

		/// <summary>An internal communications error has been detected.</summary>
		public const uint SCARD_F_COMM_ERROR = 0x80100013;

		/// <summary>An internal error has been detected, but the source is unknown.</summary>
		public const uint SCARD_F_UNKNOWN_ERROR = 0x80100014;

		/// <summary>An automatic terminal recognition (ATR) obtained from the registry is not a valid ATR string.</summary>
		public const uint SCARD_E_INVALID_ATR = 0x80100015;

		/// <summary>An attempt was made to end a nonexistent transaction.</summary>
		public const uint SCARD_E_NOT_TRANSACTED = 0x80100016;

		/// <summary>The specified reader is not currently available for use.</summary>
		public const uint SCARD_E_READER_UNAVAILABLE = 0x80100017;

		/// <summary>The operation has been aborted to allow the server application to exit.</summary>
		public const uint SCARD_P_SHUTDOWN = 0x80100018;

		/// <summary>The peripheral component interconnect (PCI) Receive buffer was too small.</summary>
		public const uint SCARD_E_PCI_TOO_SMALL = 0x80100019;

		/// <summary>The reader driver does not meet minimal requirements for support.</summary>
		public const uint SCARD_E_READER_UNSUPPORTED = 0x8010001A;

		/// <summary>The reader driver did not produce a unique reader name.</summary>
		public const uint SCARD_E_DUPLICATE_READER = 0x8010001B;

		/// <summary>The smart card does not meet minimal requirements for support.</summary>
		public const uint SCARD_E_CARD_UNSUPPORTED = 0x8010001C;

		/// <summary>The smart card resource manager is not running.</summary>
		public const uint SCARD_E_NO_SERVICE = 0x8010001D;

		/// <summary>The smart card resource manager has shut down.</summary>
		public const uint SCARD_E_SERVICE_STOPPED = 0x8010001E;

		/// <summary>An unexpected card error has occurred.</summary>
		public const uint SCARD_E_UNEXPECTED = 0x8010001F;

		/// <summary>No primary provider can be found for the smart card.</summary>
		public const uint SCARD_E_ICC_INSTALLATION = 0x80100020;

		/// <summary>The requested order of object creation is not supported.</summary>
		public const uint SCARD_E_ICC_CREATEORDER = 0x80100021;

		/// <summary>This smart card does not support the requested feature.</summary>
		public const uint SCARD_E_UNSUPPORTED_FEATURE = 0x80100022;

		/// <summary>The identified directory does not exist in the smart card.</summary>
		public const uint SCARD_E_DIR_NOT_FOUND = 0x80100023;

		/// <summary>The identified file does not exist in the smart card.</summary>
		public const uint SCARD_E_FILE_NOT_FOUND = 0x80100024;

		/// <summary>The supplied path does not represent a smart card directory.</summary>
		public const uint SCARD_E_NO_DIR = 0x80100025;

		/// <summary>The supplied path does not represent a smart card file.</summary>
		public const uint SCARD_E_NO_FILE = 0x80100026;

		/// <summary>Access is denied to this file.</summary>
		public const uint SCARD_E_NO_ACCESS = 0x80100027;

		/// <summary>The smart card does not have enough memory to store the information.</summary>
		public const uint SCARD_E_WRITE_TOO_MANY = 0x80100028;

		/// <summary>There was an error trying to set the smart card file object pointer.</summary>
		public const uint SCARD_E_BAD_SEEK = 0x80100029;

		/// <summary>The supplied PIN is incorrect.</summary>
		public const uint SCARD_E_INVALID_CHV = 0x8010002A;

		/// <summary>An unrecognized error code was returned from a layered component.</summary>
		public const uint SCARD_E_UNKNOWN_RES_MNG = 0x8010002B;

		/// <summary>The requested certificate does not exist.</summary>
		public const uint SCARD_E_NO_SUCH_CERTIFICATE = 0x8010002C;

		/// <summary>The requested certificate could not be obtained.</summary>
		public const uint SCARD_E_CERTIFICATE_UNAVAILABLE = 0x8010002D;

		/// <summary>Cannot find a smart card reader.</summary>
		public const uint SCARD_E_NO_READERS_AVAILABLE = 0x8010002E;

		/// <summary>A communications error with the smart card has been detected. Retry the operation.</summary>
		public const uint SCARD_E_COMM_DATA_LOST = 0x8010002F;

		/// <summary>The requested key container does not exist on the smart card.</summary>
		public const uint SCARD_E_NO_KEY_CONTAINER = 0x80100030;

		/// <summary>The smart card resource manager is too busy to complete this operation.</summary>
		public const uint SCARD_E_SERVER_TOO_BUSY = 0x80100031;

		/// <summary>The reader cannot communicate with the smart card, due to ATR configuration conflicts.</summary>
		public const uint SCARD_W_UNSUPPORTED_CARD = 0x80100065;

		/// <summary>The smart card is not responding to a reset.</summary>
		public const uint SCARD_W_UNRESPONSIVE_CARD = 0x80100066;

		/// <summary>Power has been removed from the smart card, so that further communication is not possible.</summary>
		public const uint SCARD_W_UNPOWERED_CARD = 0x80100067;

		/// <summary>The smart card has been reset, so any shared state information is invalid.</summary>
		public const uint SCARD_W_RESET_CARD = 0x80100068;

		/// <summary>The smart card has been removed, so that further communication is not possible.</summary>
		public const uint SCARD_W_REMOVED_CARD = 0x80100069;

		/// <summary>Access was denied because of a security violation.</summary>
		public const uint SCARD_W_SECURITY_VIOLATION = 0x8010006A;

		/// <summary>The card cannot be accessed because the wrong PIN was presented.</summary>
		public const uint SCARD_W_WRONG_CHV = 0x8010006B;

		/// <summary>The card cannot be accessed because the maximum number of PIN entry attempts has been reached.</summary>
		public const uint SCARD_W_CHV_BLOCKED = 0x8010006C;

		/// <summary>The end of the smart card file has been reached.</summary>
		public const uint SCARD_W_EOF = 0x8010006D;

		/// <summary>The action was canceled by the user.</summary>
		public const uint SCARD_W_CANCELLED_BY_USER = 0x8010006E;

		/// <summary>No PIN was presented to the smart card.</summary>
		public const uint SCARD_W_CARD_NOT_AUTHENTICATED = 0x8010006F;

		/// <summary>Errors occurred accessing one or more objects—the ErrorInfo collection contains more detail.</summary>
		public const uint COMADMIN_E_OBJECTERRORS = 0x80110401;

		/// <summary>One or more of the object's properties are missing or invalid.</summary>
		public const uint COMADMIN_E_OBJECTINVALID = 0x80110402;

		/// <summary>The object was not found in the catalog.</summary>
		public const uint COMADMIN_E_KEYMISSING = 0x80110403;

		/// <summary>The object is already registered.</summary>
		public const uint COMADMIN_E_ALREADYINSTALLED = 0x80110404;

		/// <summary>An error occurred writing to the application file.</summary>
		public const uint COMADMIN_E_APP_FILE_WRITEFAIL = 0x80110407;

		/// <summary>An error occurred reading the application file.</summary>
		public const uint COMADMIN_E_APP_FILE_READFAIL = 0x80110408;

		/// <summary>Invalid version number in application file.</summary>
		public const uint COMADMIN_E_APP_FILE_VERSION = 0x80110409;

		/// <summary>The file path is invalid.</summary>
		public const uint COMADMIN_E_BADPATH = 0x8011040A;

		/// <summary>The application is already installed.</summary>
		public const uint COMADMIN_E_APPLICATIONEXISTS = 0x8011040B;

		/// <summary>The role already exists.</summary>
		public const uint COMADMIN_E_ROLEEXISTS = 0x8011040C;

		/// <summary>An error occurred copying the file.</summary>
		public const uint COMADMIN_E_CANTCOPYFILE = 0x8011040D;

		/// <summary>One or more users are not valid.</summary>
		public const uint COMADMIN_E_NOUSER = 0x8011040F;

		/// <summary>One or more users in the application file are not valid.</summary>
		public const uint COMADMIN_E_INVALIDUSERIDS = 0x80110410;

		/// <summary>The component's CLSID is missing or corrupt.</summary>
		public const uint COMADMIN_E_NOREGISTRYCLSID = 0x80110411;

		/// <summary>The component's programmatic ID is missing or corrupt.</summary>
		public const uint COMADMIN_E_BADREGISTRYPROGID = 0x80110412;

		/// <summary>Unable to set required authentication level for update request.</summary>
		public const uint COMADMIN_E_AUTHENTICATIONLEVEL = 0x80110413;

		/// <summary>The identity or password set on the application is not valid.</summary>
		public const uint COMADMIN_E_USERPASSWDNOTVALID = 0x80110414;

		/// <summary>Application file CLSIDs or instance identifiers (IIDs) do not match corresponding DLLs.</summary>
		public const uint COMADMIN_E_CLSIDORIIDMISMATCH = 0x80110418;

		/// <summary>Interface information is either missing or changed.</summary>
		public const uint COMADMIN_E_REMOTEINTERFACE = 0x80110419;

		/// <summary>DllRegisterServer failed on component install.</summary>
		public const uint COMADMIN_E_DLLREGISTERSERVER = 0x8011041A;

		/// <summary>No server file share available.</summary>
		public const uint COMADMIN_E_NOSERVERSHARE = 0x8011041B;

		/// <summary>DLL could not be loaded.</summary>
		public const uint COMADMIN_E_DLLLOADFAILED = 0x8011041D;

		/// <summary>The registered TypeLib ID is not valid.</summary>
		public const uint COMADMIN_E_BADREGISTRYLIBID = 0x8011041E;

		/// <summary>Application install directory not found.</summary>
		public const uint COMADMIN_E_APPDIRNOTFOUND = 0x8011041F;

		/// <summary>Errors occurred while in the component registrar.</summary>
		public const uint COMADMIN_E_REGISTRARFAILED = 0x80110423;

		/// <summary>The file does not exist.</summary>
		public const uint COMADMIN_E_COMPFILE_DOESNOTEXIST = 0x80110424;

		/// <summary>The DLL could not be loaded.</summary>
		public const uint COMADMIN_E_COMPFILE_LOADDLLFAIL = 0x80110425;

		/// <summary>GetClassObject failed in the DLL.</summary>
		public const uint COMADMIN_E_COMPFILE_GETCLASSOBJ = 0x80110426;

		/// <summary>The DLL does not support the components listed in the TypeLib.</summary>
		public const uint COMADMIN_E_COMPFILE_CLASSNOTAVAIL = 0x80110427;

		/// <summary>The TypeLib could not be loaded.</summary>
		public const uint COMADMIN_E_COMPFILE_BADTLB = 0x80110428;

		/// <summary>The file does not contain components or component information.</summary>
		public const uint COMADMIN_E_COMPFILE_NOTINSTALLABLE = 0x80110429;

		/// <summary>Changes to this object and its subobjects have been disabled.</summary>
		public const uint COMADMIN_E_NOTCHANGEABLE = 0x8011042A;

		/// <summary>The delete function has been disabled for this object.</summary>
		public const uint COMADMIN_E_NOTDELETEABLE = 0x8011042B;

		/// <summary>The server catalog version is not supported.</summary>
		public const uint COMADMIN_E_SESSION = 0x8011042C;

		/// <summary>The component move was disallowed because the source or destination application is either a system application or currently locked against changes.</summary>
		public const uint COMADMIN_E_COMP_MOVE_LOCKED = 0x8011042D;

		/// <summary>The component move failed because the destination application no longer exists.</summary>
		public const uint COMADMIN_E_COMP_MOVE_BAD_DEST = 0x8011042E;

		/// <summary>The system was unable to register the TypeLib.</summary>
		public const uint COMADMIN_E_REGISTERTLB = 0x80110430;

		/// <summary>This operation cannot be performed on the system application.</summary>
		public const uint COMADMIN_E_SYSTEMAPP = 0x80110433;

		/// <summary>The component registrar referenced in this file is not available.</summary>
		public const uint COMADMIN_E_COMPFILE_NOREGISTRAR = 0x80110434;

		/// <summary>A component in the same DLL is already installed.</summary>
		public const uint COMADMIN_E_COREQCOMPINSTALLED = 0x80110435;

		/// <summary>The service is not installed.</summary>
		public const uint COMADMIN_E_SERVICENOTINSTALLED = 0x80110436;

		/// <summary>One or more property settings are either invalid or in conflict with each other.</summary>
		public const uint COMADMIN_E_PROPERTYSAVEFAILED = 0x80110437;

		/// <summary>The object you are attempting to add or rename already exists.</summary>
		public const uint COMADMIN_E_OBJECTEXISTS = 0x80110438;

		/// <summary>The component already exists.</summary>
		public const uint COMADMIN_E_COMPONENTEXISTS = 0x80110439;

		/// <summary>The registration file is corrupt.</summary>
		public const uint COMADMIN_E_REGFILE_CORRUPT = 0x8011043B;

		/// <summary>The property value is too large.</summary>
		public const uint COMADMIN_E_PROPERTY_OVERFLOW = 0x8011043C;

		/// <summary>Object was not found in registry.</summary>
		public const uint COMADMIN_E_NOTINREGISTRY = 0x8011043E;

		/// <summary>This object cannot be pooled.</summary>
		public const uint COMADMIN_E_OBJECTNOTPOOLABLE = 0x8011043F;

		/// <summary>A CLSID with the same GUID as the new application ID is already installed on this machine.</summary>
		public const uint COMADMIN_E_APPLID_MATCHES_CLSID = 0x80110446;

		/// <summary>A role assigned to a component, interface, or method did not exist in the application.</summary>
		public const uint COMADMIN_E_ROLE_DOES_NOT_EXIST = 0x80110447;

		/// <summary>You must have components in an application to start the application.</summary>
		public const uint COMADMIN_E_START_APP_NEEDS_COMPONENTS = 0x80110448;

		/// <summary>This operation is not enabled on this platform.</summary>
		public const uint COMADMIN_E_REQUIRES_DIFFERENT_PLATFORM = 0x80110449;

		/// <summary>Application proxy is not exportable.</summary>
		public const uint COMADMIN_E_CAN_NOT_EXPORT_APP_PROXY = 0x8011044A;

		/// <summary>Failed to start application because it is either a library application or an application proxy.</summary>
		public const uint COMADMIN_E_CAN_NOT_START_APP = 0x8011044B;

		/// <summary>System application is not exportable.</summary>
		public const uint COMADMIN_E_CAN_NOT_EXPORT_SYS_APP = 0x8011044C;

		/// <summary>Cannot subscribe to this component (the component might have been imported).</summary>
		public const uint COMADMIN_E_CANT_SUBSCRIBE_TO_COMPONENT = 0x8011044D;

		/// <summary>An event class cannot also be a subscriber component.</summary>
		public const uint COMADMIN_E_EVENTCLASS_CANT_BE_SUBSCRIBER = 0x8011044E;

		/// <summary>Library applications and application proxies are incompatible.</summary>
		public const uint COMADMIN_E_LIB_APP_PROXY_INCOMPATIBLE = 0x8011044F;

		/// <summary>This function is valid for the base partition only.</summary>
		public const uint COMADMIN_E_BASE_PARTITION_ONLY = 0x80110450;

		/// <summary>You cannot start an application that has been disabled.</summary>
		public const uint COMADMIN_E_START_APP_DISABLED = 0x80110451;

		/// <summary>The specified partition name is already in use on this computer.</summary>
		public const uint COMADMIN_E_CAT_DUPLICATE_PARTITION_NAME = 0x80110457;

		/// <summary>The specified partition name is invalid. Check that the name contains at least one visible character.</summary>
		public const uint COMADMIN_E_CAT_INVALID_PARTITION_NAME = 0x80110458;

		/// <summary>The partition cannot be deleted because it is the default partition for one or more users.</summary>
		public const uint COMADMIN_E_CAT_PARTITION_IN_USE = 0x80110459;

		/// <summary>The partition cannot be exported because one or more components in the partition have the same file name.</summary>
		public const uint COMADMIN_E_FILE_PARTITION_DUPLICATE_FILES = 0x8011045A;

		/// <summary>Applications that contain one or more imported components cannot be installed into a nonbase partition.</summary>
		public const uint COMADMIN_E_CAT_IMPORTED_COMPONENTS_NOT_ALLOWED = 0x8011045B;

		/// <summary>The application name is not unique and cannot be resolved to an application ID.</summary>
		public const uint COMADMIN_E_AMBIGUOUS_APPLICATION_NAME = 0x8011045C;

		/// <summary>The partition name is not unique and cannot be resolved to a partition ID.</summary>
		public const uint COMADMIN_E_AMBIGUOUS_PARTITION_NAME = 0x8011045D;

		/// <summary>The COM+ registry database has not been initialized.</summary>
		public const uint COMADMIN_E_REGDB_NOTINITIALIZED = 0x80110472;

		/// <summary>The COM+ registry database is not open.</summary>
		public const uint COMADMIN_E_REGDB_NOTOPEN = 0x80110473;

		/// <summary>The COM+ registry database detected a system error.</summary>
		public const uint COMADMIN_E_REGDB_SYSTEMERR = 0x80110474;

		/// <summary>The COM+ registry database is already running.</summary>
		public const uint COMADMIN_E_REGDB_ALREADYRUNNING = 0x80110475;

		/// <summary>This version of the COM+ registry database cannot be migrated.</summary>
		public const uint COMADMIN_E_MIG_VERSIONNOTSUPPORTED = 0x80110480;

		/// <summary>The schema version to be migrated could not be found in the COM+ registry database.</summary>
		public const uint COMADMIN_E_MIG_SCHEMANOTFOUND = 0x80110481;

		/// <summary>There was a type mismatch between binaries.</summary>
		public const uint COMADMIN_E_CAT_BITNESSMISMATCH = 0x80110482;

		/// <summary>A binary of unknown or invalid type was provided.</summary>
		public const uint COMADMIN_E_CAT_UNACCEPTABLEBITNESS = 0x80110483;

		/// <summary>There was a type mismatch between a binary and an application.</summary>
		public const uint COMADMIN_E_CAT_WRONGAPPBITNESS = 0x80110484;

		/// <summary>The application cannot be paused or resumed.</summary>
		public const uint COMADMIN_E_CAT_PAUSE_RESUME_NOT_SUPPORTED = 0x80110485;

		/// <summary>The COM+ catalog server threw an exception during execution.</summary>
		public const uint COMADMIN_E_CAT_SERVERFAULT = 0x80110486;

		/// <summary>Only COM+ applications marked "queued" can be invoked using the "queue" moniker.</summary>
		public const uint COMQC_E_APPLICATION_NOT_QUEUED = 0x80110600;

		/// <summary>At least one interface must be marked "queued" to create a queued component instance with the "queue" moniker.</summary>
		public const uint COMQC_E_NO_QUEUEABLE_INTERFACES = 0x80110601;

		/// <summary>Message Queuing is required for the requested operation and is not installed.</summary>
		public const uint COMQC_E_QUEUING_SERVICE_NOT_AVAILABLE = 0x80110602;

		/// <summary>Unable to marshal an interface that does not support IPersistStream.</summary>
		public const uint COMQC_E_NO_IPERSISTSTREAM = 0x80110603;

		/// <summary>The message is improperly formatted or was damaged in transit.</summary>
		public const uint COMQC_E_BAD_MESSAGE = 0x80110604;

		/// <summary>An unauthenticated message was received by an application that accepts only authenticated messages.</summary>
		public const uint COMQC_E_UNAUTHENTICATED = 0x80110605;

		/// <summary>The message was requeued or moved by a user not in the QC Trusted User "role".</summary>
		public const uint COMQC_E_UNTRUSTED_ENQUEUER = 0x80110606;

		/// <summary>Cannot create a duplicate resource of type Distributed Transaction Coordinator.</summary>
		public const uint MSDTC_E_DUPLICATE_RESOURCE = 0x80110701;

		/// <summary>One of the objects being inserted or updated does not belong to a valid parent collection.</summary>
		public const uint COMADMIN_E_OBJECT_PARENT_MISSING = 0x80110808;

		/// <summary>One of the specified objects cannot be found.</summary>
		public const uint COMADMIN_E_OBJECT_DOES_NOT_EXIST = 0x80110809;

		/// <summary>The specified application is not currently running.</summary>
		public const uint COMADMIN_E_APP_NOT_RUNNING = 0x8011080A;

		/// <summary>The partitions specified are not valid.</summary>
		public const uint COMADMIN_E_INVALID_PARTITION = 0x8011080B;

		/// <summary>COM+ applications that run as Windows NT service cannot be pooled or recycled.</summary>
		public const uint COMADMIN_E_SVCAPP_NOT_POOLABLE_OR_RECYCLABLE = 0x8011080D;

		/// <summary>One or more users are already assigned to a local partition set.</summary>
		public const uint COMADMIN_E_USER_IN_SET = 0x8011080E;

		/// <summary>Library applications cannot be recycled.</summary>
		public const uint COMADMIN_E_CANTRECYCLELIBRARYAPPS = 0x8011080F;

		/// <summary>Applications running as Windows NT services cannot be recycled.</summary>
		public const uint COMADMIN_E_CANTRECYCLESERVICEAPPS = 0x80110811;

		/// <summary>The process has already been recycled.</summary>
		public const uint COMADMIN_E_PROCESSALREADYRECYCLED = 0x80110812;

		/// <summary>A paused process cannot be recycled.</summary>
		public const uint COMADMIN_E_PAUSEDPROCESSMAYNOTBERECYCLED = 0x80110813;

		/// <summary>Library applications cannot be Windows NT services.</summary>
		public const uint COMADMIN_E_CANTMAKEINPROCSERVICE = 0x80110814;

		/// <summary>The ProgID provided to the copy operation is invalid. The ProgID is in use by another registered CLSID.</summary>
		public const uint COMADMIN_E_PROGIDINUSEBYCLSID = 0x80110815;

		/// <summary>The partition specified as the default is not a member of the partition set.</summary>
		public const uint COMADMIN_E_DEFAULT_PARTITION_NOT_IN_SET = 0x80110816;

		/// <summary>A recycled process cannot be paused.</summary>
		public const uint COMADMIN_E_RECYCLEDPROCESSMAYNOTBEPAUSED = 0x80110817;

		/// <summary>Access to the specified partition is denied.</summary>
		public const uint COMADMIN_E_PARTITION_ACCESSDENIED = 0x80110818;

		/// <summary>Only application files (*.msi files) can be installed into partitions.</summary>
		public const uint COMADMIN_E_PARTITION_MSI_ONLY = 0x80110819;

		/// <summary>Applications containing one or more legacy components cannot be exported to 1.0 format.</summary>
		public const uint COMADMIN_E_LEGACYCOMPS_NOT_ALLOWED_IN_1_0_FORMAT = 0x8011081A;

		/// <summary>Legacy components cannot exist in nonbase partitions.</summary>
		public const uint COMADMIN_E_LEGACYCOMPS_NOT_ALLOWED_IN_NONBASE_PARTITIONS = 0x8011081B;

		/// <summary>A component cannot be moved (or copied) from the System Application, an application proxy, or a nonchangeable application.</summary>
		public const uint COMADMIN_E_COMP_MOVE_SOURCE = 0x8011081C;

		/// <summary>A component cannot be moved (or copied) to the System Application, an application proxy or a nonchangeable application.</summary>
		public const uint COMADMIN_E_COMP_MOVE_DEST = 0x8011081D;

		/// <summary>A private component cannot be moved (or copied) to a library application or to the base partition.</summary>
		public const uint COMADMIN_E_COMP_MOVE_PRIVATE = 0x8011081E;

		/// <summary>The Base Application Partition exists in all partition sets and cannot be removed.</summary>
		public const uint COMADMIN_E_BASEPARTITION_REQUIRED_IN_SET = 0x8011081F;

		/// <summary>Alas, Event Class components cannot be aliased.</summary>
		public const uint COMADMIN_E_CANNOT_ALIAS_EVENTCLASS = 0x80110820;

		/// <summary>Access is denied because the component is private.</summary>
		public const uint COMADMIN_E_PRIVATE_ACCESSDENIED = 0x80110821;

		/// <summary>The specified SAFER level is invalid.</summary>
		public const uint COMADMIN_E_SAFERINVALID = 0x80110822;

		/// <summary>The specified user cannot write to the system registry.</summary>
		public const uint COMADMIN_E_REGISTRY_ACCESSDENIED = 0x80110823;

		/// <summary>COM+ partitions are currently disabled.</summary>
		public const uint COMADMIN_E_PARTITIONS_DISABLED = 0x80110824;

		/// <summary>A handler was not defined by the filter for this operation.</summary>
		public const uint ERROR_FLT_NO_HANDLER_DEFINED = 0x801F0001;

		/// <summary>A context is already defined for this object.</summary>
		public const uint ERROR_FLT_CONTEXT_ALREADY_DEFINED = 0x801F0002;

		/// <summary>Asynchronous requests are not valid for this operation.</summary>
		public const uint ERROR_FLT_INVALID_ASYNCHRONOUS_REQUEST = 0x801F0003;

		/// <summary>Disallow the Fast IO path for this operation.</summary>
		public const uint ERROR_FLT_DISALLOW_FAST_IO = 0x801F0004;

		/// <summary>An invalid name request was made. The name requested cannot be retrieved at this time.</summary>
		public const uint ERROR_FLT_INVALID_NAME_REQUEST = 0x801F0005;

		/// <summary>Posting this operation to a worker thread for further processing is not safe at this time because it could lead to a system deadlock.</summary>
		public const uint ERROR_FLT_NOT_SAFE_TO_POST_OPERATION = 0x801F0006;

		/// <summary>The Filter Manager was not initialized when a filter tried to register. Be sure that the Filter Manager is being loaded as a driver.</summary>
		public const uint ERROR_FLT_NOT_INITIALIZED = 0x801F0007;

		/// <summary>The filter is not ready for attachment to volumes because it has not finished initializing (FltStartFiltering has not been called).</summary>
		public const uint ERROR_FLT_FILTER_NOT_READY = 0x801F0008;

		/// <summary>The filter must clean up any operation-specific context at this time because it is being removed from the system before the operation is completed by the lower drivers.</summary>
		public const uint ERROR_FLT_POST_OPERATION_CLEANUP = 0x801F0009;

		/// <summary>The Filter Manager had an internal error from which it cannot recover; therefore, the operation has been failed. This is usually the result of a filter returning an invalid value from a preoperation callback.</summary>
		public const uint ERROR_FLT_INTERNAL_ERROR = 0x801F000A;

		/// <summary>The object specified for this action is in the process of being deleted; therefore, the action requested cannot be completed at this time.</summary>
		public const uint ERROR_FLT_DELETING_OBJECT = 0x801F000B;

		/// <summary>Nonpaged pool must be used for this type of context.</summary>
		public const uint ERROR_FLT_MUST_BE_NONPAGED_POOL = 0x801F000C;

		/// <summary>A duplicate handler definition has been provided for an operation.</summary>
		public const uint ERROR_FLT_DUPLICATE_ENTRY = 0x801F000D;

		/// <summary>The callback data queue has been disabled.</summary>
		public const uint ERROR_FLT_CBDQ_DISABLED = 0x801F000E;

		/// <summary>Do not attach the filter to the volume at this time.</summary>
		public const uint ERROR_FLT_DO_NOT_ATTACH = 0x801F000F;

		/// <summary>Do not detach the filter from the volume at this time.</summary>
		public const uint ERROR_FLT_DO_NOT_DETACH = 0x801F0010;

		/// <summary>An instance already exists at this altitude on the volume specified.</summary>
		public const uint ERROR_FLT_INSTANCE_ALTITUDE_COLLISION = 0x801F0011;

		/// <summary>An instance already exists with this name on the volume specified.</summary>
		public const uint ERROR_FLT_INSTANCE_NAME_COLLISION = 0x801F0012;

		/// <summary>The system could not find the filter specified.</summary>
		public const uint ERROR_FLT_FILTER_NOT_FOUND = 0x801F0013;

		/// <summary>The system could not find the volume specified.</summary>
		public const uint ERROR_FLT_VOLUME_NOT_FOUND = 0x801F0014;

		/// <summary>The system could not find the instance specified.</summary>
		public const uint ERROR_FLT_INSTANCE_NOT_FOUND = 0x801F0015;

		/// <summary>No registered context allocation definition was found for the given request.</summary>
		public const uint ERROR_FLT_CONTEXT_ALLOCATION_NOT_FOUND = 0x801F0016;

		/// <summary>An invalid parameter was specified during context registration.</summary>
		public const uint ERROR_FLT_INVALID_CONTEXT_REGISTRATION = 0x801F0017;

		/// <summary>The name requested was not found in the Filter Manager name cache and could not be retrieved from the file system.</summary>
		public const uint ERROR_FLT_NAME_CACHE_MISS = 0x801F0018;

		/// <summary>The requested device object does not exist for the given volume.</summary>
		public const uint ERROR_FLT_NO_DEVICE_OBJECT = 0x801F0019;

		/// <summary>The specified volume is already mounted.</summary>
		public const uint ERROR_FLT_VOLUME_ALREADY_MOUNTED = 0x801F001A;

		/// <summary>The specified Transaction Context is already enlisted in a transaction.</summary>
		public const uint ERROR_FLT_ALREADY_ENLISTED = 0x801F001B;

		/// <summary>The specified context is already attached to another object.</summary>
		public const uint ERROR_FLT_CONTEXT_ALREADY_LINKED = 0x801F001C;

		/// <summary>No waiter is present for the filter's reply to this message.</summary>
		public const uint ERROR_FLT_NO_WAITER_FOR_REPLY = 0x801F0020;

		/// <summary>{Display Driver Stopped Responding} The %hs display driver has stopped working normally. Save your work and reboot the system to restore full display functionality. The next time you reboot the machine a dialog will be displayed giving you a chance to report this failure to Microsoft.</summary>
		public const uint ERROR_HUNG_DISPLAY_DRIVER_THREAD = 0x80260001;

		/// <summary>Monitor descriptor could not be obtained.</summary>
		public const uint ERROR_MONITOR_NO_DESCRIPTOR = 0x80261001;

		/// <summary>Format of the obtained monitor descriptor is not supported by this release.</summary>
		public const uint ERROR_MONITOR_UNKNOWN_DESCRIPTOR_FORMAT = 0x80261002;

		/// <summary>{Desktop Composition is Disabled} The operation could not be completed because desktop composition is disabled.</summary>
		public const uint DWM_E_COMPOSITIONDISABLED = 0x80263001;

		/// <summary>{Some Desktop Composition APIs Are Not Supported While Remoting} Some desktop composition APIs are not supported while remoting. The operation is not supported while running in a remote session.</summary>
		public const uint DWM_E_REMOTING_NOT_SUPPORTED = 0x80263002;

		/// <summary>{No DWM Redirection Surface is Available} The Desktop Window Manager (DWM) was unable to provide a redirection surface to complete the DirectX present.</summary>
		public const uint DWM_E_NO_REDIRECTION_SURFACE_AVAILABLE = 0x80263003;

		/// <summary>{DWM Is Not Queuing Presents for the Specified Window} The window specified is not currently using queued presents.</summary>
		public const uint DWM_E_NOT_QUEUING_PRESENTS = 0x80263004;

		/// <summary>This is an error mask to convert Trusted Platform Module (TPM) hardware errors to Win32 errors.</summary>
		public const uint TPM_E_ERROR_MASK = 0x80280000;

		/// <summary>Authentication failed.</summary>
		public const uint TPM_E_AUTHFAIL = 0x80280001;

		/// <summary>The index to a Platform Configuration Register (PCR), DIR, or other register is incorrect.</summary>
		public const uint TPM_E_BADINDEX = 0x80280002;

		/// <summary>One or more parameters are bad.</summary>
		public const uint TPM_E_BAD_PARAMETER = 0x80280003;

		/// <summary>An operation completed successfully but the auditing of that operation failed.</summary>
		public const uint TPM_E_AUDITFAILURE = 0x80280004;

		/// <summary>The clear disable flag is set and all clear operations now require physical access.</summary>
		public const uint TPM_E_CLEAR_DISABLED = 0x80280005;

		/// <summary>The TPM is deactivated.</summary>
		public const uint TPM_E_DEACTIVATED = 0x80280006;

		/// <summary>The TPM is disabled.</summary>
		public const uint TPM_E_DISABLED = 0x80280007;

		/// <summary>The target command has been disabled.</summary>
		public const uint TPM_E_DISABLED_CMD = 0x80280008;

		/// <summary>The operation failed.</summary>
		public const uint TPM_E_FAIL = 0x80280009;

		/// <summary>The ordinal was unknown or inconsistent.</summary>
		public const uint TPM_E_BAD_ORDINAL = 0x8028000A;

		/// <summary>The ability to install an owner is disabled.</summary>
		public const uint TPM_E_INSTALL_DISABLED = 0x8028000B;

		/// <summary>The key handle cannot be interpreted.</summary>
		public const uint TPM_E_INVALID_KEYHANDLE = 0x8028000C;

		/// <summary>The key handle points to an invalid key.</summary>
		public const uint TPM_E_KEYNOTFOUND = 0x8028000D;

		/// <summary>Unacceptable encryption scheme.</summary>
		public const uint TPM_E_INAPPROPRIATE_ENC = 0x8028000E;

		/// <summary>Migration authorization failed.</summary>
		public const uint TPM_E_MIGRATEFAIL = 0x8028000F;

		/// <summary>PCR information could not be interpreted.</summary>
		public const uint TPM_E_INVALID_PCR_INFO = 0x80280010;

		/// <summary>No room to load key.</summary>
		public const uint TPM_E_NOSPACE = 0x80280011;

		/// <summary>There is no storage root key (SRK) set.</summary>
		public const uint TPM_E_NOSRK = 0x80280012;

		/// <summary>An encrypted blob is invalid or was not created by this TPM.</summary>
		public const uint TPM_E_NOTSEALED_BLOB = 0x80280013;

		/// <summary>There is already an owner.</summary>
		public const uint TPM_E_OWNER_SET = 0x80280014;

		/// <summary>The TPM has insufficient internal resources to perform the requested action.</summary>
		public const uint TPM_E_RESOURCES = 0x80280015;

		/// <summary>A random string was too short.</summary>
		public const uint TPM_E_SHORTRANDOM = 0x80280016;

		/// <summary>The TPM does not have the space to perform the operation.</summary>
		public const uint TPM_E_SIZE = 0x80280017;

		/// <summary>The named PCR value does not match the current PCR value.</summary>
		public const uint TPM_E_WRONGPCRVAL = 0x80280018;

		/// <summary>The paramSize argument to the command has the incorrect value.</summary>
		public const uint TPM_E_BAD_PARAM_SIZE = 0x80280019;

		/// <summary>There is no existing SHA-1 thread.</summary>
		public const uint TPM_E_SHA_THREAD = 0x8028001A;

		/// <summary>The calculation is unable to proceed because the existing SHA-1 thread has already encountered an error.</summary>
		public const uint TPM_E_SHA_ERROR = 0x8028001B;

		/// <summary>Self-test has failed and the TPM has shut down.</summary>
		public const uint TPM_E_FAILEDSELFTEST = 0x8028001C;

		/// <summary>The authorization for the second key in a two-key function failed authorization.</summary>
		public const uint TPM_E_AUTH2FAIL = 0x8028001D;

		/// <summary>The tag value sent to for a command is invalid.</summary>
		public const uint TPM_E_BADTAG = 0x8028001E;

		/// <summary>An I/O error occurred transmitting information to the TPM.</summary>
		public const uint TPM_E_IOERROR = 0x8028001F;

		/// <summary>The encryption process had a problem.</summary>
		public const uint TPM_E_ENCRYPT_ERROR = 0x80280020;

		/// <summary>The decryption process did not complete.</summary>
		public const uint TPM_E_DECRYPT_ERROR = 0x80280021;

		/// <summary>An invalid handle was used.</summary>
		public const uint TPM_E_INVALID_AUTHHANDLE = 0x80280022;

		/// <summary>The TPM does not have an endorsement key (EK) installed.</summary>
		public const uint TPM_E_NO_ENDORSEMENT = 0x80280023;

		/// <summary>The usage of a key is not allowed.</summary>
		public const uint TPM_E_INVALID_KEYUSAGE = 0x80280024;

		/// <summary>The submitted entity type is not allowed.</summary>
		public const uint TPM_E_WRONG_ENTITYTYPE = 0x80280025;

		/// <summary>The command was received in the wrong sequence relative to TPM_Init and a subsequent TPM_Startup.</summary>
		public const uint TPM_E_INVALID_POSTINIT = 0x80280026;

		/// <summary>Signed data cannot include additional DER information.</summary>
		public const uint TPM_E_INAPPROPRIATE_SIG = 0x80280027;

		/// <summary>The key properties in TPM_KEY_PARMs are not supported by this TPM.</summary>
		public const uint TPM_E_BAD_KEY_PROPERTY = 0x80280028;

		/// <summary>The migration properties of this key are incorrect.</summary>
		public const uint TPM_E_BAD_MIGRATION = 0x80280029;

		/// <summary>The signature or encryption scheme for this key is incorrect or not permitted in this situation.</summary>
		public const uint TPM_E_BAD_SCHEME = 0x8028002A;

		/// <summary>The size of the data (or blob) parameter is bad or inconsistent with the referenced key.</summary>
		public const uint TPM_E_BAD_DATASIZE = 0x8028002B;

		/// <summary>A mode parameter is bad, such as capArea or subCapArea for TPM_GetCapability, physicalPresence parameter for TPM_PhysicalPresence, or migrationType for TPM_CreateMigrationBlob.</summary>
		public const uint TPM_E_BAD_MODE = 0x8028002C;

		/// <summary>Either the physicalPresence or physicalPresenceLock bits have the wrong value.</summary>
		public const uint TPM_E_BAD_PRESENCE = 0x8028002D;

		/// <summary>The TPM cannot perform this version of the capability.</summary>
		public const uint TPM_E_BAD_VERSION = 0x8028002E;

		/// <summary>The TPM does not allow for wrapped transport sessions.</summary>
		public const uint TPM_E_NO_WRAP_TRANSPORT = 0x8028002F;

		/// <summary>TPM audit construction failed and the underlying command was returning a failure code also.</summary>
		public const uint TPM_E_AUDITFAIL_UNSUCCESSFUL = 0x80280030;

		/// <summary>TPM audit construction failed and the underlying command was returning success.</summary>
		public const uint TPM_E_AUDITFAIL_SUCCESSFUL = 0x80280031;

		/// <summary>Attempt to reset a PCR that does not have the resettable attribute.</summary>
		public const uint TPM_E_NOTRESETABLE = 0x80280032;

		/// <summary>Attempt to reset a PCR register that requires locality and the locality modifier not part of command transport.</summary>
		public const uint TPM_E_NOTLOCAL = 0x80280033;

		/// <summary>Make identity blob not properly typed.</summary>
		public const uint TPM_E_BAD_TYPE = 0x80280034;

		/// <summary>When saving context identified resource type does not match actual resource.</summary>
		public const uint TPM_E_INVALID_RESOURCE = 0x80280035;

		/// <summary>The TPM is attempting to execute a command only available when in Federal Information Processing Standards (FIPS) mode.</summary>
		public const uint TPM_E_NOTFIPS = 0x80280036;

		/// <summary>The command is attempting to use an invalid family ID.</summary>
		public const uint TPM_E_INVALID_FAMILY = 0x80280037;

		/// <summary>The permission to manipulate the NV storage is not available.</summary>
		public const uint TPM_E_NO_NV_PERMISSION = 0x80280038;

		/// <summary>The operation requires a signed command.</summary>
		public const uint TPM_E_REQUIRES_SIGN = 0x80280039;

		/// <summary>Wrong operation to load an NV key.</summary>
		public const uint TPM_E_KEY_NOTSUPPORTED = 0x8028003A;

		/// <summary>NV_LoadKey blob requires both owner and blob authorization.</summary>
		public const uint TPM_E_AUTH_CONFLICT = 0x8028003B;

		/// <summary>The NV area is locked and not writable.</summary>
		public const uint TPM_E_AREA_LOCKED = 0x8028003C;

		/// <summary>The locality is incorrect for the attempted operation.</summary>
		public const uint TPM_E_BAD_LOCALITY = 0x8028003D;

		/// <summary>The NV area is read-only and cannot be written to.</summary>
		public const uint TPM_E_READ_ONLY = 0x8028003E;

		/// <summary>There is no protection on the write to the NV area.</summary>
		public const uint TPM_E_PER_NOWRITE = 0x8028003F;

		/// <summary>The family count value does not match.</summary>
		public const uint TPM_E_FAMILYCOUNT = 0x80280040;

		/// <summary>The NV area has already been written to.</summary>
		public const uint TPM_E_WRITE_LOCKED = 0x80280041;

		/// <summary>The NV area attributes conflict.</summary>
		public const uint TPM_E_BAD_ATTRIBUTES = 0x80280042;

		/// <summary>The structure tag and version are invalid or inconsistent.</summary>
		public const uint TPM_E_INVALID_STRUCTURE = 0x80280043;

		/// <summary>The key is under control of the TPM owner and can only be evicted by the TPM owner.</summary>
		public const uint TPM_E_KEY_OWNER_CONTROL = 0x80280044;

		/// <summary>The counter handle is incorrect.</summary>
		public const uint TPM_E_BAD_COUNTER = 0x80280045;

		/// <summary>The write is not a complete write of the area.</summary>
		public const uint TPM_E_NOT_FULLWRITE = 0x80280046;

		/// <summary>The gap between saved context counts is too large.</summary>
		public const uint TPM_E_CONTEXT_GAP = 0x80280047;

		/// <summary>The maximum number of NV writes without an owner has been exceeded.</summary>
		public const uint TPM_E_MAXNVWRITES = 0x80280048;

		/// <summary>No operator AuthData value is set.</summary>
		public const uint TPM_E_NOOPERATOR = 0x80280049;

		/// <summary>The resource pointed to by context is not loaded.</summary>
		public const uint TPM_E_RESOURCEMISSING = 0x8028004A;

		/// <summary>The delegate administration is locked.</summary>
		public const uint TPM_E_DELEGATE_LOCK = 0x8028004B;

		/// <summary>Attempt to manage a family other then the delegated family.</summary>
		public const uint TPM_E_DELEGATE_FAMILY = 0x8028004C;

		/// <summary>Delegation table management not enabled.</summary>
		public const uint TPM_E_DELEGATE_ADMIN = 0x8028004D;

		/// <summary>There was a command executed outside an exclusive transport session.</summary>
		public const uint TPM_E_TRANSPORT_NOTEXCLUSIVE = 0x8028004E;

		/// <summary>Attempt to context save an owner evict controlled key.</summary>
		public const uint TPM_E_OWNER_CONTROL = 0x8028004F;

		/// <summary>The DAA command has no resources available to execute the command.</summary>
		public const uint TPM_E_DAA_RESOURCES = 0x80280050;

		/// <summary>The consistency check on DAA parameter inputData0 has failed.</summary>
		public const uint TPM_E_DAA_INPUT_DATA0 = 0x80280051;

		/// <summary>The consistency check on DAA parameter inputData1 has failed.</summary>
		public const uint TPM_E_DAA_INPUT_DATA1 = 0x80280052;

		/// <summary>The consistency check on DAA_issuerSettings has failed.</summary>
		public const uint TPM_E_DAA_ISSUER_SETTINGS = 0x80280053;

		/// <summary>The consistency check on DAA_tpmSpecific has failed.</summary>
		public const uint TPM_E_DAA_TPM_SETTINGS = 0x80280054;

		/// <summary>The atomic process indicated by the submitted DAA command is not the expected process.</summary>
		public const uint TPM_E_DAA_STAGE = 0x80280055;

		/// <summary>The issuer's validity check has detected an inconsistency.</summary>
		public const uint TPM_E_DAA_ISSUER_VALIDITY = 0x80280056;

		/// <summary>The consistency check on w has failed.</summary>
		public const uint TPM_E_DAA_WRONG_W = 0x80280057;

		/// <summary>The handle is incorrect.</summary>
		public const uint TPM_E_BAD_HANDLE = 0x80280058;

		/// <summary>Delegation is not correct.</summary>
		public const uint TPM_E_BAD_DELEGATE = 0x80280059;

		/// <summary>The context blob is invalid.</summary>
		public const uint TPM_E_BADCONTEXT = 0x8028005A;

		/// <summary>Too many contexts held by the TPM.</summary>
		public const uint TPM_E_TOOMANYCONTEXTS = 0x8028005B;

		/// <summary>Migration authority signature validation failure.</summary>
		public const uint TPM_E_MA_TICKET_SIGNATURE = 0x8028005C;

		/// <summary>Migration destination not authenticated.</summary>
		public const uint TPM_E_MA_DESTINATION = 0x8028005D;

		/// <summary>Migration source incorrect.</summary>
		public const uint TPM_E_MA_SOURCE = 0x8028005E;

		/// <summary>Incorrect migration authority.</summary>
		public const uint TPM_E_MA_AUTHORITY = 0x8028005F;

		/// <summary>Attempt to revoke the EK and the EK is not revocable.</summary>
		public const uint TPM_E_PERMANENTEK = 0x80280061;

		/// <summary>Bad signature of CMK ticket.</summary>
		public const uint TPM_E_BAD_SIGNATURE = 0x80280062;

		/// <summary>There is no room in the context list for additional contexts.</summary>
		public const uint TPM_E_NOCONTEXTSPACE = 0x80280063;

		/// <summary>The command was blocked.</summary>
		public const uint TPM_E_COMMAND_BLOCKED = 0x80280400;

		/// <summary>The specified handle was not found.</summary>
		public const uint TPM_E_INVALID_HANDLE = 0x80280401;

		/// <summary>The TPM returned a duplicate handle and the command needs to be resubmitted.</summary>
		public const uint TPM_E_DUPLICATE_VHANDLE = 0x80280402;

		/// <summary>The command within the transport was blocked.</summary>
		public const uint TPM_E_EMBEDDED_COMMAND_BLOCKED = 0x80280403;

		/// <summary>The command within the transport is not supported.</summary>
		public const uint TPM_E_EMBEDDED_COMMAND_UNSUPPORTED = 0x80280404;

		/// <summary>The TPM is too busy to respond to the command immediately, but the command could be resubmitted at a later time.</summary>
		public const uint TPM_E_RETRY = 0x80280800;

		/// <summary>SelfTestFull has not been run.</summary>
		public const uint TPM_E_NEEDS_SELFTEST = 0x80280801;

		/// <summary>The TPM is currently executing a full self-test.</summary>
		public const uint TPM_E_DOING_SELFTEST = 0x80280802;

		/// <summary>The TPM is defending against dictionary attacks and is in a time-out period.</summary>
		public const uint TPM_E_DEFEND_LOCK_RUNNING = 0x80280803;

		/// <summary>An internal software error has been detected.</summary>
		public const uint TBS_E_INTERNAL_ERROR = 0x80284001;

		/// <summary>One or more input parameters are bad.</summary>
		public const uint TBS_E_BAD_PARAMETER = 0x80284002;

		/// <summary>A specified output pointer is bad.</summary>
		public const uint TBS_E_INVALID_OUTPUT_POINTER = 0x80284003;

		/// <summary>The specified context handle does not refer to a valid context.</summary>
		public const uint TBS_E_INVALID_CONTEXT = 0x80284004;

		/// <summary>A specified output buffer is too small.</summary>
		public const uint TBS_E_INSUFFICIENT_BUFFER = 0x80284005;

		/// <summary>An error occurred while communicating with the TPM.</summary>
		public const uint TBS_E_IOERROR = 0x80284006;

		/// <summary>One or more context parameters are invalid.</summary>
		public const uint TBS_E_INVALID_CONTEXT_PARAM = 0x80284007;

		/// <summary>The TPM Base Services (TBS) is not running and could not be started.</summary>
		public const uint TBS_E_SERVICE_NOT_RUNNING = 0x80284008;

		/// <summary>A new context could not be created because there are too many open contexts.</summary>
		public const uint TBS_E_TOO_MANY_TBS_CONTEXTS = 0x80284009;

		/// <summary>A new virtual resource could not be created because there are too many open virtual resources.</summary>
		public const uint TBS_E_TOO_MANY_RESOURCES = 0x8028400A;

		/// <summary>The TBS service has been started but is not yet running.</summary>
		public const uint TBS_E_SERVICE_START_PENDING = 0x8028400B;

		/// <summary>The physical presence interface is not supported.</summary>
		public const uint TBS_E_PPI_NOT_SUPPORTED = 0x8028400C;

		/// <summary>The command was canceled.</summary>
		public const uint TBS_E_COMMAND_CANCELED = 0x8028400D;

		/// <summary>The input or output buffer is too large.</summary>
		public const uint TBS_E_BUFFER_TOO_LARGE = 0x8028400E;

		/// <summary>The command buffer is not in the correct state.</summary>
		public const uint TPMAPI_E_INVALID_STATE = 0x80290100;

		/// <summary>The command buffer does not contain enough data to satisfy the request.</summary>
		public const uint TPMAPI_E_NOT_ENOUGH_DATA = 0x80290101;

		/// <summary>The command buffer cannot contain any more data.</summary>
		public const uint TPMAPI_E_TOO_MUCH_DATA = 0x80290102;

		/// <summary>One or more output parameters was null or invalid.</summary>
		public const uint TPMAPI_E_INVALID_OUTPUT_POINTER = 0x80290103;

		/// <summary>One or more input parameters are invalid.</summary>
		public const uint TPMAPI_E_INVALID_PARAMETER = 0x80290104;

		/// <summary>Not enough memory was available to satisfy the request.</summary>
		public const uint TPMAPI_E_OUT_OF_MEMORY = 0x80290105;

		/// <summary>The specified buffer was too small.</summary>
		public const uint TPMAPI_E_BUFFER_TOO_SMALL = 0x80290106;

		/// <summary>An internal error was detected.</summary>
		public const uint TPMAPI_E_INTERNAL_ERROR = 0x80290107;

		/// <summary>The caller does not have the appropriate rights to perform the requested operation.</summary>
		public const uint TPMAPI_E_ACCESS_DENIED = 0x80290108;

		/// <summary>The specified authorization information was invalid.</summary>
		public const uint TPMAPI_E_AUTHORIZATION_FAILED = 0x80290109;

		/// <summary>The specified context handle was not valid.</summary>
		public const uint TPMAPI_E_INVALID_CONTEXT_HANDLE = 0x8029010A;

		/// <summary>An error occurred while communicating with the TBS.</summary>
		public const uint TPMAPI_E_TBS_COMMUNICATION_ERROR = 0x8029010B;

		/// <summary>The TPM returned an unexpected result.</summary>
		public const uint TPMAPI_E_TPM_COMMAND_ERROR = 0x8029010C;

		/// <summary>The message was too large for the encoding scheme.</summary>
		public const uint TPMAPI_E_MESSAGE_TOO_LARGE = 0x8029010D;

		/// <summary>The encoding in the binary large object (BLOB) was not recognized.</summary>
		public const uint TPMAPI_E_INVALID_ENCODING = 0x8029010E;

		/// <summary>The key size is not valid.</summary>
		public const uint TPMAPI_E_INVALID_KEY_SIZE = 0x8029010F;

		/// <summary>The encryption operation failed.</summary>
		public const uint TPMAPI_E_ENCRYPTION_FAILED = 0x80290110;

		/// <summary>The key parameters structure was not valid.</summary>
		public const uint TPMAPI_E_INVALID_KEY_PARAMS = 0x80290111;

		/// <summary>The requested supplied data does not appear to be a valid migration authorization BLOB.</summary>
		public const uint TPMAPI_E_INVALID_MIGRATION_AUTHORIZATION_BLOB = 0x80290112;

		/// <summary>The specified PCR index was invalid.</summary>
		public const uint TPMAPI_E_INVALID_PCR_INDEX = 0x80290113;

		/// <summary>The data given does not appear to be a valid delegate BLOB.</summary>
		public const uint TPMAPI_E_INVALID_DELEGATE_BLOB = 0x80290114;

		/// <summary>One or more of the specified context parameters was not valid.</summary>
		public const uint TPMAPI_E_INVALID_CONTEXT_PARAMS = 0x80290115;

		/// <summary>The data given does not appear to be a valid key BLOB.</summary>
		public const uint TPMAPI_E_INVALID_KEY_BLOB = 0x80290116;

		/// <summary>The specified PCR data was invalid.</summary>
		public const uint TPMAPI_E_INVALID_PCR_DATA = 0x80290117;

		/// <summary>The format of the owner authorization data was invalid.</summary>
		public const uint TPMAPI_E_INVALID_OWNER_AUTH = 0x80290118;

		/// <summary>The specified buffer was too small.</summary>
		public const uint TBSIMP_E_BUFFER_TOO_SMALL = 0x80290200;

		/// <summary>The context could not be cleaned up.</summary>
		public const uint TBSIMP_E_CLEANUP_FAILED = 0x80290201;

		/// <summary>The specified context handle is invalid.</summary>
		public const uint TBSIMP_E_INVALID_CONTEXT_HANDLE = 0x80290202;

		/// <summary>An invalid context parameter was specified.</summary>
		public const uint TBSIMP_E_INVALID_CONTEXT_PARAM = 0x80290203;

		/// <summary>An error occurred while communicating with the TPM.</summary>
		public const uint TBSIMP_E_TPM_ERROR = 0x80290204;

		/// <summary>No entry with the specified key was found.</summary>
		public const uint TBSIMP_E_HASH_BAD_KEY = 0x80290205;

		/// <summary>The specified virtual handle matches a virtual handle already in use.</summary>
		public const uint TBSIMP_E_DUPLICATE_VHANDLE = 0x80290206;

		/// <summary>The pointer to the returned handle location was null or invalid.</summary>
		public const uint TBSIMP_E_INVALID_OUTPUT_POINTER = 0x80290207;

		/// <summary>One or more parameters are invalid.</summary>
		public const uint TBSIMP_E_INVALID_PARAMETER = 0x80290208;

		/// <summary>The RPC subsystem could not be initialized.</summary>
		public const uint TBSIMP_E_RPC_INIT_FAILED = 0x80290209;

		/// <summary>The TBS scheduler is not running.</summary>
		public const uint TBSIMP_E_SCHEDULER_NOT_RUNNING = 0x8029020A;

		/// <summary>The command was canceled.</summary>
		public const uint TBSIMP_E_COMMAND_CANCELED = 0x8029020B;

		/// <summary>There was not enough memory to fulfill the request.</summary>
		public const uint TBSIMP_E_OUT_OF_MEMORY = 0x8029020C;

		/// <summary>The specified list is empty, or the iteration has reached the end of the list.</summary>
		public const uint TBSIMP_E_LIST_NO_MORE_ITEMS = 0x8029020D;

		/// <summary>The specified item was not found in the list.</summary>
		public const uint TBSIMP_E_LIST_NOT_FOUND = 0x8029020E;

		/// <summary>The TPM does not have enough space to load the requested resource.</summary>
		public const uint TBSIMP_E_NOT_ENOUGH_SPACE = 0x8029020F;

		/// <summary>There are too many TPM contexts in use.</summary>
		public const uint TBSIMP_E_NOT_ENOUGH_TPM_CONTEXTS = 0x80290210;

		/// <summary>The TPM command failed.</summary>
		public const uint TBSIMP_E_COMMAND_FAILED = 0x80290211;

		/// <summary>The TBS does not recognize the specified ordinal.</summary>
		public const uint TBSIMP_E_UNKNOWN_ORDINAL = 0x80290212;

		/// <summary>The requested resource is no longer available.</summary>
		public const uint TBSIMP_E_RESOURCE_EXPIRED = 0x80290213;

		/// <summary>The resource type did not match.</summary>
		public const uint TBSIMP_E_INVALID_RESOURCE = 0x80290214;

		/// <summary>No resources can be unloaded.</summary>
		public const uint TBSIMP_E_NOTHING_TO_UNLOAD = 0x80290215;

		/// <summary>No new entries can be added to the hash table.</summary>
		public const uint TBSIMP_E_HASH_TABLE_FULL = 0x80290216;

		/// <summary>A new TBS context could not be created because there are too many open contexts.</summary>
		public const uint TBSIMP_E_TOO_MANY_TBS_CONTEXTS = 0x80290217;

		/// <summary>A new virtual resource could not be created because there are too many open virtual resources.</summary>
		public const uint TBSIMP_E_TOO_MANY_RESOURCES = 0x80290218;

		/// <summary>The physical presence interface is not supported.</summary>
		public const uint TBSIMP_E_PPI_NOT_SUPPORTED = 0x80290219;

		/// <summary>TBS is not compatible with the version of TPM found on the system.</summary>
		public const uint TBSIMP_E_TPM_INCOMPATIBLE = 0x8029021A;

		/// <summary>A general error was detected when attempting to acquire the BIOS response to a physical presence command.</summary>
		public const uint TPM_E_PPI_ACPI_FAILURE = 0x80290300;

		/// <summary>The user failed to confirm the TPM operation request.</summary>
		public const uint TPM_E_PPI_USER_ABORT = 0x80290301;

		/// <summary>The BIOS failure prevented the successful execution of the requested TPM operation (for example, invalid TPM operation request, BIOS communication error with the TPM).</summary>
		public const uint TPM_E_PPI_BIOS_FAILURE = 0x80290302;

		/// <summary>The BIOS does not support the physical presence interface.</summary>
		public const uint TPM_E_PPI_NOT_SUPPORTED = 0x80290303;

		/// <summary>A Data Collector Set was not found.</summary>
		public const uint PLA_E_DCS_NOT_FOUND = 0x80300002;

		/// <summary>Unable to start Data Collector Set because there are too many folders.</summary>
		public const uint PLA_E_TOO_MANY_FOLDERS = 0x80300045;

		/// <summary>Not enough free disk space to start Data Collector Set.</summary>
		public const uint PLA_E_NO_MIN_DISK = 0x80300070;

		/// <summary>Data Collector Set is in use.</summary>
		public const uint PLA_E_DCS_IN_USE = 0x803000AA;

		/// <summary>Data Collector Set already exists.</summary>
		public const uint PLA_E_DCS_ALREADY_EXISTS = 0x803000B7;

		/// <summary>Property value conflict.</summary>
		public const uint PLA_E_PROPERTY_CONFLICT = 0x80300101;

		/// <summary>The current configuration for this Data Collector Set requires that it contain exactly one Data Collector.</summary>
		public const uint PLA_E_DCS_SINGLETON_REQUIRED = 0x80300102;

		/// <summary>A user account is required to commit the current Data Collector Set properties.</summary>
		public const uint PLA_E_CREDENTIALS_REQUIRED = 0x80300103;

		/// <summary>Data Collector Set is not running.</summary>
		public const uint PLA_E_DCS_NOT_RUNNING = 0x80300104;

		/// <summary>A conflict was detected in the list of include and exclude APIs. Do not specify the same API in both the include list and the exclude list.</summary>
		public const uint PLA_E_CONFLICT_INCL_EXCL_API = 0x80300105;

		/// <summary>The executable path specified refers to a network share or UNC path.</summary>
		public const uint PLA_E_NETWORK_EXE_NOT_VALID = 0x80300106;

		/// <summary>The executable path specified is already configured for API tracing.</summary>
		public const uint PLA_E_EXE_ALREADY_CONFIGURED = 0x80300107;

		/// <summary>The executable path specified does not exist. Verify that the specified path is correct.</summary>
		public const uint PLA_E_EXE_PATH_NOT_VALID = 0x80300108;

		/// <summary>Data Collector already exists.</summary>
		public const uint PLA_E_DC_ALREADY_EXISTS = 0x80300109;

		/// <summary>The wait for the Data Collector Set start notification has timed out.</summary>
		public const uint PLA_E_DCS_START_WAIT_TIMEOUT = 0x8030010A;

		/// <summary>The wait for the Data Collector to start has timed out.</summary>
		public const uint PLA_E_DC_START_WAIT_TIMEOUT = 0x8030010B;

		/// <summary>The wait for the report generation tool to finish has timed out.</summary>
		public const uint PLA_E_REPORT_WAIT_TIMEOUT = 0x8030010C;

		/// <summary>Duplicate items are not allowed.</summary>
		public const uint PLA_E_NO_DUPLICATES = 0x8030010D;

		/// <summary>When specifying the executable to trace, you must specify a full path to the executable and not just a file name.</summary>
		public const uint PLA_E_EXE_FULL_PATH_REQUIRED = 0x8030010E;

		/// <summary>The session name provided is invalid.</summary>
		public const uint PLA_E_INVALID_SESSION_NAME = 0x8030010F;

		/// <summary>The Event Log channel Microsoft-Windows-Diagnosis-PLA/Operational must be enabled to perform this operation.</summary>
		public const uint PLA_E_PLA_CHANNEL_NOT_ENABLED = 0x80300110;

		/// <summary>The Event Log channel Microsoft-Windows-TaskScheduler must be enabled to perform this operation.</summary>
		public const uint PLA_E_TASKSCHED_CHANNEL_NOT_ENABLED = 0x80300111;

		/// <summary>The volume must be unlocked before it can be used.</summary>
		public const uint FVE_E_LOCKED_VOLUME = 0x80310000;

		/// <summary>The volume is fully decrypted and no key is available.</summary>
		public const uint FVE_E_NOT_ENCRYPTED = 0x80310001;

		/// <summary>The firmware does not support using a TPM during boot.</summary>
		public const uint FVE_E_NO_TPM_BIOS = 0x80310002;

		/// <summary>The firmware does not use a TPM to perform initial program load (IPL) measurement.</summary>
		public const uint FVE_E_NO_MBR_METRIC = 0x80310003;

		/// <summary>The master boot record (MBR) is not TPM-aware.</summary>
		public const uint FVE_E_NO_BOOTSECTOR_METRIC = 0x80310004;

		/// <summary>The BOOTMGR is not being measured by the TPM.</summary>
		public const uint FVE_E_NO_BOOTMGR_METRIC = 0x80310005;

		/// <summary>The BOOTMGR component does not perform expected TPM measurements.</summary>
		public const uint FVE_E_WRONG_BOOTMGR = 0x80310006;

		/// <summary>No secure key protection mechanism has been defined.</summary>
		public const uint FVE_E_SECURE_KEY_REQUIRED = 0x80310007;

		/// <summary>This volume has not been provisioned for encryption.</summary>
		public const uint FVE_E_NOT_ACTIVATED = 0x80310008;

		/// <summary>Requested action was denied by the full-volume encryption (FVE) control engine.</summary>
		public const uint FVE_E_ACTION_NOT_ALLOWED = 0x80310009;

		/// <summary>The Active Directory forest does not contain the required attributes and classes to host FVE or TPM information.</summary>
		public const uint FVE_E_AD_SCHEMA_NOT_INSTALLED = 0x8031000A;

		/// <summary>The type of data obtained from Active Directory was not expected.</summary>
		public const uint FVE_E_AD_INVALID_DATATYPE = 0x8031000B;

		/// <summary>The size of the data obtained from Active Directory was not expected.</summary>
		public const uint FVE_E_AD_INVALID_DATASIZE = 0x8031000C;

		/// <summary>The attribute read from Active Directory has no (zero) values.</summary>
		public const uint FVE_E_AD_NO_VALUES = 0x8031000D;

		/// <summary>The attribute was not set.</summary>
		public const uint FVE_E_AD_ATTR_NOT_SET = 0x8031000E;

		/// <summary>The specified GUID could not be found.</summary>
		public const uint FVE_E_AD_GUID_NOT_FOUND = 0x8031000F;

		/// <summary>The control block for the encrypted volume is not valid.</summary>
		public const uint FVE_E_BAD_INFORMATION = 0x80310010;

		/// <summary>Not enough free space remaining on volume to allow encryption.</summary>
		public const uint FVE_E_TOO_SMALL = 0x80310011;

		/// <summary>The volume cannot be encrypted because it is required to boot the operating system.</summary>
		public const uint FVE_E_SYSTEM_VOLUME = 0x80310012;

		/// <summary>The volume cannot be encrypted because the file system is not supported.</summary>
		public const uint FVE_E_FAILED_WRONG_FS = 0x80310013;

		/// <summary>The file system is inconsistent. Run CHKDSK.</summary>
		public const uint FVE_E_FAILED_BAD_FS = 0x80310014;

		/// <summary>This volume cannot be encrypted.</summary>
		public const uint FVE_E_NOT_SUPPORTED = 0x80310015;

		/// <summary>Data supplied is malformed.</summary>
		public const uint FVE_E_BAD_DATA = 0x80310016;

		/// <summary>Volume is not bound to the system.</summary>
		public const uint FVE_E_VOLUME_NOT_BOUND = 0x80310017;

		/// <summary>TPM must be owned before a volume can be bound to it.</summary>
		public const uint FVE_E_TPM_NOT_OWNED = 0x80310018;

		/// <summary>The volume specified is not a data volume.</summary>
		public const uint FVE_E_NOT_DATA_VOLUME = 0x80310019;

		/// <summary>The buffer supplied to a function was insufficient to contain the returned data.</summary>
		public const uint FVE_E_AD_INSUFFICIENT_BUFFER = 0x8031001A;

		/// <summary>A read operation failed while converting the volume.</summary>
		public const uint FVE_E_CONV_READ = 0x8031001B;

		/// <summary>A write operation failed while converting the volume.</summary>
		public const uint FVE_E_CONV_WRITE = 0x8031001C;

		/// <summary>One or more key protection mechanisms are required for this volume.</summary>
		public const uint FVE_E_KEY_REQUIRED = 0x8031001D;

		/// <summary>Cluster configurations are not supported.</summary>
		public const uint FVE_E_CLUSTERING_NOT_SUPPORTED = 0x8031001E;

		/// <summary>The volume is already bound to the system.</summary>
		public const uint FVE_E_VOLUME_BOUND_ALREADY = 0x8031001F;

		/// <summary>The boot OS volume is not being protected via FVE.</summary>
		public const uint FVE_E_OS_NOT_PROTECTED = 0x80310020;

		/// <summary>All protection mechanisms are effectively disabled (clear key exists).</summary>
		public const uint FVE_E_PROTECTION_DISABLED = 0x80310021;

		/// <summary>A recovery key protection mechanism is required.</summary>
		public const uint FVE_E_RECOVERY_KEY_REQUIRED = 0x80310022;

		/// <summary>This volume cannot be bound to a TPM.</summary>
		public const uint FVE_E_FOREIGN_VOLUME = 0x80310023;

		/// <summary>The control block for the encrypted volume was updated by another thread. Try again.</summary>
		public const uint FVE_E_OVERLAPPED_UPDATE = 0x80310024;

		/// <summary>The SRK authentication of the TPM is not zero and, therefore, is not compatible.</summary>
		public const uint FVE_E_TPM_SRK_AUTH_NOT_ZERO = 0x80310025;

		/// <summary>The volume encryption algorithm cannot be used on this sector size.</summary>
		public const uint FVE_E_FAILED_SECTOR_SIZE = 0x80310026;

		/// <summary>BitLocker recovery authentication failed.</summary>
		public const uint FVE_E_FAILED_AUTHENTICATION = 0x80310027;

		/// <summary>The volume specified is not the boot OS volume.</summary>
		public const uint FVE_E_NOT_OS_VOLUME = 0x80310028;

		/// <summary>Auto-unlock information for data volumes is present on the boot OS volume.</summary>
		public const uint FVE_E_AUTOUNLOCK_ENABLED = 0x80310029;

		/// <summary>The system partition boot sector does not perform TPM measurements.</summary>
		public const uint FVE_E_WRONG_BOOTSECTOR = 0x8031002A;

		/// <summary>The system partition file system must be NTFS.</summary>
		public const uint FVE_E_WRONG_SYSTEM_FS = 0x8031002B;

		/// <summary>Group policy requires a recovery password before encryption can begin.</summary>
		public const uint FVE_E_POLICY_PASSWORD_REQUIRED = 0x8031002C;

		/// <summary>The volume encryption algorithm and key cannot be set on an encrypted volume.</summary>
		public const uint FVE_E_CANNOT_SET_FVEK_ENCRYPTED = 0x8031002D;

		/// <summary>A key must be specified before encryption can begin.</summary>
		public const uint FVE_E_CANNOT_ENCRYPT_NO_KEY = 0x8031002E;

		/// <summary>A bootable CD/DVD is in the system. Remove the CD/DVD and reboot the system.</summary>
		public const uint FVE_E_BOOTABLE_CDDVD = 0x80310030;

		/// <summary>An instance of this key protector already exists on the volume.</summary>
		public const uint FVE_E_PROTECTOR_EXISTS = 0x80310031;

		/// <summary>The file cannot be saved to a relative path.</summary>
		public const uint FVE_E_RELATIVE_PATH = 0x80310032;

		/// <summary>The callout does not exist.</summary>
		public const uint FWP_E_CALLOUT_NOT_FOUND = 0x80320001;

		/// <summary>The filter condition does not exist.</summary>
		public const uint FWP_E_CONDITION_NOT_FOUND = 0x80320002;

		/// <summary>The filter does not exist.</summary>
		public const uint FWP_E_FILTER_NOT_FOUND = 0x80320003;

		/// <summary>The layer does not exist.</summary>
		public const uint FWP_E_LAYER_NOT_FOUND = 0x80320004;

		/// <summary>The provider does not exist.</summary>
		public const uint FWP_E_PROVIDER_NOT_FOUND = 0x80320005;

		/// <summary>The provider context does not exist.</summary>
		public const uint FWP_E_PROVIDER_CONTEXT_NOT_FOUND = 0x80320006;

		/// <summary>The sublayer does not exist.</summary>
		public const uint FWP_E_SUBLAYER_NOT_FOUND = 0x80320007;

		/// <summary>The object does not exist.</summary>
		public const uint FWP_E_NOT_FOUND = 0x80320008;

		/// <summary>An object with that GUID or LUID already exists.</summary>
		public const uint FWP_E_ALREADY_EXISTS = 0x80320009;

		/// <summary>The object is referenced by other objects and, therefore, cannot be deleted.</summary>
		public const uint FWP_E_IN_USE = 0x8032000A;

		/// <summary>The call is not allowed from within a dynamic session.</summary>
		public const uint FWP_E_DYNAMIC_SESSION_IN_PROGRESS = 0x8032000B;

		/// <summary>The call was made from the wrong session and, therefore, cannot be completed.</summary>
		public const uint FWP_E_WRONG_SESSION = 0x8032000C;

		/// <summary>The call must be made from within an explicit transaction.</summary>
		public const uint FWP_E_NO_TXN_IN_PROGRESS = 0x8032000D;

		/// <summary>The call is not allowed from within an explicit transaction.</summary>
		public const uint FWP_E_TXN_IN_PROGRESS = 0x8032000E;

		/// <summary>The explicit transaction has been forcibly canceled.</summary>
		public const uint FWP_E_TXN_ABORTED = 0x8032000F;

		/// <summary>The session has been canceled.</summary>
		public const uint FWP_E_SESSION_ABORTED = 0x80320010;

		/// <summary>The call is not allowed from within a read-only transaction.</summary>
		public const uint FWP_E_INCOMPATIBLE_TXN = 0x80320011;

		/// <summary>The call timed out while waiting to acquire the transaction lock.</summary>
		public const uint FWP_E_TIMEOUT = 0x80320012;

		/// <summary>Collection of network diagnostic events is disabled.</summary>
		public const uint FWP_E_NET_EVENTS_DISABLED = 0x80320013;

		/// <summary>The operation is not supported by the specified layer.</summary>
		public const uint FWP_E_INCOMPATIBLE_LAYER = 0x80320014;

		/// <summary>The call is allowed for kernel-mode callers only.</summary>
		public const uint FWP_E_KM_CLIENTS_ONLY = 0x80320015;

		/// <summary>The call tried to associate two objects with incompatible lifetimes.</summary>
		public const uint FWP_E_LIFETIME_MISMATCH = 0x80320016;

		/// <summary>The object is built in and, therefore, cannot be deleted.</summary>
		public const uint FWP_E_BUILTIN_OBJECT = 0x80320017;

		/// <summary>The maximum number of boot-time filters has been reached.</summary>
		public const uint FWP_E_TOO_MANY_BOOTTIME_FILTERS = 0x80320018;

		/// <summary>A notification could not be delivered because a message queue is at its maximum capacity.</summary>
		public const uint FWP_E_NOTIFICATION_DROPPED = 0x80320019;

		/// <summary>The traffic parameters do not match those for the security association context.</summary>
		public const uint FWP_E_TRAFFIC_MISMATCH = 0x8032001A;

		/// <summary>The call is not allowed for the current security association state.</summary>
		public const uint FWP_E_INCOMPATIBLE_SA_STATE = 0x8032001B;

		/// <summary>A required pointer is null.</summary>
		public const uint FWP_E_NULL_POINTER = 0x8032001C;

		/// <summary>An enumerator is not valid.</summary>
		public const uint FWP_E_INVALID_ENUMERATOR = 0x8032001D;

		/// <summary>The flags field contains an invalid value.</summary>
		public const uint FWP_E_INVALID_FLAGS = 0x8032001E;

		/// <summary>A network mask is not valid.</summary>
		public const uint FWP_E_INVALID_NET_MASK = 0x8032001F;

		/// <summary>An FWP_RANGE is not valid.</summary>
		public const uint FWP_E_INVALID_RANGE = 0x80320020;

		/// <summary>The time interval is not valid.</summary>
		public const uint FWP_E_INVALID_INTERVAL = 0x80320021;

		/// <summary>An array that must contain at least one element that is zero-length.</summary>
		public const uint FWP_E_ZERO_LENGTH_ARRAY = 0x80320022;

		/// <summary>The displayData.name field cannot be null.</summary>
		public const uint FWP_E_NULL_DISPLAY_NAME = 0x80320023;

		/// <summary>The action type is not one of the allowed action types for a filter.</summary>
		public const uint FWP_E_INVALID_ACTION_TYPE = 0x80320024;

		/// <summary>The filter weight is not valid.</summary>
		public const uint FWP_E_INVALID_WEIGHT = 0x80320025;

		/// <summary>A filter condition contains a match type that is not compatible with the operands.</summary>
		public const uint FWP_E_MATCH_TYPE_MISMATCH = 0x80320026;

		/// <summary>An FWP_VALUE or FWPM_CONDITION_VALUE is of the wrong type.</summary>
		public const uint FWP_E_TYPE_MISMATCH = 0x80320027;

		/// <summary>An integer value is outside the allowed range.</summary>
		public const uint FWP_E_OUT_OF_BOUNDS = 0x80320028;

		/// <summary>A reserved field is nonzero.</summary>
		public const uint FWP_E_RESERVED = 0x80320029;

		/// <summary>A filter cannot contain multiple conditions operating on a single field.</summary>
		public const uint FWP_E_DUPLICATE_CONDITION = 0x8032002A;

		/// <summary>A policy cannot contain the same keying module more than once.</summary>
		public const uint FWP_E_DUPLICATE_KEYMOD = 0x8032002B;

		/// <summary>The action type is not compatible with the layer.</summary>
		public const uint FWP_E_ACTION_INCOMPATIBLE_WITH_LAYER = 0x8032002C;

		/// <summary>The action type is not compatible with the sublayer.</summary>
		public const uint FWP_E_ACTION_INCOMPATIBLE_WITH_SUBLAYER = 0x8032002D;

		/// <summary>The raw context or the provider context is not compatible with the layer.</summary>
		public const uint FWP_E_CONTEXT_INCOMPATIBLE_WITH_LAYER = 0x8032002E;

		/// <summary>The raw context or the provider context is not compatible with the callout.</summary>
		public const uint FWP_E_CONTEXT_INCOMPATIBLE_WITH_CALLOUT = 0x8032002F;

		/// <summary>The authentication method is not compatible with the policy type.</summary>
		public const uint FWP_E_INCOMPATIBLE_AUTH_METHOD = 0x80320030;

		/// <summary>The Diffie-Hellman group is not compatible with the policy type.</summary>
		public const uint FWP_E_INCOMPATIBLE_DH_GROUP = 0x80320031;

		/// <summary>An Internet Key Exchange (IKE) policy cannot contain an Extended Mode policy.</summary>
		public const uint FWP_E_EM_NOT_SUPPORTED = 0x80320032;

		/// <summary>The enumeration template or subscription will never match any objects.</summary>
		public const uint FWP_E_NEVER_MATCH = 0x80320033;

		/// <summary>The provider context is of the wrong type.</summary>
		public const uint FWP_E_PROVIDER_CONTEXT_MISMATCH = 0x80320034;

		/// <summary>The parameter is incorrect.</summary>
		public const uint FWP_E_INVALID_PARAMETER = 0x80320035;

		/// <summary>The maximum number of sublayers has been reached.</summary>
		public const uint FWP_E_TOO_MANY_SUBLAYERS = 0x80320036;

		/// <summary>The notification function for a callout returned an error.</summary>
		public const uint FWP_E_CALLOUT_NOTIFICATION_FAILED = 0x80320037;

		/// <summary>The IPsec authentication configuration is not compatible with the authentication type.</summary>
		public const uint FWP_E_INCOMPATIBLE_AUTH_CONFIG = 0x80320038;

		/// <summary>The IPsec cipher configuration is not compatible with the cipher type.</summary>
		public const uint FWP_E_INCOMPATIBLE_CIPHER_CONFIG = 0x80320039;

		/// <summary>The binding to the network interface is being closed.</summary>
		public const uint ERROR_NDIS_INTERFACE_CLOSING = 0x80340002;

		/// <summary>An invalid version was specified.</summary>
		public const uint ERROR_NDIS_BAD_VERSION = 0x80340004;

		/// <summary>An invalid characteristics table was used.</summary>
		public const uint ERROR_NDIS_BAD_CHARACTERISTICS = 0x80340005;

		/// <summary>Failed to find the network interface, or the network interface is not ready.</summary>
		public const uint ERROR_NDIS_ADAPTER_NOT_FOUND = 0x80340006;

		/// <summary>Failed to open the network interface.</summary>
		public const uint ERROR_NDIS_OPEN_FAILED = 0x80340007;

		/// <summary>The network interface has encountered an internal unrecoverable failure.</summary>
		public const uint ERROR_NDIS_DEVICE_FAILED = 0x80340008;

		/// <summary>The multicast list on the network interface is full.</summary>
		public const uint ERROR_NDIS_MULTICAST_FULL = 0x80340009;

		/// <summary>An attempt was made to add a duplicate multicast address to the list.</summary>
		public const uint ERROR_NDIS_MULTICAST_EXISTS = 0x8034000A;

		/// <summary>At attempt was made to remove a multicast address that was never added.</summary>
		public const uint ERROR_NDIS_MULTICAST_NOT_FOUND = 0x8034000B;

		/// <summary>The network interface aborted the request.</summary>
		public const uint ERROR_NDIS_REQUEST_ABORTED = 0x8034000C;

		/// <summary>The network interface cannot process the request because it is being reset.</summary>
		public const uint ERROR_NDIS_RESET_IN_PROGRESS = 0x8034000D;

		/// <summary>An attempt was made to send an invalid packet on a network interface.</summary>
		public const uint ERROR_NDIS_INVALID_PACKET = 0x8034000F;

		/// <summary>The specified request is not a valid operation for the target device.</summary>
		public const uint ERROR_NDIS_INVALID_DEVICE_REQUEST = 0x80340010;

		/// <summary>The network interface is not ready to complete this operation.</summary>
		public const uint ERROR_NDIS_ADAPTER_NOT_READY = 0x80340011;

		/// <summary>The length of the buffer submitted for this operation is not valid.</summary>
		public const uint ERROR_NDIS_INVALID_LENGTH = 0x80340014;

		/// <summary>The data used for this operation is not valid.</summary>
		public const uint ERROR_NDIS_INVALID_DATA = 0x80340015;

		/// <summary>The length of the buffer submitted for this operation is too small.</summary>
		public const uint ERROR_NDIS_BUFFER_TOO_SHORT = 0x80340016;

		/// <summary>The network interface does not support this OID.</summary>
		public const uint ERROR_NDIS_INVALID_OID = 0x80340017;

		/// <summary>The network interface has been removed.</summary>
		public const uint ERROR_NDIS_ADAPTER_REMOVED = 0x80340018;

		/// <summary>The network interface does not support this media type.</summary>
		public const uint ERROR_NDIS_UNSUPPORTED_MEDIA = 0x80340019;

		/// <summary>An attempt was made to remove a token ring group address that is in use by other components.</summary>
		public const uint ERROR_NDIS_GROUP_ADDRESS_IN_USE = 0x8034001A;

		/// <summary>An attempt was made to map a file that cannot be found.</summary>
		public const uint ERROR_NDIS_FILE_NOT_FOUND = 0x8034001B;

		/// <summary>An error occurred while the NDIS tried to map the file.</summary>
		public const uint ERROR_NDIS_ERROR_READING_FILE = 0x8034001C;

		/// <summary>An attempt was made to map a file that is already mapped.</summary>
		public const uint ERROR_NDIS_ALREADY_MAPPED = 0x8034001D;

		/// <summary>An attempt to allocate a hardware resource failed because the resource is used by another component.</summary>
		public const uint ERROR_NDIS_RESOURCE_CONFLICT = 0x8034001E;

		/// <summary>The I/O operation failed because network media is disconnected or the wireless access point is out of range.</summary>
		public const uint ERROR_NDIS_MEDIA_DISCONNECTED = 0x8034001F;

		/// <summary>The network address used in the request is invalid.</summary>
		public const uint ERROR_NDIS_INVALID_ADDRESS = 0x80340022;

		/// <summary>The offload operation on the network interface has been paused.</summary>
		public const uint ERROR_NDIS_PAUSED = 0x8034002A;

		/// <summary>The network interface was not found.</summary>
		public const uint ERROR_NDIS_INTERFACE_NOT_FOUND = 0x8034002B;

		/// <summary>The revision number specified in the structure is not supported.</summary>
		public const uint ERROR_NDIS_UNSUPPORTED_REVISION = 0x8034002C;

		/// <summary>The specified port does not exist on this network interface.</summary>
		public const uint ERROR_NDIS_INVALID_PORT = 0x8034002D;

		/// <summary>The current state of the specified port on this network interface does not support the requested operation.</summary>
		public const uint ERROR_NDIS_INVALID_PORT_STATE = 0x8034002E;

		/// <summary>The network interface does not support this request.</summary>
		public const uint ERROR_NDIS_NOT_SUPPORTED = 0x803400BB;

		/// <summary>The wireless local area network (LAN) interface is in auto-configuration mode and does not support the requested parameter change operation.</summary>
		public const uint ERROR_NDIS_DOT11_AUTO_CONFIG_ENABLED = 0x80342000;

		/// <summary>The wireless LAN interface is busy and cannot perform the requested operation.</summary>
		public const uint ERROR_NDIS_DOT11_MEDIA_IN_USE = 0x80342001;

		/// <summary>The wireless LAN interface is shutting down and does not support the requested operation.</summary>
		public const uint ERROR_NDIS_DOT11_POWER_STATE_INVALID = 0x80342002;

		/// <summary>A requested object was not found.</summary>
		public const uint TRK_E_NOT_FOUND = 0x8DEAD01B;

		/// <summary>The server received a CREATE_VOLUME subrequest of a SYNC_VOLUMES request, but the ServerVolumeTable size limit for the RequestMachine has already been reached.</summary>
		public const uint TRK_E_VOLUME_QUOTA_EXCEEDED = 0x8DEAD01C;

		/// <summary>The server is busy, and the client should retry the request at a later time.</summary>
		public const uint TRK_SERVER_TOO_BUSY = 0x8DEAD01E;

		/// <summary>The specified event is currently not being audited.</summary>
		public const uint ERROR_AUDITING_DISABLED = 0xC0090001;

		/// <summary>The SID filtering operation removed all SIDs.</summary>
		public const uint ERROR_ALL_SIDS_FILTERED = 0xC0090002;

		/// <summary>Business rule scripts are disabled for the calling application.</summary>
		public const uint ERROR_BIZRULES_NOT_ENABLED = 0xC0090003;

		/// <summary>There is no connection established with the Windows Media server. The operation failed.</summary>
		public const uint NS_E_NOCONNECTION = 0xC00D0005;

		/// <summary>Unable to establish a connection to the server.</summary>
		public const uint NS_E_CANNOTCONNECT = 0xC00D0006;

		/// <summary>Unable to destroy the title.</summary>
		public const uint NS_E_CANNOTDESTROYTITLE = 0xC00D0007;

		/// <summary>Unable to rename the title.</summary>
		public const uint NS_E_CANNOTRENAMETITLE = 0xC00D0008;

		/// <summary>Unable to offline disk.</summary>
		public const uint NS_E_CANNOTOFFLINEDISK = 0xC00D0009;

		/// <summary>Unable to online disk.</summary>
		public const uint NS_E_CANNOTONLINEDISK = 0xC00D000A;

		/// <summary>There is no file parser registered for this type of file.</summary>
		public const uint NS_E_NOREGISTEREDWALKER = 0xC00D000B;

		/// <summary>There is no data connection established.</summary>
		public const uint NS_E_NOFUNNEL = 0xC00D000C;

		/// <summary>Failed to load the local play DLL.</summary>
		public const uint NS_E_NO_LOCALPLAY = 0xC00D000D;

		/// <summary>The network is busy.</summary>
		public const uint NS_E_NETWORK_BUSY = 0xC00D000E;

		/// <summary>The server session limit was exceeded.</summary>
		public const uint NS_E_TOO_MANY_SESS = 0xC00D000F;

		/// <summary>The network connection already exists.</summary>
		public const uint NS_E_ALREADY_CONNECTED = 0xC00D0010;

		/// <summary>Index %1 is invalid.</summary>
		public const uint NS_E_INVALID_INDEX = 0xC00D0011;

		/// <summary>There is no protocol or protocol version supported by both the client and the server.</summary>
		public const uint NS_E_PROTOCOL_MISMATCH = 0xC00D0012;

		/// <summary>The server, a computer set up to offer multimedia content to other computers, could not handle your request for multimedia content in a timely manner. Please try again later.</summary>
		public const uint NS_E_TIMEOUT = 0xC00D0013;

		/// <summary>Error writing to the network.</summary>
		public const uint NS_E_NET_WRITE = 0xC00D0014;

		/// <summary>Error reading from the network.</summary>
		public const uint NS_E_NET_READ = 0xC00D0015;

		/// <summary>Error writing to a disk.</summary>
		public const uint NS_E_DISK_WRITE = 0xC00D0016;

		/// <summary>Error reading from a disk.</summary>
		public const uint NS_E_DISK_READ = 0xC00D0017;

		/// <summary>Error writing to a file.</summary>
		public const uint NS_E_FILE_WRITE = 0xC00D0018;

		/// <summary>Error reading from a file.</summary>
		public const uint NS_E_FILE_READ = 0xC00D0019;

		/// <summary>The system cannot find the file specified.</summary>
		public const uint NS_E_FILE_NOT_FOUND = 0xC00D001A;

		/// <summary>The file already exists.</summary>
		public const uint NS_E_FILE_EXISTS = 0xC00D001B;

		/// <summary>The file name, directory name, or volume label syntax is incorrect.</summary>
		public const uint NS_E_INVALID_NAME = 0xC00D001C;

		/// <summary>Failed to open a file.</summary>
		public const uint NS_E_FILE_OPEN_FAILED = 0xC00D001D;

		/// <summary>Unable to allocate a file.</summary>
		public const uint NS_E_FILE_ALLOCATION_FAILED = 0xC00D001E;

		/// <summary>Unable to initialize a file.</summary>
		public const uint NS_E_FILE_INIT_FAILED = 0xC00D001F;

		/// <summary>Unable to play a file.</summary>
		public const uint NS_E_FILE_PLAY_FAILED = 0xC00D0020;

		/// <summary>Could not set the disk UID.</summary>
		public const uint NS_E_SET_DISK_UID_FAILED = 0xC00D0021;

		/// <summary>An error was induced for testing purposes.</summary>
		public const uint NS_E_INDUCED = 0xC00D0022;

		/// <summary>Two Content Servers failed to communicate.</summary>
		public const uint NS_E_CCLINK_DOWN = 0xC00D0023;

		/// <summary>An unknown error occurred.</summary>
		public const uint NS_E_INTERNAL = 0xC00D0024;

		/// <summary>The requested resource is in use.</summary>
		public const uint NS_E_BUSY = 0xC00D0025;

		/// <summary>The specified protocol is not recognized. Be sure that the file name and syntax, such as slashes, are correct for the protocol.</summary>
		public const uint NS_E_UNRECOGNIZED_STREAM_TYPE = 0xC00D0026;

		/// <summary>The network service provider failed.</summary>
		public const uint NS_E_NETWORK_SERVICE_FAILURE = 0xC00D0027;

		/// <summary>An attempt to acquire a network resource failed.</summary>
		public const uint NS_E_NETWORK_RESOURCE_FAILURE = 0xC00D0028;

		/// <summary>The network connection has failed.</summary>
		public const uint NS_E_CONNECTION_FAILURE = 0xC00D0029;

		/// <summary>The session is being terminated locally.</summary>
		public const uint NS_E_SHUTDOWN = 0xC00D002A;

		/// <summary>The request is invalid in the current state.</summary>
		public const uint NS_E_INVALID_REQUEST = 0xC00D002B;

		/// <summary>There is insufficient bandwidth available to fulfill the request.</summary>
		public const uint NS_E_INSUFFICIENT_BANDWIDTH = 0xC00D002C;

		/// <summary>The disk is not rebuilding.</summary>
		public const uint NS_E_NOT_REBUILDING = 0xC00D002D;

		/// <summary>An operation requested for a particular time could not be carried out on schedule.</summary>
		public const uint NS_E_LATE_OPERATION = 0xC00D002E;

		/// <summary>Invalid or corrupt data was encountered.</summary>
		public const uint NS_E_INVALID_DATA = 0xC00D002F;

		/// <summary>The bandwidth required to stream a file is higher than the maximum file bandwidth allowed on the server.</summary>
		public const uint NS_E_FILE_BANDWIDTH_LIMIT = 0xC00D0030;

		/// <summary>The client cannot have any more files open simultaneously.</summary>
		public const uint NS_E_OPEN_FILE_LIMIT = 0xC00D0031;

		/// <summary>The server received invalid data from the client on the control connection.</summary>
		public const uint NS_E_BAD_CONTROL_DATA = 0xC00D0032;

		/// <summary>There is no stream available.</summary>
		public const uint NS_E_NO_STREAM = 0xC00D0033;

		/// <summary>There is no more data in the stream.</summary>
		public const uint NS_E_STREAM_END = 0xC00D0034;

		/// <summary>The specified server could not be found.</summary>
		public const uint NS_E_SERVER_NOT_FOUND = 0xC00D0035;

		/// <summary>The specified name is already in use.</summary>
		public const uint NS_E_DUPLICATE_NAME = 0xC00D0036;

		/// <summary>The specified address is already in use.</summary>
		public const uint NS_E_DUPLICATE_ADDRESS = 0xC00D0037;

		/// <summary>The specified address is not a valid multicast address.</summary>
		public const uint NS_E_BAD_MULTICAST_ADDRESS = 0xC00D0038;

		/// <summary>The specified adapter address is invalid.</summary>
		public const uint NS_E_BAD_ADAPTER_ADDRESS = 0xC00D0039;

		/// <summary>The specified delivery mode is invalid.</summary>
		public const uint NS_E_BAD_DELIVERY_MODE = 0xC00D003A;

		/// <summary>The specified station does not exist.</summary>
		public const uint NS_E_INVALID_CHANNEL = 0xC00D003B;

		/// <summary>The specified stream does not exist.</summary>
		public const uint NS_E_INVALID_STREAM = 0xC00D003C;

		/// <summary>The specified archive could not be opened.</summary>
		public const uint NS_E_INVALID_ARCHIVE = 0xC00D003D;

		/// <summary>The system cannot find any titles on the server.</summary>
		public const uint NS_E_NOTITLES = 0xC00D003E;

		/// <summary>The system cannot find the client specified.</summary>
		public const uint NS_E_INVALID_CLIENT = 0xC00D003F;

		/// <summary>The Blackhole Address is not initialized.</summary>
		public const uint NS_E_INVALID_BLACKHOLE_ADDRESS = 0xC00D0040;

		/// <summary>The station does not support the stream format.</summary>
		public const uint NS_E_INCOMPATIBLE_FORMAT = 0xC00D0041;

		/// <summary>The specified key is not valid.</summary>
		public const uint NS_E_INVALID_KEY = 0xC00D0042;

		/// <summary>The specified port is not valid.</summary>
		public const uint NS_E_INVALID_PORT = 0xC00D0043;

		/// <summary>The specified TTL is not valid.</summary>
		public const uint NS_E_INVALID_TTL = 0xC00D0044;

		/// <summary>The request to fast forward or rewind could not be fulfilled.</summary>
		public const uint NS_E_STRIDE_REFUSED = 0xC00D0045;

		/// <summary>Unable to load the appropriate file parser.</summary>
		public const uint NS_E_MMSAUTOSERVER_CANTFINDWALKER = 0xC00D0046;

		/// <summary>Cannot exceed the maximum bandwidth limit.</summary>
		public const uint NS_E_MAX_BITRATE = 0xC00D0047;

		/// <summary>Invalid value for LogFilePeriod.</summary>
		public const uint NS_E_LOGFILEPERIOD = 0xC00D0048;

		/// <summary>Cannot exceed the maximum client limit.</summary>
		public const uint NS_E_MAX_CLIENTS = 0xC00D0049;

		/// <summary>The maximum log file size has been reached.</summary>
		public const uint NS_E_LOG_FILE_SIZE = 0xC00D004A;

		/// <summary>Cannot exceed the maximum file rate.</summary>
		public const uint NS_E_MAX_FILERATE = 0xC00D004B;

		/// <summary>Unknown file type.</summary>
		public const uint NS_E_WALKER_UNKNOWN = 0xC00D004C;

		/// <summary>The specified file, %1, cannot be loaded onto the specified server, %2.</summary>
		public const uint NS_E_WALKER_SERVER = 0xC00D004D;

		/// <summary>There was a usage error with file parser.</summary>
		public const uint NS_E_WALKER_USAGE = 0xC00D004E;

		/// <summary>The Title Server %1 has failed.</summary>
		public const uint NS_E_TIGER_FAIL = 0xC00D0050;

		/// <summary>Content Server %1 (%2) has failed.</summary>
		public const uint NS_E_CUB_FAIL = 0xC00D0053;

		/// <summary>Disk %1 ( %2 ) on Content Server %3, has failed.</summary>
		public const uint NS_E_DISK_FAIL = 0xC00D0055;

		/// <summary>The NetShow data stream limit of %1 streams was reached.</summary>
		public const uint NS_E_MAX_FUNNELS_ALERT = 0xC00D0060;

		/// <summary>The NetShow Video Server was unable to allocate a %1 block file named %2.</summary>
		public const uint NS_E_ALLOCATE_FILE_FAIL = 0xC00D0061;

		/// <summary>A Content Server was unable to page a block.</summary>
		public const uint NS_E_PAGING_ERROR = 0xC00D0062;

		/// <summary>Disk %1 has unrecognized control block version %2.</summary>
		public const uint NS_E_BAD_BLOCK0_VERSION = 0xC00D0063;

		/// <summary>Disk %1 has incorrect uid %2.</summary>
		public const uint NS_E_BAD_DISK_UID = 0xC00D0064;

		/// <summary>Disk %1 has unsupported file system major version %2.</summary>
		public const uint NS_E_BAD_FSMAJOR_VERSION = 0xC00D0065;

		/// <summary>Disk %1 has bad stamp number in control block.</summary>
		public const uint NS_E_BAD_STAMPNUMBER = 0xC00D0066;

		/// <summary>Disk %1 is partially reconstructed.</summary>
		public const uint NS_E_PARTIALLY_REBUILT_DISK = 0xC00D0067;

		/// <summary>EnactPlan gives up.</summary>
		public const uint NS_E_ENACTPLAN_GIVEUP = 0xC00D0068;

		/// <summary>The key was not found in the registry.</summary>
		public const uint MCMADM_E_REGKEY_NOT_FOUND = 0xC00D006A;

		/// <summary>The publishing point cannot be started because the server does not have the appropriate stream formats. Use the Multicast Announcement Wizard to create a new announcement for this publishing point.</summary>
		public const uint NS_E_NO_FORMATS = 0xC00D006B;

		/// <summary>No reference URLs were found in an ASX file.</summary>
		public const uint NS_E_NO_REFERENCES = 0xC00D006C;

		/// <summary>Error opening wave device, the device might be in use.</summary>
		public const uint NS_E_WAVE_OPEN = 0xC00D006D;

		/// <summary>Unable to establish a connection to the NetShow event monitor service.</summary>
		public const uint NS_E_CANNOTCONNECTEVENTS = 0xC00D006F;

		/// <summary>No device driver is present on the system.</summary>
		public const uint NS_E_NO_DEVICE = 0xC00D0071;

		/// <summary>No specified device driver is present.</summary>
		public const uint NS_E_NO_SPECIFIED_DEVICE = 0xC00D0072;

		/// <summary>Netshow Events Monitor is not operational and has been disconnected.</summary>
		public const uint NS_E_MONITOR_GIVEUP = 0xC00D00C8;

		/// <summary>Disk %1 is remirrored.</summary>
		public const uint NS_E_REMIRRORED_DISK = 0xC00D00C9;

		/// <summary>Insufficient data found.</summary>
		public const uint NS_E_INSUFFICIENT_DATA = 0xC00D00CA;

		/// <summary>1 failed in file %2 line %3.</summary>
		public const uint NS_E_ASSERT = 0xC00D00CB;

		/// <summary>The specified adapter name is invalid.</summary>
		public const uint NS_E_BAD_ADAPTER_NAME = 0xC00D00CC;

		/// <summary>The application is not licensed for this feature.</summary>
		public const uint NS_E_NOT_LICENSED = 0xC00D00CD;

		/// <summary>Unable to contact the server.</summary>
		public const uint NS_E_NO_SERVER_CONTACT = 0xC00D00CE;

		/// <summary>Maximum number of titles exceeded.</summary>
		public const uint NS_E_TOO_MANY_TITLES = 0xC00D00CF;

		/// <summary>Maximum size of a title exceeded.</summary>
		public const uint NS_E_TITLE_SIZE_EXCEEDED = 0xC00D00D0;

		/// <summary>UDP protocol not enabled. Not trying %1!ls!.</summary>
		public const uint NS_E_UDP_DISABLED = 0xC00D00D1;

		/// <summary>TCP protocol not enabled. Not trying %1!ls!.</summary>
		public const uint NS_E_TCP_DISABLED = 0xC00D00D2;

		/// <summary>HTTP protocol not enabled. Not trying %1!ls!.</summary>
		public const uint NS_E_HTTP_DISABLED = 0xC00D00D3;

		/// <summary>The product license has expired.</summary>
		public const uint NS_E_LICENSE_EXPIRED = 0xC00D00D4;

		/// <summary>Source file exceeds the per title maximum bitrate. See NetShow Theater documentation for more information.</summary>
		public const uint NS_E_TITLE_BITRATE = 0xC00D00D5;

		/// <summary>The program name cannot be empty.</summary>
		public const uint NS_E_EMPTY_PROGRAM_NAME = 0xC00D00D6;

		/// <summary>Station %1 does not exist.</summary>
		public const uint NS_E_MISSING_CHANNEL = 0xC00D00D7;

		/// <summary>You need to define at least one station before this operation can complete.</summary>
		public const uint NS_E_NO_CHANNELS = 0xC00D00D8;

		/// <summary>The index specified is invalid.</summary>
		public const uint NS_E_INVALID_INDEX2 = 0xC00D00D9;

		/// <summary>Content Server %1 (%2) has failed its link to Content Server %3.</summary>
		public const uint NS_E_CUB_FAIL_LINK = 0xC00D0190;

		/// <summary>Content Server %1 (%2) has incorrect uid %3.</summary>
		public const uint NS_E_BAD_CUB_UID = 0xC00D0192;

		/// <summary>Server unreliable because multiple components failed.</summary>
		public const uint NS_E_GLITCH_MODE = 0xC00D0195;

		/// <summary>Content Server %1 (%2) is unable to communicate with the Media System Network Protocol.</summary>
		public const uint NS_E_NO_MEDIA_PROTOCOL = 0xC00D019B;

		/// <summary>Nothing to do.</summary>
		public const uint NS_E_NOTHING_TO_DO = 0xC00D07F1;

		/// <summary>Not receiving data from the server.</summary>
		public const uint NS_E_NO_MULTICAST = 0xC00D07F2;

		/// <summary>The input media format is invalid.</summary>
		public const uint NS_E_INVALID_INPUT_FORMAT = 0xC00D0BB8;

		/// <summary>The MSAudio codec is not installed on this system.</summary>
		public const uint NS_E_MSAUDIO_NOT_INSTALLED = 0xC00D0BB9;

		/// <summary>An unexpected error occurred with the MSAudio codec.</summary>
		public const uint NS_E_UNEXPECTED_MSAUDIO_ERROR = 0xC00D0BBA;

		/// <summary>The output media format is invalid.</summary>
		public const uint NS_E_INVALID_OUTPUT_FORMAT = 0xC00D0BBB;

		/// <summary>The object must be fully configured before audio samples can be processed.</summary>
		public const uint NS_E_NOT_CONFIGURED = 0xC00D0BBC;

		/// <summary>You need a license to perform the requested operation on this media file.</summary>
		public const uint NS_E_PROTECTED_CONTENT = 0xC00D0BBD;

		/// <summary>You need a license to perform the requested operation on this media file.</summary>
		public const uint NS_E_LICENSE_REQUIRED = 0xC00D0BBE;

		/// <summary>This media file is corrupted or invalid. Contact the content provider for a new file.</summary>
		public const uint NS_E_TAMPERED_CONTENT = 0xC00D0BBF;

		/// <summary>The license for this media file has expired. Get a new license or contact the content provider for further assistance.</summary>
		public const uint NS_E_LICENSE_OUTOFDATE = 0xC00D0BC0;

		/// <summary>You are not allowed to open this file. Contact the content provider for further assistance.</summary>
		public const uint NS_E_LICENSE_INCORRECT_RIGHTS = 0xC00D0BC1;

		/// <summary>The requested audio codec is not installed on this system.</summary>
		public const uint NS_E_AUDIO_CODEC_NOT_INSTALLED = 0xC00D0BC2;

		/// <summary>An unexpected error occurred with the audio codec.</summary>
		public const uint NS_E_AUDIO_CODEC_ERROR = 0xC00D0BC3;

		/// <summary>The requested video codec is not installed on this system.</summary>
		public const uint NS_E_VIDEO_CODEC_NOT_INSTALLED = 0xC00D0BC4;

		/// <summary>An unexpected error occurred with the video codec.</summary>
		public const uint NS_E_VIDEO_CODEC_ERROR = 0xC00D0BC5;

		/// <summary>The Profile is invalid.</summary>
		public const uint NS_E_INVALIDPROFILE = 0xC00D0BC6;

		/// <summary>A new version of the SDK is needed to play the requested content.</summary>
		public const uint NS_E_INCOMPATIBLE_VERSION = 0xC00D0BC7;

		/// <summary>The requested URL is not available in offline mode.</summary>
		public const uint NS_E_OFFLINE_MODE = 0xC00D0BCA;

		/// <summary>The requested URL cannot be accessed because there is no network connection.</summary>
		public const uint NS_E_NOT_CONNECTED = 0xC00D0BCB;

		/// <summary>The encoding process was unable to keep up with the amount of supplied data.</summary>
		public const uint NS_E_TOO_MUCH_DATA = 0xC00D0BCC;

		/// <summary>The given property is not supported.</summary>
		public const uint NS_E_UNSUPPORTED_PROPERTY = 0xC00D0BCD;

		/// <summary>Windows Media Player cannot copy the files to the CD because they are 8-bit. Convert the files to 16-bit, 44-kHz stereo files by using Sound Recorder or another audio-processing program, and then try again.</summary>
		public const uint NS_E_8BIT_WAVE_UNSUPPORTED = 0xC00D0BCE;

		/// <summary>There are no more samples in the current range.</summary>
		public const uint NS_E_NO_MORE_SAMPLES = 0xC00D0BCF;

		/// <summary>The given sampling rate is invalid.</summary>
		public const uint NS_E_INVALID_SAMPLING_RATE = 0xC00D0BD0;

		/// <summary>The given maximum packet size is too small to accommodate this profile.)</summary>
		public const uint NS_E_MAX_PACKET_SIZE_TOO_SMALL = 0xC00D0BD1;

		/// <summary>The packet arrived too late to be of use.</summary>
		public const uint NS_E_LATE_PACKET = 0xC00D0BD2;

		/// <summary>The packet is a duplicate of one received before.</summary>
		public const uint NS_E_DUPLICATE_PACKET = 0xC00D0BD3;

		/// <summary>Supplied buffer is too small.</summary>
		public const uint NS_E_SDK_BUFFERTOOSMALL = 0xC00D0BD4;

		/// <summary>The wrong number of preprocessing passes was used for the stream's output type.</summary>
		public const uint NS_E_INVALID_NUM_PASSES = 0xC00D0BD5;

		/// <summary>An attempt was made to add, modify, or delete a read only attribute.</summary>
		public const uint NS_E_ATTRIBUTE_READ_ONLY = 0xC00D0BD6;

		/// <summary>An attempt was made to add attribute that is not allowed for the given media type.</summary>
		public const uint NS_E_ATTRIBUTE_NOT_ALLOWED = 0xC00D0BD7;

		/// <summary>The EDL provided is invalid.</summary>
		public const uint NS_E_INVALID_EDL = 0xC00D0BD8;

		/// <summary>The Data Unit Extension data was too large to be used.</summary>
		public const uint NS_E_DATA_UNIT_EXTENSION_TOO_LARGE = 0xC00D0BD9;

		/// <summary>An unexpected error occurred with a DMO codec.</summary>
		public const uint NS_E_CODEC_DMO_ERROR = 0xC00D0BDA;

		/// <summary>This feature has been disabled by group policy.</summary>
		public const uint NS_E_FEATURE_DISABLED_BY_GROUP_POLICY = 0xC00D0BDC;

		/// <summary>This feature is disabled in this SKU.</summary>
		public const uint NS_E_FEATURE_DISABLED_IN_SKU = 0xC00D0BDD;

		/// <summary>There is no CD in the CD drive. Insert a CD, and then try again.</summary>
		public const uint NS_E_NO_CD = 0xC00D0FA0;

		/// <summary>Windows Media Player could not use digital playback to play the CD. To switch to analog playback, on the Tools menu, click Options, and then click the Devices tab. Double-click the CD drive, and then in the Playback area, click Analog. For additional assistance, click Web Help.</summary>
		public const uint NS_E_CANT_READ_DIGITAL = 0xC00D0FA1;

		/// <summary>Windows Media Player no longer detects a connected portable device. Reconnect your portable device, and then try synchronizing the file again.</summary>
		public const uint NS_E_DEVICE_DISCONNECTED = 0xC00D0FA2;

		/// <summary>Windows Media Player cannot play the file. The portable device does not support the specified file type.</summary>
		public const uint NS_E_DEVICE_NOT_SUPPORT_FORMAT = 0xC00D0FA3;

		/// <summary>Windows Media Player could not use digital playback to play the CD. The Player has automatically switched the CD drive to analog playback. To switch back to digital CD playback, use the Devices tab. For additional assistance, click Web Help.</summary>
		public const uint NS_E_SLOW_READ_DIGITAL = 0xC00D0FA4;

		/// <summary>An invalid line error occurred in the mixer.</summary>
		public const uint NS_E_MIXER_INVALID_LINE = 0xC00D0FA5;

		/// <summary>An invalid control error occurred in the mixer.</summary>
		public const uint NS_E_MIXER_INVALID_CONTROL = 0xC00D0FA6;

		/// <summary>An invalid value error occurred in the mixer.</summary>
		public const uint NS_E_MIXER_INVALID_VALUE = 0xC00D0FA7;

		/// <summary>An unrecognized MMRESULT occurred in the mixer.</summary>
		public const uint NS_E_MIXER_UNKNOWN_MMRESULT = 0xC00D0FA8;

		/// <summary>User has stopped the operation.</summary>
		public const uint NS_E_USER_STOP = 0xC00D0FA9;

		/// <summary>Windows Media Player cannot rip the track because a compatible MP3 encoder is not installed on your computer. Install a compatible MP3 encoder or choose a different format to rip to (such as Windows Media Audio).</summary>
		public const uint NS_E_MP3_FORMAT_NOT_FOUND = 0xC00D0FAA;

		/// <summary>Windows Media Player cannot read the CD. The disc might be dirty or damaged. Turn on error correction, and then try again.</summary>
		public const uint NS_E_CD_READ_ERROR_NO_CORRECTION = 0xC00D0FAB;

		/// <summary>Windows Media Player cannot read the CD. The disc might be dirty or damaged or the CD drive might be malfunctioning.</summary>
		public const uint NS_E_CD_READ_ERROR = 0xC00D0FAC;

		/// <summary>For best performance, do not play CD tracks while ripping them.</summary>
		public const uint NS_E_CD_SLOW_COPY = 0xC00D0FAD;

		/// <summary>It is not possible to directly burn tracks from one CD to another CD. You must first rip the tracks from the CD to your computer, and then burn the files to a blank CD.</summary>
		public const uint NS_E_CD_COPYTO_CD = 0xC00D0FAE;

		/// <summary>Could not open a sound mixer driver.</summary>
		public const uint NS_E_MIXER_NODRIVER = 0xC00D0FAF;

		/// <summary>Windows Media Player cannot rip tracks from the CD correctly because the CD drive settings in Device Manager do not match the CD drive settings in the Player.</summary>
		public const uint NS_E_REDBOOK_ENABLED_WHILE_COPYING = 0xC00D0FB0;

		/// <summary>Windows Media Player is busy reading the CD.</summary>
		public const uint NS_E_CD_REFRESH = 0xC00D0FB1;

		/// <summary>Windows Media Player could not use digital playback to play the CD. The Player has automatically switched the CD drive to analog playback. To switch back to digital CD playback, use the Devices tab. For additional assistance, click Web Help.</summary>
		public const uint NS_E_CD_DRIVER_PROBLEM = 0xC00D0FB2;

		/// <summary>Windows Media Player could not use digital playback to play the CD. The Player has automatically switched the CD drive to analog playback. To switch back to digital CD playback, use the Devices tab. For additional assistance, click Web Help.</summary>
		public const uint NS_E_WONT_DO_DIGITAL = 0xC00D0FB3;

		/// <summary>A call was made to GetParseError on the XML parser but there was no error to retrieve.</summary>
		public const uint NS_E_WMPXML_NOERROR = 0xC00D0FB4;

		/// <summary>The XML Parser ran out of data while parsing.</summary>
		public const uint NS_E_WMPXML_ENDOFDATA = 0xC00D0FB5;

		/// <summary>A generic parse error occurred in the XML parser but no information is available.</summary>
		public const uint NS_E_WMPXML_PARSEERROR = 0xC00D0FB6;

		/// <summary>A call get GetNamedAttribute or GetNamedAttributeIndex on the XML parser resulted in the index not being found.</summary>
		public const uint NS_E_WMPXML_ATTRIBUTENOTFOUND = 0xC00D0FB7;

		/// <summary>A call was made go GetNamedPI on the XML parser, but the requested Processing Instruction was not found.</summary>
		public const uint NS_E_WMPXML_PINOTFOUND = 0xC00D0FB8;

		/// <summary>Persist was called on the XML parser, but the parser has no data to persist.</summary>
		public const uint NS_E_WMPXML_EMPTYDOC = 0xC00D0FB9;

		/// <summary>This file path is already in the library.</summary>
		public const uint NS_E_WMP_PATH_ALREADY_IN_LIBRARY = 0xC00D0FBA;

		/// <summary>Windows Media Player is already searching for files to add to your library. Wait for the current process to finish before attempting to search again.</summary>
		public const uint NS_E_WMP_FILESCANALREADYSTARTED = 0xC00D0FBE;

		/// <summary>Windows Media Player is unable to find the media you are looking for.</summary>
		public const uint NS_E_WMP_HME_INVALIDOBJECTID = 0xC00D0FBF;

		/// <summary>A component of Windows Media Player is out-of-date. If you are running a pre-release version of Windows, try upgrading to a more recent version.</summary>
		public const uint NS_E_WMP_MF_CODE_EXPIRED = 0xC00D0FC0;

		/// <summary>This container does not support search on items.</summary>
		public const uint NS_E_WMP_HME_NOTSEARCHABLEFORITEMS = 0xC00D0FC1;

		/// <summary>Windows Media Player encountered a problem while adding one or more files to the library. For additional assistance, click Web Help.</summary>
		public const uint NS_E_WMP_ADDTOLIBRARY_FAILED = 0xC00D0FC7;

		/// <summary>A Windows API call failed but no error information was available.</summary>
		public const uint NS_E_WMP_WINDOWSAPIFAILURE = 0xC00D0FC8;

		/// <summary>This file does not have burn rights. If you obtained this file from an online store, go to the online store to get burn rights.</summary>
		public const uint NS_E_WMP_RECORDING_NOT_ALLOWED = 0xC00D0FC9;

		/// <summary>Windows Media Player no longer detects a connected portable device. Reconnect your portable device, and then try to sync the file again.</summary>
		public const uint NS_E_DEVICE_NOT_READY = 0xC00D0FCA;

		/// <summary>Windows Media Player cannot play the file because it is corrupted.</summary>
		public const uint NS_E_DAMAGED_FILE = 0xC00D0FCB;

		/// <summary>Windows Media Player encountered an error while attempting to access information in the library. Try restarting the Player.</summary>
		public const uint NS_E_MPDB_GENERIC = 0xC00D0FCC;

		/// <summary>The file cannot be added to the library because it is smaller than the "Skip files smaller than" setting. To add the file, change the setting on the Library tab. For additional assistance, click Web Help.</summary>
		public const uint NS_E_FILE_FAILED_CHECKS = 0xC00D0FCD;

		/// <summary>Windows Media Player cannot create the library. You must be logged on as an administrator or a member of the Administrators group to install the Player. For more information, contact your system administrator.</summary>
		public const uint NS_E_MEDIA_LIBRARY_FAILED = 0xC00D0FCE;

		/// <summary>The file is already in use. Close other programs that might be using the file, or stop playing the file, and then try again.</summary>
		public const uint NS_E_SHARING_VIOLATION = 0xC00D0FCF;

		/// <summary>Windows Media Player has encountered an unknown error.</summary>
		public const uint NS_E_NO_ERROR_STRING_FOUND = 0xC00D0FD0;

		/// <summary>The Windows Media Player ActiveX control cannot connect to remote media services, but will continue with local media services.</summary>
		public const uint NS_E_WMPOCX_NO_REMOTE_CORE = 0xC00D0FD1;

		/// <summary>The requested method or property is not available because the Windows Media Player ActiveX control has not been properly activated.</summary>
		public const uint NS_E_WMPOCX_NO_ACTIVE_CORE = 0xC00D0FD2;

		/// <summary>The Windows Media Player ActiveX control is not running in remote mode.</summary>
		public const uint NS_E_WMPOCX_NOT_RUNNING_REMOTELY = 0xC00D0FD3;

		/// <summary>An error occurred while trying to get the remote Windows Media Player window.</summary>
		public const uint NS_E_WMPOCX_NO_REMOTE_WINDOW = 0xC00D0FD4;

		/// <summary>Windows Media Player has encountered an unknown error.</summary>
		public const uint NS_E_WMPOCX_ERRORMANAGERNOTAVAILABLE = 0xC00D0FD5;

		/// <summary>Windows Media Player was not closed properly. A damaged or incompatible plug-in might have caused the problem to occur. As a precaution, all optional plug-ins have been disabled.</summary>
		public const uint NS_E_PLUGIN_NOTSHUTDOWN = 0xC00D0FD6;

		/// <summary>Windows Media Player cannot find the specified path. Verify that the path is typed correctly. If it is, the path does not exist in the specified location, or the computer where the path is located is not available.</summary>
		public const uint NS_E_WMP_CANNOT_FIND_FOLDER = 0xC00D0FD7;

		/// <summary>Windows Media Player cannot save a file that is being streamed.</summary>
		public const uint NS_E_WMP_STREAMING_RECORDING_NOT_ALLOWED = 0xC00D0FD8;

		/// <summary>Windows Media Player cannot find the selected plug-in. The Player will try to remove it from the menu. To use this plug-in, install it again.</summary>
		public const uint NS_E_WMP_PLUGINDLL_NOTFOUND = 0xC00D0FD9;

		/// <summary>Action requires input from the user.</summary>
		public const uint NS_E_NEED_TO_ASK_USER = 0xC00D0FDA;

		/// <summary>The Windows Media Player ActiveX control must be in a docked state for this action to be performed.</summary>
		public const uint NS_E_WMPOCX_PLAYER_NOT_DOCKED = 0xC00D0FDB;

		/// <summary>The Windows Media Player external object is not ready.</summary>
		public const uint NS_E_WMP_EXTERNAL_NOTREADY = 0xC00D0FDC;

		/// <summary>Windows Media Player cannot perform the requested action. Your computer's time and date might not be set correctly.</summary>
		public const uint NS_E_WMP_MLS_STALE_DATA = 0xC00D0FDD;

		/// <summary>The control (%s) does not support creation of sub-controls, yet (%d) sub-controls have been specified.</summary>
		public const uint NS_E_WMP_UI_SUBCONTROLSNOTSUPPORTED = 0xC00D0FDE;

		/// <summary>Version mismatch: (%.1f required, %.1f found).</summary>
		public const uint NS_E_WMP_UI_VERSIONMISMATCH = 0xC00D0FDF;

		/// <summary>The layout manager was given valid XML that wasn't a theme file.</summary>
		public const uint NS_E_WMP_UI_NOTATHEMEFILE = 0xC00D0FE0;

		/// <summary>The %s subelement could not be found on the %s object.</summary>
		public const uint NS_E_WMP_UI_SUBELEMENTNOTFOUND = 0xC00D0FE1;

		/// <summary>An error occurred parsing the version tag. Valid version tags are of the form: <?wmp version='1.0'?>.</summary>
		public const uint NS_E_WMP_UI_VERSIONPARSE = 0xC00D0FE2;

		/// <summary>The view specified in for the 'currentViewID' property (%s) was not found in this theme file.</summary>
		public const uint NS_E_WMP_UI_VIEWIDNOTFOUND = 0xC00D0FE3;

		/// <summary>This error used internally for hit testing.</summary>
		public const uint NS_E_WMP_UI_PASSTHROUGH = 0xC00D0FE4;

		/// <summary>Attributes were specified for the %s object, but the object was not available to send them to.</summary>
		public const uint NS_E_WMP_UI_OBJECTNOTFOUND = 0xC00D0FE5;

		/// <summary>The %s event already has a handler, the second handler was ignored.</summary>
		public const uint NS_E_WMP_UI_SECONDHANDLER = 0xC00D0FE6;

		/// <summary>No .wms file found in skin archive.</summary>
		public const uint NS_E_WMP_UI_NOSKININZIP = 0xC00D0FE7;

		/// <summary>Windows Media Player encountered a problem while downloading the file. For additional assistance, click Web Help.</summary>
		public const uint NS_E_WMP_URLDOWNLOADFAILED = 0xC00D0FEA;

		/// <summary>The Windows Media Player ActiveX control cannot load the requested uiMode and cannot roll back to the existing uiMode.</summary>
		public const uint NS_E_WMPOCX_UNABLE_TO_LOAD_SKIN = 0xC00D0FEB;

		/// <summary>Windows Media Player encountered a problem with the skin file. The skin file might not be valid.</summary>
		public const uint NS_E_WMP_INVALID_SKIN = 0xC00D0FEC;

		/// <summary>Windows Media Player cannot send the link because your email program is not responding. Verify that your email program is configured properly, and then try again. For more information about email, see Windows Help.</summary>
		public const uint NS_E_WMP_SENDMAILFAILED = 0xC00D0FED;

		/// <summary>Windows Media Player cannot switch to full mode because your computer administrator has locked this skin.</summary>
		public const uint NS_E_WMP_LOCKEDINSKINMODE = 0xC00D0FEE;

		/// <summary>Windows Media Player encountered a problem while saving the file. For additional assistance, click Web Help.</summary>
		public const uint NS_E_WMP_FAILED_TO_SAVE_FILE = 0xC00D0FEF;

		/// <summary>Windows Media Player cannot overwrite a read-only file. Try using a different file name.</summary>
		public const uint NS_E_WMP_SAVEAS_READONLY = 0xC00D0FF0;

		/// <summary>Windows Media Player encountered a problem while creating or saving the playlist. For additional assistance, click Web Help.</summary>
		public const uint NS_E_WMP_FAILED_TO_SAVE_PLAYLIST = 0xC00D0FF1;

		/// <summary>Windows Media Player cannot open the Windows Media Download file. The file might be damaged.</summary>
		public const uint NS_E_WMP_FAILED_TO_OPEN_WMD = 0xC00D0FF2;

		/// <summary>The file cannot be added to the library because it is a protected DVR-MS file. This content cannot be played back by Windows Media Player.</summary>
		public const uint NS_E_WMP_CANT_PLAY_PROTECTED = 0xC00D0FF3;

		/// <summary>Media sharing has been turned off because a required Windows setting or component has changed. For additional assistance, click Web Help.</summary>
		public const uint NS_E_SHARING_STATE_OUT_OF_SYNC = 0xC00D0FF4;

		/// <summary>Exclusive Services launch failed because the Windows Media Player is already running.</summary>
		public const uint NS_E_WMPOCX_REMOTE_PLAYER_ALREADY_RUNNING = 0xC00D0FFA;

		/// <summary>JPG Images are not recommended for use as a mappingImage.</summary>
		public const uint NS_E_WMP_RBC_JPGMAPPINGIMAGE = 0xC00D1004;

		/// <summary>JPG Images are not recommended when using a transparencyColor.</summary>
		public const uint NS_E_WMP_JPGTRANSPARENCY = 0xC00D1005;

		/// <summary>The Max property cannot be less than Min property.</summary>
		public const uint NS_E_WMP_INVALID_MAX_VAL = 0xC00D1009;

		/// <summary>The Min property cannot be greater than Max property.</summary>
		public const uint NS_E_WMP_INVALID_MIN_VAL = 0xC00D100A;

		/// <summary>JPG Images are not recommended for use as a positionImage.</summary>
		public const uint NS_E_WMP_CS_JPGPOSITIONIMAGE = 0xC00D100E;

		/// <summary>The (%s) image's size is not evenly divisible by the positionImage's size.</summary>
		public const uint NS_E_WMP_CS_NOTEVENLYDIVISIBLE = 0xC00D100F;

		/// <summary>The ZIP reader opened a file and its signature did not match that of the ZIP files.</summary>
		public const uint NS_E_WMPZIP_NOTAZIPFILE = 0xC00D1018;

		/// <summary>The ZIP reader has detected that the file is corrupted.</summary>
		public const uint NS_E_WMPZIP_CORRUPT = 0xC00D1019;

		/// <summary>GetFileStream, SaveToFile, or SaveTemp file was called on the ZIP reader with a file name that was not found in the ZIP file.</summary>
		public const uint NS_E_WMPZIP_FILENOTFOUND = 0xC00D101A;

		/// <summary>Image type not supported.</summary>
		public const uint NS_E_WMP_IMAGE_FILETYPE_UNSUPPORTED = 0xC00D1022;

		/// <summary>Image file might be corrupt.</summary>
		public const uint NS_E_WMP_IMAGE_INVALID_FORMAT = 0xC00D1023;

		/// <summary>Unexpected end of file. GIF file might be corrupt.</summary>
		public const uint NS_E_WMP_GIF_UNEXPECTED_ENDOFFILE = 0xC00D1024;

		/// <summary>Invalid GIF file.</summary>
		public const uint NS_E_WMP_GIF_INVALID_FORMAT = 0xC00D1025;

		/// <summary>Invalid GIF version. Only 87a or 89a supported.</summary>
		public const uint NS_E_WMP_GIF_BAD_VERSION_NUMBER = 0xC00D1026;

		/// <summary>No images found in GIF file.</summary>
		public const uint NS_E_WMP_GIF_NO_IMAGE_IN_FILE = 0xC00D1027;

		/// <summary>Invalid PNG image file format.</summary>
		public const uint NS_E_WMP_PNG_INVALIDFORMAT = 0xC00D1028;

		/// <summary>PNG bitdepth not supported.</summary>
		public const uint NS_E_WMP_PNG_UNSUPPORTED_BITDEPTH = 0xC00D1029;

		/// <summary>Compression format defined in PNG file not supported,</summary>
		public const uint NS_E_WMP_PNG_UNSUPPORTED_COMPRESSION = 0xC00D102A;

		/// <summary>Filter method defined in PNG file not supported.</summary>
		public const uint NS_E_WMP_PNG_UNSUPPORTED_FILTER = 0xC00D102B;

		/// <summary>Interlace method defined in PNG file not supported.</summary>
		public const uint NS_E_WMP_PNG_UNSUPPORTED_INTERLACE = 0xC00D102C;

		/// <summary>Bad CRC in PNG file.</summary>
		public const uint NS_E_WMP_PNG_UNSUPPORTED_BAD_CRC = 0xC00D102D;

		/// <summary>Invalid bitmask in BMP file.</summary>
		public const uint NS_E_WMP_BMP_INVALID_BITMASK = 0xC00D102E;

		/// <summary>Topdown DIB not supported.</summary>
		public const uint NS_E_WMP_BMP_TOPDOWN_DIB_UNSUPPORTED = 0xC00D102F;

		/// <summary>Bitmap could not be created.</summary>
		public const uint NS_E_WMP_BMP_BITMAP_NOT_CREATED = 0xC00D1030;

		/// <summary>Compression format defined in BMP not supported.</summary>
		public const uint NS_E_WMP_BMP_COMPRESSION_UNSUPPORTED = 0xC00D1031;

		/// <summary>Invalid Bitmap format.</summary>
		public const uint NS_E_WMP_BMP_INVALID_FORMAT = 0xC00D1032;

		/// <summary>JPEG Arithmetic coding not supported.</summary>
		public const uint NS_E_WMP_JPG_JERR_ARITHCODING_NOTIMPL = 0xC00D1033;

		/// <summary>Invalid JPEG format.</summary>
		public const uint NS_E_WMP_JPG_INVALID_FORMAT = 0xC00D1034;

		/// <summary>Invalid JPEG format.</summary>
		public const uint NS_E_WMP_JPG_BAD_DCTSIZE = 0xC00D1035;

		/// <summary>Internal version error. Unexpected JPEG library version.</summary>
		public const uint NS_E_WMP_JPG_BAD_VERSION_NUMBER = 0xC00D1036;

		/// <summary>Internal JPEG Library error. Unsupported JPEG data precision.</summary>
		public const uint NS_E_WMP_JPG_BAD_PRECISION = 0xC00D1037;

		/// <summary>JPEG CCIR601 not supported.</summary>
		public const uint NS_E_WMP_JPG_CCIR601_NOTIMPL = 0xC00D1038;

		/// <summary>No image found in JPEG file.</summary>
		public const uint NS_E_WMP_JPG_NO_IMAGE_IN_FILE = 0xC00D1039;

		/// <summary>Could not read JPEG file.</summary>
		public const uint NS_E_WMP_JPG_READ_ERROR = 0xC00D103A;

		/// <summary>JPEG Fractional sampling not supported.</summary>
		public const uint NS_E_WMP_JPG_FRACT_SAMPLE_NOTIMPL = 0xC00D103B;

		/// <summary>JPEG image too large. Maximum image size supported is 65500 X 65500.</summary>
		public const uint NS_E_WMP_JPG_IMAGE_TOO_BIG = 0xC00D103C;

		/// <summary>Unexpected end of file reached in JPEG file.</summary>
		public const uint NS_E_WMP_JPG_UNEXPECTED_ENDOFFILE = 0xC00D103D;

		/// <summary>Unsupported JPEG SOF marker found.</summary>
		public const uint NS_E_WMP_JPG_SOF_UNSUPPORTED = 0xC00D103E;

		/// <summary>Unknown JPEG marker found.</summary>
		public const uint NS_E_WMP_JPG_UNKNOWN_MARKER = 0xC00D103F;

		/// <summary>Windows Media Player cannot display the picture file. The player either does not support the picture type or the picture is corrupted.</summary>
		public const uint NS_E_WMP_FAILED_TO_OPEN_IMAGE = 0xC00D1044;

		/// <summary>Windows Media Player cannot compute a Digital Audio Id for the song. It is too short.</summary>
		public const uint NS_E_WMP_DAI_SONGTOOSHORT = 0xC00D1049;

		/// <summary>Windows Media Player cannot play the file at the requested speed.</summary>
		public const uint NS_E_WMG_RATEUNAVAILABLE = 0xC00D104A;

		/// <summary>The rendering or digital signal processing plug-in cannot be instantiated.</summary>
		public const uint NS_E_WMG_PLUGINUNAVAILABLE = 0xC00D104B;

		/// <summary>The file cannot be queued for seamless playback.</summary>
		public const uint NS_E_WMG_CANNOTQUEUE = 0xC00D104C;

		/// <summary>Windows Media Player cannot download media usage rights for a file in the playlist.</summary>
		public const uint NS_E_WMG_PREROLLLICENSEACQUISITIONNOTALLOWED = 0xC00D104D;

		/// <summary>Windows Media Player encountered an error while trying to queue a file.</summary>
		public const uint NS_E_WMG_UNEXPECTEDPREROLLSTATUS = 0xC00D104E;

		/// <summary>Windows Media Player cannot play the protected file. The Player cannot verify that the connection to your video card is secure. Try installing an updated device driver for your video card.</summary>
		public const uint NS_E_WMG_INVALID_COPP_CERTIFICATE = 0xC00D1051;

		/// <summary>Windows Media Player cannot play the protected file. The Player detected that the connection to your hardware might not be secure.</summary>
		public const uint NS_E_WMG_COPP_SECURITY_INVALID = 0xC00D1052;

		/// <summary>Windows Media Player output link protection is unsupported on this system.</summary>
		public const uint NS_E_WMG_COPP_UNSUPPORTED = 0xC00D1053;

		/// <summary>Operation attempted in an invalid graph state.</summary>
		public const uint NS_E_WMG_INVALIDSTATE = 0xC00D1054;

		/// <summary>A renderer cannot be inserted in a stream while one already exists.</summary>
		public const uint NS_E_WMG_SINKALREADYEXISTS = 0xC00D1055;

		/// <summary>The Windows Media SDK interface needed to complete the operation does not exist at this time.</summary>
		public const uint NS_E_WMG_NOSDKINTERFACE = 0xC00D1056;

		/// <summary>Windows Media Player cannot play a portion of the file because it requires a codec that either could not be downloaded or that is not supported by the Player.</summary>
		public const uint NS_E_WMG_NOTALLOUTPUTSRENDERED = 0xC00D1057;

		/// <summary>File transfer streams are not allowed in the standalone Player.</summary>
		public const uint NS_E_WMG_FILETRANSFERNOTALLOWED = 0xC00D1058;

		/// <summary>Windows Media Player cannot play the file. The Player does not support the format you are trying to play.</summary>
		public const uint NS_E_WMR_UNSUPPORTEDSTREAM = 0xC00D1059;

		/// <summary>An operation was attempted on a pin that does not exist in the DirectShow filter graph.</summary>
		public const uint NS_E_WMR_PINNOTFOUND = 0xC00D105A;

		/// <summary>Specified operation cannot be completed while waiting for a media format change from the SDK.</summary>
		public const uint NS_E_WMR_WAITINGONFORMATSWITCH = 0xC00D105B;

		/// <summary>Specified operation cannot be completed because the source filter does not exist.</summary>
		public const uint NS_E_WMR_NOSOURCEFILTER = 0xC00D105C;

		/// <summary>The specified type does not match this pin.</summary>
		public const uint NS_E_WMR_PINTYPENOMATCH = 0xC00D105D;

		/// <summary>The WMR Source Filter does not have a callback available.</summary>
		public const uint NS_E_WMR_NOCALLBACKAVAILABLE = 0xC00D105E;

		/// <summary>The specified property has not been set on this sample.</summary>
		public const uint NS_E_WMR_SAMPLEPROPERTYNOTSET = 0xC00D1062;

		/// <summary>A plug-in is required to correctly play the file. To determine if the plug-in is available to download, click Web Help.</summary>
		public const uint NS_E_WMR_CANNOT_RENDER_BINARY_STREAM = 0xC00D1063;

		/// <summary>Windows Media Player cannot play the file because your media usage rights are corrupted. If you previously backed up your media usage rights, try restoring them.</summary>
		public const uint NS_E_WMG_LICENSE_TAMPERED = 0xC00D1064;

		/// <summary>Windows Media Player cannot play protected files that contain binary streams.</summary>
		public const uint NS_E_WMR_WILLNOT_RENDER_BINARY_STREAM = 0xC00D1065;

		/// <summary>Windows Media Player cannot play the playlist because it is not valid.</summary>
		public const uint NS_E_WMX_UNRECOGNIZED_PLAYLIST_FORMAT = 0xC00D1068;

		/// <summary>Windows Media Player cannot play the playlist because it is not valid.</summary>
		public const uint NS_E_ASX_INVALIDFORMAT = 0xC00D1069;

		/// <summary>A later version of Windows Media Player might be required to play this playlist.</summary>
		public const uint NS_E_ASX_INVALIDVERSION = 0xC00D106A;

		/// <summary>The format of a REPEAT loop within the current playlist file is not valid.</summary>
		public const uint NS_E_ASX_INVALID_REPEAT_BLOCK = 0xC00D106B;

		/// <summary>Windows Media Player cannot save the playlist because it does not contain any items.</summary>
		public const uint NS_E_ASX_NOTHING_TO_WRITE = 0xC00D106C;

		/// <summary>Windows Media Player cannot play the playlist because it is not valid.</summary>
		public const uint NS_E_URLLIST_INVALIDFORMAT = 0xC00D106D;

		/// <summary>The specified attribute does not exist.</summary>
		public const uint NS_E_WMX_ATTRIBUTE_DOES_NOT_EXIST = 0xC00D106E;

		/// <summary>The specified attribute already exists.</summary>
		public const uint NS_E_WMX_ATTRIBUTE_ALREADY_EXISTS = 0xC00D106F;

		/// <summary>Cannot retrieve the specified attribute.</summary>
		public const uint NS_E_WMX_ATTRIBUTE_UNRETRIEVABLE = 0xC00D1070;

		/// <summary>The specified item does not exist in the current playlist.</summary>
		public const uint NS_E_WMX_ITEM_DOES_NOT_EXIST = 0xC00D1071;

		/// <summary>Items of the specified type cannot be created within the current playlist.</summary>
		public const uint NS_E_WMX_ITEM_TYPE_ILLEGAL = 0xC00D1072;

		/// <summary>The specified item cannot be set in the current playlist.</summary>
		public const uint NS_E_WMX_ITEM_UNSETTABLE = 0xC00D1073;

		/// <summary>Windows Media Player cannot perform the requested action because the playlist does not contain any items.</summary>
		public const uint NS_E_WMX_PLAYLIST_EMPTY = 0xC00D1074;

		/// <summary>The specified auto playlist contains a filter type that is either not valid or is not installed on this computer.</summary>
		public const uint NS_E_MLS_SMARTPLAYLIST_FILTER_NOT_REGISTERED = 0xC00D1075;

		/// <summary>Windows Media Player cannot play the file because the associated playlist contains too many nested playlists.</summary>
		public const uint NS_E_WMX_INVALID_FORMAT_OVER_NESTING = 0xC00D1076;

		/// <summary>Windows Media Player cannot find the file. Verify that the path is typed correctly. If it is, the file might not exist in the specified location, or the computer where the file is stored might not be available.</summary>
		public const uint NS_E_WMPCORE_NOSOURCEURLSTRING = 0xC00D107C;

		/// <summary>Failed to create the Global Interface Table.</summary>
		public const uint NS_E_WMPCORE_COCREATEFAILEDFORGITOBJECT = 0xC00D107D;

		/// <summary>Failed to get the marshaled graph event handler interface.</summary>
		public const uint NS_E_WMPCORE_FAILEDTOGETMARSHALLEDEVENTHANDLERINTERFACE = 0xC00D107E;

		/// <summary>Buffer is too small for copying media type.</summary>
		public const uint NS_E_WMPCORE_BUFFERTOOSMALL = 0xC00D107F;

		/// <summary>The current state of the Player does not allow this operation.</summary>
		public const uint NS_E_WMPCORE_UNAVAILABLE = 0xC00D1080;

		/// <summary>The playlist manager does not understand the current play mode (for example, shuffle or normal).</summary>
		public const uint NS_E_WMPCORE_INVALIDPLAYLISTMODE = 0xC00D1081;

		/// <summary>Windows Media Player cannot play the file because it is not in the current playlist.</summary>
		public const uint NS_E_WMPCORE_ITEMNOTINPLAYLIST = 0xC00D1086;

		/// <summary>There are no items in the playlist. Add items to the playlist, and then try again.</summary>
		public const uint NS_E_WMPCORE_PLAYLISTEMPTY = 0xC00D1087;

		/// <summary>The web page cannot be displayed because no web browser is installed on your computer.</summary>
		public const uint NS_E_WMPCORE_NOBROWSER = 0xC00D1088;

		/// <summary>Windows Media Player cannot find the specified file. Verify the path is typed correctly. If it is, the file does not exist in the specified location, or the computer where the file is stored is not available.</summary>
		public const uint NS_E_WMPCORE_UNRECOGNIZED_MEDIA_URL = 0xC00D1089;

		/// <summary>Graph with the specified URL was not found in the prerolled graph list.</summary>
		public const uint NS_E_WMPCORE_GRAPH_NOT_IN_LIST = 0xC00D108A;

		/// <summary>Windows Media Player cannot perform the requested operation because there is only one item in the playlist.</summary>
		public const uint NS_E_WMPCORE_PLAYLIST_EMPTY_OR_SINGLE_MEDIA = 0xC00D108B;

		/// <summary>An error sink was never registered for the calling object.</summary>
		public const uint NS_E_WMPCORE_ERRORSINKNOTREGISTERED = 0xC00D108C;

		/// <summary>The error manager is not available to respond to errors.</summary>
		public const uint NS_E_WMPCORE_ERRORMANAGERNOTAVAILABLE = 0xC00D108D;

		/// <summary>The Web Help URL cannot be opened.</summary>
		public const uint NS_E_WMPCORE_WEBHELPFAILED = 0xC00D108E;

		/// <summary>Could not resume playing next item in playlist.</summary>
		public const uint NS_E_WMPCORE_MEDIA_ERROR_RESUME_FAILED = 0xC00D108F;

		/// <summary>Windows Media Player cannot play the file because the associated playlist does not contain any items or the playlist is not valid.</summary>
		public const uint NS_E_WMPCORE_NO_REF_IN_ENTRY = 0xC00D1090;

		/// <summary>An empty string for playlist attribute name was found.</summary>
		public const uint NS_E_WMPCORE_WMX_LIST_ATTRIBUTE_NAME_EMPTY = 0xC00D1091;

		/// <summary>A playlist attribute name that is not valid was found.</summary>
		public const uint NS_E_WMPCORE_WMX_LIST_ATTRIBUTE_NAME_ILLEGAL = 0xC00D1092;

		/// <summary>An empty string for a playlist attribute value was found.</summary>
		public const uint NS_E_WMPCORE_WMX_LIST_ATTRIBUTE_VALUE_EMPTY = 0xC00D1093;

		/// <summary>An illegal value for a playlist attribute was found.</summary>
		public const uint NS_E_WMPCORE_WMX_LIST_ATTRIBUTE_VALUE_ILLEGAL = 0xC00D1094;

		/// <summary>An empty string for a playlist item attribute name was found.</summary>
		public const uint NS_E_WMPCORE_WMX_LIST_ITEM_ATTRIBUTE_NAME_EMPTY = 0xC00D1095;

		/// <summary>An illegal value for a playlist item attribute name was found.</summary>
		public const uint NS_E_WMPCORE_WMX_LIST_ITEM_ATTRIBUTE_NAME_ILLEGAL = 0xC00D1096;

		/// <summary>An illegal value for a playlist item attribute was found.</summary>
		public const uint NS_E_WMPCORE_WMX_LIST_ITEM_ATTRIBUTE_VALUE_EMPTY = 0xC00D1097;

		/// <summary>The playlist does not contain any items.</summary>
		public const uint NS_E_WMPCORE_LIST_ENTRY_NO_REF = 0xC00D1098;

		/// <summary>Windows Media Player cannot play the file. The file is either corrupted or the Player does not support the format you are trying to play.</summary>
		public const uint NS_E_WMPCORE_MISNAMED_FILE = 0xC00D1099;

		/// <summary>The codec downloaded for this file does not appear to be properly signed, so it cannot be installed.</summary>
		public const uint NS_E_WMPCORE_CODEC_NOT_TRUSTED = 0xC00D109A;

		/// <summary>Windows Media Player cannot play the file. One or more codecs required to play the file could not be found.</summary>
		public const uint NS_E_WMPCORE_CODEC_NOT_FOUND = 0xC00D109B;

		/// <summary>Windows Media Player cannot play the file because a required codec is not installed on your computer. To try downloading the codec, turn on the "Download codecs automatically" option.</summary>
		public const uint NS_E_WMPCORE_CODEC_DOWNLOAD_NOT_ALLOWED = 0xC00D109C;

		/// <summary>Windows Media Player encountered a problem while downloading the playlist. For additional assistance, click Web Help.</summary>
		public const uint NS_E_WMPCORE_ERROR_DOWNLOADING_PLAYLIST = 0xC00D109D;

		/// <summary>Failed to build the playlist.</summary>
		public const uint NS_E_WMPCORE_FAILED_TO_BUILD_PLAYLIST = 0xC00D109E;

		/// <summary>Playlist has no alternates to switch into.</summary>
		public const uint NS_E_WMPCORE_PLAYLIST_ITEM_ALTERNATE_NONE = 0xC00D109F;

		/// <summary>No more playlist alternates available to switch to.</summary>
		public const uint NS_E_WMPCORE_PLAYLIST_ITEM_ALTERNATE_EXHAUSTED = 0xC00D10A0;

		/// <summary>Could not find the name of the alternate playlist to switch into.</summary>
		public const uint NS_E_WMPCORE_PLAYLIST_ITEM_ALTERNATE_NAME_NOT_FOUND = 0xC00D10A1;

		/// <summary>Failed to switch to an alternate for this media.</summary>
		public const uint NS_E_WMPCORE_PLAYLIST_ITEM_ALTERNATE_MORPH_FAILED = 0xC00D10A2;

		/// <summary>Failed to initialize an alternate for the media.</summary>
		public const uint NS_E_WMPCORE_PLAYLIST_ITEM_ALTERNATE_INIT_FAILED = 0xC00D10A3;

		/// <summary>No URL specified for the roll over Refs in the playlist file.</summary>
		public const uint NS_E_WMPCORE_MEDIA_ALTERNATE_REF_EMPTY = 0xC00D10A4;

		/// <summary>Encountered a playlist with no name.</summary>
		public const uint NS_E_WMPCORE_PLAYLIST_NO_EVENT_NAME = 0xC00D10A5;

		/// <summary>A required attribute in the event block of the playlist was not found.</summary>
		public const uint NS_E_WMPCORE_PLAYLIST_EVENT_ATTRIBUTE_ABSENT = 0xC00D10A6;

		/// <summary>No items were found in the event block of the playlist.</summary>
		public const uint NS_E_WMPCORE_PLAYLIST_EVENT_EMPTY = 0xC00D10A7;

		/// <summary>No playlist was found while returning from a nested playlist.</summary>
		public const uint NS_E_WMPCORE_PLAYLIST_STACK_EMPTY = 0xC00D10A8;

		/// <summary>The media item is not active currently.</summary>
		public const uint NS_E_WMPCORE_CURRENT_MEDIA_NOT_ACTIVE = 0xC00D10A9;

		/// <summary>Windows Media Player cannot perform the requested action because you chose to cancel it.</summary>
		public const uint NS_E_WMPCORE_USER_CANCEL = 0xC00D10AB;

		/// <summary>Windows Media Player encountered a problem with the playlist. The format of the playlist is not valid.</summary>
		public const uint NS_E_WMPCORE_PLAYLIST_REPEAT_EMPTY = 0xC00D10AC;

		/// <summary>Media object corresponding to start of a playlist repeat block was not found.</summary>
		public const uint NS_E_WMPCORE_PLAYLIST_REPEAT_START_MEDIA_NONE = 0xC00D10AD;

		/// <summary>Media object corresponding to the end of a playlist repeat block was not found.</summary>
		public const uint NS_E_WMPCORE_PLAYLIST_REPEAT_END_MEDIA_NONE = 0xC00D10AE;

		/// <summary>The playlist URL supplied to the playlist manager is not valid.</summary>
		public const uint NS_E_WMPCORE_INVALID_PLAYLIST_URL = 0xC00D10AF;

		/// <summary>Windows Media Player cannot play the file because it is corrupted.</summary>
		public const uint NS_E_WMPCORE_MISMATCHED_RUNTIME = 0xC00D10B0;

		/// <summary>Windows Media Player cannot add the playlist to the library because the playlist does not contain any items.</summary>
		public const uint NS_E_WMPCORE_PLAYLIST_IMPORT_FAILED_NO_ITEMS = 0xC00D10B1;

		/// <summary>An error has occurred that could prevent the changing of the video contrast on this media.</summary>
		public const uint NS_E_WMPCORE_VIDEO_TRANSFORM_FILTER_INSERTION = 0xC00D10B2;

		/// <summary>Windows Media Player cannot play the file. If the file is located on the Internet, connect to the Internet. If the file is located on a removable storage card, insert the storage card.</summary>
		public const uint NS_E_WMPCORE_MEDIA_UNAVAILABLE = 0xC00D10B3;

		/// <summary>The playlist contains an ENTRYREF for which no href was parsed. Check the syntax of playlist file.</summary>
		public const uint NS_E_WMPCORE_WMX_ENTRYREF_NO_REF = 0xC00D10B4;

		/// <summary>Windows Media Player cannot play any items in the playlist. To find information about the problem, click the Now Playing tab, and then click the icon next to each file in the List pane.</summary>
		public const uint NS_E_WMPCORE_NO_PLAYABLE_MEDIA_IN_PLAYLIST = 0xC00D10B5;

		/// <summary>Windows Media Player cannot play some or all of the items in the playlist because the playlist is nested.</summary>
		public const uint NS_E_WMPCORE_PLAYLIST_EMPTY_NESTED_PLAYLIST_SKIPPED_ITEMS = 0xC00D10B6;

		/// <summary>Windows Media Player cannot play the file at this time. Try again later.</summary>
		public const uint NS_E_WMPCORE_BUSY = 0xC00D10B7;

		/// <summary>There is no child playlist available for this media item at this time.</summary>
		public const uint NS_E_WMPCORE_MEDIA_CHILD_PLAYLIST_UNAVAILABLE = 0xC00D10B8;

		/// <summary>There is no child playlist for this media item.</summary>
		public const uint NS_E_WMPCORE_MEDIA_NO_CHILD_PLAYLIST = 0xC00D10B9;

		/// <summary>Windows Media Player cannot find the file. The link from the item in the library to its associated digital media file might be broken. To fix the problem, try repairing the link or removing the item from the library.</summary>
		public const uint NS_E_WMPCORE_FILE_NOT_FOUND = 0xC00D10BA;

		/// <summary>The temporary file was not found.</summary>
		public const uint NS_E_WMPCORE_TEMP_FILE_NOT_FOUND = 0xC00D10BB;

		/// <summary>Windows Media Player cannot sync the file because the device needs to be updated.</summary>
		public const uint NS_E_WMDM_REVOKED = 0xC00D10BC;

		/// <summary>Windows Media Player cannot play the video because there is a problem with your video card.</summary>
		public const uint NS_E_DDRAW_GENERIC = 0xC00D10BD;

		/// <summary>Windows Media Player failed to change the screen mode for full-screen video playback.</summary>
		public const uint NS_E_DISPLAY_MODE_CHANGE_FAILED = 0xC00D10BE;

		/// <summary>Windows Media Player cannot play one or more files. For additional information, right-click an item that cannot be played, and then click Error Details.</summary>
		public const uint NS_E_PLAYLIST_CONTAINS_ERRORS = 0xC00D10BF;

		/// <summary>Cannot change the proxy name if the proxy setting is not set to custom.</summary>
		public const uint NS_E_CHANGING_PROXY_NAME = 0xC00D10C0;

		/// <summary>Cannot change the proxy port if the proxy setting is not set to custom.</summary>
		public const uint NS_E_CHANGING_PROXY_PORT = 0xC00D10C1;

		/// <summary>Cannot change the proxy exception list if the proxy setting is not set to custom.</summary>
		public const uint NS_E_CHANGING_PROXY_EXCEPTIONLIST = 0xC00D10C2;

		/// <summary>Cannot change the proxy bypass flag if the proxy setting is not set to custom.</summary>
		public const uint NS_E_CHANGING_PROXYBYPASS = 0xC00D10C3;

		/// <summary>Cannot find the specified protocol.</summary>
		public const uint NS_E_CHANGING_PROXY_PROTOCOL_NOT_FOUND = 0xC00D10C4;

		/// <summary>Cannot change the language settings. Either the graph has no audio or the audio only supports one language.</summary>
		public const uint NS_E_GRAPH_NOAUDIOLANGUAGE = 0xC00D10C5;

		/// <summary>The graph has no audio language selected.</summary>
		public const uint NS_E_GRAPH_NOAUDIOLANGUAGESELECTED = 0xC00D10C6;

		/// <summary>This is not a media CD.</summary>
		public const uint NS_E_CORECD_NOTAMEDIACD = 0xC00D10C7;

		/// <summary>Windows Media Player cannot play the file because the URL is too long.</summary>
		public const uint NS_E_WMPCORE_MEDIA_URL_TOO_LONG = 0xC00D10C8;

		/// <summary>To play the selected item, you must install the Macromedia Flash Player. To download the Macromedia Flash Player, go to the Adobe website.</summary>
		public const uint NS_E_WMPFLASH_CANT_FIND_COM_SERVER = 0xC00D10C9;

		/// <summary>To play the selected item, you must install a later version of the Macromedia Flash Player. To download the Macromedia Flash Player, go to the Adobe website.</summary>
		public const uint NS_E_WMPFLASH_INCOMPATIBLEVERSION = 0xC00D10CA;

		/// <summary>Windows Media Player cannot play the file because your Internet security settings prohibit the use of ActiveX controls.</summary>
		public const uint NS_E_WMPOCXGRAPH_IE_DISALLOWS_ACTIVEX_CONTROLS = 0xC00D10CB;

		/// <summary>The use of this method requires an existing reference to the Player object.</summary>
		public const uint NS_E_NEED_CORE_REFERENCE = 0xC00D10CC;

		/// <summary>Windows Media Player cannot play the CD. The disc might be dirty or damaged.</summary>
		public const uint NS_E_MEDIACD_READ_ERROR = 0xC00D10CD;

		/// <summary>Windows Media Player cannot play the file because your Internet security settings prohibit the use of ActiveX controls.</summary>
		public const uint NS_E_IE_DISALLOWS_ACTIVEX_CONTROLS = 0xC00D10CE;

		/// <summary>Flash playback has been turned off in Windows Media Player.</summary>
		public const uint NS_E_FLASH_PLAYBACK_NOT_ALLOWED = 0xC00D10CF;

		/// <summary>Windows Media Player cannot rip the CD because a valid rip location cannot be created.</summary>
		public const uint NS_E_UNABLE_TO_CREATE_RIP_LOCATION = 0xC00D10D0;

		/// <summary>Windows Media Player cannot play the file because a required codec is not installed on your computer.</summary>
		public const uint NS_E_WMPCORE_SOME_CODECS_MISSING = 0xC00D10D1;

		/// <summary>Windows Media Player cannot rip one or more tracks from the CD.</summary>
		public const uint NS_E_WMP_RIP_FAILED = 0xC00D10D2;

		/// <summary>Windows Media Player encountered a problem while ripping the track from the CD. For additional assistance, click Web Help.</summary>
		public const uint NS_E_WMP_FAILED_TO_RIP_TRACK = 0xC00D10D3;

		/// <summary>Windows Media Player encountered a problem while erasing the disc. For additional assistance, click Web Help.</summary>
		public const uint NS_E_WMP_ERASE_FAILED = 0xC00D10D4;

		/// <summary>Windows Media Player encountered a problem while formatting the device. For additional assistance, click Web Help.</summary>
		public const uint NS_E_WMP_FORMAT_FAILED = 0xC00D10D5;

		/// <summary>This file cannot be burned to a CD because it is not located on your computer.</summary>
		public const uint NS_E_WMP_CANNOT_BURN_NON_LOCAL_FILE = 0xC00D10D6;

		/// <summary>It is not possible to burn this file type to an audio CD. Windows Media Player can burn the following file types to an audio CD: WMA, MP3, or WAV.</summary>
		public const uint NS_E_WMP_FILE_TYPE_CANNOT_BURN_TO_AUDIO_CD = 0xC00D10D7;

		/// <summary>This file is too large to fit on a disc.</summary>
		public const uint NS_E_WMP_FILE_DOES_NOT_FIT_ON_CD = 0xC00D10D8;

		/// <summary>It is not possible to determine if this file can fit on a disc because Windows Media Player cannot detect the length of the file. Playing the file before burning might enable the Player to detect the file length.</summary>
		public const uint NS_E_WMP_FILE_NO_DURATION = 0xC00D10D9;

		/// <summary>Windows Media Player encountered a problem while burning the file to the disc. For additional assistance, click Web Help.</summary>
		public const uint NS_E_PDA_FAILED_TO_BURN = 0xC00D10DA;

		/// <summary>Windows Media Player cannot burn the audio CD because some items in the list that you chose to buy could not be downloaded from the online store.</summary>
		public const uint NS_E_FAILED_DOWNLOAD_ABORT_BURN = 0xC00D10DC;

		/// <summary>Windows Media Player cannot play the file. Try using Windows Update or Device Manager to update the device drivers for your audio and video cards. For information about using Windows Update or Device Manager, see Windows Help.</summary>
		public const uint NS_E_WMPCORE_DEVICE_DRIVERS_MISSING = 0xC00D10DD;

		/// <summary>Windows Media Player has detected that you are not connected to the Internet. Connect to the Internet, and then try again.</summary>
		public const uint NS_E_WMPIM_USEROFFLINE = 0xC00D1126;

		/// <summary>The attempt to connect to the Internet was canceled.</summary>
		public const uint NS_E_WMPIM_USERCANCELED = 0xC00D1127;

		/// <summary>The attempt to connect to the Internet failed.</summary>
		public const uint NS_E_WMPIM_DIALUPFAILED = 0xC00D1128;

		/// <summary>Windows Media Player has encountered an unknown network error.</summary>
		public const uint NS_E_WINSOCK_ERROR_STRING = 0xC00D1129;

		/// <summary>No window is currently listening to Backup and Restore events.</summary>
		public const uint NS_E_WMPBR_NOLISTENER = 0xC00D1130;

		/// <summary>Your media usage rights were not backed up because the backup was canceled.</summary>
		public const uint NS_E_WMPBR_BACKUPCANCEL = 0xC00D1131;

		/// <summary>Your media usage rights were not restored because the restoration was canceled.</summary>
		public const uint NS_E_WMPBR_RESTORECANCEL = 0xC00D1132;

		/// <summary>An error occurred while backing up or restoring your media usage rights. A required web page cannot be displayed.</summary>
		public const uint NS_E_WMPBR_ERRORWITHURL = 0xC00D1133;

		/// <summary>Your media usage rights were not backed up because the backup was canceled.</summary>
		public const uint NS_E_WMPBR_NAMECOLLISION = 0xC00D1134;

		/// <summary>Windows Media Player cannot restore your media usage rights from the specified location. Choose another location, and then try again.</summary>
		public const uint NS_E_WMPBR_DRIVE_INVALID = 0xC00D1137;

		/// <summary>Windows Media Player cannot backup or restore your media usage rights.</summary>
		public const uint NS_E_WMPBR_BACKUPRESTOREFAILED = 0xC00D1138;

		/// <summary>Windows Media Player cannot add the file to the library.</summary>
		public const uint NS_E_WMP_CONVERT_FILE_FAILED = 0xC00D1158;

		/// <summary>Windows Media Player cannot add the file to the library because the content provider prohibits it. For assistance, contact the company that provided the file.</summary>
		public const uint NS_E_WMP_CONVERT_NO_RIGHTS_ERRORURL = 0xC00D1159;

		/// <summary>Windows Media Player cannot add the file to the library because the content provider prohibits it. For assistance, contact the company that provided the file.</summary>
		public const uint NS_E_WMP_CONVERT_NO_RIGHTS_NOERRORURL = 0xC00D115A;

		/// <summary>Windows Media Player cannot add the file to the library. The file might not be valid.</summary>
		public const uint NS_E_WMP_CONVERT_FILE_CORRUPT = 0xC00D115B;

		/// <summary>Windows Media Player cannot add the file to the library. The plug-in required to add the file is not installed properly. For assistance, click Web Help to display the website of the company that provided the file.</summary>
		public const uint NS_E_WMP_CONVERT_PLUGIN_UNAVAILABLE_ERRORURL = 0xC00D115C;

		/// <summary>Windows Media Player cannot add the file to the library. The plug-in required to add the file is not installed properly. For assistance, contact the company that provided the file.</summary>
		public const uint NS_E_WMP_CONVERT_PLUGIN_UNAVAILABLE_NOERRORURL = 0xC00D115D;

		/// <summary>Windows Media Player cannot add the file to the library. The plug-in required to add the file is not installed properly. For assistance, contact the company that provided the file.</summary>
		public const uint NS_E_WMP_CONVERT_PLUGIN_UNKNOWN_FILE_OWNER = 0xC00D115E;

		/// <summary>Windows Media Player cannot play this DVD. Try installing an updated driver for your video card or obtaining a newer video card.</summary>
		public const uint NS_E_DVD_DISC_COPY_PROTECT_OUTPUT_NS = 0xC00D1160;

		/// <summary>This DVD's resolution exceeds the maximum allowed by your component video outputs. Try reducing your screen resolution to 640 x 480, or turn off analog component outputs and use a VGA connection to your monitor.</summary>
		public const uint NS_E_DVD_DISC_COPY_PROTECT_OUTPUT_FAILED = 0xC00D1161;

		/// <summary>Windows Media Player cannot display subtitles or highlights in DVD menus. Reinstall the DVD decoder or contact the DVD drive manufacturer to obtain an updated decoder.</summary>
		public const uint NS_E_DVD_NO_SUBPICTURE_STREAM = 0xC00D1162;

		/// <summary>Windows Media Player cannot play this DVD because there is a problem with digital copy protection between your DVD drive, decoder, and video card. Try installing an updated driver for your video card.</summary>
		public const uint NS_E_DVD_COPY_PROTECT = 0xC00D1163;

		/// <summary>Windows Media Player cannot play the DVD. The disc was created in a manner that the Player does not support.</summary>
		public const uint NS_E_DVD_AUTHORING_PROBLEM = 0xC00D1164;

		/// <summary>Windows Media Player cannot play the DVD because the disc prohibits playback in your region of the world. You must obtain a disc that is intended for your geographic region.</summary>
		public const uint NS_E_DVD_INVALID_DISC_REGION = 0xC00D1165;

		/// <summary>Windows Media Player cannot play the DVD because your video card does not support DVD playback.</summary>
		public const uint NS_E_DVD_COMPATIBLE_VIDEO_CARD = 0xC00D1166;

		/// <summary>Windows Media Player cannot play this DVD because it is not possible to turn on analog copy protection on the output display. Try installing an updated driver for your video card.</summary>
		public const uint NS_E_DVD_MACROVISION = 0xC00D1167;

		/// <summary>Windows Media Player cannot play the DVD because the region assigned to your DVD drive does not match the region assigned to your DVD decoder.</summary>
		public const uint NS_E_DVD_SYSTEM_DECODER_REGION = 0xC00D1168;

		/// <summary>Windows Media Player cannot play the DVD because the disc prohibits playback in your region of the world. You must obtain a disc that is intended for your geographic region.</summary>
		public const uint NS_E_DVD_DISC_DECODER_REGION = 0xC00D1169;

		/// <summary>Windows Media Player cannot play DVD video. You might need to adjust your Windows display settings. Open display settings in Control Panel, and then try lowering your screen resolution and color quality settings.</summary>
		public const uint NS_E_DVD_NO_VIDEO_STREAM = 0xC00D116A;

		/// <summary>Windows Media Player cannot play DVD audio. Verify that your sound card is set up correctly, and then try again.</summary>
		public const uint NS_E_DVD_NO_AUDIO_STREAM = 0xC00D116B;

		/// <summary>Windows Media Player cannot play DVD video. Close any open files and quit any other programs, and then try again. If the problem persists, restart your computer.</summary>
		public const uint NS_E_DVD_GRAPH_BUILDING = 0xC00D116C;

		/// <summary>Windows Media Player cannot play the DVD because a compatible DVD decoder is not installed on your computer.</summary>
		public const uint NS_E_DVD_NO_DECODER = 0xC00D116D;

		/// <summary>Windows Media Player cannot play the scene because it has a parental rating higher than the rating that you are authorized to view.</summary>
		public const uint NS_E_DVD_PARENTAL = 0xC00D116E;

		/// <summary>Windows Media Player cannot skip to the requested location on the DVD.</summary>
		public const uint NS_E_DVD_CANNOT_JUMP = 0xC00D116F;

		/// <summary>Windows Media Player cannot play the DVD because it is currently in use by another program. Quit the other program that is using the DVD, and then try again.</summary>
		public const uint NS_E_DVD_DEVICE_CONTENTION = 0xC00D1170;

		/// <summary>Windows Media Player cannot play DVD video. You might need to adjust your Windows display settings. Open display settings in Control Panel, and then try lowering your screen resolution and color quality settings.</summary>
		public const uint NS_E_DVD_NO_VIDEO_MEMORY = 0xC00D1171;

		/// <summary>Windows Media Player cannot rip the DVD because it is copy protected.</summary>
		public const uint NS_E_DVD_CANNOT_COPY_PROTECTED = 0xC00D1172;

		/// <summary>One of more of the required properties has not been set.</summary>
		public const uint NS_E_DVD_REQUIRED_PROPERTY_NOT_SET = 0xC00D1173;

		/// <summary>The specified title and/or chapter number does not exist on this DVD.</summary>
		public const uint NS_E_DVD_INVALID_TITLE_CHAPTER = 0xC00D1174;

		/// <summary>Windows Media Player cannot burn the files because the Player cannot find a burner. If the burner is connected properly, try using Windows Update to install the latest device driver.</summary>
		public const uint NS_E_NO_CD_BURNER = 0xC00D1176;

		/// <summary>Windows Media Player does not detect storage media in the selected device. Insert storage media into the device, and then try again.</summary>
		public const uint NS_E_DEVICE_IS_NOT_READY = 0xC00D1177;

		/// <summary>Windows Media Player cannot sync this file. The Player might not support the file type.</summary>
		public const uint NS_E_PDA_UNSUPPORTED_FORMAT = 0xC00D1178;

		/// <summary>Windows Media Player does not detect a portable device. Connect your portable device, and then try again.</summary>
		public const uint NS_E_NO_PDA = 0xC00D1179;

		/// <summary>Windows Media Player encountered an error while communicating with the device. The storage card on the device might be full, the device might be turned off, or the device might not allow playlists or folders to be created on it.</summary>
		public const uint NS_E_PDA_UNSPECIFIED_ERROR = 0xC00D117A;

		/// <summary>Windows Media Player encountered an error while burning a CD.</summary>
		public const uint NS_E_MEMSTORAGE_BAD_DATA = 0xC00D117B;

		/// <summary>Windows Media Player encountered an error while communicating with a portable device or CD drive.</summary>
		public const uint NS_E_PDA_FAIL_SELECT_DEVICE = 0xC00D117C;

		/// <summary>Windows Media Player cannot open the WAV file.</summary>
		public const uint NS_E_PDA_FAIL_READ_WAVE_FILE = 0xC00D117D;

		/// <summary>Windows Media Player failed to burn all the files to the CD. Select a slower recording speed, and then try again.</summary>
		public const uint NS_E_IMAPI_LOSSOFSTREAMING = 0xC00D117E;

		/// <summary>There is not enough storage space on the portable device to complete this operation. Delete some unneeded files on the portable device, and then try again.</summary>
		public const uint NS_E_PDA_DEVICE_FULL = 0xC00D117F;

		/// <summary>Windows Media Player cannot burn the files. Verify that your burner is connected properly, and then try again. If the problem persists, reinstall the Player.</summary>
		public const uint NS_E_FAIL_LAUNCH_ROXIO_PLUGIN = 0xC00D1180;

		/// <summary>Windows Media Player did not sync some files to the device because there is not enough storage space on the device.</summary>
		public const uint NS_E_PDA_DEVICE_FULL_IN_SESSION = 0xC00D1181;

		/// <summary>The disc in the burner is not valid. Insert a blank disc into the burner, and then try again.</summary>
		public const uint NS_E_IMAPI_MEDIUM_INVALIDTYPE = 0xC00D1182;

		/// <summary>Windows Media Player cannot perform the requested action because the device does not support sync.</summary>
		public const uint NS_E_PDA_MANUALDEVICE = 0xC00D1183;

		/// <summary>To perform the requested action, you must first set up sync with the device.</summary>
		public const uint NS_E_PDA_PARTNERSHIPNOTEXIST = 0xC00D1184;

		/// <summary>You have already created sync partnerships with 16 devices. To create a new sync partnership, you must first end an existing partnership.</summary>
		public const uint NS_E_PDA_CANNOT_CREATE_ADDITIONAL_SYNC_RELATIONSHIP = 0xC00D1185;

		/// <summary>Windows Media Player cannot sync the file because protected files cannot be converted to the required quality level or file format.</summary>
		public const uint NS_E_PDA_NO_TRANSCODE_OF_DRM = 0xC00D1186;

		/// <summary>The folder that stores converted files is full. Either empty the folder or increase its size, and then try again.</summary>
		public const uint NS_E_PDA_TRANSCODECACHEFULL = 0xC00D1187;

		/// <summary>There are too many files with the same name in the folder on the device. Change the file name or sync to a different folder.</summary>
		public const uint NS_E_PDA_TOO_MANY_FILE_COLLISIONS = 0xC00D1188;

		/// <summary>Windows Media Player cannot convert the file to the format required by the device.</summary>
		public const uint NS_E_PDA_CANNOT_TRANSCODE = 0xC00D1189;

		/// <summary>You have reached the maximum number of files your device allows in a folder. If your device supports playback from subfolders, try creating subfolders on the device and storing some files in them.</summary>
		public const uint NS_E_PDA_TOO_MANY_FILES_IN_DIRECTORY = 0xC00D118A;

		/// <summary>Windows Media Player is already trying to start the Device Setup Wizard.</summary>
		public const uint NS_E_PROCESSINGSHOWSYNCWIZARD = 0xC00D118B;

		/// <summary>Windows Media Player cannot convert this file format. If an updated version of the codec used to compress this file is available, install it and then try to sync the file again.</summary>
		public const uint NS_E_PDA_TRANSCODE_NOT_PERMITTED = 0xC00D118C;

		/// <summary>Windows Media Player is busy setting up devices. Try again later.</summary>
		public const uint NS_E_PDA_INITIALIZINGDEVICES = 0xC00D118D;

		/// <summary>Your device is using an outdated driver that is no longer supported by Windows Media Player. For additional assistance, click Web Help.</summary>
		public const uint NS_E_PDA_OBSOLETE_SP = 0xC00D118E;

		/// <summary>Windows Media Player cannot sync the file because a file with the same name already exists on the device. Change the file name or try to sync the file to a different folder.</summary>
		public const uint NS_E_PDA_TITLE_COLLISION = 0xC00D118F;

		/// <summary>Automatic and manual sync have been turned off temporarily. To sync to a device, restart Windows Media Player.</summary>
		public const uint NS_E_PDA_DEVICESUPPORTDISABLED = 0xC00D1190;

		/// <summary>This device is not available. Connect the device to the computer, and then try again.</summary>
		public const uint NS_E_PDA_NO_LONGER_AVAILABLE = 0xC00D1191;

		/// <summary>Windows Media Player cannot sync the file because an error occurred while converting the file to another quality level or format. If the problem persists, remove the file from the list of files to sync.</summary>
		public const uint NS_E_PDA_ENCODER_NOT_RESPONDING = 0xC00D1192;

		/// <summary>Windows Media Player cannot sync the file to your device. The file might be stored in a location that is not supported. Copy the file from its current location to your hard disk, add it to your library, and then try to sync the file again.</summary>
		public const uint NS_E_PDA_CANNOT_SYNC_FROM_LOCATION = 0xC00D1193;

		/// <summary>Windows Media Player cannot open the specified URL. Verify that the Player is configured to use all available protocols, and then try again.</summary>
		public const uint NS_E_WMP_PROTOCOL_PROBLEM = 0xC00D1194;

		/// <summary>Windows Media Player cannot perform the requested action because there is not enough storage space on your computer. Delete some unneeded files on your hard disk, and then try again.</summary>
		public const uint NS_E_WMP_NO_DISK_SPACE = 0xC00D1195;

		/// <summary>The server denied access to the file. Verify that you are using the correct user name and password.</summary>
		public const uint NS_E_WMP_LOGON_FAILURE = 0xC00D1196;

		/// <summary>Windows Media Player cannot find the file. If you are trying to play, burn, or sync an item that is in your library, the item might point to a file that has been moved, renamed, or deleted.</summary>
		public const uint NS_E_WMP_CANNOT_FIND_FILE = 0xC00D1197;

		/// <summary>Windows Media Player cannot connect to the server. The server name might not be correct, the server might not be available, or your proxy settings might not be correct.</summary>
		public const uint NS_E_WMP_SERVER_INACCESSIBLE = 0xC00D1198;

		/// <summary>Windows Media Player cannot play the file. The Player might not support the file type or might not support the codec that was used to compress the file.</summary>
		public const uint NS_E_WMP_UNSUPPORTED_FORMAT = 0xC00D1199;

		/// <summary>Windows Media Player cannot play the file. The Player might not support the file type or a required codec might not be installed on your computer.</summary>
		public const uint NS_E_WMP_DSHOW_UNSUPPORTED_FORMAT = 0xC00D119A;

		/// <summary>Windows Media Player cannot create the playlist because the name already exists. Type a different playlist name.</summary>
		public const uint NS_E_WMP_PLAYLIST_EXISTS = 0xC00D119B;

		/// <summary>Windows Media Player cannot delete the playlist because it contains items that are not digital media files. Any digital media files in the playlist were deleted.</summary>
		public const uint NS_E_WMP_NONMEDIA_FILES = 0xC00D119C;

		/// <summary>The playlist cannot be opened because it is stored in a shared folder on another computer. If possible, move the playlist to the playlists folder on your computer.</summary>
		public const uint NS_E_WMP_INVALID_ASX = 0xC00D119D;

		/// <summary>Windows Media Player is already in use. Stop playing any items, close all Player dialog boxes, and then try again.</summary>
		public const uint NS_E_WMP_ALREADY_IN_USE = 0xC00D119E;

		/// <summary>Windows Media Player encountered an error while burning. Verify that the burner is connected properly and that the disc is clean and not damaged.</summary>
		public const uint NS_E_WMP_IMAPI_FAILURE = 0xC00D119F;

		/// <summary>Windows Media Player has encountered an unknown error with your portable device. Reconnect your portable device, and then try again.</summary>
		public const uint NS_E_WMP_WMDM_FAILURE = 0xC00D11A0;

		/// <summary>A codec is required to play this file. To determine if this codec is available to download from the web, click Web Help.</summary>
		public const uint NS_E_WMP_CODEC_NEEDED_WITH_4CC = 0xC00D11A1;

		/// <summary>An audio codec is needed to play this file. To determine if this codec is available to download from the web, click Web Help.</summary>
		public const uint NS_E_WMP_CODEC_NEEDED_WITH_FORMATTAG = 0xC00D11A2;

		/// <summary>To play the file, you must install the latest Windows service pack. To install the service pack from the Windows Update website, click Web Help.</summary>
		public const uint NS_E_WMP_MSSAP_NOT_AVAILABLE = 0xC00D11A3;

		/// <summary>Windows Media Player no longer detects a portable device. Reconnect your portable device, and then try again.</summary>
		public const uint NS_E_WMP_WMDM_INTERFACEDEAD = 0xC00D11A4;

		/// <summary>Windows Media Player cannot sync the file because the portable device does not support protected files.</summary>
		public const uint NS_E_WMP_WMDM_NOTCERTIFIED = 0xC00D11A5;

		/// <summary>This file does not have sync rights. If you obtained this file from an online store, go to the online store to get sync rights.</summary>
		public const uint NS_E_WMP_WMDM_LICENSE_NOTEXIST = 0xC00D11A6;

		/// <summary>Windows Media Player cannot sync the file because the sync rights have expired. Go to the content provider's online store to get new sync rights.</summary>
		public const uint NS_E_WMP_WMDM_LICENSE_EXPIRED = 0xC00D11A7;

		/// <summary>The portable device is already in use. Wait until the current task finishes or quit other programs that might be using the portable device, and then try again.</summary>
		public const uint NS_E_WMP_WMDM_BUSY = 0xC00D11A8;

		/// <summary>Windows Media Player cannot sync the file because the content provider or device prohibits it. You might be able to resolve this problem by going to the content provider's online store to get sync rights.</summary>
		public const uint NS_E_WMP_WMDM_NORIGHTS = 0xC00D11A9;

		/// <summary>The content provider has not granted you the right to sync this file. Go to the content provider's online store to get sync rights.</summary>
		public const uint NS_E_WMP_WMDM_INCORRECT_RIGHTS = 0xC00D11AA;

		/// <summary>Windows Media Player cannot burn the files to the CD. Verify that the disc is clean and not damaged. If necessary, select a slower recording speed or try a different brand of blank discs.</summary>
		public const uint NS_E_WMP_IMAPI_GENERIC = 0xC00D11AB;

		/// <summary>Windows Media Player cannot burn the files. Verify that the burner is connected properly, and then try again.</summary>
		public const uint NS_E_WMP_IMAPI_DEVICE_NOTPRESENT = 0xC00D11AD;

		/// <summary>Windows Media Player cannot burn the files. Verify that the burner is connected properly and that the disc is clean and not damaged. If the burner is already in use, wait until the current task finishes or quit other programs that might be using the burner.</summary>
		public const uint NS_E_WMP_IMAPI_DEVICE_BUSY = 0xC00D11AE;

		/// <summary>Windows Media Player cannot burn the files to the CD.</summary>
		public const uint NS_E_WMP_IMAPI_LOSS_OF_STREAMING = 0xC00D11AF;

		/// <summary>Windows Media Player cannot play the file. The server might not be available or there might be a problem with your network or firewall settings.</summary>
		public const uint NS_E_WMP_SERVER_UNAVAILABLE = 0xC00D11B0;

		/// <summary>Windows Media Player encountered a problem while playing the file. For additional assistance, click Web Help.</summary>
		public const uint NS_E_WMP_FILE_OPEN_FAILED = 0xC00D11B1;

		/// <summary>Windows Media Player must connect to the Internet to verify the file's media usage rights. Connect to the Internet, and then try again.</summary>
		public const uint NS_E_WMP_VERIFY_ONLINE = 0xC00D11B2;

		/// <summary>Windows Media Player cannot play the file because a network error occurred. The server might not be available. Verify that you are connected to the network and that your proxy settings are correct.</summary>
		public const uint NS_E_WMP_SERVER_NOT_RESPONDING = 0xC00D11B3;

		/// <summary>Windows Media Player cannot restore your media usage rights because it could not find any backed up rights on your computer.</summary>
		public const uint NS_E_WMP_DRM_CORRUPT_BACKUP = 0xC00D11B4;

		/// <summary>Windows Media Player cannot download media usage rights because the server is not available (for example, the server might be busy or not online).</summary>
		public const uint NS_E_WMP_DRM_LICENSE_SERVER_UNAVAILABLE = 0xC00D11B5;

		/// <summary>Windows Media Player cannot play the file. A network firewall might be preventing the Player from opening the file by using the UDP transport protocol. If you typed a URL in the Open URL dialog box, try using a different transport protocol (for example, "http:").</summary>
		public const uint NS_E_WMP_NETWORK_FIREWALL = 0xC00D11B6;

		/// <summary>Insert the removable media, and then try again.</summary>
		public const uint NS_E_WMP_NO_REMOVABLE_MEDIA = 0xC00D11B7;

		/// <summary>Windows Media Player cannot play the file because the proxy server is not responding. The proxy server might be temporarily unavailable or your Player proxy settings might not be valid.</summary>
		public const uint NS_E_WMP_PROXY_CONNECT_TIMEOUT = 0xC00D11B8;

		/// <summary>To play the file, you might need to install a later version of Windows Media Player. On the Help menu, click Check for Updates, and then follow the instructions. For additional assistance, click Web Help.</summary>
		public const uint NS_E_WMP_NEED_UPGRADE = 0xC00D11B9;

		/// <summary>Windows Media Player cannot play the file because there is a problem with your sound device. There might not be a sound device installed on your computer, it might be in use by another program, or it might not be functioning properly.</summary>
		public const uint NS_E_WMP_AUDIO_HW_PROBLEM = 0xC00D11BA;

		/// <summary>Windows Media Player cannot play the file because the specified protocol is not supported. If you typed a URL in the Open URL dialog box, try using a different transport protocol (for example, "http:" or "rtsp:").</summary>
		public const uint NS_E_WMP_INVALID_PROTOCOL = 0xC00D11BB;

		/// <summary>Windows Media Player cannot add the file to the library because the file format is not supported.</summary>
		public const uint NS_E_WMP_INVALID_LIBRARY_ADD = 0xC00D11BC;

		/// <summary>Windows Media Player cannot play the file because the specified protocol is not supported. If you typed a URL in the Open URL dialog box, try using a different transport protocol (for example, "mms:").</summary>
		public const uint NS_E_WMP_MMS_NOT_SUPPORTED = 0xC00D11BD;

		/// <summary>Windows Media Player cannot play the file because there are no streaming protocols selected. Select one or more protocols, and then try again.</summary>
		public const uint NS_E_WMP_NO_PROTOCOLS_SELECTED = 0xC00D11BE;

		/// <summary>Windows Media Player cannot switch to Full Screen. You might need to adjust your Windows display settings. Open display settings in Control Panel, and then try setting Hardware acceleration to Full.</summary>
		public const uint NS_E_WMP_GOFULLSCREEN_FAILED = 0xC00D11BF;

		/// <summary>Windows Media Player cannot play the file because a network error occurred. The server might not be available (for example, the server is busy or not online) or you might not be connected to the network.</summary>
		public const uint NS_E_WMP_NETWORK_ERROR = 0xC00D11C0;

		/// <summary>Windows Media Player cannot play the file because the server is not responding. Verify that you are connected to the network, and then try again later.</summary>
		public const uint NS_E_WMP_CONNECT_TIMEOUT = 0xC00D11C1;

		/// <summary>Windows Media Player cannot play the file because the multicast protocol is not enabled. On the Tools menu, click Options, click the Network tab, and then select the Multicast check box. For additional assistance, click Web Help.</summary>
		public const uint NS_E_WMP_MULTICAST_DISABLED = 0xC00D11C2;

		/// <summary>Windows Media Player cannot play the file because a network problem occurred. Verify that you are connected to the network, and then try again later.</summary>
		public const uint NS_E_WMP_SERVER_DNS_TIMEOUT = 0xC00D11C3;

		/// <summary>Windows Media Player cannot play the file because the network proxy server cannot be found. Verify that your proxy settings are correct, and then try again.</summary>
		public const uint NS_E_WMP_PROXY_NOT_FOUND = 0xC00D11C4;

		/// <summary>Windows Media Player cannot play the file because it is corrupted.</summary>
		public const uint NS_E_WMP_TAMPERED_CONTENT = 0xC00D11C5;

		/// <summary>Your computer is running low on memory. Quit other programs, and then try again.</summary>
		public const uint NS_E_WMP_OUTOFMEMORY = 0xC00D11C6;

		/// <summary>Windows Media Player cannot play, burn, rip, or sync the file because a required audio codec is not installed on your computer.</summary>
		public const uint NS_E_WMP_AUDIO_CODEC_NOT_INSTALLED = 0xC00D11C7;

		/// <summary>Windows Media Player cannot play the file because the required video codec is not installed on your computer.</summary>
		public const uint NS_E_WMP_VIDEO_CODEC_NOT_INSTALLED = 0xC00D11C8;

		/// <summary>Windows Media Player cannot burn the files. If the burner is busy, wait for the current task to finish. If necessary, verify that the burner is connected properly and that you have installed the latest device driver.</summary>
		public const uint NS_E_WMP_IMAPI_DEVICE_INVALIDTYPE = 0xC00D11C9;

		/// <summary>Windows Media Player cannot play the protected file because there is a problem with your sound device. Try installing a new device driver or use a different sound device.</summary>
		public const uint NS_E_WMP_DRM_DRIVER_AUTH_FAILURE = 0xC00D11CA;

		/// <summary>Windows Media Player encountered a network error. Restart the Player.</summary>
		public const uint NS_E_WMP_NETWORK_RESOURCE_FAILURE = 0xC00D11CB;

		/// <summary>Windows Media Player is not installed properly. Reinstall the Player.</summary>
		public const uint NS_E_WMP_UPGRADE_APPLICATION = 0xC00D11CC;

		/// <summary>Windows Media Player encountered an unknown error. For additional assistance, click Web Help.</summary>
		public const uint NS_E_WMP_UNKNOWN_ERROR = 0xC00D11CD;

		/// <summary>Windows Media Player cannot play the file because the required codec is not valid.</summary>
		public const uint NS_E_WMP_INVALID_KEY = 0xC00D11CE;

		/// <summary>The CD drive is in use by another user. Wait for the task to complete, and then try again.</summary>
		public const uint NS_E_WMP_CD_ANOTHER_USER = 0xC00D11CF;

		/// <summary>Windows Media Player cannot play, sync, or burn the protected file because a problem occurred with the Windows Media Digital Rights Management (DRM) system. You might need to connect to the Internet to update your DRM components. For additional assistance, click Web Help.</summary>
		public const uint NS_E_WMP_DRM_NEEDS_AUTHORIZATION = 0xC00D11D0;

		/// <summary>Windows Media Player cannot play the file because there might be a problem with your sound or video device. Try installing an updated device driver.</summary>
		public const uint NS_E_WMP_BAD_DRIVER = 0xC00D11D1;

		/// <summary>Windows Media Player cannot access the file. The file might be in use, you might not have access to the computer where the file is stored, or your proxy settings might not be correct.</summary>
		public const uint NS_E_WMP_ACCESS_DENIED = 0xC00D11D2;

		/// <summary>The content provider prohibits this action. Go to the content provider's online store to get new media usage rights.</summary>
		public const uint NS_E_WMP_LICENSE_RESTRICTS = 0xC00D11D3;

		/// <summary>Windows Media Player cannot perform the requested action at this time.</summary>
		public const uint NS_E_WMP_INVALID_REQUEST = 0xC00D11D4;

		/// <summary>Windows Media Player cannot burn the files because there is not enough free disk space to store the temporary files. Delete some unneeded files on your hard disk, and then try again.</summary>
		public const uint NS_E_WMP_CD_STASH_NO_SPACE = 0xC00D11D5;

		/// <summary>Your media usage rights have become corrupted or are no longer valid. This might happen if you have replaced hardware components in your computer.</summary>
		public const uint NS_E_WMP_DRM_NEW_HARDWARE = 0xC00D11D6;

		/// <summary>The required Windows Media Digital Rights Management (DRM) component cannot be validated. You might be able resolve the problem by reinstalling the Player.</summary>
		public const uint NS_E_WMP_DRM_INVALID_SIG = 0xC00D11D7;

		/// <summary>You have exceeded your restore limit for the day. Try restoring your media usage rights tomorrow.</summary>
		public const uint NS_E_WMP_DRM_CANNOT_RESTORE = 0xC00D11D8;

		/// <summary>Some files might not fit on the CD. The required space cannot be calculated accurately because some files might be missing duration information. To ensure the calculation is accurate, play the files that are missing duration information.</summary>
		public const uint NS_E_WMP_BURN_DISC_OVERFLOW = 0xC00D11D9;

		/// <summary>Windows Media Player cannot verify the file's media usage rights. If you obtained this file from an online store, go to the online store to get the necessary rights.</summary>
		public const uint NS_E_WMP_DRM_GENERIC_LICENSE_FAILURE = 0xC00D11DA;

		/// <summary>It is not possible to sync because this device's internal clock is not set correctly. To set the clock, select the option to set the device clock on the Privacy tab of the Options dialog box, connect to the Internet, and then sync the device again. For additional assistance, click Web Help.</summary>
		public const uint NS_E_WMP_DRM_NO_SECURE_CLOCK = 0xC00D11DB;

		/// <summary>Windows Media Player cannot play, burn, rip, or sync the protected file because you do not have the appropriate rights.</summary>
		public const uint NS_E_WMP_DRM_NO_RIGHTS = 0xC00D11DC;

		/// <summary>Windows Media Player encountered an error during upgrade.</summary>
		public const uint NS_E_WMP_DRM_INDIV_FAILED = 0xC00D11DD;

		/// <summary>Windows Media Player cannot connect to the server because it is not accepting any new connections. This could be because it has reached its maximum connection limit. Please try again later.</summary>
		public const uint NS_E_WMP_SERVER_NONEWCONNECTIONS = 0xC00D11DE;

		/// <summary>A number of queued files cannot be played. To find information about the problem, click the Now Playing tab, and then click the icon next to each file in the List pane.</summary>
		public const uint NS_E_WMP_MULTIPLE_ERROR_IN_PLAYLIST = 0xC00D11DF;

		/// <summary>Windows Media Player encountered an error while erasing the rewritable CD or DVD. Verify that the CD or DVD burner is connected properly and that the disc is clean and not damaged.</summary>
		public const uint NS_E_WMP_IMAPI2_ERASE_FAIL = 0xC00D11E0;

		/// <summary>Windows Media Player cannot erase the rewritable CD or DVD. Verify that the CD or DVD burner is connected properly and that the disc is clean and not damaged. If the burner is already in use, wait until the current task finishes or quit other programs that might be using the burner.</summary>
		public const uint NS_E_WMP_IMAPI2_ERASE_DEVICE_BUSY = 0xC00D11E1;

		/// <summary>A Windows Media Digital Rights Management (DRM) component encountered a problem. If you are trying to use a file that you obtained from an online store, try going to the online store and getting the appropriate usage rights.</summary>
		public const uint NS_E_WMP_DRM_COMPONENT_FAILURE = 0xC00D11E2;

		/// <summary>It is not possible to obtain device's certificate. Please contact the device manufacturer for a firmware update or for other steps to resolve this problem.</summary>
		public const uint NS_E_WMP_DRM_NO_DEVICE_CERT = 0xC00D11E3;

		/// <summary>Windows Media Player encountered an error when connecting to the server. The security information from the server could not be validated.</summary>
		public const uint NS_E_WMP_SERVER_SECURITY_ERROR = 0xC00D11E4;

		/// <summary>An audio device was disconnected or reconfigured. Verify that the audio device is connected, and then try to play the item again.</summary>
		public const uint NS_E_WMP_AUDIO_DEVICE_LOST = 0xC00D11E5;

		/// <summary>Windows Media Player could not complete burning because the disc is not compatible with your drive. Try inserting a different kind of recordable media or use a disc that supports a write speed that is compatible with your drive.</summary>
		public const uint NS_E_WMP_IMAPI_MEDIA_INCOMPATIBLE = 0xC00D11E6;

		/// <summary>Windows Media Player cannot save the sync settings because your device is full. Delete some unneeded files on your device and then try again.</summary>
		public const uint NS_E_SYNCWIZ_DEVICE_FULL = 0xC00D11EE;

		/// <summary>It is not possible to change sync settings at this time. Try again later.</summary>
		public const uint NS_E_SYNCWIZ_CANNOT_CHANGE_SETTINGS = 0xC00D11EF;

		/// <summary>Windows Media Player cannot delete these files currently. If the Player is synchronizing, wait until it is complete and then try again.</summary>
		public const uint NS_E_TRANSCODE_DELETECACHEERROR = 0xC00D11F0;

		/// <summary>Windows Media Player could not use digital mode to read the CD. The Player has automatically switched the CD drive to analog mode. To switch back to digital mode, use the Devices tab. For additional assistance, click Web Help.</summary>
		public const uint NS_E_CD_NO_BUFFERS_READ = 0xC00D11F8;

		/// <summary>No CD track was specified for playback.</summary>
		public const uint NS_E_CD_EMPTY_TRACK_QUEUE = 0xC00D11F9;

		/// <summary>The CD filter was not able to create the CD reader.</summary>
		public const uint NS_E_CD_NO_READER = 0xC00D11FA;

		/// <summary>Invalid ISRC code.</summary>
		public const uint NS_E_CD_ISRC_INVALID = 0xC00D11FB;

		/// <summary>Invalid Media Catalog Number.</summary>
		public const uint NS_E_CD_MEDIA_CATALOG_NUMBER_INVALID = 0xC00D11FC;

		/// <summary>Windows Media Player cannot play audio CDs correctly because the CD drive is slow and error correction is turned on. To increase performance, turn off playback error correction for this drive.</summary>
		public const uint NS_E_SLOW_READ_DIGITAL_WITH_ERRORCORRECTION = 0xC00D11FD;

		/// <summary>Windows Media Player cannot estimate the CD drive's playback speed because the CD track is too short.</summary>
		public const uint NS_E_CD_SPEEDDETECT_NOT_ENOUGH_READS = 0xC00D11FE;

		/// <summary>Cannot queue the CD track because queuing is not enabled.</summary>
		public const uint NS_E_CD_QUEUEING_DISABLED = 0xC00D11FF;

		/// <summary>Windows Media Player cannot download additional media usage rights until the current download is complete.</summary>
		public const uint NS_E_WMP_DRM_ACQUIRING_LICENSE = 0xC00D1202;

		/// <summary>The media usage rights for this file have expired or are no longer valid. If you obtained the file from an online store, sign in to the store, and then try again.</summary>
		public const uint NS_E_WMP_DRM_LICENSE_EXPIRED = 0xC00D1203;

		/// <summary>Windows Media Player cannot download the media usage rights for the file. If you obtained the file from an online store, sign in to the store, and then try again.</summary>
		public const uint NS_E_WMP_DRM_LICENSE_NOTACQUIRED = 0xC00D1204;

		/// <summary>The media usage rights for this file are not yet valid. To see when they will become valid, right-click the file in the library, click Properties, and then click the Media Usage Rights tab.</summary>
		public const uint NS_E_WMP_DRM_LICENSE_NOTENABLED = 0xC00D1205;

		/// <summary>The media usage rights for this file are not valid. If you obtained this file from an online store, contact the store for assistance.</summary>
		public const uint NS_E_WMP_DRM_LICENSE_UNUSABLE = 0xC00D1206;

		/// <summary>The content provider has revoked the media usage rights for this file. If you obtained this file from an online store, ask the store if a new version of the file is available.</summary>
		public const uint NS_E_WMP_DRM_LICENSE_CONTENT_REVOKED = 0xC00D1207;

		/// <summary>The media usage rights for this file require a feature that is not supported in your current version of Windows Media Player or your current version of Windows. Try installing the latest version of the Player. If you obtained this file from an online store, contact the store for further assistance.</summary>
		public const uint NS_E_WMP_DRM_LICENSE_NOSAP = 0xC00D1208;

		/// <summary>Windows Media Player cannot download media usage rights at this time. Try again later.</summary>
		public const uint NS_E_WMP_DRM_UNABLE_TO_ACQUIRE_LICENSE = 0xC00D1209;

		/// <summary>Windows Media Player cannot play, burn, or sync the file because the media usage rights are missing. If you obtained the file from an online store, sign in to the store, and then try again.</summary>
		public const uint NS_E_WMP_LICENSE_REQUIRED = 0xC00D120A;

		/// <summary>Windows Media Player cannot play, burn, or sync the file because the media usage rights are missing. If you obtained the file from an online store, sign in to the store, and then try again.</summary>
		public const uint NS_E_WMP_PROTECTED_CONTENT = 0xC00D120B;

		/// <summary>Windows Media Player cannot read a policy. This can occur when the policy does not exist in the registry or when the registry cannot be read.</summary>
		public const uint NS_E_WMP_POLICY_VALUE_NOT_CONFIGURED = 0xC00D122A;

		/// <summary>Windows Media Player cannot sync content streamed directly from the Internet. If possible, download the file to your computer, and then try to sync the file.</summary>
		public const uint NS_E_PDA_CANNOT_SYNC_FROM_INTERNET = 0xC00D1234;

		/// <summary>This playlist is not valid or is corrupted. Create a new playlist using Windows Media Player, then sync the new playlist instead.</summary>
		public const uint NS_E_PDA_CANNOT_SYNC_INVALID_PLAYLIST = 0xC00D1235;

		/// <summary>Windows Media Player encountered a problem while synchronizing the file to the device. For additional assistance, click Web Help.</summary>
		public const uint NS_E_PDA_FAILED_TO_SYNCHRONIZE_FILE = 0xC00D1236;

		/// <summary>Windows Media Player encountered an error while synchronizing to the device.</summary>
		public const uint NS_E_PDA_SYNC_FAILED = 0xC00D1237;

		/// <summary>Windows Media Player cannot delete a file from the device.</summary>
		public const uint NS_E_PDA_DELETE_FAILED = 0xC00D1238;

		/// <summary>Windows Media Player cannot copy a file from the device to your library.</summary>
		public const uint NS_E_PDA_FAILED_TO_RETRIEVE_FILE = 0xC00D1239;

		/// <summary>Windows Media Player cannot communicate with the device because the device is not responding. Try reconnecting the device, resetting the device, or contacting the device manufacturer for updated firmware.</summary>
		public const uint NS_E_PDA_DEVICE_NOT_RESPONDING = 0xC00D123A;

		/// <summary>Windows Media Player cannot sync the picture to the device because a problem occurred while converting the file to another quality level or format. The original file might be damaged or corrupted.</summary>
		public const uint NS_E_PDA_FAILED_TO_TRANSCODE_PHOTO = 0xC00D123B;

		/// <summary>Windows Media Player cannot convert the file. The file might have been encrypted by the Encrypted File System (EFS). Try decrypting the file first and then synchronizing it. For information about how to decrypt a file, see Windows Help and Support.</summary>
		public const uint NS_E_PDA_FAILED_TO_ENCRYPT_TRANSCODED_FILE = 0xC00D123C;

		/// <summary>Your device requires that this file be converted in order to play on the device. However, the device either does not support playing audio, or Windows Media Player cannot convert the file to an audio format that is supported by the device.</summary>
		public const uint NS_E_PDA_CANNOT_TRANSCODE_TO_AUDIO = 0xC00D123D;

		/// <summary>Your device requires that this file be converted in order to play on the device. However, the device either does not support playing video, or Windows Media Player cannot convert the file to a video format that is supported by the device.</summary>
		public const uint NS_E_PDA_CANNOT_TRANSCODE_TO_VIDEO = 0xC00D123E;

		/// <summary>Your device requires that this file be converted in order to play on the device. However, the device either does not support displaying pictures, or Windows Media Player cannot convert the file to a picture format that is supported by the device.</summary>
		public const uint NS_E_PDA_CANNOT_TRANSCODE_TO_IMAGE = 0xC00D123F;

		/// <summary>Windows Media Player cannot sync the file to your computer because the file name is too long. Try renaming the file on the device.</summary>
		public const uint NS_E_PDA_RETRIEVED_FILE_FILENAME_TOO_LONG = 0xC00D1240;

		/// <summary>Windows Media Player cannot sync the file because the device is not responding. This typically occurs when there is a problem with the device firmware. For additional assistance, click Web Help.</summary>
		public const uint NS_E_PDA_CEWMDM_DRM_ERROR = 0xC00D1241;

		/// <summary>Incomplete playlist.</summary>
		public const uint NS_E_INCOMPLETE_PLAYLIST = 0xC00D1242;

		/// <summary>It is not possible to perform the requested action because sync is in progress. You can either stop sync or wait for it to complete, and then try again.</summary>
		public const uint NS_E_PDA_SYNC_RUNNING = 0xC00D1243;

		/// <summary>Windows Media Player cannot sync the subscription content because you are not signed in to the online store that provided it. Sign in to the online store, and then try again.</summary>
		public const uint NS_E_PDA_SYNC_LOGIN_ERROR = 0xC00D1244;

		/// <summary>Windows Media Player cannot convert the file to the format required by the device. One or more codecs required to convert the file could not be found.</summary>
		public const uint NS_E_PDA_TRANSCODE_CODEC_NOT_FOUND = 0xC00D1245;

		/// <summary>It is not possible to sync subscription files to this device.</summary>
		public const uint NS_E_CANNOT_SYNC_DRM_TO_NON_JANUS_DEVICE = 0xC00D1246;

		/// <summary>Your device is operating slowly or is not responding. Until the device responds, it is not possible to sync again. To return the device to normal operation, try disconnecting it from the computer or resetting it.</summary>
		public const uint NS_E_CANNOT_SYNC_PREVIOUS_SYNC_RUNNING = 0xC00D1247;

		/// <summary>The Windows Media Player download manager cannot function properly because the Player main window cannot be found. Try restarting the Player.</summary>
		public const uint NS_E_WMP_HWND_NOTFOUND = 0xC00D125C;

		/// <summary>Windows Media Player encountered a download that has the wrong number of files. This might occur if another program is trying to create jobs with the same signature as the Player.</summary>
		public const uint NS_E_BKGDOWNLOAD_WRONG_NO_FILES = 0xC00D125D;

		/// <summary>Windows Media Player tried to complete a download that was already canceled. The file will not be available.</summary>
		public const uint NS_E_BKGDOWNLOAD_COMPLETECANCELLEDJOB = 0xC00D125E;

		/// <summary>Windows Media Player tried to cancel a download that was already completed. The file will not be removed.</summary>
		public const uint NS_E_BKGDOWNLOAD_CANCELCOMPLETEDJOB = 0xC00D125F;

		/// <summary>Windows Media Player is trying to access a download that is not valid.</summary>
		public const uint NS_E_BKGDOWNLOAD_NOJOBPOINTER = 0xC00D1260;

		/// <summary>This download was not created by Windows Media Player.</summary>
		public const uint NS_E_BKGDOWNLOAD_INVALIDJOBSIGNATURE = 0xC00D1261;

		/// <summary>The Windows Media Player download manager cannot create a temporary file name. This might occur if the path is not valid or if the disk is full.</summary>
		public const uint NS_E_BKGDOWNLOAD_FAILED_TO_CREATE_TEMPFILE = 0xC00D1262;

		/// <summary>The Windows Media Player download manager plug-in cannot start. This might occur if the system is out of resources.</summary>
		public const uint NS_E_BKGDOWNLOAD_PLUGIN_FAILEDINITIALIZE = 0xC00D1263;

		/// <summary>The Windows Media Player download manager cannot move the file.</summary>
		public const uint NS_E_BKGDOWNLOAD_PLUGIN_FAILEDTOMOVEFILE = 0xC00D1264;

		/// <summary>The Windows Media Player download manager cannot perform a task because the system has no resources to allocate.</summary>
		public const uint NS_E_BKGDOWNLOAD_CALLFUNCFAILED = 0xC00D1265;

		/// <summary>The Windows Media Player download manager cannot perform a task because the task took too long to run.</summary>
		public const uint NS_E_BKGDOWNLOAD_CALLFUNCTIMEOUT = 0xC00D1266;

		/// <summary>The Windows Media Player download manager cannot perform a task because the Player is terminating the service. The task will be recovered when the Player restarts.</summary>
		public const uint NS_E_BKGDOWNLOAD_CALLFUNCENDED = 0xC00D1267;

		/// <summary>The Windows Media Player download manager cannot expand a WMD file. The file will be deleted and the operation will not be completed successfully.</summary>
		public const uint NS_E_BKGDOWNLOAD_WMDUNPACKFAILED = 0xC00D1268;

		/// <summary>The Windows Media Player download manager cannot start. This might occur if the system is out of resources.</summary>
		public const uint NS_E_BKGDOWNLOAD_FAILEDINITIALIZE = 0xC00D1269;

		/// <summary>Windows Media Player cannot access a required functionality. This might occur if the wrong system files or Player DLLs are loaded.</summary>
		public const uint NS_E_INTERFACE_NOT_REGISTERED_IN_GIT = 0xC00D126A;

		/// <summary>Windows Media Player cannot get the file name of the requested download. The requested download will be canceled.</summary>
		public const uint NS_E_BKGDOWNLOAD_INVALID_FILE_NAME = 0xC00D126B;

		/// <summary>Windows Media Player encountered an error while downloading an image.</summary>
		public const uint NS_E_IMAGE_DOWNLOAD_FAILED = 0xC00D128E;

		/// <summary>Windows Media Player cannot update your media usage rights because the Player cannot verify the list of activated users of this computer.</summary>
		public const uint NS_E_WMP_UDRM_NOUSERLIST = 0xC00D12C0;

		/// <summary>Windows Media Player is trying to acquire media usage rights for a file that is no longer being used. Rights acquisition will stop.</summary>
		public const uint NS_E_WMP_DRM_NOT_ACQUIRING = 0xC00D12C1;

		/// <summary>The parameter is not valid.</summary>
		public const uint NS_E_WMP_BSTR_TOO_LONG = 0xC00D12F2;

		/// <summary>The state is not valid for this request.</summary>
		public const uint NS_E_WMP_AUTOPLAY_INVALID_STATE = 0xC00D12FC;

		/// <summary>Windows Media Player cannot play this file until you complete the software component upgrade. After the component has been upgraded, try to play the file again.</summary>
		public const uint NS_E_WMP_COMPONENT_REVOKED = 0xC00D1306;

		/// <summary>The URL is not safe for the operation specified.</summary>
		public const uint NS_E_CURL_NOTSAFE = 0xC00D1324;

		/// <summary>The URL contains one or more characters that are not valid.</summary>
		public const uint NS_E_CURL_INVALIDCHAR = 0xC00D1325;

		/// <summary>The URL contains a host name that is not valid.</summary>
		public const uint NS_E_CURL_INVALIDHOSTNAME = 0xC00D1326;

		/// <summary>The URL contains a path that is not valid.</summary>
		public const uint NS_E_CURL_INVALIDPATH = 0xC00D1327;

		/// <summary>The URL contains a scheme that is not valid.</summary>
		public const uint NS_E_CURL_INVALIDSCHEME = 0xC00D1328;

		/// <summary>The URL is not valid.</summary>
		public const uint NS_E_CURL_INVALIDURL = 0xC00D1329;

		/// <summary>Windows Media Player cannot play the file. If you clicked a link on a web page, the link might not be valid.</summary>
		public const uint NS_E_CURL_CANTWALK = 0xC00D132B;

		/// <summary>The URL port is not valid.</summary>
		public const uint NS_E_CURL_INVALIDPORT = 0xC00D132C;

		/// <summary>The URL is not a directory.</summary>
		public const uint NS_E_CURLHELPER_NOTADIRECTORY = 0xC00D132D;

		/// <summary>The URL is not a file.</summary>
		public const uint NS_E_CURLHELPER_NOTAFILE = 0xC00D132E;

		/// <summary>The URL contains characters that cannot be decoded. The URL might be truncated or incomplete.</summary>
		public const uint NS_E_CURL_CANTDECODE = 0xC00D132F;

		/// <summary>The specified URL is not a relative URL.</summary>
		public const uint NS_E_CURLHELPER_NOTRELATIVE = 0xC00D1330;

		/// <summary>The buffer is smaller than the size specified.</summary>
		public const uint NS_E_CURL_INVALIDBUFFERSIZE = 0xC00D1331;

		/// <summary>The content provider has not granted you the right to play this file. Go to the content provider's online store to get play rights.</summary>
		public const uint NS_E_SUBSCRIPTIONSERVICE_PLAYBACK_DISALLOWED = 0xC00D1356;

		/// <summary>Windows Media Player cannot purchase or download content from multiple online stores.</summary>
		public const uint NS_E_CANNOT_BUY_OR_DOWNLOAD_FROM_MULTIPLE_SERVICES = 0xC00D1357;

		/// <summary>The file cannot be purchased or downloaded. The file might not be available from the online store.</summary>
		public const uint NS_E_CANNOT_BUY_OR_DOWNLOAD_CONTENT = 0xC00D1358;

		/// <summary>The provider of this file cannot be identified.</summary>
		public const uint NS_E_NOT_CONTENT_PARTNER_TRACK = 0xC00D135A;

		/// <summary>The file is only available for download when you buy the entire album.</summary>
		public const uint NS_E_TRACK_DOWNLOAD_REQUIRES_ALBUM_PURCHASE = 0xC00D135B;

		/// <summary>You must buy the file before you can download it.</summary>
		public const uint NS_E_TRACK_DOWNLOAD_REQUIRES_PURCHASE = 0xC00D135C;

		/// <summary>You have exceeded the maximum number of files that can be purchased in a single transaction.</summary>
		public const uint NS_E_TRACK_PURCHASE_MAXIMUM_EXCEEDED = 0xC00D135D;

		/// <summary>Windows Media Player cannot sign in to the online store. Verify that you are using the correct user name and password. If the problem persists, the store might be temporarily unavailable.</summary>
		public const uint NS_E_SUBSCRIPTIONSERVICE_LOGIN_FAILED = 0xC00D135F;

		/// <summary>Windows Media Player cannot download this item because the server is not responding. The server might be temporarily unavailable or the Internet connection might be lost.</summary>
		public const uint NS_E_SUBSCRIPTIONSERVICE_DOWNLOAD_TIMEOUT = 0xC00D1360;

		/// <summary>Content Partner still initializing.</summary>
		public const uint NS_E_CONTENT_PARTNER_STILL_INITIALIZING = 0xC00D1362;

		/// <summary>The folder could not be opened. The folder might have been moved or deleted.</summary>
		public const uint NS_E_OPEN_CONTAINING_FOLDER_FAILED = 0xC00D1363;

		/// <summary>Windows Media Player could not add all of the images to the file because the images exceeded the 7 megabyte (MB) limit.</summary>
		public const uint NS_E_ADVANCEDEDIT_TOO_MANY_PICTURES = 0xC00D136A;

		/// <summary>The client redirected to another server.</summary>
		public const uint NS_E_REDIRECT = 0xC00D1388;

		/// <summary>The streaming media description is no longer current.</summary>
		public const uint NS_E_STALE_PRESENTATION = 0xC00D1389;

		/// <summary>It is not possible to create a persistent namespace node under a transient parent node.</summary>
		public const uint NS_E_NAMESPACE_WRONG_PERSIST = 0xC00D138A;

		/// <summary>It is not possible to store a value in a namespace node that has a different value type.</summary>
		public const uint NS_E_NAMESPACE_WRONG_TYPE = 0xC00D138B;

		/// <summary>It is not possible to remove the root namespace node.</summary>
		public const uint NS_E_NAMESPACE_NODE_CONFLICT = 0xC00D138C;

		/// <summary>The specified namespace node could not be found.</summary>
		public const uint NS_E_NAMESPACE_NODE_NOT_FOUND = 0xC00D138D;

		/// <summary>The buffer supplied to hold namespace node string is too small.</summary>
		public const uint NS_E_NAMESPACE_BUFFER_TOO_SMALL = 0xC00D138E;

		/// <summary>The callback list on a namespace node is at the maximum size.</summary>
		public const uint NS_E_NAMESPACE_TOO_MANY_CALLBACKS = 0xC00D138F;

		/// <summary>It is not possible to register an already-registered callback on a namespace node.</summary>
		public const uint NS_E_NAMESPACE_DUPLICATE_CALLBACK = 0xC00D1390;

		/// <summary>Cannot find the callback in the namespace when attempting to remove the callback.</summary>
		public const uint NS_E_NAMESPACE_CALLBACK_NOT_FOUND = 0xC00D1391;

		/// <summary>The namespace node name exceeds the allowed maximum length.</summary>
		public const uint NS_E_NAMESPACE_NAME_TOO_LONG = 0xC00D1392;

		/// <summary>Cannot create a namespace node that already exists.</summary>
		public const uint NS_E_NAMESPACE_DUPLICATE_NAME = 0xC00D1393;

		/// <summary>The namespace node name cannot be a null string.</summary>
		public const uint NS_E_NAMESPACE_EMPTY_NAME = 0xC00D1394;

		/// <summary>Finding a child namespace node by index failed because the index exceeded the number of children.</summary>
		public const uint NS_E_NAMESPACE_INDEX_TOO_LARGE = 0xC00D1395;

		/// <summary>The namespace node name is invalid.</summary>
		public const uint NS_E_NAMESPACE_BAD_NAME = 0xC00D1396;

		/// <summary>It is not possible to store a value in a namespace node that has a different security type.</summary>
		public const uint NS_E_NAMESPACE_WRONG_SECURITY = 0xC00D1397;

		/// <summary>The archive request conflicts with other requests in progress.</summary>
		public const uint NS_E_CACHE_ARCHIVE_CONFLICT = 0xC00D13EC;

		/// <summary>The specified origin server cannot be found.</summary>
		public const uint NS_E_CACHE_ORIGIN_SERVER_NOT_FOUND = 0xC00D13ED;

		/// <summary>The specified origin server is not responding.</summary>
		public const uint NS_E_CACHE_ORIGIN_SERVER_TIMEOUT = 0xC00D13EE;

		/// <summary>The internal code for HTTP status code 412 Precondition Failed due to not broadcast type.</summary>
		public const uint NS_E_CACHE_NOT_BROADCAST = 0xC00D13EF;

		/// <summary>The internal code for HTTP status code 403 Forbidden due to not cacheable.</summary>
		public const uint NS_E_CACHE_CANNOT_BE_CACHED = 0xC00D13F0;

		/// <summary>The internal code for HTTP status code 304 Not Modified.</summary>
		public const uint NS_E_CACHE_NOT_MODIFIED = 0xC00D13F1;

		/// <summary>It is not possible to remove a cache or proxy publishing point.</summary>
		public const uint NS_E_CANNOT_REMOVE_PUBLISHING_POINT = 0xC00D1450;

		/// <summary>It is not possible to remove the last instance of a type of plug-in.</summary>
		public const uint NS_E_CANNOT_REMOVE_PLUGIN = 0xC00D1451;

		/// <summary>Cache and proxy publishing points do not support this property or method.</summary>
		public const uint NS_E_WRONG_PUBLISHING_POINT_TYPE = 0xC00D1452;

		/// <summary>The plug-in does not support the specified load type.</summary>
		public const uint NS_E_UNSUPPORTED_LOAD_TYPE = 0xC00D1453;

		/// <summary>The plug-in does not support any load types. The plug-in must support at least one load type.</summary>
		public const uint NS_E_INVALID_PLUGIN_LOAD_TYPE_CONFIGURATION = 0xC00D1454;

		/// <summary>The publishing point name is invalid.</summary>
		public const uint NS_E_INVALID_PUBLISHING_POINT_NAME = 0xC00D1455;

		/// <summary>Only one multicast data writer plug-in can be enabled for a publishing point.</summary>
		public const uint NS_E_TOO_MANY_MULTICAST_SINKS = 0xC00D1456;

		/// <summary>The requested operation cannot be completed while the publishing point is started.</summary>
		public const uint NS_E_PUBLISHING_POINT_INVALID_REQUEST_WHILE_STARTED = 0xC00D1457;

		/// <summary>A multicast data writer plug-in must be enabled in order for this operation to be completed.</summary>
		public const uint NS_E_MULTICAST_PLUGIN_NOT_ENABLED = 0xC00D1458;

		/// <summary>This feature requires Windows Server 2003, Enterprise Edition.</summary>
		public const uint NS_E_INVALID_OPERATING_SYSTEM_VERSION = 0xC00D1459;

		/// <summary>The requested operation cannot be completed because the specified publishing point has been removed.</summary>
		public const uint NS_E_PUBLISHING_POINT_REMOVED = 0xC00D145A;

		/// <summary>Push publishing points are started when the encoder starts pushing the stream. This publishing point cannot be started by the server administrator.</summary>
		public const uint NS_E_INVALID_PUSH_PUBLISHING_POINT_START_REQUEST = 0xC00D145B;

		/// <summary>The specified language is not supported.</summary>
		public const uint NS_E_UNSUPPORTED_LANGUAGE = 0xC00D145C;

		/// <summary>Windows Media Services will only run on Windows Server 2003, Standard Edition and Windows Server 2003, Enterprise Edition.</summary>
		public const uint NS_E_WRONG_OS_VERSION = 0xC00D145D;

		/// <summary>The operation cannot be completed because the publishing point has been stopped.</summary>
		public const uint NS_E_PUBLISHING_POINT_STOPPED = 0xC00D145E;

		/// <summary>The playlist entry is already playing.</summary>
		public const uint NS_E_PLAYLIST_ENTRY_ALREADY_PLAYING = 0xC00D14B4;

		/// <summary>The playlist or directory you are requesting does not contain content.</summary>
		public const uint NS_E_EMPTY_PLAYLIST = 0xC00D14B5;

		/// <summary>The server was unable to parse the requested playlist file.</summary>
		public const uint NS_E_PLAYLIST_PARSE_FAILURE = 0xC00D14B6;

		/// <summary>The requested operation is not supported for this type of playlist entry.</summary>
		public const uint NS_E_PLAYLIST_UNSUPPORTED_ENTRY = 0xC00D14B7;

		/// <summary>Cannot jump to a playlist entry that is not inserted in the playlist.</summary>
		public const uint NS_E_PLAYLIST_ENTRY_NOT_IN_PLAYLIST = 0xC00D14B8;

		/// <summary>Cannot seek to the desired playlist entry.</summary>
		public const uint NS_E_PLAYLIST_ENTRY_SEEK = 0xC00D14B9;

		/// <summary>Cannot play recursive playlist.</summary>
		public const uint NS_E_PLAYLIST_RECURSIVE_PLAYLISTS = 0xC00D14BA;

		/// <summary>The number of nested playlists exceeded the limit the server can handle.</summary>
		public const uint NS_E_PLAYLIST_TOO_MANY_NESTED_PLAYLISTS = 0xC00D14BB;

		/// <summary>Cannot execute the requested operation because the playlist has been shut down by the Media Server.</summary>
		public const uint NS_E_PLAYLIST_SHUTDOWN = 0xC00D14BC;

		/// <summary>The playlist has ended while receding.</summary>
		public const uint NS_E_PLAYLIST_END_RECEDING = 0xC00D14BD;

		/// <summary>The data path does not have an associated data writer plug-in.</summary>
		public const uint NS_E_DATAPATH_NO_SINK = 0xC00D1518;

		/// <summary>The specified push template is invalid.</summary>
		public const uint NS_E_INVALID_PUSH_TEMPLATE = 0xC00D151A;

		/// <summary>The specified push publishing point is invalid.</summary>
		public const uint NS_E_INVALID_PUSH_PUBLISHING_POINT = 0xC00D151B;

		/// <summary>The requested operation cannot be performed because the server or publishing point is in a critical error state.</summary>
		public const uint NS_E_CRITICAL_ERROR = 0xC00D151C;

		/// <summary>The content cannot be played because the server is not currently accepting connections. Try connecting at a later time.</summary>
		public const uint NS_E_NO_NEW_CONNECTIONS = 0xC00D151D;

		/// <summary>The version of this playlist is not supported by the server.</summary>
		public const uint NS_E_WSX_INVALID_VERSION = 0xC00D151E;

		/// <summary>The command does not apply to the current media header user by a server component.</summary>
		public const uint NS_E_HEADER_MISMATCH = 0xC00D151F;

		/// <summary>The specified publishing point name is already in use.</summary>
		public const uint NS_E_PUSH_DUPLICATE_PUBLISHING_POINT_NAME = 0xC00D1520;

		/// <summary>There is no script engine available for this file.</summary>
		public const uint NS_E_NO_SCRIPT_ENGINE = 0xC00D157C;

		/// <summary>The plug-in has reported an error. See the Troubleshooting tab or the NT Application Event Log for details.</summary>
		public const uint NS_E_PLUGIN_ERROR_REPORTED = 0xC00D157D;

		/// <summary>No enabled data source plug-in is available to access the requested content.</summary>
		public const uint NS_E_SOURCE_PLUGIN_NOT_FOUND = 0xC00D157E;

		/// <summary>No enabled playlist parser plug-in is available to access the requested content.</summary>
		public const uint NS_E_PLAYLIST_PLUGIN_NOT_FOUND = 0xC00D157F;

		/// <summary>The data source plug-in does not support enumeration.</summary>
		public const uint NS_E_DATA_SOURCE_ENUMERATION_NOT_SUPPORTED = 0xC00D1580;

		/// <summary>The server cannot stream the selected file because it is either damaged or corrupt. Select a different file.</summary>
		public const uint NS_E_MEDIA_PARSER_INVALID_FORMAT = 0xC00D1581;

		/// <summary>The plug-in cannot be enabled because a compatible script debugger is not installed on this system. Install a script debugger, or disable the script debugger option on the general tab of the plug-in's properties page and try again.</summary>
		public const uint NS_E_SCRIPT_DEBUGGER_NOT_INSTALLED = 0xC00D1582;

		/// <summary>The plug-in cannot be loaded because it requires Windows Server 2003, Enterprise Edition.</summary>
		public const uint NS_E_FEATURE_REQUIRES_ENTERPRISE_SERVER = 0xC00D1583;

		/// <summary>Another wizard is currently running. Please close the other wizard or wait until it finishes before attempting to run this wizard again.</summary>
		public const uint NS_E_WIZARD_RUNNING = 0xC00D1584;

		/// <summary>Invalid log URL. Multicast logging URL must look like "http://servername/isapibackend.dll".</summary>
		public const uint NS_E_INVALID_LOG_URL = 0xC00D1585;

		/// <summary>Invalid MTU specified. The valid range for maximum packet size is between 36 and 65507 bytes.</summary>
		public const uint NS_E_INVALID_MTU_RANGE = 0xC00D1586;

		/// <summary>Invalid play statistics for logging.</summary>
		public const uint NS_E_INVALID_PLAY_STATISTICS = 0xC00D1587;

		/// <summary>The log needs to be skipped.</summary>
		public const uint NS_E_LOG_NEED_TO_BE_SKIPPED = 0xC00D1588;

		/// <summary>The size of the data exceeded the limit the WMS HTTP Download Data Source plugin can handle.</summary>
		public const uint NS_E_HTTP_TEXT_DATACONTAINER_SIZE_LIMIT_EXCEEDED = 0xC00D1589;

		/// <summary>One usage of each socket address (protocol/network address/port) is permitted. Verify that other services or applications are not attempting to use the same port and then try to enable the plug-in again.</summary>
		public const uint NS_E_PORT_IN_USE = 0xC00D158A;

		/// <summary>One usage of each socket address (protocol/network address/port) is permitted. Verify that other services (such as IIS) or applications are not attempting to use the same port and then try to enable the plug-in again.</summary>
		public const uint NS_E_PORT_IN_USE_HTTP = 0xC00D158B;

		/// <summary>The WMS HTTP Download Data Source plugin was unable to receive the remote server's response.</summary>
		public const uint NS_E_HTTP_TEXT_DATACONTAINER_INVALID_SERVER_RESPONSE = 0xC00D158C;

		/// <summary>The archive plug-in has reached its quota.</summary>
		public const uint NS_E_ARCHIVE_REACH_QUOTA = 0xC00D158D;

		/// <summary>The archive plug-in aborted because the source was from broadcast.</summary>
		public const uint NS_E_ARCHIVE_ABORT_DUE_TO_BCAST = 0xC00D158E;

		/// <summary>The archive plug-in detected an interrupt in the source.</summary>
		public const uint NS_E_ARCHIVE_GAP_DETECTED = 0xC00D158F;

		/// <summary>The system cannot find the file specified.</summary>
		public const uint NS_E_AUTHORIZATION_FILE_NOT_FOUND = 0xC00D1590;

		/// <summary>The mark-in time should be greater than 0 and less than the mark-out time.</summary>
		public const uint NS_E_BAD_MARKIN = 0xC00D1B58;

		/// <summary>The mark-out time should be greater than the mark-in time and less than the file duration.</summary>
		public const uint NS_E_BAD_MARKOUT = 0xC00D1B59;

		/// <summary>No matching media type is found in the source %1.</summary>
		public const uint NS_E_NOMATCHING_MEDIASOURCE = 0xC00D1B5A;

		/// <summary>The specified source type is not supported.</summary>
		public const uint NS_E_UNSUPPORTED_SOURCETYPE = 0xC00D1B5B;

		/// <summary>It is not possible to specify more than one audio input.</summary>
		public const uint NS_E_TOO_MANY_AUDIO = 0xC00D1B5C;

		/// <summary>It is not possible to specify more than two video inputs.</summary>
		public const uint NS_E_TOO_MANY_VIDEO = 0xC00D1B5D;

		/// <summary>No matching element is found in the list.</summary>
		public const uint NS_E_NOMATCHING_ELEMENT = 0xC00D1B5E;

		/// <summary>The profile's media types must match the media types defined for the session.</summary>
		public const uint NS_E_MISMATCHED_MEDIACONTENT = 0xC00D1B5F;

		/// <summary>It is not possible to remove an active source while encoding.</summary>
		public const uint NS_E_CANNOT_DELETE_ACTIVE_SOURCEGROUP = 0xC00D1B60;

		/// <summary>It is not possible to open the specified audio capture device because it is currently in use.</summary>
		public const uint NS_E_AUDIODEVICE_BUSY = 0xC00D1B61;

		/// <summary>It is not possible to open the specified audio capture device because an unexpected error has occurred.</summary>
		public const uint NS_E_AUDIODEVICE_UNEXPECTED = 0xC00D1B62;

		/// <summary>The audio capture device does not support the specified audio format.</summary>
		public const uint NS_E_AUDIODEVICE_BADFORMAT = 0xC00D1B63;

		/// <summary>It is not possible to open the specified video capture device because it is currently in use.</summary>
		public const uint NS_E_VIDEODEVICE_BUSY = 0xC00D1B64;

		/// <summary>It is not possible to open the specified video capture device because an unexpected error has occurred.</summary>
		public const uint NS_E_VIDEODEVICE_UNEXPECTED = 0xC00D1B65;

		/// <summary>This operation is not allowed while encoding.</summary>
		public const uint NS_E_INVALIDCALL_WHILE_ENCODER_RUNNING = 0xC00D1B66;

		/// <summary>No profile is set for the source.</summary>
		public const uint NS_E_NO_PROFILE_IN_SOURCEGROUP = 0xC00D1B67;

		/// <summary>The video capture driver returned an unrecoverable error. It is now in an unstable state.</summary>
		public const uint NS_E_VIDEODRIVER_UNSTABLE = 0xC00D1B68;

		/// <summary>It was not possible to start the video device.</summary>
		public const uint NS_E_VIDCAPSTARTFAILED = 0xC00D1B69;

		/// <summary>The video source does not support the requested output format or color depth.</summary>
		public const uint NS_E_VIDSOURCECOMPRESSION = 0xC00D1B6A;

		/// <summary>The video source does not support the requested capture size.</summary>
		public const uint NS_E_VIDSOURCESIZE = 0xC00D1B6B;

		/// <summary>It was not possible to obtain output information from the video compressor.</summary>
		public const uint NS_E_ICMQUERYFORMAT = 0xC00D1B6C;

		/// <summary>It was not possible to create a video capture window.</summary>
		public const uint NS_E_VIDCAPCREATEWINDOW = 0xC00D1B6D;

		/// <summary>There is already a stream active on this video device.</summary>
		public const uint NS_E_VIDCAPDRVINUSE = 0xC00D1B6E;

		/// <summary>No media format is set in source.</summary>
		public const uint NS_E_NO_MEDIAFORMAT_IN_SOURCE = 0xC00D1B6F;

		/// <summary>Cannot find a valid output stream from the source.</summary>
		public const uint NS_E_NO_VALID_OUTPUT_STREAM = 0xC00D1B70;

		/// <summary>It was not possible to find a valid source plug-in for the specified source.</summary>
		public const uint NS_E_NO_VALID_SOURCE_PLUGIN = 0xC00D1B71;

		/// <summary>No source is currently active.</summary>
		public const uint NS_E_NO_ACTIVE_SOURCEGROUP = 0xC00D1B72;

		/// <summary>No script stream is set in the current source.</summary>
		public const uint NS_E_NO_SCRIPT_STREAM = 0xC00D1B73;

		/// <summary>This operation is not allowed while archiving.</summary>
		public const uint NS_E_INVALIDCALL_WHILE_ARCHIVAL_RUNNING = 0xC00D1B74;

		/// <summary>The setting for the maximum packet size is not valid.</summary>
		public const uint NS_E_INVALIDPACKETSIZE = 0xC00D1B75;

		/// <summary>The plug-in CLSID specified is not valid.</summary>
		public const uint NS_E_PLUGIN_CLSID_INVALID = 0xC00D1B76;

		/// <summary>This archive type is not supported.</summary>
		public const uint NS_E_UNSUPPORTED_ARCHIVETYPE = 0xC00D1B77;

		/// <summary>This archive operation is not supported.</summary>
		public const uint NS_E_UNSUPPORTED_ARCHIVEOPERATION = 0xC00D1B78;

		/// <summary>The local archive file name was not set.</summary>
		public const uint NS_E_ARCHIVE_FILENAME_NOTSET = 0xC00D1B79;

		/// <summary>The source is not yet prepared.</summary>
		public const uint NS_E_SOURCEGROUP_NOTPREPARED = 0xC00D1B7A;

		/// <summary>Profiles on the sources do not match.</summary>
		public const uint NS_E_PROFILE_MISMATCH = 0xC00D1B7B;

		/// <summary>The specified crop values are not valid.</summary>
		public const uint NS_E_INCORRECTCLIPSETTINGS = 0xC00D1B7C;

		/// <summary>No statistics are available at this time.</summary>
		public const uint NS_E_NOSTATSAVAILABLE = 0xC00D1B7D;

		/// <summary>The encoder is not archiving.</summary>
		public const uint NS_E_NOTARCHIVING = 0xC00D1B7E;

		/// <summary>This operation is only allowed during encoding.</summary>
		public const uint NS_E_INVALIDCALL_WHILE_ENCODER_STOPPED = 0xC00D1B7F;

		/// <summary>This SourceGroupCollection doesn't contain any SourceGroups.</summary>
		public const uint NS_E_NOSOURCEGROUPS = 0xC00D1B80;

		/// <summary>This source does not have a frame rate of 30 fps. Therefore, it is not possible to apply the inverse telecine filter to the source.</summary>
		public const uint NS_E_INVALIDINPUTFPS = 0xC00D1B81;

		/// <summary>It is not possible to display your source or output video in the Video panel.</summary>
		public const uint NS_E_NO_DATAVIEW_SUPPORT = 0xC00D1B82;

		/// <summary>One or more codecs required to open this content could not be found.</summary>
		public const uint NS_E_CODEC_UNAVAILABLE = 0xC00D1B83;

		/// <summary>The archive file has the same name as an input file. Change one of the names before continuing.</summary>
		public const uint NS_E_ARCHIVE_SAME_AS_INPUT = 0xC00D1B84;

		/// <summary>The source has not been set up completely.</summary>
		public const uint NS_E_SOURCE_NOTSPECIFIED = 0xC00D1B85;

		/// <summary>It is not possible to apply time compression to a broadcast session.</summary>
		public const uint NS_E_NO_REALTIME_TIMECOMPRESSION = 0xC00D1B86;

		/// <summary>It is not possible to open this device.</summary>
		public const uint NS_E_UNSUPPORTED_ENCODER_DEVICE = 0xC00D1B87;

		/// <summary>It is not possible to start encoding because the display size or color has changed since the current session was defined. Restore the previous settings or create a new session.</summary>
		public const uint NS_E_UNEXPECTED_DISPLAY_SETTINGS = 0xC00D1B88;

		/// <summary>No audio data has been received for several seconds. Check the audio source and restart the encoder.</summary>
		public const uint NS_E_NO_AUDIODATA = 0xC00D1B89;

		/// <summary>One or all of the specified sources are not working properly. Check that the sources are configured correctly.</summary>
		public const uint NS_E_INPUTSOURCE_PROBLEM = 0xC00D1B8A;

		/// <summary>The supplied configuration file is not supported by this version of the encoder.</summary>
		public const uint NS_E_WME_VERSION_MISMATCH = 0xC00D1B8B;

		/// <summary>It is not possible to use image preprocessing with live encoding.</summary>
		public const uint NS_E_NO_REALTIME_PREPROCESS = 0xC00D1B8C;

		/// <summary>It is not possible to use two-pass encoding when the source is set to loop.</summary>
		public const uint NS_E_NO_REPEAT_PREPROCESS = 0xC00D1B8D;

		/// <summary>It is not possible to pause encoding during a broadcast.</summary>
		public const uint NS_E_CANNOT_PAUSE_LIVEBROADCAST = 0xC00D1B8E;

		/// <summary>A DRM profile has not been set for the current session.</summary>
		public const uint NS_E_DRM_PROFILE_NOT_SET = 0xC00D1B8F;

		/// <summary>The profile ID is already used by a DRM profile. Specify a different profile ID.</summary>
		public const uint NS_E_DUPLICATE_DRMPROFILE = 0xC00D1B90;

		/// <summary>The setting of the selected device does not support control for playing back tapes.</summary>
		public const uint NS_E_INVALID_DEVICE = 0xC00D1B91;

		/// <summary>You must specify a mixed voice and audio mode in order to use an optimization definition file.</summary>
		public const uint NS_E_SPEECHEDL_ON_NON_MIXEDMODE = 0xC00D1B92;

		/// <summary>The specified password is too long. Type a password with fewer than 8 characters.</summary>
		public const uint NS_E_DRM_PASSWORD_TOO_LONG = 0xC00D1B93;

		/// <summary>It is not possible to seek to the specified mark-in point.</summary>
		public const uint NS_E_DEVCONTROL_FAILED_SEEK = 0xC00D1B94;

		/// <summary>When you choose to maintain the interlacing in your video, the output video size must match the input video size.</summary>
		public const uint NS_E_INTERLACE_REQUIRE_SAMESIZE = 0xC00D1B95;

		/// <summary>Only one device control plug-in can control a device.</summary>
		public const uint NS_E_TOO_MANY_DEVICECONTROL = 0xC00D1B96;

		/// <summary>You must also enable storing content to hard disk temporarily in order to use two-pass encoding with the input device.</summary>
		public const uint NS_E_NO_MULTIPASS_FOR_LIVEDEVICE = 0xC00D1B97;

		/// <summary>An audience is missing from the output stream configuration.</summary>
		public const uint NS_E_MISSING_AUDIENCE = 0xC00D1B98;

		/// <summary>All audiences in the output tree must have the same content type.</summary>
		public const uint NS_E_AUDIENCE_CONTENTTYPE_MISMATCH = 0xC00D1B99;

		/// <summary>A source index is missing from the output stream configuration.</summary>
		public const uint NS_E_MISSING_SOURCE_INDEX = 0xC00D1B9A;

		/// <summary>The same source index in different audiences should have the same number of languages.</summary>
		public const uint NS_E_NUM_LANGUAGE_MISMATCH = 0xC00D1B9B;

		/// <summary>The same source index in different audiences should have the same languages.</summary>
		public const uint NS_E_LANGUAGE_MISMATCH = 0xC00D1B9C;

		/// <summary>The same source index in different audiences should use the same VBR encoding mode.</summary>
		public const uint NS_E_VBRMODE_MISMATCH = 0xC00D1B9D;

		/// <summary>The bit rate index specified is not valid.</summary>
		public const uint NS_E_INVALID_INPUT_AUDIENCE_INDEX = 0xC00D1B9E;

		/// <summary>The specified language is not valid.</summary>
		public const uint NS_E_INVALID_INPUT_LANGUAGE = 0xC00D1B9F;

		/// <summary>The specified source type is not valid.</summary>
		public const uint NS_E_INVALID_INPUT_STREAM = 0xC00D1BA0;

		/// <summary>The source must be a mono channel .wav file.</summary>
		public const uint NS_E_EXPECT_MONO_WAV_INPUT = 0xC00D1BA1;

		/// <summary>All the source .wav files must have the same format.</summary>
		public const uint NS_E_INPUT_WAVFORMAT_MISMATCH = 0xC00D1BA2;

		/// <summary>The hard disk being used for temporary storage of content has reached the minimum allowed disk space. Create more space on the hard disk and restart encoding.</summary>
		public const uint NS_E_RECORDQ_DISK_FULL = 0xC00D1BA3;

		/// <summary>It is not possible to apply the inverse telecine feature to PAL content.</summary>
		public const uint NS_E_NO_PAL_INVERSE_TELECINE = 0xC00D1BA4;

		/// <summary>A capture device in the current active source is no longer available.</summary>
		public const uint NS_E_ACTIVE_SG_DEVICE_DISCONNECTED = 0xC00D1BA5;

		/// <summary>A device used in the current active source for device control is no longer available.</summary>
		public const uint NS_E_ACTIVE_SG_DEVICE_CONTROL_DISCONNECTED = 0xC00D1BA6;

		/// <summary>No frames have been submitted to the analyzer for analysis.</summary>
		public const uint NS_E_NO_FRAMES_SUBMITTED_TO_ANALYZER = 0xC00D1BA7;

		/// <summary>The source video does not support time codes.</summary>
		public const uint NS_E_INPUT_DOESNOT_SUPPORT_SMPTE = 0xC00D1BA8;

		/// <summary>It is not possible to generate a time code when there are multiple sources in a session.</summary>
		public const uint NS_E_NO_SMPTE_WITH_MULTIPLE_SOURCEGROUPS = 0xC00D1BA9;

		/// <summary>The voice codec optimization definition file cannot be found or is corrupted.</summary>
		public const uint NS_E_BAD_CONTENTEDL = 0xC00D1BAA;

		/// <summary>The same source index in different audiences should have the same interlace mode.</summary>
		public const uint NS_E_INTERLACEMODE_MISMATCH = 0xC00D1BAB;

		/// <summary>The same source index in different audiences should have the same nonsquare pixel mode.</summary>
		public const uint NS_E_NONSQUAREPIXELMODE_MISMATCH = 0xC00D1BAC;

		/// <summary>The same source index in different audiences should have the same time code mode.</summary>
		public const uint NS_E_SMPTEMODE_MISMATCH = 0xC00D1BAD;

		/// <summary>Either the end of the tape has been reached or there is no tape. Check the device and tape.</summary>
		public const uint NS_E_END_OF_TAPE = 0xC00D1BAE;

		/// <summary>No audio or video input has been specified.</summary>
		public const uint NS_E_NO_MEDIA_IN_AUDIENCE = 0xC00D1BAF;

		/// <summary>The profile must contain a bit rate.</summary>
		public const uint NS_E_NO_AUDIENCES = 0xC00D1BB0;

		/// <summary>You must specify at least one audio stream to be compatible with Windows Media Player 7.1.</summary>
		public const uint NS_E_NO_AUDIO_COMPAT = 0xC00D1BB1;

		/// <summary>Using a VBR encoding mode is not compatible with Windows Media Player 7.1.</summary>
		public const uint NS_E_INVALID_VBR_COMPAT = 0xC00D1BB2;

		/// <summary>You must specify a profile name.</summary>
		public const uint NS_E_NO_PROFILE_NAME = 0xC00D1BB3;

		/// <summary>It is not possible to use a VBR encoding mode with uncompressed audio or video.</summary>
		public const uint NS_E_INVALID_VBR_WITH_UNCOMP = 0xC00D1BB4;

		/// <summary>It is not possible to use MBR encoding with VBR encoding.</summary>
		public const uint NS_E_MULTIPLE_VBR_AUDIENCES = 0xC00D1BB5;

		/// <summary>It is not possible to mix uncompressed and compressed content in a session.</summary>
		public const uint NS_E_UNCOMP_COMP_COMBINATION = 0xC00D1BB6;

		/// <summary>All audiences must use the same audio codec.</summary>
		public const uint NS_E_MULTIPLE_AUDIO_CODECS = 0xC00D1BB7;

		/// <summary>All audiences should use the same audio format to be compatible with Windows Media Player 7.1.</summary>
		public const uint NS_E_MULTIPLE_AUDIO_FORMATS = 0xC00D1BB8;

		/// <summary>The audio bit rate for an audience with a higher total bit rate must be greater than one with a lower total bit rate.</summary>
		public const uint NS_E_AUDIO_BITRATE_STEPDOWN = 0xC00D1BB9;

		/// <summary>The audio peak bit rate setting is not valid.</summary>
		public const uint NS_E_INVALID_AUDIO_PEAKRATE = 0xC00D1BBA;

		/// <summary>The audio peak bit rate setting must be greater than the audio bit rate setting.</summary>
		public const uint NS_E_INVALID_AUDIO_PEAKRATE_2 = 0xC00D1BBB;

		/// <summary>The setting for the maximum buffer size for audio is not valid.</summary>
		public const uint NS_E_INVALID_AUDIO_BUFFERMAX = 0xC00D1BBC;

		/// <summary>All audiences must use the same video codec.</summary>
		public const uint NS_E_MULTIPLE_VIDEO_CODECS = 0xC00D1BBD;

		/// <summary>All audiences should use the same video size to be compatible with Windows Media Player 7.1.</summary>
		public const uint NS_E_MULTIPLE_VIDEO_SIZES = 0xC00D1BBE;

		/// <summary>The video bit rate setting is not valid.</summary>
		public const uint NS_E_INVALID_VIDEO_BITRATE = 0xC00D1BBF;

		/// <summary>The video bit rate for an audience with a higher total bit rate must be greater than one with a lower total bit rate.</summary>
		public const uint NS_E_VIDEO_BITRATE_STEPDOWN = 0xC00D1BC0;

		/// <summary>The video peak bit rate setting is not valid.</summary>
		public const uint NS_E_INVALID_VIDEO_PEAKRATE = 0xC00D1BC1;

		/// <summary>The video peak bit rate setting must be greater than the video bit rate setting.</summary>
		public const uint NS_E_INVALID_VIDEO_PEAKRATE_2 = 0xC00D1BC2;

		/// <summary>The video width setting is not valid.</summary>
		public const uint NS_E_INVALID_VIDEO_WIDTH = 0xC00D1BC3;

		/// <summary>The video height setting is not valid.</summary>
		public const uint NS_E_INVALID_VIDEO_HEIGHT = 0xC00D1BC4;

		/// <summary>The video frame rate setting is not valid.</summary>
		public const uint NS_E_INVALID_VIDEO_FPS = 0xC00D1BC5;

		/// <summary>The video key frame setting is not valid.</summary>
		public const uint NS_E_INVALID_VIDEO_KEYFRAME = 0xC00D1BC6;

		/// <summary>The video image quality setting is not valid.</summary>
		public const uint NS_E_INVALID_VIDEO_IQUALITY = 0xC00D1BC7;

		/// <summary>The video codec quality setting is not valid.</summary>
		public const uint NS_E_INVALID_VIDEO_CQUALITY = 0xC00D1BC8;

		/// <summary>The video buffer setting is not valid.</summary>
		public const uint NS_E_INVALID_VIDEO_BUFFER = 0xC00D1BC9;

		/// <summary>The setting for the maximum buffer size for video is not valid.</summary>
		public const uint NS_E_INVALID_VIDEO_BUFFERMAX = 0xC00D1BCA;

		/// <summary>The value of the video maximum buffer size setting must be greater than the video buffer size setting.</summary>
		public const uint NS_E_INVALID_VIDEO_BUFFERMAX_2 = 0xC00D1BCB;

		/// <summary>The alignment of the video width is not valid.</summary>
		public const uint NS_E_INVALID_VIDEO_WIDTH_ALIGN = 0xC00D1BCC;

		/// <summary>The alignment of the video height is not valid.</summary>
		public const uint NS_E_INVALID_VIDEO_HEIGHT_ALIGN = 0xC00D1BCD;

		/// <summary>All bit rates must have the same script bit rate.</summary>
		public const uint NS_E_MULTIPLE_SCRIPT_BITRATES = 0xC00D1BCE;

		/// <summary>The script bit rate specified is not valid.</summary>
		public const uint NS_E_INVALID_SCRIPT_BITRATE = 0xC00D1BCF;

		/// <summary>All bit rates must have the same file transfer bit rate.</summary>
		public const uint NS_E_MULTIPLE_FILE_BITRATES = 0xC00D1BD0;

		/// <summary>The file transfer bit rate is not valid.</summary>
		public const uint NS_E_INVALID_FILE_BITRATE = 0xC00D1BD1;

		/// <summary>All audiences in a profile should either be same as input or have video width and height specified.</summary>
		public const uint NS_E_SAME_AS_INPUT_COMBINATION = 0xC00D1BD2;

		/// <summary>This source type does not support looping.</summary>
		public const uint NS_E_SOURCE_CANNOT_LOOP = 0xC00D1BD3;

		/// <summary>The fold-down value needs to be between -144 and 0.</summary>
		public const uint NS_E_INVALID_FOLDDOWN_COEFFICIENTS = 0xC00D1BD4;

		/// <summary>The specified DRM profile does not exist in the system.</summary>
		public const uint NS_E_DRMPROFILE_NOTFOUND = 0xC00D1BD5;

		/// <summary>The specified time code is not valid.</summary>
		public const uint NS_E_INVALID_TIMECODE = 0xC00D1BD6;

		/// <summary>It is not possible to apply time compression to a video-only session.</summary>
		public const uint NS_E_NO_AUDIO_TIMECOMPRESSION = 0xC00D1BD7;

		/// <summary>It is not possible to apply time compression to a session that is using two-pass encoding.</summary>
		public const uint NS_E_NO_TWOPASS_TIMECOMPRESSION = 0xC00D1BD8;

		/// <summary>It is not possible to generate a time code for an audio-only session.</summary>
		public const uint NS_E_TIMECODE_REQUIRES_VIDEOSTREAM = 0xC00D1BD9;

		/// <summary>It is not possible to generate a time code when you are encoding content at multiple bit rates.</summary>
		public const uint NS_E_NO_MBR_WITH_TIMECODE = 0xC00D1BDA;

		/// <summary>The video codec selected does not support maintaining interlacing in video.</summary>
		public const uint NS_E_INVALID_INTERLACEMODE = 0xC00D1BDB;

		/// <summary>Maintaining interlacing in video is not compatible with Windows Media Player 7.1.</summary>
		public const uint NS_E_INVALID_INTERLACE_COMPAT = 0xC00D1BDC;

		/// <summary>Allowing nonsquare pixel output is not compatible with Windows Media Player 7.1.</summary>
		public const uint NS_E_INVALID_NONSQUAREPIXEL_COMPAT = 0xC00D1BDD;

		/// <summary>Only capture devices can be used with device control.</summary>
		public const uint NS_E_INVALID_SOURCE_WITH_DEVICE_CONTROL = 0xC00D1BDE;

		/// <summary>It is not possible to generate the stream format file if you are using quality-based VBR encoding for the audio or video stream. Instead use the Windows Media file generated after encoding to create the announcement file.</summary>
		public const uint NS_E_CANNOT_GENERATE_BROADCAST_INFO_FOR_QUALITYVBR = 0xC00D1BDF;

		/// <summary>It is not possible to create a DRM profile because the maximum number of profiles has been reached. You must delete some DRM profiles before creating new ones.</summary>
		public const uint NS_E_EXCEED_MAX_DRM_PROFILE_LIMIT = 0xC00D1BE0;

		/// <summary>The device is in an unstable state. Check that the device is functioning properly and a tape is in place.</summary>
		public const uint NS_E_DEVICECONTROL_UNSTABLE = 0xC00D1BE1;

		/// <summary>The pixel aspect ratio value must be between 1 and 255.</summary>
		public const uint NS_E_INVALID_PIXEL_ASPECT_RATIO = 0xC00D1BE2;

		/// <summary>All streams with different languages in the same audience must have same properties.</summary>
		public const uint NS_E_AUDIENCE__LANGUAGE_CONTENTTYPE_MISMATCH = 0xC00D1BE3;

		/// <summary>The profile must contain at least one audio or video stream.</summary>
		public const uint NS_E_INVALID_PROFILE_CONTENTTYPE = 0xC00D1BE4;

		/// <summary>The transform plug-in could not be found.</summary>
		public const uint NS_E_TRANSFORM_PLUGIN_NOT_FOUND = 0xC00D1BE5;

		/// <summary>The transform plug-in is not valid. It might be damaged or you might not have the required permissions to access the plug-in.</summary>
		public const uint NS_E_TRANSFORM_PLUGIN_INVALID = 0xC00D1BE6;

		/// <summary>To use two-pass encoding, you must enable device control and setup an edit decision list (EDL) that has at least one entry.</summary>
		public const uint NS_E_EDL_REQUIRED_FOR_DEVICE_MULTIPASS = 0xC00D1BE7;

		/// <summary>When you choose to maintain the interlacing in your video, the output video size must be a multiple of 4.</summary>
		public const uint NS_E_INVALID_VIDEO_WIDTH_FOR_INTERLACED_ENCODING = 0xC00D1BE8;

		/// <summary>Markin/Markout is unsupported with this source type.</summary>
		public const uint NS_E_MARKIN_UNSUPPORTED = 0xC00D1BE9;

		/// <summary>A problem has occurred in the Digital Rights Management component. Contact product support for this application.</summary>
		public const uint NS_E_DRM_INVALID_APPLICATION = 0xC00D2711;

		/// <summary>License storage is not working. Contact Microsoft product support.</summary>
		public const uint NS_E_DRM_LICENSE_STORE_ERROR = 0xC00D2712;

		/// <summary>Secure storage is not working. Contact Microsoft product support.</summary>
		public const uint NS_E_DRM_SECURE_STORE_ERROR = 0xC00D2713;

		/// <summary>License acquisition did not work. Acquire a new license or contact the content provider for further assistance.</summary>
		public const uint NS_E_DRM_LICENSE_STORE_SAVE_ERROR = 0xC00D2714;

		/// <summary>A problem has occurred in the Digital Rights Management component. Contact Microsoft product support.</summary>
		public const uint NS_E_DRM_SECURE_STORE_UNLOCK_ERROR = 0xC00D2715;

		/// <summary>The media file is corrupted. Contact the content provider to get a new file.</summary>
		public const uint NS_E_DRM_INVALID_CONTENT = 0xC00D2716;

		/// <summary>The license is corrupted. Acquire a new license.</summary>
		public const uint NS_E_DRM_UNABLE_TO_OPEN_LICENSE = 0xC00D2717;

		/// <summary>The license is corrupted or invalid. Acquire a new license</summary>
		public const uint NS_E_DRM_INVALID_LICENSE = 0xC00D2718;

		/// <summary>Licenses cannot be copied from one computer to another. Use License Management to transfer licenses, or get a new license for the media file.</summary>
		public const uint NS_E_DRM_INVALID_MACHINE = 0xC00D2719;

		/// <summary>License storage is not working. Contact Microsoft product support.</summary>
		public const uint NS_E_DRM_ENUM_LICENSE_FAILED = 0xC00D271B;

		/// <summary>The media file is corrupted. Contact the content provider to get a new file.</summary>
		public const uint NS_E_DRM_INVALID_LICENSE_REQUEST = 0xC00D271C;

		/// <summary>A problem has occurred in the Digital Rights Management component. Contact Microsoft product support.</summary>
		public const uint NS_E_DRM_UNABLE_TO_INITIALIZE = 0xC00D271D;

		/// <summary>The license could not be acquired. Try again later.</summary>
		public const uint NS_E_DRM_UNABLE_TO_ACQUIRE_LICENSE = 0xC00D271E;

		/// <summary>License acquisition did not work. Acquire a new license or contact the content provider for further assistance.</summary>
		public const uint NS_E_DRM_INVALID_LICENSE_ACQUIRED = 0xC00D271F;

		/// <summary>The requested operation cannot be performed on this file.</summary>
		public const uint NS_E_DRM_NO_RIGHTS = 0xC00D2720;

		/// <summary>The requested action cannot be performed because a problem occurred with the Windows Media Digital Rights Management (DRM) components on your computer.</summary>
		public const uint NS_E_DRM_KEY_ERROR = 0xC00D2721;

		/// <summary>A problem has occurred in the Digital Rights Management component. Contact Microsoft product support.</summary>
		public const uint NS_E_DRM_ENCRYPT_ERROR = 0xC00D2722;

		/// <summary>The media file is corrupted. Contact the content provider to get a new file.</summary>
		public const uint NS_E_DRM_DECRYPT_ERROR = 0xC00D2723;

		/// <summary>The license is corrupted. Acquire a new license.</summary>
		public const uint NS_E_DRM_LICENSE_INVALID_XML = 0xC00D2725;

		/// <summary>A security upgrade is required to perform the operation on this media file.</summary>
		public const uint NS_E_DRM_NEEDS_INDIVIDUALIZATION = 0xC00D2728;

		/// <summary>You already have the latest security components. No upgrade is necessary at this time.</summary>
		public const uint NS_E_DRM_ALREADY_INDIVIDUALIZED = 0xC00D2729;

		/// <summary>The application cannot perform this action. Contact product support for this application.</summary>
		public const uint NS_E_DRM_ACTION_NOT_QUERIED = 0xC00D272A;

		/// <summary>You cannot begin a new license acquisition process until the current one has been completed.</summary>
		public const uint NS_E_DRM_ACQUIRING_LICENSE = 0xC00D272B;

		/// <summary>You cannot begin a new security upgrade until the current one has been completed.</summary>
		public const uint NS_E_DRM_INDIVIDUALIZING = 0xC00D272C;

		/// <summary>Failure in Backup-Restore.</summary>
		public const uint NS_E_BACKUP_RESTORE_FAILURE = 0xC00D272D;

		/// <summary>Bad Request ID in Backup-Restore.</summary>
		public const uint NS_E_BACKUP_RESTORE_BAD_REQUEST_ID = 0xC00D272E;

		/// <summary>A problem has occurred in the Digital Rights Management component. Contact Microsoft product support.</summary>
		public const uint NS_E_DRM_PARAMETERS_MISMATCHED = 0xC00D272F;

		/// <summary>A license cannot be created for this media file. Reinstall the application.</summary>
		public const uint NS_E_DRM_UNABLE_TO_CREATE_LICENSE_OBJECT = 0xC00D2730;

		/// <summary>A problem has occurred in the Digital Rights Management component. Contact Microsoft product support.</summary>
		public const uint NS_E_DRM_UNABLE_TO_CREATE_INDI_OBJECT = 0xC00D2731;

		/// <summary>A problem has occurred in the Digital Rights Management component. Contact Microsoft product support.</summary>
		public const uint NS_E_DRM_UNABLE_TO_CREATE_ENCRYPT_OBJECT = 0xC00D2732;

		/// <summary>A problem has occurred in the Digital Rights Management component. Contact Microsoft product support.</summary>
		public const uint NS_E_DRM_UNABLE_TO_CREATE_DECRYPT_OBJECT = 0xC00D2733;

		/// <summary>A problem has occurred in the Digital Rights Management component. Contact Microsoft product support.</summary>
		public const uint NS_E_DRM_UNABLE_TO_CREATE_PROPERTIES_OBJECT = 0xC00D2734;

		/// <summary>A problem has occurred in the Digital Rights Management component. Contact Microsoft product support.</summary>
		public const uint NS_E_DRM_UNABLE_TO_CREATE_BACKUP_OBJECT = 0xC00D2735;

		/// <summary>The security upgrade failed. Try again later.</summary>
		public const uint NS_E_DRM_INDIVIDUALIZE_ERROR = 0xC00D2736;

		/// <summary>License storage is not working. Contact Microsoft product support.</summary>
		public const uint NS_E_DRM_LICENSE_OPEN_ERROR = 0xC00D2737;

		/// <summary>License storage is not working. Contact Microsoft product support.</summary>
		public const uint NS_E_DRM_LICENSE_CLOSE_ERROR = 0xC00D2738;

		/// <summary>License storage is not working. Contact Microsoft product support.</summary>
		public const uint NS_E_DRM_GET_LICENSE_ERROR = 0xC00D2739;

		/// <summary>A problem has occurred in the Digital Rights Management component. Contact Microsoft product support.</summary>
		public const uint NS_E_DRM_QUERY_ERROR = 0xC00D273A;

		/// <summary>A problem has occurred in the Digital Rights Management component. Contact product support for this application.</summary>
		public const uint NS_E_DRM_REPORT_ERROR = 0xC00D273B;

		/// <summary>License storage is not working. Contact Microsoft product support.</summary>
		public const uint NS_E_DRM_GET_LICENSESTRING_ERROR = 0xC00D273C;

		/// <summary>The media file is corrupted. Contact the content provider to get a new file.</summary>
		public const uint NS_E_DRM_GET_CONTENTSTRING_ERROR = 0xC00D273D;

		/// <summary>A problem has occurred in the Digital Rights Management component. Try again later.</summary>
		public const uint NS_E_DRM_MONITOR_ERROR = 0xC00D273E;

		/// <summary>The application has made an invalid call to the Digital Rights Management component. Contact product support for this application.</summary>
		public const uint NS_E_DRM_UNABLE_TO_SET_PARAMETER = 0xC00D273F;

		/// <summary>A problem has occurred in the Digital Rights Management component. Contact Microsoft product support.</summary>
		public const uint NS_E_DRM_INVALID_APPDATA = 0xC00D2740;

		/// <summary>A problem has occurred in the Digital Rights Management component. Contact product support for this application.</summary>
		public const uint NS_E_DRM_INVALID_APPDATA_VERSION = 0xC00D2741;

		/// <summary>Licenses are already backed up in this location.</summary>
		public const uint NS_E_DRM_BACKUP_EXISTS = 0xC00D2742;

		/// <summary>One or more backed-up licenses are missing or corrupt.</summary>
		public const uint NS_E_DRM_BACKUP_CORRUPT = 0xC00D2743;

		/// <summary>You cannot begin a new backup process until the current process has been completed.</summary>
		public const uint NS_E_DRM_BACKUPRESTORE_BUSY = 0xC00D2744;

		/// <summary>Bad Data sent to Backup-Restore.</summary>
		public const uint NS_E_BACKUP_RESTORE_BAD_DATA = 0xC00D2745;

		/// <summary>The license is invalid. Contact the content provider for further assistance.</summary>
		public const uint NS_E_DRM_LICENSE_UNUSABLE = 0xC00D2748;

		/// <summary>A required property was not set by the application. Contact product support for this application.</summary>
		public const uint NS_E_DRM_INVALID_PROPERTY = 0xC00D2749;

		/// <summary>A problem has occurred in the Digital Rights Management component of this application. Try to acquire a license again.</summary>
		public const uint NS_E_DRM_SECURE_STORE_NOT_FOUND = 0xC00D274A;

		/// <summary>A license cannot be found for this media file. Use License Management to transfer a license for this file from the original computer, or acquire a new license.</summary>
		public const uint NS_E_DRM_CACHED_CONTENT_ERROR = 0xC00D274B;

		/// <summary>A problem occurred during the security upgrade. Try again later.</summary>
		public const uint NS_E_DRM_INDIVIDUALIZATION_INCOMPLETE = 0xC00D274C;

		/// <summary>Certified driver components are required to play this media file. Contact Windows Update to see whether updated drivers are available for your hardware.</summary>
		public const uint NS_E_DRM_DRIVER_AUTH_FAILURE = 0xC00D274D;

		/// <summary>One or more of the Secure Audio Path components were not found or an entry point in those components was not found.</summary>
		public const uint NS_E_DRM_NEED_UPGRADE_MSSAP = 0xC00D274E;

		/// <summary>Status message: Reopen the file.</summary>
		public const uint NS_E_DRM_REOPEN_CONTENT = 0xC00D274F;

		/// <summary>Certain driver functionality is required to play this media file. Contact Windows Update to see whether updated drivers are available for your hardware.</summary>
		public const uint NS_E_DRM_DRIVER_DIGIOUT_FAILURE = 0xC00D2750;

		/// <summary>A problem has occurred in the Digital Rights Management component. Contact Microsoft product support.</summary>
		public const uint NS_E_DRM_INVALID_SECURESTORE_PASSWORD = 0xC00D2751;

		/// <summary>A problem has occurred in the Digital Rights Management component. Contact Microsoft product support.</summary>
		public const uint NS_E_DRM_APPCERT_REVOKED = 0xC00D2752;

		/// <summary>You cannot restore your license(s).</summary>
		public const uint NS_E_DRM_RESTORE_FRAUD = 0xC00D2753;

		/// <summary>The licenses for your media files are corrupted. Contact Microsoft product support.</summary>
		public const uint NS_E_DRM_HARDWARE_INCONSISTENT = 0xC00D2754;

		/// <summary>To transfer this media file, you must upgrade the application.</summary>
		public const uint NS_E_DRM_SDMI_TRIGGER = 0xC00D2755;

		/// <summary>You cannot make any more copies of this media file.</summary>
		public const uint NS_E_DRM_SDMI_NOMORECOPIES = 0xC00D2756;

		/// <summary>A problem has occurred in the Digital Rights Management component. Contact Microsoft product support.</summary>
		public const uint NS_E_DRM_UNABLE_TO_CREATE_HEADER_OBJECT = 0xC00D2757;

		/// <summary>A problem has occurred in the Digital Rights Management component. Contact Microsoft product support.</summary>
		public const uint NS_E_DRM_UNABLE_TO_CREATE_KEYS_OBJECT = 0xC00D2758;

		/// <summary>Unable to obtain license.</summary>
		public const uint NS_E_DRM_LICENSE_NOTACQUIRED = 0xC00D2759;

		/// <summary>A problem has occurred in the Digital Rights Management component. Contact Microsoft product support.</summary>
		public const uint NS_E_DRM_UNABLE_TO_CREATE_CODING_OBJECT = 0xC00D275A;

		/// <summary>A problem has occurred in the Digital Rights Management component. Contact Microsoft product support.</summary>
		public const uint NS_E_DRM_UNABLE_TO_CREATE_STATE_DATA_OBJECT = 0xC00D275B;

		/// <summary>The buffer supplied is not sufficient.</summary>
		public const uint NS_E_DRM_BUFFER_TOO_SMALL = 0xC00D275C;

		/// <summary>The property requested is not supported.</summary>
		public const uint NS_E_DRM_UNSUPPORTED_PROPERTY = 0xC00D275D;

		/// <summary>The specified server cannot perform the requested operation.</summary>
		public const uint NS_E_DRM_ERROR_BAD_NET_RESP = 0xC00D275E;

		/// <summary>Some of the licenses could not be stored.</summary>
		public const uint NS_E_DRM_STORE_NOTALLSTORED = 0xC00D275F;

		/// <summary>The Digital Rights Management security upgrade component could not be validated. Contact Microsoft product support.</summary>
		public const uint NS_E_DRM_SECURITY_COMPONENT_SIGNATURE_INVALID = 0xC00D2760;

		/// <summary>Invalid or corrupt data was encountered.</summary>
		public const uint NS_E_DRM_INVALID_DATA = 0xC00D2761;

		/// <summary>The Windows Media Digital Rights Management system cannot perform the requested action because your computer or network administrator has enabled the group policy Prevent Windows Media DRM Internet Access. For assistance, contact your administrator.</summary>
		public const uint NS_E_DRM_POLICY_DISABLE_ONLINE = 0xC00D2762;

		/// <summary>A problem has occurred in the Digital Rights Management component. Contact Microsoft product support.</summary>
		public const uint NS_E_DRM_UNABLE_TO_CREATE_AUTHENTICATION_OBJECT = 0xC00D2763;

		/// <summary>Not all of the necessary properties for DRM have been set.</summary>
		public const uint NS_E_DRM_NOT_CONFIGURED = 0xC00D2764;

		/// <summary>The portable device does not have the security required to copy protected files to it. To obtain the additional security, try to copy the file to your portable device again. When a message appears, click OK.</summary>
		public const uint NS_E_DRM_DEVICE_ACTIVATION_CANCELED = 0xC00D2765;

		/// <summary>Too many resets in Backup-Restore.</summary>
		public const uint NS_E_BACKUP_RESTORE_TOO_MANY_RESETS = 0xC00D2766;

		/// <summary>Running this process under a debugger while using DRM content is not allowed.</summary>
		public const uint NS_E_DRM_DEBUGGING_NOT_ALLOWED = 0xC00D2767;

		/// <summary>The user canceled the DRM operation.</summary>
		public const uint NS_E_DRM_OPERATION_CANCELED = 0xC00D2768;

		/// <summary>The license you are using has assocaited output restrictions. This license is unusable until these restrictions are queried.</summary>
		public const uint NS_E_DRM_RESTRICTIONS_NOT_RETRIEVED = 0xC00D2769;

		/// <summary>A problem has occurred in the Digital Rights Management component. Contact Microsoft product support.</summary>
		public const uint NS_E_DRM_UNABLE_TO_CREATE_PLAYLIST_OBJECT = 0xC00D276A;

		/// <summary>A problem has occurred in the Digital Rights Management component. Contact Microsoft product support.</summary>
		public const uint NS_E_DRM_UNABLE_TO_CREATE_PLAYLIST_BURN_OBJECT = 0xC00D276B;

		/// <summary>A problem has occurred in the Digital Rights Management component. Contact Microsoft product support.</summary>
		public const uint NS_E_DRM_UNABLE_TO_CREATE_DEVICE_REGISTRATION_OBJECT = 0xC00D276C;

		/// <summary>A problem has occurred in the Digital Rights Management component. Contact Microsoft product support.</summary>
		public const uint NS_E_DRM_UNABLE_TO_CREATE_METERING_OBJECT = 0xC00D276D;

		/// <summary>The specified track has exceeded it's specified playlist burn limit in this playlist.</summary>
		public const uint NS_E_DRM_TRACK_EXCEEDED_PLAYLIST_RESTICTION = 0xC00D2770;

		/// <summary>The specified track has exceeded it's track burn limit.</summary>
		public const uint NS_E_DRM_TRACK_EXCEEDED_TRACKBURN_RESTRICTION = 0xC00D2771;

		/// <summary>A problem has occurred in obtaining the device's certificate. Contact Microsoft product support.</summary>
		public const uint NS_E_DRM_UNABLE_TO_GET_DEVICE_CERT = 0xC00D2772;

		/// <summary>A problem has occurred in obtaining the device's secure clock. Contact Microsoft product support.</summary>
		public const uint NS_E_DRM_UNABLE_TO_GET_SECURE_CLOCK = 0xC00D2773;

		/// <summary>A problem has occurred in setting the device's secure clock. Contact Microsoft product support.</summary>
		public const uint NS_E_DRM_UNABLE_TO_SET_SECURE_CLOCK = 0xC00D2774;

		/// <summary>A problem has occurred in obtaining the secure clock from server. Contact Microsoft product support.</summary>
		public const uint NS_E_DRM_UNABLE_TO_GET_SECURE_CLOCK_FROM_SERVER = 0xC00D2775;

		/// <summary>This content requires the metering policy to be enabled.</summary>
		public const uint NS_E_DRM_POLICY_METERING_DISABLED = 0xC00D2776;

		/// <summary>Transfer of chained licenses unsupported.</summary>
		public const uint NS_E_DRM_TRANSFER_CHAINED_LICENSES_UNSUPPORTED = 0xC00D2777;

		/// <summary>The Digital Rights Management component is not installed properly. Reinstall the Player.</summary>
		public const uint NS_E_DRM_SDK_VERSIONMISMATCH = 0xC00D2778;

		/// <summary>The file could not be transferred because the device clock is not set.</summary>
		public const uint NS_E_DRM_LIC_NEEDS_DEVICE_CLOCK_SET = 0xC00D2779;

		/// <summary>The content header is missing an acquisition URL.</summary>
		public const uint NS_E_LICENSE_HEADER_MISSING_URL = 0xC00D277A;

		/// <summary>The current attached device does not support WMDRM.</summary>
		public const uint NS_E_DEVICE_NOT_WMDRM_DEVICE = 0xC00D277B;

		/// <summary>A problem has occurred in the Digital Rights Management component. Contact Microsoft product support.</summary>
		public const uint NS_E_DRM_INVALID_APPCERT = 0xC00D277C;

		/// <summary>The client application has been forcefully terminated during a DRM petition.</summary>
		public const uint NS_E_DRM_PROTOCOL_FORCEFUL_TERMINATION_ON_PETITION = 0xC00D277D;

		/// <summary>The client application has been forcefully terminated during a DRM challenge.</summary>
		public const uint NS_E_DRM_PROTOCOL_FORCEFUL_TERMINATION_ON_CHALLENGE = 0xC00D277E;

		/// <summary>Secure storage protection error. Restore your licenses from a previous backup and try again.</summary>
		public const uint NS_E_DRM_CHECKPOINT_FAILED = 0xC00D277F;

		/// <summary>A problem has occurred in the Digital Rights Management root of trust. Contact Microsoft product support.</summary>
		public const uint NS_E_DRM_BB_UNABLE_TO_INITIALIZE = 0xC00D2780;

		/// <summary>A problem has occurred in retrieving the Digital Rights Management machine identification. Contact Microsoft product support.</summary>
		public const uint NS_E_DRM_UNABLE_TO_LOAD_HARDWARE_ID = 0xC00D2781;

		/// <summary>A problem has occurred in opening the Digital Rights Management data storage file. Contact Microsoft product.</summary>
		public const uint NS_E_DRM_UNABLE_TO_OPEN_DATA_STORE = 0xC00D2782;

		/// <summary>The Digital Rights Management data storage is not functioning properly. Contact Microsoft product support.</summary>
		public const uint NS_E_DRM_DATASTORE_CORRUPT = 0xC00D2783;

		/// <summary>A problem has occurred in the Digital Rights Management component. Contact Microsoft product support.</summary>
		public const uint NS_E_DRM_UNABLE_TO_CREATE_INMEMORYSTORE_OBJECT = 0xC00D2784;

		/// <summary>A secured library is required to access the requested functionality.</summary>
		public const uint NS_E_DRM_STUBLIB_REQUIRED = 0xC00D2785;

		/// <summary>A problem has occurred in the Digital Rights Management component. Contact Microsoft product support.</summary>
		public const uint NS_E_DRM_UNABLE_TO_CREATE_CERTIFICATE_OBJECT = 0xC00D2786;

		/// <summary>A problem has occurred in the Digital Rights Management component during license migration. Contact Microsoft product support.</summary>
		public const uint NS_E_DRM_MIGRATION_TARGET_NOT_ONLINE = 0xC00D2787;

		/// <summary>A problem has occurred in the Digital Rights Management component during license migration. Contact Microsoft product support.</summary>
		public const uint NS_E_DRM_INVALID_MIGRATION_IMAGE = 0xC00D2788;

		/// <summary>A problem has occurred in the Digital Rights Management component during license migration. Contact Microsoft product support.</summary>
		public const uint NS_E_DRM_MIGRATION_TARGET_STATES_CORRUPTED = 0xC00D2789;

		/// <summary>A problem has occurred in the Digital Rights Management component during license migration. Contact Microsoft product support.</summary>
		public const uint NS_E_DRM_MIGRATION_IMPORTER_NOT_AVAILABLE = 0xC00D278A;

		/// <summary>A problem has occurred in the Digital Rights Management component during license migration. Contact Microsoft product support.</summary>
		public const uint NS_DRM_E_MIGRATION_UPGRADE_WITH_DIFF_SID = 0xC00D278B;

		/// <summary>The Digital Rights Management component is in use during license migration. Contact Microsoft product support.</summary>
		public const uint NS_DRM_E_MIGRATION_SOURCE_MACHINE_IN_USE = 0xC00D278C;

		/// <summary>Licenses are being migrated to a machine running XP or downlevel OS. This operation can only be performed on Windows Vista or a later OS. Contact Microsoft product support.</summary>
		public const uint NS_DRM_E_MIGRATION_TARGET_MACHINE_LESS_THAN_LH = 0xC00D278D;

		/// <summary>Migration Image already exists. Contact Microsoft product support.</summary>
		public const uint NS_DRM_E_MIGRATION_IMAGE_ALREADY_EXISTS = 0xC00D278E;

		/// <summary>The requested action cannot be performed because a hardware configuration change has been detected by the Windows Media Digital Rights Management (DRM) components on your computer.</summary>
		public const uint NS_E_DRM_HARDWAREID_MISMATCH = 0xC00D278F;

		/// <summary>The wrong stublib has been linked to an application or DLL using drmv2clt.dll.</summary>
		public const uint NS_E_INVALID_DRMV2CLT_STUBLIB = 0xC00D2790;

		/// <summary>The legacy V2 data being imported is invalid.</summary>
		public const uint NS_E_DRM_MIGRATION_INVALID_LEGACYV2_DATA = 0xC00D2791;

		/// <summary>The license being imported already exists.</summary>
		public const uint NS_E_DRM_MIGRATION_LICENSE_ALREADY_EXISTS = 0xC00D2792;

		/// <summary>The password of the Legacy V2 SST entry being imported is incorrect.</summary>
		public const uint NS_E_DRM_MIGRATION_INVALID_LEGACYV2_SST_PASSWORD = 0xC00D2793;

		/// <summary>Migration is not supported by the plugin.</summary>
		public const uint NS_E_DRM_MIGRATION_NOT_SUPPORTED = 0xC00D2794;

		/// <summary>A migration importer cannot be created for this media file. Reinstall the application.</summary>
		public const uint NS_E_DRM_UNABLE_TO_CREATE_MIGRATION_IMPORTER_OBJECT = 0xC00D2795;

		/// <summary>The requested action cannot be performed because a problem occurred with the Windows Media Digital Rights Management (DRM) components on your computer.</summary>
		public const uint NS_E_DRM_CHECKPOINT_MISMATCH = 0xC00D2796;

		/// <summary>The requested action cannot be performed because a problem occurred with the Windows Media Digital Rights Management (DRM) components on your computer.</summary>
		public const uint NS_E_DRM_CHECKPOINT_CORRUPT = 0xC00D2797;

		/// <summary>The requested action cannot be performed because a problem occurred with the Windows Media Digital Rights Management (DRM) components on your computer.</summary>
		public const uint NS_E_REG_FLUSH_FAILURE = 0xC00D2798;

		/// <summary>The requested action cannot be performed because a problem occurred with the Windows Media Digital Rights Management (DRM) components on your computer.</summary>
		public const uint NS_E_HDS_KEY_MISMATCH = 0xC00D2799;

		/// <summary>Migration was canceled by the user.</summary>
		public const uint NS_E_DRM_MIGRATION_OPERATION_CANCELLED = 0xC00D279A;

		/// <summary>Migration object is already in use and cannot be called until the current operation completes.</summary>
		public const uint NS_E_DRM_MIGRATION_OBJECT_IN_USE = 0xC00D279B;

		/// <summary>The content header does not comply with DRM requirements and cannot be used.</summary>
		public const uint NS_E_DRM_MALFORMED_CONTENT_HEADER = 0xC00D279C;

		/// <summary>The license for this file has expired and is no longer valid. Contact your content provider for further assistance.</summary>
		public const uint NS_E_DRM_LICENSE_EXPIRED = 0xC00D27D8;

		/// <summary>The license for this file is not valid yet, but will be at a future date.</summary>
		public const uint NS_E_DRM_LICENSE_NOTENABLED = 0xC00D27D9;

		/// <summary>The license for this file requires a higher level of security than the player you are currently using has. Try using a different player or download a newer version of your current player.</summary>
		public const uint NS_E_DRM_LICENSE_APPSECLOW = 0xC00D27DA;

		/// <summary>The license cannot be stored as it requires security upgrade of Digital Rights Management component.</summary>
		public const uint NS_E_DRM_STORE_NEEDINDI = 0xC00D27DB;

		/// <summary>Your machine does not meet the requirements for storing the license.</summary>
		public const uint NS_E_DRM_STORE_NOTALLOWED = 0xC00D27DC;

		/// <summary>The license for this file requires an upgraded version of your player or a different player.</summary>
		public const uint NS_E_DRM_LICENSE_APP_NOTALLOWED = 0xC00D27DD;

		/// <summary>The license server's certificate expired. Make sure your system clock is set correctly. Contact your content provider for further assistance.</summary>
		public const uint NS_E_DRM_LICENSE_CERT_EXPIRED = 0xC00D27DF;

		/// <summary>The license for this file requires a higher level of security than the player you are currently using has. Try using a different player or download a newer version of your current player.</summary>
		public const uint NS_E_DRM_LICENSE_SECLOW = 0xC00D27E0;

		/// <summary>The content owner for the license you just acquired is no longer supporting their content. Contact the content owner for a newer version of the content.</summary>
		public const uint NS_E_DRM_LICENSE_CONTENT_REVOKED = 0xC00D27E1;

		/// <summary>The content owner for the license you just acquired requires your device to register to the current machine.</summary>
		public const uint NS_E_DRM_DEVICE_NOT_REGISTERED = 0xC00D27E2;

		/// <summary>The license for this file requires a feature that is not supported in your current player or operating system. You can try with newer version of your current player or contact your content provider for further assistance.</summary>
		public const uint NS_E_DRM_LICENSE_NOSAP = 0xC00D280A;

		/// <summary>The license for this file requires a feature that is not supported in your current player or operating system. You can try with newer version of your current player or contact your content provider for further assistance.</summary>
		public const uint NS_E_DRM_LICENSE_NOSVP = 0xC00D280B;

		/// <summary>The license for this file requires Windows Driver Model (WDM) audio drivers. Contact your sound card manufacturer for further assistance.</summary>
		public const uint NS_E_DRM_LICENSE_NOWDM = 0xC00D280C;

		/// <summary>The license for this file requires a higher level of security than the player you are currently using has. Try using a different player or download a newer version of your current player.</summary>
		public const uint NS_E_DRM_LICENSE_NOTRUSTEDCODEC = 0xC00D280D;

		/// <summary>The license for this file is not supported by your current player. You can try with newer version of your current player or contact your content provider for further assistance.</summary>
		public const uint NS_E_DRM_SOURCEID_NOT_SUPPORTED = 0xC00D280E;

		/// <summary>An updated version of your media player is required to play the selected content.</summary>
		public const uint NS_E_DRM_NEEDS_UPGRADE_TEMPFILE = 0xC00D283D;

		/// <summary>A new version of the Digital Rights Management component is required. Contact product support for this application to get the latest version.</summary>
		public const uint NS_E_DRM_NEED_UPGRADE_PD = 0xC00D283E;

		/// <summary>Failed to either create or verify the content header.</summary>
		public const uint NS_E_DRM_SIGNATURE_FAILURE = 0xC00D283F;

		/// <summary>Could not read the necessary information from the system registry.</summary>
		public const uint NS_E_DRM_LICENSE_SERVER_INFO_MISSING = 0xC00D2840;

		/// <summary>The DRM subsystem is currently locked by another application or user. Try again later.</summary>
		public const uint NS_E_DRM_BUSY = 0xC00D2841;

		/// <summary>There are too many target devices registered on the portable media.</summary>
		public const uint NS_E_DRM_PD_TOO_MANY_DEVICES = 0xC00D2842;

		/// <summary>The security upgrade cannot be completed because the allowed number of daily upgrades has been exceeded. Try again tomorrow.</summary>
		public const uint NS_E_DRM_INDIV_FRAUD = 0xC00D2843;

		/// <summary>The security upgrade cannot be completed because the server is unable to perform the operation. Try again later.</summary>
		public const uint NS_E_DRM_INDIV_NO_CABS = 0xC00D2844;

		/// <summary>The security upgrade cannot be performed because the server is not available. Try again later.</summary>
		public const uint NS_E_DRM_INDIV_SERVICE_UNAVAILABLE = 0xC00D2845;

		/// <summary>Windows Media Player cannot restore your licenses because the server is not available. Try again later.</summary>
		public const uint NS_E_DRM_RESTORE_SERVICE_UNAVAILABLE = 0xC00D2846;

		/// <summary>Windows Media Player cannot play the protected file. Verify that your computer's date is set correctly. If it is correct, on the Help menu, click Check for Player Updates to install the latest version of the Player.</summary>
		public const uint NS_E_DRM_CLIENT_CODE_EXPIRED = 0xC00D2847;

		/// <summary>The chained license cannot be created because the referenced uplink license does not exist.</summary>
		public const uint NS_E_DRM_NO_UPLINK_LICENSE = 0xC00D2848;

		/// <summary>The specified KID is invalid.</summary>
		public const uint NS_E_DRM_INVALID_KID = 0xC00D2849;

		/// <summary>License initialization did not work. Contact Microsoft product support.</summary>
		public const uint NS_E_DRM_LICENSE_INITIALIZATION_ERROR = 0xC00D284A;

		/// <summary>The uplink license of a chained license cannot itself be a chained license.</summary>
		public const uint NS_E_DRM_CHAIN_TOO_LONG = 0xC00D284C;

		/// <summary>The specified encryption algorithm is unsupported.</summary>
		public const uint NS_E_DRM_UNSUPPORTED_ALGORITHM = 0xC00D284D;

		/// <summary>License deletion did not work. Contact Microsoft product support.</summary>
		public const uint NS_E_DRM_LICENSE_DELETION_ERROR = 0xC00D284E;

		/// <summary>The client's certificate is corrupted or the signature cannot be verified.</summary>
		public const uint NS_E_DRM_INVALID_CERTIFICATE = 0xC00D28A0;

		/// <summary>The client's certificate has been revoked.</summary>
		public const uint NS_E_DRM_CERTIFICATE_REVOKED = 0xC00D28A1;

		/// <summary>There is no license available for the requested action.</summary>
		public const uint NS_E_DRM_LICENSE_UNAVAILABLE = 0xC00D28A2;

		/// <summary>The maximum number of devices in use has been reached. Unable to open additional devices.</summary>
		public const uint NS_E_DRM_DEVICE_LIMIT_REACHED = 0xC00D28A3;

		/// <summary>The proximity detection procedure could not confirm that the receiver is near the transmitter in the network.</summary>
		public const uint NS_E_DRM_UNABLE_TO_VERIFY_PROXIMITY = 0xC00D28A4;

		/// <summary>The client must be registered before executing the intended operation.</summary>
		public const uint NS_E_DRM_MUST_REGISTER = 0xC00D28A5;

		/// <summary>The client must be approved before executing the intended operation.</summary>
		public const uint NS_E_DRM_MUST_APPROVE = 0xC00D28A6;

		/// <summary>The client must be revalidated before executing the intended operation.</summary>
		public const uint NS_E_DRM_MUST_REVALIDATE = 0xC00D28A7;

		/// <summary>The response to the proximity detection challenge is invalid.</summary>
		public const uint NS_E_DRM_INVALID_PROXIMITY_RESPONSE = 0xC00D28A8;

		/// <summary>The requested session is invalid.</summary>
		public const uint NS_E_DRM_INVALID_SESSION = 0xC00D28A9;

		/// <summary>The device must be opened before it can be used to receive content.</summary>
		public const uint NS_E_DRM_DEVICE_NOT_OPEN = 0xC00D28AA;

		/// <summary>Device registration failed because the device is already registered.</summary>
		public const uint NS_E_DRM_DEVICE_ALREADY_REGISTERED = 0xC00D28AB;

		/// <summary>Unsupported WMDRM-ND protocol version.</summary>
		public const uint NS_E_DRM_UNSUPPORTED_PROTOCOL_VERSION = 0xC00D28AC;

		/// <summary>The requested action is not supported.</summary>
		public const uint NS_E_DRM_UNSUPPORTED_ACTION = 0xC00D28AD;

		/// <summary>The certificate does not have an adequate security level for the requested action.</summary>
		public const uint NS_E_DRM_CERTIFICATE_SECURITY_LEVEL_INADEQUATE = 0xC00D28AE;

		/// <summary>Unable to open the specified port for receiving Proximity messages.</summary>
		public const uint NS_E_DRM_UNABLE_TO_OPEN_PORT = 0xC00D28AF;

		/// <summary>The message format is invalid.</summary>
		public const uint NS_E_DRM_BAD_REQUEST = 0xC00D28B0;

		/// <summary>The Certificate Revocation List is invalid or corrupted.</summary>
		public const uint NS_E_DRM_INVALID_CRL = 0xC00D28B1;

		/// <summary>The length of the attribute name or value is too long.</summary>
		public const uint NS_E_DRM_ATTRIBUTE_TOO_LONG = 0xC00D28B2;

		/// <summary>The license blob passed in the cardea request is expired.</summary>
		public const uint NS_E_DRM_EXPIRED_LICENSEBLOB = 0xC00D28B3;

		/// <summary>The license blob passed in the cardea request is invalid. Contact Microsoft product support.</summary>
		public const uint NS_E_DRM_INVALID_LICENSEBLOB = 0xC00D28B4;

		/// <summary>The requested operation cannot be performed because the license does not contain an inclusion list.</summary>
		public const uint NS_E_DRM_INCLUSION_LIST_REQUIRED = 0xC00D28B5;

		/// <summary>A problem has occurred in the Digital Rights Management component. Contact Microsoft product support.</summary>
		public const uint NS_E_DRM_DRMV2CLT_REVOKED = 0xC00D28B6;

		/// <summary>A problem has occurred in the Digital Rights Management component. Contact Microsoft product support.</summary>
		public const uint NS_E_DRM_RIV_TOO_SMALL = 0xC00D28B7;

		/// <summary>Windows Media Player does not support the level of output protection required by the content.</summary>
		public const uint NS_E_OUTPUT_PROTECTION_LEVEL_UNSUPPORTED = 0xC00D2904;

		/// <summary>Windows Media Player does not support the level of protection required for compressed digital video.</summary>
		public const uint NS_E_COMPRESSED_DIGITAL_VIDEO_PROTECTION_LEVEL_UNSUPPORTED = 0xC00D2905;

		/// <summary>Windows Media Player does not support the level of protection required for uncompressed digital video.</summary>
		public const uint NS_E_UNCOMPRESSED_DIGITAL_VIDEO_PROTECTION_LEVEL_UNSUPPORTED = 0xC00D2906;

		/// <summary>Windows Media Player does not support the level of protection required for analog video.</summary>
		public const uint NS_E_ANALOG_VIDEO_PROTECTION_LEVEL_UNSUPPORTED = 0xC00D2907;

		/// <summary>Windows Media Player does not support the level of protection required for compressed digital audio.</summary>
		public const uint NS_E_COMPRESSED_DIGITAL_AUDIO_PROTECTION_LEVEL_UNSUPPORTED = 0xC00D2908;

		/// <summary>Windows Media Player does not support the level of protection required for uncompressed digital audio.</summary>
		public const uint NS_E_UNCOMPRESSED_DIGITAL_AUDIO_PROTECTION_LEVEL_UNSUPPORTED = 0xC00D2909;

		/// <summary>Windows Media Player does not support the scheme of output protection required by the content.</summary>
		public const uint NS_E_OUTPUT_PROTECTION_SCHEME_UNSUPPORTED = 0xC00D290A;

		/// <summary>Installation was not successful and some file cleanup is not complete. For best results, restart your computer.</summary>
		public const uint NS_E_REBOOT_RECOMMENDED = 0xC00D2AFA;

		/// <summary>Installation was not successful. To continue, you must restart your computer.</summary>
		public const uint NS_E_REBOOT_REQUIRED = 0xC00D2AFB;

		/// <summary>Installation was not successful.</summary>
		public const uint NS_E_SETUP_INCOMPLETE = 0xC00D2AFC;

		/// <summary>Setup cannot migrate the Windows Media Digital Rights Management (DRM) components.</summary>
		public const uint NS_E_SETUP_DRM_MIGRATION_FAILED = 0xC00D2AFD;

		/// <summary>Some skin or playlist components cannot be installed.</summary>
		public const uint NS_E_SETUP_IGNORABLE_FAILURE = 0xC00D2AFE;

		/// <summary>Setup cannot migrate the Windows Media Digital Rights Management (DRM) components. In addition, some skin or playlist components cannot be installed.</summary>
		public const uint NS_E_SETUP_DRM_MIGRATION_FAILED_AND_IGNORABLE_FAILURE = 0xC00D2AFF;

		/// <summary>Installation is blocked because your computer does not meet one or more of the setup requirements.</summary>
		public const uint NS_E_SETUP_BLOCKED = 0xC00D2B00;

		/// <summary>The specified protocol is not supported.</summary>
		public const uint NS_E_UNKNOWN_PROTOCOL = 0xC00D2EE0;

		/// <summary>The client is redirected to a proxy server.</summary>
		public const uint NS_E_REDIRECT_TO_PROXY = 0xC00D2EE1;

		/// <summary>The server encountered an unexpected condition which prevented it from fulfilling the request.</summary>
		public const uint NS_E_INTERNAL_SERVER_ERROR = 0xC00D2EE2;

		/// <summary>The request could not be understood by the server.</summary>
		public const uint NS_E_BAD_REQUEST = 0xC00D2EE3;

		/// <summary>The proxy experienced an error while attempting to contact the media server.</summary>
		public const uint NS_E_ERROR_FROM_PROXY = 0xC00D2EE4;

		/// <summary>The proxy did not receive a timely response while attempting to contact the media server.</summary>
		public const uint NS_E_PROXY_TIMEOUT = 0xC00D2EE5;

		/// <summary>The server is currently unable to handle the request due to a temporary overloading or maintenance of the server.</summary>
		public const uint NS_E_SERVER_UNAVAILABLE = 0xC00D2EE6;

		/// <summary>The server is refusing to fulfill the requested operation.</summary>
		public const uint NS_E_REFUSED_BY_SERVER = 0xC00D2EE7;

		/// <summary>The server is not a compatible streaming media server.</summary>
		public const uint NS_E_INCOMPATIBLE_SERVER = 0xC00D2EE8;

		/// <summary>The content cannot be streamed because the Multicast protocol has been disabled.</summary>
		public const uint NS_E_MULTICAST_DISABLED = 0xC00D2EE9;

		/// <summary>The server redirected the player to an invalid location.</summary>
		public const uint NS_E_INVALID_REDIRECT = 0xC00D2EEA;

		/// <summary>The content cannot be streamed because all protocols have been disabled.</summary>
		public const uint NS_E_ALL_PROTOCOLS_DISABLED = 0xC00D2EEB;

		/// <summary>The MSBD protocol is no longer supported. Please use HTTP to connect to the Windows Media stream.</summary>
		public const uint NS_E_MSBD_NO_LONGER_SUPPORTED = 0xC00D2EEC;

		/// <summary>The proxy server could not be located. Please check your proxy server configuration.</summary>
		public const uint NS_E_PROXY_NOT_FOUND = 0xC00D2EED;

		/// <summary>Unable to establish a connection to the proxy server. Please check your proxy server configuration.</summary>
		public const uint NS_E_CANNOT_CONNECT_TO_PROXY = 0xC00D2EEE;

		/// <summary>Unable to locate the media server. The operation timed out.</summary>
		public const uint NS_E_SERVER_DNS_TIMEOUT = 0xC00D2EEF;

		/// <summary>Unable to locate the proxy server. The operation timed out.</summary>
		public const uint NS_E_PROXY_DNS_TIMEOUT = 0xC00D2EF0;

		/// <summary>Media closed because Windows was shut down.</summary>
		public const uint NS_E_CLOSED_ON_SUSPEND = 0xC00D2EF1;

		/// <summary>Unable to read the contents of a playlist file from a media server.</summary>
		public const uint NS_E_CANNOT_READ_PLAYLIST_FROM_MEDIASERVER = 0xC00D2EF2;

		/// <summary>Session not found.</summary>
		public const uint NS_E_SESSION_NOT_FOUND = 0xC00D2EF3;

		/// <summary>Content requires a streaming media client.</summary>
		public const uint NS_E_REQUIRE_STREAMING_CLIENT = 0xC00D2EF4;

		/// <summary>A command applies to a previous playlist entry.</summary>
		public const uint NS_E_PLAYLIST_ENTRY_HAS_CHANGED = 0xC00D2EF5;

		/// <summary>The proxy server is denying access. The username and/or password might be incorrect.</summary>
		public const uint NS_E_PROXY_ACCESSDENIED = 0xC00D2EF6;

		/// <summary>The proxy could not provide valid authentication credentials to the media server.</summary>
		public const uint NS_E_PROXY_SOURCE_ACCESSDENIED = 0xC00D2EF7;

		/// <summary>The network sink failed to write data to the network.</summary>
		public const uint NS_E_NETWORK_SINK_WRITE = 0xC00D2EF8;

		/// <summary>Packets are not being received from the server. The packets might be blocked by a filtering device, such as a network firewall.</summary>
		public const uint NS_E_FIREWALL = 0xC00D2EF9;

		/// <summary>The MMS protocol is not supported. Please use HTTP or RTSP to connect to the Windows Media stream.</summary>
		public const uint NS_E_MMS_NOT_SUPPORTED = 0xC00D2EFA;

		/// <summary>The Windows Media server is denying access. The username and/or password might be incorrect.</summary>
		public const uint NS_E_SERVER_ACCESSDENIED = 0xC00D2EFB;

		/// <summary>The Publishing Point or file on the Windows Media Server is no longer available.</summary>
		public const uint NS_E_RESOURCE_GONE = 0xC00D2EFC;

		/// <summary>There is no existing packetizer plugin for a stream.</summary>
		public const uint NS_E_NO_EXISTING_PACKETIZER = 0xC00D2EFD;

		/// <summary>The response from the media server could not be understood. This might be caused by an incompatible proxy server or media server.</summary>
		public const uint NS_E_BAD_SYNTAX_IN_SERVER_RESPONSE = 0xC00D2EFE;

		/// <summary>The Windows Media Server reset the network connection.</summary>
		public const uint NS_E_RESET_SOCKET_CONNECTION = 0xC00D2F00;

		/// <summary>The request could not reach the media server (too many hops).</summary>
		public const uint NS_E_TOO_MANY_HOPS = 0xC00D2F02;

		/// <summary>The server is sending too much data. The connection has been terminated.</summary>
		public const uint NS_E_TOO_MUCH_DATA_FROM_SERVER = 0xC00D2F05;

		/// <summary>It was not possible to establish a connection to the media server in a timely manner. The media server might be down for maintenance, or it might be necessary to use a proxy server to access this media server.</summary>
		public const uint NS_E_CONNECT_TIMEOUT = 0xC00D2F06;

		/// <summary>It was not possible to establish a connection to the proxy server in a timely manner. Please check your proxy server configuration.</summary>
		public const uint NS_E_PROXY_CONNECT_TIMEOUT = 0xC00D2F07;

		/// <summary>Session not found.</summary>
		public const uint NS_E_SESSION_INVALID = 0xC00D2F08;

		/// <summary>Unknown packet sink stream.</summary>
		public const uint NS_E_PACKETSINK_UNKNOWN_FEC_STREAM = 0xC00D2F0A;

		/// <summary>Unable to establish a connection to the server. Ensure Windows Media Services is started and the HTTP Server control protocol is properly enabled.</summary>
		public const uint NS_E_PUSH_CANNOTCONNECT = 0xC00D2F0B;

		/// <summary>The Server service that received the HTTP push request is not a compatible version of Windows Media Services (WMS). This error might indicate the push request was received by IIS instead of WMS. Ensure WMS is started and has the HTTP Server control protocol properly enabled and try again.</summary>
		public const uint NS_E_INCOMPATIBLE_PUSH_SERVER = 0xC00D2F0C;

		/// <summary>The playlist has reached its end.</summary>
		public const uint NS_E_END_OF_PLAYLIST = 0xC00D32C8;

		/// <summary>Use file source.</summary>
		public const uint NS_E_USE_FILE_SOURCE = 0xC00D32C9;

		/// <summary>The property was not found.</summary>
		public const uint NS_E_PROPERTY_NOT_FOUND = 0xC00D32CA;

		/// <summary>The property is read only.</summary>
		public const uint NS_E_PROPERTY_READ_ONLY = 0xC00D32CC;

		/// <summary>The table key was not found.</summary>
		public const uint NS_E_TABLE_KEY_NOT_FOUND = 0xC00D32CD;

		/// <summary>Invalid query operator.</summary>
		public const uint NS_E_INVALID_QUERY_OPERATOR = 0xC00D32CF;

		/// <summary>Invalid query property.</summary>
		public const uint NS_E_INVALID_QUERY_PROPERTY = 0xC00D32D0;

		/// <summary>The property is not supported.</summary>
		public const uint NS_E_PROPERTY_NOT_SUPPORTED = 0xC00D32D2;

		/// <summary>Schema classification failure.</summary>
		public const uint NS_E_SCHEMA_CLASSIFY_FAILURE = 0xC00D32D4;

		/// <summary>The metadata format is not supported.</summary>
		public const uint NS_E_METADATA_FORMAT_NOT_SUPPORTED = 0xC00D32D5;

		/// <summary>Cannot edit the metadata.</summary>
		public const uint NS_E_METADATA_NO_EDITING_CAPABILITY = 0xC00D32D6;

		/// <summary>Cannot set the locale id.</summary>
		public const uint NS_E_METADATA_CANNOT_SET_LOCALE = 0xC00D32D7;

		/// <summary>The language is not supported in the format.</summary>
		public const uint NS_E_METADATA_LANGUAGE_NOT_SUPORTED = 0xC00D32D8;

		/// <summary>There is no RFC1766 name translation for the supplied locale id.</summary>
		public const uint NS_E_METADATA_NO_RFC1766_NAME_FOR_LOCALE = 0xC00D32D9;

		/// <summary>The metadata (or metadata item) is not available.</summary>
		public const uint NS_E_METADATA_NOT_AVAILABLE = 0xC00D32DA;

		/// <summary>The cached metadata (or metadata item) is not available.</summary>
		public const uint NS_E_METADATA_CACHE_DATA_NOT_AVAILABLE = 0xC00D32DB;

		/// <summary>The metadata document is invalid.</summary>
		public const uint NS_E_METADATA_INVALID_DOCUMENT_TYPE = 0xC00D32DC;

		/// <summary>The metadata content identifier is not available.</summary>
		public const uint NS_E_METADATA_IDENTIFIER_NOT_AVAILABLE = 0xC00D32DD;

		/// <summary>Cannot retrieve metadata from the offline metadata cache.</summary>
		public const uint NS_E_METADATA_CANNOT_RETRIEVE_FROM_OFFLINE_CACHE = 0xC00D32DE;

		/// <summary>Checksum of the obtained monitor descriptor is invalid.</summary>
		public const uint ERROR_MONITOR_INVALID_DESCRIPTOR_CHECKSUM = 0xC0261003;

		/// <summary>Monitor descriptor contains an invalid standard timing block.</summary>
		public const uint ERROR_MONITOR_INVALID_STANDARD_TIMING_BLOCK = 0xC0261004;

		/// <summary>Windows Management Instrumentation (WMI) data block registration failed for one of the MSMonitorClass WMI subclasses.</summary>
		public const uint ERROR_MONITOR_WMI_DATABLOCK_REGISTRATION_FAILED = 0xC0261005;

		/// <summary>Provided monitor descriptor block is either corrupted or does not contain the monitor's detailed serial number.</summary>
		public const uint ERROR_MONITOR_INVALID_SERIAL_NUMBER_MONDSC_BLOCK = 0xC0261006;

		/// <summary>Provided monitor descriptor block is either corrupted or does not contain the monitor's user-friendly name.</summary>
		public const uint ERROR_MONITOR_INVALID_USER_FRIENDLY_MONDSC_BLOCK = 0xC0261007;

		/// <summary>There is no monitor descriptor data at the specified (offset, size) region.</summary>
		public const uint ERROR_MONITOR_NO_MORE_DESCRIPTOR_DATA = 0xC0261008;

		/// <summary>Monitor descriptor contains an invalid detailed timing block.</summary>
		public const uint ERROR_MONITOR_INVALID_DETAILED_TIMING_BLOCK = 0xC0261009;

		/// <summary>Exclusive mode ownership is needed to create unmanaged primary allocation.</summary>
		public const uint ERROR_GRAPHICS_NOT_EXCLUSIVE_MODE_OWNER = 0xC0262000;

		/// <summary>The driver needs more direct memory access (DMA) buffer space to complete the requested operation.</summary>
		public const uint ERROR_GRAPHICS_INSUFFICIENT_DMA_BUFFER = 0xC0262001;

		/// <summary>Specified display adapter handle is invalid.</summary>
		public const uint ERROR_GRAPHICS_INVALID_DISPLAY_ADAPTER = 0xC0262002;

		/// <summary>Specified display adapter and all of its state has been reset.</summary>
		public const uint ERROR_GRAPHICS_ADAPTER_WAS_RESET = 0xC0262003;

		/// <summary>The driver stack does not match the expected driver model.</summary>
		public const uint ERROR_GRAPHICS_INVALID_DRIVER_MODEL = 0xC0262004;

		/// <summary>Present happened but ended up into the changed desktop mode.</summary>
		public const uint ERROR_GRAPHICS_PRESENT_MODE_CHANGED = 0xC0262005;

		/// <summary>Nothing to present due to desktop occlusion.</summary>
		public const uint ERROR_GRAPHICS_PRESENT_OCCLUDED = 0xC0262006;

		/// <summary>Not able to present due to denial of desktop access.</summary>
		public const uint ERROR_GRAPHICS_PRESENT_DENIED = 0xC0262007;

		/// <summary>Not able to present with color conversion.</summary>
		public const uint ERROR_GRAPHICS_CANNOTCOLORCONVERT = 0xC0262008;

		/// <summary>Not enough video memory available to complete the operation.</summary>
		public const uint ERROR_GRAPHICS_NO_VIDEO_MEMORY = 0xC0262100;

		/// <summary>Could not probe and lock the underlying memory of an allocation.</summary>
		public const uint ERROR_GRAPHICS_CANT_LOCK_MEMORY = 0xC0262101;

		/// <summary>The allocation is currently busy.</summary>
		public const uint ERROR_GRAPHICS_ALLOCATION_BUSY = 0xC0262102;

		/// <summary>An object being referenced has reach the maximum reference count already and cannot be referenced further.</summary>
		public const uint ERROR_GRAPHICS_TOO_MANY_REFERENCES = 0xC0262103;

		/// <summary>A problem could not be solved due to some currently existing condition. The problem should be tried again later.</summary>
		public const uint ERROR_GRAPHICS_TRY_AGAIN_LATER = 0xC0262104;

		/// <summary>A problem could not be solved due to some currently existing condition. The problem should be tried again immediately.</summary>
		public const uint ERROR_GRAPHICS_TRY_AGAIN_NOW = 0xC0262105;

		/// <summary>The allocation is invalid.</summary>
		public const uint ERROR_GRAPHICS_ALLOCATION_INVALID = 0xC0262106;

		/// <summary>No more unswizzling apertures are currently available.</summary>
		public const uint ERROR_GRAPHICS_UNSWIZZLING_APERTURE_UNAVAILABLE = 0xC0262107;

		/// <summary>The current allocation cannot be unswizzled by an aperture.</summary>
		public const uint ERROR_GRAPHICS_UNSWIZZLING_APERTURE_UNSUPPORTED = 0xC0262108;

		/// <summary>The request failed because a pinned allocation cannot be evicted.</summary>
		public const uint ERROR_GRAPHICS_CANT_EVICT_PINNED_ALLOCATION = 0xC0262109;

		/// <summary>The allocation cannot be used from its current segment location for the specified operation.</summary>
		public const uint ERROR_GRAPHICS_INVALID_ALLOCATION_USAGE = 0xC0262110;

		/// <summary>A locked allocation cannot be used in the current command buffer.</summary>
		public const uint ERROR_GRAPHICS_CANT_RENDER_LOCKED_ALLOCATION = 0xC0262111;

		/// <summary>The allocation being referenced has been closed permanently.</summary>
		public const uint ERROR_GRAPHICS_ALLOCATION_CLOSED = 0xC0262112;

		/// <summary>An invalid allocation instance is being referenced.</summary>
		public const uint ERROR_GRAPHICS_INVALID_ALLOCATION_INSTANCE = 0xC0262113;

		/// <summary>An invalid allocation handle is being referenced.</summary>
		public const uint ERROR_GRAPHICS_INVALID_ALLOCATION_HANDLE = 0xC0262114;

		/// <summary>The allocation being referenced does not belong to the current device.</summary>
		public const uint ERROR_GRAPHICS_WRONG_ALLOCATION_DEVICE = 0xC0262115;

		/// <summary>The specified allocation lost its content.</summary>
		public const uint ERROR_GRAPHICS_ALLOCATION_CONTENT_LOST = 0xC0262116;

		/// <summary>Graphics processing unit (GPU) exception is detected on the given device. The device is not able to be scheduled.</summary>
		public const uint ERROR_GRAPHICS_GPU_EXCEPTION_ON_DEVICE = 0xC0262200;

		/// <summary>Specified video present network (VidPN) topology is invalid.</summary>
		public const uint ERROR_GRAPHICS_INVALID_VIDPN_TOPOLOGY = 0xC0262300;

		/// <summary>Specified VidPN topology is valid but is not supported by this model of the display adapter.</summary>
		public const uint ERROR_GRAPHICS_VIDPN_TOPOLOGY_NOT_SUPPORTED = 0xC0262301;

		/// <summary>Specified VidPN topology is valid but is not supported by the display adapter at this time, due to current allocation of its resources.</summary>
		public const uint ERROR_GRAPHICS_VIDPN_TOPOLOGY_CURRENTLY_NOT_SUPPORTED = 0xC0262302;

		/// <summary>Specified VidPN handle is invalid.</summary>
		public const uint ERROR_GRAPHICS_INVALID_VIDPN = 0xC0262303;

		/// <summary>Specified video present source is invalid.</summary>
		public const uint ERROR_GRAPHICS_INVALID_VIDEO_PRESENT_SOURCE = 0xC0262304;

		/// <summary>Specified video present target is invalid.</summary>
		public const uint ERROR_GRAPHICS_INVALID_VIDEO_PRESENT_TARGET = 0xC0262305;

		/// <summary>Specified VidPN modality is not supported (for example, at least two of the pinned modes are not cofunctional).</summary>
		public const uint ERROR_GRAPHICS_VIDPN_MODALITY_NOT_SUPPORTED = 0xC0262306;

		/// <summary>Specified VidPN source mode set is invalid.</summary>
		public const uint ERROR_GRAPHICS_INVALID_VIDPN_SOURCEMODESET = 0xC0262308;

		/// <summary>Specified VidPN target mode set is invalid.</summary>
		public const uint ERROR_GRAPHICS_INVALID_VIDPN_TARGETMODESET = 0xC0262309;

		/// <summary>Specified video signal frequency is invalid.</summary>
		public const uint ERROR_GRAPHICS_INVALID_FREQUENCY = 0xC026230A;

		/// <summary>Specified video signal active region is invalid.</summary>
		public const uint ERROR_GRAPHICS_INVALID_ACTIVE_REGION = 0xC026230B;

		/// <summary>Specified video signal total region is invalid.</summary>
		public const uint ERROR_GRAPHICS_INVALID_TOTAL_REGION = 0xC026230C;

		/// <summary>Specified video present source mode is invalid.</summary>
		public const uint ERROR_GRAPHICS_INVALID_VIDEO_PRESENT_SOURCE_MODE = 0xC0262310;

		/// <summary>Specified video present target mode is invalid.</summary>
		public const uint ERROR_GRAPHICS_INVALID_VIDEO_PRESENT_TARGET_MODE = 0xC0262311;

		/// <summary>Pinned mode must remain in the set on VidPN's cofunctional modality enumeration.</summary>
		public const uint ERROR_GRAPHICS_PINNED_MODE_MUST_REMAIN_IN_SET = 0xC0262312;

		/// <summary>Specified video present path is already in the VidPN topology.</summary>
		public const uint ERROR_GRAPHICS_PATH_ALREADY_IN_TOPOLOGY = 0xC0262313;

		/// <summary>Specified mode is already in the mode set.</summary>
		public const uint ERROR_GRAPHICS_MODE_ALREADY_IN_MODESET = 0xC0262314;

		/// <summary>Specified video present source set is invalid.</summary>
		public const uint ERROR_GRAPHICS_INVALID_VIDEOPRESENTSOURCESET = 0xC0262315;

		/// <summary>Specified video present target set is invalid.</summary>
		public const uint ERROR_GRAPHICS_INVALID_VIDEOPRESENTTARGETSET = 0xC0262316;

		/// <summary>Specified video present source is already in the video present source set.</summary>
		public const uint ERROR_GRAPHICS_SOURCE_ALREADY_IN_SET = 0xC0262317;

		/// <summary>Specified video present target is already in the video present target set.</summary>
		public const uint ERROR_GRAPHICS_TARGET_ALREADY_IN_SET = 0xC0262318;

		/// <summary>Specified VidPN present path is invalid.</summary>
		public const uint ERROR_GRAPHICS_INVALID_VIDPN_PRESENT_PATH = 0xC0262319;

		/// <summary>Miniport has no recommendation for augmentation of the specified VidPN topology.</summary>
		public const uint ERROR_GRAPHICS_NO_RECOMMENDED_VIDPN_TOPOLOGY = 0xC026231A;

		/// <summary>Specified monitor frequency range set is invalid.</summary>
		public const uint ERROR_GRAPHICS_INVALID_MONITOR_FREQUENCYRANGESET = 0xC026231B;

		/// <summary>Specified monitor frequency range is invalid.</summary>
		public const uint ERROR_GRAPHICS_INVALID_MONITOR_FREQUENCYRANGE = 0xC026231C;

		/// <summary>Specified frequency range is not in the specified monitor frequency range set.</summary>
		public const uint ERROR_GRAPHICS_FREQUENCYRANGE_NOT_IN_SET = 0xC026231D;

		/// <summary>Specified frequency range is already in the specified monitor frequency range set.</summary>
		public const uint ERROR_GRAPHICS_FREQUENCYRANGE_ALREADY_IN_SET = 0xC026231F;

		/// <summary>Specified mode set is stale. Reacquire the new mode set.</summary>
		public const uint ERROR_GRAPHICS_STALE_MODESET = 0xC0262320;

		/// <summary>Specified monitor source mode set is invalid.</summary>
		public const uint ERROR_GRAPHICS_INVALID_MONITOR_SOURCEMODESET = 0xC0262321;

		/// <summary>Specified monitor source mode is invalid.</summary>
		public const uint ERROR_GRAPHICS_INVALID_MONITOR_SOURCE_MODE = 0xC0262322;

		/// <summary>Miniport does not have any recommendation regarding the request to provide a functional VidPN given the current display adapter configuration.</summary>
		public const uint ERROR_GRAPHICS_NO_RECOMMENDED_FUNCTIONAL_VIDPN = 0xC0262323;

		/// <summary>ID of the specified mode is already used by another mode in the set.</summary>
		public const uint ERROR_GRAPHICS_MODE_ID_MUST_BE_UNIQUE = 0xC0262324;

		/// <summary>System failed to determine a mode that is supported by both the display adapter and the monitor connected to it.</summary>
		public const uint ERROR_GRAPHICS_EMPTY_ADAPTER_MONITOR_MODE_SUPPORT_INTERSECTION = 0xC0262325;

		/// <summary>Number of video present targets must be greater than or equal to the number of video present sources.</summary>
		public const uint ERROR_GRAPHICS_VIDEO_PRESENT_TARGETS_LESS_THAN_SOURCES = 0xC0262326;

		/// <summary>Specified present path is not in the VidPN topology.</summary>
		public const uint ERROR_GRAPHICS_PATH_NOT_IN_TOPOLOGY = 0xC0262327;

		/// <summary>Display adapter must have at least one video present source.</summary>
		public const uint ERROR_GRAPHICS_ADAPTER_MUST_HAVE_AT_LEAST_ONE_SOURCE = 0xC0262328;

		/// <summary>Display adapter must have at least one video present target.</summary>
		public const uint ERROR_GRAPHICS_ADAPTER_MUST_HAVE_AT_LEAST_ONE_TARGET = 0xC0262329;

		/// <summary>Specified monitor descriptor set is invalid.</summary>
		public const uint ERROR_GRAPHICS_INVALID_MONITORDESCRIPTORSET = 0xC026232A;

		/// <summary>Specified monitor descriptor is invalid.</summary>
		public const uint ERROR_GRAPHICS_INVALID_MONITORDESCRIPTOR = 0xC026232B;

		/// <summary>Specified descriptor is not in the specified monitor descriptor set.</summary>
		public const uint ERROR_GRAPHICS_MONITORDESCRIPTOR_NOT_IN_SET = 0xC026232C;

		/// <summary>Specified descriptor is already in the specified monitor descriptor set.</summary>
		public const uint ERROR_GRAPHICS_MONITORDESCRIPTOR_ALREADY_IN_SET = 0xC026232D;

		/// <summary>ID of the specified monitor descriptor is already used by another descriptor in the set.</summary>
		public const uint ERROR_GRAPHICS_MONITORDESCRIPTOR_ID_MUST_BE_UNIQUE = 0xC026232E;

		/// <summary>Specified video present target subset type is invalid.</summary>
		public const uint ERROR_GRAPHICS_INVALID_VIDPN_TARGET_SUBSET_TYPE = 0xC026232F;

		/// <summary>Two or more of the specified resources are not related to each other, as defined by the interface semantics.</summary>
		public const uint ERROR_GRAPHICS_RESOURCES_NOT_RELATED = 0xC0262330;

		/// <summary>ID of the specified video present source is already used by another source in the set.</summary>
		public const uint ERROR_GRAPHICS_SOURCE_ID_MUST_BE_UNIQUE = 0xC0262331;

		/// <summary>ID of the specified video present target is already used by another target in the set.</summary>
		public const uint ERROR_GRAPHICS_TARGET_ID_MUST_BE_UNIQUE = 0xC0262332;

		/// <summary>Specified VidPN source cannot be used because there is no available VidPN target to connect it to.</summary>
		public const uint ERROR_GRAPHICS_NO_AVAILABLE_VIDPN_TARGET = 0xC0262333;

		/// <summary>Newly arrived monitor could not be associated with a display adapter.</summary>
		public const uint ERROR_GRAPHICS_MONITOR_COULD_NOT_BE_ASSOCIATED_WITH_ADAPTER = 0xC0262334;

		/// <summary>Display adapter in question does not have an associated VidPN manager.</summary>
		public const uint ERROR_GRAPHICS_NO_VIDPNMGR = 0xC0262335;

		/// <summary>VidPN manager of the display adapter in question does not have an active VidPN.</summary>
		public const uint ERROR_GRAPHICS_NO_ACTIVE_VIDPN = 0xC0262336;

		/// <summary>Specified VidPN topology is stale. Re-acquire the new topology.</summary>
		public const uint ERROR_GRAPHICS_STALE_VIDPN_TOPOLOGY = 0xC0262337;

		/// <summary>There is no monitor connected on the specified video present target.</summary>
		public const uint ERROR_GRAPHICS_MONITOR_NOT_CONNECTED = 0xC0262338;

		/// <summary>Specified source is not part of the specified VidPN topology.</summary>
		public const uint ERROR_GRAPHICS_SOURCE_NOT_IN_TOPOLOGY = 0xC0262339;

		/// <summary>Specified primary surface size is invalid.</summary>
		public const uint ERROR_GRAPHICS_INVALID_PRIMARYSURFACE_SIZE = 0xC026233A;

		/// <summary>Specified visible region size is invalid.</summary>
		public const uint ERROR_GRAPHICS_INVALID_VISIBLEREGION_SIZE = 0xC026233B;

		/// <summary>Specified stride is invalid.</summary>
		public const uint ERROR_GRAPHICS_INVALID_STRIDE = 0xC026233C;

		/// <summary>Specified pixel format is invalid.</summary>
		public const uint ERROR_GRAPHICS_INVALID_PIXELFORMAT = 0xC026233D;

		/// <summary>Specified color basis is invalid.</summary>
		public const uint ERROR_GRAPHICS_INVALID_COLORBASIS = 0xC026233E;

		/// <summary>Specified pixel value access mode is invalid.</summary>
		public const uint ERROR_GRAPHICS_INVALID_PIXELVALUEACCESSMODE = 0xC026233F;

		/// <summary>Specified target is not part of the specified VidPN topology.</summary>
		public const uint ERROR_GRAPHICS_TARGET_NOT_IN_TOPOLOGY = 0xC0262340;

		/// <summary>Failed to acquire display mode management interface.</summary>
		public const uint ERROR_GRAPHICS_NO_DISPLAY_MODE_MANAGEMENT_SUPPORT = 0xC0262341;

		/// <summary>Specified VidPN source is already owned by a display mode manager (DMM) client and cannot be used until that client releases it.</summary>
		public const uint ERROR_GRAPHICS_VIDPN_SOURCE_IN_USE = 0xC0262342;

		/// <summary>Specified VidPN is active and cannot be accessed.</summary>
		public const uint ERROR_GRAPHICS_CANT_ACCESS_ACTIVE_VIDPN = 0xC0262343;

		/// <summary>Specified VidPN present path importance ordinal is invalid.</summary>
		public const uint ERROR_GRAPHICS_INVALID_PATH_IMPORTANCE_ORDINAL = 0xC0262344;

		/// <summary>Specified VidPN present path content geometry transformation is invalid.</summary>
		public const uint ERROR_GRAPHICS_INVALID_PATH_CONTENT_GEOMETRY_TRANSFORMATION = 0xC0262345;

		/// <summary>Specified content geometry transformation is not supported on the respective VidPN present path.</summary>
		public const uint ERROR_GRAPHICS_PATH_CONTENT_GEOMETRY_TRANSFORMATION_NOT_SUPPORTED = 0xC0262346;

		/// <summary>Specified gamma ramp is invalid.</summary>
		public const uint ERROR_GRAPHICS_INVALID_GAMMA_RAMP = 0xC0262347;

		/// <summary>Specified gamma ramp is not supported on the respective VidPN present path.</summary>
		public const uint ERROR_GRAPHICS_GAMMA_RAMP_NOT_SUPPORTED = 0xC0262348;

		/// <summary>Multisampling is not supported on the respective VidPN present path.</summary>
		public const uint ERROR_GRAPHICS_MULTISAMPLING_NOT_SUPPORTED = 0xC0262349;

		/// <summary>Specified mode is not in the specified mode set.</summary>
		public const uint ERROR_GRAPHICS_MODE_NOT_IN_MODESET = 0xC026234A;

		/// <summary>Specified VidPN topology recommendation reason is invalid.</summary>
		public const uint ERROR_GRAPHICS_INVALID_VIDPN_TOPOLOGY_RECOMMENDATION_REASON = 0xC026234D;

		/// <summary>Specified VidPN present path content type is invalid.</summary>
		public const uint ERROR_GRAPHICS_INVALID_PATH_CONTENT_TYPE = 0xC026234E;

		/// <summary>Specified VidPN present path copy protection type is invalid.</summary>
		public const uint ERROR_GRAPHICS_INVALID_COPYPROTECTION_TYPE = 0xC026234F;

		/// <summary>No more than one unassigned mode set can exist at any given time for a given VidPN source or target.</summary>
		public const uint ERROR_GRAPHICS_UNASSIGNED_MODESET_ALREADY_EXISTS = 0xC0262350;

		/// <summary>The specified scan line ordering type is invalid.</summary>
		public const uint ERROR_GRAPHICS_INVALID_SCANLINE_ORDERING = 0xC0262352;

		/// <summary>Topology changes are not allowed for the specified VidPN.</summary>
		public const uint ERROR_GRAPHICS_TOPOLOGY_CHANGES_NOT_ALLOWED = 0xC0262353;

		/// <summary>All available importance ordinals are already used in the specified topology.</summary>
		public const uint ERROR_GRAPHICS_NO_AVAILABLE_IMPORTANCE_ORDINALS = 0xC0262354;

		/// <summary>Specified primary surface has a different private format attribute than the current primary surface.</summary>
		public const uint ERROR_GRAPHICS_INCOMPATIBLE_PRIVATE_FORMAT = 0xC0262355;

		/// <summary>Specified mode pruning algorithm is invalid.</summary>
		public const uint ERROR_GRAPHICS_INVALID_MODE_PRUNING_ALGORITHM = 0xC0262356;

		/// <summary>Specified display adapter child device already has an external device connected to it.</summary>
		public const uint ERROR_GRAPHICS_SPECIFIED_CHILD_ALREADY_CONNECTED = 0xC0262400;

		/// <summary>The display adapter child device does not support reporting a descriptor.</summary>
		public const uint ERROR_GRAPHICS_CHILD_DESCRIPTOR_NOT_SUPPORTED = 0xC0262401;

		/// <summary>The display adapter is not linked to any other adapters.</summary>
		public const uint ERROR_GRAPHICS_NOT_A_LINKED_ADAPTER = 0xC0262430;

		/// <summary>Lead adapter in a linked configuration was not enumerated yet.</summary>
		public const uint ERROR_GRAPHICS_LEADLINK_NOT_ENUMERATED = 0xC0262431;

		/// <summary>Some chain adapters in a linked configuration were not enumerated yet.</summary>
		public const uint ERROR_GRAPHICS_CHAINLINKS_NOT_ENUMERATED = 0xC0262432;

		/// <summary>The chain of linked adapters is not ready to start because of an unknown failure.</summary>
		public const uint ERROR_GRAPHICS_ADAPTER_CHAIN_NOT_READY = 0xC0262433;

		/// <summary>An attempt was made to start a lead link display adapter when the chain links were not started yet.</summary>
		public const uint ERROR_GRAPHICS_CHAINLINKS_NOT_STARTED = 0xC0262434;

		/// <summary>An attempt was made to turn on a lead link display adapter when the chain links were turned off.</summary>
		public const uint ERROR_GRAPHICS_CHAINLINKS_NOT_POWERED_ON = 0xC0262435;

		/// <summary>The adapter link was found to be in an inconsistent state. Not all adapters are in an expected PNP or power state.</summary>
		public const uint ERROR_GRAPHICS_INCONSISTENT_DEVICE_LINK_STATE = 0xC0262436;

		/// <summary>The driver trying to start is not the same as the driver for the posted display adapter.</summary>
		public const uint ERROR_GRAPHICS_NOT_POST_DEVICE_DRIVER = 0xC0262438;

		/// <summary>The driver does not support Output Protection Manager (OPM).</summary>
		public const uint ERROR_GRAPHICS_OPM_NOT_SUPPORTED = 0xC0262500;

		/// <summary>The driver does not support Certified Output Protection Protocol (COPP).</summary>
		public const uint ERROR_GRAPHICS_COPP_NOT_SUPPORTED = 0xC0262501;

		/// <summary>The driver does not support a user-accessible bus (UAB).</summary>
		public const uint ERROR_GRAPHICS_UAB_NOT_SUPPORTED = 0xC0262502;

		/// <summary>The specified encrypted parameters are invalid.</summary>
		public const uint ERROR_GRAPHICS_OPM_INVALID_ENCRYPTED_PARAMETERS = 0xC0262503;

		/// <summary>An array passed to a function cannot hold all of the data that the function wants to put in it.</summary>
		public const uint ERROR_GRAPHICS_OPM_PARAMETER_ARRAY_TOO_SMALL = 0xC0262504;

		/// <summary>The GDI display device passed to this function does not have any active video outputs.</summary>
		public const uint ERROR_GRAPHICS_OPM_NO_VIDEO_OUTPUTS_EXIST = 0xC0262505;

		/// <summary>The protected video path (PVP) cannot find an actual GDI display device that corresponds to the passed-in GDI display device name.</summary>
		public const uint ERROR_GRAPHICS_PVP_NO_DISPLAY_DEVICE_CORRESPONDS_TO_NAME = 0xC0262506;

		/// <summary>This function failed because the GDI display device passed to it was not attached to the Windows desktop.</summary>
		public const uint ERROR_GRAPHICS_PVP_DISPLAY_DEVICE_NOT_ATTACHED_TO_DESKTOP = 0xC0262507;

		/// <summary>The PVP does not support mirroring display devices because they do not have video outputs.</summary>
		public const uint ERROR_GRAPHICS_PVP_MIRRORING_DEVICES_NOT_SUPPORTED = 0xC0262508;

		/// <summary>The function failed because an invalid pointer parameter was passed to it. A pointer parameter is invalid if it is null, it points to an invalid address, it points to a kernel mode address, or it is not correctly aligned.</summary>
		public const uint ERROR_GRAPHICS_OPM_INVALID_POINTER = 0xC026250A;

		/// <summary>An internal error caused this operation to fail.</summary>
		public const uint ERROR_GRAPHICS_OPM_INTERNAL_ERROR = 0xC026250B;

		/// <summary>The function failed because the caller passed in an invalid OPM user mode handle.</summary>
		public const uint ERROR_GRAPHICS_OPM_INVALID_HANDLE = 0xC026250C;

		/// <summary>This function failed because the GDI device passed to it did not have any monitors associated with it.</summary>
		public const uint ERROR_GRAPHICS_PVP_NO_MONITORS_CORRESPOND_TO_DISPLAY_DEVICE = 0xC026250D;

		/// <summary>A certificate could not be returned because the certificate buffer passed to the function was too small.</summary>
		public const uint ERROR_GRAPHICS_PVP_INVALID_CERTIFICATE_LENGTH = 0xC026250E;

		/// <summary>A video output could not be created because the frame buffer is in spanning mode.</summary>
		public const uint ERROR_GRAPHICS_OPM_SPANNING_MODE_ENABLED = 0xC026250F;

		/// <summary>A video output could not be created because the frame buffer is in theater mode.</summary>
		public const uint ERROR_GRAPHICS_OPM_THEATER_MODE_ENABLED = 0xC0262510;

		/// <summary>The function call failed because the display adapter's hardware functionality scan failed to validate the graphics hardware.</summary>
		public const uint ERROR_GRAPHICS_PVP_HFS_FAILED = 0xC0262511;

		/// <summary>The High-Bandwidth Digital Content Protection (HDCP) System Renewability Message (SRM) passed to this function did not comply with section 5 of the HDCP 1.1 specification.</summary>
		public const uint ERROR_GRAPHICS_OPM_INVALID_SRM = 0xC0262512;

		/// <summary>The video output cannot enable the HDCP system because it does not support it.</summary>
		public const uint ERROR_GRAPHICS_OPM_OUTPUT_DOES_NOT_SUPPORT_HDCP = 0xC0262513;

		/// <summary>The video output cannot enable analog copy protection because it does not support it.</summary>
		public const uint ERROR_GRAPHICS_OPM_OUTPUT_DOES_NOT_SUPPORT_ACP = 0xC0262514;

		/// <summary>The video output cannot enable the Content Generation Management System Analog (CGMS-A) protection technology because it does not support it.</summary>
		public const uint ERROR_GRAPHICS_OPM_OUTPUT_DOES_NOT_SUPPORT_CGMSA = 0xC0262515;

		/// <summary>IOPMVideoOutput's GetInformation() method cannot return the version of the SRM being used because the application never successfully passed an SRM to the video output.</summary>
		public const uint ERROR_GRAPHICS_OPM_HDCP_SRM_NEVER_SET = 0xC0262516;

		/// <summary>IOPMVideoOutput's Configure() method cannot enable the specified output protection technology because the output's screen resolution is too high.</summary>
		public const uint ERROR_GRAPHICS_OPM_RESOLUTION_TOO_HIGH = 0xC0262517;

		/// <summary>IOPMVideoOutput's Configure() method cannot enable HDCP because the display adapter's HDCP hardware is already being used by other physical outputs.</summary>
		public const uint ERROR_GRAPHICS_OPM_ALL_HDCP_HARDWARE_ALREADY_IN_USE = 0xC0262518;

		/// <summary>The operating system asynchronously destroyed this OPM video output because the operating system's state changed. This error typically occurs because the monitor physical device object (PDO) associated with this video output was removed, the monitor PDO associated with this video output was stopped, the video output's session became a nonconsole session or the video output's desktop became an inactive desktop.</summary>
		public const uint ERROR_GRAPHICS_OPM_VIDEO_OUTPUT_NO_LONGER_EXISTS = 0xC0262519;

		/// <summary>IOPMVideoOutput's methods cannot be called when a session is changing its type. There are currently three types of sessions: console, disconnected and remote (remote desktop protocol [RDP] or Independent Computing Architecture [ICA]).</summary>
		public const uint ERROR_GRAPHICS_OPM_SESSION_TYPE_CHANGE_IN_PROGRESS = 0xC026251A;

		/// <summary>The monitor connected to the specified video output does not have an I2C bus.</summary>
		public const uint ERROR_GRAPHICS_I2C_NOT_SUPPORTED = 0xC0262580;

		/// <summary>No device on the I2C bus has the specified address.</summary>
		public const uint ERROR_GRAPHICS_I2C_DEVICE_DOES_NOT_EXIST = 0xC0262581;

		/// <summary>An error occurred while transmitting data to the device on the I2C bus.</summary>
		public const uint ERROR_GRAPHICS_I2C_ERROR_TRANSMITTING_DATA = 0xC0262582;

		/// <summary>An error occurred while receiving data from the device on the I2C bus.</summary>
		public const uint ERROR_GRAPHICS_I2C_ERROR_RECEIVING_DATA = 0xC0262583;

		/// <summary>The monitor does not support the specified Virtual Control Panel (VCP) code.</summary>
		public const uint ERROR_GRAPHICS_DDCCI_VCP_NOT_SUPPORTED = 0xC0262584;

		/// <summary>The data received from the monitor is invalid.</summary>
		public const uint ERROR_GRAPHICS_DDCCI_INVALID_DATA = 0xC0262585;

		/// <summary>A function call failed because a monitor returned an invalid Timing Status byte when the operating system used the Display Data Channel Command Interface (DDC/CI) Get Timing Report and Timing Message command to get a timing report from a monitor.</summary>
		public const uint ERROR_GRAPHICS_DDCCI_MONITOR_RETURNED_INVALID_TIMING_STATUS_BYTE = 0xC0262586;

		/// <summary>The monitor returned a DDC/CI capabilities string that did not comply with the ACCESS.bus 3.0, DDC/CI 1.1 or MCCS 2 Revision 1 specification.</summary>
		public const uint ERROR_GRAPHICS_MCA_INVALID_CAPABILITIES_STRING = 0xC0262587;

		/// <summary>An internal Monitor Configuration API error occurred.</summary>
		public const uint ERROR_GRAPHICS_MCA_INTERNAL_ERROR = 0xC0262588;

		/// <summary>An operation failed because a DDC/CI message had an invalid value in its command field.</summary>
		public const uint ERROR_GRAPHICS_DDCCI_INVALID_MESSAGE_COMMAND = 0xC0262589;

		/// <summary>This error occurred because a DDC/CI message length field contained an invalid value.</summary>
		public const uint ERROR_GRAPHICS_DDCCI_INVALID_MESSAGE_LENGTH = 0xC026258A;

		/// <summary>This error occurred because the value in a DDC/CI message checksum field did not match the message's computed checksum value. This error implies that the data was corrupted while it was being transmitted from a monitor to a computer.</summary>
		public const uint ERROR_GRAPHICS_DDCCI_INVALID_MESSAGE_CHECKSUM = 0xC026258B;

		/// <summary>The HMONITOR no longer exists, is not attached to the desktop, or corresponds to a mirroring device.</summary>
		public const uint ERROR_GRAPHICS_PMEA_INVALID_MONITOR = 0xC02625D6;

		/// <summary>The Direct3D (D3D) device's GDI display device no longer exists, is not attached to the desktop, or is a mirroring display device.</summary>
		public const uint ERROR_GRAPHICS_PMEA_INVALID_D3D_DEVICE = 0xC02625D7;

		/// <summary>A continuous VCP code's current value is greater than its maximum value. This error code indicates that a monitor returned an invalid value.</summary>
		public const uint ERROR_GRAPHICS_DDCCI_CURRENT_CURRENT_VALUE_GREATER_THAN_MAXIMUM_VALUE = 0xC02625D8;

		/// <summary>The monitor's VCP Version (0xDF) VCP code returned an invalid version value.</summary>
		public const uint ERROR_GRAPHICS_MCA_INVALID_VCP_VERSION = 0xC02625D9;

		/// <summary>The monitor does not comply with the Monitor Control Command Set (MCCS) specification it claims to support.</summary>
		public const uint ERROR_GRAPHICS_MCA_MONITOR_VIOLATES_MCCS_SPECIFICATION = 0xC02625DA;

		/// <summary>The MCCS version in a monitor's mccs_ver capability does not match the MCCS version the monitor reports when the VCP Version (0xDF) VCP code is used.</summary>
		public const uint ERROR_GRAPHICS_MCA_MCCS_VERSION_MISMATCH = 0xC02625DB;

		/// <summary>The Monitor Configuration API only works with monitors that support the MCCS 1.0 specification, the MCCS 2.0 specification, or the MCCS 2.0 Revision 1 specification.</summary>
		public const uint ERROR_GRAPHICS_MCA_UNSUPPORTED_MCCS_VERSION = 0xC02625DC;

		/// <summary>The monitor returned an invalid monitor technology type. CRT, plasma, and LCD (TFT) are examples of monitor technology types. This error implies that the monitor violated the MCCS 2.0 or MCCS 2.0 Revision 1 specification.</summary>
		public const uint ERROR_GRAPHICS_MCA_INVALID_TECHNOLOGY_TYPE_RETURNED = 0xC02625DE;

		/// <summary>The SetMonitorColorTemperature() caller passed a color temperature to it that the current monitor did not support. CRT, plasma, and LCD (TFT) are examples of monitor technology types. This error implies that the monitor violated the MCCS 2.0 or MCCS 2.0 Revision 1 specification.</summary>
		public const uint ERROR_GRAPHICS_MCA_UNSUPPORTED_COLOR_TEMPERATURE = 0xC02625DF;

		/// <summary>This function can be used only if a program is running in the local console session. It cannot be used if the program is running on a remote desktop session or on a terminal server session.</summary>
		public const uint ERROR_GRAPHICS_ONLY_CONSOLE_SESSION_SUPPORTED = 0xC02625E0;

		/// <summary>User responded "Yes" to the dialog.</summary>
		public const uint COPYENGINE_S_YES = 0x00270001;
		/// <summary>Undocumented.</summary>
		public const uint COPYENGINE_S_NOT_HANDLED = 0x00270003;
		/// <summary>User responded to retry the current action.</summary>
		public const uint COPYENGINE_S_USER_RETRY = 0x00270004;
		/// <summary>User responded "No" to the dialog.</summary>
		public const uint COPYENGINE_S_USER_IGNORED = 0x00270005;
		/// <summary>User responded to merge folders.</summary>
		public const uint COPYENGINE_S_MERGE = 0x00270006;
		/// <summary>Child items should not be processed.</summary>
		public const uint COPYENGINE_S_DONT_PROCESS_CHILDREN = 0x00270008;
		/// <summary>Undocumented.</summary>
		public const uint COPYENGINE_S_ALREADY_DONE = 0x0027000A;
		/// <summary>Error has been queued and will display later.</summary>
		public const uint COPYENGINE_S_PENDING = 0x0027000B;
		/// <summary>Undocumented.</summary>
		public const uint COPYENGINE_S_KEEP_BOTH = 0x0027000C;
		/// <summary>Close the program using the current file</summary>
		public const uint COPYENGINE_S_CLOSE_PROGRAM = 0x0027000D;
		/// <summary>User wants to canceled entire job</summary>
		public const uint COPYENGINE_E_USER_CANCELLED = 0x80270000;
		/// <summary>Engine wants to canceled entire job, don't set the CANCELLED bit</summary>
		public const uint COPYENGINE_E_CANCELLED = 0x80270001;
		/// <summary>Need to elevate the process to complete the operation</summary>
		public const uint COPYENGINE_E_REQUIRES_ELEVATION = 0x80270002;
		/// <summary>Source and destination file are the same</summary>
		public const uint COPYENGINE_E_SAME_FILE = 0x80270003;
		/// <summary>Trying to rename a file into a different location, use move instead</summary>
		public const uint COPYENGINE_E_DIFF_DIR = 0x80270004;
		/// <summary>One source specified, multiple destinations</summary>
		public const uint COPYENGINE_E_MANY_SRC_1_DEST = 0x80270005;
		/// <summary>The destination is a sub-tree of the source</summary>
		public const uint COPYENGINE_E_DEST_SUBTREE = 0x80270009;
		/// <summary>The destination is the same folder as the source</summary>
		public const uint COPYENGINE_E_DEST_SAME_TREE = 0x8027000A;
		/// <summary>Existing destination file with same name as folder</summary>
		public const uint COPYENGINE_E_FLD_IS_FILE_DEST = 0x8027000B;
		/// <summary>Existing destination folder with same name as file</summary>
		public const uint COPYENGINE_E_FILE_IS_FLD_DEST = 0x8027000C;
		/// <summary>File too large for destination file system</summary>
		public const uint COPYENGINE_E_FILE_TOO_LARGE = 0x8027000D;
		/// <summary>Destination device is full and happens to be removable</summary>
		public const uint COPYENGINE_E_REMOVABLE_FULL = 0x8027000E;
		/// <summary>Destination is a Read-Only CDRom, possibly unformatted</summary>
		public const uint COPYENGINE_E_DEST_IS_RO_CD = 0x8027000F;
		/// <summary>Destination is a Read/Write CDRom, possibly unformatted</summary>
		public const uint COPYENGINE_E_DEST_IS_RW_CD = 0x80270010;
		/// <summary>Destination is a Recordable (Audio, CDRom, possibly unformatted</summary>
		public const uint COPYENGINE_E_DEST_IS_R_CD = 0x80270011;
		/// <summary>Destination is a Read-Only DVD, possibly unformatted</summary>
		public const uint COPYENGINE_E_DEST_IS_RO_DVD = 0x80270012;
		/// <summary>Destination is a Read/Wrote DVD, possibly unformatted</summary>
		public const uint COPYENGINE_E_DEST_IS_RW_DVD = 0x80270013;
		/// <summary>Destination is a Recordable (Audio, DVD, possibly unformatted</summary>
		public const uint COPYENGINE_E_DEST_IS_R_DVD = 0x80270014;
		/// <summary>Source is a Read-Only CDRom, possibly unformatted</summary>
		public const uint COPYENGINE_E_SRC_IS_RO_CD = 0x80270015;
		/// <summary>Source is a Read/Write CDRom, possibly unformatted</summary>
		public const uint COPYENGINE_E_SRC_IS_RW_CD = 0x80270016;
		/// <summary>Source is a Recordable (Audio, CDRom, possibly unformatted</summary>
		public const uint COPYENGINE_E_SRC_IS_R_CD = 0x80270017;
		/// <summary>Source is a Read-Only DVD, possibly unformatted</summary>
		public const uint COPYENGINE_E_SRC_IS_RO_DVD = 0x80270018;
		/// <summary>Source is a Read/Wrote DVD, possibly unformatted</summary>
		public const uint COPYENGINE_E_SRC_IS_RW_DVD = 0x80270019;
		/// <summary>Source is a Recordable (Audio, DVD, possibly unformatted</summary>
		public const uint COPYENGINE_E_SRC_IS_R_DVD = 0x8027001A;
		/// <summary>Invalid source path</summary>
		public const uint COPYENGINE_E_INVALID_FILES_SRC = 0x8027001B;
		/// <summary>Invalid destination path</summary>
		public const uint COPYENGINE_E_INVALID_FILES_DEST = 0x8027001C;
		/// <summary>Source Files within folders where the overall path is longer than MAX_PATH</summary>
		public const uint COPYENGINE_E_PATH_TOO_DEEP_SRC = 0x8027001D;
		/// <summary>Destination files would be within folders where the overall path is longer than MAX_PATH</summary>
		public const uint COPYENGINE_E_PATH_TOO_DEEP_DEST = 0x8027001E;
		/// <summary>Source is a root directory, cannot be moved or renamed</summary>
		public const uint COPYENGINE_E_ROOT_DIR_SRC = 0x8027001F;
		/// <summary>Destination is a root directory, cannot be renamed</summary>
		public const uint COPYENGINE_E_ROOT_DIR_DEST = 0x80270020;
		/// <summary>Security problem on source</summary>
		public const uint COPYENGINE_E_ACCESS_DENIED_SRC = 0x80270021;
		/// <summary>Security problem on destination</summary>
		public const uint COPYENGINE_E_ACCESS_DENIED_DEST = 0x80270022;
		/// <summary>Source file does not exist, or is unavailable</summary>
		public const uint COPYENGINE_E_PATH_NOT_FOUND_SRC = 0x80270023;
		/// <summary>Destination file does not exist, or is unavailable</summary>
		public const uint COPYENGINE_E_PATH_NOT_FOUND_DEST = 0x80270024;
		/// <summary>Source file is on a disconnected network location</summary>
		public const uint COPYENGINE_E_NET_DISCONNECT_SRC = 0x80270025;
		/// <summary>Destination file is on a disconnected network location</summary>
		public const uint COPYENGINE_E_NET_DISCONNECT_DEST = 0x80270026;
		/// <summary>Sharing Violation on source</summary>
		public const uint COPYENGINE_E_SHARING_VIOLATION_SRC = 0x80270027;
		/// <summary>Sharing Violation on destination</summary>
		public const uint COPYENGINE_E_SHARING_VIOLATION_DEST = 0x80270028;
		/// <summary>Destination exists, cannot replace</summary>
		public const uint COPYENGINE_E_ALREADY_EXISTS_NORMAL = 0x80270029;
		/// <summary>Destination with read-only attribute exists, cannot replace</summary>
		public const uint COPYENGINE_E_ALREADY_EXISTS_READONLY = 0x8027002A;
		/// <summary>Destination with system attribute exists, cannot replace</summary>
		public const uint COPYENGINE_E_ALREADY_EXISTS_SYSTEM = 0x8027002B;
		/// <summary>Destination folder exists, cannot replace</summary>
		public const uint COPYENGINE_E_ALREADY_EXISTS_FOLDER = 0x8027002C;
		/// <summary>Secondary Stream information would be lost</summary>
		public const uint COPYENGINE_E_STREAM_LOSS = 0x8027002D;
		/// <summary>Extended Attributes would be lost</summary>
		public const uint COPYENGINE_E_EA_LOSS = 0x8027002E;
		/// <summary>Property would be lost</summary>
		public const uint COPYENGINE_E_PROPERTY_LOSS = 0x8027002F;
		/// <summary>Properties would be lost</summary>
		public const uint COPYENGINE_E_PROPERTIES_LOSS = 0x80270030;
		/// <summary>Encryption would be lost</summary>
		public const uint COPYENGINE_E_ENCRYPTION_LOSS = 0x80270031;
		/// <summary>Entire operation likely won't fit</summary>
		public const uint COPYENGINE_E_DISK_FULL = 0x80270032;
		/// <summary>Entire operation likely won't fit, clean-up wizard available</summary>
		public const uint COPYENGINE_E_DISK_FULL_CLEAN = 0x80270033;
		/// <summary>Can't reach source folder")</summary>
		public const uint COPYENGINE_E_CANT_REACH_SOURCE = 0x80270035;
		/// <summary>???</summary>
		public const uint COPYENGINE_E_RECYCLE_UNKNOWN_ERROR = 0x80270035;
		/// <summary>Recycling not available (usually turned off,</summary>
		public const uint COPYENGINE_E_RECYCLE_FORCE_NUKE = 0x80270036;
		/// <summary>Item is too large for the recycle-bin</summary>
		public const uint COPYENGINE_E_RECYCLE_SIZE_TOO_BIG = 0x80270037;
		/// <summary>Folder is too deep to fit in the recycle-bin</summary>
		public const uint COPYENGINE_E_RECYCLE_PATH_TOO_LONG = 0x80270038;
		/// <summary>Recycle bin could not be found or is unavailable</summary>
		public const uint COPYENGINE_E_RECYCLE_BIN_NOT_FOUND = 0x8027003A;
		/// <summary>Name of the new file being created is too long</summary>
		public const uint COPYENGINE_E_NEWFILE_NAME_TOO_LONG = 0x8027003B;
		/// <summary>Name of the new folder being created is too long</summary>
		public const uint COPYENGINE_E_NEWFOLDER_NAME_TOO_LONG = 0x8027003C;
		/// <summary>The directory being processed is not empty</summary>
		public const uint COPYENGINE_E_DIR_NOT_EMPTY = 0x8027003D;
	}
}