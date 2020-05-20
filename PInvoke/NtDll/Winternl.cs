using System;
using System.Runtime.InteropServices;
using Vanara.InteropServices;

namespace Vanara.PInvoke
{
	/// <summary>Platform invokable enumerated types, constants and functions from ntdll.h</summary>
	public static partial class NtDll
	{
		/// <summary>The type of process information to be retrieved.</summary>
		[PInvokeData("winternl.h", MSDNShortId = "0eae7899-c40b-4a5f-9e9c-adae021885e7")]
		public enum PROCESSINFOCLASS
		{
			/// <summary>
			/// Retrieves a pointer to a PEB structure that can be used to determine whether the specified process is being debugged, and a
			/// unique value used by the system to identify the specified process.
			/// <para>Use the CheckRemoteDebuggerPresent and GetProcessId functions to obtain this information.</para>
			/// </summary>
			[CorrespondingType(typeof(PROCESS_BASIC_INFORMATION), CorrespondingAction.Get)]
			ProcessBasicInformation = 0,

			/// <summary>
			/// Retrieves a DWORD_PTR value that is the port number of the debugger for the process. A nonzero value indicates that the
			/// process is being run under the control of a ring 3 debugger.
			/// <para>Use the CheckRemoteDebuggerPresent or IsDebuggerPresent function.</para>
			/// </summary>
			[CorrespondingType(typeof(IntPtr), CorrespondingAction.Get)]
			ProcessDebugPort = 7,

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
			ProcessImageFileName = 27,

			/// <summary>
			/// Retrieves a ULONG value indicating whether the process is considered critical.
			/// <para>
			/// Note This value can be used starting in Windows XP with SP3. Starting in Windows 8.1, IsProcessCritical should be used instead.
			/// </para>
			/// </summary>
			[CorrespondingType(typeof(BOOL), CorrespondingAction.Get)]
			ProcessBreakOnTermination = 29,

			/// <summary>
			/// Retrieves a SUBSYSTEM_INFORMATION_TYPE value indicating the subsystem type of the process. The buffer pointed to by the
			/// ProcessInformation parameter should be large enough to hold a single SUBSYSTEM_INFORMATION_TYPE enumeration.
			/// </summary>
			[CorrespondingType(typeof(SUBSYSTEM_INFORMATION_TYPE), CorrespondingAction.Get)]
			ProcessSubsystemInformation = 75,
		}

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
			if (!CorrespondingTypeAttribute.CanGet(ProcessInformationClass, typeof(T))) throw new ArgumentException("Mismatch between requested type and class.");
			var mem = new NtQueryResult<T>();
			var status = NtQueryInformationProcess(ProcessHandle, ProcessInformationClass, mem, mem.Size, out var sz);
			if (status.Succeeded) return mem;
			if (status != NTStatus.STATUS_INFO_LENGTH_MISMATCH || sz == 0) throw status.GetException();
			mem.Size = sz;
			NtQueryInformationProcess(ProcessHandle, ProcessInformationClass, mem, mem.Size, out _).ThrowIfFailed();
			return mem;
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