using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using System.Threading;
using Microsoft.Win32.SafeHandles;
using Vanara.InteropServices;
using FILETIME = System.Runtime.InteropServices.ComTypes.FILETIME;

namespace Vanara.PInvoke
{
	public static partial class Kernel32
	{
		/// <summary>A value returned when invalid file attributes are found.</summary>
		[PInvokeData("fileapi.h")] public const int INVALID_FILE_ATTRIBUTES = -2;

		/// <summary>A value returned by <see cref="GetCompressedFileSize(string, ref uint)"/> when the function fails.</summary>
		[PInvokeData("fileapi.h")] public const uint INVALID_FILE_SIZE = 0xFFFFFFFF;

		/// <summary>A value returned then a file pointer cannot be set.</summary>
		[PInvokeData("fileapi.h")] public const int INVALID_SET_FILE_POINTER = -1;

		/// <summary>
		/// Reads data from the specified file or input/output (I/O) device. Reads occur at the position specified by the file pointer if supported by the device.
		/// </summary>
		/// <param name="hFile">A handle to the device (for example, a file, file stream, physical disk, volume, console buffer, tape drive, socket, communications resource, mailslot, or pipe). The hFile parameter must have been created with read access. </param>
		/// <param name="buffer">A pointer to the buffer that receives the data read from a file or device.</param>
		/// <param name="numberOfBytesToRead">The maximum number of bytes to be read.</param>
		/// <param name="requestCallback">An AsyncCallback delegate that references the method to invoke when the operation is complete.</param>
		/// <param name="stateObject">A user-defined object that contains information about the operation. This object is passed to the requestCallback delegate when the operation is complete.</param>
		/// <returns>An IAsyncResult instance that references the asynchronous request.</returns>
		public static unsafe IAsyncResult BeginReadFile(SafeFileHandle hFile, byte[] buffer, uint numberOfBytesToRead, AsyncCallback requestCallback, object stateObject)
		{
			var ar = OverlappedAsync.SetupOverlappedFunction(hFile, requestCallback, stateObject);
			fixed (byte* pIn = buffer)
			{
				var ret = ReadFile(hFile, pIn, numberOfBytesToRead, IntPtr.Zero, ar.Overlapped);
				return OverlappedAsync.EvaluateOverlappedFunction(ar, ret);
			}
		}

		/// <summary>
		/// Writes data to the specified file or input/output (I/O) device.
		/// <para>This function is designed for both synchronous and asynchronous operation. For a similar function designed solely for asynchronous operation, see WriteFileEx.</para>
		/// </summary>
		/// <param name="hFile">A handle to the file or I/O device (for example, a file, file stream, physical disk, volume, console buffer, tape drive, socket, communications resource, mailslot, or pipe).
		/// <para>The hFile parameter must have been created with the write access. For more information, see Generic Access Rights and File Security and Access Rights.</para>
		/// <para>For asynchronous write operations, hFile can be any handle opened with the CreateFile function using the FILE_FLAG_OVERLAPPED flag or a socket handle returned by the socket or accept function.</para></param>
		/// <param name="buffer">A pointer to the buffer containing the data to be written to the file or device.
		/// <para>This buffer must remain valid for the duration of the write operation. The caller must not use this buffer until the write operation is completed.</para></param>
		/// <param name="numberOfBytesToWrite">The number of bytes to be written to the file or device.
		/// <para>A value of zero specifies a null write operation. The behavior of a null write operation depends on the underlying file system or communications technology.</para>
		/// <para>Windows Server 2003 and Windows XP:  Pipe write operations across a network are limited in size per write. The amount varies per platform. For x86 platforms it's 63.97 MB. For x64 platforms it's 31.97 MB. For Itanium it's 63.95 MB. For more information regarding pipes, see the Remarks section.</para></param>
		/// <param name="requestCallback">An AsyncCallback delegate that references the method to invoke when the operation is complete.</param>
		/// <param name="stateObject">A user-defined object that contains information about the operation. This object is passed to the requestCallback delegate when the operation is complete.</param>
		/// <returns>An IAsyncResult instance that references the asynchronous request.</returns>
		public static unsafe IAsyncResult BeginWriteFile(SafeFileHandle hFile, byte[] buffer, uint numberOfBytesToWrite, AsyncCallback requestCallback, object stateObject)
		{
			var ar = OverlappedAsync.SetupOverlappedFunction(hFile, requestCallback, stateObject);
			fixed (byte* pIn = buffer)
			{
				var ret = WriteFile(hFile, pIn, numberOfBytesToWrite, IntPtr.Zero, ar.Overlapped);
				return OverlappedAsync.EvaluateOverlappedFunction(ar, ret);
			}
		}

		/// <summary>
		/// Creates or opens a file or I/O device. The most commonly used I/O devices are as follows: file, file stream, directory, physical disk, volume,
		/// console buffer, tape drive, communications resource, mailslot, and pipe. The function returns a handle that can be used to access the file or device
		/// for various types of I/O depending on the file or device and the flags and attributes specified.
		/// </summary>
		/// <param name="lpFileName">
		/// The name of the file or device to be created or opened. You may use either forward slashes (/) or backslashes (\) in this name.
		/// <para>
		/// In the ANSI version of this function, the name is limited to MAX_PATH characters. To extend this limit to 32,767 wide characters, call the Unicode
		/// version of the function and prepend "\\?\" to the path. For more information, see Naming Files, Paths, and Namespaces.
		/// </para>
		/// <para>For information on special device names, see Defining an MS-DOS Device Name.</para>
		/// <para>To create a file stream, specify the name of the file, a colon, and then the name of the stream. For more information, see File Streams.</para>
		/// <note type="tip">Starting with Windows 10, version 1607, for the Unicode version of this function (CreateFileW), you can opt-in to remove the
		/// MAX_PATH limitation without prepending "\\?\". See the "Maximum Path Length Limitation" section of Naming Files, Paths, and Namespaces for details.</note>
		/// </param>
		/// <param name="dwDesiredAccess">
		/// The requested access to the file or device, which can be summarized as read, write, both or neither zero).
		/// <para>
		/// The most commonly used values are GENERIC_READ, GENERIC_WRITE, or both (GENERIC_READ | GENERIC_WRITE). For more information, see Generic Access
		/// Rights, File Security and Access Rights, File Access Rights Constants, and ACCESS_MASK.
		/// </para>
		/// <para>
		/// If this parameter is zero, the application can query certain metadata such as file, directory, or device attributes without accessing that file or
		/// device, even if GENERIC_READ access would have been denied.
		/// </para>
		/// <para>
		/// You cannot request an access mode that conflicts with the sharing mode that is specified by the dwShareMode parameter in an open request that already
		/// has an open handle.
		/// </para>
		/// </param>
		/// <param name="dwShareMode">
		/// The requested sharing mode of the file or device, which can be read, write, both, delete, all of these, or none (refer to the following table).
		/// Access requests to attributes or extended attributes are not affected by this flag.
		/// <para>
		/// If this parameter is zero and CreateFile succeeds, the file or device cannot be shared and cannot be opened again until the handle to the file or
		/// device is closed. For more information, see the Remarks section.
		/// </para>
		/// <para>
		/// You cannot request a sharing mode that conflicts with the access mode that is specified in an existing request that has an open handle. CreateFile
		/// would fail and the GetLastError function would return ERROR_SHARING_VIOLATION.
		/// </para>
		/// <para>
		/// To enable a process to share a file or device while another process has the file or device open, use a compatible combination of one or more of the
		/// following values. For more information about valid combinations of this parameter with the dwDesiredAccess parameter, see Creating and Opening Files.
		/// </para>
		/// <note>The sharing options for each open handle remain in effect until that handle is closed, regardless of process context.</note>
		/// </param>
		/// <param name="lpSecurityAttributes">
		/// A pointer to a SECURITY_ATTRIBUTES structure that contains two separate but related data members: an optional security descriptor, and a Boolean
		/// value that determines whether the returned handle can be inherited by child processes.
		/// <para>This parameter can be NULL.</para>
		/// <para>
		/// If this parameter is NULL, the handle returned by CreateFile cannot be inherited by any child processes the application may create and the file or
		/// device associated with the returned handle gets a default security descriptor.
		/// </para>
		/// <para>
		/// The lpSecurityDescriptor member of the structure specifies a SECURITY_DESCRIPTOR for a file or device. If this member is NULL, the file or device
		/// associated with the returned handle is assigned a default security descriptor.
		/// </para>
		/// <para>CreateFile ignores the lpSecurityDescriptor member when opening an existing file or device, but continues to use the bInheritHandle member.</para>
		/// <para>The bInheritHandlemember of the structure specifies whether the returned handle can be inherited.</para>
		/// </param>
		/// <param name="dwCreationDisposition">
		/// An action to take on a file or device that exists or does not exist.
		/// <para>For devices other than files, this parameter is usually set to OPEN_EXISTING.</para>
		/// </param>
		/// <param name="dwFlagsAndAttributes">
		/// The file or device attributes and flags, FILE_ATTRIBUTE_NORMAL being the most common default value for files.
		/// <para>This parameter can include any combination of the available file attributes (FILE_ATTRIBUTE_*). All other file attributes override FILE_ATTRIBUTE_NORMAL.</para>
		/// <para>
		/// This parameter can also contain combinations of flags (FILE_FLAG_*) for control of file or device caching behavior, access modes, and other
		/// special-purpose flags. These combine with any FILE_ATTRIBUTE_* values.
		/// </para>
		/// <para>
		/// This parameter can also contain Security Quality of Service (SQOS) information by specifying the SECURITY_SQOS_PRESENT flag. Additional SQOS-related
		/// flags information is presented in the table following the attributes and flags tables.
		/// </para>
		/// <note>When CreateFile opens an existing file, it generally combines the file flags with the file attributes of the existing file, and ignores any
		/// file attributes supplied as part of dwFlagsAndAttributes. Special cases are detailed in Creating and Opening Files.</note>
		/// <para>
		/// Some of the following file attributes and flags may only apply to files and not necessarily all other types of devices that CreateFile can open. For
		/// additional information, see the Remarks section of this topic and Creating and Opening Files.
		/// </para>
		/// <para>
		/// For more advanced access to file attributes, see SetFileAttributes. For a complete list of all file attributes with their values and descriptions,
		/// see File Attribute Constants.
		/// </para>
		/// </param>
		/// <param name="hTemplateFile">
		/// A valid handle to a template file with the GENERIC_READ access right. The template file supplies file attributes and extended attributes for the file
		/// that is being created.
		/// <para>This parameter can be NULL.</para>
		/// <para>When opening an existing file, CreateFile ignores this parameter.</para>
		/// <para>
		/// When opening a new encrypted file, the file inherits the discretionary access control list from its parent directory. For additional information, see
		/// File Encryption.
		/// </para>
		/// </param>
		/// <returns>
		/// If the function succeeds, the return value is an open handle to the specified file, device, named pipe, or mail slot.
		/// <para>If the function fails, the return value is INVALID_HANDLE_VALUE. To get extended error information, call GetLastError.</para>
		/// </returns>
		[DllImport(Lib.Kernel32, SetLastError = true, CharSet = CharSet.Auto)]
		[PInvokeData("FileAPI.h", MSDNShortId = "aa363858")]
		public static extern SafeFileHandle CreateFile(string lpFileName, FileAccess dwDesiredAccess, FileShare dwShareMode,
			[Optional] SECURITY_ATTRIBUTES lpSecurityAttributes, FileMode dwCreationDisposition, FileFlagsAndAttributes dwFlagsAndAttributes,
			SafeFileHandle hTemplateFile);

		/// <summary>
		/// Creates or opens a file or I/O device. The most commonly used I/O devices are as follows: file, file stream, directory, physical disk, volume,
		/// console buffer, tape drive, communications resource, mailslot, and pipe. The function returns a handle that can be used to access the file or device
		/// for various types of I/O depending on the file or device and the flags and attributes specified.
		/// </summary>
		/// <param name="lpFileName">
		/// The name of the file or device to be created or opened. You may use either forward slashes (/) or backslashes (\) in this name.
		/// <para>
		/// In the ANSI version of this function, the name is limited to MAX_PATH characters. To extend this limit to 32,767 wide characters, call the Unicode
		/// version of the function and prepend "\\?\" to the path. For more information, see Naming Files, Paths, and Namespaces.
		/// </para>
		/// <para>For information on special device names, see Defining an MS-DOS Device Name.</para>
		/// <para>To create a file stream, specify the name of the file, a colon, and then the name of the stream. For more information, see File Streams.</para>
		/// <note type="tip">Starting with Windows 10, version 1607, for the Unicode version of this function (CreateFileW), you can opt-in to remove the
		/// MAX_PATH limitation without prepending "\\?\". See the "Maximum Path Length Limitation" section of Naming Files, Paths, and Namespaces for details.</note>
		/// </param>
		/// <param name="dwDesiredAccess">
		/// The requested access to the file or device, which can be summarized as read, write, both or neither zero).
		/// <para>
		/// The most commonly used values are GENERIC_READ, GENERIC_WRITE, or both (GENERIC_READ | GENERIC_WRITE). For more information, see Generic Access
		/// Rights, File Security and Access Rights, File Access Rights Constants, and ACCESS_MASK.
		/// </para>
		/// <para>
		/// If this parameter is zero, the application can query certain metadata such as file, directory, or device attributes without accessing that file or
		/// device, even if GENERIC_READ access would have been denied.
		/// </para>
		/// <para>
		/// You cannot request an access mode that conflicts with the sharing mode that is specified by the dwShareMode parameter in an open request that already
		/// has an open handle.
		/// </para>
		/// </param>
		/// <param name="dwShareMode">
		/// The requested sharing mode of the file or device, which can be read, write, both, delete, all of these, or none (refer to the following table).
		/// Access requests to attributes or extended attributes are not affected by this flag.
		/// <para>
		/// If this parameter is zero and CreateFile succeeds, the file or device cannot be shared and cannot be opened again until the handle to the file or
		/// device is closed. For more information, see the Remarks section.
		/// </para>
		/// <para>
		/// You cannot request a sharing mode that conflicts with the access mode that is specified in an existing request that has an open handle. CreateFile
		/// would fail and the GetLastError function would return ERROR_SHARING_VIOLATION.
		/// </para>
		/// <para>
		/// To enable a process to share a file or device while another process has the file or device open, use a compatible combination of one or more of the
		/// following values. For more information about valid combinations of this parameter with the dwDesiredAccess parameter, see Creating and Opening Files.
		/// </para>
		/// <note>The sharing options for each open handle remain in effect until that handle is closed, regardless of process context.</note>
		/// </param>
		/// <param name="lpSecurityAttributes">
		/// A pointer to a SECURITY_ATTRIBUTES structure that contains two separate but related data members: an optional security descriptor, and a Boolean
		/// value that determines whether the returned handle can be inherited by child processes.
		/// <para>This parameter can be NULL.</para>
		/// <para>
		/// If this parameter is NULL, the handle returned by CreateFile cannot be inherited by any child processes the application may create and the file or
		/// device associated with the returned handle gets a default security descriptor.
		/// </para>
		/// <para>
		/// The lpSecurityDescriptor member of the structure specifies a SECURITY_DESCRIPTOR for a file or device. If this member is NULL, the file or device
		/// associated with the returned handle is assigned a default security descriptor.
		/// </para>
		/// <para>CreateFile ignores the lpSecurityDescriptor member when opening an existing file or device, but continues to use the bInheritHandle member.</para>
		/// <para>The bInheritHandlemember of the structure specifies whether the returned handle can be inherited.</para>
		/// </param>
		/// <param name="dwCreationDisposition">
		/// An action to take on a file or device that exists or does not exist.
		/// <para>For devices other than files, this parameter is usually set to OPEN_EXISTING.</para>
		/// </param>
		/// <param name="dwFlagsAndAttributes">
		/// The file or device attributes and flags, FILE_ATTRIBUTE_NORMAL being the most common default value for files.
		/// <para>This parameter can include any combination of the available file attributes (FILE_ATTRIBUTE_*). All other file attributes override FILE_ATTRIBUTE_NORMAL.</para>
		/// <para>
		/// This parameter can also contain combinations of flags (FILE_FLAG_*) for control of file or device caching behavior, access modes, and other
		/// special-purpose flags. These combine with any FILE_ATTRIBUTE_* values.
		/// </para>
		/// <para>
		/// This parameter can also contain Security Quality of Service (SQOS) information by specifying the SECURITY_SQOS_PRESENT flag. Additional SQOS-related
		/// flags information is presented in the table following the attributes and flags tables.
		/// </para>
		/// <note>When CreateFile opens an existing file, it generally combines the file flags with the file attributes of the existing file, and ignores any
		/// file attributes supplied as part of dwFlagsAndAttributes. Special cases are detailed in Creating and Opening Files.</note>
		/// <para>
		/// Some of the following file attributes and flags may only apply to files and not necessarily all other types of devices that CreateFile can open. For
		/// additional information, see the Remarks section of this topic and Creating and Opening Files.
		/// </para>
		/// <para>
		/// For more advanced access to file attributes, see SetFileAttributes. For a complete list of all file attributes with their values and descriptions,
		/// see File Attribute Constants.
		/// </para>
		/// </param>
		/// <param name="hTemplateFile">
		/// A valid handle to a template file with the GENERIC_READ access right. The template file supplies file attributes and extended attributes for the file
		/// that is being created.
		/// <para>This parameter can be NULL.</para>
		/// <para>When opening an existing file, CreateFile ignores this parameter.</para>
		/// <para>
		/// When opening a new encrypted file, the file inherits the discretionary access control list from its parent directory. For additional information, see
		/// File Encryption.
		/// </para>
		/// </param>
		/// <returns>
		/// If the function succeeds, the return value is an open handle to the specified file, device, named pipe, or mail slot.
		/// <para>If the function fails, the return value is INVALID_HANDLE_VALUE. To get extended error information, call GetLastError.</para>
		/// </returns>
		[DllImport(Lib.Kernel32, SetLastError = true, CharSet = CharSet.Auto)]
		[PInvokeData("FileAPI.h", MSDNShortId = "aa363858")]
		public static extern SafeFileHandle CreateFile(string lpFileName, FileAccess dwDesiredAccess, FileShare dwShareMode,
			[Optional] SECURITY_ATTRIBUTES lpSecurityAttributes, FileMode dwCreationDisposition, FileFlagsAndAttributes dwFlagsAndAttributes,
			[Optional] IntPtr hTemplateFile);

		/// <summary>Ends an asynchronous request for ReadFile.</summary>
		/// <param name="asyncResult">An IAsyncResult instance returned by a call to the BeginReadFile method.</param>
		public static void EndReadFile(IAsyncResult asyncResult)
		{
			OverlappedAsync.EndOverlappedFunction(asyncResult);
		}

		/// <summary>Ends an asynchronous request for WriteFile.</summary>
		/// <param name="asyncResult">An IAsyncResult instance returned by a call to the BeginWriteFile method.</param>
		public static void EndWriteFile(IAsyncResult asyncResult)
		{
			OverlappedAsync.EndOverlappedFunction(asyncResult);
		}

		/// <summary>Retrieves information about the specified disk, including the amount of free space on the disk.</summary>
		/// <param name="lpRootPathName">
		/// The root directory of the disk for which information is to be returned. If this parameter is NULL, the function uses the root of the current disk. If
		/// this parameter is a UNC name, it must include a trailing backslash (for example, "\\MyServer\MyShare\"). Furthermore, a drive specification must have
		/// a trailing backslash (for example, "C:\"). The calling application must have FILE_LIST_DIRECTORY access rights for this directory.
		/// </param>
		/// <param name="lpSectorsPerCluster">A pointer to a variable that receives the number of sectors per cluster.</param>
		/// <param name="lpBytesPerSector">A pointer to a variable that receives the number of bytes per sector.</param>
		/// <param name="lpNumberOfFreeClusters">
		/// A pointer to a variable that receives the total number of free clusters on the disk that are available to the user who is associated with the calling thread.
		/// <para>If per-user disk quotas are in use, this value may be less than the total number of free clusters on the disk.</para>
		/// </param>
		/// <param name="lpTotalNumberOfClusters">
		/// A pointer to a variable that receives the total number of clusters on the disk that are available to the user who is associated with the calling thread.
		/// <para>If per-user disk quotas are in use, this value may be less than the total number of clusters on the disk.</para>
		/// </param>
		/// <returns>
		/// If the function succeeds, the return value is nonzero. If the function fails, the return value is zero.To get extended error information, call GetLastError.
		/// </returns>
		[DllImport(Lib.Kernel32, SetLastError = true, CharSet = CharSet.Auto)]
		[return: MarshalAs(UnmanagedType.Bool)]
		[PInvokeData("FileAPI.h", MSDNShortId = "aa364935")]
		public static extern bool GetDiskFreeSpace(string lpRootPathName, out uint lpSectorsPerCluster, out uint lpBytesPerSector, out uint lpNumberOfFreeClusters, out uint lpTotalNumberOfClusters);

		/// <summary>
		/// Retrieves information about the amount of space that is available on a disk volume, which is the total amount of space, the total amount of free
		/// space, and the total amount of free space available to the user that is associated with the calling thread.
		/// </summary>
		/// <param name="lpDirectoryName">
		/// A directory on the disk.
		/// <para>If this parameter is NULL, the function uses the root of the current disk.</para>
		/// <para>If this parameter is a UNC name, it must include a trailing backslash, for example, "\\MyServer\MyShare\".</para>
		/// <para>This parameter does not have to specify the root directory on a disk. The function accepts any directory on a disk.</para>
		/// <para>The calling application must have FILE_LIST_DIRECTORY access rights for this directory.</para>
		/// </param>
		/// <param name="lpFreeBytesAvailable">
		/// A pointer to a variable that receives the total number of free bytes on a disk that are available to the user who is associated with the calling thread.
		/// <para>This parameter can be NULL.</para>
		/// <para>If per-user quotas are being used, this value may be less than the total number of free bytes on a disk.</para>
		/// </param>
		/// <param name="lpTotalNumberOfBytes">
		/// A pointer to a variable that receives the total number of bytes on a disk that are available to the user who is associated with the calling thread.
		/// <para>This parameter can be NULL.</para>
		/// <para>If per-user quotas are being used, this value may be less than the total number of bytes on a disk.</para>
		/// <para>To determine the total number of bytes on a disk or volume, use IOCTL_DISK_GET_LENGTH_INFO.</para>
		/// </param>
		/// <param name="lpTotalNumberOfFreeBytes">
		/// A pointer to a variable that receives the total number of free bytes on a disk.
		/// <para>This parameter can be NULL.</para>
		/// </param>
		/// <returns>
		/// If the function succeeds, the return value is nonzero. If the function fails, the return value is zero.To get extended error information, call GetLastError.
		/// </returns>
		[DllImport(Lib.Kernel32, SetLastError = true, CharSet = CharSet.Auto)]
		[return: MarshalAs(UnmanagedType.Bool)]
		[PInvokeData("FileAPI.h", MSDNShortId = "aa364937")]
		public static extern bool GetDiskFreeSpaceEx(string lpDirectoryName, out ulong lpFreeBytesAvailable, out ulong lpTotalNumberOfBytes, out ulong lpTotalNumberOfFreeBytes);

		/// <summary>Retrieves information about the file system and volume associated with the specified root directory.</summary>
		/// <param name="lpRootPathName">
		/// A pointer to a string that contains the root directory of the volume to be described.
		/// <para>
		/// If this parameter is NULL, the root of the current directory is used. A trailing backslash is required. For example, you specify \\MyServer\MyShare
		/// as "\\MyServer\MyShare\", or the C drive as "C:\".
		/// </para>
		/// </param>
		/// <param name="lpVolumeNameBuffer">
		/// A pointer to a buffer that receives the name of a specified volume. The buffer size is specified by the <paramref name="nVolumeNameSize"/> parameter.
		/// </param>
		/// <param name="nVolumeNameSize">
		/// The length of a volume name buffer, in TCHARs. The maximum buffer size is MAX_PATH+1.
		/// <para>This parameter is ignored if the volume name buffer is not supplied.</para>
		/// </param>
		/// <param name="lpVolumeSerialNumber">
		/// A pointer to a variable that receives the volume serial number.
		/// <para>This parameter can be NULL if the serial number is not required.</para>
		/// <para>
		/// This function returns the volume serial number that the operating system assigns when a hard disk is formatted. To programmatically obtain the hard
		/// disk's serial number that the manufacturer assigns, use the Windows Management Instrumentation (WMI) Win32_PhysicalMedia property SerialNumber.
		/// </para>
		/// </param>
		/// <param name="lpMaximumComponentLength">
		/// A pointer to a variable that receives the maximum length, in TCHARs, of a file name component that a specified file system supports.
		/// <para>A file name component is the portion of a file name between backslashes.</para>
		/// <para>
		/// The value that is stored in the variable that <paramref name="lpMaximumComponentLength"/> points to is used to indicate that a specified file system
		/// supports long names. For example, for a FAT file system that supports long names, the function stores the value 255, rather than the previous 8.3
		/// indicator. Long names can also be supported on systems that use the NTFS file system.
		/// </para>
		/// </param>
		/// <param name="lpFileSystemFlags">
		/// A pointer to a variable that receives flags associated with the specified file system.
		/// <para>
		/// This parameter can be one or more of the <see cref="FileSystemFlags"/> values. However, FILE_FILE_COMPRESSION and FILE_VOL_IS_COMPRESSED are mutually exclusive.
		/// </para>
		/// </param>
		/// <param name="lpFileSystemNameBuffer">
		/// A pointer to a buffer that receives the name of the file system, for example, the FAT file system or the NTFS file system. The buffer size is
		/// specified by the <paramref name="nFileSystemNameSize"/> parameter.
		/// </param>
		/// <param name="nFileSystemNameSize">
		/// The length of the file system name buffer, in TCHARs. The maximum buffer size is MAX_PATH+1.
		/// <para>This parameter is ignored if the file system name buffer is not supplied.</para>
		/// </param>
		/// <returns>
		/// If all the requested information is retrieved, the return value is nonzero.
		/// <para>If not all the requested information is retrieved, the return value is zero. To get extended error information, call GetLastError.</para>
		/// </returns>
		/// <remarks>
		/// When a user attempts to get information about a floppy drive that does not have a floppy disk, or a CD-ROM drive that does not have a compact disc,
		/// the system displays a message box for the user to insert a floppy disk or a compact disc, respectively. To prevent the system from displaying this
		/// message box, call the SetErrorMode function with SEM_FAILCRITICALERRORS.
		/// <para>
		/// The FILE_VOL_IS_COMPRESSED flag is the only indicator of volume-based compression. The file system name is not altered to indicate compression, for
		/// example, this flag is returned set on a DoubleSpace volume. When compression is volume-based, an entire volume is compressed or not compressed.
		/// </para>
		/// <para>
		/// The FILE_FILE_COMPRESSION flag indicates whether a file system supports file-based compression. When compression is file-based, individual files can
		/// be compressed or not compressed.
		/// </para>
		/// <para>The FILE_FILE_COMPRESSION and FILE_VOL_IS_COMPRESSED flags are mutually exclusive. Both bits cannot be returned set.</para>
		/// <para>
		/// The maximum component length value that is stored in lpMaximumComponentLength is the only indicator that a volume supports longer-than-normal FAT
		/// file system (or other file system) file names. The file system name is not altered to indicate support for long file names.
		/// </para>
		/// <para>
		/// The GetCompressedFileSize function obtains the compressed size of a file. The GetFileAttributes function can determine whether an individual file is compressed.
		/// </para>
		/// <para>Symbolic link behavior—</para>
		/// <para>If the path points to a symbolic link, the function returns volume information for the target.</para>
		/// </remarks>
		[DllImport(Lib.Kernel32, SetLastError = true, CharSet = CharSet.Auto)]
		[return: MarshalAs(UnmanagedType.Bool)]
		[PInvokeData("FileAPI.h", MSDNShortId = "aa364993")]
		public static extern bool GetVolumeInformation(string lpRootPathName, StringBuilder lpVolumeNameBuffer, int nVolumeNameSize, ref uint lpVolumeSerialNumber, ref uint lpMaximumComponentLength, ref FileSystemFlags lpFileSystemFlags, StringBuilder lpFileSystemNameBuffer, int nFileSystemNameSize);

		/// <summary>Retrieves information about the file system and volume associated with the specified root directory.</summary>
		/// <param name="rootPathName">
		/// A string that contains the root directory of the volume to be described.
		/// <para>
		/// If this parameter is NULL, the root of the current directory is used. A trailing backslash is required. For example, you specify \\MyServer\MyShare
		/// as "\\MyServer\MyShare\", or the C drive as "C:\".
		/// </para>
		/// </param>
		/// <param name="volumeName">Receives the name of a specified volume.</param>
		/// <param name="volumeSerialNumber">
		/// Receives the volume serial number.
		/// <para>
		/// This function returns the volume serial number that the operating system assigns when a hard disk is formatted. To programmatically obtain the hard
		/// disk's serial number that the manufacturer assigns, use the Windows Management Instrumentation (WMI) Win32_PhysicalMedia property SerialNumber.
		/// </para>
		/// </param>
		/// <param name="maximumComponentLength">
		/// Receives the maximum length, in characters, of a file name component that a specified file system supports.
		/// <para>A file name component is the portion of a file name between backslashes.</para>
		/// <para>
		/// The value that is stored in the variable that <paramref name="maximumComponentLength"/> returns is used to indicate that a specified file system
		/// supports long names. For example, for a FAT file system that supports long names, the function stores the value 255, rather than the previous 8.3
		/// indicator. Long names can also be supported on systems that use the NTFS file system.
		/// </para>
		/// </param>
		/// <param name="fileSystemFlags">
		/// Receives the flags associated with the specified file system.
		/// <para>
		/// This parameter can be one or more of the <see cref="FileSystemFlags"/> values. However, FILE_FILE_COMPRESSION and FILE_VOL_IS_COMPRESSED are mutually exclusive.
		/// </para>
		/// </param>
		/// <param name="fileSystemName">Receives the name of the file system, for example, the FAT file system or the NTFS file system.</param>
		/// <returns>
		/// If all the requested information is retrieved, the return value is nonzero.
		/// <para>If not all the requested information is retrieved, the return value is zero. To get extended error information, call GetLastError.</para>
		/// </returns>
		/// <remarks>
		/// When a user attempts to get information about a floppy drive that does not have a floppy disk, or a CD-ROM drive that does not have a compact disc,
		/// the system displays a message box for the user to insert a floppy disk or a compact disc, respectively. To prevent the system from displaying this
		/// message box, call the SetErrorMode function with SEM_FAILCRITICALERRORS.
		/// <para>
		/// The FILE_VOL_IS_COMPRESSED flag is the only indicator of volume-based compression. The file system name is not altered to indicate compression, for
		/// example, this flag is returned set on a DoubleSpace volume. When compression is volume-based, an entire volume is compressed or not compressed.
		/// </para>
		/// <para>
		/// The FILE_FILE_COMPRESSION flag indicates whether a file system supports file-based compression. When compression is file-based, individual files can
		/// be compressed or not compressed.
		/// </para>
		/// <para>The FILE_FILE_COMPRESSION and FILE_VOL_IS_COMPRESSED flags are mutually exclusive. Both bits cannot be returned set.</para>
		/// <para>
		/// The maximum component length value that is stored in lpMaximumComponentLength is the only indicator that a volume supports longer-than-normal FAT
		/// file system (or other file system) file names. The file system name is not altered to indicate support for long file names.
		/// </para>
		/// <para>
		/// The GetCompressedFileSize function obtains the compressed size of a file. The GetFileAttributes function can determine whether an individual file is compressed.
		/// </para>
		/// <para>Symbolic link behavior—</para>
		/// <para>If the path points to a symbolic link, the function returns volume information for the target.</para>
		/// </remarks>
		[PInvokeData("FileAPI.h", MSDNShortId = "aa364993")]
		public static bool GetVolumeInformation(string rootPathName, out string volumeName, out uint volumeSerialNumber,
			out uint maximumComponentLength, out FileSystemFlags fileSystemFlags, out string fileSystemName)
		{
			var sb1 = new StringBuilder(MAX_PATH + 1);
			var sn = 0U;
			var cl = 0U;
			FileSystemFlags flags = 0;
			var sb2 = new StringBuilder(MAX_PATH + 1);
			var ret = GetVolumeInformation(rootPathName, sb1, sb1.Capacity, ref sn, ref cl, ref flags, sb2, sb2.Capacity);
			volumeName = sb1.ToString();
			volumeSerialNumber = sn;
			maximumComponentLength = cl;
			fileSystemFlags = flags;
			fileSystemName = sb2.ToString();
			return ret;
		}

		/// <summary>
		/// Retrieves information about MS-DOS device names. The function can obtain the current mapping for a particular MS-DOS device name. The function can
		/// also obtain a list of all existing MS-DOS device names.
		/// <para>
		/// MS-DOS device names are stored as junctions in the object namespace. The code that converts an MS-DOS path into a corresponding path uses these
		/// junctions to map MS-DOS devices and drive letters. The QueryDosDevice function enables an application to query the names of the junctions used to
		/// implement the MS-DOS device namespace as well as the value of each specific junction.
		/// </para>
		/// </summary>
		/// <param name="lpDeviceName">
		/// An MS-DOS device name string specifying the target of the query. The device name cannot have a trailing backslash; for example, use "C:", not "C:\".
		/// <para>
		/// This parameter can be NULL. In that case, the QueryDosDevice function will store a list of all existing MS-DOS device names into the buffer pointed
		/// to by <paramref name="lpTargetPath"/>.
		/// </para>
		/// </param>
		/// <param name="lpTargetPath">
		/// A pointer to a buffer that will receive the result of the query. The function fills this buffer with one or more null-terminated strings. The final
		/// null-terminated string is followed by an additional NULL.
		/// <para>
		/// If <paramref name="lpDeviceName"/> is non-NULL, the function retrieves information about the particular MS-DOS device specified by <paramref
		/// name="lpDeviceName"/>. The first null-terminated string stored into the buffer is the current mapping for the device. The other null-terminated
		/// strings represent undeleted prior mappings for the device.
		/// </para>
		/// <para>
		/// If <paramref name="lpDeviceName"/> is NULL, the function retrieves a list of all existing MS-DOS device names. Each null-terminated string stored
		/// into the buffer is the name of an existing MS-DOS device, for example, \Device\HarddiskVolume1 or \Device\Floppy0.
		/// </para>
		/// </param>
		/// <param name="ucchMax">The maximum number of TCHARs that can be stored into the buffer pointed to by <paramref name="lpTargetPath"/>.</param>
		/// <returns>
		/// If the function succeeds, the return value is the number of TCHARs stored into the buffer pointed to by <paramref name="lpTargetPath"/>.
		/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
		/// <para>If the buffer is too small, the function fails and the last error code is ERROR_INSUFFICIENT_BUFFER.</para>
		/// </returns>
		/// <remarks>
		/// The DefineDosDevice function enables an application to create and modify the junctions used to implement the MS-DOS device namespace.
		/// <para>
		/// <c>Windows Server 2003 and Windows XP:</c><c>QueryDosDevice</c> first searches the Local MS-DOS Device namespace for the specified device name. If
		/// the device name is not found, the function will then search the Global MS-DOS Device namespace.
		/// </para>
		/// <para>
		/// When all existing MS-DOS device names are queried, the list of device names that are returned is dependent on whether it is running in the
		/// "LocalSystem" context. If so, only the device names included in the Global MS-DOS Device namespace will be returned. If not, a concatenation of the
		/// device names in the Global and Local MS-DOS Device namespaces will be returned. If a device name exists in both namespaces, <c>QueryDosDevice</c>
		/// will return the entry in the Local MS-DOS Device namespace.
		/// </para>
		/// </remarks>
		[DllImport(Lib.Kernel32, SetLastError = true, CharSet = CharSet.Auto)]
		[PInvokeData("FileAPI.h", MSDNShortId = "aa365461")]
		public static extern int QueryDosDevice(string lpDeviceName, StringBuilder lpTargetPath, int ucchMax);

		/// <summary>
		/// Retrieves information about MS-DOS device names. The function can obtain the current mapping for a particular MS-DOS device name. The function can
		/// also obtain a list of all existing MS-DOS device names.
		/// <para>
		/// MS-DOS device names are stored as junctions in the object namespace. The code that converts an MS-DOS path into a corresponding path uses these
		/// junctions to map MS-DOS devices and drive letters. The QueryDosDevice function enables an application to query the names of the junctions used to
		/// implement the MS-DOS device namespace as well as the value of each specific junction.
		/// </para>
		/// </summary>
		/// <param name="deviceName">
		/// An MS-DOS device name string specifying the target of the query. The device name cannot have a trailing backslash; for example, use "C:", not "C:\".
		/// <para>This parameter can be NULL. In that case, the QueryDosDevice function will return a list of all existing MS-DOS device names.</para>
		/// </param>
		/// <returns>
		/// <para>
		/// If <paramref name="deviceName"/> is non-NULL, the function returns information about the particular MS-DOS device specified by <paramref
		/// name="deviceName"/>. The first string returned is the current mapping for the device. The other strings represent undeleted prior mappings for the device.
		/// </para>
		/// <para>
		/// If <paramref name="deviceName"/> is NULL, the function returns a list of all existing MS-DOS device names. Each string returned is the name of an
		/// existing MS-DOS device, for example, \Device\HarddiskVolume1 or \Device\Floppy0.
		/// </para>
		/// </returns>
		[PInvokeData("FileAPI.h", MSDNShortId = "aa365461")]
		public static IEnumerable<string> QueryDosDevice(string deviceName)
		{
			deviceName = deviceName?.TrimEnd('\\');
			var bytes = 16;
			var retLen = 0;
			using (var mem = new SafeHGlobalHandle(0))
			{
				do
				{
					mem.Size = (bytes *= 4);
					retLen = QueryDosDevice(deviceName, (IntPtr)mem, mem.Size / Marshal.SystemDefaultCharSize);
				} while (retLen == 0 && Win32Error.GetLastError() == Win32Error.ERROR_INSUFFICIENT_BUFFER);
				if (retLen == 0) throw new Win32Exception();
				return mem.ToStringEnum().ToArray();
			}
		}

		/// <summary>
		/// Reads data from the specified file or input/output (I/O) device. Reads occur at the position specified by the file pointer if supported by the device.
		/// </summary>
		/// <param name="hFile">A handle to the device (for example, a file, file stream, physical disk, volume, console buffer, tape drive, socket, communications resource, mailslot, or pipe). The hFile parameter must have been created with read access. </param>
		/// <param name="lpBuffer">A pointer to the buffer that receives the data read from a file or device.</param>
		/// <param name="nNumberOfBytesToRead">The maximum number of bytes to be read.</param>
		/// <param name="lpNumberOfBytesRead">A pointer to the variable that receives the number of bytes read when using a synchronous hFile parameter. ReadFile sets this value to zero before doing any work or error checking. Use NULL for this parameter if this is an asynchronous operation to avoid potentially erroneous results.
		/// <para>This parameter can be NULL only when the lpOverlapped parameter is not NULL.</para></param>
		/// <param name="lpOverlapped">A pointer to an OVERLAPPED structure is required if the hFile parameter was opened with FILE_FLAG_OVERLAPPED, otherwise it can be NULL.
		/// <para>If hFile is opened with FILE_FLAG_OVERLAPPED, the lpOverlapped parameter must point to a valid and unique OVERLAPPED structure, otherwise the function can incorrectly report that the read operation is complete.</para>
		/// <para>For an hFile that supports byte offsets, if you use this parameter you must specify a byte offset at which to start reading from the file or device. This offset is specified by setting the Offset and OffsetHigh members of the OVERLAPPED structure. For an hFile that does not support byte offsets, Offset and OffsetHigh are ignored.</para>
		/// <para>For more information about different combinations of lpOverlapped and FILE_FLAG_OVERLAPPED, see the Remarks section and the Synchronization and File Position section.</para></param>
		/// <returns>If the function succeeds, the return value is nonzero (TRUE). If the function fails, or is completing asynchronously, the return value is zero(FALSE). To get extended error information, call the GetLastError function.</returns>
		[DllImport(Lib.Kernel32, ExactSpelling = true, SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		[PInvokeData("FileAPI.h", MSDNShortId = "aa365467")]
		public static extern bool ReadFile(SafeFileHandle hFile, IntPtr lpBuffer, uint nNumberOfBytesToRead, out uint lpNumberOfBytesRead, IntPtr lpOverlapped);

		/// <summary>
		/// Reads data from the specified file or input/output (I/O) device. Reads occur at the position specified by the file pointer if supported by the device.
		/// </summary>
		/// <param name="hFile">A handle to the device (for example, a file, file stream, physical disk, volume, console buffer, tape drive, socket, communications resource, mailslot, or pipe). The hFile parameter must have been created with read access. </param>
		/// <param name="lpBuffer">A pointer to the buffer that receives the data read from a file or device.</param>
		/// <param name="nNumberOfBytesToRead">The maximum number of bytes to be read.</param>
		/// <param name="lpNumberOfBytesRead">A pointer to the variable that receives the number of bytes read when using a synchronous hFile parameter. ReadFile sets this value to zero before doing any work or error checking. Use NULL for this parameter if this is an asynchronous operation to avoid potentially erroneous results.
		/// <para>This parameter can be NULL only when the lpOverlapped parameter is not NULL.</para></param>
		/// <param name="lpOverlapped">A pointer to an OVERLAPPED structure is required if the hFile parameter was opened with FILE_FLAG_OVERLAPPED, otherwise it can be NULL.
		/// <para>If hFile is opened with FILE_FLAG_OVERLAPPED, the lpOverlapped parameter must point to a valid and unique OVERLAPPED structure, otherwise the function can incorrectly report that the read operation is complete.</para>
		/// <para>For an hFile that supports byte offsets, if you use this parameter you must specify a byte offset at which to start reading from the file or device. This offset is specified by setting the Offset and OffsetHigh members of the OVERLAPPED structure. For an hFile that does not support byte offsets, Offset and OffsetHigh are ignored.</para>
		/// <para>For more information about different combinations of lpOverlapped and FILE_FLAG_OVERLAPPED, see the Remarks section and the Synchronization and File Position section.</para></param>
		/// <returns>If the function succeeds, the return value is nonzero (TRUE). If the function fails, or is completing asynchronously, the return value is zero(FALSE). To get extended error information, call the GetLastError function.</returns>
		[DllImport(Lib.Kernel32, ExactSpelling = true, SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		[PInvokeData("FileAPI.h", MSDNShortId = "aa365467")]
		public static extern unsafe bool ReadFile(SafeFileHandle hFile, byte* lpBuffer, uint nNumberOfBytesToRead, IntPtr lpNumberOfBytesRead, NativeOverlapped* lpOverlapped);

		/// <summary>
		/// Reads data from the specified file or input/output (I/O) device. Reads occur at the position specified by the file pointer if supported by the device.
		/// </summary>
		/// <param name="hFile">A handle to the device (for example, a file, file stream, physical disk, volume, console buffer, tape drive, socket, communications resource, mailslot, or pipe). The hFile parameter must have been created with read access. </param>
		/// <param name="lpBuffer">A pointer to the buffer that receives the data read from a file or device.</param>
		/// <param name="nNumberOfBytesToRead">The maximum number of bytes to be read.</param>
		/// <param name="lpNumberOfBytesRead">A pointer to the variable that receives the number of bytes read when using a synchronous hFile parameter. ReadFile sets this value to zero before doing any work or error checking. Use NULL for this parameter if this is an asynchronous operation to avoid potentially erroneous results.
		/// <para>This parameter can be NULL only when the lpOverlapped parameter is not NULL.</para></param>
		/// <param name="lpOverlapped">A pointer to an OVERLAPPED structure is required if the hFile parameter was opened with FILE_FLAG_OVERLAPPED, otherwise it can be NULL.
		/// <para>If hFile is opened with FILE_FLAG_OVERLAPPED, the lpOverlapped parameter must point to a valid and unique OVERLAPPED structure, otherwise the function can incorrectly report that the read operation is complete.</para>
		/// <para>For an hFile that supports byte offsets, if you use this parameter you must specify a byte offset at which to start reading from the file or device. This offset is specified by setting the Offset and OffsetHigh members of the OVERLAPPED structure. For an hFile that does not support byte offsets, Offset and OffsetHigh are ignored.</para>
		/// <para>For more information about different combinations of lpOverlapped and FILE_FLAG_OVERLAPPED, see the Remarks section and the Synchronization and File Position section.</para></param>
		/// <returns>If the function succeeds, the return value is nonzero (TRUE). If the function fails, or is completing asynchronously, the return value is zero(FALSE). To get extended error information, call the GetLastError function.</returns>
		[DllImport(Lib.Kernel32, ExactSpelling = true, SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		[PInvokeData("FileAPI.h", MSDNShortId = "aa365467")]
		public static extern bool ReadFile(SafeFileHandle hFile, byte[] lpBuffer, uint nNumberOfBytesToRead, out uint lpNumberOfBytesRead, IntPtr lpOverlapped);

		/// <summary>Moves the file pointer of the specified file.</summary>
		/// <param name="hFile">A handle to the file. The file handle must have been created with the GENERIC_READ or GENERIC_WRITE access right. For more information, see File Security and Access Rights.</param>
		/// <param name="liDistanceToMove">The number of bytes to move the file pointer. A positive value moves the pointer forward in the file and a negative value moves the file pointer backward.</param>
		/// <param name="lpNewFilePointer">A pointer to a variable to receive the new file pointer. If this parameter is NULL, the new file pointer is not returned.</param>
		/// <param name="dwMoveMethod">The starting point for the file pointer move.</param>
		/// <returns>If the function succeeds, the return value is nonzero. If the function fails, the return value is zero.To get extended error information, call GetLastError.</returns>
		[DllImport(Lib.Kernel32, ExactSpelling = true, SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		[PInvokeData("FileAPI.h", MSDNShortId = "aa365541")]
		public static extern bool SetFilePointerEx(SafeFileHandle hFile, long liDistanceToMove, out long lpNewFilePointer, SeekOrigin dwMoveMethod);

		/// <summary>
		/// Writes data to the specified file or input/output (I/O) device.
		/// <para>This function is designed for both synchronous and asynchronous operation. For a similar function designed solely for asynchronous operation, see WriteFileEx.</para>
		/// </summary>
		/// <param name="hFile">A handle to the file or I/O device (for example, a file, file stream, physical disk, volume, console buffer, tape drive, socket, communications resource, mailslot, or pipe).
		/// <para>The hFile parameter must have been created with the write access. For more information, see Generic Access Rights and File Security and Access Rights.</para>
		/// <para>For asynchronous write operations, hFile can be any handle opened with the CreateFile function using the FILE_FLAG_OVERLAPPED flag or a socket handle returned by the socket or accept function.</para></param>
		/// <param name="lpBuffer">A pointer to the buffer containing the data to be written to the file or device.
		/// <para>This buffer must remain valid for the duration of the write operation. The caller must not use this buffer until the write operation is completed.</para></param>
		/// <param name="nNumberOfBytesToWrite">The number of bytes to be written to the file or device.
		/// <para>A value of zero specifies a null write operation. The behavior of a null write operation depends on the underlying file system or communications technology.</para>
		/// <para>Windows Server 2003 and Windows XP:  Pipe write operations across a network are limited in size per write. The amount varies per platform. For x86 platforms it's 63.97 MB. For x64 platforms it's 31.97 MB. For Itanium it's 63.95 MB. For more information regarding pipes, see the Remarks section.</para></param>
		/// <param name="lpNumberOfBytesWritten">A pointer to the variable that receives the number of bytes written when using a synchronous hFile parameter. WriteFile sets this value to zero before doing any work or error checking. Use NULL for this parameter if this is an asynchronous operation to avoid potentially erroneous results.
		/// <para>This parameter can be NULL only when the lpOverlapped parameter is not NULL.</para>
		/// <para>For more information, see the Remarks section.</para></param>
		/// <param name="lpOverlapped">A pointer to an OVERLAPPED structure is required if the hFile parameter was opened with FILE_FLAG_OVERLAPPED, otherwise this parameter can be NULL.
		/// <para>For an hFile that supports byte offsets, if you use this parameter you must specify a byte offset at which to start writing to the file or device. This offset is specified by setting the Offset and OffsetHigh members of the OVERLAPPED structure. For an hFile that does not support byte offsets, Offset and OffsetHigh are ignored.</para>
		/// <para>To write to the end of file, specify both the Offset and OffsetHigh members of the OVERLAPPED structure as 0xFFFFFFFF. This is functionally equivalent to previously calling the CreateFile function to open hFile using FILE_APPEND_DATA access.</para>
		/// <para>For more information about different combinations of lpOverlapped and FILE_FLAG_OVERLAPPED, see the Remarks section and the Synchronization and File Position section.</para></param>
		/// <returns>If the function succeeds, the return value is nonzero (TRUE). If the function fails, or is completing asynchronously, the return value is zero(FALSE). To get extended error information, call the GetLastError function.</returns>
		[DllImport(Lib.Kernel32, ExactSpelling = true, SetLastError = true), SuppressUnmanagedCodeSecurity]
		[return: MarshalAs(UnmanagedType.Bool)]
		[PInvokeData("FileAPI.h", MSDNShortId = "aa365747")]
		public static extern bool WriteFile(SafeFileHandle hFile, IntPtr lpBuffer, uint nNumberOfBytesToWrite, out uint lpNumberOfBytesWritten, IntPtr lpOverlapped);

		/// <summary>
		/// Writes data to the specified file or input/output (I/O) device.
		/// <para>This function is designed for both synchronous and asynchronous operation. For a similar function designed solely for asynchronous operation, see WriteFileEx.</para>
		/// </summary>
		/// <param name="hFile">A handle to the file or I/O device (for example, a file, file stream, physical disk, volume, console buffer, tape drive, socket, communications resource, mailslot, or pipe).
		/// <para>The hFile parameter must have been created with the write access. For more information, see Generic Access Rights and File Security and Access Rights.</para>
		/// <para>For asynchronous write operations, hFile can be any handle opened with the CreateFile function using the FILE_FLAG_OVERLAPPED flag or a socket handle returned by the socket or accept function.</para></param>
		/// <param name="lpBuffer">A pointer to the buffer containing the data to be written to the file or device.
		/// <para>This buffer must remain valid for the duration of the write operation. The caller must not use this buffer until the write operation is completed.</para></param>
		/// <param name="nNumberOfBytesToWrite">The number of bytes to be written to the file or device.
		/// <para>A value of zero specifies a null write operation. The behavior of a null write operation depends on the underlying file system or communications technology.</para>
		/// <para>Windows Server 2003 and Windows XP:  Pipe write operations across a network are limited in size per write. The amount varies per platform. For x86 platforms it's 63.97 MB. For x64 platforms it's 31.97 MB. For Itanium it's 63.95 MB. For more information regarding pipes, see the Remarks section.</para></param>
		/// <param name="lpNumberOfBytesWritten">A pointer to the variable that receives the number of bytes written when using a synchronous hFile parameter. WriteFile sets this value to zero before doing any work or error checking. Use NULL for this parameter if this is an asynchronous operation to avoid potentially erroneous results.
		/// <para>This parameter can be NULL only when the lpOverlapped parameter is not NULL.</para>
		/// <para>For more information, see the Remarks section.</para></param>
		/// <param name="lpOverlapped">A pointer to an OVERLAPPED structure is required if the hFile parameter was opened with FILE_FLAG_OVERLAPPED, otherwise this parameter can be NULL.
		/// <para>For an hFile that supports byte offsets, if you use this parameter you must specify a byte offset at which to start writing to the file or device. This offset is specified by setting the Offset and OffsetHigh members of the OVERLAPPED structure. For an hFile that does not support byte offsets, Offset and OffsetHigh are ignored.</para>
		/// <para>To write to the end of file, specify both the Offset and OffsetHigh members of the OVERLAPPED structure as 0xFFFFFFFF. This is functionally equivalent to previously calling the CreateFile function to open hFile using FILE_APPEND_DATA access.</para>
		/// <para>For more information about different combinations of lpOverlapped and FILE_FLAG_OVERLAPPED, see the Remarks section and the Synchronization and File Position section.</para></param>
		/// <returns>If the function succeeds, the return value is nonzero (TRUE). If the function fails, or is completing asynchronously, the return value is zero(FALSE). To get extended error information, call the GetLastError function.</returns>
		[DllImport(Lib.Kernel32, ExactSpelling = true, SetLastError = true), SuppressUnmanagedCodeSecurity]
		[return: MarshalAs(UnmanagedType.Bool)]
		[PInvokeData("FileAPI.h", MSDNShortId = "aa365747")]
		public static extern unsafe bool WriteFile(SafeFileHandle hFile, byte* lpBuffer, uint nNumberOfBytesToWrite, IntPtr lpNumberOfBytesWritten, NativeOverlapped* lpOverlapped);

		/// <summary>
		/// Writes data to the specified file or input/output (I/O) device.
		/// <para>This function is designed for both synchronous and asynchronous operation. For a similar function designed solely for asynchronous operation, see WriteFileEx.</para>
		/// </summary>
		/// <param name="hFile">A handle to the file or I/O device (for example, a file, file stream, physical disk, volume, console buffer, tape drive, socket, communications resource, mailslot, or pipe).
		/// <para>The hFile parameter must have been created with the write access. For more information, see Generic Access Rights and File Security and Access Rights.</para>
		/// <para>For asynchronous write operations, hFile can be any handle opened with the CreateFile function using the FILE_FLAG_OVERLAPPED flag or a socket handle returned by the socket or accept function.</para></param>
		/// <param name="lpBuffer">A pointer to the buffer containing the data to be written to the file or device.
		/// <para>This buffer must remain valid for the duration of the write operation. The caller must not use this buffer until the write operation is completed.</para></param>
		/// <param name="nNumberOfBytesToWrite">The number of bytes to be written to the file or device.
		/// <para>A value of zero specifies a null write operation. The behavior of a null write operation depends on the underlying file system or communications technology.</para>
		/// <para>Windows Server 2003 and Windows XP:  Pipe write operations across a network are limited in size per write. The amount varies per platform. For x86 platforms it's 63.97 MB. For x64 platforms it's 31.97 MB. For Itanium it's 63.95 MB. For more information regarding pipes, see the Remarks section.</para></param>
		/// <param name="lpNumberOfBytesWritten">A pointer to the variable that receives the number of bytes written when using a synchronous hFile parameter. WriteFile sets this value to zero before doing any work or error checking. Use NULL for this parameter if this is an asynchronous operation to avoid potentially erroneous results.
		/// <para>This parameter can be NULL only when the lpOverlapped parameter is not NULL.</para>
		/// <para>For more information, see the Remarks section.</para></param>
		/// <param name="lpOverlapped">A pointer to an OVERLAPPED structure is required if the hFile parameter was opened with FILE_FLAG_OVERLAPPED, otherwise this parameter can be NULL.
		/// <para>For an hFile that supports byte offsets, if you use this parameter you must specify a byte offset at which to start writing to the file or device. This offset is specified by setting the Offset and OffsetHigh members of the OVERLAPPED structure. For an hFile that does not support byte offsets, Offset and OffsetHigh are ignored.</para>
		/// <para>To write to the end of file, specify both the Offset and OffsetHigh members of the OVERLAPPED structure as 0xFFFFFFFF. This is functionally equivalent to previously calling the CreateFile function to open hFile using FILE_APPEND_DATA access.</para>
		/// <para>For more information about different combinations of lpOverlapped and FILE_FLAG_OVERLAPPED, see the Remarks section and the Synchronization and File Position section.</para></param>
		/// <returns>If the function succeeds, the return value is nonzero (TRUE). If the function fails, or is completing asynchronously, the return value is zero(FALSE). To get extended error information, call the GetLastError function.</returns>
		[DllImport(Lib.Kernel32, ExactSpelling = true, SetLastError = true), SuppressUnmanagedCodeSecurity]
		[return: MarshalAs(UnmanagedType.Bool)]
		[PInvokeData("FileAPI.h", MSDNShortId = "aa365747")]
		public static extern bool WriteFile(SafeFileHandle hFile, byte[] lpBuffer, uint nNumberOfBytesToWrite, out uint lpNumberOfBytesWritten, IntPtr lpOverlapped);

		/// <summary>
		/// Retrieves information about MS-DOS device names. The function can obtain the current mapping for a particular MS-DOS device name. The function can
		/// also obtain a list of all existing MS-DOS device names.
		/// <para>
		/// MS-DOS device names are stored as junctions in the object namespace. The code that converts an MS-DOS path into a corresponding path uses these
		/// junctions to map MS-DOS devices and drive letters. The QueryDosDevice function enables an application to query the names of the junctions used to
		/// implement the MS-DOS device namespace as well as the value of each specific junction.
		/// </para>
		/// </summary>
		/// <param name="lpDeviceName">
		/// An MS-DOS device name string specifying the target of the query. The device name cannot have a trailing backslash; for example, use "C:", not "C:\".
		/// <para>
		/// This parameter can be NULL. In that case, the QueryDosDevice function will store a list of all existing MS-DOS device names into the buffer pointed
		/// to by <paramref name="lpTargetPath"/>.
		/// </para>
		/// </param>
		/// <param name="lpTargetPath">
		/// A pointer to a buffer that will receive the result of the query. The function fills this buffer with one or more null-terminated strings. The final
		/// null-terminated string is followed by an additional NULL.
		/// <para>
		/// If <paramref name="lpDeviceName"/> is non-NULL, the function retrieves information about the particular MS-DOS device specified by <paramref
		/// name="lpDeviceName"/>. The first null-terminated string stored into the buffer is the current mapping for the device. The other null-terminated
		/// strings represent undeleted prior mappings for the device.
		/// </para>
		/// <para>
		/// If <paramref name="lpDeviceName"/> is NULL, the function retrieves a list of all existing MS-DOS device names. Each null-terminated string stored
		/// into the buffer is the name of an existing MS-DOS device, for example, \Device\HarddiskVolume1 or \Device\Floppy0.
		/// </para>
		/// </param>
		/// <param name="ucchMax">The maximum number of TCHARs that can be stored into the buffer pointed to by <paramref name="lpTargetPath"/>.</param>
		/// <returns>
		/// If the function succeeds, the return value is the number of TCHARs stored into the buffer pointed to by <paramref name="lpTargetPath"/>.
		/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
		/// <para>If the buffer is too small, the function fails and the last error code is ERROR_INSUFFICIENT_BUFFER.</para>
		/// </returns>
		/// <remarks>
		/// The DefineDosDevice function enables an application to create and modify the junctions used to implement the MS-DOS device namespace.
		/// <para>
		/// <c>Windows Server 2003 and Windows XP:</c><c>QueryDosDevice</c> first searches the Local MS-DOS Device namespace for the specified device name. If
		/// the device name is not found, the function will then search the Global MS-DOS Device namespace.
		/// </para>
		/// <para>
		/// When all existing MS-DOS device names are queried, the list of device names that are returned is dependent on whether it is running in the
		/// "LocalSystem" context. If so, only the device names included in the Global MS-DOS Device namespace will be returned. If not, a concatenation of the
		/// device names in the Global and Local MS-DOS Device namespaces will be returned. If a device name exists in both namespaces, <c>QueryDosDevice</c>
		/// will return the entry in the Local MS-DOS Device namespace.
		/// </para>
		/// </remarks>
		[DllImport(Lib.Kernel32, SetLastError = true, CharSet = CharSet.Auto)]
		[PInvokeData("FileAPI.h", MSDNShortId = "aa365461")]
		private static extern int QueryDosDevice(string lpDeviceName, IntPtr lpTargetPath, int ucchMax);
	}
}