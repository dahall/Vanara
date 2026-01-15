using System.Collections.Generic;
using System.Linq;
using Vanara.Extensions.Reflection;

namespace Vanara.PInvoke;

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

	/// <summary>Lists the different types of notifications that can be received by an enlistment.</summary>
	[PInvokeData("ktmtypes.h", MSDNShortId = "32c2be6a-c75a-9391-274d-a53a6e2b74c8")]
	public enum NOTIFICATION_MASK
	{
		/// <summary>A mask that indicates all valid bits for a transaction notification.</summary>
		TRANSACTION_NOTIFY_MASK = 0x3FFFFFFF,

		/// <summary>
		/// This notification is called after a client calls CommitTransaction and either no resource manager (RM) supports single-phase
		/// commit or a superior transaction manager (TM) calls PrePrepareEnlistment. This notification is received by the RMs
		/// indicating that they should complete any work that could cause other RMs to need to enlist in a transaction, such as
		/// flushing its cache. After completing these operations the RM must call PrePrepareComplete. To receive this notification the
		/// RM must also support TRANSACTION_NOTIFY_PREPARE and TRANSACTION_NOTIFY_COMMIT.
		/// </summary>
		TRANSACTION_NOTIFY_PREPREPARE = 0x00000001,

		/// <summary>
		/// This notification is called after the TRANSACTION_NOTIFY_PREPREPARE processing is complete. It signals the RM to complete
		/// all the work that is associated with this enlistment so that it can guarantee that a commit operation could succeed and an
		/// abort operation could also succeed. Typically, the bulk of the work for a transaction is done during the prepare phase. For
		/// durable RMs, they must log their state prior to calling the PrepareComplete function. This is the last chance for the RM to
		/// request that the transaction be rolled back.
		/// </summary>
		TRANSACTION_NOTIFY_PREPARE = 0x00000002,

		/// <summary>
		/// This notification signals the RM to complete all the work that is associated with this enlistment. Typically, the RM
		/// releases any locks, releases any information necessary to roll back the transaction. The RM must respond by calling the
		/// CommitComplete function when it has finished these operations.
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
	/// <para>
	/// The <c>DbgPrompt</c> routine displays a caller-specified user prompt string on the kernel debugger's display device and obtains
	/// a user response string.
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
	/// <c>DbgPrompt</c> returns the number of characters that the Response buffer received, including the terminating newline
	/// character. <c>DbgPrompt</c> returns zero if it receives no characters.
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
	/// <param name="NotificationFunction">
	/// A pointer to an LdrDllNotification notification callback function to call when the DLL is loaded.
	/// </param>
	/// <param name="Context">A pointer to context data for the callback function.</param>
	/// <param name="Cookie">
	/// A pointer to a variable to receive an identifier for the callback function. This identifier is used to unregister the
	/// notification callback function.
	/// </param>
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
	// https://docs.microsoft.com/en-us/windows/desktop/devnotes/ldrregisterdllnotification NTSTATUS NTAPI LdrRegisterDllNotification(
	// _In_ ULONG Flags, _In_ PLDR_DLL_NOTIFICATION_FUNCTION NotificationFunction, _In_opt_ PVOID Context, _Out_ PVOID *Cookie );
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
	[PInvokeData("Ntseapi.h", MSDNShortId = "3a07ddc6-9748-4f96-a597-2af6b4282e56")]
	public static extern NTStatus NtCompareTokens([In] IntPtr FirstTokenHandle, [In] IntPtr SecondTokenHandle, [MarshalAs(UnmanagedType.U1)] out bool Equal);

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
	/// Returns a <c>SYSTEM_KERNEL_VA_SHADOW_INFORMATION</c> structure that can be used to determine the speculation control settings
	/// for attacks involving rogue data cache loads (such as CVE-2017-5754).
	/// </para>
	/// <para>SystemLeapSecondInformation</para>
	/// <para>
	/// Returns an opaque <c>SYSTEM_LEAP_SECOND_INFORMATION</c> structure that can be used to enable or disable leap seconds
	/// system-wide. This setting will persist even after a reboot of the system.
	/// </para>
	/// <para>SystemLookasideInformation</para>
	/// <para>
	/// Returns an opaque <c>SYSTEM_LOOKASIDE_INFORMATION</c> structure that can be used to generate an unpredictable seed for a random
	/// number generator. Use the CryptGenRandom function instead.
	/// </para>
	/// <para>SystemPerformanceInformation</para>
	/// <para>
	/// Returns an opaque <c>SYSTEM_PERFORMANCE_INFORMATION</c> structure that can be used to generate an unpredictable seed for a
	/// random number generator. Use the CryptGenRandomfunction instead.
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
	/// Returns a <c>SYSTEM_QUERY_PERFORMANCE_COUNTER_INFORMATION</c> structure that can be used to determine whether the system
	/// requires a kernel transition to retrieve the high-resolution performance counter information through a QueryPerformanceCounter
	/// function call.
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
	/// A pointer to a buffer that receives the requested information. The size and structure of this information varies depending on
	/// the value of the SystemInformationClass parameter:
	/// </para>
	/// <para>SYSTEM_BASIC_INFORMATION</para>
	/// <para>
	/// When the SystemInformationClass parameter is <c>SystemBasicInformation</c>, the buffer pointed to by the SystemInformation
	/// parameter should be large enough to hold a single <c>SYSTEM_BASIC_INFORMATION</c> structure having the following layout:
	/// </para>
	/// <code>
	///typedef struct _SYSTEM_BASIC_INFORMATION {
	///BYTE Reserved1[24];
	///PVOID Reserved2[4];
	///CCHAR NumberOfProcessors;
	///} SYSTEM_BASIC_INFORMATION;"
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
	///typedef struct _SYSTEM_CODEINTEGRITY_INFORMATION {
	///ULONG  Length;
	///ULONG  CodeIntegrityOptions;
	///} SYSTEM_CODEINTEGRITY_INFORMATION, *PSYSTEM_CODEINTEGRITY_INFORMATION;"
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
	/// following paths are restricted and cannot be added as an exclusion: Built-in Path Exclusions: The following paths are excluded
	/// by default. You don't need to specifically add these to path exclusions. This only applies on ARM (Windows Runtime).
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
	///typedef struct _SYSTEM_EXCEPTION_INFORMATION {
	///BYTE Reserved1[16];
	///} SYSTEM_EXCEPTION_INFORMATION;
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
	///typedef struct _SYSTEM_INTERRUPT_INFORMATION {
	///BYTE Reserved1[24];
	///} SYSTEM_INTERRUPT_INFORMATION;
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
	///typedef struct _SYSTEM_KERNEL_VA_SHADOW_INFORMATION {
	///struct {
	///ULONG KvaShadowEnabled:1;
	///ULONG KvaShadowUserGlobal:1;
	///ULONG KvaShadowPcid:1;
	///ULONG KvaShadowInvpcid:1;
	///ULONG Reserved:28;
	///} KvaShadowFlags;
	///} SYSTEM_KERNEL_VA_SHADOW_INFORMATION, * PSYSTEM_KERNEL_VA_SHADOW_INFORMATION;
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
	///typedef struct _SYSTEM_LEAP_SECOND_INFORMATION {
	///BOOLEAN Enabled;
	///ULONG Flags;
	///} SYSTEM_LEAP_SECOND_INFORMATION
	/// </code>
	/// <para>The <c>Flags</c> field is reserved for future use.</para>
	/// <para>SYSTEM_LOOKASIDE_INFORMATION</para>
	/// <para>
	/// When the SystemInformationClass parameter is <c>SystemLookasideInformation</c>, the buffer pointed to by the SystemInformation
	/// parameter should be large enough to hold an opaque <c>SYSTEM_LOOKASIDE_INFORMATION</c> structure for use in generating an
	/// unpredictable seed for a random number generator. For this purpose, the structure has the following layout:
	/// </para>
	/// <code>
	///typedef struct _SYSTEM_LOOKASIDE_INFORMATION {
	///BYTE Reserved1[32];
	///} SYSTEM_LOOKASIDE_INFORMATION;
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
	///typedef struct _SYSTEM_PERFORMANCE_INFORMATION {
	///BYTE Reserved1[312];
	///} SYSTEM_PERFORMANCE_INFORMATION;
	/// </code>
	/// <para>Individual members of the structure are reserved for internal use by the operating system.</para>
	/// <para>Use the CryptGenRandom function instead to generate cryptographically random data.</para>
	/// <para>SYSTEM_POLICY_INFORMATION</para>
	/// <para>
	/// When the SystemInformationClass parameter is <c>SystemPolicyInformation</c>, the buffer pointed to by the SystemInformation
	/// parameter should be large enough to hold a single <c>SYSTEM_POLICY_INFORMATION</c> structure having the following layout:
	/// </para>
	/// <code>
	///typedef struct _SYSTEM_POLICY_INFORMATION {
	///PVOID Reserved1[2];
	///ULONG Reserved2[3];
	///} SYSTEM_POLICY_INFORMATION;
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
	///typedef struct _SYSTEM_PROCESS_INFORMATION {
	///ULONG NextEntryOffset;
	///ULONG NumberOfThreads;
	///BYTE Reserved1[48];
	///UNICODE_STRING ImageName;
	///KPRIORITY BasePriority;
	///HANDLE UniqueProcessId;
	///PVOID Reserved2;
	///ULONG HandleCount;
	///ULONG SessionId;
	///PVOID Reserved3;
	///SIZE_T PeakVirtualSize;
	///SIZE_T VirtualSize;
	///ULONG Reserved4;
	///SIZE_T PeakWorkingSetSize;
	///SIZE_T WorkingSetSize;
	///PVOID Reserved5;
	///SIZE_T QuotaPagedPoolUsage;
	///PVOID Reserved6;
	///SIZE_T QuotaNonPagedPoolUsage;
	///SIZE_T PagefileUsage;
	///SIZE_T PeakPagefileUsage;
	///SIZE_T PrivatePageCount;
	///LARGE_INTEGER Reserved7[6];
	///} SYSTEM_PROCESS_INFORMATION;
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
	/// process. For more information about <c>SYSTEM_PROCESS_INFORMATION</c>, see the section about this structure in this article.
	/// Each <c>SYSTEM_THREAD_INFORMATION</c> structure has the following layout:
	/// </para>
	/// <code>
	///typedef struct _SYSTEM_THREAD_INFORMATION {
	///LARGE_INTEGER Reserved1[3];
	///ULONG Reserved2;
	///PVOID StartAddress;
	///CLIENT_ID ClientId;
	///KPRIORITY Priority;
	///LONG BasePriority;
	///ULONG Reserved3;
	///ULONG ThreadState;
	///ULONG WaitReason;
	///} SYSTEM_THREAD_INFORMATION;
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
	/// <c>SYSTEM_PROCESSOR_PERFORMANCE_INFORMATION</c> structures as there are processors (CPUs) installed in the system. Each
	/// structure has the following layout:
	/// </para>
	/// <code>
	///typedef struct
	///_SYSTEM_PROCESSOR_PERFORMANCE_INFORMATION {
	///LARGE_INTEGER IdleTime;
	///LARGE_INTEGER KernelTime;
	///LARGE_INTEGER UserTime;
	///LARGE_INTEGER Reserved1[2];
	///ULONG Reserved2;
	///} SYSTEM_PROCESSOR_PERFORMANCE_INFORMATION;
	/// </code>
	/// <para>The <c>IdleTime</c> member contains the amount of time that the system has been idle, in 100-nanosecond intervals.</para>
	/// <para>
	/// The <c>KernelTime</c> member contains the amount of time that the system has spent executing in Kernel mode (including all
	/// threads in all processes, on all processors), in 100-nanosecond intervals.
	/// </para>
	/// <para>
	/// The <c>UserTime</c> member contains the amount of time that the system has spent executing in User mode (including all threads
	/// in all processes, on all processors), in 100-nanosecond intervals.
	/// </para>
	/// <para>Use GetSystemTimesinstead to retrieve this information.</para>
	/// <para>SYSTEM_QUERY_PERFORMANCE_COUNTER_INFORMATION</para>
	/// <para>
	/// When the SystemInformationClass parameter is <c>SystemQueryPerformanceCounterInformation</c>, the buffer pointed to by the
	/// SystemInformation parameter should be large enough to hold a single <c>SYSTEM_QUERY_PERFORMANCE_COUNTER_INFORMATION</c>
	/// structure having the following layout:
	/// </para>
	/// <code>
	///typedef struct _SYSTEM_QUERY_PERFORMANCE_COUNTER_INFORMATION {
	///ULONG                           Version;
	///QUERY_PERFORMANCE_COUNTER_FLAGS Flags;
	///QUERY_PERFORMANCE_COUNTER_FLAGS ValidFlags;
	///} SYSTEM_QUERY_PERFORMANCE_COUNTER_INFORMATION;
	/// </code>
	/// <para>
	/// The <c>Flags</c> and <c>ValidFlags</c> members are <c>QUERY_PERFORMANCE_COUNTER_FLAGS</c> structures having the following layout:
	/// </para>
	/// <code>
	///typedef struct _QUERY_PERFORMANCE_COUNTER_FLAGS {
	///union {
	///struct {
	///ULONG KernelTransition:1;
	///ULONG Reserved:31;
	///};
	///ULONG ul;
	///};
	///} QUERY_PERFORMANCE_COUNTER_FLAGS;
	/// </code>
	/// <para>
	/// The <c>ValidFlags</c> member of the <c>SYSTEM_QUERY_PERFORMANCE_COUNTER_INFORMATION</c> structure indicates which bits of the
	/// <c>Flags</c> member contain valid information. If a kernel transition is required, the <c>KernelTransition</c> bit is set in
	/// both <c>ValidFlags</c> and <c>Flags</c>. If a kernel transition is not required, the <c>KernelTransition</c> bit is set in
	/// <c>ValidFlags</c> and clear in <c>Flags</c>.
	/// </para>
	/// <para>SYSTEM_REGISTRY_QUOTA_INFORMATION</para>
	/// <para>
	/// When the SystemInformationClass parameter is <c>SystemRegistryQuotaInformation</c>, the buffer pointed to by the
	/// SystemInformation parameter should be large enough to hold a single <c>SYSTEM_REGISTRY_QUOTA_INFORMATION</c> structure having
	/// the following layout:
	/// </para>
	/// <code>
	///typedef struct _SYSTEM_REGISTRY_QUOTA_INFORMATION {
	///ULONG RegistryQuotaAllowed;
	///ULONG RegistryQuotaUsed;
	///PVOID Reserved1;
	///} SYSTEM_REGISTRY_QUOTA_INFORMATION;
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
	///typedef struct _SYSTEM_SPECULATION_CONTROL_INFORMATION {
	///struct {
	///ULONG BpbEnabled:1;
	///ULONG BpbDisabledSystemPolicy:1;
	///ULONG BpbDisabledNoHardwareSupport:1;
	///ULONG SpecCtrlEnumerated:1;
	///ULONG SpecCmdEnumerated:1;
	///ULONG IbrsPresent:1;
	///ULONG StibpPresent:1;
	///ULONG SmepPresent:1;
	///ULONG Reserved:24;
	///} SpeculationControlFlags;
	///
	///} SYSTEM_SPECULATION_CONTROL_INFORMATION, * PSYSTEM_SPECULATION_CONTROL_INFORMATION;
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
	///typedef struct _SYSTEM_TIMEOFDAY_INFORMATION {
	///BYTE Reserved1[48];
	///} SYSTEM_TIMEOFDAY_INFORMATION;
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
	/// Returns a <c>SYSTEM_KERNEL_VA_SHADOW_INFORMATION</c> structure that can be used to determine the speculation control settings
	/// for attacks involving rogue data cache loads (such as CVE-2017-5754).
	/// </para>
	/// <para>SystemLeapSecondInformation</para>
	/// <para>
	/// Returns an opaque <c>SYSTEM_LEAP_SECOND_INFORMATION</c> structure that can be used to enable or disable leap seconds
	/// system-wide. This setting will persist even after a reboot of the system.
	/// </para>
	/// <para>SystemLookasideInformation</para>
	/// <para>
	/// Returns an opaque <c>SYSTEM_LOOKASIDE_INFORMATION</c> structure that can be used to generate an unpredictable seed for a random
	/// number generator. Use the CryptGenRandom function instead.
	/// </para>
	/// <para>SystemPerformanceInformation</para>
	/// <para>
	/// Returns an opaque <c>SYSTEM_PERFORMANCE_INFORMATION</c> structure that can be used to generate an unpredictable seed for a
	/// random number generator. Use the CryptGenRandomfunction instead.
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
	/// Returns a <c>SYSTEM_QUERY_PERFORMANCE_COUNTER_INFORMATION</c> structure that can be used to determine whether the system
	/// requires a kernel transition to retrieve the high-resolution performance counter information through a QueryPerformanceCounter
	/// function call.
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
	/// A pointer to a buffer that receives the requested information. The size and structure of this information varies depending on
	/// the value of the SystemInformationClass parameter:
	/// </para>
	/// <para>SYSTEM_BASIC_INFORMATION</para>
	/// <para>
	/// When the SystemInformationClass parameter is <c>SystemBasicInformation</c>, the buffer pointed to by the SystemInformation
	/// parameter should be large enough to hold a single <c>SYSTEM_BASIC_INFORMATION</c> structure having the following layout:
	/// </para>
	/// <code>
	///typedef struct _SYSTEM_BASIC_INFORMATION {
	///BYTE Reserved1[24];
	///PVOID Reserved2[4];
	///CCHAR NumberOfProcessors;
	///} SYSTEM_BASIC_INFORMATION;"
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
	///typedef struct _SYSTEM_CODEINTEGRITY_INFORMATION {
	///ULONG  Length;
	///ULONG  CodeIntegrityOptions;
	///} SYSTEM_CODEINTEGRITY_INFORMATION, *PSYSTEM_CODEINTEGRITY_INFORMATION;"
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
	/// following paths are restricted and cannot be added as an exclusion: Built-in Path Exclusions: The following paths are excluded
	/// by default. You don't need to specifically add these to path exclusions. This only applies on ARM (Windows Runtime).
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
	///typedef struct _SYSTEM_EXCEPTION_INFORMATION {
	///BYTE Reserved1[16];
	///} SYSTEM_EXCEPTION_INFORMATION;
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
	///typedef struct _SYSTEM_INTERRUPT_INFORMATION {
	///BYTE Reserved1[24];
	///} SYSTEM_INTERRUPT_INFORMATION;
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
	///typedef struct _SYSTEM_KERNEL_VA_SHADOW_INFORMATION {
	///struct {
	///ULONG KvaShadowEnabled:1;
	///ULONG KvaShadowUserGlobal:1;
	///ULONG KvaShadowPcid:1;
	///ULONG KvaShadowInvpcid:1;
	///ULONG Reserved:28;
	///} KvaShadowFlags;
	///} SYSTEM_KERNEL_VA_SHADOW_INFORMATION, * PSYSTEM_KERNEL_VA_SHADOW_INFORMATION;
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
	///typedef struct _SYSTEM_LEAP_SECOND_INFORMATION {
	///BOOLEAN Enabled;
	///ULONG Flags;
	///} SYSTEM_LEAP_SECOND_INFORMATION
	/// </code>
	/// <para>The <c>Flags</c> field is reserved for future use.</para>
	/// <para>SYSTEM_LOOKASIDE_INFORMATION</para>
	/// <para>
	/// When the SystemInformationClass parameter is <c>SystemLookasideInformation</c>, the buffer pointed to by the SystemInformation
	/// parameter should be large enough to hold an opaque <c>SYSTEM_LOOKASIDE_INFORMATION</c> structure for use in generating an
	/// unpredictable seed for a random number generator. For this purpose, the structure has the following layout:
	/// </para>
	/// <code>
	///typedef struct _SYSTEM_LOOKASIDE_INFORMATION {
	///BYTE Reserved1[32];
	///} SYSTEM_LOOKASIDE_INFORMATION;
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
	///typedef struct _SYSTEM_PERFORMANCE_INFORMATION {
	///BYTE Reserved1[312];
	///} SYSTEM_PERFORMANCE_INFORMATION;
	/// </code>
	/// <para>Individual members of the structure are reserved for internal use by the operating system.</para>
	/// <para>Use the CryptGenRandom function instead to generate cryptographically random data.</para>
	/// <para>SYSTEM_POLICY_INFORMATION</para>
	/// <para>
	/// When the SystemInformationClass parameter is <c>SystemPolicyInformation</c>, the buffer pointed to by the SystemInformation
	/// parameter should be large enough to hold a single <c>SYSTEM_POLICY_INFORMATION</c> structure having the following layout:
	/// </para>
	/// <code>
	///typedef struct _SYSTEM_POLICY_INFORMATION {
	///PVOID Reserved1[2];
	///ULONG Reserved2[3];
	///} SYSTEM_POLICY_INFORMATION;
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
	///typedef struct _SYSTEM_PROCESS_INFORMATION {
	///ULONG NextEntryOffset;
	///ULONG NumberOfThreads;
	///BYTE Reserved1[48];
	///UNICODE_STRING ImageName;
	///KPRIORITY BasePriority;
	///HANDLE UniqueProcessId;
	///PVOID Reserved2;
	///ULONG HandleCount;
	///ULONG SessionId;
	///PVOID Reserved3;
	///SIZE_T PeakVirtualSize;
	///SIZE_T VirtualSize;
	///ULONG Reserved4;
	///SIZE_T PeakWorkingSetSize;
	///SIZE_T WorkingSetSize;
	///PVOID Reserved5;
	///SIZE_T QuotaPagedPoolUsage;
	///PVOID Reserved6;
	///SIZE_T QuotaNonPagedPoolUsage;
	///SIZE_T PagefileUsage;
	///SIZE_T PeakPagefileUsage;
	///SIZE_T PrivatePageCount;
	///LARGE_INTEGER Reserved7[6];
	///} SYSTEM_PROCESS_INFORMATION;
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
	/// process. For more information about <c>SYSTEM_PROCESS_INFORMATION</c>, see the section about this structure in this article.
	/// Each <c>SYSTEM_THREAD_INFORMATION</c> structure has the following layout:
	/// </para>
	/// <code>
	///typedef struct _SYSTEM_THREAD_INFORMATION {
	///LARGE_INTEGER Reserved1[3];
	///ULONG Reserved2;
	///PVOID StartAddress;
	///CLIENT_ID ClientId;
	///KPRIORITY Priority;
	///LONG BasePriority;
	///ULONG Reserved3;
	///ULONG ThreadState;
	///ULONG WaitReason;
	///} SYSTEM_THREAD_INFORMATION;
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
	/// <c>SYSTEM_PROCESSOR_PERFORMANCE_INFORMATION</c> structures as there are processors (CPUs) installed in the system. Each
	/// structure has the following layout:
	/// </para>
	/// <code>
	///typedef struct
	///_SYSTEM_PROCESSOR_PERFORMANCE_INFORMATION {
	///LARGE_INTEGER IdleTime;
	///LARGE_INTEGER KernelTime;
	///LARGE_INTEGER UserTime;
	///LARGE_INTEGER Reserved1[2];
	///ULONG Reserved2;
	///} SYSTEM_PROCESSOR_PERFORMANCE_INFORMATION;
	/// </code>
	/// <para>The <c>IdleTime</c> member contains the amount of time that the system has been idle, in 100-nanosecond intervals.</para>
	/// <para>
	/// The <c>KernelTime</c> member contains the amount of time that the system has spent executing in Kernel mode (including all
	/// threads in all processes, on all processors), in 100-nanosecond intervals.
	/// </para>
	/// <para>
	/// The <c>UserTime</c> member contains the amount of time that the system has spent executing in User mode (including all threads
	/// in all processes, on all processors), in 100-nanosecond intervals.
	/// </para>
	/// <para>Use GetSystemTimesinstead to retrieve this information.</para>
	/// <para>SYSTEM_QUERY_PERFORMANCE_COUNTER_INFORMATION</para>
	/// <para>
	/// When the SystemInformationClass parameter is <c>SystemQueryPerformanceCounterInformation</c>, the buffer pointed to by the
	/// SystemInformation parameter should be large enough to hold a single <c>SYSTEM_QUERY_PERFORMANCE_COUNTER_INFORMATION</c>
	/// structure having the following layout:
	/// </para>
	/// <code>
	///typedef struct _SYSTEM_QUERY_PERFORMANCE_COUNTER_INFORMATION {
	///ULONG                           Version;
	///QUERY_PERFORMANCE_COUNTER_FLAGS Flags;
	///QUERY_PERFORMANCE_COUNTER_FLAGS ValidFlags;
	///} SYSTEM_QUERY_PERFORMANCE_COUNTER_INFORMATION;
	/// </code>
	/// <para>
	/// The <c>Flags</c> and <c>ValidFlags</c> members are <c>QUERY_PERFORMANCE_COUNTER_FLAGS</c> structures having the following layout:
	/// </para>
	/// <code>
	///typedef struct _QUERY_PERFORMANCE_COUNTER_FLAGS {
	///union {
	///struct {
	///ULONG KernelTransition:1;
	///ULONG Reserved:31;
	///};
	///ULONG ul;
	///};
	///} QUERY_PERFORMANCE_COUNTER_FLAGS;
	/// </code>
	/// <para>
	/// The <c>ValidFlags</c> member of the <c>SYSTEM_QUERY_PERFORMANCE_COUNTER_INFORMATION</c> structure indicates which bits of the
	/// <c>Flags</c> member contain valid information. If a kernel transition is required, the <c>KernelTransition</c> bit is set in
	/// both <c>ValidFlags</c> and <c>Flags</c>. If a kernel transition is not required, the <c>KernelTransition</c> bit is set in
	/// <c>ValidFlags</c> and clear in <c>Flags</c>.
	/// </para>
	/// <para>SYSTEM_REGISTRY_QUOTA_INFORMATION</para>
	/// <para>
	/// When the SystemInformationClass parameter is <c>SystemRegistryQuotaInformation</c>, the buffer pointed to by the
	/// SystemInformation parameter should be large enough to hold a single <c>SYSTEM_REGISTRY_QUOTA_INFORMATION</c> structure having
	/// the following layout:
	/// </para>
	/// <code>
	///typedef struct _SYSTEM_REGISTRY_QUOTA_INFORMATION {
	///ULONG RegistryQuotaAllowed;
	///ULONG RegistryQuotaUsed;
	///PVOID Reserved1;
	///} SYSTEM_REGISTRY_QUOTA_INFORMATION;
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
	///typedef struct _SYSTEM_SPECULATION_CONTROL_INFORMATION {
	///struct {
	///ULONG BpbEnabled:1;
	///ULONG BpbDisabledSystemPolicy:1;
	///ULONG BpbDisabledNoHardwareSupport:1;
	///ULONG SpecCtrlEnumerated:1;
	///ULONG SpecCmdEnumerated:1;
	///ULONG IbrsPresent:1;
	///ULONG StibpPresent:1;
	///ULONG SmepPresent:1;
	///ULONG Reserved:24;
	///} SpeculationControlFlags;
	///} SYSTEM_SPECULATION_CONTROL_INFORMATION, * PSYSTEM_SPECULATION_CONTROL_INFORMATION;
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
	///typedef struct _SYSTEM_TIMEOFDAY_INFORMATION {
	///BYTE Reserved1[48];
	///} SYSTEM_TIMEOFDAY_INFORMATION;
	/// </code>
	/// <para>Individual members of the structure are reserved for internal use by the operating system.</para>
	/// <para>Use the CryptGenRandom function instead to generate cryptographically random data.</para>
	/// </returns>
	/// <exception cref="InvalidCastException">
	/// The requested SystemInformationClass does not match the return type requested. or Reported size of object does not match query.
	/// </exception>
	public static T? NtQuerySystemInformation<T>(SYSTEM_INFORMATION_CLASS SystemInformationClass)
	{
		var tType = typeof(T);
		if (CorrespondingTypeAttribute.GetCorrespondingTypes(SystemInformationClass).Any() && !CorrespondingTypeAttribute.CanGet(SystemInformationClass, tType))
			throw new InvalidCastException("The requested SystemInformationClass does not match the return type requested.");
		var status = NtQuerySystemInformation(SystemInformationClass, SafeHGlobalHandle.Null, 0, out var len);
		if ((int)status is not NTStatus.STATUS_INFO_LENGTH_MISMATCH and not NTStatus.STATUS_BUFFER_OVERFLOW and not NTStatus.STATUS_BUFFER_TOO_SMALL)
			throw status.GetException()!;
		var mem = new SafeHGlobalHandle(SystemInformationClass == SYSTEM_INFORMATION_CLASS.SystemProcessInformation ? (int)len * 2 : (int)len);
		NtQuerySystemInformation(SystemInformationClass, mem, (uint)mem.Size, out len).ThrowIfFailed();
		if (tType.IsArray)
		{
			var aType = tType.GetElementType()!;
			if (aType == typeof(SYSTEM_PROCESS_INFORMATION) && SystemInformationClass == SYSTEM_INFORMATION_CLASS.SystemProcessInformation)
			{
				var retList = new List<SYSTEM_PROCESS_INFORMATION>();
				SYSTEM_PROCESS_INFORMATION pi;
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
			return (T?)mem.InvokeGenericMethod("ToArray", [aType], [typeof(int), typeof(int)], [(int)cnt, 0]);
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
		if ((int)status is not NTStatus.STATUS_INFO_LENGTH_MISMATCH and not NTStatus.STATUS_BUFFER_OVERFLOW and not NTStatus.STATUS_BUFFER_TOO_SMALL)
			throw status.GetException()!;
		var mem = new SafeHGlobalHandle((int)len * 2);
		NtQuerySystemInformation(SYSTEM_INFORMATION_CLASS.SystemProcessInformation, mem, (uint)mem.Size, out _).ThrowIfFailed();
		var retList = new List<Tuple<SYSTEM_PROCESS_INFORMATION, SYSTEM_THREAD_INFORMATION[]>>();
		var pi = new SYSTEM_PROCESS_INFORMATION();
		var ptr = mem.DangerousGetHandle();
		var pSz = Marshal.SizeOf(pi);
		do
		{
			pi = ptr.ToStructure<SYSTEM_PROCESS_INFORMATION>();
			retList.Add(new Tuple<SYSTEM_PROCESS_INFORMATION, SYSTEM_THREAD_INFORMATION[]>(pi, ptr.Offset(pSz).ToArray<SYSTEM_THREAD_INFORMATION>((int)pi.NumberOfThreads)!));
			ptr = ptr.Offset(pi.NextEntryOffset);
		} while (pi.NextEntryOffset > 0);
		return retList;
	}

	/// <summary>
	/// Reads data from an area of memory in a specified process. The entire area to be read must be accessible or the operation fails.
	/// </summary>
	/// <param name="hProcess">
	/// A handle to the process with memory that is being read. The handle must have PROCESS_VM_READ access to the process.
	/// </param>
	/// <param name="lpBaseAddress">
	/// A pointer to the base address in the specified process from which to read. Before any data transfer occurs, the system verifies
	/// that all data in the base address and memory of the specified size is accessible for read access, and if it is not accessible
	/// the function fails.
	/// </param>
	/// <param name="lpBuffer">A pointer to a buffer that receives the contents from the address space of the specified process.</param>
	/// <param name="nSize">The number of bytes to be read from the specified process.</param>
	/// <param name="lpNumberOfBytesRead">
	/// A pointer to a variable that receives the number of bytes transferred into the specified buffer. If lpNumberOfBytesRead is
	/// <c>NULL</c>, the parameter is ignored.
	/// </param>
	/// <returns>
	/// <para>Returns an NTSTATUS success or error code.</para>
	/// <para>
	/// The forms and significance of NTSTATUS error codes are listed in the Ntstatus.h header file available in the DDK, and are
	/// described in the DDK documentation.
	/// </para>
	/// </returns>
	[DllImport(Lib.NtDll, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("winternl.h")]
	public static extern NTStatus NtWow64ReadVirtualMemory64([In] HPROCESS hProcess, [In] long lpBaseAddress, [Out] int lpBuffer, [In] long nSize, out long lpNumberOfBytesRead);

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
		public LPWSTR Name;
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
	/// All members of this structure are read-only. If a member of this structure is a pointer, the object that this member points to
	/// is read-only as well. Read-only members and objects can be used to acquire relevant information but must not be modified. To set
	/// the members of this structure, use the <c>InitializeObjectAttributes</c> macro.
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
		/// Optional quality of service to be applied to the object when it is created. Used to indicate the security impersonation
		/// level and context tracking mode (dynamic or static). Currently, the InitializeObjectAttributes macro sets this member to <c>NULL</c>.
		/// </para>
		/// </summary>
		public IntPtr securityQualityOfService;
	}

	/// <summary>Provides a <see cref="SafeHandle"/> to an enlistment that releases its handle at disposal using NTClose.</summary>
	[AutoSafeHandle(null, null, typeof(SafeNtHandle))]
	public partial class SafeEnlistmentHandle { }

	/// <summary>Provides a <see cref="SafeHandle"/> to an object that releases a created handle at disposal using NtClose.</summary>
	public abstract class SafeNtHandle : SafeHANDLE
	{
		/// <summary>Initializes a new instance of the <see cref="SafeNtHandle"/> class and assigns an existing handle.</summary>
		/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
		/// <param name="ownsHandle">
		/// <see langword="true"/> to reliably release the handle during the finalization phase; otherwise, <see langword="false"/> (not recommended).
		/// </param>
		protected SafeNtHandle(IntPtr preexistingHandle, bool ownsHandle = true) : base(preexistingHandle, ownsHandle) { }

		/// <summary>Initializes a new instance of the <see cref="SafeNtHandle"/> class.</summary>
		protected SafeNtHandle() : base() { }

#pragma warning disable CS0612 // Type or member is obsolete
		/// <inheritdoc/>
		protected override bool InternalReleaseHandle() => NtClose(handle).Succeeded;
#pragma warning restore CS0612 // Type or member is obsolete
	}

	/// <summary>Provides a <see cref="SafeHandle"/> to a resource manager that releases its handle at disposal using NTClose.</summary>
	[AutoSafeHandle(null, null, typeof(SafeNtHandle))]
	public partial class SafeResourceManagerHandle { }

	/// <summary>Provides a <see cref="SafeHandle"/> to a section that releases its handle at disposal using NTClose.</summary>
	[AutoSafeHandle(null, null, typeof(SafeNtHandle))]
	public partial class SafeSectionHandle { }

	/// <summary>Provides a <see cref="SafeHandle"/> to a transaction that releases its handle at disposal using NTClose.</summary>
	[AutoSafeHandle(null, null, typeof(SafeNtHandle))]
	public partial class SafeTransactionHandle { }

	/// <summary>Provides a <see cref="SafeHandle"/> to a transaction manager that releases its handle at disposal using NTClose.</summary>
	[AutoSafeHandle(null, null, typeof(SafeNtHandle))]
	public partial class SafeTransactionManagerHandle { }

	/*
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
	RtlAppendStringToString
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
	RtlCompressBuffer
	RtlCopyLuid
	RtlCopyMemoryNonTemporal
	RtlCopySid
	RtlCopyString
	RtlCreateAcl
	RtlCreateHeap
	RtlCreateRegistryKey
	RtlCreateSecurityDescriptor
	RtlCreateSystemVolumeInformationFolder
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
	RtlDrainNonVolatileFlush
	RtlEnumerateGenericTable
	RtlEnumerateGenericTableAvl
	RtlEnumerateGenericTableLikeADirectory
	RtlEnumerateGenericTableWithoutSplaying
	RtlEnumerateGenericTableWithoutSplayingAvl
	RtlEqualPrefixSid
	RtlEqualSid
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
	RtlInsertElementGenericTable
	RtlInsertElementGenericTableAvl
	RtlInsertElementGenericTableFullAvl
	RtlInstallFunctionTableCallback
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
	RtlOemToUnicodeN
	RtlPcToFileHeader
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
	RtlUnicodeToCustomCPN
	RtlUnicodeToMultiByteN
	RtlUnicodeToMultiByteSize
	RtlUnicodeToOemN
	RtlUnicodeToUTF8N
	RtlUniform
	RtlUnwind
	RtlUpcaseUnicodeChar
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