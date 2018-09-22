// ReSharper disable UnusedMember.Global ReSharper disable InconsistentNaming

using Microsoft.Win32.SafeHandles;
using System;
using System.Runtime.InteropServices;

namespace Vanara.PInvoke
{
	public static partial class Kernel32
	{
		/// <summary>
		/// An application-defined function registered with the RegisterBadMemoryNotification function that is called when one or more bad memory pages are detected.
		/// </summary>
		[UnmanagedFunctionPointer(CallingConvention.StdCall)]
		public delegate void PBAD_MEMORY_CALLBACK_ROUTINE();

		/// <summary>Flags that indicate which of the file cache limits are enabled.</summary>
		[PInvokeData("MemoryApi.h")]
		[Flags]
		public enum FILE_CACHE_LIMITS : uint
		{
			/// <summary>
			/// Enable the maximum size limit.
			/// <para>The FILE_CACHE_MAX_HARD_DISABLE and FILE_CACHE_MAX_HARD_ENABLE flags are mutually exclusive.</para>
			/// </summary>
			FILE_CACHE_MAX_HARD_ENABLE = 0x00000001,
			/// <summary>
			/// Disable the maximum size limit.
			/// <para>The FILE_CACHE_MAX_HARD_DISABLE and FILE_CACHE_MAX_HARD_ENABLE flags are mutually exclusive.</para>
			/// </summary>
			FILE_CACHE_MAX_HARD_DISABLE = 0x00000002,
			/// <summary>
			/// Enable the minimum size limit.
			/// <para>The FILE_CACHE_MIN_HARD_DISABLE and FILE_CACHE_MIN_HARD_ENABLE flags are mutually exclusive.</para>
			/// </summary>
			FILE_CACHE_MIN_HARD_ENABLE = 0x00000004,
			/// <summary>
			/// Disable the minimum size limit.
			/// <para>The FILE_CACHE_MIN_HARD_DISABLE and FILE_CACHE_MIN_HARD_ENABLE flags are mutually exclusive.</para>
			/// </summary>
			FILE_CACHE_MIN_HARD_DISABLE = 0x00000008,
		}

		/// <summary>The type of access to a file mapping object, which determines the page protection of the pages.</summary>
		[PInvokeData("MemoryApi.h")]
		[Flags]
		public enum FILE_MAP : uint
		{
			/// <summary>
			/// A read/write view of the file is mapped. The file mapping object must have been created with PAGE_READWRITE or PAGE_EXECUTE_READWRITE protection.
			/// <para>When used with MapViewOfFileEx, (FILE_MAP_WRITE | FILE_MAP_READ) and FILE_MAP_ALL_ACCESS are equivalent to FILE_MAP_WRITE.</para>
			/// </summary>
			FILE_MAP_WRITE = SECTION_MAP.SECTION_MAP_WRITE,
			/// <summary>
			/// A read-only view of the file is mapped. An attempt to write to the file view results in an access violation.
			/// <para>The file mapping object must have been created with PAGE_READONLY, PAGE_READWRITE, PAGE_EXECUTE_READ, or PAGE_EXECUTE_READWRITE protection.</para>
			/// </summary>
			FILE_MAP_READ = SECTION_MAP.SECTION_MAP_READ,
			/// <summary>
			/// A read/write view of the file is mapped. The file mapping object must have been created with PAGE_READWRITE or PAGE_EXECUTE_READWRITE protection.
			/// <para>When used with the MapViewOfFileEx function, FILE_MAP_ALL_ACCESS is equivalent to FILE_MAP_WRITE.</para>
			/// </summary>
			FILE_MAP_ALL_ACCESS = SECTION_MAP.SECTION_ALL_ACCESS,
			/// <summary>
			/// An executable view of the file is mapped (mapped memory can be run as code). The file mapping object must have been created with
			/// PAGE_EXECUTE_READ, PAGE_EXECUTE_WRITECOPY, or PAGE_EXECUTE_READWRITE protection.
			/// <para>Windows Server 2003 and Windows XP: This value is available starting with Windows XP with SP2 and Windows Server 2003 with SP1.</para>
			/// </summary>
			FILE_MAP_EXECUTE = SECTION_MAP.SECTION_MAP_EXECUTE_EXPLICIT,
			/// <summary>
			/// A copy-on-write view of the file is mapped. The file mapping object must have been created with PAGE_READONLY, PAGE_READ_EXECUTE, PAGE_WRITECOPY,
			/// PAGE_EXECUTE_WRITECOPY, PAGE_READWRITE, or PAGE_EXECUTE_READWRITE protection.
			/// <para>
			/// When a process writes to a copy-on-write page, the system copies the original page to a new page that is private to the process.The new page is
			/// backed by the paging file.The protection of the new page changes from copy-on-write to read/write.
			/// </para>
			/// <para>
			/// When copy-on-write access is specified, the system and process commit charge taken is for the entire view because the calling process can
			/// potentially write to every page in the view, making all pages private. The contents of the new page are never written back to the original file
			/// and are lost when the view is unmapped.
			/// </para>
			/// </summary>
			FILE_MAP_COPY = 0x00000001,
			/// <summary></summary>
			FILE_MAP_RESERVE = 0x80000000,
			/// <summary>
			/// Sets all the locations in the mapped file as invalid targets for CFG. This flag is similar to PAGE_TARGETS_INVALID. It is used along with the
			/// execute access right FILE_MAP_EXECUTE. Any indirect call to locations in those pages will fail CFG checks and the process will be terminated. The
			/// default behavior for executable pages allocated is to be marked valid call targets for CFG.
			/// </summary>
			FILE_MAP_TARGETS_INVALID = 0x40000000,
			/// <summary></summary>
			FILE_MAP_LARGE_PAGES = 0x20000000,
		}

		/// <summary>The type of memory allocation.</summary>
		[PInvokeData("WinNT.h")]
		[Flags]
		public enum MEM_ALLOCATION_TYPE : uint
		{
			/// <summary>
			/// Allocates memory charges (from the overall size of memory and the paging files on disk) for the specified reserved memory pages. The function
			/// also guarantees that when the caller later initially accesses the memory, the contents will be zero. Actual physical pages are not allocated
			/// unless/until the virtual addresses are actually accessed.To reserve and commit pages in one step, call VirtualAlloc with .Attempting to commit a
			/// specific address range by specifying MEM_COMMIT without MEM_RESERVE and a non-NULL lpAddress fails unless the entire range has already been
			/// reserved. The resulting error code is ERROR_INVALID_ADDRESS.An attempt to commit a page that is already committed does not cause the function to
			/// fail. This means that you can commit pages without first determining the current commitment state of each page.If lpAddress specifies an address
			/// within an enclave, flAllocationType must be MEM_COMMIT.
			/// </summary>
			MEM_COMMIT = 0x00001000,
			/// <summary>
			/// Reserves a range of the process&amp;#39;s virtual address space without allocating any actual physical storage in memory or in the paging file on
			/// disk.You can commit reserved pages in subsequent calls to the VirtualAlloc function. To reserve and commit pages in one step, call VirtualAlloc
			/// with MEM_COMMIT | MEM_RESERVE.Other memory allocation functions, such as malloc and LocalAlloc, cannot use a reserved range of memory until it is released.
			/// </summary>
			MEM_RESERVE = 0x00002000,
			/// <summary>
			/// Decommits the specified region of committed pages. After the operation, the pages are in the reserved state. The function does not fail if you
			/// attempt to decommit an uncommitted page. This means that you can decommit a range of pages without first determining the current commitment
			/// state.Do not use this value with MEM_RELEASE.The MEM_DECOMMIT value is not supported when the lpAddress parameter provides the base address for
			/// an enclave.
			/// </summary>
			MEM_DECOMMIT = 0x00004000,
			/// <summary>
			/// Releases the specified region of pages. After this operation, the pages are in the free state. If you specify this value, dwSize must be 0
			/// (zero), and lpAddress must point to the base address returned by the VirtualAlloc function when the region is reserved. The function fails if
			/// either of these conditions is not met. If any pages in the region are committed currently, the function first decommits, and then releases
			/// them.The function does not fail if you attempt to release pages that are in different states, some reserved and some committed. This means that
			/// you can release a range of pages without first determining the current commitment state.Do not use this value with MEM_DECOMMIT.
			/// </summary>
			MEM_RELEASE = 0x00008000,
			/// <summary>
			/// Indicates free pages not accessible to the calling process and available to be allocated. For free pages, the information in the AllocationBase,
			/// AllocationProtect, Protect, and Type members is undefined.
			/// </summary>
			MEM_FREE = 0x00010000,
			/// <summary>Indicates that the memory pages within the region are private (that is, not shared by other processes).</summary>
			MEM_PRIVATE = 0x00020000,
			/// <summary>Indicates that the memory pages within the region are mapped into the view of a section.</summary>
			MEM_MAPPED = 0x00040000,
			/// <summary>
			/// Indicates that data in the memory range specified by lpAddress and dwSize is no longer of interest. The pages should not be read from or written
			/// to the paging file. However, the memory block will be used again later, so it should not be decommitted. This value cannot be used with any other
			/// value.Using this value does not guarantee that the range operated on with MEM_RESET will contain zeros. If you want the range to contain zeros,
			/// decommit the memory and then recommit it.When you specify MEM_RESET, the VirtualAlloc function ignores the value of flProtect. However, you must
			/// still set flProtect to a valid protection value, such as PAGE_NOACCESS.VirtualAlloc returns an error if you use MEM_RESET and the range of memory
			/// is mapped to a file. A shared view is only acceptable if it is mapped to a paging file.
			/// </summary>
			MEM_RESET = 0x00080000,
			/// <summary>Allocates memory at the highest possible address. This can be slower than regular allocations, especially when there are many allocations.</summary>
			MEM_TOP_DOWN = 0x00100000,
			/// <summary>
			/// Causes the system to track pages that are written to in the allocated region. If you specify this value, you must also specify MEM_RESERVE.To
			/// retrieve the addresses of the pages that have been written to since the region was allocated or the write-tracking state was reset, call the
			/// GetWriteWatch function. To reset the write-tracking state, call GetWriteWatch or ResetWriteWatch. The write-tracking feature remains enabled for
			/// the memory region until the region is freed.
			/// </summary>
			MEM_WRITE_WATCH = 0x00200000,
			/// <summary>
			/// Reserves an address range that can be used to map Address Windowing Extensions (AWE) pages.This value must be used with MEM_RESERVE and no other values.
			/// </summary>
			MEM_PHYSICAL = 0x00400000,
			/// <summary></summary>
			MEM_ROTATE = 0x00800000,
			/// <summary></summary>
			MEM_DIFFERENT_IMAGE_BASE_OK = 0x00800000,
			/// <summary>
			/// MEM_RESET_UNDO should only be called on an address range to which MEM_RESET was successfully applied earlier. It indicates that the data in the
			/// specified memory range specified by lpAddress and dwSize is of interest to the caller and attempts to reverse the effects of MEM_RESET. If the
			/// function succeeds, that means all data in the specified address range is intact. If the function fails, at least some of the data in the address
			/// range has been replaced with zeroes.This value cannot be used with any other value. If MEM_RESET_UNDO is called on an address range which was not
			/// MEM_RESET earlier, the behavior is undefined. When you specify MEM_RESET, the VirtualAlloc function ignores the value of flProtect. However, you
			/// must still set flProtect to a valid protection value, such as PAGE_NOACCESS.Windows Server 2008 R2, Windows 7, Windows Server 2008, Windows
			/// Vista, Windows Server 2003 and Windows XP: The MEM_RESET_UNDO flag is not supported until Windows 8 and Windows Server 2012.
			/// </summary>
			MEM_RESET_UNDO = 0x01000000,
			/// <summary>
			/// Allocates memory using large page support.The size and alignment must be a multiple of the large-page minimum. To obtain this value, use the
			/// GetLargePageMinimum function.If you specify this value, you must also specify MEM_RESERVE and MEM_COMMIT.
			/// </summary>
			MEM_LARGE_PAGES = 0x20000000,
			/// <summary></summary>
			MEM_4MB_PAGES = 0x80000000,
			/// <summary></summary>
			MEM_64K_PAGES = MEM_LARGE_PAGES | MEM_PHYSICAL
		}

		/// <summary>
		/// The following are the memory-protection options; you must specify one of the following values when allocating or protecting a page in memory.
		/// Protection attributes cannot be assigned to a portion of a page; they can only be assigned to a whole page.
		/// </summary>
		[PInvokeData("WinNT.h")]
		[Flags]
		public enum MEM_PROTECTION : uint
		{
			/// <summary>
			/// Disables all access to the committed region of pages. An attempt to read from, write to, or execute the committed region results in an access violation.
			/// <para>This flag is not supported by the CreateFileMapping function.</para>
			/// </summary>
			PAGE_NOACCESS = 0x01,
			/// <summary>
			/// Enables read-only access to the committed region of pages. An attempt to write to the committed region results in an access violation. If Data
			/// Execution Prevention is enabled, an attempt to execute code in the committed region results in an access violation.
			/// </summary>
			PAGE_READONLY = 0x02,
			/// <summary>
			/// Enables read-only or read/write access to the committed region of pages. If Data Execution Prevention is enabled, attempting to execute code in
			/// the committed region results in an access violation.
			/// </summary>
			PAGE_READWRITE = 0x04,
			/// <summary>
			/// Enables read-only or copy-on-write access to a mapped view of a file mapping object. An attempt to write to a committed copy-on-write page
			/// results in a private copy of the page being made for the process. The private page is marked as PAGE_READWRITE, and the change is written to the
			/// new page. If Data Execution Prevention is enabled, attempting to execute code in the committed region results in an access violation.
			/// <para>This flag is not supported by the VirtualAlloc or VirtualAllocEx functions.</para>
			/// </summary>
			PAGE_WRITECOPY = 0x08,
			/// <summary>
			/// Enables execute access to the committed region of pages. An attempt to write to the committed region results in an access violation.
			/// <para>This flag is not supported by the CreateFileMapping function.</para>
			/// </summary>
			PAGE_EXECUTE = 0x10,
			/// <summary>
			/// Enables execute or read-only access to the committed region of pages. An attempt to write to the committed region results in an access violation.
			/// <para>
			/// Windows Server 2003 and Windows XP: This attribute is not supported by the CreateFileMapping function until Windows XP with SP2 and Windows
			/// Server 2003 with SP1.
			/// </para>
			/// </summary>
			PAGE_EXECUTE_READ = 0x20,
			/// <summary>
			/// Enables execute, read-only, or read/write access to the committed region of pages.
			/// <para>
			/// Windows Server 2003 and Windows XP: This attribute is not supported by the CreateFileMapping function until Windows XP with SP2 and Windows
			/// Server 2003 with SP1.
			/// </para>
			/// </summary>
			PAGE_EXECUTE_READWRITE = 0x40,
			/// <summary>
			/// Enables execute, read-only, or copy-on-write access to a mapped view of a file mapping object. An attempt to write to a committed copy-on-write
			/// page results in a private copy of the page being made for the process. The private page is marked as PAGE_EXECUTE_READWRITE, and the change is
			/// written to the new page.
			/// <para>This flag is not supported by the VirtualAlloc or VirtualAllocEx functions.</para>
			/// <para>
			/// Windows Vista, Windows Server 2003 and Windows XP: This attribute is not supported by the CreateFileMapping function until Windows Vista with SP1
			/// and Windows Server 2008.
			/// </para>
			/// </summary>
			PAGE_EXECUTE_WRITECOPY = 0x80,
			/// <summary>
			/// Pages in the region become guard pages. Any attempt to access a guard page causes the system to raise a STATUS_GUARD_PAGE_VIOLATION exception and
			/// turn off the guard page status. Guard pages thus act as a one-time access alarm. For more information, see Creating Guard Pages.
			/// <para>When an access attempt leads the system to turn off guard page status, the underlying page protection takes over.</para>
			/// <para>If a guard page exception occurs during a system service, the service typically returns a failure status indicator.</para>
			/// <para>This value cannot be used with PAGE_NOACCESS.</para>
			/// <para>This flag is not supported by the CreateFileMapping function.</para>
			/// </summary>
			PAGE_GUARD = 0x100,
			/// <summary>
			/// Sets all pages to be non-cachable. Applications should not use this attribute except when explicitly required for a device. Using the interlocked
			/// functions with memory that is mapped with SEC_NOCACHE can result in an EXCEPTION_ILLEGAL_INSTRUCTION exception.
			/// <para>The PAGE_NOCACHE flag cannot be used with the PAGE_GUARD, PAGE_NOACCESS, or PAGE_WRITECOMBINE flags.</para>
			/// <para>
			/// The PAGE_NOCACHE flag can be used only when allocating private memory with the VirtualAlloc, VirtualAllocEx, or VirtualAllocExNuma functions. To
			/// enable non-cached memory access for shared memory, specify the SEC_NOCACHE flag when calling the CreateFileMapping function.
			/// </para>
			/// </summary>
			PAGE_NOCACHE = 0x200,
			/// <summary>
			/// Sets all pages to be write-combined.
			/// <para>
			/// Applications should not use this attribute except when explicitly required for a device. Using the interlocked functions with memory that is
			/// mapped as write-combined can result in an EXCEPTION_ILLEGAL_INSTRUCTION exception.
			/// </para>
			/// <para>The PAGE_WRITECOMBINE flag cannot be specified with the PAGE_NOACCESS, PAGE_GUARD, and PAGE_NOCACHE flags.</para>
			/// <para>
			/// The PAGE_WRITECOMBINE flag can be used only when allocating private memory with the VirtualAlloc, VirtualAllocEx, or VirtualAllocExNuma
			/// functions. To enable write-combined memory access for shared memory, specify the SEC_WRITECOMBINE flag when calling the CreateFileMapping function.
			/// </para>
			/// <para>Windows Server 2003 and Windows XP: This flag is not supported until Windows Server 2003 with SP1.</para>
			/// </summary>
			PAGE_WRITECOMBINE = 0x400,
			/// <summary>The page contents that you supply are excluded from measurement with the EEXTEND instruction of the Intel SGX programming model.</summary>
			PAGE_ENCLAVE_UNVALIDATED = 0x20000000,
			/// <summary>
			/// Sets all locations in the pages as invalid targets for CFG. Used along with any execute page protection like PAGE_EXECUTE, PAGE_EXECUTE_READ,
			/// PAGE_EXECUTE_READWRITE and PAGE_EXECUTE_WRITECOPY. Any indirect call to locations in those pages will fail CFG checks and the process will be
			/// terminated. The default behavior for executable pages allocated is to be marked valid call targets for CFG.
			/// <para>This flag is not supported by the VirtualProtect or CreateFileMapping functions.</para>
			/// </summary>
			PAGE_TARGETS_INVALID = 0x40000000,
			/// <summary>
			/// Pages in the region will not have their CFG information updated while the protection changes for VirtualProtect. For example, if the pages in the
			/// region was allocated using PAGE_TARGETS_INVALID, then the invalid information will be maintained while the page protection changes. This flag is
			/// only valid when the protection changes to an executable type like PAGE_EXECUTE, PAGE_EXECUTE_READ, PAGE_EXECUTE_READWRITE and
			/// PAGE_EXECUTE_WRITECOPY. The default behavior for VirtualProtect protection change to executable is to mark all locations as valid call targets
			/// for CFG.
			/// <para>The following are modifiers that can be used in addition to the options provided in the previous table, except as noted.</para>
			/// </summary>
			PAGE_TARGETS_NO_UPDATE = 0x40000000,
			/// <summary>The page contains a thread control structure (TCS).</summary>
			PAGE_ENCLAVE_THREAD_CONTROL = 0x80000000,
			/// <summary></summary>
			PAGE_REVERT_TO_FILE_MAP = 0x80000000,
		}

		/// <summary>The memory condition under which the object is to be signaled.</summary>
		[PInvokeData("MemoryApi.h")]
		public enum MEMORY_RESOURCE_NOTIFICATION_TYPE
		{
			/// <summary>Available physical memory is running low.</summary>
			LowMemoryResourceNotification,
			/// <summary>Available physical memory is high.</summary>
			HighMemoryResourceNotification,
		}

		/// <summary>
		/// Indicates how important the offered memory is to the application. A higher priority increases the probability that the offered memory can be
		/// reclaimed intact when calling ReclaimVirtualMemory.
		/// </summary>
		public enum OFFER_PRIORITY
		{
			/// <summary>The offered memory is very low priority, and should be the first discarded.</summary>
			VmOfferPriorityVeryLow = 1,
			/// <summary>The offered memory is low priority.</summary>
			VmOfferPriorityLow,
			/// <summary>The offered memory is below normal priority.</summary>
			VmOfferPriorityBelowNormal,
			/// <summary>The offered memory is of normal priority to the application, and should be the last discarded.</summary>
			VmOfferPriorityNormal
		}

		/// <summary>Flags that determines the allocation attributes of the section, file, page, etc.</summary>
		[PInvokeData("winbase.h", MSDNShortId = "d3302183-76a0-47ec-874f-1173db353dfe")]
		public enum SEC_ALLOC : uint
		{
			/// <summary>
			/// If the file mapping object is backed by the operating system paging file (the hfile parameter is INVALID_HANDLE_VALUE), specifies that when a view of
			/// the file is mapped into a process address space, the entire range of pages is committed rather than reserved. The system must have enough committable
			/// pages to hold the entire mapping. Otherwise, CreateFileMapping fails.This attribute has no effect for file mapping objects that are backed by
			/// executable image files or data files (the hfile parameter is a handle to a file).SEC_COMMIT cannot be combined with SEC_RESERVE.If no attribute is
			/// specified, SEC_COMMIT is assumed.
			/// </summary>
			SEC_COMMIT = 0x8000000,
			/// <summary>
			/// Specifies that the file that the hFile parameter specifies is an executable image file.The SEC_IMAGE attribute must be combined with a page
			/// protection value such as PAGE_READONLY. However, this page protection value has no effect on views of the executable image file. Page protection for
			/// views of an executable image file is determined by the executable file itself.No other attributes are valid with SEC_IMAGE.
			/// </summary>
			SEC_IMAGE = 0x1000000,
			/// <summary>
			/// Specifies that the file that the hFile parameter specifies is an executable image file that will not be executed and the loaded image file will have
			/// no forced integrity checks run. Additionally, mapping a view of a file mapping object created with the SEC_IMAGE_NO_EXECUTE attribute will not invoke
			/// driver callbacks registered using the PsSetLoadImageNotifyRoutine kernel API.The SEC_IMAGE_NO_EXECUTE attribute must be combined with the
			/// PAGE_READONLY page protection value. No other attributes are valid with SEC_IMAGE_NO_EXECUTE.Windows Server 2008 R2, Windows 7, Windows Server 2008,
			/// Windows Vista, Windows Server 2003 and Windows XP: This value is not supported before Windows Server 2012 and Windows 8.
			/// </summary>
			SEC_IMAGE_NO_EXECUTE = 0x11000000,
			/// <summary>
			/// Enables large pages to be used for file mapping objects that are backed by the operating system paging file (the hfile parameter is
			/// INVALID_HANDLE_VALUE). This attribute is not supported for file mapping objects that are backed by executable image files or data files (the hFile
			/// parameter is a handle to an executable image or data file).The maximum size of the file mapping object must be a multiple of the minimum size of a
			/// large page returned by the GetLargePageMinimum function. If it is not, CreateFileMapping fails. When mapping a view of a file mapping object created
			/// with SEC_LARGE_PAGES, the base address and view size must also be multiples of the minimum large page size.SEC_LARGE_PAGES requires the
			/// SeLockMemoryPrivilege privilege to be enabled in the caller&amp;#39;s token.If SEC_LARGE_PAGES is specified, SEC_COMMIT must also be
			/// specified.Windows Server 2003: This value is not supported until Windows Server 2003 with SP1.Windows XP: This value is not supported.
			/// </summary>
			SEC_LARGE_PAGES = 0x80000000,
			/// <summary>
			/// Sets all pages to be non-cachable.Applications should not use this attribute except when explicitly required for a device. Using the interlocked
			/// functions with memory that is mapped with SEC_NOCACHE can result in an EXCEPTION_ILLEGAL_INSTRUCTION exception.SEC_NOCACHE requires either the
			/// SEC_RESERVE or SEC_COMMIT attribute to be set.
			/// </summary>
			SEC_NOCACHE = 0x10000000,
			/// <summary>
			/// If the file mapping object is backed by the operating system paging file (the hfile parameter is INVALID_HANDLE_VALUE), specifies that when a view of
			/// the file is mapped into a process address space, the entire range of pages is reserved for later use by the process rather than committed.Reserved
			/// pages can be committed in subsequent calls to the VirtualAlloc function. After the pages are committed, they cannot be freed or decommitted with the
			/// VirtualFree function.This attribute has no effect for file mapping objects that are backed by executable image files or data files (the hfile
			/// parameter is a handle to a file).SEC_RESERVE cannot be combined with SEC_COMMIT.
			/// </summary>
			SEC_RESERVE = 0x4000000,
			/// <summary>
			/// Sets all pages to be write-combined.Applications should not use this attribute except when explicitly required for a device. Using the interlocked
			/// functions with memory that is mapped with SEC_WRITECOMBINE can result in an EXCEPTION_ILLEGAL_INSTRUCTION exception.SEC_WRITECOMBINE requires either
			/// the SEC_RESERVE or SEC_COMMIT attribute to be set.Windows Server 2003 and Windows XP: This flag is not supported until Windows Vista.
			/// </summary>
			SEC_WRITECOMBINE = 0x40000000,

		}

		/// <summary>Used by <see cref="QueryVirtualMemoryInformation"/>.</summary>
		public enum WIN32_MEMORY_INFORMATION_CLASS
		{
			/// <summary>This parameter must point to a <c>WIN32_MEMORY_REGION_INFORMATION</c> structure.</summary>
			MemoryRegionInfo
		}

		/// <summary>Flags used in <see cref="GetWriteWatch"/>.</summary>
		public enum WRITE_WATCH
		{
			/// <summary>Do not reset the write-tracking state.</summary>
			WRITE_WATCH_UNSPECIFIED = 0,
			/// <summary>Reset the write-tracking state.</summary>
			WRITE_WATCH_FLAG_RESET = 1
		}

		/// <summary>
		/// <para>Allocates physical memory pages to be mapped and unmapped within any Address Windowing Extensions (AWE) region of a specified process.</para>
		/// <para>
		/// <c>64-bit Windows on Itanium-based systems:</c> Due to the difference in page sizes, <c>AllocateUserPhysicalPages</c> is not supported for 32-bit applications.
		/// </para>
		/// </summary>
		/// <param name="hProcess">
		/// <para>A handle to a process.</para>
		/// <para>
		/// The function allocates memory that can later be mapped within the virtual address space of this process. The handle must have the
		/// <c>PROCESS_VM_OPERATION</c> access right. For more information, see Process Security and Access Rights.
		/// </para>
		/// </param>
		/// <param name="NumberOfPages">
		/// <para>The size of the physical memory to allocate, in pages.</para>
		/// <para>
		/// To determine the page size of the computer, use the <c>GetSystemInfo</c> function. On output, this parameter receives the number of pages that are
		/// actually allocated, which might be less than the number requested.
		/// </para>
		/// </param>
		/// <param name="UserPfnArray">
		/// <para>A pointer to an array to store the page frame numbers of the allocated memory.</para>
		/// <para>The size of the array that is allocated should be at least the NumberOfPages times the size of the <c>ULONG_PTR</c> data type.</para>
		/// <para>
		/// Do not attempt to modify this buffer. It contains operating system data, and corruption could be catastrophic. The information in the buffer is not
		/// useful to an application.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is <c>TRUE</c>.</para>
		/// <para>
		/// Fewer pages than requested can be allocated. The caller must check the value of the NumberOfPages parameter on return to see how many pages are
		/// allocated. All allocated page frame numbers are sequentially placed in the memory pointed to by the UserPfnArray parameter.
		/// </para>
		/// <para>If the function fails, the return value is <c>FALSE</c>, and no frames are allocated. To get extended error information, call <c>GetLastError</c>.</para>
		/// </returns>
		// BOOL WINAPI AllocateUserPhysicalPages( _In_ HANDLE hProcess, _Inout_ PULONG_PTR NumberOfPages, _Out_ PULONG_PTR UserPfnArray);
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("WinBase.h", MSDNShortId = "aa366528")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool AllocateUserPhysicalPages([In] IntPtr hProcess, ref SizeT NumberOfPages, out IntPtr UserPfnArray);

		/// <summary>
		/// Allocates physical memory pages to be mapped and unmapped within any Address Windowing Extensions (AWE) region of a specified process and specifies
		/// the NUMA node for the physical memory.
		/// </summary>
		/// <param name="hProcess">
		/// <para>A handle to a process.</para>
		/// <para>
		/// The function allocates memory that can later be mapped within the virtual address space of this process. The handle must have the
		/// <c>PROCESS_VM_OPERATION</c> access right. For more information, see Process Security and Access Rights.
		/// </para>
		/// </param>
		/// <param name="NumberOfPages">
		/// <para>The size of the physical memory to allocate, in pages.</para>
		/// <para>
		/// To determine the page size of the computer, use the <c>GetSystemInfo</c> function. On output, this parameter receives the number of pages that are
		/// actually allocated, which might be less than the number requested.
		/// </para>
		/// </param>
		/// <param name="PageArray">
		/// <para>A pointer to an array to store the page frame numbers of the allocated memory.</para>
		/// <para>The size of the array that is allocated should be at least the NumberOfPages times the size of the <c>ULONG_PTR</c> data type.</para>
		/// </param>
		/// <param name="nndPreferred">The NUMA node where the physical memory should reside.</param>
		/// <returns>
		/// <para>If the function succeeds, the return value is <c>TRUE</c>.</para>
		/// <para>
		/// Fewer pages than requested can be allocated. The caller must check the value of the NumberOfPages parameter on return to see how many pages are
		/// allocated. All allocated page frame numbers are sequentially placed in the memory pointed to by the PageArray parameter.
		/// </para>
		/// <para>
		/// If the function fails, the return value is <c>FALSE</c> and no frames are allocated. To get extended error information, call the <c>GetLastError</c> function.
		/// </para>
		/// </returns>
		// BOOL WINAPI AllocateUserPhysicalPagesNuma( _In_ HANDLE hProcess, _Inout_ PULONG_PTR NumberOfPages, _Out_ PULONG_PTR PageArray, _In_ DWORD nndPreferred);
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("WinBase.h", MSDNShortId = "aa366529")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool AllocateUserPhysicalPagesNuma([In] IntPtr hProcess, ref SizeT NumberOfPages, out IntPtr PageArray, uint nndPreferred);

		/// <summary>
		/// <para>Creates or opens a named or unnamed file mapping object for a specified file.</para>
		/// <para>To specify the NUMA node for the physical memory, see <c>CreateFileMappingNuma</c>.</para>
		/// </summary>
		/// <param name="hFile">
		/// <para>A handle to the file from which to create a file mapping object.</para>
		/// <para>
		/// The file must be opened with access rights that are compatible with the protection flags that the flProtect parameter specifies. It is not required,
		/// but it is recommended that files you intend to map be opened for exclusive access. For more information, see File Security and Access Rights.
		/// </para>
		/// <para>
		/// If hFile is <c>INVALID_HANDLE_VALUE</c>, the calling process must also specify a size for the file mapping object in the dwMaximumSizeHigh and
		/// dwMaximumSizeLow parameters. In this scenario, <c>CreateFileMapping</c> creates a file mapping object of a specified size that is backed by the
		/// system paging file instead of by a file in the file system.
		/// </para>
		/// </param>
		/// <param name="lpAttributes">
		/// <para>
		/// A pointer to a <c>SECURITY_ATTRIBUTES</c> structure that determines whether a returned handle can be inherited by child processes. The
		/// <c>lpSecurityDescriptor</c> member of the <c>SECURITY_ATTRIBUTES</c> structure specifies a security descriptor for a new file mapping object.
		/// </para>
		/// <para>
		/// If lpAttributes is <c>NULL</c>, the handle cannot be inherited and the file mapping object gets a default security descriptor. The access control
		/// lists (ACL) in the default security descriptor for a file mapping object come from the primary or impersonation token of the creator. For more
		/// information, see File Mapping Security and Access Rights.
		/// </para>
		/// </param>
		/// <param name="flProtect">
		/// <para>Specifies the page protection of the file mapping object. All mapped views of the object must be compatible with this protection.</para>
		/// <para>This parameter can be one of the following values.</para>
		/// <para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>PAGE_EXECUTE_READ0x20</term>
		/// <term>
		/// Allows views to be mapped for read-only, copy-on-write, or execute access.The file handle specified by the hFile parameter must be created with the
		/// GENERIC_READ and GENERIC_EXECUTE access rights.Windows Server 2003 and Windows XP: This value is not available until Windows XP with SP2 and Windows
		/// Server 2003 with SP1.
		/// </term>
		/// </item>
		/// <item>
		/// <term>PAGE_EXECUTE_READWRITE0x40</term>
		/// <term>
		/// Allows views to be mapped for read-only, copy-on-write, read/write, or execute access.The file handle that the hFile parameter specifies must be
		/// created with the GENERIC_READ, GENERIC_WRITE, and GENERIC_EXECUTE access rights.Windows Server 2003 and Windows XP: This value is not available until
		/// Windows XP with SP2 and Windows Server 2003 with SP1.
		/// </term>
		/// </item>
		/// <item>
		/// <term>PAGE_EXECUTE_WRITECOPY0x80</term>
		/// <term>
		/// Allows views to be mapped for read-only, copy-on-write, or execute access. This value is equivalent to PAGE_EXECUTE_READ.The file handle that the
		/// hFile parameter specifies must be created with the GENERIC_READ and GENERIC_EXECUTE access rights.Windows Vista: This value is not available until
		/// Windows Vista with SP1.Windows Server 2003 and Windows XP: This value is not supported.
		/// </term>
		/// </item>
		/// <item>
		/// <term>PAGE_READONLY0x02</term>
		/// <term>
		/// Allows views to be mapped for read-only or copy-on-write access. An attempt to write to a specific region results in an access violation.The file
		/// handle that the hFile parameter specifies must be created with the GENERIC_READ access right.
		/// </term>
		/// </item>
		/// <item>
		/// <term>PAGE_READWRITE0x04</term>
		/// <term>
		/// Allows views to be mapped for read-only, copy-on-write, or read/write access.The file handle that the hFile parameter specifies must be created with
		/// the GENERIC_READ and GENERIC_WRITE access rights.
		/// </term>
		/// </item>
		/// <item>
		/// <term>PAGE_WRITECOPY0x08</term>
		/// <term>
		/// Allows views to be mapped for read-only or copy-on-write access. This value is equivalent to PAGE_READONLY.The file handle that the hFile parameter
		/// specifies must be created with the GENERIC_READ access right.
		/// </term>
		/// </item>
		/// </list>
		/// </para>
		/// <para>
		/// An application can specify one or more of the following attributes for the file mapping object by combining them with one of the preceding page
		/// protection values.
		/// </para>
		/// <para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>SEC_COMMIT0x8000000</term>
		/// <term>
		/// If the file mapping object is backed by the operating system paging file (the hfile parameter is INVALID_HANDLE_VALUE), specifies that when a view of
		/// the file is mapped into a process address space, the entire range of pages is committed rather than reserved. The system must have enough committable
		/// pages to hold the entire mapping. Otherwise, CreateFileMapping fails.This attribute has no effect for file mapping objects that are backed by
		/// executable image files or data files (the hfile parameter is a handle to a file).SEC_COMMIT cannot be combined with SEC_RESERVE.If no attribute is
		/// specified, SEC_COMMIT is assumed.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SEC_IMAGE0x1000000</term>
		/// <term>
		/// Specifies that the file that the hFile parameter specifies is an executable image file.The SEC_IMAGE attribute must be combined with a page
		/// protection value such as PAGE_READONLY. However, this page protection value has no effect on views of the executable image file. Page protection for
		/// views of an executable image file is determined by the executable file itself.No other attributes are valid with SEC_IMAGE.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SEC_IMAGE_NO_EXECUTE0x11000000</term>
		/// <term>
		/// Specifies that the file that the hFile parameter specifies is an executable image file that will not be executed and the loaded image file will have
		/// no forced integrity checks run. Additionally, mapping a view of a file mapping object created with the SEC_IMAGE_NO_EXECUTE attribute will not invoke
		/// driver callbacks registered using the PsSetLoadImageNotifyRoutine kernel API.The SEC_IMAGE_NO_EXECUTE attribute must be combined with the
		/// PAGE_READONLY page protection value. No other attributes are valid with SEC_IMAGE_NO_EXECUTE.Windows Server 2008 R2, Windows 7, Windows Server 2008,
		/// Windows Vista, Windows Server 2003 and Windows XP: This value is not supported before Windows Server 2012 and Windows 8.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SEC_LARGE_PAGES0x80000000</term>
		/// <term>
		/// Enables large pages to be used for file mapping objects that are backed by the operating system paging file (the hfile parameter is
		/// INVALID_HANDLE_VALUE). This attribute is not supported for file mapping objects that are backed by executable image files or data files (the hFile
		/// parameter is a handle to an executable image or data file).The maximum size of the file mapping object must be a multiple of the minimum size of a
		/// large page returned by the GetLargePageMinimum function. If it is not, CreateFileMapping fails. When mapping a view of a file mapping object created
		/// with SEC_LARGE_PAGES, the base address and view size must also be multiples of the minimum large page size.SEC_LARGE_PAGES requires the
		/// SeLockMemoryPrivilege privilege to be enabled in the caller&amp;#39;s token.If SEC_LARGE_PAGES is specified, SEC_COMMIT must also be
		/// specified.Windows Server 2003: This value is not supported until Windows Server 2003 with SP1.Windows XP: This value is not supported.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SEC_NOCACHE0x10000000</term>
		/// <term>
		/// Sets all pages to be non-cachable.Applications should not use this attribute except when explicitly required for a device. Using the interlocked
		/// functions with memory that is mapped with SEC_NOCACHE can result in an EXCEPTION_ILLEGAL_INSTRUCTION exception.SEC_NOCACHE requires either the
		/// SEC_RESERVE or SEC_COMMIT attribute to be set.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SEC_RESERVE0x4000000</term>
		/// <term>
		/// If the file mapping object is backed by the operating system paging file (the hfile parameter is INVALID_HANDLE_VALUE), specifies that when a view of
		/// the file is mapped into a process address space, the entire range of pages is reserved for later use by the process rather than committed.Reserved
		/// pages can be committed in subsequent calls to the VirtualAlloc function. After the pages are committed, they cannot be freed or decommitted with the
		/// VirtualFree function.This attribute has no effect for file mapping objects that are backed by executable image files or data files (the hfile
		/// parameter is a handle to a file).SEC_RESERVE cannot be combined with SEC_COMMIT.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SEC_WRITECOMBINE0x40000000</term>
		/// <term>
		/// Sets all pages to be write-combined.Applications should not use this attribute except when explicitly required for a device. Using the interlocked
		/// functions with memory that is mapped with SEC_WRITECOMBINE can result in an EXCEPTION_ILLEGAL_INSTRUCTION exception.SEC_WRITECOMBINE requires either
		/// the SEC_RESERVE or SEC_COMMIT attribute to be set.Windows Server 2003 and Windows XP: This flag is not supported until Windows Vista.
		/// </term>
		/// </item>
		/// </list>
		/// </para>
		/// </param>
		/// <param name="dwMaximumSizeHigh">The high-order <c>DWORD</c> of the maximum size of the file mapping object.</param>
		/// <param name="dwMaximumSizeLow">
		/// <para>The low-order <c>DWORD</c> of the maximum size of the file mapping object.</para>
		/// <para>
		/// If this parameter and dwMaximumSizeHigh are 0 (zero), the maximum size of the file mapping object is equal to the current size of the file that hFile identifies.
		/// </para>
		/// <para>
		/// An attempt to map a file with a length of 0 (zero) fails with an error code of <c>ERROR_FILE_INVALID</c>. Applications should test for files with a
		/// length of 0 (zero) and reject those files.
		/// </para>
		/// </param>
		/// <param name="lpName">
		/// <para>The name of the file mapping object.</para>
		/// <para>
		/// If this parameter matches the name of an existing mapping object, the function requests access to the object with the protection that flProtect specifies.
		/// </para>
		/// <para>If this parameter is <c>NULL</c>, the file mapping object is created without a name.</para>
		/// <para>
		/// If lpName matches the name of an existing event, semaphore, mutex, waitable timer, or job object, the function fails, and the <c>GetLastError</c>
		/// function returns <c>ERROR_INVALID_HANDLE</c>. This occurs because these objects share the same namespace.
		/// </para>
		/// <para>
		/// The name can have a "Global\" or "Local\" prefix to explicitly create the object in the global or session namespace. The remainder of the name can
		/// contain any character except the backslash character (\). Creating a file mapping object in the global namespace from a session other than session
		/// zero requires the SeCreateGlobalPrivilege privilege. For more information, see Kernel Object Namespaces.
		/// </para>
		/// <para>
		/// Fast user switching is implemented by using Terminal Services sessions. The first user to log on uses session 0 (zero), the next user to log on uses
		/// session 1 (one), and so on. Kernel object names must follow the guidelines that are outlined for Terminal Services so that applications can support
		/// multiple users.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is a handle to the newly created file mapping object.</para>
		/// <para>
		/// If the object exists before the function call, the function returns a handle to the existing object (with its current size, not the specified size),
		/// and <c>GetLastError</c> returns <c>ERROR_ALREADY_EXISTS</c>.
		/// </para>
		/// <para>If the function fails, the return value is <c>NULL</c>. To get extended error information, call <c>GetLastError</c>.</para>
		/// </returns>
		// HANDLE WINAPI CreateFileMapping( _In_ HANDLE hFile, _In_opt_ LPSECURITY_ATTRIBUTES lpAttributes, _In_ DWORD flProtect, _In_ DWORD dwMaximumSizeHigh,
		// _In_ DWORD dwMaximumSizeLow, _In_opt_ LPCTSTR lpName);
		[DllImport(Lib.Kernel32, SetLastError = true, CharSet = CharSet.Auto)]
		[PInvokeData("WinBase.h", MSDNShortId = "aa366537")]
		public static extern IntPtr CreateFileMapping([In] HFILE hFile, [In] SECURITY_ATTRIBUTES lpAttributes, MEM_PROTECTION flProtect,
			uint dwMaximumSizeHigh, uint dwMaximumSizeLow, [In] string lpName);

		/// <summary>Creates or opens a named or unnamed file mapping object for a specified file from a Windows Store app.</summary>
		/// <param name="hFile">
		/// <para>A handle to the file from which to create a file mapping object.</para>
		/// <para>
		/// The file must be opened with access rights that are compatible with the protection flags that the flProtect parameter specifies. It is not required,
		/// but it is recommended that files you intend to map be opened for exclusive access. For more information, see File Security and Access Rights.
		/// </para>
		/// <para>
		/// If hFile is <c>INVALID_HANDLE_VALUE</c>, the calling process must also specify a size for the file mapping object in the dwMaximumSizeHigh and
		/// dwMaximumSizeLow parameters. In this scenario, <c>CreateFileMappingFromApp</c> creates a file mapping object of a specified size that is backed by
		/// the system paging file instead of by a file in the file system.
		/// </para>
		/// </param>
		/// <param name="SecurityAttributes">
		/// <para>
		/// A pointer to a <c>SECURITY_ATTRIBUTES</c> structure that determines whether a returned handle can be inherited by child processes. The
		/// <c>lpSecurityDescriptor</c> member of the <c>SECURITY_ATTRIBUTES</c> structure specifies a security descriptor for a new file mapping object.
		/// </para>
		/// <para>
		/// If SecurityAttributes is <c>NULL</c>, the handle cannot be inherited and the file mapping object gets a default security descriptor. The access
		/// control lists (ACL) in the default security descriptor for a file mapping object come from the primary or impersonation token of the creator. For
		/// more information, see File Mapping Security and Access Rights.
		/// </para>
		/// </param>
		/// <param name="PageProtection">
		/// <para>Specifies the page protection of the file mapping object. All mapped views of the object must be compatible with this protection.</para>
		/// <para>This parameter can be one of the following values.</para>
		/// <para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>PAGE_READONLY0x02</term>
		/// <term>
		/// Allows views to be mapped for read-only or copy-on-write access. An attempt to write to a specific region results in an access violation.The file
		/// handle that the hFile parameter specifies must be created with the GENERIC_READ access right.
		/// </term>
		/// </item>
		/// <item>
		/// <term>PAGE_READWRITE0x04</term>
		/// <term>
		/// Allows views to be mapped for read-only, copy-on-write, or read/write access.The file handle that the hFile parameter specifies must be created with
		/// the GENERIC_READ and GENERIC_WRITE access rights.
		/// </term>
		/// </item>
		/// <item>
		/// <term>PAGE_WRITECOPY0x08</term>
		/// <term>
		/// Allows views to be mapped for read-only or copy-on-write access. This value is equivalent to PAGE_READONLY.The file handle that the hFile parameter
		/// specifies must be created with the GENERIC_READ access right.
		/// </term>
		/// </item>
		/// </list>
		/// </para>
		/// <para>
		/// An application can specify one or more of the following attributes for the file mapping object by combining them with one of the preceding page
		/// protection values.
		/// </para>
		/// <para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>SEC_COMMIT0x8000000</term>
		/// <term>
		/// If the file mapping object is backed by the operating system paging file (the hfile parameter is INVALID_HANDLE_VALUE), specifies that when a view of
		/// the file is mapped into a process address space, the entire range of pages is committed rather than reserved. The system must have enough committable
		/// pages to hold the entire mapping. Otherwise, CreateFileMappingFromApp fails.This attribute has no effect for file mapping objects that are backed by
		/// executable image files or data files (the hfile parameter is a handle to a file).SEC_COMMIT cannot be combined with SEC_RESERVE.If no attribute is
		/// specified, SEC_COMMIT is assumed.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SEC_IMAGE_NO_EXECUTE0x11000000</term>
		/// <term>
		/// Specifies that the file that the hFile parameter specifies is an executable image file that will not be executed and the loaded image file will have
		/// no forced integrity checks run. Additionally, mapping a view of a file mapping object created with the SEC_IMAGE_NO_EXECUTE attribute will not invoke
		/// driver callbacks registered using the PsSetLoadImageNotifyRoutine kernel API.The SEC_IMAGE_NO_EXECUTE attribute must be combined with the
		/// PAGE_READONLY page protection value. No other attributes are valid with SEC_IMAGE_NO_EXECUTE.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SEC_LARGE_PAGES0x80000000</term>
		/// <term>
		/// Enables large pages to be used for file mapping objects that are backed by the operating system paging file (the hfile parameter is
		/// INVALID_HANDLE_VALUE). This attribute is not supported for file mapping objects that are backed by executable image files or data files (the hFile
		/// parameter is a handle to an executable image or data file).The maximum size of the file mapping object must be a multiple of the minimum size of a
		/// large page returned by the GetLargePageMinimum function. If it is not, CreateFileMappingFromApp fails. When mapping a view of a file mapping object
		/// created with SEC_LARGE_PAGES, the base address and view size must also be multiples of the minimum large page size.SEC_LARGE_PAGES requires the
		/// SeLockMemoryPrivilege privilege to be enabled in the caller&amp;#39;s token.If SEC_LARGE_PAGES is specified, SEC_COMMIT must also be specified.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SEC_NOCACHE0x10000000</term>
		/// <term>
		/// Sets all pages to be non-cachable.Applications should not use this attribute except when explicitly required for a device. Using the interlocked
		/// functions with memory that is mapped with SEC_NOCACHE can result in an EXCEPTION_ILLEGAL_INSTRUCTION exception.SEC_NOCACHE requires either the
		/// SEC_RESERVE or SEC_COMMIT attribute to be set.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SEC_RESERVE0x4000000</term>
		/// <term>
		/// If the file mapping object is backed by the operating system paging file (the hfile parameter is INVALID_HANDLE_VALUE), specifies that when a view of
		/// the file is mapped into a process address space, the entire range of pages is reserved for later use by the process rather than committed.Reserved
		/// pages can be committed in subsequent calls to the VirtualAlloc function. After the pages are committed, they cannot be freed or decommitted with the
		/// VirtualFree function.This attribute has no effect for file mapping objects that are backed by executable image files or data files (the hfile
		/// parameter is a handle to a file).SEC_RESERVE cannot be combined with SEC_COMMIT.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SEC_WRITECOMBINE0x40000000</term>
		/// <term>
		/// Sets all pages to be write-combined.Applications should not use this attribute except when explicitly required for a device. Using the interlocked
		/// functions with memory that is mapped with SEC_WRITECOMBINE can result in an EXCEPTION_ILLEGAL_INSTRUCTION exception.SEC_WRITECOMBINE requires either
		/// the SEC_RESERVE or SEC_COMMIT attribute to be set.
		/// </term>
		/// </item>
		/// </list>
		/// </para>
		/// </param>
		/// <param name="MaximumSize">
		/// <para>The maximum size of the file mapping object.</para>
		/// <para>
		/// An attempt to map a file with a length of 0 (zero) fails with an error code of <c>ERROR_FILE_INVALID</c>. Applications should test for files with a
		/// length of 0 (zero) and reject those files.
		/// </para>
		/// </param>
		/// <param name="Name">
		/// <para>The name of the file mapping object.</para>
		/// <para>
		/// If this parameter matches the name of an existing mapping object, the function requests access to the object with the protection that flProtect specifies.
		/// </para>
		/// <para>If this parameter is <c>NULL</c>, the file mapping object is created without a name.</para>
		/// <para>
		/// If lpName matches the name of an existing event, semaphore, mutex, waitable timer, or job object, the function fails, and the <c>GetLastError</c>
		/// function returns <c>ERROR_INVALID_HANDLE</c>. This occurs because these objects share the same namespace.
		/// </para>
		/// <para>
		/// The name can have a "Global\" or "Local\" prefix to explicitly create the object in the global or session namespace. The remainder of the name can
		/// contain any character except the backslash character (\). Creating a file mapping object in the global namespace from a session other than session
		/// zero requires the SeCreateGlobalPrivilege privilege. For more information, see Kernel Object Namespaces.
		/// </para>
		/// <para>
		/// Fast user switching is implemented by using Terminal Services sessions. The first user to log on uses session 0 (zero), the next user to log on uses
		/// session 1 (one), and so on. Kernel object names must follow the guidelines that are outlined for Terminal Services so that applications can support
		/// multiple users.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is a handle to the newly created file mapping object.</para>
		/// <para>
		/// If the object exists before the function call, the function returns a handle to the existing object (with its current size, not the specified size),
		/// and <c>GetLastError</c> returns <c>ERROR_ALREADY_EXISTS</c>.
		/// </para>
		/// <para>If the function fails, the return value is <c>NULL</c>. To get extended error information, call <c>GetLastError</c>.</para>
		/// </returns>
		// HANDLE WINAPI CreateFileMappingFromApp( _In_ HANDLE hFile, _In_opt_ PSECURITY_ATTRIBUTES SecurityAttributes, _In_ ULONG PageProtection, _In_ ULONG64
		// MaximumSize, _In_opt_ PCWSTR Name);
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true, CharSet = CharSet.Unicode)]
		[PInvokeData("MemoryApi.h", MSDNShortId = "hh994453")]
		public static extern IntPtr CreateFileMappingFromApp([In] HFILE hFile, [In] SECURITY_ATTRIBUTES SecurityAttributes,
			MEM_PROTECTION PageProtection, ulong MaximumSize, [In] string Name);

		/// <summary>Creates or opens a named or unnamed file mapping object for a specified file and specifies the NUMA node for the physical memory.</summary>
		/// <param name="hFile">
		/// <para>A handle to the file from which to create a file mapping object.</para>
		/// <para>
		/// The file must be opened with access rights that are compatible with the protection flags that the flProtect parameter specifies. It is not required,
		/// but it is recommended that files you intend to map be opened for exclusive access. For more information, see File Security and Access Rights.
		/// </para>
		/// <para>
		/// If hFile is <c>INVALID_HANDLE_VALUE</c>, the calling process must also specify a size for the file mapping object in the dwMaximumSizeHigh and
		/// dwMaximumSizeLow parameters. In this scenario, <c>CreateFileMappingNuma</c> creates a file mapping object of a specified size that is backed by the
		/// system paging file instead of by a file in the file system.
		/// </para>
		/// </param>
		/// <param name="lpFileMappingAttributes">
		/// <para>
		/// A pointer to a <c>SECURITY_ATTRIBUTES</c> structure that determines whether a returned handle can be inherited by child processes. The
		/// <c>lpSecurityDescriptor</c> member of the <c>SECURITY_ATTRIBUTES</c> structure specifies a security descriptor for a new file mapping object.
		/// </para>
		/// <para>
		/// If lpFileMappingAttributes is <c>NULL</c>, the handle cannot be inherited and the file mapping object gets a default security descriptor. The access
		/// control lists (ACL) in the default security descriptor for a file mapping object come from the primary or impersonation token of the creator. For
		/// more information, see File Mapping Security and Access Rights.
		/// </para>
		/// </param>
		/// <param name="flProtect">
		/// <para>Specifies the page protection of the file mapping object. All mapped views of the object must be compatible with this protection.</para>
		/// <para>This parameter can be one of the following values.</para>
		/// <para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>PAGE_EXECUTE_READ0x20</term>
		/// <term>
		/// Allows views to be mapped for read-only, copy-on-write, or execute access.The file handle that the hFile parameter specifies must be created with the
		/// GENERIC_READ and GENERIC_EXECUTE access rights.
		/// </term>
		/// </item>
		/// <item>
		/// <term>PAGE_EXECUTE_READWRITE0x40</term>
		/// <term>
		/// Allows views to be mapped for read-only, copy-on-write, read/write or execute access.The file handle that the hFile parameter specifies must be
		/// created with the GENERIC_READ, GENERIC_WRITE, and GENERIC_EXECUTE access rights.
		/// </term>
		/// </item>
		/// <item>
		/// <term>PAGE_EXECUTE_WRITECOPY0x80</term>
		/// <term>
		/// Allows views to be mapped for read-only, copy-on-write, or execute access. This value is equivalent to PAGE_EXECUTE_READ.The file handle that the
		/// hFile parameter specifies must be created with the GENERIC_READ and GENERIC_EXECUTE access rights.Windows Vista: This value is not available until
		/// Windows Vista with SP1.
		/// </term>
		/// </item>
		/// <item>
		/// <term>PAGE_READONLY0x02</term>
		/// <term>
		/// Allows views to be mapped for read-only or copy-on-write access. An attempt to write to a specific region results in an access violation.The file
		/// handle that the hFile parameter specifies must be created with the GENERIC_READ access right.
		/// </term>
		/// </item>
		/// <item>
		/// <term>PAGE_READWRITE0x04</term>
		/// <term>
		/// Allows views to be mapped for read-only, copy-on-write, or read/write access.The file handle that the hFile parameter specifies must be created with
		/// the GENERIC_READ and GENERIC_WRITE access rights.
		/// </term>
		/// </item>
		/// <item>
		/// <term>PAGE_WRITECOPY0x08</term>
		/// <term>
		/// Allows views to be mapped for read-only or copy-on-write access. This value is equivalent to PAGE_READONLY.The file handle that the hFile parameter
		/// specifies must be created with the GENERIC_READ access right.
		/// </term>
		/// </item>
		/// </list>
		/// </para>
		/// <para>
		/// An application can specify one or more of the following attributes for the file mapping object by combining them with one of the preceding page
		/// protection values.
		/// </para>
		/// <para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>SEC_COMMIT0x8000000</term>
		/// <term>Allocates physical storage in memory or the paging file for all pages. This is the default setting.</term>
		/// </item>
		/// <item>
		/// <term>SEC_IMAGE0x1000000</term>
		/// <term>
		/// Sets the file that is specified to be an executable image file.The SEC_IMAGE attribute must be combined with a page protection value such as
		/// PAGE_READONLY. However, this page protection value has no effect on views of the executable image file. Page protection for views of an executable
		/// image file is determined by the executable file itself.No other attributes are valid with SEC_IMAGE.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SEC_IMAGE_NO_EXECUTE0x11000000</term>
		/// <term>
		/// Specifies that the file that the hFile parameter specifies is an executable image file that will not be executed and the loaded image file will have
		/// no forced integrity checks run. Additionally, mapping a view of a file mapping object created with the SEC_IMAGE_NO_EXECUTE attribute will not invoke
		/// driver callbacks registered using the PsSetLoadImageNotifyRoutine kernel API.The SEC_IMAGE_NO_EXECUTE attribute must be combined with the
		/// PAGE_READONLY page protection value. No other attributes are valid with SEC_IMAGE_NO_EXECUTE.Windows Server 2008 R2, Windows 7, Windows Server 2008
		/// and Windows Vista: This value is not supported before Windows Server 2012 and Windows 8.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SEC_LARGE_PAGES0x80000000</term>
		/// <term>
		/// Enables large pages to be used when mapping images or backing from the pagefile, but not when mapping data for regular files. Be sure to specify the
		/// maximum size of the file mapping object as the minimum size of a large page reported by the GetLargePageMinimum function and to enable the
		/// SeLockMemoryPrivilege privilege.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SEC_NOCACHE0x10000000</term>
		/// <term>
		/// Sets all pages to noncachable.Applications should not use this flag except when explicitly required for a device. Using the interlocked functions
		/// with memory mapped with SEC_NOCACHE can result in an EXCEPTION_ILLEGAL_INSTRUCTION exception.SEC_NOCACHE requires either SEC_RESERVE or SEC_COMMIT to
		/// be set.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SEC_RESERVE0x4000000</term>
		/// <term>
		/// Reserves all pages without allocating physical storage.The reserved range of pages cannot be used by any other allocation operations until the range
		/// of pages is released.Reserved pages can be identified in subsequent calls to the VirtualAllocExNuma function. This attribute is valid only if the
		/// hFile parameter is INVALID_HANDLE_VALUE (that is, a file mapping object that is backed by the system paging file).
		/// </term>
		/// </item>
		/// <item>
		/// <term>SEC_WRITECOMBINE0x40000000</term>
		/// <term>
		/// Sets all pages to be write-combined.Applications should not use this attribute except when explicitly required for a device. Using the interlocked
		/// functions with memory that is mapped with SEC_WRITECOMBINE can result in an EXCEPTION_ILLEGAL_INSTRUCTION exception.SEC_WRITECOMBINE requires either
		/// the SEC_RESERVE or SEC_COMMIT attribute to be set.
		/// </term>
		/// </item>
		/// </list>
		/// </para>
		/// </param>
		/// <param name="dwMaximumSizeHigh">The high-order <c>DWORD</c> of the maximum size of the file mapping object.</param>
		/// <param name="dwMaximumSizeLow">
		/// <para>The low-order <c>DWORD</c> of the maximum size of the file mapping object.</para>
		/// <para>
		/// If this parameter and the dwMaximumSizeHigh parameter are 0 (zero), the maximum size of the file mapping object is equal to the current size of the
		/// file that the hFile parameter identifies.
		/// </para>
		/// <para>
		/// An attempt to map a file with a length of 0 (zero) fails with an error code of <c>ERROR_FILE_INVALID</c>. Applications should test for files with a
		/// length of 0 (zero) and reject those files.
		/// </para>
		/// </param>
		/// <param name="lpName">
		/// <para>The name of the file mapping object.</para>
		/// <para>
		/// If this parameter matches the name of an existing file mapping object, the function requests access to the object with the protection that the
		/// flProtect parameter specifies.
		/// </para>
		/// <para>If this parameter is <c>NULL</c>, the file mapping object is created without a name.</para>
		/// <para>
		/// If the lpName parameter matches the name of an existing event, semaphore, mutex, waitable timer, or job object, the function fails and the
		/// <c>GetLastError</c> function returns <c>ERROR_INVALID_HANDLE</c>. This occurs because these objects share the same namespace.
		/// </para>
		/// <para>
		/// The name can have a "Global\" or "Local\" prefix to explicitly create the object in the global or session namespace. The remainder of the name can
		/// contain any character except the backslash character (\). Creating a file mapping object in the global namespace requires the SeCreateGlobalPrivilege
		/// privilege. For more information, see Kernel Object Namespaces.
		/// </para>
		/// <para>
		/// Fast user switching is implemented by using Terminal Services sessions. The first user to log on uses session 0 (zero), the next user to log on uses
		/// session 1 (one), and so on. Kernel object names must follow the guidelines so that applications can support multiple users.
		/// </para>
		/// </param>
		/// <param name="nndPreferred">
		/// <para>The NUMA node where the physical memory should reside.</para>
		/// <para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>NUMA_NO_PREFERRED_NODE = 0xffffffff</term>
		/// <term>No NUMA node is preferred. This is the same as calling the CreateFileMapping function.</term>
		/// </item>
		/// </list>
		/// </para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is a handle to the file mapping object.</para>
		/// <para>
		/// If the object exists before the function call, the function returns a handle to the existing object (with its current size, not the specified size)
		/// and the <c>GetLastError</c> function returns <c>ERROR_ALREADY_EXISTS</c>.
		/// </para>
		/// <para>If the function fails, the return value is <c>NULL</c>. To get extended error information, call the <c>GetLastError</c> function.</para>
		/// </returns>
		// HANDLE WINAPI CreateFileMappingNuma( _In_ HANDLE hFile, _In_opt_ LPSECURITY_ATTRIBUTES lpFileMappingAttributes, _In_ DWORD flProtect, _In_ DWORD
		// dwMaximumSizeHigh, _In_ DWORD dwMaximumSizeLow, _In_opt_ LPCTSTR lpName, _In_ DWORD nndPreferred);
		[DllImport(Lib.Kernel32, SetLastError = true, CharSet = CharSet.Auto)]
		[PInvokeData("WinBase.h", MSDNShortId = "aa366539")]
		public static extern SafeHFILE CreateFileMappingNuma([In] HFILE hFile, [In] SECURITY_ATTRIBUTES lpFileMappingAttributes, MEM_PROTECTION flProtect,
			uint dwMaximumSizeHigh, uint dwMaximumSizeLow, [In] string lpName, uint nndPreferred);

		/// <summary>
		/// <para>Creates a memory resource notification object.</para>
		/// </summary>
		/// <param name="NotificationType">
		/// <para>
		/// The memory condition under which the object is to be signaled. This parameter can be one of the following values from the
		/// <c>MEMORY_RESOURCE_NOTIFICATION_TYPE</c> enumeration.
		/// </para>
		/// <para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>LowMemoryResourceNotification0</term>
		/// <term>Available physical memory is running low.</term>
		/// </item>
		/// <item>
		/// <term>HighMemoryResourceNotification1</term>
		/// <term>Available physical memory is high.</term>
		/// </item>
		/// </list>
		/// </para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is a handle to a memory resource notification object.</para>
		/// <para>If the function fails, the return value is <c>NULL</c>. To get extended information, call <c>GetLastError</c>.</para>
		/// </returns>
		// HANDLE WINAPI CreateMemoryResourceNotification( _In_ MEMORY_RESOURCE_NOTIFICATION_TYPE NotificationType);
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("WinBase.h", MSDNShortId = "aa366541")]
		public static extern SafeHFILE CreateMemoryResourceNotification(MEMORY_RESOURCE_NOTIFICATION_TYPE NotificationType);

		/// <summary>
		/// Discards the memory contents of a range of memory pages, without decommitting the memory. The contents of discarded memory is undefined and must be
		/// rewritten by the application.
		/// </summary>
		/// <param name="VirtualAddress">Page-aligned starting address of the memory to discard.</param>
		/// <param name="Size">Size, in bytes, of the memory region to discard. Size must be an integer multiple of the system page size.</param>
		/// <returns>ERROR_SUCCESS if successful; a System Error Code otherwise.</returns>
		// DWORD WINAPI DiscardVirtualMemory( _In_ PVOID VirtualAddress, _In_ SIZE_T Size);
		[DllImport(Lib.Kernel32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("WinBase.h", MSDNShortId = "dn781432")]
		public static extern uint DiscardVirtualMemory(IntPtr VirtualAddress, SizeT Size);

		/// <summary>Writes to the disk a byte range within a mapped view of a file.</summary>
		/// <param name="lpBaseAddress">A pointer to the base address of the byte range to be flushed to the disk representation of the mapped file.</param>
		/// <param name="dwNumberOfBytesToFlush">
		/// The number of bytes to be flushed. If dwNumberOfBytesToFlush is zero, the file is flushed from the base address to the end of the mapping.
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is nonzero.</para>
		/// <para>If the function fails, the return value is zero. To get extended error information, call <c>GetLastError</c>.</para>
		/// </returns>
		// BOOL WINAPI FlushViewOfFile( _In_ LPCVOID lpBaseAddress, _In_ SIZE_T dwNumberOfBytesToFlush);
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("WinBase.h", MSDNShortId = "aa366563")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool FlushViewOfFile([In] IntPtr lpBaseAddress, SizeT dwNumberOfBytesToFlush);

		/// <summary>
		/// <para>
		/// Frees physical memory pages that are allocated previously by using <c>AllocateUserPhysicalPages</c> or <c>AllocateUserPhysicalPagesNuma</c>. If any
		/// of these pages are currently mapped in the Address Windowing Extensions (AWE) region, they are automatically unmapped by this call. This does not
		/// affect the virtual address space that is occupied by a specified Address Windowing Extensions (AWE) region.
		/// </para>
		/// <para>
		/// <c>64-bit Windows on Itanium-based systems:</c> Due to the difference in page sizes, <c>FreeUserPhysicalPages</c> is not supported for 32-bit applications.
		/// </para>
		/// </summary>
		/// <param name="hProcess">
		/// <para>The handle to a process.</para>
		/// <para>The function frees memory within the virtual address space of this process.</para>
		/// </param>
		/// <param name="NumberOfPages">
		/// <para>The size of the physical memory to free, in pages.</para>
		/// <para>On return, if the function fails, this parameter indicates the number of pages that are freed.</para>
		/// </param>
		/// <param name="UserPfnArray">A pointer to an array of page frame numbers of the allocated memory to be freed.</param>
		/// <returns>
		/// <para>If the function succeeds, the return value is <c>TRUE</c>.</para>
		/// <para>
		/// If the function fails, the return value is <c>FALSE</c>. In this case, the NumberOfPages parameter reflect how many pages have actually been
		/// released. To get extended error information, call <c>GetLastError</c>.
		/// </para>
		/// </returns>
		// BOOL WINAPI FreeUserPhysicalPages( _In_ HANDLE hProcess, _Inout_ PULONG_PTR NumberOfPages, _In_ PULONG_PTR UserPfnArray);
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("WinBase.h", MSDNShortId = "aa366566")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool FreeUserPhysicalPages([In] IntPtr hProcess, ref SizeT NumberOfPages, [In] IntPtr UserPfnArray);

		/// <summary>Retrieves the minimum size of a large page.</summary>
		/// <returns>
		/// <para>If the processor supports large pages, the return value is the minimum size of a large page.</para>
		/// <para>If the processor does not support large pages, the return value is zero.</para>
		/// </returns>
		// SIZE_T WINAPI GetLargePageMinimum(void);
		[DllImport(Lib.Kernel32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("WinBase.h", MSDNShortId = "aa366568")]
		public static extern SizeT GetLargePageMinimum();

		/// <summary>Gets the memory error handling capabilities of the system.</summary>
		/// <param name="Capabilities">
		/// <para>A <c>PULONG</c> that receives one or more of the following flags.</para>
		/// <para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>MEHC_PATROL_SCRUBBER_PRESENT = 1</term>
		/// <term>The hardware can detect and report failed memory.</term>
		/// </item>
		/// </list>
		/// </para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is nonzero.</para>
		/// <para>If the function fails, the return value is zero. To get extended error information, call <c>GetLastError</c>.</para>
		/// </returns>
		// BOOL WINAPI GetMemoryErrorHandlingCapabilities( _Out_ PULONG Capabilities);
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("WinBase.h", MSDNShortId = "hh691012")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool GetMemoryErrorHandlingCapabilities(out uint Capabilities);

		/// <summary>Retrieves the minimum and maximum working set sizes of the specified process.</summary>
		/// <param name="hProcess">
		/// <para>
		/// A handle to the process whose working set sizes will be obtained. The handle must have the <c>PROCESS_QUERY_INFORMATION</c> or
		/// <c>PROCESS_QUERY_LIMITED_INFORMATION</c> access right. For more information, see Process Security and Access Rights.
		/// </para>
		/// <para><c>Windows Server 2003 and Windows XP:</c> The handle must have the <c>PROCESS_QUERY_INFORMATION</c> access right.</para>
		/// </param>
		/// <param name="lpMinimumWorkingSetSize">
		/// A pointer to a variable that receives the minimum working set size of the specified process, in bytes. The virtual memory manager attempts to keep at
		/// least this much memory resident in the process whenever the process is active.
		/// </param>
		/// <param name="lpMaximumWorkingSetSize">
		/// A pointer to a variable that receives the maximum working set size of the specified process, in bytes. The virtual memory manager attempts to keep no
		/// more than this much memory resident in the process whenever the process is active when memory is in short supply.
		/// </param>
		/// <param name="Flags">The flags that control the enforcement of the minimum and maximum working set sizes.</param>
		/// <returns>
		/// <para>If the function succeeds, the return value is nonzero.</para>
		/// <para>If the function fails, the return value is zero. To get extended error information, call <c>GetLastError</c>.</para>
		/// </returns>
		// BOOL WINAPI GetProcessWorkingSetSize( _In_ HANDLE hProcess, _Out_ PSIZE_T lpMinimumWorkingSetSize, _Out_ PSIZE_T lpMaximumWorkingSetSize);
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("WinBase.h", MSDNShortId = "ms683226")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool GetProcessWorkingSetSizeEx([In] IntPtr hProcess, [Out] out SizeT lpMinimumWorkingSetSize, [Out] out SizeT lpMaximumWorkingSetSize, out QUOTA_LIMITS_HARDWS Flags);

		/// <summary>Retrieves the current size limits for the working set of the system cache.</summary>
		/// <param name="lpMinimumFileCacheSize">
		/// A pointer to a variable that receives the minimum size of the file cache, in bytes. The virtual memory manager attempts to keep at least this much
		/// memory resident in the system file cache, if there is a previous call to the <c>SetSystemFileCacheSize</c> function with the
		/// <c>FILE_CACHE_MIN_HARD_ENABLE</c> flag.
		/// </param>
		/// <param name="lpMaximumFileCacheSize">
		/// A pointer to a variable that receives the maximum size of the file cache, in bytes. The virtual memory manager enforces this limit only if there is a
		/// previous call to <c>SetSystemFileCacheSize</c> with the <c>FILE_CACHE_MAX_HARD_ENABLE</c> flag.
		/// </param>
		/// <param name="lpFlags">
		/// <para>The flags that indicate which of the file cache limits are enabled.</para>
		/// <para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>FILE_CACHE_MAX_HARD_ENABLE = 0x1</term>
		/// <term>The maximum size limit is enabled. If this flag is not present, this limit is disabled.</term>
		/// </item>
		/// <item>
		/// <term>FILE_CACHE_MIN_HARD_ENABLE = 0x4</term>
		/// <term>The minimum size limit is enabled. If this flag is not present, this limit is disabled.</term>
		/// </item>
		/// </list>
		/// </para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is a nonzero value.</para>
		/// <para>If the function fails, the return value is 0 (zero). To get extended error information, call <c>GetLastError</c>.</para>
		/// </returns>
		// BOOL WINAPI GetSystemFileCacheSize( _Out_ PSIZE_T lpMinimumFileCacheSize, _Out_ PSIZE_T lpMaximumFileCacheSize, _Out_ PDWORD lpFlags);
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("WinBase.h", MSDNShortId = "aa965224")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool GetSystemFileCacheSize(out SizeT lpMinimumFileCacheSize, out SizeT lpMaximumFileCacheSize, out FILE_CACHE_LIMITS lpFlags);

		/// <summary>
		/// <para>Retrieves the addresses of the pages that are written to in a region of virtual memory.</para>
		/// <para><c>64-bit Windows on Itanium-based systems:</c> Due to the difference in page sizes, <c>GetWriteWatch</c> is not supported for 32-bit applications.</para>
		/// </summary>
		/// <param name="dwFlags">
		/// <para>Indicates whether the function resets the write-tracking state.</para>
		/// <para>
		/// To reset the write-tracking state, set this parameter to <c>WRITE_WATCH_FLAG_RESET</c>. If this parameter is 0 (zero), <c>GetWriteWatch</c> does not
		/// reset the write-tracking state. For more information, see the Remarks section of this topic.
		/// </para>
		/// </param>
		/// <param name="lpBaseAddress">
		/// <para>The base address of the memory region for which to retrieve write-tracking information.</para>
		/// <para>This address must be in a memory region that is allocated by the <c>VirtualAlloc</c> function using <c>MEM_WRITE_WATCH</c>.</para>
		/// </param>
		/// <param name="dwRegionSize">The size of the memory region for which to retrieve write-tracking information, in bytes.</param>
		/// <param name="lpAddresses">
		/// <para>A pointer to a buffer that receives an array of page addresses in the memory region.</para>
		/// <para>The addresses indicate the pages that have been written to since the region has been allocated or the write-tracking state has been reset.</para>
		/// </param>
		/// <param name="lpdwCount">
		/// <para>On input, this variable indicates the size of the lpAddresses array, in array elements.</para>
		/// <para>On output, the variable receives the number of page addresses that are returned in the array.</para>
		/// </param>
		/// <param name="lpdwGranularity">A pointer to a variable that receives the page size, in bytes.</param>
		/// <returns>
		/// <para>If the function succeeds, the return value is 0 (zero).</para>
		/// <para>If the function fails, the return value is a nonzero value.</para>
		/// </returns>
		// UINT WINAPI GetWriteWatch( _In_ DWORD dwFlags, _In_ PVOID lpBaseAddress, _In_ SIZE_T dwRegionSize, _Out_ PVOID *lpAddresses, _Inout_ PULONG_PTR
		// lpdwCount, _Out_ PULONG lpdwGranularity);
		[DllImport(Lib.Kernel32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("WinBase.h", MSDNShortId = "aa366573")]
		public static extern uint GetWriteWatch(WRITE_WATCH dwFlags, [In] IntPtr lpBaseAddress, SizeT dwRegionSize, out IntPtr lpAddresses, ref UIntPtr lpdwCount, [Out] out uint lpdwGranularity);

		/// <summary>
		/// <para>Maps previously allocated physical memory pages at a specified address in an Address Windowing Extensions (AWE) region.</para>
		/// <para>To perform batch mapping and unmapping of multiple regions, use the <c>MapUserPhysicalPagesScatter</c> function.</para>
		/// <para>
		/// <c>64-bit Windows on Itanium-based systems:</c> Due to the difference in page sizes, <c>MapUserPhysicalPages</c> is not supported for 32-bit applications.
		/// </para>
		/// </summary>
		/// <param name="lpAddress">
		/// <para>A pointer to the starting address of the region of memory to remap.</para>
		/// <para>
		/// The value of lpAddress must be within the address range that the <c>VirtualAlloc</c> function returns when the Address Windowing Extensions (AWE)
		/// region is allocated.
		/// </para>
		/// </param>
		/// <param name="NumberOfPages">
		/// <para>The size of the physical memory and virtual address space for which to establish translations, in pages.</para>
		/// <para>The virtual address range is contiguous starting at lpAddress. The physical frames are specified by the UserPfnArray.</para>
		/// <para>The total number of pages cannot extend from the starting address beyond the end of the range that is specified in <c>AllocateUserPhysicalPages</c>.</para>
		/// </param>
		/// <param name="UserPfnArray">
		/// <para>A pointer to an array of physical page frame numbers.</para>
		/// <para>
		/// These frames are mapped by the argument lpAddress on return from this function. The size of the memory that is allocated should be at least the
		/// NumberOfPages times the size of the data type <c>ULONG_PTR</c>.
		/// </para>
		/// <para>
		/// Do not attempt to modify this buffer. It contains operating system data, and corruption could be catastrophic. The information in the buffer is not
		/// useful to an application.
		/// </para>
		/// <para>
		/// If this parameter is <c>NULL</c>, the specified address range is unmapped. Also, the specified physical pages are not freed, and you must call
		/// <c>FreeUserPhysicalPages</c> to free them.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is <c>TRUE</c>.</para>
		/// <para>
		/// If the function fails, the return value is <c>FALSE</c> and no mapping is done—partial or otherwise. To get extended error information, call <c>GetLastError</c>.
		/// </para>
		/// </returns>
		// BOOL WINAPI MapUserPhysicalPages( _In_ PVOID lpAddress, _In_ ULONG_PTR NumberOfPages, _In_ PULONG_PTR UserPfnArray);
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("WinBase.h", MSDNShortId = "aa366753")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool MapUserPhysicalPages([In] IntPtr lpAddress, ref SizeT NumberOfPages, [In] IntPtr UserPfnArray);

		/// <summary>
		/// <para>Maps a view of a file mapping into the address space of a calling process.</para>
		/// <para>To specify a suggested base address for the view, use the <c>MapViewOfFileEx</c> function. However, this practice is not recommended.</para>
		/// </summary>
		/// <param name="hFileMappingObject">
		/// A handle to a file mapping object. The <c>CreateFileMapping</c> and <c>OpenFileMapping</c> functions return this handle.
		/// </param>
		/// <param name="dwDesiredAccess">
		/// <para>The type of access to a file mapping object, which determines the protection of the pages. This parameter can be one of the following values.</para>
		/// <para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>FILE_MAP_ALL_ACCESS</term>
		/// <term>
		/// A read/write view of the file is mapped. The file mapping object must have been created with PAGE_READWRITE or PAGE_EXECUTE_READWRITE protection.When
		/// used with the MapViewOfFile function, FILE_MAP_ALL_ACCESS is equivalent to FILE_MAP_WRITE.
		/// </term>
		/// </item>
		/// <item>
		/// <term>FILE_MAP_COPY</term>
		/// <term>
		/// A copy-on-write view of the file is mapped. The file mapping object must have been created with PAGE_READONLY, PAGE_READ_EXECUTE, PAGE_WRITECOPY,
		/// PAGE_EXECUTE_WRITECOPY, PAGE_READWRITE, or PAGE_EXECUTE_READWRITE protection.When a process writes to a copy-on-write page, the system copies the
		/// original page to a new page that is private to the process. The new page is backed by the paging file. The protection of the new page changes from
		/// copy-on-write to read/write.When copy-on-write access is specified, the system and process commit charge taken is for the entire view because the
		/// calling process can potentially write to every page in the view, making all pages private. The contents of the new page are never written back to the
		/// original file and are lost when the view is unmapped.
		/// </term>
		/// </item>
		/// <item>
		/// <term>FILE_MAP_READ</term>
		/// <term>
		/// A read-only view of the file is mapped. An attempt to write to the file view results in an access violation.The file mapping object must have been
		/// created with PAGE_READONLY, PAGE_READWRITE, PAGE_EXECUTE_READ, or PAGE_EXECUTE_READWRITE protection.
		/// </term>
		/// </item>
		/// <item>
		/// <term>FILE_MAP_WRITE</term>
		/// <term>
		/// A read/write view of the file is mapped. The file mapping object must have been created with PAGE_READWRITE or PAGE_EXECUTE_READWRITE protection.When
		/// used with MapViewOfFile, (FILE_MAP_WRITE | FILE_MAP_READ) and FILE_MAP_ALL_ACCESS are equivalent to FILE_MAP_WRITE.
		/// </term>
		/// </item>
		/// </list>
		/// </para>
		/// <para>Each of the preceding values can be combined with the following value.</para>
		/// <para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>FILE_MAP_EXECUTE</term>
		/// <term>
		/// An executable view of the file is mapped (mapped memory can be run as code). The file mapping object must have been created with PAGE_EXECUTE_READ,
		/// PAGE_EXECUTE_WRITECOPY, or PAGE_EXECUTE_READWRITE protection.Windows Server 2003 and Windows XP: This value is available starting with Windows XP
		/// with SP2 and Windows Server 2003 with SP1.
		/// </term>
		/// </item>
		/// </list>
		/// </para>
		/// <para>
		/// For file mapping objects created with the <c>SEC_IMAGE</c> attribute, the dwDesiredAccess parameter has no effect and should be set to any valid
		/// value such as <c>FILE_MAP_READ</c>.
		/// </para>
		/// <para>For more information about access to file mapping objects, see File Mapping Security and Access Rights.</para>
		/// </param>
		/// <param name="dwFileOffsetHigh">A high-order <c>DWORD</c> of the file offset where the view begins.</param>
		/// <param name="dwFileOffsetLow">
		/// A low-order <c>DWORD</c> of the file offset where the view is to begin. The combination of the high and low offsets must specify an offset within the
		/// file mapping. They must also match the memory allocation granularity of the system. That is, the offset must be a multiple of the allocation
		/// granularity. To obtain the memory allocation granularity of the system, use the <c>GetSystemInfo</c> function, which fills in the members of a
		/// <c>SYSTEM_INFO</c> structure.
		/// </param>
		/// <param name="dwNumberOfBytesToMap">
		/// The number of bytes of a file mapping to map to the view. All bytes must be within the maximum size specified by <c>CreateFileMapping</c>. If this
		/// parameter is 0 (zero), the mapping extends from the specified offset to the end of the file mapping.
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is the starting address of the mapped view.</para>
		/// <para>If the function fails, the return value is <c>NULL</c>. To get extended error information, call <c>GetLastError</c>.</para>
		/// </returns>
		// LPVOID WINAPI MapViewOfFile( _In_ HANDLE hFileMappingObject, _In_ DWORD dwDesiredAccess, _In_ DWORD dwFileOffsetHigh, _In_ DWORD dwFileOffsetLow, _In_
		// SIZE_T dwNumberOfBytesToMap);
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("WinBase.h", MSDNShortId = "aa366761")]
		public static extern IntPtr MapViewOfFile([In] HFILE hFileMappingObject, FILE_MAP dwDesiredAccess, uint dwFileOffsetHigh, uint dwFileOffsetLow, uint dwNumberOfBytesToMap);

		/// <summary>
		/// <para>
		/// Maps a view of a file mapping into the address space of a calling process. A caller can optionally specify a suggested base memory address for the view.
		/// </para>
		/// <para>To specify the NUMA node for the physical memory, see <c>MapViewOfFileExNuma</c>.</para>
		/// </summary>
		/// <param name="hFileMappingObject">
		/// A handle to a file mapping object. The <c>CreateFileMapping</c> and <c>OpenFileMapping</c> functions return this handle.
		/// </param>
		/// <param name="dwDesiredAccess">
		/// <para>
		/// The type of access to a file mapping object, which determines the page protection of the pages. This parameter can be one of the following values.
		/// </para>
		/// <para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>FILE_MAP_ALL_ACCESS</term>
		/// <term>
		/// A read/write view of the file is mapped. The file mapping object must have been created with PAGE_READWRITE or PAGE_EXECUTE_READWRITE protection.When
		/// used with the MapViewOfFileEx function, FILE_MAP_ALL_ACCESS is equivalent to FILE_MAP_WRITE.
		/// </term>
		/// </item>
		/// <item>
		/// <term>FILE_MAP_COPY</term>
		/// <term>
		/// A copy-on-write view of the file is mapped. The file mapping object must have been created with PAGE_READONLY, PAGE_READ_EXECUTE, PAGE_WRITECOPY,
		/// PAGE_EXECUTE_WRITECOPY, PAGE_READWRITE, or PAGE_EXECUTE_READWRITE protection.When a process writes to a copy-on-write page, the system copies the
		/// original page to a new page that is private to the process. The new page is backed by the paging file. The protection of the new page changes from
		/// copy-on-write to read/write.When copy-on-write access is specified, the system and process commit charge taken is for the entire view because the
		/// calling process can potentially write to every page in the view, making all pages private. The contents of the new page are never written back to the
		/// original file and are lost when the view is unmapped.
		/// </term>
		/// </item>
		/// <item>
		/// <term>FILE_MAP_READ</term>
		/// <term>
		/// A read-only view of the file is mapped. An attempt to write to the file view results in an access violation.The file mapping object must have been
		/// created with PAGE_READONLY, PAGE_READWRITE, PAGE_EXECUTE_READ, or PAGE_EXECUTE_READWRITE protection.
		/// </term>
		/// </item>
		/// <item>
		/// <term>FILE_MAP_WRITE</term>
		/// <term>
		/// A read/write view of the file is mapped. The file mapping object must have been created with PAGE_READWRITE or PAGE_EXECUTE_READWRITE protection.When
		/// used with MapViewOfFileEx, (FILE_MAP_WRITE | FILE_MAP_READ) and FILE_MAP_ALL_ACCESS are equivalent to FILE_MAP_WRITE.
		/// </term>
		/// </item>
		/// </list>
		/// </para>
		/// <para>Each of the preceding values can be combined with the following value.</para>
		/// <para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>FILE_MAP_EXECUTE</term>
		/// <term>
		/// An executable view of the file is mapped (mapped memory can be run as code). The file mapping object must have been created with PAGE_EXECUTE_READ,
		/// PAGE_EXECUTE_WRITECOPY, or PAGE_EXECUTE_READWRITE protection.Windows Server 2003 and Windows XP: This value is available starting with Windows XP
		/// with SP2 and Windows Server 2003 with SP1.
		/// </term>
		/// </item>
		/// </list>
		/// </para>
		/// <para>
		/// For file mapping objects created with the <c>SEC_IMAGE</c> attribute, the dwDesiredAccess parameter has no effect and should be set to any valid
		/// value such as <c>FILE_MAP_READ</c>.
		/// </para>
		/// <para>For more information about access to file mapping objects, see File Mapping Security and Access Rights.</para>
		/// </param>
		/// <param name="dwFileOffsetHigh">The high-order <c>DWORD</c> of the file offset where the view is to begin.</param>
		/// <param name="dwFileOffsetLow">
		/// The low-order <c>DWORD</c> of the file offset where the view is to begin. The combination of the high and low offsets must specify an offset within
		/// the file mapping. They must also match the memory allocation granularity of the system. That is, the offset must be a multiple of the allocation
		/// granularity. To obtain the memory allocation granularity of the system, use the <c>GetSystemInfo</c> function, which fills in the members of a
		/// <c>SYSTEM_INFO</c> structure.
		/// </param>
		/// <param name="dwNumberOfBytesToMap">
		/// The number of bytes of a file mapping to map to a view. All bytes must be within the maximum size specified by <c>CreateFileMapping</c>. If this
		/// parameter is 0 (zero), the mapping extends from the specified offset to the end of the file mapping.
		/// </param>
		/// <param name="lpBaseAddress">
		/// <para>
		/// A pointer to the memory address in the calling process address space where mapping begins. This must be a multiple of the system's memory allocation
		/// granularity, or the function fails. To determine the memory allocation granularity of the system, use the <c>GetSystemInfo</c> function. If there is
		/// not enough address space at the specified address, the function fails.
		/// </para>
		/// <para>
		/// If lpBaseAddress is <c>NULL</c>, the operating system chooses the mapping address. In this scenario, the function is equivalent to the
		/// <c>MapViewOfFile</c> function.
		/// </para>
		/// <para>
		/// While it is possible to specify an address that is safe now (not used by the operating system), there is no guarantee that the address will remain
		/// safe over time. Therefore, it is better to let the operating system choose the address. In this case, you would not store pointers in the memory
		/// mapped file, you would store offsets from the base of the file mapping so that the mapping can be used at any address.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is the starting address of the mapped view.</para>
		/// <para>If the function fails, the return value is <c>NULL</c>. To get extended error information, call <c>GetLastError</c>.</para>
		/// </returns>
		// LPVOID WINAPI MapViewOfFileEx( _In_ HANDLE hFileMappingObject, _In_ DWORD dwDesiredAccess, _In_ DWORD dwFileOffsetHigh, _In_ DWORD dwFileOffsetLow,
		// _In_ SIZE_T dwNumberOfBytesToMap, _In_opt_ LPVOID lpBaseAddress);
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("WinBase.h", MSDNShortId = "aa366763")]
		public static extern IntPtr MapViewOfFileEx([In] HFILE hFileMappingObject, FILE_MAP dwDesiredAccess, uint dwFileOffsetHigh, uint dwFileOffsetLow, uint dwNumberOfBytesToMap,
			[In] IntPtr lpBaseAddress);

		/// <summary>Maps a view of a file mapping into the address space of a calling Windows Store app.</summary>
		/// <param name="hFileMappingObject">A handle to a file mapping object. The <c>CreateFileMappingFromApp</c> function returns this handle.</param>
		/// <param name="DesiredAccess">
		/// <para>The type of access to a file mapping object, which determines the protection of the pages. This parameter can be one of the following values.</para>
		/// <para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>FILE_MAP_ALL_ACCESS</term>
		/// <term>
		/// A read/write view of the file is mapped. The file mapping object must have been created with PAGE_READWRITE protection.When used with the
		/// MapViewOfFileFromApp function, FILE_MAP_ALL_ACCESS is equivalent to FILE_MAP_WRITE.
		/// </term>
		/// </item>
		/// <item>
		/// <term>FILE_MAP_COPY</term>
		/// <term>
		/// A copy-on-write view of the file is mapped. The file mapping object must have been created with PAGE_READONLY, PAGE_READ_EXECUTE, PAGE_WRITECOPY, or
		/// PAGE_READWRITE protection.When a process writes to a copy-on-write page, the system copies the original page to a new page that is private to the
		/// process. The new page is backed by the paging file. The protection of the new page changes from copy-on-write to read/write.When copy-on-write access
		/// is specified, the system and process commit charge taken is for the entire view because the calling process can potentially write to every page in
		/// the view, making all pages private. The contents of the new page are never written back to the original file and are lost when the view is unmapped.
		/// </term>
		/// </item>
		/// <item>
		/// <term>FILE_MAP_READ</term>
		/// <term>
		/// A read-only view of the file is mapped. An attempt to write to the file view results in an access violation.The file mapping object must have been
		/// created with PAGE_READONLY, PAGE_READWRITE, PAGE_EXECUTE_READ, or PAGE_EXECUTE_READWRITE protection.
		/// </term>
		/// </item>
		/// <item>
		/// <term>FILE_MAP_WRITE</term>
		/// <term>
		/// A read/write view of the file is mapped. The file mapping object must have been created with PAGE_READWRITE protection.When used with
		/// MapViewOfFileFromApp, (FILE_MAP_WRITE | FILE_MAP_READ) and FILE_MAP_ALL_ACCESS are equivalent to FILE_MAP_WRITE.
		/// </term>
		/// </item>
		/// </list>
		/// </para>
		/// <para>For more information about access to file mapping objects, see File Mapping Security and Access Rights.</para>
		/// </param>
		/// <param name="FileOffset">
		/// The file offset where the view is to begin. The offset must specify an offset within the file mapping. They must also match the memory allocation
		/// granularity of the system. That is, the offset must be a multiple of the allocation granularity. To obtain the memory allocation granularity of the
		/// system, use the <c>GetSystemInfo</c> function, which fills in the members of a <c>SYSTEM_INFO</c> structure.
		/// </param>
		/// <param name="NumberOfBytesToMap">
		/// The number of bytes of a file mapping to map to the view. All bytes must be within the maximum size specified by <c>CreateFileMappingFromApp</c>. If
		/// this parameter is 0 (zero), the mapping extends from the specified offset to the end of the file mapping.
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is the starting address of the mapped view.</para>
		/// <para>If the function fails, the return value is <c>NULL</c>. To get extended error information, call <c>GetLastError</c>.</para>
		/// </returns>
		// PVOID WINAPI MapViewOfFileFromApp( _In_ HANDLE hFileMappingObject, _In_ ULONG DesiredAccess, _In_ ULONG64 FileOffset, _In_ SIZE_T NumberOfBytesToMap);
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("MemoryApi.h", MSDNShortId = "hh994454")]
		public static extern IntPtr MapViewOfFileFromApp([In] HFILE hFileMappingObject, FILE_MAP DesiredAccess, ulong FileOffset, SizeT NumberOfBytesToMap);

		/// <summary>Maps a view of a file or a pagefile-backed section into the address space of the specified process.</summary>
		/// <param name="FileMappingHandle">A <c>HANDLE</c> to a section that is to be mapped into the address space of the specified process.</param>
		/// <param name="ProcessHandle">A <c>HANDLE</c> to a process into which the section will be mapped.</param>
		/// <param name="Offset">The offset from the beginning of the section. This must be 64k aligned.</param>
		/// <param name="BaseAddress">
		/// The desired base address of the view. The address is rounded down to the nearest 64k boundary. If this parameter is <c>NULL</c>, the system picks the
		/// base address.
		/// </param>
		/// <param name="ViewSize">The number of bytes to map. A value of zero (0) specifies that the entire section is to be mapped.</param>
		/// <param name="AllocationType">The type of allocation. This parameter can be zero (0) or one of the following constant values:</param>
		/// <param name="PageProtection">The desired page protection.</param>
		/// <param name="PreferredNode">The preferred NUMA node for this memory.</param>
		/// <returns>
		/// Returns the base address of the mapped view, if successful. Otherwise, returns <c>NULL</c> and extended error status is available using <c>GetLastError</c>.
		/// </returns>
		// PVOID WINAPI MapViewOfFileNuma2( _In_ HANDLE FileMappingHandle, _In_ HANDLE ProcessHandle, _In_ ULONG64 Offset, _In_opt_ PVOID BaseAddress, _In_
		// SIZE_T ViewSize, _In_ ULONG AllocationType, _In_ ULONG PageProtection, _In_ ULONG PreferredNode);
		[DllImport("Api-ms-win-core-memory-l1-1-5.dll", SetLastError = true, ExactSpelling = true)]
		[PInvokeData("WinBase.h", MSDNShortId = "mt492558")]
		public static extern IntPtr MapViewOfFileNuma2([In] HFILE FileMappingHandle, [In] IntPtr ProcessHandle, ulong Offset, IntPtr BaseAddress, SizeT ViewSize,
			MEM_ALLOCATION_TYPE AllocationType, MEM_PROTECTION PageProtection, uint PreferredNode);

		/// <summary>
		/// <para>
		/// Indicates that the data contained in a range of memory pages is no longer needed by the application and can be discarded by the system if necessary.
		/// </para>
		/// <para>The specified pages will be marked as inaccessible, removed from the process working set, and will not be written to the paging file.</para>
		/// <para>To later reclaim offered pages, call <c>ReclaimVirtualMemory</c>.</para>
		/// </summary>
		/// <param name="VirtualAddress">Page-aligned starting address of the memory to offer.</param>
		/// <param name="Size">Size, in bytes, of the memory region to offer. Size must be an integer multiple of the system page size.</param>
		/// <param name="Priority">
		/// <para>
		/// Priority indicates how important the offered memory is to the application. A higher priority increases the probability that the offered memory can be
		/// reclaimed intact when calling <c>ReclaimVirtualMemory</c>. The system typically discards lower priority memory before discarding higher priority
		/// memory. Priority must be one of the following values.
		/// </para>
		/// <para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>VMOfferPriorityVeryLow0x00001000</term>
		/// <term>The offered memory is very low priority, and should be the first discarded.</term>
		/// </item>
		/// <item>
		/// <term>VMOfferPriorityLow0x00002000</term>
		/// <term>The offered memory is low priority.</term>
		/// </item>
		/// <item>
		/// <term>VMOfferPriorityBelowNormal0x00002000</term>
		/// <term>The offered memory is below normal priority.</term>
		/// </item>
		/// <item>
		/// <term>VMOfferPriorityNormal0x00002000</term>
		/// <term>The offered memory is of normal priority to the application, and should be the last discarded.</term>
		/// </item>
		/// </list>
		/// </para>
		/// </param>
		/// <returns>ERROR_SUCCESS if successful; a System Error Code otherwise.</returns>
		// DWORD WINAPI OfferVirtualMemory( _In_ PVOID VirtualAddress, _In_ SIZE_T Size, _In_ OFFER_PRIORITY Priority);
		[DllImport(Lib.Kernel32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("WinBase.h", MSDNShortId = "dn781436")]
		public static extern uint OfferVirtualMemory(IntPtr VirtualAddress, SizeT Size, OFFER_PRIORITY Priority);

		/// <summary>Opens a named file mapping object.</summary>
		/// <param name="dwDesiredAccess">
		/// The access to the file mapping object. This access is checked against any security descriptor on the target file mapping object. For a list of
		/// values, see File Mapping Security and Access Rights.
		/// </param>
		/// <param name="bInheritHandle">
		/// If this parameter is <c>TRUE</c>, a process created by the <c>CreateProcess</c> function can inherit the handle; otherwise, the handle cannot be inherited.
		/// </param>
		/// <param name="lpName">
		/// The name of the file mapping object to be opened. If there is an open handle to a file mapping object by this name and the security descriptor on the
		/// mapping object does not conflict with the dwDesiredAccess parameter, the open operation succeeds. The name can have a "Global\" or "Local\" prefix to
		/// explicitly open an object in the global or session namespace. The remainder of the name can contain any character except the backslash character (\).
		/// For more information, see Kernel Object Namespaces. Fast user switching is implemented using Terminal Services sessions. The first user to log on
		/// uses session 0, the next user to log on uses session 1, and so on. Kernel object names must follow the guidelines outlined for Terminal Services so
		/// that applications can support multiple users.
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is an open handle to the specified file mapping object.</para>
		/// <para>If the function fails, the return value is <c>NULL</c>. To get extended error information, call <c>GetLastError</c>.</para>
		/// </returns>
		// HANDLE WINAPI OpenFileMapping( _In_ DWORD dwDesiredAccess, _In_ BOOL bInheritHandle, _In_ LPCTSTR lpName);
		[DllImport(Lib.Kernel32, SetLastError = true, CharSet = CharSet.Auto)]
		[PInvokeData("WinBase.h", MSDNShortId = "aa366791")]
		public static extern SafeHFILE OpenFileMapping(FILE_MAP dwDesiredAccess, [MarshalAs(UnmanagedType.Bool)] bool bInheritHandle, [In] string lpName);

		/// <summary>Opens a named file mapping object.</summary>
		/// <param name="DesiredAccess">
		/// The access to the file mapping object. This access is checked against any security descriptor on the target file mapping object. For a list of
		/// values, see File Mapping Security and Access Rights. You can only open the file mapping object for <c>FILE_MAP_EXECUTE</c> access if your app has the
		/// <c>codeGeneration</c> capability.
		/// </param>
		/// <param name="InheritHandle">
		/// If this parameter is <c>TRUE</c>, a process created by the <c>CreateProcess</c> function can inherit the handle; otherwise, the handle cannot be inherited.
		/// </param>
		/// <param name="Name">
		/// The name of the file mapping object to be opened. If there is an open handle to a file mapping object by this name and the security descriptor on the
		/// mapping object does not conflict with the DesiredAccess parameter, the open operation succeeds. The name can have a "Global\" or "Local\" prefix to
		/// explicitly open an object in the global or session namespace. The remainder of the name can contain any character except the backslash character (\).
		/// For more information, see Kernel Object Namespaces. Fast user switching is implemented using Terminal Services sessions. The first user to log on
		/// uses session 0, the next user to log on uses session 1, and so on. Kernel object names must follow the guidelines outlined for Terminal Services so
		/// that applications can support multiple users.
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is an open handle to the specified file mapping object.</para>
		/// <para>If the function fails, the return value is <c>NULL</c>. To get extended error information, call <c>GetLastError</c>.</para>
		/// </returns>
		// HANDLE WINAPI OpenFileMappingFromApp( _In_ ULONG DesiredAccess, _In_ BOOL InheritHandle, _In_ PCWSTR Name);
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true, CharSet = CharSet.Unicode)]
		[PInvokeData("MemoryApi.h", MSDNShortId = "mt169844")]
		public static extern SafeHFILE OpenFileMappingFromApp(FILE_MAP DesiredAccess, [MarshalAs(UnmanagedType.Bool)] bool InheritHandle, string Name);

		/// <summary>Provides an efficient mechanism to bring into memory potentially discontiguous virtual address ranges in a process address space.</summary>
		/// <param name="hProcess">
		/// Handle to the process whose virtual address ranges are to be prefetched. Use the <c>GetCurrentProcess</c> function to use the current process.
		/// </param>
		/// <param name="NumberOfEntries">Number of entries in the array pointed to by the VirtualAddresses parameter.</param>
		/// <param name="VirtualAddresses">
		/// Pointer to an array of <c>WIN32_MEMORY_RANGE_ENTRY</c> structures which each specify a virtual address range to be prefetched. The virtual address
		/// ranges may cover any part of the process address space accessible by the target process.
		/// </param>
		/// <param name="Flags">Reserved. Must be 0.</param>
		/// <returns>
		/// <para>If the function succeeds, the return value is a nonzero value.</para>
		/// <para>If the function fails, the return value is 0 (zero). To get extended error information, call <c>GetLastError</c>.</para>
		/// </returns>
		// BOOL WINAPI PrefetchVirtualMemory( _In_ HANDLE hProcess, _In_ ULONG_PTR NumberOfEntries, _In_ PWIN32_MEMORY_RANGE_ENTRY VirtualAddresses, _In_ ULONG Flags);
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("WinBase.h", MSDNShortId = "hh780543")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool PrefetchVirtualMemory(IntPtr hProcess, UIntPtr NumberOfEntries, IntPtr VirtualAddresses, uint Flags);

		/// <summary>Retrieves the state of the specified memory resource object.</summary>
		/// <param name="ResourceNotificationHandle">
		/// A handle to a memory resource notification object. The <c>CreateMemoryResourceNotification</c> function returns this handle.
		/// </param>
		/// <param name="ResourceState">
		/// The memory pointed to by this parameter receives the state of the memory resource notification object. The value of this parameter is set to
		/// <c>TRUE</c> if the specified memory condition exists, and <c>FALSE</c> if the specified memory condition does not exist.
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is nonzero.</para>
		/// <para>If the function fails, the return value is zero. For more error information, call <c>GetLastError</c>.</para>
		/// </returns>
		// BOOL WINAPI QueryMemoryResourceNotification( _In_ HANDLE ResourceNotificationHandle, _Out_ PBOOL ResourceState);
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("WinBase.h", MSDNShortId = "aa366799")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool QueryMemoryResourceNotification([In] HFILE ResourceNotificationHandle, [Out, MarshalAs(UnmanagedType.Bool)] out bool ResourceState);

		/// <summary>
		/// The <c>QueryVirtualMemoryInformation</c> function returns information about a page or a set of pages within the virtual address space of the
		/// specified process.
		/// </summary>
		/// <param name="Process">A handle for the process in whose context the pages to be queried reside.</param>
		/// <param name="VirtualAddress">The address of the region of pages to be queried. This value is rounded down to the next host-page-address boundary.</param>
		/// <param name="MemoryInformationClass">The memory information class about which to retrieve information. The only supported value is <c>MemoryRegionInfo</c>.</param>
		/// <param name="MemoryInformation">
		/// <para>A pointer to a buffer that receives the specified information.</para>
		/// <para>
		/// If the MemoryInformationClass parameter has a value of <c>MemoryRegionInfo</c>, this parameter must point to a <c>WIN32_MEMORY_REGION_INFORMATION</c> structure.
		/// </para>
		/// </param>
		/// <param name="MemoryInformationSize">Specifies the length in bytes of the memory information buffer.</param>
		/// <param name="ReturnSize">An optional pointer which, if specified, receives the number of bytes placed in the memory information buffer.</param>
		/// <returns>Returns <c>TRUE</c> on success. Returns <c>FALSE</c> for failure. To get extended error information, call <c>GetLastError</c>.</returns>
		// BOOL WINAPI QueryVirtualMemoryInformation( _In_ HANDLE Process, _In_ const VOID *VirtualAddress, _In_ WIN32_MEMORY_INFORMATION_CLASS
		// MemoryInformationClass, _Out_ _writes_bytes_(MemoryInformationSize) PVOID MemoryInformation, _In_ SIZE_T MemoryInformationSize, _Out_opt_ PSIZE_T ReturnSize);
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("MemoryApi.h", MSDNShortId = "mt845761")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool QueryVirtualMemoryInformation([In] IntPtr Process, IntPtr VirtualAddress, WIN32_MEMORY_INFORMATION_CLASS MemoryInformationClass, IntPtr MemoryInformation, SizeT MemoryInformationSize, out SizeT ReturnSize);

		/// <summary>Reads data from an area of memory in a specified process. The entire area to be read must be accessible or the operation fails.</summary>
		/// <param name="hProcess">A handle to the process with memory that is being read. The handle must have PROCESS_VM_READ access to the process.</param>
		/// <param name="lpBaseAddress">
		/// A pointer to the base address in the specified process from which to read. Before any data transfer occurs, the system verifies that all data in the
		/// base address and memory of the specified size is accessible for read access, and if it is not accessible the function fails.
		/// </param>
		/// <param name="lpBuffer">A pointer to a buffer that receives the contents from the address space of the specified process.</param>
		/// <param name="nSize">The number of bytes to be read from the specified process.</param>
		/// <param name="lpNumberOfBytesRead">
		/// A pointer to a variable that receives the number of bytes transferred into the specified buffer. If lpNumberOfBytesRead is <c>NULL</c>, the parameter
		/// is ignored.
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is nonzero.</para>
		/// <para>If the function fails, the return value is 0 (zero). To get extended error information, call <c>GetLastError</c>.</para>
		/// <para>The function fails if the requested read operation crosses into an area of the process that is inaccessible.</para>
		/// </returns>
		// BOOL WINAPI ReadProcessMemory( _In_ HANDLE hProcess, _In_ LPCVOID lpBaseAddress, _Out_ LPVOID lpBuffer, _In_ SIZE_T nSize, _Out_ SIZE_T *lpNumberOfBytesRead);
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("WinBase.h", MSDNShortId = "ms680553")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool ReadProcessMemory([In] IntPtr hProcess, [In] IntPtr lpBaseAddress, IntPtr lpBuffer, SizeT nSize, out SizeT lpNumberOfBytesRead);

		/// <summary>
		/// <para>Reclaims a range of memory pages that were offered to the system with <c>OfferVirtualMemory</c>.</para>
		/// <para>
		/// If the offered memory has been discarded, the contents of the memory region is undefined and must be rewritten by the application. If the offered
		/// memory has not been discarded, it is reclaimed intact.
		/// </para>
		/// </summary>
		/// <param name="VirtualAddress">Page-aligned starting address of the memory to reclaim.</param>
		/// <param name="Size">Size, in bytes, of the memory region to reclaim. Size must be an integer multiple of the system page size.</param>
		/// <returns>
		/// <para>Returns ERROR_SUCCESS if successful and the memory was reclaimed intact.</para>
		/// <para>
		/// Returns ERROR_BUSY if successful but the memory was discarded and must be rewritten by the application. In this case, the contents of the memory
		/// region is undefined.
		/// </para>
		/// <para>Returns a System Error Code otherwise.</para>
		/// </returns>
		// DWORD WINAPI ReclaimVirtualMemory( _In_ PVOID VirtualAddress, _In_ SIZE_T Size);
		[DllImport(Lib.Kernel32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("WinBase.h", MSDNShortId = "dn781437")]
		public static extern uint ReclaimVirtualMemory(IntPtr VirtualAddress, SizeT Size);

		/// <summary>
		/// Registers a bad memory notification that is called when one or more bad memory pages are detected and the system cannot remove at least one of them
		/// (for example if the pages contains modified data that has not yet been written to the pagefile.)
		/// </summary>
		/// <param name="Callback">A pointer to the application-defined BadMemoryCallbackRoutine function to register.</param>
		/// <returns>
		/// Registration handle that represents the callback notification. Can be passed to the <c>UnregisterBadMemoryNotification</c> function when no longer needed.
		/// </returns>
		// PVOID WINAPI RegisterBadMemoryNotification( _In_ PBAD_MEMORY_CALLBACK_ROUTINE Callback);
		[DllImport(Lib.Kernel32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("WinBase.h", MSDNShortId = "hh691013")]
		public static extern IntPtr RegisterBadMemoryNotification(PBAD_MEMORY_CALLBACK_ROUTINE Callback);

		/// <summary>
		/// <para>
		/// Resets the write-tracking state for a region of virtual memory. Subsequent calls to the <c>GetWriteWatch</c> function only report pages that are
		/// written to since the reset operation.
		/// </para>
		/// <para><c>64-bit Windows on Itanium-based systems:</c> Due to the difference in page sizes, <c>ResetWriteWatch</c> is not supported for 32-bit applications.</para>
		/// </summary>
		/// <param name="lpBaseAddress">
		/// <para>A pointer to the base address of the memory region for which to reset the write-tracking state.</para>
		/// <para>This address must be in a memory region that is allocated by the <c>VirtualAlloc</c> function with <c>MEM_WRITE_WATCH</c>.</para>
		/// </param>
		/// <param name="dwRegionSize">The size of the memory region for which to reset the write-tracking information, in bytes.</param>
		/// <returns>
		/// <para>If the function succeeds, the return value is 0 (zero).</para>
		/// <para>If the function fails, the return value is a nonzero value.</para>
		/// </returns>
		// UINT WINAPI ResetWriteWatch( _In_ LPVOID lpBaseAddress, _In_ SIZE_T dwRegionSize);
		[DllImport(Lib.Kernel32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("WinBase.h", MSDNShortId = "aa366874")]
		public static extern uint ResetWriteWatch([In] IntPtr lpBaseAddress, SizeT dwRegionSize);

		/// <summary>
		/// <para>
		/// [Some information relates to pre-released product which may be substantially modified before it's commercially released. Microsoft makes no
		/// warranties, express or implied, with respect to the information provided here.]
		/// </para>
		/// <para>
		/// Provides CFG with a list of valid indirect call targets and specifies whether they should be marked valid or not. The valid call target information
		/// is provided as a list of offsets relative to a virtual memory range(start and size of the range). The call targets specified should be 16-byte
		/// aligned and in ascendingorder.
		/// </para>
		/// </summary>
		/// <param name="hProcess">The handle to the target process.</param>
		/// <param name="VirtualAddress">The start of the virtual memory region whose call targets are being marked valid.</param>
		/// <param name="RegionSize">The size of the virtual memory region.</param>
		/// <param name="NumberOfOffsets">The number of offsets relative to the virtual memory ranges.</param>
		/// <param name="OffsetInformation">A list of offsets and flags relative to the virtual memory ranges.</param>
		/// <returns><c>TRUE</c> if the operation was successful; otherwise, <c>FALSE</c>. To retrieve error values for this function, call <c>GetLastError</c>.</returns>
		// WINAPI SetProcessValidCallTargets( _In_ HANDLE hProcess, _In_ PVOID VirtualAddress, _In_ SIZE_T RegionSize, _In_ ULONG NumberOfOffsets, _Inout_
		// PCFG_CALL_TARGET_INFO OffsetInformation);
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("WinBase.h", MSDNShortId = "dn934202")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool SetProcessValidCallTargets(IntPtr hProcess, IntPtr VirtualAddress, SizeT RegionSize, uint NumberOfOffsets, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3)] CFG_CALL_TARGET_INFO[] OffsetInformation);

		/// <summary>Sets the minimum and maximum working set sizes for the specified process.</summary>
		/// <param name="hProcess">
		/// <para>A handle to the process whose working set sizes is to be set.</para>
		/// <para>The handle must have <c>PROCESS_SET_QUOTA</c> access rights. For more information, see Process Security and Access Rights.</para>
		/// </param>
		/// <param name="dwMinimumWorkingSetSize">
		/// <para>
		/// The minimum working set size for the process, in bytes. The virtual memory manager attempts to keep at least this much memory resident in the process
		/// whenever the process is active.
		/// </para>
		/// <para>
		/// This parameter must be greater than zero but less than or equal to the maximum working set size. The default size is 50 pages (for example, this is
		/// 204,800 bytes on systems with a 4K page size). If the value is greater than zero but less than 20 pages, the minimum value is set to 20 pages.
		/// </para>
		/// <para>
		/// If both dwMinimumWorkingSetSize and dwMaximumWorkingSetSize have the value ( <c>SIZE_T</c>)–1, the function removes as many pages as possible from
		/// the working set of the specified process.
		/// </para>
		/// </param>
		/// <param name="dwMaximumWorkingSetSize">
		/// <para>
		/// The maximum working set size for the process, in bytes. The virtual memory manager attempts to keep no more than this much memory resident in the
		/// process whenever the process is active and available memory is low.
		/// </para>
		/// <para>
		/// This parameter must be greater than or equal to 13 pages (for example, 53,248 on systems with a 4K page size), and less than the system-wide maximum
		/// (number of available pages minus 512 pages). The default size is 345 pages (for example, this is 1,413,120 bytes on systems with a 4K page size).
		/// </para>
		/// <para>
		/// If both dwMinimumWorkingSetSize and dwMaximumWorkingSetSize have the value ( <c>SIZE_T</c>)–1, the function removes as many pages as possible from
		/// the working set of the specified process. For details, see Remarks.
		/// </para>
		/// </param>
		/// <param name="Flags">
		/// <para>The flags that control the enforcement of the minimum and maximum working set sizes.</para>
		/// <para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>QUOTA_LIMITS_HARDWS_MIN_DISABLE0x00000002</term>
		/// <term>The working set may fall below the minimum working set limit if memory demands are high.This flag cannot be used with QUOTA_LIMITS_HARDWS_MIN_ENABLE.</term>
		/// </item>
		/// <item>
		/// <term>QUOTA_LIMITS_HARDWS_MIN_ENABLE0x00000001</term>
		/// <term>The working set will not fall below the minimum working set limit.This flag cannot be used with QUOTA_LIMITS_HARDWS_MIN_DISABLE.</term>
		/// </item>
		/// <item>
		/// <term>QUOTA_LIMITS_HARDWS_MAX_DISABLE0x00000008</term>
		/// <term>The working set may exceed the maximum working set limit if there is abundant memory.This flag cannot be used with QUOTA_LIMITS_HARDWS_MAX_ENABLE.</term>
		/// </item>
		/// <item>
		/// <term>QUOTA_LIMITS_HARDWS_MAX_ENABLE0x00000004</term>
		/// <term>The working set will not exceed the maximum working set limit.This flag cannot be used with QUOTA_LIMITS_HARDWS_MAX_DISABLE.</term>
		/// </item>
		/// </list>
		/// </para>
		/// </param>
		/// <returns>
		/// <para>If the function is succeeds, the return value is nonzero.</para>
		/// <para>
		/// If the function fails, the return value is zero. To get extended error information, call <c>GetLastError</c>. If the function fails, the return value
		/// is zero. To get extended error information, call <c>GetLastError</c>.
		/// </para>
		/// </returns>
		// BOOL WINAPI SetProcessWorkingSetSizeEx( _In_ HANDLE hProcess, _In_ SIZE_T dwMinimumWorkingSetSize, _In_ SIZE_T dwMaximumWorkingSetSize, _In_ DWORD Flags);
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("WinBase.h", MSDNShortId = "ms686237")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool SetProcessWorkingSetSizeEx([In] IntPtr hProcess, SizeT dwMinimumWorkingSetSize, SizeT dwMaximumWorkingSetSize, QUOTA_LIMITS_HARDWS Flags);

		/// <summary>Limits the size of the working set for the file system cache.</summary>
		/// <param name="MinimumFileCacheSize">
		/// <para>
		/// The minimum size of the file cache, in bytes. The virtual memory manager attempts to keep at least this much memory resident in the system file cache.
		/// </para>
		/// <para>To flush the cache, specify .</para>
		/// </param>
		/// <param name="MaximumFileCacheSize">
		/// <para>
		/// The maximum size of the file cache, in bytes. The virtual memory manager enforces this limit only if this call or a previous call to
		/// <c>SetSystemFileCacheSize</c> specifies <c>FILE_CACHE_MAX_HARD_ENABLE</c>.
		/// </para>
		/// <para>To flush the cache, specify .</para>
		/// </param>
		/// <param name="Flags">
		/// <para>
		/// The flags that enable or disable the file cache limits. If this parameter is 0 (zero), the size limits retain the current setting, which is either
		/// disabled or enabled.
		/// </para>
		/// <para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>FILE_CACHE_MAX_HARD_DISABLE0x2</term>
		/// <term>Disable the maximum size limit.The FILE_CACHE_MAX_HARD_DISABLE and FILE_CACHE_MAX_HARD_ENABLE flags are mutually exclusive.</term>
		/// </item>
		/// <item>
		/// <term>FILE_CACHE_MAX_HARD_ENABLE0x1</term>
		/// <term>Enable the maximum size limit.The FILE_CACHE_MAX_HARD_DISABLE and FILE_CACHE_MAX_HARD_ENABLE flags are mutually exclusive.</term>
		/// </item>
		/// <item>
		/// <term>FILE_CACHE_MIN_HARD_DISABLE0x8</term>
		/// <term>Disable the minimum size limit.The FILE_CACHE_MIN_HARD_DISABLE and FILE_CACHE_MIN_HARD_ENABLE flags are mutually exclusive.</term>
		/// </item>
		/// <item>
		/// <term>FILE_CACHE_MIN_HARD_ENABLE0x4</term>
		/// <term>Enable the minimum size limit.The FILE_CACHE_MIN_HARD_DISABLE and FILE_CACHE_MIN_HARD_ENABLE flags are mutually exclusive.</term>
		/// </item>
		/// </list>
		/// </para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is a nonzero value.</para>
		/// <para>If the function fails, the return value is 0 (zero). To get extended error information, call <c>GetLastError</c>.</para>
		/// </returns>
		// BOOL WINAPI SetSystemFileCacheSize( _In_ SIZE_T MinimumFileCacheSize, _In_ SIZE_T MaximumFileCacheSize, _In_ DWORD Flags);
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("WinBase.h", MSDNShortId = "aa965240")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool SetSystemFileCacheSize(SizeT MinimumFileCacheSize, SizeT MaximumFileCacheSize, FILE_CACHE_LIMITS Flags);

		/// <summary>Unmaps a mapped view of a file from the calling process's address space.</summary>
		/// <param name="lpBaseAddress">
		/// A pointer to the base address of the mapped view of a file that is to be unmapped. This value must be identical to the value returned by a previous
		/// call to the <c>MapViewOfFile</c> or <c>MapViewOfFileEx</c> function.
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is nonzero.</para>
		/// <para>If the function fails, the return value is zero. To get extended error information, call <c>GetLastError</c>.</para>
		/// </returns>
		// BOOL WINAPI UnmapViewOfFile( _In_ LPCVOID lpBaseAddress);
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("WinBase.h", MSDNShortId = "aa366882")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool UnmapViewOfFile([In] IntPtr lpBaseAddress);

		/// <summary>Unmaps a previously mapped view of a file or a pagefile-backed section.</summary>
		/// <param name="ProcessHandle">A HANDLE to the process from which the section will be unmapped.</param>
		/// <param name="BaseAddress">
		/// The base address of a previously mapped view that is to be unmapped. This value must be identical to the value returned by a previous call to MapViewOfFile2.
		/// </param>
		/// <param name="UnmapFlags">
		/// MEM_UNMAP_WITH_TRANSIENT_BOOST (1) or zero (0). MEM_UNMAP_WITH_TRANSIENT_BOOST should be used if the pages backing this view should be temporarily
		/// boosted (with automatic short term decay) because another thread will access them shortly.
		/// </param>
		/// <returns></returns>
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("MemoryApi.h", MSDNShortId = "mt492559")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool UnmapViewOfFile2([In] IntPtr ProcessHandle, IntPtr BaseAddress, uint UnmapFlags);

		/// <summary>This is an extended version of UnmapViewOfFile that takes an additional flags parameter.</summary>
		/// <param name="BaseAddress">
		/// A pointer to the base address of the mapped view of a file that is to be unmapped. This value must be identical to the value returned by a previous
		/// call to the MapViewOfFile or MapViewOfFileEx function.
		/// </param>
		/// <param name="UnmapFlags">
		/// The only supported flag is MEM_UNMAP_WITH_TRANSIENT_BOOST (0x1), which specifies that the priority of the pages being unmapped should be temporarily
		/// boosted because the caller expects that these pages will be accessed again shortly. For more information about memory priorities, see the
		/// SetThreadInformation(ThreadMemoryPriority) function.
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is a nonzero value.</para>
		/// <para>If the function fails, the return value is 0 (zero). To get extended error information, call <c>GetLastError</c>.</para>
		/// </returns>
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("MemoryApi.h", MSDNShortId = "mt670639")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool UnmapViewOfFileEx(IntPtr BaseAddress, uint UnmapFlags);

		/// <summary>Closes the specified bad memory notification handle.</summary>
		/// <param name="RegistrationHandle">Registration handle returned from the <c>RegisterBadMemoryNotification</c> function.</param>
		/// <returns>
		/// <para>If the function succeeds, the return value is nonzero.</para>
		/// <para>If the function fails, the return value is zero. To get extended error information, call <c>GetLastError</c>.</para>
		/// </returns>
		// BOOL WINAPI UnregisterBadMemoryNotification( _In_ PVOID RegistrationHandle);
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("WinBase.h", MSDNShortId = "hh691014")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool UnregisterBadMemoryNotification(IntPtr RegistrationHandle);

		/// <summary>
		/// <para>
		/// Reserves, commits, or changes the state of a region of pages in the virtual address space of the calling process. Memory allocated by this function
		/// is automatically initialized to zero.
		/// </para>
		/// <para>To allocate memory in the address space of another process, use the <c>VirtualAllocEx</c> function.</para>
		/// </summary>
		/// <param name="lpAddress">
		/// <para>
		/// The starting address of the region to allocate. If the memory is being reserved, the specified address is rounded down to the nearest multiple of the
		/// allocation granularity. If the memory is already reserved and is being committed, the address is rounded down to the next page boundary. To determine
		/// the size of a page and the allocation granularity on the host computer, use the <c>GetSystemInfo</c> function. If this parameter is <c>NULL</c>, the
		/// system determines where to allocate the region.
		/// </para>
		/// <para>
		/// If this address is within an enclave that you have not initialized by calling <c>InitializeEnclave</c>, <c>VirtualAlloc</c> allocates a page of zeros
		/// for the enclave at that address. The page must be previously uncommitted, and will not be measured with the EEXTEND instruction of the Intel Software
		/// Guard Extensions programming model.
		/// </para>
		/// <para>If the address in within an enclave that you initialized, then the allocation operation fails with the <c>ERROR_INVALID_ADDRESS</c> error.</para>
		/// </param>
		/// <param name="dwSize">
		/// The size of the region, in bytes. If the lpAddress parameter is <c>NULL</c>, this value is rounded up to the next page boundary. Otherwise, the
		/// allocated pages include all pages containing one or more bytes in the range from lpAddress to lpAddress+dwSize. This means that a 2-byte range
		/// straddling a page boundary causes both pages to be included in the allocated region.
		/// </param>
		/// <param name="flAllocationType">
		/// <para>The type of memory allocation. This parameter must contain one of the following values.</para>
		/// <para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>MEM_COMMIT0x00001000</term>
		/// <term>
		/// Allocates memory charges (from the overall size of memory and the paging files on disk) for the specified reserved memory pages. The function also
		/// guarantees that when the caller later initially accesses the memory, the contents will be zero. Actual physical pages are not allocated unless/until
		/// the virtual addresses are actually accessed.To reserve and commit pages in one step, call VirtualAlloc with .Attempting to commit a specific address
		/// range by specifying MEM_COMMIT without MEM_RESERVE and a non-NULL lpAddress fails unless the entire range has already been reserved. The resulting
		/// error code is ERROR_INVALID_ADDRESS.An attempt to commit a page that is already committed does not cause the function to fail. This means that you
		/// can commit pages without first determining the current commitment state of each page.If lpAddress specifies an address within an enclave,
		/// flAllocationType must be MEM_COMMIT.
		/// </term>
		/// </item>
		/// <item>
		/// <term>MEM_RESERVE0x00002000</term>
		/// <term>
		/// Reserves a range of the process&amp;#39;s virtual address space without allocating any actual physical storage in memory or in the paging file on
		/// disk.You can commit reserved pages in subsequent calls to the VirtualAlloc function. To reserve and commit pages in one step, call VirtualAlloc with
		/// MEM_COMMIT | MEM_RESERVE.Other memory allocation functions, such as malloc and LocalAlloc, cannot use a reserved range of memory until it is released.
		/// </term>
		/// </item>
		/// <item>
		/// <term>MEM_RESET0x00080000</term>
		/// <term>
		/// Indicates that data in the memory range specified by lpAddress and dwSize is no longer of interest. The pages should not be read from or written to
		/// the paging file. However, the memory block will be used again later, so it should not be decommitted. This value cannot be used with any other
		/// value.Using this value does not guarantee that the range operated on with MEM_RESET will contain zeros. If you want the range to contain zeros,
		/// decommit the memory and then recommit it.When you specify MEM_RESET, the VirtualAlloc function ignores the value of flProtect. However, you must
		/// still set flProtect to a valid protection value, such as PAGE_NOACCESS.VirtualAlloc returns an error if you use MEM_RESET and the range of memory is
		/// mapped to a file. A shared view is only acceptable if it is mapped to a paging file.
		/// </term>
		/// </item>
		/// <item>
		/// <term>MEM_RESET_UNDO0x1000000</term>
		/// <term>
		/// MEM_RESET_UNDO should only be called on an address range to which MEM_RESET was successfully applied earlier. It indicates that the data in the
		/// specified memory range specified by lpAddress and dwSize is of interest to the caller and attempts to reverse the effects of MEM_RESET. If the
		/// function succeeds, that means all data in the specified address range is intact. If the function fails, at least some of the data in the address
		/// range has been replaced with zeroes.This value cannot be used with any other value. If MEM_RESET_UNDO is called on an address range which was not
		/// MEM_RESET earlier, the behavior is undefined. When you specify MEM_RESET, the VirtualAlloc function ignores the value of flProtect. However, you must
		/// still set flProtect to a valid protection value, such as PAGE_NOACCESS.Windows Server 2008 R2, Windows 7, Windows Server 2008, Windows Vista, Windows
		/// Server 2003 and Windows XP: The MEM_RESET_UNDO flag is not supported until Windows 8 and Windows Server 2012.
		/// </term>
		/// </item>
		/// </list>
		/// </para>
		/// <para>This parameter can also specify the following values as indicated.</para>
		/// <para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>MEM_LARGE_PAGES0x20000000</term>
		/// <term>
		/// Allocates memory using large page support.The size and alignment must be a multiple of the large-page minimum. To obtain this value, use the
		/// GetLargePageMinimum function.If you specify this value, you must also specify MEM_RESERVE and MEM_COMMIT.
		/// </term>
		/// </item>
		/// <item>
		/// <term>MEM_PHYSICAL0x00400000</term>
		/// <term>
		/// Reserves an address range that can be used to map Address Windowing Extensions (AWE) pages.This value must be used with MEM_RESERVE and no other values.
		/// </term>
		/// </item>
		/// <item>
		/// <term>MEM_TOP_DOWN0x00100000</term>
		/// <term>Allocates memory at the highest possible address. This can be slower than regular allocations, especially when there are many allocations.</term>
		/// </item>
		/// <item>
		/// <term>MEM_WRITE_WATCH0x00200000</term>
		/// <term>
		/// Causes the system to track pages that are written to in the allocated region. If you specify this value, you must also specify MEM_RESERVE.To
		/// retrieve the addresses of the pages that have been written to since the region was allocated or the write-tracking state was reset, call the
		/// GetWriteWatch function. To reset the write-tracking state, call GetWriteWatch or ResetWriteWatch. The write-tracking feature remains enabled for the
		/// memory region until the region is freed.
		/// </term>
		/// </item>
		/// </list>
		/// </para>
		/// </param>
		/// <param name="flProtect">
		/// <para>
		/// The memory protection for the region of pages to be allocated. If the pages are being committed, you can specify any one of the memory protection constants.
		/// </para>
		/// <para>If lpAddress specifies an address within an enclave, flProtect cannot be any of the following values:</para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is the base address of the allocated region of pages.</para>
		/// <para>If the function fails, the return value is <c>NULL</c>. To get extended error information, call <c>GetLastError</c>.</para>
		/// </returns>
		// LPVOID WINAPI VirtualAlloc( _In_opt_ LPVOID lpAddress, _In_ SIZE_T dwSize, _In_ DWORD flAllocationType, _In_ DWORD flProtect);
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("WinBase.h", MSDNShortId = "aa366887")]
		public static extern IntPtr VirtualAlloc([In] IntPtr lpAddress, SizeT dwSize, MEM_ALLOCATION_TYPE flAllocationType, MEM_PROTECTION flProtect);

		/// <summary>
		/// <para>
		/// Reserves, commits, or changes the state of a region of memory within the virtual address space of a specified process. The function initializes the
		/// memory it allocates to zero.
		/// </para>
		/// <para>To specify the NUMA node for the physical memory, see <c>VirtualAllocExNuma</c>.</para>
		/// </summary>
		/// <param name="hProcess">
		/// <para>The handle to a process. The function allocates memory within the virtual address space of this process.</para>
		/// <para>The handle must have the <c>PROCESS_VM_OPERATION</c> access right. For more information, see Process Security and Access Rights.</para>
		/// </param>
		/// <param name="lpAddress">
		/// <para>The pointer that specifies a desired starting address for the region of pages that you want to allocate.</para>
		/// <para>If you are reserving memory, the function rounds this address down to the nearest multiple of the allocation granularity.</para>
		/// <para>
		/// If you are committing memory that is already reserved, the function rounds this address down to the nearest page boundary. To determine the size of a
		/// page and the allocation granularity on the host computer, use the <c>GetSystemInfo</c> function.
		/// </para>
		/// <para>If lpAddress is <c>NULL</c>, the function determines where to allocate the region.</para>
		/// <para>
		/// If this address is within an enclave that you have not initialized by calling <c>InitializeEnclave</c>, <c>VirtualAllocEx</c> allocates a page of
		/// zeros for the enclave at that address. The page must be previously uncommitted, and will not be measured with the EEXTEND instruction of the Intel
		/// Software Guard Extensions programming model.
		/// </para>
		/// <para>If the address in within an enclave that you initialized, then the allocation operation fails with the <c>ERROR_INVALID_ADDRESS</c> error.</para>
		/// </param>
		/// <param name="dwSize">
		/// <para>The size of the region of memory to allocate, in bytes.</para>
		/// <para>If lpAddress is <c>NULL</c>, the function rounds dwSize up to the next page boundary.</para>
		/// <para>
		/// If lpAddress is not <c>NULL</c>, the function allocates all pages that contain one or more bytes in the range from lpAddress to lpAddress+dwSize.
		/// This means, for example, that a 2-byte range that straddles a page boundary causes the function to allocate both pages.
		/// </para>
		/// </param>
		/// <param name="flAllocationType">
		/// <para>The type of memory allocation. This parameter must contain one of the following values.</para>
		/// <para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>MEM_COMMIT0x00001000</term>
		/// <term>
		/// Allocates memory charges (from the overall size of memory and the paging files on disk) for the specified reserved memory pages. The function also
		/// guarantees that when the caller later initially accesses the memory, the contents will be zero. Actual physical pages are not allocated unless/until
		/// the virtual addresses are actually accessed.To reserve and commit pages in one step, call VirtualAllocEx with .Attempting to commit a specific
		/// address range by specifying MEM_COMMIT without MEM_RESERVE and a non-NULL lpAddress fails unless the entire range has already been reserved. The
		/// resulting error code is ERROR_INVALID_ADDRESS.An attempt to commit a page that is already committed does not cause the function to fail. This means
		/// that you can commit pages without first determining the current commitment state of each page.If lpAddress specifies an address within an enclave,
		/// flAllocationType must be MEM_COMMIT.
		/// </term>
		/// </item>
		/// <item>
		/// <term>MEM_RESERVE0x00002000</term>
		/// <term>
		/// Reserves a range of the process&amp;#39;s virtual address space without allocating any actual physical storage in memory or in the paging file on
		/// disk.You commit reserved pages by calling VirtualAllocEx again with MEM_COMMIT. To reserve and commit pages in one step, call VirtualAllocEx with
		/// .Other memory allocation functions, such as malloc and LocalAlloc, cannot use reserved memory until it has been released.
		/// </term>
		/// </item>
		/// <item>
		/// <term>MEM_RESET0x00080000</term>
		/// <term>
		/// Indicates that data in the memory range specified by lpAddress and dwSize is no longer of interest. The pages should not be read from or written to
		/// the paging file. However, the memory block will be used again later, so it should not be decommitted. This value cannot be used with any other
		/// value.Using this value does not guarantee that the range operated on with MEM_RESET will contain zeros. If you want the range to contain zeros,
		/// decommit the memory and then recommit it.When you use MEM_RESET, the VirtualAllocEx function ignores the value of fProtect. However, you must still
		/// set fProtect to a valid protection value, such as PAGE_NOACCESS.VirtualAllocEx returns an error if you use MEM_RESET and the range of memory is
		/// mapped to a file. A shared view is only acceptable if it is mapped to a paging file.
		/// </term>
		/// </item>
		/// <item>
		/// <term>MEM_RESET_UNDO0x1000000</term>
		/// <term>
		/// MEM_RESET_UNDO should only be called on an address range to which MEM_RESET was successfully applied earlier. It indicates that the data in the
		/// specified memory range specified by lpAddress and dwSize is of interest to the caller and attempts to reverse the effects of MEM_RESET. If the
		/// function succeeds, that means all data in the specified address range is intact. If the function fails, at least some of the data in the address
		/// range has been replaced with zeroes.This value cannot be used with any other value. If MEM_RESET_UNDO is called on an address range which was not
		/// MEM_RESET earlier, the behavior is undefined. When you specify MEM_RESET, the VirtualAllocEx function ignores the value of flProtect. However, you
		/// must still set flProtect to a valid protection value, such as PAGE_NOACCESS.Windows Server 2008 R2, Windows 7, Windows Server 2008, Windows Vista,
		/// Windows Server 2003 and Windows XP: The MEM_RESET_UNDO flag is not supported until Windows 8 and Windows Server 2012.
		/// </term>
		/// </item>
		/// </list>
		/// </para>
		/// <para>This parameter can also specify the following values as indicated.</para>
		/// <para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>MEM_LARGE_PAGES0x20000000</term>
		/// <term>
		/// Allocates memory using large page support.The size and alignment must be a multiple of the large-page minimum. To obtain this value, use the
		/// GetLargePageMinimum function.If you specify this value, you must also specify MEM_RESERVE and MEM_COMMIT.
		/// </term>
		/// </item>
		/// <item>
		/// <term>MEM_PHYSICAL0x00400000</term>
		/// <term>
		/// Reserves an address range that can be used to map Address Windowing Extensions (AWE) pages.This value must be used with MEM_RESERVE and no other values.
		/// </term>
		/// </item>
		/// <item>
		/// <term>MEM_TOP_DOWN0x00100000</term>
		/// <term>Allocates memory at the highest possible address. This can be slower than regular allocations, especially when there are many allocations.</term>
		/// </item>
		/// </list>
		/// </para>
		/// </param>
		/// <param name="flProtect">
		/// <para>
		/// The memory protection for the region of pages to be allocated. If the pages are being committed, you can specify any one of the memory protection constants.
		/// </para>
		/// <para>If lpAddress specifies an address within an enclave, flProtect cannot be any of the following values:</para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is the base address of the allocated region of pages.</para>
		/// <para>If the function fails, the return value is <c>NULL</c>. To get extended error information, call <c>GetLastError</c>.</para>
		/// </returns>
		// LPVOID WINAPI VirtualAllocEx( _In_ HANDLE hProcess, _In_opt_ LPVOID lpAddress, _In_ SIZE_T dwSize, _In_ DWORD flAllocationType, _In_ DWORD flProtect);
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("WinBase.h", MSDNShortId = "aa366890")]
		public static extern IntPtr VirtualAllocEx([In] IntPtr hProcess, [In] IntPtr lpAddress, SizeT dwSize, MEM_ALLOCATION_TYPE flAllocationType, MEM_PROTECTION flProtect);

		/// <summary>
		/// Reserves, commits, or changes the state of a region of memory within the virtual address space of the specified process, and specifies the NUMA node
		/// for the physical memory.
		/// </summary>
		/// <param name="hProcess">
		/// <para>The handle to a process. The function allocates memory within the virtual address space of this process.</para>
		/// <para>The handle must have the <c>PROCESS_VM_OPERATION</c> access right. For more information, see Process Security and Access Rights.</para>
		/// </param>
		/// <param name="lpAddress">
		/// <para>The pointer that specifies a desired starting address for the region of pages that you want to allocate.</para>
		/// <para>If you are reserving memory, the function rounds this address down to the nearest multiple of the allocation granularity.</para>
		/// <para>
		/// If you are committing memory that is already reserved, the function rounds this address down to the nearest page boundary. To determine the size of a
		/// page and the allocation granularity on the host computer, use the <c>GetSystemInfo</c> function.
		/// </para>
		/// <para>If lpAddress is <c>NULL</c>, the function determines where to allocate the region.</para>
		/// </param>
		/// <param name="dwSize">
		/// <para>The size of the region of memory to be allocated, in bytes.</para>
		/// <para>If lpAddress is <c>NULL</c>, the function rounds dwSize up to the next page boundary.</para>
		/// <para>
		/// If lpAddress is not <c>NULL</c>, the function allocates all pages that contain one or more bytes in the range from lpAddress to . This means, for
		/// example, that a 2-byte range that straddles a page boundary causes the function to allocate both pages.
		/// </para>
		/// </param>
		/// <param name="flAllocationType">
		/// <para>The type of memory allocation. This parameter must contain one of the following values.</para>
		/// <para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>MEM_COMMIT0x00001000</term>
		/// <term>
		/// Allocates memory charges (from the overall size of memory and the paging files on disk) for the specified reserved memory pages. The function also
		/// guarantees that when the caller later initially accesses the memory, the contents will be zero. Actual physical pages are not allocated unless/until
		/// the virtual addresses are actually accessed.To reserve and commit pages in one step, call the function with .Attempting to commit a specific address
		/// range by specifying MEM_COMMIT without MEM_RESERVE and a non-NULL lpAddress fails unless the entire range has already been reserved. The resulting
		/// error code is ERROR_INVALID_ADDRESS.An attempt to commit a page that is already committed does not cause the function to fail. This means that you
		/// can commit pages without first determining the current commitment state of each page.
		/// </term>
		/// </item>
		/// <item>
		/// <term>MEM_RESERVE0x00002000</term>
		/// <term>
		/// Reserves a range of the process&amp;#39;s virtual address space without allocating any actual physical storage in memory or in the paging file on
		/// disk.You commit reserved pages by calling the function again with MEM_COMMIT. To reserve and commit pages in one step, call the function with .Other
		/// memory allocation functions, such as malloc and LocalAlloc, cannot use reserved memory until it has been released.
		/// </term>
		/// </item>
		/// <item>
		/// <term>MEM_RESET0x00080000</term>
		/// <term>
		/// Indicates that data in the memory range specified by lpAddress and dwSize is no longer of interest. The pages should not be read from or written to
		/// the paging file. However, the memory block will be used again later, so it should not be decommitted. This value cannot be used with any other
		/// value.Using this value does not guarantee that the range operated on with MEM_RESET will contain zeros. If you want the range to contain zeros,
		/// decommit the memory and then recommit it.When you use MEM_RESET, the function ignores the value of fProtect. However, you must still set fProtect to
		/// a valid protection value, such as PAGE_NOACCESS.The function returns an error if you use MEM_RESET and the range of memory is mapped to a file. A
		/// shared view is only acceptable if it is mapped to a paging file.
		/// </term>
		/// </item>
		/// <item>
		/// <term>MEM_RESET_UNDO0x1000000</term>
		/// <term>
		/// MEM_RESET_UNDO should only be called on an address range to which MEM_RESET was successfully applied earlier. It indicates that the data in the
		/// specified memory range specified by lpAddress and dwSize is of interest to the caller and attempts to reverse the effects of MEM_RESET. If the
		/// function succeeds, that means all data in the specified address range is intact. If the function fails, at least some of the data in the address
		/// range has been replaced with zeroes.This value cannot be used with any other value. If MEM_RESET_UNDO is called on an address range which was not
		/// MEM_RESET earlier, the behavior is undefined. When you specify MEM_RESET, the VirtualAllocExNuma function ignores the value of flProtect. However,
		/// you must still set flProtect to a valid protection value, such as PAGE_NOACCESS.Windows Server 2008 R2, Windows 7, Windows Server 2008 and Windows
		/// Vista: The MEM_RESET_UNDO flag is not supported until Windows 8 and Windows Server 2012.
		/// </term>
		/// </item>
		/// </list>
		/// </para>
		/// <para>This parameter can also specify the following values as indicated.</para>
		/// <para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>MEM_LARGE_PAGES0x20000000</term>
		/// <term>
		/// Allocates memory using large page support.The size and alignment must be a multiple of the large-page minimum. To obtain this value, use the
		/// GetLargePageMinimum function.If you specify this value, you must also specify MEM_RESERVE and MEM_COMMIT.
		/// </term>
		/// </item>
		/// <item>
		/// <term>MEM_PHYSICAL0x00400000</term>
		/// <term>
		/// Reserves an address range that can be used to map Address Windowing Extensions (AWE) pages.This value must be used with MEM_RESERVE and no other values.
		/// </term>
		/// </item>
		/// <item>
		/// <term>MEM_TOP_DOWN0x00100000</term>
		/// <term>Allocates memory at the highest possible address.</term>
		/// </item>
		/// </list>
		/// </para>
		/// </param>
		/// <param name="flProtect">
		/// <para>
		/// The memory protection for the region of pages to be allocated. If the pages are being committed, you can specify any one of the memory protection constants.
		/// </para>
		/// <para>Protection attributes specified when protecting a page cannot conflict with those specified when allocating a page.</para>
		/// </param>
		/// <param name="nndPreferred">
		/// <para>The NUMA node where the physical memory should reside.</para>
		/// <para>
		/// Used only when allocating a new VA region (either committed or reserved). Otherwise this parameter is ignored when the API is used to commit pages in
		/// a region that already exists
		/// </para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is the base address of the allocated region of pages.</para>
		/// <para>If the function fails, the return value is <c>NULL</c>. To get extended error information, call <c>GetLastError</c>.</para>
		/// </returns>
		// LPVOID WINAPI VirtualAllocExNuma( _In_ HANDLE hProcess, _In_opt_ LPVOID lpAddress, _In_ SIZE_T dwSize, _In_ DWORD flAllocationType, _In_ DWORD
		// flProtect, _In_ DWORD nndPreferred);
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("WinBase.h", MSDNShortId = "aa366891")]
		public static extern IntPtr VirtualAllocExNuma([In] IntPtr hProcess, [In] IntPtr lpAddress, SizeT dwSize, MEM_ALLOCATION_TYPE flAllocationType, MEM_PROTECTION flProtect, uint nndPreferred);

		/// <summary>
		/// Reserves, commits, or changes the state of a region of pages in the virtual address space of the calling process. Memory allocated by this function
		/// is automatically initialized to zero.
		/// </summary>
		/// <param name="BaseAddress">
		/// The starting address of the region to allocate. If the memory is being reserved, the specified address is rounded down to the nearest multiple of the
		/// allocation granularity. If the memory is already reserved and is being committed, the address is rounded down to the next page boundary. To determine
		/// the size of a page and the allocation granularity on the host computer, use the <c>GetSystemInfo</c> function. If this parameter is <c>NULL</c>, the
		/// system determines where to allocate the region.
		/// </param>
		/// <param name="Size">
		/// The size of the region, in bytes. If the BaseAddress parameter is <c>NULL</c>, this value is rounded up to the next page boundary. Otherwise, the
		/// allocated pages include all pages containing one or more bytes in the range from BaseAddress to BaseAddress+Size. This means that a 2-byte range
		/// straddling a page boundary causes both pages to be included in the allocated region.
		/// </param>
		/// <param name="AllocationType">
		/// <para>The type of memory allocation. This parameter must contain one of the following values.</para>
		/// <para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>MEM_COMMIT0x00001000</term>
		/// <term>
		/// Allocates memory charges (from the overall size of memory and the paging files on disk) for the specified reserved memory pages. The function also
		/// guarantees that when the caller later initially accesses the memory, the contents will be zero. Actual physical pages are not allocated unless/until
		/// the virtual addresses are actually accessed.To reserve and commit pages in one step, call VirtualAllocFromApp with .Attempting to commit a specific
		/// address range by specifying MEM_COMMIT without MEM_RESERVE and a non-NULL BaseAddress fails unless the entire range has already been reserved. The
		/// resulting error code is ERROR_INVALID_ADDRESS.An attempt to commit a page that is already committed does not cause the function to fail. This means
		/// that you can commit pages without first determining the current commitment state of each page.
		/// </term>
		/// </item>
		/// <item>
		/// <term>MEM_RESERVE0x00002000</term>
		/// <term>
		/// Reserves a range of the process&amp;#39;s virtual address space without allocating any actual physical storage in memory or in the paging file on
		/// disk.You can commit reserved pages in subsequent calls to the VirtualAllocFromApp function. To reserve and commit pages in one step, call
		/// VirtualAllocFromApp with MEM_COMMIT | MEM_RESERVE.Other memory allocation functions, such as malloc and LocalAlloc, cannot use a reserved range of
		/// memory until it is released.
		/// </term>
		/// </item>
		/// <item>
		/// <term>MEM_RESET0x00080000</term>
		/// <term>
		/// Indicates that data in the memory range specified by BaseAddress and Size is no longer of interest. The pages should not be read from or written to
		/// the paging file. However, the memory block will be used again later, so it should not be decommitted. This value cannot be used with any other
		/// value.Using this value does not guarantee that the range operated on with MEM_RESET will contain zeros. If you want the range to contain zeros,
		/// decommit the memory and then recommit it.When you specify MEM_RESET, the VirtualAllocFromApp function ignores the value of Protection. However, you
		/// must still set Protection to a valid protection value, such as PAGE_NOACCESS.VirtualAllocFromApp returns an error if you use MEM_RESET and the range
		/// of memory is mapped to a file. A shared view is only acceptable if it is mapped to a paging file.
		/// </term>
		/// </item>
		/// <item>
		/// <term>MEM_RESET_UNDO0x1000000</term>
		/// <term>
		/// MEM_RESET_UNDO should only be called on an address range to which MEM_RESET was successfully applied earlier. It indicates that the data in the
		/// specified memory range specified by BaseAddress and Size is of interest to the caller and attempts to reverse the effects of MEM_RESET. If the
		/// function succeeds, that means all data in the specified address range is intact. If the function fails, at least some of the data in the address
		/// range has been replaced with zeroes.This value cannot be used with any other value. If MEM_RESET_UNDO is called on an address range which was not
		/// MEM_RESET earlier, the behavior is undefined. When you specify MEM_RESET, the VirtualAllocFromApp function ignores the value of Protection. However,
		/// you must still set Protection to a valid protection value, such as PAGE_NOACCESS.
		/// </term>
		/// </item>
		/// </list>
		/// </para>
		/// <para>This parameter can also specify the following values as indicated.</para>
		/// <para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>MEM_LARGE_PAGES0x20000000</term>
		/// <term>
		/// Allocates memory using large page support.The size and alignment must be a multiple of the large-page minimum. To obtain this value, use the
		/// GetLargePageMinimum function.If you specify this value, you must also specify MEM_RESERVE and MEM_COMMIT.
		/// </term>
		/// </item>
		/// <item>
		/// <term>MEM_PHYSICAL0x00400000</term>
		/// <term>
		/// Reserves an address range that can be used to map Address Windowing Extensions (AWE) pages.This value must be used with MEM_RESERVE and no other values.
		/// </term>
		/// </item>
		/// <item>
		/// <term>MEM_TOP_DOWN0x00100000</term>
		/// <term>Allocates memory at the highest possible address. This can be slower than regular allocations, especially when there are many allocations.</term>
		/// </item>
		/// <item>
		/// <term>MEM_WRITE_WATCH0x00200000</term>
		/// <term>
		/// Causes the system to track pages that are written to in the allocated region. If you specify this value, you must also specify MEM_RESERVE.To
		/// retrieve the addresses of the pages that have been written to since the region was allocated or the write-tracking state was reset, call the
		/// GetWriteWatch function. To reset the write-tracking state, call GetWriteWatch or ResetWriteWatch. The write-tracking feature remains enabled for the
		/// memory region until the region is freed.
		/// </term>
		/// </item>
		/// </list>
		/// </para>
		/// </param>
		/// <param name="Protection">
		/// The memory protection for the region of pages to be allocated. If the pages are being committed, you can specify one of the memory protection
		/// constants. The following constants generate an error:
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is the base address of the allocated region of pages.</para>
		/// <para>If the function fails, the return value is <c>NULL</c>. To get extended error information, call <c>GetLastError</c>.</para>
		/// </returns>
		// PVOID WINAPI VirtualAllocFromApp( _In_opt_ PVOID BaseAddress, _In_ SIZE_T Size, _In_ ULONG AllocationType, _In_ ULONG Protection);
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("MemoryApi.h", MSDNShortId = "mt169845")]
		public static extern IntPtr VirtualAllocFromApp([In] IntPtr BaseAddress, SizeT Size, MEM_ALLOCATION_TYPE AllocationType, MEM_PROTECTION Protection);

		/// <summary>
		/// <para>Releases, decommits, or releases and decommits a region of pages within the virtual address space of the calling process.</para>
		/// <para>To free memory allocated in another process by the <c>VirtualAllocEx</c> function, use the <c>VirtualFreeEx</c> function.</para>
		/// </summary>
		/// <param name="lpAddress">
		/// <para>A pointer to the base address of the region of pages to be freed.</para>
		/// <para>
		/// If the dwFreeType parameter is <c>MEM_RELEASE</c>, this parameter must be the base address returned by the <c>VirtualAlloc</c> function when the
		/// region of pages is reserved.
		/// </para>
		/// </param>
		/// <param name="dwSize">
		/// <para>The size of the region of memory to be freed, in bytes.</para>
		/// <para>
		/// If the dwFreeType parameter is <c>MEM_RELEASE</c>, this parameter must be 0 (zero). The function frees the entire region that is reserved in the
		/// initial allocation call to <c>VirtualAlloc</c>.
		/// </para>
		/// <para>
		/// If the dwFreeType parameter is <c>MEM_DECOMMIT</c>, the function decommits all memory pages that contain one or more bytes in the range from the
		/// lpAddress parameter to . This means, for example, that a 2-byte region of memory that straddles a page boundary causes both pages to be decommitted.
		/// If lpAddress is the base address returned by <c>VirtualAlloc</c> and dwSize is 0 (zero), the function decommits the entire region that is allocated
		/// by <c>VirtualAlloc</c>. After that, the entire region is in the reserved state.
		/// </para>
		/// </param>
		/// <param name="dwFreeType">
		/// <para>The type of free operation. This parameter can be one of the following values.</para>
		/// <para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>MEM_DECOMMIT0x4000</term>
		/// <term>
		/// Decommits the specified region of committed pages. After the operation, the pages are in the reserved state. The function does not fail if you
		/// attempt to decommit an uncommitted page. This means that you can decommit a range of pages without first determining the current commitment state.Do
		/// not use this value with MEM_RELEASE.The MEM_DECOMMIT value is not supported when the lpAddress parameter provides the base address for an enclave.
		/// </term>
		/// </item>
		/// <item>
		/// <term>MEM_RELEASE0x8000</term>
		/// <term>
		/// Releases the specified region of pages. After this operation, the pages are in the free state. If you specify this value, dwSize must be 0 (zero),
		/// and lpAddress must point to the base address returned by the VirtualAlloc function when the region is reserved. The function fails if either of these
		/// conditions is not met.If any pages in the region are committed currently, the function first decommits, and then releases them.The function does not
		/// fail if you attempt to release pages that are in different states, some reserved and some committed. This means that you can release a range of pages
		/// without first determining the current commitment state.Do not use this value with MEM_DECOMMIT.
		/// </term>
		/// </item>
		/// </list>
		/// </para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is nonzero.</para>
		/// <para>If the function fails, the return value is 0 (zero). To get extended error information, call <c>GetLastError</c>.</para>
		/// </returns>
		// BOOL WINAPI VirtualFree( _In_ LPVOID lpAddress, _In_ SIZE_T dwSize, _In_ DWORD dwFreeType);
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("WinBase.h", MSDNShortId = "aa366892")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool VirtualFree([In] IntPtr lpAddress, SizeT dwSize, MEM_ALLOCATION_TYPE dwFreeType);

		/// <summary>Releases, decommits, or releases and decommits a region of memory within the virtual address space of a specified process.</summary>
		/// <param name="hProcess">
		/// <para>A handle to a process. The function frees memory within the virtual address space of the process.</para>
		/// <para>The handle must have the <c>PROCESS_VM_OPERATION</c> access right. For more information, see Process Security and Access Rights.</para>
		/// </param>
		/// <param name="lpAddress">
		/// <para>A pointer to the starting address of the region of memory to be freed.</para>
		/// <para>
		/// If the dwFreeType parameter is <c>MEM_RELEASE</c>, lpAddress must be the base address returned by the <c>VirtualAllocEx</c> function when the region
		/// is reserved.
		/// </para>
		/// </param>
		/// <param name="dwSize">
		/// <para>The size of the region of memory to free, in bytes.</para>
		/// <para>
		/// If the dwFreeType parameter is <c>MEM_RELEASE</c>, dwSize must be 0 (zero). The function frees the entire region that is reserved in the initial
		/// allocation call to <c>VirtualAllocEx</c>.
		/// </para>
		/// <para>
		/// If dwFreeType is <c>MEM_DECOMMIT</c>, the function decommits all memory pages that contain one or more bytes in the range from the lpAddress
		/// parameter to . This means, for example, that a 2-byte region of memory that straddles a page boundary causes both pages to be decommitted. If
		/// lpAddress is the base address returned by <c>VirtualAllocEx</c> and dwSize is 0 (zero), the function decommits the entire region that is allocated by
		/// <c>VirtualAllocEx</c>. After that, the entire region is in the reserved state.
		/// </para>
		/// </param>
		/// <param name="dwFreeType">
		/// <para>The type of free operation. This parameter can be one of the following values.</para>
		/// <para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>MEM_DECOMMIT0x4000</term>
		/// <term>
		/// Decommits the specified region of committed pages. After the operation, the pages are in the reserved state. The function does not fail if you
		/// attempt to decommit an uncommitted page. This means that you can decommit a range of pages without first determining their current commitment
		/// state.Do not use this value with MEM_RELEASE.The MEM_DECOMMIT value is not supported when the lpAddress parameter provides the base address for an enclave.
		/// </term>
		/// </item>
		/// <item>
		/// <term>MEM_RELEASE0x8000</term>
		/// <term>
		/// Releases the specified region of pages. After the operation, the pages are in the free state. If you specify this value, dwSize must be 0 (zero), and
		/// lpAddress must point to the base address returned by the VirtualAllocEx function when the region is reserved. The function fails if either of these
		/// conditions is not met.If any pages in the region are committed currently, the function first decommits, and then releases them.The function does not
		/// fail if you attempt to release pages that are in different states, some reserved and some committed. This means that you can release a range of pages
		/// without first determining the current commitment state.Do not use this value with MEM_DECOMMIT.
		/// </term>
		/// </item>
		/// </list>
		/// </para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is a nonzero value.</para>
		/// <para>If the function fails, the return value is 0 (zero). To get extended error information, call <c>GetLastError</c>.</para>
		/// </returns>
		// BOOL WINAPI VirtualFreeEx( _In_ HANDLE hProcess, _In_ LPVOID lpAddress, _In_ SIZE_T dwSize, _In_ DWORD dwFreeType);
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("WinBase.h", MSDNShortId = "aa366894")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool VirtualFreeEx([In] IntPtr hProcess, [In] IntPtr lpAddress, SizeT dwSize, MEM_ALLOCATION_TYPE dwFreeType);

		/// <summary>
		/// Locks the specified region of the process's virtual address space into physical memory, ensuring that subsequent access to the region will not incur
		/// a page fault.
		/// </summary>
		/// <param name="lpAddress">A pointer to the base address of the region of pages to be locked.</param>
		/// <param name="dwSize">
		/// The size of the region to be locked, in bytes. The region of affected pages includes all pages that contain one or more bytes in the range from the
		/// lpAddress parameter to . This means that a 2-byte range straddling a page boundary causes both pages to be locked.
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is nonzero.</para>
		/// <para>If the function fails, the return value is zero. To get extended error information, call <c>GetLastError</c>.</para>
		/// </returns>
		// BOOL WINAPI VirtualLock( _In_ LPVOID lpAddress, _In_ SIZE_T dwSize);
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("WinBase.h", MSDNShortId = "aa366895")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool VirtualLock([In] IntPtr lpAddress, SizeT dwSize);

		/// <summary>
		/// <para>Changes the protection on a region of committed pages in the virtual address space of the calling process.</para>
		/// <para>To change the access protection of any process, use the <c>VirtualProtectEx</c> function.</para>
		/// </summary>
		/// <param name="lpAddress">
		/// <para>A pointer an address that describes the starting page of the region of pages whose access protection attributes are to be changed.</para>
		/// <para>
		/// All pages in the specified region must be within the same reserved region allocated when calling the <c>VirtualAlloc</c> or <c>VirtualAllocEx</c>
		/// function using <c>MEM_RESERVE</c>. The pages cannot span adjacent reserved regions that were allocated by separate calls to <c>VirtualAlloc</c> or
		/// <c>VirtualAllocEx</c> using <c>MEM_RESERVE</c>.
		/// </para>
		/// </param>
		/// <param name="dwSize">
		/// The size of the region whose access protection attributes are to be changed, in bytes. The region of affected pages includes all pages containing one
		/// or more bytes in the range from the lpAddress parameter to . This means that a 2-byte range straddling a page boundary causes the protection
		/// attributes of both pages to be changed.
		/// </param>
		/// <param name="flNewProtect">
		/// <para>The memory protection option. This parameter can be one of the memory protection constants.</para>
		/// <para>
		/// For mapped views, this value must be compatible with the access protection specified when the view was mapped (see <c>MapViewOfFile</c>,
		/// <c>MapViewOfFileEx</c>, and <c>MapViewOfFileExNuma</c>).
		/// </para>
		/// </param>
		/// <param name="lpflOldProtect">
		/// A pointer to a variable that receives the previous access protection value of the first page in the specified region of pages. If this parameter is
		/// <c>NULL</c> or does not point to a valid variable, the function fails.
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is nonzero.</para>
		/// <para>If the function fails, the return value is zero. To get extended error information, call <c>GetLastError</c>.</para>
		/// </returns>
		// BOOL WINAPI VirtualProtect( _In_ LPVOID lpAddress, _In_ SIZE_T dwSize, _In_ DWORD flNewProtect, _Out_ PDWORD lpflOldProtect);
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("WinBase.h", MSDNShortId = "aa366898")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool VirtualProtect([In] IntPtr lpAddress, SizeT dwSize, MEM_PROTECTION flNewProtect, [Out] out MEM_PROTECTION lpflOldProtect);

		/// <summary>Changes the protection on a region of committed pages in the virtual address space of a specified process.</summary>
		/// <param name="hProcess">
		/// A handle to the process whose memory protection is to be changed. The handle must have the <c>PROCESS_VM_OPERATION</c> access right. For more
		/// information, see Process Security and Access Rights.
		/// </param>
		/// <param name="lpAddress">
		/// <para>A pointer to the base address of the region of pages whose access protection attributes are to be changed.</para>
		/// <para>
		/// All pages in the specified region must be within the same reserved region allocated when calling the <c>VirtualAlloc</c> or <c>VirtualAllocEx</c>
		/// function using <c>MEM_RESERVE</c>. The pages cannot span adjacent reserved regions that were allocated by separate calls to <c>VirtualAlloc</c> or
		/// <c>VirtualAllocEx</c> using <c>MEM_RESERVE</c>.
		/// </para>
		/// </param>
		/// <param name="dwSize">
		/// The size of the region whose access protection attributes are changed, in bytes. The region of affected pages includes all pages containing one or
		/// more bytes in the range from the lpAddress parameter to . This means that a 2-byte range straddling a page boundary causes the protection attributes
		/// of both pages to be changed.
		/// </param>
		/// <param name="flNewProtect">
		/// <para>The memory protection option. This parameter can be one of the memory protection constants.</para>
		/// <para>
		/// For mapped views, this value must be compatible with the access protection specified when the view was mapped (see <c>MapViewOfFile</c>,
		/// <c>MapViewOfFileEx</c>, and <c>MapViewOfFileExNuma</c>).
		/// </para>
		/// </param>
		/// <param name="lpflOldProtect">
		/// A pointer to a variable that receives the previous access protection of the first page in the specified region of pages. If this parameter is
		/// <c>NULL</c> or does not point to a valid variable, the function fails.
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is nonzero.</para>
		/// <para>If the function fails, the return value is zero. To get extended error information, call <c>GetLastError</c>.</para>
		/// </returns>
		// BOOL WINAPI VirtualProtectEx( _In_ HANDLE hProcess, _In_ LPVOID lpAddress, _In_ SIZE_T dwSize, _In_ DWORD flNewProtect, _Out_ PDWORD lpflOldProtect);
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("WinBase.h", MSDNShortId = "aa366899")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool VirtualProtectEx([In] IntPtr hProcess, [In] IntPtr lpAddress, SizeT dwSize, MEM_PROTECTION flNewProtect, [Out] out MEM_PROTECTION lpflOldProtect);

		/// <summary>Changes the protection on a region of committed pages in the virtual address space of the calling process.</summary>
		/// <param name="Address">
		/// <para>A pointer an address that describes the starting page of the region of pages whose access protection attributes are to be changed.</para>
		/// <para>
		/// All pages in the specified region must be within the same reserved region allocated when calling the <c>VirtualAlloc</c>, <c>VirtualAllocFromApp</c>,
		/// or <c>VirtualAllocEx</c> function using <c>MEM_RESERVE</c>. The pages cannot span adjacent reserved regions that were allocated by separate calls to
		/// <c>VirtualAlloc</c>, <c>VirtualAllocFromApp</c>, or <c>VirtualAllocEx</c> using <c>MEM_RESERVE</c>.
		/// </para>
		/// </param>
		/// <param name="Size">
		/// The size of the region whose access protection attributes are to be changed, in bytes. The region of affected pages includes all pages containing one
		/// or more bytes in the range from the Address parameter to . This means that a 2-byte range straddling a page boundary causes the protection attributes
		/// of both pages to be changed.
		/// </param>
		/// <param name="NewProtection">
		/// <para>The memory protection option. This parameter can be one of the memory protection constants.</para>
		/// <para>
		/// For mapped views, this value must be compatible with the access protection specified when the view was mapped (see <c>MapViewOfFile</c>,
		/// <c>MapViewOfFileEx</c>, and <c>MapViewOfFileExNuma</c>).
		/// </para>
		/// <para>The following constants generate an error:</para>
		/// <para>The following constants are allowed only for apps that have the <c>codeGeneration</c> capability:</para>
		/// </param>
		/// <param name="OldProtection">
		/// A pointer to a variable that receives the previous access protection value of the first page in the specified region of pages. If this parameter is
		/// <c>NULL</c> or does not point to a valid variable, the function fails.
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is nonzero.</para>
		/// <para>If the function fails, the return value is zero. To get extended error information, call <c>GetLastError</c>.</para>
		/// </returns>
		// BOOL WINAPI VirtualProtectFromApp( _In_ PVOID Address, _In_ SIZE_T Size, _In_ ULONG NewProtection, _Out_ PULONG OldProtection);
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("MemoryApi.h", MSDNShortId = "mt169846")]
		public static extern bool VirtualProtectFromApp([In] IntPtr Address, SizeT Size, MEM_PROTECTION NewProtection, [Out] out MEM_PROTECTION OldProtection);

		/// <summary>
		/// <para>Retrieves information about a range of pages in the virtual address space of the calling process.</para>
		/// <para>To retrieve information about a range of pages in the address space of another process, use the <c>VirtualQueryEx</c> function.</para>
		/// </summary>
		/// <param name="lpAddress">
		/// <para>
		/// A pointer to the base address of the region of pages to be queried. This value is rounded down to the next page boundary. To determine the size of a
		/// page on the host computer, use the <c>GetSystemInfo</c> function.
		/// </para>
		/// <para>If lpAddress specifies an address above the highest memory address accessible to the process, the function fails with <c>ERROR_INVALID_PARAMETER</c>.</para>
		/// </param>
		/// <param name="lpBuffer">A pointer to a <c>MEMORY_BASIC_INFORMATION</c> structure in which information about the specified page range is returned.</param>
		/// <param name="dwLength">The size of the buffer pointed to by the lpBuffer parameter, in bytes.</param>
		/// <returns>
		/// <para>The return value is the actual number of bytes returned in the information buffer.</para>
		/// <para>
		/// If the function fails, the return value is zero. To get extended error information, call <c>GetLastError</c>. Possible error values include <c>ERROR_INVALID_PARAMETER</c>.
		/// </para>
		/// </returns>
		// SIZE_T WINAPI VirtualQuery( _In_opt_ LPCVOID lpAddress, _Out_ PMEMORY_BASIC_INFORMATION lpBuffer, _In_ SIZE_T dwLength);
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("WinBase.h", MSDNShortId = "aa366902")]
		public static extern SizeT VirtualQuery([In] IntPtr lpAddress, IntPtr lpBuffer, SizeT dwLength);

		/// <summary>Retrieves information about a range of pages within the virtual address space of a specified process.</summary>
		/// <param name="hProcess">
		/// A handle to the process whose memory information is queried. The handle must have been opened with the <c>PROCESS_QUERY_INFORMATION</c> access right,
		/// which enables using the handle to read information from the process object. For more information, see Process Security and Access Rights.
		/// </param>
		/// <param name="lpAddress">
		/// <para>
		/// A pointer to the base address of the region of pages to be queried. This value is rounded down to the next page boundary. To determine the size of a
		/// page on the host computer, use the <c>GetSystemInfo</c> function.
		/// </para>
		/// <para>If lpAddress specifies an address above the highest memory address accessible to the process, the function fails with <c>ERROR_INVALID_PARAMETER</c>.</para>
		/// </param>
		/// <param name="lpBuffer">A pointer to a <c>MEMORY_BASIC_INFORMATION</c> structure in which information about the specified page range is returned.</param>
		/// <param name="dwLength">The size of the buffer pointed to by the lpBuffer parameter, in bytes.</param>
		/// <returns>
		/// <para>The return value is the actual number of bytes returned in the information buffer.</para>
		/// <para>
		/// If the function fails, the return value is zero. To get extended error information, call <c>GetLastError</c>. Possible error values include <c>ERROR_INVALID_PARAMETER</c>.
		/// </para>
		/// </returns>
		// SIZE_T WINAPI VirtualQueryEx( _In_ HANDLE hProcess, _In_opt_ LPCVOID lpAddress, _Out_ PMEMORY_BASIC_INFORMATION lpBuffer, _In_ SIZE_T dwLength);
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("WinBase.h", MSDNShortId = "aa366907")]
		public static extern SizeT VirtualQueryEx([In] IntPtr hProcess, [In] IntPtr lpAddress, IntPtr lpBuffer, SizeT dwLength);

		/// <summary>
		/// Unlocks a specified range of pages in the virtual address space of a process, enabling the system to swap the pages out to the
		/// paging file if necessary.
		/// </summary>
		/// <param name="lpAddress">A pointer to the base address of the region of pages to be unlocked.</param>
		/// <param name="dwSize">
		/// The size of the region being unlocked, in bytes. The region of affected pages includes all pages containing one or more bytes in
		/// the range from the lpAddress parameter to . This means that a 2-byte range straddling a page boundary causes both pages to be unlocked.
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is nonzero.</para>
		/// <para>If the function fails, the return value is zero. To get extended error information, call <c>GetLastError</c>.</para>
		/// </returns>
		// BOOL WINAPI VirtualUnlock( _In_ LPVOID lpAddress, _In_ SIZE_T dwSize); https://msdn.microsoft.com/en-us/library/windows/desktop/aa366910(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("WinBase.h", MSDNShortId = "aa366910")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool VirtualUnlock(IntPtr lpAddress, SizeT dwSize);

		/// <summary>Writes data to an area of memory in a specified process. The entire area to be written to must be accessible or the operation fails.</summary>
		/// <param name="hProcess">
		/// A handle to the process memory to be modified. The handle must have PROCESS_VM_WRITE and PROCESS_VM_OPERATION access to the process.
		/// </param>
		/// <param name="lpBaseAddress">
		/// A pointer to the base address in the specified process to which data is written. Before data transfer occurs, the system verifies that all data in
		/// the base address and memory of the specified size is accessible for write access, and if it is not accessible, the function fails.
		/// </param>
		/// <param name="lpBuffer">A pointer to the buffer that contains data to be written in the address space of the specified process.</param>
		/// <param name="nSize">The number of bytes to be written to the specified process.</param>
		/// <param name="lpNumberOfBytesWritten">
		/// A pointer to a variable that receives the number of bytes transferred into the specified process. This parameter is optional. If
		/// lpNumberOfBytesWritten is <c>NULL</c>, the parameter is ignored.
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is nonzero.</para>
		/// <para>
		/// If the function fails, the return value is 0 (zero). To get extended error information, call <c>GetLastError</c>. The function fails if the requested
		/// write operation crosses into an area of the process that is inaccessible.
		/// </para>
		/// </returns>
		// BOOL WINAPI WriteProcessMemory( _In_ HANDLE hProcess, _In_ LPVOID lpBaseAddress, _In_ LPCVOID lpBuffer, _In_ SIZE_T nSize, _Out_ SIZE_T *lpNumberOfBytesWritten);
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("WinBase.h", MSDNShortId = "ms681674")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool WriteProcessMemory([In] IntPtr hProcess, [In] IntPtr lpBaseAddress, [In] IntPtr lpBuffer, SizeT nSize, out SizeT lpNumberOfBytesWritten);

		/// <summary>Represents information about call targets for Control Flow Guard (CFG).</summary>
		// typedef struct _CFG_CALL_TARGET_INFO { ULONG_PTR Offset; ULONG_PTR Flags;} CFG_CALL_TARGET_INFO, *PCFG_CALL_TARGET_INFO;
		[PInvokeData("Ntmmapi.h", MSDNShortId = "mt219054")]
		public struct CFG_CALL_TARGET_INFO
		{
			/// <summary>
			/// Flags describing the operation to be performed on the address. If <c>CFG_CALL_TARGET_VALID</c> is set, then the address will be marked valid for
			/// CFG. Otherwise, it will be marked an invalid call target.
			/// </summary>
			public UIntPtr Flags;
			/// <summary>Offset relative to a provided (start) virtual address. This offset should be 16 byte aligned.</summary>
			public UIntPtr Offset;
		}

		/// <summary>Specifies a range of memory. This structure is used by the <c>PrefetchVirtualMemory</c> function.</summary>
		// typedef struct _WIN32_MEMORY_RANGE_ENTRY { PVOID VirtualAddress; SIZE_T NumberOfBytes;} WIN32_MEMORY_RANGE_ENTRY, *PWIN32_MEMORY_RANGE_ENTRY;
		[PInvokeData("WinBase.h", MSDNShortId = "hh780544")]
		public struct WIN32_MEMORY_RANGE_ENTRY
		{
			/// <summary></summary>
			public SizeT NumberOfBytes;
			/// <summary></summary>
			public IntPtr VirtualAddress;
		}
	}
}