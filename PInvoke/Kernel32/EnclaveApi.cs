using System;
using System.Runtime.InteropServices;

namespace Vanara.PInvoke
{
	public static partial class Kernel32
	{
		/// <summary>Used by the <see cref="CallEnclave"/> function.</summary>
		/// <param name="lpThreadParameter">The thread parameter.</param>
		/// <returns>The return thread parameter.</returns>
		[PInvokeData("MinWinBase.h")]
		[UnmanagedFunctionPointer(CallingConvention.StdCall)]
		public delegate IntPtr PENCLAVE_ROUTINE(IntPtr lpThreadParameter);

		/// <summary>A flag that indicates whether the enclave permits debugging.</summary>
		public enum ENCLAVE_VBS_FLAG : uint
		{
			/// <summary>The enclave does not permit debugging.</summary>
			ENCLAVE_VBS_FLAG_NODEBUG = 0x00000000,
			/// <summary>The enclave permits debugging.</summary>
			ENCLAVE_VBS_FLAG_DEBUG = 0x00000001,
		}

		/// <summary>The architecture type of the enclave that you want to create.</summary>
		[Flags]
		public enum EnclaveType : uint
		{
			/// <summary>An enclave for the Intel Software Guard Extensions (SGX) architecture extension.</summary>
			ENCLAVE_TYPE_SGX = 0x00000001,
			/// <summary>A VBS enclave.</summary>
			ENCLAVE_TYPE_VBS = 0x00000010,
		}

		/// <summary>Calls a function within an enclave. <c>CallEnclave</c> can also be called within an enclave to call a function outside of the enclave.</summary>
		/// <param name="lpRoutine">The address of the function that you want to call.</param>
		/// <param name="lpParameter">The parameter than you want to pass to the function.</param>
		/// <param name="fWaitForThread">
		/// <para>
		/// <c>TRUE</c> if the call to the specified function should block execution until an idle enclave thread becomes available when no idle enclave thread
		/// is available. <c>FALSE</c> if the call to the specified function should fail when no idle enclave thread is available.
		/// </para>
		/// <para>This parameter is ignored when you use <c>CallEnclave</c> within an enclave to call a function that is not in any enclave.</para>
		/// </param>
		/// <param name="lpReturnValue">The return value of the function, if it is called successfully.</param>
		/// <returns><c>TRUE</c> if the specified function was called successfully; otherwise <c>FALSE</c>. To get extended error information, call <c>GetLastError</c>.</returns>
		// BOOL WINAPI CallEnclave( _In_ LPENCLAVE_ROUTINE lpRoutine, _In_ LPVOID lpParameter, _In_ BOOL fWaitForThread, _Out_ LPVOID *lpReturnValue); https://msdn.microsoft.com/en-us/library/windows/desktop/mt844231(v=vs.85).aspx
		[DllImport(Lib.VertDll, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("Enclaveapi.h", MSDNShortId = "mt844231")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool CallEnclave(PENCLAVE_ROUTINE lpRoutine, IntPtr lpParameter, [MarshalAs(UnmanagedType.Bool)] bool fWaitForThread, out IntPtr lpReturnValue);

		/// <summary>
		/// Creates a new uninitialized enclave. An enclave is an isolated region of code and data within the address space for an application. Only code that
		/// runs within the enclave can access data within the same enclave.
		/// </summary>
		/// <param name="hProcess">A handle to the process for which you want to create an enclave.</param>
		/// <param name="lpAddress">The preferred base address of the enclave. Specify <c>NULL</c> to have the operating system assign the base address.</param>
		/// <param name="dwSize">The size of the enclave that you want to create, including the size of the code that you will load into the enclave, in bytes.</param>
		/// <param name="dwInitialCommittment">
		/// <para>The amount of memory to commit for the enclave, in bytes.</para>
		/// <para>
		/// If the amount of enclave memory available is not sufficient to commit this number of bytes, enclave creation fails. Any memory that remains unused
		/// when you initialize the enclave by calling <c>InitializeEnclave</c> is returned to the list of free pages.
		/// </para>
		/// <para>The value of the dwInitialCommittment parameter must not exceed the value of the dwSize parameter.</para>
		/// <para>This parameter is not used for virtualization-based security (VBS) enclaves.</para>
		/// </param>
		/// <param name="flEnclaveType">
		/// <para>The architecture type of the enclave that you want to create. To verify that an enclave type is supported, call <c>IsEnclaveTypeSupported</c>.</para>
		/// <para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>ENCLAVE_TYPE_SGX0x00000001</term>
		/// <term>An enclave for the Intel Software Guard Extensions (SGX) architecture extension.</term>
		/// </item>
		/// <item>
		/// <term>ENCLAVE_TYPE_VBS0x00000010</term>
		/// <term>A VBS enclave.</term>
		/// </item>
		/// </list>
		/// </para>
		/// </param>
		/// <param name="lpEnclaveInformation">
		/// <para>A pointer to the architecture-specific information to use to create the enclave.</para>
		/// <para>For the <c>ENCLAVE_TYPE_SGX</c> enclave type, you must specify a pointer to an <c>ENCLAVE_CREATE_INFO_SGX</c> structure.</para>
		/// <para>For the <c>ENCLAVE_TYPE_VBS</c> enclave type, you must specify a pointer to an <c>ENCLAVE_CREATE_INFO_VBS</c> structure.</para>
		/// </param>
		/// <param name="dwInfoLength">
		/// The length of the structure that the lpEnclaveInformation parameter points to, in bytes. For the <c>ENCLAVE_TYPE_SGX</c> enclave type, this value
		/// must be 4096. For the <c>ENCLAVE_TYPE_VBS</c> enclave type, this value must be , which is 36 bytes.
		/// </param>
		/// <param name="lpEnclaveError">
		/// An optional pointer to a variable that receives an enclave error code that is architecture-specific. For the <c>ENCLAVE_TYPE_SGX</c> and
		/// <c>ENCLAVE_TYPE_VBS</c> enclave types, the lpEnclaveError parameter is not used.
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is the base address of the created enclave.</para>
		/// <para>If the function fails, the return value is <c>NULL</c>. To get extended error information, call <c>GetLastError</c>.</para>
		/// <para>For a list of common error codes, see System Error Codes. The following error codes also apply for this function.</para>
		/// <para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>ERROR_NOT_SUPPORTED</term>
		/// <term>An unsupported enclave type was specified.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_BAD_LENGTH</term>
		/// <term>The value of the dwInfoLength parameter did not match the value expected based on the value specified for the lpEnclaveInformation parameter.</term>
		/// </item>
		/// </list>
		/// </para>
		/// </returns>
		// PVOID WINAPI CreateEnclave( _In_ HANDLE hProcess, _In_opt_ LPVOID lpAddress, _In_ SIZE_T dwSize, _In_ SIZE_T dwInitialCommittment, _In_ DWORD
		// flEnclaveType, _In_ LPCVOID lpEnclaveInformation, _In_ DWORD dwInfoLength, _Out_opt_ LPDWORD lpEnclaveError); https://msdn.microsoft.com/en-us/library/windows/desktop/mt592866(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("Enclaveapi.h", MSDNShortId = "mt592866")]
		public static extern void CreateEnclave(IntPtr hProcess, IntPtr lpAddress, SizeT dwSize, SizeT dwInitialCommittment, EnclaveType flEnclaveType, IntPtr lpEnclaveInformation, uint dwInfoLength, out uint lpEnclaveError);

		/// <summary>Deletes the specified enclave.</summary>
		/// <param name="lpAddress">The base address of the enclave that you want to delete.</param>
		/// <returns>
		/// <para><c>TRUE</c> if the enclave was deleted successfully; otherwise <c>FALSE</c>. To get extended error information, call <c>GetLastError</c>.</para>
		/// <para>For a list of common error codes, see System Error Codes. The following error codes also apply for this function.</para>
		/// <para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>ERROR_ENCLAVE_NOT_TERMINATED</term>
		/// <term>
		/// The execution of threads running with the enclave was not ended, because either TerminateEnclave was not called, or the execution of the threads has
		/// not yet ended in response to an earlier call to TerminateEnclave.
		/// </term>
		/// </item>
		/// </list>
		/// </para>
		/// </returns>
		// BOOL WINAPI DeleteEnclave( _In_ LPVOID lpAddress); https://msdn.microsoft.com/en-us/library/windows/desktop/mt844232(v=vs.85).aspx
		[DllImport(Lib.VertDll, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("Enclaveapi.h", MSDNShortId = "mt844232")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool DeleteEnclave(IntPtr lpAddress);

		/// <summary>Initializes an enclave that you created and loaded with data.</summary>
		/// <param name="hProcess">A handle to the process for which the enclave was created.</param>
		/// <param name="lpAddress">Any address within the enclave.</param>
		/// <param name="lpEnclaveInformation">
		/// <para>A pointer to architecture-specific information to use to initialize the enclave.</para>
		/// <para>For the <c>ENCLAVE_TYPE_SGX</c> enclave type, specify a pointer to an <c>ENCLAVE_INIT_INFO_SGX</c> structure.</para>
		/// <para>For the <c>ENCLAVE_TYPE_VBS</c> enclave type, specify a pointer to an <c>ENCLAVE_INIT_INFO_VBS</c> structure.</para>
		/// </param>
		/// <param name="dwInfoLength">
		/// The length of the structure that the lpEnclaveInformation parameter points to, in bytes. For the <c>ENCLAVE_TYPE_SGX</c> enclave type, this value
		/// must be 4096. For the <c>ENCLAVE_TYPE_VBS</c> enclave type, this value must be , which is 8 bytes.
		/// </param>
		/// <param name="lpEnclaveError">
		/// <para>An optional pointer to a variable that receives an enclave error code that is architecture-specific.</para>
		/// <para>
		/// For the <c>ENCLAVE_TYPE_SGX</c> enclave type, the lpEnclaveError parameter contains the error that the EINIT instruction generated if the function
		/// fails and . <c>GetLastError</c> returns <c>ERROR_ENCLAVE_FAILURE</c>.
		/// </para>
		/// <para>For the <c>ENCLAVE_TYPE_VBS</c> enclave type, the lpEnclaveError parameter is not used.</para>
		/// </param>
		/// <returns>
		/// <para>
		/// If the function succeeds, the return value is nonzero. If the function fails, the return value is zero. To get extended error information, call <c>GetLastError</c>.
		/// </para>
		/// <para>For a list of common error codes, see System Error Codes. The following error codes also apply for this function.</para>
		/// <para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>ERROR_ENCLAVE_FAILURE</term>
		/// <term>
		/// An failure specific to the underlying enclave architecture occurred. The value for the lpEnclaveError parameter contains the architecture-specific
		/// error. For the ENCLAVE_TYPE_SGX enclave type, the EINIT instruction that the ENCLAVE_INIT_INFO_SGX structure specified generated an error. The value
		/// of the lpEnclaveError parameter contains the error that the instruction generated.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ERROR_BAD_LENGTH</term>
		/// <term>The value of the dwInfoLength parameter did not match the value expected based on the value specified for the lpEnclaveInformation parameter.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_RETRY</term>
		/// <term>The processor was not able to initialize the enclave in a timely fashion. Try to initialize the enclave again.</term>
		/// </item>
		/// </list>
		/// </para>
		/// </returns>
		// BOOL WINAPI InitializeEnclave( _In_ HANDLE hProcess, _In_ LPVOID lpAddress, _In_ LPVOID lpEnclaveInformation, _In_ DWORD dwInfoLength, _In_ LPDWORD
		// lpEnclaveError); https://msdn.microsoft.com/en-us/library/windows/desktop/mt592869(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("Enclaveapi.h", MSDNShortId = "mt592869")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool InitializeEnclave(IntPtr hProcess, IntPtr lpAddress, IntPtr lpEnclaveInformation, uint dwInfoLength, ref uint lpEnclaveError);

		/// <summary>Retrieves whether the specified type of enclave is supported.</summary>
		/// <param name="flEnclaveType">
		/// <para>The type of enclave to check.</para>
		/// <para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>ENCLAVE_TYPE_SGX0x00000001</term>
		/// <term>An enclave for the Intel Software Guard Extensions (SGX) architecture extension.</term>
		/// </item>
		/// <item>
		/// <term>ENCLAVE_TYPE_VBS0x00000010</term>
		/// <term>A virtualization-based security (VBS) enclave.</term>
		/// </item>
		/// </list>
		/// </para>
		/// </param>
		/// <returns>
		/// <para>
		/// If the function succeeds, the return value is nonzero. If the function fails, the return value is zero. To get extended error information, call <c>GetLastError</c>.
		/// </para>
		/// <para>For a list of common error codes, see System Error Codes. The following error codes also apply for this function.</para>
		/// <para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>ERROR_NOT_SUPPORTED</term>
		/// <term>An unsupported enclave type was specified.</term>
		/// </item>
		/// </list>
		/// </para>
		/// </returns>
		// BOOL WINAPI IsEnclaveTypeSupported( _In_ DWORD flEnclaveType); https://msdn.microsoft.com/en-us/library/windows/desktop/mt592870(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("Enclaveapi.h", MSDNShortId = "mt592870")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool IsEnclaveTypeSupported(EnclaveType flEnclaveType);

		/// <summary>Loads data into an uninitialized enclave that you created by calling <c>CreateEnclave</c>.</summary>
		/// <param name="hProcess">A handle to the process for which the enclave was created.</param>
		/// <param name="lpAddress">The address in the enclave where you want to load the data.</param>
		/// <param name="lpBuffer">A pointer to the data the you want to load into the enclave.</param>
		/// <param name="nSize">
		/// The size of the data that you want to load into the enclave, in bytes. This value must be a whole-number multiple of the page size.
		/// </param>
		/// <param name="flProtect">
		/// <para>
		/// The memory protection to use for the pages that you want to add to the enclave. For a list of memory protection values, see memory protection
		/// constants. This value must not include the following constants:
		/// </para>
		/// <para>This value can include the enclave specific constants that the following table describes.</para>
		/// <para>
		/// <list type="table">
		/// <listheader>
		/// <term>Constant</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>PAGE_ENCLAVE_THREAD_CONTROL</term>
		/// <term>The page contains a thread control structure (TCS).</term>
		/// </item>
		/// <item>
		/// <term>PAGE_ENCLAVE_UNVALIDATED</term>
		/// <term>
		/// The page contents that you supply are excluded from measurement with the EEXTEND instruction of the Intel Software Guard Extensions programming model.
		/// </term>
		/// </item>
		/// </list>
		/// </para>
		/// </param>
		/// <param name="lpPageInformation">
		/// A pointer to information that describes the pages that you want to add to the enclave. The lpPageInformation parameter is not used.
		/// </param>
		/// <param name="dwInfoLength">The length of the structure that the lpPageInformation parameter points to, in bytes. This value must be 0.</param>
		/// <param name="lpNumberOfBytesWritten">A pointer to a variable that receives the number of bytes that <c>LoadEnclaveData</c> copied into the enclave.</param>
		/// <param name="lpEnclaveError">
		/// An optional pointer to a variable that receives an enclave error code that is architecture-specific. The lpEnclaveError parameter is not used.
		/// </param>
		/// <returns>
		/// <para>
		/// If all of the data is loaded into the enclave successfully, the return value is nonzero. Otherwise, the return value is zero. To get extended error
		/// information, call <c>GetLastError</c>.
		/// </para>
		/// <para>For a list of common error codes, see System Error Codes. The following error codes also apply for this function.</para>
		/// <para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>ERROR_BAD_LENGTH</term>
		/// <term>The value of the dwInfoLength parameter did not match the value expected based on the value specified for the lpPageInformation parameter.</term>
		/// </item>
		/// </list>
		/// </para>
		/// </returns>
		// BOOL WINAPI LoadEnclaveData( _In_ HANDLE hProcess, _In_ LPVOID lpAddress, _In_ LPCVOID lpBuffer, _In_ SIZE_T nSize, _In_ DWORD flProtect, _In_ LPCVOID
		// lpPageInformation, _In_ DWORD dwInfoLength, _Out_ PSIZE_T lpNumberOfBytesWritten, _Out_opt_ LPDWORD lpEnclaveError); https://msdn.microsoft.com/en-us/library/windows/desktop/mt592871(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("Enclaveapi.h", MSDNShortId = "mt592871")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool LoadEnclaveData(IntPtr hProcess, IntPtr lpAddress, IntPtr lpBuffer, SizeT nSize, MEM_PROTECTION flProtect, IntPtr lpPageInformation, uint dwInfoLength, out SizeT lpNumberOfBytesWritten, out uint lpEnclaveError);

		/// <summary>Loads an image and all of its imports into an enclave.</summary>
		/// <param name="lpEnclaveAddress">The base address of the image into which to load the image.</param>
		/// <param name="lpImageName">A NULL-terminated string that contains the name of the image to load.</param>
		/// <returns><c>TRUE</c> if the function succeeds; otherwise <c>FALSE</c>. To get extended error information, call <c>GetLastError</c>.</returns>
		// BOOL WINAPI LoadEnclaveImage( _In_ LPVOID lpEnclaveAddress, _In_ LPCSTR lpImageName); https://msdn.microsoft.com/en-us/library/windows/desktop/mt844248(v=vs.85).aspx
		[DllImport(Lib.VertDll, SetLastError = true, CharSet = CharSet.Auto)]
		[PInvokeData("Enclaveapi.h", MSDNShortId = "mt844248")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool LoadEnclaveImage(IntPtr lpEnclaveAddress, string lpImageName);

		/// <summary>Ends the execution of the threads that are running within an enclave.</summary>
		/// <param name="lpAddress">The base address of the enclave in which to end the execution of the threads.</param>
		/// <param name="fWait">
		/// <c>TRUE</c> if <c>TerminateEnclave</c> should not return until all of the threads in the enclave end execution. <c>FALSE</c> if
		/// <c>TerminateEnclave</c> should return immediately.
		/// </param>
		/// <returns><c>TRUE</c> if the function succeeds; otherwise <c>FALSE</c>. To get extended error information, call <c>GetLastError</c>.</returns>
		// BOOL WINAPI TerminateEnclave( _In_ LPVOID lpAddress, _In_ BOOL fWait); https://msdn.microsoft.com/en-us/library/windows/desktop/mt844249(v=vs.85).aspx
		[DllImport(Lib.VertDll, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("Enclaveapi.h", MSDNShortId = "mt844249")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool TerminateEnclave(IntPtr lpAddress, [MarshalAs(UnmanagedType.Bool)] bool fWait);

		/// <summary>
		/// Contains architecture-specific information to use to create an enclave when the enclave type is <c>ENCLAVE_TYPE_SGX</c>, which specifies an enclave
		/// for the Intel Software Guard Extensions (SGX) architecture extension.
		/// </summary>
		// typedef struct _ENCLAVE_CREATE_INFO_SGX { UCHAR Secs[4096];} ENCLAVE_CREATE_INFO_SGX, *PENCLAVE_CREATE_INFO_SGX; https://msdn.microsoft.com/en-us/library/windows/desktop/mt592867(v=vs.85).aspx
		[PInvokeData("Winnt.h", MSDNShortId = "mt592867")]
		[StructLayout(LayoutKind.Sequential)]
		public struct ENCLAVE_CREATE_INFO_SGX
		{
			/// <summary>The SGX enclave control structure ( <c>SECS</c>) to use to create the enclave.</summary>
			[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4096)]
			public byte[] Secs;
		}

		/// <summary>
		/// Contains architecture-specific information to use to create an enclave when the enclave type is <c>ENCLAVE_TYPE_VBS</c>, which specifies a
		/// virtualization-based security (VBS) enclave.
		/// </summary>
		// typedef struct _ENCLAVE_CREATE_INFO_VBS { ULONG Flags; UCHAR OwnerID[32]; } ENCLAVE_CREATE_INFO_VBS, *PENCLAVE_CREATE_INFO_VBS; https://msdn.microsoft.com/en-us/library/windows/desktop/mt844238(v=vs.85).aspx
		[PInvokeData("Winnt.h", MSDNShortId = "mt844238")]
		[StructLayout(LayoutKind.Sequential)]
		public struct ENCLAVE_CREATE_INFO_VBS
		{
			/// <summary>
			/// <para>A flag that indicates whether the enclave permits debugging.</para>
			/// <para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>ENCLAVE_VBS_FLAG_DEBUG0x00000001</term>
			/// <term>The enclave permits debugging.</term>
			/// </item>
			/// <item>
			/// <term>0x00000000</term>
			/// <term>The enclave does not permit debugging.</term>
			/// </item>
			/// </list>
			/// </para>
			/// </summary>
			public ENCLAVE_VBS_FLAG Flags;
			/// <summary>The identifier of the owner of the enclave.</summary>
			[MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
			public byte[] OwnerID;
		}

		/// <summary>
		/// Contains architecture-specific information to use to initialize an enclave when the enclave type is <c>ENCLAVE_TYPE_SGX</c>, which specifies an
		/// enclave for the Intel Software Guard Extensions (SGX) architecture extension.
		/// </summary>
		// typedef struct _ENCLAVE_INIT_INFO_SGX { UCHAR SigStruct[1808]; UCHAR Reserved1[240]; UCHAR EInitToken[304]; UCHAR Reserved2[744];}
		// ENCLAVE_INIT_INFO_SGX, *PENCLAVE_INIT_INFO_SGX; https://msdn.microsoft.com/en-us/library/windows/desktop/mt592868(v=vs.85).aspx
		[PInvokeData("Winnt.h", MSDNShortId = "mt592868")]
		[StructLayout(LayoutKind.Sequential)]
		public struct ENCLAVE_INIT_INFO_SGX
		{
			/// <summary>
			/// The enclave signature structure ( <c>SIGSTRUCT</c>) to use to initialize the enclave. This structure specifies information about the enclave from
			/// the enclave signer.
			/// </summary>
			[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1808)]
			public byte[] SigStruct;
			/// <summary>Not used.</summary>
			[MarshalAs(UnmanagedType.ByValArray, SizeConst = 240)]
			public byte[] Reserved1;
			/// <summary>
			/// The EINIT token structure ( <c>EINITTOKEN</c>) to use to initialize the enclave. The initialization operation uses this structure to verify that
			/// the enclave has permission to start.
			/// </summary>
			[MarshalAs(UnmanagedType.ByValArray, SizeConst = 304)]
			public byte[] EInitToken;
			/// <summary>Not used.</summary>
			[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1744)]
			public byte[] Reserved2;
		}

		/// <summary>
		/// Contains architecture-specific information to use to initialize an enclave when the enclave type is <c>ENCLAVE_TYPE_VBS</c>, which specifies a
		/// virtualization-based security (VBS) enclave.
		/// </summary>
		// typedef struct ENCLAVE_INIT_INFO_VBS { ULONG Length; ULONG ThreadCount; }; https://msdn.microsoft.com/en-us/library/windows/desktop/mt844241(v=vs.85).aspx
		[PInvokeData("Winnt.h", MSDNShortId = "mt844241")]
		[StructLayout(LayoutKind.Sequential)]
		public struct ENCLAVE_INIT_INFO_VBS
		{
			/// <summary>The total length of the <c>ENCLAVE_INIT_INFO_VBS</c> structure, in bytes.</summary>
			public uint Length;
			/// <summary>
			/// Upon entry to the <c>InitializeEnclave</c> function, specifies the number of threads to create in the enclave. Upon successful return from
			/// <c>InitializeEnclave</c>, contains the number of threads the function actually created.
			/// </summary>
			public uint ThreadCount;
		}
	}
}