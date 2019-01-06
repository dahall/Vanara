using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Vanara.Collections;
using Vanara.InteropServices;
using Vanara.PInvoke;
using static Vanara.PInvoke.Ole32;
using static Vanara.PInvoke.PropSys;
using static Vanara.PInvoke.Shell32;

namespace Vanara.Windows.Shell
{
	/// <summary>Queued and static file operations using the Shell.</summary>
	/// <seealso cref="System.IDisposable"/>
	public class ShellFileOperations : IDisposable
	{
		private const OperationFlags defaultOptions = OperationFlags.AllowUndo | OperationFlags.NoConfirmMkDir;
		private bool disposedValue = false;
		private IFileOperation op;
		private OperationFlags opFlags = defaultOptions;
		private IFileOperationProgressSink sink;
		private uint sinkCookie;

		/// <summary>Initializes a new instance of the <see cref="ShellFileOperations"/> class.</summary>
		/// <param name="owner">The window that owns the modal dialog. This value can be <see langword="null"/>.</param>
		public ShellFileOperations(System.Windows.Forms.IWin32Window owner = null)
		{
			op = new IFileOperation();
			if (owner != null) op.SetOwnerWindow(owner.Handle);
			sink = new OpSink(this);
			sinkCookie = op.Advise(sink);
		}

		/// <summary>Finalizes an instance of the <see cref="ShellFileOperations"/> class.</summary>
		~ShellFileOperations()
		{
			Dispose(false);
		}

		/// <summary>Performs caller-implemented actions after the last operation performed by the call to IFileOperation is complete.</summary>
		public event EventHandler<ShellFileOpEventArgs> FinishOperations;

		/// <summary>Performs caller-implemented actions after the copy process for each item is complete.</summary>
		public event EventHandler<ShellFileOpEventArgs> PostCopyItem;

		/// <summary>Performs caller-implemented actions after the delete process for each item is complete.</summary>
		public event EventHandler<ShellFileOpEventArgs> PostDeleteItem;

		/// <summary>Performs caller-implemented actions after the move process for each item is complete.</summary>
		public event EventHandler<ShellFileOpEventArgs> PostMoveItem;

		/// <summary>Performs caller-implemented actions after the new item is created.</summary>
		public event EventHandler<ShellFileNewOpEventArgs> PostNewItem;

		/// <summary>Performs caller-implemented actions after the rename process for each item is complete.</summary>
		public event EventHandler<ShellFileOpEventArgs> PostRenameItem;

		/// <summary>Performs caller-implemented actions before the copy process for each item begins.</summary>
		public event EventHandler<ShellFileOpEventArgs> PreCopyItem;

		/// <summary>Performs caller-implemented actions before the delete process for each item begins.</summary>
		public event EventHandler<ShellFileOpEventArgs> PreDeleteItem;

		/// <summary>Performs caller-implemented actions before the move process for each item begins.</summary>
		public event EventHandler<ShellFileOpEventArgs> PreMoveItem;

		/// <summary>Performs caller-implemented actions before the process to create a new item begins.</summary>
		public event EventHandler<ShellFileOpEventArgs> PreNewItem;

		/// <summary>Performs caller-implemented actions before the rename process for each item begins.</summary>
		public event EventHandler<ShellFileOpEventArgs> PreRenameItem;

		/// <summary>Performs caller-implemented actions before any specific file operations are performed.</summary>
		public event EventHandler StartOperations;

		/// <summary>Updates the progress.</summary>
		public event System.ComponentModel.ProgressChangedEventHandler UpdateProgress;

		/// <summary>Flags that control the file operation.</summary>
		[Flags]
		public enum OperationFlags : uint
		{
			/// <summary>
			/// The pTo member specifies multiple destination files (one for each source file in pFrom) rather than one directory where all source files are to
			/// be deposited.
			/// </summary>
			MultiDestFiles = FILEOP_FLAGS.FOF_MULTIDESTFILES,
			/// <summary>Do not display a progress dialog box.</summary>
			Silent = FILEOP_FLAGS.FOF_SILENT,
			/// <summary>Give the item being operated on a new name in a move, copy, or rename operation if an item with the target name already exists.</summary>
			RenameOnCollision = FILEOP_FLAGS.FOF_RENAMEONCOLLISION,
			/// <summary>Respond with Yes to All for any dialog box that is displayed.</summary>
			NoConfirmation = FILEOP_FLAGS.FOF_NOCONFIRMATION,
			/// <summary>
			/// If FOF_RENAMEONCOLLISION is specified and any files were renamed, assign a name mapping object that contains their old and new names to the
			/// hNameMappings member. This object must be freed using SHFreeNameMappings when it is no longer needed.
			/// </summary>
			WantMappingHandle = FILEOP_FLAGS.FOF_WANTMAPPINGHANDLE,
			/// <summary>
			/// Preserve undo information, if possible.
			/// <para>Prior to Windows Vista, operations could be undone only from the same process that performed the original operation.</para>
			/// <para>
			/// In Windows Vista and later systems, the scope of the undo is a user session. Any process running in the user session can undo another operation.
			/// The undo state is held in the Explorer.exe process, and as long as that process is running, it can coordinate the undo functions.
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
			/// Do not display a message to the user if an error occurs. If this flag is set without FOFX_EARLYFAILURE, any error is treated as if the user had
			/// chosen Ignore or Continue in a dialog box. It halts the current action, sets a flag to indicate that an action was aborted, and proceeds with the
			/// rest of the operation.
			/// </summary>
			NoErrorUI = FILEOP_FLAGS.FOF_NOERRORUI,
			/// <summary>Do not copy the security attributes of the item.</summary>
			NoCopySecurityAttribs = FILEOP_FLAGS.FOF_NOCOPYSECURITYATTRIBS,
			/// <summary>Only operate in the local folder. Do not operate recursively into subdirectories.</summary>
			NoRecursion = FILEOP_FLAGS.FOF_NORECURSION,
			/// <summary>Do not move connected items as a group. Only move the specified files.</summary>
			NoConnectedElements = FILEOP_FLAGS.FOF_NO_CONNECTED_ELEMENTS,
			/// <summary>
			/// Send a warning if a file or folder is being destroyed during a delete operation rather than recycled. This flag partially overrides FOF_NOCONFIRMATION.
			/// </summary>
			WantNukeWarning = FILEOP_FLAGS.FOF_WANTNUKEWARNING,
			/// <summary>
			/// Walk into Shell namespace junctions. By default, junctions are not entered. For more information on junctions, see Specifying a Namespace
			/// Extension's Location.
			/// </summary>
			NoSkipJunctions = FILEOP_FLAGS.FOFX_NOSKIPJUNCTIONS,
			/// <summary>If possible, create a hard link rather than a new instance of the file in the destination.</summary>
			PreferHardLink = FILEOP_FLAGS.FOFX_PREFERHARDLINK,
			/// <summary>If an operation requires elevated rights and the FOF_NOERRORUI flag is set to disable error UI, display a UAC UI prompt nonetheless.</summary>
			ShowElevationPrompt = FILEOP_FLAGS.FOFX_SHOWELEVATIONPROMPT,
			/// <summary>
			/// If FOFX_EARLYFAILURE is set together with FOF_NOERRORUI, the entire set of operations is stopped upon encountering any error in any operation.
			/// This flag is valid only when FOF_NOERRORUI is set.
			/// </summary>
			EarlyFailure = FILEOP_FLAGS.FOFX_EARLYFAILURE,
			/// <summary>
			/// Rename collisions in such a way as to preserve file name extensions. This flag is valid only when FOF_RENAMEONCOLLISION is also set.
			/// </summary>
			PreserveFileExtensions = FILEOP_FLAGS.FOFX_PRESERVEFILEEXTENSIONS,
			/// <summary>
			/// Keep the newer file or folder, based on the Date Modified property, if a collision occurs. This is done automatically with no prompt UI presented
			/// to the user.
			/// </summary>
			KeepNewerFile = FILEOP_FLAGS.FOFX_KEEPNEWERFILE,
			/// <summary>Do not use copy hooks.</summary>
			NoCopyHooks = FILEOP_FLAGS.FOFX_NOCOPYHOOKS,
			/// <summary>Do not allow the progress dialog to be minimized.</summary>
			NoMinimizeBox = FILEOP_FLAGS.FOFX_NOMINIMIZEBOX,
			/// <summary>
			/// Copy the security attributes of the source item to the destination item when performing a cross-volume move operation. Without this flag, the
			/// destination item receives the security attributes of its new folder.
			/// </summary>
			MoveACLsAcrossVolumes = FILEOP_FLAGS.FOFX_MOVEACLSACROSSVOLUMES,
			/// <summary>Do not display the path of the source item in the progress dialog.</summary>
			DontDisplaySourcePath = FILEOP_FLAGS.FOFX_DONTDISPLAYSOURCEPATH,
			/// <summary>Do not display the path of the destination item in the progress dialog.</summary>
			DontDisplayDestPath = FILEOP_FLAGS.FOFX_DONTDISPLAYDESTPATH,
			/// <summary>
			/// Introduced in Windows Vista SP1. The user expects a requirement for rights elevation, so do not display a dialog box asking for a confirmation of
			/// the elevation.
			/// </summary>
			RequireElevation = FILEOP_FLAGS.FOFX_REQUIREELEVATION,
			/// <summary>Introduced in Windows 8. The file operation was user-invoked and should be placed on the undo stack. This flag is preferred to FOF_ALLOWUNDO.</summary>
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
			/// Copy the creation time as part of the copy. This can be useful for a move operation that is being used as a copy and delete operation (TSF_MOVE_AS_COPY_DELETE).
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

		/// <summary>Gets or sets options that control file operations.</summary>
		public OperationFlags Options
		{
			get => opFlags;
			set { if (value == opFlags) return; op.SetOperationFlags((FILEOP_FLAGS)value); opFlags = value; }
		}

		public int QueuedOperations { get; protected set; }

		// TODO: public Form CustomProgressDialog { get; set; }

		/// <summary>Copies a single item to a specified destination using the Shell to provide progress and error dialogs.</summary>
		/// <param name="source">A <see cref="ShellItem"/> that specifies the source item.</param>
		/// <param name="dest">A <see cref="ShellFolder"/> that specifies the destination folder to contain the copy of the item.</param>
		/// <param name="newName">
		/// An optional new name for the item after it has been copied. This can be <see langword="null"/>. If <see langword="null"/>, the name of the
		/// destination item is the same as the source.
		/// </param>
		/// <param name="options">Options that control file operations.</param>
		public static void Copy(ShellItem source, ShellFolder dest, string newName = null, OperationFlags options = defaultOptions)
		{
			using (var sop = new ShellFileOperations())
			{
				sop.Options = options;
				HRESULT hr = HRESULT.S_OK;
				sop.PostCopyItem += OnPost;
				try
				{
					sop.QueueCopyOperation(source, dest, newName);
					sop.PerformOperations();
					hr.ThrowIfFailed();
				}
				finally
				{
					sop.PostCopyItem -= OnPost;
				}

				void OnPost(object sender, ShellFileOpEventArgs e) => hr = e.Result;
			}
		}

		/// <summary>Copies a set of items to a specified destination using the Shell to provide progress and error dialogs.</summary>
		/// <param name="sourceItems">An <see cref="IEnumerable{T}"/> of <see cref="ShellItem"/> instances that represent the group of items to be copied.</param>
		/// <param name="dest">A <see cref="ShellFolder"/> that specifies the destination folder to contain the copy of the items.</param>
		/// <param name="options">Options that control file operations.</param>
		public static void Copy(IEnumerable<ShellItem> sourceItems, ShellFolder dest, OperationFlags options = defaultOptions)
		{
			using (var sop = new ShellFileOperations())
			{
				sop.Options = options;
				HRESULT hr = HRESULT.S_OK;
				sop.PostCopyItem += OnPost;
				try
				{
					sop.QueueCopyOperation(sourceItems, dest);
					sop.PerformOperations();
					hr.ThrowIfFailed();
				}
				finally
				{
					sop.PostCopyItem -= OnPost;
				}

				void OnPost(object sender, ShellFileOpEventArgs e) => hr = e.Result;
			}
		}

		/// <summary>Deletes a single item using the Shell to provide progress and error dialogs.</summary>
		/// <param name="source">A <see cref="ShellItem"/> that specifies the item to be deleted.</param>
		/// <param name="options">Options that control file operations.</param>
		public static void Delete(ShellItem source, OperationFlags options = defaultOptions)
		{
			using (var sop = new ShellFileOperations())
			{
				sop.Options = options;
				HRESULT hr = HRESULT.S_OK;
				sop.PostDeleteItem += OnPost;
				try
				{
					sop.QueueDeleteOperation(source);
					sop.PerformOperations();
					hr.ThrowIfFailed();
				}
				finally
				{
					sop.PostDeleteItem -= OnPost;
				}

				void OnPost(object sender, ShellFileOpEventArgs e) => hr = e.Result;
			}
		}

		/// <summary>Deletes a set of items using the Shell to provide progress and error dialogs.</summary>
		/// <param name="sourceItems">An <see cref="IEnumerable{T}"/> of <see cref="ShellItem"/> instances which represents the group of items to be deleted.</param>
		/// <param name="options">Options that control file operations.</param>
		public static void Delete(IEnumerable<ShellItem> sourceItems, OperationFlags options = defaultOptions)
		{
			using (var sop = new ShellFileOperations())
			{
				sop.Options = options;
				HRESULT hr = HRESULT.S_OK;
				sop.PostDeleteItem += OnPost;
				try
				{
					sop.QueueDeleteOperation(sourceItems);
					sop.PerformOperations();
					hr.ThrowIfFailed();
				}
				finally
				{
					sop.PostDeleteItem -= OnPost;
				}

				void OnPost(object sender, ShellFileOpEventArgs e) => hr = e.Result;
			}
		}

		/// <summary>Moves a single item to a specified destination using the Shell to provide progress and error dialogs.</summary>
		/// <param name="source">A <see cref="ShellItem"/> that specifies the source item.</param>
		/// <param name="dest">A <see cref="ShellFolder"/> that specifies the destination folder to contain the moved item.</param>
		/// <param name="newName">
		/// An optional new name for the item in its new location. This can be <see langword="null"/>. If <see langword="null"/>, the name of the destination
		/// item is the same as the source.
		/// </param>
		/// <param name="options">Options that control file operations.</param>
		public static void Move(ShellItem source, ShellFolder dest, string newName = null, OperationFlags options = defaultOptions)
		{
			using (var sop = new ShellFileOperations())
			{
				sop.Options = options;
				HRESULT hr = HRESULT.S_OK;
				sop.PostMoveItem += OnPost;
				try
				{
					sop.QueueMoveOperation(source, dest, newName);
					sop.PerformOperations();
					hr.ThrowIfFailed();
				}
				finally
				{
					sop.PostMoveItem -= OnPost;
				}

				void OnPost(object sender, ShellFileOpEventArgs e) => hr = e.Result;
			}
		}

		/// <summary>Moves a set of items to a specified destination using the Shell to provide progress and error dialogs.</summary>
		/// <param name="sourceItems">An <see cref="IEnumerable{T}"/> of <see cref="ShellItem"/> instances which represents the group of items to be moved.</param>
		/// <param name="dest">A <see cref="ShellFolder"/> that specifies the destination folder to contain the moved items.</param>
		/// <param name="options">Options that control file operations.</param>
		public static void Move(IEnumerable<ShellItem> sourceItems, ShellFolder dest, OperationFlags options = defaultOptions)
		{
			using (var sop = new ShellFileOperations())
			{
				sop.Options = options;
				HRESULT hr = HRESULT.S_OK;
				sop.PostMoveItem += OnPost;
				try
				{
					sop.QueueMoveOperation(sourceItems, dest);
					sop.PerformOperations();
					hr.ThrowIfFailed();
				}
				finally
				{
					sop.PostMoveItem -= OnPost;
				}

				void OnPost(object sender, ShellFileOpEventArgs e) => hr = e.Result;
			}
		}

		/// <summary>Creates a new item in a specified location using the Shell to provide progress and error dialogs.</summary>
		/// <param name="dest">A <see cref="ShellItem"/> that specifies the destination folder that will contain the new item.</param>
		/// <param name="name">The file name of the new item, for instance Newfile.txt.</param>
		/// <param name="attr">A value that specifies the file system attributes for the file or folder.</param>
		/// <param name="template">
		/// The name of the template file (for example Excel9.xls) that the new item is based on, stored in one of the following locations:
		/// <list type="bullet">
		/// <item><description>CSIDL_COMMON_TEMPLATES. The default path for this folder is %ALLUSERSPROFILE%\Templates.</description></item>
		/// <item><description>CSIDL_TEMPLATES. The default path for this folder is %USERPROFILE%\Templates.</description></item>
		/// <item><description>%SystemRoot%\shellnew</description></item>
		/// </list>
		/// <para>
		/// This is a string used to specify an existing file of the same type as the new file, containing the minimal content that an application wants to
		/// include in any new file.
		/// </para>
		/// <para>This parameter is normally <see langword="null"/> to specify a new, blank file.</para>
		/// </param>
		/// <param name="options">Options that control file operations.</param>
		public static void NewItem(ShellFolder dest, string name, System.IO.FileAttributes attr = System.IO.FileAttributes.Normal, string template = null, OperationFlags options = defaultOptions)
		{
			using (var sop = new ShellFileOperations())
			{
				sop.Options = options;
				HRESULT hr = HRESULT.S_OK;
				sop.PostNewItem += OnPost;
				try
				{
					sop.QueueNewItemOperation(dest, name, attr, template);
					sop.PerformOperations();
					hr.ThrowIfFailed();
				}
				finally
				{
					sop.PostRenameItem -= OnPost;
				}

				void OnPost(object sender, ShellFileOpEventArgs e) => hr = e.Result;
			}
		}

		/// <summary>Renames a single item to a new display name using the Shell to provide progress and error dialogs.</summary>
		/// <param name="source">A <see cref="ShellItem"/> that specifies the source item.</param>
		/// <param name="newName">The new display name of the item.</param>
		/// <param name="options">Options that control file operations.</param>
		public static void Rename(ShellItem source, string newName = null, OperationFlags options = defaultOptions)
		{
			using (var sop = new ShellFileOperations())
			{
				sop.Options = options;
				HRESULT hr = HRESULT.S_OK;
				sop.PostRenameItem += OnPost;
				try
				{
					sop.QueueRenameOperation(source, newName);
					sop.PerformOperations();
					hr.ThrowIfFailed();
				}
				finally
				{
					sop.PostRenameItem -= OnPost;
				}

				void OnPost(object sender, ShellFileOpEventArgs e) => hr = e.Result;
			}
		}

		/// <summary>
		/// Renames a set of items that are to be given a new display name using the Shell to provide progress and error dialogs. All items are given the same name.
		/// </summary>
		/// <param name="sourceItems">An <see cref="IEnumerable{T}"/> of <see cref="ShellItem"/> instances which represents the group of items to be renamed.</param>
		/// <param name="newName">The new display name of the items.</param>
		/// <param name="options">Options that control file operations.</param>
		public static void Rename(IEnumerable<ShellItem> sourceItems, string newName, OperationFlags options = defaultOptions)
		{
			using (var sop = new ShellFileOperations())
			{
				sop.Options = options;
				HRESULT hr = HRESULT.S_OK;
				sop.PostRenameItem += OnPost;
				try
				{
					sop.QueueRenameOperation(sourceItems, newName);
					sop.PerformOperations();
					hr.ThrowIfFailed();
				}
				finally
				{
					sop.PostRenameItem -= OnPost;
				}

				void OnPost(object sender, ShellFileOpEventArgs e) => hr = e.Result;
			}
		}

		/// <summary>Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.</summary>
		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		/// <summary>Executes all selected operations.</summary>
		/// <remarks>
		/// This method is called last to execute those actions that have been specified earlier by calling their individual methods. For instance,
		/// <see cref="QueueRenameOperation(ShellItem, string)"/> does not rename the item, it simply sets the parameters. The actual renaming is done when you
		/// call PerformOperations.
		/// </remarks>
		public void PerformOperations()
		{
			op.PerformOperations();
			QueuedOperations = 0;
		}

		/// <summary>Declares a set of properties and values to be set on an item.</summary>
		/// <param name="item">The item to receive the new property values.</param>
		/// <param name="props">
		/// An <see cref="ShellItemPropertyUpdates"/>, which contains a dictionary of objects that specify the properties to be set and their new values.
		/// </param>
		public void QueueApplyPropertiesOperation(ShellItem item, ShellItemPropertyUpdates props)
		{
			op.SetProperties(props.IPropertyChangeArray);
			op.ApplyPropertiesToItem(item.IShellItem);
			QueuedOperations++;
		}

		/// <summary>Declares a set of properties and values to be set on a set of items.</summary>
		/// <param name="items">
		/// An <see cref="IEnumerable{T}"/> of <see cref="ShellItem"/> instances that represent the group of items to which to apply the properties.
		/// </param>
		/// <param name="props">
		/// An <see cref="ShellItemPropertyUpdates"/>, which contains a dictionary of objects that specify the properties to be set and their new values.
		/// </param>
		public void QueueApplyPropertiesOperation(IEnumerable<ShellItem> items, ShellItemPropertyUpdates props)
		{
			op.SetProperties(props.IPropertyChangeArray);
			op.ApplyPropertiesToItems(new ShellItemArray(items).IShellItemArray);
			QueuedOperations++;
		}

		/// <summary>Declares a single item that is to be copied to a specified destination.</summary>
		/// <param name="source">A <see cref="ShellItem"/> that specifies the source item.</param>
		/// <param name="dest">A <see cref="ShellFolder"/> that specifies the destination folder to contain the copy of the item.</param>
		/// <param name="newName">
		/// An optional new name for the item after it has been copied. This can be <see langword="null"/>. If <see langword="null"/>, the name of the
		/// destination item is the same as the source.
		/// </param>
		public void QueueCopyOperation(ShellItem source, ShellFolder dest, string newName = null)
		{
			op.CopyItem(source.IShellItem, dest.IShellItem, newName, null);
			QueuedOperations++;
		}

		/// <summary>Declares a set of items that are to be copied to a specified destination.</summary>
		/// <param name="sourceItems">An <see cref="IEnumerable{T}"/> of <see cref="ShellItem"/> instances that represent the group of items to be copied.</param>
		/// <param name="dest">A <see cref="ShellFolder"/> that specifies the destination folder to contain the copy of the items.</param>
		public void QueueCopyOperation(IEnumerable<ShellItem> sourceItems, ShellFolder dest)
		{
			op.CopyItems(new ShellItemArray(sourceItems).IShellItemArray, dest.IShellItem);
			QueuedOperations++;
		}

		/// <summary>Declares a single item that is to be deleted.</summary>
		/// <param name="item">&gt;A <see cref="ShellItem"/> that specifies the item to be deleted.</param>
		public void QueueDeleteOperation(ShellItem item)
		{
			op.DeleteItem(item.IShellItem, null);
			QueuedOperations++;
		}

		/// <summary>Declares a set of items that are to be deleted.</summary>
		/// <param name="items">An <see cref="IEnumerable{T}"/> of <see cref="ShellItem"/> instances which represents the group of items to be deleted.</param>
		public void QueueDeleteOperation(IEnumerable<ShellItem> items)
		{
			op.DeleteItems(new ShellItemArray(items).IShellItemArray);
			QueuedOperations++;
		}

		/// <summary>Declares a single item that is to be moved to a specified destination.</summary>
		/// <param name="source">A <see cref="ShellItem"/> that specifies the source item.</param>
		/// <param name="dest">A <see cref="ShellFolder"/> that specifies the destination folder to contain the moved item.</param>
		/// <param name="newName">
		/// An optional new name for the item in its new location. This can be <see langword="null"/>. If <see langword="null"/>, the name of the destination
		/// item is the same as the source.
		/// </param>
		public void QueueMoveOperation(ShellItem source, ShellFolder dest, string newName = null)
		{
			op.MoveItem(source.IShellItem, dest.IShellItem, newName, null);
			QueuedOperations++;
		}

		/// <summary>Declares a set of items that are to be moved to a specified destination.</summary>
		/// <param name="sourceItems">An <see cref="IEnumerable{T}"/> of <see cref="ShellItem"/> instances which represents the group of items to be moved.</param>
		/// <param name="dest">A <see cref="ShellFolder"/> that specifies the destination folder to contain the moved items.</param>
		public void QueueMoveOperation(IEnumerable<ShellItem> sourceItems, ShellFolder dest)
		{
			op.MoveItems(new ShellItemArray(sourceItems).IShellItemArray, dest.IShellItem);
			QueuedOperations++;
		}

		/// <summary>Declares a new item that is to be created in a specified location.</summary>
		/// <param name="dest">A <see cref="ShellItem"/> that specifies the destination folder that will contain the new item.</param>
		/// <param name="name">The file name of the new item, for instance Newfile.txt.</param>
		/// <param name="attr">A value that specifies the file system attributes for the file or folder.</param>
		/// <param name="template">
		/// The name of the template file (for example Excel9.xls) that the new item is based on, stored in one of the following locations:
		/// <list type="bullet">
		/// <item><description>CSIDL_COMMON_TEMPLATES. The default path for this folder is %ALLUSERSPROFILE%\Templates.</description></item>
		/// <item><description>CSIDL_TEMPLATES. The default path for this folder is %USERPROFILE%\Templates.</description></item>
		/// <item><description>%SystemRoot%\shellnew</description></item>
		/// </list>
		/// <para>
		/// This is a string used to specify an existing file of the same type as the new file, containing the minimal content that an application wants to
		/// include in any new file.
		/// </para>
		/// <para>This parameter is normally <see langword="null"/> to specify a new, blank file.</para>
		/// </param>
		public void QueueNewItemOperation(ShellFolder dest, string name, System.IO.FileAttributes attr = System.IO.FileAttributes.Normal, string template = null)
		{
			op.NewItem(dest.IShellItem, attr, name, template, null);
			QueuedOperations++;
		}

		/// <summary>Declares a single item that is to be given a new display name.</summary>
		/// <param name="source">A <see cref="ShellItem"/> that specifies the source item.</param>
		/// <param name="newName">The new display name of the item.</param>
		public void QueueRenameOperation(ShellItem source, string newName)
		{
			op.RenameItem(source.IShellItem, newName, null);
			QueuedOperations++;
		}

		/// <summary>Declares a set of items that are to be given a new display name. All items are given the same name.</summary>
		/// <param name="sourceItems">An <see cref="IEnumerable{T}"/> of <see cref="ShellItem"/> instances which represents the group of items to be renamed.</param>
		/// <param name="newName">The new display name of the items.</param>
		public void QueueRenameOperation(IEnumerable<ShellItem> sourceItems, string newName)
		{
			op.RenameItems(new ShellItemArray(sourceItems).IShellItemArray, newName);
			QueuedOperations++;
		}

		/// <summary>Releases unmanaged and - optionally - managed resources.</summary>
		/// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
		protected virtual void Dispose(bool disposing)
		{
			if (!disposedValue)
			{
				if (disposing)
				{
					// TODO: dispose managed state (managed objects).
				}

				if (sink != null) op.Unadvise(sinkCookie);
				if (op != null)
				{
					Marshal.FinalReleaseComObject(op);
					op = null;
				}
				disposedValue = true;
			}
		}

		/// <summary>Arguments supplied to the <see cref="PostNewItem"/> event.</summary>
		/// <seealso cref="Vanara.Windows.Shell.ShellFileOperations.ShellFileOpEventArgs"/>
		public class ShellFileNewOpEventArgs : ShellFileOpEventArgs
		{
			internal ShellFileNewOpEventArgs(TRANSFER_SOURCE_FLAGS flags, IShellItem source, IShellItem folder, IShellItem dest, string name, HRESULT hr, string templ, uint attr) :
				base(flags, source, folder, dest, name, hr)
			{
				TemplateName = templ;
				FileAttributes = (System.IO.FileAttributes)attr;
			}

			/// <summary>Gets the name of the template.</summary>
			/// <value>The name of the template.</value>
			public string TemplateName { get; protected set; }
			/// <summary>Gets the file attributes.</summary>
			/// <value>The file attributes.</value>
			public System.IO.FileAttributes FileAttributes { get; protected set; }
		}

		/// <summary>Arguments supplied to events from <see cref="ShellFileOperations"/>. Depending on the event, some properties may not be set.</summary>
		/// <seealso cref="System.EventArgs"/>
		public class ShellFileOpEventArgs : EventArgs
		{
			internal ShellFileOpEventArgs(TRANSFER_SOURCE_FLAGS flags, IShellItem source, IShellItem folder = null, IShellItem dest = null, string name = null, HRESULT hr = default)
			{
				Flags = (TransferFlags)flags;
				if (source != null) SourceItem = ShellItem.Open(source);
				if (folder != null) DestFolder = ShellItem.Open(folder);
				if (dest != null) DestItem = ShellItem.Open(dest);
				Name = name;
				Result = hr;
			}

			/// <summary>Gets the destination folder.</summary>
			/// <value>The destination folder.</value>
			public ShellItem DestFolder { get; protected set; }
			/// <summary>Gets the destination item.</summary>
			/// <value>The destination item.</value>
			public ShellItem DestItem { get; protected set; }
			/// <summary>Gets the tranfer flag values.</summary>
			/// <value>The flags.</value>
			public TransferFlags Flags { get; protected set; }
			/// <summary>Gets the name of the item.</summary>
			/// <value>The item name.</value>
			public string Name { get; protected set; }
			/// <summary>Gets the result of the operation.</summary>
			/// <value>The result.</value>
			public HRESULT Result { get; protected set; }
			/// <summary>Gets the source item.</summary>
			/// <value>The source item.</value>
			public ShellItem SourceItem { get; protected set; }

			/// <summary>Returns a <see cref="System.String"/> that represents this instance.</summary>
			/// <returns>A <see cref="System.String"/> that represents this instance.</returns>
			public override string ToString() => $"HR:{Result};Src:{SourceItem};DFld:{DestFolder};Dst:{DestItem};Name:{Name}";
		}

		private class OpSink : IFileOperationProgressSink
		{
			private readonly ShellFileOperations parent;

			public OpSink(ShellFileOperations ops) { parent = ops; }

			public void FinishOperations(HRESULT hrResult) => parent.FinishOperations?.Invoke(parent, new ShellFileOpEventArgs(0, null, null, null, null, hrResult));

			public void PauseTimer() { }

			public void PostCopyItem(TRANSFER_SOURCE_FLAGS dwFlags, IShellItem psiItem, IShellItem psiDestinationFolder, [MarshalAs(UnmanagedType.LPWStr)] string pszNewName, HRESULT hrCopy, IShellItem psiNewlyCreated) =>
				parent.PostCopyItem?.Invoke(parent, new ShellFileOpEventArgs(dwFlags, psiItem, psiDestinationFolder, psiNewlyCreated, pszNewName, hrCopy));

			public void PostDeleteItem(TRANSFER_SOURCE_FLAGS dwFlags, IShellItem psiItem, HRESULT hrDelete, IShellItem psiNewlyCreated) =>
				parent.PostDeleteItem?.Invoke(parent, new ShellFileOpEventArgs(dwFlags, psiItem, null, psiNewlyCreated, null, hrDelete));

			public void PostMoveItem(TRANSFER_SOURCE_FLAGS dwFlags, IShellItem psiItem, IShellItem psiDestinationFolder, [MarshalAs(UnmanagedType.LPWStr)] string pszNewName, HRESULT hrMove, IShellItem psiNewlyCreated) =>
				parent.PostMoveItem?.Invoke(parent, new ShellFileOpEventArgs(dwFlags, psiItem, psiDestinationFolder, psiNewlyCreated, pszNewName, hrMove));

			public void PostNewItem(TRANSFER_SOURCE_FLAGS dwFlags, IShellItem psiDestinationFolder, [MarshalAs(UnmanagedType.LPWStr)] string pszNewName, [MarshalAs(UnmanagedType.LPWStr)] string pszTemplateName, uint dwFileAttributes, HRESULT hrNew, IShellItem psiNewItem) =>
				parent.PostNewItem?.Invoke(parent, new ShellFileNewOpEventArgs(dwFlags, null, psiDestinationFolder, psiNewItem, pszNewName, hrNew, pszTemplateName, dwFileAttributes));

			public void PostRenameItem(TRANSFER_SOURCE_FLAGS dwFlags, IShellItem psiItem, [MarshalAs(UnmanagedType.LPWStr)] string pszNewName, HRESULT hrRename, IShellItem psiNewlyCreated) =>
				parent.PostRenameItem?.Invoke(parent, new ShellFileOpEventArgs(dwFlags, psiItem, null, psiNewlyCreated, pszNewName, hrRename));

			public void PreCopyItem(TRANSFER_SOURCE_FLAGS dwFlags, IShellItem psiItem, IShellItem psiDestinationFolder, [MarshalAs(UnmanagedType.LPWStr)] string pszNewName) =>
				parent.PreCopyItem?.Invoke(parent, new ShellFileOpEventArgs(dwFlags, psiItem, psiDestinationFolder, null, pszNewName));

			public void PreDeleteItem(TRANSFER_SOURCE_FLAGS dwFlags, IShellItem psiItem) =>
				parent.PreDeleteItem?.Invoke(parent, new ShellFileOpEventArgs(dwFlags, psiItem));

			public void PreMoveItem(TRANSFER_SOURCE_FLAGS dwFlags, IShellItem psiItem, IShellItem psiDestinationFolder, [MarshalAs(UnmanagedType.LPWStr)] string pszNewName) =>
				parent.PreMoveItem?.Invoke(parent, new ShellFileOpEventArgs(dwFlags, psiItem, psiDestinationFolder, null, pszNewName));

			public void PreNewItem(TRANSFER_SOURCE_FLAGS dwFlags, IShellItem psiDestinationFolder, [MarshalAs(UnmanagedType.LPWStr)] string pszNewName) =>
				parent.PreNewItem?.Invoke(parent, new ShellFileOpEventArgs(dwFlags, null, psiDestinationFolder, null, pszNewName));

			public void PreRenameItem(TRANSFER_SOURCE_FLAGS dwFlags, IShellItem psiItem, [MarshalAs(UnmanagedType.LPWStr)] string pszNewName) => parent.PreRenameItem?.Invoke(parent, new ShellFileOpEventArgs(dwFlags, psiItem, null, null, pszNewName));

			public void ResetTimer() { }

			public void ResumeTimer() { }

			public void StartOperations() => parent.StartOperations?.Invoke(parent, EventArgs.Empty);

			public void UpdateProgress(uint iWorkTotal, uint iWorkSoFar) => parent.UpdateProgress?.Invoke(parent, new System.ComponentModel.ProgressChangedEventArgs((int)(iWorkSoFar * 100 / iWorkTotal), null));
		}
	}

	/// <summary>
	/// A dictionary of properties that can be used to set or update property values on Shell items via the
	/// <see cref="ShellFileOperations.QueueApplyPropertiesOperation(ShellItem, ShellItemPropertyUpdates)"/> method. This class wraps the
	/// <see cref="IPropertyChangeArray"/> COM interface.
	/// </summary>
	/// <seealso cref="System.Collections.Generic.IDictionary{TKey, TValue}"/>
	/// <seealso cref="IDisposable"/>
	public class ShellItemPropertyUpdates : IDictionary<PROPERTYKEY, object>, IDisposable
	{
		private IPropertyChangeArray changes;

		/// <summary>Initializes a new instance of the <see cref="ShellItemPropertyUpdates"/> class.</summary>
		public ShellItemPropertyUpdates()
		{
			PSCreatePropertyChangeArray(null, null, null, 0, typeof(IPropertyChangeArray).GUID, out changes).ThrowIfFailed();
		}

		/// <summary>Gets the number of elements contained in the <see cref="System.Collections.Generic.ICollection{T}"/>.</summary>
		public int Count => (int)changes.GetCount();

		/// <summary>Gets the COM interface for <see cref="IPropertyChangeArray"/>.</summary>
		/// <value>The <see cref="IPropertyChangeArray"/> value.</value>
		public IPropertyChangeArray IPropertyChangeArray => changes;

		/// <summary>Gets an <see cref="System.Collections.Generic.ICollection{T}"/> containing the keys of the <see cref="System.Collections.Generic.IDictionary{TKey, TValue}"/>.</summary>
		public ICollection<PROPERTYKEY> Keys
		{
			get
			{
				var l = new List<PROPERTYKEY>(Count);
				for (uint i = 0; i < Count; i++)
				{
					using (var p = new ComReleaser<IPropertyChange>(changes.GetAt<IPropertyChange>(i)))
						l.Add(p.Item.GetPropertyKey());
				}
				return l;
			}
		}

		/// <summary>Gets an <see cref="System.Collections.Generic.ICollection{T}"/> containing the values in the <see cref="System.Collections.Generic.IDictionary{TKey, TValue}"/>.</summary>
		public ICollection<object> Values
		{
			get
			{
				var l = new List<object>(Count);
				for (int i = 0; i < Count; i++)
					l.Add(this[i].Value);
				return l;
			}
		}

		/// <summary>Gets a value indicating whether the <see cref="System.Collections.Generic.ICollection{T}"/> is read-only.</summary>
		bool ICollection<KeyValuePair<PROPERTYKEY, object>>.IsReadOnly => false;

		/// <summary>Gets or sets the <see cref="System.Object"/> with the specified key.</summary>
		/// <value>The <see cref="System.Object"/>.</value>
		/// <param name="key">The key.</param>
		/// <returns>The object associated with <paramref name="key"/>.</returns>
		/// <exception cref="ArgumentOutOfRangeException">key</exception>
		public object this[PROPERTYKEY key]
		{
			get => TryGetValue(key, out var value) ? value : throw new ArgumentOutOfRangeException(nameof(key));
			set => changes.AppendOrReplace(ToPC(key, value));
		}

		internal KeyValuePair<PROPERTYKEY, object> this[int index]
		{
			get
			{
				using (var p = new ComReleaser<IPropertyChange>(changes.GetAt<IPropertyChange>((uint)index)))
				{
					p.Item.ApplyToPropVariant(new PROPVARIANT(), out var pv);
					return new KeyValuePair<PROPERTYKEY, object>(p.Item.GetPropertyKey(), pv.Value);
				}
			}
		}
		/// <summary>Adds an element with the provided key and value to the <see cref="System.Collections.Generic.IDictionary{TKey, TValue}"/>.</summary>
		/// <param name="key">The object to use as the key of the element to add.</param>
		/// <param name="value">The object to use as the value of the element to add.</param>
		public void Add(PROPERTYKEY key, object value)
		{
			changes.Append(ToPC(key, value));
		}

		/// <summary>Removes all items from the <see cref="System.Collections.Generic.ICollection{T}"/>.</summary>
		public void Clear()
		{
			for (uint i = (uint)Count - 1; i >= 0; i--)
				changes.RemoveAt(i);
		}

		/// <summary>Determines whether the <see cref="System.Collections.Generic.IDictionary{TKey, TValue}"/> contains an element with the specified key.</summary>
		/// <param name="key">The key to locate in the <see cref="System.Collections.Generic.IDictionary{TKey, TValue}"/>.</param>
		/// <returns>true if the <see cref="System.Collections.Generic.IDictionary{TKey, TValue}"/> contains an element with the key; otherwise, false.</returns>
		public bool ContainsKey(PROPERTYKEY key) => changes.IsKeyInArray(key).Succeeded;

		/// <summary>Returns an enumerator that iterates through the collection.</summary>
		/// <returns>A <see cref="System.Collections.Generic.IEnumerator{T}"/> that can be used to iterate through the collection.</returns>
		public IEnumerator<KeyValuePair<PROPERTYKEY, object>> GetEnumerator() =>
			new IEnumFromIndexer<KeyValuePair<PROPERTYKEY, object>>(changes.GetCount, i => this[(int)i]).GetEnumerator();

		/// <summary>Removes the element with the specified key from the <see cref="System.Collections.Generic.IDictionary{TKey, TValue}"/>.</summary>
		/// <param name="key">The key of the element to remove.</param>
		/// <returns>
		/// true if the element is successfully removed; otherwise, false. This method also returns false if <paramref name="key"/> was not found in the original <see cref="System.Collections.Generic.IDictionary{TKey, TValue}"/>.
		/// </returns>
		public bool Remove(PROPERTYKEY key)
		{
			var idx = IndexOf(key);
			if (idx == -1) return false;
			try { changes.RemoveAt((uint)idx); return true; } catch { return false; }
		}

		/// <summary>Gets the value associated with the specified key.</summary>
		/// <param name="key">The key whose value to get.</param>
		/// <param name="value">
		/// When this method returns, the value associated with the specified key, if the key is found; otherwise, the default value for the type of the
		/// <paramref name="value"/> parameter. This parameter is passed uninitialized.
		/// </param>
		/// <returns>
		/// true if the object that implements <see cref="System.Collections.Generic.IDictionary{TKey, TValue}"/> contains an element with the specified key; otherwise, false.
		/// </returns>
		public bool TryGetValue(PROPERTYKEY key, out object value)
		{
			value = null;
			var idx = IndexOf(key);
			if (idx == -1) return false;
			try { value = this[idx]; return true; } catch { return false; }
		}

		void ICollection<KeyValuePair<PROPERTYKEY, object>>.Add(KeyValuePair<PROPERTYKEY, object> item) =>
			Add(item.Key, item.Value);

		bool ICollection<KeyValuePair<PROPERTYKEY, object>>.Contains(KeyValuePair<PROPERTYKEY, object> item) =>
			ContainsKey(item.Key) && this[item.Key] == item.Value;

		void ICollection<KeyValuePair<PROPERTYKEY, object>>.CopyTo(KeyValuePair<PROPERTYKEY, object>[] array, int arrayIndex)
		{
			if (array == null) throw new ArgumentNullException(nameof(array));
			if (arrayIndex + Count > array.Length) throw new ArgumentOutOfRangeException(nameof(arrayIndex));
			for (int i = 0; i < Count; i++)
				array[i + arrayIndex] = this[i];
		}

		void IDisposable.Dispose()
		{
			if (changes == null) return;
			Marshal.FinalReleaseComObject(changes);
			changes = null;
		}

		IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

		bool ICollection<KeyValuePair<PROPERTYKEY, object>>.Remove(KeyValuePair<PROPERTYKEY, object> item)
		{
			var idx = IndexOf(item.Key);
			if (idx == -1) return false;
			if (this[idx].Value != item.Value) return false;
			try { changes.RemoveAt((uint)idx); return true; } catch { return false; }
		}

		private int IndexOf(PROPERTYKEY key)
		{
			for (uint i = 0; i < Count; i++)
			{
				using (var p = new ComReleaser<IPropertyChange>(changes.GetAt<IPropertyChange>(i)))
					if (key == p.Item.GetPropertyKey())
						return (int)i;
			}
			return -1;
		}

		private IPropertyChange ToPC(PROPERTYKEY key, object value, PKA_FLAGS flags = PKA_FLAGS.PKA_SET)
		{
			PSCreateSimplePropertyChange(PKA_FLAGS.PKA_SET, key, new PROPVARIANT(value), typeof(IPropertyChange).GUID, out var pc).ThrowIfFailed();
			return pc;
		}
	}
}