using System;
using System.Runtime.InteropServices;
using System.Text;

namespace Vanara.PInvoke
{
	public static partial class Kernel32
	{
		/// <summary>Describes possible machine architectures. Used in <c>GetSystemWow64Directory2</c> and <c>IsWow64GuestMachineSupported</c>.</summary>
		// https://msdn.microsoft.com/en-us/library/windows/desktop/mt804345(v=vs.85).aspx
		[PInvokeData("Winnt.h", MSDNShortId = "mt804345")]
		public enum IMAGE_FILE_MACHINE : ushort
		{
			/// <summary>Unknown</summary>
			IMAGE_FILE_MACHINE_UNKNOWN = 0,

			/// <summary>
			/// Interacts with the host and not a WOW64 guest. <note>This constant is available starting with Windows 10, version 1607 and
			/// Windows Server 2016.</note>
			/// </summary>
			IMAGE_FILE_MACHINE_TARGET_HOST = 0x0001,

			/// <summary>Intel 386</summary>
			IMAGE_FILE_MACHINE_I386 = 0x014c,

			/// <summary>MIPS little-endian, 0x160 big-endian</summary>
			IMAGE_FILE_MACHINE_R3000 = 0x0162,

			/// <summary>MIPS little-endian</summary>
			IMAGE_FILE_MACHINE_R4000 = 0x0166,

			/// <summary>MIPS little-endian</summary>
			IMAGE_FILE_MACHINE_R10000 = 0x0168,

			/// <summary>MIPS little-endian WCE v2</summary>
			IMAGE_FILE_MACHINE_WCEMIPSV2 = 0x0169,

			/// <summary>Alpha_AXP</summary>
			IMAGE_FILE_MACHINE_ALPHA = 0x0184,

			/// <summary>SH3 little-endian</summary>
			IMAGE_FILE_MACHINE_SH3 = 0x01a2,

			/// <summary>SH3DSP</summary>
			IMAGE_FILE_MACHINE_SH3DSP = 0x01a3,

			/// <summary>SH3E little-endian</summary>
			IMAGE_FILE_MACHINE_SH3E = 0x01a4,

			/// <summary>SH4 little-endian</summary>
			IMAGE_FILE_MACHINE_SH4 = 0x01a6,

			/// <summary>SH5</summary>
			IMAGE_FILE_MACHINE_SH5 = 0x01a8,

			/// <summary>ARM Little-Endian</summary>
			IMAGE_FILE_MACHINE_ARM = 0x01c0,

			/// <summary>ARM Thumb/Thumb-2 Little-Endian</summary>
			IMAGE_FILE_MACHINE_THUMB = 0x01c2,

			/// <summary>ARM Thumb-2 Little-Endian <note>This constant is available starting with Windows 7 and Windows Server 2008 R2.</note></summary>
			IMAGE_FILE_MACHINE_ARMNT = 0x01c4,

			/// <summary>TAM33BD</summary>
			IMAGE_FILE_MACHINE_AM33 = 0x01d3,

			/// <summary>IBM PowerPC Little-Endian</summary>
			IMAGE_FILE_MACHINE_POWERPC = 0x01F0,

			/// <summary>POWERPCFP</summary>
			IMAGE_FILE_MACHINE_POWERPCFP = 0x01f1,

			/// <summary>Intel 64</summary>
			IMAGE_FILE_MACHINE_IA64 = 0x0200,

			/// <summary>MIPS</summary>
			IMAGE_FILE_MACHINE_MIPS16 = 0x0266,

			/// <summary>ALPHA64</summary>
			IMAGE_FILE_MACHINE_ALPHA64 = 0x0284,

			/// <summary>MIPS</summary>
			IMAGE_FILE_MACHINE_MIPSFPU = 0x0366,

			/// <summary>MIPS</summary>
			IMAGE_FILE_MACHINE_MIPSFPU16 = 0x0466,

			/// <summary>AXP64</summary>
			IMAGE_FILE_MACHINE_AXP64 = 0x0284,

			/// <summary>Infineon</summary>
			IMAGE_FILE_MACHINE_TRICORE = 0x0520,

			/// <summary>CEF</summary>
			IMAGE_FILE_MACHINE_CEF = 0x0CEF,

			/// <summary>EFI Byte Code</summary>
			IMAGE_FILE_MACHINE_EBC = 0x0EBC,

			/// <summary>AMD64 (K8)</summary>
			IMAGE_FILE_MACHINE_AMD64 = 0x8664,

			/// <summary>M32R little-endian</summary>
			IMAGE_FILE_MACHINE_M32R = 0x9041,

			/// <summary>ARM64 Little-Endian <note>This constant is available starting with Windows 8.1 and Windows Server 2012 R2.</note></summary>
			IMAGE_FILE_MACHINE_ARM64 = 0xAA64,

			/// <summary>CEE</summary>
			IMAGE_FILE_MACHINE_CEE = 0xC0EE,
		}

		/// <summary>Retrieves the path of the system directory used by WOW64. This directory is not present on 32-bit Windows.</summary>
		/// <param name="lpBuffer">A pointer to the buffer to receive the path. This path does not end with a backslash.</param>
		/// <param name="uSize">The maximum size of the buffer, in <c>TCHARs</c>.</param>
		/// <returns>
		/// <para>
		/// If the function succeeds, the return value is the length, in <c>TCHARs</c>, of the string copied to the buffer, not including the
		/// terminating null character. If the length is greater than the size of the buffer, the return value is the size of the buffer
		/// required to hold the path.
		/// </para>
		/// <para>If the function fails, the return value is zero. To get extended error information, call <c>GetLastError</c>.</para>
		/// <para>On 32-bit Windows, the function always fails, and the extended error is set to ERROR_CALL_NOT_IMPLEMENTED.</para>
		/// </returns>
		// UINT WINAPI GetSystemWow64Directory( _Out_ LPTSTR lpBuffer, _In_ UINT uSize); https://msdn.microsoft.com/en-us/library/windows/desktop/ms724405(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = true, CharSet = CharSet.Auto)]
		[PInvokeData("Winbase.h", MSDNShortId = "ms724405")]
		public static extern uint GetSystemWow64Directory(StringBuilder lpBuffer, uint uSize);

		/// <summary>
		/// Retrieves the path of the system directory used by WOW64, using the specified image file machine type. This directory is not
		/// present on 32-bit Windows.
		/// </summary>
		/// <param name="lpBuffer">A pointer to the buffer to receive the path. This path does not end with a backslash.</param>
		/// <param name="uSize">The maximum size of the buffer, in TCHARs.</param>
		/// <param name="ImageFileMachineType">An IMAGE_FILE_MACHINE_* value that specifies the machine to test.</param>
		/// <returns>
		/// <para>
		/// If the function succeeds, the return value is the length, in <c>TCHARs</c>, of the string copied to the buffer, not including the
		/// terminating null character. If the length is greater than the size of the buffer, the return value is the size of the buffer
		/// required to hold the path.
		/// </para>
		/// <para>If the function fails, the return value is zero. To get extended error information, call <c>GetLastError</c>.</para>
		/// </returns>
		// UINT WINAPI GetSystemWow64Directory( _Out_ LPTSTR lpBuffer, _In_ UINT uSize, _In_ WORD ImageFileMachineType); https://msdn.microsoft.com/en-us/library/windows/desktop/mt804319(v=vs.85).aspx
		[DllImport(Lib.KernelBase, SetLastError = true, CharSet = CharSet.Auto)]
		[PInvokeData("Wow64apiset.h", MSDNShortId = "mt804319")]
		public static extern uint GetSystemWow64Directory2(StringBuilder lpBuffer, uint uSize, IMAGE_FILE_MACHINE ImageFileMachineType);

		/// <summary>
		/// <para>
		/// [Some information relates to pre-released product which may be substantially modified before it's commercially released.
		/// Microsoft makes no warranties, express or implied, with respect to the information provided here.]
		/// </para>
		/// <para>Determines which architectures are supported (under WOW64) on the given machine architecture.</para>
		/// </summary>
		/// <param name="WowGuestMachine">An <c>IMAGE_FILE_MACHINE_*</c> value that specifies the machine to test.</param>
		/// <param name="MachineIsSupported">
		/// On success, returns a pointer to a boolean: <c>true</c> if the machine supports WOW64, or <c>false</c> if it does not.
		/// </param>
		/// <returns>On success, returns <c>S_OK</c>; otherwise, returns an error. To get extended error information, call <c>GetLastError</c>.</returns>
		// HRESULT WINAPI IsWow64GuestMachineSupported( _In_ USHORT WowGuestMachine, _Out_ BOOLEAN *MachineIsSupported); https://msdn.microsoft.com/en-us/library/windows/desktop/mt804321(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("Wow64apiset.h", MSDNShortId = "mt804321")]
		public static extern HRESULT IsWow64GuestMachineSupported(IMAGE_FILE_MACHINE WowGuestMachine, [MarshalAs(UnmanagedType.U1)] out bool MachineIsSupported);

		/// <summary>Determines whether the specified process is running under WOW64.</summary>
		/// <param name="hProcess">
		/// <para>
		/// A handle to the process. The handle must have the PROCESS_QUERY_INFORMATION or PROCESS_QUERY_LIMITED_INFORMATION access right.
		/// For more information, see Process Security and Access Rights.
		/// </para>
		/// <para><c>Windows Server 2003 and Windows XP:</c> The handle must have the PROCESS_QUERY_INFORMATION access right.</para>
		/// </param>
		/// <param name="Wow64Process">
		/// A pointer to a value that is set to TRUE if the process is running under WOW64. If the process is running under 32-bit Windows,
		/// the value is set to FALSE. If the process is a 64-bit application running under 64-bit Windows, the value is also set to FALSE.
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is a nonzero value.</para>
		/// <para>If the function fails, the return value is zero. To get extended error information, call <c>GetLastError</c>.</para>
		/// </returns>
		// BOOL WINAPI IsWow64Process( _In_ HANDLE hProcess, _Out_ PBOOL Wow64Process); https://msdn.microsoft.com/en-us/library/windows/desktop/ms684139(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("WinBase.h", MSDNShortId = "ms684139")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool IsWow64Process([In] HPROCESS hProcess, [MarshalAs(UnmanagedType.Bool)] out bool Wow64Process);

		/// <summary>
		/// Determines whether the specified process is running under WOW64; also returns additional machine process and architecture information.
		/// </summary>
		/// <param name="hProcess">
		/// A handle to the process. The handle must have the PROCESS_QUERY_INFORMATION or PROCESS_QUERY_LIMITED_INFORMATION access right.
		/// For more information, see Process Security and Access Rights.
		/// </param>
		/// <param name="pProcessMachine">
		/// On success, returns a pointer to an IMAGE_FILE_MACHINE_* value. The value will be IMAGE_FILE_MACHINE_UNKNOWN if the target
		/// process is not a WOW64 process; otherwise, it will identify the type of WoW process.
		/// </param>
		/// <param name="pNativeMachine">
		/// On success, returns a pointer to a possible IMAGE_FILE_MACHINE_* value identifying the native architecture of host system.
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is a nonzero value.</para>
		/// <para>If the function fails, the return value is zero. To get extended error information, call <c>GetLastError</c>.</para>
		/// </returns>
		// BOOL WINAPI IsWow64Process( _In_ HANDLE hProcess, _Out_ USHORT *pProcessMachine, _Out_opt_ USHORT *pNativeMachine); https://msdn.microsoft.com/en-us/library/windows/desktop/mt804318(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("Wow64apiset.h", MSDNShortId = "mt804318")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool IsWow64Process2([In] HPROCESS hProcess, out IMAGE_FILE_MACHINE pProcessMachine, out IMAGE_FILE_MACHINE pNativeMachine);

		/// <summary>Disables file system redirection for the calling thread. File system redirection is enabled by default.</summary>
		/// <param name="OldValue">
		/// The WOW64 file system redirection value. The system uses this parameter to store information necessary to revert (re-enable) file
		/// system redirection.
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is a nonzero value.</para>
		/// <para>If the function fails, the return value is zero. To get extended error information, call <c>GetLastError</c>.</para>
		/// </returns>
		// BOOL WINAPI Wow64DisableWow64FsRedirection( _Out_ PVOID *OldValue); https://msdn.microsoft.com/en-us/library/windows/desktop/aa365743(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("WinBase.h", MSDNShortId = "aa365743")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool Wow64DisableWow64FsRedirection(out IntPtr OldValue);

		/// <summary>
		/// <para>Restores file system redirection for the calling thread.</para>
		/// <para>This function should not be called without a previous call to the <c>Wow64DisableWow64FsRedirection</c> function.</para>
		/// <para>Any data allocation on behalf of the <c>Wow64DisableWow64FsRedirection</c> function is cleaned up by this function.</para>
		/// </summary>
		/// <param name="OldValue">
		/// The WOW64 file system redirection value. This value is obtained from the <c>Wow64DisableWow64FsRedirection</c> function.
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is a nonzero value.</para>
		/// <para>If the function fails, the return value is <c>FALSE</c> (zero). To get extended error information, call <c>GetLastError</c>.</para>
		/// </returns>
		// BOOL WINAPI Wow64RevertWow64FsRedirection( _In_ PVOID OldValue); https://msdn.microsoft.com/en-us/library/windows/desktop/aa365745(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("WinBase.h", MSDNShortId = "aa365745")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool Wow64RevertWow64FsRedirection(IntPtr OldValue);

		/// <summary>Undocumented.</summary>
		/// <param name="Machine">Undocumented.</param>
		/// <returns>Undocumented.</returns>
		[DllImport(Lib.KernelBase, SetLastError = true, ExactSpelling = true)]
		public static extern IMAGE_FILE_MACHINE Wow64SetThreadDefaultGuestMachine(IMAGE_FILE_MACHINE Machine);
	}
}