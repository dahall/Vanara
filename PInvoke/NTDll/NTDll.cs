using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using Vanara.Extensions;
using Vanara.Extensions.Reflection;
using Vanara.InteropServices;
using static Vanara.PInvoke.Kernel32;

namespace Vanara.PInvoke
{
	/// <summary>Platform invokable enumerated types, constants and functions from ntdll.h</summary>
	public static partial class NtDll
	{
		/// <summary>
		/// <para>[This function may be changed or removed from Windows without further notice.]</para>
		/// <para>
		/// A notification callback function specified with the <c>LdrRegisterDllNotification</c> function. The loader calls this function
		/// when a DLL is first loaded.
		/// </para>
		/// <para><c>Warning:</c> It is unsafe for the notification callback function to call functions in any DLL.</para>
		/// </summary>
		/// <returns>
		/// <para>This callback function does not return a value.</para>
		/// </returns>
		/// <remarks>
		/// <para>The notification callback function is called before dynamic linking takes place.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/DevNotes/ldrdllnotification VOID CALLBACK LdrDllNotification( _In_ ULONG
		// NotificationReason, _In_ PCLDR_DLL_NOTIFICATION_DATA NotificationData, _In_opt_ PVOID Context );
		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		[PInvokeData("ntldr.h", MSDNShortId = "12202797-c80c-4fa3-9cc4-dcb1a9f01551")]
		public delegate void LdrDllNotification(uint NotificationReason, ref LDR_DLL_NOTIFICATION_DATA NotificationData, [In, Optional] IntPtr Context);

		/// <summary>
		/// <para>The <c>KEY_INFORMATION_CLASS</c> enumeration type represents the type of information to supply about a registry key.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// Use the <c>KEY_INFORMATION_CLASS</c> values to specify the type of data to be supplied by the ZwEnumerateKey and ZwQueryKey routines.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows-hardware/drivers/ddi/content/wdm/ne-wdm-_key_information_class typedef enum
		// _KEY_INFORMATION_CLASS { KeyBasicInformation , KeyNodeInformation , KeyFullInformation , KeyNameInformation , KeyCachedInformation
		// , KeyFlagsInformation , KeyVirtualizationInformation , KeyHandleTagsInformation , KeyTrustInformation , KeyLayerInformation ,
		// MaxKeyInfoClass } KEY_INFORMATION_CLASS;
		[PInvokeData("wdm.h", MSDNShortId = "cb531a0e-c934-4f3e-9b92-07eb3ab75673")]
		public enum KEY_INFORMATION_CLASS : uint
		{
			/// <summary>A KEY_BASIC_INFORMATION structure is supplied.</summary>
			[CorrespondingType(typeof(KEY_BASIC_INFORMATION))]
			KeyBasicInformation,

			/// <summary>A KEY_NODE_INFORMATION structure is supplied.</summary>
			[CorrespondingType(typeof(KEY_NODE_INFORMATION))]
			KeyNodeInformation,

			/// <summary>A KEY_FULL_INFORMATION structure is supplied.</summary>
			[CorrespondingType(typeof(KEY_FULL_INFORMATION))]
			KeyFullInformation,

			/// <summary>A KEY_NAME_INFORMATION structure is supplied.</summary>
			[CorrespondingType(typeof(KEY_NAME_INFORMATION))]
			KeyNameInformation,

			/// <summary>A KEY_CACHED_INFORMATION structure is supplied.</summary>
			KeyCachedInformation,

			/// <summary>Reserved for system use.</summary>
			KeyFlagsInformation,

			/// <summary>A KEY_VIRTUALIZATION_INFORMATION structure is supplied.</summary>
			KeyVirtualizationInformation,

			/// <summary>Reserved for system use.</summary>
			KeyHandleTagsInformation,

			/// <summary/>
			KeyTrustInformation,

			/// <summary/>
			KeyLayerInformation,

			/// <summary>The maximum value in this enumeration type.</summary>
			MaxKeyInfoClass,
		}

		/// <summary>Lists the different types of notifications that can be received by an enlistment.</summary>
		[PInvokeData("ktmtypes.h", MSDNShortId = "32c2be6a-c75a-9391-274d-a53a6e2b74c8")]
		public enum NOTIFICATION_MASK
		{
			/// <summary>A mask that indicates all valid bits for a transaction notification.</summary>
			TRANSACTION_NOTIFY_MASK = 0x3FFFFFFF,

			/// <summary>
			/// This notification is called after a client calls CommitTransaction and either no resource manager (RM) supports single-phase
			/// commit or a superior transaction manager (TM) calls PrePrepareEnlistment. This notification is received by the RMs indicating
			/// that they should complete any work that could cause other RMs to need to enlist in a transaction, such as flushing its cache.
			/// After completing these operations the RM must call PrePrepareComplete. To receive this notification the RM must also support
			/// TRANSACTION_NOTIFY_PREPARE and TRANSACTION_NOTIFY_COMMIT.
			/// </summary>
			TRANSACTION_NOTIFY_PREPREPARE = 0x00000001,

			/// <summary>
			/// This notification is called after the TRANSACTION_NOTIFY_PREPREPARE processing is complete. It signals the RM to complete all
			/// the work that is associated with this enlistment so that it can guarantee that a commit operation could succeed and an abort
			/// operation could also succeed. Typically, the bulk of the work for a transaction is done during the prepare phase. For durable
			/// RMs, they must log their state prior to calling the PrepareComplete function. This is the last chance for the RM to request
			/// that the transaction be rolled back.
			/// </summary>
			TRANSACTION_NOTIFY_PREPARE = 0x00000002,

			/// <summary>
			/// This notification signals the RM to complete all the work that is associated with this enlistment. Typically, the RM releases
			/// any locks, releases any information necessary to roll back the transaction. The RM must respond by calling the CommitComplete
			/// function when it has finished these operations.
			/// </summary>
			TRANSACTION_NOTIFY_COMMIT = 0x00000004,

			/// <summary>This notification signals the RM to undo all the work it has done that is associated with the transaction.</summary>
			TRANSACTION_NOTIFY_ROLLBACK = 0x00000008,

			/// <summary>This notification signals to the superior TM that a pre-prepare operation was completed successfully.</summary>
			TRANSACTION_NOTIFY_PREPREPARE_COMPLETE = 0x00000010,

			/// <summary>This notification signals to the superior TM that a prepare operation was completed successfully.</summary>
			TRANSACTION_NOTIFY_PREPARE_COMPLETE = 0x00000020,

			/// <summary>This notification signals to the superior TM that a commit operation was completed successfully.</summary>
			TRANSACTION_NOTIFY_COMMIT_COMPLETE = 0x00000040,

			/// <summary>This notification signals to the superior TM that a rollback operation was completed successfully.</summary>
			TRANSACTION_NOTIFY_ROLLBACK_COMPLETE = 0x00000080,

			/// <summary>
			/// This notification signals to RMs that they should recover their state because a transaction outcome must be redelivered. For
			/// example, when an RM is recovered, and when there are transactions left in-doubt. This notification is delivered once the
			/// in-doubt state is resolved.
			/// </summary>
			TRANSACTION_NOTIFY_RECOVER = 0x00000100,

			/// <summary>
			/// This notification signals the RM to complete and commit the transaction without using a two-phase commit protocol. If the RM
			/// wants to use a two-phase operation, it must respond by calling the SinglePhaseReject function.
			/// </summary>
			TRANSACTION_NOTIFY_SINGLE_PHASE_COMMIT = 0x00000200,

			/// <summary>KTM is signaling to the superior TM to perform a commit operation.</summary>
			TRANSACTION_NOTIFY_DELEGATE_COMMIT = 0x00000400,

			/// <summary>KTM is signaling to the superior TM to query the status of an in-doubt transaction.</summary>
			TRANSACTION_NOTIFY_RECOVER_QUERY = 0x00000800,

			/// <summary>
			/// This notification signals to the superior TM that pre-prepare notifications must be delivered on the specified enlistment.
			/// </summary>
			TRANSACTION_NOTIFY_ENLIST_PREPREPARE = 0x00001000,

			/// <summary>This notification indicates that the recovery operation is complete for this RM.</summary>
			TRANSACTION_NOTIFY_LAST_RECOVER = 0x00002000,

			/// <summary>
			/// The specified transaction is in an in-doubt state. The RM receives this notification during recovery operations when a
			/// transaction has been prepared, but there is no superior transaction manager (TM) available. For example, when a transaction
			/// involves a remote TM and that node is unavailable, its node is unavailable, or the local Distributed Transaction Coordinator
			/// service is unavailable, the transaction state is in-doubt.
			/// </summary>
			TRANSACTION_NOTIFY_INDOUBT = 0x00004000,

			/// <summary>Undocumented or not supported.</summary>
			TRANSACTION_NOTIFY_PROPAGATE_PULL = 0x00008000,

			/// <summary>Undocumented or not supported.</summary>
			TRANSACTION_NOTIFY_PROPAGATE_PUSH = 0x00010000,

			/// <summary>Undocumented or not supported.</summary>
			TRANSACTION_NOTIFY_MARSHAL = 0x00020000,

			/// <summary>Undocumented or not supported.</summary>
			TRANSACTION_NOTIFY_ENLIST_MASK = 0x00040000,

			/// <summary>Undocumented or not supported.</summary>
			TRANSACTION_NOTIFY_RM_DISCONNECTED = 0x01000000,

			/// <summary>Undocumented or not supported.</summary>
			TRANSACTION_NOTIFY_TM_ONLINE = 0x02000000,

			/// <summary>Undocumented or not supported.</summary>
			TRANSACTION_NOTIFY_COMMIT_REQUEST = 0x04000000,

			/// <summary>Undocumented or not supported.</summary>
			TRANSACTION_NOTIFY_PROMOTE = 0x08000000,

			/// <summary>Undocumented or not supported.</summary>
			TRANSACTION_NOTIFY_PROMOTE_NEW = 0x10000000,

			/// <summary>
			/// Signals to RMs that there is outcome information available, and that a request for that information should be made.
			/// </summary>
			TRANSACTION_NOTIFY_REQUEST_OUTCOME = 0x20000000,

			/// <summary>Reserved.</summary>
			TRANSACTION_NOTIFY_COMMIT_FINALIZE = 0x40000000,
		}

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
			/// from alerts. This flag also causes the I/O system to maintain the file-position pointer. If this flag is set, the SYNCHRONIZE
			/// flag must be set in the DesiredAccess parameter.
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
			/// Create a tree connection for this file in order to open it over the network. This flag is not used by device and intermediate drivers.
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
			/// Access to the file can be random, so no sequential read-ahead operations should be performed by file-system drivers or by the system.
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
			/// character may proceed these binary values. For example, a device name will have the following format. This number is assigned
			/// by and specific to the particular file system.
			/// </summary>
			FILE_OPEN_BY_FILE_ID = 0x00002000,

			/// <summary>
			/// The file is being opened for backup intent. Therefore, the system should check for certain access rights and grant the caller
			/// the appropriate access to the file—before checking the DesiredAccess parameter against the file's security descriptor. This
			/// flag not used by device and intermediate drivers.
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

		/// <summary>Indicates the kind of system information to be retrieved by <see cref="NtQuerySystemInformation"/>.</summary>
		[PInvokeData("winternl.h", MSDNShortId = "553ec7b9-c5eb-4955-8dc0-f1c06f59fe31")]
		public enum SYSTEM_INFORMATION_CLASS
		{
			/// <summary>
			/// Returns the number of processors in the system in a SYSTEM_BASIC_INFORMATION structure. Use the GetSystemInfo function instead.
			/// </summary>
			[Obsolete("Use the GetSystemInfo function instead.")]
			[CorrespondingType(typeof(SYSTEM_BASIC_INFORMATION))]
			SystemBasicInformation = 0,

			/// <summary>
			/// Returns an opaque SYSTEM_PERFORMANCE_INFORMATION structure that can be used to generate an unpredictable seed for a random
			/// number generator. Use the CryptGenRandomfunction instead.
			/// </summary>
			[Obsolete("Use the CryptGenRandomfunction function instead.")]
			SystemPerformanceInformation = 2,

			/// <summary>
			/// Returns an opaque SYSTEM_TIMEOFDAY_INFORMATION structure that can be used to generate an unpredictable seed for a random
			/// number generator. Use the CryptGenRandom function instead.
			/// </summary>
			[Obsolete("Use the CryptGenRandom function instead.")]
			SystemTimeOfDayInformation = 3,

			/// <summary>
			/// Returns an array of SYSTEM_PROCESS_INFORMATION structures, one for each process running in the system.
			/// <para>
			/// These structures contain information about the resource usage of each process, including the number of threads and handles
			/// used by the process, the peak page-file usage, and the number of memory pages that the process has allocated.
			/// </para>
			/// </summary>
			[CorrespondingType(typeof(SYSTEM_PROCESS_INFORMATION[]))]
			SystemProcessInformation = 5,

			/// <summary>
			/// Returns an array of SYSTEM_PROCESSOR_PERFORMANCE_INFORMATION structures, one for each processor installed in the system.
			/// </summary>
			[CorrespondingType(typeof(SYSTEM_PROCESSOR_PERFORMANCE_INFORMATION[]))]
			SystemProcessorPerformanceInformation = 8,

			/// <summary>
			/// Returns an opaque SYSTEM_INTERRUPT_INFORMATION structure that can be used to generate an unpredictable seed for a random
			/// number generator. Use the CryptGenRandom function instead.
			/// </summary>
			[Obsolete("Use the CryptGenRandom function instead.")]
			SystemInterruptInformation = 23,

			/// <summary>
			/// Returns an opaque SYSTEM_EXCEPTION_INFORMATION structure that can be used to generate an unpredictable seed for a random
			/// number generator. Use the CryptGenRandom function instead.
			/// </summary>
			[Obsolete("Use the CryptGenRandom function instead.")]
			SystemExceptionInformation = 33,

			/// <summary>Returns a SYSTEM_REGISTRY_QUOTA_INFORMATION structure.</summary>
			[CorrespondingType(typeof(SYSTEM_REGISTRY_QUOTA_INFORMATION))]
			SystemRegistryQuotaInformation = 37,

			/// <summary>
			/// Returns an opaque SYSTEM_LOOKASIDE_INFORMATION structure that can be used to generate an unpredictable seed for a random
			/// number generator. Use the CryptGenRandom function instead.
			/// </summary>
			[Obsolete("Use the CryptGenRandom function instead.")]
			SystemLookasideInformation = 45,

			/// <summary>
			/// Returns policy information in a SYSTEM_POLICY_INFORMATION structure. Use the SLGetWindowsInformation function instead to
			/// obtain policy information.
			/// </summary>
			[Obsolete("Use the SLGetWindowsInformation function instead.")]
			SystemPolicyInformation = 134,
		}

		/// <summary>
		/// <para>The <c>DbgBreakPoint</c> routine breaks into the kernel debugger.</para>
		/// </summary>
		/// <returns>
		/// <para>None</para>
		/// </returns>
		/// <remarks>
		/// <para>The <c>DbgBreakPoint</c> routine is the kernel-mode equivalent of <c>DebugBreak</c>.</para>
		/// <para>
		/// This routine raises an exception that is handled by the kernel debugger if one is installed; otherwise, it is handled by the
		/// debug system. If a debugger is not connected to the system, the exception can be handled in the standard way.
		/// </para>
		/// <para>
		/// In kernel mode, a break exception that is not handled will cause a bug check. You can, however, connect a kernel-mode debugger to
		/// a target computer that has stopped responding and has kernel debugging enabled. For more information, see Windows Debugging.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows-hardware/drivers/ddi/content/wdm/nf-wdm-dbgbreakpoint __analysis_noreturn VOID
		// DbgBreakPoint( );
		[DllImport(Lib.NtDll, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("wdm.h", MSDNShortId = "deeac910-2cc3-4a54-bf3b-aeb56d0004dc")]
		public static extern void DbgBreakPoint();

		/// <summary>
		/// <para>
		/// The <c>DbgPrompt</c> routine displays a caller-specified user prompt string on the kernel debugger's display device and obtains a
		/// user response string.
		/// </para>
		/// </summary>
		/// <param name="Prompt">
		/// <para>
		/// A pointer to a NULL-terminated constant character string that the debugger will display as a user prompt. The maximum size of
		/// this string is 512 characters.
		/// </para>
		/// </param>
		/// <param name="Response">
		/// <para>
		/// A pointer to a character array buffer that receives the user's response, including a terminating newline character. The maximum
		/// size of this buffer is 512 characters.
		/// </para>
		/// </param>
		/// <param name="Length">
		/// <para>TBD</para>
		/// </param>
		/// <returns>
		/// <para>
		/// <c>DbgPrompt</c> returns the number of characters that the Response buffer received, including the terminating newline character.
		/// <c>DbgPrompt</c> returns zero if it receives no characters.
		/// </para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The <c>DbgPrompt</c> routine displays the specified prompt string on the kernel debugger's display device and then reads a line
		/// of user input text.
		/// </para>
		/// <para>
		/// After <c>DbgPrompt</c> returns, the Response buffer contains the user's response, including the terminating newline character.
		/// The user response string is not NULL-terminated.
		/// </para>
		/// <para>
		/// The following code example asks if the user wants to continue and accepts the letter "y" for yes and the letter "n" for no.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows-hardware/drivers/ddi/content/ntddk/nf-ntddk-dbgprompt NTSYSAPI ULONG DbgPrompt( PCCH
		// Prompt, PCH Response, ULONG Length );
		[DllImport(Lib.NtDll, SetLastError = false, ExactSpelling = true, CharSet = CharSet.Ansi)]
		[PInvokeData("ntddk.h", MSDNShortId = "4bb44aab-7032-4cc7-89e3-6ac3bee233d3")]
		public static extern uint DbgPrompt(string Prompt, StringBuilder Response, uint Length);

		/// <summary>
		/// <para>
		/// [Some information relates to pre-released product which may be substantially modified before it's commercially released.
		/// Microsoft makes no warranties, express or implied, with respect to the information provided here.]
		/// </para>
		/// <para>
		/// This function forcefully terminates the calling program if it is invoked inside a loader callout. Otherwise, it has no effect.
		/// </para>
		/// </summary>
		/// <returns>
		/// <para>This function does not return a value.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// This routine does not catch all potential deadlock cases; it is possible for a thread inside a loader callout to acquire a lock
		/// while some thread outside a loader callout holds the same lock and makes a call into the loader. In other words, there can be a
		/// lock order inversion between the loader lock and a client lock.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/DevNotes/ldrfastfailinloadercallout VOID NTAPI LdrFastFailInLoaderCallout(void);
		[DllImport(Lib.NtDll, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("ntldr.h", MSDNShortId = "5C10BF04-B7C7-4481-A184-FDD418FE5F52")]
		public static extern void LdrFastFailInLoaderCallout();

		/// <summary>
		/// <para>[This function may be changed or removed from Windows without further notice.]</para>
		/// <para>Registers for notification when a DLL is first loaded. This notification occurs before dynamic linking takes place.</para>
		/// </summary>
		/// <param name="Flags">This parameter must be zero.</param>
		/// <param name="NotificationFunction">A pointer to an LdrDllNotification notification callback function to call when the DLL is loaded.</param>
		/// <param name="Context">A pointer to context data for the callback function.</param>
		/// <param name="Cookie">A pointer to a variable to receive an identifier for the callback function. This identifier is used to unregister the notification callback function.</param>
		/// <returns>
		/// <para>If the function succeeds, it returns <c>STATUS_SUCCESS</c>.</para>
		/// <para>
		/// The forms and significance of <c>NTSTATUS</c> error codes are listed in the Ntstatus.h header file available in the WDK, and are
		/// described in the WDK documentation.
		/// </para>
		/// </returns>
		/// <remarks>
		/// This function has no associated header file. The associated import library, Ntdll.lib, is available in the WDK. You can also use
		/// the <c>LoadLibrary</c> and <c>GetProcAddress</c> functions to dynamically link to Ntdll.dll.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/devnotes/ldrregisterdllnotification
		// NTSTATUS NTAPI LdrRegisterDllNotification( _In_ ULONG Flags, _In_ PLDR_DLL_NOTIFICATION_FUNCTION NotificationFunction, _In_opt_ PVOID Context, _Out_ PVOID *Cookie );
		[DllImport(Lib.NtDll, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("", MSDNShortId = "c2757aa0-76fa-427a-a4f6-cb26e7f7d0d1")]
		public static extern NTStatus LdrRegisterDllNotification([Optional] uint Flags, LdrDllNotification NotificationFunction, [Optional] IntPtr Context, out IntPtr Cookie);

		/// <summary>
		/// <para>[This function may be changed or removed from Windows without further notice.]</para>
		/// <para>Cancels DLL load notification previously registered by calling the <c>LdrRegisterDllNotification</c> function.</para>
		/// </summary>
		/// <returns>
		/// <para>Returns an <c>NTSTATUS</c> or error code.</para>
		/// <para>If the function succeeds, it returns <c>STATUS_SUCCESS</c>.</para>
		/// <para>If the callback function is not found, the function returns <c>STATUS_DLL_NOT_FOUND</c>.</para>
		/// <para>
		/// The forms and significance of <c>NTSTATUS</c> error codes are listed in the Ntstatus.h header file available in the WDK, and are
		/// described in the WDK documentation.
		/// </para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// This function has no associated header file. The associated import library, Ntdll.lib, is available in the WDK. You can also use
		/// the <c>LoadLibrary</c> and <c>GetProcAddress</c> functions to dynamically link to Ntdll.dll.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/DevNotes/ldrunregisterdllnotification NTSTATUS NTAPI
		// LdrUnregisterDllNotification( _In_ PVOID Cookie );
		[DllImport(Lib.NtDll, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("ntldr.h", MSDNShortId = "18c3a027-e3cb-4083-afdc-00f416a70d8c")]
		public static extern NTStatus LdrUnregisterDllNotification([In] IntPtr Cookie);

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
		/// system determines where to allocate the region, as when BaseAddress is <c>NULL</c>. Note that when ZeroBits is larger than 32, it
		/// becomes a bitmask.
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
		/// STATUS_GUARD_PAGE exception. Guard pages thus act as a one-shot access alarm. This flag is a page protection modifier, valid only
		/// when used with one of the page protection flags other than PAGE_NOACCESS. When an access attempt leads the system to turn off
		/// guard page status, the underlying page protection takes over. If a guard page exception occurs during a system service, the
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
		/// <para>Deprecated. Closes the specified handle. <c>NtClose</c> is superseded by CloseHandle.</para>
		/// </summary>
		/// <param name="Handle">
		/// <para>The handle being closed.</para>
		/// </param>
		/// <returns>
		/// <para>The various NTSTATUS values are defined in NTSTATUS.H, which is distributed with the Windows DDK.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>STATUS_SUCCESS</term>
		/// <term>The handle was closed.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>The <c>NtClose</c> function closes handles to the following objects.</para>
		/// <list type="bullet">
		/// <item>
		/// <term>Access token</term>
		/// </item>
		/// <item>
		/// <term>Communications device</term>
		/// </item>
		/// <item>
		/// <term>Console input</term>
		/// </item>
		/// <item>
		/// <term>Console screen buffer</term>
		/// </item>
		/// <item>
		/// <term>Event</term>
		/// </item>
		/// <item>
		/// <term>File</term>
		/// </item>
		/// <item>
		/// <term>File mapping</term>
		/// </item>
		/// <item>
		/// <term>Job</term>
		/// </item>
		/// <item>
		/// <term>Mailslot</term>
		/// </item>
		/// <item>
		/// <term>Mutex</term>
		/// </item>
		/// <item>
		/// <term>Named pipe</term>
		/// </item>
		/// <item>
		/// <term>Process</term>
		/// </item>
		/// <item>
		/// <term>Semaphore</term>
		/// </item>
		/// <item>
		/// <term>Socket</term>
		/// </item>
		/// <item>
		/// <term>Thread</term>
		/// </item>
		/// </list>
		/// <para>Because there is no import library for this function, you must use GetProcAddress.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winternl/nf-winternl-ntclose __kernel_entry NTSTATUS NtClose( IN HANDLE
		// Handle );
		[DllImport(Lib.NtDll, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("winternl.h")]
		[Obsolete]
		public static extern NTStatus NtClose(IntPtr Handle);

		/// <summary>
		/// <para>
		/// The <c>ZwCommitComplete</c> routine notifies KTM that the calling resource manager has finished committing a transaction's data.
		/// </para>
		/// </summary>
		/// <param name="EnlistmentHandle">
		/// <para>
		/// A handle to an enlistment object that was obtained by a previous call to ZwCreateEnlistment or ZwOpenEnlistment. The handle must
		/// have ENLISTMENT_SUBORDINATE_RIGHTS access to the object.
		/// </para>
		/// </param>
		/// <param name="TmVirtualClock">
		/// <para>A pointer to a virtual clock value. This parameter is optional and can be <c>NULL</c>.</para>
		/// </param>
		/// <returns>
		/// <para>
		/// <c>ZwCommitComplete</c> returns STATUS_SUCCESS if the operation succeeds. Otherwise, this routine might return one of the
		/// following values:
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>STATUS_OBJECT_TYPE_MISMATCH</term>
		/// <term>The specified handle is not a handle to an enlistment object.</term>
		/// </item>
		/// <item>
		/// <term>STATUS_INVALID_HANDLE</term>
		/// <term>The object handle is invalid.</term>
		/// </item>
		/// <item>
		/// <term>STATUS_ACCESS_DENIED</term>
		/// <term>The caller does not have appropriate access to the enlistment object.</term>
		/// </item>
		/// <item>
		/// <term>STATUS_TRANSACTION_NOT_REQUESTED</term>
		/// <term>The transaction or its enlistment is not in the correct state.</term>
		/// </item>
		/// </list>
		/// <para>The routine might return other NTSTATUS values.</para>
		/// </returns>
		/// <remarks>
		/// <para>A resource manager must call <c>ZwCommitComplete</c> after it has finished servicing a TRANSACTION_NOTIFY_COMMIT notification.</para>
		/// <para>For more information about <c>ZwCommitComplete</c>, see Handling Commit Operations.</para>
		/// <para>
		/// For calls from kernel-mode drivers, the <c>NtXxx</c> and <c>ZwXxx</c> versions of a Windows Native System Services routine can
		/// behave differently in the way that they handle and interpret input parameters. For more information about the relationship
		/// between the <c>NtXxx</c> and <c>ZwXxx</c> versions of a routine, see Using Nt and Zw Versions of the Native System Services Routines.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows-hardware/drivers/ddi/content/wdm/nf-wdm-ntcommitcomplete __kernel_entry NTSYSCALLAPI
		// NTSTATUS NtCommitComplete( HANDLE EnlistmentHandle, PLARGE_INTEGER TmVirtualClock );
		[DllImport(Lib.NtDll, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("wdm.h", MSDNShortId = "d0b968bc-bbab-4b6f-bb1f-9e36ac7c1e05")]
		public static extern NTStatus NtCommitComplete(SafeEnlistmentHandle EnlistmentHandle, ref long TmVirtualClock);

		/// <summary>
		/// <para>The <c>ZwCommitEnlistment</c> routine initiates the commit operation for a specified enlistment's transaction.</para>
		/// </summary>
		/// <param name="EnlistmentHandle">
		/// <para>
		/// A handle to an enlistment object that was obtained by a previous call to ZwCreateEnlistment or ZwOpenEnlistment. The object must
		/// represent a superior enlistment and the handle must have ENLISTMENT_SUPERIOR_RIGHTS access to the object.
		/// </para>
		/// </param>
		/// <param name="TmVirtualClock">
		/// <para>A pointer to a virtual clock value. This parameter is optional and can be <c>NULL</c>.</para>
		/// </param>
		/// <returns>
		/// <para>
		/// <c>ZwCommitEnlistment</c> returns STATUS_SUCCESS if the operation succeeds. Otherwise, this routine might return one of the
		/// following values:
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>STATUS_OBJECT_TYPE_MISMATCH</term>
		/// <term>The specified handle is not a handle to an enlistment object.</term>
		/// </item>
		/// <item>
		/// <term>STATUS_INVALID_HANDLE</term>
		/// <term>The object handle is invalid.</term>
		/// </item>
		/// <item>
		/// <term>STATUS_ACCESS_DENIED</term>
		/// <term>The caller does not have appropriate access to the enlistment object.</term>
		/// </item>
		/// <item>
		/// <term>STATUS_ENLISTMENT_NOT_SUPERIOR</term>
		/// <term>The caller is not a superior transaction manager for the enlistment.</term>
		/// </item>
		/// <item>
		/// <term>STATUS_TRANSACTION_RESPONSE_NOT_ENLISTED</term>
		/// <term>The caller did not register to receive TRANSACTION_NOTIFY_COMMIT_COMPLETE notifications.</term>
		/// </item>
		/// <item>
		/// <term>STATUS_TRANSACTION_REQUEST_NOT_VALID</term>
		/// <term>The enlistment's transaction is not in a state that allows it to be committed.</term>
		/// </item>
		/// <item>
		/// <term>STATUS_TRANSACTION_NOT_ACTIVE</term>
		/// <term>The commit operation for this transaction has already been started.</term>
		/// </item>
		/// <item>
		/// <term>STATUS_TRANSACTION_ALREADY_ABORTED</term>
		/// <term>The transaction cannot be committed because it has been rolled back.</term>
		/// </item>
		/// </list>
		/// <para>The routine might return other NTSTATUS values.</para>
		/// </returns>
		/// <remarks>
		/// <para>Only superior transaction managers can call <c>ZwCommitEnlistment</c>.</para>
		/// <para>Callers of <c>ZwCommitEnlistment</c> must register to receive TRANSACTION_NOTIFY_COMMIT_COMPLETE notifications.</para>
		/// <para>
		/// The <c>ZwCommitEnlistment</c> routine causes KTM to send TRANSACTION_NOTIFY_COMMIT notifications to all resource managers that
		/// have enlisted in the transaction.
		/// </para>
		/// <para>
		/// For more information about <c>ZwCommitEnlistment</c>, see Creating a Superior Transaction Manager and Handling Commit Operations.
		/// </para>
		/// <para>
		/// For calls from kernel-mode drivers, the <c>NtXxx</c> and <c>ZwXxx</c> versions of a Windows Native System Services routine can
		/// behave differently in the way that they handle and interpret input parameters. For more information about the relationship
		/// between the <c>NtXxx</c> and <c>ZwXxx</c> versions of a routine, see Using Nt and Zw Versions of the Native System Services Routines.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows-hardware/drivers/ddi/content/wdm/nf-wdm-ntcommitenlistment __kernel_entry NTSYSCALLAPI
		// NTSTATUS NtCommitEnlistment( HANDLE EnlistmentHandle, PLARGE_INTEGER TmVirtualClock );
		[DllImport(Lib.NtDll, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("wdm.h", MSDNShortId = "9c7f3e24-1d7c-450e-bbef-df0479911bc6")]
		public static extern NTStatus NtCommitEnlistment(SafeEnlistmentHandle EnlistmentHandle, ref long TmVirtualClock);

		/// <summary>
		/// <para>The <c>ZwCommitTransaction</c> routine initiates a commit operation for a specified transaction.</para>
		/// </summary>
		/// <param name="TransactionHandle">
		/// <para>
		/// A handle to a transaction object. Your component receives this handle from ZwCreateTransaction or ZwOpenTransaction. The handle
		/// must have TRANSACTION_COMMIT access to the object.
		/// </para>
		/// </param>
		/// <param name="Wait">
		/// <para>
		/// A Boolean value that the caller sets to <c>TRUE</c> for synchronous operation or <c>FALSE</c> for asynchronous operation. If this
		/// parameter is <c>TRUE</c>, the call returns after the commit operation is complete.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>
		/// <c>ZwCommitTransaction</c> returns STATUS_SUCCESS if the operation succeeds. Otherwise, this routine might return one of the
		/// following values:
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>STATUS_OBJECT_TYPE_MISMATCH</term>
		/// <term>The handle that was specified for the TransactionHandle parameter is not a handle to a transaction object.</term>
		/// </item>
		/// <item>
		/// <term>STATUS_INVALID_HANDLE</term>
		/// <term>The specified transaction object handle is invalid.</term>
		/// </item>
		/// <item>
		/// <term>STATUS_ACCESS_DENIED</term>
		/// <term>The caller does not have appropriate access to the transaction object.</term>
		/// </item>
		/// <item>
		/// <term>STATUS_TRANSACTION_SUPERIOR_EXISTS</term>
		/// <term>The caller cannot commit the transaction because a superior transaction manager exists.</term>
		/// </item>
		/// <item>
		/// <term>STATUS_TRANSACTION_ALREADY_ABORTED</term>
		/// <term>The transaction cannot be committed because it has been rolled back.</term>
		/// </item>
		/// <item>
		/// <term>STATUS_TRANSACTION_ALREADY_COMMITTED</term>
		/// <term>The transaction is already committed.</term>
		/// </item>
		/// <item>
		/// <term>STATUS_TRANSACTION_REQUEST_NOT_VALID</term>
		/// <term>The commit operation for this transaction has already been started.</term>
		/// </item>
		/// <item>
		/// <term>STATUS_PENDING</term>
		/// <term>Commit notifications have been queued to resource managers, and the caller specified FALSE for the Wait parameter.</term>
		/// </item>
		/// </list>
		/// <para>The routine might return other NTSTATUS values.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// For more information about how transaction clients should use the <c>ZwCommitTransaction</c> routine, see Creating a
		/// Transactional Client.
		/// </para>
		/// <para>For more information about commit operations, see Handling Commit Operations.</para>
		/// <para>
		/// For calls from kernel-mode drivers, the <c>NtXxx</c> and <c>ZwXxx</c> versions of a Windows Native System Services routine can
		/// behave differently in the way that they handle and interpret input parameters. For more information about the relationship
		/// between the <c>NtXxx</c> and <c>ZwXxx</c> versions of a routine, see Using Nt and Zw Versions of the Native System Services Routines.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows-hardware/drivers/ddi/content/wdm/nf-wdm-ntcommittransaction __kernel_entry NTSYSCALLAPI
		// NTSTATUS NtCommitTransaction( HANDLE TransactionHandle, BOOLEAN Wait );
		[DllImport(Lib.NtDll, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("wdm.h", MSDNShortId = "145646f3-ff90-41d6-bf76-947cdf93b489")]
		public static extern NTStatus NtCommitTransaction(IntPtr TransactionHandle, [MarshalAs(UnmanagedType.U1)] bool Wait);

		/// <summary>
		/// <para>
		/// The <c>NtCompareTokens</c> function compares two access tokens and determines whether they are equivalent with respect to a call
		/// to the <c>AccessCheck</c> function.
		/// </para>
		/// </summary>
		/// <returns>
		/// <para>If the function succeeds, the function returns STATUS_SUCCESS.</para>
		/// <para>If the function fails, it returns an <c>NTSTATUS</c> error code.</para>
		/// </returns>
		/// <remarks>
		/// <para>Two access control tokens are considered to be equivalent if all of the following conditions are true:</para>
		/// <list type="bullet">
		/// <item>
		/// <term>Every security identifier (SID) that is present in either token is also present in the other token.</term>
		/// </item>
		/// <item>
		/// <term>Neither or both of the tokens are restricted.</term>
		/// </item>
		/// <item>
		/// <term>If both tokens are restricted, every SID that is restricted in one token is also restricted in the other token.</term>
		/// </item>
		/// <item>
		/// <term>Every privilege present in either token is also present in the other token.</term>
		/// </item>
		/// </list>
		/// <para>
		/// This function has no associated import library or header file; you must call it using the <c>LoadLibrary</c> and
		/// <c>GetProcAddress</c> functions.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/SecAuthZ/ntcomparetokens NTSTATUS NTAPI NtCompareTokens( _In_ HANDLE
		// FirstTokenHandle, _In_ HANDLE SecondTokenHandle, _Out_ PBOOLEAN Equal );
		[DllImport(Lib.NtDll, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("", MSDNShortId = "3a07ddc6-9748-4f96-a597-2af6b4282e56")]
		public static extern NTStatus NtCompareTokens([In] IntPtr FirstTokenHandle, [In] IntPtr SecondTokenHandle, [MarshalAs(UnmanagedType.U1)] out bool Equal);

		/// <summary>
		/// <para>The <c>ZwCreateEnlistment</c> routine creates a new enlistment object for a transaction.</para>
		/// </summary>
		/// <param name="EnlistmentHandle">
		/// <para>
		/// A pointer to a caller-allocated variable that receives a handle to the new enlistment object if the call to
		/// <c>ZwCreateEnlistment</c> succeeds.
		/// </para>
		/// </param>
		/// <param name="DesiredAccess">
		/// <para>
		/// An ACCESS_MASK value that specifies the caller's requested access to the enlistment object. In addition to the access rights that
		/// are defined for all kinds of objects (see ACCESS_MASK), the caller can specify any of the following access right flags for
		/// enlistment objects:
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>ACCESS_MASK flag</term>
		/// <term>Allows the caller to</term>
		/// </listheader>
		/// <item>
		/// <term>ENLISTMENT_QUERY_INFORMATION</term>
		/// <term>Query information about the enlistment (see ZwQueryInformationEnlistment).</term>
		/// </item>
		/// <item>
		/// <term>ENLISTMENT_SET_INFORMATION</term>
		/// <term>Set information for the enlistment (see ZwSetInformationEnlistment).</term>
		/// </item>
		/// <item>
		/// <term>ENLISTMENT_RECOVER</term>
		/// <term>Recover the enlistment (see ZwRecoverEnlistment).</term>
		/// </item>
		/// <item>
		/// <term>ENLISTMENT_SUBORDINATE_RIGHTS</term>
		/// <term>
		/// Perform operations that a resource manager that is not superior performs (see ZwRollbackEnlistment, ZwPrePrepareComplete,
		/// ZwPrepareComplete, ZwCommitComplete, ZwRollbackComplete, ZwSinglePhaseReject, ZwReadOnlyEnlistment).
		/// </term>
		/// </item>
		/// <item>
		/// <term>ENLISTMENT_SUPERIOR_RIGHTS</term>
		/// <term>
		/// Perform operations that a superior transaction manager must perform (see ZwPrepareEnlistment, ZwPrePrepareEnlistment, ZwCommitEnlistment).
		/// </term>
		/// </item>
		/// </list>
		/// <para>
		/// Alternatively, you can specify one or more of the following ACCESS_MASK bitmaps. These bitmaps combine the flags from the
		/// previous table with the STANDARD_RIGHTS_XXX flags that are described on the ACCESS_MASK reference page. You can also combine
		/// these bitmaps together with additional flags from the previous table. The following table shows how the bitmaps correspond to
		/// specific access rights.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Generic access right</term>
		/// <term>Set of specific access rights</term>
		/// </listheader>
		/// <item>
		/// <term>ENLISTMENT_GENERIC_READ</term>
		/// <term>STANDARD_RIGHTS_READ and ENLISTMENT_QUERY_INFORMATION</term>
		/// </item>
		/// <item>
		/// <term>ENLISTMENT_GENERIC_WRITE</term>
		/// <term>
		/// STANDARD_RIGHTS_WRITE, ENLISTMENT_SET_INFORMATION, ENLISTMENT_RECOVER, ENLISTMENT_REFERENCE, ENLISTMENT_SUBORDINATE_RIGHTS, and ENLISTMENT_SUPERIOR_RIGHTS
		/// </term>
		/// </item>
		/// <item>
		/// <term>ENLISTMENT_GENERIC_EXECUTE</term>
		/// <term>STANDARD_RIGHTS_EXECUTE, ENLISTMENT_RECOVER, ENLISTMENT_SUBORDINATE_RIGHTS, and ENLISTMENT_SUPERIOR_RIGHTS</term>
		/// </item>
		/// <item>
		/// <term>ENLISTMENT_ALL_ACCESS</term>
		/// <term>STANDARD_RIGHTS_REQUIRED, ENLISTMENT_GENERIC_READ, ENLISTMENT_GENERIC_WRITE, and ENLISTMENT_GENERIC_EXECUTE</term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="ResourceManagerHandle">
		/// <para>A handle to the caller's resource manager object that was obtained by a previous call to ZwCreateResourceManager or ZwOpenResourceManager.</para>
		/// </param>
		/// <param name="TransactionHandle">
		/// <para>
		/// A handle to a transaction object that was obtained by a previous call to ZwCreateTransaction or ZwOpenTransaction. KTM adds this
		/// transaction to the list of transactions that the calling resource manager is handling.
		/// </para>
		/// </param>
		/// <param name="ObjectAttributes">
		/// <para>
		/// A pointer to an OBJECT_ATTRIBUTES structure that specifies the object name and other attributes. Use the
		/// InitializeObjectAttributes routine to initialize this structure. If the caller is not running in a system thread context, it must
		/// set the OBJ_KERNEL_HANDLE attribute when it calls <c>InitializeObjectAttributes</c>. This parameter is optional and can be <c>NULL</c>.
		/// </para>
		/// </param>
		/// <param name="CreateOptions">
		/// <para>Enlistment option flags. The following table contains the only available flag.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>CreateOptions flag</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>ENLISTMENT_SUPERIOR</term>
		/// <term>The caller is enlisting as a superior transaction manager for the specified transaction.</term>
		/// </item>
		/// </list>
		/// <para>This parameter is optional and can be zero.</para>
		/// </param>
		/// <param name="NotificationMask">
		/// <para>
		/// A bitwise OR of TRANSACTION_NOTIFY_XXX values that are defined in Ktmtypes.h. This mask specifies the types of transaction
		/// notifications that KTM sends to the caller.
		/// </para>
		/// </param>
		/// <param name="EnlistmentKey">
		/// <para>
		/// A pointer to caller-defined information that uniquely identifies the enlistment. The resource manager receives this pointer when
		/// it calls ZwGetNotificationResourceManager or when KTM calls the ResourceManagerNotification callback routine. The resource
		/// manager can maintain a reference count for this key by calling TmReferenceEnlistmentKey and TmDereferenceEnlistmentKey. This
		/// parameter is optional and can be <c>NULL</c>.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>
		/// <c>ZwCreateEnlistment</c> returns STATUS_SUCCESS if the operation succeeds. Otherwise, this routine might return one of the
		/// following values:
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>STATUS_INVALID_HANDLE</term>
		/// <term>An object handle is invalid.</term>
		/// </item>
		/// <item>
		/// <term>STATUS_INVALID_PARAMETER</term>
		/// <term>
		/// The CreateOptions or NotificationMask parameter's value is invalid, or KTM could not find the transaction that the
		/// TransactionHandle parameter specifies.
		/// </term>
		/// </item>
		/// <item>
		/// <term>STATUS_INSUFFICIENT_RESOURCES</term>
		/// <term>A memory allocation failed.</term>
		/// </item>
		/// <item>
		/// <term>STATUS_TRANSACTIONMANAGER_NOT_ONLINE</term>
		/// <term>The enlistment failed because KTM or the resource manager is not in an operational state.</term>
		/// </item>
		/// <item>
		/// <term>STATUS_TRANSACTION_NOT_ACTIVE</term>
		/// <term>The enlistment failed because the transaction that the TransactionHandle parameter specifies is not active.</term>
		/// </item>
		/// <item>
		/// <term>STATUS_TRANSACTION_SUPERIOR_EXISTS</term>
		/// <term>The caller tried to register as a superior transaction manager but a superior transaction manager already exists.</term>
		/// </item>
		/// <item>
		/// <term>STATUS_TM_VOLATILE</term>
		/// <term>
		/// The caller is trying to register as a superior transaction manager, but the caller's resource manager object is volatile while
		/// the associated transaction manager object is not volatile.
		/// </term>
		/// </item>
		/// <item>
		/// <term>STATUS_ACCESS_DENIED</term>
		/// <term>The value of the DesiredAccess parameter is invalid.</term>
		/// </item>
		/// </list>
		/// <para>The routine might return other NTSTATUS values.</para>
		/// </returns>
		/// <remarks>
		/// <para>A resource manager calls <c>ZwCreateEnlistment</c> to enlist in a transaction.</para>
		/// <para>Resource managers that are not superior must include the ENLISTMENT_SUBORDINATE_RIGHTS flag in their access mask.</para>
		/// <para>
		/// Superior transaction managers must include the ENLISTMENT_SUPERIOR_RIGHTS flag in their access masks. Typically, a superior
		/// transaction manager includes code that calls ZwRollbackEnlistment, so it must also include the ENLISTMENT_SUBORDINATE_RIGHTS flag.
		/// </para>
		/// <para>A resource manager that calls <c>ZwCreateEnlistment</c> must eventually call ZwClose to close the object handle.</para>
		/// <para>
		/// Your resource manager can use the EnlistmentKey parameter to assign a unique value to each enlistment, such as a pointer to a
		/// data structure that contains information about the enlistment. For example, if the resource manager stores the enlistment
		/// object's handle in the structure, the resource manager can do the following:
		/// </para>
		/// <para>
		/// For more information about <c>ZwCreateEnlistment</c>, see Creating a Resource Manager and Creating a Superior Transaction Manager.
		/// </para>
		/// <para>
		/// For calls from kernel-mode drivers, the <c>NtXxx</c> and <c>ZwXxx</c> versions of a Windows Native System Services routine can
		/// behave differently in the way that they handle and interpret input parameters. For more information about the relationship
		/// between the <c>NtXxx</c> and <c>ZwXxx</c> versions of a routine, see Using Nt and Zw Versions of the Native System Services Routines.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows-hardware/drivers/ddi/content/wdm/nf-wdm-ntcreateenlistment __kernel_entry NTSYSCALLAPI
		// NTSTATUS NtCreateEnlistment( PHANDLE EnlistmentHandle, ACCESS_MASK DesiredAccess, HANDLE ResourceManagerHandle, HANDLE
		// TransactionHandle, POBJECT_ATTRIBUTES ObjectAttributes, ULONG CreateOptions, NOTIFICATION_MASK NotificationMask, PVOID
		// EnlistmentKey );
		[DllImport(Lib.NtDll, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("wdm.h", MSDNShortId = "5ffd8262-10b3-4c40-bd3e-050271338508")]
		public static extern NTStatus NtCreateEnlistment(out SafeEnlistmentHandle EnlistmentHandle, ACCESS_MASK DesiredAccess, SafeResourceManagerHandle ResourceManagerHandle,
			SafeTransactionHandle TransactionHandle, ref OBJECT_ATTRIBUTES ObjectAttributes, uint CreateOptions, NOTIFICATION_MASK NotificationMask, [Optional] IntPtr EnlistmentKey);

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
		/// Specifies one or more FILE_ATTRIBUTE_XXX flags, which represent the file attributes to set if you create or overwrite a file. The
		/// caller usually specifies FILE_ATTRIBUTE_NORMAL, which sets the default attributes. For a list of valid FILE_ATTRIBUTE_XXXflags,
		/// see the CreateFile routine in the Microsoft Windows SDK documentation. If no file is created or overwritten, FileAttributes is ignored.
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
		/// All operations on the file are performed synchronously. Any wait on behalf of the caller is subject to premature termination from
		/// alerts. This flag also causes the I/O system to maintain the file-position pointer. If this flag is set, the SYNCHRONIZE flag
		/// must be set in the DesiredAccess parameter.
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
		/// Open a file with a reparse point and bypass normal reparse point processing for the file. For more information, see the following
		/// Remarks section.
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
		/// The file is being opened for backup intent. Therefore, the system should check for certain access rights and grant the caller the
		/// appropriate access to the file—before checking the DesiredAccess parameter against the file's security descriptor. This flag not
		/// used by device and intermediate drivers.
		/// </term>
		/// </item>
		/// <item>
		/// <term>FILE_RESERVE_OPFILTER</term>
		/// <term>
		/// This flag allows an application to request a Filter opportunistic lock (oplock) to prevent other applications from getting share
		/// violations. If there are already open handles, the create request will fail with STATUS_OPLOCK_NOT_GRANTED. For more information,
		/// see the following Remarks section.
		/// </term>
		/// </item>
		/// <item>
		/// <term>FILE_OPEN_REQUIRING_OPLOCK</term>
		/// <term>
		/// The file is being opened and an opportunistic lock (oplock) on the file is being requested as a single atomic operation. The file
		/// system checks for oplocks before it performs the create operation, and will fail the create with a return code of
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
		/// <c>IO_STATUS_BLOCK</c> structure that is pointed to by the IoStatusBlock parameter. This would occur only if the NTFS log file is
		/// full, and an error occurs while <c>NtCreateFile</c> tries to handle this situation.
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
		/// The FILE_DIRECTORY_FILE CreateOptions value specifies that the file to be created or opened is a directory. When a directory file
		/// is created, the file system creates an appropriate structure on the disk to represent an empty directory for that particular file
		/// system's on-disk structure. If this option was specified and the given file to be opened is not a directory file, or if the
		/// caller specified an inconsistent CreateOptions or CreateDisposition value, the call to <c>NtCreateFile</c> will fail.
		/// </para>
		/// <para>
		/// The FILE_NO_INTERMEDIATE_BUFFERING CreateOptions flag prevents the file system from performing any intermediate buffering on
		/// behalf of the caller. Specifying this flag places the following restrictions on the caller's parameters to other <c>ZwXxxFile</c> routines.
		/// </para>
		/// <para>
		/// The FILE_SYNCHRONOUS_IO_ALERT and FILE_SYNCHRONOUS_IO_NONALERT CreateOptions flags, which are mutually exclusive as their names
		/// suggest, specify that all I/O operations on the file will be synchronous—as long as they occur through the file object referred
		/// to by the returned FileHandle. All I/O on such a file is serialized across all threads using the returned handle. If either of
		/// these CreateOptions flags is set, the SYNCHRONIZE DesiredAccess flag must also be set—to compel the I/O manager to use the file
		/// object as a synchronization object. In these cases, the I/O manager keeps track of the current file-position offset, which you
		/// can pass to <c>NtReadFile</c> and <c>NtWriteFile</c>. Call <c>NtQueryInformationFile</c> or <c>NtSetInformationFile</c> to get or
		/// set this position.
		/// </para>
		/// <para>
		/// If the CreateOptions FILE_OPEN_REPARSE_POINT flag is specified and <c>NtCreateFile</c> attempts to open a file with a reparse
		/// point, normal reparse point processing occurs for the file. If, on the other hand, the FILE_OPEN_REPARSE_POINT flag is specified,
		/// normal reparse processing does occur and <c>NtCreateFile</c> attempts to directly open the reparse point file. In either case, if
		/// the open operation was successful, <c>NtCreateFile</c> returns STATUS_SUCCESS; otherwise, the routine returns an NTSTATUS error
		/// code. <c>NtCreateFile</c> never returns STATUS_REPARSE.
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
		/// The CreateOptions flag FILE_RESERVE_OPFILTER allows an application to request a Level 1, Batch, or Filter oplock to prevent other
		/// applications from getting share violations. However, FILE_RESERVE_OPFILTER is only practically useful for Filter oplocks. To use
		/// it, you must complete the following steps:
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
			ref long AllocationSize, FileFlagsAndAttributes FileAttributes, FileShare ShareAccess, NtFileMode CreateDisposition, NtFileCreateOptions CreateOptions, IntPtr EaBuffer, uint EaLength);

		/// <summary>
		/// <para>The <c>ZwCreateResourceManager</c> routine creates a resource manager object.</para>
		/// </summary>
		/// <param name="ResourceManagerHandle">
		/// <para>
		/// A pointer to a caller-allocated variable that receives a handle to the new resource manager object if the call to
		/// <c>ZwCreateResourceManager</c> is successful.
		/// </para>
		/// </param>
		/// <param name="DesiredAccess">
		/// <para>
		/// An ACCESS_MASK value that specifies the caller's requested access to the resource manager object. In addition to the access
		/// rights that are defined for all kinds of objects (see <c>ACCESS_MASK</c>), the caller can specify any of the following access
		/// right flags for resource manager objects:
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>ACCESS_MASK flag</term>
		/// <term>Allows the caller to</term>
		/// </listheader>
		/// <item>
		/// <term>RESOURCEMANAGER_ENLIST</term>
		/// <term>Enlist in transactions (see ZwCreateEnlistment).</term>
		/// </item>
		/// <item>
		/// <term>RESOURCEMANAGER_GET_NOTIFICATION</term>
		/// <term>Receive notifications about the transactions that are associated with this resource manager (see ZwGetNotificationResourceManager).</term>
		/// </item>
		/// <item>
		/// <term>RESOURCEMANAGER_REGISTER_PROTOCOL</term>
		/// <term>Not used.</term>
		/// </item>
		/// <item>
		/// <term>RESOURCEMANAGER_QUERY_INFORMATION</term>
		/// <term>Query information about the resource manager (see ZwQueryInformationResourceManager).</term>
		/// </item>
		/// <item>
		/// <term>RESOURCEMANAGER_SET_INFORMATION</term>
		/// <term>Not used.</term>
		/// </item>
		/// <item>
		/// <term>RESOURCEMANAGER_RECOVER</term>
		/// <term>Recover the resource manager (see ZwRecoverResourceManager).</term>
		/// </item>
		/// <item>
		/// <term>RESOURCEMANAGER_COMPLETE_PROPAGATION</term>
		/// <term>Not used.</term>
		/// </item>
		/// </list>
		/// <para>
		/// Alternatively, you can specify one or more of the following generic ACCESS_MASK flags. (The STANDARD_RIGHTS_Xxx flags are
		/// predefined system values that are used to enforce security on system objects.) You can also combine these generic flags with
		/// additional flags from the preceding table. The following table shows how generic access rights correspond to specific access rights.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Generic access right</term>
		/// <term>Set of specific access rights</term>
		/// </listheader>
		/// <item>
		/// <term>RESOURCEMANAGER_GENERIC_READ</term>
		/// <term>STANDARD_RIGHTS_READ, RESOURCEMANAGER_QUERY_INFORMATION, and SYNCHRONIZE</term>
		/// </item>
		/// <item>
		/// <term>RESOURCEMANAGER_GENERIC_WRITE</term>
		/// <term>
		/// STANDARD_RIGHTS_WRITE, RESOURCEMANAGER_SET_INFORMATION, RESOURCEMANAGER_RECOVER, RESOURCEMANAGER_ENLIST,
		/// RESOURCEMANAGER_GET_NOTIFICATION, RESOURCEMANAGER_REGISTER_PROTOCOL, RESOURCEMANAGER_COMPLETE_PROPAGATION, and SYNCHRONIZE
		/// </term>
		/// </item>
		/// <item>
		/// <term>RESOURCEMANAGER_GENERIC_EXECUTE</term>
		/// <term>
		/// STANDARD_RIGHTS_EXECUTE, RESOURCEMANAGER_RECOVER, RESOURCEMANAGER_ENLIST, RESOURCEMANAGER_GET_NOTIFICATION,
		/// RESOURCEMANAGER_COMPLETE_PROPAGATION, and SYNCHRONIZE
		/// </term>
		/// </item>
		/// <item>
		/// <term>RESOURCEMANAGER_ALL_ACCESS</term>
		/// <term>STANDARD_RIGHTS_REQUIRED, RESOURCEMANAGER_GENERIC_READ, RESOURCEMANAGER_GENERIC_WRITE, and RESOURCEMANAGER_GENERIC_EXECUTE</term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="TmHandle">
		/// <para>A handle to a transaction manager object that was obtained by a previous all to ZwCreateTransactionManager or ZwOpenTransactionManager.</para>
		/// </param>
		/// <param name="RmGuid">
		/// <para>
		/// A pointer to a GUID that KTM will use to identify the resource manager. If this pointer is <c>NULL</c>, KTM generates a GUID.
		/// </para>
		/// </param>
		/// <param name="ObjectAttributes">
		/// <para>
		/// A pointer to an OBJECT_ATTRIBUTES structure that specifies the object name and other attributes. Use the
		/// InitializeObjectAttributes routine to initialize this structure. If the caller is not running in a system thread context, it must
		/// set the OBJ_KERNEL_HANDLE attribute when it calls <c>InitializeObjectAttributes</c>. This parameter is optional and can be <c>NULL</c>.
		/// </para>
		/// </param>
		/// <param name="CreateOptions">
		/// <para>Optional object creation flags. The following table contains the available flags, which are defined in Ktmtypes.h.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>CreateOptions flag</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>RESOURCE_MANAGER_COMMUNICATION</term>
		/// <term>For internal use only.</term>
		/// </item>
		/// <item>
		/// <term>RESOURCE_MANAGER_VOLATILE</term>
		/// <term>The caller will manage volatile resources. It will be non-persistent and will not perform recovery.</term>
		/// </item>
		/// </list>
		/// <para>This parameter is optional and can be zero.</para>
		/// </param>
		/// <param name="Description">
		/// <para>
		/// A pointer to a caller-supplied UNICODE_STRING structure that contains a NULL-terminated string. The string provides a description
		/// of the resource manager. KTM stores a copy of the string and includes the string in messages that it writes to the log stream.
		/// The maximum string length is MAX_RESOURCEMANAGER_DESCRIPTION_LENGTH. This parameter is optional and can be <c>NULL</c>.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>
		/// <c>ZwCreateResourceManager</c> returns STATUS_SUCCESS if the operation succeeds. Otherwise, this routine might return one of the
		/// following values:
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>STATUS_OBJECT_TYPE_MISMATCH</term>
		/// <term>The handle that TmHandle specifies is not a handle to a transaction object.</term>
		/// </item>
		/// <item>
		/// <term>STATUS_INVALID_HANDLE</term>
		/// <term>The handle that TmHandle specifies is invalid.</term>
		/// </item>
		/// <item>
		/// <term>STATUS_ACCESS_DENIED</term>
		/// <term>The caller does not have appropriate access to the specified transaction manager object.</term>
		/// </item>
		/// <item>
		/// <term>STATUS_TRANSACTION_OBJECT_EXPIRED</term>
		/// <term>The handle that TmHandle specifies is closed.</term>
		/// </item>
		/// <item>
		/// <term>STATUS_INVALID_PARAMETER</term>
		/// <term>The CreateOptions parameter's value is invalid or the Description parameter's string is too long.</term>
		/// </item>
		/// <item>
		/// <term>STATUS_TM_VOLATILE</term>
		/// <term>
		/// The CreateOptions parameter does not specify RESOURCE_MANAGER_VOLATILE but the transaction manager that TmHandle specifies is volatile.
		/// </term>
		/// </item>
		/// <item>
		/// <term>STATUS_OBJECT_NAME_COLLISION</term>
		/// <term>The GUID that ResourceManagerGuid specifies already exists.</term>
		/// </item>
		/// <item>
		/// <term>STATUS_ACCESS_DENIED</term>
		/// <term>The value of the DesiredAccess parameter is invalid.</term>
		/// </item>
		/// </list>
		/// <para>The routine might return other NTSTATUS values.</para>
		/// </returns>
		/// <remarks>
		/// <para>A resource manager that calls <c>ZwCreateResourceManager</c> must eventually call ZwClose to close the object handle.</para>
		/// <para>For more information about <c>ZwCreateResourceManager</c>, see Creating a Resource Manager.</para>
		/// <para>
		/// For calls from kernel-mode drivers, the <c>NtXxx</c> and <c>ZwXxx</c> versions of a Windows Native System Services routine can
		/// behave differently in the way that they handle and interpret input parameters. For more information about the relationship
		/// between the <c>NtXxx</c> and <c>ZwXxx</c> versions of a routine, see Using Nt and Zw Versions of the Native System Services Routines.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows-hardware/drivers/ddi/content/wdm/nf-wdm-ntcreateresourcemanager __kernel_entry
		// NTSYSCALLAPI NTSTATUS NtCreateResourceManager( PHANDLE ResourceManagerHandle, ACCESS_MASK DesiredAccess, HANDLE TmHandle, LPGUID
		// RmGuid, POBJECT_ATTRIBUTES ObjectAttributes, ULONG CreateOptions, PUNICODE_STRING Description );
		[DllImport(Lib.NtDll, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("wdm.h", MSDNShortId = "4812eeb4-134f-4ecb-870b-dbab04c1137b")]
		public static extern NTStatus NtCreateResourceManager(out SafeResourceManagerHandle ResourceManagerHandle, ACCESS_MASK DesiredAccess, SafeTransactionManagerHandle TmHandle, in Guid RmGuid,
			ref OBJECT_ATTRIBUTES ObjectAttributes, uint CreateOptions, in UNICODE_STRING Description);

		/// <summary>Provides a <see cref="SafeHandle"/> to an enlistment that releases its handle at disposal using NTClose.</summary>
		public class SafeEnlistmentHandle : SafeNtHandle
		{
			/// <summary>Initializes a new instance of the <see cref="SafeResourceManagerHandle"/> class and assigns an existing handle.</summary>
			/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
			/// <param name="ownsHandle"><see langword="true"/> to reliably release the handle during the finalization phase; otherwise, <see langword="false"/> (not recommended).</param>
			public SafeEnlistmentHandle(IntPtr preexistingHandle, bool ownsHandle = true) : base(preexistingHandle, ownsHandle) { }

			/// <summary>Initializes a new instance of the <see cref="SafeResourceManagerHandle"/> class.</summary>
			private SafeEnlistmentHandle() : base() { }
		}

		/// <summary>Provides a <see cref="SafeHandle"/> to a resource manager that releases its handle at disposal using NTClose.</summary>
		public class SafeResourceManagerHandle : SafeNtHandle
		{
			/// <summary>Initializes a new instance of the <see cref="SafeResourceManagerHandle"/> class and assigns an existing handle.</summary>
			/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
			/// <param name="ownsHandle"><see langword="true"/> to reliably release the handle during the finalization phase; otherwise, <see langword="false"/> (not recommended).</param>
			public SafeResourceManagerHandle(IntPtr preexistingHandle, bool ownsHandle = true) : base(preexistingHandle, ownsHandle) { }

			/// <summary>Initializes a new instance of the <see cref="SafeResourceManagerHandle"/> class.</summary>
			private SafeResourceManagerHandle() : base() { }
		}

		/// <summary>Provides a <see cref="SafeHandle"/> to a transaction that releases its handle at disposal using NTClose.</summary>
		public class SafeTransactionHandle : SafeNtHandle
		{
			/// <summary>Initializes a new instance of the <see cref="SafeTransactionHandle"/> class and assigns an existing handle.</summary>
			/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
			/// <param name="ownsHandle"><see langword="true"/> to reliably release the handle during the finalization phase; otherwise, <see langword="false"/> (not recommended).</param>
			public SafeTransactionHandle(IntPtr preexistingHandle, bool ownsHandle = true) : base(preexistingHandle, ownsHandle) { }

			/// <summary>Initializes a new instance of the <see cref="SafeTransactionHandle"/> class.</summary>
			private SafeTransactionHandle() : base() { }
		}

		/// <summary>Provides a <see cref="SafeHandle"/> to a transaction manager that releases its handle at disposal using NTClose.</summary>
		public class SafeTransactionManagerHandle : SafeNtHandle
		{
			/// <summary>Initializes a new instance of the <see cref="SafeTransactionManagerHandle"/> class and assigns an existing handle.</summary>
			/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
			/// <param name="ownsHandle"><see langword="true"/> to reliably release the handle during the finalization phase; otherwise, <see langword="false"/> (not recommended).</param>
			public SafeTransactionManagerHandle(IntPtr preexistingHandle, bool ownsHandle = true) : base(preexistingHandle, ownsHandle) { }

			/// <summary>Initializes a new instance of the <see cref="SafeTransactionManagerHandle"/> class.</summary>
			private SafeTransactionManagerHandle() : base() { }
		}

		/// <summary>Provides a <see cref="SafeHandle"/> to a section that releases its handle at disposal using NTClose.</summary>
		public class SafeSectionHandle : SafeNtHandle
		{
			/// <summary>Initializes a new instance of the <see cref="SafeSectionHandle"/> class and assigns an existing handle.</summary>
			/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
			/// <param name="ownsHandle"><see langword="true"/> to reliably release the handle during the finalization phase; otherwise, <see langword="false"/> (not recommended).</param>
			public SafeSectionHandle(IntPtr preexistingHandle, bool ownsHandle = true) : base(preexistingHandle, ownsHandle) { }

			/// <summary>Initializes a new instance of the <see cref="SafeSectionHandle"/> class.</summary>
			private SafeSectionHandle() : base() { }
		}

		/// <summary>
		/// <para>The <c>NtCreateSection</c> routine creates a section object.</para>
		/// </summary>
		/// <param name="SectionHandle">
		/// <para>Pointer to a HANDLE variable that receives a handle to the section object.</para>
		/// </param>
		/// <param name="DesiredAccess">
		/// <para>
		/// Specifies an ACCESS_MASK value that determines the requested access to the object. In addition to the access rights that are
		/// defined for all types of objects (see ACCESS_MASK), the caller can specify any of the following access rights, which are specific
		/// to section objects:
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
		/// The value of MaximumSize is too big. This occurs when either MaximumSize is greater than the system-defined maximum for sections,
		/// or if MaximumSize is greater than the specified file and the section is not writable.
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
		public static extern NTStatus NtCreateSection(out SafeSectionHandle SectionHandle, ACCESS_MASK DesiredAccess, ref OBJECT_ATTRIBUTES ObjectAttributes, ref long MaximumSize,
			MEM_PROTECTION SectionPageProtection, SEC_ALLOC AllocationAttributes, [Optional] HFILE FileHandle);

		/// <summary><para>The <c>ZwCreateTransaction</c> routine creates a transaction object.</para></summary><param name="TransactionHandle"><para>A pointer to a caller-allocated variable that receives a handle to the new transaction object, if the call to <c>ZwCreateTransaction</c> succeeds.</para></param><param name="DesiredAccess"><para>An ACCESS_MASK value that specifies the caller&#39;s requested access to the transaction object. In addition to the access rights that are defined for all kinds of objects (see ACCESS_MASK), the caller can specify any of the following flags for transaction objects.</para><list type="table"><listheader><term>Access mask</term><term>Allows the caller to</term></listheader><item><term>TRANSACTION_COMMIT</term><term> Commit the transaction (see ZwCommitTransaction). </term></item><item><term>TRANSACTION_ENLIST</term><term> Create an enlistment for the transaction (see ZwCreateEnlistment). </term></item><item><term>TRANSACTION_PROPAGATE</term><term>Do not use.</term></item><item><term>TRANSACTION_QUERY_INFORMATION</term><term> Obtain information about the transaction (see ZwQueryInformationTransaction). </term></item><item><term>TRANSACTION_ROLLBACK</term><term> Roll back the transaction (see ZwRollbackTransaction). </term></item><item><term>TRANSACTION_SET_INFORMATION</term><term> Set information for the transaction (see ZwSetInformationTransaction). </term></item></list><para>Alternatively, you can specify one or more of the following ACCESS_MASK bitmaps. These bitmaps combine the flags from the previous table with the STANDARD_RIGHTS_XXX flags that are described on the ACCESS_MASK reference page. You can also combine these bitmaps with additional flags from the preceding table. The following table shows how the bitmaps correspond to specific access rights.</para><list type="table"><listheader><term>Rights bitmap</term><term>Set of specific access rights</term></listheader><item><term>TRANSACTION_GENERIC_READ</term><term>STANDARD_RIGHTS_READ, TRANSACTION_QUERY_INFORMATION, and SYNCHRONIZE</term></item><item><term>TRANSACTION_GENERIC_WRITE</term><term>STANDARD_RIGHTS_WRITE, TRANSACTION_SET_INFORMATION, TRANSACTION_COMMIT, TRANSACTION_ENLIST, TRANSACTION_ROLLBACK, TRANSACTION_PROPAGATE, TRANSACTION_SAVEPOINT, and SYNCHRONIZE</term></item><item><term>TRANSACTION_GENERIC_EXECUTE</term><term>STANDARD_RIGHTS_EXECUTE, TRANSACTION_COMMIT, TRANSACTION_ROLLBACK, and SYNCHRONIZE</term></item><item><term>TRANSACTION_ALL_ACCESS</term><term>STANDARD_RIGHTS_REQUIRED, TRANSACTION_GENERIC_READ, TRANSACTION_GENERIC_WRITE, and TRANSACTION_GENERIC_EXECUTE</term></item><item><term>TRANSACTION_RESOURCE_MANAGER_RIGHTS</term><term>STANDARD_RIGHTS_WRITE, TRANSACTION_GENERIC_READ, TRANSACTION_SET_INFORMATION, TRANSACTION_ENLIST, TRANSACTION_ROLLBACK, TRANSACTION_PROPAGATE, and SYNCHRONIZE</term></item></list><para>Typically, a resource manager specifies TRANSACTION_RESOURCE_MANAGER_RIGHTS.</para><para>The DesiredAccess value cannot be zero.</para></param><param name="ObjectAttributes"><para>A pointer to an OBJECT_ATTRIBUTES structure that specifies the object name and other attributes. Use the InitializeObjectAttributes routine to initialize this structure. If the caller is not running in a system thread context, it must set the OBJ_KERNEL_HANDLE attribute when it calls <c>InitializeObjectAttributes</c>. This parameter is optional and can be <c>NULL</c>.</para></param><param name="Uow"><para>A pointer to a GUID that KTM uses as the new transaction object&#39;s unit of work (UOW) identifier. This parameter is optional and can be <c>NULL</c>. If this parameter is <c>NULL</c>, KTM generates a GUID and assigns it to the transaction object. For more information, see the following Remarks section.</para></param><param name="TmHandle"><para>A handle to a transaction manager object that was obtained by a previous call to ZwCreateTransactionManager or ZwOpenTransactionManager. KTM assigns the new transaction object to the specified transaction manager object. If this parameter is <c>NULL</c>, KTM assigns the new transaction object to a transaction manager later, when a resource manager creates an enlistment for the transaction.</para></param><param name="CreateOptions"><para>Optional object creation flags. The following table contains the available flags, which are defined in Ktmtypes.h.</para><list type="table"><listheader><term>Option flag</term><term>Meaning</term></listheader><item><term>TRANSACTION_DO_NOT_PROMOTE</term><term>Reserved for future use.</term></item></list></param><param name="IsolationLevel"><para>Reserved for future use. Callers must set this parameter to zero.</para></param><param name="IsolationFlags"><para>Reserved for future use. Callers should set this parameter to zero.</para></param><param name="Timeout"><para>A pointer to a time-out value. If the transaction has not been committed by the time specified by this parameter, KTM rolls back the transaction. The time-out value is expressed in system time units (100-nanosecond intervals), and can specify either an absolute time or a relative time. If the value pointed to by Timeout is negative, the expiration time is relative to the current system time. Otherwise, the expiration time is absolute. This pointer is optional and can be <c>NULL</c> if you do not want the transaction to have a time-out value. If Timeout = <c>NULL</c> or *Timeout = 0, the transaction never times out. (You can also use ZwSetInformationTransaction to set a time-out value.)</para></param><param name="Description"><para>A pointer to a caller-supplied UNICODE_STRING structure that contains a NULL-terminated string. The string provides a description of the transaction. KTM stores a copy of the string and includes the string in messages that it writes to the log stream. The maximum string length is MAX_TRANSACTION_DESCRIPTION_LENGTH. This parameter is optional and can be <c>NULL</c>.</para></param><returns><para><c>ZwCreateTransaction</c> returns STATUS_SUCCESS if the operation succeeds. Otherwise, this routine might return one of the following values:</para><list type="table"><listheader><term>Return code</term><term>Description</term></listheader><item><term> STATUS_INVALID_PARAMETER </term><term> The CreateOptions parameter contains an invalid flag, the DesiredAccess parameter is zero, or the Description parameter&#39;s string is too long. </term></item><item><term> STATUS_INSUFFICIENT_RESOURCES </term><term>KTM could not allocate system resources (typically memory).</term></item><item><term> STATUS_INVALID_ACL </term><term>A security descriptor contains an invalid access control list (ACL).</term></item><item><term> STATUS_INVALID_SID </term><term>A security descriptor contains an invalid security identifier (SID).</term></item><item><term> STATUS_OBJECT_NAME_EXISTS </term><term> The object name that the ObjectAttributes parameter specifies already exists. </term></item><item><term> STATUS_OBJECT_NAME_INVALID </term><term> The object name that the ObjectAttributes parameter specifies is invalid. </term></item><item><term> STATUS_ACCESS_DENIED </term><term> The value of the DesiredAccess parameter is invalid. </term></item></list><para>The routine might return other NTSTATUS values.</para></returns><remarks><para>The caller can use the Uow parameter to specify a UOW identifier for the transaction object. If the caller does not specify a UOW identifier, KTM generates a GUID and assigns it to the transaction object. The caller can later obtain this GUID by calling ZwQueryInformationTransaction.</para><para>Typically, you should let KTM generate a GUID for the transaction object, unless your component communicates with another TPS component that has already generated a UOW identifier for the transaction.</para><para>To close the transaction handle, the component that called <c>ZwCreateTransaction</c> must call ZwClose. If the last transaction handle closes before any component calls ZwCommitTransaction for the transaction, KTM rolls back the transaction.</para><para>For more information about how transaction clients should use <c>ZwCreateTransaction</c>, see Creating a Transactional Client.</para><para>For calls from kernel-mode drivers, the <c>NtXxx</c> and <c>ZwXxx</c> versions of a Windows Native System Services routine can behave differently in the way that they handle and interpret input parameters. For more information about the relationship between the <c>NtXxx</c> and <c>ZwXxx</c> versions of a routine, see Using Nt and Zw Versions of the Native System Services Routines.</para></remarks>
		// https://docs.microsoft.com/en-us/windows-hardware/drivers/ddi/content/wdm/nf-wdm-ntcreatetransaction
		// __kernel_entry NTSYSCALLAPI NTSTATUS NtCreateTransaction( PHANDLE TransactionHandle, ACCESS_MASK DesiredAccess, POBJECT_ATTRIBUTES ObjectAttributes, LPGUID Uow, HANDLE TmHandle, ULONG CreateOptions, ULONG IsolationLevel, ULONG IsolationFlags, PLARGE_INTEGER Timeout, PUNICODE_STRING Description );
		[DllImport(Lib.NtDll, SetLastError = false, CharSet = CharSet.Auto)]
		[PInvokeData("wdm.h", MSDNShortId = "b4c2dd68-3c1a-46d3-ab9c-be2291ed80f4")]
		public static extern NTStatus NtCreateTransaction(out SafeTransactionHandle TransactionHandle, ACCESS_MASK DesiredAccess, ref OBJECT_ATTRIBUTES ObjectAttributes,
			in Guid Uow, SafeTransactionManagerHandle TmHandle, uint CreateOptions, [Optional] uint IsolationLevel, [Optional] uint IsolationFlags, in long Timeout, in UNICODE_STRING Description);

		/// <summary><para>The <c>ZwCreateTransactionManager</c> routine creates a new transaction manager object.</para></summary><param name="TmHandle"><para>A pointer to a caller-allocated variable that receives a handle to the new transaction manager object.</para></param><param name="DesiredAccess"><para>An ACCESS_MASK value that specifies the caller&#39;s requested access to the transaction manager object. In addition to the access rights that are defined for all kinds of objects (see ACCESS_MASK), the caller can specify any of the following access right flags for transaction manager objects.</para><list type="table"><listheader><term>ACCESS_MASK flag</term><term>Allows the caller to</term></listheader><item><term>TRANSACTIONMANAGER_CREATE_RM</term><term> Create a resource manager (see ZwCreateResourceManager). </term></item><item><term>TRANSACTIONMANAGER_QUERY_INFORMATION</term><term> Obtain information about the transaction manager (see ZwQueryInformationTransactionManager and ZwEnumerateTransactionObject). Also required for ZwOpenResourceManager, ZwCreateTransaction, and ZwOpenTransaction.) </term></item><item><term>TRANSACTIONMANAGER_RECOVER</term><term> Recover the transaction manager (see ZwRecoverTransactionManager and ZwRollforwardTransactionManager). </term></item><item><term>TRANSACTIONMANAGER_RENAME</term><term>Not used.</term></item><item><term>TRANSACTIONMANAGER_SET_INFORMATION</term><term>Not used.</term></item></list><para>Alternatively, you can specify one or more of the following ACCESS_MASK bitmaps. These bitmaps combine the flags from the previous table with the STANDARD_RIGHTS_XXX flags that are described on the <c>ACCESS_MASK</c> reference page. You can also combine these bitmaps with additional flags from the preceding table. The following table shows how the bitmaps correspond to specific access rights.</para><list type="table"><listheader><term>Rights bitmap</term><term>Set of specific access rights</term></listheader><item><term>TRANSACTIONMANAGER_GENERIC_READ</term><term>STANDARD_RIGHTS_READ and TRANSACTIONMANAGER_QUERY_INFORMATION</term></item><item><term>TRANSACTIONMANAGER_GENERIC_WRITE</term><term>STANDARD_RIGHTS_WRITE, TRANSACTIONMANAGER_SET_INFORMATION, TRANSACTIONMANAGER_RECOVER, TRANSACTIONMANAGER_RENAME, and TRANSACTIONMANAGER_CREATE_RM</term></item><item><term>TRANSACTIONMANAGER_GENERIC_EXECUTE</term><term>STANDARD_RIGHTS_EXECUTE</term></item><item><term>TRANSACTIONMANAGER_ALL_ACCESS</term><term>STANDARD_RIGHTS_REQUIRED, TRANSACTIONMANAGER_GENERIC_READ, TRANSACTIONMANAGER_GENERIC_WRITE, and TRANSACTIONMANAGER_GENERIC_EXECUTE</term></item></list></param><param name="ObjectAttributes"><para>A pointer to an OBJECT_ATTRIBUTES structure that specifies the object name and other attributes. Use the InitializeObjectAttributes routine to initialize this structure. If the caller is not running in a system thread context, it must set the OBJ_KERNEL_HANDLE attribute when it calls <c>InitializeObjectAttributes</c>. This parameter is optional and can be <c>NULL</c>.</para></param><param name="LogFileName"><para>A pointer to a UNICODE_STRING structure that contains the path and file name of a CLFS log file stream to be associated with the transaction manager object. This parameter must be <c>NULL</c> if the CreateOptions parameter is TRANSACTION_MANAGER_VOLATILE. Otherwise, this parameter must be non-<c>NULL</c>. For more information, see the following Remarks section.</para></param><param name="CreateOptions"><para>Optional object creation flags. The following table contains the available flags, which are defined in Ktmtypes.h.</para><list type="table"><listheader><term>Option flag</term><term>Meaning</term></listheader><item><term>TRANSACTION_MANAGER_VOLATILE</term><term>The transaction manager object will be volatile. Therefore, it will not use a log file.</term></item><item><term>TRANSACTION_MANAGER_COMMIT_DEFAULT</term><term>For internal use only.</term></item><item><term>TRANSACTION_MANAGER_COMMIT_SYSTEM_VOLUME</term><term>For internal use only.</term></item><item><term>TRANSACTION_MANAGER_COMMIT_SYSTEM_HIVES</term><term>For internal use only.</term></item><item><term>TRANSACTION_MANAGER_COMMIT_LOWEST</term><term>For internal use only.</term></item><item><term>TRANSACTION_MANAGER_CORRUPT_FOR_RECOVERY</term><term>For internal use only.</term></item><item><term>TRANSACTION_MANAGER_CORRUPT_FOR_PROGRESS</term><term>For internal use only.</term></item></list></param><param name="CommitStrength"><para>Reserved for future use. This parameter must be zero.</para></param><returns><para><c>ZwCreateTransactionManager</c> returns STATUS_SUCCESS if the operation succeeds. Otherwise, this routine might return one of the following values:</para><list type="table"><listheader><term>Return code</term><term>Description</term></listheader><item><term> STATUS_INVALID_PARAMETER </term><term>The value of an input parameter is invalid.</term></item><item><term> STATUS_INSUFFICIENT_RESOURCES </term><term>KTM could not allocate system resources (typically memory).</term></item><item><term> STATUS_LOG_CORRUPTION_DETECTED </term><term>KTM encountered an error while creating or opening the log file.</term></item><item><term> STATUS_INVALID_ACL </term><term>A security descriptor contains an invalid access control list (ACL).</term></item><item><term> STATUS_INVALID_SID </term><term>A security descriptor contains an invalid security identifier (SID).</term></item><item><term> STATUS_OBJECT_NAME_EXISTS </term><term> The object name that the ObjectAttributes parameter specifies already exists. </term></item><item><term> STATUS_OBJECT_NAME_COLLISION </term><term>The operating system detected a duplicate object name. The error might indicate that the log stream is already being used.</term></item><item><term> STATUS_OBJECT_NAME_INVALID </term><term> The object name that the ObjectAttributes parameter specifies is invalid. </term></item><item><term> STATUS_ACCESS_DENIED </term><term> The value of the DesiredAccess parameter is invalid. </term></item></list><para>The routine might return other NTSTATUS values.</para></returns><remarks><para>If the log file stream that the LogFileName parameter specifies does not exist, KTM calls CLFS to create the stream. If the stream already exists, KTM calls CLFS to open the stream.</para><para>Your TPS component must call ZwRecoverTransactionManager after it has called <c>ZwCreateTransactionManager</c></para><para>If your TPS component specifies the TRANSACTION_MANAGER_VOLATILE flag in the CreateOptions parameter, all resource managers that are associated with the transaction manager object must specify the RESOURCE_MANAGER_VOLATILE flag when they call ZwCreateResourceManager.</para><para>A TPS component that calls <c>ZwCreateTransactionManager</c> must eventually call ZwClose to close the object handle.</para><para>For more information about how use <c>ZwCreateTransactionManager</c>, see Creating a Resource Manager.</para><para><c>NtCreateTransactionManager</c> and <c>ZwCreateTransactionManager</c> are two versions of the same Windows Native System Services routine.</para><para>For calls from kernel-mode drivers, the <c>NtXxx</c> and <c>ZwXxx</c> versions of a Windows Native System Services routine can behave differently in the way that they handle and interpret input parameters. For more information about the relationship between the <c>NtXxx</c> and <c>ZwXxx</c> versions of a routine, see Using Nt and Zw Versions of the Native System Services Routines.</para></remarks>
		// https://docs.microsoft.com/en-us/windows-hardware/drivers/ddi/content/wdm/nf-wdm-ntcreatetransactionmanager
		// __kernel_entry NTSYSCALLAPI NTSTATUS NtCreateTransactionManager( PHANDLE TmHandle, ACCESS_MASK DesiredAccess, POBJECT_ATTRIBUTES ObjectAttributes, PUNICODE_STRING LogFileName, ULONG CreateOptions, ULONG CommitStrength );
		[DllImport(Lib.NtDll, SetLastError = false, CharSet = CharSet.Auto)]
		[PInvokeData("wdm.h", MSDNShortId = "9c9f0a8b-7add-4ab1-835d-39f508ce32a9")]
		public static extern NTStatus NtCreateTransactionManager(out SafeTransactionManagerHandle TmHandle, ACCESS_MASK DesiredAccess, ref OBJECT_ATTRIBUTES ObjectAttributes,
			in UNICODE_STRING LogFileName, [Optional] uint CreateOptions, [Optional] uint CommitStrength);

		/// <summary>
		/// <para>
		/// The <c>ZwQueryKey</c> routine provides information about the class of a registry key, and the number and sizes of its subkeys.
		/// </para>
		/// </summary>
		/// <param name="KeyHandle">
		/// <para>
		/// Handle to the registry key to obtain information about. This handle is created by a successful call to ZwCreateKey or ZwOpenKey.
		/// </para>
		/// </param>
		/// <param name="KeyInformationClass">
		/// <para>Specifies a KEY_INFORMATION_CLASS value that determines the type of information returned in the KeyInformation buffer.</para>
		/// </param>
		/// <param name="KeyInformation">
		/// <para>Pointer to a caller-allocated buffer that receives the requested information.</para>
		/// </param>
		/// <param name="Length">
		/// <para>Specifies the size, in bytes, of the KeyInformation buffer.</para>
		/// </param>
		/// <param name="ResultLength">
		/// <para>
		/// Pointer to a variable that receives the size, in bytes, of the requested key information. If <c>ZwQueryKey</c> returns
		/// STATUS_SUCCESS, the variable contains the amount of data returned. If <c>ZwQueryKey</c> returns STATUS_BUFFER_OVERFLOW or
		/// STATUS_BUFFER_TOO_SMALL, you can use the value of the variable to determine the required buffer size.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>
		/// <c>ZwQueryKey</c> returns STATUS_SUCCESS on success, or the appropriate error code on failure. Possible error code values include:
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>STATUS_BUFFER_OVERFLOW</term>
		/// <term>
		/// The buffer supplied is too small, and only partial data has been written to the buffer. *ResultLength is set to the minimum size
		/// required to hold the requested information.
		/// </term>
		/// </item>
		/// <item>
		/// <term>STATUS_BUFFER_TOO_SMALL</term>
		/// <term>
		/// The buffer supplied is too small, and no data has been written to the buffer. *ResultLength is set to the minimum size required
		/// to hold the requested information.
		/// </term>
		/// </item>
		/// <item>
		/// <term>STATUS_INVALID_PARAMETER</term>
		/// <term>The KeyInformationClass parameter is not a valid KEY_INFORMATION_CLASS value.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The KeyHandle passed to <c>ZwQueryKey</c> must have been opened with KEY_QUERY_VALUE access. This is accomplished by passing
		/// KEY_QUERY_VALUE, KEY_READ, or KEY_ALL_ACCESS as the DesiredAccess parameter to ZwCreateKey or ZwOpenKey.
		/// </para>
		/// <para>
		/// <c>ZwQueryKey</c> can be used to obtain information that you can use to allocate buffers to hold registry data, such as the
		/// maximum size of a key's value entries or subkey names, or the number of subkeys. For example, you can call <c>ZwQueryKey</c>, use
		/// the returned information to allocate a buffer for a subkey, call ZwEnumerateKey to get the name of the subkey, and pass that name
		/// to an <c>Rtl</c><c>Xxx</c><c>Registry</c> routine.
		/// </para>
		/// <para>For more information about working with registry keys, see Using the Registry in a Driver.</para>
		/// <para>
		/// For calls from kernel-mode drivers, the <c>NtXxx</c> and <c>ZwXxx</c> versions of a Windows Native System Services routine can
		/// behave differently in the way that they handle and interpret input parameters. For more information about the relationship
		/// between the <c>NtXxx</c> and <c>ZwXxx</c> versions of a routine, see Using Nt and Zw Versions of the Native System Services Routines.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows-hardware/drivers/ddi/content/wdm/nf-wdm-zwquerykey NTSYSAPI NTSTATUS ZwQueryKey( HANDLE
		// KeyHandle, KEY_INFORMATION_CLASS KeyInformationClass, PVOID KeyInformation, ULONG Length, PULONG ResultLength );
		[DllImport(Lib.NtDll, SetLastError = false, ExactSpelling = true, CharSet = CharSet.Unicode)]
		[PInvokeData("wdm.h", MSDNShortId = "3b2d3a8b-a21f-4067-a1f0-9aa66c1973f5")]
		// public static extern NTSYSAPI NTSTATUS ZwQueryKey(IntPtr KeyHandle, KEY_INFORMATION_CLASS KeyInformationClass, IntPtr
		// KeyInformation, uint Length, ref uint ResultLength);
		public static extern NTStatus NtQueryKey(HKEY KeyHandle, KEY_INFORMATION_CLASS KeyInformationClass, SafeHGlobalHandle KeyInformation, uint Length, out uint ResultLength);

		/// <summary>
		/// <para>
		/// [ <c>NtQuerySystemInformation</c> may be altered or unavailable in future versions of Windows. Applications should use the
		/// alternate functions listed in this topic.]
		/// </para>
		/// <para>Retrieves the specified system information.</para>
		/// </summary>
		/// <param name="SystemInformationClass">
		/// <para>
		/// One of the values enumerated in SYSTEM_INFORMATION_CLASS, which indicate the kind of system information to be retrieved. These
		/// include the following values.
		/// </para>
		/// <para>SystemBasicInformation</para>
		/// <para>
		/// Returns the number of processors in the system in a <c>SYSTEM_BASIC_INFORMATION</c> structure. Use the GetSystemInfo function instead.
		/// </para>
		/// <para>SystemCodeIntegrityInformation</para>
		/// <para>
		/// Returns a <c>SYSTEM_CODEINTEGRITY_INFORMATION</c> structure that can be used to determine the options being enforced by Code
		/// Integrity on the system.
		/// </para>
		/// <para>SystemExceptionInformation</para>
		/// <para>
		/// Returns an opaque <c>SYSTEM_EXCEPTION_INFORMATION</c> structure that can be used to generate an unpredictable seed for a random
		/// number generator. Use the CryptGenRandom function instead.
		/// </para>
		/// <para>SystemInterruptInformation</para>
		/// <para>
		/// Returns an opaque <c>SYSTEM_INTERRUPT_INFORMATION</c> structure that can be used to generate an unpredictable seed for a random
		/// number generator. Use the CryptGenRandom function instead.
		/// </para>
		/// <para>SystemKernelVaShadowInformation</para>
		/// <para>
		/// Returns a <c>SYSTEM_KERNEL_VA_SHADOW_INFORMATION</c> structure that can be used to determine the speculation control settings for
		/// attacks involving rogue data cache loads (such as CVE-2017-5754).
		/// </para>
		/// <para>SystemLeapSecondInformation</para>
		/// <para>
		/// Returns an opaque <c>SYSTEM_LEAP_SECOND_INFORMATION</c> structure that can be used to enable or disable leap seconds system-wide.
		/// This setting will persist even after a reboot of the system.
		/// </para>
		/// <para>SystemLookasideInformation</para>
		/// <para>
		/// Returns an opaque <c>SYSTEM_LOOKASIDE_INFORMATION</c> structure that can be used to generate an unpredictable seed for a random
		/// number generator. Use the CryptGenRandom function instead.
		/// </para>
		/// <para>SystemPerformanceInformation</para>
		/// <para>
		/// Returns an opaque <c>SYSTEM_PERFORMANCE_INFORMATION</c> structure that can be used to generate an unpredictable seed for a random
		/// number generator. Use the CryptGenRandomfunction instead.
		/// </para>
		/// <para>SystemPolicyInformation</para>
		/// <para>
		/// Returns policy information in a <c>SYSTEM_POLICY_INFORMATION</c> structure. Use the SLGetWindowsInformation function instead to
		/// obtain policy information.
		/// </para>
		/// <para>SystemProcessInformation</para>
		/// <para>Returns an array of <c>SYSTEM_PROCESS_INFORMATION</c> structures, one for each process running in the system.</para>
		/// <para>
		/// These structures contain information about the resource usage of each process, including the number of threads and handles used
		/// by the process, the peak page-file usage, and the number of memory pages that the process has allocated.
		/// </para>
		/// <para>SystemProcessorPerformanceInformation</para>
		/// <para>
		/// Returns an array of <c>SYSTEM_PROCESSOR_PERFORMANCE_INFORMATION</c> structures, one for each processor installed in the system.
		/// </para>
		/// <para>SystemQueryPerformanceCounterInformation</para>
		/// <para>
		/// Returns a <c>SYSTEM_QUERY_PERFORMANCE_COUNTER_INFORMATION</c> structure that can be used to determine whether the system requires
		/// a kernel transition to retrieve the high-resolution performance counter information through a QueryPerformanceCounter function call.
		/// </para>
		/// <para>SystemRegistryQuotaInformation</para>
		/// <para>Returns a <c>SYSTEM_REGISTRY_QUOTA_INFORMATION</c> structure.</para>
		/// <para>SystemSpeculationControlInformation</para>
		/// <para>
		/// Returns a <c>SYSTEM_SPECULATION_CONTROL_INFORMATION</c> structure that can be used to determine the speculation control settings
		/// for attacks involving branch target injection (such as CVE-2017-5715).
		/// </para>
		/// <para>SystemTimeOfDayInformation</para>
		/// <para>
		/// Returns an opaque <c>SYSTEM_TIMEOFDAY_INFORMATION</c> structure that can be used to generate an unpredictable seed for a random
		/// number generator. Use the CryptGenRandom function instead.
		/// </para>
		/// </param>
		/// <param name="SystemInformation">
		/// <para>
		/// A pointer to a buffer that receives the requested information. The size and structure of this information varies depending on the
		/// value of the SystemInformationClass parameter:
		/// </para>
		/// <para>SYSTEM_BASIC_INFORMATION</para>
		/// <para>
		/// When the SystemInformationClass parameter is <c>SystemBasicInformation</c>, the buffer pointed to by the SystemInformation
		/// parameter should be large enough to hold a single <c>SYSTEM_BASIC_INFORMATION</c> structure having the following layout:
		/// </para>
		/// <code>
		/// typedef struct _SYSTEM_BASIC_INFORMATION {
		///     BYTE Reserved1[24];
		///     PVOID Reserved2[4];
		///     CCHAR NumberOfProcessors;
		/// } SYSTEM_BASIC_INFORMATION;"
		/// </code>
		/// <para>
		/// The <c>NumberOfProcessors</c> member contains the number of processors present in the system. Use GetSystemInfo instead to
		/// retrieve this information.
		/// </para>
		/// <para>The other members of the structure are reserved for internal use by the operating system.</para>
		/// <para>SYSTEM_CODEINTEGRITY_INFORMATION</para>
		/// <para>
		/// When the SystemInformationClass parameter is <c>SystemCodeIntegrityInformation</c>, the buffer pointed to by the
		/// SystemInformation parameter should be large enough to hold a single <c>SYSTEM_CODEINTEGRITY_INFORMATION</c> structure having the
		/// following layout:
		/// </para>
		/// <code>
		/// typedef struct _SYSTEM_CODEINTEGRITY_INFORMATION {
		///     ULONG  Length;
		///     ULONG  CodeIntegrityOptions;
		/// } SYSTEM_CODEINTEGRITY_INFORMATION, *PSYSTEM_CODEINTEGRITY_INFORMATION;"
		/// </code>
		/// <para>The <c>Length</c> member contains the size of the structure in bytes. This must be set by the caller.</para>
		/// <para>The <c>CodeIntegrityOptions</c> member contains a bitmask to identify code integrity options.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term/>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>0x01</term>
		/// <term>CODEINTEGRITY_OPTION_ENABLED</term>
		/// <term>Enforcement of kernel mode Code Integrity is enabled.</term>
		/// </item>
		/// <item>
		/// <term>0x02</term>
		/// <term>CODEINTEGRITY_OPTION_TESTSIGN</term>
		/// <term>Test signed content is allowed by Code Integrity.</term>
		/// </item>
		/// <item>
		/// <term>0x04</term>
		/// <term>CODEINTEGRITY_OPTION_UMCI_ENABLED</term>
		/// <term>Enforcement of user mode Code Integrity is enabled.</term>
		/// </item>
		/// <item>
		/// <term>0x08</term>
		/// <term>CODEINTEGRITY_OPTION_UMCI_AUDITMODE_ENABLED</term>
		/// <term>
		/// Enforcement of user mode Code Integrity is enabled in audit mode. Executables will be allowed to run/load; however, audit events
		/// will be recorded.
		/// </term>
		/// </item>
		/// <item>
		/// <term>0x10</term>
		/// <term>CODEINTEGRITY_OPTION_UMCI_EXCLUSIONPATHS_ENABLED</term>
		/// <term>
		/// User mode binaries being run from certain paths are allowed to run even if they fail code integrity checks. Exclusion paths are
		/// listed in the following registry key in REG_MULTI_SZ format: Paths added to this key should be in one of two formats: The
		/// following paths are restricted and cannot be added as an exclusion: Built-in Path Exclusions: The following paths are excluded by
		/// default. You don't need to specifically add these to path exclusions. This only applies on ARM (Windows Runtime).
		/// </term>
		/// </item>
		/// <item>
		/// <term>0x20</term>
		/// <term>CODEINTEGRITY_OPTION_TEST_BUILD</term>
		/// <term>The build of Code Integrity is from a test build.</term>
		/// </item>
		/// <item>
		/// <term>0x40</term>
		/// <term>CODEINTEGRITY_OPTION_PREPRODUCTION_BUILD</term>
		/// <term>The build of Code Integrity is from a pre-production build.</term>
		/// </item>
		/// <item>
		/// <term>0x80</term>
		/// <term>CODEINTEGRITY_OPTION_DEBUGMODE_ENABLED</term>
		/// <term>The kernel debugger is attached and Code Integrity may allow unsigned code to load.</term>
		/// </item>
		/// <item>
		/// <term>0x100</term>
		/// <term>CODEINTEGRITY_OPTION_FLIGHT_BUILD</term>
		/// <term>The build of Code Integrity is from a flight build.</term>
		/// </item>
		/// <item>
		/// <term>0x200</term>
		/// <term>CODEINTEGRITY_OPTION_FLIGHTING_ENABLED</term>
		/// <term>
		/// Flight signed content is allowed by Code Integrity. Flight signed content is content signed by the Microsoft Development Root
		/// Certificate Authority 2014.
		/// </term>
		/// </item>
		/// <item>
		/// <term>0x400</term>
		/// <term>CODEINTEGRITY_OPTION_HVCI_KMCI_ENABLED</term>
		/// <term>Hypervisor enforced Code Integrity is enabled for kernel mode components.</term>
		/// </item>
		/// <item>
		/// <term>0x800</term>
		/// <term>CODEINTEGRITY_OPTION_HVCI_KMCI_AUDITMODE_ENABLED</term>
		/// <term>
		/// Hypervisor enforced Code Integrity is enabled in audit mode. Audit events will be recorded for kernel mode components that are
		/// not compatible with HVCI. This bit can be set whether CODEINTEGRITY_OPTION_HVCI_KMCI_ENABLED is set or not.
		/// </term>
		/// </item>
		/// <item>
		/// <term>0x1000</term>
		/// <term>CODEINTEGRITY_OPTION_HVCI_KMCI_STRICTMODE_ENABLED</term>
		/// <term>Hypervisor enforced Code Integrity is enabled for kernel mode components, but in strict mode.</term>
		/// </item>
		/// <item>
		/// <term>0x2000</term>
		/// <term>CODEINTEGRITY_OPTION_HVCI_IUM_ENABLED</term>
		/// <term>Hypervisor enforced Code Integrity is enabled with enforcement of Isolated User Mode component signing.</term>
		/// </item>
		/// </list>
		/// <para>SYSTEM_EXCEPTION_INFORMATION</para>
		/// <para>
		/// When the SystemInformationClass parameter is <c>SystemExceptionInformation</c>, the buffer pointed to by the SystemInformation
		/// parameter should be large enough to hold an opaque <c>SYSTEM_EXCEPTION_INFORMATION</c> structure for use in generating an
		/// unpredictable seed for a random number generator. For this purpose, the structure has the following layout:
		/// </para>
		/// <code>
		/// typedef struct _SYSTEM_EXCEPTION_INFORMATION {
		///     BYTE Reserved1[16];
		/// } SYSTEM_EXCEPTION_INFORMATION;
		/// </code>
		/// <para>Individual members of the structure are reserved for internal use by the operating system.</para>
		/// <para>Use the CryptGenRandom function instead to generate cryptographically random data.</para>
		/// <para>SYSTEM_INTERRUPT_INFORMATION</para>
		/// <para>
		/// When the SystemInformationClass parameter is <c>SystemInterruptInformation</c>, the buffer pointed to by the SystemInformation
		/// parameter should be large enough to hold an array that contains as many opaque <c>SYSTEM_INTERRUPT_INFORMATION</c> structures as
		/// there are processors (CPUs) installed on the system. Each structure, or the array as a whole, can be used to generate an
		/// unpredictable seed for a random number generator. For this purpose, the structure has the following layout:
		/// </para>
		/// <code>
		/// typedef struct _SYSTEM_INTERRUPT_INFORMATION {
		///     BYTE Reserved1[24];
		/// } SYSTEM_INTERRUPT_INFORMATION;
		/// </code>
		/// <para>Individual members of the structure are reserved for internal use by the operating system.</para>
		/// <para>Use the CryptGenRandom function instead to generate cryptographically random data.</para>
		/// <para>SYSTEM_KERNEL_VA_SHADOW_INFORMATION</para>
		/// <para>
		/// When the SystemInformationClass parameter is <c>SystemKernelVaShadowInformation</c>, the buffer pointed to by the
		/// SystemInformation parameter should be large enough to hold a single <c>SYSTEM_KERNEL_VA_SHADOW_INFORMATION</c> structure having
		/// the following layout:
		/// </para>
		/// <code>
		/// typedef struct _SYSTEM_KERNEL_VA_SHADOW_INFORMATION {
		///     struct {
		///         ULONG KvaShadowEnabled:1;
		///         ULONG KvaShadowUserGlobal:1;
		///         ULONG KvaShadowPcid:1;
		///         ULONG KvaShadowInvpcid:1;
		///         ULONG Reserved:28;
		///     } KvaShadowFlags;
		/// } SYSTEM_KERNEL_VA_SHADOW_INFORMATION, * PSYSTEM_KERNEL_VA_SHADOW_INFORMATION;
		/// </code>
		/// <para>The <c>KvaShadowEnabled</c> indicates whether shadowing is enabled.</para>
		/// <para>The <c>KvaShadowUserGlobal</c> indicates that user/global is enabled.</para>
		/// <para>The <c>KvaShadowPcid</c> indicates whether PCID is enabled.</para>
		/// <para>The <c>KvaShadowInvpcid</c> indicates whether PCID is enabled and whether INVPCID is in use.</para>
		/// <para>The <c>Reserved</c> member of the structure is reserved for internal use by the operating system.</para>
		/// <para>SYSTEM_LEAP_SECOND_INFORMATION</para>
		/// <para>
		/// When the SystemInformationClass parameter is <c>SystemLeapSecondInformation</c>, the buffer pointed to by the SystemInformation
		/// parameter should be large enough to hold an opaque <c>SYSTEM_LEAP_SECOND_INFORMATION</c> structure for use in enabling or
		/// disabling leap seconds system-wide. This setting will persist even after a reboot of the system. For this purpose, the structure
		/// has the following layout:
		/// </para>
		/// <code>
		/// typedef struct _SYSTEM_LEAP_SECOND_INFORMATION {
		///     BOOLEAN Enabled;
		///     ULONG Flags;
		/// } SYSTEM_LEAP_SECOND_INFORMATION
		/// </code>
		/// <para>The <c>Flags</c> field is reserved for future use.</para>
		/// <para>SYSTEM_LOOKASIDE_INFORMATION</para>
		/// <para>
		/// When the SystemInformationClass parameter is <c>SystemLookasideInformation</c>, the buffer pointed to by the SystemInformation
		/// parameter should be large enough to hold an opaque <c>SYSTEM_LOOKASIDE_INFORMATION</c> structure for use in generating an
		/// unpredictable seed for a random number generator. For this purpose, the structure has the following layout:
		/// </para>
		/// <code>
		/// typedef struct _SYSTEM_LOOKASIDE_INFORMATION {
		///     BYTE Reserved1[32];
		/// } SYSTEM_LOOKASIDE_INFORMATION;
		/// </code>
		/// <para>Individual members of the structure are reserved for internal use by the operating system.</para>
		/// <para>Use the CryptGenRandom function instead to generate cryptographically random data.</para>
		/// <para>SYSTEM_PERFORMANCE_INFORMATION</para>
		/// <para>
		/// When the SystemInformationClass parameter is <c>SystemPerformanceInformation</c>, the buffer pointed to by the SystemInformation
		/// parameter should be large enough to hold an opaque <c>SYSTEM_PERFORMANCE_INFORMATION</c> structure for use in generating an
		/// unpredictable seed for a random number generator. For this purpose, the structure has the following layout:
		/// </para>
		/// <code>
		/// typedef struct _SYSTEM_PERFORMANCE_INFORMATION {
		///     BYTE Reserved1[312];
		/// } SYSTEM_PERFORMANCE_INFORMATION;
		/// </code>
		/// <para>Individual members of the structure are reserved for internal use by the operating system.</para>
		/// <para>Use the CryptGenRandom function instead to generate cryptographically random data.</para>
		/// <para>SYSTEM_POLICY_INFORMATION</para>
		/// <para>
		/// When the SystemInformationClass parameter is <c>SystemPolicyInformation</c>, the buffer pointed to by the SystemInformation
		/// parameter should be large enough to hold a single <c>SYSTEM_POLICY_INFORMATION</c> structure having the following layout:
		/// </para>
		/// <code>
		/// typedef struct _SYSTEM_POLICY_INFORMATION {
		///     PVOID Reserved1[2];
		///     ULONG Reserved2[3];
		/// } SYSTEM_POLICY_INFORMATION;
		/// </code>
		/// <para>Individual members of the structure are reserved for internal use by the operating system.</para>
		/// <para>Use the SLGetWindowsInformation function instead to obtain policy information.</para>
		/// <para>SYSTEM_PROCESS_INFORMATION</para>
		/// <para>
		/// When the SystemInformationClass parameter is <c>SystemProcessInformation</c>, the buffer pointed to by the SystemInformation
		/// parameter contains a <c>SYSTEM_PROCESS_INFORMATION</c> structure for each process. Each of these structures is immediately
		/// followed in memory by one or more <c>SYSTEM_THREAD_INFORMATION</c> structures that provide info for each thread in the preceding
		/// process. For more information about <c>SYSTEM_THREAD_INFORMATION</c>, see the section about this structure in this article.
		/// </para>
		/// <para>
		/// The buffer pointed to by the SystemInformation parameter should be large enough to hold an array that contains as many
		/// <c>SYSTEM_PROCESS_INFORMATION</c> and <c>SYSTEM_THREAD_INFORMATION</c> structures as there are processes and threads running in
		/// the system. This size is specified by the ReturnLength parameter.
		/// </para>
		/// <para>Each <c>SYSTEM_PROCESS_INFORMATION</c> structure has the following layout:</para>
		/// <code>
		/// typedef struct _SYSTEM_PROCESS_INFORMATION {
		///     ULONG NextEntryOffset;
		///     ULONG NumberOfThreads;
		///     BYTE Reserved1[48];
		///     UNICODE_STRING ImageName;
		///     KPRIORITY BasePriority;
		///     HANDLE UniqueProcessId;
		///     PVOID Reserved2;
		///     ULONG HandleCount;
		///     ULONG SessionId;
		///     PVOID Reserved3;
		///     SIZE_T PeakVirtualSize;
		///     SIZE_T VirtualSize;
		///     ULONG Reserved4;
		///     SIZE_T PeakWorkingSetSize;
		///     SIZE_T WorkingSetSize;
		///     PVOID Reserved5;
		///     SIZE_T QuotaPagedPoolUsage;
		///     PVOID Reserved6;
		///     SIZE_T QuotaNonPagedPoolUsage;
		///     SIZE_T PagefileUsage;
		///     SIZE_T PeakPagefileUsage;
		///     SIZE_T PrivatePageCount;
		///     LARGE_INTEGER Reserved7[6];
		/// } SYSTEM_PROCESS_INFORMATION;
		/// </code>
		/// <para>
		/// The start of the next item in the array is the address of the previous item plus the value in the <c>NextEntryOffset</c> member.
		/// For the last item in the array, <c>NextEntryOffset</c> is 0.
		/// </para>
		/// <para>The <c>NumberOfThreads</c> member contains the number of threads in the process.</para>
		/// <para>The <c>ImageName</c> member contains the process's image name.</para>
		/// <para>
		/// The <c>BasePriority</c> member contains the base priority of the process, which is the starting priority for threads created
		/// within the associated process.
		/// </para>
		/// <para>The <c>UniqueProcessId</c> member contains the process's unique process ID.</para>
		/// <para>
		/// The <c>HandleCount</c> member contains the total number of handles being used by the process in question; use
		/// GetProcessHandleCount to retrieve this information instead.
		/// </para>
		/// <para>The <c>SessionId</c> member contains the session identifier of the process session.</para>
		/// <para>The <c>PeakVirtualSize</c> member contains the peak size, in bytes, of the virtual memory used by the process.</para>
		/// <para>The <c>VirtualSize</c> member contains the current size, in bytes, of virtual memory used by the process.</para>
		/// <para>The <c>PeakWorkingSetSize</c> member contains the peak size, in kilobytes, of the working set of the process.</para>
		/// <para>The <c>QuotaPagedPoolUsage</c> member contains the current quota charged to the process for paged pool usage.</para>
		/// <para>The <c>QuotaNonPagedPoolUsage</c> member contains the current quota charged to the process for nonpaged pool usage.</para>
		/// <para>The <c>PagefileUsage</c> member contains the number of bytes of page file storage in use by the process.</para>
		/// <para>The <c>PeakPagefileUsage</c> member contains the maximum number of bytes of page-file storage used by the process.</para>
		/// <para>The <c>PrivatePageCount</c> member contains the number of memory pages allocated for the use of this process.</para>
		/// <para>
		/// You can also retrieve the <c>PeakWorkingSetSize</c>, <c>QuotaPagedPoolUsage</c>, <c>QuotaNonPagedPoolUsage</c>,
		/// <c>PagefileUsage</c>, <c>PeakPagefileUsage</c>, and <c>PrivatePageCount</c> information using either the GetProcessMemoryInfo
		/// function or the Win32_Process class.
		/// </para>
		/// <para>The other members of the structure are reserved for internal use by the operating system.</para>
		/// <para>SYSTEM_THREAD_INFORMATION</para>
		/// <para>
		/// When the SystemInformationClass parameter is <c>SystemProcessInformation</c>, the buffer pointed to by the SystemInformation
		/// parameter contains a <c>SYSTEM_PROCESS_INFORMATION</c> structure for each process. Each of these structures is immediately
		/// followed in memory by one or more <c>SYSTEM_THREAD_INFORMATION</c> structures that provide info for each thread in the preceding
		/// process. For more information about <c>SYSTEM_PROCESS_INFORMATION</c>, see the section about this structure in this article. Each
		/// <c>SYSTEM_THREAD_INFORMATION</c> structure has the following layout:
		/// </para>
		/// <code>
		/// typedef struct _SYSTEM_THREAD_INFORMATION {
		///     LARGE_INTEGER Reserved1[3];
		///     ULONG Reserved2;
		///     PVOID StartAddress;
		///     CLIENT_ID ClientId;
		///     KPRIORITY Priority;
		///     LONG BasePriority;
		///     ULONG Reserved3;
		///     ULONG ThreadState;
		///     ULONG WaitReason;
		/// } SYSTEM_THREAD_INFORMATION;
		/// </code>
		/// <para>The <c>StartAddress</c> member contains the start address of the thread.</para>
		/// <para>The <c>ClientId</c> member contains the ID of the thread and the process owning the thread.</para>
		/// <para>The <c>Priority</c> member contains the dynamic thread priority.</para>
		/// <para>The <c>BasePriority</c> member contains the base thread priority.</para>
		/// <para>The <c>ThreadState</c> member contains the current thread state.</para>
		/// <para>The <c>WaitReason</c> member contains the reason the thread is waiting.</para>
		/// <para>The other members of the structure are reserved for internal use by the operating system.</para>
		/// <para>SYSTEM_PROCESSOR_PERFORMANCE_INFORMATION</para>
		/// <para>
		/// When the SystemInformationClass parameter is <c>SystemProcessorPerformanceInformation</c>, the buffer pointed to by the
		/// SystemInformation parameter should be large enough to hold an array that contains as many
		/// <c>SYSTEM_PROCESSOR_PERFORMANCE_INFORMATION</c> structures as there are processors (CPUs) installed in the system. Each structure
		/// has the following layout:
		/// </para>
		/// <code>
		/// typedef struct
		/// _SYSTEM_PROCESSOR_PERFORMANCE_INFORMATION {
		///     LARGE_INTEGER IdleTime;
		///     LARGE_INTEGER KernelTime;
		///     LARGE_INTEGER UserTime;
		///     LARGE_INTEGER Reserved1[2];
		///     ULONG Reserved2;
		/// } SYSTEM_PROCESSOR_PERFORMANCE_INFORMATION;
		/// </code>
		/// <para>The <c>IdleTime</c> member contains the amount of time that the system has been idle, in 100-nanosecond intervals.</para>
		/// <para>
		/// The <c>KernelTime</c> member contains the amount of time that the system has spent executing in Kernel mode (including all
		/// threads in all processes, on all processors), in 100-nanosecond intervals.
		/// </para>
		/// <para>
		/// The <c>UserTime</c> member contains the amount of time that the system has spent executing in User mode (including all threads in
		/// all processes, on all processors), in 100-nanosecond intervals.
		/// </para>
		/// <para>Use GetSystemTimesinstead to retrieve this information.</para>
		/// <para>SYSTEM_QUERY_PERFORMANCE_COUNTER_INFORMATION</para>
		/// <para>
		/// When the SystemInformationClass parameter is <c>SystemQueryPerformanceCounterInformation</c>, the buffer pointed to by the
		/// SystemInformation parameter should be large enough to hold a single <c>SYSTEM_QUERY_PERFORMANCE_COUNTER_INFORMATION</c> structure
		/// having the following layout:
		/// </para>
		/// <code>
		/// typedef struct _SYSTEM_QUERY_PERFORMANCE_COUNTER_INFORMATION {
		///     ULONG                           Version;
		///     QUERY_PERFORMANCE_COUNTER_FLAGS Flags;
		///     QUERY_PERFORMANCE_COUNTER_FLAGS ValidFlags;
		/// } SYSTEM_QUERY_PERFORMANCE_COUNTER_INFORMATION;
		/// </code>
		/// <para>
		/// The <c>Flags</c> and <c>ValidFlags</c> members are <c>QUERY_PERFORMANCE_COUNTER_FLAGS</c> structures having the following layout:
		/// </para>
		/// <code>
		/// typedef struct _QUERY_PERFORMANCE_COUNTER_FLAGS {
		///     union {
		///         struct {
		///             ULONG KernelTransition:1;
		///             ULONG Reserved:31;
		///         };
		///         ULONG ul;
		///     };
		/// } QUERY_PERFORMANCE_COUNTER_FLAGS;
		/// </code>
		/// <para>
		/// The <c>ValidFlags</c> member of the <c>SYSTEM_QUERY_PERFORMANCE_COUNTER_INFORMATION</c> structure indicates which bits of the
		/// <c>Flags</c> member contain valid information. If a kernel transition is required, the <c>KernelTransition</c> bit is set in both
		/// <c>ValidFlags</c> and <c>Flags</c>. If a kernel transition is not required, the <c>KernelTransition</c> bit is set in
		/// <c>ValidFlags</c> and clear in <c>Flags</c>.
		/// </para>
		/// <para>SYSTEM_REGISTRY_QUOTA_INFORMATION</para>
		/// <para>
		/// When the SystemInformationClass parameter is <c>SystemRegistryQuotaInformation</c>, the buffer pointed to by the
		/// SystemInformation parameter should be large enough to hold a single <c>SYSTEM_REGISTRY_QUOTA_INFORMATION</c> structure having the
		/// following layout:
		/// </para>
		/// <code>
		/// typedef struct _SYSTEM_REGISTRY_QUOTA_INFORMATION {
		///     ULONG RegistryQuotaAllowed;
		///     ULONG RegistryQuotaUsed;
		///     PVOID Reserved1;
		/// } SYSTEM_REGISTRY_QUOTA_INFORMATION;
		/// </code>
		/// <para>The <c>RegistryQuotaAllowed</c> member contains the maximum size, in bytes, that the Registry can attain on this system.</para>
		/// <para>The <c>RegistryQuotaUsed</c> member contains the current size of the Registry, in bytes.</para>
		/// <para>Use GetSystemRegistryQuota instead to retrieve this information.</para>
		/// <para>The other member of the structure is reserved for internal use by the operating system.</para>
		/// <para>SYSTEM_SPECULATION_CONTROL_INFORMATION</para>
		/// <para>
		/// When the SystemInformationClass parameter is <c>SystemSpeculationControlInformation</c>, the buffer pointed to by the
		/// SystemInformation parameter should be large enough to hold a single <c>SYSTEM_SPECULATION_CONTROL_INFORMATION</c> structure
		/// having the following layout:
		/// </para>
		/// <code>
		/// typedef struct _SYSTEM_SPECULATION_CONTROL_INFORMATION {
		///     struct {
		///          ULONG BpbEnabled:1;
		///          ULONG BpbDisabledSystemPolicy:1;
		///          ULONG BpbDisabledNoHardwareSupport:1;
		///          ULONG SpecCtrlEnumerated:1;
		///          ULONG SpecCmdEnumerated:1;
		///          ULONG IbrsPresent:1;
		///          ULONG StibpPresent:1;
		///          ULONG SmepPresent:1;
		///          ULONG Reserved:24;
		///     } SpeculationControlFlags;
		///
		/// } SYSTEM_SPECULATION_CONTROL_INFORMATION, * PSYSTEM_SPECULATION_CONTROL_INFORMATION;
		/// </code>
		/// <para>The <c>BpbEnabled</c> indicates whether speculation control features are supported and enabled.</para>
		/// <para>The <c>BpbDisabledSystemPolicy</c> indicates whether speculation control features are disabled due to system policy.</para>
		/// <para>
		/// The <c>BpbDisabledNoHardwareSupport</c> whether speculation control features are disabled due to the absence of hardware support.
		/// </para>
		/// <para>The <c>SpecCtrlEnumerated</c> whether the IA32_SPEC_CTRL MSR is enumerated by hardware.</para>
		/// <para>The <c>SpecCmdEnumerated</c> indicates whether the IA32_SPEC_CMD MSR is enumerated by hardware.</para>
		/// <para>The <c>IbrsPresent</c> indicates whether the IBRS MSR is treated as being present.</para>
		/// <para>The <c>StibpPresent</c> indicates whether the STIBP MSR is present.</para>
		/// <para>The <c>SmepPresent</c> indicates whether the SMEP feature is present and enabled.</para>
		/// <para>The <c>Reserved</c> member of the structure is reserved for internal use by the operating system.</para>
		/// <para>SYSTEM_TIMEOFDAY_INFORMATION</para>
		/// <para>
		/// When the SystemInformationClass parameter is <c>SystemTimeOfDayInformation</c>, the buffer pointed to by the SystemInformation
		/// parameter should be large enough to hold an opaque <c>SYSTEM_TIMEOFDAY_INFORMATION</c> structure for use in generating an
		/// unpredictable seed for a random number generator. For this purpose, the structure has the following layout:
		/// </para>
		/// <code>
		/// typedef struct _SYSTEM_TIMEOFDAY_INFORMATION {
		///     BYTE Reserved1[48];
		/// } SYSTEM_TIMEOFDAY_INFORMATION;
		/// </code>
		/// <para>Individual members of the structure are reserved for internal use by the operating system.</para>
		/// <para>Use the CryptGenRandom function instead to generate cryptographically random data.</para>
		/// </param>
		/// <param name="SystemInformationLength">
		/// <para>The size of the buffer pointed to by the SystemInformationparameter, in bytes.</para>
		/// </param>
		/// <param name="ReturnLength"/>
		/// <returns>
		/// <para>Returns an NTSTATUS success or error code.</para>
		/// <para>
		/// The forms and significance of NTSTATUS error codes are listed in the Ntstatus.h header file available in the DDK, and are
		/// described in the DDK documentation.
		/// </para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The <c>NtQuerySystemInformation</c> function and the structures that it returns are internal to the operating system and subject
		/// to change from one release of Windows to another. To maintain the compatibility of your application, it is better to use the
		/// alternate functions previously mentioned instead.
		/// </para>
		/// <para>
		/// If you do use <c>NtQuerySystemInformation</c>, access the function through run-time dynamic linking. This gives your code an
		/// opportunity to respond gracefully if the function has been changed or removed from the operating system. Signature changes,
		/// however, may not be detectable.
		/// </para>
		/// <para>
		/// This function has no associated import library. You must use the LoadLibrary and GetProcAddress functions to dynamically link to Ntdll.dll.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winternl/nf-winternl-ntquerysysteminformation __kernel_entry NTSTATUS
		// NtQuerySystemInformation( IN SYSTEM_INFORMATION_CLASS SystemInformationClass, OUT PVOID SystemInformation, IN ULONG
		// SystemInformationLength, OUT PULONG ReturnLength OPTIONAL );
		[DllImport(Lib.NtDll, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("winternl.h", MSDNShortId = "553ec7b9-c5eb-4955-8dc0-f1c06f59fe31")]
		public static extern NTStatus NtQuerySystemInformation(SYSTEM_INFORMATION_CLASS SystemInformationClass, SafeHGlobalHandle SystemInformation, uint SystemInformationLength, out uint ReturnLength);

		/// <summary>
		/// <para>
		/// [ <c>NtQuerySystemInformation</c> may be altered or unavailable in future versions of Windows. Applications should use the
		/// alternate functions listed in this topic.]
		/// </para>
		/// <para>Retrieves the specified system information.</para>
		/// </summary>
		/// <typeparam name="T">The type of the return value.</typeparam>
		/// <param name="SystemInformationClass">
		/// <para>
		/// One of the values enumerated in SYSTEM_INFORMATION_CLASS, which indicate the kind of system information to be retrieved. These
		/// include the following values.
		/// </para>
		/// <para>SystemBasicInformation</para>
		/// <para>
		/// Returns the number of processors in the system in a <c>SYSTEM_BASIC_INFORMATION</c> structure. Use the GetSystemInfo function instead.
		/// </para>
		/// <para>SystemCodeIntegrityInformation</para>
		/// <para>
		/// Returns a <c>SYSTEM_CODEINTEGRITY_INFORMATION</c> structure that can be used to determine the options being enforced by Code
		/// Integrity on the system.
		/// </para>
		/// <para>SystemExceptionInformation</para>
		/// <para>
		/// Returns an opaque <c>SYSTEM_EXCEPTION_INFORMATION</c> structure that can be used to generate an unpredictable seed for a random
		/// number generator. Use the CryptGenRandom function instead.
		/// </para>
		/// <para>SystemInterruptInformation</para>
		/// <para>
		/// Returns an opaque <c>SYSTEM_INTERRUPT_INFORMATION</c> structure that can be used to generate an unpredictable seed for a random
		/// number generator. Use the CryptGenRandom function instead.
		/// </para>
		/// <para>SystemKernelVaShadowInformation</para>
		/// <para>
		/// Returns a <c>SYSTEM_KERNEL_VA_SHADOW_INFORMATION</c> structure that can be used to determine the speculation control settings for
		/// attacks involving rogue data cache loads (such as CVE-2017-5754).
		/// </para>
		/// <para>SystemLeapSecondInformation</para>
		/// <para>
		/// Returns an opaque <c>SYSTEM_LEAP_SECOND_INFORMATION</c> structure that can be used to enable or disable leap seconds system-wide.
		/// This setting will persist even after a reboot of the system.
		/// </para>
		/// <para>SystemLookasideInformation</para>
		/// <para>
		/// Returns an opaque <c>SYSTEM_LOOKASIDE_INFORMATION</c> structure that can be used to generate an unpredictable seed for a random
		/// number generator. Use the CryptGenRandom function instead.
		/// </para>
		/// <para>SystemPerformanceInformation</para>
		/// <para>
		/// Returns an opaque <c>SYSTEM_PERFORMANCE_INFORMATION</c> structure that can be used to generate an unpredictable seed for a random
		/// number generator. Use the CryptGenRandomfunction instead.
		/// </para>
		/// <para>SystemPolicyInformation</para>
		/// <para>
		/// Returns policy information in a <c>SYSTEM_POLICY_INFORMATION</c> structure. Use the SLGetWindowsInformation function instead to
		/// obtain policy information.
		/// </para>
		/// <para>SystemProcessInformation</para>
		/// <para>Returns an array of <c>SYSTEM_PROCESS_INFORMATION</c> structures, one for each process running in the system.</para>
		/// <para>
		/// These structures contain information about the resource usage of each process, including the number of threads and handles used
		/// by the process, the peak page-file usage, and the number of memory pages that the process has allocated.
		/// </para>
		/// <para>SystemProcessorPerformanceInformation</para>
		/// <para>
		/// Returns an array of <c>SYSTEM_PROCESSOR_PERFORMANCE_INFORMATION</c> structures, one for each processor installed in the system.
		/// </para>
		/// <para>SystemQueryPerformanceCounterInformation</para>
		/// <para>
		/// Returns a <c>SYSTEM_QUERY_PERFORMANCE_COUNTER_INFORMATION</c> structure that can be used to determine whether the system requires
		/// a kernel transition to retrieve the high-resolution performance counter information through a QueryPerformanceCounter function call.
		/// </para>
		/// <para>SystemRegistryQuotaInformation</para>
		/// <para>Returns a <c>SYSTEM_REGISTRY_QUOTA_INFORMATION</c> structure.</para>
		/// <para>SystemSpeculationControlInformation</para>
		/// <para>
		/// Returns a <c>SYSTEM_SPECULATION_CONTROL_INFORMATION</c> structure that can be used to determine the speculation control settings
		/// for attacks involving branch target injection (such as CVE-2017-5715).
		/// </para>
		/// <para>SystemTimeOfDayInformation</para>
		/// <para>
		/// Returns an opaque <c>SYSTEM_TIMEOFDAY_INFORMATION</c> structure that can be used to generate an unpredictable seed for a random
		/// number generator. Use the CryptGenRandom function instead.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>
		/// A pointer to a buffer that receives the requested information. The size and structure of this information varies depending on the
		/// value of the SystemInformationClass parameter:
		/// </para>
		/// <para>SYSTEM_BASIC_INFORMATION</para>
		/// <para>
		/// When the SystemInformationClass parameter is <c>SystemBasicInformation</c>, the buffer pointed to by the SystemInformation
		/// parameter should be large enough to hold a single <c>SYSTEM_BASIC_INFORMATION</c> structure having the following layout:
		/// </para>
		/// <code>
		/// typedef struct _SYSTEM_BASIC_INFORMATION {
		/// BYTE Reserved1[24];
		/// PVOID Reserved2[4];
		/// CCHAR NumberOfProcessors;
		/// } SYSTEM_BASIC_INFORMATION;"
		/// </code>
		/// <para>
		/// The <c>NumberOfProcessors</c> member contains the number of processors present in the system. Use GetSystemInfo instead to
		/// retrieve this information.
		/// </para>
		/// <para>The other members of the structure are reserved for internal use by the operating system.</para>
		/// <para>SYSTEM_CODEINTEGRITY_INFORMATION</para>
		/// <para>
		/// When the SystemInformationClass parameter is <c>SystemCodeIntegrityInformation</c>, the buffer pointed to by the
		/// SystemInformation parameter should be large enough to hold a single <c>SYSTEM_CODEINTEGRITY_INFORMATION</c> structure having the
		/// following layout:
		/// </para>
		/// <code>
		/// typedef struct _SYSTEM_CODEINTEGRITY_INFORMATION {
		/// ULONG  Length;
		/// ULONG  CodeIntegrityOptions;
		/// } SYSTEM_CODEINTEGRITY_INFORMATION, *PSYSTEM_CODEINTEGRITY_INFORMATION;"
		/// </code>
		/// <para>The <c>Length</c> member contains the size of the structure in bytes. This must be set by the caller.</para>
		/// <para>The <c>CodeIntegrityOptions</c> member contains a bitmask to identify code integrity options.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term/>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>0x01</term>
		/// <term>CODEINTEGRITY_OPTION_ENABLED</term>
		/// <term>Enforcement of kernel mode Code Integrity is enabled.</term>
		/// </item>
		/// <item>
		/// <term>0x02</term>
		/// <term>CODEINTEGRITY_OPTION_TESTSIGN</term>
		/// <term>Test signed content is allowed by Code Integrity.</term>
		/// </item>
		/// <item>
		/// <term>0x04</term>
		/// <term>CODEINTEGRITY_OPTION_UMCI_ENABLED</term>
		/// <term>Enforcement of user mode Code Integrity is enabled.</term>
		/// </item>
		/// <item>
		/// <term>0x08</term>
		/// <term>CODEINTEGRITY_OPTION_UMCI_AUDITMODE_ENABLED</term>
		/// <term>
		/// Enforcement of user mode Code Integrity is enabled in audit mode. Executables will be allowed to run/load; however, audit events
		/// will be recorded.
		/// </term>
		/// </item>
		/// <item>
		/// <term>0x10</term>
		/// <term>CODEINTEGRITY_OPTION_UMCI_EXCLUSIONPATHS_ENABLED</term>
		/// <term>
		/// User mode binaries being run from certain paths are allowed to run even if they fail code integrity checks. Exclusion paths are
		/// listed in the following registry key in REG_MULTI_SZ format: Paths added to this key should be in one of two formats: The
		/// following paths are restricted and cannot be added as an exclusion: Built-in Path Exclusions: The following paths are excluded by
		/// default. You don't need to specifically add these to path exclusions. This only applies on ARM (Windows Runtime).
		/// </term>
		/// </item>
		/// <item>
		/// <term>0x20</term>
		/// <term>CODEINTEGRITY_OPTION_TEST_BUILD</term>
		/// <term>The build of Code Integrity is from a test build.</term>
		/// </item>
		/// <item>
		/// <term>0x40</term>
		/// <term>CODEINTEGRITY_OPTION_PREPRODUCTION_BUILD</term>
		/// <term>The build of Code Integrity is from a pre-production build.</term>
		/// </item>
		/// <item>
		/// <term>0x80</term>
		/// <term>CODEINTEGRITY_OPTION_DEBUGMODE_ENABLED</term>
		/// <term>The kernel debugger is attached and Code Integrity may allow unsigned code to load.</term>
		/// </item>
		/// <item>
		/// <term>0x100</term>
		/// <term>CODEINTEGRITY_OPTION_FLIGHT_BUILD</term>
		/// <term>The build of Code Integrity is from a flight build.</term>
		/// </item>
		/// <item>
		/// <term>0x200</term>
		/// <term>CODEINTEGRITY_OPTION_FLIGHTING_ENABLED</term>
		/// <term>
		/// Flight signed content is allowed by Code Integrity. Flight signed content is content signed by the Microsoft Development Root
		/// Certificate Authority 2014.
		/// </term>
		/// </item>
		/// <item>
		/// <term>0x400</term>
		/// <term>CODEINTEGRITY_OPTION_HVCI_KMCI_ENABLED</term>
		/// <term>Hypervisor enforced Code Integrity is enabled for kernel mode components.</term>
		/// </item>
		/// <item>
		/// <term>0x800</term>
		/// <term>CODEINTEGRITY_OPTION_HVCI_KMCI_AUDITMODE_ENABLED</term>
		/// <term>
		/// Hypervisor enforced Code Integrity is enabled in audit mode. Audit events will be recorded for kernel mode components that are
		/// not compatible with HVCI. This bit can be set whether CODEINTEGRITY_OPTION_HVCI_KMCI_ENABLED is set or not.
		/// </term>
		/// </item>
		/// <item>
		/// <term>0x1000</term>
		/// <term>CODEINTEGRITY_OPTION_HVCI_KMCI_STRICTMODE_ENABLED</term>
		/// <term>Hypervisor enforced Code Integrity is enabled for kernel mode components, but in strict mode.</term>
		/// </item>
		/// <item>
		/// <term>0x2000</term>
		/// <term>CODEINTEGRITY_OPTION_HVCI_IUM_ENABLED</term>
		/// <term>Hypervisor enforced Code Integrity is enabled with enforcement of Isolated User Mode component signing.</term>
		/// </item>
		/// </list>
		/// <para>SYSTEM_EXCEPTION_INFORMATION</para>
		/// <para>
		/// When the SystemInformationClass parameter is <c>SystemExceptionInformation</c>, the buffer pointed to by the SystemInformation
		/// parameter should be large enough to hold an opaque <c>SYSTEM_EXCEPTION_INFORMATION</c> structure for use in generating an
		/// unpredictable seed for a random number generator. For this purpose, the structure has the following layout:
		/// </para>
		/// <code>
		/// typedef struct _SYSTEM_EXCEPTION_INFORMATION {
		/// BYTE Reserved1[16];
		/// } SYSTEM_EXCEPTION_INFORMATION;
		/// </code>
		/// <para>Individual members of the structure are reserved for internal use by the operating system.</para>
		/// <para>Use the CryptGenRandom function instead to generate cryptographically random data.</para>
		/// <para>SYSTEM_INTERRUPT_INFORMATION</para>
		/// <para>
		/// When the SystemInformationClass parameter is <c>SystemInterruptInformation</c>, the buffer pointed to by the SystemInformation
		/// parameter should be large enough to hold an array that contains as many opaque <c>SYSTEM_INTERRUPT_INFORMATION</c> structures as
		/// there are processors (CPUs) installed on the system. Each structure, or the array as a whole, can be used to generate an
		/// unpredictable seed for a random number generator. For this purpose, the structure has the following layout:
		/// </para>
		/// <code>
		/// typedef struct _SYSTEM_INTERRUPT_INFORMATION {
		/// BYTE Reserved1[24];
		/// } SYSTEM_INTERRUPT_INFORMATION;
		/// </code>
		/// <para>Individual members of the structure are reserved for internal use by the operating system.</para>
		/// <para>Use the CryptGenRandom function instead to generate cryptographically random data.</para>
		/// <para>SYSTEM_KERNEL_VA_SHADOW_INFORMATION</para>
		/// <para>
		/// When the SystemInformationClass parameter is <c>SystemKernelVaShadowInformation</c>, the buffer pointed to by the
		/// SystemInformation parameter should be large enough to hold a single <c>SYSTEM_KERNEL_VA_SHADOW_INFORMATION</c> structure having
		/// the following layout:
		/// </para>
		/// <code>
		/// typedef struct _SYSTEM_KERNEL_VA_SHADOW_INFORMATION {
		/// struct {
		/// ULONG KvaShadowEnabled:1;
		/// ULONG KvaShadowUserGlobal:1;
		/// ULONG KvaShadowPcid:1;
		/// ULONG KvaShadowInvpcid:1;
		/// ULONG Reserved:28;
		/// } KvaShadowFlags;
		/// } SYSTEM_KERNEL_VA_SHADOW_INFORMATION, * PSYSTEM_KERNEL_VA_SHADOW_INFORMATION;
		/// </code>
		/// <para>The <c>KvaShadowEnabled</c> indicates whether shadowing is enabled.</para>
		/// <para>The <c>KvaShadowUserGlobal</c> indicates that user/global is enabled.</para>
		/// <para>The <c>KvaShadowPcid</c> indicates whether PCID is enabled.</para>
		/// <para>The <c>KvaShadowInvpcid</c> indicates whether PCID is enabled and whether INVPCID is in use.</para>
		/// <para>The <c>Reserved</c> member of the structure is reserved for internal use by the operating system.</para>
		/// <para>SYSTEM_LEAP_SECOND_INFORMATION</para>
		/// <para>
		/// When the SystemInformationClass parameter is <c>SystemLeapSecondInformation</c>, the buffer pointed to by the SystemInformation
		/// parameter should be large enough to hold an opaque <c>SYSTEM_LEAP_SECOND_INFORMATION</c> structure for use in enabling or
		/// disabling leap seconds system-wide. This setting will persist even after a reboot of the system. For this purpose, the structure
		/// has the following layout:
		/// </para>
		/// <code>
		/// typedef struct _SYSTEM_LEAP_SECOND_INFORMATION {
		/// BOOLEAN Enabled;
		/// ULONG Flags;
		/// } SYSTEM_LEAP_SECOND_INFORMATION
		/// </code>
		/// <para>The <c>Flags</c> field is reserved for future use.</para>
		/// <para>SYSTEM_LOOKASIDE_INFORMATION</para>
		/// <para>
		/// When the SystemInformationClass parameter is <c>SystemLookasideInformation</c>, the buffer pointed to by the SystemInformation
		/// parameter should be large enough to hold an opaque <c>SYSTEM_LOOKASIDE_INFORMATION</c> structure for use in generating an
		/// unpredictable seed for a random number generator. For this purpose, the structure has the following layout:
		/// </para>
		/// <code>
		/// typedef struct _SYSTEM_LOOKASIDE_INFORMATION {
		/// BYTE Reserved1[32];
		/// } SYSTEM_LOOKASIDE_INFORMATION;
		/// </code>
		/// <para>Individual members of the structure are reserved for internal use by the operating system.</para>
		/// <para>Use the CryptGenRandom function instead to generate cryptographically random data.</para>
		/// <para>SYSTEM_PERFORMANCE_INFORMATION</para>
		/// <para>
		/// When the SystemInformationClass parameter is <c>SystemPerformanceInformation</c>, the buffer pointed to by the SystemInformation
		/// parameter should be large enough to hold an opaque <c>SYSTEM_PERFORMANCE_INFORMATION</c> structure for use in generating an
		/// unpredictable seed for a random number generator. For this purpose, the structure has the following layout:
		/// </para>
		/// <code>
		/// typedef struct _SYSTEM_PERFORMANCE_INFORMATION {
		/// BYTE Reserved1[312];
		/// } SYSTEM_PERFORMANCE_INFORMATION;
		/// </code>
		/// <para>Individual members of the structure are reserved for internal use by the operating system.</para>
		/// <para>Use the CryptGenRandom function instead to generate cryptographically random data.</para>
		/// <para>SYSTEM_POLICY_INFORMATION</para>
		/// <para>
		/// When the SystemInformationClass parameter is <c>SystemPolicyInformation</c>, the buffer pointed to by the SystemInformation
		/// parameter should be large enough to hold a single <c>SYSTEM_POLICY_INFORMATION</c> structure having the following layout:
		/// </para>
		/// <code>
		/// typedef struct _SYSTEM_POLICY_INFORMATION {
		/// PVOID Reserved1[2];
		/// ULONG Reserved2[3];
		/// } SYSTEM_POLICY_INFORMATION;
		/// </code>
		/// <para>Individual members of the structure are reserved for internal use by the operating system.</para>
		/// <para>Use the SLGetWindowsInformation function instead to obtain policy information.</para>
		/// <para>SYSTEM_PROCESS_INFORMATION</para>
		/// <para>
		/// When the SystemInformationClass parameter is <c>SystemProcessInformation</c>, the buffer pointed to by the SystemInformation
		/// parameter contains a <c>SYSTEM_PROCESS_INFORMATION</c> structure for each process. Each of these structures is immediately
		/// followed in memory by one or more <c>SYSTEM_THREAD_INFORMATION</c> structures that provide info for each thread in the preceding
		/// process. For more information about <c>SYSTEM_THREAD_INFORMATION</c>, see the section about this structure in this article.
		/// </para>
		/// <para>
		/// The buffer pointed to by the SystemInformation parameter should be large enough to hold an array that contains as many
		/// <c>SYSTEM_PROCESS_INFORMATION</c> and <c>SYSTEM_THREAD_INFORMATION</c> structures as there are processes and threads running in
		/// the system. This size is specified by the ReturnLength parameter.
		/// </para>
		/// <para>Each <c>SYSTEM_PROCESS_INFORMATION</c> structure has the following layout:</para>
		/// <code>
		/// typedef struct _SYSTEM_PROCESS_INFORMATION {
		/// ULONG NextEntryOffset;
		/// ULONG NumberOfThreads;
		/// BYTE Reserved1[48];
		/// UNICODE_STRING ImageName;
		/// KPRIORITY BasePriority;
		/// HANDLE UniqueProcessId;
		/// PVOID Reserved2;
		/// ULONG HandleCount;
		/// ULONG SessionId;
		/// PVOID Reserved3;
		/// SIZE_T PeakVirtualSize;
		/// SIZE_T VirtualSize;
		/// ULONG Reserved4;
		/// SIZE_T PeakWorkingSetSize;
		/// SIZE_T WorkingSetSize;
		/// PVOID Reserved5;
		/// SIZE_T QuotaPagedPoolUsage;
		/// PVOID Reserved6;
		/// SIZE_T QuotaNonPagedPoolUsage;
		/// SIZE_T PagefileUsage;
		/// SIZE_T PeakPagefileUsage;
		/// SIZE_T PrivatePageCount;
		/// LARGE_INTEGER Reserved7[6];
		/// } SYSTEM_PROCESS_INFORMATION;
		/// </code>
		/// <para>
		/// The start of the next item in the array is the address of the previous item plus the value in the <c>NextEntryOffset</c> member.
		/// For the last item in the array, <c>NextEntryOffset</c> is 0.
		/// </para>
		/// <para>The <c>NumberOfThreads</c> member contains the number of threads in the process.</para>
		/// <para>The <c>ImageName</c> member contains the process's image name.</para>
		/// <para>
		/// The <c>BasePriority</c> member contains the base priority of the process, which is the starting priority for threads created
		/// within the associated process.
		/// </para>
		/// <para>The <c>UniqueProcessId</c> member contains the process's unique process ID.</para>
		/// <para>
		/// The <c>HandleCount</c> member contains the total number of handles being used by the process in question; use
		/// GetProcessHandleCount to retrieve this information instead.
		/// </para>
		/// <para>The <c>SessionId</c> member contains the session identifier of the process session.</para>
		/// <para>The <c>PeakVirtualSize</c> member contains the peak size, in bytes, of the virtual memory used by the process.</para>
		/// <para>The <c>VirtualSize</c> member contains the current size, in bytes, of virtual memory used by the process.</para>
		/// <para>The <c>PeakWorkingSetSize</c> member contains the peak size, in kilobytes, of the working set of the process.</para>
		/// <para>The <c>QuotaPagedPoolUsage</c> member contains the current quota charged to the process for paged pool usage.</para>
		/// <para>The <c>QuotaNonPagedPoolUsage</c> member contains the current quota charged to the process for nonpaged pool usage.</para>
		/// <para>The <c>PagefileUsage</c> member contains the number of bytes of page file storage in use by the process.</para>
		/// <para>The <c>PeakPagefileUsage</c> member contains the maximum number of bytes of page-file storage used by the process.</para>
		/// <para>The <c>PrivatePageCount</c> member contains the number of memory pages allocated for the use of this process.</para>
		/// <para>
		/// You can also retrieve the <c>PeakWorkingSetSize</c>, <c>QuotaPagedPoolUsage</c>, <c>QuotaNonPagedPoolUsage</c>,
		/// <c>PagefileUsage</c>, <c>PeakPagefileUsage</c>, and <c>PrivatePageCount</c> information using either the GetProcessMemoryInfo
		/// function or the Win32_Process class.
		/// </para>
		/// <para>The other members of the structure are reserved for internal use by the operating system.</para>
		/// <para>SYSTEM_THREAD_INFORMATION</para>
		/// <para>
		/// When the SystemInformationClass parameter is <c>SystemProcessInformation</c>, the buffer pointed to by the SystemInformation
		/// parameter contains a <c>SYSTEM_PROCESS_INFORMATION</c> structure for each process. Each of these structures is immediately
		/// followed in memory by one or more <c>SYSTEM_THREAD_INFORMATION</c> structures that provide info for each thread in the preceding
		/// process. For more information about <c>SYSTEM_PROCESS_INFORMATION</c>, see the section about this structure in this article. Each
		/// <c>SYSTEM_THREAD_INFORMATION</c> structure has the following layout:
		/// </para>
		/// <code>
		/// typedef struct _SYSTEM_THREAD_INFORMATION {
		/// LARGE_INTEGER Reserved1[3];
		/// ULONG Reserved2;
		/// PVOID StartAddress;
		/// CLIENT_ID ClientId;
		/// KPRIORITY Priority;
		/// LONG BasePriority;
		/// ULONG Reserved3;
		/// ULONG ThreadState;
		/// ULONG WaitReason;
		/// } SYSTEM_THREAD_INFORMATION;
		/// </code>
		/// <para>The <c>StartAddress</c> member contains the start address of the thread.</para>
		/// <para>The <c>ClientId</c> member contains the ID of the thread and the process owning the thread.</para>
		/// <para>The <c>Priority</c> member contains the dynamic thread priority.</para>
		/// <para>The <c>BasePriority</c> member contains the base thread priority.</para>
		/// <para>The <c>ThreadState</c> member contains the current thread state.</para>
		/// <para>The <c>WaitReason</c> member contains the reason the thread is waiting.</para>
		/// <para>The other members of the structure are reserved for internal use by the operating system.</para>
		/// <para>SYSTEM_PROCESSOR_PERFORMANCE_INFORMATION</para>
		/// <para>
		/// When the SystemInformationClass parameter is <c>SystemProcessorPerformanceInformation</c>, the buffer pointed to by the
		/// SystemInformation parameter should be large enough to hold an array that contains as many
		/// <c>SYSTEM_PROCESSOR_PERFORMANCE_INFORMATION</c> structures as there are processors (CPUs) installed in the system. Each structure
		/// has the following layout:
		/// </para>
		/// <code>
		/// typedef struct
		/// _SYSTEM_PROCESSOR_PERFORMANCE_INFORMATION {
		/// LARGE_INTEGER IdleTime;
		/// LARGE_INTEGER KernelTime;
		/// LARGE_INTEGER UserTime;
		/// LARGE_INTEGER Reserved1[2];
		/// ULONG Reserved2;
		/// } SYSTEM_PROCESSOR_PERFORMANCE_INFORMATION;
		/// </code>
		/// <para>The <c>IdleTime</c> member contains the amount of time that the system has been idle, in 100-nanosecond intervals.</para>
		/// <para>
		/// The <c>KernelTime</c> member contains the amount of time that the system has spent executing in Kernel mode (including all
		/// threads in all processes, on all processors), in 100-nanosecond intervals.
		/// </para>
		/// <para>
		/// The <c>UserTime</c> member contains the amount of time that the system has spent executing in User mode (including all threads in
		/// all processes, on all processors), in 100-nanosecond intervals.
		/// </para>
		/// <para>Use GetSystemTimesinstead to retrieve this information.</para>
		/// <para>SYSTEM_QUERY_PERFORMANCE_COUNTER_INFORMATION</para>
		/// <para>
		/// When the SystemInformationClass parameter is <c>SystemQueryPerformanceCounterInformation</c>, the buffer pointed to by the
		/// SystemInformation parameter should be large enough to hold a single <c>SYSTEM_QUERY_PERFORMANCE_COUNTER_INFORMATION</c> structure
		/// having the following layout:
		/// </para>
		/// <code>
		/// typedef struct _SYSTEM_QUERY_PERFORMANCE_COUNTER_INFORMATION {
		/// ULONG                           Version;
		/// QUERY_PERFORMANCE_COUNTER_FLAGS Flags;
		/// QUERY_PERFORMANCE_COUNTER_FLAGS ValidFlags;
		/// } SYSTEM_QUERY_PERFORMANCE_COUNTER_INFORMATION;
		/// </code>
		/// <para>
		/// The <c>Flags</c> and <c>ValidFlags</c> members are <c>QUERY_PERFORMANCE_COUNTER_FLAGS</c> structures having the following layout:
		/// </para>
		/// <code>
		/// typedef struct _QUERY_PERFORMANCE_COUNTER_FLAGS {
		/// union {
		/// struct {
		/// ULONG KernelTransition:1;
		/// ULONG Reserved:31;
		/// };
		/// ULONG ul;
		/// };
		/// } QUERY_PERFORMANCE_COUNTER_FLAGS;
		/// </code>
		/// <para>
		/// The <c>ValidFlags</c> member of the <c>SYSTEM_QUERY_PERFORMANCE_COUNTER_INFORMATION</c> structure indicates which bits of the
		/// <c>Flags</c> member contain valid information. If a kernel transition is required, the <c>KernelTransition</c> bit is set in both
		/// <c>ValidFlags</c> and <c>Flags</c>. If a kernel transition is not required, the <c>KernelTransition</c> bit is set in
		/// <c>ValidFlags</c> and clear in <c>Flags</c>.
		/// </para>
		/// <para>SYSTEM_REGISTRY_QUOTA_INFORMATION</para>
		/// <para>
		/// When the SystemInformationClass parameter is <c>SystemRegistryQuotaInformation</c>, the buffer pointed to by the
		/// SystemInformation parameter should be large enough to hold a single <c>SYSTEM_REGISTRY_QUOTA_INFORMATION</c> structure having the
		/// following layout:
		/// </para>
		/// <code>
		/// typedef struct _SYSTEM_REGISTRY_QUOTA_INFORMATION {
		/// ULONG RegistryQuotaAllowed;
		/// ULONG RegistryQuotaUsed;
		/// PVOID Reserved1;
		/// } SYSTEM_REGISTRY_QUOTA_INFORMATION;
		/// </code>
		/// <para>The <c>RegistryQuotaAllowed</c> member contains the maximum size, in bytes, that the Registry can attain on this system.</para>
		/// <para>The <c>RegistryQuotaUsed</c> member contains the current size of the Registry, in bytes.</para>
		/// <para>Use GetSystemRegistryQuota instead to retrieve this information.</para>
		/// <para>The other member of the structure is reserved for internal use by the operating system.</para>
		/// <para>SYSTEM_SPECULATION_CONTROL_INFORMATION</para>
		/// <para>
		/// When the SystemInformationClass parameter is <c>SystemSpeculationControlInformation</c>, the buffer pointed to by the
		/// SystemInformation parameter should be large enough to hold a single <c>SYSTEM_SPECULATION_CONTROL_INFORMATION</c> structure
		/// having the following layout:
		/// </para>
		/// <code>
		/// typedef struct _SYSTEM_SPECULATION_CONTROL_INFORMATION {
		/// struct {
		/// ULONG BpbEnabled:1;
		/// ULONG BpbDisabledSystemPolicy:1;
		/// ULONG BpbDisabledNoHardwareSupport:1;
		/// ULONG SpecCtrlEnumerated:1;
		/// ULONG SpecCmdEnumerated:1;
		/// ULONG IbrsPresent:1;
		/// ULONG StibpPresent:1;
		/// ULONG SmepPresent:1;
		/// ULONG Reserved:24;
		/// } SpeculationControlFlags;
		/// } SYSTEM_SPECULATION_CONTROL_INFORMATION, * PSYSTEM_SPECULATION_CONTROL_INFORMATION;
		/// </code>
		/// <para>The <c>BpbEnabled</c> indicates whether speculation control features are supported and enabled.</para>
		/// <para>The <c>BpbDisabledSystemPolicy</c> indicates whether speculation control features are disabled due to system policy.</para>
		/// <para>
		/// The <c>BpbDisabledNoHardwareSupport</c> whether speculation control features are disabled due to the absence of hardware support.
		/// </para>
		/// <para>The <c>SpecCtrlEnumerated</c> whether the IA32_SPEC_CTRL MSR is enumerated by hardware.</para>
		/// <para>The <c>SpecCmdEnumerated</c> indicates whether the IA32_SPEC_CMD MSR is enumerated by hardware.</para>
		/// <para>The <c>IbrsPresent</c> indicates whether the IBRS MSR is treated as being present.</para>
		/// <para>The <c>StibpPresent</c> indicates whether the STIBP MSR is present.</para>
		/// <para>The <c>SmepPresent</c> indicates whether the SMEP feature is present and enabled.</para>
		/// <para>The <c>Reserved</c> member of the structure is reserved for internal use by the operating system.</para>
		/// <para>SYSTEM_TIMEOFDAY_INFORMATION</para>
		/// <para>
		/// When the SystemInformationClass parameter is <c>SystemTimeOfDayInformation</c>, the buffer pointed to by the SystemInformation
		/// parameter should be large enough to hold an opaque <c>SYSTEM_TIMEOFDAY_INFORMATION</c> structure for use in generating an
		/// unpredictable seed for a random number generator. For this purpose, the structure has the following layout:
		/// </para>
		/// <code>
		/// typedef struct _SYSTEM_TIMEOFDAY_INFORMATION {
		/// BYTE Reserved1[48];
		/// } SYSTEM_TIMEOFDAY_INFORMATION;
		/// </code>
		/// <para>Individual members of the structure are reserved for internal use by the operating system.</para>
		/// <para>Use the CryptGenRandom function instead to generate cryptographically random data.</para>
		/// </returns>
		/// <exception cref="InvalidCastException">
		/// The requested SystemInformationClass does not match the return type requested. or Reported size of object does not match query.
		/// </exception>
		public static T NtQuerySystemInformation<T>(SYSTEM_INFORMATION_CLASS SystemInformationClass)
		{
			var tType = typeof(T);
			if (CorrespondingTypeAttribute.GetCorrespondingTypes(SystemInformationClass).Any() && !CorrespondingTypeAttribute.CanGet(SystemInformationClass, tType))
				throw new InvalidCastException("The requested SystemInformationClass does not match the return type requested.");
			var status = NtQuerySystemInformation(SystemInformationClass, SafeHGlobalHandle.Null, 0, out var len);
			if (status != NTStatus.STATUS_INFO_LENGTH_MISMATCH && status != NTStatus.STATUS_BUFFER_OVERFLOW && status != NTStatus.STATUS_BUFFER_TOO_SMALL)
				throw status.GetException();
			var mem = new SafeHGlobalHandle(SystemInformationClass == SYSTEM_INFORMATION_CLASS.SystemProcessInformation ? (int)len * 2 : (int)len);
			NtQuerySystemInformation(SystemInformationClass, mem, (uint)mem.Size, out len).ThrowIfFailed();
			if (tType.IsArray)
			{
				var aType = tType.GetElementType();
				if (aType == typeof(SYSTEM_PROCESS_INFORMATION) && SystemInformationClass == SYSTEM_INFORMATION_CLASS.SystemProcessInformation)
				{
					var retList = new List<SYSTEM_PROCESS_INFORMATION>();
					var pi = new SYSTEM_PROCESS_INFORMATION();
					var ptr = mem.DangerousGetHandle();
					do
					{
						pi = ptr.ToStructure<SYSTEM_PROCESS_INFORMATION>();
						retList.Add(pi);
						ptr = ptr.Offset(pi.NextEntryOffset);
					} while (pi.NextEntryOffset > 0);
					return (T)(object)retList.ToArray();
				}
				var cnt = Math.DivRem(len, Marshal.SizeOf(aType), out var res);
				if (res != 0) throw new InvalidCastException("Reported size of object does not match query.");
				return (T)mem.InvokeGenericMethod("ToArray", new[] { aType }, new[] { typeof(int), typeof(int) }, new object[] { (int)cnt, 0 });
			}
			return mem.ToStructure<T>();
		}

		/// <summary>
		/// <para>
		/// [ <c>NtQuerySystemInformation</c> may be altered or unavailable in future versions of Windows. Applications should use the
		/// alternate functions listed in this topic.]
		/// </para>
		/// <para>Retrieves the specified system information.</para>
		/// </summary>
		/// <returns>The list of results from calling NtQuerySystemInformation with SystemProcessInformation.</returns>
		public static IList<Tuple<SYSTEM_PROCESS_INFORMATION, SYSTEM_THREAD_INFORMATION[]>> NtQuerySystemInformation_Process()
		{
			var status = NtQuerySystemInformation(SYSTEM_INFORMATION_CLASS.SystemProcessInformation, SafeHGlobalHandle.Null, 0, out var len);
			if (status != NTStatus.STATUS_INFO_LENGTH_MISMATCH && status != NTStatus.STATUS_BUFFER_OVERFLOW && status != NTStatus.STATUS_BUFFER_TOO_SMALL)
				throw status.GetException();
			var mem = new SafeHGlobalHandle((int)len * 2);
			NtQuerySystemInformation(SYSTEM_INFORMATION_CLASS.SystemProcessInformation, mem, (uint)mem.Size, out len).ThrowIfFailed();
			var retList = new List<Tuple<SYSTEM_PROCESS_INFORMATION, SYSTEM_THREAD_INFORMATION[]>>();
			var pi = new SYSTEM_PROCESS_INFORMATION();
			var ptr = mem.DangerousGetHandle();
			var pSz = Marshal.SizeOf(pi);
			do
			{
				pi = ptr.ToStructure<SYSTEM_PROCESS_INFORMATION>();
				retList.Add(new Tuple<SYSTEM_PROCESS_INFORMATION, SYSTEM_THREAD_INFORMATION[]>(pi, ptr.Offset(pSz).ToArray<SYSTEM_THREAD_INFORMATION>((int)pi.NumberOfThreads)));
				ptr = ptr.Offset(pi.NextEntryOffset);
			} while (pi.NextEntryOffset > 0);
			return retList;
		}

		/// <summary>The CLIENT_ID structure contains identifiers of a process and a thread.</summary>
		[StructLayout(LayoutKind.Sequential, Pack = 4)]
		public struct CLIENT_ID
		{
			/// <summary>The unique process identifier.</summary>
			public IntPtr UniqueProcess;

			/// <summary>The unique thread identifier.</summary>
			public IntPtr UniqueThread;
		}

		/// <summary>
		/// <para>
		/// A driver sets an IRP's I/O status block to indicate the final status of an I/O request, before calling IoCompleteRequest for the IRP.
		/// </para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// Unless a driver's dispatch routine completes an IRP with an error status value, the lowest-level driver in the chain frequently
		/// sets the IRP's I/O status block to the values that will be returned to the original requester of the I/O operation.
		/// </para>
		/// <para>
		/// The IoCompletion routines of higher-level drivers usually check the I/O status block in IRPs completed by lower drivers. By
		/// design, the I/O status block in an IRP is the only information passed back from the underlying device driver to all higher-level
		/// drivers' IoCompletion routines.
		/// </para>
		/// <para>
		/// The operating system implements support routines that write <c>IO_STATUS_BLOCK</c> values to caller-supplied output buffers. For
		/// example, see ZwOpenFile or NtOpenFile. These routines return status codes that might not match the status codes in the
		/// <c>IO_STATUS_BLOCK</c> structures. If one of these routines returns STATUS_PENDING, the caller should wait for the I/O operation
		/// to complete, and then check the status code in the <c>IO_STATUS_BLOCK</c> structure to determine the final status of the
		/// operation. If the routine returns a status code other than STATUS_PENDING, the caller should rely on this status code instead of
		/// the status code in the <c>IO_STATUS_BLOCK</c> structure.
		/// </para>
		/// <para>For more information, see I/O Status Blocks.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows-hardware/drivers/ddi/content/wdm/ns-wdm-_io_status_block typedef struct _IO_STATUS_BLOCK
		// { union { NTSTATUS Status; PVOID Pointer; } DUMMYUNIONNAME; ULONG_PTR Information; } IO_STATUS_BLOCK, *PIO_STATUS_BLOCK;
		[PInvokeData("wdm.h", MSDNShortId = "1ce2b1d0-a8b2-4a05-8895-e13802690a7b")]
		[StructLayout(LayoutKind.Sequential)]
		public struct IO_STATUS_BLOCK
		{
			/// <summary>
			/// This is the completion status, either STATUS_SUCCESS if the requested operation was completed successfully or an
			/// informational, warning, or error STATUS_XXX value. For more information, see Using NTSTATUS values.
			/// </summary>
			public uint Status;

			/// <summary>
			/// This is set to a request-dependent value. For example, on successful completion of a transfer request, this is set to the
			/// number of bytes transferred. If a transfer request is completed with another STATUS_XXX, this member is set to zero.
			/// </summary>
			public IntPtr Information;
		}

		/// <summary>
		/// <para>The <c>KEY_BASIC_INFORMATION</c> structure defines a subset of the full information that is available for a registry key.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// The ZwEnumerateKey and ZwQueryKey routines use the <c>KEY_BASIC_INFORMATION</c> structure to contain the basic information for a
		/// registry key. When the KeyInformationClass parameter of either routine is <c>KeyBasicInformation</c>, the KeyInformation buffer
		/// is treated as a <c>KEY_BASIC_INFORMATION</c> structure. For more information about the <c>KeyBasicInformation</c> enumeration
		/// value, see KEY_INFORMATION_CLASS.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows-hardware/drivers/ddi/content/wdm/ns-wdm-_key_basic_information typedef struct
		// _KEY_BASIC_INFORMATION { LARGE_INTEGER LastWriteTime; ULONG TitleIndex; ULONG NameLength; WCHAR Name[1]; } KEY_BASIC_INFORMATION, *PKEY_BASIC_INFORMATION;
		[PInvokeData("wdm.h", MSDNShortId = "789c60b6-a5a4-4570-bb0c-acfe1166a302")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		public struct KEY_BASIC_INFORMATION
		{
			/// <summary>
			/// <para>
			/// The last time this key or any of its values changed. This time value is expressed in absolute system time format. Absolute
			/// system time is the number of 100-nanosecond intervals since the start of the year 1601 in the Gregorian calendar.
			/// </para>
			/// </summary>
			public long LastWriteTime;

			/// <summary>
			/// <para>Device and intermediate drivers should ignore this member.</para>
			/// </summary>
			public uint TitleIndex;

			/// <summary>
			/// <para>The size, in bytes, of the key name string in the <c>Name</c> array.</para>
			/// </summary>
			public uint NameLength;

			/// <summary>
			/// <para>
			/// An array of wide characters that contains the name of the registry key. This character string is null-terminated. Only the
			/// first element in this array is included in the <c>KEY_BASIC_INFORMATION</c> structure definition. The storage for the
			/// remaining elements in the array immediately follows this element.
			/// </para>
			/// </summary>
			public StrPtrUni Name;
		}

		/// <summary>
		/// <para>
		/// The <c>KEY_FULL_INFORMATION</c> structure defines the information available for a registry key, including information about its
		/// subkeys and the maximum length for their names and value entries. This information can be used to size buffers to get the names
		/// of subkeys and their value entries.
		/// </para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// The ZwEnumerateKey and ZwQueryKey routines use the <c>KEY_FULL_INFORMATION</c> structure to contain the full information for a
		/// registry key. When the KeyInformationClass parameter of either routine is <c>KeyFullInformation</c>, the KeyInformation buffer is
		/// treated as a <c>KEY_FULL_INFORMATION</c> structure. For more information about the <c>KeyFullInformation</c> enumeration value,
		/// see KEY_INFORMATION_CLASS.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows-hardware/drivers/ddi/content/wdm/ns-wdm-_key_full_information typedef struct
		// _KEY_FULL_INFORMATION { LARGE_INTEGER LastWriteTime; ULONG TitleIndex; ULONG ClassOffset; ULONG ClassLength; ULONG SubKeys; ULONG
		// MaxNameLen; ULONG MaxClassLen; ULONG Values; ULONG MaxValueNameLen; ULONG MaxValueDataLen; WCHAR Class[1]; } KEY_FULL_INFORMATION, *PKEY_FULL_INFORMATION;
		[PInvokeData("wdm.h", MSDNShortId = "dd099435-e3e3-4d78-a829-0f12f2db46d9")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		public struct KEY_FULL_INFORMATION
		{
			/// <summary>
			/// <para>
			/// The last time this key or any of its values changed. This time value is expressed in absolute system time format. Absolute
			/// system time is the number of 100-nanosecond intervals since the start of the year 1601 in the Gregorian calendar.
			/// </para>
			/// </summary>
			public long LastWriteTime;

			/// <summary>
			/// <para>Device and intermediate drivers should ignore this member.</para>
			/// </summary>
			public uint TitleIndex;

			/// <summary>
			/// <para>The byte offset from the start of this structure to the <c>Class</c> member.</para>
			/// </summary>
			public uint ClassOffset;

			/// <summary>
			/// <para>The size, in bytes, of the key class name string in the <c>Class</c> array.</para>
			/// </summary>
			public uint ClassLength;

			/// <summary>
			/// <para>The number of subkeys for this key.</para>
			/// </summary>
			public uint SubKeys;

			/// <summary>
			/// <para>The maximum size, in bytes, of any name for a subkey.</para>
			/// </summary>
			public uint MaxNameLen;

			/// <summary>
			/// <para>The maximum size, in bytes, of a class name.</para>
			/// </summary>
			public uint MaxClassLen;

			/// <summary>
			/// <para>The number of value entries for this key.</para>
			/// </summary>
			public uint Values;

			/// <summary>
			/// <para>The maximum size, in bytes, of a value entry name.</para>
			/// </summary>
			public uint MaxValueNameLen;

			/// <summary>
			/// <para>The maximum size, in bytes, of a value entry data field.</para>
			/// </summary>
			public uint MaxValueDataLen;

			/// <summary>
			/// <para>
			/// An array of wide characters that contains the name of the class of the key. This character string is null-terminated. Only
			/// the first element in this array is included in the <c>KEY_FULL_INFORMATION</c> structure definition. The storage for the
			/// remaining elements in the array immediately follows this element.
			/// </para>
			/// </summary>
			public StrPtrUni Class;
		}

		/// <summary>
		/// <para>The <c>KEY_NAME_INFORMATION</c> structure holds the name and name length of the key.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// The ZwQueryKey routine uses the <c>KEY_NAME_INFORMATION</c> structure to contain the registry key name. When the
		/// KeyInformationClass parameter of this routine is <c>KeyNameInformation</c>, the KeyInformation buffer is treated as a
		/// <c>KEY_NAME_INFORMATION</c> structure. For more information about the <c>KeyNameInformation</c> enumeration value, see KEY_INFORMATION_CLASS.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows-hardware/drivers/ddi/content/ntddk/ns-ntddk-_key_name_information typedef struct
		// _KEY_NAME_INFORMATION { ULONG NameLength; WCHAR Name[1]; } KEY_NAME_INFORMATION, *PKEY_NAME_INFORMATION;
		[PInvokeData("ntddk.h", MSDNShortId = "5b46e7d9-fbb0-4e55-b1f5-d9d0f1dd1f2c")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		public struct KEY_NAME_INFORMATION
		{
			/// <summary>
			/// <para>The size, in bytes, of the key name string in the <c>Name</c> array.</para>
			/// </summary>
			public uint NameLength;

			/// <summary>
			/// <para>
			/// An array of wide characters that contains the name of the registry key. This character string is null-terminated. Only the
			/// first element in this array is included in the <c>KEY_NAME_INFORMATION</c> structure definition. The storage for the
			/// remaining elements in the array immediately follows this element.
			/// </para>
			/// </summary>
			public StrPtrUni Name;
		}

		/// <summary>
		/// <para>The <c>KEY_NODE_INFORMATION</c> structure defines the basic information available for a registry (sub)key.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// The ZwEnumerateKey and ZwQueryKey routines use the <c>KEY_NODE_INFORMATION</c> structure to contain the registry key name and key
		/// class name. When the KeyInformationClass parameter of either routine is <c>KeyNodeInformation</c>, the KeyInformation buffer is
		/// treated as a <c>KEY_NODE_INFORMATION</c> structure. For more information about the <c>KeyNodeInformation</c> enumeration value,
		/// see KEY_INFORMATION_CLASS.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows-hardware/drivers/ddi/content/wdm/ns-wdm-_key_node_information typedef struct
		// _KEY_NODE_INFORMATION { LARGE_INTEGER LastWriteTime; ULONG TitleIndex; ULONG ClassOffset; ULONG ClassLength; ULONG NameLength;
		// WCHAR Name[1]; } KEY_NODE_INFORMATION, *PKEY_NODE_INFORMATION;
		[PInvokeData("wdm.h", MSDNShortId = "2eed1a3d-fc40-4416-ad61-d82bf4fb69a1")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		public struct KEY_NODE_INFORMATION
		{
			/// <summary>
			/// <para>
			/// The last time this key or any of its values changed. This time value is expressed in absolute system time format. Absolute
			/// system time is the number of 100-nanosecond intervals since the start of the year 1601 in the Gregorian calendar.
			/// </para>
			/// </summary>
			public long LastWriteTime;

			/// <summary>
			/// <para>Device and intermediate drivers should ignore this member.</para>
			/// </summary>
			public uint TitleIndex;

			/// <summary>
			/// <para>
			/// The byte offset from the start of this structure to the class name string, which is located in the <c>Name</c> array
			/// immediately following the key name string. Like the key name string, the class name string is not null-terminated.
			/// </para>
			/// </summary>
			public uint ClassOffset;

			/// <summary>
			/// <para>The size, in bytes, in the class name string.</para>
			/// </summary>
			public uint ClassLength;

			/// <summary>
			/// <para>The size, in bytes, of the key name string contained in the <c>Name</c> array.</para>
			/// </summary>
			public uint NameLength;

			/// <summary>
			/// <para>
			/// An array of wide characters that contains the name of the registry key. This character string is null-terminated. Only the
			/// first element in this array is included in the <c>KEY_NODE_INFORMATION</c> structure definition. The storage for the
			/// remaining elements in the array immediately follows this element.
			/// </para>
			/// </summary>
			public StrPtrUni Name;
		}

		/// <summary>Used by <see cref="LdrDllNotification"/>.</summary>
		[PInvokeData("ntldr.h", MSDNShortId = "12202797-c80c-4fa3-9cc4-dcb1a9f01551")]
		[StructLayout(LayoutKind.Sequential)]
		public struct LDR_DLL_NOTIFICATION_DATA
		{
			/// <summary>Reserved.</summary>
			public uint Flags;

			/// <summary>The full path name of the DLL module.</summary>
			public IntPtr FullDllName;

			/// <summary>The base file name of the DLL module.</summary>
			public IntPtr BaseDllName;

			/// <summary>A pointer to the base address for the DLL in memory.</summary>
			public IntPtr DllBase;

			/// <summary>The size of the DLL image, in bytes.</summary>
			public uint SizeOfImage;
		}

		/// <summary>
		/// <para>
		/// The <c>OBJECT_ATTRIBUTES</c> structure specifies attributes that can be applied to objects or object handles by routines that
		/// create objects and/or return handles to objects.
		/// </para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// Use the InitializeObjectAttributes macro to initialize the members of the <c>OBJECT_ATTRIBUTES</c> structure. Note that
		/// <c>InitializeObjectAttributes</c> initializes the <c>SecurityQualityOfService</c> member to <c>NULL</c>. If you must specify a
		/// non- <c>NULL</c> value, set the <c>SecurityQualityOfService</c> member after initialization.
		/// </para>
		/// <para>
		/// To apply the attributes contained in this structure to an object or object handle, pass a pointer to this structure to a routine
		/// that accesses objects or returns object handles, such as ZwCreateFile or ZwCreateDirectoryObject.
		/// </para>
		/// <para>
		/// All members of this structure are read-only. If a member of this structure is a pointer, the object that this member points to is
		/// read-only as well. Read-only members and objects can be used to acquire relevant information but must not be modified. To set the
		/// members of this structure, use the <c>InitializeObjectAttributes</c> macro.
		/// </para>
		/// <para>
		/// Driver routines that run in a process context other than that of the system process must set the OBJ_KERNEL_HANDLE flag for the
		/// <c>Attributes</c> member (by using the <c>InitializeObjectAttributes</c> macro). This restricts the use of a handle opened for
		/// that object to processes running only in kernel mode. Otherwise, the handle can be accessed by the process in whose context the
		/// driver is running.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows-hardware/drivers/ddi/content/wudfwdm/ns-wudfwdm-_object_attributes typedef struct
		// _OBJECT_ATTRIBUTES { ULONG Length; HANDLE RootDirectory; PUNICODE_STRING ObjectName; ULONG Attributes; PVOID SecurityDescriptor;
		// PVOID SecurityQualityOfService; } OBJECT_ATTRIBUTES;
		[PInvokeData("wudfwdm.h", MSDNShortId = "08f5a141-abce-4890-867c-5fe8c4239905")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		public struct OBJECT_ATTRIBUTES
		{
			/// <summary>
			/// <para>
			/// The number of bytes of data contained in this structure. The InitializeObjectAttributes macro sets this member to
			/// <c>sizeof</c>( <c>OBJECT_ATTRIBUTES</c>).
			/// </para>
			/// </summary>
			public uint length;

			/// <summary>
			/// <para>
			/// Optional handle to the root object directory for the path name specified by the <c>ObjectName</c> member. If
			/// <c>RootDirectory</c> is <c>NULL</c>, <c>ObjectName</c> must point to a fully qualified object name that includes the full
			/// path to the target object. If <c>RootDirectory</c> is non- <c>NULL</c>, <c>ObjectName</c> specifies an object name relative
			/// to the <c>RootDirectory</c> directory. The <c>RootDirectory</c> handle can refer to a file system directory or an object
			/// directory in the object manager namespace.
			/// </para>
			/// </summary>
			public IntPtr rootDirectory;

			/// <summary>
			/// <para>
			/// Pointer to a Unicode string that contains the name of the object for which a handle is to be opened. This must either be a
			/// fully qualified object name, or a relative path name to the directory specified by the <c>RootDirectory</c> member.
			/// </para>
			/// </summary>
			public IntPtr objectName;

			/// <summary>
			/// <para>
			/// Bitmask of flags that specify object handle attributes. This member can contain one or more of the flags in the following table.
			/// </para>
			/// <list type="table">
			/// <listheader>
			/// <term>Flag</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>OBJ_INHERIT</term>
			/// <term>This handle can be inherited by child processes of the current process.</term>
			/// </item>
			/// <item>
			/// <term>OBJ_PERMANENT</term>
			/// <term>
			/// This flag only applies to objects that are named within the object manager. By default, such objects are deleted when all
			/// open handles to them are closed. If this flag is specified, the object is not deleted when all open handles are closed.
			/// Drivers can use the ZwMakeTemporaryObject routine to make a permanent object non-permanent.
			/// </term>
			/// </item>
			/// <item>
			/// <term>OBJ_EXCLUSIVE</term>
			/// <term>
			/// If this flag is set and the OBJECT_ATTRIBUTES structure is passed to a routine that creates an object, the object can be
			/// accessed exclusively. That is, once a process opens such a handle to the object, no other processes can open handles to this
			/// object. If this flag is set and the OBJECT_ATTRIBUTES structure is passed to a routine that creates an object handle, the
			/// caller is requesting exclusive access to the object for the process context that the handle was created in. This request can
			/// be granted only if the OBJ_EXCLUSIVE flag was set when the object was created.
			/// </term>
			/// </item>
			/// <item>
			/// <term>OBJ_CASE_INSENSITIVE</term>
			/// <term>
			/// If this flag is specified, a case-insensitive comparison is used when matching the name pointed to by the ObjectName member
			/// against the names of existing objects. Otherwise, object names are compared using the default system settings.
			/// </term>
			/// </item>
			/// <item>
			/// <term>OBJ_OPENIF</term>
			/// <term>
			/// If this flag is specified, by using the object handle, to a routine that creates objects and if that object already exists,
			/// the routine should open that object. Otherwise, the routine creating the object returns an NTSTATUS code of STATUS_OBJECT_NAME_COLLISION.
			/// </term>
			/// </item>
			/// <item>
			/// <term>OBJ_OPENLINK</term>
			/// <term>
			/// If an object handle, with this flag set, is passed to a routine that opens objects and if the object is a symbolic link
			/// object, the routine should open the symbolic link object itself, rather than the object that the symbolic link refers to
			/// (which is the default behavior).
			/// </term>
			/// </item>
			/// <item>
			/// <term>OBJ_KERNEL_HANDLE</term>
			/// <term>The handle is created in system process context and can only be accessed from kernel mode.</term>
			/// </item>
			/// <item>
			/// <term>OBJ_FORCE_ACCESS_CHECK</term>
			/// <term>
			/// The routine that opens the handle should enforce all access checks for the object, even if the handle is being opened in
			/// kernel mode.
			/// </term>
			/// </item>
			/// <item>
			/// <term>OBJ_VALID_ATTRIBUTES</term>
			/// <term>Reserved.</term>
			/// </item>
			/// </list>
			/// </summary>
			public uint attributes;

			/// <summary>
			/// <para>
			/// Specifies a security descriptor (SECURITY_DESCRIPTOR) for the object when the object is created. If this member is
			/// <c>NULL</c>, the object will receive default security settings.
			/// </para>
			/// </summary>
			public IntPtr securityDescriptor;

			/// <summary>
			/// <para>
			/// Optional quality of service to be applied to the object when it is created. Used to indicate the security impersonation level
			/// and context tracking mode (dynamic or static). Currently, the InitializeObjectAttributes macro sets this member to <c>NULL</c>.
			/// </para>
			/// </summary>
			public IntPtr securityQualityOfService;
		}

		/// <summary>Returns the number of processors in the system.</summary>
		[PInvokeData("winternl.h", MSDNShortId = "553ec7b9-c5eb-4955-8dc0-f1c06f59fe31")]
		[StructLayout(LayoutKind.Sequential, Pack = 4)]
		public struct SYSTEM_BASIC_INFORMATION
		{
			/// <summary>Reserved.</summary>
			public ulong Reserved1_1;

			/// <summary>Reserved.</summary>
			public ulong Reserved1_2;

			/// <summary>Reserved.</summary>
			public ulong Reserved1_3;

			/// <summary>Reserved.</summary>
			public IntPtr Reserved2_1;

			/// <summary>Reserved.</summary>
			public IntPtr Reserved2_2;

			/// <summary>Reserved.</summary>
			public IntPtr Reserved2_3;

			/// <summary>Reserved.</summary>
			public IntPtr Reserved2_4;

			/// <summary>The number of processors present in the system.</summary>
			public byte NumberOfProcessors;
		}

		/// <summary>Process information.</summary>
		[PInvokeData("winternl.h", MSDNShortId = "553ec7b9-c5eb-4955-8dc0-f1c06f59fe31")]
		[StructLayout(LayoutKind.Sequential, Pack = 4)]
		public struct SYSTEM_PROCESS_INFORMATION
		{
			/// <summary>
			/// The start of the next item in the array is the address of the previous item plus the value in the NextEntryOffset member. For
			/// the last item in the array, NextEntryOffset is 0.
			/// </summary>
			public uint NextEntryOffset;

			/// <summary>The number of threads in the process.</summary>
			public uint NumberOfThreads;

			/// <summary>Reserved.</summary>
			public ulong Reserved1_1;

			/// <summary>Reserved.</summary>
			public ulong Reserved1_2;

			/// <summary>Reserved.</summary>
			public ulong Reserved1_3;

			/// <summary>Reserved.</summary>
			public ulong Reserved1_4;

			/// <summary>Reserved.</summary>
			public ulong Reserved1_5;

			/// <summary>Reserved.</summary>
			public ulong Reserved1_6;

			/// <summary>The process's image name.</summary>
			public UNICODE_STRING ImageName;

			/// <summary>The base priority of the process, which is the starting priority for threads created within the associated process.</summary>
			public int BasePriority;

			/// <summary>The process's unique process identifier.</summary>
			public IntPtr UniqueProcessId;

			/// <summary>Reserved.</summary>
			public IntPtr Reserved2;

			/// <summary>
			/// The total number of handles being used by the process in question; use GetProcessHandleCount to retrieve this information instead.
			/// </summary>
			public uint HandleCount;

			/// <summary>The session identifier of the process session.</summary>
			public uint SessionId;

			/// <summary>Reserved.</summary>
			public IntPtr Reserved3;

			/// <summary>The peak size, in bytes, of the virtual memory used by the process.</summary>
			public SizeT PeakVirtualSize;

			/// <summary>The current size, in bytes, of virtual memory used by the process.</summary>
			public SizeT VirtualSize;

			/// <summary>Reserved.</summary>
			public uint Reserved4;

			/// <summary>The peak size, in kilobytes, of the working set of the process.</summary>
			public SizeT PeakWorkingSetSize;

			/// <summary>The current quota charged to the process for paged pool usage.</summary>
			public SizeT WorkingSetSize;

			/// <summary>Reserved.</summary>
			public IntPtr Reserved5;

			/// <summary>The current quota charged to the process for paged pool usage.</summary>
			public SizeT QuotaPagedPoolUsage;

			/// <summary>Reserved.</summary>
			public IntPtr Reserved6;

			/// <summary>The current quota charged to the process for nonpaged pool usage.</summary>
			public SizeT QuotaNonPagedPoolUsage;

			/// <summary>The number of bytes of page file storage in use by the process.</summary>
			public SizeT PagefileUsage;

			/// <summary>The maximum number of bytes of page-file storage used by the process.</summary>
			public SizeT PeakPagefileUsage;

			/// <summary>The number of memory pages allocated for the use of this process.</summary>
			public SizeT PrivatePageCount;

			/// <summary>Reserved.</summary>
			public long Reserved7_1;

			/// <summary>Reserved.</summary>
			public long Reserved7_2;

			/// <summary>Reserved.</summary>
			public long Reserved7_3;

			/// <summary>Reserved.</summary>
			public long Reserved7_4;

			/// <summary>Reserved.</summary>
			public long Reserved7_5;

			/// <summary>Reserved.</summary>
			public long Reserved7_6;
		}

		/// <summary>Processor performance.</summary>
		[PInvokeData("winternl.h", MSDNShortId = "553ec7b9-c5eb-4955-8dc0-f1c06f59fe31")]
		[StructLayout(LayoutKind.Sequential, Pack = 8)]
		public struct SYSTEM_PROCESSOR_PERFORMANCE_INFORMATION
		{
			/// <summary>The amount of time that the system has been idle, in 100-nanosecond intervals.</summary>
			public long IdleTime;

			/// <summary>
			/// The amount of time that the system has spent executing in Kernel mode (including all threads in all processes, on all
			/// processors), in 100-nanosecond intervals..
			/// </summary>
			public long KernelTime;

			/// <summary>
			/// The amount of time that the system has spent executing in User mode (including all threads in all processes, on all
			/// processors), in 100-nanosecond intervals.
			/// </summary>
			public long UserTime;

			/// <summary>Undocumented.</summary>
			public long DpcTime;

			/// <summary>Undocumented.</summary>
			public long InterruptTime;

			/// <summary>Reserved.</summary>
			public uint Reserved2;
		}

		/// <summary>Registry quota information.</summary>
		[PInvokeData("winternl.h", MSDNShortId = "553ec7b9-c5eb-4955-8dc0-f1c06f59fe31")]
		[StructLayout(LayoutKind.Sequential, Pack = 4)]
		public struct SYSTEM_REGISTRY_QUOTA_INFORMATION
		{
			/// <summary>The maximum size, in bytes, that the Registry can attain on this system.</summary>
			public uint RegistryQuotaAllowed;

			/// <summary>The current size of the Registry, in bytes.</summary>
			public uint RegistryQuotaUsed;

			/// <summary>Reserved.</summary>
			public IntPtr Reserved1;
		}

		/// <summary>Thread information.</summary>
		[PInvokeData("winternl.h", MSDNShortId = "553ec7b9-c5eb-4955-8dc0-f1c06f59fe31")]
		[StructLayout(LayoutKind.Sequential, Pack = 4)]
		public struct SYSTEM_THREAD_INFORMATION
		{
			/// <summary>Reserved.</summary>
			public ulong Reserved1_1;

			/// <summary>Reserved.</summary>
			public ulong Reserved1_2;

			/// <summary>Reserved.</summary>
			public ulong Reserved1_3;

			/// <summary>Reserved.</summary>
			public uint Reserved2;

			/// <summary>The start address of the thread.</summary>
			public IntPtr StartAddress;

			/// <summary>The ID of the thread and the process owning the thread.</summary>
			public CLIENT_ID ClientId;

			/// <summary>The dynamic thread priority.</summary>
			public int Priority;

			/// <summary>The base thread priority.</summary>
			public int BasePriority;

			/// <summary>Reserved.</summary>
			public uint Reserved3;

			/// <summary>The current thread state.</summary>
			public uint ThreadState;

			/// <summary>The reason the thread is waiting.</summary>
			public uint WaitReason;
		}

		/// <summary>
		/// <para>The <c>UNICODE_STRING</c> structure is used to define Unicode strings.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// The <c>UNICODE_STRING</c> structure is used to pass Unicode strings. Use RtlUnicodeStringInit or RtlUnicodeStringInitEx to
		/// initialize a <c>UNICODE_STRING</c> structure.
		/// </para>
		/// <para>If the string is null-terminated, <c>Length</c> does not include the trailing null character.</para>
		/// <para>
		/// The <c>MaximumLength</c> is used to indicate the length of <c>Buffer</c> so that if the string is passed to a conversion routine
		/// such as RtlAnsiStringToUnicodeString the returned string does not exceed the buffer size.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows-hardware/drivers/ddi/content/wudfwdm/ns-wudfwdm-_unicode_string typedef struct
		// _UNICODE_STRING { USHORT Length; USHORT MaximumLength; PWCH Buffer; } UNICODE_STRING;
		[PInvokeData("wudfwdm.h", MSDNShortId = "b02f29a9-1049-4e29-aac3-72bf0c70a21e")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode, Pack = 2, Size = 8)]
		public struct UNICODE_STRING
		{
			/// <summary>
			/// <para>The length, in bytes, of the string stored in <c>Buffer</c>.</para>
			/// </summary>
			public ushort Length;

			/// <summary>
			/// <para>The length, in bytes, of <c>Buffer</c>.</para>
			/// </summary>
			public ushort MaximumLength;

			/// <summary>Pointer to a wide-character string.</summary>
			[MarshalAs(UnmanagedType.LPWStr)]
			public string Buffer;
		}

		/// <summary>Provides a <see cref="SafeHandle"/> to an object that releases a created handle at disposal using NtClose.</summary>
		public abstract class SafeNtHandle : SafeHANDLE
		{
			/// <summary>Initializes a new instance of the <see cref="SafeNtHandle"/> class and assigns an existing handle.</summary>
			/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
			/// <param name="ownsHandle"><see langword="true"/> to reliably release the handle during the finalization phase; otherwise, <see langword="false"/> (not recommended).</param>
			public SafeNtHandle(IntPtr preexistingHandle, bool ownsHandle = true) : base(preexistingHandle, ownsHandle) { }

			/// <summary>Initializes a new instance of the <see cref="SafeNtHandle"/> class.</summary>
			protected SafeNtHandle() : base() { }

#pragma warning disable CS0612 // Type or member is obsolete
			/// <inheritdoc/>
			protected override bool InternalReleaseHandle() => NtClose(handle).Succeeded;
#pragma warning restore CS0612 // Type or member is obsolete
		}

		/*		NtCreateTransaction
		NtCreateTransactionManager
		NtDeviceIoControlFile
		NtDuplicateToken
		NtEnumerateTransactionObject
		NtFlushBuffersFileEx
		NtFreeVirtualMemory
		NtFsControlFile
		NtGetCurrentProcessorNumber
		NtGetNotificationResourceManager
		NtLockFile
		NtNotifyChangeMultipleKeys
		NtOpenDirectoryObject
		NtOpenEnlistment
		NtOpenFile
		NtOpenProcess
		NtOpenProcessTokenEx
		NtOpenResourceManager
		NtOpenSymbolicLinkObject
		NtOpenThread
		NtOpenThreadTokenEx
		NtOpenTransaction
		NtOpenTransactionManager
		NtPowerInformation
		NtPrepareComplete
		NtPrepareEnlistment
		NtPrePrepareComplete
		NtPrePrepareEnlistment
		NtProtectVirtualMemory
		NtQueryAttributesFile
		NtQueryDirectoryFile
		NtQueryInformationEnlistment
		NtQueryInformationFile
		NtQueryInformationProcess
		NtQueryInformationResourceManager
		NtQueryInformationThread
		NtQueryInformationToken
		NtQueryInformationTransaction
		NtQueryInformationTransactionManager
		NtQueryMultipleValueKey
		NtQueryObject
		NtQueryPerformanceCounter
		NtQueryQuotaInformationFile
		NtQuerySecurityObject
		NtQuerySymbolicLinkObject
		NtQuerySystemTime
		NtQueryVirtualMemory
		NtQueryVolumeInformationFile
		NtReadFile
		NtReadOnlyEnlistment
		NtRecoverEnlistment
		NtRecoverResourceManager
		NtRecoverTransactionManager
		NtRenameKey
		NtRenameTransactionManager
		NtRollbackComplete
		NtRollbackEnlistment
		NtRollbackTransaction
		NtRollforwardTransactionManager
		NtSetInformationEnlistment
		NtSetInformationFile
		NtSetInformationKey
		NtSetInformationResourceManager
		NtSetInformationThread
		NtSetInformationToken
		NtSetInformationTransaction
		NtSetInformationTransactionManager
		NtSetQuotaInformationFile
		NtSetSecurityObject
		NtSinglePhaseReject
		NtUnlockFile
		NtUnmapViewOfSection
		NtWaitForSingleObject
		NtWriteFile
		RtlAbsoluteToSelfRelativeSD
		RtlAddAccessAllowedAce
		RtlAddAccessAllowedAceEx
		RtlAddAce
		RtlAddFunctionTable
		RtlAddGrowableFunctionTable
		RtlAllocateAndInitializeSid
		RtlAllocateHeap
		RtlAnsiStringToUnicodeString
		RtlAppendStringToString
		RtlAppendUnicodeStringToString
		RtlAppendUnicodeToString
		RtlAreBitsClear
		RtlAreBitsSet
		RtlCaptureContext
		RtlCaptureStackBackTrace
		RtlCharToInteger
		RtlCheckRegistryKey
		RtlClearBits
		RtlCmEncodeMemIoResource
		RtlCompareMemory
		RtlCompareMemoryUlong
		RtlCompareString
		RtlCompareUnicodeString
		RtlCompressBuffer
		RtlConvertSidToUnicodeString
		RtlCopyLuid
		RtlCopyMemoryNonTemporal
		RtlCopySid
		RtlCopyString
		RtlCopyUnicodeString
		RtlCreateAcl
		RtlCreateHeap
		RtlCreateRegistryKey
		RtlCreateSecurityDescriptor
		RtlCreateSystemVolumeInformationFolder
		RtlCreateUnicodeString
		RtlCustomCPToUnicodeN
		RtlDecompressBuffer
		RtlDecompressBufferEx
		RtlDecompressFragment
		RtlDelete
		RtlDeleteAce
		RtlDeleteElementGenericTable
		RtlDeleteElementGenericTableAvl
		RtlDeleteFunctionTable
		RtlDeleteGrowableFunctionTable
		RtlDeleteNoSplay
		RtlDeleteRegistryValue
		RtlDestroyHeap
		RtlDowncaseUnicodeString
		RtlDrainNonVolatileFlush
		RtlEnumerateGenericTable
		RtlEnumerateGenericTableAvl
		RtlEnumerateGenericTableLikeADirectory
		RtlEnumerateGenericTableWithoutSplaying
		RtlEnumerateGenericTableWithoutSplayingAvl
		RtlEqualPrefixSid
		RtlEqualSid
		RtlEqualUnicodeString
		RtlEthernetAddressToStringA
		RtlEthernetAddressToStringW
		RtlEthernetStringToAddressA
		RtlEthernetStringToAddressW
		RtlFindClearBits
		RtlFindClearBitsAndSet
		RtlFindClearRuns
		RtlFindLastBackwardRunClear
		RtlFindLeastSignificantBit
		RtlFindLongestRunClear
		RtlFindMostSignificantBit
		RtlFindNextForwardRunClear
		RtlFindSetBits
		RtlFindSetBitsAndClear
		RtlFirstEntrySList
		RtlFlushNonVolatileMemory
		RtlFlushNonVolatileMemoryRanges
		RtlFreeAnsiString
		RtlFreeHeap
		RtlFreeNonVolatileToken
		RtlFreeOemString
		RtlFreeUnicodeString
		RtlGenerate8dot3Name
		RtlGetAce
		RtlGetCompressionWorkSpaceSize
		RtlGetDaclSecurityDescriptor
		RtlGetElementGenericTable
		RtlGetElementGenericTableAvl
		RtlGetEnabledExtendedFeatures
		RtlGetFunctionTableListHead
		RtlGetGroupSecurityDescriptor
		RtlGetNonVolatileToken
		RtlGetOwnerSecurityDescriptor
		RtlGetSaclSecurityDescriptor
		RtlGetUnloadEventTrace
		RtlGetUnloadEventTraceEx
		RtlGetVersion
		RtlGrowFunctionTable
		RtlGUIDFromString
		RtlHashUnicodeString
		RtlInitAnsiString
		RtlInitCodePageTable
		RtlInitializeBitMap
		RtlInitializeGenericTable
		RtlInitializeGenericTableAvl
		RtlInitializeSid
		RtlInitializeSidEx
		RtlInitializeSListHead
		RtlInitString
		RtlInitStringEx
		RtlInitUnicodeString
		RtlInsertElementGenericTable
		RtlInsertElementGenericTableAvl
		RtlInsertElementGenericTableFullAvl
		RtlInstallFunctionTableCallback
		RtlInt64ToUnicodeString
		RtlIntegerToUnicodeString
		RtlInterlockedFlushSList
		RtlInterlockedPushEntrySList
		RtlIoDecodeMemIoResource
		RtlIoEncodeMemIoResource
		RtlIpv4AddressToStringA
		RtlIpv4AddressToStringExW
		RtlIpv4StringToAddressA
		RtlIpv4StringToAddressExA
		RtlIpv4StringToAddressExW
		RtlIpv4StringToAddressW
		RtlIpv6AddressToStringA
		RtlIpv6AddressToStringExW
		RtlIpv6AddressToStringW
		RtlIpv6StringToAddressA
		RtlIpv6StringToAddressExW
		RtlIpv6StringToAddressW
		RtlIsGenericTableEmpty
		RtlIsGenericTableEmptyAvl
		RtlIsNameInExpression
		RtlIsNameLegalDOS8Dot3
		RtlIsValidLocaleName
		RtlLengthSecurityDescriptor
		RtlLengthSid
		RtlLocalTimeToSystemTime
		RtlLookupElementGenericTable
		RtlLookupElementGenericTableAvl
		RtlLookupElementGenericTableFullAvl
		RtlLookupFirstMatchingElementGenericTableAvl
		RtlLookupFunctionEntry
		RtlMapGenericMask
		RtlMoveMemory
		RtlMultiByteToUnicodeN
		RtlMultiByteToUnicodeSize
		RtlNtStatusToDosError
		RtlNumberGenericTableElements
		RtlNumberGenericTableElementsAvl
		RtlNumberOfClearBits
		RtlNumberOfSetBits
		RtlNumberOfSetBitsUlongPtr
		RtlOemStringToUnicodeString
		RtlOemToUnicodeN
		RtlPcToFileHeader
		RtlPrefixUnicodeString
		RtlQueryDepthSList
		RtlQueryRegistryValues
		RtlRaiseException
		RtlRandom
		RtlRandomEx
		RtlRealPredecessor
		RtlRealSuccessor
		RtlRestoreContext
		RtlRunOnceBeginInitialize
		RtlRunOnceComplete
		RtlRunOnceExecuteOnce
		RtlRunOnceInitialize
		RtlSecondsSince1970ToTime
		RtlSecondsSince1980ToTime
		RtlSelfRelativeToAbsoluteSD
		RtlSetAllBits
		RtlSetBits
		RtlSetDaclSecurityDescriptor
		RtlSetGroupSecurityDescriptor
		RtlSetOwnerSecurityDescriptor
		RtlSplay
		RtlStringFromGUID
		RtlSubAuthorityCountSid
		RtlSubAuthoritySid
		RtlSubtreePredecessor
		RtlSubtreeSuccessor
		RtlTimeFieldsToTime
		RtlTimeToSecondsSince1970
		RtlTimeToSecondsSince1980
		RtlTimeToTimeFields
		RtlUnicodeStringToAnsiString
		RtlUnicodeStringToCountedOemString
		RtlUnicodeStringToInteger
		RtlUnicodeStringToOemString
		RtlUnicodeToCustomCPN
		RtlUnicodeToMultiByteN
		RtlUnicodeToMultiByteSize
		RtlUnicodeToOemN
		RtlUnicodeToUTF8N
		RtlUniform
		RtlUnwind
		RtlUpcaseUnicodeChar
		RtlUpcaseUnicodeString
		RtlUpcaseUnicodeStringToCountedOemString
		RtlUpcaseUnicodeStringToOemString
		RtlUpcaseUnicodeToCustomCPN
		RtlUpcaseUnicodeToMultiByteN
		RtlUpcaseUnicodeToOemN
		RtlUpperChar
		RtlUpperString
		RtlUTF8ToUnicodeN
		RtlValidRelativeSecurityDescriptor
		RtlVerifyVersionInfo
		RtlVirtualUnwind
		RtlWriteNonVolatileMemory
		RtlWriteRegistryValue
		vDbgPrintEx
		vDbgPrintExWithPrefix
		VerSetConditionMask
		ZwAllocateLocallyUniqueId
		ZwAllocateVirtualMemory
		ZwClose
		ZwCommitComplete
		ZwCommitEnlistment
		ZwCommitTransaction
		ZwCreateDirectoryObject
		ZwCreateEnlistment
		ZwCreateEvent
		ZwCreateFile
		ZwCreateKey
		ZwCreateKeyTransacted
		ZwCreateResourceManager
		ZwCreateSection
		ZwCreateTransaction
		ZwCreateTransactionManager
		ZwDeleteFile
		ZwDeleteKey
		ZwDeleteValueKey
		ZwDeviceIoControlFile
		ZwDuplicateObject
		ZwDuplicateToken
		ZwEnumerateKey
		ZwEnumerateTransactionObject
		ZwEnumerateValueKey
		ZwFlushBuffersFileEx
		ZwFlushKey
		ZwFlushVirtualMemory
		ZwFreeVirtualMemory
		ZwFsControlFile
		ZwGetNotificationResourceManager
		ZwLoadDriver
		ZwLockFile
		ZwMakeTemporaryObject
		ZwMapViewOfSection
		ZwNotifyChangeKey
		ZwOpenDirectoryObject
		ZwOpenEnlistment
		ZwOpenEvent
		ZwOpenFile
		ZwOpenKey
		ZwOpenKeyEx
		ZwOpenKeyTransacted
		ZwOpenKeyTransactedEx
		ZwOpenProcess
		ZwOpenProcessTokenEx
		ZwOpenResourceManager
		ZwOpenSection
		ZwOpenSymbolicLinkObject
		ZwOpenThreadTokenEx
		ZwOpenTransaction
		ZwOpenTransactionManager
		ZwPowerInformation
		ZwPrepareComplete
		ZwPrepareEnlistment
		ZwPrePrepareComplete
		ZwPrePrepareEnlistment
		ZwQueryDirectoryFile
		ZwQueryEaFile
		ZwQueryFullAttributesFile
		ZwQueryInformationEnlistment
		ZwQueryInformationFile
		ZwQueryInformationProcess
		ZwQueryInformationResourceManager
		ZwQueryInformationToken
		ZwQueryInformationTransaction
		ZwQueryInformationTransactionManager
		ZwQueryKey
		ZwQueryObject
		ZwQueryQuotaInformationFile
		ZwQuerySecurityObject
		ZwQuerySymbolicLinkObject
		ZwQuerySystemInformation
		ZwQuerySystemInformationEx
		ZwQueryValueKey
		ZwQueryVirtualMemory
		ZwQueryVolumeInformationFile
		ZwReadFile
		ZwReadOnlyEnlistment
		ZwRecoverEnlistment
		ZwRecoverResourceManager
		ZwRecoverTransactionManager
		ZwRollbackComplete
		ZwRollbackEnlistment
		ZwRollbackTransaction
		ZwRollforwardTransactionManager
		ZwSetEaFile
		ZwSetEvent
		ZwSetInformationEnlistment
		ZwSetInformationFile
		ZwSetInformationResourceManager
		ZwSetInformationThread
		ZwSetInformationToken
		ZwSetInformationTransaction
		ZwSetInformationVirtualMemory
		ZwSetQuotaInformationFile
		ZwSetSecurityObject
		ZwSetValueKey
		ZwSetVolumeInformationFile
		ZwSinglePhaseReject
		ZwSuspendProcess
		ZwTerminateProcess
		ZwUnloadDriver
		ZwUnlockFile
		ZwUnmapViewOfSection
		ZwUnmapViewOfSectionEx
		ZwWaitForSingleObject
		ZwWriteFile
		*/
	}
}