// ReSharper disable InconsistentNaming

namespace Vanara.PInvoke
{
	public partial struct NTStatus
	{
		/// <summary>The operation completed successfully.</summary>
		public const uint STATUS_SUCCESS = 0x00000000;
		/// <summary>The caller specified WaitAny for WaitType and one of the dispatcher objects in the Object array has been set to the signaled state.</summary>
		public const uint STATUS_WAIT_0 = 0x00000000;
		/// <summary>The caller specified WaitAny for WaitType and one of the dispatcher objects in the Object array has been set to the signaled state. The caller specified WaitAny for WaitType and one of the dispatcher objects in the Object array has been set to the signaled state.</summary>
		public const uint STATUS_WAIT_1 = 0x00000001;
		/// <summary>The caller specified WaitAny for WaitType and one of the dispatcher objects in the Object array has been set to the signaled state.</summary>
		public const uint STATUS_WAIT_2 = 0x00000002;
		/// <summary>The caller specified WaitAny for WaitType and one of the dispatcher objects in the Object array has been set to the signaled state.</summary>
		public const uint STATUS_WAIT_3 = 0x00000003;
		/// <summary>The caller specified WaitAny for WaitType and one of the dispatcher objects in the Object array has been set to the signaled state.</summary>
		public const uint STATUS_WAIT_63 = 0x0000003F;
		/// <summary>The caller attempted to wait for a mutex that has been abandoned.</summary>
		public const uint STATUS_ABANDONED = 0x00000080;
		/// <summary>The caller attempted to wait for a mutex that has been abandoned.</summary>
		public const uint STATUS_ABANDONED_WAIT_0 = 0x00000080;
		/// <summary>The caller attempted to wait for a mutex that has been abandoned.</summary>
		public const uint STATUS_ABANDONED_WAIT_63 = 0x000000BF;
		/// <summary>A user-mode APC was delivered before the given Interval expired.</summary>
		public const uint STATUS_USER_APC = 0x000000C0;
		/// <summary>The delay completed because the thread was alerted.</summary>
		public const uint STATUS_ALERTED = 0x00000101;
		/// <summary>The given Timeout interval expired.</summary>
		public const uint STATUS_TIMEOUT = 0x00000102;
		/// <summary>The operation that was requested is pending completion.</summary>
		public const uint STATUS_PENDING = 0x00000103;
		/// <summary>A reparse should be performed by the Object Manager because the name of the file resulted in a symbolic link.</summary>
		public const uint STATUS_REPARSE = 0x00000104;
		/// <summary>Returned by enumeration APIs to indicate more information is available to successive calls.</summary>
		public const uint STATUS_MORE_ENTRIES = 0x00000105;
		/// <summary>Indicates not all privileges or groups that are referenced are assigned to the caller. This allows, for example, all privileges to be disabled without having to know exactly which privileges are assigned.</summary>
		public const uint STATUS_NOT_ALL_ASSIGNED = 0x00000106;
		/// <summary>Some of the information to be translated has not been translated.</summary>
		public const uint STATUS_SOME_NOT_MAPPED = 0x00000107;
		/// <summary>An open/create operation completed while an opportunistic lock (oplock) break is underway.</summary>
		public const uint STATUS_OPLOCK_BREAK_IN_PROGRESS = 0x00000108;
		/// <summary>A new volume has been mounted by a file system.</summary>
		public const uint STATUS_VOLUME_MOUNTED = 0x00000109;
		/// <summary>This success level status indicates that the transaction state already exists for the registry subtree but that a transaction commit was previously aborted. The commit has now been completed.</summary>
		public const uint STATUS_RXACT_COMMITTED = 0x0000010A;
		/// <summary>Indicates that a notify change request has been completed due to closing the handle that made the notify change request.</summary>
		public const uint STATUS_NOTIFY_CLEANUP = 0x0000010B;
		/// <summary>Indicates that a notify change request is being completed and that the information is not being returned in the caller's buffer. The caller now needs to enumerate the files to find the changes.</summary>
		public const uint STATUS_NOTIFY_ENUM_DIR = 0x0000010C;
		/// <summary>{No Quotas} No system quota limits are specifically set for this account.</summary>
		public const uint STATUS_NO_QUOTAS_FOR_ACCOUNT = 0x0000010D;
		/// <summary>{Connect Failure on Primary Transport} An attempt was made to connect to the remote server %hs on the primary transport, but the connection failed. The computer WAS able to connect on a secondary transport.</summary>
		public const uint STATUS_PRIMARY_TRANSPORT_CONNECT_FAILED = 0x0000010E;
		/// <summary>The page fault was a transition fault.</summary>
		public const uint STATUS_PAGE_FAULT_TRANSITION = 0x00000110;
		/// <summary>The page fault was a demand zero fault.</summary>
		public const uint STATUS_PAGE_FAULT_DEMAND_ZERO = 0x00000111;
		/// <summary>The page fault was a demand zero fault.</summary>
		public const uint STATUS_PAGE_FAULT_COPY_ON_WRITE = 0x00000112;
		/// <summary>The page fault was a demand zero fault.</summary>
		public const uint STATUS_PAGE_FAULT_GUARD_PAGE = 0x00000113;
		/// <summary>The page fault was satisfied by reading from a secondary storage device.</summary>
		public const uint STATUS_PAGE_FAULT_PAGING_FILE = 0x00000114;
		/// <summary>The cached page was locked during operation.</summary>
		public const uint STATUS_CACHE_PAGE_LOCKED = 0x00000115;
		/// <summary>The crash dump exists in a paging file.</summary>
		public const uint STATUS_CRASH_DUMP = 0x00000116;
		/// <summary>The specified buffer contains all zeros.</summary>
		public const uint STATUS_BUFFER_ALL_ZEROS = 0x00000117;
		/// <summary>A reparse should be performed by the Object Manager because the name of the file resulted in a symbolic link.</summary>
		public const uint STATUS_REPARSE_OBJECT = 0x00000118;
		/// <summary>The device has succeeded a query-stop and its resource requirements have changed.</summary>
		public const uint STATUS_RESOURCE_REQUIREMENTS_CHANGED = 0x00000119;
		/// <summary>The translator has translated these resources into the global space and no additional translations should be performed.</summary>
		public const uint STATUS_TRANSLATION_COMPLETE = 0x00000120;
		/// <summary>The directory service evaluated group memberships locally, because it was unable to contact a global catalog server.</summary>
		public const uint STATUS_DS_MEMBERSHIP_EVALUATED_LOCALLY = 0x00000121;
		/// <summary>A process being terminated has no threads to terminate.</summary>
		public const uint STATUS_NOTHING_TO_TERMINATE = 0x00000122;
		/// <summary>The specified process is not part of a job.</summary>
		public const uint STATUS_PROCESS_NOT_IN_JOB = 0x00000123;
		/// <summary>The specified process is part of a job.</summary>
		public const uint STATUS_PROCESS_IN_JOB = 0x00000124;
		/// <summary>{Volume Shadow Copy Service} The system is now ready for hibernation.</summary>
		public const uint STATUS_VOLSNAP_HIBERNATE_READY = 0x00000125;
		/// <summary>A file system or file system filter driver has successfully completed an FsFilter operation.</summary>
		public const uint STATUS_FSFILTER_OP_COMPLETED_SUCCESSFULLY = 0x00000126;
		/// <summary>The specified interrupt vector was already connected.</summary>
		public const uint STATUS_INTERRUPT_VECTOR_ALREADY_CONNECTED = 0x00000127;
		/// <summary>The specified interrupt vector is still connected.</summary>
		public const uint STATUS_INTERRUPT_STILL_CONNECTED = 0x00000128;
		/// <summary>The current process is a cloned process.</summary>
		public const uint STATUS_PROCESS_CLONED = 0x00000129;
		/// <summary>The file was locked and all users of the file can only read.</summary>
		public const uint STATUS_FILE_LOCKED_WITH_ONLY_READERS = 0x0000012A;
		/// <summary>The file was locked and at least one user of the file can write.</summary>
		public const uint STATUS_FILE_LOCKED_WITH_WRITERS = 0x0000012B;
		/// <summary>The specified ResourceManager made no changes or updates to the resource under this transaction.</summary>
		public const uint STATUS_RESOURCEMANAGER_READ_ONLY = 0x00000202;
		/// <summary>An operation is blocked and waiting for an oplock.</summary>
		public const uint STATUS_WAIT_FOR_OPLOCK = 0x00000367;
		/// <summary>Debugger handled the exception.</summary>
		public const uint DBG_EXCEPTION_HANDLED = 0x00010001;
		/// <summary>The debugger continued.</summary>
		public const uint DBG_CONTINUE = 0x00010002;
		/// <summary>The IO was completed by a filter.</summary>
		public const uint STATUS_FLT_IO_COMPLETE = 0x001C0001;
		/// <summary>The file is temporarily unavailable.</summary>
		public const uint STATUS_FILE_NOT_AVAILABLE = 0xC0000467;
		/// <summary>The share is temporarily unavailable.</summary>
		public const uint STATUS_SHARE_UNAVAILABLE = 0xC0000480;
		/// <summary>A threadpool worker thread entered a callback at thread affinity %p and exited at affinity %p. This is unexpected, indicating that the callback missed restoring the priority.</summary>
		public const uint STATUS_CALLBACK_RETURNED_THREAD_AFFINITY = 0xC0000721;
		/// <summary>{Object Exists} An attempt was made to create an object but the object name already exists.</summary>
		public const uint STATUS_OBJECT_NAME_EXISTS = 0x40000000;
		/// <summary>{Thread Suspended} A thread termination occurred while the thread was suspended. The thread resumed, and termination proceeded.</summary>
		public const uint STATUS_THREAD_WAS_SUSPENDED = 0x40000001;
		/// <summary>{Working Set Range Error} An attempt was made to set the working set minimum or maximum to values that are outside the allowable range.</summary>
		public const uint STATUS_WORKING_SET_LIMIT_RANGE = 0x40000002;
		/// <summary>{Image Relocated} An image file could not be mapped at the address that is specified in the image file. Local fixes must be performed on this image.</summary>
		public const uint STATUS_IMAGE_NOT_AT_BASE = 0x40000003;
		/// <summary>This informational level status indicates that a specified registry subtree transaction state did not yet exist and had to be created.</summary>
		public const uint STATUS_RXACT_STATE_CREATED = 0x40000004;
		/// <summary>{Segment Load} A virtual DOS machine (VDM) is loading, unloading, or moving an MS-DOS or Win16 program segment image. An exception is raised so that a debugger can load, unload, or track symbols and breakpoints within these 16-bit segments.</summary>
		public const uint STATUS_SEGMENT_NOTIFICATION = 0x40000005;
		/// <summary>{Local Session Key} A user session key was requested for a local remote procedure call (RPC) connection. The session key that is returned is a constant value and not unique to this connection.</summary>
		public const uint STATUS_LOCAL_USER_SESSION_KEY = 0x40000006;
		/// <summary>{Invalid Current Directory} The process cannot switch to the startup current directory %hs. Select OK to set the current directory to %hs, or select CANCEL to exit.</summary>
		public const uint STATUS_BAD_CURRENT_DIRECTORY = 0x40000007;
		/// <summary>{Serial IOCTL Complete} A serial I/O operation was completed by another write to a serial port. (The IOCTL_SERIAL_XOFF_COUNTER reached zero.)</summary>
		public const uint STATUS_SERIAL_MORE_WRITES = 0x40000008;
		/// <summary>{Registry Recovery} One of the files that contains the system registry data had to be recovered by using a log or alternate copy. The recovery was successful.</summary>
		public const uint STATUS_REGISTRY_RECOVERED = 0x40000009;
		/// <summary>{Redundant Read} To satisfy a read request, the Windows NT operating system fault-tolerant file system successfully read the requested data from a redundant copy. This was done because the file system encountered a failure on a member of the fault-tolerant volume but was unable to reassign the failing area of the device.</summary>
		public const uint STATUS_FT_READ_RECOVERY_FROM_BACKUP = 0x4000000A;
		/// <summary>{Redundant Write} To satisfy a write request, the Windows NT fault-tolerant file system successfully wrote a redundant copy of the information. This was done because the file system encountered a failure on a member of the fault-tolerant volume but was unable to reassign the failing area of the device.</summary>
		public const uint STATUS_FT_WRITE_RECOVERY = 0x4000000B;
		/// <summary>{Serial IOCTL Timeout} A serial I/O operation completed because the time-out period expired. (The IOCTL_SERIAL_XOFF_COUNTER had not reached zero.)</summary>
		public const uint STATUS_SERIAL_COUNTER_TIMEOUT = 0x4000000C;
		/// <summary>{Password Too Complex} The Windows password is too complex to be converted to a LAN Manager password. The LAN Manager password that returned is a NULL string.</summary>
		public const uint STATUS_NULL_LM_PASSWORD = 0x4000000D;
		/// <summary>{Machine Type Mismatch} The image file %hs is valid but is for a machine type other than the current machine. Select OK to continue, or CANCEL to fail the DLL load.</summary>
		public const uint STATUS_IMAGE_MACHINE_TYPE_MISMATCH = 0x4000000E;
		/// <summary>{Partial Data Received} The network transport returned partial data to its client. The remaining data will be sent later.</summary>
		public const uint STATUS_RECEIVE_PARTIAL = 0x4000000F;
		/// <summary>{Expedited Data Received} The network transport returned data to its client that was marked as expedited by the remote system.</summary>
		public const uint STATUS_RECEIVE_EXPEDITED = 0x40000010;
		/// <summary>{Partial Expedited Data Received} The network transport returned partial data to its client and this data was marked as expedited by the remote system. The remaining data will be sent later.</summary>
		public const uint STATUS_RECEIVE_PARTIAL_EXPEDITED = 0x40000011;
		/// <summary>{TDI Event Done} The TDI indication has completed successfully.</summary>
		public const uint STATUS_EVENT_DONE = 0x40000012;
		/// <summary>{TDI Event Pending} The TDI indication has entered the pending state.</summary>
		public const uint STATUS_EVENT_PENDING = 0x40000013;
		/// <summary>Checking file system on %wZ.</summary>
		public const uint STATUS_CHECKING_FILE_SYSTEM = 0x40000014;
		/// <summary>{Fatal Application Exit} %hs</summary>
		public const uint STATUS_FATAL_APP_EXIT = 0x40000015;
		/// <summary>The specified registry key is referenced by a predefined handle.</summary>
		public const uint STATUS_PREDEFINED_HANDLE = 0x40000016;
		/// <summary>{Page Unlocked} The page protection of a locked page was changed to 'No Access' and the page was unlocked from memory and from the process.</summary>
		public const uint STATUS_WAS_UNLOCKED = 0x40000017;
		/// <summary>%hs</summary>
		public const uint STATUS_SERVICE_NOTIFICATION = 0x40000018;
		/// <summary>{Page Locked} One of the pages to lock was already locked.</summary>
		public const uint STATUS_WAS_LOCKED = 0x40000019;
		/// <summary>Application popup: %1 : %2</summary>
		public const uint STATUS_LOG_HARD_ERROR = 0x4000001A;
		/// <summary>A Win32 process already exists.</summary>
		public const uint STATUS_ALREADY_WIN32 = 0x4000001B;
		/// <summary>An exception status code that is used by the Win32 x86 emulation subsystem.</summary>
		public const uint STATUS_WX86_UNSIMULATE = 0x4000001C;
		/// <summary>An exception status code that is used by the Win32 x86 emulation subsystem.</summary>
		public const uint STATUS_WX86_CONTINUE = 0x4000001D;
		/// <summary>An exception status code that is used by the Win32 x86 emulation subsystem.</summary>
		public const uint STATUS_WX86_SINGLE_STEP = 0x4000001E;
		/// <summary>An exception status code that is used by the Win32 x86 emulation subsystem.</summary>
		public const uint STATUS_WX86_BREAKPOINT = 0x4000001F;
		/// <summary>An exception status code that is used by the Win32 x86 emulation subsystem.</summary>
		public const uint STATUS_WX86_EXCEPTION_CONTINUE = 0x40000020;
		/// <summary>An exception status code that is used by the Win32 x86 emulation subsystem.</summary>
		public const uint STATUS_WX86_EXCEPTION_LASTCHANCE = 0x40000021;
		/// <summary>An exception status code that is used by the Win32 x86 emulation subsystem.</summary>
		public const uint STATUS_WX86_EXCEPTION_CHAIN = 0x40000022;
		/// <summary>{Machine Type Mismatch} The image file %hs is valid but is for a machine type other than the current machine.</summary>
		public const uint STATUS_IMAGE_MACHINE_TYPE_MISMATCH_EXE = 0x40000023;
		/// <summary>A yield execution was performed and no thread was available to run.</summary>
		public const uint STATUS_NO_YIELD_PERFORMED = 0x40000024;
		/// <summary>The resume flag to a timer API was ignored.</summary>
		public const uint STATUS_TIMER_RESUME_IGNORED = 0x40000025;
		/// <summary>The arbiter has deferred arbitration of these resources to its parent.</summary>
		public const uint STATUS_ARBITRATION_UNHANDLED = 0x40000026;
		/// <summary>The device has detected a CardBus card in its slot.</summary>
		public const uint STATUS_CARDBUS_NOT_SUPPORTED = 0x40000027;
		/// <summary>An exception status code that is used by the Win32 x86 emulation subsystem.</summary>
		public const uint STATUS_WX86_CREATEWX86TIB = 0x40000028;
		/// <summary>The CPUs in this multiprocessor system are not all the same revision level. To use all processors, the operating system restricts itself to the features of the least capable processor in the system. If problems occur with this system, contact the CPU manufacturer to see if this mix of processors is supported.</summary>
		public const uint STATUS_MP_PROCESSOR_MISMATCH = 0x40000029;
		/// <summary>The system was put into hibernation.</summary>
		public const uint STATUS_HIBERNATED = 0x4000002A;
		/// <summary>The system was resumed from hibernation.</summary>
		public const uint STATUS_RESUME_HIBERNATION = 0x4000002B;
		/// <summary>Windows has detected that the system firmware (BIOS) was updated [previous firmware date = %2, current firmware date %3].</summary>
		public const uint STATUS_FIRMWARE_UPDATED = 0x4000002C;
		/// <summary>A device driver is leaking locked I/O pages and is causing system degradation. The system has automatically enabled the tracking code to try and catch the culprit.</summary>
		public const uint STATUS_DRIVERS_LEAKING_LOCKED_PAGES = 0x4000002D;
		/// <summary>The ALPC message being canceled has already been retrieved from the queue on the other side.</summary>
		public const uint STATUS_MESSAGE_RETRIEVED = 0x4000002E;
		/// <summary>The system power state is transitioning from %2 to %3.</summary>
		public const uint STATUS_SYSTEM_POWERSTATE_TRANSITION = 0x4000002F;
		/// <summary>The receive operation was successful. Check the ALPC completion list for the received message.</summary>
		public const uint STATUS_ALPC_CHECK_COMPLETION_LIST = 0x40000030;
		/// <summary>The system power state is transitioning from %2 to %3 but could enter %4.</summary>
		public const uint STATUS_SYSTEM_POWERSTATE_COMPLEX_TRANSITION = 0x40000031;
		/// <summary>Access to %1 is monitored by policy rule %2.</summary>
		public const uint STATUS_ACCESS_AUDIT_BY_POLICY = 0x40000032;
		/// <summary>A valid hibernation file has been invalidated and should be abandoned.</summary>
		public const uint STATUS_ABANDON_HIBERFILE = 0x40000033;
		/// <summary>Business rule scripts are disabled for the calling application.</summary>
		public const uint STATUS_BIZRULES_NOT_ENABLED = 0x40000034;
		/// <summary>The system has awoken.</summary>
		public const uint STATUS_WAKE_SYSTEM = 0x40000294;
		/// <summary>The directory service is shutting down.</summary>
		public const uint STATUS_DS_SHUTTING_DOWN = 0x40000370;
		/// <summary>Debugger will reply later.</summary>
		public const uint DBG_REPLY_LATER = 0x40010001;
		/// <summary>Debugger cannot provide a handle.</summary>
		public const uint DBG_UNABLE_TO_PROVIDE_HANDLE = 0x40010002;
		/// <summary>Debugger terminated the thread.</summary>
		public const uint DBG_TERMINATE_THREAD = 0x40010003;
		/// <summary>Debugger terminated the process.</summary>
		public const uint DBG_TERMINATE_PROCESS = 0x40010004;
		/// <summary>Debugger obtained control of C.</summary>
		public const uint DBG_CONTROL_C = 0x40010005;
		/// <summary>Debugger printed an exception on control C.</summary>
		public const uint DBG_PRINTEXCEPTION_C = 0x40010006;
		/// <summary>Debugger received a RIP exception.</summary>
		public const uint DBG_RIPEXCEPTION = 0x40010007;
		/// <summary>Debugger received a control break.</summary>
		public const uint DBG_CONTROL_BREAK = 0x40010008;
		/// <summary>Debugger command communication exception.</summary>
		public const uint DBG_COMMAND_EXCEPTION = 0x40010009;
		/// <summary>A UUID that is valid only on this computer has been allocated.</summary>
		public const uint RPC_NT_UUID_LOCAL_ONLY = 0x40020056;
		/// <summary>Some data remains to be sent in the request buffer.</summary>
		public const uint RPC_NT_SEND_INCOMPLETE = 0x400200AF;
		/// <summary>The Client Drive Mapping Service has connected on Terminal Connection.</summary>
		public const uint STATUS_CTX_CDM_CONNECT = 0x400A0004;
		/// <summary>The Client Drive Mapping Service has disconnected on Terminal Connection.</summary>
		public const uint STATUS_CTX_CDM_DISCONNECT = 0x400A0005;
		/// <summary>A kernel mode component is releasing a reference on an activation context.</summary>
		public const uint STATUS_SXS_RELEASE_ACTIVATION_CONTEXT = 0x4015000D;
		/// <summary>The transactional resource manager is already consistent. Recovery is not needed.</summary>
		public const uint STATUS_RECOVERY_NOT_NEEDED = 0x40190034;
		/// <summary>The transactional resource manager has already been started.</summary>
		public const uint STATUS_RM_ALREADY_STARTED = 0x40190035;
		/// <summary>The log service encountered a log stream with no restart area.</summary>
		public const uint STATUS_LOG_NO_RESTART = 0x401A000C;
		/// <summary>{Display Driver Recovered From Failure} The %hs display driver has detected a failure and recovered from it. Some graphical operations might have failed. The next time you restart the machine, a dialog box appears, giving you an opportunity to upload data about this failure to Microsoft.</summary>
		public const uint STATUS_VIDEO_DRIVER_DEBUG_REPORT_REQUEST = 0x401B00EC;
		/// <summary>The specified buffer is not big enough to contain the entire requested dataset. Partial data is populated up to the size of the buffer. The caller needs to provide a buffer of the size as specified in the partially populated buffer's content (interface specific).</summary>
		public const uint STATUS_GRAPHICS_PARTIAL_DATA_POPULATED = 0x401E000A;
		/// <summary>The kernel driver detected a version mismatch between it and the user mode driver.</summary>
		public const uint STATUS_GRAPHICS_DRIVER_MISMATCH = 0x401E0117;
		/// <summary>No mode is pinned on the specified VidPN source/target.</summary>
		public const uint STATUS_GRAPHICS_MODE_NOT_PINNED = 0x401E0307;
		/// <summary>The specified mode set does not specify a preference for one of its modes.</summary>
		public const uint STATUS_GRAPHICS_NO_PREFERRED_MODE = 0x401E031E;
		/// <summary>The specified dataset (for example, mode set, frequency range set, descriptor set, or topology) is empty.</summary>
		public const uint STATUS_GRAPHICS_DATASET_IS_EMPTY = 0x401E034B;
		/// <summary>The specified dataset (for example, mode set, frequency range set, descriptor set, or topology) does not contain any more elements.</summary>
		public const uint STATUS_GRAPHICS_NO_MORE_ELEMENTS_IN_DATASET = 0x401E034C;
		/// <summary>The specified content transformation is not pinned on the specified VidPN present path.</summary>
		public const uint STATUS_GRAPHICS_PATH_CONTENT_GEOMETRY_TRANSFORMATION_NOT_PINNED = 0x401E0351;
		/// <summary>The child device presence was not reliably detected.</summary>
		public const uint STATUS_GRAPHICS_UNKNOWN_CHILD_STATUS = 0x401E042F;
		/// <summary>Starting the lead adapter in a linked configuration has been temporarily deferred.</summary>
		public const uint STATUS_GRAPHICS_LEADLINK_START_DEFERRED = 0x401E0437;
		/// <summary>The display adapter is being polled for children too frequently at the same polling level.</summary>
		public const uint STATUS_GRAPHICS_POLLING_TOO_FREQUENTLY = 0x401E0439;
		/// <summary>Starting the adapter has been temporarily deferred.</summary>
		public const uint STATUS_GRAPHICS_START_DEFERRED = 0x401E043A;
		/// <summary>The request will be completed later by an NDIS status indication.</summary>
		public const uint STATUS_NDIS_INDICATION_REQUIRED = 0x40230001;
		/// <summary>{EXCEPTION} Guard Page Exception A page of memory that marks the end of a data structure, such as a stack or an array, has been accessed.</summary>
		public const uint STATUS_GUARD_PAGE_VIOLATION = 0x80000001;
		/// <summary>{EXCEPTION} Alignment Fault A data type misalignment was detected in a load or store instruction.</summary>
		public const uint STATUS_DATATYPE_MISALIGNMENT = 0x80000002;
		/// <summary>{EXCEPTION} Breakpoint A breakpoint has been reached.</summary>
		public const uint STATUS_BREAKPOINT = 0x80000003;
		/// <summary>{EXCEPTION} Single Step A single step or trace operation has just been completed.</summary>
		public const uint STATUS_SINGLE_STEP = 0x80000004;
		/// <summary>{Buffer Overflow} The data was too large to fit into the specified buffer.</summary>
		public const uint STATUS_BUFFER_OVERFLOW = 0x80000005;
		/// <summary>{No More Files} No more files were found which match the file specification.</summary>
		public const uint STATUS_NO_MORE_FILES = 0x80000006;
		/// <summary>{Kernel Debugger Awakened} The system debugger was awakened by an interrupt.</summary>
		public const uint STATUS_WAKE_SYSTEM_DEBUGGER = 0x80000007;
		/// <summary>{Handles Closed} Handles to objects have been automatically closed because of the requested operation.</summary>
		public const uint STATUS_HANDLES_CLOSED = 0x8000000A;
		/// <summary>{Non-Inheritable ACL} An access control list (ACL) contains no components that can be inherited.</summary>
		public const uint STATUS_NO_INHERITANCE = 0x8000000B;
		/// <summary>{GUID Substitution} During the translation of a globally unique identifier (GUID) to a Windows security ID (SID), no administratively defined GUID prefix was found. A substitute prefix was used, which will not compromise system security. However, this might provide a more restrictive access than intended.</summary>
		public const uint STATUS_GUID_SUBSTITUTION_MADE = 0x8000000C;
		/// <summary>Because of protection conflicts, not all the requested bytes could be copied.</summary>
		public const uint STATUS_PARTIAL_COPY = 0x8000000D;
		/// <summary>{Out of Paper} The printer is out of paper.</summary>
		public const uint STATUS_DEVICE_PAPER_EMPTY = 0x8000000E;
		/// <summary>{Device Power Is Off} The printer power has been turned off.</summary>
		public const uint STATUS_DEVICE_POWERED_OFF = 0x8000000F;
		/// <summary>{Device Offline} The printer has been taken offline.</summary>
		public const uint STATUS_DEVICE_OFF_LINE = 0x80000010;
		/// <summary>{Device Busy} The device is currently busy.</summary>
		public const uint STATUS_DEVICE_BUSY = 0x80000011;
		/// <summary>{No More EAs} No more extended attributes (EAs) were found for the file.</summary>
		public const uint STATUS_NO_MORE_EAS = 0x80000012;
		/// <summary>{Illegal EA} The specified extended attribute (EA) name contains at least one illegal character.</summary>
		public const uint STATUS_INVALID_EA_NAME = 0x80000013;
		/// <summary>{Inconsistent EA List} The extended attribute (EA) list is inconsistent.</summary>
		public const uint STATUS_EA_LIST_INCONSISTENT = 0x80000014;
		/// <summary>{Invalid EA Flag} An invalid extended attribute (EA) flag was set.</summary>
		public const uint STATUS_INVALID_EA_FLAG = 0x80000015;
		/// <summary>{Verifying Disk} The media has changed and a verify operation is in progress; therefore, no reads or writes can be performed to the device, except those that are used in the verify operation.</summary>
		public const uint STATUS_VERIFY_REQUIRED = 0x80000016;
		/// <summary>{Too Much Information} The specified access control list (ACL) contained more information than was expected.</summary>
		public const uint STATUS_EXTRANEOUS_INFORMATION = 0x80000017;
		/// <summary>This warning level status indicates that the transaction state already exists for the registry subtree, but that a transaction commit was previously aborted. The commit has NOT been completed but has not been rolled back either; therefore, it can still be committed, if needed.</summary>
		public const uint STATUS_RXACT_COMMIT_NECESSARY = 0x80000018;
		/// <summary>{No More Entries} No more entries are available from an enumeration operation.</summary>
		public const uint STATUS_NO_MORE_ENTRIES = 0x8000001A;
		/// <summary>{Filemark Found} A filemark was detected.</summary>
		public const uint STATUS_FILEMARK_DETECTED = 0x8000001B;
		/// <summary>{Media Changed} The media has changed.</summary>
		public const uint STATUS_MEDIA_CHANGED = 0x8000001C;
		/// <summary>{I/O Bus Reset} An I/O bus reset was detected.</summary>
		public const uint STATUS_BUS_RESET = 0x8000001D;
		/// <summary>{End of Media} The end of the media was encountered.</summary>
		public const uint STATUS_END_OF_MEDIA = 0x8000001E;
		/// <summary>The beginning of a tape or partition has been detected.</summary>
		public const uint STATUS_BEGINNING_OF_MEDIA = 0x8000001F;
		/// <summary>{Media Changed} The media might have changed.</summary>
		public const uint STATUS_MEDIA_CHECK = 0x80000020;
		/// <summary>A tape access reached a set mark.</summary>
		public const uint STATUS_SETMARK_DETECTED = 0x80000021;
		/// <summary>During a tape access, the end of the data written is reached.</summary>
		public const uint STATUS_NO_DATA_DETECTED = 0x80000022;
		/// <summary>The redirector is in use and cannot be unloaded.</summary>
		public const uint STATUS_REDIRECTOR_HAS_OPEN_HANDLES = 0x80000023;
		/// <summary>The server is in use and cannot be unloaded.</summary>
		public const uint STATUS_SERVER_HAS_OPEN_HANDLES = 0x80000024;
		/// <summary>The specified connection has already been disconnected.</summary>
		public const uint STATUS_ALREADY_DISCONNECTED = 0x80000025;
		/// <summary>A long jump has been executed.</summary>
		public const uint STATUS_LONGJUMP = 0x80000026;
		/// <summary>A cleaner cartridge is present in the tape library.</summary>
		public const uint STATUS_CLEANER_CARTRIDGE_INSTALLED = 0x80000027;
		/// <summary>The Plug and Play query operation was not successful.</summary>
		public const uint STATUS_PLUGPLAY_QUERY_VETOED = 0x80000028;
		/// <summary>A frame consolidation has been executed.</summary>
		public const uint STATUS_UNWIND_CONSOLIDATE = 0x80000029;
		/// <summary>{Registry Hive Recovered} The registry hive (file): %hs was corrupted and it has been recovered. Some data might have been lost.</summary>
		public const uint STATUS_REGISTRY_HIVE_RECOVERED = 0x8000002A;
		/// <summary>The application is attempting to run executable code from the module %hs. This might be insecure. An alternative, %hs, is available. Should the application use the secure module %hs?</summary>
		public const uint STATUS_DLL_MIGHT_BE_INSECURE = 0x8000002B;
		/// <summary>The application is loading executable code from the module %hs. This is secure but might be incompatible with previous releases of the operating system. An alternative, %hs, is available. Should the application use the secure module %hs?</summary>
		public const uint STATUS_DLL_MIGHT_BE_INCOMPATIBLE = 0x8000002C;
		/// <summary>The create operation stopped after reaching a symbolic link.</summary>
		public const uint STATUS_STOPPED_ON_SYMLINK = 0x8000002D;
		/// <summary>The device has indicated that cleaning is necessary.</summary>
		public const uint STATUS_DEVICE_REQUIRES_CLEANING = 0x80000288;
		/// <summary>The device has indicated that its door is open. Further operations require it closed and secured.</summary>
		public const uint STATUS_DEVICE_DOOR_OPEN = 0x80000289;
		/// <summary>Windows discovered a corruption in the file %hs. This file has now been repaired. Check if any data in the file was lost because of the corruption.</summary>
		public const uint STATUS_DATA_LOST_REPAIR = 0x80000803;
		/// <summary>Debugger did not handle the exception.</summary>
		public const uint DBG_EXCEPTION_NOT_HANDLED = 0x80010001;
		/// <summary>The cluster node is already up.</summary>
		public const uint STATUS_CLUSTER_NODE_ALREADY_UP = 0x80130001;
		/// <summary>The cluster node is already down.</summary>
		public const uint STATUS_CLUSTER_NODE_ALREADY_DOWN = 0x80130002;
		/// <summary>The cluster network is already online.</summary>
		public const uint STATUS_CLUSTER_NETWORK_ALREADY_ONLINE = 0x80130003;
		/// <summary>The cluster network is already offline.</summary>
		public const uint STATUS_CLUSTER_NETWORK_ALREADY_OFFLINE = 0x80130004;
		/// <summary>The cluster node is already a member of the cluster.</summary>
		public const uint STATUS_CLUSTER_NODE_ALREADY_MEMBER = 0x80130005;
		/// <summary>The log could not be set to the requested size.</summary>
		public const uint STATUS_COULD_NOT_RESIZE_LOG = 0x80190009;
		/// <summary>There is no transaction metadata on the file.</summary>
		public const uint STATUS_NO_TXF_METADATA = 0x80190029;
		/// <summary>The file cannot be recovered because there is a handle still open on it.</summary>
		public const uint STATUS_CANT_RECOVER_WITH_HANDLE_OPEN = 0x80190031;
		/// <summary>Transaction metadata is already present on this file and cannot be superseded.</summary>
		public const uint STATUS_TXF_METADATA_ALREADY_PRESENT = 0x80190041;
		/// <summary>A transaction scope could not be entered because the scope handler has not been initialized.</summary>
		public const uint STATUS_TRANSACTION_SCOPE_CALLBACKS_NOT_SET = 0x80190042;
		/// <summary>{Display Driver Stopped Responding and recovered} The %hs display driver has stopped working normally. The recovery had been performed.</summary>
		public const uint STATUS_VIDEO_HUNG_DISPLAY_DRIVER_THREAD_RECOVERED = 0x801B00EB;
		/// <summary>{Buffer too small} The buffer is too small to contain the entry. No information has been written to the buffer.</summary>
		public const uint STATUS_FLT_BUFFER_TOO_SMALL = 0x801C0001;
		/// <summary>Volume metadata read or write is incomplete.</summary>
		public const uint STATUS_FVE_PARTIAL_METADATA = 0x80210001;
		/// <summary>BitLocker encryption keys were ignored because the volume was in a transient state.</summary>
		public const uint STATUS_FVE_TRANSIENT_STATE = 0x80210002;
		/// <summary>{Operation Failed} The requested operation was unsuccessful.</summary>
		public const uint STATUS_UNSUCCESSFUL = 0xC0000001;
		/// <summary>{Not Implemented} The requested operation is not implemented.</summary>
		public const uint STATUS_NOT_IMPLEMENTED = 0xC0000002;
		/// <summary>{Invalid Parameter} The specified information class is not a valid information class for the specified object.</summary>
		public const uint STATUS_INVALID_INFO_CLASS = 0xC0000003;
		/// <summary>The specified information record length does not match the length that is required for the specified information class.</summary>
		public const uint STATUS_INFO_LENGTH_MISMATCH = 0xC0000004;
		/// <summary>The instruction at 0x%08lx referenced memory at 0x%08lx. The memory could not be %s.</summary>
		public const uint STATUS_ACCESS_VIOLATION = 0xC0000005;
		/// <summary>The instruction at 0x%08lx referenced memory at 0x%08lx. The required data was not placed into memory because of an I/O error status of 0x%08lx.</summary>
		public const uint STATUS_IN_PAGE_ERROR = 0xC0000006;
		/// <summary>The page file quota for the process has been exhausted.</summary>
		public const uint STATUS_PAGEFILE_QUOTA = 0xC0000007;
		/// <summary>An invalid HANDLE was specified.</summary>
		public const uint STATUS_INVALID_HANDLE = 0xC0000008;
		/// <summary>An invalid initial stack was specified in a call to NtCreateThread.</summary>
		public const uint STATUS_BAD_INITIAL_STACK = 0xC0000009;
		/// <summary>An invalid initial start address was specified in a call to NtCreateThread.</summary>
		public const uint STATUS_BAD_INITIAL_PC = 0xC000000A;
		/// <summary>An invalid client ID was specified.</summary>
		public const uint STATUS_INVALID_CID = 0xC000000B;
		/// <summary>An attempt was made to cancel or set a timer that has an associated APC and the specified thread is not the thread that originally set the timer with an associated APC routine.</summary>
		public const uint STATUS_TIMER_NOT_CANCELED = 0xC000000C;
		/// <summary>An invalid parameter was passed to a service or function.</summary>
		public const uint STATUS_INVALID_PARAMETER = 0xC000000D;
		/// <summary>A device that does not exist was specified.</summary>
		public const uint STATUS_NO_SUCH_DEVICE = 0xC000000E;
		/// <summary>{File Not Found} The file %hs does not exist.</summary>
		public const uint STATUS_NO_SUCH_FILE = 0xC000000F;
		/// <summary>The specified request is not a valid operation for the target device.</summary>
		public const uint STATUS_INVALID_DEVICE_REQUEST = 0xC0000010;
		/// <summary>The end-of-file marker has been reached. There is no valid data in the file beyond this marker.</summary>
		public const uint STATUS_END_OF_FILE = 0xC0000011;
		/// <summary>{Wrong Volume} The wrong volume is in the drive. Insert volume %hs into drive %hs.</summary>
		public const uint STATUS_WRONG_VOLUME = 0xC0000012;
		/// <summary>{No Disk} There is no disk in the drive. Insert a disk into drive %hs.</summary>
		public const uint STATUS_NO_MEDIA_IN_DEVICE = 0xC0000013;
		/// <summary>{Unknown Disk Format} The disk in drive %hs is not formatted properly. Check the disk, and reformat it, if needed.</summary>
		public const uint STATUS_UNRECOGNIZED_MEDIA = 0xC0000014;
		/// <summary>{Sector Not Found} The specified sector does not exist.</summary>
		public const uint STATUS_NONEXISTENT_SECTOR = 0xC0000015;
		/// <summary>{Still Busy} The specified I/O request packet (IRP) cannot be disposed of because the I/O operation is not complete.</summary>
		public const uint STATUS_MORE_PROCESSING_REQUIRED = 0xC0000016;
		/// <summary>{Not Enough Quota} Not enough virtual memory or paging file quota is available to complete the specified operation.</summary>
		public const uint STATUS_NO_MEMORY = 0xC0000017;
		/// <summary>{Conflicting Address Range} The specified address range conflicts with the address space.</summary>
		public const uint STATUS_CONFLICTING_ADDRESSES = 0xC0000018;
		/// <summary>The address range to unmap is not a mapped view.</summary>
		public const uint STATUS_NOT_MAPPED_VIEW = 0xC0000019;
		/// <summary>The virtual memory cannot be freed.</summary>
		public const uint STATUS_UNABLE_TO_FREE_VM = 0xC000001A;
		/// <summary>The specified section cannot be deleted.</summary>
		public const uint STATUS_UNABLE_TO_DELETE_SECTION = 0xC000001B;
		/// <summary>An invalid system service was specified in a system service call.</summary>
		public const uint STATUS_INVALID_SYSTEM_SERVICE = 0xC000001C;
		/// <summary>{EXCEPTION} Illegal Instruction An attempt was made to execute an illegal instruction.</summary>
		public const uint STATUS_ILLEGAL_INSTRUCTION = 0xC000001D;
		/// <summary>{Invalid Lock Sequence} An attempt was made to execute an invalid lock sequence.</summary>
		public const uint STATUS_INVALID_LOCK_SEQUENCE = 0xC000001E;
		/// <summary>{Invalid Mapping} An attempt was made to create a view for a section that is bigger than the section.</summary>
		public const uint STATUS_INVALID_VIEW_SIZE = 0xC000001F;
		/// <summary>{Bad File} The attributes of the specified mapping file for a section of memory cannot be read.</summary>
		public const uint STATUS_INVALID_FILE_FOR_SECTION = 0xC0000020;
		/// <summary>{Already Committed} The specified address range is already committed.</summary>
		public const uint STATUS_ALREADY_COMMITTED = 0xC0000021;
		/// <summary>{Access Denied} A process has requested access to an object but has not been granted those access rights.</summary>
		public const uint STATUS_ACCESS_DENIED = 0xC0000022;
		/// <summary>{Buffer Too Small} The buffer is too small to contain the entry. No information has been written to the buffer.</summary>
		public const uint STATUS_BUFFER_TOO_SMALL = 0xC0000023;
		/// <summary>{Wrong Type} There is a mismatch between the type of object that is required by the requested operation and the type of object that is specified in the request.</summary>
		public const uint STATUS_OBJECT_TYPE_MISMATCH = 0xC0000024;
		/// <summary>{EXCEPTION} Cannot Continue Windows cannot continue from this exception.</summary>
		public const uint STATUS_NONCONTINUABLE_EXCEPTION = 0xC0000025;
		/// <summary>An invalid exception disposition was returned by an exception handler.</summary>
		public const uint STATUS_INVALID_DISPOSITION = 0xC0000026;
		/// <summary>Unwind exception code.</summary>
		public const uint STATUS_UNWIND = 0xC0000027;
		/// <summary>An invalid or unaligned stack was encountered during an unwind operation.</summary>
		public const uint STATUS_BAD_STACK = 0xC0000028;
		/// <summary>An invalid unwind target was encountered during an unwind operation.</summary>
		public const uint STATUS_INVALID_UNWIND_TARGET = 0xC0000029;
		/// <summary>An attempt was made to unlock a page of memory that was not locked.</summary>
		public const uint STATUS_NOT_LOCKED = 0xC000002A;
		/// <summary>A device parity error on an I/O operation.</summary>
		public const uint STATUS_PARITY_ERROR = 0xC000002B;
		/// <summary>An attempt was made to decommit uncommitted virtual memory.</summary>
		public const uint STATUS_UNABLE_TO_DECOMMIT_VM = 0xC000002C;
		/// <summary>An attempt was made to change the attributes on memory that has not been committed.</summary>
		public const uint STATUS_NOT_COMMITTED = 0xC000002D;
		/// <summary>Invalid object attributes specified to NtCreatePort or invalid port attributes specified to NtConnectPort.</summary>
		public const uint STATUS_INVALID_PORT_ATTRIBUTES = 0xC000002E;
		/// <summary>The length of the message that was passed to NtRequestPort or NtRequestWaitReplyPort is longer than the maximum message that is allowed by the port.</summary>
		public const uint STATUS_PORT_MESSAGE_TOO_LONG = 0xC000002F;
		/// <summary>An invalid combination of parameters was specified.</summary>
		public const uint STATUS_INVALID_PARAMETER_MIX = 0xC0000030;
		/// <summary>An attempt was made to lower a quota limit below the current usage.</summary>
		public const uint STATUS_INVALID_QUOTA_LOWER = 0xC0000031;
		/// <summary>{Corrupt Disk} The file system structure on the disk is corrupt and unusable. Run the Chkdsk utility on the volume %hs.</summary>
		public const uint STATUS_DISK_CORRUPT_ERROR = 0xC0000032;
		/// <summary>The object name is invalid.</summary>
		public const uint STATUS_OBJECT_NAME_INVALID = 0xC0000033;
		/// <summary>The object name is not found.</summary>
		public const uint STATUS_OBJECT_NAME_NOT_FOUND = 0xC0000034;
		/// <summary>The object name already exists.</summary>
		public const uint STATUS_OBJECT_NAME_COLLISION = 0xC0000035;
		/// <summary>An attempt was made to send a message to a disconnected communication port.</summary>
		public const uint STATUS_PORT_DISCONNECTED = 0xC0000037;
		/// <summary>An attempt was made to attach to a device that was already attached to another device.</summary>
		public const uint STATUS_DEVICE_ALREADY_ATTACHED = 0xC0000038;
		/// <summary>The object path component was not a directory object.</summary>
		public const uint STATUS_OBJECT_PATH_INVALID = 0xC0000039;
		/// <summary>{Path Not Found} The path %hs does not exist.</summary>
		public const uint STATUS_OBJECT_PATH_NOT_FOUND = 0xC000003A;
		/// <summary>The object path component was not a directory object.</summary>
		public const uint STATUS_OBJECT_PATH_SYNTAX_BAD = 0xC000003B;
		/// <summary>{Data Overrun} A data overrun error occurred.</summary>
		public const uint STATUS_DATA_OVERRUN = 0xC000003C;
		/// <summary>{Data Late} A data late error occurred.</summary>
		public const uint STATUS_DATA_LATE_ERROR = 0xC000003D;
		/// <summary>{Data Error} An error occurred in reading or writing data.</summary>
		public const uint STATUS_DATA_ERROR = 0xC000003E;
		/// <summary>{Bad CRC} A cyclic redundancy check (CRC) checksum error occurred.</summary>
		public const uint STATUS_CRC_ERROR = 0xC000003F;
		/// <summary>{Section Too Large} The specified section is too big to map the file.</summary>
		public const uint STATUS_SECTION_TOO_BIG = 0xC0000040;
		/// <summary>The NtConnectPort request is refused.</summary>
		public const uint STATUS_PORT_CONNECTION_REFUSED = 0xC0000041;
		/// <summary>The type of port handle is invalid for the operation that is requested.</summary>
		public const uint STATUS_INVALID_PORT_HANDLE = 0xC0000042;
		/// <summary>A file cannot be opened because the share access flags are incompatible.</summary>
		public const uint STATUS_SHARING_VIOLATION = 0xC0000043;
		/// <summary>Insufficient quota exists to complete the operation.</summary>
		public const uint STATUS_QUOTA_EXCEEDED = 0xC0000044;
		/// <summary>The specified page protection was not valid.</summary>
		public const uint STATUS_INVALID_PAGE_PROTECTION = 0xC0000045;
		/// <summary>An attempt to release a mutant object was made by a thread that was not the owner of the mutant object.</summary>
		public const uint STATUS_MUTANT_NOT_OWNED = 0xC0000046;
		/// <summary>An attempt was made to release a semaphore such that its maximum count would have been exceeded.</summary>
		public const uint STATUS_SEMAPHORE_LIMIT_EXCEEDED = 0xC0000047;
		/// <summary>An attempt was made to set the DebugPort or ExceptionPort of a process, but a port already exists in the process, or an attempt was made to set the CompletionPort of a file but a port was already set in the file, or an attempt was made to set the associated completion port of an ALPC port but it is already set.</summary>
		public const uint STATUS_PORT_ALREADY_SET = 0xC0000048;
		/// <summary>An attempt was made to query image information on a section that does not map an image.</summary>
		public const uint STATUS_SECTION_NOT_IMAGE = 0xC0000049;
		/// <summary>An attempt was made to suspend a thread whose suspend count was at its maximum.</summary>
		public const uint STATUS_SUSPEND_COUNT_EXCEEDED = 0xC000004A;
		/// <summary>An attempt was made to suspend a thread that has begun termination.</summary>
		public const uint STATUS_THREAD_IS_TERMINATING = 0xC000004B;
		/// <summary>An attempt was made to set the working set limit to an invalid value (for example, the minimum greater than maximum).</summary>
		public const uint STATUS_BAD_WORKING_SET_LIMIT = 0xC000004C;
		/// <summary>A section was created to map a file that is not compatible with an already existing section that maps the same file.</summary>
		public const uint STATUS_INCOMPATIBLE_FILE_MAP = 0xC000004D;
		/// <summary>A view to a section specifies a protection that is incompatible with the protection of the initial view.</summary>
		public const uint STATUS_SECTION_PROTECTION = 0xC000004E;
		/// <summary>An operation involving EAs failed because the file system does not support EAs.</summary>
		public const uint STATUS_EAS_NOT_SUPPORTED = 0xC000004F;
		/// <summary>An EA operation failed because the EA set is too large.</summary>
		public const uint STATUS_EA_TOO_LARGE = 0xC0000050;
		/// <summary>An EA operation failed because the name or EA index is invalid.</summary>
		public const uint STATUS_NONEXISTENT_EA_ENTRY = 0xC0000051;
		/// <summary>The file for which EAs were requested has no EAs.</summary>
		public const uint STATUS_NO_EAS_ON_FILE = 0xC0000052;
		/// <summary>The EA is corrupt and cannot be read.</summary>
		public const uint STATUS_EA_CORRUPT_ERROR = 0xC0000053;
		/// <summary>A requested read/write cannot be granted due to a conflicting file lock.</summary>
		public const uint STATUS_FILE_LOCK_CONFLICT = 0xC0000054;
		/// <summary>A requested file lock cannot be granted due to other existing locks.</summary>
		public const uint STATUS_LOCK_NOT_GRANTED = 0xC0000055;
		/// <summary>A non-close operation has been requested of a file object that has a delete pending.</summary>
		public const uint STATUS_DELETE_PENDING = 0xC0000056;
		/// <summary>An attempt was made to set the control attribute on a file. This attribute is not supported in the destination file system.</summary>
		public const uint STATUS_CTL_FILE_NOT_SUPPORTED = 0xC0000057;
		/// <summary>Indicates a revision number that was encountered or specified is not one that is known by the service. It might be a more recent revision than the service is aware of.</summary>
		public const uint STATUS_UNKNOWN_REVISION = 0xC0000058;
		/// <summary>Indicates that two revision levels are incompatible.</summary>
		public const uint STATUS_REVISION_MISMATCH = 0xC0000059;
		/// <summary>Indicates a particular security ID cannot be assigned as the owner of an object.</summary>
		public const uint STATUS_INVALID_OWNER = 0xC000005A;
		/// <summary>Indicates a particular security ID cannot be assigned as the primary group of an object.</summary>
		public const uint STATUS_INVALID_PRIMARY_GROUP = 0xC000005B;
		/// <summary>An attempt has been made to operate on an impersonation token by a thread that is not currently impersonating a client.</summary>
		public const uint STATUS_NO_IMPERSONATION_TOKEN = 0xC000005C;
		/// <summary>A mandatory group cannot be disabled.</summary>
		public const uint STATUS_CANT_DISABLE_MANDATORY = 0xC000005D;
		/// <summary>No logon servers are currently available to service the logon request.</summary>
		public const uint STATUS_NO_LOGON_SERVERS = 0xC000005E;
		/// <summary>A specified logon session does not exist. It might already have been terminated.</summary>
		public const uint STATUS_NO_SUCH_LOGON_SESSION = 0xC000005F;
		/// <summary>A specified privilege does not exist.</summary>
		public const uint STATUS_NO_SUCH_PRIVILEGE = 0xC0000060;
		/// <summary>A required privilege is not held by the client.</summary>
		public const uint STATUS_PRIVILEGE_NOT_HELD = 0xC0000061;
		/// <summary>The name provided is not a properly formed account name.</summary>
		public const uint STATUS_INVALID_ACCOUNT_NAME = 0xC0000062;
		/// <summary>The specified account already exists.</summary>
		public const uint STATUS_USER_EXISTS = 0xC0000063;
		/// <summary>The specified account does not exist.</summary>
		public const uint STATUS_NO_SUCH_USER = 0xC0000064;
		/// <summary>The specified group already exists.</summary>
		public const uint STATUS_GROUP_EXISTS = 0xC0000065;
		/// <summary>The specified group does not exist.</summary>
		public const uint STATUS_NO_SUCH_GROUP = 0xC0000066;
		/// <summary>The specified user account is already in the specified group account. Also used to indicate a group cannot be deleted because it contains a member.</summary>
		public const uint STATUS_MEMBER_IN_GROUP = 0xC0000067;
		/// <summary>The specified user account is not a member of the specified group account.</summary>
		public const uint STATUS_MEMBER_NOT_IN_GROUP = 0xC0000068;
		/// <summary>Indicates the requested operation would disable or delete the last remaining administration account. This is not allowed to prevent creating a situation in which the system cannot be administrated.</summary>
		public const uint STATUS_LAST_ADMIN = 0xC0000069;
		/// <summary>When trying to update a password, this return status indicates that the value provided as the current password is not correct.</summary>
		public const uint STATUS_WRONG_PASSWORD = 0xC000006A;
		/// <summary>When trying to update a password, this return status indicates that the value provided for the new password contains values that are not allowed in passwords.</summary>
		public const uint STATUS_ILL_FORMED_PASSWORD = 0xC000006B;
		/// <summary>When trying to update a password, this status indicates that some password update rule has been violated. For example, the password might not meet length criteria.</summary>
		public const uint STATUS_PASSWORD_RESTRICTION = 0xC000006C;
		/// <summary>The attempted logon is invalid. This is either due to a bad username or authentication information.</summary>
		public const uint STATUS_LOGON_FAILURE = 0xC000006D;
		/// <summary>Indicates a referenced user name and authentication information are valid, but some user account restriction has prevented successful authentication (such as time-of-day restrictions).</summary>
		public const uint STATUS_ACCOUNT_RESTRICTION = 0xC000006E;
		/// <summary>The user account has time restrictions and cannot be logged onto at this time.</summary>
		public const uint STATUS_INVALID_LOGON_HOURS = 0xC000006F;
		/// <summary>The user account is restricted so that it cannot be used to log on from the source workstation.</summary>
		public const uint STATUS_INVALID_WORKSTATION = 0xC0000070;
		/// <summary>The user account password has expired.</summary>
		public const uint STATUS_PASSWORD_EXPIRED = 0xC0000071;
		/// <summary>The referenced account is currently disabled and cannot be logged on to.</summary>
		public const uint STATUS_ACCOUNT_DISABLED = 0xC0000072;
		/// <summary>None of the information to be translated has been translated.</summary>
		public const uint STATUS_NONE_MAPPED = 0xC0000073;
		/// <summary>The number of LUIDs requested cannot be allocated with a single allocation.</summary>
		public const uint STATUS_TOO_MANY_LUIDS_REQUESTED = 0xC0000074;
		/// <summary>Indicates there are no more LUIDs to allocate.</summary>
		public const uint STATUS_LUIDS_EXHAUSTED = 0xC0000075;
		/// <summary>Indicates the sub-authority value is invalid for the particular use.</summary>
		public const uint STATUS_INVALID_SUB_AUTHORITY = 0xC0000076;
		/// <summary>Indicates the ACL structure is not valid.</summary>
		public const uint STATUS_INVALID_ACL = 0xC0000077;
		/// <summary>Indicates the SID structure is not valid.</summary>
		public const uint STATUS_INVALID_SID = 0xC0000078;
		/// <summary>Indicates the SECURITY_DESCRIPTOR structure is not valid.</summary>
		public const uint STATUS_INVALID_SECURITY_DESCR = 0xC0000079;
		/// <summary>Indicates the specified procedure address cannot be found in the DLL.</summary>
		public const uint STATUS_PROCEDURE_NOT_FOUND = 0xC000007A;
		/// <summary>{Bad Image} %hs is either not designed to run on Windows or it contains an error. Try installing the program again using the original installation media or contact your system administrator or the software vendor for support.</summary>
		public const uint STATUS_INVALID_IMAGE_FORMAT = 0xC000007B;
		/// <summary>An attempt was made to reference a token that does not exist. This is typically done by referencing the token that is associated with a thread when the thread is not impersonating a client.</summary>
		public const uint STATUS_NO_TOKEN = 0xC000007C;
		/// <summary>Indicates that an attempt to build either an inherited ACL or ACE was not successful. This can be caused by a number of things. One of the more probable causes is the replacement of a CreatorId with a SID that did not fit into the ACE or ACL.</summary>
		public const uint STATUS_BAD_INHERITANCE_ACL = 0xC000007D;
		/// <summary>The range specified in NtUnlockFile was not locked.</summary>
		public const uint STATUS_RANGE_NOT_LOCKED = 0xC000007E;
		/// <summary>An operation failed because the disk was full.</summary>
		public const uint STATUS_DISK_FULL = 0xC000007F;
		/// <summary>The GUID allocation server is disabled at the moment.</summary>
		public const uint STATUS_SERVER_DISABLED = 0xC0000080;
		/// <summary>The GUID allocation server is enabled at the moment.</summary>
		public const uint STATUS_SERVER_NOT_DISABLED = 0xC0000081;
		/// <summary>Too many GUIDs were requested from the allocation server at once.</summary>
		public const uint STATUS_TOO_MANY_GUIDS_REQUESTED = 0xC0000082;
		/// <summary>The GUIDs could not be allocated because the Authority Agent was exhausted.</summary>
		public const uint STATUS_GUIDS_EXHAUSTED = 0xC0000083;
		/// <summary>The value provided was an invalid value for an identifier authority.</summary>
		public const uint STATUS_INVALID_ID_AUTHORITY = 0xC0000084;
		/// <summary>No more authority agent values are available for the particular identifier authority value.</summary>
		public const uint STATUS_AGENTS_EXHAUSTED = 0xC0000085;
		/// <summary>An invalid volume label has been specified.</summary>
		public const uint STATUS_INVALID_VOLUME_LABEL = 0xC0000086;
		/// <summary>A mapped section could not be extended.</summary>
		public const uint STATUS_SECTION_NOT_EXTENDED = 0xC0000087;
		/// <summary>Specified section to flush does not map a data file.</summary>
		public const uint STATUS_NOT_MAPPED_DATA = 0xC0000088;
		/// <summary>Indicates the specified image file did not contain a resource section.</summary>
		public const uint STATUS_RESOURCE_DATA_NOT_FOUND = 0xC0000089;
		/// <summary>Indicates the specified resource type cannot be found in the image file.</summary>
		public const uint STATUS_RESOURCE_TYPE_NOT_FOUND = 0xC000008A;
		/// <summary>Indicates the specified resource name cannot be found in the image file.</summary>
		public const uint STATUS_RESOURCE_NAME_NOT_FOUND = 0xC000008B;
		/// <summary>{EXCEPTION} Array bounds exceeded.</summary>
		public const uint STATUS_ARRAY_BOUNDS_EXCEEDED = 0xC000008C;
		/// <summary>{EXCEPTION} Floating-point denormal operand.</summary>
		public const uint STATUS_FLOAT_DENORMAL_OPERAND = 0xC000008D;
		/// <summary>{EXCEPTION} Floating-point division by zero.</summary>
		public const uint STATUS_FLOAT_DIVIDE_BY_ZERO = 0xC000008E;
		/// <summary>{EXCEPTION} Floating-point inexact result.</summary>
		public const uint STATUS_FLOAT_INEXACT_RESULT = 0xC000008F;
		/// <summary>{EXCEPTION} Floating-point invalid operation.</summary>
		public const uint STATUS_FLOAT_INVALID_OPERATION = 0xC0000090;
		/// <summary>{EXCEPTION} Floating-point overflow.</summary>
		public const uint STATUS_FLOAT_OVERFLOW = 0xC0000091;
		/// <summary>{EXCEPTION} Floating-point stack check.</summary>
		public const uint STATUS_FLOAT_STACK_CHECK = 0xC0000092;
		/// <summary>{EXCEPTION} Floating-point underflow.</summary>
		public const uint STATUS_FLOAT_UNDERFLOW = 0xC0000093;
		/// <summary>{EXCEPTION} Integer division by zero.</summary>
		public const uint STATUS_INTEGER_DIVIDE_BY_ZERO = 0xC0000094;
		/// <summary>{EXCEPTION} Integer overflow.</summary>
		public const uint STATUS_INTEGER_OVERFLOW = 0xC0000095;
		/// <summary>{EXCEPTION} Privileged instruction.</summary>
		public const uint STATUS_PRIVILEGED_INSTRUCTION = 0xC0000096;
		/// <summary>An attempt was made to install more paging files than the system supports.</summary>
		public const uint STATUS_TOO_MANY_PAGING_FILES = 0xC0000097;
		/// <summary>The volume for a file has been externally altered such that the opened file is no longer valid.</summary>
		public const uint STATUS_FILE_INVALID = 0xC0000098;
		/// <summary>When a block of memory is allotted for future updates, such as the memory allocated to hold discretionary access control and primary group information, successive updates might exceed the amount of memory originally allotted. Because a quota might already have been charged to several processes that have handles to the object, it is not reasonable to alter the size of the allocated memory. Instead, a request that requires more memory than has been allotted must fail and the STATUS_ALLOTTED_SPACE_EXCEEDED error returned.</summary>
		public const uint STATUS_ALLOTTED_SPACE_EXCEEDED = 0xC0000099;
		/// <summary>Insufficient system resources exist to complete the API.</summary>
		public const uint STATUS_INSUFFICIENT_RESOURCES = 0xC000009A;
		/// <summary>An attempt has been made to open a DFS exit path control file.</summary>
		public const uint STATUS_DFS_EXIT_PATH_FOUND = 0xC000009B;
		/// <summary>There are bad blocks (sectors) on the hard disk.</summary>
		public const uint STATUS_DEVICE_DATA_ERROR = 0xC000009C;
		/// <summary>There is bad cabling, non-termination, or the controller is not able to obtain access to the hard disk.</summary>
		public const uint STATUS_DEVICE_NOT_CONNECTED = 0xC000009D;
		/// <summary>Virtual memory cannot be freed because the base address is not the base of the region and a region size of zero was specified.</summary>
		public const uint STATUS_FREE_VM_NOT_AT_BASE = 0xC000009F;
		/// <summary>An attempt was made to free virtual memory that is not allocated.</summary>
		public const uint STATUS_MEMORY_NOT_ALLOCATED = 0xC00000A0;
		/// <summary>The working set is not big enough to allow the requested pages to be locked.</summary>
		public const uint STATUS_WORKING_SET_QUOTA = 0xC00000A1;
		/// <summary>{Write Protect Error} The disk cannot be written to because it is write-protected. Remove the write protection from the volume %hs in drive %hs.</summary>
		public const uint STATUS_MEDIA_WRITE_PROTECTED = 0xC00000A2;
		/// <summary>{Drive Not Ready} The drive is not ready for use; its door might be open. Check drive %hs and make sure that a disk is inserted and that the drive door is closed.</summary>
		public const uint STATUS_DEVICE_NOT_READY = 0xC00000A3;
		/// <summary>The specified attributes are invalid or are incompatible with the attributes for the group as a whole.</summary>
		public const uint STATUS_INVALID_GROUP_ATTRIBUTES = 0xC00000A4;
		/// <summary>A specified impersonation level is invalid. Also used to indicate that a required impersonation level was not provided.</summary>
		public const uint STATUS_BAD_IMPERSONATION_LEVEL = 0xC00000A5;
		/// <summary>An attempt was made to open an anonymous-level token. Anonymous tokens cannot be opened.</summary>
		public const uint STATUS_CANT_OPEN_ANONYMOUS = 0xC00000A6;
		/// <summary>The validation information class requested was invalid.</summary>
		public const uint STATUS_BAD_VALIDATION_CLASS = 0xC00000A7;
		/// <summary>The type of a token object is inappropriate for its attempted use.</summary>
		public const uint STATUS_BAD_TOKEN_TYPE = 0xC00000A8;
		/// <summary>The type of a token object is inappropriate for its attempted use.</summary>
		public const uint STATUS_BAD_MASTER_BOOT_RECORD = 0xC00000A9;
		/// <summary>An attempt was made to execute an instruction at an unaligned address and the host system does not support unaligned instruction references.</summary>
		public const uint STATUS_INSTRUCTION_MISALIGNMENT = 0xC00000AA;
		/// <summary>The maximum named pipe instance count has been reached.</summary>
		public const uint STATUS_INSTANCE_NOT_AVAILABLE = 0xC00000AB;
		/// <summary>An instance of a named pipe cannot be found in the listening state.</summary>
		public const uint STATUS_PIPE_NOT_AVAILABLE = 0xC00000AC;
		/// <summary>The named pipe is not in the connected or closing state.</summary>
		public const uint STATUS_INVALID_PIPE_STATE = 0xC00000AD;
		/// <summary>The specified pipe is set to complete operations and there are current I/O operations queued so that it cannot be changed to queue operations.</summary>
		public const uint STATUS_PIPE_BUSY = 0xC00000AE;
		/// <summary>The specified handle is not open to the server end of the named pipe.</summary>
		public const uint STATUS_ILLEGAL_FUNCTION = 0xC00000AF;
		/// <summary>The specified named pipe is in the disconnected state.</summary>
		public const uint STATUS_PIPE_DISCONNECTED = 0xC00000B0;
		/// <summary>The specified named pipe is in the closing state.</summary>
		public const uint STATUS_PIPE_CLOSING = 0xC00000B1;
		/// <summary>The specified named pipe is in the connected state.</summary>
		public const uint STATUS_PIPE_CONNECTED = 0xC00000B2;
		/// <summary>The specified named pipe is in the listening state.</summary>
		public const uint STATUS_PIPE_LISTENING = 0xC00000B3;
		/// <summary>The specified named pipe is not in message mode.</summary>
		public const uint STATUS_INVALID_READ_MODE = 0xC00000B4;
		/// <summary>{Device Timeout} The specified I/O operation on %hs was not completed before the time-out period expired.</summary>
		public const uint STATUS_IO_TIMEOUT = 0xC00000B5;
		/// <summary>The specified file has been closed by another process.</summary>
		public const uint STATUS_FILE_FORCED_CLOSED = 0xC00000B6;
		/// <summary>Profiling is not started.</summary>
		public const uint STATUS_PROFILING_NOT_STARTED = 0xC00000B7;
		/// <summary>Profiling is not stopped.</summary>
		public const uint STATUS_PROFILING_NOT_STOPPED = 0xC00000B8;
		/// <summary>The passed ACL did not contain the minimum required information.</summary>
		public const uint STATUS_COULD_NOT_INTERPRET = 0xC00000B9;
		/// <summary>The file that was specified as a target is a directory, and the caller specified that it could be anything but a directory.</summary>
		public const uint STATUS_FILE_IS_A_DIRECTORY = 0xC00000BA;
		/// <summary>The request is not supported.</summary>
		public const uint STATUS_NOT_SUPPORTED = 0xC00000BB;
		/// <summary>This remote computer is not listening.</summary>
		public const uint STATUS_REMOTE_NOT_LISTENING = 0xC00000BC;
		/// <summary>A duplicate name exists on the network.</summary>
		public const uint STATUS_DUPLICATE_NAME = 0xC00000BD;
		/// <summary>The network path cannot be located.</summary>
		public const uint STATUS_BAD_NETWORK_PATH = 0xC00000BE;
		/// <summary>The network is busy.</summary>
		public const uint STATUS_NETWORK_BUSY = 0xC00000BF;
		/// <summary>This device does not exist.</summary>
		public const uint STATUS_DEVICE_DOES_NOT_EXIST = 0xC00000C0;
		/// <summary>The network BIOS command limit has been reached.</summary>
		public const uint STATUS_TOO_MANY_COMMANDS = 0xC00000C1;
		/// <summary>An I/O adapter hardware error has occurred.</summary>
		public const uint STATUS_ADAPTER_HARDWARE_ERROR = 0xC00000C2;
		/// <summary>The network responded incorrectly.</summary>
		public const uint STATUS_INVALID_NETWORK_RESPONSE = 0xC00000C3;
		/// <summary>An unexpected network error occurred.</summary>
		public const uint STATUS_UNEXPECTED_NETWORK_ERROR = 0xC00000C4;
		/// <summary>The remote adapter is not compatible.</summary>
		public const uint STATUS_BAD_REMOTE_ADAPTER = 0xC00000C5;
		/// <summary>The print queue is full.</summary>
		public const uint STATUS_PRINT_QUEUE_FULL = 0xC00000C6;
		/// <summary>Space to store the file that is waiting to be printed is not available on the server.</summary>
		public const uint STATUS_NO_SPOOL_SPACE = 0xC00000C7;
		/// <summary>The requested print file has been canceled.</summary>
		public const uint STATUS_PRINT_CANCELLED = 0xC00000C8;
		/// <summary>The network name was deleted.</summary>
		public const uint STATUS_NETWORK_NAME_DELETED = 0xC00000C9;
		/// <summary>Network access is denied.</summary>
		public const uint STATUS_NETWORK_ACCESS_DENIED = 0xC00000CA;
		/// <summary>{Incorrect Network Resource Type} The specified device type (LPT, for example) conflicts with the actual device type on the remote resource.</summary>
		public const uint STATUS_BAD_DEVICE_TYPE = 0xC00000CB;
		/// <summary>{Network Name Not Found} The specified share name cannot be found on the remote server.</summary>
		public const uint STATUS_BAD_NETWORK_NAME = 0xC00000CC;
		/// <summary>The name limit for the network adapter card of the local computer was exceeded.</summary>
		public const uint STATUS_TOO_MANY_NAMES = 0xC00000CD;
		/// <summary>The network BIOS session limit was exceeded.</summary>
		public const uint STATUS_TOO_MANY_SESSIONS = 0xC00000CE;
		/// <summary>File sharing has been temporarily paused.</summary>
		public const uint STATUS_SHARING_PAUSED = 0xC00000CF;
		/// <summary>No more connections can be made to this remote computer at this time because the computer has already accepted the maximum number of connections.</summary>
		public const uint STATUS_REQUEST_NOT_ACCEPTED = 0xC00000D0;
		/// <summary>Print or disk redirection is temporarily paused.</summary>
		public const uint STATUS_REDIRECTOR_PAUSED = 0xC00000D1;
		/// <summary>A network data fault occurred.</summary>
		public const uint STATUS_NET_WRITE_FAULT = 0xC00000D2;
		/// <summary>The number of active profiling objects is at the maximum and no more can be started.</summary>
		public const uint STATUS_PROFILING_AT_LIMIT = 0xC00000D3;
		/// <summary>{Incorrect Volume} The destination file of a rename request is located on a different device than the source of the rename request.</summary>
		public const uint STATUS_NOT_SAME_DEVICE = 0xC00000D4;
		/// <summary>The specified file has been renamed and thus cannot be modified.</summary>
		public const uint STATUS_FILE_RENAMED = 0xC00000D5;
		/// <summary>{Network Request Timeout} The session with a remote server has been disconnected because the time-out interval for a request has expired.</summary>
		public const uint STATUS_VIRTUAL_CIRCUIT_CLOSED = 0xC00000D6;
		/// <summary>Indicates an attempt was made to operate on the security of an object that does not have security associated with it.</summary>
		public const uint STATUS_NO_SECURITY_ON_OBJECT = 0xC00000D7;
		/// <summary>Used to indicate that an operation cannot continue without blocking for I/O.</summary>
		public const uint STATUS_CANT_WAIT = 0xC00000D8;
		/// <summary>Used to indicate that a read operation was done on an empty pipe.</summary>
		public const uint STATUS_PIPE_EMPTY = 0xC00000D9;
		/// <summary>Configuration information could not be read from the domain controller, either because the machine is unavailable or access has been denied.</summary>
		public const uint STATUS_CANT_ACCESS_DOMAIN_INFO = 0xC00000DA;
		/// <summary>Indicates that a thread attempted to terminate itself by default (called NtTerminateThread with NULL) and it was the last thread in the current process.</summary>
		public const uint STATUS_CANT_TERMINATE_SELF = 0xC00000DB;
		/// <summary>Indicates the Sam Server was in the wrong state to perform the desired operation.</summary>
		public const uint STATUS_INVALID_SERVER_STATE = 0xC00000DC;
		/// <summary>Indicates the domain was in the wrong state to perform the desired operation.</summary>
		public const uint STATUS_INVALID_DOMAIN_STATE = 0xC00000DD;
		/// <summary>This operation is only allowed for the primary domain controller of the domain.</summary>
		public const uint STATUS_INVALID_DOMAIN_ROLE = 0xC00000DE;
		/// <summary>The specified domain did not exist.</summary>
		public const uint STATUS_NO_SUCH_DOMAIN = 0xC00000DF;
		/// <summary>The specified domain already exists.</summary>
		public const uint STATUS_DOMAIN_EXISTS = 0xC00000E0;
		/// <summary>An attempt was made to exceed the limit on the number of domains per server for this release.</summary>
		public const uint STATUS_DOMAIN_LIMIT_EXCEEDED = 0xC00000E1;
		/// <summary>An error status returned when the opportunistic lock (oplock) request is denied.</summary>
		public const uint STATUS_OPLOCK_NOT_GRANTED = 0xC00000E2;
		/// <summary>An error status returned when an invalid opportunistic lock (oplock) acknowledgment is received by a file system.</summary>
		public const uint STATUS_INVALID_OPLOCK_PROTOCOL = 0xC00000E3;
		/// <summary>This error indicates that the requested operation cannot be completed due to a catastrophic media failure or an on-disk data structure corruption.</summary>
		public const uint STATUS_INTERNAL_DB_CORRUPTION = 0xC00000E4;
		/// <summary>An internal error occurred.</summary>
		public const uint STATUS_INTERNAL_ERROR = 0xC00000E5;
		/// <summary>Indicates generic access types were contained in an access mask which should already be mapped to non-generic access types.</summary>
		public const uint STATUS_GENERIC_NOT_MAPPED = 0xC00000E6;
		/// <summary>Indicates a security descriptor is not in the necessary format (absolute or self-relative).</summary>
		public const uint STATUS_BAD_DESCRIPTOR_FORMAT = 0xC00000E7;
		/// <summary>An access to a user buffer failed at an expected point in time. This code is defined because the caller does not want to accept STATUS_ACCESS_VIOLATION in its filter.</summary>
		public const uint STATUS_INVALID_USER_BUFFER = 0xC00000E8;
		/// <summary>If an I/O error that is not defined in the standard FsRtl filter is returned, it is converted to the following error, which is guaranteed to be in the filter. In this case, information is lost; however, the filter correctly handles the exception.</summary>
		public const uint STATUS_UNEXPECTED_IO_ERROR = 0xC00000E9;
		/// <summary>If an MM error that is not defined in the standard FsRtl filter is returned, it is converted to one of the following errors, which are guaranteed to be in the filter. In this case, information is lost; however, the filter correctly handles the exception.</summary>
		public const uint STATUS_UNEXPECTED_MM_CREATE_ERR = 0xC00000EA;
		/// <summary>If an MM error that is not defined in the standard FsRtl filter is returned, it is converted to one of the following errors, which are guaranteed to be in the filter. In this case, information is lost; however, the filter correctly handles the exception.</summary>
		public const uint STATUS_UNEXPECTED_MM_MAP_ERROR = 0xC00000EB;
		/// <summary>If an MM error that is not defined in the standard FsRtl filter is returned, it is converted to one of the following errors, which are guaranteed to be in the filter. In this case, information is lost; however, the filter correctly handles the exception.</summary>
		public const uint STATUS_UNEXPECTED_MM_EXTEND_ERR = 0xC00000EC;
		/// <summary>The requested action is restricted for use by logon processes only. The calling process has not registered as a logon process.</summary>
		public const uint STATUS_NOT_LOGON_PROCESS = 0xC00000ED;
		/// <summary>An attempt has been made to start a new session manager or LSA logon session by using an ID that is already in use.</summary>
		public const uint STATUS_LOGON_SESSION_EXISTS = 0xC00000EE;
		/// <summary>An invalid parameter was passed to a service or function as the first argument.</summary>
		public const uint STATUS_INVALID_PARAMETER_1 = 0xC00000EF;
		/// <summary>An invalid parameter was passed to a service or function as the second argument.</summary>
		public const uint STATUS_INVALID_PARAMETER_2 = 0xC00000F0;
		/// <summary>An invalid parameter was passed to a service or function as the third argument.</summary>
		public const uint STATUS_INVALID_PARAMETER_3 = 0xC00000F1;
		/// <summary>An invalid parameter was passed to a service or function as the fourth argument.</summary>
		public const uint STATUS_INVALID_PARAMETER_4 = 0xC00000F2;
		/// <summary>An invalid parameter was passed to a service or function as the fifth argument.</summary>
		public const uint STATUS_INVALID_PARAMETER_5 = 0xC00000F3;
		/// <summary>An invalid parameter was passed to a service or function as the sixth argument.</summary>
		public const uint STATUS_INVALID_PARAMETER_6 = 0xC00000F4;
		/// <summary>An invalid parameter was passed to a service or function as the seventh argument.</summary>
		public const uint STATUS_INVALID_PARAMETER_7 = 0xC00000F5;
		/// <summary>An invalid parameter was passed to a service or function as the eighth argument.</summary>
		public const uint STATUS_INVALID_PARAMETER_8 = 0xC00000F6;
		/// <summary>An invalid parameter was passed to a service or function as the ninth argument.</summary>
		public const uint STATUS_INVALID_PARAMETER_9 = 0xC00000F7;
		/// <summary>An invalid parameter was passed to a service or function as the tenth argument.</summary>
		public const uint STATUS_INVALID_PARAMETER_10 = 0xC00000F8;
		/// <summary>An invalid parameter was passed to a service or function as the eleventh argument.</summary>
		public const uint STATUS_INVALID_PARAMETER_11 = 0xC00000F9;
		/// <summary>An invalid parameter was passed to a service or function as the twelfth argument.</summary>
		public const uint STATUS_INVALID_PARAMETER_12 = 0xC00000FA;
		/// <summary>An attempt was made to access a network file, but the network software was not yet started.</summary>
		public const uint STATUS_REDIRECTOR_NOT_STARTED = 0xC00000FB;
		/// <summary>An attempt was made to start the redirector, but the redirector has already been started.</summary>
		public const uint STATUS_REDIRECTOR_STARTED = 0xC00000FC;
		/// <summary>A new guard page for the stack cannot be created.</summary>
		public const uint STATUS_STACK_OVERFLOW = 0xC00000FD;
		/// <summary>A specified authentication package is unknown.</summary>
		public const uint STATUS_NO_SUCH_PACKAGE = 0xC00000FE;
		/// <summary>A malformed function table was encountered during an unwind operation.</summary>
		public const uint STATUS_BAD_FUNCTION_TABLE = 0xC00000FF;
		/// <summary>Indicates the specified environment variable name was not found in the specified environment block.</summary>
		public const uint STATUS_VARIABLE_NOT_FOUND = 0xC0000100;
		/// <summary>Indicates that the directory trying to be deleted is not empty.</summary>
		public const uint STATUS_DIRECTORY_NOT_EMPTY = 0xC0000101;
		/// <summary>{Corrupt File} The file or directory %hs is corrupt and unreadable. Run the Chkdsk utility.</summary>
		public const uint STATUS_FILE_CORRUPT_ERROR = 0xC0000102;
		/// <summary>A requested opened file is not a directory.</summary>
		public const uint STATUS_NOT_A_DIRECTORY = 0xC0000103;
		/// <summary>The logon session is not in a state that is consistent with the requested operation.</summary>
		public const uint STATUS_BAD_LOGON_SESSION_STATE = 0xC0000104;
		/// <summary>An internal LSA error has occurred. An authentication package has requested the creation of a logon session but the ID of an already existing logon session has been specified.</summary>
		public const uint STATUS_LOGON_SESSION_COLLISION = 0xC0000105;
		/// <summary>A specified name string is too long for its intended use.</summary>
		public const uint STATUS_NAME_TOO_LONG = 0xC0000106;
		/// <summary>The user attempted to force close the files on a redirected drive, but there were opened files on the drive, and the user did not specify a sufficient level of force.</summary>
		public const uint STATUS_FILES_OPEN = 0xC0000107;
		/// <summary>The user attempted to force close the files on a redirected drive, but there were opened directories on the drive, and the user did not specify a sufficient level of force.</summary>
		public const uint STATUS_CONNECTION_IN_USE = 0xC0000108;
		/// <summary>RtlFindMessage could not locate the requested message ID in the message table resource.</summary>
		public const uint STATUS_MESSAGE_NOT_FOUND = 0xC0000109;
		/// <summary>An attempt was made to duplicate an object handle into or out of an exiting process.</summary>
		public const uint STATUS_PROCESS_IS_TERMINATING = 0xC000010A;
		/// <summary>Indicates an invalid value has been provided for the LogonType requested.</summary>
		public const uint STATUS_INVALID_LOGON_TYPE = 0xC000010B;
		/// <summary>Indicates that an attempt was made to assign protection to a file system file or directory and one of the SIDs in the security descriptor could not be translated into a GUID that could be stored by the file system. This causes the protection attempt to fail, which might cause a file creation attempt to fail.</summary>
		public const uint STATUS_NO_GUID_TRANSLATION = 0xC000010C;
		/// <summary>Indicates that an attempt has been made to impersonate via a named pipe that has not yet been read from.</summary>
		public const uint STATUS_CANNOT_IMPERSONATE = 0xC000010D;
		/// <summary>Indicates that the specified image is already loaded.</summary>
		public const uint STATUS_IMAGE_ALREADY_LOADED = 0xC000010E;
		/// <summary>Indicates that an attempt was made to change the size of the LDT for a process that has no LDT.</summary>
		public const uint STATUS_NO_LDT = 0xC0000117;
		/// <summary>Indicates that an attempt was made to grow an LDT by setting its size, or that the size was not an even number of selectors.</summary>
		public const uint STATUS_INVALID_LDT_SIZE = 0xC0000118;
		/// <summary>Indicates that the starting value for the LDT information was not an integral multiple of the selector size.</summary>
		public const uint STATUS_INVALID_LDT_OFFSET = 0xC0000119;
		/// <summary>Indicates that the user supplied an invalid descriptor when trying to set up LDT descriptors.</summary>
		public const uint STATUS_INVALID_LDT_DESCRIPTOR = 0xC000011A;
		/// <summary>The specified image file did not have the correct format. It appears to be NE format.</summary>
		public const uint STATUS_INVALID_IMAGE_NE_FORMAT = 0xC000011B;
		/// <summary>Indicates that the transaction state of a registry subtree is incompatible with the requested operation. For example, a request has been made to start a new transaction with one already in progress, or a request has been made to apply a transaction when one is not currently in progress.</summary>
		public const uint STATUS_RXACT_INVALID_STATE = 0xC000011C;
		/// <summary>Indicates an error has occurred during a registry transaction commit. The database has been left in an unknown, but probably inconsistent, state. The state of the registry transaction is left as COMMITTING.</summary>
		public const uint STATUS_RXACT_COMMIT_FAILURE = 0xC000011D;
		/// <summary>An attempt was made to map a file of size zero with the maximum size specified as zero.</summary>
		public const uint STATUS_MAPPED_FILE_SIZE_ZERO = 0xC000011E;
		/// <summary>Too many files are opened on a remote server. This error should only be returned by the Windows redirector on a remote drive.</summary>
		public const uint STATUS_TOO_MANY_OPENED_FILES = 0xC000011F;
		/// <summary>The I/O request was canceled.</summary>
		public const uint STATUS_CANCELLED = 0xC0000120;
		/// <summary>An attempt has been made to remove a file or directory that cannot be deleted.</summary>
		public const uint STATUS_CANNOT_DELETE = 0xC0000121;
		/// <summary>Indicates a name that was specified as a remote computer name is syntactically invalid.</summary>
		public const uint STATUS_INVALID_COMPUTER_NAME = 0xC0000122;
		/// <summary>An I/O request other than close was performed on a file after it was deleted, which can only happen to a request that did not complete before the last handle was closed via NtClose.</summary>
		public const uint STATUS_FILE_DELETED = 0xC0000123;
		/// <summary>Indicates an operation that is incompatible with built-in accounts has been attempted on a built-in (special) SAM account. For example, built-in accounts cannot be deleted.</summary>
		public const uint STATUS_SPECIAL_ACCOUNT = 0xC0000124;
		/// <summary>The operation requested cannot be performed on the specified group because it is a built-in special group.</summary>
		public const uint STATUS_SPECIAL_GROUP = 0xC0000125;
		/// <summary>The operation requested cannot be performed on the specified user because it is a built-in special user.</summary>
		public const uint STATUS_SPECIAL_USER = 0xC0000126;
		/// <summary>Indicates a member cannot be removed from a group because the group is currently the member's primary group.</summary>
		public const uint STATUS_MEMBERS_PRIMARY_GROUP = 0xC0000127;
		/// <summary>An I/O request other than close and several other special case operations was attempted using a file object that had already been closed.</summary>
		public const uint STATUS_FILE_CLOSED = 0xC0000128;
		/// <summary>Indicates a process has too many threads to perform the requested action. For example, assignment of a primary token can be performed only when a process has zero or one threads.</summary>
		public const uint STATUS_TOO_MANY_THREADS = 0xC0000129;
		/// <summary>An attempt was made to operate on a thread within a specific process, but the specified thread is not in the specified process.</summary>
		public const uint STATUS_THREAD_NOT_IN_PROCESS = 0xC000012A;
		/// <summary>An attempt was made to establish a token for use as a primary token but the token is already in use. A token can only be the primary token of one process at a time.</summary>
		public const uint STATUS_TOKEN_ALREADY_IN_USE = 0xC000012B;
		/// <summary>The page file quota was exceeded.</summary>
		public const uint STATUS_PAGEFILE_QUOTA_EXCEEDED = 0xC000012C;
		/// <summary>{Out of Virtual Memory} Your system is low on virtual memory. To ensure that Windows runs correctly, increase the size of your virtual memory paging file. For more information, see Help.</summary>
		public const uint STATUS_COMMITMENT_LIMIT = 0xC000012D;
		/// <summary>The specified image file did not have the correct format: it appears to be LE format.</summary>
		public const uint STATUS_INVALID_IMAGE_LE_FORMAT = 0xC000012E;
		/// <summary>The specified image file did not have the correct format: it did not have an initial MZ.</summary>
		public const uint STATUS_INVALID_IMAGE_NOT_MZ = 0xC000012F;
		/// <summary>The specified image file did not have the correct format: it did not have a proper e_lfarlc in the MZ header.</summary>
		public const uint STATUS_INVALID_IMAGE_PROTECT = 0xC0000130;
		/// <summary>The specified image file did not have the correct format: it appears to be a 16-bit Windows image.</summary>
		public const uint STATUS_INVALID_IMAGE_WIN_16 = 0xC0000131;
		/// <summary>The Netlogon service cannot start because another Netlogon service running in the domain conflicts with the specified role.</summary>
		public const uint STATUS_LOGON_SERVER_CONFLICT = 0xC0000132;
		/// <summary>The time at the primary domain controller is different from the time at the backup domain controller or member server by too large an amount.</summary>
		public const uint STATUS_TIME_DIFFERENCE_AT_DC = 0xC0000133;
		/// <summary>The SAM database on a Windows Server operating system is significantly out of synchronization with the copy on the domain controller. A complete synchronization is required.</summary>
		public const uint STATUS_SYNCHRONIZATION_REQUIRED = 0xC0000134;
		/// <summary>{Unable To Locate Component} This application has failed to start because %hs was not found. Reinstalling the application might fix this problem.</summary>
		public const uint STATUS_DLL_NOT_FOUND = 0xC0000135;
		/// <summary>The NtCreateFile API failed. This error should never be returned to an application; it is a place holder for the Windows LAN Manager Redirector to use in its internal error-mapping routines.</summary>
		public const uint STATUS_OPEN_FAILED = 0xC0000136;
		/// <summary>{Privilege Failed} The I/O permissions for the process could not be changed.</summary>
		public const uint STATUS_IO_PRIVILEGE_FAILED = 0xC0000137;
		/// <summary>{Ordinal Not Found} The ordinal %ld could not be located in the dynamic link library %hs.</summary>
		public const uint STATUS_ORDINAL_NOT_FOUND = 0xC0000138;
		/// <summary>{Entry Point Not Found} The procedure entry point %hs could not be located in the dynamic link library %hs.</summary>
		public const uint STATUS_ENTRYPOINT_NOT_FOUND = 0xC0000139;
		/// <summary>{Application Exit by CTRL+C} The application terminated as a result of a CTRL+C.</summary>
		public const uint STATUS_CONTROL_C_EXIT = 0xC000013A;
		/// <summary>{Virtual Circuit Closed} The network transport on your computer has closed a network connection. There might or might not be I/O requests outstanding.</summary>
		public const uint STATUS_LOCAL_DISCONNECT = 0xC000013B;
		/// <summary>{Virtual Circuit Closed} The network transport on a remote computer has closed a network connection. There might or might not be I/O requests outstanding.</summary>
		public const uint STATUS_REMOTE_DISCONNECT = 0xC000013C;
		/// <summary>{Insufficient Resources on Remote Computer} The remote computer has insufficient resources to complete the network request. For example, the remote computer might not have enough available memory to carry out the request at this time.</summary>
		public const uint STATUS_REMOTE_RESOURCES = 0xC000013D;
		/// <summary>{Virtual Circuit Closed} An existing connection (virtual circuit) has been broken at the remote computer. There is probably something wrong with the network software protocol or the network hardware on the remote computer.</summary>
		public const uint STATUS_LINK_FAILED = 0xC000013E;
		/// <summary>{Virtual Circuit Closed} The network transport on your computer has closed a network connection because it had to wait too long for a response from the remote computer.</summary>
		public const uint STATUS_LINK_TIMEOUT = 0xC000013F;
		/// <summary>The connection handle that was given to the transport was invalid.</summary>
		public const uint STATUS_INVALID_CONNECTION = 0xC0000140;
		/// <summary>The address handle that was given to the transport was invalid.</summary>
		public const uint STATUS_INVALID_ADDRESS = 0xC0000141;
		/// <summary>{DLL Initialization Failed} Initialization of the dynamic link library %hs failed. The process is terminating abnormally.</summary>
		public const uint STATUS_DLL_INIT_FAILED = 0xC0000142;
		/// <summary>{Missing System File} The required system file %hs is bad or missing.</summary>
		public const uint STATUS_MISSING_SYSTEMFILE = 0xC0000143;
		/// <summary>{Application Error} The exception %s (0x%08lx) occurred in the application at location 0x%08lx.</summary>
		public const uint STATUS_UNHANDLED_EXCEPTION = 0xC0000144;
		/// <summary>{Application Error} The application failed to initialize properly (0x%lx). Click OK to terminate the application.</summary>
		public const uint STATUS_APP_INIT_FAILURE = 0xC0000145;
		/// <summary>{Unable to Create Paging File} The creation of the paging file %hs failed (%lx). The requested size was %ld.</summary>
		public const uint STATUS_PAGEFILE_CREATE_FAILED = 0xC0000146;
		/// <summary>{No Paging File Specified} No paging file was specified in the system configuration.</summary>
		public const uint STATUS_NO_PAGEFILE = 0xC0000147;
		/// <summary>{Incorrect System Call Level} An invalid level was passed into the specified system call.</summary>
		public const uint STATUS_INVALID_LEVEL = 0xC0000148;
		/// <summary>{Incorrect Password to LAN Manager Server} You specified an incorrect password to a LAN Manager 2.x or MS-NET server.</summary>
		public const uint STATUS_WRONG_PASSWORD_CORE = 0xC0000149;
		/// <summary>{EXCEPTION} A real-mode application issued a floating-point instruction and floating-point hardware is not present.</summary>
		public const uint STATUS_ILLEGAL_FLOAT_CONTEXT = 0xC000014A;
		/// <summary>The pipe operation has failed because the other end of the pipe has been closed.</summary>
		public const uint STATUS_PIPE_BROKEN = 0xC000014B;
		/// <summary>{The Registry Is Corrupt} The structure of one of the files that contains registry data is corrupt; the image of the file in memory is corrupt; or the file could not be recovered because the alternate copy or log was absent or corrupt.</summary>
		public const uint STATUS_REGISTRY_CORRUPT = 0xC000014C;
		/// <summary>An I/O operation initiated by the Registry failed and cannot be recovered. The registry could not read in, write out, or flush one of the files that contain the system's image of the registry.</summary>
		public const uint STATUS_REGISTRY_IO_FAILED = 0xC000014D;
		/// <summary>An event pair synchronization operation was performed using the thread-specific client/server event pair object, but no event pair object was associated with the thread.</summary>
		public const uint STATUS_NO_EVENT_PAIR = 0xC000014E;
		/// <summary>The volume does not contain a recognized file system. Be sure that all required file system drivers are loaded and that the volume is not corrupt.</summary>
		public const uint STATUS_UNRECOGNIZED_VOLUME = 0xC000014F;
		/// <summary>No serial device was successfully initialized. The serial driver will unload.</summary>
		public const uint STATUS_SERIAL_NO_DEVICE_INITED = 0xC0000150;
		/// <summary>The specified local group does not exist.</summary>
		public const uint STATUS_NO_SUCH_ALIAS = 0xC0000151;
		/// <summary>The specified account name is not a member of the group.</summary>
		public const uint STATUS_MEMBER_NOT_IN_ALIAS = 0xC0000152;
		/// <summary>The specified account name is already a member of the group.</summary>
		public const uint STATUS_MEMBER_IN_ALIAS = 0xC0000153;
		/// <summary>The specified local group already exists.</summary>
		public const uint STATUS_ALIAS_EXISTS = 0xC0000154;
		/// <summary>A requested type of logon (for example, interactive, network, and service) is not granted by the local security policy of the target system. Ask the system administrator to grant the necessary form of logon.</summary>
		public const uint STATUS_LOGON_NOT_GRANTED = 0xC0000155;
		/// <summary>The maximum number of secrets that can be stored in a single system was exceeded. The length and number of secrets is limited to satisfy U.S. State Department export restrictions.</summary>
		public const uint STATUS_TOO_MANY_SECRETS = 0xC0000156;
		/// <summary>The length of a secret exceeds the maximum allowable length. The length and number of secrets is limited to satisfy U.S. State Department export restrictions.</summary>
		public const uint STATUS_SECRET_TOO_LONG = 0xC0000157;
		/// <summary>The local security authority (LSA) database contains an internal inconsistency.</summary>
		public const uint STATUS_INTERNAL_DB_ERROR = 0xC0000158;
		/// <summary>The requested operation cannot be performed in full-screen mode.</summary>
		public const uint STATUS_FULLSCREEN_MODE = 0xC0000159;
		/// <summary>During a logon attempt, the user's security context accumulated too many security IDs. This is a very unusual situation. Remove the user from some global or local groups to reduce the number of security IDs to incorporate into the security context.</summary>
		public const uint STATUS_TOO_MANY_CONTEXT_IDS = 0xC000015A;
		/// <summary>A user has requested a type of logon (for example, interactive or network) that has not been granted. An administrator has control over who can logon interactively and through the network.</summary>
		public const uint STATUS_LOGON_TYPE_NOT_GRANTED = 0xC000015B;
		/// <summary>The system has attempted to load or restore a file into the registry, and the specified file is not in the format of a registry file.</summary>
		public const uint STATUS_NOT_REGISTRY_FILE = 0xC000015C;
		/// <summary>An attempt was made to change a user password in the security account manager without providing the necessary Windows cross-encrypted password.</summary>
		public const uint STATUS_NT_CROSS_ENCRYPTION_REQUIRED = 0xC000015D;
		/// <summary>A Windows Server has an incorrect configuration.</summary>
		public const uint STATUS_DOMAIN_CTRLR_CONFIG_ERROR = 0xC000015E;
		/// <summary>An attempt was made to explicitly access the secondary copy of information via a device control to the fault tolerance driver and the secondary copy is not present in the system.</summary>
		public const uint STATUS_FT_MISSING_MEMBER = 0xC000015F;
		/// <summary>A configuration registry node that represents a driver service entry was ill-formed and did not contain the required value entries.</summary>
		public const uint STATUS_ILL_FORMED_SERVICE_ENTRY = 0xC0000160;
		/// <summary>An illegal character was encountered. For a multibyte character set, this includes a lead byte without a succeeding trail byte. For the Unicode character set this includes the characters 0xFFFF and 0xFFFE.</summary>
		public const uint STATUS_ILLEGAL_CHARACTER = 0xC0000161;
		/// <summary>No mapping for the Unicode character exists in the target multibyte code page.</summary>
		public const uint STATUS_UNMAPPABLE_CHARACTER = 0xC0000162;
		/// <summary>The Unicode character is not defined in the Unicode character set that is installed on the system.</summary>
		public const uint STATUS_UNDEFINED_CHARACTER = 0xC0000163;
		/// <summary>The paging file cannot be created on a floppy disk.</summary>
		public const uint STATUS_FLOPPY_VOLUME = 0xC0000164;
		/// <summary>{Floppy Disk Error} While accessing a floppy disk, an ID address mark was not found.</summary>
		public const uint STATUS_FLOPPY_ID_MARK_NOT_FOUND = 0xC0000165;
		/// <summary>{Floppy Disk Error} While accessing a floppy disk, the track address from the sector ID field was found to be different from the track address that is maintained by the controller.</summary>
		public const uint STATUS_FLOPPY_WRONG_CYLINDER = 0xC0000166;
		/// <summary>{Floppy Disk Error} The floppy disk controller reported an error that is not recognized by the floppy disk driver.</summary>
		public const uint STATUS_FLOPPY_UNKNOWN_ERROR = 0xC0000167;
		/// <summary>{Floppy Disk Error} While accessing a floppy-disk, the controller returned inconsistent results via its registers.</summary>
		public const uint STATUS_FLOPPY_BAD_REGISTERS = 0xC0000168;
		/// <summary>{Hard Disk Error} While accessing the hard disk, a recalibrate operation failed, even after retries.</summary>
		public const uint STATUS_DISK_RECALIBRATE_FAILED = 0xC0000169;
		/// <summary>{Hard Disk Error} While accessing the hard disk, a disk operation failed even after retries.</summary>
		public const uint STATUS_DISK_OPERATION_FAILED = 0xC000016A;
		/// <summary>{Hard Disk Error} While accessing the hard disk, a disk controller reset was needed, but even that failed.</summary>
		public const uint STATUS_DISK_RESET_FAILED = 0xC000016B;
		/// <summary>An attempt was made to open a device that was sharing an interrupt request (IRQ) with other devices. At least one other device that uses that IRQ was already opened. Two concurrent opens of devices that share an IRQ and only work via interrupts is not supported for the particular bus type that the devices use.</summary>
		public const uint STATUS_SHARED_IRQ_BUSY = 0xC000016C;
		/// <summary>{FT Orphaning} A disk that is part of a fault-tolerant volume can no longer be accessed.</summary>
		public const uint STATUS_FT_ORPHANING = 0xC000016D;
		/// <summary>The basic input/output system (BIOS) failed to connect a system interrupt to the device or bus for which the device is connected.</summary>
		public const uint STATUS_BIOS_FAILED_TO_CONNECT_INTERRUPT = 0xC000016E;
		/// <summary>The tape could not be partitioned.</summary>
		public const uint STATUS_PARTITION_FAILURE = 0xC0000172;
		/// <summary>When accessing a new tape of a multi-volume partition, the current blocksize is incorrect.</summary>
		public const uint STATUS_INVALID_BLOCK_LENGTH = 0xC0000173;
		/// <summary>The tape partition information could not be found when loading a tape.</summary>
		public const uint STATUS_DEVICE_NOT_PARTITIONED = 0xC0000174;
		/// <summary>An attempt to lock the eject media mechanism failed.</summary>
		public const uint STATUS_UNABLE_TO_LOCK_MEDIA = 0xC0000175;
		/// <summary>An attempt to unload media failed.</summary>
		public const uint STATUS_UNABLE_TO_UNLOAD_MEDIA = 0xC0000176;
		/// <summary>The physical end of tape was detected.</summary>
		public const uint STATUS_EOM_OVERFLOW = 0xC0000177;
		/// <summary>{No Media} There is no media in the drive. Insert media into drive %hs.</summary>
		public const uint STATUS_NO_MEDIA = 0xC0000178;
		/// <summary>A member could not be added to or removed from the local group because the member does not exist.</summary>
		public const uint STATUS_NO_SUCH_MEMBER = 0xC000017A;
		/// <summary>A new member could not be added to a local group because the member has the wrong account type.</summary>
		public const uint STATUS_INVALID_MEMBER = 0xC000017B;
		/// <summary>An illegal operation was attempted on a registry key that has been marked for deletion.</summary>
		public const uint STATUS_KEY_DELETED = 0xC000017C;
		/// <summary>The system could not allocate the required space in a registry log.</summary>
		public const uint STATUS_NO_LOG_SPACE = 0xC000017D;
		/// <summary>Too many SIDs have been specified.</summary>
		public const uint STATUS_TOO_MANY_SIDS = 0xC000017E;
		/// <summary>An attempt was made to change a user password in the security account manager without providing the necessary LM cross-encrypted password.</summary>
		public const uint STATUS_LM_CROSS_ENCRYPTION_REQUIRED = 0xC000017F;
		/// <summary>An attempt was made to create a symbolic link in a registry key that already has subkeys or values.</summary>
		public const uint STATUS_KEY_HAS_CHILDREN = 0xC0000180;
		/// <summary>An attempt was made to create a stable subkey under a volatile parent key.</summary>
		public const uint STATUS_CHILD_MUST_BE_VOLATILE = 0xC0000181;
		/// <summary>The I/O device is configured incorrectly or the configuration parameters to the driver are incorrect.</summary>
		public const uint STATUS_DEVICE_CONFIGURATION_ERROR = 0xC0000182;
		/// <summary>An error was detected between two drivers or within an I/O driver.</summary>
		public const uint STATUS_DRIVER_INTERNAL_ERROR = 0xC0000183;
		/// <summary>The device is not in a valid state to perform this request.</summary>
		public const uint STATUS_INVALID_DEVICE_STATE = 0xC0000184;
		/// <summary>The I/O device reported an I/O error.</summary>
		public const uint STATUS_IO_DEVICE_ERROR = 0xC0000185;
		/// <summary>A protocol error was detected between the driver and the device.</summary>
		public const uint STATUS_DEVICE_PROTOCOL_ERROR = 0xC0000186;
		/// <summary>This operation is only allowed for the primary domain controller of the domain.</summary>
		public const uint STATUS_BACKUP_CONTROLLER = 0xC0000187;
		/// <summary>The log file space is insufficient to support this operation.</summary>
		public const uint STATUS_LOG_FILE_FULL = 0xC0000188;
		/// <summary>A write operation was attempted to a volume after it was dismounted.</summary>
		public const uint STATUS_TOO_LATE = 0xC0000189;
		/// <summary>The workstation does not have a trust secret for the primary domain in the local LSA database.</summary>
		public const uint STATUS_NO_TRUST_LSA_SECRET = 0xC000018A;
		/// <summary>The SAM database on the Windows Server does not have a computer account for this workstation trust relationship.</summary>
		public const uint STATUS_NO_TRUST_SAM_ACCOUNT = 0xC000018B;
		/// <summary>The logon request failed because the trust relationship between the primary domain and the trusted domain failed.</summary>
		public const uint STATUS_TRUSTED_DOMAIN_FAILURE = 0xC000018C;
		/// <summary>The logon request failed because the trust relationship between this workstation and the primary domain failed.</summary>
		public const uint STATUS_TRUSTED_RELATIONSHIP_FAILURE = 0xC000018D;
		/// <summary>The Eventlog log file is corrupt.</summary>
		public const uint STATUS_EVENTLOG_FILE_CORRUPT = 0xC000018E;
		/// <summary>No Eventlog log file could be opened. The Eventlog service did not start.</summary>
		public const uint STATUS_EVENTLOG_CANT_START = 0xC000018F;
		/// <summary>The network logon failed. This might be because the validation authority cannot be reached.</summary>
		public const uint STATUS_TRUST_FAILURE = 0xC0000190;
		/// <summary>An attempt was made to acquire a mutant such that its maximum count would have been exceeded.</summary>
		public const uint STATUS_MUTANT_LIMIT_EXCEEDED = 0xC0000191;
		/// <summary>An attempt was made to logon, but the NetLogon service was not started.</summary>
		public const uint STATUS_NETLOGON_NOT_STARTED = 0xC0000192;
		/// <summary>The user account has expired.</summary>
		public const uint STATUS_ACCOUNT_EXPIRED = 0xC0000193;
		/// <summary>{EXCEPTION} Possible deadlock condition.</summary>
		public const uint STATUS_POSSIBLE_DEADLOCK = 0xC0000194;
		/// <summary>Multiple connections to a server or shared resource by the same user, using more than one user name, are not allowed. Disconnect all previous connections to the server or shared resource and try again.</summary>
		public const uint STATUS_NETWORK_CREDENTIAL_CONFLICT = 0xC0000195;
		/// <summary>An attempt was made to establish a session to a network server, but there are already too many sessions established to that server.</summary>
		public const uint STATUS_REMOTE_SESSION_LIMIT = 0xC0000196;
		/// <summary>The log file has changed between reads.</summary>
		public const uint STATUS_EVENTLOG_FILE_CHANGED = 0xC0000197;
		/// <summary>The account used is an interdomain trust account. Use your global user account or local user account to access this server.</summary>
		public const uint STATUS_NOLOGON_INTERDOMAIN_TRUST_ACCOUNT = 0xC0000198;
		/// <summary>The account used is a computer account. Use your global user account or local user account to access this server.</summary>
		public const uint STATUS_NOLOGON_WORKSTATION_TRUST_ACCOUNT = 0xC0000199;
		/// <summary>The account used is a server trust account. Use your global user account or local user account to access this server.</summary>
		public const uint STATUS_NOLOGON_SERVER_TRUST_ACCOUNT = 0xC000019A;
		/// <summary>The name or SID of the specified domain is inconsistent with the trust information for that domain.</summary>
		public const uint STATUS_DOMAIN_TRUST_INCONSISTENT = 0xC000019B;
		/// <summary>A volume has been accessed for which a file system driver is required that has not yet been loaded.</summary>
		public const uint STATUS_FS_DRIVER_REQUIRED = 0xC000019C;
		/// <summary>Indicates that the specified image is already loaded as a DLL.</summary>
		public const uint STATUS_IMAGE_ALREADY_LOADED_AS_DLL = 0xC000019D;
		/// <summary>Short name settings cannot be changed on this volume due to the global registry setting.</summary>
		public const uint STATUS_INCOMPATIBLE_WITH_GLOBAL_SHORT_NAME_REGISTRY_SETTING = 0xC000019E;
		/// <summary>Short names are not enabled on this volume.</summary>
		public const uint STATUS_SHORT_NAMES_NOT_ENABLED_ON_VOLUME = 0xC000019F;
		/// <summary>The security stream for the given volume is in an inconsistent state. Please run CHKDSK on the volume.</summary>
		public const uint STATUS_SECURITY_STREAM_IS_INCONSISTENT = 0xC00001A0;
		/// <summary>A requested file lock operation cannot be processed due to an invalid byte range.</summary>
		public const uint STATUS_INVALID_LOCK_RANGE = 0xC00001A1;
		/// <summary>The specified access control entry (ACE) contains an invalid condition.</summary>
		public const uint STATUS_INVALID_ACE_CONDITION = 0xC00001A2;
		/// <summary>The subsystem needed to support the image type is not present.</summary>
		public const uint STATUS_IMAGE_SUBSYSTEM_NOT_PRESENT = 0xC00001A3;
		/// <summary>The specified file already has a notification GUID associated with it.</summary>
		public const uint STATUS_NOTIFICATION_GUID_ALREADY_DEFINED = 0xC00001A4;
		/// <summary>A remote open failed because the network open restrictions were not satisfied.</summary>
		public const uint STATUS_NETWORK_OPEN_RESTRICTION = 0xC0000201;
		/// <summary>There is no user session key for the specified logon session.</summary>
		public const uint STATUS_NO_USER_SESSION_KEY = 0xC0000202;
		/// <summary>The remote user session has been deleted.</summary>
		public const uint STATUS_USER_SESSION_DELETED = 0xC0000203;
		/// <summary>Indicates the specified resource language ID cannot be found in the image file.</summary>
		public const uint STATUS_RESOURCE_LANG_NOT_FOUND = 0xC0000204;
		/// <summary>Insufficient server resources exist to complete the request.</summary>
		public const uint STATUS_INSUFF_SERVER_RESOURCES = 0xC0000205;
		/// <summary>The size of the buffer is invalid for the specified operation.</summary>
		public const uint STATUS_INVALID_BUFFER_SIZE = 0xC0000206;
		/// <summary>The transport rejected the specified network address as invalid.</summary>
		public const uint STATUS_INVALID_ADDRESS_COMPONENT = 0xC0000207;
		/// <summary>The transport rejected the specified network address due to invalid use of a wildcard.</summary>
		public const uint STATUS_INVALID_ADDRESS_WILDCARD = 0xC0000208;
		/// <summary>The transport address could not be opened because all the available addresses are in use.</summary>
		public const uint STATUS_TOO_MANY_ADDRESSES = 0xC0000209;
		/// <summary>The transport address could not be opened because it already exists.</summary>
		public const uint STATUS_ADDRESS_ALREADY_EXISTS = 0xC000020A;
		/// <summary>The transport address is now closed.</summary>
		public const uint STATUS_ADDRESS_CLOSED = 0xC000020B;
		/// <summary>The transport connection is now disconnected.</summary>
		public const uint STATUS_CONNECTION_DISCONNECTED = 0xC000020C;
		/// <summary>The transport connection has been reset.</summary>
		public const uint STATUS_CONNECTION_RESET = 0xC000020D;
		/// <summary>The transport cannot dynamically acquire any more nodes.</summary>
		public const uint STATUS_TOO_MANY_NODES = 0xC000020E;
		/// <summary>The transport aborted a pending transaction.</summary>
		public const uint STATUS_TRANSACTION_ABORTED = 0xC000020F;
		/// <summary>The transport timed out a request that is waiting for a response.</summary>
		public const uint STATUS_TRANSACTION_TIMED_OUT = 0xC0000210;
		/// <summary>The transport did not receive a release for a pending response.</summary>
		public const uint STATUS_TRANSACTION_NO_RELEASE = 0xC0000211;
		/// <summary>The transport did not find a transaction that matches the specific token.</summary>
		public const uint STATUS_TRANSACTION_NO_MATCH = 0xC0000212;
		/// <summary>The transport had previously responded to a transaction request.</summary>
		public const uint STATUS_TRANSACTION_RESPONDED = 0xC0000213;
		/// <summary>The transport does not recognize the specified transaction request ID.</summary>
		public const uint STATUS_TRANSACTION_INVALID_ID = 0xC0000214;
		/// <summary>The transport does not recognize the specified transaction request type.</summary>
		public const uint STATUS_TRANSACTION_INVALID_TYPE = 0xC0000215;
		/// <summary>The transport can only process the specified request on the server side of a session.</summary>
		public const uint STATUS_NOT_SERVER_SESSION = 0xC0000216;
		/// <summary>The transport can only process the specified request on the client side of a session.</summary>
		public const uint STATUS_NOT_CLIENT_SESSION = 0xC0000217;
		/// <summary>{Registry File Failure} The registry cannot load the hive (file): %hs or its log or alternate. It is corrupt, absent, or not writable.</summary>
		public const uint STATUS_CANNOT_LOAD_REGISTRY_FILE = 0xC0000218;
		/// <summary>{Unexpected Failure in DebugActiveProcess} An unexpected failure occurred while processing a DebugActiveProcess API request. Choosing OK will terminate the process, and choosing Cancel will ignore the error.</summary>
		public const uint STATUS_DEBUG_ATTACH_FAILED = 0xC0000219;
		/// <summary>{Fatal System Error} The %hs system process terminated unexpectedly with a status of 0x%08x (0x%08x 0x%08x). The system has been shut down.</summary>
		public const uint STATUS_SYSTEM_PROCESS_TERMINATED = 0xC000021A;
		/// <summary>{Data Not Accepted} The TDI client could not handle the data received during an indication.</summary>
		public const uint STATUS_DATA_NOT_ACCEPTED = 0xC000021B;
		/// <summary>{Unable to Retrieve Browser Server List} The list of servers for this workgroup is not currently available.</summary>
		public const uint STATUS_NO_BROWSER_SERVERS_FOUND = 0xC000021C;
		/// <summary>NTVDM encountered a hard error.</summary>
		public const uint STATUS_VDM_HARD_ERROR = 0xC000021D;
		/// <summary>{Cancel Timeout} The driver %hs failed to complete a canceled I/O request in the allotted time.</summary>
		public const uint STATUS_DRIVER_CANCEL_TIMEOUT = 0xC000021E;
		/// <summary>{Reply Message Mismatch} An attempt was made to reply to an LPC message, but the thread specified by the client ID in the message was not waiting on that message.</summary>
		public const uint STATUS_REPLY_MESSAGE_MISMATCH = 0xC000021F;
		/// <summary>{Mapped View Alignment Incorrect} An attempt was made to map a view of a file, but either the specified base address or the offset into the file were not aligned on the proper allocation granularity.</summary>
		public const uint STATUS_MAPPED_ALIGNMENT = 0xC0000220;
		/// <summary>{Bad Image Checksum} The image %hs is possibly corrupt. The header checksum does not match the computed checksum.</summary>
		public const uint STATUS_IMAGE_CHECKSUM_MISMATCH = 0xC0000221;
		/// <summary>{Delayed Write Failed} Windows was unable to save all the data for the file %hs. The data has been lost. This error might be caused by a failure of your computer hardware or network connection. Try to save this file elsewhere.</summary>
		public const uint STATUS_LOST_WRITEBEHIND_DATA = 0xC0000222;
		/// <summary>The parameters passed to the server in the client/server shared memory window were invalid. Too much data might have been put in the shared memory window.</summary>
		public const uint STATUS_CLIENT_SERVER_PARAMETERS_INVALID = 0xC0000223;
		/// <summary>The user password must be changed before logging on the first time.</summary>
		public const uint STATUS_PASSWORD_MUST_CHANGE = 0xC0000224;
		/// <summary>The object was not found.</summary>
		public const uint STATUS_NOT_FOUND = 0xC0000225;
		/// <summary>The stream is not a tiny stream.</summary>
		public const uint STATUS_NOT_TINY_STREAM = 0xC0000226;
		/// <summary>A transaction recovery failed.</summary>
		public const uint STATUS_RECOVERY_FAILURE = 0xC0000227;
		/// <summary>The request must be handled by the stack overflow code.</summary>
		public const uint STATUS_STACK_OVERFLOW_READ = 0xC0000228;
		/// <summary>A consistency check failed.</summary>
		public const uint STATUS_FAIL_CHECK = 0xC0000229;
		/// <summary>The attempt to insert the ID in the index failed because the ID is already in the index.</summary>
		public const uint STATUS_DUPLICATE_OBJECTID = 0xC000022A;
		/// <summary>The attempt to set the object ID failed because the object already has an ID.</summary>
		public const uint STATUS_OBJECTID_EXISTS = 0xC000022B;
		/// <summary>Internal OFS status codes indicating how an allocation operation is handled. Either it is retried after the containing oNode is moved or the extent stream is converted to a large stream.</summary>
		public const uint STATUS_CONVERT_TO_LARGE = 0xC000022C;
		/// <summary>The request needs to be retried.</summary>
		public const uint STATUS_RETRY = 0xC000022D;
		/// <summary>The attempt to find the object found an object on the volume that matches by ID; however, it is out of the scope of the handle that is used for the operation.</summary>
		public const uint STATUS_FOUND_OUT_OF_SCOPE = 0xC000022E;
		/// <summary>The bucket array must be grown. Retry the transaction after doing so.</summary>
		public const uint STATUS_ALLOCATE_BUCKET = 0xC000022F;
		/// <summary>The specified property set does not exist on the object.</summary>
		public const uint STATUS_PROPSET_NOT_FOUND = 0xC0000230;
		/// <summary>The user/kernel marshaling buffer has overflowed.</summary>
		public const uint STATUS_MARSHALL_OVERFLOW = 0xC0000231;
		/// <summary>The supplied variant structure contains invalid data.</summary>
		public const uint STATUS_INVALID_VARIANT = 0xC0000232;
		/// <summary>A domain controller for this domain was not found.</summary>
		public const uint STATUS_DOMAIN_CONTROLLER_NOT_FOUND = 0xC0000233;
		/// <summary>The user account has been automatically locked because too many invalid logon attempts or password change attempts have been requested.</summary>
		public const uint STATUS_ACCOUNT_LOCKED_OUT = 0xC0000234;
		/// <summary>NtClose was called on a handle that was protected from close via NtSetInformationObject.</summary>
		public const uint STATUS_HANDLE_NOT_CLOSABLE = 0xC0000235;
		/// <summary>The transport-connection attempt was refused by the remote system.</summary>
		public const uint STATUS_CONNECTION_REFUSED = 0xC0000236;
		/// <summary>The transport connection was gracefully closed.</summary>
		public const uint STATUS_GRACEFUL_DISCONNECT = 0xC0000237;
		/// <summary>The transport endpoint already has an address associated with it.</summary>
		public const uint STATUS_ADDRESS_ALREADY_ASSOCIATED = 0xC0000238;
		/// <summary>An address has not yet been associated with the transport endpoint.</summary>
		public const uint STATUS_ADDRESS_NOT_ASSOCIATED = 0xC0000239;
		/// <summary>An operation was attempted on a nonexistent transport connection.</summary>
		public const uint STATUS_CONNECTION_INVALID = 0xC000023A;
		/// <summary>An invalid operation was attempted on an active transport connection.</summary>
		public const uint STATUS_CONNECTION_ACTIVE = 0xC000023B;
		/// <summary>The remote network is not reachable by the transport.</summary>
		public const uint STATUS_NETWORK_UNREACHABLE = 0xC000023C;
		/// <summary>The remote system is not reachable by the transport.</summary>
		public const uint STATUS_HOST_UNREACHABLE = 0xC000023D;
		/// <summary>The remote system does not support the transport protocol.</summary>
		public const uint STATUS_PROTOCOL_UNREACHABLE = 0xC000023E;
		/// <summary>No service is operating at the destination port of the transport on the remote system.</summary>
		public const uint STATUS_PORT_UNREACHABLE = 0xC000023F;
		/// <summary>The request was aborted.</summary>
		public const uint STATUS_REQUEST_ABORTED = 0xC0000240;
		/// <summary>The transport connection was aborted by the local system.</summary>
		public const uint STATUS_CONNECTION_ABORTED = 0xC0000241;
		/// <summary>The specified buffer contains ill-formed data.</summary>
		public const uint STATUS_BAD_COMPRESSION_BUFFER = 0xC0000242;
		/// <summary>The requested operation cannot be performed on a file with a user mapped section open.</summary>
		public const uint STATUS_USER_MAPPED_FILE = 0xC0000243;
		/// <summary>{Audit Failed} An attempt to generate a security audit failed.</summary>
		public const uint STATUS_AUDIT_FAILED = 0xC0000244;
		/// <summary>The timer resolution was not previously set by the current process.</summary>
		public const uint STATUS_TIMER_RESOLUTION_NOT_SET = 0xC0000245;
		/// <summary>A connection to the server could not be made because the limit on the number of concurrent connections for this account has been reached.</summary>
		public const uint STATUS_CONNECTION_COUNT_LIMIT = 0xC0000246;
		/// <summary>Attempting to log on during an unauthorized time of day for this account.</summary>
		public const uint STATUS_LOGIN_TIME_RESTRICTION = 0xC0000247;
		/// <summary>The account is not authorized to log on from this station.</summary>
		public const uint STATUS_LOGIN_WKSTA_RESTRICTION = 0xC0000248;
		/// <summary>{UP/MP Image Mismatch} The image %hs has been modified for use on a uniprocessor system, but you are running it on a multiprocessor machine. Reinstall the image file.</summary>
		public const uint STATUS_IMAGE_MP_UP_MISMATCH = 0xC0000249;
		/// <summary>There is insufficient account information to log you on.</summary>
		public const uint STATUS_INSUFFICIENT_LOGON_INFO = 0xC0000250;
		/// <summary>{Invalid DLL Entrypoint} The dynamic link library %hs is not written correctly. The stack pointer has been left in an inconsistent state. The entry point should be declared as WINAPI or STDCALL. Select YES to fail the DLL load. Select NO to continue execution. Selecting NO might cause the application to operate incorrectly.</summary>
		public const uint STATUS_BAD_DLL_ENTRYPOINT = 0xC0000251;
		/// <summary>{Invalid Service Callback Entrypoint} The %hs service is not written correctly. The stack pointer has been left in an inconsistent state. The callback entry point should be declared as WINAPI or STDCALL. Selecting OK will cause the service to continue operation. However, the service process might operate incorrectly.</summary>
		public const uint STATUS_BAD_SERVICE_ENTRYPOINT = 0xC0000252;
		/// <summary>The server received the messages but did not send a reply.</summary>
		public const uint STATUS_LPC_REPLY_LOST = 0xC0000253;
		/// <summary>There is an IP address conflict with another system on the network.</summary>
		public const uint STATUS_IP_ADDRESS_CONFLICT1 = 0xC0000254;
		/// <summary>There is an IP address conflict with another system on the network.</summary>
		public const uint STATUS_IP_ADDRESS_CONFLICT2 = 0xC0000255;
		/// <summary>{Low On Registry Space} The system has reached the maximum size that is allowed for the system part of the registry. Additional storage requests will be ignored.</summary>
		public const uint STATUS_REGISTRY_QUOTA_LIMIT = 0xC0000256;
		/// <summary>The contacted server does not support the indicated part of the DFS namespace.</summary>
		public const uint STATUS_PATH_NOT_COVERED = 0xC0000257;
		/// <summary>A callback return system service cannot be executed when no callback is active.</summary>
		public const uint STATUS_NO_CALLBACK_ACTIVE = 0xC0000258;
		/// <summary>The service being accessed is licensed for a particular number of connections. No more connections can be made to the service at this time because the service has already accepted the maximum number of connections.</summary>
		public const uint STATUS_LICENSE_QUOTA_EXCEEDED = 0xC0000259;
		/// <summary>The password provided is too short to meet the policy of your user account. Choose a longer password.</summary>
		public const uint STATUS_PWD_TOO_SHORT = 0xC000025A;
		/// <summary>The policy of your user account does not allow you to change passwords too frequently. This is done to prevent users from changing back to a familiar, but potentially discovered, password. If you feel your password has been compromised, contact your administrator immediately to have a new one assigned.</summary>
		public const uint STATUS_PWD_TOO_RECENT = 0xC000025B;
		/// <summary>You have attempted to change your password to one that you have used in the past. The policy of your user account does not allow this. Select a password that you have not previously used.</summary>
		public const uint STATUS_PWD_HISTORY_CONFLICT = 0xC000025C;
		/// <summary>You have attempted to load a legacy device driver while its device instance had been disabled.</summary>
		public const uint STATUS_PLUGPLAY_NO_DEVICE = 0xC000025E;
		/// <summary>The specified compression format is unsupported.</summary>
		public const uint STATUS_UNSUPPORTED_COMPRESSION = 0xC000025F;
		/// <summary>The specified hardware profile configuration is invalid.</summary>
		public const uint STATUS_INVALID_HW_PROFILE = 0xC0000260;
		/// <summary>The specified Plug and Play registry device path is invalid.</summary>
		public const uint STATUS_INVALID_PLUGPLAY_DEVICE_PATH = 0xC0000261;
		/// <summary>{Driver Entry Point Not Found} The %hs device driver could not locate the ordinal %ld in driver %hs.</summary>
		public const uint STATUS_DRIVER_ORDINAL_NOT_FOUND = 0xC0000262;
		/// <summary>{Driver Entry Point Not Found} The %hs device driver could not locate the entry point %hs in driver %hs.</summary>
		public const uint STATUS_DRIVER_ENTRYPOINT_NOT_FOUND = 0xC0000263;
		/// <summary>{Application Error} The application attempted to release a resource it did not own. Click OK to terminate the application.</summary>
		public const uint STATUS_RESOURCE_NOT_OWNED = 0xC0000264;
		/// <summary>An attempt was made to create more links on a file than the file system supports.</summary>
		public const uint STATUS_TOO_MANY_LINKS = 0xC0000265;
		/// <summary>The specified quota list is internally inconsistent with its descriptor.</summary>
		public const uint STATUS_QUOTA_LIST_INCONSISTENT = 0xC0000266;
		/// <summary>The specified file has been relocated to offline storage.</summary>
		public const uint STATUS_FILE_IS_OFFLINE = 0xC0000267;
		/// <summary>{Windows Evaluation Notification} The evaluation period for this installation of Windows has expired. This system will shutdown in 1 hour. To restore access to this installation of Windows, upgrade this installation by using a licensed distribution of this product.</summary>
		public const uint STATUS_EVALUATION_EXPIRATION = 0xC0000268;
		/// <summary>{Illegal System DLL Relocation} The system DLL %hs was relocated in memory. The application will not run properly. The relocation occurred because the DLL %hs occupied an address range that is reserved for Windows system DLLs. The vendor supplying the DLL should be contacted for a new DLL.</summary>
		public const uint STATUS_ILLEGAL_DLL_RELOCATION = 0xC0000269;
		/// <summary>{License Violation} The system has detected tampering with your registered product type. This is a violation of your software license. Tampering with the product type is not permitted.</summary>
		public const uint STATUS_LICENSE_VIOLATION = 0xC000026A;
		/// <summary>{DLL Initialization Failed} The application failed to initialize because the window station is shutting down.</summary>
		public const uint STATUS_DLL_INIT_FAILED_LOGOFF = 0xC000026B;
		/// <summary>{Unable to Load Device Driver} %hs device driver could not be loaded. Error Status was 0x%x.</summary>
		public const uint STATUS_DRIVER_UNABLE_TO_LOAD = 0xC000026C;
		/// <summary>DFS is unavailable on the contacted server.</summary>
		public const uint STATUS_DFS_UNAVAILABLE = 0xC000026D;
		/// <summary>An operation was attempted to a volume after it was dismounted.</summary>
		public const uint STATUS_VOLUME_DISMOUNTED = 0xC000026E;
		/// <summary>An internal error occurred in the Win32 x86 emulation subsystem.</summary>
		public const uint STATUS_WX86_INTERNAL_ERROR = 0xC000026F;
		/// <summary>Win32 x86 emulation subsystem floating-point stack check.</summary>
		public const uint STATUS_WX86_FLOAT_STACK_CHECK = 0xC0000270;
		/// <summary>The validation process needs to continue on to the next step.</summary>
		public const uint STATUS_VALIDATE_CONTINUE = 0xC0000271;
		/// <summary>There was no match for the specified key in the index.</summary>
		public const uint STATUS_NO_MATCH = 0xC0000272;
		/// <summary>There are no more matches for the current index enumeration.</summary>
		public const uint STATUS_NO_MORE_MATCHES = 0xC0000273;
		/// <summary>The NTFS file or directory is not a reparse point.</summary>
		public const uint STATUS_NOT_A_REPARSE_POINT = 0xC0000275;
		/// <summary>The Windows I/O reparse tag passed for the NTFS reparse point is invalid.</summary>
		public const uint STATUS_IO_REPARSE_TAG_INVALID = 0xC0000276;
		/// <summary>The Windows I/O reparse tag does not match the one that is in the NTFS reparse point.</summary>
		public const uint STATUS_IO_REPARSE_TAG_MISMATCH = 0xC0000277;
		/// <summary>The user data passed for the NTFS reparse point is invalid.</summary>
		public const uint STATUS_IO_REPARSE_DATA_INVALID = 0xC0000278;
		/// <summary>The layered file system driver for this I/O tag did not handle it when needed.</summary>
		public const uint STATUS_IO_REPARSE_TAG_NOT_HANDLED = 0xC0000279;
		/// <summary>The NTFS symbolic link could not be resolved even though the initial file name is valid.</summary>
		public const uint STATUS_REPARSE_POINT_NOT_RESOLVED = 0xC0000280;
		/// <summary>The NTFS directory is a reparse point.</summary>
		public const uint STATUS_DIRECTORY_IS_A_REPARSE_POINT = 0xC0000281;
		/// <summary>The range could not be added to the range list because of a conflict.</summary>
		public const uint STATUS_RANGE_LIST_CONFLICT = 0xC0000282;
		/// <summary>The specified medium changer source element contains no media.</summary>
		public const uint STATUS_SOURCE_ELEMENT_EMPTY = 0xC0000283;
		/// <summary>The specified medium changer destination element already contains media.</summary>
		public const uint STATUS_DESTINATION_ELEMENT_FULL = 0xC0000284;
		/// <summary>The specified medium changer element does not exist.</summary>
		public const uint STATUS_ILLEGAL_ELEMENT_ADDRESS = 0xC0000285;
		/// <summary>The specified element is contained in a magazine that is no longer present.</summary>
		public const uint STATUS_MAGAZINE_NOT_PRESENT = 0xC0000286;
		/// <summary>The device requires re-initialization due to hardware errors.</summary>
		public const uint STATUS_REINITIALIZATION_NEEDED = 0xC0000287;
		/// <summary>The file encryption attempt failed.</summary>
		public const uint STATUS_ENCRYPTION_FAILED = 0xC000028A;
		/// <summary>The file decryption attempt failed.</summary>
		public const uint STATUS_DECRYPTION_FAILED = 0xC000028B;
		/// <summary>The specified range could not be found in the range list.</summary>
		public const uint STATUS_RANGE_NOT_FOUND = 0xC000028C;
		/// <summary>There is no encryption recovery policy configured for this system.</summary>
		public const uint STATUS_NO_RECOVERY_POLICY = 0xC000028D;
		/// <summary>The required encryption driver is not loaded for this system.</summary>
		public const uint STATUS_NO_EFS = 0xC000028E;
		/// <summary>The file was encrypted with a different encryption driver than is currently loaded.</summary>
		public const uint STATUS_WRONG_EFS = 0xC000028F;
		/// <summary>There are no EFS keys defined for the user.</summary>
		public const uint STATUS_NO_USER_KEYS = 0xC0000290;
		/// <summary>The specified file is not encrypted.</summary>
		public const uint STATUS_FILE_NOT_ENCRYPTED = 0xC0000291;
		/// <summary>The specified file is not in the defined EFS export format.</summary>
		public const uint STATUS_NOT_EXPORT_FORMAT = 0xC0000292;
		/// <summary>The specified file is encrypted and the user does not have the ability to decrypt it.</summary>
		public const uint STATUS_FILE_ENCRYPTED = 0xC0000293;
		/// <summary>The GUID passed was not recognized as valid by a WMI data provider.</summary>
		public const uint STATUS_WMI_GUID_NOT_FOUND = 0xC0000295;
		/// <summary>The instance name passed was not recognized as valid by a WMI data provider.</summary>
		public const uint STATUS_WMI_INSTANCE_NOT_FOUND = 0xC0000296;
		/// <summary>The data item ID passed was not recognized as valid by a WMI data provider.</summary>
		public const uint STATUS_WMI_ITEMID_NOT_FOUND = 0xC0000297;
		/// <summary>The WMI request could not be completed and should be retried.</summary>
		public const uint STATUS_WMI_TRY_AGAIN = 0xC0000298;
		/// <summary>The policy object is shared and can only be modified at the root.</summary>
		public const uint STATUS_SHARED_POLICY = 0xC0000299;
		/// <summary>The policy object does not exist when it should.</summary>
		public const uint STATUS_POLICY_OBJECT_NOT_FOUND = 0xC000029A;
		/// <summary>The requested policy information only lives in the Ds.</summary>
		public const uint STATUS_POLICY_ONLY_IN_DS = 0xC000029B;
		/// <summary>The volume must be upgraded to enable this feature.</summary>
		public const uint STATUS_VOLUME_NOT_UPGRADED = 0xC000029C;
		/// <summary>The remote storage service is not operational at this time.</summary>
		public const uint STATUS_REMOTE_STORAGE_NOT_ACTIVE = 0xC000029D;
		/// <summary>The remote storage service encountered a media error.</summary>
		public const uint STATUS_REMOTE_STORAGE_MEDIA_ERROR = 0xC000029E;
		/// <summary>The tracking (workstation) service is not running.</summary>
		public const uint STATUS_NO_TRACKING_SERVICE = 0xC000029F;
		/// <summary>The server process is running under a SID that is different from the SID that is required by client.</summary>
		public const uint STATUS_SERVER_SID_MISMATCH = 0xC00002A0;
		/// <summary>The specified directory service attribute or value does not exist.</summary>
		public const uint STATUS_DS_NO_ATTRIBUTE_OR_VALUE = 0xC00002A1;
		/// <summary>The attribute syntax specified to the directory service is invalid.</summary>
		public const uint STATUS_DS_INVALID_ATTRIBUTE_SYNTAX = 0xC00002A2;
		/// <summary>The attribute type specified to the directory service is not defined.</summary>
		public const uint STATUS_DS_ATTRIBUTE_TYPE_UNDEFINED = 0xC00002A3;
		/// <summary>The specified directory service attribute or value already exists.</summary>
		public const uint STATUS_DS_ATTRIBUTE_OR_VALUE_EXISTS = 0xC00002A4;
		/// <summary>The directory service is busy.</summary>
		public const uint STATUS_DS_BUSY = 0xC00002A5;
		/// <summary>The directory service is unavailable.</summary>
		public const uint STATUS_DS_UNAVAILABLE = 0xC00002A6;
		/// <summary>The directory service was unable to allocate a relative identifier.</summary>
		public const uint STATUS_DS_NO_RIDS_ALLOCATED = 0xC00002A7;
		/// <summary>The directory service has exhausted the pool of relative identifiers.</summary>
		public const uint STATUS_DS_NO_MORE_RIDS = 0xC00002A8;
		/// <summary>The requested operation could not be performed because the directory service is not the master for that type of operation.</summary>
		public const uint STATUS_DS_INCORRECT_ROLE_OWNER = 0xC00002A9;
		/// <summary>The directory service was unable to initialize the subsystem that allocates relative identifiers.</summary>
		public const uint STATUS_DS_RIDMGR_INIT_ERROR = 0xC00002AA;
		/// <summary>The requested operation did not satisfy one or more constraints that are associated with the class of the object.</summary>
		public const uint STATUS_DS_OBJ_CLASS_VIOLATION = 0xC00002AB;
		/// <summary>The directory service can perform the requested operation only on a leaf object.</summary>
		public const uint STATUS_DS_CANT_ON_NON_LEAF = 0xC00002AC;
		/// <summary>The directory service cannot perform the requested operation on the Relatively Defined Name (RDN) attribute of an object.</summary>
		public const uint STATUS_DS_CANT_ON_RDN = 0xC00002AD;
		/// <summary>The directory service detected an attempt to modify the object class of an object.</summary>
		public const uint STATUS_DS_CANT_MOD_OBJ_CLASS = 0xC00002AE;
		/// <summary>An error occurred while performing a cross domain move operation.</summary>
		public const uint STATUS_DS_CROSS_DOM_MOVE_FAILED = 0xC00002AF;
		/// <summary>Unable to contact the global catalog server.</summary>
		public const uint STATUS_DS_GC_NOT_AVAILABLE = 0xC00002B0;
		/// <summary>The requested operation requires a directory service, and none was available.</summary>
		public const uint STATUS_DIRECTORY_SERVICE_REQUIRED = 0xC00002B1;
		/// <summary>The reparse attribute cannot be set because it is incompatible with an existing attribute.</summary>
		public const uint STATUS_REPARSE_ATTRIBUTE_CONFLICT = 0xC00002B2;
		/// <summary>A group marked "use for deny only" cannot be enabled.</summary>
		public const uint STATUS_CANT_ENABLE_DENY_ONLY = 0xC00002B3;
		/// <summary>{EXCEPTION} Multiple floating-point faults.</summary>
		public const uint STATUS_FLOAT_MULTIPLE_FAULTS = 0xC00002B4;
		/// <summary>{EXCEPTION} Multiple floating-point traps.</summary>
		public const uint STATUS_FLOAT_MULTIPLE_TRAPS = 0xC00002B5;
		/// <summary>The device has been removed.</summary>
		public const uint STATUS_DEVICE_REMOVED = 0xC00002B6;
		/// <summary>The volume change journal is being deleted.</summary>
		public const uint STATUS_JOURNAL_DELETE_IN_PROGRESS = 0xC00002B7;
		/// <summary>The volume change journal is not active.</summary>
		public const uint STATUS_JOURNAL_NOT_ACTIVE = 0xC00002B8;
		/// <summary>The requested interface is not supported.</summary>
		public const uint STATUS_NOINTERFACE = 0xC00002B9;
		/// <summary>A directory service resource limit has been exceeded.</summary>
		public const uint STATUS_DS_ADMIN_LIMIT_EXCEEDED = 0xC00002C1;
		/// <summary>{System Standby Failed} The driver %hs does not support standby mode. Updating this driver allows the system to go to standby mode.</summary>
		public const uint STATUS_DRIVER_FAILED_SLEEP = 0xC00002C2;
		/// <summary>Mutual Authentication failed. The server password is out of date at the domain controller.</summary>
		public const uint STATUS_MUTUAL_AUTHENTICATION_FAILED = 0xC00002C3;
		/// <summary>The system file %1 has become corrupt and has been replaced.</summary>
		public const uint STATUS_CORRUPT_SYSTEM_FILE = 0xC00002C4;
		/// <summary>{EXCEPTION} Alignment Error A data type misalignment error was detected in a load or store instruction.</summary>
		public const uint STATUS_DATATYPE_MISALIGNMENT_ERROR = 0xC00002C5;
		/// <summary>The WMI data item or data block is read-only.</summary>
		public const uint STATUS_WMI_READ_ONLY = 0xC00002C6;
		/// <summary>The WMI data item or data block could not be changed.</summary>
		public const uint STATUS_WMI_SET_FAILURE = 0xC00002C7;
		/// <summary>{Virtual Memory Minimum Too Low} Your system is low on virtual memory. Windows is increasing the size of your virtual memory paging file. During this process, memory requests for some applications might be denied. For more information, see Help.</summary>
		public const uint STATUS_COMMITMENT_MINIMUM = 0xC00002C8;
		/// <summary>{EXCEPTION} Register NaT consumption faults. A NaT value is consumed on a non-speculative instruction.</summary>
		public const uint STATUS_REG_NAT_CONSUMPTION = 0xC00002C9;
		/// <summary>The transport element of the medium changer contains media, which is causing the operation to fail.</summary>
		public const uint STATUS_TRANSPORT_FULL = 0xC00002CA;
		/// <summary>Security Accounts Manager initialization failed because of the following error: %hs Error Status: 0x%x. Click OK to shut down this system and restart in Directory Services Restore Mode. Check the event log for more detailed information.</summary>
		public const uint STATUS_DS_SAM_INIT_FAILURE = 0xC00002CB;
		/// <summary>This operation is supported only when you are connected to the server.</summary>
		public const uint STATUS_ONLY_IF_CONNECTED = 0xC00002CC;
		/// <summary>Only an administrator can modify the membership list of an administrative group.</summary>
		public const uint STATUS_DS_SENSITIVE_GROUP_VIOLATION = 0xC00002CD;
		/// <summary>A device was removed so enumeration must be restarted.</summary>
		public const uint STATUS_PNP_RESTART_ENUMERATION = 0xC00002CE;
		/// <summary>The journal entry has been deleted from the journal.</summary>
		public const uint STATUS_JOURNAL_ENTRY_DELETED = 0xC00002CF;
		/// <summary>Cannot change the primary group ID of a domain controller account.</summary>
		public const uint STATUS_DS_CANT_MOD_PRIMARYGROUPID = 0xC00002D0;
		/// <summary>{Fatal System Error} The system image %s is not properly signed. The file has been replaced with the signed file. The system has been shut down.</summary>
		public const uint STATUS_SYSTEM_IMAGE_BAD_SIGNATURE = 0xC00002D1;
		/// <summary>The device will not start without a reboot.</summary>
		public const uint STATUS_PNP_REBOOT_REQUIRED = 0xC00002D2;
		/// <summary>The power state of the current device cannot support this request.</summary>
		public const uint STATUS_POWER_STATE_INVALID = 0xC00002D3;
		/// <summary>The specified group type is invalid.</summary>
		public const uint STATUS_DS_INVALID_GROUP_TYPE = 0xC00002D4;
		/// <summary>In a mixed domain, no nesting of a global group if the group is security enabled.</summary>
		public const uint STATUS_DS_NO_NEST_GLOBALGROUP_IN_MIXEDDOMAIN = 0xC00002D5;
		/// <summary>In a mixed domain, cannot nest local groups with other local groups, if the group is security enabled.</summary>
		public const uint STATUS_DS_NO_NEST_LOCALGROUP_IN_MIXEDDOMAIN = 0xC00002D6;
		/// <summary>A global group cannot have a local group as a member.</summary>
		public const uint STATUS_DS_GLOBAL_CANT_HAVE_LOCAL_MEMBER = 0xC00002D7;
		/// <summary>A global group cannot have a universal group as a member.</summary>
		public const uint STATUS_DS_GLOBAL_CANT_HAVE_UNIVERSAL_MEMBER = 0xC00002D8;
		/// <summary>A universal group cannot have a local group as a member.</summary>
		public const uint STATUS_DS_UNIVERSAL_CANT_HAVE_LOCAL_MEMBER = 0xC00002D9;
		/// <summary>A global group cannot have a cross-domain member.</summary>
		public const uint STATUS_DS_GLOBAL_CANT_HAVE_CROSSDOMAIN_MEMBER = 0xC00002DA;
		/// <summary>A local group cannot have another cross-domain local group as a member.</summary>
		public const uint STATUS_DS_LOCAL_CANT_HAVE_CROSSDOMAIN_LOCAL_MEMBER = 0xC00002DB;
		/// <summary>Cannot change to a security-disabled group because primary members are in this group.</summary>
		public const uint STATUS_DS_HAVE_PRIMARY_MEMBERS = 0xC00002DC;
		/// <summary>The WMI operation is not supported by the data block or method.</summary>
		public const uint STATUS_WMI_NOT_SUPPORTED = 0xC00002DD;
		/// <summary>There is not enough power to complete the requested operation.</summary>
		public const uint STATUS_INSUFFICIENT_POWER = 0xC00002DE;
		/// <summary>The Security Accounts Manager needs to get the boot password.</summary>
		public const uint STATUS_SAM_NEED_BOOTKEY_PASSWORD = 0xC00002DF;
		/// <summary>The Security Accounts Manager needs to get the boot key from the floppy disk.</summary>
		public const uint STATUS_SAM_NEED_BOOTKEY_FLOPPY = 0xC00002E0;
		/// <summary>The directory service cannot start.</summary>
		public const uint STATUS_DS_CANT_START = 0xC00002E1;
		/// <summary>The directory service could not start because of the following error: %hs Error Status: 0x%x. Click OK to shut down this system and restart in Directory Services Restore Mode. Check the event log for more detailed information.</summary>
		public const uint STATUS_DS_INIT_FAILURE = 0xC00002E2;
		/// <summary>The Security Accounts Manager initialization failed because of the following error: %hs Error Status: 0x%x. Click OK to shut down this system and restart in Safe Mode. Check the event log for more detailed information.</summary>
		public const uint STATUS_SAM_INIT_FAILURE = 0xC00002E3;
		/// <summary>The requested operation can be performed only on a global catalog server.</summary>
		public const uint STATUS_DS_GC_REQUIRED = 0xC00002E4;
		/// <summary>A local group can only be a member of other local groups in the same domain.</summary>
		public const uint STATUS_DS_LOCAL_MEMBER_OF_LOCAL_ONLY = 0xC00002E5;
		/// <summary>Foreign security principals cannot be members of universal groups.</summary>
		public const uint STATUS_DS_NO_FPO_IN_UNIVERSAL_GROUPS = 0xC00002E6;
		/// <summary>Your computer could not be joined to the domain. You have exceeded the maximum number of computer accounts you are allowed to create in this domain. Contact your system administrator to have this limit reset or increased.</summary>
		public const uint STATUS_DS_MACHINE_ACCOUNT_QUOTA_EXCEEDED = 0xC00002E7;
		/// <summary>This operation cannot be performed on the current domain.</summary>
		public const uint STATUS_CURRENT_DOMAIN_NOT_ALLOWED = 0xC00002E9;
		/// <summary>The directory or file cannot be created.</summary>
		public const uint STATUS_CANNOT_MAKE = 0xC00002EA;
		/// <summary>The system is in the process of shutting down.</summary>
		public const uint STATUS_SYSTEM_SHUTDOWN = 0xC00002EB;
		/// <summary>Directory Services could not start because of the following error: %hs Error Status: 0x%x. Click OK to shut down the system. You can use the recovery console to diagnose the system further.</summary>
		public const uint STATUS_DS_INIT_FAILURE_CONSOLE = 0xC00002EC;
		/// <summary>Security Accounts Manager initialization failed because of the following error: %hs Error Status: 0x%x. Click OK to shut down the system. You can use the recovery console to diagnose the system further.</summary>
		public const uint STATUS_DS_SAM_INIT_FAILURE_CONSOLE = 0xC00002ED;
		/// <summary>A security context was deleted before the context was completed. This is considered a logon failure.</summary>
		public const uint STATUS_UNFINISHED_CONTEXT_DELETED = 0xC00002EE;
		/// <summary>The client is trying to negotiate a context and the server requires user-to-user but did not send a TGT reply.</summary>
		public const uint STATUS_NO_TGT_REPLY = 0xC00002EF;
		/// <summary>An object ID was not found in the file.</summary>
		public const uint STATUS_OBJECTID_NOT_FOUND = 0xC00002F0;
		/// <summary>Unable to accomplish the requested task because the local machine does not have any IP addresses.</summary>
		public const uint STATUS_NO_IP_ADDRESSES = 0xC00002F1;
		/// <summary>The supplied credential handle does not match the credential that is associated with the security context.</summary>
		public const uint STATUS_WRONG_CREDENTIAL_HANDLE = 0xC00002F2;
		/// <summary>The crypto system or checksum function is invalid because a required function is unavailable.</summary>
		public const uint STATUS_CRYPTO_SYSTEM_INVALID = 0xC00002F3;
		/// <summary>The number of maximum ticket referrals has been exceeded.</summary>
		public const uint STATUS_MAX_REFERRALS_EXCEEDED = 0xC00002F4;
		/// <summary>The local machine must be a Kerberos KDC (domain controller) and it is not.</summary>
		public const uint STATUS_MUST_BE_KDC = 0xC00002F5;
		/// <summary>The other end of the security negotiation requires strong crypto but it is not supported on the local machine.</summary>
		public const uint STATUS_STRONG_CRYPTO_NOT_SUPPORTED = 0xC00002F6;
		/// <summary>The KDC reply contained more than one principal name.</summary>
		public const uint STATUS_TOO_MANY_PRINCIPALS = 0xC00002F7;
		/// <summary>Expected to find PA data for a hint of what etype to use, but it was not found.</summary>
		public const uint STATUS_NO_PA_DATA = 0xC00002F8;
		/// <summary>The client certificate does not contain a valid UPN, or does not match the client name in the logon request. Contact your administrator.</summary>
		public const uint STATUS_PKINIT_NAME_MISMATCH = 0xC00002F9;
		/// <summary>Smart card logon is required and was not used.</summary>
		public const uint STATUS_SMARTCARD_LOGON_REQUIRED = 0xC00002FA;
		/// <summary>An invalid request was sent to the KDC.</summary>
		public const uint STATUS_KDC_INVALID_REQUEST = 0xC00002FB;
		/// <summary>The KDC was unable to generate a referral for the service requested.</summary>
		public const uint STATUS_KDC_UNABLE_TO_REFER = 0xC00002FC;
		/// <summary>The encryption type requested is not supported by the KDC.</summary>
		public const uint STATUS_KDC_UNKNOWN_ETYPE = 0xC00002FD;
		/// <summary>A system shutdown is in progress.</summary>
		public const uint STATUS_SHUTDOWN_IN_PROGRESS = 0xC00002FE;
		/// <summary>The server machine is shutting down.</summary>
		public const uint STATUS_SERVER_SHUTDOWN_IN_PROGRESS = 0xC00002FF;
		/// <summary>This operation is not supported on a computer running Windows Server 2003 operating system for Small Business Server.</summary>
		public const uint STATUS_NOT_SUPPORTED_ON_SBS = 0xC0000300;
		/// <summary>The WMI GUID is no longer available.</summary>
		public const uint STATUS_WMI_GUID_DISCONNECTED = 0xC0000301;
		/// <summary>Collection or events for the WMI GUID is already disabled.</summary>
		public const uint STATUS_WMI_ALREADY_DISABLED = 0xC0000302;
		/// <summary>Collection or events for the WMI GUID is already enabled.</summary>
		public const uint STATUS_WMI_ALREADY_ENABLED = 0xC0000303;
		/// <summary>The master file table on the volume is too fragmented to complete this operation.</summary>
		public const uint STATUS_MFT_TOO_FRAGMENTED = 0xC0000304;
		/// <summary>Copy protection failure.</summary>
		public const uint STATUS_COPY_PROTECTION_FAILURE = 0xC0000305;
		/// <summary>Copy protection error—DVD CSS Authentication failed.</summary>
		public const uint STATUS_CSS_AUTHENTICATION_FAILURE = 0xC0000306;
		/// <summary>Copy protection error—The specified sector does not contain a valid key.</summary>
		public const uint STATUS_CSS_KEY_NOT_PRESENT = 0xC0000307;
		/// <summary>Copy protection error—DVD session key not established.</summary>
		public const uint STATUS_CSS_KEY_NOT_ESTABLISHED = 0xC0000308;
		/// <summary>Copy protection error—The read failed because the sector is encrypted.</summary>
		public const uint STATUS_CSS_SCRAMBLED_SECTOR = 0xC0000309;
		/// <summary>Copy protection error—The region of the specified DVD does not correspond to the region setting of the drive.</summary>
		public const uint STATUS_CSS_REGION_MISMATCH = 0xC000030A;
		/// <summary>Copy protection error—The region setting of the drive might be permanent.</summary>
		public const uint STATUS_CSS_RESETS_EXHAUSTED = 0xC000030B;
		/// <summary>The Kerberos protocol encountered an error while validating the KDC certificate during smart card logon. There is more information in the system event log.</summary>
		public const uint STATUS_PKINIT_FAILURE = 0xC0000320;
		/// <summary>The Kerberos protocol encountered an error while attempting to use the smart card subsystem.</summary>
		public const uint STATUS_SMARTCARD_SUBSYSTEM_FAILURE = 0xC0000321;
		/// <summary>The target server does not have acceptable Kerberos credentials.</summary>
		public const uint STATUS_NO_KERB_KEY = 0xC0000322;
		/// <summary>The transport determined that the remote system is down.</summary>
		public const uint STATUS_HOST_DOWN = 0xC0000350;
		/// <summary>An unsupported pre-authentication mechanism was presented to the Kerberos package.</summary>
		public const uint STATUS_UNSUPPORTED_PREAUTH = 0xC0000351;
		/// <summary>The encryption algorithm that is used on the source file needs a bigger key buffer than the one that is used on the destination file.</summary>
		public const uint STATUS_EFS_ALG_BLOB_TOO_BIG = 0xC0000352;
		/// <summary>An attempt to remove a processes DebugPort was made, but a port was not already associated with the process.</summary>
		public const uint STATUS_PORT_NOT_SET = 0xC0000353;
		/// <summary>An attempt to do an operation on a debug port failed because the port is in the process of being deleted.</summary>
		public const uint STATUS_DEBUGGER_INACTIVE = 0xC0000354;
		/// <summary>This version of Windows is not compatible with the behavior version of the directory forest, domain, or domain controller.</summary>
		public const uint STATUS_DS_VERSION_CHECK_FAILURE = 0xC0000355;
		/// <summary>The specified event is currently not being audited.</summary>
		public const uint STATUS_AUDITING_DISABLED = 0xC0000356;
		/// <summary>The machine account was created prior to Windows NT 4.0 operating system. The account needs to be recreated.</summary>
		public const uint STATUS_PRENT4_MACHINE_ACCOUNT = 0xC0000357;
		/// <summary>An account group cannot have a universal group as a member.</summary>
		public const uint STATUS_DS_AG_CANT_HAVE_UNIVERSAL_MEMBER = 0xC0000358;
		/// <summary>The specified image file did not have the correct format; it appears to be a 32-bit Windows image.</summary>
		public const uint STATUS_INVALID_IMAGE_WIN_32 = 0xC0000359;
		/// <summary>The specified image file did not have the correct format; it appears to be a 64-bit Windows image.</summary>
		public const uint STATUS_INVALID_IMAGE_WIN_64 = 0xC000035A;
		/// <summary>The client's supplied SSPI channel bindings were incorrect.</summary>
		public const uint STATUS_BAD_BINDINGS = 0xC000035B;
		/// <summary>The client session has expired; so the client must re-authenticate to continue accessing the remote resources.</summary>
		public const uint STATUS_NETWORK_SESSION_EXPIRED = 0xC000035C;
		/// <summary>The AppHelp dialog box canceled; thus preventing the application from starting.</summary>
		public const uint STATUS_APPHELP_BLOCK = 0xC000035D;
		/// <summary>The SID filtering operation removed all SIDs.</summary>
		public const uint STATUS_ALL_SIDS_FILTERED = 0xC000035E;
		/// <summary>The driver was not loaded because the system is starting in safe mode.</summary>
		public const uint STATUS_NOT_SAFE_MODE_DRIVER = 0xC000035F;
		/// <summary>Access to %1 has been restricted by your Administrator by the default software restriction policy level.</summary>
		public const uint STATUS_ACCESS_DISABLED_BY_POLICY_DEFAULT = 0xC0000361;
		/// <summary>Access to %1 has been restricted by your Administrator by location with policy rule %2 placed on path %3.</summary>
		public const uint STATUS_ACCESS_DISABLED_BY_POLICY_PATH = 0xC0000362;
		/// <summary>Access to %1 has been restricted by your Administrator by software publisher policy.</summary>
		public const uint STATUS_ACCESS_DISABLED_BY_POLICY_PUBLISHER = 0xC0000363;
		/// <summary>Access to %1 has been restricted by your Administrator by policy rule %2.</summary>
		public const uint STATUS_ACCESS_DISABLED_BY_POLICY_OTHER = 0xC0000364;
		/// <summary>The driver was not loaded because it failed its initialization call.</summary>
		public const uint STATUS_FAILED_DRIVER_ENTRY = 0xC0000365;
		/// <summary>The device encountered an error while applying power or reading the device configuration. This might be caused by a failure of your hardware or by a poor connection.</summary>
		public const uint STATUS_DEVICE_ENUMERATION_ERROR = 0xC0000366;
		/// <summary>The create operation failed because the name contained at least one mount point that resolves to a volume to which the specified device object is not attached.</summary>
		public const uint STATUS_MOUNT_POINT_NOT_RESOLVED = 0xC0000368;
		/// <summary>The device object parameter is either not a valid device object or is not attached to the volume that is specified by the file name.</summary>
		public const uint STATUS_INVALID_DEVICE_OBJECT_PARAMETER = 0xC0000369;
		/// <summary>A machine check error has occurred. Check the system event log for additional information.</summary>
		public const uint STATUS_MCA_OCCURED = 0xC000036A;
		/// <summary>Driver %2 has been blocked from loading.</summary>
		public const uint STATUS_DRIVER_BLOCKED_CRITICAL = 0xC000036B;
		/// <summary>Driver %2 has been blocked from loading.</summary>
		public const uint STATUS_DRIVER_BLOCKED = 0xC000036C;
		/// <summary>There was error [%2] processing the driver database.</summary>
		public const uint STATUS_DRIVER_DATABASE_ERROR = 0xC000036D;
		/// <summary>System hive size has exceeded its limit.</summary>
		public const uint STATUS_SYSTEM_HIVE_TOO_LARGE = 0xC000036E;
		/// <summary>A dynamic link library (DLL) referenced a module that was neither a DLL nor the process's executable image.</summary>
		public const uint STATUS_INVALID_IMPORT_OF_NON_DLL = 0xC000036F;
		/// <summary>The local account store does not contain secret material for the specified account.</summary>
		public const uint STATUS_NO_SECRETS = 0xC0000371;
		/// <summary>Access to %1 has been restricted by your Administrator by policy rule %2.</summary>
		public const uint STATUS_ACCESS_DISABLED_NO_SAFER_UI_BY_POLICY = 0xC0000372;
		/// <summary>The system was not able to allocate enough memory to perform a stack switch.</summary>
		public const uint STATUS_FAILED_STACK_SWITCH = 0xC0000373;
		/// <summary>A heap has been corrupted.</summary>
		public const uint STATUS_HEAP_CORRUPTION = 0xC0000374;
		/// <summary>An incorrect PIN was presented to the smart card.</summary>
		public const uint STATUS_SMARTCARD_WRONG_PIN = 0xC0000380;
		/// <summary>The smart card is blocked.</summary>
		public const uint STATUS_SMARTCARD_CARD_BLOCKED = 0xC0000381;
		/// <summary>No PIN was presented to the smart card.</summary>
		public const uint STATUS_SMARTCARD_CARD_NOT_AUTHENTICATED = 0xC0000382;
		/// <summary>No smart card is available.</summary>
		public const uint STATUS_SMARTCARD_NO_CARD = 0xC0000383;
		/// <summary>The requested key container does not exist on the smart card.</summary>
		public const uint STATUS_SMARTCARD_NO_KEY_CONTAINER = 0xC0000384;
		/// <summary>The requested certificate does not exist on the smart card.</summary>
		public const uint STATUS_SMARTCARD_NO_CERTIFICATE = 0xC0000385;
		/// <summary>The requested keyset does not exist.</summary>
		public const uint STATUS_SMARTCARD_NO_KEYSET = 0xC0000386;
		/// <summary>A communication error with the smart card has been detected.</summary>
		public const uint STATUS_SMARTCARD_IO_ERROR = 0xC0000387;
		/// <summary>The system detected a possible attempt to compromise security. Ensure that you can contact the server that authenticated you.</summary>
		public const uint STATUS_DOWNGRADE_DETECTED = 0xC0000388;
		/// <summary>The smart card certificate used for authentication has been revoked. Contact your system administrator. There might be additional information in the event log.</summary>
		public const uint STATUS_SMARTCARD_CERT_REVOKED = 0xC0000389;
		/// <summary>An untrusted certificate authority was detected while processing the smart card certificate that is used for authentication. Contact your system administrator.</summary>
		public const uint STATUS_ISSUING_CA_UNTRUSTED = 0xC000038A;
		/// <summary>The revocation status of the smart card certificate that is used for authentication could not be determined. Contact your system administrator.</summary>
		public const uint STATUS_REVOCATION_OFFLINE_C = 0xC000038B;
		/// <summary>The smart card certificate used for authentication was not trusted. Contact your system administrator.</summary>
		public const uint STATUS_PKINIT_CLIENT_FAILURE = 0xC000038C;
		/// <summary>The smart card certificate used for authentication has expired. Contact your system administrator.</summary>
		public const uint STATUS_SMARTCARD_CERT_EXPIRED = 0xC000038D;
		/// <summary>The driver could not be loaded because a previous version of the driver is still in memory.</summary>
		public const uint STATUS_DRIVER_FAILED_PRIOR_UNLOAD = 0xC000038E;
		/// <summary>The smart card provider could not perform the action because the context was acquired as silent.</summary>
		public const uint STATUS_SMARTCARD_SILENT_CONTEXT = 0xC000038F;
		/// <summary>The delegated trust creation quota of the current user has been exceeded.</summary>
		public const uint STATUS_PER_USER_TRUST_QUOTA_EXCEEDED = 0xC0000401;
		/// <summary>The total delegated trust creation quota has been exceeded.</summary>
		public const uint STATUS_ALL_USER_TRUST_QUOTA_EXCEEDED = 0xC0000402;
		/// <summary>The delegated trust deletion quota of the current user has been exceeded.</summary>
		public const uint STATUS_USER_DELETE_TRUST_QUOTA_EXCEEDED = 0xC0000403;
		/// <summary>The requested name already exists as a unique identifier.</summary>
		public const uint STATUS_DS_NAME_NOT_UNIQUE = 0xC0000404;
		/// <summary>The requested object has a non-unique identifier and cannot be retrieved.</summary>
		public const uint STATUS_DS_DUPLICATE_ID_FOUND = 0xC0000405;
		/// <summary>The group cannot be converted due to attribute restrictions on the requested group type.</summary>
		public const uint STATUS_DS_GROUP_CONVERSION_ERROR = 0xC0000406;
		/// <summary>{Volume Shadow Copy Service} Wait while the Volume Shadow Copy Service prepares volume %hs for hibernation.</summary>
		public const uint STATUS_VOLSNAP_PREPARE_HIBERNATE = 0xC0000407;
		/// <summary>Kerberos sub-protocol User2User is required.</summary>
		public const uint STATUS_USER2USER_REQUIRED = 0xC0000408;
		/// <summary>The system detected an overrun of a stack-based buffer in this application. This overrun could potentially allow a malicious user to gain control of this application.</summary>
		public const uint STATUS_STACK_BUFFER_OVERRUN = 0xC0000409;
		/// <summary>The Kerberos subsystem encountered an error. A service for user protocol request was made against a domain controller which does not support service for user.</summary>
		public const uint STATUS_NO_S4U_PROT_SUPPORT = 0xC000040A;
		/// <summary>An attempt was made by this server to make a Kerberos constrained delegation request for a target that is outside the server realm. This action is not supported and the resulting error indicates a misconfiguration on the allowed-to-delegate-to list for this server. Contact your administrator.</summary>
		public const uint STATUS_CROSSREALM_DELEGATION_FAILURE = 0xC000040B;
		/// <summary>The revocation status of the domain controller certificate used for smart card authentication could not be determined. There is additional information in the system event log. Contact your system administrator.</summary>
		public const uint STATUS_REVOCATION_OFFLINE_KDC = 0xC000040C;
		/// <summary>An untrusted certificate authority was detected while processing the domain controller certificate used for authentication. There is additional information in the system event log. Contact your system administrator.</summary>
		public const uint STATUS_ISSUING_CA_UNTRUSTED_KDC = 0xC000040D;
		/// <summary>The domain controller certificate used for smart card logon has expired. Contact your system administrator with the contents of your system event log.</summary>
		public const uint STATUS_KDC_CERT_EXPIRED = 0xC000040E;
		/// <summary>The domain controller certificate used for smart card logon has been revoked. Contact your system administrator with the contents of your system event log.</summary>
		public const uint STATUS_KDC_CERT_REVOKED = 0xC000040F;
		/// <summary>Data present in one of the parameters is more than the function can operate on.</summary>
		public const uint STATUS_PARAMETER_QUOTA_EXCEEDED = 0xC0000410;
		/// <summary>The system has failed to hibernate (The error code is %hs). Hibernation will be disabled until the system is restarted.</summary>
		public const uint STATUS_HIBERNATION_FAILURE = 0xC0000411;
		/// <summary>An attempt to delay-load a .dll or get a function address in a delay-loaded .dll failed.</summary>
		public const uint STATUS_DELAY_LOAD_FAILED = 0xC0000412;
		/// <summary>Logon Failure: The machine you are logging onto is protected by an authentication firewall. The specified account is not allowed to authenticate to the machine.</summary>
		public const uint STATUS_AUTHENTICATION_FIREWALL_FAILED = 0xC0000413;
		/// <summary>%hs is a 16-bit application. You do not have permissions to execute 16-bit applications. Check your permissions with your system administrator.</summary>
		public const uint STATUS_VDM_DISALLOWED = 0xC0000414;
		/// <summary>{Display Driver Stopped Responding} The %hs display driver has stopped working normally. Save your work and reboot the system to restore full display functionality. The next time you reboot the machine a dialog will be displayed giving you a chance to report this failure to Microsoft.</summary>
		public const uint STATUS_HUNG_DISPLAY_DRIVER_THREAD = 0xC0000415;
		/// <summary>The Desktop heap encountered an error while allocating session memory. There is more information in the system event log.</summary>
		public const uint STATUS_INSUFFICIENT_RESOURCE_FOR_SPECIFIED_SHARED_SECTION_SIZE = 0xC0000416;
		/// <summary>An invalid parameter was passed to a C runtime function.</summary>
		public const uint STATUS_INVALID_CRUNTIME_PARAMETER = 0xC0000417;
		/// <summary>The authentication failed because NTLM was blocked.</summary>
		public const uint STATUS_NTLM_BLOCKED = 0xC0000418;
		/// <summary>The source object's SID already exists in destination forest.</summary>
		public const uint STATUS_DS_SRC_SID_EXISTS_IN_FOREST = 0xC0000419;
		/// <summary>The domain name of the trusted domain already exists in the forest.</summary>
		public const uint STATUS_DS_DOMAIN_NAME_EXISTS_IN_FOREST = 0xC000041A;
		/// <summary>The flat name of the trusted domain already exists in the forest.</summary>
		public const uint STATUS_DS_FLAT_NAME_EXISTS_IN_FOREST = 0xC000041B;
		/// <summary>The User Principal Name (UPN) is invalid.</summary>
		public const uint STATUS_INVALID_USER_PRINCIPAL_NAME = 0xC000041C;
		/// <summary>There has been an assertion failure.</summary>
		public const uint STATUS_ASSERTION_FAILURE = 0xC0000420;
		/// <summary>Application verifier has found an error in the current process.</summary>
		public const uint STATUS_VERIFIER_STOP = 0xC0000421;
		/// <summary>A user mode unwind is in progress.</summary>
		public const uint STATUS_CALLBACK_POP_STACK = 0xC0000423;
		/// <summary>%2 has been blocked from loading due to incompatibility with this system. Contact your software vendor for a compatible version of the driver.</summary>
		public const uint STATUS_INCOMPATIBLE_DRIVER_BLOCKED = 0xC0000424;
		/// <summary>Illegal operation attempted on a registry key which has already been unloaded.</summary>
		public const uint STATUS_HIVE_UNLOADED = 0xC0000425;
		/// <summary>Compression is disabled for this volume.</summary>
		public const uint STATUS_COMPRESSION_DISABLED = 0xC0000426;
		/// <summary>The requested operation could not be completed due to a file system limitation.</summary>
		public const uint STATUS_FILE_SYSTEM_LIMITATION = 0xC0000427;
		/// <summary>The hash for image %hs cannot be found in the system catalogs. The image is likely corrupt or the victim of tampering.</summary>
		public const uint STATUS_INVALID_IMAGE_HASH = 0xC0000428;
		/// <summary>The implementation is not capable of performing the request.</summary>
		public const uint STATUS_NOT_CAPABLE = 0xC0000429;
		/// <summary>The requested operation is out of order with respect to other operations.</summary>
		public const uint STATUS_REQUEST_OUT_OF_SEQUENCE = 0xC000042A;
		/// <summary>An operation attempted to exceed an implementation-defined limit.</summary>
		public const uint STATUS_IMPLEMENTATION_LIMIT = 0xC000042B;
		/// <summary>The requested operation requires elevation.</summary>
		public const uint STATUS_ELEVATION_REQUIRED = 0xC000042C;
		/// <summary>The required security context does not exist.</summary>
		public const uint STATUS_NO_SECURITY_CONTEXT = 0xC000042D;
		/// <summary>The PKU2U protocol encountered an error while attempting to utilize the associated certificates.</summary>
		public const uint STATUS_PKU2U_CERT_FAILURE = 0xC000042E;
		/// <summary>The operation was attempted beyond the valid data length of the file.</summary>
		public const uint STATUS_BEYOND_VDL = 0xC0000432;
		/// <summary>The attempted write operation encountered a write already in progress for some portion of the range.</summary>
		public const uint STATUS_ENCOUNTERED_WRITE_IN_PROGRESS = 0xC0000433;
		/// <summary>The page fault mappings changed in the middle of processing a fault so the operation must be retried.</summary>
		public const uint STATUS_PTE_CHANGED = 0xC0000434;
		/// <summary>The attempt to purge this file from memory failed to purge some or all the data from memory.</summary>
		public const uint STATUS_PURGE_FAILED = 0xC0000435;
		/// <summary>The requested credential requires confirmation.</summary>
		public const uint STATUS_CRED_REQUIRES_CONFIRMATION = 0xC0000440;
		/// <summary>The remote server sent an invalid response for a file being opened with Client Side Encryption.</summary>
		public const uint STATUS_CS_ENCRYPTION_INVALID_SERVER_RESPONSE = 0xC0000441;
		/// <summary>Client Side Encryption is not supported by the remote server even though it claims to support it.</summary>
		public const uint STATUS_CS_ENCRYPTION_UNSUPPORTED_SERVER = 0xC0000442;
		/// <summary>File is encrypted and should be opened in Client Side Encryption mode.</summary>
		public const uint STATUS_CS_ENCRYPTION_EXISTING_ENCRYPTED_FILE = 0xC0000443;
		/// <summary>A new encrypted file is being created and a $EFS needs to be provided.</summary>
		public const uint STATUS_CS_ENCRYPTION_NEW_ENCRYPTED_FILE = 0xC0000444;
		/// <summary>The SMB client requested a CSE FSCTL on a non-CSE file.</summary>
		public const uint STATUS_CS_ENCRYPTION_FILE_NOT_CSE = 0xC0000445;
		/// <summary>Indicates a particular Security ID cannot be assigned as the label of an object.</summary>
		public const uint STATUS_INVALID_LABEL = 0xC0000446;
		/// <summary>The process hosting the driver for this device has terminated.</summary>
		public const uint STATUS_DRIVER_PROCESS_TERMINATED = 0xC0000450;
		/// <summary>The requested system device cannot be identified due to multiple indistinguishable devices potentially matching the identification criteria.</summary>
		public const uint STATUS_AMBIGUOUS_SYSTEM_DEVICE = 0xC0000451;
		/// <summary>The requested system device cannot be found.</summary>
		public const uint STATUS_SYSTEM_DEVICE_NOT_FOUND = 0xC0000452;
		/// <summary>This boot application must be restarted.</summary>
		public const uint STATUS_RESTART_BOOT_APPLICATION = 0xC0000453;
		/// <summary>Insufficient NVRAM resources exist to complete the API.  A reboot might be required.</summary>
		public const uint STATUS_INSUFFICIENT_NVRAM_RESOURCES = 0xC0000454;
		/// <summary>No ranges for the specified operation were able to be processed.</summary>
		public const uint STATUS_NO_RANGES_PROCESSED = 0xC0000460;
		/// <summary>The storage device does not support Offload Write.</summary>
		public const uint STATUS_DEVICE_FEATURE_NOT_SUPPORTED = 0xC0000463;
		/// <summary>Data cannot be moved because the source device cannot communicate with the destination device.</summary>
		public const uint STATUS_DEVICE_UNREACHABLE = 0xC0000464;
		/// <summary>The token representing the data is invalid or expired.</summary>
		public const uint STATUS_INVALID_TOKEN = 0xC0000465;
		/// <summary>The file server is temporarily unavailable.</summary>
		public const uint STATUS_SERVER_UNAVAILABLE = 0xC0000466;
		/// <summary>The specified task name is invalid.</summary>
		public const uint STATUS_INVALID_TASK_NAME = 0xC0000500;
		/// <summary>The specified task index is invalid.</summary>
		public const uint STATUS_INVALID_TASK_INDEX = 0xC0000501;
		/// <summary>The specified thread is already joining a task.</summary>
		public const uint STATUS_THREAD_ALREADY_IN_TASK = 0xC0000502;
		/// <summary>A callback has requested to bypass native code.</summary>
		public const uint STATUS_CALLBACK_BYPASS = 0xC0000503;
		/// <summary>A fail fast exception occurred. Exception handlers will not be invoked and the process will be terminated immediately.</summary>
		public const uint STATUS_FAIL_FAST_EXCEPTION = 0xC0000602;
		/// <summary>Windows cannot verify the digital signature for this file. The signing certificate for this file has been revoked.</summary>
		public const uint STATUS_IMAGE_CERT_REVOKED = 0xC0000603;
		/// <summary>The ALPC port is closed.</summary>
		public const uint STATUS_PORT_CLOSED = 0xC0000700;
		/// <summary>The ALPC message requested is no longer available.</summary>
		public const uint STATUS_MESSAGE_LOST = 0xC0000701;
		/// <summary>The ALPC message supplied is invalid.</summary>
		public const uint STATUS_INVALID_MESSAGE = 0xC0000702;
		/// <summary>The ALPC message has been canceled.</summary>
		public const uint STATUS_REQUEST_CANCELED = 0xC0000703;
		/// <summary>Invalid recursive dispatch attempt.</summary>
		public const uint STATUS_RECURSIVE_DISPATCH = 0xC0000704;
		/// <summary>No receive buffer has been supplied in a synchronous request.</summary>
		public const uint STATUS_LPC_RECEIVE_BUFFER_EXPECTED = 0xC0000705;
		/// <summary>The connection port is used in an invalid context.</summary>
		public const uint STATUS_LPC_INVALID_CONNECTION_USAGE = 0xC0000706;
		/// <summary>The ALPC port does not accept new request messages.</summary>
		public const uint STATUS_LPC_REQUESTS_NOT_ALLOWED = 0xC0000707;
		/// <summary>The resource requested is already in use.</summary>
		public const uint STATUS_RESOURCE_IN_USE = 0xC0000708;
		/// <summary>The hardware has reported an uncorrectable memory error.</summary>
		public const uint STATUS_HARDWARE_MEMORY_ERROR = 0xC0000709;
		/// <summary>Status 0x%08x was returned, waiting on handle 0x%x for wait 0x%p, in waiter 0x%p.</summary>
		public const uint STATUS_THREADPOOL_HANDLE_EXCEPTION = 0xC000070A;
		/// <summary>After a callback to 0x%p(0x%p), a completion call to Set event(0x%p) failed with status 0x%08x.</summary>
		public const uint STATUS_THREADPOOL_SET_EVENT_ON_COMPLETION_FAILED = 0xC000070B;
		/// <summary>After a callback to 0x%p(0x%p), a completion call to ReleaseSemaphore(0x%p, %d) failed with status 0x%08x.</summary>
		public const uint STATUS_THREADPOOL_RELEASE_SEMAPHORE_ON_COMPLETION_FAILED = 0xC000070C;
		/// <summary>After a callback to 0x%p(0x%p), a completion call to ReleaseMutex(%p) failed with status 0x%08x.</summary>
		public const uint STATUS_THREADPOOL_RELEASE_MUTEX_ON_COMPLETION_FAILED = 0xC000070D;
		/// <summary>After a callback to 0x%p(0x%p), a completion call to FreeLibrary(%p) failed with status 0x%08x.</summary>
		public const uint STATUS_THREADPOOL_FREE_LIBRARY_ON_COMPLETION_FAILED = 0xC000070E;
		/// <summary>The thread pool 0x%p was released while a thread was posting a callback to 0x%p(0x%p) to it.</summary>
		public const uint STATUS_THREADPOOL_RELEASED_DURING_OPERATION = 0xC000070F;
		/// <summary>A thread pool worker thread is impersonating a client, after a callback to 0x%p(0x%p). This is unexpected, indicating that the callback is missing a call to revert the impersonation.</summary>
		public const uint STATUS_CALLBACK_RETURNED_WHILE_IMPERSONATING = 0xC0000710;
		/// <summary>A thread pool worker thread is impersonating a client, after executing an APC. This is unexpected, indicating that the APC is missing a call to revert the impersonation.</summary>
		public const uint STATUS_APC_RETURNED_WHILE_IMPERSONATING = 0xC0000711;
		/// <summary>Either the target process, or the target thread's containing process, is a protected process.</summary>
		public const uint STATUS_PROCESS_IS_PROTECTED = 0xC0000712;
		/// <summary>A thread is getting dispatched with MCA EXCEPTION because of MCA.</summary>
		public const uint STATUS_MCA_EXCEPTION = 0xC0000713;
		/// <summary>The client certificate account mapping is not unique.</summary>
		public const uint STATUS_CERTIFICATE_MAPPING_NOT_UNIQUE = 0xC0000714;
		/// <summary>The symbolic link cannot be followed because its type is disabled.</summary>
		public const uint STATUS_SYMLINK_CLASS_DISABLED = 0xC0000715;
		/// <summary>Indicates that the specified string is not valid for IDN normalization.</summary>
		public const uint STATUS_INVALID_IDN_NORMALIZATION = 0xC0000716;
		/// <summary>No mapping for the Unicode character exists in the target multi-byte code page.</summary>
		public const uint STATUS_NO_UNICODE_TRANSLATION = 0xC0000717;
		/// <summary>The provided callback is already registered.</summary>
		public const uint STATUS_ALREADY_REGISTERED = 0xC0000718;
		/// <summary>The provided context did not match the target.</summary>
		public const uint STATUS_CONTEXT_MISMATCH = 0xC0000719;
		/// <summary>The specified port already has a completion list.</summary>
		public const uint STATUS_PORT_ALREADY_HAS_COMPLETION_LIST = 0xC000071A;
		/// <summary>A threadpool worker thread entered a callback at thread base priority 0x%x and exited at priority 0x%x. This is unexpected, indicating that the callback missed restoring the priority.</summary>
		public const uint STATUS_CALLBACK_RETURNED_THREAD_PRIORITY = 0xC000071B;
		/// <summary>An invalid thread, handle %p, is specified for this operation. Possibly, a threadpool worker thread was specified.</summary>
		public const uint STATUS_INVALID_THREAD = 0xC000071C;
		/// <summary>A threadpool worker thread entered a callback, which left transaction state. This is unexpected, indicating that the callback missed clearing the transaction.</summary>
		public const uint STATUS_CALLBACK_RETURNED_TRANSACTION = 0xC000071D;
		/// <summary>A threadpool worker thread entered a callback, which left the loader lock held. This is unexpected, indicating that the callback missed releasing the lock.</summary>
		public const uint STATUS_CALLBACK_RETURNED_LDR_LOCK = 0xC000071E;
		/// <summary>A threadpool worker thread entered a callback, which left with preferred languages set. This is unexpected, indicating that the callback missed clearing them.</summary>
		public const uint STATUS_CALLBACK_RETURNED_LANG = 0xC000071F;
		/// <summary>A threadpool worker thread entered a callback, which left with background priorities set. This is unexpected, indicating that the callback missed restoring the original priorities.</summary>
		public const uint STATUS_CALLBACK_RETURNED_PRI_BACK = 0xC0000720;
		/// <summary>The attempted operation required self healing to be enabled.</summary>
		public const uint STATUS_DISK_REPAIR_DISABLED = 0xC0000800;
		/// <summary>The directory service cannot perform the requested operation because a domain rename operation is in progress.</summary>
		public const uint STATUS_DS_DOMAIN_RENAME_IN_PROGRESS = 0xC0000801;
		/// <summary>An operation failed because the storage quota was exceeded.</summary>
		public const uint STATUS_DISK_QUOTA_EXCEEDED = 0xC0000802;
		/// <summary>An operation failed because the content was blocked.</summary>
		public const uint STATUS_CONTENT_BLOCKED = 0xC0000804;
		/// <summary>The operation could not be completed due to bad clusters on disk.</summary>
		public const uint STATUS_BAD_CLUSTERS = 0xC0000805;
		/// <summary>The operation could not be completed because the volume is dirty. Please run the Chkdsk utility and try again.</summary>
		public const uint STATUS_VOLUME_DIRTY = 0xC0000806;
		/// <summary>This file is checked out or locked for editing by another user.</summary>
		public const uint STATUS_FILE_CHECKED_OUT = 0xC0000901;
		/// <summary>The file must be checked out before saving changes.</summary>
		public const uint STATUS_CHECKOUT_REQUIRED = 0xC0000902;
		/// <summary>The file type being saved or retrieved has been blocked.</summary>
		public const uint STATUS_BAD_FILE_TYPE = 0xC0000903;
		/// <summary>The file size exceeds the limit allowed and cannot be saved.</summary>
		public const uint STATUS_FILE_TOO_LARGE = 0xC0000904;
		/// <summary>Access Denied. Before opening files in this location, you must first browse to the e.g. site and select the option to log on automatically.</summary>
		public const uint STATUS_FORMS_AUTH_REQUIRED = 0xC0000905;
		/// <summary>The operation did not complete successfully because the file contains a virus.</summary>
		public const uint STATUS_VIRUS_INFECTED = 0xC0000906;
		/// <summary>This file contains a virus and cannot be opened. Due to the nature of this virus, the file has been removed from this location.</summary>
		public const uint STATUS_VIRUS_DELETED = 0xC0000907;
		/// <summary>The resources required for this device conflict with the MCFG table.</summary>
		public const uint STATUS_BAD_MCFG_TABLE = 0xC0000908;
		/// <summary>The operation did not complete successfully because it would cause an oplock to be broken. The caller has requested that existing oplocks not be broken.</summary>
		public const uint STATUS_CANNOT_BREAK_OPLOCK = 0xC0000909;
		/// <summary>WOW Assertion Error.</summary>
		public const uint STATUS_WOW_ASSERTION = 0xC0009898;
		/// <summary>The cryptographic signature is invalid.</summary>
		public const uint STATUS_INVALID_SIGNATURE = 0xC000A000;
		/// <summary>The cryptographic provider does not support HMAC.</summary>
		public const uint STATUS_HMAC_NOT_SUPPORTED = 0xC000A001;
		/// <summary>The IPsec queue overflowed.</summary>
		public const uint STATUS_IPSEC_QUEUE_OVERFLOW = 0xC000A010;
		/// <summary>The neighbor discovery queue overflowed.</summary>
		public const uint STATUS_ND_QUEUE_OVERFLOW = 0xC000A011;
		/// <summary>An Internet Control Message Protocol (ICMP) hop limit exceeded error was received.</summary>
		public const uint STATUS_HOPLIMIT_EXCEEDED = 0xC000A012;
		/// <summary>The protocol is not installed on the local machine.</summary>
		public const uint STATUS_PROTOCOL_NOT_SUPPORTED = 0xC000A013;
		/// <summary>{Delayed Write Failed} Windows was unable to save all the data for the file %hs; the data has been lost. This error might be caused by network connectivity issues. Try to save this file elsewhere.</summary>
		public const uint STATUS_LOST_WRITEBEHIND_DATA_NETWORK_DISCONNECTED = 0xC000A080;
		/// <summary>{Delayed Write Failed} Windows was unable to save all the data for the file %hs; the data has been lost. This error was returned by the server on which the file exists. Try to save this file elsewhere.</summary>
		public const uint STATUS_LOST_WRITEBEHIND_DATA_NETWORK_SERVER_ERROR = 0xC000A081;
		/// <summary>{Delayed Write Failed} Windows was unable to save all the data for the file %hs; the data has been lost. This error might be caused if the device has been removed or the media is write-protected.</summary>
		public const uint STATUS_LOST_WRITEBEHIND_DATA_LOCAL_DISK_ERROR = 0xC000A082;
		/// <summary>Windows was unable to parse the requested XML data.</summary>
		public const uint STATUS_XML_PARSE_ERROR = 0xC000A083;
		/// <summary>An error was encountered while processing an XML digital signature.</summary>
		public const uint STATUS_XMLDSIG_ERROR = 0xC000A084;
		/// <summary>This indicates that the caller made the connection request in the wrong routing compartment.</summary>
		public const uint STATUS_WRONG_COMPARTMENT = 0xC000A085;
		/// <summary>This indicates that there was an AuthIP failure when attempting to connect to the remote host.</summary>
		public const uint STATUS_AUTHIP_FAILURE = 0xC000A086;
		/// <summary>OID mapped groups cannot have members.</summary>
		public const uint STATUS_DS_OID_MAPPED_GROUP_CANT_HAVE_MEMBERS = 0xC000A087;
		/// <summary>The specified OID cannot be found.</summary>
		public const uint STATUS_DS_OID_NOT_FOUND = 0xC000A088;
		/// <summary>Hash generation for the specified version and hash type is not enabled on server.</summary>
		public const uint STATUS_HASH_NOT_SUPPORTED = 0xC000A100;
		/// <summary>The hash requests is not present or not up to date with the current file contents.</summary>
		public const uint STATUS_HASH_NOT_PRESENT = 0xC000A101;
		/// <summary>A file system filter on the server has not opted in for Offload Read support.</summary>
		public const uint STATUS_OFFLOAD_READ_FLT_NOT_SUPPORTED = 0xC000A2A1;
		/// <summary>A file system filter on the server has not opted in for Offload Write support.</summary>
		public const uint STATUS_OFFLOAD_WRITE_FLT_NOT_SUPPORTED = 0xC000A2A2;
		/// <summary>Offload read operations cannot be performed on: Compressed files, Sparse files, Encrypted files, File system metadata files</summary>
		public const uint STATUS_OFFLOAD_READ_FILE_NOT_SUPPORTED = 0xC000A2A3;
		/// <summary>Offload write operations cannot be performed on: Compressed files, Sparse files, Encrypted files, File system metadata files</summary>
		public const uint STATUS_OFFLOAD_WRITE_FILE_NOT_SUPPORTED = 0xC000A2A4;
		/// <summary>The debugger did not perform a state change.</summary>
		public const uint DBG_NO_STATE_CHANGE = 0xC0010001;
		/// <summary>The debugger found that the application is not idle.</summary>
		public const uint DBG_APP_NOT_IDLE = 0xC0010002;
		/// <summary>The string binding is invalid.</summary>
		public const uint RPC_NT_INVALID_STRING_BINDING = 0xC0020001;
		/// <summary>The binding handle is not the correct type.</summary>
		public const uint RPC_NT_WRONG_KIND_OF_BINDING = 0xC0020002;
		/// <summary>The binding handle is invalid.</summary>
		public const uint RPC_NT_INVALID_BINDING = 0xC0020003;
		/// <summary>The RPC protocol sequence is not supported.</summary>
		public const uint RPC_NT_PROTSEQ_NOT_SUPPORTED = 0xC0020004;
		/// <summary>The RPC protocol sequence is invalid.</summary>
		public const uint RPC_NT_INVALID_RPC_PROTSEQ = 0xC0020005;
		/// <summary>The string UUID is invalid.</summary>
		public const uint RPC_NT_INVALID_STRING_UUID = 0xC0020006;
		/// <summary>The endpoint format is invalid.</summary>
		public const uint RPC_NT_INVALID_ENDPOINT_FORMAT = 0xC0020007;
		/// <summary>The network address is invalid.</summary>
		public const uint RPC_NT_INVALID_NET_ADDR = 0xC0020008;
		/// <summary>No endpoint was found.</summary>
		public const uint RPC_NT_NO_ENDPOINT_FOUND = 0xC0020009;
		/// <summary>The time-out value is invalid.</summary>
		public const uint RPC_NT_INVALID_TIMEOUT = 0xC002000A;
		/// <summary>The object UUID was not found.</summary>
		public const uint RPC_NT_OBJECT_NOT_FOUND = 0xC002000B;
		/// <summary>The object UUID has already been registered.</summary>
		public const uint RPC_NT_ALREADY_REGISTERED = 0xC002000C;
		/// <summary>The type UUID has already been registered.</summary>
		public const uint RPC_NT_TYPE_ALREADY_REGISTERED = 0xC002000D;
		/// <summary>The RPC server is already listening.</summary>
		public const uint RPC_NT_ALREADY_LISTENING = 0xC002000E;
		/// <summary>No protocol sequences have been registered.</summary>
		public const uint RPC_NT_NO_PROTSEQS_REGISTERED = 0xC002000F;
		/// <summary>The RPC server is not listening.</summary>
		public const uint RPC_NT_NOT_LISTENING = 0xC0020010;
		/// <summary>The manager type is unknown.</summary>
		public const uint RPC_NT_UNKNOWN_MGR_TYPE = 0xC0020011;
		/// <summary>The interface is unknown.</summary>
		public const uint RPC_NT_UNKNOWN_IF = 0xC0020012;
		/// <summary>There are no bindings.</summary>
		public const uint RPC_NT_NO_BINDINGS = 0xC0020013;
		/// <summary>There are no protocol sequences.</summary>
		public const uint RPC_NT_NO_PROTSEQS = 0xC0020014;
		/// <summary>The endpoint cannot be created.</summary>
		public const uint RPC_NT_CANT_CREATE_ENDPOINT = 0xC0020015;
		/// <summary>Insufficient resources are available to complete this operation.</summary>
		public const uint RPC_NT_OUT_OF_RESOURCES = 0xC0020016;
		/// <summary>The RPC server is unavailable.</summary>
		public const uint RPC_NT_SERVER_UNAVAILABLE = 0xC0020017;
		/// <summary>The RPC server is too busy to complete this operation.</summary>
		public const uint RPC_NT_SERVER_TOO_BUSY = 0xC0020018;
		/// <summary>The network options are invalid.</summary>
		public const uint RPC_NT_INVALID_NETWORK_OPTIONS = 0xC0020019;
		/// <summary>No RPCs are active on this thread.</summary>
		public const uint RPC_NT_NO_CALL_ACTIVE = 0xC002001A;
		/// <summary>The RPC failed.</summary>
		public const uint RPC_NT_CALL_FAILED = 0xC002001B;
		/// <summary>The RPC failed and did not execute.</summary>
		public const uint RPC_NT_CALL_FAILED_DNE = 0xC002001C;
		/// <summary>An RPC protocol error occurred.</summary>
		public const uint RPC_NT_PROTOCOL_ERROR = 0xC002001D;
		/// <summary>The RPC server does not support the transfer syntax.</summary>
		public const uint RPC_NT_UNSUPPORTED_TRANS_SYN = 0xC002001F;
		/// <summary>The type UUID is not supported.</summary>
		public const uint RPC_NT_UNSUPPORTED_TYPE = 0xC0020021;
		/// <summary>The tag is invalid.</summary>
		public const uint RPC_NT_INVALID_TAG = 0xC0020022;
		/// <summary>The array bounds are invalid.</summary>
		public const uint RPC_NT_INVALID_BOUND = 0xC0020023;
		/// <summary>The binding does not contain an entry name.</summary>
		public const uint RPC_NT_NO_ENTRY_NAME = 0xC0020024;
		/// <summary>The name syntax is invalid.</summary>
		public const uint RPC_NT_INVALID_NAME_SYNTAX = 0xC0020025;
		/// <summary>The name syntax is not supported.</summary>
		public const uint RPC_NT_UNSUPPORTED_NAME_SYNTAX = 0xC0020026;
		/// <summary>No network address is available to construct a UUID.</summary>
		public const uint RPC_NT_UUID_NO_ADDRESS = 0xC0020028;
		/// <summary>The endpoint is a duplicate.</summary>
		public const uint RPC_NT_DUPLICATE_ENDPOINT = 0xC0020029;
		/// <summary>The authentication type is unknown.</summary>
		public const uint RPC_NT_UNKNOWN_AUTHN_TYPE = 0xC002002A;
		/// <summary>The maximum number of calls is too small.</summary>
		public const uint RPC_NT_MAX_CALLS_TOO_SMALL = 0xC002002B;
		/// <summary>The string is too long.</summary>
		public const uint RPC_NT_STRING_TOO_LONG = 0xC002002C;
		/// <summary>The RPC protocol sequence was not found.</summary>
		public const uint RPC_NT_PROTSEQ_NOT_FOUND = 0xC002002D;
		/// <summary>The procedure number is out of range.</summary>
		public const uint RPC_NT_PROCNUM_OUT_OF_RANGE = 0xC002002E;
		/// <summary>The binding does not contain any authentication information.</summary>
		public const uint RPC_NT_BINDING_HAS_NO_AUTH = 0xC002002F;
		/// <summary>The authentication service is unknown.</summary>
		public const uint RPC_NT_UNKNOWN_AUTHN_SERVICE = 0xC0020030;
		/// <summary>The authentication level is unknown.</summary>
		public const uint RPC_NT_UNKNOWN_AUTHN_LEVEL = 0xC0020031;
		/// <summary>The security context is invalid.</summary>
		public const uint RPC_NT_INVALID_AUTH_IDENTITY = 0xC0020032;
		/// <summary>The authorization service is unknown.</summary>
		public const uint RPC_NT_UNKNOWN_AUTHZ_SERVICE = 0xC0020033;
		/// <summary>The entry is invalid.</summary>
		public const uint EPT_NT_INVALID_ENTRY = 0xC0020034;
		/// <summary>The operation cannot be performed.</summary>
		public const uint EPT_NT_CANT_PERFORM_OP = 0xC0020035;
		/// <summary>No more endpoints are available from the endpoint mapper.</summary>
		public const uint EPT_NT_NOT_REGISTERED = 0xC0020036;
		/// <summary>No interfaces have been exported.</summary>
		public const uint RPC_NT_NOTHING_TO_EXPORT = 0xC0020037;
		/// <summary>The entry name is incomplete.</summary>
		public const uint RPC_NT_INCOMPLETE_NAME = 0xC0020038;
		/// <summary>The version option is invalid.</summary>
		public const uint RPC_NT_INVALID_VERS_OPTION = 0xC0020039;
		/// <summary>There are no more members.</summary>
		public const uint RPC_NT_NO_MORE_MEMBERS = 0xC002003A;
		/// <summary>There is nothing to unexport.</summary>
		public const uint RPC_NT_NOT_ALL_OBJS_UNEXPORTED = 0xC002003B;
		/// <summary>The interface was not found.</summary>
		public const uint RPC_NT_INTERFACE_NOT_FOUND = 0xC002003C;
		/// <summary>The entry already exists.</summary>
		public const uint RPC_NT_ENTRY_ALREADY_EXISTS = 0xC002003D;
		/// <summary>The entry was not found.</summary>
		public const uint RPC_NT_ENTRY_NOT_FOUND = 0xC002003E;
		/// <summary>The name service is unavailable.</summary>
		public const uint RPC_NT_NAME_SERVICE_UNAVAILABLE = 0xC002003F;
		/// <summary>The network address family is invalid.</summary>
		public const uint RPC_NT_INVALID_NAF_ID = 0xC0020040;
		/// <summary>The requested operation is not supported.</summary>
		public const uint RPC_NT_CANNOT_SUPPORT = 0xC0020041;
		/// <summary>No security context is available to allow impersonation.</summary>
		public const uint RPC_NT_NO_CONTEXT_AVAILABLE = 0xC0020042;
		/// <summary>An internal error occurred in the RPC.</summary>
		public const uint RPC_NT_INTERNAL_ERROR = 0xC0020043;
		/// <summary>The RPC server attempted to divide an integer by zero.</summary>
		public const uint RPC_NT_ZERO_DIVIDE = 0xC0020044;
		/// <summary>An addressing error occurred in the RPC server.</summary>
		public const uint RPC_NT_ADDRESS_ERROR = 0xC0020045;
		/// <summary>A floating point operation at the RPC server caused a divide by zero.</summary>
		public const uint RPC_NT_FP_DIV_ZERO = 0xC0020046;
		/// <summary>A floating point underflow occurred at the RPC server.</summary>
		public const uint RPC_NT_FP_UNDERFLOW = 0xC0020047;
		/// <summary>A floating point overflow occurred at the RPC server.</summary>
		public const uint RPC_NT_FP_OVERFLOW = 0xC0020048;
		/// <summary>An RPC is already in progress for this thread.</summary>
		public const uint RPC_NT_CALL_IN_PROGRESS = 0xC0020049;
		/// <summary>There are no more bindings.</summary>
		public const uint RPC_NT_NO_MORE_BINDINGS = 0xC002004A;
		/// <summary>The group member was not found.</summary>
		public const uint RPC_NT_GROUP_MEMBER_NOT_FOUND = 0xC002004B;
		/// <summary>The endpoint mapper database entry could not be created.</summary>
		public const uint EPT_NT_CANT_CREATE = 0xC002004C;
		/// <summary>The object UUID is the nil UUID.</summary>
		public const uint RPC_NT_INVALID_OBJECT = 0xC002004D;
		/// <summary>No interfaces have been registered.</summary>
		public const uint RPC_NT_NO_INTERFACES = 0xC002004F;
		/// <summary>The RPC was canceled.</summary>
		public const uint RPC_NT_CALL_CANCELLED = 0xC0020050;
		/// <summary>The binding handle does not contain all the required information.</summary>
		public const uint RPC_NT_BINDING_INCOMPLETE = 0xC0020051;
		/// <summary>A communications failure occurred during an RPC.</summary>
		public const uint RPC_NT_COMM_FAILURE = 0xC0020052;
		/// <summary>The requested authentication level is not supported.</summary>
		public const uint RPC_NT_UNSUPPORTED_AUTHN_LEVEL = 0xC0020053;
		/// <summary>No principal name was registered.</summary>
		public const uint RPC_NT_NO_PRINC_NAME = 0xC0020054;
		/// <summary>The error specified is not a valid Windows RPC error code.</summary>
		public const uint RPC_NT_NOT_RPC_ERROR = 0xC0020055;
		/// <summary>A security package-specific error occurred.</summary>
		public const uint RPC_NT_SEC_PKG_ERROR = 0xC0020057;
		/// <summary>The thread was not canceled.</summary>
		public const uint RPC_NT_NOT_CANCELLED = 0xC0020058;
		/// <summary>Invalid asynchronous RPC handle.</summary>
		public const uint RPC_NT_INVALID_ASYNC_HANDLE = 0xC0020062;
		/// <summary>Invalid asynchronous RPC call handle for this operation.</summary>
		public const uint RPC_NT_INVALID_ASYNC_CALL = 0xC0020063;
		/// <summary>Access to the HTTP proxy is denied.</summary>
		public const uint RPC_NT_PROXY_ACCESS_DENIED = 0xC0020064;
		/// <summary>The list of RPC servers available for auto-handle binding has been exhausted.</summary>
		public const uint RPC_NT_NO_MORE_ENTRIES = 0xC0030001;
		/// <summary>The file designated by DCERPCCHARTRANS cannot be opened.</summary>
		public const uint RPC_NT_SS_CHAR_TRANS_OPEN_FAIL = 0xC0030002;
		/// <summary>The file containing the character translation table has fewer than 512 bytes.</summary>
		public const uint RPC_NT_SS_CHAR_TRANS_SHORT_FILE = 0xC0030003;
		/// <summary>A null context handle is passed as an [in] parameter.</summary>
		public const uint RPC_NT_SS_IN_NULL_CONTEXT = 0xC0030004;
		/// <summary>The context handle does not match any known context handles.</summary>
		public const uint RPC_NT_SS_CONTEXT_MISMATCH = 0xC0030005;
		/// <summary>The context handle changed during a call.</summary>
		public const uint RPC_NT_SS_CONTEXT_DAMAGED = 0xC0030006;
		/// <summary>The binding handles passed to an RPC do not match.</summary>
		public const uint RPC_NT_SS_HANDLES_MISMATCH = 0xC0030007;
		/// <summary>The stub is unable to get the call handle.</summary>
		public const uint RPC_NT_SS_CANNOT_GET_CALL_HANDLE = 0xC0030008;
		/// <summary>A null reference pointer was passed to the stub.</summary>
		public const uint RPC_NT_NULL_REF_POINTER = 0xC0030009;
		/// <summary>The enumeration value is out of range.</summary>
		public const uint RPC_NT_ENUM_VALUE_OUT_OF_RANGE = 0xC003000A;
		/// <summary>The byte count is too small.</summary>
		public const uint RPC_NT_BYTE_COUNT_TOO_SMALL = 0xC003000B;
		/// <summary>The stub received bad data.</summary>
		public const uint RPC_NT_BAD_STUB_DATA = 0xC003000C;
		/// <summary>Invalid operation on the encoding/decoding handle.</summary>
		public const uint RPC_NT_INVALID_ES_ACTION = 0xC0030059;
		/// <summary>Incompatible version of the serializing package.</summary>
		public const uint RPC_NT_WRONG_ES_VERSION = 0xC003005A;
		/// <summary>Incompatible version of the RPC stub.</summary>
		public const uint RPC_NT_WRONG_STUB_VERSION = 0xC003005B;
		/// <summary>The RPC pipe object is invalid or corrupt.</summary>
		public const uint RPC_NT_INVALID_PIPE_OBJECT = 0xC003005C;
		/// <summary>An invalid operation was attempted on an RPC pipe object.</summary>
		public const uint RPC_NT_INVALID_PIPE_OPERATION = 0xC003005D;
		/// <summary>Unsupported RPC pipe version.</summary>
		public const uint RPC_NT_WRONG_PIPE_VERSION = 0xC003005E;
		/// <summary>The RPC pipe object has already been closed.</summary>
		public const uint RPC_NT_PIPE_CLOSED = 0xC003005F;
		/// <summary>The RPC call completed before all pipes were processed.</summary>
		public const uint RPC_NT_PIPE_DISCIPLINE_ERROR = 0xC0030060;
		/// <summary>No more data is available from the RPC pipe.</summary>
		public const uint RPC_NT_PIPE_EMPTY = 0xC0030061;
		/// <summary>A device is missing in the system BIOS MPS table. This device will not be used. Contact your system vendor for a system BIOS update.</summary>
		public const uint STATUS_PNP_BAD_MPS_TABLE = 0xC0040035;
		/// <summary>A translator failed to translate resources.</summary>
		public const uint STATUS_PNP_TRANSLATION_FAILED = 0xC0040036;
		/// <summary>An IRQ translator failed to translate resources.</summary>
		public const uint STATUS_PNP_IRQ_TRANSLATION_FAILED = 0xC0040037;
		/// <summary>Driver %2 returned an invalid ID for a child device (%3).</summary>
		public const uint STATUS_PNP_INVALID_ID = 0xC0040038;
		/// <summary>Reissue the given operation as a cached I/O operation</summary>
		public const uint STATUS_IO_REISSUE_AS_CACHED = 0xC0040039;
		/// <summary>Session name %1 is invalid.</summary>
		public const uint STATUS_CTX_WINSTATION_NAME_INVALID = 0xC00A0001;
		/// <summary>The protocol driver %1 is invalid.</summary>
		public const uint STATUS_CTX_INVALID_PD = 0xC00A0002;
		/// <summary>The protocol driver %1 was not found in the system path.</summary>
		public const uint STATUS_CTX_PD_NOT_FOUND = 0xC00A0003;
		/// <summary>A close operation is pending on the terminal connection.</summary>
		public const uint STATUS_CTX_CLOSE_PENDING = 0xC00A0006;
		/// <summary>No free output buffers are available.</summary>
		public const uint STATUS_CTX_NO_OUTBUF = 0xC00A0007;
		/// <summary>The MODEM.INF file was not found.</summary>
		public const uint STATUS_CTX_MODEM_INF_NOT_FOUND = 0xC00A0008;
		/// <summary>The modem (%1) was not found in the MODEM.INF file.</summary>
		public const uint STATUS_CTX_INVALID_MODEMNAME = 0xC00A0009;
		/// <summary>The modem did not accept the command sent to it. Verify that the configured modem name matches the attached modem.</summary>
		public const uint STATUS_CTX_RESPONSE_ERROR = 0xC00A000A;
		/// <summary>The modem did not respond to the command sent to it. Verify that the modem cable is properly attached and the modem is turned on.</summary>
		public const uint STATUS_CTX_MODEM_RESPONSE_TIMEOUT = 0xC00A000B;
		/// <summary>Carrier detection has failed or the carrier has been dropped due to disconnection.</summary>
		public const uint STATUS_CTX_MODEM_RESPONSE_NO_CARRIER = 0xC00A000C;
		/// <summary>A dial tone was not detected within the required time. Verify that the phone cable is properly attached and functional.</summary>
		public const uint STATUS_CTX_MODEM_RESPONSE_NO_DIALTONE = 0xC00A000D;
		/// <summary>A busy signal was detected at a remote site on callback.</summary>
		public const uint STATUS_CTX_MODEM_RESPONSE_BUSY = 0xC00A000E;
		/// <summary>A voice was detected at a remote site on callback.</summary>
		public const uint STATUS_CTX_MODEM_RESPONSE_VOICE = 0xC00A000F;
		/// <summary>Transport driver error.</summary>
		public const uint STATUS_CTX_TD_ERROR = 0xC00A0010;
		/// <summary>The client you are using is not licensed to use this system. Your logon request is denied.</summary>
		public const uint STATUS_CTX_LICENSE_CLIENT_INVALID = 0xC00A0012;
		/// <summary>The system has reached its licensed logon limit. Try again later.</summary>
		public const uint STATUS_CTX_LICENSE_NOT_AVAILABLE = 0xC00A0013;
		/// <summary>The system license has expired. Your logon request is denied.</summary>
		public const uint STATUS_CTX_LICENSE_EXPIRED = 0xC00A0014;
		/// <summary>The specified session cannot be found.</summary>
		public const uint STATUS_CTX_WINSTATION_NOT_FOUND = 0xC00A0015;
		/// <summary>The specified session name is already in use.</summary>
		public const uint STATUS_CTX_WINSTATION_NAME_COLLISION = 0xC00A0016;
		/// <summary>The requested operation cannot be completed because the terminal connection is currently processing a connect, disconnect, reset, or delete operation.</summary>
		public const uint STATUS_CTX_WINSTATION_BUSY = 0xC00A0017;
		/// <summary>An attempt has been made to connect to a session whose video mode is not supported by the current client.</summary>
		public const uint STATUS_CTX_BAD_VIDEO_MODE = 0xC00A0018;
		/// <summary>The application attempted to enable DOS graphics mode. DOS graphics mode is not supported.</summary>
		public const uint STATUS_CTX_GRAPHICS_INVALID = 0xC00A0022;
		/// <summary>The requested operation can be performed only on the system console. This is most often the result of a driver or system DLL requiring direct console access.</summary>
		public const uint STATUS_CTX_NOT_CONSOLE = 0xC00A0024;
		/// <summary>The client failed to respond to the server connect message.</summary>
		public const uint STATUS_CTX_CLIENT_QUERY_TIMEOUT = 0xC00A0026;
		/// <summary>Disconnecting the console session is not supported.</summary>
		public const uint STATUS_CTX_CONSOLE_DISCONNECT = 0xC00A0027;
		/// <summary>Reconnecting a disconnected session to the console is not supported.</summary>
		public const uint STATUS_CTX_CONSOLE_CONNECT = 0xC00A0028;
		/// <summary>The request to control another session remotely was denied.</summary>
		public const uint STATUS_CTX_SHADOW_DENIED = 0xC00A002A;
		/// <summary>A process has requested access to a session, but has not been granted those access rights.</summary>
		public const uint STATUS_CTX_WINSTATION_ACCESS_DENIED = 0xC00A002B;
		/// <summary>The terminal connection driver %1 is invalid.</summary>
		public const uint STATUS_CTX_INVALID_WD = 0xC00A002E;
		/// <summary>The terminal connection driver %1 was not found in the system path.</summary>
		public const uint STATUS_CTX_WD_NOT_FOUND = 0xC00A002F;
		/// <summary>The requested session cannot be controlled remotely. You cannot control your own session, a session that is trying to control your session, a session that has no user logged on, or other sessions from the console.</summary>
		public const uint STATUS_CTX_SHADOW_INVALID = 0xC00A0030;
		/// <summary>The requested session is not configured to allow remote control.</summary>
		public const uint STATUS_CTX_SHADOW_DISABLED = 0xC00A0031;
		/// <summary>The RDP protocol component %2 detected an error in the protocol stream and has disconnected the client.</summary>
		public const uint STATUS_RDP_PROTOCOL_ERROR = 0xC00A0032;
		/// <summary>Your request to connect to this terminal server has been rejected. Your terminal server client license number has not been entered for this copy of the terminal client. Contact your system administrator for help in entering a valid, unique license number for this terminal server client. Click OK to continue.</summary>
		public const uint STATUS_CTX_CLIENT_LICENSE_NOT_SET = 0xC00A0033;
		/// <summary>Your request to connect to this terminal server has been rejected. Your terminal server client license number is currently being used by another user. Contact your system administrator to obtain a new copy of the terminal server client with a valid, unique license number. Click OK to continue.</summary>
		public const uint STATUS_CTX_CLIENT_LICENSE_IN_USE = 0xC00A0034;
		/// <summary>The remote control of the console was terminated because the display mode was changed. Changing the display mode in a remote control session is not supported.</summary>
		public const uint STATUS_CTX_SHADOW_ENDED_BY_MODE_CHANGE = 0xC00A0035;
		/// <summary>Remote control could not be terminated because the specified session is not currently being remotely controlled.</summary>
		public const uint STATUS_CTX_SHADOW_NOT_RUNNING = 0xC00A0036;
		/// <summary>Your interactive logon privilege has been disabled. Contact your system administrator.</summary>
		public const uint STATUS_CTX_LOGON_DISABLED = 0xC00A0037;
		/// <summary>The terminal server security layer detected an error in the protocol stream and has disconnected the client.</summary>
		public const uint STATUS_CTX_SECURITY_LAYER_ERROR = 0xC00A0038;
		/// <summary>The target session is incompatible with the current session.</summary>
		public const uint STATUS_TS_INCOMPATIBLE_SESSIONS = 0xC00A0039;
		/// <summary>The resource loader failed to find an MUI file.</summary>
		public const uint STATUS_MUI_FILE_NOT_FOUND = 0xC00B0001;
		/// <summary>The resource loader failed to load an MUI file because the file failed to pass validation.</summary>
		public const uint STATUS_MUI_INVALID_FILE = 0xC00B0002;
		/// <summary>The RC manifest is corrupted with garbage data, is an unsupported version, or is missing a required item.</summary>
		public const uint STATUS_MUI_INVALID_RC_CONFIG = 0xC00B0003;
		/// <summary>The RC manifest has an invalid culture name.</summary>
		public const uint STATUS_MUI_INVALID_LOCALE_NAME = 0xC00B0004;
		/// <summary>The RC manifest has and invalid ultimate fallback name.</summary>
		public const uint STATUS_MUI_INVALID_ULTIMATEFALLBACK_NAME = 0xC00B0005;
		/// <summary>The resource loader cache does not have a loaded MUI entry.</summary>
		public const uint STATUS_MUI_FILE_NOT_LOADED = 0xC00B0006;
		/// <summary>The user stopped resource enumeration.</summary>
		public const uint STATUS_RESOURCE_ENUM_USER_STOP = 0xC00B0007;
		/// <summary>The cluster node is not valid.</summary>
		public const uint STATUS_CLUSTER_INVALID_NODE = 0xC0130001;
		/// <summary>The cluster node already exists.</summary>
		public const uint STATUS_CLUSTER_NODE_EXISTS = 0xC0130002;
		/// <summary>A node is in the process of joining the cluster.</summary>
		public const uint STATUS_CLUSTER_JOIN_IN_PROGRESS = 0xC0130003;
		/// <summary>The cluster node was not found.</summary>
		public const uint STATUS_CLUSTER_NODE_NOT_FOUND = 0xC0130004;
		/// <summary>The cluster local node information was not found.</summary>
		public const uint STATUS_CLUSTER_LOCAL_NODE_NOT_FOUND = 0xC0130005;
		/// <summary>The cluster network already exists.</summary>
		public const uint STATUS_CLUSTER_NETWORK_EXISTS = 0xC0130006;
		/// <summary>The cluster network was not found.</summary>
		public const uint STATUS_CLUSTER_NETWORK_NOT_FOUND = 0xC0130007;
		/// <summary>The cluster network interface already exists.</summary>
		public const uint STATUS_CLUSTER_NETINTERFACE_EXISTS = 0xC0130008;
		/// <summary>The cluster network interface was not found.</summary>
		public const uint STATUS_CLUSTER_NETINTERFACE_NOT_FOUND = 0xC0130009;
		/// <summary>The cluster request is not valid for this object.</summary>
		public const uint STATUS_CLUSTER_INVALID_REQUEST = 0xC013000A;
		/// <summary>The cluster network provider is not valid.</summary>
		public const uint STATUS_CLUSTER_INVALID_NETWORK_PROVIDER = 0xC013000B;
		/// <summary>The cluster node is down.</summary>
		public const uint STATUS_CLUSTER_NODE_DOWN = 0xC013000C;
		/// <summary>The cluster node is not reachable.</summary>
		public const uint STATUS_CLUSTER_NODE_UNREACHABLE = 0xC013000D;
		/// <summary>The cluster node is not a member of the cluster.</summary>
		public const uint STATUS_CLUSTER_NODE_NOT_MEMBER = 0xC013000E;
		/// <summary>A cluster join operation is not in progress.</summary>
		public const uint STATUS_CLUSTER_JOIN_NOT_IN_PROGRESS = 0xC013000F;
		/// <summary>The cluster network is not valid.</summary>
		public const uint STATUS_CLUSTER_INVALID_NETWORK = 0xC0130010;
		/// <summary>No network adapters are available.</summary>
		public const uint STATUS_CLUSTER_NO_NET_ADAPTERS = 0xC0130011;
		/// <summary>The cluster node is up.</summary>
		public const uint STATUS_CLUSTER_NODE_UP = 0xC0130012;
		/// <summary>The cluster node is paused.</summary>
		public const uint STATUS_CLUSTER_NODE_PAUSED = 0xC0130013;
		/// <summary>The cluster node is not paused.</summary>
		public const uint STATUS_CLUSTER_NODE_NOT_PAUSED = 0xC0130014;
		/// <summary>No cluster security context is available.</summary>
		public const uint STATUS_CLUSTER_NO_SECURITY_CONTEXT = 0xC0130015;
		/// <summary>The cluster network is not configured for internal cluster communication.</summary>
		public const uint STATUS_CLUSTER_NETWORK_NOT_INTERNAL = 0xC0130016;
		/// <summary>The cluster node has been poisoned.</summary>
		public const uint STATUS_CLUSTER_POISONED = 0xC0130017;
		/// <summary>An attempt was made to run an invalid AML opcode.</summary>
		public const uint STATUS_ACPI_INVALID_OPCODE = 0xC0140001;
		/// <summary>The AML interpreter stack has overflowed.</summary>
		public const uint STATUS_ACPI_STACK_OVERFLOW = 0xC0140002;
		/// <summary>An inconsistent state has occurred.</summary>
		public const uint STATUS_ACPI_ASSERT_FAILED = 0xC0140003;
		/// <summary>An attempt was made to access an array outside its bounds.</summary>
		public const uint STATUS_ACPI_INVALID_INDEX = 0xC0140004;
		/// <summary>A required argument was not specified.</summary>
		public const uint STATUS_ACPI_INVALID_ARGUMENT = 0xC0140005;
		/// <summary>A fatal error has occurred.</summary>
		public const uint STATUS_ACPI_FATAL = 0xC0140006;
		/// <summary>An invalid SuperName was specified.</summary>
		public const uint STATUS_ACPI_INVALID_SUPERNAME = 0xC0140007;
		/// <summary>An argument with an incorrect type was specified.</summary>
		public const uint STATUS_ACPI_INVALID_ARGTYPE = 0xC0140008;
		/// <summary>An object with an incorrect type was specified.</summary>
		public const uint STATUS_ACPI_INVALID_OBJTYPE = 0xC0140009;
		/// <summary>A target with an incorrect type was specified.</summary>
		public const uint STATUS_ACPI_INVALID_TARGETTYPE = 0xC014000A;
		/// <summary>An incorrect number of arguments was specified.</summary>
		public const uint STATUS_ACPI_INCORRECT_ARGUMENT_COUNT = 0xC014000B;
		/// <summary>An address failed to translate.</summary>
		public const uint STATUS_ACPI_ADDRESS_NOT_MAPPED = 0xC014000C;
		/// <summary>An incorrect event type was specified.</summary>
		public const uint STATUS_ACPI_INVALID_EVENTTYPE = 0xC014000D;
		/// <summary>A handler for the target already exists.</summary>
		public const uint STATUS_ACPI_HANDLER_COLLISION = 0xC014000E;
		/// <summary>Invalid data for the target was specified.</summary>
		public const uint STATUS_ACPI_INVALID_DATA = 0xC014000F;
		/// <summary>An invalid region for the target was specified.</summary>
		public const uint STATUS_ACPI_INVALID_REGION = 0xC0140010;
		/// <summary>An attempt was made to access a field outside the defined range.</summary>
		public const uint STATUS_ACPI_INVALID_ACCESS_SIZE = 0xC0140011;
		/// <summary>The global system lock could not be acquired.</summary>
		public const uint STATUS_ACPI_ACQUIRE_GLOBAL_LOCK = 0xC0140012;
		/// <summary>An attempt was made to reinitialize the ACPI subsystem.</summary>
		public const uint STATUS_ACPI_ALREADY_INITIALIZED = 0xC0140013;
		/// <summary>The ACPI subsystem has not been initialized.</summary>
		public const uint STATUS_ACPI_NOT_INITIALIZED = 0xC0140014;
		/// <summary>An incorrect mutex was specified.</summary>
		public const uint STATUS_ACPI_INVALID_MUTEX_LEVEL = 0xC0140015;
		/// <summary>The mutex is not currently owned.</summary>
		public const uint STATUS_ACPI_MUTEX_NOT_OWNED = 0xC0140016;
		/// <summary>An attempt was made to access the mutex by a process that was not the owner.</summary>
		public const uint STATUS_ACPI_MUTEX_NOT_OWNER = 0xC0140017;
		/// <summary>An error occurred during an access to region space.</summary>
		public const uint STATUS_ACPI_RS_ACCESS = 0xC0140018;
		/// <summary>An attempt was made to use an incorrect table.</summary>
		public const uint STATUS_ACPI_INVALID_TABLE = 0xC0140019;
		/// <summary>The registration of an ACPI event failed.</summary>
		public const uint STATUS_ACPI_REG_HANDLER_FAILED = 0xC0140020;
		/// <summary>An ACPI power object failed to transition state.</summary>
		public const uint STATUS_ACPI_POWER_REQUEST_FAILED = 0xC0140021;
		/// <summary>The requested section is not present in the activation context.</summary>
		public const uint STATUS_SXS_SECTION_NOT_FOUND = 0xC0150001;
		/// <summary>Windows was unble to process the application binding information. Refer to the system event log for further information.</summary>
		public const uint STATUS_SXS_CANT_GEN_ACTCTX = 0xC0150002;
		/// <summary>The application binding data format is invalid.</summary>
		public const uint STATUS_SXS_INVALID_ACTCTXDATA_FORMAT = 0xC0150003;
		/// <summary>The referenced assembly is not installed on the system.</summary>
		public const uint STATUS_SXS_ASSEMBLY_NOT_FOUND = 0xC0150004;
		/// <summary>The manifest file does not begin with the required tag and format information.</summary>
		public const uint STATUS_SXS_MANIFEST_FORMAT_ERROR = 0xC0150005;
		/// <summary>The manifest file contains one or more syntax errors.</summary>
		public const uint STATUS_SXS_MANIFEST_PARSE_ERROR = 0xC0150006;
		/// <summary>The application attempted to activate a disabled activation context.</summary>
		public const uint STATUS_SXS_ACTIVATION_CONTEXT_DISABLED = 0xC0150007;
		/// <summary>The requested lookup key was not found in any active activation context.</summary>
		public const uint STATUS_SXS_KEY_NOT_FOUND = 0xC0150008;
		/// <summary>A component version required by the application conflicts with another component version that is already active.</summary>
		public const uint STATUS_SXS_VERSION_CONFLICT = 0xC0150009;
		/// <summary>The type requested activation context section does not match the query API used.</summary>
		public const uint STATUS_SXS_WRONG_SECTION_TYPE = 0xC015000A;
		/// <summary>Lack of system resources has required isolated activation to be disabled for the current thread of execution.</summary>
		public const uint STATUS_SXS_THREAD_QUERIES_DISABLED = 0xC015000B;
		/// <summary>The referenced assembly could not be found.</summary>
		public const uint STATUS_SXS_ASSEMBLY_MISSING = 0xC015000C;
		/// <summary>An attempt to set the process default activation context failed because the process default activation context was already set.</summary>
		public const uint STATUS_SXS_PROCESS_DEFAULT_ALREADY_SET = 0xC015000E;
		/// <summary>The activation context being deactivated is not the most recently activated one.</summary>
		public const uint STATUS_SXS_EARLY_DEACTIVATION = 0xC015000F;
		/// <summary>The activation context being deactivated is not active for the current thread of execution.</summary>
		public const uint STATUS_SXS_INVALID_DEACTIVATION = 0xC0150010;
		/// <summary>The activation context being deactivated has already been deactivated.</summary>
		public const uint STATUS_SXS_MULTIPLE_DEACTIVATION = 0xC0150011;
		/// <summary>The activation context of the system default assembly could not be generated.</summary>
		public const uint STATUS_SXS_SYSTEM_DEFAULT_ACTIVATION_CONTEXT_EMPTY = 0xC0150012;
		/// <summary>A component used by the isolation facility has requested that the process be terminated.</summary>
		public const uint STATUS_SXS_PROCESS_TERMINATION_REQUESTED = 0xC0150013;
		/// <summary>The activation context activation stack for the running thread of execution is corrupt.</summary>
		public const uint STATUS_SXS_CORRUPT_ACTIVATION_STACK = 0xC0150014;
		/// <summary>The application isolation metadata for this process or thread has become corrupt.</summary>
		public const uint STATUS_SXS_CORRUPTION = 0xC0150015;
		/// <summary>The value of an attribute in an identity is not within the legal range.</summary>
		public const uint STATUS_SXS_INVALID_IDENTITY_ATTRIBUTE_VALUE = 0xC0150016;
		/// <summary>The name of an attribute in an identity is not within the legal range.</summary>
		public const uint STATUS_SXS_INVALID_IDENTITY_ATTRIBUTE_NAME = 0xC0150017;
		/// <summary>An identity contains two definitions for the same attribute.</summary>
		public const uint STATUS_SXS_IDENTITY_DUPLICATE_ATTRIBUTE = 0xC0150018;
		/// <summary>The identity string is malformed. This might be due to a trailing comma, more than two unnamed attributes, a missing attribute name, or a missing attribute value.</summary>
		public const uint STATUS_SXS_IDENTITY_PARSE_ERROR = 0xC0150019;
		/// <summary>The component store has become corrupted.</summary>
		public const uint STATUS_SXS_COMPONENT_STORE_CORRUPT = 0xC015001A;
		/// <summary>A component's file does not match the verification information present in the component manifest.</summary>
		public const uint STATUS_SXS_FILE_HASH_MISMATCH = 0xC015001B;
		/// <summary>The identities of the manifests are identical, but their contents are different.</summary>
		public const uint STATUS_SXS_MANIFEST_IDENTITY_SAME_BUT_CONTENTS_DIFFERENT = 0xC015001C;
		/// <summary>The component identities are different.</summary>
		public const uint STATUS_SXS_IDENTITIES_DIFFERENT = 0xC015001D;
		/// <summary>The assembly is not a deployment.</summary>
		public const uint STATUS_SXS_ASSEMBLY_IS_NOT_A_DEPLOYMENT = 0xC015001E;
		/// <summary>The file is not a part of the assembly.</summary>
		public const uint STATUS_SXS_FILE_NOT_PART_OF_ASSEMBLY = 0xC015001F;
		/// <summary>An advanced installer failed during setup or servicing.</summary>
		public const uint STATUS_ADVANCED_INSTALLER_FAILED = 0xC0150020;
		/// <summary>The character encoding in the XML declaration did not match the encoding used in the document.</summary>
		public const uint STATUS_XML_ENCODING_MISMATCH = 0xC0150021;
		/// <summary>The size of the manifest exceeds the maximum allowed.</summary>
		public const uint STATUS_SXS_MANIFEST_TOO_BIG = 0xC0150022;
		/// <summary>The setting is not registered.</summary>
		public const uint STATUS_SXS_SETTING_NOT_REGISTERED = 0xC0150023;
		/// <summary>One or more required transaction members are not present.</summary>
		public const uint STATUS_SXS_TRANSACTION_CLOSURE_INCOMPLETE = 0xC0150024;
		/// <summary>The SMI primitive installer failed during setup or servicing.</summary>
		public const uint STATUS_SMI_PRIMITIVE_INSTALLER_FAILED = 0xC0150025;
		/// <summary>A generic command executable returned a result that indicates failure.</summary>
		public const uint STATUS_GENERIC_COMMAND_FAILED = 0xC0150026;
		/// <summary>A component is missing file verification information in its manifest.</summary>
		public const uint STATUS_SXS_FILE_HASH_MISSING = 0xC0150027;
		/// <summary>The function attempted to use a name that is reserved for use by another transaction.</summary>
		public const uint STATUS_TRANSACTIONAL_CONFLICT = 0xC0190001;
		/// <summary>The transaction handle associated with this operation is invalid.</summary>
		public const uint STATUS_INVALID_TRANSACTION = 0xC0190002;
		/// <summary>The requested operation was made in the context of a transaction that is no longer active.</summary>
		public const uint STATUS_TRANSACTION_NOT_ACTIVE = 0xC0190003;
		/// <summary>The transaction manager was unable to be successfully initialized. Transacted operations are not supported.</summary>
		public const uint STATUS_TM_INITIALIZATION_FAILED = 0xC0190004;
		/// <summary>Transaction support within the specified file system resource manager was not started or was shut down due to an error.</summary>
		public const uint STATUS_RM_NOT_ACTIVE = 0xC0190005;
		/// <summary>The metadata of the resource manager has been corrupted. The resource manager will not function.</summary>
		public const uint STATUS_RM_METADATA_CORRUPT = 0xC0190006;
		/// <summary>The resource manager attempted to prepare a transaction that it has not successfully joined.</summary>
		public const uint STATUS_TRANSACTION_NOT_JOINED = 0xC0190007;
		/// <summary>The specified directory does not contain a file system resource manager.</summary>
		public const uint STATUS_DIRECTORY_NOT_RM = 0xC0190008;
		/// <summary>The remote server or share does not support transacted file operations.</summary>
		public const uint STATUS_TRANSACTIONS_UNSUPPORTED_REMOTE = 0xC019000A;
		/// <summary>The requested log size for the file system resource manager is invalid.</summary>
		public const uint STATUS_LOG_RESIZE_INVALID_SIZE = 0xC019000B;
		/// <summary>The remote server sent mismatching version number or Fid for a file opened with transactions.</summary>
		public const uint STATUS_REMOTE_FILE_VERSION_MISMATCH = 0xC019000C;
		/// <summary>The resource manager tried to register a protocol that already exists.</summary>
		public const uint STATUS_CRM_PROTOCOL_ALREADY_EXISTS = 0xC019000F;
		/// <summary>The attempt to propagate the transaction failed.</summary>
		public const uint STATUS_TRANSACTION_PROPAGATION_FAILED = 0xC0190010;
		/// <summary>The requested propagation protocol was not registered as a CRM.</summary>
		public const uint STATUS_CRM_PROTOCOL_NOT_FOUND = 0xC0190011;
		/// <summary>The transaction object already has a superior enlistment, and the caller attempted an operation that would have created a new superior. Only a single superior enlistment is allowed.</summary>
		public const uint STATUS_TRANSACTION_SUPERIOR_EXISTS = 0xC0190012;
		/// <summary>The requested operation is not valid on the transaction object in its current state.</summary>
		public const uint STATUS_TRANSACTION_REQUEST_NOT_VALID = 0xC0190013;
		/// <summary>The caller has called a response API, but the response is not expected because the transaction manager did not issue the corresponding request to the caller.</summary>
		public const uint STATUS_TRANSACTION_NOT_REQUESTED = 0xC0190014;
		/// <summary>It is too late to perform the requested operation, because the transaction has already been aborted.</summary>
		public const uint STATUS_TRANSACTION_ALREADY_ABORTED = 0xC0190015;
		/// <summary>It is too late to perform the requested operation, because the transaction has already been committed.</summary>
		public const uint STATUS_TRANSACTION_ALREADY_COMMITTED = 0xC0190016;
		/// <summary>The buffer passed in to NtPushTransaction or NtPullTransaction is not in a valid format.</summary>
		public const uint STATUS_TRANSACTION_INVALID_MARSHALL_BUFFER = 0xC0190017;
		/// <summary>The current transaction context associated with the thread is not a valid handle to a transaction object.</summary>
		public const uint STATUS_CURRENT_TRANSACTION_NOT_VALID = 0xC0190018;
		/// <summary>An attempt to create space in the transactional resource manager's log failed. The failure status has been recorded in the event log.</summary>
		public const uint STATUS_LOG_GROWTH_FAILED = 0xC0190019;
		/// <summary>The object (file, stream, or link) that corresponds to the handle has been deleted by a transaction savepoint rollback.</summary>
		public const uint STATUS_OBJECT_NO_LONGER_EXISTS = 0xC0190021;
		/// <summary>The specified file miniversion was not found for this transacted file open.</summary>
		public const uint STATUS_STREAM_MINIVERSION_NOT_FOUND = 0xC0190022;
		/// <summary>The specified file miniversion was found but has been invalidated. The most likely cause is a transaction savepoint rollback.</summary>
		public const uint STATUS_STREAM_MINIVERSION_NOT_VALID = 0xC0190023;
		/// <summary>A miniversion can be opened only in the context of the transaction that created it.</summary>
		public const uint STATUS_MINIVERSION_INACCESSIBLE_FROM_SPECIFIED_TRANSACTION = 0xC0190024;
		/// <summary>It is not possible to open a miniversion with modify access.</summary>
		public const uint STATUS_CANT_OPEN_MINIVERSION_WITH_MODIFY_INTENT = 0xC0190025;
		/// <summary>It is not possible to create any more miniversions for this stream.</summary>
		public const uint STATUS_CANT_CREATE_MORE_STREAM_MINIVERSIONS = 0xC0190026;
		/// <summary>The handle has been invalidated by a transaction. The most likely cause is the presence of memory mapping on a file or an open handle when the transaction ended or rolled back to savepoint.</summary>
		public const uint STATUS_HANDLE_NO_LONGER_VALID = 0xC0190028;
		/// <summary>The log data is corrupt.</summary>
		public const uint STATUS_LOG_CORRUPTION_DETECTED = 0xC0190030;
		/// <summary>The transaction outcome is unavailable because the resource manager responsible for it is disconnected.</summary>
		public const uint STATUS_RM_DISCONNECTED = 0xC0190032;
		/// <summary>The request was rejected because the enlistment in question is not a superior enlistment.</summary>
		public const uint STATUS_ENLISTMENT_NOT_SUPERIOR = 0xC0190033;
		/// <summary>The file cannot be opened in a transaction because its identity depends on the outcome of an unresolved transaction.</summary>
		public const uint STATUS_FILE_IDENTITY_NOT_PERSISTENT = 0xC0190036;
		/// <summary>The operation cannot be performed because another transaction is depending on this property not changing.</summary>
		public const uint STATUS_CANT_BREAK_TRANSACTIONAL_DEPENDENCY = 0xC0190037;
		/// <summary>The operation would involve a single file with two transactional resource managers and is, therefore, not allowed.</summary>
		public const uint STATUS_CANT_CROSS_RM_BOUNDARY = 0xC0190038;
		/// <summary>The $Txf directory must be empty for this operation to succeed.</summary>
		public const uint STATUS_TXF_DIR_NOT_EMPTY = 0xC0190039;
		/// <summary>The operation would leave a transactional resource manager in an inconsistent state and is therefore not allowed.</summary>
		public const uint STATUS_INDOUBT_TRANSACTIONS_EXIST = 0xC019003A;
		/// <summary>The operation could not be completed because the transaction manager does not have a log.</summary>
		public const uint STATUS_TM_VOLATILE = 0xC019003B;
		/// <summary>A rollback could not be scheduled because a previously scheduled rollback has already executed or been queued for execution.</summary>
		public const uint STATUS_ROLLBACK_TIMER_EXPIRED = 0xC019003C;
		/// <summary>The transactional metadata attribute on the file or directory %hs is corrupt and unreadable.</summary>
		public const uint STATUS_TXF_ATTRIBUTE_CORRUPT = 0xC019003D;
		/// <summary>The encryption operation could not be completed because a transaction is active.</summary>
		public const uint STATUS_EFS_NOT_ALLOWED_IN_TRANSACTION = 0xC019003E;
		/// <summary>This object is not allowed to be opened in a transaction.</summary>
		public const uint STATUS_TRANSACTIONAL_OPEN_NOT_ALLOWED = 0xC019003F;
		/// <summary>Memory mapping (creating a mapped section) a remote file under a transaction is not supported.</summary>
		public const uint STATUS_TRANSACTED_MAPPING_UNSUPPORTED_REMOTE = 0xC0190040;
		/// <summary>Promotion was required to allow the resource manager to enlist, but the transaction was set to disallow it.</summary>
		public const uint STATUS_TRANSACTION_REQUIRED_PROMOTION = 0xC0190043;
		/// <summary>This file is open for modification in an unresolved transaction and can be opened for execute only by a transacted reader.</summary>
		public const uint STATUS_CANNOT_EXECUTE_FILE_IN_TRANSACTION = 0xC0190044;
		/// <summary>The request to thaw frozen transactions was ignored because transactions were not previously frozen.</summary>
		public const uint STATUS_TRANSACTIONS_NOT_FROZEN = 0xC0190045;
		/// <summary>Transactions cannot be frozen because a freeze is already in progress.</summary>
		public const uint STATUS_TRANSACTION_FREEZE_IN_PROGRESS = 0xC0190046;
		/// <summary>The target volume is not a snapshot volume. This operation is valid only on a volume mounted as a snapshot.</summary>
		public const uint STATUS_NOT_SNAPSHOT_VOLUME = 0xC0190047;
		/// <summary>The savepoint operation failed because files are open on the transaction, which is not permitted.</summary>
		public const uint STATUS_NO_SAVEPOINT_WITH_OPEN_FILES = 0xC0190048;
		/// <summary>The sparse operation could not be completed because a transaction is active on the file.</summary>
		public const uint STATUS_SPARSE_NOT_ALLOWED_IN_TRANSACTION = 0xC0190049;
		/// <summary>The call to create a transaction manager object failed because the Tm Identity that is stored in the log file does not match the Tm Identity that was passed in as an argument.</summary>
		public const uint STATUS_TM_IDENTITY_MISMATCH = 0xC019004A;
		/// <summary>I/O was attempted on a section object that has been floated as a result of a transaction ending. There is no valid data.</summary>
		public const uint STATUS_FLOATED_SECTION = 0xC019004B;
		/// <summary>The transactional resource manager cannot currently accept transacted work due to a transient condition, such as low resources.</summary>
		public const uint STATUS_CANNOT_ACCEPT_TRANSACTED_WORK = 0xC019004C;
		/// <summary>The transactional resource manager had too many transactions outstanding that could not be aborted. The transactional resource manager has been shut down.</summary>
		public const uint STATUS_CANNOT_ABORT_TRANSACTIONS = 0xC019004D;
		/// <summary>The specified transaction was unable to be opened because it was not found.</summary>
		public const uint STATUS_TRANSACTION_NOT_FOUND = 0xC019004E;
		/// <summary>The specified resource manager was unable to be opened because it was not found.</summary>
		public const uint STATUS_RESOURCEMANAGER_NOT_FOUND = 0xC019004F;
		/// <summary>The specified enlistment was unable to be opened because it was not found.</summary>
		public const uint STATUS_ENLISTMENT_NOT_FOUND = 0xC0190050;
		/// <summary>The specified transaction manager was unable to be opened because it was not found.</summary>
		public const uint STATUS_TRANSACTIONMANAGER_NOT_FOUND = 0xC0190051;
		/// <summary>The specified resource manager was unable to create an enlistment because its associated transaction manager is not online.</summary>
		public const uint STATUS_TRANSACTIONMANAGER_NOT_ONLINE = 0xC0190052;
		/// <summary>The specified transaction manager was unable to create the objects contained in its log file in the Ob namespace. Therefore, the transaction manager was unable to recover.</summary>
		public const uint STATUS_TRANSACTIONMANAGER_RECOVERY_NAME_COLLISION = 0xC0190053;
		/// <summary>The call to create a superior enlistment on this transaction object could not be completed because the transaction object specified for the enlistment is a subordinate branch of the transaction. Only the root of the transaction can be enlisted as a superior.</summary>
		public const uint STATUS_TRANSACTION_NOT_ROOT = 0xC0190054;
		/// <summary>Because the associated transaction manager or resource manager has been closed, the handle is no longer valid.</summary>
		public const uint STATUS_TRANSACTION_OBJECT_EXPIRED = 0xC0190055;
		/// <summary>The compression operation could not be completed because a transaction is active on the file.</summary>
		public const uint STATUS_COMPRESSION_NOT_ALLOWED_IN_TRANSACTION = 0xC0190056;
		/// <summary>The specified operation could not be performed on this superior enlistment because the enlistment was not created with the corresponding completion response in the NotificationMask.</summary>
		public const uint STATUS_TRANSACTION_RESPONSE_NOT_ENLISTED = 0xC0190057;
		/// <summary>The specified operation could not be performed because the record to be logged was too long. This can occur because either there are too many enlistments on this transaction or the combined RecoveryInformation being logged on behalf of those enlistments is too long.</summary>
		public const uint STATUS_TRANSACTION_RECORD_TOO_LONG = 0xC0190058;
		/// <summary>The link-tracking operation could not be completed because a transaction is active.</summary>
		public const uint STATUS_NO_LINK_TRACKING_IN_TRANSACTION = 0xC0190059;
		/// <summary>This operation cannot be performed in a transaction.</summary>
		public const uint STATUS_OPERATION_NOT_SUPPORTED_IN_TRANSACTION = 0xC019005A;
		/// <summary>The kernel transaction manager had to abort or forget the transaction because it blocked forward progress.</summary>
		public const uint STATUS_TRANSACTION_INTEGRITY_VIOLATED = 0xC019005B;
		/// <summary>The handle is no longer properly associated with its transaction.  It might have been opened in a transactional resource manager that was subsequently forced to restart.  Please close the handle and open a new one.</summary>
		public const uint STATUS_EXPIRED_HANDLE = 0xC0190060;
		/// <summary>The specified operation could not be performed because the resource manager is not enlisted in the transaction.</summary>
		public const uint STATUS_TRANSACTION_NOT_ENLISTED = 0xC0190061;
		/// <summary>The log service found an invalid log sector.</summary>
		public const uint STATUS_LOG_SECTOR_INVALID = 0xC01A0001;
		/// <summary>The log service encountered a log sector with invalid block parity.</summary>
		public const uint STATUS_LOG_SECTOR_PARITY_INVALID = 0xC01A0002;
		/// <summary>The log service encountered a remapped log sector.</summary>
		public const uint STATUS_LOG_SECTOR_REMAPPED = 0xC01A0003;
		/// <summary>The log service encountered a partial or incomplete log block.</summary>
		public const uint STATUS_LOG_BLOCK_INCOMPLETE = 0xC01A0004;
		/// <summary>The log service encountered an attempt to access data outside the active log range.</summary>
		public const uint STATUS_LOG_INVALID_RANGE = 0xC01A0005;
		/// <summary>The log service user-log marshaling buffers are exhausted.</summary>
		public const uint STATUS_LOG_BLOCKS_EXHAUSTED = 0xC01A0006;
		/// <summary>The log service encountered an attempt to read from a marshaling area with an invalid read context.</summary>
		public const uint STATUS_LOG_READ_CONTEXT_INVALID = 0xC01A0007;
		/// <summary>The log service encountered an invalid log restart area.</summary>
		public const uint STATUS_LOG_RESTART_INVALID = 0xC01A0008;
		/// <summary>The log service encountered an invalid log block version.</summary>
		public const uint STATUS_LOG_BLOCK_VERSION = 0xC01A0009;
		/// <summary>The log service encountered an invalid log block.</summary>
		public const uint STATUS_LOG_BLOCK_INVALID = 0xC01A000A;
		/// <summary>The log service encountered an attempt to read the log with an invalid read mode.</summary>
		public const uint STATUS_LOG_READ_MODE_INVALID = 0xC01A000B;
		/// <summary>The log service encountered a corrupted metadata file.</summary>
		public const uint STATUS_LOG_METADATA_CORRUPT = 0xC01A000D;
		/// <summary>The log service encountered a metadata file that could not be created by the log file system.</summary>
		public const uint STATUS_LOG_METADATA_INVALID = 0xC01A000E;
		/// <summary>The log service encountered a metadata file with inconsistent data.</summary>
		public const uint STATUS_LOG_METADATA_INCONSISTENT = 0xC01A000F;
		/// <summary>The log service encountered an attempt to erroneously allocate or dispose reservation space.</summary>
		public const uint STATUS_LOG_RESERVATION_INVALID = 0xC01A0010;
		/// <summary>The log service cannot delete the log file or the file system container.</summary>
		public const uint STATUS_LOG_CANT_DELETE = 0xC01A0011;
		/// <summary>The log service has reached the maximum allowable containers allocated to a log file.</summary>
		public const uint STATUS_LOG_CONTAINER_LIMIT_EXCEEDED = 0xC01A0012;
		/// <summary>The log service has attempted to read or write backward past the start of the log.</summary>
		public const uint STATUS_LOG_START_OF_LOG = 0xC01A0013;
		/// <summary>The log policy could not be installed because a policy of the same type is already present.</summary>
		public const uint STATUS_LOG_POLICY_ALREADY_INSTALLED = 0xC01A0014;
		/// <summary>The log policy in question was not installed at the time of the request.</summary>
		public const uint STATUS_LOG_POLICY_NOT_INSTALLED = 0xC01A0015;
		/// <summary>The installed set of policies on the log is invalid.</summary>
		public const uint STATUS_LOG_POLICY_INVALID = 0xC01A0016;
		/// <summary>A policy on the log in question prevented the operation from completing.</summary>
		public const uint STATUS_LOG_POLICY_CONFLICT = 0xC01A0017;
		/// <summary>The log space cannot be reclaimed because the log is pinned by the archive tail.</summary>
		public const uint STATUS_LOG_PINNED_ARCHIVE_TAIL = 0xC01A0018;
		/// <summary>The log record is not a record in the log file.</summary>
		public const uint STATUS_LOG_RECORD_NONEXISTENT = 0xC01A0019;
		/// <summary>The number of reserved log records or the adjustment of the number of reserved log records is invalid.</summary>
		public const uint STATUS_LOG_RECORDS_RESERVED_INVALID = 0xC01A001A;
		/// <summary>The reserved log space or the adjustment of the log space is invalid.</summary>
		public const uint STATUS_LOG_SPACE_RESERVED_INVALID = 0xC01A001B;
		/// <summary>A new or existing archive tail or the base of the active log is invalid.</summary>
		public const uint STATUS_LOG_TAIL_INVALID = 0xC01A001C;
		/// <summary>The log space is exhausted.</summary>
		public const uint STATUS_LOG_FULL = 0xC01A001D;
		/// <summary>The log is multiplexed; no direct writes to the physical log are allowed.</summary>
		public const uint STATUS_LOG_MULTIPLEXED = 0xC01A001E;
		/// <summary>The operation failed because the log is dedicated.</summary>
		public const uint STATUS_LOG_DEDICATED = 0xC01A001F;
		/// <summary>The operation requires an archive context.</summary>
		public const uint STATUS_LOG_ARCHIVE_NOT_IN_PROGRESS = 0xC01A0020;
		/// <summary>Log archival is in progress.</summary>
		public const uint STATUS_LOG_ARCHIVE_IN_PROGRESS = 0xC01A0021;
		/// <summary>The operation requires a nonephemeral log, but the log is ephemeral.</summary>
		public const uint STATUS_LOG_EPHEMERAL = 0xC01A0022;
		/// <summary>The log must have at least two containers before it can be read from or written to.</summary>
		public const uint STATUS_LOG_NOT_ENOUGH_CONTAINERS = 0xC01A0023;
		/// <summary>A log client has already registered on the stream.</summary>
		public const uint STATUS_LOG_CLIENT_ALREADY_REGISTERED = 0xC01A0024;
		/// <summary>A log client has not been registered on the stream.</summary>
		public const uint STATUS_LOG_CLIENT_NOT_REGISTERED = 0xC01A0025;
		/// <summary>A request has already been made to handle the log full condition.</summary>
		public const uint STATUS_LOG_FULL_HANDLER_IN_PROGRESS = 0xC01A0026;
		/// <summary>The log service encountered an error when attempting to read from a log container.</summary>
		public const uint STATUS_LOG_CONTAINER_READ_FAILED = 0xC01A0027;
		/// <summary>The log service encountered an error when attempting to write to a log container.</summary>
		public const uint STATUS_LOG_CONTAINER_WRITE_FAILED = 0xC01A0028;
		/// <summary>The log service encountered an error when attempting to open a log container.</summary>
		public const uint STATUS_LOG_CONTAINER_OPEN_FAILED = 0xC01A0029;
		/// <summary>The log service encountered an invalid container state when attempting a requested action.</summary>
		public const uint STATUS_LOG_CONTAINER_STATE_INVALID = 0xC01A002A;
		/// <summary>The log service is not in the correct state to perform a requested action.</summary>
		public const uint STATUS_LOG_STATE_INVALID = 0xC01A002B;
		/// <summary>The log space cannot be reclaimed because the log is pinned.</summary>
		public const uint STATUS_LOG_PINNED = 0xC01A002C;
		/// <summary>The log metadata flush failed.</summary>
		public const uint STATUS_LOG_METADATA_FLUSH_FAILED = 0xC01A002D;
		/// <summary>Security on the log and its containers is inconsistent.</summary>
		public const uint STATUS_LOG_INCONSISTENT_SECURITY = 0xC01A002E;
		/// <summary>Records were appended to the log or reservation changes were made, but the log could not be flushed.</summary>
		public const uint STATUS_LOG_APPENDED_FLUSH_FAILED = 0xC01A002F;
		/// <summary>The log is pinned due to reservation consuming most of the log space. Free some reserved records to make space available.</summary>
		public const uint STATUS_LOG_PINNED_RESERVATION = 0xC01A0030;
		/// <summary>{Display Driver Stopped Responding} The %hs display driver has stopped working normally. Save your work and reboot the system to restore full display functionality. The next time you reboot the computer, a dialog box will allow you to upload data about this failure to Microsoft.</summary>
		public const uint STATUS_VIDEO_HUNG_DISPLAY_DRIVER_THREAD = 0xC01B00EA;
		/// <summary>A handler was not defined by the filter for this operation.</summary>
		public const uint STATUS_FLT_NO_HANDLER_DEFINED = 0xC01C0001;
		/// <summary>A context is already defined for this object.</summary>
		public const uint STATUS_FLT_CONTEXT_ALREADY_DEFINED = 0xC01C0002;
		/// <summary>Asynchronous requests are not valid for this operation.</summary>
		public const uint STATUS_FLT_INVALID_ASYNCHRONOUS_REQUEST = 0xC01C0003;
		/// <summary>This is an internal error code used by the filter manager to determine if a fast I/O operation should be forced down the input/output request packet (IRP) path. Minifilters should never return this value.</summary>
		public const uint STATUS_FLT_DISALLOW_FAST_IO = 0xC01C0004;
		/// <summary>An invalid name request was made. The name requested cannot be retrieved at this time.</summary>
		public const uint STATUS_FLT_INVALID_NAME_REQUEST = 0xC01C0005;
		/// <summary>Posting this operation to a worker thread for further processing is not safe at this time because it could lead to a system deadlock.</summary>
		public const uint STATUS_FLT_NOT_SAFE_TO_POST_OPERATION = 0xC01C0006;
		/// <summary>The Filter Manager was not initialized when a filter tried to register. Make sure that the Filter Manager is loaded as a driver.</summary>
		public const uint STATUS_FLT_NOT_INITIALIZED = 0xC01C0007;
		/// <summary>The filter is not ready for attachment to volumes because it has not finished initializing (FltStartFiltering has not been called).</summary>
		public const uint STATUS_FLT_FILTER_NOT_READY = 0xC01C0008;
		/// <summary>The filter must clean up any operation-specific context at this time because it is being removed from the system before the operation is completed by the lower drivers.</summary>
		public const uint STATUS_FLT_POST_OPERATION_CLEANUP = 0xC01C0009;
		/// <summary>The Filter Manager had an internal error from which it cannot recover; therefore, the operation has failed. This is usually the result of a filter returning an invalid value from a pre-operation callback.</summary>
		public const uint STATUS_FLT_INTERNAL_ERROR = 0xC01C000A;
		/// <summary>The object specified for this action is in the process of being deleted; therefore, the action requested cannot be completed at this time.</summary>
		public const uint STATUS_FLT_DELETING_OBJECT = 0xC01C000B;
		/// <summary>A nonpaged pool must be used for this type of context.</summary>
		public const uint STATUS_FLT_MUST_BE_NONPAGED_POOL = 0xC01C000C;
		/// <summary>A duplicate handler definition has been provided for an operation.</summary>
		public const uint STATUS_FLT_DUPLICATE_ENTRY = 0xC01C000D;
		/// <summary>The callback data queue has been disabled.</summary>
		public const uint STATUS_FLT_CBDQ_DISABLED = 0xC01C000E;
		/// <summary>Do not attach the filter to the volume at this time.</summary>
		public const uint STATUS_FLT_DO_NOT_ATTACH = 0xC01C000F;
		/// <summary>Do not detach the filter from the volume at this time.</summary>
		public const uint STATUS_FLT_DO_NOT_DETACH = 0xC01C0010;
		/// <summary>An instance already exists at this altitude on the volume specified.</summary>
		public const uint STATUS_FLT_INSTANCE_ALTITUDE_COLLISION = 0xC01C0011;
		/// <summary>An instance already exists with this name on the volume specified.</summary>
		public const uint STATUS_FLT_INSTANCE_NAME_COLLISION = 0xC01C0012;
		/// <summary>The system could not find the filter specified.</summary>
		public const uint STATUS_FLT_FILTER_NOT_FOUND = 0xC01C0013;
		/// <summary>The system could not find the volume specified.</summary>
		public const uint STATUS_FLT_VOLUME_NOT_FOUND = 0xC01C0014;
		/// <summary>The system could not find the instance specified.</summary>
		public const uint STATUS_FLT_INSTANCE_NOT_FOUND = 0xC01C0015;
		/// <summary>No registered context allocation definition was found for the given request.</summary>
		public const uint STATUS_FLT_CONTEXT_ALLOCATION_NOT_FOUND = 0xC01C0016;
		/// <summary>An invalid parameter was specified during context registration.</summary>
		public const uint STATUS_FLT_INVALID_CONTEXT_REGISTRATION = 0xC01C0017;
		/// <summary>The name requested was not found in the Filter Manager name cache and could not be retrieved from the file system.</summary>
		public const uint STATUS_FLT_NAME_CACHE_MISS = 0xC01C0018;
		/// <summary>The requested device object does not exist for the given volume.</summary>
		public const uint STATUS_FLT_NO_DEVICE_OBJECT = 0xC01C0019;
		/// <summary>The specified volume is already mounted.</summary>
		public const uint STATUS_FLT_VOLUME_ALREADY_MOUNTED = 0xC01C001A;
		/// <summary>The specified transaction context is already enlisted in a transaction.</summary>
		public const uint STATUS_FLT_ALREADY_ENLISTED = 0xC01C001B;
		/// <summary>The specified context is already attached to another object.</summary>
		public const uint STATUS_FLT_CONTEXT_ALREADY_LINKED = 0xC01C001C;
		/// <summary>No waiter is present for the filter's reply to this message.</summary>
		public const uint STATUS_FLT_NO_WAITER_FOR_REPLY = 0xC01C0020;
		/// <summary>A monitor descriptor could not be obtained.</summary>
		public const uint STATUS_MONITOR_NO_DESCRIPTOR = 0xC01D0001;
		/// <summary>This release does not support the format of the obtained monitor descriptor.</summary>
		public const uint STATUS_MONITOR_UNKNOWN_DESCRIPTOR_FORMAT = 0xC01D0002;
		/// <summary>The checksum of the obtained monitor descriptor is invalid.</summary>
		public const uint STATUS_MONITOR_INVALID_DESCRIPTOR_CHECKSUM = 0xC01D0003;
		/// <summary>The monitor descriptor contains an invalid standard timing block.</summary>
		public const uint STATUS_MONITOR_INVALID_STANDARD_TIMING_BLOCK = 0xC01D0004;
		/// <summary>WMI data-block registration failed for one of the MSMonitorClass WMI subclasses.</summary>
		public const uint STATUS_MONITOR_WMI_DATABLOCK_REGISTRATION_FAILED = 0xC01D0005;
		/// <summary>The provided monitor descriptor block is either corrupted or does not contain the monitor's detailed serial number.</summary>
		public const uint STATUS_MONITOR_INVALID_SERIAL_NUMBER_MONDSC_BLOCK = 0xC01D0006;
		/// <summary>The provided monitor descriptor block is either corrupted or does not contain the monitor's user-friendly name.</summary>
		public const uint STATUS_MONITOR_INVALID_USER_FRIENDLY_MONDSC_BLOCK = 0xC01D0007;
		/// <summary>There is no monitor descriptor data at the specified (offset or size) region.</summary>
		public const uint STATUS_MONITOR_NO_MORE_DESCRIPTOR_DATA = 0xC01D0008;
		/// <summary>The monitor descriptor contains an invalid detailed timing block.</summary>
		public const uint STATUS_MONITOR_INVALID_DETAILED_TIMING_BLOCK = 0xC01D0009;
		/// <summary>Monitor descriptor contains invalid manufacture date.</summary>
		public const uint STATUS_MONITOR_INVALID_MANUFACTURE_DATE = 0xC01D000A;
		/// <summary>Exclusive mode ownership is needed to create an unmanaged primary allocation.</summary>
		public const uint STATUS_GRAPHICS_NOT_EXCLUSIVE_MODE_OWNER = 0xC01E0000;
		/// <summary>The driver needs more DMA buffer space to complete the requested operation.</summary>
		public const uint STATUS_GRAPHICS_INSUFFICIENT_DMA_BUFFER = 0xC01E0001;
		/// <summary>The specified display adapter handle is invalid.</summary>
		public const uint STATUS_GRAPHICS_INVALID_DISPLAY_ADAPTER = 0xC01E0002;
		/// <summary>The specified display adapter and all of its state have been reset.</summary>
		public const uint STATUS_GRAPHICS_ADAPTER_WAS_RESET = 0xC01E0003;
		/// <summary>The driver stack does not match the expected driver model.</summary>
		public const uint STATUS_GRAPHICS_INVALID_DRIVER_MODEL = 0xC01E0004;
		/// <summary>Present happened but ended up into the changed desktop mode.</summary>
		public const uint STATUS_GRAPHICS_PRESENT_MODE_CHANGED = 0xC01E0005;
		/// <summary>Nothing to present due to desktop occlusion.</summary>
		public const uint STATUS_GRAPHICS_PRESENT_OCCLUDED = 0xC01E0006;
		/// <summary>Not able to present due to denial of desktop access.</summary>
		public const uint STATUS_GRAPHICS_PRESENT_DENIED = 0xC01E0007;
		/// <summary>Not able to present with color conversion.</summary>
		public const uint STATUS_GRAPHICS_CANNOTCOLORCONVERT = 0xC01E0008;
		/// <summary>Present redirection is disabled (desktop windowing management subsystem is off).</summary>
		public const uint STATUS_GRAPHICS_PRESENT_REDIRECTION_DISABLED = 0xC01E000B;
		/// <summary>Previous exclusive VidPn source owner has released its ownership</summary>
		public const uint STATUS_GRAPHICS_PRESENT_UNOCCLUDED = 0xC01E000C;
		/// <summary>Not enough video memory is available to complete the operation.</summary>
		public const uint STATUS_GRAPHICS_NO_VIDEO_MEMORY = 0xC01E0100;
		/// <summary>Could not probe and lock the underlying memory of an allocation.</summary>
		public const uint STATUS_GRAPHICS_CANT_LOCK_MEMORY = 0xC01E0101;
		/// <summary>The allocation is currently busy.</summary>
		public const uint STATUS_GRAPHICS_ALLOCATION_BUSY = 0xC01E0102;
		/// <summary>An object being referenced has already reached the maximum reference count and cannot be referenced further.</summary>
		public const uint STATUS_GRAPHICS_TOO_MANY_REFERENCES = 0xC01E0103;
		/// <summary>A problem could not be solved due to an existing condition. Try again later.</summary>
		public const uint STATUS_GRAPHICS_TRY_AGAIN_LATER = 0xC01E0104;
		/// <summary>A problem could not be solved due to an existing condition. Try again now.</summary>
		public const uint STATUS_GRAPHICS_TRY_AGAIN_NOW = 0xC01E0105;
		/// <summary>The allocation is invalid.</summary>
		public const uint STATUS_GRAPHICS_ALLOCATION_INVALID = 0xC01E0106;
		/// <summary>No more unswizzling apertures are currently available.</summary>
		public const uint STATUS_GRAPHICS_UNSWIZZLING_APERTURE_UNAVAILABLE = 0xC01E0107;
		/// <summary>The current allocation cannot be unswizzled by an aperture.</summary>
		public const uint STATUS_GRAPHICS_UNSWIZZLING_APERTURE_UNSUPPORTED = 0xC01E0108;
		/// <summary>The request failed because a pinned allocation cannot be evicted.</summary>
		public const uint STATUS_GRAPHICS_CANT_EVICT_PINNED_ALLOCATION = 0xC01E0109;
		/// <summary>The allocation cannot be used from its current segment location for the specified operation.</summary>
		public const uint STATUS_GRAPHICS_INVALID_ALLOCATION_USAGE = 0xC01E0110;
		/// <summary>A locked allocation cannot be used in the current command buffer.</summary>
		public const uint STATUS_GRAPHICS_CANT_RENDER_LOCKED_ALLOCATION = 0xC01E0111;
		/// <summary>The allocation being referenced has been closed permanently.</summary>
		public const uint STATUS_GRAPHICS_ALLOCATION_CLOSED = 0xC01E0112;
		/// <summary>An invalid allocation instance is being referenced.</summary>
		public const uint STATUS_GRAPHICS_INVALID_ALLOCATION_INSTANCE = 0xC01E0113;
		/// <summary>An invalid allocation handle is being referenced.</summary>
		public const uint STATUS_GRAPHICS_INVALID_ALLOCATION_HANDLE = 0xC01E0114;
		/// <summary>The allocation being referenced does not belong to the current device.</summary>
		public const uint STATUS_GRAPHICS_WRONG_ALLOCATION_DEVICE = 0xC01E0115;
		/// <summary>The specified allocation lost its content.</summary>
		public const uint STATUS_GRAPHICS_ALLOCATION_CONTENT_LOST = 0xC01E0116;
		/// <summary>A GPU exception was detected on the given device. The device cannot be scheduled.</summary>
		public const uint STATUS_GRAPHICS_GPU_EXCEPTION_ON_DEVICE = 0xC01E0200;
		/// <summary>The specified VidPN topology is invalid.</summary>
		public const uint STATUS_GRAPHICS_INVALID_VIDPN_TOPOLOGY = 0xC01E0300;
		/// <summary>The specified VidPN topology is valid but is not supported by this model of the display adapter.</summary>
		public const uint STATUS_GRAPHICS_VIDPN_TOPOLOGY_NOT_SUPPORTED = 0xC01E0301;
		/// <summary>The specified VidPN topology is valid but is not currently supported by the display adapter due to allocation of its resources.</summary>
		public const uint STATUS_GRAPHICS_VIDPN_TOPOLOGY_CURRENTLY_NOT_SUPPORTED = 0xC01E0302;
		/// <summary>The specified VidPN handle is invalid.</summary>
		public const uint STATUS_GRAPHICS_INVALID_VIDPN = 0xC01E0303;
		/// <summary>The specified video present source is invalid.</summary>
		public const uint STATUS_GRAPHICS_INVALID_VIDEO_PRESENT_SOURCE = 0xC01E0304;
		/// <summary>The specified video present target is invalid.</summary>
		public const uint STATUS_GRAPHICS_INVALID_VIDEO_PRESENT_TARGET = 0xC01E0305;
		/// <summary>The specified VidPN modality is not supported (for example, at least two of the pinned modes are not co-functional).</summary>
		public const uint STATUS_GRAPHICS_VIDPN_MODALITY_NOT_SUPPORTED = 0xC01E0306;
		/// <summary>The specified VidPN source mode set is invalid.</summary>
		public const uint STATUS_GRAPHICS_INVALID_VIDPN_SOURCEMODESET = 0xC01E0308;
		/// <summary>The specified VidPN target mode set is invalid.</summary>
		public const uint STATUS_GRAPHICS_INVALID_VIDPN_TARGETMODESET = 0xC01E0309;
		/// <summary>The specified video signal frequency is invalid.</summary>
		public const uint STATUS_GRAPHICS_INVALID_FREQUENCY = 0xC01E030A;
		/// <summary>The specified video signal active region is invalid.</summary>
		public const uint STATUS_GRAPHICS_INVALID_ACTIVE_REGION = 0xC01E030B;
		/// <summary>The specified video signal total region is invalid.</summary>
		public const uint STATUS_GRAPHICS_INVALID_TOTAL_REGION = 0xC01E030C;
		/// <summary>The specified video present source mode is invalid.</summary>
		public const uint STATUS_GRAPHICS_INVALID_VIDEO_PRESENT_SOURCE_MODE = 0xC01E0310;
		/// <summary>The specified video present target mode is invalid.</summary>
		public const uint STATUS_GRAPHICS_INVALID_VIDEO_PRESENT_TARGET_MODE = 0xC01E0311;
		/// <summary>The pinned mode must remain in the set on the VidPN's co-functional modality enumeration.</summary>
		public const uint STATUS_GRAPHICS_PINNED_MODE_MUST_REMAIN_IN_SET = 0xC01E0312;
		/// <summary>The specified video present path is already in the VidPN's topology.</summary>
		public const uint STATUS_GRAPHICS_PATH_ALREADY_IN_TOPOLOGY = 0xC01E0313;
		/// <summary>The specified mode is already in the mode set.</summary>
		public const uint STATUS_GRAPHICS_MODE_ALREADY_IN_MODESET = 0xC01E0314;
		/// <summary>The specified video present source set is invalid.</summary>
		public const uint STATUS_GRAPHICS_INVALID_VIDEOPRESENTSOURCESET = 0xC01E0315;
		/// <summary>The specified video present target set is invalid.</summary>
		public const uint STATUS_GRAPHICS_INVALID_VIDEOPRESENTTARGETSET = 0xC01E0316;
		/// <summary>The specified video present source is already in the video present source set.</summary>
		public const uint STATUS_GRAPHICS_SOURCE_ALREADY_IN_SET = 0xC01E0317;
		/// <summary>The specified video present target is already in the video present target set.</summary>
		public const uint STATUS_GRAPHICS_TARGET_ALREADY_IN_SET = 0xC01E0318;
		/// <summary>The specified VidPN present path is invalid.</summary>
		public const uint STATUS_GRAPHICS_INVALID_VIDPN_PRESENT_PATH = 0xC01E0319;
		/// <summary>The miniport has no recommendation for augmenting the specified VidPN's topology.</summary>
		public const uint STATUS_GRAPHICS_NO_RECOMMENDED_VIDPN_TOPOLOGY = 0xC01E031A;
		/// <summary>The specified monitor frequency range set is invalid.</summary>
		public const uint STATUS_GRAPHICS_INVALID_MONITOR_FREQUENCYRANGESET = 0xC01E031B;
		/// <summary>The specified monitor frequency range is invalid.</summary>
		public const uint STATUS_GRAPHICS_INVALID_MONITOR_FREQUENCYRANGE = 0xC01E031C;
		/// <summary>The specified frequency range is not in the specified monitor frequency range set.</summary>
		public const uint STATUS_GRAPHICS_FREQUENCYRANGE_NOT_IN_SET = 0xC01E031D;
		/// <summary>The specified frequency range is already in the specified monitor frequency range set.</summary>
		public const uint STATUS_GRAPHICS_FREQUENCYRANGE_ALREADY_IN_SET = 0xC01E031F;
		/// <summary>The specified mode set is stale. Reacquire the new mode set.</summary>
		public const uint STATUS_GRAPHICS_STALE_MODESET = 0xC01E0320;
		/// <summary>The specified monitor source mode set is invalid.</summary>
		public const uint STATUS_GRAPHICS_INVALID_MONITOR_SOURCEMODESET = 0xC01E0321;
		/// <summary>The specified monitor source mode is invalid.</summary>
		public const uint STATUS_GRAPHICS_INVALID_MONITOR_SOURCE_MODE = 0xC01E0322;
		/// <summary>The miniport does not have a recommendation regarding the request to provide a functional VidPN given the current display adapter configuration.</summary>
		public const uint STATUS_GRAPHICS_NO_RECOMMENDED_FUNCTIONAL_VIDPN = 0xC01E0323;
		/// <summary>The ID of the specified mode is being used by another mode in the set.</summary>
		public const uint STATUS_GRAPHICS_MODE_ID_MUST_BE_UNIQUE = 0xC01E0324;
		/// <summary>The system failed to determine a mode that is supported by both the display adapter and the monitor connected to it.</summary>
		public const uint STATUS_GRAPHICS_EMPTY_ADAPTER_MONITOR_MODE_SUPPORT_INTERSECTION = 0xC01E0325;
		/// <summary>The number of video present targets must be greater than or equal to the number of video present sources.</summary>
		public const uint STATUS_GRAPHICS_VIDEO_PRESENT_TARGETS_LESS_THAN_SOURCES = 0xC01E0326;
		/// <summary>The specified present path is not in the VidPN's topology.</summary>
		public const uint STATUS_GRAPHICS_PATH_NOT_IN_TOPOLOGY = 0xC01E0327;
		/// <summary>The display adapter must have at least one video present source.</summary>
		public const uint STATUS_GRAPHICS_ADAPTER_MUST_HAVE_AT_LEAST_ONE_SOURCE = 0xC01E0328;
		/// <summary>The display adapter must have at least one video present target.</summary>
		public const uint STATUS_GRAPHICS_ADAPTER_MUST_HAVE_AT_LEAST_ONE_TARGET = 0xC01E0329;
		/// <summary>The specified monitor descriptor set is invalid.</summary>
		public const uint STATUS_GRAPHICS_INVALID_MONITORDESCRIPTORSET = 0xC01E032A;
		/// <summary>The specified monitor descriptor is invalid.</summary>
		public const uint STATUS_GRAPHICS_INVALID_MONITORDESCRIPTOR = 0xC01E032B;
		/// <summary>The specified descriptor is not in the specified monitor descriptor set.</summary>
		public const uint STATUS_GRAPHICS_MONITORDESCRIPTOR_NOT_IN_SET = 0xC01E032C;
		/// <summary>The specified descriptor is already in the specified monitor descriptor set.</summary>
		public const uint STATUS_GRAPHICS_MONITORDESCRIPTOR_ALREADY_IN_SET = 0xC01E032D;
		/// <summary>The ID of the specified monitor descriptor is being used by another descriptor in the set.</summary>
		public const uint STATUS_GRAPHICS_MONITORDESCRIPTOR_ID_MUST_BE_UNIQUE = 0xC01E032E;
		/// <summary>The specified video present target subset type is invalid.</summary>
		public const uint STATUS_GRAPHICS_INVALID_VIDPN_TARGET_SUBSET_TYPE = 0xC01E032F;
		/// <summary>Two or more of the specified resources are not related to each other, as defined by the interface semantics.</summary>
		public const uint STATUS_GRAPHICS_RESOURCES_NOT_RELATED = 0xC01E0330;
		/// <summary>The ID of the specified video present source is being used by another source in the set.</summary>
		public const uint STATUS_GRAPHICS_SOURCE_ID_MUST_BE_UNIQUE = 0xC01E0331;
		/// <summary>The ID of the specified video present target is being used by another target in the set.</summary>
		public const uint STATUS_GRAPHICS_TARGET_ID_MUST_BE_UNIQUE = 0xC01E0332;
		/// <summary>The specified VidPN source cannot be used because there is no available VidPN target to connect it to.</summary>
		public const uint STATUS_GRAPHICS_NO_AVAILABLE_VIDPN_TARGET = 0xC01E0333;
		/// <summary>The newly arrived monitor could not be associated with a display adapter.</summary>
		public const uint STATUS_GRAPHICS_MONITOR_COULD_NOT_BE_ASSOCIATED_WITH_ADAPTER = 0xC01E0334;
		/// <summary>The particular display adapter does not have an associated VidPN manager.</summary>
		public const uint STATUS_GRAPHICS_NO_VIDPNMGR = 0xC01E0335;
		/// <summary>The VidPN manager of the particular display adapter does not have an active VidPN.</summary>
		public const uint STATUS_GRAPHICS_NO_ACTIVE_VIDPN = 0xC01E0336;
		/// <summary>The specified VidPN topology is stale; obtain the new topology.</summary>
		public const uint STATUS_GRAPHICS_STALE_VIDPN_TOPOLOGY = 0xC01E0337;
		/// <summary>No monitor is connected on the specified video present target.</summary>
		public const uint STATUS_GRAPHICS_MONITOR_NOT_CONNECTED = 0xC01E0338;
		/// <summary>The specified source is not part of the specified VidPN's topology.</summary>
		public const uint STATUS_GRAPHICS_SOURCE_NOT_IN_TOPOLOGY = 0xC01E0339;
		/// <summary>The specified primary surface size is invalid.</summary>
		public const uint STATUS_GRAPHICS_INVALID_PRIMARYSURFACE_SIZE = 0xC01E033A;
		/// <summary>The specified visible region size is invalid.</summary>
		public const uint STATUS_GRAPHICS_INVALID_VISIBLEREGION_SIZE = 0xC01E033B;
		/// <summary>The specified stride is invalid.</summary>
		public const uint STATUS_GRAPHICS_INVALID_STRIDE = 0xC01E033C;
		/// <summary>The specified pixel format is invalid.</summary>
		public const uint STATUS_GRAPHICS_INVALID_PIXELFORMAT = 0xC01E033D;
		/// <summary>The specified color basis is invalid.</summary>
		public const uint STATUS_GRAPHICS_INVALID_COLORBASIS = 0xC01E033E;
		/// <summary>The specified pixel value access mode is invalid.</summary>
		public const uint STATUS_GRAPHICS_INVALID_PIXELVALUEACCESSMODE = 0xC01E033F;
		/// <summary>The specified target is not part of the specified VidPN's topology.</summary>
		public const uint STATUS_GRAPHICS_TARGET_NOT_IN_TOPOLOGY = 0xC01E0340;
		/// <summary>Failed to acquire the display mode management interface.</summary>
		public const uint STATUS_GRAPHICS_NO_DISPLAY_MODE_MANAGEMENT_SUPPORT = 0xC01E0341;
		/// <summary>The specified VidPN source is already owned by a DMM client and cannot be used until that client releases it.</summary>
		public const uint STATUS_GRAPHICS_VIDPN_SOURCE_IN_USE = 0xC01E0342;
		/// <summary>The specified VidPN is active and cannot be accessed.</summary>
		public const uint STATUS_GRAPHICS_CANT_ACCESS_ACTIVE_VIDPN = 0xC01E0343;
		/// <summary>The specified VidPN's present path importance ordinal is invalid.</summary>
		public const uint STATUS_GRAPHICS_INVALID_PATH_IMPORTANCE_ORDINAL = 0xC01E0344;
		/// <summary>The specified VidPN's present path content geometry transformation is invalid.</summary>
		public const uint STATUS_GRAPHICS_INVALID_PATH_CONTENT_GEOMETRY_TRANSFORMATION = 0xC01E0345;
		/// <summary>The specified content geometry transformation is not supported on the respective VidPN present path.</summary>
		public const uint STATUS_GRAPHICS_PATH_CONTENT_GEOMETRY_TRANSFORMATION_NOT_SUPPORTED = 0xC01E0346;
		/// <summary>The specified gamma ramp is invalid.</summary>
		public const uint STATUS_GRAPHICS_INVALID_GAMMA_RAMP = 0xC01E0347;
		/// <summary>The specified gamma ramp is not supported on the respective VidPN present path.</summary>
		public const uint STATUS_GRAPHICS_GAMMA_RAMP_NOT_SUPPORTED = 0xC01E0348;
		/// <summary>Multisampling is not supported on the respective VidPN present path.</summary>
		public const uint STATUS_GRAPHICS_MULTISAMPLING_NOT_SUPPORTED = 0xC01E0349;
		/// <summary>The specified mode is not in the specified mode set.</summary>
		public const uint STATUS_GRAPHICS_MODE_NOT_IN_MODESET = 0xC01E034A;
		/// <summary>The specified VidPN topology recommendation reason is invalid.</summary>
		public const uint STATUS_GRAPHICS_INVALID_VIDPN_TOPOLOGY_RECOMMENDATION_REASON = 0xC01E034D;
		/// <summary>The specified VidPN present path content type is invalid.</summary>
		public const uint STATUS_GRAPHICS_INVALID_PATH_CONTENT_TYPE = 0xC01E034E;
		/// <summary>The specified VidPN present path copy protection type is invalid.</summary>
		public const uint STATUS_GRAPHICS_INVALID_COPYPROTECTION_TYPE = 0xC01E034F;
		/// <summary>Only one unassigned mode set can exist at any one time for a particular VidPN source or target.</summary>
		public const uint STATUS_GRAPHICS_UNASSIGNED_MODESET_ALREADY_EXISTS = 0xC01E0350;
		/// <summary>The specified scan line ordering type is invalid.</summary>
		public const uint STATUS_GRAPHICS_INVALID_SCANLINE_ORDERING = 0xC01E0352;
		/// <summary>The topology changes are not allowed for the specified VidPN.</summary>
		public const uint STATUS_GRAPHICS_TOPOLOGY_CHANGES_NOT_ALLOWED = 0xC01E0353;
		/// <summary>All available importance ordinals are being used in the specified topology.</summary>
		public const uint STATUS_GRAPHICS_NO_AVAILABLE_IMPORTANCE_ORDINALS = 0xC01E0354;
		/// <summary>The specified primary surface has a different private-format attribute than the current primary surface.</summary>
		public const uint STATUS_GRAPHICS_INCOMPATIBLE_PRIVATE_FORMAT = 0xC01E0355;
		/// <summary>The specified mode-pruning algorithm is invalid.</summary>
		public const uint STATUS_GRAPHICS_INVALID_MODE_PRUNING_ALGORITHM = 0xC01E0356;
		/// <summary>The specified monitor-capability origin is invalid.</summary>
		public const uint STATUS_GRAPHICS_INVALID_MONITOR_CAPABILITY_ORIGIN = 0xC01E0357;
		/// <summary>The specified monitor-frequency range constraint is invalid.</summary>
		public const uint STATUS_GRAPHICS_INVALID_MONITOR_FREQUENCYRANGE_CONSTRAINT = 0xC01E0358;
		/// <summary>The maximum supported number of present paths has been reached.</summary>
		public const uint STATUS_GRAPHICS_MAX_NUM_PATHS_REACHED = 0xC01E0359;
		/// <summary>The miniport requested that augmentation be canceled for the specified source of the specified VidPN's topology.</summary>
		public const uint STATUS_GRAPHICS_CANCEL_VIDPN_TOPOLOGY_AUGMENTATION = 0xC01E035A;
		/// <summary>The specified client type was not recognized.</summary>
		public const uint STATUS_GRAPHICS_INVALID_CLIENT_TYPE = 0xC01E035B;
		/// <summary>The client VidPN is not set on this adapter (for example, no user mode-initiated mode changes have taken place on this adapter).</summary>
		public const uint STATUS_GRAPHICS_CLIENTVIDPN_NOT_SET = 0xC01E035C;
		/// <summary>The specified display adapter child device already has an external device connected to it.</summary>
		public const uint STATUS_GRAPHICS_SPECIFIED_CHILD_ALREADY_CONNECTED = 0xC01E0400;
		/// <summary>The display adapter child device does not support reporting a descriptor.</summary>
		public const uint STATUS_GRAPHICS_CHILD_DESCRIPTOR_NOT_SUPPORTED = 0xC01E0401;
		/// <summary>The display adapter is not linked to any other adapters.</summary>
		public const uint STATUS_GRAPHICS_NOT_A_LINKED_ADAPTER = 0xC01E0430;
		/// <summary>The lead adapter in a linked configuration was not enumerated yet.</summary>
		public const uint STATUS_GRAPHICS_LEADLINK_NOT_ENUMERATED = 0xC01E0431;
		/// <summary>Some chain adapters in a linked configuration have not yet been enumerated.</summary>
		public const uint STATUS_GRAPHICS_CHAINLINKS_NOT_ENUMERATED = 0xC01E0432;
		/// <summary>The chain of linked adapters is not ready to start because of an unknown failure.</summary>
		public const uint STATUS_GRAPHICS_ADAPTER_CHAIN_NOT_READY = 0xC01E0433;
		/// <summary>An attempt was made to start a lead link display adapter when the chain links had not yet started.</summary>
		public const uint STATUS_GRAPHICS_CHAINLINKS_NOT_STARTED = 0xC01E0434;
		/// <summary>An attempt was made to turn on a lead link display adapter when the chain links were turned off.</summary>
		public const uint STATUS_GRAPHICS_CHAINLINKS_NOT_POWERED_ON = 0xC01E0435;
		/// <summary>The adapter link was found in an inconsistent state. Not all adapters are in an expected PNP/power state.</summary>
		public const uint STATUS_GRAPHICS_INCONSISTENT_DEVICE_LINK_STATE = 0xC01E0436;
		/// <summary>STATUS_GRAPHICS_NOT_POST_DEVICE_DRIVER</summary>
		public const uint STATUS_GRAPHICS_NOT_POST_DEVICE_DRIVER = 0xC01E0438;
		/// <summary>An operation is being attempted that requires the display adapter to be in a quiescent state.</summary>
		public const uint STATUS_GRAPHICS_ADAPTER_ACCESS_NOT_EXCLUDED = 0xC01E043B;
		/// <summary>The driver does not support OPM.</summary>
		public const uint STATUS_GRAPHICS_OPM_NOT_SUPPORTED = 0xC01E0500;
		/// <summary>The driver does not support COPP.</summary>
		public const uint STATUS_GRAPHICS_COPP_NOT_SUPPORTED = 0xC01E0501;
		/// <summary>The driver does not support UAB.</summary>
		public const uint STATUS_GRAPHICS_UAB_NOT_SUPPORTED = 0xC01E0502;
		/// <summary>The specified encrypted parameters are invalid.</summary>
		public const uint STATUS_GRAPHICS_OPM_INVALID_ENCRYPTED_PARAMETERS = 0xC01E0503;
		/// <summary>An array passed to a function cannot hold all of the data that the function wants to put in it.</summary>
		public const uint STATUS_GRAPHICS_OPM_PARAMETER_ARRAY_TOO_SMALL = 0xC01E0504;
		/// <summary>The GDI display device passed to this function does not have any active protected outputs.</summary>
		public const uint STATUS_GRAPHICS_OPM_NO_PROTECTED_OUTPUTS_EXIST = 0xC01E0505;
		/// <summary>The PVP cannot find an actual GDI display device that corresponds to the passed-in GDI display device name.</summary>
		public const uint STATUS_GRAPHICS_PVP_NO_DISPLAY_DEVICE_CORRESPONDS_TO_NAME = 0xC01E0506;
		/// <summary>This function failed because the GDI display device passed to it was not attached to the Windows desktop.</summary>
		public const uint STATUS_GRAPHICS_PVP_DISPLAY_DEVICE_NOT_ATTACHED_TO_DESKTOP = 0xC01E0507;
		/// <summary>The PVP does not support mirroring display devices because they do not have any protected outputs.</summary>
		public const uint STATUS_GRAPHICS_PVP_MIRRORING_DEVICES_NOT_SUPPORTED = 0xC01E0508;
		/// <summary>The function failed because an invalid pointer parameter was passed to it. A pointer parameter is invalid if it is null, is not correctly aligned, or it points to an invalid address or a kernel mode address.</summary>
		public const uint STATUS_GRAPHICS_OPM_INVALID_POINTER = 0xC01E050A;
		/// <summary>An internal error caused an operation to fail.</summary>
		public const uint STATUS_GRAPHICS_OPM_INTERNAL_ERROR = 0xC01E050B;
		/// <summary>The function failed because the caller passed in an invalid OPM user-mode handle.</summary>
		public const uint STATUS_GRAPHICS_OPM_INVALID_HANDLE = 0xC01E050C;
		/// <summary>This function failed because the GDI device passed to it did not have any monitors associated with it.</summary>
		public const uint STATUS_GRAPHICS_PVP_NO_MONITORS_CORRESPOND_TO_DISPLAY_DEVICE = 0xC01E050D;
		/// <summary>A certificate could not be returned because the certificate buffer passed to the function was too small.</summary>
		public const uint STATUS_GRAPHICS_PVP_INVALID_CERTIFICATE_LENGTH = 0xC01E050E;
		/// <summary>DxgkDdiOpmCreateProtectedOutput() could not create a protected output because the video present yarget is in spanning mode.</summary>
		public const uint STATUS_GRAPHICS_OPM_SPANNING_MODE_ENABLED = 0xC01E050F;
		/// <summary>DxgkDdiOpmCreateProtectedOutput() could not create a protected output because the video present target is in theater mode.</summary>
		public const uint STATUS_GRAPHICS_OPM_THEATER_MODE_ENABLED = 0xC01E0510;
		/// <summary>The function call failed because the display adapter's hardware functionality scan (HFS) failed to validate the graphics hardware.</summary>
		public const uint STATUS_GRAPHICS_PVP_HFS_FAILED = 0xC01E0511;
		/// <summary>The HDCP SRM passed to this function did not comply with section 5 of the HDCP 1.1 specification.</summary>
		public const uint STATUS_GRAPHICS_OPM_INVALID_SRM = 0xC01E0512;
		/// <summary>The protected output cannot enable the HDCP system because it does not support it.</summary>
		public const uint STATUS_GRAPHICS_OPM_OUTPUT_DOES_NOT_SUPPORT_HDCP = 0xC01E0513;
		/// <summary>The protected output cannot enable analog copy protection because it does not support it.</summary>
		public const uint STATUS_GRAPHICS_OPM_OUTPUT_DOES_NOT_SUPPORT_ACP = 0xC01E0514;
		/// <summary>The protected output cannot enable the CGMS-A protection technology because it does not support it.</summary>
		public const uint STATUS_GRAPHICS_OPM_OUTPUT_DOES_NOT_SUPPORT_CGMSA = 0xC01E0515;
		/// <summary>DxgkDdiOPMGetInformation() cannot return the version of the SRM being used because the application never successfully passed an SRM to the protected output.</summary>
		public const uint STATUS_GRAPHICS_OPM_HDCP_SRM_NEVER_SET = 0xC01E0516;
		/// <summary>DxgkDdiOPMConfigureProtectedOutput() cannot enable the specified output protection technology because the output's screen resolution is too high.</summary>
		public const uint STATUS_GRAPHICS_OPM_RESOLUTION_TOO_HIGH = 0xC01E0517;
		/// <summary>DxgkDdiOPMConfigureProtectedOutput() cannot enable HDCP because other physical outputs are using the display adapter's HDCP hardware.</summary>
		public const uint STATUS_GRAPHICS_OPM_ALL_HDCP_HARDWARE_ALREADY_IN_USE = 0xC01E0518;
		/// <summary>The operating system asynchronously destroyed this OPM-protected output because the operating system state changed. This error typically occurs because the monitor PDO associated with this protected output was removed or stopped, the protected output's session became a nonconsole session, or the protected output's desktop became inactive.</summary>
		public const uint STATUS_GRAPHICS_OPM_PROTECTED_OUTPUT_NO_LONGER_EXISTS = 0xC01E051A;
		/// <summary>OPM functions cannot be called when a session is changing its type. Three types of sessions currently exist: console, disconnected, and remote (RDP or ICA).</summary>
		public const uint STATUS_GRAPHICS_OPM_SESSION_TYPE_CHANGE_IN_PROGRESS = 0xC01E051B;
		/// <summary>The DxgkDdiOPMGetCOPPCompatibleInformation, DxgkDdiOPMGetInformation, or DxgkDdiOPMConfigureProtectedOutput function failed. This error is returned only if a protected output has OPM semantics. DxgkDdiOPMGetCOPPCompatibleInformation always returns this error if a protected output has OPM semantics. DxgkDdiOPMGetInformation returns this error code if the caller requested COPP-specific information. DxgkDdiOPMConfigureProtectedOutput returns this error when the caller tries to use a COPP-specific command.</summary>
		public const uint STATUS_GRAPHICS_OPM_PROTECTED_OUTPUT_DOES_NOT_HAVE_COPP_SEMANTICS = 0xC01E051C;
		/// <summary>The DxgkDdiOPMGetInformation and DxgkDdiOPMGetCOPPCompatibleInformation functions return this error code if the passed-in sequence number is not the expected sequence number or the passed-in OMAC value is invalid.</summary>
		public const uint STATUS_GRAPHICS_OPM_INVALID_INFORMATION_REQUEST = 0xC01E051D;
		/// <summary>The function failed because an unexpected error occurred inside a display driver.</summary>
		public const uint STATUS_GRAPHICS_OPM_DRIVER_INTERNAL_ERROR = 0xC01E051E;
		/// <summary>The DxgkDdiOPMGetCOPPCompatibleInformation, DxgkDdiOPMGetInformation, or DxgkDdiOPMConfigureProtectedOutput function failed. This error is returned only if a protected output has COPP semantics. DxgkDdiOPMGetCOPPCompatibleInformation returns this error code if the caller requested OPM-specific information. DxgkDdiOPMGetInformation always returns this error if a protected output has COPP semantics. DxgkDdiOPMConfigureProtectedOutput returns this error when the caller tries to use an OPM-specific command.</summary>
		public const uint STATUS_GRAPHICS_OPM_PROTECTED_OUTPUT_DOES_NOT_HAVE_OPM_SEMANTICS = 0xC01E051F;
		/// <summary>The DxgkDdiOPMGetCOPPCompatibleInformation and DxgkDdiOPMConfigureProtectedOutput functions return this error if the display driver does not support the DXGKMDT_OPM_GET_ACP_AND_CGMSA_SIGNALING and DXGKMDT_OPM_SET_ACP_AND_CGMSA_SIGNALING GUIDs.</summary>
		public const uint STATUS_GRAPHICS_OPM_SIGNALING_NOT_SUPPORTED = 0xC01E0520;
		/// <summary>The DxgkDdiOPMConfigureProtectedOutput function returns this error code if the passed-in sequence number is not the expected sequence number or the passed-in OMAC value is invalid.</summary>
		public const uint STATUS_GRAPHICS_OPM_INVALID_CONFIGURATION_REQUEST = 0xC01E0521;
		/// <summary>The monitor connected to the specified video output does not have an I2C bus.</summary>
		public const uint STATUS_GRAPHICS_I2C_NOT_SUPPORTED = 0xC01E0580;
		/// <summary>No device on the I2C bus has the specified address.</summary>
		public const uint STATUS_GRAPHICS_I2C_DEVICE_DOES_NOT_EXIST = 0xC01E0581;
		/// <summary>An error occurred while transmitting data to the device on the I2C bus.</summary>
		public const uint STATUS_GRAPHICS_I2C_ERROR_TRANSMITTING_DATA = 0xC01E0582;
		/// <summary>An error occurred while receiving data from the device on the I2C bus.</summary>
		public const uint STATUS_GRAPHICS_I2C_ERROR_RECEIVING_DATA = 0xC01E0583;
		/// <summary>The monitor does not support the specified VCP code.</summary>
		public const uint STATUS_GRAPHICS_DDCCI_VCP_NOT_SUPPORTED = 0xC01E0584;
		/// <summary>The data received from the monitor is invalid.</summary>
		public const uint STATUS_GRAPHICS_DDCCI_INVALID_DATA = 0xC01E0585;
		/// <summary>A function call failed because a monitor returned an invalid timing status byte when the operating system used the DDC/CI get timing report and timing message command to get a timing report from a monitor.</summary>
		public const uint STATUS_GRAPHICS_DDCCI_MONITOR_RETURNED_INVALID_TIMING_STATUS_BYTE = 0xC01E0586;
		/// <summary>A monitor returned a DDC/CI capabilities string that did not comply with the ACCESS.bus 3.0, DDC/CI 1.1, or MCCS 2 Revision 1 specification.</summary>
		public const uint STATUS_GRAPHICS_DDCCI_INVALID_CAPABILITIES_STRING = 0xC01E0587;
		/// <summary>An internal error caused an operation to fail.</summary>
		public const uint STATUS_GRAPHICS_MCA_INTERNAL_ERROR = 0xC01E0588;
		/// <summary>An operation failed because a DDC/CI message had an invalid value in its command field.</summary>
		public const uint STATUS_GRAPHICS_DDCCI_INVALID_MESSAGE_COMMAND = 0xC01E0589;
		/// <summary>This error occurred because a DDC/CI message had an invalid value in its length field.</summary>
		public const uint STATUS_GRAPHICS_DDCCI_INVALID_MESSAGE_LENGTH = 0xC01E058A;
		/// <summary>This error occurred because the value in a DDC/CI message's checksum field did not match the message's computed checksum value. This error implies that the data was corrupted while it was being transmitted from a monitor to a computer.</summary>
		public const uint STATUS_GRAPHICS_DDCCI_INVALID_MESSAGE_CHECKSUM = 0xC01E058B;
		/// <summary>This function failed because an invalid monitor handle was passed to it.</summary>
		public const uint STATUS_GRAPHICS_INVALID_PHYSICAL_MONITOR_HANDLE = 0xC01E058C;
		/// <summary>The operating system asynchronously destroyed the monitor that corresponds to this handle because the operating system's state changed. This error typically occurs because the monitor PDO associated with this handle was removed or stopped, or a display mode change occurred. A display mode change occurs when Windows sends a WM_DISPLAYCHANGE message to applications.</summary>
		public const uint STATUS_GRAPHICS_MONITOR_NO_LONGER_EXISTS = 0xC01E058D;
		/// <summary>This function can be used only if a program is running in the local console session. It cannot be used if a program is running on a remote desktop session or on a terminal server session.</summary>
		public const uint STATUS_GRAPHICS_ONLY_CONSOLE_SESSION_SUPPORTED = 0xC01E05E0;
		/// <summary>This function cannot find an actual GDI display device that corresponds to the specified GDI display device name.</summary>
		public const uint STATUS_GRAPHICS_NO_DISPLAY_DEVICE_CORRESPONDS_TO_NAME = 0xC01E05E1;
		/// <summary>The function failed because the specified GDI display device was not attached to the Windows desktop.</summary>
		public const uint STATUS_GRAPHICS_DISPLAY_DEVICE_NOT_ATTACHED_TO_DESKTOP = 0xC01E05E2;
		/// <summary>This function does not support GDI mirroring display devices because GDI mirroring display devices do not have any physical monitors associated with them.</summary>
		public const uint STATUS_GRAPHICS_MIRRORING_DEVICES_NOT_SUPPORTED = 0xC01E05E3;
		/// <summary>The function failed because an invalid pointer parameter was passed to it. A pointer parameter is invalid if it is null, is not correctly aligned, or points to an invalid address or to a kernel mode address.</summary>
		public const uint STATUS_GRAPHICS_INVALID_POINTER = 0xC01E05E4;
		/// <summary>This function failed because the GDI device passed to it did not have a monitor associated with it.</summary>
		public const uint STATUS_GRAPHICS_NO_MONITORS_CORRESPOND_TO_DISPLAY_DEVICE = 0xC01E05E5;
		/// <summary>An array passed to the function cannot hold all of the data that the function must copy into the array.</summary>
		public const uint STATUS_GRAPHICS_PARAMETER_ARRAY_TOO_SMALL = 0xC01E05E6;
		/// <summary>An internal error caused an operation to fail.</summary>
		public const uint STATUS_GRAPHICS_INTERNAL_ERROR = 0xC01E05E7;
		/// <summary>The function failed because the current session is changing its type. This function cannot be called when the current session is changing its type. Three types of sessions currently exist: console, disconnected, and remote (RDP or ICA).</summary>
		public const uint STATUS_GRAPHICS_SESSION_TYPE_CHANGE_IN_PROGRESS = 0xC01E05E8;
		/// <summary>The volume must be unlocked before it can be used.</summary>
		public const uint STATUS_FVE_LOCKED_VOLUME = 0xC0210000;
		/// <summary>The volume is fully decrypted and no key is available.</summary>
		public const uint STATUS_FVE_NOT_ENCRYPTED = 0xC0210001;
		/// <summary>The control block for the encrypted volume is not valid.</summary>
		public const uint STATUS_FVE_BAD_INFORMATION = 0xC0210002;
		/// <summary>Not enough free space remains on the volume to allow encryption.</summary>
		public const uint STATUS_FVE_TOO_SMALL = 0xC0210003;
		/// <summary>The partition cannot be encrypted because the file system is not supported.</summary>
		public const uint STATUS_FVE_FAILED_WRONG_FS = 0xC0210004;
		/// <summary>The file system is inconsistent. Run the Check Disk utility.</summary>
		public const uint STATUS_FVE_FAILED_BAD_FS = 0xC0210005;
		/// <summary>The file system does not extend to the end of the volume.</summary>
		public const uint STATUS_FVE_FS_NOT_EXTENDED = 0xC0210006;
		/// <summary>This operation cannot be performed while a file system is mounted on the volume.</summary>
		public const uint STATUS_FVE_FS_MOUNTED = 0xC0210007;
		/// <summary>BitLocker Drive Encryption is not included with this version of Windows.</summary>
		public const uint STATUS_FVE_NO_LICENSE = 0xC0210008;
		/// <summary>The requested action was denied by the FVE control engine.</summary>
		public const uint STATUS_FVE_ACTION_NOT_ALLOWED = 0xC0210009;
		/// <summary>The data supplied is malformed.</summary>
		public const uint STATUS_FVE_BAD_DATA = 0xC021000A;
		/// <summary>The volume is not bound to the system.</summary>
		public const uint STATUS_FVE_VOLUME_NOT_BOUND = 0xC021000B;
		/// <summary>The volume specified is not a data volume.</summary>
		public const uint STATUS_FVE_NOT_DATA_VOLUME = 0xC021000C;
		/// <summary>A read operation failed while converting the volume.</summary>
		public const uint STATUS_FVE_CONV_READ_ERROR = 0xC021000D;
		/// <summary>A write operation failed while converting the volume.</summary>
		public const uint STATUS_FVE_CONV_WRITE_ERROR = 0xC021000E;
		/// <summary>The control block for the encrypted volume was updated by another thread. Try again.</summary>
		public const uint STATUS_FVE_OVERLAPPED_UPDATE = 0xC021000F;
		/// <summary>The volume encryption algorithm cannot be used on this sector size.</summary>
		public const uint STATUS_FVE_FAILED_SECTOR_SIZE = 0xC0210010;
		/// <summary>BitLocker recovery authentication failed.</summary>
		public const uint STATUS_FVE_FAILED_AUTHENTICATION = 0xC0210011;
		/// <summary>The volume specified is not the boot operating system volume.</summary>
		public const uint STATUS_FVE_NOT_OS_VOLUME = 0xC0210012;
		/// <summary>The BitLocker startup key or recovery password could not be read from external media.</summary>
		public const uint STATUS_FVE_KEYFILE_NOT_FOUND = 0xC0210013;
		/// <summary>The BitLocker startup key or recovery password file is corrupt or invalid.</summary>
		public const uint STATUS_FVE_KEYFILE_INVALID = 0xC0210014;
		/// <summary>The BitLocker encryption key could not be obtained from the startup key or the recovery password.</summary>
		public const uint STATUS_FVE_KEYFILE_NO_VMK = 0xC0210015;
		/// <summary>The TPM is disabled.</summary>
		public const uint STATUS_FVE_TPM_DISABLED = 0xC0210016;
		/// <summary>The authorization data for the SRK of the TPM is not zero.</summary>
		public const uint STATUS_FVE_TPM_SRK_AUTH_NOT_ZERO = 0xC0210017;
		/// <summary>The system boot information changed or the TPM locked out access to BitLocker encryption keys until the computer is restarted.</summary>
		public const uint STATUS_FVE_TPM_INVALID_PCR = 0xC0210018;
		/// <summary>The BitLocker encryption key could not be obtained from the TPM.</summary>
		public const uint STATUS_FVE_TPM_NO_VMK = 0xC0210019;
		/// <summary>The BitLocker encryption key could not be obtained from the TPM and PIN.</summary>
		public const uint STATUS_FVE_PIN_INVALID = 0xC021001A;
		/// <summary>A boot application hash does not match the hash computed when BitLocker was turned on.</summary>
		public const uint STATUS_FVE_AUTH_INVALID_APPLICATION = 0xC021001B;
		/// <summary>The Boot Configuration Data (BCD) settings are not supported or have changed because BitLocker was enabled.</summary>
		public const uint STATUS_FVE_AUTH_INVALID_CONFIG = 0xC021001C;
		/// <summary>Boot debugging is enabled. Run Windows Boot Configuration Data Store Editor (bcdedit.exe) to turn it off.</summary>
		public const uint STATUS_FVE_DEBUGGER_ENABLED = 0xC021001D;
		/// <summary>The BitLocker encryption key could not be obtained.</summary>
		public const uint STATUS_FVE_DRY_RUN_FAILED = 0xC021001E;
		/// <summary>The metadata disk region pointer is incorrect.</summary>
		public const uint STATUS_FVE_BAD_METADATA_POINTER = 0xC021001F;
		/// <summary>The backup copy of the metadata is out of date.</summary>
		public const uint STATUS_FVE_OLD_METADATA_COPY = 0xC0210020;
		/// <summary>No action was taken because a system restart is required.</summary>
		public const uint STATUS_FVE_REBOOT_REQUIRED = 0xC0210021;
		/// <summary>No action was taken because BitLocker Drive Encryption is in RAW access mode.</summary>
		public const uint STATUS_FVE_RAW_ACCESS = 0xC0210022;
		/// <summary>BitLocker Drive Encryption cannot enter RAW access mode for this volume.</summary>
		public const uint STATUS_FVE_RAW_BLOCKED = 0xC0210023;
		/// <summary>This feature of BitLocker Drive Encryption is not included with this version of Windows.</summary>
		public const uint STATUS_FVE_NO_FEATURE_LICENSE = 0xC0210026;
		/// <summary>Group policy does not permit turning off BitLocker Drive Encryption on roaming data volumes.</summary>
		public const uint STATUS_FVE_POLICY_USER_DISABLE_RDV_NOT_ALLOWED = 0xC0210027;
		/// <summary>Bitlocker Drive Encryption failed to recover from aborted conversion. This could be due to either all conversion logs being corrupted or the media being write-protected.</summary>
		public const uint STATUS_FVE_CONV_RECOVERY_FAILED = 0xC0210028;
		/// <summary>The requested virtualization size is too big.</summary>
		public const uint STATUS_FVE_VIRTUALIZED_SPACE_TOO_BIG = 0xC0210029;
		/// <summary>The drive is too small to be protected using BitLocker Drive Encryption.</summary>
		public const uint STATUS_FVE_VOLUME_TOO_SMALL = 0xC0210030;
		/// <summary>The callout does not exist.</summary>
		public const uint STATUS_FWP_CALLOUT_NOT_FOUND = 0xC0220001;
		/// <summary>The filter condition does not exist.</summary>
		public const uint STATUS_FWP_CONDITION_NOT_FOUND = 0xC0220002;
		/// <summary>The filter does not exist.</summary>
		public const uint STATUS_FWP_FILTER_NOT_FOUND = 0xC0220003;
		/// <summary>The layer does not exist.</summary>
		public const uint STATUS_FWP_LAYER_NOT_FOUND = 0xC0220004;
		/// <summary>The provider does not exist.</summary>
		public const uint STATUS_FWP_PROVIDER_NOT_FOUND = 0xC0220005;
		/// <summary>The provider context does not exist.</summary>
		public const uint STATUS_FWP_PROVIDER_CONTEXT_NOT_FOUND = 0xC0220006;
		/// <summary>The sublayer does not exist.</summary>
		public const uint STATUS_FWP_SUBLAYER_NOT_FOUND = 0xC0220007;
		/// <summary>The object does not exist.</summary>
		public const uint STATUS_FWP_NOT_FOUND = 0xC0220008;
		/// <summary>An object with that GUID or LUID already exists.</summary>
		public const uint STATUS_FWP_ALREADY_EXISTS = 0xC0220009;
		/// <summary>The object is referenced by other objects and cannot be deleted.</summary>
		public const uint STATUS_FWP_IN_USE = 0xC022000A;
		/// <summary>The call is not allowed from within a dynamic session.</summary>
		public const uint STATUS_FWP_DYNAMIC_SESSION_IN_PROGRESS = 0xC022000B;
		/// <summary>The call was made from the wrong session and cannot be completed.</summary>
		public const uint STATUS_FWP_WRONG_SESSION = 0xC022000C;
		/// <summary>The call must be made from within an explicit transaction.</summary>
		public const uint STATUS_FWP_NO_TXN_IN_PROGRESS = 0xC022000D;
		/// <summary>The call is not allowed from within an explicit transaction.</summary>
		public const uint STATUS_FWP_TXN_IN_PROGRESS = 0xC022000E;
		/// <summary>The explicit transaction has been forcibly canceled.</summary>
		public const uint STATUS_FWP_TXN_ABORTED = 0xC022000F;
		/// <summary>The session has been canceled.</summary>
		public const uint STATUS_FWP_SESSION_ABORTED = 0xC0220010;
		/// <summary>The call is not allowed from within a read-only transaction.</summary>
		public const uint STATUS_FWP_INCOMPATIBLE_TXN = 0xC0220011;
		/// <summary>The call timed out while waiting to acquire the transaction lock.</summary>
		public const uint STATUS_FWP_TIMEOUT = 0xC0220012;
		/// <summary>The collection of network diagnostic events is disabled.</summary>
		public const uint STATUS_FWP_NET_EVENTS_DISABLED = 0xC0220013;
		/// <summary>The operation is not supported by the specified layer.</summary>
		public const uint STATUS_FWP_INCOMPATIBLE_LAYER = 0xC0220014;
		/// <summary>The call is allowed for kernel-mode callers only.</summary>
		public const uint STATUS_FWP_KM_CLIENTS_ONLY = 0xC0220015;
		/// <summary>The call tried to associate two objects with incompatible lifetimes.</summary>
		public const uint STATUS_FWP_LIFETIME_MISMATCH = 0xC0220016;
		/// <summary>The object is built-in and cannot be deleted.</summary>
		public const uint STATUS_FWP_BUILTIN_OBJECT = 0xC0220017;
		/// <summary>The maximum number of boot-time filters has been reached.</summary>
		public const uint STATUS_FWP_TOO_MANY_BOOTTIME_FILTERS = 0xC0220018;
		/// <summary>The maximum number of callouts has been reached.</summary>
		public const uint STATUS_FWP_TOO_MANY_CALLOUTS = 0xC0220018;
		/// <summary>A notification could not be delivered because a message queue has reached maximum capacity.</summary>
		public const uint STATUS_FWP_NOTIFICATION_DROPPED = 0xC0220019;
		/// <summary>The traffic parameters do not match those for the security association context.</summary>
		public const uint STATUS_FWP_TRAFFIC_MISMATCH = 0xC022001A;
		/// <summary>The call is not allowed for the current security association state.</summary>
		public const uint STATUS_FWP_INCOMPATIBLE_SA_STATE = 0xC022001B;
		/// <summary>A required pointer is null.</summary>
		public const uint STATUS_FWP_NULL_POINTER = 0xC022001C;
		/// <summary>An enumerator is not valid.</summary>
		public const uint STATUS_FWP_INVALID_ENUMERATOR = 0xC022001D;
		/// <summary>The flags field contains an invalid value.</summary>
		public const uint STATUS_FWP_INVALID_FLAGS = 0xC022001E;
		/// <summary>A network mask is not valid.</summary>
		public const uint STATUS_FWP_INVALID_NET_MASK = 0xC022001F;
		/// <summary>An FWP_RANGE is not valid.</summary>
		public const uint STATUS_FWP_INVALID_RANGE = 0xC0220020;
		/// <summary>The time interval is not valid.</summary>
		public const uint STATUS_FWP_INVALID_INTERVAL = 0xC0220021;
		/// <summary>An array that must contain at least one element has a zero length.</summary>
		public const uint STATUS_FWP_ZERO_LENGTH_ARRAY = 0xC0220022;
		/// <summary>The displayData.name field cannot be null.</summary>
		public const uint STATUS_FWP_NULL_DISPLAY_NAME = 0xC0220023;
		/// <summary>The action type is not one of the allowed action types for a filter.</summary>
		public const uint STATUS_FWP_INVALID_ACTION_TYPE = 0xC0220024;
		/// <summary>The filter weight is not valid.</summary>
		public const uint STATUS_FWP_INVALID_WEIGHT = 0xC0220025;
		/// <summary>A filter condition contains a match type that is not compatible with the operands.</summary>
		public const uint STATUS_FWP_MATCH_TYPE_MISMATCH = 0xC0220026;
		/// <summary>An FWP_VALUE or FWPM_CONDITION_VALUE is of the wrong type.</summary>
		public const uint STATUS_FWP_TYPE_MISMATCH = 0xC0220027;
		/// <summary>An integer value is outside the allowed range.</summary>
		public const uint STATUS_FWP_OUT_OF_BOUNDS = 0xC0220028;
		/// <summary>A reserved field is nonzero.</summary>
		public const uint STATUS_FWP_RESERVED = 0xC0220029;
		/// <summary>A filter cannot contain multiple conditions operating on a single field.</summary>
		public const uint STATUS_FWP_DUPLICATE_CONDITION = 0xC022002A;
		/// <summary>A policy cannot contain the same keying module more than once.</summary>
		public const uint STATUS_FWP_DUPLICATE_KEYMOD = 0xC022002B;
		/// <summary>The action type is not compatible with the layer.</summary>
		public const uint STATUS_FWP_ACTION_INCOMPATIBLE_WITH_LAYER = 0xC022002C;
		/// <summary>The action type is not compatible with the sublayer.</summary>
		public const uint STATUS_FWP_ACTION_INCOMPATIBLE_WITH_SUBLAYER = 0xC022002D;
		/// <summary>The raw context or the provider context is not compatible with the layer.</summary>
		public const uint STATUS_FWP_CONTEXT_INCOMPATIBLE_WITH_LAYER = 0xC022002E;
		/// <summary>The raw context or the provider context is not compatible with the callout.</summary>
		public const uint STATUS_FWP_CONTEXT_INCOMPATIBLE_WITH_CALLOUT = 0xC022002F;
		/// <summary>The authentication method is not compatible with the policy type.</summary>
		public const uint STATUS_FWP_INCOMPATIBLE_AUTH_METHOD = 0xC0220030;
		/// <summary>The Diffie-Hellman group is not compatible with the policy type.</summary>
		public const uint STATUS_FWP_INCOMPATIBLE_DH_GROUP = 0xC0220031;
		/// <summary>An IKE policy cannot contain an Extended Mode policy.</summary>
		public const uint STATUS_FWP_EM_NOT_SUPPORTED = 0xC0220032;
		/// <summary>The enumeration template or subscription will never match any objects.</summary>
		public const uint STATUS_FWP_NEVER_MATCH = 0xC0220033;
		/// <summary>The provider context is of the wrong type.</summary>
		public const uint STATUS_FWP_PROVIDER_CONTEXT_MISMATCH = 0xC0220034;
		/// <summary>The parameter is incorrect.</summary>
		public const uint STATUS_FWP_INVALID_PARAMETER = 0xC0220035;
		/// <summary>The maximum number of sublayers has been reached.</summary>
		public const uint STATUS_FWP_TOO_MANY_SUBLAYERS = 0xC0220036;
		/// <summary>The notification function for a callout returned an error.</summary>
		public const uint STATUS_FWP_CALLOUT_NOTIFICATION_FAILED = 0xC0220037;
		/// <summary>The IPsec authentication configuration is not compatible with the authentication type.</summary>
		public const uint STATUS_FWP_INCOMPATIBLE_AUTH_CONFIG = 0xC0220038;
		/// <summary>The IPsec cipher configuration is not compatible with the cipher type.</summary>
		public const uint STATUS_FWP_INCOMPATIBLE_CIPHER_CONFIG = 0xC0220039;
		/// <summary>A policy cannot contain the same auth method more than once.</summary>
		public const uint STATUS_FWP_DUPLICATE_AUTH_METHOD = 0xC022003C;
		/// <summary>The TCP/IP stack is not ready.</summary>
		public const uint STATUS_FWP_TCPIP_NOT_READY = 0xC0220100;
		/// <summary>The injection handle is being closed by another thread.</summary>
		public const uint STATUS_FWP_INJECT_HANDLE_CLOSING = 0xC0220101;
		/// <summary>The injection handle is stale.</summary>
		public const uint STATUS_FWP_INJECT_HANDLE_STALE = 0xC0220102;
		/// <summary>The classify cannot be pended.</summary>
		public const uint STATUS_FWP_CANNOT_PEND = 0xC0220103;
		/// <summary>The binding to the network interface is being closed.</summary>
		public const uint STATUS_NDIS_CLOSING = 0xC0230002;
		/// <summary>An invalid version was specified.</summary>
		public const uint STATUS_NDIS_BAD_VERSION = 0xC0230004;
		/// <summary>An invalid characteristics table was used.</summary>
		public const uint STATUS_NDIS_BAD_CHARACTERISTICS = 0xC0230005;
		/// <summary>Failed to find the network interface or the network interface is not ready.</summary>
		public const uint STATUS_NDIS_ADAPTER_NOT_FOUND = 0xC0230006;
		/// <summary>Failed to open the network interface.</summary>
		public const uint STATUS_NDIS_OPEN_FAILED = 0xC0230007;
		/// <summary>The network interface has encountered an internal unrecoverable failure.</summary>
		public const uint STATUS_NDIS_DEVICE_FAILED = 0xC0230008;
		/// <summary>The multicast list on the network interface is full.</summary>
		public const uint STATUS_NDIS_MULTICAST_FULL = 0xC0230009;
		/// <summary>An attempt was made to add a duplicate multicast address to the list.</summary>
		public const uint STATUS_NDIS_MULTICAST_EXISTS = 0xC023000A;
		/// <summary>At attempt was made to remove a multicast address that was never added.</summary>
		public const uint STATUS_NDIS_MULTICAST_NOT_FOUND = 0xC023000B;
		/// <summary>The network interface aborted the request.</summary>
		public const uint STATUS_NDIS_REQUEST_ABORTED = 0xC023000C;
		/// <summary>The network interface cannot process the request because it is being reset.</summary>
		public const uint STATUS_NDIS_RESET_IN_PROGRESS = 0xC023000D;
		/// <summary>An attempt was made to send an invalid packet on a network interface.</summary>
		public const uint STATUS_NDIS_INVALID_PACKET = 0xC023000F;
		/// <summary>The specified request is not a valid operation for the target device.</summary>
		public const uint STATUS_NDIS_INVALID_DEVICE_REQUEST = 0xC0230010;
		/// <summary>The network interface is not ready to complete this operation.</summary>
		public const uint STATUS_NDIS_ADAPTER_NOT_READY = 0xC0230011;
		/// <summary>The length of the buffer submitted for this operation is not valid.</summary>
		public const uint STATUS_NDIS_INVALID_LENGTH = 0xC0230014;
		/// <summary>The data used for this operation is not valid.</summary>
		public const uint STATUS_NDIS_INVALID_DATA = 0xC0230015;
		/// <summary>The length of the submitted buffer for this operation is too small.</summary>
		public const uint STATUS_NDIS_BUFFER_TOO_SHORT = 0xC0230016;
		/// <summary>The network interface does not support this object identifier.</summary>
		public const uint STATUS_NDIS_INVALID_OID = 0xC0230017;
		/// <summary>The network interface has been removed.</summary>
		public const uint STATUS_NDIS_ADAPTER_REMOVED = 0xC0230018;
		/// <summary>The network interface does not support this media type.</summary>
		public const uint STATUS_NDIS_UNSUPPORTED_MEDIA = 0xC0230019;
		/// <summary>An attempt was made to remove a token ring group address that is in use by other components.</summary>
		public const uint STATUS_NDIS_GROUP_ADDRESS_IN_USE = 0xC023001A;
		/// <summary>An attempt was made to map a file that cannot be found.</summary>
		public const uint STATUS_NDIS_FILE_NOT_FOUND = 0xC023001B;
		/// <summary>An error occurred while NDIS tried to map the file.</summary>
		public const uint STATUS_NDIS_ERROR_READING_FILE = 0xC023001C;
		/// <summary>An attempt was made to map a file that is already mapped.</summary>
		public const uint STATUS_NDIS_ALREADY_MAPPED = 0xC023001D;
		/// <summary>An attempt to allocate a hardware resource failed because the resource is used by another component.</summary>
		public const uint STATUS_NDIS_RESOURCE_CONFLICT = 0xC023001E;
		/// <summary>The I/O operation failed because the network media is disconnected or the wireless access point is out of range.</summary>
		public const uint STATUS_NDIS_MEDIA_DISCONNECTED = 0xC023001F;
		/// <summary>The network address used in the request is invalid.</summary>
		public const uint STATUS_NDIS_INVALID_ADDRESS = 0xC0230022;
		/// <summary>The offload operation on the network interface has been paused.</summary>
		public const uint STATUS_NDIS_PAUSED = 0xC023002A;
		/// <summary>The network interface was not found.</summary>
		public const uint STATUS_NDIS_INTERFACE_NOT_FOUND = 0xC023002B;
		/// <summary>The revision number specified in the structure is not supported.</summary>
		public const uint STATUS_NDIS_UNSUPPORTED_REVISION = 0xC023002C;
		/// <summary>The specified port does not exist on this network interface.</summary>
		public const uint STATUS_NDIS_INVALID_PORT = 0xC023002D;
		/// <summary>The current state of the specified port on this network interface does not support the requested operation.</summary>
		public const uint STATUS_NDIS_INVALID_PORT_STATE = 0xC023002E;
		/// <summary>The miniport adapter is in a lower power state.</summary>
		public const uint STATUS_NDIS_LOW_POWER_STATE = 0xC023002F;
		/// <summary>The network interface does not support this request.</summary>
		public const uint STATUS_NDIS_NOT_SUPPORTED = 0xC02300BB;
		/// <summary>The TCP connection is not offloadable because of a local policy setting.</summary>
		public const uint STATUS_NDIS_OFFLOAD_POLICY = 0xC023100F;
		/// <summary>The TCP connection is not offloadable by the Chimney offload target.</summary>
		public const uint STATUS_NDIS_OFFLOAD_CONNECTION_REJECTED = 0xC0231012;
		/// <summary>The IP Path object is not in an offloadable state.</summary>
		public const uint STATUS_NDIS_OFFLOAD_PATH_REJECTED = 0xC0231013;
		/// <summary>The wireless LAN interface is in auto-configuration mode and does not support the requested parameter change operation.</summary>
		public const uint STATUS_NDIS_DOT11_AUTO_CONFIG_ENABLED = 0xC0232000;
		/// <summary>The wireless LAN interface is busy and cannot perform the requested operation.</summary>
		public const uint STATUS_NDIS_DOT11_MEDIA_IN_USE = 0xC0232001;
		/// <summary>The wireless LAN interface is power down and does not support the requested operation.</summary>
		public const uint STATUS_NDIS_DOT11_POWER_STATE_INVALID = 0xC0232002;
		/// <summary>The list of wake on LAN patterns is full.</summary>
		public const uint STATUS_NDIS_PM_WOL_PATTERN_LIST_FULL = 0xC0232003;
		/// <summary>The list of low power protocol offloads is full.</summary>
		public const uint STATUS_NDIS_PM_PROTOCOL_OFFLOAD_LIST_FULL = 0xC0232004;
		/// <summary>The SPI in the packet does not match a valid IPsec SA.</summary>
		public const uint STATUS_IPSEC_BAD_SPI = 0xC0360001;
		/// <summary>The packet was received on an IPsec SA whose lifetime has expired.</summary>
		public const uint STATUS_IPSEC_SA_LIFETIME_EXPIRED = 0xC0360002;
		/// <summary>The packet was received on an IPsec SA that does not match the packet characteristics.</summary>
		public const uint STATUS_IPSEC_WRONG_SA = 0xC0360003;
		/// <summary>The packet sequence number replay check failed.</summary>
		public const uint STATUS_IPSEC_REPLAY_CHECK_FAILED = 0xC0360004;
		/// <summary>The IPsec header and/or trailer in the packet is invalid.</summary>
		public const uint STATUS_IPSEC_INVALID_PACKET = 0xC0360005;
		/// <summary>The IPsec integrity check failed.</summary>
		public const uint STATUS_IPSEC_INTEGRITY_CHECK_FAILED = 0xC0360006;
		/// <summary>IPsec dropped a clear text packet.</summary>
		public const uint STATUS_IPSEC_CLEAR_TEXT_DROP = 0xC0360007;
		/// <summary>IPsec dropped an incoming ESP packet in authenticated firewall mode.  This drop is benign.</summary>
		public const uint STATUS_IPSEC_AUTH_FIREWALL_DROP = 0xC0360008;
		/// <summary>IPsec dropped a packet due to DOS throttle.</summary>
		public const uint STATUS_IPSEC_THROTTLE_DROP = 0xC0360009;
		/// <summary>IPsec Dos Protection matched an explicit block rule.</summary>
		public const uint STATUS_IPSEC_DOSP_BLOCK = 0xC0368000;
		/// <summary>IPsec Dos Protection received an IPsec specific multicast packet which is not allowed.</summary>
		public const uint STATUS_IPSEC_DOSP_RECEIVED_MULTICAST = 0xC0368001;
		/// <summary>IPsec Dos Protection received an incorrectly formatted packet.</summary>
		public const uint STATUS_IPSEC_DOSP_INVALID_PACKET = 0xC0368002;
		/// <summary>IPsec Dos Protection failed to lookup state.</summary>
		public const uint STATUS_IPSEC_DOSP_STATE_LOOKUP_FAILED = 0xC0368003;
		/// <summary>IPsec Dos Protection failed to create state because there are already maximum number of entries allowed by policy.</summary>
		public const uint STATUS_IPSEC_DOSP_MAX_ENTRIES = 0xC0368004;
		/// <summary>IPsec Dos Protection received an IPsec negotiation packet for a keying module which is not allowed by policy.</summary>
		public const uint STATUS_IPSEC_DOSP_KEYMOD_NOT_ALLOWED = 0xC0368005;
		/// <summary>IPsec Dos Protection failed to create per internal IP ratelimit queue because there is already maximum number of queues allowed by policy.</summary>
		public const uint STATUS_IPSEC_DOSP_MAX_PER_IP_RATELIMIT_QUEUES = 0xC0368006;
		/// <summary>The system does not support mirrored volumes.</summary>
		public const uint STATUS_VOLMGR_MIRROR_NOT_SUPPORTED = 0xC038005B;
		/// <summary>The system does not support RAID-5 volumes.</summary>
		public const uint STATUS_VOLMGR_RAID5_NOT_SUPPORTED = 0xC038005C;
		/// <summary>A virtual disk support provider for the specified file was not found.</summary>
		public const uint STATUS_VIRTDISK_PROVIDER_NOT_FOUND = 0xC03A0014;
		/// <summary>The specified disk is not a virtual disk.</summary>
		public const uint STATUS_VIRTDISK_NOT_VIRTUAL_DISK = 0xC03A0015;
		/// <summary>The chain of virtual hard disks is inaccessible. The process has not been granted access rights to the parent virtual hard disk for the differencing disk.</summary>
		public const uint STATUS_VHD_PARENT_VHD_ACCESS_DENIED = 0xC03A0016;
		/// <summary>The chain of virtual hard disks is corrupted. There is a mismatch in the virtual sizes of the parent virtual hard disk and differencing disk.</summary>
		public const uint STATUS_VHD_CHILD_PARENT_SIZE_MISMATCH = 0xC03A0017;
		/// <summary>The chain of virtual hard disks is corrupted. A differencing disk is indicated in its own parent chain.</summary>
		public const uint STATUS_VHD_DIFFERENCING_CHAIN_CYCLE_DETECTED = 0xC03A0018;
		/// <summary>The chain of virtual hard disks is inaccessible. There was an error opening a virtual hard disk further up the chain.</summary>
		public const uint STATUS_VHD_DIFFERENCING_CHAIN_ERROR_IN_PARENT = 0xC03A0019;
	}
}