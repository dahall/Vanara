using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace Vanara.PInvoke
{
	public static partial class Kernel32
	{
		/// <summary>
		/// <para>
		/// [Microsoft strongly recommends developers utilize alternative means to achieve your application’s needs. Many scenarios that TxF
		/// was developed for can be achieved through simpler and more readily available techniques. Furthermore, TxF may not be available in
		/// future versions of Microsoft Windows. For more information, and alternatives to TxF, please see
		/// </para>
		/// <para>Alternatives to using Transactional NTFS</para>
		/// <para>.]</para>
		/// <para>
		/// Establishes a hard link between an existing file and a new file as a transacted operation. This function is only supported on the
		/// NTFS file system, and only for files, not directories.
		/// </para>
		/// </summary>
		/// <param name="lpFileName">
		/// <para>The name of the new file.</para>
		/// <para>This parameter cannot specify the name of a directory.</para>
		/// </param>
		/// <param name="lpExistingFileName">
		/// <para>The name of the existing file.</para>
		/// <para>This parameter cannot specify the name of a directory.</para>
		/// </param>
		/// <param name="lpSecurityAttributes">
		/// <para>Reserved; must be <c>NULL</c>.</para>
		/// </param>
		/// <param name="hTransaction">
		/// <para>A handle to the transaction. This handle is returned by the CreateTransaction function.</para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is nonzero.</para>
		/// <para>If the function fails, the return value is zero (0). To get extended error information, call GetLastError.</para>
		/// <para>
		/// The maximum number of hard links that can be created with this function is 1023 per file. If more than 1023 links are created for
		/// a file, an error results.
		/// </para>
		/// <para>The files must reside on the local computer; otherwise, the function fails and the last error code is set to <c>ERROR_TRANSACTIONS_UNSUPPORTED_REMOTE</c>.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// Any directory entry for a file that is created with CreateFileTransacted or <c>CreateHardLinkTransacted</c> is a hard link to an
		/// associated file. An additional hard link that is created with the <c>CreateHardLinkTransacted</c> function allows you to have
		/// multiple directory entries for a file, that is, multiple hard links to the same file, which can be different names in the same
		/// directory, or the same or different names in different directories. However, all hard links to a file must be on the same volume.
		/// </para>
		/// <para>
		/// Because hard links are only directory entries for a file, when an application modifies a file through any hard link, all
		/// applications that use any other hard link to the file see the changes. Also, all of the directory entries are updated if the file
		/// changes. For example, if a file size changes, all of the hard links to the file show the new file size.
		/// </para>
		/// <para>
		/// The security descriptor belongs to the file to which a hard link points. The link itself is only a directory entry, and does not
		/// have a security descriptor. Therefore, when you change the security descriptor of a hard link, you a change the security
		/// descriptor of the underlying file, and all hard links that point to the file allow the newly specified access. You cannot give a
		/// file different security descriptors on a per-hard-link basis.
		/// </para>
		/// <para>
		/// This function does not modify the security descriptor of the file to be linked to, even if security descriptor information is
		/// passed in the parameter.
		/// </para>
		/// <para>
		/// Use DeleteFileTransacted to delete hard links. You can delete them in any order regardless of the order in which they are created.
		/// </para>
		/// <para>
		/// Flags, attributes, access, and sharing that are specified in CreateFileTransacted operate on a per-file basis. That is, if you
		/// open a file that does not allow sharing, another application cannot share the file by creating a new hard link to the file.
		/// </para>
		/// <para>
		/// When you create a hard link on the NTFS file system, the file attribute information in the directory entry is refreshed only when
		/// the file is opened, or when GetFileInformationByHandle is called with the handle of a specific file.
		/// </para>
		/// <para><c>Symbolic links:</c> If the path points to a symbolic link, the function creates a hard link to the target.</para>
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
		/// <term>No</term>
		/// </item>
		/// </list>
		/// <para>Note that SMB 3.0 does not support TxF.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winbase/nf-winbase-createhardlinktransacteda BOOL CreateHardLinkTransactedA(
		// LPCSTR lpFileName, LPCSTR lpExistingFileName, LPSECURITY_ATTRIBUTES lpSecurityAttributes, HANDLE hTransaction );
		[DllImport(Lib.Kernel32, SetLastError = true, CharSet = CharSet.Auto)]
		[PInvokeData("winbase.h", MSDNShortId = "27dd5b0a-08ef-4757-8f51-03d9918028c8")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool CreateHardLinkTransacted(string lpFileName, string lpExistingFileName, SECURITY_ATTRIBUTES lpSecurityAttributes, IntPtr hTransaction);

		/// <summary>
		/// <para>
		/// [Microsoft strongly recommends developers utilize alternative means to achieve your application’s needs. Many scenarios that TxF
		/// was developed for can be achieved through simpler and more readily available techniques. Furthermore, TxF may not be available in
		/// future versions of Microsoft Windows. For more information, and alternatives to TxF, please see
		/// </para>
		/// <para>Alternatives to using Transactional NTFS</para>
		/// <para>.]</para>
		/// <para>
		/// Copies an existing file to a new file as a transacted operation, notifying the application of its progress through a callback function.
		/// </para>
		/// </summary>
		/// <param name="lpExistingFileName">
		/// <para>The name of an existing file.</para>
		/// <para>
		/// In the ANSI version of this function, the name is limited to <c>MAX_PATH</c> characters. To extend this limit to 32,767 wide
		/// characters, call the Unicode version of the function and prepend "\?" to the path. For more information, see Naming a File.
		/// </para>
		/// <para>If does not exist, the <c>CopyFileTransacted</c> function fails, and the GetLastError function returns <c>ERROR_FILE_NOT_FOUND</c>.</para>
		/// <para>The file must reside on the local computer; otherwise, the function fails and the last error code is set to <c>ERROR_TRANSACTIONS_UNSUPPORTED_REMOTE</c>.</para>
		/// </param>
		/// <param name="lpNewFileName">
		/// <para>The name of the new file.</para>
		/// <para>
		/// In the ANSI version of this function, the name is limited to <c>MAX_PATH</c> characters. To extend this limit to 32,767 wide
		/// characters, call the Unicode version of the function and prepend "\?" to the path. For more information, see Naming a File.
		/// </para>
		/// </param>
		/// <param name="lpProgressRoutine">
		/// <para>
		/// The address of a callback function of type <c>LPPROGRESS_ROUTINE</c> that is called each time another portion of the file has
		/// been copied. This parameter can be <c>NULL</c>. For more information on the progress callback function, see the
		/// CopyProgressRoutine function.
		/// </para>
		/// </param>
		/// <param name="lpData">
		/// <para>The argument to be passed to the callback function. This parameter can be <c>NULL</c>.</para>
		/// </param>
		/// <param name="pbCancel">
		/// <para>
		/// If this flag is set to <c>TRUE</c> during the copy operation, the operation is canceled. Otherwise, the copy operation will
		/// continue to completion.
		/// </para>
		/// </param>
		/// <param name="dwCopyFlags">
		/// <para>Flags that specify how the file is to be copied. This parameter can be a combination of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>COPY_FILE_COPY_SYMLINK 0x00000800</term>
		/// <term>
		/// If the source file is a symbolic link, the destination file is also a symbolic link pointing to the same file that the source
		/// symbolic link is pointing to.
		/// </term>
		/// </item>
		/// <item>
		/// <term>COPY_FILE_FAIL_IF_EXISTS 0x00000001</term>
		/// <term>The copy operation fails immediately if the target file already exists.</term>
		/// </item>
		/// <item>
		/// <term>COPY_FILE_OPEN_SOURCE_FOR_WRITE 0x00000004</term>
		/// <term>The file is copied and the original file is opened for write access.</term>
		/// </item>
		/// <item>
		/// <term>COPY_FILE_RESTARTABLE 0x00000002</term>
		/// <term>
		/// Progress of the copy is tracked in the target file in case the copy fails. The failed copy can be restarted at a later time by
		/// specifying the same values for and as those used in the call that failed. This can significantly slow down the copy operation as
		/// the new file may be flushed multiple times during the copy operation.
		/// </term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="hTransaction">
		/// <para>A handle to the transaction. This handle is returned by the CreateTransaction function.</para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is nonzero.</para>
		/// <para>If the function fails, the return value is zero. To get extended error information call GetLastError.</para>
		/// <para>
		/// If returns <c>PROGRESS_CANCEL</c> due to the user canceling the operation, <c>CopyFileTransacted</c> will return zero and
		/// GetLastError will return <c>ERROR_REQUEST_ABORTED</c>. In this case, the partially copied destination file is deleted.
		/// </para>
		/// <para>
		/// If returns <c>PROGRESS_STOP</c> due to the user stopping the operation, <c>CopyFileTransacted</c> will return zero and
		/// GetLastError will return <c>ERROR_REQUEST_ABORTED</c>. In this case, the partially copied destination file is left intact.
		/// </para>
		/// <para>
		/// If you attempt to call this function with a handle to a transaction that has already been rolled back, <c>CopyFileTransacted</c>
		/// will return either <c>ERROR_TRANSACTION_NOT_ACTIVE</c> or <c>ERROR_INVALID_TRANSACTION</c>.
		/// </para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// This function preserves extended attributes, OLE structured storage, NTFS file system alternate data streams, security
		/// attributes, and file attributes.
		/// </para>
		/// <para>
		/// <c>Windows 7, Windows Server 2008 R2, Windows Server 2008 and Windows Vista:</c> Security resource attributes (
		/// <c>ATTRIBUTE_SECURITY_INFORMATION</c>) for the existing file are not copied to the new file until Windows 8 and Windows Server 2012.
		/// </para>
		/// <para>
		/// This function fails with <c>ERROR_ACCESS_DENIED</c> if the destination file already exists and has the
		/// <c>FILE_ATTRIBUTE_HIDDEN</c> or <c>FILE_ATTRIBUTE_READONLY</c> attribute set.
		/// </para>
		/// <para>Encrypted files are not supported by TxF.</para>
		/// <para>If <c>COPY_FILE_COPY_SYMLINK</c> is specified, the following rules apply:</para>
		/// <list type="bullet">
		/// <item>If the source file is a symbolic link, the symbolic link is copied, not the target file.</item>
		/// <item>If the source file is not a symbolic link, there is no change in behavior.</item>
		/// <item>If the destination file is an existing symbolic link, the symbolic link is overwritten, not the target file.</item>
		/// <item>
		/// If <c>COPY_FILE_FAIL_IF_EXISTS</c> is also specified, and the destination file is an existing symbolic link, the operation fails
		/// in all cases.
		/// </item>
		/// </list>
		/// <para>If</para>
		/// <para>COPY_FILE_COPY_SYMLINK</para>
		/// <para>is not specified, the following rules apply:</para>
		/// <list type="bullet">
		/// <item>
		/// If <c>COPY_FILE_FAIL_IF_EXISTS</c> is also specified, and the destination file is an existing symbolic link, the operation fails
		/// only if the target of the symbolic link exists.
		/// </item>
		/// <item>If <c>COPY_FILE_FAIL_IF_EXISTS</c> is not specified, there is no change in behavior.</item>
		/// </list>
		/// <para>Link tracking is not supported by TxF.</para>
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
		/// <term>No</term>
		/// </item>
		/// </list>
		/// <para>Note that SMB 3.0 does not support TxF.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winbase/nf-winbase-copyfiletransacteda BOOL CopyFileTransactedA( LPCSTR
		// lpExistingFileName, LPCSTR lpNewFileName, LPPROGRESS_ROUTINE lpProgressRoutine, LPVOID lpData, LPBOOL pbCancel, DWORD dwCopyFlags,
		// HANDLE hTransaction );
		[DllImport(Lib.Kernel32, SetLastError = true, CharSet = CharSet.Auto)]
		[PInvokeData("winbase.h", MSDNShortId = "118392de-166b-413e-99c9-b3deb756de0e")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool CopyFileTransacted(string lpExistingFileName, string lpNewFileName, CopyProgressRoutine lpProgressRoutine, IntPtr lpData, [MarshalAs(UnmanagedType.Bool)] ref bool pbCancel, COPY_FILE dwCopyFlags, IntPtr hTransaction);

		/// <summary>
		/// <para>
		/// [Microsoft strongly recommends developers utilize alternative means to achieve your application’s needs. Many scenarios that TxF
		/// was developed for can be achieved through simpler and more readily available techniques. Furthermore, TxF may not be available in
		/// future versions of Microsoft Windows. For more information, and alternatives to TxF, please see
		/// </para>
		/// <para>Alternatives to using Transactional NTFS</para>
		/// <para>.]</para>
		/// <para>
		/// Creates a new directory as a transacted operation, with the attributes of a specified template directory. If the underlying file
		/// system supports security on files and directories, the function applies a specified security descriptor to the new directory. The
		/// new directory retains the other attributes of the specified template directory.
		/// </para>
		/// </summary>
		/// <param name="lpTemplateDirectory">
		/// <para>The path of the directory to use as a template when creating the new directory. This parameter can be <c>NULL</c>.</para>
		/// <para>
		/// In the ANSI version of this function, the name is limited to <c>MAX_PATH</c> characters. To extend this limit to 32,767 wide
		/// characters, call the Unicode version of the function and prepend "\?" to the path. For more information, see Naming a File.
		/// </para>
		/// <para>The directory must reside on the local computer; otherwise, the function fails and the last error code is set to <c>ERROR_TRANSACTIONS_UNSUPPORTED_REMOTE</c>.</para>
		/// </param>
		/// <param name="lpNewDirectory">
		/// <para>The path of the directory to be created.</para>
		/// <para>
		/// In the ANSI version of this function, the name is limited to <c>MAX_PATH</c> characters. To extend this limit to 32,767 wide
		/// characters, call the Unicode version of the function and prepend "\?" to the path. For more information, see Naming a File.
		/// </para>
		/// </param>
		/// <param name="lpSecurityAttributes">
		/// <para>
		/// A pointer to a SECURITY_ATTRIBUTES structure. The <c>lpSecurityDescriptor</c> member of the structure specifies a security
		/// descriptor for the new directory.
		/// </para>
		/// <para>
		/// If is <c>NULL</c>, the directory gets a default security descriptor. The access control lists (ACL) in the default security
		/// descriptor for a directory are inherited from its parent directory.
		/// </para>
		/// <para>
		/// The target file system must support security on files and directories for this parameter to have an effect. This is indicated
		/// when GetVolumeInformation returns <c>FS_PERSISTENT_ACLS</c>.
		/// </para>
		/// </param>
		/// <param name="hTransaction">
		/// <para>A handle to the transaction. This handle is returned by the CreateTransaction function.</para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is nonzero.</para>
		/// <para>
		/// If the function fails, the return value is zero (0). To get extended error information, call GetLastError. Possible errors
		/// include the following.
		/// </para>
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
		/// <term>ERROR_EFS_NOT_ALLOWED_IN_TRANSACTION</term>
		/// <term>You cannot create a child directory with a parent directory that has encryption disabled.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_PATH_NOT_FOUND</term>
		/// <term>One or more intermediate directories do not exist. This function only creates the final directory in the path.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The <c>CreateDirectoryTransacted</c> function allows you to create directories that inherit stream information from other
		/// directories. This function is useful, for example, when you are using Macintosh directories, which have a resource stream that is
		/// needed to properly identify directory contents as an attribute.
		/// </para>
		/// <para>
		/// Some file systems, such as the NTFS file system, support compression or encryption for individual files and directories. On
		/// volumes formatted for such a file system, a new directory inherits the compression and encryption attributes of its parent directory.
		/// </para>
		/// <para>
		/// This function fails with <c>ERROR_EFS_NOT_ALLOWED_IN_TRANSACTION</c> if you try to create a child directory with a parent
		/// directory that has encryption disabled.
		/// </para>
		/// <para>
		/// You can obtain a handle to a directory by calling the CreateFileTransacted function with the <c>FILE_FLAG_BACKUP_SEMANTICS</c>
		/// flag set.
		/// </para>
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
		/// <term>No</term>
		/// </item>
		/// </list>
		/// <para>SMB 3.0 does not support TxF.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winbase/nf-winbase-createdirectorytransacteda BOOL
		// CreateDirectoryTransactedA( LPCSTR lpTemplateDirectory, LPCSTR lpNewDirectory, LPSECURITY_ATTRIBUTES lpSecurityAttributes, HANDLE
		// hTransaction );
		[DllImport(Lib.Kernel32, SetLastError = true, CharSet = CharSet.Auto)]
		[PInvokeData("winbase.h", MSDNShortId = "75663b30-5bd9-4de7-8e4f-dc58016c2c40")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool CreateDirectoryTransacted(string lpTemplateDirectory, string lpNewDirectory, SECURITY_ATTRIBUTES lpSecurityAttributes, IntPtr hTransaction);

		/// <summary>
		/// <para>
		/// [Microsoft strongly recommends developers utilize alternative means to achieve your application’s needs. Many scenarios that TxF
		/// was developed for can be achieved through simpler and more readily available techniques. Furthermore, TxF may not be available in
		/// future versions of Microsoft Windows. For more information, and alternatives to TxF, please see
		/// </para>
		/// <para>Alternatives to using Transactional NTFS</para>
		/// <para>.]</para>
		/// <para>
		/// Creates or opens a file, file stream, or directory as a transacted operation. The function returns a handle that can be used to
		/// access the object.
		/// </para>
		/// <para>
		/// To perform this operation as a non-transacted operation or to access objects other than files (for example, named pipes, physical
		/// devices, mailslots), use the CreateFile function.
		/// </para>
		/// <para>For more information about transactions, see the Remarks section of this topic.</para>
		/// </summary>
		/// <param name="lpFileName">
		/// <para>The name of an object to be created or opened.</para>
		/// <para>The object must reside on the local computer; otherwise, the function fails and the last error code is set to <c>ERROR_TRANSACTIONS_UNSUPPORTED_REMOTE</c>.</para>
		/// <para>
		/// In the ANSI version of this function, the name is limited to <c>MAX_PATH</c> characters. To extend this limit to 32,767 wide
		/// characters, call the Unicode version of the function and prepend "\?" to the path. For more information, see Naming a File. For
		/// information on special device names, see Defining an MS-DOS Device Name.
		/// </para>
		/// <para>
		/// To create a file stream, specify the name of the file, a colon, and then the name of the stream. For more information, see File Streams.
		/// </para>
		/// </param>
		/// <param name="dwDesiredAccess">
		/// <para>
		/// The access to the object, which can be summarized as read, write, both or neither (zero). The most commonly used values are
		/// <c>GENERIC_READ</c>, <c>GENERIC_WRITE</c>, or both ( <c>GENERIC_READ</c> | <c>GENERIC_WRITE</c>). For more information, see
		/// Generic Access Rights and File Security and Access Rights.
		/// </para>
		/// <para>
		/// If this parameter is zero, the application can query file, directory, or device attributes without accessing that file or device.
		/// For more information, see the Remarks section of this topic.
		/// </para>
		/// <para>
		/// You cannot request an access mode that conflicts with the sharing mode that is specified in an open request that has an open
		/// handle. For more information, see Creating and Opening Files.
		/// </para>
		/// </param>
		/// <param name="dwShareMode">
		/// <para>The sharing mode of an object, which can be read, write, both, delete, all of these, or none (refer to the following table).</para>
		/// <para>
		/// If this parameter is zero and <c>CreateFileTransacted</c> succeeds, the object cannot be shared and cannot be opened again until
		/// the handle is closed. For more information, see the Remarks section of this topic.
		/// </para>
		/// <para>
		/// You cannot request a sharing mode that conflicts with the access mode that is specified in an open request that has an open
		/// handle, because that would result in the following sharing violation: <c>ERROR_SHARING_VIOLATION</c>. For more information, see
		/// Creating and Opening Files.
		/// </para>
		/// <para>
		/// To enable a process to share an object while another process has the object open, use a combination of one or more of the
		/// following values to specify the access mode they can request to open the object.
		/// </para>
		/// <para>
		/// <c>Note</c> The sharing options for each open handle remain in effect until that handle is closed, regardless of process context.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>0 0x00000000</term>
		/// <term>Disables subsequent open operations on an object to request any type of access to that object.</term>
		/// </item>
		/// <item>
		/// <term>FILE_SHARE_DELETE 0x00000004</term>
		/// <term>
		/// Enables subsequent open operations on an object to request delete access. Otherwise, other processes cannot open the object if
		/// they request delete access. If this flag is not specified, but the object has been opened for delete access, the function fails.
		/// </term>
		/// </item>
		/// <item>
		/// <term>FILE_SHARE_READ 0x00000001</term>
		/// <term>
		/// Enables subsequent open operations on an object to request read access. Otherwise, other processes cannot open the object if they
		/// request read access. If this flag is not specified, but the object has been opened for read access, the function fails.
		/// </term>
		/// </item>
		/// <item>
		/// <term>FILE_SHARE_WRITE 0x00000002</term>
		/// <term>
		/// Enables subsequent open operations on an object to request write access. Otherwise, other processes cannot open the object if
		/// they request write access. If this flag is not specified, but the object has been opened for write access or has a file mapping
		/// with write access, the function fails.
		/// </term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="lpSecurityAttributes">
		/// <para>
		/// A pointer to a SECURITY_ATTRIBUTES structure that contains an optional security descriptor and also determines whether or not the
		/// returned handle can be inherited by child processes. The parameter can be <c>NULL</c>.
		/// </para>
		/// <para>
		/// If the parameter is <c>NULL</c>, the handle returned by <c>CreateFileTransacted</c> cannot be inherited by any child processes
		/// your application may create and the object associated with the returned handle gets a default security descriptor.
		/// </para>
		/// <para>The <c>bInheritHandle</c> member of the structure specifies whether the returned handle can be inherited.</para>
		/// <para>
		/// The <c>lpSecurityDescriptor</c> member of the structure specifies a security descriptor for an object, but may also be <c>NULL</c>.
		/// </para>
		/// <para>
		/// If <c>lpSecurityDescriptor</c> member is <c>NULL</c>, the object associated with the returned handle is assigned a default
		/// security descriptor.
		/// </para>
		/// <para>
		/// <c>CreateFileTransacted</c> ignores the <c>lpSecurityDescriptor</c> member when opening an existing file, but continues to use
		/// the <c>bInheritHandle</c> member.
		/// </para>
		/// <para>For more information, see the Remarks section of this topic.</para>
		/// </param>
		/// <param name="dwCreationDisposition">
		/// <para>An action to take on files that exist and do not exist.</para>
		/// <para>For more information, see the Remarks section of this topic.</para>
		/// <para>This parameter must be one of the following values, which cannot be combined.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>CREATE_ALWAYS 2</term>
		/// <term>
		/// Creates a new file, always. If the specified file exists and is writable, the function overwrites the file, the function
		/// succeeds, and last-error code is set to ERROR_ALREADY_EXISTS (183). If the specified file does not exist and is a valid path, a
		/// new file is created, the function succeeds, and the last-error code is set to zero. For more information, see the Remarks section
		/// of this topic.
		/// </term>
		/// </item>
		/// <item>
		/// <term>CREATE_NEW 1</term>
		/// <term>
		/// Creates a new file, only if it does not already exist. If the specified file exists, the function fails and the last-error code
		/// is set to ERROR_FILE_EXISTS (80). If the specified file does not exist and is a valid path to a writable location, a new file is created.
		/// </term>
		/// </item>
		/// <item>
		/// <term>OPEN_ALWAYS 4</term>
		/// <term>
		/// Opens a file, always. If the specified file exists, the function succeeds and the last-error code is set to ERROR_ALREADY_EXISTS
		/// (183). If the specified file does not exist and is a valid path to a writable location, the function creates a file and the
		/// last-error code is set to zero.
		/// </term>
		/// </item>
		/// <item>
		/// <term>OPEN_EXISTING 3</term>
		/// <term>
		/// Opens a file or device, only if it exists. If the specified file does not exist, the function fails and the last-error code is
		/// set to ERROR_FILE_NOT_FOUND (2). For more information, see the Remarks section of this topic.
		/// </term>
		/// </item>
		/// <item>
		/// <term>TRUNCATE_EXISTING 5</term>
		/// <term>
		/// Opens a file and truncates it so that its size is zero bytes, only if it exists. If the specified file does not exist, the
		/// function fails and the last-error code is set to ERROR_FILE_NOT_FOUND (2). The calling process must open the file with the
		/// GENERIC_WRITE bit set as part of the parameter.
		/// </term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="dwFlagsAndAttributes">
		/// <para>The file attributes and flags, <c>FILE_ATTRIBUTE_NORMAL</c> being the most common default value.</para>
		/// <para>
		/// This parameter can include any combination of the available file attributes ( <c>FILE_ATTRIBUTE_*</c>). All other file attributes
		/// override <c>FILE_ATTRIBUTE_NORMAL</c>.
		/// </para>
		/// <para>
		/// This parameter can also contain combinations of flags ( <c>FILE_FLAG_</c>) for control of buffering behavior, access modes, and
		/// other special-purpose flags. These combine with any <c>FILE_ATTRIBUTE_</c> values.
		/// </para>
		/// <para>
		/// This parameter can also contain Security Quality of Service (SQOS) information by specifying the <c>SECURITY_SQOS_PRESENT</c>
		/// flag. Additional SQOS-related flags information is presented in the table following the attributes and flags tables.
		/// </para>
		/// <para>
		/// <c>Note</c> When <c>CreateFileTransacted</c> opens an existing file, it generally combines the file flags with the file
		/// attributes of the existing file, and ignores any file attributes supplied as part of . Special cases are detailed in Creating and
		/// Opening Files.
		/// </para>
		/// <para>The following file attributes and flags are used only for file objects, not other types of objects that</para>
		/// <para>CreateFileTransacted</para>
		/// <para>
		/// opens (additional information can be found in the Remarks section of this topic). For more advanced access to file attributes, see
		/// </para>
		/// <para>SetFileAttributes</para>
		/// <para>. For a complete list of all file attributes with their values and descriptions, see</para>
		/// <para>File Attribute Constants</para>
		/// <para>.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Attribute</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>FILE_ATTRIBUTE_ARCHIVE 32 (0x20)</term>
		/// <term>The file should be archived. Applications use this attribute to mark files for backup or removal.</term>
		/// </item>
		/// <item>
		/// <term>FILE_ATTRIBUTE_ENCRYPTED 16384 (0x4000)</term>
		/// <term>
		/// The file or directory is encrypted. For a file, this means that all data in the file is encrypted. For a directory, this means
		/// that encryption is the default for newly created files and subdirectories. For more information, see File Encryption. This flag
		/// has no effect if FILE_ATTRIBUTE_SYSTEM is also specified.
		/// </term>
		/// </item>
		/// <item>
		/// <term>FILE_ATTRIBUTE_HIDDEN 2 (0x2)</term>
		/// <term>The file is hidden. Do not include it in an ordinary directory listing.</term>
		/// </item>
		/// <item>
		/// <term>FILE_ATTRIBUTE_NORMAL 128 (0x80)</term>
		/// <term>The file does not have other attributes set. This attribute is valid only if used alone.</term>
		/// </item>
		/// <item>
		/// <term>FILE_ATTRIBUTE_OFFLINE 4096 (0x1000)</term>
		/// <term>
		/// The data of a file is not immediately available. This attribute indicates that file data is physically moved to offline storage.
		/// This attribute is used by Remote Storage, the hierarchical storage management software. Applications should not arbitrarily
		/// change this attribute.
		/// </term>
		/// </item>
		/// <item>
		/// <term>FILE_ATTRIBUTE_READONLY 1 (0x1)</term>
		/// <term>The file is read only. Applications can read the file, but cannot write to or delete it.</term>
		/// </item>
		/// <item>
		/// <term>FILE_ATTRIBUTE_SYSTEM 4 (0x4)</term>
		/// <term>The file is part of or used exclusively by an operating system.</term>
		/// </item>
		/// <item>
		/// <term>FILE_ATTRIBUTE_TEMPORARY 256 (0x100)</term>
		/// <term>
		/// The file is being used for temporary storage. File systems avoid writing data back to mass storage if sufficient cache memory is
		/// available, because an application deletes a temporary file after a handle is closed. In that case, the system can entirely avoid
		/// writing the data. Otherwise, the data is written after the handle is closed.
		/// </term>
		/// </item>
		/// </list>
		/// <list type="table">
		/// <listheader>
		/// <term>Flag</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>FILE_FLAG_BACKUP_SEMANTICS 0x02000000</term>
		/// <term>
		/// The file is being opened or created for a backup or restore operation. The system ensures that the calling process overrides file
		/// security checks when the process has SE_BACKUP_NAME and SE_RESTORE_NAME privileges. For more information, see Changing Privileges
		/// in a Token. You must set this flag to obtain a handle to a directory. A directory handle can be passed to some functions instead
		/// of a file handle. For more information, see Directory Handles.
		/// </term>
		/// </item>
		/// <item>
		/// <term>FILE_FLAG_DELETE_ON_CLOSE 0x04000000</term>
		/// <term>
		/// The file is to be deleted immediately after the last transacted writer handle to the file is closed, provided that the
		/// transaction is still active. If a file has been marked for deletion and a transacted writer handle is still open after the
		/// transaction completes, the file will not be deleted. If there are existing open handles to a file, the call fails unless they
		/// were all opened with the FILE_SHARE_DELETE share mode. Subsequent open requests for the file fail, unless the FILE_SHARE_DELETE
		/// share mode is specified.
		/// </term>
		/// </item>
		/// <item>
		/// <term>FILE_FLAG_NO_BUFFERING 0x20000000</term>
		/// <term>
		/// The file is being opened with no system caching. This flag does not affect hard disk caching or memory mapped files. When
		/// combined with FILE_FLAG_OVERLAPPED, the flag gives maximum asynchronous performance, because the I/O does not rely on the
		/// synchronous operations of the memory manager. However, some I/O operations take more time, because data is not being held in the
		/// cache. Also, the file metadata may still be cached. To flush the metadata to disk, use the FlushFileBuffers function. An
		/// application must meet certain requirements when working with files that are opened with FILE_FLAG_NO_BUFFERING: One way to align
		/// buffers on integer multiples of the volume sector size is to use VirtualAlloc to allocate the buffers. It allocates memory that
		/// is aligned on addresses that are integer multiples of the operating system's memory page size. Because both memory page and
		/// volume sector sizes are powers of 2, this memory is also aligned on addresses that are integer multiples of a volume sector size.
		/// Memory pages are 4 or 8 KB in size; sectors are 512 bytes (hard disks), 2048 bytes (CD), or 4096 bytes (hard disks), and
		/// therefore, volume sectors can never be larger than memory pages. An application can determine a volume sector size by calling the
		/// GetDiskFreeSpace function.
		/// </term>
		/// </item>
		/// <item>
		/// <term>FILE_FLAG_OPEN_NO_RECALL 0x00100000</term>
		/// <term>
		/// The file data is requested, but it should continue to be located in remote storage. It should not be transported back to local
		/// storage. This flag is for use by remote storage systems.
		/// </term>
		/// </item>
		/// <item>
		/// <term>FILE_FLAG_OPEN_REPARSE_POINT 0x00200000</term>
		/// <term>
		/// Normal reparse point processing will not occur; CreateFileTransacted will attempt to open the reparse point. When a file is
		/// opened, a file handle is returned, whether or not the filter that controls the reparse point is operational. This flag cannot be
		/// used with the CREATE_ALWAYS flag. If the file is not a reparse point, then this flag is ignored.
		/// </term>
		/// </item>
		/// <item>
		/// <term>FILE_FLAG_OVERLAPPED 0x40000000</term>
		/// <term>
		/// The file is being opened or created for asynchronous I/O. When the operation is complete, the event specified in the OVERLAPPED
		/// structure is set to the signaled state. Operations that take a significant amount of time to process return ERROR_IO_PENDING. If
		/// this flag is specified, the file can be used for simultaneous read and write operations. The system does not maintain the file
		/// pointer, therefore you must pass the file position to the read and write functions in the OVERLAPPED structure or update the file
		/// pointer. If this flag is not specified, then I/O operations are serialized, even if the calls to the read and write functions
		/// specify an OVERLAPPED structure.
		/// </term>
		/// </item>
		/// <item>
		/// <term>FILE_FLAG_POSIX_SEMANTICS 0x0100000</term>
		/// <term>
		/// The file is to be accessed according to POSIX rules. This includes allowing multiple files with names, differing only in case,
		/// for file systems that support that naming. Use care when using this option, because files created with this flag may not be
		/// accessible by applications that are written for MS-DOS or 16-bit Windows.
		/// </term>
		/// </item>
		/// <item>
		/// <term>FILE_FLAG_RANDOM_ACCESS 0x10000000</term>
		/// <term>The file is to be accessed randomly. The system can use this as a hint to optimize file caching.</term>
		/// </item>
		/// <item>
		/// <term>FILE_FLAG_SESSION_AWARE 0x00800000</term>
		/// <term>
		/// The file or device is being opened with session awareness. If this flag is not specified, then per-session devices (such as a
		/// device using RemoteFX USB Redirection) cannot be opened by processes running in session 0. This flag has no effect for callers
		/// not in session 0. This flag is supported only on server editions of Windows. Windows Server 2008 R2 and Windows Server 2008: This
		/// flag is not supported before Windows Server 2012.
		/// </term>
		/// </item>
		/// <item>
		/// <term>FILE_FLAG_SEQUENTIAL_SCAN 0x08000000</term>
		/// <term>
		/// The file is to be accessed sequentially from beginning to end. The system can use this as a hint to optimize file caching. If an
		/// application moves the file pointer for random access, optimum caching may not occur. However, correct operation is still
		/// guaranteed. Specifying this flag can increase performance for applications that read large files using sequential access.
		/// Performance gains can be even more noticeable for applications that read large files mostly sequentially, but occasionally skip
		/// over small ranges of bytes. This flag has no effect if the file system does not support cached I/O and FILE_FLAG_NO_BUFFERING.
		/// </term>
		/// </item>
		/// <item>
		/// <term>FILE_FLAG_WRITE_THROUGH 0x80000000</term>
		/// <term>
		/// Write operations will not go through any intermediate cache, they will go directly to disk. If FILE_FLAG_NO_BUFFERING is not also
		/// specified, so that system caching is in effect, then the data is written to the system cache, but is flushed to disk without
		/// delay. If FILE_FLAG_NO_BUFFERING is also specified, so that system caching is not in effect, then the data is immediately flushed
		/// to disk without going through the system cache. The operating system also requests a write-through the hard disk cache to
		/// persistent media. However, not all hardware supports this write-through capability.
		/// </term>
		/// </item>
		/// </list>
		/// <para>
		/// The parameter can also specify Security Quality of Service information. For more information, see Impersonation Levels. When the
		/// calling application specifies the <c>SECURITY_SQOS_PRESENT</c> flag as part of , it can also contain one or more of the following values.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Security flag</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>SECURITY_ANONYMOUS</term>
		/// <term>Impersonates a client at the Anonymous impersonation level.</term>
		/// </item>
		/// <item>
		/// <term>SECURITY_CONTEXT_TRACKING</term>
		/// <term>The security tracking mode is dynamic. If this flag is not specified, the security tracking mode is static.</term>
		/// </item>
		/// <item>
		/// <term>SECURITY_DELEGATION</term>
		/// <term>Impersonates a client at the Delegation impersonation level.</term>
		/// </item>
		/// <item>
		/// <term>SECURITY_EFFECTIVE_ONLY</term>
		/// <term>
		/// Only the enabled aspects of the client's security context are available to the server. If you do not specify this flag, all
		/// aspects of the client's security context are available. This allows the client to limit the groups and privileges that a server
		/// can use while impersonating the client.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SECURITY_IDENTIFICATION</term>
		/// <term>Impersonates a client at the Identification impersonation level.</term>
		/// </item>
		/// <item>
		/// <term>SECURITY_IMPERSONATION</term>
		/// <term>
		/// Impersonate a client at the impersonation level. This is the default behavior if no other flags are specified along with the
		/// SECURITY_SQOS_PRESENT flag.
		/// </term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="hTemplateFile">
		/// <para>
		/// A valid handle to a template file with the <c>GENERIC_READ</c> access right. The template file supplies file attributes and
		/// extended attributes for the file that is being created. This parameter can be <c>NULL</c>.
		/// </para>
		/// <para>When opening an existing file, <c>CreateFileTransacted</c> ignores the template file.</para>
		/// <para>When opening a new EFS-encrypted file, the file inherits the DACL from its parent directory.</para>
		/// </param>
		/// <param name="hTransaction">
		/// <para>A handle to the transaction. This handle is returned by the CreateTransaction function.</para>
		/// </param>
		/// <param name="pusMiniVersion">
		/// <para>
		/// The miniversion to be opened. If the transaction specified in is not the transaction that is modifying the file, this parameter
		/// should be <c>NULL</c>. Otherwise, this parameter can be a miniversion identifier returned by the FSCTL_TXFS_CREATE_MINIVERSION
		/// control code, or one of the following values.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>TXFS_MINIVERSION_COMMITTED_VIEW 0x0000</term>
		/// <term>The view of the file as of its last commit.</term>
		/// </item>
		/// <item>
		/// <term>TXFS_MINIVERSION_DIRTY_VIEW 0xFFFF</term>
		/// <term>The view of the file as it is being modified by the transaction.</term>
		/// </item>
		/// <item>
		/// <term>TXFS_MINIVERSION_DEFAULT_VIEW 0xFFFE</term>
		/// <term>
		/// Either the committed or dirty view of the file, depending on the context. A transaction that is modifying the file gets the dirty
		/// view, while a transaction that is not modifying the file gets the committed view.
		/// </term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="lpExtendedParameter">
		/// <para>TBD</para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is an open handle to the specified file, device, named pipe, or mail slot.</para>
		/// <para>If the function fails, the return value is <c>INVALID_HANDLE_VALUE</c>. To get extended error information, call GetLastError.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// When using the handle returned by <c>CreateFileTransacted</c>, use the transacted version of file I/O functions instead of the
		/// standard file I/O functions where appropriate. For more information, see Programming Considerations for Transactional NTFS.
		/// </para>
		/// <para>
		/// When opening a transacted handle to a directory, that handle must have <c>FILE_WRITE_DATA</c> ( <c>FILE_ADD_FILE</c>) and
		/// <c>FILE_APPEND_DATA</c> ( <c>FILE_ADD_SUBDIRECTORY</c>) permissions. These are included in <c>FILE_GENERIC_WRITE</c> permissions.
		/// You should open directories with fewer permissions if you are just using the handle to create files or subdirectories; otherwise,
		/// sharing violations can occur.
		/// </para>
		/// <para>
		/// You cannot open a file with <c>FILE_EXECUTE</c> access level when that file is a part of another transaction (that is, another
		/// application opened it by calling <c>CreateFileTransacted</c>). This means that <c>CreateFileTransacted</c> fails if the access
		/// level <c>FILE_EXECUTE</c> or <c>FILE_ALL_ACCESS</c> is specified
		/// </para>
		/// <para>
		/// When a non-transacted application calls <c>CreateFileTransacted</c> with <c>MAXIMUM_ALLOWED</c> specified for , a handle is
		/// opened with the same access level every time. When a transacted application calls <c>CreateFileTransacted</c> with
		/// <c>MAXIMUM_ALLOWED</c> specified for , a handle is opened with a differing amount of access based on whether the file is locked
		/// by a transaction. For example, if the calling application has <c>FILE_EXECUTE</c> access level for a file, the application only
		/// obtains this access if the file that is being opened is either not locked by a transaction, or is locked by a transaction and the
		/// application is already a transacted reader for that file.
		/// </para>
		/// <para>See Transactional NTFS for a complete description of transacted operations.</para>
		/// <para>
		/// Use the CloseHandle function to close an object handle returned by <c>CreateFileTransacted</c> when the handle is no longer
		/// needed, and prior to committing or rolling back the transaction.
		/// </para>
		/// <para>
		/// Some file systems, such as the NTFS file system, support compression or encryption for individual files and directories. On
		/// volumes that are formatted for that kind of file system, a new file inherits the compression and encryption attributes of its directory.
		/// </para>
		/// <para>
		/// You cannot use <c>CreateFileTransacted</c> to control compression on a file or directory. For more information, see File
		/// Compression and Decompression, and File Encryption.
		/// </para>
		/// <para>Symbolic link behavior—If the call to this function creates a new file, there is no change in behavior.</para>
		/// <para>If <c>FILE_FLAG_OPEN_REPARSE_POINT</c> is specified:</para>
		/// <list type="bullet">
		/// <item>If an existing file is opened and it is a symbolic link, the handle returned is a handle to the symbolic link.</item>
		/// <item>If <c>TRUNCATE_EXISTING</c> or <c>FILE_FLAG_DELETE_ON_CLOSE</c> are specified, the file affected is a symbolic link.</item>
		/// </list>
		/// <para>If</para>
		/// <para>FILE_FLAG_OPEN_REPARSE_POINT</para>
		/// <para>is not specified:</para>
		/// <list type="bullet">
		/// <item>If an existing file is opened and it is a symbolic link, the handle returned is a handle to the target.</item>
		/// <item>
		/// If <c>CREATE_ALWAYS</c>, <c>TRUNCATE_EXISTING</c>, or <c>FILE_FLAG_DELETE_ON_CLOSE</c> are specified, the file affected is the target.
		/// </item>
		/// </list>
		/// <para>
		/// A multi-sector write is not guaranteed to be atomic unless you are using a transaction (that is, the handle created is a
		/// transacted handle). A single-sector write is atomic. Multi-sector writes that are cached may not always be written to the disk;
		/// therefore, specify
		/// </para>
		/// <para>FILE_FLAG_WRITE_THROUGH</para>
		/// <para>to ensure that an entire multi-sector write is written to the disk without caching.</para>
		/// <para>
		/// As stated previously, if the parameter is <c>NULL</c>, the handle returned by <c>CreateFileTransacted</c> cannot be inherited by
		/// any child processes your application may create. The following information regarding this parameter also applies:
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// If <c>bInheritHandle</c> is not <c>FALSE</c>, which is any nonzero value, then the handle can be inherited. Therefore it is
		/// critical this structure member be properly initialized to <c>FALSE</c> if you do not intend the handle to be inheritable.
		/// </item>
		/// <item>
		/// The access control lists (ACL) in the default security descriptor for a file or directory are inherited from its parent directory.
		/// </item>
		/// <item>
		/// The target file system must support security on files and directories for the <c>lpSecurityDescriptor</c> to have an effect on
		/// them, which can be determined by using GetVolumeInformation
		/// </item>
		/// </list>
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
		/// <term>No</term>
		/// </item>
		/// </list>
		/// <para>Note that SMB 3.0 does not support TxF.</para>
		/// <para>Files</para>
		/// <para>
		/// If you try to create a file on a floppy drive that does not have a floppy disk or a CD-ROM drive that does not have a CD, the
		/// system displays a message for the user to insert a disk or a CD. To prevent the system from displaying this message, call the
		/// </para>
		/// <para>SetErrorMode</para>
		/// <para>function with</para>
		/// <para>SEM_FAILCRITICALERRORS</para>
		/// <para>.</para>
		/// <para>For more information, see Creating and Opening Files.</para>
		/// <para>
		/// If you rename or delete a file and then restore it shortly afterward, the system searches the cache for file information to
		/// restore. Cached information includes its short/long name pair and creation time.
		/// </para>
		/// <para>
		/// If you call <c>CreateFileTransacted</c> on a file that is pending deletion as a result of a previous call to DeleteFile, the
		/// function fails. The operating system delays file deletion until all handles to the file are closed. GetLastError returns <c>ERROR_ACCESS_DENIED</c>.
		/// </para>
		/// <para>
		/// The parameter can be zero, allowing the application to query file attributes without accessing the file if the application is
		/// running with adequate security settings. This is useful to test for the existence of a file without opening it for read and/or
		/// write access, or to obtain other statistics about the file or directory. See Obtaining and Setting File Information and GetFileInformationByHandle.
		/// </para>
		/// <para>
		/// When an application creates a file across a network, it is better to use <c>GENERIC_READ</c> | <c>GENERIC_WRITE</c> than to use
		/// <c>GENERIC_WRITE</c> alone. The resulting code is faster, because the redirector can use the cache manager and send fewer SMBs
		/// with more data. This combination also avoids an issue where writing to a file across a network can occasionally return <c>ERROR_ACCESS_DENIED</c>.
		/// </para>
		/// <para>File Streams</para>
		/// <para>On NTFS file systems, you can use</para>
		/// <para>CreateFileTransacted</para>
		/// <para>to create separate streams within a file.</para>
		/// <para>For more information, see File Streams.</para>
		/// <para>Directories</para>
		/// <para>An application cannot create a directory by using</para>
		/// <para>CreateFileTransacted</para>
		/// <para>, therefore only the</para>
		/// <para>OPEN_EXISTING</para>
		/// <para>value is valid for</para>
		/// <para>dwCreationDisposition</para>
		/// <para>for this use case. To create a directory, the application must call</para>
		/// <para>CreateDirectoryTransacted</para>
		/// <para>,</para>
		/// <para>CreateDirectory</para>
		/// <para>or</para>
		/// <para>CreateDirectoryEx</para>
		/// <para>.</para>
		/// <para>
		/// To open a directory using <c>CreateFileTransacted</c>, specify the <c>FILE_FLAG_BACKUP_SEMANTICS</c> flag as part of .
		/// Appropriate security checks still apply when this flag is used without <c>SE_BACKUP_NAME</c> and <c>SE_RESTORE_NAME</c> privileges.
		/// </para>
		/// <para>
		/// When using <c>CreateFileTransacted</c> to open a directory during defragmentation of a FAT or FAT32 file system volume, do not
		/// specify the <c>MAXIMUM_ALLOWED</c> access right. Access to the directory is denied if this is done. Specify the
		/// <c>GENERIC_READ</c> access right instead.
		/// </para>
		/// <para>For more information, see About Directory Management.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winbase/nf-winbase-createfiletransacteda HANDLE CreateFileTransactedA( LPCSTR
		// lpFileName, DWORD dwDesiredAccess, DWORD dwShareMode, LPSECURITY_ATTRIBUTES lpSecurityAttributes, DWORD dwCreationDisposition,
		// DWORD dwFlagsAndAttributes, HANDLE hTemplateFile, HANDLE hTransaction, PUSHORT pusMiniVersion, PVOID lpExtendedParameter );
		[DllImport(Lib.Kernel32, SetLastError = true, CharSet = CharSet.Auto)]
		[PInvokeData("winbase.h", MSDNShortId = "0cbc081d-8787-409b-84bc-a6a28d8f83a0")]
		public static extern SafeHFILE CreateFileTransacted(string lpFileName, FileAccess dwDesiredAccess, FileShare dwShareMode, SECURITY_ATTRIBUTES lpSecurityAttributes, FileMode dwCreationDisposition, FileFlagsAndAttributes dwFlagsAndAttributes,
			IntPtr hTemplateFile, IntPtr hTransaction, in ushort pusMiniVersion, [Optional] IntPtr lpExtendedParameter);

		/// <summary>
		/// <para>
		/// [Microsoft strongly recommends developers utilize alternative means to achieve your application’s needs. Many scenarios that TxF
		/// was developed for can be achieved through simpler and more readily available techniques. Furthermore, TxF may not be available in
		/// future versions of Microsoft Windows. For more information, and alternatives to TxF, please see
		/// </para>
		/// <para>Alternatives to using Transactional NTFS</para>
		/// <para>.]</para>
		/// <para>
		/// Creates or opens a file, file stream, or directory as a transacted operation. The function returns a handle that can be used to
		/// access the object.
		/// </para>
		/// <para>
		/// To perform this operation as a non-transacted operation or to access objects other than files (for example, named pipes, physical
		/// devices, mailslots), use the CreateFile function.
		/// </para>
		/// <para>For more information about transactions, see the Remarks section of this topic.</para>
		/// </summary>
		/// <param name="lpFileName">
		/// <para>The name of an object to be created or opened.</para>
		/// <para>The object must reside on the local computer; otherwise, the function fails and the last error code is set to <c>ERROR_TRANSACTIONS_UNSUPPORTED_REMOTE</c>.</para>
		/// <para>
		/// In the ANSI version of this function, the name is limited to <c>MAX_PATH</c> characters. To extend this limit to 32,767 wide
		/// characters, call the Unicode version of the function and prepend "\?" to the path. For more information, see Naming a File. For
		/// information on special device names, see Defining an MS-DOS Device Name.
		/// </para>
		/// <para>
		/// To create a file stream, specify the name of the file, a colon, and then the name of the stream. For more information, see File Streams.
		/// </para>
		/// </param>
		/// <param name="dwDesiredAccess">
		/// <para>
		/// The access to the object, which can be summarized as read, write, both or neither (zero). The most commonly used values are
		/// <c>GENERIC_READ</c>, <c>GENERIC_WRITE</c>, or both ( <c>GENERIC_READ</c> | <c>GENERIC_WRITE</c>). For more information, see
		/// Generic Access Rights and File Security and Access Rights.
		/// </para>
		/// <para>
		/// If this parameter is zero, the application can query file, directory, or device attributes without accessing that file or device.
		/// For more information, see the Remarks section of this topic.
		/// </para>
		/// <para>
		/// You cannot request an access mode that conflicts with the sharing mode that is specified in an open request that has an open
		/// handle. For more information, see Creating and Opening Files.
		/// </para>
		/// </param>
		/// <param name="dwShareMode">
		/// <para>The sharing mode of an object, which can be read, write, both, delete, all of these, or none (refer to the following table).</para>
		/// <para>
		/// If this parameter is zero and <c>CreateFileTransacted</c> succeeds, the object cannot be shared and cannot be opened again until
		/// the handle is closed. For more information, see the Remarks section of this topic.
		/// </para>
		/// <para>
		/// You cannot request a sharing mode that conflicts with the access mode that is specified in an open request that has an open
		/// handle, because that would result in the following sharing violation: <c>ERROR_SHARING_VIOLATION</c>. For more information, see
		/// Creating and Opening Files.
		/// </para>
		/// <para>
		/// To enable a process to share an object while another process has the object open, use a combination of one or more of the
		/// following values to specify the access mode they can request to open the object.
		/// </para>
		/// <para>
		/// <c>Note</c> The sharing options for each open handle remain in effect until that handle is closed, regardless of process context.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>0 0x00000000</term>
		/// <term>Disables subsequent open operations on an object to request any type of access to that object.</term>
		/// </item>
		/// <item>
		/// <term>FILE_SHARE_DELETE 0x00000004</term>
		/// <term>
		/// Enables subsequent open operations on an object to request delete access. Otherwise, other processes cannot open the object if
		/// they request delete access. If this flag is not specified, but the object has been opened for delete access, the function fails.
		/// </term>
		/// </item>
		/// <item>
		/// <term>FILE_SHARE_READ 0x00000001</term>
		/// <term>
		/// Enables subsequent open operations on an object to request read access. Otherwise, other processes cannot open the object if they
		/// request read access. If this flag is not specified, but the object has been opened for read access, the function fails.
		/// </term>
		/// </item>
		/// <item>
		/// <term>FILE_SHARE_WRITE 0x00000002</term>
		/// <term>
		/// Enables subsequent open operations on an object to request write access. Otherwise, other processes cannot open the object if
		/// they request write access. If this flag is not specified, but the object has been opened for write access or has a file mapping
		/// with write access, the function fails.
		/// </term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="lpSecurityAttributes">
		/// <para>
		/// A pointer to a SECURITY_ATTRIBUTES structure that contains an optional security descriptor and also determines whether or not the
		/// returned handle can be inherited by child processes. The parameter can be <c>NULL</c>.
		/// </para>
		/// <para>
		/// If the parameter is <c>NULL</c>, the handle returned by <c>CreateFileTransacted</c> cannot be inherited by any child processes
		/// your application may create and the object associated with the returned handle gets a default security descriptor.
		/// </para>
		/// <para>The <c>bInheritHandle</c> member of the structure specifies whether the returned handle can be inherited.</para>
		/// <para>
		/// The <c>lpSecurityDescriptor</c> member of the structure specifies a security descriptor for an object, but may also be <c>NULL</c>.
		/// </para>
		/// <para>
		/// If <c>lpSecurityDescriptor</c> member is <c>NULL</c>, the object associated with the returned handle is assigned a default
		/// security descriptor.
		/// </para>
		/// <para>
		/// <c>CreateFileTransacted</c> ignores the <c>lpSecurityDescriptor</c> member when opening an existing file, but continues to use
		/// the <c>bInheritHandle</c> member.
		/// </para>
		/// <para>For more information, see the Remarks section of this topic.</para>
		/// </param>
		/// <param name="dwCreationDisposition">
		/// <para>An action to take on files that exist and do not exist.</para>
		/// <para>For more information, see the Remarks section of this topic.</para>
		/// <para>This parameter must be one of the following values, which cannot be combined.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>CREATE_ALWAYS 2</term>
		/// <term>
		/// Creates a new file, always. If the specified file exists and is writable, the function overwrites the file, the function
		/// succeeds, and last-error code is set to ERROR_ALREADY_EXISTS (183). If the specified file does not exist and is a valid path, a
		/// new file is created, the function succeeds, and the last-error code is set to zero. For more information, see the Remarks section
		/// of this topic.
		/// </term>
		/// </item>
		/// <item>
		/// <term>CREATE_NEW 1</term>
		/// <term>
		/// Creates a new file, only if it does not already exist. If the specified file exists, the function fails and the last-error code
		/// is set to ERROR_FILE_EXISTS (80). If the specified file does not exist and is a valid path to a writable location, a new file is created.
		/// </term>
		/// </item>
		/// <item>
		/// <term>OPEN_ALWAYS 4</term>
		/// <term>
		/// Opens a file, always. If the specified file exists, the function succeeds and the last-error code is set to ERROR_ALREADY_EXISTS
		/// (183). If the specified file does not exist and is a valid path to a writable location, the function creates a file and the
		/// last-error code is set to zero.
		/// </term>
		/// </item>
		/// <item>
		/// <term>OPEN_EXISTING 3</term>
		/// <term>
		/// Opens a file or device, only if it exists. If the specified file does not exist, the function fails and the last-error code is
		/// set to ERROR_FILE_NOT_FOUND (2). For more information, see the Remarks section of this topic.
		/// </term>
		/// </item>
		/// <item>
		/// <term>TRUNCATE_EXISTING 5</term>
		/// <term>
		/// Opens a file and truncates it so that its size is zero bytes, only if it exists. If the specified file does not exist, the
		/// function fails and the last-error code is set to ERROR_FILE_NOT_FOUND (2). The calling process must open the file with the
		/// GENERIC_WRITE bit set as part of the parameter.
		/// </term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="dwFlagsAndAttributes">
		/// <para>The file attributes and flags, <c>FILE_ATTRIBUTE_NORMAL</c> being the most common default value.</para>
		/// <para>
		/// This parameter can include any combination of the available file attributes ( <c>FILE_ATTRIBUTE_*</c>). All other file attributes
		/// override <c>FILE_ATTRIBUTE_NORMAL</c>.
		/// </para>
		/// <para>
		/// This parameter can also contain combinations of flags ( <c>FILE_FLAG_</c>) for control of buffering behavior, access modes, and
		/// other special-purpose flags. These combine with any <c>FILE_ATTRIBUTE_</c> values.
		/// </para>
		/// <para>
		/// This parameter can also contain Security Quality of Service (SQOS) information by specifying the <c>SECURITY_SQOS_PRESENT</c>
		/// flag. Additional SQOS-related flags information is presented in the table following the attributes and flags tables.
		/// </para>
		/// <para>
		/// <c>Note</c> When <c>CreateFileTransacted</c> opens an existing file, it generally combines the file flags with the file
		/// attributes of the existing file, and ignores any file attributes supplied as part of . Special cases are detailed in Creating and
		/// Opening Files.
		/// </para>
		/// <para>The following file attributes and flags are used only for file objects, not other types of objects that</para>
		/// <para>CreateFileTransacted</para>
		/// <para>
		/// opens (additional information can be found in the Remarks section of this topic). For more advanced access to file attributes, see
		/// </para>
		/// <para>SetFileAttributes</para>
		/// <para>. For a complete list of all file attributes with their values and descriptions, see</para>
		/// <para>File Attribute Constants</para>
		/// <para>.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Attribute</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>FILE_ATTRIBUTE_ARCHIVE 32 (0x20)</term>
		/// <term>The file should be archived. Applications use this attribute to mark files for backup or removal.</term>
		/// </item>
		/// <item>
		/// <term>FILE_ATTRIBUTE_ENCRYPTED 16384 (0x4000)</term>
		/// <term>
		/// The file or directory is encrypted. For a file, this means that all data in the file is encrypted. For a directory, this means
		/// that encryption is the default for newly created files and subdirectories. For more information, see File Encryption. This flag
		/// has no effect if FILE_ATTRIBUTE_SYSTEM is also specified.
		/// </term>
		/// </item>
		/// <item>
		/// <term>FILE_ATTRIBUTE_HIDDEN 2 (0x2)</term>
		/// <term>The file is hidden. Do not include it in an ordinary directory listing.</term>
		/// </item>
		/// <item>
		/// <term>FILE_ATTRIBUTE_NORMAL 128 (0x80)</term>
		/// <term>The file does not have other attributes set. This attribute is valid only if used alone.</term>
		/// </item>
		/// <item>
		/// <term>FILE_ATTRIBUTE_OFFLINE 4096 (0x1000)</term>
		/// <term>
		/// The data of a file is not immediately available. This attribute indicates that file data is physically moved to offline storage.
		/// This attribute is used by Remote Storage, the hierarchical storage management software. Applications should not arbitrarily
		/// change this attribute.
		/// </term>
		/// </item>
		/// <item>
		/// <term>FILE_ATTRIBUTE_READONLY 1 (0x1)</term>
		/// <term>The file is read only. Applications can read the file, but cannot write to or delete it.</term>
		/// </item>
		/// <item>
		/// <term>FILE_ATTRIBUTE_SYSTEM 4 (0x4)</term>
		/// <term>The file is part of or used exclusively by an operating system.</term>
		/// </item>
		/// <item>
		/// <term>FILE_ATTRIBUTE_TEMPORARY 256 (0x100)</term>
		/// <term>
		/// The file is being used for temporary storage. File systems avoid writing data back to mass storage if sufficient cache memory is
		/// available, because an application deletes a temporary file after a handle is closed. In that case, the system can entirely avoid
		/// writing the data. Otherwise, the data is written after the handle is closed.
		/// </term>
		/// </item>
		/// </list>
		/// <list type="table">
		/// <listheader>
		/// <term>Flag</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>FILE_FLAG_BACKUP_SEMANTICS 0x02000000</term>
		/// <term>
		/// The file is being opened or created for a backup or restore operation. The system ensures that the calling process overrides file
		/// security checks when the process has SE_BACKUP_NAME and SE_RESTORE_NAME privileges. For more information, see Changing Privileges
		/// in a Token. You must set this flag to obtain a handle to a directory. A directory handle can be passed to some functions instead
		/// of a file handle. For more information, see Directory Handles.
		/// </term>
		/// </item>
		/// <item>
		/// <term>FILE_FLAG_DELETE_ON_CLOSE 0x04000000</term>
		/// <term>
		/// The file is to be deleted immediately after the last transacted writer handle to the file is closed, provided that the
		/// transaction is still active. If a file has been marked for deletion and a transacted writer handle is still open after the
		/// transaction completes, the file will not be deleted. If there are existing open handles to a file, the call fails unless they
		/// were all opened with the FILE_SHARE_DELETE share mode. Subsequent open requests for the file fail, unless the FILE_SHARE_DELETE
		/// share mode is specified.
		/// </term>
		/// </item>
		/// <item>
		/// <term>FILE_FLAG_NO_BUFFERING 0x20000000</term>
		/// <term>
		/// The file is being opened with no system caching. This flag does not affect hard disk caching or memory mapped files. When
		/// combined with FILE_FLAG_OVERLAPPED, the flag gives maximum asynchronous performance, because the I/O does not rely on the
		/// synchronous operations of the memory manager. However, some I/O operations take more time, because data is not being held in the
		/// cache. Also, the file metadata may still be cached. To flush the metadata to disk, use the FlushFileBuffers function. An
		/// application must meet certain requirements when working with files that are opened with FILE_FLAG_NO_BUFFERING: One way to align
		/// buffers on integer multiples of the volume sector size is to use VirtualAlloc to allocate the buffers. It allocates memory that
		/// is aligned on addresses that are integer multiples of the operating system's memory page size. Because both memory page and
		/// volume sector sizes are powers of 2, this memory is also aligned on addresses that are integer multiples of a volume sector size.
		/// Memory pages are 4 or 8 KB in size; sectors are 512 bytes (hard disks), 2048 bytes (CD), or 4096 bytes (hard disks), and
		/// therefore, volume sectors can never be larger than memory pages. An application can determine a volume sector size by calling the
		/// GetDiskFreeSpace function.
		/// </term>
		/// </item>
		/// <item>
		/// <term>FILE_FLAG_OPEN_NO_RECALL 0x00100000</term>
		/// <term>
		/// The file data is requested, but it should continue to be located in remote storage. It should not be transported back to local
		/// storage. This flag is for use by remote storage systems.
		/// </term>
		/// </item>
		/// <item>
		/// <term>FILE_FLAG_OPEN_REPARSE_POINT 0x00200000</term>
		/// <term>
		/// Normal reparse point processing will not occur; CreateFileTransacted will attempt to open the reparse point. When a file is
		/// opened, a file handle is returned, whether or not the filter that controls the reparse point is operational. This flag cannot be
		/// used with the CREATE_ALWAYS flag. If the file is not a reparse point, then this flag is ignored.
		/// </term>
		/// </item>
		/// <item>
		/// <term>FILE_FLAG_OVERLAPPED 0x40000000</term>
		/// <term>
		/// The file is being opened or created for asynchronous I/O. When the operation is complete, the event specified in the OVERLAPPED
		/// structure is set to the signaled state. Operations that take a significant amount of time to process return ERROR_IO_PENDING. If
		/// this flag is specified, the file can be used for simultaneous read and write operations. The system does not maintain the file
		/// pointer, therefore you must pass the file position to the read and write functions in the OVERLAPPED structure or update the file
		/// pointer. If this flag is not specified, then I/O operations are serialized, even if the calls to the read and write functions
		/// specify an OVERLAPPED structure.
		/// </term>
		/// </item>
		/// <item>
		/// <term>FILE_FLAG_POSIX_SEMANTICS 0x0100000</term>
		/// <term>
		/// The file is to be accessed according to POSIX rules. This includes allowing multiple files with names, differing only in case,
		/// for file systems that support that naming. Use care when using this option, because files created with this flag may not be
		/// accessible by applications that are written for MS-DOS or 16-bit Windows.
		/// </term>
		/// </item>
		/// <item>
		/// <term>FILE_FLAG_RANDOM_ACCESS 0x10000000</term>
		/// <term>The file is to be accessed randomly. The system can use this as a hint to optimize file caching.</term>
		/// </item>
		/// <item>
		/// <term>FILE_FLAG_SESSION_AWARE 0x00800000</term>
		/// <term>
		/// The file or device is being opened with session awareness. If this flag is not specified, then per-session devices (such as a
		/// device using RemoteFX USB Redirection) cannot be opened by processes running in session 0. This flag has no effect for callers
		/// not in session 0. This flag is supported only on server editions of Windows. Windows Server 2008 R2 and Windows Server 2008: This
		/// flag is not supported before Windows Server 2012.
		/// </term>
		/// </item>
		/// <item>
		/// <term>FILE_FLAG_SEQUENTIAL_SCAN 0x08000000</term>
		/// <term>
		/// The file is to be accessed sequentially from beginning to end. The system can use this as a hint to optimize file caching. If an
		/// application moves the file pointer for random access, optimum caching may not occur. However, correct operation is still
		/// guaranteed. Specifying this flag can increase performance for applications that read large files using sequential access.
		/// Performance gains can be even more noticeable for applications that read large files mostly sequentially, but occasionally skip
		/// over small ranges of bytes. This flag has no effect if the file system does not support cached I/O and FILE_FLAG_NO_BUFFERING.
		/// </term>
		/// </item>
		/// <item>
		/// <term>FILE_FLAG_WRITE_THROUGH 0x80000000</term>
		/// <term>
		/// Write operations will not go through any intermediate cache, they will go directly to disk. If FILE_FLAG_NO_BUFFERING is not also
		/// specified, so that system caching is in effect, then the data is written to the system cache, but is flushed to disk without
		/// delay. If FILE_FLAG_NO_BUFFERING is also specified, so that system caching is not in effect, then the data is immediately flushed
		/// to disk without going through the system cache. The operating system also requests a write-through the hard disk cache to
		/// persistent media. However, not all hardware supports this write-through capability.
		/// </term>
		/// </item>
		/// </list>
		/// <para>
		/// The parameter can also specify Security Quality of Service information. For more information, see Impersonation Levels. When the
		/// calling application specifies the <c>SECURITY_SQOS_PRESENT</c> flag as part of , it can also contain one or more of the following values.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Security flag</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>SECURITY_ANONYMOUS</term>
		/// <term>Impersonates a client at the Anonymous impersonation level.</term>
		/// </item>
		/// <item>
		/// <term>SECURITY_CONTEXT_TRACKING</term>
		/// <term>The security tracking mode is dynamic. If this flag is not specified, the security tracking mode is static.</term>
		/// </item>
		/// <item>
		/// <term>SECURITY_DELEGATION</term>
		/// <term>Impersonates a client at the Delegation impersonation level.</term>
		/// </item>
		/// <item>
		/// <term>SECURITY_EFFECTIVE_ONLY</term>
		/// <term>
		/// Only the enabled aspects of the client's security context are available to the server. If you do not specify this flag, all
		/// aspects of the client's security context are available. This allows the client to limit the groups and privileges that a server
		/// can use while impersonating the client.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SECURITY_IDENTIFICATION</term>
		/// <term>Impersonates a client at the Identification impersonation level.</term>
		/// </item>
		/// <item>
		/// <term>SECURITY_IMPERSONATION</term>
		/// <term>
		/// Impersonate a client at the impersonation level. This is the default behavior if no other flags are specified along with the
		/// SECURITY_SQOS_PRESENT flag.
		/// </term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="hTemplateFile">
		/// <para>
		/// A valid handle to a template file with the <c>GENERIC_READ</c> access right. The template file supplies file attributes and
		/// extended attributes for the file that is being created. This parameter can be <c>NULL</c>.
		/// </para>
		/// <para>When opening an existing file, <c>CreateFileTransacted</c> ignores the template file.</para>
		/// <para>When opening a new EFS-encrypted file, the file inherits the DACL from its parent directory.</para>
		/// </param>
		/// <param name="hTransaction">
		/// <para>A handle to the transaction. This handle is returned by the CreateTransaction function.</para>
		/// </param>
		/// <param name="pusMiniVersion">
		/// <para>
		/// The miniversion to be opened. If the transaction specified in is not the transaction that is modifying the file, this parameter
		/// should be <c>NULL</c>. Otherwise, this parameter can be a miniversion identifier returned by the FSCTL_TXFS_CREATE_MINIVERSION
		/// control code, or one of the following values.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>TXFS_MINIVERSION_COMMITTED_VIEW 0x0000</term>
		/// <term>The view of the file as of its last commit.</term>
		/// </item>
		/// <item>
		/// <term>TXFS_MINIVERSION_DIRTY_VIEW 0xFFFF</term>
		/// <term>The view of the file as it is being modified by the transaction.</term>
		/// </item>
		/// <item>
		/// <term>TXFS_MINIVERSION_DEFAULT_VIEW 0xFFFE</term>
		/// <term>
		/// Either the committed or dirty view of the file, depending on the context. A transaction that is modifying the file gets the dirty
		/// view, while a transaction that is not modifying the file gets the committed view.
		/// </term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="lpExtendedParameter">
		/// <para>TBD</para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is an open handle to the specified file, device, named pipe, or mail slot.</para>
		/// <para>If the function fails, the return value is <c>INVALID_HANDLE_VALUE</c>. To get extended error information, call GetLastError.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// When using the handle returned by <c>CreateFileTransacted</c>, use the transacted version of file I/O functions instead of the
		/// standard file I/O functions where appropriate. For more information, see Programming Considerations for Transactional NTFS.
		/// </para>
		/// <para>
		/// When opening a transacted handle to a directory, that handle must have <c>FILE_WRITE_DATA</c> ( <c>FILE_ADD_FILE</c>) and
		/// <c>FILE_APPEND_DATA</c> ( <c>FILE_ADD_SUBDIRECTORY</c>) permissions. These are included in <c>FILE_GENERIC_WRITE</c> permissions.
		/// You should open directories with fewer permissions if you are just using the handle to create files or subdirectories; otherwise,
		/// sharing violations can occur.
		/// </para>
		/// <para>
		/// You cannot open a file with <c>FILE_EXECUTE</c> access level when that file is a part of another transaction (that is, another
		/// application opened it by calling <c>CreateFileTransacted</c>). This means that <c>CreateFileTransacted</c> fails if the access
		/// level <c>FILE_EXECUTE</c> or <c>FILE_ALL_ACCESS</c> is specified
		/// </para>
		/// <para>
		/// When a non-transacted application calls <c>CreateFileTransacted</c> with <c>MAXIMUM_ALLOWED</c> specified for , a handle is
		/// opened with the same access level every time. When a transacted application calls <c>CreateFileTransacted</c> with
		/// <c>MAXIMUM_ALLOWED</c> specified for , a handle is opened with a differing amount of access based on whether the file is locked
		/// by a transaction. For example, if the calling application has <c>FILE_EXECUTE</c> access level for a file, the application only
		/// obtains this access if the file that is being opened is either not locked by a transaction, or is locked by a transaction and the
		/// application is already a transacted reader for that file.
		/// </para>
		/// <para>See Transactional NTFS for a complete description of transacted operations.</para>
		/// <para>
		/// Use the CloseHandle function to close an object handle returned by <c>CreateFileTransacted</c> when the handle is no longer
		/// needed, and prior to committing or rolling back the transaction.
		/// </para>
		/// <para>
		/// Some file systems, such as the NTFS file system, support compression or encryption for individual files and directories. On
		/// volumes that are formatted for that kind of file system, a new file inherits the compression and encryption attributes of its directory.
		/// </para>
		/// <para>
		/// You cannot use <c>CreateFileTransacted</c> to control compression on a file or directory. For more information, see File
		/// Compression and Decompression, and File Encryption.
		/// </para>
		/// <para>Symbolic link behavior—If the call to this function creates a new file, there is no change in behavior.</para>
		/// <para>If <c>FILE_FLAG_OPEN_REPARSE_POINT</c> is specified:</para>
		/// <list type="bullet">
		/// <item>If an existing file is opened and it is a symbolic link, the handle returned is a handle to the symbolic link.</item>
		/// <item>If <c>TRUNCATE_EXISTING</c> or <c>FILE_FLAG_DELETE_ON_CLOSE</c> are specified, the file affected is a symbolic link.</item>
		/// </list>
		/// <para>If</para>
		/// <para>FILE_FLAG_OPEN_REPARSE_POINT</para>
		/// <para>is not specified:</para>
		/// <list type="bullet">
		/// <item>If an existing file is opened and it is a symbolic link, the handle returned is a handle to the target.</item>
		/// <item>
		/// If <c>CREATE_ALWAYS</c>, <c>TRUNCATE_EXISTING</c>, or <c>FILE_FLAG_DELETE_ON_CLOSE</c> are specified, the file affected is the target.
		/// </item>
		/// </list>
		/// <para>
		/// A multi-sector write is not guaranteed to be atomic unless you are using a transaction (that is, the handle created is a
		/// transacted handle). A single-sector write is atomic. Multi-sector writes that are cached may not always be written to the disk;
		/// therefore, specify
		/// </para>
		/// <para>FILE_FLAG_WRITE_THROUGH</para>
		/// <para>to ensure that an entire multi-sector write is written to the disk without caching.</para>
		/// <para>
		/// As stated previously, if the parameter is <c>NULL</c>, the handle returned by <c>CreateFileTransacted</c> cannot be inherited by
		/// any child processes your application may create. The following information regarding this parameter also applies:
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// If <c>bInheritHandle</c> is not <c>FALSE</c>, which is any nonzero value, then the handle can be inherited. Therefore it is
		/// critical this structure member be properly initialized to <c>FALSE</c> if you do not intend the handle to be inheritable.
		/// </item>
		/// <item>
		/// The access control lists (ACL) in the default security descriptor for a file or directory are inherited from its parent directory.
		/// </item>
		/// <item>
		/// The target file system must support security on files and directories for the <c>lpSecurityDescriptor</c> to have an effect on
		/// them, which can be determined by using GetVolumeInformation
		/// </item>
		/// </list>
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
		/// <term>No</term>
		/// </item>
		/// </list>
		/// <para>Note that SMB 3.0 does not support TxF.</para>
		/// <para>Files</para>
		/// <para>
		/// If you try to create a file on a floppy drive that does not have a floppy disk or a CD-ROM drive that does not have a CD, the
		/// system displays a message for the user to insert a disk or a CD. To prevent the system from displaying this message, call the
		/// </para>
		/// <para>SetErrorMode</para>
		/// <para>function with</para>
		/// <para>SEM_FAILCRITICALERRORS</para>
		/// <para>.</para>
		/// <para>For more information, see Creating and Opening Files.</para>
		/// <para>
		/// If you rename or delete a file and then restore it shortly afterward, the system searches the cache for file information to
		/// restore. Cached information includes its short/long name pair and creation time.
		/// </para>
		/// <para>
		/// If you call <c>CreateFileTransacted</c> on a file that is pending deletion as a result of a previous call to DeleteFile, the
		/// function fails. The operating system delays file deletion until all handles to the file are closed. GetLastError returns <c>ERROR_ACCESS_DENIED</c>.
		/// </para>
		/// <para>
		/// The parameter can be zero, allowing the application to query file attributes without accessing the file if the application is
		/// running with adequate security settings. This is useful to test for the existence of a file without opening it for read and/or
		/// write access, or to obtain other statistics about the file or directory. See Obtaining and Setting File Information and GetFileInformationByHandle.
		/// </para>
		/// <para>
		/// When an application creates a file across a network, it is better to use <c>GENERIC_READ</c> | <c>GENERIC_WRITE</c> than to use
		/// <c>GENERIC_WRITE</c> alone. The resulting code is faster, because the redirector can use the cache manager and send fewer SMBs
		/// with more data. This combination also avoids an issue where writing to a file across a network can occasionally return <c>ERROR_ACCESS_DENIED</c>.
		/// </para>
		/// <para>File Streams</para>
		/// <para>On NTFS file systems, you can use</para>
		/// <para>CreateFileTransacted</para>
		/// <para>to create separate streams within a file.</para>
		/// <para>For more information, see File Streams.</para>
		/// <para>Directories</para>
		/// <para>An application cannot create a directory by using</para>
		/// <para>CreateFileTransacted</para>
		/// <para>, therefore only the</para>
		/// <para>OPEN_EXISTING</para>
		/// <para>value is valid for</para>
		/// <para>dwCreationDisposition</para>
		/// <para>for this use case. To create a directory, the application must call</para>
		/// <para>CreateDirectoryTransacted</para>
		/// <para>,</para>
		/// <para>CreateDirectory</para>
		/// <para>or</para>
		/// <para>CreateDirectoryEx</para>
		/// <para>.</para>
		/// <para>
		/// To open a directory using <c>CreateFileTransacted</c>, specify the <c>FILE_FLAG_BACKUP_SEMANTICS</c> flag as part of .
		/// Appropriate security checks still apply when this flag is used without <c>SE_BACKUP_NAME</c> and <c>SE_RESTORE_NAME</c> privileges.
		/// </para>
		/// <para>
		/// When using <c>CreateFileTransacted</c> to open a directory during defragmentation of a FAT or FAT32 file system volume, do not
		/// specify the <c>MAXIMUM_ALLOWED</c> access right. Access to the directory is denied if this is done. Specify the
		/// <c>GENERIC_READ</c> access right instead.
		/// </para>
		/// <para>For more information, see About Directory Management.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winbase/nf-winbase-createfiletransacteda HANDLE CreateFileTransactedA( LPCSTR
		// lpFileName, DWORD dwDesiredAccess, DWORD dwShareMode, LPSECURITY_ATTRIBUTES lpSecurityAttributes, DWORD dwCreationDisposition,
		// DWORD dwFlagsAndAttributes, HANDLE hTemplateFile, HANDLE hTransaction, PUSHORT pusMiniVersion, PVOID lpExtendedParameter );
		[DllImport(Lib.Kernel32, SetLastError = true, CharSet = CharSet.Auto)]
		[PInvokeData("winbase.h", MSDNShortId = "0cbc081d-8787-409b-84bc-a6a28d8f83a0")]
		public static extern SafeHFILE CreateFileTransacted(string lpFileName, FileAccess dwDesiredAccess, FileShare dwShareMode, SECURITY_ATTRIBUTES lpSecurityAttributes, FileMode dwCreationDisposition, FileFlagsAndAttributes dwFlagsAndAttributes,
			IntPtr hTemplateFile, IntPtr hTransaction, [Optional] IntPtr pusMiniVersion, [Optional] IntPtr lpExtendedParameter);

		/// <summary>
		/// <para>
		/// [Microsoft strongly recommends developers utilize alternative means to achieve your application’s needs. Many scenarios that TxF
		/// was developed for can be achieved through simpler and more readily available techniques. Furthermore, TxF may not be available in
		/// future versions of Microsoft Windows. For more information, and alternatives to TxF, please see Alternatives to using
		/// Transactional NTFS.]
		/// </para>
		/// <para>Deletes an existing file as a transacted operation.</para>
		/// </summary>
		/// <param name="lpFileName">
		/// <para>The name of the file to be deleted.</para>
		/// <para>
		/// In the ANSI version of this function, the name is limited to <c>MAX_PATH</c> characters. To extend this limit to 32,767 wide
		/// characters, call the Unicode version of the function and prepend "\?" to the path. For more information, see Naming a File.
		/// </para>
		/// <para>The file must reside on the local computer; otherwise, the function fails and the last error code is set to <c>ERROR_TRANSACTIONS_UNSUPPORTED_REMOTE</c>.</para>
		/// </param>
		/// <param name="hTransaction">
		/// <para>A handle to the transaction. This handle is returned by the CreateTransaction function.</para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is nonzero.</para>
		/// <para>If the function fails, the return value is 0 (zero). To get extended error information, call GetLastError.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// If an application attempts to delete a file that does not exist, the <c>DeleteFileTransacted</c> function fails with
		/// <c>ERROR_FILE_NOT_FOUND</c>. If the file is a read-only file, the function fails with <c>ERROR_ACCESS_DENIED</c>.
		/// </para>
		/// <para>The following list identifies some tips for deleting, removing, or closing files:</para>
		/// <list type="bullet">
		/// <item>
		/// <term>To delete a read-only file, first you must remove the read-only attribute.</term>
		/// </item>
		/// <item>
		/// <term>
		/// To delete or rename a file, you must have either delete permission on the file, or delete child permission in the parent directory.
		/// </term>
		/// </item>
		/// <item>
		/// <term>To recursively delete the files in a directory, use the SHFileOperation function.</term>
		/// </item>
		/// <item>
		/// <term>To remove an empty directory, use the RemoveDirectoryTransacted function.</term>
		/// </item>
		/// <item>
		/// <term>To close an open file, use the CloseHandle function.</term>
		/// </item>
		/// </list>
		/// <para>
		/// If you set up a directory with all access except delete and delete child, and the access control lists (ACL) of new files are
		/// inherited, then you can create a file without being able to delete it. However, then you can create a file, and then get all the
		/// access you request on the handle that is returned to you at the time you create the file.
		/// </para>
		/// <para>
		/// If you request delete permission at the time you create a file, you can delete or rename the file with that handle, but not with
		/// any other handle. For more information, see File Security and Access Rights.
		/// </para>
		/// <para>
		/// The <c>DeleteFileTransacted</c> function fails if an application attempts to delete a file that has other handles open for normal
		/// I/O or as a memory-mapped file ( <c>FILE_SHARE_DELETE</c> must have been specified when other handles were opened).
		/// </para>
		/// <para>
		/// The <c>DeleteFileTransacted</c> function marks a file for deletion on close. The file is deleted after the last transacted writer
		/// handle to the file is closed, provided that the transaction is still active. If a file has been marked for deletion and a
		/// transacted writer handle is still open after the transaction completes, the file will not be deleted.
		/// </para>
		/// <para>
		/// <c>Symbolic links:</c> If the path points to a symbolic link, the symbolic link is deleted, not the target. To delete a target,
		/// you must call CreateFile and specify <c>FILE_FLAG_DELETE_ON_CLOSE</c>.
		/// </para>
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
		/// <term>No</term>
		/// </item>
		/// </list>
		/// <para>SMB 3.0 does not support TxF.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winbase/nf-winbase-deletefiletransacteda BOOL DeleteFileTransactedA( LPCSTR
		// lpFileName, HANDLE hTransaction );
		[DllImport(Lib.Kernel32, SetLastError = true, CharSet = CharSet.Auto)]
		[PInvokeData("winbase.h", MSDNShortId = "e0a6230b-2da1-4746-95fe-80f7b6bae41f")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool DeleteFileTransacted(string lpFileName, IntPtr hTransaction);

		/// <summary>
		/// <para>
		/// [Microsoft strongly recommends developers utilize alternative means to achieve your application’s needs. Many scenarios that TxF
		/// was developed for can be achieved through simpler and more readily available techniques. Furthermore, TxF may not be available in
		/// future versions of Microsoft Windows. For more information, and alternatives to TxF, please see Alternatives to using
		/// Transactional NTFS.]
		/// </para>
		/// <para>
		/// Creates an enumeration of all the hard links to the specified file as a transacted operation. The function returns a handle to
		/// the enumeration that can be used on subsequent calls to the FindNextFileNameW function.
		/// </para>
		/// </summary>
		/// <param name="lpFileName">
		/// <para>The name of the file.</para>
		/// <para>
		/// The file must reside on the local computer; otherwise, the function fails and the last error code is set to
		/// <c>ERROR_TRANSACTIONS_UNSUPPORTED_REMOTE</c> (6805).
		/// </para>
		/// </param>
		/// <param name="dwFlags">
		/// <para>Reserved; specify zero (0).</para>
		/// </param>
		/// <param name="StringLength">
		/// <para>
		/// The size of the buffer pointed to by the LinkName parameter, in characters. If this call fails and the error is
		/// <c>ERROR_MORE_DATA</c> (234), the value that is returned by this parameter is the size that the buffer pointed to by LinkName
		/// must be to contain all the data.
		/// </para>
		/// </param>
		/// <param name="LinkName">
		/// <para>A pointer to a buffer to store the first link name found for lpFileName.</para>
		/// </param>
		/// <param name="hTransaction">
		/// <para>A handle to the transaction. This handle is returned by the CreateTransaction function.</para>
		/// </param>
		/// <returns>
		/// <para>
		/// If the function succeeds, the return value is a search handle that can be used with the FindNextFileNameW function or closed with
		/// the FindClose function.
		/// </para>
		/// <para>
		/// If the function fails, the return value is <c>INVALID_HANDLE_VALUE</c> (0xffffffff). To get extended error information, call the
		/// GetLastError function.
		/// </para>
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
		/// <term>No</term>
		/// </item>
		/// </list>
		/// <para>SMB 3.0 does not support TxF.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winbase/nf-winbase-findfirstfilenametransactedw HANDLE
		// FindFirstFileNameTransactedW( LPCWSTR lpFileName, DWORD dwFlags, LPDWORD StringLength, PWSTR LinkName, HANDLE hTransaction );
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true, CharSet = CharSet.Unicode)]
		[PInvokeData("winbase.h", MSDNShortId = "79c7d32d-3cb7-4e27-9db1-f24282bf606a")]
		public static extern IntPtr FindFirstFileNameTransactedW(string lpFileName, uint dwFlags, ref uint StringLength, StringBuilder LinkName, IntPtr hTransaction);

		/// <summary>
		/// <para>
		/// [Microsoft strongly recommends developers utilize alternative means to achieve your application’s needs. Many scenarios that TxF
		/// was developed for can be achieved through simpler and more readily available techniques. Furthermore, TxF may not be available in
		/// future versions of Microsoft Windows. For more information, and alternatives to TxF, please see Alternatives to using
		/// Transactional NTFS.]
		/// </para>
		/// <para>Searches a directory for a file or subdirectory with a name that matches a specific name as a transacted operation.</para>
		/// <para>This function is the transacted form of the FindFirstFileEx function.</para>
		/// <para>For the most basic version of this function, see FindFirstFile.</para>
		/// </summary>
		/// <param name="lpFileName">
		/// <para>
		/// The directory or path, and the file name. The file name can include wildcard characters, for example, an asterisk (*) or a
		/// question mark (?).
		/// </para>
		/// <para>
		/// This parameter should not be <c>NULL</c>, an invalid string (for example, an empty string or a string that is missing the
		/// terminating null character), or end in a trailing backslash ().
		/// </para>
		/// <para>
		/// If the string ends with a wildcard, period (.), or directory name, the user must have access to the root and all subdirectories
		/// on the path.
		/// </para>
		/// <para>
		/// In the ANSI version of this function, the name is limited to <c>MAX_PATH</c> characters. To extend this limit to 32,767 wide
		/// characters, call the Unicode version of the function and prepend "\?" to the path. For more information, see Naming a File.
		/// </para>
		/// <para>The file must reside on the local computer; otherwise, the function fails and the last error code is set to <c>ERROR_TRANSACTIONS_UNSUPPORTED_REMOTE</c>.</para>
		/// </param>
		/// <param name="fInfoLevelId">
		/// <para>The information level of the returned data.</para>
		/// <para>This parameter is one of the FINDEX_INFO_LEVELS enumeration values.</para>
		/// </param>
		/// <param name="lpFindFileData">
		/// <para>A pointer to the WIN32_FIND_DATA structure that receives information about a found file or subdirectory.</para>
		/// </param>
		/// <param name="fSearchOp">
		/// <para>The type of filtering to perform that is different from wildcard matching.</para>
		/// <para>This parameter is one of the FINDEX_SEARCH_OPS enumeration values.</para>
		/// </param>
		/// <param name="lpSearchFilter">
		/// <para>A pointer to the search criteria if the specified fSearchOp needs structured search information.</para>
		/// <para>
		/// At this time, none of the supported fSearchOp values require extended search information. Therefore, this pointer must be <c>NULL</c>.
		/// </para>
		/// </param>
		/// <param name="dwAdditionalFlags">
		/// <para>Specifies additional flags that control the search.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>FIND_FIRST_EX_CASE_SENSITIVE 1</term>
		/// <term>Searches are case-sensitive.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="hTransaction">
		/// <para>A handle to the transaction. This handle is returned by the CreateTransaction function.</para>
		/// </param>
		/// <returns>
		/// <para>
		/// If the function succeeds, the return value is a search handle used in a subsequent call to FindNextFile or FindClose, and the
		/// lpFindFileData parameter contains information about the first file or directory found.
		/// </para>
		/// <para>
		/// If the function fails or fails to locate files from the search string in the lpFileName parameter, the return value is
		/// <c>INVALID_HANDLE_VALUE</c> and the contents of lpFindFileData are indeterminate. To get extended error information, call the
		/// GetLastError function.
		/// </para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The <c>FindFirstFileTransacted</c> function opens a search handle and returns information about the first file that the file
		/// system finds with a name that matches the specified pattern. This may or may not be the first file or directory that appears in a
		/// directory-listing application (such as the dir command) when given the same file name string pattern. This is because
		/// <c>FindFirstFileTransacted</c> does no sorting of the search results. For additional information, see FindNextFile.
		/// </para>
		/// <para>The following list identifies some other search characteristics:</para>
		/// <list type="bullet">
		/// <item>
		/// <term>The search is performed strictly on the name of the file, not on any attributes such as a date or a file type.</term>
		/// </item>
		/// <item>
		/// <term>The search includes the long and short file names.</term>
		/// </item>
		/// <item>
		/// <term>An attempt to open a search with a trailing backslash always fails.</term>
		/// </item>
		/// <item>
		/// <term>
		/// Passing an invalid string, <c>NULL</c>, or empty string for the lpFileName parameter is not a valid use of this function. Results
		/// in this case are undefined.
		/// </term>
		/// </item>
		/// </list>
		/// <para>
		/// <c>Note</c> In rare cases, file information on NTFS file systems may not be current at the time you call this function. To be
		/// assured of getting the current file information, call the GetFileInformationByHandle function.
		/// </para>
		/// <para>
		/// If the underlying file system does not support the specified type of filtering, other than directory filtering,
		/// <c>FindFirstFileTransacted</c> fails with the error <c>ERROR_NOT_SUPPORTED</c>. The application must use FINDEX_SEARCH_OPS type
		/// <c>FileExSearchNameMatch</c> and perform its own filtering.
		/// </para>
		/// <para>
		/// After the search handle is established, use it in the FindNextFile function to search for other files that match the same pattern
		/// with the same filtering that is being performed. When the search handle is not needed, it should be closed by using the FindClose function.
		/// </para>
		/// <para>
		/// As stated previously, you cannot use a trailing backslash () in the lpFileName input string for <c>FindFirstFileTransacted</c>,
		/// therefore it may not be obvious how to search root directories. If you want to see files or get the attributes of a root
		/// directory, the following options would apply:
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <term>To examine files in a root directory, you can use "C:\*" and step through the directory by using FindNextFile.</term>
		/// </item>
		/// <item>
		/// <term>To get the attributes of a root directory, use the GetFileAttributes function.</term>
		/// </item>
		/// </list>
		/// <para><c>Note</c> Prepending the string "\\?\" does not allow access to the root directory.</para>
		/// <para>
		/// On network shares, you can use an lpFileName in the form of the following: "\\server\service\*". However, you cannot use an
		/// lpFileName that points to the share itself; for example, "\\server\service" is not valid.
		/// </para>
		/// <para>
		/// To examine a directory that is not a root directory, use the path to that directory, without a trailing backslash. For example,
		/// an argument of "C:\Windows" returns information about the directory "C:\Windows", not about a directory or file in "C:\Windows".
		/// To examine the files and directories in "C:\Windows", use an lpFileName of "C:\Windows*".
		/// </para>
		/// <para>
		/// Be aware that some other thread or process could create or delete a file with this name between the time you query for the result
		/// and the time you act on the information. If this is a potential concern for your application, one possible solution is to use the
		/// CreateFile function with <c>CREATE_NEW</c> (which fails if the file exists) or <c>OPEN_EXISTING</c> (which fails if the file does
		/// not exist).
		/// </para>
		/// <para>
		/// If you are writing a 32-bit application to list all the files in a directory and the application may be run on a 64-bit computer,
		/// you should call Wow64DisableWow64FsRedirection before calling <c>FindFirstFileTransacted</c> and call
		/// Wow64RevertWow64FsRedirection after the last call to FindNextFile. For more information, see File System Redirector.
		/// </para>
		/// <para>
		/// If the path points to a symbolic link, the WIN32_FIND_DATA buffer contains information about the symbolic link, not the target.
		/// </para>
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
		/// <term>No</term>
		/// </item>
		/// </list>
		/// <para>SMB 3.0 does not support TxF.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winbase/nf-winbase-findfirstfiletransacteda HANDLE FindFirstFileTransactedA(
		// LPCSTR lpFileName, FINDEX_INFO_LEVELS fInfoLevelId, LPVOID lpFindFileData, FINDEX_SEARCH_OPS fSearchOp, LPVOID lpSearchFilter,
		// DWORD dwAdditionalFlags, HANDLE hTransaction );
		[DllImport(Lib.Kernel32, SetLastError = true, CharSet = CharSet.Auto)]
		[PInvokeData("winbase.h", MSDNShortId = "d94bf32b-f14b-44b4-824b-ed453d0424ef")]
		public static extern IntPtr FindFirstFileTransacted(string lpFileName, FINDEX_INFO_LEVELS fInfoLevelId, out WIN32_FIND_DATA lpFindFileData, FINDEX_SEARCH_OPS fSearchOp, [Optional] IntPtr lpSearchFilter, FIND_FIRST dwAdditionalFlags, IntPtr hTransaction);

		/// <summary>
		/// <para>
		/// [Microsoft strongly recommends developers utilize alternative means to achieve your application’s needs. Many scenarios that TxF
		/// was developed for can be achieved through simpler and more readily available techniques. Furthermore, TxF may not be available in
		/// future versions of Microsoft Windows. For more information, and alternatives to TxF, please see Alternatives to using
		/// Transactional NTFS.]
		/// </para>
		/// <para>Enumerates the first stream in the specified file or directory as a transacted operation.</para>
		/// </summary>
		/// <param name="lpFileName">
		/// <para>The fully qualified file name.</para>
		/// <para>
		/// The file must reside on the local computer; otherwise, the function fails and the last error code is set to
		/// <c>ERROR_TRANSACTIONS_UNSUPPORTED_REMOTE</c> (6805).
		/// </para>
		/// </param>
		/// <param name="InfoLevel">
		/// <para>
		/// The information level of the returned data. This parameter is one of the values in the STREAM_INFO_LEVELS enumeration type.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>FindStreamInfoStandard 0</term>
		/// <term>The data is returned in a WIN32_FIND_STREAM_DATA structure.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="lpFindStreamData">
		/// <para>A pointer to a buffer that receives the file data. The format of this data depends on the value of the InfoLevel parameter.</para>
		/// </param>
		/// <param name="dwFlags">
		/// <para>Reserved for future use. This parameter must be zero.</para>
		/// </param>
		/// <param name="hTransaction">
		/// <para>A handle to the transaction. This handle is returned by the CreateTransaction function.</para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is a search handle that can be used in subsequent calls to the FindNextStreamWfunction.</para>
		/// <para>If the function fails, the return value is <c>INVALID_HANDLE_VALUE</c>. To get extended error information, call GetLastError.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// All files contain a default data stream. On NTFS, files can also contain one or more named data streams. On FAT file systems,
		/// files cannot have more that the default data stream, and therefore, this function will not return valid results when used on FAT
		/// filesystem files. This function works on all file systems that supports hard links; otherwise, the function returns
		/// <c>ERROR_STATUS_NOT_IMPLEMENTED</c> (6805).
		/// </para>
		/// <para>
		/// The <c>FindFirstStreamTransactedW</c> function opens a search handle and returns information about the first stream in the
		/// specified file or directory. For files, this is always the default data stream, ::$DATA. After the search handle has been
		/// established, use it in the FindNextStreamW function to search for other streams in the specified file or directory. When the
		/// search handle is no longer needed, it should be closed using the FindClosefunction.
		/// </para>
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
		/// <term>No</term>
		/// </item>
		/// </list>
		/// <para>SMB 3.0 does not support TxF.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winbase/nf-winbase-findfirststreamtransactedw HANDLE
		// FindFirstStreamTransactedW( LPCWSTR lpFileName, STREAM_INFO_LEVELS InfoLevel, LPVOID lpFindStreamData, DWORD dwFlags, HANDLE
		// hTransaction );
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true, CharSet = CharSet.Unicode)]
		[PInvokeData("winbase.h", MSDNShortId = "76c64aa9-0501-457d-b774-c209fbac4ccc")]
		public static extern IntPtr FindFirstStreamTransactedW(string lpFileName, STREAM_INFO_LEVELS InfoLevel, out WIN32_FIND_STREAM_DATA lpFindStreamData, [Optional] uint dwFlags, IntPtr hTransaction);

		/// <summary>
		/// <para>
		/// [Microsoft strongly recommends developers utilize alternative means to achieve your application’s needs. Many scenarios that TxF
		/// was developed for can be achieved through simpler and more readily available techniques. Furthermore, TxF may not be available in
		/// future versions of Microsoft Windows. For more information, and alternatives to TxF, please see Alternatives to using
		/// Transactional NTFS.]
		/// </para>
		/// <para>Retrieves file system attributes for a specified file or directory as a transacted operation.</para>
		/// </summary>
		/// <param name="lpFileName">
		/// <para>The name of the file or directory.</para>
		/// <para>
		/// In the ANSI version of this function, the name is limited to <c>MAX_PATH</c> characters. To extend this limit to 32,767 wide
		/// characters, call the Unicode version of the function and prepend "\?" to the path. For more information, see Naming a File.
		/// </para>
		/// <para>
		/// The file or directory must reside on the local computer; otherwise, the function fails and the last error code is set to <c>ERROR_TRANSACTIONS_UNSUPPORTED_REMOTE</c>.
		/// </para>
		/// </param>
		/// <param name="fInfoLevelId">
		/// <para>The level of attribute information to retrieve.</para>
		/// <para>This parameter can be the following value from the GET_FILEEX_INFO_LEVELS enumeration.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>GetFileExInfoStandard</term>
		/// <term>The lpFileInformation parameter is a WIN32_FILE_ATTRIBUTE_DATA structure.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="lpFileInformation">
		/// <para>A pointer to a buffer that receives the attribute information.</para>
		/// <para>
		/// The type of attribute information that is stored into this buffer is determined by the value of fInfoLevelId. If the fInfoLevelId
		/// parameter is <c>GetFileExInfoStandard</c> then this parameter points to a WIN32_FILE_ATTRIBUTE_DATA structure
		/// </para>
		/// </param>
		/// <param name="hTransaction">
		/// <para>A handle to the transaction. This handle is returned by the CreateTransaction function.</para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is nonzero.</para>
		/// <para>If the function fails, the return value is zero (0). To get extended error information, call GetLastError.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// When <c>GetFileAttributesTransacted</c> is called on a directory that is a mounted folder, it returns the attributes of the
		/// directory, not those of the root directory in the volume that the mounted folder associates with the directory. To obtain the
		/// file attributes of the associated volume, call GetVolumeNameForVolumeMountPoint to obtain the name of the associated volume. Then
		/// use the resulting name in a call to <c>GetFileAttributesTransacted</c>. The results are the attributes of the root directory on
		/// the associated volume.
		/// </para>
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
		/// <term>No</term>
		/// </item>
		/// </list>
		/// <para>SMB 3.0 does not support TxF.</para>
		/// <para><c>Symbolic links:</c> If the path points to a symbolic link, the function returns attributes for the symbolic link.</para>
		/// <para>Transacted Operations</para>
		/// <para>
		/// If a file is open for modification in a transaction, no other thread can open the file for modification until the transaction is
		/// committed. Conversely, if a file is open for modification outside of a transaction, no transacted thread can open the file for
		/// modification until the non-transacted handle is closed. If a non-transacted thread has a handle opened to modify a file, a call
		/// to <c>GetFileAttributesTransacted</c> for that file will fail with an <c>ERROR_TRANSACTIONAL_CONFLICT</c> error.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winbase/nf-winbase-getfileattributestransacteda BOOL
		// GetFileAttributesTransactedA( LPCSTR lpFileName, GET_FILEEX_INFO_LEVELS fInfoLevelId, LPVOID lpFileInformation, HANDLE
		// hTransaction );
		[DllImport(Lib.Kernel32, SetLastError = true, CharSet = CharSet.Auto)]
		[PInvokeData("winbase.h", MSDNShortId = "dd1435da-93e5-440a-913a-9e40e39b4a01")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool GetFileAttributesTransacted(string lpFileName, GET_FILEEX_INFO_LEVELS fInfoLevelId, ref WIN32_FILE_ATTRIBUTE_DATA lpFileInformation, IntPtr hTransaction);

		/// <summary>
		/// <para>
		/// [Microsoft strongly recommends developers utilize alternative means to achieve your application’s needs. Many scenarios that TxF
		/// was developed for can be achieved through simpler and more readily available techniques. Furthermore, TxF may not be available in
		/// future versions of Microsoft Windows. For more information, and alternatives to TxF, please see Alternatives to using
		/// Transactional NTFS.]
		/// </para>
		/// <para>Retrieves the full path and file name of the specified file as a transacted operation.</para>
		/// <para>To perform this operation without transactions, use the GetFullPathName function.</para>
		/// <para>For more information about file and path names, see File Names, Paths, and Namespaces.</para>
		/// </summary>
		/// <param name="lpFileName">
		/// <para>The name of the file.</para>
		/// <para>This string can use short (the 8.3 form) or long file names. This string can be a share or volume name.</para>
		/// <para>The file must reside on the local computer; otherwise, the function fails and the last error code is set to <c>ERROR_TRANSACTIONS_UNSUPPORTED_REMOTE</c>.</para>
		/// </param>
		/// <param name="nBufferLength">
		/// <para>The size of the buffer to receive the null-terminated string for the drive and path, in <c>TCHARs</c>.</para>
		/// </param>
		/// <param name="lpBuffer">
		/// <para>A pointer to a buffer that receives the null-terminated string for the drive and path.</para>
		/// </param>
		/// <param name="lpFilePart">
		/// <para>
		/// A pointer to a buffer that receives the address (in lpBuffer) of the final file name component in the path. Specify <c>NULL</c>
		/// if you do not need to receive this information.
		/// </para>
		/// <para>If lpBuffer points to a directory and not a file, lpFilePart receives 0 (zero).</para>
		/// </param>
		/// <param name="hTransaction">
		/// <para>A handle to the transaction. This handle is returned by the CreateTransaction function.</para>
		/// </param>
		/// <returns>
		/// <para>
		/// If the function succeeds, the return value is the length, in <c>TCHARs</c>, of the string copied to lpBuffer, not including the
		/// terminating null character.
		/// </para>
		/// <para>
		/// If the lpBuffer buffer is too small to contain the path, the return value is the size, in <c>TCHARs</c>, of the buffer that is
		/// required to hold the path and the terminating null character.
		/// </para>
		/// <para>If the function fails for any other reason, the return value is zero. To get extended error information, call GetLastError.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// <c>GetFullPathNameTransacted</c> merges the name of the current drive and directory with a specified file name to determine the
		/// full path and file name of a specified file. It also calculates the address of the file name portion of the full path and file
		/// name. This function does not verify that the resulting path and file name are valid, or that they see an existing file on the
		/// associated volume.
		/// </para>
		/// <para>
		/// Share and volume names are valid input for lpFileName. For example, the following list identities the returned path and file
		/// names if test-2 is a remote computer and U: is a network mapped drive:
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <term>If you specify "\\test-2\q$\lh" the path returned is "\\test-2\q$\lh"</term>
		/// </item>
		/// <item>
		/// <term>If you specify "\\?\UNC\test-2\q$\lh" the path returned is "\\?\UNC\test-2\q$\lh"</term>
		/// </item>
		/// <item>
		/// <term>If you specify "U:" the path returned is "U:\"</term>
		/// </item>
		/// </list>
		/// <para>
		/// <c>GetFullPathNameTransacted</c> does not convert the specified file name, lpFileName. If the specified file name exists, you can
		/// use GetLongPathNameTransacted, GetLongPathName, or GetShortPathName to convert to long or short path names, respectively.
		/// </para>
		/// <para>
		/// If the return value is greater than the value specified in nBufferLength, you can call the function again with a buffer that is
		/// large enough to hold the path. For an example of this case as well as using zero length buffer for dynamic allocation, see the
		/// Example Code section.
		/// </para>
		/// <para>
		/// <c>Note</c> Although the return value in this case is a length that includes the terminating null character, the return value on
		/// success does not include the terminating null character in the count.
		/// </para>
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
		/// <term>No</term>
		/// </item>
		/// </list>
		/// <para>SMB 3.0 does not support TxF.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winbase/nf-winbase-getfullpathnametransacteda DWORD
		// GetFullPathNameTransactedA( LPCSTR lpFileName, DWORD nBufferLength, LPSTR lpBuffer, LPSTR *lpFilePart, HANDLE hTransaction );
		[DllImport(Lib.Kernel32, SetLastError = true, CharSet = CharSet.Auto)]
		[PInvokeData("winbase.h", MSDNShortId = "63cbcec6-e9f0-4db3-bf2f-03a987000af1")]
		public static extern uint GetFullPathNameTransacted(string lpFileName, uint nBufferLength, StringBuilder lpBuffer, ref IntPtr lpFilePart, IntPtr hTransaction);

		/// <summary>
		/// <para>
		/// [Microsoft strongly recommends developers utilize alternative means to achieve your application’s needs. Many scenarios that TxF
		/// was developed for can be achieved through simpler and more readily available techniques. Furthermore, TxF may not be available in
		/// future versions of Microsoft Windows. For more information, and alternatives to TxF, please see Alternatives to using
		/// Transactional NTFS.]
		/// </para>
		/// <para>Converts the specified path to its long form as a transacted operation.</para>
		/// <para>To perform this operation without a transaction, use the GetLongPathName function.</para>
		/// <para>For more information about file and path names, see Naming Files, Paths, and Namespaces.</para>
		/// </summary>
		/// <param name="lpszShortPath">
		/// <para>The path to be converted.</para>
		/// <para>
		/// In the ANSI version of this function, the name is limited to <c>MAX_PATH</c> (260) characters. To extend this limit to 32,767
		/// wide characters, call the Unicode version of the function and prepend "\?" to the path. For more information, see Naming Files,
		/// Paths, and Namespaces.
		/// </para>
		/// <para>The path must reside on the local computer; otherwise, the function fails and the last error code is set to <c>ERROR_TRANSACTIONS_UNSUPPORTED_REMOTE</c>.</para>
		/// </param>
		/// <param name="lpszLongPath">
		/// <para>A pointer to the buffer to receive the long path.</para>
		/// <para>You can use the same buffer you used for the lpszShortPath parameter.</para>
		/// </param>
		/// <param name="cchBuffer">
		/// <para>The size of the buffer lpszLongPath points to, in <c>TCHAR</c> s.</para>
		/// </param>
		/// <param name="hTransaction">
		/// <para>A handle to the transaction. This handle is returned by the CreateTransaction function.</para>
		/// </param>
		/// <returns>
		/// <para>
		/// If the function succeeds, the return value is the length, in <c>TCHAR</c> s, of the string copied to lpszLongPath, not including
		/// the terminating null character.
		/// </para>
		/// <para>
		/// If the lpBuffer buffer is too small to contain the path, the return value is the size, in <c>TCHAR</c> s, of the buffer that is
		/// required to hold the path and the terminating null character.
		/// </para>
		/// <para>
		/// If the function fails for any other reason, such as if the file does not exist, the return value is zero. To get extended error
		/// information, call GetLastError.
		/// </para>
		/// </returns>
		/// <remarks>
		/// <para>On many file systems, a short file name contains a tilde () character.</para>
		/// <para>
		/// If a long path is not found, this function returns the name specified in the lpszShortPath parameter in the lpszLongPath parameter.
		/// </para>
		/// <para>
		/// If the return value is greater than the value specified in cchBuffer, you can call the function again with a buffer that is large
		/// enough to hold the path. For an example of this case, see the Example Code section for GetFullPathName.
		/// </para>
		/// <para>
		/// <c>Note</c> Although the return value in this case is a length that includes the terminating null character, the return value on
		/// success does not include the terminating null character in the count.
		/// </para>
		/// <para>
		/// It is possible to have access to a file or directory but not have access to some of the parent directories of that file or
		/// directory. As a result, <c>GetLongPathNameTransacted</c> may fail when it is unable to query the parent directory of a path
		/// component to determine the long name for that component. This check can be skipped for directory components that have file
		/// extensions longer than 3 characters, or total lengths longer than 12 characters. For more information, see the Short vs. Long
		/// Names section of Naming Files, Paths, and Namespaces.
		/// </para>
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
		/// <term>No</term>
		/// </item>
		/// </list>
		/// <para>SMB 3.0 does not support TxF.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winbase/nf-winbase-getlongpathnametransacteda DWORD
		// GetLongPathNameTransactedA( LPCSTR lpszShortPath, LPSTR lpszLongPath, DWORD cchBuffer, HANDLE hTransaction );
		[DllImport(Lib.Kernel32, SetLastError = true, CharSet = CharSet.Auto)]
		[PInvokeData("winbase.h", MSDNShortId = "8523cde9-f0dd-4832-8d9d-9e68bac89344")]
		public static extern uint GetLongPathNameTransacted(string lpszShortPath, StringBuilder lpszLongPath, uint cchBuffer, IntPtr hTransaction);

		/// <summary>
		/// <para>
		/// [Microsoft strongly recommends developers utilize alternative means to achieve your application’s needs. Many scenarios that TxF
		/// was developed for can be achieved through simpler and more readily available techniques. Furthermore, TxF may not be available in
		/// future versions of Microsoft Windows. For more information, and alternatives to TxF, please see Alternatives to using
		/// Transactional NTFS.]
		/// </para>
		/// <para>Moves an existing file or a directory, including its children, as a transacted operation.</para>
		/// </summary>
		/// <param name="lpExistingFileName">
		/// <para>The current name of the existing file or directory on the local computer.</para>
		/// <para>
		/// In the ANSI version of this function, the name is limited to <c>MAX_PATH</c> characters. To extend this limit to 32,767 wide
		/// characters, call the Unicode version of the function and prepend "\?" to the path. For more information, see Naming a File.
		/// </para>
		/// </param>
		/// <param name="lpNewFileName">
		/// <para>
		/// The new name for the file or directory. The new name must not already exist. A new file may be on a different file system or
		/// drive. A new directory must be on the same drive.
		/// </para>
		/// <para>
		/// In the ANSI version of this function, the name is limited to <c>MAX_PATH</c> characters. To extend this limit to 32,767 wide
		/// characters, call the Unicode version of the function and prepend "\?" to the path. For more information, see Naming a File.
		/// </para>
		/// </param>
		/// <param name="lpProgressRoutine">
		/// <para>
		/// A pointer to a CopyProgressRoutine callback function that is called each time another portion of the file has been moved. The
		/// callback function can be useful if you provide a user interface that displays the progress of the operation. This parameter can
		/// be <c>NULL</c>.
		/// </para>
		/// </param>
		/// <param name="lpData">
		/// <para>An argument to be passed to the CopyProgressRoutine callback function. This parameter can be <c>NULL</c>.</para>
		/// </param>
		/// <param name="dwFlags">
		/// <para>The move options. This parameter can be one or more of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>MOVEFILE_COPY_ALLOWED 2 (0x2)</term>
		/// <term>
		/// If the file is to be moved to a different volume, the function simulates the move by using the CopyFile and DeleteFile functions.
		/// If the file is successfully copied to a different volume and the original file is unable to be deleted, the function succeeds
		/// leaving the source file intact. This value cannot be used with MOVEFILE_DELAY_UNTIL_REBOOT.
		/// </term>
		/// </item>
		/// <item>
		/// <term>MOVEFILE_CREATE_HARDLINK 16 (0x10)</term>
		/// <term>Reserved for future use.</term>
		/// </item>
		/// <item>
		/// <term>MOVEFILE_DELAY_UNTIL_REBOOT 4 (0x4)</term>
		/// <term>
		/// The system does not move the file until the operating system is restarted. The system moves the file immediately after AUTOCHK is
		/// executed, but before creating any paging files. Consequently, this parameter enables the function to delete paging files from
		/// previous startups. This value can only be used if the process is in the context of a user who belongs to the administrators group
		/// or the LocalSystem account. This value cannot be used with MOVEFILE_COPY_ALLOWED. The write operation to the registry value as
		/// detailed in the Remarks section is what is transacted. The file move is finished when the computer restarts, after the
		/// transaction is complete.
		/// </term>
		/// </item>
		/// <item>
		/// <term>MOVEFILE_REPLACE_EXISTING 1 (0x1)</term>
		/// <term>
		/// If a file named lpNewFileName exists, the function replaces its contents with the contents of the lpExistingFileName file. This
		/// value cannot be used if lpNewFileName or lpExistingFileName names a directory.
		/// </term>
		/// </item>
		/// <item>
		/// <term>MOVEFILE_WRITE_THROUGH 8 (0x8)</term>
		/// <term>
		/// A call to MoveFileTransacted means that the move file operation is complete when the commit operation is completed. This flag is
		/// unnecessary; there are no negative affects if this flag is specified, other than an operation slowdown. The function does not
		/// return until the file has actually been moved on the disk. Setting this value guarantees that a move performed as a copy and
		/// delete operation is flushed to disk before the function returns. The flush occurs at the end of the copy operation. This value
		/// has no effect if MOVEFILE_DELAY_UNTIL_REBOOT is set.
		/// </term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="hTransaction">
		/// <para>A handle to the transaction. This handle is returned by the CreateTransaction function.</para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is nonzero.</para>
		/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
		/// <para>
		/// When moving a file across volumes, if lpProgressRoutine returns <c>PROGRESS_CANCEL</c> due to the user canceling the operation,
		/// <c>MoveFileTransacted</c> will return zero and GetLastError will return <c>ERROR_REQUEST_ABORTED</c>. The existing file is left intact.
		/// </para>
		/// <para>
		/// When moving a file across volumes, if lpProgressRoutine returns <c>PROGRESS_STOP</c> due to the user stopping the operation,
		/// <c>MoveFileTransacted</c> will return zero and GetLastError will return <c>ERROR_REQUEST_ABORTED</c>. The existing file is left intact.
		/// </para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// If the dwFlags parameter specifies <c>MOVEFILE_DELAY_UNTIL_REBOOT</c>, <c>MoveFileTransacted</c> fails if it cannot access the
		/// registry. The function transactionally stores the locations of the files to be renamed at restart in the following registry
		/// value: <c>HKEY_LOCAL_MACHINE</c>&lt;b&gt;SYSTEM&lt;b&gt;CurrentControlSet&lt;b&gt;Control&lt;b&gt;Session Manager&lt;b&gt;PendingFileRenameOperations
		/// </para>
		/// <para>
		/// This registry value is of type <c>REG_MULTI_SZ</c>. Each rename operation stores one of the following <c>NULL</c>-terminated
		/// strings, depending on whether the rename is a delete or not:
		/// </para>
		/// <para>szDstFile\0\0</para>
		/// <para>szSrcFile\0szDstFile\0</para>
		/// <para>The string szDstFile\0\0 indicates that the file szDstFile is to be deleted on reboot.</para>
		/// <para>The string szSrcFile\0szDstFile\0 indicates that szSrcFile is to be renamed szDstFile on reboot.</para>
		/// <para>
		/// <c>Note</c> Although \0\0 is technically not allowed in a <c>REG_MULTI_SZ</c> node, it can because the file is considered to be
		/// renamed to a null name.
		/// </para>
		/// <para>
		/// The system uses these registry entries to complete the operations at restart in the same order that they were issued. For more
		/// information about using the <c>MOVEFILE_DELAY_UNTIL_REBOOT</c> flag, see MoveFileWithProgress.
		/// </para>
		/// <para>
		/// If a file is moved across volumes, <c>MoveFileTransacted</c> does not move the security descriptor with the file. The file is
		/// assigned the default security descriptor in the destination directory.
		/// </para>
		/// <para>
		/// This function always fails if you specify the <c>MOVEFILE_FAIL_IF_NOT_TRACKABLE</c> flag; tracking is not supported by TxF.
		/// </para>
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
		/// <term>No</term>
		/// </item>
		/// </list>
		/// <para>SMB 3.0 does not support TxF.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winbase/nf-winbase-movefiletransacteda BOOL MoveFileTransactedA( LPCSTR
		// lpExistingFileName, LPCSTR lpNewFileName, LPPROGRESS_ROUTINE lpProgressRoutine, LPVOID lpData, DWORD dwFlags, HANDLE hTransaction );
		[DllImport(Lib.Kernel32, SetLastError = true, CharSet = CharSet.Auto)]
		[PInvokeData("winbase.h", MSDNShortId = "466d733b-30d2-4297-a0e6-77038f1a21d5")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool MoveFileTransacted(string lpExistingFileName, string lpNewFileName, CopyProgressRoutine lpProgressRoutine, IntPtr lpData, MOVEFILE dwFlags, IntPtr hTransaction);

		/// <summary>
		/// <para>
		/// [Microsoft strongly recommends developers utilize alternative means to achieve your application’s needs. Many scenarios that TxF
		/// was developed for can be achieved through simpler and more readily available techniques. Furthermore, TxF may not be available in
		/// future versions of Microsoft Windows. For more information, and alternatives to TxF, please see Alternatives to using
		/// Transactional NTFS.]
		/// </para>
		/// <para>Deletes an existing empty directory as a transacted operation.</para>
		/// </summary>
		/// <param name="lpPathName">
		/// <para>
		/// The path of the directory to be removed. The path must specify an empty directory, and the calling process must have delete
		/// access to the directory.
		/// </para>
		/// <para>
		/// In the ANSI version of this function, the name is limited to <c>MAX_PATH</c> characters. To extend this limit to 32,767 wide
		/// characters, call the Unicode version of the function and prepend "\?" to the path. For more information, see Naming a File.
		/// </para>
		/// <para>The directory must reside on the local computer; otherwise, the function fails and the last error code is set to <c>ERROR_TRANSACTIONS_UNSUPPORTED_REMOTE</c>.</para>
		/// </param>
		/// <param name="hTransaction">
		/// <para>A handle to the transaction. This handle is returned by the CreateTransaction function.</para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is nonzero.</para>
		/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The <c>RemoveDirectoryTransacted</c> function marks a directory for deletion on close. Therefore, the directory is not removed
		/// until the last handle to the directory is closed.
		/// </para>
		/// <para>
		/// RemoveDirectory removes a directory junction, even if the contents of the target are not empty; the function removes directory
		/// junctions regardless of the state of the target object.
		/// </para>
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
		/// <term>No</term>
		/// </item>
		/// </list>
		/// <para>SMB 3.0 does not support TxF .</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winbase/nf-winbase-removedirectorytransacteda BOOL
		// RemoveDirectoryTransactedA( LPCSTR lpPathName, HANDLE hTransaction );
		[DllImport(Lib.Kernel32, SetLastError = true, CharSet = CharSet.Auto)]
		[PInvokeData("winbase.h", MSDNShortId = "e8600166-62dc-4398-9e16-43b07f7f0b89")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool RemoveDirectoryTransacted(string lpPathName, IntPtr hTransaction);

		/// <summary>
		/// <para>
		/// [Microsoft strongly recommends developers utilize alternative means to achieve your application’s needs. Many scenarios that TxF
		/// was developed for can be achieved through simpler and more readily available techniques. Furthermore, TxF may not be available in
		/// future versions of Microsoft Windows. For more information, and alternatives to TxF, please see Alternatives to using
		/// Transactional NTFS.]
		/// </para>
		/// <para>Sets the attributes for a file or directory as a transacted operation.</para>
		/// </summary>
		/// <param name="lpFileName">
		/// <para>The name of the file whose attributes are to be set.</para>
		/// <para>
		/// In the ANSI version of this function, the name is limited to <c>MAX_PATH</c> characters. To extend this limit to 32,767 wide
		/// characters, call the Unicode version of the function and prepend "\?" to the path. For more information, see File Names, Paths,
		/// and Namespaces.
		/// </para>
		/// <para>The file must reside on the local computer; otherwise, the function fails and the last error code is set to <c>ERROR_TRANSACTIONS_UNSUPPORTED_REMOTE</c>.</para>
		/// </param>
		/// <param name="dwFileAttributes">
		/// <para>The file attributes to set for the file.</para>
		/// <para>
		/// For a list of file attribute value and their descriptions, see File Attribute Constants. This parameter can be one or more
		/// values, combined using the bitwise-OR operator. However, all other values override <c>FILE_ATTRIBUTE_NORMAL</c>.
		/// </para>
		/// <para>Not all attributes are supported by this function. For more information, see the Remarks section.</para>
		/// <para>The following is a list of supported attribute values.</para>
		/// <para>FILE_ATTRIBUTE_ARCHIVE (32 (0x20))</para>
		/// <para>FILE_ATTRIBUTE_HIDDEN (2 (0x2))</para>
		/// <para>FILE_ATTRIBUTE_NORMAL (128 (0x80))</para>
		/// <para>FILE_ATTRIBUTE_NOT_CONTENT_INDEXED (8192 (0x2000))</para>
		/// <para>FILE_ATTRIBUTE_OFFLINE (4096 (0x1000))</para>
		/// <para>FILE_ATTRIBUTE_READONLY (1 (0x1))</para>
		/// <para>FILE_ATTRIBUTE_SYSTEM (4 (0x4))</para>
		/// <para>FILE_ATTRIBUTE_TEMPORARY (256 (0x100))</para>
		/// </param>
		/// <param name="hTransaction">
		/// <para>A handle to the transaction. This handle is returned by the CreateTransaction function.</para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is nonzero.</para>
		/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The following table describes how to set the attributes that cannot be set using <c>SetFileAttributesTransacted</c>. Note that
		/// these are not transacted operations.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Attribute</term>
		/// <term>How to Set</term>
		/// </listheader>
		/// <item>
		/// <term>FILE_ATTRIBUTE_COMPRESSED 0x800</term>
		/// <term>To set a file's compression state, use the DeviceIoControl function with the FSCTL_SET_COMPRESSION operation.</term>
		/// </item>
		/// <item>
		/// <term>FILE_ATTRIBUTE_DEVICE 0x40</term>
		/// <term>Reserved; do not use.</term>
		/// </item>
		/// <item>
		/// <term>FILE_ATTRIBUTE_DIRECTORY 0x10</term>
		/// <term>Files cannot be converted into directories. To create a directory, use the CreateDirectory or CreateDirectoryEx function.</term>
		/// </item>
		/// <item>
		/// <term>FILE_ATTRIBUTE_ENCRYPTED 0x4000</term>
		/// <term>
		/// To create an encrypted file, use the CreateFile function with the FILE_ATTRIBUTE_ENCRYPTED attribute. To convert an existing file
		/// into an encrypted file, use the EncryptFile function.
		/// </term>
		/// </item>
		/// <item>
		/// <term>FILE_ATTRIBUTE_REPARSE_POINT 0x400</term>
		/// <term>
		/// To associate a reparse point with a file or directory, use the DeviceIoControl function with the FSCTL_SET_REPARSE_POINT operation.
		/// </term>
		/// </item>
		/// <item>
		/// <term>FILE_ATTRIBUTE_SPARSE_FILE 0x200</term>
		/// <term>To set a file's sparse attribute, use the DeviceIoControl function with the FSCTL_SET_SPARSE operation.</term>
		/// </item>
		/// </list>
		/// <para>
		/// If a file is open for modification in a transaction, no other thread can successfully open the file for modification until the
		/// transaction is committed. If a transacted thread opens the file first, any subsequent threads that attempt to open the file for
		/// modification before the transaction is committed will receive a sharing violation. If a non-transacted thread opens the file for
		/// modification before the transacted thread does, and it is still open when the transacted thread attempts to open it, the
		/// transaction will receive the <c>ERROR_TRANSACTIONAL_CONFLICT</c> error.
		/// </para>
		/// <para>For more information on transactions, see Transactional NTFS.</para>
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
		/// <term>No</term>
		/// </item>
		/// </list>
		/// <para>SMB 3.0 does not support TxF.</para>
		/// <para>Transacted Operations</para>
		/// <para>
		/// If a file is open for modification in a transaction, no other thread can open the file for modification until the transaction is
		/// committed. So if a transacted thread opens the file first, any subsequent threads that try modifying the file before the
		/// transaction is committed receives a sharing violation. If a non-transacted thread modifies the file before the transacted thread
		/// does, and the file is still open when the transaction attempts to open it, the transaction receives the error <c>ERROR_TRANSACTIONAL_CONFLICT</c>.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winbase/nf-winbase-setfileattributestransacteda BOOL
		// SetFileAttributesTransactedA( LPCSTR lpFileName, DWORD dwFileAttributes, HANDLE hTransaction );
		[DllImport(Lib.Kernel32, SetLastError = true, CharSet = CharSet.Auto)]
		[PInvokeData("winbase.h", MSDNShortId = "e25e77b2-a6ad-4ce4-8589-d7ff6c4074f6")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool SetFileAttributesTransacted(string lpFileName, FileFlagsAndAttributes dwFileAttributes, IntPtr hTransaction);
	}
}