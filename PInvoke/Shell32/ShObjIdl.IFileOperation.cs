using System;
using System.IO;
using System.Runtime.InteropServices;

// ReSharper disable MemberCanBePrivate.Global ReSharper disable UnusedParameter.Global ReSharper disable UnusedMember.Global ReSharper disable
// FieldCanBeMadeReadOnly.Global ReSharper disable InconsistentNaming ReSharper disable MemberHidesStaticFromOuterClass ReSharper disable UnusedMethodReturnValue.Global

namespace Vanara.PInvoke
{
	public static partial class Shell32
	{
		[Flags]
		public enum FileOperationFlags : uint
		{
			FOF_MULTIDESTFILES = 0x0001,
			FOF_CONFIRMMOUSE = 0x0002,
			FOF_SILENT = 0x0004,  // don't create progress/report
			FOF_RENAMEONCOLLISION = 0x0008,
			FOF_NOCONFIRMATION = 0x0010,  // Don't prompt the user.
			FOF_WANTMAPPINGHANDLE = 0x0020,  // Fill in SHFILEOPSTRUCT.hNameMappings
											 // Must be freed using SHFreeNameMappings
			FOF_ALLOWUNDO = 0x0040,
			FOF_FILESONLY = 0x0080,  // on *.*, do only files
			FOF_SIMPLEPROGRESS = 0x0100,  // means don't show names of files
			FOF_NOCONFIRMMKDIR = 0x0200,  // don't confirm making any needed dirs
			FOF_NOERRORUI = 0x0400,  // don't put up error UI
			FOF_NOCOPYSECURITYATTRIBS = 0x0800,  // dont copy NT file Security Attributes
			FOF_NORECURSION = 0x1000,  // don't recurse into directories.
			FOF_NO_CONNECTED_ELEMENTS = 0x2000,  // don't operate on connected file elements.
			FOF_WANTNUKEWARNING = 0x4000,  // during delete operation, warn if nuking instead of recycling (partially overrides FOF_NOCONFIRMATION)
			FOF_NORECURSEREPARSE = 0x8000,  // treat reparse points as objects, not containers

			FOFX_NOSKIPJUNCTIONS = 0x00010000,  // Don't avoid binding to junctions (like Task folder, Recycle-Bin)
			FOFX_PREFERHARDLINK = 0x00020000,  // Create hard link if possible
			FOFX_SHOWELEVATIONPROMPT = 0x00040000,  // Show elevation prompts when error UI is disabled (use with FOF_NOERRORUI)
			FOFX_EARLYFAILURE = 0x00100000,  // Fail operation as soon as a single error occurs rather than trying to process other items (applies only when using FOF_NOERRORUI)
			FOFX_PRESERVEFILEEXTENSIONS = 0x00200000,  // Rename collisions preserve file extns (use with FOF_RENAMEONCOLLISION)
			FOFX_KEEPNEWERFILE = 0x00400000,  // Keep newer file on naming conflicts
			FOFX_NOCOPYHOOKS = 0x00800000,  // Don't use copy hooks
			FOFX_NOMINIMIZEBOX = 0x01000000,  // Don't allow minimizing the progress dialog
			FOFX_MOVEACLSACROSSVOLUMES = 0x02000000,  // Copy security information when performing a cross-volume move operation
			FOFX_DONTDISPLAYSOURCEPATH = 0x04000000,  // Don't display the path of source file in progress dialog
			FOFX_DONTDISPLAYDESTPATH = 0x08000000,  // Don't display the path of destination file in progress dialog
		}

		[ComImport, Guid("947aab5f-0a5c-4c13-b4d6-4bf7836fc9f8"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		public interface IFileOperation
		{
			uint Advise(IFileOperationProgressSink pfops);
			void Unadvise(uint dwCookie);
			void SetOperationFlags(FileOperationFlags dwOperationFlags);
			void SetProgressMessage([MarshalAs(UnmanagedType.LPWStr)] string pszMessage);
			void SetProgressDialog([MarshalAs(UnmanagedType.Interface)] object popd);
			void SetProperties([MarshalAs(UnmanagedType.Interface)] object pproparray);
			void SetOwnerWindow(uint hwndParent);
			void ApplyPropertiesToItem(IShellItem psiItem);
			void ApplyPropertiesToItems([MarshalAs(UnmanagedType.Interface)] object punkItems);
			void RenameItem(IShellItem psiItem, [MarshalAs(UnmanagedType.LPWStr)] string pszNewName,
				IFileOperationProgressSink pfopsItem);
			void RenameItems(
				[MarshalAs(UnmanagedType.Interface)] object pUnkItems,
				[MarshalAs(UnmanagedType.LPWStr)] string pszNewName);
			void MoveItem(
				IShellItem psiItem,
				IShellItem psiDestinationFolder,
				[MarshalAs(UnmanagedType.LPWStr)] string pszNewName,
				IFileOperationProgressSink pfopsItem);
			void MoveItems(
				[MarshalAs(UnmanagedType.Interface)] object punkItems,
				IShellItem psiDestinationFolder);
			void CopyItem(
				IShellItem psiItem,
				IShellItem psiDestinationFolder,
				[MarshalAs(UnmanagedType.LPWStr)] string pszCopyName,
				IFileOperationProgressSink pfopsItem);
			void CopyItems(
				[MarshalAs(UnmanagedType.Interface)] object punkItems,
				IShellItem psiDestinationFolder);
			void DeleteItem(
				IShellItem psiItem,
				IFileOperationProgressSink pfopsItem);
			void DeleteItems([MarshalAs(UnmanagedType.Interface)] object punkItems);
			uint NewItem(
				IShellItem psiDestinationFolder,
				FileAttributes dwFileAttributes,
				[MarshalAs(UnmanagedType.LPWStr)] string pszName,
				[MarshalAs(UnmanagedType.LPWStr)] string pszTemplateName,
				IFileOperationProgressSink pfopsItem);
			void PerformOperations();
			[return: MarshalAs(UnmanagedType.Bool)]
			bool GetAnyOperationsAborted();
		}
	}
}