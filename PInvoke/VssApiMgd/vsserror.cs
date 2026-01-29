namespace Vanara.PInvoke.VssApi;

/// <summary>VSS error codes.</summary>
public enum VSS_ERROR : int
{
	/// <summary>A function call was made when the object was in an incorrect state for that function</summary>
	VSS_E_BAD_STATE = unchecked((int)0x80042301),

	/// <summary>A Volume Shadow Copy Service component encountered an unexpected error. Check the Application event log for more information.</summary>
	VSS_E_UNEXPECTED = unchecked((int)0x80042302),

	/// <summary>The provider has already been registered.</summary>
	VSS_E_PROVIDER_ALREADY_REGISTERED = unchecked((int)0x80042303),

	/// <summary>The volume shadow copy provider is not registered in the system.</summary>
	VSS_E_PROVIDER_NOT_REGISTERED = unchecked((int)0x80042304),

	/// <summary>The shadow copy provider had an error. Check the System and Application event logs for more information.</summary>
	VSS_E_PROVIDER_VETO = unchecked((int)0x80042306),

	/// <summary>The shadow copy provider is currently in use and cannot be unregistered.</summary>
	VSS_E_PROVIDER_IN_USE = unchecked((int)0x80042307),

	/// <summary>The specified object was not found.</summary>
	VSS_E_OBJECT_NOT_FOUND = unchecked((int)0x80042308),

	/// <summary>The asynchronous operation is pending.</summary>
	VSS_S_ASYNC_PENDING = 0x00042309,

	/// <summary>The asynchronous operation has completed.</summary>
	VSS_S_ASYNC_FINISHED = 0x0004230A,

	/// <summary>The asynchronous operation has been cancelled.</summary>
	VSS_S_ASYNC_CANCELLED = 0x0004230B,

	/// <summary>Shadow copying the specified volume is not supported.</summary>
	VSS_E_VOLUME_NOT_SUPPORTED = unchecked((int)0x8004230C),

	/// <summary>The given shadow copy provider does not support shadow copying the specified volume.</summary>
	VSS_E_VOLUME_NOT_SUPPORTED_BY_PROVIDER = unchecked((int)0x8004230E),

	/// <summary>The object already exists.</summary>
	VSS_E_OBJECT_ALREADY_EXISTS = unchecked((int)0x8004230D),

	/// <summary>The shadow copy provider had an unexpected error while trying to process the specified operation.</summary>
	VSS_E_UNEXPECTED_PROVIDER_ERROR = unchecked((int)0x8004230F),

	/// <summary>The given XML document is invalid.  It is either incorrectly-formed XML or it does not match the schema.  This error code is deprecated.</summary>
	VSS_E_CORRUPT_XML_DOCUMENT = unchecked((int)0x80042310),

	/// <summary>The given XML document is invalid.  It is either incorrectly-formed XML or it does not match the schema.</summary>
	VSS_E_INVALID_XML_DOCUMENT = unchecked((int)0x80042311),

	/// <summary>The maximum number of volumes for this operation has been reached.</summary>
	VSS_E_MAXIMUM_NUMBER_OF_VOLUMES_REACHED = unchecked((int)0x80042312),

	/// <summary>The shadow copy provider timed out while flushing data to the volume being shadow copied. This is probably due to excessive activity on the volume. Try again later when the volume is not being used so heavily.</summary>
	VSS_E_FLUSH_WRITES_TIMEOUT = unchecked((int)0x80042313),

	/// <summary>The shadow copy provider timed out while holding writes to the volume being shadow copied. This is probably due to excessive activity on the volume by an application or a system service. Try again later when activity on the volume is reduced.</summary>
	VSS_E_HOLD_WRITES_TIMEOUT = unchecked((int)0x80042314),

	/// <summary>VSS encountered problems while sending events to writers.</summary>
	VSS_E_UNEXPECTED_WRITER_ERROR = unchecked((int)0x80042315),

	/// <summary>Another shadow copy creation is already in progress. Wait a few moments and try again.</summary>
	VSS_E_SNAPSHOT_SET_IN_PROGRESS = unchecked((int)0x80042316),

	/// <summary>The specified volume has already reached its maximum number of shadow copies.</summary>
	VSS_E_MAXIMUM_NUMBER_OF_SNAPSHOTS_REACHED = unchecked((int)0x80042317),

	/// <summary>An error was detected in the Volume Shadow Copy Service (VSS). The problem occurred while trying to contact VSS writers. Verify that the Event System service and the VSS service are running and check for associated errors in the event logs.</summary>
	VSS_E_WRITER_INFRASTRUCTURE = unchecked((int)0x80042318),

	/// <summary>A writer did not respond to a GatherWriterStatus call.  The writer may either have terminated or it may be stuck.  Check the System and Application event logs for more information.</summary>
	VSS_E_WRITER_NOT_RESPONDING = unchecked((int)0x80042319),

	/// <summary>The writer has already successfully called the Subscribe function.  It cannot call Subscribe multiple times.</summary>
	VSS_E_WRITER_ALREADY_SUBSCRIBED = unchecked((int)0x8004231A),

	/// <summary>The shadow copy provider does not support the specified shadow copy type.</summary>
	VSS_E_UNSUPPORTED_CONTEXT = unchecked((int)0x8004231B),

	/// <summary>The specified shadow copy storage association is in use and so can't be deleted.</summary>
	VSS_E_VOLUME_IN_USE = unchecked((int)0x8004231D),

	/// <summary>Maximum number of shadow copy storage associations already reached.</summary>
	VSS_E_MAXIMUM_DIFFAREA_ASSOCIATIONS_REACHED = unchecked((int)0x8004231E),

	/// <summary>Insufficient storage available to create either the shadow copy storage file or other shadow copy data.</summary>
	VSS_E_INSUFFICIENT_STORAGE = unchecked((int)0x8004231F),

	/// <summary>No shadow copies were successfully imported.</summary>
	VSS_E_NO_SNAPSHOTS_IMPORTED = unchecked((int)0x80042320),

	/// <summary>Some shadow copies were not successfully imported.</summary>
	VSS_S_SOME_SNAPSHOTS_NOT_IMPORTED = 0x00042321,

	/// <summary>Some shadow copies were not successfully imported.</summary>
	VSS_E_SOME_SNAPSHOTS_NOT_IMPORTED = unchecked((int)0x80042321),

	/// <summary>The maximum number of remote machines for this operation has been reached.</summary>
	VSS_E_MAXIMUM_NUMBER_OF_REMOTE_MACHINES_REACHED = unchecked((int)0x80042322),

	/// <summary>The remote server is unavailable.</summary>
	VSS_E_REMOTE_SERVER_UNAVAILABLE = unchecked((int)0x80042323),

	/// <summary>The remote server is running a version of the Volume Shadow Copy Service that does not support remote shadow-copy creation.</summary>
	VSS_E_REMOTE_SERVER_UNSUPPORTED = unchecked((int)0x80042324),

	/// <summary>A revert is currently in progress for the specified volume.  Another revert cannot be initiated until the current revert completes.</summary>
	VSS_E_REVERT_IN_PROGRESS = unchecked((int)0x80042325),

	/// <summary>The volume being reverted was lost during revert.</summary>
	VSS_E_REVERT_VOLUME_LOST = unchecked((int)0x80042326),

	/// <summary>A reboot is required after completing this operation.</summary>
	VSS_E_REBOOT_REQUIRED = unchecked((int)0x80042327),

	/// <summary>A timeout occurred while freezing a transaction manager.</summary>
	VSS_E_TRANSACTION_FREEZE_TIMEOUT = unchecked((int)0x80042328),

	/// <summary>Too much time elapsed between freezing a transaction manager and thawing the transaction manager.</summary>
	VSS_E_TRANSACTION_THAW_TIMEOUT = unchecked((int)0x80042329),

	/// <summary>The volume being backed up is not mounted on the local host.</summary>
	VSS_E_VOLUME_NOT_LOCAL = unchecked((int)0x8004232D),

	/// <summary>A timeout occurred while preparing a cluster shared volume for backup.</summary>
	VSS_E_CLUSTER_TIMEOUT = unchecked((int)0x8004232E),

	/// <summary>The shadow-copy set only contains only a subset of the volumes needed to correctly backup the selected components of the writer.</summary>
	VSS_E_WRITERERROR_INCONSISTENTSNAPSHOT = unchecked((int)0x800423F0),

	/// <summary>A resource allocation failed while processing this operation.</summary>
	VSS_E_WRITERERROR_OUTOFRESOURCES = unchecked((int)0x800423F1),

	/// <summary>The writer's timeout expired between the Freeze and Thaw events.</summary>
	VSS_E_WRITERERROR_TIMEOUT = unchecked((int)0x800423F2),

	/// <summary>The writer experienced a transient error.  If the backup process is retried, the error may not reoccur.</summary>
	VSS_E_WRITERERROR_RETRYABLE = unchecked((int)0x800423F3),

	/// <summary>The writer experienced a non-transient error.  If the backup process is retried, the error is likely to reoccur.</summary>
	VSS_E_WRITERERROR_NONRETRYABLE = unchecked((int)0x800423F4),

	/// <summary>The writer experienced an error while trying to recover the shadow-copy volume.</summary>
	VSS_E_WRITERERROR_RECOVERY_FAILED = unchecked((int)0x800423F5),

	/// <summary>The shadow copy set break operation failed because the disk/partition identities could not be reverted. The target identity already exists on the machine or cluster and must be masked before this operation can succeed.</summary>
	VSS_E_BREAK_REVERT_ID_FAILED = unchecked((int)0x800423F6),

	/// <summary>This version of the hardware provider does not support this operation.</summary>
	VSS_E_LEGACY_PROVIDER = unchecked((int)0x800423F7),

	/// <summary>An expected disk did not arrive in the system.</summary>
	VSS_E_MISSING_DISK = unchecked((int)0x800423F8),

	/// <summary>An expected hidden volume did not arrive in the system. Check the Application event log for more information.</summary>
	VSS_E_MISSING_HIDDEN_VOLUME = unchecked((int)0x800423F9),

	/// <summary>An expected volume did not arrive in the system. Check the Application event log for more information.</summary>
	VSS_E_MISSING_VOLUME = unchecked((int)0x800423FA),

	/// <summary>The autorecovery operation failed to complete on the shadow copy.</summary>
	VSS_E_AUTORECOVERY_FAILED = unchecked((int)0x800423FB),

	/// <summary>An error occurred in processing the dynamic disks involved in the operation.</summary>
	VSS_E_DYNAMIC_DISK_ERROR = unchecked((int)0x800423FC),

	/// <summary>The given Backup Components Document is for a non-transportable shadow copy. This operation can only be done on transportable shadow copies.</summary>
	VSS_E_NONTRANSPORTABLE_BCD = unchecked((int)0x800423FD),

	/// <summary>The MBR signature or GPT ID for one or more disks could not be set to the intended value. Check the Application event log for more information.</summary>
	VSS_E_CANNOT_REVERT_DISKID = unchecked((int)0x800423FE),

	/// <summary>The LUN resynchronization operation could not be started because another resynchronization operation is already in progress.</summary>
	VSS_E_RESYNC_IN_PROGRESS = unchecked((int)0x800423FF),

	/// <summary>The clustered disks could not be enumerated or could not be put into cluster maintenance mode. Check the System event log for cluster related events and the Application event log for VSS related events.</summary>
	VSS_E_CLUSTER_ERROR = unchecked((int)0x80042400),

	/// <summary>The requested operation would overwrite a volume that is not explicitly selected. For more information, check the Application event log.</summary>
	VSS_E_UNSELECTED_VOLUME = unchecked((int)0x8004232A),

	/// <summary>The shadow copy ID was not found in the backup components document for the shadow copy set.</summary>
	VSS_E_SNAPSHOT_NOT_IN_SET = unchecked((int)0x8004232B),

	/// <summary>The specified volume is nested too deeply to participate in the VSS operation.</summary>
	VSS_E_NESTED_VOLUME_LIMIT = unchecked((int)0x8004232C),

	/// <summary>The requested operation is not supported.</summary>
	VSS_E_NOT_SUPPORTED = unchecked((int)0x8004232F),

	/// <summary>The writer experienced a partial failure. Check the component level error state for more information.</summary>
	VSS_E_WRITERERROR_PARTIAL_FAILURE = unchecked((int)0x80042336),

	/// <summary>There are too few disks on this computer or one or more of the disks is too small. Add or change disks so they match the disks in the backup, and try the restore again.</summary>
	VSS_E_ASRERROR_DISK_ASSIGNMENT_FAILED = unchecked((int)0x80042401),

	/// <summary>Windows cannot create a disk on this computer needed to restore from the backup. Make sure the disks are properly connected, or add or change disks, and try the restore again.</summary>
	VSS_E_ASRERROR_DISK_RECREATION_FAILED = unchecked((int)0x80042402),

	/// <summary>The computer needs to be restarted to finish preparing a hard disk for restore. To continue, restart your computer and run the restore again.</summary>
	VSS_E_ASRERROR_NO_ARCPATH = unchecked((int)0x80042403),

	/// <summary>The backup failed due to a missing disk for a dynamic volume. Ensure the disk is online and retry the backup.</summary>
	VSS_E_ASRERROR_MISSING_DYNDISK = unchecked((int)0x80042404),

	/// <summary>Automated System Recovery failed the shadow copy, because a selected critical volume is located on a cluster shared disk. This is an unsupported configuration.</summary>
	VSS_E_ASRERROR_SHARED_CRIDISK = unchecked((int)0x80042405),

	/// <summary>A data disk is currently set as active in BIOS. Set some other disk as active or use the DiskPart utility to clean the data disk, and then retry the restore operation.</summary>
	VSS_E_ASRERROR_DATADISK_RDISK0 = unchecked((int)0x80042406),

	/// <summary>The disk that is set as active in BIOS is too small to recover the original system disk. Replace the disk with a larger one and retry the restore operation.</summary>
	VSS_E_ASRERROR_RDISK0_TOOSMALL = unchecked((int)0x80042407),

	/// <summary>Failed to find enough suitable disks for recreating all critical disks. The number of available disks should be same or greater than the number of critical disks at time of backup, and each one of the disks must be of same or greater size.</summary>
	VSS_E_ASRERROR_CRITICAL_DISKS_TOO_SMALL = unchecked((int)0x80042408),

	/// <summary>Writer status is not available for one or more writers.  A writer may have reached the limit to the number of available backup-restore session states.</summary>
	VSS_E_WRITER_STATUS_NOT_AVAILABLE = unchecked((int)0x80042409),

	/// <summary>A critical dynamic disk is a Virtual Hard Disk (VHD). This is an unsupported configuration. Check the Application event log for more details.</summary>
	VSS_E_ASRERROR_DYNAMIC_VHD_NOT_SUPPORTED = unchecked((int)0x8004240A),

	/// <summary>A critical volume selected for backup exists on a disk which cannot be backed up by ASR.</summary>
	VSS_E_CRITICAL_VOLUME_ON_INVALID_DISK = unchecked((int)0x80042411),

	/// <summary>
	/// <para>No disk that can be used for recovering the system disk can be found.</para>
	/// <para>Try the following:</para>
	/// <list type="number">
	/// <item>A probable system disk may have been excluded by mistake.</item>
	/// <list type="number">
	/// <item>Review the list of disks that you have excluded from the recovery for a likely disk.</item>
	/// <item>
	/// Type LIST DISK command in the DISKPART command interpreter. The probable system disk is usually the first disk listed in the results.
	/// </item>
	/// <item>If possible, remove the disk from the exclusion list and then retry the recovery.</item>
	/// </list>
	/// <item>A USB disk may have been assigned as a system disk.</item>
	/// <list type="number">
	/// <item>Detach all USB disks from the computer.</item>
	/// <item>Reboot into Windows Recovery Environment (Win RE), then reattach USB disks and retry the recovery.</item>
	/// </list>
	/// <item>An invalid disk may have been assigned as system disk.</item>
	/// <list type="number">
	/// <item>Physically detach the disk from your computer. Then boot into Win RE to retry the recovery.</item>
	/// </list>
	/// </list>
	/// </summary>
	VSS_E_ASRERROR_RDISK_FOR_SYSTEM_DISK_NOT_FOUND = unchecked((int)0x80042412),

	/// <summary>Windows did not find any fixed disk that can be used to recreate volumes present in backup. Ensure disks are online, and disk drivers are installed to access the disk(s). 'diskpart.exe' tool with list disks command can be used to see the list of available fixed disks on the system.</summary>
	VSS_E_ASRERROR_NO_PHYSICAL_DISK_AVAILABLE = unchecked((int)0x80042413),

	/// <summary>Windows did not find any disk which it can use for recreating volumes present in backup. Offline disks, cluster shared disks or disks explicitly excluded by user will not be used by Windows. Ensure that disks are online and no disks are excluded by mistake.</summary>
	VSS_E_ASRERROR_FIXED_PHYSICAL_DISK_AVAILABLE_AFTER_DISK_EXCLUSION = unchecked((int)0x80042414),

	/// <summary>Restore failed because a disk which was critical at backup is excluded. To continue you need to either remove the disk from exclusion list or detach it from machine or clean it using DiskPart utility, and then retry restore. If you cannot clean or detach it then change the disk signature using DiskPart command UNIQUEID DISK ID.</summary>
	VSS_E_ASRERROR_CRITICAL_DISK_CANNOT_BE_EXCLUDED = unchecked((int)0x80042415),

	/// <summary>System partition (partition marked "active") is hidden or contains an unrecognized file system. Backup does not support this configuration.</summary>
	VSS_E_ASRERROR_SYSTEM_PARTITION_HIDDEN = unchecked((int)0x80042416),

	/// <summary>A timeout occurred while preparing a file share shadowcopy for backup.</summary>
	VSS_E_FSS_TIMEOUT = unchecked((int)0x80042417),

}
