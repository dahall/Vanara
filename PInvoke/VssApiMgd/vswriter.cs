using System.Collections.Generic;

namespace Vanara.PInvoke.VssApi;

/// <summary>
/// <para>
/// The <c>VSS_ALTERNATE_WRITER_STATE</c> enumeration is used to indicate whether a given writer has an associated alternate writer. The
/// existence of an alternate writer is set during writer initialization by CVssWriter::Initialize.
/// </para>
/// <para>Currently, the only supported value for a method taking a <c>VSS_ALTERNATE_WRITER_STATE</c> argument is <c>VSS_AWS_NO_ALTERNATE_WRITER</c>.</para>
/// </summary>
// https://docs.microsoft.com/en-us/windows/win32/api/vswriter/ne-vswriter-vss_alternate_writer_state typedef enum
// VSS_ALTERNATE_WRITER_STATE { VSS_AWS_UNDEFINED, VSS_AWS_NO_ALTERNATE_WRITER, VSS_AWS_ALTERNATE_WRITER_EXISTS,
// VSS_AWS_THIS_IS_ALTERNATE_WRITER } ;
[PInvokeData("vswriter.h", MSDNShortId = "NE:vswriter.VSS_ALTERNATE_WRITER_STATE")]
public enum VSS_ALTERNATE_WRITER_STATE
{
	/// <summary>
	/// <para>No information is available as to the existence of an alternate writer. This value indicates an application</para>
	/// <para>error. This enumeration value is reserved for future use.</para>
	/// </summary>
	VSS_AWS_UNDEFINED = 0,

	/// <summary>A given writer does not have an alternate writer.</summary>
	VSS_AWS_NO_ALTERNATE_WRITER,

	/// <summary>
	/// <para>An alternate writer exists. This alternate writer runs when the writer is not available. This enumeration</para>
	/// <para>value is reserved for future use.</para>
	/// </summary>
	VSS_AWS_ALTERNATE_WRITER_EXISTS,

	/// <summary>The writer in question is an alternate writer. This enumeration value is reserved for future use.</summary>
	VSS_AWS_THIS_IS_ALTERNATE_WRITER,
}

/// <summary>
/// The <c>VSS_COMPONENT_FLAGS</c> enumeration is used by writers to indicate support for auto-recovery. These values are used in the
/// <c>dwComponentFlags</c> member of the VSS_COMPONENTINFO structure and the dwComponentFlags parameter of the
/// IVssCreateWriterMetadata::AddComponent method.
/// </summary>
// https://docs.microsoft.com/en-us/windows/win32/api/vswriter/ne-vswriter-vss_component_flags typedef enum VSS_COMPONENT_FLAGS {
// VSS_CF_BACKUP_RECOVERY, VSS_CF_APP_ROLLBACK_RECOVERY, VSS_CF_NOT_SYSTEM_STATE } ;
[PInvokeData("vswriter.h", MSDNShortId = "NE:vswriter.VSS_COMPONENT_FLAGS")]
[Flags]
public enum VSS_COMPONENT_FLAGS
{
	/// <summary>
	/// <para>The writer will need write access to this component after the shadow copy has been created.</para>
	/// <para>This flag can be used together with the</para>
	/// <para>VSS_VOLSNAP_ATTR_TRANSPORTABLE</para>
	/// <para>value of the</para>
	/// <para>_VSS_VOLUME_SNAPSHOT_ATTRIBUTES</para>
	/// <para>enumeration if the VSS hardware provider supports LUN masking.</para>
	/// <para>Windows Vista and Windows Server 2003 with SP1:</para>
	/// <para>This flag is incompatible with</para>
	/// <para>VSS_VOLSNAP_ATTR_TRANSPORTABLE</para>
	/// <para>.</para>
	/// <para>This flag is not supported for express writers.</para>
	/// </summary>
	VSS_CF_BACKUP_RECOVERY = 0x01,

	/// <summary>
	/// <para>If this is a rollback shadow copy</para>
	/// <para>(see the</para>
	/// <para>VSS_VOLSNAP_ATTR_ROLLBACK_RECOVERY</para>
	/// <para>value of the</para>
	/// <para>_VSS_VOLUME_SNAPSHOT_ATTRIBUTES</para>
	/// <para>enumeration), the writer for this</para>
	/// <para>component will need write access to this component after the shadow copy has been created.</para>
	/// <para>This flag can be used together with the</para>
	/// <para>VSS_VOLSNAP_ATTR_TRANSPORTABLE</para>
	/// <para>value of the</para>
	/// <para>_VSS_VOLUME_SNAPSHOT_ATTRIBUTES</para>
	/// <para>enumeration if the VSS hardware provider supports LUN masking.</para>
	/// <para>Windows Vista and Windows Server 2003 with SP1:</para>
	/// <para>This flag is incompatible with</para>
	/// <para>VSS_VOLSNAP_ATTR_TRANSPORTABLE</para>
	/// <para>.</para>
	/// <para>This flag is not supported for express writers.</para>
	/// </summary>
	VSS_CF_APP_ROLLBACK_RECOVERY = 0x02,

	/// <summary>
	/// <para>This component is not part of system state.</para>
	/// <para>Windows Server 2003 with SP1:</para>
	/// <para>This value is not supported until Windows Vista.</para>
	/// </summary>
	VSS_CF_NOT_SYSTEM_STATE = 0x04,
}

/// <summary>
/// The <c>VSS_COMPONENT_TYPE</c> enumeration is used by both the requester and the writer to specify the type of component being used
/// with a shadow copy backup operation.
/// </summary>
/// <remarks>
/// <para>A writer sets a component's type when it adds the component to its Writer Metadata Document using IVssCreateWriterMetadata::AddComponent.</para>
/// <para>
/// Writers and requesters can find the type information of components selected for inclusion in a Backup Components Document through
/// calls to IVssComponent::GetComponentType to return a component type directly.
/// </para>
/// <para>A requester can obtain the type of any component in a given writer's Writer Metadata Document by doing the following:</para>
/// <list type="number">
/// <item>
/// <term>Using IVssExamineWriterMetadata::GetComponent to obtain a IVssWMComponent interface</term>
/// </item>
/// <item>
/// <term>Using IVssWMComponent::GetComponentInfo to return a VSS_COMPONENTINFO structure</term>
/// </item>
/// <item>
/// <term>Examining the <c>Type</c> member of the VSS_COMPONENTINFO object</term>
/// </item>
/// </list>
/// </remarks>
// https://docs.microsoft.com/en-us/windows/win32/api/vswriter/ne-vswriter-vss_component_type typedef enum VSS_COMPONENT_TYPE {
// VSS_CT_UNDEFINED, VSS_CT_DATABASE, VSS_CT_FILEGROUP } ;
[PInvokeData("vswriter.h", MSDNShortId = "NE:vswriter.VSS_COMPONENT_TYPE")]
public enum VSS_COMPONENT_TYPE
{
	/// <summary>
	/// <para>Undefined component type.</para>
	/// <para>This value indicates an application error.</para>
	/// </summary>
	VSS_CT_UNDEFINED = 0,

	/// <summary>Database component.</summary>
	VSS_CT_DATABASE,

	/// <summary>File group component. This is any component other than a database.</summary>
	VSS_CT_FILEGROUP,
}

/// <summary>
/// The <c>VSS_FILE_RESTORE_STATUS</c> enumeration defines the set of statuses of a file restore operation performed on the files
/// managed by a selected component or component set (see Working with Selectability and Logical Paths for information on selecting components).
/// </summary>
/// <remarks>
/// <para>
/// If any files managed by a component or, if it defines a component set, any of its subcomponents cannot be restored, the value of
/// <c>VSS_FILE_RESTORE_STATUS</c> must indicate an error.
/// </para>
/// <para>Both the values <c>VSS_RS_FAILED</c> and <c>VSS_RS_NONE</c> indicate that a restore operation did not complete successfully:</para>
/// <list type="bullet">
/// <item>
/// <term>
/// <c>VSS_RS_NONE</c> indicates a restore failed gracefully: no files from the component or its subcomponents were restored to disk.
/// </term>
/// </item>
/// <item>
/// <term><c>VSS_RS_FAIL</c> indicates a restore failed gracelessly, leaving some files restored to disk and some files unrestored.</term>
/// </item>
/// </list>
/// <para>
/// Requesters must set a restore status (using IVssBackupComponents::SetFileRestoreStatus) for every component (and its component set,
/// if it defines one) explicitly added for restore to the Backup Components Document (using either
/// IVssBackupComponents::SetSelectedForRestore or IVssBackupComponents::AddRestoreSubcomponent).
/// </para>
/// <para>
/// Writers and requesters can query the status of the restoration of a component or a component set defined by a selectable component
/// with calls to IVssComponent::GetFileRestoreStatus. If this method is called for a component that was not selected, the value
/// returned is undefined.
/// </para>
/// </remarks>
// https://docs.microsoft.com/en-us/windows/win32/api/vswriter/ne-vswriter-vss_file_restore_status typedef enum VSS_FILE_RESTORE_STATUS
// { VSS_RS_UNDEFINED, VSS_RS_NONE, VSS_RS_ALL, VSS_RS_FAILED } ;
[PInvokeData("vswriter.h", MSDNShortId = "NE:vswriter.VSS_FILE_RESTORE_STATUS")]
public enum VSS_FILE_RESTORE_STATUS
{
	/// <summary>
	/// <para>The restore state is undefined.</para>
	/// <para>This value indicates an error, or indicates that a restore operation has not yet started.</para>
	/// <para>This value is not supported for components that are owned by express writers.</para>
	/// </summary>
	VSS_RS_UNDEFINED = 0,

	/// <summary>
	/// <para>No files were restored.</para>
	/// <para>This value indicates an error in restoration that did not leave any restored files on disk.</para>
	/// </summary>
	VSS_RS_NONE,

	/// <summary>
	/// <para>All files were restored. This value indicates success and should be set for each component that was</para>
	/// <para>restored successfully.</para>
	/// </summary>
	VSS_RS_ALL,

	/// <summary>
	/// <para>The restore process failed.</para>
	/// <para>This value indicates an error in restoration that did leave some restored files on disk. This means the</para>
	/// <para>components on disk are now corrupt.</para>
	/// </summary>
	VSS_RS_FAILED,
}

/// <summary>
/// <para>
/// The <c>VSS_RESTORE_TARGET</c> enumeration is used by a writer at restore time to indicate how all the files included in a selected
/// component, and all the files in any component set it defines, are to be restored. (See Working with Selectability and Logical Paths
/// for information on selecting components.)
/// </para>
/// <para>Setting a restore target modifies or overrides the restore method set during backup (see VSS_RESTOREMETHOD_ENUM).</para>
/// </summary>
/// <remarks>
/// <para>A target of <c>VSS_RT_UNDEFINED</c> indicates an error state.</para>
/// <para>
/// At backup time, writers set the default restore behavior by indicating a restore method (VSS_RESTOREMETHOD_ENUM) set with IVssCreateWriterMetadata::SetRestoreMethod.
/// </para>
/// <para>
/// If a writer does not explicitly set the restore target of a component and any component set it defines, by default it is set to <c>VSS_RT_ORIGINAL</c>.
/// </para>
/// <para>
/// At restore time, a <c>VSS_RESTORE_TARGET</c> value other than <c>VSS_RT_ORIGINAL</c> overrides the value of the originally specified
/// restore method specified by VSS_RESTOREMETHOD_ENUM and set by IVssCreateWriterMetadata::SetRestoreMethod.
/// </para>
/// <para>
/// Only writers (using IVssComponent::SetRestoreTarget) can set a restore target ( <c>VSS_RESTORE_TARGET</c>) and change how files are
/// restored overriding the restore method).
/// </para>
/// <para>Requesters and writers can access the current restore target through IVssComponent::GetRestoreTarget.</para>
/// <para>
/// A restore target of <c>VSS_RT_ORIGINAL</c> does not mean that files should be restored to their original location, but that the
/// originally specified restore method (VSS_RESTOREMETHOD_ENUM) must be respected. For instance, if a writer set a restore method of
/// <c>VSS_RME_RESTORE_TO_ALTERNATE_LOCATION</c> for a selected component and the restore target is <c>VSS_RT_ORIGINAL</c>, files should
/// be restored to the alternate location defined by the writer.
/// </para>
/// <para>
/// (In this example, if a writer has failed to define alternate location mappings, then it is a writer error, and the requester should
/// report it.)
/// </para>
/// <para>
/// A restore target of <c>VSS_RT_ALTERNATE</c> without an alternate location mapping defined constitutes a writer error, and the
/// requester should report it as such.
/// </para>
/// <para>See Non-Default Backup And Restore Locations for more information.</para>
/// </remarks>
// https://docs.microsoft.com/en-us/windows/win32/api/vswriter/ne-vswriter-vss_restore_target typedef enum VSS_RESTORE_TARGET {
// VSS_RT_UNDEFINED, VSS_RT_ORIGINAL, VSS_RT_ALTERNATE, VSS_RT_DIRECTED, VSS_RT_ORIGINAL_LOCATION } ;
[PInvokeData("vswriter.h", MSDNShortId = "NE:vswriter.VSS_RESTORE_TARGET")]
public enum VSS_RESTORE_TARGET
{
	/// <summary>
	/// <para>No target is defined.</para>
	/// <para>This value indicates an error on the part of the writer.</para>
	/// <para>This value is not supported for express writers.</para>
	/// </summary>
	VSS_RT_UNDEFINED = 0,

	/// <summary>
	/// <para>This is the default restore target.</para>
	/// <para>This value indicates that the restoration of the files included in a selected component (or the component set</para>
	/// <para>defined by that component) should proceed according to the original restore method specified at backup time by</para>
	/// <para>a</para>
	/// <para>VSS_RESTOREMETHOD_ENUM</para>
	/// <para>value.</para>
	/// </summary>
	VSS_RT_ORIGINAL,

	/// <summary>
	/// <para>The files are restored to a location determined from an existing alternate location mapping.</para>
	/// <para>The restore target should be set to</para>
	/// <para>VSS_RT_ALTERNATE</para>
	/// <para>only when alternate location</para>
	/// <para>mappings have been set for all the files managed by a selected component or component set.</para>
	/// <para>This value is not supported for express writers.</para>
	/// </summary>
	VSS_RT_ALTERNATE,

	/// <summary>
	/// <para>Use directed targeting by the writer at restore time to restore a file.</para>
	/// <para>Directed targeting allows a writer to control, on a file-by-file basis, how a file is</para>
	/// <para>restored—indicating how much of a file is to be restored and into which files the</para>
	/// <para>backed-up file is to be restored.</para>
	/// <para>This value is not supported for express writers.</para>
	/// </summary>
	VSS_RT_DIRECTED,

	/// <summary>
	/// <para>The files are restored to the location at which they were at backup time, even if the original</para>
	/// <para>restore method that was specified at backup time was</para>
	/// <para>VSS_RME_RESTORE_TO_ALTERNATE_LOCATION</para>
	/// <para>.</para>
	/// <para>Windows Server 2003 and Windows XP:</para>
	/// <para>This value is not supported.</para>
	/// <para>This value is not supported for express writers.</para>
	/// </summary>
	VSS_RT_ORIGINAL_LOCATION,
}

/// <summary>
/// <para>
/// The <c>VSS_RESTOREMETHOD_ENUM</c> enumeration is used by a writer at backup time to specify through its Writer Metadata Document the
/// default file restore method to be used with all the files in all the components it manages.
/// </para>
/// <para>
/// The restore method is writer-wide and is also referred to as the original restore target and indicated by a VSS_RESTORE_TARGET value
/// of <c>VSS_RT_ORIGINAL</c>.
/// </para>
/// </summary>
/// <remarks>
/// <para>
/// A writer sets the restore method in the Writer Metadata Document by calling IVssCreateWriterMetadata::SetRestoreMethod during backup
/// to specify its desired restore method in its metadata.
/// </para>
/// <para>
/// A requester retrieves a writer's requested restore method by calling IVssExamineWriterMetadata::GetRestoreMethod and acts accordingly.
/// </para>
/// <para>The restore method applies to all files in all components of a given writer.</para>
/// <para>
/// The restore method may be overridden on a component-by-component basis at restore time if a writer sets a VSS_RESTORE_TARGET value
/// other than <c>VSS_RT_ORIGINAL</c> with IVssComponent::SetRestoreTarget.
/// </para>
/// <para>
/// A restore method of <c>VSS_RME_RESTORE_TO_ALTERNATE_LOCATION</c> without an alternate location mapping defined constitutes a writer
/// error, and the requester should report it as such.
/// </para>
/// <para>
/// When a restore method requires a check on the status of files currently on disk ( <c>VSS_RME_RESTORE_IF_NOT_THERE</c>,
/// <c>VSS_RME_RESTORE_IF_CAN_REPLACE</c>, or <c>VSS_RME_RESTORE_AT_REBOOT_IF_CANNOT_REPLACE</c>), ideally, you should use file I/O
/// operations to verify that an entire component can be restored before actually proceeding with the restore.
/// </para>
/// <para>The safest way to do this would be to open exclusively (no-sharing) all the target files with CreateFile prior to the restore.</para>
/// <para>In the case of <c>VSS_RME_RESTORE_IF_NOT_THERE</c>, a creation disposition flag of <c>CREATE_NEW</c> should also be set.</para>
/// <para>
/// If the open operations succeed, the restore can proceed and should use the handles returned by CreateFile to actually write restored
/// data to disk.
/// </para>
/// <para>
/// If not, an error can be returned—depending on the method—or alternate location mapping checked and (if it is available) used, or the
/// components files staged for restore at the next reboot.
/// </para>
/// <para>This may be a problem for very large components (some of which may have thousands of files), due to system overhead.</para>
/// <para>In this case, an available though less reliable option is to do the following:</para>
/// <list type="number">
/// <item>
/// <term>Copy all files currently on disk and to be restored to a temporary cache.</term>
/// </item>
/// <item>
/// <term>
/// Attempt to replace the files currently on disk with the backed-up files (which could be either on disk in a second temporary area,
/// or on a backup medium).
/// </term>
/// </item>
/// <item>
/// <term>
/// If any files fail to restore, then terminate the restore operation and copy the original files back from their temporary location
/// and proceed with alternate location mapping or restore on reboot operations.
/// </term>
/// </item>
/// </list>
/// <para>For more information on backup and restore file locations under VSS, see Non-Default Backup And Restore Locations.</para>
/// </remarks>
// https://docs.microsoft.com/en-us/windows/win32/api/vswriter/ne-vswriter-vss_restoremethod_enum typedef enum VSS_RESTOREMETHOD_ENUM {
// VSS_RME_UNDEFINED, VSS_RME_RESTORE_IF_NOT_THERE, VSS_RME_RESTORE_IF_CAN_REPLACE, VSS_RME_STOP_RESTORE_START,
// VSS_RME_RESTORE_TO_ALTERNATE_LOCATION, VSS_RME_RESTORE_AT_REBOOT, VSS_RME_RESTORE_AT_REBOOT_IF_CANNOT_REPLACE, VSS_RME_CUSTOM,
// VSS_RME_RESTORE_STOP_START } ;
[PInvokeData("vswriter.h", MSDNShortId = "NE:vswriter.VSS_RESTOREMETHOD_ENUM")]
public enum VSS_RESTOREMETHOD_ENUM
{
	/// <summary>
	/// <para>No restore method is defined.</para>
	/// <para>This indicates an error on the part of the writer.</para>
	/// <para>This value is not supported for express writers.</para>
	/// </summary>
	VSS_RME_UNDEFINED = 0,

	/// <summary>
	/// <para>The requester should restore the files of a selected component or component set only if there are no versions of</para>
	/// <para>those files currently on the disk.</para>
	/// <para>Unless alternate location mappings are defined for file restoration, if a version of any file managed by a</para>
	/// <para>selected component or component set is currently on the disk, none of the files managed by the selected</para>
	/// <para>component or component set should be restored.</para>
	/// <para>If a file's alternate location mapping is defined, and a version of the files is present on disk at the</para>
	/// <para>original location, files should be written to the alternate location only if no version of the file exists at</para>
	/// <para>the alternate location.</para>
	/// </summary>
	VSS_RME_RESTORE_IF_NOT_THERE,

	/// <summary>
	/// <para>
	/// The requester should restore files of a selected component or component set only if the files currently on the disk can be overwritten.
	/// </para>
	/// <para>Unless alternate location mappings are defined for file restoration, if there is a version of any file that</para>
	/// <para>cannot be overwritten of the selected component or component set on the disk, none of the files managed by the</para>
	/// <para>component or component set should be restored.</para>
	/// <para>If a file's alternate location mapping is defined, files should be written to the alternate location.</para>
	/// </summary>
	VSS_RME_RESTORE_IF_CAN_REPLACE,

	/// <summary>
	/// <para>The requester should perform the restore operation as follows:</para>
	/// <list type="number">
	/// <item>
	/// <term>Send the PreRestore event and wait for all writers to process it.</term>
	/// </item>
	/// <item>
	/// <term>Stop the service.</term>
	/// </item>
	/// <item>
	/// <term>Restore the files to their original locations.</term>
	/// </item>
	/// <item>
	/// <term>Restart the service.</term>
	/// </item>
	/// <item>
	/// <term>Send the PostRestore event and wait for all writers to process it.</term>
	/// </item>
	/// </list>
	/// <para>The service to be stopped is specified the writer beforehand when it calls the</para>
	/// <para>IVssCreateWriterMetadata::SetRestoreMethod</para>
	/// <para>method. The requester can obtain the name of the service by calling the</para>
	/// <para>IVssExamineWriterMetadata::GetRestoreMethod</para>
	/// <para>method.</para>
	/// <para>Note that if the writer is hosted in the service that is being stopped, that writer will not receive the</para>
	/// <para>PostRestore</para>
	/// <para>event, because the writer instance ID changes when the service is stopped and restarted.</para>
	/// </summary>
	VSS_RME_STOP_RESTORE_START,

	/// <summary>
	/// <para>The requester should restore the files of the selected component or component set to the location specified by the</para>
	/// <para>alternate location mapping specified in the writer component metadata file. (See</para>
	/// <para>IVssCreateWriterMetadata::AddAlternateLocationMapping</para>
	/// <para>,</para>
	/// <para>IVssComponent::GetAlternateLocationMapping</para>
	/// <para>,</para>
	/// <para>IVssExamineWriterMetadata::GetAlternateLocationMapping</para>
	/// <para>,</para>
	/// <para>and</para>
	/// <para>IVssWMFiledesc::GetAlternateLocation</para>
	/// <para>.)</para>
	/// <para>This value is not supported for express writers.</para>
	/// </summary>
	VSS_RME_RESTORE_TO_ALTERNATE_LOCATION,

	/// <summary>
	/// <para>The requester should restore the files of a selected component or component set after the computer is restarted.</para>
	/// <para>The files to be restored should be copied to a temporary location, and the requester should use</para>
	/// <para>MoveFileEx</para>
	/// <para>with the</para>
	/// <para>MOVEFILE_DELAY_UNTIL_REBOOT</para>
	/// <para>flag to complete the restoration of these files to their</para>
	/// <para>proper location after the computer is restarted.</para>
	/// </summary>
	VSS_RME_RESTORE_AT_REBOOT,

	/// <summary>
	/// <para>If possible, the requester should restore the files of the selected component or component set to their correct</para>
	/// <para>location immediately.</para>
	/// <para>If there are versions of any of the files managed by the selected component or component set on the disk that</para>
	/// <para>cannot be overwritten, then all the files managed by the selected component or component set should be restored</para>
	/// <para>after the computer is restarted.</para>
	/// <para>In this case, files to be restored should be copied to a temporary location on disk, and the requester should</para>
	/// <para>use</para>
	/// <para>MoveFileEx</para>
	/// <para>with the</para>
	/// <para>MOVEFILE_DELAY_UNTIL_REBOOT</para>
	/// <para>flag to complete the restoration of these files to their</para>
	/// <para>proper location after the computer is restarted.</para>
	/// </summary>
	VSS_RME_RESTORE_AT_REBOOT_IF_CANNOT_REPLACE,

	/// <summary>
	/// <para>The requester should use a custom restore method to restore the files that are managed by the selected</para>
	/// <para>component or component set.</para>
	/// <para>A custom restore may use file retrieval API functions or protocols that are private to a given writer</para>
	/// <para>application. Such a restore need not use the information in the writer component metadata file. (See</para>
	/// <para>Custom Backups and Restores</para>
	/// <para>for more</para>
	/// <para>information.)</para>
	/// <para>This value is not supported for express writers.</para>
	/// </summary>
	VSS_RME_CUSTOM,

	/// <summary>
	/// <para>The requester should perform the restore operation as follows:</para>
	/// <list type="number">
	/// <item>
	/// <term>Send the PreRestore event and wait for all writers to process it.</term>
	/// </item>
	/// <item>
	/// <term>Restore the files to their original locations.</term>
	/// </item>
	/// <item>
	/// <term>Send the PostRestore event and wait for all writers to process it.</term>
	/// </item>
	/// <item>
	/// <term>Stop the service.</term>
	/// </item>
	/// <item>
	/// <term>Restart the service.</term>
	/// </item>
	/// </list>
	/// <para>The service to be stopped is specified by the writer beforehand when it calls the</para>
	/// <para>IVssCreateWriterMetadata::SetRestoreMethod</para>
	/// <para>method. The requester can obtain the name of the service by calling the</para>
	/// <para>IVssExamineWriterMetadata::GetRestoreMethod</para>
	/// <para>method.</para>
	/// </summary>
	VSS_RME_RESTORE_STOP_START,
}

/// <summary>The <c>VSS_SOURCE_TYPE</c> enumeration specifies the type of data that a writer manages.</summary>
/// <remarks>
/// <para>
/// The source type of the data that a writer manages is specified when it initializes its cooperation with the shadow copy mechanism
/// through a call to CVssWriter::Initialize.
/// </para>
/// <para>Information about the source type of the data that a writer manages can be retrieved through its metadata using IVssExamineWriterMetadata::GetIdentity.</para>
/// </remarks>
// https://docs.microsoft.com/en-us/windows/win32/api/vswriter/ne-vswriter-vss_source_type typedef enum VSS_SOURCE_TYPE {
// VSS_ST_UNDEFINED, VSS_ST_TRANSACTEDDB, VSS_ST_NONTRANSACTEDDB, VSS_ST_OTHER } ;
[PInvokeData("vswriter.h", MSDNShortId = "NE:vswriter.VSS_SOURCE_TYPE")]
public enum VSS_SOURCE_TYPE
{
	/// <summary>
	/// <para>The source of the data is not known.</para>
	/// <para>This indicates a writer error, and the requester should report it.</para>
	/// </summary>
	VSS_ST_UNDEFINED = 0,

	/// <summary>The source of the data is a database that supports transactions, such as Microsoft SQL Server.</summary>
	VSS_ST_TRANSACTEDDB,

	/// <summary>The source of the data is a database that does not support transactions.</summary>
	VSS_ST_NONTRANSACTEDDB,

	/// <summary>
	/// <para>Unclassified source type—data will be in a file group.</para>
	/// <para>This is the default source type.</para>
	/// </summary>
	VSS_ST_OTHER,
}

/// <summary>
/// The <c>VSS_SUBSCRIBE_MASK</c> enumeration is used by a writer when subscribing to the VSS service. It indicates the events that the
/// writer is willing to receive.
/// </summary>
/// <remarks>
/// <para>A bit mask (or bitwise OR) of <c>VSS_SUBSCRIBE_MASK</c> values is used as an argument only to CVssWriter::Subscribe.</para>
/// <para>Currently, the only supported <c>VSS_SUBSCRIBE_MASK</c> bit mask is ( <c>VSS_SM_BACKUP_EVENTS_FLAG</c> | <c>VSS_SM_RESTORE_EVENTS_FLAG</c>).</para>
/// </remarks>
// https://docs.microsoft.com/en-us/windows/win32/api/vswriter/ne-vswriter-vss_subscribe_mask typedef enum VSS_SUBSCRIBE_MASK {
// VSS_SM_POST_SNAPSHOT_FLAG, VSS_SM_BACKUP_EVENTS_FLAG, VSS_SM_RESTORE_EVENTS_FLAG, VSS_SM_IO_THROTTLING_FLAG, VSS_SM_ALL_FLAGS } ;
[PInvokeData("vswriter.h", MSDNShortId = "NE:vswriter.VSS_SUBSCRIBE_MASK")]
[Flags]
public enum VSS_SUBSCRIBE_MASK : uint
{
	/// <summary>
	/// <para>This enumeration value is reserved for future use.</para>
	/// <para>Specifies that the writer expects to be notified after the shadow copy it is participating in has completed.</para>
	/// <para>It will then call</para>
	/// <para>CVssWriter::OnPostSnapshot</para>
	/// <para>.</para>
	/// </summary>
	VSS_SM_POST_SNAPSHOT_FLAG = 0x01,

	/// <summary>
	/// <para>Currently,</para>
	/// <para>VSS_SM_BACKUP_EVENTS_FLAG</para>
	/// <para>can be used as an argument only when</para>
	/// <para>combined through a bitwise OR with</para>
	/// <para>VSS_SM_RESTORE_EVENTS_FLAG</para>
	/// <para>.</para>
	/// <para>Specifies that the writer can expect to receive the following events:</para>
	/// <list type="bullet">
	/// <item>
	/// <term>A PrepareForSnapshot event when the writer will call CVssWriter::OnPrepareSnapshot.</term>
	/// </item>
	/// <item>
	/// <term>A PrepareForBackup event when the writer will call CVssWriter::OnPrepareBackup.</term>
	/// </item>
	/// <item>
	/// <term>A Freeze event when the writer will call CVssWriter::OnFreeze.</term>
	/// </item>
	/// <item>
	/// <term>A BackupComplete event when the writer will call CVssWriter::OnBackupComplete.</term>
	/// </item>
	/// <item>
	/// <term>A Thaw event when the writer will call CVssWriter::OnThaw.</term>
	/// </item>
	/// <item>
	/// <term>A PostSnapshot event when the writer will call CVssWriter::OnPostSnapshot.</term>
	/// </item>
	/// </list>
	/// </summary>
	VSS_SM_BACKUP_EVENTS_FLAG = 0x02,

	/// <summary>
	/// <para>Currently,</para>
	/// <para>VSS_SM_RESTORE_EVENTS_FLAG</para>
	/// <para>can be used as an argument only when</para>
	/// <para>combined through a bitwise OR with</para>
	/// <para>VSS_SM_BACKUP_EVENTS_FLAG</para>
	/// <para>.</para>
	/// <para>Specifies that the writer can expect to receive the following events:</para>
	/// <list type="bullet">
	/// <item>
	/// <term>A PreRestore event when the writer will call CVssWriter::OnPreRestore.</term>
	/// </item>
	/// <item>
	/// <term>A PostRestore event when the writer will call CVssWriter::OnPostRestore.</term>
	/// </item>
	/// </list>
	/// </summary>
	VSS_SM_RESTORE_EVENTS_FLAG = 0x04,

	/// <summary>This enumeration value is reserved for future use.</summary>
	VSS_SM_IO_THROTTLING_FLAG = 0x08,

	/// <summary>
	/// <para>This enumeration value is reserved for future use.</para>
	/// <para>Specifies that the writer expects to be notified for all events.</para>
	/// </summary>
	VSS_SM_ALL_FLAGS = 0xFFFFFFFF,
}

/// <summary>
/// The <c>VSS_USAGE_TYPE</c> enumeration specifies how the host system uses the data managed by a writer involved in a VSS operation.
/// </summary>
/// <remarks>
/// <para>
/// The usage type of the data that a writer manages is specified when it initializes its cooperation with the shadow copy mechanism
/// through CVssWriter::Initialize.
/// </para>
/// <para>Information about the usage type of the data that a writer manages can be retrieved through its metadata using IVssExamineWriterMetadata::GetIdentity.</para>
/// <para>
/// Requester applications that are interested in backing up system state should look for writers with the
/// <c>VSS_UT_BOOTABLESYSTEMSTATE</c> or <c>VSS_UT_SYSTEMSERVICE</c> usage type.
/// </para>
/// </remarks>
// https://docs.microsoft.com/en-us/windows/win32/api/vswriter/ne-vswriter-vss_usage_type typedef enum VSS_USAGE_TYPE {
// VSS_UT_UNDEFINED, VSS_UT_BOOTABLESYSTEMSTATE, VSS_UT_SYSTEMSERVICE, VSS_UT_USERDATA, VSS_UT_OTHER } ;
[PInvokeData("vswriter.h", MSDNShortId = "NE:vswriter.VSS_USAGE_TYPE")]
public enum VSS_USAGE_TYPE
{
	/// <summary>
	/// <para>The usage type is not known.</para>
	/// <para>This indicates an error on the part of the writer.</para>
	/// </summary>
	VSS_UT_UNDEFINED = 0,

	/// <summary>The data stored by the writer is part of the bootable system state.</summary>
	VSS_UT_BOOTABLESYSTEMSTATE,

	/// <summary>The writer either stores data used by a system service or is a system service itself.</summary>
	VSS_UT_SYSTEMSERVICE,

	/// <summary>The data is user data.</summary>
	VSS_UT_USERDATA,

	/// <summary>Unclassified data.</summary>
	VSS_UT_OTHER,
}

/// <summary>
/// The <c>VSS_WRITERRESTORE_ENUM</c> enumeration is used by a writer to indicate to a requester the conditions under which it will
/// handle events generated during a restore operation.
/// </summary>
/// <remarks>
/// <para>
/// A writer passes a value of <c>VSS_WRITERRESTORE_ENUM</c> to IVssCreateWriterMetadata::SetRestoreMethod to indicate through its
/// metadata how it interacts with requesters during a restore operation.
/// </para>
/// <para>A requester retrieves information about a writer's participation by calling IVssExamineWriterMetadata::GetRestoreMethod.</para>
/// </remarks>
// https://docs.microsoft.com/en-us/windows/win32/api/vswriter/ne-vswriter-vss_writerrestore_enum typedef enum VSS_WRITERRESTORE_ENUM {
// VSS_WRE_UNDEFINED, VSS_WRE_NEVER, VSS_WRE_IF_REPLACE_FAILS, VSS_WRE_ALWAYS } ;
[PInvokeData("vswriter.h", MSDNShortId = "NE:vswriter.VSS_WRITERRESTORE_ENUM")]
public enum VSS_WRITERRESTORE_ENUM
{
	/// <summary>
	/// <para>It is not known whether the writer will perform special operations during the restore operation.</para>
	/// <para>This state indicates a writer error.</para>
	/// </summary>
	VSS_WRE_UNDEFINED = 0,

	/// <summary>The writer does not require restore events.</summary>
	VSS_WRE_NEVER,

	/// <summary>
	/// <para>Indicates that the writer always expects to handle a</para>
	/// <para>PreRestore</para>
	/// <para>(</para>
	/// <para>CvssWriter::OnPreRestore</para>
	/// <para>) event, but expects</para>
	/// <para>to handle a</para>
	/// <para>PostRestore</para>
	/// <para>event</para>
	/// <para>(</para>
	/// <para>CvssWriter::OnPostRestore</para>
	/// <para>) only if a restore</para>
	/// <para>fails when implementing either a</para>
	/// <para>VSS_RME_RESTORE_IF_NOT_THERE</para>
	/// <para>or</para>
	/// <para>VSS_RME_RESTORE_IF_CAN_REPLACE</para>
	/// <para>restore method</para>
	/// <para>(</para>
	/// <para>VSS_RESTOREMETHOD_ENUM</para>
	/// <para>).</para>
	/// </summary>
	VSS_WRE_IF_REPLACE_FAILS,

	/// <summary>The writer always performs special operations during the restore operation.</summary>
	VSS_WRE_ALWAYS,
}

/// <summary>Defines methods to manipulate a list that can be appended.</summary>
/// <typeparam name="T">The type of the elements in the collection.</typeparam>
public interface IAppendOnlyList<T> : IReadOnlyList<T>
{
	/// <summary>Adds an item to the list.</summary>
	/// <param name="item">The object to add to the list.</param>
	void Add(T item);
}

/// <summary>
/// <para>
/// The <c>IVssComponent</c> interface contains methods for examining and modifying information about components contained in a
/// requester's Backup Components Document.
/// </para>
/// <para>
/// <c>IVssComponent</c> objects can be obtained only for those components that have been explicitly added to the Backup Components
/// Document during a backup operation by the IVssBackupComponents::AddComponent method.
/// </para>
/// <para>
/// Information about components explicitly added during a restore operation using IVssBackupComponents::AddRestoreSubcomponent are not
/// available through the <c>IVssComponent</c> interface.
/// </para>
/// <para>
/// Some information common to both components and implicitly selected subcomponents available through <c>IVssComponent</c> objects
/// includes the following:
/// </para>
/// <list type="bullet">
/// <item>
/// <term>Backup time stamp</term>
/// </item>
/// <item>
/// <term>Pre-/post-restore Failure Messages</term>
/// </item>
/// <item>
/// <term>Restore metadata</term>
/// </item>
/// <item>
/// <term>Restore target</term>
/// </item>
/// </list>
/// <para>
/// Some information in the <c>IVssComponent</c> object is on a per-file basis and can refer to files managed either by explicitly
/// selected components or by implicitly selected subcomponents:
/// </para>
/// <list type="bullet">
/// <item>
/// <term>Alternate location mappings</term>
/// </item>
/// <item>
/// <term>Partial files</term>
/// </item>
/// <item>
/// <term>Directed target</term>
/// </item>
/// </list>
/// <para>
/// Other information is not included in the Backup Components Document and can be inferred using the <c>IVssComponent</c> object in
/// conjunction with the appropriate Writer Metadata Documents based on a writer's component hierarchy expressed in the logical paths
/// (see Working with Selectability and Logical Paths).
/// </para>
/// <para>
/// The interface can be used by either a writer or a requester, although certain methods are supported only for writers. In this way, a
/// writer can request changes in a backup or restore operation, such as adding a new target, or learn of requester actions, such as the
/// use of an alternate location.
/// </para>
/// <para>The following methods return an <c>IVssComponent</c> interface:</para>
/// <list type="bullet">
/// <item>
/// <term>IVssWriterComponents::GetComponent</term>
/// </item>
/// <item>
/// <term>IVssWriterComponentsExt::GetComponent</term>
/// </item>
/// </list>
/// </summary>
// https://docs.microsoft.com/en-us/windows/win32/api/vswriter/nl-vswriter-ivsscomponent
[PInvokeData("vswriter.h", MSDNShortId = "NL:vswriter.IVssComponent")]
public interface IVssComponent
{
	/// <summary>
	/// <para>
	/// The <c>GetAdditionalRestores</c> method is used by a writer during incremental or differential restore operations to determine
	/// whether a given component will require additional restore operations to completely retrieve it.
	/// </para>
	/// <para>Either a writer or a requester can call this method.</para>
	/// </summary>
	/// <returns>
	/// The address of a caller-allocated variable that receives <c>true</c> if additional restores will occur for the current
	/// component, or <c>false</c> otherwise.
	/// </returns>
	/// <remarks>
	/// <para>
	/// The value returned by <c>GetAdditionalRestores</c> will be false, unless during a restore operation a requester calls IVssBackupComponents::SetAdditionalRestores.
	/// </para>
	/// <para>
	/// <c>GetAdditionalRestores</c> should be used to check if it is necessary to use more than one backup set to completely restore a
	/// component. A component might first be retrieved by restoring data from a full backup, and then updating that data from one or
	/// more subsequent incremental or differential backups.
	/// </para>
	/// <para>
	/// The <c>GetAdditionalRestores</c> method is typically used by writers that support an explicit recovery mechanism as part of
	/// their PostRestore event handler (CVssWriter::OnPostRestore)—for instance, the Exchange Server, and database applications such as
	/// SQL Server. For these applications, it is often not possible to perform additional differential, incremental, or log restores
	/// after such a recovery is performed.
	/// </para>
	/// <para>
	/// Therefore, if <c>GetAdditionalRestores</c> returns <c>true</c> for a component, such a writer should not execute its explicit
	/// recovery mechanism and should expect that additional differential, incremental, or log restores will be done.
	/// </para>
	/// <para>
	/// When SetAdditionalRestores returns <c>false</c>, then after the restore has finished, when handling the PostRestore event, the
	/// writer can complete its recovery operation and be brought back online.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/vswriter/nf-vswriter-ivsscomponent-getadditionalrestores HRESULT
	// GetAdditionalRestores( [out] bool *pbAdditionalRestores );
	bool AdditionalRestores { get; }

	/// <summary>
	/// The <c>AlternateLocationMappings</c> property is used to return a file set's alternate locations for file restoration. This can
	/// be called by either a writer or a requester.
	/// </summary>
	/// <returns>List of IVssWMFiledesc objects containing the mapping information.</returns>
	/// <remarks>
	/// <para>
	/// The value returned by <c>IVssComponent::GetAlternateLocationMapping</c> should also not be confused with that returned by IVssExamineWriterMetadata::GetAlternateLocationMapping:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>
	/// IVssExamineWriterMetadata::GetAlternateLocationMapping is the alternate location mapping to which a file may be restored if necessary.
	/// </term>
	/// </item>
	/// <item>
	/// <term><c>IVssComponent::GetAlternateLocationMapping</c> is the alternate location to which a file was in fact restored.</term>
	/// </item>
	/// </list>
	/// <para>A file should always be restored to its alternate location mapping if either of the following is true:</para>
	/// <list type="bullet">
	/// <item>
	/// <term>The restore method (set at backup time) is VSS_RME_RESTORE_TO_ALTERNATE_LOCATION.</term>
	/// </item>
	/// <item>
	/// <term>Its restore target was set (at restore time) to VSS_RT_ALTERNATE.</term>
	/// </item>
	/// </list>
	/// <para>In either case, having no alternate location mapping defined constitutes a writer error.</para>
	/// <para>A file can be restored to an alternate location mapping if either of the following is true:</para>
	/// <list type="bullet">
	/// <item>
	/// <term>The restore method is VSS_RME_RESTORE_IF_NOT_THERE and a version of the file is already present on disk.</term>
	/// </item>
	/// <item>
	/// <term>The restore method is VSS_RME_RESTORE_IF_CAN_REPLACE and a version of the file is present on disk and cannot be replaced.</term>
	/// </item>
	/// </list>
	/// <para>
	/// An alternate location mapping is used only during a restore operation and should not be confused with an alternate path, which
	/// is used only during a backup operation.
	/// </para>
	/// <para>
	/// The mapping returned by <c>GetAlternateLocationMapping</c> refers to the alternate location mappings used in the course of
	/// restoring files.
	/// </para>
	/// <para>Alternate location mappings are added to an IVssComponent object by IVssBackupComponents::AddAlternativeLocationMapping.</para>
	/// <para>For more information on backup and restore file locations under VSS, see Non-Default Backup And Restore Locations.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/vswriter/nf-vswriter-ivsscomponent-getalternatelocationmapping HRESULT
	// GetAlternateLocationMapping( [in] UINT iMapping, [out] IVssWMFiledesc **ppFiledesc );
	IReadOnlyList<IVssWMFiledesc> AlternateLocationMappings { get; }

	/// <summary>Determines whether a requester has marked the restore of a component as authoritative for a replicated data store.</summary>
	/// <returns>
	/// The address of a caller-allocated variable that receives <c>true</c> if the restore is authoritative, or <c>false</c> otherwise.
	/// </returns>
	/// <remarks>
	/// <para>
	/// A writer indicates that it supports authoritative restore by setting the <c>VSS_BS_AUTHORITATIVE_RESTORE</c> flag in its backup
	/// schema mask.
	/// </para>
	/// <para>For more information, see Setting VSS Restore Options.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/vswriter/nf-vswriter-ivsscomponentex-getauthoritativerestore HRESULT
	// GetAuthoritativeRestore( [out] bool *pbAuth );
	bool AuthoritativeRestore { get; }

	/// <summary>
	/// <para>
	/// The <c>GetBackupMetadata</c> method retrieves private, writer-specific backup metadata that might have been set during a
	/// PrepareForBackup event by CVssWriter::OnPrepareBackup using IVssComponent::SetBackupMetadata.
	/// </para>
	/// <para>Only a writer can call this method.</para>
	/// </summary>
	/// <returns>
	/// The address of a caller-allocated variable that receives a string containing the backup metadata that was added during an
	/// OnPrepareBackup event.
	/// </returns>
	/// <remarks>
	/// <para>This method can be called at any time depending on the logic of a given writer.</para>
	/// <para>If no backup metadata has been set, <c>GetBackupMetadata</c> returns S_FALSE.</para>
	/// <para>
	/// If the call to <c>GetBackupMetadata</c> is successful, the caller is responsible for freeing the string that is returned in the
	/// pbstrMetadata parameter by calling the SysFreeString function.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/vswriter/nf-vswriter-ivsscomponent-getbackupmetadata HRESULT
	// GetBackupMetadata( [out] BSTR *pbstrData );
	string BackupMetadata { get; set; }

	/// <summary>
	/// <para>
	/// The <c>GetBackupOptions</c> method returns the backup options specified to the writer that manages the currently selected
	/// component or component set by a requester using IVssBackupComponents::SetBackupOptions.
	/// </para>
	/// <para>Either a writer or a requester can call this method.</para>
	/// </summary>
	/// <returns>
	/// The address of a caller-allocated variable that receives a string containing the backup options for the current writer.
	/// </returns>
	/// <remarks>
	/// <para>If no backup options have been set, S_FALSE is returned.</para>
	/// <para>
	/// If the call to <c>GetBackupOptions</c> is successful, the caller is responsible for freeing the string that is returned in the
	/// pbstrBackupOptions parameter by calling the SysFreeString function.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/vswriter/nf-vswriter-ivsscomponent-getbackupoptions HRESULT GetBackupOptions(
	// [out] BSTR *pbstrBackupOptions );
	string BackupOptions { get; }

	/// <summary>
	/// <para>The <c>GetBackupStamp</c> method returns the backup stamp string stored by a writer for a given component.</para>
	/// <para>Either a writer or a requester can call this method.</para>
	/// </summary>
	/// <returns>
	/// The address of a caller-allocated variable that receives a string containing the backup stamp indicating the time at which the
	/// component was backed up.
	/// </returns>
	/// <remarks>
	/// <para>If no backup time stamp has been set, <c>GetBackupStamp</c> returns S_FALSE.</para>
	/// <para>
	/// If the call to <c>GetBackupStamp</c> is successful, the caller is responsible for freeing the string that is returned in the
	/// pbstrBackupStamp parameter by calling the SysFreeString function.
	/// </para>
	/// <para>The string returned refers to all files in the component and any nonselectable subcomponents it has.</para>
	/// <para>
	/// The backup stamp retrieved by <c>GetBackupStamp</c> is generally set by a writer by a call to IVssComponent::SetBackupStamp from
	/// within the PostSnapshot event handler, CVssWriter::OnPostSnapshot.
	/// </para>
	/// <para>
	/// Requesters merely store the backup stamps in the Backup Components Document; they do not make direct use of the backup stamp,
	/// know how to generate it, or understand its format.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/vswriter/nf-vswriter-ivsscomponent-getbackupstamp HRESULT GetBackupStamp(
	// [out] BSTR *pbstrBackupStamp );
	string BackupStamp { get; set; }

	/// <summary>
	/// <para>
	/// The <c>GetBackupSucceeded</c> method returns the status of a complete attempt at backing up all the files of a selected
	/// component or component set as a VSS_FILE_RESTORE_STATUS enumeration. (See Working with Selectability and Logical Paths for
	/// information on selecting components.)
	/// </para>
	/// <para>Either a writer or a requester can call this method.</para>
	/// </summary>
	/// <returns>
	/// The address of a caller-allocated variable that receives <c>true</c> if the backup was successful, or <c>false</c> otherwise.
	/// </returns>
	/// <remarks>
	/// This method should not be called prior to a BackupComplete event, and is designed for use in an implementation of the event
	/// handler CVssWriter::OnBackupComplete.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/vswriter/nf-vswriter-ivsscomponent-getbackupsucceeded HRESULT
	// GetBackupSucceeded( [out] bool *pbSucceeded );
	bool BackupSucceeded { get; }

	/// <summary>
	/// <para>The <c>GetComponentName</c> method returns the logical name of this component.</para>
	/// <para>Either a writer or a requester can call this method.</para>
	/// </summary>
	/// <returns>Pointer to a string containing the logical name of the component.</returns>
	/// <remarks>The caller should free the memory held by the pwszName parameter by calling SysFreeString.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/vswriter/nf-vswriter-ivsscomponent-getcomponentname HRESULT GetComponentName(
	// [out] BSTR *pbstrName );
	string ComponentName { get; }

	/// <summary>
	/// <para>The <c>GetComponentType</c> method returns the type of this component in terms of the VSS_COMPONENT_TYPE enumeration.</para>
	/// <para>Either a writer or a requester can call this method.</para>
	/// </summary>
	/// <returns>
	/// The address of a caller-allocated variable that receives a VSS_COMPONENT_TYPE enumeration value that specifies the type of the component.
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/vswriter/nf-vswriter-ivsscomponent-getcomponenttype HRESULT GetComponentType(
	// [out] VSS_COMPONENT_TYPE *pct );
	VSS_COMPONENT_TYPE ComponentType { get; }

	/// <summary>
	/// <para>
	/// The <c>GetDifferencedFile</c> method returns information about a file set (a specified file or files) to participate in an
	/// incremental or differential backup or restore as a differenced file—that is, backup and restores associated with it are to be
	/// implemented as if entire files are copied to and from backup media (as opposed to using partial files).
	/// </para>
	/// <para>This method can be called by a requester or a writer during backup or restore operations.</para>
	/// </summary>
	/// <remarks>
	/// <para><c>GetDifferencedFile</c> can be called by a requester or a writer during backup or restore operations.</para>
	/// <para>
	/// If the call to <c>GetDifferencedFile</c> is successful, the caller is responsible for freeing the string that is returned in the
	/// pbstrPath and pbstrFilespec parameters by calling the SysFreeString function.
	/// </para>
	/// <para>
	/// As writers can indicate differenced files with calls to IVssComponent::AddDifferencedFilesByLastModifyTime at any time prior to
	/// the actual backing up of files, typically while handling a PostSnapshot event (CVssWriter::OnPostSnapshot), during backups
	/// <c>GetDifferencedFile</c> is not usefully called prior to the return of IVssBackupComponents::DoSnapshotSet has successfully returned.
	/// </para>
	/// <para>
	/// The time stamp returned by <c>GetDifferencedFile</c> applies to all files that match the returned path (pbstrPath) and file
	/// specification (pbstrFilespec).
	/// </para>
	/// <para>
	/// If the time-stamp value returned by <c>GetDifferencedFile</c> (pftLastModifyTime) is nonzero, a requester must respect this
	/// value regardless of its own records and file system information and use it to determine whether the differenced file should be
	/// included in a differential or incremental backup.
	/// </para>
	/// <para>
	/// If the time stamp returned by <c>GetDifferencedFile</c> is zero, the requester can use file system information and its own
	/// records to determine whether the differenced files should be included in a differential or incremental backup.
	/// </para>
	/// <para>Differenced files can be either of the following:</para>
	/// <list type="bullet">
	/// <item>
	/// <term>
	/// Members of the current component or, if the component defines a component set, members of its subcomponents that were added to
	/// the component using IVssCreateWriterMetadata::AddFilesToFileGroup, IVssCreateWriterMetadata::AddDatabaseFiles, or IVssCreateWriterMetadata::AddDatabaseLogFiles
	/// </term>
	/// </item>
	/// <item>
	/// <term>New files added to the component by IVssComponent::AddDifferencedFilesByLastModifyTime</term>
	/// </item>
	/// </list>
	/// <para>
	/// When referring to a file set that is already part of the component, the combination of path, file specification, and recursion
	/// flag (wszPath, wszFileSpec, and bRecursive, respectively) used when calling <c>GetDifferencedFile</c> should match that of a
	/// file set already in the component, or one of its subcomponents (if the component defines a component set).
	/// </para>
	/// <para>
	/// When <c>GetDifferencedFile</c> returns a differenced new file, that file's path (pbstrPath) should match or be beneath a path
	/// already in the component, or one of its subcomponents (if the component defines a component set).
	/// </para>
	/// <para>In addition, the files returned by <c>GetDifferencedFile</c> should not already be managed by component or writer.</para>
	/// <para>If any of these criteria are violated, they constitute an error on the part of the writer and should be reported.</para>
	/// <para>
	/// There is no method in the IVssComponent interface that allows for changing or adding an alternate location mapping for new files
	/// returned by <c>GetDifferencedFilesByLastModifyTime</c>. If an alternate location mapping corresponds to the new file, then that
	/// alternate location will be used.
	/// </para>
	/// </remarks>
	IAppendOnlyList<VssDifferencedFile> DifferencedFiles { get; }

	/// <summary>
	/// <para>
	/// The <c>DirectedTargets</c> property returns information stored by a writer, at backup time, to the Backup Components Document to
	/// indicate that when a file is to be restored, it (the source file) should be remapped. The file may be restored to a new restore
	/// target and/or ranges of its data restored to different locations with the restore target.
	/// </para>
	/// <para>Either a writer or a requester can call this method.</para>
	/// </summary>
	/// <remarks>
	/// <para>
	/// A requester will use the directed target information stored in the Backup Components Document only if the restore target is VSS_RT_DIRECTED.
	/// </para>
	/// <para>
	/// The syntax of the range listing (wszSourceRanges and wszDestinationRanges) is that of a comma-separated list of the form
	/// <c>offset1:length1, offset2:length2</c>, where each offset and length is a 64-bit integer specifying a byte offset and length in
	/// bytes, respectively. The offset and length can be expressed either as hexadecimal or decimal values.
	/// </para>
	/// <para>
	/// Files whose directed targets are returned by <c>GetDirectedTarget</c> may be members of the files of the current component or
	/// any subcomponent it defines.
	/// </para>
	/// <para>
	/// Partial files may be added as directed targets, if the partial file ranges to be backed up match the directed target source
	/// ranges (see IVssComponent::AddPartialFile). This will allow you to remap partial files.
	/// </para>
	/// <para>
	/// The requester will need to check if the directed target source file was backed up as a partial file to correctly implement the
	/// restore. If this is the case, the requester uses the directed target information in conjunction with the partial file
	/// information (IVssComponent::GetPartialFile) to implement the remapping of the backed-up data during restore.
	/// </para>
	/// </remarks>
	IAppendOnlyList<VssDirectedTarget> DirectedTargets { get; }

	/// <summary>
	/// <para>
	/// The <c>GetFileRestoreStatus</c> method returns the status of a completed attempt to restore all the files of a selected
	/// component or component set as a VSS_FILE_RESTORE_STATUS enumeration. (See Working with Selectability and Logical Paths for
	/// information on selecting components.)
	/// </para>
	/// <para>Either a writer or a requester can call this method.</para>
	/// </summary>
	/// <returns>
	/// The address of a caller-allocated variable that receives a VSS_FILE_RESTORE_STATUS enumeration value that specifies whether all
	/// files were successfully restored.
	/// </returns>
	/// <remarks>
	/// <para>This method should be called only following a PostRestore event.</para>
	/// <para>
	/// The status returned is undefined if this method is applied to a component that has not been selected for restore by being added
	/// to the Backup Components via IVssBackupComponents::AddComponent.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/vswriter/nf-vswriter-ivsscomponent-getfilerestorestatus HRESULT
	// GetFileRestoreStatus( [out] VSS_FILE_RESTORE_STATUS *pStatus );
	VSS_FILE_RESTORE_STATUS FileRestoreStatus { get; }

	/// <summary>
	/// <para>The <c>IsSelectedForRestore</c> method determines whether the current component has been selected to be restored.</para>
	/// <para>Either a writer or a requester can call this method.</para>
	/// </summary>
	/// <returns>
	/// The address of a caller-allocated variable that receives <c>true</c> if the component has been selected to be restored, or
	/// <c>false</c> otherwise.
	/// </returns>
	/// <remarks>
	/// <para><c>IsSelectedForRestore</c> is relevant only under component mode.</para>
	/// <para>If the component defines a component set, <c>IsSelectedForRestore</c> refers both to the component and all of its subcomponents.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/vswriter/nf-vswriter-ivsscomponent-isselectedforrestore HRESULT
	// IsSelectedForRestore( [out] bool *pbSelectedForRestore );
	bool IsSelectedForRestore { get; }

	/// <summary>
	/// <para>The <c>GetLogicalPath</c> method returns the logical path of this component.</para>
	/// <para>Either a writer or a requester can call this method.</para>
	/// </summary>
	/// <returns>Pointer to a string containing the logical path of the component.</returns>
	/// <remarks>
	/// <para>The caller should free the memory held by the pbstrPath parameter by calling SysFreeString.</para>
	/// <para>Logical paths are not required of components. A component without a logical path will return S_FALSE.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/vswriter/nf-vswriter-ivsscomponent-getlogicalpath HRESULT GetLogicalPath(
	// [out] BSTR *pbstrPath );
	string LogicalPath { get; }

	/// <summary>
	/// <para>
	/// The <c>NewTargets</c> property returns the new file restoration locations. (See Working with Selectability and Logical Paths for
	/// information on selecting components.)
	/// </para>
	/// <para>Either a writer or a requester can call this method.</para>
	/// </summary>
	/// <returns>List of IVssWMFiledesc objects containing the new target restore locations information.</returns>
	/// <remarks>
	/// New targets returned by <c>NewTargets</c> may be those not only of files in the current component but to files in any of its
	/// nonselectable subcomponents.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/vswriter/nf-vswriter-ivsscomponent-getnewtarget HRESULT GetNewTarget( [in]
	// UINT iNewTarget, [out] IVssWMFiledesc **ppFiledesc );
	IReadOnlyList<IVssWMFiledesc> NewTargets { get; }

	/// <summary>The <c>PartialFiles</c> property returns information on the partial files associated with this component.</summary>
	/// <remarks>
	/// <para>A range indicates a subsection of a given file that is to be backed up, independent of the rest of the file.</para>
	/// <para>
	/// The syntax of the range listing (pbstrRanges) is that of a comma-separated list of the form <c>offset1:length1,
	/// offset2:length2</c>, where each offset and length is a 64-bit integer specifying a byte offset and length in bytes,
	/// respectively. The offset and length can be expressed either as hexadecimal or decimal values.
	/// </para>
	/// <para>
	/// If pbstrRanges refers to a file containing all the offsets and lengths (a ranges file), pbstrRanges should contain the full path
	/// to the file.
	/// </para>
	/// <para>
	/// If wszRange refers to a file containing all the offsets and lengths (a ranges file), wszRange should contain the full path to
	/// the file.
	/// </para>
	/// <para>A ranges file must be a binary file with the following format:</para>
	/// <list type="number">
	/// <item>
	/// <term>A 64-bit integer indicating the number of distinct file ranges that need to be backed up.</term>
	/// </item>
	/// <item>
	/// <term>
	/// Each range expressed as a pair of 64-bit integers: the offset into the file being backed up, in bytes, and the length of data
	/// starting from that offset to be backed up.
	/// </term>
	/// </item>
	/// </list>
	/// <para>
	/// A ranges file should have been backed up along with the partial file and typically is restored to the same location that it was
	/// backed up from.
	/// </para>
	/// <para>
	/// However, the location to which a ranges file is restored might be altered by the requester, which uses
	/// IVssBackupComponents::SetRangesFilePath to indicate this and to update the Backup Components Document so that pbstrRanges
	/// indicates the correct ranges file.
	/// </para>
	/// <para>
	/// A requester would use the ranges information returned by <c>GetPartialFile</c> to restore the backed-up sections to the
	/// appropriate location within the copy of the file on disk at restore time.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/vswriter/nf-vswriter-ivsscomponent-getpartialfile HRESULT GetPartialFile( [in]
	// UINT iPartialFile, [out] BSTR *pbstrPath, [out] BSTR *pbstrFilename, [out] BSTR *pbstrRange, [out] BSTR *pbstrMetadata );
	IAppendOnlyList<VssPartialFile> PartialFiles { get; }

	/// <summary>
	/// <para>
	/// The <c>GetPostRestoreFailureMsg</c> method returns the failure message generated by a writer while handling the PostRestore
	/// event, if IVssComponent::SetPostRestoreFailureMsg set one.
	/// </para>
	/// <para>Either a writer or a requester can call this method.</para>
	/// </summary>
	/// <returns>
	/// Pointer to a string containing the failure message that describes an error that occurred while processing the PostRestore event.
	/// </returns>
	/// <remarks>
	/// <para>The caller should free the memory held by the pbstrPostRestoreFailureMsg parameter by calling SysFreeString.</para>
	/// <para>If SetPostRestoreFailureMsg was not used to set a PostRestore failure message, GetPreRestoreFailureMsg returns S_FALSE.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/vswriter/nf-vswriter-ivsscomponent-getpostrestorefailuremsg HRESULT
	// GetPostRestoreFailureMsg( [out] BSTR *pbstrPostRestoreFailureMsg );
	string PostRestoreFailureMsg { get; set; }

	/// <summary>
	/// <para>Returns the PostSnapshot failure message string that a writer has set for a given component.</para>
	/// <para>
	/// Both writers and requesters can call this method. Writers should call this method after the IVssBackupComponents::DoSnapshotSet
	/// asynchronous operation has completed.
	/// </para>
	/// </summary>
	/// <returns>
	/// A pointer to a null-terminated wide character string containing the failure message that describes an error that occurred while
	/// processing a PostSnapshot event.
	/// </returns>
	/// <remarks>
	/// The caller is responsible for freeing the string that the pbstrFailureMsg parameter points to by calling the SysFreeString function.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/vswriter/nf-vswriter-ivsscomponentex-getpostsnapshotfailuremsg HRESULT
	// GetPostSnapshotFailureMsg( [out] BSTR *pbstrFailureMsg );
	string PostSnapshotFailureMsg { get; set; }

	/// <summary>
	/// <para>Returns the PrepareForBackup failure message string that a writer has set for a given component.</para>
	/// <para>Both writers and requesters can call this method.</para>
	/// </summary>
	/// <returns>
	/// A pointer to a null-terminated wide character string containing the failure message that describes an error that occurred while
	/// processing a PrepareForBackup event.
	/// </returns>
	/// <remarks>
	/// <para>
	/// The caller is responsible for freeing the string that the pbstrFailureMsg parameter points to by calling the SysFreeString function.
	/// </para>
	/// <para>Examples</para>
	/// <para>
	/// <code>#include &lt;windows.h&gt; #include "vss.h" #include "vsmgmt.h" #define CHKARG_ASSERT(EXPR) do { if(! ( EXPR ) ) { assert(FALSE); hr = E_INVALIDARG; goto exit; } } while ( FALSE, FALSE ); #define CHK(HR) do { hr = ( HR ) ; if(FAILED(HR)) { hr = HR; goto exit; } } while ( FALSE, FALSE ); STDMETHODIMP CheckAsrBackupErrorMsg ( IVssBackupComponents *pBackup, const WCHAR *pwszWriterName ) { CComPtr&lt;IVssWriterComponentsExt&gt; spWriter; CComPtr&lt;IVssComponent&gt; spComponent; CComPtr&lt;IVssComponentEx&gt; spComponentEx; UINT cWriterComponents = 0; UINT iWriterComponent = 0; UINT cComponents = 0; UINT iComponent = 0; VSS_ID idWriter; VSS_ID idInstance; CComBSTR bstrFailureMsg; HRESULT hr = S_OK; CHKARG_ASSERT( pBackup ); CHKARG_ASSERT( pwszWriterName ); CHK( pBackup-&gt;GetWriterComponentsCount( &amp;cWriterComponents ) ); for( iWriterComponent = 0; iWriterComponent &lt; cWriterComponents; iWriterComponent++ ) { spWriter.Release(); CHK( pBackup-&gt;GetWriterComponents( iWriterComponent, &amp;spWriter ) ); CHK( spWriter-&gt;GetWriterInfo(&amp;idInstance, &amp;idWriter) ); if( idWriter != c_ASRWriterId ) { continue; } CHK( spWriter-&gt;GetComponentCount(&amp;cComponents) ); for( iComponent = 0; iComponent &lt; cComponents; iComponent++ ) { spComponent.Release(); spComponentEx.Release(); CHK( spWriter-&gt;GetComponent(iComponent, &amp;spComponent) ); CHK( spComponent-&gt;QueryInterface(__uuidof(IVssComponentEx), (void**)&amp;spComponentEx) ); bstrFailureMsg.Empty(); CHK( spComponentEx-&gt;GetPrepareForBackupFailureMsg(&amp;bstrFailureMsg) ); if( ::SysStringLen(bstrFailureMsg) != 0 ) { // Write into the event log. Log_SPP_ERROR_WRITER( &amp;ft, __LINE__, pwszWriterName, bstrFailureMsg ); // The ASR writer writes the same message to all components. // Log the message once. break; } } } exit: return hr; }</code>
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/vswriter/nf-vswriter-ivsscomponentex-getprepareforbackupfailuremsg HRESULT
	// GetPrepareForBackupFailureMsg( [out] BSTR *pbstrFailureMsg );
	string PrepareForBackupFailureMsg { get; set; }

	/// <summary>
	/// <para>
	/// The <c>GetPreRestoreFailureMsg</c> method retrieves the error message generated by a writer while handling the PreRestore event,
	/// if IVssComponent::SetPreRestoreFailureMsg set one.
	/// </para>
	/// <para>Either a writer or a requester can call this method.</para>
	/// </summary>
	/// <returns>String containing the failure message that describes an error that occurred while processing the PreRestore event.</returns>
	/// <remarks>
	/// <para>The caller should free the memory held by the pbstrPreRestoreFailureMsg parameter by calling SysFreeString.</para>
	/// <para>If SetPreRestoreFailureMsg was not used to set a PreRestore failure message, <c>GetPreRestoreFailureMsg</c> returns S_FALSE.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/vswriter/nf-vswriter-ivsscomponent-getprerestorefailuremsg HRESULT
	// GetPreRestoreFailureMsg( [out] BSTR *pbstrPreRestoreFailureMsg );
	string PreRestoreFailureMsg { get; set; }

	/// <summary>
	/// <para>
	/// The <c>GetPreviousBackupStamp</c> method returns a previous backup stamp loaded by a requester in the Backup Components
	/// Document. The value is used by a writer when deciding if files should participate in differential or incremental backup operation.
	/// </para>
	/// <para>Either a writer or a requester can call this method.</para>
	/// </summary>
	/// <returns>
	/// Pointer to a string containing the time stamp of a previous backup so that a differential or incremental backup can be correctly implemented.
	/// </returns>
	/// <remarks>
	/// <para>
	/// For more information about backup stamps, see Writer Role in Backing Up Complex Stores and Requester Role in Backing Up Complex Stores.
	/// </para>
	/// <para>The caller should free the memory held by the pbstrBackupStamp parameter by calling SysFreeString.</para>
	/// <para>If there is no previous backup time stamp, <c>GetPreviousBackupStamp</c> returns S_FALSE.</para>
	/// <para>The string returned refers to all files in the component and any nonselectable subcomponents it has.</para>
	/// <para>The backup stamp retrieved by <c>GetPreviousBackupStamp</c> is set by a requester using IVssBackupComponents::SetPreviousBackupStamp.</para>
	/// <para>
	/// Typically, the string used to set the value found by <c>GetPreviousBackupStamp</c> was retrieved from a stored Backup Components
	/// Document or was stored by the requester as part of its own internal records.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/vswriter/nf-vswriter-ivsscomponent-getpreviousbackupstamp HRESULT
	// GetPreviousBackupStamp( [out] BSTR *pbstrBackupStamp );
	string PreviousBackupStamp { get; }

	/// <summary>
	/// <para>
	/// The <c>GetRestoreMetadata</c> method retrieves private, writer-specific restore metadata that might have been set during a
	/// PreRestore event by CVssWriter::OnPreRestore using IVssComponent::SetRestoreMetadata.
	/// </para>
	/// <para>Only a writer can call this method.</para>
	/// </summary>
	/// <returns>A string containing the restore metadata.</returns>
	/// <remarks>
	/// <para>This method can be called at any time depending on the logic of a given writer.</para>
	/// <para>The caller should free the memory held by the pbstrRestoreMetadata parameter by calling SysFreeString.</para>
	/// <para>If no backup metadata has been set, GetBackupMetadata returns S_FALSE.</para>
	/// <para>
	/// A writer setting the restore method to VSS_RME_RESTORE_TO_ALTERNATE_LOCATION without defining an alternate location mapping
	/// constitutes a writer error.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/vswriter/nf-vswriter-ivsscomponent-getrestoremetadata HRESULT
	// GetRestoreMetadata( [out] BSTR *pbstrRestoreMetadata );
	string RestoreMetadata { get; set; }

	/// <summary>Obtains the logical name assigned to a component that is being restored.</summary>
	/// <returns>
	/// The address of a caller-allocated variable that receives a null-terminated wide character string containing the restore name for
	/// the component.
	/// </returns>
	/// <remarks>
	/// <para>The GetRestoreName method can only be called during a restore operation.</para>
	/// <para>
	/// If the call to GetRestoreName is successful, the caller is responsible for freeing the string that is returned in the pbstrName
	/// parameter by calling the SysFreeString function.
	/// </para>
	/// <para>
	/// A writer indicates that it supports this method by setting the <c>VSS_BS_RESTORE_RENAME</c> flag in its backup schema mask.
	/// </para>
	/// <para>For more information, see Setting VSS Restore Options.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/vswriter/nf-vswriter-ivsscomponentex-getrestorename HRESULT GetRestoreName(
	// [out] BSTR *pbstrName );
	string RestoreName { get; }

	/// <summary>
	/// <para>The <c>GetRestoreOptions</c> method gets the restore options specified to the current writer by a requester using IVssBackupComponents::SetRestoreOptions.</para>
	/// <para>Either a writer or a requester can call this method.</para>
	/// </summary>
	/// <returns>String containing the restore options of the writer.</returns>
	/// <remarks>
	/// <para>The caller should free the memory held by the pbstrRestoreOptions parameter by calling SysFreeString.</para>
	/// <para>If no restore options have been set, S_FALSE is returned.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/vswriter/nf-vswriter-ivsscomponent-getrestoreoptions HRESULT
	// GetRestoreOptions( [out] BSTR *pbstrRestoreOptions );
	string RestoreOptions { get; }

	/// <summary>
	/// <para>The <c>RestoreSubcomponents</c> property returns the subcomponents associated with a given component.</para>
	/// <para>Either a writer or a requester can call this method.</para>
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/vswriter/nf-vswriter-ivsscomponent-getrestoresubcomponent HRESULT
	// GetRestoreSubcomponent( [in] UINT iComponent, [out] BSTR *pbstrLogicalPath, [out] BSTR *pbstrComponentName, [out] bool *pbRepair );
	IReadOnlyList<VssRestoreSubcomponent> RestoreSubcomponents { get; }

	/// <summary>
	/// <para>
	/// The <c>GetRestoreTarget</c> method returns the restore target (in terms of the VSS_RESTORE_TARGET enumeration) for the current component.
	/// </para>
	/// <para>Either a writer or a requester can call this method. It can be called only during a restore operation.</para>
	/// </summary>
	/// <returns>
	/// The address of a caller-allocated variable that receives a VSS_RESTORE_TARGET enumeration value that specifies the restore target.
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/vswriter/nf-vswriter-ivsscomponent-getrestoretarget HRESULT GetRestoreTarget(
	// [out] VSS_RESTORE_TARGET *pTarget );
	VSS_RESTORE_TARGET RestoreTarget { get; set; }

	/// <summary>VSS requesters call this method to retrieve component-level errors reported by writers.</summary>
	/// <param name="phr">
	/// <para>
	/// The address of a caller-allocated variable that receives the HRESULT failure code that the writer passed for the hr parameter of
	/// the IVssComponentEx2::SetFailure method. This parameter is required and cannot be <c>NULL</c>.
	/// </para>
	/// <para>The following are the supported values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>S_OK</term>
	/// <term>The writer was successful.</term>
	/// </item>
	/// <item>
	/// <term>VSS_E_WRITERERROR_INCONSISTENTSNAPSHOT</term>
	/// <term>The shadow copy contains only a subset of the volumes needed by the writer to correctly back up the application component.</term>
	/// </item>
	/// <item>
	/// <term>VSS_E_WRITERERROR_OUTOFRESOURCES</term>
	/// <term>
	/// The writer ran out of memory or other system resources. The recommended way to handle this error code is to wait ten minutes and
	/// then repeat the operation, up to three times.
	/// </term>
	/// </item>
	/// <item>
	/// <term>VSS_E_WRITERERROR_TIMEOUT</term>
	/// <term>
	/// The writer operation failed because of a time-out between the Freeze and Thaw events. The recommended way to handle this error
	/// code is to wait ten minutes and then repeat the operation, up to three times.
	/// </term>
	/// </item>
	/// <item>
	/// <term>VSS_E_WRITERERROR_RETRYABLE</term>
	/// <term>
	/// The writer failed due to an error that would likely not occur if the entire backup, restore, or shadow copy creation process was
	/// restarted. The recommended way to handle this error code is to wait ten minutes and then repeat the operation, up to three times.
	/// </term>
	/// </item>
	/// <item>
	/// <term>VSS_E_WRITERERROR_NONRETRYABLE</term>
	/// <term>
	/// The writer operation failed because of an error that might recur if another shadow copy is created. For more information, see
	/// Event and Error Handling Under VSS.
	/// </term>
	/// </item>
	/// <item>
	/// <term>VSS_E_WRITER_NOT_RESPONDING</term>
	/// <term>The writer is not responding.</term>
	/// </item>
	/// <item>
	/// <term>VSS_E_WRITER_STATUS_NOT_AVAILABLE</term>
	/// <term>
	/// The writer status is not available for one or more writers. A writer may have reached the maximum number of available backup and
	/// restore sessions.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="phrApplication">
	/// The address of a caller-allocated variable that receives the return code that the writer passed for the hrApplication parameter
	/// of the SetFailure method. This parameter is required and cannot be <c>NULL</c>.
	/// </param>
	/// <param name="pbstrApplicationMessage">
	/// The address of a caller-allocated variable that receives the application failure message that the writer passed for the
	/// wszApplicationMessage parameter of the SetFailure method. This parameter is required and cannot be <c>NULL</c>.
	/// </param>
	/// <remarks>
	/// When the caller has finished accessing the status information returned by this method, it should call SysFreeString to free the
	/// memory held by the pbstrApplicationMessage parameter.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/vswriter/nf-vswriter-ivsscomponentex2-getfailure HRESULT GetFailure( [out]
	// HRESULT *phr, [out] HRESULT *phrApplication, [out] BSTR *pbstrApplicationMessage, [out] DWORD *pdwReserved );
	void GetFailure(out HRESULT phr, out HRESULT phrApplication, out string pbstrApplicationMessage);

	/// <summary>
	/// Obtains the roll-forward operation type for a component and obtains the restore point for a partial roll-forward operation.
	/// </summary>
	/// <param name="pRollType">A VSS_ROLLFORWARD_TYPE enumeration value indicating the type of roll-forward operation to be performed.</param>
	/// <param name="pbstrPoint">
	/// The address of a caller-allocated variable that receives a null-terminated wide character string specifying the roll-forward
	/// restore point.
	/// </param>
	/// <remarks>
	/// <para>The <c>GetRollForward</c> method can be called only during a restore operation.</para>
	/// <para>
	/// If the call to <c>GetRollForward</c> is successful, the caller is responsible for freeing the string that is returned in the
	/// pRollType parameter by calling the SysFreeString function.
	/// </para>
	/// <para>
	/// A writer indicates that it supports this method by setting the <c>VSS_BS_ROLLFORWARD_RESTORE</c> flag in its backup schema mask.
	/// </para>
	/// <para>For more information, see Setting VSS Restore Options.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/vswriter/nf-vswriter-ivsscomponentex-getrollforward HRESULT GetRollForward(
	// [out] VSS_ROLLFORWARD_TYPE *pRollType, [out] BSTR *pbstrPoint );
	void GetRollForward(out VSS_ROLLFORWARD_TYPE pRollType, out string pbstrPoint);

	/// <summary>VSS writers call this method to report errors at the component level.</summary>
	/// <param name="hr">
	/// <para>The error code to be returned to the requester that calls the IVssComponentEx2::GetFailure method.</para>
	/// <para>The following are the error codes that this method can set.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>S_OK</term>
	/// <term>The writer was successful.</term>
	/// </item>
	/// <item>
	/// <term>VSS_E_WRITERERROR_INCONSISTENTSNAPSHOT</term>
	/// <term>The shadow copy contains only a subset of the volumes needed by the writer to correctly back up the application component.</term>
	/// </item>
	/// <item>
	/// <term>VSS_E_WRITERERROR_OUTOFRESOURCES</term>
	/// <term>
	/// The writer ran out of memory or other system resources. The recommended way to handle this error code is to wait ten minutes and
	/// then repeat the operation, up to three times.
	/// </term>
	/// </item>
	/// <item>
	/// <term>VSS_E_WRITERERROR_TIMEOUT</term>
	/// <term>
	/// The writer operation failed because of a time-out between the Freeze and Thaw events. The recommended way to handle this error
	/// code is to wait ten minutes and then repeat the operation, up to three times.
	/// </term>
	/// </item>
	/// <item>
	/// <term>VSS_E_WRITERERROR_RETRYABLE</term>
	/// <term>
	/// The writer failed due to an error that would likely not occur if the entire backup, restore, or shadow copy creation process was
	/// restarted. The recommended way to handle this error code is to wait ten minutes and then repeat the operation, up to three times.
	/// </term>
	/// </item>
	/// <item>
	/// <term>VSS_E_WRITERERROR_NONRETRYABLE</term>
	/// <term>
	/// The writer operation failed because of an error that might recur if another shadow copy is created. For more information, see
	/// Event and Error Handling Under VSS.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="hrApplication">An additional error code to be returned to the requester. This parameter is optional.</param>
	/// <param name="wszApplicationMessage">
	/// A string containing an error message for the requester to display to the end user. The writer is responsible for localizing this
	/// string if necessary before using it in this method. This parameter is optional and can be <c>NULL</c> or an empty string.
	/// </param>
	/// <remarks>
	/// <para>
	/// In addition to calling this method, use the CVssWriterEx2::SetWriterFailureEx method to report that a partial writer failure has occurred.
	/// </para>
	/// <para>This method cannot be called from CVssWriter::OnIdentify or CVssWriterEx::OnIdentifyEx.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/vswriter/nf-vswriter-ivsscomponentex2-setfailure HRESULT SetFailure( [in]
	// HRESULT hr, [in] HRESULT hrApplication, [in] LPCWSTR wszApplicationMessage, [in] DWORD dwReserved );
	void SetFailure(HRESULT hr, [Optional] HRESULT hrApplication, [Optional] string? wszApplicationMessage);
}

/// <summary>
/// <para>
/// The <c>IVssCreateExpressWriterMetadata</c> interface is a COM interface containing methods to construct the Writer Metadata Document
/// for an express writer.
/// </para>
/// <para>
/// After it is constructed, the Writer Metadata Document is a read-only object that requesters query for information about a writer and
/// its components.
/// </para>
/// </summary>
// https://docs.microsoft.com/en-us/windows/win32/api/vswriter/nl-vswriter-ivsscreateexpresswritermetadata
[PInvokeData("vswriter.h", MSDNShortId = "NL:vswriter.IVssCreateExpressWriterMetadata")]
[ComImport, Guid("9c772e77-b26e-427f-92dd-c996f41ea5e3"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
public interface IVssCreateExpressWriterMetadata
{
	/// <summary>
	/// Excludes a file set (a specified file or files) that might otherwise be implicitly included when a component of an express
	/// writer is backed up.
	/// </summary>
	/// <param name="wszPath">
	/// <para>A pointer to a null-terminated wide character string containing the root directory under which files are to be excluded.</para>
	/// <para>The path can contain environment variables (for example, %SystemRoot%) but cannot contain wildcard characters.</para>
	/// <para>
	/// There is no requirement that the path end with a backslash (\). It is up to applications that retrieve this information to check.
	/// </para>
	/// </param>
	/// <param name="wszFilespec">
	/// <para>A pointer to a null-terminated wide character string containing the file specification of the files to be excluded.</para>
	/// <para>
	/// A file specification cannot contain directory specifications (for example, no backslashes) but can contain the ? and * wildcard characters.
	/// </para>
	/// </param>
	/// <param name="bRecursive">
	/// <para>
	/// A Boolean value specifying whether the path specified by the wszPath parameter identifies only a single directory or if it
	/// indicates a hierarchy of directories to be traversed recursively. This parameter should be set to <c>true</c> if the path is
	/// treated as a hierarchy of directories to be recursed through, or <c>false</c> otherwise.
	/// </para>
	/// <para>For information on traversing over mounted folders, see Working with Mounted Folders and Reparse Points.</para>
	/// </param>
	/// <remarks>
	/// <para>
	/// Express writers support only local resources—sets of files whose absolute path starts with a valid local volume specification
	/// and cannot be a mapped network drive. Therefore, path inputs (wszPath) to <c>AddExcludeFiles</c> (after the resolution of any
	/// environment variables) must be in this format. For example, it is often convenient to define a component to include all files in
	/// a specified directory and then use <c>AddExcludeFiles</c> to explicitly remove some files (for instance, temporary files) from a backup.
	/// </para>
	/// <para>For more information on excluding files, see Exclude File List Specification.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/vswriter/nf-vswriter-ivsscreateexpresswritermetadata-addexcludefiles HRESULT
	// AddExcludeFiles( [in] LPCWSTR wszPath, [in] LPCWSTR wszFilespec, [in] bool bRecursive );
	void AddExcludeFiles([MarshalAs(UnmanagedType.LPWStr)] string wszPath, [MarshalAs(UnmanagedType.LPWStr)] string wszFilespec, bool bRecursive);

	/// <summary>Adds a file group to an express writer's set of components to be backed up.</summary>
	/// <param name="ct">
	/// A VSS_COMPONENT_TYPE enumeration value that specifies the type of the component. Only <c>VSS_CT_FILEGROUP</c> is supported for
	/// this parameter.
	/// </param>
	/// <param name="wszLogicalPath">
	/// <para>
	/// A pointer to a <c>null</c>-terminated wide character string containing the logical path of the database or file group. For more
	/// information, see Logical Pathing of Components.
	/// </para>
	/// <para>This parameter is optional and can be <c>NULL</c>.</para>
	/// </param>
	/// <param name="wszComponentName">
	/// <para>A pointer to a <c>null</c>-terminated wide character string containing the name of the component. This string is not localized.</para>
	/// <para>This parameter is required and cannot be <c>NULL</c>. The string cannot contain backslashes.</para>
	/// </param>
	/// <param name="wszCaption">
	/// <para>
	/// A pointer to a <c>null</c>-terminated wide character string containing a description (also called a "friendly name") for the
	/// component. This string might be localized, and therefore requesters must assume that it is localized.
	/// </para>
	/// <para>This parameter is optional and can be <c>NULL</c>. The string can contain backslashes.</para>
	/// </param>
	/// <param name="pbIcon">
	/// <para>
	/// A pointer to a bitmap of the icon representing the database, to be displayed in a user interface. The size, in bytes, of the
	/// buffer is specified by the cbIcon parameter.
	/// </para>
	/// <para>This parameter is optional and can be <c>NULL</c>.</para>
	/// </param>
	/// <param name="cbIcon">The number of bytes in <paramref name="pbIcon"/>.</param>
	/// <param name="bRestoreMetadata">This parameter is reserved for future use and should always be set to <c>false</c>.</param>
	/// <param name="bNotifyOnBackupComplete">This parameter is reserved for future use and should always be set to <c>false</c>.</param>
	/// <param name="bSelectable">
	/// A Boolean value that indicates whether the component can be optionally backed up (which means it can be excluded from the
	/// backup) or is always backed up when any of the writer's components is backed up. This parameter should be set to <c>true</c> if
	/// the component can be selectively backed up, or <c>false</c> if the component is backed up when any of the components is backed up.
	/// </param>
	/// <param name="bSelectableForRestore">
	/// <para>
	/// A Boolean value that determines whether a component can be individually restored when it has not been explicitly included in the
	/// backup document. If the component was explicitly added to the backup document, it can always be individually selected for
	/// restore; in this case, this flag has no meaning.
	/// </para>
	/// <para>
	/// When this parameter is <c>true</c>, the component can be restored by itself; when <c>false</c>, the component can be restored
	/// only if the entire component set is being restored. (For more information, see VSS_COMPONENTINFO and Working with Selectability
	/// and Logical Paths.)
	/// </para>
	/// <para>The default value for this parameter is <c>false</c>.</para>
	/// </param>
	/// <param name="dwComponentFlags">
	/// <para>
	/// A bitmask of VSS_COMPONENT_FLAGS enumeration values indicating the features that this component supports. This bitmask cannot
	/// include <c>VSS_CF_APP_ROLLBACK_RECOVERY</c> or <c>VSS_CF_BACKUP_RECOVERY</c>.
	/// </para>
	/// <para>The default value for this parameter is zero.</para>
	/// </param>
	/// <remarks>
	/// <para>This method can be called multiple times to add several components to an express writer's metadata.</para>
	/// <para>
	/// The combination of logical path and name for each component of a specified instance of a specified class of writer must be
	/// unique. Attempting to call <c>AddComponent</c> twice with the same values of wszLogicalPath and wszComponentName results in a
	/// VSS_E_OBJECT_ALREADY_EXISTS error.
	/// </para>
	/// <para>
	/// <c>AddComponent</c> can be used to add subcomponents—components in which all member files are backed up as a group but which
	/// contain files that can be restored individually. For more information, see Working with Selectability for Restore and Subcomponents.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/vswriter/nf-vswriter-ivsscreateexpresswritermetadata-addcomponent HRESULT
	// AddComponent( [in] VSS_COMPONENT_TYPE ct, [in] LPCWSTR wszLogicalPath, [in] LPCWSTR wszComponentName, [in] LPCWSTR wszCaption,
	// [in] const BYTE *pbIcon, [in] UINT cbIcon, [in] bool bRestoreMetadata, [in] bool bNotifyOnBackupComplete, [in] bool bSelectable,
	// [in] bool bSelectableForRestore, [in] DWORD dwComponentFlags );
	void AddComponent(VSS_COMPONENT_TYPE ct, [MarshalAs(UnmanagedType.LPWStr)] string? wszLogicalPath,
		[MarshalAs(UnmanagedType.LPWStr)] string wszComponentName, [MarshalAs(UnmanagedType.LPWStr)] string? wszCaption,
		[Optional] IntPtr pbIcon, uint cbIcon, bool bRestoreMetadata, bool bNotifyOnBackupComplete, bool bSelectable, bool bSelectableForRestore = false,
		VSS_COMPONENT_FLAGS dwComponentFlags = 0);

	/// <summary>Adds a file set (a specified file or files) to a specified file group component for an express writer.</summary>
	/// <param name="wszLogicalPath">
	/// A pointer to a <c>null</c>-terminated wide character string containing the logical path (which may be <c>NULL</c>) of the
	/// component to which to add the files. For more information, see Logical Pathing of Components.
	/// </param>
	/// <param name="wszGroupName">
	/// A pointer to a <c>null</c>-terminated wide character string containing the name of the file group component. The type of this
	/// component must be VSS_CT_FILEGROUP; otherwise, the method will return an error.
	/// </param>
	/// <param name="wszPath">
	/// <para>A pointer to a <c>null</c>-terminated wide character string containing the default root directory of the files to be added.</para>
	/// <para>The path can contain environment variables (for example, %SystemRoot%) but cannot contain wildcard characters.</para>
	/// <para>
	/// There is no requirement that the path end with a backslash (\). It is up to applications that retrieve this information to check.
	/// </para>
	/// </param>
	/// <param name="wszFilespec">
	/// <para>A pointer to a <c>null</c>-terminated wide character string containing the file specification of the files to be included.</para>
	/// <para>
	/// A file specification cannot contain directory specifications (for example, no backslashes) but can contain the ? and * wildcard characters.
	/// </para>
	/// </param>
	/// <param name="bRecursive">
	/// <para>
	/// A Boolean value specifying whether the path specified by the wszPath parameter identifies only a single directory or if it
	/// indicates a hierarchy of directories to be traversed recursively. This parameter should be set to <c>true</c> if the path is
	/// treated as a hierarchy of directories to be recursed through, or <c>false</c> otherwise.
	/// </para>
	/// <para>For information on traversing over mounted folders, see Working with Mounted Folders and Reparse Points.</para>
	/// </param>
	/// <param name="wszAlternateLocation">This parameter is reserved and must be <c>NULL</c>.</param>
	/// <param name="dwBackupTypeMask">
	/// <para>
	/// A bitmask of VSS_FILE_SPEC_BACKUP_TYPE enumeration values to indicate if a writer should evaluate the file for participation in
	/// a certain type of backup operations.
	/// </para>
	/// <para>
	/// This parameter cannot include <c>VSS_FSBT_DIFFERENTIAL_BACKUP_REQUIRED</c>, <c>VSS_FSBT_INCREMENTAL_BACKUP_REQUIRED</c>, or <c>VSS_FSBT_LOG_BACKUP_REQUIRED</c>.
	/// </para>
	/// <para>The default value for this argument is (VSS_FSBT_ALL_BACKUP_REQUIRED | VSS_FSBT_ALL_SNAPSHOT_REQUIRED).</para>
	/// </param>
	// https://docs.microsoft.com/en-us/windows/win32/api/vswriter/nf-vswriter-ivsscreateexpresswritermetadata-addfilestofilegroup
	// HRESULT AddFilesToFileGroup( [in] LPCWSTR wszLogicalPath, [in] LPCWSTR wszGroupName, [in] LPCWSTR wszPath, [in] LPCWSTR
	// wszFilespec, [in] bool bRecursive, [in] LPCWSTR wszAlternateLocation, [in] DWORD dwBackupTypeMask );
	void AddFilesToFileGroup([MarshalAs(UnmanagedType.LPWStr)] string? wszLogicalPath, [MarshalAs(UnmanagedType.LPWStr)] string wszGroupName,
		[MarshalAs(UnmanagedType.LPWStr)] string wszPath, [MarshalAs(UnmanagedType.LPWStr)] string wszFilespec, bool bRecursive,
		[MarshalAs(UnmanagedType.LPWStr)] string? wszAlternateLocation = null,
		VSS_FILE_SPEC_BACKUP_TYPE dwBackupTypeMask = VSS_FILE_SPEC_BACKUP_TYPE.VSS_FSBT_ALL_BACKUP_REQUIRED | VSS_FILE_SPEC_BACKUP_TYPE.VSS_FSBT_ALL_SNAPSHOT_REQUIRED);

	/// <summary>Specifies how an express writer's data is to be restored.</summary>
	/// <param name="method">
	/// A VSS_RESTOREMETHOD_ENUM enumeration value specifying the restore method to be used in the restore operation. This parameter is
	/// required and cannot be <c>VSS_RME_UNDEFINED</c>, <c>VSS_RME_RESTORE_TO_ALTERNATE_LOCATION</c>, or <c>VSS_RME_CUSTOM</c>.
	/// </param>
	/// <param name="wszService">
	/// <para>
	/// A pointer to a wide character string containing the name of a service that must be stopped prior to a restore operation and then
	/// started after the restore operation takes place, if the value of method is <c>VSS_RME_STOP_RESTORE_START</c> or <c>VSS_RME_RESTORE_STOP_START</c>.
	/// </para>
	/// <para>
	/// If the value of method is not <c>VSS_RME_STOP_RESTORE_START</c> or <c>VSS_RME_RESTORE_STOP_START</c>, this parameter is not used
	/// and should be set to <c>NULL</c>.
	/// </para>
	/// </param>
	/// <param name="wszUserProcedure">Reserved for future use. The value of this parameter should always be set to <c>NULL</c>.</param>
	/// <param name="writerRestore">
	/// A VSS_WRITERRESTORE_ENUM enumeration value specifying whether the writer will be involved in restoring its data. This parameter
	/// must be set to <c>VSS_WRE_NEVER</c>.
	/// </param>
	/// <param name="bRebootRequired">A Boolean value indicating whether a reboot will be required after the restore operation is complete.</param>
	/// <remarks>
	/// <para>
	/// An express writer can define only one restore method. If the restore method is not overridden, all of the express writer's
	/// components will be restored using the same method.
	/// </para>
	/// <para>
	/// Express writers override the restore method on a component-by-component basis by setting a restore target, typically while
	/// handling a PreRestore event (CVssWriter::OnPreRestore).
	/// </para>
	/// <para>
	/// It is important to note that despite the fact that restore methods are applied on a per-writer basis, methods are implemented on
	/// a per-component basis. For example, if the method specified by the method parameter is <c>VSS_RME_RESTORE_IF_CAN_REPLACE</c>,
	/// then all of the files in the component are restored to their original location if they can all be replaced without an error
	/// occurring. Otherwise, they are restored to their alternate location if one is specified.
	/// </para>
	/// <para>A file can be restored to an alternate location mapping if either of the following is true:</para>
	/// <list type="bullet">
	/// <item>
	/// <term>The restore method is <c>VSS_RME_RESTORE_IF_NOT_THERE</c>, and a version of the file is already present on disk.</term>
	/// </item>
	/// <item>
	/// <term>
	/// The restore method is <c>VSS_RME_RESTORE_IF_CAN_REPLACE</c>, and a version of the file is present on disk and cannot be replaced.
	/// </term>
	/// </item>
	/// </list>
	/// <para>If no valid alternate location mapping is defined, this is a writer error.</para>
	/// <para>For more information about restore methods, see Setting VSS Restore Methods.</para>
	/// <para>
	/// If the restore method is VSS_RME_STOP_RESTORE_START or VSS_RME_RESTORE_STOP_START, then the correct name of the service must be
	/// provided as the wszService argument. For information on writer participation in stopping and restarting services during a
	/// restore operation, see Stopping Services for Restore by Requesters.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/vswriter/nf-vswriter-ivsscreateexpresswritermetadata-setrestoremethod HRESULT
	// SetRestoreMethod( [in] VSS_RESTOREMETHOD_ENUM method, [in] LPCWSTR wszService, [in] LPCWSTR wszUserProcedure, [in]
	// VSS_WRITERRESTORE_ENUM writerRestore, [in] bool bRebootRequired );
	void SetRestoreMethod(VSS_RESTOREMETHOD_ENUM method, [MarshalAs(UnmanagedType.LPWStr)] string? wszService,
		[MarshalAs(UnmanagedType.LPWStr)] string? wszUserProcedure, VSS_WRITERRESTORE_ENUM writerRestore, bool bRebootRequired);

	/// <summary>
	/// Allows an express writer to indicate that a component it manages has an explicit writer-component dependency; that is, another
	/// component (possibly managed by another writer) must be backed up and restored with it.
	/// </summary>
	/// <param name="wszForLogicalPath">
	/// A null-terminated wide character string containing the logical path of the component (managed by the express writer) that
	/// requires a dependency.
	/// </param>
	/// <param name="wszForComponentName">
	/// A null-terminated wide character string containing the component (managed by the express writer) that requires a dependency.
	/// </param>
	/// <param name="onWriterId">
	/// A VSS_ID (GUID) value that specifies the writer class of the express writer managing the component on which the current
	/// component depends.
	/// </param>
	/// <param name="wszOnLogicalPath">
	/// The logical path of the component (managed by the express writer identified by onWriterId) on which the current component depends.
	/// </param>
	/// <param name="wszOnComponentName">
	/// The name of the component (managed by the express writer identified by onWriterId) on which the current component depends.
	/// </param>
	// https://docs.microsoft.com/en-us/windows/win32/api/vswriter/nf-vswriter-ivsscreateexpresswritermetadata-addcomponentdependency
	// HRESULT AddComponentDependency( [in] LPCWSTR wszForLogicalPath, [in] LPCWSTR wszForComponentName, [in] VSS_ID onWriterId, [in]
	// LPCWSTR wszOnLogicalPath, [in] LPCWSTR wszOnComponentName );
	void AddComponentDependency([MarshalAs(UnmanagedType.LPWStr)] string wszForLogicalPath, [MarshalAs(UnmanagedType.LPWStr)] string wszForComponentName,
		Guid onWriterId, [MarshalAs(UnmanagedType.LPWStr)] string wszOnLogicalPath, [MarshalAs(UnmanagedType.LPWStr)] string wszOnComponentName);

	/// <summary>
	/// Used by an express writer to indicate in its Writer Metadata Document the types of backup operations it can participate in.
	/// </summary>
	/// <param name="dwSchemaMask">
	/// A bitmask of VSS_BACKUP_SCHEMA enumeration values that specify the types of backup operations this writer supports.
	/// </param>
	/// <remarks>
	/// <para>
	/// If no schema is explicitly set by <c>SetBackupSchema</c>, the express writer will be assigned the default value of
	/// <c>VSS_BS_UNDEFINED</c>. <c>VSS_BS_UNDEFINED</c> means that the writer supports only simple full backup and restoration of
	/// entire files (as defined by <c>VSS_BT_FULL</c>), there is no support for incremental or differential backups, and partial files
	/// are not supported. Only the <c>VSS_BS_UNDEFINED</c>, <c>VSS_BS_COPY</c> and <c>VSS_BS_INDEPENDENT_SYSTEM_STATE</c> backup schema
	/// types are supported by express writers.
	/// </para>
	/// <para>Requesters call IVssExamineWriterMetadata::GetBackupSchema to retrieve a writer's backup schemas as set by <c>SetBackupSchema</c>.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/vswriter/nf-vswriter-ivsscreateexpresswritermetadata-setbackupschema HRESULT
	// SetBackupSchema( [in] DWORD dwSchemaMask );
	void SetBackupSchema(VSS_BACKUP_SCHEMA dwSchemaMask);

	/// <summary>Stores the Writer Metadata Document that contains an express writer's state information into a specified string.</summary>
	/// <returns>A pointer to a string to be used to store the Writer Metadata Document that contains a writer's state information.</returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/vswriter/nf-vswriter-ivsscreateexpresswritermetadata-saveasxml HRESULT
	// SaveAsXML( [in] BSTR *pbstrXML );
	[return: MarshalAs(UnmanagedType.BStr)]
	string SaveAsXML();
}

/// <summary>
/// <para>
/// The <c>IVssCreateWriterMetadata</c> interface contains methods to construct the Writer Metadata Document in response to an Identify
/// event. It is used only in the CVssWriter::OnIdentify method.
/// </para>
/// <para>The addition and specification of components by a writer is managed through this interface.</para>
/// <para>
/// After it is constructed, the Writer Metadata Document is a read-only object that requesters query for information about a writer and
/// its components.
/// </para>
/// <para><c>IVssCreateWriterMetadata</c> defines the following methods.</para>
/// <list type="table">
/// <listheader>
/// <term>Method</term>
/// <term>Description</term>
/// </listheader>
/// <item>
/// <term>AddAlternateLocationMapping</term>
/// <term>Creates an alternate location mapping.</term>
/// </item>
/// <item>
/// <term>AddComponent</term>
/// <term>Adds a database or file group as a component to be backed up.</term>
/// </item>
/// <item>
/// <term>AddComponentDependency</term>
/// <term>
/// Indicates that a component participates in a backup or restore only if specified components managed by other writers also participate.
/// </term>
/// </item>
/// <item>
/// <term>AddDatabaseFiles</term>
/// <term>Indicates the physical files that are associated with a database to be backed up, as well as their location.</term>
/// </item>
/// <item>
/// <term>AddDatabaseLogFiles</term>
/// <term>Indicates the log files that are associated with a database to be backed up, as well as their location.</term>
/// </item>
/// <item>
/// <term>AddExcludeFiles</term>
/// <term>Specifies the files that will be excluded from the backup.</term>
/// </item>
/// <item>
/// <term>AddFilesToFileGroup</term>
/// <term>Adds the specified file or files to the specified file group.</term>
/// </item>
/// <item>
/// <term>AddIncludeFiles</term>
/// <term>Reserved for system use.</term>
/// </item>
/// <item>
/// <term>GetDocument</term>
/// <term>Reserved for system use.</term>
/// </item>
/// <item>
/// <term>SaveAsXML</term>
/// <term>Saves a text string containing the Writer Metadata Document.</term>
/// </item>
/// <item>
/// <term>SetBackupSchema</term>
/// <term>Sets the backup schema (how a backup is to be executed) to be used when processing a writer's files.</term>
/// </item>
/// <item>
/// <term>SetRestoreMethod</term>
/// <term>Indicates how writer data is to be restored.</term>
/// </item>
/// </list>
/// </summary>
// https://docs.microsoft.com/en-us/windows/win32/api/vswriter/nl-vswriter-ivsscreatewritermetadata
[PInvokeData("vswriter.h", MSDNShortId = "NL:vswriter.IVssCreateWriterMetadata")]
public interface IVssCreateWriterMetadata
{
	/// <summary>The <c>AddAlternateLocationMapping</c> method creates an alternate location mapping for a file set.</summary>
	/// <param name="wszSourcePath">
	/// <para>String containing the name of the directory or directory hierarchy containing the files to be mapped.</para>
	/// <para>The directory can be a local directory on the VSS machine, or it can be a file share directory on a remote file server.</para>
	/// <para>The path can contain environment variables (for example, %SystemRoot%) but cannot contain wildcard characters.</para>
	/// <para>
	/// There is no requirement that the path end with a backslash (""). It is up to applications that retrieve this information to check.
	/// </para>
	/// </param>
	/// <param name="wszSourceFilespec">
	/// <para>String containing the file specification of the files to be mapped.</para>
	/// <para>
	/// A file specification cannot contain directory specifications (for example, no backslashes) but can contain the ? and * wildcard characters.
	/// </para>
	/// </param>
	/// <param name="bRecursive">
	/// <para>
	/// A Boolean value specifying whether the path specified by the wszPath parameter identifies only a single directory or if it
	/// indicates a hierarchy of directories to be traversed recursively. This parameter should be set to <c>true</c> if the path is
	/// treated as a hierarchy of directories to be traversed recursively, or <c>false</c> if not.
	/// </para>
	/// <para>For information on traversing mounted folders, see Working with Mounted Folders and Reparse Points.</para>
	/// </param>
	/// <param name="wszDestination">
	/// <para>String containing the fully qualified path to the directory where the files will be relocated.</para>
	/// <para>The directory can be a local directory on the VSS machine, or it can be a file share directory on a remote file server.</para>
	/// <para>UNC paths are supported.</para>
	/// </param>
	/// <remarks>
	/// <para>
	/// <c>Windows 7, Windows Server 2008 R2, Windows Vista, Windows Server 2008, Windows XP and Windows Server 2003:</c> Remote file
	/// shares are not supported until Windows 8 and Windows Server 2012. Writers support only local resources—sets of files whose
	/// absolute path starts with a valid local volume specification and cannot be a mapped network drive. Therefore, path inputs
	/// (wszPath and wszDestination) to <c>AddAlternateLocationMapping</c> (after the resolution of any environment variables) must be
	/// in this format.
	/// </para>
	/// <para>This method can be called multiple times to add mapping for multiple files.</para>
	/// <para>
	/// The combination of path, file specification, and recursion flag (wszPath, wszFileSpec, and bRecursive, respectively) provided to
	/// <c>AddAlternateLocationMapping</c> to be mapped must match that of one of the file sets added to one of the writer's components
	/// using IVssCreateWriterMetadata::AddFilesToFileGroup, IVssCreateWriterMetadata::AddDatabaseFiles, or IVssCreateWriterMetadata::AddDatabaseLogFiles.
	/// </para>
	/// <para>
	/// The <c>AddAlternateLocationMapping</c> method should be called only after IVssCreateWriterMetadata::SetRestoreMethod is called.
	/// </para>
	/// <para>A file should always be restored to its alternate location mapping if either of the following is true:</para>
	/// <list type="bullet">
	/// <item>
	/// <term>The restore method (set at backup time) is VSS_RME_RESTORE_TO_ALTERNATE_LOCATION.</term>
	/// </item>
	/// <item>
	/// <term>Its restore target was set (at restore time) to VSS_RT_ALTERNATE.</term>
	/// </item>
	/// </list>
	/// <para>In either case, if no valid alternate location mapping is defined, this constitutes a writer error.</para>
	/// <para>A file can be restored to an alternate location mapping if either of the following is true:</para>
	/// <list type="bullet">
	/// <item>
	/// <term>The restore method is VSS_RME_RESTORE_IF_NOT_THERE and a version of the file is already present on disk.</term>
	/// </item>
	/// <item>
	/// <term>The restore method is VSS_RME_RESTORE_IF_CAN_REPLACE and a version of the file is present on disk and cannot be replaced.</term>
	/// </item>
	/// </list>
	/// <para>Again, if no valid alternate location mapping is defined, this constitutes a writer error.</para>
	/// <para>
	/// An alternate location mapping is used only during a restore operation and should not be confused with an alternate path, which
	/// is used only during a backup operation.
	/// </para>
	/// <para>For more information on backup and restore file locations under VSS, see Non-Default Backup And Restore Locations.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/vswriter/nf-vswriter-ivsscreatewritermetadata-addalternatelocationmapping
	// HRESULT AddAlternateLocationMapping( [in] LPCWSTR wszSourcePath, [in] LPCWSTR wszSourceFilespec, [in] bool bRecursive, [in]
	// LPCWSTR wszDestination );
	void AddAlternateLocationMapping(string wszSourcePath, string wszSourceFilespec, bool bRecursive, string wszDestination);

	/// <summary>The <c>AddComponent</c> method adds a database or file group as a component to be backed up.</summary>
	/// <param name="ct">
	/// <para>A VSS_COMPONENT_TYPE enumeration value specifying the type of the component.</para>
	/// <para>
	/// <c>Windows Server 2003 and Windows XP:</c> Before Windows Server 2003 with SP1, this parameter is reserved for system use, and
	/// the caller should not override the default value.
	/// </para>
	/// </param>
	/// <param name="wszLogicalPath">
	/// <para>
	/// A pointer to a <c>null</c>-terminated wide character string containing the logical path of the database or file group. For more
	/// information, see Logical Pathing of Components.
	/// </para>
	/// <para>A logical path is optional and can be <c>NULL</c>.</para>
	/// </param>
	/// <param name="wszComponentName">
	/// <para>A pointer to a <c>null</c>-terminated wide character string containing the name of the component. This string is not localized.</para>
	/// <para>This parameter is required and cannot be <c>NULL</c>. The string cannot contain backslashes.</para>
	/// </param>
	/// <param name="wszCaption">
	/// <para>
	/// A pointer to a <c>null</c>-terminated wide character string containing a description (also called a "friendly name") for the
	/// component. This string might be localized, and therefore requesters must assume that it is localized.
	/// </para>
	/// <para>This parameter is optional and can be <c>NULL</c>. The string can contain backslashes.</para>
	/// </param>
	/// <param name="pbIcon">
	/// <para>
	/// A pointer to a bitmap of the icon representing the database, to be displayed in a user interface. The size, in bytes, of the
	/// buffer is specified by the cbIcon parameter.
	/// </para>
	/// <para>If the writer does not want to specify an icon, pbIcon should be set to <c>NULL</c>.</para>
	/// </param>
	/// <param name="bRestoreMetadata">This parameter is reserved for future use and should always be set to <c>false</c>.</param>
	/// <param name="bNotifyOnBackupComplete">This parameter is reserved for future use and should always be set to <c>false</c>.</param>
	/// <param name="bSelectable">
	/// A Boolean that indicates whether the component can be optionally backed up (which means it can be excluded from the backup) or
	/// is always backed up when any of the writer's component is backed up. The Boolean is <c>true</c> if the component can be
	/// selectively backed up and <c>false</c> if it is backed up when any of the components is backed up.
	/// </param>
	/// <param name="bSelectableForRestore">
	/// <para>
	/// A Boolean that determines whether a component can be individually restored when it has not been explicitly included in the
	/// backup document. If the component was explicitly added to the backup document, it can always be individually selected for
	/// restore; in this case, this flag has no meaning.
	/// </para>
	/// <para>
	/// When <c>true</c>, the component can be restored by itself; when <c>false</c>, the component can be restored only if the entire
	/// component set is being restored. (See VSS_COMPONENTINFO and Working with Selectability and Logical Paths for more information).
	/// </para>
	/// <para>The default value for this parameter is <c>false</c>.</para>
	/// </param>
	/// <param name="dwComponentFlags">
	/// <para>
	/// A bit mask (or bitwise OR) of members of the VSS_COMPONENT_FLAGS enumeration indicating the features that this component supports.
	/// </para>
	/// <para>The default value for this argument is zero.</para>
	/// </param>
	/// <remarks>
	/// <para>This method can be called multiple times to add several components to a writer's metadata.</para>
	/// <para>
	/// The combination of logical path and name for each component of a given instance of a given class of writer must be unique.
	/// Attempting to call <c>AddComponent</c> twice with the same values of wszLogicalPath and wszComponentName results in a
	/// VSS_E_OBJECT_ALREADY_EXISTS error.
	/// </para>
	/// <para>
	/// <c>AddComponent</c> can be used to add subcomponents—components in which all member files are backed up as a group, but which
	/// contain files that can be restored individually. See Working with Selectability for Restore and Subcomponents for more information.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/vswriter/nf-vswriter-ivsscreatewritermetadata-addcomponent HRESULT
	// AddComponent( [in] VSS_COMPONENT_TYPE ct, [in] LPCWSTR wszLogicalPath, [in] LPCWSTR wszComponentName, [in] LPCWSTR wszCaption,
	// [in] const BYTE *pbIcon, [in] UINT cbIcon, [in] bool bRestoreMetadata, [in] bool bNotifyOnBackupComplete, [in] bool bSelectable,
	// [in] bool bSelectableForRestore, [in] DWORD dwComponentFlags );
	void AddComponent(VSS_COMPONENT_TYPE ct, [Optional] string? wszLogicalPath, string wszComponentName, [Optional] string? wszCaption, byte[]? pbIcon,
		bool bRestoreMetadata, bool bNotifyOnBackupComplete, bool bSelectable, bool bSelectableForRestore = false,
		VSS_COMPONENT_FLAGS dwComponentFlags = 0);

	/// <summary>
	/// The <c>AddComponentDependency</c> method allows a writer to indicate that a component it manages has an explicit
	/// writer-component dependency; that is, another component in another writer must be backed up and restored with it.
	/// </summary>
	/// <param name="wszForLogicalPath">
	/// A null-terminated wide character string containing the logical path of the component (managed by the current writer) that
	/// requires a dependency.
	/// </param>
	/// <param name="wszForComponentName">
	/// A null-terminated wide character string containing the component (managed by the current writer) that requires a dependency.
	/// </param>
	/// <param name="onWriterId">
	/// The class ID or VSS_ID (GUID) of the writer managing the component on which the current component depends.
	/// </param>
	/// <param name="wszOnLogicalPath">
	/// The logical path of the component (managed by the writer identified by onWriterId) on which the current component depends.
	/// </param>
	/// <param name="wszOnComponentName">
	/// The name of the component (managed by the writer identified by onWriterId) on which the current component depends.
	/// </param>
	/// <remarks>
	/// <para>Dependencies upon components managed by the current writer are not permitted.</para>
	/// <para>
	/// A dependency requires that both the target of the dependency and the component that depends on the target be restored and backed
	/// up together. It does not indicate a priority between the components, although a requester may choose to implement that.
	/// </para>
	/// <para>
	/// Because the combination of logical name and component name must be unique across all instances of a writer class, the fact that
	/// several writers may have the same class ID is not a problem.
	/// </para>
	/// <para>
	/// This method can be used to declare remote dependencies. A writer can declare a remote dependency by prepending
	/// "\\RemoteComputerName", where RemoteComputerName is the name of the computer where the remote component resides, to the logical
	/// path in the wszOnLogicalPath parameter. The value of RemoteComputerName can be an IP address or a computer name returned by the
	/// GetComputerNameEx function.
	/// </para>
	/// <para>
	/// If the remote component resides on a cluster, the writer must report the virtual name for the cluster, and it is the requester's
	/// responsibility to map the virtual name to the physical name of a cluster node before a volume shadow copy can be created.
	/// </para>
	/// <para>
	/// To determine whether a dependency is local or remote, the requester must examine the component name returned in the
	/// pbstrComponentName parameter. If the component name begins with "\", the requester must assume that it specifies a remote
	/// dependency and that the first component following "\" is the RemoteComputerName that was specified by the writer. If the
	/// component name does not begin with "\", the requester should assume that it specifies a local dependency.
	/// </para>
	/// <para>
	/// <c>Windows Server 2003:</c> This method cannot be used to declare remote dependencies until Windows Server 2003 with Service
	/// Pack 1 (SP1).
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/vswriter/nf-vswriter-ivsscreatewritermetadata-addcomponentdependency HRESULT
	// AddComponentDependency( [in] LPCWSTR wszForLogicalPath, [in] LPCWSTR wszForComponentName, [in] VSS_ID onWriterId, [in] LPCWSTR
	// wszOnLogicalPath, [in] LPCWSTR wszOnComponentName );
	void AddComponentDependency(string wszForLogicalPath, string wszForComponentName, Guid onWriterId, string wszOnLogicalPath,
		string wszOnComponentName);

	/// <summary>
	/// The <c>AddDatabaseFiles</c> method indicates the file set (the specified file or files) that make up the database component to
	/// be backed up.
	/// </summary>
	/// <param name="wszLogicalPath">
	/// <para>
	/// Pointer to a <c>null</c>-terminated wide character string containing the logical path of the component to which the database
	/// will be added.
	/// </para>
	/// <para>For more information, see Logical Pathing of Components.</para>
	/// <para>A logical path is not required and can be <c>NULL</c>.</para>
	/// </param>
	/// <param name="wszDatabaseName">
	/// <para>Pointer to a <c>null</c>-terminated wide character string containing the name of the database.</para>
	/// <para>This name is required and must match the name of the component to which the database is being added.</para>
	/// </param>
	/// <param name="wszPath">
	/// <para>
	/// Pointer to a <c>null</c>-terminated wide character string containing the path of the directory containing the database file.
	/// </para>
	/// <para>The path can contain environment variables (for example, %SystemRoot%) but cannot contain wildcard characters.</para>
	/// <para>UNC paths are supported.</para>
	/// <para>
	/// There is no requirement that the path end with a backslash (""). It is up to applications that retrieve this information to check.
	/// </para>
	/// </param>
	/// <param name="wszFilespec">
	/// <para>
	/// Pointer to a <c>null</c>-terminated wide character string containing the file specification of the file or files associated with
	/// the database.
	/// </para>
	/// <para>
	/// A file specification cannot contain directory specifications (for example, no backslashes) but can contain the ? and * wildcard characters.
	/// </para>
	/// </param>
	/// <param name="dwBackupTypeMask">
	/// <para>
	/// A bit mask (or bitwise OR) of VSS_FILE_SPEC_BACKUP_TYPE enumeration values to indicate whether a writer should evaluate the file
	/// for participation in certain types of backup operations.
	/// </para>
	/// <para>The default value for this argument is (VSS_FSBT_ALL_BACKUP_REQUIRED | VSS_FSBT_ALL_SNAPSHOT_REQUIRED).</para>
	/// </param>
	/// <remarks>
	/// <para>
	/// <c>Windows 7, Windows Server 2008 R2, Windows Vista, Windows Server 2008, Windows XP and Windows Server 2003:</c> Remote file
	/// shares are not supported until Windows 8 and Windows Server 2012. Writers support only local resources—sets of files whose
	/// absolute path starts with a valid local volume specification and cannot be a mapped network drive. Therefore, path inputs
	/// (wszPath) to <c>AddDatabaseFiles</c> (after the resolution of any environment variables) must be in this format.
	/// </para>
	/// <para>
	/// This method can be called multiple times for a particular database. This is done when the database exists on files stored on
	/// separate volumes, as is possible with Microsoft SQL Server.
	/// </para>
	/// <para>
	/// The values of the wszLogicalPath and wszDatabaseName parameters should match those of one of the database components previously
	/// added with the IVssCreateWriterMetadata::AddComponent method.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/vswriter/nf-vswriter-ivsscreatewritermetadata-adddatabasefiles HRESULT
	// AddDatabaseFiles( [in] LPCWSTR wszLogicalPath, [in] LPCWSTR wszDatabaseName, [in] LPCWSTR wszPath, [in] LPCWSTR wszFilespec, [in]
	// DWORD dwBackupTypeMask );
	void AddDatabaseFiles([Optional] string? wszLogicalPath, string wszDatabaseName, string wszPath, string wszFilespec,
		VSS_FILE_SPEC_BACKUP_TYPE dwBackupTypeMask = VSS_FILE_SPEC_BACKUP_TYPE.VSS_FSBT_ALL_BACKUP_REQUIRED | VSS_FILE_SPEC_BACKUP_TYPE.VSS_FSBT_ALL_SNAPSHOT_REQUIRED);

	/// <summary>
	/// The <c>AddDatabaseLogFiles</c> method indicates the log files that are associated with a database to be backed up, as well as
	/// their location.
	/// </summary>
	/// <param name="wszLogicalPath">
	/// <para>
	/// Pointer to a <c>null</c>-terminated wide character string containing the logical path of the database component to which the log
	/// files will be added.
	/// </para>
	/// <para>For more information, see Logical Pathing of Components.</para>
	/// <para>A logical path is not required, and can be <c>NULL</c>.</para>
	/// </param>
	/// <param name="wszDatabaseName">
	/// Pointer to a <c>null</c>-terminated wide character string containing the name of the database component associated with the log
	/// files. The type of this component must be VSS_CT_DATABASE; otherwise, the method will return an error.
	/// </param>
	/// <param name="wszPath">
	/// <para>Pointer to a <c>null</c>-terminated wide character string containing the path of the directory containing the log files.</para>
	/// <para>The directory can be a local directory on the VSS machine, or it can be a file share directory on a remote file server.</para>
	/// <para>UNC paths are supported.</para>
	/// <para>The path can contain environment variables (for example, %SystemRoot%) but cannot contain wildcard characters.</para>
	/// <para>
	/// There is no requirement that the path end with a backslash (""). It is up to applications that retrieve this information to check.
	/// </para>
	/// </param>
	/// <param name="wszFilespec">
	/// <para>
	/// Pointer to a <c>null</c>-terminated wide character string containing the file specification of the log file(s) associated with
	/// the database.
	/// </para>
	/// <para>
	/// A file specification cannot contain directory specifications (for example, no backslashes) but can contain the ? and * wildcard characters.
	/// </para>
	/// </param>
	/// <param name="dwBackupTypeMask">
	/// <para>
	/// A bit mask (or bitwise OR) of VSS_FILE_SPEC_BACKUP_TYPE enumeration values to indicate if a writer should evaluate the file for
	/// participation in a certain type of backup operations.
	/// </para>
	/// <para>The default value for this argument is (VSS_FSBT_ALL_BACKUP_REQUIRED | VSS_FSBT_ALL_SNAPSHOT_REQUIRED).</para>
	/// </param>
	/// <remarks>
	/// <para>
	/// <c>Windows 7, Windows Server 2008 R2, Windows Vista, Windows Server 2008, Windows XP and Windows Server 2003:</c> Remote file
	/// shares are not supported until Windows 8 and Windows Server 2012. Writers support only local resources—sets of files whose
	/// absolute path starts with a valid local volume specification and cannot be a mapped network drive. Therefore, path inputs
	/// (wszPath) to <c>AddDatabaseLogFiles</c> (after the resolution of any environment variables) must be in this format.
	/// </para>
	/// <para>
	/// This method can be called multiple times for a particular database component, which might be needed when several log files are
	/// stored on separate volumes.
	/// </para>
	/// <para>
	/// The values of the wszLogicalPath and wszDatabaseName parameters should match those of one of the database components previously
	/// added with the IVssCreateWriterMetadata::AddComponent method.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/vswriter/nf-vswriter-ivsscreatewritermetadata-adddatabaselogfiles HRESULT
	// AddDatabaseLogFiles( [in] LPCWSTR wszLogicalPath, [in] LPCWSTR wszDatabaseName, [in] LPCWSTR wszPath, [in] LPCWSTR wszFilespec,
	// [in] DWORD dwBackupTypeMask );
	void AddDatabaseLogFiles([Optional] string? wszLogicalPath, string wszDatabaseName, string wszPath, string wszFilespec,
		VSS_FILE_SPEC_BACKUP_TYPE dwBackupTypeMask = VSS_FILE_SPEC_BACKUP_TYPE.VSS_FSBT_ALL_BACKUP_REQUIRED | VSS_FILE_SPEC_BACKUP_TYPE.VSS_FSBT_ALL_SNAPSHOT_REQUIRED);

	/// <summary>
	/// The <c>AddExcludeFiles</c> method is used to explicitly exclude a file set (a specified file or files) that might otherwise be
	/// implicitly included when a component of the current writer is backed up.
	/// </summary>
	/// <param name="wszPath">
	/// <para>Pointer to a null-terminated wide character string containing the root directory under which files are to be excluded.</para>
	/// <para>The directory can be a local directory on the VSS machine, or it can be a file share directory on a remote file server.</para>
	/// <para>UNC paths are supported.</para>
	/// <para>The path can contain environment variables (for example, %SystemRoot%) but cannot contain wildcard characters.</para>
	/// <para>
	/// There is no requirement that the path end with a backslash (""). It is up to applications that retrieve this information to check.
	/// </para>
	/// </param>
	/// <param name="wszFilespec">
	/// <para>Pointer to a null-terminated wide character string containing the file specification of the files to be excluded.</para>
	/// <para>
	/// A file specification cannot contain directory specifications (for example, no backslashes) but can contain the ? and * wildcard characters.
	/// </para>
	/// </param>
	/// <param name="bRecursive">
	/// <para>
	/// A Boolean value specifying whether the path specified by the wszPath parameter identifies only a single directory or if it
	/// indicates a hierarchy of directories to be traversed recursively. This parameter should be set to <c>true</c> if the path is
	/// treated as a hierarchy of directories to be recursed through, or <c>false</c> otherwise.
	/// </para>
	/// <para>For information on traversing over mounted folders, see Working with Mounted Folders and Reparse Points.</para>
	/// </param>
	/// <remarks>
	/// <para>
	/// <c>Windows 7, Windows Server 2008 R2, Windows Vista, Windows Server 2008, Windows XP and Windows Server 2003:</c> Remote file
	/// shares are not supported until Windows 8 and Windows Server 2012. Writers support only local resources—sets of files whose
	/// absolute path starts with a valid local volume specification and cannot be a mapped network drive. Therefore, path inputs
	/// (wszPath) to <c>AddExcludeFiles</c> (after the resolution of any environment variables) must be in this format.
	/// </para>
	/// <para>
	/// For example, it is often convenient to define a component to include all files in a given directory and then use
	/// <c>AddExcludeFiles</c> to explicitly remove some files (for instance, temporary files) from a backup.
	/// </para>
	/// <para>For more information on excluding files, see Exclude File List Specification.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/vswriter/nf-vswriter-ivsscreatewritermetadata-addexcludefiles HRESULT
	// AddExcludeFiles( [in] LPCWSTR wszPath, [in] LPCWSTR wszFilespec, [in] bool bRecursive );
	void AddExcludeFiles(string wszPath, string wszFilespec, bool bRecursive);

	/// <summary>The <c>AddFilesToFileGroup</c> method adds a file set (a specified file or files) to a specified file group component.</summary>
	/// <param name="wszLogicalPath">
	/// Pointer to a <c>null</c>-terminated wide character string containing the logical path (which may be <c>NULL</c>) of the
	/// component to which to add the files. For more information, see Logical Pathing of Components.
	/// </param>
	/// <param name="wszGroupName">
	/// Pointer to a <c>null</c>-terminated wide character string containing the name of the file group component. The type of this
	/// component must be VSS_CT_FILEGROUP; otherwise, the method will return an error.
	/// </param>
	/// <param name="wszPath">
	/// <para>Pointer to a <c>null</c>-terminated wide character string containing the default root directory of the files to be added.</para>
	/// <para>The directory can be a local directory on the VSS machine, or it can be a file share directory on a remote file server.</para>
	/// <para>UNC paths are supported.</para>
	/// <para>The path can contain environment variables (for example, %SystemRoot%) but cannot contain wildcard characters.</para>
	/// <para>
	/// There is no requirement that the path end with a backslash (""). It is up to applications that retrieve this information to check.
	/// </para>
	/// </param>
	/// <param name="wszFilespec">
	/// <para>Pointer to a <c>null</c>-terminated wide character string containing the file specification of the files to be included.</para>
	/// <para>
	/// A file specification cannot contain directory specifications (for example, no backslashes) but can contain the ? and * wildcard characters.
	/// </para>
	/// </param>
	/// <param name="bRecursive">
	/// <para>
	/// A Boolean value specifying whether the path specified by the wszPath parameter identifies only a single directory or if it
	/// indicates a hierarchy of directories to be traversed recursively. This parameter should be set to <c>true</c> if the path is
	/// treated as a hierarchy of directories to be recursed through, or <c>false</c> otherwise.
	/// </para>
	/// <para>For information on traversing over mounted folders, see Working with Mounted Folders and Reparse Points.</para>
	/// </param>
	/// <param name="wszAlternateLocation">
	/// <para>
	/// Pointer to a <c>null</c>-terminated wide character string containing the alternate path, which actually contains the files to be
	/// backed up with this component.
	/// </para>
	/// <para>The directory can be a local directory on the VSS machine, or it can be a file share directory on a remote file server.</para>
	/// <para>UNC paths are supported.</para>
	/// <para>Specifying an alternate path is optional; if no alternate path is needed, wszAlternatePath should be <c>NULL</c>.</para>
	/// <para>An alternate path should not be confused with an alternate location mapping.</para>
	/// </param>
	/// <param name="dwBackupTypeMask">
	/// <para>
	/// A bitmask of VSS_FILE_SPEC_BACKUP_TYPE enumeration values to indicate if a writer should evaluate the file for participation in
	/// a certain type of backup operations.
	/// </para>
	/// <para>The default value for this argument is (VSS_FSBT_ALL_BACKUP_REQUIRED | VSS_FSBT_ALL_SNAPSHOT_REQUIRED).</para>
	/// </param>
	/// <remarks>
	/// <para>
	/// <c>Windows 7, Windows Server 2008 R2, Windows Vista, Windows Server 2008, Windows XP and Windows Server 2003:</c> Remote file
	/// shares are not supported until Windows 8 and Windows Server 2012. Writers support only local resources—sets of files whose
	/// absolute path starts with a valid local volume specification and cannot be a mapped network drive. Therefore, path inputs
	/// (wszPath and wszAlternatePath) to <c>AddFilesToFileGroup</c> (after the resolution of any environment variables) must be in this format.
	/// </para>
	/// <para>
	/// A writer can call this method multiple times to add several sets of files to its file group component. However, you should make
	/// sure that the file specifications do not overlap, because a particular file can be specified only once.
	/// </para>
	/// <para>
	/// The locations from which files are backed up and to which they are restored depends on the values for the root directory defined
	/// by wszPath and the alternate path defined by wszAlternatePath.
	/// </para>
	/// <para>Note the following when using path information provided by <c>AddFilesToFileGroup</c>:</para>
	/// <list type="bullet">
	/// <item>
	/// <term>
	/// Restore operations should (if possible) restore files added to a component by <c>AddFilesToFileGroup</c> under the default root
	/// directory defined by wszPath.
	/// </term>
	/// </item>
	/// <item>
	/// <term>
	/// If an alternate path is not specified (if wszAlternatePath is <c>NULL</c>), the files added to the component will be backed up
	/// from the default root directory and restored to the default root directory indicated by wszPath.
	/// </term>
	/// </item>
	/// <item>
	/// <term>
	/// If an alternate path is specified (if wszAlternatePath is non- <c>NULL</c>), files added to the component are backed up from the
	/// alternate path specified by wszAlternatePath. However, requesters will still use wszPath as the default restoration location.
	/// </term>
	/// </item>
	/// <item>
	/// <term>
	/// If the alternate path is defined (wszAlternatePath is non- <c>NULL</c>) and there are files matching the file specification
	/// (wszFilespec) in both the alternate path and the default root directory (wszPath), then a backup operation should back up files
	/// located under the alternate path, not files located under the default root directory.
	/// </term>
	/// </item>
	/// <item>
	/// <term>
	/// Files should be restored to the directory indicated by wszPath unless an alternate location mapping was set by
	/// IVssCreateWriterMetadata::AddAlternateLocationMapping and the restore method or restore target requires it.
	/// </term>
	/// </item>
	/// </list>
	/// <para>For more information on backup and restore file locations under VSS, see Non-Default Backup And Restore Locations.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/vswriter/nf-vswriter-ivsscreatewritermetadata-addfilestofilegroup HRESULT
	// AddFilesToFileGroup( [in] LPCWSTR wszLogicalPath, [in] LPCWSTR wszGroupName, [in] LPCWSTR wszPath, [in] LPCWSTR wszFilespec, [in]
	// bool bRecursive, [in] LPCWSTR wszAlternateLocation, [in] DWORD dwBackupTypeMask );
	void AddFilesToFileGroup([Optional] string? wszLogicalPath, string wszGroupName, string wszPath, string wszFilespec, bool bRecursive,
		[Optional] string? wszAlternateLocation,
		VSS_FILE_SPEC_BACKUP_TYPE dwBackupTypeMask = VSS_FILE_SPEC_BACKUP_TYPE.VSS_FSBT_ALL_BACKUP_REQUIRED | VSS_FILE_SPEC_BACKUP_TYPE.VSS_FSBT_ALL_SNAPSHOT_REQUIRED);

	/// <summary>
	/// The <c>SaveAsXML</c> method saves the Writer Metadata Document that contains a writer's state information to a specified string.
	/// </summary>
	/// <returns>Pointer to a string to be used to store the Writer Metadata Document that contains a writer's state information.</returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/vswriter/nf-vswriter-ivsscreatewritermetadata-saveasxml HRESULT SaveAsXML(
	// [in] BSTR *pbstrXML );
	string SaveAsXML();

	/// <summary>
	/// The <c>SetBackupSchema</c> method is used by a writer to indicate in its Writer Metadata Document the types of backup operations
	/// it can participate in.
	/// </summary>
	/// <param name="dwSchemaMask">
	/// <para>The types of backup operations this writer supports expressed as a bitmask of VSS_BACKUP_SCHEMA enumeration values.</para>
	/// <para>
	/// For express writers, only the <c>VSS_BS_UNDEFINED</c>, <c>VSS_BS_COPY</c>, and <c>VSS_BS_INDEPENDENT_SYSTEM_STATE</c> values are supported.
	/// </para>
	/// </param>
	/// <remarks>
	/// <para>
	/// If no schema is explicitly set by <c>SetBackupSchema</c>, the writer will be assigned the default value of VSS_BS_UNDEFINED: the
	/// writer supports only simple full backup and restoration of entire files (as defined by VSS_BT_FULL), there is no support for
	/// incremental or differential backups, and partial files are not supported.
	/// </para>
	/// <para>Requesters call IVssExamineWriterMetadata::GetBackupSchema to retrieve a writer's backup schemas as set by <c>SetBackupSchema</c>.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/vswriter/nf-vswriter-ivsscreatewritermetadata-setbackupschema HRESULT
	// SetBackupSchema( [in] DWORD dwSchemaMask );
	void SetBackupSchema(VSS_BACKUP_SCHEMA dwSchemaMask);

	/// <summary>The <c>SetRestoreMethod</c> method indicates how the writer's data is to be restored.</summary>
	/// <param name="method">VSS_RESTOREMETHOD_ENUM value specifying the method that will be used in the restore operation.</param>
	/// <param name="wszService">
	/// <para>
	/// A pointer to a wide character string containing the name of a service that must be stopped prior to a restore operation and then
	/// started after the restore operation takes place, if the value of method is VSS_RME_STOP_RESTORE_START or VSS_RME_RESTORE_STOP_START.
	/// </para>
	/// <para>
	/// If the value of method is not VSS_RME_STOP_RESTORE_START or VSS_RME_RESTORE_STOP_START, this argument is not used and should be
	/// set to <c>NULL</c>.
	/// </para>
	/// </param>
	/// <param name="wszUserProcedure">Reserved for future use. The value of this parameter should always be set to <c>NULL</c>.</param>
	/// <param name="writerRestore">
	/// <para>VSS_WRITERRESTORE_ENUM value specifying whether the writer will be involved in restoring its data.</para>
	/// <para>Express writers must set this parameter to VSS_WRE_NEVER.</para>
	/// </param>
	/// <param name="bRebootRequired">Boolean indicating whether a reboot will be required after the restore operation is complete.</param>
	/// <remarks>
	/// <para>
	/// There is a single restore method defined for a writer. If the restore method is not overridden, all of the writer's components
	/// will be restored using the same method.
	/// </para>
	/// <para>
	/// Writers override the restore method on a component-by-component basis by setting a restore target, typically while handling a
	/// PreRestore event (CVssWriter::OnPreRestore).
	/// </para>
	/// <para>
	/// It is important to note that despite the fact that restore methods are applied writer-wide, methods are implemented on a
	/// per-component basis. For example, if the method specified by the method parameter is VSS_RME_RESTORE_IF_CAN_REPLACE, then all of
	/// the files in the component are restored to their original location if they can all be replaced without an error occurring.
	/// Otherwise, they are restored to their alternate location if one is specified.
	/// </para>
	/// <para>A file should always be restored to its alternate location mapping if either of the following is true:</para>
	/// <list type="bullet">
	/// <item>
	/// <term>The restore method (set at backup time) is VSS_RME_RESTORE_TO_ALTERNATE_LOCATION.</term>
	/// </item>
	/// <item>
	/// <term>Its restore target was set (at restore time) to VSS_RT_ALTERNATE.</term>
	/// </item>
	/// </list>
	/// <para>In either case, if no valid alternate location mapping is defined, this constitutes a writer error.</para>
	/// <para>A file can be restored to an alternate location mapping if either of the following is true:</para>
	/// <list type="bullet">
	/// <item>
	/// <term>The restore method is VSS_RME_RESTORE_IF_NOT_THERE and a version of the file is already present on disk.</term>
	/// </item>
	/// <item>
	/// <term>The restore method is VSS_RME_RESTORE_IF_CAN_REPLACE and a version of the file is present on disk and cannot be replaced.</term>
	/// </item>
	/// </list>
	/// <para>Again, if no valid alternate location mapping is defined, this constitutes a writer error.</para>
	/// <para>
	/// An alternate location mapping is used only during a restore operation and should not be confused with an alternate path, which
	/// is used only during a backup operation.
	/// </para>
	/// <para>For more information about restore methods, see Setting VSS Restore Methods.</para>
	/// <para>
	/// If the restore method is VSS_RME_STOP_RESTORE_START or VSS_RME_RESTORE_STOP_START, then the correct name of the service must be
	/// provided as the wszService argument. For information on writer participation in stopping and restarting services during a
	/// restore operation, see Stopping Services for Restore by Requesters.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/vswriter/nf-vswriter-ivsscreatewritermetadata-setrestoremethod HRESULT
	// SetRestoreMethod( [in] VSS_RESTOREMETHOD_ENUM method, [in] LPCWSTR wszService, [in] LPCWSTR wszUserProcedure, [in]
	// VSS_WRITERRESTORE_ENUM writerRestore, [in] bool bRebootRequired );
	void SetRestoreMethod(VSS_RESTOREMETHOD_ENUM method, [Optional] string? wszService, [Optional] string? wszUserProcedure,
		VSS_WRITERRESTORE_ENUM writerRestore, bool bRebootRequired);
}

/// <summary>
/// <para>
/// The <c>IVssCreateWriterMetadataEx</c> interface defines a method to report any file sets that will be explicitly excluded when a
/// shadow copy is created. This interface is used only in the CVssWriterEx::OnIdentifyEx method.
/// </para>
/// <para>The <c>IVssCreateWriterMetadataEx</c> interface inherits from the IVssCreateWriterMetadata interface and IUnknown.</para>
/// </summary>
// https://docs.microsoft.com/en-us/windows/win32/api/vswriter/nl-vswriter-ivsscreatewritermetadataex
[PInvokeData("vswriter.h", MSDNShortId = "NL:vswriter.IVssCreateWriterMetadataEx")]
public interface IVssCreateWriterMetadataEx : IVssCreateWriterMetadata
{
	/// <summary>
	/// <para>Reports any file sets that will be explicitly excluded by the writer when a shadow copy is created.</para>
	/// <para>
	/// Calling this method does not cause the files to be excluded. The writer is responsible for deleting the files from the shadow
	/// copy in its CVssWriter::OnPostSnapshot method.
	/// </para>
	/// </summary>
	/// <param name="wszPath">
	/// <para>A pointer to a null-terminated wide character string containing the root directory under which files are to be excluded.</para>
	/// <para>The directory can be a local directory on the VSS machine, or it can be a file share directory on a remote file server.</para>
	/// <para>UNC paths are supported.</para>
	/// <para>The path can contain environment variables (for example, %SystemRoot%) but cannot contain wildcard characters.</para>
	/// <para>
	/// There is no requirement that the path end with a backslash (""). It is up to applications that retrieve this information to
	/// check whether the path ends with a backslash.
	/// </para>
	/// </param>
	/// <param name="wszFilespec">
	/// <para>A pointer to a null-terminated wide character string containing the file specification of the files to be excluded.</para>
	/// <para>
	/// A file specification cannot contain directory specifications (for example, no backslashes) but can contain the ? and * wildcard characters.
	/// </para>
	/// </param>
	/// <param name="bRecursive">
	/// <para>
	/// A Boolean value specifying whether the path specified by the wszPath parameter identifies only a single directory or if it
	/// indicates a hierarchy of directories to be traversed recursively. This parameter should be set to <c>true</c> if the path is
	/// treated as a hierarchy of directories to be recursed through, or <c>false</c> otherwise.
	/// </para>
	/// <para>For information on traversing over mounted folders, see Working with Mounted Folders and Reparse Points.</para>
	/// </param>
	/// <remarks>
	/// <para>
	/// <c>Windows 7, Windows Server 2008 R2, Windows Vista, Windows Server 2008, Windows XP and Windows Server 2003:</c> Remote file
	/// shares are not supported until Windows 8 and Windows Server 2012.
	/// </para>
	/// <para>
	/// The use of the <c>AddExcludeFilesFromSnapshot</c> method is optional. Writers should use this method only for large files that
	/// change significantly between shadow copy operations.
	/// </para>
	/// <para>
	/// This method is not a substitute for the IVssCreateWriterMetadata::AddExcludeFiles method. Writers should continue to use the
	/// <c>AddExcludeFiles</c> method to report which file sets are excluded from backup.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/vswriter/nf-vswriter-ivsscreatewritermetadataex-addexcludefilesfromsnapshot
	// HRESULT AddExcludeFilesFromSnapshot( [in] LPCWSTR wszPath, [in] LPCWSTR wszFilespec, [in] bool bRecursive );
	void AddExcludeFilesFromSnapshot(string wszPath, string wszFilespec, bool bRecursive);
}

/// <summary>Defines methods to manage metadata for a VSS express writer.</summary>
// https://docs.microsoft.com/en-us/windows/win32/api/vswriter/nl-vswriter-ivssexpresswriter
[PInvokeData("vswriter.h", MSDNShortId = "NL:vswriter.IVssExpressWriter")]
public interface IVssExpressWriter
{
	/// <summary>Creates an express writer metadata object and returns an IVssCreateExpressWriterMetadata interface pointer to it.</summary>
	/// <param name="writerId">The globally unique identifier (GUID) of the writer class.</param>
	/// <param name="writerName">
	/// A null-terminated wide character string that contains the name of the writer class. This string is not localized.
	/// </param>
	/// <param name="usageType">
	/// A VSS_USAGE_TYPE enumeration value that indicates how the data that is managed by the writer is used on the host system. The
	/// only valid values for this parameter are VSS_UT_BOOTABLESYSTEMSTATE, VSS_UT_SYSTEMSERVICE, and VSS_UT_USERDATA.
	/// </param>
	/// <param name="versionMajor">The major version of the writer application. For more information, see the Remarks section.</param>
	/// <param name="versionMinor">The minor version of the writer application. For more information, see the Remarks section.</param>
	/// <returns>
	/// A pointer to a variable that receives an IVssCreateExpressWriterMetadata interface pointer to the newly created express writer metadata.
	/// </returns>
	/// <remarks>
	/// <para>
	/// The versionMajor and versionMajor parameters are used to specify the writer's major and minor version numbers according to the
	/// following VSS conventions:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>
	/// A writer's minor version number should be incremented by one whenever a released version of the writer contains minor changes
	/// that affect the writer's interaction with requesters. For example, a correction to a file specification in a writer QFE or
	/// service pack would justify incrementing the minor version number. However, a change between beta or release candidate versions
	/// of a writer would not justify the changing of the minor version number.
	/// </term>
	/// </item>
	/// <item>
	/// <term>
	/// A writer's major version number should be incremented by one whenever a released version of the writer contains a significant
	/// change. For example, if data that is backed up with a new version of a writer cannot be restored using the previous version of
	/// the writer, the new writer's major version number should be incremented.
	/// </term>
	/// </item>
	/// <item>
	/// <term>Whenever the major version number is incremented, the minor version number should be reset to zero.</term>
	/// </item>
	/// </list>
	/// <para>If a writer does not specify a version number, VSS will assign a default version number of 0.0.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/vswriter/nf-vswriter-ivssexpresswriter-createmetadata HRESULT CreateMetadata(
	// [in] VSS_ID writerId, [in] LPCWSTR writerName, [in] VSS_USAGE_TYPE usageType, [in] DWORD versionMajor, [in] DWORD versionMinor,
	// [in] DWORD reserved, [out] IVssCreateExpressWriterMetadata **ppMetadata );
	IVssCreateExpressWriterMetadata CreateMetadata(Guid writerId, string writerName, VSS_USAGE_TYPE usageType, uint versionMajor, uint versionMinor);

	/// <summary>Causes VSS to load the writer's metadata from a string instead of the express writer metadata store.</summary>
	/// <param name="metadata">A null-terminated wide character string that contains the writer's metadata.</param>
	// https://docs.microsoft.com/en-us/windows/win32/api/vswriter/nf-vswriter-ivssexpresswriter-loadmetadata HRESULT LoadMetadata( [in]
	// LPCWSTR metadata, [in] DWORD reserved );
	void LoadMetadata(string metadata);

	/// <summary>Causes VSS to store the writer's metadata in the express writer metadata store.</summary>
	/// <remarks>
	/// Before using this method, the caller must have either used the LoadMetadata method to load the writer's metadata directly or
	/// used the CreateMetadata method to create a writer metadata object.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/vswriter/nf-vswriter-ivssexpresswriter-register HRESULT Register();
	void Register();

	/// <summary>Causes VSS to delete the writer's metadata from the express writer metadata store.</summary>
	/// <param name="writerId">The globally unique identifier (GUID) of the writer class.</param>
	/// <remarks>Before using this method, the caller must have used the CreateMetadata method to create a writer metadata object.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/vswriter/nf-vswriter-ivssexpresswriter-unregister HRESULT Unregister( [in]
	// VSS_ID writerId );
	void Unregister(Guid writerId);
}

/// <summary>
/// <para>
/// The <c>IVssWMDependency</c> is returned by the IVssWMComponent interface and used by applications when backing up or restoring a
/// component that has an explicit writer-component dependency on a component managed by another writer. (Dependencies must be between
/// writers, not within writers.)
/// </para>
/// <para>
/// <c>IVssWMDependency</c> is used to determine the writer ID, logical path, and component name of components that must be restored or
/// backed up along with the target component.
/// </para>
/// <para>
/// Dependencies are created by writers while handling Identify events (CVssWriter::OnIdentify) using the
/// IVssCreateWriterMetadata::AddComponentDependency method.
/// </para>
/// <para>The IVssWMComponent::GetDependency method returns an <c>IVssWMDependency</c> interface.</para>
/// <para>
/// Note that a dependency does not indicate an order of preference between the component with the documented dependencies and the
/// components it depends on. A dependency merely indicates that the component and the components it depends on must always be backed up
/// or restored together.
/// </para>
/// </summary>
// https://docs.microsoft.com/en-us/windows/win32/api/vswriter/nl-vswriter-ivsswmdependency
[PInvokeData("vswriter.h", MSDNShortId = "NL:vswriter.IVssWMDependency")]
public interface IVssWMDependency
{
	/// <summary>
	/// The <c>GetComponentName</c> method retrieves the name of a component that the current component depends on in an explicit
	/// writer-component dependency.
	/// </summary>
	/// <value>
	/// The address of a caller-allocated variable that receives a <c>NULL</c>-terminated wide character string containing the name of
	/// the component that the current component depends on.
	/// </value>
	/// <remarks>
	/// <para>The caller must free the memory used by the returned string by calling SysFreeString.</para>
	/// <para>
	/// A dependency does not indicate an order of preference between the component with the documented dependencies and the components
	/// it depends on. A dependency merely indicates that the component and the components it depends on must always be backed up or
	/// restored together.
	/// </para>
	/// <para>
	/// It is possible to have multiple instances of a given writer class; however, any component's logical path and name should be unique.
	/// </para>
	/// <para>
	/// If there are multiple instances of a writer class, it will be necessary to use logical path and component name information to
	/// identify the instance managing the component that the current component depends on.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/vswriter/nf-vswriter-ivsswmdependency-getcomponentname HRESULT
	// GetComponentName( BSTR *pbstrComponentName );
	string ComponentName { get; }

	/// <summary>
	/// The <c>GetLogicalPath</c> method retrieves the logical path of a component that the current component depends on in explicit
	/// writer-component dependency.
	/// </summary>
	/// <value>
	/// The address of a caller-allocated variable that receives a <c>NULL</c>-terminated wide character string containing the logical
	/// path of the component that the current component depends on.
	/// </value>
	/// <remarks>
	/// <para>The caller must free the memory used by the returned string by calling SysFreeString.</para>
	/// <para>
	/// A dependency does not indicate an order of preference between the component with the documented dependencies and the components
	/// it depends on. A dependency merely indicates that the component and the components it depends on must always be backed up or
	/// restored together.
	/// </para>
	/// <para>
	/// It is possible to have multiple instances of a given writer class; however, any component's logical path and name should be unique.
	/// </para>
	/// <para>
	/// If there are multiple instances of a writer class, it will be necessary to use logical path and component name information to
	/// identify the instance managing the component that the current component depends on.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/vswriter/nf-vswriter-ivsswmdependency-getlogicalpath HRESULT GetLogicalPath(
	// [out] BSTR *pbstrLogicalPath );
	string LogicalPath { get; }

	/// <summary>
	/// The <c>GetWriterId</c> method retrieves the class ID of a writer containing a component that the current component depends on in
	/// an explicit writer-component dependency.
	/// </summary>
	/// <value>The class ID of a writer that manages a component on which the current component depends.</value>
	/// <remarks>
	/// <para>
	/// A dependency does not indicate an order of preference between the component with the documented dependencies and the components
	/// it depends on. A dependency merely indicates that the component and the components it depends on must always be backed up or
	/// restored together.
	/// </para>
	/// <para>
	/// It is possible to have multiple instances of a given writer class; however, any component's logical path and name should be unique.
	/// </para>
	/// <para>
	/// If there are multiple instances of a writer class, it will be necessary to use logical path and component name information to
	/// identify the instance managing the component that the current component depends on.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/vswriter/nf-vswriter-ivsswmdependency-getwriterid HRESULT GetWriterId( VSS_ID
	// *pWriterId );
	Guid WriterId { get; }
}

/// <summary>
/// <para>
/// The <c>IVssWMFiledesc</c> interface is returned to a calling application by a number of query methods. It provides detailed
/// information about a file or set of files (a file set).
/// </para>
/// <para>The following methods return an <c>IVssWMFiledesc</c> interface:</para>
/// <list type="bullet">
/// <item>
/// <term>IVssComponent::GetAlternateLocationMapping</term>
/// </item>
/// <item>
/// <term>IVssComponent::GetNewTarget</term>
/// </item>
/// <item>
/// <term>IVssExamineWriterMetadata::GetExcludeFile</term>
/// </item>
/// <item>
/// <term>IVssExamineWriterMetadata::GetAlternateLocationMapping</term>
/// </item>
/// <item>
/// <term>IVssWMComponent::GetFile</term>
/// </item>
/// <item>
/// <term>IVssWMComponent::GetDatabaseFile</term>
/// </item>
/// <item>
/// <term>IVssWMComponent::GetDatabaseLogFile</term>
/// </item>
/// </list>
/// </summary>
// https://docs.microsoft.com/en-us/windows/win32/api/vswriter/nl-vswriter-ivsswmfiledesc
[PInvokeData("vswriter.h", MSDNShortId = "NL:vswriter.IVssWMFiledesc")]
public interface IVssWMFiledesc
{
	/// <summary>The <c>GetAlternateLocation</c> method obtains an alternate location for a file set.</summary>
	/// <value>
	/// The address of a caller-allocated variable that receives a string specifying the alternate backup location. The path of this
	/// location can be a local path or the UNC path of a remote file share. If there is no alternate location, the pointer is <c>NULL</c>.
	/// </value>
	/// <remarks>
	/// <para>
	/// <c>Windows 7, Windows Server 2008 R2, Windows Vista, Windows Server 2008, Windows XP and Windows Server 2003:</c> Remote file
	/// shares are not supported until Windows 8 and Windows Server 2012.
	/// </para>
	/// <para>The caller must call SysFreeString to free the memory held by the pbstrAlternateLocation parameter.</para>
	/// <para>
	/// The interpretation of the alternate location returned by <c>GetAlternateLocation</c> differs depending on the method used to
	/// retrieve the IVssWMFiledesc object.
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>IVssExamineWriterMetadata::GetExcludeFile</term>
	/// </item>
	/// <item>
	/// <term>IVssWMComponent::GetDatabaseFile</term>
	/// </item>
	/// <item>
	/// <term>IVssWMComponent::GetDatabaseLogFile</term>
	/// </item>
	/// <item>
	/// <term>IVssWMComponent::GetFile</term>
	/// </item>
	/// </list>
	/// <para>
	/// The value returned by <c>GetAlternateLocation</c> refers to an alternate location mapping when returned by the
	/// IVssExamineWriterMetadata::GetAlternateLocationMapping method.
	/// </para>
	/// <para>
	/// During backup operations, this is the alternate location from which to back up a file. During a restore, it is the alternate
	/// location to which to restore a file.
	/// </para>
	/// <para>For more information, see Non-Default Backup And Restore Locations.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/vswriter/nf-vswriter-ivsswmfiledesc-getalternatelocation HRESULT
	// GetAlternateLocation( [out] BSTR *pbstrAlternateLocation );
	string? AlternateLocation { get; }

	/// <summary>
	/// The <c>GetBackupTypeMask</c> method returns the file backup specification for the files specified by the current file descriptor
	/// as a bit mask (or bitwise OR) of VSS_FILE_SPEC_BACKUP_TYPE values. This information indicates if the files are to be evaluated
	/// by their writer for participation in various specific types of backup operations (or if they will participate in an incremental
	/// or differential backups).
	/// </summary>
	/// <value>
	/// Pointer to a <c>DWORD</c> containing a bit mask (or bitwise OR) of VSS_FILE_SPEC_BACKUP_TYPE values indicating the file backup
	/// specification for the file or file set described by the current IVssWMFiledesc interface.
	/// </value>
	/// <remarks>
	/// A file backup specification is specified by a writer when it adds a file specification to a component using the
	/// IVssCreateWriterMetadata::AddFilesToFileGroup, IVssCreateWriterMetadata::AddDatabaseFiles, or
	/// IVssCreateWriterMetadata::AddDatabaseLogFiles method.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/vswriter/nf-vswriter-ivsswmfiledesc-getbackuptypemask HRESULT
	// GetBackupTypeMask( DWORD *pdwTypeMask );
	VSS_FILE_SPEC_BACKUP_TYPE BackupTypeMask { get; }

	/// <summary>
	/// <para>
	/// The <c>GetFilespec</c> method returns the file specification used to obtain the list of files that the current IVssWMFiledesc
	/// object is a member of.
	/// </para>
	/// <para>A querying method used a path and this file specification to return the current IVssWMFiledesc object.</para>
	/// </summary>
	/// <value>
	/// <para>The address of a caller-allocated variable that receives a string specifying the returned file specification.</para>
	/// <para>
	/// A file specification cannot contain directory specifications (for example, no backslashes) but can contain the ? and * wildcard characters.
	/// </para>
	/// </value>
	/// <remarks>The caller must call SysFreeString to free the memory held by the pbstrFilespec parameter.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/vswriter/nf-vswriter-ivsswmfiledesc-getfilespec HRESULT GetFilespec( [out]
	// BSTR *pbstrFilespec );
	string FileSpec { get; }

	/// <summary>
	/// <para>
	/// The <c>GetPath</c> method obtains the fully qualified directory path or the UNC path of the remote file share to obtain the list
	/// of files described in the current IVssWMFiledesc object.
	/// </para>
	/// <para>A querying method used this path and a file specification to return the current IVssWMFiledesc object.</para>
	/// </summary>
	/// <value>
	/// <para>
	/// The address of a caller-allocated variable that receives a <c>NULL</c>-terminated wide character string specifying the fully
	/// qualified directory path or the UNC path of the remote file share directory.
	/// </para>
	/// <para>The path can be a long or short file name and can use the prefix "\?". For more information, see Naming a File.</para>
	/// <para>Users of this method need to check to determine whether this path ends with a backslash ("").</para>
	/// </value>
	/// <remarks>
	/// <para>
	/// <c>Windows 7, Windows Server 2008 R2, Windows Vista, Windows Server 2008, Windows XP and Windows Server 2003:</c> Remote file
	/// shares are not supported until Windows 8 and Windows Server 2012.
	/// </para>
	/// <para>The caller must call SysFreeString to free the memory held by the pbstrPath parameter.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/vswriter/nf-vswriter-ivsswmfiledesc-getpath HRESULT GetPath( [out] BSTR
	// *pbstrPath );
	string Path { get; }

	/// <summary>
	/// The <c>GetRecursive</c> method indicates whether the list of files described in a IVssWMFiledesc object with a root directory
	/// returned by IVssWMFiledesc::GetPath contains only files in that directory or whether the file list contains files from the
	/// directory hierarchy as well.
	/// </summary>
	/// <value>
	/// <para>
	/// A pointer to a Boolean value specifying whether the value returned by IVssWMFiledesc::GetPath identifies only a single directory
	/// or if it indicates a hierarchy of directories to be traversed recursively. The Boolean value receives <c>true</c> if the path is
	/// treated as a hierarchy of directories to be traversed recursively, or <c>false</c> if not.
	/// </para>
	/// <para>For information on traversing over mounted folders, see Working with Mounted Folders and Reparse Points.</para>
	/// </value>
	// https://docs.microsoft.com/en-us/windows/win32/api/vswriter/nf-vswriter-ivsswmfiledesc-getrecursive HRESULT GetRecursive( [out]
	// bool *pbRecursive );
	bool Recursive { get; }
}

/// <summary>
/// <para>
/// The <c>IVssWriterComponents</c> interface contains methods used to obtain and modify component information (in the form of
/// IVssComponent objects) associated with a given writer but stored in a requester's Backup Components Document.
/// </para>
/// <para>
/// The CVssWriter base class is responsible for passing an instance of the <c>IVssWriterComponents</c> interface to the following event handlers:
/// </para>
/// <list type="bullet">
/// <item>
/// <term>CVssWriter::OnPrepareBackup</term>
/// </item>
/// <item>
/// <term>CVssWriter::OnBackupComplete</term>
/// </item>
/// <item>
/// <term>CVssWriter::OnPreRestore</term>
/// </item>
/// <item>
/// <term>CVssWriter::OnPostRestore</term>
/// </item>
/// <item>
/// <term>CVssWriter::OnPostSnapshot</term>
/// </item>
/// </list>
/// <para>
/// In addition, an instance of the IVssWriterComponentsExt interface, which implements a requester-side version of the
/// <c>IVssWriterComponents</c> interface, is returned by IVssBackupComponents::GetWriterComponents.
/// </para>
/// <para><c>IVssWriterComponents</c> defines the following methods.</para>
/// <list type="table">
/// <listheader>
/// <term>Method</term>
/// <term>Description</term>
/// </listheader>
/// <item>
/// <term>GetComponent</term>
/// <term>Returns the components belonging to a given writer instance.</term>
/// </item>
/// <item>
/// <term>GetComponentCount</term>
/// <term>Returns the number of components belonging to a given writer instance.</term>
/// </item>
/// <item>
/// <term>GetWriterInfo</term>
/// <term>Returns the instance and class identifier of the writer responsible for the components.</term>
/// </item>
/// </list>
/// </summary>
// https://docs.microsoft.com/en-us/windows/win32/api/vswriter/nl-vswriter-ivsswritercomponents
[PInvokeData("vswriter.h", MSDNShortId = "NL:vswriter.IVssWriterComponents")]
public interface IVssWriterComponents
{
	/// <summary>
	/// The <c>GetComponent</c> method returns an IVssComponent interface to one of a given writer's components explicitly stored in the
	/// Backup Components Document.
	/// </summary>
	/// <value>List of IVssComponent objects that contain component information.</value>
	// https://docs.microsoft.com/en-us/windows/win32/api/vswriter/nf-vswriter-ivsswritercomponents-getcomponent HRESULT GetComponent(
	// [in] UINT iComponent, [out] IVssComponent **ppComponent );
	IReadOnlyList<IVssComponent> Components { get; }

	/// <summary>The <c>GetWriterInfo</c> method gets the instance and class identifier of the writer responsible for the components.</summary>
	/// <param name="pidInstance">Identifier of the writer instance.</param>
	/// <param name="pidWriter">Identifier of the writer class.</param>
	// https://docs.microsoft.com/en-us/windows/win32/api/vswriter/nf-vswriter-ivsswritercomponents-getwriterinfo HRESULT GetWriterInfo(
	// [out] VSS_ID *pidInstance, [out] VSS_ID *pidWriter );
	void GetWriterInfo(out Guid pidInstance, out Guid pidWriter);
}

/// <summary>
/// <para>
/// The <c>GetDifferencedFile</c> method returns information about a file set (a specified file or files) to participate in an
/// incremental or differential backup or restore as a differenced file—that is, backup and restores associated with it are to be
/// implemented as if entire files are copied to and from backup media (as opposed to using partial files).
/// </para>
/// <para>This method can be called by a requester or a writer during backup or restore operations.</para>
/// </summary>
/// <remarks>
/// <para><c>GetDifferencedFile</c> can be called by a requester or a writer during backup or restore operations.</para>
/// <para>
/// If the call to <c>GetDifferencedFile</c> is successful, the caller is responsible for freeing the string that is returned in the
/// pbstrPath and pbstrFilespec parameters by calling the SysFreeString function.
/// </para>
/// <para>
/// As writers can indicate differenced files with calls to IVssComponent::AddDifferencedFilesByLastModifyTime at any time prior to the
/// actual backing up of files, typically while handling a PostSnapshot event (CVssWriter::OnPostSnapshot), during backups
/// <c>GetDifferencedFile</c> is not usefully called prior to the return of IVssBackupComponents::DoSnapshotSet has successfully returned.
/// </para>
/// <para>
/// The time stamp returned by <c>GetDifferencedFile</c> applies to all files that match the returned path (pbstrPath) and file
/// specification (pbstrFilespec).
/// </para>
/// <para>
/// If the time-stamp value returned by <c>GetDifferencedFile</c> (pftLastModifyTime) is nonzero, a requester must respect this value
/// regardless of its own records and file system information and use it to determine whether the differenced file should be included in
/// a differential or incremental backup.
/// </para>
/// <para>
/// If the time stamp returned by <c>GetDifferencedFile</c> is zero, the requester can use file system information and its own records
/// to determine whether the differenced files should be included in a differential or incremental backup.
/// </para>
/// <para>Differenced files can be either of the following:</para>
/// <list type="bullet">
/// <item>
/// <term>
/// Members of the current component or, if the component defines a component set, members of its subcomponents that were added to the
/// component using IVssCreateWriterMetadata::AddFilesToFileGroup, IVssCreateWriterMetadata::AddDatabaseFiles, or IVssCreateWriterMetadata::AddDatabaseLogFiles
/// </term>
/// </item>
/// <item>
/// <term>New files added to the component by IVssComponent::AddDifferencedFilesByLastModifyTime</term>
/// </item>
/// </list>
/// <para>
/// When referring to a file set that is already part of the component, the combination of path, file specification, and recursion flag
/// (wszPath, wszFileSpec, and bRecursive, respectively) used when calling <c>GetDifferencedFile</c> should match that of a file set
/// already in the component, or one of its subcomponents (if the component defines a component set).
/// </para>
/// <para>
/// When <c>GetDifferencedFile</c> returns a differenced new file, that file's path (pbstrPath) should match or be beneath a path
/// already in the component, or one of its subcomponents (if the component defines a component set).
/// </para>
/// <para>In addition, the files returned by <c>GetDifferencedFile</c> should not already be managed by component or writer.</para>
/// <para>If any of these criteria are violated, they constitute an error on the part of the writer and should be reported.</para>
/// <para>
/// There is no method in the IVssComponent interface that allows for changing or adding an alternate location mapping for new files
/// returned by <c>GetDifferencedFilesByLastModifyTime</c>. If an alternate location mapping corresponds to the new file, then that
/// alternate location will be used.
/// </para>
/// </remarks>
public struct VssDifferencedFile
{
	/// <summary>
	/// <para>String containing the file specification of the files to be mapped.</para>
	/// <para>
	/// A file specification cannot contain directory specifications (for example, no backslashes) but can contain the ? and * wildcard characters.
	/// </para>
	/// </summary>
	public string FileSpec;

	/// <summary>
	/// <para>The writer specification of the time of last modification for the difference files.</para>
	/// <para>The last-modify time is always given in Greenwich Mean Time.</para>
	/// </summary>
	public DateTime LastModifyTime;

	/// <summary>
	/// <para>String containing the name of the directory or directory hierarchy containing the files to be mapped.</para>
	/// <para>The path can contain environment variables (for example, %SystemRoot%) but cannot contain wildcard characters.</para>
	/// <para>
	/// There is no requirement that the path end with a backslash (""). It is up to applications that retrieve this information to check.
	/// </para>
	/// </summary>
	public string Path;

	/// <summary>
	/// <para>
	/// A Boolean value specifying whether the path specified by the wszPath parameter identifies only a single directory or if it
	/// indicates a hierarchy of directories to be traversed recursively. This parameter should be set to <c>true</c> if the path is
	/// treated as a hierarchy of directories to be traversed recursively, or <c>false</c> if not.
	/// </para>
	/// <para>For information on traversing mounted folders, see Working with Mounted Folders and Reparse Points.</para>
	/// </summary>
	public bool Recursive;
}

/// <summary>
/// <para>
/// The <c>AddDirectedTarget</c> method allows a writer to indicate at restore time that when a file is to be restored, it (the source
/// file) should be remapped. The file can be restored to a new restore location and/or ranges of its data restored to different offsets
/// within the restore location.
/// </para>
/// <para>This method can be called by a writer only during a restore operation.</para>
/// <para>
/// This method cannot be called while handling a BackupComplete (CVssWriter::OnBackupComplete) or BackupShutdown
/// (CVssWriter::OnBackupShutdown) event.
/// </para>
/// </summary>
/// <remarks>
/// <para>Only a writer can call <c>AddDirectedTarget</c>, and only during restore operations.</para>
/// <para>
/// A requester will use the directed target information stored in the Backup Components Document only if the restore target is VSS_RT_DIRECTED.
/// </para>
/// <para>
/// The <c>AddDirectedTarget</c> method can be applied to any file managed in the current component or, if the component defines a
/// component set, in any of its nonselectable subcomponents.
/// </para>
/// <para>
/// Source and destination file specifications may point to the same file. This would allow remapping of a file into itself at restore time.
/// </para>
/// <para>
/// The syntax of the range listing (wszSourceRanges and wszDestinationRanges) is that of a comma-separated list of the form
/// <c>offset1:length1, offset2:length2</c>, where each offset and length is a 64-bit integer specifying a byte offset and length in
/// bytes, respectively. The offset and length can be expressed either as hexadecimal or decimal values.
/// </para>
/// <para>The number of entries and their sizes must match in the source and destination range arguments.</para>
/// <para>
/// <c>AddDirectedTarget</c> can use as its source file any file already managed by the component or one of its subcomponents if the
/// component defines a component set.
/// </para>
/// <para>
/// Partial files may be added as directed targets, if the partial file ranges to be backed up match the directed target source ranges
/// (see IVssComponent::AddPartialFile). This will allow you to remap partial files at restore time.
/// </para>
/// <para>
/// In this case, the requester retrieves the directed target information by calling the IVssComponent::GetDirectedTarget method and
/// uses that to implement the remapping of the backed-up data during restore.
/// </para>
/// </remarks>
public struct VssDirectedTarget
{
	/// <summary>
	/// String containing the name of the file to which source file data will be remapped at restore time. The name of the file
	/// (wszDestinationFilename) cannot contain wildcard characters (* or ?).
	/// </summary>
	public string DestinationFilename;

	/// <summary>String containing the path to which source file data will be remapped at restore time.</summary>
	public string DestinationPath;

	/// <summary>
	/// <para>
	/// A null-terminated wide character string containing a comma-separated list of file offsets and lengths indicating the destination
	/// file support range (locations to which the sections of the source file are to be restored).
	/// </para>
	/// <para>The number and length of the destination file support ranges must match the number and size of source file support ranges.</para>
	/// </summary>
	public string DestinationRangeList;

	/// <summary>
	/// String containing the name of the file (at backup time) that will be remapped at restore time (the source file). The name of the
	/// file (wszSourceFilename) cannot contain wildcard characters (* or ?) and must be consistent with the file specification of a
	/// file set containing the source path (wszSourcePath).
	/// </summary>
	public string SourceFilename;

	/// <summary>
	/// String containing the path to the directory at restore time containing the file to be restored (the source file). This path
	/// should match or be beneath the path of a file set already in the component (or one of its subcomponents if the component defines
	/// a component set).
	/// </summary>
	public string SourcePath;

	/// <summary>
	/// <para>
	/// A null-terminated wide character string containing a comma-separated list of file offsets and lengths indicating the source file
	/// support range (the sections of the file to actually be restored).
	/// </para>
	/// <para>The number and length of the source file support ranges must match the number and size of destination file support ranges.</para>
	/// </summary>
	public string SourceRangeList;
}

/// <summary>
/// <para>
/// The <c>AddPartialFile</c> method indicates that only portions of a given file are to be backed up and which portions those are.
/// </para>
/// <para>Only a writer can call this method, and only during a backup operation.</para>
/// </summary>
/// <remarks>
/// <para>Only a writer can call this method, and the writer cannot call this method during a restore operation.</para>
/// <para>
/// The syntax of the range listing (wszRanges) is that of a comma-separated list of the form <c>offset1:length1, offset2:length2</c>,
/// where each offset and length is a 64-bit integer specifying a byte offset and length in bytes, respectively. The offset and length
/// can be expressed either as hexadecimal or decimal values.
/// </para>
/// <para>
/// If wszRange refers to a file containing all the offsets and lengths (a ranges file), wszRange will contain only the full path to the file.
/// </para>
/// <para>A ranges file must be a binary file with the following format:</para>
/// <list type="number">
/// <item>
/// <term>A 64-bit integer indicating the number of distinct file ranges that need to be backed up</term>
/// </item>
/// <item>
/// <term>
/// Each range expressed as a pair of 64-bit integers: the offset into the file being backed up in bytes, and the length of data
/// starting from that offset to be backed up
/// </term>
/// </item>
/// </list>
/// <para>In either case, a range indicates a subsection of a given file that is to be backed up, independent of the rest of the file.</para>
/// <para>
/// Requesters can retrieve the partial file information using IVssComponent::GetPartialFile and use the offset and length information
/// returned by <c>GetPartialFile</c> to restore backed-up sections to the appropriate location within the copy of the file on disk at
/// restore time.
/// </para>
/// <para>
/// <c>AddPartialFile</c> can be applied to a file already managed by the component (or one of its subcomponents if the component
/// defines a component set), or it can add a new file to the component and indicate that it will participate in partial file operations.
/// </para>
/// <para>
/// When indicating that the file to participate is a new file, that file must exist on a shadow-copied volume and its path (wszPath)
/// should match or be beneath a path already in the component (or one of its subcomponents if the component defines a component set).
/// However, the file's file specification (wszFileSpec) should not match one in the components.
/// </para>
/// <para>Any newly added files will not support alternate location mappings.</para>
/// </remarks>
public struct VssPartialFile
{
	/// <summary>
	/// String containing the name of the file involved in partial file operations. The name of the file (wszFilename) cannot contain
	/// wildcard characters (* or ?) and must be consistent with the file specification of a file set containing the source path (wszPath).
	/// </summary>
	public string Filename;

	/// <summary>
	/// <para>
	/// String containing any additional metadata required by a writer to validate a partial file restore operation. The information in
	/// this metadata string will be opaque to requesters.
	/// </para>
	/// <para>If additional metadata is not required, this value can be <c>NULL</c>.</para>
	/// </summary>
	public string? Metadata;

	/// <summary>
	/// <para>String containing the path of the file involved in partial file operations.</para>
	/// <para>The path can contain environment variables (for example, %SystemRoot%) but cannot contain wildcard characters.</para>
	/// <para>
	/// There is no requirement that the path end with a backslash (""). It is up to applications that retrieve this information to check.
	/// </para>
	/// <para>
	/// This path should match or be beneath the path of a file set already in the component (or one of its subcomponents if the
	/// component defines a component set).
	/// </para>
	/// </summary>
	public string Path;

	/// <summary>
	/// <para>
	/// String containing either a listing of file offsets and lengths that make up the partial file support range (the sections of the
	/// file to actually be backed up), or the name of a file containing such a list.
	/// </para>
	/// <para>Specifying the partial file support range is required, and this value cannot be <c>NULL</c>.</para>
	/// </summary>
	public string? Ranges;
}

/// <summary>
/// <para>The <c>GetRestoreSubcomponent</c> method returns the specified subcomponent associated with a given component.</para>
/// <para>Either a writer or a requester can call this method.</para>
/// </summary>
/// <remarks>The caller should free the memory held by the pbstrLogicalPath and pbstrComponentName parameters by calling SysFreeString.</remarks>
public struct VssRestoreSubcomponent
{
	/// <summary>Pointer to a string containing the name of the subcomponent. The string cannot be empty.</summary>
	public string ComponentName;

	/// <summary>
	/// Pointer to a string containing the logical path of the subcomponent. The logical path cannot be empty when working with subcomponents.
	/// </summary>
	public string LogicalPath;

	/// <summary>Reserved for future use.</summary>
	public bool Repair;
}