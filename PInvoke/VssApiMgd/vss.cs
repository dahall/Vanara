using System;
using System.Runtime.InteropServices;
using Vanara.Collections;
using Vanara.InteropServices;
using FILETIME = System.Runtime.InteropServices.ComTypes.FILETIME;

namespace Vanara.PInvoke.VssApi
{
	/// <summary>
	/// <para>
	/// The <c>VSS_APPLICATION_LEVEL</c> enumeration indicates the application level, the point in the course of the creation of a shadow
	/// copy that a writer is notified of a freeze.
	/// </para>
	/// <para>
	/// VSS first sends a Freeze event to writers initialized with <c>VSS_APP_FRONT_END</c> (called front-end level applications), then to
	/// writers initialized with <c>VSS_APP_BACK_END</c> (called back-end level applications), and finally to writers initialized with
	/// <c>VSS_APP_SYSTEM</c> (called system-level applications).
	/// </para>
	/// </summary>
	/// <remarks>
	/// <para>
	/// <c>VSS_APPLICATION_LEVEL</c> is provided to allow application developers to control at what point a writer will receive a Freeze
	/// event. This may be important if one writer uses or depends on another writer.
	/// </para>
	/// <para>
	/// For instance, if an application X is storing data using application Y as an intermediate layer (for example, if Y implements a
	/// database used by X), we would describe X as a front-end application, and Y as a back-end application.
	/// </para>
	/// <para>
	/// In this example, when freezing applications that participate in a shadow copy, you would want X (the front-end application) to
	/// suspend its writes to the database prior to freezing Y (the back-end application), the database service itself.
	/// </para>
	/// <para>The application level of a writer is set by CVssWriter::Initialize and retrieved by CVssWriter::GetCurrentLevel.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/vss/ne-vss-vss_application_level typedef enum _VSS_APPLICATION_LEVEL {
	// VSS_APP_UNKNOWN, VSS_APP_SYSTEM, VSS_APP_BACK_END, VSS_APP_FRONT_END, VSS_APP_SYSTEM_RM, VSS_APP_AUTO } VSS_APPLICATION_LEVEL, *PVSS_APPLICATION_LEVEL;
	[PInvokeData("vss.h", MSDNShortId = "NE:vss._VSS_APPLICATION_LEVEL")]
	public enum VSS_APPLICATION_LEVEL
	{
		/// <summary>
		/// <para>The level at which this writer's freeze state will occur is not known. This indicates an application</para>
		/// <para>error.</para>
		/// </summary>
		VSS_APP_UNKNOWN,

		/// <summary>This writer freeze state will occur at the system application level.</summary>
		VSS_APP_SYSTEM,

		/// <summary>This writer freeze state will occur at the back-end application level.</summary>
		VSS_APP_BACK_END,

		/// <summary>This writer freeze state will occur at the front-end application level.</summary>
		VSS_APP_FRONT_END,

		/// <summary/>
		VSS_APP_SYSTEM_RM,

		/// <summary>
		/// <para>This writer freeze state will be determined automatically. This enumeration value is reserved for future</para>
		/// <para>use.</para>
		/// </summary>
		VSS_APP_AUTO = -1,
	}

	/// <summary>
	/// The <c>VSS_BACKUP_SCHEMA</c> enumeration is used by a writer to indicate the types of backup operations it can participate in. The
	/// supported kinds of backup are expressed as a bit mask (or bitwise OR) of <c>VSS_BACKUP_SCHEMA</c> values.
	/// </summary>
	/// <remarks>
	/// <para>Writer set their backup schemas with calls to IVssCreateWriterMetadata::SetBackupSchema.</para>
	/// <para>Requesters use IVssExamineWriterMetadata::GetBackupSchema to determine the backup schema that a writer supports.</para>
	/// <para>
	/// For a specific kind of backup operation to be supported, the writer must support the corresponding schema, and the requester must
	/// set the corresponding backup type.
	/// </para>
	/// <para>
	/// For example, to involve a writer in an incremental backup operation, the requester must set the backup type to
	/// <c>VSS_BT_INCREMENTAL</c>, and the writer should have a backup schema that includes <c>VSS_BS_INCREMENTAL</c>.
	/// </para>
	/// <para>
	/// A writer that does not support the backup schema corresponding to a requester's backup type should treat the backup operation that
	/// is being performed as if it were a default (full) backup. If the desired backup type is not supported by the writer's backup schema,
	/// the requester can either perform a full backup for this writer or exclude the writer from the backup operation. A requester can
	/// exclude a writer by selecting none of the writer's components (see Working with Selectability and Logical Paths), or by disabling
	/// the writer (see IVssBackupComponents::DisableWriterClasses or IVssBackupComponents::DisableWriterInstances).
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/vss/ne-vss-vss_backup_schema typedef enum _VSS_BACKUP_SCHEMA { VSS_BS_UNDEFINED,
	// VSS_BS_DIFFERENTIAL, VSS_BS_INCREMENTAL, VSS_BS_EXCLUSIVE_INCREMENTAL_DIFFERENTIAL, VSS_BS_LOG, VSS_BS_COPY, VSS_BS_TIMESTAMPED,
	// VSS_BS_LAST_MODIFY, VSS_BS_LSN, VSS_BS_WRITER_SUPPORTS_NEW_TARGET, VSS_BS_WRITER_SUPPORTS_RESTORE_WITH_MOVE,
	// VSS_BS_INDEPENDENT_SYSTEM_STATE, VSS_BS_ROLLFORWARD_RESTORE, VSS_BS_RESTORE_RENAME, VSS_BS_AUTHORITATIVE_RESTORE,
	// VSS_BS_WRITER_SUPPORTS_PARALLEL_RESTORES } VSS_BACKUP_SCHEMA, *PVSS_BACKUP_SCHEMA;
	[PInvokeData("vss.h", MSDNShortId = "NE:vss._VSS_BACKUP_SCHEMA")]
	[Flags]
	public enum VSS_BACKUP_SCHEMA
	{
		/// <summary>
		/// <para>The writer supports a simple full backup and restoration of entire files (as defined by a</para>
		/// <para>VSS_BACKUP_TYPE</para>
		/// <para>value of</para>
		/// <para>VSS_BT_FULL</para>
		/// <para>). This backup scheme can be used as the basis of an incremental or</para>
		/// <para>differential backup. This is the default value.</para>
		/// </summary>
		VSS_BS_UNDEFINED = 0,

		/// <summary>
		/// <para>The writer supports differential backups (corresponding to the</para>
		/// <para>VSS_BACKUP_TYPE</para>
		/// <para>value</para>
		/// <para>VSS_BT_DIFFERENTIAL</para>
		/// <para>). Files created or changed since the last full backup are saved.</para>
		/// <para>Files are not marked as having been backed up.</para>
		/// <para>This setting does not preclude mixing of incremental and differential backups.</para>
		/// <para>This value is not supported for express writers.</para>
		/// </summary>
		VSS_BS_DIFFERENTIAL = 0x0001,

		/// <summary>
		/// <para>The writer supports incremental backups (corresponding to the</para>
		/// <para>VSS_BACKUP_TYPE</para>
		/// <para>value</para>
		/// <para>VSS_BT_INCREMENTAL</para>
		/// <para>). Files created or changed since the last full or incremental</para>
		/// <para>backup are saved. Files are marked as having been backed up.</para>
		/// <para>This setting does not preclude mixing of incremental and differential backups.</para>
		/// <para>This value is not supported for express writers.</para>
		/// </summary>
		VSS_BS_INCREMENTAL = 0x0002,

		/// <summary>
		/// <para>The writer supports both differential and incremental backup schemas, but only exclusively: for example,</para>
		/// <para>you cannot follow a differential backup with an incremental one. A writer cannot support this schema if it does</para>
		/// <para>not support both incremental and differential schemas (</para>
		/// <para>VSS_BS_DIFFERENTIAL</para>
		/// </summary>
		VSS_BS_EXCLUSIVE_INCREMENTAL_DIFFERENTIAL = 0x0004,

		/// <summary>
		/// <para>The writer supports backups that involve only the log files it manages (corresponding to a</para>
		/// <para>VSS_BACKUP_TYPE</para>
		/// <para>value of</para>
		/// <para>VSS_BT_LOG</para>
		/// <para>). This schema requires a writer to have added at least one file to at</para>
		/// <para>least one component using the</para>
		/// <para>IVssCreateWriterMetadata::AddDataBaseLogFiles</para>
		/// <para>method. Requesters retrieve log file information using the</para>
		/// <para>IVssWMComponent::GetDatabaseLogFile</para>
		/// <para>method.</para>
		/// </summary>
		VSS_BS_LOG = 0x0008,

		/// <summary>
		/// <para>Similar to the default backup schema (</para>
		/// <para>VSS_BT_UNDEFINED</para>
		/// <para>), the writer supports</para>
		/// <para>copy backup operations (corresponding to</para>
		/// <para>VSS_BT_COPY</para>
		/// <para>) where file access information</para>
		/// <para>(such as information as to when a file was last backed up) will not be updated either in the writer's own state</para>
		/// <para>information or in the file system information. This type of backup cannot be used as the basis of an incremental</para>
		/// <para>or differential backup.</para>
		/// </summary>
		VSS_BS_COPY = 0x0010,

		/// <summary>
		/// <para>A writer supports using the VSS time-stamp mechanism when evaluating if a file should be included in</para>
		/// <para>differential or incremental operations (corresponding to</para>
		/// <para>VSS_BT_DIFFERENTIAL</para>
		/// <para>and</para>
		/// <para>VSS_BT_INCREMENTAL</para>
		/// <para>, respectively) using the</para>
		/// <para>IVssComponent::GetBackupStamp</para>
		/// <para>,</para>
		/// <para>IVssComponent::GetPreviousBackupStamp</para>
		/// <para>,</para>
		/// <para>IVssComponent::SetBackupStamp</para>
		/// <para>, and</para>
		/// <para>IVssBackupComponents::SetPreviousBackupStamp</para>
		/// <para>methods.</para>
		/// <para>A writer cannot support this schema if it does not support either differential or incremental backup schemas</para>
		/// <para>(</para>
		/// <para>VSS_BS_DIFFERENTIAL</para>
		/// <para>or</para>
		/// <para>VSS_BS_INCREMENTAL</para>
		/// <para>).</para>
		/// <para>This value is not supported for express writers.</para>
		/// </summary>
		VSS_BS_TIMESTAMPED = 0x0020,

		/// <summary>
		/// <para>When implementing incremental or differential backups with differenced files, a writer can provide last</para>
		/// <para>modification time information for files (using</para>
		/// <para>IVssComponent::AddDifferencedFilesByLastModifyTime</para>
		/// <para>).</para>
		/// <para>A requester then can use</para>
		/// <para>IVssComponent::GetDifferencedFile</para>
		/// <para>to</para>
		/// <para>obtain candidate files and information about their last modification data. The requester can use this</para>
		/// <para>information (along with any records about previous backup operations it maintains) to decide if a file should be</para>
		/// <para>included in incremental and differential backups.</para>
		/// <para>This scheme does not apply to partial file implementations of incremental and differential backup</para>
		/// <para>operations.</para>
		/// <para>A writer cannot support this schema if it does not support either incremental or differential backup schemas</para>
		/// <para>(</para>
		/// <para>VSS_BS_DIFFERENTIAL</para>
		/// <para>or</para>
		/// <para>VSS_BS_INCREMENTAL</para>
		/// <para>).</para>
		/// <para>This value is not supported for express writers.</para>
		/// </summary>
		VSS_BS_LAST_MODIFY = 0x0040,

		/// <summary>Reserved for system use.</summary>
		VSS_BS_LSN = 0x0080,

		/// <summary>
		/// <para>The writer supports a requester changing the target for file restoration using</para>
		/// <para>IVssBackupComponents::AddNewTarget</para>
		/// <para>.</para>
		/// <para>(See</para>
		/// <para>Non-Default Backup And Restore Locations</para>
		/// <para>for more information.)</para>
		/// <para>This value is not supported for express writers.</para>
		/// </summary>
		VSS_BS_WRITER_SUPPORTS_NEW_TARGET = 0x0100,

		/// <summary>
		/// <para>
		/// The writer supports running multiple writer instances with the same class ID, and it supports a requester moving a component to
		/// a different writer instance at restore time using
		/// </para>
		/// <para>IVssBackupComponentsEx::SetSelectedForRestoreEx</para>
		/// <para>.</para>
		/// <para>This value is not supported for express writers.</para>
		/// <para>Windows Server 2003:</para>
		/// <para>This value is not supported until Windows Server 2003 with SP1.</para>
		/// </summary>
		VSS_BS_WRITER_SUPPORTS_RESTORE_WITH_MOVE = 0x0200,

		/// <summary>
		/// <para>
		/// The writer supports backing up data that is part of the system state, but that can also be backed up independently of the system state.
		/// </para>
		/// <para>Windows Server 2003:</para>
		/// <para>This value is not supported until Windows Vista.</para>
		/// </summary>
		VSS_BS_INDEPENDENT_SYSTEM_STATE = 0x0400,

		/// <summary>
		/// <para>The writer supports a requester setting a roll-forward restore point using</para>
		/// <para>IVssBackupComponentsEx2::SetRollForward</para>
		/// <para>.</para>
		/// <para>This value is not supported for express writers.</para>
		/// <para>Windows Server 2003:</para>
		/// <para>This value is not supported until Windows Vista.</para>
		/// </summary>
		VSS_BS_ROLLFORWARD_RESTORE = 0x1000,

		/// <summary>
		/// <para>The writer supports a requester setting a restore name using</para>
		/// <para>IVssBackupComponentsEx2::SetRestoreName</para>
		/// <para>.</para>
		/// <para>This value is not supported for express writers.</para>
		/// <para>Windows Server 2003:</para>
		/// <para>This value is not supported until Windows Vista.</para>
		/// </summary>
		VSS_BS_RESTORE_RENAME = 0x2000,

		/// <summary>
		/// <para>The writer supports a requester setting authoritative restore using</para>
		/// <para>IVssBackupComponentsEx2::SetAuthoritativeRestore</para>
		/// <para>.</para>
		/// <para>This value is not supported for express writers.</para>
		/// <para>Windows Server 2003:</para>
		/// <para>This value is not supported until Windows Vista.</para>
		/// </summary>
		VSS_BS_AUTHORITATIVE_RESTORE = 0x4000,

		/// <summary>
		/// <para>The writer supports multiple unsynchronized restore events.</para>
		/// <para>This value is not supported for express writers.</para>
		/// <para>Windows Vista and Windows Server 2003:</para>
		/// <para>This value is not supported until Windows Server 2008.</para>
		/// </summary>
		VSS_BS_WRITER_SUPPORTS_PARALLEL_RESTORES = 0x8000,
	}

	/// <summary>The <c>VSS_BACKUP_TYPE</c> enumeration indicates the type of backup to be performed using VSS writer/requester coordination.</summary>
	/// <remarks>
	/// <para>An implementation of a backup type defined by a <c>VSS_BACKUP_TYPE</c> value must be done using the VSS API.</para>
	/// <para>
	/// This is particularly true in the case of incremental ( <c>VSS_BT_INCREMENTAL</c>) and differential ( <c>VSS_BT_DIFFERENTIAL</c>)
	/// backups. In these cases, requesters and writers work together using the file backup specification masks (VSS_FILE_SPEC_BACKUP_TYPE),
	/// and designations of files as being part of partial and differenced file operations to select which files must be backed up.
	/// </para>
	/// <para>
	/// A requester may also use other more traditional techniques to implement an incremental or differential restore, but it must not
	/// override the information provided through the VSS interfaces.
	/// </para>
	/// <para>
	/// If a requester, when processing a given backup type, encounters a writer that does not support that backup type, the requester
	/// performs backup or restore operations for that particular writer's data as if the backup type was <c>VSS_BT_FULL</c>.
	/// </para>
	/// <para>Requesters set the backup type with a call to IVssBackupComponents::SetBackupState.</para>
	/// <para>Writers use CVssWriter::GetBackupType to determine the backup type.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/vss/ne-vss-vss_backup_type typedef enum _VSS_BACKUP_TYPE { VSS_BT_UNDEFINED,
	// VSS_BT_FULL, VSS_BT_INCREMENTAL, VSS_BT_DIFFERENTIAL, VSS_BT_LOG, VSS_BT_COPY, VSS_BT_OTHER } VSS_BACKUP_TYPE, *PVSS_BACKUP_TYPE;
	[PInvokeData("vss.h", MSDNShortId = "NE:vss._VSS_BACKUP_TYPE")]
	public enum VSS_BACKUP_TYPE
	{
		/// <summary>
		/// <para>The backup type is not known.</para>
		/// <para>This value indicates an application error.</para>
		/// </summary>
		VSS_BT_UNDEFINED = 0,

		/// <summary>
		/// <para>Full backup: all files, regardless of whether they have been marked as backed up or not, are saved. This is</para>
		/// <para>the default backup type and schema, and all writers support it.</para>
		/// <para>Each file's backup history will be updated to reflect that it was backed up.</para>
		/// </summary>
		VSS_BT_FULL,

		/// <summary>
		/// <para>Incremental backup: files created or changed since the last full or incremental backup are saved. Files are</para>
		/// <para>marked as having been backed up.</para>
		/// <para>A requester can implement this sort of backup on a particular writer only if it supports the</para>
		/// <para>VSS_BS_INCREMENTAL</para>
		/// <para>schema.</para>
		/// <para>If a requester's backup type is</para>
		/// <para>VSS_BT_INCREMENTAL</para>
		/// <para>and a particular writer's</para>
		/// <para>backup schema does not support that sort of backup, the requester will always perform a full</para>
		/// <para>(</para>
		/// <para>VSS_BT_FULL</para>
		/// <para>) backup on that writer's data.</para>
		/// </summary>
		VSS_BT_INCREMENTAL,

		/// <summary>
		/// <para>Differential backup: files created or changed since the last full backup are saved. Files are not marked as</para>
		/// <para>having been backed up.</para>
		/// <para>A requester can implement this sort of backup on a particular writer only if it supports the</para>
		/// <para>VSS_BS_DIFFERENTIAL</para>
		/// <para>schema.</para>
		/// <para>If a requester's backup type is</para>
		/// <para>VSS_BT_DIFFERENTIAL</para>
		/// <para>and a particular writer's</para>
		/// <para>backup schema does not support that sort of backup, the requester will always perform a full</para>
		/// <para>(</para>
		/// <para>VSS_BT_FULL</para>
		/// <para>) backup on that writer's data.</para>
		/// </summary>
		VSS_BT_DIFFERENTIAL,

		/// <summary>
		/// <para>The log file of a writer is to participate in backup or restore operations.</para>
		/// <para>A requester can implement this sort of backup on a particular writer only if it supports the</para>
		/// <para>VSS_BS_LOG</para>
		/// <para>schema.</para>
		/// <para>If a requester's backup type is</para>
		/// <para>VSS_BT_LOG</para>
		/// <para>and a particular writer's backup</para>
		/// <para>schema does not support that sort of backup, the requester will always perform a full</para>
		/// <para>(</para>
		/// <para>VSS_BT_FULL</para>
		/// <para>) backup on that writer's data.</para>
		/// </summary>
		VSS_BT_LOG,

		/// <summary>
		/// <para>Files on disk will be copied to a backup medium regardless of the state of each file's backup history, and</para>
		/// <para>the backup history will not be updated.</para>
		/// <para>A requester can implement this sort of backup on a particular writer only if it supports the</para>
		/// <para>VSS_BS_COPY</para>
		/// <para>schema.</para>
		/// <para>If a requester's backup type is</para>
		/// <para>VSS_BT_COPY</para>
		/// <para>and a particular writer's backup</para>
		/// <para>schema does not support that sort of backup, the requester will always perform a full</para>
		/// <para>(</para>
		/// <para>VSS_BT_FULL</para>
		/// <para>) backup on that writer's data.</para>
		/// </summary>
		VSS_BT_COPY,

		/// <summary>Backup type that is not full, copy, log, incremental, or differential.</summary>
		VSS_BT_OTHER,
	}

	/// <summary>
	/// <para>
	/// The <c>VSS_FILE_SPEC_BACKUP_TYPE</c> enumeration is used by writers to indicate their support of certain backup operations—such as
	/// incremental or differential backup—on the basis of file sets (a specified file or files).
	/// </para>
	/// <para>
	/// File sets stored in the Writer Metadata Document are tagged with a bit mask (or bitwise OR) of <c>VSS_FILE_SPEC_BACKUP_TYPE</c>
	/// values indicating the following:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>Whether the writer and the requester have to evaluate a given file set for participation in the specified type of backup operations</term>
	/// </item>
	/// <item>
	/// <term>Whether backing up the specified file will require a shadow copy</term>
	/// </item>
	/// </list>
	/// </summary>
	/// <remarks>
	/// <para>
	/// When a writer sets a backup-required value of the <c>VSS_FILE_SPEC_BACKUP_TYPE</c> enumeration, it is indicating that the requester
	/// perform the backup in such a way that, when the backup is restored, the current version of the file set is restored. Typically, this
	/// means that the file set is copied as part of the backup.
	/// </para>
	/// <para>
	/// This setting can be overridden if a file is added to the Backup Components Document as a differenced file (using
	/// IVssComponent::AddDifferencedFilesByLastModifyTime) or as a partial file (using IVssComponent::AddPartialFile).
	/// </para>
	/// <para>
	/// If a file is added as a differenced file, the writer establishes criteria by which the requester should decide whether or not to
	/// actually copy a file to a backup medium. A writer typically adds differenced files to the Backup Components Document for inclusion
	/// in a backup PostSnapshot event (see CVssWriter::OnPostSnapshot). See Incremental and Differential Backups for details.
	/// </para>
	/// <para>
	/// When a writer sets a shadow copy-required value of the <c>VSS_FILE_SPEC_BACKUP_TYPE</c> enumeration, it indicates that the file set
	/// should be backed up from a shadow-copied volume. File sets not tagged with a shadow copy-required value can be backed up from the
	/// original volume.
	/// </para>
	/// <para>Writers set <c>VSS_FILE_SPEC_BACKUP_TYPE</c> values while handling an Identify event (see CVssWriter::OnIdentify).</para>
	/// <para>
	/// A bit mask (or bitwise OR) of <c>VSS_FILE_SPEC_BACKUP_TYPE</c> values can be applied to a file set when adding it to a component
	/// using the IVssCreateWriterMetadata::AddFilesToFileGroup, IVssCreateWriterMetadata::AddDatabaseFiles, or
	/// IVssCreateWriterMetadata::AddDatabaseLogFiles method.
	/// </para>
	/// <para>
	/// If no explicit file specification backup type is supplied during the addition of a file specification to a component, the
	/// specification is tagged with the default <c>VSS_FILE_SPEC_BACKUP_TYPE</c> value: (VSS_FSBT_ALL_BACKUP_REQUIRED | VSS_FSBT_ALL_SNAPSHOT_REQUIRED).
	/// </para>
	/// <para>
	/// Requesters or writers can recover a file set's file specification backup type by using the IVssWMFiledesc::GetBackupTypeMask method.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/vss/ne-vss-vss_file_spec_backup_type typedef enum _VSS_FILE_SPEC_BACKUP_TYPE {
	// VSS_FSBT_FULL_BACKUP_REQUIRED, VSS_FSBT_DIFFERENTIAL_BACKUP_REQUIRED, VSS_FSBT_INCREMENTAL_BACKUP_REQUIRED,
	// VSS_FSBT_LOG_BACKUP_REQUIRED, VSS_FSBT_FULL_SNAPSHOT_REQUIRED, VSS_FSBT_DIFFERENTIAL_SNAPSHOT_REQUIRED,
	// VSS_FSBT_INCREMENTAL_SNAPSHOT_REQUIRED, VSS_FSBT_LOG_SNAPSHOT_REQUIRED, VSS_FSBT_CREATED_DURING_BACKUP, VSS_FSBT_ALL_BACKUP_REQUIRED,
	// VSS_FSBT_ALL_SNAPSHOT_REQUIRED } VSS_FILE_SPEC_BACKUP_TYPE, *PVSS_FILE_SPEC_BACKUP_TYPE;
	[PInvokeData("vss.h", MSDNShortId = "NE:vss._VSS_FILE_SPEC_BACKUP_TYPE")]
	[Flags]
	public enum VSS_FILE_SPEC_BACKUP_TYPE
	{
		/// <summary>
		/// <para>A file set tagged with this value must be involved in all types of backup operations.</para>
		/// <para>A writer tags a file set with this value to indicate to the requester that it expects a copy of the current</para>
		/// <para>version of the file set to be available following the restore of any backup operation with a</para>
		/// <para>VSS_BACKUP_TYPE</para>
		/// <para>of</para>
		/// <para>VSS_BT_FULL</para>
		/// <para>.</para>
		/// </summary>
		VSS_FSBT_FULL_BACKUP_REQUIRED = 0x001,

		/// <summary>
		/// <para>A writer tags a file set with this value to indicate to the requester that it expects a copy of the current</para>
		/// <para>version of the file set to be available following the restore of any backup operation with a</para>
		/// <para>VSS_BACKUP_TYPE</para>
		/// <para>of</para>
		/// <para>VSS_BT_DIFFERENTIAL</para>
		/// <para>.</para>
		/// <para>This value is not supported for express writers.</para>
		/// </summary>
		VSS_FSBT_DIFFERENTIAL_BACKUP_REQUIRED = 0x002,

		/// <summary>
		/// <para>A writer tags a file set with this value to indicate to the requester that it expects a copy of the current</para>
		/// <para>version of the file set to be available following the restore of any backup operation with a</para>
		/// <para>VSS_BACKUP_TYPE</para>
		/// <para>of</para>
		/// <para>VSS_BT_INCREMENTAL</para>
		/// <para>.</para>
		/// <para>This value is not supported for express writers.</para>
		/// </summary>
		VSS_FSBT_INCREMENTAL_BACKUP_REQUIRED = 0x004,

		/// <summary>
		/// <para>A writer tags a file set with this value to indicate to the requester that it expects a copy of the current</para>
		/// <para>version of the file set to be available following the restore of any backup operation with a</para>
		/// <para>VSS_BACKUP_TYPE</para>
		/// <para>of</para>
		/// <para>VSS_BT_LOG</para>
		/// <para>.</para>
		/// <para>This value is not supported for express writers.</para>
		/// </summary>
		VSS_FSBT_LOG_BACKUP_REQUIRED = 0x008,

		/// <summary>
		/// <para>A file set tagged with this value must be backed up from a shadow copy of a volume (and never from the</para>
		/// <para>original volume) when participating in a backup operation with a</para>
		/// <para>VSS_BACKUP_TYPE</para>
		/// <para>of</para>
		/// <para>VSS_BT_FULL</para>
		/// <para>.</para>
		/// </summary>
		VSS_FSBT_FULL_SNAPSHOT_REQUIRED = 0x100,

		/// <summary>
		/// <para>A file set tagged with this value must be backed up from a shadow copy of a volume (and never from the</para>
		/// <para>original volume) when participating in a backup operation with a</para>
		/// <para>VSS_BACKUP_TYPE</para>
		/// <para>of</para>
		/// <para>VSS_BT_DIFFERENTIAL</para>
		/// <para>.</para>
		/// </summary>
		VSS_FSBT_DIFFERENTIAL_SNAPSHOT_REQUIRED = 0x200,

		/// <summary>
		/// <para>A file set tagged with this value must be backed up from a shadow copy of a volume (and never from the</para>
		/// <para>original volume) when participating in a backup operation with a</para>
		/// <para>VSS_BACKUP_TYPE</para>
		/// <para>of</para>
		/// <para>VSS_BT_INCREMENTAL</para>
		/// <para>.</para>
		/// </summary>
		VSS_FSBT_INCREMENTAL_SNAPSHOT_REQUIRED = 0x400,

		/// <summary>
		/// <para>A file set tagged with this value must be backed up from a shadow copy of a volume (and never from the</para>
		/// <para>original volume) when participating in a backup operation with a</para>
		/// <para>VSS_BACKUP_TYPE</para>
		/// <para>of</para>
		/// <para>VSS_BT_LOG</para>
		/// <para>).</para>
		/// </summary>
		VSS_FSBT_LOG_SNAPSHOT_REQUIRED = 0x800,

		/// <summary>
		/// A writer tags a file set with this value to indicate to the requester that they expect the file to be created during the
		/// snapshot sequence.
		/// </summary>
		VSS_FSBT_CREATED_DURING_BACKUP = 0x10000,

		/// <summary>
		/// <para>The default file backup specification type. A file set tagged with this value must always participate in</para>
		/// <para>backup and restore operations.</para>
		/// </summary>
		VSS_FSBT_ALL_BACKUP_REQUIRED = 0xF,

		/// <summary>
		/// <para>The shadow copy requirement for backup. A file set tagged with this value must always be backed up from a</para>
		/// <para>shadow copy of a volume (and never from the original volume) when participating in a backup operation.</para>
		/// </summary>
		VSS_FSBT_ALL_SNAPSHOT_REQUIRED = 0xF00,
	}

	/// <summary>Defines shadow copy LUN flags.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/vss/ne-vss-vss_hardware_options typedef enum _VSS_HARDWARE_OPTIONS {
	// VSS_BREAKEX_FLAG_MASK_LUNS, VSS_BREAKEX_FLAG_MAKE_READ_WRITE, VSS_BREAKEX_FLAG_REVERT_IDENTITY_ALL,
	// VSS_BREAKEX_FLAG_REVERT_IDENTITY_NONE, VSS_ONLUNSTATECHANGE_NOTIFY_READ_WRITE, VSS_ONLUNSTATECHANGE_NOTIFY_LUN_PRE_RECOVERY,
	// VSS_ONLUNSTATECHANGE_NOTIFY_LUN_POST_RECOVERY, VSS_ONLUNSTATECHANGE_DO_MASK_LUNS } VSS_HARDWARE_OPTIONS, *PVSS_HARDWARE_OPTIONS;
	[PInvokeData("vss.h", MSDNShortId = "NE:vss._VSS_HARDWARE_OPTIONS")]
	[Flags]
	public enum VSS_HARDWARE_OPTIONS
	{
		/// <summary>The shadow copy LUN will be masked from the host.</summary>
		VSS_BREAKEX_FLAG_MASK_LUNS = 0x001,

		/// <summary>The shadow copy LUN will be exposed to the host as a read-write volume.</summary>
		VSS_BREAKEX_FLAG_MAKE_READ_WRITE = 0x002,

		/// <summary>
		/// The disk identifiers of all of the shadow copy LUNs will be reverted to that of the original LUNs. However, if any of the
		/// original LUNs are present on the system, the operation will fail and none of the identifiers will be reverted.
		/// </summary>
		VSS_BREAKEX_FLAG_REVERT_IDENTITY_ALL = 0x004,

		/// <summary>None of the disk identifiers of the shadow copy LUNs will be reverted.</summary>
		VSS_BREAKEX_FLAG_REVERT_IDENTITY_NONE = 0x008,

		/// <summary>
		/// <para>
		/// The shadow copy LUNs will be converted permanently to read-write. This flag is set only as a notification for the provider; no
		/// provider action is required. For more information, see the
		/// </para>
		/// <para>IVssHardwareSnapshotProviderEx::OnLunStateChange</para>
		/// <para>method.</para>
		/// </summary>
		VSS_ONLUNSTATECHANGE_NOTIFY_READ_WRITE = 0x100,

		/// <summary>
		/// <para>
		/// The shadow copy LUNs will be converted temporarily to read-write and are about to undergo TxF recovery or VSS auto-recovery.
		/// This flag is set only as a notification for the provider; no provider action is required. For more information, see the
		/// </para>
		/// <para>IVssHardwareSnapshotProviderEx::OnLunStateChange</para>
		/// <para>method.</para>
		/// </summary>
		VSS_ONLUNSTATECHANGE_NOTIFY_LUN_PRE_RECOVERY = 0x200,

		/// <summary>
		/// <para>
		/// The shadow copy LUNs have just undergone TxF recovery or VSS auto-recovery and have been converted back to read-only. This flag
		/// is set only as a notification for the provider; no provider action is required. For more information, see the
		/// </para>
		/// <para>IVssHardwareSnapshotProviderEx::OnLunStateChange</para>
		/// <para>method.</para>
		/// </summary>
		VSS_ONLUNSTATECHANGE_NOTIFY_LUN_POST_RECOVERY = 0x400,

		/// <summary>
		/// <para>The provider must mask shadow copy LUNs from this computer. For more information, see the</para>
		/// <para>IVssHardwareSnapshotProviderEx::OnLunStateChange</para>
		/// <para>method.</para>
		/// </summary>
		VSS_ONLUNSTATECHANGE_DO_MASK_LUNS = 0x800,
	}

	/// <summary>
	/// The <c>VSS_OBJECT_TYPE</c> enumeration is used by requesters to identify an object as a shadow copy set, shadow copy, or provider.
	/// </summary>
	/// <remarks>
	/// <para>
	/// <c>VSS_OBJECT_TYPE</c> is used when calling IVssBackupComponents::Query to specify the types of objects about which to obtain
	/// information. An input of <c>VSS_OBJECT_NONE</c> will return information about all objects.
	/// </para>
	/// <para>
	/// In addition, <c>VSS_OBJECT_TYPE</c> is used as an input to IVssBackupComponents::DeleteSnapshots. However, <c>DeleteSnapshots</c>
	/// accepts only <c>VSS_OBJECT_TYPE</c> values of <c>VSS_OBJECT_SNAPSHOT_SET</c> or <c>VSS_OBJECT_SNAPSHOT</c>.
	/// </para>
	/// <para>The <c>Type</c> member of VSS_OBJECT_PROP is a member of the <c>VSS_OBJECT_TYPE</c> enumeration.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/vss/ne-vss-vss_object_type typedef enum _VSS_OBJECT_TYPE { VSS_OBJECT_UNKNOWN,
	// VSS_OBJECT_NONE, VSS_OBJECT_SNAPSHOT_SET, VSS_OBJECT_SNAPSHOT, VSS_OBJECT_PROVIDER, VSS_OBJECT_TYPE_COUNT } VSS_OBJECT_TYPE, *PVSS_OBJECT_TYPE;
	[PInvokeData("vss.h", MSDNShortId = "NE:vss._VSS_OBJECT_TYPE")]
	public enum VSS_OBJECT_TYPE
	{
		/// <summary>
		/// <para>The object type is not known.</para>
		/// <para>This indicates an application error.</para>
		/// </summary>
		VSS_OBJECT_UNKNOWN = 0,

		/// <summary>
		/// <para>The interpretation of this value depends on whether it is used as an input to a VSS method or returned as</para>
		/// <para>an output from a VSS method.</para>
		/// <para>When used as an input to a VSS method, it indicates that the method is not restricted to any particular</para>
		/// <para>object type, but should act on all appropriate objects. In this sense,</para>
		/// <para>VSS_OBJECT_NONE</para>
		/// <para>can be thought of as a wildcard input.</para>
		/// <para>When returned as an output, the object type is not known and means that there has been an application</para>
		/// <para>error.</para>
		/// </summary>
		VSS_OBJECT_NONE,

		/// <summary>Shadow copy set.</summary>
		VSS_OBJECT_SNAPSHOT_SET,

		/// <summary>Shadow copy.</summary>
		VSS_OBJECT_SNAPSHOT,

		/// <summary>Shadow copy provider.</summary>
		VSS_OBJECT_PROVIDER,

		/// <summary>Reserved value.</summary>
		VSS_OBJECT_TYPE_COUNT,
	}

	/// <summary>
	/// <para>Not supported.</para>
	/// <para>This enumeration is reserved for future use.</para>
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/vss/ne-vss-vss_provider_capabilities typedef enum _VSS_PROVIDER_CAPABILITIES {
	// VSS_PRV_CAPABILITY_LEGACY, VSS_PRV_CAPABILITY_COMPLIANT, VSS_PRV_CAPABILITY_LUN_REPOINT, VSS_PRV_CAPABILITY_LUN_RESYNC,
	// VSS_PRV_CAPABILITY_OFFLINE_CREATION, VSS_PRV_CAPABILITY_MULTIPLE_IMPORT, VSS_PRV_CAPABILITY_RECYCLING, VSS_PRV_CAPABILITY_PLEX,
	// VSS_PRV_CAPABILITY_DIFFERENTIAL, VSS_PRV_CAPABILITY_CLUSTERED } VSS_PROVIDER_CAPABILITIES, *PVSS_PROVIDER_CAPABILITIES;
	[PInvokeData("vss.h", MSDNShortId = "NE:vss._VSS_PROVIDER_CAPABILITIES")]
	[Flags]
	public enum VSS_PROVIDER_CAPABILITIES : ulong
	{
		/// <summary/>
		VSS_PRV_CAPABILITY_LEGACY = 0x001,

		/// <summary/>
		VSS_PRV_CAPABILITY_COMPLIANT = 0x002,

		/// <summary/>
		VSS_PRV_CAPABILITY_LUN_REPOINT = 0x004,

		/// <summary/>
		VSS_PRV_CAPABILITY_LUN_RESYNC = 0x008,

		/// <summary/>
		VSS_PRV_CAPABILITY_OFFLINE_CREATION = 0x010,

		/// <summary/>
		VSS_PRV_CAPABILITY_MULTIPLE_IMPORT = 0x020,

		/// <summary/>
		VSS_PRV_CAPABILITY_RECYCLING = 0x040,

		/// <summary/>
		VSS_PRV_CAPABILITY_PLEX = 0x080,

		/// <summary/>
		VSS_PRV_CAPABILITY_DIFFERENTIAL = 0x100,

		/// <summary/>
		VSS_PRV_CAPABILITY_CLUSTERED = 0x200,
	}

	/// <summary>The <c>VSS_PROVIDER_TYPE</c> enumeration specifies the provider type.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/vss/ne-vss-vss_provider_type typedef enum _VSS_PROVIDER_TYPE { VSS_PROV_UNKNOWN,
	// VSS_PROV_SYSTEM, VSS_PROV_SOFTWARE, VSS_PROV_HARDWARE, VSS_PROV_FILESHARE } VSS_PROVIDER_TYPE, *PVSS_PROVIDER_TYPE;
	[PInvokeData("vss.h", MSDNShortId = "NE:vss._VSS_PROVIDER_TYPE")]
	public enum VSS_PROVIDER_TYPE
	{
		/// <summary>
		/// <para>The provider type is unknown.</para>
		/// <para>This indicates an error in the application or the VSS service, or that no provider is available.</para>
		/// </summary>
		VSS_PROV_UNKNOWN = 0,

		/// <summary>The default provider that ships with Windows.</summary>
		VSS_PROV_SYSTEM,

		/// <summary>A software provider.</summary>
		VSS_PROV_SOFTWARE,

		/// <summary>A hardware provider.</summary>
		VSS_PROV_HARDWARE,

		/// <summary>
		/// <para>A file share provider.</para>
		/// <para>Windows 7, Windows Server 2008 R2, Windows Vista, Windows Server 2008, Windows XP and Windows Server 2003:</para>
		/// <para>This enumeration value is not supported until Windows 8 and Windows Server 2012.</para>
		/// </summary>
		VSS_PROV_FILESHARE,
	}

	/// <summary>Used by a requester to specify how a resynchronization operation is to be performed.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/vss/ne-vss-vss_recovery_options typedef enum _VSS_RECOVERY_OPTIONS {
	// VSS_RECOVERY_REVERT_IDENTITY_ALL, VSS_RECOVERY_NO_VOLUME_CHECK } VSS_RECOVERY_OPTIONS, *PVSS_RECOVERY_OPTIONS;
	[PInvokeData("vss.h", MSDNShortId = "NE:vss._VSS_RECOVERY_OPTIONS")]
	[Flags]
	public enum VSS_RECOVERY_OPTIONS
	{
		/// <summary>
		/// After the resynchronization operation is complete, the signature of each target LUN should be identical to that of the original
		/// LUN that was used to create the shadow copy.
		/// </summary>
		VSS_RECOVERY_REVERT_IDENTITY_ALL = 0x100,

		/// <summary>Volume safety checks should not be performed.</summary>
		VSS_RECOVERY_NO_VOLUME_CHECK = 0x200,
	}

	/// <summary>
	/// The <c>VSS_RESTORE_TYPE</c> enumeration is used by a requester to indicate the type of restore operation it is about to perform.
	/// </summary>
	/// <remarks>
	/// <para>A requester can optionally set the type of a restore operation using IVssBackupComponents::SetRestoreState.</para>
	/// <para>A writer can retrieve the type of a restore operation by calling CVssWriter::GetRestoreType.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/vss/ne-vss-vss_restore_type typedef enum _VSS_RESTORE_TYPE { VSS_RTYPE_UNDEFINED,
	// VSS_RTYPE_BY_COPY, VSS_RTYPE_IMPORT, VSS_RTYPE_OTHER } VSS_RESTORE_TYPE, *PVSS_RESTORE_TYPE;
	[PInvokeData("vss.h", MSDNShortId = "NE:vss._VSS_RESTORE_TYPE")]
	public enum VSS_RESTORE_TYPE
	{
		/// <summary>
		/// <para>No restore type is defined.</para>
		/// <para>This is the default restore type. However, writers should treat this restore type as if it were VSS_RTYPE_BY_COPY.</para>
		/// <para>This indicates an error on the part of the requester.</para>
		/// </summary>
		VSS_RTYPE_UNDEFINED = 0,

		/// <summary>
		/// <para>A requester restores backed-up data to the original volume from a backup</para>
		/// <para>medium.</para>
		/// </summary>
		VSS_RTYPE_BY_COPY,

		/// <summary>
		/// <para>A requester does not copy data from a backup medium, but imports a transportable shadow copy and uses this</para>
		/// <para>imported volume for operations such as data mining.</para>
		/// <para>Windows Server 2003, Standard Edition and Windows Server 2003, Web Edition:</para>
		/// <para>This value is not supported. All editions of Windows Server 2003 with SP1 support this value.</para>
		/// </summary>
		VSS_RTYPE_IMPORT,

		/// <summary>A restore type not currently enumerated. This value indicates an application error.</summary>
		VSS_RTYPE_OTHER,
	}

	/// <summary>
	/// The <c>VSS_ROLLFORWARD_TYPE</c> enumeration is used by a requester to indicate the type of roll-forward operation it is about to perform.
	/// </summary>
	/// <remarks>
	/// A requester sets the roll-forward operation type and specifies the restore point for partial roll-forward operations using IVssBackupComponentsEx2::SetRollForward.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/vss/ne-vss-vss_rollforward_type typedef enum _VSS_ROLLFORWARD_TYPE {
	// VSS_RF_UNDEFINED, VSS_RF_NONE, VSS_RF_ALL, VSS_RF_PARTIAL } VSS_ROLLFORWARD_TYPE, *PVSS_ROLLFORWARD_TYPE;
	[PInvokeData("vss.h", MSDNShortId = "NE:vss._VSS_ROLLFORWARD_TYPE")]
	public enum VSS_ROLLFORWARD_TYPE
	{
		/// <summary>
		/// <para>No roll-forward type is defined.</para>
		/// <para>This indicates an error on the part of the requester.</para>
		/// </summary>
		VSS_RF_UNDEFINED = 0,

		/// <summary>The roll-forward operation should not roll forward through logs.</summary>
		VSS_RF_NONE,

		/// <summary>The roll-forward operation should roll forward through all logs.</summary>
		VSS_RF_ALL,

		/// <summary>The roll-forward operation should roll forward through logs up to a specified restore point.</summary>
		VSS_RF_PARTIAL,
	}

	/// <summary>
	/// The <c>VSS_SNAPSHOT_COMPATIBILITY</c> enumeration indicates which volume control or file I/O operations are disabled for the volume
	/// that has been shadow copied.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/vss/ne-vss-vss_snapshot_compatibility typedef enum _VSS_SNAPSHOT_COMPATIBILITY {
	// VSS_SC_DISABLE_DEFRAG, VSS_SC_DISABLE_CONTENTINDEX } VSS_SNAPSHOT_COMPATIBILITY;
	[PInvokeData("vss.h", MSDNShortId = "NE:vss._VSS_SNAPSHOT_COMPATIBILITY")]
	[Flags]
	public enum VSS_SNAPSHOT_COMPATIBILITY
	{
		/// <summary>
		/// <para>The provider managing the shadow copies for a specified volume does not support defragmentation operations</para>
		/// <para>on that volume.</para>
		/// </summary>
		VSS_SC_DISABLE_DEFRAG = 0x01,

		/// <summary>
		/// <para>The provider managing the shadow copies for a specified volume does not support content index operations on</para>
		/// <para>that volume.</para>
		/// </summary>
		VSS_SC_DISABLE_CONTENTINDEX = 0x02,
	}

	/// <summary>
	/// The <c>_VSS_SNAPSHOT_CONTEXT</c> enumeration enables a requester using IVssBackupComponents::SetContext to specify how a shadow copy
	/// is to be created, queried, or deleted and the degree of writer involvement.
	/// </summary>
	/// <remarks>
	/// <para>The data type to be used with values of <c>_VSS_SNAPSHOT_CONTEXT</c> is <c>LONG</c>.</para>
	/// <para>The default context for VSS shadow copies is <c>VSS_CTX_BACKUP</c>.</para>
	/// <para>
	/// <c>Windows XP:</c> The only supported context is the default, <c>VSS_CTX_BACKUP</c>. Calling IVssBackupComponents::SetContext will
	/// return <c>E_NOTIMPL</c>.
	/// </para>
	/// <para>For details on how to use VSS shadow copies contexts, see Implementation Details for Creating Shadow Copies.</para>
	/// <para>
	/// Shadow copy behavior can be further controlled by using a bitwise OR to combine a supported _VSS_VOLUME_SNAPSHOT_ATTRIBUTES with
	/// valid <c>_VSS_SNAPSHOT_CONTEXT</c> values as an argument to the IVssBackupComponents::SetContext method.
	/// </para>
	/// <para>
	/// Currently, the only supported modifications are the bitwise OR of a <c>_VSS_SNAPSHOT_CONTEXT</c> value with the
	/// <c>VSS_VOLSNAP_ATTR_TRANSPORTABLE</c> and either the <c>VSS_VOLSNAP_ATTR_DIFFERENTIAL</c> or the <c>VSS_VOLSNAP_ATTR_PLEX</c> value
	/// of the _VSS_VOLUME_SNAPSHOT_ATTRIBUTES enumeration.
	/// </para>
	/// <para>However, these values cannot be used to modify <c>VSS_CTX_CLIENT_ACCESSIBLE</c> context.</para>
	/// <para>
	/// The use of <c>VSS_VOLSNAP_ATTR_TRANSPORTABLE</c> is limited to systems running Windows Server 2008 Enterprise, Windows Server 2008
	/// Datacenter, Windows Server 2003, Enterprise Edition, or Windows Server 2003, Datacenter Edition.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/vss/ne-vss-vss_snapshot_context typedef enum _VSS_SNAPSHOT_CONTEXT {
	// VSS_CTX_BACKUP, VSS_CTX_FILE_SHARE_BACKUP, VSS_CTX_NAS_ROLLBACK, VSS_CTX_APP_ROLLBACK, VSS_CTX_CLIENT_ACCESSIBLE,
	// VSS_CTX_CLIENT_ACCESSIBLE_WRITERS, VSS_CTX_ALL } VSS_SNAPSHOT_CONTEXT, *PVSS_SNAPSHOT_CONTEXT;
	[PInvokeData("vss.h", MSDNShortId = "NE:vss._VSS_SNAPSHOT_CONTEXT")]
	[Flags]
	public enum VSS_SNAPSHOT_CONTEXT : uint
	{
		/// <summary>
		/// <para>The standard backup context. Specifies an auto-release, nonpersistent shadow copy in which writers are</para>
		/// <para>involved in the creation.</para>
		/// </summary>
		VSS_CTX_BACKUP = 0,

		/// <summary>Specifies an auto-release, nonpersistent shadow copy created without writer involvement.</summary>
		VSS_CTX_FILE_SHARE_BACKUP = VSS_VOLUME_SNAPSHOT_ATTRIBUTES.VSS_VOLSNAP_ATTR_NO_WRITERS,

		/// <summary>
		/// <para>Specifies a persistent, non-auto-release shadow copy without writer involvement. This context should be</para>
		/// <para>used when there is no need for writer involvement to ensure that files are in a consistent state at the time</para>
		/// <para>of the shadow copy.</para>
		/// <para>Lightweight automated file rollback mechanisms or persistent shadow copies of file shares or data volumes</para>
		/// <para>that are not expected to contain any system-related files or databases might run under this context. For</para>
		/// <para>example, a requester could use this context for creating a shadow copy of a NAS volume hosting documents and</para>
		/// <para>simple user shares. Those types of data do not need writer involvement to create a consistent shadow copy.</para>
		/// </summary>
		VSS_CTX_NAS_ROLLBACK = VSS_VOLUME_SNAPSHOT_ATTRIBUTES.VSS_VOLSNAP_ATTR_PERSISTENT | VSS_VOLUME_SNAPSHOT_ATTRIBUTES.VSS_VOLSNAP_ATTR_NO_AUTO_RELEASE | VSS_VOLUME_SNAPSHOT_ATTRIBUTES.VSS_VOLSNAP_ATTR_NO_WRITERS,

		/// <summary>
		/// <para>Specifies a persistent, non-auto-release shadow copy with writer involvement. This context is designed</para>
		/// <para>to be used when writers are needed to ensure that files are in a well-defined state prior to shadow copy.</para>
		/// <para>Automated file rollback mechanisms of system volumes and shadow copies to be used in data mining or restore</para>
		/// <para>operations might run under this context. This context is similar to</para>
		/// <para>VSS_CTX_BACKUP</para>
		/// <para>but allows a requester more control over the persistence of the shadow copy.</para>
		/// </summary>
		VSS_CTX_APP_ROLLBACK = VSS_VOLUME_SNAPSHOT_ATTRIBUTES.VSS_VOLSNAP_ATTR_PERSISTENT | VSS_VOLUME_SNAPSHOT_ATTRIBUTES.VSS_VOLSNAP_ATTR_NO_AUTO_RELEASE,

		/// <summary>
		/// <para>Specifies a read-only,</para>
		/// <para>client-accessible shadow copy</para>
		/// <para>
		/// that supports Shadow Copies for Shared Folders and is created without writer involvement. Only the system provider (the default
		/// provider available on the system) can create this type of shadow copy.
		/// </para>
		/// <para>Most requesters will want to use the</para>
		/// <para>VSS_CTX_NAS_ROLLBACK</para>
		/// <para>context for persistent, non-auto-release shadow copies without writer involvement.</para>
		/// </summary>
		VSS_CTX_CLIENT_ACCESSIBLE = VSS_VOLUME_SNAPSHOT_ATTRIBUTES.VSS_VOLSNAP_ATTR_PERSISTENT | VSS_VOLUME_SNAPSHOT_ATTRIBUTES.VSS_VOLSNAP_ATTR_NO_AUTO_RELEASE | VSS_VOLUME_SNAPSHOT_ATTRIBUTES.VSS_VOLSNAP_ATTR_CLIENT_ACCESSIBLE | VSS_VOLUME_SNAPSHOT_ATTRIBUTES.VSS_VOLSNAP_ATTR_NO_WRITERS,

		/// <summary>
		/// <para>Specifies a read-only,</para>
		/// <para>client-accessible shadow copy</para>
		/// <para>
		/// that is created with writer involvement. Only the system provider (the default provider available on the system) can create this
		/// type of shadow copy.
		/// </para>
		/// <para>Most requesters will want to use the</para>
		/// <para>VSS_CTX_APP_ROLLBACK</para>
		/// <para>context for persistent, non-auto-release shadow copies with writer involvement.</para>
		/// <para>Windows Server 2003 and Windows XP:</para>
		/// <para>This context is not supported by Windows Server 2003 and Windows XP.</para>
		/// </summary>
		VSS_CTX_CLIENT_ACCESSIBLE_WRITERS = VSS_VOLUME_SNAPSHOT_ATTRIBUTES.VSS_VOLSNAP_ATTR_PERSISTENT | VSS_VOLUME_SNAPSHOT_ATTRIBUTES.VSS_VOLSNAP_ATTR_NO_AUTO_RELEASE | VSS_VOLUME_SNAPSHOT_ATTRIBUTES.VSS_VOLSNAP_ATTR_CLIENT_ACCESSIBLE,

		/// <summary>
		/// <para>All types of currently live shadow copies are available for administrative operations, such as shadow copy</para>
		/// <para>queries (see</para>
		/// <para>IVssBackupComponents::Query</para>
		/// <para>).</para>
		/// <para>VSS_CTX_ALL</para>
		/// <para>is a valid context for all VSS interfaces except</para>
		/// <para>IVssBackupComponents::StartSnapshotSet</para>
		/// <para>and</para>
		/// <para>IVssBackupComponents::DoSnapshotSet</para>
		/// <para>.</para>
		/// </summary>
		VSS_CTX_ALL = 0xffffffff,
	}

	/// <summary>Specifies the property to be set for a shadow copy.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/vss/ne-vss-vss_snapshot_property_id
	// typedef enum _VSS_SNAPSHOT_PROPERTY_ID { VSS_SPROPID_UNKNOWN, VSS_SPROPID_SNAPSHOT_ID, VSS_SPROPID_SNAPSHOT_SET_ID, VSS_SPROPID_SNAPSHOTS_COUNT, VSS_SPROPID_SNAPSHOT_DEVICE, VSS_SPROPID_ORIGINAL_VOLUME, VSS_SPROPID_ORIGINATING_MACHINE, VSS_SPROPID_SERVICE_MACHINE, VSS_SPROPID_EXPOSED_NAME, VSS_SPROPID_EXPOSED_PATH, VSS_SPROPID_PROVIDER_ID, VSS_SPROPID_SNAPSHOT_ATTRIBUTES, VSS_SPROPID_CREATION_TIMESTAMP, VSS_SPROPID_STATUS } VSS_SNAPSHOT_PROPERTY_ID, *PVSS_SNAPSHOT_PROPERTY_ID;
	[PInvokeData("vss.h", MSDNShortId = "NE:vss._VSS_SNAPSHOT_PROPERTY_ID")]
	public enum VSS_SNAPSHOT_PROPERTY_ID
	{
		/// <summary>
		///   <para>The property is not known.</para>
		///   <para>This value indicates an application error.</para>
		/// </summary>
		VSS_SPROPID_UNKNOWN,
		/// <summary>
		///   <para>The shadow copy identifier. For more information, see the</para>
		///   <para>m_SnapshotId</para>
		///   <para>member of the</para>
		///   <para>VSS_SNAPSHOT_PROP</para>
		///   <para>structure.</para>
		/// </summary>
		VSS_SPROPID_SNAPSHOT_ID,
		/// <summary>
		///   <para>The shadow copy set identifier. For more information, see the</para>
		///   <para>m_SnapshotSetId</para>
		///   <para>member of the</para>
		///   <para>VSS_SNAPSHOT_PROP</para>
		///   <para>structure.</para>
		/// </summary>
		VSS_SPROPID_SNAPSHOT_SET_ID,
		/// <summary>
		///   <para>The number of volumes included with the shadow copy in the shadow copy set when it was created. For more</para>
		///   <para>information, see the</para>
		///   <para>m_lSnapshotsCount</para>
		///   <para>member of the</para>
		///   <para>VSS_SNAPSHOT_PROP</para>
		///   <para>structure.</para>
		/// </summary>
		VSS_SPROPID_SNAPSHOTS_COUNT,
		/// <summary>
		///   <para>Null-terminated wide character string that specifies the name of the device object for the shadow copy of the</para>
		///   <para>volume. For more information, see the</para>
		///   <para>m_pwszSnapshotDeviceObject</para>
		///   <para>member of the</para>
		///   <para>VSS_SNAPSHOT_PROP</para>
		///   <para>structure.</para>
		/// </summary>
		VSS_SPROPID_SNAPSHOT_DEVICE,
		/// <summary>
		///   <para>A null-terminated wide character string that specifies the name of the original volume. For more information, see the</para>
		///   <para>m_pwszOriginalVolumeName</para>
		///   <para>member of the</para>
		///   <para>VSS_SNAPSHOT_PROP</para>
		///   <para>structure.</para>
		/// </summary>
		VSS_SPROPID_ORIGINAL_VOLUME,
		/// <summary>
		///   <para>A null-terminated wide character string that specifies the name of the machine that contains the original</para>
		///   <para>volume. For more information, see the</para>
		///   <para>m_pwszOriginatingMachine</para>
		///   <para>member of the</para>
		///   <para>VSS_SNAPSHOT_PROP</para>
		///   <para>structure.</para>
		/// </summary>
		VSS_SPROPID_ORIGINATING_MACHINE,
		/// <summary>
		///   <para>A null-terminated wide character string that specifies the name of the machine that is running the Volume Shadow Copy</para>
		///   <para>Service that created the shadow copy. For more information, see the</para>
		///   <para>m_pwszServiceMachine</para>
		///   <para>member of the</para>
		///   <para>VSS_SNAPSHOT_PROP</para>
		///   <para>structure.</para>
		/// </summary>
		VSS_SPROPID_SERVICE_MACHINE,
		/// <summary>
		///   <para>A null-terminated wide character string that specifies the name of the shadow copy when it is exposed. For more information, see the</para>
		///   <para>m_pwszExposedName</para>
		///   <para>member of the</para>
		///   <para>VSS_SNAPSHOT_PROP</para>
		///   <para>structure.</para>
		/// </summary>
		VSS_SPROPID_EXPOSED_NAME,
		/// <summary>
		///   <para>A null-terminated wide character string that specifies the portion of the volume that is made available</para>
		///   <para>when the shadow copy is exposed as a file share. For more information, see the</para>
		///   <para>m_pwszExposedPath</para>
		///   <para>member of the</para>
		///   <para>VSS_SNAPSHOT_PROP</para>
		///   <para>structure.</para>
		/// </summary>
		VSS_SPROPID_EXPOSED_PATH,
		/// <summary>
		///   <para>The provider identifier. For more information, see the</para>
		///   <para>m_ProviderId</para>
		///   <para>member of the</para>
		///   <para>VSS_SNAPSHOT_PROP</para>
		///   <para>structure.</para>
		/// </summary>
		VSS_SPROPID_PROVIDER_ID,
		/// <summary>
		///   <para>A bitmask of</para>
		///   <para>_VSS_VOLUME_SNAPSHOT_ATTRIBUTES</para>
		///   <para>values that specify the properties of the shadow copy. For more information, see the</para>
		///   <para>m_lSnapshotAttributes</para>
		///   <para>member of the</para>
		///   <para>VSS_SNAPSHOT_PROP</para>
		///   <para>structure.</para>
		/// </summary>
		VSS_SPROPID_SNAPSHOT_ATTRIBUTES,
		/// <summary>
		///   <para>A time stamp that specifies when the shadow copy was created. For more information, see the</para>
		///   <para>m_tsCreationTimestamp</para>
		///   <para>member of the</para>
		///   <para>VSS_SNAPSHOT_PROP</para>
		///   <para>structure.</para>
		/// </summary>
		VSS_SPROPID_CREATION_TIMESTAMP,
		/// <summary>
		///   <para>The status of the current shadow copy creation operation. For more information, see the</para>
		///   <para>m_eStatus</para>
		///   <para>member of the</para>
		///   <para>VSS_SNAPSHOT_PROP</para>
		///   <para>structure.</para>
		/// </summary>
		VSS_SPROPID_STATUS,
	}

	/// <summary>The <c>VSS_SNAPSHOT_STATE</c> enumeration is returned by a provider to specify the state of a given shadow copy operation.</summary>
	/// <remarks>
	/// <para>
	/// The shadow copy state is contained in the <c>m_eStatus</c> member of a VSS_SNAPSHOT_PROP object, which can be obtained for a single
	/// shadow copy by calling IVssBackupComponents::GetSnapshotProperties.
	/// </para>
	/// <para>
	/// Because IVssBackupComponents::GetSnapshotProperties fails during shadow copy creation with <c>VSS_E_OBJECT_NOT_FOUND</c>, a
	/// requester cannot obtain any <c>VSS_SNAPSHOT_STATE</c> value other than <c>VSS_SS_CREATED</c>.
	/// </para>
	/// <para>
	/// Calls to IVssBackupComponents::Query can also be used to obtain the shadow copy state. <c>IVssBackupComponents::Query</c> is used to
	/// return lists of shadow copies, which may be iterated over by means of the IVssEnumObject interface to obtain VSS_SNAPSHOT_PROP
	/// objects for each shadow copy that have completed on a given system. This means that, like
	/// IVssBackupComponents::GetSnapshotProperties, the <c>IVssBackupComponents::Query</c> method can return only a shadow copy state of <c>VSS_SS_CREATED</c>.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/vss/ne-vss-vss_snapshot_state typedef enum _VSS_SNAPSHOT_STATE { VSS_SS_UNKNOWN,
	// VSS_SS_PREPARING, VSS_SS_PROCESSING_PREPARE, VSS_SS_PREPARED, VSS_SS_PROCESSING_PRECOMMIT, VSS_SS_PRECOMMITTED,
	// VSS_SS_PROCESSING_COMMIT, VSS_SS_COMMITTED, VSS_SS_PROCESSING_POSTCOMMIT, VSS_SS_PROCESSING_PREFINALCOMMIT, VSS_SS_PREFINALCOMMITTED,
	// VSS_SS_PROCESSING_POSTFINALCOMMIT, VSS_SS_CREATED, VSS_SS_ABORTED, VSS_SS_DELETED, VSS_SS_POSTCOMMITTED, VSS_SS_COUNT }
	// VSS_SNAPSHOT_STATE, *PVSS_SNAPSHOT_STATE;
	[PInvokeData("vss.h", MSDNShortId = "NE:vss._VSS_SNAPSHOT_STATE")]
	public enum VSS_SNAPSHOT_STATE
	{
		/// <summary>
		/// <para>Reserved for system use.</para>
		/// <para>Unknown shadow copy state.</para>
		/// </summary>
		VSS_SS_UNKNOWN = 0,

		/// <summary>
		/// <para>Reserved for system use.</para>
		/// <para>Shadow copy is being prepared.</para>
		/// </summary>
		VSS_SS_PREPARING,

		/// <summary>
		/// <para>Reserved for system use.</para>
		/// <para>Processing of the shadow copy preparation is in progress.</para>
		/// </summary>
		VSS_SS_PROCESSING_PREPARE,

		/// <summary>
		/// <para>Reserved for system use.</para>
		/// <para>Shadow copy has been prepared.</para>
		/// </summary>
		VSS_SS_PREPARED,

		/// <summary>
		/// <para>Reserved for system use.</para>
		/// <para>Processing of the shadow copy precommit is in process.</para>
		/// </summary>
		VSS_SS_PROCESSING_PRECOMMIT,

		/// <summary>
		/// <para>Reserved for system use.</para>
		/// <para>Shadow copy is precommitted.</para>
		/// </summary>
		VSS_SS_PRECOMMITTED,

		/// <summary>
		/// <para>Reserved for system use.</para>
		/// <para>Processing of the shadow copy commit is in process.</para>
		/// </summary>
		VSS_SS_PROCESSING_COMMIT,

		/// <summary>
		/// <para>Reserved for system use.</para>
		/// <para>Shadow copy is committed.</para>
		/// </summary>
		VSS_SS_COMMITTED,

		/// <summary>
		/// <para>Reserved for system use.</para>
		/// <para>Processing of the shadow copy postcommit is in process.</para>
		/// </summary>
		VSS_SS_PROCESSING_POSTCOMMIT,

		/// <summary>
		/// <para>Reserved for system use.</para>
		/// <para>Processing of the shadow copy file commit operation is underway.</para>
		/// </summary>
		VSS_SS_PROCESSING_PREFINALCOMMIT,

		/// <summary>
		/// <para>Reserved for system use.</para>
		/// <para>Processing of the shadow copy file commit operation is done.</para>
		/// </summary>
		VSS_SS_PREFINALCOMMITTED,

		/// <summary>
		/// <para>Reserved for system use.</para>
		/// <para>Processing of the shadow copy following the final commit and prior to shadow copy create is underway.</para>
		/// </summary>
		VSS_SS_PROCESSING_POSTFINALCOMMIT,

		/// <summary>Shadow copy is created.</summary>
		VSS_SS_CREATED,

		/// <summary>
		/// <para>Reserved for system use.</para>
		/// <para>Shadow copy creation is aborted.</para>
		/// </summary>
		VSS_SS_ABORTED,

		/// <summary>
		/// <para>Reserved for system use.</para>
		/// <para>Shadow copy has been deleted.</para>
		/// </summary>
		VSS_SS_DELETED,

		/// <summary/>
		VSS_SS_POSTCOMMITTED,

		/// <summary>Reserved value.</summary>
		VSS_SS_COUNT,
	}

	/// <summary>
	/// Allows additional attributes to be specified for a shadow copy. The context of a shadow copy (as set by the
	/// IVssBackupComponents::SetContext method) may be modified by a bitmask that contains a valid combination of
	/// <c>_VSS_VOLUME_SNAPSHOT_ATTRIBUTES</c> and _VSS_SNAPSHOT_CONTEXT enumeration values.
	/// </summary>
	/// <remarks>
	/// <para>The default context for VSS shadow copies is VSS_CTX_BACKUP.</para>
	/// <para>
	/// A requester sets the context for a shadow copy about to be created by passing the member of the _VSS_SNAPSHOT_CONTEXT enumeration to
	/// the IVssBackupComponents::SetContext method.
	/// </para>
	/// <para>
	/// Requesters can modify this context by using a bitwise OR of the _VSS_SNAPSHOT_CONTEXT value with a supported value from the
	/// <c>_VSS_VOLUME_SNAPSHOT_ATTRIBUTES</c> enumeration as an argument to IVssBackupComponents::SetContext.
	/// </para>
	/// <para>
	/// Unless specifically requested to support a given mechanism, providers are free to use any type of mechanism to implement a shadow
	/// copy. Therefore, in the case where a shadow copy method is not specified, the provider is free to choose a differential mechanism (
	/// <c>VSS_VOLSNAP_ATTR_DIFFERENTIAL</c>), a PLEX mechanism ( <c>VSS_VOLSNAP_ATTR_PLEX</c>), or any other mechanism to support the
	/// shadow copy.
	/// </para>
	/// <para>
	/// While a provider can support both mechanisms, they are mutually exclusive for a given shadow copy. Requesters should not use both
	/// <c>VSS_VOLSNAP_ATTR_DIFFERENTIAL</c> and <c>VSS_VOLSNAP_ATTR_PLEX</c> to modify a specific shadow copy context.
	/// </para>
	/// <para>
	/// Currently, <c>VSS_VOLSNAP_ATTR_DIFFERENTIAL</c>, <c>VSS_VOLSNAP_ATTR_PLEX</c>, and <c>VSS_VOLSNAP_ATTR_TRANSPORTABLE</c> are the
	/// only values of the <c>_VSS_VOLUME_SNAPSHOT_ATTRIBUTES</c> enumeration that can be used to modify any context.
	/// </para>
	/// <para>In addition, it cannot be used to modify a <c>VSS_CTX_CLIENT_ACCESSIBLE</c> context.</para>
	/// <para>
	/// A requester can obtain information about a specific shadow copy (identified by VSS_ID) by unpacking the VSS_SNAPSHOT_PROP structure
	/// from the VSS_OBJECT_PROP structure returned by a call to IVssBackupComponents::GetSnapshotProperties.
	/// </para>
	/// <para>
	/// A requester can also obtain a VSS_SNAPSHOT_PROP structure for each of multiple shadow copies by calling IVssBackupComponents::Query
	/// and using IVssEnumObject to iterate the returns.
	/// </para>
	/// <para>
	/// The shadow copies' context and attributes are found as a bit mask contained in the <c>m_lSnapshotAttributes</c> member of the
	/// VSS_SNAPSHOT_PROP structure.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/vss/ne-vss-vss_volume_snapshot_attributes typedef enum
	// _VSS_VOLUME_SNAPSHOT_ATTRIBUTES { VSS_VOLSNAP_ATTR_PERSISTENT, VSS_VOLSNAP_ATTR_NO_AUTORECOVERY, VSS_VOLSNAP_ATTR_CLIENT_ACCESSIBLE,
	// VSS_VOLSNAP_ATTR_NO_AUTO_RELEASE, VSS_VOLSNAP_ATTR_NO_WRITERS, VSS_VOLSNAP_ATTR_TRANSPORTABLE, VSS_VOLSNAP_ATTR_NOT_SURFACED,
	// VSS_VOLSNAP_ATTR_NOT_TRANSACTED, VSS_VOLSNAP_ATTR_HARDWARE_ASSISTED, VSS_VOLSNAP_ATTR_DIFFERENTIAL, VSS_VOLSNAP_ATTR_PLEX,
	// VSS_VOLSNAP_ATTR_IMPORTED, VSS_VOLSNAP_ATTR_EXPOSED_LOCALLY, VSS_VOLSNAP_ATTR_EXPOSED_REMOTELY, VSS_VOLSNAP_ATTR_AUTORECOVER,
	// VSS_VOLSNAP_ATTR_ROLLBACK_RECOVERY, VSS_VOLSNAP_ATTR_DELAYED_POSTSNAPSHOT, VSS_VOLSNAP_ATTR_TXF_RECOVERY, VSS_VOLSNAP_ATTR_FILE_SHARE
	// } VSS_VOLUME_SNAPSHOT_ATTRIBUTES, *PVSS_VOLUME_SNAPSHOT_ATTRIBUTES;
	[PInvokeData("vss.h", MSDNShortId = "NE:vss._VSS_VOLUME_SNAPSHOT_ATTRIBUTES")]
	[Flags]
	public enum VSS_VOLUME_SNAPSHOT_ATTRIBUTES : uint
	{
		/// <summary>
		/// <para>The shadow copy is persistent across reboots.</para>
		/// <para>This attribute is automatically set for</para>
		/// <para>_VSS_SNAPSHOT_CONTEXT</para>
		/// <para>contexts of</para>
		/// <para>VSS_CTX_APP_ROLLBACK</para>
		/// <para>,</para>
		/// <para>VSS_CTX_CLIENT_ACCESSIBLE</para>
		/// <para>,</para>
		/// <para>VSS_CTX_CLIENT_ACCESSIBLE_WRITERS</para>
		/// <para>, and</para>
		/// <para>VSS_CTX_NAS_ROLLBACK</para>
		/// <para>.</para>
		/// <para>This attribute should not be used explicitly by requesters when setting the context of a shadow copy.</para>
		/// </summary>
		VSS_VOLSNAP_ATTR_PERSISTENT = 0x01,

		/// <summary>
		/// <para>Auto-recovery</para>
		/// <para>is disabled for the shadow copy.</para>
		/// <para>
		/// A requester can modify a shadow copy context with a bitwise OR of this attribute. By doing this, the requester instructs VSS to
		/// make the shadow copy read-only immediately after it is created, without allowing writers or other applications to update
		/// components in the shadow copy.
		/// </para>
		/// <para>
		/// Disabling auto-recovery can cause the shadow copy to be in an inconsistent state if any of its components are involved in
		/// transactional database operations, such as transactional read and write operations managed by Transactional NTFS (TxF). This is
		/// because disabling auto-recovery prevents incomplete transactions from being rolled back.
		/// </para>
		/// <para>
		/// Disabling auto-recovery also prevents writers from excluding files from the shadow copy. When auto-recovery is disabled, a
		/// writer can still call the
		/// </para>
		/// <para>IVssCreateWriterMetadataEx::AddExcludeFilesFromSnapshot</para>
		/// <para>method, but the writer's</para>
		/// <para>CVssWriter::OnPostSnapshot</para>
		/// <para>method cannot delete the files from the shadow copy.</para>
		/// <para>Windows Server 2003 and Windows XP:</para>
		/// <para>This value is not supported until Windows Vista.</para>
		/// </summary>
		VSS_VOLSNAP_ATTR_NO_AUTORECOVERY = 0x02,

		/// <summary>
		/// <para>The specified shadow copy is a</para>
		/// <para>client-accessible shadow copy</para>
		/// <para>that supports Shadow Copies for Shared Folders, and should not be exposed.</para>
		/// <para>This attribute is automatically set for</para>
		/// <para>VSS_CTX_CLIENT_ACCESSIBLE</para>
		/// <para>and</para>
		/// <para>VSS_CTX_CLIENT_ACCESSIBLE_WRITERS</para>
		/// <para>.</para>
		/// <para>This attribute should not be used explicitly by requesters when setting the context of a shadow copy.</para>
		/// </summary>
		VSS_VOLSNAP_ATTR_CLIENT_ACCESSIBLE = 0x04,

		/// <summary>
		/// <para>The shadow copy is not automatically deleted when the shadow copy requester process ends. The shadow copy</para>
		/// <para>can be deleted only by a call to</para>
		/// <para>IVssBackupComponents::DeleteSnapshots</para>
		/// <para>.</para>
		/// <para>This attribute is automatically set for</para>
		/// <para>_VSS_SNAPSHOT_CONTEXT</para>
		/// <para>contexts of</para>
		/// <para>VSS_CTX_APP_ROLLBACK</para>
		/// <para>,</para>
		/// <para>VSS_CTX_CLIENT_ACCESSIBLE</para>
		/// <para>,</para>
		/// <para>VSS_CTX_CLIENT_ACCESSIBLE_WRITERS</para>
		/// <para>, and</para>
		/// <para>VSS_CTX_NAS_ROLLBACK</para>
		/// <para>.</para>
		/// <para>This attribute should not be used explicitly by requesters when setting the context of a shadow copy.</para>
		/// </summary>
		VSS_VOLSNAP_ATTR_NO_AUTO_RELEASE = 0x08,

		/// <summary>
		/// <para>No writers are involved in creating the shadow copy.</para>
		/// <para>This attribute is automatically set for</para>
		/// <para>_VSS_SNAPSHOT_CONTEXT</para>
		/// <para>contexts of</para>
		/// <para>VSS_CTX_NAS_ROLLBACK</para>
		/// <para>,</para>
		/// <para>VSS_CTX_FILE_SHARE_BACKUP</para>
		/// <para>, and</para>
		/// <para>VSS_CTX_CLIENT_ACCESSIBLE</para>
		/// <para>.</para>
		/// <para>This attribute should not be used explicitly by requesters when setting the context of a shadow copy.</para>
		/// </summary>
		VSS_VOLSNAP_ATTR_NO_WRITERS = 0x10,

		/// <summary>
		/// <para>The shadow copy is to be transported and therefore should not be surfaced locally.</para>
		/// <para>This attribute can be used explicitly by requesters when setting the context of a shadow copy, if the</para>
		/// <para>provider for shadow copy supports transportable shadow copies.</para>
		/// <para>Windows Server 2003, Standard Edition, Windows Server 2003, Web Edition and Windows XP:</para>
		/// <para>This attribute is not supported. All editions of Windows Server 2003 with SP1 support this attribute.</para>
		/// <para>See</para>
		/// <para>Importing Transportable Shadow Copied Volumes</para>
		/// <para>for more information.</para>
		/// </summary>
		VSS_VOLSNAP_ATTR_TRANSPORTABLE = 0x20,

		/// <summary>
		/// <para>The shadow copy is not currently exposed.</para>
		/// <para>Unless the shadow copy is explicitly exposed or mounted, this attribute is set for all shadow copies.</para>
		/// <para>This attribute should not be used explicitly by requesters when setting the context of a shadow copy.</para>
		/// </summary>
		VSS_VOLSNAP_ATTR_NOT_SURFACED = 0x40,

		/// <summary>
		/// <para>The shadow copy is not transacted.</para>
		/// <para>
		/// A requester can modify a shadow copy context with a bitwise OR of this attribute. By doing this, the requester instructs VSS to
		/// disable built-in integration between VSS and transaction and resource managers.
		/// </para>
		/// <para>
		/// Setting this attribute guarantees that the requester will not receive VSS_E_TRANSACTION_FREEZE_TIMEOUT errors. However, it may
		/// cause unwanted consequences, such as the loss of transactional integrity or even data loss.
		/// </para>
		/// <para>Windows Server 2003 and Windows XP:</para>
		/// <para>This value is not supported until Windows Vista.</para>
		/// </summary>
		VSS_VOLSNAP_ATTR_NOT_TRANSACTED = 0x80,

		/// <summary>
		/// <para>Indicates that a given provider is a hardware provider.</para>
		/// <para>This attribute is automatically set for hardware providers.</para>
		/// <para>This enumeration value cannot be used to manually set the context (using the</para>
		/// <para>IVssBackupComponents::SetContext</para>
		/// <para>method) of a shadow copy by a bit mask (or bitwise OR) of this enumeration value and a valid shadow copy</para>
		/// <para>context value from</para>
		/// <para>_VSS_SNAPSHOT_CONTEXT</para>
		/// <para>.</para>
		/// </summary>
		VSS_VOLSNAP_ATTR_HARDWARE_ASSISTED = 0x10000,

		/// <summary>
		/// <para>Indicates that a given provider uses differential data or a copy-on-write mechanism to implement shadow copies.</para>
		/// <para>A requester can modify a shadow copy context with a bitwise OR of this attribute. By doing this, the</para>
		/// <para>requester instructs providers to create a shadow copy using a differential implementation. If no shadow copy</para>
		/// <para>provider installed on the system supports the requested attributes, a VSS_E_VOLUME_NOT_SUPPORTED error will be</para>
		/// <para>returned to</para>
		/// <para>IVssBackupComponents::AddToSnapshotSet</para>
		/// <para>.</para>
		/// </summary>
		VSS_VOLSNAP_ATTR_DIFFERENTIAL = 0x20000,

		/// <summary>
		/// <para>Indicates that a given provider uses a PLEX or mirrored split mechanism to implement shadow copies.</para>
		/// <para>A requester can modify a shadow copy context with a bitwise OR of this attribute. By doing this, the</para>
		/// <para>requester instructs the providers to create a shadow copy using a PLEX implementation. If no shadow copy</para>
		/// <para>provider installed on the system supports the requested attributes, a VSS_E_VOLUME_NOT_SUPPORTED error will be</para>
		/// <para>returned to</para>
		/// <para>IVssBackupComponents::AddToSnapshotSet</para>
		/// <para>.</para>
		/// </summary>
		VSS_VOLSNAP_ATTR_PLEX = 0x40000,

		/// <summary>
		/// <para>The shadow copy of the volume was imported onto this machine using the</para>
		/// <para>IVssBackupComponents::ImportSnapshots</para>
		/// <para>method rather than created using the</para>
		/// <para>IVssBackupComponents::DoSnapshotSet</para>
		/// <para>method.</para>
		/// <para>This attribute is automatically set if a shadow copy is imported.</para>
		/// <para>This attribute should not be used explicitly by requesters when setting the context of a shadow copy.</para>
		/// </summary>
		VSS_VOLSNAP_ATTR_IMPORTED = 0x80000,

		/// <summary>
		/// <para>The shadow copy is locally exposed. If this bit flag and the VSS_VOLSNAP_ATTR_EXPOSED_REMOTELY bit flag are</para>
		/// <para>not set, the shadow copy is hidden.</para>
		/// <para>The attribute is automatically added to a shadow copy context upon calling the</para>
		/// <para>IVssBackupComponents::ExposeSnapshot</para>
		/// <para>method to expose a shadow copy locally.</para>
		/// <para>This attribute should not be used explicitly by requesters when setting the context of a shadow copy.</para>
		/// </summary>
		VSS_VOLSNAP_ATTR_EXPOSED_LOCALLY = 0x100000,

		/// <summary>
		/// <para>The shadow copy is remotely exposed. If this bit flag and the VSS_VOLSNAP_ATTR_EXPOSED_LOCALLY bit flag are</para>
		/// <para>not set, the shadow copy is hidden.</para>
		/// <para>The attribute is automatically added to a shadow copy context upon calling the</para>
		/// <para>IVssBackupComponents::ExposeSnapshot</para>
		/// <para>method to expose a shadow copy locally.</para>
		/// <para>This attribute should not be used explicitly by requesters when setting the context of a shadow copy.</para>
		/// </summary>
		VSS_VOLSNAP_ATTR_EXPOSED_REMOTELY = 0x200000,

		/// <summary>
		/// <para>Indicates that the writer will need to</para>
		/// <para>auto-recover</para>
		/// <para>the component in</para>
		/// <para>CVssWriter::OnPostSnapshot</para>
		/// <para>.</para>
		/// <para>This attribute should not be used explicitly by requesters when setting the context of a shadow copy.</para>
		/// </summary>
		VSS_VOLSNAP_ATTR_AUTORECOVER = 0x400000,

		/// <summary>
		/// <para>Indicates that the writer will need to</para>
		/// <para>auto-recover</para>
		/// <para>the component in</para>
		/// <para>CVssWriter::OnPostSnapshot</para>
		/// <para>if the shadow copy is being used for rollback (for data mining, for example).</para>
		/// <para>
		/// A requester would set this flag in the shadow copy context to indicate that the shadow copy is being created for a non-backup
		/// purpose such as data mining.
		/// </para>
		/// </summary>
		VSS_VOLSNAP_ATTR_ROLLBACK_RECOVERY = 0x800000,

		/// <summary>
		/// <para>Reserved for system use.</para>
		/// <para>Windows Vista, Windows Server 2003 and Windows XP:</para>
		/// <para>This value is not supported until Windows Server 2008.</para>
		/// </summary>
		VSS_VOLSNAP_ATTR_DELAYED_POSTSNAPSHOT = 0x1000000,

		/// <summary>
		/// <para>Indicates that TxF recovery should be enforced during shadow copy creation.</para>
		/// <para>Windows Vista, Windows Server 2003 and Windows XP:</para>
		/// <para>This value is not supported until Windows Server 2008.</para>
		/// </summary>
		VSS_VOLSNAP_ATTR_TXF_RECOVERY = 0x2000000,

		/// <summary/>
		VSS_VOLSNAP_ATTR_FILE_SHARE = 0x4000000,
	}

	/// <summary>The <c>VSS_WRITER_STATE</c> enumeration indicates the current state of the writer.</summary>
	/// <remarks>A requester determines the state of a writer through IVssBackupComponents::GetWriterStatus.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/vss/ne-vss-vss_writer_state typedef enum _VSS_WRITER_STATE { VSS_WS_UNKNOWN,
	// VSS_WS_STABLE, VSS_WS_WAITING_FOR_FREEZE, VSS_WS_WAITING_FOR_THAW, VSS_WS_WAITING_FOR_POST_SNAPSHOT,
	// VSS_WS_WAITING_FOR_BACKUP_COMPLETE, VSS_WS_FAILED_AT_IDENTIFY, VSS_WS_FAILED_AT_PREPARE_BACKUP, VSS_WS_FAILED_AT_PREPARE_SNAPSHOT,
	// VSS_WS_FAILED_AT_FREEZE, VSS_WS_FAILED_AT_THAW, VSS_WS_FAILED_AT_POST_SNAPSHOT, VSS_WS_FAILED_AT_BACKUP_COMPLETE,
	// VSS_WS_FAILED_AT_PRE_RESTORE, VSS_WS_FAILED_AT_POST_RESTORE, VSS_WS_FAILED_AT_BACKUPSHUTDOWN, VSS_WS_COUNT } VSS_WRITER_STATE, *PVSS_WRITER_STATE;
	[PInvokeData("vss.h", MSDNShortId = "NE:vss._VSS_WRITER_STATE")]
	public enum VSS_WRITER_STATE
	{
		/// <summary>
		/// <para>The writer's state is not known.</para>
		/// <para>This indicates an error on the part of the writer.</para>
		/// </summary>
		VSS_WS_UNKNOWN = 0,

		/// <summary>
		/// <para>The writer has completed processing current shadow copy events and is ready to proceed, or</para>
		/// <para>CVssWriter::OnPrepareSnapshot</para>
		/// <para>has not yet</para>
		/// <para>been called.</para>
		/// </summary>
		VSS_WS_STABLE,

		/// <summary>The writer is waiting for the freeze state.</summary>
		VSS_WS_WAITING_FOR_FREEZE,

		/// <summary>The writer is waiting for the thaw state.</summary>
		VSS_WS_WAITING_FOR_THAW,

		/// <summary>
		/// <para>The writer is waiting for the</para>
		/// <para>PostSnapshot</para>
		/// <para>state.</para>
		/// </summary>
		VSS_WS_WAITING_FOR_POST_SNAPSHOT,

		/// <summary>The writer is waiting for the requester to finish its backup operation.</summary>
		VSS_WS_WAITING_FOR_BACKUP_COMPLETE,

		/// <summary>The writer vetoed the shadow copy creation process at the writer identification state.</summary>
		VSS_WS_FAILED_AT_IDENTIFY,

		/// <summary>The writer vetoed the shadow copy creation process during the backup preparation state.</summary>
		VSS_WS_FAILED_AT_PREPARE_BACKUP,

		/// <summary>
		/// <para>The writer vetoed the shadow copy creation process during the</para>
		/// <para>PrepareForSnapshot</para>
		/// <para>state.</para>
		/// </summary>
		VSS_WS_FAILED_AT_PREPARE_SNAPSHOT,

		/// <summary>The writer vetoed the shadow copy creation process during the freeze state.</summary>
		VSS_WS_FAILED_AT_FREEZE,

		/// <summary>The writer vetoed the shadow copy creation process during the thaw state.</summary>
		VSS_WS_FAILED_AT_THAW,

		/// <summary>
		/// <para>The writer vetoed the shadow copy creation process during the</para>
		/// <para>PostSnapshot</para>
		/// <para>state.</para>
		/// </summary>
		VSS_WS_FAILED_AT_POST_SNAPSHOT,

		/// <summary>
		/// <para>The shadow copy has been created and the writer failed during the</para>
		/// <para>BackupComplete</para>
		/// <para>state. A writer</para>
		/// <para>should save information about this failure to the error log. For additional information on logging, see</para>
		/// <para>Event and Error Handling Under VSS</para>
		/// <para>.</para>
		/// </summary>
		VSS_WS_FAILED_AT_BACKUP_COMPLETE,

		/// <summary>
		/// <para>The writer failed during the</para>
		/// <para>PreRestore</para>
		/// <para>state.</para>
		/// </summary>
		VSS_WS_FAILED_AT_PRE_RESTORE,

		/// <summary>
		/// <para>The writer failed during the</para>
		/// <para>PostRestore</para>
		/// <para>state.</para>
		/// </summary>
		VSS_WS_FAILED_AT_POST_RESTORE,

		/// <summary>The writer failed during the shutdown of the backup application.</summary>
		VSS_WS_FAILED_AT_BACKUPSHUTDOWN,

		/// <summary>Reserved value.</summary>
		VSS_WS_COUNT,
	}

	/// <summary>
	/// <para>
	/// The <c>IVssAsync</c> interface is returned to calling applications by methods that initiate asynchronous operations, which run in
	/// the background and typically require a long time to complete.
	/// </para>
	/// <para>
	/// The <c>IVssAsync</c> interface permits an application to monitor and control an asynchronous operation by waiting on its completion,
	/// querying its status, or canceling it.
	/// </para>
	/// <para>The following methods return an <c>IVssAsync</c> interface:</para>
	/// <list type="bullet">
	/// <item>
	/// <term>IVssBackupComponents::BackupComplete</term>
	/// </item>
	/// <item>
	/// <term>IVssBackupComponents::DoSnapshotSet</term>
	/// </item>
	/// <item>
	/// <term>IVssBackupComponents::GatherWriterMetadata</term>
	/// </item>
	/// <item>
	/// <term>IVssBackupComponents::GatherWriterStatus</term>
	/// </item>
	/// <item>
	/// <term>IVssBackupComponents::ImportSnapshots</term>
	/// </item>
	/// <item>
	/// <term>IVssBackupComponents::PostRestore</term>
	/// </item>
	/// <item>
	/// <term>IVssBackupComponents::PrepareForBackup</term>
	/// </item>
	/// <item>
	/// <term>IVssBackupComponents::PreRestore</term>
	/// </item>
	/// </list>
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/vss/nn-vss-ivssasync
	[PInvokeData("vss.h", MSDNShortId = "NN:vss.IVssAsync")]
	[ComImport, Guid("507C37B4-CF5B-4e95-B0AF-14EB9767467E"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IVssAsync
	{
		/// <summary>The <c>Cancel</c> method cancels an incomplete asynchronous operation.</summary>
		/// <returns>
		/// <para>All calls to <c>Cancel</c> for all IVssAsync objects support the following status codes.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The asynchronous operation had been successfully canceled.</term>
		/// </item>
		/// <item>
		/// <term>VSS_S_ASYNC_CANCELLED</term>
		/// <term>The asynchronous operation had been canceled prior to calling this method.</term>
		/// </item>
		/// <item>
		/// <term>VSS_S_ASYNC_FINISHED</term>
		/// <term>The asynchronous operation had completed prior to calling this method.</term>
		/// </item>
		/// <item>
		/// <term>VSS_E_UNEXPECTED</term>
		/// <term>
		/// Unexpected error. The error code is logged in the error log file. For more information, see Event and Error Handling Under VSS.
		/// Windows Server 2008, Windows Vista, Windows Server 2003 and Windows XP: This value is not supported until Windows Server 2008 R2
		/// and Windows 7. E_UNEXPECTED is used instead.
		/// </term>
		/// </item>
		/// </list>
		/// <para>
		/// If an operation has completed unsuccessfully before <c>Cancel</c> was called, then <c>Cancel</c> returns the error that
		/// operation encountered.
		/// </para>
		/// <para>
		/// To obtain a complete list of return values for a specific <c>IVssAsync::Cancel</c>, see the error codes of the method that
		/// returned the IVssAsync object.
		/// </para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/vss/nf-vss-ivssasync-cancel HRESULT Cancel();
		[PreserveSig]
		HRESULT Cancel();

		/// <summary>The <c>Wait</c> method waits until an incomplete asynchronous operation finishes.</summary>
		/// <param name="dwMilliseconds">
		/// <para>Length of time, in milliseconds, that the method will wait for an asynchronous process to return before timing out.</para>
		/// <para>The default value for this argument is INFINITE.</para>
		/// <para>
		/// <c>Windows Server 2003:</c> This parameter is reserved and must be INFINITE. If any other value is specified for this parameter,
		/// the call to <c>Wait</c> fails with E_INVALIDARG.
		/// </para>
		/// <para><c>Windows XP:</c> This method has no parameters.</para>
		/// </param>
		/// <returns>
		/// <para>All calls to <c>Wait</c> for all IVssAsync objects support the following status codes.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The wait operation was successful. Call IVssAsync::QueryStatus to determine the final status of the asynchronous operation.</term>
		/// </item>
		/// <item>
		/// <term>E_ACCESSDENIED</term>
		/// <term>The wait operation failed because the user did not have the correct privileges.</term>
		/// </item>
		/// <item>
		/// <term>VSS_E_UNEXPECTED</term>
		/// <term>
		/// Unexpected error. The error code is logged in the error log file. For more information, see Event and Error Handling Under VSS.
		/// Windows Server 2008, Windows Vista, Windows Server 2003 and Windows XP: This value is not supported until Windows Server 2008 R2
		/// and Windows 7. E_UNEXPECTED is used instead.
		/// </term>
		/// </item>
		/// </list>
		/// <para>If an operation fails while being waited on, <c>Wait</c> returns the error that operation encountered.</para>
		/// <para>
		/// To obtain a complete list of return values for a specific <c>Wait</c>, see the error codes of the method that returned the
		/// IVssAsync object.
		/// </para>
		/// </returns>
		/// <remarks>This method can succeed even if the method that returns it failed.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/vss/nf-vss-ivssasync-wait HRESULT Wait( [in] DWORD dwMilliseconds );
		[PreserveSig]
		HRESULT Wait(uint dwMilliseconds = 0xffffffff);

		/// <summary>The <c>QueryStatus</c> method queries the status of an asynchronous operation.</summary>
		/// <param name="pHrResult">
		/// <para>The status of the asynchronous operation that returned the current IVssAsync object.</para>
		/// <para>All calls to <c>QueryStatus</c> for all IVssAsync objects support the following status codes.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>VSS_S_ASYNC_CANCELLED</term>
		/// <term>The asynchronous operation was canceled by a previous call to IVssAsync::Cancel.</term>
		/// </item>
		/// <item>
		/// <term>VSS_S_ASYNC_FINISHED</term>
		/// <term>The asynchronous operation was completed successfully.</term>
		/// </item>
		/// <item>
		/// <term>VSS_S_ASYNC_PENDING</term>
		/// <term>The asynchronous operation is still running.</term>
		/// </item>
		/// </list>
		/// <para>
		/// Additional return values can be returned, but depend on the return codes of the method that initially returned the IVssAsync object.
		/// </para>
		/// </param>
		/// <param name="pReserved">The value of this parameter should be <c>NULL</c>.</param>
		/// <returns>
		/// <para>The following are the valid return codes for this method.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The query operation was successful.</term>
		/// </item>
		/// <item>
		/// <term>E_ACCESSDENIED</term>
		/// <term>The query operation failed because the user did not have the correct privileges.</term>
		/// </item>
		/// <item>
		/// <term>E_INVALIDARG</term>
		/// <term>The pointer to the variable used to hold the pHrResult return value is NULL or is not a valid memory location.</term>
		/// </item>
		/// <item>
		/// <term>VSS_E_UNEXPECTED</term>
		/// <term>
		/// Unexpected error. The error code is logged in the error log file. For more information, see Event and Error Handling Under VSS.
		/// Windows Server 2008, Windows Vista, Windows Server 2003 and Windows XP: This value is not supported until Windows Server 2008 R2
		/// and Windows 7. E_UNEXPECTED is used instead.
		/// </term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// In the event of an error during the course of an asynchronous operation, <c>QueryStatus</c> will return the same error code as
		/// the method that initially returned the IVssAsync object.
		/// </para>
		/// <para>
		/// To obtain a complete list of return values for an <c>IVssAsync::QueryStatus</c> object returned by a specific method, see the
		/// error codes documented for that method.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/vss/nf-vss-ivssasync-querystatus HRESULT QueryStatus( [out] HRESULT
		// *pHrResult, [out] INT *pReserved );
		[PreserveSig]
		HRESULT QueryStatus(out HRESULT pHrResult, [In, Optional] IntPtr pReserved);
	}

	/// <summary>
	/// <para>
	/// The <c>IVssEnumObject</c> interface contains methods to iterate over and perform other operations on a list of enumerated objects.
	/// </para>
	/// <para>The IVssBackupComponents::Query method returns an <c>IVssEnumObject</c> object.</para>
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/vss/nn-vss-ivssenumobject
	[PInvokeData("vss.h", MSDNShortId = "NN:vss.IVssEnumObject")]
	[ComImport, Guid("AE1C7110-2F60-11d3-8A39-00C04F72D8E3"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IVssEnumObject : ICOMEnum<VSS_OBJECT_PROP>
	{
		/// <summary>The <c>Next</c> method returns the specified number of objects from the specified list of enumerated objects.</summary>
		/// <param name="celt">The number of elements to be read from the list of enumerated objects into the rgelt buffer.</param>
		/// <param name="rgelt">
		/// The address of a caller-allocated buffer that receives celtVSS_OBJECT_PROP structures that contain the returned objects. This
		/// parameter is required and cannot be NULL.
		/// </param>
		/// <param name="pceltFetched">The number of elements that were returned in the rgelt buffer.</param>
		/// <returns>
		/// <para>The following are the valid return codes for this method.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The operation was successful.</term>
		/// </item>
		/// <item>
		/// <term>S_FALSE</term>
		/// <term>The number of returned items is less than the number requested.</term>
		/// </item>
		/// <item>
		/// <term>E_FAIL</term>
		/// <term>There is an internal error in the enumerator.</term>
		/// </item>
		/// <item>
		/// <term>E_POINTER</term>
		/// <term>One of the required pointer parameters is NULL.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// When requesting the return of more than one VSS_OBJECT_PROP object, a return value of S_FALSE indicates that the end of the
		/// enumeration list has been reached. If more objects were requested than remained in the list, <c>Next</c> will return all the
		/// remaining objects, set the pceltFetched parameter to a nonzero value, and return S_FALSE.
		/// </para>
		/// <para>
		/// The output rgelt parameter must point to an allocated array containing celt VSS_OBJECT_PROP structures, and cannot be NULL.
		/// </para>
		/// <para>
		/// It is the caller's responsibility to free system resources returned by <c>IVssEnumObject::Next</c> to the VSS_OBJECT_PROP
		/// structure pointed to by the rgelt parameter.
		/// </para>
		/// <para>
		/// The callers must use CoTaskMemFree for every string value in the VSS_SNAPSHOT_PROP or VSS_PROVIDER_PROP object in the returned
		/// VSS_OBJECT_PROP structure.
		/// </para>
		/// <para>
		/// In the case of VSS_SNAPSHOT_PROP, this can be done manually, or the utility function VssFreeSnapshotProperties can be used.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/vss/nf-vss-ivssenumobject-next HRESULT Next( [in] ULONG celt, [out]
		// VSS_OBJECT_PROP *rgelt, [out] ULONG *pceltFetched );
		[PreserveSig]
		HRESULT Next(uint celt, [Out, MarshalAs(UnmanagedType.LPArray)] VSS_OBJECT_PROP[] rgelt, out uint pceltFetched);

		/// <summary>The <c>Skip</c> method skips the specified number of objects.</summary>
		/// <param name="celt">Number of elements to be skipped in the list of enumerated objects.</param>
		/// <returns>
		/// <para>The following are the valid return codes for this method.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The operation was successful.</term>
		/// </item>
		/// <item>
		/// <term>S_FALSE</term>
		/// <term>An attempt was made to access a location beyond the end of the list of items.</term>
		/// </item>
		/// <item>
		/// <term>E_FAIL</term>
		/// <term>There was an internal error in the enumerator.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/vss/nf-vss-ivssenumobject-skip HRESULT Skip( [in] ULONG celt );
		[PreserveSig]
		HRESULT Skip(uint celt);

		/// <summary>The <c>Reset</c> method resets the enumerator so that IVssEnumObject:Next starts at the first enumerated object.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/vss/nf-vss-ivssenumobject-reset HRESULT Reset();
		void Reset();

		/// <summary>
		/// The <c>Clone</c> method creates a copy of the specified list of enumerated elements by creating a copy of the IVssEnumObject
		/// enumerator object.
		/// </summary>
		/// <returns>
		/// An IVssEnumObject enumerator object. Set the value of this parameter to <c>NULL</c> before calling
		/// this method.
		/// </returns>
		/// <remarks>
		/// <para>The cloned enumerator object will refer to the same list of VSS_OBJECT_PROP structures.</para>
		/// <para>
		/// The caller must call the Release method of the returned interface pointer to deallocate the system resources held by the
		/// IVssEnumObject enumerator object pointed to by the ppEnum parameter.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/vss/nf-vss-ivssenumobject-clone HRESULT Clone( [in, out] IVssEnumObject
		// **ppenum );
		IVssEnumObject Clone();
	}

	/// <summary>The <c>VSS_OBJECT_PROP</c> structure defines the properties of a provider, volume, shadow copy, or shadow copy set.</summary>
	/// <remarks>
	/// <para>
	/// A requester obtains <c>VSS_OBJECT_PROP</c> structures by using IVssEnumObject::Next to iterate over the list of objects returned by
	/// a call to IVssBackupComponents::Query.
	/// </para>
	/// <para>
	/// As its members are filled by a COM interface, prior to deleting the property structures VSS_SNAPSHOT_PROP and VSS_PROVIDER_PROP, the
	/// memory they contain must be released by calling CoTaskMemFree for every string and byte array value contained in each structure.
	/// </para>
	/// <para>In the case of VSS_SNAPSHOT_PROP, this can be done manually, or the utility function VssFreeSnapshotProperties can be used.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/vss/ns-vss-vss_object_prop typedef struct _VSS_OBJECT_PROP { VSS_OBJECT_TYPE Type;
	// VSS_OBJECT_UNION Obj; } VSS_OBJECT_PROP, *PVSS_OBJECT_PROP;
	[PInvokeData("vss.h", MSDNShortId = "NS:vss._VSS_OBJECT_PROP")]
	[StructLayout(LayoutKind.Sequential)]
	public struct VSS_OBJECT_PROP
	{
		/// <summary>Object type. Refer to VSS_OBJECT_TYPE.</summary>
		public VSS_OBJECT_TYPE Type;

		/// <summary>
		/// <para>Object properties: a union of VSS_SNAPSHOT_PROP and VSS_PROVIDER_PROP structures. (See VSS_OBJECT_UNION.)</para>
		/// <para>
		/// It contains information for an object of the type specified by the <c>Type</c> member of the <c>VSS_OBJECT_PROP</c> structure.
		/// Objects can be providers, volumes, shadow copies, or shadow copy sets.
		/// </para>
		/// </summary>
		public VSS_OBJECT_UNION Obj;
	}

	/// <summary>
	/// The VSS_OBJECT_UNION defines the union of object types that can be defined by the VSS_OBJECT_PROP structure (section 2.2.3.2).
	/// </summary>
	[PInvokeData("vss.h", MSDNShortId = "NS:vss._VSS_OBJECT_PROP")]
	[StructLayout(LayoutKind.Explicit)]
	public struct VSS_OBJECT_UNION
	{
		/// <summary>The structure specifies a shadow copy object as a VSS_SNAPSHOT_PROP structure (section 2.2.3.3).</summary>
		[FieldOffset(0)]
		public VSS_SNAPSHOT_PROP Snap;

		/// <summary>
		/// The structure specifies a VSS provider object. The Shadow Copy Management Protocol is not used to manage VSS provider objects;
		/// therefore, this member MUST NOT be referenced and MUST be ignored on receipt.
		/// </summary>
		[FieldOffset(0)]
		public VSS_PROVIDER_PROP Prov;
	}

	/// <summary>The <c>VSS_PROVIDER_PROP</c> structure specifies shadow copy provider properties.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/vss/ns-vss-vss_provider_prop typedef struct _VSS_PROVIDER_PROP { VSS_ID
	// m_ProviderId; VSS_PWSZ m_pwszProviderName; VSS_PROVIDER_TYPE m_eProviderType; VSS_PWSZ m_pwszProviderVersion; VSS_ID
	// m_ProviderVersionId; CLSID m_ClassId; } VSS_PROVIDER_PROP, *PVSS_PROVIDER_PROP;
	[PInvokeData("vss.h", MSDNShortId = "NS:vss._VSS_PROVIDER_PROP")]
	[StructLayout(LayoutKind.Sequential)]
	public struct VSS_PROVIDER_PROP
	{
		/// <summary>Identifies the provider who supports shadow copies of this class.</summary>
		public Guid m_ProviderId;

		/// <summary>String containing the provider name.</summary>
		public StrPtrUni m_pwszProviderName;

		/// <summary>Provider type. See VSS_PROVIDER_TYPE for more information.</summary>
		public VSS_PROVIDER_TYPE m_eProviderType;

		/// <summary>String containing the provider version in readable format.</summary>
		public StrPtrUni m_pwszProviderVersion;

		/// <summary>A VSS_ID (GUID) uniquely identifying the version of a provider.</summary>
		public Guid m_ProviderVersionId;

		/// <summary>Class identifier of the component registered in the local machine's COM catalog.</summary>
		public Guid m_ClassId;
	}

	/// <summary>The <c>VSS_SNAPSHOT_PROP</c> structure contains the properties of a shadow copy or shadow copy set.</summary>
	/// <remarks>
	/// <para>
	/// Requesters typically obtain a pointer to a <c>VSS_SNAPSHOT_PROP</c> structure by using the
	/// IVssBackupComponents::GetSnapshotProperties method or the IVssSoftwareSnapshotProvider::GetSnapshotProperties method. When this
	/// structure is no longer needed, the caller is responsible for freeing it by using the VssFreeSnapshotProperties function.
	/// </para>
	/// <para>
	/// The shadow copy device object contained in <c>m_pwszSnapshotDeviceObject</c> is used to address files on the shadow copy of the
	/// volume. For instance, if the original volume has a file with a path of "\topleveldir\File.html", then the path to the shadow copy of
	/// the file is " <c>m_pwszSnapshotDeviceObject</c>"+"\topleveldir\File.html".
	/// </para>
	/// <para>
	/// When a shadow copy is exposed as a share, the value of <c>m_pwszExposedName</c> will be the share name. When the shadow copy is
	/// exposed as a drive letter or mounted folder, the shadow copy <c>m_pwszExposedName</c> is a drive letter followed by a colon—for
	/// example, "X:" or a mounted folder path (for example, "Y:\MountX").
	/// </para>
	/// <para>
	/// If a shadow copy is exposed as a drive letter or mounted folder, then (as with mounting any device) the entire shadow copy starting
	/// at its root will be exposed at the mount point. In this case, <c>m_pwszExposedPath</c> will be null.
	/// </para>
	/// <para>
	/// If the shadow copy is exposed as a share, the value of <c>m_pwszExposedPath</c> will be the path to the portion of the volume that
	/// is shared.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/vss/ns-vss-vss_snapshot_prop typedef struct _VSS_SNAPSHOT_PROP { VSS_ID
	// m_SnapshotId; VSS_ID m_SnapshotSetId; LONG m_lSnapshotsCount; VSS_PWSZ m_pwszSnapshotDeviceObject; VSS_PWSZ m_pwszOriginalVolumeName;
	// VSS_PWSZ m_pwszOriginatingMachine; VSS_PWSZ m_pwszServiceMachine; VSS_PWSZ m_pwszExposedName; VSS_PWSZ m_pwszExposedPath; VSS_ID
	// m_ProviderId; LONG m_lSnapshotAttributes; VSS_TIMESTAMP m_tsCreationTimestamp; VSS_SNAPSHOT_STATE m_eStatus; } VSS_SNAPSHOT_PROP, *PVSS_SNAPSHOT_PROP;
	[PInvokeData("vss.h", MSDNShortId = "NS:vss._VSS_SNAPSHOT_PROP")]
	[StructLayout(LayoutKind.Sequential)]
	public struct VSS_SNAPSHOT_PROP
	{
		/// <summary>A VSS_ID (GUID) uniquely identifying the shadow copy identifier.</summary>
		public Guid m_SnapshotId;

		/// <summary>A VSS_ID (GUID) uniquely identifying the shadow copy set containing the shadow copy.</summary>
		public Guid m_SnapshotSetId;

		/// <summary>
		/// <para>
		/// Number of volumes included with the shadow copy in the shadow copy set when it was created. Because it is possible for
		/// applications to release individual shadow copies without releasing the shadow copy set, at any given time the number of shadow
		/// copies in the shadow copy set may be less than <c>m_LSnapshotsCount</c>.
		/// </para>
		/// <para>The maximum number of shadow-copied volumes permitted in a shadow copy set is 64.</para>
		/// </summary>
		public int m_lSnapshotsCount;

		/// <summary>
		/// <para>
		/// String containing the name of the device object for the shadow copy of the volume. The device object can be thought of as the
		/// root of a shadow copy of a volume. Requesters will use this device name when accessing files on a shadow-copied volume that it
		/// needs to work with.
		/// </para>
		/// <para>The device name does not contain a trailing "".</para>
		/// </summary>
		public StrPtrUni m_pwszSnapshotDeviceObject;

		/// <summary>String containing the name of the volume that had been shadow copied.</summary>
		public StrPtrUni m_pwszOriginalVolumeName;

		/// <summary>String containing the name of the machine containing the original volume.</summary>
		public StrPtrUni m_pwszOriginatingMachine;

		/// <summary>String containing the name of the machine running the Volume Shadow Copy Service that created the shadow copy.</summary>
		public StrPtrUni m_pwszServiceMachine;

		/// <summary>
		/// String containing the name of the shadow copy when it is exposed. This is a drive letter or mounted folder (if the shadow copy
		/// is exposed as a local volume), or a share name. Corresponds to the wszExpose parameter of the
		/// IVssBackupComponents::ExposeSnapshot method.
		/// </summary>
		public StrPtrUni m_pwszExposedName;

		/// <summary>
		/// String indicating the portion of the shadow copy of a volume made available if it is exposed as a share. Corresponds to the
		/// wszPathFromRoot parameter of the IVssBackupComponents::ExposeSnapshot method.
		/// </summary>
		public StrPtrUni m_pwszExposedPath;

		/// <summary>A VSS_ID (GUID) uniquely identifying the provider used to create this shadow copy.</summary>
		public Guid m_ProviderId;

		/// <summary>
		/// The attributes of the shadow copy expressed as a bit mask (or bitwise OR) of members of the _VSS_VOLUME_SNAPSHOT_ATTRIBUTES enumeration.
		/// </summary>
		public VSS_VOLUME_SNAPSHOT_ATTRIBUTES m_lSnapshotAttributes;

		/// <summary>
		/// Time stamp indicating when the shadow copy was created. The exact time is determined by the provider. See VSS_TIMESTAMP for
		/// information about the time-stamp format.
		/// </summary>
		public FILETIME m_tsCreationTimestamp;

		/// <summary>Current shadow copy creation status. See VSS_SNAPSHOT_STATE.</summary>
		public VSS_SNAPSHOT_STATE m_eStatus;
	}
}