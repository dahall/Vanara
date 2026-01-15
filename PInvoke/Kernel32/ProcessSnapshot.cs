using System.Collections.Generic;

namespace Vanara.PInvoke;

public static partial class Kernel32
{
	/// <summary>The resolution in microseconds of the performance counters in PSS_PERFORMANCE_COUNTERS.</summary>
	[PInvokeData("processsnapshot.h")]
	public const uint PSS_PERF_RESOLUTION = 1000000;

	/// <summary>Flags that specify what PssCaptureSnapshot captures.</summary>
	/// <remarks>
	/// If both <c>PSS_CREATE_FORCE_BREAKAWAY</c> and <c>PSS_CREATE_BREAKAWAY</c> are specified, then <c>PSS_CREATE_FORCE_BREAKAWAY</c> takes precedence.
	/// </remarks>
	// https://docs.microsoft.com/en-us/previous-versions/windows/desktop/api/processsnapshot/ne-processsnapshot-pss_capture_flags typedef
	// enum PSS_CAPTURE_FLAGS { PSS_CAPTURE_NONE , PSS_CAPTURE_VA_CLONE , PSS_CAPTURE_RESERVED_00000002 , PSS_CAPTURE_HANDLES ,
	// PSS_CAPTURE_HANDLE_NAME_INFORMATION , PSS_CAPTURE_HANDLE_BASIC_INFORMATION , PSS_CAPTURE_HANDLE_TYPE_SPECIFIC_INFORMATION ,
	// PSS_CAPTURE_HANDLE_TRACE , PSS_CAPTURE_THREADS , PSS_CAPTURE_THREAD_CONTEXT , PSS_CAPTURE_THREAD_CONTEXT_EXTENDED ,
	// PSS_CAPTURE_RESERVED_00000400 , PSS_CAPTURE_VA_SPACE , PSS_CAPTURE_VA_SPACE_SECTION_INFORMATION , PSS_CAPTURE_IPT_TRACE ,
	// PSS_CREATE_BREAKAWAY_OPTIONAL , PSS_CREATE_BREAKAWAY , PSS_CREATE_FORCE_BREAKAWAY , PSS_CREATE_USE_VM_ALLOCATIONS ,
	// PSS_CREATE_MEASURE_PERFORMANCE , PSS_CREATE_RELEASE_SECTION } ;
	[PInvokeData("processsnapshot.h", MSDNShortId = "6146DDA2-2475-45F8-86F3-65791B10743D")]
	[Flags]
	public enum PSS_CAPTURE_FLAGS : uint
	{
		/// <summary>Capture nothing.</summary>
		PSS_CAPTURE_NONE = 0x00000000,

		/// <summary>
		/// Capture a snapshot of all cloneable pages in the process. The clone includes all MEM_PRIVATE regions, as well as all sections
		/// (MEM_MAPPED and MEM_IMAGE) that are shareable. All Win32 sections created via CreateFileMapping are shareable.
		/// </summary>
		PSS_CAPTURE_VA_CLONE = 0x00000001,

		/// <summary>(Do not use.)</summary>
		PSS_CAPTURE_RESERVED_00000002 = 0x00000002,

		/// <summary>Capture the handle table (handle values only).</summary>
		PSS_CAPTURE_HANDLES = 0x00000004,

		/// <summary>Capture name information for each handle.</summary>
		PSS_CAPTURE_HANDLE_NAME_INFORMATION = 0x00000008,

		/// <summary>Capture basic handle information such as HandleCount, PointerCount, GrantedAccess, etc.</summary>
		PSS_CAPTURE_HANDLE_BASIC_INFORMATION = 0x00000010,

		/// <summary>Capture type-specific information for supported object types: Process, Thread, Event, Mutant, Section.</summary>
		PSS_CAPTURE_HANDLE_TYPE_SPECIFIC_INFORMATION = 0x00000020,

		/// <summary>Capture the handle tracing table.</summary>
		PSS_CAPTURE_HANDLE_TRACE = 0x00000040,

		/// <summary>Capture thread information (IDs only).</summary>
		PSS_CAPTURE_THREADS = 0x00000080,

		/// <summary>Capture the context for each thread.</summary>
		PSS_CAPTURE_THREAD_CONTEXT = 0x00000100,

		/// <summary>Capture extended context for each thread (e.g. CONTEXT_XSTATE).</summary>
		PSS_CAPTURE_THREAD_CONTEXT_EXTENDED = 0x00000200,

		/// <summary>(Do not use.)</summary>
		PSS_CAPTURE_RESERVED_00000400 = 0x00000400,

		/// <summary>
		/// Capture a snapshot of the virtual address space. The VA space is captured as an array of MEMORY_BASIC_INFORMATION structures.
		/// This flag does not capture the contents of the pages.
		/// </summary>
		PSS_CAPTURE_VA_SPACE = 0x00000800,

		/// <summary>
		/// For MEM_IMAGE and MEM_MAPPED regions, dumps the path to the file backing the sections (identical to what GetMappedFileName
		/// returns). For MEM_IMAGE regions, also dumps: The PROCESS_VM_READ access right is required on the process handle.
		/// </summary>
		PSS_CAPTURE_VA_SPACE_SECTION_INFORMATION = 0x00001000,

		/// <summary>The PSS capture ipt trace</summary>
		PSS_CAPTURE_IPT_TRACE = 0x00002000,

		/// <summary>
		/// The breakaway is optional. If the clone process fails to create as a breakaway, then it is created still inside the job. This
		/// flag must be specified in combination with either PSS_CREATE_FORCE_BREAKAWAY and/or PSS_CREATE_BREAKAWAY.
		/// </summary>
		PSS_CREATE_BREAKAWAY_OPTIONAL = 0x04000000,

		/// <summary>The clone is broken away from the parent process' job. This is equivalent to CreateProcess flag CREATE_BREAKAWAY_FROM_JOB.</summary>
		PSS_CREATE_BREAKAWAY = 0x08000000,

		/// <summary>The clone is forcefully broken away the parent process's job. This is only allowed for Tcb-privileged callers.</summary>
		PSS_CREATE_FORCE_BREAKAWAY = 0x10000000,

		/// <summary>
		/// The facility should not use the process heap for any persistent or transient allocations. The use of the heap may be undesirable
		/// in certain contexts such as creation of snapshots in the exception reporting path (where the heap may be corrupted).
		/// </summary>
		PSS_CREATE_USE_VM_ALLOCATIONS = 0x20000000,

		/// <summary>
		/// Measure performance of the facility. Performance counters can be retrieved via PssQuerySnapshot with the
		/// PSS_QUERY_PERFORMANCE_COUNTERS information class of PSS_QUERY_INFORMATION_CLASS.
		/// </summary>
		PSS_CREATE_MEASURE_PERFORMANCE = 0x40000000,

		/// <summary>
		/// The virtual address (VA) clone process does not hold a reference to the underlying image. This will cause functions such as
		/// QueryFullProcessImageName to fail on the VA clone process.
		/// </summary>
		PSS_CREATE_RELEASE_SECTION = 0x80000000
	}

	/// <summary>Duplication flags for use by PssDuplicateSnapshot.</summary>
	// https://docs.microsoft.com/en-us/previous-versions/windows/desktop/api/processsnapshot/ne-processsnapshot-pss_duplicate_flags typedef
	// enum PSS_DUPLICATE_FLAGS { PSS_DUPLICATE_NONE , PSS_DUPLICATE_CLOSE_SOURCE } ;
	[PInvokeData("processsnapshot.h", MSDNShortId = "CAD06441-750F-42FC-A95A-7CAA79F31348")]
	[Flags]
	public enum PSS_DUPLICATE_FLAGS
	{
		/// <summary>No flag.</summary>
		PSS_DUPLICATE_NONE = 0x00,

		/// <summary>
		/// Free the source handle. This will only succeed if you set the PSS_CREATE_USE_VM_ALLOCATIONS flag when you called
		/// PssCaptureSnapshot to create the snapshot and handle. The handle will be freed even if duplication fails. The close operation
		/// does not protect against concurrent access to the same descriptor.
		/// </summary>
		PSS_DUPLICATE_CLOSE_SOURCE = 0x01
	}

	/// <summary>Flags to specify what parts of a PSS_HANDLE_ENTRY structure are valid.</summary>
	// https://docs.microsoft.com/en-us/previous-versions/windows/desktop/api/processsnapshot/ne-processsnapshot-pss_handle_flags typedef
	// enum PSS_HANDLE_FLAGS { PSS_HANDLE_NONE , PSS_HANDLE_HAVE_TYPE , PSS_HANDLE_HAVE_NAME , PSS_HANDLE_HAVE_BASIC_INFORMATION ,
	// PSS_HANDLE_HAVE_TYPE_SPECIFIC_INFORMATION } ;
	[PInvokeData("processsnapshot.h", MSDNShortId = "A4A604A9-0210-413C-BCAC-F8458B371D42")]
	[Flags]
	public enum PSS_HANDLE_FLAGS
	{
		/// <summary>No parts specified.</summary>
		PSS_HANDLE_NONE = 0x00,

		/// <summary>The ObjectType member is valid.</summary>
		PSS_HANDLE_HAVE_TYPE = 0x01,

		/// <summary>The ObjectName member is valid.</summary>
		PSS_HANDLE_HAVE_NAME = 0x02,

		/// <summary>The Attributes, GrantedAccess, HandleCount, PointerCount, PagedPoolCharge, and NonPagedPoolCharge members are valid.</summary>
		PSS_HANDLE_HAVE_BASIC_INFORMATION = 0x04,

		/// <summary>The TypeSpecificInformation member is valid (either Process, Thread, Mutant, Event or Section).</summary>
		PSS_HANDLE_HAVE_TYPE_SPECIFIC_INFORMATION = 0x08
	}

	/// <summary>Specifies the object type in a PSS_HANDLE_ENTRY structure.</summary>
	// https://docs.microsoft.com/en-us/previous-versions/windows/desktop/api/processsnapshot/ne-processsnapshot-pss_object_type typedef enum
	// PSS_OBJECT_TYPE { PSS_OBJECT_TYPE_UNKNOWN , PSS_OBJECT_TYPE_PROCESS , PSS_OBJECT_TYPE_THREAD , PSS_OBJECT_TYPE_MUTANT ,
	// PSS_OBJECT_TYPE_EVENT , PSS_OBJECT_TYPE_SECTION , PSS_OBJECT_TYPE_SEMAPHORE } ;
	[PInvokeData("processsnapshot.h", MSDNShortId = "3AF2AE47-6E1A-4B20-B6A3-36C1DDB80674")]
	public enum PSS_OBJECT_TYPE
	{
		/// <summary>The object type is either unknown or unsupported.</summary>
		PSS_OBJECT_TYPE_UNKNOWN,

		/// <summary>The object is a process.</summary>
		PSS_OBJECT_TYPE_PROCESS,

		/// <summary>The object is a thread.</summary>
		PSS_OBJECT_TYPE_THREAD,

		/// <summary>The object is a mutant/mutex.</summary>
		PSS_OBJECT_TYPE_MUTANT,

		/// <summary>The object is an event.</summary>
		PSS_OBJECT_TYPE_EVENT,

		/// <summary>The object is a file-mapping object.</summary>
		PSS_OBJECT_TYPE_SECTION,

		/// <summary>The PSS object type semaphore</summary>
		PSS_OBJECT_TYPE_SEMAPHORE,
	}

	/// <summary>Flags that describe a process.</summary>
	/// <remarks>There are <c>PSS_PROCESS_FLAGS</c> members in the PSS_PROCESS_INFORMATION and PSS_HANDLE_ENTRY structures.</remarks>
	// https://docs.microsoft.com/en-us/previous-versions/windows/desktop/api/processsnapshot/ne-processsnapshot-pss_process_flags typedef
	// enum PSS_PROCESS_FLAGS { PSS_PROCESS_FLAGS_NONE , PSS_PROCESS_FLAGS_PROTECTED , PSS_PROCESS_FLAGS_WOW64 ,
	// PSS_PROCESS_FLAGS_RESERVED_03 , PSS_PROCESS_FLAGS_RESERVED_04 , PSS_PROCESS_FLAGS_FROZEN } ;
	[PInvokeData("processsnapshot.h", MSDNShortId = "A1C793DD-EE93-47B6-8EA8-3A45DAD55F2D")]
	[Flags]
	public enum PSS_PROCESS_FLAGS
	{
		/// <summary>No flag.</summary>
		PSS_PROCESS_FLAGS_NONE = 0x00000000,

		/// <summary>The process is protected.</summary>
		PSS_PROCESS_FLAGS_PROTECTED = 0x00000001,

		/// <summary>The process is a 32-bit process running on a 64-bit native OS.</summary>
		PSS_PROCESS_FLAGS_WOW64 = 0x00000002,

		/// <summary>Undefined.</summary>
		PSS_PROCESS_FLAGS_RESERVED_03 = 0x00000004,

		/// <summary>Undefined.</summary>
		PSS_PROCESS_FLAGS_RESERVED_04 = 0x00000008,

		/// <summary>
		/// The process is frozen; for example, a debugger is attached and broken into the process or a Store process is suspended by a
		/// lifetime management service.
		/// </summary>
		PSS_PROCESS_FLAGS_FROZEN = 0x00000010
	}

	/// <summary>Specifies what information PssQuerySnapshot function returns.</summary>
	// https://docs.microsoft.com/en-us/previous-versions/windows/desktop/api/processsnapshot/ne-processsnapshot-pss_query_information_class
	// typedef enum PSS_QUERY_INFORMATION_CLASS { PSS_QUERY_PROCESS_INFORMATION , PSS_QUERY_VA_CLONE_INFORMATION ,
	// PSS_QUERY_AUXILIARY_PAGES_INFORMATION , PSS_QUERY_VA_SPACE_INFORMATION , PSS_QUERY_HANDLE_INFORMATION , PSS_QUERY_THREAD_INFORMATION ,
	// PSS_QUERY_HANDLE_TRACE_INFORMATION , PSS_QUERY_PERFORMANCE_COUNTERS } ;
	[PInvokeData("processsnapshot.h", MSDNShortId = "1C3E5BF4-5AC9-4012-B29D-49C35C0AF90B")]
	public enum PSS_QUERY_INFORMATION_CLASS
	{
		/// <summary>Returns a PSS_PROCESS_INFORMATION structure, with information about the original process.</summary>
		[CorrespondingType(typeof(PSS_PROCESS_INFORMATION), CorrespondingAction.Get)]
		PSS_QUERY_PROCESS_INFORMATION,

		/// <summary>Returns a PSS_VA_CLONE_INFORMATION structure, with a handle to the VA clone.</summary>
		[CorrespondingType(typeof(PSS_VA_CLONE_INFORMATION), CorrespondingAction.Get)]
		PSS_QUERY_VA_CLONE_INFORMATION,

		/// <summary>Returns a PSS_AUXILIARY_PAGES_INFORMATION structure, which contains the count of auxiliary pages captured.</summary>
		[CorrespondingType(typeof(PSS_AUXILIARY_PAGES_INFORMATION), CorrespondingAction.Get)]
		PSS_QUERY_AUXILIARY_PAGES_INFORMATION,

		/// <summary>Returns a PSS_VA_SPACE_INFORMATION structure, which contains the count of regions captured.</summary>
		[CorrespondingType(typeof(PSS_VA_SPACE_INFORMATION), CorrespondingAction.Get)]
		PSS_QUERY_VA_SPACE_INFORMATION,

		/// <summary>Returns a PSS_HANDLE_INFORMATION structure, which contains the count of handles captured.</summary>
		[CorrespondingType(typeof(PSS_HANDLE_INFORMATION), CorrespondingAction.Get)]
		PSS_QUERY_HANDLE_INFORMATION,

		/// <summary>Returns a PSS_THREAD_INFORMATION structure, which contains the count of threads captured.</summary>
		[CorrespondingType(typeof(PSS_THREAD_INFORMATION), CorrespondingAction.Get)]
		PSS_QUERY_THREAD_INFORMATION,

		/// <summary>Returns a PSS_HANDLE_TRACE_INFORMATION structure, which contains a handle to the handle trace section, and its size.</summary>
		[CorrespondingType(typeof(PSS_HANDLE_TRACE_INFORMATION), CorrespondingAction.Get)]
		PSS_QUERY_HANDLE_TRACE_INFORMATION,

		/// <summary>Returns a PSS_PERFORMANCE_COUNTERS structure, which contains various performance counters.</summary>
		[CorrespondingType(typeof(PSS_PERFORMANCE_COUNTERS), CorrespondingAction.Get)]
		PSS_QUERY_PERFORMANCE_COUNTERS,
	}

	/// <summary>Flags that describe a thread.</summary>
	/// <remarks>There is a <c>PSS_THREAD_FLAGS</c> member in the PSS_THREAD_ENTRY structure that PssWalkSnapshot returns.</remarks>
	// https://docs.microsoft.com/en-us/previous-versions/windows/desktop/api/processsnapshot/ne-processsnapshot-pss_thread_flags typedef
	// enum PSS_THREAD_FLAGS { PSS_THREAD_FLAGS_NONE , PSS_THREAD_FLAGS_TERMINATED } ;
	[PInvokeData("processsnapshot.h", MSDNShortId = "8E90F0EA-D50A-431D-9507-B882EB673629")]
	[Flags]
	public enum PSS_THREAD_FLAGS
	{
		/// <summary>No flag.</summary>
		PSS_THREAD_FLAGS_NONE = 0x0000,

		/// <summary>The thread terminated.</summary>
		PSS_THREAD_FLAGS_TERMINATED = 0x0001
	}

	/// <summary>Specifies what information the PssWalkSnapshot function returns.</summary>
	// https://docs.microsoft.com/en-us/previous-versions/windows/desktop/api/processsnapshot/ne-processsnapshot-pss_walk_information_class
	// typedef enum PSS_WALK_INFORMATION_CLASS { PSS_WALK_AUXILIARY_PAGES , PSS_WALK_VA_SPACE , PSS_WALK_HANDLES , PSS_WALK_THREADS } ;
	[PInvokeData("processsnapshot.h", MSDNShortId = "93A79F7F-2164-4F7A-ADE7-C1655EEFC9BF")]
	public enum PSS_WALK_INFORMATION_CLASS
	{
		/// <summary>
		/// Returns a PSS_AUXILIARY_PAGE_ENTRY structure, which contains the address, page attributes and contents of an auxiliary copied page.
		/// </summary>
		[CorrespondingType(typeof(PSS_AUXILIARY_PAGE_ENTRY), CorrespondingAction.Get)]
		PSS_WALK_AUXILIARY_PAGES,

		/// <summary>
		/// Returns a PSS_VA_SPACE_ENTRY structure, which contains the MEMORY_BASIC_INFORMATION structure for every distinct VA region.
		/// </summary>
		[CorrespondingType(typeof(PSS_VA_SPACE_ENTRY), CorrespondingAction.Get)]
		PSS_WALK_VA_SPACE,

		/// <summary>
		/// Returns a PSS_HANDLE_ENTRY structure, with information specifying the handle value, its type name, object name (if captured),
		/// basic information (if captured), and type-specific information (if captured).
		/// </summary>
		[CorrespondingType(typeof(PSS_HANDLE_ENTRY), CorrespondingAction.Get)]
		PSS_WALK_HANDLES,

		/// <summary>
		/// Returns a PSS_THREAD_ENTRY structure, with basic information about the thread, as well as its termination state, suspend count
		/// and Win32 start address.
		/// </summary>
		[CorrespondingType(typeof(PSS_THREAD_ENTRY), CorrespondingAction.Get)]
		PSS_WALK_THREADS,
	}

	/// <summary>Captures a snapshot of a target process.</summary>
	/// <param name="ProcessHandle">A handle to the target process.</param>
	/// <param name="CaptureFlags">Flags that specify what to capture. For more information, see PSS_CAPTURE_FLAGS.</param>
	/// <param name="ThreadContextFlags">The <see cref="CONTEXT_FLAG"/> record flags to capture if CaptureFlags specifies thread contexts.</param>
	/// <param name="SnapshotHandle">A handle to the snapshot that this function captures.</param>
	/// <returns>
	/// <para>This function returns <c>ERROR_SUCCESS</c> on success.</para>
	/// <para>
	/// All error codes are defined in winerror.h. Use FormatMessage with the <c>FORMAT_MESSAGE_FROM_SYSTEM</c> flag to get a message for an
	/// error code.
	/// </para>
	/// </returns>
	// https://docs.microsoft.com/en-us/previous-versions/windows/desktop/api/processsnapshot/nf-processsnapshot-psscapturesnapshot DWORD
	// PssCaptureSnapshot( HANDLE ProcessHandle, PSS_CAPTURE_FLAGS CaptureFlags, DWORD ThreadContextFlags, HPSS *SnapshotHandle );
	[PInvokeData("processsnapshot.h", MSDNShortId = "44F2CB48-A9F6-4131-B21C-9F27A27CECD5")]
	public static Win32Error PssCaptureSnapshot(HPROCESS ProcessHandle, PSS_CAPTURE_FLAGS CaptureFlags, uint ThreadContextFlags, [AddAsCtor] out SafeHPSS SnapshotHandle)
	{
		var err = PssCaptureSnapshotInternal(ProcessHandle, CaptureFlags, ThreadContextFlags, out SnapshotHandle);
		SnapshotHandle.ProcessHandle = ProcessHandle;
		return err;
	}

	/// <summary>Duplicates a snapshot handle from one process to another.</summary>
	/// <param name="SourceProcessHandle">
	/// A handle to the source process from which the original snapshot was captured. The handle must have <c>PROCESS_VM_READ</c> and
	/// <c>PROCESS_DUP_HANDLE</c> rights.
	/// </param>
	/// <param name="SnapshotHandle">A handle to the snapshot to duplicate. This handle must be in the context of the source process.</param>
	/// <param name="TargetProcessHandle">
	/// A handle to the target process that receives the duplicate snapshot. The handle must have <c>PROCESS_VM_OPERATION</c>,
	/// <c>PROCESS_VM_WRITE</c>, and <c>PROCESS_DUP_HANDLE</c> rights.
	/// </param>
	/// <param name="TargetSnapshotHandle">A handle to the duplicate snapshot that this function creates, in the context of the target process.</param>
	/// <param name="Flags">The duplication flags. For more information, see PSS_DUPLICATE_FLAGS.</param>
	/// <returns>
	/// <para>This function returns <c>ERROR_SUCCESS</c> on success or the following error code.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_INVALID_HANDLE</term>
	/// <term>The specified handle is invalid.</term>
	/// </item>
	/// </list>
	/// <para>
	/// All error codes are defined in winerror.h. Use FormatMessage with the <c>FORMAT_MESSAGE_FROM_SYSTEM</c> flag to get a message for an
	/// error code.
	/// </para>
	/// </returns>
	// https://docs.microsoft.com/en-us/previous-versions/windows/desktop/api/processsnapshot/nf-processsnapshot-pssduplicatesnapshot DWORD
	// PssDuplicateSnapshot( HANDLE SourceProcessHandle, HPSS SnapshotHandle, HANDLE TargetProcessHandle, HPSS
	// *TargetSnapshotHandle, PSS_DUPLICATE_FLAGS Flags );
	[PInvokeData("processsnapshot.h", MSDNShortId = "5D2751F3-E7E1-4917-8060-E2BC8A7A3DEA")]
	public static Win32Error PssDuplicateSnapshot(HPROCESS SourceProcessHandle, [AddAsMember] HPSS SnapshotHandle, HPROCESS TargetProcessHandle, out SafeHPSS TargetSnapshotHandle, PSS_DUPLICATE_FLAGS Flags)
	{
		var err = PssDuplicateSnapshot(SourceProcessHandle, SnapshotHandle, TargetProcessHandle, out TargetSnapshotHandle, Flags);
		TargetSnapshotHandle.ProcessHandle = TargetProcessHandle;
		return err;
	}

	/// <summary>Frees a snapshot.</summary>
	/// <param name="ProcessHandle">
	/// A handle to the process that contains the snapshot. The handle must have <c>PROCESS_VM_READ</c>, <c>PROCESS_VM_OPERATION</c>, and
	/// <c>PROCESS_DUP_HANDLE</c> rights. If the snapshot was captured from the current process, or duplicated into the current process, then
	/// pass in the result of GetCurrentProcess.
	/// </param>
	/// <param name="SnapshotHandle">A handle to the snapshot to free.</param>
	/// <returns>
	/// <para>This function returns <c>ERROR_SUCCESS</c> on success or one of the following error codes.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_INVALID_HANDLE</term>
	/// <term>The specified handle is invalid.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_NOT_SUPPORTED</term>
	/// <term>The remote snapshot was not created with PSS_CREATE_USE_VM_ALLOCATIONS.</term>
	/// </item>
	/// </list>
	/// <para>
	/// All error codes are defined in winerror.h. Use FormatMessage with the <c>FORMAT_MESSAGE_FROM_SYSTEM</c> flag to get a message for an
	/// error code.
	/// </para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// This API can free snapshot handles in the context of either the local or remote processes. If the snapshot was captured in the local
	/// process with PssCaptureSnapshot, or duplicated into the local process with PssDuplicateSnapshot, then specify the result of
	/// GetCurrentProcess as the process handle. If the snapshot is in the context of a remote process (for example, duplicated into the
	/// remote process), then specify the handle to that process.
	/// </para>
	/// <para>The operation does not protect against concurrent access to the same descriptor.</para>
	/// <para>
	/// For remote process frees, only snapshot handles that were created with <c>PSS_CREATE_USE_VM_ALLOCATIONS</c> or duplicated remotely
	/// can be freed by this API.
	/// </para>
	/// <para>The behavior of this routine on a descriptor that has already been freed is undefined.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/previous-versions/windows/desktop/api/processsnapshot/nf-processsnapshot-pssfreesnapshot DWORD
	// PssFreeSnapshot( HANDLE ProcessHandle, HPSS SnapshotHandle );
	[DllImport(Lib.Kernel32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("processsnapshot.h", MSDNShortId = "5D062AE6-2F7C-4121-AB6E-9BFA06AB36C6")]
	public static extern Win32Error PssFreeSnapshot(HPROCESS ProcessHandle, HPSS SnapshotHandle);

	/// <summary>Queries the snapshot.</summary>
	/// <param name="SnapshotHandle">A handle to the snapshot to query.</param>
	/// <param name="InformationClass">An enumerator member that selects what information to query. For more information, see PSS_QUERY_INFORMATION_CLASS.</param>
	/// <param name="Buffer">The information that this function provides.</param>
	/// <param name="BufferLength">The size of Buffer, in bytes.</param>
	/// <returns>
	/// <para>This function returns <c>ERROR_SUCCESS</c> on success or one of the following error codes.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_BAD_LENGTH</term>
	/// <term>The specified buffer length is invalid.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_HANDLE</term>
	/// <term>The specified handle is invalid.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_PARAMETER</term>
	/// <term>The specified information class is invalid.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_NOT_FOUND</term>
	/// <term>The requested information is not in the snapshot.</term>
	/// </item>
	/// </list>
	/// <para>
	/// All error codes are defined in winerror.h. Use FormatMessage with the <c>FORMAT_MESSAGE_FROM_SYSTEM</c> flag to get a message for an
	/// error code.
	/// </para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/desktop/api/processsnapshot/nf-processsnapshot-pssquerysnapshot DWORD PssQuerySnapshot( HPSS
	// SnapshotHandle, PSS_QUERY_INFORMATION_CLASS InformationClass, void *Buffer, DWORD BufferLength );
	[DllImport(Lib.Kernel32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("processsnapshot.h", MSDNShortId = "D9580147-28ED-4FF5-B7DB-844ACB19769F")]
	public static extern Win32Error PssQuerySnapshot(HPSS SnapshotHandle, PSS_QUERY_INFORMATION_CLASS InformationClass, IntPtr Buffer, uint BufferLength);

	/// <summary>Queries the snapshot.</summary>
	/// <typeparam name="T">The type of the information to retrieve specified by <paramref name="InformationClass"/>.</typeparam>
	/// <param name="SnapshotHandle">A handle to the snapshot to query.</param>
	/// <param name="InformationClass">An enumerator member that selects what information to query. For more information, see PSS_QUERY_INFORMATION_CLASS.</param>
	/// <returns>The information that this function provides.</returns>
	/// <exception cref="ArgumentOutOfRangeException">InformationClass</exception>
	/// <exception cref="ArgumentOutOfRangeException">InformationClass</exception>
	public static T PssQuerySnapshot<T>([AddAsMember] HPSS SnapshotHandle, PSS_QUERY_INFORMATION_CLASS InformationClass) where T : struct
	{
		if (!CorrespondingTypeAttribute.CanGet(InformationClass, typeof(T))) throw new ArgumentOutOfRangeException(nameof(InformationClass));
		using var mem = SafeCoTaskMemHandle.CreateFromStructure<T>();
		PssQuerySnapshot(SnapshotHandle, InformationClass, (IntPtr)mem, (uint)mem.Size).ThrowIfFailed();
		return mem.ToStructure<T>();
	}

	/// <summary>Creates a walk marker.</summary>
	/// <param name="Allocator">
	/// A structure that provides functions to allocate and free memory. If you provide the structure, <c>PssWalkMarkerCreate</c> uses the
	/// functions to allocate the internal walk marker structures. Otherwise it uses the default process heap. For more information, see PSS_ALLOCATOR.
	/// </param>
	/// <param name="WalkMarkerHandle">A handle to the walk marker that this function creates.</param>
	/// <returns>
	/// <para>This function returns <c>ERROR_SUCCESS</c> on success or the following error code.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_NOT_ENOUGH_MEMORY</term>
	/// <term>Could not allocate memory for the walk marker.</term>
	/// </item>
	/// </list>
	/// <para>
	/// All error codes are defined in winerror.h. Use FormatMessage with the <c>FORMAT_MESSAGE_FROM_SYSTEM</c> flag to get a message for an
	/// error code.
	/// </para>
	/// </returns>
	/// <remarks>
	/// <para>The walk marker maintains the state of a walk, and can be used to reposition or rewind the walk.</para>
	/// <para>
	/// The Allocator structure that provides the custom functions should remain valid for the lifetime of the walk marker. The custom
	/// functions are called from <c>PssWalkMarkerCreate</c>, PssWalkMarkerFree and PssWalkSnapshot using the same thread that calls
	/// <c>PssWalkMarkerCreate</c>, <c>PssWalkMarkerFree</c> and <c>PssWalkSnapshot</c>. Therefore the custom functions need not be multi-threaded.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/previous-versions/windows/desktop/api/processsnapshot/nf-processsnapshot-psswalkmarkercreate DWORD
	// PssWalkMarkerCreate( PSS_ALLOCATOR const *Allocator, HPSSWALK *WalkMarkerHandle );
	[DllImport(Lib.Kernel32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("processsnapshot.h", MSDNShortId = "58E2FBAF-661C-45BE-A25A-A096AF52ED3E")]
	public static extern Win32Error PssWalkMarkerCreate(in PSS_ALLOCATOR Allocator, [AddAsCtor] out SafeHPSSWALK WalkMarkerHandle);

	/// <summary>Creates a walk marker.</summary>
	/// <param name="Allocator">
	/// A structure that provides functions to allocate and free memory. If you provide the structure, <c>PssWalkMarkerCreate</c> uses the
	/// functions to allocate the internal walk marker structures. Otherwise it uses the default process heap. For more information, see PSS_ALLOCATOR.
	/// </param>
	/// <param name="WalkMarkerHandle">A handle to the walk marker that this function creates.</param>
	/// <returns>
	/// <para>This function returns <c>ERROR_SUCCESS</c> on success or the following error code.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_NOT_ENOUGH_MEMORY</term>
	/// <term>Could not allocate memory for the walk marker.</term>
	/// </item>
	/// </list>
	/// <para>
	/// All error codes are defined in winerror.h. Use FormatMessage with the <c>FORMAT_MESSAGE_FROM_SYSTEM</c> flag to get a message for an
	/// error code.
	/// </para>
	/// </returns>
	/// <remarks>
	/// <para>The walk marker maintains the state of a walk, and can be used to reposition or rewind the walk.</para>
	/// <para>
	/// The Allocator structure that provides the custom functions should remain valid for the lifetime of the walk marker. The custom
	/// functions are called from <c>PssWalkMarkerCreate</c>, PssWalkMarkerFree and PssWalkSnapshot using the same thread that calls
	/// <c>PssWalkMarkerCreate</c>, <c>PssWalkMarkerFree</c> and <c>PssWalkSnapshot</c>. Therefore the custom functions need not be multi-threaded.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/previous-versions/windows/desktop/api/processsnapshot/nf-processsnapshot-psswalkmarkercreate DWORD
	// PssWalkMarkerCreate( PSS_ALLOCATOR const *Allocator, HPSSWALK *WalkMarkerHandle );
	[DllImport(Lib.Kernel32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("processsnapshot.h", MSDNShortId = "58E2FBAF-661C-45BE-A25A-A096AF52ED3E")]
	public static extern Win32Error PssWalkMarkerCreate([Optional] IntPtr Allocator, out SafeHPSSWALK WalkMarkerHandle);

	/// <summary>Frees a walk marker created by PssWalkMarkerCreate.</summary>
	/// <param name="WalkMarkerHandle">A handle to the walk marker.</param>
	/// <returns>
	/// <para>This function returns <c>ERROR_SUCCESS</c> on success.</para>
	/// <para>
	/// All error codes are defined in winerror.h. Use FormatMessage with the <c>FORMAT_MESSAGE_FROM_SYSTEM</c> flag to get a message for an
	/// error code.
	/// </para>
	/// </returns>
	/// <remarks>
	/// If PssWalkMarkerCreate used <c>AllocRoutine</c> of a custom allocator to create the walk marker, <c>PssWalkMarkerFree</c> uses the
	/// <c>FreeRoutine</c> of the allocator.
	/// </remarks>
	// https://docs.microsoft.com/en-us/previous-versions/windows/desktop/api/processsnapshot/nf-processsnapshot-psswalkmarkerfree DWORD
	// PssWalkMarkerFree( HPSSWALK WalkMarkerHandle );
	[DllImport(Lib.Kernel32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("processsnapshot.h", MSDNShortId = "74158846-6A5F-4F81-B4D7-46DED1EE017C")]
	public static extern Win32Error PssWalkMarkerFree(HPSSWALK WalkMarkerHandle);

	/// <summary>Returns the current position of a walk marker.</summary>
	/// <param name="WalkMarkerHandle">A handle to the walk marker.</param>
	/// <param name="Position">The walk marker position that this function returns.</param>
	/// <returns>
	/// <para>This function returns <c>ERROR_SUCCESS</c> on success.</para>
	/// <para>
	/// All error codes are defined in winerror.h. Use FormatMessage with the <c>FORMAT_MESSAGE_FROM_SYSTEM</c> flag to get a message for an
	/// error code.
	/// </para>
	/// </returns>
	/// <remarks>
	/// The position value compared to the values of other positions is not of any significance. The only valid use of the position is to set
	/// the current position using the PssWalkMarkerSetPosition function.
	/// </remarks>
	// https://docs.microsoft.com/en-us/previous-versions/windows/desktop/api/processsnapshot/nf-processsnapshot-psswalkmarkergetposition
	// DWORD PssWalkMarkerGetPosition( HPSSWALK WalkMarkerHandle, ULONG_PTR *Position );
	[DllImport(Lib.Kernel32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("processsnapshot.h", MSDNShortId = "A2058E81-2B01-4436-ACC6-2A3E58BC4E27")]
	public static extern Win32Error PssWalkMarkerGetPosition([AddAsMember] HPSSWALK WalkMarkerHandle, out UIntPtr Position);

	/// <summary>Rewinds a walk marker back to the beginning.</summary>
	/// <param name="WalkMarkerHandle">A handle to the walk marker.</param>
	/// <returns>
	/// <para>This function returns <c>ERROR_SUCCESS</c> on success.</para>
	/// <para>
	/// All error codes are defined in winerror.h. Use FormatMessage with the <c>FORMAT_MESSAGE_FROM_SYSTEM</c> flag to get a message for an
	/// error code.
	/// </para>
	/// </returns>
	// https://docs.microsoft.com/en-us/previous-versions/windows/desktop/api/processsnapshot/nf-processsnapshot-psswalkmarkerseektobeginning
	// DWORD PssWalkMarkerSeekToBeginning( HPSSWALK WalkMarkerHandle );
	[DllImport(Lib.Kernel32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("processsnapshot.h", MSDNShortId = "BE0FA122-3966-4827-9DA3-A98A162EF270")]
	public static extern Win32Error PssWalkMarkerSeekToBeginning([AddAsMember] HPSSWALK WalkMarkerHandle);

	/// <summary>Sets the position of a walk marker.</summary>
	/// <param name="WalkMarkerHandle">A handle to the walk marker.</param>
	/// <param name="Position">The position to set. This is a position that the PssWalkMarkerGetPosition function provided.</param>
	/// <returns>
	/// <para>This function returns <c>ERROR_SUCCESS</c> on success or one of the following error codes.</para>
	/// <para>
	/// All error codes are defined in winerror.h. Use FormatMessage with the <c>FORMAT_MESSAGE_FROM_SYSTEM</c> flag to get a message for an
	/// error code.
	/// </para>
	/// </returns>
	// https://docs.microsoft.com/en-us/previous-versions/windows/desktop/api/processsnapshot/nf-processsnapshot-psswalkmarkersetposition
	// DWORD PssWalkMarkerSetPosition( HPSSWALK WalkMarkerHandle, ULONG_PTR Position );
	[DllImport(Lib.Kernel32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("processsnapshot.h", MSDNShortId = "D89EA4DB-D8C6-43D1-B292-D24F1EAB2E43")]
	public static extern Win32Error PssWalkMarkerSetPosition([AddAsMember] HPSSWALK WalkMarkerHandle, UIntPtr Position);

	/// <summary>Returns information from the current walk position and advanced the walk marker to the next position.</summary>
	/// <param name="SnapshotHandle">A handle to the snapshot.</param>
	/// <param name="InformationClass">The type of information to return. For more information, see PSS_WALK_INFORMATION_CLASS.</param>
	/// <param name="WalkMarkerHandle">
	/// A handle to a walk marker. The walk marker indicates the walk position from which data is to be returned. <c>PssWalkSnapshot</c>
	/// advances the walk marker to the next walk position in time order before returning to the caller.
	/// </param>
	/// <param name="Buffer">The snapshot information that this function returns.</param>
	/// <param name="BufferLength">The size of Buffer, in bytes.</param>
	/// <returns>
	/// <para>This function returns <c>ERROR_SUCCESS</c> on success or one of the following error codes.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_BAD_LENGTH</term>
	/// <term>The specified buffer length is invalid.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_HANDLE</term>
	/// <term>The specified handle is invalid.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_PARAMETER</term>
	/// <term>The specified information class is invalid.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_MORE_DATA</term>
	/// <term>Buffer is NULL, and there is data at the current position to return.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_NO_MORE_ITEMS</term>
	/// <term>The walk has completed and there are no more items to return.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_NOT_FOUND</term>
	/// <term>The requested information is not in the snapshot.</term>
	/// </item>
	/// </list>
	/// <para>
	/// All error codes are defined in winerror.h. Use FormatMessage with the <c>FORMAT_MESSAGE_FROM_SYSTEM</c> flag to get a message for an
	/// error code.
	/// </para>
	/// </returns>
	/// <remarks>
	/// For snapshot data types that have a variable number of instances within a snapshot, you use the <c>PssWalkSnapshot</c> function to
	/// obtain the instances one after another. You set the InformationClass parameter to specify the type of data.
	/// </remarks>
	// https://docs.microsoft.com/en-us/previous-versions/windows/desktop/api/processsnapshot/nf-processsnapshot-psswalksnapshot DWORD
	// PssWalkSnapshot( HPSS SnapshotHandle, PSS_WALK_INFORMATION_CLASS InformationClass, HPSSWALK WalkMarkerHandle, void *Buffer, DWORD
	// BufferLength );
	[DllImport(Lib.Kernel32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("processsnapshot.h", MSDNShortId = "C6AC38B5-0A1C-44D7-A1F6-8196AE9B8FB0")]
	public static extern Win32Error PssWalkSnapshot(HPSS SnapshotHandle, PSS_WALK_INFORMATION_CLASS InformationClass, HPSSWALK WalkMarkerHandle, IntPtr Buffer, uint BufferLength);

	/// <summary>Returns information from the current walk position and advanced the walk marker to the next position.</summary>
	/// <typeparam name="T"></typeparam>
	/// <param name="SnapshotHandle">A handle to the snapshot.</param>
	/// <param name="InformationClass">The type of information to return. For more information, see PSS_WALK_INFORMATION_CLASS.</param>
	/// <param name="WalkMarkerHandle">
	/// An optional handle to a walk marker. The walk marker indicates the walk position from which data is to be returned.
	/// <c>PssWalkSnapshot</c> advances the walk marker to the next walk position in time order before returning to the caller.
	/// <para>If this value is <c>NULL</c>, then a new walk marker will be temporarily created.</para>
	/// </param>
	/// <returns>The list of snapshot information that this function returns.</returns>
	/// <exception cref="ArgumentOutOfRangeException">InformationClass</exception>
	/// <exception cref="ArgumentNullException">SnapshotHandle</exception>
	[PInvokeData("processsnapshot.h", MSDNShortId = "C6AC38B5-0A1C-44D7-A1F6-8196AE9B8FB0")]
	public static IEnumerable<T> PssWalkSnapshot<T>([AddAsMember] HPSS SnapshotHandle, PSS_WALK_INFORMATION_CLASS InformationClass, HPSSWALK WalkMarkerHandle = default) where T : struct
	{
		if (!CorrespondingTypeAttribute.CanGet(InformationClass, typeof(T))) throw new ArgumentOutOfRangeException(nameof(InformationClass));
		if (SnapshotHandle.IsNull) throw new ArgumentNullException(nameof(SnapshotHandle));
		SafeHPSSWALK hWalk;
		if (WalkMarkerHandle.IsNull)
			PssWalkMarkerCreate(IntPtr.Zero, out hWalk).ThrowIfFailed();
		else
			hWalk = new SafeHPSSWALK(WalkMarkerHandle.DangerousGetHandle(), false);
		using (hWalk)
		using (var mem = SafeCoTaskMemHandle.CreateFromStructure<T>())
		{
			do
			{
				var err = PssWalkSnapshot(SnapshotHandle, InformationClass, hWalk, (IntPtr)mem, (uint)mem.Size);
				if (err == Win32Error.ERROR_NO_MORE_ITEMS)
					break;
				else
					err.ThrowIfFailed();
				yield return mem.ToStructure<T>();
			} while (true);
		}
	}

	/// <summary>PSSs the capture snapshot internal.</summary>
	/// <param name="ProcessHandle">The process handle.</param>
	/// <param name="CaptureFlags">The capture flags.</param>
	/// <param name="ThreadContextFlags">The thread context flags.</param>
	/// <param name="SnapshotHandle">The snapshot handle.</param>
	/// <returns></returns>
	[DllImport(Lib.Kernel32, SetLastError = false, EntryPoint = "PssCaptureSnapshot", ExactSpelling = true)]
	private static extern Win32Error PssCaptureSnapshotInternal(HPROCESS ProcessHandle, PSS_CAPTURE_FLAGS CaptureFlags, uint ThreadContextFlags, out SafeHPSS SnapshotHandle);

	/// <summary>PSSs the duplicate snapshot internal.</summary>
	/// <param name="SourceProcessHandle">The source process handle.</param>
	/// <param name="SnapshotHandle">The snapshot handle.</param>
	/// <param name="TargetProcessHandle">The target process handle.</param>
	/// <param name="TargetSnapshotHandle">The target snapshot handle.</param>
	/// <param name="Flags">The flags.</param>
	/// <returns></returns>
	[DllImport(Lib.Kernel32, SetLastError = false, EntryPoint = "PssDuplicateSnapshot", ExactSpelling = true)]
	private static extern Win32Error PssDuplicateSnapshotInternal(HPROCESS SourceProcessHandle, HPSS SnapshotHandle, HPROCESS TargetProcessHandle, out SafeHPSS TargetSnapshotHandle, PSS_DUPLICATE_FLAGS Flags);

	/// <summary>
	/// Contains information about a range of pages in the virtual address space of a process. The VirtualQuery and VirtualQueryEx functions
	/// use this structure.
	/// </summary>
	/// <remarks>
	/// To enable a debugger to debug a target that is running on a different architecture (32-bit versus 64-bit), use one of the explicit
	/// forms of this structure.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winnt/ns-winnt-_memory_basic_information typedef struct _MEMORY_BASIC_INFORMATION
	// { PVOID BaseAddress; PVOID AllocationBase; DWORD AllocationProtect; SIZE_T RegionSize; DWORD State; DWORD Protect; DWORD Type; }
	// MEMORY_BASIC_INFORMATION, *PMEMORY_BASIC_INFORMATION;
	[PInvokeData("winnt.h", MSDNShortId = "dc3fa48e-0986-49cc-88a9-ff8179fbe5f0")]
	[StructLayout(LayoutKind.Sequential)]
	public struct MEMORY_BASIC_INFORMATION
	{
		/// <summary>A pointer to the base address of the region of pages.</summary>
		public IntPtr BaseAddress;

		/// <summary>
		/// A pointer to the base address of a range of pages allocated by the VirtualAlloc function. The page pointed to by the
		/// <c>BaseAddress</c> member is contained within this allocation range.
		/// </summary>
		public IntPtr AllocationBase;

		/// <summary>
		/// The memory protection option when the region was initially allocated. This member can be one of the memory protection constants
		/// or 0 if the caller does not have access.
		/// </summary>
		public MEM_PROTECTION AllocationProtect;

		/// <summary>The size of the region beginning at the base address in which all pages have identical attributes, in bytes.</summary>
		public SIZE_T RegionSize;

		/// <summary>
		/// <para>The state of the pages in the region. This member can be one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>State</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>MEM_COMMIT 0x1000</term>
		/// <term>Indicates committed pages for which physical storage has been allocated, either in memory or in the paging file on disk.</term>
		/// </item>
		/// <item>
		/// <term>MEM_FREE 0x10000</term>
		/// <term>
		/// Indicates free pages not accessible to the calling process and available to be allocated. For free pages, the information in the
		/// AllocationBase, AllocationProtect, Protect, and Type members is undefined.
		/// </term>
		/// </item>
		/// <item>
		/// <term>MEM_RESERVE 0x2000</term>
		/// <term>
		/// Indicates reserved pages where a range of the process's virtual address space is reserved without any physical storage being
		/// allocated. For reserved pages, the information in the Protect member is undefined.
		/// </term>
		/// </item>
		/// </list>
		/// </summary>
		public MEM_ALLOCATION_TYPE State;

		/// <summary>
		/// The access protection of the pages in the region. This member is one of the values listed for the <c>AllocationProtect</c> member.
		/// </summary>
		public MEM_PROTECTION Protect;

		/// <summary>
		/// <para>The type of pages in the region. The following types are defined.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Type</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>MEM_IMAGE 0x1000000</term>
		/// <term>Indicates that the memory pages within the region are mapped into the view of an image section.</term>
		/// </item>
		/// <item>
		/// <term>MEM_MAPPED 0x40000</term>
		/// <term>Indicates that the memory pages within the region are mapped into the view of a section.</term>
		/// </item>
		/// <item>
		/// <term>MEM_PRIVATE 0x20000</term>
		/// <term>Indicates that the memory pages within the region are private (that is, not shared by other processes).</term>
		/// </item>
		/// </list>
		/// </summary>
		public MEM_ALLOCATION_TYPE Type;
	}

	/// <summary>
	/// Specifies custom functions which the Process Snapshotting functions use to allocate and free the internal walk marker structures.
	/// </summary>
	/// <remarks>
	/// <para>
	/// To use custom memory allocation functions, pass this structure to PssWalkMarkerCreate. Otherwise, the Process Snapshotting functions
	/// use the default process heap.
	/// </para>
	/// <para>
	/// The <c>PSS_ALLOCATOR</c> structure that provides the custom functions should remain valid for the lifetime of the walk marker that
	/// PssWalkMarkerCreate creates.
	/// </para>
	/// <para><c>FreeRoutine</c> must accept <c>NULL</c> address parameters without failing.</para>
	/// <para>
	/// The custom functions are called from PssWalkMarkerCreate, PssWalkMarkerFree and PssWalkSnapshot using the same thread that calls
	/// <c>PssWalkMarkerCreate</c>, <c>PssWalkMarkerFree</c> and <c>PssWalkSnapshot</c>. Therefore the custom functions need not be multi-threaded.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/previous-versions/windows/desktop/api/processsnapshot/ns-processsnapshot-pss_allocator typedef struct
	// PSS_ALLOCATOR { void *Context; void )(void *Context,DWORD Size) *(*AllocRoutine; void((void *Context, void *Address) * )FreeRoutine; };
	[PInvokeData("processsnapshot.h", MSDNShortId = "54225F76-9A2E-4CB3-A3B5-9F9DB5551D53")]
	[StructLayout(LayoutKind.Sequential)]
	public struct PSS_ALLOCATOR
	{
		/// <summary>An arbitrary pointer-sized value that the Process Snapshotting functions pass to <c>AllocRoutine</c> and <c>FreeRoutine</c>.</summary>
		public IntPtr Context;

		/// <summary>
		/// <para>
		/// A pointer to a WINAPI-calling convention function that takes two parameters. It returns a pointer to the block of memory that it
		/// allocates, or <c>NULL</c> if allocation fails.
		/// </para>
		/// <para>Context</para>
		/// <para>The context value, as passed in <c>PSS_ALLOCATOR</c>.</para>
		/// <para>Size</para>
		/// <para>Number of bytes to allocate.</para>
		/// </summary>
		[MarshalAs(UnmanagedType.FunctionPtr)]
		public AllocRoutine Alloc;

		/// <summary>
		/// <para>
		/// A pointer to a WINAPI-calling convention function taking two parameters. It deallocates a block of memory that
		/// <c>AllocRoutine</c> allocated.
		/// </para>
		/// <para>Context</para>
		/// <para>The context value, as passed in <c>PSS_ALLOCATOR</c>.</para>
		/// <para>Address</para>
		/// <para>The address of a block of memory that <c>AllocRoutine</c> allocated.</para>
		/// </summary>
		[MarshalAs(UnmanagedType.FunctionPtr)]
		public FreeRoutine Free;

		/// <summary>A WINAPI-calling convention function that takes two parameters.</summary>
		/// <param name="Context">The context.</param>
		/// <param name="Size">The size.</param>
		/// <returns>A pointer to the block of memory that it allocates, or NULL if allocation fails.</returns>
		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		public delegate IntPtr AllocRoutine(IntPtr Context, uint Size);

		/// <summary>A WINAPI-calling convention function taking two parameters.</summary>
		/// <param name="Context">The context.</param>
		/// <param name="Address">The address.</param>
		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		public delegate void FreeRoutine(IntPtr Context, IntPtr Address);
	}

	/// <summary>Holds auxiliary page entry information returned by PssWalkSnapshot.</summary>
	/// <remarks>
	/// PssWalkSnapshot returns a <c>PSS_AUXILIARY_PAGE_ENTRY</c> structure when the PSS_WALK_INFORMATION_CLASS member that the caller
	/// provides it is <c>PSS_WALK_AUXILIARY_PAGES</c>.
	/// </remarks>
	// https://docs.microsoft.com/en-us/previous-versions/windows/desktop/api/processsnapshot/ns-processsnapshot-pss_auxiliary_page_entry
	// typedef struct PSS_AUXILIARY_PAGE_ENTRY { void *Address; MEMORY_BASIC_INFORMATION BasicInformation; FILETIME CaptureTime; void
	// *PageContents; DWORD PageSize; };
	[PInvokeData("processsnapshot.h", MSDNShortId = "A3D948E6-6FFE-4732-A8C7-A292FDA07D7C")]
	[StructLayout(LayoutKind.Sequential)]
	public struct PSS_AUXILIARY_PAGE_ENTRY
	{
		/// <summary>The address of the captured auxiliary page, in the context of the captured process.</summary>
		public IntPtr Address;

		/// <summary>Basic information about the captured page. See MEMORY_BASIC_INFORMATION for more information.</summary>
		public MEMORY_BASIC_INFORMATION BasicInformation;

		/// <summary>The capture time of the page. For more information, see FILETIME.</summary>
		public FILETIME CaptureTime;

		/// <summary>
		/// A pointer to the contents of the captured page, in the context of the current process. This member may be <c>NULL</c> if page
		/// contents were not captured. The pointer is valid for the lifetime of the walk marker passed to PssWalkSnapshot.
		/// </summary>
		public IntPtr PageContents;

		/// <summary>The size of the page contents that <c>PageContents</c> points to, in bytes.</summary>
		public uint PageSize;
	}

	/// <summary>Holds auxiliary pages information returned by PssQuerySnapshot.</summary>
	/// <remarks>
	/// PssQuerySnapshot returns a <c>PSS_AUXILIARY_PAGES_INFORMATION</c> structure when the PSS_QUERY_INFORMATION_CLASS member that the
	/// caller provides it is <c>PSS_QUERY_AUXILIARY_PAGES_INFORMATION</c>.
	/// </remarks>
	// https://docs.microsoft.com/en-us/previous-versions/windows/desktop/api/processsnapshot/ns-processsnapshot-pss_auxiliary_pages_information
	// typedef struct PSS_AUXILIARY_PAGES_INFORMATION { DWORD AuxPagesCaptured; };
	[PInvokeData("processsnapshot.h", MSDNShortId = "122DD3DF-002A-4250-9E37-BA239638A684")]
	[StructLayout(LayoutKind.Sequential)]
	public struct PSS_AUXILIARY_PAGES_INFORMATION
	{
		/// <summary>The count of auxiliary pages captured.</summary>
		public uint AuxPagesCaptured;
	}

	/// <summary>Holds information about a handle returned by PssWalkSnapshot.</summary>
	/// <remarks>
	/// PssWalkSnapshot returns a <c>PSS_HANDLE_ENTRY</c> structure when the PSS_WALK_INFORMATION_CLASS member that the caller provides it is <c>PSS_WALK_HANDLES</c>.
	/// </remarks>
	// https://docs.microsoft.com/en-us/previous-versions/windows/desktop/api/processsnapshot/ns-processsnapshot-pss_handle_entry typedef
	// struct PSS_HANDLE_ENTRY { HANDLE Handle; PSS_HANDLE_FLAGS Flags; PSS_OBJECT_TYPE ObjectType; FILETIME CaptureTime; DWORD Attributes;
	// DWORD GrantedAccess; DWORD HandleCount; DWORD PointerCount; DWORD PagedPoolCharge; DWORD NonPagedPoolCharge; FILETIME CreationTime;
	// WORD TypeNameLength; wchar_t const *TypeName; WORD ObjectNameLength; wchar_t const *ObjectName; union { struct { DWORD ExitStatus;
	// void *PebBaseAddress; ULONG_PTR AffinityMask; LONG BasePriority; DWORD ProcessId; DWORD ParentProcessId; DWORD Flags; } Process;
	// struct { DWORD ExitStatus; void *TebBaseAddress; DWORD ProcessId; DWORD ThreadId; ULONG_PTR AffinityMask; int Priority; int
	// BasePriority; void *Win32StartAddress; } Thread; struct { LONG CurrentCount; BOOL Abandoned; DWORD OwnerProcessId; DWORD
	// OwnerThreadId; } Mutant; struct { BOOL ManualReset; BOOL Signaled; } Event; struct { void *BaseAddress; DWORD AllocationAttributes;
	// LARGE_INTEGER MaximumSize; } Section; struct { LONG CurrentCount; LONG MaximumCount; } Semaphore; } TypeSpecificInformation; };
	[PInvokeData("processsnapshot.h", MSDNShortId = "F56E8C35-949A-4DEE-973F-CF24F6596036")]
	[StructLayout(LayoutKind.Sequential)]
	public struct PSS_HANDLE_ENTRY
	{
		/// <summary>The handle value.</summary>
		public IntPtr Handle;

		/// <summary>Flags that indicate what parts of this structure are valid. For more information, see PSS_HANDLE_FLAGS.</summary>
		public PSS_HANDLE_FLAGS Flags;

		/// <summary>The type of the object that the handle references. For more information, see PSS_OBJECT_TYPE.</summary>
		public PSS_OBJECT_TYPE ObjectType;

		/// <summary>The capture time of this information. For more information, see FILETIME.</summary>
		public FILETIME CaptureTime;

		/// <summary>Attributes.</summary>
		public uint Attributes;

		/// <summary>Reserved for use by the operating system.</summary>
		public uint GrantedAccess;

		/// <summary>Reserved for use by the operating system.</summary>
		public uint HandleCount;

		/// <summary>Reserved for use by the operating system.</summary>
		public uint PointerCount;

		/// <summary>Reserved for use by the operating system.</summary>
		public uint PagedPoolCharge;

		/// <summary>Reserved for use by the operating system.</summary>
		public uint NonPagedPoolCharge;

		/// <summary>Reserved for use by the operating system.</summary>
		public FILETIME CreationTime;

		/// <summary>The length of <c>TypeName</c>, in bytes.</summary>
		public ushort TypeNameLength;

		/// <summary>
		/// The type name of the object referenced by this handle. The buffer may not terminated by a <c>NULL</c> character. The pointer is
		/// valid for the lifetime of the walk marker passed to PssWalkSnapshot.
		/// </summary>
		public IntPtr TypeName;

		/// <summary>The length of <c>ObjectName</c>, in bytes.</summary>
		public ushort ObjectNameLength;

		/// <summary>
		/// Specifies the name of the object referenced by this handle. The buffer may not terminated by a <c>NULL</c> character. The pointer
		/// is valid for the lifetime of the walk marker passed to PssWalkSnapshot.
		/// </summary>
		public IntPtr ObjectName;

		/// <summary>Type-specific information.</summary>
		public UNION TypeSpecificInformation;

		/// <summary>Type-specific information.</summary>
		[StructLayout(LayoutKind.Explicit)]
		public struct UNION
		{
			/// <summary>Process</summary>
			[FieldOffset(0)]
			public Process Process;

			/// <summary>Thread</summary>
			[FieldOffset(0)]
			public Thread Thread;

			/// <summary>Mutant</summary>
			[FieldOffset(0)]
			public Mutant Mutant;

			/// <summary>Event</summary>
			[FieldOffset(0)]
			public Event Event;

			/// <summary>Section</summary>
			[FieldOffset(0)]
			public Section Section;

			/// <summary>Semaphore</summary>
			[FieldOffset(0)]
			public Semaphore Semaphore;
		}

		/// <summary>Undocumented.</summary>
		[StructLayout(LayoutKind.Sequential)]
		public struct Process
		{
			/// <summary>The exit code of the process. If the process has not exited, this is set to <c>STILL_ACTIVE</c> (259).</summary>
			public uint ExitStatus;

			/// <summary>The address of the process environment block (PEB). Reserved for use by the operating system.</summary>
			public IntPtr PebBaseAddress;

			/// <summary>The affinity mask of the process.</summary>
			public nuint AffinityMask;

			/// <summary>The base priority level of the process.</summary>
			public int BasePriority;

			/// <summary>The process ID.</summary>
			public uint ProcessId;

			/// <summary>The parent process ID.</summary>
			public uint ParentProcessId;

			/// <summary>Flags about the process. For more information, see PSS_PROCESS_FLAGS.</summary>
			public uint Flags;
		}

		/// <summary>Undocumented.</summary>
		[StructLayout(LayoutKind.Sequential)]
		public struct Thread
		{
			/// <summary>The exit code of the process. If the process has not exited, this is set to <c>STILL_ACTIVE</c> (259).</summary>
			public uint ExitStatus;

			/// <summary>The address of the thread environment block (TEB). Reserved for use by the operating system.</summary>
			public IntPtr TebBaseAddress;

			/// <summary>The process ID.</summary>
			public uint ProcessId;

			/// <summary>The thread ID.</summary>
			public uint ThreadId;

			/// <summary>The affinity mask of the process.</summary>
			public nuint AffinityMask;

			/// <summary>The thread’s dynamic priority level.</summary>
			public int Priority;

			/// <summary>The thread’s base priority level.</summary>
			public int BasePriority;

			/// <summary>A pointer to the thread procedure for the thread.</summary>
			public IntPtr Win32StartAddress;
		}

		/// <summary>Undocumented.</summary>
		[StructLayout(LayoutKind.Sequential)]
		public struct Mutant
		{
			/// <summary>Reserved for use by the operating system.</summary>
			public int CurrentCount;

			/// <summary>
			/// <c>TRUE</c> if the mutant has been abandoned (the owning thread exited without releasing the mutex), <c>FALSE</c> if not.
			/// </summary>
			[MarshalAs(UnmanagedType.Bool)] public bool Abandoned;

			/// <summary>The process ID of the owning thread, at the time of snapshot creation and handle capture.</summary>
			public uint OwnerProcessId;

			/// <summary>The process ID of the owning thread, at the time of snapshot creation and handle capture.</summary>
			public uint OwnerThreadId;
		}

		/// <summary>Undocumented.</summary>
		[StructLayout(LayoutKind.Sequential)]
		public struct Event
		{
			/// <summary><c>TRUE</c> if the event is manual reset, <c>FALSE</c> if not.</summary>
			[MarshalAs(UnmanagedType.Bool)] public bool ManualReset;

			/// <summary><c>TRUE</c> if the event was signaled at the time of snapshot creation and handle capture, <c>FALSE</c> if not.</summary>
			[MarshalAs(UnmanagedType.Bool)] public bool Signaled;
		}

		/// <summary>Undocumented.</summary>
		[StructLayout(LayoutKind.Sequential)]
		public struct Section
		{
			/// <summary>Reserved for use by the operating system.</summary>
			public IntPtr BaseAddress;

			/// <summary>Reserved for use by the operating system.</summary>
			public uint AllocationAttributes;

			/// <summary>Reserved for use by the operating system.</summary>
			public long MaximumSize;
		}

		/// <summary>Undocumented.</summary>
		[StructLayout(LayoutKind.Sequential)]
		public struct Semaphore
		{
			/// <summary>Undocumented.</summary>
			public int CurrentCount;

			/// <summary>Undocumented.</summary>
			public int MaximumCount;
		}
	}

	/// <summary>Holds handle information returned by PssQuerySnapshot.</summary>
	/// <remarks>
	/// PssQuerySnapshot returns a <c>PSS_HANDLE_INFORMATION</c> structure when the PSS_QUERY_INFORMATION_CLASS member that the caller
	/// provides it is <c>PSS_QUERY_HANDLE_INFORMATION</c>.
	/// </remarks>
	// https://docs.microsoft.com/en-us/previous-versions/windows/desktop/api/processsnapshot/ns-processsnapshot-pss_handle_information
	// typedef struct PSS_HANDLE_INFORMATION { DWORD HandlesCaptured; };
	[PInvokeData("processsnapshot.h", MSDNShortId = "77192849-D919-4947-9BFF-343C166C5A51")]
	[StructLayout(LayoutKind.Sequential)]
	public struct PSS_HANDLE_INFORMATION
	{
		/// <summary>The count of handles captured.</summary>
		public uint HandlesCaptured;
	}

	/// <summary>Holds handle trace information returned by PssQuerySnapshot.</summary>
	/// <remarks>
	/// PssQuerySnapshot returns a <c>PSS_HANDLE_TRACE_INFORMATION</c> structure when the PSS_QUERY_INFORMATION_CLASS member that the caller
	/// provides it is <c>PSS_QUERY_HANDLE_TRACE_INFORMATION</c>.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/processsnapshot/ns-processsnapshot-pss_handle_trace_information typedef struct {
	// HANDLE SectionHandle; DWORD Size; } PSS_HANDLE_TRACE_INFORMATION;
	[PInvokeData("processsnapshot.h", MSDNShortId = "0877DF1F-044C-48F2-9BCC-938EBD6D46EE")]
	[StructLayout(LayoutKind.Sequential)]
	public struct PSS_HANDLE_TRACE_INFORMATION
	{
		/// <summary>A handle to a section containing the handle trace information.</summary>
		public HANDLE SectionHandle;

		/// <summary>The size of the handle trace section, in bytes.</summary>
		public uint Size;
	}

	/// <summary>Holds performance counters returned by PssQuerySnapshot.</summary>
	/// <remarks>
	/// PssQuerySnapshot returns a <c>PSS_PERFORMANCE_COUNTERS</c> structure when the PSS_QUERY_INFORMATION_CLASS member that the caller
	/// provides it is <c>PSS_QUERY_PERFORMANCE_COUNTERS</c>.
	/// </remarks>
	// https://docs.microsoft.com/en-us/previous-versions/windows/desktop/api/processsnapshot/ns-processsnapshot-pss_performance_counters
	// typedef struct PSS_PERFORMANCE_COUNTERS { UINT64 TotalCycleCount; UINT64 TotalWallClockPeriod; UINT64 VaCloneCycleCount; UINT64
	// VaCloneWallClockPeriod; UINT64 VaSpaceCycleCount; UINT64 VaSpaceWallClockPeriod; UINT64 AuxPagesCycleCount; UINT64
	// AuxPagesWallClockPeriod; UINT64 HandlesCycleCount; UINT64 HandlesWallClockPeriod; UINT64 ThreadsCycleCount; UINT64
	// ThreadsWallClockPeriod; };
	[PInvokeData("processsnapshot.h", MSDNShortId = "298C1FC8-D19D-4DB3-84AA-3870D06B16A1")]
	[StructLayout(LayoutKind.Sequential)]
	public struct PSS_PERFORMANCE_COUNTERS
	{
		/// <summary>The count of clock cycles spent for capture.</summary>
		public ulong TotalCycleCount;

		/// <summary>The count of FILETIME units spent for capture.</summary>
		public ulong TotalWallClockPeriod;

		/// <summary>The count of clock cycles spent for the capture of the VA clone.</summary>
		public ulong VaCloneCycleCount;

		/// <summary>The count of FILETIME units spent for the capture of the VA clone.</summary>
		public ulong VaCloneWallClockPeriod;

		/// <summary>The count of clock cycles spent for the capture of VA space information.</summary>
		public ulong VaSpaceCycleCount;

		/// <summary>The count of FILETIME units spent for the capture VA space information.</summary>
		public ulong VaSpaceWallClockPeriod;

		/// <summary>The count of clock cycles spent for the capture of auxiliary page information.</summary>
		public ulong AuxPagesCycleCount;

		/// <summary>The count of FILETIME units spent for the capture of auxiliary page information.</summary>
		public ulong AuxPagesWallClockPeriod;

		/// <summary>The count of clock cycles spent for the capture of handle information.</summary>
		public ulong HandlesCycleCount;

		/// <summary>The count of FILETIME units spent for the capture of handle information.</summary>
		public ulong HandlesWallClockPeriod;

		/// <summary>The count of clock cycles spent for the capture of thread information.</summary>
		public ulong ThreadsCycleCount;

		/// <summary>The count of FILETIME units spent for the capture of thread information.</summary>
		public ulong ThreadsWallClockPeriod;
	}

	/// <summary>Holds process information returned by PssQuerySnapshot.</summary>
	/// <remarks>
	/// PssQuerySnapshot returns a <c>PSS_PROCESS_INFORMATION</c> structure when the PSS_QUERY_INFORMATION_CLASS member that the caller
	/// provides it is <c>PSS_QUERY_PROCESS_INFORMATION</c>.
	/// </remarks>
	// https://docs.microsoft.com/en-us/previous-versions/windows/desktop/api/processsnapshot/ns-processsnapshot-pss_process_information
	// typedef struct PSS_PROCESS_INFORMATION { DWORD ExitStatus; void *PebBaseAddress; ULONG_PTR AffinityMask; LONG BasePriority; DWORD
	// ProcessId; DWORD ParentProcessId; PSS_PROCESS_FLAGS Flags; FILETIME CreateTime; FILETIME ExitTime; FILETIME KernelTime; FILETIME
	// UserTime; DWORD PriorityClass; ULONG_PTR PeakVirtualSize; ULONG_PTR VirtualSize; DWORD PageFaultCount; ULONG_PTR PeakWorkingSetSize;
	// ULONG_PTR WorkingSetSize; ULONG_PTR QuotaPeakPagedPoolUsage; ULONG_PTR QuotaPagedPoolUsage; ULONG_PTR QuotaPeakNonPagedPoolUsage;
	// ULONG_PTR QuotaNonPagedPoolUsage; ULONG_PTR PagefileUsage; ULONG_PTR PeakPagefileUsage; ULONG_PTR PrivateUsage; DWORD ExecuteFlags;
	// wchar_t ImageFileName[MAX_PATH]; };
	[PInvokeData("processsnapshot.h", MSDNShortId = "D629FA42-B501-4A0E-9B53-6D70E580B687")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct PSS_PROCESS_INFORMATION
	{
		/// <summary>The exit code of the process. If the process has not exited, this is set to <c>STILL_ACTIVE</c> (259).</summary>
		public uint ExitStatus;

		/// <summary>The address to the process environment block (PEB). Reserved for use by the operating system.</summary>
		public IntPtr PebBaseAddress;

		/// <summary>The affinity mask of the process.</summary>
		public nuint AffinityMask;

		/// <summary>The base priority level of the process.</summary>
		public int BasePriority;

		/// <summary>The process ID.</summary>
		public uint ProcessId;

		/// <summary>The parent process ID.</summary>
		public uint ParentProcessId;

		/// <summary>Flags about the process. For more information, see PSS_PROCESS_FLAGS.</summary>
		public PSS_PROCESS_FLAGS Flags;

		/// <summary>The time the process was created. For more information, see FILETIME.</summary>
		public FILETIME CreateTime;

		/// <summary>If the process exited, the time of the exit. For more information, see FILETIME.</summary>
		public FILETIME ExitTime;

		/// <summary>The amount of time the process spent executing in kernel-mode. For more information, see FILETIME.</summary>
		public FILETIME KernelTime;

		/// <summary>The amount of time the process spent executing in user-mode. For more information, see FILETIME.</summary>
		public FILETIME UserTime;

		/// <summary>The priority class.</summary>
		public uint PriorityClass;

		/// <summary>A memory usage counter. See the GetProcessMemoryInfo function for more information.</summary>
		public nuint PeakVirtualSize;

		/// <summary>A memory usage counter. See the GetProcessMemoryInfo function for more information.</summary>
		public nuint VirtualSize;

		/// <summary>A memory usage counter. See the GetProcessMemoryInfo function for more information.</summary>
		public uint PageFaultCount;

		/// <summary>A memory usage counter. See the GetProcessMemoryInfo function for more information.</summary>
		public nuint PeakWorkingSetSize;

		/// <summary>A memory usage counter. See the GetProcessMemoryInfo function for more information.</summary>
		public nuint WorkingSetSize;

		/// <summary>A memory usage counter. See the GetProcessMemoryInfo function for more information.</summary>
		public nuint QuotaPeakPagedPoolUsage;

		/// <summary>A memory usage counter. See the GetProcessMemoryInfo function for more information.</summary>
		public nuint QuotaPagedPoolUsage;

		/// <summary>A memory usage counter. See the GetProcessMemoryInfo function for more information.</summary>
		public nuint QuotaPeakNonPagedPoolUsage;

		/// <summary>A memory usage counter. See the GetProcessMemoryInfo function for more information.</summary>
		public nuint QuotaNonPagedPoolUsage;

		/// <summary>A memory usage counter. See the GetProcessMemoryInfo function for more information.</summary>
		public nuint PagefileUsage;

		/// <summary>A memory usage counter. See the GetProcessMemoryInfo function for more information.</summary>
		public nuint PeakPagefileUsage;

		/// <summary>A memory usage counter. See the GetProcessMemoryInfo function for more information.</summary>
		public nuint PrivateUsage;

		/// <summary>Reserved for use by the operating system.</summary>
		public uint ExecuteFlags;

		/// <summary>The full path to the process executable. If the path exceeds the allocated buffer size, it is truncated.</summary>
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_PATH)]
		public string ImageFileName;
	}

	/// <summary>Holds thread information returned by PssWalkSnapshot <c>PssWalkSnapshot</c>.</summary>
	/// <remarks>
	/// PssWalkSnapshot returns a <c>PSS_THREAD_ENTRY</c> structure when the PSS_WALK_INFORMATION_CLASS member that the caller provides it is <c>PSS_WALK_THREADS</c>.
	/// </remarks>
	// https://docs.microsoft.com/en-us/previous-versions/windows/desktop/api/processsnapshot/ns-processsnapshot-pss_thread_entry typedef
	// struct PSS_THREAD_ENTRY { DWORD ExitStatus; void *TebBaseAddress; DWORD ProcessId; DWORD ThreadId; ULONG_PTR AffinityMask; int
	// Priority; int BasePriority; void *LastSyscallFirstArgument; WORD LastSyscallNumber; FILETIME CreateTime; FILETIME ExitTime; FILETIME
	// KernelTime; FILETIME UserTime; void *Win32StartAddress; FILETIME CaptureTime; PSS_THREAD_FLAGS Flags; WORD SuspendCount; WORD
	// SizeOfContextRecord; PCONTEXT ContextRecord; };
	[PInvokeData("processsnapshot.h", MSDNShortId = "99C89DBB-8C12-482E-B33D-AE59C37662CF")]
	[StructLayout(LayoutKind.Sequential)]
	public struct PSS_THREAD_ENTRY
	{
		/// <summary>The exit code of the process. If the process has not exited, this is set to <c>STILL_ACTIVE</c> (259).</summary>
		public uint ExitStatus;

		/// <summary>The address of the thread environment block (TEB). Reserved for use by the operating system.</summary>
		public IntPtr TebBaseAddress;

		/// <summary>The process ID.</summary>
		public uint ProcessId;

		/// <summary>The thread ID.</summary>
		public uint ThreadId;

		/// <summary>The affinity mask of the process.</summary>
		public nuint AffinityMask;

		/// <summary>The thread’s dynamic priority level.</summary>
		public int Priority;

		/// <summary>The base priority level of the process.</summary>
		public int BasePriority;

		/// <summary>Reserved for use by the operating system.</summary>
		public IntPtr LastSyscallFirstArgument;

		/// <summary>Reserved for use by the operating system.</summary>
		public ushort LastSyscallNumber;

		/// <summary>The time the thread was created. For more information, see FILETIME.</summary>
		public FILETIME CreateTime;

		/// <summary>If the thread exited, the time of the exit. For more information, see FILETIME.</summary>
		public FILETIME ExitTime;

		/// <summary>The amount of time the thread spent executing in kernel mode. For more information, see FILETIME.</summary>
		public FILETIME KernelTime;

		/// <summary>The amount of time the thread spent executing in user mode. For more information, see FILETIME.</summary>
		public FILETIME UserTime;

		/// <summary>A pointer to the thread procedure for thread.</summary>
		public IntPtr Win32StartAddress;

		/// <summary>The capture time of this thread. For more information, see FILETIME.</summary>
		public FILETIME CaptureTime;

		/// <summary>Flags about the thread. For more information, see PSS_THREAD_FLAGS.</summary>
		public PSS_THREAD_FLAGS Flags;

		/// <summary>The count of times the thread suspended.</summary>
		public ushort SuspendCount;

		/// <summary>The size of ContextRecord, in bytes.</summary>
		public ushort SizeOfContextRecord;

		/// <summary>
		/// A pointer to the context record if thread context information was captured. The pointer is valid for the lifetime of the walk
		/// marker passed to PssWalkSnapshot.
		/// </summary>
		public IntPtr ContextRecord;         // valid for life time of walk marker
	}

	/// <summary>Holds thread information returned by PssQuerySnapshot.</summary>
	/// <remarks>
	/// PssQuerySnapshot returns a <c>PSS_THREAD_INFORMATION</c> structure when the PSS_QUERY_INFORMATION_CLASS member that the caller
	/// provides it is <c>PSS_QUERY_THREAD_INFORMATION</c>.
	/// </remarks>
	// https://docs.microsoft.com/en-us/previous-versions/windows/desktop/api/processsnapshot/ns-processsnapshot-pss_thread_information
	// typedef struct PSS_THREAD_INFORMATION { DWORD ThreadsCaptured; DWORD ContextLength; };
	[PInvokeData("processsnapshot.h", MSDNShortId = "68BC42FD-9A30-462F-AFB1-DF9587C50F45")]
	[StructLayout(LayoutKind.Sequential)]
	public struct PSS_THREAD_INFORMATION
	{
		/// <summary>The count of threads in the snapshot.</summary>
		public uint ThreadsCaptured;

		/// <summary>The length of the <c>CONTEXT</c> record captured, in bytes.</summary>
		public uint ContextLength;
	}

	/// <summary>Holds virtual address (VA) clone information returned by PssQuerySnapshot.</summary>
	/// <remarks>
	/// PssQuerySnapshot returns a <c>PSS_VA_CLONE_INFORMATION</c> structure when the PSS_QUERY_INFORMATION_CLASS member that the caller
	/// provides it is <c>PSS_QUERY_VA_CLONE_INFORMATION</c>.
	/// </remarks>
	// https://docs.microsoft.com/en-us/previous-versions/windows/desktop/api/processsnapshot/ns-processsnapshot-pss_va_clone_information
	// typedef struct PSS_VA_CLONE_INFORMATION { HANDLE VaCloneHandle; };
	[PInvokeData("processsnapshot.h", MSDNShortId = "F93D61B0-EDB2-4560-A69F-CF839EC98B53")]
	[StructLayout(LayoutKind.Sequential)]
	public struct PSS_VA_CLONE_INFORMATION
	{
		/// <summary>A handle to the VA clone process.</summary>
		public IntPtr VaCloneHandle;
	}

	/// <summary>Holds the MEMORY_BASIC_INFORMATION returned by PssWalkSnapshot for a virtual address (VA) region.</summary>
	/// <remarks>
	/// PssWalkSnapshot returns a <c>PSS_VA_SPACE_ENTRY</c> structure when the PSS_WALK_INFORMATION_CLASS member that the caller provides it
	/// is <c>PSS_WALK_VA_SPACE</c>.
	/// </remarks>
	// https://docs.microsoft.com/en-us/previous-versions/windows/desktop/api/processsnapshot/ns-processsnapshot-pss_va_space_entry typedef
	// struct PSS_VA_SPACE_ENTRY { void *BaseAddress; void *AllocationBase; DWORD AllocationProtect; ULONG_PTR RegionSize; DWORD State; DWORD
	// Protect; DWORD Type; DWORD TimeDateStamp; DWORD SizeOfImage; void *ImageBase; DWORD CheckSum; WORD MappedFileNameLength; wchar_t const
	// *MappedFileName; };
	[PInvokeData("processsnapshot.h", MSDNShortId = "69B8F6A3-76DF-421B-B89B-73BA3254F897")]
	[StructLayout(LayoutKind.Sequential)]
	public struct PSS_VA_SPACE_ENTRY
	{
		/// <summary>Information about the VA region. For more information, see MEMORY_BASIC_INFORMATION.</summary>
		public IntPtr BaseAddress;

		/// <summary>Information about the VA region. For more information, see MEMORY_BASIC_INFORMATION.</summary>
		public IntPtr AllocationBase;

		/// <summary>Information about the VA region. For more information, see MEMORY_BASIC_INFORMATION.</summary>
		public MEM_PROTECTION AllocationProtect;

		/// <summary>Information about the VA region. For more information, see MEMORY_BASIC_INFORMATION.</summary>
		public nuint RegionSize;

		/// <summary>Information about the VA region. For more information, see MEMORY_BASIC_INFORMATION.</summary>
		public MEM_ALLOCATION_TYPE State;

		/// <summary>Information about the VA region. For more information, see MEMORY_BASIC_INFORMATION.</summary>
		public MEM_PROTECTION Protect;

		/// <summary>Information about the VA region. For more information, see MEMORY_BASIC_INFORMATION.</summary>
		public MEM_ALLOCATION_TYPE Type;

		/// <summary>
		/// If section information was captured and the region is an executable image ( <c>MEM_IMAGE</c>), this is the <c>TimeDateStamp</c>
		/// value from the Portable Executable (PE) header which describes the image. It is the low 32 bits of the number of seconds since
		/// 00:00 January 1, 1970 (a C run-time time_t value), that indicates when the file was created.
		/// </summary>
		public uint TimeDateStamp;

		/// <summary>
		/// If section information was captured and the region is an executable image ( <c>MEM_IMAGE</c>), this is the <c>SizeOfImage</c>
		/// value from the Portable Executable (PE) header which describes the image. It is the size (in bytes) of the image, including all
		/// headers, as the image is loaded in memory.
		/// </summary>
		public uint SizeOfImage;

		/// <summary>
		/// If section information was captured and the region is an executable image ( <c>MEM_IMAGE</c>), this is the <c>ImageBase</c> value
		/// from the Portable Executable (PE) header which describes the image. It is the preferred address of the first byte of the image
		/// when loaded into memory.
		/// </summary>
		public IntPtr ImageBase;

		/// <summary>
		/// If section information was captured and the region is an executable image ( <c>MEM_IMAGE</c>), this is the <c>CheckSum</c> value
		/// from the Portable Executable (PE) header which describes the image. It is the image file checksum.
		/// </summary>
		public uint CheckSum;

		/// <summary>The length of the mapped file name buffer, in bytes.</summary>
		public ushort MappedFileNameLength;

		/// <summary>
		/// If section information was captured, this is the file path backing the section (if any). The path may be in NT namespace. The
		/// string may not be terminated by a <c>NULL</c> character. The pointer is valid for the lifetime of the walk marker passed to PssWalkSnapshot.
		/// </summary>
		public PWSTR MappedFileName;
	}

	/// <summary>Holds virtual address (VA) space information returned by PssQuerySnapshot.</summary>
	/// <remarks>
	/// PssQuerySnapshot returns a <c>PSS_VA_SPACE_INFORMATION</c> structure when the PSS_QUERY_INFORMATION_CLASS member that the caller
	/// provides it is <c>PSS_QUERY_VA_SPACE_INFORMATION</c>.
	/// </remarks>
	// https://docs.microsoft.com/en-us/previous-versions/windows/desktop/api/processsnapshot/ns-processsnapshot-pss_va_space_information
	// typedef struct PSS_VA_SPACE_INFORMATION { DWORD RegionCount; };
	[PInvokeData("processsnapshot.h", MSDNShortId = "F38FF7EB-DDC5-4692-8F57-8D633193D891")]
	[StructLayout(LayoutKind.Sequential)]
	public struct PSS_VA_SPACE_INFORMATION
	{
		/// <summary>The count of VA regions captured.</summary>
		public uint RegionCount;
	}

	/// <summary></summary>
	/// <seealso cref="SafeHANDLE"/>
	public partial class SafeHPSS
	{
		/// <summary>The process handle</summary>
		internal HPROCESS ProcessHandle;
	}
}