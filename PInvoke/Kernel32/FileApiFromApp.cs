using System.IO;

namespace Vanara.PInvoke;

public static partial class Kernel32
{
	/// <summary>
	/// Copies an existing file to a new file. The behavior of this function is identical to <c>CopyFile</c>, except that this function
	/// adheres to the Universal Windows Platform app security model.
	/// </summary>
	/// <param name="lpExistingFileName">
	/// <para>The name of an existing file.</para>
	/// <para>
	/// For information about opting out of the <c>MAX_PATH</c> limitation without prepending "\\?\", see the "Maximum Path Length
	/// Limitation" section of Naming Files, Paths, and Namespaces for details.
	/// </para>
	/// <para>If lpExistingFileName does not exist, the function fails, and <c>GetLastError</c> returns <c>ERROR_FILE_NOT_FOUND</c>.</para>
	/// </param>
	/// <param name="lpNewFileName">
	/// <para>The name of the new file.</para>
	/// <para>
	/// In the ANSI version of this function, the name is limited to <c>MAX_PATH</c> characters. To extend this limit to 32,767 wide
	/// characters, call the Unicode version of the function and prepend "\\?\" to the path. For more information, see Naming a File.
	/// </para>
	/// <para>
	/// For the unicode version of this function ( <c>CopyFileFromAppW</c>), you can opt-in to remove the <c>MAX_PATH</c> limitation
	/// without prepending "\\?\". See the "Maximum Path Length Limitation" section of Naming Files, Paths, and Namespaces for details.
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
	// https://docs.microsoft.com/en-us/windows/win32/api/fileapifromapp/nf-fileapifromapp-copyfilefromappw WINSTORAGEAPI BOOL noexcept
	// CopyFileFromAppW( LPCWSTR lpExistingFileName, LPCWSTR lpNewFileName, BOOL bFailIfExists );
	[DllImport(Lib.KernelBase, SetLastError = true, ExactSpelling = true, CharSet = CharSet.Unicode)]
	[PInvokeData("fileapifromapp.h", MSDNShortId = "NF:fileapifromapp.CopyFileFromAppW", MinClient = PInvokeClient.Windows10)]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool CopyFileFromAppW(string lpExistingFileName, string lpNewFileName, [MarshalAs(UnmanagedType.Bool)] bool bFailIfExists);

	/// <summary>
	/// Creates a new directory. The behavior of this function is identical to <c>CreateDirectory</c>, except that this function adheres
	/// to the Universal Windows Platform app security model.
	/// </summary>
	/// <param name="lpPathName">
	/// <para>The path of the directory to be created.</para>
	/// <para>
	/// For information about opting out of the <c>MAX_PATH</c> limitation without prepending "\\?\", see the "Maximum Path Length
	/// Limitation" section of Naming Files, Paths, and Namespaces for details.
	/// </para>
	/// </param>
	/// <param name="lpSecurityAttributes">
	/// <para>
	/// A pointer to a <c>SECURITY_ATTRIBUTES</c> structure. The <c>lpSecurityDescriptor</c> member of the structure specifies a
	/// security descriptor for the new directory. If lpSecurityAttributes is <c>NULL</c>, the directory gets a default security
	/// descriptor. The ACLs in the default security descriptor for a directory are inherited from its parent directory.
	/// </para>
	/// <para>The target file system must support security on files and directories for this parameter to have an effect.</para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>
	/// If the function fails, the return value is zero. To get extended error information, call <c>GetLastError</c>. Possible errors
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
	/// <term>ERROR_PATH_NOT_FOUND</term>
	/// <term>One or more intermediate directories do not exist; this function will only create the final directory in the path.</term>
	/// </item>
	/// </list>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/fileapifromapp/nf-fileapifromapp-createdirectoryfromappw WINSTORAGEAPI BOOL
	// noexcept CreateDirectoryFromAppW( LPCWSTR lpPathName, LPSECURITY_ATTRIBUTES lpSecurityAttributes );
	[DllImport(Lib.KernelBase, SetLastError = true, ExactSpelling = true, CharSet = CharSet.Unicode)]
	[PInvokeData("fileapifromapp.h", MSDNShortId = "NF:fileapifromapp.CreateDirectoryFromAppW", MinClient = PInvokeClient.Windows10)]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool CreateDirectoryFromAppW(string lpPathName, [In, Optional] SECURITY_ATTRIBUTES? lpSecurityAttributes);

	/// <summary>
	/// Creates or opens a file or I/O device. The behavior of this function is identical to <c>CreateFile2</c>, except that this
	/// function adheres to the Universal Windows Platform app security model.
	/// </summary>
	/// <param name="lpFileName">
	/// <para>The name of the file or device to be created or opened.</para>
	/// <para>For information on special device names, see Defining an MS-DOS Device Name.</para>
	/// <para>
	/// To create a file stream, specify the name of the file, a colon, and then the name of the stream. For more information, see File Streams.
	/// </para>
	/// <para>
	/// For information about opting out of the <c>MAX_PATH</c> limitation without prepending "\\?\", see the "Maximum Path Length
	/// Limitation" section of Naming Files, Paths, and Namespaces for details.
	/// </para>
	/// </param>
	/// <param name="dwDesiredAccess">
	/// <para>The requested access to the file or device, which can be summarized as read, write, both or neither zero).</para>
	/// <para>The most commonly used values are <c>GENERIC_READ</c>, <c>GENERIC_WRITE</c>, or both (
	/// <code>GENERIC_READ | GENERIC_WRITE</code>
	/// ). For more information, see Generic Access Rights, File Security and Access Rights, <c>File Access Rights Constants</c>, and <c>ACCESS_MASK</c>.
	/// </para>
	/// <para>
	/// If this parameter is zero, the application can query certain metadata such as file, directory, or device attributes without
	/// accessing that file or device, even if <c>GENERIC_READ</c> access would have been denied.
	/// </para>
	/// <para>
	/// You cannot request an access mode that conflicts with the sharing mode that is specified by the dwShareMode parameter in an open
	/// request that already has an open handle.
	/// </para>
	/// </param>
	/// <param name="dwShareMode">
	/// <para>
	/// The requested sharing mode of the file or device, which can be read, write, both, delete, all of these, or none (refer to the
	/// following table). Access requests to attributes or extended attributes are not affected by this flag.
	/// </para>
	/// <para>
	/// If this parameter is zero and the function succeeds, the file or device cannot be shared and cannot be opened again until the
	/// handle to the file or device is closed. For more information, see the Remarks section.
	/// </para>
	/// <para>
	/// You can't request a sharing mode that conflicts with the access mode that is specified in an existing request that has an open
	/// handle. This function would fail and the <c>GetLastError</c> function would return <c>ERROR_SHARING_VIOLATION</c>.
	/// </para>
	/// <para>
	/// To enable a process to share a file or device while another process has the file or device open, use a compatible combination of
	/// one or more of the following values. For more information about valid combinations of this parameter with the dwDesiredAccess
	/// parameter, see Creating and Opening Files.
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
	/// <term>
	/// Prevents other processes from opening a file or device if they request delete, read, or write access. Exclusive access to a file
	/// or directory is only granted if the application has write access to the file.
	/// </term>
	/// </item>
	/// <item>
	/// <term>FILE_SHARE_DELETE 0x00000004</term>
	/// <term>
	/// Enables subsequent open operations on a file or device to request delete access. Otherwise, other processes cannot open the file
	/// or device if they request delete access. If this flag is not specified, but the file or device has been opened for delete
	/// access, the function fails. Note Delete access allows both delete and rename operations.
	/// </term>
	/// </item>
	/// <item>
	/// <term>FILE_SHARE_READ 0x00000001</term>
	/// <term>
	/// Enables subsequent open operations on a file or device to request read access. Otherwise, other processes cannot open the file
	/// or device if they request read access. If this flag is not specified, but the file or device has been opened for read access,
	/// the function fails. If a file or directory is being opened and this flag is not specified, and the caller does not have write
	/// access to the file or directory, the function fails.
	/// </term>
	/// </item>
	/// <item>
	/// <term>FILE_SHARE_WRITE 0x00000002</term>
	/// <term>
	/// Enables subsequent open operations on a file or device to request write access. Otherwise, other processes cannot open the file
	/// or device if they request write access. If this flag is not specified, but the file or device has been opened for write access
	/// or has a file mapping with write access, the function fails.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="dwCreationDisposition">
	/// <para>An action to take on a file or device that exists or does not exist.</para>
	/// <para>For devices other than files, this parameter is usually set to <c>OPEN_EXISTING</c>.</para>
	/// <para>This parameter must be one of the following values, which cannot be combined:</para>
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
	/// new file is created, the function succeeds, and the last-error code is set to zero.
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
	/// Opens a file or device, only if it exists. If the specified file or device does not exist, the function fails and the last-error
	/// code is set to ERROR_FILE_NOT_FOUND (2).
	/// </term>
	/// </item>
	/// <item>
	/// <term>TRUNCATE_EXISTING 5</term>
	/// <term>
	/// Opens a file and truncates it so that its size is zero bytes, only if it exists. If the specified file does not exist, the
	/// function fails and the last-error code is set to ERROR_FILE_NOT_FOUND (2). The calling process must open the file with the
	/// GENERIC_WRITE bit set as part of the dwDesiredAccess parameter.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="pCreateExParams">Pointer to an optional <c>CREATEFILE2_EXTENDED_PARAMETERS</c> structure.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is an open handle to the specified file, device, named pipe, or mail slot.</para>
	/// <para>If the function fails, the return value is <c>INVALID_HANDLE_VALUE</c>. To get extended error information, call <c>GetLastError</c>.</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/fileapifromapp/nf-fileapifromapp-createfile2fromappw WINSTORAGEAPI HANDLE
	// noexcept CreateFile2FromAppW( LPCWSTR lpFileName, DWORD dwDesiredAccess, DWORD dwShareMode, DWORD dwCreationDisposition,
	// LPCREATEFILE2_EXTENDED_PARAMETERS pCreateExParams );
	[DllImport(Lib.KernelBase, SetLastError = true, ExactSpelling = true, CharSet = CharSet.Unicode)]
	[PInvokeData("fileapifromapp.h", MSDNShortId = "NF:fileapifromapp.CreateFile2FromAppW", MinClient = PInvokeClient.Windows10)]
	public static extern SafeHFILE CreateFile2FromAppW(string lpFileName, FileAccess dwDesiredAccess, FileShare dwShareMode,
		FileMode dwCreationDisposition, in CREATEFILE2_EXTENDED_PARAMETERS pCreateExParams);

	/// <summary>
	/// Creates or opens a file or I/O device. The behavior of this function is identical to <c>CreateFile2</c>, except that this
	/// function adheres to the Universal Windows Platform app security model.
	/// </summary>
	/// <param name="lpFileName">
	/// <para>The name of the file or device to be created or opened.</para>
	/// <para>For information on special device names, see Defining an MS-DOS Device Name.</para>
	/// <para>
	/// To create a file stream, specify the name of the file, a colon, and then the name of the stream. For more information, see File Streams.
	/// </para>
	/// <para>
	/// For information about opting out of the <c>MAX_PATH</c> limitation without prepending "\\?\", see the "Maximum Path Length
	/// Limitation" section of Naming Files, Paths, and Namespaces for details.
	/// </para>
	/// </param>
	/// <param name="dwDesiredAccess">
	/// <para>The requested access to the file or device, which can be summarized as read, write, both or neither zero).</para>
	/// <para>The most commonly used values are <c>GENERIC_READ</c>, <c>GENERIC_WRITE</c>, or both (
	/// <code>GENERIC_READ | GENERIC_WRITE</code>
	/// ). For more information, see Generic Access Rights, File Security and Access Rights, <c>File Access Rights Constants</c>, and <c>ACCESS_MASK</c>.
	/// </para>
	/// <para>
	/// If this parameter is zero, the application can query certain metadata such as file, directory, or device attributes without
	/// accessing that file or device, even if <c>GENERIC_READ</c> access would have been denied.
	/// </para>
	/// <para>
	/// You cannot request an access mode that conflicts with the sharing mode that is specified by the dwShareMode parameter in an open
	/// request that already has an open handle.
	/// </para>
	/// </param>
	/// <param name="dwShareMode">
	/// <para>
	/// The requested sharing mode of the file or device, which can be read, write, both, delete, all of these, or none (refer to the
	/// following table). Access requests to attributes or extended attributes are not affected by this flag.
	/// </para>
	/// <para>
	/// If this parameter is zero and the function succeeds, the file or device cannot be shared and cannot be opened again until the
	/// handle to the file or device is closed. For more information, see the Remarks section.
	/// </para>
	/// <para>
	/// You can't request a sharing mode that conflicts with the access mode that is specified in an existing request that has an open
	/// handle. This function would fail and the <c>GetLastError</c> function would return <c>ERROR_SHARING_VIOLATION</c>.
	/// </para>
	/// <para>
	/// To enable a process to share a file or device while another process has the file or device open, use a compatible combination of
	/// one or more of the following values. For more information about valid combinations of this parameter with the dwDesiredAccess
	/// parameter, see Creating and Opening Files.
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
	/// <term>
	/// Prevents other processes from opening a file or device if they request delete, read, or write access. Exclusive access to a file
	/// or directory is only granted if the application has write access to the file.
	/// </term>
	/// </item>
	/// <item>
	/// <term>FILE_SHARE_DELETE 0x00000004</term>
	/// <term>
	/// Enables subsequent open operations on a file or device to request delete access. Otherwise, other processes cannot open the file
	/// or device if they request delete access. If this flag is not specified, but the file or device has been opened for delete
	/// access, the function fails. Note Delete access allows both delete and rename operations.
	/// </term>
	/// </item>
	/// <item>
	/// <term>FILE_SHARE_READ 0x00000001</term>
	/// <term>
	/// Enables subsequent open operations on a file or device to request read access. Otherwise, other processes cannot open the file
	/// or device if they request read access. If this flag is not specified, but the file or device has been opened for read access,
	/// the function fails. If a file or directory is being opened and this flag is not specified, and the caller does not have write
	/// access to the file or directory, the function fails.
	/// </term>
	/// </item>
	/// <item>
	/// <term>FILE_SHARE_WRITE 0x00000002</term>
	/// <term>
	/// Enables subsequent open operations on a file or device to request write access. Otherwise, other processes cannot open the file
	/// or device if they request write access. If this flag is not specified, but the file or device has been opened for write access
	/// or has a file mapping with write access, the function fails.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="dwCreationDisposition">
	/// <para>An action to take on a file or device that exists or does not exist.</para>
	/// <para>For devices other than files, this parameter is usually set to <c>OPEN_EXISTING</c>.</para>
	/// <para>This parameter must be one of the following values, which cannot be combined:</para>
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
	/// new file is created, the function succeeds, and the last-error code is set to zero.
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
	/// Opens a file or device, only if it exists. If the specified file or device does not exist, the function fails and the last-error
	/// code is set to ERROR_FILE_NOT_FOUND (2).
	/// </term>
	/// </item>
	/// <item>
	/// <term>TRUNCATE_EXISTING 5</term>
	/// <term>
	/// Opens a file and truncates it so that its size is zero bytes, only if it exists. If the specified file does not exist, the
	/// function fails and the last-error code is set to ERROR_FILE_NOT_FOUND (2). The calling process must open the file with the
	/// GENERIC_WRITE bit set as part of the dwDesiredAccess parameter.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="pCreateExParams">Pointer to an optional <c>CREATEFILE2_EXTENDED_PARAMETERS</c> structure.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is an open handle to the specified file, device, named pipe, or mail slot.</para>
	/// <para>If the function fails, the return value is <c>INVALID_HANDLE_VALUE</c>. To get extended error information, call <c>GetLastError</c>.</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/fileapifromapp/nf-fileapifromapp-createfile2fromappw WINSTORAGEAPI HANDLE
	// noexcept CreateFile2FromAppW( LPCWSTR lpFileName, DWORD dwDesiredAccess, DWORD dwShareMode, DWORD dwCreationDisposition,
	// LPCREATEFILE2_EXTENDED_PARAMETERS pCreateExParams );
	[DllImport(Lib.KernelBase, SetLastError = true, ExactSpelling = true, CharSet = CharSet.Unicode)]
	[PInvokeData("fileapifromapp.h", MSDNShortId = "NF:fileapifromapp.CreateFile2FromAppW", MinClient = PInvokeClient.Windows10)]
	public static extern SafeHFILE CreateFile2FromAppW(string lpFileName, FileAccess dwDesiredAccess, FileShare dwShareMode,
		FileMode dwCreationDisposition, [In, Optional] IntPtr pCreateExParams);

	/// <summary>
	/// Creates or opens a file or I/O device. The behavior of this function is identical to <c>CreateFile</c>, except that this
	/// function adheres to the Universal Windows Platform app security model.
	/// </summary>
	/// <param name="lpFileName">
	/// <para>
	/// The name of the file or device to be created or opened. You may use either forward slashes (/) or backslashes (\) in this name.
	/// </para>
	/// <para>
	/// In the ANSI version of this function, the name is limited to <c>MAX_PATH</c> characters. To extend this limit to 32,767 wide
	/// characters, call the Unicode version of the function and prepend "\\?\" to the path. For more information, see Naming Files,
	/// Paths, and Namespaces.
	/// </para>
	/// <para>For information on special device names, see Defining an MS-DOS Device Name.</para>
	/// <para>
	/// To create a file stream, specify the name of the file, a colon, and then the name of the stream. For more information, see File Streams.
	/// </para>
	/// <para>
	/// For the unicode version of this function ( <c>CreateFileFromAppW</c>), you can opt-in to remove the <c>MAX_PATH</c> limitation
	/// without prepending "\\?\". See the "Maximum Path Length Limitation" section of Naming Files, Paths, and Namespaces for details.
	/// </para>
	/// </param>
	/// <param name="dwDesiredAccess">
	/// <para>The requested access to the file or device, which can be summarized as read, write, both or neither zero).</para>
	/// <para>The most commonly used values are <c>GENERIC_READ</c>, <c>GENERIC_WRITE</c>, or both (
	/// <code>GENERIC_READ | GENERIC_WRITE</code>
	/// ). For more information, see Generic Access Rights, File Security and Access Rights, <c>File Access Rights Constants</c>, and <c>ACCESS_MASK</c>.
	/// </para>
	/// <para>
	/// If this parameter is zero, the application can query certain metadata such as file, directory, or device attributes without
	/// accessing that file or device, even if <c>GENERIC_READ</c> access would have been denied.
	/// </para>
	/// <para>
	/// You cannot request an access mode that conflicts with the sharing mode that is specified by the dwShareMode parameter in an open
	/// request that already has an open handle.
	/// </para>
	/// </param>
	/// <param name="dwShareMode">
	/// <para>
	/// The requested sharing mode of the file or device, which can be read, write, both, delete, all of these, or none (refer to the
	/// following table). Access requests to attributes or extended attributes are not affected by this flag.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>0 0x00000000</term>
	/// <term>Prevents other processes from opening a file or device if they request delete, read, or write access.</term>
	/// </item>
	/// <item>
	/// <term>FILE_SHARE_DELETE 0x00000004</term>
	/// <term>
	/// Enables subsequent open operations on a file or device to request delete access. Otherwise, other processes cannot open the file
	/// or device if they request delete access. If this flag is not specified, but the file or device has been opened for delete
	/// access, the function fails. Note Delete access allows both delete and rename operations.
	/// </term>
	/// </item>
	/// <item>
	/// <term>FILE_SHARE_READ 0x00000001</term>
	/// <term>
	/// Enables subsequent open operations on a file or device to request read access. Otherwise, other processes cannot open the file
	/// or device if they request read access. If this flag is not specified, but the file or device has been opened for read access,
	/// the function fails.
	/// </term>
	/// </item>
	/// <item>
	/// <term>FILE_SHARE_WRITE 0x00000002</term>
	/// <term>
	/// Enables subsequent open operations on a file or device to request write access. Otherwise, other processes cannot open the file
	/// or device if they request write access. If this flag is not specified, but the file or device has been opened for write access
	/// or has a file mapping with write access, the function fails.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="lpSecurityAttributes">
	/// <para>
	/// A pointer to a <c>SECURITY_ATTRIBUTES</c> structure that contains two separate but related data members: an optional security
	/// descriptor, and a Boolean value that determines whether the returned handle can be inherited by child processes.
	/// </para>
	/// <para>This parameter can be <c>NULL</c>.</para>
	/// <para>
	/// If this parameter is <c>NULL</c>, the handle returned cannot be inherited by any child processes the application may create and
	/// the file or device associated with the returned handle gets a default security descriptor.
	/// </para>
	/// <para>
	/// The <c>lpSecurityDescriptor</c> member of the structure specifies a <c>SECURITY_DESCRIPTOR</c> for a file or device. If this
	/// member is <c>NULL</c>, the file or device associated with the returned handle is assigned a default security descriptor.
	/// </para>
	/// <para>
	/// This function ignores the <c>lpSecurityDescriptor</c> member when opening an existing file or device, but continues to use the
	/// <c>bInheritHandle</c> member.
	/// </para>
	/// <para>The <c>bInheritHandle</c> member of the structure specifies whether the returned handle can be inherited.</para>
	/// </param>
	/// <param name="dwCreationDisposition">
	/// <para>An action to take on a file or device that exists or does not exist.</para>
	/// <para>For devices other than files, this parameter is usually set to <c>OPEN_EXISTING</c>.</para>
	/// <para>For more information, see the Remarks section.</para>
	/// <para>This parameter must be one of the following values, which cannot be combined:</para>
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
	/// new file is created, the function succeeds, and the last-error code is set to zero. For more information, see the Remarks
	/// section of this topic.
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
	/// Opens a file or device, only if it exists. If the specified file or device does not exist, the function fails and the last-error
	/// code is set to ERROR_FILE_NOT_FOUND (2). For more information about devices, see the Remarks section.
	/// </term>
	/// </item>
	/// <item>
	/// <term>TRUNCATE_EXISTING 5</term>
	/// <term>
	/// Opens a file and truncates it so that its size is zero bytes, only if it exists. If the specified file does not exist, the
	/// function fails and the last-error code is set to ERROR_FILE_NOT_FOUND (2). The calling process must open the file with the
	/// GENERIC_WRITE bit set as part of the dwDesiredAccess parameter.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="dwFlagsAndAttributes">
	/// <para>The file or device attributes and flags, <c>FILE_ATTRIBUTE_NORMAL</c> being the most common default value for files.</para>
	/// <para>
	/// This parameter can include any combination of the available file attributes ( <c>FILE_ATTRIBUTE_*</c>). All other file
	/// attributes override <c>FILE_ATTRIBUTE_NORMAL</c>.
	/// </para>
	/// <para>
	/// This parameter can also contain combinations of flags ( <c>FILE_FLAG_*</c>) for control of file or device caching behavior,
	/// access modes, and other special-purpose flags. These combine with any <c>FILE_ATTRIBUTE_*</c> values.
	/// </para>
	/// <para>
	/// This parameter can also contain Security Quality of Service (SQOS) information by specifying the <c>SECURITY_SQOS_PRESENT</c>
	/// flag. Additional SQOS-related flags information is presented in the table following the attributes and flags tables.
	/// </para>
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
	/// has no effect if FILE_ATTRIBUTE_SYSTEM is also specified. This flag is not supported on Home, Home Premium, Starter, or ARM
	/// editions of Windows.
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
	/// <term>The file is being used for temporary storage. For more information, see the Caching Behavior section of this topic.</term>
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
	/// The file is being opened or created for a backup or restore operation. The system ensures that the calling process overrides
	/// file security checks when the process has SE_BACKUP_NAME and SE_RESTORE_NAME privileges. For more information, see Changing
	/// Privileges in a Token. You must set this flag to obtain a handle to a directory. A directory handle can be passed to some
	/// functions instead of a file handle. For more information, see the Remarks section.
	/// </term>
	/// </item>
	/// <item>
	/// <term>FILE_FLAG_DELETE_ON_CLOSE 0x04000000</term>
	/// <term>
	/// The file is to be deleted immediately after all of its handles are closed, which includes the specified handle and any other
	/// open or duplicated handles. If there are existing open handles to a file, the call fails unless they were all opened with the
	/// FILE_SHARE_DELETE share mode. Subsequent open requests for the file fail, unless the FILE_SHARE_DELETE share mode is specified.
	/// </term>
	/// </item>
	/// <item>
	/// <term>FILE_FLAG_NO_BUFFERING 0x20000000</term>
	/// <term>
	/// The file or device is being opened with no system caching for data reads and writes. This flag does not affect hard disk caching
	/// or memory mapped files. There are strict requirements for successfully working with files opened with this function using the
	/// FILE_FLAG_NO_BUFFERING flag, for details see File Buffering.
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
	/// Normal reparse point processing will not occur; this function will attempt to open the reparse point. When a file is opened, a
	/// file handle is returned, whether or not the filter that controls the reparse point is operational. This flag cannot be used with
	/// the CREATE_ALWAYS flag. If the file is not a reparse point, then this flag is ignored. For more information, see the Remarks section.
	/// </term>
	/// </item>
	/// <item>
	/// <term>FILE_FLAG_OVERLAPPED 0x40000000</term>
	/// <term>
	/// The file or device is being opened or created for asynchronous I/O. When subsequent I/O operations are completed on this handle,
	/// the event specified in the OVERLAPPED structure will be set to the signaled state. If this flag is specified, the file can be
	/// used for simultaneous read and write operations. If this flag is not specified, then I/O operations are serialized, even if the
	/// calls to the read and write functions specify an OVERLAPPED structure. For information about considerations when using a file
	/// handle created with this flag, see the Synchronous and Asynchronous I/O Handles section of this topic.
	/// </term>
	/// </item>
	/// <item>
	/// <term>FILE_FLAG_POSIX_SEMANTICS 0x0100000</term>
	/// <term>
	/// Access will occur according to POSIX rules. This includes allowing multiple files with names, differing only in case, for file
	/// systems that support that naming. Use care when using this option, because files created with this flag may not be accessible by
	/// applications that are written for MS-DOS or 16-bit Windows.
	/// </term>
	/// </item>
	/// <item>
	/// <term>FILE_FLAG_RANDOM_ACCESS 0x10000000</term>
	/// <term>
	/// Access is intended to be random. The system can use this as a hint to optimize file caching. This flag has no effect if the file
	/// system does not support cached I/O and FILE_FLAG_NO_BUFFERING. For more information, see the Caching Behavior section of this topic.
	/// </term>
	/// </item>
	/// <item>
	/// <term>FILE_FLAG_SESSION_AWARE 0x00800000</term>
	/// <term>
	/// The file or device is being opened with session awareness. If this flag is not specified, then per-session devices (such as a
	/// device using RemoteFX USB Redirection) cannot be opened by processes running in session 0. This flag has no effect for callers
	/// not in session 0. This flag is supported only on server editions of Windows.
	/// </term>
	/// </item>
	/// <item>
	/// <term>FILE_FLAG_SEQUENTIAL_SCAN 0x08000000</term>
	/// <term>
	/// Access is intended to be sequential from beginning to end. The system can use this as a hint to optimize file caching. This flag
	/// should not be used if read-behind (that is, reverse scans) will be used. This flag has no effect if the file system does not
	/// support cached I/O and FILE_FLAG_NO_BUFFERING. For more information, see the Caching Behavior section of this topic.
	/// </term>
	/// </item>
	/// <item>
	/// <term>FILE_FLAG_WRITE_THROUGH 0x80000000</term>
	/// <term>
	/// Write operations will not go through any intermediate cache, they will go directly to disk. For additional information, see the
	/// Caching Behavior section of this topic.
	/// </term>
	/// </item>
	/// </list>
	/// <para>
	/// The dwFlagsAndAttributesparameter can also specify SQOS information. For more information, see Impersonation Levels. When the
	/// calling application specifies the <c>SECURITY_SQOS_PRESENT</c> flag as part of dwFlagsAndAttributes, it can also contain one or
	/// more of the following values.
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
	/// extended attributes for the file that is being created.
	/// </para>
	/// <para>This parameter can be <c>NULL</c>.</para>
	/// <para>When opening an existing file, this parameter is ignored.</para>
	/// <para>
	/// When opening a new encrypted file, the file inherits the discretionary access control list from its parent directory. For more
	/// information, see File Encryption.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is an open handle to the specified file, device, named pipe, or mail slot.</para>
	/// <para>If the function fails, the return value is <c>INVALID_HANDLE_VALUE</c>. To get extended error information, call <c>GetLastError</c>.</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/fileapifromapp/nf-fileapifromapp-createfilefromappw WINSTORAGEAPI HANDLE
	// noexcept CreateFileFromAppW( LPCWSTR lpFileName, DWORD dwDesiredAccess, DWORD dwShareMode, LPSECURITY_ATTRIBUTES
	// lpSecurityAttributes, DWORD dwCreationDisposition, DWORD dwFlagsAndAttributes, HANDLE hTemplateFile );
	[DllImport(Lib.KernelBase, SetLastError = true, ExactSpelling = true, CharSet = CharSet.Unicode)]
	[PInvokeData("fileapifromapp.h", MSDNShortId = "NF:fileapifromapp.CreateFileFromAppW", MinClient = PInvokeClient.Windows10)]
	public static extern SafeHFILE CreateFileFromAppW(string lpFileName, FileAccess dwDesiredAccess, FileShare dwShareMode,
		[Optional] SECURITY_ATTRIBUTES? lpSecurityAttributes, FileMode dwCreationDisposition, FileFlagsAndAttributes dwFlagsAndAttributes,
		[Optional] HFILE hTemplateFile);

	/// <summary>
	/// Deletes an existing file. The behavior of this function is identical to <c>DeleteFile</c>, except that this function adheres to
	/// the Universal Windows Platform app security model.
	/// </summary>
	/// <param name="lpFileName">
	/// <para>The name of the file to be deleted.</para>
	/// <para>
	/// In the ANSI version of this function, the name is limited to <c>MAX_PATH</c> characters. To extend this limit to 32,767 wide
	/// characters, call the Unicode version of the function and prepend "\\?\" to the path. For more information, see Naming Files,
	/// Paths, and Namespaces.
	/// </para>
	/// <para>
	/// For the unicode version of this function ( <c>DeleteFileFromAppW</c>), you can opt-in to remove the <c>MAX_PATH</c> character
	/// limitation without prepending "\\?\". See the "Maximum Path Limitation" section of Naming Files, Paths, and Namespaces for details.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero (0). To get extended error information, call <c>GetLastError</c>.</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/fileapifromapp/nf-fileapifromapp-deletefilefromappw WINSTORAGEAPI BOOL
	// noexcept DeleteFileFromAppW( LPCWSTR lpFileName );
	[DllImport(Lib.KernelBase, SetLastError = true, ExactSpelling = true, CharSet = CharSet.Unicode)]
	[PInvokeData("fileapifromapp.h", MSDNShortId = "NF:fileapifromapp.DeleteFileFromAppW", MinClient = PInvokeClient.Windows10)]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool DeleteFileFromAppW(string lpFileName);

	/// <summary>
	/// Searches a directory for a file or subdirectory with a name and attributes that match those specified. The behavior of this
	/// function is identical to <c>FindFirstFileEx</c>, except that this function adheres to the Universal Windows Platform app
	/// security model.
	/// </summary>
	/// <param name="lpFileName">
	/// <para>
	/// The directory or path, and the file name. The file name can include wildcard characters, for example, an asterisk (*) or a
	/// question mark (?).
	/// </para>
	/// <para>
	/// This parameter should not be <c>NULL</c>, an invalid string (for example, an empty string or a string that is missing the
	/// terminating null character), or end in a trailing backslash (\).
	/// </para>
	/// <para>
	/// If the string ends with a wildcard, period, or directory name, the user must have access to the root and all subdirectories on
	/// the path.
	/// </para>
	/// <para>
	/// For information about opting out of the <c>MAX_PATH</c> limitation without prepending "\\?\", see the "Maximum Path Length
	/// Limitation" section of Naming Files, Paths, and Namespaces for details.
	/// </para>
	/// </param>
	/// <param name="fInfoLevelId">
	/// <para>The information level of the returned data.</para>
	/// <para>This parameter is one of the <c>FINDEX_INFO_LEVELS</c> enumeration values.</para>
	/// </param>
	/// <param name="lpFindFileData">
	/// <para>A pointer to the buffer that receives the file data.</para>
	/// <para>The pointer type is determined by the level of information that is specified in the fInfoLevelId parameter.</para>
	/// </param>
	/// <param name="fSearchOp">
	/// <para>The type of filtering to perform that is different from wildcard matching.</para>
	/// <para>This parameter is one of the <c>FINDEX_SEARCH_OPS</c> enumeration values.</para>
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
	/// <item>
	/// <term>FIND_FIRST_EX_LARGE_FETCH 2</term>
	/// <term>Uses a larger buffer for directory queries, which can increase performance of the find operation.</term>
	/// </item>
	/// <item>
	/// <term>FIND_FIRST_EX_ON_DISK_ENTRIES_ONLY 4</term>
	/// <term>
	/// Limits the results to files that are physically on disk. This flag is only relevant when a file virtualization filter is present.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <returns>
	/// <para>
	/// If the function succeeds, the return value is a search handle used in a subsequent call to <c>FindNextFile</c> or
	/// <c>FindClose</c>, and the lpFindFileData parameter contains information about the first file or directory found.
	/// </para>
	/// <para>
	/// If the function fails or fails to locate files from the search string in the lpFileName parameter, the return value is
	/// <c>INVALID_HANDLE_VALUE</c> and the contents of lpFindFileData are indeterminate. To get extended error information, call the
	/// <c>GetLastError</c> function.
	/// </para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/fileapifromapp/nf-fileapifromapp-findfirstfileexfromappw WINSTORAGEAPI HANDLE
	// noexcept FindFirstFileExFromAppW( LPCWSTR lpFileName, FINDEX_INFO_LEVELS fInfoLevelId, LPVOID lpFindFileData, FINDEX_SEARCH_OPS
	// fSearchOp, LPVOID lpSearchFilter, DWORD dwAdditionalFlags );
	[DllImport(Lib.KernelBase, SetLastError = true, ExactSpelling = true, CharSet = CharSet.Unicode)]
	[PInvokeData("fileapifromapp.h", MSDNShortId = "NF:fileapifromapp.FindFirstFileExFromAppW", MinClient = PInvokeClient.Windows10)]
	public static extern SafeSearchHandle FindFirstFileExFromAppW(string lpFileName, FINDEX_INFO_LEVELS fInfoLevelId,
		out WIN32_FIND_DATA lpFindFileData, FINDEX_SEARCH_OPS fSearchOp, [Optional] IntPtr lpSearchFilter, FIND_FIRST dwAdditionalFlags);

	/// <summary>
	/// Retrieves attributes for a specified file or directory. The behavior of this function is identical to
	/// <c>GetFileAttributesEx</c>, except that this function adheres to the Universal Windows Platform app security model.
	/// </summary>
	/// <param name="lpFileName"/>
	/// <param name="fInfoLevelId">
	/// <para>A class of attribute information to retrieve.</para>
	/// <para>This parameter can be the following value from the <c>GET_FILEEX_INFO_LEVELS</c> enumeration.</para>
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
	/// <para>The type of attribute information that is stored into this buffer is determined by the value of fInfoLevelId.</para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is a nonzero value.</para>
	/// <para>If the function fails, the return value is zero (0). To get extended error information, call <c>GetLastError</c>.</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/fileapifromapp/nf-fileapifromapp-getfileattributesexfromappw WINSTORAGEAPI
	// BOOL noexcept GetFileAttributesExFromAppW( LPCWSTR lpFileName, GET_FILEEX_INFO_LEVELS fInfoLevelId, LPVOID lpFileInformation );
	[DllImport(Lib.KernelBase, SetLastError = true, ExactSpelling = true, CharSet = CharSet.Unicode)]
	[PInvokeData("fileapifromapp.h", MSDNShortId = "NF:fileapifromapp.GetFileAttributesExFromAppW", MinClient = PInvokeClient.Windows10)]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool GetFileAttributesExFromAppW(string lpFileName, GET_FILEEX_INFO_LEVELS fInfoLevelId,
		out WIN32_FILE_ATTRIBUTE_DATA lpFileInformation);

	/// <summary>
	/// Moves an existing file or a directory, including its children. The behavior of this function is identical to <c>MoveFile</c>,
	/// except that this function adheres to the Universal Windows Platform app security model.
	/// </summary>
	/// <param name="lpExistingFileName">
	/// <para>The current name of the file or directory on the local computer.</para>
	/// <para>
	/// For information about opting out of the <c>MAX_PATH</c> limitation without prepending "\\?\", see the "Maximum Path Length
	/// Limitation" section of Naming Files, Paths, and Namespaces for details.
	/// </para>
	/// </param>
	/// <param name="lpNewFileName">
	/// <para>
	/// The new name for the file or directory. The new name must not already exist. A new file may be on a different file system or
	/// drive. A new directory must be on the same drive.
	/// </para>
	/// <para>
	/// For information about opting out of the <c>MAX_PATH</c> limitation without prepending "\\?\", see the "Maximum Path Length
	/// Limitation" section of Naming Files, Paths, and Namespaces for details.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call <c>GetLastError</c>.</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/fileapifromapp/nf-fileapifromapp-movefilefromappw WINSTORAGEAPI BOOL noexcept
	// MoveFileFromAppW( LPCWSTR lpExistingFileName, LPCWSTR lpNewFileName );
	[DllImport(Lib.KernelBase, SetLastError = true, ExactSpelling = true, CharSet = CharSet.Unicode)]
	[PInvokeData("fileapifromapp.h", MSDNShortId = "NF:fileapifromapp.MoveFileFromAppW", MinClient = PInvokeClient.Windows10)]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool MoveFileFromAppW(string lpExistingFileName, string lpNewFileName);

	/// <summary>
	/// Deletes an existing empty directory. The behavior of this function is identical to <c>RemoveDirectory</c>, except that this
	/// function adheres to the Universal Windows Platform app security model.
	/// </summary>
	/// <param name="lpPathName">
	/// <para>
	/// The path of the directory to be removed. This path must specify an empty directory, and the calling process must have delete
	/// access to the directory.
	/// </para>
	/// <para>
	/// For information about opting out of the <c>MAX_PATH</c> limitation without prepending "\\?\", see the "Maximum Path Length
	/// Limitation" section of Naming Files, Paths, and Namespaces for details.
	/// </para>
	/// </param>
	/// <returns>None</returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/fileapifromapp/nf-fileapifromapp-removedirectoryfromappw WINSTORAGEAPI BOOL
	// noexcept RemoveDirectoryFromAppW( LPCWSTR lpPathName );
	[DllImport(Lib.KernelBase, SetLastError = false, ExactSpelling = true, CharSet = CharSet.Unicode)]
	[PInvokeData("fileapifromapp.h", MSDNShortId = "NF:fileapifromapp.RemoveDirectoryFromAppW", MinClient = PInvokeClient.Windows10)]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool RemoveDirectoryFromAppW(string lpPathName);

	/// <summary>
	/// Replaces one file with another file, with the option of creating a backup copy of the original file. The behavior of this
	/// function is identical to <c>ReplaceFile</c>, except that this function adheres to the Universal Windows Platform app security model.
	/// </summary>
	/// <param name="lpReplacedFileName">
	/// <para>
	/// For information about opting out of the <c>MAX_PATH</c> limitation without prepending "\\?\", see the "Maximum Path Length
	/// Limitation" section of Naming Files, Paths, and Namespaces for details.
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
	/// For information about opting out of the <c>MAX_PATH</c> limitation without prepending "\\?\", see the "Maximum Path Length
	/// Limitation" section of Naming Files, Paths, and Namespaces for details.
	/// </para>
	/// <para>
	/// The function attempts to open this file with the <c>SYNCHRONIZE</c>, <c>GENERIC_READ</c>, <c>GENERIC_WRITE</c>, <c>DELETE</c>,
	/// and <c>WRITE_DAC</c> access rights so that it can preserve all attributes and ACLs. If this fails, the function attempts to open
	/// the file with the <c>SYNCHRONIZE</c>, <c>GENERIC_READ</c>, <c>DELETE</c>, and <c>WRITE_DAC</c> access rights. No sharing mode is specified.
	/// </para>
	/// </param>
	/// <param name="lpBackupFileName">
	/// <para>
	/// The name of the file that will serve as a backup copy of the lpReplacedFileName file. If this parameter is <c>NULL</c>, no
	/// backup file is created. See the Remarks section for implementation details on the backup file.
	/// </para>
	/// <para>
	/// For information about opting out of the <c>MAX_PATH</c> limitation without prepending "\\?\", see the "Maximum Path Length
	/// Limitation" section of Naming Files, Paths, and Namespaces for details.
	/// </para>
	/// </param>
	/// <param name="dwReplaceFlags">
	/// <para>The replacement options. This parameter can be one or more of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>REPLACEFILE_WRITE_THROUGH 0x00000001</term>
	/// <term>This value is not supported.</term>
	/// </item>
	/// <item>
	/// <term>REPLACEFILE_IGNORE_MERGE_ERRORS 0x00000002</term>
	/// <term>
	/// Ignores errors that occur while merging information (such as attributes and ACLs) from the replaced file to the replacement
	/// file. Therefore, if you specify this flag and do not have WRITE_DAC access, the function succeeds but the ACLs are not preserved.
	/// </term>
	/// </item>
	/// <item>
	/// <term>REPLACEFILE_IGNORE_ACL_ERRORS 0x00000004</term>
	/// <term>
	/// Ignores errors that occur while merging ACL information from the replaced file to the replacement file. Therefore, if you
	/// specify this flag and do not have WRITE_DAC access, the function succeeds but the ACLs are not preserved. To compile an
	/// application that uses this value, define the _WIN32_WINNT macro as 0x0600 or later.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="lpExclude">Reserved for future use.</param>
	/// <param name="lpReserved">Reserved for future use.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>
	/// If the function fails, the return value is zero. To get extended error information, call <c>GetLastError</c>. The following are
	/// possible error codes for this function.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code/value</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_UNABLE_TO_MOVE_REPLACEMENT 1176 (0x498)</term>
	/// <term>
	/// The replacement file could not be renamed. If lpBackupFileName was specified, the replaced and replacement files retain their
	/// original file names. Otherwise, the replaced file no longer exists and the replacement file exists under its original name.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ERROR_UNABLE_TO_MOVE_REPLACEMENT_2 1177 (0x499)</term>
	/// <term>
	/// The replacement file could not be moved. The replacement file still exists under its original name; however, it has inherited
	/// the file streams and attributes from the file it is replacing. The file to be replaced still exists with a different name. If
	/// lpBackupFileName is specified, it will be the name of the replaced file.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ERROR_UNABLE_TO_REMOVE_REPLACED 1175 (0x497)</term>
	/// <term>The replaced file could not be deleted. The replaced and replacement files retain their original file names.</term>
	/// </item>
	/// </list>
	/// <para>
	/// If any other error is returned, such as <c>ERROR_INVALID_PARAMETER</c>, the replaced and replacement files will retain their
	/// original file names. In this scenario, a backup file does not exist and it is not guaranteed that the replacement file will have
	/// inherited all of the attributes and streams of the replaced file.
	/// </para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/fileapifromapp/nf-fileapifromapp-replacefilefromappw WINSTORAGEAPI BOOL
	// noexcept ReplaceFileFromAppW( LPCWSTR lpReplacedFileName, LPCWSTR lpReplacementFileName, LPCWSTR lpBackupFileName, DWORD
	// dwReplaceFlags, LPVOID lpExclude, LPVOID lpReserved );
	[DllImport(Lib.KernelBase, SetLastError = true, ExactSpelling = true, CharSet = CharSet.Unicode)]
	[PInvokeData("fileapifromapp.h", MSDNShortId = "NF:fileapifromapp.ReplaceFileFromAppW", MinClient = PInvokeClient.Windows10)]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool ReplaceFileFromAppW(string lpReplacedFileName, string lpReplacementFileName,
		[Optional] string? lpBackupFileName, REPLACEFILE dwReplaceFlags, [Optional] IntPtr lpExclude, [Optional] IntPtr lpReserved);

	/// <summary>
	/// Sets the attributes for a file or directory. The behavior of this function is identical to <c>SetFileAttributes</c>, except that
	/// this function adheres to the Universal Windows Platform app security model.
	/// </summary>
	/// <param name="lpFileName">
	/// <para>The name of the file whose attributes are to be set.</para>
	/// <para>
	/// For information about opting out of the <c>MAX_PATH</c> limitation without prepending "\\?\", see the "Maximum Path Length
	/// Limitation" section of Naming Files, Paths, and Namespaces for details.
	/// </para>
	/// </param>
	/// <param name="dwFileAttributes">
	/// <para>The file attributes to set for the file.</para>
	/// <para>This parameter can be one or more values, combined using the bitwise-OR operator. However, all other values override <c>FILE_ATTRIBUTE_NORMAL</c>.</para>
	/// <para>Not all attributes are supported by this function.</para>
	/// <para>The following is a list of supported attribute values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>FILE_ATTRIBUTE_ARCHIVE 32 (0x20)</term>
	/// <term>
	/// A file or directory that is an archive file or directory. Applications typically use this attribute to mark files for backup or removal.
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
	/// A file that is read-only. Applications can read the file, but cannot write to it or delete it. This attribute is not honored on directories.
	/// </term>
	/// </item>
	/// <item>
	/// <term>FILE_ATTRIBUTE_SYSTEM 4 (0x4)</term>
	/// <term>A file or directory that the operating system uses a part of, or uses exclusively.</term>
	/// </item>
	/// <item>
	/// <term>FILE_ATTRIBUTE_TEMPORARY 256 (0x100)</term>
	/// <term>
	/// A file that is being used for temporary storage. File systems avoid writing data back to mass storage if sufficient cache memory
	/// is available, because typically, an application deletes a temporary file after the handle is closed. In that scenario, the
	/// system can entirely avoid writing the data. Otherwise, the data is written after the handle is closed.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call <c>GetLastError</c>.</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/fileapifromapp/nf-fileapifromapp-setfileattributesfromappw WINSTORAGEAPI BOOL
	// noexcept SetFileAttributesFromAppW( LPCWSTR lpFileName, DWORD dwFileAttributes );
	[DllImport(Lib.KernelBase, SetLastError = true, ExactSpelling = true, CharSet = CharSet.Unicode)]
	[PInvokeData("fileapifromapp.h", MSDNShortId = "NF:fileapifromapp.SetFileAttributesFromAppW", MinClient = PInvokeClient.Windows10)]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SetFileAttributesFromAppW(string lpFileName, FileFlagsAndAttributes dwFileAttributes);
}