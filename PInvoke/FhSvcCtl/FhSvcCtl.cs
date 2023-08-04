using System;
using System.Runtime.InteropServices;

namespace Vanara.PInvoke;

/// <summary>Items from the FhSvcCtl.dll for File History.</summary>
public static partial class FhSvcCtl
{
	private const string Lib_FhSvcCtl = "fhsvcctl.dll";

	/// <summary>Specifies whether File History backups are enabled.</summary>
	/// <remarks>
	/// <para>
	/// The protection scope is the set of files and folders that are backed up by the File History feature. The default protection
	/// scope includes all folders from all user libraries and the Contacts, Desktop, and Favorites folders.
	/// </para>
	/// <para>
	/// The <c>FH_STATUS_DISABLED_BY_GP</c> status can be queried by calling the IFhConfigMgr::GetBackupStatus method, but it cannot be
	/// set by calling the IFhConfigMgr::SetBackupStatus method. This is because it can only be set by Group Policy.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/fhcfg/ne-fhcfg-fh_backup_status typedef enum _FH_BACKUP_STATUS {
	// FH_STATUS_DISABLED, FH_STATUS_DISABLED_BY_GP, FH_STATUS_ENABLED, FH_STATUS_REHYDRATING, MAX_BACKUP_STATUS } FH_BACKUP_STATUS;
	[PInvokeData("fhcfg.h", MSDNShortId = "NE:fhcfg._FH_BACKUP_STATUS")]
	public enum FH_BACKUP_STATUS
	{
		/// <summary>File History backups are not enabled by the user.</summary>
		FH_STATUS_DISABLED,

		/// <summary>File History backups are disabled by Group Policy.</summary>
		FH_STATUS_DISABLED_BY_GP,

		/// <summary>File History backups are enabled.</summary>
		FH_STATUS_ENABLED,

		/// <summary/>
		FH_STATUS_REHYDRATING,
	}

	/// <summary>Indicates whether the storage device or network share can be used as a File History backup target.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/fhcfg/ne-fhcfg-fh_device_validation_result typedef enum
	// _FH_DEVICE_VALIDATION_RESULT { FH_ACCESS_DENIED, FH_INVALID_DRIVE_TYPE, FH_READ_ONLY_PERMISSION, FH_CURRENT_DEFAULT,
	// FH_NAMESPACE_EXISTS, FH_TARGET_PART_OF_LIBRARY, FH_VALID_TARGET, MAX_VALIDATION_RESULT } FH_DEVICE_VALIDATION_RESULT, *PFH_DEVICE_VALIDATION_RESULT;
	[PInvokeData("fhcfg.h", MSDNShortId = "NE:fhcfg._FH_DEVICE_VALIDATION_RESULT")]
	public enum FH_DEVICE_VALIDATION_RESULT
	{
		/// <summary>The storage device or network share cannot be used as a backup target, because it is not accessible.</summary>
		FH_ACCESS_DENIED,

		/// <summary>
		/// The storage device or network share cannot be used as a backup target, because the drive type is not supported. For example,
		/// a CD or DVD cannot be used as a File History backup target.
		/// </summary>
		FH_INVALID_DRIVE_TYPE,

		/// <summary>The storage device or network share cannot be used as a backup target, because it is read-only.</summary>
		FH_READ_ONLY_PERMISSION,

		/// <summary>The storage device or network share is already being used as a backup target.</summary>
		FH_CURRENT_DEFAULT,

		/// <summary>
		/// The storage device or network share was previously used to back up files from a computer or user that has the same name as
		/// the current computer or user. It can be used as a backup target, but if it is used, the operating system will delete the
		/// previous backup.
		/// </summary>
		FH_NAMESPACE_EXISTS,

		/// <summary>
		/// The storage device or network share cannot be used as a backup target, because it is in the File History protection scope.
		/// </summary>
		FH_TARGET_PART_OF_LIBRARY,

		/// <summary>The storage device or network share can be used as a backup target.</summary>
		FH_VALID_TARGET,
	}

	/// <summary>
	/// Specifies the type of a local policy for the File History feature. Each local policy has a numeric parameter associated with it.
	/// </summary>
	/// <remarks>
	/// <para>To retrieve the value of the numeric parameter for a local policy, use the IFhConfigMgr::GetLocalPolicy method.</para>
	/// <para>To set the value of the numeric parameter for the local policy, use the IFhConfigMgr::SetLocalPolicy method.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/fhcfg/ne-fhcfg-fh_local_policy_type typedef enum _FH_LOCAL_POLICY_TYPE {
	// FH_FREQUENCY, FH_RETENTION_TYPE, FH_RETENTION_AGE, MAX_LOCAL_POLICY } FH_LOCAL_POLICY_TYPE, *PFH_LOCAL_POLICY_TYPE;
	[PInvokeData("fhcfg.h", MSDNShortId = "NE:fhcfg._FH_LOCAL_POLICY_TYPE")]
	public enum FH_LOCAL_POLICY_TYPE
	{
		/// <summary>
		/// This local policy specifies how frequently backups are to be performed for the current user. The numeric parameter contains
		/// the time, in seconds, from the end of one backup until the start of the next one. The default value of the numeric parameter
		/// for this policy is 3600 seconds (1 hour).
		/// </summary>
		FH_FREQUENCY,

		/// <summary>
		/// This local policy specifies when previous versions of files and folders can be deleted from a backup target. See the
		/// FH_RETENTION_TYPES enumeration for the list of possible values. The default value of the numeric parameter for this policy
		/// is FH_RETENTION_DISABLED.
		/// </summary>
		FH_RETENTION_TYPE,

		/// <summary>
		/// This local policy specifies the minimum age of previous versions that can be deleted from a backup target when the
		/// FH_RETENTION_AGE_BASED retention type is specified. For more information, see the FH_RETENTION_TYPES enumeration. The
		/// numeric parameter contains the minimum age, in days. The default value of the numeric parameter for this policy is 365 days
		/// (1 year).
		/// </summary>
		FH_RETENTION_AGE,
	}

	/// <summary>Specifies the type of an inclusion or exclusion list.</summary>
	/// <remarks>
	/// <para>
	/// To retrieve the inclusion and exclusion rules that are currently stored in an FhConfigMgr object, call the
	/// IFhConfigMgr::GetIncludeExcludeRules method.
	/// </para>
	/// <para>To add or remove an exclusion rule, call the IFhConfigMgr::AddRemoveExcludeRule method.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/fhcfg/ne-fhcfg-fh_protected_item_category typedef enum
	// _FH_PROTECTED_ITEM_CATEGORY { FH_FOLDER, FH_LIBRARY, MAX_PROTECTED_ITEM_CATEGORY } FH_PROTECTED_ITEM_CATEGORY, *PFH_PROTECTED_ITEM_CATEGORY;
	[PInvokeData("fhcfg.h", MSDNShortId = "NE:fhcfg._FH_PROTECTED_ITEM_CATEGORY")]
	public enum FH_PROTECTED_ITEM_CATEGORY
	{
		/// <summary>The inclusion or exclusion list is a list of folders.</summary>
		FH_FOLDER,

		/// <summary>The inclusion or exclusion list is a list of libraries.</summary>
		FH_LIBRARY,
	}

	/// <summary>Specifies under what conditions previous versions of files and folders can be deleted from a backup target.</summary>
	/// <remarks>
	/// <para>
	/// The operating system deletes previous versions from a backup target only when the target is full or when the user has initiated
	/// data retention manually by using the File History item in Control Panel.
	/// </para>
	/// <para>
	/// If <c>FH_RETENTION_AGE_BASED</c> is specified and the target is large enough, it is possible for the target to contain versions
	/// that are much older than the minimum age that is specified by the <c>FH_RETENTION_AGE</c> local policy.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/fhcfg/ne-fhcfg-fh_retention_types typedef enum _FH_RETENTION_TYPES {
	// FH_RETENTION_DISABLED, FH_RETENTION_UNLIMITED, FH_RETENTION_AGE_BASED, MAX_RETENTION_TYPE } FH_RETENTION_TYPES;
	[PInvokeData("fhcfg.h", MSDNShortId = "NE:fhcfg._FH_RETENTION_TYPES")]
	public enum FH_RETENTION_TYPES
	{
		/// <summary>Previous versions are never deleted from the backup target.</summary>
		FH_RETENTION_DISABLED,

		/// <summary>
		/// The operating system can delete any previous version on an as-needed basis, unless it is the most recent version of a file
		/// that currently exists and is within the protection scope.
		/// </summary>
		FH_RETENTION_UNLIMITED,

		/// <summary>
		/// The operating system can delete any previous version older than the specified minimum age on as-needed basis, unless it is
		/// the most recent version of a file that currently exists and is within the protection scope. The minimum age is specified by
		/// the FH_RETENTION_AGE local policy.
		/// </summary>
		FH_RETENTION_AGE_BASED,
	}

	/// <summary>The current File History protection state.</summary>
	[PInvokeData("fhstatus.h")]
	public enum FH_STATE
	{
		/// <summary>
		/// The File History protection state is unknown, because the File History service is not started or the current user is not
		/// tracked in it. This value cannot be ORed with FH_STATE_RUNNING (0x100).
		/// </summary>
		FH_STATE_NOT_TRACKED = 0x00,

		/// <summary>
		/// File History protection is not enabled for the current user. No files will be backed up. This value cannot be ORed with
		/// FH_STATE_RUNNING (0x100).
		/// </summary>
		FH_STATE_OFF = 0x01,

		/// <summary>
		/// File History protection is disabled by Group Policy. No files will be backed up. This value cannot be ORed with
		/// FH_STATE_RUNNING (0x100).
		/// </summary>
		FH_STATE_DISABLED_BY_GP = 0x02,

		/// <summary>
		/// There is a fatal error in one of the files that store internal File History information for the current user. No files will
		/// be backed up. This value cannot be ORed with FH_STATE_RUNNING (0x100).
		/// </summary>
		FH_STATE_FATAL_CONFIG_ERROR = 0x03,

		/// <summary>
		/// The current user does not have write permission for the currently assigned target. Backup copies of file versions will not
		/// be created. This value can be ORed with FH_STATE_RUNNING (0x100) to indicate that a backup cycle is being performed for the
		/// current user right now.
		/// </summary>
		FH_STATE_TARGET_ACCESS_DENIED = 0x0E,

		/// <summary>
		/// The currently assigned target has been marked as dirty. Backup copies of file versions will not be created until after the
		/// Chkdsk utility is run. This value can be ORed with FH_STATE_RUNNING (0x100) to indicate that a backup cycle is being
		/// performed for the current user right now.
		/// </summary>
		FH_STATE_TARGET_VOLUME_DIRTY = 0x0F,

		/// <summary>
		/// The currently assigned target does not have sufficient space for storing backup copies of files from the File History
		/// protection scope, and retention is already set to the most aggressive policy. File History will provide a degraded level of
		/// protection. This value can be ORed with FH_STATE_RUNNING (0x100) to indicate that a backup cycle is being performed for the
		/// current user right now.
		/// </summary>
		FH_STATE_TARGET_FULL_RETENTION_MAX = 0x10,

		/// <summary>
		/// The currently assigned target does not have sufficient space for storing backup copies of files from the File History
		/// protection scope. File History will provide a degraded level of protection. This value can be ORed with FH_STATE_RUNNING
		/// (0x100) to indicate that a backup cycle is being performed for the current user right now.
		/// </summary>
		FH_STATE_TARGET_FULL = 0x11,

		/// <summary>
		/// The File History cache on one of the local disks does not have sufficient space for storing backup copies of files from the
		/// File History protection scope temporarily. File History will provide a degraded level of protection. This value can be ORed
		/// with FH_STATE_RUNNING (0x100) to indicate that a backup cycle is being performed for the current user right now.
		/// </summary>
		FH_STATE_STAGING_FULL = 0x12,

		/// <summary>
		/// The currently assigned target is running low on free space, and retention is already set to the most aggressive policy. The
		/// level of File History protection is likely to degrade soon. This value can be ORed with FH_STATE_RUNNING (0x100) to indicate
		/// that a backup cycle is being performed for the current user right now.
		/// </summary>
		FH_STATE_TARGET_LOW_SPACE_RETENTION_MAX = 0x13,

		/// <summary>
		/// The currently assigned target is running low on free space. The level of File History protection is likely to degrade soon.
		/// This value can be ORed with FH_STATE_RUNNING (0x100) to indicate that a backup cycle is being performed for the current user
		/// right now.
		/// </summary>
		FH_STATE_TARGET_LOW_SPACE = 0x14,

		/// <summary>
		/// The currently assigned target has not been available for backups for a substantial period of time, causing File History
		/// level of protection to start degrading. This value can be ORed with FH_STATE_RUNNING (0x100) to indicate that a backup cycle
		/// is being performed for the current user right now.
		/// </summary>
		FH_STATE_TARGET_ABSENT = 0x15,

		/// <summary>
		/// Too many changes have been made in the protected files or the protection scope. File History level of protection is likely
		/// to degrade, unless the user explicitly initiates an immediate backup instead of relying on regular backup cycles to be
		/// performed in the background. This value can be ORed with FH_STATE_RUNNING (0x100) to indicate that a backup cycle is being
		/// performed for the current user right now.
		/// </summary>
		FH_STATE_TOO_MUCH_BEHIND = 0xF0,

		/// <summary>
		/// File History backups are performed regularly, no error conditions are detected, an optimal level of File History protection
		/// is provided. This value can be ORed with FH_STATE_RUNNING (0x100) to indicate that a backup cycle is being performed for the
		/// current user right now.
		/// </summary>
		FH_STATE_NO_ERROR = 0xFF,

		/// <summary>
		/// Indicates that File History is in a depreciated state where backup is not supported. This is only applicable if the user has
		/// an existing backup configured.
		/// </summary>
		FH_STATE_BACKUP_NOT_SUPPORTED = 0x810,

		/// <summary>File History backups are currently running.</summary>
		FH_STATE_RUNNING = 0x100
	}

	/// <summary>Specifies the type of a File History backup target.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/fhcfg/ne-fhcfg-fh_target_drive_types typedef enum _FH_TARGET_DRIVE_TYPES {
	// FH_DRIVE_UNKNOWN, FH_DRIVE_REMOVABLE, FH_DRIVE_FIXED, FH_DRIVE_REMOTE } FH_TARGET_DRIVE_TYPES;
	[PInvokeData("fhcfg.h", MSDNShortId = "NE:fhcfg._FH_TARGET_DRIVE_TYPES")]
	public enum FH_TARGET_DRIVE_TYPES
	{
		/// <summary>The type of the backup target is unknown.</summary>
		FH_DRIVE_UNKNOWN,

		/// <summary>The backup target is a locally attached removable storage device, such as a USB thumb drive.</summary>
		FH_DRIVE_REMOVABLE,

		/// <summary>The backup target is a locally attached nonremovable storage device, such as an internal hard drive.</summary>
		FH_DRIVE_FIXED,

		/// <summary>
		/// The backup target is a storage device that is accessible over network, such as a computer that is running Windows Home Server.
		/// </summary>
		FH_DRIVE_REMOTE,
	}

	/// <summary>Specifies the type of a property of a backup target.</summary>
	/// <remarks>
	/// <para>
	/// To query a backup target property, call the IFhTarget::GetStringProperty method or the IFhTarget::GetNumericalProperty method.
	/// </para>
	/// <para>
	/// For local disks, the <c>FH_TARGET_URL</c> property contains the drive letter. This path must end with a trailing backslash (for
	/// example, "X:").
	/// </para>
	/// <para>
	/// For network shares, the <c>FH_TARGET_URL</c> property contains the full path of the share. This path must end with a trailing
	/// backslash (for example, "\myserver\myshare").
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/fhcfg/ne-fhcfg-fh_target_property_type typedef enum _FH_TARGET_PROPERTY_TYPE {
	// FH_TARGET_NAME, FH_TARGET_URL, FH_TARGET_DRIVE_TYPE, MAX_TARGET_PROPERTY } FH_TARGET_PROPERTY_TYPE, *PFH_TARGET_PROPERTY_TYPE;
	[PInvokeData("fhcfg.h", MSDNShortId = "NE:fhcfg._FH_TARGET_PROPERTY_TYPE")]
	public enum FH_TARGET_PROPERTY_TYPE
	{
		/// <summary>
		/// The property is a string that contains the backup target’s friendly name. The friendly name is set during target
		/// provisioning by calling the IFhConfigMgr::ProvisionAndSetNewTarget method.
		/// </summary>
		FH_TARGET_NAME,

		/// <summary>The property is a string that contains a path to the backup target.</summary>
		FH_TARGET_URL,

		/// <summary>
		/// <para>
		/// The property is a numeric property that specifies the target type of the backup target. See the FH_TARGET_DRIVE_TYPES
		/// enumeration for the list of possible backup target types.
		/// </para>
		/// </summary>
		FH_TARGET_DRIVE_TYPE,
	}

	/// <summary>
	/// <para>
	/// The <c>IFhConfigMgr</c> interface allows client applications to read and modify the File History configuration for the user
	/// account under which the methods of this interface are called.
	/// </para>
	/// <note><c>IFhConfigMgr</c> is deprecated and may be altered or unavailable in future releases.</note>
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/fhcfg/nn-fhcfg-ifhconfigmgr
	[PInvokeData("fhcfg.h", MSDNShortId = "NN:fhcfg.IFhConfigMgr")]
	[ComImport, Guid("6A5FEA5B-BF8F-4EE5-B8C3-44D8A0D7331C"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown), CoClass(typeof(FhConfigMgr))]
	public interface IFhConfigMgr
	{
		/// <summary>
		/// <para>Loads the File History configuration information for the current user into an FhConfigMgr object.</para>
		/// <note><c>IFhConfigMgr</c> is deprecated and may be altered or unavailable in future releases.</note>
		/// </summary>
		/// <remarks>
		/// This method or the IFhConfigMgr::CreateDefaultConfiguration method must be called before any other IFhConfigMgr method can
		/// be called.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/fhcfg/nf-fhcfg-ifhconfigmgr-loadconfiguration HRESULT LoadConfiguration();
		void LoadConfiguration();

		/// <summary>
		/// <para>
		/// Creates File History configuration files with default settings for the current user and loads them into an FhConfigMgr object.
		/// </para>
		/// <note><c>IFhConfigMgr</c> is deprecated and may be altered or unavailable in future releases.</note>
		/// </summary>
		/// <param name="OverwriteIfExists">
		/// <para>
		/// If File History configuration files already exist for the current user and this parameter is set to <c>TRUE</c>, those files
		/// are overwritten and all previous settings and policies are reset to default values.
		/// </para>
		/// <para>
		/// If File History configuration files already exist for the current user and this parameter is set to <c>FALSE</c>, those
		/// files are not overwritten and an unsuccessful <c>HRESULT</c> value is returned.
		/// </para>
		/// </param>
		/// <remarks>This method or the LoadConfiguration method must be called before any other IFhConfigMgr method can be called.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/fhcfg/nf-fhcfg-ifhconfigmgr-createdefaultconfiguration HRESULT
		// CreateDefaultConfiguration( BOOL OverwriteIfExists );
		void CreateDefaultConfiguration([MarshalAs(UnmanagedType.Bool)] bool OverwriteIfExists);

		/// <summary>
		/// <para>
		/// Saves to disk all the changes that were made in an FhConfigMgr object since the last time that the LoadConfiguration,
		/// CreateDefaultConfiguration or <c>SaveConfiguration</c> method was called for the File History configuration files of the
		/// current user.
		/// </para>
		/// <note><c>IFhConfigMgr</c> is deprecated and may be altered or unavailable in future releases.</note>
		/// </summary>
		/// <remarks>This method can be called as many times as needed during the lifetime of an FhConfigMgr object.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/fhcfg/nf-fhcfg-ifhconfigmgr-saveconfiguration HRESULT SaveConfiguration();
		void SaveConfiguration();

		/// <summary>
		/// <para>Adds an exclusion rule to the exclusion list or removes a rule from the list.</para>
		/// <note><c>IFhConfigMgr</c> is deprecated and may be altered or unavailable in future releases.</note>
		/// </summary>
		/// <param name="Add">
		/// If this parameter is <c>TRUE</c>, a new exclusion rule is added. If it is set to <c>FALSE</c>, an existing exclusion rule is removed.
		/// </param>
		/// <param name="Category">
		/// Specifies the type of the exclusion rule. See the FH_PROTECTED_ITEM_CATEGORY enumeration for possible values.
		/// </param>
		/// <param name="Item">The folder path or library name or GUID of the item that the exclusion rule applies to.</param>
		/// <remarks>
		/// <para>
		/// The File History protection scope is the set of files that are backed up by the File History feature. It contains inclusion
		/// rules and exclusion rules. Inclusion rules specify the files and folders that are included. Exclusion rules specify the
		/// files and folders that are excluded.
		/// </para>
		/// <para>
		/// The default protection scope includes all folders from all user libraries and the Contacts, Desktop, and Favorites folders.
		/// </para>
		/// <para>
		/// Exclusion rules take precedence over inclusion rules. In other words, if an inclusion rule conflicts with an exclusion rule,
		/// the File History feature follows the exclusion rule.
		/// </para>
		/// <para>To reduce the protection scope, use the <c>IFhConfigMgr::AddRemoveExcludeRule</c> to add exclusion rules.</para>
		/// <para>This method can be used to add or remove exclusion rules. It cannot be used to modify inclusion rules.</para>
		/// <para>
		/// User libraries can be enumerated by calling the SHGetKnownFolderItem function and the methods of the IShellItem and
		/// IEnumShellItems interfaces.
		/// </para>
		/// <para>
		/// Standard folders and libraries are specified by a GUID, prefixed with an asterisk. For example,
		/// *a990ae9f-a03b-4e80-94bc-9912d7504104 specifies the Pictures library. For a list of standard folders and libraries and their
		/// GUIDs, see the KNOWNFOLDERID documentation.
		/// </para>
		/// <para>Custom libraries are specified by name. Folders are specified by their full path (for example, C:\Users\Public\Videos).</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/fhcfg/nf-fhcfg-ifhconfigmgr-addremoveexcluderule HRESULT
		// AddRemoveExcludeRule( BOOL Add, FH_PROTECTED_ITEM_CATEGORY Category, BSTR Item );
		void AddRemoveExcludeRule([MarshalAs(UnmanagedType.Bool)] bool Add, FH_PROTECTED_ITEM_CATEGORY Category, [MarshalAs(UnmanagedType.BStr)] string Item);

		/// <summary>
		/// <para>Retrieves the inclusion and exclusion rules that are currently stored in an FhConfigMgr object.</para>
		/// <note><c>IFhConfigMgr</c> is deprecated and may be altered or unavailable in future releases.</note>
		/// </summary>
		/// <param name="Include">
		/// If set to <c>TRUE</c>, inclusion rules are returned. If set to <c>FALSE</c>, exclusion rules are returned.
		/// </param>
		/// <param name="Category">
		/// An FH_PROTECTED_ITEM_CATEGORY enumeration value that specifies the type of the inclusion or exclusion rules.
		/// </param>
		/// <returns>Receives an IFhScopeIterator interface pointer that can be used to enumerate the rules in the requested category.</returns>
		/// <remarks>
		/// <para>
		/// The File History protection scope is the set of files that are backed up by this feature. It contains inclusion rules and
		/// exclusion rules. Inclusion rules specify the files and folders that are included. Exclusion rules specify the files and
		/// folders that are excluded.
		/// </para>
		/// <para>
		/// The default protection scope includes all folders from all user libraries and the Contacts, Desktop, and Favorites folders.
		/// </para>
		/// <para>
		/// You can modify the File History protection scope by adding exclusion rules to reduce the File History protection scope
		/// without removing folders from user libraries.
		/// </para>
		/// <para>
		/// Exclusion rules take precedence over inclusion rules. In other words, if an inclusion rule conflicts with an exclusion rule,
		/// the File History feature follows the exclusion rule.
		/// </para>
		/// <para>
		/// The IFhConfigMgr::AddRemoveExcludeRule method can be used to add or remove exclusion rules. It cannot be used to modify the
		/// inclusion rules.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/fhcfg/nf-fhcfg-ifhconfigmgr-getincludeexcluderules HRESULT
		// GetIncludeExcludeRules( BOOL Include, FH_PROTECTED_ITEM_CATEGORY Category, IFhScopeIterator **Iterator );
		IFhScopeIterator GetIncludeExcludeRules([MarshalAs(UnmanagedType.Bool)] bool Include, FH_PROTECTED_ITEM_CATEGORY Category);

		/// <summary>
		/// <para>Retrieves the numeric parameter for a local policy for the File History feature.</para>
		/// <note><c>IFhConfigMgr</c> is deprecated and may be altered or unavailable in future releases.</note>
		/// </summary>
		/// <param name="LocalPolicyType">Specifies the local policy.</param>
		/// <returns>Receives the value of the numeric parameter for the specified local policy.</returns>
		/// <remarks>
		/// <para>
		/// Each local policy contains a numeric parameter that specifies how or when the File History feature backs up files and
		/// folders. See the FH_LOCAL_POLICY_TYPE enumeration for more information about the local policies that can be specified.
		/// </para>
		/// <para>To set the numeric parameter value for a local policy, use the IFhConfigMgr::SetLocalPolicy method.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/fhcfg/nf-fhcfg-ifhconfigmgr-getlocalpolicy HRESULT GetLocalPolicy(
		// FH_LOCAL_POLICY_TYPE LocalPolicyType, ULONGLONG *PolicyValue );
		ulong GetLocalPolicy(FH_LOCAL_POLICY_TYPE LocalPolicyType);

		/// <summary>
		/// <para>Changes the numeric parameter value of a local policy in an FhConfigMgr object.</para>
		/// <note><c>IFhConfigMgr</c> is deprecated and may be altered or unavailable in future releases.</note>
		/// </summary>
		/// <param name="LocalPolicyType">Specifies the local policy.</param>
		/// <param name="PolicyValue">Specifies the new value of the numeric parameter for the specified local policy.</param>
		/// <remarks>
		/// <para>
		/// Each local policy contains a numeric parameter that specifies how or when the File History feature backs up files and
		/// folders. See the FH_LOCAL_POLICY_TYPE enumeration for more information about the local policies that can be specified.
		/// </para>
		/// <para>To retrieve the numeric parameter value for a local policy, use the IFhConfigMgr::GetLocalPolicy method.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/fhcfg/nf-fhcfg-ifhconfigmgr-setlocalpolicy HRESULT SetLocalPolicy(
		// FH_LOCAL_POLICY_TYPE LocalPolicyType, ULONGLONG PolicyValue );
		void SetLocalPolicy(FH_LOCAL_POLICY_TYPE LocalPolicyType, ulong PolicyValue);

		/// <summary>
		/// <para>Retrieves the backup status value for an FhConfigMgr object.</para>
		/// <note><c>IFhConfigMgr</c> is deprecated and may be altered or unavailable in future releases.</note>
		/// </summary>
		/// <returns>
		/// Receives the backup status value. See the FH_BACKUP_STATUS enumeration for the list of possible backup status values.
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/fhcfg/nf-fhcfg-ifhconfigmgr-getbackupstatus HRESULT GetBackupStatus(
		// FH_BACKUP_STATUS *BackupStatus );
		FH_BACKUP_STATUS GetBackupStatus();

		/// <summary>
		/// <para>Changes the backup status value for an FhConfigMgr object.</para>
		/// <note><c>IFhConfigMgr</c> is deprecated and may be altered or unavailable in future releases.</note>
		/// </summary>
		/// <param name="BackupStatus">
		/// The backup status value. See the FH_BACKUP_STATUS enumeration for a list of possible backup status values.
		/// </param>
		/// <returns>
		/// <c>S_OK</c> on success, or an unsuccessful <c>HRESULT</c> value on failure. Possible unsuccessful <c>HRESULT</c> values
		/// include values defined in the FhErrors.h header file.
		/// </returns>
		/// <remarks><c>FH_STATUS_DISABLED_BY_GP</c> is not a valid value for the BackupStatus parameter.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/fhcfg/nf-fhcfg-ifhconfigmgr-setbackupstatus HRESULT SetBackupStatus(
		// FH_BACKUP_STATUS BackupStatus );
		void SetBackupStatus(FH_BACKUP_STATUS BackupStatus);

		/// <summary>
		/// <para>
		/// Returns a pointer to an IFhTarget interface that can be used to query information about the currently assigned backup target.
		/// </para>
		/// <note><c>IFhConfigMgr</c> is deprecated and may be altered or unavailable in future releases.</note>
		/// </summary>
		/// <returns>
		/// Receives a pointer to the IFhTarget interface of an object that represents the currently assigned default target, or
		/// <c>NULL</c> if there is no default target.
		/// </returns>
		/// <remarks>
		/// If no backup target is currently assigned, this method returns
		/// <code>HRESULT_FROM_WIN32(ERROR_NOT_FOUND)</code>
		/// .
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/fhcfg/nf-fhcfg-ifhconfigmgr-getdefaulttarget HRESULT GetDefaultTarget(
		// IFhTarget **DefaultTarget );
		IFhTarget GetDefaultTarget();

		/// <summary>
		/// <para>Checks whether a certain storage device or network share can be used as a File History backup target.</para>
		/// <note><c>IFhConfigMgr</c> is deprecated and may be altered or unavailable in future releases.</note>
		/// </summary>
		/// <param name="TargetUrl">The storage device or network share to be validated.</param>
		/// <returns>
		/// Receives the result of the device validation. See the FH_DEVICE_VALIDATION_RESULT enumeration for the list of possible
		/// device validation result values.
		/// </returns>
		/// <remarks>
		/// <para>
		/// For local disks, the TargetUrl parameter contains the drive letter. This path must end with a trailing backslash (for
		/// example, "X:").
		/// </para>
		/// <para>
		/// For network shares, the TargetUrl parameter contains the full path of the share. This path must end with a trailing
		/// backslash (for example, "\myserver\myshare").
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/fhcfg/nf-fhcfg-ifhconfigmgr-validatetarget HRESULT ValidateTarget( BSTR
		// TargetUrl, PFH_DEVICE_VALIDATION_RESULT ValidationResult );
		FH_DEVICE_VALIDATION_RESULT ValidateTarget([MarshalAs(UnmanagedType.BStr)] string TargetUrl);

		/// <summary>
		/// <para>
		/// Provisions a certain storage device or network share as a File History backup target and assigns it as the default backup
		/// target for the current user.
		/// </para>
		/// <note><c>IFhConfigMgr</c> is deprecated and may be altered or unavailable in future releases.</note>
		/// </summary>
		/// <param name="TargetUrl">Specifies the storage device or network share to be provisioned and assigned as the default.</param>
		/// <param name="TargetName">Specifies a user-friendly name for the specified backup target.</param>
		/// <remarks>
		/// <para>
		/// For local disks, the TargetUrl parameter contains the drive letter. This path must end with a trailing backslash (for
		/// example, "X:").
		/// </para>
		/// <para>
		/// For network shares, the TargetUrl parameter contains the full path of the share. This path must end with a trailing
		/// backslash (for example, "\myserver\myshare").
		/// </para>
		/// <para>
		/// It is highly recommended that the storage device or network share specified by the TargetUrl parameter be validated first
		/// using the IFhConfigMgr::ValidateTarget method. If <c>ValidateTarget</c> returns a validation result other than
		/// <c>FH_VALID_TARGET</c>, assigning this storage device or network share as the default backup target may have unpredictable consequences.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/fhcfg/nf-fhcfg-ifhconfigmgr-provisionandsetnewtarget HRESULT
		// ProvisionAndSetNewTarget( BSTR TargetUrl, BSTR TargetName );
		void ProvisionAndSetNewTarget([MarshalAs(UnmanagedType.BStr)] string TargetUrl, [MarshalAs(UnmanagedType.BStr)] string TargetName);

		/// <summary>
		/// <para>
		/// Causes the currently assigned backup target to be recommended or not recommended to other members of the home group that the
		/// computer belongs to.
		/// </para>
		/// <note><c>IFhConfigMgr</c> is deprecated and may be altered or unavailable in future releases.</note>
		/// </summary>
		/// <param name="Recommend">
		/// If set to <c>TRUE</c>, the currently assigned backup target is recommended to other members of the home group. If set to
		/// <c>FALSE</c> and the currently assigned backup target is currently recommended to other members of the home group, this
		/// recommendation is withdrawn.
		/// </param>
		/// <remarks>
		/// <para>
		/// When a backup target is recommended to other computers in the home group, users on those computers see that storage device
		/// in the list of available backup targets in the File History item in Control Panel.
		/// </para>
		/// <para>
		/// If the backup target is not recommended to other computers in the home group, or if the recommendation is withdrawn, the
		/// target does not appear in the list of available backup targets on the other computers.
		/// </para>
		/// <para>
		/// A backup target cannot be recommended or not recommended on a computer that is joined to a domain or on a computer that is
		/// having ARM architecture.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/fhcfg/nf-fhcfg-ifhconfigmgr-changedefaulttargetrecommendation HRESULT
		// ChangeDefaultTargetRecommendation( BOOL Recommend );
		void ChangeDefaultTargetRecommendation([MarshalAs(UnmanagedType.Bool)] bool Recommend);

		/// <summary>
		/// <para>Retrieves the current File History protection state.</para>
		/// <note><c>IFhConfigMgr</c> is deprecated and may be altered or unavailable in future releases.</note>
		/// </summary>
		/// <param name="ProtectionState">
		/// <para>
		/// On return, this parameter receives the current File History protection state. The following protection states are defined in
		/// the FhStatus.h header file.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>FH_STATE_NOT_TRACKED 0x00</term>
		/// <term>
		/// The File History protection state is unknown, because the File History service is not started or the current user is not
		/// tracked in it. This value cannot be ORed with FH_STATE_RUNNING (0x100).
		/// </term>
		/// </item>
		/// <item>
		/// <term>FH_STATE_OFF 0x01</term>
		/// <term>
		/// File History protection is not enabled for the current user. No files will be backed up. This value cannot be ORed with
		/// FH_STATE_RUNNING (0x100).
		/// </term>
		/// </item>
		/// <item>
		/// <term>FH_STATE_DISABLED_BY_GP 0x02</term>
		/// <term>
		/// File History protection is disabled by Group Policy. No files will be backed up. This value cannot be ORed with
		/// FH_STATE_RUNNING (0x100).
		/// </term>
		/// </item>
		/// <item>
		/// <term>FH_STATE_FATAL_CONFIG_ERROR 0x03</term>
		/// <term>
		/// There is a fatal error in one of the files that store internal File History information for the current user. No files will
		/// be backed up. This value cannot be ORed with FH_STATE_RUNNING (0x100).
		/// </term>
		/// </item>
		/// <item>
		/// <term>FH_STATE_TARGET_ACCESS_DENIED 0x0E</term>
		/// <term>
		/// The current user does not have write permission for the currently assigned target. Backup copies of file versions will not
		/// be created. This value can be ORed with FH_STATE_RUNNING (0x100) to indicate that a backup cycle is being performed for the
		/// current user right now.
		/// </term>
		/// </item>
		/// <item>
		/// <term>FH_STATE_TARGET_VOLUME_DIRTY 0x0F</term>
		/// <term>
		/// The currently assigned target has been marked as dirty. Backup copies of file versions will not be created until after the
		/// Chkdsk utility is run. This value can be ORed with FH_STATE_RUNNING (0x100) to indicate that a backup cycle is being
		/// performed for the current user right now.
		/// </term>
		/// </item>
		/// <item>
		/// <term>FH_STATE_TARGET_FULL_RETENTION_MAX 0x10</term>
		/// <term>
		/// The currently assigned target does not have sufficient space for storing backup copies of files from the File History
		/// protection scope, and retention is already set to the most aggressive policy. File History will provide a degraded level of
		/// protection. This value can be ORed with FH_STATE_RUNNING (0x100) to indicate that a backup cycle is being performed for the
		/// current user right now.
		/// </term>
		/// </item>
		/// <item>
		/// <term>FH_STATE_TARGET_FULL 0x11</term>
		/// <term>
		/// The currently assigned target does not have sufficient space for storing backup copies of files from the File History
		/// protection scope. File History will provide a degraded level of protection. This value can be ORed with FH_STATE_RUNNING
		/// (0x100) to indicate that a backup cycle is being performed for the current user right now.
		/// </term>
		/// </item>
		/// <item>
		/// <term>FH_STATE_STAGING_FULL 0x12</term>
		/// <term>
		/// The File History cache on one of the local disks does not have sufficient space for storing backup copies of files from the
		/// File History protection scope temporarily. File History will provide a degraded level of protection. This value can be ORed
		/// with FH_STATE_RUNNING (0x100) to indicate that a backup cycle is being performed for the current user right now.
		/// </term>
		/// </item>
		/// <item>
		/// <term>FH_STATE_TARGET_LOW_SPACE_RETENTION_MAX 0x13</term>
		/// <term>
		/// The currently assigned target is running low on free space, and retention is already set to the most aggressive policy. The
		/// level of File History protection is likely to degrade soon. This value can be ORed with FH_STATE_RUNNING (0x100) to indicate
		/// that a backup cycle is being performed for the current user right now.
		/// </term>
		/// </item>
		/// <item>
		/// <term>FH_STATE_TARGET_LOW_SPACE 0x14</term>
		/// <term>
		/// The currently assigned target is running low on free space. The level of File History protection is likely to degrade soon.
		/// This value can be ORed with FH_STATE_RUNNING (0x100) to indicate that a backup cycle is being performed for the current user
		/// right now.
		/// </term>
		/// </item>
		/// <item>
		/// <term>FH_STATE_TARGET_ABSENT 0x15</term>
		/// <term>
		/// The currently assigned target has not been available for backups for a substantial period of time, causing File History
		/// level of protection to start degrading. This value can be ORed with FH_STATE_RUNNING (0x100) to indicate that a backup cycle
		/// is being performed for the current user right now.
		/// </term>
		/// </item>
		/// <item>
		/// <term>FH_STATE_TOO_MUCH_BEHIND 0x16</term>
		/// <term>
		/// Too many changes have been made in the protected files or the protection scope. File History level of protection is likely
		/// to degrade, unless the user explicitly initiates an immediate backup instead of relying on regular backup cycles to be
		/// performed in the background. This value can be ORed with FH_STATE_RUNNING (0x100) to indicate that a backup cycle is being
		/// performed for the current user right now.
		/// </term>
		/// </item>
		/// <item>
		/// <term>FH_STATE_NO_ERROR 0xFF</term>
		/// <term>
		/// File History backups are performed regularly, no error conditions are detected, an optimal level of File History protection
		/// is provided. This value can be ORed with FH_STATE_RUNNING (0x100) to indicate that a backup cycle is being performed for the
		/// current user right now.
		/// </term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="ProtectedUntilTime">
		/// <para>
		/// Receives a pointer to a string allocated with SysAllocString containing the date and time until which all files within the
		/// File History protection scope are protected. The date and time are formatted per the system locale. If the date and time are
		/// unknown, an empty string is returned.
		/// </para>
		/// <para>A file is considered protected until a certain point in time if one of the following conditions is true:</para>
		/// <list type="bullet">
		/// <item>
		/// <term>
		/// There is a version of that file that was captured at or after that point in time and was fully copied to the currently
		/// assigned backup target before now.
		/// </term>
		/// </item>
		/// <item>
		/// <term>The file was created or included in the File History protection scope at or after that point in time.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <remarks>
		/// <para>The caller is responsible for releasing the memory allocated for ProtectedUntilTime by calling SysFreeString on it.</para>
		/// <para>
		/// The protection state indicates the File History operational state and the date and time until which all files within the
		/// protection scope are protected.
		/// </para>
		/// <para>If the target is full or disconnected, the File History feature will provide a degraded level of protection as follows:</para>
		/// <list type="bullet">
		/// <item>
		/// <term>Files will be backed up to the File History cache on one of the local disks.</term>
		/// </item>
		/// <item>
		/// <term>If the cache fills up during this time, older copies will be deleted from the cache to back up newer copies.</term>
		/// </item>
		/// <item>
		/// <term>If the target is low on free space, the degraded level of protection will start once the target becomes full.</term>
		/// </item>
		/// </list>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/fhcfg/nf-fhcfg-ifhconfigmgr-queryprotectionstatus HRESULT
		// QueryProtectionStatus( DWORD *ProtectionState, BSTR *ProtectedUntilTime );
		void QueryProtectionStatus(out FH_STATE ProtectionState, [MarshalAs(UnmanagedType.BStr)] out string ProtectedUntilTime);
	}

	/// <summary>
	/// <para>
	/// This interface allows client applications to reassociate a File History configuration from a File History target with the
	/// current user. Reassociation serves two purposes:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>
	/// It allows the user to access the data that was backed up to the target in the past, possibly from a different computer or under
	/// a different account.
	/// </term>
	/// </item>
	/// <item>
	/// <term>It allows the user to continue to back up data to the target, possibly on a new computer or under a new account name.</term>
	/// </item>
	/// </list>
	/// <note><c>IFhReassociation</c> is deprecated and may be altered or unavailable in future releases.</note>
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/fhcfg/nn-fhcfg-ifhreassociation
	[PInvokeData("fhcfg.h", MSDNShortId = "NN:fhcfg.IFhReassociation")]
	[ComImport, Guid("6544A28A-F68D-47ac-91EF-16B2B36AA3EE"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown), CoClass(typeof(FhReassociation))]
	public interface IFhReassociation
	{
		/// <summary>
		/// <para>
		/// This method checks whether a certain storage device or network share can be used as a File History default target and, thus,
		/// whether reassociation is possible at all or not.
		/// </para>
		/// <note><c>IFhReassociation</c> is deprecated and may be altered or unavailable in future releases.</note>
		/// </summary>
		/// <param name="TargetUrl">Specifies the storage device or network share to be validated.</param>
		/// <returns>
		/// On return, contains a value specifying the result of the device validation. See the FH_DEVICE_VALIDATION_RESULT enumeration
		/// for a detailed description of supported device validation results.
		/// </returns>
		/// <remarks>
		/// <para>
		/// For local disks, the TargetUrl parameter contains the drive letter. This path must end with a trailing backslash (for
		/// example, "X:").
		/// </para>
		/// <para>
		/// For network shares, the TargetUrl parameter contains the full path of the share. This path must end with a trailing
		/// backslash (for example, "\myserver\myshare").
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/fhcfg/nf-fhcfg-ifhreassociation-validatetarget HRESULT ValidateTarget(
		// BSTR TargetUrl, PFH_DEVICE_VALIDATION_RESULT ValidationResult );
		FH_DEVICE_VALIDATION_RESULT ValidateTarget([MarshalAs(UnmanagedType.BStr)] string TargetUrl);

		/// <summary>
		/// <para>
		/// Scans the namespace on a specified storage device or network share for File History configurations that can be reassociated
		/// with and continued to be used on the current computer.
		/// </para>
		/// <note><c>IFhReassociation</c> is deprecated and may be altered or unavailable in future releases.</note>
		/// </summary>
		/// <param name="TargetUrl">Specifies the storage device or network share to be scanned.</param>
		/// <remarks>
		/// <para>
		/// For local disks, the TargetUrl parameter contains the drive letter. This path must end with a trailing backslash (for
		/// example, "X:").
		/// </para>
		/// <para>
		/// For network shares, the TargetUrl parameter contains the full path of the share. This path must end with a trailing
		/// backslash (for example, "\myserver\myshare").
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/fhcfg/nf-fhcfg-ifhreassociation-scantargetforconfigurations HRESULT
		// ScanTargetForConfigurations( BSTR TargetUrl );
		void ScanTargetForConfigurations([MarshalAs(UnmanagedType.BStr)] string TargetUrl);

		/// <summary>
		/// <para>
		/// This method enumerates File History configurations that were discovered on a storage device or network share by the
		/// IFhReassociation::ScanTargetForConfigurations method and returns additional information about each of the discovered configurations.
		/// </para>
		/// <note><c>IFhReassociation</c> is deprecated and may be altered or unavailable in future releases.</note>
		/// </summary>
		/// <param name="Index">Zero-based index of a discovered configuration.</param>
		/// <param name="UserName">
		/// On return, contains a pointer to a string allocated with SysAllocString containing the name of the user account under which
		/// the configuration was last backed up to.
		/// </param>
		/// <param name="PcName">
		/// On return, contains a pointer to a string allocated with SysAllocString containing the name of the computer from which the
		/// configuration was last backed up.
		/// </param>
		/// <param name="BackupTime">On return, contains the date and time when the configuration was last backed up.</param>
		/// <remarks>
		/// <para>
		/// The caller is responsible for releasing the memory allocated for UserName and PcName by calling SysFreeString on each of them.
		/// </para>
		/// <para>
		/// In order to perform reassociation, one of the configurations enumerated by this method must be selected using the
		/// IFhReassociation::SelectConfiguration method and then the IFhReassociation::PerformReassociation method needs to be called.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/fhcfg/nf-fhcfg-ifhreassociation-getconfigurationdetails HRESULT
		// GetConfigurationDetails( DWORD Index, BSTR *UserName, BSTR *PcName, FILETIME *BackupTime );
		void GetConfigurationDetails(uint Index, [MarshalAs(UnmanagedType.BStr)] out string UserName, [MarshalAs(UnmanagedType.BStr)] out string PcName, out FILETIME BackupTime);

		/// <summary>
		/// <para>
		/// Selects one of the File History configurations discovered on a storage device or network share by the
		/// IFhReassociation::ScanTargetForConfigurations method for subsequent reassociation. Actual reassociation is performed by the
		/// IFhReassociation::PerformReassociation method.
		/// </para>
		/// <note><c>IFhReassociation</c> is deprecated and may be altered or unavailable in future releases.</note>
		/// </summary>
		/// <param name="Index">Zero-based index of a discovered configuration.</param>
		// https://docs.microsoft.com/en-us/windows/win32/api/fhcfg/nf-fhcfg-ifhreassociation-selectconfiguration HRESULT
		// SelectConfiguration( DWORD Index );
		void SelectConfiguration(uint Index);

		/// <summary>
		/// <para>
		/// This method re-establishes relationship between the current user and the configuration selected previously via the
		/// IFhReassociation::SelectConfiguration method and prepares the target device for accepting backup data from the current computer.
		/// </para>
		/// <note><c>IFhReassociation</c> is deprecated and may be altered or unavailable in future releases.</note>
		/// </summary>
		/// <param name="OverwriteIfExists">
		/// <para>This parameter specifies how to handle the current File History configuration, if it already exists.</para>
		/// <para>
		/// If this parameter is set to <c>FALSE</c> and File History is already configured for the current user, this method fails with
		/// the <c>FHCFG_E_CONFIG_ALREADY_EXISTS</c> error code and backups continue to be performed to the already configured target device.
		/// </para>
		/// <para>
		/// If this parameter is set to <c>TRUE</c> and File History is already configured for the current user, the current
		/// configuration is replaced with the selected one and future backups after performed to the target device containing the
		/// selected configuration.
		/// </para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/fhcfg/nf-fhcfg-ifhreassociation-performreassociation HRESULT
		// PerformReassociation( BOOL OverwriteIfExists );
		void PerformReassociation([MarshalAs(UnmanagedType.Bool)] bool OverwriteIfExists);
	}

	/// <summary>
	/// <para>
	/// The <c>IFhScopeIterator</c> interface allows client applications to enumerate individual items in an inclusion or exclusion
	/// list. To retrieve inclusion and exclusion lists, call the IFhConfigMgr::GetIncludeExcludeRules method.
	/// </para>
	/// <note><c>IFhScopeIterator</c> is deprecated and may be altered or unavailable in future releases.</note>
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/fhcfg/nn-fhcfg-ifhscopeiterator
	[PInvokeData("fhcfg.h", MSDNShortId = "NN:fhcfg.IFhScopeIterator")]
	[ComImport, Guid("3197ABCE-532A-44C6-8615-F3666566A720"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IFhScopeIterator
	{
		/// <summary>
		/// <para>Moves to the next item in the inclusion or exclusion list.</para>
		/// <note><c>IFhScopeIterator</c> is deprecated and may be altered or unavailable in future releases.</note>
		/// </summary>
		/// <returns>
		/// <c>S_OK</c> on success, or an unsuccessful <c>HRESULT</c> on failure. Possible unsuccessful <c>HRESULT</c> values include
		/// values defined in the FhErrors.h header file.
		/// </returns>
		/// <remarks>
		/// If the current item is the last item in the list, or if the list is empty, this method returns
		/// <code>HRESULT_FROM_WIN32(ERROR_NOT_FOUND)</code>
		/// .
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/fhcfg/nf-fhcfg-ifhscopeiterator-movetonextitem HRESULT MoveToNextItem();
		[PreserveSig]
		HRESULT MoveToNextItem();

		/// <summary>
		/// <para>Retrieves the current item in an inclusion or exclusion list.</para>
		/// <note><c>IFhScopeIterator</c> is deprecated and may be altered or unavailable in future releases.</note>
		/// </summary>
		/// <returns>
		/// On output, it receives a pointer to a string that contains the current element of the list. This element is a library name
		/// or a folder name, depending on the parameters that were passed to the IFhConfigMgr::GetIncludeExcludeRules method. The
		/// string is allocated by calling SysAllocString. You must call SysFreeString to free the string when it is no longer needed.
		/// </returns>
		/// <remarks>To move to the next item in the inclusion or exclusion list, call the IFhScopeIterator::MoveToNextItem method.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/fhcfg/nf-fhcfg-ifhscopeiterator-getitem HRESULT GetItem( BSTR *Item );
		[return: MarshalAs(UnmanagedType.BStr)]
		string GetItem();
	}

	/// <summary>
	/// <para>
	/// The <c>IFhTarget</c> interface allows client applications to read numeric and string properties of a File History backup target.
	/// </para>
	/// <note><c>IFhTarget</c> is deprecated and may be altered or unavailable in future releases.</note>
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/fhcfg/nn-fhcfg-ifhtarget
	[PInvokeData("fhcfg.h", MSDNShortId = "NN:fhcfg.IFhTarget")]
	[ComImport, Guid("D87965FD-2BAD-4657-BD3B-9567EB300CED"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IFhTarget
	{
		/// <summary>
		/// <para>Retrieves a string property of the File History backup target that is represented by an IFhTarget interface.</para>
		/// <note><c>IFhTarget</c> is deprecated and may be altered or unavailable in future releases.</note>
		/// </summary>
		/// <param name="PropertyType">
		/// Specifies the string property. See the FH_TARGET_PROPERTY_TYPE enumeration for the list of possible string property types.
		/// </param>
		/// <returns>
		/// This parameter must be <c>NULL</c> on input. On output, it receives a pointer to a string that contains the string property.
		/// This string is allocated by calling SysAllocString. You must call SysFreeString to free the string when it is no longer needed.
		/// </returns>
		/// <remarks>
		/// The FH_TARGET_PROPERTY_TYPE enumeration defines property types for string properties and numeric properties. However, the
		/// <c>IFhTarget::GetStringProperty</c> method can only be used to retrieve string properties. Numeric properties must be
		/// retrieved by calling the IFhTarget::GetNumericalProperty method.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/fhcfg/nf-fhcfg-ifhtarget-getstringproperty HRESULT GetStringProperty(
		// FH_TARGET_PROPERTY_TYPE PropertyType, BSTR *PropertyValue );
		[return: MarshalAs(UnmanagedType.BStr)]
		string GetStringProperty(FH_TARGET_PROPERTY_TYPE PropertyType);

		/// <summary>
		/// <para>Retrieves a numeric property of the File History backup target that is represented by an IFhTarget interface.</para>
		/// <note><c>IFhTarget</c> is deprecated and may be altered or unavailable in future releases.</note>
		/// </summary>
		/// <param name="PropertyType">
		/// Specifies the numeric property. See the FH_TARGET_PROPERTY_TYPE enumeration for a list of possible numeric properties.
		/// </param>
		/// <returns>Receives the value of the numeric property.</returns>
		/// <remarks>
		/// The FH_TARGET_PROPERTY_TYPE enumeration defines property types for string properties and numeric properties. However, the
		/// <c>IFhTarget::GetNumericalProperty</c> method can only be used to retrieve numeric properties. String properties must be
		/// retrieved by calling the IFhTarget::GetStringProperty method.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/fhcfg/nf-fhcfg-ifhtarget-getnumericalproperty HRESULT
		// GetNumericalProperty( FH_TARGET_PROPERTY_TYPE PropertyType, ULONGLONG *PropertyValue );
		ulong GetNumericalProperty(FH_TARGET_PROPERTY_TYPE PropertyType);
	}

	/// <summary>
	/// <para>This function temporarily blocks backups for the current user.</para>
	/// <note><c>FhServiceBlockBackup</c> is deprecated and may be altered or unavailable in future releases.</note>
	/// </summary>
	/// <param name="Pipe">The communication channel handle returned by an earlier FhServiceOpenPipe call.</param>
	/// <returns>
	/// <c>S_OK</c> on success, or an unsuccessful <c>HRESULT</c> value on failure. Possible unsuccessful <c>HRESULT</c> values include
	/// values defined in the FhErrors.h header file.
	/// </returns>
	/// <remarks>
	/// <para>
	/// This function instructs the File History Service to not perform backups for the current user until the FhServiceUnblockBackup
	/// function is called or the communication channel with the File History Service is closed by calling FhServiceClosePipe.
	/// </para>
	/// <para>
	/// Call this function prior to performing File History configuration reassociation to ensure that File History configuration and
	/// data files are not currently in use. (Otherwise, the IFhReassociation::PerformReassociation method may fail.)
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/fhsvcctl/nf-fhsvcctl-fhserviceblockbackup HRESULT FhServiceBlockBackup(
	// FH_SERVICE_PIPE_HANDLE Pipe );
	[DllImport(Lib_FhSvcCtl, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("fhsvcctl.h", MSDNShortId = "NF:fhsvcctl.FhServiceBlockBackup")]
	public static extern HRESULT FhServiceBlockBackup(FH_SERVICE_PIPE_HANDLE Pipe);

	/// <summary>
	/// <para>Closes a communication channel to the File History Service opened with FhServiceOpenPipe.</para>
	/// <note><c>FhServiceClosePipe</c> is deprecated and may be altered or unavailable in future releases.</note>
	/// </summary>
	/// <param name="Pipe">The communication channel handle returned by an earlier FhServiceOpenPipe call.</param>
	/// <returns>
	/// <c>S_OK</c> on success, or an unsuccessful <c>HRESULT</c> value on failure. Possible unsuccessful <c>HRESULT</c> values include
	/// values defined in the FhErrors.h header file.
	/// </returns>
	/// <remarks>
	/// An application should call <c>FhServiceClosePipe</c> once for each communication channel handle it opens with FhServiceOpenPipe.
	/// Closing a communication channel handle multiple times is not supported and may lead to unpredictable behavior.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/fhsvcctl/nf-fhsvcctl-fhserviceclosepipe HRESULT FhServiceClosePipe(
	// FH_SERVICE_PIPE_HANDLE Pipe );
	[DllImport(Lib_FhSvcCtl, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("fhsvcctl.h", MSDNShortId = "NF:fhsvcctl.FhServiceClosePipe")]
	public static extern HRESULT FhServiceClosePipe(FH_SERVICE_PIPE_HANDLE Pipe);

	/// <summary>
	/// <para>Opens a communication channel to the File History Service.</para>
	/// <note><c>FhServiceOpenPipe</c> is deprecated and may be altered or unavailable in future releases.</note>
	/// </summary>
	/// <param name="StartServiceIfStopped">
	/// <para>
	/// If the File History Service is not started yet and this parameter is <c>TRUE</c>, this function starts the File History Service
	/// before opening a communication channel to it.
	/// </para>
	/// <para>
	/// If the File History Service is not started yet and this parameter is <c>FALSE</c>, this function fails and returns an
	/// unsuccessful <c>HRESULT</c> value.
	/// </para>
	/// </param>
	/// <param name="Pipe">
	/// On successful return, this parameter contains a non-NULL handle representing a newly opened communication channel to the File
	/// History Service.
	/// </param>
	/// <returns>
	/// <c>S_OK</c> on success, or an unsuccessful <c>HRESULT</c> value on failure. Possible unsuccessful <c>HRESULT</c> values include
	/// values defined in the FhErrors.h header file.
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/fhsvcctl/nf-fhsvcctl-fhserviceopenpipe HRESULT FhServiceOpenPipe( BOOL
	// StartServiceIfStopped, FH_SERVICE_PIPE_HANDLE *Pipe );
	[DllImport(Lib_FhSvcCtl, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("fhsvcctl.h", MSDNShortId = "NF:fhsvcctl.FhServiceOpenPipe")]
	public static extern HRESULT FhServiceOpenPipe([MarshalAs(UnmanagedType.Bool)] bool StartServiceIfStopped, out SafeFH_SERVICE_PIPE_HANDLE Pipe);

	/// <summary>
	/// <para>This function causes the File History Service to reload the current user’s File History configuration files.</para>
	/// <note><c>FhServiceReloadConfiguration</c> is deprecated and may be altered or unavailable in future releases.</note>
	/// </summary>
	/// <param name="Pipe">The communication channel handle returned by an earlier FhServiceOpenPipe call.</param>
	/// <returns>
	/// <c>S_OK</c> on success, or an unsuccessful <c>HRESULT</c> value on failure. Possible unsuccessful <c>HRESULT</c> values include
	/// values defined in the FhErrors.h header file.
	/// </returns>
	/// <remarks>
	/// <para>
	/// This function causes the File History Service to schedule periodic backups for the current user if they have not been scheduled
	/// yet and File History is enabled for that user.
	/// </para>
	/// <para>
	/// It is recommended to call this function every time a policy is changed in File History configuration via the
	/// IFhConfigMgr::SetLocalPolicy method. It should also be called after File History has been enabled or disabled for a user.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/fhsvcctl/nf-fhsvcctl-fhservicereloadconfiguration HRESULT
	// FhServiceReloadConfiguration( FH_SERVICE_PIPE_HANDLE Pipe );
	[DllImport(Lib_FhSvcCtl, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("fhsvcctl.h", MSDNShortId = "NF:fhsvcctl.FhServiceReloadConfiguration")]
	public static extern HRESULT FhServiceReloadConfiguration(FH_SERVICE_PIPE_HANDLE Pipe);

	/// <summary>
	/// <para>This function starts an immediate backup for the current user.</para>
	/// <note><c>FhServiceStartBackup</c> is deprecated and may be altered or unavailable in future releases.</note>
	/// </summary>
	/// <param name="Pipe">The communication channel handle returned by an earlier FhServiceOpenPipe call.</param>
	/// <param name="LowPriorityIo">
	/// <para>
	/// If <c>TRUE</c>, the File History Service is instructed to use low priority I/O for the immediate backup scheduled by this
	/// function. Low-priority I/O reduces impact on foreground user activities. It is recommended to set this parameter to <c>TRUE.</c>
	/// </para>
	/// <para>
	/// If <c>FALSE</c>, the File History Service is instructed to use normal priority I/O for the immediate backup scheduled by this
	/// function. This results in faster backups but negatively affects the responsiveness and performance of user applications.
	/// </para>
	/// </param>
	/// <returns>
	/// <c>S_OK</c> on success, or an unsuccessful <c>HRESULT</c> on failure. Possible unsuccessful <c>HRESULT</c> values include values
	/// defined in the FhErrors.h header file.
	/// </returns>
	/// <remarks>
	/// <para>
	/// This function does not wait until the immediate backup completes. If an error or warning condition is encountered during backup,
	/// it is communicated to the user via an Action Center notification and programmatically retrievable via the
	/// IFhConfigMgr::QueryProtectionStatus method.
	/// </para>
	/// <para>A backup cycle initiated by calling this function can be stopped using the FhServiceStopBackup function.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/fhsvcctl/nf-fhsvcctl-fhservicestartbackup HRESULT FhServiceStartBackup(
	// FH_SERVICE_PIPE_HANDLE Pipe, BOOL LowPriorityIo );
	[DllImport(Lib_FhSvcCtl, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("fhsvcctl.h", MSDNShortId = "NF:fhsvcctl.FhServiceStartBackup")]
	public static extern HRESULT FhServiceStartBackup(FH_SERVICE_PIPE_HANDLE Pipe, [MarshalAs(UnmanagedType.Bool)] bool LowPriorityIo);

	/// <summary>
	/// <para>This function stops an ongoing backup cycle for the current user.</para>
	/// <note><c>FhServiceStopBackup</c> is deprecated and may be altered or unavailable in future releases.</note>
	/// </summary>
	/// <param name="Pipe">The communication channel handle returned by an earlier FhServiceOpenPipe call.</param>
	/// <param name="StopTracking">
	/// <para>
	/// If <c>TRUE</c>, this function both stops the ongoing backup cycle (if any) and prevents periodic backup cycles for the current
	/// user in the future.
	/// </para>
	/// <para>If <c>FALSE</c>, this function only stops the ongoing backup cycle.</para>
	/// </param>
	/// <returns>
	/// <c>S_OK</c> on success, or an unsuccessful <c>HRESULT</c> value on failure. Possible unsuccessful <c>HRESULT</c> values include
	/// values defined in the FhErrors.h header file.
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/fhsvcctl/nf-fhsvcctl-fhservicestopbackup HRESULT FhServiceStopBackup(
	// FH_SERVICE_PIPE_HANDLE Pipe, BOOL StopTracking );
	[DllImport(Lib_FhSvcCtl, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("fhsvcctl.h", MSDNShortId = "NF:fhsvcctl.FhServiceStopBackup")]
	public static extern HRESULT FhServiceStopBackup(FH_SERVICE_PIPE_HANDLE Pipe, [MarshalAs(UnmanagedType.Bool)] bool StopTracking);

	/// <summary>
	/// <para>This function unblocks backups blocked via FhServiceBlockBackup.</para>
	/// <note><c>FhServiceUnblockBackup</c> is deprecated and may be altered or unavailable in future releases.</note>
	/// </summary>
	/// <param name="Pipe">The communication channel handle returned by an earlier FhServiceOpenPipe call.</param>
	/// <returns>
	/// <c>S_OK</c> on success, or an unsuccessful <c>HRESULT</c> value on failure. Possible unsuccessful <c>HRESULT</c> values include
	/// values defined in the FhErrors.h header file.
	/// </returns>
	/// <remarks>
	/// This function removes the effects of a prior FhServiceBlockBackup call issued via a given communication channel with the File
	/// History Service.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/fhsvcctl/nf-fhsvcctl-fhserviceunblockbackup HRESULT FhServiceUnblockBackup(
	// FH_SERVICE_PIPE_HANDLE Pipe );
	[DllImport(Lib_FhSvcCtl, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("fhsvcctl.h", MSDNShortId = "NF:fhsvcctl.FhServiceUnblockBackup")]
	public static extern HRESULT FhServiceUnblockBackup(FH_SERVICE_PIPE_HANDLE Pipe);

	/// <summary>Provides a handle to a communication channel.</summary>
	[StructLayout(LayoutKind.Sequential)]
	public struct FH_SERVICE_PIPE_HANDLE : IHandle
	{
		private readonly IntPtr handle;

		/// <summary>Initializes a new instance of the <see cref="FH_SERVICE_PIPE_HANDLE"/> struct.</summary>
		/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
		public FH_SERVICE_PIPE_HANDLE(IntPtr preexistingHandle) => handle = preexistingHandle;

		/// <summary>Returns an invalid handle by instantiating a <see cref="FH_SERVICE_PIPE_HANDLE"/> object with <see cref="IntPtr.Zero"/>.</summary>
		public static FH_SERVICE_PIPE_HANDLE NULL => new(IntPtr.Zero);

		/// <summary>Gets a value indicating whether this instance is a null handle.</summary>
		public bool IsNull => handle == IntPtr.Zero;

		/// <summary>Performs an explicit conversion from <see cref="FH_SERVICE_PIPE_HANDLE"/> to <see cref="IntPtr"/>.</summary>
		/// <param name="h">The handle.</param>
		/// <returns>The result of the conversion.</returns>
		public static explicit operator IntPtr(FH_SERVICE_PIPE_HANDLE h) => h.handle;

		/// <summary>Performs an implicit conversion from <see cref="IntPtr"/> to <see cref="FH_SERVICE_PIPE_HANDLE"/>.</summary>
		/// <param name="h">The pointer to a handle.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator FH_SERVICE_PIPE_HANDLE(IntPtr h) => new(h);

		/// <summary>Implements the operator !=.</summary>
		/// <param name="h1">The first handle.</param>
		/// <param name="h2">The second handle.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator !=(FH_SERVICE_PIPE_HANDLE h1, FH_SERVICE_PIPE_HANDLE h2) => !(h1 == h2);

		/// <summary>Implements the operator ==.</summary>
		/// <param name="h1">The first handle.</param>
		/// <param name="h2">The second handle.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator ==(FH_SERVICE_PIPE_HANDLE h1, FH_SERVICE_PIPE_HANDLE h2) => h1.Equals(h2);

		/// <inheritdoc/>
		public override bool Equals(object obj) => obj is FH_SERVICE_PIPE_HANDLE h && handle == h.handle;

		/// <inheritdoc/>
		public override int GetHashCode() => handle.GetHashCode();

		/// <inheritdoc/>
		public IntPtr DangerousGetHandle() => handle;
	}

	/// <summary>Class interface for <see cref="IFhConfigMgr"/>.</summary>
	[ComImport, Guid("ED43BB3C-09E9-498a-9DF6-2177244C6DB4"), ClassInterface(ClassInterfaceType.None)]
	public class FhConfigMgr { }

	/// <summary>Class interface for <see cref="IFhReassociation"/>.</summary>
	[ComImport, Guid("4D728E35-16FA-4320-9E8B-BFD7100A8846"), ClassInterface(ClassInterfaceType.None)]
	public class FhReassociation { }

	/// <summary>Provides a <see cref="SafeHandle"/> for <see cref="FH_SERVICE_PIPE_HANDLE"/> that is disposed using <see cref="FhServiceClosePipe"/>.</summary>
	public class SafeFH_SERVICE_PIPE_HANDLE : SafeHANDLE
	{
		/// <summary>Initializes a new instance of the <see cref="SafeFH_SERVICE_PIPE_HANDLE"/> class and assigns an existing handle.</summary>
		/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
		/// <param name="ownsHandle">
		/// <see langword="true"/> to reliably release the handle during the finalization phase; otherwise, <see langword="false"/> (not recommended).
		/// </param>
		public SafeFH_SERVICE_PIPE_HANDLE(IntPtr preexistingHandle, bool ownsHandle = true) : base(preexistingHandle, ownsHandle) { }

		/// <summary>Initializes a new instance of the <see cref="SafeFH_SERVICE_PIPE_HANDLE"/> class.</summary>
		private SafeFH_SERVICE_PIPE_HANDLE() : base() { }

		/// <summary>Performs an implicit conversion from <see cref="SafeFH_SERVICE_PIPE_HANDLE"/> to <see cref="FH_SERVICE_PIPE_HANDLE"/>.</summary>
		/// <param name="h">The safe handle instance.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator FH_SERVICE_PIPE_HANDLE(SafeFH_SERVICE_PIPE_HANDLE h) => h.handle;

		/// <inheritdoc/>
		protected override bool InternalReleaseHandle() => FhServiceClosePipe(handle).Succeeded;
	}
}