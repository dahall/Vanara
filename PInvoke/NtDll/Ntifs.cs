using System.IO;
using static Vanara.PInvoke.Kernel32;

namespace Vanara.PInvoke;

public static partial class NtDll
{
	/// <summary>Callback routine to commit pages from the heap.</summary>
	/// <param name="Base">Base address for the block of caller-allocated memory being used for the heap.</param>
	/// <param name="CommitAddress">Pointer to a variable that will receive the base address of the committed region of pages.</param>
	/// <param name="CommitSize">Pointer to a variable that will receive the actual size, in bytes, of the allocated region of pages.</param>
	/// <returns>Result of commit.</returns>
	[UnmanagedFunctionPointer(CallingConvention.Winapi, SetLastError = false)]
	public delegate NTStatus PRTL_HEAP_COMMIT_ROUTINE([In] IntPtr Base, ref IntPtr CommitAddress, ref SizeT CommitSize);

	/// <summary>Specifies the options to apply when the driver creates or opens the file.</summary>
	[PInvokeData("ntifs.h", MSDNShortId = "c40b99be-5627-44f3-9853-c3ae31a8035c")]
	public enum NtFileCreateOptions
	{
		/// <summary>
		/// The file is a directory. Compatible CreateOptions flags are FILE_SYNCHRONOUS_IO_ALERT, FILE_SYNCHRONOUS_IO_NONALERT,
		/// FILE_WRITE_THROUGH, FILE_OPEN_FOR_BACKUP_INTENT, and FILE_OPEN_BY_FILE_ID. The CreateDisposition parameter must be set to
		/// FILE_CREATE, FILE_OPEN, or FILE_OPEN_IF.
		/// </summary>
		FILE_DIRECTORY_FILE = 0x00000001,

		/// <summary>
		/// System services, file-system drivers, and drivers that write data to the file must actually transfer the data to the file
		/// before any requested write operation is considered complete.
		/// </summary>
		FILE_WRITE_THROUGH = 0x00000002,

		/// <summary>
		/// <para>All access to the file will be sequential.</para>
		/// </summary>
		FILE_SEQUENTIAL_ONLY = 0x00000004,

		/// <summary>
		/// The file cannot be cached or buffered in a driver's internal buffers. This flag is incompatible with the DesiredAccess
		/// parameter's FILE_APPEND_DATA flag.
		/// </summary>
		FILE_NO_INTERMEDIATE_BUFFERING = 0x00000008,

		/// <summary>
		/// All operations on the file are performed synchronously. Any wait on behalf of the caller is subject to premature termination
		/// from alerts. This flag also causes the I/O system to maintain the file-position pointer. If this flag is set, the
		/// SYNCHRONIZE flag must be set in the DesiredAccess parameter.
		/// </summary>
		FILE_SYNCHRONOUS_IO_ALERT = 0x00000010,

		/// <summary>
		/// All operations on the file are performed synchronously. Waits in the system that synchronize I/O queuing and completion are
		/// not subject to alerts. This flag also causes the I/O system to maintain the file-position context. If this flag is set, the
		/// SYNCHRONIZE flag must be set in the DesiredAccess parameter.
		/// </summary>
		FILE_SYNCHRONOUS_IO_NONALERT = 0x00000020,

		/// <summary>
		/// The file is a directory. The file object to open can represent a data file; a logical, virtual, or physical device; or a volume.
		/// </summary>
		FILE_NON_DIRECTORY_FILE = 0x00000040,

		/// <summary>
		/// Create a tree connection for this file in order to open it over the network. This flag is not used by device and
		/// intermediate drivers.
		/// </summary>
		FILE_CREATE_TREE_CONNECTION = 0x00000080,

		/// <summary>
		/// Complete this operation immediately with an alternate success code of STATUS_OPLOCK_BREAK_IN_PROGRESS if the target file is
		/// oplocked, rather than blocking the caller's thread. If the file is oplocked, another caller already has access to the file.
		/// This flag is not used by device and intermediate drivers.
		/// </summary>
		FILE_COMPLETE_IF_OPLOCKED = 0x00000100,

		/// <summary>
		/// If the extended attributes (EAs) for an existing file being opened indicate that the caller must understand EAs to properly
		/// interpret the file, NtCreateFile should return an error. This flag is irrelevant for device and intermediate drivers.
		/// </summary>
		FILE_NO_EA_KNOWLEDGE = 0x00000200,

		/// <summary>formerly known as FILE_OPEN_FOR_RECOVERY</summary>
		FILE_OPEN_REMOTE_INSTANCE = 0x00000400,

		/// <summary>
		/// Access to the file can be random, so no sequential read-ahead operations should be performed by file-system drivers or by
		/// the system.
		/// </summary>
		FILE_RANDOM_ACCESS = 0x00000800,

		/// <summary>
		/// The system deletes the file when the last handle to the file is passed to NtClose. If this flag is set, the DELETE flag must
		/// be set in the DesiredAccess parameter.
		/// </summary>
		FILE_DELETE_ON_CLOSE = 0x00001000,

		/// <summary>
		/// The file name that is specified by the ObjectAttributes parameter includes a binary 8-byte or 16-byte file reference number
		/// or object ID for the file, depending on the file system as shown below. Optionally, a device name followed by a backslash
		/// character may proceed these binary values. For example, a device name will have the following format. This number is
		/// assigned by and specific to the particular file system.
		/// </summary>
		FILE_OPEN_BY_FILE_ID = 0x00002000,

		/// <summary>
		/// The file is being opened for backup intent. Therefore, the system should check for certain access rights and grant the
		/// caller the appropriate access to the file—before checking the DesiredAccess parameter against the file's security
		/// descriptor. This flag not used by device and intermediate drivers.
		/// </summary>
		FILE_OPEN_FOR_BACKUP_INTENT = 0x00004000,

		/// <summary>
		/// When a new file is created, the file MUST NOT be compressed, even if it is on a compressed volume. The flag MUST be ignored
		/// when opening an existing file.
		/// </summary>
		FILE_NO_COMPRESSION = 0x00008000,

		/// <summary>
		/// The file is being opened and an opportunistic lock (oplock) on the file is being requested as a single atomic operation. The
		/// file system checks for oplocks before it performs the create operation, and will fail the create with a return code of
		/// STATUS_CANNOT_BREAK_OPLOCK if the result would be to break an existing oplock.
		/// </summary>
		FILE_OPEN_REQUIRING_OPLOCK = 0x00010000,

		/// <summary>
		/// This flag allows an application to request a Filter opportunistic lock (oplock) to prevent other applications from getting
		/// share violations. If there are already open handles, the create request will fail with STATUS_OPLOCK_NOT_GRANTED. For more
		/// information, see the following Remarks section.
		/// </summary>
		FILE_RESERVE_OPFILTER = 0x00100000,

		/// <summary>
		/// Open a file with a reparse point and bypass normal reparse point processing for the file. For more information, see the
		/// following Remarks section.
		/// </summary>
		FILE_OPEN_REPARSE_POINT = 0x00200000,

		/// <summary>
		/// In a hierarchical storage management environment, this option requests that the file SHOULD NOT be recalled from tertiary
		/// storage such as tape. A file recall can take up to several minutes in a hierarchical storage management environment. The
		/// clients can specify this option to avoid such delays.
		/// </summary>
		FILE_OPEN_NO_RECALL = 0x00400000,

		/// <summary>Open file to query for free space. The client SHOULD set this to 0 and the server MUST ignore it.</summary>
		FILE_OPEN_FOR_FREE_SPACE_QUERY = 0x00800000,

		/// <summary>Undocumented.</summary>
		FILE_VALID_OPTION_FLAGS = 0x00ffffff,

		/// <summary>Undocumented.</summary>
		FILE_VALID_PIPE_OPTION_FLAGS = 0x00000032,

		/// <summary>Undocumented.</summary>
		FILE_VALID_MAILSLOT_OPTION_FLAGS = 0x00000032,

		/// <summary>Undocumented.</summary>
		FILE_VALID_SET_FLAGS = 0x00000036,
	}

	/// <summary>Specifies the action to perform if the file does or does not exist.</summary>
	[PInvokeData("ntifs.h", MSDNShortId = "c40b99be-5627-44f3-9853-c3ae31a8035c")]
	public enum NtFileMode
	{
		/// <summary>Replaces the file if it exists. Creates the file if it doesn't exist.</summary>
		FILE_SUPERSEDE = 0x00000000,

		/// <summary>Opens the file if it exists. Returns an error if it doesn't exist.</summary>
		FILE_OPEN = 0x00000001,

		/// <summary>Returns an error if the file exists. Creates the file if it doesn't exist.</summary>
		FILE_CREATE = 0x00000002,

		/// <summary>Opens the file if it exists. Creates the file if it doesn't exist.</summary>
		FILE_OPEN_IF = 0x00000003,

		/// <summary>Open the file, and overwrite it if it exists. Returns an error if it doesn't exist.</summary>
		FILE_OVERWRITE = 0x00000004,

		/// <summary>Open the file, and overwrite it if it exists. Creates the file if it doesn't exist.</summary>
		FILE_OVERWRITE_IF = 0x00000005,

		/// <summary>Undocumented.</summary>
		FILE_MAXIMUM_DISPOSITION = 0x00000005
	}

	/// <summary>
	/// <para>
	/// The <c>NtAllocateVirtualMemory</c> routine reserves, commits, or both, a region of pages within the user-mode virtual address
	/// space of a specified process.
	/// </para>
	/// </summary>
	/// <param name="ProcessHandle">
	/// <para>
	/// A handle for the process for which the mapping should be done. Use the <c>NtCurrentProcess</c> macro, defined in Ntddk.h, to
	/// specify the current process.
	/// </para>
	/// </param>
	/// <param name="BaseAddress">
	/// <para>
	/// A pointer to a variable that will receive the base address of the allocated region of pages. If the initial value of this
	/// parameter is non- <c>NULL</c>, the region is allocated starting at the specified virtual address rounded down to the next host
	/// page size address boundary. If the initial value of this parameter is <c>NULL</c>, the operating system will determine where to
	/// allocate the region.
	/// </para>
	/// </param>
	/// <param name="ZeroBits">
	/// <para>
	/// The number of high-order address bits that must be zero in the base address of the section view. Used only when the operating
	/// system determines where to allocate the region, as when BaseAddress is <c>NULL</c>. Note that when ZeroBits is larger than 32,
	/// it becomes a bitmask.
	/// </para>
	/// </param>
	/// <param name="RegionSize">
	/// <para>
	/// A pointer to a variable that will receive the actual size, in bytes, of the allocated region of pages. The initial value of this
	/// parameter specifies the size, in bytes, of the region and is rounded up to the next host page size boundary. *RegionSize cannot
	/// be zero on input.
	/// </para>
	/// </param>
	/// <param name="AllocationType">
	/// <para>A bitmask containing flags that specify the type of allocation to be performed. The following table describes these flags.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Flag</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>MEM_COMMIT</term>
	/// <term>The specified region of pages is to be committed. One of MEM_COMMIT, MEM_RESET, or MEM_RESERVE must be set.</term>
	/// </item>
	/// <item>
	/// <term>MEM_PHYSICAL</term>
	/// <term>
	/// Allocate physical memory. This flag is solely for use with Address Windowing Extensions (AWE) memory. If MEM_PHYSICAL is set,
	/// MEM_RESERVE must also be set. No other flags may be set. If MEM_PHYSICAL is set, Protect must be set to PAGE_READWRITE.
	/// </term>
	/// </item>
	/// <item>
	/// <term>MEM_RESERVE</term>
	/// <term>The specified region of pages is to be reserved. One of MEM_COMMIT, MEM_RESET, or MEM_RESERVE must be set.</term>
	/// </item>
	/// <item>
	/// <term>MEM_RESET</term>
	/// <term>
	/// Reset the state of the specified region so that if the pages are in paging file, they are discarded and pages of zeros are
	/// brought in. If the pages are in memory and modified, they are marked as not modified so that they will not be written out to the
	/// paging file. The contents are zeroed. The Protect parameter is not used, but it must be set to a valid value. One of MEM_COMMIT,
	/// MEM_RESET, or MEM_RESERVE must be set. If MEM_RESET is set, no other flag may be set.
	/// </term>
	/// </item>
	/// <item>
	/// <term>MEM_TOP_DOWN</term>
	/// <term>The specified region should be created at the highest virtual address possible based on ZeroBits.</term>
	/// </item>
	/// <item>
	/// <term>MEM_WRITE_WATCH</term>
	/// <term>The specified region should be created at the highest virtual address possible based on ZeroBits.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="Protect">
	/// <para>
	/// A bitmask containing page protection flags that specify the protection desired for the committed region of pages. The following
	/// table describes these flags.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Flag</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>PAGE_NOACCESS</term>
	/// <term>
	/// No access to the committed region of pages is allowed. An attempt to read, write, or execute the committed region results in an
	/// access violation exception, called a general protection (GP) fault.
	/// </term>
	/// </item>
	/// <item>
	/// <term>PAGE_READONLY</term>
	/// <term>
	/// Read-only and execute access to the committed region of pages is allowed. An attempt to write the committed region results in an
	/// access violation.
	/// </term>
	/// </item>
	/// <item>
	/// <term>PAGE_READWRITE</term>
	/// <term>
	/// Read, write, and execute access to the committed region of pages is allowed. If write access to the underlying section is
	/// allowed, then a single copy of the pages is shared. Otherwise the pages are shared read only/copy on write.
	/// </term>
	/// </item>
	/// <item>
	/// <term>PAGE_EXECUTE</term>
	/// <term>
	/// Execute access to the committed region of pages is allowed. An attempt to read or write to the committed region results in an
	/// access violation.
	/// </term>
	/// </item>
	/// <item>
	/// <term>PAGE_EXECUTE_READ</term>
	/// <term>
	/// Execute and read access to the committed region of pages are allowed. An attempt to write to the committed region results in an
	/// access violation.
	/// </term>
	/// </item>
	/// <item>
	/// <term>PAGE_GUARD</term>
	/// <term>
	/// Pages in the region become guard pages. Any attempt to read from or write to a guard page causes the system to raise a
	/// STATUS_GUARD_PAGE exception. Guard pages thus act as a one-shot access alarm. This flag is a page protection modifier, valid
	/// only when used with one of the page protection flags other than PAGE_NOACCESS. When an access attempt leads the system to turn
	/// off guard page status, the underlying page protection takes over. If a guard page exception occurs during a system service, the
	/// service typically returns a failure status indicator.
	/// </term>
	/// </item>
	/// <item>
	/// <term>PAGE_NOCACHE</term>
	/// <term>The region of pages should be allocated as noncacheable. PAGE_NOCACHE is not allowed for sections.</term>
	/// </item>
	/// <item>
	/// <term>PAGE_WRITECOMBINE</term>
	/// <term>
	/// Enables write combining, that is, coalescing writes from cache to main memory, where the hardware supports it. This flag is used
	/// primarily for frame buffer memory so that writes to the same cache line are combined where possible before being written to the
	/// device. This can greatly reduce writes across the bus to (for example) video memory. If the hardware does not support write
	/// combining, the flag is ignored. This flag is a page protection modifier, valid only when used with one of the page protection
	/// flags other than PAGE_NOACCESS.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <returns>
	/// <para>
	/// <c>ZwAllocateVirtualMemory</c> returns either STATUS_SUCCESS or an error status code. Possible error status codes include the following:
	/// </para>
	/// </returns>
	/// <remarks>
	/// <para><c>ZwAllocateVirtualMemory</c> can perform the following operations:</para>
	/// <para>
	/// Kernel-mode drivers can use <c>ZwAllocateVirtualMemory</c> to reserve a range of application-accessible virtual addresses in the
	/// specified process and then make additional calls to <c>ZwAllocateVirtualMemory</c> to commit individual pages from the reserved
	/// range. This enables a process to reserve a range of its virtual address space without consuming physical storage until it is needed.
	/// </para>
	/// <para>Each page in the process's virtual address space is in one of the three states described in the following table.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>State</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>FREE</term>
	/// <term>
	/// The page is not committed or reserved and is not accessible to the process. ZwAllocateVirtualMemory can reserve, or
	/// simultaneously reserve and commit, a free page.
	/// </term>
	/// </item>
	/// <item>
	/// <term>RESERVED</term>
	/// <term>
	/// The range of addresses cannot be used by other allocation functions, but the page is not accessible to the process and has no
	/// physical storage associated with it. ZwAllocateVirtualMemory can commit a reserved page, but it cannot reserve it a second time.
	/// ZwFreeVirtualMemory can release a reserved page, making it a free page.
	/// </term>
	/// </item>
	/// <item>
	/// <term>COMMITTED</term>
	/// <term>
	/// Physical storage is allocated for the page, and access is controlled by a protection code. The system initializes and loads each
	/// committed page into physical memory only at the first attempt to read or write to that page. When the process terminates, the
	/// system releases the storage for committed pages. ZwAllocateVirtualMemory can commit an already committed page. This means that
	/// you can commit a range of pages, regardless of whether they have already been committed, and the function will not fail.
	/// ZwFreeVirtualMemory can decommit a committed page, releasing the page's storage, or it can simultaneously decommit and release a
	/// committed page.
	/// </term>
	/// </item>
	/// </list>
	/// <para>Memory allocated by calling <c>ZwAllocateVirtualMemory</c> must be freed by calling <c>ZwFreeVirtualMemory</c>.</para>
	/// <para>For more information about memory management, see Memory Management for Windows Drivers.</para>
	/// <para>
	/// For calls from kernel-mode drivers, the <c>NtXxx</c> and <c>ZwXxx</c> versions of a Windows Native System Services routine can
	/// behave differently in the way that they handle and interpret input parameters. For more information about the relationship
	/// between the <c>NtXxx</c> and <c>ZwXxx</c> versions of a routine, see Using Nt and Zw Versions of the Native System Services Routines.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows-hardware/drivers/ddi/content/ntifs/nf-ntifs-ntallocatevirtualmemory __kernel_entry
	// NTSYSCALLAPI NTSTATUS NtAllocateVirtualMemory( HANDLE ProcessHandle, PVOID *BaseAddress, ULONG_PTR ZeroBits, PSIZE_T RegionSize,
	// ULONG AllocationType, ULONG Protect );
	[DllImport(Lib.NtDll, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("ntifs.h", MSDNShortId = "bb82c90d-9bd3-4a23-b171-06a3208e424b")]
	public static extern NTStatus NtAllocateVirtualMemory(HPROCESS ProcessHandle, ref IntPtr BaseAddress, SizeT ZeroBits, ref SizeT RegionSize, MEM_ALLOCATION_TYPE AllocationType, MEM_PROTECTION Protect);

	/// <summary>
	/// <para>The <c>NtCreateFile</c> routine creates a new file or opens an existing file.</para>
	/// </summary>
	/// <param name="FileHandle">
	/// <para>A pointer to a HANDLE variable that receives a handle to the file.</para>
	/// </param>
	/// <param name="DesiredAccess">
	/// <para>
	/// Specifies an ACCESS_MASK value that determines the requested access to the object. In addition to the access rights that are
	/// defined for all types of objects, the caller can specify any of the following access rights, which are specific to files.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>ACCESS_MASK flag</term>
	/// <term>Allows caller to do this</term>
	/// </listheader>
	/// <item>
	/// <term>FILE_READ_DATA</term>
	/// <term>Read data from the file.</term>
	/// </item>
	/// <item>
	/// <term>FILE_READ_ATTRIBUTES</term>
	/// <term>Read the attributes of the file. (For more information, see the description of the FileAttributes parameter.)</term>
	/// </item>
	/// <item>
	/// <term>FILE_READ_EA</term>
	/// <term>Read the extended attributes (EAs) of the file. This flag is irrelevant for device and intermediate drivers.</term>
	/// </item>
	/// <item>
	/// <term>FILE_WRITE_DATA</term>
	/// <term>Write data to the file.</term>
	/// </item>
	/// <item>
	/// <term>FILE_WRITE_ATTRIBUTES</term>
	/// <term>Write the attributes of the file. (For more information, see the description of the FileAttributes parameter.)</term>
	/// </item>
	/// <item>
	/// <term>FILE_WRITE_EA</term>
	/// <term>Change the extended attributes (EAs) of the file. This flag is irrelevant for device and intermediate drivers.</term>
	/// </item>
	/// <item>
	/// <term>FILE_APPEND_DATA</term>
	/// <term>Append data to the file.</term>
	/// </item>
	/// <item>
	/// <term>FILE_EXECUTE</term>
	/// <term>Use system paging I/O to read data from the file into memory. This flag is irrelevant for device and intermediate drivers.</term>
	/// </item>
	/// </list>
	/// <para>
	/// <c>Note</c> Do not specify FILE_READ_DATA, FILE_WRITE_DATA, FILE_APPEND_DATA, or FILE_EXECUTE when you create or open a directory.
	/// </para>
	/// <para>The caller can only specify a generic access right, GENERIC_</para>
	/// <para>XXX</para>
	/// <para>, for a file, not a directory. Generic access rights correspond to specific access rights as shown in the following table.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Generic access right</term>
	/// <term>Set of specific access rights</term>
	/// </listheader>
	/// <item>
	/// <term>GENERIC_READ</term>
	/// <term>STANDARD_RIGHTS_READ, FILE_READ_DATA, FILE_READ_ATTRIBUTES, FILE_READ_EA, and SYNCHRONIZE.</term>
	/// </item>
	/// <item>
	/// <term>GENERIC_WRITE</term>
	/// <term>STANDARD_RIGHTS_WRITE, FILE_WRITE_DATA, FILE_WRITE_ATTRIBUTES, FILE_WRITE_EA, FILE_APPEND_DATA, and SYNCHRONIZE.</term>
	/// </item>
	/// <item>
	/// <term>GENERIC_EXECUTE</term>
	/// <term>
	/// STANDARD_RIGHTS_EXECUTE, FILE_EXECUTE, FILE_READ_ATTRIBUTES, and SYNCHRONIZE. This value is irrelevant for device and
	/// intermediate drivers.
	/// </term>
	/// </item>
	/// <item>
	/// <term>GENERIC_ALL</term>
	/// <term>FILE_ALL_ACCESS.</term>
	/// </item>
	/// </list>
	/// <para>
	/// For example, if you specify GENERIC_READ for a file object, the routine maps this value to the FILE_GENERIC_READ bitmask of
	/// specific access rights. In the preceding table, the specific access rights that are listed for GENERIC_READ correspond to the
	/// access flags that are contained in the FILE_GENERIC_READ bitmask. If the file is actually a directory, the caller can also
	/// specify the following generic access rights.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>DesiredAccess flag</term>
	/// <term>Allows caller to do this</term>
	/// </listheader>
	/// <item>
	/// <term>FILE_LIST_DIRECTORY</term>
	/// <term>List the files in the directory.</term>
	/// </item>
	/// <item>
	/// <term>FILE_TRAVERSE</term>
	/// <term>Traverse the directory, in other words, include the directory in the path of a file.</term>
	/// </item>
	/// </list>
	/// <para>For more information about access rights, see ACCESS_MASK.</para>
	/// </param>
	/// <param name="ObjectAttributes">
	/// <para>
	/// A pointer to an OBJECT_ATTRIBUTES structure that specifies the object name and other attributes. Use InitializeObjectAttributes
	/// to initialize this structure. If the caller is not running in a system thread context, it must set the OBJ_KERNEL_HANDLE
	/// attribute when it calls InitializeObjectAttributes.
	/// </para>
	/// </param>
	/// <param name="IoStatusBlock">
	/// <para>
	/// A pointer to an IO_STATUS_BLOCK structure that receives the final completion status and other information about the requested
	/// operation. In particular, the Information member receives one of the following values:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>FILE_CREATED</term>
	/// </item>
	/// <item>
	/// <term>FILE_OPENED</term>
	/// </item>
	/// <item>
	/// <term>FILE_OVERWRITTEN</term>
	/// </item>
	/// <item>
	/// <term>FILE_SUPERSEDED</term>
	/// </item>
	/// <item>
	/// <term>FILE_EXISTS</term>
	/// </item>
	/// <item>
	/// <term>FILE_DOES_NOT_EXIST</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="AllocationSize">
	/// <para>
	/// A pointer to a LARGE_INTEGER that contains the initial allocation size, in bytes, for a file that is created or overwritten. If
	/// AllocationSize is NULL, no allocation size is specified. If no file is created or overwritten, AllocationSize is ignored.
	/// </para>
	/// </param>
	/// <param name="FileAttributes">
	/// <para>
	/// Specifies one or more FILE_ATTRIBUTE_XXX flags, which represent the file attributes to set if you create or overwrite a file.
	/// The caller usually specifies FILE_ATTRIBUTE_NORMAL, which sets the default attributes. For a list of valid
	/// FILE_ATTRIBUTE_XXXflags, see the CreateFile routine in the Microsoft Windows SDK documentation. If no file is created or
	/// overwritten, FileAttributes is ignored.
	/// </para>
	/// </param>
	/// <param name="ShareAccess">
	/// <para>Type of share access, which is specified as zero or any combination of the following flags.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>ShareAccess flag</term>
	/// <term>Allows other threads to do this</term>
	/// </listheader>
	/// <item>
	/// <term>FILE_SHARE_READ</term>
	/// <term>Read the file</term>
	/// </item>
	/// <item>
	/// <term>FILE_SHARE_WRITE</term>
	/// <term>Write the file</term>
	/// </item>
	/// <item>
	/// <term>FILE_SHARE_DELETE</term>
	/// <term>Delete the file</term>
	/// </item>
	/// </list>
	/// <para>Device and intermediate drivers usually set ShareAccess to zero, which gives the caller exclusive access to the open file.</para>
	/// </param>
	/// <param name="CreateDisposition">
	/// <para>
	/// Specifies the action to perform if the file does or does not exist. CreateDisposition can be one of the values in the following table.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>CreateDisposition value</term>
	/// <term>Action if file exists</term>
	/// <term>Action if file does not exist</term>
	/// </listheader>
	/// <item>
	/// <term>FILE_SUPERSEDE</term>
	/// <term>Replace the file.</term>
	/// <term>Create the file.</term>
	/// </item>
	/// <item>
	/// <term>FILE_CREATE</term>
	/// <term>Return an error.</term>
	/// <term>Create the file.</term>
	/// </item>
	/// <item>
	/// <term>FILE_OPEN</term>
	/// <term>Open the file.</term>
	/// <term>Return an error.</term>
	/// </item>
	/// <item>
	/// <term>FILE_OPEN_IF</term>
	/// <term>Open the file.</term>
	/// <term>Create the file.</term>
	/// </item>
	/// <item>
	/// <term>FILE_OVERWRITE</term>
	/// <term>Open the file, and overwrite it.</term>
	/// <term>Return an error.</term>
	/// </item>
	/// <item>
	/// <term>FILE_OVERWRITE_IF</term>
	/// <term>Open the file, and overwrite it.</term>
	/// <term>Create the file.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="CreateOptions">
	/// <para>
	/// Specifies the options to apply when the driver creates or opens the file. Use one or more of the flags in the following table.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>CreateOptions flag</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>FILE_DIRECTORY_FILE</term>
	/// <term>
	/// The file is a directory. Compatible CreateOptions flags are FILE_SYNCHRONOUS_IO_ALERT, FILE_SYNCHRONOUS_IO_NONALERT,
	/// FILE_WRITE_THROUGH, FILE_OPEN_FOR_BACKUP_INTENT, and FILE_OPEN_BY_FILE_ID. The CreateDisposition parameter must be set to
	/// FILE_CREATE, FILE_OPEN, or FILE_OPEN_IF.
	/// </term>
	/// </item>
	/// <item>
	/// <term>FILE_NON_DIRECTORY_FILE</term>
	/// <term>
	/// The file is a directory. The file object to open can represent a data file; a logical, virtual, or physical device; or a volume.
	/// </term>
	/// </item>
	/// <item>
	/// <term>FILE_WRITE_THROUGH</term>
	/// <term>
	/// System services, file-system drivers, and drivers that write data to the file must actually transfer the data to the file before
	/// any requested write operation is considered complete.
	/// </term>
	/// </item>
	/// <item>
	/// <term>FILE_SEQUENTIAL_ONLY</term>
	/// <term>All access to the file will be sequential.</term>
	/// </item>
	/// <item>
	/// <term>FILE_RANDOM_ACCESS</term>
	/// <term>
	/// Access to the file can be random, so no sequential read-ahead operations should be performed by file-system drivers or by the system.
	/// </term>
	/// </item>
	/// <item>
	/// <term>FILE_NO_INTERMEDIATE_BUFFERING</term>
	/// <term>
	/// The file cannot be cached or buffered in a driver's internal buffers. This flag is incompatible with the DesiredAccess
	/// parameter's FILE_APPEND_DATA flag.
	/// </term>
	/// </item>
	/// <item>
	/// <term>FILE_SYNCHRONOUS_IO_ALERT</term>
	/// <term>
	/// All operations on the file are performed synchronously. Any wait on behalf of the caller is subject to premature termination
	/// from alerts. This flag also causes the I/O system to maintain the file-position pointer. If this flag is set, the SYNCHRONIZE
	/// flag must be set in the DesiredAccess parameter.
	/// </term>
	/// </item>
	/// <item>
	/// <term>FILE_SYNCHRONOUS_IO_NONALERT</term>
	/// <term>
	/// All operations on the file are performed synchronously. Waits in the system that synchronize I/O queuing and completion are not
	/// subject to alerts. This flag also causes the I/O system to maintain the file-position context. If this flag is set, the
	/// SYNCHRONIZE flag must be set in the DesiredAccess parameter.
	/// </term>
	/// </item>
	/// <item>
	/// <term>FILE_CREATE_TREE_CONNECTION</term>
	/// <term>
	/// Create a tree connection for this file in order to open it over the network. This flag is not used by device and intermediate drivers.
	/// </term>
	/// </item>
	/// <item>
	/// <term>FILE_COMPLETE_IF_OPLOCKED</term>
	/// <term>
	/// Complete this operation immediately with an alternate success code of STATUS_OPLOCK_BREAK_IN_PROGRESS if the target file is
	/// oplocked, rather than blocking the caller's thread. If the file is oplocked, another caller already has access to the file. This
	/// flag is not used by device and intermediate drivers.
	/// </term>
	/// </item>
	/// <item>
	/// <term>FILE_NO_EA_KNOWLEDGE</term>
	/// <term>
	/// If the extended attributes (EAs) for an existing file being opened indicate that the caller must understand EAs to properly
	/// interpret the file, NtCreateFile should return an error. This flag is irrelevant for device and intermediate drivers.
	/// </term>
	/// </item>
	/// <item>
	/// <term>FILE_OPEN_REPARSE_POINT</term>
	/// <term>
	/// Open a file with a reparse point and bypass normal reparse point processing for the file. For more information, see the
	/// following Remarks section.
	/// </term>
	/// </item>
	/// <item>
	/// <term>FILE_DELETE_ON_CLOSE</term>
	/// <term>
	/// The system deletes the file when the last handle to the file is passed to NtClose. If this flag is set, the DELETE flag must be
	/// set in the DesiredAccess parameter.
	/// </term>
	/// </item>
	/// <item>
	/// <term>FILE_OPEN_BY_FILE_ID</term>
	/// <term>
	/// The file name that is specified by the ObjectAttributes parameter includes a binary 8-byte or 16-byte file reference number or
	/// object ID for the file, depending on the file system as shown below. Optionally, a device name followed by a backslash character
	/// may proceed these binary values. For example, a device name will have the following format. This number is assigned by and
	/// specific to the particular file system.
	/// </term>
	/// </item>
	/// <item>
	/// <term>FILE_OPEN_FOR_BACKUP_INTENT</term>
	/// <term>
	/// The file is being opened for backup intent. Therefore, the system should check for certain access rights and grant the caller
	/// the appropriate access to the file—before checking the DesiredAccess parameter against the file's security descriptor. This flag
	/// not used by device and intermediate drivers.
	/// </term>
	/// </item>
	/// <item>
	/// <term>FILE_RESERVE_OPFILTER</term>
	/// <term>
	/// This flag allows an application to request a Filter opportunistic lock (oplock) to prevent other applications from getting share
	/// violations. If there are already open handles, the create request will fail with STATUS_OPLOCK_NOT_GRANTED. For more
	/// information, see the following Remarks section.
	/// </term>
	/// </item>
	/// <item>
	/// <term>FILE_OPEN_REQUIRING_OPLOCK</term>
	/// <term>
	/// The file is being opened and an opportunistic lock (oplock) on the file is being requested as a single atomic operation. The
	/// file system checks for oplocks before it performs the create operation, and will fail the create with a return code of
	/// STATUS_CANNOT_BREAK_OPLOCK if the result would be to break an existing oplock.
	/// </term>
	/// </item>
	/// <item>
	/// <term>FILE_SESSION_AWARE</term>
	/// <term>The client opening the file or device is session aware and per session access is validated if necessary.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="EaBuffer">
	/// <para>For device and intermediate drivers, this parameter must be a NULL pointer.</para>
	/// </param>
	/// <param name="EaLength">
	/// <para>For device and intermediate drivers, this parameter must be zero.</para>
	/// </param>
	/// <returns>
	/// NtCreateFile returns STATUS_SUCCESS on success or an appropriate NTSTATUS error code on failure. In the latter case, the caller
	/// can determine the cause of the failure by checking the IoStatusBlock parameter.
	/// <para>
	/// <c>Note</c><c>NtCreateFile</c> might return STATUS_FILE_LOCK_CONFLICT as the return value or in the <c>Status</c> member of the
	/// <c>IO_STATUS_BLOCK</c> structure that is pointed to by the IoStatusBlock parameter. This would occur only if the NTFS log file
	/// is full, and an error occurs while <c>NtCreateFile</c> tries to handle this situation.
	/// </para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// <c>NtCreateFile</c> supplies a handle that the caller can use to manipulate a file's data, or the file object's state and
	/// attributes. For more information, see Using Files in a Driver.
	/// </para>
	/// <para>Once the handle pointed to by FileHandle is no longer in use, the driver must call NtClose to close it.</para>
	/// <para>
	/// If the caller is not running in a system thread context, it must ensure that any handles it creates are private handles.
	/// Otherwise, the handle can be accessed by the process in whose context the driver is running. For more information, see Object Handles.
	/// </para>
	/// <para>There are two alternate ways to specify the name of the file to be created or opened with <c>NtCreateFile</c>:</para>
	/// <para>Setting certain flags in the DesiredAccess parameter results in the following effects:</para>
	/// <para>
	/// The ShareAccess parameter determines whether separate threads can access the same file, possibly simultaneously. Provided that
	/// both callers have the appropriate access privileges, the file can be successfully opened and shared. If the original caller of
	/// <c>NtCreateFile</c> does not specify FILE_SHARE_READ, FILE_SHARE_WRITE, or FILE_SHARE_DELETE, no other caller can open the
	/// file—that is, the original caller is granted exclusive access.
	/// </para>
	/// <para>
	/// To successfully open a shared file, the DesiredAccess flags must be compatible with the DesiredAccess and ShareAccess flags of
	/// all the previous open operations that have not yet been released through . That is, the DesiredAccess specified to
	/// <c>NtCreateFile</c> for a given file must not conflict with the accesses that other openers of the file have disallowed.
	/// </para>
	/// <para>
	/// The CreateDisposition value FILE_SUPERSEDE requires that the caller have DELETE access to a existing file object. If so, a
	/// successful call to <c>NtCreateFile</c> with FILE_SUPERSEDE on an existing file effectively deletes that file, and then recreates
	/// it. This implies that, if the file has already been opened by another thread, it opened the file by specifying a ShareAccess
	/// parameter with the FILE_SHARE_DELETE flag set. Note that this type of disposition is consistent with the POSIX style of
	/// overwriting files.
	/// </para>
	/// <para>
	/// The CreateDisposition values FILE_OVERWRITE_IF and FILE_SUPERSEDE are similar. If <c>NtCreateFile</c> is called with a existing
	/// file and either of these CreateDisposition values, the file will be replaced.
	/// </para>
	/// <para>Overwriting a file is semantically equivalent to a supersede operation, except for the following:</para>
	/// <para>
	/// The FILE_DIRECTORY_FILE CreateOptions value specifies that the file to be created or opened is a directory. When a directory
	/// file is created, the file system creates an appropriate structure on the disk to represent an empty directory for that
	/// particular file system's on-disk structure. If this option was specified and the given file to be opened is not a directory
	/// file, or if the caller specified an inconsistent CreateOptions or CreateDisposition value, the call to <c>NtCreateFile</c> will fail.
	/// </para>
	/// <para>
	/// The FILE_NO_INTERMEDIATE_BUFFERING CreateOptions flag prevents the file system from performing any intermediate buffering on
	/// behalf of the caller. Specifying this flag places the following restrictions on the caller's parameters to other
	/// <c>ZwXxxFile</c> routines.
	/// </para>
	/// <para>
	/// The FILE_SYNCHRONOUS_IO_ALERT and FILE_SYNCHRONOUS_IO_NONALERT CreateOptions flags, which are mutually exclusive as their names
	/// suggest, specify that all I/O operations on the file will be synchronous—as long as they occur through the file object referred
	/// to by the returned FileHandle. All I/O on such a file is serialized across all threads using the returned handle. If either of
	/// these CreateOptions flags is set, the SYNCHRONIZE DesiredAccess flag must also be set—to compel the I/O manager to use the file
	/// object as a synchronization object. In these cases, the I/O manager keeps track of the current file-position offset, which you
	/// can pass to <c>NtReadFile</c> and <c>NtWriteFile</c>. Call <c>NtQueryInformationFile</c> or <c>NtSetInformationFile</c> to get
	/// or set this position.
	/// </para>
	/// <para>
	/// If the CreateOptions FILE_OPEN_REPARSE_POINT flag is specified and <c>NtCreateFile</c> attempts to open a file with a reparse
	/// point, normal reparse point processing occurs for the file. If, on the other hand, the FILE_OPEN_REPARSE_POINT flag is
	/// specified, normal reparse processing does occur and <c>NtCreateFile</c> attempts to directly open the reparse point file. In
	/// either case, if the open operation was successful, <c>NtCreateFile</c> returns STATUS_SUCCESS; otherwise, the routine returns an
	/// NTSTATUS error code. <c>NtCreateFile</c> never returns STATUS_REPARSE.
	/// </para>
	/// <para>
	/// The CreateOptions FILE_OPEN_REQUIRING_OPLOCK flag eliminates the time between when you open the file and request an oplock that
	/// could potentially allow a third party to open the file and get a sharing violation. An application can use the
	/// FILE_OPEN_REQUIRING_OPLOCK flag on <c>NtCreateFile</c> and then request any oplock. This ensures that an oplock owner will be
	/// notified of any subsequent open request that causes a sharing violation.
	/// </para>
	/// <para>
	/// In Windows 7, if other handles exist on the file when an application uses the FILE_OPEN_REQUIRING_OPLOCK flag, the create
	/// operation will fail with STATUS_OPLOCK_NOT_GRANTED. This restriction no longer exists starting with Windows 8.
	/// </para>
	/// <para>
	/// If this create operation would break an oplock that already exists on the file, then setting the FILE_OPEN_REQUIRING_OPLOCK flag
	/// will cause the create operation to fail with STATUS_CANNOT_BREAK_OPLOCK. The existing oplock will not be broken by this create operation.
	/// </para>
	/// <para>
	/// An application that uses the FILE_OPEN_REQUIRING_OPLOCK flag must request an oplock after this call succeeds, or all subsequent
	/// attempts to open the file will be blocked without the benefit of normal oplock processing. Similarly, if this call succeeds but
	/// the subsequent oplock request fails, an application that uses this flag must close its handle after it detects that the oplock
	/// request has failed.
	/// </para>
	/// <para>
	/// The CreateOptions flag FILE_RESERVE_OPFILTER allows an application to request a Level 1, Batch, or Filter oplock to prevent
	/// other applications from getting share violations. However, FILE_RESERVE_OPFILTER is only practically useful for Filter oplocks.
	/// To use it, you must complete the following steps:
	/// </para>
	/// <para>
	/// Step three makes this practical only for Filter oplocks. The handle opened in step 3 can have a DesiredAccess that contains a
	/// maximum of FILE_READ_ATTRIBUTES | FILE_WRITE_ATTRIBUTES | FILE_READ_DATA | FILE_READ_EA | FILE_EXECUTE | SYNCHRONIZE |
	/// READ_CONTROL and still not break a Filter oplock. However, any DesiredAccess greater than FILE_READ_ATTRIBUTES |
	/// FILE_WRITE_ATTRIBUTES | SYNCHRONIZE will break a Level 1 or Batch oplock and make the FILE_RESERVE_OPFILTER flag useless for
	/// those oplock types.
	/// </para>
	/// <para>NTFS is the only Microsoft file system that implements FILE_RESERVE_OPFILTER.</para>
	/// <para>Callers of <c>NtCreateFile</c> must be running at IRQL = PASSIVE_LEVEL and with special kernel APCs enabled.</para>
	/// <para>
	/// For calls from kernel-mode drivers, the <c>NtXxx</c> and <c>ZwXxx</c> versions of a Windows Native System Services routine can
	/// behave differently in the way that they handle and interpret input parameters. For more information about the relationship
	/// between the <c>NtXxx</c> and <c>ZwXxx</c> versions of a routine, see Using Nt and Zw Versions of the Native System Services Routines.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows-hardware/drivers/ddi/content/ntifs/nf-ntifs-ntcreatefile __kernel_entry NTSYSCALLAPI
	// NTSTATUS NtCreateFile( PHANDLE FileHandle, ACCESS_MASK DesiredAccess, POBJECT_ATTRIBUTES ObjectAttributes, PIO_STATUS_BLOCK
	// IoStatusBlock, PLARGE_INTEGER AllocationSize, ULONG FileAttributes, ULONG ShareAccess, ULONG CreateDisposition, ULONG
	// CreateOptions, PVOID EaBuffer, ULONG EaLength );
	[DllImport(Lib.NtDll, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("ntifs.h", MSDNShortId = "c40b99be-5627-44f3-9853-c3ae31a8035c")]
	// public static extern __kernel_entry NTSYSCALLAPI NTSTATUS NtCreateFile(ref IntPtr FileHandle, ACCESS_MASK DesiredAccess,
	// POBJECT_ATTRIBUTES ObjectAttributes, PIO_STATUS_BLOCK IoStatusBlock, PLARGE_INTEGER AllocationSize, uint FileAttributes, uint
	// ShareAccess, uint CreateDisposition, uint CreateOptions, IntPtr EaBuffer, uint EaLength);
	public static extern NTStatus NtCreateFile(out SafeHFILE FileHandle, ACCESS_MASK DesiredAccess, in OBJECT_ATTRIBUTES ObjectAttributes, out IO_STATUS_BLOCK IoStatusBlock,
		in long AllocationSize, FileFlagsAndAttributes FileAttributes, FileShare ShareAccess, NtFileMode CreateDisposition, NtFileCreateOptions CreateOptions, IntPtr EaBuffer = default, uint EaLength = 0);

	/// <summary>
	/// <para>The <c>NtCreateFile</c> routine creates a new file or opens an existing file.</para>
	/// </summary>
	/// <param name="FileHandle">
	/// <para>A pointer to a HANDLE variable that receives a handle to the file.</para>
	/// </param>
	/// <param name="DesiredAccess">
	/// <para>
	/// Specifies an ACCESS_MASK value that determines the requested access to the object. In addition to the access rights that are
	/// defined for all types of objects, the caller can specify any of the following access rights, which are specific to files.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>ACCESS_MASK flag</term>
	/// <term>Allows caller to do this</term>
	/// </listheader>
	/// <item>
	/// <term>FILE_READ_DATA</term>
	/// <term>Read data from the file.</term>
	/// </item>
	/// <item>
	/// <term>FILE_READ_ATTRIBUTES</term>
	/// <term>Read the attributes of the file. (For more information, see the description of the FileAttributes parameter.)</term>
	/// </item>
	/// <item>
	/// <term>FILE_READ_EA</term>
	/// <term>Read the extended attributes (EAs) of the file. This flag is irrelevant for device and intermediate drivers.</term>
	/// </item>
	/// <item>
	/// <term>FILE_WRITE_DATA</term>
	/// <term>Write data to the file.</term>
	/// </item>
	/// <item>
	/// <term>FILE_WRITE_ATTRIBUTES</term>
	/// <term>Write the attributes of the file. (For more information, see the description of the FileAttributes parameter.)</term>
	/// </item>
	/// <item>
	/// <term>FILE_WRITE_EA</term>
	/// <term>Change the extended attributes (EAs) of the file. This flag is irrelevant for device and intermediate drivers.</term>
	/// </item>
	/// <item>
	/// <term>FILE_APPEND_DATA</term>
	/// <term>Append data to the file.</term>
	/// </item>
	/// <item>
	/// <term>FILE_EXECUTE</term>
	/// <term>Use system paging I/O to read data from the file into memory. This flag is irrelevant for device and intermediate drivers.</term>
	/// </item>
	/// </list>
	/// <para>
	/// <c>Note</c> Do not specify FILE_READ_DATA, FILE_WRITE_DATA, FILE_APPEND_DATA, or FILE_EXECUTE when you create or open a directory.
	/// </para>
	/// <para>The caller can only specify a generic access right, GENERIC_</para>
	/// <para>XXX</para>
	/// <para>, for a file, not a directory. Generic access rights correspond to specific access rights as shown in the following table.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Generic access right</term>
	/// <term>Set of specific access rights</term>
	/// </listheader>
	/// <item>
	/// <term>GENERIC_READ</term>
	/// <term>STANDARD_RIGHTS_READ, FILE_READ_DATA, FILE_READ_ATTRIBUTES, FILE_READ_EA, and SYNCHRONIZE.</term>
	/// </item>
	/// <item>
	/// <term>GENERIC_WRITE</term>
	/// <term>STANDARD_RIGHTS_WRITE, FILE_WRITE_DATA, FILE_WRITE_ATTRIBUTES, FILE_WRITE_EA, FILE_APPEND_DATA, and SYNCHRONIZE.</term>
	/// </item>
	/// <item>
	/// <term>GENERIC_EXECUTE</term>
	/// <term>
	/// STANDARD_RIGHTS_EXECUTE, FILE_EXECUTE, FILE_READ_ATTRIBUTES, and SYNCHRONIZE. This value is irrelevant for device and
	/// intermediate drivers.
	/// </term>
	/// </item>
	/// <item>
	/// <term>GENERIC_ALL</term>
	/// <term>FILE_ALL_ACCESS.</term>
	/// </item>
	/// </list>
	/// <para>
	/// For example, if you specify GENERIC_READ for a file object, the routine maps this value to the FILE_GENERIC_READ bitmask of
	/// specific access rights. In the preceding table, the specific access rights that are listed for GENERIC_READ correspond to the
	/// access flags that are contained in the FILE_GENERIC_READ bitmask. If the file is actually a directory, the caller can also
	/// specify the following generic access rights.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>DesiredAccess flag</term>
	/// <term>Allows caller to do this</term>
	/// </listheader>
	/// <item>
	/// <term>FILE_LIST_DIRECTORY</term>
	/// <term>List the files in the directory.</term>
	/// </item>
	/// <item>
	/// <term>FILE_TRAVERSE</term>
	/// <term>Traverse the directory, in other words, include the directory in the path of a file.</term>
	/// </item>
	/// </list>
	/// <para>For more information about access rights, see ACCESS_MASK.</para>
	/// </param>
	/// <param name="ObjectAttributes">
	/// <para>
	/// A pointer to an OBJECT_ATTRIBUTES structure that specifies the object name and other attributes. Use InitializeObjectAttributes
	/// to initialize this structure. If the caller is not running in a system thread context, it must set the OBJ_KERNEL_HANDLE
	/// attribute when it calls InitializeObjectAttributes.
	/// </para>
	/// </param>
	/// <param name="IoStatusBlock">
	/// <para>
	/// A pointer to an IO_STATUS_BLOCK structure that receives the final completion status and other information about the requested
	/// operation. In particular, the Information member receives one of the following values:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>FILE_CREATED</term>
	/// </item>
	/// <item>
	/// <term>FILE_OPENED</term>
	/// </item>
	/// <item>
	/// <term>FILE_OVERWRITTEN</term>
	/// </item>
	/// <item>
	/// <term>FILE_SUPERSEDED</term>
	/// </item>
	/// <item>
	/// <term>FILE_EXISTS</term>
	/// </item>
	/// <item>
	/// <term>FILE_DOES_NOT_EXIST</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="AllocationSize">
	/// <para>
	/// A pointer to a LARGE_INTEGER that contains the initial allocation size, in bytes, for a file that is created or overwritten. If
	/// AllocationSize is NULL, no allocation size is specified. If no file is created or overwritten, AllocationSize is ignored.
	/// </para>
	/// </param>
	/// <param name="FileAttributes">
	/// <para>
	/// Specifies one or more FILE_ATTRIBUTE_XXX flags, which represent the file attributes to set if you create or overwrite a file.
	/// The caller usually specifies FILE_ATTRIBUTE_NORMAL, which sets the default attributes. For a list of valid
	/// FILE_ATTRIBUTE_XXXflags, see the CreateFile routine in the Microsoft Windows SDK documentation. If no file is created or
	/// overwritten, FileAttributes is ignored.
	/// </para>
	/// </param>
	/// <param name="ShareAccess">
	/// <para>Type of share access, which is specified as zero or any combination of the following flags.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>ShareAccess flag</term>
	/// <term>Allows other threads to do this</term>
	/// </listheader>
	/// <item>
	/// <term>FILE_SHARE_READ</term>
	/// <term>Read the file</term>
	/// </item>
	/// <item>
	/// <term>FILE_SHARE_WRITE</term>
	/// <term>Write the file</term>
	/// </item>
	/// <item>
	/// <term>FILE_SHARE_DELETE</term>
	/// <term>Delete the file</term>
	/// </item>
	/// </list>
	/// <para>Device and intermediate drivers usually set ShareAccess to zero, which gives the caller exclusive access to the open file.</para>
	/// </param>
	/// <param name="CreateDisposition">
	/// <para>
	/// Specifies the action to perform if the file does or does not exist. CreateDisposition can be one of the values in the following table.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>CreateDisposition value</term>
	/// <term>Action if file exists</term>
	/// <term>Action if file does not exist</term>
	/// </listheader>
	/// <item>
	/// <term>FILE_SUPERSEDE</term>
	/// <term>Replace the file.</term>
	/// <term>Create the file.</term>
	/// </item>
	/// <item>
	/// <term>FILE_CREATE</term>
	/// <term>Return an error.</term>
	/// <term>Create the file.</term>
	/// </item>
	/// <item>
	/// <term>FILE_OPEN</term>
	/// <term>Open the file.</term>
	/// <term>Return an error.</term>
	/// </item>
	/// <item>
	/// <term>FILE_OPEN_IF</term>
	/// <term>Open the file.</term>
	/// <term>Create the file.</term>
	/// </item>
	/// <item>
	/// <term>FILE_OVERWRITE</term>
	/// <term>Open the file, and overwrite it.</term>
	/// <term>Return an error.</term>
	/// </item>
	/// <item>
	/// <term>FILE_OVERWRITE_IF</term>
	/// <term>Open the file, and overwrite it.</term>
	/// <term>Create the file.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="CreateOptions">
	/// <para>
	/// Specifies the options to apply when the driver creates or opens the file. Use one or more of the flags in the following table.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>CreateOptions flag</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>FILE_DIRECTORY_FILE</term>
	/// <term>
	/// The file is a directory. Compatible CreateOptions flags are FILE_SYNCHRONOUS_IO_ALERT, FILE_SYNCHRONOUS_IO_NONALERT,
	/// FILE_WRITE_THROUGH, FILE_OPEN_FOR_BACKUP_INTENT, and FILE_OPEN_BY_FILE_ID. The CreateDisposition parameter must be set to
	/// FILE_CREATE, FILE_OPEN, or FILE_OPEN_IF.
	/// </term>
	/// </item>
	/// <item>
	/// <term>FILE_NON_DIRECTORY_FILE</term>
	/// <term>
	/// The file is a directory. The file object to open can represent a data file; a logical, virtual, or physical device; or a volume.
	/// </term>
	/// </item>
	/// <item>
	/// <term>FILE_WRITE_THROUGH</term>
	/// <term>
	/// System services, file-system drivers, and drivers that write data to the file must actually transfer the data to the file before
	/// any requested write operation is considered complete.
	/// </term>
	/// </item>
	/// <item>
	/// <term>FILE_SEQUENTIAL_ONLY</term>
	/// <term>All access to the file will be sequential.</term>
	/// </item>
	/// <item>
	/// <term>FILE_RANDOM_ACCESS</term>
	/// <term>
	/// Access to the file can be random, so no sequential read-ahead operations should be performed by file-system drivers or by the system.
	/// </term>
	/// </item>
	/// <item>
	/// <term>FILE_NO_INTERMEDIATE_BUFFERING</term>
	/// <term>
	/// The file cannot be cached or buffered in a driver's internal buffers. This flag is incompatible with the DesiredAccess
	/// parameter's FILE_APPEND_DATA flag.
	/// </term>
	/// </item>
	/// <item>
	/// <term>FILE_SYNCHRONOUS_IO_ALERT</term>
	/// <term>
	/// All operations on the file are performed synchronously. Any wait on behalf of the caller is subject to premature termination
	/// from alerts. This flag also causes the I/O system to maintain the file-position pointer. If this flag is set, the SYNCHRONIZE
	/// flag must be set in the DesiredAccess parameter.
	/// </term>
	/// </item>
	/// <item>
	/// <term>FILE_SYNCHRONOUS_IO_NONALERT</term>
	/// <term>
	/// All operations on the file are performed synchronously. Waits in the system that synchronize I/O queuing and completion are not
	/// subject to alerts. This flag also causes the I/O system to maintain the file-position context. If this flag is set, the
	/// SYNCHRONIZE flag must be set in the DesiredAccess parameter.
	/// </term>
	/// </item>
	/// <item>
	/// <term>FILE_CREATE_TREE_CONNECTION</term>
	/// <term>
	/// Create a tree connection for this file in order to open it over the network. This flag is not used by device and intermediate drivers.
	/// </term>
	/// </item>
	/// <item>
	/// <term>FILE_COMPLETE_IF_OPLOCKED</term>
	/// <term>
	/// Complete this operation immediately with an alternate success code of STATUS_OPLOCK_BREAK_IN_PROGRESS if the target file is
	/// oplocked, rather than blocking the caller's thread. If the file is oplocked, another caller already has access to the file. This
	/// flag is not used by device and intermediate drivers.
	/// </term>
	/// </item>
	/// <item>
	/// <term>FILE_NO_EA_KNOWLEDGE</term>
	/// <term>
	/// If the extended attributes (EAs) for an existing file being opened indicate that the caller must understand EAs to properly
	/// interpret the file, NtCreateFile should return an error. This flag is irrelevant for device and intermediate drivers.
	/// </term>
	/// </item>
	/// <item>
	/// <term>FILE_OPEN_REPARSE_POINT</term>
	/// <term>
	/// Open a file with a reparse point and bypass normal reparse point processing for the file. For more information, see the
	/// following Remarks section.
	/// </term>
	/// </item>
	/// <item>
	/// <term>FILE_DELETE_ON_CLOSE</term>
	/// <term>
	/// The system deletes the file when the last handle to the file is passed to NtClose. If this flag is set, the DELETE flag must be
	/// set in the DesiredAccess parameter.
	/// </term>
	/// </item>
	/// <item>
	/// <term>FILE_OPEN_BY_FILE_ID</term>
	/// <term>
	/// The file name that is specified by the ObjectAttributes parameter includes a binary 8-byte or 16-byte file reference number or
	/// object ID for the file, depending on the file system as shown below. Optionally, a device name followed by a backslash character
	/// may proceed these binary values. For example, a device name will have the following format. This number is assigned by and
	/// specific to the particular file system.
	/// </term>
	/// </item>
	/// <item>
	/// <term>FILE_OPEN_FOR_BACKUP_INTENT</term>
	/// <term>
	/// The file is being opened for backup intent. Therefore, the system should check for certain access rights and grant the caller
	/// the appropriate access to the file—before checking the DesiredAccess parameter against the file's security descriptor. This flag
	/// not used by device and intermediate drivers.
	/// </term>
	/// </item>
	/// <item>
	/// <term>FILE_RESERVE_OPFILTER</term>
	/// <term>
	/// This flag allows an application to request a Filter opportunistic lock (oplock) to prevent other applications from getting share
	/// violations. If there are already open handles, the create request will fail with STATUS_OPLOCK_NOT_GRANTED. For more
	/// information, see the following Remarks section.
	/// </term>
	/// </item>
	/// <item>
	/// <term>FILE_OPEN_REQUIRING_OPLOCK</term>
	/// <term>
	/// The file is being opened and an opportunistic lock (oplock) on the file is being requested as a single atomic operation. The
	/// file system checks for oplocks before it performs the create operation, and will fail the create with a return code of
	/// STATUS_CANNOT_BREAK_OPLOCK if the result would be to break an existing oplock.
	/// </term>
	/// </item>
	/// <item>
	/// <term>FILE_SESSION_AWARE</term>
	/// <term>The client opening the file or device is session aware and per session access is validated if necessary.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="EaBuffer">
	/// <para>For device and intermediate drivers, this parameter must be a NULL pointer.</para>
	/// </param>
	/// <param name="EaLength">
	/// <para>For device and intermediate drivers, this parameter must be zero.</para>
	/// </param>
	/// <returns>
	/// NtCreateFile returns STATUS_SUCCESS on success or an appropriate NTSTATUS error code on failure. In the latter case, the caller
	/// can determine the cause of the failure by checking the IoStatusBlock parameter.
	/// <para>
	/// <c>Note</c><c>NtCreateFile</c> might return STATUS_FILE_LOCK_CONFLICT as the return value or in the <c>Status</c> member of the
	/// <c>IO_STATUS_BLOCK</c> structure that is pointed to by the IoStatusBlock parameter. This would occur only if the NTFS log file
	/// is full, and an error occurs while <c>NtCreateFile</c> tries to handle this situation.
	/// </para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// <c>NtCreateFile</c> supplies a handle that the caller can use to manipulate a file's data, or the file object's state and
	/// attributes. For more information, see Using Files in a Driver.
	/// </para>
	/// <para>Once the handle pointed to by FileHandle is no longer in use, the driver must call NtClose to close it.</para>
	/// <para>
	/// If the caller is not running in a system thread context, it must ensure that any handles it creates are private handles.
	/// Otherwise, the handle can be accessed by the process in whose context the driver is running. For more information, see Object Handles.
	/// </para>
	/// <para>There are two alternate ways to specify the name of the file to be created or opened with <c>NtCreateFile</c>:</para>
	/// <para>Setting certain flags in the DesiredAccess parameter results in the following effects:</para>
	/// <para>
	/// The ShareAccess parameter determines whether separate threads can access the same file, possibly simultaneously. Provided that
	/// both callers have the appropriate access privileges, the file can be successfully opened and shared. If the original caller of
	/// <c>NtCreateFile</c> does not specify FILE_SHARE_READ, FILE_SHARE_WRITE, or FILE_SHARE_DELETE, no other caller can open the
	/// file—that is, the original caller is granted exclusive access.
	/// </para>
	/// <para>
	/// To successfully open a shared file, the DesiredAccess flags must be compatible with the DesiredAccess and ShareAccess flags of
	/// all the previous open operations that have not yet been released through . That is, the DesiredAccess specified to
	/// <c>NtCreateFile</c> for a given file must not conflict with the accesses that other openers of the file have disallowed.
	/// </para>
	/// <para>
	/// The CreateDisposition value FILE_SUPERSEDE requires that the caller have DELETE access to a existing file object. If so, a
	/// successful call to <c>NtCreateFile</c> with FILE_SUPERSEDE on an existing file effectively deletes that file, and then recreates
	/// it. This implies that, if the file has already been opened by another thread, it opened the file by specifying a ShareAccess
	/// parameter with the FILE_SHARE_DELETE flag set. Note that this type of disposition is consistent with the POSIX style of
	/// overwriting files.
	/// </para>
	/// <para>
	/// The CreateDisposition values FILE_OVERWRITE_IF and FILE_SUPERSEDE are similar. If <c>NtCreateFile</c> is called with a existing
	/// file and either of these CreateDisposition values, the file will be replaced.
	/// </para>
	/// <para>Overwriting a file is semantically equivalent to a supersede operation, except for the following:</para>
	/// <para>
	/// The FILE_DIRECTORY_FILE CreateOptions value specifies that the file to be created or opened is a directory. When a directory
	/// file is created, the file system creates an appropriate structure on the disk to represent an empty directory for that
	/// particular file system's on-disk structure. If this option was specified and the given file to be opened is not a directory
	/// file, or if the caller specified an inconsistent CreateOptions or CreateDisposition value, the call to <c>NtCreateFile</c> will fail.
	/// </para>
	/// <para>
	/// The FILE_NO_INTERMEDIATE_BUFFERING CreateOptions flag prevents the file system from performing any intermediate buffering on
	/// behalf of the caller. Specifying this flag places the following restrictions on the caller's parameters to other
	/// <c>ZwXxxFile</c> routines.
	/// </para>
	/// <para>
	/// The FILE_SYNCHRONOUS_IO_ALERT and FILE_SYNCHRONOUS_IO_NONALERT CreateOptions flags, which are mutually exclusive as their names
	/// suggest, specify that all I/O operations on the file will be synchronous—as long as they occur through the file object referred
	/// to by the returned FileHandle. All I/O on such a file is serialized across all threads using the returned handle. If either of
	/// these CreateOptions flags is set, the SYNCHRONIZE DesiredAccess flag must also be set—to compel the I/O manager to use the file
	/// object as a synchronization object. In these cases, the I/O manager keeps track of the current file-position offset, which you
	/// can pass to <c>NtReadFile</c> and <c>NtWriteFile</c>. Call <c>NtQueryInformationFile</c> or <c>NtSetInformationFile</c> to get
	/// or set this position.
	/// </para>
	/// <para>
	/// If the CreateOptions FILE_OPEN_REPARSE_POINT flag is specified and <c>NtCreateFile</c> attempts to open a file with a reparse
	/// point, normal reparse point processing occurs for the file. If, on the other hand, the FILE_OPEN_REPARSE_POINT flag is
	/// specified, normal reparse processing does occur and <c>NtCreateFile</c> attempts to directly open the reparse point file. In
	/// either case, if the open operation was successful, <c>NtCreateFile</c> returns STATUS_SUCCESS; otherwise, the routine returns an
	/// NTSTATUS error code. <c>NtCreateFile</c> never returns STATUS_REPARSE.
	/// </para>
	/// <para>
	/// The CreateOptions FILE_OPEN_REQUIRING_OPLOCK flag eliminates the time between when you open the file and request an oplock that
	/// could potentially allow a third party to open the file and get a sharing violation. An application can use the
	/// FILE_OPEN_REQUIRING_OPLOCK flag on <c>NtCreateFile</c> and then request any oplock. This ensures that an oplock owner will be
	/// notified of any subsequent open request that causes a sharing violation.
	/// </para>
	/// <para>
	/// In Windows 7, if other handles exist on the file when an application uses the FILE_OPEN_REQUIRING_OPLOCK flag, the create
	/// operation will fail with STATUS_OPLOCK_NOT_GRANTED. This restriction no longer exists starting with Windows 8.
	/// </para>
	/// <para>
	/// If this create operation would break an oplock that already exists on the file, then setting the FILE_OPEN_REQUIRING_OPLOCK flag
	/// will cause the create operation to fail with STATUS_CANNOT_BREAK_OPLOCK. The existing oplock will not be broken by this create operation.
	/// </para>
	/// <para>
	/// An application that uses the FILE_OPEN_REQUIRING_OPLOCK flag must request an oplock after this call succeeds, or all subsequent
	/// attempts to open the file will be blocked without the benefit of normal oplock processing. Similarly, if this call succeeds but
	/// the subsequent oplock request fails, an application that uses this flag must close its handle after it detects that the oplock
	/// request has failed.
	/// </para>
	/// <para>
	/// The CreateOptions flag FILE_RESERVE_OPFILTER allows an application to request a Level 1, Batch, or Filter oplock to prevent
	/// other applications from getting share violations. However, FILE_RESERVE_OPFILTER is only practically useful for Filter oplocks.
	/// To use it, you must complete the following steps:
	/// </para>
	/// <para>
	/// Step three makes this practical only for Filter oplocks. The handle opened in step 3 can have a DesiredAccess that contains a
	/// maximum of FILE_READ_ATTRIBUTES | FILE_WRITE_ATTRIBUTES | FILE_READ_DATA | FILE_READ_EA | FILE_EXECUTE | SYNCHRONIZE |
	/// READ_CONTROL and still not break a Filter oplock. However, any DesiredAccess greater than FILE_READ_ATTRIBUTES |
	/// FILE_WRITE_ATTRIBUTES | SYNCHRONIZE will break a Level 1 or Batch oplock and make the FILE_RESERVE_OPFILTER flag useless for
	/// those oplock types.
	/// </para>
	/// <para>NTFS is the only Microsoft file system that implements FILE_RESERVE_OPFILTER.</para>
	/// <para>Callers of <c>NtCreateFile</c> must be running at IRQL = PASSIVE_LEVEL and with special kernel APCs enabled.</para>
	/// <para>
	/// For calls from kernel-mode drivers, the <c>NtXxx</c> and <c>ZwXxx</c> versions of a Windows Native System Services routine can
	/// behave differently in the way that they handle and interpret input parameters. For more information about the relationship
	/// between the <c>NtXxx</c> and <c>ZwXxx</c> versions of a routine, see Using Nt and Zw Versions of the Native System Services Routines.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows-hardware/drivers/ddi/content/ntifs/nf-ntifs-ntcreatefile __kernel_entry NTSYSCALLAPI
	// NTSTATUS NtCreateFile( PHANDLE FileHandle, ACCESS_MASK DesiredAccess, POBJECT_ATTRIBUTES ObjectAttributes, PIO_STATUS_BLOCK
	// IoStatusBlock, PLARGE_INTEGER AllocationSize, ULONG FileAttributes, ULONG ShareAccess, ULONG CreateDisposition, ULONG
	// CreateOptions, PVOID EaBuffer, ULONG EaLength );
	[DllImport(Lib.NtDll, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("ntifs.h", MSDNShortId = "c40b99be-5627-44f3-9853-c3ae31a8035c")]
	// public static extern __kernel_entry NTSYSCALLAPI NTSTATUS NtCreateFile(ref IntPtr FileHandle, ACCESS_MASK DesiredAccess,
	// POBJECT_ATTRIBUTES ObjectAttributes, PIO_STATUS_BLOCK IoStatusBlock, PLARGE_INTEGER AllocationSize, uint FileAttributes, uint
	// ShareAccess, uint CreateDisposition, uint CreateOptions, IntPtr EaBuffer, uint EaLength);
	public static extern NTStatus NtCreateFile(out SafeHFILE FileHandle, ACCESS_MASK DesiredAccess, in OBJECT_ATTRIBUTES ObjectAttributes, out IO_STATUS_BLOCK IoStatusBlock,
		[In, Optional] IntPtr AllocationSize, FileFlagsAndAttributes FileAttributes, FileShare ShareAccess, NtFileMode CreateDisposition, NtFileCreateOptions CreateOptions,
		IntPtr EaBuffer = default, uint EaLength = 0);

	/// <summary>
	/// <para>The <c>NtCreateSection</c> routine creates a section object.</para>
	/// </summary>
	/// <param name="SectionHandle">
	/// <para>Pointer to a HANDLE variable that receives a handle to the section object.</para>
	/// </param>
	/// <param name="DesiredAccess">
	/// <para>
	/// Specifies an ACCESS_MASK value that determines the requested access to the object. In addition to the access rights that are
	/// defined for all types of objects (see ACCESS_MASK), the caller can specify any of the following access rights, which are
	/// specific to section objects:
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>DesiredAccess flag</term>
	/// <term>Allows caller to do this</term>
	/// </listheader>
	/// <item>
	/// <term>SECTION_EXTEND_SIZE</term>
	/// <term>Dynamically extend the size of the section.</term>
	/// </item>
	/// <item>
	/// <term>SECTION_MAP_EXECUTE</term>
	/// <term>Execute views of the section.</term>
	/// </item>
	/// <item>
	/// <term>SECTION_MAP_READ</term>
	/// <term>Read views of the section.</term>
	/// </item>
	/// <item>
	/// <term>SECTION_MAP_WRITE</term>
	/// <term>Write views of the section.</term>
	/// </item>
	/// <item>
	/// <term>SECTION_QUERY</term>
	/// <term>Query the section object for information about the section. Drivers should set this flag.</term>
	/// </item>
	/// <item>
	/// <term>SECTION_ALL_ACCESS</term>
	/// <term>All of the previous flags combined with STANDARD_RIGHTS_REQUIRED.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="ObjectAttributes">
	/// <para>
	/// Pointer to an OBJECT_ATTRIBUTES structure that specifies the object name and other attributes. Use InitializeObjectAttributes to
	/// initialize this structure. If the caller is not running in a system thread context, it must set the OBJ_KERNEL_HANDLE attribute
	/// when it calls <c>InitializeObjectAttributes</c>.
	/// </para>
	/// </param>
	/// <param name="MaximumSize">
	/// <para>
	/// Specifies the maximum size, in bytes, of the section. <c>NtCreateSection</c> rounds this value up to the nearest multiple of
	/// PAGE_SIZE. If the section is backed by the paging file, MaximumSize specifies the actual size of the section. If the section is
	/// backed by an ordinary file, MaximumSize specifies the maximum size that the file can be extended or mapped to.
	/// </para>
	/// </param>
	/// <param name="SectionPageProtection">
	/// <para>
	/// Specifies the protection to place on each page in the section. Use one of the following four values: PAGE_READONLY,
	/// PAGE_READWRITE, PAGE_EXECUTE, or PAGE_WRITECOPY. For a description of these values, see CreateFileMapping.
	/// </para>
	/// </param>
	/// <param name="AllocationAttributes">
	/// <para>
	/// Specifies a bitmask of SEC_XXX flags that determines the allocation attributes of the section. For a description of these flags,
	/// see CreateFileMapping.
	/// </para>
	/// </param>
	/// <param name="FileHandle">
	/// <para>
	/// Optionally specifies a handle for an open file object. If the value of FileHandle is <c>NULL</c>, the section is backed by the
	/// paging file. Otherwise, the section is backed by the specified file.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>
	/// <c>NtCreateSection</c> returns STATUS_SUCCESS on success, or the appropriate NTSTATUS error code on failure. Possible error
	/// status codes include the following:
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>STATUS_FILE_LOCK_CONFLICT</term>
	/// <term>The file specified by the FileHandle parameter is locked.</term>
	/// </item>
	/// <item>
	/// <term>STATUS_INVALID_FILE_FOR_SECTION</term>
	/// <term>The file specified by FileHandle does not support sections.</term>
	/// </item>
	/// <item>
	/// <term>STATUS_INVALID_PAGE_PROTECTION</term>
	/// <term>The value specified for the SectionPageProtection parameter is invalid.</term>
	/// </item>
	/// <item>
	/// <term>STATUS_MAPPED_FILE_SIZE_ZERO</term>
	/// <term>The size of the file specified by FileHandle is zero, and MaximumSize is zero.</term>
	/// </item>
	/// <item>
	/// <term>STATUS_SECTION_TOO_BIG</term>
	/// <term>
	/// The value of MaximumSize is too big. This occurs when either MaximumSize is greater than the system-defined maximum for
	/// sections, or if MaximumSize is greater than the specified file and the section is not writable.
	/// </term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>Once the handle pointed to by SectionHandle is no longer in use, the driver must call NtClose to close it.</para>
	/// <para>
	/// If the caller is not running in a system thread context, it must ensure that any handles it creates are private handles.
	/// Otherwise, the handle can be accessed by the process in whose context the driver is running. For more information, see Object Handles.
	/// </para>
	/// <para>For more information about setting up mapped sections and views of memory, see Sections and Views.</para>
	/// <para>
	/// For calls from kernel-mode drivers, the <c>NtXxx</c> and <c>ZwXxx</c> versions of a Windows Native System Services routine can
	/// behave differently in the way that they handle and interpret input parameters. For more information about the relationship
	/// between the <c>NtXxx</c> and <c>ZwXxx</c> versions of a routine, see Using Nt and Zw Versions of the Native System Services Routines.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows-hardware/drivers/ddi/content/ntifs/nf-ntifs-ntcreatesection __kernel_entry NTSYSCALLAPI
	// NTSTATUS NtCreateSection( PHANDLE SectionHandle, ACCESS_MASK DesiredAccess, POBJECT_ATTRIBUTES ObjectAttributes, PLARGE_INTEGER
	// MaximumSize, ULONG SectionPageProtection, ULONG AllocationAttributes, HANDLE FileHandle );
	[DllImport(Lib.NtDll, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("ntifs.h", MSDNShortId = "805d7eff-19be-47a1-acc9-1b97e5493031")]
	public static extern NTStatus NtCreateSection(out SafeSectionHandle SectionHandle, ACCESS_MASK DesiredAccess, in OBJECT_ATTRIBUTES ObjectAttributes, in long MaximumSize,
		MEM_PROTECTION SectionPageProtection, SEC_ALLOC AllocationAttributes, [Optional] HFILE FileHandle);

	/// <summary>
	/// <para>The <c>NtCreateSection</c> routine creates a section object.</para>
	/// </summary>
	/// <param name="SectionHandle">
	/// <para>Pointer to a HANDLE variable that receives a handle to the section object.</para>
	/// </param>
	/// <param name="DesiredAccess">
	/// <para>
	/// Specifies an ACCESS_MASK value that determines the requested access to the object. In addition to the access rights that are
	/// defined for all types of objects (see ACCESS_MASK), the caller can specify any of the following access rights, which are
	/// specific to section objects:
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>DesiredAccess flag</term>
	/// <term>Allows caller to do this</term>
	/// </listheader>
	/// <item>
	/// <term>SECTION_EXTEND_SIZE</term>
	/// <term>Dynamically extend the size of the section.</term>
	/// </item>
	/// <item>
	/// <term>SECTION_MAP_EXECUTE</term>
	/// <term>Execute views of the section.</term>
	/// </item>
	/// <item>
	/// <term>SECTION_MAP_READ</term>
	/// <term>Read views of the section.</term>
	/// </item>
	/// <item>
	/// <term>SECTION_MAP_WRITE</term>
	/// <term>Write views of the section.</term>
	/// </item>
	/// <item>
	/// <term>SECTION_QUERY</term>
	/// <term>Query the section object for information about the section. Drivers should set this flag.</term>
	/// </item>
	/// <item>
	/// <term>SECTION_ALL_ACCESS</term>
	/// <term>All of the previous flags combined with STANDARD_RIGHTS_REQUIRED.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="ObjectAttributes">
	/// <para>
	/// Pointer to an OBJECT_ATTRIBUTES structure that specifies the object name and other attributes. Use InitializeObjectAttributes to
	/// initialize this structure. If the caller is not running in a system thread context, it must set the OBJ_KERNEL_HANDLE attribute
	/// when it calls <c>InitializeObjectAttributes</c>.
	/// </para>
	/// </param>
	/// <param name="MaximumSize">
	/// <para>
	/// Specifies the maximum size, in bytes, of the section. <c>NtCreateSection</c> rounds this value up to the nearest multiple of
	/// PAGE_SIZE. If the section is backed by the paging file, MaximumSize specifies the actual size of the section. If the section is
	/// backed by an ordinary file, MaximumSize specifies the maximum size that the file can be extended or mapped to.
	/// </para>
	/// </param>
	/// <param name="SectionPageProtection">
	/// <para>
	/// Specifies the protection to place on each page in the section. Use one of the following four values: PAGE_READONLY,
	/// PAGE_READWRITE, PAGE_EXECUTE, or PAGE_WRITECOPY. For a description of these values, see CreateFileMapping.
	/// </para>
	/// </param>
	/// <param name="AllocationAttributes">
	/// <para>
	/// Specifies a bitmask of SEC_XXX flags that determines the allocation attributes of the section. For a description of these flags,
	/// see CreateFileMapping.
	/// </para>
	/// </param>
	/// <param name="FileHandle">
	/// <para>
	/// Optionally specifies a handle for an open file object. If the value of FileHandle is <c>NULL</c>, the section is backed by the
	/// paging file. Otherwise, the section is backed by the specified file.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>
	/// <c>NtCreateSection</c> returns STATUS_SUCCESS on success, or the appropriate NTSTATUS error code on failure. Possible error
	/// status codes include the following:
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>STATUS_FILE_LOCK_CONFLICT</term>
	/// <term>The file specified by the FileHandle parameter is locked.</term>
	/// </item>
	/// <item>
	/// <term>STATUS_INVALID_FILE_FOR_SECTION</term>
	/// <term>The file specified by FileHandle does not support sections.</term>
	/// </item>
	/// <item>
	/// <term>STATUS_INVALID_PAGE_PROTECTION</term>
	/// <term>The value specified for the SectionPageProtection parameter is invalid.</term>
	/// </item>
	/// <item>
	/// <term>STATUS_MAPPED_FILE_SIZE_ZERO</term>
	/// <term>The size of the file specified by FileHandle is zero, and MaximumSize is zero.</term>
	/// </item>
	/// <item>
	/// <term>STATUS_SECTION_TOO_BIG</term>
	/// <term>
	/// The value of MaximumSize is too big. This occurs when either MaximumSize is greater than the system-defined maximum for
	/// sections, or if MaximumSize is greater than the specified file and the section is not writable.
	/// </term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>Once the handle pointed to by SectionHandle is no longer in use, the driver must call NtClose to close it.</para>
	/// <para>
	/// If the caller is not running in a system thread context, it must ensure that any handles it creates are private handles.
	/// Otherwise, the handle can be accessed by the process in whose context the driver is running. For more information, see Object Handles.
	/// </para>
	/// <para>For more information about setting up mapped sections and views of memory, see Sections and Views.</para>
	/// <para>
	/// For calls from kernel-mode drivers, the <c>NtXxx</c> and <c>ZwXxx</c> versions of a Windows Native System Services routine can
	/// behave differently in the way that they handle and interpret input parameters. For more information about the relationship
	/// between the <c>NtXxx</c> and <c>ZwXxx</c> versions of a routine, see Using Nt and Zw Versions of the Native System Services Routines.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows-hardware/drivers/ddi/content/ntifs/nf-ntifs-ntcreatesection __kernel_entry NTSYSCALLAPI
	// NTSTATUS NtCreateSection( PHANDLE SectionHandle, ACCESS_MASK DesiredAccess, POBJECT_ATTRIBUTES ObjectAttributes, PLARGE_INTEGER
	// MaximumSize, ULONG SectionPageProtection, ULONG AllocationAttributes, HANDLE FileHandle );
	[DllImport(Lib.NtDll, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("ntifs.h", MSDNShortId = "805d7eff-19be-47a1-acc9-1b97e5493031")]
	public static extern NTStatus NtCreateSection(out SafeSectionHandle SectionHandle, ACCESS_MASK DesiredAccess, [In, Optional] IntPtr ObjectAttributes, [In, Optional] IntPtr MaximumSize,
		MEM_PROTECTION SectionPageProtection, SEC_ALLOC AllocationAttributes, [Optional] HFILE FileHandle);

	/// <summary>The <c>RtlAllocateHeap</c> routine allocates a block of memory from a heap.</summary>
	/// <param name="HeapHandle">
	/// [in] Handle for a private heap from which the memory will be allocated. This parameter is a handle returned from a successful
	/// call to <c>RtlCreateHeap</c> .
	/// </param>
	/// <param name="Flags">
	/// <para>
	/// [in, optional] Controllable aspects of heap allocation. Specifying any of these values will override the corresponding value
	/// specified when the heap was created with <c>RtlCreateHeap</c>. This parameter can be one or more of the following values.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Flag</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>HEAP_GENERATE_EXCEPTIONS</term>
	/// <term>
	/// The system will raise an exception to indicate a function failure, such as an out-of-memory condition, instead of returning NULL.
	/// </term>
	/// </item>
	/// <item>
	/// <term>HEAP_NO_SERIALIZE</term>
	/// <term>Mutual exclusion will not be used while RtlAllocateHeap is accessing the heap.</term>
	/// </item>
	/// <item>
	/// <term>HEAP_ZERO_MEMORY</term>
	/// <term>The allocated memory will be initialized to zero. Otherwise, the memory is not initialized to zero.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="Size">
	/// [in] Number of bytes to be allocated. If the heap, specified by the HeapHandle parameter, is a nongrowable heap, Size must be
	/// less than or equal to the heap's virtual memory threshold. (For more information, see the <c>VirtualMemoryThreshold</c> member
	/// of the Parameters parameter to <c>RtlCreateHeap</c>.)
	/// </param>
	/// <returns>
	/// If the call to <c>RtlAllocateHeap</c> succeeds, the return value is a pointer to the newly-allocated block. The return value is
	/// NULL if the allocation failed.
	/// </returns>
	/// <remarks>
	/// <para><c>RtlAllocateHeap</c> allocates a block of memory of the specified size from the specified heap.</para>
	/// <para>To free a block of memory allocated by <c>RtlAllocateHeap</c>, call <c>RtlFreeHeap</c>.</para>
	/// <para>
	/// Memory allocated by <c>RtlAllocateHeap</c> is not movable. Since the memory is not movable, it is possible for the heap to
	/// become fragmented.
	/// </para>
	/// <para>
	/// Serialization ensures mutual exclusion when two or more threads attempt to simultaneously allocate or free blocks from the same
	/// heap. There is a small performance cost to serialization, but it must be used whenever multiple threads allocate and free memory
	/// from the same heap. Setting the HEAP_NO_SERIALIZE value eliminates mutual exclusion on the heap. Without serialization, two or
	/// more threads that use the same heap handle might attempt to allocate or free memory simultaneously, likely causing corruption in
	/// the heap. The HEAP_NO_SERIALIZE value can, therefore, be safely used only in the following situations:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>
	/// <para>The process has only one thread.</para>
	/// </term>
	/// </item>
	/// <item>
	/// <term>
	/// <para>The process has multiple threads, but only one thread calls the heap functions for a specific heap.</para>
	/// </term>
	/// </item>
	/// <item>
	/// <term>
	/// <para>The process has multiple threads, and the application provides its own mechanism for mutual exclusion to a specific heap.</para>
	/// </term>
	/// </item>
	/// </list>
	/// <para>
	/// <para>Note</para>
	/// <para>
	/// To guard against an access violation, use structured exception handling to protect any code that writes to or reads from a heap.
	/// For more information about structured exception handling with memory accesses, see Handling Exceptions.
	/// </para>
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows-hardware/drivers/ddi/ntifs/nf-ntifs-rtlallocateheap NTSYSAPI PVOID RtlAllocateHeap(
	// PVOID HeapHandle, ULONG Flags, SIZE_T Size );
	[DllImport(Lib.NtDll, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("ntifs.h", MSDNShortId = "NF:ntifs.RtlAllocateHeap")]
	public static extern IntPtr RtlAllocateHeap(IntPtr HeapHandle, [In, Optional] HeapFlags Flags, SizeT Size);

	/// <summary>
	/// The <c>RtlCreateHeap</c> routine creates a heap object that can be used by the calling process. This routine reserves space in
	/// the virtual address space of the process and allocates physical storage for a specified initial portion of this block.
	/// </summary>
	/// <param name="Flags">
	/// <para>
	/// [in] Flags specifying optional attributes of the heap. These options affect subsequent access to the new heap through calls to
	/// the heap functions (RtlAllocateHeap and RtlFreeHeap).
	/// </para>
	/// <para>Callers should set this parameter to zero if no optional attributes are requested.</para>
	/// <para>This parameter can be one or more of the following values.</para>
	/// <para>HEAP_GENERATE_EXCEPTIONS</para>
	/// <para>
	/// Specifies that the system will indicate a heap failure by raising an exception, such as STATUS_NO_MEMORY, instead of returning <c>NULL</c>.
	/// </para>
	/// <para>HEAP_GROWABLE</para>
	/// <para>Specifies that the heap is growable. Must be specified if HeapBase is <c>NULL</c>.</para>
	/// <para>HEAP_NO_SERIALIZE</para>
	/// <para>
	/// Specifies that mutual exclusion will not be used when the heap functions allocate and free memory from this heap. The default,
	/// when HEAP_NO_SERIALIZE is not specified, is to serialize access to the heap. Serialization of heap access allows two or more
	/// threads to simultaneously allocate and free memory from the same heap.
	/// </para>
	/// </param>
	/// <param name="HeapBase">
	/// <para>[in, optional] Specifies one of two actions:</para>
	/// <para>
	/// If HeapBase is a non- <c>NULL</c> value, it specifies the base address for a block of caller-allocated memory to use for the heap.
	/// </para>
	/// <para>
	/// If HeapBase is <c>NULL</c>, <c>RtlCreateHeap</c> allocates system memory for the heap from the process's virtual address space.
	/// </para>
	/// </param>
	/// <param name="ReserveSize">
	/// <para>
	/// [in, optional] If ReserveSize is a nonzero value, it specifies the initial amount of memory, in bytes, to reserve for the heap.
	/// <c>RtlCreateHeap</c> rounds ReserveSize up to the next page boundary, and then reserves a block of that size for the heap.
	/// </para>
	/// <para>
	/// This parameter is optional and can be zero. The following table summarizes the interaction of the ReserveSize and CommitSize parameters.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Values</term>
	/// <term>Result</term>
	/// </listheader>
	/// <item>
	/// <term>ReserveSize zero, CommitSize zero</term>
	/// <term>64 pages are initially reserved for the heap. One page is initially committed.</term>
	/// </item>
	/// <item>
	/// <term>ReserveSize zero, CommitSize nonzero</term>
	/// <term>
	/// RtlCreateHeap sets ReserveSize to be equal to CommitSize, and then rounds ReserveSize up to the nearest multiple of (PAGE_SIZE * 16).
	/// </term>
	/// </item>
	/// <item>
	/// <term>ReserveSize nonzero, CommitSize zero</term>
	/// <term>One page is initially committed for the heap.</term>
	/// </item>
	/// <item>
	/// <term>ReserveSize nonzero, CommitSize nonzero</term>
	/// <term>If CommitSize is greater than ReserveSize, RtlCreateHeap reduces CommitSize to ReserveSize.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="CommitSize">
	/// <para>
	/// [in, optional] If CommitSize is a nonzero value, it specifies the initial amount of memory, in bytes, to commit for the heap.
	/// <c>RtlCreateHeap</c> rounds CommitSize up to the next page boundary, and then commits a block of that size in the process's
	/// virtual address space for the heap.
	/// </para>
	/// <para>This parameter is optional and can be zero.</para>
	/// </param>
	/// <param name="Lock">
	/// [in, optional] Pointer to an opaque ERESOURCE structure to be used as a resource lock. This parameter is optional and can be
	/// <c>NULL</c>. When provided by the caller, the structure must be allocated from nonpaged pool and initialized by calling
	/// ExInitializeResourceLite or ExReinitializeResourceLite. If the HEAP_NO_SERIALIZE flag is set, this parameter must be <c>NULL</c>.
	/// </param>
	/// <param name="Parameters">
	/// [in, optional] Pointer to a RTL_HEAP_PARAMETERS structure that contains parameters to be applied when creating the heap. This
	/// parameter is optional and can be <c>NULL</c>.
	/// </param>
	/// <returns><c>RtlCreateHeap</c> returns a handle to be used in accessing the created heap.</returns>
	/// <remarks>
	/// <para>
	/// <c>RtlCreateHeap</c> creates a private heap object from which the calling process can allocate memory blocks by calling
	/// RtlAllocateHeap. The initial commit size determines the number of pages that are initially allocated for the heap. The initial
	/// reserve size determines the number of pages that are initially reserved for the heap. Pages that are reserved but uncommitted
	/// create a block in the process's virtual address space into which the heap can expand.
	/// </para>
	/// <para>
	/// If allocation requests made by RtlAllocateHeap exceed the heap's initial commit size, the system commits additional pages of
	/// physical storage for the heap, up to the heap's maximum size. If the heap is nongrowable, its maximum size is limited to its
	/// initial reserve size.
	/// </para>
	/// <para>
	/// If the heap is growable, its size is limited only by available memory. If requests by RtlAllocateHeap exceed the current size of
	/// committed pages, the system calls ZwAllocateVirtualMemory to obtain the memory needed, assuming that the physical storage is available.
	/// </para>
	/// <para>
	/// In addition, if the heap is nongrowable, an absolute limitation arises: the maximum size of a memory block in the heap is
	/// 0x7F000 bytes. The virtual memory threshold of the heap is equal to the maximum heap block size or the value of the
	/// <c>VirtualMemoryThreshold</c> member of the Parameters structure, whichever is less. The heap also may need to pad the request
	/// size for metadata and alignment purposes so requests to allocate blocks within 4096 Bytes (1 Page) of the
	/// <c>VirtualMemoryThreshold</c> may fail even if the maximum size of the heap is large enough to contain the block. (For more
	/// information about <c>VirtualMemoryThreshold</c>, see the members of the Parameters parameter to <c>RtlCreateHeap</c>.)
	/// </para>
	/// <para>
	/// If the heap is growable, requests to allocate blocks larger than the heap's virtual memory threshold do not automatically fail;
	/// the system calls ZwAllocateVirtualMemory to obtain the memory needed for such large blocks.
	/// </para>
	/// <para>The memory of a private heap object is accessible only to the process that created it.</para>
	/// <para>
	/// The system uses memory from the private heap to store heap support structures, so not all of the specified heap size is
	/// available to the process. For example, if RtlAllocateHeap requests 64 kilobytes (K) from a heap with a maximum size of 64K, the
	/// request may fail because of system overhead.
	/// </para>
	/// <para>
	/// If HEAP_NO_SERIALIZE is not specified (the simple default), the heap will serialize access within the calling process.
	/// Serialization ensures mutual exclusion when two or more threads attempt to simultaneously allocate or free blocks from the same
	/// heap. There is a small performance cost to serialization, but it must be used whenever multiple threads allocate and free memory
	/// from the same heap.
	/// </para>
	/// <para>
	/// Setting HEAP_NO_SERIALIZE eliminates mutual exclusion on the heap. Without serialization, two or more threads that use the same
	/// heap handle might attempt to allocate or free memory simultaneously, likely causing corruption in the heap. Therefore,
	/// HEAP_NO_SERIALIZE can safely be used only in the following situations:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>The process has only one thread.</term>
	/// </item>
	/// <item>
	/// <term>The process has multiple threads, but only one thread calls the heap functions for a specific heap.</term>
	/// </item>
	/// <item>
	/// <term>The process has multiple threads, and the application provides its own mechanism for mutual exclusion to a specific heap.</term>
	/// </item>
	/// </list>
	/// <para><c>Note</c>
	/// <para></para>
	/// To guard against an access violation, use structured exception handling to protect any code that writes to or reads from a heap.
	/// For more information about structured exception handling with memory accesses, see Handling Exceptions.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows-hardware/drivers/ddi/ntifs/nf-ntifs-rtlcreateheap NTSYSAPI PVOID RtlCreateHeap( ULONG
	// Flags, PVOID HeapBase, SIZE_T ReserveSize, SIZE_T CommitSize, PVOID Lock, PRTL_HEAP_PARAMETERS Parameters );
	[DllImport(Lib.NtDll, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("ntifs.h", MSDNShortId = "NF:ntifs.RtlCreateHeap")]
	public static extern IntPtr RtlCreateHeap([In, Optional] HeapFlags Flags, [In, Optional] IntPtr HeapBase, [In, Optional] SizeT ReserveSize,
		[In, Optional] SizeT CommitSize, [In, Optional] IntPtr Lock, [In, Optional] IntPtr Parameters);

	/// <summary>
	/// The <c>RtlCreateHeap</c> routine creates a heap object that can be used by the calling process. This routine reserves space in
	/// the virtual address space of the process and allocates physical storage for a specified initial portion of this block.
	/// </summary>
	/// <param name="Flags">
	/// <para>
	/// [in] Flags specifying optional attributes of the heap. These options affect subsequent access to the new heap through calls to
	/// the heap functions (RtlAllocateHeap and RtlFreeHeap).
	/// </para>
	/// <para>Callers should set this parameter to zero if no optional attributes are requested.</para>
	/// <para>This parameter can be one or more of the following values.</para>
	/// <para>HEAP_GENERATE_EXCEPTIONS</para>
	/// <para>
	/// Specifies that the system will indicate a heap failure by raising an exception, such as STATUS_NO_MEMORY, instead of returning <c>NULL</c>.
	/// </para>
	/// <para>HEAP_GROWABLE</para>
	/// <para>Specifies that the heap is growable. Must be specified if HeapBase is <c>NULL</c>.</para>
	/// <para>HEAP_NO_SERIALIZE</para>
	/// <para>
	/// Specifies that mutual exclusion will not be used when the heap functions allocate and free memory from this heap. The default,
	/// when HEAP_NO_SERIALIZE is not specified, is to serialize access to the heap. Serialization of heap access allows two or more
	/// threads to simultaneously allocate and free memory from the same heap.
	/// </para>
	/// </param>
	/// <param name="HeapBase">
	/// <para>[in, optional] Specifies one of two actions:</para>
	/// <para>
	/// If HeapBase is a non- <c>NULL</c> value, it specifies the base address for a block of caller-allocated memory to use for the heap.
	/// </para>
	/// <para>
	/// If HeapBase is <c>NULL</c>, <c>RtlCreateHeap</c> allocates system memory for the heap from the process's virtual address space.
	/// </para>
	/// </param>
	/// <param name="ReserveSize">
	/// <para>
	/// [in, optional] If ReserveSize is a nonzero value, it specifies the initial amount of memory, in bytes, to reserve for the heap.
	/// <c>RtlCreateHeap</c> rounds ReserveSize up to the next page boundary, and then reserves a block of that size for the heap.
	/// </para>
	/// <para>
	/// This parameter is optional and can be zero. The following table summarizes the interaction of the ReserveSize and CommitSize parameters.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Values</term>
	/// <term>Result</term>
	/// </listheader>
	/// <item>
	/// <term>ReserveSize zero, CommitSize zero</term>
	/// <term>64 pages are initially reserved for the heap. One page is initially committed.</term>
	/// </item>
	/// <item>
	/// <term>ReserveSize zero, CommitSize nonzero</term>
	/// <term>
	/// RtlCreateHeap sets ReserveSize to be equal to CommitSize, and then rounds ReserveSize up to the nearest multiple of (PAGE_SIZE * 16).
	/// </term>
	/// </item>
	/// <item>
	/// <term>ReserveSize nonzero, CommitSize zero</term>
	/// <term>One page is initially committed for the heap.</term>
	/// </item>
	/// <item>
	/// <term>ReserveSize nonzero, CommitSize nonzero</term>
	/// <term>If CommitSize is greater than ReserveSize, RtlCreateHeap reduces CommitSize to ReserveSize.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="CommitSize">
	/// <para>
	/// [in, optional] If CommitSize is a nonzero value, it specifies the initial amount of memory, in bytes, to commit for the heap.
	/// <c>RtlCreateHeap</c> rounds CommitSize up to the next page boundary, and then commits a block of that size in the process's
	/// virtual address space for the heap.
	/// </para>
	/// <para>This parameter is optional and can be zero.</para>
	/// </param>
	/// <param name="Lock">
	/// [in, optional] Pointer to an opaque ERESOURCE structure to be used as a resource lock. This parameter is optional and can be
	/// <c>NULL</c>. When provided by the caller, the structure must be allocated from nonpaged pool and initialized by calling
	/// ExInitializeResourceLite or ExReinitializeResourceLite. If the HEAP_NO_SERIALIZE flag is set, this parameter must be <c>NULL</c>.
	/// </param>
	/// <param name="Parameters">
	/// [in, optional] Pointer to a RTL_HEAP_PARAMETERS structure that contains parameters to be applied when creating the heap. This
	/// parameter is optional and can be <c>NULL</c>.
	/// </param>
	/// <returns><c>RtlCreateHeap</c> returns a handle to be used in accessing the created heap.</returns>
	/// <remarks>
	/// <para>
	/// <c>RtlCreateHeap</c> creates a private heap object from which the calling process can allocate memory blocks by calling
	/// RtlAllocateHeap. The initial commit size determines the number of pages that are initially allocated for the heap. The initial
	/// reserve size determines the number of pages that are initially reserved for the heap. Pages that are reserved but uncommitted
	/// create a block in the process's virtual address space into which the heap can expand.
	/// </para>
	/// <para>
	/// If allocation requests made by RtlAllocateHeap exceed the heap's initial commit size, the system commits additional pages of
	/// physical storage for the heap, up to the heap's maximum size. If the heap is nongrowable, its maximum size is limited to its
	/// initial reserve size.
	/// </para>
	/// <para>
	/// If the heap is growable, its size is limited only by available memory. If requests by RtlAllocateHeap exceed the current size of
	/// committed pages, the system calls ZwAllocateVirtualMemory to obtain the memory needed, assuming that the physical storage is available.
	/// </para>
	/// <para>
	/// In addition, if the heap is nongrowable, an absolute limitation arises: the maximum size of a memory block in the heap is
	/// 0x7F000 bytes. The virtual memory threshold of the heap is equal to the maximum heap block size or the value of the
	/// <c>VirtualMemoryThreshold</c> member of the Parameters structure, whichever is less. The heap also may need to pad the request
	/// size for metadata and alignment purposes so requests to allocate blocks within 4096 Bytes (1 Page) of the
	/// <c>VirtualMemoryThreshold</c> may fail even if the maximum size of the heap is large enough to contain the block. (For more
	/// information about <c>VirtualMemoryThreshold</c>, see the members of the Parameters parameter to <c>RtlCreateHeap</c>.)
	/// </para>
	/// <para>
	/// If the heap is growable, requests to allocate blocks larger than the heap's virtual memory threshold do not automatically fail;
	/// the system calls ZwAllocateVirtualMemory to obtain the memory needed for such large blocks.
	/// </para>
	/// <para>The memory of a private heap object is accessible only to the process that created it.</para>
	/// <para>
	/// The system uses memory from the private heap to store heap support structures, so not all of the specified heap size is
	/// available to the process. For example, if RtlAllocateHeap requests 64 kilobytes (K) from a heap with a maximum size of 64K, the
	/// request may fail because of system overhead.
	/// </para>
	/// <para>
	/// If HEAP_NO_SERIALIZE is not specified (the simple default), the heap will serialize access within the calling process.
	/// Serialization ensures mutual exclusion when two or more threads attempt to simultaneously allocate or free blocks from the same
	/// heap. There is a small performance cost to serialization, but it must be used whenever multiple threads allocate and free memory
	/// from the same heap.
	/// </para>
	/// <para>
	/// Setting HEAP_NO_SERIALIZE eliminates mutual exclusion on the heap. Without serialization, two or more threads that use the same
	/// heap handle might attempt to allocate or free memory simultaneously, likely causing corruption in the heap. Therefore,
	/// HEAP_NO_SERIALIZE can safely be used only in the following situations:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>The process has only one thread.</term>
	/// </item>
	/// <item>
	/// <term>The process has multiple threads, but only one thread calls the heap functions for a specific heap.</term>
	/// </item>
	/// <item>
	/// <term>The process has multiple threads, and the application provides its own mechanism for mutual exclusion to a specific heap.</term>
	/// </item>
	/// </list>
	/// <para><c>Note</c>
	/// <para></para>
	/// To guard against an access violation, use structured exception handling to protect any code that writes to or reads from a heap.
	/// For more information about structured exception handling with memory accesses, see Handling Exceptions.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows-hardware/drivers/ddi/ntifs/nf-ntifs-rtlcreateheap NTSYSAPI PVOID RtlCreateHeap( ULONG
	// Flags, PVOID HeapBase, SIZE_T ReserveSize, SIZE_T CommitSize, PVOID Lock, PRTL_HEAP_PARAMETERS Parameters );
	[DllImport(Lib.NtDll, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("ntifs.h", MSDNShortId = "NF:ntifs.RtlCreateHeap")]
	public static extern IntPtr RtlCreateHeap([In, Optional] HeapFlags Flags, [In, Optional] IntPtr HeapBase, [In, Optional] SizeT ReserveSize,
		[In, Optional] SizeT CommitSize, [In, Optional] IntPtr Lock, in RTL_HEAP_PARAMETERS Parameters);

	/// <summary>
	/// The <c>RtlDestroyHeap</c> routine destroys the specified heap object. <c>RtlDestroyHeap</c> decommits and releases all the pages
	/// of a private heap object, and it invalidates the handle to the heap.
	/// </summary>
	/// <param name="HeapHandle">[in] Handle for the heap to be destroyed. This parameter is a heap handle returned by <c>RtlCreateHeap</c>.</param>
	/// <returns>
	/// <para>If the call to <c>RtlDestroyHeap</c> succeeds, the return value is a <c>NULL</c> pointer.</para>
	/// <para>If the call to <c>RtlDestroyHeap</c> fails, the return value is a handle for the heap.</para>
	/// </returns>
	/// <remarks>
	/// Processes can call <c>RtlDestroyHeap</c> without first calling <c>RtlFreeHeap</c> to free memory that was allocated from the heap.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows-hardware/drivers/ddi/ntifs/nf-ntifs-rtldestroyheap NTSYSAPI PVOID RtlDestroyHeap( PVOID
	// HeapHandle );
	[DllImport(Lib.NtDll, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("ntifs.h", MSDNShortId = "NF:ntifs.RtlDestroyHeap")]
	public static extern IntPtr RtlDestroyHeap(IntPtr HeapHandle);

	/// <summary>Frees a memory block that was allocated from a heap by <c>RtlAllocateHeap</c>.</summary>
	/// <param name="HeapHandle">A handle for the heap whose memory block is to be freed. This parameter is a handle returned by <c>RtlCreateHeap</c>.</param>
	/// <param name="Flags">
	/// <para>
	/// A set of flags that controls aspects of freeing a memory block. Specifying the following value overrides the corresponding value
	/// that was specified in the Flags parameter when the heap was created by <c>RtlCreateHeap</c>.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Flag</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>HEAP_NO_SERIALIZE</term>
	/// <term>Mutual exclusion will not be used when RtlFreeHeap is accessing the heap.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="HeapBase">A pointer to the memory block to free. This pointer is returned by <c>RtlAllocateHeap</c>.</param>
	/// <returns>
	/// <para>Returns <c>TRUE</c> if the block was freed successfully; <c>FALSE</c> otherwise.</para>
	/// <para>
	/// <para>Note</para>
	/// <para>Starting with Windows 8 the return value is typed as <c>LOGICAL</c>, which has a different size than <c>BOOLEAN</c>.</para>
	/// </para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/devnotes/rtlfreeheap BOOLEAN RtlFreeHeap( _In_ PVOID HeapHandle, _In_opt_ ULONG
	// Flags, _In_ PVOID HeapBase );
	[DllImport(Lib.NtDll, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("ntifs.h")]
	[return: MarshalAs(UnmanagedType.U1)]
	public static extern bool RtlFreeHeap([In] IntPtr HeapHandle, [In, Optional] HeapFlags Flags, [In] IntPtr HeapBase);

	/// <summary>Contains parameters to be applied when creating the heap.</summary>
	[StructLayout(LayoutKind.Sequential)]
	public struct RTL_HEAP_PARAMETERS
	{
		/// <summary>Size, in bytes, of the RTL_HEAP_PARAMETERS structure.</summary>
		public uint Length;

		/// <summary>Segment reserve size, in bytes. If this value is not specified, 1 MB is used.</summary>
		public SizeT SegmentReserve;

		/// <summary>Segment reserve size, in bytes. If this value is not specified, 1 MB is used.</summary>
		public SizeT SegmentCommit;

		/// <summary>Decommit free block threshold, in bytes. If this value is not specified, PAGE_SIZE is used.</summary>
		public SizeT DeCommitFreeBlockThreshold;

		/// <summary>Decommit total free threshold, in bytes. If this value is not specified, 65536 is used.</summary>
		public SizeT DeCommitTotalFreeThreshold;

		/// <summary>
		/// Size, in bytes, of the largest block of memory that can be allocated from the heap. If this value is not specified, the
		/// difference between the highest and lowest addresses, less one page, is used.
		/// </summary>
		public SizeT MaximumAllocationSize;

		/// <summary>
		/// Virtual memory threshold, in bytes. If this value is not specified, or if it is greater than the maximum heap block size,
		/// the maximum heap block size of 0x7F000 is used.
		/// </summary>
		public SizeT VirtualMemoryThreshold;

		/// <summary>
		/// Initial amount of memory, in bytes, to commit for the heap.
		/// <para>Must be less than or equal to InitialReserve.</para>
		/// <para>
		/// If HeapBase and CommitRoutine are non-NULL, this parameter, which overrides the value of CommitSize, must be a nonzero
		/// value; otherwise it is ignored.
		/// </para>
		/// </summary>
		public SizeT InitialCommit;

		/// <summary>
		/// Initial amount of memory, in bytes, to reserve for the heap.
		/// <para>
		/// If HeapBase and CommitRoutine are non-NULL, this parameter, which overrides the value of ReserveSize, must be a nonzero
		/// value; otherwise it is ignored.
		/// </para>
		/// </summary>
		public SizeT InitialReserve;

		/// <summary>
		/// Callback routine to commit pages from the heap. If this parameter is non-NULL, the heap must be nongrowable.
		/// <para>If HeapBase is NULL, CommitRoutine must also be NULL.</para>
		/// </summary>
		[MarshalAs(UnmanagedType.FunctionPtr)]
		public PRTL_HEAP_COMMIT_ROUTINE? CommitRoutine;

		/// <summary>Reserved for system use. Drivers must set this parameter to zero.</summary>
		private SizeT Reserved1;

		/// <summary>Reserved for system use. Drivers must set this parameter to zero.</summary>
		private SizeT Reserved2;
	}

	/*
	IoGetAttachedDeviceReference
	IoGetConfigurationInformation
	IoSetStartIoAttributes
	IoSizeOfIrp macro
	IoStartNextPacket
	IoStartNextPacketByKey
	IoStartPacket
	IoStartTimer
	IoStopTimer
	IoWriteErrorLogEntry
	KeGetProcessorIndexFromNumber
	KeGetProcessorNumberFromIndex
	KeSetKernelStackSwapEnable
	KeStallExecutionProcessor
	MEMORY_BASIC_INFORMATION structure
	NtClose
	NtCreateSectionEx
	NtDeviceIoControlFile
	NtDuplicateToken
	NtFlushBuffersFileEx
	NtFreeVirtualMemory
	NtFsControlFile
	NtLockFile
	NtOpenFile
	NtOpenProcessToken
	NtOpenProcessTokenEx
	NtOpenThreadToken
	NtOpenThreadTokenEx
	NtPrivilegeCheck
	NtQueryDirectoryFile
	NtQueryDirectoryFileEx
	NtQueryInformationFile
	NtQueryInformationToken
	NtQueryObject
	NtQueryQuotaInformationFile
	NtQuerySecurityObject
	NtQueryVirtualMemory
	NtQueryVolumeInformationFile
	NtReadFile
	NtSetInformationFile
	NtSetInformationThread
	NtSetInformationToken
	NtSetQuotaInformationFile
	NtSetSecurityObject
	NtUnlockFile
	NtWriteFile
	PoCallDriver
	PoClearPowerRequest
	PoCreatePowerRequest
	PoDeletePowerRequest
	PoEndDeviceBusy
	PoQueryWatchdogTime
	PoRegisterDeviceForIdleDetection
	PoRegisterPowerSettingCallback
	PoRegisterSystemState
	PoSetDeviceBusyEx
	PoSetPowerRequest
	PoSetPowerState
	PoStartDeviceBusy
	PoStartNextPowerIrp
	PoUnregisterPowerSettingCallback
	PoUnregisterSystemState
	PsGetCurrentThread
	PsIsSystemThread
	RtlInitStringEx
	RtlUnicodeToUTF8N
	RtlUTF8ToUnicodeN
	SeFreePrivileges
	ZwAllocateVirtualMemory
	ZwCreateEvent
	ZwDeleteFile
	ZwDeviceIoControlFile
	ZwDuplicateObject
	ZwDuplicateToken
	ZwFlushBuffersFile
	ZwFlushBuffersFileEx
	ZwFlushVirtualMemory
	ZwFreeVirtualMemory
	ZwFsControlFile
	ZwLockFile
	ZwNotifyChangeKey
	ZwOpenDirectoryObject
	ZwOpenProcessTokenEx
	ZwOpenThreadTokenEx
	ZwQueryDirectoryFile
	ZwQueryDirectoryFileEx
	ZwQueryEaFile
	ZwQueryInformationToken
	ZwQueryObject
	ZwQueryQuotaInformationFile
	ZwQuerySecurityObject
	ZwQueryVirtualMemory
	ZwQueryVolumeInformationFile
	ZwSetEaFile
	ZwSetEvent
	ZwSetInformationToken
	ZwSetInformationVirtualMemory
	ZwSetQuotaInformationFile
	ZwSetSecurityObject
	ZwSetVolumeInformationFile
	ZwUnlockFile
	ZwWaitForSingleObject
	ACCESS_ALLOWED_ACE structure
ACCESS_DENIED_ACE structure
ACE_HEADER structure
ATOMIC_CREATE_ECP_CONTEXT structure
BOOT_AREA_INFO structure
CcCanIWrite function
CcCoherencyFlushAndPurgeCache function
CcCopyRead function
CcCopyReadEx function
CcCopyWrite function
CcCopyWriteEx function
CcCopyWriteWontFlush function
CcDeferWrite function
CcFastCopyRead function
CcFastCopyWrite function
CcFlushCache function
CcGetDirtyPages function
CcGetFileObjectFromBcb function
CcGetFileObjectFromSectionPtrs function
CcGetFileObjectFromSectionPtrsRef function
CcGetFlushedValidData function
CcInitializeCacheMap function
CcIsThereDirtyData function
CcIsThereDirtyDataEx function
CcMapData function
CcMdlReadComplete function
CcMdlWriteAbort function
CcMdlWriteComplete function
CcPinMappedData function
CcPinRead function
CcPrepareMdlWrite function
CcPreparePinWrite function
CcPurgeCacheSection function
CcRemapBcb function
CcRepinBcb function
CcScheduleReadAhead function
CcScheduleReadAheadEx function
CcSetAdditionalCacheAttributes function
CcSetAdditionalCacheAttributesEx function
CcSetBcbOwnerPointer function
CcSetDirtyPageThreshold function
CcSetDirtyPinnedData function
CcSetFileSizes function
CcSetLogHandleForFile function
CcSetReadAheadGranularity function
CcUninitializeCacheMap function
CcUnpinData function
CcUnpinDataForThread function
CcUnpinRepinnedBcb function
CcWaitForCurrentLazyWriterActivity function
CcZeroData function
CREATE_REDIRECTION_ECP_CONTEXT structure
CSV_CONTROL_OP enumeration
CSV_DOWN_LEVEL_FILE_TYPE enumeration
CSV_DOWN_LEVEL_OPEN_ECP_CONTEXT structure
CSV_QUERY_FILE_REVISION_ECP_CONTEXT structure
CSV_QUERY_FILE_REVISION_ECP_CONTEXT_FILE_ID_128 structure
CSV_SET_HANDLE_PROPERTIES_ECP_CONTEXT structure
DRIVER_FS_NOTIFICATION callback function
ECP_OPEN_PARAMETERS structure
ENCRYPTION_KEY_CTRL_INPUT structure
ExAdjustLookasideDepth function
ExDisableResourceBoostLite function
ExQueryPoolBlockSize function
FILE_ALLOCATION_INFORMATION structure
FILE_BOTH_DIR_INFORMATION structure
FILE_CASE_SENSITIVE_INFORMATION structure
FILE_COMPLETION_INFORMATION structure
FILE_COMPRESSION_INFORMATION structure
FILE_DESIRED_STORAGE_CLASS_INFORMATION structure
FILE_DIRECTORY_INFORMATION structure
FILE_FS_ATTRIBUTE_INFORMATION structure
FILE_FS_CONTROL_INFORMATION structure
FILE_FS_DRIVER_PATH_INFORMATION structure
FILE_FS_PERSISTENT_VOLUME_INFORMATION structure
FILE_FULL_DIR_INFORMATION structure
FILE_GET_EA_INFORMATION structure
FILE_GET_QUOTA_INFORMATION structure
FILE_ID_BOTH_DIR_INFORMATION structure
FILE_ID_EXTD_BOTH_DIR_INFORMATION structure
FILE_ID_EXTD_DIR_INFORMATION structure
FILE_ID_FULL_DIR_INFORMATION structure
FILE_ID_GLOBAL_TX_DIR_INFORMATION structure
FILE_ID_INFORMATION structure
FILE_INTERNAL_INFORMATION structure
FILE_KNOWN_FOLDER_INFORMATION structure
FILE_KNOWN_FOLDER_TYPE enumeration
FILE_LEVEL_TRIM structure
FILE_LEVEL_TRIM_OUTPUT structure
FILE_LEVEL_TRIM_RANGE structure
FILE_LINK_ENTRY_INFORMATION structure
FILE_LINK_INFORMATION structure
FILE_LINKS_INFORMATION structure
FILE_MAILSLOT_QUERY_INFORMATION structure
FILE_MAILSLOT_SET_INFORMATION structure
FILE_NAMES_INFORMATION structure
FILE_NETWORK_PHYSICAL_NAME_INFORMATION structure
FILE_NOTIFY_INFORMATION structure
FILE_OBJECTID_INFORMATION structure
FILE_PIPE_INFORMATION structure
FILE_PIPE_LOCAL_INFORMATION structure
FILE_PIPE_REMOTE_INFORMATION structure
FILE_PROVIDER_EXTERNAL_INFO_V0 structure
FILE_PROVIDER_EXTERNAL_INFO_V1 structure
FILE_QUOTA_INFORMATION structure
FILE_REMOTE_PROTOCOL_INFORMATION structure
FILE_RENAME_INFORMATION structure
FILE_REPARSE_POINT_INFORMATION structure
FILE_STANDARD_LINK_INFORMATION structure
FILE_STAT_INFORMATION structure
FILE_STAT_LX_INFORMATION structure
FILE_STORAGE_RESERVE_ID_INFORMATION structure
FILE_STORAGE_TIER_CLASS enumeration
FILE_STREAM_INFORMATION structure
FILE_TIMESTAMPS structure
FILE_ZERO_DATA_INFORMATION structure
FILE_ZERO_DATA_INFORMATION_EX structure
FS_BPIO_INFLAGS enumeration
FS_BPIO_INFO structure
FS_BPIO_INPUT structure
FS_BPIO_OPERATIONS enumeration
FS_BPIO_OUTFLAGS enumeration
FS_BPIO_OUTPUT structure
FS_BPIO_RESULTS structure
FS_FILTER_CALLBACK_DATA structure
FS_FILTER_CALLBACKS structure
FS_FILTER_SECTION_SYNC_OUTPUT structure
FSCTL_MANAGE_BYPASS_IO IOCTL
FSCTL_MARK_HANDLE IOCTL
FSCTL_OFFLOAD_READ_INPUT structure
FSCTL_OFFLOAD_READ_OUTPUT structure
FSCTL_OFFLOAD_WRITE_INPUT structure
FSCTL_OFFLOAD_WRITE_OUTPUT structure
FSCTL_QUERY_VOLUME_NUMA_INFO_OUTPUT structure
FSRTL_ADVANCED_FCB_HEADER structure
FSRTL_CHANGE_BACKING_TYPE enumeration
FSRTL_COMMON_FCB_HEADER structure
FSRTL_PER_FILE_CONTEXT structure
FSRTL_PER_FILEOBJECT_CONTEXT structure
FSRTL_PER_STREAM_CONTEXT structure
FsRtlAcknowledgeEcp function
FsRtlAcquireFileExclusive function
FsRtlAddBaseMcbEntryEx function
FsRtlAddLargeMcbEntry function
FsRtlAddMcbEntry function
FsRtlAddToTunnelCache function
FsRtlAllocateAePushLock function
FsRtlAllocateExtraCreateParameter function
FsRtlAllocateExtraCreateParameterFromLookasideList function
FsRtlAllocateExtraCreateParameterList function
FsRtlAllocateFileLock function
FsRtlAllocatePoolWithQuotaTag macro
FsRtlAllocatePoolWithTag macro
FsRtlAllocateResource function
FsRtlAreNamesEqual function
FsRtlAreThereCurrentFileLocks macro
FsRtlAreThereCurrentOrInProgressFileLocks function
FsRtlAreThereWaitingFileLocks function
FsRtlAreVolumeStartupApplicationsComplete function
FsRtlBalanceReads function
FsRtlCancellableWaitForMultipleObjects function
FsRtlCancellableWaitForSingleObject function
FsRtlChangeBackingFileObject function
FsRtlCheckLockForOplockRequest function
FsRtlCheckLockForReadAccess function
FsRtlCheckLockForWriteAccess function
FsRtlCheckOplock function
FsRtlCheckOplockEx function
FsRtlCheckOplockEx2 function
FsRtlCheckUpperOplock function
FsRtlCompleteRequest macro
FsRtlCopyRead function
FsRtlCopyWrite function
FsRtlCreateSectionForDataScan function
FsRtlCurrentBatchOplock function
FsRtlCurrentOplock function
FsRtlCurrentOplockH function
FsRtlDeleteExtraCreateParameterLookasideList function
FsRtlDeleteKeyFromTunnelCache function
FsRtlDeleteTunnelCache function
FsRtlDeregisterUncProvider function
FsRtlDissectDbcs function
FsRtlDissectName function
FsRtlDoesDbcsContainWildCards function
FsRtlDoesNameContainWildCards function
FsRtlFastCheckLockForRead function
FsRtlFastCheckLockForWrite function
FsRtlFastLock macro
FsRtlFastUnlockAll function
FsRtlFastUnlockAllByKey function
FsRtlFastUnlockSingle function
FsRtlFindExtraCreateParameter function
FsRtlFindInTunnelCache function
FsRtlFreeAePushLock function
FsRtlFreeExtraCreateParameter function
FsRtlFreeExtraCreateParameterList function
FsRtlFreeFileLock function
FsRtlGetBypassIoOpenCount macro
FsRtlGetBypassIoOpenCountPtr macro
FsRtlGetEcpListFromIrp function
FsRtlGetFileSize function
FsRtlGetNextExtraCreateParameter function
FsRtlGetNextFileLock function
FsRtlGetNextLargeMcbEntry function
FsRtlGetNextMcbEntry function
FsRtlGetPerStreamContextPointer macro
FsRtlGetSectorSizeInformation function
FsRtlGetSupportedFeatures function
FsRtlIncrementCcFastMdlReadWait function
FsRtlIncrementCcFastReadNotPossible function
FsRtlIncrementCcFastReadNoWait function
FsRtlIncrementCcFastReadResourceMiss function
FsRtlIncrementCcFastReadWait function
FsRtlInitExtraCreateParameterLookasideList function
FsRtlInitializeBaseMcb function
FsRtlInitializeBaseMcbEx function
FsRtlInitializeExtraCreateParameter function
FsRtlInitializeExtraCreateParameterList function
FsRtlInitializeFileLock function
FsRtlInitializeLargeMcb function
FsRtlInitializeMcb function
FsRtlInitializeOplock function
FsRtlInitializeTunnelCache function
FsRtlInitPerStreamContext macro
FsRtlInsertExtraCreateParameter function
FsRtlInsertPerFileContext function
FsRtlInsertPerFileObjectContext function
FsRtlInsertPerStreamContext function
FsRtlIsAnsiCharacterLegal macro
FsRtlIsAnsiCharacterLegalFat macro
FsRtlIsAnsiCharacterLegalHpfs macro
FsRtlIsAnsiCharacterLegalNtfs macro
FsRtlIsAnsiCharacterLegalNtfsStream macro
FsRtlIsAnsiCharacterWild macro
FsRtlIsDaxVolume function
FsRtlIsDbcsInExpression function
FsRtlIsEcpAcknowledged function
FsRtlIsEcpFromUserMode function
FsRtlIsFatDbcsLegal function
FsRtlIsHpfsDbcsLegal function
FsRtlIsLeadDbcsCharacter macro
FsRtlIsNameInExpression function
FsRtlIsNameInUnUpcasedExpression function
FsRtlIsNtstatusExpected function
FsRtlIsPagingFile function
FsRtlIssueDeviceIoControl function
FsRtlIsSystemPagingFile function
FsRtlIsTotalDeviceFailure function
FsRtlIsUnicodeCharacterWild macro
FsRtlLogCcFlushError function
FsRtlLookupBaseMcbEntry function
FsRtlLookupLargeMcbEntry function
FsRtlLookupLastLargeMcbEntry function
FsRtlLookupLastLargeMcbEntryAndIndex function
FsRtlLookupLastMcbEntry function
FsRtlLookupMcbEntry function
FsRtlLookupPerFileContext function
FsRtlLookupPerFileObjectContext function
FsRtlLookupPerStreamContext macro
FsRtlLookupPerStreamContextInternal function
FsRtlMdlReadCompleteDev function
FsRtlMdlReadDev function
FsRtlMdlReadEx function
FsRtlMdlWriteCompleteDev function
FsRtlMupGetProviderIdFromName function
FsRtlMupGetProviderInfoFromFileObject function
FsRtlNormalizeNtstatus function
FsRtlNotifyCleanup function
FsRtlNotifyCleanupAll function
FsRtlNotifyFilterChangeDirectory function
FsRtlNotifyFilterReportChange function
FsRtlNotifyFullChangeDirectory function
FsRtlNotifyFullReportChange function
FsRtlNotifyInitializeSync function
FsRtlNotifyUninitializeSync function
FsRtlNotifyVolumeEvent function
FsRtlNotifyVolumeEventEx function
FsRtlNumberOfRunsInLargeMcb function
FsRtlNumberOfRunsInMcb function
FsRtlOplockBreakH function
FsRtlOplockBreakToNone function
FsRtlOplockBreakToNoneEx function
FsRtlOplockFsctrl function
FsRtlOplockFsctrlEx function
FsRtlOplockIsFastIoPossible function
FsRtlOplockIsSharedRequest function
FsRtlOplockKeysEqual function
FsRtlPostPagingFileStackOverflow function
FsRtlPostStackOverflow function
FsRtlPrepareMdlWriteDev function
FsRtlPrepareMdlWriteEx function
FsRtlPrepareToReuseEcp function
FsRtlPrivateLock function
FsRtlProcessFileLock function
FsRtlQueryCachedVdl function
FsRtlQueryKernelEaFile function
FsRtlRegisterFileSystemFilterCallbacks function
FsRtlRegisterUncProvider function
FsRtlRegisterUncProviderEx function
FsRtlReleaseFile function
FsRtlRemoveBaseMcbEntry function
FsRtlRemoveDotsFromPath function
FsRtlRemoveExtraCreateParameter function
FsRtlRemoveLargeMcbEntry function
FsRtlRemoveMcbEntry function
FsRtlRemovePerFileContext function
FsRtlRemovePerFileObjectContext function
FsRtlRemovePerStreamContext function
FsRtlResetLargeMcb function
FsRtlSetEcpListIntoIrp function
FsRtlSetKernelEaFile function
FsRtlSetupAdvancedHeader function
FsRtlSetupAdvancedHeaderEx macro
FsRtlSetupAdvancedHeaderEx2 macro
FsRtlSplitLargeMcb function
FsRtlSupportsPerFileContexts macro
FsRtlTeardownPerFileContexts function
FsRtlTeardownPerStreamContexts function
FsRtlTestAnsiCharacter macro
FsRtlTruncateLargeMcb function
FsRtlTruncateMcb function
FsRtlUninitializeBaseMcb function
FsRtlUninitializeFileLock function
FsRtlUninitializeLargeMcb function
FsRtlUninitializeMcb function
FsRtlUninitializeOplock function
FsRtlUpperOplockFsctrl function
FsRtlValidateReparsePointBuffer function
GetSecurityUserInfo function
IO_DEVICE_HINT_ECP_CONTEXT structure
IO_PRIORITY_INFO structure
IO_STOP_ON_SYMLINK_FILTER_ECP_v0 structure
IoAcquireVpbSpinLock function
IoCheckDesiredAccess function
IoCheckEaBufferValidity function
IoCheckFunctionAccess function
IoCheckQuerySetFileInformation function
IoCheckQuerySetVolumeInformation function
IoCheckQuotaBufferValidity function
IoCreateStreamFileObject function
IoCreateStreamFileObjectEx function
IoCreateStreamFileObjectEx2 function
IoCreateStreamFileObjectLite function
IOCTL_REDIR_QUERY_PATH IOCTL
IOCTL_REDIR_QUERY_PATH_EX IOCTL
IOCTL_VOLSNAP_FLUSH_AND_HOLD_WRITES IOCTL
IoEnumerateDeviceObjectList function
IoEnumerateRegisteredFiltersList function
IoFastQueryNetworkAttributes function
IoGetAttachedDevice function
IoGetBaseFileSystemDeviceObject function
IoGetDeviceAttachmentBaseRef function
IoGetDeviceToVerify function
IoGetDiskDeviceObject function
IoGetLowerDeviceObject function
IoGetRequestorProcess function
IoGetRequestorProcessId function
IoGetRequestorSessionId function
IoGetTopLevelIrp function
IoInitializePriorityInfo function
IoIsFileOpenedExclusively macro
IoIsOperationSynchronous function
IoIsSystemThread function
IoIsValidNameGraftingBuffer function
IoPageRead function
IoQueryFileDosDeviceName function
IoQueryFileInformation function
IoQueryVolumeInformation function
IoQueueThreadIrp function
IoRegisterFileSystem function
IoRegisterFsRegistrationChange function
IoRegisterFsRegistrationChangeEx function
IoRegisterFsRegistrationChangeMountAware function
IoReleaseVpbSpinLock function
IoReplaceFileObjectName function
IoSetDeviceToVerify function
IoSetInformation function
IoSetTopLevelIrp function
IoSynchronousPageWrite function
IoThreadToProcess function
IoUnregisterFileSystem function
IoUnregisterFsRegistrationChange function
IoVerifyVolume function
IsReparseTagMicrosoft macro
IsReparseTagNameSurrogate macro
IsReparseTagValid macro
KeAttachProcess function
KeDetachProcess function
KeInitializeMutant function
KeInitializeQueue function
KeInsertHeadQueue function
KeInsertQueue function
KeQueryPerformanceCounter function
KeReadStateMutant function
KeReadStateQueue function
KeReleaseMutant function
KeReleaseQueuedSpinLock function
KeRemoveQueue function
KeRundownQueue function
KeSetIdealProcessorThread function
KeStackAttachProcess function
KeTryToAcquireQueuedSpinLock function
KeUnstackDetachProcess function
MapSecurityError function
MARK_HANDLE_INFO structure
MARK_HANDLE_INFO32 structure
MEMORY_INFORMATION_CLASS enumeration
MmCanFileBeTruncated function
MmDoesFileHaveUserWritableReferences function
MmFlushImageSection function
MmForceSectionClosed function
MmForceSectionClosedEx function
MmGetMaximumFileSectionSize function
MmIsRecursiveIoFault function
MmPrefetchPages function
MmSetAddressRangeModified function
NETWORK_APP_INSTANCE_EA structure
NETWORK_APP_INSTANCE_ECP_CONTEXT structure
NETWORK_OPEN_ECP_CONTEXT structure
NETWORK_OPEN_ECP_CONTEXT_V0 structure
NETWORK_OPEN_INTEGRITY_QUALIFIER enumeration
NETWORK_OPEN_LOCATION_QUALIFIER enumeration
NFS_OPEN_ECP_CONTEXT structure
NtQueryInformationByName function
ObInsertObject function
ObIsKernelHandle function
OBJECT_INFORMATION_CLASS enumeration
ObMakeTemporaryObject function
ObOpenObjectByPointer function
ObQueryNameString function
ObQueryObjectAuditingByHandle function
OPEN_REPARSE_LIST structure
OPEN_REPARSE_LIST_ENTRY structure
OPLOCK_NOTIFY_PARAMS structure
OPLOCK_NOTIFY_REASON enumeration
PFSRTL_EXTRA_CREATE_PARAMETER_CLEANUP_CALLBACK callback function
PREFETCH_OPEN_ECP_CONTEXT structure
PsChargePoolQuota function
PsDereferenceImpersonationToken function
PsDereferencePrimaryToken function
PsGetProcessExitTime function
PsImpersonateClient function
PsIsDiskCountersEnabled function
PsIsThreadTerminating function
PsLookupProcessByProcessId function
PsLookupThreadByThreadId function
PsReferenceImpersonationToken function
PsReferencePrimaryToken function
PsReturnPoolQuota function
PsRevertToSelf function
PsUpdateDiskCounters function
PUBLIC_OBJECT_BASIC_INFORMATION structure
PUBLIC_OBJECT_TYPE_INFORMATION structure
QUERY_FILE_LAYOUT_INPUT structure
QUERY_FILE_LAYOUT_OUTPUT structure
QUERY_ON_CREATE_EA_INFORMATION structure
QUERY_ON_CREATE_ECP_CONTEXT structure
QUERY_ON_CREATE_FILE_LX_INFORMATION structure
QUERY_ON_CREATE_FILE_STAT_INFORMATION structure
QUERY_PATH_REQUEST structure
QUERY_PATH_REQUEST_EX structure
QUERY_PATH_RESPONSE structure
REFS_SMR_VOLUME_GC_ACTION enumeration
REFS_SMR_VOLUME_GC_METHOD enumeration
REFS_SMR_VOLUME_GC_PARAMETERS structure
REFS_SMR_VOLUME_GC_STATE enumeration
REFS_SMR_VOLUME_INFO_OUTPUT structure
REPARSE_DATA_BUFFER structure
REPARSE_DATA_BUFFER_EX structure
REPARSE_GUID_DATA_BUFFER structure
RKF_BYPASS_ECP_CONTEXT structure
RTL_MEMORY_TYPE enumeration
RTL_SEGMENT_HEAP_MEMORY_SOURCE structure
RTL_SEGMENT_HEAP_PARAMETERS structure
RtlAbsoluteToSelfRelativeSD function
RtlAddAccessAllowedAce function
RtlAddAccessAllowedAceEx function
RtlAddAce function
RtlAllocateAndInitializeSid function
RtlAllocateHeap function
RtlAppendStringToString function
RtlCaptureContext function
RtlCaptureStackBackTrace function
RtlCompareMemoryUlong function
RtlCompressBuffer function
RtlCompressChunks function
RtlConvertSidToUnicodeString function
RtlCopyLuid function
RtlCopySid function
RtlCreateAcl function
RtlCreateHeap function
RtlCreateSecurityDescriptorRelative function
RtlCreateSystemVolumeInformationFolder function
RtlCreateUnicodeString function
RtlCustomCPToUnicodeN function
RtlDecompressBuffer function
RtlDecompressBufferEx function
RtlDecompressBufferEx2 function
RtlDecompressChunks function
RtlDecompressFragment function
RtlDecompressFragmentEx function
RtlDeleteAce function
RtlDescribeChunk function
RtlDestroyHeap function
RtlDowncaseUnicodeString function
RtlEqualPrefixSid function
RtlEqualSid function
RtlFillMemoryUlong function
RtlFillMemoryUlonglong macro
RtlFindUnicodePrefix function
RtlFreeHeap function
RtlFreeOemString function
RtlFreeSid function
RtlGenerate8dot3Name function
RtlGetAce function
RtlGetCompressionWorkSpaceSize function
RtlGetDaclSecurityDescriptor function
RtlGetGroupSecurityDescriptor function
RtlGetOwnerSecurityDescriptor function
RtlGetSaclSecurityDescriptor function
RtlIdentifierAuthoritySid function
RtlInitCodePageTable function
RtlInitializeSid function
RtlInitializeSidEx function
RtlInitializeUnicodePrefix function
RtlInitUTF8StringEx function
RtlInsertUnicodePrefix function
RtlIsCloudFilesPlaceholder function
RtlIsNameLegalDOS8Dot3 function
RtlIsPartialPlaceholder function
RtlIsPartialPlaceholderFileHandle function
RtlIsPartialPlaceholderFileInfo function
RtlIsValidOemCharacter function
RtlLengthRequiredSid function
RtlLengthSid function
RtlMultiByteToUnicodeN function
RtlMultiByteToUnicodeSize function
RtlNextUnicodePrefix function
RtlNtStatusToDosError function
RtlNtStatusToDosErrorNoTeb function
RtlOemStringToCountedUnicodeSize macro
RtlOemStringToCountedUnicodeString function
RtlOemStringToUnicodeSize macro
RtlOemStringToUnicodeString function
RtlOemToUnicodeN function
RtlQueryPackageIdentity function
RtlQueryPackageIdentityEx function
RtlQueryProcessPlaceholderCompatibilityMode function
RtlQueryThreadPlaceholderCompatibilityMode function
RtlRandom function
RtlRandomEx function
RtlRemoveUnicodePrefix function
RtlReserveChunk function
RtlSecondsSince1970ToTime function
RtlSecondsSince1980ToTime function
RtlSelfRelativeToAbsoluteSD function
RtlSetGroupSecurityDescriptor function
RtlSetOwnerSecurityDescriptor function
RtlSetProcessPlaceholderCompatibilityMode function
RtlSetThreadPlaceholderCompatibilityMode function
RtlSubAuthorityCountSid function
RtlSubAuthoritySid function
RtlTimeToSecondsSince1970 function
RtlTimeToSecondsSince1980 function
RtlUnicodeStringToCountedOemString function
RtlUnicodeStringToOemSize macro
RtlUnicodeStringToOemString function
RtlUnicodeStringToUTF8String function
RtlUnicodeToCustomCPN function
RtlUnicodeToMultiByteN function
RtlUnicodeToMultiByteSize function
RtlUnicodeToOemN function
RtlUpcaseUnicodeStringToCountedOemString function
RtlUpcaseUnicodeStringToOemString function
RtlUpcaseUnicodeToCustomCPN function
RtlUpcaseUnicodeToMultiByteN function
RtlUpcaseUnicodeToOemN function
RtlUTF8StringToUnicodeString function
RtlValidSid function
RtlxOemStringToUnicodeSize function
RtlxUnicodeStringToOemSize function
SE_EXPORTS structure
SE_SID union
SE_TOKEN_USER structure
SeAppendPrivileges function
SeAuditHardLinkCreation function
SeAuditingFileEvents function
SeAuditingFileOrGlobalEvents function
SeAuditingHardLinkEvents function
SeCaptureSubjectContext function
SecLookupAccountName function
SecLookupAccountSid function
SecLookupWellKnownSid function
SecMakeSPN function
SecMakeSPNEx function
SecMakeSPNEx2 function
SeCreateClientSecurity function
SeCreateClientSecurityFromSubjectContext function
SECURITY_DESCRIPTOR structure
SeDeleteClientSecurity function
SeDeleteObjectAuditAlarm function
SeFilterToken function
SeImpersonateClient function
SeImpersonateClientEx function
SeLengthSid macro
SeLockSubjectContext function
SeMarkLogonSessionForTerminationNotification function
SeOpenObjectAuditAlarm function
SeOpenObjectForDeleteAuditAlarm function
SePrivilegeCheck function
SeQueryAuthenticationIdToken function
SeQueryInformationToken function
SeQuerySecurityDescriptorInfo function
SeQuerySessionIdToken function
SeQuerySubjectContextToken macro
SeRegisterLogonSessionTerminatedRoutine function
SeReleaseSubjectContext function
SeSetAccessStateGenericMapping function
SeSetSecurityDescriptorInfo function
SeSetSecurityDescriptorInfoEx function
SeSetSessionIdToken function
SET_DAX_ALLOC_ALIGNMENT_HINT_INPUT structure
SeTokenGetNoChildProcessRestricted function
SeTokenIsAdmin function
SeTokenIsNoChildProcessRestrictionEnforced function
SeTokenIsRestricted function
SeTokenSetNoChildProcessRestricted function
SeTokenType function
SeUnlockSubjectContext function
SeUnregisterLogonSessionTerminatedRoutine function
SID structure
SID_AND_ATTRIBUTES structure
SID_IDENTIFIER_AUTHORITY structure
SID_NAME_USE enumeration
SRV_INSTANCE_TYPE enumeration
SRV_OPEN_ECP_CONTEXT structure
STORAGE_RESERVE_ID enumeration
SYSTEM_ALARM_ACE structure
SYSTEM_AUDIT_ACE structure
SYSTEM_PROCESS_TRUST_LABEL_ACE structure
SYSTEM_RESOURCE_ATTRIBUTE_ACE structure
SYSTEM_SCOPED_POLICY_ID_ACE structure
TOKEN_CONTROL structure
TOKEN_DEFAULT_DACL structure
TOKEN_GROUPS structure
TOKEN_GROUPS_AND_PRIVILEGES structure
TOKEN_INFORMATION_CLASS enumeration
TOKEN_ORIGIN structure
TOKEN_OWNER structure
TOKEN_PRIMARY_GROUP structure
TOKEN_PRIVILEGES structure
TOKEN_SOURCE structure
TOKEN_STATISTICS structure
TOKEN_TYPE enumeration
TOKEN_USER structure
TUNNEL structure
VIRTUAL_STORAGE_BEHAVIOR_CODE enumeration
VIRTUAL_STORAGE_SET_BEHAVIOR_INPUT structure
VIRTUALIZATION_INSTANCE_INFO_INPUT_EX structure
WIM_PROVIDER_ADD_OVERLAY_INPUT structure
WIM_PROVIDER_EXTERNAL_INFO structure
WIM_PROVIDER_OVERLAY_ENTRY structure
WIM_PROVIDER_REMOVE_OVERLAY_INPUT structure
WIM_PROVIDER_SUSPEND_OVERLAY_INPUT structure
WIM_PROVIDER_UPDATE_OVERLAY_INPUT structure
WOF_EXTERNAL_FILE_ID structure
WOF_EXTERNAL_INFO structure
WOF_VERSION_INFO structure
	*/
}