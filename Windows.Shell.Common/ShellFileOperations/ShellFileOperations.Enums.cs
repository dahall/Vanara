using System;
using static Vanara.PInvoke.Shell32;

namespace Vanara.Windows.Shell;

public partial class ShellFileOperations
{
	/// <summary>Flags that control the file operation.</summary>
	[Flags]
	public enum OperationFlags : uint
	{
		/// <summary>
		/// The pTo member specifies multiple destination files (one for each source file in pFrom) rather than one directory where all
		/// source files are to be deposited.
		/// </summary>
		MultiDestFiles = FILEOP_FLAGS.FOF_MULTIDESTFILES,

		/// <summary>Do not display a progress dialog box.</summary>
		Silent = FILEOP_FLAGS.FOF_SILENT,

		/// <summary>
		/// Give the item being operated on a new name in a move, copy, or rename operation if an item with the target name already exists.
		/// </summary>
		RenameOnCollision = FILEOP_FLAGS.FOF_RENAMEONCOLLISION,

		/// <summary>Respond with Yes to All for any dialog box that is displayed.</summary>
		NoConfirmation = FILEOP_FLAGS.FOF_NOCONFIRMATION,

		/// <summary>
		/// If FOF_RENAMEONCOLLISION is specified and any files were renamed, assign a name mapping object that contains their old and
		/// new names to the hNameMappings member. This object must be freed using SHFreeNameMappings when it is no longer needed.
		/// </summary>
		WantMappingHandle = FILEOP_FLAGS.FOF_WANTMAPPINGHANDLE,

		/// <summary>
		/// Preserve undo information, if possible.
		/// <para>Prior to Windows Vista, operations could be undone only from the same process that performed the original operation.</para>
		/// <para>
		/// In Windows Vista and later systems, the scope of the undo is a user session. Any process running in the user session can
		/// undo another operation. The undo state is held in the Explorer.exe process, and as long as that process is running, it can
		/// coordinate the undo functions.
		/// </para>
		/// <para>If the source file parameter does not contain fully qualified path and file names, this flag is ignored.</para>
		/// </summary>
		AllowUndo = FILEOP_FLAGS.FOF_ALLOWUNDO,

		/// <summary>Perform the operation only on files (not on folders) if a wildcard file name (*.*) is specified.</summary>
		FilesOnly = FILEOP_FLAGS.FOF_FILESONLY,

		/// <summary>Display a progress dialog box but do not show individual file names as they are operated on.</summary>
		SimpleProgress = FILEOP_FLAGS.FOF_SIMPLEPROGRESS,

		/// <summary>Do not confirm the creation of a new folder if the operation requires one to be created.</summary>
		NoConfirmMkDir = FILEOP_FLAGS.FOF_NOCONFIRMMKDIR,

		/// <summary>
		/// Do not display a message to the user if an error occurs. If this flag is set without FOFX_EARLYFAILURE, any error is treated
		/// as if the user had chosen Ignore or Continue in a dialog box. It halts the current action, sets a flag to indicate that an
		/// action was aborted, and proceeds with the rest of the operation.
		/// </summary>
		NoErrorUI = FILEOP_FLAGS.FOF_NOERRORUI,

		/// <summary>Do not copy the security attributes of the item.</summary>
		NoCopySecurityAttribs = FILEOP_FLAGS.FOF_NOCOPYSECURITYATTRIBS,

		/// <summary>Only operate in the local folder. Do not operate recursively into subdirectories.</summary>
		NoRecursion = FILEOP_FLAGS.FOF_NORECURSION,

		/// <summary>Do not move connected items as a group. Only move the specified files.</summary>
		NoConnectedElements = FILEOP_FLAGS.FOF_NO_CONNECTED_ELEMENTS,

		/// <summary>
		/// Send a warning if a file or folder is being destroyed during a delete operation rather than recycled. This flag partially
		/// overrides FOF_NOCONFIRMATION.
		/// </summary>
		WantNukeWarning = FILEOP_FLAGS.FOF_WANTNUKEWARNING,

		/// <summary>Don't display any UI at all.</summary>
		NoUI = FILEOP_FLAGS.FOF_NO_UI,

		/// <summary>
		/// Walk into Shell namespace junctions. By default, junctions are not entered. For more information on junctions, see
		/// Specifying a Namespace Extension's Location.
		/// </summary>
		NoSkipJunctions = FILEOP_FLAGS.FOFX_NOSKIPJUNCTIONS,

		/// <summary>If possible, create a hard link rather than a new instance of the file in the destination.</summary>
		PreferHardLink = FILEOP_FLAGS.FOFX_PREFERHARDLINK,

		/// <summary>
		/// If an operation requires elevated rights and the FOF_NOERRORUI flag is set to disable error UI, display a UAC UI prompt nonetheless.
		/// </summary>
		ShowElevationPrompt = FILEOP_FLAGS.FOFX_SHOWELEVATIONPROMPT,

		/// <summary>
		/// Introduced in Windows 8. When a file is deleted, send it to the Recycle Bin rather than permanently deleting it.
		/// </summary>
		RecycleOnDelete = FILEOP_FLAGS.FOFX_RECYCLEONDELETE,

		/// <summary>
		/// If FOFX_EARLYFAILURE is set together with FOF_NOERRORUI, the entire set of operations is stopped upon encountering any error
		/// in any operation. This flag is valid only when FOF_NOERRORUI is set.
		/// </summary>
		EarlyFailure = FILEOP_FLAGS.FOFX_EARLYFAILURE,

		/// <summary>
		/// Rename collisions in such a way as to preserve file name extensions. This flag is valid only when FOF_RENAMEONCOLLISION is
		/// also set.
		/// </summary>
		PreserveFileExtensions = FILEOP_FLAGS.FOFX_PRESERVEFILEEXTENSIONS,

		/// <summary>
		/// Keep the newer file or folder, based on the Date Modified property, if a collision occurs. This is done automatically with
		/// no prompt UI presented to the user.
		/// </summary>
		KeepNewerFile = FILEOP_FLAGS.FOFX_KEEPNEWERFILE,

		/// <summary>Do not use copy hooks.</summary>
		NoCopyHooks = FILEOP_FLAGS.FOFX_NOCOPYHOOKS,

		/// <summary>Do not allow the progress dialog to be minimized.</summary>
		NoMinimizeBox = FILEOP_FLAGS.FOFX_NOMINIMIZEBOX,

		/// <summary>
		/// Copy the security attributes of the source item to the destination item when performing a cross-volume move operation.
		/// Without this flag, the destination item receives the security attributes of its new folder.
		/// </summary>
		MoveACLsAcrossVolumes = FILEOP_FLAGS.FOFX_MOVEACLSACROSSVOLUMES,

		/// <summary>Do not display the path of the source item in the progress dialog.</summary>
		DontDisplaySourcePath = FILEOP_FLAGS.FOFX_DONTDISPLAYSOURCEPATH,

		/// <summary>Do not display the path of the destination item in the progress dialog.</summary>
		DontDisplayDestPath = FILEOP_FLAGS.FOFX_DONTDISPLAYDESTPATH,

		/// <summary>
		/// Introduced in Windows Vista SP1. The user expects a requirement for rights elevation, so do not display a dialog box asking
		/// for a confirmation of the elevation.
		/// </summary>
		RequireElevation = FILEOP_FLAGS.FOFX_REQUIREELEVATION,

		/// <summary>
		/// Introduced in Windows 8. The file operation was user-invoked and should be placed on the undo stack. This flag is preferred
		/// to FOF_ALLOWUNDO.
		/// </summary>
		AddUndoRecord = FILEOP_FLAGS.FOFX_ADDUNDORECORD,

		/// <summary>Introduced in Windows 7. Display a Downloading instead of Copying message in the progress dialog.</summary>
		CopyAsDownload = FILEOP_FLAGS.FOFX_COPYASDOWNLOAD,

		/// <summary>Introduced in Windows 7. Do not display the location line in the progress dialog.</summary>
		DontDisplayLocations = FILEOP_FLAGS.FOFX_DONTDISPLAYLOCATIONS,
	}

	/// <summary>Used by methods of the ITransferSource and ITransferDestination interfaces to control their file operations.</summary>
	[Flags]
	public enum TransferFlags
	{
		/// <summary>Fail if the destination already exists, unless TSF_OVERWRITE_EXIST is specified. This is a default behavior.</summary>
		Normal = TRANSFER_SOURCE_FLAGS.TSF_NORMAL,

		/// <summary>Fail if the destination already exists, unless TSF_OVERWRITE_EXIST is specified. This is a default behavior</summary>
		FailExist = TRANSFER_SOURCE_FLAGS.TSF_FAIL_EXIST,

		/// <summary>Rename with auto-name generation if the destination already exists.</summary>
		RenameExist = TRANSFER_SOURCE_FLAGS.TSF_RENAME_EXIST,

		/// <summary>Overwrite or merge with the destination.</summary>
		OverwriteExist = TRANSFER_SOURCE_FLAGS.TSF_OVERWRITE_EXIST,

		/// <summary>Allow creation of a decrypted destination.</summary>
		AllowDecryption = TRANSFER_SOURCE_FLAGS.TSF_ALLOW_DECRYPTION,

		/// <summary>No discretionary access control list (DACL), system access control list (SACL), or owner.</summary>
		NoSecurity = TRANSFER_SOURCE_FLAGS.TSF_NO_SECURITY,

		/// <summary>
		/// Copy the creation time as part of the copy. This can be useful for a move operation that is being used as a copy and delete
		/// operation (TSF_MOVE_AS_COPY_DELETE).
		/// </summary>
		CopyCreationTime = TRANSFER_SOURCE_FLAGS.TSF_COPY_CREATION_TIME,

		/// <summary>Copy the last write time as part of the copy.</summary>
		CopyWriteTime = TRANSFER_SOURCE_FLAGS.TSF_COPY_WRITE_TIME,

		/// <summary>Assign write, read, and delete permissions as share mode.</summary>
		UseFullAccess = TRANSFER_SOURCE_FLAGS.TSF_USE_FULL_ACCESS,

		/// <summary>Recycle on file delete, if possible.</summary>
		DeleteRecycleIfPossible = TRANSFER_SOURCE_FLAGS.TSF_DELETE_RECYCLE_IF_POSSIBLE,

		/// <summary>Hard link to the desired source (not required). This avoids a normal copy operation.</summary>
		CopyHardLink = TRANSFER_SOURCE_FLAGS.TSF_COPY_HARD_LINK,

		/// <summary>Copy the localized name.</summary>
		CopyLocalizedName = TRANSFER_SOURCE_FLAGS.TSF_COPY_LOCALIZED_NAME,

		/// <summary>Move as a copy and delete operation.</summary>
		MoveAsCopyDelete = TRANSFER_SOURCE_FLAGS.TSF_MOVE_AS_COPY_DELETE,

		/// <summary>Suspend Shell events.</summary>
		SuspendShellEvents = TRANSFER_SOURCE_FLAGS.TSF_SUSPEND_SHELLEVENTS,
	}
}