using System;
using System.Runtime.InteropServices;
using FILETIME = System.Runtime.InteropServices.ComTypes.FILETIME;

namespace Vanara.PInvoke;

/// <summary>Functions, structures and constants from ProjectedFSLib.dll.</summary>
public static partial class ProjectedFSLib
{
	/// <summary>Notifies the provider that an operation by an earlier invocation of a callback should be canceled.</summary>
	/// <param name="callbackData">
	/// <para>Information about the operation. The following</para>
	/// <para>callbackData</para>
	/// <para>members are necessary to implement this callback:</para>
	/// </param>
	/// <returns>None</returns>
	/// <remarks>
	/// <para>
	/// Every invocation of a provider callback has a callbackData parameter with a <c>CommandId</c> field. If a provider supplies an
	/// implementation of this callback, it should keep track of the <c>CommandId</c> values of callbacks that it processes
	/// asynchronously, i.e. callbacks from which it has returned <c>HRESULT_FROM_WIN32(ERROR_IO_PENDING)</c> but not yet completed by
	/// calling PrjCompleteCommand. If the provider receives this callback, it indicates that the I/O that caused the earlier callback
	/// to be invoked was canceled, either explicitly or because the thread it was issued on terminated. The provider should cancel
	/// processing the callback invocation identified by <c>CommandId</c> as soon as possible.
	/// </para>
	/// <para>
	/// Calling PrjCompleteCommand for the <c>CommandId</c> in this callback's callbackData is not an error, however it is a no-op
	/// because the I/O that caused the callback invocation identified by <c>CommandId</c> has already ended.
	/// </para>
	/// <para>
	/// ProjFS will invoke PRJ_CANCEL_COMMAND_CB for a given <c>CommandId</c> only after the callback to be canceled is invoked. However
	/// if the provider is configured to allow more than one concurrently running worker thread, the cancellation and original
	/// invocation may run concurrently. The provider must be able to handle this situation.
	/// </para>
	/// <para>
	/// This callback is optional. If the provider does not supply an implementation of this callback, none of the other callbacks will
	/// be cancellable. The provider will process all callbacks synchronously.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/projectedfslib/nc-projectedfslib-prj_cancel_command_cb PRJ_CANCEL_COMMAND_CB
	// PrjCancelCommandCb; void PrjCancelCommandCb( const PRJ_CALLBACK_DATA *callbackData ) {...}
	[PInvokeData("projectedfslib.h", MSDNShortId = "8C646A8C-7C55-4F54-965A-04ACAC64C65D")]
	public delegate void PRJ_CANCEL_COMMAND_CB(in PRJ_CALLBACK_DATA callbackData);

	/// <summary>Informs the provider that a directory enumeration is over.</summary>
	/// <param name="callbackData">
	/// <para>Information about the operation.</para>
	/// <para>
	/// The provider can access this buffer only while the callback is running. If it wishes to pend the operation and it requires data
	/// from this buffer, it must make its own copy of it.
	/// </para>
	/// </param>
	/// <param name="enumerationId">
	/// An identifier for this enumeration session. See the Remarks section of PRJ_START_DIRECTORY_ENUMERATION_CB for more information.
	/// </param>
	/// <returns>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>S_OK</term>
	/// <term>The provider successfully completed the operation.</term>
	/// </item>
	/// <item>
	/// <term>HRESULT_FROM_WIN32(ERROR_IO_PENDING)</term>
	/// <term>The provider wishes to complete the operation at a later time.</term>
	/// </item>
	/// </list>
	/// <para>The provider should not return any other value from this callback.</para>
	/// </returns>
	/// <remarks>
	/// For a user-initiated enumeration ProjFS invokes this callback when the file handle used to enumerate the directory is closed.
	/// For a ProjFS-initiated enumeration, this callback is invoked when ProjFS completes the enumeration.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/projectedfslib/nc-projectedfslib-prj_end_directory_enumeration_cb
	// PRJ_END_DIRECTORY_ENUMERATION_CB PrjEndDirectoryEnumerationCb; HRESULT PrjEndDirectoryEnumerationCb( const PRJ_CALLBACK_DATA
	// *callbackData, const GUID *enumerationId ) {...}
	[PInvokeData("projectedfslib.h", MSDNShortId = "E9DA86AC-E884-4DB3-977D-6D8EDA2A8E12")]
	public delegate HRESULT PRJ_END_DIRECTORY_ENUMERATION_CB(in PRJ_CALLBACK_DATA callbackData, in Guid enumerationId);

	/// <summary>Requests directory enumeration information from the provider.</summary>
	/// <param name="callbackData">
	/// <para>Information about the operation. The following</para>
	/// <para>callbackData</para>
	/// <para>members are necessary to implement this callback:</para>
	/// <para>
	/// The provider can access this buffer only while the callback is running. If it wishes to pend the operation and it requires data
	/// from this buffer, it must make its own copy of it.
	/// </para>
	/// </param>
	/// <param name="enumerationId">An identifier for this enumeration session.</param>
	/// <param name="searchExpression">
	/// <para>
	/// A pointer to a null-terminated Unicode string specifying a search expression. The search expression may include wildcard
	/// characters. The provider should use the PrjDoesNameContainWildCards function to determine whether wildcards are present in
	/// <c>searchExpression</c>, and it should use the PrjFileNameMatch function to determine whether an entry in its backing store
	/// matches a search expression containing wildcards.
	/// </para>
	/// <para>This parameter is optional and may be NULL.</para>
	/// <list type="bullet">
	/// <item>
	/// <term>If this parameter is not NULL, the provider must return only those directory entries whose names match the search expression.</term>
	/// </item>
	/// <item>
	/// <term>If this parameter is NULL, the provider must return all directory entries.</term>
	/// </item>
	/// </list>
	/// <para>
	/// The provider should capture the value of this parameter on the first invocation of this callback for an enumeration session and
	/// use it on subsequent invocations, ignoring this parameter on those invocations unless <c>PRJ_CB_DATA_FLAG_ENUM_RESTART_SCAN</c>
	/// is specified in the <c>Flags</c> member of <c>callbackData</c>. In that case the provider must re-capture the value of <c>searchExpression.</c>
	/// </para>
	/// </param>
	/// <param name="dirEntryBufferHandle">
	/// An opaque handle to a structure that receives the results of the enumeration from the provider. The provider uses the
	/// PrjFillDirEntryBuffer routine to fill the structure.
	/// </param>
	/// <returns>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>S_OK</term>
	/// <term>
	/// The provider successfully added at least one entry to dirEntryBufferHandle, or no entries in the provider’s store match searchExpression.
	/// </term>
	/// </item>
	/// <item>
	/// <term>HRESULT_FROM_WIN32(ERROR_INSUFFICIENT_BUFFER)</term>
	/// <term>The provider received this error from PrjFillDirEntryBuffer for the first file or directory it tried to add to dirEntryBufferHandle.</term>
	/// </item>
	/// <item>
	/// <term>HRESULT_FROM_WIN32(ERROR_IO_PENDING)</term>
	/// <term>The provider wishes to complete the operation at a later time.</term>
	/// </item>
	/// </list>
	/// <para>An appropriate HRESULT error code if the provider fails the operation.</para>
	/// </returns>
	/// <remarks>
	/// ProjFS invokes this callback one or more times after invoking PRJ_START_DIRECTORY_ENUMERATION_CB. See the Remarks section of
	/// PRJ_START_DIRECTORY_ENUMERATION_CB for more information.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/projectedfslib/nc-projectedfslib-prj_get_directory_enumeration_cb
	// PRJ_GET_DIRECTORY_ENUMERATION_CB PrjGetDirectoryEnumerationCb; HRESULT PrjGetDirectoryEnumerationCb( const PRJ_CALLBACK_DATA
	// *callbackData, const GUID *enumerationId, PCWSTR searchExpression, PRJ_DIR_ENTRY_BUFFER_HANDLE dirEntryBufferHandle ) {...}
	[PInvokeData("projectedfslib.h", MSDNShortId = "45E7E7F9-9E54-44C8-9915-43CCECF85DB6")]
	public delegate HRESULT PRJ_GET_DIRECTORY_ENUMERATION_CB(in PRJ_CALLBACK_DATA callbackData, in Guid enumerationId, [MarshalAs(UnmanagedType.LPWStr)] string searchExpression, PRJ_DIR_ENTRY_BUFFER_HANDLE dirEntryBufferHandle);

	/// <summary>Requests the contents of a file's primary data stream.</summary>
	/// <param name="callbackData">
	/// <para>Information about the operation. The following</para>
	/// <para>callbackData</para>
	/// <para>members are necessary to implement this callback:</para>
	/// <para>
	/// The provider can access this buffer only while the callback is running. If it wishes to pend the operation and it requires data
	/// from this buffer, it must make its own copy of it.
	/// </para>
	/// </param>
	/// <param name="byteOffset">
	/// Offset of the requested data, in bytes, from the beginning of the file. The provider must return file data starting at or before
	/// this offset
	/// </param>
	/// <param name="length">
	/// Number of bytes of file data requested. The provider must return at least this many bytes of file data beginning with byteOffset.
	/// </param>
	/// <returns>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>S_OK</term>
	/// <term>The provider successfully returned all the requested data.</term>
	/// </item>
	/// <item>
	/// <term>HRESULT_FROM_WIN32(ERROR_IO_PENDING)</term>
	/// <term>The provider wishes to complete the operation at a later time.</term>
	/// </item>
	/// </list>
	/// <para>An appropriate HRESULT error code if the provider fails the operation.</para>
	/// </returns>
	/// <remarks>
	/// <para>When ProjFS receives the data it will write it to the file to convert it into a hydrated placeholder.</para>
	/// <para>
	/// To handle this callback, the provider issues one or more calls to PrjWriteFileData to give ProjFS the requested contents of the
	/// file's primary data stream. Then the provider completes the callback.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/projectedfslib/nc-projectedfslib-prj_get_file_data_cb PRJ_GET_FILE_DATA_CB
	// PrjGetFileDataCb; HRESULT PrjGetFileDataCb( const PRJ_CALLBACK_DATA *callbackData, UINT64 byteOffset, UINT32 length ) {...}
	[PInvokeData("projectedfslib.h", MSDNShortId = "8F3EEC96-70C2-40ED-BDF3-B6E979EF1F7E")]
	public delegate HRESULT PRJ_GET_FILE_DATA_CB(in PRJ_CALLBACK_DATA callbackData, ulong byteOffset, uint length);

	/// <summary>Requests information for a file or directory from the provider.</summary>
	/// <param name="callbackData">
	/// <para>Information about the operation. The following</para>
	/// <para>callbackData</para>
	/// <para>members are necessary to implement this callback:</para>
	/// <para>
	/// The provider can access this buffer only while the callback is running. If it wishes to pend the operation and it requires data
	/// from this buffer, it must make its own copy of it.
	/// </para>
	/// </param>
	/// <returns>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>S_OK</term>
	/// <term>The file exists in the provider's store and it successfully gave the file's information to ProjFS.</term>
	/// </item>
	/// <item>
	/// <term>HRESULT_FROM_WIN32(ERROR_IO_PENDING)</term>
	/// <term>The provider wishes to complete the operation at a later time.</term>
	/// </item>
	/// <item>
	/// <term>HRESULT_FROM_WIN32(ERROR_FILE_NOT_FOUND)</term>
	/// <term>The file does not exist in the provider's store.</term>
	/// </item>
	/// </list>
	/// <para>Another appropriate HRESULT error code if the provider fails the operation.</para>
	/// </returns>
	/// <remarks>
	/// <para>ProjFS will use the information provided in this callback to create a placeholder for the requested item.</para>
	/// <para>
	/// To handle this callback, the provider calls PrjWritePlaceholderInfo to give ProjFS the information for the requested file name.
	/// Then the provider completes the callback.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/projectedfslib/nc-projectedfslib-prj_get_placeholder_info_cb
	// PRJ_GET_PLACEHOLDER_INFO_CB PrjGetPlaceholderInfoCb; HRESULT PrjGetPlaceholderInfoCb( const PRJ_CALLBACK_DATA *callbackData ) {...}
	[PInvokeData("projectedfslib.h", MSDNShortId = "1BC7C1FA-1BAB-48FB-85C2-34EC3B1B4167")]
	public delegate HRESULT PRJ_GET_PLACEHOLDER_INFO_CB(in PRJ_CALLBACK_DATA callbackData);

	/// <summary>Delivers notifications to the provider about file system operations.</summary>
	/// <param name="callbackData">
	/// <para>Information about the operation. The following</para>
	/// <para>callbackData</para>
	/// <para>members are necessary to implement this callback:</para>
	/// <para>
	/// The provider can access this buffer only while the callback is running. If it wishes to pend the operation and it requires data
	/// from this buffer, it must make its own copy of it.
	/// </para>
	/// </param>
	/// <param name="isDirectory">TRUE if the <c>FilePathName</c> field in callbackData refers to a directory, FALSE otherwise.</param>
	/// <param name="notification">A PRJ_NOTIFICATIONvalue specifying the notification.</param>
	/// <param name="destinationFileName">
	/// If <c>notification</c> is <c>PRJ_NOTIFICATION_PRE_RENAME</c> or <c>PRJ_NOTIFICATION_PRE_SET_HARDLINK</c>, this points to a
	/// null-terminated Unicode string specifying the path, relative to the virtualization root, of the target of the rename or
	/// set-hardlink operation.
	/// </param>
	/// <param name="operationParameters">
	/// <para>A pointer to a PRJ_NOTIFICATION_PARAMETERS union specifying extra parameters for certain values of notification:</para>
	/// <para>PRJ_NOTIFICATION_FILE_OPENED</para>
	/// <para>,</para>
	/// <para>PRJ_NOTIFICATION_NEW_FILE_CREATED</para>
	/// <para>, or</para>
	/// <para>PRJ_NOTIFICATION_FILE_OVERWRITTEN</para>
	/// <para>PRJ_NOTIFICATION_FILE_RENAMED</para>
	/// <para>PRJ_NOTIFICATION_FILE_HANDLE_CLOSED_FILE_DELETED</para>
	/// <list type="bullet">
	/// <item>
	/// <term>The fields of the <c>FileDeletedOnHandleClose</c> member are specified. These fields are: <c>NotificationMask</c></term>
	/// </item>
	/// </list>
	/// </param>
	/// <returns>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>S_OK</term>
	/// <term>The provider successfully processed the notification.</term>
	/// </item>
	/// <item>
	/// <term>HRESULT_FROM_WIN32(ERROR_IO_PENDING)</term>
	/// <term>The provider wishes to complete the operation at a later time.</term>
	/// </item>
	/// </list>
	/// <para>
	/// An appropriate HRESULT error code if the provider fails the operation. For pre-operation notifications (operations with "PRE" in
	/// their name), if the provider returns a failure code ProjFS will fail the corresponding operation with the provided error code.
	/// </para>
	/// </returns>
	/// <remarks>
	/// <para>This callback is optional. If the provider does not supply an implementation of this callback, it will not receive notifications.</para>
	/// <para>The provider registers for the notifications it wishes to receive when it calls PrjStartVirtualizing.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/projectedfslib/nc-projectedfslib-prj_notification_cb PRJ_NOTIFICATION_CB
	// PrjNotificationCb; HRESULT PrjNotificationCb( const PRJ_CALLBACK_DATA *callbackData, BOOLEAN isDirectory, PRJ_NOTIFICATION
	// notification, PCWSTR destinationFileName, PRJ_NOTIFICATION_PARAMETERS *operationParameters ) {...}
	[PInvokeData("projectedfslib.h", MSDNShortId = "7F149A78-2668-4BF2-88D3-1E40CA469AA6")]
	public delegate HRESULT PRJ_NOTIFICATION_CB(in PRJ_CALLBACK_DATA callbackData, [MarshalAs(UnmanagedType.U1)] bool isDirectory, PRJ_NOTIFICATION notification,
		[MarshalAs(UnmanagedType.LPWStr)] string destinationFileName, ref PRJ_NOTIFICATION_PARAMETERS operationParameters);

	/// <summary>Determines whether a given file path exists in the provider's backing store.</summary>
	/// <param name="callbackData">Information about the operation.</param>
	/// <returns>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>S_OK</term>
	/// <term>The queried file path exists in the provider's store.</term>
	/// </item>
	/// <item>
	/// <term>HRESULT_FROM_WIN32(ERROR_FILE_NOT_FOUND)</term>
	/// <term>The queried file path does not exist in the provider's store.</term>
	/// </item>
	/// <item>
	/// <term>HRESULT_FROM_WIN32(ERROR_IO_PENDING)</term>
	/// <term>The provider wishes to complete the operation at a later time.</term>
	/// </item>
	/// </list>
	/// <para>An appropriate HRESULT error code if the provider fails the operation.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// This callback is optional. If the provider does not supply an implementation of this callback, ProjFS will invoke the provider’s
	/// directory enumeration callbacks to determine the existence of a file path in the provider's store.
	/// </para>
	/// <para>
	/// The provider should use PrjFileNameCompare as the comparison routine when searching its backing store for the specified file.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/projectedfslib/nc-projectedfslib-prj_query_file_name_cb PRJ_QUERY_FILE_NAME_CB
	// PrjQueryFileNameCb; HRESULT PrjQueryFileNameCb( const PRJ_CALLBACK_DATA *callbackData ) {...}
	[PInvokeData("projectedfslib.h", MSDNShortId = "1B218D41-AF24-48C2-9E11-7E0455CE15AC")]
	public delegate HRESULT PRJ_QUERY_FILE_NAME_CB(in PRJ_CALLBACK_DATA callbackData);

	/// <summary>Informs the provider that a directory enumeration is starting.</summary>
	/// <param name="callbackData">
	/// <para>Information about the operation. The following</para>
	/// <para>callbackData</para>
	/// <para>members are necessary to implement this callback:</para>
	/// <para>
	/// The provider can access this buffer only while the callback is running. If it wishes to pend the operation and it requires data
	/// from this buffer, it must make its own copy of it.
	/// </para>
	/// </param>
	/// <param name="enumerationId">An identifier for this enumeration session.</param>
	/// <returns>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>S_OK</term>
	/// <term>The provider successfully completed the operation.</term>
	/// </item>
	/// <item>
	/// <term>HRESULT_FROM_WIN32(ERROR_FILE_NOT_FOUND)</term>
	/// <term>The directory to be enumerated does not exist in the provider’s backing store.</term>
	/// </item>
	/// <item>
	/// <term>HRESULT_FROM_WIN32(ERROR_IO_PENDING)</term>
	/// <term>The provider wishes to complete the operation at a later time.</term>
	/// </item>
	/// </list>
	/// <para>An appropriate HRESULT error code if the provider fails the operation.</para>
	/// </returns>
	/// <remarks>
	/// ProjFS requests a directory enumeration from the provider by first invoking this callback, then one or more
	/// PRJ_GET_DIRECTORY_ENUMERATION_CB callbacks, then the PRJ_END_DIRECTORY_ENUMERATION_CB callback. Because multiple enumerations
	/// may occur in parallel in the same location, ProjFS uses the enumerationId argument to associate the callback invocations into a
	/// single enumeration session, meaning that a given set of calls to the enumeration callbacks will use the same value for
	/// enumerationId for the same session.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/projectedfslib/nc-projectedfslib-prj_start_directory_enumeration_cb
	// PRJ_START_DIRECTORY_ENUMERATION_CB PrjStartDirectoryEnumerationCb; HRESULT PrjStartDirectoryEnumerationCb( const
	// PRJ_CALLBACK_DATA *callbackData, const GUID *enumerationId ) {...}
	[PInvokeData("projectedfslib.h", MSDNShortId = "09F284D4-BF39-42C9-A89B-DDC8201362EE")]
	public delegate HRESULT PRJ_START_DIRECTORY_ENUMERATION_CB(in PRJ_CALLBACK_DATA callbackData, in Guid enumerationId);

	/// <summary>Flags controlling what is returned in the enumeration.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/projectedfslib/ne-projectedfslib-prj_callback_data_flags typedef enum
	// PRJ_CALLBACK_DATA_FLAGS { PRJ_CB_DATA_FLAG_ENUM_RESTART_SCAN, PRJ_CB_DATA_FLAG_ENUM_RETURN_SINGLE_ENTRY } ;
	[PInvokeData("projectedfslib.h", MSDNShortId = "5046714B-64AC-458D-93C7-013B1466C655")]
	[Flags]
	public enum PRJ_CALLBACK_DATA_FLAGS
	{
		/// <summary>Start the scan at the first entry in the directory.</summary>
		PRJ_CB_DATA_FLAG_ENUM_RESTART_SCAN = 0x1,

		/// <summary>Return only one entry from the enumeration.</summary>
		PRJ_CB_DATA_FLAG_ENUM_RETURN_SINGLE_ENTRY = 0x2,
	}

	/// <summary>Specifies command types.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/projectedfslib/ne-projectedfslib-prj_complete_command_type typedef enum
	// PRJ_COMPLETE_COMMAND_TYPE { PRJ_COMPLETE_COMMAND_TYPE_NOTIFICATION, PRJ_COMPLETE_COMMAND_TYPE_ENUMERATION } ;
	[PInvokeData("projectedfslib.h", MSDNShortId = "AE9CD44C-0E68-4E35-8A7E-89B33E796AF0")]
	public enum PRJ_COMPLETE_COMMAND_TYPE
	{
		/// <summary>The provider is completing a call to its PRJ_NOTIFICATION_CB callback.</summary>
		PRJ_COMPLETE_COMMAND_TYPE_NOTIFICATION = 1,

		/// <summary>The provider is completing a call to its PRJ_GET_DIRECTORY_ENUMERATION_CB callback.</summary>
		PRJ_COMPLETE_COMMAND_TYPE_ENUMERATION,
	}

	/// <summary>Specifies extended information types for PRJ_EXTENDED_INFO.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/projectedfslib/ne-projectedfslib-prj_ext_info_type typedef enum
	// PRJ_EXT_INFO_TYPE { PRJ_EXT_INFO_TYPE_SYMLINK } ;
	[PInvokeData("projectedfslib.h", MSDNShortId = "NE:projectedfslib.PRJ_EXT_INFO_TYPE")]
	public enum PRJ_EXT_INFO_TYPE
	{
		/// <summary>This PRJ_EXTENDED_INFO specifies the target of a symbolic link.</summary>
		PRJ_EXT_INFO_TYPE_SYMLINK = 1
	}

	/// <summary>The state of an item.</summary>
	/// <remarks>
	/// The PRJ_FILE_STATE_FULL and PRJ_FILE_STATE_TOMBSTONE bits will not appear in combination with each other or any other bit.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/projectedfslib/ne-projectedfslib-prj_file_state typedef enum PRJ_FILE_STATE {
	// PRJ_FILE_STATE_PLACEHOLDER, PRJ_FILE_STATE_HYDRATED_PLACEHOLDER, PRJ_FILE_STATE_DIRTY_PLACEHOLDER, PRJ_FILE_STATE_FULL,
	// PRJ_FILE_STATE_TOMBSTONE } ;
	[PInvokeData("projectedfslib.h", MSDNShortId = "9474C21B-47D4-468F-A970-0B0CBCF357A3")]
	[Flags]
	public enum PRJ_FILE_STATE : uint
	{
		/// <summary>The item is a placeholder.</summary>
		PRJ_FILE_STATE_PLACEHOLDER = 0x01,

		/// <summary>The item is a hydrated placeholder, i.e., the item's content has been written to disk.</summary>
		PRJ_FILE_STATE_HYDRATED_PLACEHOLDER = 0x02,

		/// <summary>The placeholder item's metadata has been modified.</summary>
		PRJ_FILE_STATE_DIRTY_PLACEHOLDER = 0x04,

		/// <summary>The item is full.</summary>
		PRJ_FILE_STATE_FULL = 0x08,

		/// <summary>The item is a tombstone.</summary>
		PRJ_FILE_STATE_TOMBSTONE = 0x10,
	}

	/// <summary>A notification value specified when sending the PRJ_NOTIFICATION_CB callback.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/projectedfslib/ne-projectedfslib-prj_notification typedef enum
	// PRJ_NOTIFICATION { PRJ_NOTIFICATION_FILE_OPENED, PRJ_NOTIFICATION_NEW_FILE_CREATED, PRJ_NOTIFICATION_FILE_OVERWRITTEN,
	// PRJ_NOTIFICATION_PRE_DELETE, PRJ_NOTIFICATION_PRE_RENAME, PRJ_NOTIFICATION_PRE_SET_HARDLINK, PRJ_NOTIFICATION_FILE_RENAMED,
	// PRJ_NOTIFICATION_HARDLINK_CREATED, PRJ_NOTIFICATION_FILE_HANDLE_CLOSED_NO_MODIFICATION,
	// PRJ_NOTIFICATION_FILE_HANDLE_CLOSED_FILE_MODIFIED, PRJ_NOTIFICATION_FILE_HANDLE_CLOSED_FILE_DELETED,
	// PRJ_NOTIFICATION_FILE_PRE_CONVERT_TO_FULL } ;
	[PInvokeData("projectedfslib.h", MSDNShortId = "A1DC0CAF-0101-4410-86A6-5839A8C20988")]
	[Flags]
	public enum PRJ_NOTIFICATION : uint
	{
		/// <summary>
		/// - Indicates that a handle has been created to an existing file or folder.- The provider can specify a new notification mask
		/// for this file or folder when responding to the notification.
		/// </summary>
		PRJ_NOTIFICATION_FILE_OPENED = 0x00000002,

		/// <summary>
		/// - A new file or folder has been created.- The provider can specify a new notification mask for this file or folder when
		/// responding to the notification.
		/// </summary>
		PRJ_NOTIFICATION_NEW_FILE_CREATED = 0x00000004,

		/// <summary>
		/// - An existing file has been overwritten or superceded.- The provider can specify a new notification mask for this file or
		/// folder when responding to the notification.
		/// </summary>
		PRJ_NOTIFICATION_FILE_OVERWRITTEN = 0x00000008,

		/// <summary>
		/// - A file or folder is about to be deleted.- If the provider returns an error HRESULT code from the callback, the delete will
		/// not take effect.
		/// </summary>
		PRJ_NOTIFICATION_PRE_DELETE = 0x00000010,

		/// <summary>
		/// - A file or folder is about to be renamed.- If the provider returns an error HRESULT code from the callback, the rename will
		/// not take effect.- If the callbackData-&gt;FilePathName parameter of PRJ_NOTIFICATION_CB is an empty string, this indicates
		/// that the rename is moving the file/directory from outside the virtualization instance. In that case, this notification will
		/// always be sent if the provider has registered a PRJ_NOTIFICATION_CB callback, even if the provider did not specify this bit
		/// when registering the subtree containing the destination path. However if the provider specified
		/// PRJ_NOTIFICATION_SUPPRESS_NOTIFICATIONS when registering the subtree containing the destination path, the notification will
		/// be suppressed. - If the destinationFileName parameter of PRJ_NOTIFICATION_CB is an empty string, this indicates that the
		/// rename is moving the file/folder out of the virtualization instance. - If both the callbackData-&gt;FilePathName and
		/// destinationFileName parameters of PRJ_NOTIFICATION_CB are non-empty strings, this indicates that the rename is within the
		/// virtualization instance. If the provider specified different notification masks for the source and destination paths in the
		/// NotificationMappings member of the options parameter of PrjStartVirtualizing, then this notification will be sent if the
		/// provider specified this bit when registering either the source or destination paths.
		/// </summary>
		PRJ_NOTIFICATION_PRE_RENAME = 0x00000020,

		/// <summary>
		/// - A hard link is about to be created for the file.- If the provider returns an error HRESULT code from the callback, the
		/// hard link operation will not take effect. - If the callbackData-&gt;FilePathName parameter of PRJ_NOTIFICATION_CB is an
		/// empty string, this indicates that the hard link name will be created inside the virtualization instance, i.e. a new hard
		/// link is being created inside the virtualization instance to a file that exists outside the virtualization instance. In that
		/// case, this notification will always be sent if the provider has registered a PRJ_NOTIFICATION_CB callback, even if the
		/// provider did not specify this bit when registering the subtree where the new hard link name will be. However if the provider
		/// specified PRJ_NOTIFICATION_SUPPRESS_NOTIFICATIONS when registering the subtree containing the destination path, the
		/// notification will be suppressed.- If the destinationFileName parameter of PRJ_NOTIFICATION_CB is an empty string, this
		/// indicates that the hard link name will be created outside the virtualization instance, i.e. a new hard link is being created
		/// outside the virtualization instance for a file that exists inside the virtualization instance. - If both the
		/// callbackData-&gt;FilePathName and destinationFileName parameters of PRJ_NOTIFICATION_CB are non-empty strings, this
		/// indicates that the new hard link will be created within the virtualization instance for a file that exists within the
		/// virtualization instance. If the provider specified different notification masks for the source and destination paths in the
		/// NotificationMappings member of the options parameter of PrjStartVirtualizing, then this notification will be sent if the
		/// provider specified this bit when registering either the source or destination paths.
		/// </summary>
		PRJ_NOTIFICATION_PRE_SET_HARDLINK = 0x00000040,

		/// <summary>
		/// - Indicates that a file/folder has been renamed. The file/folder may have been moved into the virtualization instance.- If
		/// the callbackData-&gt;FilePathName parameter of PRJ_NOTIFICATION_CB is an empty string, this indicates that the rename moved
		/// the file/directory from outside the virtualization instance. In that case ProjFS will always send this notification if the
		/// provider has registered a PRJ_NOTIFICATION_CB callback, even if the provider did not specify this bit when registering the
		/// subtree containing the destination path. - If the destinationFileName parameter of PRJ_NOTIFICATION_CB is an empty string,
		/// this indicates that the rename moved the file/directory out of the virtualization instance. - If both the
		/// callbackData-&gt;FilePathName and destinationFileName parameters of PRJ_NOTIFICATION_CB are non-empty strings, this
		/// indicates that the rename was within the virtualization instance. If the provider specified different notification masks for
		/// the source and destination paths in the NotificationMappings member of the options parameter of PrjStartVirtualizing, then
		/// ProjFS will send this notification if the provider specified this bit when registering either the source or destination
		/// paths.- The provider can specify a new notification mask for this file/directory when responding to the notification.
		/// </summary>
		PRJ_NOTIFICATION_FILE_RENAMED = 0x00000080,

		/// <summary>
		/// - Indicates that a hard link has been created for the file. - If the callbackData-&gt;FilePathName parameter of
		/// PRJ_NOTIFICATION_CB is an empty string, this indicates that the hard link name was created inside the virtualization
		/// instance, i.e. a new hard link was created inside the virtualization instance to a file that exists outside the
		/// virtualization instance. In that case ProjFS will always send this notification if the provider has registered a
		/// PRJ_NOTIFICATION_CB callback, even if the provider did not specify this bit when registering the subtree where the new hard
		/// link name will be. - If the destinationFileName parameter of PRJ_NOTIFICATION_CB is an empty string, this indicates that the
		/// hard link name was created outside the virtualization instance, i.e. a new hard link was created outside the virtualization
		/// instance for a file that exists inside the virtualization instance. - If both the callbackData-&gt;FilePathName and
		/// destinationFileName parameters of PRJ_NOTIFICATION_CB are non-empty strings, this indicates that the a new hard link was
		/// created within the virtualization instance for a file that exists within the virtualization instance. If the provider
		/// specified different notification masks for the source and destination paths in the NotificationMappings member of the
		/// options parameter of PrjStartVirtualizing, then ProjFS will send this notification if the provider specified this bit when
		/// registering either the source or destination paths.
		/// </summary>
		PRJ_NOTIFICATION_HARDLINK_CREATED = 0x00000100,

		/// <summary>
		/// - A handle has been closed on the file/folder, and the file's content was not modified while the handle was open, and the
		/// file/folder was not deleted
		/// </summary>
		PRJ_NOTIFICATION_FILE_HANDLE_CLOSED_NO_MODIFICATION = 0x00000200,

		/// <summary>- A handle has been closed on the file, and that the file's content was modified while the handle was open.</summary>
		PRJ_NOTIFICATION_FILE_HANDLE_CLOSED_FILE_MODIFIED = 0x00000400,

		/// <summary>
		/// - A handle has been closed on the file/folder, and that it was deleted as part of closing the handle. - If the provider also
		/// registered to receive PRJ_NOTIFICATION_FILE_HANDLE_CLOSED_FILE_MODIFIED notifications, and the file was modified using the
		/// handle whose close resulted in deleting the file, then the operationParameters-&gt;FileDeletedOnHandleClose.IsFileModified
		/// parameter of PRJ_NOTIFICATION_CB will be TRUE. This applies only to files, not directories
		/// </summary>
		PRJ_NOTIFICATION_FILE_HANDLE_CLOSED_FILE_DELETED = 0x00000800,

		/// <summary>
		/// - The file is about to be expanded from a placeholder to a full file, i.e. its contents are likely to be modified.- If the
		/// provider returns an error HRESULT code from the callback, the file will not be expanded to a full file, and the I/O that
		/// triggered the conversion will fail.- If there are multiple racing I/Os that would expand the same file, the provider will
		/// receive this notification value only once for the file.
		/// </summary>
		PRJ_NOTIFICATION_FILE_PRE_CONVERT_TO_FULL = 0x00001000,
	}

	/// <summary>Types of notifications describing a change to the file or folder.</summary>
	/// <remarks>
	/// <para>
	/// ProjFS can send notifications of file system activity to a provider. When the provider starts a virtualization instance it
	/// specifies which notifications it wishes to receive. It may also specify a new set of notifications for a file when it is created
	/// or renamed. The provider must register a PRJ_NOTIFICATION_CB notification callback routine in the callbacks parameter of
	/// PrjStartVirtualizing in order to receive notifications.
	/// </para>
	/// <para>
	/// ProjFS sends notifications for files and directories within an active virtualization root. That is, ProjFS will send
	/// notifications for the virtualization root and its descendants. Symbolic links and junctions within the virtualization root are
	/// not traversed when determining what constitutes a descendant of the virtualization root.
	/// </para>
	/// <para>
	/// ProjFS sends notifications only for the primary data stream of a file. ProjFS does not send notifications for operations on
	/// alternate data streams.
	/// </para>
	/// <para>
	/// ProjFS does not send notifications for an inactive virtualization instance. A virtualization instance is inactive if any one of
	/// the following is true:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>The provider has not yet started it by calling PrjStartVirtualizing.</term>
	/// </item>
	/// <item>
	/// <term>The provider has stopped the instance by calling PrjStopVirtualizing.</term>
	/// </item>
	/// <item>
	/// <term>The provider process has exited</term>
	/// </item>
	/// </list>
	/// <para>
	/// The provider may specify which notifications it wishes to receive when starting a virtualization instance, or in response to a
	/// notification that allows a new notification mask to be set.
	/// </para>
	/// <para>
	/// The provider specifies a default set of notifications that it wants ProjFS to send for the virtualization instance when it
	/// starts the instance. This set of notifications is provided in the NotificationMappings member of the options parameter of
	/// PrjStartVirtualizing, which may specify different notification masks for different subtrees of the virtualization instance.
	/// </para>
	/// <para>
	/// The provider may choose to supply a different notification mask in response to a notification of file open, create,
	/// supersede/overwrite, or rename. ProjFS will continue to send these notifications for the given file until all handles to the
	/// file are closed. After that it will revert to the default set of notifications. Naturally if the default set of notifications
	/// does not specify that ProjFS should notify for open, create, etc., the provider will not get the opportunity to specify a
	/// different mask for those operations.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/projectedfslib/ne-projectedfslib-prj_notify_types typedef enum
	// PRJ_NOTIFY_TYPES { PRJ_NOTIFY_NONE, PRJ_NOTIFY_SUPPRESS_NOTIFICATIONS, PRJ_NOTIFY_FILE_OPENED, PRJ_NOTIFY_NEW_FILE_CREATED,
	// PRJ_NOTIFY_FILE_OVERWRITTEN, PRJ_NOTIFY_PRE_DELETE, PRJ_NOTIFY_PRE_RENAME, PRJ_NOTIFY_PRE_SET_HARDLINK, PRJ_NOTIFY_FILE_RENAMED,
	// PRJ_NOTIFY_HARDLINK_CREATED, PRJ_NOTIFY_FILE_HANDLE_CLOSED_NO_MODIFICATION, PRJ_NOTIFY_FILE_HANDLE_CLOSED_FILE_MODIFIED,
	// PRJ_NOTIFY_FILE_HANDLE_CLOSED_FILE_DELETED, PRJ_NOTIFY_FILE_PRE_CONVERT_TO_FULL, PRJ_NOTIFY_USE_EXISTING_MASK } ;
	[PInvokeData("projectedfslib.h", MSDNShortId = "AB19AD36-44FB-4CA8-9101-4EEF2646A46C")]
	[Flags]
	public enum PRJ_NOTIFY_TYPES : uint
	{
		/// <summary>No notification.</summary>
		PRJ_NOTIFY_NONE = 0x00000000,

		/// <summary>
		/// If specified on virtualization instance start:- This indicates that notifications should not be sent for the virtualization
		/// instance, or a specified subtree of the instance.If specified in response to a notification:- This indicates that
		/// notifications should not be sent for the specified file or folder until all handles to it are closed.
		/// </summary>
		PRJ_NOTIFY_SUPPRESS_NOTIFICATIONS = 0x00000001,

		/// <summary>
		/// If specified on virtualization instance start:- This indicates that the provider should be notified when a handle is created
		/// to an existing file or folder.If specified in response to a notification:- This indicates that the provider should be
		/// notified if any further handles are created to the file or folder.
		/// </summary>
		PRJ_NOTIFY_FILE_OPENED = 0x00000002,

		/// <summary>
		/// If specified on virtualization instance start:- The provider should be notified when a new file or folder is created.If
		/// specified in response to a notification:- No effect.
		/// </summary>
		PRJ_NOTIFY_NEW_FILE_CREATED = 0x00000004,

		/// <summary>
		/// If specified on virtualization instance start:- Indicates that the provider should be notified when an existing when an
		/// existing file is overwritten or superceded.If specified in response to a notification:- Indicates that the provider should
		/// be notified when the file or folder is overwritten or superceded.
		/// </summary>
		PRJ_NOTIFY_FILE_OVERWRITTEN = 0x00000008,

		/// <summary>
		/// If specified on virtualization instance start:- Indicates that the provider should be notified when a file or folder is
		/// about to be deleted.If specified in response to a notification:- Indicates that the provider should be notified when a file
		/// or folder is about to be deleted.
		/// </summary>
		PRJ_NOTIFY_PRE_DELETE = 0x00000010,

		/// <summary>
		/// If specified on virtualization instance start:- Indicates that the provider should be notified when a file or folder is
		/// about to be renamed.If specified in response to a notification:- Indicates that the provider should be notified when a file
		/// or folder is about to be renamed.
		/// </summary>
		PRJ_NOTIFY_PRE_RENAME = 0x00000020,

		/// <summary>
		/// If specified on virtualization instance start:- Indicates that the provider should be notified when a hard link is about to
		/// be created for a file.If specified in response to a notification:- Indicates that the provider should be notified when a
		/// hard link is about to be created for a file.
		/// </summary>
		PRJ_NOTIFY_PRE_SET_HARDLINK = 0x00000040,

		/// <summary>
		/// If specified on virtualization instance start:- Indicates that the provider should be notified that a file or folder has
		/// been renamed.If specified in response to a notification:- Indicates that the provider should be notified when a file or
		/// folder has been renamed.
		/// </summary>
		PRJ_NOTIFY_FILE_RENAMED = 0x00000080,

		/// <summary>
		/// If specified on virtualization instance start:- Indicates that the provider should be notified that a hard link has been
		/// created for a file.If specified in response to a notification:- Indicates that the provider should be notified that a hard
		/// link has been created for the file.
		/// </summary>
		PRJ_NOTIFY_HARDLINK_CREATED = 0x00000100,

		/// <summary>
		/// If specified on virtualization instance start:- The provider should be notified when a handle is closed on a file/folder and
		/// the closing handle neither modified nor deleted it.If specified in response to a notification:- The provider should be
		/// notified when handles are closed for the file/folder and there were no modifications or deletions associated with the
		/// closing handle.
		/// </summary>
		PRJ_NOTIFY_FILE_HANDLE_CLOSED_NO_MODIFICATION = 0x00000200,

		/// <summary>
		/// If specified on virtualization instance start:- The provider should be notified when a handle is closed on a file/folder and
		/// the closing handle was used to modify it.If specified in response to a notification:- The provider should be notified when a
		/// handle is closed on the file/folder and the closing handle was used to modify it.
		/// </summary>
		PRJ_NOTIFY_FILE_HANDLE_CLOSED_FILE_MODIFIED = 0x00000400,

		/// <summary>
		/// If specified on virtualization instance start:- The provider should be notified when a handle is closed on a file/folder and
		/// it is deleted as part of closing the handle.If specified in response to a notification:- The provider should be notified
		/// when a handle is closed on the file/folder and it is deleted as part of closing the handle.
		/// </summary>
		PRJ_NOTIFY_FILE_HANDLE_CLOSED_FILE_DELETED = 0x00000800,

		/// <summary>
		/// If specified on virtualization instance start:- The provider should be notified when it is about to convert a placeholder to
		/// a full file.If specified in response to a notification:- The provider should be notified when it is about to convert the
		/// placeholder to a full file, assuming it is a placeholder and not already a full file.
		/// </summary>
		PRJ_NOTIFY_FILE_PRE_CONVERT_TO_FULL = 0x00001000,

		/// <summary>
		/// If specified on virtualization instance start:- This value is not valid on virtualization instance start.If specified in
		/// response to a notification:- Continue to use the existing set of notifications for this file/folder.
		/// </summary>
		PRJ_NOTIFY_USE_EXISTING_MASK = 0xFFFFFFFF,
	}

	/// <summary>Defines the length of a placeholder identifier.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/projectedfslib/ne-projectedfslib-prj_placeholder_id typedef enum
	// PRJ_PLACEHOLDER_ID { PRJ_PLACEHOLDER_ID_LENGTH } ;
	[PInvokeData("projectedfslib.h", MSDNShortId = "6E8574B4-C83D-4B0C-9B80-5ACD0BC45C1C")]
	public enum PRJ_PLACEHOLDER_ID
	{
		/// <summary>The length of a placeholder identifier.</summary>
		PRJ_PLACEHOLDER_ID_LENGTH = 128,
	}

	/// <summary>Flags to provide when starting a virtualization instance.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/projectedfslib/ne-projectedfslib-prj_startvirtualizing_flags typedef enum
	// PRJ_STARTVIRTUALIZING_FLAGS { PRJ_FLAG_NONE, PRJ_FLAG_USE_NEGATIVE_PATH_CACHE } ;
	[PInvokeData("projectedfslib.h", MSDNShortId = "AF67668B-E9BC-4320-AB1F-1E78CA700D8E")]
	[Flags]
	public enum PRJ_STARTVIRTUALIZING_FLAGS
	{
		/// <summary>No flags.</summary>
		PRJ_FLAG_NONE = 0x0,

		/// <summary>
		/// Specifies that ProjFS should maintain a "negative path cache" for the virtualization instance. If the negative path cache is
		/// active, then if the provider indicates that a file path does not exist by returning HRESULT_FROM_WIN32(ERROR_FILE_NOT_FOUND)
		/// from its PRJ_GET_PLACEHOLDER_INFO_CB callback, ProjFS will fail subsequent opens of that path without calling the
		/// PRJ_GET_PLACEHOLDER_INFO_CB callback again. To resume receiving the PRJ_GET_PLACEHOLDER_INFO_CB for paths the provider has
		/// indicated do not exist, the provider must call PrjClearNegativePathCache.
		/// </summary>
		PRJ_FLAG_USE_NEGATIVE_PATH_CACHE = 0x1,
	}

	/// <summary>Descriptions for the reason an update failed.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/projectedfslib/ne-projectedfslib-prj_update_failure_causes typedef enum
	// PRJ_UPDATE_FAILURE_CAUSES { PRJ_UPDATE_FAILURE_CAUSE_NONE, PRJ_UPDATE_FAILURE_CAUSE_DIRTY_METADATA,
	// PRJ_UPDATE_FAILURE_CAUSE_DIRTY_DATA, PRJ_UPDATE_FAILURE_CAUSE_TOMBSTONE, PRJ_UPDATE_FAILURE_CAUSE_READ_ONLY } ;
	[PInvokeData("projectedfslib.h", MSDNShortId = "8C3375C5-507C-4336-8F6A-DE509F3F20D2")]
	[Flags]
	public enum PRJ_UPDATE_FAILURE_CAUSES
	{
		/// <summary>The update did not fail.</summary>
		PRJ_UPDATE_FAILURE_CAUSE_NONE = 0x00,

		/// <summary>
		/// The item was a dirty placeholder (hydrated or not), and the provider did not specify PRJ_UPDATE_ALLOW_DIRTY_METADATA in PRJ_UPDATE_TYPES.
		/// </summary>
		PRJ_UPDATE_FAILURE_CAUSE_DIRTY_METADATA = 0x01,

		/// <summary>The item was a full file and the provider did not specify PRJ_UPDATE_ALLOW_DIRTY_DATA in PRJ_UPDATE_TYPES.</summary>
		PRJ_UPDATE_FAILURE_CAUSE_DIRTY_DATA = 0x02,

		/// <summary>The item was a tombstone and the provider did not specify PRJ_UPDATE_ALLOW_TOMBSTONE in PRJ_UPDATE_TYPES.</summary>
		PRJ_UPDATE_FAILURE_CAUSE_TOMBSTONE = 0x04,

		/// <summary>The item had the DOS read-only bit set and the provider did not specify PRJ_UPDATE_ALLOW_READ_ONLY in PRJ_UPDATE_TYPES.</summary>
		PRJ_UPDATE_FAILURE_CAUSE_READ_ONLY = 0x08,
	}

	/// <summary>Flags to specify whether updates will be allowed given the state of a file or directory on disk.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/projectedfslib/ne-projectedfslib-prj_update_types typedef enum
	// PRJ_UPDATE_TYPES { PRJ_UPDATE_NONE, PRJ_UPDATE_ALLOW_DIRTY_METADATA, PRJ_UPDATE_ALLOW_DIRTY_DATA, PRJ_UPDATE_ALLOW_TOMBSTONE,
	// PRJ_UPDATE_RESERVED1, PRJ_UPDATE_RESERVED2, PRJ_UPDATE_ALLOW_READ_ONLY, PRJ_UPDATE_MAX_VAL } ;
	[PInvokeData("projectedfslib.h", MSDNShortId = "E0E6F600-3B06-42D0-A87F-FAB4990562D0")]
	[Flags]
	public enum PRJ_UPDATE_TYPES
	{
		/// <summary>Allow update only if the item is a placeholder (whether hydrated or not).</summary>
		PRJ_UPDATE_NONE = 0x00000000,

		/// <summary>Allow update if the item is a placeholder or a dirty placeholder.</summary>
		PRJ_UPDATE_ALLOW_DIRTY_METADATA = 0x00000001,

		/// <summary>Allow update if the item is a placeholder or if it is a full file.</summary>
		PRJ_UPDATE_ALLOW_DIRTY_DATA = 0x00000002,

		/// <summary>Allow update if the item is a placeholder or if it is a tombstone.</summary>
		PRJ_UPDATE_ALLOW_TOMBSTONE = 0x00000004,

		/// <summary>Reserved for future use.</summary>
		PRJ_UPDATE_RESERVED1 = 0x00000008,

		/// <summary>Reserved for future use.</summary>
		PRJ_UPDATE_RESERVED2 = 0x00000010,

		/// <summary>Allow update regardless of whether the DOS read-only bit is set on the item.</summary>
		PRJ_UPDATE_ALLOW_READ_ONLY = 0x00000020,

		/// <summary>Maximum value.</summary>
		PRJ_UPDATE_MAX_VAL = (PRJ_UPDATE_ALLOW_READ_ONLY << 1),
	}

	/// <summary>Allocates a buffer that meets the memory alignment requirements of the virtualization instance's storage device.</summary>
	/// <param name="namespaceVirtualizationContext">Opaque handle for the virtualization instance.</param>
	/// <param name="size">The size of the buffer required, in bytes.</param>
	/// <returns>Returns NULL if the buffer could not be allocated.</returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/projectedfslib/nf-projectedfslib-prjallocatealignedbuffer void *
	// PrjAllocateAlignedBuffer( PRJ_NAMESPACE_VIRTUALIZATION_CONTEXT namespaceVirtualizationContext, size_t size );
	[DllImport(Lib.ProjectedFSLib, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("projectedfslib.h", MSDNShortId = "49B723CC-976D-44C6-91D9-0FB26CFD45CA")]
	public static extern IntPtr PrjAllocateAlignedBuffer(PRJ_NAMESPACE_VIRTUALIZATION_CONTEXT namespaceVirtualizationContext, SizeT size);

	/// <summary>Purges the virtualization instance's negative path cache, if it is active.</summary>
	/// <param name="namespaceVirtualizationContext">Opaque handle for the virtualization instance.</param>
	/// <param name="totalEntryNumber">
	/// Optional pointer to a variable that receives the number of paths that were in the cache before it was purged.
	/// </param>
	/// <returns>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
	/// <remarks>
	/// <para>
	/// If the negative path cache is active, then if the provider indicates that a file path does not exist by returning
	/// HRESULT_FROM_WIN32(ERROR_FILE_NOT_FOUND) from its PRJ_GET_PLACEHOLDER_INFO_CB callback, ProjFS will fail subsequent opens of
	/// that path without calling the PRJ_GET_PLACEHOLDER_INFO_CB callback again. This helps improve performance of virtualization
	/// instances that host workloads that frequently probe for the presence of a file by trying to open it.
	/// </para>
	/// <para>
	/// To resume receiving the PRJ_GET_PLACEHOLDER_INFO_CB callback for paths the provider has indicated do not exist, the provider
	/// must call this routine.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/projectedfslib/nf-projectedfslib-prjclearnegativepathcache HRESULT
	// PrjClearNegativePathCache( PRJ_NAMESPACE_VIRTUALIZATION_CONTEXT namespaceVirtualizationContext, UINT32 *totalEntryNumber );
	[DllImport(Lib.ProjectedFSLib, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("projectedfslib.h", MSDNShortId = "90E37386-C647-476C-A53D-C479411DF8F9")]
	public static extern HRESULT PrjClearNegativePathCache(PRJ_NAMESPACE_VIRTUALIZATION_CONTEXT namespaceVirtualizationContext, out uint totalEntryNumber);

	/// <summary>Indicates that the provider has completed processing a callback from which it had previously returned HRESULT_FROM_WIN32(ERROR_IO_PENDING).</summary>
	/// <param name="namespaceVirtualizationContext">
	/// Opaque handle for the virtualization instance. This must be the value from the VirtualizationInstanceHandle member of the
	/// callbackData passed to the provider in the callback that is being complete.
	/// </param>
	/// <param name="commandId">
	/// A value identifying the callback invocation that the provider is completing. This must be the value from the CommandId member of
	/// the callbackData passed to the provider in the callback that is being completed.
	/// </param>
	/// <param name="completionResult">The final HRESULT of the operation.</param>
	/// <param name="extendedParameters">Optional pointer to extended parameters required for completing certain callbacks.</param>
	/// <returns>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/projectedfslib/nf-projectedfslib-prjcompletecommand HRESULT
	// PrjCompleteCommand( PRJ_NAMESPACE_VIRTUALIZATION_CONTEXT namespaceVirtualizationContext, INT32 commandId, HRESULT
	// completionResult, PRJ_COMPLETE_COMMAND_EXTENDED_PARAMETERS *extendedParameters );
	[DllImport(Lib.ProjectedFSLib, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("projectedfslib.h", MSDNShortId = "9A47FAB5-A085-41C9-861C-E74F2F5AF474")]
	public static extern HRESULT PrjCompleteCommand(PRJ_NAMESPACE_VIRTUALIZATION_CONTEXT namespaceVirtualizationContext, int commandId,
		HRESULT completionResult, in PRJ_COMPLETE_COMMAND_EXTENDED_PARAMETERS extendedParameters);

	/// <summary>Indicates that the provider has completed processing a callback from which it had previously returned HRESULT_FROM_WIN32(ERROR_IO_PENDING).</summary>
	/// <param name="namespaceVirtualizationContext">
	/// Opaque handle for the virtualization instance. This must be the value from the VirtualizationInstanceHandle member of the
	/// callbackData passed to the provider in the callback that is being complete.
	/// </param>
	/// <param name="commandId">
	/// A value identifying the callback invocation that the provider is completing. This must be the value from the CommandId member of
	/// the callbackData passed to the provider in the callback that is being completed.
	/// </param>
	/// <param name="completionResult">The final HRESULT of the operation.</param>
	/// <param name="extendedParameters">Optional pointer to extended parameters required for completing certain callbacks.</param>
	/// <returns>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/projectedfslib/nf-projectedfslib-prjcompletecommand HRESULT
	// PrjCompleteCommand( PRJ_NAMESPACE_VIRTUALIZATION_CONTEXT namespaceVirtualizationContext, INT32 commandId, HRESULT
	// completionResult, PRJ_COMPLETE_COMMAND_EXTENDED_PARAMETERS *extendedParameters );
	[DllImport(Lib.ProjectedFSLib, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("projectedfslib.h", MSDNShortId = "9A47FAB5-A085-41C9-861C-E74F2F5AF474")]
	public static extern HRESULT PrjCompleteCommand(PRJ_NAMESPACE_VIRTUALIZATION_CONTEXT namespaceVirtualizationContext, int commandId,
		HRESULT completionResult, [Optional] IntPtr extendedParameters);

	/// <summary>Enables a provider to delete an item that has been cached on the local file system.</summary>
	/// <param name="namespaceVirtualizationContext">An opaque handle for the virtualization instance.</param>
	/// <param name="destinationFileName">
	/// A null-terminated Unicode string specifying the path, relative to the virtualization root, to the file or directory to be deleted.
	/// </param>
	/// <param name="updateFlags">Flags to control the delete operation should be allowed given the state of the file.</param>
	/// <param name="failureReason">Optional pointer to receive a code describing the reason a delete failed.</param>
	/// <returns>
	/// If an HRESULT_FROM_WIN32(ERROR_FILE_SYSTEM_VIRTUALIZATION_INVALID_OPERATION) error is returned, the update failed due to the
	/// item's state and the value of updateFlags. failureReason, if specified, will describe the reason for the failure.
	/// </returns>
	/// <remarks>
	/// <para>If the item is still in the provider's backing store, deleting it from the local file system changes it to a virtual item.</para>
	/// <para>This routine cannot be called on a virtual file/directory.</para>
	/// <para>
	/// If the file/directory to be deleted is in any state other than "placeholder", the provider must specify an appropriate
	/// combination of PRJ_UPDATE_TYPES values in the updateFlags parameter. This helps guard against accidental loss of data.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/projectedfslib/nf-projectedfslib-prjdeletefile HRESULT PrjDeleteFile(
	// PRJ_NAMESPACE_VIRTUALIZATION_CONTEXT namespaceVirtualizationContext, PCWSTR destinationFileName, PRJ_UPDATE_TYPES updateFlags,
	// PRJ_UPDATE_FAILURE_CAUSES *failureReason );
	[DllImport(Lib.ProjectedFSLib, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("projectedfslib.h", MSDNShortId = "4F3529FC-5658-4768-AC72-29178C9595F0")]
	public static extern HRESULT PrjDeleteFile(PRJ_NAMESPACE_VIRTUALIZATION_CONTEXT namespaceVirtualizationContext, [MarshalAs(UnmanagedType.LPWStr)] string destinationFileName,
		PRJ_UPDATE_TYPES updateFlags, out PRJ_UPDATE_FAILURE_CAUSES failureReason);

	/// <summary>Determines whether a name contains wildcard characters.</summary>
	/// <param name="fileName">A null-terminated Unicode string to check for wildcard characters.</param>
	/// <returns>True if fileName contains wildcards, False otherwise.</returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/projectedfslib/nf-projectedfslib-prjdoesnamecontainwildcards BOOLEAN
	// PrjDoesNameContainWildCards( LPCWSTR fileName );
	[DllImport(Lib.ProjectedFSLib, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("projectedfslib.h", MSDNShortId = "AE1896D4-0DFB-477F-ADD8-C6C14DAD27CD")]
	[return: MarshalAs(UnmanagedType.U1)]
	public static extern bool PrjDoesNameContainWildCards([MarshalAs(UnmanagedType.LPWStr)] string fileName);

	/// <summary>Compares two file names and returns a value that indicates their relative collation order.</summary>
	/// <param name="fileName1">A null-terminated Unicode string specifying the first name to compare.</param>
	/// <param name="fileName2">A null-terminated Unicode string specifying the second name to compare.</param>
	/// <returns>
	/// <list type="bullet">
	/// <item>
	/// <term>&lt;0 indicates fileName1 is before fileName2 in collation order</term>
	/// </item>
	/// <item>
	/// <term>0 indicates fileName1 is equal to fileName2</term>
	/// </item>
	/// <item>
	/// <term>&gt;0 indicates fileName1 is after fileName2 in collation order</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>The provider may use this routine to determine how to sort file names in the same order that the file system does.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/projectedfslib/nf-projectedfslib-prjfilenamecompare int PrjFileNameCompare(
	// PCWSTR fileName1, PCWSTR fileName2 );
	[DllImport(Lib.ProjectedFSLib, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("projectedfslib.h", MSDNShortId = "A20C2E31-918D-4AE8-9C54-D88BB5DC21E7")]
	public static extern int PrjFileNameCompare([MarshalAs(UnmanagedType.LPWStr)] string fileName1, [MarshalAs(UnmanagedType.LPWStr)] string fileName2);

	/// <summary>Determines whether a file name matches a search pattern.</summary>
	/// <param name="fileNameToCheck">
	/// A null-terminated Unicode string of at most MAX_PATH characters specifying the file name to check against pattern.
	/// </param>
	/// <param name="pattern">
	/// A null-terminated Unicode string of at most MAX_PATH characters specifying the pattern to compare against fileNameToCheck.
	/// </param>
	/// <returns>True if fileNameToCheck matches pattern, False otherwise.</returns>
	/// <remarks>
	/// The provider must use this routine when processing a PRJ_GET_DIRECTORY_ENUMERATION_CB callback to determine whether a name in
	/// its backing store matches the searchExpression passed to the callback. This routine performs pattern matching in the same way
	/// the file system does when it is processing a directory enumeration
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/projectedfslib/nf-projectedfslib-prjfilenamematch BOOLEAN PrjFileNameMatch(
	// PCWSTR fileNameToCheck, PCWSTR pattern );
	[DllImport(Lib.ProjectedFSLib, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("projectedfslib.h", MSDNShortId = "2BE57189-0F68-4CCD-8796-964EFDE0A02E")]
	[return: MarshalAs(UnmanagedType.U1)]
	public static extern bool PrjFileNameMatch([MarshalAs(UnmanagedType.LPWStr)] string fileNameToCheck, [MarshalAs(UnmanagedType.LPWStr)] string pattern);

	/// <summary>Provides information for one file or directory to an enumeration.</summary>
	/// <param name="fileName">A pointer to a null-terminated string that contains the name of the entry</param>
	/// <param name="fileBasicInfo">Basic information about the entry to be filled.</param>
	/// <param name="dirEntryBufferHandle">An opaque handle to a structure that receives information about the filled entries.</param>
	/// <returns>
	/// HRESULT_FROM_WIN32(ERROR_INSUFFICIENT_BUFFER) indicates that dirEntryBufferHandle doesn't have enough space for the new entry.
	/// </returns>
	/// <remarks>
	/// <para>
	/// The provider uses this routine to service a PRJ_GET_DIRECTORY_ENUMERATION_CB callback. When processing the callback, the
	/// provider calls this routine for each matching file or directory in the enumeration.
	/// </para>
	/// <para>
	/// If this routine returns HRESULT_FROM_WIN32(ERROR_INSUFFICIENT_BUFFER) when adding an entry to the enumeration, the provider
	/// returns S_OK from the callback and waits for the next PRJ_GET_DIRECTORY_ENUMERATION_CB callback.
	/// </para>
	/// <para>The provider resumes filling the enumeration with the entry it was trying to add when it got HRESULT_FROM_WIN32(ERROR_INSUFFICIENT_BUFFER).</para>
	/// <para>
	/// If this routine returns HRESULT_FROM_WIN32(ERROR_INSUFFICIENT_BUFFER) for the first file or directory in the enumeration, the
	/// provider must return HRESULT_FROM_WIN32(ERROR_INSUFFICIENT_BUFFER) from its PRJ_GET_DIRECTORY_ENUMERATION_CB callback.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/projectedfslib/nf-projectedfslib-prjfilldirentrybuffer HRESULT
	// PrjFillDirEntryBuffer( PCWSTR fileName, PRJ_FILE_BASIC_INFO *fileBasicInfo, PRJ_DIR_ENTRY_BUFFER_HANDLE dirEntryBufferHandle );
	[DllImport(Lib.ProjectedFSLib, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("projectedfslib.h", MSDNShortId = "CBCB0A0E-9227-42EF-B747-62783400AD16")]
	public static extern HRESULT PrjFillDirEntryBuffer([MarshalAs(UnmanagedType.LPWStr)] string fileName, in PRJ_FILE_BASIC_INFO fileBasicInfo,
		PRJ_DIR_ENTRY_BUFFER_HANDLE dirEntryBufferHandle);

	/// <summary>Provides information for one file or directory to an enumeration.</summary>
	/// <param name="fileName">A pointer to a null-terminated string that contains the name of the entry</param>
	/// <param name="fileBasicInfo">Basic information about the entry to be filled.</param>
	/// <param name="dirEntryBufferHandle">An opaque handle to a structure that receives information about the filled entries.</param>
	/// <returns>
	/// HRESULT_FROM_WIN32(ERROR_INSUFFICIENT_BUFFER) indicates that dirEntryBufferHandle doesn't have enough space for the new entry.
	/// </returns>
	/// <remarks>
	/// <para>
	/// The provider uses this routine to service a PRJ_GET_DIRECTORY_ENUMERATION_CB callback. When processing the callback, the
	/// provider calls this routine for each matching file or directory in the enumeration.
	/// </para>
	/// <para>
	/// If this routine returns HRESULT_FROM_WIN32(ERROR_INSUFFICIENT_BUFFER) when adding an entry to the enumeration, the provider
	/// returns S_OK from the callback and waits for the next PRJ_GET_DIRECTORY_ENUMERATION_CB callback.
	/// </para>
	/// <para>The provider resumes filling the enumeration with the entry it was trying to add when it got HRESULT_FROM_WIN32(ERROR_INSUFFICIENT_BUFFER).</para>
	/// <para>
	/// If this routine returns HRESULT_FROM_WIN32(ERROR_INSUFFICIENT_BUFFER) for the first file or directory in the enumeration, the
	/// provider must return HRESULT_FROM_WIN32(ERROR_INSUFFICIENT_BUFFER) from its PRJ_GET_DIRECTORY_ENUMERATION_CB callback.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/projectedfslib/nf-projectedfslib-prjfilldirentrybuffer HRESULT
	// PrjFillDirEntryBuffer( PCWSTR fileName, PRJ_FILE_BASIC_INFO *fileBasicInfo, PRJ_DIR_ENTRY_BUFFER_HANDLE dirEntryBufferHandle );
	[DllImport(Lib.ProjectedFSLib, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("projectedfslib.h", MSDNShortId = "CBCB0A0E-9227-42EF-B747-62783400AD16")]
	public static extern HRESULT PrjFillDirEntryBuffer([MarshalAs(UnmanagedType.LPWStr)] string fileName, [Optional] IntPtr fileBasicInfo,
		PRJ_DIR_ENTRY_BUFFER_HANDLE dirEntryBufferHandle);

	/// <summary>Provides information for one file or directory to an enumeration and allows the caller to specify extended information.</summary>
	/// <param name="dirEntryBufferHandle">An opaque handle to a structure that receives information about the filled entries.</param>
	/// <param name="fileName">A pointer to a null-terminated string that contains the name of the entry</param>
	/// <param name="fileBasicInfo">Basic information about the entry to be filled.</param>
	/// <param name="extendedInfo">A pointer to a PRJ_EXTENDED_INFO struct specifying extended information about the entry to be filled.</param>
	/// <returns>
	/// <para>
	/// HRESULT_FROM_WIN32(ERROR_INSUFFICIENT_BUFFER) indicates that dirEntryBufferHandle doesn't have enough space for the new entry.
	/// </para>
	/// <para>E_INVALIDARG indicates that extendedInfo.InfoType is unrecognized.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The provider uses this routine to service a PRJ_GET_DIRECTORY_ENUMERATION_CB callback. When processing the callback, the
	/// provider calls this routine for each matching file or directory in the enumeration. This routine allows the provider to specify
	/// extended information about the file or directory, such as whether it is a symbolic link.
	/// </para>
	/// <para>
	/// If this routine returns HRESULT_FROM_WIN32(ERROR_INSUFFICIENT_BUFFER) when adding an entry to the enumeration, the provider
	/// returns S_OK from the callback and waits for the next PRJ_GET_DIRECTORY_ENUMERATION_CB callback.
	/// </para>
	/// <para>The provider resumes filling the enumeration with the entry it was trying to add when it got HRESULT_FROM_WIN32(ERROR_INSUFFICIENT_BUFFER).</para>
	/// <para>
	/// If this routine returns HRESULT_FROM_WIN32(ERROR_INSUFFICIENT_BUFFER) for the first file or directory in the enumeration, the
	/// provider must return HRESULT_FROM_WIN32(ERROR_INSUFFICIENT_BUFFER) from its PRJ_GET_DIRECTORY_ENUMERATION_CB callback.
	/// </para>
	/// <para>Symbolic Links</para>
	/// <para>
	/// To specify that this directory entry is for a symbolic link, the provider formats a buffer with a single PRJ_EXTENDED_INFO
	/// struct and passes a pointer to it in the parameter. The provider sets the struct's fields as follows:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <code>extendedInfo.InfoType = PRJ_EXT_INFO_TYPE_SYMLINK</code>
	/// </item>
	/// <item>
	/// <code>extendedInfo.NextInfoOffset = 0</code>
	/// </item>
	/// <item>
	/// <code>extendedInfo.Symlink.TargetName = &lt;path to the target of the symbolic link&gt;</code>
	/// </item>
	/// </list>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/projectedfslib/nf-projectedfslib-prjfilldirentrybuffer2 HRESULT
	// PrjFillDirEntryBuffer2( PRJ_DIR_ENTRY_BUFFER_HANDLE dirEntryBufferHandle, PCWSTR fileName, PRJ_FILE_BASIC_INFO *fileBasicInfo,
	// PRJ_EXTENDED_INFO *extendedInfo );
	[DllImport(Lib.ProjectedFSLib, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("projectedfslib.h", MSDNShortId = "NF:projectedfslib.PrjFillDirEntryBuffer2")]
	public static extern HRESULT PrjFillDirEntryBuffer2(PRJ_DIR_ENTRY_BUFFER_HANDLE dirEntryBufferHandle, [MarshalAs(UnmanagedType.LPWStr)] string fileName,
		in PRJ_FILE_BASIC_INFO fileBasicInfo, in PRJ_EXTENDED_INFO extendedInfo);

	/// <summary>Provides information for one file or directory to an enumeration and allows the caller to specify extended information.</summary>
	/// <param name="dirEntryBufferHandle">An opaque handle to a structure that receives information about the filled entries.</param>
	/// <param name="fileName">A pointer to a null-terminated string that contains the name of the entry</param>
	/// <param name="fileBasicInfo">Basic information about the entry to be filled.</param>
	/// <param name="extendedInfo">A pointer to a PRJ_EXTENDED_INFO struct specifying extended information about the entry to be filled.</param>
	/// <returns>
	/// <para>
	/// HRESULT_FROM_WIN32(ERROR_INSUFFICIENT_BUFFER) indicates that dirEntryBufferHandle doesn't have enough space for the new entry.
	/// </para>
	/// <para>E_INVALIDARG indicates that extendedInfo.InfoType is unrecognized.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The provider uses this routine to service a PRJ_GET_DIRECTORY_ENUMERATION_CB callback. When processing the callback, the
	/// provider calls this routine for each matching file or directory in the enumeration. This routine allows the provider to specify
	/// extended information about the file or directory, such as whether it is a symbolic link.
	/// </para>
	/// <para>
	/// If this routine returns HRESULT_FROM_WIN32(ERROR_INSUFFICIENT_BUFFER) when adding an entry to the enumeration, the provider
	/// returns S_OK from the callback and waits for the next PRJ_GET_DIRECTORY_ENUMERATION_CB callback.
	/// </para>
	/// <para>The provider resumes filling the enumeration with the entry it was trying to add when it got HRESULT_FROM_WIN32(ERROR_INSUFFICIENT_BUFFER).</para>
	/// <para>
	/// If this routine returns HRESULT_FROM_WIN32(ERROR_INSUFFICIENT_BUFFER) for the first file or directory in the enumeration, the
	/// provider must return HRESULT_FROM_WIN32(ERROR_INSUFFICIENT_BUFFER) from its PRJ_GET_DIRECTORY_ENUMERATION_CB callback.
	/// </para>
	/// <para>Symbolic Links</para>
	/// <para>
	/// To specify that this directory entry is for a symbolic link, the provider formats a buffer with a single PRJ_EXTENDED_INFO
	/// struct and passes a pointer to it in the parameter. The provider sets the struct's fields as follows:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <code>extendedInfo.InfoType = PRJ_EXT_INFO_TYPE_SYMLINK</code>
	/// </item>
	/// <item>
	/// <code>extendedInfo.NextInfoOffset = 0</code>
	/// </item>
	/// <item>
	/// <code>extendedInfo.Symlink.TargetName = &lt;path to the target of the symbolic link&gt;</code>
	/// </item>
	/// </list>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/projectedfslib/nf-projectedfslib-prjfilldirentrybuffer2 HRESULT
	// PrjFillDirEntryBuffer2( PRJ_DIR_ENTRY_BUFFER_HANDLE dirEntryBufferHandle, PCWSTR fileName, PRJ_FILE_BASIC_INFO *fileBasicInfo,
	// PRJ_EXTENDED_INFO *extendedInfo );
	[DllImport(Lib.ProjectedFSLib, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("projectedfslib.h", MSDNShortId = "NF:projectedfslib.PrjFillDirEntryBuffer2")]
	public static extern HRESULT PrjFillDirEntryBuffer2(PRJ_DIR_ENTRY_BUFFER_HANDLE dirEntryBufferHandle, [MarshalAs(UnmanagedType.LPWStr)] string fileName,
		[In, Optional] IntPtr fileBasicInfo, [In, Optional] IntPtr extendedInfo);

	/// <summary>Frees an allocated buffer.</summary>
	/// <param name="buffer">The buffer to free.</param>
	/// <returns>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/projectedfslib/nf-projectedfslib-prjfreealignedbuffer void
	// PrjFreeAlignedBuffer( void *buffer );
	[DllImport(Lib.ProjectedFSLib, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("projectedfslib.h", MSDNShortId = "EE5AC099-CB39-48B1-BB7B-8C9B436AA4A3")]
	public static extern void PrjFreeAlignedBuffer(IntPtr buffer);

	/// <summary>Gets the on-disk file state for a file or directory.</summary>
	/// <param name="destinationFileName">
	/// A null-terminated Unicode string specifying the full path to the file whose state is to be queried.
	/// </param>
	/// <param name="fileState">This is a combination of one or more PRJ_FILE_STATE values describing the file state.</param>
	/// <returns>
	/// HRESULT_FROM_WIN32(ERROR_FILE_NOT_FOUND) indicates destinationFileName does not exist. HRESULT_FROM_WIN32(ERROR_PATH_NOT_FOUND)
	/// indicates that an intermediate component of the path to destinationFileName does not exist.
	/// </returns>
	/// <remarks>
	/// <para>
	/// This routine tells the caller what the ProjFS caching state is of the specified file or directory. For example, the caller can
	/// use this routine to determine whether the given item is a placeholder or full file.
	/// </para>
	/// <para>
	/// A running provider should be cautious if using this routine on files or directories within one of its virtualization instances,
	/// as it may cause callbacks to be invoked in the provider. Depending on the design of the provider this may lead to deadlocks.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/projectedfslib/nf-projectedfslib-prjgetondiskfilestate HRESULT
	// PrjGetOnDiskFileState( PCWSTR destinationFileName, PRJ_FILE_STATE *fileState );
	[DllImport(Lib.ProjectedFSLib, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("projectedfslib.h", MSDNShortId = "E302C472-1360-43D9-8AB9-26C93F97F00F")]
	public static extern HRESULT PrjGetOnDiskFileState([MarshalAs(UnmanagedType.LPWStr)] string destinationFileName, out PRJ_FILE_STATE fileState);

	/// <summary>Retrieves information about the virtualization instance.</summary>
	/// <param name="namespaceVirtualizationContext">An opaque handle for the virtualization instance.</param>
	/// <param name="virtualizationInstanceInfo">
	/// On input points to a buffer to fill with information about the virtualization instance. On successful return the buffer is
	/// filled in.
	/// </param>
	/// <returns>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
	/// <remarks>
	/// <para>
	/// ProjFS callback routines provide the virtualization instance handle in their callbackData parameters. A provider that manages
	/// multiple virtualization instances can use the InstanceID field of virtualizationInstanceInfo to identify which of its
	/// virtualization instances is receiving the callback.
	/// </para>
	/// <para>
	/// The provider can use the WriteAlignment member of virtualizationInstanceInfo to determine the correct values to use for the
	/// byteOffset and length parameters of PrjWriteFileData.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/projectedfslib/nf-projectedfslib-prjgetvirtualizationinstanceinfo HRESULT
	// PrjGetVirtualizationInstanceInfo( PRJ_NAMESPACE_VIRTUALIZATION_CONTEXT namespaceVirtualizationContext,
	// PRJ_VIRTUALIZATION_INSTANCE_INFO *virtualizationInstanceInfo );
	[DllImport(Lib.ProjectedFSLib, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("projectedfslib.h", MSDNShortId = "0C04D13F-862C-4E4C-9BC1-13E6FAC86E99")]
	public static extern HRESULT PrjGetVirtualizationInstanceInfo(PRJ_NAMESPACE_VIRTUALIZATION_CONTEXT namespaceVirtualizationContext,
		out PRJ_VIRTUALIZATION_INSTANCE_INFO virtualizationInstanceInfo);

	/// <summary>Converts an existing directory to a directory placeholder.</summary>
	/// <param name="rootPathName">A null-terminated Unicode string specifying the full path to the virtualization root.</param>
	/// <param name="targetPathName">
	/// <para>
	/// A null-terminated Unicode string specifying the path, relative to the virtualization root, to the directory to convert to a placeholder.
	/// </para>
	/// <para>
	/// If this parameter is not specified or is an empty string, then this means the caller wants to designate rootPathName as the
	/// virtualization root. The provider only needs to do this one time, upon establishing a new virtualization instance.
	/// </para>
	/// </param>
	/// <param name="versionInfo">
	/// Optional version information for the target placeholder. The provider chooses what information to put in the
	/// PRJ_PLACEHOLDER_VERSION_INFO structure. If not specified, the placeholder gets zeros for its version information.
	/// </param>
	/// <param name="virtualizationInstanceID">A value that identifies the virtualization instance.</param>
	/// <returns>
	/// HRESULT_FROM_WIN32(ERROR_REPARSE_POINT_ENCOUNTERED) typically means the directory at targetPathName has a reparse point on it.
	/// HRESULT_FROM_WIN32(ERROR_DIRECTORY) typically means the targetPathName does not specify a directory.
	/// </returns>
	/// <remarks>The provider must use this API to designate the virtualization root before calling PrjStartVirtualizing.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/projectedfslib/nf-projectedfslib-prjmarkdirectoryasplaceholder HRESULT
	// PrjMarkDirectoryAsPlaceholder( PCWSTR rootPathName, PCWSTR targetPathName, const PRJ_PLACEHOLDER_VERSION_INFO *versionInfo, const
	// GUID *virtualizationInstanceID );
	[DllImport(Lib.ProjectedFSLib, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("projectedfslib.h", MSDNShortId = "6C92275E-B9A6-4556-A709-8EFBAEDB94B5")]
	public static extern HRESULT PrjMarkDirectoryAsPlaceholder([MarshalAs(UnmanagedType.LPWStr)] string rootPathName,
		[Optional, MarshalAs(UnmanagedType.LPWStr)] string? targetPathName, in PRJ_PLACEHOLDER_VERSION_INFO versionInfo, in Guid virtualizationInstanceID);

	/// <summary>Converts an existing directory to a directory placeholder.</summary>
	/// <param name="rootPathName">A null-terminated Unicode string specifying the full path to the virtualization root.</param>
	/// <param name="targetPathName">
	/// <para>
	/// A null-terminated Unicode string specifying the path, relative to the virtualization root, to the directory to convert to a placeholder.
	/// </para>
	/// <para>
	/// If this parameter is not specified or is an empty string, then this means the caller wants to designate rootPathName as the
	/// virtualization root. The provider only needs to do this one time, upon establishing a new virtualization instance.
	/// </para>
	/// </param>
	/// <param name="versionInfo">
	/// Optional version information for the target placeholder. The provider chooses what information to put in the
	/// PRJ_PLACEHOLDER_VERSION_INFO structure. If not specified, the placeholder gets zeros for its version information.
	/// </param>
	/// <param name="virtualizationInstanceID">A value that identifies the virtualization instance.</param>
	/// <returns>
	/// HRESULT_FROM_WIN32(ERROR_REPARSE_POINT_ENCOUNTERED) typically means the directory at targetPathName has a reparse point on it.
	/// HRESULT_FROM_WIN32(ERROR_DIRECTORY) typically means the targetPathName does not specify a directory.
	/// </returns>
	/// <remarks>The provider must use this API to designate the virtualization root before calling PrjStartVirtualizing.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/projectedfslib/nf-projectedfslib-prjmarkdirectoryasplaceholder HRESULT
	// PrjMarkDirectoryAsPlaceholder( PCWSTR rootPathName, PCWSTR targetPathName, const PRJ_PLACEHOLDER_VERSION_INFO *versionInfo, const
	// GUID *virtualizationInstanceID );
	[DllImport(Lib.ProjectedFSLib, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("projectedfslib.h", MSDNShortId = "6C92275E-B9A6-4556-A709-8EFBAEDB94B5")]
	public static extern HRESULT PrjMarkDirectoryAsPlaceholder([MarshalAs(UnmanagedType.LPWStr)] string rootPathName,
		[Optional, MarshalAs(UnmanagedType.LPWStr)] string? targetPathName, [Optional] IntPtr versionInfo, in Guid virtualizationInstanceID);

	/// <summary>
	/// Configures a ProjFS virtualization instance and starts it, making it available to service I/O and invoke callbacks on the provider.
	/// </summary>
	/// <param name="virtualizationRootPath">
	/// <para>Pointer to a null-terminated unicode string specifying the full path to the virtualization root directory.</para>
	/// <para>
	/// The provider must have called PrjMarkDirectoryAsPlaceholder passing the specified path as the rootPathName parameter and NULL as
	/// the targetPathName parameter before calling this routine. This only needs to be done once to designate the path as the
	/// virtualization root directory
	/// </para>
	/// </param>
	/// <param name="callbacks">
	/// Pointer to a PRJ_CALLBACKS structure that has been initialized with PrjCommandCallbacksInit and filled in with pointers to the
	/// provider's callback functions.
	/// </param>
	/// <param name="instanceContext">
	/// Pointer to context information defined by the provider for each instance. This parameter is optional and can be NULL. If it is
	/// specified, ProjFS will return it in the InstanceContext member of PRJ_CALLBACK_DATA when invoking provider callback routines.
	/// </param>
	/// <param name="options">An optional pointer to a PRJ_STARTVIRTUALIZING_OPTIONS.</param>
	/// <param name="namespaceVirtualizationContext">
	/// On success returns an opaque handle to the ProjFS virtualization instance. The provider passes this value when calling functions
	/// that require a PRJ_NAMESPACE_VIRTUALIZATION_CONTEXT as input.
	/// </param>
	/// <returns>
	/// The error, HRESULT_FROM_WIN32(ERROR_REPARSE_TAG_MISMATCH), indicates that virtualizationRootPath has not been configured as a
	/// virtualization root.
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/projectedfslib/nf-projectedfslib-prjstartvirtualizing HRESULT
	// PrjStartVirtualizing( PCWSTR virtualizationRootPath, const PRJ_CALLBACKS *callbacks, const void *instanceContext, const
	// PRJ_STARTVIRTUALIZING_OPTIONS *options, PRJ_NAMESPACE_VIRTUALIZATION_CONTEXT *namespaceVirtualizationContext );
	[DllImport(Lib.ProjectedFSLib, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("projectedfslib.h", MSDNShortId = "466347B7-1D7D-4C7D-B17C-1E5E1A2223C1")]
	public static extern HRESULT PrjStartVirtualizing([MarshalAs(UnmanagedType.LPWStr)] string virtualizationRootPath, in PRJ_CALLBACKS callbacks,
		[In, Optional] IntPtr instanceContext, in PRJ_STARTVIRTUALIZING_OPTIONS options, out PRJ_NAMESPACE_VIRTUALIZATION_CONTEXT namespaceVirtualizationContext);

	/// <summary>
	/// Configures a ProjFS virtualization instance and starts it, making it available to service I/O and invoke callbacks on the provider.
	/// </summary>
	/// <param name="virtualizationRootPath">
	/// <para>Pointer to a null-terminated unicode string specifying the full path to the virtualization root directory.</para>
	/// <para>
	/// The provider must have called PrjMarkDirectoryAsPlaceholder passing the specified path as the rootPathName parameter and NULL as
	/// the targetPathName parameter before calling this routine. This only needs to be done once to designate the path as the
	/// virtualization root directory
	/// </para>
	/// </param>
	/// <param name="callbacks">
	/// Pointer to a PRJ_CALLBACKS structure that has been initialized with PrjCommandCallbacksInit and filled in with pointers to the
	/// provider's callback functions.
	/// </param>
	/// <param name="instanceContext">
	/// Pointer to context information defined by the provider for each instance. This parameter is optional and can be NULL. If it is
	/// specified, ProjFS will return it in the InstanceContext member of PRJ_CALLBACK_DATA when invoking provider callback routines.
	/// </param>
	/// <param name="options">An optional pointer to a PRJ_STARTVIRTUALIZING_OPTIONS.</param>
	/// <param name="namespaceVirtualizationContext">
	/// On success returns an opaque handle to the ProjFS virtualization instance. The provider passes this value when calling functions
	/// that require a PRJ_NAMESPACE_VIRTUALIZATION_CONTEXT as input.
	/// </param>
	/// <returns>
	/// The error, HRESULT_FROM_WIN32(ERROR_REPARSE_TAG_MISMATCH), indicates that virtualizationRootPath has not been configured as a
	/// virtualization root.
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/projectedfslib/nf-projectedfslib-prjstartvirtualizing HRESULT
	// PrjStartVirtualizing( PCWSTR virtualizationRootPath, const PRJ_CALLBACKS *callbacks, const void *instanceContext, const
	// PRJ_STARTVIRTUALIZING_OPTIONS *options, PRJ_NAMESPACE_VIRTUALIZATION_CONTEXT *namespaceVirtualizationContext );
	[DllImport(Lib.ProjectedFSLib, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("projectedfslib.h", MSDNShortId = "466347B7-1D7D-4C7D-B17C-1E5E1A2223C1")]
	public static extern HRESULT PrjStartVirtualizing([MarshalAs(UnmanagedType.LPWStr)] string virtualizationRootPath, in PRJ_CALLBACKS callbacks,
		[In, Optional] IntPtr instanceContext, [Optional] IntPtr options, out PRJ_NAMESPACE_VIRTUALIZATION_CONTEXT namespaceVirtualizationContext);

	/// <summary>
	/// Stops a running ProjFS virtualization instance, making it unavailable to service I/O or involve callbacks on the provider.
	/// </summary>
	/// <param name="namespaceVirtualizationContext">An opaque handle for the virtualization instance.</param>
	/// <returns>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/projectedfslib/nf-projectedfslib-prjstopvirtualizing void PrjStopVirtualizing(
	// PRJ_NAMESPACE_VIRTUALIZATION_CONTEXT namespaceVirtualizationContext );
	[DllImport(Lib.ProjectedFSLib, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("projectedfslib.h", MSDNShortId = "D01BF7C5-1EAC-446A-BCE5-A6EF46A5443D")]
	public static extern void PrjStopVirtualizing(PRJ_NAMESPACE_VIRTUALIZATION_CONTEXT namespaceVirtualizationContext);

	/// <summary>Enables a provider to update an item that has been cached on the local file system.</summary>
	/// <param name="namespaceVirtualizationContext">Opague handle for the virtualization instance.</param>
	/// <param name="destinationFileName">
	/// A null-terminated Unicode string specifying the path, relative to the virtualization root, to the file or directory to be updated.
	/// </param>
	/// <param name="placeholderInfo">
	/// <para>A pointer to a PRJ_PLACEHOLDER_INFO buffer containing the updated metadata for the file or directory.</para>
	/// <para>
	/// If placeholderInfo-&gt;VersionInfo.ContentID contains a content identifier that is the same as the content identifier already on
	/// the file/directory, the call succeeds and no update takes place. Otherwise, if the call succeeds then
	/// placeholderInfo-&gt;VersionInfo.ContentID replaces the existing content identifier on the file.
	/// </para>
	/// </param>
	/// <param name="placeholderInfoSize">The size in bytes of the buffer pointed to by placeholderInfo.</param>
	/// <param name="updateFlags">
	/// <para>Flags to control updates.</para>
	/// <para>
	/// If the item is a dirty placeholder, full file, or tombstone, and the provider does not specify the appropriate flag(s), this
	/// routine will fail to update the placeholder
	/// </para>
	/// </param>
	/// <param name="failureReason">Optional pointer to receive a code describing the reason an update failed.</param>
	/// <returns>
	/// If an HRESULT_FROM_WIN32(ERROR_FILE_SYSTEM_VIRTUALIZATION_INVALID_OPERATION) error is returned, the update failed due to the
	/// item's state and the value of updateFlags. failureReason, if specified, will describe the reason for the failure.
	/// </returns>
	/// <remarks>
	/// <para>
	/// The provider uses this routine to update an item in the local file system if the item's information has changed in the
	/// provider’s backing store and the updates should be reflected in the items cached in the local file system.
	/// </para>
	/// <para>
	/// This routine cannot be called on a virtual file/directory. If the file/directory to be updated is in any state other than
	/// "placeholder", the provider must specify an appropriate combination of PRJ_UPDATE_TYPES values in the updateFlags parameter.
	/// This helps guard against accidental loss of data, since upon successful return from this routine the item becomes a placeholder
	/// with the updated metadata; any metadata that had been changed since the placeholder was created, or any file data it contained
	/// is discarded.
	/// </para>
	/// <para>
	/// The provider uses the local file system as a cache of the items that it manages. An item (file or directory) can be in one of
	/// six states on the local file system.
	/// </para>
	/// <para>
	/// Virtual - The item does not exist locally on disk. It is projected, i.e. synthesized, during enumerations of its parent
	/// directory. Virtual items are merged with any items that may exist on disk to present the full contents of the parent directory.
	/// </para>
	/// <para>
	/// Placeholder - For files: The file's content (primary data stream) is not present on the disk. The file’s metadata (name, size,
	/// timestamps, attributes, etc.) is cached on the disk. For directories: Some or all of the directory’s immediate descendants (the
	/// files and directories in the directory) are not present on the disk, i.e. they are still virtual. The directory’s metadata
	/// (name, timestamps, attributes, etc.) is cached on the disk.
	/// </para>
	/// <para>
	/// Hydrated placeholder - For files: The file’s content and metadata have been cached to the disk. Also referred to as a "partial
	/// file". For directories: Directories are never hydrated placeholders. A directory that was created on disk as a placeholder never
	/// becomes a hydrated placeholder directory. This allows the provider to add or remove items from the directory in its backing
	/// store and have those changes be reflected in the local cache.
	/// </para>
	/// <para>
	/// Dirty placeholder (hydrated or not) - The item's metadata has been locally modified and is no longer a cache of its state in the
	/// provider's store. Note that creating or deleting a file or directory under a placeholder directory causes that placeholder
	/// directory to become dirty.
	/// </para>
	/// <para>
	/// Full file/directory - For files: The file's content (primary data stream) has been modified. The file is no longer a cache of
	/// its state in the provider's store. Files that have been created on the local file system (i.e. that do not exist in the
	/// provider's store at all) are also considered to be full files. For directories: Directories that have been created on the local
	/// file system (i.e. that do not exist in the provider's store at all) are considered to be full directories. A directory that was
	/// created on disk as a placeholder never becomes a full directory.
	/// </para>
	/// <para>
	/// Tombstone - A special hidden placeholder that represents an item that has been deleted from the local file system. When a
	/// directory is enumerated ProjFS merges the set of local items (placeholders, full files, etc.) with the set of virtual projected
	/// items. If an item appears in both the local and projected sets, the local item takes precedence. If a file does not exist, there
	/// is no local state, so it would appear in the enumeration. However if that item had been deleted, having it appear in the
	/// enumeration would be unexpected. Replacing a deleted item with a tombstone result in the following effects:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>Enumerations to not reveal the item</term>
	/// </item>
	/// <item>
	/// <term>File opens that expect the item to exist fail with e.g. "file not found".</term>
	/// </item>
	/// <item>
	/// <term>
	/// File creates that expect to succeed only if the item does not exist succeed; ProjFS removes the tombstone as part of the operation.
	/// </term>
	/// </item>
	/// </list>
	/// <para>
	/// To illustrate the above states, consider the following sequence, given a ProjFS provider that has a single file "foo.txt"
	/// located in the virtualization root C:\root.
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>
	/// An app enumerates C:\root. It sees the virtual file "foo.txt". Since the file has not yet been accessed, the file does not exist
	/// on disk.
	/// </term>
	/// </item>
	/// <item>
	/// <term>The app opens a handle to C:\root\foo.txt. ProjFS tells the provider to create a placeholder for it.</term>
	/// </item>
	/// <item>
	/// <term>
	/// The app reads the content of the file. The provider provides the file content to ProjFS and it is cached to C:\root\foo.txt. The
	/// file is now a hydrated placeholder.
	/// </term>
	/// </item>
	/// <item>
	/// <term>The app updates the Last Modified timestamp. The file is now a dirty hydrated placeholder.</term>
	/// </item>
	/// <item>
	/// <term>The app opens a handle for write access to the file. C:\root\foo.txt is now a full file.</term>
	/// </item>
	/// <item>
	/// <term>
	/// The app deletes C:\root\foo.txt. ProjFS replaces the file with a tombstone. Now when the app enumerates C:\root it does not see
	/// foo.txt. If it tries to open the file, the open fails with ERROR_FILE_NOT_FOUND.
	/// </term>
	/// </item>
	/// </list>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/projectedfslib/nf-projectedfslib-prjupdatefileifneeded HRESULT
	// PrjUpdateFileIfNeeded( PRJ_NAMESPACE_VIRTUALIZATION_CONTEXT namespaceVirtualizationContext, PCWSTR destinationFileName, const
	// PRJ_PLACEHOLDER_INFO *placeholderInfo, UINT32 placeholderInfoSize, PRJ_UPDATE_TYPES updateFlags, PRJ_UPDATE_FAILURE_CAUSES
	// *failureReason );
	[DllImport(Lib.ProjectedFSLib, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("projectedfslib.h", MSDNShortId = "182C9C5E-ABBC-4A7C-99E4-D019B7E237CE")]
	public static extern HRESULT PrjUpdateFileIfNeeded(PRJ_NAMESPACE_VIRTUALIZATION_CONTEXT namespaceVirtualizationContext, [MarshalAs(UnmanagedType.LPWStr)] string destinationFileName,
		in PRJ_PLACEHOLDER_INFO placeholderInfo, uint placeholderInfoSize, [Optional] PRJ_UPDATE_TYPES updateFlags, out PRJ_UPDATE_FAILURE_CAUSES failureReason);

	/// <summary>Enables a provider to update an item that has been cached on the local file system.</summary>
	/// <param name="namespaceVirtualizationContext">Opague handle for the virtualization instance.</param>
	/// <param name="destinationFileName">
	/// A null-terminated Unicode string specifying the path, relative to the virtualization root, to the file or directory to be updated.
	/// </param>
	/// <param name="placeholderInfo">
	/// <para>A pointer to a PRJ_PLACEHOLDER_INFO buffer containing the updated metadata for the file or directory.</para>
	/// <para>
	/// If placeholderInfo-&gt;VersionInfo.ContentID contains a content identifier that is the same as the content identifier already on
	/// the file/directory, the call succeeds and no update takes place. Otherwise, if the call succeeds then
	/// placeholderInfo-&gt;VersionInfo.ContentID replaces the existing content identifier on the file.
	/// </para>
	/// </param>
	/// <param name="placeholderInfoSize">The size in bytes of the buffer pointed to by placeholderInfo.</param>
	/// <param name="updateFlags">
	/// <para>Flags to control updates.</para>
	/// <para>
	/// If the item is a dirty placeholder, full file, or tombstone, and the provider does not specify the appropriate flag(s), this
	/// routine will fail to update the placeholder
	/// </para>
	/// </param>
	/// <param name="failureReason">Optional pointer to receive a code describing the reason an update failed.</param>
	/// <returns>
	/// If an HRESULT_FROM_WIN32(ERROR_FILE_SYSTEM_VIRTUALIZATION_INVALID_OPERATION) error is returned, the update failed due to the
	/// item's state and the value of updateFlags. failureReason, if specified, will describe the reason for the failure.
	/// </returns>
	/// <remarks>
	/// <para>
	/// The provider uses this routine to update an item in the local file system if the item's information has changed in the
	/// provider’s backing store and the updates should be reflected in the items cached in the local file system.
	/// </para>
	/// <para>
	/// This routine cannot be called on a virtual file/directory. If the file/directory to be updated is in any state other than
	/// "placeholder", the provider must specify an appropriate combination of PRJ_UPDATE_TYPES values in the updateFlags parameter.
	/// This helps guard against accidental loss of data, since upon successful return from this routine the item becomes a placeholder
	/// with the updated metadata; any metadata that had been changed since the placeholder was created, or any file data it contained
	/// is discarded.
	/// </para>
	/// <para>
	/// The provider uses the local file system as a cache of the items that it manages. An item (file or directory) can be in one of
	/// six states on the local file system.
	/// </para>
	/// <para>
	/// Virtual - The item does not exist locally on disk. It is projected, i.e. synthesized, during enumerations of its parent
	/// directory. Virtual items are merged with any items that may exist on disk to present the full contents of the parent directory.
	/// </para>
	/// <para>
	/// Placeholder - For files: The file's content (primary data stream) is not present on the disk. The file’s metadata (name, size,
	/// timestamps, attributes, etc.) is cached on the disk. For directories: Some or all of the directory’s immediate descendants (the
	/// files and directories in the directory) are not present on the disk, i.e. they are still virtual. The directory’s metadata
	/// (name, timestamps, attributes, etc.) is cached on the disk.
	/// </para>
	/// <para>
	/// Hydrated placeholder - For files: The file’s content and metadata have been cached to the disk. Also referred to as a "partial
	/// file". For directories: Directories are never hydrated placeholders. A directory that was created on disk as a placeholder never
	/// becomes a hydrated placeholder directory. This allows the provider to add or remove items from the directory in its backing
	/// store and have those changes be reflected in the local cache.
	/// </para>
	/// <para>
	/// Dirty placeholder (hydrated or not) - The item's metadata has been locally modified and is no longer a cache of its state in the
	/// provider's store. Note that creating or deleting a file or directory under a placeholder directory causes that placeholder
	/// directory to become dirty.
	/// </para>
	/// <para>
	/// Full file/directory - For files: The file's content (primary data stream) has been modified. The file is no longer a cache of
	/// its state in the provider's store. Files that have been created on the local file system (i.e. that do not exist in the
	/// provider's store at all) are also considered to be full files. For directories: Directories that have been created on the local
	/// file system (i.e. that do not exist in the provider's store at all) are considered to be full directories. A directory that was
	/// created on disk as a placeholder never becomes a full directory.
	/// </para>
	/// <para>
	/// Tombstone - A special hidden placeholder that represents an item that has been deleted from the local file system. When a
	/// directory is enumerated ProjFS merges the set of local items (placeholders, full files, etc.) with the set of virtual projected
	/// items. If an item appears in both the local and projected sets, the local item takes precedence. If a file does not exist, there
	/// is no local state, so it would appear in the enumeration. However if that item had been deleted, having it appear in the
	/// enumeration would be unexpected. Replacing a deleted item with a tombstone result in the following effects:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>Enumerations to not reveal the item</term>
	/// </item>
	/// <item>
	/// <term>File opens that expect the item to exist fail with e.g. "file not found".</term>
	/// </item>
	/// <item>
	/// <term>
	/// File creates that expect to succeed only if the item does not exist succeed; ProjFS removes the tombstone as part of the operation.
	/// </term>
	/// </item>
	/// </list>
	/// <para>
	/// To illustrate the above states, consider the following sequence, given a ProjFS provider that has a single file "foo.txt"
	/// located in the virtualization root C:\root.
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>
	/// An app enumerates C:\root. It sees the virtual file "foo.txt". Since the file has not yet been accessed, the file does not exist
	/// on disk.
	/// </term>
	/// </item>
	/// <item>
	/// <term>The app opens a handle to C:\root\foo.txt. ProjFS tells the provider to create a placeholder for it.</term>
	/// </item>
	/// <item>
	/// <term>
	/// The app reads the content of the file. The provider provides the file content to ProjFS and it is cached to C:\root\foo.txt. The
	/// file is now a hydrated placeholder.
	/// </term>
	/// </item>
	/// <item>
	/// <term>The app updates the Last Modified timestamp. The file is now a dirty hydrated placeholder.</term>
	/// </item>
	/// <item>
	/// <term>The app opens a handle for write access to the file. C:\root\foo.txt is now a full file.</term>
	/// </item>
	/// <item>
	/// <term>
	/// The app deletes C:\root\foo.txt. ProjFS replaces the file with a tombstone. Now when the app enumerates C:\root it does not see
	/// foo.txt. If it tries to open the file, the open fails with ERROR_FILE_NOT_FOUND.
	/// </term>
	/// </item>
	/// </list>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/projectedfslib/nf-projectedfslib-prjupdatefileifneeded HRESULT
	// PrjUpdateFileIfNeeded( PRJ_NAMESPACE_VIRTUALIZATION_CONTEXT namespaceVirtualizationContext, PCWSTR destinationFileName, const
	// PRJ_PLACEHOLDER_INFO *placeholderInfo, UINT32 placeholderInfoSize, PRJ_UPDATE_TYPES updateFlags, PRJ_UPDATE_FAILURE_CAUSES
	// *failureReason );
	[DllImport(Lib.ProjectedFSLib, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("projectedfslib.h", MSDNShortId = "182C9C5E-ABBC-4A7C-99E4-D019B7E237CE")]
	public static extern HRESULT PrjUpdateFileIfNeeded(PRJ_NAMESPACE_VIRTUALIZATION_CONTEXT namespaceVirtualizationContext, [MarshalAs(UnmanagedType.LPWStr)] string destinationFileName,
		[In] IntPtr placeholderInfo, uint placeholderInfoSize, [Optional] PRJ_UPDATE_TYPES updateFlags, out PRJ_UPDATE_FAILURE_CAUSES failureReason);

	/// <summary>TBD</summary>
	/// <param name="namespaceVirtualizationContext">
	/// <para>Opaque handle for the virtualization instance.</para>
	/// <para>
	/// If the provider is servicing a PRJ_GET_FILE_DATA_CB callback, this must be the value from the VirtualizationInstanceHandle
	/// member of the callbackData passed to the provider in the callback.
	/// </para>
	/// </param>
	/// <param name="dataStreamId">
	/// <para>Identifier for the data stream to write to.</para>
	/// <para>
	/// If the provider is servicing a PRJ_GET_FILE_DATA_CB callback, this must be the value from the DataStreamId member of the
	/// callbackData passed to the provider in the callback.
	/// </para>
	/// </param>
	/// <param name="buffer">
	/// Pointer to a buffer containing the data to write. The buffer must be at least as large as the value of the length parameter in
	/// bytes. The provider should use PrjAllocateAlignedBuffer to ensure that the buffer meets the storage device’s alignment requirements.
	/// </param>
	/// <param name="byteOffset">Byte offset from the beginning of the file at which to write the data.</param>
	/// <param name="length">The number of bytes to write to the file.</param>
	/// <returns>
	/// HRESULT_FROM_WIN32(ERROR_OFFSET_ALIGNMENT_VIOLATION) indicates that the user's handle was opened for unbuffered I/O and
	/// byteOffset is not aligned to the sector size of the storage device.
	/// </returns>
	/// <remarks>
	/// <para>The provider uses this routine to provide the data requested in an invocation of its PRJ_GET_FILE_DATA_CB callback.</para>
	/// <para>
	/// The provider’s PRJ_GET_FILE_DATA_CB callback is invoked when the system needs to ensure that a file contains data. When the
	/// provider calls PrjWriteFileData to supply the requested data the system uses the user’s FILE_OBJECT to write that data to the
	/// file. However the system cannot control whether that FILE_OBJECT was opened for buffered or unbuffered I/O. If the FILE_OBJECT
	/// was opened for unbuffered I/O, reads and writes to the file must adhere to certain alignment requirements. The provider can meet
	/// those alignment requirements by doing two things:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>Use PrjAllocateAlignedBuffer to allocate the buffer to pass to buffer.</term>
	/// </item>
	/// <item>
	/// <term>
	/// Ensure that byteOffset and length are integer multiples of the storage device’s alignment requirement (length does not have to
	/// meet this requirement if byteOffset + length is equal to the end of the file). The provider can use
	/// PrjGetVirtualizationInstanceInfo to retrieve the storage device’s alignment requirement.
	/// </term>
	/// </item>
	/// </list>
	/// <para>
	/// The system leaves it up to the provider to calculate proper alignment because when processing a PRJ_GET_FILE_DATA_CB callback
	/// the provider may opt to return the requested data across multiple PrjWriteFileData calls, each returning part of the total
	/// requested data.
	/// </para>
	/// <para>
	/// Note that if the provider is going to write the entire file in a single call to PrjWriteFileData, i.e. from byteOffset = 0 to
	/// length = size of the file, the provider does not have to do any alignment calculations. However it must still use
	/// PrjAllocateAlignedBuffer to ensure that buffer meets the storage device’s alignment requirements. See the File Buffering topic
	/// for more information on buffered vs unbuffered I/O.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/projectedfslib/nf-projectedfslib-prjwritefiledata HRESULT PrjWriteFileData(
	// PRJ_NAMESPACE_VIRTUALIZATION_CONTEXT namespaceVirtualizationContext, const GUID *dataStreamId, void *buffer, UINT64 byteOffset,
	// UINT32 length );
	[DllImport(Lib.ProjectedFSLib, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("projectedfslib.h", MSDNShortId = "A09D8E74-D574-41C6-A586-86E03839DA89")]
	public static extern HRESULT PrjWriteFileData(PRJ_NAMESPACE_VIRTUALIZATION_CONTEXT namespaceVirtualizationContext, in Guid dataStreamId, [In] IntPtr buffer, ulong byteOffset, uint length);

	/// <summary>Sends file or directory metadata to ProjFS.</summary>
	/// <param name="namespaceVirtualizationContext">
	/// Opaque handle for the virtualization instance. This must be the value from the VirtualizationInstanceHandle member of the
	/// callbackData passed to the provider in the PRJ_GET_PLACEHOLDER_INFO_CB callback.
	/// </param>
	/// <param name="destinationFileName">
	/// <para>
	/// A null-terminated Unicode string specifying the path, relative to the virtualization root, to the file or directory for which to
	/// create a placeholder.
	/// </para>
	/// <para>
	/// This must be a match to the FilePathName member of the callbackData parameter passed to the provider in the
	/// PRJ_GET_PLACEHOLDER_INFO_CB callback. The provider should use the PrjFileNameCompare function to determine whether the two names match.
	/// </para>
	/// <para>
	/// For example, if the PRJ_GET_PLACEHOLDER_INFO_CB callback specifies “dir1\dir1\FILE.TXT” in callbackData-&gt;FilePathName, and
	/// the provider’s backing store contains a file called “File.txt” in the dir1\dir2 directory, and PrjFileNameCompare returns 0 when
	/// comparing the names “FILE.TXT” and “File.txt”, then the provider specifies “dir1\dir2\File.txt” as the value of this parameter.
	/// </para>
	/// </param>
	/// <param name="placeholderInfo">A pointer to the metadata for the file or directory.</param>
	/// <param name="placeholderInfoSize">Size in bytes of the buffer pointed to by placeholderInfo.</param>
	/// <returns>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
	/// <remarks>
	/// <para>
	/// The provider uses this routine to provide the data requested in an invocation of its PRJ_GET_PLACEHOLDER_INFO_CB callback, or it
	/// may use it to proactively lay down a placeholder.
	/// </para>
	/// <para>
	/// The EaInformation, SecurityInformation, and StreamsInformation members of PRJ_PLACEHOLDER_INFO are optional. If the provider
	/// does not wish to provide extended attributes, custom security descriptors, or alternate data streams, it must set these fields
	/// to 0.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/projectedfslib/nf-projectedfslib-prjwriteplaceholderinfo HRESULT
	// PrjWritePlaceholderInfo( PRJ_NAMESPACE_VIRTUALIZATION_CONTEXT namespaceVirtualizationContext, PCWSTR destinationFileName, const
	// PRJ_PLACEHOLDER_INFO *placeholderInfo, UINT32 placeholderInfoSize );
	[DllImport(Lib.ProjectedFSLib, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("projectedfslib.h", MSDNShortId = "EAEA2D05-2FCF-46A7-AEBD-9CF085D868E1")]
	public static extern HRESULT PrjWritePlaceholderInfo(PRJ_NAMESPACE_VIRTUALIZATION_CONTEXT namespaceVirtualizationContext,
		[MarshalAs(UnmanagedType.LPWStr)] string destinationFileName, in PRJ_PLACEHOLDER_INFO placeholderInfo, uint placeholderInfoSize);

	/// <summary>Sends file or directory metadata to ProjFS and allows the caller to specify extended information.</summary>
	/// <param name="namespaceVirtualizationContext">
	/// Opaque handle for the virtualization instance. This must be the value from the VirtualizationInstanceHandle member of the
	/// callbackData passed to the provider in the PRJ_GET_PLACEHOLDER_INFO_CB callback.
	/// </param>
	/// <param name="destinationFileName">
	/// <para>
	/// A null-terminated Unicode string specifying the path, relative to the virtualization root, to the file or directory for which to
	/// create a placeholder.
	/// </para>
	/// <para>
	/// This must be a match to the FilePathName member of the callbackData parameter passed to the provider in the
	/// PRJ_GET_PLACEHOLDER_INFO_CB callback. The provider should use the PrjFileNameCompare function to determine whether the two names match.
	/// </para>
	/// <para>
	/// For example, if the PRJ_GET_PLACEHOLDER_INFO_CB callback specifies “dir1\dir1\FILE.TXT” in callbackData-&gt;FilePathName, and
	/// the provider’s backing store contains a file called “File.txt” in the dir1\dir2 directory, and PrjFileNameCompare returns 0 when
	/// comparing the names “FILE.TXT” and “File.txt”, then the provider specifies “dir1\dir2\File.txt” as the value of this parameter.
	/// </para>
	/// </param>
	/// <param name="placeholderInfo">A pointer to the metadata for the file or directory. Type: <see cref="PRJ_PLACEHOLDER_INFO"/>.</param>
	/// <param name="placeholderInfoSize">Size in bytes of the buffer pointed to by placeholderInfo.</param>
	/// <param name="ExtendedInfo"/>
	/// <returns>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
	/// <remarks>
	/// <para>
	/// The provider uses this routine to provide the data requested in an invocation of its PRJ_GET_PLACEHOLDER_INFO_CB callback, or it
	/// may use it to proactively lay down a placeholder.
	/// </para>
	/// <para>
	/// The EaInformation, SecurityInformation, and StreamsInformation members of PRJ_PLACEHOLDER_INFO are optional. If the provider
	/// does not wish to provide extended attributes, custom security descriptors, or alternate data streams, it must set these fields
	/// to 0.
	/// </para>
	/// <para>Symbolic Links</para>
	/// <para>
	/// To specify that this placeholder is to be a symbolic link, the provider formats a buffer with a single PRJ_EXTENDED_INFO struct
	/// and passes a pointer to it in the parameter. The provider sets the struct's fields as follows:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <code>extendedInfo.InfoType = PRJ_EXT_INFO_TYPE_SYMLINK</code>
	/// </item>
	/// <item>
	/// <code>extendedInfo.NextInfoOffset = 0</code>
	/// </item>
	/// <item>
	/// <code>extendedInfo.Symlink.TargetName = &lt;path to the target of the symbolic link&gt;</code>
	/// </item>
	/// </list>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/projectedfslib/nf-projectedfslib-prjwriteplaceholderinfo2 HRESULT
	// PrjWritePlaceholderInfo2( PRJ_NAMESPACE_VIRTUALIZATION_CONTEXT namespaceVirtualizationContext, PCWSTR destinationFileName, const
	// PRJ_PLACEHOLDER_INFO *placeholderInfo, UINT32 placeholderInfoSize, const PRJ_EXTENDED_INFO *ExtendedInfo );
	[DllImport(Lib.ProjectedFSLib, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("projectedfslib.h", MSDNShortId = "NF:projectedfslib.PrjWritePlaceholderInfo2")]
	public static extern HRESULT PrjWritePlaceholderInfo2(PRJ_NAMESPACE_VIRTUALIZATION_CONTEXT namespaceVirtualizationContext,
		[MarshalAs(UnmanagedType.LPWStr)] string destinationFileName, IntPtr placeholderInfo, uint placeholderInfoSize, in PRJ_EXTENDED_INFO ExtendedInfo);

	/// <summary>Sends file or directory metadata to ProjFS and allows the caller to specify extended information.</summary>
	/// <param name="namespaceVirtualizationContext">
	/// Opaque handle for the virtualization instance. This must be the value from the VirtualizationInstanceHandle member of the
	/// callbackData passed to the provider in the PRJ_GET_PLACEHOLDER_INFO_CB callback.
	/// </param>
	/// <param name="destinationFileName">
	/// <para>
	/// A null-terminated Unicode string specifying the path, relative to the virtualization root, to the file or directory for which to
	/// create a placeholder.
	/// </para>
	/// <para>
	/// This must be a match to the FilePathName member of the callbackData parameter passed to the provider in the
	/// PRJ_GET_PLACEHOLDER_INFO_CB callback. The provider should use the PrjFileNameCompare function to determine whether the two names match.
	/// </para>
	/// <para>
	/// For example, if the PRJ_GET_PLACEHOLDER_INFO_CB callback specifies “dir1\dir1\FILE.TXT” in callbackData-&gt;FilePathName, and
	/// the provider’s backing store contains a file called “File.txt” in the dir1\dir2 directory, and PrjFileNameCompare returns 0 when
	/// comparing the names “FILE.TXT” and “File.txt”, then the provider specifies “dir1\dir2\File.txt” as the value of this parameter.
	/// </para>
	/// </param>
	/// <param name="placeholderInfo">A pointer to the metadata for the file or directory. Type: <see cref="PRJ_PLACEHOLDER_INFO"/>.</param>
	/// <param name="placeholderInfoSize">Size in bytes of the buffer pointed to by placeholderInfo.</param>
	/// <param name="ExtendedInfo"/>
	/// <returns>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
	/// <remarks>
	/// <para>
	/// The provider uses this routine to provide the data requested in an invocation of its PRJ_GET_PLACEHOLDER_INFO_CB callback, or it
	/// may use it to proactively lay down a placeholder.
	/// </para>
	/// <para>
	/// The EaInformation, SecurityInformation, and StreamsInformation members of PRJ_PLACEHOLDER_INFO are optional. If the provider
	/// does not wish to provide extended attributes, custom security descriptors, or alternate data streams, it must set these fields
	/// to 0.
	/// </para>
	/// <para>Symbolic Links</para>
	/// <para>
	/// To specify that this placeholder is to be a symbolic link, the provider formats a buffer with a single PRJ_EXTENDED_INFO struct
	/// and passes a pointer to it in the parameter. The provider sets the struct's fields as follows:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <code>extendedInfo.InfoType = PRJ_EXT_INFO_TYPE_SYMLINK</code>
	/// </item>
	/// <item>
	/// <code>extendedInfo.NextInfoOffset = 0</code>
	/// </item>
	/// <item>
	/// <code>extendedInfo.Symlink.TargetName = &lt;path to the target of the symbolic link&gt;</code>
	/// </item>
	/// </list>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/projectedfslib/nf-projectedfslib-prjwriteplaceholderinfo2 HRESULT
	// PrjWritePlaceholderInfo2( PRJ_NAMESPACE_VIRTUALIZATION_CONTEXT namespaceVirtualizationContext, PCWSTR destinationFileName, const
	// PRJ_PLACEHOLDER_INFO *placeholderInfo, UINT32 placeholderInfoSize, const PRJ_EXTENDED_INFO *ExtendedInfo );
	[DllImport(Lib.ProjectedFSLib, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("projectedfslib.h", MSDNShortId = "NF:projectedfslib.PrjWritePlaceholderInfo2")]
	public static extern HRESULT PrjWritePlaceholderInfo2(PRJ_NAMESPACE_VIRTUALIZATION_CONTEXT namespaceVirtualizationContext,
		[MarshalAs(UnmanagedType.LPWStr)] string destinationFileName, [In] IntPtr placeholderInfo, uint placeholderInfoSize, [In, Optional] IntPtr ExtendedInfo);

	/// <summary>Defines the standard information passed to a provider for every operation callback.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/projectedfslib/ns-projectedfslib-prj_callback_data typedef struct
	// PRJ_CALLBACK_DATA { UINT32 Size; PRJ_CALLBACK_DATA_FLAGS Flags; PRJ_NAMESPACE_VIRTUALIZATION_CONTEXT
	// NamespaceVirtualizationContext; INT32 CommandId; GUID FileId; GUID DataStreamId; PCWSTR FilePathName;
	// PRJ_PLACEHOLDER_VERSION_INFO *VersionInfo; UINT32 TriggeringProcessId; PCWSTR TriggeringProcessImageFileName; void
	// *InstanceContext; } PRJ_CALLBACK_DATA;
	[PInvokeData("projectedfslib.h", MSDNShortId = "569204FF-97F5-4FE2-9885-94C88AB5A6FE")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct PRJ_CALLBACK_DATA
	{
		/// <summary>
		/// Size in bytes of this structure. The provider must not attempt to access any field of this structure that is located beyond
		/// this value.
		/// </summary>
		public uint Size;

		/// <summary>Callback-specific flags.</summary>
		public PRJ_CALLBACK_DATA_FLAGS Flags;

		/// <summary/>
		public PRJ_NAMESPACE_VIRTUALIZATION_CONTEXT NamespaceVirtualizationContext;

		/// <summary>
		/// <para>A value that uniquely identifies a particular invocation of a callback. The provider uses this value:</para>
		/// <list type="bullet">
		/// <item>
		/// <term>In calls to PrjCompleteCommand to signal completion of a callback from which it earlier returned HRESULT_FROM_WIN32(ERROR_IO_PENDING).</term>
		/// </item>
		/// <item>
		/// <term>
		/// When ProjFS sends a PRJ_CANCEL_COMMAND_CB callback. The commandId in the PRJ_CANCEL_COMMAND_CB call identifies an earlier
		/// invocation of a callback that the provider should cancel.
		/// </term>
		/// </item>
		/// </list>
		/// </summary>
		public int CommandId;

		/// <summary>A value that uniquely identifies the file handle for the callback.</summary>
		public Guid FileId;

		/// <summary>A value that uniquely identifies an open data stream for the callback.</summary>
		public Guid DataStreamId;

		/// <summary>
		/// The path to the target file. This is a null-terminated string of Unicode characters. This path is always specified relative
		/// to the virtualization root.
		/// </summary>
		[MarshalAs(UnmanagedType.LPWStr)] public string FilePathName;

		/// <summary>Version information if the target of the callback is a placeholder or partial file.</summary>
		public IntPtr VersionInfo;

		/// <summary>
		/// The process identifier for the process that triggered this callback. If this information is not available, this will be 0.
		/// Callbacks that supply this information include: PRJ_GET_PLACEHOLDER_INFO_CB, PRJ_GET_FILE_DATA_CB, and PRJ_NOTIFICATION_CB.
		/// </summary>
		public uint TriggeringProcessId;

		/// <summary>
		/// A null-terminated Unicode string specifying the image file name corresponding to TriggeringProcessId. If TriggeringProcessId
		/// is 0 this will be NULL.
		/// </summary>
		[MarshalAs(UnmanagedType.LPWStr)] public string TriggeringProcessImageFileName;

		/// <summary>
		/// <para>
		/// A pointer to context information defined by the provider. The provider passes this context in the instanceContext parameter
		/// of PrjStartVirtualizing.
		/// </para>
		/// <para>If the provider did not specify such a context, this value will be NULL.</para>
		/// </summary>
		public IntPtr InstanceContext;
	}

	/// <summary>A set of callback routines to where the provider stores its implementation of the callback.</summary>
	/// <remarks>
	/// <para>
	/// The provider must supply implementations for StartDirectoryEnumerationCallback, EndDirectoryEnumerationCallback,
	/// GetDirectoryEnumerationCallback, GetPlaceholderInformationCallback, and GetFileDataCallback.
	/// </para>
	/// <para>The QueryFileNameCallback, NotifyOperationCallback, and CancelCommandCallback callbacks are optional.</para>
	/// <list type="bullet">
	/// <item>
	/// <term>
	/// If the provider does not supply an implementation of QueryFileNameCallback, ProjFS will invoke the directory enumeration
	/// callbacks to determine the existence of a file path in the provider's store.
	/// </term>
	/// </item>
	/// <item>
	/// <term>If the provider does not supply an implementation of NotifyOperationCallback, it will not get any notifications from ProjFS.</term>
	/// </item>
	/// <item>
	/// <term>
	/// If the provider does not supply an implementation of CancelCommandCallback, none of the other callbacks will be cancellable. The
	/// provider will process all callbacks synchronously.
	/// </term>
	/// </item>
	/// </list>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/projectedfslib/ns-projectedfslib-prj_callbacks typedef struct PRJ_CALLBACKS {
	// PRJ_START_DIRECTORY_ENUMERATION_CB *StartDirectoryEnumerationCallback; PRJ_END_DIRECTORY_ENUMERATION_CB
	// *EndDirectoryEnumerationCallback; PRJ_GET_DIRECTORY_ENUMERATION_CB *GetDirectoryEnumerationCallback; PRJ_GET_PLACEHOLDER_INFO_CB
	// *GetPlaceholderInfoCallback; PRJ_GET_FILE_DATA_CB *GetFileDataCallback; PRJ_QUERY_FILE_NAME_CB *QueryFileNameCallback;
	// PRJ_NOTIFICATION_CB *NotificationCallback; PRJ_CANCEL_COMMAND_CB *CancelCommandCallback; } PRJ_CALLBACKS;
	[PInvokeData("projectedfslib.h", MSDNShortId = "2FFF6A39-92C0-4BD1-B293-AC5650B2575C")]
	[StructLayout(LayoutKind.Sequential)]
	public struct PRJ_CALLBACKS
	{
		/// <summary>A pointer to the StartDirectoryEnumerationCallback.</summary>
		[MarshalAs(UnmanagedType.FunctionPtr)]
		public PRJ_START_DIRECTORY_ENUMERATION_CB StartDirectoryEnumerationCallback;

		/// <summary>A pointer to the EndDirectoryEnumerationCallback.</summary>
		[MarshalAs(UnmanagedType.FunctionPtr)]
		public PRJ_END_DIRECTORY_ENUMERATION_CB EndDirectoryEnumerationCallback;

		/// <summary>A pointer to the GetDirectoryEnumerationCallback.</summary>
		[MarshalAs(UnmanagedType.FunctionPtr)]
		public PRJ_GET_DIRECTORY_ENUMERATION_CB GetDirectoryEnumerationCallback;

		/// <summary/>
		[MarshalAs(UnmanagedType.FunctionPtr)]
		public PRJ_GET_PLACEHOLDER_INFO_CB GetPlaceholderInfoCallback;

		/// <summary>A pointer to the GetFileDataCallback.</summary>
		[MarshalAs(UnmanagedType.FunctionPtr)]
		public PRJ_GET_FILE_DATA_CB GetFileDataCallback;

		/// <summary>A pointer to the QueryFileNameCallback.</summary>
		[MarshalAs(UnmanagedType.FunctionPtr)]
		public PRJ_QUERY_FILE_NAME_CB QueryFileNameCallback;

		/// <summary/>
		[MarshalAs(UnmanagedType.FunctionPtr)]
		public PRJ_NOTIFICATION_CB NotificationCallback;

		/// <summary>A pointer to the CancelCommandCallback.</summary>
		[MarshalAs(UnmanagedType.FunctionPtr)]
		public PRJ_CANCEL_COMMAND_CB CancelCommandCallback;
	}

	/// <summary>Specifies parameters required for completing certain callbacks.</summary>
	/// <remarks>
	/// <para>
	/// For any callback except PRJ_CANCEL_COMMAND_CB, the provider may opt to process the callback asynchronously. To do so it returns
	/// HRESULT_FROM_WIN32(ERROR_IO_PENDING) from the callback. Once the provider has finished processing the callback.
	/// </para>
	/// <para>
	/// If the provider calls this function for the commandId passed by the PRJ_CANCEL_COMMAND_CB callback it is not an error, however
	/// it is a no-op because the I/O that caused the callback invocation identified by commandId has already ended.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/projectedfslib/ns-projectedfslib-prj_complete_command_extended_parameters
	// typedef struct PRJ_COMPLETE_COMMAND_EXTENDED_PARAMETERS { PRJ_COMPLETE_COMMAND_TYPE CommandType; union { struct {
	// PRJ_NOTIFY_TYPES NotificationMask; } Notification; struct { PRJ_DIR_ENTRY_BUFFER_HANDLE DirEntryBufferHandle; } Enumeration; }
	// DUMMYUNIONNAME; } PRJ_COMPLETE_COMMAND_EXTENDED_PARAMETERS;
	[PInvokeData("projectedfslib.h", MSDNShortId = "1E13CED8-41DF-4206-AA60-751424424011")]
	[StructLayout(LayoutKind.Explicit)]
	public struct PRJ_COMPLETE_COMMAND_EXTENDED_PARAMETERS
	{
		/// <summary/>
		[FieldOffset(0)]
		public PRJ_COMPLETE_COMMAND_TYPE CommandType;

		/// <summary>A new set of notifications the provider wishes to receive.</summary>
		[FieldOffset(4)]
		public PRJ_NOTIFY_TYPES NotificationMask;

		/// <summary>
		/// An opaque handle to a directory entry buffer. This must be the value passed in the dirEntryBufferHandle parameter of the
		/// PRJ_GET_DIRECTORY_ENUMERATION_CB callback being completed.
		/// </summary>
		[FieldOffset(4)]
		public PRJ_DIR_ENTRY_BUFFER_HANDLE DirEntryBufferHandle;
	}

	/// <summary>Provides a handle to a directory entry buffer.</summary>
	[StructLayout(LayoutKind.Sequential)]
	public struct PRJ_DIR_ENTRY_BUFFER_HANDLE : IHandle
	{
		private IntPtr handle;

		/// <summary>Initializes a new instance of the <see cref="PRJ_DIR_ENTRY_BUFFER_HANDLE"/> struct.</summary>
		/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
		public PRJ_DIR_ENTRY_BUFFER_HANDLE(IntPtr preexistingHandle) => handle = preexistingHandle;

		/// <summary>Returns an invalid handle by instantiating a <see cref="PRJ_DIR_ENTRY_BUFFER_HANDLE"/> object with <see cref="IntPtr.Zero"/>.</summary>
		public static PRJ_DIR_ENTRY_BUFFER_HANDLE NULL => new PRJ_DIR_ENTRY_BUFFER_HANDLE(IntPtr.Zero);

		/// <summary>Gets a value indicating whether this instance is a null handle.</summary>
		public bool IsNull => handle == IntPtr.Zero;

		/// <summary>Performs an explicit conversion from <see cref="PRJ_DIR_ENTRY_BUFFER_HANDLE"/> to <see cref="IntPtr"/>.</summary>
		/// <param name="h">The handle.</param>
		/// <returns>The result of the conversion.</returns>
		public static explicit operator IntPtr(PRJ_DIR_ENTRY_BUFFER_HANDLE h) => h.handle;

		/// <summary>Performs an implicit conversion from <see cref="IntPtr"/> to <see cref="PRJ_DIR_ENTRY_BUFFER_HANDLE"/>.</summary>
		/// <param name="h">The pointer to a handle.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator PRJ_DIR_ENTRY_BUFFER_HANDLE(IntPtr h) => new PRJ_DIR_ENTRY_BUFFER_HANDLE(h);

		/// <summary>Implements the operator !=.</summary>
		/// <param name="h1">The first handle.</param>
		/// <param name="h2">The second handle.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator !=(PRJ_DIR_ENTRY_BUFFER_HANDLE h1, PRJ_DIR_ENTRY_BUFFER_HANDLE h2) => !(h1 == h2);

		/// <summary>Implements the operator ==.</summary>
		/// <param name="h1">The first handle.</param>
		/// <param name="h2">The second handle.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator ==(PRJ_DIR_ENTRY_BUFFER_HANDLE h1, PRJ_DIR_ENTRY_BUFFER_HANDLE h2) => h1.Equals(h2);

		/// <inheritdoc/>
		public override bool Equals(object obj) => obj is PRJ_DIR_ENTRY_BUFFER_HANDLE h ? handle == h.handle : false;

		/// <inheritdoc/>
		public override int GetHashCode() => handle.GetHashCode();

		/// <inheritdoc/>
		public IntPtr DangerousGetHandle() => handle;
	}

	/// <summary>
	/// A provider uses PRJ_EXTENDED_INFO to provide extended information about a file when calling PrjFillDirEntryBuffer2 or PrjWritePlaceholderInfo2.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/projectedfslib/ns-projectedfslib-prj_extended_info typedef struct
	// PRJ_EXTENDED_INFO { PRJ_EXT_INFO_TYPE InfoType; ULONG NextInfoOffset; union { struct { PCWSTR TargetName; } Symlink; }
	// DUMMYUNIONNAME; } PRJ_EXTENDED_INFO;
	[PInvokeData("projectedfslib.h", MSDNShortId = "NS:projectedfslib.PRJ_EXTENDED_INFO")]
	[StructLayout(LayoutKind.Sequential)]
	public struct PRJ_EXTENDED_INFO
	{
		/// <summary>A PRJ_EXT_INFO value describing what kind of extended information this structure contains.</summary>
		public PRJ_EXT_INFO_TYPE InfoType;

		/// <summary>
		/// Offset in bytes from the beginning of this structure to the next PRJ_EXTENDED_INFO structure. If this is the last structure
		/// in the buffer this value must be 0.
		/// </summary>
		public uint NextInfoOffset;

		/// <summary>This PRJ_EXTENDED_INFO specifies the target of a symbolic link.</summary>
		public SYMLINK Symlink;

		/// <summary>This PRJ_EXTENDED_INFO specifies the target of a symbolic link.</summary>
		[StructLayout(LayoutKind.Sequential)]
		public struct SYMLINK
		{
			/// <summary>Specifies the name of the target of a symbolic link.</summary>
			[MarshalAs(UnmanagedType.LPWStr)]
			public string TargetName;
		}
	}

	/// <summary>Basic information about an item.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/projectedfslib/ns-projectedfslib-prj_file_basic_info typedef struct
	// PRJ_FILE_BASIC_INFO { BOOLEAN IsDirectory; INT64 FileSize; LARGE_INTEGER CreationTime; LARGE_INTEGER LastAccessTime;
	// LARGE_INTEGER LastWriteTime; LARGE_INTEGER ChangeTime; UINT32 FileAttributes; } PRJ_FILE_BASIC_INFO;
	[PInvokeData("projectedfslib.h", MSDNShortId = "5B5D157E-DEAF-47F2-BDB2-2CF3D307CB7F")]
	[StructLayout(LayoutKind.Sequential)]
	public struct PRJ_FILE_BASIC_INFO
	{
		/// <summary>Specifies whether the item is a directory.</summary>
		[MarshalAs(UnmanagedType.U1)] public bool IsDirectory;

		/// <summary>Size of the item, in bytes.</summary>
		public long FileSize;

		/// <summary>Creation time of the item.</summary>
		public FILETIME CreationTime;

		/// <summary>Last time the item was accessed.</summary>
		public FILETIME LastAccessTime;

		/// <summary>Last time the item was written to.</summary>
		public FILETIME LastWriteTime;

		/// <summary>The last time the item was changed.</summary>
		public FILETIME ChangeTime;

		/// <summary>Attributes of the item.</summary>
		public FileFlagsAndAttributes FileAttributes;
	}

	/// <summary>Provides a handle to a namespace virtualization context.</summary>
	[StructLayout(LayoutKind.Sequential)]
	public struct PRJ_NAMESPACE_VIRTUALIZATION_CONTEXT : IHandle
	{
		private IntPtr handle;

		/// <summary>Initializes a new instance of the <see cref="PRJ_NAMESPACE_VIRTUALIZATION_CONTEXT"/> struct.</summary>
		/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
		public PRJ_NAMESPACE_VIRTUALIZATION_CONTEXT(IntPtr preexistingHandle) => handle = preexistingHandle;

		/// <summary>
		/// Returns an invalid handle by instantiating a <see cref="PRJ_NAMESPACE_VIRTUALIZATION_CONTEXT"/> object with <see cref="IntPtr.Zero"/>.
		/// </summary>
		public static PRJ_NAMESPACE_VIRTUALIZATION_CONTEXT NULL => new PRJ_NAMESPACE_VIRTUALIZATION_CONTEXT(IntPtr.Zero);

		/// <summary>Gets a value indicating whether this instance is a null handle.</summary>
		public bool IsNull => handle == IntPtr.Zero;

		/// <summary>Performs an explicit conversion from <see cref="PRJ_NAMESPACE_VIRTUALIZATION_CONTEXT"/> to <see cref="IntPtr"/>.</summary>
		/// <param name="h">The handle.</param>
		/// <returns>The result of the conversion.</returns>
		public static explicit operator IntPtr(PRJ_NAMESPACE_VIRTUALIZATION_CONTEXT h) => h.handle;

		/// <summary>Performs an implicit conversion from <see cref="IntPtr"/> to <see cref="PRJ_NAMESPACE_VIRTUALIZATION_CONTEXT"/>.</summary>
		/// <param name="h">The pointer to a handle.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator PRJ_NAMESPACE_VIRTUALIZATION_CONTEXT(IntPtr h) => new PRJ_NAMESPACE_VIRTUALIZATION_CONTEXT(h);

		/// <summary>Implements the operator !=.</summary>
		/// <param name="h1">The first handle.</param>
		/// <param name="h2">The second handle.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator !=(PRJ_NAMESPACE_VIRTUALIZATION_CONTEXT h1, PRJ_NAMESPACE_VIRTUALIZATION_CONTEXT h2) => !(h1 == h2);

		/// <summary>Implements the operator ==.</summary>
		/// <param name="h1">The first handle.</param>
		/// <param name="h2">The second handle.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator ==(PRJ_NAMESPACE_VIRTUALIZATION_CONTEXT h1, PRJ_NAMESPACE_VIRTUALIZATION_CONTEXT h2) => h1.Equals(h2);

		/// <inheritdoc/>
		public override bool Equals(object obj) => obj is PRJ_NAMESPACE_VIRTUALIZATION_CONTEXT h ? handle == h.handle : false;

		/// <inheritdoc/>
		public override int GetHashCode() => handle.GetHashCode();

		/// <inheritdoc/>
		public IntPtr DangerousGetHandle() => handle;
	}

	/// <summary>
	/// Describes a notification mapping, which is a pairing between a directory (referred to as a "notification root") and a set of
	/// notifications, expressed as a bit mask.
	/// </summary>
	/// <remarks>
	/// <para>
	/// PRJ_NOTIFICATION_MAPPING describes a "notification mapping", which is a pairing between a directory (referred to as a
	/// "notification root") and a set of notifications, expressed as a bit mask, which ProjFS should send for that directory and its
	/// descendants. A notification mapping can also be established for a single file.
	/// </para>
	/// <para>
	/// The provider puts an array of zero or more PRJ_NOTIFICATION_MAPPING structures in the NotificationMappings member of the options
	/// parameter of PrjStartVirtualizing to configure notifications for the virtualization root.
	/// </para>
	/// <para>
	/// If the provider does not specify any notification mappings, ProjFS will default to sending the notifications
	/// PRJ_NOTIFICATION_FILE_OPENED, PRJ_NOTIFICATION_NEW_FILE_CREATED, and PRJ_NOTIFICATION_FILE_OVERWRITTEN for all files and
	/// directories in the virtualization instance.
	/// </para>
	/// <para>
	/// The directory or file is specified relative to the virtualization root, with an empty string representing the virtualization
	/// root itself.
	/// </para>
	/// <para>
	/// If the provider specifies multiple notification mappings, and some are descendants of others, the mappings must be specified in
	/// descending depth. Notification mappings at deeper levels override higher-level ones for their descendants.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/projectedfslib/ns-projectedfslib-prj_notification_mapping typedef struct
	// PRJ_NOTIFICATION_MAPPING { PRJ_NOTIFY_TYPES NotificationBitMask; PCWSTR NotificationRoot; } PRJ_NOTIFICATION_MAPPING;
	[PInvokeData("projectedfslib.h", MSDNShortId = "758E1ADB-8C16-46D9-B796-57C0B875790D")]
	[StructLayout(LayoutKind.Sequential)]
	public struct PRJ_NOTIFICATION_MAPPING
	{
		/// <summary>A bit mask representing a set of notifications.</summary>
		public PRJ_NOTIFY_TYPES NotificationBitMask;

		/// <summary>The directory that the notification mapping is paired to.</summary>
		[MarshalAs(UnmanagedType.LPWStr)] public string NotificationRoot;
	}

	/// <summary>Extra parameters for notifications.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/projectedfslib/ns-projectedfslib-prj_notification_parameters typedef union
	// PRJ_NOTIFICATION_PARAMETERS { struct { PRJ_NOTIFY_TYPES NotificationMask; } PostCreate; struct { PRJ_NOTIFY_TYPES
	// NotificationMask; } FileRenamed; struct { BOOLEAN IsFileModified; } FileDeletedOnHandleClose; } PRJ_NOTIFICATION_PARAMETERS;
	[PInvokeData("projectedfslib.h", MSDNShortId = "596DC712-C6DD-4834-9E0F-CA21B0BC3BB3")]
	[StructLayout(LayoutKind.Explicit)]
	public struct PRJ_NOTIFICATION_PARAMETERS
	{
		/// <summary>
		/// Upon return from the PRJ_NOTIFICATION_CB callback, the provider may specify a new set of notifications that it wishes to
		/// receive for the file here. If the provider sets this value to 0, it is equivalent to specifying PRJ_NOTIFICATION_USE_EXISTING_MASK.
		/// </summary>
		[FieldOffset(0)]
		public PRJ_NOTIFY_TYPES PostCreate_NotificationMask;

		/// <summary>
		/// Upon return from the PRJ_NOTIFICATION_CB callback, the provider may specify a new set of notifications that it wishes to
		/// receive for the file here. If the provider sets this value to 0, it is equivalent to specifying PRJ_NOTIFICATION_USE_EXISTING_MASK.
		/// </summary>
		[FieldOffset(0)]
		public PRJ_NOTIFY_TYPES FileRenamed_NotificationMask;

		/// <summary>
		/// If the provider registered for PRJ_NOTIFICATION_FILE_HANDLE_CLOSED_FILE_MODIFIED as well as
		/// PRJ_NOTIFICATION_FILE_HANDLE_CLOSED_FILE_DELETED, this field is set to TRUE if the file was modified before it was deleted.
		/// </summary>
		[FieldOffset(0)]
		public BOOLEAN FileDeletedOnHandleClose_IsFileModified;
	}

	/// <summary>A buffer of metadata for the placeholder file or directory.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/projectedfslib/ns-projectedfslib-prj_placeholder_info typedef struct
	// PRJ_PLACEHOLDER_INFO { PRJ_FILE_BASIC_INFO FileBasicInfo; struct { UINT32 EaBufferSize; UINT32 OffsetToFirstEa; } EaInformation;
	// struct { UINT32 SecurityBufferSize; UINT32 OffsetToSecurityDescriptor; } SecurityInformation; struct { UINT32
	// StreamsInfoBufferSize; UINT32 OffsetToFirstStreamInfo; } StreamsInformation; PRJ_PLACEHOLDER_VERSION_INFO VersionInfo; UINT8
	// VariableData[1]; } PRJ_PLACEHOLDER_INFO;
	[PInvokeData("projectedfslib.h", MSDNShortId = "84F510F6-7192-4B0D-A063-CE99B54ED7DD")]
	[StructLayout(LayoutKind.Sequential)]
	public struct PRJ_PLACEHOLDER_INFO
	{
		/// <summary>
		/// A structure that supplies basic information about the item: the size of the file in bytes (should be zero if the IsDirectory
		/// field is set to TRUE), the item’s timestamps, and its attributes.
		/// </summary>
		public PRJ_FILE_BASIC_INFO FileBasicInfo;

		/// <summary>A structure that supplies extended attribute (EA) information about the item.</summary>
		public EAINFORMATION EaInformation;

		/// <summary>Supplies custom security descriptor information about the item.</summary>
		public SECURITYINFORMATION SecurityInformation;

		/// <summary>Supplies information about alternate data streams for the item.</summary>
		public STREAMSINFORMATION StreamsInformation;

		/// <summary/>
		public PRJ_PLACEHOLDER_VERSION_INFO VersionInfo;

		/// <summary/>
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
		public byte[] VariableData;

		/// <summary>A structure that supplies extended attribute (EA) information about the item.</summary>
		[StructLayout(LayoutKind.Sequential)]
		public struct EAINFORMATION
		{
			/// <summary>
			/// The size in bytes of the extended attribute buffer. If there is no extended attribute information, this must be set to 0.
			/// </summary>
			public uint EaBufferSize;

			/// <summary>
			/// The offset, in bytes, from the start of the <c>PRJ_PLACEHOLDER_INFO</c> structure to the first FILE_FULL_EA_INFORMATION entry.
			/// </summary>
			public uint OffsetToFirstEa;
		}

		/// <summary>Supplies custom security descriptor information about the item.</summary>
		[StructLayout(LayoutKind.Sequential)]
		public struct SECURITYINFORMATION
		{
			/// <summary>
			/// The size, in bytes, of the custom security descriptor. If there is no custom security descriptor, this must be set to 0.
			/// </summary>
			public uint SecurityBufferSize;

			/// <summary>
			/// Specifies the offset, in bytes, from the start of the <c>PRJ_PLACEHOLDER_INFO</c> structure to the SECURITY_DESCRIPTOR structure.
			/// </summary>
			public uint OffsetToSecurityDescriptor;
		}

		/// <summary>Supplies information about alternate data streams for the item.</summary>
		[StructLayout(LayoutKind.Sequential)]
		public struct STREAMSINFORMATION
		{
			/// <summary>
			/// The size, in bytes, of alternate data stream information for the placeholder. If there are no alternate data streams,
			/// this must be set to 0.
			/// </summary>
			public uint StreamsInfoBufferSize;

			/// <summary>
			/// The offset, in bytes, from the start of the <c>PRJ_PLACEHOLDER_INFO</c> structure to the first FILE_STREAM_INFORMATION entry.
			/// </summary>
			public uint OffsetToFirstStreamInfo;
		}
	}

	/// <summary>Information that uniquely identifies the contents of a placeholder file.</summary>
	/// <remarks>
	/// <para>
	/// A provider uses <c>PRJ_PLACEHOLDER_VERSION_INFO</c> to provide information that uniquely identifies the contents of a
	/// placeholder file. ProjFS stores the contents of this struct with the file and returns it when invoking callbacks.
	/// </para>
	/// <para>
	/// <c>PRJ_PLACEHOLDER_VERSION_INFO</c>.ProviderID is a provider-specific identifier. The provider may use this value as its own
	/// unique identifier, for example as a version number for the format of the ContentID field.
	/// </para>
	/// <para>
	/// <c>PRJ_PLACEHOLDER_VERSION_INFO</c>.ContentID is a content identifier, generated by the provider. This value is used to
	/// distinguish different versions of the same file, i.e. different file contents and/or metadata (e.g. timestamps) for the same
	/// file path.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/projectedfslib/ns-projectedfslib-prj_placeholder_version_info typedef struct
	// PRJ_PLACEHOLDER_VERSION_INFO { UINT8 ProviderID[PRJ_PLACEHOLDER_ID_LENGTH]; UINT8 ContentID[PRJ_PLACEHOLDER_ID_LENGTH]; } PRJ_PLACEHOLDER_VERSION_INFO;
	[PInvokeData("projectedfslib.h", MSDNShortId = "4F2156AC-087B-4FF6-8566-25D9DC2A8C06")]
	[StructLayout(LayoutKind.Sequential)]
	public struct PRJ_PLACEHOLDER_VERSION_INFO
	{
		/// <summary>A provider specific identifier.</summary>
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = (int)PRJ_PLACEHOLDER_ID.PRJ_PLACEHOLDER_ID_LENGTH)]
		public byte[] ProviderID;

		/// <summary>A content identifier, generated by the provider.</summary>
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = (int)PRJ_PLACEHOLDER_ID.PRJ_PLACEHOLDER_ID_LENGTH)]
		public byte[] ContentID;
	}

	/// <summary>Options to provide when starting a virtualization instance.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/projectedfslib/ns-projectedfslib-prj_startvirtualizing_options typedef struct
	// PRJ_STARTVIRTUALIZING_OPTIONS { PRJ_STARTVIRTUALIZING_FLAGS Flags; UINT32 PoolThreadCount; UINT32 ConcurrentThreadCount;
	// PRJ_NOTIFICATION_MAPPING *NotificationMappings; UINT32 NotificationMappingsCount; } PRJ_STARTVIRTUALIZING_OPTIONS;
	[PInvokeData("projectedfslib.h", MSDNShortId = "5FF20B04-29A6-4310-ACD6-35E189B87C9E")]
	[StructLayout(LayoutKind.Sequential)]
	public struct PRJ_STARTVIRTUALIZING_OPTIONS
	{
		/// <summary>A flag for starting virtualization.</summary>
		public PRJ_STARTVIRTUALIZING_FLAGS Flags;

		/// <summary>The number of threads the provider wants to create to service callbacks.</summary>
		public uint PoolThreadCount;

		/// <summary>The maximum number of threads the provider wants to run concurrently to process callbacks.</summary>
		public uint ConcurrentThreadCount;

		/// <summary>
		/// An array of zero or more notification mappings. See the Remarks section of PRJ_NOTIFICATION MAPPING for more details.
		/// </summary>
		public IntPtr NotificationMappings;

		/// <summary>The number of notification mappings provided in NotificationMappings.</summary>
		public uint NotificationMappingsCount;
	}

	/// <summary>Information about a virtualization instance.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/projectedfslib/ns-projectedfslib-prj_virtualization_instance_info typedef
	// struct PRJ_VIRTUALIZATION_INSTANCE_INFO { GUID InstanceID; UINT32 WriteAlignment; } PRJ_VIRTUALIZATION_INSTANCE_INFO;
	[PInvokeData("projectedfslib.h", MSDNShortId = "B6532FDF-F190-4C10-BF5C-96BDF477BB4A")]
	[StructLayout(LayoutKind.Sequential)]
	public struct PRJ_VIRTUALIZATION_INSTANCE_INFO
	{
		/// <summary>An ID corresponding to a specific virtualization instance.</summary>
		public Guid InstanceID;

		/// <summary>The value used for the byteOffset and length parameters of PrjWriteFileData.</summary>
		public uint WriteAlignment;
	}
}