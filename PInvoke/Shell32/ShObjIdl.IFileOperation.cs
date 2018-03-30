using System;
using System.IO;
using System.Runtime.InteropServices;

// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable UnusedParameter.Global
// ReSharper disable UnusedMember.Global
// ReSharper disable FieldCanBeMadeReadOnly.Global
// ReSharper disable InconsistentNaming
// ReSharper disable MemberHidesStaticFromOuterClass
// ReSharper disable UnusedMethodReturnValue.Global

namespace Vanara.PInvoke
{
	public static partial class Shell32
	{
		[Flags]
		public enum FILEOP_FLAGS : uint
		{
			FOF_MULTIDESTFILES = 0x0001,
			FOF_CONFIRMMOUSE = 0x0002,
			FOF_SILENT = 0x0004,
			FOF_RENAMEONCOLLISION = 0x0008,
			FOF_NOCONFIRMATION = 0x0010,
			FOF_WANTMAPPINGHANDLE = 0x0020,
			FOF_ALLOWUNDO = 0x0040,
			FOF_FILESONLY = 0x0080,
			FOF_SIMPLEPROGRESS = 0x0100,
			FOF_NOCONFIRMMKDIR = 0x0200,
			FOF_NOERRORUI = 0x0400,
			FOF_NOCOPYSECURITYATTRIBS = 0x0800,
			FOF_NORECURSION = 0x1000,
			FOF_NO_CONNECTED_ELEMENTS = 0x2000,
			FOF_WANTNUKEWARNING = 0x4000,
			FOF_NORECURSEREPARSE = 0x8000,
			FOFX_NOSKIPJUNCTIONS = 0x00010000,
			FOFX_PREFERHARDLINK = 0x00020000,
			FOFX_SHOWELEVATIONPROMPT = 0x00040000,
			FOFX_EARLYFAILURE = 0x00100000,
			FOFX_PRESERVEFILEEXTENSIONS = 0x00200000,
			FOFX_KEEPNEWERFILE = 0x00400000,
			FOFX_NOCOPYHOOKS = 0x00800000,
			FOFX_NOMINIMIZEBOX = 0x01000000,
			FOFX_MOVEACLSACROSSVOLUMES = 0x02000000,
			FOFX_DONTDISPLAYSOURCEPATH = 0x04000000,
			FOFX_DONTDISPLAYDESTPATH = 0x08000000,
			FOFX_REQUIREELEVATION = 0x10000000,
			FOFX_ADDUNDORECORD = 0x20000000,
			FOFX_COPYASDOWNLOAD = 0x40000000,
			FOFX_DONTDISPLAYLOCATIONS = 0x80000000,
		}

		[ComImport, Guid("947aab5f-0a5c-4c13-b4d6-4bf7836fc9f8"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown), CoClass(typeof(CFileOperations))]
		public interface IFileOperation
		{
			uint Advise(IFileOperationProgressSink pfops);
			void Unadvise(uint dwCookie);
			void SetOperationFlags(FILEOP_FLAGS dwOperationFlags);
			void SetProgressMessage([MarshalAs(UnmanagedType.LPWStr)] string pszMessage);
			void SetProgressDialog(IOperationsProgressDialog popd);
			void SetProperties(PropSys.IPropertyChangeArray pproparray);
			void SetOwnerWindow(IntPtr hwndParent);
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

		[ComImport, Guid("3ad05575-8857-4850-9277-11b85bdb8e09"), ClassInterface(ClassInterfaceType.None)]
		public class CFileOperations { }
	}
}