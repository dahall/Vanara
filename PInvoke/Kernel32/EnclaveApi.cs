namespace Vanara.PInvoke;

public static partial class Kernel32
{
	/// <summary>Enclave constant.</summary>
	public const int ENCLAVE_LONG_ID_LENGTH = 32;

	/// <summary>Enclave constant.</summary>
	public const int ENCLAVE_SHORT_ID_LENGTH = 16;

	/// <summary>Enclave constant.</summary>
	public const int IMAGE_ENCLAVE_LONG_ID_LENGTH = ENCLAVE_LONG_ID_LENGTH;

	/// <summary>Enclave constant.</summary>
	public const int IMAGE_ENCLAVE_SHORT_ID_LENGTH = ENCLAVE_SHORT_ID_LENGTH;

	/// <summary>Used by the <see cref="CallEnclave"/> function.</summary>
	/// <param name="lpThreadParameter">The thread parameter.</param>
	/// <returns>The return thread parameter.</returns>
	[PInvokeData("MinWinBase.h")]
	[UnmanagedFunctionPointer(CallingConvention.StdCall)]
	public delegate IntPtr PENCLAVE_ROUTINE(IntPtr lpThreadParameter);

	/// <summary>Flags that describe the runtime policy for the enclave.</summary>
	[PInvokeData("ntenclv.h")]
	[Flags]
	public enum ENCLAVE_FLAG : uint
	{
		/// <summary>The enclave supports debugging.</summary>
		ENCLAVE_FLAG_FULL_DEBUG_ENABLED = 0x00000001,

		/// <summary>The enclave supports dynamic debugging.</summary>
		ENCLAVE_FLAG_DYNAMIC_DEBUG_ENABLED = 0x00000002,

		/// <summary>Dynamic debugging is turned on for the enclave.</summary>
		ENCLAVE_FLAG_DYNAMIC_DEBUG_ACTIVE = 0x00000004,
	}

	/// <summary>
	/// Specifies how another enclave must be related to the enclave that calls <c>EnclaveSealData</c> for the enclave to unseal the data.
	/// </summary>
	[PInvokeData("ntenclv.h")]
	public enum ENCLAVE_SEALING_IDENTITY_POLICY
	{
		/// <summary/>
		ENCLAVE_IDENTITY_POLICY_SEAL_INVALID = 0,

		/// <summary/>
		ENCLAVE_IDENTITY_POLICY_SEAL_EXACT_CODE,

		/// <summary/>
		ENCLAVE_IDENTITY_POLICY_SEAL_SAME_PRIMARY_CODE,

		/// <summary/>
		ENCLAVE_IDENTITY_POLICY_SEAL_SAME_IMAGE,

		/// <summary/>
		ENCLAVE_IDENTITY_POLICY_SEAL_SAME_FAMILY,

		/// <summary/>
		ENCLAVE_IDENTITY_POLICY_SEAL_SAME_AUTHOR,
	}

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

		/// <summary>
		/// Supports SGX2 and SGX1 enclaves. The platform and OS support SGX2 instructions with EDMM on this platform (in addition to other
		/// SGX2 constructs).
		/// </summary>
		ENCLAVE_TYPE_SGX2 = 0x00000002,

		/// <summary>A VBS enclave.</summary>
		ENCLAVE_TYPE_VBS = 0x00000010,
	}

	/// <summary>
	/// Calls a function within an enclave. <c>CallEnclave</c> can also be called within an enclave to call a function outside of the enclave.
	/// </summary>
	/// <param name="lpRoutine">The address of the function that you want to call.</param>
	/// <param name="lpParameter">The parameter than you want to pass to the function.</param>
	/// <param name="fWaitForThread">
	/// <para>
	/// <c>TRUE</c> if the call to the specified function should block execution until an idle enclave thread becomes available when no
	/// idle enclave thread is available. <c>FALSE</c> if the call to the specified function should fail when no idle enclave thread is available.
	/// </para>
	/// <para>This parameter is ignored when you use <c>CallEnclave</c> within an enclave to call a function that is not in any enclave.</para>
	/// </param>
	/// <param name="lpReturnValue">The return value of the function, if it is called successfully.</param>
	/// <returns>
	/// <c>TRUE</c> if the specified function was called successfully; otherwise <c>FALSE</c>. To get extended error information, call <c>GetLastError</c>.
	/// </returns>
	// BOOL WINAPI CallEnclave( _In_ LPENCLAVE_ROUTINE lpRoutine, _In_ LPVOID lpParameter, _In_ BOOL fWaitForThread, _Out_ LPVOID
	// *lpReturnValue); https://msdn.microsoft.com/en-us/library/windows/desktop/mt844231(v=vs.85).aspx
	[DllImport(Lib.VertDll, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("Enclaveapi.h", MSDNShortId = "mt844231")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool CallEnclave(PENCLAVE_ROUTINE lpRoutine, IntPtr lpParameter, [MarshalAs(UnmanagedType.Bool)] bool fWaitForThread, out IntPtr lpReturnValue);

	/// <summary>
	/// Creates a new uninitialized enclave. An enclave is an isolated region of code and data within the address space for an
	/// application. Only code that runs within the enclave can access data within the same enclave.
	/// </summary>
	/// <param name="hProcess">A handle to the process for which you want to create an enclave.</param>
	/// <param name="lpAddress">
	/// The preferred base address of the enclave. Specify <c>NULL</c> to have the operating system assign the base address.
	/// </param>
	/// <param name="dwSize">
	/// The size of the enclave that you want to create, including the size of the code that you will load into the enclave, in bytes.
	/// </param>
	/// <param name="dwInitialCommittment">
	/// <para>The amount of memory to commit for the enclave, in bytes.</para>
	/// <para>
	/// If the amount of enclave memory available is not sufficient to commit this number of bytes, enclave creation fails. Any memory
	/// that remains unused when you initialize the enclave by calling <c>InitializeEnclave</c> is returned to the list of free pages.
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
	/// The length of the structure that the lpEnclaveInformation parameter points to, in bytes. For the <c>ENCLAVE_TYPE_SGX</c> enclave
	/// type, this value must be 4096. For the <c>ENCLAVE_TYPE_VBS</c> enclave type, this value must be , which is 36 bytes.
	/// </param>
	/// <param name="lpEnclaveError">
	/// An optional pointer to a variable that receives an enclave error code that is architecture-specific. For the
	/// <c>ENCLAVE_TYPE_SGX</c> and <c>ENCLAVE_TYPE_VBS</c> enclave types, the lpEnclaveError parameter is not used.
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
	/// <term>
	/// The value of the dwInfoLength parameter did not match the value expected based on the value specified for the
	/// lpEnclaveInformation parameter.
	/// </term>
	/// </item>
	/// </list>
	/// </para>
	/// </returns>
	// PVOID WINAPI CreateEnclave( _In_ HANDLE hProcess, _In_opt_ LPVOID lpAddress, _In_ SizeT dwSize, _In_ SizeT dwInitialCommittment,
	// _In_ DWORD flEnclaveType, _In_ LPCVOID lpEnclaveInformation, _In_ DWORD dwInfoLength, _Out_opt_ LPDWORD lpEnclaveError); https://msdn.microsoft.com/en-us/library/windows/desktop/mt592866(v=vs.85).aspx
	[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("Enclaveapi.h", MSDNShortId = "mt592866")]
	[return: AddAsCtor]
	public static extern SafeEnclaveHandle CreateEnclave(HPROCESS hProcess, [In, Optional] IntPtr lpAddress, SizeT dwSize, [Optional] SizeT dwInitialCommittment,
		EnclaveType flEnclaveType, in ENCLAVE_CREATE_INFO_SGX lpEnclaveInformation, uint dwInfoLength, out uint lpEnclaveError);

	/// <summary>
	/// Creates a new uninitialized enclave. An enclave is an isolated region of code and data within the address space for an
	/// application. Only code that runs within the enclave can access data within the same enclave.
	/// </summary>
	/// <param name="hProcess">A handle to the process for which you want to create an enclave.</param>
	/// <param name="lpAddress">
	/// The preferred base address of the enclave. Specify <c>NULL</c> to have the operating system assign the base address.
	/// </param>
	/// <param name="dwSize">
	/// The size of the enclave that you want to create, including the size of the code that you will load into the enclave, in bytes.
	/// </param>
	/// <param name="dwInitialCommittment">
	/// <para>The amount of memory to commit for the enclave, in bytes.</para>
	/// <para>
	/// If the amount of enclave memory available is not sufficient to commit this number of bytes, enclave creation fails. Any memory
	/// that remains unused when you initialize the enclave by calling <c>InitializeEnclave</c> is returned to the list of free pages.
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
	/// The length of the structure that the lpEnclaveInformation parameter points to, in bytes. For the <c>ENCLAVE_TYPE_SGX</c> enclave
	/// type, this value must be 4096. For the <c>ENCLAVE_TYPE_VBS</c> enclave type, this value must be , which is 36 bytes.
	/// </param>
	/// <param name="lpEnclaveError">
	/// An optional pointer to a variable that receives an enclave error code that is architecture-specific. For the
	/// <c>ENCLAVE_TYPE_SGX</c> and <c>ENCLAVE_TYPE_VBS</c> enclave types, the lpEnclaveError parameter is not used.
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
	/// <term>
	/// The value of the dwInfoLength parameter did not match the value expected based on the value specified for the
	/// lpEnclaveInformation parameter.
	/// </term>
	/// </item>
	/// </list>
	/// </para>
	/// </returns>
	// PVOID WINAPI CreateEnclave( _In_ HANDLE hProcess, _In_opt_ LPVOID lpAddress, _In_ SizeT dwSize, _In_ SizeT dwInitialCommittment,
	// _In_ DWORD flEnclaveType, _In_ LPCVOID lpEnclaveInformation, _In_ DWORD dwInfoLength, _Out_opt_ LPDWORD lpEnclaveError); https://msdn.microsoft.com/en-us/library/windows/desktop/mt592866(v=vs.85).aspx
	[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("Enclaveapi.h", MSDNShortId = "mt592866")]
	[return: AddAsCtor]
	public static extern SafeEnclaveHandle CreateEnclave(HPROCESS hProcess, [In, Optional] IntPtr lpAddress, SizeT dwSize, [Optional] SizeT dwInitialCommittment,
		EnclaveType flEnclaveType, in ENCLAVE_CREATE_INFO_VBS lpEnclaveInformation, uint dwInfoLength, out uint lpEnclaveError);

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
	/// The execution of threads running with the enclave was not ended, because either TerminateEnclave was not called, or the execution
	/// of the threads has not yet ended in response to an earlier call to TerminateEnclave.
	/// </term>
	/// </item>
	/// </list>
	/// </para>
	/// </returns>
	// BOOL WINAPI DeleteEnclave( _In_ LPVOID lpAddress); https://msdn.microsoft.com/en-us/library/windows/desktop/mt844232(v=vs.85).aspx
	[DllImport(Lib.KernelBase, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("Enclaveapi.h", MSDNShortId = "mt844232")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool DeleteEnclave(IntPtr lpAddress);

	/// <summary>
	/// Gets an enclave attestation report that describes the current enclave and is signed by the authority that is responsible for the
	/// type of the enclave.
	/// </summary>
	/// <param name="EnclaveData">
	/// A pointer to a 64-byte buffer of data that the enclave wants to insert into its signed report. For example, this buffer could
	/// include a 256-bit nonce that the relying party supplied, followed by a SHA-256 hash of additional data that the enclave wants to
	/// convey, such as a public key that corresponds to a private key that the enclave owns. If this parameter is NULL, the
	/// corresponding field of the report is filled with zeroes.
	/// </param>
	/// <param name="Report">
	/// A pointer to a buffer where the report should be placed. This report may be stored either within the address range of the enclave
	/// or within the address space of the host process. Specify NULL to indicate that only the size of the buffer required for the
	/// output should be calculated, and not the report itself.
	/// </param>
	/// <param name="BufferSize">
	/// The size of the buffer to which the Report parameter points. If Report is NULL, BufferSize must be zero. If Report is not NULL,
	/// and if the size of the report is larger than this value, an error is returned.
	/// </param>
	/// <param name="OutputSize">A pointer to a variable that receives the size of the report.</param>
	/// <returns>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
	/// <remarks>
	/// <para><c>EnclaveGetAttestationReport</c> must be called from within an enclave.</para>
	/// <para>
	/// <c>EnclaveGetAttestationReport</c> is not currently supported for enclaves with a type of <c>ENCLAVE_TYPE_SGX</c>. For VBS
	/// enclaves, the report that <c>EnclaveGetAttestationReport</c> gets is signed by using a VBS-specific key.
	/// </para>
	/// <para>
	/// The enclave attestation report contains the identity of all code loaded into the enclave, as well as policies that control how
	/// the enclave is running, such as whether the enclave is running with debugger access active. The report also includes a small
	/// amount of information that the enclave generated to use in a key-exchange protocol.
	/// </para>
	/// <para>The report that <c>EnclaveGetAttestationReport</c> generates consists of the following items:</para>
	/// <list type="bullet">
	/// <item>
	/// <term>A VBS_ENCLAVE_REPORT_PKG_HEADER structure</term>
	/// </item>
	/// <item>
	/// <term>A signed statement that consist of the following items:</term>
	/// </item>
	/// <item>
	/// <term>A signature</term>
	/// </item>
	/// </list>
	/// <para>
	/// The enclave attestation report provide proof that specific code is running with an enclave. If a validating entity also obtains
	/// proof that the host system is running with VBS turned on, that entity can use that proof in conjunction with the enclave
	/// attestation report to verify that a specific enclave, populated with specific code, has been loaded.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/winenclaveapi/nf-winenclaveapi-enclavegetattestationreport HRESULT
	// EnclaveGetAttestationReport( const UINT8 [ENCLAVE_REPORT_DATA_LENGTH] EnclaveData, PVOID Report, UINT32 BufferSize, UINT32
	// *OutputSize );
	[DllImport(Lib.VertDll, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("winenclaveapi.h", MSDNShortId = "FEE8F05B-540F-4C10-A90C-55607A4E9293")]
	public static extern HRESULT EnclaveGetAttestationReport([In, Optional] byte[]? EnclaveData, [Optional, SizeDef(nameof(BufferSize), SizingMethod.Query, OutVarName = nameof(OutputSize))] IntPtr Report, [Optional] uint BufferSize, out uint OutputSize);

	/// <summary>Gets information about the currently executing enclave.</summary>
	/// <param name="InformationSize">
	/// The size of the ENCLAVE_INFORMATION structure that the EnclaveInformation parameter points to, in bytes.
	/// </param>
	/// <param name="EnclaveInformation">Information about the currently executing enclave.</param>
	/// <returns>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
	/// <remarks>
	/// <c>EnclaveGetEnclaveInformation</c> must be called from within an enclave, and is only supported within enclaves that have the
	/// <c>ENCLAVE_TYPE_VBS</c> enclave type.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/winenclaveapi/nf-winenclaveapi-enclavegetenclaveinformation HRESULT
	// EnclaveGetEnclaveInformation( UINT32 InformationSize, ENCLAVE_INFORMATION *EnclaveInformation );
	[DllImport(Lib.VertDll, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("winenclaveapi.h", MSDNShortId = "26349C3C-4B73-430C-B002-ED262DB0304F")]
	public static extern HRESULT EnclaveGetEnclaveInformation(uint InformationSize, ref ENCLAVE_INFORMATION EnclaveInformation);

	/// <summary>Generates an encrypted binary large object (blob) from unencypted data.</summary>
	/// <param name="DataToEncrypt">
	/// A pointer to the data that you want to seal. This data can be stored either within the address range of the enclave or within the
	/// address range of the host process.
	/// </param>
	/// <param name="DataToEncryptSize">The size of the data that you want to seal, in bytes.</param>
	/// <param name="IdentityPolicy">
	/// A value that specifies how another enclave must be related to the enclave that calls <c>EnclaveSealData</c> for the enclave to
	/// unseal the data.
	/// </param>
	/// <param name="RuntimePolicy">
	/// <para>
	/// A value that indicates whether an enclave that runs with debugging turned on is permitted to unseal the data the this call to
	/// <c>EnclaveSealData</c> seals.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>ENCLAVE_RUNTIME_POLICY_ALLOW_FULL_DEBUG 1</term>
	/// <term>
	/// If specified, indicates that an enclave that runs with debugging turned on is permitted to unseal the data. If not specified,
	/// indicates that an enclave that runs with debugging turned on is not permitted to unseal the data. This flag is automatically
	/// included if the calling enclave is running with debugging turned on.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ENCLAVE_RUNTIME_POLICY_ALLOW_DYNAMIC_DEBUG 2</term>
	/// <term>
	/// If specified, indicates that an enclave that runs with dynamic debugging turned on is permitted to unseal the data. If not
	/// specified, indicates that an enclave that runs with dynamic debugging turned on is not permitted to unseal the data. This flag is
	/// automatically included if the calling enclave is running with dynamic debugging turned on
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="ProtectedBlob">
	/// A pointer to a buffer where the sealed data should be placed. This data may be stored either within the address range of the
	/// enclave or within the address space of the host process. If this parameter is NULL, only the size of the protected blob is calculated.
	/// </param>
	/// <param name="BufferSize">
	/// A pointer to a variable that holds the size of the buffer to which the ProtectedBlob parameter points. If ProtectedBlob is NULL,
	/// this value must be zero. If ProtectedBlob is not NULL, and if the size of the encrypted data is larger than this value, an error occurs.
	/// </param>
	/// <param name="ProtectedBlobSize">A pointer to a variable that receives the actual size of the encrypted blob.</param>
	/// <returns>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
	/// <remarks>
	/// <c>EnclaveSealData</c> must be called from within an enclave, and is only supported within enclaves that have the
	/// <c>ENCLAVE_TYPE_VBS</c> enclave type.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/winenclaveapi/nf-winenclaveapi-enclavesealdata HRESULT EnclaveSealData( const
	// VOID *DataToEncrypt, UINT32 DataToEncryptSize, ENCLAVE_SEALING_IDENTITY_POLICY IdentityPolicy, UINT32 RuntimePolicy, PVOID
	// ProtectedBlob, UINT32 BufferSize, UINT32 *ProtectedBlobSize );
	[DllImport(Lib.VertDll, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("winenclaveapi.h", MSDNShortId = "C5711D43-F0B4-43C6-B0DB-D65622851384")]
	public static extern HRESULT EnclaveSealData([In, SizeDef(nameof(DataToEncryptSize))] IntPtr DataToEncrypt, uint DataToEncryptSize, ENCLAVE_SEALING_IDENTITY_POLICY IdentityPolicy,
		uint RuntimePolicy, [Optional, SizeDef(nameof(BufferSize), SizingMethod.Query, OutVarName = nameof(ProtectedBlobSize))] IntPtr ProtectedBlob, [Optional] uint BufferSize, out uint ProtectedBlobSize);

	/// <summary>Decrypts an encrypted binary large object (blob).</summary>
	/// <param name="ProtectedBlob">
	/// A pointer to the sealed data to unseal. This data may be stored either within the address range of the enclave or within the
	/// address space of the host process
	/// </param>
	/// <param name="ProtectedBlobSize">The size of the sealed data to unseal, in bytes.</param>
	/// <param name="DecryptedData">
	/// A pointer to a buffer where the unencrypted data should be placed. This data may be stored either within the address range of the
	/// enclave or within the address space of the host process. If this parameter is NULL, only the size of the decrypted data is calculated.
	/// </param>
	/// <param name="BufferSize">
	/// The size of the buffer to which the DecryptedData parameter points, in bytes. If DecryptedData is NULL, BufferSize must be zero.
	/// If DecryptedData is not NULL, and if the size of the decrypted data is larger than this value, an error is returned.
	/// </param>
	/// <param name="DecryptedDataSize">A pointer to a variable that receives the actual size of the decrypted data, in bytes.</param>
	/// <param name="SealingIdentity">
	/// An optional pointer to a buffer that should be filled with the identity of the enclave that sealed the data. If this pointer is
	/// NULL, the identity of the sealing enclave is not returned.
	/// </param>
	/// <param name="UnsealingFlags">
	/// <para>
	/// An optional pointer to a variable that receives zero or more of the following flags that describe the encrypted binary large object.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>ENCLAVE_UNSEAL_FLAG_STALE_KEY 1</term>
	/// <term>
	/// The data was encrypted with a stale key. Sealing keys are rotated when required for security, and the system can only maintain a
	/// fixed number of recently known keys. An enclave that determines that data was encrypted with a stale key should reencrypt the
	/// data with a current key to minimize the chances that the key used to encrypt the data is no longer maintained in the key list.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <returns>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
	/// <remarks>
	/// <para>
	/// The enclave that calls <c>EnclaveUnsealData</c> must meet the criteria that correspond to the value of the
	/// ENCLAVE_SEALING_IDENTITY_POLICY that was specified by the enclave that sealed the data by calling EnclaveSealData.
	/// </para>
	/// <para>
	/// <c>EnclaveUnsealData</c> must be called from within an enclave, and is only supported within enclaves that have the
	/// <c>ENCLAVE_TYPE_VBS</c> enclave type.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/winenclaveapi/nf-winenclaveapi-enclaveunsealdata HRESULT EnclaveUnsealData(
	// const VOID *ProtectedBlob, UINT32 ProtectedBlobSize, PVOID DecryptedData, UINT32 BufferSize, UINT32 *DecryptedDataSize,
	// ENCLAVE_IDENTITY *SealingIdentity, UINT32 *UnsealingFlags );
	[DllImport(Lib.VertDll, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("winenclaveapi.h", MSDNShortId = "DDBDBEDE-E7EA-43B0-B2C7-B85D75EF3EB0")]
	public static extern HRESULT EnclaveUnsealData(IntPtr ProtectedBlob, uint ProtectedBlobSize, [Optional] IntPtr DecryptedData, uint BufferSize,
		out uint DecryptedDataSize, out ENCLAVE_IDENTITY SealingIdentity, out uint UnsealingFlags);

	/// <summary>Verifies an attestation report that was generated on the current system.</summary>
	/// <param name="EnclaveType">The type of the enclave for which the report was generated. Must be <c>ENCLAVE_TYPE_VBS</c>.</param>
	/// <param name="Report">
	/// A pointer to a buffer that stores the report. This report may be stored either within the address range of the enclave or within
	/// the address space of the host process.
	/// </param>
	/// <param name="ReportSize">The size of the report, in bytes.</param>
	/// <returns>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
	/// <remarks>
	/// <para>
	/// This function is used if two enclaves run on the same system and need to establish a secure channel between one another. When you
	/// call <c>EnclaveVerifyAttestationReport</c> from a virtualization-based security (VBS) enclave, you can only use
	/// <c>EnclaveVerifyAttestationReport</c> to validate an attestation report that another VBS enclave generated.
	/// </para>
	/// <para>
	/// <c>EnclaveVerifyAttestationReport</c> must be called from within an enclave, and is only supported within enclaves that have the
	/// <c>ENCLAVE_TYPE_VBS</c> enclave type.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/winenclaveapi/nf-winenclaveapi-enclaveverifyattestationreport HRESULT
	// EnclaveVerifyAttestationReport( UINT32 EnclaveType, const VOID *Report, UINT32 ReportSize );
	[DllImport(Lib.VertDll, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("winenclaveapi.h", MSDNShortId = "D74F89FB-9F06-4AA1-9E2E-C9265B3C5B44")]
	public static extern HRESULT EnclaveVerifyAttestationReport(uint EnclaveType, IntPtr Report, uint ReportSize);

	/// <summary>Initializes an enclave that you created and loaded with data.</summary>
	/// <param name="hProcess">A handle to the process for which the enclave was created.</param>
	/// <param name="lpAddress">Any address within the enclave.</param>
	/// <param name="lpEnclaveInformation">
	/// <para>A pointer to architecture-specific information to use to initialize the enclave.</para>
	/// <para>For the <c>ENCLAVE_TYPE_SGX</c> enclave type, specify a pointer to an <c>ENCLAVE_INIT_INFO_SGX</c> structure.</para>
	/// <para>For the <c>ENCLAVE_TYPE_VBS</c> enclave type, specify a pointer to an <c>ENCLAVE_INIT_INFO_VBS</c> structure.</para>
	/// </param>
	/// <param name="dwInfoLength">
	/// The length of the structure that the lpEnclaveInformation parameter points to, in bytes. For the <c>ENCLAVE_TYPE_SGX</c> enclave
	/// type, this value must be 4096. For the <c>ENCLAVE_TYPE_VBS</c> enclave type, this value must be , which is 8 bytes.
	/// </param>
	/// <param name="lpEnclaveError">
	/// <para>An optional pointer to a variable that receives an enclave error code that is architecture-specific.</para>
	/// <para>
	/// For the <c>ENCLAVE_TYPE_SGX</c> enclave type, the lpEnclaveError parameter contains the error that the EINIT instruction
	/// generated if the function fails and . <c>GetLastError</c> returns <c>ERROR_ENCLAVE_FAILURE</c>.
	/// </para>
	/// <para>For the <c>ENCLAVE_TYPE_VBS</c> enclave type, the lpEnclaveError parameter is not used.</para>
	/// </param>
	/// <returns>
	/// <para>
	/// If the function succeeds, the return value is nonzero. If the function fails, the return value is zero. To get extended error
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
	/// <term>ERROR_ENCLAVE_FAILURE</term>
	/// <term>
	/// An failure specific to the underlying enclave architecture occurred. The value for the lpEnclaveError parameter contains the
	/// architecture-specific error. For the ENCLAVE_TYPE_SGX enclave type, the EINIT instruction that the ENCLAVE_INIT_INFO_SGX
	/// structure specified generated an error. The value of the lpEnclaveError parameter contains the error that the instruction generated.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ERROR_BAD_LENGTH</term>
	/// <term>
	/// The value of the dwInfoLength parameter did not match the value expected based on the value specified for the
	/// lpEnclaveInformation parameter.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ERROR_RETRY</term>
	/// <term>The processor was not able to initialize the enclave in a timely fashion. Try to initialize the enclave again.</term>
	/// </item>
	/// </list>
	/// </para>
	/// </returns>
	// BOOL WINAPI InitializeEnclave( _In_ HANDLE hProcess, _In_ LPVOID lpAddress, _In_ LPVOID lpEnclaveInformation, _In_ DWORD
	// dwInfoLength, _In_ LPDWORD lpEnclaveError); https://msdn.microsoft.com/en-us/library/windows/desktop/mt592869(v=vs.85).aspx
	[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("Enclaveapi.h", MSDNShortId = "mt592869")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool InitializeEnclave(HPROCESS hProcess, IntPtr lpAddress, in ENCLAVE_INIT_INFO_SGX lpEnclaveInformation, uint dwInfoLength, ref uint lpEnclaveError);

	/// <summary>Initializes an enclave that you created and loaded with data.</summary>
	/// <param name="hProcess">A handle to the process for which the enclave was created.</param>
	/// <param name="lpAddress">Any address within the enclave.</param>
	/// <param name="lpEnclaveInformation">
	/// <para>A pointer to architecture-specific information to use to initialize the enclave.</para>
	/// <para>For the <c>ENCLAVE_TYPE_SGX</c> enclave type, specify a pointer to an <c>ENCLAVE_INIT_INFO_SGX</c> structure.</para>
	/// <para>For the <c>ENCLAVE_TYPE_VBS</c> enclave type, specify a pointer to an <c>ENCLAVE_INIT_INFO_VBS</c> structure.</para>
	/// </param>
	/// <param name="dwInfoLength">
	/// The length of the structure that the lpEnclaveInformation parameter points to, in bytes. For the <c>ENCLAVE_TYPE_SGX</c> enclave
	/// type, this value must be 4096. For the <c>ENCLAVE_TYPE_VBS</c> enclave type, this value must be , which is 8 bytes.
	/// </param>
	/// <param name="lpEnclaveError">
	/// <para>An optional pointer to a variable that receives an enclave error code that is architecture-specific.</para>
	/// <para>
	/// For the <c>ENCLAVE_TYPE_SGX</c> enclave type, the lpEnclaveError parameter contains the error that the EINIT instruction
	/// generated if the function fails and . <c>GetLastError</c> returns <c>ERROR_ENCLAVE_FAILURE</c>.
	/// </para>
	/// <para>For the <c>ENCLAVE_TYPE_VBS</c> enclave type, the lpEnclaveError parameter is not used.</para>
	/// </param>
	/// <returns>
	/// <para>
	/// If the function succeeds, the return value is nonzero. If the function fails, the return value is zero. To get extended error
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
	/// <term>ERROR_ENCLAVE_FAILURE</term>
	/// <term>
	/// An failure specific to the underlying enclave architecture occurred. The value for the lpEnclaveError parameter contains the
	/// architecture-specific error. For the ENCLAVE_TYPE_SGX enclave type, the EINIT instruction that the ENCLAVE_INIT_INFO_SGX
	/// structure specified generated an error. The value of the lpEnclaveError parameter contains the error that the instruction generated.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ERROR_BAD_LENGTH</term>
	/// <term>
	/// The value of the dwInfoLength parameter did not match the value expected based on the value specified for the
	/// lpEnclaveInformation parameter.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ERROR_RETRY</term>
	/// <term>The processor was not able to initialize the enclave in a timely fashion. Try to initialize the enclave again.</term>
	/// </item>
	/// </list>
	/// </para>
	/// </returns>
	// BOOL WINAPI InitializeEnclave( _In_ HANDLE hProcess, _In_ LPVOID lpAddress, _In_ LPVOID lpEnclaveInformation, _In_ DWORD
	// dwInfoLength, _In_ LPDWORD lpEnclaveError); https://msdn.microsoft.com/en-us/library/windows/desktop/mt592869(v=vs.85).aspx
	[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("Enclaveapi.h", MSDNShortId = "mt592869")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool InitializeEnclave(HPROCESS hProcess, IntPtr lpAddress, in ENCLAVE_INIT_INFO_VBS lpEnclaveInformation, uint dwInfoLength, ref uint lpEnclaveError);

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
	/// If the function succeeds, the return value is nonzero. If the function fails, the return value is zero. To get extended error
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
	/// The memory protection to use for the pages that you want to add to the enclave. For a list of memory protection values, see
	/// memory protection constants. This value must not include the following constants:
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
	/// The page contents that you supply are excluded from measurement with the EEXTEND instruction of the Intel Software Guard
	/// Extensions programming model.
	/// </term>
	/// </item>
	/// </list>
	/// </para>
	/// </param>
	/// <param name="lpPageInformation">
	/// A pointer to information that describes the pages that you want to add to the enclave. The lpPageInformation parameter is not used.
	/// </param>
	/// <param name="dwInfoLength">
	/// The length of the structure that the lpPageInformation parameter points to, in bytes. This value must be 0.
	/// </param>
	/// <param name="lpNumberOfBytesWritten">
	/// A pointer to a variable that receives the number of bytes that <c>LoadEnclaveData</c> copied into the enclave.
	/// </param>
	/// <param name="lpEnclaveError">
	/// An optional pointer to a variable that receives an enclave error code that is architecture-specific. The lpEnclaveError parameter
	/// is not used.
	/// </param>
	/// <returns>
	/// <para>
	/// If all of the data is loaded into the enclave successfully, the return value is nonzero. Otherwise, the return value is zero. To
	/// get extended error information, call <c>GetLastError</c>.
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
	/// <term>
	/// The value of the dwInfoLength parameter did not match the value expected based on the value specified for the lpPageInformation parameter.
	/// </term>
	/// </item>
	/// </list>
	/// </para>
	/// </returns>
	// BOOL WINAPI LoadEnclaveData( _In_ HANDLE hProcess, _In_ LPVOID lpAddress, _In_ LPCVOID lpBuffer, _In_ SizeT nSize, _In_ DWORD
	// flProtect, _In_ LPCVOID lpPageInformation, _In_ DWORD dwInfoLength, _Out_ PSIZE_T lpNumberOfBytesWritten, _Out_opt_ LPDWORD
	// lpEnclaveError); https://msdn.microsoft.com/en-us/library/windows/desktop/mt592871(v=vs.85).aspx
	[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("Enclaveapi.h", MSDNShortId = "mt592871")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool LoadEnclaveData(HPROCESS hProcess, IntPtr lpAddress, [Optional] IntPtr lpBuffer, [Optional] SizeT nSize, MEM_PROTECTION flProtect,
		[Optional] IntPtr lpPageInformation, [Optional] uint dwInfoLength, out SizeT lpNumberOfBytesWritten, out uint lpEnclaveError);

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

	/// <summary>Copies data from an untrusted address (outside of the enclave) into the enclave.</summary>
	/// <param name="EnclaveAddress">An address within the enclave to which to copy data.</param>
	/// <param name="UnsecureAddress">An address outside of the enclave from which to copy data.</param>
	/// <param name="NumberOfBytes">The number of bytes to copy.</param>
	/// <returns>
	/// An HRESULT value that indicates success or failure. The function returns <c>S_OK</c> if the copy operation was successful. Otherwise,
	/// it returns an HRESULT error code.
	/// </returns>
	/// <remarks>
	/// Note that the <c>EnclaveCopyOutOfEnclave</c> and <b>EnclaveCopyIntoEnclave</b> APIs will still continue to work (and access the
	/// address space of the containing process) even when access is restricted using <c>EnclaveRestrictContainingProcessAccess</c>.
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/winenclaveapi/nf-winenclaveapi-enclavecopyintoenclave HRESULT
	// EnclaveCopyIntoEnclave( VOID *EnclaveAddress, const VOID *UnsecureAddress, SizeT NumberOfBytes );
	[PInvokeData("winenclaveapi.h", MSDNShortId = "NF:winenclaveapi.EnclaveCopyIntoEnclave")]
	[DllImport(Lib.VertDll, SetLastError = true, ExactSpelling = true)]
	public static extern HRESULT EnclaveCopyIntoEnclave([In] IntPtr EnclaveAddress, [In] IntPtr UnsecureAddress, SizeT NumberOfBytes);

	/// <summary>Copies data from the enclave to an untrusted address (outside of the enclave).</summary>
	/// <param name="UnsecureAddress">An address outside of the enclave to which to copy data.</param>
	/// <param name="EnclaveAddress">An address within the enclave from which to copy data.</param>
	/// <param name="NumberOfBytes">The number of bytes to copy.</param>
	/// <returns>
	/// An HRESULT value that indicates success or failure. The function returns <c>S_OK</c> if the copy operation was successful. Otherwise,
	/// it returns an HRESULT error code.
	/// </returns>
	/// <remarks>
	/// Note that the <b>EnclaveCopyOutOfEnclave</b> and <c>EnclaveCopyIntoEnclave</c> APIs will still continue to work (and access the
	/// address space of the containing process) even when access is restricted using <c>EnclaveRestrictContainingProcessAccess</c>.
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/winenclaveapi/nf-winenclaveapi-enclavecopyoutofenclave HRESULT
	// EnclaveCopyOutOfEnclave( VOID *UnsecureAddress, const VOID *EnclaveAddress, SizeT NumberOfBytes );
	[PInvokeData("winenclaveapi.h", MSDNShortId = "NF:winenclaveapi.EnclaveCopyOutOfEnclave")]
	[DllImport(Lib.VertDll, SetLastError = true, ExactSpelling = true)]
	public static extern HRESULT EnclaveCopyOutOfEnclave([In] IntPtr UnsecureAddress, [In] IntPtr EnclaveAddress, SizeT NumberOfBytes);

	/// <summary>
	/// Restricts (or restores) access by an enclave to the address space of its containing process. This policy applies to all threads in
	/// the enclave.
	/// </summary>
	/// <param name="RestrictAccess">
	/// Set this value to <c>TRUE</c> if the process should restrict (i.e. disable) access to the address space of the containing process.
	/// Otherwise, set it to <c>FALSE</c> if restrictions should be relaxed, and the containing address space should be accessible.
	/// </param>
	/// <param name="PreviouslyRestricted">A pointer to a variable that will receive the previous state of the restriction.</param>
	/// <returns>An <c>HRESULT</c> value that indicates the success or failure of the operation.</returns>
	/// <remarks>
	/// <para>
	/// Note that the <c>EnclaveCopyOutOfEnclave</c> and <c>EnclaveCopyIntoEnclave</c> APIs will still continue to work (and access the
	/// address space of the containing process) even when access is restricted using <b>EnclaveRestrictContainingProcessAccess</b>.
	/// </para>
	/// <para>
	/// Access to the containing process's address space can also be restricted by setting the <c>IMAGE_ENCLAVE_POLICY_STRICT_MEMORY</c> flag
	/// in the enclave's image configuration. The <b>EnclaveRestrictContainingProcessAccess</b> API can be used to change this policy at runtime.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/winenclaveapi/nf-winenclaveapi-enclaverestrictcontainingprocessaccess HRESULT
	// EnclaveRestrictContainingProcessAccess( BOOL RestrictAccess, PBOOL PreviouslyRestricted );
	[PInvokeData("winenclaveapi.h", MSDNShortId = "NF:winenclaveapi.EnclaveRestrictContainingProcessAccess")]
	[DllImport(Lib.VertDll, SetLastError = true, ExactSpelling = true)]
	public static extern HRESULT EnclaveRestrictContainingProcessAccess([MarshalAs(UnmanagedType.Bool)] bool RestrictAccess,
		[MarshalAs(UnmanagedType.Bool)] out bool PreviouslyRestricted);

	/// <summary>
	/// Contains architecture-specific information to use to create an enclave when the enclave type is <c>ENCLAVE_TYPE_SGX</c>, which
	/// specifies an enclave for the Intel Software Guard Extensions (SGX) architecture extension.
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
	/// Contains architecture-specific information to use to create an enclave when the enclave type is <c>ENCLAVE_TYPE_VBS</c>, which
	/// specifies a virtualization-based security (VBS) enclave.
	/// </summary>
	// typedef struct _ENCLAVE_CREATE_INFO_VBS { ULONG Flags; UCHAR OwnerID[32]; } ENCLAVE_CREATE_INFO_VBS, *PENCLAVE_CREATE_INFO_VBS; https://msdn.microsoft.com/en-us/library/windows/desktop/mt844238(v=vs.85).aspx
	[PInvokeData("Winnt.h", MSDNShortId = "mt844238")]
	[StructLayout(LayoutKind.Sequential)]
	public struct ENCLAVE_CREATE_INFO_VBS
	{
		const int oidlen = 32;

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

		private unsafe fixed byte _OwnerID[oidlen];

		/// <summary>Initializes a new instance of the <see cref="ENCLAVE_CREATE_INFO_VBS"/> struct.</summary>
		/// <param name="flags">A flag that indicates whether the enclave permits debugging.</param>
		/// <param name="ownerId">The identifier of the owner of the enclave.</param>
		public ENCLAVE_CREATE_INFO_VBS(ENCLAVE_VBS_FLAG flags, Span<byte> ownerId) : this()
		{
			Flags = flags;
			OwnerID = ownerId;
		}

		/// <summary>The identifier of the owner of the enclave.</summary>
		public Span<byte> OwnerID
		{
			get { unsafe { fixed (byte* p = _OwnerID) { return new Span<byte>(p, oidlen); } } }
			set { if (value.Length > oidlen) throw new ArgumentOutOfRangeException(); unsafe { fixed (byte* p = _OwnerID) { value.CopyTo(new Span<byte>(p, oidlen)); } } }
		}
	}

	/// <summary>Describes the identity of the primary module of an enclave.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/ntenclv/ns-ntenclv-enclave_identity typedef struct ENCLAVE_IDENTITY { UINT8
	// OwnerId[IMAGE_ENCLAVE_LONG_ID_LENGTH]; UINT8 UniqueId[IMAGE_ENCLAVE_LONG_ID_LENGTH]; UINT8 AuthorId[IMAGE_ENCLAVE_LONG_ID_LENGTH];
	// UINT8 FamilyId[IMAGE_ENCLAVE_SHORT_ID_LENGTH]; UINT8 ImageId[IMAGE_ENCLAVE_SHORT_ID_LENGTH]; UINT32 EnclaveSvn; UINT32
	// SecureKernelSvn; UINT32 PlatformSvn; UINT32 Flags; UINT32 SigningLevel; UINT32 EnclaveType; } ENCLAVE_IDENTITY;
	[PInvokeData("ntenclv.h", MSDNShortId = "D584D824-3C86-4BBB-9086-6DBE0290E0A4")]
	[StructLayout(LayoutKind.Sequential)]
	public struct ENCLAVE_IDENTITY
	{
		/// <summary>The identifier of the owner for the enclave.</summary>
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = IMAGE_ENCLAVE_LONG_ID_LENGTH)]
		public byte[] OwnerId;

		/// <summary>The unique identifier of the primary module for the enclave.</summary>
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = IMAGE_ENCLAVE_LONG_ID_LENGTH)]
		public byte[] UniqueId;

		/// <summary>The author identifier of the primary module for the enclave.</summary>
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = IMAGE_ENCLAVE_LONG_ID_LENGTH)]
		public byte[] AuthorId;

		/// <summary>The family identifier of the primary module for the enclave.</summary>
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = IMAGE_ENCLAVE_SHORT_ID_LENGTH)]
		public byte[] FamilyId;

		/// <summary>The image identifier of the primary module for the enclave.</summary>
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = IMAGE_ENCLAVE_SHORT_ID_LENGTH)]
		public byte[] ImageId;

		/// <summary>The security version number of the primary module for the enclave.</summary>
		public uint EnclaveSvn;

		/// <summary>The security version number of the Virtual Secure Mode (VSM) kernel.</summary>
		public uint SecureKernelSvn;

		/// <summary>The security version number of the platform that hosts the enclave.</summary>
		public uint PlatformSvn;

		/// <summary>
		/// <para>Flags that describe the runtime policy for the enclave.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>ENCLAVE_FLAG_FULL_DEBUG_ENABLED 0x00000001</term>
		/// <term>The enclave supports debugging.</term>
		/// </item>
		/// <item>
		/// <term>ENCLAVE_FLAG_DYNAMIC_DEBUG_ENABLED 0x00000002</term>
		/// <term>The enclave supports dynamic debugging.</term>
		/// </item>
		/// <item>
		/// <term>ENCLAVE_FLAG_DYNAMIC_DEBUG_ACTIVE 0x00000004</term>
		/// <term>Dynamic debugging is turned on for the enclave.</term>
		/// </item>
		/// </list>
		/// </summary>
		public ENCLAVE_FLAG Flags;

		/// <summary>The signing level of the primary module for the enclave.</summary>
		public uint SigningLevel;

		/// <summary/>
		public uint EnclaveType;
	}

	/// <summary>Contains information about the currently executing enclave.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/ntenclv/ns-ntenclv-enclave_information typedef struct ENCLAVE_INFORMATION {
	// ULONG EnclaveType; ULONG Reserved; PVOID BaseAddress; SizeT Size; ENCLAVE_IDENTITY Identity; } ENCLAVE_INFORMATION;
	[PInvokeData("ntenclv.h", MSDNShortId = "6720EDBE-6A0E-4192-A096-2ACA681E2AAF")]
	[StructLayout(LayoutKind.Sequential)]
	public struct ENCLAVE_INFORMATION
	{
		/// <summary>
		/// <para>The architecture type of the enclave.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>ENCLAVE_TYPE_SGX 0x00000001</term>
		/// <term>An enclave for the Intel Software Guard Extensions (SGX) architecture extension.</term>
		/// </item>
		/// <item>
		/// <term>ENCLAVE_TYPE_VBS 0x00000010</term>
		/// <term>A VBS enclave.</term>
		/// </item>
		/// </list>
		/// </summary>
		public EnclaveType EnclaveType;

		/// <summary>Reserved.</summary>
		public uint Reserved;

		/// <summary>A pointer to the base address of the enclave.</summary>
		public IntPtr BaseAddress;

		/// <summary>The size of the enclave, in bytes.</summary>
		public SizeT Size;

		/// <summary>The identity of the primary module of an enclave.</summary>
		public ENCLAVE_IDENTITY Identity;
	}

	/// <summary>
	/// Contains architecture-specific information to use to initialize an enclave when the enclave type is <c>ENCLAVE_TYPE_SGX</c>,
	/// which specifies an enclave for the Intel Software Guard Extensions (SGX) architecture extension.
	/// </summary>
	// typedef struct _ENCLAVE_INIT_INFO_SGX { UCHAR SigStruct[1808]; UCHAR Reserved1[240]; UCHAR EInitToken[304]; UCHAR Reserved2[744];}
	// ENCLAVE_INIT_INFO_SGX, *PENCLAVE_INIT_INFO_SGX; https://msdn.microsoft.com/en-us/library/windows/desktop/mt592868(v=vs.85).aspx
	[PInvokeData("Winnt.h", MSDNShortId = "mt592868")]
	[StructLayout(LayoutKind.Sequential)]
	public struct ENCLAVE_INIT_INFO_SGX()
	{
		/// <summary>
		/// The enclave signature structure ( <c>SIGSTRUCT</c>) to use to initialize the enclave. This structure specifies information
		/// about the enclave from the enclave signer.
		/// </summary>
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1808)]
		public byte[] SigStruct = new byte[1808];

		/// <summary>Not used.</summary>
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 240)]
		public byte[] Reserved1 = new byte[240];

		/// <summary>
		/// The EINIT token structure ( <c>EINITTOKEN</c>) to use to initialize the enclave. The initialization operation uses this
		/// structure to verify that the enclave has permission to start.
		/// </summary>
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 304)]
		public byte[] EInitToken = new byte[304];

		/// <summary>Not used.</summary>
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1744)]
		public byte[] Reserved2 = new byte[1744];
	}

	/// <summary>
	/// Contains architecture-specific information to use to initialize an enclave when the enclave type is <c>ENCLAVE_TYPE_VBS</c>,
	/// which specifies a virtualization-based security (VBS) enclave.
	/// </summary>
	// typedef struct ENCLAVE_INIT_INFO_VBS { ULONG Length; ULONG ThreadCount; }; https://msdn.microsoft.com/en-us/library/windows/desktop/mt844241(v=vs.85).aspx
	[PInvokeData("Winnt.h", MSDNShortId = "mt844241")]
	[StructLayout(LayoutKind.Sequential)]
	public struct ENCLAVE_INIT_INFO_VBS
	{
		/// <summary>The total length of the <c>ENCLAVE_INIT_INFO_VBS</c> structure, in bytes.</summary>
		public uint Length;

		/// <summary>
		/// Upon entry to the <c>InitializeEnclave</c> function, specifies the number of threads to create in the enclave. Upon
		/// successful return from <c>InitializeEnclave</c>, contains the number of threads the function actually created.
		/// </summary>
		public uint ThreadCount;
	}

	/// <summary>Provides a <see cref="SafeHandle"/> for an enclave handle that is disposed using <see cref="DeleteEnclave(IntPtr)"/>.</summary>
	[AutoSafeHandle("DeleteEnclave(handle)", null, typeof(SafeHANDLE))]
	[AdjustAutoMethodNamePattern("Enclave", "")]
	public partial class SafeEnclaveHandle { }
}