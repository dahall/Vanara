using System.IO;

namespace Vanara.PInvoke;

public static partial class Shell32
{
	/// <summary>Flags that control the file operation.</summary>
	[PInvokeData("Shobjidl.h")]
	[Flags]
	public enum FILEOP_FLAGS : uint
	{
		/// <summary>
		/// The pTo member specifies multiple destination files (one for each source file in pFrom) rather than one directory where all
		/// source files are to be deposited.
		/// </summary>
		FOF_MULTIDESTFILES = 0x0001,

		/// <summary>Not implemented.</summary>
		[Obsolete] FOF_CONFIRMMOUSE = 0x0002,

		/// <summary>Do not display a progress dialog box.</summary>
		FOF_SILENT = 0x0004,

		/// <summary>
		/// Give the item being operated on a new name in a move, copy, or rename operation if an item with the target name already exists.
		/// </summary>
		FOF_RENAMEONCOLLISION = 0x0008,

		/// <summary>Respond with Yes to All for any dialog box that is displayed.</summary>
		FOF_NOCONFIRMATION = 0x0010,

		/// <summary>
		/// If FOF_RENAMEONCOLLISION is specified and any files were renamed, assign a name mapping object that contains their old and
		/// new names to the hNameMappings member. This object must be freed using SHFreeNameMappings when it is no longer needed.
		/// </summary>
		FOF_WANTMAPPINGHANDLE = 0x0020,

		/// <summary>
		/// Preserve undo information, if possible.
		/// <para>Prior to Windows Vista, operations could be undone only from the same process that performed the original operation.</para>
		/// <para>
		/// In Windows Vista and later systems, the scope of the undo is a user session. Any process running in the user session can undo
		/// another operation. The undo state is held in the Explorer.exe process, and as long as that process is running, it can
		/// coordinate the undo functions.
		/// </para>
		/// <para>If the source file parameter does not contain fully qualified path and file names, this flag is ignored.</para>
		/// </summary>
		FOF_ALLOWUNDO = 0x0040,

		/// <summary>Perform the operation only on files (not on folders) if a wildcard file name (*.*) is specified.</summary>
		FOF_FILESONLY = 0x0080,

		/// <summary>Display a progress dialog box but do not show individual file names as they are operated on.</summary>
		FOF_SIMPLEPROGRESS = 0x0100,

		/// <summary>Do not confirm the creation of a new folder if the operation requires one to be created.</summary>
		FOF_NOCONFIRMMKDIR = 0x0200,

		/// <summary>
		/// Do not display a message to the user if an error occurs. If this flag is set without FOFX_EARLYFAILURE, any error is treated
		/// as if the user had chosen Ignore or Continue in a dialog box. It halts the current action, sets a flag to indicate that an
		/// action was aborted, and proceeds with the rest of the operation.
		/// </summary>
		FOF_NOERRORUI = 0x0400,

		/// <summary>Do not copy the security attributes of the item.</summary>
		FOF_NOCOPYSECURITYATTRIBS = 0x0800,

		/// <summary>Only operate in the local folder. Do not operate recursively into subdirectories.</summary>
		FOF_NORECURSION = 0x1000,

		/// <summary>Do not move connected items as a group. Only move the specified files.</summary>
		FOF_NO_CONNECTED_ELEMENTS = 0x2000,

		/// <summary>
		/// Send a warning if a file or folder is being destroyed during a delete operation rather than recycled. This flag partially
		/// overrides FOF_NOCONFIRMATION.
		/// </summary>
		FOF_WANTNUKEWARNING = 0x4000,

		/// <summary>Deprecated.</summary>
		FOF_NORECURSEREPARSE = 0x8000,

		/// <summary>Don't display any UI at all.</summary>
		FOF_NO_UI = FOF_SILENT | FOF_NOCONFIRMATION | FOF_NOERRORUI | FOF_NOCONFIRMMKDIR,

		/// <summary>
		/// Walk into Shell namespace junctions. By default, junctions are not entered. For more information on junctions, see Specifying
		/// a Namespace Extension's Location.
		/// </summary>
		FOFX_NOSKIPJUNCTIONS = 0x00010000,

		/// <summary>If possible, create a hard link rather than a new instance of the file in the destination.</summary>
		FOFX_PREFERHARDLINK = 0x00020000,

		/// <summary>
		/// If an operation requires elevated rights and the FOF_NOERRORUI flag is set to disable error UI, display a UAC UI prompt nonetheless.
		/// </summary>
		FOFX_SHOWELEVATIONPROMPT = 0x00040000,

		/// <summary>
		/// Introduced in Windows 8. When a file is deleted, send it to the Recycle Bin rather than permanently deleting it.
		/// </summary>
		FOFX_RECYCLEONDELETE = 0x00080000,

		/// <summary>
		/// If FOFX_EARLYFAILURE is set together with FOF_NOERRORUI, the entire set of operations is stopped upon encountering any error
		/// in any operation. This flag is valid only when FOF_NOERRORUI is set.
		/// </summary>
		FOFX_EARLYFAILURE = 0x00100000,

		/// <summary>
		/// Rename collisions in such a way as to preserve file name extensions. This flag is valid only when FOF_RENAMEONCOLLISION is
		/// also set.
		/// </summary>
		FOFX_PRESERVEFILEEXTENSIONS = 0x00200000,

		/// <summary>
		/// Keep the newer file or folder, based on the Date Modified property, if a collision occurs. This is done automatically with no
		/// prompt UI presented to the user.
		/// </summary>
		FOFX_KEEPNEWERFILE = 0x00400000,

		/// <summary>Do not use copy hooks.</summary>
		FOFX_NOCOPYHOOKS = 0x00800000,

		/// <summary>Do not allow the progress dialog to be minimized.</summary>
		FOFX_NOMINIMIZEBOX = 0x01000000,

		/// <summary>
		/// Copy the security attributes of the source item to the destination item when performing a cross-volume move operation.
		/// Without this flag, the destination item receives the security attributes of its new folder.
		/// </summary>
		FOFX_MOVEACLSACROSSVOLUMES = 0x02000000,

		/// <summary>Do not display the path of the source item in the progress dialog.</summary>
		FOFX_DONTDISPLAYSOURCEPATH = 0x04000000,

		/// <summary>Do not display the path of the destination item in the progress dialog.</summary>
		FOFX_DONTDISPLAYDESTPATH = 0x08000000,

		/// <summary>
		/// Introduced in Windows Vista SP1. The user expects a requirement for rights elevation, so do not display a dialog box asking
		/// for a confirmation of the elevation.
		/// </summary>
		FOFX_REQUIREELEVATION = 0x10000000,

		/// <summary>
		/// Introduced in Windows 8. The file operation was user-invoked and should be placed on the undo stack. This flag is preferred
		/// to FOF_ALLOWUNDO.
		/// </summary>
		FOFX_ADDUNDORECORD = 0x20000000,

		/// <summary>Introduced in Windows 7. Display a Downloading instead of Copying message in the progress dialog.</summary>
		FOFX_COPYASDOWNLOAD = 0x40000000,

		/// <summary>Introduced in Windows 7. Do not display the location line in the progress dialog.</summary>
		FOFX_DONTDISPLAYLOCATIONS = 0x80000000,
	}

	/// <summary>
	/// Exposes methods to copy, move, rename, create, and delete Shell items as well as methods to provide progress and error dialogs.
	/// This interface replaces the SHFileOperation function.
	/// </summary>
	[PInvokeData("Shobjidl.h")]
	[ComImport, Guid("947aab5f-0a5c-4c13-b4d6-4bf7836fc9f8"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown), CoClass(typeof(CFileOperations))]
	public interface IFileOperation
	{
		/// <summary>Enables a handler to provide status and error information for all operations.</summary>
		/// <param name="pfops">Pointer to an IFileOperationProgressSink object to be used for progress status and error notifications.</param>
		/// <returns>
		/// When this method returns, this parameter points to a returned token that uniquely identifies this connection. The calling
		/// application uses this token later to delete the connection by passing it to IFileOperation::Unadvise. If the call to Advise
		/// fails, this value is meaningless.
		/// </returns>
		uint Advise(IFileOperationProgressSink pfops);

		/// <summary>Terminates an advisory connection previously established through IFileOperation::Advise.</summary>
		/// <param name="dwCookie">
		/// The connection token that identifies the connection to delete. This value was originally retrieved by Advise when the
		/// connection was made.
		/// </param>
		void Unadvise(uint dwCookie);

		/// <summary>Sets parameters for the current operation.</summary>
		/// <param name="dwOperationFlags">
		/// Flags that control the file operation. This member can be a combination of the following flags. FOF flags are defined in
		/// Shellapi.h and FOFX flags are defined in Shobjidl.h.
		/// </param>
		void SetOperationFlags(FILEOP_FLAGS dwOperationFlags);

		/// <summary>This method is not implemented.</summary>
		/// <param name="pszMessage">The message.</param>
		[Obsolete]
		void SetProgressMessage([MarshalAs(UnmanagedType.LPWStr)] string pszMessage);

		/// <summary>Specifies a dialog box used to display the progress of the operation.</summary>
		/// <param name="popd">Pointer to an IOperationsProgressDialog object that represents the dialog box.</param>
		void SetProgressDialog(IOperationsProgressDialog popd);

		/// <summary>Declares a set of properties and values to be set on an item or items.</summary>
		/// <param name="pproparray">
		/// Pointer to an IPropertyChangeArray, which accesses a collection of IPropertyChange objects that specify the properties to be
		/// set and their new values.
		/// </param>
		void SetProperties(PropSys.IPropertyChangeArray pproparray);

		/// <summary>Sets the parent or owner window for progress and dialog windows.</summary>
		/// <param name="hwndParent">A handle to the owner window of the operation. This window will receive error messages.</param>
		void SetOwnerWindow(HWND hwndParent);

		/// <summary>Declares a single item whose property values are to be set.</summary>
		/// <param name="psiItem">Pointer to the item to receive the new property values.</param>
		void ApplyPropertiesToItem(IShellItem psiItem);

		/// <summary>Declares a set of items for which to apply a common set of property values.</summary>
		/// <param name="punkItems">
		/// Pointer to the IUnknown of the IShellItemArray, IDataObject, or IEnumShellItems object which represents the group of items.
		/// You can also point to an IPersistIDList object to represent a single item, effectively accomplishing the same function as IFileOperation::ApplyPropertiesToItem.
		/// </param>
		void ApplyPropertiesToItems([MarshalAs(UnmanagedType.IUnknown)] object punkItems);

		/// <summary>Declares a single item that is to be given a new display name.</summary>
		/// <param name="psiItem">Pointer to an IShellItem that specifies the source item.</param>
		/// <param name="pszNewName">Pointer to the new display name of the item. This is a null-terminated, Unicode string.</param>
		/// <param name="pfopsItem">
		/// Pointer to an IFileOperationProgressSink object to be used for status and failure notifications. If you call
		/// IFileOperation::Advise for the overall operation, progress status and error notifications for the rename operation are
		/// included there, so set this parameter to NULL.
		/// </param>
		void RenameItem(IShellItem psiItem, [MarshalAs(UnmanagedType.LPWStr)] string pszNewName, [Optional] IFileOperationProgressSink? pfopsItem);

		/// <summary>Declares a set of items that are to be given a new display name. All items are given the same name.</summary>
		/// <param name="pUnkItems">
		/// Pointer to the IUnknown of the IShellItemArray, IDataObject, or IEnumShellItems object which represents the group of items to
		/// be renamed. You can also point to an IPersistIDList object to represent a single item, effectively accomplishing the same
		/// function as IFileOperation::RenameItem.
		/// </param>
		/// <param name="pszNewName">Pointer to the new display name of the items. This is a null-terminated, Unicode string.</param>
		void RenameItems([MarshalAs(UnmanagedType.IUnknown)] object pUnkItems, [MarshalAs(UnmanagedType.LPWStr)] string pszNewName);

		/// <summary>Declares a single item that is to be moved to a specified destination.</summary>
		/// <param name="psiItem">Pointer to an IShellItem that specifies the source item.</param>
		/// <param name="psiDestinationFolder">
		/// Pointer to an IShellItem that specifies the destination folder to contain the moved item.
		/// </param>
		/// <param name="pszNewName">
		/// Pointer to a new name for the item in its new location. This is a null-terminated Unicode string and can be NULL. If NULL,
		/// the name of the destination item is the same as the source.
		/// </param>
		/// <param name="pfopsItem">
		/// Pointer to an IFileOperationProgressSink object to be used for progress status and error notifications for this specific move
		/// operation. If you call IFileOperation::Advise for the overall operation, progress status and error notifications for the move
		/// operation are included there, so set this parameter to NULL.
		/// </param>
		void MoveItem(IShellItem psiItem, IShellItem psiDestinationFolder, [MarshalAs(UnmanagedType.LPWStr)] string? pszNewName, [Optional] IFileOperationProgressSink? pfopsItem);

		/// <summary>Declares a set of items that are to be moved to a specified destination.</summary>
		/// <param name="punkItems">
		/// Pointer to the IUnknown of the IShellItemArray, IDataObject, or IEnumShellItems object which represents the group of items to
		/// be moved. You can also point to an IPersistIDList object to represent a single item, effectively accomplishing the same
		/// function as IFileOperation::MoveItem.
		/// </param>
		/// <param name="psiDestinationFolder">
		/// Pointer to an IShellItem that specifies the destination folder to contain the moved items.
		/// </param>
		void MoveItems([MarshalAs(UnmanagedType.IUnknown)] object punkItems, IShellItem psiDestinationFolder);

		/// <summary>Declares a single item that is to be copied to a specified destination.</summary>
		/// <param name="psiItem">Pointer to an IShellItem that specifies the source item.</param>
		/// <param name="psiDestinationFolder">
		/// Pointer to an IShellItem that specifies the destination folder to contain the copy of the item.
		/// </param>
		/// <param name="pszCopyName">
		/// Pointer to a new name for the item after it has been copied. This is a null-terminated Unicode string and can be NULL. If
		/// NULL, the name of the destination item is the same as the source.
		/// </param>
		/// <param name="pfopsItem">
		/// Pointer to an IFileOperationProgressSink object to be used for progress status and error notifications for this specific copy
		/// operation. If you call IFileOperation::Advise for the overall operation, progress status and error notifications for the copy
		/// operation are included there, so set this parameter to NULL.
		/// </param>
		void CopyItem(IShellItem psiItem, IShellItem psiDestinationFolder, [MarshalAs(UnmanagedType.LPWStr)] string? pszCopyName, [Optional] IFileOperationProgressSink? pfopsItem);

		/// <summary>Declares a set of items that are to be copied to a specified destination.</summary>
		/// <param name="punkItems">
		/// Pointer to the IUnknown of the IShellItemArray, IDataObject, or IEnumShellItems object which represents the group of items to
		/// be copied. You can also point to an IPersistIDList object to represent a single item, effectively accomplishing the same
		/// function as IFileOperation::CopyItem.
		/// </param>
		/// <param name="psiDestinationFolder">
		/// Pointer to an IShellItem that specifies the destination folder to contain the copy of the items.
		/// </param>
		void CopyItems([MarshalAs(UnmanagedType.Interface)] object punkItems, IShellItem psiDestinationFolder);

		/// <summary>Declares a single item that is to be deleted.</summary>
		/// <param name="psiItem">Pointer to an IShellItem that specifies the item to be deleted.</param>
		/// <param name="pfopsItem">
		/// Pointer to an IFileOperationProgressSink object to be used for progress status and error notifications for this specific
		/// delete operation. If you call IFileOperation::Advise for the overall operation, progress status and error notifications for
		/// the delete operation are included there, so set this parameter to NULL.
		/// </param>
		void DeleteItem(IShellItem psiItem, [Optional] IFileOperationProgressSink? pfopsItem);

		/// <summary>Declares a set of items that are to be deleted.</summary>
		/// <param name="punkItems">
		/// Pointer to the IUnknown of the IShellItemArray, IDataObject, or IEnumShellItems object which represents the group of items to
		/// be deleted. You can also point to an IPersistIDList object to represent a single item, effectively accomplishing the same
		/// function as IFileOperation::DeleteItem.
		/// </param>
		void DeleteItems([MarshalAs(UnmanagedType.IUnknown)] object punkItems);

		/// <summary>Declares a new item that is to be created in a specified location.</summary>
		/// <param name="psiDestinationFolder">
		/// Pointer to an IShellItem that specifies the destination folder that will contain the new item.
		/// </param>
		/// <param name="dwFileAttributes">
		/// A bitwise value that specifies the file system attributes for the file or folder. See GetFileAttributes for possible values.
		/// </param>
		/// <param name="pszName">
		/// Pointer to the file name of the new item, for instance Newfile.txt. This is a null-terminated, Unicode string.
		/// </param>
		/// <param name="pszTemplateName">
		/// Pointer to the name of the template file (for example Excel9.xls) that the new item is based on, stored in one of the
		/// following locations:
		/// <list type="bullet">
		/// <item>
		/// <description>CSIDL_COMMON_TEMPLATES. The default path for this folder is %ALLUSERSPROFILE%\Templates.</description>
		/// </item>
		/// <item>
		/// <description>CSIDL_TEMPLATES. The default path for this folder is %USERPROFILE%\Templates.</description>
		/// </item>
		/// <item>
		/// <description>%SystemRoot%\shellnew</description>
		/// </item>
		/// </list>
		/// <para>
		/// This is a null-terminated, Unicode string used to specify an existing file of the same type as the new file, containing the
		/// minimal content that an application wants to include in any new file.
		/// </para>
		/// <para>This parameter is normally NULL to specify a new, blank file.</para>
		/// </param>
		/// <param name="pfopsItem">
		/// Pointer to an IFileOperationProgressSink object to be used for status and failure notifications. If you call
		/// IFileOperation::Advise for the overall operation, progress status and error notifications for the creation operation are
		/// included there, so set this parameter to NULL.
		/// </param>
		void NewItem(IShellItem psiDestinationFolder, FileAttributes dwFileAttributes,
			[MarshalAs(UnmanagedType.LPWStr)] string pszName, [MarshalAs(UnmanagedType.LPWStr)] string? pszTemplateName,
			[Optional] IFileOperationProgressSink? pfopsItem);

		/// <summary>Executes all selected operations.</summary>
		/// <remarks>
		/// This method is called last to execute those actions that have been specified earlier by calling their individual methods. For
		/// instance, RenameItem does not rename the item, it simply sets the parameters. The actual renaming is done when you call PerformOperations.
		/// </remarks>
		void PerformOperations();

		/// <summary>
		/// Gets a value that states whether any file operations initiated by a call to IFileOperation::PerformOperations were stopped
		/// before they were complete. The operations could be stopped either by user action or silently by the system.
		/// </summary>
		/// <returns>
		/// When this method returns, points to TRUE if any file operations were aborted before they were complete; otherwise, FALSE.
		/// </returns>
		[return: MarshalAs(UnmanagedType.Bool)]
		bool GetAnyOperationsAborted();
	}

	/// <summary>CLSID_FileOperations</summary>
	[ComImport, Guid("3ad05575-8857-4850-9277-11b85bdb8e09"), ClassInterface(ClassInterfaceType.None)]
	public class CFileOperations { }
}