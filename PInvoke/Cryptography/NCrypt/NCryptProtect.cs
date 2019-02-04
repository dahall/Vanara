using System;
using System.Runtime.InteropServices;
using System.Text;
using Vanara.InteropServices;

namespace Vanara.PInvoke
{
	/// <summary>Methods and data types found in ncrypt.dll.</summary>
	public static partial class NCrypt
	{
		/// <summary>
		/// <para>
		/// The <c>PFNCryptStreamOutputCallback</c> function receives encrypted or decrypted data from tasks started by using the
		/// NCryptStreamOpenToProtect or NCryptStreamOpenToUnprotect functions. This callback must be defined by your application using the
		/// following syntax.
		/// </para>
		/// </summary>
		/// <param name="pvCallbackCtxt">
		/// <para>Pointer to data that you can use to keep track of your application. The data is not modified by the data protection API.</para>
		/// <para>
		/// <c>Note</c> You can set a pointer to your context data in the <c>pvCallbackCtxt</c> member of the NCRYPT_PROTECT_STREAM_INFO
		/// structure before passing a pointer to that structure in the pStreamInfo parameter of the NCryptStreamOpenToProtect or
		/// NCryptStreamOpenToUnprotect functions.
		/// </para>
		/// </param>
		/// <param name="pbData">
		/// <para>Pointer to a block of processed data that can be used by the application.</para>
		/// </param>
		/// <param name="cbData">
		/// <para>The size, in bytes, of the processed data pointed to by the pbData parameter.</para>
		/// </param>
		/// <param name="fFinal">
		/// <para>
		/// If this value is <c>TRUE</c>, the current data block is the last to be processed and this is the last time the callback will be called.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>
		/// If you return any status code other than <c>ERROR_SUCCESS</c> from your implementation of this callback function, the stream
		/// encryption or decryption process will fail.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>ERROR_SUCCESS</term>
		/// <term>The function was successful.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// Set a pointer to this callback function in the <c>pfnStreamOutput</c> member of the NCRYPT_PROTECT_STREAM_INFO structure. Set a
		/// pointer to the structure in the pStreamInfo parameter of the NCryptStreamOpenToProtect or NCryptStreamOpenToUnprotect functions.
		/// </para>
		/// <para>
		/// You can use this callback to further process the encrypted or decrypted data. A common use of the function is to write the data
		/// to disk as it is received from the data protection API. The blocks of encrypted or unencrypted data are created by the
		/// NCryptStreamUpdate function.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/ncryptprotect/nc-ncryptprotect-pfncryptstreamoutputcallback
		// PFNCryptStreamOutputCallback Pfncryptstreamoutputcallback; SECURITY_STATUS Pfncryptstreamoutputcallback( void *pvCallbackCtxt,
		// const BYTE *pbData, SIZE_T cbData, BOOL fFinal ) {...}
		[PInvokeData("ncryptprotect.h", MSDNShortId = "D07B2B63-306B-4C41-AA14-320EFEFFB939")]
		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		public delegate HRESULT PFNCryptStreamOutputCallback(IntPtr pvCallbackCtxt, IntPtr pbData, SizeT cbData, [MarshalAs(UnmanagedType.Bool)] bool fFinal);

		/// <summary>
		/// The <c>PFNCryptStreamOutputCallbackEx</c> function receives encrypted or decrypted data from tasks started by using the
		/// NCryptStreamOpenToProtectEx or NCryptStreamOpenToUnprotectEx functions. This callback must be defined by your application using
		/// the following syntax.
		/// </summary>
		/// <param name="pvCallbackCtxt">The arguments specified by NCRYPT_PROTECT_STREAM_INFO_EX.</param>
		/// <param name="pbData">
		/// A pointer to a block of processed data that is available to the application. If data is not available yet, but the descriptor is,
		/// this will be NULL.
		/// </param>
		/// <param name="cbData">The size, in bytes, of the processed data pointed to by the pbData parameter.</param>
		/// <param name="hDescriptor">Handle of Protection Descriptor.</param>
		/// <param name="fFinal">
		/// If this value is <c>TRUE</c>, the current data block is the last to be processed and this is the last time the callback will be called.
		/// </param>
		/// <returns>
		/// <para>
		/// If you return any status code other than <c>ERROR_SUCCESS</c> from your implementation of this callback function, the stream
		/// encryption or decryption process will fail.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>ERROR_SUCCESS</term>
		/// <term>The function was successful.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// Set a pointer to this callback function in the <c>pfnStreamOutput</c> member of the NCRYPT_PROTECT_STREAM_INFO structure. Set a
		/// pointer to the structure in the pStreamInfo parameter of the NCryptStreamOpenToProtect or NCryptStreamOpenToUnprotect functions.
		/// </para>
		/// <para>
		/// You can use this callback to further process the encrypted or decrypted data. A common use of the function is to write the data
		/// to disk as it is received from the data protection API. The blocks of encrypted or unencrypted data are created by the
		/// NCryptStreamUpdate function.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/ncryptprotect/nc-ncryptprotect-pfncryptstreamoutputcallback
		[PInvokeData("ncryptprotect.h")]
		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		public delegate HRESULT PFNCryptStreamOutputCallbackEx(IntPtr pvCallbackCtxt, IntPtr pbData, SizeT cbData, NCRYPT_DESCRIPTOR_HANDLE hDescriptor, [MarshalAs(UnmanagedType.Bool)] bool fFinal);

		/// <summary>Flags for <c>NCryptCreateProtectionDescriptor</c>.</summary>
		[PInvokeData("ncryptprotect.h", MSDNShortId = "BA6B15AC-2CD8-4D9A-817F-65CF9C09D22C")]
		[Flags]
		public enum CreateProtectionDescriptorFlags
		{
			/// <summary>
			/// To indicate that the string is a display name and that it is saved, along with its associated descriptor string rule, in the
			/// HKEY_CURRENT_USER registry hive, set only the NCRYPT_NAMED_DESCRIPTOR_FLAG value. That is, there is no unique flag to specify
			/// the current user registry hive.
			/// </summary>
			NCRYPT_NAMED_DESCRIPTOR_FLAG = 0x00000001,

			/// <summary>
			/// To indicate that the string is a display name and that it is saved, along with its associated descriptor rule string, in the
			/// HKEY_LOCAL_MACHINE registry hive, bitwise-OR the NCRYPT_NAMED_DESCRIPTOR_FLAG value and the NCRYPT_MACHINE_KEY_FLAG value.
			/// </summary>
			NCRYPT_MACHINE_KEY_FLAG = 0x00000020,
		}

		/// <summary>Flags for <c>NCryptProtectSecret</c>.</summary>
		[PInvokeData("ncryptprotect.h", MSDNShortId = "8726F92B-34D5-4696-8803-3D7F50F1006D")]
		[Flags]
		public enum ProtectFlags
		{
			/// <summary>Requests that the key service provider not display a user interface.</summary>
			NCRYPT_SILENT_FLAG = 0x00000040,
		}

		/// <summary>Flags used by <c>NCryptGetProtectionDescriptorInfo</c>.</summary>
		[PInvokeData("ncryptprotect.h", MSDNShortId = "EF4777D5-E218-4868-8D25-58E0EF8C9D30")]
		[Flags]
		public enum ProtectionDescriptorInfoType
		{
			/// <summary>The ppvInfo argument returns the descriptor rule string.</summary>
			[CorrespondingType(typeof(string))]
			NCRYPT_PROTECTION_INFO_TYPE_DESCRIPTOR_STRING = 0x00000001,
		}

		/// <summary>Flags for <c>NCryptQueryProtectionDescriptorName</c>.</summary>
		[PInvokeData("ncryptprotect.h", MSDNShortId = "32953AEC-01EE-4ED1-80F3-29963F43004F")]
		[Flags]
		public enum ProtectionDescriptorNameFlags
		{
			/// <summary>
			/// To indicate that the string is a display name and that it is saved, along with its associated descriptor rule string, in the
			/// HKEY_LOCAL_MACHINE registry hive, bitwise-OR the NCRYPT_NAMED_DESCRIPTOR_FLAG value and the NCRYPT_MACHINE_KEY_FLAG value.
			/// </summary>
			NCRYPT_MACHINE_KEY_FLAG = 0x00000020,
		}

		/// <summary>Flags used by <c>NCryptUnprotectSecret</c>.</summary>
		[PInvokeData("ncryptprotect.h", MSDNShortId = "F532F0ED-36F4-47E3-B478-089CC083E5D1")]
		[Flags]
		public enum UnprotectSecretFlags
		{
			/// <summary>Decodes only the header of the protected data blob. No actual decryption takes place.</summary>
			NCRYPT_UNPROTECT_NO_DECRYPT = 0x00000001,

			/// <summary>Requests that the key service provider not display a user interface.</summary>
			NCRYPT_SILENT_FLAG = 0x00000040,
		}

		/// <summary>
		/// <para>The <c>NCryptCloseProtectionDescriptor</c> function zeros and frees a protection descriptor object and releases its handle.</para>
		/// </summary>
		/// <param name="hDescriptor">
		/// <para>Handle of a protection descriptor created by calling NCryptCreateProtectionDescriptor.</para>
		/// </param>
		/// <returns>
		/// <para>
		/// Returns a status code that indicates the success or failure of the function. Possible return codes include, but are not limited
		/// to, the following.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>ERROR_SUCCESS</term>
		/// <term>The function was successful.</term>
		/// </item>
		/// <item>
		/// <term>NTE_INVALID_HANDLE</term>
		/// <term>The handle specified by the hDescriptor parameter cannot be NULL and it must represent a valid descriptor.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/ncryptprotect/nf-ncryptprotect-ncryptcloseprotectiondescriptor
		// SECURITY_STATUS NCryptCloseProtectionDescriptor( NCRYPT_DESCRIPTOR_HANDLE hDescriptor );
		[DllImport(Lib.Ncrypt, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("ncryptprotect.h", MSDNShortId = "523FD83E-85A3-4A0E-BA8D-2F27F82C1072")]
		public static extern HRESULT NCryptCloseProtectionDescriptor(NCRYPT_DESCRIPTOR_HANDLE hDescriptor);

		/// <summary>
		/// <para>The <c>NCryptCreateProtectionDescriptor</c> function retrieves a handle to a protection descriptor object.</para>
		/// </summary>
		/// <param name="pwszDescriptorString">
		/// <para>
		/// Null-terminated Unicode string that contains a protection descriptor rule string or a registered display name for the rule.
		/// </para>
		/// <para>
		/// If you specify the display name and you want this function to look in the registry for the associated protection descriptor rule
		/// string, you must set the dwFlags parameter to <c>NCRYPT_NAMED_DESCRIPTOR_FLAG</c>.
		/// </para>
		/// </param>
		/// <param name="dwFlags">
		/// <para>
		/// Flag that specifies whether the string in pwszDescriptorString represents the display name of a protection descriptor and, if so,
		/// where in the registry the function should search for the associated protection rule string. The following value combinations can
		/// be set:
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <term>
		/// To indicate that the value set in the pwszDescriptorString parameter is a complete protection descriptor rule string rather than
		/// a display name, set the dwFlags parameter to zero (0).
		/// </term>
		/// </item>
		/// <item>
		/// <term>
		/// To indicate that the string is a display name and that it is saved, along with its associated descriptor rule string, in the
		/// <c>HKEY_LOCAL_MACHINE</c> registry hive, bitwise-OR the <c>NCRYPT_NAMED_DESCRIPTOR_FLAG</c> value and the
		/// <c>NCRYPT_MACHINE_KEY_FLAG</c> value.
		/// </term>
		/// </item>
		/// <item>
		/// <term>
		/// To indicate that the string is a display name and that it is saved, along with its associated descriptor string rule, in the
		/// <c>HKEY_CURRENT_USER</c> registry hive, set only the <c>NCRYPT_NAMED_DESCRIPTOR_FLAG</c> value. That is, there is no unique flag
		/// to specify the current user registry hive.
		/// </term>
		/// </item>
		/// </list>
		/// <para>
		/// <c>Note</c> To associate a descriptor rule with a display name and save both in the registry, call the
		/// NCryptRegisterProtectionDescriptorName function.
		/// </para>
		/// </param>
		/// <param name="phDescriptor">
		/// <para>Pointer to a protection descriptor object handle.</para>
		/// </param>
		/// <returns>
		/// <para>
		/// Returns a status code that indicates the success or failure of the function. Possible return codes include, but are not limited
		/// to, the following.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>ERROR_SUCCESS</term>
		/// <term>The function was successful.</term>
		/// </item>
		/// <item>
		/// <term>NTE_INVALID_PARAMETER</term>
		/// <term>
		/// The phDescriptor parameter cannot be NULL. The pwszDescriptorString parameter cannot be NULL and it cannot be an empty sting.
		/// </term>
		/// </item>
		/// <item>
		/// <term>NTE_BAD_FLAGS</term>
		/// <term>The dwFlags parameter must be NCRYPT_MACHINE_KEY_FLAG or NCRYPT_NAMED_DESCRIPTOR_FLAG.</term>
		/// </item>
		/// <item>
		/// <term>NTE_NO_MEMORY</term>
		/// <term>Memory could not be allocated to retrieve the registered protection descriptor string.</term>
		/// </item>
		/// <item>
		/// <term>NTE_NOT_FOUND</term>
		/// <term>The protection descriptor name specified in the pwszDescriptorString parameter could not be found.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The protection descriptor object created by this function is an internal data structure that contains information about the
		/// descriptor. You cannot use it directly. Your application can, however, use the returned handle in the following functions:
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <term>NCryptCloseProtectionDescriptor</term>
		/// </item>
		/// <item>
		/// <term>NCryptGetProtectionDescriptorInfo</term>
		/// </item>
		/// <item>
		/// <term>NCryptProtectSecret</term>
		/// </item>
		/// <item>
		/// <term>NCryptProtectSecret</term>
		/// </item>
		/// <item>
		/// <term>NCryptUnprotectSecret</term>
		/// </item>
		/// <item>
		/// <term>NCryptStreamOpenToProtect</term>
		/// </item>
		/// </list>
		/// <para>The following examples show protection descriptor rule strings:</para>
		/// <list type="bullet">
		/// <item>
		/// <term>"SID=S-1-5-21-4392301 AND SID=S-1-5-21-3101812"</term>
		/// </item>
		/// <item>
		/// <term>"SDDL=O:S-1-5-5-0-290724G:SYD:(A;;CCDC;;;S-1-5-5-0-290724)(A;;DC;;;WD)"</term>
		/// </item>
		/// <item>
		/// <term>"LOCAL=user"</term>
		/// </item>
		/// <item>
		/// <term>"LOCAL=machine"</term>
		/// </item>
		/// <item>
		/// <term>"WEBCREDENTIALS=MyPasswordName"</term>
		/// </item>
		/// <item>
		/// <term>"WEBCREDENTIALS=MyPasswordName,myweb.com"</term>
		/// </item>
		/// </list>
		/// <para>
		/// You can use the NCryptRegisterProtectionDescriptorName function to associate a display name with a rule string and save both in
		/// the registry.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/ncryptprotect/nf-ncryptprotect-ncryptcreateprotectiondescriptor
		// SECURITY_STATUS NCryptCreateProtectionDescriptor( LPCWSTR pwszDescriptorString, DWORD dwFlags, NCRYPT_DESCRIPTOR_HANDLE
		// *phDescriptor );
		[DllImport(Lib.Ncrypt, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("ncryptprotect.h", MSDNShortId = "BA6B15AC-2CD8-4D9A-817F-65CF9C09D22C")]
		public static extern HRESULT NCryptCreateProtectionDescriptor([MarshalAs(UnmanagedType.LPWStr)] string pwszDescriptorString, CreateProtectionDescriptorFlags dwFlags, out SafeNCRYPT_DESCRIPTOR_HANDLE phDescriptor);

		/// <summary>
		/// <para>The <c>NCryptGetProtectionDescriptorInfo</c> function retrieves a protection descriptor rule string.</para>
		/// </summary>
		/// <param name="hDescriptor">
		/// <para>Protection descriptor handle created by calling NCryptCreateProtectionDescriptor.</para>
		/// </param>
		/// <param name="pMemPara">
		/// <para>
		/// Pointer to an NCRYPT_ALLOC_PARA structure that you can use to specify custom memory management functions. If you set this
		/// argument to <c>NULL</c>, the LocalAlloc function is used internally to allocate memory and your application must call LocalFree
		/// to release memory pointed to by the ppvInfo parameter.
		/// </para>
		/// </param>
		/// <param name="dwInfoType">
		/// <para>Specifies how to return descriptor information to the ppvInfo parameter. This can be the following value:</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>NCRYPT_PROTECTION_INFO_TYPE_DESCRIPTOR_STRING</term>
		/// <term>The ppvInfo argument returns the descriptor rule string.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="ppvInfo">
		/// <para>Pointer to the descriptor information.</para>
		/// </param>
		/// <returns>
		/// <para>
		/// Returns a status code that indicates the success or failure of the function. Possible return codes include, but are not limited
		/// to, the following.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>ERROR_SUCCESS</term>
		/// <term>The function was successful.</term>
		/// </item>
		/// <item>
		/// <term>NTE_INVALID_PARAMETER</term>
		/// <term>The ppvInfo parameter cannot be NULL.</term>
		/// </item>
		/// <item>
		/// <term>NTE_NOT_SUPPORTED</term>
		/// <term>An unsupported value was specified in the dwInfoType parameter.</term>
		/// </item>
		/// <item>
		/// <term>NTE_INVALID_HANDLE</term>
		/// <term>The handle specified by the hDescriptor parameter is not valid.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/ncryptprotect/nf-ncryptprotect-ncryptgetprotectiondescriptorinfo
		// SECURITY_STATUS NCryptGetProtectionDescriptorInfo( NCRYPT_DESCRIPTOR_HANDLE hDescriptor, const NCRYPT_ALLOC_PARA *pMemPara, DWORD
		// dwInfoType, void **ppvInfo );
		[DllImport(Lib.Ncrypt, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("ncryptprotect.h", MSDNShortId = "EF4777D5-E218-4868-8D25-58E0EF8C9D30")]
		public static extern HRESULT NCryptGetProtectionDescriptorInfo(NCRYPT_DESCRIPTOR_HANDLE hDescriptor, in NCRYPT_ALLOC_PARA pMemPara, ProtectionDescriptorInfoType dwInfoType, out IntPtr ppvInfo);

		/// <summary>
		/// <para>The <c>NCryptGetProtectionDescriptorInfo</c> function retrieves a protection descriptor rule string.</para>
		/// </summary>
		/// <param name="hDescriptor">
		/// <para>Protection descriptor handle created by calling NCryptCreateProtectionDescriptor.</para>
		/// </param>
		/// <param name="pMemPara">
		/// <para>
		/// Pointer to an NCRYPT_ALLOC_PARA structure that you can use to specify custom memory management functions. If you set this
		/// argument to <c>NULL</c>, the LocalAlloc function is used internally to allocate memory and your application must call LocalFree
		/// to release memory pointed to by the ppvInfo parameter.
		/// </para>
		/// </param>
		/// <param name="dwInfoType">
		/// <para>Specifies how to return descriptor information to the ppvInfo parameter. This can be the following value:</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>NCRYPT_PROTECTION_INFO_TYPE_DESCRIPTOR_STRING</term>
		/// <term>The ppvInfo argument returns the descriptor rule string.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="ppvInfo">
		/// <para>Pointer to the descriptor information.</para>
		/// </param>
		/// <returns>
		/// <para>
		/// Returns a status code that indicates the success or failure of the function. Possible return codes include, but are not limited
		/// to, the following.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>ERROR_SUCCESS</term>
		/// <term>The function was successful.</term>
		/// </item>
		/// <item>
		/// <term>NTE_INVALID_PARAMETER</term>
		/// <term>The ppvInfo parameter cannot be NULL.</term>
		/// </item>
		/// <item>
		/// <term>NTE_NOT_SUPPORTED</term>
		/// <term>An unsupported value was specified in the dwInfoType parameter.</term>
		/// </item>
		/// <item>
		/// <term>NTE_INVALID_HANDLE</term>
		/// <term>The handle specified by the hDescriptor parameter is not valid.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/ncryptprotect/nf-ncryptprotect-ncryptgetprotectiondescriptorinfo
		// SECURITY_STATUS NCryptGetProtectionDescriptorInfo( NCRYPT_DESCRIPTOR_HANDLE hDescriptor, const NCRYPT_ALLOC_PARA *pMemPara, DWORD
		// dwInfoType, void **ppvInfo );
		[DllImport(Lib.Ncrypt, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("ncryptprotect.h", MSDNShortId = "EF4777D5-E218-4868-8D25-58E0EF8C9D30")]
		public static extern HRESULT NCryptGetProtectionDescriptorInfo(NCRYPT_DESCRIPTOR_HANDLE hDescriptor, [Optional] IntPtr pMemPara, ProtectionDescriptorInfoType dwInfoType, out IntPtr ppvInfo);

		/// <summary>
		/// <para>
		/// The <c>NCryptProtectSecret</c> function encrypts data to a specified protection descriptor. Call NCryptUnprotectSecret to decrypt
		/// the data.
		/// </para>
		/// </summary>
		/// <param name="hDescriptor">
		/// <para>Handle of the protection descriptor object. Create the handle by calling NCryptCreateProtectionDescriptor.</para>
		/// </param>
		/// <param name="dwFlags">
		/// <para>The flag can be zero or the following value.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>NCRYPT_SILENT_FLAG</term>
		/// <term>Requests that the key service provider not display a user interface.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="pbData">
		/// <para>Pointer to the byte array to be protected.</para>
		/// </param>
		/// <param name="cbData">
		/// <para>Number of bytes in the binary array specified by the pbData parameter.</para>
		/// </param>
		/// <param name="pMemPara">
		/// <para>
		/// Pointer to an NCRYPT_ALLOC_PARA structure that you can use to specify custom memory management functions. If you set this
		/// argument to <c>NULL</c>, the LocalAlloc function is used internally to allocate memory and your application must call LocalFree
		/// to release memory pointed to by the ppbProtectedBlob parameter.
		/// </para>
		/// </param>
		/// <param name="hWnd">
		/// <para>Handle to the parent window of the user interface, if any, to be displayed.</para>
		/// </param>
		/// <param name="ppbProtectedBlob">
		/// <para>Address of a variable that receives a pointer to the encrypted data.</para>
		/// </param>
		/// <param name="pcbProtectedBlob">
		/// <para>
		/// Pointer to a <c>ULONG</c> variable that contains the size, in bytes, of the encrypted data pointed to by the ppbProtectedBlob variable.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>
		/// Returns a status code that indicates the success or failure of the function. Possible return codes include, but are not limited
		/// to, the following.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>ERROR_SUCCESS</term>
		/// <term>The function was successful.</term>
		/// </item>
		/// <item>
		/// <term>NTE_INVALID_PARAMETER</term>
		/// <term>
		/// The pbData, ppbProtectedBlob, and pcbProtectedBlob parameters cannot be NULL. The cbData parameter cannot be less than one.
		/// </term>
		/// </item>
		/// <item>
		/// <term>NTE_NO_MEMORY</term>
		/// <term>Insufficient memory exists to allocate the content encryption key.</term>
		/// </item>
		/// <item>
		/// <term>NTE_INVALID_HANDLE</term>
		/// <term>The handle specified by the hDescriptor parameter is not valid.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// Use the <c>NCryptProtectSecret</c> function to protect keys, key material, and passwords. Use the NCryptStreamOpenToProtect and
		/// the NCryptStreamUpdate functions to encrypt larger messages.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/ncryptprotect/nf-ncryptprotect-ncryptprotectsecret SECURITY_STATUS
		// NCryptProtectSecret( NCRYPT_DESCRIPTOR_HANDLE hDescriptor, DWORD dwFlags, const BYTE *pbData, ULONG cbData, const
		// NCRYPT_ALLOC_PARA *pMemPara, HWND hWnd, BYTE **ppbProtectedBlob, ULONG *pcbProtectedBlob );
		[DllImport(Lib.Ncrypt, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("ncryptprotect.h", MSDNShortId = "8726F92B-34D5-4696-8803-3D7F50F1006D")]
		public static extern HRESULT NCryptProtectSecret(NCRYPT_DESCRIPTOR_HANDLE hDescriptor, ProtectFlags dwFlags, [In] IntPtr pbData, uint cbData, in NCRYPT_ALLOC_PARA pMemPara, HWND hWnd,
			out IntPtr ppbProtectedBlob, out uint pcbProtectedBlob);

		/// <summary>
		/// <para>
		/// The <c>NCryptProtectSecret</c> function encrypts data to a specified protection descriptor. Call NCryptUnprotectSecret to decrypt
		/// the data.
		/// </para>
		/// </summary>
		/// <param name="hDescriptor">
		/// <para>Handle of the protection descriptor object. Create the handle by calling NCryptCreateProtectionDescriptor.</para>
		/// </param>
		/// <param name="dwFlags">
		/// <para>The flag can be zero or the following value.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>NCRYPT_SILENT_FLAG</term>
		/// <term>Requests that the key service provider not display a user interface.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="pbData">
		/// <para>Pointer to the byte array to be protected.</para>
		/// </param>
		/// <param name="cbData">
		/// <para>Number of bytes in the binary array specified by the pbData parameter.</para>
		/// </param>
		/// <param name="pMemPara">
		/// <para>
		/// Pointer to an NCRYPT_ALLOC_PARA structure that you can use to specify custom memory management functions. If you set this
		/// argument to <c>NULL</c>, the LocalAlloc function is used internally to allocate memory and your application must call LocalFree
		/// to release memory pointed to by the ppbProtectedBlob parameter.
		/// </para>
		/// </param>
		/// <param name="hWnd">
		/// <para>Handle to the parent window of the user interface, if any, to be displayed.</para>
		/// </param>
		/// <param name="ppbProtectedBlob">
		/// <para>Address of a variable that receives a pointer to the encrypted data.</para>
		/// </param>
		/// <param name="pcbProtectedBlob">
		/// <para>
		/// Pointer to a <c>ULONG</c> variable that contains the size, in bytes, of the encrypted data pointed to by the ppbProtectedBlob variable.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>
		/// Returns a status code that indicates the success or failure of the function. Possible return codes include, but are not limited
		/// to, the following.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>ERROR_SUCCESS</term>
		/// <term>The function was successful.</term>
		/// </item>
		/// <item>
		/// <term>NTE_INVALID_PARAMETER</term>
		/// <term>
		/// The pbData, ppbProtectedBlob, and pcbProtectedBlob parameters cannot be NULL. The cbData parameter cannot be less than one.
		/// </term>
		/// </item>
		/// <item>
		/// <term>NTE_NO_MEMORY</term>
		/// <term>Insufficient memory exists to allocate the content encryption key.</term>
		/// </item>
		/// <item>
		/// <term>NTE_INVALID_HANDLE</term>
		/// <term>The handle specified by the hDescriptor parameter is not valid.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// Use the <c>NCryptProtectSecret</c> function to protect keys, key material, and passwords. Use the NCryptStreamOpenToProtect and
		/// the NCryptStreamUpdate functions to encrypt larger messages.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/ncryptprotect/nf-ncryptprotect-ncryptprotectsecret SECURITY_STATUS
		// NCryptProtectSecret( NCRYPT_DESCRIPTOR_HANDLE hDescriptor, DWORD dwFlags, const BYTE *pbData, ULONG cbData, const
		// NCRYPT_ALLOC_PARA *pMemPara, HWND hWnd, BYTE **ppbProtectedBlob, ULONG *pcbProtectedBlob );
		[DllImport(Lib.Ncrypt, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("ncryptprotect.h", MSDNShortId = "8726F92B-34D5-4696-8803-3D7F50F1006D")]
		public static extern HRESULT NCryptProtectSecret(NCRYPT_DESCRIPTOR_HANDLE hDescriptor, ProtectFlags dwFlags, [In] IntPtr pbData, uint cbData, [Optional] IntPtr pMemPara, HWND hWnd,
			out IntPtr ppbProtectedBlob, out uint pcbProtectedBlob);

		/// <summary>
		/// <para>
		/// The <c>NCryptQueryProtectionDescriptorName</c> function retrieves the protection descriptor rule string associated with a
		/// registered descriptor display name.
		/// </para>
		/// </summary>
		/// <param name="pwszName">
		/// <para>
		/// The registered display name for the protection descriptor. Register a name by calling the NCryptRegisterProtectionDescriptorName function.
		/// </para>
		/// </param>
		/// <param name="pwszDescriptorString">
		/// <para>
		/// A null-terminated Unicode string that contains the protection descriptor rule. Set this value to <c>NULL</c> and set the size of
		/// the descriptor string pointed to by pcDescriptorString argument to zero on your initial call to this function. For more
		/// information, see Remarks.
		/// </para>
		/// </param>
		/// <param name="pcDescriptorString">
		/// <para>
		/// Pointer to a variable that contains the number of characters in the string retrieved in the pwszDescriptorString parameter. Set
		/// the variable to zero on your initial call to this function. For more information, see Remarks.
		/// </para>
		/// </param>
		/// <param name="dwFlags">
		/// <para>
		/// Flag that specifies which registry hive to query for the registered name. This can be zero to look in the
		/// <c>HKEY_CURRENT_USER</c> hive or you can specify <c>NCRYPT_MACHINE_KEY_FLAG</c> to query the <c>HKEY_LOCAL_MACHINE</c> hive.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>
		/// Returns a status code that indicates the success or failure of the function. Possible return codes include, but are not limited
		/// to, the following.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>ERROR_SUCCESS</term>
		/// <term>The function was successful.</term>
		/// </item>
		/// <item>
		/// <term>NTE_INVALID_PARAMETER</term>
		/// <term>The pwszName parameter cannot be NULL, and the value pointed to by the parameter cannot be an empty string.</term>
		/// </item>
		/// <item>
		/// <term>NTE_BAD_FLAGS</term>
		/// <term>The dwFlags parameter must be zero or NCRYPT_MACHINE_KEY_FLAG.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// To retrieve a protection descriptor rule string, you must call this function twice. The first time you call, set the
		/// pwszDescriptorString argument to <c>NULL</c> and the value pointed to by the pcDescriptorString argument to zero. Your first call
		/// retrieves the number of characters in the descriptor string. Use this number to allocate memory for the string and retrieve a
		/// pointer to the allocated buffer. To retrieve the string, call the function again using the pointer.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/ncryptprotect/nf-ncryptprotect-ncryptqueryprotectiondescriptorname
		// SECURITY_STATUS NCryptQueryProtectionDescriptorName( LPCWSTR pwszName, LPWSTR pwszDescriptorString, SIZE_T *pcDescriptorString,
		// DWORD dwFlags );
		[DllImport(Lib.Ncrypt, SetLastError = false, ExactSpelling = true, CharSet = CharSet.Unicode)]
		[PInvokeData("ncryptprotect.h", MSDNShortId = "32953AEC-01EE-4ED1-80F3-29963F43004F")]
		public static extern HRESULT NCryptQueryProtectionDescriptorName(string pwszName, StringBuilder pwszDescriptorString, out SizeT pcDescriptorString, ProtectionDescriptorNameFlags dwFlags);

		/// <summary>
		/// <para>
		/// The <c>NCryptRegisterProtectionDescriptorName</c> function registers the display name and the associated rule string for a
		/// protection descriptor.
		/// </para>
		/// </summary>
		/// <param name="pwszName">
		/// <para>Pointer to a null-terminated Unicode string that contains the display name of the descriptor to be registered.</para>
		/// </param>
		/// <param name="pwszDescriptorString">
		/// <para>
		/// Pointer to a null-terminated Unicode string that contains a protection descriptor rule. If this parameter is <c>NULL</c> or the
		/// string is empty, the registry value previously created for the pwszName parameter will be deleted.
		/// </para>
		/// </param>
		/// <param name="dwFlags">
		/// <para>
		/// A constant that indicates the registry hive under which to register the new entry. If this value is zero (0), the registry root
		/// is <c>HKEY_CURRENT_USER</c>. If this value is <c>NCRYPT_MACHINE_KEY_FLAG</c>, the root is <c>HKEY_LOCAL_MACHINE</c>.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>
		/// Returns a status code that indicates the success or failure of the function. Possible return codes include, but are not limited
		/// to, the following.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>ERROR_SUCCESS</term>
		/// <term>The function was successful.</term>
		/// </item>
		/// <item>
		/// <term>NTE_INVALID_PARAMETER</term>
		/// <term>The pwszName parameter cannot be NULL, and the value pointed to by the parameter cannot be an empty string.</term>
		/// </item>
		/// <item>
		/// <term>NTE_BAD_FLAGS</term>
		/// <term>The dwFlags parameter must be zero or NCRYPT_MACHINE_KEY_FLAG.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The registry key created by using this function is not volatile. The information is stored in a file and preserved when the
		/// computer shuts down.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/ncryptprotect/nf-ncryptprotect-ncryptregisterprotectiondescriptorname
		// SECURITY_STATUS NCryptRegisterProtectionDescriptorName( LPCWSTR pwszName, LPCWSTR pwszDescriptorString, DWORD dwFlags );
		[DllImport(Lib.Ncrypt, SetLastError = false, ExactSpelling = true, CharSet = CharSet.Unicode)]
		[PInvokeData("ncryptprotect.h", MSDNShortId = "DAB03CB2-630F-4BB3-93BD-06BE9126B1C4")]
		public static extern HRESULT NCryptRegisterProtectionDescriptorName(string pwszName, string pwszDescriptorString, ProtectionDescriptorNameFlags dwFlags);

		/// <summary>
		/// <para>
		/// The <c>NCryptStreamClose</c> function closes a data protection stream object opened by using the NCryptStreamOpenToProtect or
		/// NCryptStreamOpenToUnprotect functions.
		/// </para>
		/// </summary>
		/// <param name="hStream">
		/// <para>Data stream handle returned by NCryptStreamOpenToProtect or NCryptStreamOpenToUnprotect.</para>
		/// </param>
		/// <returns>
		/// <para>
		/// Returns a status code that indicates the success or failure of the function. Possible return codes include, but are not limited
		/// to, the following.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>ERROR_SUCCESS</term>
		/// <term>The function was successful.</term>
		/// </item>
		/// <item>
		/// <term>NTE_INVALID_HANDLE</term>
		/// <term>The handle specified by the hStream parameter is not valid.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/ncryptprotect/nf-ncryptprotect-ncryptstreamclose SECURITY_STATUS
		// NCryptStreamClose( NCRYPT_STREAM_HANDLE hStream );
		[DllImport(Lib.Ncrypt, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("ncryptprotect.h", MSDNShortId = "770640F2-04C7-4512-8004-41F4ECDC110E")]
		public static extern HRESULT NCryptStreamClose(NCRYPT_STREAM_HANDLE hStream);

		/// <summary>
		/// <para>
		/// The <c>NCryptStreamOpenToProtect</c> function opens a stream object that can be used to encrypt large amounts of data to a given
		/// protection descriptor. Call NCryptStreamUpdate to encrypt the content. To encrypt smaller messages such as keys and passwords,
		/// call NCryptProtectSecret.
		/// </para>
		/// </summary>
		/// <param name="hDescriptor">
		/// <para>Handle of the protection descriptor. Create the handle by calling NCryptCreateProtectionDescriptor.</para>
		/// </param>
		/// <param name="dwFlags">
		/// <para>The flag can be zero or the following value.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>NCRYPT_SILENT_FLAG</term>
		/// <term>Requests that the key service provider not display a user interface.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="hWnd">
		/// <para>Handle to the parent window of the user interface, if any, to be displayed.</para>
		/// </param>
		/// <param name="pStreamInfo">
		/// <para>
		/// Pointer to an NCRYPT_PROTECT_STREAM_INFO structure that contains the address of a user defined callback function to receive the
		/// encrypted data and a pointer to user-defined context data.
		/// </para>
		/// </param>
		/// <param name="phStream">
		/// <para>Pointer to the stream object handle.</para>
		/// </param>
		/// <returns>
		/// <para>
		/// Returns a status code that indicates the success or failure of the function. Possible return codes include, but are not limited
		/// to, the following.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>ERROR_SUCCESS</term>
		/// <term>The function was successful.</term>
		/// </item>
		/// <item>
		/// <term>NTE_BAD_FLAGS</term>
		/// <term>The dwFlags parameter must contain zero (0), NCRYPT_MACHINE_KEY_FLAG, or NCRYPT_SILENT_FLAG.</term>
		/// </item>
		/// <item>
		/// <term>NTE_INVALID_HANDLE</term>
		/// <term>The handle specified by the hDescriptor parameter is not valid.</term>
		/// </item>
		/// <item>
		/// <term>NTE_INVALID_PARAMETER</term>
		/// <term>
		/// The phStream and pStreamInfo parameters cannot be NULL. The callback function pointed to by the pfnStreamOutput member of the
		/// NCRYPT_PROTECT_STREAM_INFO structure pointed to by the pStreamInfo parameter cannot be NULL.
		/// </term>
		/// </item>
		/// <item>
		/// <term>NTE_NO_MEMORY</term>
		/// <term>There was insufficient memory to allocate a data stream.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The <c>NCryptStreamOpenToProtect</c> function creates an internal stream object that can be used to encrypt large messages. You
		/// cannot use the object directly. Instead, you must use the object handle returned by this function.
		/// </para>
		/// <para>
		/// Call this function before calling the NCryptStreamUpdate function. If you are encrypting a large file, use
		/// <c>NCryptStreamUpdate</c> in a loop that advances through the file block by block, encrypting each block as it advances and
		/// notifying your callback when each block is finished. For more information, see <c>NCryptStreamUpdate</c>.
		/// </para>
		/// <para>
		/// The <c>NCryptStreamOpenToProtect</c> function writes the unencrypted protection descriptor rule string to the stream object
		/// header so that NCryptStreamOpenToUnprotect will be able to start the decrypting the stream by using the same protector used
		/// during encryption.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/ncryptprotect/nf-ncryptprotect-ncryptstreamopentoprotect SECURITY_STATUS
		// NCryptStreamOpenToProtect( NCRYPT_DESCRIPTOR_HANDLE hDescriptor, DWORD dwFlags, HWND hWnd, NCRYPT_PROTECT_STREAM_INFO
		// *pStreamInfo, NCRYPT_STREAM_HANDLE *phStream );
		[DllImport(Lib.Ncrypt, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("ncryptprotect.h", MSDNShortId = "7DE74BB1-1B84-4721-BE4A-4D2661E93E00")]
		public static extern HRESULT NCryptStreamOpenToProtect(NCRYPT_DESCRIPTOR_HANDLE hDescriptor, ProtectFlags dwFlags, HWND hWnd, in NCRYPT_PROTECT_STREAM_INFO pStreamInfo, out SafeNCRYPT_STREAM_HANDLE phStream);

		/// <summary>
		/// <para>
		/// The <c>NCryptStreamOpenToUnprotect</c> function opens a stream object that can be used to decrypt large amounts of data to the
		/// same protection descriptor used for encryption. Call NCryptStreamUpdate to perform the decryption. To decrypt smaller messages
		/// such as keys and passwords, call NCryptUnprotectSecret.
		/// </para>
		/// </summary>
		/// <param name="pStreamInfo">
		/// <para>
		/// Pointer to an NCRYPT_PROTECT_STREAM_INFO structure that contains the address of a user defined callback function to receive the
		/// decrypted data and a pointer to user-defined context data.
		/// </para>
		/// </param>
		/// <param name="dwFlags">
		/// <para>A flag that specifies additional information for the key service provider. This can be zero or the following value.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>NCRYPT_SILENT_FLAG</term>
		/// <term>Requests that the key service provider not display a user interface.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="hWnd">
		/// <para>Handle to the parent window of the user interface, if any, to be displayed.</para>
		/// </param>
		/// <param name="phStream">
		/// <para>Pointer to the handle of the decrypted stream of data.</para>
		/// </param>
		/// <returns>
		/// <para>
		/// Returns a status code that indicates the success or failure of the function. Possible return codes include, but are not limited
		/// to, the following.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>ERROR_SUCCESS</term>
		/// <term>The function was successful.</term>
		/// </item>
		/// <item>
		/// <term>NTE_BAD_FLAGS</term>
		/// <term>The dwFlags parameter must contain zero (0) or NCRYPT_SILENT_FLAG.</term>
		/// </item>
		/// <item>
		/// <term>NTE_INVALID_PARAMETER</term>
		/// <term>
		/// The phStream and pStreamInfo parameters cannot be NULL. The callback function pointed to by the pfnStreamOutput member of the
		/// NCRYPT_PROTECT_STREAM_INFO structure pointed to by the pStreamInfo parameter cannot be NULL.
		/// </term>
		/// </item>
		/// <item>
		/// <term>NTE_NO_MEMORY</term>
		/// <term>There was insufficient memory to allocate a data stream.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The <c>NCryptStreamOpenToUnprotect</c> function creates an internal stream object that can be used to encrypt large messages. You
		/// cannot use the object directly. Instead, you must use the object handle returned by this function.
		/// </para>
		/// <para>
		/// Call this function before calling the NCryptStreamUpdate function. If you are encrypting a large file, use
		/// <c>NCryptStreamUpdate</c> in a loop that advances through the file block by block, encrypting each block as it advances and
		/// notifying your callback when each block is finished. For more information, see <c>NCryptStreamUpdate</c>.
		/// </para>
		/// <para>
		/// The <c>NCryptStreamOpenToUnprotect</c> function retrieves the unencrypted protection descriptor rule string from the stream
		/// header. The rule string is placed in the header by the <c>NCryptStreamOpenToUnprotect</c> function.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/ncryptprotect/nf-ncryptprotect-ncryptstreamopentounprotect SECURITY_STATUS
		// NCryptStreamOpenToUnprotect( NCRYPT_PROTECT_STREAM_INFO *pStreamInfo, DWORD dwFlags, HWND hWnd, NCRYPT_STREAM_HANDLE *phStream );
		[DllImport(Lib.Ncrypt, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("ncryptprotect.h", MSDNShortId = "9848082E-EDDA-4DA1-9896-42EAF2ADFAB4")]
		public static extern HRESULT NCryptStreamOpenToUnprotect(in NCRYPT_PROTECT_STREAM_INFO pStreamInfo, ProtectFlags dwFlags, HWND hWnd, out SafeNCRYPT_STREAM_HANDLE phStream);

		/// <summary>
		/// <para>
		/// [Some information relates to pre-released product which may be substantially modified before it's commercially released.
		/// Microsoft makes no warranties, express or implied, with respect to the information provided here.]
		/// </para>
		/// <para>
		/// Opens a stream object that can be used to decrypt large amounts of data to the same protection descriptor used for
		/// encryption.Call NCryptStreamUpdate to perform the decryption. To decrypt smaller messages such as keys and passwords, call NCryptUnprotectSecret.
		/// </para>
		/// </summary>
		/// <param name="pStreamInfo">
		/// <para>A pointer to NCRYPT_PROTECT_STREAM_INFO_EX.</para>
		/// </param>
		/// <param name="dwFlags">
		/// <para>Only the NCRYPT_SILENT_FLAG is supported.</para>
		/// </param>
		/// <param name="hWnd">
		/// <para>A window handle to be used as the parent of any user interface that is displayed.</para>
		/// </param>
		/// <param name="phStream">
		/// <para>Receives a pointer to a stream handle.</para>
		/// </param>
		/// <returns>
		/// <para>
		/// Returns a status code that indicates the success or failure of the function. Possible return codes include, but are not limited to:
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <term>ERROR_SUCCESS</term>
		/// </item>
		/// <item>
		/// <term>NTE_INVALID_PARAMETER</term>
		/// </item>
		/// <item>
		/// <term>NTE_BAD_FLAGS</term>
		/// </item>
		/// <item>
		/// <term>NTE_BAD_DATA</term>
		/// </item>
		/// <item>
		/// <term>NTE_NO_MEMORY</term>
		/// </item>
		/// <item>
		/// <term>NTE_NOT_FOUND</term>
		/// </item>
		/// <item>
		/// <term>NTE_NOT_SUPPORTED</term>
		/// </item>
		/// <item>
		/// <term>NTE_INVALID_HANDLE</term>
		/// </item>
		/// <item>
		/// <term>NTE_BAD_KEY</term>
		/// </item>
		/// <item>
		/// <term>NTE_BAD_PROVIDER</term>
		/// </item>
		/// <item>
		/// <term>NTE_BAD_TYPE</term>
		/// </item>
		/// <item>
		/// <term>NTE_DECRYPTION_FAILURE</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/ncryptprotect/nf-ncryptprotect-ncryptstreamopentounprotectex SECURITY_STATUS
		// NCryptStreamOpenToUnprotectEx( NCRYPT_PROTECT_STREAM_INFO_EX *pStreamInfo, DWORD dwFlags, HWND hWnd, NCRYPT_STREAM_HANDLE
		// *phStream );
		[DllImport(Lib.Ncrypt, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("ncryptprotect.h", MSDNShortId = "8E607F4F-4A0F-4796-8F40-D232687815AF")]
		public static extern HRESULT NCryptStreamOpenToUnprotectEx(in NCRYPT_PROTECT_STREAM_INFO_EX pStreamInfo, ProtectFlags dwFlags, HWND hWnd, out SafeNCRYPT_STREAM_HANDLE phStream);

		/// <summary>
		/// <para>The <c>NCryptStreamUpdate</c> function encrypts and decrypts blocks of data.</para>
		/// </summary>
		/// <param name="hStream">
		/// <para>Handle to the stream object created by calling NCryptStreamOpenToProtect or NCryptStreamOpenToUnprotect.</para>
		/// </param>
		/// <param name="pbData">
		/// <para>Pointer to the byte array to be processed.</para>
		/// </param>
		/// <param name="cbData">
		/// <para>Number of bytes in the binary array specified by the pbData parameter.</para>
		/// </param>
		/// <param name="fFinal">
		/// <para>A Boolean value that specifies whether the last block of data has been processed.</para>
		/// </param>
		/// <returns>
		/// <para>
		/// Returns a status code that indicates the success or failure of the function. Possible return codes include, but are not limited
		/// to, the following.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>ERROR_SUCCESS</term>
		/// <term>The function was successful.</term>
		/// </item>
		/// <item>
		/// <term>NTE_BAD_DATA</term>
		/// <term>The content could not be decoded.</term>
		/// </item>
		/// <item>
		/// <term>NTE_INVALID_HANDLE</term>
		/// <term>The stream handle pointed to by the hStream parameter is not valid.</term>
		/// </item>
		/// <item>
		/// <term>NTE_NO_MEMORY</term>
		/// <term>There was insufficient memory available to process the content.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>You must call NCryptStreamOpenToProtect or NCryptStreamOpenToUnprotect to open a stream before calling <c>NCryptStreamUpdate</c></para>
		/// <para>
		/// Messages can be so large that processing them all at once by storing the entire message in memory can be difficult. It is
		/// possible, however, to process large messages by partitioning the data to be processed into manageable blocks.
		/// </para>
		/// <para>
		/// To do this, use <c>NCryptStreamUpdate</c> in a loop that advances through the file block by block. As the streamed message is
		/// processed, the resulting output data is passed back to your application by using a callback function that you specify. This is
		/// shown by the following example. For more information about the callback function, see PFNCryptStreamOutputCallback.
		/// </para>
		/// <para>
		/// <c>Note</c> We recommend against using too small of a block size. Small blocks require more calls and therefore more calling
		/// overhead. Further, the streaming APIs are optimized for larger blocks. You should experiment to find the best block size for the
		/// data you must process.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/ncryptprotect/nf-ncryptprotect-ncryptstreamupdate SECURITY_STATUS
		// NCryptStreamUpdate( NCRYPT_STREAM_HANDLE hStream, const BYTE *pbData, SIZE_T cbData, BOOL fFinal );
		[DllImport(Lib.Ncrypt, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("ncryptprotect.h", MSDNShortId = "417F9267-6055-489C-AF26-BEF5E17CB8B4")]
		public static extern HRESULT NCryptStreamUpdate(NCRYPT_STREAM_HANDLE hStream, IntPtr pbData, SizeT cbData, [MarshalAs(UnmanagedType.Bool)] bool fFinal);

		/// <summary>
		/// <para>
		/// The <c>NCryptUnprotectSecret</c> function decrypts data to a specified protection descriptor. Call NCryptProtectSecret to encrypt
		/// the data.
		/// </para>
		/// </summary>
		/// <param name="phDescriptor">
		/// <para>Pointer to the protection descriptor handle.</para>
		/// </param>
		/// <param name="dwFlags">
		/// <para>The flag can be zero or a bitwise OR of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>NCRYPT_SILENT_FLAG</term>
		/// <term>Requests that the key service provider not display a user interface.</term>
		/// </item>
		/// <item>
		/// <term>NCRYPT_UNPROTECT_NO_DECRYPT</term>
		/// <term>Decodes only the header of the protected data blob. No actual decryption takes place.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="pbProtectedBlob">
		/// <para>Pointer to an array of bytes that contains the data to decrypt.</para>
		/// </param>
		/// <param name="cbProtectedBlob">
		/// <para>The number of bytes in the array pointed to by the pbProtectedBlob parameter.</para>
		/// </param>
		/// <param name="pMemPara">
		/// <para>
		/// Pointer to an NCRYPT_ALLOC_PARA structure that you can use to specify custom memory management functions. If you set this
		/// argument to <c>NULL</c>, the LocalAlloc function is used internally to allocate memory and your application must call LocalFree
		/// to release memory pointed to by the ppbData parameter.
		/// </para>
		/// </param>
		/// <param name="hWnd">
		/// <para>Handle to the parent window of the user interface, if any, to be displayed.</para>
		/// </param>
		/// <param name="ppbData">
		/// <para>Address of a variable that receives a pointer to the decrypted data.</para>
		/// </param>
		/// <param name="pcbData">
		/// <para>Pointer to a <c>ULONG</c> variable that contains the size, in bytes, of the decrypted data pointed to by the ppbData variable.</para>
		/// </param>
		/// <returns>
		/// <para>
		/// Returns a status code that indicates the success or failure of the function. Possible return codes include, but are not limited
		/// to, the following.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>ERROR_SUCCESS</term>
		/// <term>The function was successful.</term>
		/// </item>
		/// <item>
		/// <term>NTE_BAD_FLAGS</term>
		/// <term>The dwFlags parameter can only contain NCRYPT_SILENT_FLAG or NCRYPT_UNPROTECT_NO_DECRYPT.</term>
		/// </item>
		/// <item>
		/// <term>NTE_INVALID_PARAMETER</term>
		/// <term>The pbProtectedBlob, ppbData, and pcbData parameters cannot be NULL. The cbData parameter cannot be less than one.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// Use the <c>NCryptUnprotectSecret</c> function to decrypt keys, key material, and passwords. Use the NCryptStreamOpenToUnprotect
		/// and the NCryptStreamUpdate functions to decrypt larger messages.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/ncryptprotect/nf-ncryptprotect-ncryptunprotectsecret SECURITY_STATUS
		// NCryptUnprotectSecret( NCRYPT_DESCRIPTOR_HANDLE *phDescriptor, DWORD dwFlags, const BYTE *pbProtectedBlob, ULONG cbProtectedBlob,
		// const NCRYPT_ALLOC_PARA *pMemPara, HWND hWnd, BYTE **ppbData, ULONG *pcbData );
		[DllImport(Lib.Ncrypt, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("ncryptprotect.h", MSDNShortId = "F532F0ED-36F4-47E3-B478-089CC083E5D1")]
		public static extern HRESULT NCryptUnprotectSecret(out SafeNCRYPT_DESCRIPTOR_HANDLE phDescriptor, UnprotectSecretFlags dwFlags, [In] IntPtr pbProtectedBlob, uint cbProtectedBlob, in NCRYPT_ALLOC_PARA pMemPara,
			HWND hWnd, out IntPtr ppbData, out uint pcbData);

		/// <summary>
		/// <para>
		/// The <c>NCryptUnprotectSecret</c> function decrypts data to a specified protection descriptor. Call NCryptProtectSecret to encrypt
		/// the data.
		/// </para>
		/// </summary>
		/// <param name="phDescriptor">
		/// <para>Pointer to the protection descriptor handle.</para>
		/// </param>
		/// <param name="dwFlags">
		/// <para>The flag can be zero or a bitwise OR of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>NCRYPT_SILENT_FLAG</term>
		/// <term>Requests that the key service provider not display a user interface.</term>
		/// </item>
		/// <item>
		/// <term>NCRYPT_UNPROTECT_NO_DECRYPT</term>
		/// <term>Decodes only the header of the protected data blob. No actual decryption takes place.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="pbProtectedBlob">
		/// <para>Pointer to an array of bytes that contains the data to decrypt.</para>
		/// </param>
		/// <param name="cbProtectedBlob">
		/// <para>The number of bytes in the array pointed to by the pbProtectedBlob parameter.</para>
		/// </param>
		/// <param name="pMemPara">
		/// <para>
		/// Pointer to an NCRYPT_ALLOC_PARA structure that you can use to specify custom memory management functions. If you set this
		/// argument to <c>NULL</c>, the LocalAlloc function is used internally to allocate memory and your application must call LocalFree
		/// to release memory pointed to by the ppbData parameter.
		/// </para>
		/// </param>
		/// <param name="hWnd">
		/// <para>Handle to the parent window of the user interface, if any, to be displayed.</para>
		/// </param>
		/// <param name="ppbData">
		/// <para>Address of a variable that receives a pointer to the decrypted data.</para>
		/// </param>
		/// <param name="pcbData">
		/// <para>Pointer to a <c>ULONG</c> variable that contains the size, in bytes, of the decrypted data pointed to by the ppbData variable.</para>
		/// </param>
		/// <returns>
		/// <para>
		/// Returns a status code that indicates the success or failure of the function. Possible return codes include, but are not limited
		/// to, the following.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>ERROR_SUCCESS</term>
		/// <term>The function was successful.</term>
		/// </item>
		/// <item>
		/// <term>NTE_BAD_FLAGS</term>
		/// <term>The dwFlags parameter can only contain NCRYPT_SILENT_FLAG or NCRYPT_UNPROTECT_NO_DECRYPT.</term>
		/// </item>
		/// <item>
		/// <term>NTE_INVALID_PARAMETER</term>
		/// <term>The pbProtectedBlob, ppbData, and pcbData parameters cannot be NULL. The cbData parameter cannot be less than one.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// Use the <c>NCryptUnprotectSecret</c> function to decrypt keys, key material, and passwords. Use the NCryptStreamOpenToUnprotect
		/// and the NCryptStreamUpdate functions to decrypt larger messages.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/ncryptprotect/nf-ncryptprotect-ncryptunprotectsecret SECURITY_STATUS
		// NCryptUnprotectSecret( NCRYPT_DESCRIPTOR_HANDLE *phDescriptor, DWORD dwFlags, const BYTE *pbProtectedBlob, ULONG cbProtectedBlob,
		// const NCRYPT_ALLOC_PARA *pMemPara, HWND hWnd, BYTE **ppbData, ULONG *pcbData );
		[DllImport(Lib.Ncrypt, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("ncryptprotect.h", MSDNShortId = "F532F0ED-36F4-47E3-B478-089CC083E5D1")]
		public static extern HRESULT NCryptUnprotectSecret(out SafeNCRYPT_DESCRIPTOR_HANDLE phDescriptor, UnprotectSecretFlags dwFlags, [In] IntPtr pbProtectedBlob, uint cbProtectedBlob, [Optional] IntPtr pMemPara,
			HWND hWnd, out IntPtr ppbData, out uint pcbData);

		/// <summary>Provides a handle to a protection descriptor.</summary>
		[StructLayout(LayoutKind.Sequential)]
		public struct NCRYPT_DESCRIPTOR_HANDLE : IHandle
		{
			private IntPtr handle;

			/// <summary>Initializes a new instance of the <see cref="NCRYPT_DESCRIPTOR_HANDLE"/> struct.</summary>
			/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
			public NCRYPT_DESCRIPTOR_HANDLE(IntPtr preexistingHandle) => handle = preexistingHandle;

			/// <summary>Returns an invalid handle by instantiating a <see cref="NCRYPT_DESCRIPTOR_HANDLE"/> object with <see cref="IntPtr.Zero"/>.</summary>
			public static NCRYPT_DESCRIPTOR_HANDLE NULL => new NCRYPT_DESCRIPTOR_HANDLE(IntPtr.Zero);

			/// <summary>Gets a value indicating whether this instance is a null handle.</summary>
			public bool IsNull => handle == IntPtr.Zero;

			/// <summary>Performs an explicit conversion from <see cref="NCRYPT_DESCRIPTOR_HANDLE"/> to <see cref="IntPtr"/>.</summary>
			/// <param name="h">The handle.</param>
			/// <returns>The result of the conversion.</returns>
			public static explicit operator IntPtr(NCRYPT_DESCRIPTOR_HANDLE h) => h.handle;

			/// <summary>Performs an implicit conversion from <see cref="IntPtr"/> to <see cref="NCRYPT_DESCRIPTOR_HANDLE"/>.</summary>
			/// <param name="h">The pointer to a handle.</param>
			/// <returns>The result of the conversion.</returns>
			public static implicit operator NCRYPT_DESCRIPTOR_HANDLE(IntPtr h) => new NCRYPT_DESCRIPTOR_HANDLE(h);

			/// <summary>Implements the operator !=.</summary>
			/// <param name="h1">The first handle.</param>
			/// <param name="h2">The second handle.</param>
			/// <returns>The result of the operator.</returns>
			public static bool operator !=(NCRYPT_DESCRIPTOR_HANDLE h1, NCRYPT_DESCRIPTOR_HANDLE h2) => !(h1 == h2);

			/// <summary>Implements the operator ==.</summary>
			/// <param name="h1">The first handle.</param>
			/// <param name="h2">The second handle.</param>
			/// <returns>The result of the operator.</returns>
			public static bool operator ==(NCRYPT_DESCRIPTOR_HANDLE h1, NCRYPT_DESCRIPTOR_HANDLE h2) => h1.Equals(h2);

			/// <inheritdoc/>
			public override bool Equals(object obj) => obj is NCRYPT_DESCRIPTOR_HANDLE h ? handle == h.handle : false;

			/// <inheritdoc/>
			public override int GetHashCode() => handle.GetHashCode();

			/// <inheritdoc/>
			public IntPtr DangerousGetHandle() => handle;
		}

		/// <summary>
		/// The <c>NCRYPT_PROTECT_STREAM_INFO</c> structure is used by the NCryptStreamOpenToProtect and NCryptStreamOpenToUnprotect
		/// functions to pass blocks of processed data to your application.
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/ncryptprotect/ns-ncryptprotect-ncrypt_protect_stream_info typedef struct
		// NCRYPT_PROTECT_STREAM_INFO { PFNCryptStreamOutputCallback pfnStreamOutput; void *pvCallbackCtxt; } NCRYPT_PROTECT_STREAM_INFO;
		[PInvokeData("ncryptprotect.h", MSDNShortId = "77FADFC1-6C66-4801-B0BD-263963555C3C")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
		public struct NCRYPT_PROTECT_STREAM_INFO
		{
			/// <summary>
			/// Address of a callback function that accepts data from the stream encryption or decryption process. for more information, see PFNCryptStreamOutputCallback.
			/// </summary>
			public PFNCryptStreamOutputCallback pfnStreamOutput;

			/// <summary>
			/// Pointer to a buffer supplied the caller. The buffer is not modified by the data protection API. You can use the buffer to
			/// keep track of your application.
			/// </summary>
			public IntPtr pvCallbackCtxt;
		}

		/// <summary>
		/// The <c>NCRYPT_PROTECT_STREAM_INFO_EX</c> structure is used by the NCryptStreamOpenToProtectEx and NCryptStreamOpenToUnprotectEx
		/// functions to pass blocks of processed data to your application.
		/// </summary>
		[PInvokeData("ncryptprotect.h")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
		public struct NCRYPT_PROTECT_STREAM_INFO_EX
		{
			/// <summary>
			/// Address of a callback function that accepts data from the stream encryption or decryption process. for more information, see PFNCryptStreamOutputCallback.
			/// </summary>
			public PFNCryptStreamOutputCallbackEx pfnStreamOutput;

			/// <summary>
			/// Pointer to a buffer supplied the caller. The buffer is not modified by the data protection API. You can use the buffer to
			/// keep track of your application.
			/// </summary>
			public IntPtr pvCallbackCtxt;
		}

		/// <summary>Provides a handle to a data protection stream object.</summary>
		[StructLayout(LayoutKind.Sequential)]
		public struct NCRYPT_STREAM_HANDLE : IHandle
		{
			private IntPtr handle;

			/// <summary>Initializes a new instance of the <see cref="NCRYPT_STREAM_HANDLE"/> struct.</summary>
			/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
			public NCRYPT_STREAM_HANDLE(IntPtr preexistingHandle) => handle = preexistingHandle;

			/// <summary>Returns an invalid handle by instantiating a <see cref="NCRYPT_STREAM_HANDLE"/> object with <see cref="IntPtr.Zero"/>.</summary>
			public static NCRYPT_STREAM_HANDLE NULL => new NCRYPT_STREAM_HANDLE(IntPtr.Zero);

			/// <summary>Gets a value indicating whether this instance is a null handle.</summary>
			public bool IsNull => handle == IntPtr.Zero;

			/// <summary>Performs an explicit conversion from <see cref="NCRYPT_STREAM_HANDLE"/> to <see cref="IntPtr"/>.</summary>
			/// <param name="h">The handle.</param>
			/// <returns>The result of the conversion.</returns>
			public static explicit operator IntPtr(NCRYPT_STREAM_HANDLE h) => h.handle;

			/// <summary>Performs an implicit conversion from <see cref="IntPtr"/> to <see cref="NCRYPT_STREAM_HANDLE"/>.</summary>
			/// <param name="h">The pointer to a handle.</param>
			/// <returns>The result of the conversion.</returns>
			public static implicit operator NCRYPT_STREAM_HANDLE(IntPtr h) => new NCRYPT_STREAM_HANDLE(h);

			/// <summary>Implements the operator !=.</summary>
			/// <param name="h1">The first handle.</param>
			/// <param name="h2">The second handle.</param>
			/// <returns>The result of the operator.</returns>
			public static bool operator !=(NCRYPT_STREAM_HANDLE h1, NCRYPT_STREAM_HANDLE h2) => !(h1 == h2);

			/// <summary>Implements the operator ==.</summary>
			/// <param name="h1">The first handle.</param>
			/// <param name="h2">The second handle.</param>
			/// <returns>The result of the operator.</returns>
			public static bool operator ==(NCRYPT_STREAM_HANDLE h1, NCRYPT_STREAM_HANDLE h2) => h1.Equals(h2);

			/// <inheritdoc/>
			public override bool Equals(object obj) => obj is NCRYPT_STREAM_HANDLE h ? handle == h.handle : false;

			/// <inheritdoc/>
			public override int GetHashCode() => handle.GetHashCode();

			/// <inheritdoc/>
			public IntPtr DangerousGetHandle() => handle;
		}

		/// <summary>Provides a <see cref="SafeHandle"/> for <see cref="NCRYPT_DESCRIPTOR_HANDLE"/> that is disposed using <see cref="NCryptCloseProtectionDescriptor"/>.</summary>
		public class SafeNCRYPT_DESCRIPTOR_HANDLE : SafeHANDLE
		{
			/// <summary>Initializes a new instance of the <see cref="SafeNCRYPT_DESCRIPTOR_HANDLE"/> class and assigns an existing handle.</summary>
			/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
			/// <param name="ownsHandle">
			/// <see langword="true"/> to reliably release the handle during the finalization phase; otherwise, <see langword="false"/> (not recommended).
			/// </param>
			public SafeNCRYPT_DESCRIPTOR_HANDLE(IntPtr preexistingHandle, bool ownsHandle = true) : base(preexistingHandle, ownsHandle) { }

			/// <summary>Initializes a new instance of the <see cref="SafeNCRYPT_DESCRIPTOR_HANDLE"/> class.</summary>
			private SafeNCRYPT_DESCRIPTOR_HANDLE() : base() { }

			/// <summary>Performs an implicit conversion from <see cref="SafeNCRYPT_DESCRIPTOR_HANDLE"/> to <see cref="NCRYPT_DESCRIPTOR_HANDLE"/>.</summary>
			/// <param name="h">The safe handle instance.</param>
			/// <returns>The result of the conversion.</returns>
			public static implicit operator NCRYPT_DESCRIPTOR_HANDLE(SafeNCRYPT_DESCRIPTOR_HANDLE h) => h.handle;

			/// <inheritdoc/>
			protected override bool InternalReleaseHandle() => NCryptCloseProtectionDescriptor(this).Succeeded;
		}

		/// <summary>Provides a <see cref="SafeHandle"/> for <see cref="NCRYPT_STREAM_HANDLE"/> that is disposed using <see cref="NCryptStreamClose"/>.</summary>
		public class SafeNCRYPT_STREAM_HANDLE : SafeHANDLE
		{
			/// <summary>Initializes a new instance of the <see cref="SafeNCRYPT_STREAM_HANDLE"/> class and assigns an existing handle.</summary>
			/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
			/// <param name="ownsHandle">
			/// <see langword="true"/> to reliably release the handle during the finalization phase; otherwise, <see langword="false"/> (not recommended).
			/// </param>
			public SafeNCRYPT_STREAM_HANDLE(IntPtr preexistingHandle, bool ownsHandle = true) : base(preexistingHandle, ownsHandle) { }

			/// <summary>Initializes a new instance of the <see cref="SafeNCRYPT_STREAM_HANDLE"/> class.</summary>
			private SafeNCRYPT_STREAM_HANDLE() : base() { }

			/// <summary>Performs an implicit conversion from <see cref="SafeNCRYPT_STREAM_HANDLE"/> to <see cref="NCRYPT_STREAM_HANDLE"/>.</summary>
			/// <param name="h">The safe handle instance.</param>
			/// <returns>The result of the conversion.</returns>
			public static implicit operator NCRYPT_STREAM_HANDLE(SafeNCRYPT_STREAM_HANDLE h) => h.handle;

			/// <inheritdoc/>
			protected override bool InternalReleaseHandle() => NCryptStreamClose(this).Succeeded;
		}
	}
}