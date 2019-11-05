using System;
using System.Runtime.InteropServices;
using Vanara.InteropServices;
using static Vanara.PInvoke.Crypt32;

namespace Vanara.PInvoke
{
	public static partial class WinTrust
	{
		/// <summary>
		/// The <c>CryptSIPCreateIndirectData</c> function returns a SIP_INDIRECT_DATA structure that contains a hash of the supplied
		/// SIP_SUBJECTINFO structure, the digest algorithm, and an encoding attribute. The hash can be used as an indirect reference to the data.
		/// </summary>
		/// <param name="pSubjectInfo">
		/// A pointer to a SIP_SUBJECTINFO structure that contains the subject to which the indirect data reference will point.
		/// </param>
		/// <param name="pcbIndirectData">A pointer to a <c>DWORD</c> value to receive the size of the returned SIP_INDIRECT_DATA structure.</param>
		/// <param name="pIndirectData">A pointer to a SIP_INDIRECT_DATA structure to receive the catalog item.</param>
		/// <returns>
		/// <para>The return value is <c>TRUE</c> if the function succeeds; otherwise, <c>FALSE</c>.</para>
		/// <para>
		/// If this function returns <c>FALSE</c>, additional error information can be obtained by calling the GetLastError function.
		/// <c>GetLastError</c> will return one of the following error codes.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>ERROR_BAD_FORMAT</term>
		/// <term>The file or data format is not correct for the specified subject interface package (SIP) type.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_INVALID_PARAMETER</term>
		/// <term>One or more of the parameters are not valid.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_NOT_ENOUGH_MEMORY</term>
		/// <term>There was an error allocating memory.</term>
		/// </item>
		/// <item>
		/// <term>NTE_BAD_ALGID</term>
		/// <term>The specified algorithm is not supported by the SIP.</term>
		/// </item>
		/// <item>
		/// <term>TRUST_E_SUBJECT_FORM_UNKNOWN</term>
		/// <term>The subject type is not recognized.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// If pcbIndirectData points to a <c>DWORD</c> and pIndirectData points to <c>NULL</c>, the size of the data will be returned in pcbIndirectData.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/mssip/nf-mssip-cryptsipcreateindirectdata BOOL CryptSIPCreateIndirectData( IN
		// SIP_SUBJECTINFO *pSubjectInfo, IN OUT DWORD *pcbIndirectData, OUT SIP_INDIRECT_DATA *pIndirectData );
		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		[PInvokeData("mssip.h", MSDNShortId = "bb4ecc95-972f-415c-9722-59b00a27cddc")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public delegate bool pCryptSIPCreateIndirectData(in SIP_SUBJECTINFO pSubjectInfo, ref uint pcbIndirectData, IntPtr pIndirectData);

		/// <summary>The <c>pCryptSIPGetCaps</c> function is implemented by an subject interface package (SIP) to report capabilities.</summary>
		/// <param name="pSubjInfo">Pointer to a SIP_SUBJECTINFO structure that specifies subject information data to the SIP APIs.</param>
		/// <param name="pCaps">Pointer to a SIP_CAP_SET structure that defines the capabilities of an SIP.</param>
		/// <returns>None</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/mssip/nc-mssip-pcryptsipgetcaps pCryptSIPGetCaps Pcryptsipgetcaps; BOOL
		// Pcryptsipgetcaps( SIP_SUBJECTINFO *pSubjInfo, SIP_CAP_SET *pCaps ) {...}
		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		[PInvokeData("mssip.h", MSDNShortId = "8EA46B67-F542-4B15-81F4-3DD83DD45764")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public delegate bool pCryptSIPGetCaps(in SIP_SUBJECTINFO pSubjInfo, IntPtr pCaps);

		/// <summary>The <c>CryptSIPGetSignedDataMsg</c> function retrieves an Authenticode signature from the file.</summary>
		/// <param name="pSubjectInfo">A pointer to a SIP_SUBJECTINFO structure that contains information about the message subject.</param>
		/// <param name="pdwEncodingType">
		/// <para>The encoding type of the Authenticode signature.</para>
		/// <para>This parameter can be a combination of one or more of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>PKCS_7_ASN_ENCODING 65536 (0x10000)</term>
		/// <term>Specifies PKCS #7 message encoding.</term>
		/// </item>
		/// <item>
		/// <term>X509_ASN_ENCODING 1 (0x1)</term>
		/// <term>Specifies X.509 certificate encoding.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="dwIndex">This parameter is reserved and should be set to zero.</param>
		/// <param name="pcbSignedDataMsg">The length, in bytes, of the buffer pointed to by the pbSignedDataMsg parameter.</param>
		/// <param name="pbSignedDataMsg">
		/// <para>A pointer to a buffer to receive the returned Authenticode signature.</para>
		/// <para>
		/// To determine the size of the buffer needed, set the pbSignedDataMsg parameter to <c>NULL</c> and call the
		/// <c>CryptSIPGetSignedDataMsg</c> function. This function will place the required size of the buffer, in bytes, in the value
		/// pointed to by pcbSignedDataMsg. For more information, see Retrieving Data of Unknown Length.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the function returns <c>TRUE</c>.</para>
		/// <para>
		/// If the function fails, it returns <c>FALSE</c>. For extended error information, call GetLastError. Some possible error codes follow.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>CRYPT_E_NO_MATCH</term>
		/// <term>The signature specified by the index could not be found.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_BAD_FORMAT</term>
		/// <term>The specified data or file format of the subject interface package (SIP) is not valid.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_INVALID_PARAMETER</term>
		/// <term>The pSubjectInfo parameter or the pgSubjectType member of the SIP_SUBJECTINFO structure is a null pointer.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_INSUFFICIENT_BUFFER</term>
		/// <term>
		/// The size of the message buffer was insufficient to hold the retrieved data, the pcbSignedDataMsgparameter has been set to
		/// indicate the required buffer size.
		/// </term>
		/// </item>
		/// <item>
		/// <term>TRUST_E_SUBJECT_FORM_UNKNOWN</term>
		/// <term>The specified subject type is not valid.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// Subjects include, but are not limited to, portable executable images (.exe), cabinet (.cab) images, flat files, and catalog
		/// files. Each subject type uses a different subset of its data for hash calculation and requires a different procedure for storage
		/// and retrieval. Therefore, each subject type has a unique SIP specification.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/mssip/nf-mssip-cryptsipgetsigneddatamsg BOOL CryptSIPGetSignedDataMsg( IN
		// SIP_SUBJECTINFO *pSubjectInfo, OUT DWORD *pdwEncodingType, IN DWORD dwIndex, IN OUT DWORD *pcbSignedDataMsg, OUT BYTE
		// *pbSignedDataMsg );
		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		[PInvokeData("mssip.h", MSDNShortId = "e3fabaa7-2dda-4c6c-8d1a-3ee5363e10b5")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public delegate bool pCryptSIPGetSignedDataMsg(in SIP_SUBJECTINFO pSubjectInfo, out CertEncodingType pdwEncodingType, uint dwIndex, ref uint pcbSignedDataMsg, [Out] IntPtr pbSignedDataMsg);

		/// <summary>The <c>CryptSIPPutSignedDataMsg</c> function stores an Authenticode signature in the target file.</summary>
		/// <param name="pSubjectInfo">Pointer to a SIP_SUBJECTINFO structure that contains information about the message subject.</param>
		/// <param name="dwEncodingType">
		/// <para>The encoding type of the message. This can be a combination of one or more of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>PKCS_7_ASN_ENCODING 65536 (0x10000)</term>
		/// <term>Specifies PKCS #7 message encoding.</term>
		/// </item>
		/// <item>
		/// <term>X509_ASN_ENCODING 1 (0x1)</term>
		/// <term>Specifies X.509 certificate encoding.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="pdwIndex">Pointer to the message index.</param>
		/// <param name="cbSignedDataMsg">Length, in bytes, of the buffer pointed to by the pbSignedDataMsg parameter.</param>
		/// <param name="pbSignedDataMsg">Pointer to the buffer that contains the message.</param>
		/// <returns>
		/// <para>If the function succeeds, the function returns <c>TRUE</c>.</para>
		/// <para>
		/// If the function fails, it returns <c>FALSE</c>. For extended error information, call GetLastError. Some possible error codes follow.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>ERROR_BAD_FORMAT</term>
		/// <term>The specified data or file format of the subject interface package (SIP) is not valid.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_INVALID_PARAMETER</term>
		/// <term>This code can be returned for the following reasons:</term>
		/// </item>
		/// <item>
		/// <term>TRUST_E_SUBJECT_FORM_UNKNOWN</term>
		/// <term>The specified subject type is not valid.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// Each subject type uses a different subset of its data for hash calculation and requires a different procedure for storage and
		/// retrieval. Therefore, each subject type has a unique SIP specification.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/mssip/nf-mssip-cryptsipputsigneddatamsg BOOL CryptSIPPutSignedDataMsg( IN
		// SIP_SUBJECTINFO *pSubjectInfo, IN DWORD dwEncodingType, OUT DWORD *pdwIndex, IN DWORD cbSignedDataMsg, IN BYTE *pbSignedDataMsg );
		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		[PInvokeData("mssip.h", MSDNShortId = "731f64bf-49f0-4799-b84a-9ca04292aa91")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public delegate bool pCryptSIPPutSignedDataMsg(in SIP_SUBJECTINFO pSubjectInfo, CertEncodingType dwEncodingType, out uint pdwIndex, uint cbSignedDataMsg, [In] IntPtr pbSignedDataMsg);

		/// <summary>The <c>CryptSIPRemoveSignedDataMsg</c> function removes a specified Authenticode signature.</summary>
		/// <param name="pSubjectInfo">A pointer to a SIP_SUBJECTINFO structure that contains information about the message subject.</param>
		/// <param name="dwIndex">This parameter is reserved and should be set to zero.</param>
		/// <returns>
		/// <para>If the function succeeds, the function returns <c>TRUE</c>.</para>
		/// <para>If the function fails, it returns <c>FALSE</c>. For extended error information, call GetLastError.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/mssip/nf-mssip-cryptsipremovesigneddatamsg BOOL CryptSIPRemoveSignedDataMsg(
		// IN SIP_SUBJECTINFO *pSubjectInfo, IN DWORD dwIndex );
		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		[PInvokeData("mssip.h", MSDNShortId = "c3ea46bb-931a-4ca6-93f5-db7e07b4cb7a")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public delegate bool pCryptSIPRemoveSignedDataMsg(in SIP_SUBJECTINFO pSubjectInfo, uint dwIndex = 0);

		/// <summary>The <c>CryptSIPVerifyIndirectData</c> function validates the indirect hashed data against the supplied subject.</summary>
		/// <param name="pSubjectInfo">A pointer to a SIP_SUBJECTINFO structure that contains information about the message subject.</param>
		/// <param name="pIndirectData">A pointer to a SIP_INDIRECT_DATA structure that contains information about the hashed subject information.</param>
		/// <returns>
		/// <para>The return value is <c>TRUE</c> if the function succeeds; otherwise, <c>FALSE</c>.</para>
		/// <para>
		/// If this function returns <c>FALSE</c>, additional error information can be obtained by calling the GetLastError function.
		/// <c>GetLastError</c> will return one of the following error codes.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>ERROR_INVALID_PARAMETER</term>
		/// <term>One or more of the parameters are not valid.</term>
		/// </item>
		/// <item>
		/// <term>TRUST_E_SUBJECT_FORM_UNKNOWN</term>
		/// <term>The subject type is an unknown type.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// Subjects include, but are not limited to, portable executable images (.exe), cabinet (.cab) images, flat files, and catalog
		/// files. Each subject type uses a different subset of its data for hash calculation and requires a different procedure for storage
		/// and retrieval. Therefore each subject type has a unique subject interface package specification.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/mssip/nf-mssip-cryptsipverifyindirectdata BOOL CryptSIPVerifyIndirectData( IN
		// SIP_SUBJECTINFO *pSubjectInfo, IN SIP_INDIRECT_DATA *pIndirectData );
		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		[PInvokeData("mssip.h", MSDNShortId = "137b8858-a31f-4ef6-96bd-c5e26ae7b3e8")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public delegate bool pCryptSIPVerifyIndirectData(in SIP_SUBJECTINFO pSubjectInfo, in SIP_INDIRECT_DATA pIndirectData);

		/// <summary>
		/// The <c>pfnIsFileSupported</c> callback function queries the subject interface packages (SIPs) listed in the registry to
		/// determine which SIP handles the file type.
		/// </summary>
		/// <param name="hFile">A handle to the file.</param>
		/// <param name="pgSubject"/>
		/// <returns>
		/// <para>If the function succeeds, the function returns <c>TRUE</c>.</para>
		/// <para>If the function fails, it returns <c>FALSE</c>. For extended error information, call GetLastError.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// If the SIP supports the file type passed by hfile, the function returns <c>TRUE</c>, and sets pgSubject to the GUID that
		/// identifies the SIP for handling the file type.
		/// </para>
		/// <para>
		/// Each SIP implements its own version of the function that determines whether the file type is supported. The specific name of the
		/// function may vary depending on the implementation of the SIP, but the signature of the function will match that of the
		/// <c>pfnIsFileSupported</c> function. The function name is added to the registry by the CryptSIPAddProvider function, which takes
		/// the function name as a parameter in the <c>pwszIsFunctionName</c> field of the SIP_ADD_NEWPROVIDER structure.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/mssip/nc-mssip-pfnisfilesupported pfnIsFileSupported Pfnisfilesupported; BOOL
		// Pfnisfilesupported( IN HANDLE hFile, OUT GUID *pgSubject ) {...}
		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		[PInvokeData("mssip.h", MSDNShortId = "cf12d057-328a-4975-b7e5-842c4ea2e760")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public delegate bool pfnIsFileSupported(HFILE hFile, out Guid pgSubject);

		/// <summary>
		/// The <c>pfnIsFileSupportedName</c> callback function queries the subject interface packages (SIPs) listed in the registry to
		/// determine which SIP handles the file type.
		/// </summary>
		/// <param name="pwszFileName"/>
		/// <param name="pgSubject"/>
		/// <returns>
		/// The return value is <c>TRUE</c> if the function succeeds; <c>FALSE</c> if the function fails. If the function fails, call the
		/// GetLastError function to determine the reason for failure.
		/// </returns>
		/// <remarks>
		/// <para>
		/// If the SIP supports the file type passed by hfile, the function returns <c>TRUE</c>, and sets pgSubject to the GUID that
		/// identifies the SIP for handling the file type.
		/// </para>
		/// <para>
		/// Each SIP implements its own version of the function that determines if the file type is supported. The specific name of the
		/// function may vary depending on the implementation of the SIP, but the signature of the function will match that of the
		/// <c>pfnIsFileSupportedName</c> function. The function name is added to the registry by the CryptSIPAddProvider function, which
		/// takes the function name as parameter in the <c>pwszIsFunctionNameFmt2</c> field in the SIP_ADD_NEWPROVIDER structure.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/mssip/nc-mssip-pfnisfilesupportedname pfnIsFileSupportedName
		// Pfnisfilesupportedname; BOOL Pfnisfilesupportedname( IN WCHAR *pwszFileName, OUT GUID *pgSubject ) {...}
		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		[PInvokeData("mssip.h", MSDNShortId = "cc2304ef-c319-45eb-b2ec-7410510af213")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public delegate bool pfnIsFileSupportedName([MarshalAs(UnmanagedType.LPWStr)] string pwszFileName, out Guid pgSubject);

		/// <summary>
		/// The <c>CryptSIPAddProvider</c> function registers functions that are exported by a given DLL file that implements a Subject
		/// Interface Package (SIP).
		/// </summary>
		/// <param name="psNewProv">A pointer to a SIP_ADD_NEWPROVIDER structure that specifies the DLL file and function names to register.</param>
		/// <returns>
		/// The return value is <c>TRUE</c> if the function succeeds; <c>FALSE</c> if the function fails. If the function fails, call the
		/// GetLastError function to determine the reason for failure.
		/// </returns>
		/// <remarks>
		/// <para>
		/// Typically, you call this function as part of an in-process COM server registration. The <c>CryptSIPAddProvider</c> function
		/// persists the appropriate Registry entries for the SIP provider functions.
		/// </para>
		/// <para>When you have finished using the added SIP provider, remove it by calling the CryptSIPRemoveProvider function.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/mssip/nf-mssip-cryptsipaddprovider BOOL CryptSIPAddProvider( IN
		// SIP_ADD_NEWPROVIDER *psNewProv );
		[DllImport(Lib.Crypt32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("mssip.h", MSDNShortId = "99633c2f-e5ed-49e4-9c98-7501f66e5571")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool CryptSIPAddProvider([In] in SIP_ADD_NEWPROVIDER psNewProv);

		/// <summary>
		/// The <c>CryptSIPCreateIndirectData</c> function returns a SIP_INDIRECT_DATA structure that contains a hash of the supplied
		/// SIP_SUBJECTINFO structure, the digest algorithm, and an encoding attribute. The hash can be used as an indirect reference to the data.
		/// </summary>
		/// <param name="pSubjectInfo">
		/// A pointer to a SIP_SUBJECTINFO structure that contains the subject to which the indirect data reference will point.
		/// </param>
		/// <param name="pcbIndirectData">A pointer to a <c>DWORD</c> value to receive the size of the returned SIP_INDIRECT_DATA structure.</param>
		/// <param name="pIndirectData">A pointer to a SIP_INDIRECT_DATA structure to receive the catalog item.</param>
		/// <returns>
		/// <para>The return value is <c>TRUE</c> if the function succeeds; otherwise, <c>FALSE</c>.</para>
		/// <para>
		/// If this function returns <c>FALSE</c>, additional error information can be obtained by calling the GetLastError function.
		/// <c>GetLastError</c> will return one of the following error codes.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>ERROR_BAD_FORMAT</term>
		/// <term>The file or data format is not correct for the specified subject interface package (SIP) type.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_INVALID_PARAMETER</term>
		/// <term>One or more of the parameters are not valid.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_NOT_ENOUGH_MEMORY</term>
		/// <term>There was an error allocating memory.</term>
		/// </item>
		/// <item>
		/// <term>NTE_BAD_ALGID</term>
		/// <term>The specified algorithm is not supported by the SIP.</term>
		/// </item>
		/// <item>
		/// <term>TRUST_E_SUBJECT_FORM_UNKNOWN</term>
		/// <term>The subject type is not recognized.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// If pcbIndirectData points to a <c>DWORD</c> and pIndirectData points to <c>NULL</c>, the size of the data will be returned in pcbIndirectData.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/mssip/nf-mssip-cryptsipcreateindirectdata BOOL CryptSIPCreateIndirectData( IN
		// SIP_SUBJECTINFO *pSubjectInfo, IN OUT DWORD *pcbIndirectData, OUT SIP_INDIRECT_DATA *pIndirectData );
		[DllImport(Lib.Crypt32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("mssip.h", MSDNShortId = "bb4ecc95-972f-415c-9722-59b00a27cddc")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool CryptSIPCreateIndirectData(in SIP_SUBJECTINFO pSubjectInfo, ref uint pcbIndirectData, IntPtr pIndirectData);

		/// <summary>The <c>CryptSIPGetCaps</c> function retrieves the capabilities of a subject interface package (SIP).</summary>
		/// <param name="pSubjInfo">Pointer to a SIP_SUBJECTINFO structure that specifies subject information data to the SIP APIs.</param>
		/// <param name="pCaps">Pointer to a SIP_CAP_SET structure that defines the capabilities of an SIP.</param>
		/// <returns>None</returns>
		/// <remarks>
		/// Unlike other SIP functions, <c>CryptSIPGetCaps</c> is not registered in the dispatch table. For more information, see the
		/// SIP_DISPATCH_INFO structure. Instead, callers must map the object identifier (OID) to the function entry point.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/mssip/nf-mssip-cryptsipgetcaps BOOL CryptSIPGetCaps( SIP_SUBJECTINFO
		// *pSubjInfo, SIP_CAP_SET *pCaps );
		[DllImport(Lib.Crypt32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("mssip.h", MSDNShortId = "F939F6D5-DDFE-478F-8FDD-8FA9FAB26010")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool CryptSIPGetCaps(in SIP_SUBJECTINFO pSubjInfo, ref SIP_CAP_SET_V2 pCaps);

		/// <summary>The <c>CryptSIPGetCaps</c> function retrieves the capabilities of a subject interface package (SIP).</summary>
		/// <param name="pSubjInfo">Pointer to a SIP_SUBJECTINFO structure that specifies subject information data to the SIP APIs.</param>
		/// <param name="pCaps">Pointer to a SIP_CAP_SET structure that defines the capabilities of an SIP.</param>
		/// <returns>None</returns>
		/// <remarks>
		/// Unlike other SIP functions, <c>CryptSIPGetCaps</c> is not registered in the dispatch table. For more information, see the
		/// SIP_DISPATCH_INFO structure. Instead, callers must map the object identifier (OID) to the function entry point.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/mssip/nf-mssip-cryptsipgetcaps BOOL CryptSIPGetCaps( SIP_SUBJECTINFO
		// *pSubjInfo, SIP_CAP_SET *pCaps );
		[DllImport(Lib.Crypt32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("mssip.h", MSDNShortId = "F939F6D5-DDFE-478F-8FDD-8FA9FAB26010")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool CryptSIPGetCaps(in SIP_SUBJECTINFO pSubjInfo, ref SIP_CAP_SET_V3 pCaps);

		/// <summary>The <c>CryptSIPGetSignedDataMsg</c> function retrieves an Authenticode signature from the file.</summary>
		/// <param name="pSubjectInfo">A pointer to a SIP_SUBJECTINFO structure that contains information about the message subject.</param>
		/// <param name="pdwEncodingType">
		/// <para>The encoding type of the Authenticode signature.</para>
		/// <para>This parameter can be a combination of one or more of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>PKCS_7_ASN_ENCODING 65536 (0x10000)</term>
		/// <term>Specifies PKCS #7 message encoding.</term>
		/// </item>
		/// <item>
		/// <term>X509_ASN_ENCODING 1 (0x1)</term>
		/// <term>Specifies X.509 certificate encoding.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="dwIndex">This parameter is reserved and should be set to zero.</param>
		/// <param name="pcbSignedDataMsg">The length, in bytes, of the buffer pointed to by the pbSignedDataMsg parameter.</param>
		/// <param name="pbSignedDataMsg">
		/// <para>A pointer to a buffer to receive the returned Authenticode signature.</para>
		/// <para>
		/// To determine the size of the buffer needed, set the pbSignedDataMsg parameter to <c>NULL</c> and call the
		/// <c>CryptSIPGetSignedDataMsg</c> function. This function will place the required size of the buffer, in bytes, in the value
		/// pointed to by pcbSignedDataMsg. For more information, see Retrieving Data of Unknown Length.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the function returns <c>TRUE</c>.</para>
		/// <para>
		/// If the function fails, it returns <c>FALSE</c>. For extended error information, call GetLastError. Some possible error codes follow.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>CRYPT_E_NO_MATCH</term>
		/// <term>The signature specified by the index could not be found.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_BAD_FORMAT</term>
		/// <term>The specified data or file format of the subject interface package (SIP) is not valid.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_INVALID_PARAMETER</term>
		/// <term>The pSubjectInfo parameter or the pgSubjectType member of the SIP_SUBJECTINFO structure is a null pointer.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_INSUFFICIENT_BUFFER</term>
		/// <term>
		/// The size of the message buffer was insufficient to hold the retrieved data, the pcbSignedDataMsgparameter has been set to
		/// indicate the required buffer size.
		/// </term>
		/// </item>
		/// <item>
		/// <term>TRUST_E_SUBJECT_FORM_UNKNOWN</term>
		/// <term>The specified subject type is not valid.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// Subjects include, but are not limited to, portable executable images (.exe), cabinet (.cab) images, flat files, and catalog
		/// files. Each subject type uses a different subset of its data for hash calculation and requires a different procedure for storage
		/// and retrieval. Therefore, each subject type has a unique SIP specification.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/mssip/nf-mssip-cryptsipgetsigneddatamsg BOOL CryptSIPGetSignedDataMsg( IN
		// SIP_SUBJECTINFO *pSubjectInfo, OUT DWORD *pdwEncodingType, IN DWORD dwIndex, IN OUT DWORD *pcbSignedDataMsg, OUT BYTE
		// *pbSignedDataMsg );
		[DllImport(Lib.Crypt32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("mssip.h", MSDNShortId = "e3fabaa7-2dda-4c6c-8d1a-3ee5363e10b5")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool CryptSIPGetSignedDataMsg(in SIP_SUBJECTINFO pSubjectInfo, out CertEncodingType pdwEncodingType, uint dwIndex, ref uint pcbSignedDataMsg, [Out] IntPtr pbSignedDataMsg);

		/// <summary>
		/// The <c>CryptSIPLoad</c> function loads the dynamic-link library (DLL) that implements a subject interface package (SIP) and
		/// assigns appropriate library export functions to a SIP_DISPATCH_INFO structure. The exported functions must have been previously
		/// registered by calling the CryptSIPAddProvider function.
		/// </summary>
		/// <param name="pgSubject">A pointer to a GUID returned by calling the CryptSIPRetrieveSubjectGuid function.</param>
		/// <param name="dwFlags">This parameter is reserved and must be set to zero.</param>
		/// <param name="pSipDispatch">
		/// A pointer to a SIP_DISPATCH_INFO structure that contains pointers to SIP provider functions that are specific to the subject
		/// type. The caller must initialize this structure to binary zeros, and set the <c>cbSize</c> member to before calling the
		/// <c>CryptSIPLoad</c> function.
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the function returns <c>TRUE</c>.</para>
		/// <para>If the function fails, it returns <c>FALSE</c>. For extended error information, call GetLastError.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/mssip/nf-mssip-cryptsipload BOOL CryptSIPLoad( IN const GUID *pgSubject, IN
		// DWORD dwFlags, IN OUT SIP_DISPATCH_INFO *pSipDispatch );
		[DllImport(Lib.Crypt32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("mssip.h", MSDNShortId = "3378ecee-bd5d-45e5-9a1f-a3734d086782")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool CryptSIPLoad(in Guid pgSubject, [Optional] uint dwFlags, ref SIP_DISPATCH_INFO pSipDispatch);

		/// <summary>The <c>CryptSIPPutSignedDataMsg</c> function stores an Authenticode signature in the target file.</summary>
		/// <param name="pSubjectInfo">Pointer to a SIP_SUBJECTINFO structure that contains information about the message subject.</param>
		/// <param name="dwEncodingType">
		/// <para>The encoding type of the message. This can be a combination of one or more of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>PKCS_7_ASN_ENCODING 65536 (0x10000)</term>
		/// <term>Specifies PKCS #7 message encoding.</term>
		/// </item>
		/// <item>
		/// <term>X509_ASN_ENCODING 1 (0x1)</term>
		/// <term>Specifies X.509 certificate encoding.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="pdwIndex">Pointer to the message index.</param>
		/// <param name="cbSignedDataMsg">Length, in bytes, of the buffer pointed to by the pbSignedDataMsg parameter.</param>
		/// <param name="pbSignedDataMsg">Pointer to the buffer that contains the message.</param>
		/// <returns>
		/// <para>If the function succeeds, the function returns <c>TRUE</c>.</para>
		/// <para>
		/// If the function fails, it returns <c>FALSE</c>. For extended error information, call GetLastError. Some possible error codes follow.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>ERROR_BAD_FORMAT</term>
		/// <term>The specified data or file format of the subject interface package (SIP) is not valid.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_INVALID_PARAMETER</term>
		/// <term>This code can be returned for the following reasons:</term>
		/// </item>
		/// <item>
		/// <term>TRUST_E_SUBJECT_FORM_UNKNOWN</term>
		/// <term>The specified subject type is not valid.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// Each subject type uses a different subset of its data for hash calculation and requires a different procedure for storage and
		/// retrieval. Therefore, each subject type has a unique SIP specification.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/mssip/nf-mssip-cryptsipputsigneddatamsg BOOL CryptSIPPutSignedDataMsg( IN
		// SIP_SUBJECTINFO *pSubjectInfo, IN DWORD dwEncodingType, OUT DWORD *pdwIndex, IN DWORD cbSignedDataMsg, IN BYTE *pbSignedDataMsg );
		[DllImport(Lib.Crypt32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("mssip.h", MSDNShortId = "731f64bf-49f0-4799-b84a-9ca04292aa91")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool CryptSIPPutSignedDataMsg(in SIP_SUBJECTINFO pSubjectInfo, CertEncodingType dwEncodingType, out uint pdwIndex, uint cbSignedDataMsg, [In] IntPtr pbSignedDataMsg);

		/// <summary>
		/// The <c>CryptSIPRemoveProvider</c> function removes registry details of a Subject Interface Package (SIP) DLL file added by a
		/// previous call to the CryptSIPAddProvider function.
		/// </summary>
		/// <param name="pgProv">A pointer to the GUID that identifies the SIP DLL to remove.</param>
		/// <returns>
		/// The return value is <c>TRUE</c> if the function succeeds; <c>FALSE</c> if the function fails. If the function fails, call the
		/// GetLastError function to determine the reason for failure.
		/// </returns>
		/// <remarks>
		/// Typically you call this function to unregister an in-process COM server. The <c>CryptSIPRemoveProvider</c> function removes the
		/// appropriate Registry entries for the SIP provider functions.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/mssip/nf-mssip-cryptsipremoveprovider BOOL CryptSIPRemoveProvider( IN GUID
		// *pgProv );
		[DllImport(Lib.Crypt32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("mssip.h", MSDNShortId = "0a269956-b2c7-414a-b002-7cec0d52bfd6")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool CryptSIPRemoveProvider(in Guid pgProv);

		/// <summary>The <c>CryptSIPRemoveSignedDataMsg</c> function removes a specified Authenticode signature.</summary>
		/// <param name="pSubjectInfo">A pointer to a SIP_SUBJECTINFO structure that contains information about the message subject.</param>
		/// <param name="dwIndex">This parameter is reserved and should be set to zero.</param>
		/// <returns>
		/// <para>If the function succeeds, the function returns <c>TRUE</c>.</para>
		/// <para>If the function fails, it returns <c>FALSE</c>. For extended error information, call GetLastError.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/mssip/nf-mssip-cryptsipremovesigneddatamsg BOOL CryptSIPRemoveSignedDataMsg(
		// IN SIP_SUBJECTINFO *pSubjectInfo, IN DWORD dwIndex );
		[DllImport(Lib.Crypt32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("mssip.h", MSDNShortId = "c3ea46bb-931a-4ca6-93f5-db7e07b4cb7a")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool CryptSIPRemoveSignedDataMsg(in SIP_SUBJECTINFO pSubjectInfo, uint dwIndex = 0);

		/// <summary>
		/// The <c>CryptSIPRetrieveSubjectGuid</c> function retrieves a GUID based on the header information in a specified file. The GUID
		/// is used by the CryptSIPLoad function to load the subject interface package (SIP) implementation for the given file type.
		/// </summary>
		/// <param name="FileName">The name of the file.</param>
		/// <param name="hFileIn">A handle to the file to check.</param>
		/// <param name="pgSubject">A GUID that identifies the subject.</param>
		/// <returns>
		/// <para>If the function succeeds, the function returns <c>TRUE</c>.</para>
		/// <para>If the function fails, it returns <c>FALSE</c>. For extended error information, call GetLastError.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/mssip/nf-mssip-cryptsipretrievesubjectguid BOOL CryptSIPRetrieveSubjectGuid(
		// IN LPCWSTR FileName, IN HANDLE hFileIn, OUT GUID *pgSubject );
		[DllImport(Lib.Crypt32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("mssip.h", MSDNShortId = "b81472bc-6d9c-4634-a378-e39786a0ca09")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool CryptSIPRetrieveSubjectGuid([MarshalAs(UnmanagedType.LPWStr)] string FileName, HFILE hFileIn, out Guid pgSubject);

		/// <summary>
		/// The <c>CryptSIPRetrieveSubjectGuidForCatalogFile</c> function retrieves the subject GUID associated with the specified file.
		/// </summary>
		/// <param name="FileName">The name of the file. If the hFileIn parameter is set, the value in this parameter is ignored.</param>
		/// <param name="hFileIn">
		/// A handle to the file to check. This parameter must contain a valid handle if the FileName parameter is <c>NULL</c>.
		/// </param>
		/// <param name="pgSubject">A globally unique ID that identifies the subject.</param>
		/// <returns>
		/// <para>The return value is <c>TRUE</c> if the function succeeds; otherwise, <c>FALSE</c>.</para>
		/// <para>
		/// If this function returns <c>FALSE</c>, additional error information can be obtained by calling the GetLastError function.
		/// <c>GetLastError</c> will return one of the following error codes.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>ERROR_INVALID_PARAMETER</term>
		/// <term>One or more of the parameters are not valid.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// This function only supports subject interface packages (SIPs) that are used for portable executable images (.exe), cabinet
		/// (.cab) images, and flat files.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/mssip/nf-mssip-cryptsipretrievesubjectguidforcatalogfile BOOL
		// CryptSIPRetrieveSubjectGuidForCatalogFile( IN LPCWSTR FileName, IN HANDLE hFileIn, OUT GUID *pgSubject );
		[DllImport(Lib.Crypt32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("mssip.h", MSDNShortId = "7f757dc8-948c-476e-aca3-a9051e962ed4")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool CryptSIPRetrieveSubjectGuidForCatalogFile([MarshalAs(UnmanagedType.LPWStr)] string FileName, HFILE hFileIn, out Guid pgSubject);

		/// <summary>The <c>CryptSIPVerifyIndirectData</c> function validates the indirect hashed data against the supplied subject.</summary>
		/// <param name="pSubjectInfo">A pointer to a SIP_SUBJECTINFO structure that contains information about the message subject.</param>
		/// <param name="pIndirectData">A pointer to a SIP_INDIRECT_DATA structure that contains information about the hashed subject information.</param>
		/// <returns>
		/// <para>The return value is <c>TRUE</c> if the function succeeds; otherwise, <c>FALSE</c>.</para>
		/// <para>
		/// If this function returns <c>FALSE</c>, additional error information can be obtained by calling the GetLastError function.
		/// <c>GetLastError</c> will return one of the following error codes.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>ERROR_INVALID_PARAMETER</term>
		/// <term>One or more of the parameters are not valid.</term>
		/// </item>
		/// <item>
		/// <term>TRUST_E_SUBJECT_FORM_UNKNOWN</term>
		/// <term>The subject type is an unknown type.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// Subjects include, but are not limited to, portable executable images (.exe), cabinet (.cab) images, flat files, and catalog
		/// files. Each subject type uses a different subset of its data for hash calculation and requires a different procedure for storage
		/// and retrieval. Therefore each subject type has a unique subject interface package specification.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/mssip/nf-mssip-cryptsipverifyindirectdata BOOL CryptSIPVerifyIndirectData( IN
		// SIP_SUBJECTINFO *pSubjectInfo, IN SIP_INDIRECT_DATA *pIndirectData );
		[DllImport(Lib.Crypt32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("mssip.h", MSDNShortId = "137b8858-a31f-4ef6-96bd-c5e26ae7b3e8")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool CryptSIPVerifyIndirectData(in SIP_SUBJECTINFO pSubjectInfo, in SIP_INDIRECT_DATA pIndirectData);

		/// <summary>The <c>MS_ADDINFO_BLOB</c> structure provides additional information for in-memory BLOB subject types.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/mssip/ns-mssip-ms_addinfo_blob typedef struct MS_ADDINFO_BLOB_ { DWORD
		// cbStruct; DWORD cbMemObject; BYTE *pbMemObject; DWORD cbMemSignedMsg; BYTE *pbMemSignedMsg; } MS_ADDINFO_BLOB, *PMS_ADDINFO_BLOB;
		[PInvokeData("mssip.h", MSDNShortId = "236c8778-0b80-4157-8a81-24712ebf9a77")]
		[StructLayout(LayoutKind.Sequential)]
		public struct MS_ADDINFO_BLOB
		{
			/// <summary>The size, in bytes, of this structure.</summary>
			public uint cbStruct;

			/// <summary>The size, in bytes, of the data in the pbMemObject member.</summary>
			public uint cbMemObject;

			/// <summary>A pointer to the in-memory BLOB subject.</summary>
			public IntPtr pbMemObject;

			/// <summary>The size, in bytes, of the data in the pbMemSignedMsg member.</summary>
			public uint cbMemSignedMsg;

			/// <summary>A pointer to the signed message.</summary>
			public IntPtr pbMemSignedMsg;
		}

		/// <summary>The <c>MS_ADDINFO_CATALOGMEMBER</c> structure provides additional information for catalog member subject types.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/mssip/ns-mssip-ms_addinfo_catalogmember typedef struct
		// MS_ADDINFO_CATALOGMEMBER_ { DWORD cbStruct; struct CRYPTCATSTORE_ *pStore; struct CRYPTCATMEMBER_ *pMember; }
		// MS_ADDINFO_CATALOGMEMBER, *PMS_ADDINFO_CATALOGMEMBER;
		[PInvokeData("mssip.h", MSDNShortId = "40a00c8a-95e4-406c-b04e-0d29beb70d67")]
		[StructLayout(LayoutKind.Sequential)]
		public struct MS_ADDINFO_CATALOGMEMBER
		{
			/// <summary>The size, in bytes, of this structure.</summary>
			public uint cbStruct;

			/// <summary>A CRYPTCATSTORE structure that contains a catalog file store.</summary>
			public IntPtr pStore;

			/// <summary>A CRYPTCATMEMBER structure that contains a catalog member.</summary>
			public IntPtr pMember;
		}

		/// <summary>The <c>MS_ADDINFO_FLAT</c> structure provides additional information about flat or end-to-end subject types.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/mssip/ns-mssip-ms_addinfo_flat typedef struct MS_ADDINFO_FLAT_ { DWORD
		// cbStruct; struct SIP_INDIRECT_DATA_ *pIndirectData; } MS_ADDINFO_FLAT, *PMS_ADDINFO_FLAT;
		[PInvokeData("mssip.h", MSDNShortId = "9f5bebd1-8eda-456d-9339-3334a19c0ea4")]
		[StructLayout(LayoutKind.Sequential)]
		public struct MS_ADDINFO_FLAT
		{
			/// <summary>The size, in bytes, of this structure.</summary>
			public uint cbStruct;

			/// <summary>A SIP_INDIRECT_DATA structure that contains the hash of a flat file subject.</summary>
			public IntPtr pIndirectData;
		}

		/// <summary>
		/// The <c>SIP_ADD_NEWPROVIDER</c> structure defines a subject interface package (SIP). This structure is used by the
		/// CryptSIPAddProvider function.
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/mssip/ns-mssip-sip_add_newprovider typedef struct SIP_ADD_NEWPROVIDER_ { DWORD
		// cbStruct; GUID *pgSubject; WCHAR *pwszDLLFileName; WCHAR *pwszMagicNumber; WCHAR *pwszIsFunctionName; WCHAR *pwszGetFuncName;
		// WCHAR *pwszPutFuncName; WCHAR *pwszCreateFuncName; WCHAR *pwszVerifyFuncName; WCHAR *pwszRemoveFuncName; WCHAR
		// *pwszIsFunctionNameFmt2; PWSTR pwszGetCapFuncName; } SIP_ADD_NEWPROVIDER, *PSIP_ADD_NEWPROVIDER;
		[PInvokeData("mssip.h", MSDNShortId = "5ca88c0c-a7c9-4517-a874-49d38c1bc7c3")]
		[StructLayout(LayoutKind.Sequential)]
		public struct SIP_ADD_NEWPROVIDER
		{
			/// <summary>The size, in bytes, of this structure. Set this value to .</summary>
			public uint cbStruct;

			/// <summary>Pointer to the GUID that identifies the SIP.</summary>
			public GuidPtr pgSubject;

			/// <summary>Pointer to a null-terminated string that contains the name of the DLL file.</summary>
			[MarshalAs(UnmanagedType.LPWStr)] public string pwszDLLFileName;

			/// <summary>This member is not used.</summary>
			[MarshalAs(UnmanagedType.LPWStr)] public string pwszMagicNumber;

			/// <summary>
			/// Pointer to a null-terminated string that contains the name of the function that determines whether the file contents are
			/// supported by this SIP. This member can be <c>NULL</c>. The signature for this function pointer is described in pfnIsFileSupported.
			/// </summary>
			[MarshalAs(UnmanagedType.LPWStr)] public string pwszIsFunctionName;

			/// <summary>
			/// Pointer to a null-terminated string that contains the name of the function that retrieves the signed data. The signature for
			/// this function pointer is described in CryptSIPGetSignedDataMsg.
			/// </summary>
			[MarshalAs(UnmanagedType.LPWStr)] public string pwszGetFuncName;

			/// <summary>
			/// Pointer to a null-terminated string that contains the name of the function that stores the Authenticode signature in the
			/// target file. The signature for this function pointer is described in CryptSIPPutSignedDataMsg.
			/// </summary>
			[MarshalAs(UnmanagedType.LPWStr)] public string pwszPutFuncName;

			/// <summary>
			/// Pointer to a null-terminated string that contains the name of the function that creates the hash. The signature for this
			/// function pointer is described in CryptSIPCreateIndirectData.
			/// </summary>
			[MarshalAs(UnmanagedType.LPWStr)] public string pwszCreateFuncName;

			/// <summary>
			/// Pointer to a null-terminated string that contains the name of the function that verifies the hash. The signature for this
			/// function pointer is described in CryptSIPVerifyIndirectData.
			/// </summary>
			[MarshalAs(UnmanagedType.LPWStr)] public string pwszVerifyFuncName;

			/// <summary>
			/// Pointer to a null-terminated string that contains the name of the function that removes the signed data. The signature for
			/// this function pointer is described in CryptSIPRemoveSignedDataMsg.
			/// </summary>
			[MarshalAs(UnmanagedType.LPWStr)] public string pwszRemoveFuncName;

			/// <summary>
			/// Pointer to a null-terminated string that contains the name of the function that determines whether the file name extension
			/// is supported by this SIP. This member can be <c>NULL</c>. The signature for this function pointer is described in pfnIsFileSupportedName.
			/// </summary>
			[MarshalAs(UnmanagedType.LPWStr)] public string pwszIsFunctionNameFmt2;

			/// <summary>
			/// <para>
			/// Pointer to a null-terminated string that contains the name of the function that determines the capabilities of the SIP. If
			/// this parameter is set to <c>NULL</c>, multiple signatures are not available for this SIP. The signature for this function
			/// pointer is described in pCryptSIPGetCaps.
			/// </para>
			/// <para>
			/// <c>Windows Server 2008 R2, Windows 7, Windows Server 2008, Windows Vista, Windows Server 2003 and Windows XP:</c> This
			/// member is not available.
			/// </para>
			/// </summary>
			[MarshalAs(UnmanagedType.LPWStr)] public string pwszGetCapFuncName;
		}

		/// <summary>The <c>SIP_CAP_SET</c> structure defines the capabilities of a subject interface package (SIP).</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/mssip/ns-mssip-sip_cap_set_v2 typedef struct _SIP_CAP_SET_V2 { DWORD cbSize;
		// DWORD dwVersion; BOOL isMultiSign; DWORD dwReserved; } SIP_CAP_SET_V2, *PSIP_CAP_SET_V2;
		[PInvokeData("mssip.h", MSDNShortId = "0B6D173B-0183-4A7C-BB92-2D451F746164")]
		[StructLayout(LayoutKind.Sequential)]
		public struct SIP_CAP_SET_V2
		{
			/// <summary>Size, in bytes, of this structure.</summary>
			public uint cbSize;

			/// <summary>The SIP version. By default, this value is two (2).</summary>
			public uint dwVersion;

			/// <summary>
			/// A value of one (1) indicates that the SIP supports multiple embedded signatures. Otherwise, set this value to zero (0).
			/// </summary>
			[MarshalAs(UnmanagedType.Bool)] public bool isMultiSign;

			/// <summary>Reserved for future use. Set this value to zero (0).</summary>
			public uint dwReserved;
		}

		/// <summary>The <c>SIP_CAP_SET</c> structure defines the capabilities of a subject interface package (SIP).</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/mssip/ns-mssip-sip_cap_set_v3 typedef struct _SIP_CAP_SET_V3 { DWORD cbSize;
		// DWORD dwVersion; BOOL isMultiSign; union { DWORD dwFlags; DWORD dwReserved; }; } SIP_CAP_SET_V3, *PSIP_CAP_SET_V3;
		[PInvokeData("mssip.h", MSDNShortId = "0B6D173B-0183-4A7C-BB92-2D451F746164")]
		[StructLayout(LayoutKind.Sequential)]
		public struct SIP_CAP_SET_V3
		{
			/// <summary>Size, in bytes, of this structure.</summary>
			public uint cbSize;

			/// <summary>The SIP version. By default, this value is two (2).</summary>
			public uint dwVersion;

			/// <summary>
			/// A value of one (1) indicates that the SIP supports multiple embedded signatures. Otherwise, set this value to zero (0).
			/// </summary>
			[MarshalAs(UnmanagedType.Bool)] public bool isMultiSign;

			/// <summary/>
			public uint dwFlags;

			/// <summary>Reserved for future use. Set this value to zero (0).</summary>
			public uint dwReserved;
		}

		/// <summary>
		/// The <c>SIP_DISPATCH_INFO</c> structure contains a set of function pointers assigned by the CryptSIPLoad function that your
		/// application uses to perform subject interface package (SIP) operations.
		/// </summary>
		/// <remarks>
		/// Your application must initialize this structure to binary zeros and set <c>cbSize</c> to by calling the memset function before
		/// calling the CryptSIPLoad function. Your application can use the function pointers in the returned <c>SIP_DISPATCH_INFO</c>
		/// structure to perform the necessary SIP operations. The function pointers can point to functions exported by third party SIPs.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/mssip/ns-mssip-sip_dispatch_info typedef struct SIP_DISPATCH_INFO_ { DWORD
		// cbSize; HANDLE hSIP; pCryptSIPGetSignedDataMsg pfGet; pCryptSIPPutSignedDataMsg pfPut; pCryptSIPCreateIndirectData pfCreate;
		// pCryptSIPVerifyIndirectData pfVerify; pCryptSIPRemoveSignedDataMsg pfRemove; } SIP_DISPATCH_INFO, *LPSIP_DISPATCH_INFO;
		[PInvokeData("mssip.h", MSDNShortId = "d34b5081-0af8-4dcc-8133-a91d0603d419")]
		[StructLayout(LayoutKind.Sequential)]
		public struct SIP_DISPATCH_INFO
		{
			/// <summary>The size, in bytes, of this structure.</summary>
			public uint cbSize;

			/// <summary>This member is reserved and must be set to <c>NULL</c>.</summary>
			public HANDLE hSIP;

			/// <summary>
			/// A pointer to the function that retrieves the signed data for the subject. The signature for this function pointer is
			/// described in CryptSIPGetSignedDataMsg.
			/// </summary>
			public pCryptSIPGetSignedDataMsg pfGet;

			/// <summary>
			/// A pointer to the function that stores the signed data for the subject. The signature for this function pointer is described
			/// in CryptSIPPutSignedDataMsg.
			/// </summary>
			public pCryptSIPPutSignedDataMsg pfPut;

			/// <summary>
			/// A pointer to the function that returns a SIP_INDIRECT_DATA structure that contains the subject data. This structure contains
			/// the hash of the target. The signature for this function pointer is described in CryptSIPCreateIndirectData.
			/// </summary>
			public pCryptSIPCreateIndirectData pfCreate;

			/// <summary>
			/// A pointer to the function that verifies the SIP_INDIRECT_DATA structure that contains the subject data. This structure
			/// contains the hash of the target. The signature for this function pointer is described in CryptSIPVerifyIndirectData.
			/// </summary>
			public pCryptSIPVerifyIndirectData pfVerify;

			/// <summary>
			/// A pointer to the function that removes the signed data for the subject. The signature for this function pointer is described
			/// in CryptSIPRemoveSignedDataMsg.
			/// </summary>
			public pCryptSIPRemoveSignedDataMsg pfRemove;
		}

		/// <summary>The <c>SIP_INDIRECT_DATA</c> structure contains the digest of the hashed subject information.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/mssip/ns-mssip-sip_indirect_data typedef struct SIP_INDIRECT_DATA_ {
		// CRYPT_ATTRIBUTE_TYPE_VALUE Data; CRYPT_ALGORITHM_IDENTIFIER DigestAlgorithm; CRYPT_HASH_BLOB Digest; } SIP_INDIRECT_DATA, *PSIP_INDIRECT_DATA;
		[PInvokeData("mssip.h", MSDNShortId = "d34b599b-fe49-47c4-bb52-73ee14d73253")]
		[StructLayout(LayoutKind.Sequential)]
		public struct SIP_INDIRECT_DATA
		{
			/// <summary>A CRYPT_ATTRIBUTE_TYPE_VALUE structure used to encode the attribute.</summary>
			public CRYPT_ATTRIBUTE_TYPE_VALUE Data;

			/// <summary>A CRYPT_ALGORITHM_IDENTIFIER structure that contains the digest algorithm to use to create the hash.</summary>
			public CRYPT_ALGORITHM_IDENTIFIER DigestAlgorithm;

			/// <summary>
			/// A CRYPT_HASH_BLOB structure that contains the hash of the subject. For information about <c>CRYPT_HASH_BLOB</c>, see <c>CRYPT_INTEGER_BLOB</c>.
			/// </summary>
			public CRYPTOAPI_BLOB Digest;
		}

		/// <summary>The <c>SIP_SUBJECTINFO</c> structure specifies subject information data to the subject interface package (SIP) APIs.</summary>
		/// <remarks>
		/// <para>
		/// Upon first use of the <c>SIP_SUBJECTINFO</c> structure, initialize the entire structure to binary zero. Do not initialize the
		/// structure between SIP function calls.
		/// </para>
		/// <para>
		/// Subjects include, but are not limited to, portable executable images (.exe), cabinet (.cab) images, flat files, and catalog
		/// files. Each subject type uses a different subset of its data for hash calculation and requires a different procedure for storage
		/// and retrieval. Therefore each subject type has a unique subject interface package specification.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/mssip/ns-mssip-sip_subjectinfo typedef struct SIP_SUBJECTINFO_ { DWORD cbSize;
		// GUID *pgSubjectType; HANDLE hFile; LPCWSTR pwsFileName; LPCWSTR pwsDisplayName; DWORD dwReserved1; DWORD dwIntVersion; HCRYPTPROV
		// hProv; CRYPT_ALGORITHM_IDENTIFIER DigestAlgorithm; DWORD dwFlags; DWORD dwEncodingType; DWORD dwReserved2; DWORD fdwCAPISettings;
		// DWORD fdwSecuritySettings; DWORD dwIndex; DWORD dwUnionChoice; union { #if ... MS_ADDINFO_FLAT_ *psFlat; #else struct
		// MS_ADDINFO_FLAT_ *psFlat; #endif #if ... MS_ADDINFO_CATALOGMEMBER_ *psCatMember; #else struct MS_ADDINFO_CATALOGMEMBER_
		// *psCatMember; #endif #if ... MS_ADDINFO_BLOB_ *psBlob; #else struct MS_ADDINFO_BLOB_ *psBlob; #endif }; LPVOID pClientData; }
		// SIP_SUBJECTINFO, *LPSIP_SUBJECTINFO;
		[PInvokeData("mssip.h", MSDNShortId = "6274cd08-d67f-410d-9303-3a42b7f1edc6")]
		[StructLayout(LayoutKind.Sequential)]
		public struct SIP_SUBJECTINFO
		{
			/// <summary>The size, in bytes, of this structure.</summary>
			public uint cbSize;

			/// <summary>A pointer to a <c>GUID</c> structure that identifies the subject type.</summary>
			public GuidPtr pgSubjectType;

			/// <summary>
			/// A file handle that represents the subject. If the storage type of the subject is a file, set hFile to
			/// <c>INVALID_HANDLE_VALUE</c> and set the pwsFileName parameter to the name of the file.
			/// </summary>
			public HFILE hFile;

			/// <summary>A pointer to a null-terminated Unicode string that contains the file name of the subject.</summary>
			[MarshalAs(UnmanagedType.LPWStr)] public string pwsFileName;

			/// <summary>A pointer to a null-terminated Unicode string that contains the display name of the subject.</summary>
			[MarshalAs(UnmanagedType.LPWStr)] public string pwsDisplayName;

			/// <summary>This member is reserved for future use.</summary>
			public uint dwReserved1;

			/// <summary>
			/// This member is reserved. Do not modify this member. It is used by the SIP to pass the internal version number between get
			/// and verify functions.
			/// </summary>
			public uint dwIntVersion;

			/// <summary>An HCRYPTPROV handle to the cryptography provider.</summary>
			public HCRYPTPROV hProv;

			/// <summary>
			/// A CRYPT_ALGORITHM_IDENTIFIER structure that contains the identifier for the hash algorithm used to hash the file.
			/// </summary>
			public CRYPT_ALGORITHM_IDENTIFIER DigestAlgorithm;

			/// <summary>
			/// A value that modifies the behavior of the functions that use this structure. For more information about possible values for
			/// this member, see the dwFlags parameter of SignerSignEx.
			/// </summary>
			public uint dwFlags;

			/// <summary>
			/// A value that specifies the encoding type used for the file. Currently, only <c>X509_ASN_ENCODING</c> and
			/// <c>PKCS_7_ASN_ENCODING</c> are being used; however, additional encoding types may be added in the future. For either current
			/// encoding type, use: <c>X509_ASN_ENCODING</c> | <c>PKCS_7_ASN_ENCODING</c>.
			/// </summary>
			public CertEncodingType dwEncodingType;

			/// <summary>This member is reserved for future use.</summary>
			public uint dwReserved2;

			/// <summary>This member is not used.</summary>
			public uint fdwCAPISettings;

			/// <summary>This member is not used.</summary>
			public uint fdwSecuritySettings;

			/// <summary>The message index of the last call to <c>CryptSIPGetSignedDataMsg</c>. operation.</summary>
			public uint dwIndex;

			/// <summary>
			/// <para>Specifies the type of additional information provided.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Defined constant/value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>MSSIP_ADDINFO_NONE 0</term>
			/// <term>There is no additional information about the subject.</term>
			/// </item>
			/// <item>
			/// <term>MSSIP_ADDINFO_FLAT 1</term>
			/// <term>The additional information is a flat file.</term>
			/// </item>
			/// <item>
			/// <term>MSSIP_ADDINFO_CATMEMBER 2</term>
			/// <term>The additional information is a catalog member.</term>
			/// </item>
			/// <item>
			/// <term>MSSIP_ADDINFO_BLOB 3</term>
			/// <term>The additional information is a BLOB.</term>
			/// </item>
			/// <item>
			/// <term>MSSIP_ADDINFO_NONMSSIP 500</term>
			/// <term>The additional information is in a user defined format.</term>
			/// </item>
			/// </list>
			/// </summary>
			public uint dwUnionChoice;

			/// <summary>A pointer to either a MS_ADDINFO_FLAT, MS_ADDINFO_CATALOGMEMBER, or MS_ADDINFO_BLOB structure.</summary>
			public IntPtr pUnionData;

			/// <summary>A pointer to SIP-specific data.</summary>
			public IntPtr pClientData;
		}
	}
}