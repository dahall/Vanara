using System;
using System.Linq;
using System.Runtime.InteropServices;
using Vanara.InteropServices;
using FILETIME = System.Runtime.InteropServices.ComTypes.FILETIME;

namespace Vanara.PInvoke
{
	/// <summary>Platform invokable enumerated types, constants and functions from ntdll.h</summary>
	public static partial class NtDll
	{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

		/// <summary></summary>
		[Flags]
		public enum PROCESS_CREATE_FLAGS : uint
		{
			/// <summary></summary>
			PROCESS_CREATE_FLAGS_BREAKAWAY = 0x00000001,
			/// <summary></summary>
			PROCESS_CREATE_FLAGS_NO_DEBUG_INHERIT = 0x00000002,
			/// <summary></summary>
			PROCESS_CREATE_FLAGS_INHERIT_HANDLES = 0x00000004,
			/// <summary></summary>
			PROCESS_CREATE_FLAGS_OVERRIDE_ADDRESS_SPACE = 0x00000008,
			/// <summary></summary>
			PROCESS_CREATE_FLAGS_LARGE_PAGES = 0x00000010,
		}

		/// <summary>The type of process information to be retrieved.</summary>
		[PInvokeData("winternl.h", MSDNShortId = "0eae7899-c40b-4a5f-9e9c-adae021885e7")]
		// Undocumented values pulled from ProcessHacker source.
		public enum PROCESSINFOCLASS
		{
			/// <summary>
			/// Retrieves a pointer to a PEB structure that can be used to determine whether the specified process is being debugged, and a
			/// unique value used by the system to identify the specified process.
			/// <para>Use the CheckRemoteDebuggerPresent and GetProcessId functions to obtain this information.</para>
			/// </summary>
			[CorrespondingType(typeof(PROCESS_BASIC_INFORMATION), CorrespondingAction.Get)]
			[CorrespondingType(typeof(PROCESS_BASIC_INFORMATION_WOW64), CorrespondingAction.Get)]
			ProcessBasicInformation = 0,

			ProcessQuotaLimits, // qs: QUOTA_LIMITS, QUOTA_LIMITS_EX
			ProcessIoCounters, // q: IO_COUNTERS
			ProcessVmCounters, // q: VM_COUNTERS, VM_COUNTERS_EX, VM_COUNTERS_EX2

			[CorrespondingType(typeof(KERNEL_USER_TIMES), CorrespondingAction.Get)]
			ProcessTimes, // q: KERNEL_USER_TIMES

			ProcessBasePriority, // s: KPRIORITY
			ProcessRaisePriority, // s: ULONG

			/// <summary>
			/// Retrieves a DWORD_PTR value that is the port number of the debugger for the process. A nonzero value indicates that the
			/// process is being run under the control of a ring 3 debugger.
			/// <para>Use the CheckRemoteDebuggerPresent or IsDebuggerPresent function.</para>
			/// </summary>
			[CorrespondingType(typeof(IntPtr), CorrespondingAction.Get)]
			ProcessDebugPort = 7,

			ProcessExceptionPort, // s: PROCESS_EXCEPTION_PORT
			ProcessAccessToken, // s: PROCESS_ACCESS_TOKEN
			ProcessLdtInformation, // qs: PROCESS_LDT_INFORMATION // 10
			ProcessLdtSize, // s: PROCESS_LDT_SIZE
			ProcessDefaultHardErrorMode, // qs: ULONG
			ProcessIoPortHandlers, // (kernel-mode only) // PROCESS_IO_PORT_HANDLER_INFORMATION
			ProcessPooledUsageAndLimits, // q: POOLED_USAGE_AND_LIMITS
			ProcessWorkingSetWatch, // q: PROCESS_WS_WATCH_INFORMATION[]; s: void
			ProcessUserModeIOPL, // qs: ULONG (requires SeTcbPrivilege)
			ProcessEnableAlignmentFaultFixup, // s: BOOLEAN
			ProcessPriorityClass, // qs: PROCESS_PRIORITY_CLASS
			ProcessWx86Information, // qs: ULONG (requires SeTcbPrivilege) (VdmAllowed)
			ProcessHandleCount, // q: ULONG, PROCESS_HANDLE_INFORMATION // 20
			ProcessAffinityMask, // s: KAFFINITY
			ProcessPriorityBoost, // qs: ULONG
			ProcessDeviceMap, // qs: PROCESS_DEVICEMAP_INFORMATION, PROCESS_DEVICEMAP_INFORMATION_EX
			ProcessSessionInformation, // q: PROCESS_SESSION_INFORMATION
			ProcessForegroundInformation, // s: PROCESS_FOREGROUND_BACKGROUND

			/// <summary>
			/// Determines whether the process is running in the WOW64 environment (WOW64 is the x86 emulator that allows Win32-based
			/// applications to run on 64-bit Windows).
			/// <para>Use the IsWow64Process2 function to obtain this information.</para>
			/// </summary>
			[CorrespondingType(typeof(BOOL), CorrespondingAction.Get)]
			ProcessWow64Information = 26,

			/// <summary>
			/// Retrieves a UNICODE_STRING value containing the name of the image file for the process.
			/// <para>Use the QueryFullProcessImageName or GetProcessImageFileName function to obtain this information.</para>
			/// </summary>
			[CorrespondingType(typeof(UNICODE_STRING), CorrespondingAction.Get)]
			[CorrespondingType(typeof(UNICODE_STRING_WOW64), CorrespondingAction.Get)]
			ProcessImageFileName = 27,

			ProcessLUIDDeviceMapsEnabled, // q: ULONG

			/// <summary>
			/// Retrieves a ULONG value indicating whether the process is considered critical.
			/// <para>
			/// Note This value can be used starting in Windows XP with SP3. Starting in Windows 8.1, IsProcessCritical should be used instead.
			/// </para>
			/// </summary>
			[CorrespondingType(typeof(BOOL), CorrespondingAction.GetSet)]
			ProcessBreakOnTermination = 29,

			ProcessDebugObjectHandle, // q: HANDLE // 30
			ProcessDebugFlags, // qs: ULONG
			ProcessHandleTracing, // q: PROCESS_HANDLE_TRACING_QUERY; s: size 0 disables, otherwise enables
			ProcessIoPriority, // qs: IO_PRIORITY_HINT
			ProcessExecuteFlags, // qs: ULONG
			ProcessResourceManagement, // ProcessTlsInformation // PROCESS_TLS_INFORMATION
			ProcessCookie, // q: ULONG
			ProcessImageInformation, // q: SECTION_IMAGE_INFORMATION
			ProcessCycleTime, // q: PROCESS_CYCLE_TIME_INFORMATION // since VISTA
			ProcessPagePriority, // q: PAGE_PRIORITY_INFORMATION
			ProcessInstrumentationCallback, // qs: PROCESS_INSTRUMENTATION_CALLBACK_INFORMATION // 40
			ProcessThreadStackAllocation, // s: PROCESS_STACK_ALLOCATION_INFORMATION, PROCESS_STACK_ALLOCATION_INFORMATION_EX
			ProcessWorkingSetWatchEx, // q: PROCESS_WS_WATCH_INFORMATION_EX[]
			ProcessImageFileNameWin32, // q: UNICODE_STRING
			ProcessImageFileMapping, // q: HANDLE (input)
			ProcessAffinityUpdateMode, // qs: PROCESS_AFFINITY_UPDATE_MODE
			ProcessMemoryAllocationMode, // qs: PROCESS_MEMORY_ALLOCATION_MODE
			ProcessGroupInformation, // q: USHORT[]
			ProcessTokenVirtualizationEnabled, // s: ULONG
			ProcessConsoleHostProcess, // q: ULONG_PTR // ProcessOwnerInformation
			ProcessWindowInformation, // q: PROCESS_WINDOW_INFORMATION // 50
			ProcessHandleInformation, // q: PROCESS_HANDLE_SNAPSHOT_INFORMATION // since WIN8
			ProcessMitigationPolicy, // s: PROCESS_MITIGATION_POLICY_INFORMATION
			ProcessDynamicFunctionTableInformation,
			ProcessHandleCheckingMode, // qs: ULONG; s: 0 disables, otherwise enables
			ProcessKeepAliveCount, // q: PROCESS_KEEPALIVE_COUNT_INFORMATION
			ProcessRevokeFileHandles, // s: PROCESS_REVOKE_FILE_HANDLES_INFORMATION
			ProcessWorkingSetControl, // s: PROCESS_WORKING_SET_CONTROL
			ProcessHandleTable, // q: ULONG[] // since WINBLUE
			ProcessCheckStackExtentsMode,
			ProcessCommandLineInformation, // q: UNICODE_STRING // 60
			ProcessProtectionInformation, // q: PS_PROTECTION
			ProcessMemoryExhaustion, // PROCESS_MEMORY_EXHAUSTION_INFO // since THRESHOLD
			ProcessFaultInformation, // PROCESS_FAULT_INFORMATION
			ProcessTelemetryIdInformation, // PROCESS_TELEMETRY_ID_INFORMATION
			ProcessCommitReleaseInformation, // PROCESS_COMMIT_RELEASE_INFORMATION
			ProcessDefaultCpuSetsInformation,
			ProcessAllowedCpuSetsInformation,
			ProcessSubsystemProcess,
			ProcessJobMemoryInformation, // PROCESS_JOB_MEMORY_INFO
			ProcessInPrivate, // since THRESHOLD2 // 70
			ProcessRaiseUMExceptionOnInvalidHandleClose, // qs: ULONG; s: 0 disables, otherwise enables
			ProcessIumChallengeResponse,
			ProcessChildProcessInformation, // PROCESS_CHILD_PROCESS_INFORMATION
			ProcessHighGraphicsPriorityInformation,

			/// <summary>
			/// Retrieves a SUBSYSTEM_INFORMATION_TYPE value indicating the subsystem type of the process. The buffer pointed to by the
			/// ProcessInformation parameter should be large enough to hold a single SUBSYSTEM_INFORMATION_TYPE enumeration.
			/// </summary>
			[CorrespondingType(typeof(SUBSYSTEM_INFORMATION_TYPE), CorrespondingAction.Get)]
			ProcessSubsystemInformation = 75,

			ProcessEnergyValues, // PROCESS_ENERGY_VALUES, PROCESS_EXTENDED_ENERGY_VALUES
			ProcessActivityThrottleState, // PROCESS_ACTIVITY_THROTTLE_STATE
			ProcessActivityThrottlePolicy, // PROCESS_ACTIVITY_THROTTLE_POLICY
			ProcessWin32kSyscallFilterInformation,
			ProcessDisableSystemAllowedCpuSets, // 80
			ProcessWakeInformation, // PROCESS_WAKE_INFORMATION
			ProcessEnergyTrackingState, // PROCESS_ENERGY_TRACKING_STATE
			ProcessManageWritesToExecutableMemory, // MANAGE_WRITES_TO_EXECUTABLE_MEMORY // since REDSTONE3
			ProcessCaptureTrustletLiveDump,
			ProcessTelemetryCoverage,
			ProcessEnclaveInformation,
			ProcessEnableReadWriteVmLogging, // PROCESS_READWRITEVM_LOGGING_INFORMATION
			ProcessUptimeInformation, // PROCESS_UPTIME_INFORMATION
			ProcessImageSection, // q: HANDLE
			ProcessDebugAuthInformation, // since REDSTONE4 // 90
			ProcessSystemResourceManagement, // PROCESS_SYSTEM_RESOURCE_MANAGEMENT
			ProcessSequenceNumber, // q: ULONGLONG
			ProcessLoaderDetour, // since REDSTONE5
			ProcessSecurityDomainInformation, // PROCESS_SECURITY_DOMAIN_INFORMATION
			ProcessCombineSecurityDomainsInformation, // PROCESS_COMBINE_SECURITY_DOMAINS_INFORMATION
			ProcessEnableLogging, // PROCESS_LOGGING_INFORMATION
			ProcessLeapSecondInformation, // PROCESS_LEAP_SECOND_INFORMATION
			ProcessFiberShadowStackAllocation, // PROCESS_FIBER_SHADOW_STACK_ALLOCATION_INFORMATION // since 19H1
			ProcessFreeFiberShadowStackAllocation, // PROCESS_FREE_FIBER_SHADOW_STACK_ALLOCATION_INFORMATION
			ProcessAltSystemCallInformation, // qs: BOOLEAN (kernel-mode only) // since 20H1 // 100
			ProcessDynamicEHContinuationTargets, // PROCESS_DYNAMIC_EH_CONTINUATION_TARGETS_INFORMATION
		}

#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member

		/// <summary>
		/// Indicates the type of subsystem for a process or thread. This enumeration is used in NtQueryInformationProcess and
		/// NtQueryInformationThread calls.
		/// </summary>
		// https://docs.microsoft.com/en-us/windows-hardware/drivers/ddi/ntddk/ne-ntddk-_subsystem_information_type typedef enum
		// _SUBSYSTEM_INFORMATION_TYPE { SubsystemInformationTypeWin32, SubsystemInformationTypeWSL, MaxSubsystemInformationType }
		// SUBSYSTEM_INFORMATION_TYPE, *PSUBSYSTEM_INFORMATION_TYPE;
		[PInvokeData("ntddk.h", MSDNShortId = "B1E334BF-AAB3-410D-8D10-A750E8459E42")]
		public enum SUBSYSTEM_INFORMATION_TYPE
		{
			/// <summary>The subsystem type for the process or thread is Win32.</summary>
			SubsystemInformationTypeWin32,

			/// <summary>
			/// The subsystem type for the process or thread is Windows Subsystem for Linux (WSL). For this process, these members of the
			/// PS_CREATE_NOTIFY_INFO structure are set as follows: The preceding member values may be NULL.
			/// </summary>
			SubsystemInformationTypeWSL,

			/// <summary>Reserved.</summary>
			MaxSubsystemInformationType,
		}
		/// <summary>Creates a process. This function is UNDOCUMENTED.</summary>
		/// <param name="ProcessHandle">The process handle.</param>
		/// <param name="DesiredAccess">The desired access.</param>
		/// <param name="ObjectAttributes">The object attributes.</param>
		/// <param name="ParentProcess">The parent process.</param>
		/// <param name="InheritObjectTable">if set to <see langword="true"/>, inherits the object table.</param>
		/// <param name="SectionHandle">The section handle.</param>
		/// <param name="DebugPort">The debug port.</param>
		/// <param name="ExceptionPort">The exception port.</param>
		/// <returns>
		/// <para>The function returns an NTSTATUS success or error code.</para>
		/// <para>
		/// The forms and significance of NTSTATUS error codes are listed in the Ntstatus.h header file available in the DDK, and are
		/// described in the DDK documentation under Kernel-Mode Driver Architecture / Design Guide / Driver Programming Techniques /
		/// Logging Errors.
		/// </para>
		/// </returns>
		[DllImport(Lib.NtDll, SetLastError = false, ExactSpelling = true)]
		public static extern NTStatus NtCreateProcess(out HPROCESS ProcessHandle, [In] ACCESS_MASK DesiredAccess, in OBJECT_ATTRIBUTES ObjectAttributes,
			[In] HPROCESS ParentProcess, [In, MarshalAs(UnmanagedType.U1)] bool InheritObjectTable, [In, Optional] IntPtr SectionHandle,
			[In, Optional] IntPtr DebugPort, [In, Optional] IntPtr ExceptionPort);

		/// <summary>Creates a process. This function is UNDOCUMENTED.</summary>
		/// <param name="ProcessHandle">The process handle.</param>
		/// <param name="DesiredAccess">The desired access.</param>
		/// <param name="ObjectAttributes">The object attributes.</param>
		/// <param name="ParentProcess">The parent process.</param>
		/// <param name="InheritObjectTable">if set to <see langword="true"/>, inherits the object table.</param>
		/// <param name="SectionHandle">The section handle.</param>
		/// <param name="DebugPort">The debug port.</param>
		/// <param name="ExceptionPort">The exception port.</param>
		/// <returns>
		/// <para>The function returns an NTSTATUS success or error code.</para>
		/// <para>
		/// The forms and significance of NTSTATUS error codes are listed in the Ntstatus.h header file available in the DDK, and are
		/// described in the DDK documentation under Kernel-Mode Driver Architecture / Design Guide / Driver Programming Techniques /
		/// Logging Errors.
		/// </para>
		/// </returns>
		[DllImport(Lib.NtDll, SetLastError = false, ExactSpelling = true)]
		public static extern NTStatus NtCreateProcess(out HPROCESS ProcessHandle, [In] ACCESS_MASK DesiredAccess, [In, Optional] IntPtr ObjectAttributes,
			[In] HPROCESS ParentProcess, [In, MarshalAs(UnmanagedType.U1)] bool InheritObjectTable, [In, Optional] IntPtr SectionHandle,
			[In, Optional] IntPtr DebugPort, [In, Optional] IntPtr ExceptionPort);

		/// <summary>Creates a process. This function is UNDOCUMENTED.</summary>
		/// <param name="ProcessHandle">The process handle.</param>
		/// <param name="DesiredAccess">The desired access.</param>
		/// <param name="ObjectAttributes">The object attributes.</param>
		/// <param name="ParentProcess">The parent process.</param>
		/// <param name="Flags">The flags.</param>
		/// <param name="SectionHandle">The section handle.</param>
		/// <param name="DebugPort">The debug port.</param>
		/// <param name="ExceptionPort">The exception port.</param>
		/// <param name="JobMemberLevel">The job member level.</param>
		/// <returns>
		/// <para>The function returns an NTSTATUS success or error code.</para>
		/// <para>
		/// The forms and significance of NTSTATUS error codes are listed in the Ntstatus.h header file available in the DDK, and are
		/// described in the DDK documentation under Kernel-Mode Driver Architecture / Design Guide / Driver Programming Techniques /
		/// Logging Errors.
		/// </para>
		/// </returns>
		[DllImport(Lib.NtDll, SetLastError = false, ExactSpelling = true)]
		public static extern NTStatus NtCreateProcessEx(out HPROCESS ProcessHandle, [In] ACCESS_MASK DesiredAccess, in OBJECT_ATTRIBUTES ObjectAttributes,
			[In] HPROCESS ParentProcess, [In] PROCESS_CREATE_FLAGS Flags, [In, Optional] IntPtr SectionHandle,
			[In, Optional] IntPtr DebugPort, [In, Optional] IntPtr ExceptionPort, uint JobMemberLevel);

		/// <summary>Creates a process. This function is UNDOCUMENTED.</summary>
		/// <param name="ProcessHandle">The process handle.</param>
		/// <param name="DesiredAccess">The desired access.</param>
		/// <param name="ObjectAttributes">The object attributes.</param>
		/// <param name="ParentProcess">The parent process.</param>
		/// <param name="Flags">The flags.</param>
		/// <param name="SectionHandle">The section handle.</param>
		/// <param name="DebugPort">The debug port.</param>
		/// <param name="ExceptionPort">The exception port.</param>
		/// <param name="JobMemberLevel">The job member level.</param>
		/// <returns>
		/// <para>The function returns an NTSTATUS success or error code.</para>
		/// <para>
		/// The forms and significance of NTSTATUS error codes are listed in the Ntstatus.h header file available in the DDK, and are
		/// described in the DDK documentation under Kernel-Mode Driver Architecture / Design Guide / Driver Programming Techniques /
		/// Logging Errors.
		/// </para>
		/// </returns>
		[DllImport(Lib.NtDll, SetLastError = false, ExactSpelling = true)]
		public static extern NTStatus NtCreateProcessEx(out HPROCESS ProcessHandle, [In] ACCESS_MASK DesiredAccess, [In, Optional] IntPtr ObjectAttributes,
			[In] HPROCESS ParentProcess, [In] PROCESS_CREATE_FLAGS Flags, [In, Optional] IntPtr SectionHandle,
			[In, Optional] IntPtr DebugPort, [In, Optional] IntPtr ExceptionPort, uint JobMemberLevel);

		/// <summary>Set the debug object handle in the TEB. This function is UNDOCUMENTED.</summary>
		/// <param name="DebugObjectHandle">Debug object handle. Retrieve from NtQueryInformationProcess</param>
		/// <returns>
		/// <para>The function returns an NTSTATUS success or error code.</para>
		/// <para>
		/// The forms and significance of NTSTATUS error codes are listed in the Ntstatus.h header file available in the DDK, and are
		/// described in the DDK documentation under Kernel-Mode Driver Architecture / Design Guide / Driver Programming Techniques /
		/// Logging Errors.
		/// </para>
		/// </returns>
		[DllImport(Lib.NtDll, SetLastError = false, ExactSpelling = true)]
		public static extern NTStatus DbgUiSetThreadDebugObject(IntPtr DebugObjectHandle);

		/// <summary>Call the kernel to remove the debug object. This function is UNDOCUMENTED.</summary>
		/// <param name="ProcessHandle">The process handle.</param>
		/// <param name="DebugObjectHandle">Debug object handle. Retrieve from NtQueryInformationProcess</param>
		/// <returns>
		/// <para>The function returns an NTSTATUS success or error code.</para>
		/// <para>
		/// The forms and significance of NTSTATUS error codes are listed in the Ntstatus.h header file available in the DDK, and are
		/// described in the DDK documentation under Kernel-Mode Driver Architecture / Design Guide / Driver Programming Techniques /
		/// Logging Errors.
		/// </para>
		/// </returns>
		[DllImport(Lib.NtDll, SetLastError = false, ExactSpelling = true)]
		public static extern NTStatus NtRemoveProcessDebug(HPROCESS ProcessHandle, IntPtr DebugObjectHandle);

		/// <summary>
		/// <para>
		/// [ <c>NtQueryInformationProcess</c> may be altered or unavailable in future versions of Windows. Applications should use the
		/// alternate functions listed in this topic.]
		/// </para>
		/// <para>Retrieves information about the specified process.</para>
		/// </summary>
		/// <param name="ProcessHandle">A handle to the process for which information is to be retrieved.</param>
		/// <param name="ProcessInformationClass">
		/// <para>
		/// The type of process information to be retrieved. This parameter can be one of the following values from the
		/// <c>PROCESSINFOCLASS</c> enumeration.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>ProcessBasicInformation<br/>0</term>
		/// <term>
		/// Retrieves a pointer to a PEB structure that can be used to determine whether the specified process is being debugged, and a
		/// unique value used by the system to identify the specified process. Use the CheckRemoteDebuggerPresent and GetProcessId functions
		/// to obtain this information.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ProcessDebugPort<br/>7</term>
		/// <term>
		/// Retrieves a DWORD_PTR value that is the port number of the debugger for the process. A nonzero value indicates that the process
		/// is being run under the control of a ring 3 debugger. Use the CheckRemoteDebuggerPresent or IsDebuggerPresent function.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ProcessWow64Information<br/>26</term>
		/// <term>
		/// Determines whether the process is running in the WOW64 environment (WOW64 is the x86 emulator that allows Win32-based
		/// applications to run on 64-bit Windows). Use the IsWow64Process2 function to obtain this information.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ProcessImageFileName<br/>27</term>
		/// <term>
		/// Retrieves a UNICODE_STRING value containing the name of the image file for the process. Use the QueryFullProcessImageName or
		/// GetProcessImageFileName function to obtain this information.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ProcessBreakOnTermination<br/>29</term>
		/// <term>Retrieves a ULONG value indicating whether the process is considered critical.</term>
		/// </item>
		/// <item>
		/// <term>ProcessSubsystemInformation<br/>75</term>
		/// <term>
		/// Retrieves a SUBSYSTEM_INFORMATION_TYPE value indicating the subsystem type of the process. The buffer pointed to by the
		/// ProcessInformation parameter should be large enough to hold a single SUBSYSTEM_INFORMATION_TYPE enumeration.
		/// </term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="ProcessInformation">
		/// <para>
		/// A pointer to a buffer supplied by the calling application into which the function writes the requested information. The size of
		/// the information written varies depending on the data type of the ProcessInformationClass parameter:
		/// </para>
		/// <para>PROCESS_BASIC_INFORMATION</para>
		/// <para>
		/// When the ProcessInformationClass parameter is <c>ProcessBasicInformation</c>, the buffer pointed to by the ProcessInformation
		/// parameter should be large enough to hold a single <c>PROCESS_BASIC_INFORMATION</c> structure having the following layout:
		/// </para>
		/// <code><![CDATA[
		///typedef struct _PROCESS_BASIC_INFORMATION {
		///    PVOID Reserved1;
		///    PPEB PebBaseAddress;
		///    PVOID Reserved2[2];
		///    ULONG_PTR UniqueProcessId;
		///    PVOID Reserved3;
		///} PROCESS_BASIC_INFORMATION;
		/// ]]></code>
		/// <para>
		/// The <c>UniqueProcessId</c> member points to the system's unique identifier for this process. Use the GetProcessId function to
		/// retrieve this information.
		/// </para>
		/// <para>The <c>PebBaseAddress</c> member points to a PEB structure.</para>
		/// <para>The other members of this structure are reserved for internal use by the operating system.</para>
		/// <para>ULONG_PTR</para>
		/// <para>
		/// When the ProcessInformationClass parameter is <c>ProcessWow64Information</c>, the buffer pointed to by the ProcessInformation
		/// parameter should be large enough to hold a <c>ULONG_PTR</c>. If this value is nonzero, the process is running in a WOW64
		/// environment; otherwise, if the value is equal to zero, the process is not running in a WOW64 environment.
		/// </para>
		/// <para>Use the IsWow64Process2 function to determine whether a process is running in the WOW64 environment.</para>
		/// <para>UNICODE_STRING</para>
		/// <para>
		/// When the ProcessInformationClass parameter is <c>ProcessImageFileName</c>, the buffer pointed to by the ProcessInformation
		/// parameter should be large enough to hold a <c>UNICODE_STRING</c> structure as well as the string itself. The string stored in
		/// the <c>Buffer</c> member is the name of the image file.
		/// </para>
		/// <para>
		/// If the buffer is too small, the function fails with the STATUS_INFO_LENGTH_MISMATCH error code and the ReturnLength parameter is
		/// set to the required buffer size.
		/// </para>
		/// </param>
		/// <param name="ProcessInformationLength">The size of the buffer pointed to by the ProcessInformation parameter, in bytes.</param>
		/// <param name="ReturnLength">
		/// A pointer to a variable in which the function returns the size of the requested information. If the function was successful,
		/// this is the size of the information written to the buffer pointed to by the ProcessInformation parameter, but if the buffer was
		/// too small, this is the minimum size of buffer needed to receive the information successfully.
		/// </param>
		/// <returns>
		/// <para>The function returns an NTSTATUS success or error code.</para>
		/// <para>
		/// The forms and significance of NTSTATUS error codes are listed in the Ntstatus.h header file available in the DDK, and are
		/// described in the DDK documentation under Kernel-Mode Driver Architecture / Design Guide / Driver Programming Techniques /
		/// Logging Errors.
		/// </para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The <c>NtQueryInformationProcess</c> function and the structures that it returns are internal to the operating system and
		/// subject to change from one release of Windows to another. To maintain the compatibility of your application, it is better to use
		/// public functions mentioned in the description of the ProcessInformationClass parameter instead.
		/// </para>
		/// <para>
		/// If you do use <c>NtQueryInformationProcess</c>, access the function through run-time dynamic linking. This gives your code an
		/// opportunity to respond gracefully if the function has been changed or removed from the operating system. Signature changes,
		/// however, may not be detectable.
		/// </para>
		/// <para>
		/// This function has no associated import library. You must use the LoadLibrary and GetProcAddress functions to dynamically link to Ntdll.dll.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/winternl/nf-winternl-ntqueryinformationprocess __kernel_entry NTSTATUS
		// NtQueryInformationProcess( IN HANDLE ProcessHandle, IN PROCESSINFOCLASS ProcessInformationClass, OUT PVOID ProcessInformation, IN
		// ULONG ProcessInformationLength, OUT PULONG ReturnLength );
		[DllImport(Lib.NtDll, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("winternl.h", MSDNShortId = "0eae7899-c40b-4a5f-9e9c-adae021885e7")]
		public static extern NTStatus NtQueryInformationProcess([In] HPROCESS ProcessHandle, PROCESSINFOCLASS ProcessInformationClass, [Out] IntPtr ProcessInformation, uint ProcessInformationLength, out uint ReturnLength);

		/// <summary>
		/// <para>Retrieves information about the specified process.</para>
		/// </summary>
		/// <typeparam name="T">The type of the structure to retrieve.</typeparam>
		/// <param name="ProcessHandle">A handle to the process for which information is to be retrieved.</param>
		/// <param name="ProcessInformationClass">
		/// <para>
		/// The type of process information to be retrieved. This parameter can be one of the following values from the
		/// <c>PROCESSINFOCLASS</c> enumeration.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>ProcessBasicInformation <br/> 0</term>
		/// <term>
		/// Retrieves a pointer to a PEB structure that can be used to determine whether the specified process is being debugged, and a
		/// unique value used by the system to identify the specified process. Use the CheckRemoteDebuggerPresent and GetProcessId functions
		/// to obtain this information.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ProcessDebugPort <br/> 7</term>
		/// <term>
		/// Retrieves a DWORD_PTR value that is the port number of the debugger for the process. A nonzero value indicates that the process
		/// is being run under the control of a ring 3 debugger. Use the CheckRemoteDebuggerPresent or IsDebuggerPresent function.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ProcessWow64Information <br/> 26</term>
		/// <term>
		/// Determines whether the process is running in the WOW64 environment (WOW64 is the x86 emulator that allows Win32-based
		/// applications to run on 64-bit Windows). Use the IsWow64Process2 function to obtain this information.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ProcessImageFileName <br/> 27</term>
		/// <term>
		/// Retrieves a UNICODE_STRING value containing the name of the image file for the process. Use the QueryFullProcessImageName or
		/// GetProcessImageFileName function to obtain this information.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ProcessBreakOnTermination <br/> 29</term>
		/// <term>Retrieves a ULONG value indicating whether the process is considered critical.</term>
		/// </item>
		/// <item>
		/// <term>ProcessSubsystemInformation <br/> 75</term>
		/// <term>
		/// Retrieves a SUBSYSTEM_INFORMATION_TYPE value indicating the subsystem type of the process. The buffer pointed to by the
		/// ProcessInformation parameter should be large enough to hold a single SUBSYSTEM_INFORMATION_TYPE enumeration.
		/// </term>
		/// </item>
		/// </list>
		/// </param>
		/// <returns>The structure and associated memory for any allocated sub-types.</returns>
		/// <exception cref="System.ArgumentException">Mismatch between requested type and class.</exception>
		public static NtQueryResult<T> NtQueryInformationProcess<T>([In] HPROCESS ProcessHandle, PROCESSINFOCLASS ProcessInformationClass) where T : struct
		{
			var validTypes = CorrespondingTypeAttribute.GetCorrespondingTypes(ProcessInformationClass, CorrespondingAction.Get).ToArray();
			if (validTypes.Length > 0 && Array.IndexOf(validTypes, typeof(T)) == -1)
				throw new ArgumentException("Mismatch between requested type and class.");

			if (IntPtr.Size == 8)
			{
				// Check if the target is a 32 bit process running in WoW64 mode.
				if (IsWow64(ProcessHandle))
				{
					// We are 64 bit. Target process is 32 bit running in WoW64 mode.
					throw new PlatformNotSupportedException("Unable to query a 32-bit process from a 64-bit process.");
				}
			}
			else
			{
				if (NtQueryInformationProcessRequiresWow64Structs(ProcessHandle))
				{
					if (validTypes.Length > 1 && !TypeIsWow())
						throw new ArgumentException("Type name must end in WOW64 to indicate it was configured exclusively for 64-bit use.");
					var res = new NtQueryResult<T>();
					var ret = NtWow64QueryInformationProcess64(ProcessHandle, ProcessInformationClass, ((IntPtr)res).ToInt32(), res.Size, out var qsz);
					if (ret.Succeeded)
						return res;
					if (ret != NTStatus.STATUS_INFO_LENGTH_MISMATCH || qsz == 0)
						throw ret.GetException();
					res.Size = qsz;
					NtWow64QueryInformationProcess64(ProcessHandle, ProcessInformationClass, ((IntPtr)res).ToInt32(), res.Size, out _).ThrowIfFailed();
					return res;
				}
			}

			if (validTypes.Length > 1 && TypeIsWow())
				throw new ArgumentException("Type name must not end in WOW64 should be configured for 32 or 64-bit use.");
			var mem = new NtQueryResult<T>();
			var status = NtQueryInformationProcess(ProcessHandle, ProcessInformationClass, mem, mem.Size, out var sz);
			if (status.Succeeded)
				return mem;
			if (status != NTStatus.STATUS_INFO_LENGTH_MISMATCH || sz == 0)
				throw status.GetException();
			mem.Size = sz;
			NtQueryInformationProcess(ProcessHandle, ProcessInformationClass, mem, mem.Size, out _).ThrowIfFailed();
			return mem;

			bool TypeIsWow() => typeof(T).Name.EndsWith("WOW64");
		}

		/// <summary>A call to <c>NtQueryInformationProcess</c> for the supplied process requires WOW64 structs.</summary>
		/// <param name="ProcessHandle">The process handle.</param>
		/// <returns><see langword="true"/> if structures returned from <c>NtQueryInformationProcess</c> must be configured exclusively for 64-bit use.</returns>
		public static bool NtQueryInformationProcessRequiresWow64Structs(HPROCESS ProcessHandle) => IsWow64(Kernel32.GetCurrentProcess()) && !IsWow64(ProcessHandle);

		/// <summary>
		/// <para>
		/// [ <c>NtQueryInformationProcess</c> may be altered or unavailable in future versions of Windows. Applications should use the
		/// alternate functions listed in this topic.]
		/// </para>
		/// <para>Retrieves information about the specified process.</para>
		/// </summary>
		/// <param name="ProcessHandle">A handle to the process for which information is to be retrieved.</param>
		/// <param name="ProcessInformationClass">
		/// <para>
		/// The type of process information to be retrieved. This parameter can be one of the following values from the
		/// <c>PROCESSINFOCLASS</c> enumeration.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>ProcessBasicInformation<br/>0</term>
		/// <term>
		/// Retrieves a pointer to a PEB structure that can be used to determine whether the specified process is being debugged, and a
		/// unique value used by the system to identify the specified process. Use the CheckRemoteDebuggerPresent and GetProcessId functions
		/// to obtain this information.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ProcessDebugPort<br/>7</term>
		/// <term>
		/// Retrieves a DWORD_PTR value that is the port number of the debugger for the process. A nonzero value indicates that the process
		/// is being run under the control of a ring 3 debugger. Use the CheckRemoteDebuggerPresent or IsDebuggerPresent function.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ProcessWow64Information<br/>26</term>
		/// <term>
		/// Determines whether the process is running in the WOW64 environment (WOW64 is the x86 emulator that allows Win32-based
		/// applications to run on 64-bit Windows). Use the IsWow64Process2 function to obtain this information.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ProcessImageFileName<br/>27</term>
		/// <term>
		/// Retrieves a UNICODE_STRING value containing the name of the image file for the process. Use the QueryFullProcessImageName or
		/// GetProcessImageFileName function to obtain this information.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ProcessBreakOnTermination<br/>29</term>
		/// <term>Retrieves a ULONG value indicating whether the process is considered critical.</term>
		/// </item>
		/// <item>
		/// <term>ProcessSubsystemInformation<br/>75</term>
		/// <term>
		/// Retrieves a SUBSYSTEM_INFORMATION_TYPE value indicating the subsystem type of the process. The buffer pointed to by the
		/// ProcessInformation parameter should be large enough to hold a single SUBSYSTEM_INFORMATION_TYPE enumeration.
		/// </term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="ProcessInformation">
		/// <para>
		/// A pointer to a buffer supplied by the calling application into which the function writes the requested information. The size of
		/// the information written varies depending on the data type of the ProcessInformationClass parameter:
		/// </para>
		/// <para>PROCESS_BASIC_INFORMATION</para>
		/// <para>
		/// When the ProcessInformationClass parameter is <c>ProcessBasicInformation</c>, the buffer pointed to by the ProcessInformation
		/// parameter should be large enough to hold a single <c>PROCESS_BASIC_INFORMATION</c> structure having the following layout:
		/// </para>
		/// <code><![CDATA[
		///typedef struct _PROCESS_BASIC_INFORMATION {
		///    PVOID Reserved1;
		///    PPEB PebBaseAddress;
		///    PVOID Reserved2[2];
		///    ULONG_PTR UniqueProcessId;
		///    PVOID Reserved3;
		///} PROCESS_BASIC_INFORMATION;
		/// ]]></code>
		/// <para>
		/// The <c>UniqueProcessId</c> member points to the system's unique identifier for this process. Use the GetProcessId function to
		/// retrieve this information.
		/// </para>
		/// <para>The <c>PebBaseAddress</c> member points to a PEB structure.</para>
		/// <para>The other members of this structure are reserved for internal use by the operating system.</para>
		/// <para>ULONG_PTR</para>
		/// <para>
		/// When the ProcessInformationClass parameter is <c>ProcessWow64Information</c>, the buffer pointed to by the ProcessInformation
		/// parameter should be large enough to hold a <c>ULONG_PTR</c>. If this value is nonzero, the process is running in a WOW64
		/// environment; otherwise, if the value is equal to zero, the process is not running in a WOW64 environment.
		/// </para>
		/// <para>Use the IsWow64Process2 function to determine whether a process is running in the WOW64 environment.</para>
		/// <para>UNICODE_STRING</para>
		/// <para>
		/// When the ProcessInformationClass parameter is <c>ProcessImageFileName</c>, the buffer pointed to by the ProcessInformation
		/// parameter should be large enough to hold a <c>UNICODE_STRING</c> structure as well as the string itself. The string stored in
		/// the <c>Buffer</c> member is the name of the image file.
		/// </para>
		/// <para>
		/// If the buffer is too small, the function fails with the STATUS_INFO_LENGTH_MISMATCH error code and the ReturnLength parameter is
		/// set to the required buffer size.
		/// </para>
		/// </param>
		/// <param name="ProcessInformationLength">The size of the buffer pointed to by the ProcessInformation parameter, in bytes.</param>
		/// <param name="ReturnLength">
		/// A pointer to a variable in which the function returns the size of the requested information. If the function was successful,
		/// this is the size of the information written to the buffer pointed to by the ProcessInformation parameter, but if the buffer was
		/// too small, this is the minimum size of buffer needed to receive the information successfully.
		/// </param>
		/// <returns>
		/// <para>The function returns an NTSTATUS success or error code.</para>
		/// <para>
		/// The forms and significance of NTSTATUS error codes are listed in the Ntstatus.h header file available in the DDK, and are
		/// described in the DDK documentation under Kernel-Mode Driver Architecture / Design Guide / Driver Programming Techniques /
		/// Logging Errors.
		/// </para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The <c>NtQueryInformationProcess</c> function and the structures that it returns are internal to the operating system and
		/// subject to change from one release of Windows to another. To maintain the compatibility of your application, it is better to use
		/// public functions mentioned in the description of the ProcessInformationClass parameter instead.
		/// </para>
		/// <para>
		/// If you do use <c>NtQueryInformationProcess</c>, access the function through run-time dynamic linking. This gives your code an
		/// opportunity to respond gracefully if the function has been changed or removed from the operating system. Signature changes,
		/// however, may not be detectable.
		/// </para>
		/// <para>
		/// This function has no associated import library. You must use the LoadLibrary and GetProcAddress functions to dynamically link to Ntdll.dll.
		/// </para>
		/// </remarks>
		[DllImport(Lib.NtDll, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("winternl.h")]
		public static extern NTStatus NtWow64QueryInformationProcess64([In] HPROCESS ProcessHandle, PROCESSINFOCLASS ProcessInformationClass, [Out] int ProcessInformation, [In] ulong ProcessInformationLength, out ulong ReturnLength);

		internal static bool IsWow64(HPROCESS hProc) => (Environment.OSVersion.Version.Major >= 6 || (Environment.OSVersion.Version.Major == 5 && Environment.OSVersion.Version.Minor >= 1)) && Kernel32.IsWow64Process(hProc, out var b) && b;

		/// <summary>Timing information for a process.</summary>
		[StructLayout(LayoutKind.Sequential)]
		public struct KERNEL_USER_TIMES
		{
			/// <summary>The creation time of the process.</summary>
			public FILETIME CreateTime;

			/// <summary>The exit time of the process.</summary>
			public FILETIME ExitTime;

			/// <summary>
			/// The amount of time that the process has executed in kernel mode. The time that each of the threads of the process has
			/// executed in kernel mode is determined, and then all of those times are summed together to obtain this value.
			/// </summary>
			public FILETIME KernelTime;

			/// <summary>
			/// The amount of time that the process has executed in user mode. The time that each of the threads of the process has executed
			/// in user mode is determined, and then all of those times are summed together to obtain this value. Note that this value can
			/// exceed the amount of real time elapsed (between lpCreationTime and lpExitTime) if the process executes across multiple CPU cores.
			/// </summary>
			public FILETIME UserTime;
		}

		/// <summary>
		/// <para>[This structure may be altered in future versions of Windows.]</para>
		/// <para>Contains process information.</para>
		/// </summary>
		/// <remarks>The syntax for this structure on 64-bit Windows is as follows:</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/winternl/ns-winternl-peb typedef struct _PEB { BYTE Reserved1[2]; BYTE
		// BeingDebugged; BYTE Reserved2[1]; PVOID Reserved3[2]; PPEB_LDR_DATA Ldr; PRTL_USER_PROCESS_PARAMETERS ProcessParameters; PVOID
		// Reserved4[3]; PVOID AtlThunkSListPtr; PVOID Reserved5; ULONG Reserved6; PVOID Reserved7; ULONG Reserved8; ULONG
		// AtlThunkSListPtr32; PVOID Reserved9[45]; BYTE Reserved10[96]; PPS_POST_PROCESS_INIT_ROUTINE PostProcessInitRoutine; BYTE
		// Reserved11[128]; PVOID Reserved12[1]; ULONG SessionId; } PEB, *PPEB;
		[PInvokeData("winternl.h", MSDNShortId = "836a6b82-d3e8-4de6-808d-5476dfb51356")]
		[StructLayout(LayoutKind.Sequential)]
		public struct PEB
		{
			/// <summary>Reserved for internal use by the operating system.</summary>
			[MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
			private readonly byte[] Reserved_1;

			/// <summary>Indicates whether the specified process is currently being debugged.</summary>
			public byte BeingDebugged;

			/// <summary>Reserved for internal use by the operating system.</summary>
			[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
			private readonly byte[] Reserved2;

			/// <summary>Reserved for internal use by the operating system.</summary>
			[MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
			private readonly IntPtr[] Reserved3;

			/// <summary>A pointer to a PEB_LDR_DATA structure that contains information about the loaded modules for the process.</summary>
			public IntPtr Ldr;

			/// <summary>
			/// A pointer to an RTL_USER_PROCESS_PARAMETERS structure that contains process parameter information such as the command line.
			/// </summary>
			public IntPtr ProcessParameters;

			/// <summary>Reserved for internal use by the operating system.</summary>
			[MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
			private readonly IntPtr[] Reserved4;

			private readonly IntPtr AtlThunkSListPtr;

			/// <summary>Reserved for internal use by the operating system.</summary>
			private readonly IntPtr Reserved5;

			/// <summary>Reserved for internal use by the operating system.</summary>
			private readonly uint Reserved6;

			/// <summary>Reserved for internal use by the operating system.</summary>
			private readonly IntPtr Reserved7;

			/// <summary>Reserved for internal use by the operating system.</summary>
			private readonly uint Reserved8;

			/// <summary/>
			private readonly uint AtlThunkSListPtr32;

			/// <summary>Reserved for internal use by the operating system.</summary>
			[MarshalAs(UnmanagedType.ByValArray, SizeConst = 45)]
			private readonly IntPtr[] Reserved9;

			/// <summary>Reserved for internal use by the operating system.</summary>
			[MarshalAs(UnmanagedType.ByValArray, SizeConst = 96)]
			private readonly byte[] Reserved10;

			/// <summary/>
			private readonly IntPtr PostProcessInitRoutine;

			/// <summary>Reserved for internal use by the operating system.</summary>
			[MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
			private readonly byte[] Reserved11;

			/// <summary>Reserved for internal use by the operating system.</summary>
			[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
			private readonly IntPtr[] Reserved12;

			/// <summary>The Terminal Services session identifier associated with the current process.</summary>
			public uint SessionId;
		}

		/// <summary>
		/// <para>[This structure may be altered in future versions of Windows.]</para>
		/// <para>Contains process information.</para>
		/// </summary>
		/// <remarks>The syntax for this structure on 64-bit Windows is as follows:</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/winternl/ns-winternl-peb typedef struct _PEB { BYTE Reserved1[2]; BYTE
		// BeingDebugged; BYTE Reserved2[1]; PVOID Reserved3[2]; PPEB_LDR_DATA Ldr; PRTL_USER_PROCESS_PARAMETERS ProcessParameters; PVOID
		// Reserved4[3]; PVOID AtlThunkSListPtr; PVOID Reserved5; ULONG Reserved6; PVOID Reserved7; ULONG Reserved8; ULONG
		// AtlThunkSListPtr32; PVOID Reserved9[45]; BYTE Reserved10[96]; PPS_POST_PROCESS_INIT_ROUTINE PostProcessInitRoutine; BYTE
		// Reserved11[128]; PVOID Reserved12[1]; ULONG SessionId; } PEB, *PPEB;
		[PInvokeData("winternl.h", MSDNShortId = "836a6b82-d3e8-4de6-808d-5476dfb51356")]
		[StructLayout(LayoutKind.Sequential)]
		public struct PEB_WOW64
		{
			/// <summary>Reserved for internal use by the operating system.</summary>
			[MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
			private readonly byte[] Reserved_1;

			/// <summary>Indicates whether the specified process is currently being debugged.</summary>
			public byte BeingDebugged;

			/// <summary>Reserved for internal use by the operating system.</summary>
			[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
			private readonly byte[] Reserved2;

			/// <summary>Reserved for internal use by the operating system.</summary>
			[MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
			private readonly long[] Reserved3;

			/// <summary>A pointer to a PEB_LDR_DATA structure that contains information about the loaded modules for the process.</summary>
			public long Ldr;

			/// <summary>
			/// A pointer to an RTL_USER_PROCESS_PARAMETERS structure that contains process parameter information such as the command line.
			/// </summary>
			public long ProcessParameters;

			/// <summary>Reserved for internal use by the operating system.</summary>
			[MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
			private readonly long[] Reserved4;

			private readonly long AtlThunkSListPtr;

			/// <summary>Reserved for internal use by the operating system.</summary>
			private readonly long Reserved5;

			/// <summary>Reserved for internal use by the operating system.</summary>
			private readonly uint Reserved6;

			/// <summary>Reserved for internal use by the operating system.</summary>
			private readonly long Reserved7;

			/// <summary>Reserved for internal use by the operating system.</summary>
			private readonly uint Reserved8;

			/// <summary/>
			private readonly uint AtlThunkSListPtr32;

			/// <summary>Reserved for internal use by the operating system.</summary>
			[MarshalAs(UnmanagedType.ByValArray, SizeConst = 45)]
			private readonly long[] Reserved9;

			/// <summary>Reserved for internal use by the operating system.</summary>
			[MarshalAs(UnmanagedType.ByValArray, SizeConst = 96)]
			private readonly byte[] Reserved10;

			/// <summary/>
			private readonly long PostProcessInitRoutine;

			/// <summary>Reserved for internal use by the operating system.</summary>
			[MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
			private readonly byte[] Reserved11;

			/// <summary>Reserved for internal use by the operating system.</summary>
			[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
			private readonly long[] Reserved12;

			/// <summary>The Terminal Services session identifier associated with the current process.</summary>
			public uint SessionId;
		}

		/// <summary>Contains information for basic process information.</summary>
		/// <remarks>https://msdn.microsoft.com/en-us/library/windows/desktop/ms684280(v=vs.85).aspx</remarks>
		[StructLayout(LayoutKind.Sequential)]
		public struct PROCESS_BASIC_INFORMATION
		{
			/// <summary>Reserved for internal use by the operating system.</summary>
			private readonly IntPtr Reserved1;

			/// <summary>Pointer to a PEB structure.</summary>
			public IntPtr PebBaseAddress;

			/// <summary>Reserved for internal use by the operating system.</summary>
			private readonly IntPtr Reserved2_1;

			/// <summary>Reserved for internal use by the operating system.</summary>
			private readonly IntPtr Reserved2_2;

			/// <summary>System's unique identifier for this process.</summary>
			public IntPtr UniqueProcessId;

			/// <summary>Reserved for internal use by the operating system.</summary>
			private readonly IntPtr Reserved3;
		}

		/// <summary>Contains information for basic process information.</summary>
		/// <remarks>https://msdn.microsoft.com/en-us/library/windows/desktop/ms684280(v=vs.85).aspx</remarks>
		[StructLayout(LayoutKind.Sequential)]
		public struct PROCESS_BASIC_INFORMATION_WOW64
		{
			/// <summary>Reserved for internal use by the operating system.</summary>
			private readonly long Reserved1;

			/// <summary>Pointer to a PEB structure.</summary>
			public long PebBaseAddress;

			/// <summary>Reserved for internal use by the operating system.</summary>
			private readonly long Reserved2_1;

			/// <summary>Reserved for internal use by the operating system.</summary>
			private readonly long Reserved2_2;

			/// <summary>System's unique identifier for this process.</summary>
			public long UniqueProcessId;

			/// <summary>Reserved for internal use by the operating system.</summary>
			private readonly long Reserved3;
		}

		/// <summary>
		/// <para>[This structure may be altered in future versions of Windows.]</para>
		/// <para>Contains process parameter information.</para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/winternl/ns-winternl-rtl_user_process_parameters typedef struct
		// _RTL_USER_PROCESS_PARAMETERS { BYTE Reserved1[16]; PVOID Reserved2[10]; UNICODE_STRING ImagePathName; UNICODE_STRING CommandLine;
		// } RTL_USER_PROCESS_PARAMETERS, *PRTL_USER_PROCESS_PARAMETERS;
		[PInvokeData("winternl.h", MSDNShortId = "e736aefa-9945-4526-84d8-adb6e82b9991")]
		[StructLayout(LayoutKind.Sequential)]
		public struct RTL_USER_PROCESS_PARAMETERS
		{
			/// <summary>Reserved for internal use by the operating system.</summary>
			[MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
			private readonly byte[] Reserved1;

			/// <summary>Reserved for internal use by the operating system.</summary>
			[MarshalAs(UnmanagedType.ByValArray, SizeConst = 10)]
			private readonly IntPtr[] Reserved2;

			/// <summary>The path of the image file for the process.</summary>
			public UNICODE_STRING ImagePathName;

			/// <summary>The command-line string passed to the process.</summary>
			public UNICODE_STRING CommandLine;
		}

		/// <summary>
		/// <para>[This structure may be altered in future versions of Windows.]</para>
		/// <para>Contains process parameter information.</para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/winternl/ns-winternl-rtl_user_process_parameters typedef struct
		// _RTL_USER_PROCESS_PARAMETERS { BYTE Reserved1[16]; PVOID Reserved2[10]; UNICODE_STRING ImagePathName; UNICODE_STRING CommandLine;
		// } RTL_USER_PROCESS_PARAMETERS, *PRTL_USER_PROCESS_PARAMETERS;
		[PInvokeData("winternl.h", MSDNShortId = "e736aefa-9945-4526-84d8-adb6e82b9991")]
		[StructLayout(LayoutKind.Sequential)]
		public struct RTL_USER_PROCESS_PARAMETERS_WOW64
		{
			/// <summary>Reserved for internal use by the operating system.</summary>
			[MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
			private readonly byte[] Reserved1;

			/// <summary>Reserved for internal use by the operating system.</summary>
			[MarshalAs(UnmanagedType.ByValArray, SizeConst = 10)]
			private readonly long[] Reserved2;

			/// <summary>The path of the image file for the process.</summary>
			public UNICODE_STRING_WOW64 ImagePathName;

			/// <summary>The command-line string passed to the process.</summary>
			public UNICODE_STRING_WOW64 CommandLine;
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
			/// The start of the next item in the array is the address of the previous item plus the value in the NextEntryOffset member.
			/// For the last item in the array, NextEntryOffset is 0.
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
		/// Represents the structure and associated memory returned by <c>NtQueryXX</c> functions. The memory associate with this structure
		/// will be disposed when this variable goes out of scope or is disposed.
		/// </summary>
		/// <typeparam name="T">The type of the retrieved structure.</typeparam>
		public class NtQueryResult<T> : SafeMemStruct<T, HGlobalMemoryMethods> where T : struct
		{
			internal NtQueryResult(uint sz = 0) : base(sz)
			{
			}
		}
	}
}