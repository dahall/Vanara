using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using Vanara.Extensions;
using Vanara.InteropServices;
using FILETIME = System.Runtime.InteropServices.ComTypes.FILETIME;

namespace Vanara.PInvoke
{
	public static partial class Kernel32
	{
		/// <summary>
		/// An application-defined callback function used with the <c>CopyFileEx</c>, <c>MoveFileTransacted</c>, and
		/// <c>MoveFileWithProgress</c> functions. It is called when a portion of a copy or move operation is completed. The
		/// <c>LPPROGRESS_ROUTINE</c> type defines a pointer to this callback function. <c>CopyProgressRoutine</c> is a placeholder for the
		/// application-defined function name.
		/// </summary>
		/// <param name="TotalFileSize">The total size of the file, in bytes.</param>
		/// <param name="TotalBytesTransferred">
		/// The total number of bytes transferred from the source file to the destination file since the copy operation began.
		/// </param>
		/// <param name="StreamSize">The total size of the current file stream, in bytes.</param>
		/// <param name="StreamBytesTransferred">
		/// The total number of bytes in the current stream that have been transferred from the source file to the destination file since the
		/// copy operation began.
		/// </param>
		/// <param name="dwStreamNumber">
		/// A handle to the current stream. The first time <c>CopyProgressRoutine</c> is called, the stream number is 1.
		/// </param>
		/// <param name="dwCallbackReason">
		/// <para>The reason that <c>CopyProgressRoutine</c> was called. This parameter can be one of the following values.</para>
		/// <para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>CALLBACK_CHUNK_FINISHED0x00000000</term>
		/// <term>Another part of the data file was copied.</term>
		/// </item>
		/// <item>
		/// <term>CALLBACK_STREAM_SWITCH0x00000001</term>
		/// <term>
		/// Another stream was created and is about to be copied. This is the callback reason given when the callback routine is first invoked.
		/// </term>
		/// </item>
		/// </list>
		/// </para>
		/// </param>
		/// <param name="hSourceFile">A handle to the source file.</param>
		/// <param name="hDestinationFile">A handle to the destination file</param>
		/// <param name="lpData">Argument passed to <c>CopyProgressRoutine</c> by <c>CopyFileEx</c>, <c>MoveFileTransacted</c>, or <c>MoveFileWithProgress</c>.</param>
		/// <returns>
		/// <para>The <c>CopyProgressRoutine</c> function should return one of the following values.</para>
		/// <para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code/value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>PROGRESS_CANCEL1</term>
		/// <term>Cancel the copy operation and delete the destination file.</term>
		/// </item>
		/// <item>
		/// <term>PROGRESS_CONTINUE0</term>
		/// <term>Continue the copy operation.</term>
		/// </item>
		/// <item>
		/// <term>PROGRESS_QUIET3</term>
		/// <term>Continue the copy operation, but stop invoking CopyProgressRoutine to report progress.</term>
		/// </item>
		/// <item>
		/// <term>PROGRESS_STOP2</term>
		/// <term>Stop the copy operation. It can be restarted at a later time.</term>
		/// </item>
		/// </list>
		/// </para>
		/// </returns>
		// DWORD CALLBACK CopyProgressRoutine( _In_ LARGE_INTEGER TotalFileSize, _In_ LARGE_INTEGER TotalBytesTransferred, _In_ LARGE_INTEGER
		// StreamSize, _In_ LARGE_INTEGER StreamBytesTransferred, _In_ DWORD dwStreamNumber, _In_ DWORD dwCallbackReason, _In_ HANDLE
		// hSourceFile, _In_ HANDLE hDestinationFile, _In_opt_ LPVOID lpData);typedef DWORD (WINAPI *LPPROGRESS_ROUTINE)( _In_ LARGE_INTEGER
		// TotalFileSize, _In_ LARGE_INTEGER TotalBytesTransferred, _In_ LARGE_INTEGER StreamSize, _In_ LARGE_INTEGER StreamBytesTransferred,
		// _In_ DWORD dwStreamNumber, _In_ DWORD dwCallbackReason, _In_ HANDLE hSourceFile, _In_ HANDLE hDestinationFile, _In_opt_ LPVOID
		// lpData); https://msdn.microsoft.com/en-us/library/windows/desktop/aa363854(v=vs.85).aspx
		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		[PInvokeData("WinBase.h", MSDNShortId = "aa363854")]
		public delegate uint CopyProgressRoutine(long TotalFileSize, long TotalBytesTransferred, long StreamSize, long StreamBytesTransferred, uint dwStreamNumber, COPY_CALLBACK_REASON dwCallbackReason, [In] IntPtr hSourceFile, [In] IntPtr hDestinationFile, [In] IntPtr lpData);

		private delegate THandle FindFirstDelegate<THandle>(StringBuilder sb, ref uint sz) where THandle : SafeHandle;

		private delegate bool FindNextDelegate<THandle>(THandle handle, StringBuilder sb, ref uint sz) where THandle : SafeHandle;

		/// <summary>The reason that CopyProgressRoutine was called.</summary>
		public enum COPY_CALLBACK_REASON : uint
		{
			/// <summary>Another part of the data file was copied.</summary>
			CALLBACK_CHUNK_FINISHED = 0x00000000,

			/// <summary>
			/// Another stream was created and is about to be copied. This is the callback reason given when the callback routine is first invoked.
			/// </summary>
			CALLBACK_STREAM_SWITCH = 0x00000001,
		}

		/// <summary>Flags used by <see cref="COPYFILE2_EXTENDED_PARAMETERS"/>.</summary>
		[PInvokeData("winbase.h", MSDNShortId = "a8da62e5-bc49-4aff-afaa-e774393b7120")]
		[Flags]
		public enum COPY_FILE : uint
		{
			/// <summary>The copy will be attempted even if the destination file cannot be encrypted.</summary>
			COPY_FILE_ALLOW_DECRYPTED_DESTINATION = 0x00000008,

			/// <summary>
			/// If the source file is a symbolic link, the destination file is also a symbolic link pointing to the same file as the source
			/// symbolic link.
			/// </summary>
			COPY_FILE_COPY_SYMLINK = 0x00000800,

			/// <summary>
			/// If the destination file exists the copy operation fails immediately. If a file or directory exists with the destination name
			/// then the CopyFile2 function call will fail with either HRESULT_FROM_WIN32(ERROR_ALREADY_EXISTS) or
			/// HRESULT_FROM_WIN32(ERROR_FILE_EXISTS). If COPY_FILE_RESUME_FROM_PAUSE is also specified then a failure is only triggered if
			/// the destination file does not have a valid restart header.
			/// </summary>
			COPY_FILE_FAIL_IF_EXISTS = 0x00000001,

			/// <summary>
			/// The copy is performed using unbuffered I/O, bypassing the system cache resources. This flag is recommended for very large
			/// file copies. It is not recommended to pause copies that are using this flag.
			/// </summary>
			COPY_FILE_NO_BUFFERING = 0x00001000,

			/// <summary>Do not attempt to use the Windows Copy Offload mechanism. This is not generally recommended.</summary>
			COPY_FILE_NO_OFFLOAD = 0x00040000,

			/// <summary>The file is copied and the source file is opened for write access.</summary>
			COPY_FILE_OPEN_SOURCE_FOR_WRITE = 0x00000004,

			/// <summary>
			/// The file is copied in a manner that can be restarted if the same source and destination filenames are used again. This is slower.
			/// </summary>
			COPY_FILE_RESTARTABLE = 0x00000002,

			/// <summary>
			/// The copy is attempted, specifying ACCESS_SYSTEM_SECURITY for the source file and ACCESS_SYSTEM_SECURITY | WRITE_DAC |
			/// WRITE_OWNER for the destination file. If these requests are denied the access request will be reduced to the highest
			/// privilege level for which access is granted. For more information see SACL Access Right. This can be used to allow the
			/// CopyFile2ProgressRoutine callback to perform operations requiring higher privileges, such as copying the security attributes
			/// for the file.
			/// </summary>
			COPY_FILE_REQUEST_SECURITY_PRIVILEGES = 0x00002000,

			/// <summary>
			/// The destination file is examined to see if it was copied using COPY_FILE_RESTARTABLE. If so the copy is resumed. If not the
			/// file will be fully copied.
			/// </summary>
			COPY_FILE_RESUME_FROM_PAUSE = 0x00004000,

			/// <summary>Undocumented.</summary>
			COPY_FILE_IGNORE_EDP_BLOCK = 0x00400000,

			/// <summary>Undocumented.</summary>
			COPY_FILE_IGNORE_SOURCE_ENCRYPTION = 0x00800000,
		}

		/// <summary>
		/// <para>
		/// Identifies the type of file information that <see cref="GetFileInformationByHandleEx"/> should retrieve or <see
		/// cref="SetFileInformationByHandle"/> should set.
		/// </para>
		/// </summary>
		// typedef enum _FILE_INFO_BY_HANDLE_CLASS { FileBasicInfo = 0, FileStandardInfo = 1, FileNameInfo = 2, FileRenameInfo = 3,
		// FileDispositionInfo = 4, FileAllocationInfo = 5, FileEndOfFileInfo = 6, FileStreamInfo = 7, FileCompressionInfo = 8,
		// FileAttributeTagInfo = 9, FileIdBothDirectoryInfo = 10, // 0xA FileIdBothDirectoryRestartInfo = 11, // 0xB FileIoPriorityHintInfo
		// = 12, // 0xC FileRemoteProtocolInfo = 13, // 0xD FileFullDirectoryInfo = 14, // 0xE FileFullDirectoryRestartInfo = 15, // 0xF
		// FileStorageInfo = 16, // 0x10 FileAlignmentInfo = 17, // 0x11 FileIdInfo = 18, // 0x12 FileIdExtdDirectoryInfo = 19, // 0x13
		// FileIdExtdDirectoryRestartInfo = 20, // 0x14 MaximumFileInfoByHandlesClass} FILE_INFO_BY_HANDLE_CLASS, *PFILE_INFO_BY_HANDLE_CLASS;
		[PInvokeData("WinBase.h", MSDNShortId = "aa364228")]
		public enum FILE_INFO_BY_HANDLE_CLASS
		{
			/// <summary>
			/// <para>Minimal information for the file should be retrieved or set. Used for file handles. See <c>FILE_BASIC_INFO</c>.</para>
			/// </summary>
			[CorrespondingType(typeof(FILE_BASIC_INFO))]
			FileBasicInfo = 0,

			/// <summary>
			/// <para>
			/// Extended information for the file should be retrieved. Used for file handles. Use only when calling
			/// <c>GetFileInformationByHandleEx</c>. See <c>FILE_STANDARD_INFO</c>.
			/// </para>
			/// </summary>
			[CorrespondingType(typeof(FILE_STANDARD_INFO), CorrespondingAction.Get)]
			FileStandardInfo,

			/// <summary>
			/// <para>
			/// The file name should be retrieved. Used for any handles. Use only when calling <c>GetFileInformationByHandleEx</c>. See <c>FILE_NAME_INFO</c>.
			/// </para>
			/// </summary>
			[CorrespondingType(typeof(FILE_NAME_INFO), CorrespondingAction.Get)]
			FileNameInfo,

			/// <summary>
			/// <para>
			/// The file name should be changed. Used for file handles. Use only when calling <c>SetFileInformationByHandle</c>. See <c>FILE_RENAME_INFO</c>.
			/// </para>
			/// </summary>
			[CorrespondingType(typeof(FILE_RENAME_INFO), CorrespondingAction.Set)]
			FileRenameInfo,

			/// <summary>
			/// <para>The file should be deleted. Used for any handles. Use only when calling <c>SetFileInformationByHandle</c>. See <c>FILE_DISPOSITION_INFO</c>.</para>
			/// </summary>
			[CorrespondingType(typeof(FILE_DISPOSITION_INFO), CorrespondingAction.Set)]
			FileDispositionInfo,

			/// <summary>
			/// <para>
			/// The file allocation information should be changed. Used for file handles. Use only when calling
			/// <c>SetFileInformationByHandle</c>. See <c>FILE ALLOCATION INFO</c>.
			/// </para>
			/// </summary>
			[CorrespondingType(typeof(FILE_ALLOCATION_INFO), CorrespondingAction.Set)]
			FileAllocationInfo,

			/// <summary>
			/// <para>The end of the file should be set. Use only when calling <c>SetFileInformationByHandle</c>. See <c>FILE_END_OF_FILE_INFO</c>.</para>
			/// </summary>
			[CorrespondingType(typeof(FILE_END_OF_FILE_INFO), CorrespondingAction.Set)]
			FileEndOfFileInfo,

			/// <summary>
			/// <para>
			/// File stream information for the specified file should be retrieved. Used for any handles. Use only when calling
			/// <c>GetFileInformationByHandleEx</c>. See <c>FILE_STREAM_INFO</c>.
			/// </para>
			/// </summary>
			[CorrespondingType(typeof(FILE_STREAM_INFO), CorrespondingAction.Get)]
			FileStreamInfo,

			/// <summary>
			/// <para>
			/// File compression information should be retrieved. Used for any handles. Use only when calling
			/// <c>GetFileInformationByHandleEx</c>. See <c>FILE_COMPRESSION_INFO</c>.
			/// </para>
			/// </summary>
			[CorrespondingType(typeof(FILE_COMPRESSION_INFO), CorrespondingAction.Get)]
			FileCompressionInfo,

			/// <summary>
			/// <para>
			/// File attribute information should be retrieved. Used for any handles. Use only when calling
			/// <c>GetFileInformationByHandleEx</c>. See <c>FILE_ATTRIBUTE_TAG_INFO</c>.
			/// </para>
			/// </summary>
			[CorrespondingType(typeof(FILE_ATTRIBUTE_TAG_INFO), CorrespondingAction.Get)]
			FileAttributeTagInfo,

			/// <summary>
			/// <para>
			/// Files in the specified directory should be retrieved. Used for directory handles. Use only when calling
			/// <c>GetFileInformationByHandleEx</c>. The number of files returned for each call to <c>GetFileInformationByHandleEx</c>
			/// depends on the size of the buffer that is passed to the function. Any subsequent calls to <c>GetFileInformationByHandleEx</c>
			/// on the same handle will resume the enumeration operation after the last file is returned. See <c>FILE_ID_BOTH_DIR_INFO</c>.
			/// </para>
			/// </summary>
			[CorrespondingType(typeof(FILE_ID_BOTH_DIR_INFO), CorrespondingAction.Get)]
			FileIdBothDirectoryInfo,

			/// <summary>
			/// <para>
			/// Identical to <c>FileIdBothDirectoryInfo</c>, but forces the enumeration operation to start again from the beginning. See <c>FILE_ID_BOTH_DIR_INFO</c>.
			/// </para>
			/// </summary>
			[CorrespondingType(typeof(FILE_ID_BOTH_DIR_INFO), CorrespondingAction.Get)]
			FileIdBothDirectoryRestartInfo,

			/// <summary>
			/// <para>Priority hint information should be set. Use only when calling <c>SetFileInformationByHandle</c>. See <c>FILE_IO_PRIORITY_HINT_INFO</c>.</para>
			/// </summary>
			[CorrespondingType(typeof(FILE_IO_PRIORITY_HINT_INFO), CorrespondingAction.Set)]
			FileIoPriorityHintInfo,

			/// <summary>
			/// <para>
			/// File remote protocol information should be retrieved. Use for any handles. Use only when calling
			/// <c>GetFileInformationByHandleEx</c>. See <c>FILE_REMOTE_PROTOCOL_INFO</c>.
			/// </para>
			/// </summary>
			[CorrespondingType(typeof(FILE_REMOTE_PROTOCOL_INFO), CorrespondingAction.Get)]
			FileRemoteProtocolInfo,

			/// <summary>
			/// <para>
			/// Files in the specified directory should be retrieved. Used for directory handles. Use only when calling
			/// <c>GetFileInformationByHandleEx</c>. See <c>FILE_FULL_DIR_INFO</c>.
			/// </para>
			/// <para>
			/// <c>Windows Server 2008 R2, Windows 7, Windows Server 2008, Windows Vista, Windows Server 2003 and Windows XP:</c> This value
			/// is not supported before Windows 8 and Windows Server 2012
			/// </para>
			/// </summary>
			[CorrespondingType(typeof(FILE_FULL_DIR_INFO), CorrespondingAction.Get)]
			FileFullDirectoryInfo,

			/// <summary>
			/// <para>
			/// Identical to <c>FileFullDirectoryInfo</c>, but forces the enumeration operation to start again from the beginning. Use only
			/// when calling <c>GetFileInformationByHandleEx</c>. See <c>FILE_FULL_DIR_INFO</c>.
			/// </para>
			/// <para>
			/// <c>Windows Server 2008 R2, Windows 7, Windows Server 2008, Windows Vista, Windows Server 2003 and Windows XP:</c> This value
			/// is not supported before Windows 8 and Windows Server 2012
			/// </para>
			/// </summary>
			[CorrespondingType(typeof(FILE_FULL_DIR_INFO), CorrespondingAction.Get)]
			FileFullDirectoryRestartInfo,

			/// <summary>
			/// <para>
			/// File storage information should be retrieved. Use for any handles. Use only when calling <c>GetFileInformationByHandleEx</c>.
			/// See <c>FILE_STORAGE_INFO</c>.
			/// </para>
			/// <para>
			/// <c>Windows Server 2008 R2, Windows 7, Windows Server 2008, Windows Vista, Windows Server 2003 and Windows XP:</c> This value
			/// is not supported before Windows 8 and Windows Server 2012
			/// </para>
			/// </summary>
			[CorrespondingType(typeof(FILE_STORAGE_INFO), CorrespondingAction.Get)]
			FileStorageInfo,

			/// <summary>
			/// <para>
			/// File alignment information should be retrieved. Use for any handles. Use only when calling
			/// <c>GetFileInformationByHandleEx</c>. See <c>FILE_ALIGNMENT_INFO</c>.
			/// </para>
			/// <para>
			/// <c>Windows Server 2008 R2, Windows 7, Windows Server 2008, Windows Vista, Windows Server 2003 and Windows XP:</c> This value
			/// is not supported before Windows 8 and Windows Server 2012
			/// </para>
			/// </summary>
			[CorrespondingType(typeof(FILE_ALIGNMENT_INFO), CorrespondingAction.Get)]
			FileAlignmentInfo,

			/// <summary>
			/// <para>
			/// File information should be retrieved. Use for any handles. Use only when calling <c>GetFileInformationByHandleEx</c>. See <c>FILE_ID_INFO</c>.
			/// </para>
			/// <para>
			/// <c>Windows Server 2008 R2, Windows 7, Windows Server 2008, Windows Vista, Windows Server 2003 and Windows XP:</c> This value
			/// is not supported before Windows 8 and Windows Server 2012
			/// </para>
			/// </summary>
			[CorrespondingType(typeof(FILE_ID_INFO), CorrespondingAction.Get)]
			FileIdInfo,

			/// <summary>
			/// <para>
			/// Files in the specified directory should be retrieved. Used for directory handles. Use only when calling
			/// <c>GetFileInformationByHandleEx</c>. See <c>FILE_ID_EXTD_DIR_INFO</c>.
			/// </para>
			/// <para>
			/// <c>Windows Server 2008 R2, Windows 7, Windows Server 2008, Windows Vista, Windows Server 2003 and Windows XP:</c> This value
			/// is not supported before Windows 8 and Windows Server 2012
			/// </para>
			/// </summary>
			[CorrespondingType(typeof(FILE_ID_EXTD_DIR_INFO), CorrespondingAction.Get)]
			FileIdExtdDirectoryInfo,

			/// <summary>
			/// <para>
			/// Identical to <c>FileIdExtdDirectoryInfo</c>, but forces the enumeration operation to start again from the beginning. Use only
			/// when calling <c>GetFileInformationByHandleEx</c>. See <c>FILE_ID_EXTD_DIR_INFO</c>.
			/// </para>
			/// <para>
			/// <c>Windows Server 2008 R2, Windows 7, Windows Server 2008, Windows Vista, Windows Server 2003 and Windows XP:</c> This value
			/// is not supported before Windows 8 and Windows Server 2012
			/// </para>
			/// </summary>
			[CorrespondingType(typeof(FILE_ID_EXTD_DIR_INFO), CorrespondingAction.Get)]
			FileIdExtdDirectoryRestartInfo,

			/// <summary>
			/// <para>This value is used for validation. Supported values are less than this value.</para>
			/// </summary>
			MaximumFileInfoByHandlesClass,
		}

		/// <summary>The type of result to return.</summary>
		[PInvokeData("WinBase.h")]
		[Flags]
		public enum FinalPathNameOptions
		{
			/// <summary>Return the path with the drive letter. This is the default.</summary>
			VOLUME_NAME_DOS = 0x0,

			/// <summary>Return the path with a volume GUID path instead of the drive name.</summary>
			VOLUME_NAME_GUID = 0x1,

			/// <summary>Return the path with the volume device path.</summary>
			VOLUME_NAME_NT = 0x2,

			/// <summary>Return the path with no drive information.</summary>
			VOLUME_NAME_NONE = 0x4,

			/// <summary>Return the normalized drive name. This is the default.</summary>
			FILE_NAME_NORMALIZED = 0x0,

			/// <summary>Return the opened file name (not normalized).</summary>
			FILE_NAME_OPENED = 0x8,
		}

		/// <summary>MoveFileEx options.</summary>
		[Flags]
		public enum MOVEFILE : uint
		{
			/// <summary>
			/// If a file named lpNewFileName exists, the function replaces its contents with the contents of the lpExistingFileName file,
			/// provided that security requirements regarding access control lists (ACLs) are met. For more information, see the Remarks
			/// section of this topic.This value cannot be used if lpNewFileName or lpExistingFileName names a directory.
			/// </summary>
			MOVEFILE_REPLACE_EXISTING = 0x00000001,

			/// <summary>
			/// If the file is to be moved to a different volume, the function simulates the move by using the CopyFile and DeleteFile
			/// functions.If the file is successfully copied to a different volume and the original file is unable to be deleted, the
			/// function succeeds leaving the source file intact.This value cannot be used with MOVEFILE_DELAY_UNTIL_REBOOT.
			/// </summary>
			MOVEFILE_COPY_ALLOWED = 0x00000002,

			/// <summary>
			/// The system does not move the file until the operating system is restarted. The system moves the file immediately after
			/// AUTOCHK is executed, but before creating any paging files. Consequently, this parameter enables the function to delete paging
			/// files from previous startups.This value can be used only if the process is in the context of a user who belongs to the
			/// administrators group or the LocalSystem account. This value cannot be used with MOVEFILE_COPY_ALLOWED.Windows Server 2003 and
			/// Windows XP: For information about special situations where this functionality can fail, and a suggested workaround solution,
			/// see Files are not exchanged when Windows Server 2003 restarts if you use the MoveFileEx function to schedule a replacement
			/// for some files in the Help and Support Knowledge Base.
			/// </summary>
			MOVEFILE_DELAY_UNTIL_REBOOT = 0x00000004,

			/// <summary>
			/// The function does not return until the file is actually moved on the disk.Setting this value guarantees that a move performed
			/// as a copy and delete operation is flushed to disk before the function returns. The flush occurs at the end of the copy
			/// operation.This value has no effect if MOVEFILE_DELAY_UNTIL_REBOOT is set.
			/// </summary>
			MOVEFILE_WRITE_THROUGH = 0x00000008,

			/// <summary>Reserved for future use.</summary>
			MOVEFILE_CREATE_HARDLINK = 0x00000010,

			/// <summary>
			/// The function fails if the source file is a link source, but the file cannot be tracked after the move. This situation can
			/// occur if the destination is a volume formatted with the FAT file system.
			/// </summary>
			MOVEFILE_FAIL_IF_NOT_TRACKABLE = 0x00000020
		}

		/// <summary>
		/// <para>The <c>IO_PRIORITY_HINT</c> enumeration type specifies the priority hint for an IRP.</para>
		/// </summary>
		/// <remarks>
		/// <para>For more information about priority hints, see Using IRP Priority Hints.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows-hardware/drivers/ddi/content/wdm/ne-wdm-_io_priority_hint typedef enum _IO_PRIORITY_HINT
		// { IoPriorityVeryLow , IoPriorityLow , IoPriorityNormal , IoPriorityHigh , IoPriorityCritical , MaxIoPriorityTypes } IO_PRIORITY_HINT;
		[PInvokeData("wdm.h", MSDNShortId = "38d19398-b34f-4934-b643-df119ebd9711")]
		public enum PRIORITY_HINT
		{
			/// <summary>Specifies the lowest possible priority hint level. The system uses this value for background I/O operations.</summary>
			IoPriorityVeryLow,

			/// <summary>Specifies a low-priority hint level.</summary>
			IoPriorityLow,

			/// <summary>Specifies a normal-priority hint level. This value is the default setting for an IRP.</summary>
			IoPriorityNormal,

			/// <summary>Specifies a high-priority hint level. This value is reserved for use by the system.</summary>
			IoPriorityHigh,

			/// <summary>Specifies the highest-priority hint level. This value is reserved for use by the system.</summary>
			IoPriorityCritical,

			/// <summary>Marks the limit for priority hints. Any priority hint value must be less than MaxIoPriorityTypes.</summary>
			MaxIoPriorityTypes,
		}

		/// <summary>
		/// <para>Indicates the possible types of information that an application that calls the ReadDirectoryChangesExW function can request.</para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/minwinbase/ne-minwinbase-_read_directory_notify_information_class typedef
		// enum _READ_DIRECTORY_NOTIFY_INFORMATION_CLASS { ReadDirectoryNotifyInformation , ReadDirectoryNotifyExtendedInformation }
		// READ_DIRECTORY_NOTIFY_INFORMATION_CLASS, *PREAD_DIRECTORY_NOTIFY_INFORMATION_CLASS;
		[PInvokeData("minwinbase.h", MSDNShortId = "193D018B-80FE-45B2-826A-A00D173E32D3")]
		public enum READ_DIRECTORY_NOTIFY_INFORMATION_CLASS
		{
			/// <summary>
			/// The ReadDirectoryChangesExW function should provide information that describes the changes within the specified directory,
			/// and return this information in the output buffer in the form of FILE_NOTIFY_INFORMATION structures.
			/// </summary>
			ReadDirectoryNotifyInformation,

			/// <summary>
			/// The ReadDirectoryChangesExW function should provide extended information that describes the changes within the specified
			/// directory, and return this information in the output buffer in the form of FILE_NOTIFY_EXTENDED_INFORMATION structures.
			/// </summary>
			ReadDirectoryNotifyExtendedInformation,
		}

		/// <summary>Flags used by <see cref="FILE_REMOTE_PROTOCOL_INFO"/>.</summary>
		[Flags]
		public enum RemoteProtocol
		{
			/// <summary>The remote protocol is using a loopback.</summary>
			REMOTE_PROTOCOL_FLAG_LOOPBACK = 0x1,

			/// <summary>The remote protocol is using an offline cache.</summary>
			REMOTE_PROTOCOL_FLAG_OFFLINE = 0x2,

			/// <summary>
			/// The remote protocol is using a persistent handle.
			/// <para>Windows 7 and Windows Server 2008 R2: This flag is not supported before Windows 8 and Windows Server 2012.</para>
			/// </summary>
			REMOTE_PROTOCOL_INFO_FLAG_PERSISTENT_HANDLE = 0x4,

			/// <summary>
			/// The remote protocol is using privacy. This is only supported if the StructureVersion member is 2 or higher.
			/// <para>Windows 7 and Windows Server 2008 R2: This flag is not supported before Windows 8 and Windows Server 2012.</para>
			/// </summary>
			REMOTE_PROTOCOL_INFO_FLAG_PRIVACY = 0x8,

			/// <summary>
			/// The remote protocol is using integrity so the data is signed. This is only supported if the StructureVersion member is 2 or higher.
			/// <para>Windows 7 and Windows Server 2008 R2: This flag is not supported before Windows 8 and Windows Server 2012.</para>
			/// </summary>
			REMOTE_PROTOCOL_INFO_FLAG_INTEGRITY = 0x10,

			/// <summary>
			/// The remote protocol is using mutual authentication using Kerberos. This is only supported if the StructureVersion member is 2
			/// or higher.
			/// <para>Windows 7 and Windows Server 2008 R2: This flag is not supported before Windows 8 and Windows Server 2012.</para>
			/// </summary>
			REMOTE_PROTOCOL_INFO_FLAG_MUTUAL_AUTH = 0x20,
		}

		/// <summary>ReplaceFile options.</summary>
		public enum REPLACEFILE
		{
			/// <summary>This value is not supported.</summary>
			REPLACEFILE_WRITE_THROUGH = 0x00000001,

			/// <summary>
			/// Ignores errors that occur while merging information (such as attributes and ACLs) from the replaced file to the replacement
			/// file. Therefore, if you specify this flag and do not have WRITE_DAC access, the function succeeds but the ACLs are not preserved.
			/// </summary>
			REPLACEFILE_IGNORE_MERGE_ERRORS = 0x00000002,

			/// <summary>
			/// Ignores errors that occur while merging ACL information from the replaced file to the replacement file. Therefore, if you
			/// specify this flag and do not have WRITE_DAC access, the function succeeds but the ACLs are not preserved. To compile an
			/// application that uses this value, define the _WIN32_WINNT macro as 0x0600 or later.
			/// <para>Windows Server 2003 and Windows XP: This value is not supported.</para>
			/// </summary>
			REPLACEFILE_IGNORE_ACL_ERRORS = 0x00000004,
		}

		/// <summary>Flags used by <see cref="FILE_STORAGE_INFO"/>.</summary>
		[Flags]
		public enum StorageInfoFlags
		{
			/// <summary>
			/// When set, this flag indicates that the logical sectors of the storage device are aligned to physical sector boundaries.
			/// </summary>
			STORAGE_INFO_FLAGS_ALIGNED_DEVICE = 0x00000001,

			/// <summary>When set, this flag indicates that the partition is aligned to physical sector boundaries on the storage device.</summary>
			STORAGE_INFO_FLAGS_PARTITION_ALIGNED_ON_DEVICE = 0x00000002,
		}

		/// <summary>
		/// <para>
		/// Defines values that are used with the <c>FindFirstStreamW</c> function to specify the information level of the returned data.
		/// </para>
		/// </summary>
		// typedef enum _STREAM_INFO_LEVELS { FindStreamInfoStandard = 0, FindStreamInfoMaxInfoLevel = 1} STREAM_INFO_LEVELS;
		[PInvokeData("WinBase.h", MSDNShortId = "aa365675")]
		public enum STREAM_INFO_LEVELS
		{
			/// <summary>
			/// <para>
			/// The <c>FindFirstStreamW</c> function retrieves standard stream information. The data is returned in a
			/// <c>WIN32_FIND_STREAM_DATA</c> structure.
			/// </para>
			/// </summary>
			FindStreamInfoStandard,
		}

		/// <summary>Flags used in the <see cref="CreateSymbolicLink"/> function.</summary>
		[PInvokeData("WinBase.h")]
		public enum SymbolicLinkType : uint
		{
			/// <summary>The link target is a file.</summary>
			SYMBOLIC_LINK_FLAG_FILE = 0x0,

			/// <summary>The link target is a directory.</summary>
			SYMBOLIC_LINK_FLAG_DIRECTORY = 0x1
		}

		/// <summary>
		/// <para>
		/// Determines whether the file I/O functions are using the ANSI or OEM character set code page. This function is useful for 8-bit
		/// console input and output operations.
		/// </para>
		/// </summary>
		/// <returns>
		/// <para>If the set of file I/O functions is using the ANSI code page, the return value is nonzero.</para>
		/// <para>If the set of file I/O functions is using the OEM code page, the return value is zero.</para>
		/// </returns>
		// BOOL WINAPI AreFileApisANSI(void);
		[DllImport(Lib.Kernel32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("WinBase.h", MSDNShortId = "aa363781")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool AreFileApisANSI();

		/// <summary>Determines whether the specified name can be used to create a file on a FAT file system.</summary>
		/// <param name="lpName">The file name, in 8.3 format.</param>
		/// <param name="lpOemName">
		/// A pointer to a buffer that receives the OEM string that corresponds to Name. This parameter can be <c>NULL</c>.
		/// </param>
		/// <param name="OemNameSize">
		/// The size of the lpOemName buffer, in characters. If lpOemName is <c>NULL</c>, this parameter must be 0 (zero).
		/// </param>
		/// <param name="pbNameContainsSpaces">
		/// Indicates whether or not a name contains spaces. This parameter can be <c>NULL</c>. If the name is not a valid 8.3 FAT file
		/// system name, this parameter is undefined.
		/// </param>
		/// <param name="pbNameLegal">
		/// If the function succeeds, this parameter indicates whether a file name is a valid 8.3 FAT file name when the current OEM code
		/// page is applied to the file name.
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is nonzero.</para>
		/// <para>If the function fails, the return value is 0 (zero). To get extended error information, call <c>GetLastError</c>.</para>
		/// </returns>
		// BOOL WINAPI CheckNameLegalDOS8Dot3( _In_ LPCTSTR lpName, _Out_opt_ LPSTR lpOemName, _In_ DWORD OemNameSize, _Out_opt_ PBOOL
		// pbNameContainsSpaces, _Out_ PBOOL pbNameLegal); https://msdn.microsoft.com/en-us/library/windows/desktop/aa363807(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = true, CharSet = CharSet.Auto)]
		[PInvokeData("WinBase.h", MSDNShortId = "aa363807")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool CheckNameLegalDOS8Dot3(string lpName, [MarshalAs(UnmanagedType.LPStr)] StringBuilder lpOemName, uint OemNameSize, [MarshalAs(UnmanagedType.Bool)] out bool pbNameContainsSpaces, [MarshalAs(UnmanagedType.Bool)] out bool pbNameLegal);

		/// <summary>
		/// <para>Copies an existing file to a new file.</para>
		/// <para>
		/// The <c>CopyFileEx</c> function provides two additional capabilities. <c>CopyFileEx</c> can call a specified callback function
		/// each time a portion of the copy operation is completed, and <c>CopyFileEx</c> can be canceled during the copy operation.
		/// </para>
		/// <para>To perform this operation as a transacted operation, use the <c>CopyFileTransacted</c> function.</para>
		/// </summary>
		/// <param name="lpExistingFileName">
		/// <para>The name of an existing file.</para>
		/// <para>
		/// In the ANSI version of this function, the name is limited to <c>MAX_PATH</c> characters. To extend this limit to 32,767 wide
		/// characters, call the Unicode version of the function and prepend "\\?\" to the path. For more information, see Naming a File.
		/// </para>
		/// <para>If lpExistingFileName does not exist, <c>CopyFile</c> fails, and <c>GetLastError</c> returns <c>ERROR_FILE_NOT_FOUND</c>.</para>
		/// </param>
		/// <param name="lpNewFileName">
		/// <para>The name of the new file.</para>
		/// <para>
		/// In the ANSI version of this function, the name is limited to <c>MAX_PATH</c> characters. To extend this limit to 32,767 wide
		/// characters, call the Unicode version of the function and prepend "\\?\" to the path. For more information, see Naming a File.
		/// </para>
		/// </param>
		/// <param name="bFailIfExists">
		/// If this parameter is <c>TRUE</c> and the new file specified by lpNewFileName already exists, the function fails. If this
		/// parameter is <c>FALSE</c> and the new file already exists, the function overwrites the existing file and succeeds.
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is nonzero.</para>
		/// <para>If the function fails, the return value is zero. To get extended error information, call <c>GetLastError</c>.</para>
		/// </returns>
		// BOOL WINAPI CopyFile( _In_ LPCTSTR lpExistingFileName, _In_ LPCTSTR lpNewFileName, _In_ BOOL bFailIfExists); https://msdn.microsoft.com/en-us/library/windows/desktop/aa363851(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = true, CharSet = CharSet.Auto)]
		[PInvokeData("WinBase.h", MSDNShortId = "aa363851")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool CopyFile(string lpExistingFileName, string lpNewFileName, [MarshalAs(UnmanagedType.Bool)] bool bFailIfExists);

		/// <summary>
		/// <para>Copies an existing file to a new file, notifying the application of its progress through a callback function.</para>
		/// </summary>
		/// <param name="pwszExistingFileName">
		/// <para>The name of an existing file.</para>
		/// <para>
		/// To extend this limit to 32,767 wide characters, prepend "\?" to the path. For more information, see Naming Files, Paths, and Namespaces.
		/// </para>
		/// <para>
		/// <c>Tip</c> Starting in Windows 10, version 1607, you can opt-in to remove the <c>MAX_PATH</c> character limitation without
		/// prepending "\\?\". See the "Maximum Path Limitation" section of Naming Files, Paths, and Namespaces for details.
		/// </para>
		/// <para>If</para>
		/// <para>lpExistingFileName</para>
		/// <para>does not exist, the</para>
		/// <para>CopyFile2</para>
		/// <para>function fails returns</para>
		/// <para>HRESULT_FROM_WIN32(ERROR_FILE_NOT_FOUND)</para>
		/// <para>.</para>
		/// </param>
		/// <param name="pwszNewFileName">
		/// <para>The name of the new file.</para>
		/// <para>
		/// To extend this limit to 32,767 wide characters, prepend "\?" to the path. For more information, see Naming Files, Paths, and Namespaces.
		/// </para>
		/// <para>
		/// <c>Tip</c> Starting in Windows 10, version 1607, you can opt-in to remove the <c>MAX_PATH</c> character limitation without
		/// prepending "\\?\". See the "Maximum Path Limitation" section of Naming Files, Paths, and Namespaces for details.
		/// </para>
		/// </param>
		/// <param name="pExtendedParameters">
		/// <para>Optional address of a COPYFILE2_EXTENDED_PARAMETERS structure.</para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value will return <c>TRUE</c> when passed to the SUCCEEDED macro.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The copy operation completed successfully.</term>
		/// </item>
		/// <item>
		/// <term>HRESULT_FROM_WIN32(ERROR_REQUEST_PAUSED)</term>
		/// <term>The copy operation was paused by a COPYFILE2_PROGRESS_PAUSE return from the CopyFile2ProgressRoutine callback function.</term>
		/// </item>
		/// <item>
		/// <term>HRESULT_FROM_WIN32(ERROR_REQUEST_ABORTED)</term>
		/// <term>
		/// The copy operation was paused by a COPYFILE2_PROGRESS_CANCEL or COPYFILE2_PROGRESS_STOP return from the CopyFile2ProgressRoutine
		/// callback function.
		/// </term>
		/// </item>
		/// <item>
		/// <term>HRESULT_FROM_WIN32(ERROR_ALREADY_EXISTS)</term>
		/// <term>
		/// The dwCopyFlags member of the COPYFILE2_EXTENDED_PARAMETERS structure passed through the parameter contains the
		/// COPY_FILE_FAIL_IF_EXISTS flag and a conflicting name existed.
		/// </term>
		/// </item>
		/// <item>
		/// <term>HRESULT_FROM_WIN32(ERROR_FILE_EXISTS)</term>
		/// <term>
		/// The dwCopyFlags member of the COPYFILE2_EXTENDED_PARAMETERS structure passed through the parameter contains the
		/// COPY_FILE_FAIL_IF_EXISTS flag and a conflicting name existed.
		/// </term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// This function preserves extended attributes, OLE structured storage, NTFS file system alternate data streams, and file
		/// attributes. Security attributes for the existing file are not copied to the new file. To copy security attributes, use the
		/// SHFileOperation function.
		/// </para>
		/// <para>
		/// This function fails with if the destination file already exists and has the <c>FILE_ATTRIBUTE_HIDDEN</c> or
		/// <c>FILE_ATTRIBUTE_READONLY</c> attribute set.
		/// </para>
		/// <para>
		/// To compile an application that uses this function, define the <c>_WIN32_WINNT</c> macro as <c>_WIN32_WINNT_WIN8</c> or later. For
		/// more information, see Using the Windows Headers.
		/// </para>
		/// <para>In Windows 8 and Windows Server 2012, this function is supported by the following technologies.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Technology</term>
		/// <term>Supported</term>
		/// </listheader>
		/// <item>
		/// <term>Server Message Block (SMB) 3.0 protocol</term>
		/// <term>Yes</term>
		/// </item>
		/// <item>
		/// <term>SMB 3.0 Transparent Failover (TFO)</term>
		/// <term>Yes</term>
		/// </item>
		/// <item>
		/// <term>SMB 3.0 with Scale-out File Shares (SO)</term>
		/// <term>Yes</term>
		/// </item>
		/// <item>
		/// <term>Cluster Shared Volume File System (CsvFS)</term>
		/// <term>Yes</term>
		/// </item>
		/// <item>
		/// <term>Resilient File System (ReFS)</term>
		/// <term>Yes</term>
		/// </item>
		/// </list>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winbase/nf-winbase-copyfile2 HRESULT CopyFile2( PCWSTR pwszExistingFileName,
		// PCWSTR pwszNewFileName, COPYFILE2_EXTENDED_PARAMETERS *pExtendedParameters );
		[DllImport(Lib.Kernel32, SetLastError = false, ExactSpelling = true, CharSet = CharSet.Unicode)]
		[PInvokeData("winbase.h", MSDNShortId = "aa2df686-4b61-4d90-ba0b-c78c5a0d2d59")]
		public static extern HRESULT CopyFile2(string pwszExistingFileName, string pwszNewFileName, ref COPYFILE2_EXTENDED_PARAMETERS pExtendedParameters);

		/// <summary>
		/// <para>Copies an existing file to a new file, notifying the application of its progress through a callback function.</para>
		/// <para>To perform this operation as a transacted operation, use the <c>CopyFileTransacted</c> function.</para>
		/// </summary>
		/// <param name="lpExistingFileName">
		/// <para>The name of an existing file.</para>
		/// <para>
		/// In the ANSI version of this function, the name is limited to <c>MAX_PATH</c> characters. To extend this limit to 32,767 wide
		/// characters, call the Unicode version of the function and prepend "\\?\" to the path. For more information, see Naming a File.
		/// </para>
		/// <para>
		/// If lpExistingFileName does not exist, the <c>CopyFileEx</c> function fails, and the <c>GetLastError</c> function returns <c>ERROR_FILE_NOT_FOUND</c>.
		/// </para>
		/// </param>
		/// <param name="lpNewFileName">
		/// <para>The name of the new file.</para>
		/// <para>
		/// In the ANSI version of this function, the name is limited to <c>MAX_PATH</c> characters. To extend this limit to 32,767 wide
		/// characters, call the Unicode version of the function and prepend "\\?\" to the path. For more information, see Naming a File.
		/// </para>
		/// </param>
		/// <param name="lpProgressRoutine">
		/// The address of a callback function of type <c>LPPROGRESS_ROUTINE</c> that is called each time another portion of the file has
		/// been copied. This parameter can be <c>NULL</c>. For more information on the progress callback function, see the
		/// <c>CopyProgressRoutine</c> function.
		/// </param>
		/// <param name="lpData">The argument to be passed to the callback function. This parameter can be <c>NULL</c>.</param>
		/// <param name="pbCancel">
		/// If this flag is set to <c>TRUE</c> during the copy operation, the operation is canceled. Otherwise, the copy operation will
		/// continue to completion.
		/// </param>
		/// <param name="dwCopyFlags">
		/// <para>Flags that specify how the file is to be copied. This parameter can be a combination of the following values.</para>
		/// <para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>COPY_FILE_ALLOW_DECRYPTED_DESTINATION0x00000008</term>
		/// <term>An attempt to copy an encrypted file will succeed even if the destination copy cannot be encrypted.</term>
		/// </item>
		/// <item>
		/// <term>COPY_FILE_COPY_SYMLINK0x00000800</term>
		/// <term>
		/// If the source file is a symbolic link, the destination file is also a symbolic link pointing to the same file that the source
		/// symbolic link is pointing to. Windows Server 2003 and Windows XP: This value is not supported.
		/// </term>
		/// </item>
		/// <item>
		/// <term>COPY_FILE_FAIL_IF_EXISTS0x00000001</term>
		/// <term>The copy operation fails immediately if the target file already exists.</term>
		/// </item>
		/// <item>
		/// <term>COPY_FILE_NO_BUFFERING0x00001000</term>
		/// <term>
		/// The copy operation is performed using unbuffered I/O, bypassing system I/O cache resources. Recommended for very large file
		/// transfers. Windows Server 2003 and Windows XP: This value is not supported.
		/// </term>
		/// </item>
		/// <item>
		/// <term>COPY_FILE_OPEN_SOURCE_FOR_WRITE0x00000004</term>
		/// <term>The file is copied and the original file is opened for write access.</term>
		/// </item>
		/// <item>
		/// <term>COPY_FILE_RESTARTABLE0x00000002</term>
		/// <term>
		/// Progress of the copy is tracked in the target file in case the copy fails. The failed copy can be restarted at a later time by
		/// specifying the same values for lpExistingFileName and lpNewFileName as those used in the call that failed. This can significantly
		/// slow down the copy operation as the new file may be flushed multiple times during the copy operation.
		/// </term>
		/// </item>
		/// </list>
		/// </para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is nonzero.</para>
		/// <para>If the function fails, the return value is zero. To get extended error information call <c>GetLastError</c>.</para>
		/// <para>
		/// If lpProgressRoutine returns <c>PROGRESS_CANCEL</c> due to the user canceling the operation, <c>CopyFileEx</c> will return zero
		/// and <c>GetLastError</c> will return <c>ERROR_REQUEST_ABORTED</c>. In this case, the partially copied destination file is deleted.
		/// </para>
		/// <para>
		/// If lpProgressRoutine returns <c>PROGRESS_STOP</c> due to the user stopping the operation, <c>CopyFileEx</c> will return zero and
		/// <c>GetLastError</c> will return <c>ERROR_REQUEST_ABORTED</c>. In this case, the partially copied destination file is left intact.
		/// </para>
		/// </returns>
		// BOOL WINAPI CopyFileEx( _In_ LPCTSTR lpExistingFileName, _In_ LPCTSTR lpNewFileName, _In_opt_ LPPROGRESS_ROUTINE
		// lpProgressRoutine, _In_opt_ LPVOID lpData, _In_opt_ LPBOOL pbCancel, _In_ DWORD dwCopyFlags); https://msdn.microsoft.com/en-us/library/windows/desktop/aa363852(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = true, CharSet = CharSet.Auto)]
		[PInvokeData("WinBase.h", MSDNShortId = "aa363852")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool CopyFileEx(string lpExistingFileName, string lpNewFileName, CopyProgressRoutine lpProgressRoutine, [In] IntPtr lpData, [MarshalAs(UnmanagedType.Bool)] in bool pbCancel, COPY_FILE dwCopyFlags);

		/// <summary>
		/// <para>
		/// Creates a new directory with the attributes of a specified template directory. If the underlying file system supports security on
		/// files and directories, the function applies a specified security descriptor to the new directory. The new directory retains the
		/// other attributes of the specified template directory.
		/// </para>
		/// <para>To perform this operation as a transacted operation, use the <c>CreateDirectoryTransacted</c> function.</para>
		/// </summary>
		/// <param name="lpTemplateDirectory">
		/// <para>The path of the directory to use as a template when creating the new directory.</para>
		/// <para>
		/// In the ANSI version of this function, the name is limited to <c>MAX_PATH</c> characters. To extend this limit to 32,767 wide
		/// characters, call the Unicode version of the function and prepend "\\?\" to the path. For more information, see Naming a File.
		/// </para>
		/// </param>
		/// <param name="lpNewDirectory">
		/// <para>The path of the directory to be created.</para>
		/// <para>
		/// In the ANSI version of this function, the name is limited to <c>MAX_PATH</c> characters. To extend this limit to 32,767 wide
		/// characters, call the Unicode version of the function and prepend "\\?\" to the path. For more information, see Naming a File.
		/// </para>
		/// </param>
		/// <param name="lpSecurityAttributes">
		/// <para>
		/// A pointer to a <c>SECURITY_ATTRIBUTES</c> structure. The <c>lpSecurityDescriptor</c> member of the structure specifies a security
		/// descriptor for the new directory.
		/// </para>
		/// <para>
		/// If lpSecurityAttributes is <c>NULL</c>, the directory gets a default security descriptor. The access control lists (ACL) in the
		/// default security descriptor for a directory are inherited from its parent directory.
		/// </para>
		/// <para>
		/// The target file system must support security on files and directories for this parameter to have an effect. This is indicated
		/// when <c>GetVolumeInformation</c> returns <c>FS_PERSISTENT_ACLS</c>.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is nonzero.</para>
		/// <para>
		/// If the function fails, the return value is zero (0). To get extended error information, call <c>GetLastError</c>. Possible errors
		/// include the following.
		/// </para>
		/// <para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>ERROR_ALREADY_EXISTS</term>
		/// <term>The specified directory already exists.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_PATH_NOT_FOUND</term>
		/// <term>
		/// One or more intermediate directories do not exist. This function only creates the final directory in the path. To create all
		/// intermediate directories on the path, use the SHCreateDirectoryEx function.
		/// </term>
		/// </item>
		/// </list>
		/// </para>
		/// </returns>
		// BOOL WINAPI CreateDirectoryEx( _In_ LPCTSTR lpTemplateDirectory, _In_ LPCTSTR lpNewDirectory, _In_opt_ LPSECURITY_ATTRIBUTES
		// lpSecurityAttributes); https://msdn.microsoft.com/en-us/library/windows/desktop/aa363856(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = true, CharSet = CharSet.Auto)]
		[PInvokeData("WinBase.h", MSDNShortId = "aa363856")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool CreateDirectoryEx(string lpTemplateDirectory, string lpNewDirectory, [In] SECURITY_ATTRIBUTES lpSecurityAttributes);

		/// <summary>
		/// Establishes a hard link between an existing file and a new file. This function is only supported on the NTFS file system, and
		/// only for files, not directories.
		/// </summary>
		/// <param name="lpFileName">
		/// The name of the new file.
		/// <para>This parameter may include the path but cannot specify the name of a directory.</para>
		/// <para>
		/// In the ANSI version of this function, the name is limited to <c>MAX_PATH</c> characters. To extend this limit to 32,767 wide
		/// characters, call the Unicode version of the function and prepend "\\?\" to the path. For more information, see Naming a File.
		/// </para>
		/// <note><c>Tip</c> Starting with Windows 10, version 1607, for the Unicode version of this function ( <c>CreateHardLinkW</c>), you
		/// can opt-in to remove the <c>MAX_PATH</c> limitation without prepending "\\?\". See the "Maximum Path Length Limitation" section
		/// of Naming Files, Paths, and Namespaces for details.</note>
		/// </param>
		/// <param name="lpExistingFileName">
		/// The name of the existing file.
		/// <para>This parameter may include the path but cannot specify the name of a directory.</para>
		/// <para>
		/// In the ANSI version of this function, the name is limited to <c>MAX_PATH</c> characters. To extend this limit to 32,767 wide
		/// characters, call the Unicode version of the function and prepend "\\?\" to the path. For more information, see Naming a File.
		/// </para>
		/// <note><c>Tip</c> Starting with Windows 10, version 1607, for the Unicode version of this function ( <c>CreateHardLinkW</c>), you
		/// can opt-in to remove the <c>MAX_PATH</c> limitation without prepending "\\?\". See the "Maximum Path Length Limitation" section
		/// of Naming Files, Paths, and Namespaces for details.</note>
		/// </param>
		/// <param name="lpSecurityAttributes">Reserved; must be NULL.</param>
		/// <returns></returns>
		[DllImport(Lib.Kernel32, CharSet = CharSet.Auto, SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		[PInvokeData("WinBase.h", MSDNShortId = "aa363860")]
		public static extern bool CreateHardLink(string lpFileName, string lpExistingFileName, [Optional] SECURITY_ATTRIBUTES lpSecurityAttributes);

		/// <summary>Creates a symbolic link.</summary>
		/// <param name="lpSymlinkFileName">
		/// The symbolic link to be created.
		/// <para>
		/// This parameter may include the path. In the ANSI version of this function, the name is limited to <c>MAX_PATH</c> characters. To
		/// extend this limit to 32,767 wide characters, call the Unicode version of the function and prepend "\\?\" to the path. For more
		/// information, see Naming a File.
		/// </para>
		/// <note><c>Tip</c> Starting with Windows 10, version 1607, for the Unicode version of this function ( <c>CreateSymbolicLinkW</c>),
		/// you can opt-in to remove the <c>MAX_PATH</c> limitation without prepending "\\?\". See the "Maximum Path Length Limitation"
		/// section of Naming Files, Paths, and Namespaces for details.</note>
		/// </param>
		/// <param name="lpTargetFileName">
		/// The name of the target for the symbolic link to be created.
		/// <para>
		/// If lpTargetFileName has a device name associated with it, the link is treated as an absolute link; otherwise, the link is treated
		/// as a relative link.
		/// </para>
		/// <para>
		/// This parameter may include the path. In the ANSI version of this function, the name is limited to <c>MAX_PATH</c> characters. To
		/// extend this limit to 32,767 wide characters, call the Unicode version of the function and prepend "\\?\" to the path. For more
		/// information, see Naming a File.
		/// </para>
		/// <note><c>Tip</c> Starting with Windows 10, version 1607, for the Unicode version of this function ( <c>CreateSymbolicLinkW</c>),
		/// you can opt-in to remove the <c>MAX_PATH</c> limitation without prepending "\\?\". See the "Maximum Path Length Limitation"
		/// section of Naming Files, Paths, and Namespaces for details.</note>
		/// </param>
		/// <param name="dwFlags">Indicates whether the link target, lpTargetFileName, is a directory.</param>
		/// <returns>
		/// f the function succeeds, the return value is nonzero. If the function fails, the return value is zero.To get extended error
		/// information, call GetLastError.
		/// </returns>
		[DllImport(Lib.Kernel32, CharSet = CharSet.Auto, SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		[PInvokeData("WinBase.h", MSDNShortId = "aa363866")]
		public static extern bool CreateSymbolicLink(string lpSymlinkFileName, string lpTargetFileName, SymbolicLinkType dwFlags);

		/// <summary>Creates an enumeration of all the hard links to the specified file.</summary>
		/// <param name="fileName">The name of the file.</param>
		/// <returns>An enumeration of all the hard links to the specified file.</returns>
		public static IEnumerable<string> EnumFileLinks(string fileName) => EnumFindMethods((StringBuilder sb, ref uint sz) => FindFirstFileName(fileName, 0, ref sz, sb), (SafeSearchHandle h, StringBuilder sb, ref uint sz) => FindNextFileName(h, ref sz, sb));

		/// <summary>Enumerates the streams in the specified file or directory.</summary>
		/// <param name="fileName">The fully qualified file name.</param>
		/// <returns>The streams in the specified file or directory.</returns>
		public static IEnumerable<WIN32_FIND_STREAM_DATA> EnumFileStreams(string fileName)
		{
			var h = FindFirstStream(fileName, STREAM_INFO_LEVELS.FindStreamInfoStandard, out var data);
			if (h.IsInvalid)
			{
				var err = Win32Error.GetLastError();
				if (err == Win32Error.ERROR_HANDLE_EOF)
					yield break;
				else
					err.ThrowIfFailed();
			}
			while (FindNextStream(h, out data))
				yield return data;
			var err2 = Win32Error.GetLastError();
			if (err2 != Win32Error.ERROR_HANDLE_EOF)
				err2.ThrowIfFailed();
		}

		/// <summary>Retrieves the names of all mounted folders on the specified volume.</summary>
		/// <param name="volumeGuidPath">A volume GUID path for the volume to scan for mounted folders. A trailing backslash is required.</param>
		/// <returns>The names of the mounted folders that are found.</returns>
		public static IEnumerable<string> EnumVolumeMountPoints(string volumeGuidPath) => EnumFindMethods((StringBuilder sb, ref uint sz) => FindFirstVolumeMountPoint(volumeGuidPath, sb, sz), (SafeVolumeMountPointHandle h, StringBuilder sb, ref uint sz) => FindNextVolumeMountPoint(h, sb, sz));

		/// <summary>
		/// <para>
		/// Creates an enumeration of all the hard links to the specified file. The <c>FindFirstFileNameW</c> function returns a handle to
		/// the enumeration that can be used on subsequent calls to the <c>FindNextFileNameW</c> function.
		/// </para>
		/// <para>To perform this operation as a transacted operation, use the <c>FindFirstFileNameTransactedW</c> function.</para>
		/// </summary>
		/// <param name="lpFileName">
		/// <para>The name of the file.</para>
		/// </param>
		/// <param name="dwFlags">
		/// <para>Reserved; specify zero (0).</para>
		/// </param>
		/// <param name="StringLength">
		/// <para>
		/// The size of the buffer pointed to by the LinkName parameter, in characters. If this call fails and the error returned from the
		/// <c>GetLastError</c> function is <c>ERROR_MORE_DATA</c> (234), the value that is returned by this parameter is the size that the
		/// buffer pointed to by LinkName must be to contain all the data.
		/// </para>
		/// </param>
		/// <param name="LinkName">
		/// <para>A pointer to a buffer to store the first link name found for lpFileName.</para>
		/// </param>
		/// <returns>
		/// <para>
		/// If the function succeeds, the return value is a search handle that can be used with the <c>FindNextFileNameW</c> function or
		/// closed with the <c>FindClose</c> function.
		/// </para>
		/// <para>
		/// If the function fails, the return value is <c>INVALID_HANDLE_VALUE</c> (0xffffffff). To get extended error information, call the
		/// <c>GetLastError</c> function.
		/// </para>
		/// </returns>
		// HANDLE WINAPI FindFirstFileNameW( _In_ LPCWSTR lpFileName, _In_ DWORD dwFlags, _Inout_ LPDWORD StringLength, _Inout_ PWCHAR LinkName);
		[DllImport(Lib.Kernel32, SetLastError = true, EntryPoint = "FindFirstFileNameW", CharSet = CharSet.Unicode)]
		[PInvokeData("WinBase.h", MSDNShortId = "aa364421")]
		public static extern SafeSearchHandle FindFirstFileName(string lpFileName, [Optional] uint dwFlags, ref uint StringLength, StringBuilder LinkName);

		/// <summary>
		/// <para>Enumerates the first stream with a ::$DATA stream type in the specified file or directory.</para>
		/// <para>To perform this operation as a transacted operation, use the <c>FindFirstStreamTransactedW</c> function.</para>
		/// </summary>
		/// <param name="lpFileName">The fully qualified file name.</param>
		/// <param name="InfoLevel">
		/// <para>
		/// The information level of the returned data. This parameter is one of the values in the <c>STREAM_INFO_LEVELS</c> enumeration type.
		/// </para>
		/// <para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>FindStreamInfoStandard = 0</term>
		/// <term>The data is returned in a WIN32_FIND_STREAM_DATA structure.</term>
		/// </item>
		/// </list>
		/// </para>
		/// </param>
		/// <param name="lpFindStreamData">
		/// A pointer to a buffer that receives the file stream data. The format of this data depends on the value of the InfoLevel parameter.
		/// </param>
		/// <param name="dwFlags">Reserved for future use. This parameter must be zero.</param>
		/// <returns>
		/// <para>
		/// If the function succeeds, the return value is a search handle that can be used in subsequent calls to the <c>FindNextStreamW</c> function.
		/// </para>
		/// <para>If the function fails, the return value is <c>INVALID_HANDLE_VALUE</c>. To get extended error information, call <c>GetLastError</c>.</para>
		/// <para>If no streams can be found, the function fails and <c>GetLastError</c> returns <c>ERROR_HANDLE_EOF</c> (38).</para>
		/// </returns>
		// HANDLE WINAPI FindFirstStreamW( _In_ LPCWSTR lpFileName, _In_ STREAM_INFO_LEVELS InfoLevel, _Out_ LPVOID lpFindStreamData,
		// _Reserved_ DWORD dwFlags); https://msdn.microsoft.com/en-us/library/windows/desktop/aa364424(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = true, EntryPoint = "FindFirstStreamW", CharSet = CharSet.Unicode)]
		[PInvokeData("WinBase.h", MSDNShortId = "aa364424")]
		public static extern SafeSearchHandle FindFirstStream(string lpFileName, STREAM_INFO_LEVELS InfoLevel, out WIN32_FIND_STREAM_DATA lpFindStreamData, [Optional] uint dwFlags);

		/// <summary>
		/// Retrieves the name of a mounted folder on the specified volume. <c>FindFirstVolumeMountPoint</c> is used to begin scanning the
		/// mounted folders on a volume.
		/// </summary>
		/// <param name="lpszRootPathName">A volume GUID path for the volume to scan for mounted folders. A trailing backslash is required.</param>
		/// <param name="lpszVolumeMountPoint">A pointer to a buffer that receives the name of the first mounted folder that is found.</param>
		/// <param name="cchBufferLength">The length of the buffer that receives the path to the mounted folder, in <c>TCHAR</c> s.</param>
		/// <returns>
		/// <para>
		/// If the function succeeds, the return value is a search handle used in a subsequent call to the <c>FindNextVolumeMountPoint</c>
		/// and <c>FindVolumeMountPointClose</c> functions.
		/// </para>
		/// <para>
		/// If the function fails to find a mounted folder on the volume, the return value is the <c>INVALID_HANDLE_VALUE</c> error code. To
		/// get extended error information, call <c>GetLastError</c>.
		/// </para>
		/// </returns>
		// HANDLE WINAPI FindFirstVolumeMountPoint( _In_ LPTSTR lpszRootPathName, _Out_ LPTSTR lpszVolumeMountPoint, _In_ DWORD
		// cchBufferLength); https://msdn.microsoft.com/en-us/library/windows/desktop/aa364426(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = true, CharSet = CharSet.Auto)]
		[PInvokeData("WinBase.h", MSDNShortId = "aa364426")]
		public static extern SafeVolumeMountPointHandle FindFirstVolumeMountPoint(string lpszRootPathName, StringBuilder lpszVolumeMountPoint, uint cchBufferLength);

		/// <summary>
		/// <para>
		/// Continues enumerating the hard links to a file using the handle returned by a successful call to the <c>FindFirstFileNameW</c> function.
		/// </para>
		/// </summary>
		/// <param name="hFindStream">
		/// <para>A handle to the enumeration that is returned by a successful call to <c>FindFirstFileNameW</c>.</para>
		/// </param>
		/// <param name="StringLength">
		/// <para>
		/// The size of the LinkName parameter, in characters. If this call fails and the error is <c>ERROR_MORE_DATA</c>, the value that is
		/// returned by this parameter is the size that LinkName must be to contain all the data.
		/// </para>
		/// </param>
		/// <param name="LinkName">
		/// <para>A pointer to a buffer to store the first link name found for lpFileName.</para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is nonzero.</para>
		/// <para>If the function fails, the return value is zero (0). To get extended error information, call <c>GetLastError</c>.</para>
		/// <para>If no matching files can be found, the <c>GetLastError</c> function returns <c>ERROR_HANDLE_EOF</c>.</para>
		/// </returns>
		// BOOL WINAPI FindNextFileNameW( _In_ HANDLE hFindStream, _Inout_ LPDWORD StringLength, _Inout_ PWCHAR LinkName);
		[DllImport(Lib.Kernel32, SetLastError = true, EntryPoint = "FindNextFileNameW", CharSet = CharSet.Unicode)]
		[PInvokeData("WinBase.h", MSDNShortId = "aa364429")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool FindNextFileName(SafeSearchHandle hFindStream, ref uint StringLength, StringBuilder LinkName);

		/// <summary>
		/// <para>Continues a stream search started by a previous call to the <c>FindFirstStreamW</c> function.</para>
		/// </summary>
		/// <param name="hFindStream">
		/// <para>The search handle returned by a previous call to the <c>FindFirstStreamW</c> function.</para>
		/// </param>
		/// <param name="lpFindStreamData">
		/// <para>A pointer to the <c>WIN32_FIND_STREAM_DATA</c> structure that receives information about the stream.</para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is nonzero.</para>
		/// <para>
		/// If the function fails, the return value is zero. To get extended error information, call <c>GetLastError</c>. If no more streams
		/// can be found, <c>GetLastError</c> returns <c>ERROR_HANDLE_EOF</c> (38).
		/// </para>
		/// </returns>
		// BOOL WINAPI FindNextStreamW( _In_ HANDLE hFindStream, _Out_ LPVOID lpFindStreamData);
		[DllImport(Lib.Kernel32, SetLastError = true, EntryPoint = "FindNextStreamW", CharSet = CharSet.Unicode)]
		[PInvokeData("WinBase.h", MSDNShortId = "aa364430")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool FindNextStream([In] SafeSearchHandle hFindStream, out WIN32_FIND_STREAM_DATA lpFindStreamData);

		/// <summary>
		/// Continues a mounted folder search started by a call to the <c>FindFirstVolumeMountPoint</c> function.
		/// <c>FindNextVolumeMountPoint</c> finds one mounted folder per call.
		/// </summary>
		/// <param name="hFindVolumeMountPoint">
		/// A mounted folder search handle returned by a previous call to the <c>FindFirstVolumeMountPoint</c> function.
		/// </param>
		/// <param name="lpszVolumeMountPoint">A pointer to a buffer that receives the name of the mounted folder that is found.</param>
		/// <param name="cchBufferLength">The length of the buffer that receives the mounted folder name, in <c>TCHARs</c>.</param>
		/// <returns>
		/// <para>If the function succeeds, the return value is nonzero.</para>
		/// <para>
		/// If the function fails, the return value is zero. To get extended error information, call <c>GetLastError</c>. If no more mounted
		/// folders can be found, the <c>GetLastError</c> function returns the <c>ERROR_NO_MORE_FILES</c> error code. In that case, close the
		/// search with the <c>FindVolumeMountPointClose</c> function.
		/// </para>
		/// </returns>
		// BOOL WINAPI FindNextVolumeMountPoint( _In_ HANDLE hFindVolumeMountPoint, _Out_ LPTSTR lpszVolumeMountPoint, _In_ DWORD
		// cchBufferLength); https://msdn.microsoft.com/en-us/library/windows/desktop/aa364432(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = true, CharSet = CharSet.Auto)]
		[PInvokeData("WinBase.h", MSDNShortId = "aa364432")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool FindNextVolumeMountPoint([In] SafeVolumeMountPointHandle hFindVolumeMountPoint, StringBuilder lpszVolumeMountPoint, uint cchBufferLength);

		/// <summary>
		/// Closes the specified mounted folder search handle. The <c>FindFirstVolumeMountPoint</c> and <c>FindNextVolumeMountPoint</c>
		/// functions use this search handle to locate mounted folders on a specified volume.
		/// </summary>
		/// <param name="hFindVolumeMountPoint">
		/// The mounted folder search handle to be closed. This handle must have been previously opened by the
		/// <c>FindFirstVolumeMountPoint</c> function.
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is nonzero.</para>
		/// <para>If the function fails, the return value is zero. To get extended error information, call <c>GetLastError</c>.</para>
		/// </returns>
		// BOOL WINAPI FindVolumeMountPointClose( _In_ HANDLE hFindVolumeMountPoint); https://msdn.microsoft.com/en-us/library/windows/desktop/aa364435(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("WinBase.h", MSDNShortId = "aa364435")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool FindVolumeMountPointClose([In] IntPtr hFindVolumeMountPoint);

		/// <summary>
		/// Retrieves the actual number of bytes of disk storage used to store a specified file. If the file is located on a volume that
		/// supports compression and the file is compressed, the value obtained is the compressed size of the specified file. If the file is
		/// located on a volume that supports sparse files and the file is a sparse file, the value obtained is the sparse size of the
		/// specified file.
		/// </summary>
		/// <param name="lpFileName">
		/// The name of the file.
		/// <para>
		/// Do not specify the name of a file on a nonseeking device, such as a pipe or a communications device, as its file size has no meaning.
		/// </para>
		/// <para>
		/// This parameter may include the path. In the ANSI version of this function, the name is limited to <see cref="MAX_PATH"/>
		/// characters. To extend this limit to 32,767 wide characters, call the Unicode version of the function and prepend "\\?\" to the
		/// path. For more information, see <a href="https://msdn.microsoft.com/en-us/library/windows/desktop/aa365247(v=vs.85).aspx">Naming
		/// a File</a>.
		/// </para>
		/// <para>
		/// <c>Tip</c> Starting with Windows 10, version 1607, for the Unicode version of this function ( <c>GetCompressedFileSizeW</c>), you
		/// can opt-in to remove the <see cref="MAX_PATH"/> limitation without prepending "\\?\". See the "Maximum Path Length Limitation"
		/// section of <a href="https://msdn.microsoft.com/en-us/library/windows/desktop/aa365247(v=vs.85).aspx">Naming Files, Paths, and
		/// Namespaces</a> for details.
		/// </para>
		/// </param>
		/// <param name="lpFileSizeHigh">
		/// The high-order DWORD of the compressed file size. The function's return value is the low-order DWORD of the compressed file size.
		/// <para>
		/// This parameter can be NULL if the high-order DWORD of the compressed file size is not needed.Files less than 4 gigabytes in size
		/// do not need the high-order DWORD.
		/// </para>
		/// </param>
		/// <returns>
		/// If the function succeeds, the return value is the low-order DWORD of the actual number of bytes of disk storage used to store the
		/// specified file, and if <paramref name="lpFileSizeHigh"/> is non-NULL, the function puts the high-order DWORD of that actual value
		/// into the DWORD pointed to by that parameter. This is the compressed file size for compressed files, the actual file size for
		/// noncompressed files.
		/// <para>
		/// If the function fails, and <paramref name="lpFileSizeHigh"/> is NULL, the return value is INVALID_FILE_SIZE. To get extended
		/// error information, call GetLastError.
		/// </para>
		/// <para>
		/// If the return value is INVALID_FILE_SIZE and <paramref name="lpFileSizeHigh"/> is non-NULL, an application must call GetLastError
		/// to determine whether the function has succeeded (value is NO_ERROR) or failed (value is other than NO_ERROR).
		/// </para>
		/// </returns>
		/// <remarks>
		/// An application can determine whether a volume is compressed by calling <see cref="GetVolumeInformation(string, out string, out
		/// uint, out uint, out FileSystemFlags, out string)"/>, then checking the status of the FS_VOL_IS_COMPRESSED flag in the DWORD value
		/// pointed to by that function's lpFileSystemFlags parameter.
		/// <para>
		/// If the file is not located on a volume that supports compression or sparse files, or if the file is not compressed or a sparse
		/// file, the value obtained is the actual file size, the same as the value returned by a call to GetFileSize.
		/// </para>
		/// <para>Symbolic link behavior—If the path points to a symbolic link, the function returns the file size of the target.</para>
		/// </remarks>
		[DllImport(Lib.Kernel32, SetLastError = true, CharSet = CharSet.Auto)]
		[PInvokeData("WinBase.h", MSDNShortId = "aa364930")]
		public static extern uint GetCompressedFileSize(string lpFileName, out uint lpFileSizeHigh);

		/// <summary>
		/// Retrieves the actual number of bytes of disk storage used to store a specified file. If the file is located on a volume that
		/// supports compression and the file is compressed, the value obtained is the compressed size of the specified file. If the file is
		/// located on a volume that supports sparse files and the file is a sparse file, the value obtained is the sparse size of the
		/// specified file.
		/// </summary>
		/// <param name="lpFileName">
		/// The name of the file.
		/// <para>
		/// Do not specify the name of a file on a nonseeking device, such as a pipe or a communications device, as its file size has no meaning.
		/// </para>
		/// <para>
		/// This parameter may include the path. In the ANSI version of this function, the name is limited to <see cref="MAX_PATH"/>
		/// characters. To extend this limit to 32,767 wide characters, call the Unicode version of the function and prepend "\\?\" to the
		/// path. For more information, see <a href="https://msdn.microsoft.com/en-us/library/windows/desktop/aa365247(v=vs.85).aspx">Naming
		/// a File</a>.
		/// </para>
		/// <para>
		/// <c>Tip</c> Starting with Windows 10, version 1607, for the Unicode version of this function ( <c>GetCompressedFileSizeW</c>), you
		/// can opt-in to remove the <see cref="MAX_PATH"/> limitation without prepending "\\?\". See the "Maximum Path Length Limitation"
		/// section of <a href="https://msdn.microsoft.com/en-us/library/windows/desktop/aa365247(v=vs.85).aspx">Naming Files, Paths, and
		/// Namespaces</a> for details.
		/// </para>
		/// </param>
		/// <param name="fileSize">The compressed file size.</param>
		/// <returns>If the function succeeds, the return value is ERROR_SUCCESS, otherwise it is the failure code.</returns>
		/// <remarks>
		/// An application can determine whether a volume is compressed by calling <see cref="GetVolumeInformation(string, out string, out
		/// uint, out uint, out FileSystemFlags, out string)"/>, then checking the status of the FS_VOL_IS_COMPRESSED flag in the DWORD value
		/// pointed to by that function's lpFileSystemFlags parameter.
		/// <para>
		/// If the file is not located on a volume that supports compression or sparse files, or if the file is not compressed or a sparse
		/// file, the value obtained is the actual file size, the same as the value returned by a call to GetFileSize.
		/// </para>
		/// <para>Symbolic link behavior—If the path points to a symbolic link, the function returns the file size of the target.</para>
		/// </remarks>
		public static Win32Error GetCompressedFileSize(string lpFileName, out ulong fileSize)
		{
			var low = GetCompressedFileSize(lpFileName, out uint high);
			if (low == INVALID_FILE_SIZE)
			{
				fileSize = 0;
				return Win32Error.GetLastError();
			}
			fileSize = Macros.MAKELONG64(low, high);
			return Win32Error.ERROR_SUCCESS;
		}

		/// <summary>
		/// <para>Retrieves the bandwidth reservation properties of the volume on which the specified file resides.</para>
		/// </summary>
		/// <param name="hFile">
		/// <para>A handle to the file.</para>
		/// </param>
		/// <param name="lpPeriodMilliseconds">
		/// <para>
		/// A pointer to a variable that receives the period of the reservation, in milliseconds. The period is the time from which the I/O
		/// is issued to the kernel until the time the I/O should be completed. If no bandwidth has been reserved for this handle, then the
		/// value returned is the minimum reservation period supported for this volume.
		/// </para>
		/// </param>
		/// <param name="lpBytesPerPeriod">
		/// <para>
		/// A pointer to a variable that receives the maximum number of bytes per period that can be reserved on the volume. If no bandwidth
		/// has been reserved for this handle, then the value returned is the maximum number of bytes per period supported for the volume.
		/// </para>
		/// </param>
		/// <param name="pDiscardable">
		/// <para>
		/// <c>TRUE</c> if I/O should be completed with an error if a driver is unable to satisfy an I/O operation before the period expires.
		/// <c>FALSE</c> if the underlying subsystem does not support failing in this manner.
		/// </para>
		/// </param>
		/// <param name="lpTransferSize">
		/// <para>
		/// The minimum size of any individual I/O request that may be issued by the application. All I/O requests should be multiples of
		/// TransferSize. If no bandwidth has been reserved for this handle, then the value returned is the minimum transfer size supported
		/// for this volume.
		/// </para>
		/// </param>
		/// <param name="lpNumOutstandingRequests">
		/// <para>The number of TransferSize chunks allowed to be outstanding with the operating system.</para>
		/// </param>
		/// <returns>
		/// <para>Returns nonzero if successful or zero otherwise.</para>
		/// <para>To get extended error information, call GetLastError.</para>
		/// </returns>
		/// <remarks>
		/// <para>In Windows 8 and Windows Server 2012, this function is supported by the following technologies.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Technology</term>
		/// <term>Supported</term>
		/// </listheader>
		/// <item>
		/// <term>Server Message Block (SMB) 3.0 protocol</term>
		/// <term>No</term>
		/// </item>
		/// <item>
		/// <term>SMB 3.0 Transparent Failover (TFO)</term>
		/// <term>No</term>
		/// </item>
		/// <item>
		/// <term>SMB 3.0 with Scale-out File Shares (SO)</term>
		/// <term>No</term>
		/// </item>
		/// <item>
		/// <term>Cluster Shared Volume File System (CsvFS)</term>
		/// <term>No</term>
		/// </item>
		/// <item>
		/// <term>Resilient File System (ReFS)</term>
		/// <term>Yes</term>
		/// </item>
		/// </list>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winbase/nf-winbase-getfilebandwidthreservation BOOL
		// GetFileBandwidthReservation( HANDLE hFile, LPDWORD lpPeriodMilliseconds, LPDWORD lpBytesPerPeriod, LPBOOL pDiscardable, LPDWORD
		// lpTransferSize, LPDWORD lpNumOutstandingRequests );
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("winbase.h", MSDNShortId = "3caf38f6-e853-4057-a192-71cda4443dbd")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool GetFileBandwidthReservation(HFILE hFile, out uint lpPeriodMilliseconds, out uint lpBytesPerPeriod, [MarshalAs(UnmanagedType.Bool)] out bool pDiscardable, out uint lpTransferSize, out uint lpNumOutstandingRequests);

		/// <summary>
		/// <para>Retrieves file information for the specified file.</para>
		/// <para>For a more basic version of this function for desktop apps, see GetFileInformationByHandle.</para>
		/// <para>To set file information using a file handle, see SetFileInformationByHandle.</para>
		/// </summary>
		/// <param name="hFile">
		/// <para>A handle to the file that contains the information to be retrieved.</para>
		/// <para>This handle should not be a pipe handle.</para>
		/// </param>
		/// <param name="FileInformationClass">
		/// <para>A FILE_INFO_BY_HANDLE_CLASS enumeration value that specifies the type of information to be retrieved.</para>
		/// <para>For a table of valid values, see the Remarks section.</para>
		/// </param>
		/// <param name="lpFileInformation">
		/// <para>
		/// A pointer to the buffer that receives the requested file information. The structure that is returned corresponds to the class
		/// that is specified by FileInformationClass. For a table of valid structure types, see the Remarks section.
		/// </para>
		/// </param>
		/// <param name="dwBufferSize">
		/// <para>The size of the lpFileInformation buffer, in bytes.</para>
		/// </param>
		/// <returns>
		/// <para>
		/// If the function succeeds, the return value is nonzero and file information data is contained in the buffer pointed to by the
		/// lpFileInformation parameter.
		/// </para>
		/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// If FileInformationClass is <c>FileStreamInfo</c> and the calls succeed but no streams are returned, the error that is returned by
		/// GetLastError is <c>ERROR_HANDLE_EOF</c>.
		/// </para>
		/// <para>
		/// Certain file information classes behave slightly differently on different operating system releases. These classes are supported
		/// by the underlying drivers, and any information they return is subject to change between operating system releases.
		/// </para>
		/// <para>
		/// The following table shows the valid file information class types and their corresponding data structure types for use with this function.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>FileInformationClass value</term>
		/// <term>lpFileInformation type</term>
		/// </listheader>
		/// <item>
		/// <term>FileBasicInfo (0)</term>
		/// <term>FILE_BASIC_INFO</term>
		/// </item>
		/// <item>
		/// <term>FileStandardInfo (1)</term>
		/// <term>FILE_STANDARD_INFO</term>
		/// </item>
		/// <item>
		/// <term>FileNameInfo (2)</term>
		/// <term>FILE_NAME_INFO</term>
		/// </item>
		/// <item>
		/// <term>FileStreamInfo (7)</term>
		/// <term>FILE_STREAM_INFO</term>
		/// </item>
		/// <item>
		/// <term>FileCompressionInfo (8)</term>
		/// <term>FILE_COMPRESSION_INFO</term>
		/// </item>
		/// <item>
		/// <term>FileAttributeTagInfo (9)</term>
		/// <term>FILE_ATTRIBUTE_TAG_INFO</term>
		/// </item>
		/// <item>
		/// <term>FileIdBothDirectoryInfo (0xa)</term>
		/// <term>FILE_ID_BOTH_DIR_INFO</term>
		/// </item>
		/// <item>
		/// <term>FileIdBothDirectoryRestartInfo (0xb)</term>
		/// <term>FILE_ID_BOTH_DIR_INFO</term>
		/// </item>
		/// <item>
		/// <term>FileRemoteProtocolInfo (0xd)</term>
		/// <term>FILE_REMOTE_PROTOCOL_INFO</term>
		/// </item>
		/// <item>
		/// <term>FileFullDirectoryInfo (0xe)</term>
		/// <term>FILE_FULL_DIR_INFO</term>
		/// </item>
		/// <item>
		/// <term>FileFullDirectoryRestartInfo (0xf)</term>
		/// <term>FILE_FULL_DIR_INFO</term>
		/// </item>
		/// <item>
		/// <term>FileStorageInfo (0x10)</term>
		/// <term>FILE_STORAGE_INFO</term>
		/// </item>
		/// <item>
		/// <term>FileAlignmentInfo (0x11)</term>
		/// <term>FILE_ALIGNMENT_INFO</term>
		/// </item>
		/// <item>
		/// <term>FileIdInfo (0x12)</term>
		/// <term>FILE_ID_INFO</term>
		/// </item>
		/// <item>
		/// <term>FileIdExtdDirectoryInfo (0x13)</term>
		/// <term>FILE_ID_EXTD_DIR_INFO</term>
		/// </item>
		/// <item>
		/// <term>FileIdExtdDirectoryRestartInfo (0x14)</term>
		/// <term>FILE_ID_EXTD_DIR_INFO</term>
		/// </item>
		/// </list>
		/// <para>Transacted Operations</para>
		/// <para>
		/// If there is a transaction bound to the thread at the time of the call, then the function returns the compressed file size of the
		/// isolated file view. For more information, see About Transactional NTFS.
		/// </para>
		/// <para>In Windows 8 and Windows Server 2012, this function is supported by the following technologies.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Technology</term>
		/// <term>Supported</term>
		/// </listheader>
		/// <item>
		/// <term>Server Message Block (SMB) 3.0 protocol</term>
		/// <term>Yes</term>
		/// </item>
		/// <item>
		/// <term>SMB 3.0 Transparent Failover (TFO)</term>
		/// <term>Yes</term>
		/// </item>
		/// <item>
		/// <term>SMB 3.0 with Scale-out File Shares (SO)</term>
		/// <term>Yes</term>
		/// </item>
		/// <item>
		/// <term>Cluster Shared Volume File System (CsvFS)</term>
		/// <term>Yes</term>
		/// </item>
		/// <item>
		/// <term>Resilient File System (ReFS)</term>
		/// <term>Yes</term>
		/// </item>
		/// </list>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winbase/nf-winbase-getfileinformationbyhandleex BOOL
		// GetFileInformationByHandleEx( HANDLE hFile, FILE_INFO_BY_HANDLE_CLASS FileInformationClass, LPVOID lpFileInformation, DWORD
		// dwBufferSize );
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("winbase.h", MSDNShortId = "e261ea45-d084-490e-94b4-129bd76f6a04")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool GetFileInformationByHandleEx(HFILE hFile, FILE_INFO_BY_HANDLE_CLASS FileInformationClass, SafeAllocatedMemoryHandle lpFileInformation, uint dwBufferSize);

		/// <summary>
		/// <para>Retrieves file information for the specified file.</para>
		/// <para>For a more basic version of this function for desktop apps, see GetFileInformationByHandle.</para>
		/// <para>To set file information using a file handle, see SetFileInformationByHandle.</para>
		/// </summary>
		/// <param name="hFile">
		/// <para>A handle to the file that contains the information to be retrieved.</para>
		/// <para>This handle should not be a pipe handle.</para>
		/// </param>
		/// <param name="FileInformationClass">
		/// <para>A FILE_INFO_BY_HANDLE_CLASS enumeration value that specifies the type of information to be retrieved.</para>
		/// <para>For a table of valid values, see the Remarks section.</para>
		/// </param>
		/// <returns>The requested file information. The structure that is returned corresponds to the class that is specified by FileInformationClass.</returns>
		public static T GetFileInformationByHandleEx<T>(HFILE hFile, FILE_INFO_BY_HANDLE_CLASS FileInformationClass) where T : struct
		{
			if (!CorrespondingTypeAttribute.CanGet(FileInformationClass, typeof(T))) throw new InvalidOperationException("Type mismatch.");
			var mem = SafeHGlobalHandle.CreateFromStructure<T>();
			if (!GetFileInformationByHandleEx(hFile, FileInformationClass, mem, (uint)mem.Size)) Win32Error.ThrowLastError();
			return mem.ToStructure<T>();
		}

		/// <summary>
		/// <para>Moves an existing file or a directory, including its children.</para>
		/// <para>To specify how to move the file, use the <c>MoveFileEx</c> or <c>MoveFileWithProgress</c> function.</para>
		/// <para>To perform this operation as a transacted operation, use the <c>MoveFileTransacted</c> function.</para>
		/// </summary>
		/// <param name="lpExistingFileName">
		/// <para>The current name of the file or directory on the local computer.</para>
		/// <para>
		/// In the ANSI version of this function, the name is limited to <c>MAX_PATH</c> characters. To extend this limit to 32,767 wide
		/// characters, call the Unicode version of the function and prepend "\\?\" to the path. For more information, see Naming a File.
		/// </para>
		/// </param>
		/// <param name="lpNewFileName">
		/// <para>
		/// The new name for the file or directory. The new name must not already exist. A new file may be on a different file system or
		/// drive. A new directory must be on the same drive.
		/// </para>
		/// <para>
		/// In the ANSI version of this function, the name is limited to <c>MAX_PATH</c> characters. To extend this limit to 32,767 wide
		/// characters, call the Unicode version of the function and prepend "\\?\" to the path. For more information, see Naming a File.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is nonzero.</para>
		/// <para>If the function fails, the return value is zero. To get extended error information, call <c>GetLastError</c>.</para>
		/// </returns>
		// BOOL WINAPI MoveFile( _In_ LPCTSTR lpExistingFileName, _In_ LPCTSTR lpNewFileName); https://msdn.microsoft.com/en-us/library/windows/desktop/aa365239(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = true, CharSet = CharSet.Auto)]
		[PInvokeData("WinBase.h", MSDNShortId = "aa365239")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool MoveFile(string lpExistingFileName, string lpNewFileName);

		/// <summary>
		/// <para>Moves an existing file or directory, including its children, with various move options.</para>
		/// <para>
		/// The <c>MoveFileWithProgress</c> function is equivalent to the <c>MoveFileEx</c> function, except that <c>MoveFileWithProgress</c>
		/// allows you to provide a callback function that receives progress notifications.
		/// </para>
		/// <para>To perform this operation as a transacted operation, use the <c>MoveFileTransacted</c> function.</para>
		/// </summary>
		/// <param name="lpExistingFileName">
		/// <para>The current name of the file or directory on the local computer.</para>
		/// <para>
		/// If dwFlags specifies <c>MOVEFILE_DELAY_UNTIL_REBOOT</c>, the file cannot exist on a remote share, because delayed operations are
		/// performed before the network is available.
		/// </para>
		/// <para>
		/// In the ANSI version of this function, the name is limited to <c>MAX_PATH</c> characters. To extend this limit to 32,767 wide
		/// characters, call the Unicode version of the function and prepend "\\?\" to the path. For more information, see Naming a File
		/// </para>
		/// </param>
		/// <param name="lpNewFileName">
		/// <para>The new name of the file or directory on the local computer.</para>
		/// <para>
		/// When moving a file, the destination can be on a different file system or volume. If the destination is on another drive, you must
		/// set the <c>MOVEFILE_COPY_ALLOWED</c> flag in dwFlags.
		/// </para>
		/// <para>When moving a directory, the destination must be on the same drive.</para>
		/// <para>
		/// If dwFlags specifies <c>MOVEFILE_DELAY_UNTIL_REBOOT</c> and lpNewFileName is <c>NULL</c>, <c>MoveFileEx</c> registers the
		/// lpExistingFileName file to be deleted when the system restarts. If lpExistingFileName refers to a directory, the system removes
		/// the directory at restart only if the directory is empty.
		/// </para>
		/// <para>
		/// In the ANSI version of this function, the name is limited to <c>MAX_PATH</c> characters. To extend this limit to 32,767 wide
		/// characters, call the Unicode version of the function and prepend "\\?\" to the path. For more information, see Naming a File
		/// </para>
		/// </param>
		/// <param name="dwFlags">
		/// <para>This parameter can be one or more of the following values.</para>
		/// <para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>MOVEFILE_COPY_ALLOWED2 (0x2)</term>
		/// <term>
		/// If the file is to be moved to a different volume, the function simulates the move by using the CopyFile and DeleteFile
		/// functions.If the file is successfully copied to a different volume and the original file is unable to be deleted, the function
		/// succeeds leaving the source file intact.This value cannot be used with MOVEFILE_DELAY_UNTIL_REBOOT.
		/// </term>
		/// </item>
		/// <item>
		/// <term>MOVEFILE_CREATE_HARDLINK16 (0x10)</term>
		/// <term>Reserved for future use.</term>
		/// </item>
		/// <item>
		/// <term>MOVEFILE_DELAY_UNTIL_REBOOT4 (0x4)</term>
		/// <term>
		/// The system does not move the file until the operating system is restarted. The system moves the file immediately after AUTOCHK is
		/// executed, but before creating any paging files. Consequently, this parameter enables the function to delete paging files from
		/// previous startups.This value can be used only if the process is in the context of a user who belongs to the administrators group
		/// or the LocalSystem account. This value cannot be used with MOVEFILE_COPY_ALLOWED.Windows Server 2003 and Windows XP: For
		/// information about special situations where this functionality can fail, and a suggested workaround solution, see Files are not
		/// exchanged when Windows Server 2003 restarts if you use the MoveFileEx function to schedule a replacement for some files in the
		/// Help and Support Knowledge Base.
		/// </term>
		/// </item>
		/// <item>
		/// <term>MOVEFILE_FAIL_IF_NOT_TRACKABLE32 (0x20)</term>
		/// <term>
		/// The function fails if the source file is a link source, but the file cannot be tracked after the move. This situation can occur
		/// if the destination is a volume formatted with the FAT file system.
		/// </term>
		/// </item>
		/// <item>
		/// <term>MOVEFILE_REPLACE_EXISTING1 (0x1)</term>
		/// <term>
		/// If a file named lpNewFileName exists, the function replaces its contents with the contents of the lpExistingFileName file,
		/// provided that security requirements regarding access control lists (ACLs) are met. For more information, see the Remarks section
		/// of this topic.This value cannot be used if lpNewFileName or lpExistingFileName names a directory.
		/// </term>
		/// </item>
		/// <item>
		/// <term>MOVEFILE_WRITE_THROUGH8 (0x8)</term>
		/// <term>
		/// The function does not return until the file is actually moved on the disk.Setting this value guarantees that a move performed as
		/// a copy and delete operation is flushed to disk before the function returns. The flush occurs at the end of the copy
		/// operation.This value has no effect if MOVEFILE_DELAY_UNTIL_REBOOT is set.
		/// </term>
		/// </item>
		/// </list>
		/// </para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is nonzero.</para>
		/// <para>If the function fails, the return value is zero (0). To get extended error information, call <c>GetLastError</c>.</para>
		/// </returns>
		// BOOL WINAPI MoveFileEx( _In_ LPCTSTR lpExistingFileName, _In_opt_ LPCTSTR lpNewFileName, _In_ DWORD dwFlags); https://msdn.microsoft.com/en-us/library/windows/desktop/aa365240(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = true, CharSet = CharSet.Auto)]
		[PInvokeData("WinBase.h", MSDNShortId = "aa365240")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool MoveFileEx(string lpExistingFileName, string lpNewFileName, MOVEFILE dwFlags);

		/// <summary>
		/// <para>Moves a file or directory, including its children. You can provide a callback function that receives progress notifications.</para>
		/// <para>To perform this operation as a transacted operation, use the <c>MoveFileTransacted</c> function.</para>
		/// </summary>
		/// <param name="lpExistingFileName">
		/// <para>The name of the existing file or directory on the local computer.</para>
		/// <para>
		/// If dwFlags specifies <c>MOVEFILE_DELAY_UNTIL_REBOOT</c>, the file cannot exist on a remote share because delayed operations are
		/// performed before the network is available.
		/// </para>
		/// <para>
		/// In the ANSI version of this function, the name is limited to <c>MAX_PATH</c> characters. To extend this limit to 32,767 wide
		/// characters, call the Unicode version of the function and prepend "\\?\" to the path. For more information, see Naming a File.
		/// </para>
		/// </param>
		/// <param name="lpNewFileName">
		/// <para>The new name of the file or directory on the local computer.</para>
		/// <para>
		/// When moving a file, lpNewFileName can be on a different file system or volume. If lpNewFileName is on another drive, you must set
		/// the <c>MOVEFILE_COPY_ALLOWED</c> flag in dwFlags.
		/// </para>
		/// <para>When moving a directory, lpExistingFileName and lpNewFileName must be on the same drive.</para>
		/// <para>
		/// If dwFlags specifies <c>MOVEFILE_DELAY_UNTIL_REBOOT</c> and lpNewFileName is <c>NULL</c>, <c>MoveFileWithProgress</c> registers
		/// lpExistingFileName to be deleted when the system restarts. The function fails if it cannot access the registry to store the
		/// information about the delete operation. If lpExistingFileName refers to a directory, the system removes the directory at restart
		/// only if the directory is empty.
		/// </para>
		/// <para>
		/// In the ANSI version of this function, the name is limited to <c>MAX_PATH</c> characters. To extend this limit to 32,767 wide
		/// characters, call the Unicode version of the function and prepend "\\?\" to the path. For more information, see Naming a File.
		/// </para>
		/// </param>
		/// <param name="lpProgressRoutine">
		/// A pointer to a <c>CopyProgressRoutine</c> callback function that is called each time another portion of the file has been moved.
		/// The callback function can be useful if you provide a user interface that displays the progress of the operation. This parameter
		/// can be <c>NULL</c>.
		/// </param>
		/// <param name="lpData">An argument to be passed to the <c>CopyProgressRoutine</c> callback function. This parameter can be <c>NULL</c>.</param>
		/// <param name="dwFlags">
		/// <para>The move options. This parameter can be one or more of the following values.</para>
		/// <para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>MOVEFILE_COPY_ALLOWED2 (0x2)</term>
		/// <term>
		/// If the file is to be moved to a different volume, the function simulates the move by using the CopyFile and DeleteFile
		/// functions.If the file is successfully copied to a different volume and the original file is unable to be deleted, the function
		/// succeeds leaving the source file intact.This value cannot be used with MOVEFILE_DELAY_UNTIL_REBOOT.
		/// </term>
		/// </item>
		/// <item>
		/// <term>MOVEFILE_CREATE_HARDLINK16 (0x10)</term>
		/// <term>Reserved for future use.</term>
		/// </item>
		/// <item>
		/// <term>MOVEFILE_DELAY_UNTIL_REBOOT4 (0x4)</term>
		/// <term>
		/// The system does not move the file until the operating system is restarted. The system moves the file immediately after AUTOCHK is
		/// executed, but before creating any paging files. Consequently, this parameter enables the function to delete paging files from
		/// previous startups.This value can only be used if the process is in the context of a user who belongs to the administrators group
		/// or the LocalSystem account.This value cannot be used with MOVEFILE_COPY_ALLOWED.
		/// </term>
		/// </item>
		/// <item>
		/// <term>MOVEFILE_FAIL_IF_NOT_TRACKABLE32 (0x20)</term>
		/// <term>
		/// The function fails if the source file is a link source, but the file cannot be tracked after the move. This situation can occur
		/// if the destination is a volume formatted with the FAT file system.
		/// </term>
		/// </item>
		/// <item>
		/// <term>MOVEFILE_REPLACE_EXISTING1 (0x1)</term>
		/// <term>
		/// If a file named lpNewFileName exists, the function replaces its contents with the contents of the lpExistingFileName file.This
		/// value cannot be used if lpNewFileName or lpExistingFileName names a directory.
		/// </term>
		/// </item>
		/// <item>
		/// <term>MOVEFILE_WRITE_THROUGH8 (0x8)</term>
		/// <term>
		/// The function does not return until the file has actually been moved on the disk.Setting this value guarantees that a move
		/// performed as a copy and delete operation is flushed to disk before the function returns. The flush occurs at the end of the copy
		/// operation.This value has no effect if MOVEFILE_DELAY_UNTIL_REBOOT is set.
		/// </term>
		/// </item>
		/// </list>
		/// </para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is nonzero.</para>
		/// <para>If the function fails, the return value is zero. To get extended error information, call <c>GetLastError</c>.</para>
		/// <para>
		/// When moving a file across volumes, if lpProgressRoutine returns <c>PROGRESS_CANCEL</c> due to the user canceling the operation,
		/// <c>MoveFileWithProgress</c> will return zero and <c>GetLastError</c> will return <c>ERROR_REQUEST_ABORTED</c>. The existing file
		/// is left intact.
		/// </para>
		/// <para>
		/// When moving a file across volumes, if lpProgressRoutine returns <c>PROGRESS_STOP</c> due to the user stopping the operation,
		/// <c>MoveFileWithProgress</c> will return zero and <c>GetLastError</c> will return <c>ERROR_REQUEST_ABORTED</c>. The existing file
		/// is left intact.
		/// </para>
		/// </returns>
		// BOOL WINAPI MoveFileWithProgress( _In_ LPCTSTR lpExistingFileName, _In_opt_ LPCTSTR lpNewFileName, _In_opt_ LPPROGRESS_ROUTINE
		// lpProgressRoutine, _In_opt_ LPVOID lpData, _In_ DWORD dwFlags); https://msdn.microsoft.com/en-us/library/windows/desktop/aa365242(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = true, CharSet = CharSet.Auto)]
		[PInvokeData("WinBase.h", MSDNShortId = "aa365242")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool MoveFileWithProgress(string lpExistingFileName, string lpNewFileName, CopyProgressRoutine lpProgressRoutine, [In] IntPtr lpData, MOVEFILE dwFlags);

		/// <summary>Creates, opens, reopens, or deletes a file.</summary>
		/// <param name="lpFileName">
		/// <para>The name of the file.</para>
		/// <para>
		/// The string must consist of characters from the 8-bit Windows character set. The <c>OpenFile</c> function does not support Unicode
		/// file names or opening named pipes.
		/// </para>
		/// </param>
		/// <param name="lpReOpenBuff">
		/// <para>A pointer to the <c>OFSTRUCT</c> structure that receives information about a file when it is first opened.</para>
		/// <para>The structure can be used in subsequent calls to the <c>OpenFile</c> function to see an open file.</para>
		/// <para>
		/// The <c>OFSTRUCT</c> structure contains a path string member with a length that is limited to <c>OFS_MAXPATHNAME</c> characters,
		/// which is 128 characters. Because of this, you cannot use the <c>OpenFile</c> function to open a file with a path length that
		/// exceeds 128 characters. The <c>CreateFile</c> function does not have this path length limitation.
		/// </para>
		/// </param>
		/// <param name="uStyle">
		/// <para>The action to be taken.</para>
		/// <para>This parameter can be one or more of the following values.</para>
		/// <para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>OF_CANCEL0x00000800</term>
		/// <term>Ignored.To produce a dialog box containing a Cancel button, use OF_PROMPT.</term>
		/// </item>
		/// <item>
		/// <term>OF_CREATE0x00001000</term>
		/// <term>Creates a new file.If the file exists, it is truncated to zero (0) length.</term>
		/// </item>
		/// <item>
		/// <term>OF_DELETE0x00000200</term>
		/// <term>Deletes a file.</term>
		/// </item>
		/// <item>
		/// <term>OF_EXIST0x00004000</term>
		/// <term>Opens a file and then closes it.Use this to test for the existence of a file.</term>
		/// </item>
		/// <item>
		/// <term>OF_PARSE0x00000100</term>
		/// <term>Fills the OFSTRUCT structure, but does not do anything else.</term>
		/// </item>
		/// <item>
		/// <term>OF_PROMPT0x00002000</term>
		/// <term>
		/// Displays a dialog box if a requested file does not exist.A dialog box informs a user that the system cannot find a file, and it
		/// contains Retry and Cancel buttons. The Cancel button directs OpenFile to return a file-not-found error message.
		/// </term>
		/// </item>
		/// <item>
		/// <term>OF_READ0x00000000</term>
		/// <term>Opens a file for reading only.</term>
		/// </item>
		/// <item>
		/// <term>OF_READWRITE0x00000002</term>
		/// <term>Opens a file with read/write permissions.</term>
		/// </item>
		/// <item>
		/// <term>OF_REOPEN0x00008000</term>
		/// <term>Opens a file by using information in the reopen buffer.</term>
		/// </item>
		/// <item>
		/// <term>OF_SHARE_COMPAT0x00000000</term>
		/// <term>
		/// For MS-DOS–based file systems, opens a file with compatibility mode, allows any process on a specified computer to open the file
		/// any number of times.Other efforts to open a file with other sharing modes fail. This flag is mapped to the
		/// FILE_SHARE_READ|FILE_SHARE_WRITE flags of the CreateFile function.
		/// </term>
		/// </item>
		/// <item>
		/// <term>OF_SHARE_DENY_NONE0x00000040</term>
		/// <term>
		/// Opens a file without denying read or write access to other processes.On MS-DOS-based file systems, if the file has been opened in
		/// compatibility mode by any other process, the function fails.This flag is mapped to the FILE_SHARE_READ|FILE_SHARE_WRITE flags of
		/// the CreateFile function.
		/// </term>
		/// </item>
		/// <item>
		/// <term>OF_SHARE_DENY_READ0x00000030</term>
		/// <term>
		/// Opens a file and denies read access to other processes.On MS-DOS-based file systems, if the file has been opened in compatibility
		/// mode, or for read access by any other process, the function fails.This flag is mapped to the FILE_SHARE_WRITE flag of the
		/// CreateFile function.
		/// </term>
		/// </item>
		/// <item>
		/// <term>OF_SHARE_DENY_WRITE0x00000020</term>
		/// <term>
		/// Opens a file and denies write access to other processes.On MS-DOS-based file systems, if a file has been opened in compatibility
		/// mode, or for write access by any other process, the function fails.This flag is mapped to the FILE_SHARE_READ flag of the
		/// CreateFile function.
		/// </term>
		/// </item>
		/// <item>
		/// <term>OF_SHARE_EXCLUSIVE0x00000010</term>
		/// <term>
		/// Opens a file with exclusive mode, and denies both read/write access to other processes. If a file has been opened in any other
		/// mode for read/write access, even by the current process, the function fails.
		/// </term>
		/// </item>
		/// <item>
		/// <term>OF_VERIFY</term>
		/// <term>
		/// Verifies that the date and time of a file are the same as when it was opened previously.This is useful as an extra check for
		/// read-only files.
		/// </term>
		/// </item>
		/// <item>
		/// <term>OF_WRITE0x00000001</term>
		/// <term>Opens a file for write access only.</term>
		/// </item>
		/// </list>
		/// </para>
		/// </param>
		/// <returns>
		/// <para>
		/// If the function succeeds, the return value specifies a file handle to use when performing file I/O. To close the file, call the
		/// <c>CloseHandle</c> function using this handle.
		/// </para>
		/// <para>If the function fails, the return value is <c>HFILE_ERROR</c>. To get extended error information, call <c>GetLastError</c>.</para>
		/// </returns>
		// HFILE WINAPI OpenFile( _In_ LPCSTR lpFileName, _Out_ LPOFSTRUCT lpReOpenBuff, _In_ UINT uStyle); https://msdn.microsoft.com/en-us/library/windows/desktop/aa365430(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("WinBase.h", MSDNShortId = "aa365430")]
		public static extern SafeHFILE OpenFile([In] [MarshalAs(UnmanagedType.LPStr)] string lpFileName, ref OFSTRUCT lpReOpenBuff, uint uStyle);

		/// <summary>
		/// <para>
		/// Retrieves information that describes the changes within the specified directory. The function does not report changes to the
		/// specified directory itself.
		/// </para>
		/// <para>To track changes on a volume, see change journals.</para>
		/// </summary>
		/// <param name="hDirectory">
		/// A handle to the directory to be monitored. This directory must be opened with the <c>FILE_LIST_DIRECTORY</c> access right, or an
		/// access right such as <c>GENERIC_READ</c> that includes the <c>FILE_LIST_DIRECTORY</c> access right.
		/// </param>
		/// <param name="lpBuffer">
		/// A pointer to the <c>DWORD</c>-aligned formatted buffer in which the read results are to be returned. The structure of this buffer
		/// is defined by the <c>FILE_NOTIFY_INFORMATION</c> structure. This buffer is filled either synchronously or asynchronously,
		/// depending on how the directory is opened and what value is given to the lpOverlapped parameter. For more information, see the
		/// Remarks section.
		/// </param>
		/// <param name="nBufferLength">The size of the buffer that is pointed to by the lpBuffer parameter, in bytes.</param>
		/// <param name="bWatchSubtree">
		/// If this parameter is <c>TRUE</c>, the function monitors the directory tree rooted at the specified directory. If this parameter
		/// is <c>FALSE</c>, the function monitors only the directory specified by the hDirectory parameter.
		/// </param>
		/// <param name="dwNotifyFilter">
		/// <para>
		/// The filter criteria that the function checks to determine if the wait operation has completed. This parameter can be one or more
		/// of the following values.
		/// </para>
		/// <para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>FILE_NOTIFY_CHANGE_FILE_NAME0x00000001</term>
		/// <term>
		/// Any file name change in the watched directory or subtree causes a change notification wait operation to return. Changes include
		/// renaming, creating, or deleting a file.
		/// </term>
		/// </item>
		/// <item>
		/// <term>FILE_NOTIFY_CHANGE_DIR_NAME0x00000002</term>
		/// <term>
		/// Any directory-name change in the watched directory or subtree causes a change notification wait operation to return. Changes
		/// include creating or deleting a directory.
		/// </term>
		/// </item>
		/// <item>
		/// <term>FILE_NOTIFY_CHANGE_ATTRIBUTES0x00000004</term>
		/// <term>Any attribute change in the watched directory or subtree causes a change notification wait operation to return.</term>
		/// </item>
		/// <item>
		/// <term>FILE_NOTIFY_CHANGE_SIZE0x00000008</term>
		/// <term>
		/// Any file-size change in the watched directory or subtree causes a change notification wait operation to return. The operating
		/// system detects a change in file size only when the file is written to the disk. For operating systems that use extensive caching,
		/// detection occurs only when the cache is sufficiently flushed.
		/// </term>
		/// </item>
		/// <item>
		/// <term>FILE_NOTIFY_CHANGE_LAST_WRITE0x00000010</term>
		/// <term>
		/// Any change to the last write-time of files in the watched directory or subtree causes a change notification wait operation to
		/// return. The operating system detects a change to the last write-time only when the file is written to the disk. For operating
		/// systems that use extensive caching, detection occurs only when the cache is sufficiently flushed.
		/// </term>
		/// </item>
		/// <item>
		/// <term>FILE_NOTIFY_CHANGE_LAST_ACCESS0x00000020</term>
		/// <term>
		/// Any change to the last access time of files in the watched directory or subtree causes a change notification wait operation to return.
		/// </term>
		/// </item>
		/// <item>
		/// <term>FILE_NOTIFY_CHANGE_CREATION0x00000040</term>
		/// <term>
		/// Any change to the creation time of files in the watched directory or subtree causes a change notification wait operation to return.
		/// </term>
		/// </item>
		/// <item>
		/// <term>FILE_NOTIFY_CHANGE_SECURITY0x00000100</term>
		/// <term>Any security-descriptor change in the watched directory or subtree causes a change notification wait operation to return.</term>
		/// </item>
		/// </list>
		/// </para>
		/// </param>
		/// <param name="lpBytesReturned">
		/// For synchronous calls, this parameter receives the number of bytes transferred into the lpBuffer parameter. For asynchronous
		/// calls, this parameter is undefined. You must use an asynchronous notification technique to retrieve the number of bytes transferred.
		/// </param>
		/// <param name="lpOverlapped">
		/// A pointer to an <c>OVERLAPPED</c> structure that supplies data to be used during asynchronous operation. Otherwise, this value is
		/// <c>NULL</c>. The <c>Offset</c> and <c>OffsetHigh</c> members of this structure are not used.
		/// </param>
		/// <param name="lpCompletionRoutine">
		/// A pointer to a completion routine to be called when the operation has been completed or canceled and the calling thread is in an
		/// alertable wait state. For more information about this completion routine, see <c>FileIOCompletionRoutine</c>.
		/// </param>
		/// <returns>
		/// <para>
		/// If the function succeeds, the return value is nonzero. For synchronous calls, this means that the operation succeeded. For
		/// asynchronous calls, this indicates that the operation was successfully queued.
		/// </para>
		/// <para>If the function fails, the return value is zero. To get extended error information, call <c>GetLastError</c>.</para>
		/// <para>If the network redirector or the target file system does not support this operation, the function fails with <c>ERROR_INVALID_FUNCTION</c>.</para>
		/// </returns>
		// BOOL WINAPI ReadDirectoryChangesW( _In_ HANDLE hDirectory, _Out_ LPVOID lpBuffer, _In_ DWORD nBufferLength, _In_ BOOL
		// bWatchSubtree, _In_ DWORD dwNotifyFilter, _Out_opt_ LPDWORD lpBytesReturned, _Inout_opt_ LPOVERLAPPED lpOverlapped, _In_opt_
		// LPOVERLAPPED_COMPLETION_ROUTINE lpCompletionRoutine); https://msdn.microsoft.com/en-us/library/windows/desktop/aa365465(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = true, EntryPoint = "ReadDirectoryChangesW", CharSet = CharSet.Unicode)]
		[PInvokeData("WinBase.h", MSDNShortId = "aa365465")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern unsafe bool ReadDirectoryChanges([In] HFILE hDirectory, IntPtr lpBuffer, uint nBufferLength, [MarshalAs(UnmanagedType.Bool)] bool bWatchSubtree, FILE_NOTIFY_CHANGE dwNotifyFilter,
			out uint lpBytesReturned, NativeOverlapped* lpOverlapped, FileIOCompletionRoutine lpCompletionRoutine);

		/// <summary>
		/// <para>
		/// Retrieves information that describes the changes within the specified directory, which can include extended information if that
		/// information type is specified. The function does not report changes to the specified directory itself.
		/// </para>
		/// <para>To track changes on a volume, see change journals.</para>
		/// </summary>
		/// <param name="hDirectory">
		/// <para>
		/// A handle to the directory to be monitored. This directory must be opened with the <c>FILE_LIST_DIRECTORY</c> access right, or an
		/// access right such as <c>GENERIC_READ</c> that includes the <c>FILE_LIST_DIRECTORY</c> access right.
		/// </para>
		/// </param>
		/// <param name="lpBuffer">
		/// <para>
		/// A pointer to the <c>DWORD</c>-aligned formatted buffer in which <c>ReadDirectoryChangesExW</c> should return the read results.
		/// The structure of this buffer is defined by the FILE_NOTIFY_EXTENDED_INFORMATION structure if the value of the
		/// ReadDirectoryNotifyInformationClass parameter is <c>ReadDirectoryNotifyExtendedInformation</c>, or by the FILE_NOTIFY_INFORMATION
		/// structure if ReadDirectoryNotifyInformationClass is <c>ReadDirectoryNotifyInformation</c>.
		/// </para>
		/// <para>
		/// This buffer is filled either synchronously or asynchronously, depending on how the directory is opened and what value is given to
		/// the lpOverlapped parameter. For more information, see the Remarks section.
		/// </para>
		/// </param>
		/// <param name="nBufferLength">
		/// <para>The size of the buffer to which the lpBuffer parameter points, in bytes.</para>
		/// </param>
		/// <param name="bWatchSubtree">
		/// <para>
		/// If this parameter is <c>TRUE</c>, the function monitors the directory tree rooted at the specified directory. If this parameter
		/// is <c>FALSE</c>, the function monitors only the directory specified by the hDirectory parameter.
		/// </para>
		/// </param>
		/// <param name="dwNotifyFilter">
		/// <para>
		/// The filter criteria that the function checks to determine if the wait operation has completed. This parameter can be one or more
		/// of the following values.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>FILE_NOTIFY_CHANGE_FILE_NAME 0x00000001</term>
		/// <term>
		/// Any file name change in the watched directory or subtree causes a change notification wait operation to return. Changes include
		/// renaming, creating, or deleting a file.
		/// </term>
		/// </item>
		/// <item>
		/// <term>FILE_NOTIFY_CHANGE_DIR_NAME 0x00000002</term>
		/// <term>
		/// Any directory-name change in the watched directory or subtree causes a change notification wait operation to return. Changes
		/// include creating or deleting a directory.
		/// </term>
		/// </item>
		/// <item>
		/// <term>FILE_NOTIFY_CHANGE_ATTRIBUTES 0x00000004</term>
		/// <term>Any attribute change in the watched directory or subtree causes a change notification wait operation to return.</term>
		/// </item>
		/// <item>
		/// <term>FILE_NOTIFY_CHANGE_SIZE 0x00000008</term>
		/// <term>
		/// Any file-size change in the watched directory or subtree causes a change notification wait operation to return. The operating
		/// system detects a change in file size only when the file is written to the disk. For operating systems that use extensive caching,
		/// detection occurs only when the cache is sufficiently flushed.
		/// </term>
		/// </item>
		/// <item>
		/// <term>FILE_NOTIFY_CHANGE_LAST_WRITE 0x00000010</term>
		/// <term>
		/// Any change to the last write-time of files in the watched directory or subtree causes a change notification wait operation to
		/// return. The operating system detects a change to the last write-time only when the file is written to the disk. For operating
		/// systems that use extensive caching, detection occurs only when the cache is sufficiently flushed.
		/// </term>
		/// </item>
		/// <item>
		/// <term>FILE_NOTIFY_CHANGE_LAST_ACCESS 0x00000020</term>
		/// <term>
		/// Any change to the last access time of files in the watched directory or subtree causes a change notification wait operation to return.
		/// </term>
		/// </item>
		/// <item>
		/// <term>FILE_NOTIFY_CHANGE_CREATION 0x00000040</term>
		/// <term>
		/// Any change to the creation time of files in the watched directory or subtree causes a change notification wait operation to return.
		/// </term>
		/// </item>
		/// <item>
		/// <term>FILE_NOTIFY_CHANGE_SECURITY 0x00000100</term>
		/// <term>Any security-descriptor change in the watched directory or subtree causes a change notification wait operation to return.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="lpBytesReturned">
		/// <para>
		/// For synchronous calls, this parameter receives the number of bytes transferred into the lpBuffer parameter. For asynchronous
		/// calls, this parameter is undefined. You must use an asynchronous notification technique to retrieve the number of bytes transferred.
		/// </para>
		/// </param>
		/// <param name="lpOverlapped">
		/// <para>
		/// A pointer to an OVERLAPPED structure that supplies data to be used during asynchronous operation. Otherwise, this value is
		/// <c>NULL</c>. The <c>Offset</c> and <c>OffsetHigh</c> members of this structure are not used.
		/// </para>
		/// </param>
		/// <param name="lpCompletionRoutine">
		/// <para>
		/// A pointer to a completion routine to be called when the operation has been completed or canceled and the calling thread is in an
		/// alertable wait state. For more information about this completion routine, see FileIOCompletionRoutine.
		/// </para>
		/// </param>
		/// <param name="ReadDirectoryNotifyInformationClass">
		/// <para>
		/// The type of information that <c>ReadDirectoryChangesExW</c> should write to the buffer to which the lpBuffer parameter points.
		/// Specify <c>ReadDirectoryNotifyInformation</c> to indicate that the information should consist of FILE_NOTIFY_INFORMATION
		/// structures, or <c>ReadDirectoryNotifyExtendedInformation</c> to indicate that the information should consist of
		/// FILE_NOTIFY_EXTENDED_INFORMATION structures.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>
		/// If the function succeeds, the return value is nonzero. For synchronous calls, this means that the operation succeeded. For
		/// asynchronous calls, this indicates that the operation was successfully queued.
		/// </para>
		/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
		/// <para>If the network redirector or the target file system does not support this operation, the function fails with <c>ERROR_INVALID_FUNCTION</c>.</para>
		/// </returns>
		/// <remarks>
		/// <para>To obtain a handle to a directory, use the CreateFile function with the <c>FILE_FLAG_BACKUP_SEMANTICS</c> flag.</para>
		/// <para>
		/// A call to <c>ReadDirectoryChangesExW</c> can be completed synchronously or asynchronously. To specify asynchronous completion,
		/// open the directory with CreateFile as shown above, but additionally specify the <c>FILE_FLAG_OVERLAPPED</c> attribute in the
		/// dwFlagsAndAttributes parameter. Then specify an OVERLAPPED structure when you call <c>ReadDirectoryChangesExW</c>.
		/// </para>
		/// <para>
		/// When you first call <c>ReadDirectoryChangesExW</c>, the system allocates a buffer to store change information. This buffer is
		/// associated with the directory handle until it is closed and its size does not change during its lifetime. Directory changes that
		/// occur between calls to this function are added to the buffer and then returned with the next call. If the buffer overflows, the
		/// entire contents of the buffer are discarded, the lpBytesReturned parameter contains zero, and the <c>ReadDirectoryChangesExW</c>
		/// function fails with the error code <c>ERROR_NOTIFY_ENUM_DIR</c>.
		/// </para>
		/// <para>
		/// Upon successful synchronous completion, the lpBuffer parameter is a formatted buffer and the number of bytes written to the
		/// buffer is available in lpBytesReturned. If the number of bytes transferred is zero, the buffer was either too large for the
		/// system to allocate or too small to provide detailed information on all the changes that occurred in the directory or subtree. In
		/// this case, you should compute the changes by enumerating the directory or subtree.
		/// </para>
		/// <para>For asynchronous completion, you can receive notification in one of three ways:</para>
		/// <list type="bullet">
		/// <item>
		/// <term>
		/// Using the GetOverlappedResult function. To receive notification through <c>GetOverlappedResult</c>, do not specify a completion
		/// routine in the lpCompletionRoutine parameter. Be sure to set the <c>hEvent</c> member of the OVERLAPPED structure to a unique event.
		/// </term>
		/// </item>
		/// <item>
		/// <term>
		/// Using the GetQueuedCompletionStatus function. To receive notification through <c>GetQueuedCompletionStatus</c>, do not specify a
		/// completion routine in lpCompletionRoutine. Associate the directory handle hDirectory with a completion port by calling the
		/// CreateIoCompletionPort function.
		/// </term>
		/// </item>
		/// <item>
		/// <term>
		/// Using a completion routine. To receive notification through a completion routine, do not associate the directory with a
		/// completion port. Specify a completion routine in lpCompletionRoutine. This routine is called whenever the operation has been
		/// completed or canceled while the thread is in an alertable wait state. The <c>hEvent</c> member of the OVERLAPPED structure is not
		/// used by the system, so you can use it yourself.
		/// </term>
		/// </item>
		/// </list>
		/// <para>For more information, see Synchronous and Asynchronous I/O.</para>
		/// <para>
		/// <c>ReadDirectoryChangesExW</c> fails with <c>ERROR_INVALID_PARAMETER</c> when the buffer length is greater than 64 KB and the
		/// application is monitoring a directory over the network. This is due to a packet size limitation with the underlying file sharing protocols.
		/// </para>
		/// <para><c>ReadDirectoryChangesExW</c> fails with <c>ERROR_NOACCESS</c> when the buffer is not aligned on a <c>DWORD</c> boundary.</para>
		/// <para>If you opened the file using the short name, you can receive change notifications for the short name.</para>
		/// <para><c>ReadDirectoryChangesExW</c> is currently supported only for the NTFS file system.</para>
		/// <para>Transacted Operations</para>
		/// <para>
		/// If there is a transaction bound to the directory handle, then the notifications follow the appropriate transaction isolation rules.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winbase/nf-winbase-readdirectorychangesexw BOOL ReadDirectoryChangesExW(
		// HANDLE hDirectory, LPVOID lpBuffer, DWORD nBufferLength, BOOL bWatchSubtree, DWORD dwNotifyFilter, LPDWORD lpBytesReturned,
		// LPOVERLAPPED lpOverlapped, LPOVERLAPPED_COMPLETION_ROUTINE lpCompletionRoutine, READ_DIRECTORY_NOTIFY_INFORMATION_CLASS
		// ReadDirectoryNotifyInformationClass );
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("winbase.h", MSDNShortId = "90C2F258-094C-4A0E-80E7-3FA241D288EA")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static unsafe extern bool ReadDirectoryChangesExW(HFILE hDirectory, IntPtr lpBuffer, uint nBufferLength, [MarshalAs(UnmanagedType.Bool)] bool bWatchSubtree, FILE_NOTIFY_CHANGE dwNotifyFilter, out uint lpBytesReturned,
			NativeOverlapped* lpOverlapped, FileIOCompletionRoutine lpCompletionRoutine, READ_DIRECTORY_NOTIFY_INFORMATION_CLASS ReadDirectoryNotifyInformationClass);

		/// <summary>
		/// <para>Reopens the specified file system object with different access rights, sharing mode, and flags.</para>
		/// </summary>
		/// <param name="hOriginalFile">
		/// <para>A handle to the object to be reopened. The object must have been created by the CreateFile function.</para>
		/// </param>
		/// <param name="dwDesiredAccess">
		/// <para>
		/// The required access to the object. For a list of values, see File Security and Access Rights. You cannot request an access mode
		/// that conflicts with the sharing mode specified in a previous open request whose handle is still open.
		/// </para>
		/// <para>
		/// If this parameter is zero (0), the application can query device attributes without accessing the device. This is useful if an
		/// application wants to determine the size of a floppy disk drive and the formats it supports without requiring a floppy in the drive.
		/// </para>
		/// </param>
		/// <param name="dwShareMode">
		/// <para>
		/// The sharing mode of the object. You cannot request a sharing mode that conflicts with the access mode specified in a previous
		/// open request whose handle is still open.
		/// </para>
		/// <para>
		/// If this parameter is zero (0) and CreateFile succeeds, the object cannot be shared and cannot be opened again until the handle is closed.
		/// </para>
		/// <para>
		/// To enable other processes to share the object while your process has it open, use a combination of one or more of the following
		/// values to specify the type of access they can request when they open the object. These sharing options remain in effect until you
		/// close the handle to the object.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>FILE_SHARE_DELETE 0x00000004</term>
		/// <term>
		/// Enables subsequent open operations on the object to request delete access. Otherwise, other processes cannot open the object if
		/// they request delete access. If the object has already been opened with delete access, the sharing mode must include this flag.
		/// </term>
		/// </item>
		/// <item>
		/// <term>FILE_SHARE_READ 0x00000001</term>
		/// <term>
		/// Enables subsequent open operations on the object to request read access. Otherwise, other processes cannot open the object if
		/// they request read access. If the object has already been opened with read access, the sharing mode must include this flag.
		/// </term>
		/// </item>
		/// <item>
		/// <term>FILE_SHARE_WRITE 0x00000002</term>
		/// <term>
		/// Enables subsequent open operations on the object to request write access. Otherwise, other processes cannot open the object if
		/// they request write access. If the object has already been opened with write access, the sharing mode must include this flag.
		/// </term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="dwFlagsAndAttributes">
		/// <para>TBD</para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is an open handle to the specified file.</para>
		/// <para>If the function fails, the return value is <c>INVALID_HANDLE_VALUE</c>. To get extended error information, call GetLastError.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The dwFlags parameter cannot contain any of the file attribute flags ( <c>FILE_ATTRIBUTE_*</c>). These can only be specified when
		/// the file is created.
		/// </para>
		/// <para>In Windows 8 and Windows Server 2012, this function is supported by the following technologies.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Technology</term>
		/// <term>Supported</term>
		/// </listheader>
		/// <item>
		/// <term>Server Message Block (SMB) 3.0 protocol</term>
		/// <term>Yes</term>
		/// </item>
		/// <item>
		/// <term>SMB 3.0 Transparent Failover (TFO)</term>
		/// <term>Yes</term>
		/// </item>
		/// <item>
		/// <term>SMB 3.0 with Scale-out File Shares (SO)</term>
		/// <term>Yes</term>
		/// </item>
		/// <item>
		/// <term>Cluster Shared Volume File System (CsvFS)</term>
		/// <term>Yes</term>
		/// </item>
		/// <item>
		/// <term>Resilient File System (ReFS)</term>
		/// <term>Yes</term>
		/// </item>
		/// </list>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winbase/nf-winbase-reopenfile HANDLE ReOpenFile( HANDLE hOriginalFile, DWORD
		// dwDesiredAccess, DWORD dwShareMode, DWORD dwFlagsAndAttributes );
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("winbase.h", MSDNShortId = "56d8a4b1-e3b5-4134-8d21-bf40761e9dcc")]
		public static extern SafeHFILE ReOpenFile(HFILE hOriginalFile, FileAccess dwDesiredAccess, FileShare dwShareMode, FileFlagsAndAttributes dwFlagsAndAttributes);

		/// <summary>
		/// Replaces one file with another file, with the option of creating a backup copy of the original file. The replacement file assumes
		/// the name of the replaced file and its identity.
		/// </summary>
		/// <param name="lpReplacedFileName">
		/// <para>The name of the file to be replaced.</para>
		/// <para>
		/// In the ANSI version of this function, the name is limited to <c>MAX_PATH</c> characters. To extend this limit to 32,767 wide
		/// characters, call the Unicode version of the function and prepend "\\?\" to the path. For more information, see Naming a File.
		/// </para>
		/// <para>
		/// This file is opened with the <c>GENERIC_READ</c>, <c>DELETE</c>, and <c>SYNCHRONIZE</c> access rights. The sharing mode is
		/// <c>FILE_SHARE_READ</c> | <c>FILE_SHARE_WRITE</c> | <c>FILE_SHARE_DELETE</c>.
		/// </para>
		/// <para>The caller must have write access to the file to be replaced. For more information, see File Security and Access Rights.</para>
		/// </param>
		/// <param name="lpReplacementFileName">
		/// <para>The name of the file that will replace the lpReplacedFileName file.</para>
		/// <para>
		/// In the ANSI version of this function, the name is limited to <c>MAX_PATH</c> characters. To extend this limit to 32,767 wide
		/// characters, call the Unicode version of the function and prepend "\\?\" to the path. For more information, see Naming a File.
		/// </para>
		/// <para>
		/// The function attempts to open this file with the <c>SYNCHRONIZE</c>, <c>GENERIC_READ</c>, <c>GENERIC_WRITE</c>, <c>DELETE</c>,
		/// and <c>WRITE_DAC</c> access rights so that it can preserve all attributes and ACLs. If this fails, the function attempts to open
		/// the file with the <c>SYNCHRONIZE</c>, <c>GENERIC_READ</c>, <c>DELETE</c>, and <c>WRITE_DAC</c> access rights. No sharing mode is specified.
		/// </para>
		/// </param>
		/// <param name="lpBackupFileName">
		/// <para>
		/// The name of the file that will serve as a backup copy of the lpReplacedFileName file. If this parameter is <c>NULL</c>, no backup
		/// file is created. See the Remarks section for implementation details on the backup file.
		/// </para>
		/// <para>
		/// In the ANSI version of this function, the name is limited to <c>MAX_PATH</c> characters. To extend this limit to 32,767 wide
		/// characters, call the Unicode version of the function and prepend "\\?\" to the path. For more information, see Naming a File.
		/// </para>
		/// </param>
		/// <param name="dwReplaceFlags">
		/// <para>The replacement options. This parameter can be one or more of the following values.</para>
		/// <para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>REPLACEFILE_WRITE_THROUGH0x00000001</term>
		/// <term>This value is not supported.</term>
		/// </item>
		/// <item>
		/// <term>REPLACEFILE_IGNORE_MERGE_ERRORS0x00000002</term>
		/// <term>
		/// Ignores errors that occur while merging information (such as attributes and ACLs) from the replaced file to the replacement file.
		/// Therefore, if you specify this flag and do not have WRITE_DAC access, the function succeeds but the ACLs are not preserved.
		/// </term>
		/// </item>
		/// <item>
		/// <term>REPLACEFILE_IGNORE_ACL_ERRORS0x00000004</term>
		/// <term>
		/// Ignores errors that occur while merging ACL information from the replaced file to the replacement file. Therefore, if you specify
		/// this flag and do not have WRITE_DAC access, the function succeeds but the ACLs are not preserved. To compile an application that
		/// uses this value, define the _WIN32_WINNT macro as 0x0600 or later.Windows Server 2003 and Windows XP: This value is not supported.
		/// </term>
		/// </item>
		/// </list>
		/// </para>
		/// </param>
		/// <param name="lpExclude">Reserved for future use.</param>
		/// <param name="lpReserved">Reserved for future use.</param>
		/// <returns>
		/// <para>If the function succeeds, the return value is nonzero.</para>
		/// <para>
		/// If the function fails, the return value is zero. To get extended error information, call <c>GetLastError</c>. The following are
		/// possible error codes for this function.
		/// </para>
		/// <para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code/value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>ERROR_UNABLE_TO_MOVE_REPLACEMENT1176 (0x498)</term>
		/// <term>
		/// The replacement file could not be renamed. If lpBackupFileName was specified, the replaced and replacement files retain their
		/// original file names. Otherwise, the replaced file no longer exists and the replacement file exists under its original name.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ERROR_UNABLE_TO_MOVE_REPLACEMENT_21177 (0x499)</term>
		/// <term>
		/// The replacement file could not be moved. The replacement file still exists under its original name; however, it has inherited the
		/// file streams and attributes from the file it is replacing. The file to be replaced still exists with a different name. If
		/// lpBackupFileName is specified, it will be the name of the replaced file.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ERROR_UNABLE_TO_REMOVE_REPLACED1175 (0x497)</term>
		/// <term>The replaced file could not be deleted. The replaced and replacement files retain their original file names.</term>
		/// </item>
		/// </list>
		/// </para>
		/// <para>
		/// If any other error is returned, such as <c>ERROR_INVALID_PARAMETER</c>, the replaced and replacement files will retain their
		/// original file names. In this scenario, a backup file does not exist and it is not guaranteed that the replacement file will have
		/// inherited all of the attributes and streams of the replaced file.
		/// </para>
		/// </returns>
		// BOOL WINAPI ReplaceFile( _In_ LPCTSTR lpReplacedFileName, _In_ LPCTSTR lpReplacementFileName, _In_opt_ LPCTSTR lpBackupFileName,
		// _In_ DWORD dwReplaceFlags, _Reserved_ LPVOID lpExclude, _Reserved_ LPVOID lpReserved); https://msdn.microsoft.com/en-us/library/windows/desktop/aa365512(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = true, CharSet = CharSet.Auto)]
		[PInvokeData("WinBase.h", MSDNShortId = "aa365512")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool ReplaceFile(string lpReplacedFileName, string lpReplacementFileName, string lpBackupFileName, REPLACEFILE dwReplaceFlags, [Optional] IntPtr lpExclude, [Optional] IntPtr lpReserved);

		/// <summary>
		/// <para>
		/// Causes the file I/O functions to use the ANSI character set code page for the current process. This function is useful for 8-bit
		/// console input and output operations.
		/// </para>
		/// </summary>
		/// <returns>
		/// <para>This function does not return a value.</para>
		/// </returns>
		// void WINAPI SetFileApisToANSI(void);
		[DllImport(Lib.Kernel32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("WinBase.h", MSDNShortId = "aa365533")]
		public static extern void SetFileApisToANSI();

		/// <summary>
		/// <para>
		/// Causes the file I/O functions for the process to use the OEM character set code page. This function is useful for 8-bit console
		/// input and output operations.
		/// </para>
		/// </summary>
		/// <returns>
		/// <para>This function does not return a value.</para>
		/// </returns>
		// void WINAPI SetFileApisToOEM(void);
		[DllImport(Lib.Kernel32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("WinBase.h", MSDNShortId = "aa365534")]
		public static extern void SetFileApisToOEM();

		/// <summary>
		/// <para>
		/// Requests that bandwidth for the specified file stream be reserved. The reservation is specified as a number of bytes in a period
		/// of milliseconds for I/O requests on the specified file handle.
		/// </para>
		/// </summary>
		/// <param name="hFile">
		/// <para>A handle to the file.</para>
		/// </param>
		/// <param name="nPeriodMilliseconds">
		/// <para>
		/// The period of the reservation, in milliseconds. The period is the time from which the I/O is issued to the kernel until the time
		/// the I/O should be completed. The minimum supported value for the file stream can be determined by looking at the value returned
		/// through the lpPeriodMilliseconds parameter to the GetFileBandwidthReservation function, on a handle that has not had a bandwidth
		/// reservation set.
		/// </para>
		/// </param>
		/// <param name="nBytesPerPeriod">
		/// <para>
		/// The bandwidth to reserve, in bytes per period. The maximum supported value for the file stream can be determined by looking at
		/// the value returned through the lpBytesPerPeriod parameter to the GetFileBandwidthReservation function, on a handle that has not
		/// had a bandwidth reservation set.
		/// </para>
		/// </param>
		/// <param name="bDiscardable">
		/// <para>
		/// Indicates whether I/O should be completed with an error if a driver is unable to satisfy an I/O operation before the period
		/// expires. If one of the drivers for the specified file stream does not support this functionality, this function may return
		/// success and ignore the flag. To verify whether the setting will be honored, call the GetFileBandwidthReservation function using
		/// the same hFile handle and examine the *pDiscardable return value.
		/// </para>
		/// </param>
		/// <param name="lpTransferSize">
		/// <para>
		/// A pointer to a variable that receives the minimum size of any individual I/O request that may be issued by the application. All
		/// I/O requests should be multiples of TransferSize.
		/// </para>
		/// </param>
		/// <param name="lpNumOutstandingRequests">
		/// <para>
		/// A pointer to a variable that receives the number of TransferSize chunks the application should allow to be outstanding with the
		/// operating system. This allows the storage stack to keep the device busy and allows maximum throughput.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Returns nonzero if successful or zero otherwise.</para>
		/// <para>
		/// A reservation can fail if there is not enough bandwidth available on the volume because of existing reservations; in this case
		/// <c>ERROR_NO_SYSTEM_RESOURCES</c> is returned.
		/// </para>
		/// <para>To get extended error information, call GetLastError.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The requested bandwidth reservation must be greater than or equal to one packet per period. The minimum period, in milliseconds,
		/// maximum bytes per period, and minimum transfer size, in bytes, for a specific volume are returned through the
		/// lpPeriodMilliseconds, lpBytesPerPeriod, and lpTransferSize parameters to GetFileBandwidthReservation on a handle that has not
		/// been used in a call to <c>SetFileBandwidthReservation</c>. In other words:
		/// </para>
		/// <para>1 ≤ (nBytesPerPeriod)×(lpPeriodMilliseconds)/(lpTransferSize)/(nPeriodMilliseconds)</para>
		/// <para>IIn Windows 8 and Windows Server 2012, this function is supported by the following technologies.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Technology</term>
		/// <term>Supported</term>
		/// </listheader>
		/// <item>
		/// <term>Server Message Block (SMB) 3.0 protocol</term>
		/// <term>No</term>
		/// </item>
		/// <item>
		/// <term>SMB 3.0 Transparent Failover (TFO)</term>
		/// <term>No</term>
		/// </item>
		/// <item>
		/// <term>SMB 3.0 with Scale-out File Shares (SO)</term>
		/// <term>No</term>
		/// </item>
		/// <item>
		/// <term>Cluster Shared Volume File System (CsvFS)</term>
		/// <term>No</term>
		/// </item>
		/// <item>
		/// <term>Resilient File System (ReFS)</term>
		/// <term>Yes</term>
		/// </item>
		/// </list>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winbase/nf-winbase-setfilebandwidthreservation BOOL
		// SetFileBandwidthReservation( HANDLE hFile, DWORD nPeriodMilliseconds, DWORD nBytesPerPeriod, BOOL bDiscardable, LPDWORD
		// lpTransferSize, LPDWORD lpNumOutstandingRequests );
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("winbase.h", MSDNShortId = "a22bd8f3-4fbf-4f77-b8b6-7e786942615a")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool SetFileBandwidthReservation(HFILE hFile, uint nPeriodMilliseconds, uint nBytesPerPeriod, [MarshalAs(UnmanagedType.Bool)] bool bDiscardable, out uint lpTransferSize, out uint lpNumOutstandingRequests);

		/// <summary>
		/// <para>
		/// Sets the notification modes for a file handle, allowing you to specify how completion notifications work for the specified file.
		/// </para>
		/// </summary>
		/// <param name="FileHandle">
		/// <para>A handle to the file.</para>
		/// </param>
		/// <param name="Flags">
		/// <para>
		/// The modes to be set. One or more modes can be set at the same time; however, after a mode has been set for a file handle, it
		/// cannot be removed.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>FILE_SKIP_COMPLETION_PORT_ON_SUCCESS 0x1</term>
		/// <term>
		/// If the following three conditions are true, the I/O Manager does not queue a completion entry to the port, when it would
		/// ordinarily do so. The conditions are: When the FileHandle parameter is a socket, this mode is only compatible with Layered
		/// Service Providers (LSP) that return Installable File Systems (IFS) handles. To detect whether a non-IFS LSP is installed, use the
		/// WSAEnumProtocols function and examine the dwServiceFlag1 member in each returned WSAPROTOCOL_INFO structure. If the
		/// XP1_IFS_HANDLES (0x20000) bit is cleared then the specified LSP is not an IFS LSP. Vendors that have non-IFS LSPs are encouraged
		/// to migrate to the Windows Filtering Platform (WFP).
		/// </term>
		/// </item>
		/// <item>
		/// <term>FILE_SKIP_SET_EVENT_ON_HANDLE 0x2</term>
		/// <term>
		/// The I/O Manager does not set the event for the file object if a request returns with a success code, or the error returned is
		/// ERROR_PENDING and the function that is called is not a synchronous function. If an explicit event is provided for the request, it
		/// is still signaled.
		/// </term>
		/// </item>
		/// </list>
		/// </param>
		/// <returns>
		/// <para>Returns nonzero if successful or zero otherwise.</para>
		/// <para>To get extended error information, call GetLastError.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// To compile an application that uses this function, define the <c>_WIN32_WINNT</c> macro as 0x0600 or later. For more information,
		/// see Using the Windows Headers.
		/// </para>
		/// <para>In Windows 8 and Windows Server 2012, this function is supported by the following technologies.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Technology</term>
		/// <term>Supported</term>
		/// </listheader>
		/// <item>
		/// <term>Server Message Block (SMB) 3.0 protocol</term>
		/// <term>Yes</term>
		/// </item>
		/// <item>
		/// <term>SMB 3.0 Transparent Failover (TFO)</term>
		/// <term>Yes</term>
		/// </item>
		/// <item>
		/// <term>SMB 3.0 with Scale-out File Shares (SO)</term>
		/// <term>Yes</term>
		/// </item>
		/// <item>
		/// <term>Cluster Shared Volume File System (CsvFS)</term>
		/// <term>Yes</term>
		/// </item>
		/// <item>
		/// <term>Resilient File System (ReFS)</term>
		/// <term>Yes</term>
		/// </item>
		/// </list>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winbase/nf-winbase-setfilecompletionnotificationmodes BOOL
		// SetFileCompletionNotificationModes( HANDLE FileHandle, UCHAR Flags );
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("winbase.h", MSDNShortId = "23796484-ee47-4f80-856d-5a5d5635547c")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool SetFileCompletionNotificationModes(HFILE FileHandle, FILE_NOTIFICATION_MODE Flags);

		/// <summary>
		/// <para>
		/// Associates a virtual address range with the specified file handle. This indicates that the kernel should optimize any further
		/// asynchronous I/O requests with overlapped structures inside this range. The overlapped range is locked in memory, and then
		/// unlocked when the file is closed. After a range is associated with a file handle, it cannot be disassociated.
		/// </para>
		/// </summary>
		/// <param name="FileHandle">
		/// <para>A handle to the file.</para>
		/// <para>This file handle must be opened with <c>FILE_READ_ATTRIBUTES</c> access rights.</para>
		/// </param>
		/// <param name="OverlappedRangeStart">
		/// <para>The starting address for the range.</para>
		/// </param>
		/// <param name="Length">
		/// <para>The length of the range, in bytes.</para>
		/// </param>
		/// <returns>
		/// <para>Returns nonzero if successful or zero otherwise.</para>
		/// <para>To get extended error information, call <c>GetLastError</c>.</para>
		/// </returns>
		// BOOL WINAPI SetFileIoOverlappedRange( _In_ HANDLE FileHandle, _In_ PUCHAR OverlappedRangeStart, _In_ ULONG Length);
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("WinBase.h", MSDNShortId = "aa365540")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool SetFileIoOverlappedRange([In] HFILE FileHandle, IntPtr OverlappedRangeStart, uint Length);

		/// <summary>Sets the short name for the specified file. The file must be on an NTFS file system volume.</summary>
		/// <param name="hFile">
		/// A handle to the file. The file must be opened with either the <c>GENERIC_ALL</c> access right or <c>GENERIC_WRITE</c>|
		/// <c>DELETE</c>, and with the <c>FILE_FLAG_BACKUP_SEMANTICS</c> file attribute.
		/// </param>
		/// <param name="lpShortName">
		/// <para>A pointer to a string that specifies the short name for the file.</para>
		/// <para>
		/// Specifying an empty (zero-length) string will remove the short file name, if it exists for the file specified by the hFile
		/// parameter. If a short file name does not exist, the function will do nothing and return success.
		/// </para>
		/// <para>
		/// <c>Windows Server 2008, Windows Vista, Windows Server 2003 and Windows XP:</c> This behavior is not supported. The parameter must
		/// contain a valid string of one or more characters.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is nonzero.</para>
		/// <para>
		/// If the function fails, the return value is zero. To get extended error information, call <c>GetLastError</c>. <c>GetLastError</c>
		/// may return one of the following error codes that are specific to this function.
		/// </para>
		/// <para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>ERROR_ALREADY_EXISTS</term>
		/// <term>The specified short name is not unique.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_INVALID_PARAMETER</term>
		/// <term>Either the specified file has been opened in case-sensitive mode or the specified short name is invalid.</term>
		/// </item>
		/// </list>
		/// </para>
		/// </returns>
		// BOOL WINAPI SetFileShortName( _In_ HANDLE hFile, _In_ LPCTSTR lpShortName); https://msdn.microsoft.com/en-us/library/windows/desktop/aa365543(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = true, CharSet = CharSet.Auto)]
		[PInvokeData("WinBase.h", MSDNShortId = "aa365543")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool SetFileShortName([In] HFILE hFile, string lpShortName);

		/// <summary>Sets the label of a file system volume.</summary>
		/// <param name="lpRootPathName">
		/// A pointer to a string that contains the volume's drive letter (for example, X:\) or the path of a mounted folder that is
		/// associated with the volume (for example, Y:\MountX\). The string must end with a trailing backslash ('\'). If this parameter is
		/// <c>NULL</c>, the root of the current directory is used.
		/// </param>
		/// <param name="lpVolumeName">
		/// A pointer to a string that contains the new label for the volume. If this parameter is <c>NULL</c>, the function deletes any
		/// existing label from the specified volume and does not assign a new label.
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is nonzero.</para>
		/// <para>If the function fails, the return value is zero. To get extended error information, call <c>GetLastError</c>.</para>
		/// </returns>
		// BOOL WINAPI SetVolumeLabel( _In_opt_ LPCTSTR lpRootPathName, _In_opt_ LPCTSTR lpVolumeName); https://msdn.microsoft.com/en-us/library/windows/desktop/aa365560(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = true, CharSet = CharSet.Auto)]
		[PInvokeData("WinBase.h", MSDNShortId = "aa365560")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool SetVolumeLabel(string lpRootPathName, string lpVolumeName);

		/// <summary>Associates a volume with a drive letter or a directory on another volume.</summary>
		/// <param name="lpszVolumeMountPoint">
		/// The user-mode path to be associated with the volume. This may be a drive letter (for example, "X:\") or a directory on another
		/// volume (for example, "Y:\MountX\"). The string must end with a trailing backslash ('\').
		/// </param>
		/// <param name="lpszVolumeName">
		/// A volume <c>GUID</c> path for the volume. This string must be of the form "\\?\Volume{GUID}\" where GUID is a <c>GUID</c> that
		/// identifies the volume. The "\\?\" turns off path parsing and is ignored as part of the path, as discussed in Naming a Volume.
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is nonzero.</para>
		/// <para>If the function fails, the return value is zero. To get extended error information, call <c>GetLastError</c>.</para>
		/// <para>
		/// If the lpszVolumeMountPoint parameter contains a path to a mounted folder, <c>GetLastError</c> returns
		/// <c>ERROR_DIR_NOT_EMPTY</c>, even if the directory is empty.
		/// </para>
		/// </returns>
		// BOOL WINAPI SetVolumeMountPoint( _In_ LPCTSTR lpszVolumeMountPoint, _In_ LPCTSTR lpszVolumeName); https://msdn.microsoft.com/en-us/library/windows/desktop/aa365561(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = true, CharSet = CharSet.Auto)]
		[PInvokeData("WinBase.h", MSDNShortId = "aa365561")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool SetVolumeMountPoint(string lpszVolumeMountPoint, string lpszVolumeName);

		/// <summary>Template method for using FindXX methods to get a list of strings.</summary>
		/// <typeparam name="THandle">The type of the handle returned by the <paramref name="first"/> method.</typeparam>
		/// <param name="first">The method that gets the first value.</param>
		/// <param name="next">The method that gets the next value.</param>
		/// <param name="strSz">The string buffer length.</param>
		/// <param name="done">The error value that indicates the enumeration has completed.</param>
		/// <returns>List of strings returned by <paramref name="first"/> and <paramref name="next"/> methods.</returns>
		private static IEnumerable<string> EnumFindMethods<THandle>(FindFirstDelegate<THandle> first, FindNextDelegate<THandle> next, uint strSz = MAX_PATH + 1, int done = Win32Error.ERROR_HANDLE_EOF) where THandle : SafeHandle
		{
			var sb = new StringBuilder((int)strSz, (int)strSz);
			THandle h = default;
			while ((h = first(sb, ref strSz)).IsInvalid)
			{
				var err = Win32Error.GetLastError();
				if (err == Win32Error.ERROR_MORE_DATA)
					AddCap();
				else
					throw err.GetException();
			}
			yield return sb.ToString();
			do
			{
				sb.Length = 0;
				if (!next(h, sb, ref strSz))
				{
					var err = Win32Error.GetLastError();
					if (err == Win32Error.ERROR_MORE_DATA)
						AddCap();
					else if (err == done)
						break;
					else
						throw err.GetException();
				}
				else
					yield return sb.ToString();
			} while (true);

			void AddCap() => sb.Capacity = strSz <= sb.Capacity ? (int)(strSz *= 2) : (int)++strSz;
		}

		/// <summary>
		/// <para>Contains extended parameters for the CopyFile2 function.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// To compile an application that uses this structure, define the <c>_WIN32_WINNT</c> macro as <c>_WIN32_WINNT_WIN8</c> or later.
		/// For more information, see Using the Windows Headers.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winbase/ns-winbase-copyfile2_extended_parameters typedef struct
		// COPYFILE2_EXTENDED_PARAMETERS { DWORD dwSize; DWORD dwCopyFlags; BOOL *pfCancel; PCOPYFILE2_PROGRESS_ROUTINE pProgressRoutine;
		// PVOID pvCallbackContext; };
		[PInvokeData("winbase.h", MSDNShortId = "a8da62e5-bc49-4aff-afaa-e774393b7120")]
		[StructLayout(LayoutKind.Sequential)]
		public struct COPYFILE2_EXTENDED_PARAMETERS
		{
			/// <summary>
			/// <para>Contains the size of this structure, .</para>
			/// </summary>
			public uint dwSize;

			/// <summary>
			/// <para>Contains a combination of zero or more of these flag values.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>COPY_FILE_ALLOW_DECRYPTED_DESTINATION 0x00000008</term>
			/// <term>The copy will be attempted even if the destination file cannot be encrypted.</term>
			/// </item>
			/// <item>
			/// <term>COPY_FILE_COPY_SYMLINK 0x00000800</term>
			/// <term>
			/// If the source file is a symbolic link, the destination file is also a symbolic link pointing to the same file as the source
			/// symbolic link.
			/// </term>
			/// </item>
			/// <item>
			/// <term>COPY_FILE_FAIL_IF_EXISTS 0x00000001</term>
			/// <term>
			/// If the destination file exists the copy operation fails immediately. If a file or directory exists with the destination name
			/// then the CopyFile2 function call will fail with either or . If COPY_FILE_RESUME_FROM_PAUSE is also specified then a failure
			/// is only triggered if the destination file does not have a valid restart header.
			/// </term>
			/// </item>
			/// <item>
			/// <term>COPY_FILE_NO_BUFFERING 0x00001000</term>
			/// <term>
			/// The copy is performed using unbuffered I/O, bypassing the system cache resources. This flag is recommended for very large
			/// file copies. It is not recommended to pause copies that are using this flag.
			/// </term>
			/// </item>
			/// <item>
			/// <term>COPY_FILE_NO_OFFLOAD 0x00040000</term>
			/// <term>Do not attempt to use the Windows Copy Offload mechanism. This is not generally recommended.</term>
			/// </item>
			/// <item>
			/// <term>COPY_FILE_OPEN_SOURCE_FOR_WRITE 0x00000004</term>
			/// <term>The file is copied and the source file is opened for write access.</term>
			/// </item>
			/// <item>
			/// <term>COPY_FILE_RESTARTABLE 0x00000002</term>
			/// <term>
			/// The file is copied in a manner that can be restarted if the same source and destination filenames are used again. This is slower.
			/// </term>
			/// </item>
			/// <item>
			/// <term>COPY_FILE_REQUEST_SECURITY_PRIVILEGES 0x00002000</term>
			/// <term>
			/// The copy is attempted, specifying for the source file and for the destination file. If these requests are denied the access
			/// request will be reduced to the highest privilege level for which access is granted. For more information see SACL Access
			/// Right. This can be used to allow the CopyFile2ProgressRoutine callback to perform operations requiring higher privileges,
			/// such as copying the security attributes for the file.
			/// </term>
			/// </item>
			/// <item>
			/// <term>COPY_FILE_RESUME_FROM_PAUSE 0x00004000</term>
			/// <term>
			/// The destination file is examined to see if it was copied using COPY_FILE_RESTARTABLE. If so the copy is resumed. If not the
			/// file will be fully copied.
			/// </term>
			/// </item>
			/// </list>
			/// </summary>
			public COPY_FILE dwCopyFlags;

			/// <summary>
			/// <para>If this flag is set to <c>TRUE</c> during the copy operation then the copy operation is canceled.</para>
			/// </summary>
			public IntPtr pfCancel;

			/// <summary>
			/// The optional address of a callback function of type <c>PCOPYFILE2_PROGRESS_ROUTINE</c> that is called each time another
			/// portion of the file has been copied. This parameter can be <c>NULL</c>. For more information on the progress callback
			/// function, see the CopyFile2ProgressRoutine callback function.
			/// </summary>
			[MarshalAs(UnmanagedType.FunctionPtr)]
			public Pcopyfile2ProgressRoutine pProgressRoutine;

			/// <summary>
			/// <para>A pointer to application-specific context information to be passed to the CopyFile2ProgressRoutine.</para>
			/// </summary>
			public IntPtr pvCallbackContext;
		}

		/// <summary>
		/// <para>Passed to the CopyFile2ProgressRoutine callback function with information about a pending copy operation.</para>
		/// </summary>
		/// <remarks>
		/// To compile an application that uses the <c>COPYFILE2_MESSAGE</c> structure, define the <c>_WIN32_WINNT</c> macro as 0x0601 or
		/// later. For more information, see Using the Windows Headers.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winbase/ns-winbase-copyfile2_message
		[PInvokeData("winbase.h", MSDNShortId = "ab841bee-90a0-4beb-99d3-764e608c3872")]
		[StructLayout(LayoutKind.Sequential)]
		public struct COPYFILE2_MESSAGE
		{
			/// <summary>
			/// <para>Value from the COPYFILE2_MESSAGE_TYPE enumeration used as a discriminant for the <c>Info</c> union within this structure.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>COPYFILE2_CALLBACK_CHUNK_STARTED 1</term>
			/// <term>
			/// Indicates a single chunk of a stream has started to be copied. Information is in the ChunkStarted structure within the Info union.
			/// </term>
			/// </item>
			/// <item>
			/// <term>COPYFILE2_CALLBACK_CHUNK_FINISHED 2</term>
			/// <term>
			/// Indicates the copy of a single chunk of a stream has completed. Information is in the ChunkFinished structure within the Info union.
			/// </term>
			/// </item>
			/// <item>
			/// <term>COPYFILE2_CALLBACK_STREAM_STARTED 3</term>
			/// <term>
			/// Indicates both source and destination handles for a stream have been opened and the copy of the stream is about to be
			/// started. Information is in the StreamStarted structure within the Info union. This does not indicate that the copy has
			/// started for that stream.
			/// </term>
			/// </item>
			/// <item>
			/// <term>COPYFILE2_CALLBACK_STREAM_FINISHED 4</term>
			/// <term>
			/// Indicates the copy operation for a stream have started to be completed, either successfully or due to a
			/// COPYFILE2_PROGRESS_STOP return from CopyFile2ProgressRoutine. Information is in the StreamFinished structure within the Info union.
			/// </term>
			/// </item>
			/// <item>
			/// <term>COPYFILE2_CALLBACK_POLL_CONTINUE 5</term>
			/// <term>May be sent periodically. Information is in the PollContinue structure within the Info union.</term>
			/// </item>
			/// <item>
			/// <term>COPYFILE2_CALLBACK_ERROR 6</term>
			/// <term>An error was encountered during the copy operation. Information is in the Error structure within the Info union.</term>
			/// </item>
			/// </list>
			/// </summary>
			public COPYFILE2_MESSAGE_TYPE Type;

			private readonly uint dwPadding;

			/// <summary>Union</summary>
			public Union Info;

			/// <summary>Undocumented.</summary>
			[StructLayout(LayoutKind.Explicit)]
			public struct Union
			{
				/// <summary>Undocumented.</summary>
				[FieldOffset(0)]
				public ChunkStarted ChunkStarted;

				/// <summary>Undocumented.</summary>
				[FieldOffset(0)]
				public ChunkFinished ChunkFinished;

				/// <summary>Undocumented.</summary>
				[FieldOffset(0)]
				public StreamStarted StreamStarted;

				/// <summary>Undocumented.</summary>
				[FieldOffset(0)]
				public StreamFinished StreamFinished;

				/// <summary>Undocumented.</summary>
				[FieldOffset(0)]
				public PollContinue PollContinue;

				/// <summary>Undocumented.</summary>
				[FieldOffset(0)]
				public Error Error;
			}

			/// <summary>Undocumented.</summary>
			[StructLayout(LayoutKind.Sequential)]
			public struct ChunkStarted
			{
				/// <summary>
				/// <para>
				/// Indicates which stream within the file is about to be copied. The value used for identifying a stream within a file will
				/// start at one (1) and will always be higher than any previous stream for that file.
				/// </para>
				/// </summary>
				public uint dwStreamNumber;

				/// <summary>
				/// <para>This member is reserved for internal use.</para>
				/// </summary>
				public uint dwReserved;

				/// <summary>
				/// <para>Handle to the source stream.</para>
				/// </summary>
				public IntPtr hSourceFile;

				/// <summary>
				/// <para>Handle to the destination stream.</para>
				/// </summary>
				public IntPtr hDestinationFile;

				/// <summary>
				/// <para>
				/// Indicates which chunk within the current stream is about to be copied. The value used for a chunk will start at zero (0)
				/// and will always be higher than that of any previous chunk for the current stream.
				/// </para>
				/// </summary>
				public ulong uliChunkNumber;

				/// <summary>
				/// <para>Size of the copied chunk, in bytes.</para>
				/// </summary>
				public ulong uliChunkSize;

				/// <summary>
				/// <para>Size of the current stream, in bytes.</para>
				/// </summary>
				public ulong uliStreamSize;

				/// <summary>
				/// <para>Size of all streams for this file, in bytes.</para>
				/// </summary>
				public ulong uliTotalFileSize;
			}

			/// <summary>Undocumented.</summary>
			[StructLayout(LayoutKind.Sequential)]
			public struct ChunkFinished
			{
				/// <summary>
				/// <para>
				/// Indicates which stream within the file is about to be copied. The value used for identifying a stream within a file will
				/// start at one (1) and will always be higher than any previous stream for that file.
				/// </para>
				/// </summary>
				public uint dwStreamNumber;

				/// <summary>
				/// <para>This member is reserved for internal use.</para>
				/// </summary>
				public uint dwFlags;

				/// <summary>
				/// <para>Handle to the source stream.</para>
				/// </summary>
				public IntPtr hSourceFile;

				/// <summary>
				/// <para>Handle to the destination stream.</para>
				/// </summary>
				public IntPtr hDestinationFile;

				/// <summary>
				/// <para>
				/// Indicates which chunk within the current stream is in process. The value used for a chunk will start at zero (0) and will
				/// always be higher than that of any previous chunk for the current stream.
				/// </para>
				/// </summary>
				public ulong uliChunkNumber;

				/// <summary>
				/// <para>Size of the copied chunk, in bytes.</para>
				/// </summary>
				public ulong uliChunkSize;

				/// <summary>
				/// <para>Size of the current stream, in bytes.</para>
				/// </summary>
				public ulong uliStreamSize;

				/// <summary>
				/// <para>Total bytes copied for this stream so far.</para>
				/// </summary>
				public ulong uliStreamBytesTransferred;

				/// <summary>
				/// <para>Size of all streams for this file, in bytes.</para>
				/// </summary>
				public ulong uliTotalFileSize;

				/// <summary>
				/// <para>Total bytes copied for this file so far.</para>
				/// </summary>
				public ulong uliTotalBytesTransferred;
			}

			/// <summary>Undocumented.</summary>
			[StructLayout(LayoutKind.Sequential)]
			public struct StreamStarted
			{
				/// <summary>
				/// <para>
				/// Indicates which stream within the file is about to be copied. The value used for identifying a stream within a file will
				/// start at one (1) and will always be higher than any previous stream for that file.
				/// </para>
				/// </summary>
				public uint dwStreamNumber;

				/// <summary>
				/// <para>This member is reserved for internal use.</para>
				/// </summary>
				public uint dwReserved;

				/// <summary>
				/// <para>Handle to the source stream.</para>
				/// </summary>
				public IntPtr hSourceFile;

				/// <summary>
				/// <para>Handle to the destination stream.</para>
				/// </summary>
				public IntPtr hDestinationFile;

				/// <summary>
				/// <para>Size of the current stream, in bytes.</para>
				/// </summary>
				public ulong uliStreamSize;

				/// <summary>
				/// <para>Size of all streams for this file, in bytes.</para>
				/// </summary>
				public ulong uliTotalFileSize;
			}

			/// <summary>Undocumented.</summary>
			[StructLayout(LayoutKind.Sequential)]
			public struct StreamFinished
			{
				/// <summary>
				/// <para>
				/// Indicates which stream within the file is about to be copied. The value used for identifying a stream within a file will
				/// start at one (1) and will always be higher than any previous stream for that file.
				/// </para>
				/// </summary>
				public uint dwStreamNumber;

				/// <summary>
				/// <para>This member is reserved for internal use.</para>
				/// </summary>
				public uint dwReserved;

				/// <summary>
				/// <para>Handle to the source stream.</para>
				/// </summary>
				public IntPtr hSourceFile;

				/// <summary>
				/// <para>Handle to the destination stream.</para>
				/// </summary>
				public IntPtr hDestinationFile;

				/// <summary>
				/// <para>Size of the current stream, in bytes.</para>
				/// </summary>
				public ulong uliStreamSize;

				/// <summary>
				/// <para>Total bytes copied for this stream so far.</para>
				/// </summary>
				public ulong uliStreamBytesTransferred;

				/// <summary>
				/// <para>Size of all streams for this file, in bytes.</para>
				/// </summary>
				public ulong uliTotalFileSize;

				/// <summary>
				/// <para>Total bytes copied for this file so far.</para>
				/// </summary>
				public ulong uliTotalBytesTransferred;
			}

			/// <summary>Undocumented.</summary>
			[StructLayout(LayoutKind.Sequential)]
			public struct PollContinue
			{
				/// <summary>
				/// <para>This member is reserved for internal use.</para>
				/// </summary>
				public uint dwReserved;
			}

			/// <summary>Undocumented.</summary>
			[StructLayout(LayoutKind.Sequential)]
			public struct Error
			{
				/// <summary>
				/// <para>Value from the COPYFILE2_COPY_PHASE enumeration indicating the current phase of the copy at the time of the error.</para>
				/// </summary>
				public COPYFILE2_COPY_PHASE CopyPhase;

				/// <summary>
				/// <para>The number of the stream that was being processed at the time of the error.</para>
				/// </summary>
				public uint dwStreamNumber;

				/// <summary>
				/// <para>Value indicating the problem.</para>
				/// </summary>
				public HRESULT hrFailure;

				/// <summary>
				/// <para>This member is reserved for internal use.</para>
				/// </summary>
				public uint dwReserved;

				/// <summary>
				/// <para>
				/// Indicates which chunk within the current stream was being processed at the time of the error. The value used for a chunk
				/// will start at zero (0) and will always be higher than that of any previous chunk for the current stream.
				/// </para>
				/// </summary>
				public ulong uliChunkNumber;

				/// <summary>
				/// <para>Size, in bytes, of the stream being processed.</para>
				/// </summary>
				public ulong uliStreamSize;

				/// <summary>
				/// <para>Number of bytes that had been successfully transferred for the stream being processed.</para>
				/// </summary>
				public ulong uliStreamBytesTransferred;

				/// <summary>
				/// <para>Size, in bytes, of the total file being processed.</para>
				/// </summary>
				public ulong uliTotalFileSize;

				/// <summary>
				/// <para>Number of bytes that had been successfully transferred for the entire copy operation.</para>
				/// </summary>
				public ulong uliTotalBytesTransferred;
			}
		}

		/// <summary>
		/// <para>Specifies the type of ID that is being used.</para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winbase/ns-winbase-file_id_descriptor typedef struct FILE_ID_DESCRIPTOR {
		// DWORD dwSize; FILE_ID_TYPE Type; union { LARGE_INTEGER FileId; GUID ObjectId; FILE_ID_128 ExtendedFileId; } DUMMYUNIONNAME; } *LPFILE_ID_DESCRIPTOR;
		[PInvokeData("winbase.h", MSDNShortId = "9092a701-3b47-4c4c-8221-54fa3220d322")]
		[StructLayout(LayoutKind.Sequential)]
		public struct FILE_ID_DESCRIPTOR
		{
			/// <summary>
			/// <para>The size of this <c>FILE_ID_DESCRIPTOR</c> structure.</para>
			/// </summary>
			public uint dwSize;

			/// <summary>
			/// <para>The discriminator for the union indicating the type of identifier that is being passed.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>FileIdType 0</term>
			/// <term>Use the FileId member of the union.</term>
			/// </item>
			/// <item>
			/// <term>ObjectIdType 1</term>
			/// <term>Use the ObjectId member of the union.</term>
			/// </item>
			/// <item>
			/// <term>ExtendedFileIdType 2</term>
			/// <term>
			/// Use the ExtendedFileId member of the union. Windows XP, Windows Server 2003, Windows Vista, Windows Server 2008, Windows 7
			/// and Windows Server 2008 R2: This value is not supported before Windows 8 and Windows Server 2012.
			/// </term>
			/// </item>
			/// </list>
			/// </summary>
			public FILE_ID_TYPE Type;

			/// <summary>Undocumented.</summary>
			public DUMMYUNIONNAME Id;

			/// <summary>Undocumented.</summary>
			[StructLayout(LayoutKind.Explicit)]
			public struct DUMMYUNIONNAME
			{
				/// <summary>
				/// <para>The ID of the file to open.</para>
				/// </summary>
				[FieldOffset(0)]
				public long FileId;

				/// <summary>
				/// <para>The ID of the object to open.</para>
				/// </summary>
				[FieldOffset(0)]
				public Guid ObjectId;

				/// <summary>
				/// <para>A FILE_ID_128 structure containing the 128-bit file ID of the file. This is used on ReFS file systems.</para>
				/// <para>
				/// <c>Windows XP, Windows Server 2003, Windows Vista, Windows Server 2008, Windows 7 and Windows Server 2008 R2:</c> This
				/// member is not supported before Windows 8 and Windows Server 2012.
				/// </para>
				/// </summary>
				[FieldOffset(0)]
				public FILE_ID_128 ExtendedFileId;
			}
		}

		/// <summary>
		/// <para>
		/// Contains alignment information for a file. This structure is returned from the GetFileInformationByHandleEx function when
		/// <c>FileAlignmentInfo</c> is passed in the FileInformationClass parameter.
		/// </para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winbase/ns-winbase-_file_alignment_info typedef struct _FILE_ALIGNMENT_INFO {
		// ULONG AlignmentRequirement; } FILE_ALIGNMENT_INFO, *PFILE_ALIGNMENT_INFO;
		[PInvokeData("winbase.h", MSDNShortId = "a6d3cba0-d59b-45c2-a763-ecdde5b36348")]
		[StructLayout(LayoutKind.Sequential)]
		public struct FILE_ALIGNMENT_INFO
		{
			/// <summary>
			/// <para>Minimum alignment requirement, in bytes.</para>
			/// </summary>
			public uint AlignmentRequirement;
		}

		/// <summary>
		/// <para>
		/// Contains the total number of bytes that should be allocated for a file. This structure is used when calling the
		/// SetFileInformationByHandle function.
		/// </para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// The end-of-file (EOF) position for a file must always be less than or equal to the file allocation size. If the allocation size
		/// is set to a value that is less than EOF, the EOF position is automatically adjusted to match the file allocation size.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winbase/ns-winbase-_file_allocation_info typedef struct _FILE_ALLOCATION_INFO
		// { LARGE_INTEGER AllocationSize; } FILE_ALLOCATION_INFO, *PFILE_ALLOCATION_INFO;
		[PInvokeData("winbase.h", MSDNShortId = "909f1747-0099-407e-89a7-bec6331887da")]
		[StructLayout(LayoutKind.Sequential)]
		public struct FILE_ALLOCATION_INFO
		{
			/// <summary>
			/// <para>
			/// The new file allocation size, in bytes. This value is typically a multiple of the sector or cluster size for the underlying
			/// physical device.
			/// </para>
			/// </summary>
			public long AllocationSize;
		}

		/// <summary>
		/// <para>Receives the requested file attribute information. Used for any handles. Use only when calling GetFileInformationByHandleEx.</para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winbase/ns-winbase-_file_attribute_tag_info typedef struct
		// _FILE_ATTRIBUTE_TAG_INFO { DWORD FileAttributes; DWORD ReparseTag; } FILE_ATTRIBUTE_TAG_INFO, *PFILE_ATTRIBUTE_TAG_INFO;
		[PInvokeData("winbase.h", MSDNShortId = "4a2467a2-c22a-4ee6-a40e-5603ea381adc")]
		[StructLayout(LayoutKind.Sequential)]
		public struct FILE_ATTRIBUTE_TAG_INFO
		{
			/// <summary>
			/// <para>The file attribute information.</para>
			/// </summary>
			public uint FileAttributes;

			/// <summary>
			/// <para>The reparse tag.</para>
			/// </summary>
			public uint ReparseTag;
		}

		/// <summary>
		/// <para>Contains the basic information for a file. Used for file handles.</para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winbase/ns-winbase-_file_basic_info typedef struct _FILE_BASIC_INFO {
		// LARGE_INTEGER CreationTime; LARGE_INTEGER LastAccessTime; LARGE_INTEGER LastWriteTime; LARGE_INTEGER ChangeTime; DWORD
		// FileAttributes; } FILE_BASIC_INFO, *PFILE_BASIC_INFO;
		[PInvokeData("winbase.h", MSDNShortId = "7765e430-cf6b-4ccf-b5e7-9fb6e15ca6d6")]
		[StructLayout(LayoutKind.Sequential)]
		public struct FILE_BASIC_INFO
		{
			/// <summary>
			/// <para>
			/// The time the file was created in FILETIME format, which is a 64-bit value representing the number of 100-nanosecond intervals
			/// since January 1, 1601 (UTC).
			/// </para>
			/// </summary>
			public FILETIME CreationTime;

			/// <summary>
			/// <para>The time the file was last accessed in FILETIME format.</para>
			/// </summary>
			public FILETIME LastAccessTime;

			/// <summary>
			/// <para>The time the file was last written to in FILETIME format.</para>
			/// </summary>
			public FILETIME LastWriteTime;

			/// <summary>
			/// <para>The time the file was changed in FILETIME format.</para>
			/// </summary>
			public FILETIME ChangeTime;

			/// <summary>
			/// <para>
			/// The file attributes. For a list of attributes, see File Attribute Constants. If this is set to 0 in a <c>FILE_BASIC_INFO</c>
			/// structure passed to SetFileInformationByHandle then none of the attributes are changed.
			/// </para>
			/// </summary>
			public FileFlagsAndAttributes FileAttributes;
		}

		/// <summary>
		/// <para>Receives file compression information. Used for any handles. Use only when calling GetFileInformationByHandleEx.</para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winbase/ns-winbase-_file_compression_info typedef struct
		// _FILE_COMPRESSION_INFO { LARGE_INTEGER CompressedFileSize; WORD CompressionFormat; UCHAR CompressionUnitShift; UCHAR ChunkShift;
		// UCHAR ClusterShift; UCHAR Reserved[3]; } FILE_COMPRESSION_INFO, *PFILE_COMPRESSION_INFO;
		[PInvokeData("winbase.h", MSDNShortId = "2f64e7cc-e23c-4e3d-8e17-0e8e38f1ea24")]
		[StructLayout(LayoutKind.Sequential, Pack = 4)]
		public struct FILE_COMPRESSION_INFO
		{
			/// <summary>
			/// <para>The file size of the compressed file.</para>
			/// </summary>
			public long CompressedFileSize;

			/// <summary>
			/// <para>The compression format that is used to compress the file.</para>
			/// </summary>
			public ushort CompressionFormat;

			/// <summary>
			/// <para>The factor that the compression uses.</para>
			/// </summary>
			public byte CompressionUnitShift;

			/// <summary>
			/// <para>The number of chunks that are shifted by compression.</para>
			/// </summary>
			public byte ChunkShift;

			/// <summary>
			/// <para>The number of clusters that are shifted by compression.</para>
			/// </summary>
			public byte ClusterShift;

			/// <summary>
			/// <para>Reserved.</para>
			/// </summary>
			[MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
			public byte[] Reserved;
		}

		/// <summary>
		/// <para>Indicates whether a file should be deleted. Used for any handles. Use only when calling SetFileInformationByHandle.</para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winbase/ns-winbase-_file_disposition_info typedef struct
		// _FILE_DISPOSITION_INFO { BOOLEAN DeleteFile; } FILE_DISPOSITION_INFO, *PFILE_DISPOSITION_INFO;
		[PInvokeData("winbase.h", MSDNShortId = "07095f62-323a-463a-a33e-7e4ca9adcb69")]
		[StructLayout(LayoutKind.Sequential)]
		public struct FILE_DISPOSITION_INFO
		{
			/// <summary>
			/// <para>
			/// Indicates whether the file should be deleted. Set to <c>TRUE</c> to delete the file. This member has no effect if the handle
			/// was opened with <c>FILE_FLAG_DELETE_ON_CLOSE</c>.
			/// </para>
			/// </summary>
			[MarshalAs(UnmanagedType.U1)] public bool DeleteFile;
		}

		/// <summary>
		/// <para>
		/// Contains the specified value to which the end of the file should be set. Used for file handles. Use only when calling SetFileInformationByHandle.
		/// </para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winbase/ns-winbase-_file_end_of_file_info typedef struct
		// _FILE_END_OF_FILE_INFO { LARGE_INTEGER EndOfFile; } FILE_END_OF_FILE_INFO, *PFILE_END_OF_FILE_INFO;
		[PInvokeData("winbase.h", MSDNShortId = "77500ae7-654a-4b34-aaee-5c3844303271")]
		[StructLayout(LayoutKind.Sequential)]
		public struct FILE_END_OF_FILE_INFO
		{
			/// <summary>
			/// <para>The specified value for the new end of the file.</para>
			/// </summary>
			public long EndOfFile;
		}

		/// <summary>
		/// <para>
		/// Contains directory information for a file. This structure is returned from the GetFileInformationByHandleEx function when
		/// <c>FileFullDirectoryInfo</c> or <c>FileFullDirectoryRestartInfo</c> is passed in the FileInformationClass parameter.
		/// </para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// The <c>FILE_FULL_DIR_INFO</c> structure is a subset of the information in the FILE_ID_BOTH_DIR_INFO structure. If the additional
		/// information is not needed then the operation will be faster as it comes from the directory entry; <c>FILE_ID_BOTH_DIR_INFO</c>
		/// contains information from both the directory entry and the Master File Table (MFT).
		/// </para>
		/// <para>No specific access rights are required to query this information.</para>
		/// <para>
		/// All dates and times are in absolute system-time format. Absolute system time is the number of 100-nanosecond intervals since the
		/// start of the year 1601.
		/// </para>
		/// <para>
		/// This <c>FILE_FULL_DIR_INFO</c> structure must be aligned on a <c>LONGLONG</c> (8-byte) boundary. If a buffer contains two or more
		/// of these structures, the <c>NextEntryOffset</c> value in each entry, except the last, falls on an 8-byte boundary.
		/// </para>
		/// <para>
		/// To compile an application that uses this structure, define the <c>_WIN32_WINNT</c> macro as 0x0600 or later. For more
		/// information, see Using the Windows Headers.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winbase/ns-winbase-_file_full_dir_info typedef struct _FILE_FULL_DIR_INFO {
		// ULONG NextEntryOffset; ULONG FileIndex; LARGE_INTEGER CreationTime; LARGE_INTEGER LastAccessTime; LARGE_INTEGER LastWriteTime;
		// LARGE_INTEGER ChangeTime; LARGE_INTEGER EndOfFile; LARGE_INTEGER AllocationSize; ULONG FileAttributes; ULONG FileNameLength; ULONG
		// EaSize; WCHAR FileName[1]; } FILE_FULL_DIR_INFO, *PFILE_FULL_DIR_INFO;
		[PInvokeData("winbase.h", MSDNShortId = "606726e7-fd6b-4419-bd37-7282283007f8")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		public struct FILE_FULL_DIR_INFO
		{
			/// <summary>
			/// <para>
			/// The offset for the next <c>FILE_FULL_DIR_INFO</c> structure that is returned. Contains zero (0) if no other entries follow
			/// this one.
			/// </para>
			/// </summary>
			public uint NextEntryOffset;

			/// <summary>
			/// <para>
			/// The byte offset of the file within the parent directory. This member is undefined for file systems, such as NTFS, in which
			/// the position of a file within the parent directory is not fixed and can be changed at any time to maintain sort order.
			/// </para>
			/// </summary>
			public uint FileIndex;

			/// <summary>
			/// <para>The time that the file was created.</para>
			/// </summary>
			public FILETIME CreationTime;

			/// <summary>
			/// <para>The time that the file was last accessed.</para>
			/// </summary>
			public FILETIME LastAccessTime;

			/// <summary>
			/// <para>The time that the file was last written to.</para>
			/// </summary>
			public FILETIME LastWriteTime;

			/// <summary>
			/// <para>The time that the file was last changed.</para>
			/// </summary>
			public FILETIME ChangeTime;

			/// <summary>
			/// <para>
			/// The absolute new end-of-file position as a byte offset from the start of the file to the end of the default data stream of
			/// the file. Because this value is zero-based, it actually refers to the first free byte in the file. In other words,
			/// <c>EndOfFile</c> is the offset to the byte that immediately follows the last valid byte in the file.
			/// </para>
			/// </summary>
			public long EndOfFile;

			/// <summary>
			/// <para>
			/// The number of bytes that are allocated for the file. This value is usually a multiple of the sector or cluster size of the
			/// underlying physical device.
			/// </para>
			/// </summary>
			public long AllocationSize;

			/// <summary>
			/// <para>The file attributes. This member can be any valid combination of the following attributes:</para>
			/// <para>FILE_ATTRIBUTE_ARCHIVE (0x00000020)</para>
			/// <para>FILE_ATTRIBUTE_COMPRESSED (0x00000800)</para>
			/// <para>FILE_ATTRIBUTE_DIRECTORY (0x00000010)</para>
			/// <para>FILE_ATTRIBUTE_HIDDEN (0x00000002)</para>
			/// <para>FILE_ATTRIBUTE_NORMAL (0x00000080)</para>
			/// <para>FILE_ATTRIBUTE_READONLY (0x00000001)</para>
			/// <para>FILE_ATTRIBUTE_SYSTEM (0x00000004)</para>
			/// <para>FILE_ATTRIBUTE_TEMPORARY (0x00000100)</para>
			/// </summary>
			public FileFlagsAndAttributes FileAttributes;

			/// <summary>
			/// <para>The length of the file name.</para>
			/// </summary>
			public uint FileNameLength;

			/// <summary>
			/// <para>The size of the extended attributes for the file.</para>
			/// </summary>
			public uint EaSize;

			/// <summary>
			/// <para>The first character of the file name string. This is followed in memory by the remainder of the string.</para>
			/// </summary>
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_PATH)]
			public string FileName;
		}

		/// <summary>
		/// <para>Defines a 128-bit file identifier.</para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winnt/ns-winnt-_file_id_128 typedef struct _FILE_ID_128 { BYTE
		// Identifier[16]; } FILE_ID_128, *PFILE_ID_128;
		[PInvokeData("winnt.h", MSDNShortId = "254ea6a9-e1dd-4b97-91f7-2693065c4bb8")]
		[StructLayout(LayoutKind.Sequential)]
		public struct FILE_ID_128
		{
			private ulong id0;
			private ulong id1;

			/// <summary>
			/// <para>A byte array containing the 128 bit identifier.</para>
			/// </summary>
			public byte[] Identifier
			{
				get
				{
					using (var pin = new PinnedObject(id0))
						return ((IntPtr)pin).ToArray<byte>(16);
				}
				set
				{
					using (var pin = new PinnedObject(id0))
						Marshal.Copy(value, 0, pin, 16);
				}
			}
		}

		/// <summary>
		/// <para>
		/// Contains information about files in the specified directory. Used for directory handles. Use only when calling
		/// GetFileInformationByHandleEx. The number of files that are returned for each call to <c>GetFileInformationByHandleEx</c> depends
		/// on the size of the buffer that is passed to the function. Any subsequent calls to <c>GetFileInformationByHandleEx</c> on the same
		/// handle will resume the enumeration operation after the last file is returned.
		/// </para>
		/// </summary>
		/// <remarks>
		/// <para>No specific access rights are required to query this information.</para>
		/// <para>
		/// File reference numbers, also called file IDs, are guaranteed to be unique only within a static file system. They are not
		/// guaranteed to be unique over time, because file systems are free to reuse them. Nor are they guaranteed to remain constant. For
		/// example, the FAT file system generates the file reference number for a file from the byte offset of the file's directory entry
		/// record (DIRENT) on the disk. Defragmentation can change this byte offset. Thus a FAT file reference number can change over time.
		/// </para>
		/// <para>
		/// All dates and times are in absolute system-time format. Absolute system time is the number of 100-nanosecond intervals since the
		/// start of the year 1601.
		/// </para>
		/// <para>
		/// This <c>FILE_ID_BOTH_DIR_INFO</c> structure must be aligned on a <c>DWORDLONG</c> (8-byte) boundary. If a buffer contains two or
		/// more of these structures, the <c>NextEntryOffset</c> value in each entry, except the last, falls on an 8-byte boundary.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winbase/ns-winbase-_file_id_both_dir_info typedef struct
		// _FILE_ID_BOTH_DIR_INFO { DWORD NextEntryOffset; DWORD FileIndex; LARGE_INTEGER CreationTime; LARGE_INTEGER LastAccessTime;
		// LARGE_INTEGER LastWriteTime; LARGE_INTEGER ChangeTime; LARGE_INTEGER EndOfFile; LARGE_INTEGER AllocationSize; DWORD
		// FileAttributes; DWORD FileNameLength; DWORD EaSize; CCHAR ShortNameLength; WCHAR ShortName[12]; LARGE_INTEGER FileId; WCHAR
		// FileName[1]; } FILE_ID_BOTH_DIR_INFO, *PFILE_ID_BOTH_DIR_INFO;
		[PInvokeData("winbase.h", MSDNShortId = "d7011ea4-e70a-4c03-a715-6144ce0c7029")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		public struct FILE_ID_BOTH_DIR_INFO
		{
			/// <summary>
			/// <para>
			/// The offset for the next <c>FILE_ID_BOTH_DIR_INFO</c> structure that is returned. Contains zero (0) if no other entries follow
			/// this one.
			/// </para>
			/// </summary>
			public uint NextEntryOffset;

			/// <summary>
			/// <para>
			/// The byte offset of the file within the parent directory. This member is undefined for file systems, such as NTFS, in which
			/// the position of a file within the parent directory is not fixed and can be changed at any time to maintain sort order.
			/// </para>
			/// </summary>
			public uint FileIndex;

			/// <summary>
			/// <para>The time that the file was created.</para>
			/// </summary>
			public FILETIME CreationTime;

			/// <summary>
			/// <para>The time that the file was last accessed.</para>
			/// </summary>
			public FILETIME LastAccessTime;

			/// <summary>
			/// <para>The time that the file was last written to.</para>
			/// </summary>
			public FILETIME LastWriteTime;

			/// <summary>
			/// <para>The time that the file was last changed.</para>
			/// </summary>
			public FILETIME ChangeTime;

			/// <summary>
			/// <para>
			/// The absolute new end-of-file position as a byte offset from the start of the file to the end of the file. Because this value
			/// is zero-based, it actually refers to the first free byte in the file. In other words, <c>EndOfFile</c> is the offset to the
			/// byte that immediately follows the last valid byte in the file.
			/// </para>
			/// </summary>
			public long EndOfFile;

			/// <summary>
			/// <para>
			/// The number of bytes that are allocated for the file. This value is usually a multiple of the sector or cluster size of the
			/// underlying physical device.
			/// </para>
			/// </summary>
			public long AllocationSize;

			/// <summary>
			/// <para>The file attributes. This member can be any valid combination of the following attributes:</para>
			/// <para>FILE_ATTRIBUTE_ARCHIVE (0x00000020)</para>
			/// <para>FILE_ATTRIBUTE_COMPRESSED (0x00000800)</para>
			/// <para>FILE_ATTRIBUTE_DIRECTORY (0x00000010)</para>
			/// <para>FILE_ATTRIBUTE_HIDDEN (0x00000002)</para>
			/// <para>FILE_ATTRIBUTE_NORMAL (0x00000080)</para>
			/// <para>FILE_ATTRIBUTE_READONLY (0x00000001)</para>
			/// <para>FILE_ATTRIBUTE_SYSTEM (0x00000004)</para>
			/// <para>FILE_ATTRIBUTE_TEMPORARY (0x00000100)</para>
			/// </summary>
			public FileFlagsAndAttributes FileAttributes;

			/// <summary>
			/// <para>The length of the file name.</para>
			/// </summary>
			public uint FileNameLength;

			/// <summary>
			/// <para>The size of the extended attributes for the file.</para>
			/// </summary>
			public uint EaSize;

			/// <summary>
			/// <para>The length of <c>ShortName</c>.</para>
			/// </summary>
			public byte ShortNameLength;

			/// <summary>
			/// <para>The short 8.3 file naming convention (for example, "FILENAME.TXT") name of the file.</para>
			/// </summary>
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 12)]
			public string ShortName;

			/// <summary>
			/// <para>The file ID.</para>
			/// </summary>
			public long FileId;

			/// <summary>
			/// <para>The first character of the file name string. This is followed in memory by the remainder of the string.</para>
			/// </summary>
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_PATH)]
			public string FileName;
		}

		/// <summary>
		/// <para>
		/// Contains identification information for a file. This structure is returned from the GetFileInformationByHandleEx function when
		/// <c>FileIdExtdDirectoryInfo</c> (0x13) or <c>FileIdExtdDirectoryRestartInfo</c> (0x14) is passed in the FileInformationClass parameter.
		/// </para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winbase/ns-winbase-_file_id_extd_dir_info typedef struct
		// _FILE_ID_EXTD_DIR_INFO { ULONG NextEntryOffset; ULONG FileIndex; LARGE_INTEGER CreationTime; LARGE_INTEGER LastAccessTime;
		// LARGE_INTEGER LastWriteTime; LARGE_INTEGER ChangeTime; LARGE_INTEGER EndOfFile; LARGE_INTEGER AllocationSize; ULONG
		// FileAttributes; ULONG FileNameLength; ULONG EaSize; ULONG ReparsePointTag; FILE_ID_128 FileId; WCHAR FileName[1]; }
		// FILE_ID_EXTD_DIR_INFO, *PFILE_ID_EXTD_DIR_INFO;
		[PInvokeData("winbase.h", MSDNShortId = "68f222c4-beb6-4be1-a31a-c5fbebbf76f7")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
		public struct FILE_ID_EXTD_DIR_INFO
		{
			/// <summary>
			/// <para>
			/// The offset for the next <c>FILE_ID_EXTD_DIR_INFO</c> structure that is returned. Contains zero (0) if no other entries follow
			/// this one.
			/// </para>
			/// </summary>
			public uint NextEntryOffset;

			/// <summary>
			/// <para>
			/// The byte offset of the file within the parent directory. This member is undefined for file systems, such as NTFS, in which
			/// the position of a file within the parent directory is not fixed and can be changed at any time to maintain sort order.
			/// </para>
			/// </summary>
			public uint FileIndex;

			/// <summary>
			/// <para>The time that the file was created.</para>
			/// </summary>
			public FILETIME CreationTime;

			/// <summary>
			/// <para>The time that the file was last accessed.</para>
			/// </summary>
			public FILETIME LastAccessTime;

			/// <summary>
			/// <para>The time that the file was last written to.</para>
			/// </summary>
			public FILETIME LastWriteTime;

			/// <summary>
			/// <para>The time that the file was last changed.</para>
			/// </summary>
			public FILETIME ChangeTime;

			/// <summary>
			/// <para>
			/// The absolute new end-of-file position as a byte offset from the start of the file to the end of the file. Because this value
			/// is zero-based, it actually refers to the first free byte in the file. In other words, <c>EndOfFile</c> is the offset to the
			/// byte that immediately follows the last valid byte in the file.
			/// </para>
			/// </summary>
			public long EndOfFile;

			/// <summary>
			/// <para>
			/// The number of bytes that are allocated for the file. This value is usually a multiple of the sector or cluster size of the
			/// underlying physical device.
			/// </para>
			/// </summary>
			public long AllocationSize;

			/// <summary>
			/// <para>The file attributes. This member can be any valid combination of the following attributes:</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>FILE_ATTRIBUTE_ARCHIVE 32 (0x20)</term>
			/// <term>
			/// A file or directory that is an archive file or directory. Applications typically use this attribute to mark files for backup
			/// or removal .
			/// </term>
			/// </item>
			/// <item>
			/// <term>FILE_ATTRIBUTE_COMPRESSED 2048 (0x800)</term>
			/// <term>
			/// A file or directory that is compressed. For a file, all of the data in the file is compressed. For a directory, compression
			/// is the default for newly created files and subdirectories.
			/// </term>
			/// </item>
			/// <item>
			/// <term>FILE_ATTRIBUTE_DEVICE 64 (0x40)</term>
			/// <term>This value is reserved for system use.</term>
			/// </item>
			/// <item>
			/// <term>FILE_ATTRIBUTE_DIRECTORY 16 (0x10)</term>
			/// <term>The handle that identifies a directory.</term>
			/// </item>
			/// <item>
			/// <term>FILE_ATTRIBUTE_ENCRYPTED 16384 (0x4000)</term>
			/// <term>
			/// A file or directory that is encrypted. For a file, all data streams in the file are encrypted. For a directory, encryption is
			/// the default for newly created files and subdirectories.
			/// </term>
			/// </item>
			/// <item>
			/// <term>FILE_ATTRIBUTE_HIDDEN 2 (0x2)</term>
			/// <term>The file or directory is hidden. It is not included in an ordinary directory listing.</term>
			/// </item>
			/// <item>
			/// <term>FILE_ATTRIBUTE_NORMAL 128 (0x80)</term>
			/// <term>A file that does not have other attributes set. This attribute is valid only when used alone.</term>
			/// </item>
			/// <item>
			/// <term>FILE_ATTRIBUTE_NOT_CONTENT_INDEXED 8192 (0x2000)</term>
			/// <term>The file or directory is not to be indexed by the content indexing service.</term>
			/// </item>
			/// <item>
			/// <term>FILE_ATTRIBUTE_OFFLINE 4096 (0x1000)</term>
			/// <term>
			/// The data of a file is not available immediately. This attribute indicates that the file data is physically moved to offline
			/// storage. This attribute is used by Remote Storage, which is the hierarchical storage management software. Applications should
			/// not arbitrarily change this attribute.
			/// </term>
			/// </item>
			/// <item>
			/// <term>FILE_ATTRIBUTE_READONLY 1 (0x1)</term>
			/// <term>
			/// A file that is read-only. Applications can read the file, but cannot write to it or delete it. This attribute is not honored
			/// on directories. For more information, see You cannot view or change the Read-only or the System attributes of folders in
			/// Windows Server 2003, in Windows XP, in Windows Vista or in Windows 7.
			/// </term>
			/// </item>
			/// <item>
			/// <term>FILE_ATTRIBUTE_REPARSE_POINT 1024 (0x400)</term>
			/// <term>A file or directory that has an associated reparse point, or a file that is a symbolic link.</term>
			/// </item>
			/// <item>
			/// <term>FILE_ATTRIBUTE_SPARSE_FILE 512 (0x200)</term>
			/// <term>A file that is a sparse file.</term>
			/// </item>
			/// <item>
			/// <term>FILE_ATTRIBUTE_SYSTEM 4 (0x4)</term>
			/// <term>A file or directory that the operating system uses a part of, or uses exclusively.</term>
			/// </item>
			/// <item>
			/// <term>FILE_ATTRIBUTE_TEMPORARY 256 (0x100)</term>
			/// <term>
			/// A file that is being used for temporary storage. File systems avoid writing data back to mass storage if sufficient cache
			/// memory is available, because typically, an application deletes a temporary file after the handle is closed. In that scenario,
			/// the system can entirely avoid writing the data. Otherwise, the data is written after the handle is closed.
			/// </term>
			/// </item>
			/// <item>
			/// <term>FILE_ATTRIBUTE_VIRTUAL 65536 (0x10000)</term>
			/// <term>This value is reserved for system use.</term>
			/// </item>
			/// </list>
			/// </summary>
			public FileFlagsAndAttributes FileAttributes;

			/// <summary>
			/// <para>The length of the file name.</para>
			/// </summary>
			public uint FileNameLength;

			/// <summary>
			/// <para>The size of the extended attributes for the file.</para>
			/// </summary>
			public uint EaSize;

			/// <summary>
			/// <para>
			/// If the <c>FileAttributes</c> member includes the <c>FILE_ATTRIBUTE_REPARSE_POINT</c> attribute, this member specifies the
			/// reparse point tag.
			/// </para>
			/// <para>Otherwise, this value is undefined and should not be used.</para>
			/// <para>For more information see Reparse Point Tags.</para>
			/// <para>IO_REPARSE_TAG_CSV (0x80000009)</para>
			/// <para>IO_REPARSE_TAG_DEDUP (0x80000013)</para>
			/// <para>IO_REPARSE_TAG_DFS (0x8000000A)</para>
			/// <para>IO_REPARSE_TAG_DFSR (0x80000012)</para>
			/// <para>IO_REPARSE_TAG_HSM (0xC0000004)</para>
			/// <para>IO_REPARSE_TAG_HSM2 (0x80000006)</para>
			/// <para>IO_REPARSE_TAG_MOUNT_POINT (0xA0000003)</para>
			/// <para>IO_REPARSE_TAG_NFS (0x80000014)</para>
			/// <para>IO_REPARSE_TAG_SIS (0x80000007)</para>
			/// <para>IO_REPARSE_TAG_SYMLINK (0xA000000C)</para>
			/// <para>IO_REPARSE_TAG_WIM (0x80000008)</para>
			/// </summary>
			public uint ReparsePointTag;

			/// <summary>
			/// <para>The file ID.</para>
			/// </summary>
			public FILE_ID_128 FileId;

			/// <summary>
			/// <para>The first character of the file name string. This is followed in memory by the remainder of the string.</para>
			/// </summary>
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_PATH)]
			public string FileName;
		}

		/// <summary>
		/// <para>
		/// Contains identification information for a file. This structure is returned from the GetFileInformationByHandleEx function when
		/// <c>FileIdInfo</c> is passed in the FileInformationClass parameter.
		/// </para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winbase/ns-winbase-_file_id_info typedef struct _FILE_ID_INFO { ULONGLONG
		// VolumeSerialNumber; FILE_ID_128 FileId; } FILE_ID_INFO, *PFILE_ID_INFO;
		[PInvokeData("winbase.h", MSDNShortId = "e2774e29-1a90-44d6-9001-f73a98be6624")]
		[StructLayout(LayoutKind.Sequential)]
		public struct FILE_ID_INFO
		{
			/// <summary>
			/// <para>The serial number of the volume that contains a file.</para>
			/// </summary>
			public ulong VolumeSerialNumber;

			/// <summary>
			/// <para>
			/// The 128-bit file identifier for the file. The file identifier and the volume serial number uniquely identify a file on a
			/// single computer. To determine whether two open handles represent the same file, combine the identifier and the volume serial
			/// number for each file and compare them.
			/// </para>
			/// </summary>
			public FILE_ID_128 FileId;
		}

		/// <summary>
		/// <para>Specifies the priority hint for a file I/O operation.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// The SetFileInformationByHandle function can be used with this structure to associate a priority hint with I/O operations on a
		/// file-handle basis. In addition to the idle priority (very low), this function allows normal priority and low priority. Whether
		/// these priorities are supported and honored by the underlying drivers depends on their implementation (which is why they are
		/// called hints). For more information, see the I/O Prioritization in Windows Vista white paper on the Windows Hardware Developer
		/// Central (WHDC) website.
		/// </para>
		/// <para>This structure must be aligned on a <c>LONGLONG</c> (8-byte) boundary.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winbase/ns-winbase-_file_io_priority_hint_info typedef struct
		// _FILE_IO_PRIORITY_HINT_INFO { PRIORITY_HINT PriorityHint; } FILE_IO_PRIORITY_HINT_INFO, *PFILE_IO_PRIORITY_HINT_INFO;
		[PInvokeData("winbase.h", MSDNShortId = "a142b8fd-b71c-4449-a8c6-fb23715d1576")]
		[StructLayout(LayoutKind.Sequential)]
		public struct FILE_IO_PRIORITY_HINT_INFO
		{
			/// <summary>
			/// <para>The priority hint. This member is a value from the PRIORITY_HINT enumeration.</para>
			/// </summary>
			public PRIORITY_HINT PriorityHint;
		}

		/// <summary>
		/// <para>Receives the file name. Used for any handles. Use only when calling GetFileInformationByHandleEx.</para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winbase/ns-winbase-_file_name_info typedef struct _FILE_NAME_INFO { DWORD
		// FileNameLength; WCHAR FileName[1]; } FILE_NAME_INFO, *PFILE_NAME_INFO;
		[PInvokeData("winbase.h", MSDNShortId = "7ab98f41-b99e-4731-b803-921064a961c4")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		public struct FILE_NAME_INFO
		{
			/// <summary>
			/// <para>The size of the <c>FileName</c> string, in bytes.</para>
			/// </summary>
			public uint FileNameLength;

			/// <summary>
			/// <para>The file name that is returned.</para>
			/// </summary>
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_PATH + 1)]
			public string FileName;
		}

		/// <summary>
		/// <para>
		/// Contains file remote protocol information. This structure is returned from the GetFileInformationByHandleEx function when
		/// <c>FileRemoteProtocolInfo</c> is passed in the FileInformationClass parameter.
		/// </para>
		/// </summary>
		/// <remarks>
		/// <para>The <c>FILE_REMOTE_PROTOCOL_INFO</c> structure is valid only for use with the GetFileInformationByHandleEx function.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winbase/ns-winbase-_file_remote_protocol_info typedef struct
		// _FILE_REMOTE_PROTOCOL_INFO { USHORT StructureVersion; USHORT StructureSize; ULONG Protocol; USHORT ProtocolMajorVersion; USHORT
		// ProtocolMinorVersion; USHORT ProtocolRevision; USHORT Reserved; ULONG Flags; struct { ULONG Reserved[8]; } GenericReserved; struct
		// { ULONG Reserved[16]; } ProtocolSpecificReserved; union { struct { struct { ULONG Capabilities; } Server; struct { ULONG
		// Capabilities; ULONG CachingFlags; } Share; } Smb2; ULONG Reserved[16]; } ProtocolSpecific; } FILE_REMOTE_PROTOCOL_INFO, *PFILE_REMOTE_PROTOCOL_INFO;
		[PInvokeData("winbase.h", MSDNShortId = "ddb555ad-0acb-4538-88ce-a871adfc21fc")]
		[StructLayout(LayoutKind.Sequential)]
		public struct FILE_REMOTE_PROTOCOL_INFO
		{
			/// <summary>
			/// <para>
			/// Version of this structure. This member should be set to 2 if the communication is between computers running Windows 8,
			/// Windows Server 2012, or later and 1 otherwise.
			/// </para>
			/// </summary>
			public ushort StructureVersion;

			/// <summary>
			/// <para>Size of this structure. This member should be set to .</para>
			/// </summary>
			public ushort StructureSize;

			/// <summary>
			/// <para>Remote protocol ( <c>WNNC_NET_*</c>) defined in Wnnc.h or Ntifs.h.</para>
			/// <para>WNNC_NET_MSNET (0x00010000)</para>
			/// <para>WNNC_NET_SMB (0x00020000)</para>
			/// <para>WNNC_NET_LANMAN (0x00020000)</para>
			/// <para>WNNC_NET_NETWARE (0x00030000)</para>
			/// <para>WNNC_NET_VINES (0x00040000)</para>
			/// <para>WNNC_NET_10NET (0x00050000)</para>
			/// <para>WNNC_NET_LOCUS (0x00060000)</para>
			/// <para>WNNC_NET_SUN_PC_NFS (0x00070000)</para>
			/// <para>WNNC_NET_LANSTEP (0x00080000)</para>
			/// <para>WNNC_NET_9TILES (0x00090000)</para>
			/// <para>WNNC_NET_LANTASTIC (0x000A0000)</para>
			/// <para>WNNC_NET_AS400 (0x000B0000)</para>
			/// <para>WNNC_NET_FTP_NFS (0x000C0000)</para>
			/// <para>WNNC_NET_PATHWORKS (0x000D0000)</para>
			/// <para>WNNC_NET_LIFENET (0x000E0000)</para>
			/// <para>WNNC_NET_POWERLAN (0x000F0000)</para>
			/// <para>WNNC_NET_BWNFS (0x00100000)</para>
			/// <para>WNNC_NET_COGENT (0x00110000)</para>
			/// <para>WNNC_NET_FARALLON (0x00120000)</para>
			/// <para>WNNC_NET_APPLETALK (0x00130000)</para>
			/// <para>WNNC_NET_INTERGRAPH (0x00140000)</para>
			/// <para>WNNC_NET_SYMFONET (0x00150000)</para>
			/// <para>WNNC_NET_CLEARCASE (0x00160000)</para>
			/// <para>WNNC_NET_FRONTIER (0x00170000)</para>
			/// <para>WNNC_NET_BMC (0x00180000)</para>
			/// <para>WNNC_NET_DCE (0x00190000)</para>
			/// <para>WNNC_NET_AVID (0x001A0000)</para>
			/// <para>WNNC_NET_DOCUSPACE (0x001B0000)</para>
			/// <para>WNNC_NET_MANGOSOFT (0x001C0000)</para>
			/// <para>WNNC_NET_SERNET (0x001D0000)</para>
			/// <para>WNNC_NET_RIVERFRONT1 (0x001E0000)</para>
			/// <para>WNNC_NET_RIVERFRONT2 (0x001F0000)</para>
			/// <para>WNNC_NET_DECORB (0x00200000)</para>
			/// <para>WNNC_NET_PROTSTOR (0x00210000)</para>
			/// <para>WNNC_NET_FJ_REDIR (0x00220000)</para>
			/// <para>WNNC_NET_DISTINCT (0x00230000)</para>
			/// <para>WNNC_NET_TWINS (0x00240000)</para>
			/// <para>WNNC_NET_RDR2SAMPLE (0x00250000)</para>
			/// <para>WNNC_NET_CSC (0x00260000)</para>
			/// <para>WNNC_NET_3IN1 (0x00270000)</para>
			/// <para>WNNC_NET_EXTENDNET (0x00290000)</para>
			/// <para>WNNC_NET_STAC (0x002A0000)</para>
			/// <para>WNNC_NET_FOXBAT (0x002B0000)</para>
			/// <para>WNNC_NET_YAHOO (0x002C0000)</para>
			/// <para>WNNC_NET_EXIFS (0x002D0000)</para>
			/// <para>WNNC_NET_DAV (0x002E0000)</para>
			/// <para>WNNC_NET_KNOWARE (0x002F0000)</para>
			/// <para>WNNC_NET_OBJECT_DIRE (0x00300000)</para>
			/// <para>WNNC_NET_MASFAX (0x00310000)</para>
			/// <para>WNNC_NET_HOB_NFS (0x00320000)</para>
			/// <para>WNNC_NET_SHIVA (0x00330000)</para>
			/// <para>WNNC_NET_IBMAL (0x00340000)</para>
			/// <para>WNNC_NET_LOCK (0x00350000)</para>
			/// <para>WNNC_NET_TERMSRV (0x00360000)</para>
			/// <para>WNNC_NET_SRT (0x00370000)</para>
			/// <para>WNNC_NET_QUINCY (0x00380000)</para>
			/// <para>WNNC_NET_OPENAFS (0x00390000)</para>
			/// <para>WNNC_NET_AVID1 (0x003A0000)</para>
			/// <para>WNNC_NET_DFS (0x003B0000)</para>
			/// <para>WNNC_NET_KWNP (0x003C0000)</para>
			/// <para>WNNC_NET_ZENWORKS (0x003D0000)</para>
			/// <para>WNNC_NET_DRIVEONWEB (0x003E0000)</para>
			/// <para>WNNC_NET_VMWARE (0x003F0000)</para>
			/// <para>WNNC_NET_RSFX (0x00400000)</para>
			/// <para>WNNC_NET_MFILES (0x00410000)</para>
			/// <para>WNNC_NET_MS_NFS (0x00420000)</para>
			/// <para>WNNC_NET_GOOGLE (0x00430000)</para>
			/// <para>WNNC_NET_NDFS (0x00440000)</para>
			/// </summary>
			public uint Protocol;

			/// <summary>
			/// <para>Major version of the remote protocol.</para>
			/// </summary>
			public ushort ProtocolMajorVersion;

			/// <summary>
			/// <para>Minor version of the remote protocol.</para>
			/// </summary>
			public ushort ProtocolMinorVersion;

			/// <summary>
			/// <para>Revision of the remote protocol.</para>
			/// </summary>
			public ushort ProtocolRevision;

			/// <summary>
			/// <para>Should be set to zero. Do not use this member.</para>
			/// </summary>
			public ushort Reserved;

			/// <summary>
			/// <para>Remote protocol information. This member can be set to zero or more of the following flags.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>REMOTE_PROTOCOL_FLAG_LOOPBACK 0x1</term>
			/// <term>The remote protocol is using a loopback.</term>
			/// </item>
			/// <item>
			/// <term>REMOTE_PROTOCOL_FLAG_OFFLINE 0x2</term>
			/// <term>The remote protocol is using an offline cache.</term>
			/// </item>
			/// <item>
			/// <term>REMOTE_PROTOCOL_INFO_FLAG_PERSISTENT_HANDLE 0x4</term>
			/// <term>
			/// The remote protocol is using a persistent handle. Windows 7 and Windows Server 2008 R2: This flag is not supported before
			/// Windows 8 and Windows Server 2012.
			/// </term>
			/// </item>
			/// <item>
			/// <term>REMOTE_PROTOCOL_INFO_FLAG_PRIVACY 0x8</term>
			/// <term>
			/// The remote protocol is using privacy. This is only supported if the StructureVersion member is 2 or higher. Windows 7 and
			/// Windows Server 2008 R2: This flag is not supported before Windows 8 and Windows Server 2012.
			/// </term>
			/// </item>
			/// <item>
			/// <term>REMOTE_PROTOCOL_INFO_FLAG_INTEGRITY 0x10</term>
			/// <term>
			/// The remote protocol is using integrity so the data is signed. This is only supported if the StructureVersion member is 2 or
			/// higher. Windows 7 and Windows Server 2008 R2: This flag is not supported before Windows 8 and Windows Server 2012.
			/// </term>
			/// </item>
			/// <item>
			/// <term>REMOTE_PROTOCOL_INFO_FLAG_MUTUAL_AUTH 0x20</term>
			/// <term>
			/// The remote protocol is using mutual authentication using Kerberos. This is only supported if the StructureVersion member is 2
			/// or higher. Windows 7 and Windows Server 2008 R2: This flag is not supported before Windows 8 and Windows Server 2012.
			/// </term>
			/// </item>
			/// </list>
			/// </summary>
			public RemoteProtocol Flags;

			/// <summary>
			/// <para>Protocol-generic information structure.</para>
			/// </summary>
			public GenericReserved_ GenericReserved;

			/// <summary>
			/// <para>Protocol-specific information structure.</para>
			/// </summary>
			public ProtocolSpecificReserved_ ProtocolSpecificReserved;

			public ProtocolSpecific_ ProtocolSpecific;

			/// <summary>
			/// <para>Protocol-generic information structure.</para>
			/// </summary>
			[StructLayout(LayoutKind.Sequential)]
			public struct GenericReserved_
			{
				/// <summary>
				/// <para>Should be set to zero. Do not use this member.</para>
				/// </summary>
				[MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
				public uint[] Reserved;
			}

			/// <summary>
			/// <para>Protocol-specific information structure.</para>
			/// </summary>
			[StructLayout(LayoutKind.Sequential)]
			public struct ProtocolSpecificReserved_
			{
				/// <summary>
				/// <para>Should be set to zero. Do not use this member.</para>
				/// </summary>
				[MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
				public uint[] Reserved;
			}

			[StructLayout(LayoutKind.Explicit)]
			public struct ProtocolSpecific_
			{
				[FieldOffset(0)]
				public Smb2 Smb2;

				[FieldOffset(0)]
				public Guid Reserved;
			}

			[StructLayout(LayoutKind.Sequential)]
			public struct Smb2
			{
				public Server Server;
				public Share Share;
			}

			[StructLayout(LayoutKind.Sequential)]
			public struct Server
			{
				public uint Capabilities;
			}

			[StructLayout(LayoutKind.Sequential)]
			public struct Share
			{
				public uint Capabilities;
				public uint CachingFlags;
			}
		}

		/// <summary>
		/// <para>Contains the name to which the file should be renamed. Use only when calling SetFileInformationByHandle.</para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winbase/ns-winbase-_file_rename_info typedef struct _FILE_RENAME_INFO { union
		// { BOOLEAN ReplaceIfExists; DWORD Flags; } DUMMYUNIONNAME; BOOLEAN ReplaceIfExists; HANDLE RootDirectory; DWORD FileNameLength;
		// WCHAR FileName[1]; } FILE_RENAME_INFO, *PFILE_RENAME_INFO;
		[PInvokeData("winbase.h", MSDNShortId = "f4de0130-66fd-4847-bb6f-3f16fe17ca6e")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode, Pack = 4)]
		public struct FILE_RENAME_INFO
		{
			/// <summary>
			/// <para><c>TRUE</c> to replace the file; otherwise, <c>FALSE</c>.</para>
			/// </summary>
			[MarshalAs(UnmanagedType.U1)]
			public bool ReplaceIfExists;

			/// <summary>
			/// <para>A handle to the root directory in which the file to be renamed is located.</para>
			/// </summary>
			public HFILE RootDirectory;

			/// <summary>
			/// <para>The size of <c>FileName</c> in bytes.</para>
			/// </summary>
			public uint FileNameLength;

			/// <summary>
			/// <para>The new file name.</para>
			/// </summary>
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_PATH)]
			public string FileName;
		}

		/// <summary>
		/// <para>Receives extended information for the file. Used for file handles. Use only when calling GetFileInformationByHandleEx.</para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winbase/ns-winbase-_file_standard_info typedef struct _FILE_STANDARD_INFO {
		// LARGE_INTEGER AllocationSize; LARGE_INTEGER EndOfFile; DWORD NumberOfLinks; BOOLEAN DeletePending; BOOLEAN Directory; }
		// FILE_STANDARD_INFO, *PFILE_STANDARD_INFO;
		[PInvokeData("winbase.h", MSDNShortId = "da3187de-7de2-4307-a083-ae5fff6d8096")]
		[StructLayout(LayoutKind.Sequential)]
		public struct FILE_STANDARD_INFO
		{
			/// <summary>
			/// <para>The amount of space that is allocated for the file.</para>
			/// </summary>
			public long AllocationSize;

			/// <summary>
			/// <para>The end of the file.</para>
			/// </summary>
			public long EndOfFile;

			/// <summary>
			/// <para>The number of links to the file.</para>
			/// </summary>
			public uint NumberOfLinks;

			/// <summary>
			/// <para><c>TRUE</c> if the file in the delete queue; otherwise, <c>false</c>.</para>
			/// </summary>
			[MarshalAs(UnmanagedType.U1)] public bool DeletePending;

			/// <summary>
			/// <para><c>TRUE</c> if the file is a directory; otherwise, <c>false</c>.</para>
			/// </summary>
			[MarshalAs(UnmanagedType.U1)] public bool Directory;
		}

		/// <summary>
		/// <para>
		/// Contains directory information for a file. This structure is returned from the GetFileInformationByHandleEx function when
		/// <c>FileStorageInfo</c> is passed in the FileInformationClass parameter.
		/// </para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// If a volume is built on top of storage devices with different properties (for example a mirrored, spanned, striped, or RAID
		/// configuration) the sizes returned are those of the largest size of any of the underlying storage devices.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winbase/ns-winbase-_file_storage_info typedef struct _FILE_STORAGE_INFO {
		// ULONG LogicalBytesPerSector; ULONG PhysicalBytesPerSectorForAtomicity; ULONG PhysicalBytesPerSectorForPerformance; ULONG
		// FileSystemEffectivePhysicalBytesPerSectorForAtomicity; ULONG Flags; ULONG ByteOffsetForSectorAlignment; ULONG
		// ByteOffsetForPartitionAlignment; } FILE_STORAGE_INFO, *PFILE_STORAGE_INFO;
		[PInvokeData("winbase.h", MSDNShortId = "1aa9585d-9001-4d94-babe-a39c8dde2332")]
		[StructLayout(LayoutKind.Sequential)]
		public struct FILE_STORAGE_INFO
		{
			/// <summary>
			/// <para>Logical bytes per sector reported by physical storage. This is the smallest size for which uncached I/O is supported.</para>
			/// </summary>
			public uint LogicalBytesPerSector;

			/// <summary>
			/// <para>
			/// Bytes per sector for atomic writes. Writes smaller than this may require a read before the entire block can be written atomically.
			/// </para>
			/// </summary>
			public uint PhysicalBytesPerSectorForAtomicity;

			/// <summary>
			/// <para>Bytes per sector for optimal performance for writes.</para>
			/// </summary>
			public uint PhysicalBytesPerSectorForPerformance;

			/// <summary>
			/// <para>
			/// This is the size of the block used for atomicity by the file system. This may be a trade-off between the optimal size of the
			/// physical media and one that is easier to adapt existing code and structures.
			/// </para>
			/// </summary>
			public uint FileSystemEffectivePhysicalBytesPerSectorForAtomicity;

			/// <summary>
			/// <para>This member can contain combinations of flags specifying information about the alignment of the storage.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>STORAGE_INFO_FLAGS_ALIGNED_DEVICE 0x00000001</term>
			/// <term>When set, this flag indicates that the logical sectors of the storage device are aligned to physical sector boundaries.</term>
			/// </item>
			/// <item>
			/// <term>STORAGE_INFO_FLAGS_PARTITION_ALIGNED_ON_DEVICE 0x00000002</term>
			/// <term>When set, this flag indicates that the partition is aligned to physical sector boundaries on the storage device.</term>
			/// </item>
			/// </list>
			/// </summary>
			public StorageInfoFlags Flags;

			/// <summary>
			/// <para>
			/// Logical sector offset within the first physical sector where the first logical sector is placed, in bytes. If this value is
			/// set to <c>STORAGE_INFO_OFFSET_UNKNOWN</c> (0xffffffff), there was insufficient information to compute this field.
			/// </para>
			/// </summary>
			public uint ByteOffsetForSectorAlignment;

			/// <summary>
			/// <para>
			/// Offset used to align the partition to a physical sector boundary on the storage device, in bytes. If this value is set to
			/// <c>STORAGE_INFO_OFFSET_UNKNOWN</c> (0xffffffff), there was insufficient information to compute this field.
			/// </para>
			/// </summary>
			public uint ByteOffsetForPartitionAlignment;
		}

		/// <summary>
		/// <para>Receives file stream information for the specified file. Used for any handles. Use only when calling GetFileInformationByHandleEx.</para>
		/// </summary>
		/// <remarks>
		/// <para>The <c>FILE_STREAM_INFO</c> structure is used to enumerate the streams for a file.</para>
		/// <para>Support for named data streams is file-system-specific.</para>
		/// <para>
		/// The <c>FILE_STREAM_INFO</c> structure must be aligned on a <c>LONGLONG</c> (8-byte) boundary. If a buffer contains two or more of
		/// these structures, the <c>NextEntryOffset</c> value in each entry, except the last, falls on an 8-byte boundary.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winbase/ns-winbase-_file_stream_info typedef struct _FILE_STREAM_INFO { DWORD
		// NextEntryOffset; DWORD StreamNameLength; LARGE_INTEGER StreamSize; LARGE_INTEGER StreamAllocationSize; WCHAR StreamName[1]; }
		// FILE_STREAM_INFO, *PFILE_STREAM_INFO;
		[PInvokeData("winbase.h", MSDNShortId = "36d1b0b3-bd6b-41e7-937a-4e8deef6f9da")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode, Pack = 8)]
		public struct FILE_STREAM_INFO
		{
			/// <summary>
			/// <para>
			/// The offset for the next <c>FILE_STREAM_INFO</c> entry that is returned. This member is zero if no other entries follow this one.
			/// </para>
			/// </summary>
			public uint NextEntryOffset;

			/// <summary>
			/// <para>The length, in bytes, of <c>StreamName</c>.</para>
			/// </summary>
			public uint StreamNameLength;

			/// <summary>
			/// <para>The size, in bytes, of the data stream.</para>
			/// </summary>
			public long StreamSize;

			/// <summary>
			/// <para>
			/// The amount of space that is allocated for the stream, in bytes. This value is usually a multiple of the sector or cluster
			/// size of the underlying physical device.
			/// </para>
			/// </summary>
			public long StreamAllocationSize;

			/// <summary>
			/// <para>The stream name.</para>
			/// </summary>
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 1024)]
			public string StreamName;
		}

		/// <summary>Contains information about a file that the <c>OpenFile</c> function opened or attempted to open.</summary>
		// typedef struct _OFSTRUCT { BYTE cBytes; BYTE fFixedDisk; WORD nErrCode; WORD Reserved1; WORD Reserved2; CHAR
		// szPathName[OFS_MAXPATHNAME];} OFSTRUCT,
		// *POFSTRUCT; https://msdn.microsoft.com/en-us/library/windows/desktop/aa365282(v=vs.85).aspx
		[PInvokeData("WinBase.h", MSDNShortId = "aa365282")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
		public struct OFSTRUCT
		{
			/// <summary>The size of the structure, in bytes.</summary>
			public byte cBytes;

			/// <summary>If this member is nonzero, the file is on a hard (fixed) disk. Otherwise, it is not.</summary>
			public byte fFixedDisk;

			/// <summary>The MS-DOS error code if the <c>OpenFile</c> function failed.</summary>
			public ushort nErrCode;

			/// <summary>Reserved; do not use.</summary>
			public ushort Reserved1;

			/// <summary>Reserved; do not use.</summary>
			public ushort Reserved2;

			/// <summary>The path and file name of the file.</summary>
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
			public string szPathName;
		}

		/// <summary>Contains attribute information for a file or directory. The GetFileAttributesEx function uses this structure.</summary>
		[StructLayout(LayoutKind.Sequential)]
		[PInvokeData("WinBase.h", MSDNShortId = "aa365739")]
		public struct WIN32_FILE_ATTRIBUTE_DATA
		{
			/// <summary>The file system attribute information for a file or directory.</summary>
			public FileFlagsAndAttributes dwFileAttributes;

			/// <summary>A FILETIME structure that specifies when the file or directory is created.</summary>
			public FILETIME ftCreationTime;

			/// <summary>
			/// A FILETIME structure. For a file, the structure specifies when the file is last read from or written to. For a directory, the
			/// structure specifies when the directory is created. For both files and directories, the specified date is correct, but the
			/// time of day is always set to midnight. If the underlying file system does not support last access time, this member is zero.
			/// </summary>
			public FILETIME ftLastAccessTime;

			/// <summary>
			/// A FILETIME structure. For a file, the structure specifies when the file is last written to. For a directory, the structure
			/// specifies when the directory is created. If the underlying file system does not support last write time, this member is zero.
			/// </summary>
			public FILETIME ftLastWriteTime;

			/// <summary>The high-order DWORD of the file size. This member does not have a meaning for directories.</summary>
			public uint nFileSizeHigh;

			/// <summary>The low-order DWORD of the file size. This member does not have a meaning for directories.</summary>
			public uint nFileSizeLow;
		}

		/// <summary>
		/// <para>Contains information about the stream found by the <c>FindFirstStreamW</c> or <c>FindNextStreamW</c> function.</para>
		/// </summary>
		// typedef struct _WIN32_FIND_STREAM_DATA { LARGE_INTEGER StreamSize; WCHAR cStreamName[MAX_PATH + 36];} WIN32_FIND_STREAM_DATA, *PWIN32_FIND_STREAM_DATA;
		[PInvokeData("WinBase.h", MSDNShortId = "aa365741")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		public struct WIN32_FIND_STREAM_DATA
		{
			/// <summary>
			/// <para>A <c>LARGE_INTEGER</c> value that specifies the size of the stream, in bytes.</para>
			/// </summary>
			public long StreamSize;

			/// <summary>
			/// <para>The name of the stream. The string name format is ":streamname:$streamtype".</para>
			/// </summary>
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_PATH + 36)] private readonly string cStreamName;
		}

		/// <summary>Represents a search handle used in a subsequent call to the <c>FindNextVolumeMountPoint</c> and retrieved by <c>FindFirstVolumeMountPoint</c>.</summary>
		public class SafeVolumeMountPointHandle : SafeHANDLE
		{
			/// <summary>Initializes a new instance of the <see cref="SafeVolumeMountPointHandle"/> class.</summary>
			/// <param name="handle">The handle.</param>
			/// <param name="own">if set to <c>true</c> handle should be released at disposal.</param>
			public SafeVolumeMountPointHandle(IntPtr handle, bool own = true) : base(IntPtr.Zero, true) { }

			private SafeVolumeMountPointHandle() : base()
			{
			}

			protected override bool InternalReleaseHandle() => FindVolumeMountPointClose(handle);
		}
	}
}