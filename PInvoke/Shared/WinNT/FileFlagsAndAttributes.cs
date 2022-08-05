using System;

namespace Vanara.PInvoke;

/// <summary>
/// File attributes are metadata values stored by the file system on disk and are used by the system and are available to developers via
/// various file I/O APIs.
/// </summary>
[Flags]
[PInvokeData("winnt.h")]
public enum FileFlagsAndAttributes : uint
{
	/// <summary>
	/// A file that is read-only. Applications can read the file, but cannot write to it or delete it. This attribute is not honored on
	/// directories. For more information, see You cannot view or change the Read-only or the System attributes of folders in Windows Server
	/// 2003, in Windows XP, in Windows Vista or in Windows 7.
	/// </summary>
	FILE_ATTRIBUTE_READONLY = 0x00000001,

	/// <summary>The file or directory is hidden. It is not included in an ordinary directory listing.</summary>
	FILE_ATTRIBUTE_HIDDEN = 0x00000002,

	/// <summary>A file or directory that the operating system uses a part of, or uses exclusively.</summary>
	FILE_ATTRIBUTE_SYSTEM = 0x00000004,

	/// <summary>The handle that identifies a directory.</summary>
	FILE_ATTRIBUTE_DIRECTORY = 0x00000010,

	/// <summary>
	/// A file or directory that is an archive file or directory. Applications typically use this attribute to mark files for backup or
	/// removal .
	/// </summary>
	FILE_ATTRIBUTE_ARCHIVE = 0x00000020,

	/// <summary>This value is reserved for system use.</summary>
	FILE_ATTRIBUTE_DEVICE = 0x00000040,

	/// <summary>A file that does not have other attributes set. This attribute is valid only when used alone.</summary>
	FILE_ATTRIBUTE_NORMAL = 0x00000080,

	/// <summary>
	/// A file that is being used for temporary storage. File systems avoid writing data back to mass storage if sufficient cache memory is
	/// available, because typically, an application deletes a temporary file after the handle is closed. In that scenario, the system can
	/// entirely avoid writing the data. Otherwise, the data is written after the handle is closed.
	/// </summary>
	FILE_ATTRIBUTE_TEMPORARY = 0x00000100,

	/// <summary>A file that is a sparse file.</summary>
	FILE_ATTRIBUTE_SPARSE_FILE = 0x00000200,

	/// <summary>A file or directory that has an associated reparse point, or a file that is a symbolic link.</summary>
	FILE_ATTRIBUTE_REPARSE_POINT = 0x00000400,

	/// <summary>
	/// A file or directory that is compressed. For a file, all of the data in the file is compressed. For a directory, compression is the
	/// default for newly created files and subdirectories.
	/// </summary>
	FILE_ATTRIBUTE_COMPRESSED = 0x00000800,

	/// <summary>
	/// The data of a file is not available immediately. This attribute indicates that the file data is physically moved to offline storage.
	/// This attribute is used by Remote Storage, which is the hierarchical storage management software. Applications should not arbitrarily
	/// change this attribute.
	/// </summary>
	FILE_ATTRIBUTE_OFFLINE = 0x00001000,

	/// <summary>The file or directory is not to be indexed by the content indexing service.</summary>
	FILE_ATTRIBUTE_NOT_CONTENT_INDEXED = 0x00002000,

	/// <summary>
	/// A file or directory that is encrypted. For a file, all data streams in the file are encrypted. For a directory, encryption is the
	/// default for newly created files and subdirectories.
	/// </summary>
	FILE_ATTRIBUTE_ENCRYPTED = 0x00004000,

	/// <summary>
	/// The directory or user data stream is configured with integrity (only supported on ReFS volumes). It is not included in an ordinary
	/// directory listing. The integrity setting persists with the file if it's renamed. If a file is copied the destination file will have
	/// integrity set if either the source file or destination directory have integrity set.
	/// <para>
	/// <c>Windows Server 2008 R2, Windows 7, Windows Server 2008, Windows Vista, Windows Server 2003 and Windows XP:</c> This flag is not
	/// supported until Windows Server 2012.
	/// </para>
	/// </summary>
	FILE_ATTRIBUTE_INTEGRITY_STREAM = 0x00008000,

	/// <summary>This value is reserved for system use.</summary>
	FILE_ATTRIBUTE_VIRTUAL = 0x00010000,

	/// <summary>
	/// The user data stream not to be read by the background data integrity scanner (AKA scrubber). When set on a directory it only provides
	/// inheritance. This flag is only supported on Storage Spaces and ReFS volumes. It is not included in an ordinary directory listing.
	/// <para>
	/// <c>Windows Server 2008 R2, Windows 7, Windows Server 2008, Windows Vista, Windows Server 2003 and Windows XP:</c> This flag is not
	/// supported until Windows 8 and Windows Server 2012.
	/// </para>
	/// </summary>
	FILE_ATTRIBUTE_NO_SCRUB_DATA = 0x00020000,

	/// <summary/>
	FILE_ATTRIBUTE_EA = 0x00040000,

	/// <summary>Used to prevent the file from being purged from local storage when running low on disk space.</summary>
	FILE_ATTRIBUTE_PINNED = 0x00080000,

	/// <summary>Indicate that the file is not stored locally.</summary>
	FILE_ATTRIBUTE_UNPINNED = 0x00100000,

	/// <summary>
	/// This attribute only appears in directory enumeration classes (FILE_DIRECTORY_INFORMATION, FILE_BOTH_DIR_INFORMATION, etc.). When this
	/// attribute is set, it means that the file or directory has no physical representation on the local system; the item is virtual.
	/// Opening the item will be more expensive than normal, e.g. it will cause at least some of it to be fetched from a remote store.
	/// </summary>
	FILE_ATTRIBUTE_RECALL_ON_OPEN = 0x00040000,

	/// <summary>
	/// When this attribute is set, it means that the file or directory is not fully present locally. For a file that means that not all of
	/// its data is on local storage (e.g. it may be sparse with some data still in remote storage). For a directory it means that some of
	/// the directory contents are being virtualized from another location. Reading the file / enumerating the directory will be more
	/// expensive than normal, e.g. it will cause at least some of the file/directory content to be fetched from a remote store. Only
	/// kernel-mode callers can set this bit.
	/// </summary>
	FILE_ATTRIBUTE_RECALL_ON_DATA_ACCESS = 0x00400000,

	/// <summary/>
	FILE_ATTRIBUTE_STRICTLY_SEQUENTIAL = 0x20000000,

	/// <summary>
	/// Write operations will not go through any intermediate cache, they will go directly to disk.
	/// <para>For additional information, see the Caching Behavior section of this topic.</para>
	/// </summary>
	FILE_FLAG_WRITE_THROUGH = 0x80000000,

	/// <summary>
	/// The file or device is being opened or created for asynchronous I/O.
	/// <para>
	/// When subsequent I/O operations are completed on this handle, the event specified in the OVERLAPPED structure will be set to the
	/// signaled state.
	/// </para>
	/// <para>If this flag is specified, the file can be used for simultaneous read and write operations.</para>
	/// <para>
	/// If this flag is not specified, then I/O operations are serialized, even if the calls to the read and write functions specify an
	/// OVERLAPPED structure.
	/// </para>
	/// <para>
	/// For information about considerations when using a file handle created with this flag, see the Synchronous and Asynchronous I/O
	/// Handles section of this topic.
	/// </para>
	/// </summary>
	FILE_FLAG_OVERLAPPED = 0x40000000,

	/// <summary>
	/// The file or device is being opened with no system caching for data reads and writes. This flag does not affect hard disk caching or
	/// memory mapped files.
	/// <para>
	/// There are strict requirements for successfully working with files opened with CreateFile using the FILE_FLAG_NO_BUFFERING flag, for
	/// details see File Buffering.
	/// </para>
	/// </summary>
	FILE_FLAG_NO_BUFFERING = 0x20000000,

	/// <summary>
	/// Access is intended to be random. The system can use this as a hint to optimize file caching.
	/// <para>This flag has no effect if the file system does not support cached I/O and FILE_FLAG_NO_BUFFERING.</para>
	/// <para>For more information, see the Caching Behavior section of this topic.</para>
	/// </summary>
	FILE_FLAG_RANDOM_ACCESS = 0x10000000,

	/// <summary>
	/// Access is intended to be sequential from beginning to end. The system can use this as a hint to optimize file caching.
	/// <para>This flag should not be used if read-behind (that is, reverse scans) will be used.</para>
	/// <para>This flag has no effect if the file system does not support cached I/O and FILE_FLAG_NO_BUFFERING.</para>
	/// <para>For more information, see the Caching Behavior section of this topic.</para>
	/// </summary>
	FILE_FLAG_SEQUENTIAL_SCAN = 0x08000000,

	/// <summary>
	/// The file is to be deleted immediately after all of its handles are closed, which includes the specified handle and any other open or
	/// duplicated handles.
	/// <para>If there are existing open handles to a file, the call fails unless they were all opened with the FILE_SHARE_DELETE share mode.</para>
	/// <para>Subsequent open requests for the file fail, unless the FILE_SHARE_DELETE share mode is specified.</para>
	/// </summary>
	FILE_FLAG_DELETE_ON_CLOSE = 0x04000000,

	/// <summary>
	/// The file is being opened or created for a backup or restore operation. The system ensures that the calling process overrides file
	/// security checks when the process has SE_BACKUP_NAME and SE_RESTORE_NAME privileges. For more information, see Changing Privileges in
	/// a Token.
	/// <para>
	/// You must set this flag to obtain a handle to a directory. A directory handle can be passed to some functions instead of a file
	/// handle. For more information, see the Remarks section.
	/// </para>
	/// </summary>
	FILE_FLAG_BACKUP_SEMANTICS = 0x02000000,

	/// <summary>
	/// Access will occur according to POSIX rules. This includes allowing multiple files with names, differing only in case, for file
	/// systems that support that naming. Use care when using this option, because files created with this flag may not be accessible by
	/// applications that are written for MS-DOS or 16-bit Windows.
	/// </summary>
	FILE_FLAG_POSIX_SEMANTICS = 0x01000000,

	/// <summary>
	/// The file or device is being opened with session awareness. If this flag is not specified, then per-session devices (such as a device
	/// using RemoteFX USB Redirection) cannot be opened by processes running in session 0. This flag has no effect for callers not in
	/// session 0. This flag is supported only on server editions of Windows.
	/// <para><c>Windows Server 2008 R2 and Windows Server 2008:</c> This flag is not supported before Windows Server 2012.</para>
	/// </summary>
	FILE_FLAG_SESSION_AWARE = 0x00800000,

	/// <summary>
	/// Normal reparse point processing will not occur; CreateFile will attempt to open the reparse point. When a file is opened, a file
	/// handle is returned, whether or not the filter that controls the reparse point is operational.
	/// <para>This flag cannot be used with the CREATE_ALWAYS flag.</para>
	/// <para>If the file is not a reparse point, then this flag is ignored.</para>
	/// </summary>
	FILE_FLAG_OPEN_REPARSE_POINT = 0x00200000,

	/// <summary>
	/// The file data is requested, but it should continue to be located in remote storage. It should not be transported back to local
	/// storage. This flag is for use by remote storage systems.
	/// </summary>
	FILE_FLAG_OPEN_NO_RECALL = 0x00100000,

	/// <summary>
	/// If you attempt to create multiple instances of a pipe with this flag, creation of the first instance succeeds, but creation of the
	/// next instance fails with ERROR_ACCESS_DENIED.
	/// </summary>
	FILE_FLAG_FIRST_PIPE_INSTANCE = 0x00080000,

	/// <summary>Impersonates a client at the Anonymous impersonation level.</summary>
	SECURITY_ANONYMOUS = 0x00000000,

	/// <summary>Impersonates a client at the Identification impersonation level.</summary>
	SECURITY_IDENTIFICATION = 0x00010000,

	/// <summary>
	/// Impersonate a client at the impersonation level. This is the default behavior if no other flags are specified along with the
	/// SECURITY_SQOS_PRESENT flag.
	/// </summary>
	SECURITY_IMPERSONATION = 0x00020000,

	/// <summary>Impersonates a client at the Delegation impersonation level.</summary>
	SECURITY_DELEGATION = 0x00030000,

	/// <summary>The security tracking mode is dynamic. If this flag is not specified, the security tracking mode is static.</summary>
	SECURITY_CONTEXT_TRACKING = 0x00040000,

	/// <summary>
	/// Only the enabled aspects of the client's security context are available to the server. If you do not specify this flag, all aspects
	/// of the client's security context are available.
	/// <para>This allows the client to limit the groups and privileges that a server can use while impersonating the client.</para>
	/// </summary>
	SECURITY_EFFECTIVE_ONLY = 0x00080000,

	/// <summary>Include to enable the other SECURITY_ flags.</summary>
	SECURITY_SQOS_PRESENT = 0x00100000,

	/// <summary>The specified volume is a compressed volume.</summary>
	FILE_VOLUME_IS_COMPRESSED = 0x00008000,

	/// <summary>The specified volume supports object identifiers.</summary>
	FILE_SUPPORTS_OBJECT_IDS = 0x00010000,

	/// <summary>The specified volume supports the Encrypted File System (EFS). For more information, see File Encryption.</summary>
	FILE_SUPPORTS_ENCRYPTION = 0x00020000,

	/// <summary>The specified volume supports named streams.</summary>
	FILE_NAMED_STREAMS = 0x00040000,

	/// <summary>The specified volume is read-only.</summary>
	FILE_READ_ONLY_VOLUME = 0x00080000,

	/// <summary>The specified volume supports a single sequential write.</summary>
	FILE_SEQUENTIAL_WRITE_ONCE = 0x00100000,

	/// <summary>The specified volume supports transactions. For more information, see About KTM.</summary>
	FILE_SUPPORTS_TRANSACTIONS = 0x00200000,

	/// <summary>
	/// The specified volume supports hard links. For more information, see Hard Links and Junctions.
	/// <para>Windows Vista and Windows Server 2008: This value is not supported.</para>
	/// </summary>
	FILE_SUPPORTS_HARD_LINKS = 0x00400000,

	/// <summary>
	/// The specified volume supports extended attributes. An extended attribute is a piece of application-specific metadata that an
	/// application can associate with a file and is not part of the file's data.
	/// <para>Windows Vista and Windows Server 2008: This value is not supported.</para>
	/// </summary>
	FILE_SUPPORTS_EXTENDED_ATTRIBUTES = 0x00800000,

	/// <summary>
	/// The file system supports open by FileID. For more information, see FILE_ID_BOTH_DIR_INFO.
	/// <para>Windows Vista and Windows Server 2008: This value is not supported.</para>
	/// </summary>
	FILE_SUPPORTS_OPEN_BY_FILE_ID = 0x01000000,

	/// <summary>
	/// The specified volume supports update sequence number (USN) journals. For more information, see Change Journal Records.
	/// <para>Windows Vista and Windows Server 2008: This value is not supported.</para>
	/// </summary>
	FILE_SUPPORTS_USN_JOURNAL = 0x02000000,

	/// <summary>The file system supports integrity streams.</summary>
	FILE_SUPPORTS_INTEGRITY_STREAMS = 0x04000000,

	/// <summary>
	/// The file system supports block cloning, that is, sharing logical clusters between files on the same volume. The file system
	/// reallocates on writes to shared clusters.
	/// </summary>
	FILE_SUPPORTS_BLOCK_REFCOUNTING = 0x08000000,

	/// <summary>
	/// The file system tracks whether each cluster of a file contains valid data (either from explicit file writes or automatic zeros) or
	/// invalid data (has not yet been written to or zeroed). File systems that use sparse valid data length (VDL) do not store a valid data
	/// length and do not require that valid data be contiguous within a file.
	/// </summary>
	FILE_SUPPORTS_SPARSE_VDL = 0x10000000,

	/// <summary>The specified volume is a direct access (DAX) volume.</summary>
	FILE_DAX_VOLUME = 0x20000000,

	/// <summary>The file system supports ghosting.</summary>
	FILE_SUPPORTS_GHOSTING = 0x40000000,
}

/// <summary>
/// The requested sharing mode of the file or device, which can be read, write, both, delete, all of these, or none (refer to the following
/// table). Access requests to attributes or extended attributes are not affected by this flag.
/// </summary>
[PInvokeData("winnt.h")]
[Flags]
public enum FILE_SHARE : uint
{
	/// <summary>
	/// Enables subsequent open operations on a file or device to request read access.
	/// <para>Otherwise, other processes cannot open the file or device if they request read access.</para>
	/// <para>If this flag is not specified, but the file or device has been opened for read access, the function fails.</para>
	/// </summary>
	FILE_SHARE_READ = 0x00000001,

	/// <summary>
	/// Enables subsequent open operations on a file or device to request write access.
	/// <para>Otherwise, other processes cannot open the file or device if they request write access.</para>
	/// <para>
	/// If this flag is not specified, but the file or device has been opened for write access or has a file mapping with write access, the
	/// function fails.
	/// </para>
	/// </summary>
	FILE_SHARE_WRITE = 0x00000002,

	/// <summary>
	/// Enables subsequent open operations on a file or device to request delete access.
	/// <para>Otherwise, other processes cannot open the file or device if they request delete access.</para>
	/// <para>If this flag is not specified, but the file or device has been opened for delete access, the function fails.</para>
	/// <note type="note">Delete access allows both delete and rename operations.</note>
	/// </summary>
	FILE_SHARE_DELETE = 0x00000004,
}