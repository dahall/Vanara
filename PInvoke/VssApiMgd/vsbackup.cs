using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Vanara.PInvoke.VssApi
{
	/// <summary>
	/// <para>
	/// The <c>IVssBackupComponents</c> interface is used by a requester to poll writers about file status and to run backup/restore operations.
	/// </para>
	/// <para>Applications obtain an instance of the <c>IVssBackupComponents</c> interface by calling CreateVssBackupComponents.</para>
	/// <para>An <c>IVssBackupComponents</c> object can be used for only a single backup, restore, or Query operation.</para>
	/// <para>
	/// An <c>IVssBackupComponents</c> object must not be reused. For example, you cannot perform a backup or restore operation with the
	/// same <c>IVssBackupComponents</c> object that you have already used for a <c>Query</c> operation.
	/// </para>
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/vsbackup/nl-vsbackup-ivssbackupcomponents
	[PInvokeData("vsbackup.h", MSDNShortId = "NL:vsbackup.IVssBackupComponents")]
	public interface IVssBackupComponents
	{
		/// <summary>
		/// The <c>GetWriterComponents</c> method is used to return information about those components that have been stored in a
		/// requester's Backup Components Document.
		/// </summary>
		/// <returns>A list of IVssWriterComponentsExt interface objects with the returned component information.</returns>
		/// <remarks>
		/// <para>
		/// <c>WriterComponents</c> retrieves component information for components stored in the Backup Components Document by earlier calls
		/// to IVssBackupComponents::AddComponent.
		/// </para>
		/// <para>
		/// The information in the components stored in the Backup Components Document is not static. If a writer updates a component during
		/// a restore, that change will be reflected in the component retrieved by <c>GetWriterComponents</c>. This is in contrast with
		/// component information found in the IVssWMComponent object returned by IVssExamineWriterMetadata::GetComponent. That information
		/// is read-only and comes from the Writer Metadata Document of a writer process.
		/// </para>
		/// <para>
		/// The IVssWriterComponentsExt interface pointer that is returned in the pWriterComponents parameter should not be cached, because
		/// the following IVssBackupComponents methods cause the interface pointer that is returned by <c>GetWriterComponents</c> to be no
		/// longer valid:
		/// </para>
		/// <para>
		/// IVssBackupComponents::PrepareForBackup IVssBackupComponents::DoSnapshotSet IVssBackupComponents::BackupComplete
		/// IVssBackupComponents::PreRestore IVssBackupComponents::PostRestore If you call one of these methods after you have retrieved an
		/// IVssWriterComponentsExt interface pointer by calling <c>GetWriterComponents</c>, you cannot reuse that pointer, because it is no
		/// longer valid. Instead, you must call <c>GetWriterComponents</c> again to retrieve a new <c>IVssWriterComponentsExt</c> interface pointer.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/vsbackup/nf-vsbackup-ivssbackupcomponents-getwritercomponents HRESULT
		// GetWriterComponents( [in] UINT iWriter, [out] IVssWriterComponentsExt **ppWriter );
		IReadOnlyList<IVssWriterComponentsExt> WriterComponents { get; }

		/// <summary>The <c>WriterMetadata</c> property returns the metadata for writers running on the system.</summary>
		/// <returns>A list of IVssExamineWriterMetadata objects that contains the returned metadata.</returns>
		/// <remarks>
		/// <para>
		/// A requester must call the asynchronous operation IVssBackupComponents::GatherWriterMetadata and wait for it to complete prior to
		/// calling <c>WriterMetadata</c>.
		/// </para>
		/// <para>
		/// Although IVssBackupComponents::GatherWriterMetadata must be called prior to either a restore or backup operation,
		/// <c>WriterMetadata</c> is not typically called for restores.
		/// </para>
		/// <para>
		/// Component information retrieved (during backup operations) using IVssExamineWriterMetadata::GetComponent, where the
		/// IVssExamineWriterMetadata interface has been returned by <c>GetWriterMetadata</c>, comes from the Writer Metadata Document of a
		/// live writer process.
		/// </para>
		/// <para>
		/// This is in contrast to the information returned by GetWriterComponents (during restore operations), which was stored in the
		/// Backup Components Document by calls to AddComponent.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/vsbackup/nf-vsbackup-ivssbackupcomponents-getwritermetadata HRESULT
		// GetWriterMetadata( [in] UINT iWriter, [out] VSS_ID *pidInstance, [out] IVssExamineWriterMetadata **ppMetadata );
		IReadOnlyList<IVssExamineWriterMetadata> WriterMetadata { get; }

		/// <summary>The <c>WriterStatus</c> property returns the status of the writers.</summary>
		/// <remarks>
		/// <para>
		/// A requester must call the asynchronous operation IVssBackupComponents::GatherWriterStatus and wait for it to complete prior to
		/// calling <c>WriterStatus</c>.
		/// </para>
		/// <para>
		/// The VSS_E_WRITERERROR_XXX values returned in the pHrResultFailure parameter are generated by writers.
		/// VSS_E_WRITER_NOT_RESPONDING and VSS_E_WRITER_STATUS_NOT_AVAILABLE are generated by VSS.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/vsbackup/nf-vsbackup-ivssbackupcomponents-getwriterstatus HRESULT
		// GetWriterStatus( [in] UINT iWriter, [out] VSS_ID *pidInstance, [out] VSS_ID *pidWriter, [out] BSTR *pbstrWriter, [out]
		// VSS_WRITER_STATE *pnStatus, [out] HRESULT *phResultFailure );
		IReadOnlyList<VssWriterStatus> WriterStatus { get; }

		/// <summary>
		/// <para>The <c>AbortBackup</c> method notifies VSS that a backup operation was terminated.</para>
		/// <para>
		/// This method must be called if a backup operation terminates after the creation of a shadow copy set with
		/// IVssBackupComponents::StartSnapshotSet and before IVssBackupComponents::DoSnapshotSet returns.
		/// </para>
		/// <para>If <c>AbortBackup</c> is called and no shadow copy or backup operations are underway, it is ignored.</para>
		/// </summary>
		/// <remarks>
		/// <c>AbortBackup</c> generates an Abort event, which is handled by each instance of each writer through the CVssWriter::OnAbort method.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/vsbackup/nf-vsbackup-ivssbackupcomponents-abortbackup HRESULT AbortBackup();
		void AbortBackup();

		/// <summary>
		/// The <c>AddAlternativeLocationMapping</c> method is used by a requester to indicate that an alternate location mapping was used
		/// to restore all the members of a file set in a given component.
		/// </summary>
		/// <param name="writerId">Globally unique identifier (GUID) of the writer class that exported the component.</param>
		/// <param name="componentType">
		/// Type of the component. The possible values of this parameter are defined by the VSS_COMPONENT_TYPE enumeration.
		/// </param>
		/// <param name="wszLogicalPath">
		/// <para>String containing the logical path to the component.</para>
		/// <para>For more information, see Logical Pathing of Components.</para>
		/// <para>The logical path can be <see langword="null"/>.</para>
		/// <para>There are no restrictions on the characters that can appear in a non- <see langword="null"/> logical path.</para>
		/// </param>
		/// <param name="wszComponentName">
		/// <para>String containing the component name.</para>
		/// <para>There are no restrictions on the characters that can appear in a non- <see langword="null"/> logical path.</para>
		/// </param>
		/// <param name="wszPath">
		/// <para>
		/// String containing the path to the directory that originally contained the file to be relocated. This path can be local to the
		/// VSS machine, or it can be a file share directory on a remote file server.
		/// </para>
		/// <para>
		/// The path can contain environment variables (for example, %SystemRoot%) but cannot contain wildcard characters. UNC paths are supported.
		/// </para>
		/// <para>
		/// There is no requirement that the path end with a backslash (""). It is up to applications that retrieve this information to check.
		/// </para>
		/// </param>
		/// <param name="wszFilespec">
		/// <para>String containing the original file specification.</para>
		/// <para>
		/// A file specification cannot contain directory specifications (for example, no backslashes) but can contain the ? and * wildcard characters.
		/// </para>
		/// </param>
		/// <param name="bRecursive">
		/// <para>
		/// A Boolean value that indicates whether the path specified by the wszPath parameter identifies only a single directory or if it
		/// indicates a hierarchy of directories to be traversed recursively. This parameter should be set to <c>true</c> if the path is
		/// treated as a hierarchy of directories to be traversed recursively, or <c>false</c> if not.
		/// </para>
		/// <para>For information on traversing mounted folders, see Working with Mounted Folders and Reparse Points.</para>
		/// </param>
		/// <param name="wszDestination">
		/// String containing the name of the directory where the file will be relocated. This path can be local to the VSS machine, or it
		/// can be a file share directory on a remote file server. UNC paths are supported.
		/// </param>
		/// <remarks>
		/// <para>
		/// <c>Windows 7, Windows Server 2008 R2, Windows Vista, Windows Server 2008, Windows XP and Windows Server 2003:</c> Remote file
		/// shares are not supported until Windows 8 and Windows Server 2012.
		/// </para>
		/// <para>
		/// The writerId, componentType, wszLogicalPath, and wszComponentName parameters identify a particular component, and the wszPath,
		/// wszFilespec, and bRecursive parameters identify the file set belonging to that component.
		/// </para>
		/// <para>
		/// The combination of path, file specification, and recursion flag (wszPath, wszFilespec, and bRecursive, respectively) provided to
		/// <c>AddAlternativeLocationMapping</c> to be mapped must match that of one of the file sets added to a component using either
		/// IVssCreateWriterMetadata::AddFilesToFileGroup, IVssCreateWriterMetadata::AddDatabaseFiles, or IVssCreateWriterMetadata::AddDatabaseLogFiles.
		/// </para>
		/// <para>
		/// Because <c>AddAlternativeLocationMapping</c> is used to notify a writer that an alternate location was used to restore all the
		/// files in a component, it should not be called for any component or files in a component that have not had an alternate location
		/// mapping specified.
		/// </para>
		/// <para>
		/// The value of wszPath will have been mapped to wszDestination on restore; however, file names and subdirectories under the
		/// original path retain their same names.
		/// </para>
		/// <para>A typical usage of <c>AddAlternativeLocationMapping</c> during restore might be the following:</para>
		/// <list type="number">
		/// <item>
		/// <term>Retrieve stored Writer Metadata Documents from the backup media and load that information with IVssExamineWriterMetadata::LoadFromXML.</term>
		/// </item>
		/// <item>
		/// <term>
		/// Call IVssExamineWriterMetadata::GetAlternateLocationMapping to get an IVssWMFiledesc interface with the mapping information and
		/// use IVssWMFiledesc::GetAlternateLocation to get the alternate location.
		/// </term>
		/// </item>
		/// <item>
		/// <term>
		/// Examine filedesc information to heuristically determine which component this alternate location mapping should be applied to.
		/// </term>
		/// </item>
		/// <item>
		/// <term>Call <c>IVssBackupComponents::AddAlternativeLocationMapping</c> to communicate where files were restored.</term>
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
		/// <para>In either case, if no valid alternate location mapping is defined this constitutes a writer error.</para>
		/// <para>A file may be restored to an alternate location mapping if either of the following is true:</para>
		/// <list type="bullet">
		/// <item>
		/// <term>The restore method is VSS_RME_RESTORE_IF_NOT_THERE and a version of the file is already present on disk.</term>
		/// </item>
		/// <item>
		/// <term>The restore method is VSS_RME_RESTORE_IF_CAN_REPLACE and a version of the file is present on disk and cannot be replaced.</term>
		/// </item>
		/// </list>
		/// <para>Again, if no valid alternate location mapping is defined this constitutes a writer error.</para>
		/// <para>
		/// An alternate location mapping is used only during a restore operation and should not be confused with an alternate path, which
		/// is used only during a backup operation.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/vsbackup/nf-vsbackup-ivssbackupcomponents-addalternativelocationmapping
		// HRESULT AddAlternativeLocationMapping( [in] VSS_ID writerId, [in] VSS_COMPONENT_TYPE componentType, [in] LPCWSTR wszLogicalPath,
		// [in] LPCWSTR wszComponentName, [in] LPCWSTR wszPath, [in] LPCWSTR wszFilespec, [in] bool bRecursive, [in] LPCWSTR wszDestination );
		void AddAlternativeLocationMapping(Guid writerId, VSS_COMPONENT_TYPE componentType, [Optional] string wszLogicalPath,
			string wszComponentName, string wszPath, string wszFilespec, bool bRecursive, string wszDestination);

		/// <summary>
		/// The <c>AddComponent</c> method is used to explicitly add to the backup set in the Backup Components Document all required
		/// components (nonselectable for backup components without a selectable for backup ancestor), and such optional (selectable for
		/// backup) components as the requester considers necessary. Members of component sets (components with a selectable for backup
		/// ancestor) are implicitly included in the backup set, but are not explicitly added to the Backup Components Document.
		/// </summary>
		/// <param name="instanceId">Identifies a specific instance of a writer.</param>
		/// <param name="writerId">Writer class identifier.</param>
		/// <param name="ct">
		/// Identifies the type of the component. Refer to the documentation for VSS_COMPONENT_TYPE for permitted input values.
		/// </param>
		/// <param name="wszLogicalPath">
		/// <para>
		/// String containing the logical path of the selectable for backup component. For more information, see Logical Pathing of Components.
		/// </para>
		/// <para>A logical path is not required when adding a component. Therefore, the value of this parameter can be <see langword="null"/>.</para>
		/// <para>There are no restrictions on the characters that can appear in a non- <see langword="null"/> logical path.</para>
		/// </param>
		/// <param name="wszComponentName">
		/// <para>String containing the name of the selectable for backup component.</para>
		/// <para>The value of this parameter cannot be <see langword="null"/>.</para>
		/// <para>There are no restrictions on the characters that can appear in a non- <see langword="null"/> logical path.</para>
		/// </param>
		/// <remarks>
		/// <para>The <c>AddComponent</c> method has meaning only if the backup operation takes place in component mode.</para>
		/// <para>Only these kinds of components should be added to the Backup Components Document using <c>AddComponent</c>.</para>
		/// <list type="bullet">
		/// <item>
		/// <term>Components that are selectable for backup (see selectability for backup).</term>
		/// </item>
		/// <item>
		/// <term>Nonselectable-for-backup components with no selectable-for-backup ancestors.</term>
		/// </item>
		/// </list>
		/// <para>
		/// Nonselectable for backup components that have a selectable for backup ancestor in the hierarchy of their logical paths are part
		/// of a component set defined by the selectable for backup ancestor. These components are implicitly added to the Backup Components
		/// Document when the ancestor is added and should never be explicitly added to a requester's Backup Components Document by using
		/// <c>AddComponent</c>.The result of doing so is undefined (see Working with Selectability and Logical Paths).
		/// </para>
		/// <para>
		/// Selectable for backup components with selectable for backup ancestors are also subcomponents in a component set. They can be
		/// implicitly selected if their ancestor is selected (in which case they are not added to the Backup Components Document using
		/// <c>AddComponent</c>), or they can be explicitly selected using <c>AddComponent</c>.
		/// </para>
		/// <para>
		/// The combination of logical path and name for each component of a given instance of a given class of writer must be unique.
		/// Attempting to call <c>AddComponent</c> twice with the same values of wszLogicalPath and wszComponentName results in a
		/// VSS_E_OBJECT_ALREADY_EXISTS error.
		/// </para>
		/// <para>
		/// The distinction between the instanceId and the writerID is necessary because it is possible to run multiple copies for the same writer.
		/// </para>
		/// <para>A writer's class identifier and instance can be found by calling IVssExamineWriterMetadata::GetIdentity.</para>
		/// <para>
		/// Before it calls <c>AddComponent</c>, a requester must have been initialized for backup by calling
		/// IVssBackupComponents::InitializeForBackup and IVssBackupComponents::GatherWriterMetadata. See Overview of Backup Initialization.
		/// </para>
		/// <para>
		/// The requester must call <c>AddComponent</c> to add the required components to the shadow copy before calling
		/// IVssBackupComponents::DoSnapshotSet to create the shadow copy. See Overview of the Backup Discovery Phase and Overview of
		/// Pre-Backup Tasks.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/vsbackup/nf-vsbackup-ivssbackupcomponents-addcomponent HRESULT AddComponent(
		// [in] VSS_ID instanceId, [in] VSS_ID writerId, [in] VSS_COMPONENT_TYPE ct, [in] LPCWSTR wszLogicalPath, [in] LPCWSTR
		// wszComponentName );
		void AddComponent(Guid instanceId, Guid writerId, VSS_COMPONENT_TYPE ct, [Optional] string wszLogicalPath, string wszComponentName);

		/// <summary>
		/// The <c>AddNewTarget</c> method is used by a requester during a restore operation to indicate that the backup application plans
		/// to restore files to a new location.
		/// </summary>
		/// <param name="writerId">
		/// Globally unique identifier (GUID) of the writer class containing the files that are to receive a new target.
		/// </param>
		/// <param name="ct">
		/// Identifies the type of the component. Refer to the documentation for VSS_COMPONENT_TYPE for possible return values.
		/// </param>
		/// <param name="wszLogicalPath">
		/// <para>
		/// String containing the logical path of the component containing the files that are to receive a new restore target. For more
		/// information, see Logical Pathing of Components.
		/// </para>
		/// <para>
		/// The value of the string containing the logical path used here should be the same as was used when the component was added to the
		/// backup set using IVssBackupComponents::AddComponent.
		/// </para>
		/// <para>The logical path can be <see langword="null"/>.</para>
		/// <para>There are no restrictions on the characters that can appear in a non- <see langword="null"/> logical path.</para>
		/// </param>
		/// <param name="wszComponentName">
		/// <para>String containing the name of the component containing the files that are to receive a new restore target.</para>
		/// <para>
		/// The string should not be <see langword="null"/> and should contain the same component name as was used when the component was
		/// added to the backup set using IVssBackupComponents::AddComponent.
		/// </para>
		/// <para>There are no restrictions on the characters that can appear in a non- <see langword="null"/> logical path.</para>
		/// </param>
		/// <param name="wszPath">
		/// <para>String containing the name of the directory or directory hierarchy containing the files to receive a new restore target.</para>
		/// <para>The directory can be a local directory on the VSS machine, or it can be a file share directory on a remote file server.</para>
		/// <para>
		/// The path can contain environment variables (for example, %SystemRoot%) but cannot contain wildcard characters. UNC paths are supported.
		/// </para>
		/// <para>
		/// There is no requirement that the path end with a backslash (""). It is up to applications that retrieve this information to check.
		/// </para>
		/// </param>
		/// <param name="wszFileName">
		/// <para>String containing the file specification of the files to receive a new restore target.</para>
		/// <para>
		/// A file specification cannot contain directory specifications (for example, no backslashes) but can contain the ? and * wildcard characters.
		/// </para>
		/// </param>
		/// <param name="bRecursive">
		/// <para>
		/// Boolean indicating whether only the files in the directory defined by wszPath and matching the file specification provided by
		/// wszFileName are to receive a new restore target, or if all files in the hierarchy defined by wszPath and matching the file
		/// specification provided by wszFileName are to receive a new restore target.
		/// </para>
		/// <para>For information on traversing mounted folders, see Working with Mounted Folders and Reparse Points.</para>
		/// </param>
		/// <param name="wszAlternatePath">
		/// <para>String containing the fully qualified path of the new restore target directory.</para>
		/// <para>The directory can be a local directory on the VSS machine, or it can be a file share directory on a remote file server.</para>
		/// <para>UNC paths are supported.</para>
		/// </param>
		/// <remarks>
		/// <para>
		/// <c>Windows 7, Windows Server 2008 R2, Windows Vista, Windows Server 2008, Windows XP and Windows Server 2003:</c> Remote file
		/// shares are not supported until Windows 8 and Windows Server 2012.
		/// </para>
		/// <para>
		/// The component name specified as an argument to <c>AddNewTarget</c> (wszComponentName) must match a component that has already
		/// been added to the Backup Components Document.
		/// </para>
		/// <para>Therefore, wszComponentName can be the name of any component explicitly included in the Backup Components Document.</para>
		/// <para>
		/// Adding a new target for file in a subcomponent must be done using the name of the component that defines the component set
		/// containing the subcomponent.
		/// </para>
		/// <para>
		/// When specifying a file or files to have their restore target changed, a requester must ensure that the combination of path, file
		/// specification, and recursion flag (wszPath, wszFileSpec, and bRecursive, respectively) provided to <c>AddNewTarget</c> must
		/// match that of one of the file sets added to a component using IVssCreateWriterMetadata::AddFilesToFileGroup,
		/// IVssCreateWriterMetadata::AddDatabaseFiles, or IVssCreateWriterMetadata::AddDatabaseLogFiles.
		/// </para>
		/// <para>
		/// When a requester calls <c>AddNewTarget</c>, it must do so before calling IVssBackupComponents::PreRestore. For more information,
		/// see Overview of Preparing for Restore.
		/// </para>
		/// <para>
		/// Path and file descriptor information can be obtained from the Writer Metadata Document by using the IVssWMFiledesc object
		/// returned by IVssWMComponent::GetFile, IVssWMComponent::GetDatabaseFile, or IVssWMComponent::GetDatabaseLogFile. The
		/// IVssWMComponent object is obtained from Writer Metadata Document by the IVssExamineWriterMetadata::GetComponent method.
		/// </para>
		/// <para>
		/// Writers can determine if files have been restored to new locations by using the IVssComponent::GetNewTargetCount and
		/// IVssComponent::GetNewTarget methods.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/vsbackup/nf-vsbackup-ivssbackupcomponents-addnewtarget HRESULT AddNewTarget(
		// [in] VSS_ID writerId, [in] VSS_COMPONENT_TYPE ct, [in] LPCWSTR wszLogicalPath, [in] LPCWSTR wszComponentName, [in] LPCWSTR
		// wszPath, [in] LPCWSTR wszFileName, [in] bool bRecursive, [in] LPCWSTR wszAlternatePath );
		void AddNewTarget(Guid writerId, VSS_COMPONENT_TYPE ct, [Optional] string wszLogicalPath, string wszComponentName,
			string wszPath, string wszFileName, bool bRecursive, string wszAlternatePath);

		/// <summary>
		/// The <c>AddRestoreSubcomponent</c> method indicates that a subcomponent member of a component set, which had been marked as
		/// nonselectable for backup but is marked selectable for restore, is to be restored irrespective of whether any other member of the
		/// component set will be restored.
		/// </summary>
		/// <param name="writerId">Writer class identifier.</param>
		/// <param name="componentType">
		/// Identifies the type of the component. Refer to the documentation for VSS_COMPONENT_TYPE for possible return values.
		/// </param>
		/// <param name="wszLogicalPath">
		/// <para>
		/// String containing the logical path of the component in the backup document that defines the backup component set containing the
		/// subcomponent to be added for restore.
		/// </para>
		/// <para>The value of this parameter can be <see langword="null"/>.</para>
		/// <para>There are no restrictions on the characters that can appear in a non- <see langword="null"/> logical path.</para>
		/// </param>
		/// <param name="wszComponentName">
		/// <para>
		/// String containing the logical path of the component in the backup document that defines the backup component set containing the
		/// subcomponent to be added for restore.
		/// </para>
		/// <para>The value of this parameter cannot be <see langword="null"/>.</para>
		/// <para>There are no restrictions on the characters that can appear in a non- <see langword="null"/> component name.</para>
		/// </param>
		/// <param name="wszSubComponentLogicalPath">
		/// <para>String containing the logical path of the subcomponent to be added for restore.</para>
		/// <para>A logical path is required when adding a subcomponent. Therefore, the value of this parameter cannot be <see langword="null"/>.</para>
		/// <para>There are no restrictions on the characters that can appear in a non- <see langword="null"/> logical path.</para>
		/// </param>
		/// <param name="wszSubComponentName">
		/// <para>String containing the logical name of the subcomponent to be added for restore.</para>
		/// <para>The value of this parameter cannot be <see langword="null"/>.</para>
		/// <para>There are no restrictions on the characters that can appear in a non- <see langword="null"/> component name.</para>
		/// </param>
		/// <param name="bRepair">This parameter is reserved for future use. This parameter should always be set to <c>false</c></param>
		/// <remarks>
		/// <para>
		/// Before calling <c>AddRestoreSubcomponent</c>, the root component defined by the wszLogicalPath and wszComponentName parameters
		/// must first be selected for restore using IVssBackupComponents::SetSelectedForRestore.
		/// </para>
		/// <para>If a requester is to support restoring subcomponents, this method must be called before IVssBackupComponents::PreRestore.</para>
		/// <para>
		/// <c>AddRestoreSubcomponent</c> is intended for the case in which all the files in a writer's component set must be backed up as a
		/// unit, but where it is desirable that selected files (subcomponents) be capable of being restored individually.
		/// </para>
		/// <para>
		/// To participate in such a restore, a subcomponent must have the <c>bSelectableForRestore</c> member of VSS_COMPONENTINFO set to
		/// <c>TRUE</c>. The component defined by the wszLogicalPath and wszComponentName parameters must also be selected for restore using IVssBackupComponents::SetSelectedForRestore.
		/// </para>
		/// <para>See Working with Selectability for Restore and Subcomponents for more information.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/vsbackup/nf-vsbackup-ivssbackupcomponents-addrestoresubcomponent HRESULT
		// AddRestoreSubcomponent( [in] VSS_ID writerId, [in] VSS_COMPONENT_TYPE componentType, [in] LPCWSTR wszLogicalPath, [in] LPCWSTR
		// wszComponentName, [in] LPCWSTR wszSubComponentLogicalPath, [in] LPCWSTR wszSubComponentName, [in] bool bRepair );
		void AddRestoreSubcomponent(Guid writerId, VSS_COMPONENT_TYPE componentType, [Optional] string wszLogicalPath,
			string wszComponentName, string wszSubComponentLogicalPath, string wszSubComponentName, bool bRepair);

		/// <summary>
		/// Specifies the volumes to be included in a LUN resynchronization operation. This method is supported only on Windows server
		/// operating systems.
		/// </summary>
		/// <param name="snapshotId">
		/// The identifier of the shadow copy that was returned by the IVssBackupComponents::AddToSnapshotSet method during backup. This
		/// parameter is required and cannot be Guid.Null.
		/// </param>
		/// <param name="dwFlags">This parameter is reserved and must be zero.</param>
		/// <param name="pwszDestinationVolume">
		/// This parameter is optional and can be <see langword="null"/>. A value of <see langword="null"/> means that the contents of the
		/// shadow copy volume are to be copied back to the original volume. VSS identifies the original volume by the VDS_LUN_INFO
		/// information in the Backup Components Document.
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/vsbackup/nf-vsbackup-ivssbackupcomponentsex3-addsnapshottorecoveryset HRESULT
		// AddSnapshotToRecoverySet( [in] VSS_ID snapshotId, [in] DWORD dwFlags, [in, optional] VSS_PWSZ pwszDestinationVolume );
		void AddSnapshotToRecoverySet(Guid snapshotId, [Optional] uint dwFlags, string pwszDestinationVolume = default);

		/// <summary>The <c>AddToSnapshotSet</c> method adds an original volume or original remote file share to the shadow copy set.</summary>
		/// <param name="pwszVolumeName">
		/// <para>
		/// String containing the name of the volume or the UNC path of the remote file share to be shadow copied. The name or UNC path must
		/// be in one of the following formats and must include a trailing backslash (\):
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <term>The path of a mounted folder, for example, Y:\MountX\</term>
		/// </item>
		/// <item>
		/// <term>A drive letter, for example, D:\</term>
		/// </item>
		/// <item>
		/// <term>A volume GUID path of the form \\?\Volume{GUID}\ (where GUID identifies the volume)</term>
		/// </item>
		/// <item>
		/// <term>A UNC path that specifies a remote file share, for example, \\Clusterx\Share1\</term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="ProviderId">The provider to be used. Guid.Null can be used, in which case the default provider will be used.</param>
		/// <returns>Returned identifier of the added shadow copy.</returns>
		/// <remarks>
		/// <para>
		/// <c>Windows 7, Windows Server 2008 R2, Windows Vista, Windows Server 2008, Windows XP and Windows Server 2003:</c> Remote file
		/// shares are not supported until Windows 8 and Windows Server 2012.
		/// </para>
		/// <para>
		/// If pwszVolumeName is a UNC share path, the server name portion must be in hostname or fully qualified domain name format. UNC
		/// share names with IP addresses must be normalized by calling the IVssBackupComponentsEx4::GetRootAndLogicalPrefixPaths method
		/// before they are passed to <c>AddToSnapshotSet</c>.
		/// </para>
		/// <para>The maximum number of shadow copied volumes in a single shadow copy set is 64.</para>
		/// <para>If ProviderId is Guid.Null, the default provider is selected according to the following algorithm:</para>
		/// <list type="number">
		/// <item>
		/// <term>If any hardware provider supports the given volume or remote file share, that provider is selected.</term>
		/// </item>
		/// <item>
		/// <term>If there is no hardware provider available, if any software provider supports the given volume, it is selected.</term>
		/// </item>
		/// <item>
		/// <term>
		/// If there is no hardware provider or software provider available, the system provider is selected. (There is only one
		/// preinstalled system provider, which must support all nonremovable local volumes.)
		/// </term>
		/// </item>
		/// </list>
		/// <para>This method cannot be called for a virtual hard disk (VHD) that is nested inside another VHD.</para>
		/// <para><c>Windows Server 2008, Windows Vista, Windows Server 2003 and Windows XP:</c> VHDs are not supported.</para>
		/// <para>
		/// The shadow copy identifier that is returned in the pidSnapshot parameter is stored in the Backup Components Document. However,
		/// there is no method for querying this information, and the caller may need to store it so that it can be used during restore.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/vsbackup/nf-vsbackup-ivssbackupcomponents-addtosnapshotset HRESULT
		// AddToSnapshotSet( [in] VSS_PWSZ pwszVolumeName, [in] VSS_ID ProviderId, [out] VSS_ID *pidSnapshot );
		Guid AddToSnapshotSet(string pwszVolumeName, Guid ProviderId);

		/// <summary>
		/// The <c>BackupComplete</c> method causes VSS to generate a <c>BackupComplete</c> event, which signals writers that the backup
		/// process has completed.
		/// </summary>
		/// <returns>An IVssAsync instance.</returns>
		/// <remarks>
		/// <para>
		/// When working in component mode (IVssBackupComponents::SetBackupState was called with a select components argument of
		/// <c>TRUE</c>), writers can determine the success or failure of the backup of any component explicitly included in the Backup
		/// Components Document components by using IVssComponent::GetBackupSucceeded. Therefore, a well-behaved backup application
		/// (requester) must call IVssBackupComponents::SetBackupSucceeded after each component has been processed and prior to calling <c>BackupComplete</c>.
		/// </para>
		/// <para>
		/// Do not call this method if the call to IVssBackupComponents::DoSnapshotSet failed. For more information about how requesters use
		/// <c>DoSnapshotSet</c>, SetBackupSucceeded, and <c>BackupComplete</c> in a backup operation, see Overview of Pre-Backup Tasks and
		/// Overview of Actual Backup Of Files.
		/// </para>
		/// <para>
		/// This operation is asynchronous. The caller can use the QueryStatus interface method in the returned IVssAsync interface to
		/// determine the status of the notification.
		/// </para>
		/// <para>
		/// After calling <c>BackupComplete</c>, requesters must call GatherWriterStatus to cause the writer session to be set to a
		/// completed state.
		/// </para>
		/// <para><c>Note</c> This is only necessary on Windows Server 2008 with Service Pack 2 (SP2) and earlier.</para>
		/// <para>The backup application can choose to abort the backup at any time after the shadow copy is created by calling IVssAsync::Cancel.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/vsbackup/nf-vsbackup-ivssbackupcomponents-backupcomplete HRESULT
		// BackupComplete( [out] IVssAsync **ppAsync );
		IVssAsync BackupComplete();

		/// <summary>The <c>BreakSnapshotSet</c> method causes the existence of a shadow copy set to be "forgotten" by VSS.</summary>
		/// <param name="SnapshotSetId">Shadow copy set identifier.</param>
		/// <remarks>
		/// <para>
		/// <c>BreakSnapshotSet</c> can be used only for shadow copies created by a hardware shadow copy provider. This method makes these
		/// shadow copies regular volumes.
		/// </para>
		/// <para>
		/// Shadow copies of volumes "broken" with <c>BreakSnapshotSet</c> must be managed independently of VSS as stand-alone volumes. See
		/// Breaking Shadow Copies for more information.
		/// </para>
		/// <para>
		/// IVssBackupComponentsEx2::BreakSnapshotSetEx is similar to the <c>BreakSnapshotSet</c> method, except that it has extra
		/// parameters to query status and specify how the shadow copy set is broken.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/vsbackup/nf-vsbackup-ivssbackupcomponents-breaksnapshotset HRESULT
		// BreakSnapshotSet( [in] VSS_ID SnapshotSetId );
		void BreakSnapshotSet(Guid SnapshotSetId);

		/// <summary>Breaks a shadow copy set according to requester-specified options.</summary>
		/// <param name="SnapshotSetID">A shadow copy set identifier.</param>
		/// <param name="dwBreakFlags">A bitmask of _VSS_HARDWARE_OPTIONS flags that specify how the shadow copy set is broken.</param>
		/// <returns>
		/// A variable that receives an IVssAsync interface pointer that can be used to retrieve the status of the shadow copy set break
		/// operation.
		/// </returns>
		/// <remarks>
		/// <para>
		/// <c>BreakSnapshotSetEx</c> is similar to the IVssBackupComponents::BreakSnapshotSet method, except that it has extra parameters
		/// to query status and specify how the shadow copy set is broken.
		/// </para>
		/// <para>
		/// Like BreakSnapshotSet, <c>BreakSnapshotSetEx</c> can be used only for shadow copies that were created by a hardware shadow copy provider.
		/// </para>
		/// <para>
		/// After this method returns, the shadow copy volume is still a volume, but it is no longer a shadow copy. For more information,
		/// see Breaking Shadow Copies.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/vsbackup/nf-vsbackup-ivssbackupcomponentsex2-breaksnapshotsetex HRESULT
		// BreakSnapshotSetEx( VSS_ID SnapshotSetID, DWORD dwBreakFlags, [out] IVssAsync **ppAsync );
		IVssAsync BreakSnapshotSetEx(Guid SnapshotSetID, VSS_HARDWARE_OPTIONS dwBreakFlags);

		/// <summary>The <c>DeleteSnapshots</c> method deletes one or more shadow copies or a shadow copy set.</summary>
		/// <param name="SourceObjectId">Identifier of the shadow copy or a shadow copy set to be deleted.</param>
		/// <param name="eSourceObjectType">
		/// Type of the object on which all shadow copies will be deleted. The value of this parameter is <c>VSS_OBJECT_SNAPSHOT</c> or <c>VSS_OBJECT_SNAPSHOT_SET</c>.
		/// </param>
		/// <param name="bForceDelete">
		/// If the value of this parameter is <c>TRUE</c>, the provider will do everything possible to delete the shadow copy or shadow
		/// copies in a shadow copy set. If it is <c>FALSE</c>, no additional effort will be made.
		/// </param>
		/// <param name="plDeletedSnapshots">Number of deleted shadow copies.</param>
		/// <param name="pNondeletedSnapshotID">
		/// If an error occurs, the value of this parameter is the identifier of the first shadow copy that could not be deleted. Otherwise,
		/// it is <c>Guid.Null</c>.
		/// </param>
		/// <remarks>
		/// <para>
		/// Multiple shadow copies in a shadow copy set are deleted sequentially. If an error occurs during one of these individual
		/// deletions, <c>DeleteSnapshots</c> will return immediately; no attempt will be made to delete any remaining shadow copies. The
		/// VSS_ID of the undeleted shadow copy is returned in pNondeletedSnapshotID.
		/// </para>
		/// <para>The requester is responsible for serializing the delete shadow copy operation.</para>
		/// <para>
		/// During a backup, shadow copies are automatically released as soon as the IVssBackupComponents instance is released. In this
		/// case, it is not necessary to explicitly delete shadow copies.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/vsbackup/nf-vsbackup-ivssbackupcomponents-deletesnapshots HRESULT
		// DeleteSnapshots( [in] VSS_ID SourceObjectId, [in] VSS_OBJECT_TYPE eSourceObjectType, [in] BOOL bForceDelete, [out] LONG
		// *plDeletedSnapshots, [out] VSS_ID *pNondeletedSnapshotID );
		void DeleteSnapshots(Guid SourceObjectId, VSS_OBJECT_TYPE eSourceObjectType, bool bForceDelete,
			out int plDeletedSnapshots, out Guid pNondeletedSnapshotID);

		/// <summary>The <c>DisableWriterClasses</c> method prevents a specific class of writers from receiving any events.</summary>
		/// <param name="rgWriterClassId">An array containing one or more writer class identifiers.</param>
		/// <remarks>
		/// <para>
		/// If you have multiple running copies of the same writer, they will all have the same writer class identifier, but they will have
		/// different writer instance identifiers. Disabling a writer class causes all of the writer's instances to be disabled.
		/// </para>
		/// <para>
		/// If the <c>DisableWriterClasses</c> method and the IVssBackupComponents::EnableWriterClasses method are never called, all writer
		/// classes are enabled.
		/// </para>
		/// <para>
		/// After the first call to <c>DisableWriterClasses</c> returns, the writer classes that were specified in the rgWriterClassId array
		/// are disabled, and all other writer classes are enabled.
		/// </para>
		/// <para>
		/// If you call <c>DisableWriterClasses</c> more than once, each call adds the writers in the rgWriterClassId array to the list of
		/// disabled writers.
		/// </para>
		/// <para>
		/// If you call <c>DisableWriterClasses</c> one or more times and then call EnableWriterClasses, the first call to
		/// <c>EnableWriterClasses</c> cancels the effect of the calls to <c>DisableWriterClasses</c> and enables only the writers in the
		/// rgWriterClassId array.
		/// </para>
		/// <para>
		/// If you call <c>DisableWriterClasses</c>, you must do so before calling the IVssBackupComponents::GatherWriterMetadata method. If
		/// you call <c>GatherWriterMetadata</c> first and then call <c>DisableWriterClasses</c>, the call to <c>DisableWriterClasses</c>
		/// has no effect. If you need to call <c>GatherWriterMetadata</c> first, to determine which writer classes to disable, you must
		/// call it from a different instance of the IVssBackupComponents interface.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/vsbackup/nf-vsbackup-ivssbackupcomponents-disablewriterclasses HRESULT
		// DisableWriterClasses( [in] const VSS_ID *rgWriterClassId, [in] UINT cClassId );
		void DisableWriterClasses([In] Guid[] rgWriterClassId);

		/// <summary>The <c>DisableWriterInstances</c> method disables a specified writer instance or instances.</summary>
		/// <param name="rgWriterInstanceId">An array containing one or more writer instance identifiers.</param>
		/// <remarks>
		/// <para>
		/// If you have multiple running copies of the same writer, they will all have the same writer class identifier, but they will have
		/// different writer instance identifiers. Disabling one instance of a writer does not cause the writer's other instances to be disabled.
		/// </para>
		/// <para>
		/// If you call <c>DisableWriterInstances</c>, you must do so before calling the IVssBackupComponents::GatherWriterMetadata method.
		/// If you call <c>GatherWriterMetadata</c> first and then call <c>DisableWriterInstances</c>, the call to
		/// <c>DisableWriterInstances</c> has no effect. If you need to call <c>GatherWriterMetadata</c> first, to determine which writer
		/// instances to disable, you must call it from a different instance of the IVssBackupComponents interface.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/vsbackup/nf-vsbackup-ivssbackupcomponents-disablewriterinstances HRESULT
		// DisableWriterInstances( [in] const VSS_ID *rgWriterInstanceId, [in] UINT cInstanceId );
		void DisableWriterInstances([In] Guid[] rgWriterInstanceId);

		/// <summary>Commits all shadow copies in this set simultaneously.</summary>
		/// <returns>
		/// The required IVssAsync asynchronous interface. This is used to query the method execution state and
		/// to retrieve the final error code.
		/// </returns>
		/// <remarks>
		/// <para>The caller is responsible for releasing the IVssAsync interface.</para>
		/// <para>This method cannot be called for a virtual hard disk (VHD) that is nested inside another VHD.</para>
		/// <para><c>Windows Server 2008, Windows Vista, Windows Server 2003 and Windows XP:</c> VHDs are not supported.</para>
		/// <para>
		/// For information on how to use <c>IVssBackupComponents::DoSnapshotSet</c> to create a standard backup shadow copy, see Overview
		/// of Pre-Backup Tasks and Simple Shadow Copy Creation for Backup. For information on how the method is used under different VSS
		/// contexts, see Implementation Details for Creating Shadow Copies.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/vsbackup/nf-vsbackup-ivssbackupcomponents-dosnapshotset HRESULT DoSnapshotSet(
		// [out] IVssAsync **ppAsync );
		IVssAsync DoSnapshotSet();

		/// <summary>The <c>EnableWriterClasses</c> method enables the specified writers to receive all events.</summary>
		/// <param name="rgWriterClassId">An array containing one or more writer class identifiers.</param>
		/// <remarks>
		/// <para>
		/// If the <c>EnableWriterClasses</c> method and the IVssBackupComponents::DisableWriterClasses method are never called, all writer
		/// classes are enabled.
		/// </para>
		/// <para>
		/// After the first call to <c>EnableWriterClasses</c> returns, the writer classes that were specified in the rgWriterClassId array
		/// are enabled, and all other writer classes are disabled.
		/// </para>
		/// <para>
		/// If you call <c>EnableWriterClasses</c> more than once, each call adds the writers in the rgWriterClassId array to the list of
		/// enabled writers.
		/// </para>
		/// <para>
		/// If you call <c>EnableWriterClasses</c> one or more times and then call DisableWriterClasses, the call to
		/// <c>DisableWriterClasses</c> disables any writers in the rgWriterClassId array that were enabled in the calls to <c>EnableWriterClasses</c>.
		/// </para>
		/// <para>
		/// If you call <c>EnableWriterClasses</c>, you must do so before calling the IVssBackupComponents::GatherWriterMetadata method. If
		/// you call <c>GatherWriterMetadata</c> first and then call <c>EnableWriterClasses</c>, the call to <c>EnableWriterClasses</c> has
		/// no effect. If you need to call <c>GatherWriterMetadata</c> first, to determine which writer classes to enable, you must call it
		/// from a different instance of the IVssBackupComponents interface.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/vsbackup/nf-vsbackup-ivssbackupcomponents-enablewriterclasses HRESULT
		// EnableWriterClasses( [in] const VSS_ID *rgWriterClassId, [in] UINT cClassId );
		void EnableWriterClasses([In] Guid[] rgWriterClassId);

		/// <summary>The <c>ExposeSnapshot</c> method exposes a shadow copy as a drive letter, mounted folder, or file share.</summary>
		/// <param name="SnapshotId">Shadow copy identifier.</param>
		/// <param name="wszPathFromRoot">
		/// <para>
		/// The path to the portion of the volume made available when exposing a shadow copy as a file share. The value of this parameter
		/// must be <see langword="null"/> when exposing a shadow copy locally; that is, exposing it as a drive letter or mounted folder.
		/// </para>
		/// <para>The path cannot contain environment variables (for example, %MyEnv%) or wildcard characters.</para>
		/// <para>
		/// There is no requirement that the path end with a backslash (""). It is up to applications that retrieve this information to check.
		/// </para>
		/// </param>
		/// <param name="lAttributes">
		/// Attributes of the exposed shadow copy indicating whether it is exposed locally or remotely. The value must be either the
		/// <c>VSS_VOLSNAP_ATTR_EXPOSED_LOCALLY</c> or the <c>VSS_VOLSNAP_ATTR_EXPOSED_REMOTELY</c> value of _VSS_VOLUME_SNAPSHOT_ATTRIBUTES.
		/// </param>
		/// <param name="wszExpose">
		/// When a shadow copy is exposed as a file share, the value of this parameter is the share name. If a shadow copy is exposed by
		/// mounting it as a device, the parameter value is a drive letter followed by a colon—for example, "X:" or a mounted folder path
		/// (for example, "Y:\MountX"). If the value of this parameter is <see langword="null"/>, then VSS determines the share name or
		/// drive letter if the lAttributes parameter is <c>VSS_VOLSNAP_ATTR_EXPOSED_REMOTELY</c>.
		/// </param>
		/// <returns>
		/// The exposed name of the shadow copy. This is either a share name, a drive letter followed by a colon, or a mounted folder. The
		/// value is <see langword="null"/> if <c>ExposeSnapshot</c> failed. VSS allocates the memory for this string.
		/// </returns>
		/// <remarks>
		/// <para>
		/// The caller is responsible for freeing the string that the pwszExposed parameter points to by calling the CoTaskMemFree function.
		/// </para>
		/// <para>When exposing a persistent shadow copy, it remains exposed through subsequent boots.</para>
		/// <para>
		/// When exposing a shadow copy of a volume, the shadow copy may be treated either as a mountable device or as a file system
		/// available for file sharing.
		/// </para>
		/// <para>
		/// When it is exposed as a device—as with other mountable devices—the shadow copy of a volume is exposed at its mount point (drive
		/// letter or mounted folder) starting with its root.
		/// </para>
		/// <para>When exposed as a file share, subsets (indicated by wszPathFromRoot) of the volume can be shared.</para>
		/// <para>For more information on how to expose shadow copies, see Exposing and Surfacing Shadow Copied Volumes.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/vsbackup/nf-vsbackup-ivssbackupcomponents-exposesnapshot HRESULT
		// ExposeSnapshot( [in] VSS_ID SnapshotId, [in] VSS_PWSZ wszPathFromRoot, [in] LONG lAttributes, [in] VSS_PWSZ wszExpose, [out]
		// VSS_PWSZ *pwszExposed );
		string ExposeSnapshot(Guid SnapshotId, [Optional] string wszPathFromRoot,
			VSS_VOLUME_SNAPSHOT_ATTRIBUTES lAttributes, [Optional] string wszExpose);

		/// <summary>
		/// <para>Not supported.</para>
		/// <para>This method is reserved for future use.</para>
		/// </summary>
		/// <param name="SnapshotSetID">This parameter is reserved for future use.</param>
		/// <param name="dwFastRecoveryFlags">This parameter is reserved for future use.</param>
		/// <returns>This parameter is reserved for future use.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/vsbackup/nf-vsbackup-ivssbackupcomponentsex2-fastrecovery HRESULT
		// FastRecovery( VSS_ID SnapshotSetID, DWORD dwFastRecoveryFlags, IVssAsync **ppAsync );
		IVssAsync FastRecovery(Guid SnapshotSetID, [Optional] uint dwFastRecoveryFlags);

		/// <summary>
		/// The <c>FreeWriterMetadata</c> method frees system resources allocated when IVssBackupComponents::GatherWriterMetadata was called.
		/// </summary>
		/// <remarks>
		/// <para>
		/// This method should never be called prior to the completion of IVssBackupComponents::GatherWriterMetadata. The result of calling
		/// the method prior to completion of the metadata gather is undefined.
		/// </para>
		/// <para>
		/// Once writer metadata has been freed, it cannot be recovered by the current instance of the IVssBackupComponents interface. It
		/// will be necessary to create a new instance of <c>IVssBackupComponents</c>, and call the
		/// IVssBackupComponents::GatherWriterMetadata method again.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/vsbackup/nf-vsbackup-ivssbackupcomponents-freewritermetadata HRESULT FreeWriterMetadata();
		void FreeWriterMetadata();

		/// <summary>The <c>FreeWriterStatus</c> method frees system resources allocated during the call to IVssBackupComponents::GatherWriterStatus.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/vsbackup/nf-vsbackup-ivssbackupcomponents-freewriterstatus HRESULT FreeWriterStatus();
		void FreeWriterStatus();

		/// <summary>
		/// The <c>GatherWriterMetadata</c> method prompts each writer to send the metadata they have collected. The method will generate an
		/// Identify event to communicate with writers.
		/// </summary>
		/// <returns>An IVssAsync object containing the writer metadata.</returns>
		/// <remarks>
		/// <para>The caller is responsible for releasing the IVssAsync interface.</para>
		/// <para><c>GatherWriterMetadata</c> should be called only once during the lifetime of a given IVssBackupComponents object.</para>
		/// <para>
		/// <c>GatherWriterMetadata</c> generates an Identify event, which is handled by each instance of each writer through the
		/// CVssWriter::OnIdentify method, which is used to fill the Writer Metadata Document.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/vsbackup/nf-vsbackup-ivssbackupcomponents-gatherwritermetadata HRESULT
		// GatherWriterMetadata( [out] IVssAsync **pAsync );
		IVssAsync GatherWriterMetadata();

		/// <summary>The <c>GatherWriterStatus</c> method prompts each writer to send a status message.</summary>
		/// <returns>An IVssAsync object containing the writer status data.</returns>
		/// <remarks>
		/// <para>The caller of this method should also call IVssBackupComponents::FreeWriterStatus after receiving the status of each writer.</para>
		/// <para>
		/// After calling BackupComplete, requesters must call <c>GatherWriterStatus</c> to cause the writer session to be set to a
		/// completed state.
		/// </para>
		/// <para><c>Note</c> This is only necessary on Windows Server 2008 with Service Pack 2 (SP2) and earlier.</para>
		/// <para>The CVssWriter class handles the status message sent by each writer.</para>
		/// <para>The caller is responsible for releasing the IVssAsync interface.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/vsbackup/nf-vsbackup-ivssbackupcomponents-gatherwriterstatus HRESULT
		// GatherWriterStatus( [out] IVssAsync **pAsync );
		IVssAsync GatherWriterStatus();

		/// <summary>
		/// Normalizes a local volume path or UNC share path so that it can be passed to the IVssBackupComponents::AddToSnapshotSet method.
		/// </summary>
		/// <param name="pwszFilePath">The path to be normalized.</param>
		/// <param name="ppwszRootPath">Receives the root path that should be passed to the IVssBackupComponents::AddToSnapshotSet method.</param>
		/// <param name="ppwszLogicalPrefix">
		/// If pwszFilePath is a local path, this parameter receives the volume GUID name. If it's a UNC path, this parameter receives a
		/// fully evaluated share path.
		/// </param>
		/// <param name="bNormalizeFQDNforRootPath">
		/// <para>If pwszFilePath is a UNC share path, the server name portion can be</para>
		/// <list type="bullet">
		/// <item>
		/// <term>A host name</term>
		/// <description></description>
		/// </item>
		/// <item>
		/// <term>A fully qualified domain name</term>
		/// <description></description>
		/// </item>
		/// <item>
		/// <term>An IP address</term>
		/// <description></description>
		/// </item>
		/// </list>
		/// <para>
		/// This parameter specifies whether host name format or fully qualified domain name format should be used in the server name
		/// portion of the normalized root path that is returned in the ppwszRootPath parameter.
		/// </para>
		/// <para>If this parameter is <c>FALSE</c>, simple host name format will be used.</para>
		/// <para>The default value for this parameter is <c>FALSE</c>.</para>
		/// <para>If this parameter is <c>TRUE</c>, fully qualified domain name will be used.</para>
		/// <para>In a deployment where a host name could exist in multiple domain suffixes, this parameter should be <c>TRUE</c>.</para>
		/// </param>
		/// <remarks>
		/// <para>
		/// This method normalizes a local volume path or UNC share path and separates it into a root path and a logical prefix path. The
		/// root path can then be passed to the IVssBackupComponents::AddToSnapshotSet method.
		/// </para>
		/// <para>
		/// If pwszFilePath is a local volume path, the root path will be similar to a volume mount point. In this case, the root and the
		/// logical prefix paths map to the results of GetVolumePathName and GetVolumeNameForVolumeMountPoint, respectively.
		/// </para>
		/// <para>
		/// If pwszFilePath is a UNC share path, the root and logical prefix paths map to the root path of the file share and the fully
		/// evaluated physical share path (which will take into account DFS and cluster deployment), respectively.
		/// </para>
		/// <para>
		/// If you call this method more than once for the same shadow copy set creation operation, you must set the
		/// bNormalizeFQDNforRootPath to the same value for every call. Fully qualified domain name format and host name format cannot be
		/// mixed in the same shadow copy set.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/vsbackup/nf-vsbackup-ivssbackupcomponentsex4-getrootandlogicalprefixpaths
		// HRESULT GetRootAndLogicalPrefixPaths( [in] VSS_PWSZ pwszFilePath, [out] VSS_PWSZ *ppwszRootPath, [out] VSS_PWSZ
		// *ppwszLogicalPrefix, [in, optional] BOOL bNormalizeFQDNforRootPath );
		void GetRootAndLogicalPrefixPaths(string pwszFilePath, out string ppwszRootPath,
			out string ppwszLogicalPrefix, bool bNormalizeFQDNforRootPath = false);

		/// <summary>Returns the requester's session identifier.</summary>
		/// <returns>A variable that receives the session identifier.</returns>
		/// <remarks>
		/// <para>
		/// The session identifier is an opaque value that uniquely identifies a backup or restore session. It is used to distinguish the
		/// current session among multiple parallel backup or restore sessions.
		/// </para>
		/// <para>
		/// As a best practice, writers and requesters should include the session ID in all diagnostics messages used for event logging and tracing.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/vsbackup/nf-vsbackup-ivssbackupcomponentsex3-getsessionid HRESULT
		// GetSessionId( [out] VSS_ID *idSession );
		Guid GetSessionId();

		/// <summary>The <c>GetSnapshotProperties</c> method gets the properties of the specified shadow copy.</summary>
		/// <param name="SnapshotId">The identifier of the shadow copy of a volume as returned by IVssBackupComponents::AddToSnapshotSet.</param>
		/// <returns>
		/// The address of a caller-allocated VSS_SNAPSHOT_PROP structure that receives the shadow copy properties. The software provider is
		/// responsible for setting the members of this structure. The software provider allocates memory for all string members that it
		/// sets in the structure. When the structure is no longer needed, the software provider is responsible for freeing these strings by
		/// calling the VssFreeSnapshotProperties function.
		/// </returns>
		/// <remarks>
		/// <para>
		/// The caller should set the contents of the VSS_SNAPSHOT_PROP structure to zero before calling the <c>GetSnapshotProperties</c> method.
		/// </para>
		/// <para>The provider is responsible for allocating and freeing the strings in the VSS_SNAPSHOT_PROP structure.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/vsbackup/nf-vsbackup-ivssbackupcomponents-getsnapshotproperties HRESULT
		// GetSnapshotProperties( [in] VSS_ID SnapshotId, [out] VSS_SNAPSHOT_PROP *pProp );
		VSS_SNAPSHOT_PROP GetSnapshotProperties(Guid SnapshotId);

		/// <summary>The <c>ImportSnapshots</c> method imports shadow copies transported from a different machine.</summary>
		/// <returns>An IVssAsync object containing the imported shadow copy status data.</returns>
		/// <remarks>
		/// <para>Only one shadow copy can be imported at a time.</para>
		/// <para>The requester is responsible for serializing the import shadow copy operation.</para>
		/// <para>The caller is responsible for releasing the IVssAsync interface.</para>
		/// <para>For more information on importing shadow copies, see Importing Transportable Shadow Copied Volumes.</para>
		/// <para>
		/// <c>Transportable shadow copies in a cluster:</c> For details about using transportable shadow copies in a cluster, see Fast
		/// Recovery Using Transportable Shadow Copied Volumes. The transportable shadow copy must be imported from outside the cluster as
		/// long as the original volume is mounted within the cluster.
		/// </para>
		/// <para>
		/// <c>Note</c> If the shadow copy import fails, the Volume Shadow Copy Service won't clean up LUNs on its own. The requester has to
		/// initiate the cleanup of LUNs.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/vsbackup/nf-vsbackup-ivssbackupcomponents-importsnapshots HRESULT
		// ImportSnapshots( [out] IVssAsync **ppAsync );
		IVssAsync ImportSnapshots();

		/// <summary>The <c>InitializeForBackup</c> method initializes the backup components metadata in preparation for backup.</summary>
		/// <param name="bstrXML">
		/// Optional. During imports of transported shadow copies, this parameter must be the original document generated when creating the
		/// saved shadow copy and saved using IVssBackupComponents::SaveAsXML.
		/// </param>
		/// <remarks>
		/// <para>
		/// The XML document supplied to this method initializes the IVssBackupComponents object with metadata previously stored by a call
		/// to IVssBackupComponents::SaveAsXML. Users should not tamper with this metadata document.
		/// </para>
		/// <para>
		/// For more information on how to use <c>InitializeForBackup</c> with transportable shadow copies, see Importing Transportable
		/// Shadow Copied Volumes.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/vsbackup/nf-vsbackup-ivssbackupcomponents-initializeforbackup HRESULT
		// InitializeForBackup( [in] BSTR bstrXML );
		void InitializeForBackup([Optional] string bstrXML);

		/// <summary>
		/// The <c>InitializeForRestore</c> method initializes the IVssBackupComponents interface in preparation for a restore operation.
		/// </summary>
		/// <param name="bstrXML">XML string containing the Backup Components Document generated by a backup operation and saved by IVssBackupComponents::SaveAsXML.</param>
		/// <remarks>
		/// The XML document supplied to this method initializes the IVssBackupComponents object with metadata previously stored by a call
		/// to IVssBackupComponents::SaveAsXML. Users should not tamper with this metadata document.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/vsbackup/nf-vsbackup-ivssbackupcomponents-initializeforrestore HRESULT
		// InitializeForRestore( [in] BSTR bstrXML );
		void InitializeForRestore([Optional] string bstrXML);

		/// <summary>
		/// The <c>IsVolumeSupported</c> method determines whether the specified provider supports shadow copies on the specified volume or
		/// remote file share.
		/// </summary>
		/// <param name="ProviderId">
		/// Provider identifier. If the value is Guid.Null, <c>IsVolumeSupported</c> checks whether any provider supports the volume or
		/// remote file share.
		/// </param>
		/// <param name="pwszVolumeName">
		/// <para>
		/// Volume name or UNC path of remote file share. The name or UNC path must be in one of the following formats and must include a
		/// trailing backslash (\):
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <term>The path of a mounted folder, for example, Y:\MountX\</term>
		/// </item>
		/// <item>
		/// <term>A drive letter, for example, D:\</term>
		/// </item>
		/// <item>
		/// <term>A volume GUID path of the form \\?\Volume{GUID}\ (where GUID identifies the volume)</term>
		/// </item>
		/// <item>
		/// <term>A UNC path that specifies a remote file share, for example, \\Clusterx\Share1\</term>
		/// </item>
		/// </list>
		/// </param>
		/// <returns>
		/// Address of a caller-allocated variable that receives <c>TRUE</c> if shadow copies are supported on the specified volume or
		/// remote file share, or <c>FALSE</c> otherwise.
		/// </returns>
		/// <remarks>
		/// <para>
		/// <c>Windows 7, Windows Server 2008 R2, Windows Vista, Windows Server 2008, Windows XP and Windows Server 2003:</c> Remote file
		/// shares are not supported until Windows 8 and Windows Server 2012.
		/// </para>
		/// <para>
		/// <c>IsVolumeSupported</c> will return <c>TRUE</c> if it is possible to create shadow copies on the given volume, even if the
		/// current configuration does not allow the creation of shadow copies on that volume at the present time.
		/// </para>
		/// <para>
		/// For example, if the maximum number of shadow copies has been reached on a given volume (and therefore no more shadow copies can
		/// be created on that volume), the method will still indicate that the volume can be shadow copied.
		/// </para>
		/// <para>
		/// <c>Note</c> For more information about the maximum number of shadow copies that can be created on a volume, see the entry for
		/// <c>MaxShadowCopies</c> in Registry Keys and Values for Backup and Restore.
		/// </para>
		/// <para>This method cannot be called for a virtual hard disk (VHD) that is nested inside another VHD.</para>
		/// <para><c>Windows Server 2008, Windows Vista, Windows Server 2003 and Windows XP:</c> VHDs are not supported.</para>
		/// </remarks>
		bool IsVolumeSupported(Guid ProviderId, string pwszVolumeName);

		/// <summary>
		/// The <c>PostRestore</c> method will cause VSS to generate a <c>PostRestore</c> event, signaling writers that the current restore
		/// operation has finished.
		/// </summary>
		/// <returns>An IVssAsync object that contains status data for the signaled event.</returns>
		/// <remarks>The caller is responsible for releasing the IVssAsync interface.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/vsbackup/nf-vsbackup-ivssbackupcomponents-postrestore HRESULT PostRestore(
		// [out] IVssAsync **ppAsync );
		IVssAsync PostRestore();

		/// <summary>
		/// <para>Not supported.</para>
		/// <para>This method is reserved for future use.</para>
		/// </summary>
		/// <param name="SnapshotSetID">This parameter is reserved for future use.</param>
		/// <param name="dwPreFastRecoveryFlags">This parameter is reserved for future use.</param>
		/// <returns>This parameter is reserved for future use.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/vsbackup/nf-vsbackup-ivssbackupcomponentsex2-prefastrecovery HRESULT
		// PreFastRecovery( VSS_ID SnapshotSetID, DWORD dwPreFastRecoveryFlags, IVssAsync **ppAsync );
		IVssAsync PreFastRecovery(Guid SnapshotSetID, [Optional] uint dwPreFastRecoveryFlags);

		/// <summary>
		/// The <c>PrepareForBackup</c> method will cause VSS to generate a PrepareForBackup event, signaling writers to prepare for an
		/// upcoming backup operation. This makes a requester's Backup Components Document available to writers.
		/// </summary>
		/// <returns>
		/// An instance of the IVssAsync interface that is used to determine when the asynchronous operation is complete.
		/// </returns>
		/// <remarks>
		/// <para>
		/// <c>PrepareForBackup</c> generates a PrepareForBackup event, which is handled by each instance of each writer through the
		/// CVssWriter::OnPrepareBackup method.
		/// </para>
		/// <para>Before <c>PrepareForBackup</c> can be called, IVssBackupComponents::SetBackupState must be called.</para>
		/// <para>
		/// The Backup Components Document can still be modified by writers in their <c>PrepareForBackup</c> event handler
		/// (CVssWriter::OnPrepareBackup), and afterward until the generation of a BackupComplete event.
		/// </para>
		/// <para>The caller is responsible for releasing the IVssAsync interface.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/vsbackup/nf-vsbackup-ivssbackupcomponents-prepareforbackup HRESULT
		// PrepareForBackup( [out] IVssAsync **ppAsync );
		IVssAsync PrepareForBackup();

		/// <summary>
		/// The <c>PreRestore</c> method will cause VSS to generate a PreRestore event, signaling writers to prepare for an upcoming restore operation.
		/// </summary>
		/// <returns>An IVssAsync object containing status data for the signaled event.</returns>
		/// <remarks>
		/// <para>The caller is responsible for releasing the IVssAsync interface pointer.</para>
		/// <para>
		/// Special consideration should be given to EFI systems when the requester has selected the Automated System Recovery (ASR) writer
		/// for restore. If you are restoring to a disk that contains the EFI partition, and one of the following conditions exists, you
		/// must first clean the disk by calling the IVdsAdvancedDisk::Clean method:
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <term>You are restoring to an EFI system disk whose partitioning has changed since the last ASR backup.</term>
		/// </item>
		/// <item>
		/// <term>You are restoring to a different physical drive than the one from which the backup was taken.</term>
		/// </item>
		/// </list>
		/// <para>Failure to perform this disk-cleaning step may result in unexpected results during PreRestore.</para>
		/// <para>For more information about the ASR writer, see In-Box VSS Writers.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/vsbackup/nf-vsbackup-ivssbackupcomponents-prerestore HRESULT PreRestore( [out]
		// IVssAsync **ppAsync );
		IVssAsync PreRestore();

		/// <summary>
		/// The <c>Query</c> method queries providers on the system and/or the completed shadow copies in the system that reside in the
		/// current context. The method can be called only during backup operations.
		/// </summary>
		/// <param name="QueriedObjectId">Reserved. The value of this parameter must be Guid.Null.</param>
		/// <param name="eQueriedObjectType">
		/// <para>
		/// Indicates restriction of the query to the given object type. A value of VSS_OBJECT_NONE indicates no restriction—that is, all
		/// objects will be queried.
		/// </para>
		/// <para>Currently, the value of this parameter must be <c>VSS_OBJECT_NONE</c>.</para>
		/// </param>
		/// <param name="eReturnedObjectsType">
		/// Object types to be returned. The value of this parameter must be either <c>VSS_OBJECT_SNAPSHOT</c> or <c>VSS_OBJECT_PROVIDER</c>.
		/// </param>
		/// <returns>An IVssEnumObject enumerator object.</returns>
		/// <remarks>
		/// <para>
		/// Because <c>Query</c> returns only information on completed shadow copies, the only shadow copy state it can disclose is VSS_SS_COMPLETED.
		/// </para>
		/// <para>
		/// The method may be called only during backup operations and must be preceded by calls to
		/// IVssBackupComponents::InitializeForBackup and IVssBackupComponents::SetContext.
		/// </para>
		/// <para>
		/// While <c>Query</c> can return information on all of the providers available on a system, it will return only information about
		/// shadow copies with the current context (set by IVssBackupComponents::SetContext). For instance, if the _VSS_SNAPSHOT_CONTEXT
		/// context is set to <c>VSS_CTX_BACKUP</c>, <c>Query</c> will not return information on a shadow copy created with a context of VSS_CTX_FILE_SHARE_BACKUP.
		/// </para>
		/// <para>
		/// While this method currently returns a lists of all available providers and/or all completed shadow copies, in the future,
		/// specialized queries may be supported: for instance, querying all shadow copies associated with a provider.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/vsbackup/nf-vsbackup-ivssbackupcomponents-query HRESULT Query( [in] VSS_ID
		// QueriedObjectId, [in] VSS_OBJECT_TYPE eQueriedObjectType, [in] VSS_OBJECT_TYPE eReturnedObjectsType, [out] IVssEnumObject
		// **ppEnum );
		IVssEnumObject Query(Guid QueriedObjectId, VSS_OBJECT_TYPE eQueriedObjectType, VSS_OBJECT_TYPE eReturnedObjectsType);

		/// <summary>
		/// The <c>QueryRevertStatus</c> method returns an IVssAsync interface pointer that can be used to determine the status of the
		/// revert operation.
		/// </summary>
		/// <param name="pwszVolume">
		/// <para>
		/// String containing the name of the volume. The name must be in one of the following formats and must include a trailing backslash (\):
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <term>The path of a mounted folder, for example, Y:\MountX\</term>
		/// </item>
		/// <item>
		/// <term>A drive letter, for example, D:\</term>
		/// </item>
		/// <item>
		/// <term>A volume GUID path of the form \\?\Volume{GUID}\ (where GUID identifies the volume)</term>
		/// </item>
		/// </list>
		/// </param>
		/// <returns>An IVssAsync interface pointer that can be used to retrieve the status of the revert process.</returns>
		/// <remarks>
		/// The revert operation will continue even if the computer is rebooted, and cannot be canceled or undone, except by restoring a
		/// backup created using another method. The QueryStatus method on the returned IVssAsync interface cannot return
		/// <c>VSS_S_ASYNC_CANCELLED</c> as the revert operation cannot be canceled after it has started.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/vsbackup/nf-vsbackup-ivssbackupcomponents-queryrevertstatus HRESULT
		// QueryRevertStatus( [in] VSS_PWSZ pwszVolume, [out] IVssAsync **ppAsync );
		IVssAsync QueryRevertStatus(string pwszVolume);

		/// <summary>Initiates a LUN resynchronization operation. This method is supported only on Windows server operating systems.</summary>
		/// <param name="dwFlags">A bitmask of VSS_RECOVERY_OPTIONS flags that specify how the resynchronization is to be performed.</param>
		/// <returns>
		/// A variable that receives an IVssAsync interface pointer that can be used to retrieve the status of the LUN resynchronization
		/// operation.
		/// </returns>
		/// <remarks>
		/// <para>
		/// At the end of the resynchronization operation, by default the newly resychronized LUN will have the same disk signature that the
		/// destination LUN had before the resynchronization.
		/// </para>
		/// <para>
		/// This method cannot be called in WinPE, and it cannot be called in Safe mode. Before calling this method, the caller must call
		/// IVssBackupComponents::InitializeForRestore to prepare for the resynchronization.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/vsbackup/nf-vsbackup-ivssbackupcomponentsex3-recoverset HRESULT RecoverSet(
		// [in] DWORD dwFlags, [out] IVssAsync **ppAsync );
		IVssAsync RecoverSet(VSS_RECOVERY_OPTIONS dwFlags);

		/// <summary>
		/// <para>
		/// The <c>RevertToSnapshot</c> method reverts a volume to a previous shadow copy. Only shadow copies created with persistent
		/// contexts ( <c>VSS_CTX_APP_ROLLBACK</c>, <c>VSS_CTX_CLIENT_ACCESSIBLE</c>, <c>VSS_CTX_CLIENT_ACCESSIBLE_WRITERS</c>, or
		/// <c>VSS_CTX_NAS_ROLLBACK</c>) are supported.
		/// </para>
		/// <para><c>Note</c> This method is only supported on Windows Server operating systems.</para>
		/// </summary>
		/// <param name="SnapshotId">VSS_ID of the shadow copy to revert.</param>
		/// <param name="bForceDismount">
		/// If this parameter is <c>TRUE</c>, the volume will be dismounted and reverted even if the volume is in use.
		/// </param>
		/// <remarks>
		/// This operation cannot be canceled, or undone once completed. If the computer is rebooted during the revert operation, the revert
		/// process will continue when the system is restarted.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/vsbackup/nf-vsbackup-ivssbackupcomponents-reverttosnapshot HRESULT
		// RevertToSnapshot( [in] VSS_ID SnapshotId, [in] BOOL bForceDismount );
		void RevertToSnapshot(Guid SnapshotId, bool bForceDismount);

		/// <summary>
		/// The <c>SaveAsXML</c> method saves the Backup Components Document containing a requester's state information to a specified
		/// string. This XML document, which contains the Backup Components Document, should always be securely saved as part of a backup operation.
		/// </summary>
		/// <returns>The Backup Components Document containing a requester's state information.</returns>
		/// <remarks>
		/// <para>
		/// For a typical backup operation, <c>SaveAsXML</c> should not be called until after both writers and the requester are finished
		/// modifying the Backup Components Document.
		/// </para>
		/// <para>
		/// Writers can continue to modify the Backup Components Document until their successful return from handling the PostSnapshot event
		/// (CVssWriter::OnPostSnapshot), or equivalently upon the completion of IVssBackupComponents::DoSnapshotSet.
		/// </para>
		/// <para>
		/// Requesters will need to continue to modify the Backup Components Document as the backup progresses. In particular, a requester
		/// will store a component-by-component record of the success or failure of the backup through calls to the
		/// IVssBackupComponents::SetBackupSucceeded method.
		/// </para>
		/// <para>
		/// Once the requester has finished modifying the Backup Components Document, the requester should use <c>SaveAsXML</c> to save a
		/// copy of the document to the backup media.
		/// </para>
		/// <para>
		/// A Backup Components Document can be saved at earlier points in the life cycle of a backup operation—for instance, to support the
		/// generation of transportable shadow copies to be handled on remote machines. (See Importing Transportable Shadow Copied Volumes
		/// for more information.)
		/// </para>
		/// <para>
		/// However, <c>SaveAsXML</c> should never be called prior to IVssBackupComponents::PrepareForBackup, because the Backup Components
		/// Document will not have been filled by the requester and the writers.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/vsbackup/nf-vsbackup-ivssbackupcomponents-saveasxml HRESULT SaveAsXML( [in]
		// BSTR *pbstrXML );
		string SaveAsXML();

		/// <summary>
		/// The <c>SetAdditionalRestores</c> method is used by a requester during incremental or differential restore operations to indicate
		/// to writers that a given component will require additional restore operations to completely retrieve it.
		/// </summary>
		/// <param name="writerId">Writer identifier.</param>
		/// <param name="ct">Type of the component. See VSS_COMPONENT_TYPE for the possible values.</param>
		/// <param name="wszLogicalPath">
		/// <para>String containing the logical path of the component to be added.</para>
		/// <para>For more information, see Logical Pathing of Components.</para>
		/// <para>
		/// The value of the string containing the logical path used here should be the same as was used when the component was added to the
		/// backup set using IVssBackupComponents::AddComponent.
		/// </para>
		/// <para>The logical path can be <see langword="null"/>.</para>
		/// <para>There are no restrictions on the characters that can appear in a non- <see langword="null"/> logical path.</para>
		/// </param>
		/// <param name="wszComponentName">
		/// <para>String containing the name of the component.</para>
		/// <para>
		/// The value of the string should not be <see langword="null"/>, and should contain the same component as was used when the
		/// component was added to the backup set using IVssBackupComponents::AddComponent.
		/// </para>
		/// </param>
		/// <param name="bAdditionalRestores">
		/// If the value of this parameter is <c>true</c>, additional restores of the component will follow this restore. If the value is
		/// <c>false</c>, additional restores of the component will not follow this restore.
		/// </param>
		/// <remarks>
		/// <para>
		/// The information provided by the <c>SetAdditionalRestores</c> method is typically used by writers that support an explicit
		/// recovery mechanism as part of their PostRestore event handler (CVssWriter::OnPostRestore)—for instance, the Exchange Server, and
		/// database applications such as SQL Server. For these applications, it is often not possible to perform additional differential,
		/// incremental, or log restores after such a recovery is performed.
		/// </para>
		/// <para>
		/// Therefore, if <c>SetAdditionalRestores</c> for a component is set to <c>true</c>, this means that such a writer should not
		/// execute its explicit recovery mechanism and should expect that additional differential, incremental, or log restores will be done.
		/// </para>
		/// <para>
		/// When <c>SetAdditionalRestores</c> on a component is set to <c>false</c>, then after the component is restored, the application
		/// can complete its recovery operation and be brought back online.
		/// </para>
		/// <para>This method must be called before IVssBackupComponents::PreRestore.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/vsbackup/nf-vsbackup-ivssbackupcomponents-setadditionalrestores HRESULT
		// SetAdditionalRestores( [in] VSS_ID writerId, [in] VSS_COMPONENT_TYPE ct, [in] LPCWSTR wszLogicalPath, [in] LPCWSTR
		// wszComponentName, [in] bool bAdditionalRestores );
		void SetAdditionalRestores(Guid writerId, VSS_COMPONENT_TYPE ct, [Optional] string wszLogicalPath,
			string wszComponentName, bool bAdditionalRestores);

		/// <summary>Marks the restore of a component as authoritative for a replicated data store.</summary>
		/// <param name="writerId">The globally unique identifier (GUID) of the writer class.</param>
		/// <param name="ct">The type of the component. See the VSS_COMPONENT_TYPE enumeration for the possible values.</param>
		/// <param name="wszLogicalPath">
		/// <para>A string containing the logical path of the component. For more information, see Logical Pathing of Components.</para>
		/// <para>
		/// The value of the string containing the logical path used here should be the same as the string that was used when the component
		/// was added.
		/// </para>
		/// <para>The logical path can be <see langword="null"/>.</para>
		/// <para>There are no restrictions on the characters that can appear in a non- <see langword="null"/> logical path.</para>
		/// </param>
		/// <param name="wszComponentName">
		/// <para>A string containing the name of the component.</para>
		/// <para>
		/// The string cannot be <see langword="null"/> and should contain the same component name as the string that was used when the
		/// component was added to the backup set using the IVssBackupComponents::AddComponent method.
		/// </para>
		/// </param>
		/// <param name="bAuth">
		/// <para>Set this variable to <c>true</c> to indicate that the restore of the component is authoritative, or <c>false</c> otherwise.</para>
		/// <para>The default value is <c>false</c>.</para>
		/// </param>
		/// <remarks>
		/// <para>The <c>SetAuthoritativeRestore</c> method can only be called during a restore operation.</para>
		/// <para>
		/// A writer indicates that it supports authoritative restore by setting the <c>VSS_BS_AUTHORITATIVE_RESTORE</c> flag in its backup
		/// schema mask.
		/// </para>
		/// <para>For more information, see Setting VSS Restore Options.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/vsbackup/nf-vsbackup-ivssbackupcomponentsex2-setauthoritativerestore HRESULT
		// SetAuthoritativeRestore( [in] VSS_ID writerId, [in] VSS_COMPONENT_TYPE ct, [in] LPCWSTR wszLogicalPath, [in] LPCWSTR
		// wszComponentName, [in] bool bAuth );
		void SetAuthoritativeRestore(Guid writerId, VSS_COMPONENT_TYPE ct, [Optional] string wszLogicalPath,
			string wszComponentName, bool bAuth);

		/// <summary>The <c>SetBackupOptions</c> method sets a string of private, or writer-dependent, backup parameters for a component.</summary>
		/// <param name="writerId">Writer identifier.</param>
		/// <param name="ct">Type of the component. See VSS_COMPONENT_TYPE for the possible values.</param>
		/// <param name="wszLogicalPath">
		/// <para>String containing the logical path of the component.</para>
		/// <para>For more information, see Logical Pathing of Components.</para>
		/// <para>
		/// The value of the string containing the logical path used here should be the same as was used when the component was added to the
		/// backup set using IVssBackupComponents::AddComponent.
		/// </para>
		/// <para>The logical path can be <see langword="null"/>.</para>
		/// <para>There are no restrictions on the characters that can appear in a non- <see langword="null"/> logical path.</para>
		/// </param>
		/// <param name="wszComponentName">
		/// <para>String containing the name of the component.</para>
		/// <para>
		/// The string containing the name cannot be <see langword="null"/> and should contain the same component name as was used when the
		/// component was added to the backup set using IVssBackupComponents::AddComponent.
		/// </para>
		/// </param>
		/// <param name="wszBackupOptions">String containing the backup parameters to be set.</param>
		/// <returns>
		/// <para>The following are the valid return codes for this method.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>Successfully set the backup options.</term>
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
		/// <term>VSS_E_BAD_STATE</term>
		/// <term>
		/// The backup components object is not initialized, this method has been called during a restore operation, or this method has not
		/// been called within the correct sequence.
		/// </term>
		/// </item>
		/// <item>
		/// <term>VSS_E_OBJECT_NOT_FOUND</term>
		/// <term>The backup component does not exist.</term>
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
		/// Unexpected error. The error code is logged in the error log file. For more information, see Event and Error Handling Under VSS.
		/// Windows Server 2008, Windows Vista, Windows Server 2003 and Windows XP: This value is not supported until Windows Server 2008 R2
		/// and Windows 7. E_UNEXPECTED is used instead.
		/// </term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The exact syntax and content of the backup options set by the wszBackupOptions parameter of the <c>SetBackupOptions</c> method
		/// will depend on the specific writer being contacted.
		/// </para>
		/// <para>This method must be called before IVssBackupComponents::PrepareForBackup.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/vsbackup/nf-vsbackup-ivssbackupcomponents-setbackupoptions HRESULT
		// SetBackupOptions( [in] VSS_ID writerId, [in] VSS_COMPONENT_TYPE ct, [in] LPCWSTR wszLogicalPath, [in] LPCWSTR wszComponentName,
		// [in] LPCWSTR wszBackupOptions );
		void SetBackupOptions(Guid writerId, VSS_COMPONENT_TYPE ct, [Optional] string wszLogicalPath,
			string wszComponentName, string wszBackupOptions);

		/// <summary>The <c>SetBackupState</c> method defines an overall configuration for a backup operation.</summary>
		/// <param name="bSelectComponents">
		/// <para>Indicates whether a backup or restore operation will be in component mode.</para>
		/// <para>
		/// Operation in component mode supports selectively backing up designated individual components (which can allow their exclusion),
		/// or only supports backing up all files and components on a volume.
		/// </para>
		/// <para>The Boolean is <c>true</c> if the operation will be conducted in component mode and <c>false</c> if not.</para>
		/// </param>
		/// <param name="bBackupBootableSystemState">Indicates whether a bootable system state backup is being performed.</param>
		/// <param name="backupType">A VSS_BACKUP_TYPE enumeration value indicating the type of backup to be performed.</param>
		/// <param name="bPartialFileSupport">
		/// Optional. If the value of this parameter is <c>true</c>, partial file support is enabled. The default value for this argument is <c>false</c>.
		/// </param>
		/// <remarks>Applications must call <c>SetBackupState</c> prior to calling IVssBackupComponents::PrepareForBackup.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/vsbackup/nf-vsbackup-ivssbackupcomponents-setbackupstate HRESULT
		// SetBackupState( [in] bool bSelectComponents, [in] bool bBackupBootableSystemState, [in] VSS_BACKUP_TYPE backupType, [in] bool
		// bPartialFileSupport );
		void SetBackupState(bool bSelectComponents, bool bBackupBootableSystemState, VSS_BACKUP_TYPE backupType, bool bPartialFileSupport = false);

		/// <summary>
		/// The <c>SetBackupSucceeded</c> method indicates whether the backup of the specified component of a specific writer was successful.
		/// </summary>
		/// <param name="instanceId">Globally unique identifier (GUID) of the writer instance.</param>
		/// <param name="writerId">Globally unique identifier (GUID) of the writer class.</param>
		/// <param name="ct">Type of the component. See VSS_COMPONENT_TYPE for the possible values.</param>
		/// <param name="wszLogicalPath">
		/// <para>String containing the logical path of the component.</para>
		/// <para>For more information, see Logical Pathing of Components.</para>
		/// <para>
		/// The value of the string containing the logical path used here should be the same as was used when the component was added to the
		/// backup set using IVssBackupComponents::AddComponent.
		/// </para>
		/// <para>The logical path can be <see langword="null"/>.</para>
		/// <para>There are no restrictions on the characters that can appear in a non- <see langword="null"/> logical path.</para>
		/// </param>
		/// <param name="wszComponentName">
		/// <para>String containing the name of the component.</para>
		/// <para>
		/// The string cannot be <see langword="null"/> and should contain the same component name as was used when the component was added
		/// to the backup set using IVssBackupComponents::AddComponent.
		/// </para>
		/// </param>
		/// <param name="bSucceded">Set this parameter to <c>true</c> if the component was successfully backed up, or <c>false</c> otherwise.</param>
		/// <remarks>
		/// <para>
		/// When working in component mode (when IVssBackupComponents::SetBackupState is called with its select components argument set to
		/// <c>true</c>), writers check the state of each components backup using IVssComponent::GetBackupSucceeded. Therefore, a
		/// well-behaved backup application (requester) must call <c>SetBackupSucceeded</c> after each component has been processed and
		/// prior to calling IVssBackupComponents::BackupComplete.
		/// </para>
		/// <para>
		/// Do not call this method if the call to IVssBackupComponents::DoSnapshotSet failed. For more information about how requesters use
		/// <c>DoSnapshotSet</c>, <c>SetBackupSucceeded</c>, and BackupComplete in a backup operation, see Overview of Pre-Backup Tasks and
		/// Overview of Actual Backup Of Files.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/vsbackup/nf-vsbackup-ivssbackupcomponents-setbackupsucceeded HRESULT
		// SetBackupSucceeded( [in] VSS_ID instanceId, [in] VSS_ID writerId, [in] VSS_COMPONENT_TYPE ct, [in] LPCWSTR wszLogicalPath, [in]
		// LPCWSTR wszComponentName, [in] bool bSucceded );
		void SetBackupSucceeded(Guid instanceId, Guid writerId, VSS_COMPONENT_TYPE ct, [Optional] string wszLogicalPath,
			string wszComponentName, bool bSucceded);

		/// <summary>The <c>SetContext</c> method sets the context for subsequent shadow copy-related operations.</summary>
		/// <param name="lContext">
		/// The context to be set. The context must be one of the supported values of _VSS_SNAPSHOT_CONTEXT or a supported bit mask (or
		/// bitwise OR) of _VSS_VOLUME_SNAPSHOT_ATTRIBUTES with a valid <c>_VSS_SNAPSHOT_CONTEXT</c>.
		/// </param>
		/// <remarks>
		/// <para>The default context for VSS shadow copies is VSS_CTX_BACKUP.</para>
		/// <para>
		/// <c>Windows XP:</c> The only supported context is the default context, VSS_CTX_BACKUP. Therefore, calling <c>SetContext</c> under
		/// Windows XP returns E_NOTIMPL.
		/// </para>
		/// <para><c>SetContext</c> can be called only once, and it must be called prior to calling most VSS functions.</para>
		/// <para>
		/// For details on how the context set by <c>IVssBackupComponents::SetContext</c> affects how a shadow copy is created and managed,
		/// see Implementation Details for Creating Shadow Copies.
		/// </para>
		/// <para>For a complete discussion of the permitted shadow copy contexts, see _VSS_SNAPSHOT_CONTEXT and _VSS_VOLUME_SNAPSHOT_ATTRIBUTES.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/vsbackup/nf-vsbackup-ivssbackupcomponents-setcontext HRESULT SetContext( [in]
		// LONG lContext );
		void SetContext(VSS_SNAPSHOT_CONTEXT lContext);

		/// <summary>The <c>SetFileRestoreStatus</c> method indicates whether some, all, or no files were successfully restored.</summary>
		/// <param name="writerId">Writer identifier.</param>
		/// <param name="ct">Type of the component. See VSS_COMPONENT_TYPE for the possible values.</param>
		/// <param name="wszLogicalPath">
		/// <para>String containing the logical path of the component.</para>
		/// <para>For more information, see Logical Pathing of Components.</para>
		/// <para>
		/// The value of the string containing the logical path used here should be the same as was used when the component was added to the
		/// backup set using IVssBackupComponents::AddComponent.
		/// </para>
		/// <para>The logical path can be <see langword="null"/>.</para>
		/// <para>There are no restrictions on the characters that can appear in a non- <see langword="null"/> logical path.</para>
		/// </param>
		/// <param name="wszComponentName">
		/// <para>String containing the name of the component.</para>
		/// <para>
		/// The string cannot be <see langword="null"/> and should contain the same component name as was used when the component was added
		/// to the backup set using IVssBackupComponents::AddComponent.
		/// </para>
		/// </param>
		/// <param name="status">
		/// If all of the files were restored, the value of this parameter is VSS_RS_ALL. If some of the files were restored, the value of
		/// this parameter is VSS_RS_FAILED. If none of the files were restored, the value of this parameter is VSS_RS_NONE.
		/// </param>
		/// <remarks>This method should be called between calls to IVssBackupComponents::PreRestore and IVssBackupComponents::PostRestore.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/vsbackup/nf-vsbackup-ivssbackupcomponents-setfilerestorestatus HRESULT
		// SetFileRestoreStatus( [in] VSS_ID writerId, [in] VSS_COMPONENT_TYPE ct, [in] LPCWSTR wszLogicalPath, [in] LPCWSTR
		// wszComponentName, [in] VSS_FILE_RESTORE_STATUS status );
		void SetFileRestoreStatus(Guid writerId, VSS_COMPONENT_TYPE ct, [Optional] string wszLogicalPath,
			string wszComponentName, VSS_FILE_RESTORE_STATUS status);

		/// <summary>
		/// <para>
		/// The <c>SetPreviousBackupStamp</c> method sets the backup stamp of an earlier backup operation, upon which a differential or
		/// incremental backup operation will be based.
		/// </para>
		/// <para>The method can be called only during a backup operation.</para>
		/// </summary>
		/// <param name="writerId">Writer identifier.</param>
		/// <param name="ct">Type of the component. See VSS_COMPONENT_TYPE for the possible values.</param>
		/// <param name="wszLogicalPath">
		/// <para>String containing the logical path of the component.</para>
		/// <para>For more information, see Logical Pathing of Components.</para>
		/// <para>
		/// The value of the string containing the logical path used here should be the same as was used when the component was added to the
		/// backup set using IVssBackupComponents::AddComponent.
		/// </para>
		/// <para>The logical path can be <see langword="null"/>.</para>
		/// </param>
		/// <param name="wszComponentName">
		/// <para>String containing the name of the component.</para>
		/// <para>
		/// The string cannot be <see langword="null"/> and should contain the same component name as was used when the component was added
		/// to the backup set using IVssBackupComponents::AddComponent.
		/// </para>
		/// </param>
		/// <param name="wszPreviousBackupStamp">The backup stamp to be set.</param>
		/// <remarks>
		/// <para>This method should be called before IVssBackupComponents::PrepareForBackup.</para>
		/// <para>Only requesters can call this method.</para>
		/// <para>
		/// The backup stamp set by <c>SetPreviousBackupStamp</c> applies to all files in the component and any nonselectable subcomponents
		/// it has.
		/// </para>
		/// <para>
		/// Requesters merely store the backup stamps in the Backup Components Document. They cannot make direct use of the backup stamps,
		/// do not know their format, and do not know how to generate them.
		/// </para>
		/// <para>
		/// Therefore, the value set with <c>SetPreviousBackupStamp</c> should either be retrieved from the stored Backup Components
		/// Document of an earlier backup operation (using IVssComponent::GetBackupStamp for the correct component), or from information
		/// stored by the requester into its own internal records.
		/// </para>
		/// <para>
		/// A writer will then obtain this value (using IVssComponent::GetPreviousBackupStamp) and using it will be able to mark the
		/// appropriate files for participation in an incremental or differential backup.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/vsbackup/nf-vsbackup-ivssbackupcomponents-setpreviousbackupstamp HRESULT
		// SetPreviousBackupStamp( [in] VSS_ID writerId, [in] VSS_COMPONENT_TYPE ct, [in] LPCWSTR wszLogicalPath, [in] LPCWSTR
		// wszComponentName, [in] LPCWSTR wszPreviousBackupStamp );
		void SetPreviousBackupStamp(Guid writerId, VSS_COMPONENT_TYPE ct, [Optional] string wszLogicalPath,
			string wszComponentName, string wszPreviousBackupStamp);

		/// <summary>
		/// The <c>SetRangesFilePath</c> method is used when a partial file operation requires a ranges file, and that file has been
		/// restored to a location other than its original one.
		/// </summary>
		/// <param name="writerId">
		/// Globally unique identifier (GUID) of the writer class containing the files involved in the partial file operation.
		/// </param>
		/// <param name="ct">Identifies the type of the component. Refer to VSS_COMPONENT_TYPE for possible return values.</param>
		/// <param name="wszLogicalPath">
		/// <para>String containing the logical path of the component containing the files that are participating in the partial file operation.</para>
		/// <para>For more information, see Logical Pathing of Components.</para>
		/// <para>
		/// The value of the string containing the logical path used here should be the same as was used when the component was added to the
		/// backup set using IVssBackupComponents::AddComponent.
		/// </para>
		/// <para>The logical path can be <see langword="null"/>.</para>
		/// <para>There are no restrictions on the characters that can appear in a non- <see langword="null"/> logical path.</para>
		/// </param>
		/// <param name="wszComponentName">
		/// <para>String containing the name of the component containing the files that are participating in the partial file operation.</para>
		/// <para>
		/// The string cannot be <see langword="null"/> and should contain the same component name as was used when the component was added
		/// to the backup set using IVssBackupComponents::AddComponent.
		/// </para>
		/// </param>
		/// <param name="iPartialFile">
		/// Index number of the partial file. The value of this parameter is an integer from 0 to n–1 inclusive, where n is the total number
		/// of partial files associated with a given component. The value of n is returned by IVssComponent::GetPartialFileCount.
		/// </param>
		/// <param name="wszRangesFile">String containing the fully qualified path of a ranges file.</param>
		/// <remarks>Calling <c>SetRangesFilePath</c> is not necessary if ranges files are restored in place.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/vsbackup/nf-vsbackup-ivssbackupcomponents-setrangesfilepath HRESULT
		// SetRangesFilePath( VSS_ID writerId, VSS_COMPONENT_TYPE ct, LPCWSTR wszLogicalPath, LPCWSTR wszComponentName, UINT iPartialFile,
		// LPCWSTR wszRangesFile );
		void SetRangesFilePath(Guid writerId, VSS_COMPONENT_TYPE ct, [Optional] string wszLogicalPath,
			string wszComponentName, uint iPartialFile, string wszRangesFile);

		/// <summary>Assigns a new logical name to a component that is being restored.</summary>
		/// <param name="writerId">The globally unique identifier (GUID) of the writer class.</param>
		/// <param name="ct">The type of the component. See the VSS_COMPONENT_TYPE enumeration for the possible values.</param>
		/// <param name="wszLogicalPath">
		/// <para>A string containing the logical path of the component. For more information, see Logical Pathing of Components.</para>
		/// <para>
		/// The value of the string containing the logical path used here should be the same as the string that was used when the component
		/// was added.
		/// </para>
		/// <para>The logical path can be <see langword="null"/>.</para>
		/// <para>There are no restrictions on the characters that can appear in a non- <see langword="null"/> logical path.</para>
		/// </param>
		/// <param name="wszComponentName">
		/// <para>A string containing the name of the component.</para>
		/// <para>
		/// The string cannot be <see langword="null"/> and should contain the same component name as was the component name that was used
		/// when the component was added to the backup set using the IVssBackupComponents::AddComponent method.
		/// </para>
		/// </param>
		/// <param name="wszRestoreName">A string containing the restore name to be set for the component.</param>
		/// <remarks>
		/// <para>The <c>SetRestoreName</c> method can only be called during a restore operation.</para>
		/// <para>
		/// A writer indicates that it supports this method by setting the <c>VSS_BS_RESTORE_RENAME</c> flag in its backup schema mask.
		/// </para>
		/// <para>For more information, see Setting VSS Restore Options.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/vsbackup/nf-vsbackup-ivssbackupcomponentsex2-setrestorename HRESULT
		// SetRestoreName( VSS_ID writerId, VSS_COMPONENT_TYPE ct, LPCWSTR wszLogicalPath, LPCWSTR wszComponentName, LPCWSTR wszRestoreName );
		void SetRestoreName(Guid writerId, VSS_COMPONENT_TYPE ct, [Optional] string wszLogicalPath,
			string wszComponentName, string wszRestoreName);

		/// <summary>
		/// The <c>SetRestoreOptions</c> method sets a string of private, or writer-dependent, restore parameters for a writer component.
		/// </summary>
		/// <param name="writerId">Writer identifier.</param>
		/// <param name="ct">Type of the component. See VSS_COMPONENT_TYPE for the possible values.</param>
		/// <param name="wszLogicalPath">
		/// <para>String containing the logical path of the component. For more information, see Logical Pathing of Components.</para>
		/// <para>
		/// The value of the string containing the logical path used here should be the same as was used when the component was added to the
		/// backup set using IVssBackupComponents::AddComponent.
		/// </para>
		/// <para>The logical path can be <see langword="null"/>.</para>
		/// <para>There are no restrictions on the characters that can appear in a non-NULL logical path.</para>
		/// </param>
		/// <param name="wszComponentName">
		/// <para>String containing the name of the component.</para>
		/// <para>
		/// The string cannot be <see langword="null"/> and should contain the same component name as was used when the component was added
		/// to the backup set using IVssBackupComponents::AddComponent.
		/// </para>
		/// </param>
		/// <param name="wszRestoreOptions">
		/// String containing the private string of restore parameters. For more information see Setting VSS Restore Options.
		/// </param>
		/// <remarks>
		/// <para>This method must be called before IVssBackupComponents::PreRestore.</para>
		/// <para>
		/// The exact syntax and content of the restore options set by the wszRestoreOptions parameter of the <c>SetRestoreOptions</c>
		/// method will depend on the specific writer being contacted.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/vsbackup/nf-vsbackup-ivssbackupcomponents-setrestoreoptions HRESULT
		// SetRestoreOptions( [in] VSS_ID writerId, [in] VSS_COMPONENT_TYPE ct, [in] LPCWSTR wszLogicalPath, [in] LPCWSTR wszComponentName,
		// [in] LPCWSTR wszRestoreOptions );
		void SetRestoreOptions(Guid writerId, VSS_COMPONENT_TYPE ct, [Optional] string wszLogicalPath,
			string wszComponentName, string wszRestoreOptions);

		/// <summary>The <c>SetRestoreState</c> method defines an overall configuration for a restore operation.</summary>
		/// <param name="restoreType">A VSS_RESTORE_TYPE enumeration value indicating the type of restore to be performed.</param>
		/// <remarks>
		/// <para>
		/// Typically, most restore operations will not need to override the default restore type (VSS_RTYPE_UNDEFINED). Writers should
		/// treat this restore type as if it were VSS_RTYPE_BY_COPY.
		/// </para>
		/// <para>If applications need to call <c>SetRestoreState</c>, it should be called prior to calling IVssBackupComponents::PreRestore.</para>
		/// <para>If <c>SetRestoreState</c> is not called prior to IVssBackupComponents::PreRestore, the default restore state () is used.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/vsbackup/nf-vsbackup-ivssbackupcomponents-setrestorestate HRESULT
		// SetRestoreState( [in] VSS_RESTORE_TYPE restoreType );
		void SetRestoreState(VSS_RESTORE_TYPE restoreType);

		/// <summary>
		/// Sets the roll-forward operation type for a component and specifies the restore point for a partial roll-forward operation.
		/// </summary>
		/// <param name="writerId">The globally unique identifier (GUID) of the writer class.</param>
		/// <param name="ct">The type of the component. See the VSS_COMPONENT_TYPE enumeration for the possible values.</param>
		/// <param name="wszLogicalPath">
		/// <para>A string containing the logical path of the component. For more information, see Logical Pathing of Components.</para>
		/// <para>
		/// The value of the string containing the logical path used here should be the same as the string that was used when the component
		/// was added.
		/// </para>
		/// <para>The logical path can be <see langword="null"/>.</para>
		/// <para>There are no restrictions on the characters that can appear in a non- <see langword="null"/> logical path.</para>
		/// </param>
		/// <param name="wszComponentName">
		/// <para>A string containing the name of the component.</para>
		/// <para>
		/// The string cannot be <see langword="null"/> and should contain the same component name as the string that was used when the
		/// component was added to the backup set using the IVssBackupComponents::AddComponent method.
		/// </para>
		/// </param>
		/// <param name="rollType">A VSS_ROLLFORWARD_TYPE enumeration value indicating the type of roll-forward operation to be performed.</param>
		/// <param name="wszRollForwardPoint">
		/// <para>A string specifying the roll-forward restore point.</para>
		/// <para>
		/// The format of this string is defined by the writer, and can be a timestamp, a log sequence number (LSN), or any marker defined
		/// by the writer.
		/// </para>
		/// </param>
		/// <remarks>
		/// <para>The <c>SetRollForward</c> method can only be called during a restore operation.</para>
		/// <para>
		/// A writer indicates that it supports this method by setting the <c>VSS_BS_ROLLFORWARD_RESTORE</c> flag in its backup schema mask.
		/// </para>
		/// <para>For more information, see Setting VSS Restore Options.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/vsbackup/nf-vsbackup-ivssbackupcomponentsex2-setrollforward HRESULT
		// SetRollForward( [in] VSS_ID writerId, [in] VSS_COMPONENT_TYPE ct, [in] LPCWSTR wszLogicalPath, [in] LPCWSTR wszComponentName,
		// [in] VSS_ROLLFORWARD_TYPE rollType, [in] LPCWSTR wszRollForwardPoint );
		void SetRollForward(Guid writerId, VSS_COMPONENT_TYPE ct, [Optional] string wszLogicalPath,
			string wszComponentName, VSS_ROLLFORWARD_TYPE rollType, string wszRollForwardPoint);

		/// <summary>The <c>SetSelectedForRestore</c> method indicates whether the specified selectable component is selected for restoration.</summary>
		/// <param name="writerId">Writer identifier.</param>
		/// <param name="ct">Type of the component. See VSS_COMPONENT_TYPE for the possible values.</param>
		/// <param name="wszLogicalPath">
		/// <para>String containing the logical path of the component. For more information, see Logical Pathing of Components.</para>
		/// <para>The value of the string containing the logical path used here should be the same as was used when the component was added.</para>
		/// <para>The logical path can be <see langword="null"/>.</para>
		/// <para>There are no restrictions on the characters that can appear in a non- <see langword="null"/> logical path.</para>
		/// </param>
		/// <param name="wszComponentName">
		/// <para>String containing the name of the component.</para>
		/// <para>
		/// The string cannot be <see langword="null"/> and should contain the same component name as was used when the component was added
		/// to the backup set using IVssBackupComponents::AddComponent.
		/// </para>
		/// </param>
		/// <param name="bSelectedForRestore">
		/// If the value of this parameter is <c>true</c>, the selected component has been selected for restoration. If the value is
		/// <c>false</c>, the selected component has not been selected for restoration.
		/// </param>
		/// <remarks>
		/// <para><c>SetSelectedForRestore</c> has meaning only for restores taking place in component mode.</para>
		/// <para>
		/// <c>SetSelectedForRestore</c> can only be called for components that were explicitly added to the backup document at backup time
		/// using IVssBackupComponents::AddComponent. Restoring a component that was implicitly selected for backup as part of a component
		/// set must be done by calling <c>SetSelectedForRestore</c> on the closest ancestor component that was added to the document. If
		/// only this component's data is to be restored, that should be accomplished through IVssBackupComponents::AddRestoreSubcomponent;
		/// this can only be done if the component is selectable for restore (see Working with Selectability and Logical Paths).
		/// </para>
		/// <para>This method must be called before IVssBackupComponents::PreRestore.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/vsbackup/nf-vsbackup-ivssbackupcomponents-setselectedforrestore HRESULT
		// SetSelectedForRestore( [in] VSS_ID writerId, [in] VSS_COMPONENT_TYPE ct, [in] LPCWSTR wszLogicalPath, [in] LPCWSTR
		// wszComponentName, [in] bool bSelectedForRestore );
		void SetSelectedForRestore(Guid writerId, VSS_COMPONENT_TYPE ct, [Optional] string wszLogicalPath,
			string wszComponentName, bool bSelectedForRestore);

		/// <summary>
		/// The <c>SetSelectedForRestoreEx</c> method indicates whether the specified selectable component is selected for restoration to a
		/// specified writer instance.
		/// </summary>
		/// <param name="writerId">Globally unique identifier (GUID) of the writer class.</param>
		/// <param name="ct">Type of the component. See VSS_COMPONENT_TYPE for the possible values.</param>
		/// <param name="wszLogicalPath">
		/// <para>String containing the logical path of the component. For more information, see Logical Pathing of Components.</para>
		/// <para>The value of the string containing the logical path used here should be the same as was used when the component was added.</para>
		/// <para>The logical path can be <see langword="null"/>.</para>
		/// <para>There are no restrictions on the characters that can appear in a non- <see langword="null"/> logical path.</para>
		/// </param>
		/// <param name="wszComponentName">
		/// <para>String containing the name of the component.</para>
		/// <para>
		/// The string cannot be <see langword="null"/> and should contain the same component name as was used when the component was added
		/// to the backup set using the IVssBackupComponents::AddComponent method.
		/// </para>
		/// </param>
		/// <param name="bSelectedForRestore">
		/// If the value of this parameter is <c>true</c>, the selected component has been selected for restoration. If the value is
		/// <c>false</c>, the selected component has not been selected for restoration.
		/// </param>
		/// <param name="instanceId">
		/// <para>GUID of the writer instance.</para>
		/// <para>The default value for this parameter is Guid.Null.</para>
		/// </param>
		/// <remarks>
		/// <para>
		/// <c>SetSelectedForRestoreEx</c>, which moves a component to a different writer instance, can be called only for a writer that
		/// supports running multiple writer instances with the same class ID and supports a requester moving a component to a different
		/// writer instance at restore time. To determine whether a writer provides this support, call the
		/// IVssExamineWriterMetadata::GetBackupSchema method.
		/// </para>
		/// <para><c>SetSelectedForRestoreEx</c> has meaning only for restores taking place in component mode.</para>
		/// <para>
		/// <c>SetSelectedForRestoreEx</c> can be called only for components that were explicitly added to the backup document at backup
		/// time using AddComponent. Restoring a component that was implicitly selected for backup as part of a component set must be done
		/// by calling <c>SetSelectedForRestoreEx</c> on the closest ancestor component that was added to the document. If only this
		/// component's data is to be restored, that should be accomplished through the IVssBackupComponents::AddRestoreSubcomponent method;
		/// this can be done only if the component is selectable for restore (see Working with Selectability and Logical Paths).
		/// </para>
		/// <para>This method must be called before the IVssBackupComponents::PreRestore method.</para>
		/// <para>
		/// The distinction between the instanceId and writerID parameters is necessary because it is possible that multiple instances of
		/// the same writer are running on the computer.
		/// </para>
		/// <para>
		/// If the value of the instanceId parameter is Guid.Null, this is equivalent to calling the
		/// IVssBackupComponents::SetSelectedForRestore method.
		/// </para>
		/// <para>
		/// The instanceId parameter is used to specify that the component is to be restored to a different writer instance. If the value of
		/// the instanceId parameter is not Guid.Null, it must match the instance ID of a writer instance with the same writer class ID
		/// specified in in the writerID parameter.
		/// </para>
		/// <para>
		/// A writer's class identifier, instance identifier, and instance name can be found by calling the
		/// IVssExamineWriterMetadataEx::GetIdentityEx method.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/vsbackup/nf-vsbackup-ivssbackupcomponentsex-setselectedforrestoreex HRESULT
		// SetSelectedForRestoreEx( VSS_ID writerId, VSS_COMPONENT_TYPE ct, LPCWSTR wszLogicalPath, LPCWSTR wszComponentName, bool
		// bSelectedForRestore, VSS_ID instanceId );
		void SetSelectedForRestoreEx(Guid writerId, VSS_COMPONENT_TYPE ct, [Optional] string wszLogicalPath,
			string wszComponentName, bool bSelectedForRestore, Guid instanceId = default);

		/// <summary>The <c>StartSnapshotSet</c> method creates a new, empty shadow copy set.</summary>
		/// <returns>The address of a caller-allocated variable that receives the shadow copy set identifier.</returns>
		/// <remarks>This method must be called before IVssBackupComponents::PrepareForBackup during backup operations.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/vsbackup/nf-vsbackup-ivssbackupcomponents-startsnapshotset HRESULT
		// StartSnapshotSet( [out] VSS_ID *pSnapshotSetId );
		Guid StartSnapshotSet();

		/// <summary>Unexposes a shadow copy either by deleting the file share or by removing the drive letter or mounted folder.</summary>
		/// <param name="snapshotId">
		/// The shadow copy identifier. The value of this identifier should be the same as the value that was used when the shadow copy was exposed.
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/vsbackup/nf-vsbackup-ivssbackupcomponentsex2-unexposesnapshot HRESULT
		// UnexposeSnapshot( [in] VSS_ID snapshotId );
		void UnexposeSnapshot(Guid snapshotId);
	}

	/// <summary>
	/// <para>
	/// The <c>IVssExamineWriterMetadata</c> interface allows a requester to examine the metadata of a specific writer instance. This
	/// metadata may come from a currently executing (live) writer, or it may have been stored as an XML document.
	/// </para>
	/// <para>An <c>IVssExamineWriterMetadata</c> interface to a live writer's metadata is obtained by a call to IVssBackupComponents::GetWriterMetadata.</para>
	/// <para>
	/// Metadata obtained from a stored XML document can be examined by an instance of <c>IVssExamineWriterMetadata</c> obtained by a call
	/// to CreateVssExamineWriterMetadata.
	/// </para>
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/vsbackup/nl-vsbackup-ivssexaminewritermetadata
	[PInvokeData("vsbackup.h", MSDNShortId = "NL:vsbackup.IVssExamineWriterMetadata")]
	public interface IVssExamineWriterMetadata
	{
		/// <summary>The <c>AlternateLocationMappings</c> property obtains alternate location mappings of a file set.</summary>
		/// <remarks>
		/// <para>
		/// The value returned by <c>IVssExamineWriterMetadata::GetAlternateLocationMapping</c> should not be confused with that returned by IVssComponent::GetAlternateLocationMapping.
		/// </para>
		/// <para>IVssComponent::GetAlternateLocationMapping is the alternate location to which a file was restored.</para>
		/// <para>
		/// <c>IVssExamineWriterMetadata::GetAlternateLocationMapping</c> is the alternate location mapping to which a file may be restored
		/// if necessary.
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
		/// <para>A file may be restored to an alternate location mapping if either of the following is true:</para>
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
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/vsbackup/nf-vsbackup-ivssexaminewritermetadata-getalternatelocationmapping
		// HRESULT GetAlternateLocationMapping( [in] UINT iMapping, [out] IVssWMFiledesc **ppFiledesc );
		IReadOnlyList<IVssWMFiledesc> AlternateLocationMappings { get; }

		/// <summary>
		/// The <c>BackupSchema</c> property is used by a requester to determine from the Writer Metadata Document the types of backup
		/// operations that a given writer can participate in.
		/// </summary>
		/// <returns>
		/// The types of backup operations that a given writer supports, expressed as a bit mask (or bitwise OR) of VSS_BACKUP_SCHEMA
		/// enumeration values.
		/// </returns>
		/// <remarks>
		/// <para>
		/// The default backup schema is VSS_BS_UNDEFINED: the writer supports only simple full backup and restoration of entire files (as
		/// defined by VSS_BT_FULL), there is no support for incremental or differential backups, and partial files are not supported.
		/// </para>
		/// <para>The writer calls IVssCreateWriterMetadata::SetBackupSchema to indicate its supported schema in its Writer Metadata Document.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/vsbackup/nf-vsbackup-ivssexaminewritermetadata-getbackupschema HRESULT
		// GetBackupSchema( DWORD *pdwSchemaMask );
		VSS_BACKUP_SCHEMA BackupSchema { get; }

		/// <summary>The <c>Components</c> property obtains the Writer Metadata Documents.</summary>
		/// <returns>List of IVssWMComponent objects containing the component information.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/vsbackup/nf-vsbackup-ivssexaminewritermetadata-getcomponent HRESULT
		// GetComponent( [in] UINT iComponent, [out] IVssWMComponent **ppComponent );
		IReadOnlyList<IVssWMComponent> Components { get; }

		/// <summary>The <c>ExcludeFiles</c> property obtains information about files that have been explicitly excluded from backup.</summary>
		/// <remarks>For more information on excluding files, see Exclude File List Specification.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/vsbackup/nf-vsbackup-ivssexaminewritermetadata-getexcludefile HRESULT
		// GetExcludeFile( [in] UINT iFile, [out] IVssWMFiledesc **ppFiledesc );
		IReadOnlyList<IVssWMFiledesc> ExcludeFiles { get; }

		/// <summary>Obtains information about file sets that have been explicitly excluded.</summary>
		/// <remarks>
		/// The <c>GetExcludeFromSnapshotFile</c> method is intended to report information about file sets excluded from a shadow copy.
		/// Requesters should not exclude files from backup based on the information returned by this method.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/vsbackup/nf-vsbackup-ivssexaminewritermetadataex2-getexcludefromsnapshotfile
		// HRESULT GetExcludeFromSnapshotFile( [in] UINT iFile, [out] IVssWMFiledesc **ppFiledesc );
		IReadOnlyList<IVssWMFiledesc> ExcludeFromSnapshotFiles { get; }

		/// <summary>Obtains the version information for a writer application.</summary>
		/// <value>The version of the writer application.</value>
		/// <remarks>
		/// The <c>GetVersion</c> method returns nonzero results only if the writer was initialized by calling the
		/// CVssWriterEx::InitializeEx method and explicit version information was specified. If the writer is initialized by calling the
		/// CVssWriter::Initialize method, or if no version information was specified in the call to the <c>CVssWriterEx::InitializeEx</c>
		/// method, the <c>GetVersion</c> method returns zero in the Major and Minor fields.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/vsbackup/nf-vsbackup-ivssexaminewritermetadataex2-getversion HRESULT
		// GetVersion( [out] DWORD *pdwMajorVersion, [out] DWORD *pdwMinorVersion );
		Version Version { get; }

		/// <summary>
		/// The <c>GetIdentityEx</c> method obtains the writer instance name and other basic information about a specific writer instance.
		/// </summary>
		/// <param name="pidInstance">Globally unique identifier (GUID) of the writer instance.</param>
		/// <param name="pidWriter">GUID of the writer class.</param>
		/// <param name="pbstrWriterName">A string specifying the name of the writer.</param>
		/// <param name="pbstrInstanceName">A string specifying the writer instance name.</param>
		/// <param name="pUsage">A VSS_USAGE_TYPE enumeration value indicating how the data managed by the writer is used on the host system.</param>
		/// <param name="pSource">A VSS_SOURCE_TYPE enumeration value indicating the type of data managed by the writer.</param>
		/// <remarks>
		/// <para>This method is identical to the IVssExamineWriterMetadata::GetIdentity method except for the pbstrInstanceName parameter.</para>
		/// <para>The pbstrInstanceName parameter is the writer instance name that was specified during writer initialization by CVssWriter::Initialize.</para>
		/// <para>
		/// The writer instance name is useful for writers that support running multiple writer instances with the same writer class ID on a
		/// single computer. The writer instance name can be used to identify the specific instance. Therefore, the writer must make the
		/// instance name unique within the writer class. Also, the writer instance name is expected to persist between backup and restore,
		/// and it is used by VSS to correctly restore multiple-instance writers.
		/// </para>
		/// <para>The caller must free the memory held by the pbstrWriterName and pbstrInstanceName parameters by calling SysFreeString.</para>
		/// <para>
		/// An IVssExamineWriterMetadataEx interface might be from stored writer state information (created by a call to
		/// CreateVssExamineWriterMetadata). If this is the case, then the following are true:
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <term>pidInstance may not mean anything in terms of live writers.</term>
		/// </item>
		/// <item>
		/// <term>If pidWriter does not match the writer class of any live writer, a requester should not use that writer's components.</term>
		/// </item>
		/// </list>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/vsbackup/nf-vsbackup-ivssexaminewritermetadataex-getidentityex HRESULT
		// GetIdentityEx( [out] VSS_ID *pidInstance, [out] VSS_ID *pidWriter, [out] BSTR *pbstrWriterName, [out] BSTR
		// *pbstrInstanceName, [out] VSS_USAGE_TYPE *pUsage, [out] VSS_SOURCE_TYPE *pSource );
		void GetIdentity(out Guid pidInstance, out Guid pidWriter, out string pbstrWriterName,
			out string pbstrInstanceName, out VSS_USAGE_TYPE pUsage, out VSS_SOURCE_TYPE pSource);

		/// <summary>The <c>GetRestoreMethod</c> method returns information about how a writer wants its data to be restored.</summary>
		/// <param name="pMethod">
		/// A VSS_RESTOREMETHOD_ENUM value that specifies file overwriting, the use of alternate locations specifying the method that will
		/// be used in the restore operation.
		/// </param>
		/// <param name="pbstrService">
		/// If the value of pMethod is VSS_RME_STOP_RESTORE_START or VSS_RME_RESTORE_STOP_START, a pointer to a string containing the name
		/// of the service that is started and stopped. Otherwise, the value is <see langword="null"/>.
		/// </param>
		/// <param name="pbstrUserProcedure">
		/// Pointer to the URL of an HTML or XML document describing to the user how the restore is to be performed. The value may be <see langword="null"/>.
		/// </param>
		/// <param name="pwriterRestore">
		/// A VSS_WRITERRESTORE_ENUM value specifying whether the writer will be involved in restoring its data.
		/// </param>
		/// <param name="pbRebootRequired">
		/// A Boolean value indicating whether a reboot will be required after the restore operation is complete. The value receives
		/// <c>true</c> if a reboot will be required, or <c>false</c> otherwise.
		/// </param>
		/// <param name="pcMappings">Pointer to the number of alternate mappings associated with the writer.</param>
		/// <remarks>
		/// <para>The caller must free the memory used by the pbstrUserProcedure and pbstrService parameters by calling SysFreeString.</para>
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
		/// <para>A file can be restored to an alternate location mapping if :</para>
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
		/// If the restore method is VSS_RME_STOP_RESTORE_START or VSS_RME_RESTORE_STOP_START, a requester uses the name returned by
		/// pbstrService to determine which service must be stopped during and then restarted after restore. See Stopping Services For
		/// Restore by Requesters for information on writer participation in stopping and restarting services during a restore operation.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/vsbackup/nf-vsbackup-ivssexaminewritermetadata-getrestoremethod HRESULT
		// GetRestoreMethod( [out] VSS_RESTOREMETHOD_ENUM *pMethod, [out] BSTR *pbstrService, [out] BSTR *pbstrUserProcedure, [out]
		// VSS_WRITERRESTORE_ENUM *pwriterRestore, [out] bool *pbRebootRequired, [out] UINT *pcMappings );
		void GetRestoreMethod(out VSS_RESTOREMETHOD_ENUM pMethod, out string pbstrService, out string pbstrUserProcedure,
			out VSS_WRITERRESTORE_ENUM pwriterRestore, out bool pbRebootRequired, out uint pcMappings);

		/// <summary>
		/// The <c>LoadFromXML</c> method loads an XML document that contains a writer's metadata document into an IVssExamineWriterMetadata interface.
		/// </summary>
		/// <param name="bstrXML">String that contains an XML document that represents a writer's metadata document.</param>
		/// <remarks>
		/// <para>
		/// This method is used at restore time to load writer metadata that was saved by IVssExamineWriterMetadata::SaveAsXML at the time
		/// of the backup operation.
		/// </para>
		/// <para>Users should not tamper with this metadata document.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/vsbackup/nf-vsbackup-ivssexaminewritermetadata-loadfromxml HRESULT
		// LoadFromXML( [in] BSTR bstrXML );
		void LoadFromXML(string bstrXML);

		/// <summary>
		/// The <c>SaveAsXML</c> method saves the Writer Metadata Document that contains a writer's state information to a specified string.
		/// This string can be saved as part of a backup operation.
		/// </summary>
		/// <returns>The Writer Metadata Document that contains a writer's state information.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/vsbackup/nf-vsbackup-ivssexaminewritermetadata-saveasxml HRESULT SaveAsXML(
		// [in] BSTR *pbstrXML );
		string SaveAsXML();
	}

	/// <summary>
	/// <para>The <c>IVssWMComponent</c> allows access to component information stored in a Writer Metadata Document.</para>
	/// <para>Instances of <c>IVssWMComponent</c> are obtained by calling IVssExamineWriterMetadata::GetComponent.</para>
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/vsbackup/nl-vsbackup-ivsswmcomponent
	[PInvokeData("vsbackup.h", MSDNShortId = "NL:vsbackup.IVssWMComponent")]
	public interface IVssWMComponent
	{
		/// <summary>
		/// The <c>DatabaseFiles</c> property obtains a list of IVssWMFiledesc objects containing information about the database backup
		/// component files.
		/// </summary>
		/// <returns>List of IVssWMFiledesc objects containing the returned file descriptor information.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/vsbackup/nf-vsbackup-ivsswmcomponent-getdatabasefile HRESULT GetDatabaseFile(
		// [in] UINT iDBFile, [out] IVssWMFiledesc **ppFiledesc );
		IReadOnlyList<IVssWMFiledesc> DatabaseFiles { get; }

		/// <summary>
		/// The <c>DatabaseLogFiles</c> property obtains file descriptors for the log file associated with the database backup component.
		/// </summary>
		/// <returns>List of IVssWMFiledesc objects containing the returned file descriptor information.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/vsbackup/nf-vsbackup-ivsswmcomponent-getdatabaselogfile HRESULT
		// GetDatabaseLogFile( [in] UINT iDbLogFile, [out] IVssWMFiledesc **ppFiledesc );
		IReadOnlyList<IVssWMFiledesc> DatabaseLogFiles { get; }

		/// <summary>
		/// The <c>Dependencies</c> property returns a list of IVssWMDependency interfaces containing accessors for obtaining information
		/// about explicit writer-component dependencies of the current components.
		/// </summary>
		/// <returns>List of IVssWMDependency interfaces.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/vsbackup/nf-vsbackup-ivsswmcomponent-getdependency HRESULT GetDependency( [in]
		// UINT iDependency, [out] IVssWMDependency **ppDependency );
		IReadOnlyList<IVssWMDependency> Dependencies { get; }

		/// <summary>The <c>Files</c> property obtains the file descriptors associated with the component.</summary>
		/// <returns>List of IVssWMFiledesc objects containing the returned file descriptor information.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/vsbackup/nf-vsbackup-ivsswmcomponent-getfile HRESULT GetFile( [in] UINT iFile,
		// [out] IVssWMFiledesc **ppFiledesc );
		IReadOnlyList<IVssWMFiledesc> Files { get; }

		/// <summary>The <c>GetComponentInfo</c> method obtains basic information about the specified writer metadata component.</summary>
		/// <returns>A <see cref="VSS_COMPONENTINFO"/> structure containing the returned component information.</returns>
		/// <remarks>The caller is responsible for freeing the returned VSS_COMPONENTINFO structure by calling IVssWMComponent::FreeComponentInfo.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/vsbackup/nf-vsbackup-ivsswmcomponent-getcomponentinfo HRESULT
		// GetComponentInfo( [out] PVSSCOMPONENTINFO *ppInfo );
		VSS_COMPONENTINFO GetComponentInfo();
	}

	/// <summary>
	/// <para>
	/// The <c>IVssWriterComponentsExt</c> interface is used by requesters to access and modify the components of a writer involved in a backup.
	/// </para>
	/// <para>
	/// <c>IVssWriterComponentsExt</c> is returned by IVssBackupComponents::GetWriterComponents and inherits from IVssWriterComponents and IUnknown.
	/// </para>
	/// <para>
	/// <c>Note</c> During the restore phase, the requester should call IVssWriterComponentsExt::GetComponent or
	/// IVssWriterComponentsExt::GetComponentCount only after the call to IVssBackupComponents::PreRestore has returned, to allow time for
	/// the writer to update the Backup Components Document. One example of such an update would be to change the restore target.
	/// </para>
	/// <para>Life cycle management of <c>IVssWriterComponentsExt</c> is handled through the inherited IUnknown methods.</para>
	/// <para><c>IVssWriterComponentsExt</c> does not define any methods.</para>
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/vsbackup/nl-vsbackup-ivsswritercomponentsext
	[PInvokeData("vsbackup.h", MSDNShortId = "NL:vsbackup.IVssWriterComponentsExt")]
	public interface IVssWriterComponentsExt : IVssWriterComponents
	{
	}

	/// <summary>
	/// The <c>VSS_COMPONENTINFO</c> structure contains information about a given component, and is returned to requesters by the
	/// IVssWMComponent interface.
	/// </summary>
	/// <remarks>
	/// <para>
	/// To obtain <c>VSS_COMPONENTINFO</c> object for a given component, a requester must first obtain the corresponding IVssWMComponent
	/// object through a call to IVssExamineWriterMetadata::GetComponent. A call to IVssWMComponent::GetComponentInfo then allocates and
	/// returns a <c>VSS_COMPONENTINFO</c> structure.
	/// </para>
	/// <para>
	/// Because <c>VSS_COMPONENTINFO</c> is allocated and returned by IVssWMComponent::GetComponentInfo, a requester should not free a
	/// <c>VSS_COMPONENTINFO</c> object directly, but should use IVssWMComponent::FreeComponentInfo.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/vsbackup/ns-vsbackup-vss_componentinfo typedef struct _VSS_COMPONENTINFO {
	// VSS_COMPONENT_TYPE type; BSTR bstrLogicalPath; BSTR bstrComponentName; BSTR bstrCaption; BYTE *pbIcon; UINT cbIcon; bool
	// bRestoreMetadata; bool bNotifyOnBackupComplete; bool bSelectable; bool bSelectableForRestore; DWORD dwComponentFlags; UINT
	// cFileCount; UINT cDatabases; UINT cLogFiles; UINT cDependencies; } VSS_COMPONENTINFO;
	[PInvokeData("vsbackup.h", MSDNShortId = "NS:vsbackup._VSS_COMPONENTINFO")]
	[StructLayout(LayoutKind.Sequential)]
	public struct VSS_COMPONENTINFO
	{
		/// <summary>Component type. See VSS_COMPONENT_TYPE.</summary>
		public VSS_COMPONENT_TYPE type;

		/// <summary>
		/// <para>A string containing the logical path of the component.</para>
		/// <para>A logical path can be <see langword="null"/>.</para>
		/// <para>There are no restrictions on the characters that can appear in a non- <see langword="null"/> logical path.</para>
		/// </summary>
		public string bstrLogicalPath;

		/// <summary>A string containing the name of the component. A component name string cannot be <see langword="null"/>.</summary>
		public string bstrComponentName;

		/// <summary>A string containing the description of the component. A caption string can be <see langword="null"/>.</summary>
		public string bstrCaption;

		/// <summary>
		/// <para>
		/// A buffer containing the binary data for a displayable icon representing the component. The buffer contents should use the same
		/// format as the standard icon(.ico) files. The size, in bytes, of the buffer is specified by <c>cbIcon</c>.
		/// </para>
		/// <para>If the writer that created the component did not choose to specify an icon, <c>pbIcon</c> is <see langword="null"/>.</para>
		/// </summary>
		public byte[] pbIcon;

		/// <summary>
		/// <para>
		/// Boolean that indicates whether there is private metadata associated with the restoration of the component. The Boolean is
		/// <c>true</c> if there is metadata and <c>false</c> if there is not.
		/// </para>
		/// <para>
		/// A writer indicates whether a component supports private metadata by setting this value when a component is added with
		/// IVssCreateWriterMetadata::AddComponent. Writers later add restore metadata with IVssComponent::SetRestoreMetadata. Requesters
		/// retrieve the information using IVssComponent::GetRestoreMetadata.
		/// </para>
		/// </summary>
		public bool bRestoreMetadata;

		/// <summary>Reserved for future use. The value of this parameter should always be set to <c>false</c>.</summary>
		public bool bNotifyOnBackupComplete;

		/// <summary>
		/// <para>
		/// Boolean that indicates(for component mode operations) if the component is selectable for backup. The value of <c>bSelectable</c>
		/// helps determine whether a requester has the option of including or excluding a given component in backup operations. The Boolean
		/// is <c>true</c> if the component is selectable for backup and <c>false</c> if it is not.
		/// </para>
		/// <para>
		/// There is no default value for a component's selectability for backup. A writer must always explicitly set the value when it adds
		/// the component to its Writer Metadata Document using IVssCreateWriterMetadata::AddComponent.
		/// </para>
		/// <para>
		/// In addition, the value of <c>bSelectable</c>, the component's logical path, and the component's relationship to other components
		/// as expressed in that path determine when and how a component is included in a backup operation:
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <term>
		/// For a nonselectable for backup component( <c>bSelectable</c> is <c>false</c>) with no selectable for backup ancestors in the
		/// hierarchy of its logical path, inclusion in the backup set is always mandatory and always implicit. A requester explicitly adds
		/// the component to the backup set in the Backup Components Document with IVssBackupComponents::AddComponent.
		/// </term>
		/// </item>
		/// <item>
		/// <term>
		/// For a selectable for backup component( <c>bSelectable</c> is <c>true</c>) with no selectable for backup ancestor in the
		/// hierarchy of its logical paths, inclusion in the backup set is always optional and always explicit. A requester explicitly adds
		/// the component to the backup set in the Backup Components Document with IVssBackupComponents::AddComponent.
		/// <para>
		/// If such a component is included as an ancestor in the logical path of other components, both those that are selectable for
		/// backup and those that are not, it defines a component set containing these other components as subcomponents. If a selectable
		/// for backup component is explicitly included in a backup, these subcomponents are implicitly included in the backup.
		/// </para>
		/// </term>
		/// </item>
		/// <item>
		/// <term>
		/// For a nonselectable for backup component( <c>bSelectable</c> is <c>false</c>) that has a selectable for backup ancestor in the
		/// hierarchy of its logical paths(and are therefore part of a component set defined by that ancestor), inclusion in the backup set
		/// is always implicit and contingent on the inclusion of a selectable for backup ancestor. A requester never explicitly adds the
		/// component to the backup set in the Backup Components Document; instead, it adds the selectable for backup ancestor to the
		/// document using IVssBackupComponents::AddComponent.
		/// </term>
		/// </item>
		/// <item>
		/// <term>
		/// For a selectable for backup component( <c>bSelectable</c> is <c>true</c>) that has a selectable for backup ancestor in the
		/// hierarchy of its logical paths(and is therefore part of a component set defined by that ancestor), inclusion in the backup set
		/// can be either optional and explicit, or if the component is not explicitly selected, its inclusion may be implicit and
		/// contingent on the inclusion of a selectable for backup ancestor. If the inclusion of the component is explicit, a requester
		/// explicitly adds the components to the backup set in the Backup Components Document with IVssBackupComponents::AddComponent.
		/// <para>If the inclusion is implicit, a requester does not add these components to a backup set in the Backup Components Document.</para>
		/// <para>
		/// If the inclusion of the component is explicit and the component defines a component set, the members of that component set are
		/// implicitly selected.
		/// </para>
		/// <para>
		/// A writer sets a component's selectability for backup( <c>bSelectable</c>) when adding the component to the Writer Metadata
		/// Document by using IVssCreateWriterMetadata::AddComponent.
		/// </para>
		/// <para>See Working with Selectability and Logical Paths for more information.</para>
		/// </term>
		/// </item>
		/// </list>
		/// </summary>
		public bool bSelectable;

		/// <summary>
		/// <para>
		/// Boolean that indicates(for component-mode operations) whether the component is selectable for restore.
		/// <c>bSelectableForRestore</c> allows the requester to determine whether this component can be individually selected for restore
		/// if it had earlier been implicitly included in the backup. The Boolean is <c>true</c> if the component is selectable for restore
		/// and <c>false</c> if it is not.
		/// </para>
		/// <para>
		/// By default, a component's selectability for restore is <c>false</c>. A writer can override this default when it adds the
		/// component to its Writer Metadata Document using IVssCreateWriterMetadata::AddComponent.
		/// </para>
		/// <para>
		/// If a component is explicitly added to the backup document(see explicit component inclusion), then it can always be individually
		/// selected for restore; so this flag then has no meaning. If a component is implicitly added to the backup document, then the
		/// <c>bSelectableForRestore</c> flag determines whether the component can be individually restored using IVssBackupComponents::AddRestoreSubcomponent.
		/// </para>
		/// <para>See Working with Selectability and Logical Paths for more information.</para>
		/// </summary>
		public bool bSelectableForRestore;

		/// <summary>
		/// <para>A bit mask(or bitwise OR) of values of the VSS_COMPONENT_FLAGS enumeration, indicating the features this component supports.</para>
		/// <para><c>Windows Server 2003 and Windows XP:</c> Before Windows Server 2003 with SP1, this member is reserved for system use.</para>
		/// </summary>
		public VSS_COMPONENT_FLAGS dwComponentFlags;

		/// <summary>
		/// If the component is a file group, the number of file descriptors for files in the group. Otherwise, this value is zero.
		/// </summary>
		public uint cFileCount;

		/// <summary>If the component is a database, the number of database file descriptors. Otherwise, this value is zero.</summary>
		public uint cDatabases;

		/// <summary>
		/// If the component is a database, the number of database log file descriptors. Otherwise, the value of this parameter is zero.
		/// </summary>
		public uint cLogFiles;

		/// <summary>
		/// The number of explicit writer-component dependencies of the current component. This value is incremented when
		/// IVssCreateWriterMetadata::AddComponentDependency is called by a writer.
		/// </summary>
		public uint cDependencies;
	}

	/// <summary>Status of a writer.</summary>
	public struct VssWriterStatus
	{
		/// <summary>
		/// The address of a variable that receives the application failure message that the writer passed for the wszApplicationMessage
		/// parameter of the SetWriterFailureEx method. This parameter is optional and can be NULL.
		/// </summary>
		public string pbstrApplicationMessage;

		/// <summary>The address of a caller-allocated variable that receives a string containing the name of the specified writer.</summary>
		public string pbstrWriter;

		/// <summary>
		/// The address of a caller-allocated variable that receives the return code that the writer passed for the hrApplication parameter
		/// of the CVssWriterEx2::SetWriterFailureEx method. This parameter is optional and can be NULL.
		/// </summary>
		public HRESULT phrApplication;

		/// <summary>
		/// <para>The address of a caller-allocated variable that receives the HRESULT failure code that was returned by the writer.</para>
		/// <para>The following are the supported values for pHrResultFailure.</para>
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
		/// restore sessions. Windows Vista, Windows Server 2003 and Windows XP: This value is not supported.
		/// </term>
		/// </item>
		/// </list>
		/// </summary>
		public HRESULT phResultFailure;

		/// <summary>The address of a caller-allocated variable that receives the instance identifier of the writer.</summary>
		public Guid pidInstance;

		/// <summary>The address of a caller-allocated variable that receives the identifier for the writer class.</summary>
		public Guid pidWriter;

		/// <summary>The address of a caller-allocated variable that receives a VSS_WRITER_STATE enumeration value.</summary>
		public VSS_WRITER_STATE pnStatus;
	}

	/// <summary>VSS information methods.</summary>
	public static class VssInfo
	{
		private const string Lib_VssApi = "vssapi.dll";

		/// <summary>
		/// <para>The <c>IsVolumeSnapshotted</c> function determines whether any shadow copies exist for the specified volume.</para>
		/// <para>
		/// <c>Note</c> This function is exported as <c>IsVolumeSnapshottedInternal</c>, but you should call <c>IsVolumeSnapshotted</c>, not <c>IsVolumeSnapshottedInternal</c>.
		/// </para>
		/// </summary>
		/// <param name="pwszVolumeName">
		/// <para>
		/// Name of the volume. The name of the volume to be checked must be in one of the following formats and must include a trailing backslash(\):
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <term>The path of a mounted folder, for example, Y:\MountX\</term>
		/// </item>
		/// <item>
		/// <term>A drive letter, for example, D:\</term>
		/// </item>
		/// <item>
		/// <term>A volume GUID path of the form \\?\Volume{GUID}\(where GUID identifies the volume)</term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="pbSnapshotsPresent">
		/// The value of this parameter is <c>TRUE</c> if the volume has a shadow copy, and <c>FALSE</c> if the volume does not have a
		/// shadow copy.
		/// </param>
		/// <param name="plSnapshotCapability">
		/// A bit mask(or bitwise OR) of VSS_SNAPSHOT_COMPATIBILITY values that indicates whether certain volume control or file I/O
		/// operations are disabled for the given volume if a shadow copy of it exists.
		/// </param>
		/// <returns>
		/// <para>
		/// The return values listed here are in addition to the normal COM <c>HRESULT</c> s that may be returned at any time from the function.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The function completed successfully.</term>
		/// </item>
		/// <item>
		/// <term>E_ACCESSDENIED</term>
		/// <term>The caller does not have sufficient backup privileges or is not an administrator.</term>
		/// </item>
		/// <item>
		/// <term>E_INVALIDARG</term>
		/// <term>One of the parameters is not valid.</term>
		/// </item>
		/// <item>
		/// <term>E_OUTOFMEMORY</term>
		/// <term>Out of memory or other system resources.</term>
		/// </item>
		/// <item>
		/// <term>VSS_E_PROVIDER_VETO</term>
		/// <term>
		/// Expected provider error. The provider logged the error in the event log. For more information, see Event and Error Handling
		/// Under VSS.
		/// </term>
		/// </item>
		/// <item>
		/// <term>VSS_E_OBJECT_NOT_FOUND</term>
		/// <term>The specified volume was not found.</term>
		/// </item>
		/// <item>
		/// <term>VSS_E_UNEXPECTED</term>
		/// <term>
		/// Unexpected error. The error code is logged in the error log file. For more information, see Event and Error Handling Under VSS.
		/// Windows Server 2008, Windows Vista, Windows Server 2003 and Windows XP: This value is not supported until Windows Server 2008 R2
		/// and Windows 7. E_UNEXPECTED is used instead.
		/// </term>
		/// </item>
		/// <item>
		/// <term>VSS_E_UNEXPECTED_PROVIDER_ERROR</term>
		/// <term>
		/// Unexpected provider error. The error code is logged in the event log file. For additional information, see Event and Error
		/// Handling Under VSS.
		/// </term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>Before calling this function, the caller must have initialized COM by calling the CoInitialize function.</para>
		/// <para>
		/// If no volume control or file I/O operations are disabled for the selected volume, then the shadow copy capability of the
		/// selected volume returned by plSnapshotCapability will be zero.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/vsbackup/nf-vsbackup-isvolumesnapshotted HRESULT IsVolumeSnapshotted( [in]
		// VSS_PWSZ pwszVolumeName, [out] BOOL *pbSnapshotsPresent, [out] LONG *plSnapshotCapability);
		[DllImport(Lib_VssApi, SetLastError = false, CharSet = CharSet.Unicode, EntryPoint = "IsVolumeSnapshottedInternal")]
		[PInvokeData("vsbackup.h", MSDNShortId = "NF:vsbackup.IsVolumeSnapshotted")]
		public static extern HRESULT IsVolumeSnapshotted(string pwszVolumeName, [MarshalAs(UnmanagedType.Bool)] out bool pbSnapshotsPresent,
			out VSS_SNAPSHOT_COMPATIBILITY plSnapshotCapability);

		/// <summary>Checks the registry for writers that should block revert operations on the specified volume.</summary>
		/// <param name="wszVolumeName">
		/// <para>The name of the volume. This name must be in one of the following formats and must include a trailing backslash(\):</para>
		/// <list type="bullet">
		/// <item>
		/// <term>The path of a mounted folder, for example, Y:\MountX\</term>
		/// </item>
		/// <item>
		/// <term>A drive letter, for example, D:\</term>
		/// </item>
		/// <item>
		/// <term>A volume GUID path of the form \\?\Volume{GUID}\(where GUID identifies the volume)</term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="pbBlock">
		/// A variable that receives <c>true</c> if the volume contains components from any writers that are listed in the registry as
		/// writers that should block revert operations, or <c>false</c> otherwise.
		/// </param>
		/// <returns>
		/// <para>This function can return one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The function succeeded.</term>
		/// </item>
		/// <item>
		/// <term>E_ACCESSDENIED</term>
		/// <term>The caller is not an administrator.</term>
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
		/// Unexpected error. The error code is logged in the error log file. For more information, see Event and Error Handling Under VSS.
		/// Windows Server 2008, Windows Vista, Windows Server 2003 and Windows XP: This value is not supported until Windows Server 2008 R2
		/// and Windows 7. E_UNEXPECTED is used instead.
		/// </term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>The list of writers that should block revert operations is stored in the registry under the following key:</para>
		/// <para><c>HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Services\VSS\Settings\WritersBlockingRevert</c></para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/vsbackup/nf-vsbackup-shouldblockrevert HRESULT ShouldBlockRevert( [in] LPCWSTR
		// wszVolumeName, [out] bool *pbBlock);
		[DllImport(Lib_VssApi, SetLastError = false, ExactSpelling = true, EntryPoint = "ShouldBlockRevertInternal")]
		[PInvokeData("vsbackup.h", MSDNShortId = "NF:vsbackup.ShouldBlockRevert")]
		public static extern HRESULT ShouldBlockRevert([MarshalAs(UnmanagedType.LPWStr)] string wszVolumeName, [MarshalAs(UnmanagedType.Bool)] out bool pbBlock);
	}
}