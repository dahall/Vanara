using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using Vanara.Extensions;
using Vanara.InteropServices;
using FILETIME = System.Runtime.InteropServices.ComTypes.FILETIME;

namespace Vanara.PInvoke
{
	public static partial class Kernel32
	{
		/// <summary>Value indicating that there are no thread local storage indexes to allocate.</summary>
		public const uint TLS_OUT_OF_INDEXES = 0xFFFFFFFF;

		/// <summary>The maximum processors.</summary>
		public static readonly uint MAXIMUM_PROCESSORS = Is64bitOS() ? 64U : 32U;

		/// <summary>
		/// An application-defined completion routine. Specify this address when calling the QueueUserAPC function. The PAPCFUNC type defines
		/// a pointer to this callback function.
		/// </summary>
		/// <param name="dwParam">The data passed to the function using the dwData parameter of the QueueUserAPC function.</param>
		[UnmanagedFunctionPointer(CallingConvention.StdCall)]
		public delegate void PAPCFUNC(IntPtr dwParam);

		/// <summary>Represents the type of information in the <c>SYSTEM_CPU_SET_INFORMATION</c> structure.</summary>
		// typedef enum _CPU_SET_INFORMATION_TYPE { CpuSetInformation} CPU_SET_INFORMATION_TYPE, *PCPU_SET_INFORMATION_TYPE; https://msdn.microsoft.com/en-us/library/windows/desktop/mt186423(v=vs.85).aspx
		[PInvokeData("Processthreadapi.h", MSDNShortId = "mt186423")]
		public enum CPU_SET_INFORMATION_TYPE
		{
			/// <summary>The structure contains CPU Set information.</summary>
			CpuSetInformation
		}

		/// <summary>
		/// The following process creation flags are used by the <c>CreateProcess</c>, <c>CreateProcessAsUser</c>,
		/// <c>CreateProcessWithLogonW</c>, and <c>CreateProcessWithTokenW</c> functions. They can be specified in any combination, except as noted.
		/// </summary>
		// https://msdn.microsoft.com/en-us/library/windows/desktop/ms684863(v=vs.85).aspx
		[PInvokeData("WinBase.h", MSDNShortId = "ms684863")]
		[Flags]
		public enum CREATE_PROCESS : uint
		{
			/// <summary>
			/// The child processes of a process associated with a job are not associated with the job. If the calling process is not
			/// associated with a job, this constant has no effect. If the calling process is associated with a job, the job must set the
			/// JOB_OBJECT_LIMIT_BREAKAWAY_OK limit.
			/// </summary>
			CREATE_BREAKAWAY_FROM_JOB = 0x01000000,

			/// <summary>
			/// The new process does not inherit the error mode of the calling process. Instead, the new process gets the default error mode.
			/// This feature is particularly useful for multithreaded shell applications that run with hard errors disabled.The default
			/// behavior is for the new process to inherit the error mode of the caller. Setting this flag changes that default behavior.
			/// </summary>
			CREATE_DEFAULT_ERROR_MODE = 0x04000000,

			/// <summary>
			/// The new process has a new console, instead of inheriting its parent's console (the default). For more information, see
			/// Creation of a Console. This flag cannot be used with DETACHED_PROCESS.
			/// </summary>
			CREATE_NEW_CONSOLE = 0x00000010,

			/// <summary>
			/// The new process is the root process of a new process group. The process group includes all processes that are descendants of
			/// this root process. The process identifier of the new process group is the same as the process identifier, which is returned
			/// in the lpProcessInformation parameter. Process groups are used by the GenerateConsoleCtrlEvent function to enable sending a
			/// CTRL+BREAK signal to a group of console processes.If this flag is specified, CTRL+C signals will be disabled for all
			/// processes within the new process group.This flag is ignored if specified with CREATE_NEW_CONSOLE.
			/// </summary>
			CREATE_NEW_PROCESS_GROUP = 0x00000200,

			/// <summary>
			/// The process is a console application that is being run without a console window. Therefore, the console handle for the
			/// application is not set.This flag is ignored if the application is not a console application, or if it is used with either
			/// CREATE_NEW_CONSOLE or DETACHED_PROCESS.
			/// </summary>
			CREATE_NO_WINDOW = 0x08000000,

			/// <summary>
			/// The process is to be run as a protected process. The system restricts access to protected processes and the threads of
			/// protected processes. For more information on how processes can interact with protected processes, see Process Security and
			/// Access Rights.To activate a protected process, the binary must have a special signature. This signature is provided by
			/// Microsoft but not currently available for non-Microsoft binaries. There are currently four protected processes: media
			/// foundation, audio engine, Windows error reporting, and system. Components that load into these binaries must also be signed.
			/// Multimedia companies can leverage the first two protected processes. For more information, see Overview of the Protected
			/// Media Path.Windows Server 2003 and Windows XP: This value is not supported.
			/// </summary>
			CREATE_PROTECTED_PROCESS = 0x00040000,

			/// <summary>
			/// Allows the caller to execute a child process that bypasses the process restrictions that would normally be applied
			/// automatically to the process.
			/// </summary>
			CREATE_PRESERVE_CODE_AUTHZ_LEVEL = 0x02000000,

			/// <summary>This flag allows secure processes, that run in the Virtualization-Based Security environment, to launch.</summary>
			CREATE_SECURE_PROCESS = 0x00400000,

			/// <summary>
			/// This flag is valid only when starting a 16-bit Windows-based application. If set, the new process runs in a private Virtual
			/// DOS Machine (VDM). By default, all 16-bit Windows-based applications run as threads in a single, shared VDM. The advantage of
			/// running separately is that a crash only terminates the single VDM; any other programs running in distinct VDMs continue to
			/// function normally. Also, 16-bit Windows-based applications that are run in separate VDMs have separate input queues. That
			/// means that if one application stops responding momentarily, applications in separate VDMs continue to receive input. The
			/// disadvantage of running separately is that it takes significantly more memory to do so. You should use this flag only if the
			/// user requests that 16-bit applications should run in their own VDM.
			/// </summary>
			CREATE_SEPARATE_WOW_VDM = 0x00000800,

			/// <summary>
			/// The flag is valid only when starting a 16-bit Windows-based application. If the DefaultSeparateVDM switch in the Windows
			/// section of WIN.INI is TRUE, this flag overrides the switch. The new process is run in the shared Virtual DOS Machine.
			/// </summary>
			CREATE_SHARED_WOW_VDM = 0x00001000,

			/// <summary>
			/// The primary thread of the new process is created in a suspended state, and does not run until the ResumeThread function is called.
			/// </summary>
			CREATE_SUSPENDED = 0x00000004,

			/// <summary>
			/// If this flag is set, the environment block pointed to by lpEnvironment uses Unicode characters. Otherwise, the environment
			/// block uses ANSI characters.
			/// </summary>
			CREATE_UNICODE_ENVIRONMENT = 0x00000400,

			/// <summary>
			/// The calling thread starts and debugs the new process. It can receive all related debug events using the WaitForDebugEvent function.
			/// </summary>
			DEBUG_ONLY_THIS_PROCESS = 0x00000002,

			/// <summary>
			/// The calling thread starts and debugs the new process and all child processes created by the new process. It can receive all
			/// related debug events using the WaitForDebugEvent function. A process that uses DEBUG_PROCESS becomes the root of a debugging
			/// chain. This continues until another process in the chain is created with DEBUG_PROCESS.If this flag is combined with
			/// DEBUG_ONLY_THIS_PROCESS, the caller debugs only the new process, not any child processes.
			/// </summary>
			DEBUG_PROCESS = 0x00000001,

			/// <summary>
			/// For console processes, the new process does not inherit its parent's console (the default). The new process can call the
			/// AllocConsole function at a later time to create a console. For more information, see Creation of a Console. This value cannot
			/// be used with CREATE_NEW_CONSOLE.
			/// </summary>
			DETACHED_PROCESS = 0x00000008,

			/// <summary>
			/// The process is created with extended startup information; the lpStartupInfo parameter specifies a STARTUPINFOEX
			/// structure.Windows Server 2003 and Windows XP: This value is not supported.
			/// </summary>
			EXTENDED_STARTUPINFO_PRESENT = 0x00080000,

			/// <summary>
			/// The process inherits its parent's affinity. If the parent process has threads in more than one processor group, the new
			/// process inherits the group-relative affinity of an arbitrary group in use by the parent.Windows Server 2008, Windows Vista,
			/// Windows Server 2003 and Windows XP: This value is not supported.
			/// </summary>
			INHERIT_PARENT_AFFINITY = 0x00010000,

			/// <summary>Process with no special scheduling needs.</summary>
			NORMAL_PRIORITY_CLASS = 0x00000020,

			/// <summary>
			/// Process whose threads run only when the system is idle and are preempted by the threads of any process running in a higher
			/// priority class. An example is a screen saver. The idle priority class is inherited by child processes.
			/// </summary>
			IDLE_PRIORITY_CLASS = 0x00000040,

			/// <summary>
			/// Process that performs time-critical tasks that must be executed immediately for it to run correctly. The threads of a
			/// high-priority class process preempt the threads of normal or idle priority class processes. An example is the Task List,
			/// which must respond quickly when called by the user, regardless of the load on the operating system. Use extreme care when
			/// using the high-priority class, because a high-priority class CPU-bound application can use nearly all available cycles.
			/// </summary>
			HIGH_PRIORITY_CLASS = 0x00000080,

			/// <summary>
			/// Process that has the highest possible priority. The threads of a real-time priority class process preempt the threads of all
			/// other processes, including operating system processes performing important tasks. For example, a real-time process that
			/// executes for more than a very brief interval can cause disk caches not to flush or cause the mouse to be unresponsive.
			/// </summary>
			REALTIME_PRIORITY_CLASS = 0x00000100,

			/// <summary>Process that has priority above IDLE_PRIORITY_CLASS but below NORMAL_PRIORITY_CLASS.</summary>
			BELOW_NORMAL_PRIORITY_CLASS = 0x00004000,

			/// <summary>Process that has priority above NORMAL_PRIORITY_CLASS but below HIGH_PRIORITY_CLASS.</summary>
			ABOVE_NORMAL_PRIORITY_CLASS = 0x00008000,

			/// <summary>Undocumented.</summary>
			CREATE_FORCEDOS = 0x00002000,

			/// <summary>Creates profiles for the user mode modeuls of the process.</summary>
			PROFILE_USER = 0x10000000,

			/// <summary>Undocumented.</summary>
			PROFILE_KERNEL = 0x20000000,

			/// <summary>Undocumented.</summary>
			PROFILE_SERVER = 0x40000000,

			/// <summary>Undocumented.</summary>
			CREATE_IGNORE_SYSTEM_DEFAULT = 0x80000000,

			/// <summary>Undocumented.</summary>
			INHERIT_CALLER_PRIORITY = 0x00020000,

			/// <summary>
			/// Begin background processing mode. The system lowers the resource scheduling priorities of the process (and its threads) so
			/// that it can perform background work without significantly affecting activity in the foreground.
			/// <para>
			/// This value can be specified only if hProcess is a handle to the current process. The function fails if the process is already
			/// in background processing mode.
			/// </para>
			/// <para>Windows Server 2003 and Windows XP: This value is not supported.</para>
			/// </summary>
			PROCESS_MODE_BACKGROUND_BEGIN = 0x00100000,

			/// <summary>
			/// End background processing mode. The system restores the resource scheduling priorities of the process (and its threads) as
			/// they were before the process entered background processing mode.
			/// <para>
			/// This value can be specified only if hProcess is a handle to the current process. The function fails if the process is not in
			/// background processing mode.
			/// </para>
			/// <para>Windows Server 2003 and Windows XP: This value is not supported.</para>
			/// </summary>
			PROCESS_MODE_BACKGROUND_END = 0x00200000,
		}

		/// <summary>Flags used by <see cref="CreateRemoteThread"/>.</summary>
		[Flags]
		public enum CREATE_THREAD_FLAGS
		{
			/// <term>The thread runs immediately after creation.</term>
			RUN_IMMEDIATELY = 0,

			/// <term>The thread is created in a suspended state, and does not run until the ResumeThread function is called.</term>
			CREATE_SUSPENDED = 4,

			/// The dwStackSize parameter specifies the initial reserve size of the stack. If this flag is not specified, dwStackSize
			/// specifies the commit size.
			STACK_SIZE_PARAM_IS_A_RESERVATION = 0x00010000,
		}

		/// <summary>The memory priority for the thread or process.</summary>
		public enum MEMORY_PRIORITY
		{
			/// <summary>Lowest memory priority.</summary>
			MEMORY_PRIORITY_LOWEST = 0,

			/// <summary>Very low memory priority.</summary>
			MEMORY_PRIORITY_VERY_LOW = 1,

			/// <summary>Low memory priority.</summary>
			MEMORY_PRIORITY_LOW = 2,

			/// <summary>Medium memory priority.</summary>
			MEMORY_PRIORITY_MEDIUM = 3,

			/// <summary>Below normal memory priority.</summary>
			MEMORY_PRIORITY_BELOW_NORMAL = 4,

			/// <summary>Normal memory priority. This is the default priority for all threads and processes on the system.</summary>
			MEMORY_PRIORITY_NORMAL = 5,
		}

		/// <summary>The affinity update mode.</summary>
		public enum PROCESS_AFFINITY_MODE
		{
			/// <summary>Dynamic update of the process affinity by the system is disabled.</summary>
			PROCESS_AFFINITY_DISABLE_AUTO_UPDATE,

			/// <summary>Dynamic update of the process affinity by the system is enabled.</summary>
			PROCESS_AFFINITY_ENABLE_AUTO_UPDATE
		}

		/// <summary>Indicates type of structure used in <c>GetProcessInformation</c> and <c>SetProcessInformation</c> calls.</summary>
		public enum PROCESS_INFORMATION_CLASS
		{
			/// <summary>Indicates that a MEMORY_PRIORITY_INFORMATION structure is specified for the operation.</summary>
			[CorrespondingType(typeof(MEMORY_PRIORITY_INFORMATION))]
			ProcessMemoryPriority,

			/// <summary>Indicates that a PROCESS_MEMORY_EXHAUSTION_INFO structure is specified for the operation.</summary>
			[CorrespondingType(typeof(PROCESS_MEMORY_EXHAUSTION_INFO))]
			ProcessMemoryExhaustionInfo,

			/// <summary>Indicates that a APP_MEMORY_INFORMATION structure is specified for the operation.</summary>
			[CorrespondingType(typeof(APP_MEMORY_INFORMATION))]
			ProcessAppMemoryInfo,

			/// <summary>Undocumented.</summary>
			ProcessInPrivateInfo,

			/// <summary>Indicates that a PROCESS_POWER_THROTTLING_STATE structure is specified for the operation.</summary>
			[CorrespondingType(typeof(PROCESS_POWER_THROTTLING_STATE))]
			ProcessPowerThrottling,

			/// <summary>Undocumented.</summary>
			ProcessReservedValue1,

			/// <summary>Undocumented.</summary>
			ProcessTelemetryCoverageInfo,

			/// <summary>Indicates that a PROCESS_PROTECTION_LEVEL_INFORMATION structure is specified for the operation.</summary>
			[CorrespondingType(typeof(PROCESS_PROTECTION_LEVEL_INFORMATION))]
			ProcessProtectionLevelInfo,
		}

		/// <summary>Represents the different memory exhaustion types.</summary>
		// typedef enum _PROCESS_MEMORY_EXHAUSTION_TYPE { PMETypeFailFastOnCommitFailure, PMETypeMax} PROCESS_MEMORY_EXHAUSTION_TYPE,
		// *PPROCESS_MEMORY_EXHAUSTION_TYPE;// https://msdn.microsoft.com/en-us/library/windows/desktop/mt767998(v=vs.85).aspx
		[PInvokeData("WinBase.h", MSDNShortId = "mt767998")]
		public enum PROCESS_MEMORY_EXHAUSTION_TYPE
		{
			/// <summary>
			/// Anytime memory management fails an allocation due to an inability to commit memory, it will cause the process to trigger a
			/// Windows Error Reporting report and then terminate immediately with <c>STATUS_COMMITMENT_LIMIT</c>. The failure cannot be
			/// caught and handled by the app.
			/// </summary>
			PMETypeFailFastOnCommitFailure,

			/// <summary>The maximum value for this enumeration. This value may change in a future version.</summary>
			PMETypeMax
		}

		/// <summary>Flags used by PROCESS_MITIGATION_ASLR_POLICY</summary>
		[Flags]
		public enum PROCESS_MITIGATION_ASLR_POLICY_FLAGS : uint
		{
			/// <summary>
			/// Thread stacks and other bottom-up allocations are subject to randomization by ASLR if this flag is set. This flag is
			/// read-only and cannot be modified after a process has been created.
			/// </summary>
			EnableBottomUpRandomization = 1 << 0,

			/// <summary>Images that have not been built with /DYNAMICBASE are forcibly relocated on load if this flag is set.</summary>
			EnableForceRelocateImages = 1 << 1,

			/// <summary>
			/// Bottom-up allocations are subject to higher degrees of entropy when randomized by ASLR if this flag is set. This flag only
			/// applies to 64-bit processes and is read-only.
			/// </summary>
			EnableHighEntropy = 1 << 2,

			/// <summary>
			/// Images that have not been built with /DYNAMICBASE and do not have relocation information will fail to load if this flag and
			/// <c>EnableForceRelocateImages</c> are set.
			/// </summary>
			DisallowStrippedImages = 1 << 3,
		}

		/// <summary>Flags used by PROCESS_MITIGATION_BINARY_SIGNATURE_POLICY.</summary>
		[Flags]
		public enum PROCESS_MITIGATION_BINARY_SIGNATURE_POLICY_FLAGS : uint
		{
			/// <summary>
			/// Set (0x1) to prevent the process from loading images that are not signed by Microsoft; otherwise leave unset (0x0).
			/// </summary>
			MicrosoftSignedOnly = 1 << 0,

			/// <summary>
			/// Set (0x1) to prevent the process from loading images that are not signed by the Windows Store; otherwise leave unset (0x0).
			/// </summary>
			StoreSignedOnly = 1 << 1,

			/// <summary>
			/// Set (0x1) to prevent the process from loading images that are not signed by Microsoft, the Windows Store and the Windows
			/// Hardware Quality Labs (WHQL); otherwise leave unset (0x0).
			/// </summary>
			MitigationOptIn = 1 << 2,

			/// <summary>Undocumented</summary>
			AuditMicrosoftSignedOnly = 1 << 3,

			/// <summary>Undocumented</summary>
			AuditStoreSignedOnly = 1 << 4,
		}

		/// <summary>Flags used by PROCESS_MITIGATION_CHILD_PROCESS_POLICY.</summary>
		[Flags]
		public enum PROCESS_MITIGATION_CHILD_PROCESS_POLICY_FLAGS : uint
		{
			/// <summary>If set, the process cannot create child processes.</summary>
			NoChildProcessCreation = 1 << 0,

			/// <summary>
			/// If set, causes audit events to be generated when child processes are created by the process. If both NoChildProcessCreation
			/// and AuditNoChildProcessCreation are set, NoChildProcessCreation takes precedence over audit setting.
			/// </summary>
			AuditNoChildProcessCreation = 1 << 1,

			/// <summary>
			/// Denies creation of child processes unless the child process is a secure process and if creation was previously blocked. It
			/// allows a process to spawn a child process on behalf of another process that cannot itself create child processes. See
			/// PROCESS_CREATION_CHILD_PROCESS_OVERRIDE in UpdateProcThreadAttribute.
			/// </summary>
			AllowSecureProcessCreation = 1 << 2,
		}

		/// <summary>Flags used by PROCESS_MITIGATION_CONTROL_FLOW_GUARD_POLICY</summary>
		[Flags]
		public enum PROCESS_MITIGATION_CONTROL_FLOW_GUARD_POLICY_FLAGS : uint
		{
			/// <summary>CFG is enabled for the process if this flag is set. This field cannot be changed via SetProcessMitigationPolicy.</summary>
			EnableControlFlowGuard = 1 << 0,

			/// <summary>
			/// If TRUE, exported functions will be treated as invalid indirect call targets by default. Exported functions only become valid
			/// indirect call targets if they are dynamically resolved via GetProcAddress. This field cannot be changed via <c>SetProcessMitigationPolicy</c>.
			/// </summary>
			EnableExportSuppression = 1 << 1,

			/// <summary>
			/// If TRUE, all DLLs that are loaded must enable CFG. If a DLL does not enable CFG then the image will fail to load. This policy
			/// can be enabled after a process has started by calling <c>SetProcessMitigationPolicy</c>. It cannot be disabled once enabled.
			/// </summary>
			StrictMode = 1 << 2,
		}

		/// <summary>Flags used by PROCESS_MITIGATION_DEP_POLICY</summary>
		[Flags]
		public enum PROCESS_MITIGATION_DEP_POLICY_FLAGS : uint
		{
			/// <summary>DEP is enabled for the process if this flag is set.</summary>
			Enable = 1 << 0,

			/// <summary>ATL thunk emulation is disabled for the process if this flag is set.</summary>
			DisableAtlThunkEmulation = 1 << 1,
		}

		/// <summary>Flags used by PROCESS_MITIGATION_DYNAMIC_CODE_POLICY</summary>
		[Flags]
		public enum PROCESS_MITIGATION_DYNAMIC_CODE_POLICY_FLAGS : uint
		{
			/// <summary>
			/// Set (0x1) to prevent the process from generating dynamic code or modifying existing executable code; otherwise leave unset (0x0).
			/// </summary>
			ProhibitDynamicCode = 1 << 0,

			/// <summary>
			/// Set (0x1) to allow threads to opt out of the restrictions on dynamic code generation by calling the
			/// <c>SetThreadInformation</c> function with the ThreadInformation parameter set to <c>ThreadDynamicCodePolicy</c>; otherwise
			/// leave unset (0x0). You should not use the <c>AllowThreadOptOut</c> and <c>ThreadDynamicCodePolicy</c> settings together to
			/// provide strong security. These settings are only intended to enable applications to adapt their code more easily for full
			/// dynamic code restrictions.
			/// </summary>
			AllowThreadOptOut = 1 << 1,

			/// <summary>
			/// Set (0x1) to allow non-AppContainer processes to modify all of the dynamic code settings for the calling process, including
			/// relaxing dynamic code restrictions after they have been set.
			/// </summary>
			AllowRemoteDowngrade = 1 << 2,

			/// <summary>Undocumented</summary>
			AuditProhibitDynamicCode = 1 << 3,
		}

		/// <summary>Flags used by PROCESS_MITIGATION_EXTENSION_POINT_DISABLE_POLICY</summary>
		[Flags]
		public enum PROCESS_MITIGATION_EXTENSION_POINT_DISABLE_POLICY_FLAGS : uint
		{
			/// <summary>Prevents legacy extension point DLLs from being loaded into the process.</summary>
			DisableExtensionPoints = 1 << 0,
		}

		/// <summary>Flags used by PROCESS_MITIGATION_FONT_DISABLE_POLICY.</summary>
		[Flags]
		public enum PROCESS_MITIGATION_FONT_DISABLE_POLICY_FLAGS : uint
		{
			/// <summary>Set (0x1) to prevent the process from loading non-system fonts; otherwise leave unset (0x0).</summary>
			DisableNonSystemFonts = 1 << 0,

			/// <summary>
			/// Set (0x1) to indicate that an Event Tracing for Windows (ETW) event should be logged when the process attempts to load a
			/// non-system font; leave unset (0x0) to indicate that an ETW event should not be logged.
			/// </summary>
			AuditNonSystemFontLoading = 1 << 1,
		}

		/// <summary>Flags used by PROCESS_MITIGATION_IMAGE_LOAD_POLICY.</summary>
		[Flags]
		public enum PROCESS_MITIGATION_IMAGE_LOAD_POLICY_FLAGS : uint
		{
			/// <summary>
			/// Set (0x1) to prevent the process from loading images from a remote device, such as a UNC share; otherwise leave unset (0x0).
			/// </summary>
			NoRemoteImages = 1 << 0,

			/// <summary>
			/// Set (0x1) to prevent the process from loading images that have a Low mandatory label, as written by low IL; otherwise leave
			/// unset (0x0).
			/// </summary>
			NoLowMandatoryLabelImages = 1 << 1,

			/// <summary>
			/// Set (0x1) to search for images to load in the System32 subfolder of the folder in which Windows is installed first, then in
			/// the application directory in the standard DLL search order; otherwise leave unset (0x0).
			/// </summary>
			PreferSystem32Images = 1 << 2,

			/// <summary>Undocumented.</summary>
			AuditNoRemoteImages = 1 << 3,

			/// <summary>Undocumented.</summary>
			AuditNoLowMandatoryLabelImages = 1 << 4,
		}

		/// <summary>Flags used by PROCESS_MITIGATION_PAYLOAD_RESTRICTION_POLICY.</summary>
		[Flags]
		public enum PROCESS_MITIGATION_PAYLOAD_RESTRICTION_POLICY_FLAGS : uint
		{
			/// <summary>If set this enables the Export Address Filter mitigation in enforcement mode for the process.</summary>
			EnableExportAddressFilter = 1 << 0,

			/// <summary>If set this enables the Export Address Filter mitigation in audit mode for the process.</summary>
			AuditExportAddressFilter = 1 << 1,

			/// <summary>If set this enables the Export Address Filter Plus mitigation in enforcement mode for the process.</summary>
			EnableExportAddressFilterPlus = 1 << 2,

			/// <summary>If set this enables the Export Address Filter mitigation in audit mode for the process.</summary>
			AuditExportAddressFilterPlus = 1 << 3,

			/// <summary>If set this enables the Import Address Filter mitigation in enforcement mode for the process.</summary>
			EnableImportAddressFilter = 1 << 4,

			/// <summary>If set this enables the Import Address Filter mitigation in enforcement mode for the process.</summary>
			AuditImportAddressFilter = 1 << 5,

			/// <summary>
			/// If set this enables the stack pivot anti-ROP (Return-oriented-programming) mitigation in enforcement mode for the process.
			/// </summary>
			EnableRopStackPivot = 1 << 6,

			/// <summary>
			/// If set this enables the stack pivot anti-ROP (Return-oriented-programming) mitigation in audit mode for the process.
			/// </summary>
			AuditRopStackPivot = 1 << 7,

			/// <summary>
			/// If set this enables the caller check anti-ROP (Return-oriented-programming) mitigation in enforcement mode for the process.
			/// Applies to 32-bit processes only.
			/// </summary>
			EnableRopCallerCheck = 1 << 8,

			/// <summary>
			/// If set this enables the caller check anti-ROP (Return-oriented-programming) mitigation in audit mode for the process. Applies
			/// to 32-bit processes only.
			/// </summary>
			AuditRopCallerCheck = 1 << 9,

			/// <summary>
			/// If set this enables the simulated execution anti-ROP (Return-oriented-programming) mitigation in enforcement mode for the
			/// process. Applies to 32-bit processes only.
			/// </summary>
			EnableRopSimExec = 1 << 10,

			/// <summary>
			/// If set this enables the simulated execution anti-ROP (Return-oriented-programming) mitigation in audit mode for the process.
			/// Applies to 32-bit processes only.
			/// </summary>
			AuditRopSimExec = 1 << 11,
		}

		/// <summary>Represents the different process mitigation policies.</summary>
		[PInvokeData("winnt.h")]
		public enum PROCESS_MITIGATION_POLICY
		{
			/// <summary>The data execution prevention (DEP) policy of the process.</summary>
			[CorrespondingType(typeof(PROCESS_MITIGATION_DEP_POLICY))]
			ProcessDEPPolicy,

			/// <summary>The Address Space Layout Randomization (ASLR) policy of the process.</summary>
			[CorrespondingType(typeof(PROCESS_MITIGATION_ASLR_POLICY))]
			ProcessASLRPolicy,

			/// <summary>
			/// The policy that turns off the ability of the process to generate dynamic code or modify existing executable code.
			/// </summary>
			[CorrespondingType(typeof(PROCESS_MITIGATION_DYNAMIC_CODE_POLICY))]
			ProcessDynamicCodePolicy,

			/// <summary>
			/// The process will receive a fatal error if it manipulates an invalid handle. Useful for preventing downstream problems in a
			/// process due to handle misuse.
			/// </summary>
			[CorrespondingType(typeof(PROCESS_MITIGATION_STRICT_HANDLE_CHECK_POLICY))]
			ProcessStrictHandleCheckPolicy,

			/// <summary>Disables the ability to use NTUser/GDI functions at the lowest layer.</summary>
			[CorrespondingType(typeof(PROCESS_MITIGATION_SYSTEM_CALL_DISABLE_POLICY))]
			ProcessSystemCallDisablePolicy,

			/// <summary>
			/// Returns the mask of valid bits for all the mitigation options on the system. An application can set many mitigation options
			/// without querying the operating system for mitigation options by combining bitwise with the mask to exclude all non-supported
			/// bits at once.
			/// </summary>
			[CorrespondingType(typeof(ulong[]))]
			ProcessMitigationOptionsMask,

			/// <summary>
			/// The policy that prevents some built-in third party extension points from being turned on, which prevents legacy extension
			/// point DLLs from being loaded into the process.
			/// </summary>
			[CorrespondingType(typeof(PROCESS_MITIGATION_EXTENSION_POINT_DISABLE_POLICY))]
			ProcessExtensionPointDisablePolicy,

			/// <summary>The Control Flow Guard (CFG) policy of the process.</summary>
			[CorrespondingType(typeof(PROCESS_MITIGATION_CONTROL_FLOW_GUARD_POLICY))]
			ProcessControlFlowGuardPolicy,

			/// <summary>
			/// The policy of a process that can restrict image loading to those images that are either signed by Microsoft, by the Windows
			/// Store, or by Microsoft, the Windows Store and the Windows Hardware Quality Labs (WHQL).
			/// </summary>
			[CorrespondingType(typeof(PROCESS_MITIGATION_BINARY_SIGNATURE_POLICY))]
			ProcessSignaturePolicy,

			/// <summary>The policy that turns off the ability of the process to load non-system fonts.</summary>
			[CorrespondingType(typeof(PROCESS_MITIGATION_FONT_DISABLE_POLICY))]
			ProcessFontDisablePolicy,

			/// <summary>
			/// The policy that turns off the ability of the process to load images from some locations, such a remote devices or files that
			/// have the low mandatory label.
			/// </summary>
			[CorrespondingType(typeof(PROCESS_MITIGATION_IMAGE_LOAD_POLICY))]
			ProcessImageLoadPolicy,
		}

		/// <summary>Flags used by PROCESS_MITIGATION_STRICT_HANDLE_CHECK_POLICY</summary>
		[Flags]
		public enum PROCESS_MITIGATION_STRICT_HANDLE_CHECK_POLICY_FLAGS : uint
		{
			/// <summary>
			/// When set to 1, an exception is raised if an invalid handle to a kernel object is used. Except as noted in the Remarks
			/// section, once exceptions for invalid handles are enabled for a process, they cannot be disabled.
			/// </summary>
			RaiseExceptionOnInvalidHandleReference = 1 << 0,

			/// <summary>When set to 1, exceptions for invalid kernel handles are permanently enabled.</summary>
			HandleExceptionsPermanentlyEnabled = 1 << 1,
		}

		/// <summary>Flags used by PROCESS_MITIGATION_SYSTEM_CALL_DISABLE_POLICY</summary>
		[Flags]
		public enum PROCESS_MITIGATION_SYSTEM_CALL_DISABLE_POLICY_FLAGS : uint
		{
			/// <summary>When set to 1, the process is not permitted to perform GUI system calls.</summary>
			DisallowWin32kSystemCalls = 1 << 0,

			/// <summary>Undocumented.</summary>
			AuditDisallowWin32kSystemCalls = 1 << 1,
		}

		/// <summary>Enables the caller to take control of the power throttling mechanism.</summary>
		[PInvokeData("processthreadsapi.h", MSDNShortId = "394B6509-849C-4B4C-9A46-AF5011A03585")]
		[Flags]
		public enum PROCESS_POWER_THROTTLING_MASK
		{
			/// <summary>Manages the execution speed of the process.</summary>
			PROCESS_POWER_THROTTLING_EXECUTION_SPEED = 1
		}

		[Flags]
		public enum ProcessAccess : uint
		{
			PROCESS_TERMINATE = 0x0001,
			PROCESS_CREATE_THREAD = 0x0002,
			PROCESS_SET_SESSIONID = 0x0004,
			PROCESS_VM_OPERATION = 0x0008,
			PROCESS_VM_READ = 0x0010,
			PROCESS_VM_WRITE = 0x0020,
			PROCESS_DUP_HANDLE = 0x0040,
			PROCESS_CREATE_PROCESS = 0x0080,
			PROCESS_SET_QUOTA = 0x0100,
			PROCESS_SET_INFORMATION = 0x0200,
			PROCESS_QUERY_INFORMATION = 0x0400,
			PROCESS_SUSPEND_RESUME = 0x0800,
			PROCESS_QUERY_LIMITED_INFORMATION = 0x1000,
			PROCESS_SET_LIMITED_INFORMATION = 0x2000,
			PROCESS_ALL_ACCESS = ACCESS_MASK.STANDARD_RIGHTS_REQUIRED | ACCESS_MASK.SYNCHRONIZE | 0xFFFF,
		}

		/// <summary>The processor feature to be tested.</summary>
		[PInvokeData("winnt.h", MSDNShortId = "ms724482")]
		public enum PROCESSOR_FEATURE
		{
			/// <summary>The alpha byte instructions are available.</summary>
			PF_ALPHA_BYTE_INSTRUCTIONS = 5,

			/// <summary>The 64-bit load/store atomic instructions are available.</summary>
			PF_ARM_64BIT_LOADSTORE_ATOMIC = 25,

			/// <summary>The divide instructions are available.</summary>
			PF_ARM_DIVIDE_INSTRUCTION_AVAILABLE = 24,

			/// <summary>The external cache is available.</summary>
			PF_ARM_EXTERNAL_CACHE_AVAILABLE = 26,

			/// <summary>The floating-point multiply-accumulate instruction is available.</summary>
			PF_ARM_FMAC_INSTRUCTIONS_AVAILABLE = 27,

			/// <summary>The neon instructions are available.</summary>
			PF_ARM_NEON_INSTRUCTIONS_AVAILABLE = 19,

			/// <summary>The v8 CRC32 instructions are available.</summary>
			PF_ARM_V8_CRC32_INSTRUCTIONS_AVAILABLE = 31,

			/// <summary>The v8 Crypto instructions are available.</summary>
			PF_ARM_V8_CRYPTO_INSTRUCTIONS_AVAILABLE = 30,

			/// <summary>The v8 instructions are available.</summary>
			PF_ARM_V8_INSTRUCTIONS_AVAILABLE = 29,

			/// <summary>The VFP/Neon: 32 x 64bit register bank is present. This flag has the same meaning as PF_ARM_VFP_EXTENDED_REGISTERS.</summary>
			PF_ARM_VFP_32_REGISTERS_AVAILABLE = 18,

			/// <summary>The 3D-Now instruction set is available.</summary>
			PF_3DNOW_INSTRUCTIONS_AVAILABLE = 7,

			/// <summary>The processor channels are enabled.</summary>
			PF_CHANNELS_ENABLED = 16,

			/// <summary>The atomic compare and exchange operation (cmpxchg) is available.</summary>
			PF_COMPARE_EXCHANGE_DOUBLE = 2,

			/// <summary>
			/// The atomic compare and exchange 128-bit operation (cmpxchg16b) is available.
			/// <para>Windows Server 2003 and Windows XP/2000: This feature is not supported.</para>
			/// </summary>
			PF_COMPARE_EXCHANGE128 = 14,

			/// <summary>
			/// The atomic compare 64 and exchange 128-bit operation (cmp8xchg16) is available.
			/// <para>Windows Server 2003 and Windows XP/2000: This feature is not supported.</para>
			/// </summary>
			PF_COMPARE64_EXCHANGE128 = 15,

			/// <summary>_fastfail() is available.</summary>
			PF_FASTFAIL_AVAILABLE = 23,

			/// <summary>
			/// Floating-point operations are emulated using a software emulator.
			/// <para>This function returns a nonzero value if floating-point operations are emulated; otherwise, it returns zero.</para>
			/// </summary>
			PF_FLOATING_POINT_EMULATED = 1,

			/// <summary>On a Pentium, a floating-point precision error can occur in rare circumstances.</summary>
			PF_FLOATING_POINT_PRECISION_ERRATA = 0,

			/// <summary>The MMX instruction set is available.</summary>
			PF_MMX_INSTRUCTIONS_AVAILABLE = 3,

			/// <summary>
			/// Data execution prevention is enabled.
			/// <para>Windows XP/2000: This feature is not supported until Windows XP with SP2 and Windows Server 2003 with SP1.</para>
			/// </summary>
			PF_NX_ENABLED = 12,

			/// <summary>
			/// The processor is PAE-enabled. For more information, see Physical Address Extension.
			/// <para>All x64 processors always return a nonzero value for this feature.</para>
			/// </summary>
			PF_PAE_ENABLED = 9,

			/// <summary>The PPC movemem 64 bit is ok.</summary>
			PF_PPC_MOVEMEM_64BIT_OK = 4,

			/// <summary>The pf rdrand instruction available</summary>
			PF_RDRAND_INSTRUCTION_AVAILABLE = 28,

			/// <summary>The RDTSC instruction is available.</summary>
			PF_RDTSC_INSTRUCTION_AVAILABLE = 8,

			/// <summary>The pf RDTSCP instruction available</summary>
			PF_RDTSCP_INSTRUCTION_AVAILABLE = 32,

			/// <summary>RDFSBASE, RDGSBASE, WRFSBASE, and WRGSBASE instructions are available.</summary>
			PF_RDWRFSGSBASE_AVAILABLE = 22,

			/// <summary>Second Level Address Translation is supported by the hardware.</summary>
			PF_SECOND_LEVEL_ADDRESS_TRANSLATION = 20,

			/// <summary>The pf sse daz mode available</summary>
			PF_SSE_DAZ_MODE_AVAILABLE = 11,

			/// <summary>
			/// The SSE3 instruction set is available.
			/// <para>Windows Server 2003 and Windows XP/2000: This feature is not supported.</para>
			/// </summary>
			PF_SSE3_INSTRUCTIONS_AVAILABLE = 13,

			/// <summary>Virtualization is enabled in the firmware.</summary>
			PF_VIRT_FIRMWARE_ENABLED = 21,

			/// <summary>The SSE instruction set is available.</summary>
			PF_XMMI_INSTRUCTIONS_AVAILABLE = 6,

			/// <summary>
			/// The SSE2 instruction set is available.
			/// <para>Windows 2000: This feature is not supported.</para>
			/// </summary>
			PF_XMMI64_INSTRUCTIONS_AVAILABLE = 10,

			/// <summary>
			/// The processor implements the XSAVE and XRSTOR instructions.
			/// <para>
			/// Windows Server 2008, Windows Vista, Windows Server 2003 and Windows XP/2000: This feature is not supported until Windows 7
			/// and Windows Server 2008 R2.
			/// </para>
			/// </summary>
			PF_XSAVE_ENABLED = 17,
		}

		/// <summary>Process protection level.</summary>
		public enum PROTECTION_LEVEL : uint
		{
			/// <summary>For internal use only.</summary>
			PROTECTION_LEVEL_WINTCB_LIGHT = 0x00000000,

			/// <summary>For internal use only.</summary>
			PROTECTION_LEVEL_WINDOWS = 0x00000001,

			/// <summary>For internal use only.</summary>
			PROTECTION_LEVEL_WINDOWS_LIGHT = 0x00000002,

			/// <summary>For internal use only.</summary>
			PROTECTION_LEVEL_ANTIMALWARE_LIGHT = 0x00000003,

			/// <summary>For internal use only.</summary>
			PROTECTION_LEVEL_LSA_LIGHT = 0x00000004,

			/// <summary>Not implemented.</summary>
			PROTECTION_LEVEL_WINTCB = 0x00000005,

			/// <summary>Not implemented.</summary>
			PROTECTION_LEVEL_CODEGEN_LIGHT = 0x00000006,

			/// <summary>Not implemented.</summary>
			PROTECTION_LEVEL_AUTHENTICODE = 0x00000007,

			/// <summary>The process is a third party app that is using process protection.</summary>
			PROTECTION_LEVEL_PPL_APP = 0x00000008,

			/// <summary>The protection level same</summary>
			PROTECTION_LEVEL_SAME = 0xFFFFFFFF,

			/// <summary>The process is not protected.</summary>
			PROTECTION_LEVEL_NONE = 0xFFFFFFFE,
		}

		/// <summary>Value retrieved by the <see cref="GetProcessShutdownParameters"/> function.</summary>
		public enum SHUTDOWN
		{
			/// <summary>
			/// If this process takes longer than the specified timeout to shut down, do not display a retry dialog box for the user.
			/// Instead, just cause the process to directly exit.
			/// </summary>
			SHUTDOWN_NORETRY = 1
		}

		/// <summary>Flags used in the <see cref="STARTUPINFO.dwFlags"/> field.</summary>
		[PInvokeData("WinBase.h")]
		[Flags]
		public enum STARTF
		{
			/// <summary>
			/// Indicates that the cursor is in feedback mode for two seconds after CreateProcess is called. The Working in Background cursor
			/// is displayed (see the Pointers tab in the Mouse control panel utility). If during those two seconds the process makes the
			/// first GUI call, the system gives five more seconds to the process. If during those five seconds the process shows a window,
			/// the system gives five more seconds to the process to finish drawing the window.The system turns the feedback cursor off after
			/// the first call to GetMessage, regardless of whether the process is drawing.
			/// </summary>
			STARTF_FORCEONFEEDBACK = 0x00000040,

			/// <summary>
			/// Indicates that the feedback cursor is forced off while the process is starting. The Normal Select cursor is displayed.
			/// </summary>
			STARTF_FORCEOFFFEEDBACK = 0x00000080,

			/// <summary>
			/// Indicates that any windows created by the process cannot be pinned on the taskbar.This flag must be combined with STARTF_TITLEISAPPID.
			/// </summary>
			STARTF_PREVENTPINNING = 0x00002000,

			/// <summary>
			/// Indicates that the process should be run in full-screen mode, rather than in windowed mode. This flag is only valid for
			/// console applications running on an x86 computer.
			/// </summary>
			STARTF_RUNFULLSCREEN = 0x00000020,

			/// <summary>
			/// The lpTitle member contains an AppUserModelID. This identifier controls how the taskbar and Start menu present the
			/// application, and enables it to be associated with the correct shortcuts and Jump Lists. Generally, applications will use the
			/// SetCurrentProcessExplicitAppUserModelID and GetCurrentProcessExplicitAppUserModelID functions instead of setting this flag.
			/// For more information, see Application User Model IDs.If STARTF_PREVENTPINNING is used, application windows cannot be pinned
			/// on the taskbar. The use of any AppUserModelID-related window properties by the application overrides this setting for that
			/// window only.This flag cannot be used with STARTF_TITLEISLINKNAME.
			/// </summary>
			STARTF_TITLEISAPPID = 0x00001000,

			/// <summary>
			/// The lpTitle member contains the path of the shortcut file (.lnk) that the user invoked to start this process. This is
			/// typically set by the shell when a .lnk file pointing to the launched application is invoked. Most applications will not need
			/// to set this value.This flag cannot be used with STARTF_TITLEISAPPID.
			/// </summary>
			STARTF_TITLEISLINKNAME = 0x00000800,

			/// <summary>The command line came from an untrusted source. For more information, see Remarks.</summary>
			STARTF_UNTRUSTEDSOURCE = 0x00008000,

			/// <summary>The dwXCountChars and dwYCountChars members contain additional information.</summary>
			STARTF_USECOUNTCHARS = 0x00000008,

			/// <summary>The dwFillAttribute member contains additional information.</summary>
			STARTF_USEFILLATTRIBUTE = 0x00000010,

			/// <summary>The hStdInput member contains additional information. This flag cannot be used with STARTF_USESTDHANDLES.</summary>
			STARTF_USEHOTKEY = 0x00000200,

			/// <summary>The dwX and dwY members contain additional information.</summary>
			STARTF_USEPOSITION = 0x00000004,

			/// <summary>The wShowWindow member contains additional information.</summary>
			STARTF_USESHOWWINDOW = 0x00000001,

			/// <summary>The dwXSize and dwYSize members contain additional information.</summary>
			STARTF_USESIZE = 0x00000002,

			/// <summary>
			/// The hStdInput, hStdOutput, and hStdError members contain additional information. If this flag is specified when calling one
			/// of the process creation functions, the handles must be inheritable and the function's bInheritHandles parameter must be set
			/// to TRUE. For more information, see Handle Inheritance.If this flag is specified when calling the GetStartupInfo function,
			/// these members are either the handle value specified during process creation or INVALID_HANDLE_VALUE.Handles must be closed
			/// with CloseHandle when they are no longer needed.This flag cannot be used with STARTF_USEHOTKEY.
			/// </summary>
			STARTF_USESTDHANDLES = 0x00000100,
		}

		/// <summary>Used by the <see cref="SYSTEM_CPU_SET_INFORMATION"/> structure.</summary>
		[Flags]
		public enum SYSTEM_CPU_SET_FLAGS : byte
		{
			/// <summary>
			/// If set, the home processor of this CPU Set is parked. If the CPU Set is on a parked processor, threads assigned to that set
			/// may be reassigned to other processors that are selected by the Process Default sets or the Thread Selected sets. If all such
			/// processors are parked, the threads are reassigned to other available processors on the system.
			/// </summary>
			SYSTEM_CPU_SET_INFORMATION_PARKED = 0x1,

			/// <summary>
			/// If set, the specified CPU Set is not available for general system use, but instead is allocated for exclusive use of some
			/// processes. If a non-NULL Process argument is specified in a call to GetSystemCpuSetInformation, it is possible to determine
			/// if the processor is allocated for use with that process.
			/// </summary>
			SYSTEM_CPU_SET_INFORMATION_ALLOCATED = 0x2,

			/// <summary>
			/// This is set if the CPU Set is allocated for the exclusive use of some subset of the system processes and if it is allocated
			/// for the use of the process passed into GetSystemCpuSetInformation.
			/// </summary>
			SYSTEM_CPU_SET_INFORMATION_ALLOCATED_TO_TARGET_PROCESS = 0x4,

			/// <summary>
			/// This is set of the CPU Set is on a processor that is suitable for low-latency realtime processing. The system takes steps to
			/// ensure that RealTime CPU Sets are unlikely to be running non-preemptible code, by moving other work like Interrupts and other
			/// application threads off of those processors.
			/// </summary>
			SYSTEM_CPU_SET_INFORMATION_REALTIME = 0x8,
		}

		/// <summary></summary>
		public enum THREAD_INFORMATION_CLASS
		{
			/// <summary>The thread memory priority</summary>
			[CorrespondingType(typeof(MEMORY_PRIORITY_INFORMATION), CorrespondingAction.GetSet)]
			ThreadMemoryPriority,

			/// <summary>The thread absolute cpu priority</summary>
			ThreadAbsoluteCpuPriority,

			/// <summary>The thread dynamic code policy</summary>
			ThreadDynamicCodePolicy,

			/// <summary>The thread power throttling</summary>
			[CorrespondingType(typeof(THREAD_POWER_THROTTLING_STATE), CorrespondingAction.Set)] // TODO: Figure out why Get doesn't work
			ThreadPowerThrottling,
		}

		/// <summary>The thread's priority level.</summary>
		public enum THREAD_PRIORITY
		{
			/// <summary>Priority 2 points below the priority class.</summary>
			THREAD_PRIORITY_LOWEST = -2,

			/// <summary>Priority 1 point below the priority class.</summary>
			THREAD_PRIORITY_BELOW_NORMAL = (THREAD_PRIORITY_LOWEST + 1),

			/// <summary>Normal priority for the priority class.</summary>
			THREAD_PRIORITY_NORMAL = 0,

			/// <summary>Priority 2 points above the priority class.</summary>
			THREAD_PRIORITY_HIGHEST = 2,

			/// <summary>Priority 1 point above the priority class.</summary>
			THREAD_PRIORITY_ABOVE_NORMAL = (THREAD_PRIORITY_HIGHEST - 1),

			/// <summary>The thread priority error return</summary>
			THREAD_PRIORITY_ERROR_RETURN = 0x7fffffff,

			/// <summary>
			/// Base-priority level of 15 for IDLE_PRIORITY_CLASS, BELOW_NORMAL_PRIORITY_CLASS, NORMAL_PRIORITY_CLASS,
			/// ABOVE_NORMAL_PRIORITY_CLASS, or HIGH_PRIORITY_CLASS processes, and a base-priority level of 31 for REALTIME_PRIORITY_CLASS processes.
			/// </summary>
			THREAD_PRIORITY_TIME_CRITICAL = 15,

			/// <summary>
			/// Base priority of 1 for IDLE_PRIORITY_CLASS, BELOW_NORMAL_PRIORITY_CLASS, NORMAL_PRIORITY_CLASS, ABOVE_NORMAL_PRIORITY_CLASS,
			/// or HIGH_PRIORITY_CLASS processes, and a base priority of 16 for REALTIME_PRIORITY_CLASS processes.
			/// </summary>
			THREAD_PRIORITY_IDLE = -15,

			/// <summary>The thread mode background begin</summary>
			THREAD_MODE_BACKGROUND_BEGIN = 0x00010000,

			/// <summary>The thread mode background end</summary>
			THREAD_MODE_BACKGROUND_END = 0x00020000,
		}

		[Flags]
		public enum ThreadAccess : uint
		{
			THREAD_TERMINATE = 0x0001,
			THREAD_SUSPEND_RESUME = 0x0002,
			THREAD_GET_CONTEXT = 0x0008,
			THREAD_SET_CONTEXT = 0x0010,
			THREAD_QUERY_INFORMATION = 0x0040,
			THREAD_SET_INFORMATION = 0x0020,
			THREAD_SET_THREAD_TOKEN = 0x0080,
			THREAD_IMPERSONATE = 0x0100,
			THREAD_DIRECT_IMPERSONATION = 0x0200,
			THREAD_SET_LIMITED_INFORMATION = 0x0400,
			THREAD_QUERY_LIMITED_INFORMATION = 0x0800,
			THREAD_RESUME = 0x1000,
			THREAD_ALL_ACCESS = ACCESS_MASK.STANDARD_RIGHTS_REQUIRED | ACCESS_MASK.SYNCHRONIZE | 0xFFFF
		}

		/// <summary>
		/// <para>Creates a new process and its primary thread. The new process runs in the security context of the calling process.</para>
		/// <para>
		/// If the calling process is impersonating another user, the new process uses the token for the calling process, not the
		/// impersonation token. To run the new process in the security context of the user represented by the impersonation token, use the
		/// <c>CreateProcessAsUser</c> or <c>CreateProcessWithLogonW</c> function.
		/// </para>
		/// </summary>
		/// <param name="lpApplicationName">
		/// <para>
		/// The name of the module to be executed. This module can be a Windows-based application. It can be some other type of module (for
		/// example, MS-DOS or OS/2) if the appropriate subsystem is available on the local computer.
		/// </para>
		/// <para>
		/// The string can specify the full path and file name of the module to execute or it can specify a partial name. In the case of a
		/// partial name, the function uses the current drive and current directory to complete the specification. The function will not use
		/// the search path. This parameter must include the file name extension; no default extension is assumed.
		/// </para>
		/// <para>
		/// The lpApplicationName parameter can be <c>NULL</c>. In that case, the module name must be the first white space–delimited token
		/// in the lpCommandLine string. If you are using a long file name that contains a space, use quoted strings to indicate where the
		/// file name ends and the arguments begin; otherwise, the file name is ambiguous. For example, consider the string "c:\program
		/// files\sub dir\program name". This string can be interpreted in a number of ways. The system tries to interpret the possibilities
		/// in the following order:
		/// </para>
		/// <para>
		/// If the executable module is a 16-bit application, lpApplicationName should be <c>NULL</c>, and the string pointed to by
		/// lpCommandLine should specify the executable module as well as its arguments.
		/// </para>
		/// <para>
		/// To run a batch file, you must start the command interpreter; set lpApplicationName to cmd.exe and set lpCommandLine to the
		/// following arguments: /c plus the name of the batch file.
		/// </para>
		/// </param>
		/// <param name="lpCommandLine">
		/// <para>
		/// The command line to be executed. The maximum length of this string is 32,768 characters, including the Unicode terminating null
		/// character. If lpApplicationName is <c>NULL</c>, the module name portion of lpCommandLine is limited to <c>MAX_PATH</c> characters.
		/// </para>
		/// <para>
		/// The Unicode version of this function, <c>CreateProcessW</c>, can modify the contents of this string. Therefore, this parameter
		/// cannot be a pointer to read-only memory (such as a <c>const</c> variable or a literal string). If this parameter is a constant
		/// string, the function may cause an access violation.
		/// </para>
		/// <para>
		/// The lpCommandLine parameter can be NULL. In that case, the function uses the string pointed to by lpApplicationName as the
		/// command line.
		/// </para>
		/// <para>
		/// If both lpApplicationName and lpCommandLine are non- <c>NULL</c>, the null-terminated string pointed to by lpApplicationName
		/// specifies the module to execute, and the null-terminated string pointed to by lpCommandLine specifies the command line. The new
		/// process can use <c>GetCommandLine</c> to retrieve the entire command line. Console processes written in C can use the argc and
		/// argv arguments to parse the command line. Because argv[0] is the module name, C programmers generally repeat the module name as
		/// the first token in the command line.
		/// </para>
		/// <para>
		/// If lpApplicationName is NULL, the first white space–delimited token of the command line specifies the module name. If you are
		/// using a long file name that contains a space, use quoted strings to indicate where the file name ends and the arguments begin
		/// (see the explanation for the lpApplicationName parameter). If the file name does not contain an extension, .exe is appended.
		/// Therefore, if the file name extension is .com, this parameter must include the .com extension. If the file name ends in a period
		/// (.) with no extension, or if the file name contains a path, .exe is not appended. If the file name does not contain a directory
		/// path, the system searches for the executable file in the following sequence:
		/// </para>
		/// <para>
		/// The system adds a terminating null character to the command-line string to separate the file name from the arguments. This
		/// divides the original string into two strings for internal processing.
		/// </para>
		/// </param>
		/// <param name="lpProcessAttributes">
		/// <para>
		/// A pointer to a <c>SECURITY_ATTRIBUTES</c> structure that determines whether the returned handle to the new process object can be
		/// inherited by child processes. If lpProcessAttributes is <c>NULL</c>, the handle cannot be inherited.
		/// </para>
		/// <para>
		/// The <c>lpSecurityDescriptor</c> member of the structure specifies a security descriptor for the new process. If
		/// lpProcessAttributes is NULL or <c>lpSecurityDescriptor</c> is <c>NULL</c>, the process gets a default security descriptor. The
		/// ACLs in the default security descriptor for a process come from the primary token of the creator.
		/// </para>
		/// <para>
		/// <c>Windows XP:</c> The ACLs in the default security descriptor for a process come from the primary or impersonation token of the
		/// creator. This behavior changed with Windows XP with SP2 and Windows Server 2003.
		/// </para>
		/// </param>
		/// <param name="lpThreadAttributes">
		/// <para>
		/// A pointer to a <c>SECURITY_ATTRIBUTES</c> structure that determines whether the returned handle to the new thread object can be
		/// inherited by child processes. If lpThreadAttributes is NULL, the handle cannot be inherited.
		/// </para>
		/// <para>
		/// The <c>lpSecurityDescriptor</c> member of the structure specifies a security descriptor for the main thread. If
		/// lpThreadAttributes is NULL or <c>lpSecurityDescriptor</c> is NULL, the thread gets a default security descriptor. The ACLs in the
		/// default security descriptor for a thread come from the process token.
		/// </para>
		/// <para>
		/// <c>Windows XP:</c> The ACLs in the default security descriptor for a thread come from the primary or impersonation token of the
		/// creator. This behavior changed with Windows XP with SP2 and Windows Server 2003.
		/// </para>
		/// </param>
		/// <param name="bInheritHandles">
		/// <para>
		/// If this parameter is TRUE, each inheritable handle in the calling process is inherited by the new process. If the parameter is
		/// FALSE, the handles are not inherited. Note that inherited handles have the same value and access rights as the original handles.
		/// </para>
		/// <para>
		/// <c>Terminal Services:</c> You cannot inherit handles across sessions. Additionally, if this parameter is TRUE, you must create
		/// the process in the same session as the caller.
		/// </para>
		/// <para>
		/// <c>Protected Process Light (PPL) processes:</c> The generic handle inheritance is blocked when a PPL process creates a non-PPL
		/// process since PROCESS_DUP_HANDLE is not allowed from a non-PPL process to a PPL process. See Process Security and Access Rights
		/// </para>
		/// </param>
		/// <param name="dwCreationFlags">
		/// <para>
		/// The flags that control the priority class and the creation of the process. For a list of values, see Process Creation Flags.
		/// </para>
		/// <para>
		/// This parameter also controls the new process's priority class, which is used to determine the scheduling priorities of the
		/// process's threads. For a list of values, see <c>GetPriorityClass</c>. If none of the priority class flags is specified, the
		/// priority class defaults to <c>NORMAL_PRIORITY_CLASS</c> unless the priority class of the creating process is
		/// <c>IDLE_PRIORITY_CLASS</c> or <c>BELOW_NORMAL_PRIORITY_CLASS</c>. In this case, the child process receives the default priority
		/// class of the calling process.
		/// </para>
		/// </param>
		/// <param name="lpEnvironment">
		/// <para>
		/// An array of the environment items for the new process. If this parameter is <c>NULL</c>, the new process uses the environment of
		/// the calling process.
		/// </para>
		/// <para>An environment item is in the following form:</para>
		/// <para>name=value\0</para>
		/// <para>Because the equal sign is used as a separator, it must not be used in the name of an environment variable.</para>
		/// <para>
		/// An environment block can contain either Unicode or ANSI characters. If the environment block pointed to by lpEnvironment contains
		/// Unicode characters, be sure that dwCreationFlags includes <c>CREATE_UNICODE_ENVIRONMENT</c>. If this parameter is <c>NULL</c> and
		/// the environment block of the parent process contains Unicode characters, you must also ensure that dwCreationFlags includes <c>CREATE_UNICODE_ENVIRONMENT</c>.
		/// </para>
		/// <para>
		/// The ANSI version of this function, <c>CreateProcessA</c> fails if the total size of the environment block for the process exceeds
		/// 32,767 characters.
		/// </para>
		/// </param>
		/// <param name="lpCurrentDirectory">
		/// <para>The full path to the current directory for the process. The string can also specify a UNC path.</para>
		/// <para>
		/// If this parameter is <c>NULL</c>, the new process will have the same current drive and directory as the calling process. (This
		/// feature is provided primarily for shells that need to start an application and specify its initial drive and working directory.)
		/// </para>
		/// </param>
		/// <param name="lpStartupInfo">
		/// <para>A pointer to a <c>STARTUPINFO</c> or <c>STARTUPINFOEX</c> structure.</para>
		/// <para>
		/// To set extended attributes, use a <c>STARTUPINFOEX</c> structure and specify EXTENDED_STARTUPINFO_PRESENT in the dwCreationFlags parameter.
		/// </para>
		/// <para>Handles in <c>STARTUPINFO</c> or <c>STARTUPINFOEX</c> must be closed with <c>CloseHandle</c> when they are no longer needed.</para>
		/// </param>
		/// <param name="lpProcessInformation">
		/// <para>A pointer to a <c>PROCESS_INFORMATION</c> structure that receives identification information about the new process.</para>
		/// <para>Handles in <c>PROCESS_INFORMATION</c> must be closed with <c>CloseHandle</c> when they are no longer needed.</para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is nonzero.</para>
		/// <para>If the function fails, the return value is zero. To get extended error information, call <c>GetLastError</c>.</para>
		/// <para>
		/// Note that the function returns before the process has finished initialization. If a required DLL cannot be located or fails to
		/// initialize, the process is terminated. To get the termination status of a process, call <c>GetExitCodeProcess</c>.
		/// </para>
		/// </returns>
		// BOOL WINAPI CreateProcess( _In_opt_ LPCTSTR lpApplicationName, _Inout_opt_ LPTSTR lpCommandLine, _In_opt_ LPSECURITY_ATTRIBUTES
		// lpProcessAttributes, _In_opt_ LPSECURITY_ATTRIBUTES lpThreadAttributes, _In_ BOOL bInheritHandles, _In_ DWORD dwCreationFlags,
		// _In_opt_ LPVOID lpEnvironment, _In_opt_ LPCTSTR lpCurrentDirectory, _In_ LPSTARTUPINFO lpStartupInfo, _Out_ LPPROCESS_INFORMATION
		// lpProcessInformation); https://msdn.microsoft.com/en-us/library/windows/desktop/ms682425(v=vs.85).aspx
		[PInvokeData("WinBase.h", MSDNShortId = "ms682425")]
		public static bool CreateProcess([Optional] string lpApplicationName, [Optional] StringBuilder lpCommandLine, [In, Optional] SECURITY_ATTRIBUTES lpProcessAttributes,
			[In, Optional] SECURITY_ATTRIBUTES lpThreadAttributes, [Optional] bool bInheritHandles, [Optional] CREATE_PROCESS dwCreationFlags, [In, Optional] string[] lpEnvironment,
			[Optional] string lpCurrentDirectory, in STARTUPINFO lpStartupInfo, out SafePROCESS_INFORMATION lpProcessInformation)
		{
			using (var mEnv = lpEnvironment is null ? SafeHGlobalHandle.Null : SafeHGlobalHandle.CreateFromStringList(lpEnvironment))
			{
				if (lpEnvironment != null && StringHelper.GetCharSize() == 2)
					dwCreationFlags |= CREATE_PROCESS.CREATE_UNICODE_ENVIRONMENT;
				var ret = CreateProcess(lpApplicationName, lpCommandLine, lpProcessAttributes, lpThreadAttributes, bInheritHandles, dwCreationFlags, (IntPtr)mEnv,
					lpCurrentDirectory, lpStartupInfo, out var pi);
				lpProcessInformation = ret ? new SafePROCESS_INFORMATION(pi) : null;
				return ret;
			}
		}

		/// <summary>
		/// <para>Creates a new process and its primary thread. The new process runs in the security context of the calling process.</para>
		/// <para>
		/// If the calling process is impersonating another user, the new process uses the token for the calling process, not the
		/// impersonation token. To run the new process in the security context of the user represented by the impersonation token, use the
		/// <c>CreateProcessAsUser</c> or <c>CreateProcessWithLogonW</c> function.
		/// </para>
		/// </summary>
		/// <param name="lpCommandLine">
		/// <para>
		/// The command line to be executed. The maximum length of this string is 32,768 characters, including the Unicode terminating null
		/// character. The module name portion of lpCommandLine is limited to <c>MAX_PATH</c> characters.
		/// </para>
		/// <para>
		/// The first white space–delimited token of the command line specifies the module name. If you are using a long file name that
		/// contains a space, use quoted strings to indicate where the file name ends and the arguments begin (see the explanation for the
		/// lpApplicationName parameter). If the file name does not contain an extension, .exe is appended. Therefore, if the file name
		/// extension is .com, this parameter must include the .com extension. If the file name ends in a period (.) with no extension, or if
		/// the file name contains a path, .exe is not appended. If the file name does not contain a directory path, the system searches for
		/// the executable file in the following sequence:
		/// </para>
		/// </param>
		/// <returns>A handle to the created process.</returns>
		[PInvokeData("WinBase.h", MSDNShortId = "ms682425")]
		public static SafeHPROCESS CreateProcess(string lpCommandLine)
		{
			if (CreateProcess(null, new StringBuilder(lpCommandLine ?? throw new ArgumentNullException(nameof(lpCommandLine))), null, null, false, 0, IntPtr.Zero, null, STARTUPINFO.Default, out var pi))
			{
				CloseHandle((IntPtr)pi.hThread);
				return new SafeHPROCESS(pi.hProcess);
			}
			return SafeHPROCESS.Null;
		}

		/// <summary>
		/// <para>Creates a new process and its primary thread. The new process runs in the security context of the calling process.</para>
		/// <para>
		/// If the calling process is impersonating another user, the new process uses the token for the calling process, not the
		/// impersonation token. To run the new process in the security context of the user represented by the impersonation token, use the
		/// <c>CreateProcessAsUser</c> or <c>CreateProcessWithLogonW</c> function.
		/// </para>
		/// </summary>
		/// <param name="lpApplicationName">
		/// <para>
		/// The name of the module to be executed. This module can be a Windows-based application. It can be some other type of module (for
		/// example, MS-DOS or OS/2) if the appropriate subsystem is available on the local computer.
		/// </para>
		/// <para>
		/// The string can specify the full path and file name of the module to execute or it can specify a partial name. In the case of a
		/// partial name, the function uses the current drive and current directory to complete the specification. The function will not use
		/// the search path. This parameter must include the file name extension; no default extension is assumed.
		/// </para>
		/// <para>
		/// The lpApplicationName parameter can be <c>NULL</c>. In that case, the module name must be the first white space–delimited token
		/// in the lpCommandLine string. If you are using a long file name that contains a space, use quoted strings to indicate where the
		/// file name ends and the arguments begin; otherwise, the file name is ambiguous. For example, consider the string "c:\program
		/// files\sub dir\program name". This string can be interpreted in a number of ways. The system tries to interpret the possibilities
		/// in the following order:
		/// </para>
		/// <para>
		/// If the executable module is a 16-bit application, lpApplicationName should be <c>NULL</c>, and the string pointed to by
		/// lpCommandLine should specify the executable module as well as its arguments.
		/// </para>
		/// <para>
		/// To run a batch file, you must start the command interpreter; set lpApplicationName to cmd.exe and set lpCommandLine to the
		/// following arguments: /c plus the name of the batch file.
		/// </para>
		/// </param>
		/// <param name="lpCommandLine">
		/// <para>
		/// The command line to be executed. The maximum length of this string is 32,768 characters, including the Unicode terminating null
		/// character. If lpApplicationName is <c>NULL</c>, the module name portion of lpCommandLine is limited to <c>MAX_PATH</c> characters.
		/// </para>
		/// <para>
		/// The Unicode version of this function, <c>CreateProcessW</c>, can modify the contents of this string. Therefore, this parameter
		/// cannot be a pointer to read-only memory (such as a <c>const</c> variable or a literal string). If this parameter is a constant
		/// string, the function may cause an access violation.
		/// </para>
		/// <para>
		/// The lpCommandLine parameter can be NULL. In that case, the function uses the string pointed to by lpApplicationName as the
		/// command line.
		/// </para>
		/// <para>
		/// If both lpApplicationName and lpCommandLine are non- <c>NULL</c>, the null-terminated string pointed to by lpApplicationName
		/// specifies the module to execute, and the null-terminated string pointed to by lpCommandLine specifies the command line. The new
		/// process can use <c>GetCommandLine</c> to retrieve the entire command line. Console processes written in C can use the argc and
		/// argv arguments to parse the command line. Because argv[0] is the module name, C programmers generally repeat the module name as
		/// the first token in the command line.
		/// </para>
		/// <para>
		/// If lpApplicationName is NULL, the first white space–delimited token of the command line specifies the module name. If you are
		/// using a long file name that contains a space, use quoted strings to indicate where the file name ends and the arguments begin
		/// (see the explanation for the lpApplicationName parameter). If the file name does not contain an extension, .exe is appended.
		/// Therefore, if the file name extension is .com, this parameter must include the .com extension. If the file name ends in a period
		/// (.) with no extension, or if the file name contains a path, .exe is not appended. If the file name does not contain a directory
		/// path, the system searches for the executable file in the following sequence:
		/// </para>
		/// <para>
		/// The system adds a terminating null character to the command-line string to separate the file name from the arguments. This
		/// divides the original string into two strings for internal processing.
		/// </para>
		/// </param>
		/// <param name="lpProcessAttributes">
		/// <para>
		/// A pointer to a <c>SECURITY_ATTRIBUTES</c> structure that determines whether the returned handle to the new process object can be
		/// inherited by child processes. If lpProcessAttributes is <c>NULL</c>, the handle cannot be inherited.
		/// </para>
		/// <para>
		/// The <c>lpSecurityDescriptor</c> member of the structure specifies a security descriptor for the new process. If
		/// lpProcessAttributes is NULL or <c>lpSecurityDescriptor</c> is <c>NULL</c>, the process gets a default security descriptor. The
		/// ACLs in the default security descriptor for a process come from the primary token of the creator.
		/// </para>
		/// <para>
		/// <c>Windows XP:</c> The ACLs in the default security descriptor for a process come from the primary or impersonation token of the
		/// creator. This behavior changed with Windows XP with SP2 and Windows Server 2003.
		/// </para>
		/// </param>
		/// <param name="lpThreadAttributes">
		/// <para>
		/// A pointer to a <c>SECURITY_ATTRIBUTES</c> structure that determines whether the returned handle to the new thread object can be
		/// inherited by child processes. If lpThreadAttributes is NULL, the handle cannot be inherited.
		/// </para>
		/// <para>
		/// The <c>lpSecurityDescriptor</c> member of the structure specifies a security descriptor for the main thread. If
		/// lpThreadAttributes is NULL or <c>lpSecurityDescriptor</c> is NULL, the thread gets a default security descriptor. The ACLs in the
		/// default security descriptor for a thread come from the process token.
		/// </para>
		/// <para>
		/// <c>Windows XP:</c> The ACLs in the default security descriptor for a thread come from the primary or impersonation token of the
		/// creator. This behavior changed with Windows XP with SP2 and Windows Server 2003.
		/// </para>
		/// </param>
		/// <param name="bInheritHandles">
		/// <para>
		/// If this parameter is TRUE, each inheritable handle in the calling process is inherited by the new process. If the parameter is
		/// FALSE, the handles are not inherited. Note that inherited handles have the same value and access rights as the original handles.
		/// </para>
		/// <para>
		/// <c>Terminal Services:</c> You cannot inherit handles across sessions. Additionally, if this parameter is TRUE, you must create
		/// the process in the same session as the caller.
		/// </para>
		/// <para>
		/// <c>Protected Process Light (PPL) processes:</c> The generic handle inheritance is blocked when a PPL process creates a non-PPL
		/// process since PROCESS_DUP_HANDLE is not allowed from a non-PPL process to a PPL process. See Process Security and Access Rights
		/// </para>
		/// </param>
		/// <param name="dwCreationFlags">
		/// <para>
		/// The flags that control the priority class and the creation of the process. For a list of values, see Process Creation Flags.
		/// </para>
		/// <para>
		/// This parameter also controls the new process's priority class, which is used to determine the scheduling priorities of the
		/// process's threads. For a list of values, see <c>GetPriorityClass</c>. If none of the priority class flags is specified, the
		/// priority class defaults to <c>NORMAL_PRIORITY_CLASS</c> unless the priority class of the creating process is
		/// <c>IDLE_PRIORITY_CLASS</c> or <c>BELOW_NORMAL_PRIORITY_CLASS</c>. In this case, the child process receives the default priority
		/// class of the calling process.
		/// </para>
		/// </param>
		/// <param name="lpEnvironment">
		/// <para>
		/// An array of the environment items for the new process. If this parameter is <c>NULL</c>, the new process uses the environment of
		/// the calling process.
		/// </para>
		/// <para>An environment item is in the following form:</para>
		/// <para>name=value\0</para>
		/// <para>Because the equal sign is used as a separator, it must not be used in the name of an environment variable.</para>
		/// <para>
		/// An environment block can contain either Unicode or ANSI characters. If the environment block pointed to by lpEnvironment contains
		/// Unicode characters, be sure that dwCreationFlags includes <c>CREATE_UNICODE_ENVIRONMENT</c>. If this parameter is <c>NULL</c> and
		/// the environment block of the parent process contains Unicode characters, you must also ensure that dwCreationFlags includes <c>CREATE_UNICODE_ENVIRONMENT</c>.
		/// </para>
		/// <para>
		/// The ANSI version of this function, <c>CreateProcessA</c> fails if the total size of the environment block for the process exceeds
		/// 32,767 characters.
		/// </para>
		/// </param>
		/// <param name="lpCurrentDirectory">
		/// <para>The full path to the current directory for the process. The string can also specify a UNC path.</para>
		/// <para>
		/// If this parameter is <c>NULL</c>, the new process will have the same current drive and directory as the calling process. (This
		/// feature is provided primarily for shells that need to start an application and specify its initial drive and working directory.)
		/// </para>
		/// </param>
		/// <param name="lpStartupInfo">
		/// <para>A pointer to a <c>STARTUPINFO</c> or <c>STARTUPINFOEX</c> structure.</para>
		/// <para>
		/// To set extended attributes, use a <c>STARTUPINFOEX</c> structure and specify EXTENDED_STARTUPINFO_PRESENT in the dwCreationFlags parameter.
		/// </para>
		/// <para>Handles in <c>STARTUPINFO</c> or <c>STARTUPINFOEX</c> must be closed with <c>CloseHandle</c> when they are no longer needed.</para>
		/// </param>
		/// <param name="lpProcessInformation">
		/// <para>A pointer to a <c>PROCESS_INFORMATION</c> structure that receives identification information about the new process.</para>
		/// <para>Handles in <c>PROCESS_INFORMATION</c> must be closed with <c>CloseHandle</c> when they are no longer needed.</para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is nonzero.</para>
		/// <para>If the function fails, the return value is zero. To get extended error information, call <c>GetLastError</c>.</para>
		/// <para>
		/// Note that the function returns before the process has finished initialization. If a required DLL cannot be located or fails to
		/// initialize, the process is terminated. To get the termination status of a process, call <c>GetExitCodeProcess</c>.
		/// </para>
		/// </returns>
		// BOOL WINAPI CreateProcess( _In_opt_ LPCTSTR lpApplicationName, _Inout_opt_ LPTSTR lpCommandLine, _In_opt_ LPSECURITY_ATTRIBUTES
		// lpProcessAttributes, _In_opt_ LPSECURITY_ATTRIBUTES lpThreadAttributes, _In_ BOOL bInheritHandles, _In_ DWORD dwCreationFlags,
		// _In_opt_ LPVOID lpEnvironment, _In_opt_ LPCTSTR lpCurrentDirectory, _In_ LPSTARTUPINFO lpStartupInfo, _Out_ LPPROCESS_INFORMATION
		// lpProcessInformation); https://msdn.microsoft.com/en-us/library/windows/desktop/ms682425(v=vs.85).aspx
		[PInvokeData("WinBase.h", MSDNShortId = "ms682425")]
		public static bool CreateProcess([Optional] string lpApplicationName, [Optional] StringBuilder lpCommandLine, [In, Optional] SECURITY_ATTRIBUTES lpProcessAttributes,
			[In, Optional] SECURITY_ATTRIBUTES lpThreadAttributes, bool bInheritHandles, [Optional] CREATE_PROCESS dwCreationFlags, [In, Optional] string[] lpEnvironment,
			[Optional] string lpCurrentDirectory, in STARTUPINFOEX lpStartupInfo, out SafePROCESS_INFORMATION lpProcessInformation)
		{
			using (var mEnv = lpEnvironment is null ? SafeHGlobalHandle.Null : SafeHGlobalHandle.CreateFromStringList(lpEnvironment))
			{
				if (lpEnvironment != null && StringHelper.GetCharSize() == 2)
					dwCreationFlags |= CREATE_PROCESS.CREATE_UNICODE_ENVIRONMENT;
				var ret = CreateProcess(lpApplicationName, lpCommandLine, lpProcessAttributes, lpThreadAttributes, bInheritHandles, dwCreationFlags, (IntPtr)mEnv,
					lpCurrentDirectory, lpStartupInfo, out var pi);
				lpProcessInformation = ret ? new SafePROCESS_INFORMATION(pi) : null;
				return ret;
			}
		}

		/// <summary>
		/// <para>Creates a thread that runs in the virtual address space of another process.</para>
		/// <para>
		/// Use the <c>CreateRemoteThreadEx</c> function to create a thread that runs in the virtual address space of another process and
		/// optionally specify extended attributes.
		/// </para>
		/// </summary>
		/// <param name="hProcess">
		/// A handle to the process in which the thread is to be created. The handle must have the <c>PROCESS_CREATE_THREAD</c>,
		/// <c>PROCESS_QUERY_INFORMATION</c>, <c>PROCESS_VM_OPERATION</c>, <c>PROCESS_VM_WRITE</c>, and <c>PROCESS_VM_READ</c> access rights,
		/// and may fail without these rights on certain platforms. For more information, see Process Security and Access Rights.
		/// </param>
		/// <param name="lpThreadAttributes">
		/// <para>
		/// A pointer to a <c>SECURITY_ATTRIBUTES</c> structure that specifies a security descriptor for the new thread and determines
		/// whether child processes can inherit the returned handle. If lpThreadAttributes is NULL, the thread gets a default security
		/// descriptor and the handle cannot be inherited. The access control lists (ACL) in the default security descriptor for a thread
		/// come from the primary token of the creator.
		/// </para>
		/// <para>
		/// <c>Windows XP:</c> The ACLs in the default security descriptor for a thread come from the primary or impersonation token of the
		/// creator. This behavior changed with Windows XP with SP2 and Windows Server 2003.
		/// </para>
		/// </param>
		/// <param name="dwStackSize">
		/// The initial size of the stack, in bytes. The system rounds this value to the nearest page. If this parameter is 0 (zero), the new
		/// thread uses the default size for the executable. For more information, see Thread Stack Size.
		/// </param>
		/// <param name="lpStartAddress">
		/// A pointer to the application-defined function of type <c>LPTHREAD_START_ROUTINE</c> to be executed by the thread and represents
		/// the starting address of the thread in the remote process. The function must exist in the remote process. For more information,
		/// see <c>ThreadProc</c>.
		/// </param>
		/// <param name="lpParameter">A pointer to a variable to be passed to the thread function.</param>
		/// <param name="dwCreationFlags">
		/// <para>The flags that control the creation of the thread.</para>
		/// <para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>0</term>
		/// <term>The thread runs immediately after creation.</term>
		/// </item>
		/// <item>
		/// <term>CREATE_SUSPENDED0x00000004</term>
		/// <term>The thread is created in a suspended state, and does not run until the ResumeThread function is called.</term>
		/// </item>
		/// <item>
		/// <term>STACK_SIZE_PARAM_IS_A_RESERVATION0x00010000</term>
		/// <term>
		/// The dwStackSize parameter specifies the initial reserve size of the stack. If this flag is not specified, dwStackSize specifies
		/// the commit size.
		/// </term>
		/// </item>
		/// </list>
		/// </para>
		/// </param>
		/// <param name="lpThreadId">
		/// <para>A pointer to a variable that receives the thread identifier.</para>
		/// <para>If this parameter is <c>NULL</c>, the thread identifier is not returned.</para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is a handle to the new thread.</para>
		/// <para>If the function fails, the return value is <c>NULL</c>. To get extended error information, call <c>GetLastError</c>.</para>
		/// <para>
		/// Note that <c>CreateRemoteThread</c> may succeed even if lpStartAddress points to data, code, or is not accessible. If the start
		/// address is invalid when the thread runs, an exception occurs, and the thread terminates. Thread termination due to a invalid
		/// start address is handled as an error exit for the thread's process. This behavior is similar to the asynchronous nature of
		/// <c>CreateProcess</c>, where the process is created even if it refers to invalid or missing dynamic-link libraries (DLL).
		/// </para>
		/// </returns>
		// HANDLE WINAPI CreateRemoteThread( _In_ HANDLE hProcess, _In_ LPSECURITY_ATTRIBUTES lpThreadAttributes, _In_ SIZE_T dwStackSize,
		// _In_ LPTHREAD_START_ROUTINE lpStartAddress, _In_ LPVOID lpParameter, _In_ DWORD dwCreationFlags, _Out_ LPDWORD lpThreadId); https://msdn.microsoft.com/en-us/library/windows/desktop/ms682437(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("WinBase.h", MSDNShortId = "ms682437")]
		public static extern SafeHTHREAD CreateRemoteThread([In] HPROCESS hProcess, [In, Optional] SECURITY_ATTRIBUTES lpThreadAttributes, [Optional] SizeT dwStackSize,
			ThreadProc lpStartAddress, [In, Optional] IntPtr lpParameter, [Optional] CREATE_THREAD_FLAGS dwCreationFlags, out uint lpThreadId);

		/// <summary>
		/// <para>Creates a thread that runs in the virtual address space of another process.</para>
		/// <para>
		/// Use the <c>CreateRemoteThreadEx</c> function to create a thread that runs in the virtual address space of another process and
		/// optionally specify extended attributes.
		/// </para>
		/// </summary>
		/// <param name="hProcess">
		/// A handle to the process in which the thread is to be created. The handle must have the <c>PROCESS_CREATE_THREAD</c>,
		/// <c>PROCESS_QUERY_INFORMATION</c>, <c>PROCESS_VM_OPERATION</c>, <c>PROCESS_VM_WRITE</c>, and <c>PROCESS_VM_READ</c> access rights,
		/// and may fail without these rights on certain platforms. For more information, see Process Security and Access Rights.
		/// </param>
		/// <param name="lpThreadAttributes">
		/// <para>
		/// A pointer to a <c>SECURITY_ATTRIBUTES</c> structure that specifies a security descriptor for the new thread and determines
		/// whether child processes can inherit the returned handle. If lpThreadAttributes is NULL, the thread gets a default security
		/// descriptor and the handle cannot be inherited. The access control lists (ACL) in the default security descriptor for a thread
		/// come from the primary token of the creator.
		/// </para>
		/// <para>
		/// <c>Windows XP:</c> The ACLs in the default security descriptor for a thread come from the primary or impersonation token of the
		/// creator. This behavior changed with Windows XP with SP2 and Windows Server 2003.
		/// </para>
		/// </param>
		/// <param name="dwStackSize">
		/// The initial size of the stack, in bytes. The system rounds this value to the nearest page. If this parameter is 0 (zero), the new
		/// thread uses the default size for the executable. For more information, see Thread Stack Size.
		/// </param>
		/// <param name="lpStartAddress">
		/// A pointer to the application-defined function of type <c>LPTHREAD_START_ROUTINE</c> to be executed by the thread and represents
		/// the starting address of the thread in the remote process. The function must exist in the remote process. For more information,
		/// see <c>ThreadProc</c>.
		/// </param>
		/// <param name="lpParameter">A pointer to a variable to be passed to the thread function.</param>
		/// <param name="dwCreationFlags">
		/// <para>The flags that control the creation of the thread.</para>
		/// <para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>0</term>
		/// <term>The thread runs immediately after creation.</term>
		/// </item>
		/// <item>
		/// <term>CREATE_SUSPENDED0x00000004</term>
		/// <term>The thread is created in a suspended state, and does not run until the ResumeThread function is called.</term>
		/// </item>
		/// <item>
		/// <term>STACK_SIZE_PARAM_IS_A_RESERVATION0x00010000</term>
		/// <term>
		/// The dwStackSize parameter specifies the initial reserve size of the stack. If this flag is not specified, dwStackSize specifies
		/// the commit size.
		/// </term>
		/// </item>
		/// </list>
		/// </para>
		/// </param>
		/// <param name="lpThreadId">
		/// <para>A pointer to a variable that receives the thread identifier.</para>
		/// <para>If this parameter is <c>NULL</c>, the thread identifier is not returned.</para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is a handle to the new thread.</para>
		/// <para>If the function fails, the return value is <c>NULL</c>. To get extended error information, call <c>GetLastError</c>.</para>
		/// <para>
		/// Note that <c>CreateRemoteThread</c> may succeed even if lpStartAddress points to data, code, or is not accessible. If the start
		/// address is invalid when the thread runs, an exception occurs, and the thread terminates. Thread termination due to a invalid
		/// start address is handled as an error exit for the thread's process. This behavior is similar to the asynchronous nature of
		/// <c>CreateProcess</c>, where the process is created even if it refers to invalid or missing dynamic-link libraries (DLL).
		/// </para>
		/// </returns>
		// HANDLE WINAPI CreateRemoteThread( _In_ HANDLE hProcess, _In_ LPSECURITY_ATTRIBUTES lpThreadAttributes, _In_ SIZE_T dwStackSize,
		// _In_ LPTHREAD_START_ROUTINE lpStartAddress, _In_ LPVOID lpParameter, _In_ DWORD dwCreationFlags, _Out_ LPDWORD lpThreadId); https://msdn.microsoft.com/en-us/library/windows/desktop/ms682437(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("WinBase.h", MSDNShortId = "ms682437")]
		public static extern SafeHTHREAD CreateRemoteThread([In] HPROCESS hProcess, [In, Optional] SECURITY_ATTRIBUTES lpThreadAttributes, [Optional] SizeT dwStackSize,
			IntPtr lpStartAddress, [In, Optional] IntPtr lpParameter, [Optional] CREATE_THREAD_FLAGS dwCreationFlags, out uint lpThreadId);

		/// <summary>
		/// Creates a thread that runs in the virtual address space of another process and optionally specifies extended attributes such as
		/// processor group affinity.
		/// </summary>
		/// <param name="hProcess">
		/// A handle to the process in which the thread is to be created. The handle must have the PROCESS_CREATE_THREAD,
		/// PROCESS_QUERY_INFORMATION, PROCESS_VM_OPERATION, PROCESS_VM_WRITE, and PROCESS_VM_READ access rights. In Windows 10, version
		/// 1607, your code must obtain these access rights for the new handle. However, starting in Windows 10, version 1703, if the new
		/// handle is entitled to these access rights, the system obtains them for you. For more information, see Process Security and Access Rights.
		/// </param>
		/// <param name="lpThreadAttributes">
		/// A pointer to a <c>SECURITY_ATTRIBUTES</c> structure that specifies a security descriptor for the new thread and determines
		/// whether child processes can inherit the returned handle. If lpThreadAttributes is NULL, the thread gets a default security
		/// descriptor and the handle cannot be inherited. The access control lists (ACL) in the default security descriptor for a thread
		/// come from the primary token of the creator.
		/// </param>
		/// <param name="dwStackSize">
		/// The initial size of the stack, in bytes. The system rounds this value to the nearest page. If this parameter is 0 (zero), the new
		/// thread uses the default size for the executable. For more information, see Thread Stack Size.
		/// </param>
		/// <param name="lpStartAddress">
		/// A pointer to the application-defined function of type <c>LPTHREAD_START_ROUTINE</c> to be executed by the thread and represents
		/// the starting address of the thread in the remote process. The function must exist in the remote process. For more information,
		/// see <c>ThreadProc</c>.
		/// </param>
		/// <param name="lpParameter">
		/// A pointer to a variable to be passed to the thread function pointed to by lpStartAddress. This parameter can be NULL.
		/// </param>
		/// <param name="dwCreationFlags">
		/// <para>The flags that control the creation of the thread.</para>
		/// <para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>0</term>
		/// <term>The thread runs immediately after creation.</term>
		/// </item>
		/// <item>
		/// <term>CREATE_SUSPENDED0x00000004</term>
		/// <term>The thread is created in a suspended state and does not run until the ResumeThread function is called.</term>
		/// </item>
		/// <item>
		/// <term>STACK_SIZE_PARAM_IS_A_RESERVATION0x00010000</term>
		/// <term>
		/// The dwStackSize parameter specifies the initial reserve size of the stack. If this flag is not specified, dwStackSize specifies
		/// the commit size.
		/// </term>
		/// </item>
		/// </list>
		/// </para>
		/// </param>
		/// <param name="lpAttributeList">
		/// An attribute list that contains additional parameters for the new thread. This list is created by the
		/// <c>InitializeProcThreadAttributeList</c> function.
		/// </param>
		/// <param name="lpThreadId">
		/// <para>A pointer to a variable that receives the thread identifier.</para>
		/// <para>If this parameter is NULL, the thread identifier is not returned.</para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is a handle to the new thread.</para>
		/// <para>If the function fails, the return value is NULL. To get extended error information, call <c>GetLastError</c>.</para>
		/// </returns>
		// HANDLE CreateRemoteThreadEx( _In_ HANDLE hProcess, _In_opt_ LPSECURITY_ATTRIBUTES lpThreadAttributes, _In_ SIZE_T dwStackSize,
		// _In_ LPTHREAD_START_ROUTINE lpStartAddress, _In_opt_ LPVOID lpParameter, _In_ DWORD dwCreationFlags, _In_opt_
		// LPPROC_THREAD_ATTRIBUTE_LIST lpAttributeList, _Out_opt_ LPDWORD lpThreadId); https://msdn.microsoft.com/en-us/library/windows/desktop/dd405484(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("WinBase.h", MSDNShortId = "dd405484")]
		public static extern SafeHTHREAD CreateRemoteThreadEx([In] HPROCESS hProcess, [In, Optional] SECURITY_ATTRIBUTES lpThreadAttributes, [Optional] SizeT dwStackSize,
			ThreadProc lpStartAddress, [In, Optional] IntPtr lpParameter, [Optional] CREATE_THREAD_FLAGS dwCreationFlags, SafeProcThreadAttributeList lpAttributeList,
			out uint lpThreadId);

		/// <summary>
		/// Creates a thread that runs in the virtual address space of another process and optionally specifies extended attributes such as
		/// processor group affinity.
		/// </summary>
		/// <param name="hProcess">
		/// A handle to the process in which the thread is to be created. The handle must have the PROCESS_CREATE_THREAD,
		/// PROCESS_QUERY_INFORMATION, PROCESS_VM_OPERATION, PROCESS_VM_WRITE, and PROCESS_VM_READ access rights. In Windows 10, version
		/// 1607, your code must obtain these access rights for the new handle. However, starting in Windows 10, version 1703, if the new
		/// handle is entitled to these access rights, the system obtains them for you. For more information, see Process Security and Access Rights.
		/// </param>
		/// <param name="lpThreadAttributes">
		/// A pointer to a <c>SECURITY_ATTRIBUTES</c> structure that specifies a security descriptor for the new thread and determines
		/// whether child processes can inherit the returned handle. If lpThreadAttributes is NULL, the thread gets a default security
		/// descriptor and the handle cannot be inherited. The access control lists (ACL) in the default security descriptor for a thread
		/// come from the primary token of the creator.
		/// </param>
		/// <param name="dwStackSize">
		/// The initial size of the stack, in bytes. The system rounds this value to the nearest page. If this parameter is 0 (zero), the new
		/// thread uses the default size for the executable. For more information, see Thread Stack Size.
		/// </param>
		/// <param name="lpStartAddress">
		/// A pointer to the application-defined function of type <c>LPTHREAD_START_ROUTINE</c> to be executed by the thread and represents
		/// the starting address of the thread in the remote process. The function must exist in the remote process. For more information,
		/// see <c>ThreadProc</c>.
		/// </param>
		/// <param name="lpParameter">
		/// A pointer to a variable to be passed to the thread function pointed to by lpStartAddress. This parameter can be NULL.
		/// </param>
		/// <param name="dwCreationFlags">
		/// <para>The flags that control the creation of the thread.</para>
		/// <para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>0</term>
		/// <term>The thread runs immediately after creation.</term>
		/// </item>
		/// <item>
		/// <term>CREATE_SUSPENDED0x00000004</term>
		/// <term>The thread is created in a suspended state and does not run until the ResumeThread function is called.</term>
		/// </item>
		/// <item>
		/// <term>STACK_SIZE_PARAM_IS_A_RESERVATION0x00010000</term>
		/// <term>
		/// The dwStackSize parameter specifies the initial reserve size of the stack. If this flag is not specified, dwStackSize specifies
		/// the commit size.
		/// </term>
		/// </item>
		/// </list>
		/// </para>
		/// </param>
		/// <param name="lpAttributeList">
		/// An attribute list that contains additional parameters for the new thread. This list is created by the
		/// <c>InitializeProcThreadAttributeList</c> function.
		/// </param>
		/// <param name="lpThreadId">
		/// <para>A pointer to a variable that receives the thread identifier.</para>
		/// <para>If this parameter is NULL, the thread identifier is not returned.</para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is a handle to the new thread.</para>
		/// <para>If the function fails, the return value is NULL. To get extended error information, call <c>GetLastError</c>.</para>
		/// </returns>
		// HANDLE CreateRemoteThreadEx( _In_ HANDLE hProcess, _In_opt_ LPSECURITY_ATTRIBUTES lpThreadAttributes, _In_ SIZE_T dwStackSize,
		// _In_ LPTHREAD_START_ROUTINE lpStartAddress, _In_opt_ LPVOID lpParameter, _In_ DWORD dwCreationFlags, _In_opt_
		// LPPROC_THREAD_ATTRIBUTE_LIST lpAttributeList, _Out_opt_ LPDWORD lpThreadId); https://msdn.microsoft.com/en-us/library/windows/desktop/dd405484(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("WinBase.h", MSDNShortId = "dd405484")]
		public static extern SafeHTHREAD CreateRemoteThreadEx([In] HPROCESS hProcess, [In, Optional] SECURITY_ATTRIBUTES lpThreadAttributes, [Optional] SizeT dwStackSize,
			ThreadProc lpStartAddress, [In, Optional] IntPtr lpParameter, [Optional] CREATE_THREAD_FLAGS dwCreationFlags, [Optional] IntPtr lpAttributeList,
			out uint lpThreadId);

		/// <summary>
		/// Creates a thread that runs in the virtual address space of another process and optionally specifies extended attributes such as
		/// processor group affinity.
		/// </summary>
		/// <param name="hProcess">
		/// A handle to the process in which the thread is to be created. The handle must have the PROCESS_CREATE_THREAD,
		/// PROCESS_QUERY_INFORMATION, PROCESS_VM_OPERATION, PROCESS_VM_WRITE, and PROCESS_VM_READ access rights. In Windows 10, version
		/// 1607, your code must obtain these access rights for the new handle. However, starting in Windows 10, version 1703, if the new
		/// handle is entitled to these access rights, the system obtains them for you. For more information, see Process Security and Access Rights.
		/// </param>
		/// <param name="lpThreadAttributes">
		/// A pointer to a <c>SECURITY_ATTRIBUTES</c> structure that specifies a security descriptor for the new thread and determines
		/// whether child processes can inherit the returned handle. If lpThreadAttributes is NULL, the thread gets a default security
		/// descriptor and the handle cannot be inherited. The access control lists (ACL) in the default security descriptor for a thread
		/// come from the primary token of the creator.
		/// </param>
		/// <param name="dwStackSize">
		/// The initial size of the stack, in bytes. The system rounds this value to the nearest page. If this parameter is 0 (zero), the new
		/// thread uses the default size for the executable. For more information, see Thread Stack Size.
		/// </param>
		/// <param name="lpStartAddress">
		/// A pointer to the application-defined function of type <c>LPTHREAD_START_ROUTINE</c> to be executed by the thread and represents
		/// the starting address of the thread in the remote process. The function must exist in the remote process. For more information,
		/// see <c>ThreadProc</c>.
		/// </param>
		/// <param name="lpParameter">
		/// A pointer to a variable to be passed to the thread function pointed to by lpStartAddress. This parameter can be NULL.
		/// </param>
		/// <param name="dwCreationFlags">
		/// <para>The flags that control the creation of the thread.</para>
		/// <para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>0</term>
		/// <term>The thread runs immediately after creation.</term>
		/// </item>
		/// <item>
		/// <term>CREATE_SUSPENDED0x00000004</term>
		/// <term>The thread is created in a suspended state and does not run until the ResumeThread function is called.</term>
		/// </item>
		/// <item>
		/// <term>STACK_SIZE_PARAM_IS_A_RESERVATION0x00010000</term>
		/// <term>
		/// The dwStackSize parameter specifies the initial reserve size of the stack. If this flag is not specified, dwStackSize specifies
		/// the commit size.
		/// </term>
		/// </item>
		/// </list>
		/// </para>
		/// </param>
		/// <param name="lpAttributeList">
		/// An attribute list that contains additional parameters for the new thread. This list is created by the
		/// <c>InitializeProcThreadAttributeList</c> function.
		/// </param>
		/// <param name="lpThreadId">
		/// <para>A pointer to a variable that receives the thread identifier.</para>
		/// <para>If this parameter is NULL, the thread identifier is not returned.</para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is a handle to the new thread.</para>
		/// <para>If the function fails, the return value is NULL. To get extended error information, call <c>GetLastError</c>.</para>
		/// </returns>
		// HANDLE CreateRemoteThreadEx( _In_ HANDLE hProcess, _In_opt_ LPSECURITY_ATTRIBUTES lpThreadAttributes, _In_ SIZE_T dwStackSize,
		// _In_ LPTHREAD_START_ROUTINE lpStartAddress, _In_opt_ LPVOID lpParameter, _In_ DWORD dwCreationFlags, _In_opt_
		// LPPROC_THREAD_ATTRIBUTE_LIST lpAttributeList, _Out_opt_ LPDWORD lpThreadId); https://msdn.microsoft.com/en-us/library/windows/desktop/dd405484(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("WinBase.h", MSDNShortId = "dd405484")]
		public static extern SafeHTHREAD CreateRemoteThreadEx([In] HPROCESS hProcess, [In, Optional] SECURITY_ATTRIBUTES lpThreadAttributes, [Optional] SizeT dwStackSize,
			IntPtr lpStartAddress, [In, Optional] IntPtr lpParameter, [Optional] CREATE_THREAD_FLAGS dwCreationFlags, SafeProcThreadAttributeList lpAttributeList,
			out uint lpThreadId);

		/// <summary>
		/// Creates a thread that runs in the virtual address space of another process and optionally specifies extended attributes such as
		/// processor group affinity.
		/// </summary>
		/// <param name="hProcess">
		/// A handle to the process in which the thread is to be created. The handle must have the PROCESS_CREATE_THREAD,
		/// PROCESS_QUERY_INFORMATION, PROCESS_VM_OPERATION, PROCESS_VM_WRITE, and PROCESS_VM_READ access rights. In Windows 10, version
		/// 1607, your code must obtain these access rights for the new handle. However, starting in Windows 10, version 1703, if the new
		/// handle is entitled to these access rights, the system obtains them for you. For more information, see Process Security and Access Rights.
		/// </param>
		/// <param name="lpThreadAttributes">
		/// A pointer to a <c>SECURITY_ATTRIBUTES</c> structure that specifies a security descriptor for the new thread and determines
		/// whether child processes can inherit the returned handle. If lpThreadAttributes is NULL, the thread gets a default security
		/// descriptor and the handle cannot be inherited. The access control lists (ACL) in the default security descriptor for a thread
		/// come from the primary token of the creator.
		/// </param>
		/// <param name="dwStackSize">
		/// The initial size of the stack, in bytes. The system rounds this value to the nearest page. If this parameter is 0 (zero), the new
		/// thread uses the default size for the executable. For more information, see Thread Stack Size.
		/// </param>
		/// <param name="lpStartAddress">
		/// A pointer to the application-defined function of type <c>LPTHREAD_START_ROUTINE</c> to be executed by the thread and represents
		/// the starting address of the thread in the remote process. The function must exist in the remote process. For more information,
		/// see <c>ThreadProc</c>.
		/// </param>
		/// <param name="lpParameter">
		/// A pointer to a variable to be passed to the thread function pointed to by lpStartAddress. This parameter can be NULL.
		/// </param>
		/// <param name="dwCreationFlags">
		/// <para>The flags that control the creation of the thread.</para>
		/// <para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>0</term>
		/// <term>The thread runs immediately after creation.</term>
		/// </item>
		/// <item>
		/// <term>CREATE_SUSPENDED0x00000004</term>
		/// <term>The thread is created in a suspended state and does not run until the ResumeThread function is called.</term>
		/// </item>
		/// <item>
		/// <term>STACK_SIZE_PARAM_IS_A_RESERVATION0x00010000</term>
		/// <term>
		/// The dwStackSize parameter specifies the initial reserve size of the stack. If this flag is not specified, dwStackSize specifies
		/// the commit size.
		/// </term>
		/// </item>
		/// </list>
		/// </para>
		/// </param>
		/// <param name="lpAttributeList">
		/// An attribute list that contains additional parameters for the new thread. This list is created by the
		/// <c>InitializeProcThreadAttributeList</c> function.
		/// </param>
		/// <param name="lpThreadId">
		/// <para>A pointer to a variable that receives the thread identifier.</para>
		/// <para>If this parameter is NULL, the thread identifier is not returned.</para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is a handle to the new thread.</para>
		/// <para>If the function fails, the return value is NULL. To get extended error information, call <c>GetLastError</c>.</para>
		/// </returns>
		// HANDLE CreateRemoteThreadEx( _In_ HANDLE hProcess, _In_opt_ LPSECURITY_ATTRIBUTES lpThreadAttributes, _In_ SIZE_T dwStackSize,
		// _In_ LPTHREAD_START_ROUTINE lpStartAddress, _In_opt_ LPVOID lpParameter, _In_ DWORD dwCreationFlags, _In_opt_
		// LPPROC_THREAD_ATTRIBUTE_LIST lpAttributeList, _Out_opt_ LPDWORD lpThreadId); https://msdn.microsoft.com/en-us/library/windows/desktop/dd405484(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("WinBase.h", MSDNShortId = "dd405484")]
		public static extern SafeHTHREAD CreateRemoteThreadEx([In] HPROCESS hProcess, [In, Optional] SECURITY_ATTRIBUTES lpThreadAttributes, [Optional] SizeT dwStackSize,
			IntPtr lpStartAddress, [In, Optional] IntPtr lpParameter, [Optional] CREATE_THREAD_FLAGS dwCreationFlags, [Optional] IntPtr lpAttributeList,
			out uint lpThreadId);

		/// <summary>
		/// <para>Creates a thread to execute within the virtual address space of the calling process.</para>
		/// <para>To create a thread that runs in the virtual address space of another process, use the <c>CreateRemoteThread</c> function.</para>
		/// </summary>
		/// <param name="lpThreadAttributes">
		/// <para>
		/// A pointer to a <c>SECURITY_ATTRIBUTES</c> structure that determines whether the returned handle can be inherited by child
		/// processes. If lpThreadAttributes is NULL, the handle cannot be inherited.
		/// </para>
		/// <para>
		/// The <c>lpSecurityDescriptor</c> member of the structure specifies a security descriptor for the new thread. If lpThreadAttributes
		/// is NULL, the thread gets a default security descriptor. The ACLs in the default security descriptor for a thread come from the
		/// primary token of the creator.
		/// </para>
		/// </param>
		/// <param name="dwStackSize">
		/// The initial size of the stack, in bytes. The system rounds this value to the nearest page. If this parameter is zero, the new
		/// thread uses the default size for the executable. For more information, see Thread Stack Size.
		/// </param>
		/// <param name="lpStartAddress">
		/// A pointer to the application-defined function to be executed by the thread. This pointer represents the starting address of the
		/// thread. For more information on the thread function, see <c>ThreadProc</c>.
		/// </param>
		/// <param name="lpParameter">A pointer to a variable to be passed to the thread.</param>
		/// <param name="dwCreationFlags">
		/// <para>The flags that control the creation of the thread.</para>
		/// <para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>0</term>
		/// <term>The thread runs immediately after creation.</term>
		/// </item>
		/// <item>
		/// <term>CREATE_SUSPENDED0x00000004</term>
		/// <term>The thread is created in a suspended state, and does not run until the ResumeThread function is called.</term>
		/// </item>
		/// <item>
		/// <term>STACK_SIZE_PARAM_IS_A_RESERVATION0x00010000</term>
		/// <term>
		/// The dwStackSize parameter specifies the initial reserve size of the stack. If this flag is not specified, dwStackSize specifies
		/// the commit size.
		/// </term>
		/// </item>
		/// </list>
		/// </para>
		/// </param>
		/// <param name="lpThreadId">
		/// A pointer to a variable that receives the thread identifier. If this parameter is <c>NULL</c>, the thread identifier is not returned.
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is a handle to the new thread.</para>
		/// <para>If the function fails, the return value is <c>NULL</c>. To get extended error information, call <c>GetLastError</c>.</para>
		/// <para>
		/// Note that <c>CreateThread</c> may succeed even if lpStartAddress points to data, code, or is not accessible. If the start address
		/// is invalid when the thread runs, an exception occurs, and the thread terminates. Thread termination due to a invalid start
		/// address is handled as an error exit for the thread's process. This behavior is similar to the asynchronous nature of
		/// <c>CreateProcess</c>, where the process is created even if it refers to invalid or missing dynamic-link libraries (DLLs).
		/// </para>
		/// </returns>
		// HANDLE WINAPI CreateThread( _In_opt_ LPSECURITY_ATTRIBUTES lpThreadAttributes, _In_ SIZE_T dwStackSize, _In_
		// LPTHREAD_START_ROUTINE lpStartAddress, _In_opt_ LPVOID lpParameter, _In_ DWORD dwCreationFlags, _Out_opt_ LPDWORD lpThreadId); https://msdn.microsoft.com/en-us/library/windows/desktop/ms682453(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("WinBase.h", MSDNShortId = "ms682453")]
		public static extern SafeHTHREAD CreateThread([In, Optional] SECURITY_ATTRIBUTES lpThreadAttributes, [Optional] SizeT dwStackSize, ThreadProc lpStartAddress,
			[In, Optional] IntPtr lpParameter, [Optional] CREATE_THREAD_FLAGS dwCreationFlags, out uint lpThreadId);

		/// <summary>
		/// <para>Creates a thread to execute within the virtual address space of the calling process.</para>
		/// <para>To create a thread that runs in the virtual address space of another process, use the <c>CreateRemoteThread</c> function.</para>
		/// </summary>
		/// <param name="lpThreadAttributes">
		/// <para>
		/// A pointer to a <c>SECURITY_ATTRIBUTES</c> structure that determines whether the returned handle can be inherited by child
		/// processes. If lpThreadAttributes is NULL, the handle cannot be inherited.
		/// </para>
		/// <para>
		/// The <c>lpSecurityDescriptor</c> member of the structure specifies a security descriptor for the new thread. If lpThreadAttributes
		/// is NULL, the thread gets a default security descriptor. The ACLs in the default security descriptor for a thread come from the
		/// primary token of the creator.
		/// </para>
		/// </param>
		/// <param name="dwStackSize">
		/// The initial size of the stack, in bytes. The system rounds this value to the nearest page. If this parameter is zero, the new
		/// thread uses the default size for the executable. For more information, see Thread Stack Size.
		/// </param>
		/// <param name="lpStartAddress">
		/// A pointer to the application-defined function to be executed by the thread. This pointer represents the starting address of the
		/// thread. For more information on the thread function, see <c>ThreadProc</c>.
		/// </param>
		/// <param name="lpParameter">A pointer to a variable to be passed to the thread.</param>
		/// <param name="dwCreationFlags">
		/// <para>The flags that control the creation of the thread.</para>
		/// <para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>0</term>
		/// <term>The thread runs immediately after creation.</term>
		/// </item>
		/// <item>
		/// <term>CREATE_SUSPENDED0x00000004</term>
		/// <term>The thread is created in a suspended state, and does not run until the ResumeThread function is called.</term>
		/// </item>
		/// <item>
		/// <term>STACK_SIZE_PARAM_IS_A_RESERVATION0x00010000</term>
		/// <term>
		/// The dwStackSize parameter specifies the initial reserve size of the stack. If this flag is not specified, dwStackSize specifies
		/// the commit size.
		/// </term>
		/// </item>
		/// </list>
		/// </para>
		/// </param>
		/// <param name="lpThreadId">
		/// A pointer to a variable that receives the thread identifier. If this parameter is <c>NULL</c>, the thread identifier is not returned.
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is a handle to the new thread.</para>
		/// <para>If the function fails, the return value is <c>NULL</c>. To get extended error information, call <c>GetLastError</c>.</para>
		/// <para>
		/// Note that <c>CreateThread</c> may succeed even if lpStartAddress points to data, code, or is not accessible. If the start address
		/// is invalid when the thread runs, an exception occurs, and the thread terminates. Thread termination due to a invalid start
		/// address is handled as an error exit for the thread's process. This behavior is similar to the asynchronous nature of
		/// <c>CreateProcess</c>, where the process is created even if it refers to invalid or missing dynamic-link libraries (DLLs).
		/// </para>
		/// </returns>
		// HANDLE WINAPI CreateThread( _In_opt_ LPSECURITY_ATTRIBUTES lpThreadAttributes, _In_ SIZE_T dwStackSize, _In_
		// LPTHREAD_START_ROUTINE lpStartAddress, _In_opt_ LPVOID lpParameter, _In_ DWORD dwCreationFlags, _Out_opt_ LPDWORD lpThreadId); https://msdn.microsoft.com/en-us/library/windows/desktop/ms682453(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("WinBase.h", MSDNShortId = "ms682453")]
		public static extern unsafe SafeHTHREAD CreateThread([In, Optional] SECURITY_ATTRIBUTES lpThreadAttributes, [Optional] SizeT dwStackSize, ThreadProcUnsafe lpStartAddress,
			[In, Optional] void* lpParameter, [Optional] CREATE_THREAD_FLAGS dwCreationFlags, out uint lpThreadId);

		/// <summary>Deletes the specified list of attributes for process and thread creation.</summary>
		/// <param name="lpAttributeList">The attribute list. This list is created by the <see cref="InitializeProcThreadAttributeList"/>.</param>
		/// <returns>This function does not return a value.</returns>
		// VOID WINAPI DeleteProcThreadAttributeList( _Inout_ LPPROC_THREAD_ATTRIBUTE_LIST lpAttributeList); https://msdn.microsoft.com/en-us/library/windows/desktop/ms682559(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("WinBase.h", MSDNShortId = "ms682559")]
		public static extern void DeleteProcThreadAttributeList(IntPtr lpAttributeList);

		/// <summary>Ends the calling process and all its threads.</summary>
		/// <param name="uExitCode">The exit code for the process and all threads.</param>
		/// <returns>This function does not return a value.</returns>
		// VOID WINAPI ExitProcess( _In_ UINT uExitCode); https://msdn.microsoft.com/en-us/library/windows/desktop/ms682658(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("WinBase.h", MSDNShortId = "ms682658")]
		public static extern void ExitProcess(uint uExitCode);

		/// <summary>Ends the calling thread.</summary>
		/// <param name="dwExitCode">The exit code for the thread.</param>
		/// <returns>This function does not return a value.</returns>
		// VOID WINAPI ExitThread( _In_ DWORD dwExitCode); https://msdn.microsoft.com/en-us/library/windows/desktop/ms682659(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("WinBase.h", MSDNShortId = "ms682659")]
		public static extern void ExitThread(uint dwExitCode);

		/// <summary>Flushes the instruction cache for the specified process.</summary>
		/// <param name="hProcess">A handle to a process whose instruction cache is to be flushed.</param>
		/// <param name="lpBaseAddress">A pointer to the base of the region to be flushed. This parameter can be <c>NULL</c>.</param>
		/// <param name="dwSize">The size of the region to be flushed if the lpBaseAddress parameter is not <c>NULL</c>, in bytes.</param>
		/// <returns>
		/// <para>If the function succeeds, the return value is nonzero.</para>
		/// <para>If the function fails, the return value is zero. To get extended error information, call <c>GetLastError</c>.</para>
		/// </returns>
		// BOOL WINAPI FlushInstructionCache( _In_ HANDLE hProcess, _In_ LPCVOID lpBaseAddress, _In_ SIZE_T dwSize); https://msdn.microsoft.com/en-us/library/windows/desktop/ms679350(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("WinBase.h", MSDNShortId = "ms679350")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool FlushInstructionCache([In] HPROCESS hProcess, [In, Optional] IntPtr lpBaseAddress, [Optional] SizeT dwSize);

		/// <summary>Flushes the write queue of each processor that is running a thread of the current process.</summary>
		/// <returns>This function does not return a value.</returns>
		// VOID WINAPI FlushProcessWriteBuffers(void); https://msdn.microsoft.com/en-us/library/windows/desktop/ms683148(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("WinBase.h", MSDNShortId = "ms683148")]
		public static extern void FlushProcessWriteBuffers();

		/// <summary>Retrieves the process identifier of the calling process.</summary>
		/// <returns>The return value is the process identifier of the calling process.</returns>
		// DWORD WINAPI GetCurrentProcessId(void); https://msdn.microsoft.com/en-us/library/windows/desktop/ms683180(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("WinBase.h", MSDNShortId = "ms683180")]
		public static extern uint GetCurrentProcessId();

		/// <summary>
		/// <para>Retrieves the number of the processor the current thread was running on during the call to this function.</para>
		/// </summary>
		/// <returns>
		/// <para>The function returns the current processor number.</para>
		/// </returns>
		/// <remarks>
		/// <para>This function is used to provide information for estimating process performance.</para>
		/// <para>
		/// On systems with more than 64 logical processors, the <c>GetCurrentProcessorNumber</c> function returns the processor number
		/// within the processor group to which the logical processor is assigned. Use the GetCurrentProcessorNumberEx function to retrieve
		/// the processor group and number of the current processor.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/processthreadsapi/nf-processthreadsapi-getcurrentprocessornumber DWORD
		// GetCurrentProcessorNumber( );
		[DllImport(Lib.Kernel32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("processthreadsapi.h", MSDNShortId = "1f2bebc7-a548-409a-ab74-78a4b55c8fa7")]
		public static extern uint GetCurrentProcessorNumber();

		/// <summary>Retrieves the processor group and number of the logical processor in which the calling thread is running.</summary>
		/// <param name="ProcNumber">
		/// A pointer to a <c>PROCESSOR_NUMBER</c> structure that receives the processor group to which the logical processor is assigned and
		/// the number of the logical processor within its group.
		/// </param>
		/// <returns>
		/// If the function succeeds, the ProcNumber parameter contains the group and processor number of the processor on which the calling
		/// thread is running.
		/// </returns>
		// VOID GetCurrentProcessorNumberEx( _Out_ PPROCESSOR_NUMBER ProcNumber); https://msdn.microsoft.com/en-us/library/windows/desktop/dd405487(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("WinBase.h", MSDNShortId = "dd405487")]
		public static extern void GetCurrentProcessorNumberEx(out PROCESSOR_NUMBER ProcNumber);

		/// <summary>Retrieves a pseudo-handle that you can use as a shorthand way to refer to the access token associated with a process.</summary>
		/// <returns>A pseudo-handle that you can use as a shorthand way to refer to the access token associated with a process.</returns>
		[PInvokeData("Processthreadsapi.h", MSDNShortId = "mt643211")]
		public static HTOKEN GetCurrentProcessToken() => new IntPtr(-4);

		/// <summary>Retrieves a pseudo handle for the calling thread.</summary>
		/// <returns>The return value is a pseudo handle for the current thread.</returns>
		/// <remarks>
		/// A pseudo handle is a special constant that is interpreted as the current thread handle. The calling thread can use this handle to
		/// specify itself whenever a thread handle is required. Pseudo handles are not inherited by child processes.
		/// <para>
		/// This handle has the THREAD_ALL_ACCESS access right to the thread object. For more information, see Thread Security and Access Rights.
		/// </para>
		/// <para>
		/// Windows Server 2003 and Windows XP: This handle has the maximum access allowed by the security descriptor of the thread to the
		/// primary token of the process.
		/// </para>
		/// <para>
		/// The function cannot be used by one thread to create a handle that can be used by other threads to refer to the first thread. The
		/// handle is always interpreted as referring to the thread that is using it. A thread can create a "real" handle to itself that can
		/// be used by other threads, or inherited by other processes, by specifying the pseudo handle as the source handle in a call to the
		/// DuplicateHandle function.
		/// </para>
		/// <para>
		/// The pseudo handle need not be closed when it is no longer needed. Calling the CloseHandle function with this handle has no
		/// effect. If the pseudo handle is duplicated by DuplicateHandle, the duplicate handle must be closed.
		/// </para>
		/// <para>
		/// Do not create a thread while impersonating a security context. The call will succeed, however the newly created thread will have
		/// reduced access rights to itself when calling GetCurrentThread. The access rights granted this thread will be derived from the
		/// access rights the impersonated user has to the process. Some access rights including THREAD_SET_THREAD_TOKEN and
		/// THREAD_GET_CONTEXT may not be present, leading to unexpected failures.
		/// </para>
		/// </remarks>
		[DllImport(Lib.Kernel32, ExactSpelling = true, SetLastError = true)]
		[PInvokeData("WinBase.h", MSDNShortId = "ms683182")]
		public static extern HTHREAD GetCurrentThread();

		/// <summary>
		/// Retrieves a pseudo-handle that you can use as a shorthand way to refer to the token that is currently in effect for the thread,
		/// which is the thread token if one exists and the process token otherwise.
		/// </summary>
		/// <returns>A pseudo-handle that you can use as a shorthand way to refer to the token that is currently in effect for the thread.</returns>
		// FORCEINLINE HANDLE GetCurrentThreadEffectiveToken(void); https://msdn.microsoft.com/en-us/library/windows/desktop/mt643212(v=vs.85).aspx
		[PInvokeData("Processthreadsapi.h", MSDNShortId = "mt643212")]
		public static HTOKEN GetCurrentThreadEffectiveToken() => new IntPtr(-6);

		/// <summary>Retrieves the thread identifier of the calling thread.</summary>
		/// <returns>The return value is the thread identifier of the calling thread.</returns>
		// DWORD WINAPI GetCurrentThreadId(void); https://msdn.microsoft.com/en-us/library/windows/desktop/ms683183(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("WinBase.h", MSDNShortId = "ms683183")]
		public static extern uint GetCurrentThreadId();

		/// <summary>Retrieves the boundaries of the stack that was allocated by the system for the current thread.</summary>
		/// <param name="LowLimit">A pointer variable that receives the lower boundary of the current thread stack.</param>
		/// <param name="HighLimit">A pointer variable that receives the upper boundary of the current thread stack.</param>
		/// <returns>This function does not return a value.</returns>
		// VOID WINAPI GetCurrentThreadStackLimits( _Out_ PULONG_PTR LowLimit, _Out_ PULONG_PTR HighLimit); https://msdn.microsoft.com/en-us/library/windows/desktop/hh706789(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("Processthreadsapi.h", MSDNShortId = "hh706789")]
		public static extern void GetCurrentThreadStackLimits(out UIntPtr LowLimit, out UIntPtr HighLimit);

		/// <summary>
		/// Retrieves a pseudo-handle that you can use as a shorthand way to refer to the impersonation token that was assigned to the
		/// current thread.
		/// </summary>
		/// <returns>
		/// A pseudo-handle that you can use as a shorthand way to refer to the impersonation token that was assigned to the current thread.
		/// </returns>
		// FORCEINLINE HANDLE GetCurrentThreadEffectiveToken(void); https://msdn.microsoft.com/en-us/library/windows/desktop/mt643213(v=vs.85).aspx
		[PInvokeData("Processthreadsapi.h", MSDNShortId = "mt643213")]
		public static HTOKEN GetCurrentThreadToken() => new IntPtr(-5);

		/// <summary>Retrieves the termination status of the specified process.</summary>
		/// <param name="hProcess">
		/// <para>A handle to the process.</para>
		/// <para>
		/// The handle must have the <c>PROCESS_QUERY_INFORMATION</c> or <c>PROCESS_QUERY_LIMITED_INFORMATION</c> access right. For more
		/// information, see Process Security and Access Rights.
		/// </para>
		/// <para><c>Windows Server 2003 and Windows XP:</c> The handle must have the <c>PROCESS_QUERY_INFORMATION</c> access right.</para>
		/// </param>
		/// <param name="lpExitCode">A pointer to a variable to receive the process termination status. For more information, see Remarks.</param>
		/// <returns>
		/// <para>If the function succeeds, the return value is nonzero.</para>
		/// <para>If the function fails, the return value is zero. To get extended error information, call <c>GetLastError</c>.</para>
		/// </returns>
		// BOOL WINAPI GetExitCodeProcess( _In_ HANDLE hProcess, _Out_ LPDWORD lpExitCode); https://msdn.microsoft.com/en-us/library/windows/desktop/ms683189(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("WinBase.h", MSDNShortId = "ms683189")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool GetExitCodeProcess([In] HPROCESS hProcess, out uint lpExitCode);

		/// <summary>Retrieves the termination status of the specified thread.</summary>
		/// <param name="hThread">
		/// <para>A handle to the thread.</para>
		/// <para>
		/// The handle must have the <c>THREAD_QUERY_INFORMATION</c> or <c>THREAD_QUERY_LIMITED_INFORMATION</c> access right. For more
		/// information, see Thread Security and Access Rights.
		/// </para>
		/// <para><c>Windows Server 2003 and Windows XP:</c> The handle must have the <c>THREAD_QUERY_INFORMATION</c> access right.</para>
		/// </param>
		/// <param name="lpExitCode">A pointer to a variable to receive the thread termination status. For more information, see Remarks.</param>
		/// <returns>
		/// <para>If the function succeeds, the return value is nonzero.</para>
		/// <para>If the function fails, the return value is zero. To get extended error information, call <c>GetLastError</c>.</para>
		/// </returns>
		// BOOL WINAPI GetExitCodeThread( _In_ HANDLE hThread, _Out_ LPDWORD lpExitCode); https://msdn.microsoft.com/en-us/library/windows/desktop/ms683190(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("WinBase.h", MSDNShortId = "ms683190")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool GetExitCodeThread([In] HTHREAD hThread, out uint lpExitCode);

		/// <summary>
		/// Retrieves the priority class for the specified process. This value, together with the priority value of each thread of the
		/// process, determines each thread's base priority level.
		/// </summary>
		/// <param name="hProcess">
		/// <para>A handle to the process.</para>
		/// <para>
		/// The handle must have the <c>PROCESS_QUERY_INFORMATION</c> or <c>PROCESS_QUERY_LIMITED_INFORMATION</c> access right. For more
		/// information, see Process Security and Access Rights.
		/// </para>
		/// <para><c>Windows Server 2003 and Windows XP:</c> The handle must have the <c>PROCESS_QUERY_INFORMATION</c> access right.</para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is the priority class of the specified process.</para>
		/// <para>If the function fails, the return value is zero. To get extended error information, call <c>GetLastError</c>.</para>
		/// <para>The process's priority class is one of the following values.</para>
		/// <para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code/value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>ABOVE_NORMAL_PRIORITY_CLASS0x00008000</term>
		/// <term>Process that has priority above NORMAL_PRIORITY_CLASS but below HIGH_PRIORITY_CLASS.</term>
		/// </item>
		/// <item>
		/// <term>BELOW_NORMAL_PRIORITY_CLASS0x00004000</term>
		/// <term>Process that has priority above IDLE_PRIORITY_CLASS but below NORMAL_PRIORITY_CLASS.</term>
		/// </item>
		/// <item>
		/// <term>HIGH_PRIORITY_CLASS0x00000080</term>
		/// <term>
		/// Process that performs time-critical tasks that must be executed immediately for it to run correctly. The threads of a
		/// high-priority class process preempt the threads of normal or idle priority class processes. An example is the Task List, which
		/// must respond quickly when called by the user, regardless of the load on the operating system. Use extreme care when using the
		/// high-priority class, because a high-priority class CPU-bound application can use nearly all available cycles.
		/// </term>
		/// </item>
		/// <item>
		/// <term>IDLE_PRIORITY_CLASS0x00000040</term>
		/// <term>
		/// Process whose threads run only when the system is idle and are preempted by the threads of any process running in a higher
		/// priority class. An example is a screen saver. The idle priority class is inherited by child processes.
		/// </term>
		/// </item>
		/// <item>
		/// <term>NORMAL_PRIORITY_CLASS0x00000020</term>
		/// <term>Process with no special scheduling needs.</term>
		/// </item>
		/// <item>
		/// <term>REALTIME_PRIORITY_CLASS0x00000100</term>
		/// <term>
		/// Process that has the highest possible priority. The threads of a real-time priority class process preempt the threads of all
		/// other processes, including operating system processes performing important tasks. For example, a real-time process that executes
		/// for more than a very brief interval can cause disk caches not to flush or cause the mouse to be unresponsive.
		/// </term>
		/// </item>
		/// </list>
		/// </para>
		/// </returns>
		// DWORD WINAPI GetPriorityClass( _In_ HANDLE hProcess); https://msdn.microsoft.com/en-us/library/windows/desktop/ms683211(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("WinBase.h", MSDNShortId = "ms683211")]
		public static extern CREATE_PROCESS GetPriorityClass([In] HPROCESS hProcess);

		/// <summary>
		/// Retrieves the list of CPU Sets in the process default set that was set by <c>SetProcessDefaultCpuSets</c>. If no default CPU Sets
		/// are set for a given process, then the <c>RequiredIdCount</c> is set to 0 and the function succeeds.
		/// </summary>
		/// <param name="Process">
		/// Specifies a process handle for the process to query. This handle must have the PROCESS_QUERY_LIMITED_INFORMATION access right.
		/// The value returned by <c>GetCurrentProcess</c> can also be specified here.
		/// </param>
		/// <param name="CpuSetIds">Specifies an optional buffer to retrieve the list of CPU Set identifiers.</param>
		/// <param name="CpuSetIdCount">
		/// Specifies the capacity of the buffer specified in <c>CpuSetIds</c>. If the buffer is NULL, this must be 0.
		/// </param>
		/// <param name="RequiredIdCount">
		/// Specifies the required capacity of the buffer to hold the entire list of process default CPU Sets. On successful return, this
		/// specifies the number of IDs filled into the buffer.
		/// </param>
		/// <returns>
		/// This API returns TRUE on success. If the buffer is not large enough the API returns FALSE, and the <c>GetLastError</c> value is
		/// ERROR_INSUFFICIENT_BUFFER. This API cannot fail when passed valid parameters and the return buffer is large enough.
		/// </returns>
		// BOOL WINAPI GetProcessDefaultCpuSets( _In_ HANDLE Process, _Out_opt_ PULONG CpuSetIds, _In_ ULONG CpuSetIdCount, _Out_ PULONG
		// RequiredIdCount); https://msdn.microsoft.com/en-us/library/windows/desktop/mt186424(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("Processthreadapi.h", MSDNShortId = "mt186424")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool GetProcessDefaultCpuSets(HPROCESS Process, IntPtr CpuSetIds, uint CpuSetIdCount, out uint RequiredIdCount);

		/// <summary>
		/// Retrieves the list of CPU Sets in the process default set that was set by <c>SetProcessDefaultCpuSets</c>. If no default CPU Sets
		/// are set for a given process, then an empty array is returned.
		/// </summary>
		/// <param name="Process">
		/// Specifies a process handle for the process to query. This handle must have the PROCESS_QUERY_LIMITED_INFORMATION access right.
		/// The value returned by <c>GetCurrentProcess</c> can also be specified here.
		/// </param>
		/// <returns>The list of CPU Set identifiers.</returns>
		public static uint[] GetProcessDefaultCpuSets(HPROCESS Process)
		{
			var cnt = (uint)Environment.ProcessorCount;
			if (cnt == 0) return new uint[0];
			var iptr = new SafeCoTaskMemHandle((int)cnt * Marshal.SizeOf(typeof(uint)));
			if (!GetProcessDefaultCpuSets(Process, (IntPtr)iptr, cnt, out cnt)) Win32Error.ThrowLastError();
			return iptr.ToArray<uint>((int)cnt);
		}

		/// <summary>Retrieves the number of open handles that belong to the specified process.</summary>
		/// <param name="hProcess">
		/// <para>
		/// A handle to the process whose handle count is being requested. The handle must have the PROCESS_QUERY_INFORMATION or
		/// PROCESS_QUERY_LIMITED_INFORMATION access right. For more information, see Process Security and Access Rights.
		/// </para>
		/// <para><c>Windows Server 2003 and Windows XP:</c> The handle must have the PROCESS_QUERY_INFORMATION access right.</para>
		/// </param>
		/// <param name="pdwHandleCount">
		/// A pointer to a variable that receives the number of open handles that belong to the specified process.
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is nonzero.</para>
		/// <para>If the function fails, the return value is zero. To get extended error information, call <c>GetLastError</c>.</para>
		/// </returns>
		// BOOL WINAPI GetProcessHandleCount( _In_ HANDLE hProcess, _Inout_ PDWORD pdwHandleCount); https://msdn.microsoft.com/en-us/library/windows/desktop/ms683214(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("WinBase.h", MSDNShortId = "ms683214")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool GetProcessHandleCount([In] HPROCESS hProcess, out uint pdwHandleCount);

		/// <summary>Retrieves the process identifier of the specified process.</summary>
		/// <param name="Process">
		/// <para>
		/// A handle to the process. The handle must have the PROCESS_QUERY_INFORMATION or PROCESS_QUERY_LIMITED_INFORMATION access right.
		/// For more information, see Process Security and Access Rights.
		/// </para>
		/// <para><c>Windows Server 2003 and Windows XP:</c> The handle must have the PROCESS_QUERY_INFORMATION access right.</para>
		/// </param>
		/// <returns></returns>
		// DWORD WINAPI GetProcessId( _In_ HANDLE Process); https://msdn.microsoft.com/en-us/library/windows/desktop/ms683215(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("WinBase.h", MSDNShortId = "ms683215")]
		public static extern uint GetProcessId([In] HPROCESS Process);

		/// <summary>Retrieves the process identifier of the process associated with the specified thread.</summary>
		/// <param name="Thread">
		/// <para>
		/// A handle to the thread. The handle must have the THREAD_QUERY_INFORMATION or THREAD_QUERY_LIMITED_INFORMATION access right. For
		/// more information, see Thread Security and Access Rights.
		/// </para>
		/// <para><c>Windows Server 2003:</c> The handle must have the THREAD_QUERY_INFORMATION access right.</para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is the process identifier of the process associated with the specified thread.</para>
		/// <para>If the function fails, the return value is zero. To get extended error information, call <c>GetLastError</c>.</para>
		/// </returns>
		// DWORD WINAPI GetProcessIdOfThread( _In_ HANDLE Thread); https://msdn.microsoft.com/en-us/library/windows/desktop/ms683216(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("WinBase.h", MSDNShortId = "ms683216")]
		public static extern uint GetProcessIdOfThread(HTHREAD Thread);

		/// <summary>Retrieves information about the specified process.</summary>
		/// <param name="hProcess">
		/// A handle to the process. This handle must have the <c>PROCESS_SET_INFORMATION</c> access right. For more information, see Process
		/// Security and Access Rights.
		/// </param>
		/// <param name="ProcessInformationClass">The kind of information to retrieve. The only supported value is <c>ProcessMemoryPriority</c></param>
		/// <param name="ProcessInformation">
		/// <para>Pointer to an object to receive the type of information specified by the ProcessInformationClass parameter.</para>
		/// <para>
		/// If the ProcessInformationClass parameter is <c>ProcessMemoryPriority</c>, this parameter must point to a
		/// <c>MEMORY_PRIORITY_INFORMATION</c> structure.
		/// </para>
		/// <para>
		/// If the ProcessInformationClass parameter is <c>ProcessPowerThrottling</c>, this parameter must point to a
		/// <c>PROCESS_POWER_THROTTLING_STATE</c> structure.
		/// </para>
		/// <para>
		/// If the ProcessInformationClass parameter is <c>ProcessProtectionLevelInfo</c>, this parameter must point to a
		/// <c>PROCESS_PROTECTION_LEVEL_INFORMATION</c> structure.
		/// </para>
		/// <para>
		/// If the ProcessInformationClass parameter is <c>ProcessAppMemoryInfo</c>, this parameter must point to a
		/// <c>APP_MEMORY_INFORMATION</c> structure.
		/// </para>
		/// </param>
		/// <param name="ProcessInformationSize">
		/// <para>The size in bytes of the structure specified by the ProcessInformation parameter.</para>
		/// <para>If the ProcessInformationClass parameter is <c>ProcessMemoryPriority</c>, this parameter must be .</para>
		/// <para>If the ProcessInformationClass parameter is <c>ProcessPowerThrottling</c>, this parameter must be .</para>
		/// <para>If the ProcessInformationClass parameter is <c>ProcessProtectionLevelInfo</c>, this parameter must be .</para>
		/// <para>If the ProcessInformationClass parameter is <c>ProcessAppMemoryInfo</c>, this parameter must be .</para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is nonzero.</para>
		/// <para>If the function fails, the return value is zero. To get extended error information, call <c>GetLastError</c>.</para>
		/// </returns>
		// BOOL WINAPI GetProcessInformation( _In_ HANDLE hProcess, _In_ PROCESS_INFORMATION_CLASS ProcessInformationClass,
		// _Out_writes_bytes_(ProcessInformationSize) ProcessInformation, _In_ DWORD ProcessInformationSize); https://msdn.microsoft.com/en-us/library/windows/desktop/hh448381(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("WinBase.h", MSDNShortId = "hh448381")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool GetProcessInformation(HPROCESS hProcess, PROCESS_INFORMATION_CLASS ProcessInformationClass,
			IntPtr ProcessInformation, uint ProcessInformationSize);

		/// <summary>Retrieves information about the specified process.</summary>
		/// <typeparam name="T">The type of information associated with <paramref name="ProcessInformationClass"/>.</typeparam>
		/// <param name="hProcess">
		/// A handle to the process. This handle must have the <c>PROCESS_SET_INFORMATION</c> access right. For more information, see Process
		/// Security and Access Rights.
		/// </param>
		/// <param name="ProcessInformationClass">The kind of information to retrieve. The only supported value is <c>ProcessMemoryPriority</c></param>
		/// <returns>An object containing the type of information specified by the ProcessInformationClass parameter.</returns>
		/// <exception cref="ArgumentException">Type mismatch.</exception>
		[PInvokeData("WinBase.h", MSDNShortId = "hh448381")]
		public static T GetProcessInformation<T>(HPROCESS hProcess, PROCESS_INFORMATION_CLASS ProcessInformationClass) where T : struct
		{
			if (!CorrespondingTypeAttribute.CanGet(ProcessInformationClass, typeof(T))) throw new ArgumentException("Type mismatch.");
			using (var mem = SafeHGlobalHandle.CreateFromStructure<T>())
			{
				if (!GetProcessInformation(hProcess, ProcessInformationClass, (IntPtr)mem, (uint)mem.Size))
					Win32Error.ThrowLastError();
				return mem.ToStructure<T>();
			}
		}

		/// <summary>Retrieves mitigation policy settings for the calling process.</summary>
		/// <param name="hProcess">
		/// A handle to the process. This handle must have the PROCESS_QUERY_INFORMATION access right. For more information, see Process
		/// Security and Access Rights.
		/// </param>
		/// <param name="MitigationPolicy">
		/// <para>The mitigation policy to retrieve. This parameter can be one of the following values.</para>
		/// <para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>ProcessDEPPolicy</term>
		/// <term>
		/// The data execution prevention (DEP) policy of the process.The lpBuffer parameter points to a PROCESS_MITIGATION_DEP_POLICY
		/// structure that specifies the DEP policy flags.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ProcessASLRPolicy</term>
		/// <term>
		/// The Address Space Layout Randomization (ASLR) policy of the process.The lpBuffer parameter points to a
		/// PROCESS_MITIGATION_ASLR_POLICY structure that specifies the ASLR policy flags.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ProcessDynamicCodePolicy</term>
		/// <term>
		/// The dynamic code policy of the process. When turned on, the process cannot generate dynamic code or modify existing executable
		/// code.The lpBuffer parameter points to a PROCESS_MITIGATION_DYNAMIC_CODE_POLICY structure that specifies the dynamic code policy flags.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ProcessStrictHandleCheckPolicy</term>
		/// <term>
		/// The process will receive a fatal error if it manipulates a handle that is not valid.The lpBuffer parameter points to a
		/// PROCESS_MITIGATION_STRICT_HANDLE_CHECK_POLICY structure that specifies the handle check policy flags.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ProcessSystemCallDisablePolicy</term>
		/// <term>
		/// Disables the ability to use NTUser/GDI functions at the lowest layer.The lpBuffer parameter points to a
		/// PROCESS_MITIGATION_SYSTEM_CALL_DISABLE_POLICY structure that specifies the system call disable policy flags.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ProcessMitigationOptionsMask</term>
		/// <term>
		/// Returns the mask of valid bits for all the mitigation options on the system. An application can set many mitigation options
		/// without querying the operating system for mitigation options by combining bitwise with the mask to exclude all non-supported bits
		/// at once.The lpBuffer parameter points to a ULONG64 bit vector for the mask, or a two-element array of ULONG64 bit vectors.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ProcessExtensionPointDisablePolicy</term>
		/// <term>
		/// Prevents certain built-in third party extension points from being enabled, preventing legacy extension point DLLs from being
		/// loaded into the process.The lpBuffer parameter points to a PROCESS_MITIGATION_EXTENSION_POINT_DISABLE_POLICY structure that
		/// specifies the extension point disable policy flags.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ProcessControlFlowGuardPolicy</term>
		/// <term>
		/// The Control Flow Guard (CFG) policy of the process.The lpBuffer parameter points to a
		/// PROCESS_MITIGATION_CONTROL_FLOW_GUARD_POLICY structure that specifies the CFG policy flags.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ProcessSignaturePolicy</term>
		/// <term>
		/// The policy of a process that can restrict image loading to those images that are either signed by Microsoft, by the Windows
		/// Store, or by Microsoft, the Windows Store and the Windows Hardware Quality Labs (WHQL).he lpBuffer parameter points to a
		/// PROCESS_MITIGATION_BINARY_SIGNATURE_POLICY structure that specifies the signature policy flags.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ProcessFontDisablePolicy</term>
		/// <term>
		/// The policy regarding font loading for the process. When turned on, the process cannot load non-system fonts.The lpBuffer
		/// parameter points to a PROCESS_MITIGATION_FONT_DISABLE_POLICY structure that specifies the policy flags for font loading.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ProcessImageLoadPolicy</term>
		/// <term>
		/// The policy regarding image loading for the process, which determines the types of executable images that are allowed to be mapped
		/// into the process. When turned on, images cannot be loaded from some locations, such a remote devices or files that have the low
		/// mandatory label.The lpBuffer parameter points to a PROCESS_MITIGATION_IMAGE_LOAD_POLICY structure that specifies the policy flags
		/// for image loading.
		/// </term>
		/// </item>
		/// </list>
		/// </para>
		/// </param>
		/// <param name="lpBuffer">
		/// <para>
		/// If the MitigationPolicy parameter is <c>ProcessDEPPolicy</c>, this parameter points to a <c>PROCESS_MITIGATION_DEP_POLICY</c>
		/// structure that receives the DEP policy flags.
		/// </para>
		/// <para>
		/// If the MitigationPolicy parameter is <c>ProcessASLRPolicy</c>, this parameter points to a <c>PROCESS_MITIGATION_ASLR_POLICY</c>
		/// structure that receives the ASLR policy flags.
		/// </para>
		/// <para>
		/// If the MitigationPolicy parameter is <c>ProcessDynamicCodePolicy</c>, this parameter points to a
		/// <c>PROCESS_MITIGATION_DYNAMIC_CODE_POLICY</c> structure that receives the dynamic code policy flags.
		/// </para>
		/// <para>
		/// If the MitigationPolicy parameter is <c>ProcessStrictHandleCheckPolicy</c>, this parameter points to a
		/// <c>PROCESS_MITIGATION_STRICT_HANDLE_CHECK_POLICY</c> structure that specifies the handle check policy flags.
		/// </para>
		/// <para>
		/// If the MitigationPolicy parameter is <c>ProcessSystemCallDisablePolicy</c>, this parameter points to a
		/// <c>PROCESS_MITIGATION_SYSTEM_CALL_DISABLE_POLICY</c> structure that specifies the system call disable policy flags.
		/// </para>
		/// <para>
		/// If the MitigationPolicy parameter is <c>ProcessMitigationOptionsMask</c>, this parameter points to a <c>ULONG64</c> bit vector
		/// for the mask or a two-element array of <c>ULONG64</c> bit vectors.
		/// </para>
		/// <para>
		/// If the MitigationPolicy parameter is <c>ProcessExtensionPointDisablePolicy</c>, this parameter points to a
		/// <c>PROCESS_MITIGATION_EXTENSION_POINT_DISABLE_POLICY</c> structure that specifies the extension point disable policy flags.
		/// </para>
		/// <para>
		/// If the MitigationPolicy parameter is <c>ProcessControlFlowGuardPolicy</c>, this parameter points to a
		/// <c>PROCESS_MITIGATION_CONTROL_FLOW_GUARD_POLICY</c> structure that specifies the CFG policy flags.
		/// </para>
		/// <para>
		/// If the MitigationPolicy parameter is <c>ProcessSignaturePolicy</c>, this parameter points to a
		/// <c>PROCESS_MITIGATION_BINARY_SIGNATURE_POLICY</c> structure that receives the signature policy flags.
		/// </para>
		/// <para>
		/// If the MitigationPolicy parameter is <c>ProcessFontDisablePolicy</c>, this parameter points to a
		/// <c>PROCESS_MITIGATION_FONT_DISABLE_POLICY</c> structure that receives the policy flags for font loading.
		/// </para>
		/// <para>
		/// If the MitigationPolicy parameter is <c>ProcessImageLoadPolicy</c>, this parameter points to a
		/// <c>PROCESS_MITIGATION_IMAGE_LOAD_POLICY</c> structure that receives the policy flags for image loading.
		/// </para>
		/// </param>
		/// <param name="dwLength">The size of lpBuffer, in bytes.</param>
		/// <returns>
		/// If the function succeeds, it returns <c>TRUE</c>. If the function fails, it returns <c>FALSE</c>. To retrieve error values
		/// defined for this function, call <c>GetLastError</c>.
		/// </returns>
		// BOOL WINAPI GetProcessMitigationPolicy( _In_ HANDLE hProcess, _In_ PROCESS_MITIGATION_POLICY MitigationPolicy, _Out_ PVOID
		// lpBuffer, _In_ SIZE_T dwLength); https://msdn.microsoft.com/en-us/library/windows/desktop/hh769085(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("Processthreadsapi.h", MSDNShortId = "hh769085")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool GetProcessMitigationPolicy(HPROCESS hProcess, PROCESS_MITIGATION_POLICY MitigationPolicy, IntPtr lpBuffer, SizeT dwLength);

		/// <summary>Retrieves mitigation policy settings for the calling process.</summary>
		/// <typeparam name="T">The type of the value to retrieve.</typeparam>
		/// <param name="hProcess">
		/// A handle to the process. This handle must have the PROCESS_QUERY_INFORMATION access right. For more information, see Process
		/// Security and Access Rights.
		/// </param>
		/// <param name="MitigationPolicy">
		/// <para>The mitigation policy to retrieve. This parameter can be one of the following values.</para>
		/// <para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>ProcessDEPPolicy</term>
		/// <term>
		/// The data execution prevention (DEP) policy of the process.The lpBuffer parameter points to a PROCESS_MITIGATION_DEP_POLICY
		/// structure that specifies the DEP policy flags.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ProcessASLRPolicy</term>
		/// <term>
		/// The Address Space Layout Randomization (ASLR) policy of the process.The lpBuffer parameter points to a
		/// PROCESS_MITIGATION_ASLR_POLICY structure that specifies the ASLR policy flags.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ProcessDynamicCodePolicy</term>
		/// <term>
		/// The dynamic code policy of the process. When turned on, the process cannot generate dynamic code or modify existing executable
		/// code.The lpBuffer parameter points to a PROCESS_MITIGATION_DYNAMIC_CODE_POLICY structure that specifies the dynamic code policy flags.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ProcessStrictHandleCheckPolicy</term>
		/// <term>
		/// The process will receive a fatal error if it manipulates a handle that is not valid.The lpBuffer parameter points to a
		/// PROCESS_MITIGATION_STRICT_HANDLE_CHECK_POLICY structure that specifies the handle check policy flags.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ProcessSystemCallDisablePolicy</term>
		/// <term>
		/// Disables the ability to use NTUser/GDI functions at the lowest layer.The lpBuffer parameter points to a
		/// PROCESS_MITIGATION_SYSTEM_CALL_DISABLE_POLICY structure that specifies the system call disable policy flags.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ProcessMitigationOptionsMask</term>
		/// <term>
		/// Returns the mask of valid bits for all the mitigation options on the system. An application can set many mitigation options
		/// without querying the operating system for mitigation options by combining bitwise with the mask to exclude all non-supported bits
		/// at once.The lpBuffer parameter points to a ULONG64 bit vector for the mask, or a two-element array of ULONG64 bit vectors.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ProcessExtensionPointDisablePolicy</term>
		/// <term>
		/// Prevents certain built-in third party extension points from being enabled, preventing legacy extension point DLLs from being
		/// loaded into the process.The lpBuffer parameter points to a PROCESS_MITIGATION_EXTENSION_POINT_DISABLE_POLICY structure that
		/// specifies the extension point disable policy flags.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ProcessControlFlowGuardPolicy</term>
		/// <term>
		/// The Control Flow Guard (CFG) policy of the process.The lpBuffer parameter points to a
		/// PROCESS_MITIGATION_CONTROL_FLOW_GUARD_POLICY structure that specifies the CFG policy flags.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ProcessSignaturePolicy</term>
		/// <term>
		/// The policy of a process that can restrict image loading to those images that are either signed by Microsoft, by the Windows
		/// Store, or by Microsoft, the Windows Store and the Windows Hardware Quality Labs (WHQL).he lpBuffer parameter points to a
		/// PROCESS_MITIGATION_BINARY_SIGNATURE_POLICY structure that specifies the signature policy flags.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ProcessFontDisablePolicy</term>
		/// <term>
		/// The policy regarding font loading for the process. When turned on, the process cannot load non-system fonts.The lpBuffer
		/// parameter points to a PROCESS_MITIGATION_FONT_DISABLE_POLICY structure that specifies the policy flags for font loading.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ProcessImageLoadPolicy</term>
		/// <term>
		/// The policy regarding image loading for the process, which determines the types of executable images that are allowed to be mapped
		/// into the process. When turned on, images cannot be loaded from some locations, such a remote devices or files that have the low
		/// mandatory label.The lpBuffer parameter points to a PROCESS_MITIGATION_IMAGE_LOAD_POLICY structure that specifies the policy flags
		/// for image loading.
		/// </term>
		/// </item>
		/// </list>
		/// </para>
		/// </param>
		/// <param name="value">The value.</param>
		/// <returns>
		/// If the function succeeds, it returns <c>TRUE</c>. If the function fails, it returns <c>FALSE</c>. To retrieve error values
		/// defined for this function, call <c>GetLastError</c>.
		/// </returns>
		/// <exception cref="ArgumentException"></exception>
		public static bool GetProcessMitigationPolicy<T>(HPROCESS hProcess, PROCESS_MITIGATION_POLICY MitigationPolicy, out T value)
		{
			var isMask = MitigationPolicy == PROCESS_MITIGATION_POLICY.ProcessMitigationOptionsMask;
			if (!isMask && !CorrespondingTypeAttribute.CanGet(MitigationPolicy, typeof(T))) throw new ArgumentException($"{MitigationPolicy} cannot be used to get values of type {typeof(T)}.");
			var sz = isMask ? 16 : Marshal.SizeOf(typeof(T));
			using (var ptr = new SafeCoTaskMemHandle(sz))
			{
				if (!isMask)
				{
					if (GetProcessMitigationPolicy(hProcess, MitigationPolicy, (IntPtr)ptr, (uint)ptr.Size))
					{
						value = ptr.ToStructure<T>();
						return true;
					}
				}
				else
				{
					if (GetProcessMitigationPolicy(hProcess, MitigationPolicy, (IntPtr)ptr, (uint)ptr.Size))
					{
						value = (T)(object)ptr.ToArray<ulong>(2);
						return true;
					}
					else if (GetProcessMitigationPolicy(hProcess, MitigationPolicy, (IntPtr)ptr, 8))
					{
						value = (T)(object)ptr.ToArray<ulong>(1);
						return true;
					}
				}
			}
			value = default;
			return false;
		}

		/// <summary>Retrieves the priority boost control state of the specified process.</summary>
		/// <param name="hProcess">
		/// <para>
		/// A handle to the process. This handle must have the <c>PROCESS_QUERY_INFORMATION</c> or <c>PROCESS_QUERY_LIMITED_INFORMATION</c>
		/// access right. For more information, see Process Security and Access Rights.
		/// </para>
		/// <para><c>Windows Server 2003 and Windows XP:</c> The handle must have the <c>PROCESS_QUERY_INFORMATION</c> access right.</para>
		/// </param>
		/// <param name="pDisablePriorityBoost">
		/// A pointer to a variable that receives the priority boost control state. A value of TRUE indicates that dynamic boosting is
		/// disabled. A value of FALSE indicates normal behavior.
		/// </param>
		/// <returns>
		/// <para>
		/// If the function succeeds, the return value is nonzero. In that case, the variable pointed to by the pDisablePriorityBoost
		/// parameter receives the priority boost control state.
		/// </para>
		/// <para>If the function fails, the return value is zero. To get extended error information, call <c>GetLastError</c>.</para>
		/// </returns>
		// BOOL WINAPI GetProcessPriorityBoost( _In_ HANDLE hProcess, _Out_ PBOOL pDisablePriorityBoost); https://msdn.microsoft.com/en-us/library/windows/desktop/ms683220(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("WinBase.h", MSDNShortId = "ms683220")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool GetProcessPriorityBoost([In] HPROCESS hProcess, [MarshalAs(UnmanagedType.Bool)] out bool pDisablePriorityBoost);

		/// <summary>Retrieves the shutdown parameters for the currently calling process.</summary>
		/// <param name="lpdwLevel">
		/// <para>
		/// A pointer to a variable that receives the shutdown priority level. Higher levels shut down first. System level shutdown orders
		/// are reserved for system components. Higher numbers shut down first. Following are the level conventions.
		/// </para>
		/// <para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>000-0FF</term>
		/// <term>System reserved last shutdown range.</term>
		/// </item>
		/// <item>
		/// <term>100-1FF</term>
		/// <term>Application reserved last shutdown range.</term>
		/// </item>
		/// <item>
		/// <term>200-2FF</term>
		/// <term>Application reserved &amp;quot;in between&amp;quot; shutdown range.</term>
		/// </item>
		/// <item>
		/// <term>300-3FF</term>
		/// <term>Application reserved first shutdown range.</term>
		/// </item>
		/// <item>
		/// <term>400-4FF</term>
		/// <term>System reserved first shutdown range.</term>
		/// </item>
		/// </list>
		/// </para>
		/// <para>All processes start at shutdown level 0x280.</para>
		/// </param>
		/// <param name="lpdwFlags">
		/// <para>A pointer to a variable that receives the shutdown flags. This parameter can be the following value.</para>
		/// <para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>SHUTDOWN_NORETRY0x00000001</term>
		/// <term>
		/// If this process takes longer than the specified timeout to shut down, do not display a retry dialog box for the user. Instead,
		/// just cause the process to directly exit.
		/// </term>
		/// </item>
		/// </list>
		/// </para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is nonzero.</para>
		/// <para>If the function fails, the return value is zero. To get extended error information, call <c>GetLastError</c>.</para>
		/// </returns>
		// BOOL WINAPI GetProcessShutdownParameters( _Out_ LPDWORD lpdwLevel, _Out_ LPDWORD lpdwFlags); https://msdn.microsoft.com/en-us/library/windows/desktop/ms683221(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("WinBase.h", MSDNShortId = "ms683221")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool GetProcessShutdownParameters(out uint lpdwLevel, out SHUTDOWN lpdwFlags);

		/// <summary>Retrieves timing information for the specified process.</summary>
		/// <param name="hProcess">
		/// <para>
		/// A handle to the process whose timing information is sought. The handle must have the <c>PROCESS_QUERY_INFORMATION</c> or
		/// <c>PROCESS_QUERY_LIMITED_INFORMATION</c> access right. For more information, see Process Security and Access Rights.
		/// </para>
		/// <para><c>Windows Server 2003 and Windows XP:</c> The handle must have the <c>PROCESS_QUERY_INFORMATION</c> access right.</para>
		/// </param>
		/// <param name="lpCreationTime">A pointer to a <c>FILETIME</c> structure that receives the creation time of the process.</param>
		/// <param name="lpExitTime">
		/// A pointer to a <c>FILETIME</c> structure that receives the exit time of the process. If the process has not exited, the content
		/// of this structure is undefined.
		/// </param>
		/// <param name="lpKernelTime">
		/// A pointer to a <c>FILETIME</c> structure that receives the amount of time that the process has executed in kernel mode. The time
		/// that each of the threads of the process has executed in kernel mode is determined, and then all of those times are summed
		/// together to obtain this value.
		/// </param>
		/// <param name="lpUserTime">
		/// A pointer to a <c>FILETIME</c> structure that receives the amount of time that the process has executed in user mode. The time
		/// that each of the threads of the process has executed in user mode is determined, and then all of those times are summed together
		/// to obtain this value. Note that this value can exceed the amount of real time elapsed (between lpCreationTime and lpExitTime) if
		/// the process executes across multiple CPU cores.
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is nonzero.</para>
		/// <para>If the function fails, the return value is zero. To get extended error information, call <c>GetLastError</c>.</para>
		/// </returns>
		// BOOL WINAPI GetProcessTimes( _In_ HANDLE hProcess, _Out_ LPFILETIME lpCreationTime, _Out_ LPFILETIME lpExitTime, _Out_ LPFILETIME
		// lpKernelTime, _Out_ LPFILETIME lpUserTime); https://msdn.microsoft.com/en-us/library/windows/desktop/ms683223(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("WinBase.h", MSDNShortId = "ms683223")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool GetProcessTimes([In] HPROCESS hProcess, out FILETIME lpCreationTime, out FILETIME lpExitTime, out FILETIME lpKernelTime,
			out FILETIME lpUserTime);

		/// <summary>Retrieves the major and minor version numbers of the system on which the specified process expects to run.</summary>
		/// <param name="ProcessId">The process identifier of the process of interest. A value of zero specifies the calling process.</param>
		/// <returns>
		/// <para>
		/// If the function succeeds, the return value is the version of the system on which the process expects to run. The high word of the
		/// return value contains the major version number. The low word of the return value contains the minor version number.
		/// </para>
		/// <para>
		/// If the function fails, the return value is zero. To get extended error information, call <c>GetLastError</c>. The function fails
		/// if ProcessId is an invalid value.
		/// </para>
		/// </returns>
		// DWORD WINAPI GetProcessVersion( _In_ DWORD ProcessId); https://msdn.microsoft.com/en-us/library/windows/desktop/ms683224(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("WinBase.h", MSDNShortId = "ms683224")]
		public static extern uint GetProcessVersion(uint ProcessId = 0);

		/// <summary>Retrieves the contents of the <c>STARTUPINFO</c> structure that was specified when the calling process was created.</summary>
		/// <param name="lpStartupInfo">A pointer to a <c>STARTUPINFO</c> structure that receives the startup information.</param>
		/// <returns>
		/// <para>This function does not return a value.</para>
		/// <para>
		/// If an error occurs, the ANSI version of this function ( <c>GetStartupInfoA</c>) can raise an exception. The Unicode version (
		/// <c>GetStartupInfoW</c>) does not fail.
		/// </para>
		/// </returns>
		// VOID WINAPI GetStartupInfo( _Out_ LPSTARTUPINFO lpStartupInfo); https://msdn.microsoft.com/en-us/library/windows/desktop/ms683230(v=vs.85).aspx
		[PInvokeData("WinBase.h", MSDNShortId = "ms683230")]
		public static void GetStartupInfo(out STARTUPINFO lpStartupInfo) { GetStartupInfo(out STARTUPINFO_OUT sio); lpStartupInfo = sio; }

		/// <summary>Allows an application to query the available CPU Sets on the system, and their current state.</summary>
		/// <param name="Information">
		/// A pointer to a <c>SYSTEM_CPU_SET_INFORMATION</c> structure that receives the CPU Set data. Pass NULL with a buffer length of 0 to
		/// determine the required buffer size.
		/// </param>
		/// <param name="BufferLength">The length, in bytes, of the output buffer passed as the Information argument.</param>
		/// <param name="ReturnedLength">
		/// The length, in bytes, of the valid data in the output buffer if the buffer is large enough, or the required size of the output
		/// buffer. If no CPU Sets exist, this value will be 0.
		/// </param>
		/// <param name="Process">
		/// An optional handle to a process. This process is used to determine the value of the <c>AllocatedToTargetProcess</c> flag in the
		/// SYSTEM_CPU_SET_INFORMATION structure. If a CPU Set is allocated to the specified process, the flag is set. Otherwise, it is
		/// clear. This handle must have the PROCESS_QUERY_LIMITED_INFORMATION access right. The value returned by <c>GetCurrentProcess</c>
		/// may also be specified here.
		/// </param>
		/// <param name="Flags">Reserved, must be 0.</param>
		/// <returns>
		/// If the API succeeds it returns TRUE. If it fails, the error reason is available through <c>GetLastError</c>. If the Information
		/// buffer was NULL or not large enough, the error code ERROR_INSUFFICIENT_BUFFER is returned. This API cannot fail when passed valid
		/// parameters and a buffer that is large enough to hold all of the return data.
		/// </returns>
		// BOOL WINAPI GetSystemCpuSetInformation( _Out_opt_ PSYSTEM_CPU_SET_INFORMATION Information, _In_ ULONG BufferLength, _Out_ PULONG
		// ReturnedLength, _In_opt_ HANDLE Process, _Reserved_ ULONG Flags); https://msdn.microsoft.com/en-us/library/windows/desktop/mt186425(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("Processthreadapi.h", MSDNShortId = "mt186425")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool GetSystemCpuSetInformation(IntPtr Information, uint BufferLength, out uint ReturnedLength, [Optional] HPROCESS Process, [Optional] uint Flags);

		/// <summary>Allows an application to query the available CPU Sets on the system, and their current state.</summary>
		/// <param name="Process">
		/// An optional handle to a process. This process is used to determine the value of the <c>AllocatedToTargetProcess</c> flag in the
		/// SYSTEM_CPU_SET_INFORMATION structure. If a CPU Set is allocated to the specified process, the flag is set. Otherwise, it is
		/// clear. This handle must have the PROCESS_QUERY_LIMITED_INFORMATION access right. The value returned by <c>GetCurrentProcess</c>
		/// may also be specified here.
		/// </param>
		/// <returns>A list of <c>SYSTEM_CPU_SET_INFORMATION</c> structures with CPU Set data.</returns>
		public static IEnumerable<SYSTEM_CPU_SET_INFORMATION> GetSystemCpuSetInformation([Optional] HPROCESS Process)
		{
			if (!GetSystemCpuSetInformation(IntPtr.Zero, 0, out var sz, Process) || sz == 0)
			{
				var err = Win32Error.GetLastError();
				if (err != Win32Error.ERROR_INSUFFICIENT_BUFFER) throw err.GetException();
			}
			using (var ptr = new SafeCoTaskMemHandle((int)sz))
			{
				if (!GetSystemCpuSetInformation((IntPtr)ptr, sz, out sz, Process))
					Win32Error.ThrowLastError();
				var offset = 0;
				while (offset < sz)
				{
					var sptr = ptr.DangerousGetHandle().Offset(offset);
					var structSize = Marshal.ReadInt32(sptr);
					yield return sptr.ToStructure<SYSTEM_CPU_SET_INFORMATION>(sz - offset);
					offset += structSize;
				}
			}
		}

		/// <summary>
		/// Retrieves system timing information. On a multiprocessor system, the values returned are the sum of the designated times across
		/// all processors.
		/// </summary>
		/// <param name="lpIdleTime">
		/// A pointer to a <c>FILETIME</c> structure that receives the amount of time that the system has been idle.
		/// </param>
		/// <param name="lpKernelTime">
		/// A pointer to a <c>FILETIME</c> structure that receives the amount of time that the system has spent executing in Kernel mode
		/// (including all threads in all processes, on all processors). This time value also includes the amount of time the system has been idle.
		/// </param>
		/// <param name="lpUserTime">
		/// A pointer to a <c>FILETIME</c> structure that receives the amount of time that the system has spent executing in User mode
		/// (including all threads in all processes, on all processors).
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is nonzero.</para>
		/// <para>If the function fails, the return value is zero. To get extended error information, call <c>GetLastError</c>.</para>
		/// </returns>
		// BOOL WINAPI GetSystemTimes( _Out_opt_ LPFILETIME lpIdleTime, _Out_opt_ LPFILETIME lpKernelTime, _Out_opt_ LPFILETIME lpUserTime); https://msdn.microsoft.com/en-us/library/windows/desktop/ms724400(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("Winbase.h", MSDNShortId = "ms724400")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool GetSystemTimes(out FILETIME lpIdleTime, out FILETIME lpKernelTime, out FILETIME lpUserTime);

		/// <summary>
		/// <para>Retrieves the context of the specified thread.</para>
		/// <para>A 64-bit application can retrieve the context of a WOW64 thread using the <c>Wow64GetThreadContext</c> function.</para>
		/// </summary>
		/// <param name="hThread">
		/// <para>
		/// A handle to the thread whose context is to be retrieved. The handle must have <c>THREAD_GET_CONTEXT</c> access to the thread. For
		/// more information, see Thread Security and Access Rights.
		/// </para>
		/// <para><c>WOW64:</c> The handle must also have <c>THREAD_QUERY_INFORMATION</c> access.</para>
		/// </param>
		/// <param name="lpContext">
		/// A pointer to a <c>CONTEXT</c> structure that receives the appropriate context of the specified thread. The value of the
		/// <c>ContextFlags</c> member of this structure specifies which portions of a thread's context are retrieved. The <c>CONTEXT</c>
		/// structure is highly processor specific. Refer to the WinNT.h header file for processor-specific definitions of this structures
		/// and any alignment requirements.
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is nonzero.</para>
		/// <para>If the function fails, the return value is zero. To get extended error information, call <c>GetLastError</c>.</para>
		/// </returns>
		// BOOL WINAPI GetThreadContext( _In_ HANDLE hThread, _Inout_ LPCONTEXT lpContext); https://msdn.microsoft.com/en-us/library/windows/desktop/ms679362(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("WinBase.h", MSDNShortId = "ms679362")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool GetThreadContext([In] HTHREAD hThread, ref CONTEXT lpContext);

		/// <summary>Retrieves the description that was assigned to a thread by calling SetThreadDescription.</summary>
		/// <param name="hThread">
		/// A handle to the thread for which to retrieve the description. The handle must have THREAD_QUERY_LIMITED_INFORMATION access.
		/// </param>
		/// <param name="ppszThreadDescription">A Unicode string that contains the description of the thread.</param>
		/// <returns>
		/// If the function succeeds, the return value is the <c>HRESULT</c> that denotes a successful operation. If the function fails, the
		/// return value is an <c>HRESULT</c> that denotes the error.
		/// </returns>
		/// <remarks>
		/// <para>
		/// The description for a thread can change at any time. For example, a different thread can change the description of a thread of
		/// interest while you try to retrieve that description.
		/// </para>
		/// <para>Thread descriptions do not need to be unique.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/processthreadsapi/nf-processthreadsapi-getthreaddescription HRESULT
		// GetThreadDescription( HANDLE hThread, PWSTR *ppszThreadDescription );
		[DllImport(Lib.Kernel32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("processthreadsapi.h", MSDNShortId = "9CFF0A2D-2196-4AE0-8F77-229A8AB7A3E8")]
		public static extern HRESULT GetThreadDescription(HTHREAD hThread, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(LocalStringMarshaler))] out string threadDescription);

		/// <summary>Retrieves the thread identifier of the specified thread.</summary>
		/// <param name="Thread">
		/// <para>
		/// A handle to the thread. The handle must have the THREAD_QUERY_INFORMATION or THREAD_QUERY_LIMITED_INFORMATION access right. For
		/// more information about access rights, see Thread Security and Access Rights.
		/// </para>
		/// <para><c>Windows Server 2003:</c> The handle must have the THREAD_QUERY_INFORMATION access right.</para>
		/// </param>
		/// <returns>If the function fails, the return value is zero. To get extended error information, call <c>GetLastError</c>.</returns>
		// DWORD WINAPI GetThreadId( _In_ HANDLE Thread); https://msdn.microsoft.com/en-us/library/windows/desktop/ms683233(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("WinBase.h", MSDNShortId = "ms683233")]
		public static extern uint GetThreadId(HTHREAD Thread);

		/// <summary>Retrieves the processor number of the ideal processor for the specified thread.</summary>
		/// <param name="hThread">
		/// A handle to the thread for which to retrieve the ideal processor. This handle must have been created with the
		/// THREAD_QUERY_LIMITED_INFORMATION access right. For more information, see Thread Security and Access Rights.
		/// </param>
		/// <param name="lpIdealProcessor">Points to <c>PROCESSOR_NUMBER</c> structure to receive the number of the ideal processor.</param>
		/// <returns>
		/// <para>If the function succeeds, it returns a nonzero value.</para>
		/// <para>If the function fails, it returns zero. To get extended error information, use <c>GetLastError</c>.</para>
		/// </returns>
		// BOOL GetThreadIdealProcessorEx( _In_ HANDLE hThread, _Out_ PPROCESSOR_NUMBER lpIdealProcessor); https://msdn.microsoft.com/en-us/library/windows/desktop/dd405499(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("WinBase.h", MSDNShortId = "dd405499")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool GetThreadIdealProcessorEx(HTHREAD hThread, out PROCESSOR_NUMBER lpIdealProcessor);

		/// <summary>Retrieves information about the specified thread.</summary>
		/// <param name="hThread">
		/// A handle to the thread. The handle must have THREAD_QUERY_INFORMATION access rights. For more information, see Thread Security
		/// and Access Rights.
		/// </param>
		/// <param name="ThreadInformationClass">
		/// The class of information to retrieve. The only supported values are <c>ThreadMemoryPriority</c> and <c>ThreadPowerThrottling</c>.
		/// </param>
		/// <param name="ThreadInformation">
		/// <para>Pointer to a structure to receive the type of information specified by the ThreadInformationClass parameter.</para>
		/// <para>
		/// If the ThreadInformationClass parameter is <c>ThreadMemoryPriority</c>, this parameter must point to a
		/// <c>MEMORY_PRIORITY_INFORMATION</c> structure.
		/// </para>
		/// <para>
		/// If the ThreadInformationClass parameter is <c>ThreadPowerThrottling</c>, this parameter must point to a
		/// <c>THREAD_POWER_THROTTLING_STATE</c> structure.
		/// </para>
		/// </param>
		/// <param name="ThreadInformationSize">
		/// <para>The size in bytes of the structure specified by the ThreadInformation parameter.</para>
		/// <para>If the ThreadInformationClass parameter is <c>ThreadMemoryPriority</c>, this parameter must be .</para>
		/// <para>If the ThreadInformationClass parameter is <c>ThreadPowerThrottling</c>, this parameter must be .</para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is nonzero.</para>
		/// <para>If the function fails, the return value is zero. To get extended error information, call <c>GetLastError</c>.</para>
		/// </returns>
		// BOOL GetThreadInformation( _In_ HANDLE hThread, _In_ THREAD_INFORMATION_CLASS ThreadInformationClass, _Out_writes_bytes_
		// ThreadInformation, _In_ DWORD ThreadInformationSize);// https://msdn.microsoft.com/en-us/library/windows/desktop/hh448382(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("WinBase.h", MSDNShortId = "hh448382")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool GetThreadInformation(HTHREAD hThread, THREAD_INFORMATION_CLASS ThreadInformationClass, IntPtr ThreadInformation, uint ThreadInformationSize);

		/// <summary>Retrieves information about the specified thread.</summary>
		/// <param name="hThread">
		/// A handle to the thread. The handle must have THREAD_QUERY_INFORMATION access rights. For more information, see Thread Security
		/// and Access Rights.
		/// </param>
		/// <param name="ThreadInformationClass">
		/// The class of information to retrieve. The only supported values are <c>ThreadMemoryPriority</c> and <c>ThreadPowerThrottling</c>.
		/// </param>
		/// <returns>
		/// <para>A structure that receives the type of information specified by the ThreadInformationClass parameter.</para>
		/// <para>
		/// If the ThreadInformationClass parameter is <c>ThreadMemoryPriority</c>, this parameter must point to a
		/// <c>MEMORY_PRIORITY_INFORMATION</c> structure.
		/// </para>
		/// <para>
		/// If the ThreadInformationClass parameter is <c>ThreadPowerThrottling</c>, this parameter must point to a
		/// <c>THREAD_POWER_THROTTLING_STATE</c> structure.
		/// </para>
		/// </returns>
		[PInvokeData("WinBase.h", MSDNShortId = "hh448382")]
		public static T GetThreadInformation<T>(HTHREAD hThread, THREAD_INFORMATION_CLASS ThreadInformationClass) where T : struct
		{
			if (!CorrespondingTypeAttribute.CanGet(ThreadInformationClass, typeof(T))) throw new ArgumentException($"{ThreadInformationClass} cannot be used to get values of type {typeof(T)}.");
			using (var mem = SafeHGlobalHandle.CreateFromStructure(ReflectionExtensions.CreateOrDefault<T>()))
			{
				if (!GetThreadInformation(hThread, ThreadInformationClass, (IntPtr)mem, (uint)mem.Size))
					Win32Error.ThrowLastError();
				return mem.ToStructure<T>();
			}
		}

		/// <summary>Determines whether a specified thread has any I/O requests pending.</summary>
		/// <param name="hThread">
		/// A handle to the thread in question. This handle must have been created with the THREAD_QUERY_INFORMATION access right. For more
		/// information, see Thread Security and Access Rights.
		/// </param>
		/// <param name="lpIOIsPending">
		/// A pointer to a variable which the function sets to TRUE if the specified thread has one or more I/O requests pending, or to FALSE otherwise.
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is nonzero.</para>
		/// <para>If the function fails, the return value is zero. To get extended error information, call <c>GetLastError</c>.</para>
		/// </returns>
		// BOOL WINAPI GetThreadIOPendingFlag( _In_ HANDLE hThread, _Inout_ PBOOL lpIOIsPending); https://msdn.microsoft.com/en-us/library/windows/desktop/ms683234(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("WinBase.h", MSDNShortId = "ms683234")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool GetThreadIOPendingFlag([In] HTHREAD hThread, [MarshalAs(UnmanagedType.Bool)] out bool lpIOIsPending);

		/// <summary>
		/// Retrieves the priority value for the specified thread. This value, together with the priority class of the thread's process,
		/// determines the thread's base-priority level.
		/// </summary>
		/// <param name="hThread">
		/// <para>A handle to the thread.</para>
		/// <para>
		/// The handle must have the <c>THREAD_QUERY_INFORMATION</c> or <c>THREAD_QUERY_LIMITED_INFORMATION</c> access right. For more
		/// information, see Thread Security and Access Rights.
		/// </para>
		/// <para><c>Windows Server 2003:</c> The handle must have the <c>THREAD_QUERY_INFORMATION</c> access right.</para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is the thread's priority level.</para>
		/// <para>
		/// If the function fails, the return value is <c>THREAD_PRIORITY_ERROR_RETURN</c>. To get extended error information, call <c>GetLastError</c>.
		/// </para>
		/// <para><c>Windows Phone 8.1:</c> This function will always return <c>THREAD_PRIORITY_NORMAL</c>.</para>
		/// <para>The thread's priority level is one of the following values.</para>
		/// <para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code/value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>THREAD_PRIORITY_ABOVE_NORMAL1</term>
		/// <term>Priority 1 point above the priority class.</term>
		/// </item>
		/// <item>
		/// <term>THREAD_PRIORITY_BELOW_NORMAL-1</term>
		/// <term>Priority 1 point below the priority class.</term>
		/// </item>
		/// <item>
		/// <term>THREAD_PRIORITY_HIGHEST2</term>
		/// <term>Priority 2 points above the priority class.</term>
		/// </item>
		/// <item>
		/// <term>THREAD_PRIORITY_IDLE-15</term>
		/// <term>
		/// Base priority of 1 for IDLE_PRIORITY_CLASS, BELOW_NORMAL_PRIORITY_CLASS, NORMAL_PRIORITY_CLASS, ABOVE_NORMAL_PRIORITY_CLASS, or
		/// HIGH_PRIORITY_CLASS processes, and a base priority of 16 for REALTIME_PRIORITY_CLASS processes.
		/// </term>
		/// </item>
		/// <item>
		/// <term>THREAD_PRIORITY_LOWEST-2</term>
		/// <term>Priority 2 points below the priority class.</term>
		/// </item>
		/// <item>
		/// <term>THREAD_PRIORITY_NORMAL0</term>
		/// <term>Normal priority for the priority class.</term>
		/// </item>
		/// <item>
		/// <term>THREAD_PRIORITY_TIME_CRITICAL15</term>
		/// <term>
		/// Base-priority level of 15 for IDLE_PRIORITY_CLASS, BELOW_NORMAL_PRIORITY_CLASS, NORMAL_PRIORITY_CLASS,
		/// ABOVE_NORMAL_PRIORITY_CLASS, or HIGH_PRIORITY_CLASS processes, and a base-priority level of 31 for REALTIME_PRIORITY_CLASS processes.
		/// </term>
		/// </item>
		/// </list>
		/// </para>
		/// <para>
		/// If the thread has the <c>REALTIME_PRIORITY_CLASS</c> base class, this function can also return one of the following values: -7,
		/// -6, -5, -4, -3, 3, 4, 5, or 6. For more information, see Scheduling Priorities.
		/// </para>
		/// </returns>
		// int WINAPI GetThreadPriority( _In_ HANDLE hThread);// https://msdn.microsoft.com/en-us/library/windows/desktop/ms683235(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("WinBase.h", MSDNShortId = "ms683235")]
		public static extern int GetThreadPriority([In] HTHREAD hThread);

		/// <summary>Retrieves the priority boost control state of the specified thread.</summary>
		/// <param name="hThread">
		/// <para>
		/// A handle to the thread. The handle must have the <c>THREAD_QUERY_INFORMATION</c> or <c>THREAD_QUERY_LIMITED_INFORMATION</c>
		/// access right. For more information, see Thread Security and Access Rights.
		/// </para>
		/// <para><c>Windows Server 2003 and Windows XP:</c> The handle must have the <c>THREAD_QUERY_INFORMATION</c> access right.</para>
		/// </param>
		/// <param name="pDisablePriorityBoost">
		/// A pointer to a variable that receives the priority boost control state. A value of TRUE indicates that dynamic boosting is
		/// disabled. A value of FALSE indicates normal behavior.
		/// </param>
		/// <returns>
		/// <para>
		/// If the function succeeds, the return value is nonzero. In that case, the variable pointed to by the pDisablePriorityBoost
		/// parameter receives the priority boost control state.
		/// </para>
		/// <para>If the function fails, the return value is zero. To get extended error information, call <c>GetLastError</c>.</para>
		/// </returns>
		// BOOL WINAPI GetThreadPriorityBoost( _In_ HANDLE hThread, _Out_ PBOOL pDisablePriorityBoost); https://msdn.microsoft.com/en-us/library/windows/desktop/ms683236(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("WinBase.h", MSDNShortId = "ms683236")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool GetThreadPriorityBoost([In] HTHREAD hThread, [MarshalAs(UnmanagedType.Bool)] out bool pDisablePriorityBoost);

		/// <summary>
		/// Returns the explicit CPU Set assignment of the specified thread, if any assignment was set using the
		/// <c>SetThreadSelectedCpuSets</c> API. If no explicit assignment is set, <c>RequiredIdCount</c> is set to 0 and the function
		/// returns TRUE.
		/// </summary>
		/// <param name="Thread">
		/// Specifies the thread for which to query the selected CPU Sets. This handle must have the THREAD_QUERY_LIMITED_INFORMATION access
		/// right. The value returned by <c>GetCurrentThread</c> can also be specified here.
		/// </param>
		/// <param name="CpuSetIds">Specifies an optional buffer to retrieve the list of CPU Set identifiers.</param>
		/// <param name="CpuSetIdCount">
		/// Specifies the capacity of the buffer specified in <c>CpuSetIds</c>. If the buffer is NULL, this must be 0.
		/// </param>
		/// <param name="RequiredIdCount">
		/// Specifies the required capacity of the buffer to hold the entire list of thread selected CPU Sets. On successful return, this
		/// specifies the number of IDs filled into the buffer.
		/// </param>
		/// <returns>
		/// This API returns TRUE on success. If the buffer is not large enough, the <c>GetLastError</c> value is ERROR_INSUFFICIENT_BUFFER.
		/// This API cannot fail when passed valid parameters and the return buffer is large enough.
		/// </returns>
		// BOOL WINAPI GetThreadSelectedCpuSets( _In_ HANDLE Thread, _Out_opt_ PULONG CpuSetIds, _In_ ULONG CpuSetIdCount, _Out_ PULONG
		// RequiredIdCount); https://msdn.microsoft.com/en-us/library/windows/desktop/mt186426(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("Processthreadapi.h", MSDNShortId = "mt186426")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool GetThreadSelectedCpuSets(HTHREAD Thread, IntPtr CpuSetIds, uint CpuSetIdCount, out uint RequiredIdCount);

		/// <summary>
		/// Returns the explicit CPU Set assignment of the specified thread, if any assignment was set using the
		/// <c>SetThreadSelectedCpuSets</c> API. If no explicit assignment is set, <c>RequiredIdCount</c> is set to 0 and the function
		/// returns TRUE.
		/// </summary>
		/// <param name="Thread">
		/// Specifies the thread for which to query the selected CPU Sets. This handle must have the THREAD_QUERY_LIMITED_INFORMATION access
		/// right. The value returned by <c>GetCurrentThread</c> can also be specified here.
		/// </param>
		/// <returns>The list of CPU Set identifiers.</returns>
		[PInvokeData("Processthreadapi.h", MSDNShortId = "mt186426")]
		public static uint[] GetThreadSelectedCpuSets(HTHREAD Thread)
		{
			var cnt = (uint)Environment.ProcessorCount;
			if (cnt == 0) return new uint[0];
			var iptr = new SafeCoTaskMemHandle((int)cnt * Marshal.SizeOf(typeof(uint)));
			if (!GetThreadSelectedCpuSets(Thread, (IntPtr)iptr, cnt, out cnt)) Win32Error.ThrowLastError();
			return iptr.ToArray<uint>((int)cnt);
		}

		/// <summary>Retrieves timing information for the specified thread.</summary>
		/// <param name="hThread">
		/// <para>
		/// A handle to the thread whose timing information is sought. The handle must have the <c>THREAD_QUERY_INFORMATION</c> or
		/// <c>THREAD_QUERY_LIMITED_INFORMATION</c> access right. For more information, see Thread Security and Access Rights.
		/// </para>
		/// <para><c>Windows Server 2003 and Windows XP:</c> The handle must have the <c>THREAD_QUERY_INFORMATION</c> access right.</para>
		/// </param>
		/// <param name="lpCreationTime">A pointer to a <c>FILETIME</c> structure that receives the creation time of the thread.</param>
		/// <param name="lpExitTime">
		/// A pointer to a <c>FILETIME</c> structure that receives the exit time of the thread. If the thread has not exited, the content of
		/// this structure is undefined.
		/// </param>
		/// <param name="lpKernelTime">
		/// A pointer to a <c>FILETIME</c> structure that receives the amount of time that the thread has executed in kernel mode.
		/// </param>
		/// <param name="lpUserTime">
		/// A pointer to a <c>FILETIME</c> structure that receives the amount of time that the thread has executed in user mode.
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is nonzero.</para>
		/// <para>If the function fails, the return value is zero. To get extended error information, call <c>GetLastError</c>.</para>
		/// </returns>
		// BOOL WINAPI GetThreadTimes( _In_ HANDLE hThread, _Out_ LPFILETIME lpCreationTime, _Out_ LPFILETIME lpExitTime, _Out_ LPFILETIME
		// lpKernelTime, _Out_ LPFILETIME lpUserTime);// https://msdn.microsoft.com/en-us/library/windows/desktop/ms683237(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("WinBase.h", MSDNShortId = "ms683237")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool GetThreadTimes([In] HTHREAD hThread, out FILETIME lpCreationTime, out FILETIME lpExitTime, out FILETIME lpKernelTime,
			out FILETIME lpUserTime);

		/// <summary>Initializes the specified list of attributes for process and thread creation.</summary>
		/// <param name="lpAttributeList">
		/// The attribute list. This parameter can be NULL to determine the buffer size required to support the specified number of attributes.
		/// </param>
		/// <param name="dwAttributeCount">The count of attributes to be added to the list.</param>
		/// <param name="dwFlags">This parameter is reserved and must be zero.</param>
		/// <param name="lpSize">
		/// <para>
		/// If lpAttributeList is not NULL, this parameter specifies the size in bytes of the lpAttributeList buffer on input. On output,
		/// this parameter receives the size in bytes of the initialized attribute list.
		/// </para>
		/// <para>If lpAttributeList is NULL, this parameter receives the required buffer size in bytes.</para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is nonzero.</para>
		/// <para>If the function fails, the return value is zero. To get extended error information, call <c>GetLastError</c>.</para>
		/// </returns>
		// BOOL WINAPI InitializeProcThreadAttributeList( _Out_opt_ LPPROC_THREAD_ATTRIBUTE_LIST lpAttributeList, _In_ DWORD
		// dwAttributeCount, _Reserved_ DWORD dwFlags, _Inout_ PSIZE_T lpSize); https://msdn.microsoft.com/en-us/library/windows/desktop/ms683481(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("WinBase.h", MSDNShortId = "ms683481")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool InitializeProcThreadAttributeList(IntPtr lpAttributeList, uint dwAttributeCount, [Optional] uint dwFlags, ref SizeT lpSize);

		/// <summary>Determines whether the specified process is considered critical.</summary>
		/// <param name="hProcess">
		/// A handle to the process to query. The process must have been opened with <c>PROCESS_QUERY_LIMITED_INFORMATION</c> access.
		/// </param>
		/// <param name="Critical">
		/// A pointer to the <c>BOOL</c> value this function will use to indicate whether the process is considered critical.
		/// </param>
		/// <returns>
		/// This routine returns FALSE on failure. Any other value indicates success. Call <c>GetLastError</c> to query for the specific
		/// error reason on failure.
		/// </returns>
		// BOOL WINAPI IsProcessCritical( _In_ HANDLE hProcess, _Out_ PBOOL Critical); https://msdn.microsoft.com/en-us/library/windows/desktop/dn386160(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("Processthreadsapi.h", MSDNShortId = "dn386160")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool IsProcessCritical([In] HPROCESS hProcess, [MarshalAs(UnmanagedType.Bool)] out bool Critical);

		/// <summary>Determines whether the specified processor feature is supported by the current computer.</summary>
		/// <param name="ProcessorFeature">
		/// <para>The processor feature to be tested. This parameter can be one of the following values.</para>
		/// <para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>PF_ARM_64BIT_LOADSTORE_ATOMIC25</term>
		/// <term>The 64-bit load/store atomic instructions are available.</term>
		/// </item>
		/// <item>
		/// <term>PF_ARM_DIVIDE_INSTRUCTION_AVAILABLE24</term>
		/// <term>The divide instructions are available.</term>
		/// </item>
		/// <item>
		/// <term>PF_ARM_EXTERNAL_CACHE_AVAILABLE26</term>
		/// <term>The external cache is available.</term>
		/// </item>
		/// <item>
		/// <term>PF_ARM_FMAC_INSTRUCTIONS_AVAILABLE27</term>
		/// <term>The floating-point multiply-accumulate instruction is available.</term>
		/// </item>
		/// <item>
		/// <term>PF_ARM_VFP_32_REGISTERS_AVAILABLE18</term>
		/// <term>The VFP/Neon: 32 x 64bit register bank is present. This flag has the same meaning as PF_ARM_VFP_EXTENDED_REGISTERS.</term>
		/// </item>
		/// <item>
		/// <term>PF_3DNOW_INSTRUCTIONS_AVAILABLE7</term>
		/// <term>The 3D-Now instruction set is available.</term>
		/// </item>
		/// <item>
		/// <term>PF_CHANNELS_ENABLED16</term>
		/// <term>The processor channels are enabled.</term>
		/// </item>
		/// <item>
		/// <term>PF_COMPARE_EXCHANGE_DOUBLE2</term>
		/// <term>The atomic compare and exchange operation (cmpxchg) is available.</term>
		/// </item>
		/// <item>
		/// <term>PF_COMPARE_EXCHANGE12814</term>
		/// <term>
		/// The atomic compare and exchange 128-bit operation (cmpxchg16b) is available.Windows Server 2003 and Windows XP/2000: This feature
		/// is not supported.
		/// </term>
		/// </item>
		/// <item>
		/// <term>PF_COMPARE64_EXCHANGE12815</term>
		/// <term>
		/// The atomic compare 64 and exchange 128-bit operation (cmp8xchg16) is available.Windows Server 2003 and Windows XP/2000: This
		/// feature is not supported.
		/// </term>
		/// </item>
		/// <item>
		/// <term>PF_FASTFAIL_AVAILABLE23</term>
		/// <term>_fastfail() is available.</term>
		/// </item>
		/// <item>
		/// <term>PF_FLOATING_POINT_EMULATED1</term>
		/// <term>
		/// Floating-point operations are emulated using a software emulator.This function returns a nonzero value if floating-point
		/// operations are emulated; otherwise, it returns zero.
		/// </term>
		/// </item>
		/// <item>
		/// <term>PF_FLOATING_POINT_PRECISION_ERRATA0</term>
		/// <term>On a Pentium, a floating-point precision error can occur in rare circumstances.</term>
		/// </item>
		/// <item>
		/// <term>PF_MMX_INSTRUCTIONS_AVAILABLE3</term>
		/// <term>The MMX instruction set is available.</term>
		/// </item>
		/// <item>
		/// <term>PF_NX_ENABLED12</term>
		/// <term>
		/// Data execution prevention is enabled.Windows XP/2000: This feature is not supported until Windows XP with SP2 and Windows Server
		/// 2003 with SP1.
		/// </term>
		/// </item>
		/// <item>
		/// <term>PF_PAE_ENABLED9</term>
		/// <term>
		/// The processor is PAE-enabled. For more information, see Physical Address Extension.All x64 processors always return a nonzero
		/// value for this feature.
		/// </term>
		/// </item>
		/// <item>
		/// <term>PF_RDTSC_INSTRUCTION_AVAILABLE8</term>
		/// <term>The RDTSC instruction is available.</term>
		/// </item>
		/// <item>
		/// <term>PF_RDWRFSGSBASE_AVAILABLE22</term>
		/// <term>RDFSBASE, RDGSBASE, WRFSBASE, and WRGSBASE instructions are available.</term>
		/// </item>
		/// <item>
		/// <term>PF_SECOND_LEVEL_ADDRESS_TRANSLATION20</term>
		/// <term>Second Level Address Translation is supported by the hardware.</term>
		/// </item>
		/// <item>
		/// <term>PF_SSE3_INSTRUCTIONS_AVAILABLE13</term>
		/// <term>The SSE3 instruction set is available.Windows Server 2003 and Windows XP/2000: This feature is not supported.</term>
		/// </item>
		/// <item>
		/// <term>PF_VIRT_FIRMWARE_ENABLED21</term>
		/// <term>Virtualization is enabled in the firmware.</term>
		/// </item>
		/// <item>
		/// <term>PF_XMMI_INSTRUCTIONS_AVAILABLE6</term>
		/// <term>The SSE instruction set is available.</term>
		/// </item>
		/// <item>
		/// <term>PF_XMMI64_INSTRUCTIONS_AVAILABLE10</term>
		/// <term>The SSE2 instruction set is available.Windows 2000: This feature is not supported.</term>
		/// </item>
		/// <item>
		/// <term>PF_XSAVE_ENABLED17</term>
		/// <term>
		/// The processor implements the XSAVE and XRSTOR instructions.Windows Server 2008, Windows Vista, Windows Server 2003 and Windows
		/// XP/2000: This feature is not supported until Windows 7 and Windows Server 2008 R2.
		/// </term>
		/// </item>
		/// </list>
		/// </para>
		/// </param>
		/// <returns>
		/// <para>If the feature is supported, the return value is a nonzero value.</para>
		/// <para>If the feature is not supported, the return value is zero.</para>
		/// <para>
		/// If the HAL does not support detection of the feature, whether or not the hardware supports the feature, the return value is also zero.
		/// </para>
		/// </returns>
		// BOOL WINAPI IsProcessorFeaturePresent( _In_ DWORD ProcessorFeature); https://msdn.microsoft.com/en-us/library/windows/desktop/ms724482(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("Winbase.h", MSDNShortId = "ms724482")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool IsProcessorFeaturePresent(PROCESSOR_FEATURE ProcessorFeature);

		/// <summary>Opens an existing local process object.</summary>
		/// <param name="dwDesiredAccess">
		/// <para>
		/// The access to the process object. This access right is checked against the security descriptor for the process. This parameter
		/// can be one or more of the process access rights.
		/// </para>
		/// <para>
		/// If the caller has enabled the SeDebugPrivilege privilege, the requested access is granted regardless of the contents of the
		/// security descriptor.
		/// </para>
		/// </param>
		/// <param name="bInheritHandle">
		/// If this value is TRUE, processes created by this process will inherit the handle. Otherwise, the processes do not inherit this handle.
		/// </param>
		/// <param name="dwProcessId">
		/// <para>The identifier of the local process to be opened.</para>
		/// <para>
		/// If the specified process is the System Process (0x00000000), the function fails and the last error code is
		/// ERROR_INVALID_PARAMETER. If the specified process is the Idle process or one of the CSRSS processes, this function fails and the
		/// last error code is ERROR_ACCESS_DENIED because their access restrictions prevent user-level code from opening them.
		/// </para>
		/// <para>
		/// If you are using <c>GetCurrentProcessId</c> as an argument to this function, consider using <c>GetCurrentProcess</c> instead of
		/// OpenProcess, for improved performance.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is an open handle to the specified process.</para>
		/// <para>If the function fails, the return value is NULL. To get extended error information, call <c>GetLastError</c>.</para>
		/// </returns>
		// HANDLE WINAPI OpenProcess( _In_ DWORD dwDesiredAccess, _In_ BOOL bInheritHandle, _In_ DWORD dwProcessId); https://msdn.microsoft.com/en-us/library/windows/desktop/ms684320(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("WinBase.h", MSDNShortId = "ms684320")]
		public static extern SafeHPROCESS OpenProcess(ACCESS_MASK dwDesiredAccess, [MarshalAs(UnmanagedType.Bool)] bool bInheritHandle, uint dwProcessId);

		/// <summary>Opens an existing thread object.</summary>
		/// <param name="dwDesiredAccess">
		/// <para>
		/// The access to the thread object. This access right is checked against the security descriptor for the thread. This parameter can
		/// be one or more of the thread access rights.
		/// </para>
		/// <para>
		/// If the caller has enabled the SeDebugPrivilege privilege, the requested access is granted regardless of the contents of the
		/// security descriptor.
		/// </para>
		/// </param>
		/// <param name="bInheritHandle">
		/// If this value is TRUE, processes created by this process will inherit the handle. Otherwise, the processes do not inherit this handle.
		/// </param>
		/// <param name="dwThreadId">The identifier of the thread to be opened.</param>
		/// <returns>
		/// <para>If the function succeeds, the return value is an open handle to the specified thread.</para>
		/// <para>If the function fails, the return value is NULL. To get extended error information, call <c>GetLastError</c>.</para>
		/// </returns>
		// HANDLE WINAPI OpenThread( _In_ DWORD dwDesiredAccess, _In_ BOOL bInheritHandle, _In_ DWORD dwThreadId); https://msdn.microsoft.com/en-us/library/windows/desktop/ms684335(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("WinBase.h", MSDNShortId = "ms684335")]
		public static extern SafeHTHREAD OpenThread(ACCESS_MASK dwDesiredAccess, [MarshalAs(UnmanagedType.Bool)] bool bInheritHandle, uint dwThreadId);

		/// <summary>Retrieves the Remote Desktop Services session associated with a specified process.</summary>
		/// <param name="dwProcessId">
		/// Specifies a process identifier. Use the <c>GetCurrentProcessId</c> function to retrieve the process identifier for the current process.
		/// </param>
		/// <param name="pSessionId">
		/// Pointer to a variable that receives the identifier of the Remote Desktop Services session under which the specified process is
		/// running. To retrieve the identifier of the session currently attached to the console, use the <c>WTSGetActiveConsoleSessionId</c> function.
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is a nonzero value.</para>
		/// <para>If the function fails, the return value is zero. To get extended error information, call <c>GetLastError</c>.</para>
		/// </returns>
		// BOOL ProcessIdToSessionId( _In_ DWORD dwProcessId, _Out_ DWORD *pSessionId ); https://msdn.microsoft.com/en-us/library/aa382990(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("Winbase.h", MSDNShortId = "aa382990")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool ProcessIdToSessionId(uint dwProcessId, out uint pSessionId);

		/// <summary>Retrieves the affinity update mode of the specified process.</summary>
		/// <param name="ProcessHandle">
		/// A handle to the process. The handle must have the PROCESS_QUERY_INFORMATION or PROCESS_QUERY_LIMITED_INFORMATION access right.
		/// For more information, see Process Security and Access Rights.
		/// </param>
		/// <param name="lpdwFlags">
		/// <para>The affinity update mode. This parameter can be one of the following values.</para>
		/// <para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>0</term>
		/// <term>Dynamic update of the process affinity by the system is disabled.</term>
		/// </item>
		/// <item>
		/// <term>PROCESS_AFFINITY_ENABLE_AUTO_UPDATE0x00000001UL</term>
		/// <term>Dynamic update of the process affinity by the system is enabled.</term>
		/// </item>
		/// </list>
		/// </para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is nonzero.</para>
		/// <para>If the function fails, the return value is zero. To get extended error information, call <c>GetLastError</c>.</para>
		/// </returns>
		// BOOL WINAPI QueryProcessAffinityUpdateMode( _In_ HANDLE ProcessHandle, _Out_opt_ DWORD lpdwFlags); https://msdn.microsoft.com/en-us/library/windows/desktop/bb309062(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("WinBase.h", MSDNShortId = "bb309062")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool QueryProcessAffinityUpdateMode(HPROCESS ProcessHandle, out PROCESS_AFFINITY_MODE lpdwFlags);

		/// <summary>Queries the value associated with a protected policy.</summary>
		/// <param name="PolicyGuid">The globally-unique identifier of the policy to query.</param>
		/// <param name="PolicyValue">Receives the value that the supplied policy is set to.</param>
		/// <returns>True if the function succeeds; otherwise, false.</returns>
		// BOOL WINAPI QueryProtectedPolicy( _In_ LPCGUID PolicyGuid, _Out_ PULONG_PTR PolicyValue); https://msdn.microsoft.com/en-us/library/windows/desktop/dn893591(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("Winbase.h", MSDNShortId = "dn893591")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool QueryProtectedPolicy(in Guid PolicyGuid, out IntPtr PolicyValue);

		/// <summary>Adds a user-mode asynchronous procedure call (APC) object to the APC queue of the specified thread.</summary>
		/// <param name="pfnAPC">
		/// A pointer to the application-supplied APC function to be called when the specified thread performs an alertable wait operation.
		/// For more information, see APCProc.
		/// </param>
		/// <param name="hThread">
		/// A handle to the thread. The handle must have the <c>THREAD_SET_CONTEXT</c> access right. For more information, see
		/// Synchronization Object Security and Access Rights.
		/// </param>
		/// <param name="dwData">A single value that is passed to the APC function pointed to by the pfnAPC parameter.</param>
		/// <returns>
		/// <para>If the function succeeds, the return value is nonzero.</para>
		/// <para>
		/// If the function fails, the return value is zero. To get extended error information, call GetLastError. <c>Windows Server 2003 and
		/// Windows XP:</c> There are no error values defined for this function that can be retrieved by calling GetLastError.
		/// </para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The APC support provided in the operating system allows an application to queue an APC object to a thread. To ensure successful
		/// execution of functions used by the APC, APCs should be queued only to threads in the caller's process.
		/// </para>
		/// <para>
		/// <c>Note</c> Queuing APCs to threads outside the caller's process is not recommended for a number of reasons. DLL rebasing can
		/// cause the addresses of functions used by the APC to be incorrect when the functions are executed outside the caller's process.
		/// Similarly, if a 64-bit process queues an APC to a 32-bit process or vice versa, addresses will be incorrect and the application
		/// will crash. Other factors can prevent successful function execution, even if the address is known.
		/// </para>
		/// <para>
		/// Each thread has its own APC queue. The queuing of an APC is a request for the thread to call the APC function. The operating
		/// system issues a software interrupt to direct the thread to call the APC function.
		/// </para>
		/// <para>
		/// When a user-mode APC is queued, the thread is not directed to call the APC function unless it is in an alertable state. After the
		/// thread is in an alertable state, the thread handles all pending APCs in first in, first out (FIFO) order, and the wait operation
		/// returns <c>WAIT_IO_COMPLETION</c>. A thread enters an alertable state by using SleepEx, SignalObjectAndWait,
		/// WaitForSingleObjectEx, WaitForMultipleObjectsEx, or MsgWaitForMultipleObjectsEx to perform an alertable wait operation.
		/// </para>
		/// <para>
		/// If an application queues an APC before the thread begins running, the thread begins by calling the APC function. After the thread
		/// calls an APC function, it calls the APC functions for all APCs in its APC queue.
		/// </para>
		/// <para>
		/// It is possible to sleep or wait for an object within the APC. If you perform an alertable wait inside an APC, it will recursively
		/// dispatch the APCs. This can cause a stack overflow.
		/// </para>
		/// <para>
		/// When the thread is terminated using the ExitThread or TerminateThread function, the APCs in its APC queue are lost. The APC
		/// functions are not called.
		/// </para>
		/// <para>
		/// When the thread is in the process of being terminated, calling QueueUserAPC to add to the thread's APC queue will fail with
		/// <c>(31) ERROR_GEN_FAILURE</c>.
		/// </para>
		/// <para>
		/// Note that the ReadFileEx, SetWaitableTimer, and WriteFileEx functions are implemented using an APC as the completion notification
		/// callback mechanism.
		/// </para>
		/// <para>
		/// To compile an application that uses this function, define <c>_WIN32_WINNT</c> as 0x0400 or later. For more information, see Using
		/// the Windows Headers.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/processthreadsapi/nf-processthreadsapi-queueuserapc DWORD QueueUserAPC(
		// PAPCFUNC pfnAPC, HANDLE hThread, ULONG_PTR dwData );
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("processthreadsapi.h", MSDNShortId = "5b141372-7c95-4eb2-987b-64fdf7d0783d")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool QueueUserAPC(PAPCFUNC pfnAPC, [In] HTHREAD hThread, IntPtr dwData);

		/// <summary>
		/// Decrements a thread's suspend count. When the suspend count is decremented to zero, the execution of the thread is resumed.
		/// </summary>
		/// <param name="hThread">
		/// <para>A handle to the thread to be restarted.</para>
		/// <para>This handle must have the THREAD_SUSPEND_RESUME access right. For more information, see Thread Security and Access Rights.</para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is the thread's previous suspend count.</para>
		/// <para>If the function fails, the return value is (DWORD) -1. To get extended error information, call <c>GetLastError</c>.</para>
		/// </returns>
		// DWORD WINAPI ResumeThread( _In_ HANDLE hThread); https://msdn.microsoft.com/en-us/library/windows/desktop/ms685086(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("WinBase.h", MSDNShortId = "ms685086")]
		public static extern uint ResumeThread([In] HTHREAD hThread);

		/// <summary>
		/// Sets the priority class for the specified process. This value together with the priority value of each thread of the process
		/// determines each thread's base priority level.
		/// </summary>
		/// <param name="hProcess">
		/// <para>A handle to the process.</para>
		/// <para>
		/// The handle must have the <c>PROCESS_SET_INFORMATION</c> access right. For more information, see Process Security and Access Rights.
		/// </para>
		/// </param>
		/// <param name="dwPriorityClass">
		/// <para>The priority class for the process. This parameter can be one of the following values.</para>
		/// <para>
		/// <list type="table">
		/// <listheader>
		/// <term>Priority</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>ABOVE_NORMAL_PRIORITY_CLASS0x00008000</term>
		/// <term>Process that has priority above NORMAL_PRIORITY_CLASS but below HIGH_PRIORITY_CLASS.</term>
		/// </item>
		/// <item>
		/// <term>BELOW_NORMAL_PRIORITY_CLASS0x00004000</term>
		/// <term>Process that has priority above IDLE_PRIORITY_CLASS but below NORMAL_PRIORITY_CLASS.</term>
		/// </item>
		/// <item>
		/// <term>HIGH_PRIORITY_CLASS0x00000080</term>
		/// <term>
		/// Process that performs time-critical tasks that must be executed immediately. The threads of the process preempt the threads of
		/// normal or idle priority class processes. An example is the Task List, which must respond quickly when called by the user,
		/// regardless of the load on the operating system. Use extreme care when using the high-priority class, because a high-priority
		/// class application can use nearly all available CPU time.
		/// </term>
		/// </item>
		/// <item>
		/// <term>IDLE_PRIORITY_CLASS0x00000040</term>
		/// <term>
		/// Process whose threads run only when the system is idle. The threads of the process are preempted by the threads of any process
		/// running in a higher priority class. An example is a screen saver. The idle-priority class is inherited by child processes.
		/// </term>
		/// </item>
		/// <item>
		/// <term>NORMAL_PRIORITY_CLASS0x00000020</term>
		/// <term>Process with no special scheduling needs.</term>
		/// </item>
		/// <item>
		/// <term>PROCESS_MODE_BACKGROUND_BEGIN0x00100000</term>
		/// <term>
		/// Begin background processing mode. The system lowers the resource scheduling priorities of the process (and its threads) so that
		/// it can perform background work without significantly affecting activity in the foreground.This value can be specified only if
		/// hProcess is a handle to the current process. The function fails if the process is already in background processing mode.Windows
		/// Server 2003 and Windows XP: This value is not supported.
		/// </term>
		/// </item>
		/// <item>
		/// <term>PROCESS_MODE_BACKGROUND_END0x00200000</term>
		/// <term>
		/// End background processing mode. The system restores the resource scheduling priorities of the process (and its threads) as they
		/// were before the process entered background processing mode.This value can be specified only if hProcess is a handle to the
		/// current process. The function fails if the process is not in background processing mode.Windows Server 2003 and Windows XP: This
		/// value is not supported.
		/// </term>
		/// </item>
		/// <item>
		/// <term>REALTIME_PRIORITY_CLASS0x00000100</term>
		/// <term>
		/// Process that has the highest possible priority. The threads of the process preempt the threads of all other processes, including
		/// operating system processes performing important tasks. For example, a real-time process that executes for more than a very brief
		/// interval can cause disk caches not to flush or cause the mouse to be unresponsive.
		/// </term>
		/// </item>
		/// </list>
		/// </para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is nonzero.</para>
		/// <para>If the function fails, the return value is zero. To get extended error information, call <c>GetLastError</c>.</para>
		/// </returns>
		// BOOL WINAPI SetPriorityClass( _In_ HANDLE hProcess, _In_ DWORD dwPriorityClass); https://msdn.microsoft.com/en-us/library/windows/desktop/ms686219(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("WinBase.h", MSDNShortId = "ms686219")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool SetPriorityClass([In] HPROCESS hProcess, CREATE_PROCESS dwPriorityClass);

		/// <summary>Sets the affinity update mode of the specified process.</summary>
		/// <param name="ProcessHandle">A handle to the process. This handle must be returned by the <c>GetCurrentProcess</c> function.</param>
		/// <param name="dwFlags">
		/// <para>The affinity update mode. This parameter can be one of the following values.</para>
		/// <para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>0</term>
		/// <term>Disables dynamic update of the process affinity by the system.</term>
		/// </item>
		/// <item>
		/// <term>PROCESS_AFFINITY_ENABLE_AUTO_UPDATE0x00000001UL</term>
		/// <term>Enables dynamic update of the process affinity by the system.</term>
		/// </item>
		/// </list>
		/// </para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is nonzero.</para>
		/// <para>If the function fails, the return value is zero. To get extended error information, call <c>GetLastError</c>.</para>
		/// </returns>
		// BOOL WINAPI SetProcessAffinityUpdateMode( _In_ HANDLE ProcessHandle, _In_ DWORD dwFlags); https://msdn.microsoft.com/en-us/library/windows/desktop/bb309063(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("WinBase.h", MSDNShortId = "bb309063")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool SetProcessAffinityUpdateMode([In] HPROCESS ProcessHandle, PROCESS_AFFINITY_MODE dwFlags);

		/// <summary>
		/// Sets the default CPU Sets assignment for threads in the specified process. Threads that are created, which don’t have CPU Sets
		/// explicitly set using <c>SetThreadSelectedCpuSets</c>, will inherit the sets specified by <c>SetProcessDefaultCpuSets</c> automatically.
		/// </summary>
		/// <param name="Process">
		/// Specifies the process for which to set the default CPU Sets. This handle must have the PROCESS_SET_LIMITED_INFORMATION access
		/// right. The value returned by <c>GetCurrentProcess</c> can also be specified here.
		/// </param>
		/// <param name="CpuSetIds">
		/// Specifies the list of CPU Set IDs to set as the process default CPU set. If this is NULL, the <c>SetProcessDefaultCpuSets</c>
		/// clears out any assignment.
		/// </param>
		/// <param name="CpuSetIdCound">
		/// Specifies the number of IDs in the list passed in the <c>CpuSetIds</c> argument. If that value is NULL, this should be 0.
		/// </param>
		/// <returns>This function cannot fail when passed valid parameters.</returns>
		// BOOL WINAPI SetProcessDefaultCpuSets( _In_ HANDLE Process, _In_opt_ ULONG CpuSetIds, _In_ ULONG CpuSetIdCound); https://msdn.microsoft.com/en-us/library/windows/desktop/mt186427(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("Processthreadapi.h", MSDNShortId = "mt186427")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool SetProcessDefaultCpuSets([In] HPROCESS Process, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] uint[] CpuSetIds, uint CpuSetIdCound);

		/// <summary>Sets information for the specified process.</summary>
		/// <param name="hProcess">
		/// A handle to the process. This handle must have the <c>PROCESS_SET_INFORMATION</c> access right. For more information, see Process
		/// Security and Access Rights.
		/// </param>
		/// <param name="ProcessInformationClass">
		/// The class of information to set. The only supported values are <c>ProcessMemoryPriority</c> and <c>ProcessPowerThrottling</c>.
		/// </param>
		/// <param name="ProcessInformation">
		/// <para>Pointer to an object that contains the type of information specified by the ProcessInformationClass parameter.</para>
		/// <para>
		/// If the ProcessInformationClass parameter is <c>ProcessMemoryPriority</c>, this parameter must point to a
		/// <c>MEMORY_PRIORITY_INFORMATION</c> structure.
		/// </para>
		/// <para>
		/// If the ProcessInformationClass parameter is <c>ProcessPowerThrottling</c>, this parameter must point to a
		/// <c>PROCESS_POWER_THROTTLING_STATE</c> structure.
		/// </para>
		/// </param>
		/// <param name="ProcessInformationSize">
		/// <para>The size in bytes of the structure specified by the ProcessInformation parameter.</para>
		/// <para>If the ProcessInformationClass parameter is <c>ProcessMemoryPriority</c>, this parameter must be .</para>
		/// <para>If the ProcessInformationClass parameter is <c>ProcessPowerThrottling</c>, this parameter must be .</para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is nonzero.</para>
		/// <para>If the function fails, the return value is zero. To get extended error information, call <c>GetLastError</c>.</para>
		/// </returns>
		// BOOL WINAPI SetProcessInformation( _In_ HANDLE hProcess, _In_ PROCESS_INFORMATION_CLASS ProcessInformationClass,
		// _In_reads_bytes_(ProcessInformationSize) ProcessInformation, _In_ DWORD ProcessInformationSize); https://msdn.microsoft.com/en-us/library/windows/desktop/hh448389(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("WinBase.h", MSDNShortId = "hh448389")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool SetProcessInformation([In] HPROCESS hProcess, PROCESS_INFORMATION_CLASS ProcessInformationClass, IntPtr ProcessInformation, uint ProcessInformationSize);

		/// <summary>Sets information for the specified process.</summary>
		/// <param name="hProcess">
		/// A handle to the process. This handle must have the <c>PROCESS_SET_INFORMATION</c> access right. For more information, see Process
		/// Security and Access Rights.
		/// </param>
		/// <param name="ProcessInformationClass">
		/// The class of information to set. The only supported values are <c>ProcessMemoryPriority</c> and <c>ProcessPowerThrottling</c>.
		/// </param>
		/// <param name="ProcessInformation">
		/// <para>Pointer to an object that contains the type of information specified by the ProcessInformationClass parameter.</para>
		/// <para>
		/// If the ProcessInformationClass parameter is <c>ProcessMemoryPriority</c>, this parameter must point to a
		/// <c>MEMORY_PRIORITY_INFORMATION</c> structure.
		/// </para>
		/// <para>
		/// If the ProcessInformationClass parameter is <c>ProcessPowerThrottling</c>, this parameter must point to a
		/// <c>PROCESS_POWER_THROTTLING_STATE</c> structure.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is nonzero.</para>
		/// <para>If the function fails, the return value is zero. To get extended error information, call <c>GetLastError</c>.</para>
		/// </returns>
		[PInvokeData("WinBase.h", MSDNShortId = "hh448389")]
		public static bool SetProcessInformation<T>([In] HPROCESS hProcess, PROCESS_INFORMATION_CLASS ProcessInformationClass, in T ProcessInformation) where T : struct
		{
			if (!CorrespondingTypeAttribute.CanSet(ProcessInformationClass, typeof(T))) throw new ArgumentException($"{ProcessInformationClass} cannot be used to set values of type {typeof(T)}.");
			using (var mem = SafeHGlobalHandle.CreateFromStructure(ProcessInformation))
				return SetProcessInformation(hProcess, ProcessInformationClass, (IntPtr)mem, (uint)mem.Size);
		}

		/// <summary>
		/// Sets a mitigation policy for the calling process. Mitigation policies enable a process to harden itself against various types of attacks.
		/// </summary>
		/// <param name="MitigationPolicy">
		/// <para>The mitigation policy to apply. This parameter can be one of the following values.</para>
		/// <para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>ProcessDEPPolicy</term>
		/// <term>
		/// The data execution prevention (DEP) policy of the process.The lpBuffer parameter points to a PROCESS_MITIGATION_DEP_POLICY
		/// structure that specifies the DEP policy flags.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ProcessASLRPolicy</term>
		/// <term>
		/// The Address Space Layout Randomization (ASLR) policy of the process.The lpBuffer parameter points to a
		/// PROCESS_MITIGATION_ASLR_POLICY structure that specifies the ASLR policy flags.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ProcessDynamicCodePolicy</term>
		/// <term>
		/// The dynamic code policy of the process. When turned on, the process cannot generate dynamic code or modify existing executable
		/// code.The lpBuffer parameter points to a PROCESS_MITIGATION_DYNAMIC_CODE_POLICY structure that specifies the dynamic code policy flags.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ProcessStrictHandleCheckPolicy</term>
		/// <term>
		/// The process will receive a fatal error if it manipulates a handle that is not valid.The lpBuffer parameter points to a
		/// PROCESS_MITIGATION_STRICT_HANDLE_CHECK_POLICY structure that specifies the handle check policy flags.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ProcessSystemCallDisablePolicy</term>
		/// <term>
		/// Disables the ability to use NTUser/GDI functions at the lowest layer.The lpBuffer parameter points to a
		/// PROCESS_MITIGATION_SYSTEM_CALL_DISABLE_POLICY structure that specifies the system call disable policy flags.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ProcessMitigationOptionsMask</term>
		/// <term>
		/// Returns the mask of valid bits for all the mitigation options on the system. An application can set many mitigation options
		/// without querying the operating system for mitigation options by combining bitwise with the mask to exclude all non-supported bits
		/// at once.The lpBuffer parameter points to a ULONG64 bit vector for the mask, or to accommodate more than 64 bits, a two-element
		/// array of ULONG64 bit vectors.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ProcessExtensionPointDisablePolicy</term>
		/// <term>
		/// The lpBuffer parameter points to a PROCESS_MITIGATION_EXTENSION_POINT_DISABLE_POLICY structure that specifies the extension point
		/// disable policy flags.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ProcessControlFlowGuardPolicy</term>
		/// <term>
		/// The Control Flow Guard (CFG) policy of the process.The lpBuffer parameter points to a
		/// PROCESS_MITIGATION_CONTROL_FLOW_GUARD_POLICY structure that specifies the CFG policy flags.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ProcessSignaturePolicy</term>
		/// <term>
		/// The policy of a process that can restrict image loading to those images that are either signed by Microsoft, by the Windows
		/// Store, or by Microsoft, the Windows Store and the Windows Hardware Quality Labs (WHQL).he lpBuffer parameter points to a
		/// PROCESS_MITIGATION_BINARY_SIGNATURE_POLICY structure that specifies the signature policy flags.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ProcessFontDisablePolicy</term>
		/// <term>
		/// The policy regarding font loading for the process. When turned on, the process cannot load non-system fonts.The lpBuffer
		/// parameter points to a PROCESS_MITIGATION_FONT_DISABLE_POLICY structure that specifies the policy flags for font loading.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ProcessImageLoadPolicy</term>
		/// <term>
		/// The policy regarding image loading for the process, which determines the types of executable images that are allowed to be mapped
		/// into the process. When turned on, images cannot be loaded from some locations, such a remote devices or files that have the low
		/// mandatory label.The lpBuffer parameter points to a PROCESS_MITIGATION_IMAGE_LOAD_POLICY structure that specifies the policy flags
		/// for image loading.
		/// </term>
		/// </item>
		/// </list>
		/// </para>
		/// </param>
		/// <param name="lpBuffer">
		/// <para>
		/// If the MitigationPolicy parameter is <c>ProcessDEPPolicy</c>, this parameter points to a <c>PROCESS_MITIGATION_DEP_POLICY</c>
		/// structure that specifies the DEP policy flags.
		/// </para>
		/// <para>
		/// If the MitigationPolicy parameter is <c>ProcessASLRPolicy</c>, this parameter points to a <c>PROCESS_MITIGATION_ASLR_POLICY</c>
		/// structure that specifies the ASLR policy flags.
		/// </para>
		/// <para>
		/// If the MitigationPolicy parameter is <c>ProcessImageLoadPolicy</c>, this parameter points to a
		/// <c>PROCESS_MITIGATION_IMAGE_LOAD_POLICY</c> structure that receives the policy flags for image loading.
		/// </para>
		/// <para>
		/// If the MitigationPolicy parameter is <c>ProcessStrictHandleCheckPolicy</c>, this parameter points to a
		/// <c>PROCESS_MITIGATION_STRICT_HANDLE_CHECK_POLICY</c> structure that specifies the handle check policy flags.
		/// </para>
		/// <para>
		/// If the MitigationPolicy parameter is <c>ProcessSystemCallDisablePolicy</c>, this parameter points to a
		/// <c>PROCESS_MITIGATION_SYSTEM_CALL_DISABLE_POLICY</c> structure that specifies the system call disable policy flags.
		/// </para>
		/// <para>
		/// If the MitigationPolicy parameter is <c>ProcessMitigationOptionsMask</c>, this parameter points to a <c>ULONG64</c> bit vector
		/// for the mask, or to accommodate more than 64 bits, a two-element array of <c>ULONG64</c> bit vectors.
		/// </para>
		/// <para>
		/// If the MitigationPolicy parameter is <c>ProcessExtensionPointDisablePolicy</c>, this parameter points to a
		/// <c>PROCESS_MITIGATION_EXTENSION_POINT_DISABLE_POLICY</c> structure that specifies the extension point disable policy flags.
		/// </para>
		/// <para>
		/// If the MitigationPolicy parameter is <c>ProcessControlFlowGuardPolicy</c>, this parameter points to a
		/// <c>PROCESS_MITIGATION_CONTROL_FLOW_GUARD_POLICY</c> structure that specifies the CFG policy flags.
		/// </para>
		/// <para>
		/// If the MitigationPolicy parameter is <c>ProcessSignaturePolicy</c>, this parameter points to a
		/// <c>PROCESS_MITIGATION_BINARY_SIGNATURE_POLICY</c> structure that specifies the signature policy flags.
		/// </para>
		/// <para>
		/// If the MitigationPolicy parameter is <c>ProcessFontDisablePolicy</c>, this parameter points to a
		/// <c>PROCESS_MITIGATION_FONT_DISABLE_POLICY</c> structure that specifies the policy flags for font loading.
		/// </para>
		/// <para>
		/// If the MitigationPolicy parameter is <c>ProcessImageLoadPolicy</c>, this parameter points to a
		/// <c>PROCESS_MITIGATION_IMAGE_LOAD_POLICY</c> structure that specifies the policy flags for image loading.
		/// </para>
		/// </param>
		/// <param name="dwLength">The size of lpBuffer, in bytes.</param>
		/// <returns>
		/// If the function succeeds, it returns <c>TRUE</c>. If the function fails, it returns <c>FALSE</c>. To retrieve error values
		/// defined for this function, call <c>GetLastError</c>.
		/// </returns>
		// BOOL WINAPI SetProcessMitigationPolicy( _In_ PROCESS_MITIGATION_POLICY MitigationPolicy, _In_ PVOID lpBuffer, _In_ SIZE_T
		// dwLength); https://msdn.microsoft.com/en-us/library/windows/desktop/hh769088(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("Processthreadsapi.h", MSDNShortId = "hh769088")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool SetProcessMitigationPolicy(PROCESS_MITIGATION_POLICY MitigationPolicy, IntPtr lpBuffer, SizeT dwLength);

		/// <summary>
		/// Sets a mitigation policy for the calling process. Mitigation policies enable a process to harden itself against various types of attacks.
		/// </summary>
		/// <typeparam name="T">The type of the value being set.</typeparam>
		/// <param name="MitigationPolicy">
		/// <para>The mitigation policy to apply. This parameter can be one of the following values.</para>
		/// <para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>ProcessDEPPolicy</term>
		/// <term>
		/// The data execution prevention (DEP) policy of the process.The lpBuffer parameter points to a PROCESS_MITIGATION_DEP_POLICY
		/// structure that specifies the DEP policy flags.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ProcessASLRPolicy</term>
		/// <term>
		/// The Address Space Layout Randomization (ASLR) policy of the process.The lpBuffer parameter points to a
		/// PROCESS_MITIGATION_ASLR_POLICY structure that specifies the ASLR policy flags.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ProcessDynamicCodePolicy</term>
		/// <term>
		/// The dynamic code policy of the process. When turned on, the process cannot generate dynamic code or modify existing executable
		/// code.The lpBuffer parameter points to a PROCESS_MITIGATION_DYNAMIC_CODE_POLICY structure that specifies the dynamic code policy flags.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ProcessStrictHandleCheckPolicy</term>
		/// <term>
		/// The process will receive a fatal error if it manipulates a handle that is not valid.The lpBuffer parameter points to a
		/// PROCESS_MITIGATION_STRICT_HANDLE_CHECK_POLICY structure that specifies the handle check policy flags.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ProcessSystemCallDisablePolicy</term>
		/// <term>
		/// Disables the ability to use NTUser/GDI functions at the lowest layer.The lpBuffer parameter points to a
		/// PROCESS_MITIGATION_SYSTEM_CALL_DISABLE_POLICY structure that specifies the system call disable policy flags.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ProcessMitigationOptionsMask</term>
		/// <term>
		/// Returns the mask of valid bits for all the mitigation options on the system. An application can set many mitigation options
		/// without querying the operating system for mitigation options by combining bitwise with the mask to exclude all non-supported bits
		/// at once.The lpBuffer parameter points to a ULONG64 bit vector for the mask, or to accommodate more than 64 bits, a two-element
		/// array of ULONG64 bit vectors.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ProcessExtensionPointDisablePolicy</term>
		/// <term>
		/// The lpBuffer parameter points to a PROCESS_MITIGATION_EXTENSION_POINT_DISABLE_POLICY structure that specifies the extension point
		/// disable policy flags.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ProcessControlFlowGuardPolicy</term>
		/// <term>
		/// The Control Flow Guard (CFG) policy of the process.The lpBuffer parameter points to a
		/// PROCESS_MITIGATION_CONTROL_FLOW_GUARD_POLICY structure that specifies the CFG policy flags.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ProcessSignaturePolicy</term>
		/// <term>
		/// The policy of a process that can restrict image loading to those images that are either signed by Microsoft, by the Windows
		/// Store, or by Microsoft, the Windows Store and the Windows Hardware Quality Labs (WHQL).he lpBuffer parameter points to a
		/// PROCESS_MITIGATION_BINARY_SIGNATURE_POLICY structure that specifies the signature policy flags.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ProcessFontDisablePolicy</term>
		/// <term>
		/// The policy regarding font loading for the process. When turned on, the process cannot load non-system fonts.The lpBuffer
		/// parameter points to a PROCESS_MITIGATION_FONT_DISABLE_POLICY structure that specifies the policy flags for font loading.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ProcessImageLoadPolicy</term>
		/// <term>
		/// The policy regarding image loading for the process, which determines the types of executable images that are allowed to be mapped
		/// into the process. When turned on, images cannot be loaded from some locations, such a remote devices or files that have the low
		/// mandatory label.The lpBuffer parameter points to a PROCESS_MITIGATION_IMAGE_LOAD_POLICY structure that specifies the policy flags
		/// for image loading.
		/// </term>
		/// </item>
		/// </list>
		/// </para>
		/// </param>
		/// <param name="value">The value. This must correspond to the <paramref name="MitigationPolicy"/> value.</param>
		/// <returns>
		/// If the function succeeds, it returns <c>TRUE</c>. If the function fails, it returns <c>FALSE</c>. To retrieve error values
		/// defined for this function, call <c>GetLastError</c>.
		/// </returns>
		public static bool SetProcessMitigationPolicy<T>(PROCESS_MITIGATION_POLICY MitigationPolicy, in T value)
		{
			if (MitigationPolicy == PROCESS_MITIGATION_POLICY.ProcessMitigationOptionsMask)
			{
				if (!(value is ulong || value is ulong[])) throw new ArgumentException($"{MitigationPolicy} cannot be used to set values of type {typeof(T)}.");
				using (var ptr = new PinnedObject(value))
					return SetProcessMitigationPolicy(MitigationPolicy, ptr, value is ulong ? 8U : 16U);
			}

			if (!CorrespondingTypeAttribute.CanSet(MitigationPolicy, typeof(T))) throw new ArgumentException($"{MitigationPolicy} cannot be used to set values of type {typeof(T)}.");
			using (var ptr = SafeCoTaskMemHandle.CreateFromStructure(value))
				return SetProcessMitigationPolicy(MitigationPolicy, (IntPtr)ptr, (uint)ptr.Size);
		}

		/// <summary>
		/// Disables or enables the ability of the system to temporarily boost the priority of the threads of the specified process.
		/// </summary>
		/// <param name="hProcess">
		/// A handle to the process. This handle must have the PROCESS_SET_INFORMATION access right. For more information, see Process
		/// Security and Access Rights.
		/// </param>
		/// <param name="DisablePriorityBoost">
		/// If this parameter is TRUE, dynamic boosting is disabled. If the parameter is FALSE, dynamic boosting is enabled.
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is nonzero.</para>
		/// <para>If the function fails, the return value is zero. To get extended error information, call <c>GetLastError</c>.</para>
		/// </returns>
		// BOOL WINAPI SetProcessPriorityBoost( _In_ HANDLE hProcess, _In_ BOOL DisablePriorityBoost); https://msdn.microsoft.com/en-us/library/windows/desktop/ms686225(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("WinBase.h", MSDNShortId = "ms686225")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool SetProcessPriorityBoost([In] HPROCESS hProcess, [MarshalAs(UnmanagedType.Bool)] bool DisablePriorityBoost);

		/// <summary>
		/// Sets shutdown parameters for the currently calling process. This function sets a shutdown order for a process relative to the
		/// other processes in the system.
		/// </summary>
		/// <param name="dwLevel">
		/// <para>
		/// The shutdown priority for a process relative to other processes in the system. The system shuts down processes from high dwLevel
		/// values to low. The highest and lowest shutdown priorities are reserved for system components. This parameter must be in the
		/// following range of values.
		/// </para>
		/// <para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>000-0FF</term>
		/// <term>System reserved last shutdown range.</term>
		/// </item>
		/// <item>
		/// <term>100-1FF</term>
		/// <term>Application reserved last shutdown range.</term>
		/// </item>
		/// <item>
		/// <term>200-2FF</term>
		/// <term>Application reserved &amp;quot;in between&amp;quot; shutdown range.</term>
		/// </item>
		/// <item>
		/// <term>300-3FF</term>
		/// <term>Application reserved first shutdown range.</term>
		/// </item>
		/// <item>
		/// <term>400-4FF</term>
		/// <term>System reserved first shutdown range.</term>
		/// </item>
		/// </list>
		/// </para>
		/// <para>All processes start at shutdown level 0x280.</para>
		/// </param>
		/// <param name="dwFlags">
		/// <para>This parameter can be the following value.</para>
		/// <para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>SHUTDOWN_NORETRY0x00000001</term>
		/// <term>The system terminates the process without displaying a retry dialog box for the user.</term>
		/// </item>
		/// </list>
		/// </para>
		/// </param>
		/// <returns>
		/// <para>If the function is succeeds, the return value is nonzero.</para>
		/// <para>If the function fails, the return value is zero. To get extended error information, call <c>GetLastError</c>.</para>
		/// </returns>
		// BOOL WINAPI SetProcessShutdownParameters( _In_ DWORD dwLevel, _In_ DWORD dwFlags); https://msdn.microsoft.com/en-us/library/windows/desktop/ms686227(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("WinBase.h", MSDNShortId = "ms686227")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool SetProcessShutdownParameters(uint dwLevel, SHUTDOWN dwFlags);

		/// <summary>Sets a protected policy. This function is for use primarily by Windows, and not designed for external use.</summary>
		/// <param name="PolicyGuid">The globally-unique identifier of the policy to set.</param>
		/// <param name="PolicyValue">The value to set the policy to.</param>
		/// <param name="OldPolicyValue">Optionally receives the original value that was associated with the supplied policy.</param>
		/// <returns>True if the function succeeds; otherwise, false. To retrieve error values for this function, call <c>GetLastError</c>.</returns>
		// BOOL WINAPI SetProtectedPolicy( _In_ LPCGUID PolicyGuid, _In_ ULONG_PTR PolicyValue, _Out_ PULONG_PTR OldPolicyValue); https://msdn.microsoft.com/en-us/library/windows/desktop/dn893592(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("Winbase.h", MSDNShortId = "dn893592")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool SetProtectedPolicy(in Guid PolicyGuid, IntPtr PolicyValue, out IntPtr OldPolicyValue);

		/// <summary>
		/// <para>Sets the context for the specified thread.</para>
		/// <para>A 64-bit application can set the context of a WOW64 thread using the <c>Wow64SetThreadContext</c> function.</para>
		/// </summary>
		/// <param name="hThread">
		/// A handle to the thread whose context is to be set. The handle must have the <c>THREAD_SET_CONTEXT</c> access right to the thread.
		/// For more information, see Thread Security and Access Rights.
		/// </param>
		/// <param name="lpContext">
		/// A pointer to a <c>CONTEXT</c> structure that contains the context to be set in the specified thread. The value of the
		/// <c>ContextFlags</c> member of this structure specifies which portions of a thread's context to set. Some values in the
		/// <c>CONTEXT</c> structure that cannot be specified are silently set to the correct value. This includes bits in the CPU status
		/// register that specify the privileged processor mode, global enabling bits in the debugging register, and other states that must
		/// be controlled by the operating system.
		/// </param>
		/// <returns>
		/// <para>If the context was set, the return value is nonzero.</para>
		/// <para>If the function fails, the return value is zero. To get extended error information, call <c>GetLastError</c>.</para>
		/// </returns>
		// BOOL WINAPI SetThreadContext( _In_ HANDLE hThread, _In_ const CONTEXT *lpContext); https://msdn.microsoft.com/en-us/library/windows/desktop/ms680632(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("WinBase.h", MSDNShortId = "ms680632")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool SetThreadContext([In] HTHREAD hThread, in CONTEXT lpContext);

		/// <summary>Assigns a description to a thread.</summary>
		/// <param name="hThread">
		/// A handle for the thread for which you want to set the description. The handle must have THREAD_SET_LIMITED_INFORMATION access.
		/// </param>
		/// <param name="lpThreadDescription">A Unicode string that specifies the description of the thread.</param>
		/// <returns>
		/// If the function succeeds, the return value is the <c>HRESULT</c> that denotes a successful operation.If the function fails, the
		/// return value is an <c>HRESULT</c> that denotes the error.
		/// </returns>
		// HRESULT WINAPI SetThreadDescription( _In_ HANDLE hThread, _In_ PCWSTR lpThreadDescription); https://msdn.microsoft.com/en-us/library/windows/desktop/mt774976(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("ProcessThreadsApi.h", MSDNShortId = "mt774976")]
		public static extern HRESULT SetThreadDescription(HTHREAD hThread, [MarshalAs(UnmanagedType.LPWStr)] string lpThreadDescription);

		/// <summary>
		/// <para>Sets a preferred processor for a thread. The system schedules threads on their preferred processors whenever possible.</para>
		/// <para>
		/// On a system with more than 64 processors, this function sets the preferred processor to a logical processor in the processor
		/// group to which the calling thread is assigned. Use the <c>SetThreadIdealProcessorEx</c> function to specify a processor group and
		/// preferred processor.
		/// </para>
		/// </summary>
		/// <param name="hThread">
		/// A handle to the thread whose preferred processor is to be set. The handle must have the THREAD_SET_INFORMATION access right. For
		/// more information, see Thread Security and Access Rights.
		/// </param>
		/// <param name="dwIdealProcessor">
		/// The number of the preferred processor for the thread. This value is zero-based. If this parameter is MAXIMUM_PROCESSORS, the
		/// function returns the current ideal processor without changing it.
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is the previous preferred processor.</para>
		/// <para>If the function fails, the return value is (DWORD) – 1. To get extended error information, call <c>GetLastError</c>.</para>
		/// </returns>
		// DWORD WINAPI SetThreadIdealProcessor( _In_ HANDLE hThread, _In_ DWORD dwIdealProcessor); https://msdn.microsoft.com/en-us/library/windows/desktop/ms686253(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("WinBase.h", MSDNShortId = "ms686253")]
		public static extern uint SetThreadIdealProcessor([In] HTHREAD hThread, uint dwIdealProcessor);

		/// <summary>Sets the ideal processor for the specified thread and optionally retrieves the previous ideal processor.</summary>
		/// <param name="hThread">
		/// A handle to the thread for which to set the ideal processor. This handle must have been created with the THREAD_SET_INFORMATION
		/// access right. For more information, see Thread Security and Access Rights.
		/// </param>
		/// <param name="lpIdealProcessor">
		/// A pointer to a PROCESSOR_NUMBER structure that specifies the processor number of the desired ideal processor.
		/// </param>
		/// <param name="lpPreviousIdealProcessor">
		/// A pointer to a PROCESSOR_NUMBER structure to receive the previous ideal processor. This parameter can point to the same memory
		/// location as the lpIdealProcessor parameter. This parameter can be NULL if the previous ideal processor is not required.
		/// </param>
		/// <returns>
		/// If the function succeeds, it returns a nonzero value. If the function fails, it returns zero.To get extended error information,
		/// use GetLastError.
		/// </returns>
		// https://msdn.microsoft.com/en-us/library/windows/desktop/dd405517(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("WinBase.h", MSDNShortId = "dd405517")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool SetThreadIdealProcessorEx([In] HTHREAD hThread, in PROCESSOR_NUMBER lpIdealProcessor, out PROCESSOR_NUMBER lpPreviousIdealProcessor);

		/// <summary>Sets information for the specified thread.</summary>
		/// <param name="hThread">
		/// A handle to the thread. The handle must have THREAD_QUERY_INFORMATION access right. For more information, see Thread Security and
		/// Access Rights.
		/// </param>
		/// <param name="ThreadInformationClass">
		/// The class of information to set. The only supported values are <c>ThreadMemoryPriority</c> and <c>ThreadPowerThrottling</c>.
		/// </param>
		/// <param name="ThreadInformation">
		/// <para>Pointer to a structure that contains the type of information specified by the ThreadInformationClass parameter.</para>
		/// <para>
		/// If the ThreadInformationClass parameter is <c>ThreadMemoryPriority</c>, this parameter must point to a
		/// <c>MEMORY_PRIORITY_INFORMATION</c> structure.
		/// </para>
		/// <para>
		/// If the ThreadInformationClass parameter is <c>ThreadPowerThrottling</c>, this parameter must point to a
		/// <c>THREAD_POWER_THROTTLING_STATE</c> structure.
		/// </para>
		/// </param>
		/// <param name="ThreadInformationSize">
		/// <para>The size in bytes of the structure specified by the ThreadInformation parameter.</para>
		/// <para>If the ThreadInformationClass parameter is <c>ThreadMemoryPriority</c>, this parameter must be .</para>
		/// <para>If the ThreadInformationClass parameter is <c>ThreadPowerThrottling</c>, this parameter must be .</para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is nonzero.</para>
		/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// To help improve system performance, applications should use the <c>SetThreadInformation</c> function with
		/// <c>ThreadMemoryPriority</c> to lower the memory priority of threads that perform background operations or access files and data
		/// that are not expected to be accessed again soon. For example, an anti-malware application might lower the priority of threads
		/// involved in scanning files.
		/// </para>
		/// <para>
		/// Memory priority helps to determine how long pages remain in the working set of a process before they are trimmed. A thread's
		/// memory priority determines the minimum priority of the physical pages that are added to the process working set by that thread.
		/// When the memory manager trims the working set, it trims lower priority pages before higher priority pages. This improves overall
		/// system performance because higher priority pages are less likely to be trimmed from the working set and then trigger a page fault
		/// when they are accessed again.
		/// </para>
		/// <para>Examples</para>
		/// <para>
		/// The following example shows how to call <c>SetThreadInformation</c> with <c>ThreadMemoryPriority</c> to set low memory priority
		/// on the current thread.
		/// </para>
		/// <para>
		/// The following example shows how to call <c>SetThreadInformation</c> with <c>ThreadPowerThrottling</c> to enable throttling
		/// policies on a thread.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/processthreadsapi/nf-processthreadsapi-setthreadinformation BOOL
		// SetThreadInformation( HANDLE hThread, THREAD_INFORMATION_CLASS ThreadInformationClass, LPVOID ThreadInformation, DWORD
		// ThreadInformationSize );
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("processthreadsapi.h", MSDNShortId = "c0159bea-870a-46b7-a350-91fe52efae49")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool SetThreadInformation(HTHREAD hThread, THREAD_INFORMATION_CLASS ThreadInformationClass, IntPtr ThreadInformation, uint ThreadInformationSize);

		/// <summary>Sets information for the specified thread.</summary>
		/// <typeparam name="T">
		/// The type of the structure that contains the type of information specified by the ThreadInformationClass parameter.
		/// </typeparam>
		/// <param name="hThread">
		/// A handle to the thread. The handle must have THREAD_QUERY_INFORMATION access right. For more information, see Thread Security and
		/// Access Rights.
		/// </param>
		/// <param name="ThreadInformationClass">
		/// The class of information to set. The only supported values are <c>ThreadMemoryPriority</c> and <c>ThreadPowerThrottling</c>.
		/// </param>
		/// <param name="ThreadInformation">
		/// <para>The structure that contains the type of information specified by the ThreadInformationClass parameter.</para>
		/// <para>
		/// If the ThreadInformationClass parameter is <c>ThreadMemoryPriority</c>, this parameter must point to a
		/// <c>MEMORY_PRIORITY_INFORMATION</c> structure.
		/// </para>
		/// <para>
		/// If the ThreadInformationClass parameter is <c>ThreadPowerThrottling</c>, this parameter must point to a
		/// <c>THREAD_POWER_THROTTLING_STATE</c> structure.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is nonzero.</para>
		/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
		/// </returns>
		/// <exception cref="ArgumentException"></exception>
		/// <remarks>
		/// <para>
		/// To help improve system performance, applications should use the <c>SetThreadInformation</c> function with
		/// <c>ThreadMemoryPriority</c> to lower the memory priority of threads that perform background operations or access files and data
		/// that are not expected to be accessed again soon. For example, an anti-malware application might lower the priority of threads
		/// involved in scanning files.
		/// </para>
		/// <para>
		/// Memory priority helps to determine how long pages remain in the working set of a process before they are trimmed. A thread's
		/// memory priority determines the minimum priority of the physical pages that are added to the process working set by that thread.
		/// When the memory manager trims the working set, it trims lower priority pages before higher priority pages. This improves overall
		/// system performance because higher priority pages are less likely to be trimmed from the working set and then trigger a page fault
		/// when they are accessed again.
		/// </para>
		/// <para>Examples</para>
		/// <para>
		/// The following example shows how to call <c>SetThreadInformation</c> with <c>ThreadMemoryPriority</c> to set low memory priority
		/// on the current thread.
		/// </para>
		/// <para>
		/// The following example shows how to call <c>SetThreadInformation</c> with <c>ThreadPowerThrottling</c> to enable throttling
		/// policies on a thread.
		/// </para>
		/// </remarks>
		[PInvokeData("processthreadsapi.h", MSDNShortId = "c0159bea-870a-46b7-a350-91fe52efae49")]
		public static bool SetThreadInformation<T>(HTHREAD hThread, THREAD_INFORMATION_CLASS ThreadInformationClass, in T ThreadInformation)
		{
			if (!CorrespondingTypeAttribute.CanSet(ThreadInformationClass, typeof(T))) throw new ArgumentException($"{ThreadInformationClass} cannot be used to set values of type {typeof(T)}.");
			using (var mem = SafeHGlobalHandle.CreateFromStructure(ThreadInformation))
				return SetThreadInformation(hThread, ThreadInformationClass, (IntPtr)mem, (uint)mem.Size);
		}

		/// <summary>
		/// Sets the priority value for the specified thread. This value, together with the priority class of the thread's process,
		/// determines the thread's base priority level.
		/// </summary>
		/// <param name="hThread">
		/// <para>A handle to the thread whose priority value is to be set.</para>
		/// <para>
		/// The handle must have the <c>THREAD_SET_INFORMATION</c> or <c>THREAD_SET_LIMITED_INFORMATION</c> access right. For more
		/// information, see Thread Security and Access Rights.
		/// </para>
		/// <para><c>Windows Server 2003:</c> The handle must have the <c>THREAD_SET_INFORMATION</c> access right.</para>
		/// </param>
		/// <param name="nPriority">
		/// <para>The priority value for the thread. This parameter can be one of the following values.</para>
		/// <para>
		/// <list type="table">
		/// <listheader>
		/// <term>Priority</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>THREAD_MODE_BACKGROUND_BEGIN0x00010000</term>
		/// <term>
		/// Begin background processing mode. The system lowers the resource scheduling priorities of the thread so that it can perform
		/// background work without significantly affecting activity in the foreground.This value can be specified only if hThread is a
		/// handle to the current thread. The function fails if the thread is already in background processing mode.Windows Server 2003: This
		/// value is not supported.
		/// </term>
		/// </item>
		/// <item>
		/// <term>THREAD_MODE_BACKGROUND_END0x00020000</term>
		/// <term>
		/// End background processing mode. The system restores the resource scheduling priorities of the thread as they were before the
		/// thread entered background processing mode.This value can be specified only if hThread is a handle to the current thread. The
		/// function fails if the thread is not in background processing mode.Windows Server 2003: This value is not supported.
		/// </term>
		/// </item>
		/// <item>
		/// <term>THREAD_PRIORITY_ABOVE_NORMAL1</term>
		/// <term>Priority 1 point above the priority class.</term>
		/// </item>
		/// <item>
		/// <term>THREAD_PRIORITY_BELOW_NORMAL-1</term>
		/// <term>Priority 1 point below the priority class.</term>
		/// </item>
		/// <item>
		/// <term>THREAD_PRIORITY_HIGHEST2</term>
		/// <term>Priority 2 points above the priority class.</term>
		/// </item>
		/// <item>
		/// <term>THREAD_PRIORITY_IDLE-15</term>
		/// <term>
		/// Base priority of 1 for IDLE_PRIORITY_CLASS, BELOW_NORMAL_PRIORITY_CLASS, NORMAL_PRIORITY_CLASS, ABOVE_NORMAL_PRIORITY_CLASS, or
		/// HIGH_PRIORITY_CLASS processes, and a base priority of 16 for REALTIME_PRIORITY_CLASS processes.
		/// </term>
		/// </item>
		/// <item>
		/// <term>THREAD_PRIORITY_LOWEST-2</term>
		/// <term>Priority 2 points below the priority class.</term>
		/// </item>
		/// <item>
		/// <term>THREAD_PRIORITY_NORMAL0</term>
		/// <term>Normal priority for the priority class.</term>
		/// </item>
		/// <item>
		/// <term>THREAD_PRIORITY_TIME_CRITICAL15</term>
		/// <term>
		/// Base priority of 15 for IDLE_PRIORITY_CLASS, BELOW_NORMAL_PRIORITY_CLASS, NORMAL_PRIORITY_CLASS, ABOVE_NORMAL_PRIORITY_CLASS, or
		/// HIGH_PRIORITY_CLASS processes, and a base priority of 31 for REALTIME_PRIORITY_CLASS processes.
		/// </term>
		/// </item>
		/// </list>
		/// </para>
		/// <para>
		/// If the thread has the <c>REALTIME_PRIORITY_CLASS</c> base class, this parameter can also be -7, -6, -5, -4, -3, 3, 4, 5, or 6.
		/// For more information, see Scheduling Priorities.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is nonzero.</para>
		/// <para>If the function fails, the return value is zero. To get extended error information, call <c>GetLastError</c>.</para>
		/// <para>
		/// <c>Windows Phone 8.1:</c> Windows Phone Store apps may call this function but it has no effect. The function will return a
		/// nonzero value indicating success.
		/// </para>
		/// </returns>
		// BOOL WINAPI SetThreadPriority( _In_ HANDLE hThread, _In_ int nPriority); https://msdn.microsoft.com/en-us/library/windows/desktop/ms686277(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("WinBase.h", MSDNShortId = "ms686277")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool SetThreadPriority([In] HTHREAD hThread, int nPriority);

		/// <summary>Disables or enables the ability of the system to temporarily boost the priority of a thread.</summary>
		/// <param name="hThread">
		/// <para>
		/// A handle to the thread whose priority is to be boosted. The handle must have the <c>THREAD_SET_INFORMATION</c> or
		/// <c>THREAD_SET_LIMITED_INFORMATION</c> access right. For more information, see Thread Security and Access Rights.
		/// </para>
		/// <para><c>Windows Server 2003 and Windows XP:</c> The handle must have the <c>THREAD_SET_INFORMATION</c> access right.</para>
		/// </param>
		/// <param name="DisablePriorityBoost">
		/// If this parameter is <c>TRUE</c>, dynamic boosting is disabled. If the parameter is <c>FALSE</c>, dynamic boosting is enabled.
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is nonzero.</para>
		/// <para>If the function fails, the return value is zero. To get extended error information, call <c>GetLastError</c>.</para>
		/// </returns>
		// BOOL WINAPI SetThreadPriorityBoost( _In_ HANDLE hThread, _In_ BOOL DisablePriorityBoost); https://msdn.microsoft.com/en-us/library/windows/desktop/ms686280(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("WinBase.h", MSDNShortId = "ms686280")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool SetThreadPriorityBoost([In] HTHREAD hThread, [MarshalAs(UnmanagedType.Bool)] bool DisablePriorityBoost);

		/// <summary>
		/// Sets the selected CPU Sets assignment for the specified thread. This assignment overrides the process default assignment, if one
		/// is set.
		/// </summary>
		/// <param name="Thread">
		/// Specifies the thread on which to set the CPU Set assignment. This handle must have the THREAD_SET_LIMITED_INFORMATION access
		/// right. The value returned by <c>GetCurrentThread</c> can also be used.
		/// </param>
		/// <param name="CpuSetIds">
		/// Specifies the list of CPU Set IDs to set as the thread selected CPU set. If this is NULL, the API clears out any assignment,
		/// reverting to process default assignment if one is set.
		/// </param>
		/// <param name="CpuSetIdCount">
		/// Specifies the number of IDs in the list passed in the <c>CpuSetIds</c> argument. If that value is NULL, this should be 0.
		/// </param>
		/// <returns>This function cannot fail when passed valid parameters.</returns>
		// BOOL WINAPI SetThreadSelectedCpuSets( _In_ HANDLE Thread, _In_ const ULONG *CpuSetIds, _In_ ULONG CpuSetIdCount); https://msdn.microsoft.com/en-us/library/windows/desktop/mt186428(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("Processthreadapi.h", MSDNShortId = "mt186428")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool SetThreadSelectedCpuSets([In] HTHREAD Thread, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] uint[] CpuSetIds, uint CpuSetIdCount);

		/// <summary>
		/// Sets the minimum size of the stack associated with the calling thread or fiber that will be available during any stack overflow
		/// exceptions. This is useful for handling stack overflow exceptions; the application can safely use the specified number of bytes
		/// during exception handling.
		/// </summary>
		/// <param name="StackSizeInBytes">
		/// <para>The size of the stack, in bytes. On return, this value is set to the size of the previous stack, in bytes.</para>
		/// <para>If this parameter is 0 (zero), the function succeeds and the parameter contains the size of the current stack.</para>
		/// <para>
		/// If the specified size is less than the current size, the function succeeds but ignores this request. Therefore, you cannot use
		/// this function to reduce the size of the stack.
		/// </para>
		/// <para>This value cannot be larger than the reserved stack size.</para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is nonzero.</para>
		/// <para>If the function fails, the return value is 0 (zero). To get extended error information, call <c>GetLastError</c>.</para>
		/// </returns>
		// BOOL WINAPI SetThreadStackGuarantee( _Inout_ PULONG StackSizeInBytes); https://msdn.microsoft.com/en-us/library/windows/desktop/ms686283(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("WinBase.h", MSDNShortId = "ms686283")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool SetThreadStackGuarantee(ref uint StackSizeInBytes);

		/// <summary>
		/// <para>Suspends the specified thread.</para>
		/// <para>A 64-bit application can suspend a WOW64 thread using the <c>Wow64SuspendThread</c> function.</para>
		/// </summary>
		/// <param name="hThread">
		/// <para>A handle to the thread that is to be suspended.</para>
		/// <para>
		/// The handle must have the <c>THREAD_SUSPEND_RESUME</c> access right. For more information, see Thread Security and Access Rights.
		/// </para>
		/// </param>
		/// <returns>
		/// If the function succeeds, the return value is the thread's previous suspend count; otherwise, it is . To get extended error
		/// information, use the <c>GetLastError</c> function.
		/// </returns>
		// DWORD WINAPI SuspendThread( _In_ HANDLE hThread); https://msdn.microsoft.com/en-us/library/windows/desktop/ms686345(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("WinBase.h", MSDNShortId = "ms686345")]
		public static extern uint SuspendThread(HTHREAD hThread);

		/// <summary>
		/// Causes the calling thread to yield execution to another thread that is ready to run on the current processor. The operating
		/// system selects the next thread to be executed.
		/// </summary>
		/// <returns>
		/// <para>
		/// If calling the <c>SwitchToThread</c> function causes the operating system to switch execution to another thread, the return value
		/// is nonzero.
		/// </para>
		/// <para>
		/// If there are no other threads ready to execute, the operating system does not switch execution to another thread, and the return
		/// value is zero.
		/// </para>
		/// </returns>
		// BOOL WINAPI SwitchToThread(void); https://msdn.microsoft.com/en-us/library/windows/desktop/ms686352(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("WinBase.h", MSDNShortId = "ms686352")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool SwitchToThread();

		/// <summary>Terminates the specified process and all of its threads.</summary>
		/// <param name="hProcess">
		/// <para>A handle to the process to be terminated.</para>
		/// <para>
		/// The handle must have the <c>PROCESS_TERMINATE</c> access right. For more information, see Process Security and Access Rights.
		/// </para>
		/// </param>
		/// <param name="uExitCode">
		/// The exit code to be used by the process and threads terminated as a result of this call. Use the <c>GetExitCodeProcess</c>
		/// function to retrieve a process's exit value. Use the <c>GetExitCodeThread</c> function to retrieve a thread's exit value.
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is nonzero.</para>
		/// <para>If the function fails, the return value is zero. To get extended error information, call <c>GetLastError</c>.</para>
		/// </returns>
		// BOOL WINAPI TerminateProcess( _In_ HANDLE hProcess, _In_ UINT uExitCode); https://msdn.microsoft.com/en-us/library/windows/desktop/ms686714(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("WinBase.h", MSDNShortId = "ms686714")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool TerminateProcess([In] HPROCESS hProcess, uint uExitCode);

		/// <summary>Terminates a thread.</summary>
		/// <param name="hThread">
		/// <para>A handle to the thread to be terminated.</para>
		/// <para>The handle must have the <c>THREAD_TERMINATE</c> access right. For more information, see Thread Security and Access Rights.</para>
		/// </param>
		/// <param name="dwExitCode">
		/// The exit code for the thread. Use the <c>GetExitCodeThread</c> function to retrieve a thread's exit value.
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is nonzero.</para>
		/// <para>If the function fails, the return value is zero. To get extended error information, call <c>GetLastError</c>.</para>
		/// </returns>
		// BOOL WINAPI TerminateThread( _Inout_ HANDLE hThread, _In_ DWORD dwExitCode); https://msdn.microsoft.com/en-us/library/windows/desktop/ms686717(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("WinBase.h", MSDNShortId = "ms686717")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool TerminateThread([In] HTHREAD hThread, uint dwExitCode);

		/// <summary>
		/// Allocates a thread local storage (TLS) index. Any thread of the process can subsequently use this index to store and retrieve
		/// values that are local to the thread, because each thread receives its own slot for the index.
		/// </summary>
		/// <returns>
		/// <para>If the function succeeds, the return value is a TLS index. The slots for the index are initialized to zero.</para>
		/// <para>If the function fails, the return value is <c>TLS_OUT_OF_INDEXES</c>. To get extended error information, call GetLastError.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// <c>Windows Phone 8.1:</c> This function is supported for Windows Phone Store apps on Windows Phone 8.1 and later. When a Windows
		/// Phone Store app calls this function, it is replaced with an inline call to <c>FlsAlloc</c>. Refer to FlsAlloc for function documentation.
		/// </para>
		/// <para>
		/// <c>Windows 8.1</c>, <c>Windows Server 2012 R2</c>, and <c>Windows 10, version 1507</c>: This function is supported for Windows
		/// Store apps on Windows 8.1, Windows Server 2012 R2, and Windows 10, version 1507. When a Windows Store app calls this function, it
		/// is replaced with an inline call to <c>FlsAlloc</c>. Refer to FlsAlloc for function documentation.
		/// </para>
		/// <para>
		/// <c>Windows 10, version 1511</c> and <c>Windows 10, version 1607</c>: This function is fully supported for Universal Windows
		/// Platform (UWP) apps, and is no longer replaced with an inline call to <c>FlsAlloc</c>.
		/// </para>
		/// <para>
		/// The threads of the process can use the TLS index in subsequent calls to the TlsFree, TlsSetValue, or TlsGetValue functions. The
		/// value of the TLS index should be treated as an opaque value; do not assume that it is an index into a zero-based array.
		/// </para>
		/// <para>
		/// TLS indexes are typically allocated during process or dynamic-link library (DLL) initialization. When a TLS index is allocated,
		/// its storage slots are initialized to <c>NULL</c>. After a TLS index has been allocated, each thread of the process can use it to
		/// access its own TLS storage slot. To store a value in its TLS slot, a thread specifies the index in a call to TlsSetValue. The
		/// thread specifies the same index in a subsequent call to TlsGetValue, to retrieve the stored value.
		/// </para>
		/// <para>
		/// TLS indexes are not valid across process boundaries. A DLL cannot assume that an index assigned in one process is valid in
		/// another process.
		/// </para>
		/// <para>Examples</para>
		/// <para>For an example, see Using Thread Local Storage or Using Thread Local Storage in a Dynamic-Link Library.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/processthreadsapi/nf-processthreadsapi-tlsalloc DWORD TlsAlloc( );
		[DllImport(Lib.KernelBase, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("processthreadsapi.h", MSDNShortId = "cbb3d832-cd92-4875-8366-6b69be7a536f")]
		public static extern uint TlsAlloc();

		/// <summary>Releases a thread local storage (TLS) index, making it available for reuse.</summary>
		/// <param name="dwTlsIndex">The TLS index that was allocated by the TlsAlloc function.</param>
		/// <returns>
		/// <para>If the function succeeds, the return value is nonzero.</para>
		/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// <c>Windows Phone 8.1:</c> This function is supported for Windows Phone Store apps on Windows Phone 8.1 and later. When a Windows
		/// Phone Store app calls this function, it is replaced with an inline call to <c>FlsFree</c>. Refer to FlsFree for function documentation.
		/// </para>
		/// <para>
		/// <c>Windows 8.1</c>, <c>Windows Server 2012 R2</c>, and <c>Windows 10, version 1507</c>: This function is supported for Windows
		/// Store apps on Windows 8.1, Windows Server 2012 R2, and Windows 10, version 1507. When a Windows Store app calls this function, it
		/// is replaced with an inline call to <c>FlsFree</c>. Refer to FlsFree for function documentation.
		/// </para>
		/// <para>
		/// <c>Windows 10, version 1511</c> and <c>Windows 10, version 1607</c>: This function is fully supported for Universal Windows
		/// Platform (UWP) apps, and is no longer replaced with an inline call to <c>FlsFree</c>.
		/// </para>
		/// <para>
		/// If the threads of the process have allocated memory and stored a pointer to the memory in a TLS slot, they should free the memory
		/// before calling <c>TlsFree</c>. The <c>TlsFree</c> function does not free memory blocks whose addresses have been stored in the
		/// TLS slots associated with the TLS index. It is expected that DLLs call this function (if at all) only during <c>DLL_PROCESS_DETACH</c>.
		/// </para>
		/// <para>For more information, see Thread Local Storage.</para>
		/// <para>Examples</para>
		/// <para>For an example, see Using Thread Local Storage or Using Thread Local Storage in a Dynamic-Link Library.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/processthreadsapi/nf-processthreadsapi-tlsfree BOOL TlsFree( DWORD dwTlsIndex );
		[DllImport(Lib.KernelBase, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("processthreadsapi.h", MSDNShortId = "f5b1e8fc-02eb-4a06-b606-2b647944029b")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool TlsFree(uint dwTlsIndex);

		/// <summary>
		/// Retrieves the value in the calling thread's thread local storage (TLS) slot for the specified TLS index. Each thread of a process
		/// has its own slot for each TLS index.
		/// </summary>
		/// <param name="dwTlsIndex">The TLS index that was allocated by the TlsAlloc function.</param>
		/// <returns>
		/// <para>
		/// If the function succeeds, the return value is the value stored in the calling thread's TLS slot associated with the specified
		/// index. If dwTlsIndex is a valid index allocated by a successful call to TlsAlloc, this function always succeeds.
		/// </para>
		/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
		/// <para>
		/// The data stored in a TLS slot can have a value of 0 because it still has its initial value or because the thread called the
		/// TlsSetValue function with 0. Therefore, if the return value is 0, you must check whether GetLastError returns
		/// <c>ERROR_SUCCESS</c> before determining that the function has failed. If <c>GetLastError</c> returns <c>ERROR_SUCCESS</c>, then
		/// the function has succeeded and the data stored in the TLS slot is 0. Otherwise, the function has failed.
		/// </para>
		/// <para>
		/// Functions that return indications of failure call SetLastErrorwhen they fail. They generally do not call <c>SetLastError</c> when
		/// they succeed. The <c>TlsGetValue</c> function is an exception to this general rule. The <c>TlsGetValue</c> function calls
		/// <c>SetLastError</c> to clear a thread's last error when it succeeds. That allows checking for the error-free retrieval of zero values.
		/// </para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// <c>Windows Phone 8.1:</c> This function is supported for Windows Phone Store apps on Windows Phone 8.1 and later. When a Windows
		/// Phone Store app calls this function, it is replaced with an inline call to <c>FlsGetValue</c>. Refer to FlsGetValue for function documentation.
		/// </para>
		/// <para>
		/// <c>Windows 8.1</c>, <c>Windows Server 2012 R2</c>, and <c>Windows 10, version 1507</c>: This function is supported for Windows
		/// Store apps on Windows 8.1, Windows Server 2012 R2, and Windows 10, version 1507. When a Windows Store app calls this function, it
		/// is replaced with an inline call to <c>FlsGetValue</c>. Refer to FlsGetValue for function documentation.
		/// </para>
		/// <para>
		/// <c>Windows 10, version 1511</c> and <c>Windows 10, version 1607</c>: This function is fully supported for Universal Windows
		/// Platform (UWP) apps, and is no longer replaced with an inline call to <c>FlsGetValue</c>.
		/// </para>
		/// <para>
		/// TLS indexes are typically allocated by the TlsAlloc function during process or DLL initialization. After a TLS index is
		/// allocated, each thread of the process can use it to access its own TLS slot for that index. A thread specifies a TLS index in a
		/// call to TlsSetValue to store a value in its slot. The thread specifies the same index in a subsequent call to <c>TlsGetValue</c>
		/// to retrieve the stored value.
		/// </para>
		/// <para>
		/// <c>TlsGetValue</c> was implemented with speed as the primary goal. The function performs minimal parameter validation and error
		/// checking. In particular, it succeeds if dwTlsIndex is in the range 0 through ( <c>TLS_MINIMUM_AVAILABLE</c>– 1). It is up to the
		/// programmer to ensure that the index is valid and that the thread calls TlsSetValue before calling <c>TlsGetValue</c>.
		/// </para>
		/// <para>Examples</para>
		/// <para>For an example, see Using Thread Local Storage or Using Thread Local Storage in a Dynamic-Link Library.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/processthreadsapi/nf-processthreadsapi-tlsgetvalue LPVOID TlsGetValue( DWORD
		// dwTlsIndex );
		[DllImport(Lib.KernelBase, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("processthreadsapi.h", MSDNShortId = "82bd5ff6-ff0b-42b7-9ece-e9e8531eb5fb")]
		public static extern IntPtr TlsGetValue(uint dwTlsIndex);

		/// <summary>
		/// Stores a value in the calling thread's thread local storage (TLS) slot for the specified TLS index. Each thread of a process has
		/// its own slot for each TLS index.
		/// </summary>
		/// <param name="dwTlsIndex">The TLS index that was allocated by the TlsAlloc function.</param>
		/// <param name="lpTlsValue">The value to be stored in the calling thread's TLS slot for the index.</param>
		/// <returns>
		/// <para>If the function succeeds, the return value is nonzero.</para>
		/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// <c>Windows Phone 8.1:</c> This function is supported for Windows Phone Store apps on Windows Phone 8.1 and later. When a Windows
		/// Phone Store app calls this function, it is replaced with an inline call to <c>FlsSetValue</c>. Refer to FlsSetValue for function documentation.
		/// </para>
		/// <para>
		/// <c>Windows 8.1</c>, <c>Windows Server 2012 R2</c>, and <c>Windows 10, version 1507</c>: This function is supported for Windows
		/// Store apps on Windows 8.1, Windows Server 2012 R2, and Windows 10, version 1507. When a Windows Store app calls this function, it
		/// is replaced with an inline call to <c>FlsSetValue</c>. Refer to FlsSetValue for function documentation.
		/// </para>
		/// <para>
		/// <c>Windows 10, version 1511</c> and <c>Windows 10, version 1607</c>: This function is fully supported for Universal Windows
		/// Platform (UWP) apps, and is no longer replaced with an inline call to <c>FlsSetValue</c>.
		/// </para>
		/// <para>
		/// TLS indexes are typically allocated by the TlsAlloc function during process or DLL initialization. When a TLS index is allocated,
		/// its storage slots are initialized to NULL. After a TLS index is allocated, each thread of the process can use it to access its
		/// own TLS slot for that index. A thread specifies a TLS index in a call to <c>TlsSetValue</c>, to store a value in its slot. The
		/// thread specifies the same index in a subsequent call to TlsGetValue, to retrieve the stored value.
		/// </para>
		/// <para>
		/// <c>TlsSetValue</c> was implemented with speed as the primary goal. The function performs minimal parameter validation and error
		/// checking. In particular, it succeeds if dwTlsIndex is in the range 0 through ( <c>TLS_MINIMUM_AVAILABLE</c>– 1). It is up to the
		/// programmer to ensure that the index is valid before calling TlsGetValue.
		/// </para>
		/// <para>Examples</para>
		/// <para>For an example, see Using Thread Local Storage or Using Thread Local Storage in a Dynamic-Link Library.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/processthreadsapi/nf-processthreadsapi-tlssetvalue BOOL TlsSetValue( DWORD
		// dwTlsIndex, LPVOID lpTlsValue );
		[DllImport(Lib.KernelBase, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("processthreadsapi.h", MSDNShortId = "531b4a4a-a251-4ab4-b00a-754783a51283")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool TlsSetValue(uint dwTlsIndex, [In] IntPtr lpTlsValue);

		/// <summary>Updates the specified attribute in a list of attributes for process and thread creation.</summary>
		/// <param name="lpAttributeList">A pointer to an attribute list created by the <c>InitializeProcThreadAttributeList</c> function.</param>
		/// <param name="dwFlags">This parameter is reserved and must be zero.</param>
		/// <param name="Attribute">
		/// <para>The attribute key to update in the attribute list. This parameter can be one of the following values.</para>
		/// <para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>PROC_THREAD_ATTRIBUTE_GROUP_AFFINITY</term>
		/// <term>
		/// The lpValue parameter is a pointer to a GROUP_AFFINITY structure that specifies the processor group affinity for the new
		/// thread.Windows Server 2008 and Windows Vista: This value is not supported until Windows 7 and Windows Server 2008 R2.
		/// </term>
		/// </item>
		/// <item>
		/// <term>PROC_THREAD_ATTRIBUTE_HANDLE_LIST</term>
		/// <term>
		/// The lpValue parameter is a pointer to a list of handles to be inherited by the child process.These handles must be created as
		/// inheritable handles and must not include pseudo handles such as those returned by the GetCurrentProcess or GetCurrentThread function.
		/// </term>
		/// </item>
		/// <item>
		/// <term>PROC_THREAD_ATTRIBUTE_IDEAL_PROCESSOR</term>
		/// <term>
		/// The lpValue parameter is a pointer to a PROCESSOR_NUMBER structure that specifies the ideal processor for the new thread.Windows
		/// Server 2008 and Windows Vista: This value is not supported until Windows 7 and Windows Server 2008 R2.
		/// </term>
		/// </item>
		/// <item>
		/// <term>PROC_THREAD_ATTRIBUTE_MITIGATION_POLICY</term>
		/// <term>
		/// The lpValue parameter is a pointer to a DWORD or DWORD64 that specifies the exploit mitigation policy for the child process.
		/// Starting in Windows 10, version 1703, this parameter can also be a pointer to a two-element DWORD64 array.The specified policy
		/// overrides the policies set for the application and the system and cannot be changed after the child process starts running.
		/// Windows Server 2008 and Windows Vista: This value is not supported until Windows 7 and Windows Server 2008 R2.The DWORD or
		/// DWORD64 pointed to by lpValue can be one or more of the values listed in the remarks.
		/// </term>
		/// </item>
		/// <item>
		/// <term>PROC_THREAD_ATTRIBUTE_PARENT_PROCESS</term>
		/// <term>
		/// The lpValue parameter is a pointer to a handle to a process to use instead of the calling process as the parent for the process
		/// being created. The process to use must have the PROCESS_CREATE_PROCESS access right.Attributes inherited from the specified
		/// process include handles, the device map, processor affinity, priority, quotas, the process token, and job object. (Note that some
		/// attributes such as the debug port will come from the creating process, not the process specified by this handle.)
		/// </term>
		/// </item>
		/// <item>
		/// <term>PROC_THREAD_ATTRIBUTE_PREFERRED_NODE</term>
		/// <term>
		/// The lpValue parameter is a pointer to the node number of the preferred NUMA node for the new process.Windows Server 2008 and
		/// Windows Vista: This value is not supported until Windows 7 and Windows Server 2008 R2.
		/// </term>
		/// </item>
		/// <item>
		/// <term>PROC_THREAD_ATTRIBUTE_UMS_THREAD</term>
		/// <term>
		/// The lpValue parameter is a pointer to a UMS_CREATE_THREAD_ATTRIBUTES structure that specifies a user-mode scheduling (UMS) thread
		/// context and a UMS completion list to associate with the thread. After the UMS thread is created, the system queues it to the
		/// specified completion list. The UMS thread runs only when an application's UMS scheduler retrieves the UMS thread from the
		/// completion list and selects it to run. For more information, see User-Mode Scheduling.Windows Server 2008 and Windows Vista: This
		/// value is not supported until Windows 7 and Windows Server 2008 R2.
		/// </term>
		/// </item>
		/// <item>
		/// <term>PROC_THREAD_ATTRIBUTE_SECURITY_CAPABILITIES</term>
		/// <term>
		/// The lpValue parameter is a pointer to a SECURITY_CAPABILITIES structure that defines the security capabilities of an app
		/// container. If this attribute is set the new process will be created as an AppContainer process.Windows 7, Windows Server 2008 R2,
		/// Windows Server 2008 and Windows Vista: This value is not supported until Windows 8 and Windows Server 2012.
		/// </term>
		/// </item>
		/// <item>
		/// <term>PROC_THREAD_ATTRIBUTE_PROTECTION_LEVEL</term>
		/// <term>
		/// The lpValue parameter is a pointer to a DWORD value of PROTECTION_LEVEL_SAME. This specifies the protection level of the child
		/// process to be the same as the protection level of its parent process.
		/// </term>
		/// </item>
		/// <item>
		/// <term>PROC_THREAD_ATTRIBUTE_CHILD_PROCESS_POLICY</term>
		/// <term>
		/// The lpValue parameter is a pointer to a DWORD or DWORD64 value that specifies the child process policy. THe policy specifies
		/// whether to allow a child process to be created.For information on the possible values for the DWORD or DWORD64 to which lpValue
		/// points, see Remarks.
		/// </term>
		/// </item>
		/// <item>
		/// <term>PROC_THREAD_ATTRIBUTE_DESKTOP_APP_POLICY</term>
		/// <term>
		/// This attribute is relevant only to win32 applications that have been converted to UWP packages by using the Desktop Bridge. The
		/// lpValue parameter is a pointer to a DWORD value that specifies the desktop app policy. The policy specifies whether descendant
		/// processes should continue to run in the desktop environment.For information about the possible values for the DWORD to which
		/// lpValue points, see Remarks.
		/// </term>
		/// </item>
		/// </list>
		/// </para>
		/// </param>
		/// <param name="lpValue">
		/// A pointer to the attribute value. This value should persist until the attribute is destroyed using the
		/// <c>DeleteProcThreadAttributeList</c> function.
		/// </param>
		/// <param name="cbSize">The size of the attribute value specified by the lpValue parameter.</param>
		/// <param name="lpPreviousValue">This parameter is reserved and must be NULL.</param>
		/// <param name="lpReturnSize">This parameter is reserved and must be NULL.</param>
		/// <returns>
		/// <para>If the function succeeds, the return value is nonzero.</para>
		/// <para>If the function fails, the return value is zero. To get extended error information, call <c>GetLastError</c>.</para>
		/// </returns>
		// BOOL WINAPI UpdateProcThreadAttribute( _Inout_ LPPROC_THREAD_ATTRIBUTE_LIST lpAttributeList, _In_ DWORD dwFlags, _In_ DWORD_PTR
		// Attribute, _In_ PVOID lpValue, _In_ SIZE_T cbSize, _Out_opt_ PVOID lpPreviousValue, _In_opt_ PSIZE_T lpReturnSize); https://msdn.microsoft.com/en-us/library/windows/desktop/ms686880(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("WinBase.h", MSDNShortId = "ms686880")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool UpdateProcThreadAttribute(IntPtr lpAttributeList, [Optional] uint dwFlags, PROC_THREAD_ATTRIBUTE Attribute, IntPtr lpValue, SizeT cbSize, [Optional] IntPtr lpPreviousValue, [Optional] IntPtr lpReturnSize);

		/// <summary>
		/// <para>Creates a new process and its primary thread. The new process runs in the security context of the calling process.</para>
		/// <para>
		/// If the calling process is impersonating another user, the new process uses the token for the calling process, not the
		/// impersonation token. To run the new process in the security context of the user represented by the impersonation token, use the
		/// <c>CreateProcessAsUser</c> or <c>CreateProcessWithLogonW</c> function.
		/// </para>
		/// </summary>
		/// <param name="lpApplicationName">
		/// <para>
		/// The name of the module to be executed. This module can be a Windows-based application. It can be some other type of module (for
		/// example, MS-DOS or OS/2) if the appropriate subsystem is available on the local computer.
		/// </para>
		/// <para>
		/// The string can specify the full path and file name of the module to execute or it can specify a partial name. In the case of a
		/// partial name, the function uses the current drive and current directory to complete the specification. The function will not use
		/// the search path. This parameter must include the file name extension; no default extension is assumed.
		/// </para>
		/// <para>
		/// The lpApplicationName parameter can be <c>NULL</c>. In that case, the module name must be the first white space–delimited token
		/// in the lpCommandLine string. If you are using a long file name that contains a space, use quoted strings to indicate where the
		/// file name ends and the arguments begin; otherwise, the file name is ambiguous. For example, consider the string "c:\program
		/// files\sub dir\program name". This string can be interpreted in a number of ways. The system tries to interpret the possibilities
		/// in the following order:
		/// </para>
		/// <para>
		/// If the executable module is a 16-bit application, lpApplicationName should be <c>NULL</c>, and the string pointed to by
		/// lpCommandLine should specify the executable module as well as its arguments.
		/// </para>
		/// <para>
		/// To run a batch file, you must start the command interpreter; set lpApplicationName to cmd.exe and set lpCommandLine to the
		/// following arguments: /c plus the name of the batch file.
		/// </para>
		/// </param>
		/// <param name="lpCommandLine">
		/// <para>
		/// The command line to be executed. The maximum length of this string is 32,768 characters, including the Unicode terminating null
		/// character. If lpApplicationName is <c>NULL</c>, the module name portion of lpCommandLine is limited to <c>MAX_PATH</c> characters.
		/// </para>
		/// <para>
		/// The Unicode version of this function, <c>CreateProcessW</c>, can modify the contents of this string. Therefore, this parameter
		/// cannot be a pointer to read-only memory (such as a <c>const</c> variable or a literal string). If this parameter is a constant
		/// string, the function may cause an access violation.
		/// </para>
		/// <para>
		/// The lpCommandLine parameter can be NULL. In that case, the function uses the string pointed to by lpApplicationName as the
		/// command line.
		/// </para>
		/// <para>
		/// If both lpApplicationName and lpCommandLine are non- <c>NULL</c>, the null-terminated string pointed to by lpApplicationName
		/// specifies the module to execute, and the null-terminated string pointed to by lpCommandLine specifies the command line. The new
		/// process can use <c>GetCommandLine</c> to retrieve the entire command line. Console processes written in C can use the argc and
		/// argv arguments to parse the command line. Because argv[0] is the module name, C programmers generally repeat the module name as
		/// the first token in the command line.
		/// </para>
		/// <para>
		/// If lpApplicationName is NULL, the first white space–delimited token of the command line specifies the module name. If you are
		/// using a long file name that contains a space, use quoted strings to indicate where the file name ends and the arguments begin
		/// (see the explanation for the lpApplicationName parameter). If the file name does not contain an extension, .exe is appended.
		/// Therefore, if the file name extension is .com, this parameter must include the .com extension. If the file name ends in a period
		/// (.) with no extension, or if the file name contains a path, .exe is not appended. If the file name does not contain a directory
		/// path, the system searches for the executable file in the following sequence:
		/// </para>
		/// <para>
		/// The system adds a terminating null character to the command-line string to separate the file name from the arguments. This
		/// divides the original string into two strings for internal processing.
		/// </para>
		/// </param>
		/// <param name="lpProcessAttributes">
		/// <para>
		/// A pointer to a <c>SECURITY_ATTRIBUTES</c> structure that determines whether the returned handle to the new process object can be
		/// inherited by child processes. If lpProcessAttributes is <c>NULL</c>, the handle cannot be inherited.
		/// </para>
		/// <para>
		/// The <c>lpSecurityDescriptor</c> member of the structure specifies a security descriptor for the new process. If
		/// lpProcessAttributes is NULL or <c>lpSecurityDescriptor</c> is <c>NULL</c>, the process gets a default security descriptor. The
		/// ACLs in the default security descriptor for a process come from the primary token of the creator.
		/// </para>
		/// <para>
		/// <c>Windows XP:</c> The ACLs in the default security descriptor for a process come from the primary or impersonation token of the
		/// creator. This behavior changed with Windows XP with SP2 and Windows Server 2003.
		/// </para>
		/// </param>
		/// <param name="lpThreadAttributes">
		/// <para>
		/// A pointer to a <c>SECURITY_ATTRIBUTES</c> structure that determines whether the returned handle to the new thread object can be
		/// inherited by child processes. If lpThreadAttributes is NULL, the handle cannot be inherited.
		/// </para>
		/// <para>
		/// The <c>lpSecurityDescriptor</c> member of the structure specifies a security descriptor for the main thread. If
		/// lpThreadAttributes is NULL or <c>lpSecurityDescriptor</c> is NULL, the thread gets a default security descriptor. The ACLs in the
		/// default security descriptor for a thread come from the process token.
		/// </para>
		/// <para>
		/// <c>Windows XP:</c> The ACLs in the default security descriptor for a thread come from the primary or impersonation token of the
		/// creator. This behavior changed with Windows XP with SP2 and Windows Server 2003.
		/// </para>
		/// </param>
		/// <param name="bInheritHandles">
		/// <para>
		/// If this parameter is TRUE, each inheritable handle in the calling process is inherited by the new process. If the parameter is
		/// FALSE, the handles are not inherited. Note that inherited handles have the same value and access rights as the original handles.
		/// </para>
		/// <para>
		/// <c>Terminal Services:</c> You cannot inherit handles across sessions. Additionally, if this parameter is TRUE, you must create
		/// the process in the same session as the caller.
		/// </para>
		/// <para>
		/// <c>Protected Process Light (PPL) processes:</c> The generic handle inheritance is blocked when a PPL process creates a non-PPL
		/// process since PROCESS_DUP_HANDLE is not allowed from a non-PPL process to a PPL process. See Process Security and Access Rights
		/// </para>
		/// </param>
		/// <param name="dwCreationFlags">
		/// <para>
		/// The flags that control the priority class and the creation of the process. For a list of values, see Process Creation Flags.
		/// </para>
		/// <para>
		/// This parameter also controls the new process's priority class, which is used to determine the scheduling priorities of the
		/// process's threads. For a list of values, see <c>GetPriorityClass</c>. If none of the priority class flags is specified, the
		/// priority class defaults to <c>NORMAL_PRIORITY_CLASS</c> unless the priority class of the creating process is
		/// <c>IDLE_PRIORITY_CLASS</c> or <c>BELOW_NORMAL_PRIORITY_CLASS</c>. In this case, the child process receives the default priority
		/// class of the calling process.
		/// </para>
		/// </param>
		/// <param name="lpEnvironment">
		/// <para>
		/// A pointer to the environment block for the new process. If this parameter is <c>NULL</c>, the new process uses the environment of
		/// the calling process.
		/// </para>
		/// <para>An environment block consists of a null-terminated block of null-terminated strings. Each string is in the following form:</para>
		/// <para>name=value\0</para>
		/// <para>Because the equal sign is used as a separator, it must not be used in the name of an environment variable.</para>
		/// <para>
		/// An environment block can contain either Unicode or ANSI characters. If the environment block pointed to by lpEnvironment contains
		/// Unicode characters, be sure that dwCreationFlags includes <c>CREATE_UNICODE_ENVIRONMENT</c>. If this parameter is <c>NULL</c> and
		/// the environment block of the parent process contains Unicode characters, you must also ensure that dwCreationFlags includes <c>CREATE_UNICODE_ENVIRONMENT</c>.
		/// </para>
		/// <para>
		/// The ANSI version of this function, <c>CreateProcessA</c> fails if the total size of the environment block for the process exceeds
		/// 32,767 characters.
		/// </para>
		/// <para>
		/// Note that an ANSI environment block is terminated by two zero bytes: one for the last string, one more to terminate the block. A
		/// Unicode environment block is terminated by four zero bytes: two for the last string, two more to terminate the block.
		/// </para>
		/// </param>
		/// <param name="lpCurrentDirectory">
		/// <para>The full path to the current directory for the process. The string can also specify a UNC path.</para>
		/// <para>
		/// If this parameter is <c>NULL</c>, the new process will have the same current drive and directory as the calling process. (This
		/// feature is provided primarily for shells that need to start an application and specify its initial drive and working directory.)
		/// </para>
		/// </param>
		/// <param name="lpStartupInfo">
		/// <para>A pointer to a <c>STARTUPINFO</c> or <c>STARTUPINFOEX</c> structure.</para>
		/// <para>
		/// To set extended attributes, use a <c>STARTUPINFOEX</c> structure and specify EXTENDED_STARTUPINFO_PRESENT in the dwCreationFlags parameter.
		/// </para>
		/// <para>Handles in <c>STARTUPINFO</c> or <c>STARTUPINFOEX</c> must be closed with <c>CloseHandle</c> when they are no longer needed.</para>
		/// </param>
		/// <param name="lpProcessInformation">
		/// <para>A pointer to a <c>PROCESS_INFORMATION</c> structure that receives identification information about the new process.</para>
		/// <para>Handles in <c>PROCESS_INFORMATION</c> must be closed with <c>CloseHandle</c> when they are no longer needed.</para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is nonzero.</para>
		/// <para>If the function fails, the return value is zero. To get extended error information, call <c>GetLastError</c>.</para>
		/// <para>
		/// Note that the function returns before the process has finished initialization. If a required DLL cannot be located or fails to
		/// initialize, the process is terminated. To get the termination status of a process, call <c>GetExitCodeProcess</c>.
		/// </para>
		/// </returns>
		// BOOL WINAPI CreateProcess( _In_opt_ LPCTSTR lpApplicationName, _Inout_opt_ LPTSTR lpCommandLine, _In_opt_ LPSECURITY_ATTRIBUTES
		// lpProcessAttributes, _In_opt_ LPSECURITY_ATTRIBUTES lpThreadAttributes, _In_ BOOL bInheritHandles, _In_ DWORD dwCreationFlags,
		// _In_opt_ LPVOID lpEnvironment, _In_opt_ LPCTSTR lpCurrentDirectory, _In_ LPSTARTUPINFO lpStartupInfo, _Out_ LPPROCESS_INFORMATION
		// lpProcessInformation); https://msdn.microsoft.com/en-us/library/windows/desktop/ms682425(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = true, CharSet = CharSet.Auto)]
		[PInvokeData("WinBase.h", MSDNShortId = "ms682425")]
		[return: MarshalAs(UnmanagedType.Bool)]
		private static extern bool CreateProcess(string lpApplicationName, StringBuilder lpCommandLine, [In] SECURITY_ATTRIBUTES lpProcessAttributes,
			[In] SECURITY_ATTRIBUTES lpThreadAttributes, [MarshalAs(UnmanagedType.Bool)] bool bInheritHandles, CREATE_PROCESS dwCreationFlags, [In] IntPtr lpEnvironment,
			string lpCurrentDirectory, in STARTUPINFO lpStartupInfo, out PROCESS_INFORMATION lpProcessInformation);

		/// <summary>
		/// <para>Creates a new process and its primary thread. The new process runs in the security context of the calling process.</para>
		/// <para>
		/// If the calling process is impersonating another user, the new process uses the token for the calling process, not the
		/// impersonation token. To run the new process in the security context of the user represented by the impersonation token, use the
		/// <c>CreateProcessAsUser</c> or <c>CreateProcessWithLogonW</c> function.
		/// </para>
		/// </summary>
		/// <param name="lpApplicationName">
		/// <para>
		/// The name of the module to be executed. This module can be a Windows-based application. It can be some other type of module (for
		/// example, MS-DOS or OS/2) if the appropriate subsystem is available on the local computer.
		/// </para>
		/// <para>
		/// The string can specify the full path and file name of the module to execute or it can specify a partial name. In the case of a
		/// partial name, the function uses the current drive and current directory to complete the specification. The function will not use
		/// the search path. This parameter must include the file name extension; no default extension is assumed.
		/// </para>
		/// <para>
		/// The lpApplicationName parameter can be <c>NULL</c>. In that case, the module name must be the first white space–delimited token
		/// in the lpCommandLine string. If you are using a long file name that contains a space, use quoted strings to indicate where the
		/// file name ends and the arguments begin; otherwise, the file name is ambiguous. For example, consider the string "c:\program
		/// files\sub dir\program name". This string can be interpreted in a number of ways. The system tries to interpret the possibilities
		/// in the following order:
		/// </para>
		/// <para>
		/// If the executable module is a 16-bit application, lpApplicationName should be <c>NULL</c>, and the string pointed to by
		/// lpCommandLine should specify the executable module as well as its arguments.
		/// </para>
		/// <para>
		/// To run a batch file, you must start the command interpreter; set lpApplicationName to cmd.exe and set lpCommandLine to the
		/// following arguments: /c plus the name of the batch file.
		/// </para>
		/// </param>
		/// <param name="lpCommandLine">
		/// <para>
		/// The command line to be executed. The maximum length of this string is 32,768 characters, including the Unicode terminating null
		/// character. If lpApplicationName is <c>NULL</c>, the module name portion of lpCommandLine is limited to <c>MAX_PATH</c> characters.
		/// </para>
		/// <para>
		/// The Unicode version of this function, <c>CreateProcessW</c>, can modify the contents of this string. Therefore, this parameter
		/// cannot be a pointer to read-only memory (such as a <c>const</c> variable or a literal string). If this parameter is a constant
		/// string, the function may cause an access violation.
		/// </para>
		/// <para>
		/// The lpCommandLine parameter can be NULL. In that case, the function uses the string pointed to by lpApplicationName as the
		/// command line.
		/// </para>
		/// <para>
		/// If both lpApplicationName and lpCommandLine are non- <c>NULL</c>, the null-terminated string pointed to by lpApplicationName
		/// specifies the module to execute, and the null-terminated string pointed to by lpCommandLine specifies the command line. The new
		/// process can use <c>GetCommandLine</c> to retrieve the entire command line. Console processes written in C can use the argc and
		/// argv arguments to parse the command line. Because argv[0] is the module name, C programmers generally repeat the module name as
		/// the first token in the command line.
		/// </para>
		/// <para>
		/// If lpApplicationName is NULL, the first white space–delimited token of the command line specifies the module name. If you are
		/// using a long file name that contains a space, use quoted strings to indicate where the file name ends and the arguments begin
		/// (see the explanation for the lpApplicationName parameter). If the file name does not contain an extension, .exe is appended.
		/// Therefore, if the file name extension is .com, this parameter must include the .com extension. If the file name ends in a period
		/// (.) with no extension, or if the file name contains a path, .exe is not appended. If the file name does not contain a directory
		/// path, the system searches for the executable file in the following sequence:
		/// </para>
		/// <para>
		/// The system adds a terminating null character to the command-line string to separate the file name from the arguments. This
		/// divides the original string into two strings for internal processing.
		/// </para>
		/// </param>
		/// <param name="lpProcessAttributes">
		/// <para>
		/// A pointer to a <c>SECURITY_ATTRIBUTES</c> structure that determines whether the returned handle to the new process object can be
		/// inherited by child processes. If lpProcessAttributes is <c>NULL</c>, the handle cannot be inherited.
		/// </para>
		/// <para>
		/// The <c>lpSecurityDescriptor</c> member of the structure specifies a security descriptor for the new process. If
		/// lpProcessAttributes is NULL or <c>lpSecurityDescriptor</c> is <c>NULL</c>, the process gets a default security descriptor. The
		/// ACLs in the default security descriptor for a process come from the primary token of the creator.
		/// </para>
		/// <para>
		/// <c>Windows XP:</c> The ACLs in the default security descriptor for a process come from the primary or impersonation token of the
		/// creator. This behavior changed with Windows XP with SP2 and Windows Server 2003.
		/// </para>
		/// </param>
		/// <param name="lpThreadAttributes">
		/// <para>
		/// A pointer to a <c>SECURITY_ATTRIBUTES</c> structure that determines whether the returned handle to the new thread object can be
		/// inherited by child processes. If lpThreadAttributes is NULL, the handle cannot be inherited.
		/// </para>
		/// <para>
		/// The <c>lpSecurityDescriptor</c> member of the structure specifies a security descriptor for the main thread. If
		/// lpThreadAttributes is NULL or <c>lpSecurityDescriptor</c> is NULL, the thread gets a default security descriptor. The ACLs in the
		/// default security descriptor for a thread come from the process token.
		/// </para>
		/// <para>
		/// <c>Windows XP:</c> The ACLs in the default security descriptor for a thread come from the primary or impersonation token of the
		/// creator. This behavior changed with Windows XP with SP2 and Windows Server 2003.
		/// </para>
		/// </param>
		/// <param name="bInheritHandles">
		/// <para>
		/// If this parameter is TRUE, each inheritable handle in the calling process is inherited by the new process. If the parameter is
		/// FALSE, the handles are not inherited. Note that inherited handles have the same value and access rights as the original handles.
		/// </para>
		/// <para>
		/// <c>Terminal Services:</c> You cannot inherit handles across sessions. Additionally, if this parameter is TRUE, you must create
		/// the process in the same session as the caller.
		/// </para>
		/// <para>
		/// <c>Protected Process Light (PPL) processes:</c> The generic handle inheritance is blocked when a PPL process creates a non-PPL
		/// process since PROCESS_DUP_HANDLE is not allowed from a non-PPL process to a PPL process. See Process Security and Access Rights
		/// </para>
		/// </param>
		/// <param name="dwCreationFlags">
		/// <para>
		/// The flags that control the priority class and the creation of the process. For a list of values, see Process Creation Flags.
		/// </para>
		/// <para>
		/// This parameter also controls the new process's priority class, which is used to determine the scheduling priorities of the
		/// process's threads. For a list of values, see <c>GetPriorityClass</c>. If none of the priority class flags is specified, the
		/// priority class defaults to <c>NORMAL_PRIORITY_CLASS</c> unless the priority class of the creating process is
		/// <c>IDLE_PRIORITY_CLASS</c> or <c>BELOW_NORMAL_PRIORITY_CLASS</c>. In this case, the child process receives the default priority
		/// class of the calling process.
		/// </para>
		/// </param>
		/// <param name="lpEnvironment">
		/// <para>
		/// A pointer to the environment block for the new process. If this parameter is <c>NULL</c>, the new process uses the environment of
		/// the calling process.
		/// </para>
		/// <para>An environment block consists of a null-terminated block of null-terminated strings. Each string is in the following form:</para>
		/// <para>name=value\0</para>
		/// <para>Because the equal sign is used as a separator, it must not be used in the name of an environment variable.</para>
		/// <para>
		/// An environment block can contain either Unicode or ANSI characters. If the environment block pointed to by lpEnvironment contains
		/// Unicode characters, be sure that dwCreationFlags includes <c>CREATE_UNICODE_ENVIRONMENT</c>. If this parameter is <c>NULL</c> and
		/// the environment block of the parent process contains Unicode characters, you must also ensure that dwCreationFlags includes <c>CREATE_UNICODE_ENVIRONMENT</c>.
		/// </para>
		/// <para>
		/// The ANSI version of this function, <c>CreateProcessA</c> fails if the total size of the environment block for the process exceeds
		/// 32,767 characters.
		/// </para>
		/// <para>
		/// Note that an ANSI environment block is terminated by two zero bytes: one for the last string, one more to terminate the block. A
		/// Unicode environment block is terminated by four zero bytes: two for the last string, two more to terminate the block.
		/// </para>
		/// </param>
		/// <param name="lpCurrentDirectory">
		/// <para>The full path to the current directory for the process. The string can also specify a UNC path.</para>
		/// <para>
		/// If this parameter is <c>NULL</c>, the new process will have the same current drive and directory as the calling process. (This
		/// feature is provided primarily for shells that need to start an application and specify its initial drive and working directory.)
		/// </para>
		/// </param>
		/// <param name="lpStartupInfo">
		/// <para>A pointer to a <c>STARTUPINFO</c> or <c>STARTUPINFOEX</c> structure.</para>
		/// <para>
		/// To set extended attributes, use a <c>STARTUPINFOEX</c> structure and specify EXTENDED_STARTUPINFO_PRESENT in the dwCreationFlags parameter.
		/// </para>
		/// <para>Handles in <c>STARTUPINFO</c> or <c>STARTUPINFOEX</c> must be closed with <c>CloseHandle</c> when they are no longer needed.</para>
		/// </param>
		/// <param name="lpProcessInformation">
		/// <para>A pointer to a <c>PROCESS_INFORMATION</c> structure that receives identification information about the new process.</para>
		/// <para>Handles in <c>PROCESS_INFORMATION</c> must be closed with <c>CloseHandle</c> when they are no longer needed.</para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is nonzero.</para>
		/// <para>If the function fails, the return value is zero. To get extended error information, call <c>GetLastError</c>.</para>
		/// <para>
		/// Note that the function returns before the process has finished initialization. If a required DLL cannot be located or fails to
		/// initialize, the process is terminated. To get the termination status of a process, call <c>GetExitCodeProcess</c>.
		/// </para>
		/// </returns>
		// BOOL WINAPI CreateProcess( _In_opt_ LPCTSTR lpApplicationName, _Inout_opt_ LPTSTR lpCommandLine, _In_opt_ LPSECURITY_ATTRIBUTES
		// lpProcessAttributes, _In_opt_ LPSECURITY_ATTRIBUTES lpThreadAttributes, _In_ BOOL bInheritHandles, _In_ DWORD dwCreationFlags,
		// _In_opt_ LPVOID lpEnvironment, _In_opt_ LPCTSTR lpCurrentDirectory, _In_ LPSTARTUPINFO lpStartupInfo, _Out_ LPPROCESS_INFORMATION
		// lpProcessInformation); https://msdn.microsoft.com/en-us/library/windows/desktop/ms682425(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = true, CharSet = CharSet.Auto)]
		[PInvokeData("WinBase.h", MSDNShortId = "ms682425")]
		[return: MarshalAs(UnmanagedType.Bool)]
		private static extern bool CreateProcess(string lpApplicationName, StringBuilder lpCommandLine, [In] SECURITY_ATTRIBUTES lpProcessAttributes,
			[In] SECURITY_ATTRIBUTES lpThreadAttributes, [MarshalAs(UnmanagedType.Bool)] bool bInheritHandles, CREATE_PROCESS dwCreationFlags, [In] IntPtr lpEnvironment,
			string lpCurrentDirectory, in STARTUPINFOEX lpStartupInfo, out PROCESS_INFORMATION lpProcessInformation);

		/// <summary>Retrieves the contents of the <c>STARTUPINFO</c> structure that was specified when the calling process was created.</summary>
		/// <param name="lpStartupInfo">A pointer to a <c>STARTUPINFO</c> structure that receives the startup information.</param>
		/// <returns>
		/// <para>This function does not return a value.</para>
		/// <para>
		/// If an error occurs, the ANSI version of this function ( <c>GetStartupInfoA</c>) can raise an exception. The Unicode version (
		/// <c>GetStartupInfoW</c>) does not fail.
		/// </para>
		/// </returns>
		// VOID WINAPI GetStartupInfo( _Out_ LPSTARTUPINFO lpStartupInfo); https://msdn.microsoft.com/en-us/library/windows/desktop/ms683230(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = false, CharSet = CharSet.Auto)]
		[PInvokeData("WinBase.h", MSDNShortId = "ms683230")]
		private static extern void GetStartupInfo(out STARTUPINFO_OUT lpStartupInfo);

		private static bool Is64bitOS() => !(0 == GetSystemWow64Directory(null, 0) && Win32Error.GetLastError() == Win32Error.ERROR_CALL_NOT_IMPLEMENTED);

		/// <summary>
		/// Represents app memory usage at a single point in time. This structure is used by the <c>PROCESS_INFORMATION_CLASS</c> class.
		/// </summary>
		// typedef struct _APP_MEMORY_INFORMATION { ULONG64 AvailableCommit; ULONG64 PrivateCommitUsage; ULONG64 PeakPrivateCommitUsage;
		// ULONG64 TotalCommitUsage;} APP_MEMORY_INFORMATION, *PAPP_MEMORY_INFORMATION; https://msdn.microsoft.com/en-us/library/windows/desktop/mt767995(v=vs.85).aspx
		[PInvokeData("WinBase.h", MSDNShortId = "mt767995")]
		[StructLayout(LayoutKind.Sequential)]
		public struct APP_MEMORY_INFORMATION
		{
			/// <summary>Total commit available to the app.</summary>
			public ulong AvailableCommit;

			/// <summary>The app's usage of private commit.</summary>
			public ulong PrivateCommitUsage;

			/// <summary>The app's peak usage of private commit.</summary>
			public ulong PeakPrivateCommitUsage;

			/// <summary>The app's total usage of private plus shared commit.</summary>
			public ulong TotalCommitUsage;
		}

		/// <summary>
		/// Contains processor-specific register data. The system uses CONTEXT structures to perform various internal operations. Refer to
		/// the header file WinNT.h for definitions of this structure for each processor architecture.
		/// </summary>
		// https://msdn.microsoft.com/en-us/library/windows/desktop/ms679284(v=vs.85).aspx
		[StructLayout(LayoutKind.Sequential)]
		public struct CONTEXT
		{
			public uint ContextFlags;
			public uint Dr0;
			public uint Dr1;
			public uint Dr2;
			public uint Dr3;
			public uint Dr6;
			public uint Dr7;

			// Retrieved by CONTEXT_FLOATING_POINT
			public FLOATING_SAVE_AREA FloatSave;

			// Retrieved by CONTEXT_SEGMENTS
			public uint SegGs;

			public uint SegFs;
			public uint SegEs;
			public uint SegDs;

			// Retrieved by CONTEXT_INTEGER
			public uint Edi;

			public uint Esi;
			public uint Ebx;
			public uint Edx;
			public uint Ecx;
			public uint Eax;

			// Retrieved by CONTEXT_CONTROL
			public uint Ebp;

			public uint Eip;
			public uint SegCs;
			public uint EFlags;
			public uint Esp;
			public uint SegSs;

			// Retrieved by CONTEXT_EXTENDED_REGISTERS
			[MarshalAs(UnmanagedType.ByValArray, SizeConst = 512)]
			public byte[] ExtendedRegisters;

			/// <summary>Represents the 80387 save area on WOW64. Refer to the header file WinNT.h for the definition of this structure.</summary>
			// https://msdn.microsoft.com/en-us/library/windows/desktop/ms681671(v=vs.85).aspx
			[PInvokeData("WinNT.h", MSDNShortId = "ms681671")]
			[StructLayout(LayoutKind.Sequential)]
			public struct FLOATING_SAVE_AREA
			{
				public int ControlWord;
				public int StatusWord;
				public int TagWord;
				public int ErrorOffset;
				public int ErrorSelector;
				public int DataOffset;
				public int DataSelector;
				[MarshalAs(UnmanagedType.ByValArray, SizeConst = 80)] public byte[] RegisterArea;
				public int Cr0NpxState;
			}

			/// <summary>Initializes a new instance of the <see cref="CONTEXT"/> struct.</summary>
			/// <param name="flags">The context flags.</param>
			public CONTEXT(uint flags) : this() { ContextFlags = flags; }
		}

		[StructLayout(LayoutKind.Sequential, Pack = 16)]
		public struct CONTEXT64
		{
			public ulong P1Home;
			public ulong P2Home;
			public ulong P3Home;
			public ulong P4Home;
			public ulong P5Home;
			public ulong P6Home;

			public uint ContextFlags;
			public uint MxCsr;

			public ushort SegCs;
			public ushort SegDs;
			public ushort SegEs;
			public ushort SegFs;
			public ushort SegGs;
			public ushort SegSs;
			public uint EFlags;

			public ulong Dr0;
			public ulong Dr1;
			public ulong Dr2;
			public ulong Dr3;
			public ulong Dr6;
			public ulong Dr7;

			public ulong Rax;
			public ulong Rcx;
			public ulong Rdx;
			public ulong Rbx;
			public ulong Rsp;
			public ulong Rbp;
			public ulong Rsi;
			public ulong Rdi;
			public ulong R8;
			public ulong R9;
			public ulong R10;
			public ulong R11;
			public ulong R12;
			public ulong R13;
			public ulong R14;
			public ulong R15;
			public ulong Rip;

			public XSAVE_FORMAT64 DUMMYUNIONNAME;

			[MarshalAs(UnmanagedType.ByValArray, SizeConst = 26)]
			public M128A[] VectorRegister;

			public ulong VectorControl;

			public ulong DebugControl;
			public ulong LastBranchToRip;
			public ulong LastBranchFromRip;
			public ulong LastExceptionToRip;
			public ulong LastExceptionFromRip;

			[StructLayout(LayoutKind.Sequential)]
			public struct M128A
			{
				public ulong High;
				public long Low;
			}

			[StructLayout(LayoutKind.Sequential, Pack = 16)]
			public struct XSAVE_FORMAT64
			{
				public ushort ControlWord;
				public ushort StatusWord;
				public byte TagWord;
				public byte Reserved1;
				public ushort ErrorOpcode;
				public uint ErrorOffset;
				public ushort ErrorSelector;
				public ushort Reserved2;
				public uint DataOffset;
				public ushort DataSelector;
				public ushort Reserved3;
				public uint MxCsr;
				public uint MxCsr_Mask;

				[MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
				public M128A[] FloatRegisters;

				[MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
				public M128A[] XmmRegisters;

				[MarshalAs(UnmanagedType.ByValArray, SizeConst = 96)]
				public byte[] Reserved4;
			}
		}

		/// <summary>
		/// Specifies the memory priority for a thread or process. This structure is used by the <c>GetProcessInformation</c>,
		/// <c>SetProcessInformation</c>, <c>GetThreadInformation</c>, and <c>SetThreadInformation</c> functions.
		/// </summary>
		// typedef struct _MEMORY_PRIORITY_INFORMATION { ULONG MemoryPriority;} MEMORY_PRIORITY_INFORMATION, *PMEMORY_PRIORITY_INFORMATION; https://msdn.microsoft.com/en-us/library/windows/desktop/hh448387(v=vs.85).aspx
		[PInvokeData("WinBase.h", MSDNShortId = "hh448387")]
		[StructLayout(LayoutKind.Sequential)]
		public struct MEMORY_PRIORITY_INFORMATION
		{
			/// <summary>
			/// <para>The memory priority for the thread or process. This member can be one of the following values.</para>
			/// <para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>MEMORY_PRIORITY_VERY_LOW1</term>
			/// <term>Very low memory priority.</term>
			/// </item>
			/// <item>
			/// <term>MEMORY_PRIORITY_LOW2</term>
			/// <term>Low memory priority.</term>
			/// </item>
			/// <item>
			/// <term>MEMORY_PRIORITY_MEDIUM3</term>
			/// <term>Medium memory priority.</term>
			/// </item>
			/// <item>
			/// <term>MEMORY_PRIORITY_BELOW_NORMAL4</term>
			/// <term>Below normal memory priority.</term>
			/// </item>
			/// <item>
			/// <term>MEMORY_PRIORITY_NORMAL5</term>
			/// <term>Normal memory priority. This is the default priority for all threads and processes on the system.</term>
			/// </item>
			/// </list>
			/// </para>
			/// </summary>
			public MEMORY_PRIORITY MemoryPriority;

			/// <summary>Initializes a new instance of the <see cref="MEMORY_PRIORITY_INFORMATION"/> struct.</summary>
			/// <param name="memoryPriority">The memory priority for the thread or process.</param>
			public MEMORY_PRIORITY_INFORMATION(MEMORY_PRIORITY memoryPriority)
			{
				MemoryPriority = memoryPriority;
			}
		}

		/// <summary>Represents a process or thread attribute identifier.</summary>
		[StructLayout(LayoutKind.Sequential)]
		public struct PROC_THREAD_ATTRIBUTE : IEquatable<PROC_THREAD_ATTRIBUTE>, IEquatable<UIntPtr>
		{
			private UIntPtr value;

			private const uint PROC_THREAD_ATTRIBUTE_NUMBER = 0x0000FFFF;
			private const uint PROC_THREAD_ATTRIBUTE_THREAD = 0x00010000;
			private const uint PROC_THREAD_ATTRIBUTE_INPUT = 0x00020000;
			private const uint PROC_THREAD_ATTRIBUTE_ADDITIVE = 0x00040000;

			private static Dictionary<uint, Type> typeLookup = new Dictionary<uint, Type>();

			static PROC_THREAD_ATTRIBUTE()
			{
				typeLookup.Add(PROC_THREAD_ATTRIBUTE_ALL_APPLICATION_PACKAGES_POLICY, null);
				typeLookup.Add(PROC_THREAD_ATTRIBUTE_CHILD_PROCESS_POLICY, typeof(ulong));
				typeLookup.Add(PROC_THREAD_ATTRIBUTE_DESKTOP_APP_POLICY, typeof(uint));
				typeLookup.Add(PROC_THREAD_ATTRIBUTE_GROUP_AFFINITY, typeof(GROUP_AFFINITY));
				typeLookup.Add(PROC_THREAD_ATTRIBUTE_HANDLE_LIST, typeof(HANDLE[]));
				typeLookup.Add(PROC_THREAD_ATTRIBUTE_IDEAL_PROCESSOR, typeof(PROCESSOR_NUMBER));
				typeLookup.Add(PROC_THREAD_ATTRIBUTE_JOB_LIST, null);
				typeLookup.Add(PROC_THREAD_ATTRIBUTE_MITIGATION_POLICY, typeof(ulong));
				typeLookup.Add(PROC_THREAD_ATTRIBUTE_PARENT_PROCESS, typeof(HPROCESS));
				typeLookup.Add(PROC_THREAD_ATTRIBUTE_PREFERRED_NODE, typeof(uint));
				typeLookup.Add(PROC_THREAD_ATTRIBUTE_PROTECTION_LEVEL, typeof(uint));
				typeLookup.Add(PROC_THREAD_ATTRIBUTE_SECURITY_CAPABILITIES, typeof(SECURITY_CAPABILITIES));
				typeLookup.Add(PROC_THREAD_ATTRIBUTE_UMS_THREAD, typeof(UMS_CREATE_THREAD_ATTRIBUTES));
				typeLookup.Add(PROC_THREAD_ATTRIBUTE_WIN32K_FILTER, null);
			}

			/// <summary>Determines equality.</summary>
			/// <param name="attr">The attribute to compare.</param>
			/// <returns><see langword="true"/> if the value is equal to this instance.</returns>
			public bool Equals(PROC_THREAD_ATTRIBUTE attr) => value.Equals(attr.value);

			/// <summary>Determines equality.</summary>
			/// <param name="puint">The <see cref="UIntPtr"/> value.</param>
			/// <returns><see langword="true"/> if the value is equal to this instance.</returns>
			public bool Equals(UIntPtr puint) => value.Equals(puint);

			/// <summary>Determines whether the specified <see cref="System.Object"/>, is equal to this instance.</summary>
			/// <param name="obj">The <see cref="System.Object"/> to compare with this instance.</param>
			/// <returns><c>true</c> if the specified <see cref="System.Object"/> is equal to this instance; otherwise, <c>false</c>.</returns>
			public override bool Equals(object obj)
			{
				switch (obj)
				{
					case PROC_THREAD_ATTRIBUTE pta:
						return Equals(pta);

					case UIntPtr up:
						return Equals(up);

					case uint ui:
						return ui.Equals(this);

					default:
						return base.Equals(obj);
				}
			}

			/// <summary>Returns a hash code for this instance.</summary>
			/// <returns>A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.</returns>
			public override int GetHashCode() => unchecked((int)value.ToUInt32());

			/// <summary>Performs an implicit conversion from <see cref="PROC_THREAD_ATTRIBUTE"/> to <see cref="System.UInt32"/>.</summary>
			/// <param name="pta">The PROC_THREAD_ATTRIBUTE.</param>
			/// <returns>The result of the conversion.</returns>
			public static implicit operator uint(PROC_THREAD_ATTRIBUTE pta) => pta.value.ToUInt32();

			/// <summary>A type specifier for an attribute.</summary>
			public enum AttrType : uint
			{
				ProcThreadAttributeParentProcess = 0,
				ProcThreadAttributeHandleList = 2,
				ProcThreadAttributeGroupAffinity = 3,
				ProcThreadAttributePreferredNode = 4,
				ProcThreadAttributeIdealProcessor = 5,
				ProcThreadAttributeUmsThread = 6,
				ProcThreadAttributeMitigationPolicy = 7,
				ProcThreadAttributeSecurityCapabilities = 9,
				ProcThreadAttributeProtectionLevel = 11,
				ProcThreadAttributeJobList = 13,
				ProcThreadAttributeChildProcessPolicy = 14,
				ProcThreadAttributeAllApplicationPackagesPolicy = 15,
				ProcThreadAttributeWin32kFilter = 16,
				ProcThreadAttributeSafeOpenPromptOriginClaim = 17,
				ProcThreadAttributeDesktopAppPolicy = 18,
			}

			/// <summary>Initializes a new instance of the <see cref="PROC_THREAD_ATTRIBUTE"/> struct.</summary>
			/// <param name="Number">The attribute type.</param>
			/// <param name="Thread">if set to <c>true</c> this is thread specific.</param>
			/// <param name="Input">if set to <c>true</c> this is an input attribute.</param>
			/// <param name="Additive">if set to <c>true</c> this is additive.</param>
			public PROC_THREAD_ATTRIBUTE(AttrType type, bool Thread, bool Input, bool Additive) =>
				value = (UIntPtr)(((uint)type & PROC_THREAD_ATTRIBUTE_NUMBER) | (Thread ? PROC_THREAD_ATTRIBUTE_THREAD : 0) |
				(Input ? PROC_THREAD_ATTRIBUTE_INPUT : 0) | (Additive ? PROC_THREAD_ATTRIBUTE_ADDITIVE : 0));

			/// <summary>Gets the type associated with this attribute.</summary>
			public Type ValidType => LookupType(this);

			/// <summary>Performs an implicit conversion from <see cref="PROC_THREAD_ATTRIBUTE"/> to <see cref="UIntPtr"/>.</summary>
			/// <param name="attr">The attribute.</param>
			/// <returns>The result of the conversion.</returns>
			public static implicit operator UIntPtr(PROC_THREAD_ATTRIBUTE attr) => attr.value;

			/// <summary>Lookups the type associated with an attribute.</summary>
			/// <param name="attr">The attribute.</param>
			/// <returns>The associated type, or <see langword="null"/> if not found.</returns>
			public static Type LookupType(PROC_THREAD_ATTRIBUTE attr) => typeLookup.TryGetValue(attr, out var type) ? type : null;

			/// <summary>Undocumented.</summary>
			public static readonly PROC_THREAD_ATTRIBUTE PROC_THREAD_ATTRIBUTE_ALL_APPLICATION_PACKAGES_POLICY = new PROC_THREAD_ATTRIBUTE(AttrType.ProcThreadAttributeAllApplicationPackagesPolicy, false, true, false);

			/// <summary>
			/// The lpValue parameter is a pointer to a DWORD or DWORD64 value that specifies the child process policy. THe policy specifies
			/// whether to allow a child process to be created.For information on the possible values for the DWORD or DWORD64 to which
			/// lpValue points, see Remarks.
			/// </summary>
			public static readonly PROC_THREAD_ATTRIBUTE PROC_THREAD_ATTRIBUTE_CHILD_PROCESS_POLICY = new PROC_THREAD_ATTRIBUTE(AttrType.ProcThreadAttributeChildProcessPolicy, false, true, false);

			/// <summary>
			/// This attribute is relevant only to win32 applications that have been converted to UWP packages by using the Desktop Bridge.
			/// The lpValue parameter is a pointer to a DWORD value that specifies the desktop app policy. The policy specifies whether
			/// descendant processes should continue to run in the desktop environment.For information about the possible values for the
			/// DWORD to which lpValue points, see Remarks.
			/// </summary>
			public static readonly PROC_THREAD_ATTRIBUTE PROC_THREAD_ATTRIBUTE_DESKTOP_APP_POLICY = new PROC_THREAD_ATTRIBUTE(AttrType.ProcThreadAttributeDesktopAppPolicy, false, true, false);

			/// <summary>
			/// The lpValue parameter is a pointer to a GROUP_AFFINITY structure that specifies the processor group affinity for the new
			/// thread.Windows Server 2008 and Windows Vista: This value is not supported until Windows 7 and Windows Server 2008 R2.
			/// </summary>
			public static readonly PROC_THREAD_ATTRIBUTE PROC_THREAD_ATTRIBUTE_GROUP_AFFINITY = new PROC_THREAD_ATTRIBUTE(AttrType.ProcThreadAttributeGroupAffinity, true, true, false);

			/// <summary>
			/// The lpValue parameter is a pointer to a list of handles to be inherited by the child process.These handles must be created as
			/// inheritable handles and must not include pseudo handles such as those returned by the GetCurrentProcess or GetCurrentThread function.
			/// </summary>
			public static readonly PROC_THREAD_ATTRIBUTE PROC_THREAD_ATTRIBUTE_HANDLE_LIST = new PROC_THREAD_ATTRIBUTE(AttrType.ProcThreadAttributeHandleList, false, true, false);

			/// <summary>
			/// The lpValue parameter is a pointer to a PROCESSOR_NUMBER structure that specifies the ideal processor for the new
			/// thread.Windows Server 2008 and Windows Vista: This value is not supported until Windows 7 and Windows Server 2008 R2.
			/// </summary>
			public static readonly PROC_THREAD_ATTRIBUTE PROC_THREAD_ATTRIBUTE_IDEAL_PROCESSOR = new PROC_THREAD_ATTRIBUTE(AttrType.ProcThreadAttributeIdealProcessor, true, true, false);

			/// <summary>Undocumented.</summary>
			public static readonly PROC_THREAD_ATTRIBUTE PROC_THREAD_ATTRIBUTE_JOB_LIST = new PROC_THREAD_ATTRIBUTE(AttrType.ProcThreadAttributeJobList, false, true, false);

			/// <summary>
			/// The lpValue parameter is a pointer to a DWORD or DWORD64 that specifies the exploit mitigation policy for the child process.
			/// Starting in Windows 10, version 1703, this parameter can also be a pointer to a two-element DWORD64 array.The specified
			/// policy overrides the policies set for the application and the system and cannot be changed after the child process starts
			/// running. Windows Server 2008 and Windows Vista: This value is not supported until Windows 7 and Windows Server 2008 R2.The
			/// DWORD or DWORD64 pointed to by lpValue can be one or more of the values listed in the remarks.
			/// </summary>
			public static readonly PROC_THREAD_ATTRIBUTE PROC_THREAD_ATTRIBUTE_MITIGATION_POLICY = new PROC_THREAD_ATTRIBUTE(AttrType.ProcThreadAttributeMitigationPolicy, false, true, false);

			/// <summary>
			/// The lpValue parameter is a pointer to a handle to a process to use instead of the calling process as the parent for the
			/// process being created. The process to use must have the PROCESS_CREATE_PROCESS access right.Attributes inherited from the
			/// specified process include handles, the device map, processor affinity, priority, quotas, the process token, and job object.
			/// (Note that some attributes such as the debug port will come from the creating process, not the process specified by this handle.)
			/// </summary>
			public static readonly PROC_THREAD_ATTRIBUTE PROC_THREAD_ATTRIBUTE_PARENT_PROCESS = new PROC_THREAD_ATTRIBUTE(AttrType.ProcThreadAttributeParentProcess, false, true, false);

			/// <summary>
			/// The lpValue parameter is a pointer to the node number of the preferred NUMA node for the new process.Windows Server 2008 and
			/// Windows Vista: This value is not supported until Windows 7 and Windows Server 2008 R2.
			/// </summary>
			public static readonly PROC_THREAD_ATTRIBUTE PROC_THREAD_ATTRIBUTE_PREFERRED_NODE = new PROC_THREAD_ATTRIBUTE(AttrType.ProcThreadAttributePreferredNode, false, true, false);

			/// <summary>
			/// The lpValue parameter is a pointer to a DWORD value of PROTECTION_LEVEL_SAME. This specifies the protection level of the
			/// child process to be the same as the protection level of its parent process.
			/// </summary>
			public static readonly PROC_THREAD_ATTRIBUTE PROC_THREAD_ATTRIBUTE_PROTECTION_LEVEL = new PROC_THREAD_ATTRIBUTE(AttrType.ProcThreadAttributeProtectionLevel, false, true, false);

			/// <summary>
			/// The lpValue parameter is a pointer to a SECURITY_CAPABILITIES structure that defines the security capabilities of an app
			/// container. If this attribute is set the new process will be created as an AppContainer process.Windows 7, Windows Server 2008
			/// R2, Windows Server 2008 and Windows Vista: This value is not supported until Windows 8 and Windows Server 2012.
			/// </summary>
			public static readonly PROC_THREAD_ATTRIBUTE PROC_THREAD_ATTRIBUTE_SECURITY_CAPABILITIES = new PROC_THREAD_ATTRIBUTE(AttrType.ProcThreadAttributeSecurityCapabilities, false, true, false);

			/// <summary>
			/// The lpValue parameter is a pointer to a UMS_CREATE_THREAD_ATTRIBUTES structure that specifies a user-mode scheduling (UMS)
			/// thread context and a UMS completion list to associate with the thread. After the UMS thread is created, the system queues it
			/// to the specified completion list. The UMS thread runs only when an application's UMS scheduler retrieves the UMS thread from
			/// the completion list and selects it to run. For more information, see User-Mode Scheduling.Windows Server 2008 and Windows
			/// Vista: This value is not supported until Windows 7 and Windows Server 2008 R2.
			/// </summary>
			public static readonly PROC_THREAD_ATTRIBUTE PROC_THREAD_ATTRIBUTE_UMS_THREAD = new PROC_THREAD_ATTRIBUTE(AttrType.ProcThreadAttributeUmsThread, true, true, false);

			/// <summary>Undocumented.</summary>
			public static readonly PROC_THREAD_ATTRIBUTE PROC_THREAD_ATTRIBUTE_WIN32K_FILTER = new PROC_THREAD_ATTRIBUTE(AttrType.ProcThreadAttributeWin32kFilter, false, true, false);
		}

		/// <summary>
		/// Contains information about a newly created process and its primary thread. It is used with the <c>CreateProcess</c>,
		/// <c>CreateProcessAsUser</c>, <c>CreateProcessWithLogonW</c>, or <c>CreateProcessWithTokenW</c> function.
		/// </summary>
		// typedef struct _PROCESS_INFORMATION { HANDLE hProcess; HANDLE hThread; DWORD dwProcessId; DWORD dwThreadId;} PROCESS_INFORMATION,
		// *LPPROCESS_INFORMATION; https://msdn.microsoft.com/en-us/library/windows/desktop/ms684873(v=vs.85).aspx
		[PInvokeData("WinBase.h", MSDNShortId = "ms684873")]
		[StructLayout(LayoutKind.Sequential)]
		public struct PROCESS_INFORMATION
		{
			/// <summary>
			/// A handle to the newly created process. The handle is used to specify the process in all functions that perform operations on
			/// the process object.
			/// </summary>
			public HPROCESS hProcess;

			/// <summary>
			/// A handle to the primary thread of the newly created process. The handle is used to specify the thread in all functions that
			/// perform operations on the thread object.
			/// </summary>
			public HTHREAD hThread;

			/// <summary>
			/// A value that can be used to identify a process. The value is valid from the time the process is created until all handles to
			/// the process are closed and the process object is freed; at this point, the identifier may be reused.
			/// </summary>
			public uint dwProcessId;

			/// <summary>
			/// A value that can be used to identify a thread. The value is valid from the time the thread is created until all handles to
			/// the thread are closed and the thread object is freed; at this point, the identifier may be reused.
			/// </summary>
			public uint dwThreadId;
		}

		/// <summary>
		/// Allows applications to configure a process to terminate if an allocation fails to commit memory. This structure is used by the
		/// <c>PROCESS_INFORMATION_CLASS</c> class.
		/// </summary>
		// typedef struct _PROCESS_MEMORY_EXHAUSTION_INFO { USHORT Version; USHORT Reserved; PROCESS_MEMORY_EXHAUSTION_TYPE Type; ULONG_PTR
		// Value;} PROCESS_MEMORY_EXHAUSTION_INFO, *PPROCESS_MEMORY_EXHAUSTION_INFO;// https://msdn.microsoft.com/en-us/library/windows/desktop/mt767997(v=vs.85).aspx
		[PInvokeData("WinBase.h", MSDNShortId = "mt767997")]
		[StructLayout(LayoutKind.Sequential)]
		public struct PROCESS_MEMORY_EXHAUSTION_INFO
		{
			/// <summary>Version should be set to <c>PME_CURRENT_VERSION</c>.</summary>
			public ushort Version;

			/// <summary>Reserved.</summary>
			public ushort Reserved;

			/// <summary>
			/// <para>Type of failure.</para>
			/// <para>Type should be set to <c>PMETypeFailFastOnCommitFailure</c> (this is the only type available).</para>
			/// </summary>
			public PROCESS_MEMORY_EXHAUSTION_TYPE Type;

			/// <summary>
			/// <para>Used to turn the feature on or off.</para>
			/// <para>
			/// <list type="table">
			/// <listheader>
			/// <term>Function</term>
			/// <term>Setting</term>
			/// </listheader>
			/// <item>
			/// <term>Enable</term>
			/// <term>PME_FAILFAST_ON_COMMIT_FAIL_ENABLE</term>
			/// </item>
			/// <item>
			/// <term>Disable</term>
			/// <term>PME_FAILFAST_ON_COMMIT_FAIL_DISABLE</term>
			/// </item>
			/// </list>
			/// </para>
			/// </summary>
			public UIntPtr Value;
		}

		/// <summary>
		/// Contains process mitigation policy settings for Address Space Randomization Layout (ASLR). The <c>GetProcessMitigationPolicy</c>
		/// and <c>SetProcessMitigationPolicy</c> functions use this structure.
		/// </summary>
		// typedef struct _PROCESS_MITIGATION_ASLR_POLICY { union { DWORD Flags; struct { DWORD EnableBottomUpRandomization : 1; DWORD
		// EnableForceRelocateImages : 1; DWORD EnableHighEntropy : 1; DWORD DisallowStrippedImages : 1; DWORD ReservedFlags : 28; }; };} PROCESS_MITIGATION_ASLR_POLICY,
		// *PPROCESS_MITIGATION_ASLR_POLICY; https://msdn.microsoft.com/en-us/library/windows/desktop/hh769086(v=vs.85).aspx
		[PInvokeData("WinNT.h", MSDNShortId = "hh769086")]
		[StructLayout(LayoutKind.Sequential)]
		public struct PROCESS_MITIGATION_ASLR_POLICY
		{
			/// <summary>The flags</summary>
			public PROCESS_MITIGATION_ASLR_POLICY_FLAGS Flags;
		}

		/// <summary>Contains process mitigation policy settings for the loading of images depending on the signatures for the image.</summary>
		// typedef struct _PROCESS_MITIGATION_BINARY_SIGNATURE_POLICY { union { DWORD Flags; struct { DWORD MicrosoftSignedOnly :1; DWORD
		// StoreSignedOnly :1; DWORD MitigationOptIn :1; DWORD ReservedFlags :29; }; };} PROCESS_MITIGATION_BINARY_SIGNATURE_POLICY,
		// *PPROCESS_MITIGATION_BINARY_SIGNATURE_POLICY; https://msdn.microsoft.com/en-us/library/windows/desktop/mt706242(v=vs.85).aspx
		[PInvokeData("WinNT.h", MSDNShortId = "mt706242")]
		[StructLayout(LayoutKind.Sequential)]
		public struct PROCESS_MITIGATION_BINARY_SIGNATURE_POLICY
		{
			/// <summary>The flags</summary>
			public PROCESS_MITIGATION_BINARY_SIGNATURE_POLICY_FLAGS Flags;
		}

		/// <summary>Stores policy information about creating child processes.</summary>
		// https://docs.microsoft.com/en-us/windows-hardware/drivers/ddi/content/ntddk/ns-ntddk-_process_mitigation_child_process_policy
		[PInvokeData("WinNT.h", MSDNShortId = "")]
		[StructLayout(LayoutKind.Sequential)]
		public struct PROCESS_MITIGATION_CHILD_PROCESS_POLICY
		{
			/// <summary>The flags</summary>
			public PROCESS_MITIGATION_CHILD_PROCESS_POLICY_FLAGS Flags;
		}

		/// <summary>
		/// Contains process mitigation policy settings for Control Flow Guard (CFG). The <c>GetProcessMitigationPolicy</c> and
		/// <c>SetProcessMitigationPolicy</c> functions use this structure.
		/// </summary>
		// typedef struct _PROCESS_MITIGATION_CONTROL_FLOW_GUARD_POLICY { union { DWORD Flags; struct { DWORD EnableControlFlowGuard :1;
		// DWORD EnableExportSuppression :1; DWORD StrictMode :1; DWORD ReservedFlags :29; }; };} PROCESS_MITIGATION_CONTROL_FLOW_GUARD_POLICY,
		// *PPROCESS_MITIGATION_CONTROL_FLOW_GUARD_POLICY; https://msdn.microsoft.com/en-us/library/windows/desktop/mt654121(v=vs.85).aspx
		[PInvokeData("WinNT.h", MSDNShortId = "mt654121")]
		[StructLayout(LayoutKind.Sequential)]
		public struct PROCESS_MITIGATION_CONTROL_FLOW_GUARD_POLICY
		{
			/// <summary>The flags</summary>
			public PROCESS_MITIGATION_CONTROL_FLOW_GUARD_POLICY_FLAGS Flags;
		}

		/// <summary>
		/// Contains process mitigation policy settings for data execution prevention (DEP). The <c>GetProcessMitigationPolicy</c> and
		/// <c>SetProcessMitigationPolicy</c> functions use this structure.
		/// </summary>
		// typedef struct _PROCESS_MITIGATION_DEP_POLICY { union { DWORD Flags; struct { DWORD Enable : 1; DWORD DisableAtlThunkEmulation :
		// 1; DWORD ReservedFlags : 30; }; }; BOOLEAN Permanent;} PROCESS_MITIGATION_DEP_POLICY, *PPROCESS_MITIGATION_DEP_POLICY; https://msdn.microsoft.com/en-us/library/windows/desktop/hh769087(v=vs.85).aspx
		[PInvokeData("WinNT.h", MSDNShortId = "hh769087")]
		[StructLayout(LayoutKind.Sequential, Pack = 4)]
		public struct PROCESS_MITIGATION_DEP_POLICY
		{
			/// <summary>The flags</summary>
			public PROCESS_MITIGATION_DEP_POLICY_FLAGS Flags;

			/// <summary>DEP is permanently enabled and cannot be disabled if this field is set to TRUE.</summary>
			[MarshalAs(UnmanagedType.U1)]
			public bool Permanent;
		}

		/// <summary>Contains process mitigation policy settings for restricting dynamic code generation and modification.</summary>
		// typedef struct _PROCESS_MITIGATION_DYNAMIC_CODE_POLICY { union { DWORD Flags; struct { DWORD ProhibitDynamicCode :1; DWORD
		// AllowThreadOptOut :1; DWORD AllowRemoteDowngrade :1; DWORD ReservedFlags :30; }; };} PROCESS_MITIGATION_DYNAMIC_CODE_POLICY,
		// *PPROCESS_MITIGATION_DYNAMIC_CODE_POLICY; https://msdn.microsoft.com/en-us/library/windows/desktop/mt706243(v=vs.85).aspx
		[PInvokeData("WinNT.h", MSDNShortId = "mt706243")]
		[StructLayout(LayoutKind.Sequential)]
		public struct PROCESS_MITIGATION_DYNAMIC_CODE_POLICY
		{
			/// <summary>The flags</summary>
			public PROCESS_MITIGATION_DYNAMIC_CODE_POLICY_FLAGS Flags;
		}

		/// <summary>
		/// Contains process mitigation policy settings for legacy extension point DLLs. The <c>GetProcessMitigationPolicy</c> and
		/// <c>SetProcessMitigationPolicy</c> functions use this structure.
		/// </summary>
		// typedef struct _PROCESS_MITIGATION_EXTENSION_POINT_DISABLE_POLICY { union { DWORD Flags; struct { DWORD DisableExtensionPoints :
		// 1; DWORD ReservedFlags : 31; }; };} PROCESS_MITIGATION_EXTENSION_POINT_DISABLE_POLICY,
		// *PPROCESS_MITIGATION_EXTENSION_POINT_DISABLE_POLICY; https://msdn.microsoft.com/en-us/library/windows/desktop/jj200586(v=vs.85).aspx
		[PInvokeData("Winnt.h", MSDNShortId = "jj200586")]
		[StructLayout(LayoutKind.Sequential)]
		public struct PROCESS_MITIGATION_EXTENSION_POINT_DISABLE_POLICY
		{
			/// <summary>The flags</summary>
			public PROCESS_MITIGATION_EXTENSION_POINT_DISABLE_POLICY_FLAGS Flags;
		}

		/// <summary>Contains process mitigation policy settings for the loading of non-system fonts.</summary>
		// typedef struct _PROCESS_MITIGATION_FONT_DISABLE_POLICY { union { DWORD Flags; struct { DWORD DisableNonSystemFonts :1; DWORD
		// AuditNonSystemFontLoading :1; DWORD ReservedFlags :30; }; };} PROCESS_MITIGATION_FONT_DISABLE_POLICY,
		// *PPROCESS_MITIGATION_FONT_DISABLE_POLICY; https://msdn.microsoft.com/en-us/library/windows/desktop/mt706244(v=vs.85).aspx
		[PInvokeData("WinNT.h", MSDNShortId = "mt706244")]
		[StructLayout(LayoutKind.Sequential)]
		public struct PROCESS_MITIGATION_FONT_DISABLE_POLICY
		{
			/// <summary>The flags</summary>
			public PROCESS_MITIGATION_FONT_DISABLE_POLICY_FLAGS Flags;
		}

		/// <summary>Contains process mitigation policy settings for the loading of images from a remote device.</summary>
		// typedef struct _PROCESS_MITIGATION_IMAGE_LOAD_POLICY { union { DWORD Flags; struct { DWORD NoRemoteImages :1; DWORD
		// NoLowMandatoryLabelImages :1; DWORD PreferSystem32Images :1; DWORD ReservedFlags :29; }; };} PROCESS_MITIGATION_IMAGE_LOAD_POLICY,
		// *PPROCESS_MITIGATION_IMAGE_LOAD_POLICY; https://msdn.microsoft.com/en-us/library/windows/desktop/mt706245(v=vs.85).aspx
		[PInvokeData("WinNT.h", MSDNShortId = "mt706245")]
		[StructLayout(LayoutKind.Sequential)]
		public struct PROCESS_MITIGATION_IMAGE_LOAD_POLICY
		{
			/// <summary>The flags</summary>
			public PROCESS_MITIGATION_IMAGE_LOAD_POLICY_FLAGS Flags;
		}

		/// <summary>Stores information about process mitigation policy.</summary>
		// https://docs.microsoft.com/en-us/windows-hardware/drivers/ddi/content/ntddk/ns-ntddk-_process_mitigation_payload_restriction_policy
		[PInvokeData("WinNT.h", MSDNShortId = "")]
		[StructLayout(LayoutKind.Sequential)]
		public struct PROCESS_MITIGATION_PAYLOAD_RESTRICTION_POLICY
		{
			/// <summary>The flags</summary>
			public PROCESS_MITIGATION_PAYLOAD_RESTRICTION_POLICY_FLAGS Flags;
		}

		/// <summary>Used to impose new behavior on handle references that are not valid.</summary>
		// typedef struct _PROCESS_MITIGATION_STRICT_HANDLE_CHECK_POLICY { union { DWORD Flags; struct { DWORD
		// RaiseExceptionOnInvalidHandleReference : 1; DWORD HandleExceptionsPermanentlyEnabled : 1; DWORD ReservedFlags : 30; }; };} PROCESS_MITIGATION_STRICT_HANDLE_CHECK_POLICY,
		// *PPROCESS_MITIGATION_STRICT_HANDLE_CHECK_POLICY; https://msdn.microsoft.com/en-us/library/windows/desktop/hh871471(v=vs.85).aspx
		[PInvokeData("WinNT.h", MSDNShortId = "hh871471")]
		[StructLayout(LayoutKind.Sequential)]
		public struct PROCESS_MITIGATION_STRICT_HANDLE_CHECK_POLICY
		{
			/// <summary>The flags</summary>
			public PROCESS_MITIGATION_STRICT_HANDLE_CHECK_POLICY_FLAGS Flags;
		}

		/// <summary>Used to impose restrictions on what system calls can be invoked by a process.</summary>
		// typedef struct _PROCESS_MITIGATION_SYSTEM_CALL_DISABLE_POLICY { union { DWORD Flags; struct { DWORD DisallowWin32kSystemCalls : 1;
		// DWORD ReservedFlags : 31; }; };} PROCESS_MITIGATION_SYSTEM_CALL_DISABLE_POLICY, *PPROCESS_MITIGATION_SYSTEM_CALL_DISABLE_POLICY; https://msdn.microsoft.com/en-us/library/windows/desktop/hh871472(v=vs.85).aspx
		[PInvokeData("WinNT.h", MSDNShortId = "hh871472")]
		[StructLayout(LayoutKind.Sequential)]
		public struct PROCESS_MITIGATION_SYSTEM_CALL_DISABLE_POLICY
		{
			/// <summary>The flags</summary>
			public PROCESS_MITIGATION_SYSTEM_CALL_DISABLE_POLICY_FLAGS Flags;
		}

		/// <summary>This structure is not supported.</summary>
		// https://msdn.microsoft.com/en-us/library/windows/hardware/mt843942(v=vs.85).aspx
		[PInvokeData("WinNT.h", MSDNShortId = "mt843942")]
		[StructLayout(LayoutKind.Sequential)]
		public struct PROCESS_MITIGATION_SYSTEM_CALL_FILTER_POLICY
		{
			/// <summary>Undocumented.</summary>
			public uint FilterId; // Only lowest 4 bits
		}

		/// <summary>
		/// Specifies the throttling policies and how to apply them to a target process when that process is subject to power management.
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/processthreadsapi/ns-processthreadsapi-process_power_throttling_state typedef
		// struct _PROCESS_POWER_THROTTLING_STATE { ULONG Version; ULONG ControlMask; ULONG StateMask; } PROCESS_POWER_THROTTLING_STATE, *PPROCESS_POWER_THROTTLING_STATE;
		[PInvokeData("processthreadsapi.h", MSDNShortId = "394B6509-849C-4B4C-9A46-AF5011A03585")]
		[StructLayout(LayoutKind.Sequential)]
		public struct PROCESS_POWER_THROTTLING_STATE
		{
			public const uint PROCESS_POWER_THROTTLING_CURRENT_VERSION = 1;

			/// <summary>
			/// <para>The version of the <c>PROCESS_POWER_THROTTLING_STATE</c> structure.</para>
			/// <para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>PROCESS_POWER_THROTTLING_CURRENT_VERSION</term>
			/// <term>The current version.</term>
			/// </item>
			/// </list>
			/// </para>
			/// </summary>
			public uint Version;

			/// <summary>
			/// <para>This field enables the caller to take control of the power throttling mechanism.</para>
			/// <para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>PROCESS_POWER_THROTTLING_EXECUTION_SPEED</term>
			/// <term>Manages the execution speed of the process.</term>
			/// </item>
			/// </list>
			/// </para>
			/// </summary>
			public PROCESS_POWER_THROTTLING_MASK ControlMask;

			/// <summary>
			/// <para>Manages the power throttling mechanism on/off state.</para>
			/// <para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>PROCESS_POWER_THROTTLING_EXECUTION_SPEED</term>
			/// <term>Manages the execution speed of the process.</term>
			/// </item>
			/// </list>
			/// </para>
			/// </summary>
			public PROCESS_POWER_THROTTLING_MASK StateMask;

			/// <summary>Initializes a new instance of the <see cref="PROCESS_POWER_THROTTLING_STATE"/> struct.</summary>
			/// <param name="controlMask">The control mask.</param>
			/// <param name="stateMask">The state mask.</param>
			public PROCESS_POWER_THROTTLING_STATE(PROCESS_POWER_THROTTLING_MASK controlMask, PROCESS_POWER_THROTTLING_MASK stateMask)
			{
				Version = PROCESS_POWER_THROTTLING_CURRENT_VERSION;
				ControlMask = controlMask;
				StateMask = stateMask;
			}
		}

		/// <summary>Specifies whether Protected Process Light (PPL) is enabled.</summary>
		// typedef struct _PROCESS_PROTECTION_LEVEL_INFORMATION { DWORD ProtectionLevel;} PROCESS_PROTECTION_LEVEL_INFORMATION,
		// *PPROCESS_PROTECTION_LEVEL_INFORMATION;// https://msdn.microsoft.com/en-us/library/windows/desktop/mt823702(v=vs.85).aspx
		[PInvokeData("Processthreadsapi.h", MSDNShortId = "mt823702")]
		[StructLayout(LayoutKind.Sequential)]
		public struct PROCESS_PROTECTION_LEVEL_INFORMATION
		{
			/// <summary>
			/// <para>The one of the following values.</para>
			/// <para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>PROTECTION_LEVEL_WINTCB_LIGHT</term>
			/// <term>For internal use only.</term>
			/// </item>
			/// <item>
			/// <term>PROTECTION_LEVEL_WINDOWS</term>
			/// <term>For internal use only.</term>
			/// </item>
			/// <item>
			/// <term>PROTECTION_LEVEL_WINDOWS_LIGHT</term>
			/// <term>For internal use only.</term>
			/// </item>
			/// <item>
			/// <term>PROTECTION_LEVEL_ANTIMALWARE_LIGHT</term>
			/// <term>For internal use only.</term>
			/// </item>
			/// <item>
			/// <term>PROTECTION_LEVEL_LSA_LIGHT</term>
			/// <term>For internal use only.</term>
			/// </item>
			/// <item>
			/// <term>PROTECTION_LEVEL_WINTCB</term>
			/// <term>Not implemented.</term>
			/// </item>
			/// <item>
			/// <term>PROTECTION_LEVEL_CODEGEN_LIGHT</term>
			/// <term>Not implemented.</term>
			/// </item>
			/// <item>
			/// <term>PROTECTION_LEVEL_AUTHENTICODE</term>
			/// <term>Not implemented.</term>
			/// </item>
			/// <item>
			/// <term>PROTECTION_LEVEL_PPL_APP</term>
			/// <term>The process is a third party app that is using process protection.</term>
			/// </item>
			/// <item>
			/// <term>PROTECTION_LEVEL_NONE</term>
			/// <term>The process is not protected.</term>
			/// </item>
			/// </list>
			/// </para>
			/// </summary>
			public PROTECTION_LEVEL ProtectionLevel;
		}

		/// <summary>Represents a logical processor in a processor group.</summary>
		[PInvokeData("WinNT.h", MSDNShortId = "dd405505")]
		[StructLayout(LayoutKind.Sequential, Pack = 1)]
		public struct PROCESSOR_NUMBER
		{
			/// <summary>The processor group to which the logical processor is assigned.</summary>
			public ushort Group;

			/// <summary>The number of the logical processor relative to the group.</summary>
			public byte Number;

			/// <summary>This parameter is reserved.</summary>
			public byte Reserved;

			/// <summary>Initializes a new instance of the <see cref="PROCESSOR_NUMBER"/> struct.</summary>
			/// <param name="processorGroup">The processor group to which the logical processor is assigned.</param>
			/// <param name="logicalProcessor">The number of the logical processor relative to the group.</param>
			public PROCESSOR_NUMBER(ushort processorGroup, byte logicalProcessor)
			{
				Group = processorGroup;
				Number = logicalProcessor;
				Reserved = 0;
			}
		}

		/// <summary>
		/// Specifies the window station, desktop, standard handles, and appearance of the main window for a process at creation time.
		/// </summary>
		/// <remarks>
		/// <para>
		/// For graphical user interface (GUI) processes, this information affects the first window created by the CreateWindow function and
		/// shown by the ShowWindow function. For console processes, this information affects the console window if a new console is created
		/// for the process. A process can use the GetStartupInfo function to retrieve the <c>STARTUPINFO</c> structure specified when the
		/// process was created.
		/// </para>
		/// <para>
		/// If a GUI process is being started and neither STARTF_FORCEONFEEDBACK or STARTF_FORCEOFFFEEDBACK is specified, the process
		/// feedback cursor is used. A GUI process is one whose subsystem is specified as "windows."
		/// </para>
		/// <para>
		/// If a process is launched from the taskbar or jump list, the system sets <c>hStdOutput</c> to a handle to the monitor that
		/// contains the taskbar or jump list used to launch the process. To retrieve this handle, use GetStartupInfo to retrieve the
		/// <c>STARTUPINFO</c> structure and check that <c>hStdOutput</c> is set. If so, use GetMonitorInfo to check whether
		/// <c>hStdOutput</c> is a valid monitor handle (HMONITOR). The process can then use the handle to position its windows.
		/// </para>
		/// <para>
		/// If the <c>STARTF_UNTRUSTEDSOURCE</c> flag is set in the in the <c>STARTUPINFO</c> structure returned by the GetStartupInfo
		/// function, then applications should be aware that the command line is untrusted. If this flag is set, applications should disable
		/// potentially dangerous features such as macros, downloaded content, and automatic printing. This flag is optional. Applications
		/// that call CreateProcess are encouraged to set this flag when launching a program with a untrusted command line so that the
		/// created process can apply appropriate policy.
		/// </para>
		/// <para>
		/// The <c>STARTF_UNTRUSTEDSOURCE</c> flag is supported starting in Windows Vista, but it is not defined in the SDK header files
		/// prior to the Windows 10 SDK. To use the flag in versions prior to Windows 10, you can define it manually in your program.
		/// </para>
		/// <para>Examples</para>
		/// <para>For an example, see Creating Processes.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/processthreadsapi/ns-processthreadsapi-_startupinfoa typedef struct
		// _STARTUPINFOA { DWORD cb; LPSTR lpReserved; LPSTR lpDesktop; LPSTR lpTitle; DWORD dwX; DWORD dwY; DWORD dwXSize; DWORD dwYSize;
		// DWORD dwXCountChars; DWORD dwYCountChars; DWORD dwFillAttribute; DWORD dwFlags; WORD wShowWindow; WORD cbReserved2; LPBYTE
		// lpReserved2; HANDLE hStdInput; HANDLE hStdOutput; HANDLE hStdError; } STARTUPINFOA, *LPSTARTUPINFOA;
		[PInvokeData("processthreadsapi.h", MSDNShortId = "cf4b795c-52c1-4573-8328-99ee13f68bb3")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
		public struct STARTUPINFO
		{
			/// <summary>The size of the structure, in bytes.</summary>
			public uint cb;

			/// <summary>Reserved; must be NULL.</summary>
			public IntPtr lpReserved;

			/// <summary>
			/// The name of the desktop, or the name of both the desktop and window station for this process. A backslash in the string
			/// indicates that the string includes both the desktop and window station names.
			/// <para>
			/// For more information, see <a href="https://msdn.microsoft.com/45016619-ed11-4b0c-84e3-f8662553c64d">Thread Connection to a Desktop</a>.
			/// </para>
			/// </summary>
			[MarshalAs(UnmanagedType.LPTStr)]
			public string lpDesktop;

			/// <summary>
			/// For console processes, this is the title displayed in the title bar if a new console window is created. If NULL, the name of
			/// the executable file is used as the window title instead. This parameter must be NULL for GUI or console processes that do not
			/// create a new console window.
			/// </summary>
			[MarshalAs(UnmanagedType.LPTStr)]
			public string lpTitle;

			/// <summary>
			/// <para>
			/// If <c>dwFlags</c> specifies STARTF_USEPOSITION, this member is the x offset of the upper left corner of a window if a new
			/// window is created, in pixels. Otherwise, this member is ignored.
			/// </para>
			/// <para>
			/// The offset is from the upper left corner of the screen. For GUI processes, the specified position is used the first time the
			/// new process calls CreateWindow to create an overlapped window if the x parameter of <c>CreateWindow</c> is CW_USEDEFAULT.
			/// </para>
			/// </summary>
			public uint dwX;

			/// <summary>
			/// <para>
			/// If <c>dwFlags</c> specifies STARTF_USEPOSITION, this member is the y offset of the upper left corner of a window if a new
			/// window is created, in pixels. Otherwise, this member is ignored.
			/// </para>
			/// <para>
			/// The offset is from the upper left corner of the screen. For GUI processes, the specified position is used the first time the
			/// new process calls CreateWindow to create an overlapped window if the y parameter of <c>CreateWindow</c> is CW_USEDEFAULT.
			/// </para>
			/// </summary>
			public uint dwY;

			/// <summary>
			/// <para>
			/// If <c>dwFlags</c> specifies STARTF_USESIZE, this member is the width of the window if a new window is created, in pixels.
			/// Otherwise, this member is ignored.
			/// </para>
			/// <para>
			/// For GUI processes, this is used only the first time the new process calls CreateWindow to create an overlapped window if the
			/// nWidth parameter of <c>CreateWindow</c> is CW_USEDEFAULT.
			/// </para>
			/// </summary>
			public uint dwXSize;

			/// <summary>
			/// <para>
			/// If <c>dwFlags</c> specifies STARTF_USESIZE, this member is the height of the window if a new window is created, in pixels.
			/// Otherwise, this member is ignored.
			/// </para>
			/// <para>
			/// For GUI processes, this is used only the first time the new process calls CreateWindow to create an overlapped window if the
			/// nHeight parameter of <c>CreateWindow</c> is CW_USEDEFAULT.
			/// </para>
			/// </summary>
			public uint dwYSize;

			/// <summary>
			/// If <c>dwFlags</c> specifies STARTF_USECOUNTCHARS, if a new console window is created in a console process, this member
			/// specifies the screen buffer width, in character columns. Otherwise, this member is ignored.
			/// </summary>
			public uint dwXCountChars;

			/// <summary>
			/// If <c>dwFlags</c> specifies STARTF_USECOUNTCHARS, if a new console window is created in a console process, this member
			/// specifies the screen buffer height, in character rows. Otherwise, this member is ignored.
			/// </summary>
			public uint dwYCountChars;

			/// <summary>
			/// <para>
			/// If <c>dwFlags</c> specifies STARTF_USEFILLATTRIBUTE, this member is the initial text and background colors if a new console
			/// window is created in a console application. Otherwise, this member is ignored.
			/// </para>
			/// <para>
			/// This value can be any combination of the following values: FOREGROUND_BLUE, FOREGROUND_GREEN, FOREGROUND_RED,
			/// FOREGROUND_INTENSITY, BACKGROUND_BLUE, BACKGROUND_GREEN, BACKGROUND_RED, and BACKGROUND_INTENSITY. For example, the following
			/// combination of values produces red text on a white background:
			/// </para>
			/// <para><c>FOREGROUND_RED | BACKGROUND_RED | BACKGROUND_GREEN | BACKGROUND_BLUE</c></para>
			/// </summary>
			public uint dwFillAttribute; // CHARACTER_ATTRIBUTE

			/// <summary>
			/// <para>
			/// A bitfield that determines whether certain <c>STARTUPINFO</c> members are used when the process creates a window. This member
			/// can be one or more of the following values.
			/// </para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>STARTF_FORCEONFEEDBACK 0x00000040</term>
			/// <term>
			/// Indicates that the cursor is in feedback mode for two seconds after CreateProcess is called. The Working in Background cursor
			/// is displayed (see the Pointers tab in the Mouse control panel utility). If during those two seconds the process makes the
			/// first GUI call, the system gives five more seconds to the process. If during those five seconds the process shows a window,
			/// the system gives five more seconds to the process to finish drawing the window. The system turns the feedback cursor off
			/// after the first call to GetMessage, regardless of whether the process is drawing.
			/// </term>
			/// </item>
			/// <item>
			/// <term>STARTF_FORCEOFFFEEDBACK 0x00000080</term>
			/// <term>Indicates that the feedback cursor is forced off while the process is starting. The Normal Select cursor is displayed.</term>
			/// </item>
			/// <item>
			/// <term>STARTF_PREVENTPINNING 0x00002000</term>
			/// <term>
			/// Indicates that any windows created by the process cannot be pinned on the taskbar. This flag must be combined with STARTF_TITLEISAPPID.
			/// </term>
			/// </item>
			/// <item>
			/// <term>STARTF_RUNFULLSCREEN 0x00000020</term>
			/// <term>
			/// Indicates that the process should be run in full-screen mode, rather than in windowed mode. This flag is only valid for
			/// console applications running on an x86 computer.
			/// </term>
			/// </item>
			/// <item>
			/// <term>STARTF_TITLEISAPPID 0x00001000</term>
			/// <term>
			/// The lpTitle member contains an AppUserModelID. This identifier controls how the taskbar and Start menu present the
			/// application, and enables it to be associated with the correct shortcuts and Jump Lists. Generally, applications will use the
			/// SetCurrentProcessExplicitAppUserModelID and GetCurrentProcessExplicitAppUserModelID functions instead of setting this flag.
			/// For more information, see Application User Model IDs. If STARTF_PREVENTPINNING is used, application windows cannot be pinned
			/// on the taskbar. The use of any AppUserModelID-related window properties by the application overrides this setting for that
			/// window only. This flag cannot be used with STARTF_TITLEISLINKNAME.
			/// </term>
			/// </item>
			/// <item>
			/// <term>STARTF_TITLEISLINKNAME 0x00000800</term>
			/// <term>
			/// The lpTitle member contains the path of the shortcut file (.lnk) that the user invoked to start this process. This is
			/// typically set by the shell when a .lnk file pointing to the launched application is invoked. Most applications will not need
			/// to set this value. This flag cannot be used with STARTF_TITLEISAPPID.
			/// </term>
			/// </item>
			/// <item>
			/// <term>STARTF_UNTRUSTEDSOURCE 0x00008000</term>
			/// <term>The command line came from an untrusted source. For more information, see Remarks.</term>
			/// </item>
			/// <item>
			/// <term/>
			/// <term/>
			/// </item>
			/// <item>
			/// <term>STARTF_USECOUNTCHARS 0x00000008</term>
			/// <term>The dwXCountChars and dwYCountChars members contain additional information.</term>
			/// </item>
			/// <item>
			/// <term>STARTF_USEFILLATTRIBUTE 0x00000010</term>
			/// <term>The dwFillAttribute member contains additional information.</term>
			/// </item>
			/// <item>
			/// <term>STARTF_USEHOTKEY 0x00000200</term>
			/// <term>The hStdInput member contains additional information. This flag cannot be used with STARTF_USESTDHANDLES.</term>
			/// </item>
			/// <item>
			/// <term>STARTF_USEPOSITION 0x00000004</term>
			/// <term>The dwX and dwY members contain additional information.</term>
			/// </item>
			/// <item>
			/// <term>STARTF_USESHOWWINDOW 0x00000001</term>
			/// <term>The wShowWindow member contains additional information.</term>
			/// </item>
			/// <item>
			/// <term>STARTF_USESIZE 0x00000002</term>
			/// <term>The dwXSize and dwYSize members contain additional information.</term>
			/// </item>
			/// <item>
			/// <term>STARTF_USESTDHANDLES 0x00000100</term>
			/// <term>
			/// The hStdInput, hStdOutput, and hStdError members contain additional information. If this flag is specified when calling one
			/// of the process creation functions, the handles must be inheritable and the function's bInheritHandles parameter must be set
			/// to TRUE. For more information, see Handle Inheritance. If this flag is specified when calling the GetStartupInfo function,
			/// these members are either the handle value specified during process creation or INVALID_HANDLE_VALUE. Handles must be closed
			/// with CloseHandle when they are no longer needed. This flag cannot be used with STARTF_USEHOTKEY.
			/// </term>
			/// </item>
			/// </list>
			/// </summary>
			public STARTF dwFlags;

			/// <summary>
			/// <para>
			/// If <c>dwFlags</c> specifies STARTF_USESHOWWINDOW, this member can be any of the values that can be specified in the nCmdShow
			/// parameter for the ShowWindow function, except for SW_SHOWDEFAULT. Otherwise, this member is ignored.
			/// </para>
			/// <para>
			/// For GUI processes, the first time ShowWindow is called, its nCmdShow parameter is ignored <c>wShowWindow</c> specifies the
			/// default value. In subsequent calls to ShowWindow, the <c>wShowWindow</c> member is used if the nCmdShow parameter of
			/// <c>ShowWindow</c> is set to SW_SHOWDEFAULT.
			/// </para>
			/// </summary>
			public ushort wShowWindow;

			/// <summary>Reserved for use by the C Run-time; must be zero.</summary>
			public ushort cbReserved2;

			/// <summary>Reserved for use by the C Run-time; must be NULL.</summary>
			public IntPtr lpReserved2;

			/// <summary>
			/// <para>
			/// If <c>dwFlags</c> specifies STARTF_USESTDHANDLES, this member is the standard input handle for the process. If
			/// STARTF_USESTDHANDLES is not specified, the default for standard input is the keyboard buffer.
			/// </para>
			/// <para>
			/// If <c>dwFlags</c> specifies STARTF_USEHOTKEY, this member specifies a hotkey value that is sent as the wParam parameter of a
			/// WM_SETHOTKEY message to the first eligible top-level window created by the application that owns the process. If the window
			/// is created with the WS_POPUP window style, it is not eligible unless the WS_EX_APPWINDOW extended window style is also set.
			/// For more information, see CreateWindowEx.
			/// </para>
			/// <para>Otherwise, this member is ignored.</para>
			/// </summary>
			public HANDLE hStdInput;

			/// <summary>
			/// <para>
			/// If <c>dwFlags</c> specifies STARTF_USESTDHANDLES, this member is the standard output handle for the process. Otherwise, this
			/// member is ignored and the default for standard output is the console window's buffer.
			/// </para>
			/// <para>
			/// If a process is launched from the taskbar or jump list, the system sets <c>hStdOutput</c> to a handle to the monitor that
			/// contains the taskbar or jump list used to launch the process. For more information, see Remarks. <c>Windows 7, Windows Server
			/// 2008 R2, Windows Vista, Windows Server 2008, Windows XP and Windows Server 2003:</c> This behavior was introduced in Windows
			/// 8 and Windows Server 2012.
			/// </para>
			/// </summary>
			public HANDLE hStdOutput;

			/// <summary>
			/// If <c>dwFlags</c> specifies STARTF_USESTDHANDLES, this member is the standard error handle for the process. Otherwise, this
			/// member is ignored and the default for standard error is the console window's buffer.
			/// </summary>
			public HANDLE hStdError;

			/// <summary>
			/// <para>
			/// If <c>dwFlags</c> specifies STARTF_USEFILLATTRIBUTE, this member is the initial text and background colors if a new console
			/// window is created in a console application. Otherwise, this member is ignored.
			/// </para>
			/// <para>
			/// This value can be any combination of the following values: FOREGROUND_BLUE, FOREGROUND_GREEN, FOREGROUND_RED,
			/// FOREGROUND_INTENSITY, BACKGROUND_BLUE, BACKGROUND_GREEN, BACKGROUND_RED, and BACKGROUND_INTENSITY. For example, the following
			/// combination of values produces red text on a white background:
			/// </para>
			/// <para><c>FOREGROUND_RED | BACKGROUND_RED | BACKGROUND_GREEN | BACKGROUND_BLUE</c></para>
			/// </summary>
			public CHARACTER_ATTRIBUTE FillAttribute { get => (CHARACTER_ATTRIBUTE)dwFillAttribute; set { dwFillAttribute = (uint)value; dwFlags = dwFlags.SetFlags(STARTF.STARTF_USEFILLATTRIBUTE, value != 0); } }

			/// <summary>
			/// <para>
			/// This member can be any of the values that can be specified in the nCmdShow parameter for the <c>ShowWindow</c> function,
			/// except for SW_SHOWDEFAULT.
			/// </para>
			/// <para>
			/// For GUI processes, the first time <c>ShowWindow</c> is called, its nCmdShow parameter is ignored <c>wShowWindow</c> specifies
			/// the default value. In subsequent calls to <c>ShowWindow</c>, the <c>wShowWindow</c> member is used if the nCmdShow parameter
			/// of <c>ShowWindow</c> is set to SW_SHOWDEFAULT.
			/// </para>
			/// </summary>
			public ShowWindowCommand ShowWindowCommand { get => (ShowWindowCommand)wShowWindow; set { wShowWindow = (ushort)value; dwFlags = dwFlags.SetFlags(STARTF.STARTF_USESHOWWINDOW, value != 0); } }

			/// <summary>
			/// <para>The x and y offset of the upper left corner of a window if a new window is created, in pixels.</para>
			/// <para>
			/// The offset is from the upper left corner of the screen. For GUI processes, the specified position is used the first time the
			/// new process calls <c>CreateWindow</c> to create an overlapped window if the x or y parameter of <c>CreateWindow</c> is CW_USEDEFAULT.
			/// </para>
			/// </summary>
			public System.Drawing.Point WindowPosition { get => new System.Drawing.Point((int)dwX, (int)dwY); set { dwX = (uint)value.X; dwY = (uint)value.Y; dwFlags = dwFlags.SetFlags(STARTF.STARTF_USEPOSITION, value != System.Drawing.Point.Empty); } }

			/// <summary>
			/// <para>The height of the window if a new window is created, in pixels.</para>
			/// <para>
			/// For GUI processes, this is used only the first time the new process calls <c>CreateWindow</c> to create an overlapped window
			/// if the nHeight or nWidth parameter of <c>CreateWindow</c> is CW_USEDEFAULT.
			/// </para>
			/// </summary>
			public SIZE WindowSize { get => new SIZE((int)dwXSize, (int)dwYSize); set { dwXSize = (uint)value.cx; dwYSize = (uint)value.cy; dwFlags = dwFlags.SetFlags(STARTF.STARTF_USESIZE, value != SIZE.Empty); } }

			/// <summary>Gets the default value for this structure with the <c>cb</c> field set to the size of the structure.</summary>
			public static STARTUPINFO Default => new STARTUPINFO { cb = (uint)Marshal.SizeOf(typeof(STARTUPINFO)) };
		}

		/// <summary>
		/// <para>
		/// Specifies the window station, desktop, standard handles, and attributes for a new process. It is used with the CreateProcess and
		/// CreateProcessAsUser functions.
		/// </para>
		/// </summary>
		/// <remarks>
		/// <para>Be sure to set the <c>cb</c> member of the STARTUPINFO structure to .</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winbase/ns-winbase-_startupinfoexa typedef struct _STARTUPINFOEXA {
		// STARTUPINFOA StartupInfo; LPPROC_THREAD_ATTRIBUTE_LIST lpAttributeList; } STARTUPINFOEXA, *LPSTARTUPINFOEXA;
		[PInvokeData("winbase.h", MSDNShortId = "61203f57-292d-4ea1-88f4-a3b05012d7a3")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
		public struct STARTUPINFOEX
		{
			/// <summary>
			/// <para>A STARTUPINFO structure.</para>
			/// </summary>
			public STARTUPINFO StartupInfo;

			/// <summary>
			/// <para>An attribute list. This list is created by the InitializeProcThreadAttributeList function.</para>
			/// </summary>
			public IntPtr lpAttributeList;

			/// <summary>Gets the default value for this structure with the <c>cb</c> field set to the size of the structure.</summary>
			public static STARTUPINFOEX Default => new STARTUPINFOEX { StartupInfo = new STARTUPINFO { cb = (uint)Marshal.SizeOf(typeof(STARTUPINFOEX)) } };
		}

		/// <summary>
		/// <para>
		/// This structure is returned by <c>GetSystemCpuSetInformation</c>. It is used to enumerate the CPU Sets on the system and determine
		/// their current state.
		/// </para>
		/// <para>
		/// This is a variable-sized structure designed for future expansion. When iterating over this structure, use the size field to
		/// determine the offset to the next structure.
		/// </para>
		/// </summary>
		// typedef struct _SYSTEM_CPU_SET_INFORMATION { DWORD Size; CPU_SET_INFORMATION_TYPE Type; union { struct { DWORD Id; WORD Group;
		// BYTE LogicalProcessorIndex; BYTE CoreIndex; BYTE LastLevelCacheIndex; BYTE NumaNodeIndex; BYTE EfficiencyClass; struct { BOOLEAN
		// Parked : 1; BOOLEAN Allocated : 1; BOOLEAN AllocatedToTargetProcess : 1; BOOLEAN RealTime : 1; BYTE ReservedFlags : 4; }; DWORD
		// Reserved; DWORD64 AllocationTag; } CpuSet; };} SYSTEM_CPU_SET_INFORMATION, *PSYSTEM_CPU_SET_INFORMATION;// https://msdn.microsoft.com/en-us/library/windows/desktop/mt186429(v=vs.85).aspx
		[PInvokeData("Winnt.h", MSDNShortId = "mt186429")]
		[StructLayout(LayoutKind.Explicit)]
		public struct SYSTEM_CPU_SET_INFORMATION
		{
			/// <summary>This is the size, in bytes, of this information structure.</summary>
			[FieldOffset(0)]
			public uint Size;

			/// <summary>
			/// This is the type of information in the structure. Applications should skip any structures with unrecognized types.
			/// </summary>
			[FieldOffset(4)]
			public CPU_SET_INFORMATION_TYPE Type;

			/// <summary>Value used when Type is CpuSetInformation.</summary>
			[FieldOffset(8)]
			public CPU_SET CpuSet;

			/// <summary>Defines values used when Type is CpuSetInformation.</summary>
			[StructLayout(LayoutKind.Sequential)]
			public struct CPU_SET
			{
				/// <summary>
				/// The ID of the specified CPU Set. This identifier can be used with SetProcessDefaultCpuSets or SetThreadSelectedCpuSets
				/// when specifying a list of CPU Sets to affinitize to.
				/// </summary>
				public uint Id;

				/// <summary>
				/// Specifies the Processor Group of the CPU Set. All other values in the CpuSet structure are relative to the processor group.
				/// </summary>
				public ushort Group;

				/// <summary>
				/// Specifies the group-relative index of the home processor of the CPU Set. Unless the CPU Set is parked for thermal or
				/// power management reasons or assigned for exclusive use to another application, threads will run on the home processor of
				/// one of their CPU Sets. The Group and LogicalProcessorIndex fields are the same as the ones found in the PROCESSOR_NUMBER
				/// structure and they correspond to the Group field and Mask field of the GROUP_AFFINITY structure.
				/// </summary>
				public byte LogicalProcessorIndex;

				/// <summary>
				/// A group-relative value indicating which "Core" has the home processor of the CPU Set. This number is the same for all CPU
				/// Sets in the same group that share significant execution resources with each other, such as different hardware threads on
				/// a single core that supports simultaneous multi-threading.
				/// </summary>
				public byte CoreIndex;

				/// <summary>
				/// A group-relative value indicating which CPU Sets share at least one level of cache with each other. This value is the
				/// same for all CPU Sets in a group that are on processors that share cache with each other.
				/// </summary>
				public byte LastLevelCacheIndex;

				/// <summary>
				/// A group-relative value indicating which NUMA node a CPU Set is on. All CPU Sets in a given group that are on the same
				/// NUMA node will have the same value for this field.
				/// </summary>
				public byte NumaNodeIndex;

				/// <summary>
				/// A value indicating the intrinsic energy efficiency of a processor for systems that support heterogeneous processors (such
				/// as ARM big.LITTLE systems). CPU Sets with higher numerical values of this field have home processors that are faster but
				/// less power-efficient than ones with lower values.
				/// </summary>
				public byte EfficiencyClass;

				/// <summary>All flags</summary>
				public SYSTEM_CPU_SET_FLAGS AllFlags;

				/// <summary>Reserved</summary>
				private readonly uint Reserved;

				/// <summary>
				/// Specifies a tag used by Core Allocation to communicate a given allocated CPU Set between threads in different components.
				/// </summary>
				public ulong AllocationTag;
			}
		}

		/// <summary>
		/// Specifies the throttling policies and how to apply them to a target thread when that thread is subject to power management.
		/// </summary>
		// typedef struct _THREAD_POWER_THROTTLING_STATE { ULONG Version; ULONG ControlMask; ULONG StateMask;} THREAD_POWER_THROTTLING_STATE,
		// *PTHREAD_POWER_THROTTLING_STATE; https://msdn.microsoft.com/en-us/library/windows/desktop/mt804325(v=vs.85).aspx
		[PInvokeData("Processthreadsapi.h", MSDNShortId = "mt804325")]
		[StructLayout(LayoutKind.Sequential)]
		public struct THREAD_POWER_THROTTLING_STATE
		{
			public const uint THREAD_POWER_THROTTLING_CURRENT_VERSION = 1;
			public const uint THREAD_POWER_THROTTLING_EXECUTION_SPEED = 0x1;

			/// <summary>
			/// <para>The version of the <c>THREAD_POWER_THROTTLING_STATE</c> structure.</para>
			/// <para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>THREAD_POWER_THROTTLING_CURRENT_VERSION</term>
			/// <term>The current version.</term>
			/// </item>
			/// </list>
			/// </para>
			/// </summary>
			public uint Version;

			/// <summary>
			/// <para>This field enables the caller to take control of the power throttling mechanism.</para>
			/// <para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>THREAD_POWER_THROTTLING_EXECUTION_SPEED</term>
			/// <term>Manages the execution speed of the thread.</term>
			/// </item>
			/// </list>
			/// </para>
			/// </summary>
			public uint ControlMask;

			/// <summary>
			/// <para>Manages the power throttling mechanism on/off state.</para>
			/// <para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>THREAD_POWER_THROTTLING_EXECUTION_SPEED</term>
			/// <term>Manages the execution speed of the thread.</term>
			/// </item>
			/// </list>
			/// </para>
			/// </summary>
			public uint StateMask;

			/// <summary>Creates an initialized instance of THREAD_POWER_THROTTLING_STATE.</summary>
			public static THREAD_POWER_THROTTLING_STATE Create() => new THREAD_POWER_THROTTLING_STATE
			{ Version = THREAD_POWER_THROTTLING_CURRENT_VERSION, ControlMask = THREAD_POWER_THROTTLING_EXECUTION_SPEED };
		}

		/// <summary>
		/// Specifies the window station, desktop, standard handles, and appearance of the main window for a process at creation time.
		/// </summary>
		/// <remarks>
		/// <para>
		/// For graphical user interface (GUI) processes, this information affects the first window created by the CreateWindow function and
		/// shown by the ShowWindow function. For console processes, this information affects the console window if a new console is created
		/// for the process. A process can use the GetStartupInfo function to retrieve the <c>STARTUPINFO</c> structure specified when the
		/// process was created.
		/// </para>
		/// <para>
		/// If a GUI process is being started and neither STARTF_FORCEONFEEDBACK or STARTF_FORCEOFFFEEDBACK is specified, the process
		/// feedback cursor is used. A GUI process is one whose subsystem is specified as "windows."
		/// </para>
		/// <para>
		/// If a process is launched from the taskbar or jump list, the system sets <c>hStdOutput</c> to a handle to the monitor that
		/// contains the taskbar or jump list used to launch the process. To retrieve this handle, use GetStartupInfo to retrieve the
		/// <c>STARTUPINFO</c> structure and check that <c>hStdOutput</c> is set. If so, use GetMonitorInfo to check whether
		/// <c>hStdOutput</c> is a valid monitor handle (HMONITOR). The process can then use the handle to position its windows.
		/// </para>
		/// <para>
		/// If the <c>STARTF_UNTRUSTEDSOURCE</c> flag is set in the in the <c>STARTUPINFO</c> structure returned by the GetStartupInfo
		/// function, then applications should be aware that the command line is untrusted. If this flag is set, applications should disable
		/// potentially dangerous features such as macros, downloaded content, and automatic printing. This flag is optional. Applications
		/// that call CreateProcess are encouraged to set this flag when launching a program with a untrusted command line so that the
		/// created process can apply appropriate policy.
		/// </para>
		/// <para>
		/// The <c>STARTF_UNTRUSTEDSOURCE</c> flag is supported starting in Windows Vista, but it is not defined in the SDK header files
		/// prior to the Windows 10 SDK. To use the flag in versions prior to Windows 10, you can define it manually in your program.
		/// </para>
		/// <para>Examples</para>
		/// <para>For an example, see Creating Processes.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/processthreadsapi/ns-processthreadsapi-_startupinfoa typedef struct
		// _STARTUPINFOA { DWORD cb; LPSTR lpReserved; LPSTR lpDesktop; LPSTR lpTitle; DWORD dwX; DWORD dwY; DWORD dwXSize; DWORD dwYSize;
		// DWORD dwXCountChars; DWORD dwYCountChars; DWORD dwFillAttribute; DWORD dwFlags; WORD wShowWindow; WORD cbReserved2; LPBYTE
		// lpReserved2; HANDLE hStdInput; HANDLE hStdOutput; HANDLE hStdError; } STARTUPINFOA, *LPSTARTUPINFOA;
		[PInvokeData("processthreadsapi.h", MSDNShortId = "cf4b795c-52c1-4573-8328-99ee13f68bb3")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
		private struct STARTUPINFO_OUT
		{
			/// <summary>The size of the structure, in bytes.</summary>
			public uint cb;

			/// <summary>Reserved; must be NULL.</summary>
			public IntPtr lpReserved;

			/// <summary>
			/// The name of the desktop, or the name of both the desktop and window station for this process. A backslash in the string
			/// indicates that the string includes both the desktop and window station names.
			/// <para>
			/// For more information, see <a href="https://msdn.microsoft.com/45016619-ed11-4b0c-84e3-f8662553c64d">Thread Connection to a Desktop</a>.
			/// </para>
			/// </summary>
			//[MarshalAs(UnmanagedType.LPTStr)]
			//public string lpDesktop;
			public StrPtrAuto lpDesktop;

			/// <summary>
			/// For console processes, this is the title displayed in the title bar if a new console window is created. If NULL, the name of
			/// the executable file is used as the window title instead. This parameter must be NULL for GUI or console processes that do not
			/// create a new console window.
			/// </summary>
			//[MarshalAs(UnmanagedType.LPTStr)]
			//public string lpTitle;
			public StrPtrAuto lpTitle;

			/// <summary>
			/// <para>
			/// If <c>dwFlags</c> specifies STARTF_USEPOSITION, this member is the x offset of the upper left corner of a window if a new
			/// window is created, in pixels. Otherwise, this member is ignored.
			/// </para>
			/// <para>
			/// The offset is from the upper left corner of the screen. For GUI processes, the specified position is used the first time the
			/// new process calls CreateWindow to create an overlapped window if the x parameter of <c>CreateWindow</c> is CW_USEDEFAULT.
			/// </para>
			/// </summary>
			public uint dwX;

			/// <summary>
			/// <para>
			/// If <c>dwFlags</c> specifies STARTF_USEPOSITION, this member is the y offset of the upper left corner of a window if a new
			/// window is created, in pixels. Otherwise, this member is ignored.
			/// </para>
			/// <para>
			/// The offset is from the upper left corner of the screen. For GUI processes, the specified position is used the first time the
			/// new process calls CreateWindow to create an overlapped window if the y parameter of <c>CreateWindow</c> is CW_USEDEFAULT.
			/// </para>
			/// </summary>
			public uint dwY;

			/// <summary>
			/// <para>
			/// If <c>dwFlags</c> specifies STARTF_USESIZE, this member is the width of the window if a new window is created, in pixels.
			/// Otherwise, this member is ignored.
			/// </para>
			/// <para>
			/// For GUI processes, this is used only the first time the new process calls CreateWindow to create an overlapped window if the
			/// nWidth parameter of <c>CreateWindow</c> is CW_USEDEFAULT.
			/// </para>
			/// </summary>
			public uint dwXSize;

			/// <summary>
			/// <para>
			/// If <c>dwFlags</c> specifies STARTF_USESIZE, this member is the height of the window if a new window is created, in pixels.
			/// Otherwise, this member is ignored.
			/// </para>
			/// <para>
			/// For GUI processes, this is used only the first time the new process calls CreateWindow to create an overlapped window if the
			/// nHeight parameter of <c>CreateWindow</c> is CW_USEDEFAULT.
			/// </para>
			/// </summary>
			public uint dwYSize;

			/// <summary>
			/// If <c>dwFlags</c> specifies STARTF_USECOUNTCHARS, if a new console window is created in a console process, this member
			/// specifies the screen buffer width, in character columns. Otherwise, this member is ignored.
			/// </summary>
			public uint dwXCountChars;

			/// <summary>
			/// If <c>dwFlags</c> specifies STARTF_USECOUNTCHARS, if a new console window is created in a console process, this member
			/// specifies the screen buffer height, in character rows. Otherwise, this member is ignored.
			/// </summary>
			public uint dwYCountChars;

			/// <summary>
			/// <para>
			/// If <c>dwFlags</c> specifies STARTF_USEFILLATTRIBUTE, this member is the initial text and background colors if a new console
			/// window is created in a console application. Otherwise, this member is ignored.
			/// </para>
			/// <para>
			/// This value can be any combination of the following values: FOREGROUND_BLUE, FOREGROUND_GREEN, FOREGROUND_RED,
			/// FOREGROUND_INTENSITY, BACKGROUND_BLUE, BACKGROUND_GREEN, BACKGROUND_RED, and BACKGROUND_INTENSITY. For example, the following
			/// combination of values produces red text on a white background:
			/// </para>
			/// <para><c>FOREGROUND_RED | BACKGROUND_RED | BACKGROUND_GREEN | BACKGROUND_BLUE</c></para>
			/// </summary>
			public uint dwFillAttribute; // CHARACTER_ATTRIBUTE

			/// <summary>
			/// <para>
			/// A bitfield that determines whether certain <c>STARTUPINFO</c> members are used when the process creates a window. This member
			/// can be one or more of the following values.
			/// </para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>STARTF_FORCEONFEEDBACK 0x00000040</term>
			/// <term>
			/// Indicates that the cursor is in feedback mode for two seconds after CreateProcess is called. The Working in Background cursor
			/// is displayed (see the Pointers tab in the Mouse control panel utility). If during those two seconds the process makes the
			/// first GUI call, the system gives five more seconds to the process. If during those five seconds the process shows a window,
			/// the system gives five more seconds to the process to finish drawing the window. The system turns the feedback cursor off
			/// after the first call to GetMessage, regardless of whether the process is drawing.
			/// </term>
			/// </item>
			/// <item>
			/// <term>STARTF_FORCEOFFFEEDBACK 0x00000080</term>
			/// <term>Indicates that the feedback cursor is forced off while the process is starting. The Normal Select cursor is displayed.</term>
			/// </item>
			/// <item>
			/// <term>STARTF_PREVENTPINNING 0x00002000</term>
			/// <term>
			/// Indicates that any windows created by the process cannot be pinned on the taskbar. This flag must be combined with STARTF_TITLEISAPPID.
			/// </term>
			/// </item>
			/// <item>
			/// <term>STARTF_RUNFULLSCREEN 0x00000020</term>
			/// <term>
			/// Indicates that the process should be run in full-screen mode, rather than in windowed mode. This flag is only valid for
			/// console applications running on an x86 computer.
			/// </term>
			/// </item>
			/// <item>
			/// <term>STARTF_TITLEISAPPID 0x00001000</term>
			/// <term>
			/// The lpTitle member contains an AppUserModelID. This identifier controls how the taskbar and Start menu present the
			/// application, and enables it to be associated with the correct shortcuts and Jump Lists. Generally, applications will use the
			/// SetCurrentProcessExplicitAppUserModelID and GetCurrentProcessExplicitAppUserModelID functions instead of setting this flag.
			/// For more information, see Application User Model IDs. If STARTF_PREVENTPINNING is used, application windows cannot be pinned
			/// on the taskbar. The use of any AppUserModelID-related window properties by the application overrides this setting for that
			/// window only. This flag cannot be used with STARTF_TITLEISLINKNAME.
			/// </term>
			/// </item>
			/// <item>
			/// <term>STARTF_TITLEISLINKNAME 0x00000800</term>
			/// <term>
			/// The lpTitle member contains the path of the shortcut file (.lnk) that the user invoked to start this process. This is
			/// typically set by the shell when a .lnk file pointing to the launched application is invoked. Most applications will not need
			/// to set this value. This flag cannot be used with STARTF_TITLEISAPPID.
			/// </term>
			/// </item>
			/// <item>
			/// <term>STARTF_UNTRUSTEDSOURCE 0x00008000</term>
			/// <term>The command line came from an untrusted source. For more information, see Remarks.</term>
			/// </item>
			/// <item>
			/// <term/>
			/// <term/>
			/// </item>
			/// <item>
			/// <term>STARTF_USECOUNTCHARS 0x00000008</term>
			/// <term>The dwXCountChars and dwYCountChars members contain additional information.</term>
			/// </item>
			/// <item>
			/// <term>STARTF_USEFILLATTRIBUTE 0x00000010</term>
			/// <term>The dwFillAttribute member contains additional information.</term>
			/// </item>
			/// <item>
			/// <term>STARTF_USEHOTKEY 0x00000200</term>
			/// <term>The hStdInput member contains additional information. This flag cannot be used with STARTF_USESTDHANDLES.</term>
			/// </item>
			/// <item>
			/// <term>STARTF_USEPOSITION 0x00000004</term>
			/// <term>The dwX and dwY members contain additional information.</term>
			/// </item>
			/// <item>
			/// <term>STARTF_USESHOWWINDOW 0x00000001</term>
			/// <term>The wShowWindow member contains additional information.</term>
			/// </item>
			/// <item>
			/// <term>STARTF_USESIZE 0x00000002</term>
			/// <term>The dwXSize and dwYSize members contain additional information.</term>
			/// </item>
			/// <item>
			/// <term>STARTF_USESTDHANDLES 0x00000100</term>
			/// <term>
			/// The hStdInput, hStdOutput, and hStdError members contain additional information. If this flag is specified when calling one
			/// of the process creation functions, the handles must be inheritable and the function's bInheritHandles parameter must be set
			/// to TRUE. For more information, see Handle Inheritance. If this flag is specified when calling the GetStartupInfo function,
			/// these members are either the handle value specified during process creation or INVALID_HANDLE_VALUE. Handles must be closed
			/// with CloseHandle when they are no longer needed. This flag cannot be used with STARTF_USEHOTKEY.
			/// </term>
			/// </item>
			/// </list>
			/// </summary>
			public STARTF dwFlags;

			/// <summary>
			/// <para>
			/// If <c>dwFlags</c> specifies STARTF_USESHOWWINDOW, this member can be any of the values that can be specified in the nCmdShow
			/// parameter for the ShowWindow function, except for SW_SHOWDEFAULT. Otherwise, this member is ignored.
			/// </para>
			/// <para>
			/// For GUI processes, the first time ShowWindow is called, its nCmdShow parameter is ignored <c>wShowWindow</c> specifies the
			/// default value. In subsequent calls to ShowWindow, the <c>wShowWindow</c> member is used if the nCmdShow parameter of
			/// <c>ShowWindow</c> is set to SW_SHOWDEFAULT.
			/// </para>
			/// </summary>
			public ushort wShowWindow;

			/// <summary>Reserved for use by the C Run-time; must be zero.</summary>
			public ushort cbReserved2;

			/// <summary>Reserved for use by the C Run-time; must be NULL.</summary>
			public IntPtr lpReserved2;

			/// <summary>
			/// <para>
			/// If <c>dwFlags</c> specifies STARTF_USESTDHANDLES, this member is the standard input handle for the process. If
			/// STARTF_USESTDHANDLES is not specified, the default for standard input is the keyboard buffer.
			/// </para>
			/// <para>
			/// If <c>dwFlags</c> specifies STARTF_USEHOTKEY, this member specifies a hotkey value that is sent as the wParam parameter of a
			/// WM_SETHOTKEY message to the first eligible top-level window created by the application that owns the process. If the window
			/// is created with the WS_POPUP window style, it is not eligible unless the WS_EX_APPWINDOW extended window style is also set.
			/// For more information, see CreateWindowEx.
			/// </para>
			/// <para>Otherwise, this member is ignored.</para>
			/// </summary>
			public HANDLE hStdInput;

			/// <summary>
			/// <para>
			/// If <c>dwFlags</c> specifies STARTF_USESTDHANDLES, this member is the standard output handle for the process. Otherwise, this
			/// member is ignored and the default for standard output is the console window's buffer.
			/// </para>
			/// <para>
			/// If a process is launched from the taskbar or jump list, the system sets <c>hStdOutput</c> to a handle to the monitor that
			/// contains the taskbar or jump list used to launch the process. For more information, see Remarks. <c>Windows 7, Windows Server
			/// 2008 R2, Windows Vista, Windows Server 2008, Windows XP and Windows Server 2003:</c> This behavior was introduced in Windows
			/// 8 and Windows Server 2012.
			/// </para>
			/// </summary>
			public HANDLE hStdOutput;

			/// <summary>
			/// If <c>dwFlags</c> specifies STARTF_USESTDHANDLES, this member is the standard error handle for the process. Otherwise, this
			/// member is ignored and the default for standard error is the console window's buffer.
			/// </summary>
			public HANDLE hStdError;

			/// <summary>Performs an implicit conversion from <see cref="STARTUPINFO_OUT"/> to <see cref="STARTUPINFO"/>.</summary>
			/// <param name="sio">The STARTUPINFO_OUT instance.</param>
			/// <returns>The result of the conversion.</returns>
			public static implicit operator STARTUPINFO(STARTUPINFO_OUT sio)
			{
				return new STARTUPINFO
				{
					cb = sio.cb,
					lpReserved = sio.lpReserved,
					lpDesktop = sio.lpDesktop,
					lpTitle = sio.lpTitle,
					dwX = sio.dwX,
					dwY = sio.dwY,
					dwXSize = sio.dwXSize,
					dwYSize = sio.dwYSize,
					dwXCountChars = sio.dwXCountChars,
					dwYCountChars = sio.dwYCountChars,
					dwFillAttribute = sio.dwFillAttribute,
					dwFlags = sio.dwFlags,
					wShowWindow = sio.wShowWindow,
					cbReserved2 = sio.cbReserved2,
					lpReserved2 = sio.lpReserved2,
					hStdInput = sio.hStdInput,
					hStdOutput = sio.hStdOutput,
					hStdError = sio.hStdError,
				};
			}
		}

		/// <summary>Provides a <see cref="SafeHandle"/> to a process that releases a created HPROCESS instance at disposal using CloseHandle.</summary>
		public class SafeHPROCESS : SafeSyncHandle
		{
			/// <summary>Initializes a new instance of the <see cref="HPROCESS"/> class and assigns an existing handle.</summary>
			/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
			/// <param name="ownsHandle">
			/// <see langword="true"/> to reliably release the handle during the finalization phase; otherwise, <see langword="false"/> (not recommended).
			/// </param>
			public SafeHPROCESS(HPROCESS preexistingHandle, bool ownsHandle = true) : base((IntPtr)preexistingHandle, ownsHandle) { }

			private SafeHPROCESS() : base()
			{
			}

			/// <summary>Gets a handle to the current process that can be used across processes.</summary>
			/// <value>The current process handle.</value>
			public static SafeHPROCESS Current => new SafeHPROCESS(GetCurrentProcess().Duplicate());

			/// <summary>Represents a <see langword="null"/> or invalid process.</summary>
			public static SafeHPROCESS Null => new SafeHPROCESS();

			/// <summary>Performs an implicit conversion from <see cref="SafeHPROCESS"/> to <see cref="HPROCESS"/>.</summary>
			/// <param name="h">The safe handle instance.</param>
			/// <returns>The result of the conversion.</returns>
			public static implicit operator HPROCESS(SafeHPROCESS h) => h.handle;
		}

		/// <summary>Provides a <see cref="SafeHandle"/> to a thread that releases a created HTHREAD instance at disposal using CloseHandle.</summary>
		public class SafeHTHREAD : SafeSyncHandle
		{
			/// <summary>Initializes a new instance of the <see cref="HTHREAD"/> class and assigns an existing handle.</summary>
			/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
			/// <param name="ownsHandle">
			/// <see langword="true"/> to reliably release the handle during the finalization phase; otherwise, <see langword="false"/> (not recommended).
			/// </param>
			public SafeHTHREAD(HTHREAD preexistingHandle, bool ownsHandle = true) : base((IntPtr)preexistingHandle, ownsHandle) { }

			private SafeHTHREAD() : base()
			{
			}

			/// <summary>Gets a handle to the current thread that can be used across processes.</summary>
			/// <value>The current thread handle.</value>
			public static SafeHTHREAD Current => new SafeHTHREAD(GetCurrentThread().Duplicate());

			/// <summary>Performs an implicit conversion from <see cref="SafeHTHREAD"/> to <see cref="HTHREAD"/>.</summary>
			/// <param name="h">The safe handle instance.</param>
			/// <returns>The result of the conversion.</returns>
			public static implicit operator HTHREAD(SafeHTHREAD h) => h.handle;
		}

		/// <summary>
		/// Contains information about a newly created process and its primary thread. It is used with the <c>CreateProcess</c>,
		/// <c>CreateProcessAsUser</c>, <c>CreateProcessWithLogonW</c>, or <c>CreateProcessWithTokenW</c> function. This class will close the
		/// process and thread handles at disposal.
		/// </summary>
		// typedef struct _PROCESS_INFORMATION { HANDLE hProcess; HANDLE hThread; DWORD dwProcessId; DWORD dwThreadId;} PROCESS_INFORMATION,
		// *LPPROCESS_INFORMATION; https://msdn.microsoft.com/en-us/library/windows/desktop/ms684873(v=vs.85).aspx
		[PInvokeData("WinBase.h", MSDNShortId = "ms684873")]
		public sealed class SafePROCESS_INFORMATION : IDisposable
		{
			/// <summary>Initializes a new instance of the <see cref="SafePROCESS_INFORMATION"/> class.</summary>
			/// <param name="pi">The pi.</param>
			public SafePROCESS_INFORMATION(in PROCESS_INFORMATION pi)
			{
				hProcess = new SafeHPROCESS(pi.hProcess);
				hThread = new SafeHTHREAD(pi.hThread);
				dwProcessId = pi.dwProcessId;
				dwThreadId = pi.dwThreadId;
			}

			/// <summary>Initializes an empty instance of the <see cref="SafePROCESS_INFORMATION"/> class.</summary>
			public SafePROCESS_INFORMATION()
			{
				hProcess = new SafeHPROCESS(IntPtr.Zero);
				hThread = new SafeHTHREAD(IntPtr.Zero);
			}

			/// <summary>
			/// A value that can be used to identify a process. The value is valid from the time the process is created until all handles to
			/// the process are closed and the process object is freed; at this point, the identifier may be reused.
			/// </summary>
			public uint dwProcessId { get; }

			/// <summary>
			/// A value that can be used to identify a thread. The value is valid from the time the thread is created until all handles to
			/// the thread are closed and the thread object is freed; at this point, the identifier may be reused.
			/// </summary>
			public uint dwThreadId { get; }

			/// <summary>
			/// A handle to the newly created process. The handle is used to specify the process in all functions that perform operations on
			/// the process object.
			/// </summary>
			public SafeHPROCESS hProcess { get; private set; }

			/// <summary>
			/// A handle to the primary thread of the newly created process. The handle is used to specify the thread in all functions that
			/// perform operations on the thread object.
			/// </summary>
			public SafeHTHREAD hThread { get; private set; }

			/// <summary>Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.</summary>
			void IDisposable.Dispose()
			{
				hProcess.Dispose();
				hThread.Dispose();
			}
		}

		/// <summary>Provides a <see cref="SafeHandle"/> for <see cref="ProcThreadAttributeList"/> that is disposed using <see cref="DeleteProcThreadAttributeList"/>.</summary>
		public class SafeProcThreadAttributeList : SafeHANDLE
		{
			private List<PinnedObject> values = new List<PinnedObject>();

			/// <summary>Initializes a new instance of the <see cref="SafeProcThreadAttributeList"/> class and assigns an existing handle.</summary>
			/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
			/// <param name="ownsHandle">
			/// <see langword="true"/> to reliably release the handle during the finalization phase; otherwise, <see langword="false"/> (not recommended).
			/// </param>
			public SafeProcThreadAttributeList(IntPtr preexistingHandle, bool ownsHandle = true) : base(preexistingHandle, ownsHandle) { }

			/// <summary>Initializes a new instance of the <see cref="SafeProcThreadAttributeList"/> class.</summary>
			private SafeProcThreadAttributeList() : base() { }

			public static SafeProcThreadAttributeList Create(IDictionary<PROC_THREAD_ATTRIBUTE, object> attributes)
			{
				if (attributes is null) throw new ArgumentNullException(nameof(attributes));
				foreach (var kv in attributes)
					if (!IsValid(kv.Key, kv.Value)) throw new ArgumentException($"The attribute {kv.Key} does not support a value of type {kv.Value.GetType().Name}.");

				SizeT sz = 0;
				InitializeProcThreadAttributeList(IntPtr.Zero, (uint)attributes.Count, 0, ref sz);
				if (sz == 0) Win32Error.ThrowLastError();
				RuntimeHelpers.PrepareConstrainedRegions();
				var ptr = Marshal.AllocHGlobal(sz);
				if (!InitializeProcThreadAttributeList(ptr, (uint)attributes.Count, 0, ref sz))
				{
					Marshal.FreeHGlobal(ptr);
					Win32Error.ThrowLastError();
				}

				var hAttr = new SafeProcThreadAttributeList(ptr);
				foreach (var kv in attributes)
					hAttr.Add(kv.Key, kv.Value);
				return hAttr;
			}

			/// <inheritdoc/>
			protected override bool InternalReleaseHandle() { values.Clear(); DeleteProcThreadAttributeList(handle); Marshal.FreeHGlobal(handle); return true; }

			private static bool IsValid(PROC_THREAD_ATTRIBUTE attr, object value) => !(value is null) && value.GetType().Equals(attr.ValidType);

			private void Add(PROC_THREAD_ATTRIBUTE attr, object value)
			{
				var pVal = new PinnedObject(value);
				values.Add(pVal);
				if (!UpdateProcThreadAttribute(handle, 0, attr, pVal, Marshal.SizeOf(value)))
					Win32Error.ThrowLastError();
			}
		}
	}
}