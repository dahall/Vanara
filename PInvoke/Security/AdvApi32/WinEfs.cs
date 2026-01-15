using static Vanara.PInvoke.Crypt32;
using static Vanara.PInvoke.Kernel32;

namespace Vanara.PInvoke;

public static partial class AdvApi32
{
	/// <summary>Adds user keys to the specified encrypted file.</summary>
	/// <param name="lpFileName">The name of the encrypted file.</param>
	/// <param name="pEncryptionCertificates">
	/// A pointer to an ENCRYPTION_CERTIFICATE_LIST structure that contains the list of new user keys to be added to the file.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is <c>ERROR_SUCCESS</c>.</para>
	/// <para>
	/// If the function fails, the return value is a system error code. For a complete list of error codes, see System Error Codes or the
	/// header file WinError.h.
	/// </para>
	/// </returns>
	/// <remarks>
	/// <para>Starting with Windows 8 and Windows Server 2012, this function is supported by the following technologies.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Technology</term>
	/// <term>Supported</term>
	/// </listheader>
	/// <item>
	/// <term>Server Message Block (SMB) 3.0 protocol</term>
	/// <term>No</term>
	/// </item>
	/// <item>
	/// <term>SMB 3.0 Transparent Failover (TFO)</term>
	/// <term>No</term>
	/// </item>
	/// <item>
	/// <term>SMB 3.0 with Scale-out File Shares (SO)</term>
	/// <term>No</term>
	/// </item>
	/// <item>
	/// <term>Cluster Shared Volume File System (CsvFS)</term>
	/// <term>No</term>
	/// </item>
	/// <item>
	/// <term>Resilient File System (ReFS)</term>
	/// <term>No</term>
	/// </item>
	/// </list>
	/// <para>SMB 3.0 does not support EFS on shares with continuous availability capability.</para>
	/// <para>Examples</para>
	/// <para>For example code that uses this function, see Adding Users to an Encrypted File.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/winefs/nf-winefs-adduserstoencryptedfile DWORD AddUsersToEncryptedFile( LPCWSTR
	// lpFileName, PENCRYPTION_CERTIFICATE_LIST pEncryptionCertificates );
	[DllImport(Lib.AdvApi32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("winefs.h", MSDNShortId = "a92d6a52-20d1-4d5c-a222-ab9afaf85c4b")]
	public static extern Win32Error AddUsersToEncryptedFile([MarshalAs(UnmanagedType.LPWStr)] string lpFileName, in ENCRYPTION_CERTIFICATE_LIST pEncryptionCertificates);

	/// <summary>Copies the EFS metadata from one file or directory to another.</summary>
	/// <param name="SrcFileName">
	/// The name of the file or directory from which the EFS metadata is to be copied. This source file or directory must be encrypted.
	/// </param>
	/// <param name="DstFileName">
	/// <para>The name of the file or directory to which the EFS metadata is to be copied.</para>
	/// <para>
	/// This destination file or directory does not have to be encrypted before the call to this function; however if this function
	/// completes successfully, it will be encrypted.
	/// </para>
	/// <para>
	/// If the value of SrcFileName specifies a file, the value of this parameter must also specify a file, and likewise for directories.
	/// If a file or directory with the name specified by this parameter does not exist, a file or directory (depending on whether
	/// SrcFileName specifies a file or directory) will be created.
	/// </para>
	/// </param>
	/// <param name="dwCreationDistribution">
	/// <para>
	/// Describes how the destination file or directory identified by the DstFileName parameter value is to be opened. The following are
	/// the valid values of this parameter.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>CREATE_ALWAYS 2</term>
	/// <term>
	/// Always create the destination file or directory. Any value passed in this parameter other than CREATE_NEW will be processed as CREATE_ALWAYS.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CREATE_NEW 1</term>
	/// <term>
	/// Create the destination file or directory only if it does not already exist. If it does exist, and this value is specified, this
	/// function will fail.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="dwAttributes">
	/// The file attributes of the destination file or directory. The <c>FILE_READ_ONLY</c> attribute is currently not processed by this function.
	/// </param>
	/// <param name="lpSecurityAttributes">
	/// A pointer to a SECURITY_ATTRIBUTES structure that specifies the security attributes of the destination file or directory, if it
	/// does not already exist. If you specify <c>NULL</c>, the file or directory gets a default security descriptor. The ACLs in the
	/// default security descriptor for a file or directory are inherited from its parent directory.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is <c>ERROR_SUCCESS</c>.</para>
	/// <para>
	/// If the function fails, the return value is a system error code. For a complete list of error codes, see System Error Codes or the
	/// header file WinError.h.
	/// </para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// Exclusive access to the destination file or directory is required by EFS for the call to this function. If this access is not
	/// provided, this function will fail.
	/// </para>
	/// <para>
	/// The caller should have the EFS key for the source file or directory, and at least the <c>READ_ATTRIBUTE</c> ACL for the source
	/// file or directory.
	/// </para>
	/// <para>
	/// The specified source and destination file or directories should reside on the same computer; otherwise, an error will be returned.
	/// </para>
	/// <para>In Windows 8 and Windows Server 2012, this function is supported by the following technologies.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Technology</term>
	/// <term>Supported</term>
	/// </listheader>
	/// <item>
	/// <term>Server Message Block (SMB) 3.0 protocol</term>
	/// <term>Yes</term>
	/// </item>
	/// <item>
	/// <term>SMB 3.0 Transparent Failover (TFO)</term>
	/// <term>No</term>
	/// </item>
	/// <item>
	/// <term>SMB 3.0 with Scale-out File Shares (SO)</term>
	/// <term>No</term>
	/// </item>
	/// <item>
	/// <term>Cluster Shared Volume File System (CsvFS)</term>
	/// <term>No</term>
	/// </item>
	/// <item>
	/// <term>Resilient File System (ReFS)</term>
	/// <term>No</term>
	/// </item>
	/// </list>
	/// <para>SMB 3.0 does not support EFS on shares with continuous availability capability.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/winefs/nf-winefs-duplicateencryptioninfofile DWORD DuplicateEncryptionInfoFile(
	// LPCWSTR SrcFileName, LPCWSTR DstFileName, DWORD dwCreationDistribution, DWORD dwAttributes, const LPSECURITY_ATTRIBUTES
	// lpSecurityAttributes );
	[DllImport(Lib.AdvApi32, SetLastError = false, ExactSpelling = true, CharSet = CharSet.Unicode)]
	[PInvokeData("winefs.h", MSDNShortId = "c830ae98-3649-4981-9369-7d4cb019b50f")]
	public static extern Win32Error DuplicateEncryptionInfoFile(string SrcFileName, string DstFileName, CreationOption dwCreationDistribution,
		FileFlagsAndAttributes dwAttributes, [Optional] SECURITY_ATTRIBUTES? lpSecurityAttributes);

	/// <summary>
	/// Disables or enables encryption of the specified directory and the files in it. It does not affect encryption of subdirectories
	/// below the indicated directory.
	/// </summary>
	/// <param name="DirPath">The name of the directory for which to enable or disable encryption.</param>
	/// <param name="Disable">Indicates whether to disable encryption ( <c>TRUE</c>) or enable it ( <c>FALSE</c>).</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// Under normal circumstances, EncryptFile will not encrypt files and directories with the <c>FILE_ATTRIBUTE_SYSTEM</c> attribute
	/// set. It is possible to override the <c>FILE_ATTRIBUTE_SYSTEM</c> attribute and encrypt files. Also, if a file or directory is
	/// marked with the <c>FILE_ATTRIBUTE_SYSTEM</c> attribute, it will normally be invisible to the user in directory listings and
	/// Windows Explorer directory windows. <c>EncryptionDisable</c> disables encryption of directories and files. It does not affect the
	/// visibility of files with the <c>FILE_ATTRIBUTE_SYSTEM</c> attribute set.
	/// </para>
	/// <para>
	/// If <c>TRUE</c> is passed in, <c>EncryptionDisable</c> will write the following to the Desktop.ini file in the directory (creating
	/// it if necessary):
	/// </para>
	/// <para>If the section already exists but Disable is set to 0, it will be set to 1.</para>
	/// <para>
	/// Thereafter, EncryptFile will fail on the directory and the files in it, and the code that GetLastError returns will be
	/// <c>ERROR_DIR_EFS_DISALLOWED</c>. This function does not affect encryption of subdirectories within the given directory.
	/// </para>
	/// <para>The user can also manually add or edit the above lines in the Desktop.ini file and produce the same effect.</para>
	/// <para>
	/// <c>EncryptionDisable</c> affects only FileEncryptionStatus and EncryptFile. After the directory is encrypted, any new files and
	/// new subdirectories created without the <c>FILE_ATTRIBUTE_SYSTEM</c> attribute will be encrypted.
	/// </para>
	/// <para>If <c>FALSE</c> is passed in, <c>EncryptionDisable</c> will write the following to the Desktop.ini file:</para>
	/// <para>This means that file encryption is permitted on the files in that directory.</para>
	/// <para>
	/// If you try to use <c>EncryptionDisable</c> to set the directory to the state it is already in, the function succeeds but has no effect.
	/// </para>
	/// <para>If you try to use <c>EncryptionDisable</c> to disable or enable encryption on a file, the attempt will fail.</para>
	/// <para>In Windows 8 and Windows Server 2012, this function is supported by the following technologies.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Technology</term>
	/// <term>Supported</term>
	/// </listheader>
	/// <item>
	/// <term>Server Message Block (SMB) 3.0 protocol</term>
	/// <term>Yes</term>
	/// </item>
	/// <item>
	/// <term>SMB 3.0 Transparent Failover (TFO)</term>
	/// <term>No</term>
	/// </item>
	/// <item>
	/// <term>SMB 3.0 with Scale-out File Shares (SO)</term>
	/// <term>No</term>
	/// </item>
	/// <item>
	/// <term>Cluster Shared Volume File System (CsvFS)</term>
	/// <term>No</term>
	/// </item>
	/// <item>
	/// <term>Resilient File System (ReFS)</term>
	/// <term>No</term>
	/// </item>
	/// </list>
	/// <para>SMB 3.0 does not support EFS on shares with continuous availability capability.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winefs/nf-winefs-encryptiondisable BOOL EncryptionDisable( LPCWSTR DirPath,
	// BOOL Disable );
	[DllImport(Lib.AdvApi32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("winefs.h", MSDNShortId = "6ff93a90-c1cf-4782-862c-d3d7e294c4b0")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool EncryptionDisable([MarshalAs(UnmanagedType.LPWStr)] string DirPath, [MarshalAs(UnmanagedType.Bool)] bool Disable);

	/// <summary>Frees a certificate hash list.</summary>
	/// <param name="pUsers">
	/// A pointer to a certificate hash list structure, ENCRYPTION_CERTIFICATE_HASH_LIST, which was returned by the
	/// QueryUsersOnEncryptedFile or QueryRecoveryAgentsOnEncryptedFile function.
	/// </param>
	/// <returns>This function does not return a value.</returns>
	/// <remarks><c>ReFS:</c> This function is not supported.</remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winefs/nf-winefs-freeencryptioncertificatehashlist void
	// FreeEncryptionCertificateHashList( PENCRYPTION_CERTIFICATE_HASH_LIST pUsers );
	[DllImport(Lib.AdvApi32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("winefs.h", MSDNShortId = "63d5811f-a135-45b0-8f23-fd8851f7bcca")]
	public static extern void FreeEncryptionCertificateHashList(IntPtr pUsers);

	/// <summary>Retrieves a list of recovery agents for the specified file.</summary>
	/// <param name="lpFileName">The name of the file.</param>
	/// <param name="pRecoveryAgents">A pointer to a ENCRYPTION_CERTIFICATE_HASH_LIST structure that receives a list of recovery agents.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is <c>ERROR_SUCCESS</c>.</para>
	/// <para>
	/// If the function fails, the return value is a system error code. For a complete list of error codes, see System Error Codes or the
	/// header file WinError.h.
	/// </para>
	/// </returns>
	/// <remarks>
	/// <para>When the list of recovery agents is no longer needed, free it by calling the FreeEncryptionCertificateHashList function.</para>
	/// <para>In Windows 8, Windows Server 2012, and later, this function is supported by the following technologies.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Technology</term>
	/// <term>Supported</term>
	/// </listheader>
	/// <item>
	/// <term>Server Message Block (SMB) 3.0 protocol</term>
	/// <term>Yes</term>
	/// </item>
	/// <item>
	/// <term>SMB 3.0 Transparent Failover (TFO)</term>
	/// <term>No</term>
	/// </item>
	/// <item>
	/// <term>SMB 3.0 with Scale-out File Shares (SO)</term>
	/// <term>No</term>
	/// </item>
	/// <item>
	/// <term>Cluster Shared Volume File System (CsvFS)</term>
	/// <term>No</term>
	/// </item>
	/// <item>
	/// <term>Resilient File System (ReFS)</term>
	/// <term>No</term>
	/// </item>
	/// </list>
	/// <para>SMB 3.0 does not support EFS on shares with continuous availability capability.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winefs/nf-winefs-queryrecoveryagentsonencryptedfile DWORD
	// QueryRecoveryAgentsOnEncryptedFile( LPCWSTR lpFileName, PENCRYPTION_CERTIFICATE_HASH_LIST *pRecoveryAgents );
	[DllImport(Lib.AdvApi32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("winefs.h", MSDNShortId = "2f8d0673-3c87-46a4-b7d5-3888d20bd9b8")]
	public static extern Win32Error QueryRecoveryAgentsOnEncryptedFile([MarshalAs(UnmanagedType.LPWStr)] string lpFileName, out SafeENCRYPTION_CERTIFICATE_HASH_LIST pRecoveryAgents);

	/// <summary>Retrieves a list of users for the specified file.</summary>
	/// <param name="lpFileName">The name of the file.</param>
	/// <param name="pUsers">A pointer to a ENCRYPTION_CERTIFICATE_HASH_LIST structure that receives the list of users.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is <c>ERROR_SUCCESS</c>.</para>
	/// <para>
	/// If the function fails, the return value is a system error code. For a complete list of error codes, see System Error Codes or the
	/// header file WinError.h.
	/// </para>
	/// </returns>
	/// <remarks>
	/// <para>When the list of users is no longer needed, call the FreeEncryptionCertificateHashList function to free the list.</para>
	/// <para>In Windows 8, Windows Server 2012, and later, this function is supported by the following technologies.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Technology</term>
	/// <term>Supported</term>
	/// </listheader>
	/// <item>
	/// <term>Server Message Block (SMB) 3.0 protocol</term>
	/// <term>Yes</term>
	/// </item>
	/// <item>
	/// <term>SMB 3.0 Transparent Failover (TFO)</term>
	/// <term>No</term>
	/// </item>
	/// <item>
	/// <term>SMB 3.0 with Scale-out File Shares (SO)</term>
	/// <term>No</term>
	/// </item>
	/// <item>
	/// <term>Cluster Shared Volume File System (CsvFS)</term>
	/// <term>No</term>
	/// </item>
	/// <item>
	/// <term>Resilient File System (ReFS)</term>
	/// <term>No</term>
	/// </item>
	/// </list>
	/// <para>SMB 3.0 does not support EFS on shares with continuous availability capability.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winefs/nf-winefs-queryusersonencryptedfile DWORD QueryUsersOnEncryptedFile(
	// LPCWSTR lpFileName, PENCRYPTION_CERTIFICATE_HASH_LIST *pUsers );
	[DllImport(Lib.AdvApi32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("winefs.h", MSDNShortId = "1bdab753-e7f2-4c08-8b37-3903c0842227")]
	public static extern Win32Error QueryUsersOnEncryptedFile([MarshalAs(UnmanagedType.LPWStr)] string lpFileName, out SafeENCRYPTION_CERTIFICATE_HASH_LIST pUsers);

	/// <summary>Removes specified certificate hashes from a specified file.</summary>
	/// <param name="lpFileName">The name of the file.</param>
	/// <param name="pHashes">
	/// A pointer to an ENCRYPTION_CERTIFICATE_HASH_LIST structure that contains a list of certificate hashes to be removed from the file.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is <c>ERROR_SUCCESS</c>.</para>
	/// <para>
	/// If the function fails, the return value is a system error code. For a complete list of error codes, see System Error Codes or the
	/// header file WinError.h.
	/// </para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The <c>RemoveUsersFromEncryptedFile</c> function removes the specified certificate hashes if they exist in the specified file. If
	/// any of the certificate hashes are not found in the specified file, they are ignored and no error code is returned.
	/// </para>
	/// <para>Starting with Windows 8 and Windows Server 2012, this function is supported by the following technologies.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Technology</term>
	/// <term>Supported</term>
	/// </listheader>
	/// <item>
	/// <term>Server Message Block (SMB) 3.0 protocol</term>
	/// <term>Yes</term>
	/// </item>
	/// <item>
	/// <term>SMB 3.0 Transparent Failover (TFO)</term>
	/// <term>No</term>
	/// </item>
	/// <item>
	/// <term>SMB 3.0 with Scale-out File Shares (SO)</term>
	/// <term>No</term>
	/// </item>
	/// <item>
	/// <term>Cluster Shared Volume File System (CsvFS)</term>
	/// <term>No</term>
	/// </item>
	/// <item>
	/// <term>Resilient File System (ReFS)</term>
	/// <term>No</term>
	/// </item>
	/// </list>
	/// <para>SMB 3.0 does not support EFS on shares with continuous availability capability.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winefs/nf-winefs-removeusersfromencryptedfile DWORD
	// RemoveUsersFromEncryptedFile( LPCWSTR lpFileName, PENCRYPTION_CERTIFICATE_HASH_LIST pHashes );
	[DllImport(Lib.AdvApi32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("winefs.h", MSDNShortId = "c6672581-24b4-464c-b32d-48a04e56eef8")]
	public static unsafe extern Win32Error RemoveUsersFromEncryptedFile([MarshalAs(UnmanagedType.LPWStr)] string lpFileName, in ENCRYPTION_CERTIFICATE_HASH_LIST pHashes);

	/// <summary>Sets the user's current key to the specified certificate.</summary>
	/// <param name="pEncryptionCertificate">
	/// A pointer to a certificate that will be the user's key. This parameter is a pointer to an ENCRYPTION_CERTIFICATE structure.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is <c>ERROR_SUCCESS</c>.</para>
	/// <para>
	/// If the function fails, the return value is a system error code. For a complete list of error codes, see System Error Codes or the
	/// header file WinError.h.
	/// </para>
	/// </returns>
	/// <remarks>
	/// <para>In Windows 8 and Windows Server 2012, this function is supported by the following technologies.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Technology</term>
	/// <term>Supported</term>
	/// </listheader>
	/// <item>
	/// <term>Server Message Block (SMB) 3.0 protocol</term>
	/// <term>Yes</term>
	/// </item>
	/// <item>
	/// <term>SMB 3.0 Transparent Failover (TFO)</term>
	/// <term>No</term>
	/// </item>
	/// <item>
	/// <term>SMB 3.0 with Scale-out File Shares (SO)</term>
	/// <term>No</term>
	/// </item>
	/// <item>
	/// <term>Cluster Shared Volume File System (CsvFS)</term>
	/// <term>No</term>
	/// </item>
	/// <item>
	/// <term>Resilient File System (ReFS)</term>
	/// <term>No</term>
	/// </item>
	/// </list>
	/// <para>SMB 3.0 does not support EFS on shares with continuous availability capability.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winefs/nf-winefs-setuserfileencryptionkey DWORD SetUserFileEncryptionKey(
	// PENCRYPTION_CERTIFICATE pEncryptionCertificate );
	[DllImport(Lib.AdvApi32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("winefs.h", MSDNShortId = "dd23fab7-1675-4d0d-911c-e2aac2273e7f")]
	public static extern Win32Error SetUserFileEncryptionKey(in ENCRYPTION_CERTIFICATE pEncryptionCertificate);

	/// <summary>Contains a certificate.</summary>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winefs/ns-winefs-_certificate_blob typedef struct _CERTIFICATE_BLOB { DWORD
	// dwCertEncodingType; DWORD cbData; PBYTE pbData; } EFS_CERTIFICATE_BLOB, *PEFS_CERTIFICATE_BLOB;
	[PInvokeData("winefs.h", MSDNShortId = "e0d0aa0a-ac87-4734-93d0-30c2080319e8")]
	[StructLayout(LayoutKind.Sequential)]
	public struct EFS_CERTIFICATE_BLOB
	{
		/// <summary>
		/// <para>A certificate encoding type. This member can be one of the following values.</para>
		/// <para>CRYPT_ASN_ENCODING</para>
		/// <para>CRYPT_NDR_ENCODING</para>
		/// <para>X509_ASN_ENCODING</para>
		/// <para>X509_NDR_ENCODING</para>
		/// </summary>
		public CertEncodingType dwCertEncodingType;

		/// <summary>The number of bytes in the <c>pbData</c> buffer.</summary>
		public uint cbData;

		/// <summary>The binary certificate. The <c>dwCertEncodingType</c> member specifies the format for this certificate.</summary>
		public IntPtr pbData;
	}

	/// <summary>Contains a certificate hash.</summary>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winefs/ns-winefs-_efs_hash_blob typedef struct _EFS_HASH_BLOB { DWORD cbData;
	// PBYTE pbData; } EFS_HASH_BLOB, *PEFS_HASH_BLOB;
	[PInvokeData("winefs.h", MSDNShortId = "23a172be-6e94-4a1f-afde-fc9437443c7a")]
	[StructLayout(LayoutKind.Sequential)]
	public struct EFS_HASH_BLOB
	{
		/// <summary>The number of bytes in the <c>pbData</c> buffer.</summary>
		public uint cbData;

		/// <summary>The certificate hash.</summary>
		public IntPtr pbData;
	}

	/// <summary>Contains a certificate and the SID of its owner.</summary>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winefs/ns-winefs-_encryption_certificate typedef struct
	// _ENCRYPTION_CERTIFICATE { DWORD cbTotalLength; SID *pUserSid; PEFS_CERTIFICATE_BLOB pCertBlob; } ENCRYPTION_CERTIFICATE, *PENCRYPTION_CERTIFICATE;
	[PInvokeData("winefs.h", MSDNShortId = "33b36659-48bb-4297-8142-f8702db03d20")]
	[StructLayout(LayoutKind.Sequential)]
	public struct ENCRYPTION_CERTIFICATE
	{
		/// <summary>The length of this structure, in bytes.</summary>
		public uint cbTotalLength;

		/// <summary>The SID of the user who owns the certificate.</summary>
		public PSID pUserSid;

		/// <summary>A pointer to an EFS_CERTIFICATE_BLOB structure.</summary>
		public IntPtr pCertBlob;
	}

	/// <summary>Contains a certificate hash and display information for the certificate.</summary>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winefs/ns-winefs-_encryption_certificate_hash typedef struct
	// _ENCRYPTION_CERTIFICATE_HASH { DWORD cbTotalLength; SID *pUserSid; PEFS_HASH_BLOB pHash; PWSTR lpDisplayInformation; }
	// ENCRYPTION_CERTIFICATE_HASH, *PENCRYPTION_CERTIFICATE_HASH;
	[PInvokeData("winefs.h", MSDNShortId = "6930446c-5338-4ff9-a662-791fc9e7cefe")]
	[StructLayout(LayoutKind.Sequential)]
	public struct ENCRYPTION_CERTIFICATE_HASH
	{
		/// <summary>The length of this structure, in bytes.</summary>
		public uint cbTotalLength;

		/// <summary>The SID of the user who created the certificate. This member is optional and can be <c>NULL</c>.</summary>
		public PSID pUserSid;

		/// <summary>A pointer to an EFS_HASH_BLOB structure.</summary>
		public IntPtr pHash;

		/// <summary>
		/// User-displayable information for the certificate. This is usually the user's common name and universal principal name (UPN).
		/// </summary>
		public PWSTR lpDisplayInformation;
	}

	/// <summary>Contains a list of certificate hashes.</summary>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winefs/ns-winefs-_encryption_certificate_hash_list typedef struct
	// _ENCRYPTION_CERTIFICATE_HASH_LIST { DWORD nCert_Hash; PENCRYPTION_CERTIFICATE_HASH *pUsers; } ENCRYPTION_CERTIFICATE_HASH_LIST, *PENCRYPTION_CERTIFICATE_HASH_LIST;
	[PInvokeData("winefs.h", MSDNShortId = "988159b3-3cb9-4a4d-9c68-ebfb309cff25")]
	[StructLayout(LayoutKind.Sequential)]
	public struct ENCRYPTION_CERTIFICATE_HASH_LIST
	{
		/// <summary>The number of certificate hashes in the list.</summary>
		public uint nCert_Hash;

		/// <summary>A pointer to the first ENCRYPTION_CERTIFICATE_HASH structure in the list.</summary>
		public IntPtr pUsers;
	}

	/// <summary>Contains a list of certificates.</summary>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winefs/ns-winefs-_encryption_certificate_list typedef struct
	// _ENCRYPTION_CERTIFICATE_LIST { DWORD nUsers; PENCRYPTION_CERTIFICATE *pUsers; } ENCRYPTION_CERTIFICATE_LIST, *PENCRYPTION_CERTIFICATE_LIST;
	[PInvokeData("winefs.h", MSDNShortId = "e1914b96-2fba-49ed-9dd2-464659323eda")]
	[StructLayout(LayoutKind.Sequential)]
	public struct ENCRYPTION_CERTIFICATE_LIST
	{
		/// <summary>The number of certificates in the list.</summary>
		public uint nUsers;

		/// <summary>A pointer to the first ENCRYPTION_CERTIFICATE structure in the list.</summary>
		public IntPtr pUsers;
	}

	/// <summary>Provides a <see cref="SafeHandle"/> for <see cref="ENCRYPTION_CERTIFICATE_HASH_LIST"/> that is disposed using <see cref="FreeEncryptionCertificateHashList"/>.</summary>
	[AutoSafeHandle("{ FreeEncryptionCertificateHashList(handle); return true; }")]
	public partial class SafeENCRYPTION_CERTIFICATE_HASH_LIST
	{
		/// <summary>Gets the certificate hash items.</summary>
		public ENCRYPTION_CERTIFICATE_HASH[] Items
		{
			get
			{
				unsafe
				{
					var l = GetList();
					var pUsers = *(ENCRYPTION_CERTIFICATE_HASH**)l->pUsers;
					var ret = new ENCRYPTION_CERTIFICATE_HASH[l->nCert_Hash];
					for (var i = 0; i < l->nCert_Hash; i++)
						ret[i] = pUsers[i];
					return ret;
				}
			}
		}

		/// <summary>Performs an implicit conversion from <see cref="SafeENCRYPTION_CERTIFICATE_HASH_LIST"/> to <see cref="ENCRYPTION_CERTIFICATE_HASH_LIST"/>.</summary>
		/// <param name="l">The list.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator ENCRYPTION_CERTIFICATE_HASH_LIST(SafeENCRYPTION_CERTIFICATE_HASH_LIST l) { unsafe { return *l.GetList(); } }

		private unsafe ENCRYPTION_CERTIFICATE_HASH_LIST* GetList() => (ENCRYPTION_CERTIFICATE_HASH_LIST*)(void*)handle;
	}
}