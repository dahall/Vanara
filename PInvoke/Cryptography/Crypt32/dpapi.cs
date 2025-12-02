namespace Vanara.PInvoke;

/// <summary>Methods and data types found in Crypt32.dll.</summary>
public static partial class Crypt32
{
	/// <summary>Flags for CryptProtectData.</summary>
	[PInvokeData("dpapi.h", MSDNShortId = "765a68fd-f105-49fc-a738-4a8129eb0770")]
	[Flags]
	public enum CryptProtectFlags
	{
		/// <summary>
		/// This flag is used for remote situations where presenting a user interface (UI) is not an option. When this flag is set and a
		/// UI is specified for either the protect or unprotect operation, the operation fails and GetLastError returns the
		/// ERROR_PASSWORD_RESTRICTION code.
		/// </summary>
		CRYPTPROTECT_UI_FORBIDDEN = 0x1,

		/// <summary>
		/// When this flag is set, it associates the data encrypted with the current computer instead of with an individual user. Any
		/// user on the computer on which CryptProtectData is called can use CryptUnprotectData to decrypt the data.
		/// </summary>
		CRYPTPROTECT_LOCAL_MACHINE = 0x4,

		/// <summary>
		/// Force credential synchronize during CryptProtectData(). Synchronize is the only operation that occurs during this operation.
		/// </summary>
		CRYPTPROTECT_CRED_SYNC = 0x8,

		/// <summary>Generate an Audit on protect and unprotect operations.</summary>
		CRYPTPROTECT_AUDIT = 0x10,

		/// <summary>Protect data with a non-recoverable key.</summary>
		CRYPTPROTECT_NO_RECOVERY = 0x20,

		/// <summary>Verify the protection of a protected blob.</summary>
		CRYPTPROTECT_VERIFY_PROTECTION = 0x40,

		/// <summary>Regenerate the local machine protection.</summary>
		CRYPTPROTECT_CRED_REGENERATE = 0x80
	}

	/// <summary>Flags for CryptProtectMemory and CryptUnprotectMemory</summary>
	[PInvokeData("dpapi.h", MSDNShortId = "6b372552-87d4-4047-afa5-0d1113348289")]
	[Flags]
	public enum CryptProtectMemoryFlags
	{
		/// <summary>
		/// Encrypt and decrypt memory in the same process. An application running in a different process will not be able to decrypt
		/// the data.
		/// </summary>
		CRYPTPROTECTMEMORY_SAME_PROCESS = 0x00,

		/// <summary>
		/// Encrypt and decrypt memory in different processes. An application running in a different process will be able to decrypt the data.
		/// </summary>
		CRYPTPROTECTMEMORY_CROSS_PROCESS = 0x01,

		/// <summary>
		/// Use the same logon credentials to encrypt and decrypt memory in different processes. An application running in a different
		/// process will be able to decrypt the data. However, the process must run as the same user that encrypted the data and in the
		/// same logon session.
		/// </summary>
		CRYPTPROTECTMEMORY_SAME_LOGON = 0x02,
	}

	/// <summary>Flags that indicate when prompts to the user are to be displayed.</summary>
	[PInvokeData("dpapi.h", MSDNShortId = "412ce598-a7c9-446d-bd98-6583a20d6cd7")]
	[Flags]
	public enum CryptProtectPrompt : uint
	{
		/// <summary>
		/// This flag can be combined with CRYPTPROTECT_PROMPT_ON_PROTECT to enforce the UI (user interface) policy of the caller. When
		/// CryptUnprotectData is called, the dwPromptFlags specified in the CryptProtectData call are enforced.
		/// </summary>
		CRYPTPROTECT_PROMPT_ON_UNPROTECT = 0x1,

		/// <summary>This flag is used to provide the prompt for the protect phase.</summary>
		CRYPTPROTECT_PROMPT_ON_PROTECT = 0x2,

		/// <summary>Reserved.</summary>
		CRYPTPROTECT_PROMPT_RESERVED = 0x04,

		/// <summary>Default to strong variant UI protection (user supplied password currently).</summary>
		CRYPTPROTECT_PROMPT_STRONG = 0x08,

		/// <summary>Require strong variant UI protection (user supplied password currently).</summary>
		CRYPTPROTECT_PROMPT_REQUIRE_STRONG = 0x10,
	}

	/// <summary>
	/// The <c>CryptProtectData</c> function performs encryption on the data in a DATA_BLOB structure. Typically, only a user with the
	/// same logon credential as the user who encrypted the data can decrypt the data. In addition, the encryption and decryption
	/// usually must be done on the same computer. For information about exceptions, see Remarks.
	/// </summary>
	/// <param name="pDataIn">The plaintext to be encrypted.</param>
	/// <param name="szDataDescr">
	/// A string with a readable description of the data to be encrypted. This description string is included with the encrypted data.
	/// This parameter is optional and can be set to <c>NULL</c>.
	/// </param>
	/// <param name="pOptionalEntropy">
	/// A pointer to a DATA_BLOB structure that contains a password or other additional entropy used to encrypt the data. The
	/// <c>DATA_BLOB</c> structure used in the encryption phase must also be used in the decryption phase. This parameter can be set to
	/// <c>NULL</c> for no additional entropy. For information about protecting passwords, see Handling Passwords.
	/// </param>
	/// <param name="pPromptStruct">
	/// A pointer to a CRYPTPROTECT_PROMPTSTRUCT structure that provides information about where and when prompts are to be displayed
	/// and what the content of those prompts should be. This parameter can be set to <c>NULL</c> in both the encryption and decryption phases.
	/// </param>
	/// <param name="dwFlags">
	/// <para>This parameter can be one of the following flags.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>CRYPTPROTECT_LOCAL_MACHINE</term>
	/// <term>
	/// When this flag is set, it associates the data encrypted with the current computer instead of with an individual user. Any user
	/// on the computer on which CryptProtectData is called can use CryptUnprotectData to decrypt the data.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CRYPTPROTECT_UI_FORBIDDEN</term>
	/// <term>
	/// This flag is used for remote situations where presenting a user interface (UI) is not an option. When this flag is set and a UI
	/// is specified for either the protect or unprotect operation, the operation fails and GetLastError returns the
	/// ERROR_PASSWORD_RESTRICTION code.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CRYPTPROTECT_AUDIT</term>
	/// <term>This flag generates an audit on protect and unprotect operations.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="pDataOut">
	/// A byte array that receives the encrypted data.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the function returns <c>TRUE</c>.</para>
	/// <para>If the function fails, it returns <c>FALSE</c>. For extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// Typically, only a user with logon credentials that match those of the user who encrypted the data can decrypt the data. In
	/// addition, decryption usually can only be done on the computer where the data was encrypted. However, a user with a roaming
	/// profile can decrypt the data from another computer on the network.
	/// </para>
	/// <para>
	/// If the CRYPTPROTECT_LOCAL_MACHINE flag is set when the data is encrypted, any user on the computer where the encryption was done
	/// can decrypt the data.
	/// </para>
	/// <para>
	/// The function creates a session key to perform the encryption. The session key is derived again when the data is to be decrypted.
	/// </para>
	/// <para>
	/// The function also adds a Message Authentication Code (MAC) (keyed integrity check) to the encrypted data to guard against data tampering.
	/// </para>
	/// <para>To encrypt memory for temporary use in the same process or across processes, call the CryptProtectMemory function.</para>
	/// <para>Examples</para>
	/// <para>
	/// The following example shows encryption of the data in a DATA_BLOB structure. The <c>CryptProtectData</c> function does the
	/// encryption by using a session key that the function creates by using the user's logon credentials. For another example that uses
	/// this function, see Example C Program: Using CryptProtectData.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/dpapi/nf-dpapi-cryptprotectdata DPAPI_IMP BOOL CryptProtectData( DATA_BLOB
	// *pDataIn, LPCWSTR szDataDescr, DATA_BLOB *pOptionalEntropy, PVOID pvReserved, CRYPTPROTECT_PROMPTSTRUCT *pPromptStruct, DWORD
	// dwFlags, DATA_BLOB *pDataOut );
	[PInvokeData("dpapi.h", MSDNShortId = "765a68fd-f105-49fc-a738-4a8129eb0770")]
	public static bool CryptProtectData([In] byte[] pDataIn, [Optional] string? szDataDescr, [In, Optional] byte[]? pOptionalEntropy,
		[Optional] in CRYPTPROTECT_PROMPTSTRUCT? pPromptStruct, CryptProtectFlags dwFlags, out byte[] pDataOut)
	{
		unsafe
		{
			CRYPTOAPI_BLOB oe = new(pOptionalEntropy);
			using SafeCoTaskMemStruct<CRYPTPROTECT_PROMPTSTRUCT> ps = pPromptStruct;
			CRYPTOAPI_BLOB dout = new();
			if (!CryptProtectData((CRYPTOAPI_BLOB)pDataIn, szDataDescr, pOptionalEntropy is null ? default : &oe, default, ps, dwFlags, &dout))
			{
				pDataOut = [];
				return false;
			}
			pDataOut = dout;
			LocalFree(dout.pbData);
			return true;
		}
	}

	/// <summary>
	/// The <c>CryptProtectData</c> function performs encryption on the data in a DATA_BLOB structure. Typically, only a user with the
	/// same logon credential as the user who encrypted the data can decrypt the data. In addition, the encryption and decryption
	/// usually must be done on the same computer. For information about exceptions, see Remarks.
	/// </summary>
	/// <param name="pDataIn">A pointer to a DATA_BLOB structure that contains the plaintext to be encrypted.</param>
	/// <param name="szDataDescr">
	/// A string with a readable description of the data to be encrypted. This description string is included with the encrypted data.
	/// This parameter is optional and can be set to <c>NULL</c>.
	/// </param>
	/// <param name="pOptionalEntropy">
	/// A pointer to a DATA_BLOB structure that contains a password or other additional entropy used to encrypt the data. The
	/// <c>DATA_BLOB</c> structure used in the encryption phase must also be used in the decryption phase. This parameter can be set to
	/// <c>NULL</c> for no additional entropy. For information about protecting passwords, see Handling Passwords.
	/// </param>
	/// <param name="pvReserved">Reserved for future use and must be set to <c>NULL</c>.</param>
	/// <param name="pPromptStruct">
	/// A pointer to a CRYPTPROTECT_PROMPTSTRUCT structure that provides information about where and when prompts are to be displayed
	/// and what the content of those prompts should be. This parameter can be set to <c>NULL</c> in both the encryption and decryption phases.
	/// </param>
	/// <param name="dwFlags">
	/// <para>This parameter can be one of the following flags.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>CRYPTPROTECT_LOCAL_MACHINE</term>
	/// <term>
	/// When this flag is set, it associates the data encrypted with the current computer instead of with an individual user. Any user
	/// on the computer on which CryptProtectData is called can use CryptUnprotectData to decrypt the data.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CRYPTPROTECT_UI_FORBIDDEN</term>
	/// <term>
	/// This flag is used for remote situations where presenting a user interface (UI) is not an option. When this flag is set and a UI
	/// is specified for either the protect or unprotect operation, the operation fails and GetLastError returns the
	/// ERROR_PASSWORD_RESTRICTION code.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CRYPTPROTECT_AUDIT</term>
	/// <term>This flag generates an audit on protect and unprotect operations.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="pDataOut">
	/// A pointer to a DATA_BLOB structure that receives the encrypted data. When you have finished using the <c>DATA_BLOB</c>
	/// structure, free its <c>pbData</c> member by calling the LocalFree function.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the function returns <c>TRUE</c>.</para>
	/// <para>If the function fails, it returns <c>FALSE</c>. For extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// Typically, only a user with logon credentials that match those of the user who encrypted the data can decrypt the data. In
	/// addition, decryption usually can only be done on the computer where the data was encrypted. However, a user with a roaming
	/// profile can decrypt the data from another computer on the network.
	/// </para>
	/// <para>
	/// If the CRYPTPROTECT_LOCAL_MACHINE flag is set when the data is encrypted, any user on the computer where the encryption was done
	/// can decrypt the data.
	/// </para>
	/// <para>
	/// The function creates a session key to perform the encryption. The session key is derived again when the data is to be decrypted.
	/// </para>
	/// <para>
	/// The function also adds a Message Authentication Code (MAC) (keyed integrity check) to the encrypted data to guard against data tampering.
	/// </para>
	/// <para>To encrypt memory for temporary use in the same process or across processes, call the CryptProtectMemory function.</para>
	/// <para>Examples</para>
	/// <para>
	/// The following example shows encryption of the data in a DATA_BLOB structure. The <c>CryptProtectData</c> function does the
	/// encryption by using a session key that the function creates by using the user's logon credentials. For another example that uses
	/// this function, see Example C Program: Using CryptProtectData.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/dpapi/nf-dpapi-cryptprotectdata DPAPI_IMP BOOL CryptProtectData( DATA_BLOB
	// *pDataIn, LPCWSTR szDataDescr, DATA_BLOB *pOptionalEntropy, PVOID pvReserved, CRYPTPROTECT_PROMPTSTRUCT *pPromptStruct, DWORD dwFlags,
	// DATA_BLOB *pDataOut );
	[DllImport(Lib.Crypt32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("dpapi.h", MSDNShortId = "765a68fd-f105-49fc-a738-4a8129eb0770")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool CryptProtectData(in CRYPTOAPI_BLOB pDataIn, [Optional, MarshalAs(UnmanagedType.LPWStr)] string? szDataDescr,
		[In, Optional] StructPointer<CRYPTOAPI_BLOB> pOptionalEntropy, [Optional] IntPtr pvReserved,
		[In, Optional] ManagedStructPointer<CRYPTPROTECT_PROMPTSTRUCT> pPromptStruct, CryptProtectFlags dwFlags, [Out] StructPointer<CRYPTOAPI_BLOB> pDataOut);

	/// <summary>
	/// The <c>CryptProtectMemory</c> function encrypts memory to prevent others from viewing sensitive information in your process. For
	/// example, use the <c>CryptProtectMemory</c> function to encrypt memory that contains a password. Encrypting the password prevents
	/// others from viewing it when the process is paged out to the swap file. Otherwise, the password is in plaintext and viewable by others.
	/// </summary>
	/// <param name="pDataIn">
	/// A pointer to the block of memory to encrypt. The cbData parameter specifies the number of bytes that will be encrypted. If the
	/// data contained in the memory space is smaller than the number of bytes specified, data outside of the intended block will be
	/// encrypted. If it is larger than cbData bytes, then only the first cbData bytes will be encrypted.
	/// </param>
	/// <param name="cbDataIn">
	/// Number of bytes of memory pointed to by the pData parameter to encrypt. The number of bytes must be a multiple of the
	/// <c>CRYPTPROTECTMEMORY_BLOCK_SIZE</c> constant defined in Wincrypt.h.
	/// </param>
	/// <param name="dwFlags">
	/// <para>This parameter can be one of the following flags. You must specify the same flag when encrypting and decrypting the memory.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>CRYPTPROTECTMEMORY_SAME_PROCESS</term>
	/// <term>
	/// Encrypt and decrypt memory in the same process. An application running in a different process will not be able to decrypt the data.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CRYPTPROTECTMEMORY_CROSS_PROCESS</term>
	/// <term>
	/// Encrypt and decrypt memory in different processes. An application running in a different process will be able to decrypt the data.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CRYPTPROTECTMEMORY_SAME_LOGON</term>
	/// <term>
	/// Use the same logon credentials to encrypt and decrypt memory in different processes. An application running in a different
	/// process will be able to decrypt the data. However, the process must run as the same user that encrypted the data and in the same
	/// logon session.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the function returns <c>TRUE</c>.</para>
	/// <para>If the function fails, it returns <c>FALSE</c>. For extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// Using CryptProtectMemory and CryptUnprotectMemory for password encryption is not secure because the data exists as plaintext in
	/// memory before it is encrypted and at any time the caller decrypts it for use.
	/// </para>
	/// <para>
	/// Typically, you use the <c>CryptProtectMemory</c> function to encrypt sensitive information that you are going to decrypt while
	/// your process is running. Do not use this function to save data that you want to decrypt later; you will not be able to decrypt
	/// the data if the computer is restarted. To save encrypted data to a file to decrypt later, use the CryptProtectData function.
	/// </para>
	/// <para>
	/// Call the CryptUnprotectMemory function to decrypt memory encrypted with the <c>CryptProtectMemory</c> function. When you have
	/// finished using the sensitive information, clear it from memory by calling the SecureZeroMemory function.
	/// </para>
	/// <para>
	/// Use the CRYPTPROTECTMEMORY_CROSS_PROCESS or CRYPTPROTECTMEMORY_SAME_LOGON flag if you use RPC or LRPC to pass encrypted data to
	/// another process. The receiving process must specify the same flag to decrypt the data. Also, use these flags if you use shared memory.
	/// </para>
	/// <para>
	/// If the client uses the CRYPTPROTECTMEMORY_SAME_LOGON flag, the server must impersonate the client (RpcImpersonateClient) before
	/// decrypting the memory.
	/// </para>
	/// <para>Examples</para>
	/// <para>The following example calls the <c>CryptProtectMemory</c> function to encrypt data that is in memory.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/dpapi/nf-dpapi-cryptprotectmemory DPAPI_IMP BOOL CryptProtectMemory( LPVOID
	// pDataIn, DWORD cbDataIn, DWORD dwFlags );
	[DllImport(Lib.Crypt32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("dpapi.h", MSDNShortId = "6b372552-87d4-4047-afa5-0d1113348289")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool CryptProtectMemory([In, SizeDef(nameof(cbDataIn))] IntPtr pDataIn, uint cbDataIn, CryptProtectMemoryFlags dwFlags);

	/// <summary>
	/// The <c>CryptUnprotectData</c> function decrypts and does an integrity check of the data in a DATA_BLOB structure. Usually, the
	/// only user who can decrypt the data is a user with the same logon credentials as the user who encrypted the data. In addition,
	/// the encryption and decryption must be done on the same computer. For information about exceptions, see the Remarks section of CryptProtectData.
	/// </summary>
	/// <param name="pDataIn">
	/// A pointer to a DATA_BLOB structure that holds the encrypted data. The <c>DATA_BLOB</c> structure's <c>cbData</c> member holds
	/// the length of the <c>pbData</c> member's byte string that contains the text to be encrypted.
	/// </param>
	/// <param name="ppszDataDescr">
	/// A pointer to a string-readable description of the encrypted data included with the encrypted data. This parameter can be set to
	/// <c>NULL</c>. When you have finished using ppszDataDescr, free it by calling the LocalFree function.
	/// </param>
	/// <param name="pOptionalEntropy">
	/// A pointer to a DATA_BLOB structure that contains a password or other additional entropy used when the data was encrypted. This
	/// parameter can be set to <c>NULL</c>; however, if an optional entropy <c>DATA_BLOB</c> structure was used in the encryption
	/// phase, that same <c>DATA_BLOB</c> structure must be used for the decryption phase. For information about protecting passwords,
	/// see Handling Passwords.
	/// </param>
	/// <param name="pvReserved">This parameter is reserved for future use and must be set to <c>NULL</c>.</param>
	/// <param name="pPromptStruct">
	/// A pointer to a CRYPTPROTECT_PROMPTSTRUCT structure that provides information about where and when prompts are to be displayed
	/// and what the content of those prompts should be. This parameter can be set to <c>NULL</c>.
	/// </param>
	/// <param name="dwFlags">
	/// <para>
	/// A <c>DWORD</c> value that specifies options for this function. This parameter can be zero, in which case no option is set, or
	/// the following flag.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>CRYPTPROTECT_UI_FORBIDDEN</term>
	/// <term>
	/// This flag is used for remote situations where the user interface (UI) is not an option. When this flag is set and UI is
	/// specified for either the protect or unprotect operation, the operation fails and GetLastError returns the
	/// ERROR_PASSWORD_RESTRICTION code.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CRYPTPROTECT_VERIFY_PROTECTION</term>
	/// <term>
	/// This flag verifies the protection of a protected BLOB. If the default protection level configured of the host is higher than the
	/// current protection level for the BLOB, the function returns CRYPT_I_NEW_PROTECTION_REQUIRED to advise the caller to again
	/// protect the plaintext contained in the BLOB.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="pDataOut">
	/// A pointer to a DATA_BLOB structure where the function stores the decrypted data. When you have finished using the
	/// <c>DATA_BLOB</c> structure, free its <c>pbData</c> member by calling the LocalFree function.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the function returns <c>TRUE</c>.</para>
	/// <para>If the function fails, it returns <c>FALSE</c>.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The CryptProtectData function creates a session key when the data is encrypted. That key is derived again and used to decrypt
	/// the data BLOB.
	/// </para>
	/// <para>
	/// The Message Authentication Code (MAC) hash added to the encrypted data can be used to determine whether the encrypted data was
	/// altered in any way. Any tampering results in the return of the ERROR_INVALID_DATA code.
	/// </para>
	/// <para>
	/// When you have finished using the DATA_BLOB structure, free its <c>pbData</c> member by calling the LocalFree function. Any
	/// ppszDataDescr that is not <c>NULL</c> must also be freed by using <c>LocalFree</c>.
	/// </para>
	/// <para>When you have finished using sensitive information, clear it from memory by calling the SecureZeroMemory function.</para>
	/// <para>Examples</para>
	/// <para>
	/// The following example shows decrypting encrypted data in a DATA_BLOB structure. This function does the decryption by using a
	/// session key that the function creates by using the user's logon credentials. For another example that uses this function, see
	/// Example C Program: Using CryptProtectData.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/dpapi/nf-dpapi-cryptunprotectdata DPAPI_IMP BOOL CryptUnprotectData( DATA_BLOB
	// *pDataIn, LPWSTR *ppszDataDescr, DATA_BLOB *pOptionalEntropy, PVOID pvReserved, CRYPTPROTECT_PROMPTSTRUCT *pPromptStruct, DWORD
	// dwFlags, DATA_BLOB *pDataOut );
	[DllImport(Lib.Crypt32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("dpapi.h", MSDNShortId = "54eab3b0-d341-47c6-9c32-79328d7a7155")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool CryptUnprotectData(in CRYPTOAPI_BLOB pDataIn, out StrPtrUni ppszDataDescr,
		in CRYPTOAPI_BLOB pOptionalEntropy, [Optional] IntPtr pvReserved, in CRYPTPROTECT_PROMPTSTRUCT pPromptStruct, CryptProtectFlags dwFlags, [Out] IntPtr pDataOut);

	/// <summary>
	/// The <c>CryptUnprotectData</c> function decrypts and does an integrity check of the data in a DATA_BLOB structure. Usually, the
	/// only user who can decrypt the data is a user with the same logon credentials as the user who encrypted the data. In addition,
	/// the encryption and decryption must be done on the same computer. For information about exceptions, see the Remarks section of CryptProtectData.
	/// </summary>
	/// <param name="pDataIn">
	/// A pointer to a DATA_BLOB structure that holds the encrypted data. The <c>DATA_BLOB</c> structure's <c>cbData</c> member holds
	/// the length of the <c>pbData</c> member's byte string that contains the text to be encrypted.
	/// </param>
	/// <param name="ppszDataDescr">
	/// A pointer to a string-readable description of the encrypted data included with the encrypted data. This parameter can be set to
	/// <c>NULL</c>. When you have finished using ppszDataDescr, free it by calling the LocalFree function.
	/// </param>
	/// <param name="pOptionalEntropy">
	/// A pointer to a DATA_BLOB structure that contains a password or other additional entropy used when the data was encrypted. This
	/// parameter can be set to <c>NULL</c>; however, if an optional entropy <c>DATA_BLOB</c> structure was used in the encryption
	/// phase, that same <c>DATA_BLOB</c> structure must be used for the decryption phase. For information about protecting passwords,
	/// see Handling Passwords.
	/// </param>
	/// <param name="pvReserved">This parameter is reserved for future use and must be set to <c>NULL</c>.</param>
	/// <param name="pPromptStruct">
	/// A pointer to a CRYPTPROTECT_PROMPTSTRUCT structure that provides information about where and when prompts are to be displayed
	/// and what the content of those prompts should be. This parameter can be set to <c>NULL</c>.
	/// </param>
	/// <param name="dwFlags">
	/// <para>
	/// A <c>DWORD</c> value that specifies options for this function. This parameter can be zero, in which case no option is set, or
	/// the following flag.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>CRYPTPROTECT_UI_FORBIDDEN</term>
	/// <term>
	/// This flag is used for remote situations where the user interface (UI) is not an option. When this flag is set and UI is
	/// specified for either the protect or unprotect operation, the operation fails and GetLastError returns the
	/// ERROR_PASSWORD_RESTRICTION code.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CRYPTPROTECT_VERIFY_PROTECTION</term>
	/// <term>
	/// This flag verifies the protection of a protected BLOB. If the default protection level configured of the host is higher than the
	/// current protection level for the BLOB, the function returns CRYPT_I_NEW_PROTECTION_REQUIRED to advise the caller to again
	/// protect the plaintext contained in the BLOB.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="pDataOut">
	/// A pointer to a DATA_BLOB structure where the function stores the decrypted data. When you have finished using the
	/// <c>DATA_BLOB</c> structure, free its <c>pbData</c> member by calling the LocalFree function.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the function returns <c>TRUE</c>.</para>
	/// <para>If the function fails, it returns <c>FALSE</c>.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The CryptProtectData function creates a session key when the data is encrypted. That key is derived again and used to decrypt
	/// the data BLOB.
	/// </para>
	/// <para>
	/// The Message Authentication Code (MAC) hash added to the encrypted data can be used to determine whether the encrypted data was
	/// altered in any way. Any tampering results in the return of the ERROR_INVALID_DATA code.
	/// </para>
	/// <para>
	/// When you have finished using the DATA_BLOB structure, free its <c>pbData</c> member by calling the LocalFree function. Any
	/// ppszDataDescr that is not <c>NULL</c> must also be freed by using <c>LocalFree</c>.
	/// </para>
	/// <para>When you have finished using sensitive information, clear it from memory by calling the SecureZeroMemory function.</para>
	/// <para>Examples</para>
	/// <para>
	/// The following example shows decrypting encrypted data in a DATA_BLOB structure. This function does the decryption by using a
	/// session key that the function creates by using the user's logon credentials. For another example that uses this function, see
	/// Example C Program: Using CryptProtectData.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/dpapi/nf-dpapi-cryptunprotectdata DPAPI_IMP BOOL CryptUnprotectData( DATA_BLOB
	// *pDataIn, LPWSTR *ppszDataDescr, DATA_BLOB *pOptionalEntropy, PVOID pvReserved, CRYPTPROTECT_PROMPTSTRUCT *pPromptStruct, DWORD
	// dwFlags, DATA_BLOB *pDataOut );
	[DllImport(Lib.Crypt32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("dpapi.h", MSDNShortId = "54eab3b0-d341-47c6-9c32-79328d7a7155")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool CryptUnprotectData(in CRYPTOAPI_BLOB pDataIn, [Optional] IntPtr ppszDataDescr, [In, Optional] StructPointer<CRYPTOAPI_BLOB> pOptionalEntropy,
		[Optional] IntPtr pvReserved, [In, Optional] ManagedStructPointer<CRYPTPROTECT_PROMPTSTRUCT> pPromptStruct, CryptProtectFlags dwFlags, [Out] StructPointer<CRYPTOAPI_BLOB> pDataOut);

	/// <summary>The <c>CryptUnprotectMemory</c> function decrypts memory that was encrypted using the CryptProtectMemory function.</summary>
	/// <param name="pDataIn">
	/// A pointer to the block of memory to decrypt. The cbData parameter specifies the number of bytes that the function will attempt
	/// to decrypt. If the data contained in the memory space is smaller than the number of bytes specified, the function will attempt
	/// to decrypt data outside of the intended block. If it is larger than cbData bytes, then only the first cbData bytes will be decrypted.
	/// </param>
	/// <param name="cbDataIn">
	/// Number of bytes of memory pointed to by the pData parameter to decrypt. The number of bytes must be a multiple of the
	/// <c>CRYPTPROTECTMEMORY_BLOCK_SIZE</c> constant defined in Wincrypt.h.
	/// </param>
	/// <param name="dwFlags">
	/// <para>This parameter can be one of the following flags. You must specify the same flag when encrypting and decrypting the memory.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>CRYPTPROTECTMEMORY_SAME_PROCESS</term>
	/// <term>
	/// Encrypt and decrypt memory in the same process. An application running in a different process will not be able to decrypt the data.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CRYPTPROTECTMEMORY_CROSS_PROCESS</term>
	/// <term>
	/// Encrypt and decrypt memory in different processes. An application running in a different process will be able to decrypt the data.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CRYPTPROTECTMEMORY_SAME_LOGON</term>
	/// <term>
	/// Use the same logon credentials to encrypt and decrypt memory in different processes. An application running in a different
	/// process will be able to decrypt the data. However, the process must run as the same user that encrypted the data and in the same
	/// logon session.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the function returns <c>TRUE</c>.</para>
	/// <para>If the function fails, it returns <c>FALSE</c>. For extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// Using CryptProtectMemory and CryptUnprotectMemory for password encryption is not secure because the data exists as plaintext in
	/// memory before it is encrypted and at any time the caller decrypts it for use.
	/// </para>
	/// <para>
	/// You must encrypt and decrypt the memory during the same boot session. If the computer is restarted before you call the
	/// <c>CryptUnprotectMemory</c> function, you will not be able to decrypt the data.
	/// </para>
	/// <para>
	/// You must pass the same flag to <c>CryptUnprotectMemory</c> and CryptProtectMemory. If you pass different flags, the
	/// <c>CryptUnprotectMemory</c> function succeeds; however, the result is unpredictable.
	/// </para>
	/// <para>When you have finished using the sensitive information, clear it from memory by calling the SecureZeroMemory function.</para>
	/// <para>Examples</para>
	/// <para>
	/// The following example calls the <c>CryptUnprotectMemory</c> function to decrypt data that is in memory. The example assumes the
	/// variable pEncryptedText points to a string that has been encrypted using the CryptProtectMemory function.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/dpapi/nf-dpapi-cryptunprotectmemory DPAPI_IMP BOOL CryptUnprotectMemory(
	// LPVOID pDataIn, DWORD cbDataIn, DWORD dwFlags );
	[DllImport(Lib.Crypt32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("dpapi.h", MSDNShortId = "1c7980ac-4e9e-43fd-b6d7-c0d0a69c8040")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool CryptUnprotectMemory([In, SizeDef(nameof(cbDataIn))] IntPtr pDataIn, uint cbDataIn, CryptProtectMemoryFlags dwFlags);

	/// <summary>
	/// The <c>CryptUpdateProtectedState</c> function migrates the current user's master keys after the user's security identifier (SID)
	/// has changed. This function can be used to preserve encrypted data after a user has been moved from one domain to another.
	/// </summary>
	/// <param name="pOldSid">
	/// <para>
	/// The address of a SID structure that contains the user's previous SID. This SID is used to locate the old master keys. If this
	/// parameter is <c>NULL</c>, the master keys for the current user SID are migrated.
	/// </para>
	/// <para>Either this parameter or the pwszOldPassword parameter may be <c>NULL</c>, but not both.</para>
	/// </param>
	/// <param name="pwszOldPassword">
	/// <para>
	/// A pointer to a null-terminated Unicode string that contains the user's password before the SID was changed. This password is
	/// used to decrypt the old master keys. If this parameter is <c>NULL</c>, the password of the current user will be used.
	/// </para>
	/// <para>Either this parameter or the pOldSid parameter may be <c>NULL</c>, but not both.</para>
	/// </param>
	/// <param name="dwFlags">Not used. Must be zero.</param>
	/// <param name="pdwSuccessCount">
	/// The address of a <c>DWORD</c> variable that receives the number of master keys that were successfully migrated.
	/// </param>
	/// <param name="pdwFailureCount">
	/// <para>The address of a <c>DWORD</c> variable that receives the number of master keys that could not be decrypted.</para>
	/// <para>
	/// It is not necessarily an error if one or more master keys cannot be decrypted. Some users may possess master keys that are
	/// stagnant and could not have been decrypted for a long time. One way that this can happen is when the password of a local user
	/// has been administratively reset.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is <c>TRUE</c>.</para>
	/// <para>
	/// If the function fails, the return value is <c>FALSE</c>. For extended error information, call GetLastError. Some possible error
	/// codes include the following.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_INVALID_PARAMETER</term>
	/// <term>One of the parameters contains a value that is not valid.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_OUTOFMEMORY</term>
	/// <term>A memory allocation failure occurred.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_ENCRYPTION_FAILED</term>
	/// <term>The old password could not be encrypted.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// This function decrypts all of the user's master keys in the old master key directory, using the previous password, and stores
	/// them in the user's current master key directory, encrypted with the user's current password.
	/// </para>
	/// <para>This function must be called from the user account that the keys are being migrated to.</para>
	/// <para>
	/// If this function is able to successfully migrate an old master key, it will automatically delete the old master key. Master keys
	/// that cannot be decrypted are not deleted.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/dpapi/nf-dpapi-cryptupdateprotectedstate DPAPI_IMP BOOL
	// CryptUpdateProtectedState( PSID pOldSid, LPCWSTR pwszOldPassword, DWORD dwFlags, DWORD *pdwSuccessCount, DWORD *pdwFailureCount );
	[DllImport(Lib.Crypt32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("dpapi.h", MSDNShortId = "f32e8fcd-6b5b-4a43-b3f9-77e17c84deca")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool CryptUpdateProtectedState([In, Optional] PSID pOldSid, [Optional, MarshalAs(UnmanagedType.LPWStr)] string? pwszOldPassword,
		[Optional] uint dwFlags, out uint pdwSuccessCount, out uint pdwFailureCount);

	[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
	internal static extern IntPtr LocalFree(IntPtr hMem);

	/// <summary>
	/// The <c>CRYPTPROTECT_PROMPTSTRUCT</c> structure provides the text of a prompt and information about when and where that prompt is
	/// to be displayed when using the CryptProtectData and CryptUnprotectData functions.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/dpapi/ns-dpapi-cryptprotect_promptstruct typedef struct
	// _CRYPTPROTECT_PROMPTSTRUCT { DWORD cbSize; DWORD dwPromptFlags; HWND hwndApp; LPCWSTR szPrompt; } CRYPTPROTECT_PROMPTSTRUCT, *PCRYPTPROTECT_PROMPTSTRUCT;
	[PInvokeData("dpapi.h", MSDNShortId = "412ce598-a7c9-446d-bd98-6583a20d6cd7")]
	[StructLayout(LayoutKind.Sequential)]
	public struct CRYPTPROTECT_PROMPTSTRUCT
	{
		/// <summary>The size, in bytes, of this structure.</summary>
		public uint cbSize;

		/// <summary>
		/// <para>
		/// <c>DWORD</c> flags that indicate when prompts to the user are to be displayed. Current <c>dwPromptFlags</c> values are as follows.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>CRYPTPROTECT_PROMPT_ON_PROTECT</term>
		/// <term>This flag is used to provide the prompt for the protect phase.</term>
		/// </item>
		/// <item>
		/// <term>CRYPTPROTECT_PROMPT_ON_UNPROTECT</term>
		/// <term>
		/// This flag can be combined with CRYPTPROTECT_PROMPT_ON_PROTECT to enforce the UI (user interface) policy of the caller. When
		/// CryptUnprotectData is called, the dwPromptFlags specified in the CryptProtectData call are enforced.
		/// </term>
		/// </item>
		/// </list>
		/// </summary>
		public CryptProtectPrompt dwPromptFlags;

		/// <summary>Window handle to the parent window.</summary>
		public HWND hwndApp;

		/// <summary>A string containing the text of a prompt to be displayed.</summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string? szPrompt;
	}
}