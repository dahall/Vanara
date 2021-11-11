using System;
using System.Runtime.InteropServices;
using FILETIME = System.Runtime.InteropServices.ComTypes.FILETIME;

namespace Vanara.PInvoke
{
	public static partial class VssApi
	{
		/// <summary>
		/// <para>
		/// The <c>VSS_ALTERNATE_WRITER_STATE</c> enumeration is used to indicate whether a given writer has an associated alternate writer.
		/// The existence of an alternate writer is set during writer initialization by CVssWriter::Initialize.
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
		/// The <c>VSS_COMPONENT_FLAGS</c> enumeration is used by writers to indicate support for auto-recovery. These values are used in
		/// the <c>dwComponentFlags</c> member of the VSS_COMPONENTINFO structure and the dwComponentFlags parameter of the
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
		/// The <c>VSS_COMPONENT_TYPE</c> enumeration is used by both the requester and the writer to specify the type of component being
		/// used with a shadow copy backup operation.
		/// </summary>
		/// <remarks>
		/// <para>A writer sets a component's type when it adds the component to its Writer Metadata Document using IVssCreateWriterMetadata::AddComponent.</para>
		/// <para>
		/// Writers and requesters can find the type information of components selected for inclusion in a Backup Components Document
		/// through calls to IVssComponent::GetComponentType to return a component type directly.
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
		/// Requesters must set a restore status (using IVssBackupComponents::SetFileRestoreStatus) for every component (and its component
		/// set, if it defines one) explicitly added for restore to the Backup Components Document (using either
		/// IVssBackupComponents::SetSelectedForRestore or IVssBackupComponents::AddRestoreSubcomponent).
		/// </para>
		/// <para>
		/// Writers and requesters can query the status of the restoration of a component or a component set defined by a selectable
		/// component with calls to IVssComponent::GetFileRestoreStatus. If this method is called for a component that was not selected, the
		/// value returned is undefined.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/vswriter/ne-vswriter-vss_file_restore_status typedef enum
		// VSS_FILE_RESTORE_STATUS { VSS_RS_UNDEFINED, VSS_RS_NONE, VSS_RS_ALL, VSS_RS_FAILED } ;
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
		/// The <c>VSS_RESTORE_TARGET</c> enumeration is used by a writer at restore time to indicate how all the files included in a
		/// selected component, and all the files in any component set it defines, are to be restored. (See Working with Selectability and
		/// Logical Paths for information on selecting components.)
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
		/// At restore time, a <c>VSS_RESTORE_TARGET</c> value other than <c>VSS_RT_ORIGINAL</c> overrides the value of the originally
		/// specified restore method specified by VSS_RESTOREMETHOD_ENUM and set by IVssCreateWriterMetadata::SetRestoreMethod.
		/// </para>
		/// <para>
		/// Only writers (using IVssComponent::SetRestoreTarget) can set a restore target ( <c>VSS_RESTORE_TARGET</c>) and change how files
		/// are restored overriding the restore method).
		/// </para>
		/// <para>Requesters and writers can access the current restore target through IVssComponent::GetRestoreTarget.</para>
		/// <para>
		/// A restore target of <c>VSS_RT_ORIGINAL</c> does not mean that files should be restored to their original location, but that the
		/// originally specified restore method (VSS_RESTOREMETHOD_ENUM) must be respected. For instance, if a writer set a restore method
		/// of <c>VSS_RME_RESTORE_TO_ALTERNATE_LOCATION</c> for a selected component and the restore target is <c>VSS_RT_ORIGINAL</c>, files
		/// should be restored to the alternate location defined by the writer.
		/// </para>
		/// <para>
		/// (In this example, if a writer has failed to define alternate location mappings, then it is a writer error, and the requester
		/// should report it.)
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
		/// The <c>VSS_RESTOREMETHOD_ENUM</c> enumeration is used by a writer at backup time to specify through its Writer Metadata Document
		/// the default file restore method to be used with all the files in all the components it manages.
		/// </para>
		/// <para>
		/// The restore method is writer-wide and is also referred to as the original restore target and indicated by a VSS_RESTORE_TARGET
		/// value of <c>VSS_RT_ORIGINAL</c>.
		/// </para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// A writer sets the restore method in the Writer Metadata Document by calling IVssCreateWriterMetadata::SetRestoreMethod during
		/// backup to specify its desired restore method in its metadata.
		/// </para>
		/// <para>
		/// A requester retrieves a writer's requested restore method by calling IVssExamineWriterMetadata::GetRestoreMethod and acts accordingly.
		/// </para>
		/// <para>The restore method applies to all files in all components of a given writer.</para>
		/// <para>
		/// The restore method may be overridden on a component-by-component basis at restore time if a writer sets a VSS_RESTORE_TARGET
		/// value other than <c>VSS_RT_ORIGINAL</c> with IVssComponent::SetRestoreTarget.
		/// </para>
		/// <para>
		/// A restore method of <c>VSS_RME_RESTORE_TO_ALTERNATE_LOCATION</c> without an alternate location mapping defined constitutes a
		/// writer error, and the requester should report it as such.
		/// </para>
		/// <para>
		/// When a restore method requires a check on the status of files currently on disk ( <c>VSS_RME_RESTORE_IF_NOT_THERE</c>,
		/// <c>VSS_RME_RESTORE_IF_CAN_REPLACE</c>, or <c>VSS_RME_RESTORE_AT_REBOOT_IF_CANNOT_REPLACE</c>), ideally, you should use file I/O
		/// operations to verify that an entire component can be restored before actually proceeding with the restore.
		/// </para>
		/// <para>
		/// The safest way to do this would be to open exclusively (no-sharing) all the target files with CreateFile prior to the restore.
		/// </para>
		/// <para>In the case of <c>VSS_RME_RESTORE_IF_NOT_THERE</c>, a creation disposition flag of <c>CREATE_NEW</c> should also be set.</para>
		/// <para>
		/// If the open operations succeed, the restore can proceed and should use the handles returned by CreateFile to actually write
		/// restored data to disk.
		/// </para>
		/// <para>
		/// If not, an error can be returned—depending on the method—or alternate location mapping checked and (if it is available) used, or
		/// the components files staged for restore at the next reboot.
		/// </para>
		/// <para>This may be a problem for very large components (some of which may have thousands of files), due to system overhead.</para>
		/// <para>In this case, an available though less reliable option is to do the following:</para>
		/// <list type="number">
		/// <item>
		/// <term>Copy all files currently on disk and to be restored to a temporary cache.</term>
		/// </item>
		/// <item>
		/// <term>
		/// Attempt to replace the files currently on disk with the backed-up files (which could be either on disk in a second temporary
		/// area, or on a backup medium).
		/// </term>
		/// </item>
		/// <item>
		/// <term>
		/// If any files fail to restore, then terminate the restore operation and copy the original files back from their temporary
		/// location and proceed with alternate location mapping or restore on reboot operations.
		/// </term>
		/// </item>
		/// </list>
		/// <para>For more information on backup and restore file locations under VSS, see Non-Default Backup And Restore Locations.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/vswriter/ne-vswriter-vss_restoremethod_enum typedef enum
		// VSS_RESTOREMETHOD_ENUM { VSS_RME_UNDEFINED, VSS_RME_RESTORE_IF_NOT_THERE, VSS_RME_RESTORE_IF_CAN_REPLACE,
		// VSS_RME_STOP_RESTORE_START, VSS_RME_RESTORE_TO_ALTERNATE_LOCATION, VSS_RME_RESTORE_AT_REBOOT,
		// VSS_RME_RESTORE_AT_REBOOT_IF_CANNOT_REPLACE, VSS_RME_CUSTOM, VSS_RME_RESTORE_STOP_START } ;
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
		/// The source type of the data that a writer manages is specified when it initializes its cooperation with the shadow copy
		/// mechanism through a call to CVssWriter::Initialize.
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
		/// The <c>VSS_SUBSCRIBE_MASK</c> enumeration is used by a writer when subscribing to the VSS service. It indicates the events that
		/// the writer is willing to receive.
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
		// https://docs.microsoft.com/en-us/windows/win32/api/vswriter/ne-vswriter-vss_writerrestore_enum typedef enum
		// VSS_WRITERRESTORE_ENUM { VSS_WRE_UNDEFINED, VSS_WRE_NEVER, VSS_WRE_IF_REPLACE_FAILS, VSS_WRE_ALWAYS } ;
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

		/// <summary>
		/// <para>
		/// The <c>IVssComponent</c> interface is a C++ (not COM) interface containing methods for examining and modifying information about
		/// components contained in a requester's Backup Components Document.
		/// </para>
		/// <para>
		/// <c>IVssComponent</c> objects can be obtained only for those components that have been explicitly added to the Backup Components
		/// Document during a backup operation by the IVssBackupComponents::AddComponent method.
		/// </para>
		/// <para>
		/// Information about components explicitly added during a restore operation using IVssBackupComponents::AddRestoreSubcomponent are
		/// not available through the <c>IVssComponent</c> interface.
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
		/// conjunction with the appropriate Writer Metadata Documents based on a writer's component hierarchy expressed in the logical
		/// paths (see Working with Selectability and Logical Paths).
		/// </para>
		/// <para>
		/// The interface can be used by either a writer or a requester, although certain methods are supported only for writers. In this
		/// way, a writer can request changes in a backup or restore operation, such as adding a new target, or learn of requester actions,
		/// such as the use of an alternate location.
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
		[ComVisible(true), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		private interface IVssComponent
		{
			[PreserveSig]
			HRESULT AddDifferencedFilesByLastModifyLSN([MarshalAs(UnmanagedType.LPWStr)] string wszPath,
							[MarshalAs(UnmanagedType.LPWStr)] string wszFilespec,
							[MarshalAs(UnmanagedType.Bool)] bool bRecursive,
							[MarshalAs(UnmanagedType.BStr)] string bstrLsnString);

			// add differenced files by last modify time
			[PreserveSig]
			HRESULT AddDifferencedFilesByLastModifyTime([MarshalAs(UnmanagedType.LPWStr)] string wszPath, [MarshalAs(UnmanagedType.LPWStr)] string wszFilespec,
				[MarshalAs(UnmanagedType.Bool)] bool bRecursive, FILETIME ftLastModifyTime);

			// add a directed target specification
			[PreserveSig]
			HRESULT AddDirectedTarget([MarshalAs(UnmanagedType.LPWStr)] string wszSourcePath,
		[MarshalAs(UnmanagedType.LPWStr)] string wszSourceFilename,
		[MarshalAs(UnmanagedType.LPWStr)] string wszSourceRangeList,
		[MarshalAs(UnmanagedType.LPWStr)] string wszDestinationPath,
		[MarshalAs(UnmanagedType.LPWStr)] string wszDestinationFilename,
		[MarshalAs(UnmanagedType.LPWStr)] string wszDestinationRangeList);

			// indicate that only ranges in the file are to be backed up
			[PreserveSig]
			HRESULT AddPartialFile([MarshalAs(UnmanagedType.LPWStr)] string wszPath,
		[MarshalAs(UnmanagedType.LPWStr)] string wszFilename,
		[MarshalAs(UnmanagedType.LPWStr)] string wszRanges,
		[MarshalAs(UnmanagedType.LPWStr)] string wszMetadata);

			[PreserveSig]
			HRESULT GetAdditionalRestores(out bool pbAdditionalRestores);

			// get a paraticular alternative location mapping
			[PreserveSig]
			HRESULT GetAlternateLocationMapping([In] uint iMapping, out IVssWMFiledesc ppFiledesc);

			// get altermative location mapping count
			[PreserveSig]
			HRESULT GetAlternateLocationMappingCount(out uint pcMappings);

			// get the backup metadata for a component
			[PreserveSig]
			HRESULT GetBackupMetadata([MarshalAs(UnmanagedType.BStr)] out string pbstrData);

			// obtain backup options for the writer
			[PreserveSig]
			HRESULT GetBackupOptions([MarshalAs(UnmanagedType.BStr)] out string pbstrBackupOptions);

			// obtain the stamp of the backup
			[PreserveSig]
			HRESULT GetBackupStamp([MarshalAs(UnmanagedType.BStr)] out string pbstrBackupStamp);

			// determine whether the component was successfully backed up.
			[PreserveSig]
			HRESULT GetBackupSucceeded(out bool pbSucceeded);

			[PreserveSig]
			HRESULT GetComponentName([MarshalAs(UnmanagedType.BStr)] out string pbstrName);

			/// <summary>
			/// <para>The <c>GetComponentType</c> method returns the type of this component in terms of the VSS_COMPONENT_TYPE enumeration.</para>
			/// <para>Either a writer or a requester can call this method.</para>
			/// </summary>
			/// <param name="pct">
			/// The address of a caller-allocated variable that receives a VSS_COMPONENT_TYPE enumeration value that specifies the type of
			/// the component.
			/// </param>
			/// <returns>
			/// <para>The following are the valid return codes for this method.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>S_OK</term>
			/// <term>Successfully returned the attribute value.</term>
			/// </item>
			/// <item>
			/// <term>E_INVALIDARG</term>
			/// <term>One of the parameter values is not valid.</term>
			/// </item>
			/// <item>
			/// <term>E_OUTOFMEMORY</term>
			/// <term>The caller is out of memory or other system resources.</term>
			/// </item>
			/// <item>
			/// <term>VSS_E_INVALID_XML_DOCUMENT</term>
			/// <term>
			/// The XML document is not valid. Check the event log for details. For more information, see Event and Error Handling Under VSS.
			/// </term>
			/// </item>
			/// </list>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/vswriter/nf-vswriter-ivsscomponent-getcomponenttype HRESULT
			// GetComponentType( [out] VSS_COMPONENT_TYPE *pct );
			[PreserveSig]
			HRESULT GetComponentType(out VSS_COMPONENT_TYPE pct);

			[PreserveSig]
			HRESULT GetDifferencedFile(uint iDifferencedFile,
							[MarshalAs(UnmanagedType.BStr)] out string pbstrPath,
							[MarshalAs(UnmanagedType.BStr)] out string pbstrFilespec,
							[MarshalAs(UnmanagedType.Bool)] out bool pbRecursive,
							[MarshalAs(UnmanagedType.BStr)] out string pbstrLsnString,
							out FILETIME pftLastModifyTime);

			[PreserveSig]
			HRESULT GetDifferencedFilesCount(out uint pcDifferencedFiles);

			// obtain a particular directed target specification
			[PreserveSig]
			HRESULT GetDirectedTarget(uint iDirectedTarget,
		[MarshalAs(UnmanagedType.BStr)] out string pbstrSourcePath,
		[MarshalAs(UnmanagedType.BStr)] out string pbstrSourceFileName,
		[MarshalAs(UnmanagedType.BStr)] out string pbstrSourceRangeList,
		[MarshalAs(UnmanagedType.BStr)] out string pbstrDestinationPath,
		[MarshalAs(UnmanagedType.BStr)] out string pbstrDestinationFilename,
		[MarshalAs(UnmanagedType.BStr)] out string pbstrDestinationRangeList);

			// get count of directed target specifications
			[PreserveSig]
			HRESULT GetDirectedTargetCount(out uint pcDirectedTarget);

			// obtain whether files were successfully restored
			[PreserveSig]
			HRESULT GetFileRestoreStatus(out VSS_FILE_RESTORE_STATUS pStatus);

			/// <summary>
			/// <para>The <c>GetLogicalPath</c> method returns the logical path of this component.</para>
			/// <para>Either a writer or a requester can call this method.</para>
			/// </summary>
			/// <param name="pbstrPath">Pointer to a string containing the logical path of the component.</param>
			/// <returns>
			/// <para>The following are the valid return codes for this method.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>S_OK</term>
			/// <term>Successfully returned the attribute value.</term>
			/// </item>
			/// <item>
			/// <term>S_FALSE</term>
			/// <term>This component has no logical path.</term>
			/// </item>
			/// <item>
			/// <term>E_INVALIDARG</term>
			/// <term>One of the parameter values is not valid.</term>
			/// </item>
			/// <item>
			/// <term>E_OUTOFMEMORY</term>
			/// <term>The caller is out of memory or other system resources.</term>
			/// </item>
			/// <item>
			/// <term>VSS_E_INVALID_XML_DOCUMENT</term>
			/// <term>
			/// The XML document is not valid. Check the event log for details. For more information, see Event and Error Handling Under VSS.
			/// </term>
			/// </item>
			/// </list>
			/// </returns>
			/// <remarks>
			/// <para>The caller should free the memory held by the pbstrPath parameter by calling SysFreeString.</para>
			/// <para>Logical paths are not required of components. A component without a logical path will return S_FALSE.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/vswriter/nf-vswriter-ivsscomponent-getlogicalpath HRESULT GetLogicalPath(
			// [out] BSTR *pbstrPath );
			[PreserveSig]
			HRESULT GetLogicalPath([MarshalAs(UnmanagedType.BStr)] out string pbstrPath);

			[PreserveSig]
			HRESULT GetNewTarget(uint iNewTarget, out IVssWMFiledesc ppFiledesc);

			// get count of new target specifications
			[PreserveSig]
			HRESULT GetNewTargetCount(out uint pcNewTarget);

			// get a partial file declaration
			[PreserveSig]
			HRESULT GetPartialFile(uint iPartialFile,
		[MarshalAs(UnmanagedType.BStr)] out string pbstrPath,
		[MarshalAs(UnmanagedType.BStr)] out string pbstrFilename,
		[MarshalAs(UnmanagedType.BStr)] out string pbstrRange,
		[MarshalAs(UnmanagedType.BStr)] out string pbstrMetadata);

			// get count of partial file declarations
			[PreserveSig]
			HRESULT GetPartialFileCount(out uint pcPartialFiles);

			// obtain the failure message set during the post restore event
			[PreserveSig]
			HRESULT GetPostRestoreFailureMsg([MarshalAs(UnmanagedType.BStr)] out string pbstrPostRestoreFailureMsg);

			// obtain failure message during pre restore event
			[PreserveSig]
			HRESULT GetPreRestoreFailureMsg([MarshalAs(UnmanagedType.BStr)] out string pbstrPreRestoreFailureMsg);

			// obtain the backup stamp that the differential or incremental backup is baed on
			[PreserveSig]
			HRESULT GetPreviousBackupStamp([MarshalAs(UnmanagedType.BStr)] out string pbstrBackupStamp);

			// obtain restore metadata associated with the component
			[PreserveSig]
			HRESULT GetRestoreMetadata([MarshalAs(UnmanagedType.BStr)] out string pbstrRestoreMetadata);

			// obtain the restore options
			[PreserveSig]
			HRESULT GetRestoreOptions([MarshalAs(UnmanagedType.BStr)] out string pbstrRestoreOptions);

			// obtain a particular subcomponent to be restored
			[PreserveSig]
			HRESULT GetRestoreSubcomponent(uint iComponent, [MarshalAs(UnmanagedType.BStr)] out string pbstrLogicalPath,
				[MarshalAs(UnmanagedType.BStr)] out string pbstrComponentName, out bool pbRepair);

			// obtain count of subcomponents to be restored
			[PreserveSig]
			HRESULT GetRestoreSubcomponentCount(out uint pcRestoreSubcomponent);

			// obtain the restore target
			[PreserveSig]
			HRESULT GetRestoreTarget(out VSS_RESTORE_TARGET pTarget);

			// determine if the component is selected to be restored
			[PreserveSig]
			HRESULT IsSelectedForRestore(out bool pbSelectedForRestore);

			// set the backup metadata for a component
			[PreserveSig]
			HRESULT SetBackupMetadata([MarshalAs(UnmanagedType.LPWStr)] string wszData);

			// set the backup stamp of the backup
			[PreserveSig]
			HRESULT SetBackupStamp([MarshalAs(UnmanagedType.LPWStr)] string wszBackupStamp);

			// set the failure message during the post restore event
			[PreserveSig]
			HRESULT SetPostRestoreFailureMsg([MarshalAs(UnmanagedType.LPWStr)] string wszPostRestoreFailureMsg);

			// set failure message during pre restore event
			[PreserveSig]
			HRESULT SetPreRestoreFailureMsg([MarshalAs(UnmanagedType.LPWStr)] string wszPreRestoreFailureMsg);

			// set restore metadata associated with the component
			[PreserveSig]
			HRESULT SetRestoreMetadata([MarshalAs(UnmanagedType.LPWStr)] string wszRestoreMetadata);

			// set the restore target
			[PreserveSig]
			HRESULT SetRestoreTarget(VSS_RESTORE_TARGET target);
		}

		/// <summary>
		/// <para>
		/// Defines additional methods for examining and modifying information about components contained in a requester's Backup Components Document.
		/// </para>
		/// <para>The <c>IVssComponentEx</c> interface is a C++ (not COM) interface.</para>
		/// <para>
		/// To obtain an instance of the <c>IVssComponentEx</c> interface, call the QueryInterface method of the IVssComponent interface,
		/// and pass the <c>IID_IVssComponentEx</c> constant as the interface identifier (IID) parameter.
		/// </para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/vswriter/nl-vswriter-ivsscomponentex
		[PInvokeData("vswriter.h", MSDNShortId = "NL:vswriter.IVssComponentEx")]
		private interface IVssComponentEx
		{ }

		/// <summary>
		/// <para>Defines additional methods for reporting and retrieving component-level writer errors.</para>
		/// <para>The <c>IVssComponentEx2</c> interface is a C++ (not COM) interface.</para>
		/// <para>
		/// To obtain an instance of the <c>IVssComponentEx2</c> interface, call the QueryInterface method of the IVssComponent interface
		/// and pass the <c>IID_IVssComponentEx2</c> constant as the interface identifier (IID) parameter.
		/// </para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/vswriter/nl-vswriter-ivsscomponentex2
		[PInvokeData("vswriter.h", MSDNShortId = "NL:vswriter.IVssComponentEx2")]
		private interface IVssComponentEx2
		{ }

		/// <summary>
		/// <para>
		/// The <c>IVssCreateExpressWriterMetadata</c> interface is a COM interface containing methods to construct the Writer Metadata
		/// Document for an express writer.
		/// </para>
		/// <para>
		/// After it is constructed, the Writer Metadata Document is a read-only object that requesters query for information about a writer
		/// and its components.
		/// </para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/vswriter/nl-vswriter-ivsscreateexpresswritermetadata
		[PInvokeData("vswriter.h", MSDNShortId = "NL:vswriter.IVssCreateExpressWriterMetadata")]
		private interface IVssCreateExpressWriterMetadata
		{ }

		/// <summary>
		/// <para>
		/// The <c>IVssCreateWriterMetadata</c> interface is a C++ (not COM) interface containing methods to construct the Writer Metadata
		/// Document in response to an Identify event. It is used only in the CVssWriter::OnIdentify method.
		/// </para>
		/// <para>The addition and specification of components by a writer is managed through this interface.</para>
		/// <para>
		/// After it is constructed, the Writer Metadata Document is a read-only object that requesters query for information about a writer
		/// and its components.
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
		private interface IVssCreateWriterMetadata
		{ }

		/// <summary>
		/// <para>
		/// The <c>IVssCreateWriterMetadataEx</c> interface is a C++ (not COM) interface that defines a method to report any file sets that
		/// will be explicitly excluded when a shadow copy is created. This interface is used only in the CVssWriterEx::OnIdentifyEx method.
		/// </para>
		/// <para>The <c>IVssCreateWriterMetadataEx</c> interface inherits from the IVssCreateWriterMetadata interface and IUnknown.</para>
		/// <para><c>IVssCreateWriterMetadataEx</c> defines the following method.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Method</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>AddExcludeFilesFromSnapshot</term>
		/// <term>Reports any file sets that will be explicitly excluded by the writer when a shadow copy is created.</term>
		/// </item>
		/// </list>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/vswriter/nl-vswriter-ivsscreatewritermetadataex
		[PInvokeData("vswriter.h", MSDNShortId = "NL:vswriter.IVssCreateWriterMetadataEx")]
		private interface IVssCreateWriterMetadataEx
		{ }

		/// <summary>Defines methods to manage metadata for a VSS express writer.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/vswriter/nl-vswriter-ivssexpresswriter
		[PInvokeData("vswriter.h", MSDNShortId = "NL:vswriter.IVssExpressWriter")]
		private interface IVssExpressWriter
		{ }

		/// <summary>
		/// <para>
		/// The <c>IVssWMDependency</c> is a C++ (not COM) interface returned by the IVssWMComponent interface and used by applications when
		/// backing up or restoring a component that has an explicit writer-component dependency on a component managed by another writer.
		/// (Dependencies must be between writers, not within writers.)
		/// </para>
		/// <para>
		/// <c>IVssWMDependency</c> is used to determine the writer ID, logical path, and component name of components that must be restored
		/// or backed up along with the target component.
		/// </para>
		/// <para>
		/// Dependencies are created by writers while handling Identify events (CVssWriter::OnIdentify) using the
		/// IVssCreateWriterMetadata::AddComponentDependency method.
		/// </para>
		/// <para>
		/// Calling applications are responsible for calling IUnknown::Release to release resources held by a returned
		/// <c>IVssWMDependency</c> object when it is no longer needed.
		/// </para>
		/// <para>The IVssWMComponent::GetDependency method returns an <c>IVssWMDependency</c> interface.</para>
		/// <para>
		/// Note that a dependency does not indicate an order of preference between the component with the documented dependencies and the
		/// components it depends on. A dependency merely indicates that the component and the components it depends on must always be
		/// backed up or restored together.
		/// </para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/vswriter/nl-vswriter-ivsswmdependency
		[PInvokeData("vswriter.h", MSDNShortId = "NL:vswriter.IVssWMDependency")]
		private interface IVssWMDependency
		{ }

		/// <summary>
		/// <para>
		/// The <c>IVssWMFiledesc</c> interface is a C++ (not COM) interface returned to a calling application by a number of query methods.
		/// It provides detailed information about a file or set of files (a file set).
		/// </para>
		/// <para>
		/// The calling application is responsible for calling IUnknown::Release to release the resources held by the returned
		/// <c>IVssWMFiledesc</c> interface when it is no longer needed.
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
		[ComVisible(true), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		private interface IVssWMFiledesc
		{
			/// <summary>The <c>GetAlternateLocation</c> method obtains an alternate location for a file set.</summary>
			/// <param name="pbstrAlternateLocation">
			/// The address of a caller-allocated variable that receives a string specifying the alternate backup location. The path of this
			/// location can be a local path or the UNC path of a remote file share. If there is no alternate location, the pointer is <c>NULL</c>.
			/// </param>
			/// <returns>
			/// <para>The following are the valid return codes for this method.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>S_OK</term>
			/// <term>Successfully returned the alternate location information.</term>
			/// </item>
			/// <item>
			/// <term>S_FALSE</term>
			/// <term>The requested information could not be found.</term>
			/// </item>
			/// <item>
			/// <term>E_INVALIDARG</term>
			/// <term>One of the parameter values is not valid.</term>
			/// </item>
			/// <item>
			/// <term>E_OUTOFMEMORY</term>
			/// <term>The caller is out of memory or other system resources.</term>
			/// </item>
			/// <item>
			/// <term>VSS_E_INVALID_XML_DOCUMENT</term>
			/// <term>
			/// The XML document is not valid. Check the event log for details. For more information, see Event and Error Handling Under VSS.
			/// </term>
			/// </item>
			/// <item>
			/// <term>VSS_E_UNEXPECTED</term>
			/// <term>
			/// Unexpected error. The error code is logged in the error log file. For more information, see Event and Error Handling Under
			/// VSS. Windows Server 2008, Windows Vista, Windows Server 2003 and Windows XP: This value is not supported until Windows
			/// Server 2008 R2 and Windows 7. E_UNEXPECTED is used instead.
			/// </term>
			/// </item>
			/// </list>
			/// </returns>
			/// <remarks>
			/// <para>
			/// <c>Windows 7, Windows Server 2008 R2, Windows Vista, Windows Server 2008, Windows XP and Windows Server 2003:</c> Remote
			/// file shares are not supported until Windows 8 and Windows Server 2012.
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
			[PreserveSig]
			HRESULT GetAlternateLocation([MarshalAs(UnmanagedType.BStr)] out string pbstrAlternateLocation);

			/// <summary>
			/// The <c>GetBackupTypeMask</c> method returns the file backup specification for the files specified by the current file
			/// descriptor as a bit mask (or bitwise OR) of VSS_FILE_SPEC_BACKUP_TYPE values. This information indicates if the files are to
			/// be evaluated by their writer for participation in various specific types of backup operations (or if they will participate
			/// in an incremental or differential backups).
			/// </summary>
			/// <param name="pdwTypeMask">
			/// Pointer to a <c>DWORD</c> containing a bit mask (or bitwise OR) of VSS_FILE_SPEC_BACKUP_TYPE values indicating the file
			/// backup specification for the file or file set described by the current IVssWMFiledesc interface.
			/// </param>
			/// <returns>
			/// <para>The following are the valid return codes for this method.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>S_OK</term>
			/// <term>Successfully returned the filespec information.</term>
			/// </item>
			/// <item>
			/// <term>E_INVALIDARG</term>
			/// <term>The pdwTypeMask variable points to a NULL region of memory.</term>
			/// </item>
			/// <item>
			/// <term>E_OUTOFMEMORY</term>
			/// <term>The caller is out of memory or other system resources.</term>
			/// </item>
			/// <item>
			/// <term>VSS_E_INVALID_XML_DOCUMENT</term>
			/// <term>
			/// The XML document is not valid. Check the event log for details. For more information, see Event and Error Handling Under VSS.
			/// </term>
			/// </item>
			/// <item>
			/// <term>VSS_E_UNEXPECTED</term>
			/// <term>
			/// Unexpected error. The error code is logged in the error log file. For more information, see Event and Error Handling Under
			/// VSS. Windows Server 2008, Windows Vista, Windows Server 2003 and Windows XP: This value is not supported until Windows
			/// Server 2008 R2 and Windows 7. E_UNEXPECTED is used instead.
			/// </term>
			/// </item>
			/// </list>
			/// </returns>
			/// <remarks>
			/// A file backup specification is specified by a writer when it adds a file specification to a component using the
			/// IVssCreateWriterMetadata::AddFilesToFileGroup, IVssCreateWriterMetadata::AddDatabaseFiles, or
			/// IVssCreateWriterMetadata::AddDatabaseLogFiles method.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/vswriter/nf-vswriter-ivsswmfiledesc-getbackuptypemask HRESULT
			// GetBackupTypeMask( DWORD *pdwTypeMask );
			[PreserveSig]
			HRESULT GetBackupTypeMask(out uint pdwTypeMask);

			/// <summary>
			/// <para>
			/// The <c>GetFilespec</c> method returns the file specification used to obtain the list of files that the current
			/// IVssWMFiledesc object is a member of.
			/// </para>
			/// <para>A querying method used a path and this file specification to return the current IVssWMFiledesc object.</para>
			/// </summary>
			/// <param name="pbstrFilespec">
			/// <para>The address of a caller-allocated variable that receives a string specifying the returned file specification.</para>
			/// <para>
			/// A file specification cannot contain directory specifications (for example, no backslashes) but can contain the ? and *
			/// wildcard characters.
			/// </para>
			/// </param>
			/// <returns>
			/// <para>The following are the valid return codes for this method.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>S_OK</term>
			/// <term>Successfully returned the filespec information.</term>
			/// </item>
			/// <item>
			/// <term>E_INVALIDARG</term>
			/// <term>One of the parameter values is not valid.</term>
			/// </item>
			/// <item>
			/// <term>E_OUTOFMEMORY</term>
			/// <term>The caller is out of memory or other system resources.</term>
			/// </item>
			/// <item>
			/// <term>VSS_E_INVALID_XML_DOCUMENT</term>
			/// <term>
			/// The XML document is not valid. Check the event log for details. For more information, see Event and Error Handling Under VSS.
			/// </term>
			/// </item>
			/// <item>
			/// <term>VSS_E_UNEXPECTED</term>
			/// <term>
			/// Unexpected error. The error code is logged in the error log file. For more information, see Event and Error Handling Under
			/// VSS. Windows Server 2008, Windows Vista, Windows Server 2003 and Windows XP: This value is not supported until Windows
			/// Server 2008 R2 and Windows 7. E_UNEXPECTED is used instead.
			/// </term>
			/// </item>
			/// </list>
			/// </returns>
			/// <remarks>The caller must call SysFreeString to free the memory held by the pbstrFilespec parameter.</remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/vswriter/nf-vswriter-ivsswmfiledesc-getfilespec HRESULT GetFilespec( [out]
			// BSTR *pbstrFilespec );
			[PreserveSig]
			HRESULT GetFilespec([MarshalAs(UnmanagedType.BStr)] out string pbstrFilespec);

			/// <summary>
			/// <para>
			/// The <c>GetPath</c> method obtains the fully qualified directory path or the UNC path of the remote file share to obtain the
			/// list of files described in the current IVssWMFiledesc object.
			/// </para>
			/// <para>A querying method used this path and a file specification to return the current IVssWMFiledesc object.</para>
			/// </summary>
			/// <param name="pbstrPath">
			/// <para>
			/// The address of a caller-allocated variable that receives a <c>NULL</c>-terminated wide character string specifying the fully
			/// qualified directory path or the UNC path of the remote file share directory.
			/// </para>
			/// <para>The path can be a long or short file name and can use the prefix "\?". For more information, see Naming a File.</para>
			/// <para>Users of this method need to check to determine whether this path ends with a backslash ("").</para>
			/// </param>
			/// <returns>
			/// <para>The following are the valid return codes for this method.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>S_OK</term>
			/// <term>Successfully returned the path information.</term>
			/// </item>
			/// <item>
			/// <term>E_INVALIDARG</term>
			/// <term>One of the parameter values is not valid.</term>
			/// </item>
			/// <item>
			/// <term>E_OUTOFMEMORY</term>
			/// <term>The caller is out of memory or other system resources.</term>
			/// </item>
			/// <item>
			/// <term>VSS_E_INVALID_XML_DOCUMENT</term>
			/// <term>
			/// The XML document is not valid. Check the event log for details. For more information, see Event and Error Handling Under VSS.
			/// </term>
			/// </item>
			/// <item>
			/// <term>VSS_E_UNEXPECTED</term>
			/// <term>
			/// Unexpected error. The error code is logged in the error log file. For more information, see Event and Error Handling Under
			/// VSS. Windows Server 2008, Windows Vista, Windows Server 2003 and Windows XP: This value is not supported until Windows
			/// Server 2008 R2 and Windows 7. E_UNEXPECTED is used instead.
			/// </term>
			/// </item>
			/// </list>
			/// </returns>
			/// <remarks>
			/// <para>
			/// <c>Windows 7, Windows Server 2008 R2, Windows Vista, Windows Server 2008, Windows XP and Windows Server 2003:</c> Remote
			/// file shares are not supported until Windows 8 and Windows Server 2012.
			/// </para>
			/// <para>The caller must call SysFreeString to free the memory held by the pbstrPath parameter.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/vswriter/nf-vswriter-ivsswmfiledesc-getpath HRESULT GetPath( [out] BSTR
			// *pbstrPath );
			[PreserveSig]
			HRESULT GetPath([MarshalAs(UnmanagedType.BStr)] out string pbstrPath);

			/// <summary>
			/// The <c>GetRecursive</c> method indicates whether the list of files described in a IVssWMFiledesc object with a root
			/// directory returned by IVssWMFiledesc::GetPath contains only files in that directory or whether the file list contains files
			/// from the directory hierarchy as well.
			/// </summary>
			/// <param name="pbRecursive">
			/// <para>
			/// A pointer to a Boolean value specifying whether the value returned by IVssWMFiledesc::GetPath identifies only a single
			/// directory or if it indicates a hierarchy of directories to be traversed recursively. The Boolean value receives <c>true</c>
			/// if the path is treated as a hierarchy of directories to be traversed recursively, or <c>false</c> if not.
			/// </para>
			/// <para>For information on traversing over mounted folders, see Working with Mounted Folders and Reparse Points.</para>
			/// </param>
			/// <returns>
			/// <para>The following are the valid return codes for this method.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>S_OK</term>
			/// <term>Successfully returned the recursive information.</term>
			/// </item>
			/// <item>
			/// <term>E_INVALIDARG</term>
			/// <term>One of the parameter values is not valid.</term>
			/// </item>
			/// <item>
			/// <term>E_OUTOFMEMORY</term>
			/// <term>The caller is out of memory or other system resources.</term>
			/// </item>
			/// <item>
			/// <term>VSS_E_UNEXPECTED</term>
			/// <term>
			/// Unexpected error. The error code is logged in the error log file. For more information, see Event and Error Handling Under
			/// VSS. Windows Server 2008, Windows Vista, Windows Server 2003 and Windows XP: This value is not supported until Windows
			/// Server 2008 R2 and Windows 7. E_UNEXPECTED is used instead.
			/// </term>
			/// </item>
			/// <item>
			/// <term>VSS_E_INVALID_XML_DOCUMENT</term>
			/// <term>
			/// The XML document is not valid. Check the event log for details. For more information, see Event and Error Handling Under VSS.
			/// </term>
			/// </item>
			/// </list>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/vswriter/nf-vswriter-ivsswmfiledesc-getrecursive HRESULT GetRecursive(
			// [out] bool *pbRecursive );
			[PreserveSig]
			HRESULT GetRecursive(out bool pbRecursive);
		}

		/// <summary>
		/// <para>
		/// The <c>IVssWriterComponents</c> interface is a C++ (not COM) interface that contains methods used to obtain and modify component
		/// information (in the form of IVssComponent objects) associated with a given writer but stored in a requester's Backup Components Document.
		/// </para>
		/// <para>
		/// The CVssWriter base class is responsible for passing an instance of the <c>IVssWriterComponents</c> interface to the following
		/// event handlers:
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
		private interface IVssWriterComponents
		{ }

		/// <summary>Creates an IVssExpressWriter interface object and returns a pointer to it.</summary>
		/// <param name="ppWriter">Doubly indirect pointer to the newly created IVssExpressWriter object.</param>
		/// <returns>
		/// <para>
		/// The return values listed here are in addition to the normal COM HRESULT values that may be returned at any time from the function.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>Successfully returned a pointer to an IVssExpressWriter interface.</term>
		/// </item>
		/// <item>
		/// <term>E_ACCESSDENIED</term>
		/// <term>The caller does not have sufficient privileges.</term>
		/// </item>
		/// <item>
		/// <term>E_INVALIDARG</term>
		/// <term>One of the parameters is not valid.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/vswriter/nf-vswriter-createvssexpresswriter HRESULT CreateVssExpressWriter(
		// [out] IVssExpressWriter **ppWriter );
		[DllImport(Lib_VssApi, SetLastError = false, CharSet = CharSet.Unicode, EntryPoint = "CreateVssExpressWriterInternal")]
		[PInvokeData("vswriter.h", MSDNShortId = "NF:vswriter.CreateVssExpressWriter")]
		public static extern HRESULT CreateVssExpressWriter(out /*IVssExpressWriter*/ IntPtr ppWriter);
	}
}