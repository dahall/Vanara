using static Vanara.PInvoke.Kernel32;
using USN = System.Int64;

namespace Vanara.PInvoke;

/// <summary>Functions, structures and constants from CldApi.dll.</summary>
public static partial class CldApi
{
	private const int CF_MAX_PROVIDER_NAME_LENGTH = 255;

	private const int CF_MAX_PROVIDER_VERSION_LENGTH = 255;

	/// <summary>Callback flags for canceling data fetching for a placeholder file or folder.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/cfapi/ne-cfapi-cf_callback_cancel_flags typedef enum CF_CALLBACK_CANCEL_FLAGS
	// { CF_CALLBACK_CANCEL_FLAG_NONE, CF_CALLBACK_CANCEL_FLAG_IO_TIMEOUT, CF_CALLBACK_CANCEL_FLAG_IO_ABORTED } ;
	[PInvokeData("cfapi.h", MSDNShortId = "16F0BB1E-FB9E-4AC3-8FD9-A540F72F1155")]
	[Flags]
	public enum CF_CALLBACK_CANCEL_FLAGS
	{
		/// <summary>No cancel flag.</summary>
		CF_CALLBACK_CANCEL_FLAG_NONE = 0,

		/// <summary>Flag to be set if the user request is cancelled as a result of the expiration of the 60 second timer.</summary>
		CF_CALLBACK_CANCEL_FLAG_IO_TIMEOUT = 1,

		/// <summary>
		/// Flag to be set if the user request is cancelled as a result of the user explicitly terminating the hydration from
		/// app-initiated download toast.
		/// </summary>
		CF_CALLBACK_CANCEL_FLAG_IO_ABORTED = 2,
	}

	/// <summary>
	/// Callback flags for notifying a sync provider that a placeholder under one of its sync roots that has been previously opened for
	/// read/write/delete access is now closed.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/cfapi/ne-cfapi-cf_callback_close_completion_flags typedef enum
	// CF_CALLBACK_CLOSE_COMPLETION_FLAGS { CF_CALLBACK_CLOSE_COMPLETION_FLAG_NONE, CF_CALLBACK_CLOSE_COMPLETION_FLAG_DELETED } ;
	[PInvokeData("cfapi.h", MSDNShortId = "D80D95FB-C53B-4A31-97B9-389BE73BE966")]
	[Flags]
	public enum CF_CALLBACK_CLOSE_COMPLETION_FLAGS
	{
		/// <summary>No close completion flags.</summary>
		CF_CALLBACK_CLOSE_COMPLETION_FLAG_NONE = 0,

		/// <summary>A flag set if a placeholder is deleted as a result of the close.</summary>
		CF_CALLBACK_CLOSE_COMPLETION_FLAG_DELETED = 1,
	}

	/// <summary>
	/// A callback flag to inform the sync provider that a placeholder under one of its sync roots has been successfully dehydrated.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/cfapi/ne-cfapi-cf_callback_dehydrate_completion_flags typedef enum
	// CF_CALLBACK_DEHYDRATE_COMPLETION_FLAGS { CF_CALLBACK_DEHYDRATE_COMPLETION_FLAG_NONE,
	// CF_CALLBACK_DEHYDRATE_COMPLETION_FLAG_BACKGROUND, CF_CALLBACK_DEHYDRATE_COMPLETION_FLAG_DEHYDRATED } ;
	[PInvokeData("cfapi.h", MSDNShortId = "BB39BC4D-A5FF-4204-A7ED-30605B865F15")]
	[Flags]
	public enum CF_CALLBACK_DEHYDRATE_COMPLETION_FLAGS
	{
		/// <summary>No dehydration completion flag.</summary>
		CF_CALLBACK_DEHYDRATE_COMPLETION_FLAG_NONE = 0,

		/// <summary>A flag set if the dehydration request is initiated by a system background service.</summary>
		CF_CALLBACK_DEHYDRATE_COMPLETION_FLAG_BACKGROUND = 1,

		/// <summary>A flag set if the placeholder was hydrated prior to the dehydration request.</summary>
		CF_CALLBACK_DEHYDRATE_COMPLETION_FLAG_DEHYDRATED = 2,
	}

	/// <summary>Callback flags for notifying a sync provider that a placeholder under one of its sync root is going to be dehydrated.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/cfapi/ne-cfapi-cf_callback_dehydrate_flags typedef enum
	// CF_CALLBACK_DEHYDRATE_FLAGS { CF_CALLBACK_DEHYDRATE_FLAG_NONE, CF_CALLBACK_DEHYDRATE_FLAG_BACKGROUND } ;
	[PInvokeData("cfapi.h", MSDNShortId = "DCB085EA-1468-44FB-9D45-F5C89693CBE7")]
	[Flags]
	public enum CF_CALLBACK_DEHYDRATE_FLAGS
	{
		/// <summary>No dehydrate flag.</summary>
		CF_CALLBACK_DEHYDRATE_FLAG_NONE = 0,

		/// <summary>A flag set if the dehydration request is initiated by a system background service.</summary>
		CF_CALLBACK_DEHYDRATE_FLAG_BACKGROUND = 1,
	}

	/// <summary/>
	[PInvokeData("cfapi.h")]
	public enum CF_CALLBACK_DEHYDRATION_REASON
	{
		/// <summary/>
		CF_CALLBACK_DEHYDRATION_REASON_NONE,

		/// <summary/>
		CF_CALLBACK_DEHYDRATION_REASON_USER_MANUAL,

		/// <summary/>
		CF_CALLBACK_DEHYDRATION_REASON_SYSTEM_LOW_SPACE,

		/// <summary/>
		CF_CALLBACK_DEHYDRATION_REASON_SYSTEM_INACTIVITY,

		/// <summary/>
		CF_CALLBACK_DEHYDRATION_REASON_SYSTEM_OS_UPGRADE,
	}

	/// <summary>Callback flags for notifying a sync provider that a placeholder was successfully deleted.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/cfapi/ne-cfapi-cf_callback_delete_completion_flags typedef enum
	// CF_CALLBACK_DELETE_COMPLETION_FLAGS { CF_CALLBACK_DELETE_COMPLETION_FLAG_NONE } ;
	[PInvokeData("cfapi.h", MSDNShortId = "33971B32-C97B-4C79-B6ED-B2E1C20B912A")]
	[Flags]
	public enum CF_CALLBACK_DELETE_COMPLETION_FLAGS
	{
		/// <summary>No delete completion flag.</summary>
		CF_CALLBACK_DELETE_COMPLETION_FLAG_NONE = 0,
	}

	/// <summary>
	/// This callback is used to inform the sync provider that a placeholder file or directory under one of its sync roots is about to
	/// be deleted.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/cfapi/ne-cfapi-cf_callback_delete_flags typedef enum CF_CALLBACK_DELETE_FLAGS
	// { CF_CALLBACK_DELETE_FLAG_NONE, CF_CALLBACK_DELETE_FLAG_IS_DIRECTORY } ;
	[PInvokeData("cfapi.h", MSDNShortId = "76F9FB0C-F531-447F-8F0E-1EB849336771")]
	[Flags]
	public enum CF_CALLBACK_DELETE_FLAGS
	{
		/// <summary>No delete flag.</summary>
		CF_CALLBACK_DELETE_FLAG_NONE = 0,

		/// <summary>The placeholder that is about to be deleted is a directory.</summary>
		CF_CALLBACK_DELETE_FLAG_IS_DIRECTORY = 1,
	}

	/// <summary>Callback flags for fetching data for a placeholder file or folder.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/cfapi/ne-cfapi-cf_callback_fetch_data_flags typedef enum
	// CF_CALLBACK_FETCH_DATA_FLAGS { CF_CALLBACK_FETCH_DATA_FLAG_NONE, CF_CALLBACK_FETCH_DATA_FLAG_RECOVERY,
	// CF_CALLBACK_FETCH_DATA_FLAG_EXPLICIT_HYDRATION } ;
	[PInvokeData("cfapi.h", MSDNShortId = "18C2CF8D-C59F-4181-953E-84B6BEC5F479")]
	[Flags]
	public enum CF_CALLBACK_FETCH_DATA_FLAGS
	{
		/// <summary>No data fetch flag.</summary>
		CF_CALLBACK_FETCH_DATA_FLAG_NONE = 0,

		/// <summary>Flag to be used if the callback is invoked as a result of previously interrupted hydration process.</summary>
		CF_CALLBACK_FETCH_DATA_FLAG_RECOVERY = 1,

		/// <summary>
		/// Note This value is new for Windows 10, version 1803. Flag to be used if the callback is invoked as a result of a call to CfHydratePlaceholder.
		/// </summary>
		CF_CALLBACK_FETCH_DATA_FLAG_EXPLICIT_HYDRATION = 2,
	}

	/// <summary>Flags for fetching information about the content of a placeholder file or directory.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/cfapi/ne-cfapi-cf_callback_fetch_placeholders_flags typedef enum
	// CF_CALLBACK_FETCH_PLACEHOLDERS_FLAGS { CF_CALLBACK_FETCH_PLACEHOLDERS_FLAG_NONE } ;
	[PInvokeData("cfapi.h", MSDNShortId = "CD90EB49-8C39-49DD-8688-CBDF77B1EA92")]
	[Flags]
	public enum CF_CALLBACK_FETCH_PLACEHOLDERS_FLAGS
	{
		/// <summary>No fetch placeholder flags.</summary>
		CF_CALLBACK_FETCH_PLACEHOLDERS_FLAG_NONE = 0,
	}

	/// <summary>Callback flags for notifying a sync provider that a placeholder was successfully opened for read/write/delete access.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/cfapi/ne-cfapi-cf_callback_open_completion_flags typedef enum
	// CF_CALLBACK_OPEN_COMPLETION_FLAGS { CF_CALLBACK_OPEN_COMPLETION_FLAG_NONE, CF_CALLBACK_OPEN_COMPLETION_FLAG_PLACEHOLDER_UNKNOWN,
	// CF_CALLBACK_OPEN_COMPLETION_FLAG_PLACEHOLDER_UNSUPPORTED } ;
	[PInvokeData("cfapi.h", MSDNShortId = "FF7EA010-B90A-46F8-A373-5C128B31FE70")]
	[Flags]
	public enum CF_CALLBACK_OPEN_COMPLETION_FLAGS
	{
		/// <summary>No open completion flag.</summary>
		CF_CALLBACK_OPEN_COMPLETION_FLAG_NONE = 0,

		/// <summary>A flag set if the placeholder metadata is corrupted.</summary>
		CF_CALLBACK_OPEN_COMPLETION_FLAG_PLACEHOLDER_UNKNOWN = 1,

		/// <summary>A flag set if the placeholder metadata is not supported.</summary>
		CF_CALLBACK_OPEN_COMPLETION_FLAG_PLACEHOLDER_UNSUPPORTED = 2,
	}

	/// <summary>
	/// A callback flag to inform the sync provider that a placeholder under one of its sync roots has been successfully renamed.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/cfapi/ne-cfapi-cf_callback_rename_completion_flags typedef enum
	// CF_CALLBACK_RENAME_COMPLETION_FLAGS { CF_CALLBACK_RENAME_COMPLETION_FLAG_NONE } ;
	[PInvokeData("cfapi.h", MSDNShortId = "60C94543-E0C4-4A79-BBE3-3098401B1123")]
	[Flags]
	public enum CF_CALLBACK_RENAME_COMPLETION_FLAGS
	{
		/// <summary>No rename completion flag.</summary>
		CF_CALLBACK_RENAME_COMPLETION_FLAG_NONE = 0,
	}

	/// <summary>
	/// Call back flags to inform the sync provider that a placeholder under one of its sync roots is about to be renamed or moved.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/cfapi/ne-cfapi-cf_callback_rename_flags typedef enum CF_CALLBACK_RENAME_FLAGS
	// { CF_CALLBACK_RENAME_FLAG_NONE, CF_CALLBACK_RENAME_FLAG_IS_DIRECTORY, CF_CALLBACK_RENAME_FLAG_SOURCE_IN_SCOPE,
	// CF_CALLBACK_RENAME_FLAG_TARGET_IN_SCOPE } ;
	[PInvokeData("cfapi.h", MSDNShortId = "7506ED1D-F6A8-49EB-B03B-B629264DFBB2")]
	[Flags]
	public enum CF_CALLBACK_RENAME_FLAGS
	{
		/// <summary>No rename flag.</summary>
		CF_CALLBACK_RENAME_FLAG_NONE = 0,

		/// <summary>Flag set if the placeholder is a directory.</summary>
		CF_CALLBACK_RENAME_FLAG_IS_DIRECTORY = 1,

		/// <summary>Flag set if the link to be renamed or moved is within a sync root managed by the sync process.</summary>
		CF_CALLBACK_RENAME_FLAG_SOURCE_IN_SCOPE = 2,

		/// <summary>Flag set if the rename or move target is in the same sync root of the source path.</summary>
		CF_CALLBACK_RENAME_FLAG_TARGET_IN_SCOPE = 4,
	}

	/// <summary>Contains the various types of callbacks used on placeholder files or folders.</summary>
	/// <remarks>
	/// <para>
	/// These are not APIs provided by the library, but rather callbacks that a sync provider must implement in order to service
	/// requests from the platform. As necessary, the platform will ask the library instance running inside the sync provider process to
	/// invoke the appropriate callback routine.
	/// </para>
	/// <para>
	/// Callback routines will be invoked in an arbitrary thread (part of a thread pool). Multiple callbacks can occur simultaneously,
	/// in different threads, and it is the responsibility of the sync provider code to implement any necessary synchronization to make
	/// this work reliably. All callbacks are asynchronous. Asynchronous user requests that trigger the callbacks are pended and the
	/// control is returned to the user application.
	/// </para>
	/// <para>
	/// Every callback request has a fixed 60 second timeout. A valid operation on any pending requests from the sync provider resets
	/// the timers of all pending requests.
	/// </para>
	/// <para>
	/// All callback functions have the same prototype with two arguments: a CF_CALLBACK_INFO structure and a CF_CALLBACK_PARAMETER structure.
	/// </para>
	/// <para>Callback routines have no return value.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/cfapi/ne-cfapi-cf_callback_type typedef enum CF_CALLBACK_TYPE {
	// CF_CALLBACK_TYPE_FETCH_DATA, CF_CALLBACK_TYPE_VALIDATE_DATA, CF_CALLBACK_TYPE_CANCEL_FETCH_DATA,
	// CF_CALLBACK_TYPE_FETCH_PLACEHOLDERS, CF_CALLBACK_TYPE_CANCEL_FETCH_PLACEHOLDERS, CF_CALLBACK_TYPE_NOTIFY_FILE_OPEN_COMPLETION,
	// CF_CALLBACK_TYPE_NOTIFY_FILE_CLOSE_COMPLETION, CF_CALLBACK_TYPE_NOTIFY_DEHYDRATE, CF_CALLBACK_TYPE_NOTIFY_DEHYDRATE_COMPLETION,
	// CF_CALLBACK_TYPE_NOTIFY_DELETE, CF_CALLBACK_TYPE_NOTIFY_DELETE_COMPLETION, CF_CALLBACK_TYPE_NOTIFY_RENAME,
	// CF_CALLBACK_TYPE_NOTIFY_RENAME_COMPLETION, CF_CALLBACK_TYPE_NONE } ;
	[PInvokeData("cfapi.h", MSDNShortId = "0BA978D3-110C-47FC-8949-C5D98A59654C")]
	[Flags]
	public enum CF_CALLBACK_TYPE : uint
	{
		/// <summary>Callback to satisfy an I/O request, or a placeholder hydration request.</summary>
		CF_CALLBACK_TYPE_FETCH_DATA,

		/// <summary>Callback to validate placeholder data.</summary>
		CF_CALLBACK_TYPE_VALIDATE_DATA,

		/// <summary>Callback to cancel an ongoing placeholder hydration.</summary>
		CF_CALLBACK_TYPE_CANCEL_FETCH_DATA,

		/// <summary>Callback to request information about the contents of placeholder files.</summary>
		CF_CALLBACK_TYPE_FETCH_PLACEHOLDERS,

		/// <summary>Callback to cancel a request for the contents of placeholder files.</summary>
		CF_CALLBACK_TYPE_CANCEL_FETCH_PLACEHOLDERS,

		/// <summary>
		/// Callback to inform the sync provider that a placeholder under one of its sync roots has been successfully opened for
		/// read/write/delete access.
		/// </summary>
		CF_CALLBACK_TYPE_NOTIFY_FILE_OPEN_COMPLETION,

		/// <summary>
		/// Callback to inform the sync provider that a placeholder under one of its sync roots that has been previously opened for
		/// read/write/delete access is now closed.
		/// </summary>
		CF_CALLBACK_TYPE_NOTIFY_FILE_CLOSE_COMPLETION,

		/// <summary>Callback to inform the sync provider that a placeholder under one of its sync roots is about to be dehydrated.</summary>
		CF_CALLBACK_TYPE_NOTIFY_DEHYDRATE,

		/// <summary>Callback to inform the sync provider that a placeholder under one of its sync roots has been successfully dehydrated.</summary>
		CF_CALLBACK_TYPE_NOTIFY_DEHYDRATE_COMPLETION,

		/// <summary>Callback to inform the sync provider that a placeholder under one of its sync roots is about to be deleted.</summary>
		CF_CALLBACK_TYPE_NOTIFY_DELETE,

		/// <summary>Callback to inform the sync provider that a placeholder under one of its sync roots has been successfully deleted.</summary>
		CF_CALLBACK_TYPE_NOTIFY_DELETE_COMPLETION,

		/// <summary>
		/// Callback to inform the sync provider that a placeholder under one of its sync roots is about to be renamed or moved.
		/// </summary>
		CF_CALLBACK_TYPE_NOTIFY_RENAME,

		/// <summary>
		/// Callback to inform the sync provider that a placeholder under one of its sync roots has been successfully renamed or moved.
		/// </summary>
		CF_CALLBACK_TYPE_NOTIFY_RENAME_COMPLETION,

		/// <summary>No callback type.</summary>
		CF_CALLBACK_TYPE_NONE = 0xffffffff,
	}

	/// <summary>Flags to validate the data of a placeholder file or directory.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/cfapi/ne-cfapi-cf_callback_validate_data_flags typedef enum
	// CF_CALLBACK_VALIDATE_DATA_FLAGS { CF_CALLBACK_VALIDATE_DATA_FLAG_NONE, CF_CALLBACK_VALIDATE_DATA_FLAG_EXPLICIT_HYDRATION } ;
	[PInvokeData("cfapi.h", MSDNShortId = "D5BEAEAA-318E-4BA5-8DC5-EDD24E2C26EF")]
	[Flags]
	public enum CF_CALLBACK_VALIDATE_DATA_FLAGS
	{
		/// <summary>No data validation flag.</summary>
		CF_CALLBACK_VALIDATE_DATA_FLAG_NONE = 0,

		/// <summary>
		/// Note This value is new for Windows 10, version 1803.Set if the callback is invoked as a result of a call to CfHydratePlaceholder.
		/// </summary>
		CF_CALLBACK_VALIDATE_DATA_FLAG_EXPLICIT_HYDRATION = 2,
	}

	/// <summary>Additional information that can be requested by a sync provider when its callbacks are invoked.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/cfapi/ne-cfapi-cf_connect_flags typedef enum CF_CONNECT_FLAGS {
	// CF_CONNECT_FLAG_NONE, CF_CONNECT_FLAG_REQUIRE_PROCESS_INFO, CF_CONNECT_FLAG_REQUIRE_FULL_FILE_PATH,
	// CF_CONNECT_FLAG_BLOCK_SELF_IMPLICIT_HYDRATION } ;
	[PInvokeData("cfapi.h", MSDNShortId = "C1CAC75C-9CB6-4172-A437-AE366D99DA9F")]
	[Flags]
	public enum CF_CONNECT_FLAGS
	{
		/// <summary>No connection flags.</summary>
		CF_CONNECT_FLAG_NONE = 0,

		/// <summary>
		/// When this flag is specified, the platform returns the full image path of the hydrating process in the callback parameters.
		/// </summary>
		CF_CONNECT_FLAG_REQUIRE_PROCESS_INFO = 2,

		/// <summary>
		/// When this flag is specified, the platform returns the full path of the placeholder being requested in the callback parameters.
		/// </summary>
		CF_CONNECT_FLAG_REQUIRE_FULL_FILE_PATH = 4,

		/// <summary>
		/// Note This value is new for Windows 10, version 1803.When this flag is specified, The implicit hydration, which is not
		/// performed via CfHydratePlaceholder, can happen when the anti-virus software scans a sync provider’s file system activities
		/// on non-hydrated cloud file placeholders. This kind of implicit hydration is not expected. If the sync provider never
		/// initiates implicit hydration operations, it can instruct the platform to block all such implicit hydration operations, as
		/// opposed to failing the FETCH_DATA callbacks later.
		/// </summary>
		CF_CONNECT_FLAG_BLOCK_SELF_IMPLICIT_HYDRATION = 8,
	}

	/// <summary>Normal file/directory to placeholder file/directory conversion flags.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/cfapi/ne-cfapi-cf_convert_flags typedef enum CF_CONVERT_FLAGS {
	// CF_CONVERT_FLAG_NONE, CF_CONVERT_FLAG_MARK_IN_SYNC, CF_CONVERT_FLAG_DEHYDRATE, CF_CONVERT_FLAG_ENABLE_ON_DEMAND_POPULATION } ;
	[PInvokeData("cfapi.h", MSDNShortId = "0342BF0B-509A-4F8D-9557-54E534A3DDFE")]
	[Flags]
	public enum CF_CONVERT_FLAGS
	{
		/// <summary>No conversion flags.</summary>
		CF_CONVERT_FLAG_NONE = 0,

		/// <summary>The platform marks the converted placeholder as in sync with cloud upon a successful conversion of the file.</summary>
		CF_CONVERT_FLAG_MARK_IN_SYNC = 1,

		/// <summary>
		/// Applicable to files only. When specified, the platform dehydrates the file after converting it to a placeholder
		/// successfully. The caller must acquire an exclusive handle when specifying this flag or data corruptions can occur. Note that
		/// the platform does not validate the exclusiveness of the handle.
		/// </summary>
		CF_CONVERT_FLAG_DEHYDRATE = 2,

		/// <summary>
		/// Applicable for directories only. When specified, it marks the converted placeholder directory as partially populated such
		/// that any future access to it will result in a FETCH_PLACEHOLDERS callback sent to the sync provider.
		/// </summary>
		CF_CONVERT_FLAG_ENABLE_ON_DEMAND_POPULATION = 4,
	}

	/// <summary>Flags for creating a placeholder file or directory.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/cfapi/ne-cfapi-cf_create_flags typedef enum CF_CREATE_FLAGS {
	// CF_CREATE_FLAG_NONE, CF_CREATE_FLAG_STOP_ON_ERROR } ;
	[PInvokeData("cfapi.h", MSDNShortId = "F70ECFDB-8542-4395-9EDD-7DABC2E5225D")]
	[Flags]
	public enum CF_CREATE_FLAGS
	{
		/// <summary>Default mode. All entries are processed.</summary>
		CF_CREATE_FLAG_NONE = 0,

		/// <summary>
		/// Causes the API to return immediately if placeholder creation fails. If creation fails, the error code will be returned by
		/// the API.
		/// </summary>
		CF_CREATE_FLAG_STOP_ON_ERROR = 1,
	}

	/// <summary>Placeholder dehydration flags.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/cfapi/ne-cfapi-cf_dehydrate_flags typedef enum CF_DEHYDRATE_FLAGS {
	// CF_DEHYDRATE_FLAG_NONE, CF_DEHYDRATE_FLAG_BACKGROUND } ;
	[PInvokeData("cfapi.h", MSDNShortId = "AE8AA67D-F6ED-4A2B-8613-17BBAB4C9F54")]
	[Flags]
	public enum CF_DEHYDRATE_FLAGS
	{
		/// <summary>No dehydration flags.</summary>
		CF_DEHYDRATE_FLAG_NONE = 0,

		/// <summary>
		/// If specified, the caller is a system process running in the background. Otherwise, the caller is performing this operation
		/// on behalf of a logged-in user.
		/// </summary>
		CF_DEHYDRATE_FLAG_BACKGROUND = 1,
	}

	/// <summary>Specifies whether or not hard links are allowed on placeholder files.</summary>
	/// <remarks>
	/// If hard links are enabled, applications can create as many hard links as the file system supports so long as the links are under
	/// the same sync root or no sync root. Hard links and placeholder operations that are not compatible with this policy will fail
	/// with the error: HRESULT(ERROR_CLOUD_FILES_INCOMPATIBLE_HARDLINKS).
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/cfapi/ne-cfapi-cf_hardlink_policy typedef enum CF_HARDLINK_POLICY {
	// CF_HARDLINK_POLICY_NONE, CF_HARDLINK_POLICY_ALLOWED } ;
	[PInvokeData("cfapi.h", MSDNShortId = "23FFC4E8-0CB7-4FF4-A3C3-2E8FB2C74497")]
	[Flags]
	public enum CF_HARDLINK_POLICY
	{
		/// <summary/>
		CF_HARDLINK_POLICY_NONE = 0,

		/// <summary>Hard links can be created on a placeholder under the same sync root or no sync root.</summary>
		CF_HARDLINK_POLICY_ALLOWED = 1,
	}

	/// <summary>Placeholder data hydration flags.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/cfapi/ne-cfapi-cf_hydrate_flags typedef enum CF_HYDRATE_FLAGS {
	// CF_HYDRATE_FLAG_NONE } ;
	[PInvokeData("cfapi.h", MSDNShortId = "1D49752C-2D80-4EC8-AE24-2DEAFCB7FD46")]
	[Flags]
	public enum CF_HYDRATE_FLAGS
	{
		/// <summary>No hydration flags.</summary>
		CF_HYDRATE_FLAG_NONE = 0,
	}

	/// <summary>
	/// Allows a sync provider to control how placeholder files should be hydrated by the platform. This is a modifier that can be used
	/// with the primary policy: CF_HYDRATION_POLICY_PRIMARY.
	/// </summary>
	/// <remarks>
	/// In general, modifiers can be mixed and matched with any primary policy (CF_HYDRATION_POLICY_PRIMARY) and other policy modifiers
	/// so long as the combination is not self-conflicting.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/cfapi/ne-cfapi-cf_hydration_policy_modifier typedef enum
	// CF_HYDRATION_POLICY_MODIFIER { CF_HYDRATION_POLICY_MODIFIER_NONE, CF_HYDRATION_POLICY_MODIFIER_VALIDATION_REQUIRED,
	// CF_HYDRATION_POLICY_MODIFIER_STREAMING_ALLOWED, CF_HYDRATION_POLICY_MODIFIER_AUTO_DEHYDRATION_ALLOWED } ;
	[PInvokeData("cfapi.h", MSDNShortId = "A98C635E-7E18-4E18-B19A-D3FD85A53CBB")]
	[Flags]
	public enum CF_HYDRATION_POLICY_MODIFIER : ushort
	{
		/// <summary>No policy modifier.</summary>
		CF_HYDRATION_POLICY_MODIFIER_NONE = 0,

		/// <summary>
		/// This policy modifier offers two guarantees to a sync provider. First, it guarantees that the data returned by the sync
		/// provider is always persisted to the disk prior to it being returned to the user application. Second, it allows the sync
		/// provider to retrieve the same data it has returned previously to the platform and validate its integrity. Only upon a
		/// successful confirmation of the integrity by the sync provider will the platform complete the user I/O request. This modifier
		/// helps support end-to-end data integrity at the cost of extra disk I/Os.
		/// </summary>
		CF_HYDRATION_POLICY_MODIFIER_VALIDATION_REQUIRED = 1,

		/// <summary>
		/// This policy modifier grants the platform the permission to not store any data returned by a sync provider on local disks.
		/// This policy modifier is ineffective when being combined with CF_HYDRATION_POLICY_MODIFIER_VALIDATION_REQUIRED.
		/// </summary>
		CF_HYDRATION_POLICY_MODIFIER_STREAMING_ALLOWED = 2,

		/// <summary>
		/// Note This value is new for Windows 10, version 1803.This policy modifier grants the platform the permission to dehydrate
		/// in-sync cloud file placeholders without the help of sync providers. Without this flag, the platform is not allowed to call
		/// CfDehydratePlaceholder directly. Instead, the only supported way to dehydrate a cloud file placeholder is to clear the
		/// file’s pinned attribute and set the file’s unpinned attribute. At that point, the actual dehydration will be performed
		/// asynchronously by the sync engine after it receives the directory change notification on the two attributes. When this flag
		/// is specified, the platform will be allowed to invoke CfDehydratePlaceholder directly on any in-sync cloud file placeholder.
		/// It is recommended for sync providers to support auto-dehydration.
		/// </summary>
		CF_HYDRATION_POLICY_MODIFIER_AUTO_DEHYDRATION_ALLOWED = 4,
	}

	/// <summary>
	/// Allows a sync provider to control how placeholder files should be hydrated by the platform. This is the primary policy.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/cfapi/ne-cfapi-cf_hydration_policy_primary typedef enum
	// CF_HYDRATION_POLICY_PRIMARY { CF_HYDRATION_POLICY_PARTIAL, CF_HYDRATION_POLICY_PROGRESSIVE, CF_HYDRATION_POLICY_FULL,
	// CF_HYDRATION_POLICY_ALWAYS_FULL } ;
	[PInvokeData("cfapi.h", MSDNShortId = "47ACA107-80AA-42B3-B583-399323E2B11C")]
	public enum CF_HYDRATION_POLICY_PRIMARY : ushort
	{
		/// <summary>
		/// The same behavior as CF_HYDRATION_POLICY_PROGRESSIVE, except that CF_HYDRATION_POLICY_PARTIAL does not have continuous
		/// hydration in the background.
		/// </summary>
		CF_HYDRATION_POLICY_PARTIAL,

		/// <summary>
		/// When CF_HYDRATION_POLICY_PROGRESSIVE is selected, the platform will allow a placeholder to be dehydrated. When the platform
		/// detects access to a dehydrated placeholder, it will complete the user IO request as soon as it determines that sufficient
		/// data is received from the sync provider. However, the platform will continue requesting the remaining content in the
		/// placeholder from the sync provider in the background until either the full content of the placeholder is available locally,
		/// or the last user handle on the placeholder is closed.
		/// </summary>
		CF_HYDRATION_POLICY_PROGRESSIVE,

		/// <summary>
		/// When CF_HYDRATION_POLICY_FULL is selected, the platform will allow a placeholder to be dehydrated. When the platform detects
		/// access to a dehydrated placeholder, it will ensure that the full content of the placeholder is available locally before
		/// completing the user IO request, even if the request is only asking for 1 byte.
		/// </summary>
		CF_HYDRATION_POLICY_FULL,

		/// <summary>
		/// When CF_HYDRATION_POLICY_ALWAYS_FULL is selected, the platform will block any placeholder operation that could result in a
		/// not fully hydrated placeholder, which includes CfCreatePlaceholders, CfUpdatePlaceholder with the dehydrate option, and
		/// CfConvertToPlaceholder with the dehydrate option.
		/// </summary>
		CF_HYDRATION_POLICY_ALWAYS_FULL,
	}

	/// <summary>Specifies the in-sync state for placeholder files and folders.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/cfapi/ne-cfapi-cf_in_sync_state typedef enum CF_IN_SYNC_STATE {
	// CF_IN_SYNC_STATE_NOT_IN_SYNC, CF_IN_SYNC_STATE_IN_SYNC } ;
	[PInvokeData("cfapi.h", MSDNShortId = "05F99E47-00EE-422C-BDDF-CCCDDD4DADED")]
	public enum CF_IN_SYNC_STATE
	{
		/// <summary>The platform clears the placeholder’s in-sync state upon a successful return from the CfSetInSyncState call.</summary>
		CF_IN_SYNC_STATE_NOT_IN_SYNC,

		/// <summary>The platform sets the placeholder’s in-sync state upon a successful return from the CfSetInSyncState call.</summary>
		CF_IN_SYNC_STATE_IN_SYNC,
	}

	/// <summary>
	/// A policy allowing a sync provider to control when the platform should clear the in-sync state on a placeholder file or directory.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/cfapi/ne-cfapi-cf_insync_policy typedef enum CF_INSYNC_POLICY {
	// CF_INSYNC_POLICY_NONE, CF_INSYNC_POLICY_TRACK_FILE_CREATION_TIME, CF_INSYNC_POLICY_TRACK_FILE_READONLY_ATTRIBUTE,
	// CF_INSYNC_POLICY_TRACK_FILE_HIDDEN_ATTRIBUTE, CF_INSYNC_POLICY_TRACK_FILE_SYSTEM_ATTRIBUTE,
	// CF_INSYNC_POLICY_TRACK_DIRECTORY_CREATION_TIME, CF_INSYNC_POLICY_TRACK_DIRECTORY_READONLY_ATTRIBUTE,
	// CF_INSYNC_POLICY_TRACK_DIRECTORY_HIDDEN_ATTRIBUTE, CF_INSYNC_POLICY_TRACK_DIRECTORY_SYSTEM_ATTRIBUTE,
	// CF_INSYNC_POLICY_TRACK_FILE_LAST_WRITE_TIME, CF_INSYNC_POLICY_TRACK_DIRECTORY_LAST_WRITE_TIME, CF_INSYNC_POLICY_TRACK_FILE_ALL,
	// CF_INSYNC_POLICY_TRACK_DIRECTORY_ALL, CF_INSYNC_POLICY_TRACK_ALL, CF_INSYNC_POLICY_PRESERVE_INSYNC_FOR_SYNC_ENGINE } ;
	[PInvokeData("cfapi.h", MSDNShortId = "BE9574D7-2717-42F6-AB59-096AACCD8BC1")]
	[Flags]
	public enum CF_INSYNC_POLICY : uint
	{
		/// <summary/>
		CF_INSYNC_POLICY_NONE = 0x00000000,

		/// <summary>Clears in-sync state when a file is created.</summary>
		CF_INSYNC_POLICY_TRACK_FILE_CREATION_TIME = 0x00000001,

		/// <summary>Clears in-sync state when a file is read-only.</summary>
		CF_INSYNC_POLICY_TRACK_FILE_READONLY_ATTRIBUTE = 0x00000002,

		/// <summary>Clears in-sync state when a file is hidden.</summary>
		CF_INSYNC_POLICY_TRACK_FILE_HIDDEN_ATTRIBUTE = 0x00000004,

		/// <summary/>
		CF_INSYNC_POLICY_TRACK_FILE_SYSTEM_ATTRIBUTE = 0x00000008,

		/// <summary>Clears in-sync state when a directory is created.</summary>
		CF_INSYNC_POLICY_TRACK_DIRECTORY_CREATION_TIME = 0x00000010,

		/// <summary>Clears in-sync state when a directory is read-only.</summary>
		CF_INSYNC_POLICY_TRACK_DIRECTORY_READONLY_ATTRIBUTE = 0x00000020,

		/// <summary>Clears in-sync state when a directory is hidden.</summary>
		CF_INSYNC_POLICY_TRACK_DIRECTORY_HIDDEN_ATTRIBUTE = 0x00000040,

		/// <summary>Clears in-sync state when a directory is a system directory.</summary>
		CF_INSYNC_POLICY_TRACK_DIRECTORY_SYSTEM_ATTRIBUTE = 0x00000080,

		/// <summary>Clears in-sync state based on the last write time to a file.</summary>
		CF_INSYNC_POLICY_TRACK_FILE_LAST_WRITE_TIME = 0x00000100,

		/// <summary>Clears in-sync state based on the last write time to a directory.</summary>
		CF_INSYNC_POLICY_TRACK_DIRECTORY_LAST_WRITE_TIME = 0x00000200,

		/// <summary>Clears in-sync state for any changes to a file.</summary>
		CF_INSYNC_POLICY_TRACK_FILE_ALL = 0x0055550f,

		/// <summary>Clears in-sync state for any changes to a directory.</summary>
		CF_INSYNC_POLICY_TRACK_DIRECTORY_ALL = 0x00aaaaf0,

		/// <summary>Clears in-sync state for any changes to a file or directory.</summary>
		CF_INSYNC_POLICY_TRACK_ALL = 0x00ffffff,

		/// <summary>In-sync policies are exempt from clearing.</summary>
		CF_INSYNC_POLICY_PRESERVE_INSYNC_FOR_SYNC_ENGINE = 0x80000000,
	}

	/// <summary>Flags to request various permissions on opening a file.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/cfapi/ne-cfapi-cf_open_file_flags typedef enum CF_OPEN_FILE_FLAGS {
	// CF_OPEN_FILE_FLAG_NONE, CF_OPEN_FILE_FLAG_EXCLUSIVE, CF_OPEN_FILE_FLAG_WRITE_ACCESS, CF_OPEN_FILE_FLAG_DELETE_ACCESS,
	// CF_OPEN_FILE_FLAG_FOREGROUND } ;
	[PInvokeData("cfapi.h", MSDNShortId = "4A9D87AB-7B81-46DF-80C3-DB2F63C76964")]
	[Flags]
	public enum CF_OPEN_FILE_FLAGS
	{
		/// <summary>No open file flags.</summary>
		CF_OPEN_FILE_FLAG_NONE = 0,

		/// <summary>When specified, CfOpenFileWithOplock returns a share-none handle and requests an RH (OPLOCK_LEVEL_CACHE_READ</summary>
		CF_OPEN_FILE_FLAG_EXCLUSIVE = 1,

		/// <summary>
		/// When specified, CfOpenFileWithOplock attempts to open the file or directory with FILE_READ_DATA/FILE_LIST_DIRECTORY and
		/// FILE_WRITE_DATA/FILE_ADD_FILE access; otherwise it attempts to open the file or directory with FILE_READ_DATA/ FILE_LIST_DIRECTORY.
		/// </summary>
		CF_OPEN_FILE_FLAG_WRITE_ACCESS = 2,

		/// <summary>
		/// When specified, CfOpenFileWithOplock attempts to open the file or directory with DELETE access; otherwise it opens the file normally.
		/// </summary>
		CF_OPEN_FILE_FLAG_DELETE_ACCESS = 4,

		/// <summary/>
		CF_OPEN_FILE_FLAG_FOREGROUND = 8,
	}

	/// <summary>Flags to verify and acknowledge data for a placeholder file or folder.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/cfapi/ne-cfapi-cf_operation_ack_data_flags typedef enum
	// CF_OPERATION_ACK_DATA_FLAGS { CF_OPERATION_ACK_DATA_FLAG_NONE } ;
	[PInvokeData("cfapi.h", MSDNShortId = "9465B686-7C8A-44AD-BC65-41F22FFEC741")]
	[Flags]
	public enum CF_OPERATION_ACK_DATA_FLAGS
	{
		/// <summary>No acknowledge data flag.</summary>
		CF_OPERATION_ACK_DATA_FLAG_NONE = 0,
	}

	/// <summary>Flags to acknowledge the dehydration of a placeholder file or directory.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/cfapi/ne-cfapi-cf_operation_ack_dehydrate_flags typedef enum
	// CF_OPERATION_ACK_DEHYDRATE_FLAGS { CF_OPERATION_ACK_DEHYDRATE_FLAG_NONE } ;
	[PInvokeData("cfapi.h", MSDNShortId = "A1236139-947A-4360-91A0-E634A22C26A5")]
	[Flags]
	public enum CF_OPERATION_ACK_DEHYDRATE_FLAGS
	{
		/// <summary>No acknowledge dehydration flag.</summary>
		CF_OPERATION_ACK_DEHYDRATE_FLAG_NONE = 0,
	}

	/// <summary>Flags to acknowledge the deletion of a placeholder file or directory.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/cfapi/ne-cfapi-cf_operation_ack_delete_flags typedef enum
	// CF_OPERATION_ACK_DELETE_FLAGS { CF_OPERATION_ACK_DELETE_FLAG_NONE } ;
	[PInvokeData("cfapi.h", MSDNShortId = "407B7035-09A0-43BC-AC07-2CC0973DDBCC")]
	[Flags]
	public enum CF_OPERATION_ACK_DELETE_FLAGS
	{
		/// <summary>No deletion acknowledgment flags.</summary>
		CF_OPERATION_ACK_DELETE_FLAG_NONE = 0,
	}

	/// <summary>Flags for acknowledging placeholder file or directory renaming.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/cfapi/ne-cfapi-cf_operation_ack_rename_flags typedef enum
	// CF_OPERATION_ACK_RENAME_FLAGS { CF_OPERATION_ACK_RENAME_FLAG_NONE } ;
	[PInvokeData("cfapi.h", MSDNShortId = "2EAABBAE-8737-4399-8C39-7D63B45C52B3")]
	[Flags]
	public enum CF_OPERATION_ACK_RENAME_FLAGS
	{
		/// <summary>No acknowledgment of placeholder renaming.</summary>
		CF_OPERATION_ACK_RENAME_FLAG_NONE = 0,
	}

	/// <summary>Flags to restart data hydration on a placeholder file or folder.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/cfapi/ne-cfapi-cf_operation_restart_hydration_flags typedef enum
	// CF_OPERATION_RESTART_HYDRATION_FLAGS { CF_OPERATION_RESTART_HYDRATION_FLAG_NONE, CF_OPERATION_RESTART_HYDRATION_FLAG_MARK_IN_SYNC
	// } ;
	[PInvokeData("cfapi.h", MSDNShortId = "4112937A-3ED6-48F8-BFD1-52D01ABA3D72")]
	[Flags]
	public enum CF_OPERATION_RESTART_HYDRATION_FLAGS
	{
		/// <summary>No restart data hydration flag.</summary>
		CF_OPERATION_RESTART_HYDRATION_FLAG_NONE = 0,

		/// <summary>If this flag is specified, the placeholder will be marked in-sync upon a successful RESTART_HYDRATION operation.</summary>
		CF_OPERATION_RESTART_HYDRATION_FLAG_MARK_IN_SYNC = 1,
	}

	/// <summary>Flags to retrieve data for a placeholder file or folder.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/cfapi/ne-cfapi-cf_operation_retrieve_data_flags typedef enum
	// CF_OPERATION_RETRIEVE_DATA_FLAGS { CF_OPERATION_RETRIEVE_DATA_FLAG_NONE } ;
	[PInvokeData("cfapi.h", MSDNShortId = "A233B2E8-B350-495A-9688-3795790F23EF")]
	[Flags]
	public enum CF_OPERATION_RETRIEVE_DATA_FLAGS
	{
		/// <summary>No retrieve data flag.</summary>
		CF_OPERATION_RETRIEVE_DATA_FLAG_NONE = 0,
	}

	/// <summary>Flags to transfer data to hydrate a placeholder file or folder.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/cfapi/ne-cfapi-cf_operation_transfer_data_flags typedef enum
	// CF_OPERATION_TRANSFER_DATA_FLAGS { CF_OPERATION_TRANSFER_DATA_FLAG_NONE } ;
	[PInvokeData("cfapi.h", MSDNShortId = "6273CB7A-80B9-4E9A-8C3A-5308F59BB335")]
	[Flags]
	public enum CF_OPERATION_TRANSFER_DATA_FLAGS
	{
		/// <summary>No transfer data flag.</summary>
		CF_OPERATION_TRANSFER_DATA_FLAG_NONE = 0,
	}

	/// <summary>Flags to specify the behavior when transferring a placeholder file or directory.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/cfapi/ne-cfapi-cf_operation_transfer_placeholders_flags typedef enum
	// CF_OPERATION_TRANSFER_PLACEHOLDERS_FLAGS { CF_OPERATION_TRANSFER_PLACEHOLDERS_FLAG_NONE,
	// CF_OPERATION_TRANSFER_PLACEHOLDERS_FLAG_STOP_ON_ERROR, CF_OPERATION_TRANSFER_PLACEHOLDERS_FLAG_DISABLE_ON_DEMAND_POPULATION } ;
	[PInvokeData("cfapi.h", MSDNShortId = "6C75030D-A5CF-423D-A931-3D2ED6113BD1")]
	[Flags]
	public enum CF_OPERATION_TRANSFER_PLACEHOLDERS_FLAGS
	{
		/// <summary>No transfer placeholder flags.</summary>
		CF_OPERATION_TRANSFER_PLACEHOLDERS_FLAG_NONE = 0,

		/// <summary>
		/// Causes the API to return immediately if a placeholder transfer fails. If a transfer fails, the error code will be returned.
		/// </summary>
		CF_OPERATION_TRANSFER_PLACEHOLDERS_FLAG_STOP_ON_ERROR = 1,

		/// <summary>
		/// The transferred child placeholder directory is considered to have all of its children present locally.Applicable to a child
		/// placeholder directory only.
		/// </summary>
		CF_OPERATION_TRANSFER_PLACEHOLDERS_FLAG_DISABLE_ON_DEMAND_POPULATION = 2,
	}

	/// <summary>The types of operations that can be performed on placeholder files and directories.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/cfapi/ne-cfapi-cf_operation_type typedef enum CF_OPERATION_TYPE {
	// CF_OPERATION_TYPE_TRANSFER_DATA, CF_OPERATION_TYPE_RETRIEVE_DATA, CF_OPERATION_TYPE_ACK_DATA,
	// CF_OPERATION_TYPE_RESTART_HYDRATION, CF_OPERATION_TYPE_TRANSFER_PLACEHOLDERS, CF_OPERATION_TYPE_ACK_DEHYDRATE,
	// CF_OPERATION_TYPE_ACK_DELETE, CF_OPERATION_TYPE_ACK_RENAME } ;
	[PInvokeData("cfapi.h", MSDNShortId = "34E23442-1BCC-4B8B-9AD3-67B2AEDBE2FE")]
	public enum CF_OPERATION_TYPE
	{
		/// <summary>Transfers data to hydrate a placeholder.</summary>
		CF_OPERATION_TYPE_TRANSFER_DATA,

		/// <summary>Validates the integrity of data previously transferred to a placeholder.</summary>
		CF_OPERATION_TYPE_RETRIEVE_DATA,

		/// <summary>Data is acknowledged by the sync provider.</summary>
		CF_OPERATION_TYPE_ACK_DATA,

		/// <summary>Restarts ongoing data hydration.</summary>
		CF_OPERATION_TYPE_RESTART_HYDRATION,

		/// <summary>Transfers placeholders.</summary>
		CF_OPERATION_TYPE_TRANSFER_PLACEHOLDERS,

		/// <summary>Acknowledge and dehydrate a placeholder.</summary>
		CF_OPERATION_TYPE_ACK_DEHYDRATE,

		/// <summary>Acknowledge and delete a placeholder.</summary>
		CF_OPERATION_TYPE_ACK_DELETE,

		/// <summary>Acknowledge and rename a placeholder.</summary>
		CF_OPERATION_TYPE_ACK_RENAME,
	}

	/// <summary>Pin states of a placeholder file or directory.</summary>
	/// <remarks>
	/// <list type="table">
	/// <listheader>
	/// <term/>
	/// <term>Parent</term>
	/// <term>Unspecified</term>
	/// <term>Pinned</term>
	/// <term>Unpinned</term>
	/// <term>Excluded</term>
	/// </listheader>
	/// <item>
	/// <term>File</term>
	/// <term>Unspecified</term>
	/// <term>Unspecified</term>
	/// <term>Pinned</term>
	/// <term>Unspecified</term>
	/// <term>Excluded</term>
	/// </item>
	/// <item>
	/// <term/>
	/// <term>Pinned</term>
	/// <term>Pinned</term>
	/// <term>Pinned</term>
	/// <term>Pinned</term>
	/// <term>Excluded</term>
	/// </item>
	/// <item>
	/// <term/>
	/// <term>Unpinned</term>
	/// <term>Unpinned</term>
	/// <term>Unpinned</term>
	/// <term>Unpinned</term>
	/// <term>Excluded</term>
	/// </item>
	/// <item>
	/// <term/>
	/// <term>Excluded</term>
	/// <term>Unspecified</term>
	/// <term>Pinned</term>
	/// <term>Unspecified</term>
	/// <term>Excluded</term>
	/// </item>
	/// <item>
	/// <term>Directory</term>
	/// <term>Unspecified</term>
	/// <term>Unspecified</term>
	/// <term>Pinned</term>
	/// <term>Unpinned</term>
	/// <term>Excluded</term>
	/// </item>
	/// <item>
	/// <term/>
	/// <term>Pinned</term>
	/// <term>Pinned</term>
	/// <term>Pinned</term>
	/// <term>Pinned</term>
	/// <term>Excluded</term>
	/// </item>
	/// <item>
	/// <term/>
	/// <term>Unpinned</term>
	/// <term>Unpinned</term>
	/// <term>Unpinned</term>
	/// <term>Unpinned</term>
	/// <term>Excluded</term>
	/// </item>
	/// <item>
	/// <term/>
	/// <term>Excluded</term>
	/// <term>Unspecified</term>
	/// <term>Pinned</term>
	/// <term>Unpinned</term>
	/// <term>Excluded</term>
	/// </item>
	/// </list>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/cfapi/ne-cfapi-cf_pin_state typedef enum CF_PIN_STATE {
	// CF_PIN_STATE_UNSPECIFIED, CF_PIN_STATE_PINNED, CF_PIN_STATE_UNPINNED, CF_PIN_STATE_EXCLUDED, CF_PIN_STATE_INHERIT } ;
	[PInvokeData("cfapi.h", MSDNShortId = "F3074C9A-2805-47DE-9BA0-D7E02C4FF030")]
	public enum CF_PIN_STATE
	{
		/// <summary>The platform can decide freely when the placeholder’s content needs to present or absent locally on the disk.</summary>
		CF_PIN_STATE_UNSPECIFIED,

		/// <summary>
		/// The sync provider will be notified to fetch the placeholder’s content asynchronously after the pin request is received by
		/// the platform. There is no guarantee that the placeholders to be pinned will be fully available locally after a CfSetPinState
		/// call completes successfully. However, the platform will fail any dehydration request on pinned placeholders.
		/// </summary>
		CF_PIN_STATE_PINNED,

		/// <summary>
		/// The sync provider will be notified to dehydrate/invalidate the placeholder’s content on-disk asynchronously after the unpin
		/// request is received by the platform. There is no guarantee that the placeholders to be unpinned will be fully dehydrated
		/// after the API call completes successfully.
		/// </summary>
		CF_PIN_STATE_UNPINNED,

		/// <summary>
		/// the placeholder will never be synced to the cloud by the sync provider. This state can only be set by the sync provider.
		/// </summary>
		CF_PIN_STATE_EXCLUDED,

		/// <summary>
		/// The platform treats it as if the caller performs a move operation on the placeholder and hence re-evaluates the
		/// placeholder’s pin state based on its parent’s pin state. See the Remarks section for an inheritance table.
		/// </summary>
		CF_PIN_STATE_INHERIT,
	}

	/// <summary>Flags for creating a placeholder on a per-placeholder basis.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/cfapi/ne-cfapi-cf_placeholder_create_flags typedef enum
	// CF_PLACEHOLDER_CREATE_FLAGS { CF_PLACEHOLDER_CREATE_FLAG_NONE, CF_PLACEHOLDER_CREATE_FLAG_DISABLE_ON_DEMAND_POPULATION,
	// CF_PLACEHOLDER_CREATE_FLAG_MARK_IN_SYNC, CF_PLACEHOLDER_CREATE_FLAG_SUPERSEDE } ;
	[PInvokeData("cfapi.h", MSDNShortId = "7DB55949-E209-490C-9FF9-53E1D72CD0FA")]
	[Flags]
	public enum CF_PLACEHOLDER_CREATE_FLAGS
	{
		/// <summary>No placeholder create flags.</summary>
		CF_PLACEHOLDER_CREATE_FLAG_NONE = 0,

		/// <summary>
		/// The newly created child placeholder directory is considered to have all of its children present locally. Applicable to a
		/// child placeholder directory only.
		/// </summary>
		CF_PLACEHOLDER_CREATE_FLAG_DISABLE_ON_DEMAND_POPULATION = 1,

		/// <summary>The newly created placeholder is marked as in-sync. Applicable to both placeholder files and directories.</summary>
		CF_PLACEHOLDER_CREATE_FLAG_MARK_IN_SYNC = 2,

		/// <summary/>
		CF_PLACEHOLDER_CREATE_FLAG_SUPERSEDE = 4,
	}

	/// <summary>Information classes for placeholder info.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/cfapi/ne-cfapi-cf_placeholder_info_class typedef enum
	// CF_PLACEHOLDER_INFO_CLASS { CF_PLACEHOLDER_INFO_BASIC, CF_PLACEHOLDER_INFO_STANDARD } ;
	[PInvokeData("cfapi.h", MSDNShortId = "DA05148F-3EF0-4CC3-9233-883859FA00F1")]
	public enum CF_PLACEHOLDER_INFO_CLASS
	{
		/// <summary>Basic placeholder information. See CF_PLACEHOLDER_BASIC_INFO.</summary>
		[CorrespondingType(typeof(CF_PLACEHOLDER_BASIC_INFO), CorrespondingAction.Get)]
		CF_PLACEHOLDER_INFO_BASIC,

		/// <summary>Standard placeholder information. See CF_PLACEHOLDER_STANDARD_INFO.</summary>
		[CorrespondingType(typeof(CF_PLACEHOLDER_STANDARD_INFO), CorrespondingAction.Get)]
		CF_PLACEHOLDER_INFO_STANDARD,
	}

	/// <summary>Types of the range of placeholder file data.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/cfapi/ne-cfapi-cf_placeholder_range_info_class typedef enum
	// CF_PLACEHOLDER_RANGE_INFO_CLASS { CF_PLACEHOLDER_RANGE_INFO_ONDISK, CF_PLACEHOLDER_RANGE_INFO_VALIDATED,
	// CF_PLACEHOLDER_RANGE_INFO_MODIFIED } ;
	[PInvokeData("cfapi.h", MSDNShortId = "04533C98-894C-422F-9BE5-F2746BF13567")]
	public enum CF_PLACEHOLDER_RANGE_INFO_CLASS
	{
		/// <summary>On-disk data is data that is physical present in the file, which is a super set of other types of ranges.</summary>
		CF_PLACEHOLDER_RANGE_INFO_ONDISK = 1,

		/// <summary>Validated data is a subset of the on-disk data that is currently in sync with the cloud.</summary>
		CF_PLACEHOLDER_RANGE_INFO_VALIDATED,

		/// <summary>
		/// Modified data is a subset of the on-disk data that is currently not in sync with the cloud, i.e., either modified or appended.
		/// </summary>
		CF_PLACEHOLDER_RANGE_INFO_MODIFIED,
	}

	/// <summary>The state of a placeholder file or folder.</summary>
	/// <remarks>
	/// Placeholder state information can be obtained by calling: CfGetPlaceholderStateFromAttributeTag,
	/// CfGetPlaceholderStateFromFileInfo, or CfGetPlaceholderStateFromFindData.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/cfapi/ne-cfapi-cf_placeholder_state typedef enum CF_PLACEHOLDER_STATE {
	// CF_PLACEHOLDER_STATE_NO_STATES, CF_PLACEHOLDER_STATE_PLACEHOLDER, CF_PLACEHOLDER_STATE_SYNC_ROOT,
	// CF_PLACEHOLDER_STATE_ESSENTIAL_PROP_PRESENT, CF_PLACEHOLDER_STATE_IN_SYNC, CF_PLACEHOLDER_STATE_PARTIAL,
	// CF_PLACEHOLDER_STATE_PARTIALLY_ON_DISK, CF_PLACEHOLDER_STATE_INVALID } ;
	[PInvokeData("cfapi.h", MSDNShortId = "5E814458-2045-4CFD-90AC-F1F53DEB4FD0")]
	[Flags]
	public enum CF_PLACEHOLDER_STATE : uint
	{
		/// <summary>When returned, the file or directory whose FileAttributes and ReparseTag examined by the API is not a placeholder.</summary>
		CF_PLACEHOLDER_STATE_NO_STATES = 0x00000000,

		/// <summary>The file or directory whose FileAttributes and ReparseTag examined by the API is a placeholder.</summary>
		CF_PLACEHOLDER_STATE_PLACEHOLDER = 0x00000001,

		/// <summary>The directory is both a placeholder directory as well as the sync root.</summary>
		CF_PLACEHOLDER_STATE_SYNC_ROOT = 0x00000002,

		/// <summary>
		/// The file or directory must be a placeholder and there exists an essential property in the property store of the file or directory.
		/// </summary>
		CF_PLACEHOLDER_STATE_ESSENTIAL_PROP_PRESENT = 0x00000004,

		/// <summary>The file or directory must be a placeholder and its content in sync with the cloud.</summary>
		CF_PLACEHOLDER_STATE_IN_SYNC = 0x00000008,

		/// <summary>
		/// The file or directory must be a placeholder and its content is not ready to be consumed by the user application, though it
		/// may or may not be fully present locally. An example is a placeholder file whose content has been fully downloaded to the
		/// local disk, but is yet to be validated by a sync provider that has registered the sync root with the hydration modifier VERIFICATION_REQUIRED.
		/// </summary>
		CF_PLACEHOLDER_STATE_PARTIAL = 0x00000010,

		/// <summary>
		/// The file or directory must be a placeholder and its content is not fully present locally. When this is set,
		/// CF_PLACEHOLDER_STATE_PARTIAL must also be set.
		/// </summary>
		CF_PLACEHOLDER_STATE_PARTIALLY_ON_DISK = 0x00000020,

		/// <summary>This is an invalid state when the API fails to parse the information of the file or directory.</summary>
		CF_PLACEHOLDER_STATE_INVALID = 0xffffffff,
	}

	/// <summary>Defines the population policy modifiers. This is a modifier that can be used with the primary policy: CF_POPULATION_POLICY_PRIMARY.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/cfapi/ne-cfapi-cf_population_policy_modifier typedef enum
	// CF_POPULATION_POLICY_MODIFIER { CF_POPULATION_POLICY_MODIFIER_NONE } ;
	[PInvokeData("cfapi.h", MSDNShortId = "E8F8066C-BAAE-4576-BA8F-49074F7C3C8F")]
	[Flags]
	public enum CF_POPULATION_POLICY_MODIFIER : ushort
	{
		/// <summary>No policy modifier.</summary>
		CF_POPULATION_POLICY_MODIFIER_NONE = 0,
	}

	/// <summary>
	/// Allows a sync provider to control how placeholder directories and files should be created by the platform. This is the primary policy.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/cfapi/ne-cfapi-cf_population_policy_primary typedef enum
	// CF_POPULATION_POLICY_PRIMARY { CF_POPULATION_POLICY_PARTIAL, CF_POPULATION_POLICY_FULL, CF_POPULATION_POLICY_ALWAYS_FULL } ;
	[PInvokeData("cfapi.h", MSDNShortId = "3EDCDE3D-AD47-4C4B-9F83-C89879D668DA")]
	public enum CF_POPULATION_POLICY_PRIMARY : ushort
	{
		/// <summary>
		/// With CF_POPULATION_POLICY_PARTIAL population policy, when the platform detects access on a not fully populated directory, it
		/// will request only the entries required by the user application from the sync provider. This policy is not currently
		/// supported by the platform.
		/// </summary>
		CF_POPULATION_POLICY_PARTIAL = 0,

		/// <summary>
		/// With CF_POPULATION_POLICY_FULL population policy, when the platform detects access on a not fully populated directory, it
		/// will request the sync provider return all entries under the directory before completing the user request.
		/// </summary>
		CF_POPULATION_POLICY_FULL = 2,

		/// <summary>
		/// When CF_POPULATION_POLICY_ALWAYS_FULL is selected, the platform assumes that the full name space is always available
		/// locally. It will never forward any directory enumeration request to the sync provider.
		/// </summary>
		CF_POPULATION_POLICY_ALWAYS_FULL = 3,
	}

	/// <summary>Flags for registering and updating a sync root.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/cfapi/ne-cfapi-cf_register_flags typedef enum CF_REGISTER_FLAGS {
	// CF_REGISTER_FLAG_NONE, CF_REGISTER_FLAG_UPDATE, CF_REGISTER_FLAG_DISABLE_ON_DEMAND_POPULATION_ON_ROOT,
	// CF_REGISTER_FLAG_MARK_IN_SYNC_ON_ROOT } ;
	[PInvokeData("cfapi.h", MSDNShortId = "043670D7-5908-40B5-82A8-EFF05FCB391B")]
	[Flags]
	public enum CF_REGISTER_FLAGS
	{
		/// <summary>No registration flags.</summary>
		CF_REGISTER_FLAG_NONE = 0,

		/// <summary>Use this flag for modifying previously registered sync root identities and policies.</summary>
		CF_REGISTER_FLAG_UPDATE = 1,

		/// <summary>
		/// The on-demand directory/folder population behavior is globally controlled by the population policy. This flag allows a sync
		/// provider to opt out of the on-demand population behavior just for the sync root itself while keeping on-demand population on
		/// for all other directories under the sync root. This is useful when the sync provider would like to pre-populate the
		/// immediate child files/directories of the sync root.
		/// </summary>
		CF_REGISTER_FLAG_DISABLE_ON_DEMAND_POPULATION_ON_ROOT = 2,

		/// <summary>
		/// This flag allows a sync provider to mark the sync root to be registered in-sync simultaneously at the registration time. An
		/// alternative is to call CfSetInSyncState on the sync root later.
		/// </summary>
		CF_REGISTER_FLAG_MARK_IN_SYNC_ON_ROOT = 4,
	}

	/// <summary>Flags for reverting a placeholder file to a regular file.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/cfapi/ne-cfapi-cf_revert_flags typedef enum CF_REVERT_FLAGS {
	// CF_REVERT_FLAG_NONE } ;
	[PInvokeData("cfapi.h", MSDNShortId = "71FDE7FA-99FC-4773-A857-8E1BF89ED7E4")]
	[Flags]
	public enum CF_REVERT_FLAGS
	{
		/// <summary>No placeholder revert flags.</summary>
		CF_REVERT_FLAG_NONE = 0,
	}

	/// <summary>The in-sync state flags for placeholder files and folders.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/cfapi/ne-cfapi-cf_set_in_sync_flags typedef enum CF_SET_IN_SYNC_FLAGS {
	// CF_SET_IN_SYNC_FLAG_NONE } ;
	[PInvokeData("cfapi.h", MSDNShortId = "55A20F07-0B3E-4C1D-9E59-288DAE08D134")]
	[Flags]
	public enum CF_SET_IN_SYNC_FLAGS
	{
		/// <summary>No in-sync flag.</summary>
		CF_SET_IN_SYNC_FLAG_NONE = 0,
	}

	/// <summary>The placeholder pin flags.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/cfapi/ne-cfapi-cf_set_pin_flags typedef enum CF_SET_PIN_FLAGS {
	// CF_SET_PIN_FLAG_NONE, CF_SET_PIN_FLAG_RECURSE, CF_SET_PIN_FLAG_RECURSE_ONLY, CF_SET_PIN_FLAG_RECURSE_STOP_ON_ERROR } ;
	[PInvokeData("cfapi.h", MSDNShortId = "6766931E-B2D4-4166-9B6E-E6D8F57E57B3")]
	[Flags]
	public enum CF_SET_PIN_FLAGS
	{
		/// <summary>No pin flag.</summary>
		CF_SET_PIN_FLAG_NONE = 0,

		/// <summary>
		/// The platform applies the pin state to the placeholder FileHandle and every file recursively beneath it (relevant only if
		/// FileHandle is a handle to a directory).
		/// </summary>
		CF_SET_PIN_FLAG_RECURSE = 1,

		/// <summary>
		/// The platform applies the pin state to every file recursively beneath the placeholder FileHandle, but not to FileHandle itself.
		/// </summary>
		CF_SET_PIN_FLAG_RECURSE_ONLY = 2,

		/// <summary>
		/// The platform will stop the recursion when encountering the first error; otherwise the platform skips the error and continues
		/// the recursion.
		/// </summary>
		CF_SET_PIN_FLAG_RECURSE_STOP_ON_ERROR = 4,
	}

	/// <summary>Current status of a sync provider.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/cfapi/ne-cfapi-cf_sync_provider_status typedef enum CF_SYNC_PROVIDER_STATUS {
	// CF_PROVIDER_STATUS_DISCONNECTED, CF_PROVIDER_STATUS_IDLE, CF_PROVIDER_STATUS_POPULATE_NAMESPACE,
	// CF_PROVIDER_STATUS_POPULATE_METADATA, CF_PROVIDER_STATUS_POPULATE_CONTENT, CF_PROVIDER_STATUS_SYNC_INCREMENTAL,
	// CF_PROVIDER_STATUS_SYNC_FULL, CF_PROVIDER_STATUS_CONNECTIVITY_LOST, CF_PROVIDER_STATUS_CLEAR_FLAGS,
	// CF_PROVIDER_STATUS_TERMINATED, CF_PROVIDER_STATUS_ERROR } ;
	[PInvokeData("cfapi.h", MSDNShortId = "575A9F66-66D4-4443-9BCB-0CBD60DA27A0")]
	[Flags]
	public enum CF_SYNC_PROVIDER_STATUS : uint
	{
		/// <summary>The sync provider is disconnected.</summary>
		CF_PROVIDER_STATUS_DISCONNECTED = 0x00000000,

		/// <summary>The sync provider is idle.</summary>
		CF_PROVIDER_STATUS_IDLE = 0x00000001,

		/// <summary>The sync provider is populating a namespace.</summary>
		CF_PROVIDER_STATUS_POPULATE_NAMESPACE = 0x00000002,

		/// <summary>The sync provider is populating placeholder metadata.</summary>
		CF_PROVIDER_STATUS_POPULATE_METADATA = 0x00000004,

		/// <summary>The sync provider is populating placeholder content.</summary>
		CF_PROVIDER_STATUS_POPULATE_CONTENT = 0x00000008,

		/// <summary>The sync provider is incrementally syncing placeholder content.</summary>
		CF_PROVIDER_STATUS_SYNC_INCREMENTAL = 0x00000010,

		/// <summary>The sync provider has fully synced placeholder file data.</summary>
		CF_PROVIDER_STATUS_SYNC_FULL = 0x00000020,

		/// <summary>The sync provider has lost connectivity.</summary>
		CF_PROVIDER_STATUS_CONNECTIVITY_LOST = 0x00000040,

		/// <summary>Clears the flags of the sync provider.</summary>
		CF_PROVIDER_STATUS_CLEAR_FLAGS = 0x80000000,

		/// <summary/>
		CF_PROVIDER_STATUS_TERMINATED = 0xC0000001,

		/// <summary/>
		CF_PROVIDER_STATUS_ERROR = 0xC0000002,
	}

	/// <summary>Types of sync root information.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/cfapi/ne-cfapi-cf_sync_root_info_class typedef enum CF_SYNC_ROOT_INFO_CLASS {
	// CF_SYNC_ROOT_INFO_BASIC, CF_SYNC_ROOT_INFO_STANDARD, CF_SYNC_ROOT_INFO_PROVIDER } ;
	[PInvokeData("cfapi.h", MSDNShortId = "4415E075-048E-4B9F-B293-5F7A63CAE3A4")]
	public enum CF_SYNC_ROOT_INFO_CLASS
	{
		/// <summary>Basic sync root information. See CF_SYNC_ROOT_BASIC_INFO.</summary>
		[CorrespondingType(typeof(CF_SYNC_ROOT_BASIC_INFO), CorrespondingAction.Get)]
		CF_SYNC_ROOT_INFO_BASIC,

		/// <summary>Standard sync root information. See CF_SYNC_ROOT_STANDARD_INFO.</summary>
		[CorrespondingType(typeof(CF_SYNC_ROOT_STANDARD_INFO), CorrespondingAction.Get)]
		CF_SYNC_ROOT_INFO_STANDARD,

		/// <summary>Sync root provider information. See CF_SYNC_ROOT_PROVIDER_INFO.</summary>
		[CorrespondingType(typeof(CF_SYNC_ROOT_PROVIDER_INFO), CorrespondingAction.Get)]
		CF_SYNC_ROOT_INFO_PROVIDER,
	}

	/// <summary>Flags for updating a placeholder file or directory.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/cfapi/ne-cfapi-cf_update_flags typedef enum CF_UPDATE_FLAGS {
	// CF_UPDATE_FLAG_NONE, CF_UPDATE_FLAG_VERIFY_IN_SYNC, CF_UPDATE_FLAG_MARK_IN_SYNC, CF_UPDATE_FLAG_DEHYDRATE,
	// CF_UPDATE_FLAG_ENABLE_ON_DEMAND_POPULATION, CF_UPDATE_FLAG_DISABLE_ON_DEMAND_POPULATION, CF_UPDATE_FLAG_REMOVE_FILE_IDENTITY,
	// CF_UPDATE_FLAG_CLEAR_IN_SYNC, CF_UPDATE_FLAG_REMOVE_PROPERTY, CF_UPDATE_FLAG_PASSTHROUGH_FS_METADATA } ;
	[PInvokeData("cfapi.h", MSDNShortId = "83EBEF22-9EAE-4B51-AA23-325FA96EB070")]
	[Flags]
	public enum CF_UPDATE_FLAGS : uint
	{
		/// <summary>No update flags.</summary>
		CF_UPDATE_FLAG_NONE = 0x00000000,

		/// <summary>
		/// The update will fail if the CF_UPDATE_FLAG_MARK_IN_SYNC attribute is not currently set on the placeholder. This is to
		/// prevent a race between syncing changes from the cloud down to a local placeholder and the placeholder’s data stream getting
		/// locally modified.
		/// </summary>
		CF_UPDATE_FLAG_VERIFY_IN_SYNC = 0x00000001,

		/// <summary>The platform marks the placeholder as in-sync upon a successful update placeholder operation.</summary>
		CF_UPDATE_FLAG_MARK_IN_SYNC = 0x00000002,

		/// <summary>
		/// Applicable to files only. When specified, the platform dehydrates the file after updating the placeholder successfully. The
		/// caller must acquire an exclusive handle when specifying this flag or data corruptions can occur. Note that the platform does
		/// not validate the exclusiveness of the handle.
		/// </summary>
		CF_UPDATE_FLAG_DEHYDRATE = 0x00000004,

		/// <summary>
		/// Applicable to directories only. When specified, it marks the updated placeholder directory partially populated such that any
		/// future access to it will result in a FETCH_PLACEHOLDERS callback sent to the sync provider.
		/// </summary>
		CF_UPDATE_FLAG_ENABLE_ON_DEMAND_POPULATION = 0x00000008,

		/// <summary>
		/// Applicable to directories only. When specified, it marks the updated placeholder directory fully populated such that any
		/// future access to it will be handled by the platform without any callbacks to the sync provider.
		/// </summary>
		CF_UPDATE_FLAG_DISABLE_ON_DEMAND_POPULATION = 0x00000010,

		/// <summary>
		/// When specified, FileIdentity and FileIdentityLength in CfUpdatePlaceholder are ignored and the platform will remove the
		/// existing file identity blob on the placeholder upon a successful update call.
		/// </summary>
		CF_UPDATE_FLAG_REMOVE_FILE_IDENTITY = 0x00000020,

		/// <summary>The platform marks the placeholder as not in-sync upon a successful update placeholder operation.</summary>
		CF_UPDATE_FLAG_CLEAR_IN_SYNC = 0x00000040,

		/// <summary>
		/// Note This value is new for Windows 10, version 1803.The platform removes all existing extrinsic properties on the placeholder.
		/// </summary>
		CF_UPDATE_FLAG_REMOVE_PROPERTY = 0x00000080,

		/// <summary>
		/// Note This value is new for Windows 10, version 1803.The platform passes CF_FS_METADATA to the file system without any
		/// filtering; otherwise, the platform skips setting any fields whose value is 0.
		/// </summary>
		CF_UPDATE_FLAG_PASSTHROUGH_FS_METADATA = 0x00000100,

		/// <summary>
		/// Effective on placeholder files only. Marks the placeholder always full.  
		/// Once hydrated, any attempt to dehydrate will fail with
		/// ERROR_CLOUD_FILE_DEHYDRATION_DISALLOWED.
		/// </summary>
		CF_UPDATE_FLAG_ALWAYS_FULL = 0x00000200,

		/// <summary>
		/// Effective on placeholder files only. Clears the always‑full state, allowing
		/// dehydration again. Cannot be combined with CF_UPDATE_FLAG_ALWAYS_FULL; doing
		/// so returns ERROR_CLOUD_FILE_INVALID_REQUEST.
		/// </summary>
		CF_UPDATE_FLAG_ALLOW_PARTIAL = 0x00000400,

	}

	/// <summary>Contains common callback information.</summary>
	/// <remarks>
	/// <para>A file name is considered normalized if all of the following are true:</para>
	/// <list type="bullet">
	/// <item>
	/// <term>
	/// It contains the full directory path for the file, including the volume name, unless the user opened the file by file ID but does
	/// not have traverse privilege for the entire path. (For more information, see FltGetFileNameInformation.)
	/// </term>
	/// </item>
	/// <item>
	/// <term>The volume name is the volume's non-persistent device object name (for example, "\Device\HarddiskVolume1").</term>
	/// </item>
	/// <item>
	/// <term>All short names are expanded to the equivalent long names.</term>
	/// </item>
	/// <item>
	/// <term>Any trailing ":$DATA" or "::$DATA" strings are removed from the stream name.</term>
	/// </item>
	/// <item>
	/// <term>All mount points are resolved.</term>
	/// </item>
	/// </list>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/cfapi/ns-cfapi-cf_callback_info typedef struct CF_CALLBACK_INFO { DWORD
	// StructSize; CF_CONNECTION_KEY ConnectionKey; LPVOID CallbackContext; PCWSTR VolumeGuidName; PCWSTR VolumeDosName; DWORD
	// VolumeSerialNumber; LARGE_INTEGER SyncRootFileId; LPCVOID SyncRootIdentity; DWORD SyncRootIdentityLength; LARGE_INTEGER FileId;
	// LARGE_INTEGER FileSize; LPCVOID FileIdentity; DWORD FileIdentityLength; PCWSTR NormalizedPath; CF_TRANSFER_KEY TransferKey; UCHAR
	// PriorityHint; PCORRELATION_VECTOR CorrelationVector; CF_PROCESS_INFO *ProcessInfo; CF_REQUEST_KEY RequestKey; } CF_CALLBACK_INFO;
	[PInvokeData("cfapi.h", MSDNShortId = "EF24E61E-4AF7-4946-A326-1F045267AE01")]
	[StructLayout(LayoutKind.Sequential)]
	public struct CF_CALLBACK_INFO
	{
		/// <summary>The size of the structure.</summary>
		public uint StructSize;

		/// <summary>An opaque handle created by CfConnectSyncRoot for a sync root managed by the sync provider.</summary>
		public CF_CONNECTION_KEY ConnectionKey;

		/// <summary>points to an opaque blob that the sync provider provides at the sync root connect time.</summary>
		public IntPtr CallbackContext;

		/// <summary>GUID name of the volume on which the placeholder file/directory to be serviced resides. It is in the form: “\?\Volume{GUID}”.</summary>
		[MarshalAs(UnmanagedType.LPWStr)] public string VolumeGuidName;

		/// <summary>DOS drive letter of the volume in the form of “X:” where X is the drive letter.</summary>
		[MarshalAs(UnmanagedType.LPWStr)] public string VolumeDosName;

		/// <summary>The serial number of the volume.</summary>
		public uint VolumeSerialNumber;

		/// <summary>
		/// A 64 bit file system maintained volume-wide unique ID of the sync root under which the placeholder file/directory to be
		/// serviced resides.
		/// </summary>
		public long SyncRootFileId;

		/// <summary>Points to the opaque blob provided by the sync provider at the sync root registration time.</summary>
		public IntPtr SyncRootIdentity;

		/// <summary>The length, in bytes, of the <c>SyncRootIdentity</c>.</summary>
		public uint SyncRootIdentityLength;

		/// <summary>A 64 bit file system maintained, volume-wide unique ID of the placeholder file/directory to be serviced.</summary>
		public long FileId;

		/// <summary>
		/// The logical size of the placeholder file to be serviced. It is always 0 if the subject of the callback is a directory.
		/// </summary>
		public long FileSize;

		/// <summary>Points to the opaque blob that the sync provider provides at the placeholder creation/conversion/update time.</summary>
		public IntPtr FileIdentity;

		/// <summary>The length, in bytes, of <c>FileIdentity</c>.</summary>
		public uint FileIdentityLength;

		/// <summary>
		/// The absolute path of the placeholder file/directory to be serviced on the volume identified by VolumeGuidName/VolumeDosName.
		/// It starts from the root directory of the volume. See the Remarks section for more details.
		/// </summary>
		[MarshalAs(UnmanagedType.LPWStr)] public string NormalizedPath;

		/// <summary>
		/// An opaque handle to the placeholder file/directory to be serviced. The sync provider must pass it back to the CfExecute call
		/// in order to perform the desired operation on the file/directory.
		/// </summary>
		public CF_TRANSFER_KEY TransferKey;

		/// <summary>
		/// A numeric scale given to the sync provider to describe the relative priority of one fetch compared to another fetch, in
		/// order to provide the most responsive experience to the user. The values range from 0 (lowest possible priority) to 15
		/// (highest possible priority).
		/// </summary>
		public byte PriorityHint;

		/// <summary>An optional correlation vector.</summary>
		public IntPtr CorrelationVector;

		/// <summary>Points to a structure that contains the information about the user process that triggers this callback.</summary>
		public IntPtr ProcessInfo;

		/// <summary/>
		public CF_REQUEST_KEY RequestKey;
	}

	/// <summary>Contains callback specific parameters such as file offset, length, flags, etc.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/cfapi/ns-cfapi-cf_callback_parameters typedef struct CF_CALLBACK_PARAMETERS {
	// ULONG ParamSize; union { struct { CF_CALLBACK_CANCEL_FLAGS Flags; union { struct { LARGE_INTEGER FileOffset; LARGE_INTEGER
	// Length; } FetchData; } DUMMYUNIONNAME; } Cancel; struct { CF_CALLBACK_FETCH_DATA_FLAGS Flags; LARGE_INTEGER RequiredFileOffset;
	// LARGE_INTEGER RequiredLength; LARGE_INTEGER OptionalFileOffset; LARGE_INTEGER OptionalLength; LARGE_INTEGER LastDehydrationTime;
	// CF_CALLBACK_DEHYDRATION_REASON LastDehydrationReason; } FetchData; struct { CF_CALLBACK_VALIDATE_DATA_FLAGS Flags; LARGE_INTEGER
	// RequiredFileOffset; LARGE_INTEGER RequiredLength; } ValidateData; struct { CF_CALLBACK_FETCH_PLACEHOLDERS_FLAGS Flags; PCWSTR
	// Pattern; } FetchPlaceholders; struct { CF_CALLBACK_OPEN_COMPLETION_FLAGS Flags; } OpenCompletion; struct {
	// CF_CALLBACK_CLOSE_COMPLETION_FLAGS Flags; } CloseCompletion; struct { CF_CALLBACK_DEHYDRATE_FLAGS Flags;
	// CF_CALLBACK_DEHYDRATION_REASON Reason; } Dehydrate; struct { CF_CALLBACK_DEHYDRATE_COMPLETION_FLAGS Flags;
	// CF_CALLBACK_DEHYDRATION_REASON Reason; } DehydrateCompletion; struct { CF_CALLBACK_DELETE_FLAGS Flags; } Delete; struct {
	// CF_CALLBACK_DELETE_COMPLETION_FLAGS Flags; } DeleteCompletion; struct { CF_CALLBACK_RENAME_FLAGS Flags; PCWSTR TargetPath; }
	// Rename; struct { CF_CALLBACK_RENAME_COMPLETION_FLAGS Flags; PCWSTR SourcePath; } RenameCompletion; } DUMMYUNIONNAME; } CF_CALLBACK_PARAMETERS;
	[PInvokeData("cfapi.h", MSDNShortId = "FA403E9E-5EFA-4285-9619-614DB0044FFB")]
	[StructLayout(LayoutKind.Sequential)]
	public struct CF_CALLBACK_PARAMETERS
	{
		/// <summary/>
		public uint ParamSize;

		private readonly uint pad;

		/// <summary/>
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 56)]
		public byte[] Content;

		/// <summary/>
		public CANCEL Cancel => GetParam<CANCEL>();

		/// <summary/>
		public FETCHDATA FetchData => GetParam<FETCHDATA>();

		/// <summary/>
		public VALIDATEDATA ValidateData => GetParam<VALIDATEDATA>();

		/// <summary/>
		public FETCHPLACEHOLDERS FetchPlaceholders => GetParam<FETCHPLACEHOLDERS>();

		/// <summary/>
		public OPENCOMPLETION OpenCompletion => GetParam<OPENCOMPLETION>();

		/// <summary/>
		public CLOSECOMPLETION CloseCompletion => GetParam<CLOSECOMPLETION>();

		/// <summary/>
		public DEHYDRATE Dehydrate => GetParam<DEHYDRATE>();

		/// <summary/>
		public DEHYDRATECOMPLETION DehydrateCompletion => GetParam<DEHYDRATECOMPLETION>();

		/// <summary/>
		public DELETE Delete => GetParam<DELETE>();

		/// <summary/>
		public DELETECOMPLETION DeleteCompletion => GetParam<DELETECOMPLETION>();

		/// <summary/>
		public RENAME Rename => GetParam<RENAME>();

		/// <summary/>
		public RENAMECOMPLETION RenameCompletion => GetParam<RENAMECOMPLETION>();

		/// <summary>Gets the parameter value for this structure.</summary>
		/// <typeparam name="T">The type of the structure to retrieve.</typeparam>
		/// <returns>The requested structure.</returns>
		public T GetParam<T>() where T : struct
		{
			using var ptr = new PinnedObject(Content);
			return ((IntPtr)ptr).ToStructure<T>();
		}

		/// <summary>Contains callback specific parameters such as file offset, length, flags, etc.</summary>
		[PInvokeData("cfapi.h", MSDNShortId = "FA403E9E-5EFA-4285-9619-614DB0044FFB")]
		[StructLayout(LayoutKind.Sequential, Pack = 8)]
		public struct CANCEL
		{
			/// <summary>Cancel data flags.</summary>
			public CF_CALLBACK_CANCEL_FLAGS Flags;

			/// <summary/>
			public CANCELFETCHDATA FetchData;

			/// <summary/>
			[StructLayout(LayoutKind.Sequential)]
			public struct CANCELFETCHDATA
			{
				/// <summary>Offset, in bytes, for specifying the range of data.</summary>
				public long FileOffset;

				/// <summary>Length of the data in bytes.</summary>
				public long Length;
			}
		}

		/// <summary>Contains callback specific parameters such as file offset, length, flags, etc.</summary>
		[PInvokeData("cfapi.h", MSDNShortId = "FA403E9E-5EFA-4285-9619-614DB0044FFB")]
		[StructLayout(LayoutKind.Sequential)]
		public struct CLOSECOMPLETION
		{
			/// <summary>Placeholder close completion flags.</summary>
			public CF_CALLBACK_CLOSE_COMPLETION_FLAGS Flags;
		}

		/// <summary>Contains callback specific parameters such as file offset, length, flags, etc.</summary>
		[PInvokeData("cfapi.h", MSDNShortId = "FA403E9E-5EFA-4285-9619-614DB0044FFB")]
		[StructLayout(LayoutKind.Sequential)]
		public struct DEHYDRATE
		{
			/// <summary>Placeholder dehydration flags.</summary>
			public CF_CALLBACK_DEHYDRATE_FLAGS Flags;

			/// <summary/>
			public CF_CALLBACK_DEHYDRATION_REASON Reason;
		}

		/// <summary>Contains callback specific parameters such as file offset, length, flags, etc.</summary>
		[PInvokeData("cfapi.h", MSDNShortId = "FA403E9E-5EFA-4285-9619-614DB0044FFB")]
		[StructLayout(LayoutKind.Sequential)]
		public struct DEHYDRATECOMPLETION
		{
			/// <summary/>
			public CF_CALLBACK_DEHYDRATE_COMPLETION_FLAGS Flags;

			/// <summary/>
			public CF_CALLBACK_DEHYDRATION_REASON Reason;
		}

		/// <summary>Contains callback specific parameters such as file offset, length, flags, etc.</summary>
		[PInvokeData("cfapi.h", MSDNShortId = "FA403E9E-5EFA-4285-9619-614DB0044FFB")]
		[StructLayout(LayoutKind.Sequential)]
		public struct DELETE
		{
			/// <summary>Placeholder deletion flags.</summary>
			public CF_CALLBACK_DELETE_FLAGS Flags;
		}

		/// <summary>Contains callback specific parameters such as file offset, length, flags, etc.</summary>
		[PInvokeData("cfapi.h", MSDNShortId = "FA403E9E-5EFA-4285-9619-614DB0044FFB")]
		[StructLayout(LayoutKind.Sequential)]
		public struct DELETECOMPLETION
		{
			/// <summary>Placeholder deletion complete flags.</summary>
			public CF_CALLBACK_DELETE_COMPLETION_FLAGS Flags;
		}

		/// <summary>Contains callback specific parameters such as file offset, length, flags, etc.</summary>
		[PInvokeData("cfapi.h", MSDNShortId = "FA403E9E-5EFA-4285-9619-614DB0044FFB")]
		[StructLayout(LayoutKind.Sequential)]
		public struct FETCHDATA
		{
			/// <summary>Fetch data flags.</summary>
			public CF_CALLBACK_FETCH_DATA_FLAGS Flags;

			/// <summary>Offset, in bytes, for specifying the required range of data.</summary>
			public long RequiredFileOffset;

			/// <summary>Length of the required data to retrieve, in bytes.</summary>
			public long RequiredLength;

			/// <summary>
			/// Offset, in bytes, of a broader piece of data to provide to a sync provider. This is optional and can be used if the sync
			/// provider prefers to work with larger segments of data.
			/// </summary>
			public long OptionalFileOffset;

			/// <summary>
			/// Length, in bytes, of a broader piece of data to provide to a sync provider. This is optional and can be used if the sync
			/// provider prefers to work with larger segments of data.
			/// </summary>
			public long OptionalLength;

			/// <summary/>
			public long LastDehydrationTime;

			/// <summary/>
			public CF_CALLBACK_DEHYDRATION_REASON LastDehydrationReason;
		}

		/// <summary>Contains callback specific parameters such as file offset, length, flags, etc.</summary>
		[PInvokeData("cfapi.h", MSDNShortId = "FA403E9E-5EFA-4285-9619-614DB0044FFB")]
		[StructLayout(LayoutKind.Sequential)]
		public struct FETCHPLACEHOLDERS
		{
			/// <summary>Flags for fetching placeholder metadata.</summary>
			public CF_CALLBACK_FETCH_PLACEHOLDERS_FLAGS Flags;

			/// <summary>
			/// A standard Windows file pattern which may contain wildcard characters (‘?’, ‘*’). All placeholders information matching the
			/// pattern must be transferred, but not necessarily in one-shot, as a minimum requirement. Alternatively, a sync provider may
			/// choose to not transfer placeholders matching the pattern.
			/// </summary>
			[MarshalAs(UnmanagedType.LPWStr)]
			public string Pattern;
		}

		/// <summary>Contains callback specific parameters such as file offset, length, flags, etc.</summary>
		[PInvokeData("cfapi.h", MSDNShortId = "FA403E9E-5EFA-4285-9619-614DB0044FFB")]
		[StructLayout(LayoutKind.Sequential)]
		public struct OPENCOMPLETION
		{
			/// <summary>Placeholder open completion flags.</summary>
			public CF_CALLBACK_OPEN_COMPLETION_FLAGS Flags;
		}

		/// <summary>Contains callback specific parameters such as file offset, length, flags, etc.</summary>
		[PInvokeData("cfapi.h", MSDNShortId = "FA403E9E-5EFA-4285-9619-614DB0044FFB")]
		[StructLayout(LayoutKind.Sequential)]
		public struct RENAME
		{
			/// <summary>Rename placeholder flags.</summary>
			public CF_CALLBACK_RENAME_FLAGS Flags;

			/// <summary>The full rename/move target path relative to the volume.</summary>
			[MarshalAs(UnmanagedType.LPWStr)]
			public string TargetPath;
		}

		/// <summary>Contains callback specific parameters such as file offset, length, flags, etc.</summary>
		[PInvokeData("cfapi.h", MSDNShortId = "FA403E9E-5EFA-4285-9619-614DB0044FFB")]
		[StructLayout(LayoutKind.Sequential)]
		public struct RENAMECOMPLETION
		{
			/// <summary>Rename completion placeholder flags.</summary>
			public CF_CALLBACK_RENAME_COMPLETION_FLAGS Flags;

			/// <summary>The full source link path relative to the volume.</summary>
			[MarshalAs(UnmanagedType.LPWStr)]
			public string SourcePath;
		}

		/// <summary>Contains callback specific parameters such as file offset, length, flags, etc.</summary>
		[PInvokeData("cfapi.h", MSDNShortId = "FA403E9E-5EFA-4285-9619-614DB0044FFB")]
		[StructLayout(LayoutKind.Sequential)]
		public struct VALIDATEDATA
		{
			/// <summary>Data validation flags.</summary>
			public CF_CALLBACK_VALIDATE_DATA_FLAGS Flags;

			/// <summary>Offset, in bytes, for specifying the range of data to validate.</summary>
			public long RequiredFileOffset;

			/// <summary>Length, in bytes, of the data to validate.</summary>
			public long RequiredLength;
		}
	}

	/// <summary>The callbacks to be registered by the sync provider.</summary>
	/// <remarks>
	/// <para>
	/// This callback registration is how a sync provider communicates to the library which functions to call to execute various
	/// requests from the platform.
	/// </para>
	/// <para>
	/// Note that the sync provider only needs to register implemented callbacks, and <c>CF_CALLBACK_REGISTRATION</c> should always end
	/// with <c>CF_CALLBACK_REGISTRATION_END</c>.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/cfapi/ns-cfapi-cf_callback_registration typedef struct
	// CF_CALLBACK_REGISTRATION { CF_CALLBACK_TYPE Type; CF_CALLBACK Callback; } CF_CALLBACK_REGISTRATION;
	[PInvokeData("cfapi.h", MSDNShortId = "F1633983-DAB2-4072-AA9E-DC7015E6B988")]
	[StructLayout(LayoutKind.Sequential)]
	public struct CF_CALLBACK_REGISTRATION
	{
		/// <summary>The type of callback to be registered.</summary>
		public CF_CALLBACK_TYPE Type;

		/// <summary>A pointer to the callback function.</summary>
		[MarshalAs(UnmanagedType.FunctionPtr)]
		public CF_CALLBACK Callback;

		/// <summary>An instance of <c>CF_CALLBACK_REGISTRATION</c> that indicates the end of the registration list.</summary>
		public static readonly CF_CALLBACK_REGISTRATION CF_CALLBACK_REGISTRATION_END = new() { Type = CF_CALLBACK_TYPE.CF_CALLBACK_TYPE_NONE };
	}

	/// <summary>Opaque handle to a connection key.</summary>
	[PInvokeData("cfapi.h")]
	[StructLayout(LayoutKind.Sequential)]
	public struct CF_CONNECTION_KEY
	{
		private readonly long Internal;
	}

	/// <summary>Specifies a range of data in a placeholder file.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/cfapi/ns-cfapi-cf_file_range typedef struct CF_FILE_RANGE { LARGE_INTEGER
	// StartingOffset; LARGE_INTEGER Length; } CF_FILE_RANGE;
	[PInvokeData("cfapi.h", MSDNShortId = "DAE43446-725E-490B-AE1B-EA6CB31F4358")]
	[StructLayout(LayoutKind.Sequential)]
	public struct CF_FILE_RANGE
	{
		/// <summary>The offset of the starting point of the data.</summary>
		public long StartingOffset;

		/// <summary>The length of the data, in bytes.</summary>
		public long Length;
	}

	/// <summary>A structure to describe the location and range of data in a file.</summary>
	// https://docs.microsoft.com/en-us/previous-versions/windows/desktop/legacy/mt844616(v=vs.85) typedef struct __CF_FILE_RANGE_BUFFER
	// { LARGE_INTEGER FileOffset; LARGE_INTEGER Length; } CF_FILE_RANGE_BUFFER;
	[PInvokeData("CfApi.h")]
	[StructLayout(LayoutKind.Sequential)]
	public struct CF_FILE_RANGE_BUFFER
	{
		/// <summary>The offset of the range of data within a file.</summary>
		public long FileOffset;

		/// <summary>The length, in bytes of the data range.</summary>
		public long Length;
	}

	/// <summary>Placeholder file or directory metadata.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/cfapi/ns-cfapi-cf_fs_metadata typedef struct CF_FS_METADATA { FILE_BASIC_INFO
	// BasicInfo; LARGE_INTEGER FileSize; } CF_FS_METADATA;
	[PInvokeData("cfapi.h", MSDNShortId = "A6D4473A-C93A-4B56-9EB0-9B44A56E5D28")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
	public struct CF_FS_METADATA
	{
		/// <summary>Basic file information.</summary>
		public FILE_BASIC_INFO BasicInfo;

		/// <summary>The size of the file, in bytes.</summary>
		public long FileSize;
	}

	/// <summary>Specifies the primary hydration policy and its modifier.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/cfapi/ns-cfapi-cf_hydration_policy typedef struct CF_HYDRATION_POLICY {
	// CF_HYDRATION_POLICY_PRIMARY_USHORT Primary; CF_HYDRATION_POLICY_MODIFIER_USHORT Modifier; } CF_HYDRATION_POLICY;
	[PInvokeData("cfapi.h", MSDNShortId = "1541E108-7AE4-4899-8940-94FD264C1B10")]
	[StructLayout(LayoutKind.Sequential)]
	public struct CF_HYDRATION_POLICY
	{
		/// <summary>The primary hydration policy.</summary>
		public CF_HYDRATION_POLICY_PRIMARY Primary;

		/// <summary>The hydration policy modifier.</summary>
		public CF_HYDRATION_POLICY_MODIFIER Modifier;
	}

	/// <summary>Information about an operation on a placeholder file or folder.</summary>
	/// <remarks>
	/// The platform provides the <c>ConnectionKey</c>, <c>TransferKey</c>, and <c>CorrelationVector</c> to all callback functions
	/// registered via CfConnectSyncRoot. Additionally, sync providers can obtain a <c>TransferKey</c> using CfGetTransferKey and a
	/// <c>CorrelationVector</c> using CfGetCorrelationVector.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/cfapi/ns-cfapi-cf_operation_info typedef struct CF_OPERATION_INFO { ULONG
	// StructSize; CF_OPERATION_TYPE Type; CF_CONNECTION_KEY ConnectionKey; CF_TRANSFER_KEY TransferKey; const CORRELATION_VECTOR
	// *CorrelationVector; const CF_SYNC_STATUS *SyncStatus; CF_REQUEST_KEY RequestKey; } CF_OPERATION_INFO;
	[PInvokeData("cfapi.h", MSDNShortId = "4AE9A968-1325-4EFF-8F5B-8F465740B0C4")]
	[StructLayout(LayoutKind.Sequential)]
	public struct CF_OPERATION_INFO
	{
		/// <summary>The size of the structure.</summary>
		public uint StructSize;

		/// <summary>The type of operation performed.</summary>
		public CF_OPERATION_TYPE Type;

		/// <summary>A connection key obtained for the communication channel.</summary>
		public CF_CONNECTION_KEY ConnectionKey;

		/// <summary>An opaque handle to the placeholder.</summary>
		public CF_TRANSFER_KEY TransferKey;

		/// <summary>A correlation vector on a placeholder used for telemetry purposes.</summary>
		public IntPtr CorrelationVector;

		/// <summary>
		/// <para><c>Note</c> This member is new for Windows 10, version 1803.</para>
		/// <para>The current sync status of the platform.</para>
		/// <para>
		/// The platform queries this information upon any failed operations on a cloud file placeholder. If a structure is available,
		/// the platform will use the information provided to construct a more meaningful and actionable message to the user. The
		/// platform will keep this information on the file until the last handle on it goes away. If <c>null</c>, the platform will
		/// clear the previously set sync status, if there is one.
		/// </para>
		/// </summary>
		public IntPtr SyncStatus;

		/// <summary/>
		public CF_REQUEST_KEY RequestKey;
	}

	/// <summary>Parameters of an operation on a placeholder file or folder.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/cfapi/ns-cfapi-cf_operation_parameters typedef struct CF_OPERATION_PARAMETERS
	// { ULONG ParamSize; union { struct { CF_OPERATION_TRANSFER_DATA_FLAGS Flags; NTSTATUS CompletionStatus; LPCVOID Buffer;
	// LARGE_INTEGER Offset; LARGE_INTEGER Length; } TransferData; struct { CF_OPERATION_RETRIEVE_DATA_FLAGS Flags; LPVOID Buffer;
	// LARGE_INTEGER Offset; LARGE_INTEGER Length; LARGE_INTEGER ReturnedLength; } RetrieveData; struct { CF_OPERATION_ACK_DATA_FLAGS
	// Flags; NTSTATUS CompletionStatus; LARGE_INTEGER Offset; LARGE_INTEGER Length; } AckData; struct {
	// CF_OPERATION_RESTART_HYDRATION_FLAGS Flags; const CF_FS_METADATA *FsMetadata; LPCVOID FileIdentity; DWORD FileIdentityLength; }
	// RestartHydration; struct { CF_OPERATION_TRANSFER_PLACEHOLDERS_FLAGS Flags; NTSTATUS CompletionStatus; LARGE_INTEGER
	// PlaceholderTotalCount; CF_PLACEHOLDER_CREATE_INFO *PlaceholderArray; DWORD PlaceholderCount; DWORD EntriesProcessed; }
	// TransferPlaceholders; struct { CF_OPERATION_ACK_DEHYDRATE_FLAGS Flags; NTSTATUS CompletionStatus; LPCVOID FileIdentity; DWORD
	// FileIdentityLength; } AckDehydrate; struct { CF_OPERATION_ACK_RENAME_FLAGS Flags; NTSTATUS CompletionStatus; } AckRename; struct
	// { CF_OPERATION_ACK_DELETE_FLAGS Flags; NTSTATUS CompletionStatus; } AckDelete; } DUMMYUNIONNAME; } CF_OPERATION_PARAMETERS;
	[PInvokeData("cfapi.h", MSDNShortId = "668C682E-47C2-41BC-A4F9-AA2F2B516F54")]
	[StructLayout(LayoutKind.Sequential)]
	public struct CF_OPERATION_PARAMETERS
	{
		/// <summary/>
		public uint ParamSize;

		// Yes, this is strange, but needed to deal with struct size changing based on pointer size (40/48).
		private readonly uint pad4_8;
		private readonly ulong pad8_16;
		private readonly ulong pad16_24;
		private readonly ulong pad24_32;
		private readonly IntPtr padp1;
		private readonly IntPtr padp2;

		/// <summary/>
		public TRANSFERDATA TransferData { get => GetParam<TRANSFERDATA>(); set => SetParam(value); }

		/// <summary/>
		public RETRIEVEDATA RetrieveData { get => GetParam<RETRIEVEDATA>(); set => SetParam(value); }

		/// <summary/>
		public ACKDATA AckData { get => GetParam<ACKDATA>(); set => SetParam(value); }

		/// <summary/>
		public RESTARTHYDRATION RestartHydration { get => GetParam<RESTARTHYDRATION>(); set => SetParam(value); }

		/// <summary/>
		public TRANSFERPLACEHOLDERS TransferPlaceholders { get => GetParam<TRANSFERPLACEHOLDERS>(); set => SetParam(value); }

		/// <summary/>
		public ACKDEHYDRATE AckDehydrate { get => GetParam<ACKDEHYDRATE>(); set => SetParam(value); }

		/// <summary/>
		public ACKRENAME AckRename { get => GetParam<ACKRENAME>(); set => SetParam(value); }

		/// <summary/>
		public ACKDELETE AckDelete { get => GetParam<ACKDELETE>(); set => SetParam(value); }

		/// <summary>Gets the parameter value for this structure.</summary>
		/// <typeparam name="T">The type of the structure to retrieve.</typeparam>
		/// <returns>The requested structure.</returns>
		public unsafe T GetParam<T>() where T : struct
		{
			using var ptr = new PinnedObject(this);
			return ((IntPtr)ptr).ToStructure<T>(Marshal.SizeOf(typeof(CF_OPERATION_PARAMETERS)), 8);
		}

		/// <summary>Sets the parameter value for this structure.</summary>
		/// <typeparam name="T">The type of the structure to set.</typeparam>
		/// <param name="value">The value to set.</param>
		public void SetParam<T>(T value) where T : struct
		{
			unsafe
			{
				fixed (ulong* p = &pad8_16)
				{
					((IntPtr)(void*)p).Write(value, 0, Marshal.SizeOf(typeof(CF_OPERATION_PARAMETERS)) - 8);
				}
			}
		}

		/// <summary>Creates a CF_OPERATION_PARAMETERS instance with the specified parameter value.</summary>
		/// <typeparam name="T">The parameter type.</typeparam>
		/// <param name="paramValue">The parameter value.</param>
		/// <returns>A CF_OPERATION_PARAMETERS instance initialized with <paramref name="paramValue"/> and the correct ParamSize.</returns>
		public static CF_OPERATION_PARAMETERS Create<T>(T paramValue = default) where T : struct
		{
			var op = new CF_OPERATION_PARAMETERS { ParamSize = CF_SIZE_OF_OP_PARAM<T>() };
			op.SetParam(paramValue);
			return op;
		}

		/// <summary>Gets the size value used in ParamSize given a specific parameter type.</summary>
		/// <typeparam name="T">The parameter type.</typeparam>
		/// <returns>The size of the structure.</returns>
		public static uint CF_SIZE_OF_OP_PARAM<T>() where T : struct => (uint)(Marshal.OffsetOf(typeof(CF_OPERATION_PARAMETERS), nameof(pad8_16)).ToInt32() + Marshal.SizeOf(typeof(T)));

		/// <summary/>
		[StructLayout(LayoutKind.Sequential)]
		public struct TRANSFERDATA
		{
			/// <summary>Flags for transferring data.</summary>
			public CF_OPERATION_TRANSFER_DATA_FLAGS Flags;

			/// <summary>Status for transferring data. Set to STATUS_SUCCESS if the sync provider will transfer data to a placeholder.</summary>
			public NTStatus CompletionStatus;

			/// <summary>A valid user mode buffer.</summary>
			public IntPtr Buffer;

			/// <summary>The offset used with the <c>Length</c> to describe a range in the placeholder to which the data is transferred.</summary>
			public long Offset;

			/// <summary>The length in bytes of the <c>Buffer</c>.</summary>
			public long Length;
		}

		/// <summary/>
		[StructLayout(LayoutKind.Sequential)]
		public struct RETRIEVEDATA
		{
			/// <summary>Flags for retrieving data.</summary>
			public CF_OPERATION_RETRIEVE_DATA_FLAGS Flags;

			/// <summary/>
			public IntPtr Buffer;

			/// <summary>The offset used with the <c>Length</c> to describe the range of data retrieved from a placeholder.</summary>
			public long Offset;

			/// <summary>The length in bytes of the <c>Buffer</c>.</summary>
			public long Length;

			/// <summary>The number of bytes retrieved on successful completion.</summary>
			public long ReturnedLength;
		}

		/// <summary/>
		[StructLayout(LayoutKind.Sequential)]
		public struct ACKDATA
		{
			/// <summary>Flags for acknowledging data.</summary>
			public CF_OPERATION_ACK_DATA_FLAGS Flags;

			/// <summary>
			/// <para>Completion status of data acknowledgement.</para>
			/// <para>Set to STATUS_SUCCESS if the sync provider validates the data within the range to be acknowledged is good.</para>
			/// </summary>
			public NTStatus CompletionStatus;

			/// <summary>The offset in bytes of the placeholder data to be acknowledged.</summary>
			public long Offset;

			/// <summary>The length in bytes of data in the placeholder to be acknowledged.</summary>
			public long Length;
		}

		/// <summary/>
		[StructLayout(LayoutKind.Sequential)]
		public struct RESTARTHYDRATION
		{
			/// <summary>Flags to restart placeholder hydration.</summary>
			public CF_OPERATION_RESTART_HYDRATION_FLAGS Flags;

			/// <summary>Optional. Contains updates to the files metadata.</summary>
			public IntPtr FsMetadata;

			/// <summary>Optional. When provided, the file identity is updated to this value. Otherwise, it remains the same.</summary>
			public IntPtr FileIdentity;

			/// <summary>Optional. This specifies the length of the <c>FileIdentity</c>.</summary>
			public uint FileIdentityLength;
		}

		/// <summary/>
		[StructLayout(LayoutKind.Sequential)]
		public struct TRANSFERPLACEHOLDERS
		{
			/// <summary>Flags for transferring placeholders.</summary>
			public CF_OPERATION_TRANSFER_PLACEHOLDERS_FLAGS Flags;

			/// <summary>The completion status of the operation.</summary>
			public NTStatus CompletionStatus;

			/// <summary>Total number of placeholders.</summary>
			public long PlaceholderTotalCount;

			/// <summary>An array of placeholders to be transferred.</summary>
			public IntPtr PlaceholderArray;

			/// <summary>The number of placeholders being transferred.</summary>
			public uint PlaceholderCount;

			/// <summary>The placeholder entries that have been processed.</summary>
			public uint EntriesProcessed;
		}

		/// <summary/>
		[StructLayout(LayoutKind.Sequential)]
		public struct ACKDEHYDRATE
		{
			/// <summary>Dehydrated data acknowledgment flags.</summary>
			public CF_OPERATION_ACK_DEHYDRATE_FLAGS Flags;

			/// <summary>The completion status of the operation.</summary>
			public NTStatus CompletionStatus;

			/// <summary>The file identity of the placeholder file to acknowledge dehydrated data for.</summary>
			public IntPtr FileIdentity;

			/// <summary>Length, in bytes, of the <c>FileIdentity</c>.</summary>
			public uint FileIdentityLength;
		}

		/// <summary/>
		[StructLayout(LayoutKind.Sequential)]
		public struct ACKRENAME
		{
			/// <summary>Acknowledge rename placeholder flags.</summary>
			public CF_OPERATION_ACK_RENAME_FLAGS Flags;

			/// <summary>The completion status of the operation.</summary>
			public NTStatus CompletionStatus;
		}

		/// <summary/>
		[StructLayout(LayoutKind.Sequential)]
		public struct ACKDELETE
		{
			/// <summary>Acknowledge delete flags.</summary>
			public CF_OPERATION_ACK_DELETE_FLAGS Flags;

			/// <summary>The completion status of the operation.</summary>
			public NTStatus CompletionStatus;
		}
	}

	/// <summary>Basic placeholder information.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/cfapi/ns-cfapi-cf_placeholder_basic_info typedef struct
	// CF_PLACEHOLDER_BASIC_INFO { CF_PIN_STATE PinState; CF_IN_SYNC_STATE InSyncState; LARGE_INTEGER FileId; LARGE_INTEGER
	// SyncRootFileId; ULONG FileIdentityLength; BYTE FileIdentity[1]; } CF_PLACEHOLDER_BASIC_INFO;
	[PInvokeData("cfapi.h", MSDNShortId = "77367235-342D-4BBC-B910-FE798E14B588")]
	[VanaraMarshaler(typeof(SafeAnysizeStructMarshaler<CF_PLACEHOLDER_BASIC_INFO>), nameof(FileIdentityLength))]
	[StructLayout(LayoutKind.Sequential)]
	public struct CF_PLACEHOLDER_BASIC_INFO
	{
		/// <summary>The pin state of the placeholder. See CfSetPinState for more details.</summary>
		public CF_PIN_STATE PinState;

		/// <summary>The in-sync state of the placeholder. see CfSetInSyncState for more details.</summary>
		public CF_IN_SYNC_STATE InSyncState;

		/// <summary>A 64-bit volume wide non-volatile number that uniquely identifies a file or directory.</summary>
		public long FileId;

		/// <summary>The file ID of the sync root directory that contains the file whose placeholder information is to be queried.</summary>
		public long SyncRootFileId;

		/// <summary>Length, in bytes, of the FileIdentity.</summary>
		public uint FileIdentityLength;

		/// <summary/>
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
		public byte[] FileIdentity;
	}

	/// <summary>Contains placeholder information for creating new placeholder files or directories.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/cfapi/ns-cfapi-cf_placeholder_create_info typedef struct
	// CF_PLACEHOLDER_CREATE_INFO { LPCWSTR RelativeFileName; CF_FS_METADATA FsMetadata; LPCVOID FileIdentity; DWORD FileIdentityLength;
	// CF_PLACEHOLDER_CREATE_FLAGS Flags; HRESULT Result; USN CreateUsn; } CF_PLACEHOLDER_CREATE_INFO;
	[PInvokeData("cfapi.h", MSDNShortId = "2DC1FF5F-FBFD-45CA-8CD5-B2F586C22778")]
	[StructLayout(LayoutKind.Sequential)]
	public struct CF_PLACEHOLDER_CREATE_INFO
	{
		/// <summary>The name of the child placeholder file or directory to be created.</summary>
		[MarshalAs(UnmanagedType.LPWStr)] public string RelativeFileName;

		/// <summary>File system metadata to be created with the placeholder.</summary>
		public CF_FS_METADATA FsMetadata;

		/// <summary>
		/// A user mode buffer containing file information supplied by the sync provider. This is required for files (not for directories).
		/// </summary>
		public IntPtr FileIdentity;

		/// <summary>Length, in bytes, of the <c>FileIdentity</c>.</summary>
		public uint FileIdentityLength;

		/// <summary>Flags for specifying placeholder creation behavior.</summary>
		public CF_PLACEHOLDER_CREATE_FLAGS Flags;

		/// <summary>The result of placeholder creation. On successful creation, the value is: STATUS_OK.</summary>
		public HRESULT Result;

		/// <summary>The final USN value after create actions are performed.</summary>
		public USN CreateUsn;

		/// <summary>
		/// Initializes a new instance of the <see cref="CF_PLACEHOLDER_CREATE_INFO"/> struct with info from a file.
		/// </summary>
		/// <param name="fileInfo">The file information.</param>
		public CF_PLACEHOLDER_CREATE_INFO(System.IO.FileInfo fileInfo) : this()
		{
			RelativeFileName = fileInfo.FullName;
			FsMetadata = new CF_FS_METADATA
			{
				FileSize = fileInfo.Length,
				BasicInfo = new FILE_BASIC_INFO
				{
					FileAttributes = (FileFlagsAndAttributes)fileInfo.Attributes,
					CreationTime = fileInfo.CreationTime.ToFileTimeStruct(),
					LastWriteTime = fileInfo.LastWriteTime.ToFileTimeStruct(),
					LastAccessTime = fileInfo.LastAccessTime.ToFileTimeStruct(),
					ChangeTime = fileInfo.LastWriteTime.ToFileTimeStruct()
				}
			};
		}
	}

	/// <summary>Standard placeholder information.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/cfapi/ns-cfapi-cf_placeholder_standard_info typedef struct
	// CF_PLACEHOLDER_STANDARD_INFO { LARGE_INTEGER OnDiskDataSize; LARGE_INTEGER ValidatedDataSize; LARGE_INTEGER ModifiedDataSize;
	// LARGE_INTEGER PropertiesSize; CF_PIN_STATE PinState; CF_IN_SYNC_STATE InSyncState; LARGE_INTEGER FileId; LARGE_INTEGER
	// SyncRootFileId; ULONG FileIdentityLength; BYTE FileIdentity[1]; } CF_PLACEHOLDER_STANDARD_INFO;
	[PInvokeData("cfapi.h", MSDNShortId = "F0CDC9CD-7D31-4854-9568-8F13516C6D15")]
	[VanaraMarshaler(typeof(SafeAnysizeStructMarshaler<CF_PLACEHOLDER_STANDARD_INFO>), nameof(FileIdentityLength))]
	[StructLayout(LayoutKind.Sequential)]
	public struct CF_PLACEHOLDER_STANDARD_INFO
	{
		/// <summary>Total number of bytes on disk.</summary>
		public long OnDiskDataSize;

		/// <summary>Total number of bytes in sync with the cloud.</summary>
		public long ValidatedDataSize;

		/// <summary>Total number of bytes that have been overwritten/appended locally that are not in sync with the cloud.</summary>
		public long ModifiedDataSize;

		/// <summary>Total number of bytes on disk that are used by all the property blobs.</summary>
		public long PropertiesSize;

		/// <summary>The pin state of the placeholder. See CfSetPinState for more details.</summary>
		public CF_PIN_STATE PinState;

		/// <summary>The in-sync state of the placeholder. see CfSetInSyncState for more details.</summary>
		public CF_IN_SYNC_STATE InSyncState;

		/// <summary>A 64-bit volume wide non-volatile number that uniquely identifies a file or directory.</summary>
		public long FileId;

		/// <summary>The file ID of the sync root directory that contains the file whose placeholder information is to be queried.</summary>
		public long SyncRootFileId;

		/// <summary>Length, in bytes, of the FileIdentity.</summary>
		public uint FileIdentityLength;

		/// <summary/>
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
		public byte[] FileIdentity;
	}

	/// <summary>
	/// Returns information for the cloud files platform. This is intended for sync providers running on multiple versions of Windows.
	/// </summary>
	/// <remarks>
	/// <para>
	/// The platform is a combination of the cloud filter and the placeholder files API library, which are always kept in sync with each
	/// other. This API is intended for sync providers that need to make decisions based on the platform capabilities of multiple
	/// versions of Windows.
	/// </para>
	/// <para>If you are building an app that uses or is aware of placeholder files, this may be useful to you.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/cfapi/ns-cfapi-cf_platform_info typedef struct CF_PLATFORM_INFO { DWORD
	// BuildNumber; DWORD RevisionNumber; DWORD IntegrationNumber; } CF_PLATFORM_INFO;
	[PInvokeData("cfapi.h", MSDNShortId = "BEB1CBF0-05FB-4D48-AC43-AA957F2208DB")]
	[StructLayout(LayoutKind.Sequential)]
	public struct CF_PLATFORM_INFO
	{
		/// <summary>The build number of the Windows platform version. Changes when the platform is serviced by a Windows update.</summary>
		public uint BuildNumber;

		/// <summary>The revision number of the Windows platform version. Changes when the platform is serviced by a Windows update.</summary>
		public uint RevisionNumber;

		/// <summary>
		/// The integration number of the Windows platform version. This is indicative of the platform capabilities, both in terms of
		/// API contracts and availability of bug fixes.
		/// </summary>
		public uint IntegrationNumber;
	}

	/// <summary>Specifies the primary population policy and its modifier.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/cfapi/ns-cfapi-cf_population_policy typedef struct CF_POPULATION_POLICY {
	// CF_POPULATION_POLICY_PRIMARY_USHORT Primary; CF_POPULATION_POLICY_MODIFIER_USHORT Modifier; } CF_POPULATION_POLICY;
	[PInvokeData("cfapi.h", MSDNShortId = "043EBBF8-4077-429B-B959-55E0623520E2")]
	[StructLayout(LayoutKind.Sequential)]
	public struct CF_POPULATION_POLICY
	{
		/// <summary>The primary population policy.</summary>
		public CF_POPULATION_POLICY_PRIMARY Primary;

		/// <summary>The population policy modifier.</summary>
		public CF_POPULATION_POLICY_MODIFIER Modifier;
	}

	/// <summary>Contains information about a user process.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/cfapi/ns-cfapi-cf_process_info typedef struct CF_PROCESS_INFO { DWORD
	// StructSize; DWORD ProcessId; PCWSTR ImagePath; PCWSTR PackageName; PCWSTR ApplicationId; PCWSTR CommandLine; DWORD SessionId; } CF_PROCESS_INFO;
	[PInvokeData("cfapi.h", MSDNShortId = "912433E9-DC49-41BA-85F7-1A0AF9F88159")]
	[StructLayout(LayoutKind.Sequential)]
	public struct CF_PROCESS_INFO
	{
		/// <summary>The size of the structure.</summary>
		public uint StructSize;

		/// <summary>The 32 bit ID of the user process.</summary>
		public uint ProcessId;

		/// <summary>
		/// The absolute path of the main executable file including the volume name in the format of NT file path. If the platform
		/// failed to retrieve the image path, “UNKNOWN” will be returned.
		/// </summary>
		[MarshalAs(UnmanagedType.LPWStr)] public string ImagePath;

		/// <summary>Used for modern applications. The app package name.</summary>
		[MarshalAs(UnmanagedType.LPWStr)] public string PackageName;

		/// <summary>Used for modern applications. The application ID.</summary>
		[MarshalAs(UnmanagedType.LPWStr)] public string ApplicationId;

		/// <summary>
		/// <para><c>Note</c> This member was added in Windows 10, version 1803.</para>
		/// <para>Used to start the process. If the platform failed to retrieve the command line, “UNKNOWN” will be returned.</para>
		/// <para>SessionId</para>
		/// <para><c>Note</c> This member was added in Windows 10, version 1803.</para>
		/// <para>The 32bit ID of the session wherein the user process that triggers the callback resides.</para>
		/// </summary>
		[MarshalAs(UnmanagedType.LPWStr)] public string CommandLine;

		/// <summary/>
		public uint SessionId;
	}

	/// <summary>Opaque handle to a request key.</summary>
	[PInvokeData("cfapi.h")]
	[StructLayout(LayoutKind.Sequential)]
	public struct CF_REQUEST_KEY
	{
		private readonly long Internal;
	}

	/// <summary>Defines the sync policies used by a sync root.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/cfapi/ns-cfapi-cf_sync_policies typedef struct CF_SYNC_POLICIES { ULONG
	// StructSize; CF_HYDRATION_POLICY Hydration; CF_POPULATION_POLICY Population; CF_INSYNC_POLICY InSync; CF_HARDLINK_POLICY HardLink;
	// } CF_SYNC_POLICIES;
	[PInvokeData("cfapi.h", MSDNShortId = "5BCD0958-1FED-4F97-A4B4-2EB354E85BF6")]
	[StructLayout(LayoutKind.Sequential)]
	public struct CF_SYNC_POLICIES
	{
		/// <summary>The size of the CF_SYNC_POLICIES structure.</summary>
		public uint StructSize;

		/// <summary>The hydration policy.</summary>
		public CF_HYDRATION_POLICY Hydration;

		/// <summary>The population policy.</summary>
		public CF_POPULATION_POLICY Population;

		/// <summary>The in-sync policy.</summary>
		public CF_INSYNC_POLICY InSync;

		/// <summary>The hard link policy.</summary>
		public CF_HARDLINK_POLICY HardLink;
	}

	/// <summary>The details of the sync provider and sync root to be registered.</summary>
	/// <remarks>
	/// <c>SyncRootIdentity</c> and <c>SyncRootIdentityLength</c> are optional members. If not used, set <c>SyncRootIdentity</c> to
	/// <c>nullptr</c> and <c>SyncRootIdentityLength</c> to <c>0</c>. <c>FileIdentity</c> and <c>FileIdentityLength</c> are also
	/// optional and if not used should be set to <c>nullptr</c> and <c>0</c>, respectively.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/cfapi/ns-cfapi-cf_sync_registration typedef struct CF_SYNC_REGISTRATION {
	// ULONG StructSize; LPCWSTR ProviderName; LPCWSTR ProviderVersion; LPCVOID SyncRootIdentity; DWORD SyncRootIdentityLength; LPCVOID
	// FileIdentity; DWORD FileIdentityLength; GUID ProviderId; } CF_SYNC_REGISTRATION;
	[PInvokeData("cfapi.h", MSDNShortId = "F4D535FA-A0F5-4B4E-8409-0DD13C78A94E")]
	[StructLayout(LayoutKind.Sequential)]
	public struct CF_SYNC_REGISTRATION
	{
		/// <summary>The size of the structure.</summary>
		public uint StructSize;

		/// <summary>The name of the sync provider. This is a user friendly string with a maximum length of 255 characters.</summary>
		[MarshalAs(UnmanagedType.LPWStr)] public string ProviderName;

		/// <summary>The version of the sync provider. This is a user friendly string with a maximum length of 255 characters.</summary>
		[MarshalAs(UnmanagedType.LPWStr)] public string ProviderVersion;

		/// <summary>The sync root identity used by the provider. This member is optional with a maximum size of 64 KB.</summary>
		public IntPtr SyncRootIdentity;

		/// <summary>
		/// The length of the <c>SyncRootIdentity</c>. This member is optional and is only used if a <c>SyncRootIdentity</c> is provided.
		/// </summary>
		public uint SyncRootIdentityLength;

		/// <summary>An optional file identity. This member has a maximum size of 4 KB.</summary>
		public IntPtr FileIdentity;

		/// <summary>The length of the file identity.</summary>
		public uint FileIdentityLength;

		/// <summary/>
		public Guid ProviderId;
	}

	/// <summary>Basic sync root information.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/cfapi/ns-cfapi-cf_sync_root_basic_info typedef struct CF_SYNC_ROOT_BASIC_INFO
	// { LARGE_INTEGER SyncRootFileId; } CF_SYNC_ROOT_BASIC_INFO;
	[PInvokeData("cfapi.h", MSDNShortId = "7499D9DD-BAF6-449A-A34E-CEAE3EE10543")]
	[StructLayout(LayoutKind.Sequential)]
	public struct CF_SYNC_ROOT_BASIC_INFO
	{
		/// <summary>The file ID of the sync root.</summary>
		public long SyncRootFileId;
	}

	/// <summary>Sync root provider information.</summary>
	/// <remarks><c>CF_MAX_PROVIDER_NAME_LENGTH</c> and <c>CF_MAX_PROVIDER_VERSION_LENGTH</c> are set to 255.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/cfapi/ns-cfapi-cf_sync_root_provider_info typedef struct
	// CF_SYNC_ROOT_PROVIDER_INFO { CF_SYNC_PROVIDER_STATUS ProviderStatus; WCHAR ProviderName[CF_MAX_PROVIDER_NAME_LENGTH + 1]; WCHAR
	// ProviderVersion[CF_MAX_PROVIDER_VERSION_LENGTH + 1]; } CF_SYNC_ROOT_PROVIDER_INFO;
	[PInvokeData("cfapi.h", MSDNShortId = "9EBC64B5-7FB3-41AA-BCB2-29B3E444B463")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct CF_SYNC_ROOT_PROVIDER_INFO
	{
		/// <summary>Status of the sync root provider.</summary>
		public CF_SYNC_PROVIDER_STATUS ProviderStatus;

		/// <summary/>
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = CF_MAX_PROVIDER_NAME_LENGTH + 1)]
		public string ProviderName;

		/// <summary/>
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = CF_MAX_PROVIDER_VERSION_LENGTH + 1)]
		public string ProviderVersion;
	}

	/// <summary>Standard sync root information.</summary>
	/// <remarks><c>CF_MAX_PROVIDER_NAME_LENGTH</c> and <c>CF_MAX_PROVIDER_VERSION_LENGTH</c> are set to 255.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/cfapi/ns-cfapi-cf_sync_root_standard_info typedef struct
	// CF_SYNC_ROOT_STANDARD_INFO { LARGE_INTEGER SyncRootFileId; CF_HYDRATION_POLICY HydrationPolicy; CF_POPULATION_POLICY
	// PopulationPolicy; CF_INSYNC_POLICY InSyncPolicy; CF_HARDLINK_POLICY HardLinkPolicy; CF_SYNC_PROVIDER_STATUS ProviderStatus; WCHAR
	// ProviderName[CF_MAX_PROVIDER_NAME_LENGTH + 1]; WCHAR ProviderVersion[CF_MAX_PROVIDER_VERSION_LENGTH + 1]; ULONG
	// SyncRootIdentityLength; BYTE SyncRootIdentity[1]; } CF_SYNC_ROOT_STANDARD_INFO;
	[PInvokeData("cfapi.h", MSDNShortId = "17E409FB-2997-432C-977F-BEBF53068B42")]
	[VanaraMarshaler(typeof(SafeAnysizeStructMarshaler<CF_SYNC_ROOT_STANDARD_INFO>), nameof(SyncRootIdentityLength))]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct CF_SYNC_ROOT_STANDARD_INFO
	{
		/// <summary>File ID of the sync root.</summary>
		public long SyncRootFileId;

		/// <summary>Hydration policy of the sync root.</summary>
		public CF_HYDRATION_POLICY HydrationPolicy;

		/// <summary>Population policy of the sync root.</summary>
		public CF_POPULATION_POLICY PopulationPolicy;

		/// <summary>In-sync policy of the sync root.</summary>
		public CF_INSYNC_POLICY InSyncPolicy;

		/// <summary>Sync root hard linking policy.</summary>
		public CF_HARDLINK_POLICY HardLinkPolicy;

		/// <summary>Status of the sync root provider.</summary>
		public CF_SYNC_PROVIDER_STATUS ProviderStatus;

		/// <summary/>
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = CF_MAX_PROVIDER_NAME_LENGTH + 1)]
		public string ProviderName;

		/// <summary/>
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = CF_MAX_PROVIDER_VERSION_LENGTH + 1)]
		public string ProviderVersion;

		/// <summary>Length, in bytes, of the SyncRootIdentity.</summary>
		public uint SyncRootIdentityLength;

		/// <summary/>
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
		public byte[] SyncRootIdentity;
	}

	/// <summary>Used in a CF_OPERATION_INFO structure to describe the status of a specified sync root.</summary>
	/// <remarks>
	/// If a null pointer is set in the <c>SyncStatus</c> field of a CF_OPERATION_INFO structure, the platform will clear the previously
	/// set sync status, if there is one.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/cfapi/ns-cfapi-cf_sync_status typedef struct CF_SYNC_STATUS { ULONG
	// StructSize; ULONG Code; ULONG DescriptionOffset; ULONG DescriptionLength; ULONG DeviceIdOffset; ULONG DeviceIdLength; } CF_SYNC_STATUS;
	[PInvokeData("cfapi.h", MSDNShortId = "F80CBBAE-605B-4C1E-BDA5-A4B155F9D079")]
	[StructLayout(LayoutKind.Sequential)]
	public struct CF_SYNC_STATUS
	{
		/// <summary>The size, in bytes, of the sync status structure, including the actual description string.</summary>
		public uint StructSize;

		/// <summary>
		/// <para>The use of this parameter is completely up to the sync provider that supports this rich sync status construct.</para>
		/// <para>For a particular sync provider, it is expected that there is a 1:1 mapping between the code and the description string.</para>
		/// <para>
		/// It is recommended that you use the highest bit order to describe the type of error code: 1 for an error-level code, and 0
		/// for an information-level code.
		/// </para>
		/// <para><c>Note</c><c>Code</c> is opaque to the platform, and is used only for tracking purposes.</para>
		/// </summary>
		public uint Code;

		/// <summary>
		/// The offset of the description string relative to the start of <c>CF_SYNC_STATUS</c>. It points to a localized
		/// null-terminated wide string that is expected to contain more meaningful and actionable information about the file in
		/// question. Sync providers are expected to balance the requirement of providing more actionable information and maintaining an
		/// as small as possible memory footprint.
		/// </summary>
		public uint DescriptionOffset;

		/// <summary>The size of the description string, in bytes, that includes the null terminator.</summary>
		public uint DescriptionLength;

		/// <summary/>
		public uint DeviceIdOffset;

		/// <summary/>
		public uint DeviceIdLength;
	}

	/// <summary>Opaque handle to a transfer key.</summary>
	[PInvokeData("cfapi.h")]
	[StructLayout(LayoutKind.Sequential)]
	public struct CF_TRANSFER_KEY
	{
		private readonly long Internal;
	}
}
