using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Security.AccessControl;
using static Vanara.PInvoke.Kernel32;

namespace Vanara.PInvoke;

public static partial class AdvApi32
{
	/// <summary>size of alert string in server</summary>
	public const int ALERTSZ = 128;

	/// <summary>Length of client type string</summary>
	public const int CLTYPE_LEN = 12;

	/// <summary>Computer name length</summary>
	public const int CNLEN = 15;

	/// <summary/>
	public const int CRYPT_KEY_LEN = 7;

	/// <summary/>
	public const int CRYPT_TXT_LEN = 8;

	/// <summary>Device name length</summary>
	public const int DEVLEN = 80;

	/// <summary>Maximum domain name length</summary>
	public const int DNLEN = CNLEN;

	/// <summary/>
	public const int ENCRYPTED_PWLEN = 16;

	/// <summary>Event name length</summary>
	public const int EVLEN = 16;

	/// <summary>Group name</summary>
	public const int GNLEN = UNLEN;

	/// <summary>LM 2.0 Computer name length</summary>
	public const int LM20_CNLEN = 15;

	/// <summary>LM 2.0 Device name length</summary>
	public const int LM20_DEVLEN = 8;

	/// <summary>LM 2.0 Maximum domain name length</summary>
	public const int LM20_DNLEN = LM20_CNLEN;

	/// <summary>LM 2.0 Group name</summary>
	public const int LM20_GNLEN = LM20_UNLEN;

	/// <summary>LM 2.0 Multipurpose comment length</summary>
	public const int LM20_MAXCOMMENTSZ = 48;

	/// <summary>LM 2.0 Net name length</summary>
	public const int LM20_NNLEN = 12;

	/// <summary>LM 2.0 Max. path</summary>
	public const int LM20_PATHLEN = 256;

	/// <summary>LM 2.0 Maximum password length</summary>
	public const int LM20_PWLEN = 14;

	/// <summary>LM 2.0 Queue name maximum length</summary>
	public const int LM20_QNLEN = LM20_NNLEN;

	/// <summary>LM 2.0 Max remote name length</summary>
	public const int LM20_RMLEN = (LM20_UNCLEN + 1 + LM20_NNLEN);

	/// <summary>LM 2.0 Service name length</summary>
	public const int LM20_SNLEN = 15;

	/// <summary>LM 2.0 Service text length</summary>
	public const int LM20_STXTLEN = 63;

	/// <summary>LM 2.0 UNC computer name length</summary>
	public const int LM20_UNCLEN = (LM20_CNLEN + 2);

	/// <summary>LM 2.0 Maximum user name length</summary>
	public const int LM20_UNLEN = 20;

	/// <summary/>
	public const uint MAX_PREFERRED_LENGTH = uint.MaxValue;

	/// <summary>Multipurpose comment length</summary>
	public const int MAXCOMMENTSZ = 256;

	/// <summary>NetBIOS net name (bytes)</summary>
	public const int NETBIOS_NAME_LEN = 16;

	/// <summary>Net name length (share name)</summary>
	public const int NNLEN = 80;

	/// <summary/>
	public const uint OPERATION_API_VERSION = 1;

	/// <summary>Max. path (not including drive name)</summary>
	public const int PATHLEN = 256;

	/// <summary>Maximum password length</summary>
	public const int PWLEN = 256;

	/// <summary>Queue name maximum length</summary>
	public const int QNLEN = NNLEN;

	/// <summary>Max remote name length</summary>
	public const int RMLEN = (UNCLEN + 1 + NNLEN);

	/// <summary/>
	public const int SESSION_CRYPT_KLEN = 21;

	/// <summary/>
	public const int SESSION_PWLEN = 24;

	/// <summary>Share password length (bytes)</summary>
	public const int SHPWLEN = 8;

	/// <summary>Service name length</summary>
	public const int SNLEN = 80;

	/// <summary>Service text length</summary>
	public const int STXTLEN = 256;

	/// <summary>UNC computer name length</summary>
	public const int UNCLEN = (CNLEN + 2);

	/// <summary>Maximum user name length</summary>
	public const int UNLEN = 256;

	/// <summary>
	/// <para>
	/// An application-defined callback function used with ReadEncryptedFileRaw. The system calls <c>ExportCallback</c> one or more
	/// times, each time with a block of the encrypted file's data, until it has received all of the file data. <c>ExportCallback</c>
	/// writes the encrypted file's data to another storage media, usually for purposes of backing up the file.
	/// </para>
	/// <para>
	/// The <c>PFE_EXPORT_FUNC</c> type defines a pointer to the callback function. <c>ExportCallback</c> is a placeholder for the
	/// application-defined function name.
	/// </para>
	/// </summary>
	/// <param name="pbData">
	/// A pointer to a block of the encrypted file's data to be backed up. This block of data is allocated by the system.
	/// </param>
	/// <param name="pvCallbackContext">
	/// A pointer to an application-defined and allocated context block. The application passes this pointer to ReadEncryptedFileRaw, and
	/// <c>ReadEncryptedFileRaw</c> passes this pointer to the callback function so that it can have access to application-specific data.
	/// This data can be a structure and can contain any data the application needs, such as the handle to the file that contains the
	/// backup copy of the encrypted file.
	/// </param>
	/// <param name="ulLength">The size of the data pointed to by the pbData parameter, in bytes.</param>
	/// <returns>
	/// <para>If the function succeeds, it must set the return value to <c>ERROR_SUCCESS</c>.</para>
	/// <para>
	/// If the function fails, set the return value to a nonzero error code defined in WinError.h. For example, if this function fails
	/// because an API that it calls fails, you can set the return value to the value returned by GetLastError for the failed API.
	/// </para>
	/// </returns>
	/// <remarks>
	/// You can use the application-defined context block for internal tracking of information such as the file handle and the current
	/// offset in the file.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winbase/nc-winbase-pfe_export_func PFE_EXPORT_FUNC PfeExportFunc; DWORD
	// PfeExportFunc( PBYTE pbData, PVOID pvCallbackContext, ULONG ulLength ) {...}
	[UnmanagedFunctionPointer(CallingConvention.Winapi)]
	[PInvokeData("winbase.h", MSDNShortId = "156948c9-d7b4-4491-bdb1-e1864a32caab")]
	public delegate Win32Error ExportCallback(IntPtr pbData, IntPtr pvCallbackContext, uint ulLength);

	/// <summary>
	/// <para>
	/// An application-defined callback function used with WriteEncryptedFileRaw. The system calls <c>ImportCallback</c> one or more
	/// times, each time to retrieve a portion of a backup file's data. <c>ImportCallback</c> reads the data from a backup file
	/// sequentially and restores the data, and the system continues calling it until it has read all of the backup file data.
	/// </para>
	/// <para>
	/// The <c>PFE_IMPORT_FUNC</c> type defines a pointer to this callback function. <c>ImportCallback</c> is a placeholder for the
	/// application-defined function name.
	/// </para>
	/// </summary>
	/// <param name="pbData">A pointer to a system-supplied buffer that will receive a block of data to be restored.</param>
	/// <param name="pvCallbackContext">
	/// A pointer to an application-defined and allocated context block. The application passes this pointer to WriteEncryptedFileRaw,
	/// and it passes this pointer to the callback function so that the callback function can have access to application-specific data.
	/// This data can be a structure and can contain any data the application needs, such as the handle to the file that contains the
	/// backup copy of the encrypted file.
	/// </param>
	/// <param name="ulLength">
	/// <para>
	/// On function entry, this parameter specifies the length of the buffer the system has supplied. The callback function must write no
	/// more than this many bytes to the buffer pointed to by the pbData parameter.
	/// </para>
	/// <para>On exit, the function must set this to the number of bytes of data written into the pbData.</para>
	/// </param>
	/// <returns>
	/// <para>
	/// If the function succeeds, it must set the return value to <c>ERROR_SUCCESS</c>, and set the value pointed to by the ulLength
	/// parameter to the number of bytes copied into pbData.
	/// </para>
	/// <para>When the end of the backup file is reached, set ulLength to zero to tell the system that the entire file has been processed.</para>
	/// <para>
	/// If the function fails, set the return value to a nonzero error code defined in WinError.h. For example, if this function fails
	/// because an API that it calls fails, you can set the return value to the value returned by GetLastError for the failed API.
	/// </para>
	/// </returns>
	/// <remarks>
	/// The system calls the <c>ImportCallback</c> function until the callback function indicates there is no more data to restore. To
	/// indicate that there is no more data to be restored, set *ulLength to 0 and use a return code of <c>ERROR_SUCCESS</c>. You can use
	/// the application-defined context block for internal tracking of information such as the file handle and the current offset in the file.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winbase/nc-winbase-pfe_import_func PFE_IMPORT_FUNC PfeImportFunc; DWORD
	// PfeImportFunc( PBYTE pbData, PVOID pvCallbackContext, PULONG ulLength ) {...}
	[UnmanagedFunctionPointer(CallingConvention.Winapi)]
	[PInvokeData("winbase.h", MSDNShortId = "4c951e44-15d8-43c8-bd3d-293a1ec9d444")]
	public delegate Win32Error ImportCallback(IntPtr pbData, IntPtr pvCallbackContext, ref uint ulLength);

	/// <summary>Flags used by <see cref="AccessCheckByTypeAndAuditAlarm"/>.</summary>
	[PInvokeData("winbase.h", MSDNShortId = "ea14fd55-e0e4-4bf2-b20e-5874783c16c3")]
	[Flags]
	public enum AccessCheckFlags
	{
		/// <summary>The function performs the access check without generating audit messages when the privilege is not enabled.</summary>
		AUDIT_ALLOW_NO_PRIVILEGE = 1
	}

	/// <summary>
	/// The <c>AUDIT_EVENT_TYPE</c> enumeration type defines values that indicate the type of object being audited. The
	/// AccessCheckByTypeAndAuditAlarm and AccessCheckByTypeResultListAndAuditAlarm functions use these values.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winnt/ne-winnt-_audit_event_type typedef enum _AUDIT_EVENT_TYPE {
	// AuditEventObjectAccess, AuditEventDirectoryServiceAccess } AUDIT_EVENT_TYPE, *PAUDIT_EVENT_TYPE;
	[PInvokeData("winnt.h", MSDNShortId = "7dc21840-6dcc-445b-a254-f8ca27008d63")]
	public enum AUDIT_EVENT_TYPE
	{
		/// <summary>
		/// Indicates an object that generates audit messages only if the system administrator has enabled auditing access to files and objects.
		/// </summary>
		AuditEventObjectAccess,

		/// <summary>
		/// Indicates a directory service object that generates audit messages only if the system administrator has enabled auditing
		/// access to directory service objects.
		/// </summary>
		AuditEventDirectoryServiceAccess,
	}

	/// <summary>The reported docking state of the computer.</summary>
	[PInvokeData("winbase.h", MSDNShortId = "b1c8eb4c-8c62-4e3e-a7d2-0888512b3d4c")]
	[Flags]
	public enum DOCKINFO : uint
	{
		/// <summary>The computer is undocked. This flag is always set for desktop systems that cannot be undocked.</summary>
		DOCKINFO_UNDOCKED = 0x1,

		/// <summary>The computer is docked.</summary>
		DOCKINFO_DOCKED = 0x2,

		/// <summary>
		/// If this flag is set, GetCurrentHwProfile retrieved the current docking state from information provided by the user in the
		/// Hardware Profiles page of the System control panel application.
		/// <para>If there is no such value or the value is set to 0, this flag is set.</para>
		/// </summary>
		DOCKINFO_USER_SUPPLIED = 0x4,

		/// <summary>
		/// The computer is docked, according to information provided by the user. This value is a combination of the
		/// DOCKINFO_USER_SUPPLIED and DOCKINFO_DOCKED flags.
		/// </summary>
		DOCKINFO_USER_DOCKED = DOCKINFO_UNDOCKED | DOCKINFO_USER_SUPPLIED,

		/// <summary>
		/// The computer is undocked, according to information provided by the user. This value is a combination of the
		/// DOCKINFO_USER_SUPPLIED and DOCKINFO_UNDOCKED flags.
		/// </summary>
		DOCKINFO_USER_UNDOCKED = DOCKINFO_DOCKED | DOCKINFO_USER_SUPPLIED,
	}

	/// <summary>The encryption status of the file.</summary>
	[PInvokeData("winbase.h", MSDNShortId = "96efe065-de62-4941-811d-610465cd7ef5")]
	public enum EncryptionStatus
	{
		/// <summary>
		/// The file can be encrypted.
		/// <para>
		/// Home, Home Premium, Starter, and ARM Editions of Windows: FILE_ENCRYPTABLE may be returned but EFS does not support
		/// encrypting files on these editions of Windows.
		/// </para>
		/// </summary>
		FILE_ENCRYPTABLE = 0,

		/// <summary>The file is encrypted.</summary>
		FILE_IS_ENCRYPTED = 1,

		/// <summary>The file is a read-only file.</summary>
		FILE_READ_ONLY = 8,

		/// <summary>The file is a root directory. Root directories cannot be encrypted.</summary>
		FILE_ROOT_DIR = 3,

		/// <summary>The file is a system file. System files cannot be encrypted.</summary>
		FILE_SYSTEM_ATTR = 2,

		/// <summary>The file is a system directory. System directories cannot be encrypted.</summary>
		FILE_SYSTEM_DIR = 4,

		/// <summary>The file system does not support file encryption.</summary>
		FILE_SYSTEM_NOT_SUPPORT = 6,

		/// <summary>The encryption status is unknown. The file may be encrypted.</summary>
		FILE_UNKNOWN = 5,

		/// <summary>Reserved for future use.</summary>
		FILE_USER_DISALLOWED = 7,

		/// <summary>Reserved for future use.</summary>
		FILE_DIR_DISALLOWED = 9,
	}

	/// <summary>Flags used by <see cref="IsTextUnicode(byte[], int, ref IS_TEXT_UNICODE)"/>.</summary>
	[Flags]
	public enum IS_TEXT_UNICODE : uint
	{
		/// <summary>The text is Unicode, and contains only zero-extended ASCII values/characters.</summary>
		IS_TEXT_UNICODE_ASCII16 = 0x0001,

		/// <summary>
		/// The text is probably Unicode, with the determination made by applying statistical analysis. Absolute certainty is not
		/// guaranteed. See the Remarks section.
		/// </summary>
		IS_TEXT_UNICODE_STATISTICS = 0x0002,

		/// <summary>Same as the preceding, except that the Unicode text is byte-reversed.</summary>
		IS_TEXT_UNICODE_REVERSE_ASCII16 = 0x0010,

		/// <summary>Same as the preceding, except that the text that is probably Unicode is byte-reversed.</summary>
		IS_TEXT_UNICODE_REVERSE_STATISTICS = 0x0020,

		/// <summary>
		/// The text contains Unicode representations of one or more of these nonprinting characters: RETURN, LINEFEED, SPACE, CJK_SPACE, TAB.
		/// </summary>
		IS_TEXT_UNICODE_CONTROLS = 0x0004,

		/// <summary>Same as the preceding, except that the Unicode characters are byte-reversed.</summary>
		IS_TEXT_UNICODE_REVERSE_CONTROLS = 0x0040,

		/// <summary>The text contains the Unicode byte-order mark (BOM) 0xFEFF as its first character.</summary>
		IS_TEXT_UNICODE_SIGNATURE = 0x0008,

		/// <summary>The text contains the Unicode byte-reversed byte-order mark (Reverse BOM) 0xFFFE as its first character.</summary>
		IS_TEXT_UNICODE_REVERSE_SIGNATURE = 0x0080,

		/// <summary>
		/// The text contains one of these Unicode-illegal characters: embedded Reverse BOM, UNICODE_NUL, CRLF (packed into one word), or 0xFFFF.
		/// </summary>
		IS_TEXT_UNICODE_ILLEGAL_CHARS = 0x0100,

		/// <summary>The number of characters in the string is odd. A string of odd length cannot (by definition) be Unicode text.</summary>
		IS_TEXT_UNICODE_ODD_LENGTH = 0x0200,

		/// <summary>Undocumented.</summary>
		IS_TEXT_UNICODE_DBCS_LEADBYTE = 0x0400,

		/// <summary>The text contains null bytes, which indicate non-ASCII text.</summary>
		IS_TEXT_UNICODE_NULL_BYTES = 0x1000,

		/// <summary>
		/// The value is a combination of IS_TEXT_UNICODE_ASCII16, IS_TEXT_UNICODE_STATISTICS, IS_TEXT_UNICODE_CONTROLS, IS_TEXT_UNICODE_SIGNATURE.
		/// </summary>
		IS_TEXT_UNICODE_UNICODE_MASK = 0x000F,

		/// <summary>
		/// The value is a combination of IS_TEXT_UNICODE_REVERSE_ASCII16, IS_TEXT_UNICODE_REVERSE_STATISTICS,
		/// IS_TEXT_UNICODE_REVERSE_CONTROLS, IS_TEXT_UNICODE_REVERSE_SIGNATURE.
		/// </summary>
		IS_TEXT_UNICODE_REVERSE_MASK = 0x00F0,

		/// <summary>
		/// The value is a combination of IS_TEXT_UNICODE_ILLEGAL_CHARS, IS_TEXT_UNICODE_ODD_LENGTH, and two currently unused bit flags.
		/// </summary>
		IS_TEXT_UNICODE_NOT_UNICODE_MASK = 0x0F00,

		/// <summary>The value is a combination of IS_TEXT_UNICODE_NULL_BYTES and three currently unused bit flags.</summary>
		IS_TEXT_UNICODE_NOT_ASCII_MASK = 0xF000,
	}

	/// <summary>The operation to perform when calling <c>OpenEncryptedFileRaw</c>.</summary>
	[PInvokeData("winbase.h", MSDNShortId = "f792f38d-783e-4f39-a9d8-0c378d508d97")]
	public enum OpenRawFlags
	{
		/// <summary>The file is being opened for import (restore).</summary>
		CREATE_FOR_IMPORT = 1,

		/// <summary>
		/// Import (restore) a directory containing encrypted files. This must be combined with one of the previous two flags to indicate
		/// the operation.
		/// </summary>
		CREATE_FOR_DIR = 2,

		/// <summary>Overwrite a hidden file on import.</summary>
		OVERWRITE_HIDDEN = 4,

		/// <summary/>
		EFSRPC_SECURE_ONLY = 8,

		/// <summary/>
		EFS_DROP_ALTERNATE_STREAMS = 0x10
	}

	/// <summary>The logon option.</summary>
	[PInvokeData("winbase.h", MSDNShortId = "dcfdcd5b-0269-4081-b1db-e272171c27a2")]
	[Flags]
	public enum ProcessLogonFlags : uint
	{
		/// <summary>
		/// Log on, then load the user profile in the HKEY_USERS registry key. The function returns after the profile is loaded. Loading
		/// the profile can be time-consuming, so it is best to use this value only if you must access the information in the
		/// HKEY_CURRENT_USER registry key.
		/// <para>
		/// Windows Server 2003: The profile is unloaded after the new process is terminated, whether or not it has created child processes.
		/// </para>
		/// <para>Windows XP: The profile is unloaded after the new process and all child processes it has created are terminated.</para>
		/// </summary>
		LOGON_WITH_PROFILE = 0x00000001,

		/// <summary>
		/// Log on, but use the specified credentials on the network only. The new process uses the same token as the caller, but the
		/// system creates a new logon session within LSA, and the process uses the specified credentials as the default credentials.
		/// <para>
		/// This value can be used to create a process that uses a different set of credentials locally than it does remotely. This is
		/// useful in inter-domain scenarios where there is no trust relationship.
		/// </para>
		/// <para>
		/// The system does not validate the specified credentials. Therefore, the process can start, but it may not have access to
		/// network resources.
		/// </para>
		/// </summary>
		LOGON_NETCREDENTIALS_ONLY = 0x00000002,

		/// <summary>The logon zero password buffer</summary>
		LOGON_ZERO_PASSWORD_BUFFER = 0x80000000
	}

	/// <summary>
	/// <para>
	/// The <c>AccessCheckAndAuditAlarm</c> function determines whether a security descriptor grants a specified set of access rights to
	/// the client being impersonated by the calling thread. If the security descriptor has a SACL with ACEs that apply to the client,
	/// the function generates any necessary audit messages in the security event log.
	/// </para>
	/// <para>Alarms are not currently supported.</para>
	/// </summary>
	/// <param name="SubsystemName">
	/// A pointer to a null-terminated string specifying the name of the subsystem calling the function. This string appears in any audit
	/// message that the function generates.
	/// </param>
	/// <param name="HandleId">
	/// A pointer to a unique value representing the client's handle to the object. If the access is denied, the system ignores this value.
	/// </param>
	/// <param name="ObjectTypeName">
	/// A pointer to a null-terminated string specifying the type of object being created or accessed. This string appears in any audit
	/// message that the function generates.
	/// </param>
	/// <param name="ObjectName">
	/// A pointer to a null-terminated string specifying the name of the object being created or accessed. This string appears in any
	/// audit message that the function generates.
	/// </param>
	/// <param name="SecurityDescriptor">A pointer to the SECURITY_DESCRIPTOR structure against which access is checked.</param>
	/// <param name="DesiredAccess">
	/// <para>
	/// Access mask that specifies the access rights to check. This mask must have been mapped by the MapGenericMask function to contain
	/// no generic access rights.
	/// </para>
	/// <para>
	/// If this parameter is MAXIMUM_ALLOWED, the function sets the GrantedAccess access mask to indicate the maximum access rights the
	/// security descriptor allows the client.
	/// </para>
	/// </param>
	/// <param name="GenericMapping">
	/// A pointer to the GENERIC_MAPPING structure associated with the object for which access is being checked.
	/// </param>
	/// <param name="ObjectCreation">
	/// Specifies a flag that determines whether the calling application will create a new object when access is granted. A value of
	/// <c>TRUE</c> indicates the application will create a new object. A value of <c>FALSE</c> indicates the application will open an
	/// existing object.
	/// </param>
	/// <param name="GrantedAccess">
	/// A pointer to an access mask that receives the granted access rights. If AccessStatus is set to <c>FALSE</c>, the function sets
	/// the access mask to zero. If the function fails, it does not set the access mask.
	/// </param>
	/// <param name="AccessStatus">
	/// A pointer to a variable that receives the results of the access check. If the security descriptor allows the requested access
	/// rights to the client, AccessStatus is set to <c>TRUE</c>. Otherwise, AccessStatus is set to <c>FALSE</c>.
	/// </param>
	/// <param name="pfGenerateOnClose">
	/// A pointer to a flag set by the audit-generation routine when the function returns. Pass this flag to the ObjectCloseAuditAlarm
	/// function when the object handle is closed.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>For more information, see the How AccessCheck Works overview.</para>
	/// <para>
	/// The <c>AccessCheckAndAuditAlarm</c> function requires the calling process to have the SE_AUDIT_NAME privilege enabled. The test
	/// for this privilege is performed against the primary token of the calling process, not the impersonation token of the thread.
	/// </para>
	/// <para>The <c>AccessCheckAndAuditAlarm</c> function fails if the calling thread is not impersonating a client.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/winbase/nf-winbase-accesscheckandauditalarma BOOL AccessCheckAndAuditAlarmA(
	// LPCSTR SubsystemName, LPVOID HandleId, StrPtrAnsi ObjectTypeName, StrPtrAnsi ObjectName, PSECURITY_DESCRIPTOR SecurityDescriptor, DWORD
	// DesiredAccess, PGENERIC_MAPPING GenericMapping, BOOL ObjectCreation, LPDWORD GrantedAccess, LPBOOL AccessStatus, LPBOOL
	// pfGenerateOnClose );
	[DllImport(Lib.AdvApi32, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("winbase.h", MSDNShortId = "c2d144f4-9eeb-4723-9d28-97cfd1a07274")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool AccessCheckAndAuditAlarm(string SubsystemName, IntPtr HandleId, string ObjectTypeName, [Optional] string? ObjectName,
		PSECURITY_DESCRIPTOR SecurityDescriptor, ACCESS_MASK DesiredAccess, in GENERIC_MAPPING GenericMapping, [MarshalAs(UnmanagedType.Bool)] bool ObjectCreation,
		out ACCESS_MASK GrantedAccess, [MarshalAs(UnmanagedType.Bool)] out bool AccessStatus, [MarshalAs(UnmanagedType.Bool)] out bool pfGenerateOnClose);

	/// <summary>
	/// <para>
	/// The <c>AccessCheckByTypeAndAuditAlarm</c> function determines whether a security descriptor grants a specified set of access
	/// rights to the client being impersonated by the calling thread. The function can check the client's access to a hierarchy of
	/// objects, such as an object, its property sets, and properties. The function grants or denies access to the hierarchy as a whole.
	/// If the security descriptor has a system access control list (SACL) with access control entries (ACEs) that apply to the client,
	/// the function generates any necessary audit messages in the security event log.
	/// </para>
	/// <para>Alarms are not currently supported.</para>
	/// </summary>
	/// <param name="SubsystemName">
	/// A pointer to a null-terminated string that specifies the name of the subsystem calling the function. This string appears in any
	/// audit message that the function generates.
	/// </param>
	/// <param name="HandleId">
	/// A pointer to a unique value that represents the client's handle to the object. If the access is denied, the system ignores this value.
	/// </param>
	/// <param name="ObjectTypeName">
	/// A pointer to a null-terminated string that specifies the type of object being created or accessed. This string appears in any
	/// audit message that the function generates.
	/// </param>
	/// <param name="ObjectName">
	/// A pointer to a null-terminated string that specifies the name of the object being created or accessed. This string appears in any
	/// audit message that the function generates.
	/// </param>
	/// <param name="SecurityDescriptor">A pointer to a SECURITY_DESCRIPTOR structure against which access is checked.</param>
	/// <param name="PrincipalSelfSid">
	/// <para>
	/// A pointer to a security identifier (SID). If the security descriptor is associated with an object that represents a principal
	/// (for example, a user object), the PrincipalSelfSid parameter should be the SID of the object. When evaluating access, this SID
	/// logically replaces the SID in any ACE containing the well-known PRINCIPAL_SELF SID (S-1-5-10). For information about well-known
	/// SIDs, see Well-known SIDs.
	/// </para>
	/// <para>If the protected object does not represent a principal, set this parameter to <c>NULL</c>.</para>
	/// </param>
	/// <param name="DesiredAccess">
	/// <para>
	/// An access mask that specifies the access rights to check. This mask must have been mapped by the MapGenericMask function to
	/// contain no generic access rights.
	/// </para>
	/// <para>
	/// If this parameter is MAXIMUM_ALLOWED, the function sets the GrantedAccess access mask to indicate the maximum access rights the
	/// security descriptor allows the client.
	/// </para>
	/// </param>
	/// <param name="AuditType">
	/// The type of audit to be generated. This can be one of the values from the AUDIT_EVENT_TYPE enumeration type.
	/// </param>
	/// <param name="Flags">
	/// A flag that controls the function's behavior if the calling process does not have the SE_AUDIT_NAME privilege enabled. If the
	/// AUDIT_ALLOW_NO_PRIVILEGE flag is set, the function performs the access check without generating audit messages when the privilege
	/// is not enabled. If this parameter is zero, the function fails if the privilege is not enabled.
	/// </param>
	/// <param name="ObjectTypeList">
	/// <para>
	/// A pointer to an array of OBJECT_TYPE_LIST structures that identify the hierarchy of object types for which to check access. Each
	/// element in the array specifies a GUID that identifies the object type and a value that indicates the level of the object type in
	/// the hierarchy of object types. The array should not have two elements with the same GUID.
	/// </para>
	/// <para>
	/// The array must have at least one element. The first element in the array must be at level zero and identify the object itself.
	/// The array can have only one level zero element. The second element is a subobject, such as a property set, at level 1. Following
	/// each level 1 entry are subordinate entries for the level 2 through 4 subobjects. Thus, the levels for the elements in the array
	/// might be {0, 1, 2, 2, 1, 2, 3}. If the object type list is out of order, <c>AccessCheckByTypeAndAuditAlarm</c> fails and
	/// GetLastError returns ERROR_INVALID_PARAMETER.
	/// </para>
	/// </param>
	/// <param name="ObjectTypeListLength">The number of elements in the ObjectTypeList array.</param>
	/// <param name="GenericMapping">
	/// A pointer to the GENERIC_MAPPING structure associated with the object for which access is being checked.
	/// </param>
	/// <param name="ObjectCreation">
	/// A flag that determines whether the calling application will create a new object when access is granted. A value of <c>TRUE</c>
	/// indicates the application will create a new object. A value of <c>FALSE</c> indicates the application will open an existing object.
	/// </param>
	/// <param name="GrantedAccess">
	/// A pointer to an access mask that receives the granted access rights. If AccessStatus is set to <c>FALSE</c>, the function sets
	/// the access mask to zero. If the function fails, it does not set the access mask.
	/// </param>
	/// <param name="AccessStatus">
	/// A pointer to a variable that receives the results of the access check. If the security descriptor allows the requested access
	/// rights to the client, AccessStatus is set to <c>TRUE</c>. Otherwise, AccessStatus is set to <c>FALSE</c> and you can call
	/// GetLastError to get extended error information.
	/// </param>
	/// <param name="pfGenerateOnClose">
	/// A pointer to a flag set by the audit-generation routine when the function returns. Pass this flag to the ObjectCloseAuditAlarm
	/// function when the object handle is closed.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the function returns nonzero.</para>
	/// <para>If the function fails, it returns zero. To get extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>For more information, see the How AccessCheck Works overview.</para>
	/// <para>
	/// If the PrincipalSelfSid and ObjectTypeList parameters are <c>NULL</c>, the AuditType parameter is AuditEventObjectAccess, and the
	/// Flags parameter is zero, <c>AccessCheckByTypeAndAuditAlarm</c> performs in the same way as the AccessCheckAndAuditAlarm function.
	/// </para>
	/// <para>
	/// The ObjectTypeList array does not necessarily represent the entire defined object. Rather, it represents that subset of the
	/// object for which to check access. For instance, to check access to two properties in a property set, specify an object type list
	/// with four elements: the object itself at level zero, the property set at level 1, and the two properties at level 2.
	/// </para>
	/// <para>
	/// The <c>AccessCheckByTypeAndAuditAlarm</c> function evaluates ACEs that apply to the object itself and object-specific ACEs for
	/// the object types listed in the ObjectTypeList array. The function ignores object-specific ACEs for object types not listed in the
	/// ObjectTypeList array. Thus, the results returned in the AccessStatus parameter indicate the access allowed to the subset of the
	/// object defined by the ObjectTypeList parameter, not to the entire object.
	/// </para>
	/// <para>
	/// For more information about how a hierarchy of ACEs controls access to an object and its subobjects, see ACEs to Control Access to
	/// an Object's Properties.
	/// </para>
	/// <para>
	/// To generate audit messages in the security event log, the calling process must have the SE_AUDIT_NAME privilege enabled. The
	/// system checks for this privilege in the primary token of the calling process, not the impersonation token of the thread. If the
	/// Flags parameter includes the AUDIT_ALLOW_NO_PRIVILEGE flag, the function performs the access check without generating audit
	/// messages when the privilege is not enabled.
	/// </para>
	/// <para>The <c>AccessCheckByTypeAndAuditAlarm</c> function fails if the calling thread is not impersonating a client.</para>
	/// <para>If the security descriptor does not contain owner and group SIDs, <c>AccessCheckByTypeAndAuditAlarm</c> fails with ERROR_INVALID_SECURITY_DESCR.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winbase/nf-winbase-accesscheckbytypeandauditalarma BOOL
	// AccessCheckByTypeAndAuditAlarmA( LPCSTR SubsystemName, LPVOID HandleId, LPCSTR ObjectTypeName, LPCSTR ObjectName,
	// PSECURITY_DESCRIPTOR SecurityDescriptor, PSID PrincipalSelfSid, DWORD DesiredAccess, AUDIT_EVENT_TYPE AuditType, DWORD Flags,
	// POBJECT_TYPE_LIST ObjectTypeList, DWORD ObjectTypeListLength, PGENERIC_MAPPING GenericMapping, BOOL ObjectCreation, LPDWORD
	// GrantedAccess, LPBOOL AccessStatus, LPBOOL pfGenerateOnClose );
	[DllImport(Lib.AdvApi32, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("winbase.h", MSDNShortId = "ea14fd55-e0e4-4bf2-b20e-5874783c16c3")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool AccessCheckByTypeAndAuditAlarm(string SubsystemName, [In] IntPtr HandleId, string ObjectTypeName, [Optional] string? ObjectName,
		[In] PSECURITY_DESCRIPTOR SecurityDescriptor, [In, Optional] PSID PrincipalSelfSid, ACCESS_MASK DesiredAccess, AUDIT_EVENT_TYPE AuditType,
		AccessCheckFlags Flags, [In, Out, MarshalAs(UnmanagedType.LPArray)] OBJECT_TYPE_LIST[] ObjectTypeList, uint ObjectTypeListLength,
		in GENERIC_MAPPING GenericMapping, [MarshalAs(UnmanagedType.Bool)] bool ObjectCreation, out ACCESS_MASK GrantedAccess,
		[MarshalAs(UnmanagedType.Bool)] out bool AccessStatus, [MarshalAs(UnmanagedType.Bool)] out bool pfGenerateOnClose);

	/// <summary>
	/// The <c>AccessCheckByTypeResultListAndAuditAlarm</c> function determines whether a security descriptor grants a specified set of
	/// access rights to the client being impersonated by the calling thread. The function can check access to a hierarchy of objects,
	/// such as an object, its property sets, and properties. The function reports the access rights granted or denied to each object
	/// type in the hierarchy. If the security descriptor has a system access control list (SACL) with access control entries (ACEs) that
	/// apply to the client, the function generates any necessary audit messages in the security event log. Alarms are not currently supported.
	/// </summary>
	/// <param name="SubsystemName">
	/// A pointer to a null-terminated string that specifies the name of the subsystem calling the function. This string appears in any
	/// audit message that the function generates.
	/// </param>
	/// <param name="HandleId">
	/// A pointer to a unique value that represents the client's handle to the object. If the access is denied, the system ignores this value.
	/// </param>
	/// <param name="ObjectTypeName">
	/// A pointer to a null-terminated string that specifies the type of object being created or accessed. This string appears in any
	/// audit message that the function generates.
	/// </param>
	/// <param name="ObjectName">
	/// A pointer to a null-terminated string that specifies the name of the object being created or accessed. This string appears in any
	/// audit message that the function generates.
	/// </param>
	/// <param name="SecurityDescriptor">A pointer to a SECURITY_DESCRIPTOR structure against which access is checked.</param>
	/// <param name="PrincipalSelfSid">
	/// <para>
	/// A pointer to a security identifier (SID). If the security descriptor is associated with an object that represents a principal
	/// (for example, a user object), the PrincipalSelfSid parameter should be the SID of the object. When evaluating access, this SID
	/// logically replaces the SID in any ACE that contains the well-known PRINCIPAL_SELF SID (S-1-5-10). For information about
	/// well-known SIDs, see Well-known SIDs.
	/// </para>
	/// <para>Set this parameter to <c>NULL</c> if the protected object does not represent a principal.</para>
	/// </param>
	/// <param name="DesiredAccess">
	/// <para>
	/// An access mask that specifies the access rights to check. This mask must have been mapped by the MapGenericMask function so that
	/// it contains no generic access rights.
	/// </para>
	/// <para>
	/// If this parameter is MAXIMUM_ALLOWED, the function sets the access mask in GrantedAccess to indicate the maximum access rights
	/// the security descriptor allows the client.
	/// </para>
	/// </param>
	/// <param name="AuditType">
	/// The type of audit to be generated. This can be one of the values from the AUDIT_EVENT_TYPE enumeration type.
	/// </param>
	/// <param name="Flags">
	/// A flag that controls the function's behavior if the calling process does not have the SE_AUDIT_NAME privilege enabled. If the
	/// AUDIT_ALLOW_NO_PRIVILEGE flag is set, the function performs the access check without generating audit messages when the privilege
	/// is not enabled. If this parameter is zero, the function fails if the privilege is not enabled.
	/// </param>
	/// <param name="ObjectTypeList">
	/// <para>
	/// A pointer to an array of OBJECT_TYPE_LIST structures that identify the hierarchy of object types for which to check access. Each
	/// element in the array specifies a GUID that identifies the object type and a value that indicates the level of the object type in
	/// the hierarchy of object types. The array should not have two elements with the same GUID.
	/// </para>
	/// <para>
	/// The array must have at least one element. The first element in the array must be at level zero and identify the object itself.
	/// The array can have only one level zero element. The second element is a subobject, such as a property set, at level 1. Following
	/// each level 1 entry are subordinate entries for the level 2 through 4 subobjects. Thus, the levels for the elements in the array
	/// might be {0, 1, 2, 2, 1, 2, 3}. If the object type list is out of order, <c>AccessCheckByTypeResultListAndAuditAlarm</c> fails,
	/// and GetLastError returns ERROR_INVALID_PARAMETER.
	/// </para>
	/// </param>
	/// <param name="ObjectTypeListLength">The number of elements in the ObjectTypeList array.</param>
	/// <param name="GenericMapping">
	/// A pointer to the GENERIC_MAPPING structure associated with the object for which access is being checked.
	/// </param>
	/// <param name="ObjectCreation">
	/// A flag that determines whether the calling application will create a new object when access is granted. A value of <c>TRUE</c>
	/// indicates the application will create a new object. A value of <c>FALSE</c> indicates the application will open an existing object.
	/// </param>
	/// <param name="GrantedAccess">
	/// A pointer to an array of access masks. The function sets each access mask to indicate the access rights granted to the
	/// corresponding element in the object type list. If the function fails, it does not set the access masks.
	/// </param>
	/// <param name="AccessStatusList">
	/// A pointer to an array of status codes for the corresponding elements in the object type list. The function sets an element to
	/// zero to indicate success or to a nonzero value to indicate the specific error during the access check. If the function fails, it
	/// does not set any of the elements in the array.
	/// </param>
	/// <param name="pfGenerateOnClose">
	/// A pointer to a flag set by the audit-generation routine when the function returns. Pass this flag to the ObjectCloseAuditAlarm
	/// function when the object handle is closed.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the function returns nonzero.</para>
	/// <para>If the function fails, it returns zero. To get extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>For more information, see the How AccessCheck Works overview.</para>
	/// <para>
	/// The <c>AccessCheckByTypeResultListAndAuditAlarm</c> function is a combination of the AccessCheckByTypeResultList and
	/// AccessCheckAndAuditAlarm functions.
	/// </para>
	/// <para>
	/// The ObjectTypeList array does not necessarily represent the entire defined object. Rather, it represents that subset of the
	/// object for which to check access. For instance, to check access to two properties in a property set, specify an object type list
	/// with four elements: the object itself at level zero, the property set at level 1, and the two properties at level 2.
	/// </para>
	/// <para>
	/// The <c>AccessCheckByTypeResultListAndAuditAlarm</c> function evaluates ACEs that apply to the object itself and object-specific
	/// ACEs for the object types listed in the ObjectTypeList array. The function ignores object-specific ACEs for object types not
	/// listed in the ObjectTypeList array.
	/// </para>
	/// <para>
	/// For more information about how a hierarchy of ACEs controls access to an object and its subobjects, see ACEs to Control Access to
	/// an Object's Properties.
	/// </para>
	/// <para>
	/// To generate audit messages in the security event log, the calling process must have the SE_AUDIT_NAME privilege enabled. The
	/// system checks for this privilege in the primary token of the calling process, not the impersonation token of the thread. If the
	/// Flags parameter includes the AUDIT_ALLOW_NO_PRIVILEGE flag, the function performs the access check without generating audit
	/// messages when the privilege is not enabled.
	/// </para>
	/// <para>The <c>AccessCheckByTypeResultListAndAuditAlarm</c> function fails if the calling thread is not impersonating a client.</para>
	/// <para>
	/// If the security descriptor does not contain owner and group SIDs, <c>AccessCheckByTypeResultListAndAuditAlarm</c> fails with ERROR_INVALID_SECURITY_DESCR.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/winbase/nf-winbase-accesscheckbytyperesultlistandauditalarma BOOL
	// AccessCheckByTypeResultListAndAuditAlarmA( LPCSTR SubsystemName, LPVOID HandleId, LPCSTR ObjectTypeName, LPCSTR ObjectName,
	// PSECURITY_DESCRIPTOR SecurityDescriptor, PSID PrincipalSelfSid, DWORD DesiredAccess, AUDIT_EVENT_TYPE AuditType, DWORD Flags,
	// POBJECT_TYPE_LIST ObjectTypeList, DWORD ObjectTypeListLength, PGENERIC_MAPPING GenericMapping, BOOL ObjectCreation, LPDWORD
	// GrantedAccess, LPDWORD AccessStatusList, LPBOOL pfGenerateOnClose );
	[DllImport(Lib.AdvApi32, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("winbase.h", MSDNShortId = "4b53a15a-5a6b-40c7-acf8-26b1f4bca4ae")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool AccessCheckByTypeResultListAndAuditAlarm(string SubsystemName, IntPtr HandleId, string ObjectTypeName, [Optional] string? ObjectName,
		PSECURITY_DESCRIPTOR SecurityDescriptor, [Optional] PSID PrincipalSelfSid, ACCESS_MASK DesiredAccess, AUDIT_EVENT_TYPE AuditType, AccessCheckFlags Flags,
		[In, Out, MarshalAs(UnmanagedType.LPArray)] OBJECT_TYPE_LIST[] ObjectTypeList, uint ObjectTypeListLength, in GENERIC_MAPPING GenericMapping,
		[MarshalAs(UnmanagedType.Bool)] bool ObjectCreation, [Out] uint[] GrantedAccess, [Out] uint[] AccessStatusList,
		[MarshalAs(UnmanagedType.Bool)] out bool pfGenerateOnClose);

	/// <summary>
	/// <para>
	/// The <c>AccessCheckByTypeResultListAndAuditAlarmByHandle</c> function determines whether a security descriptor grants a specified
	/// set of access rights to the client that the calling thread is impersonating. The difference between this function and
	/// AccessCheckByTypeResultListAndAuditAlarm is that this function allows the calling thread to perform the access check before
	/// impersonating the client.
	/// </para>
	/// <para>
	/// The function can check access to a hierarchy of objects, such as an object, its property sets, and properties. The function
	/// reports the access rights granted or denied to each object type in the hierarchy. If the security descriptor has a system access
	/// control list (SACL) with access control entries (ACEs) that apply to the client, the function generates any necessary audit
	/// messages in the security event log. Alarms are not currently supported.
	/// </para>
	/// </summary>
	/// <param name="SubsystemName">
	/// A pointer to a null-terminated string that specifies the name of the subsystem calling the function. This string appears in any
	/// audit message that the function generates.
	/// </param>
	/// <param name="HandleId">
	/// A pointer to a unique value that represents the client's handle to the object. If the access is denied, the system ignores this value.
	/// </param>
	/// <param name="ClientToken">
	/// A handle to a token object that represents the client that requested the operation. This handle must be obtained through a
	/// communication session layer, such as a local named pipe, to prevent possible security policy violations. The caller must have
	/// TOKEN_QUERY access for the specified token.
	/// </param>
	/// <param name="ObjectTypeName">
	/// A pointer to a null-terminated string that specifies the type of object being created or accessed. This string appears in any
	/// audit message that the function generates.
	/// </param>
	/// <param name="ObjectName">
	/// A pointer to a null-terminated string that specifies the name of the object being created or accessed. This string appears in any
	/// audit message that the function generates.
	/// </param>
	/// <param name="SecurityDescriptor">A pointer to a SECURITY_DESCRIPTOR structure against which access is checked.</param>
	/// <param name="PrincipalSelfSid">
	/// <para>
	/// A pointer to a SID. If the security descriptor is associated with an object that represents a principal (for example, a user
	/// object), the PrincipalSelfSid parameter should be the SID of the object. When evaluating access, this SID logically replaces the
	/// SID in any ACE containing the well-known PRINCIPAL_SELF SID (S-1-5-10). For information about well-known SIDs, see Well-known SIDs.
	/// </para>
	/// <para>Set this parameter to <c>NULL</c> if the protected object does not represent a principal.</para>
	/// </param>
	/// <param name="DesiredAccess">
	/// <para>
	/// An access mask that specifies the access rights to check. This mask must have been mapped by the MapGenericMask function so that
	/// it contains no generic access rights.
	/// </para>
	/// <para>
	/// If this parameter is MAXIMUM_ALLOWED, the function sets the access mask in GrantedAccess to indicate the maximum access rights
	/// the security descriptor allows the client.
	/// </para>
	/// </param>
	/// <param name="AuditType">
	/// The type of audit to be generated. This can be one of the values from the AUDIT_EVENT_TYPE enumeration type.
	/// </param>
	/// <param name="Flags">
	/// A flag that controls the function's behavior if the calling process does not have the SE_AUDIT_NAME privilege enabled. If the
	/// AUDIT_ALLOW_NO_PRIVILEGE flag is set, the function performs the access check without generating audit messages when the privilege
	/// is not enabled. If this parameter is zero, the function fails if the privilege is not enabled.
	/// </param>
	/// <param name="ObjectTypeList">
	/// <para>
	/// A pointer to an array of OBJECT_TYPE_LIST structures that identify the hierarchy of object types for which to check access. Each
	/// element in the array specifies a GUID that identifies the object type and a value that indicates the level of the object type in
	/// the hierarchy of object types. The array should not have two elements with the same GUID.
	/// </para>
	/// <para>
	/// The array must have at least one element. The first element in the array must be at level zero and identify the object itself.
	/// The array can have only one level zero element. The second element is a subobject, such as a property set, at level 1. Following
	/// each level 1 entry are subordinate entries for the level 2 through 4 subobjects. Thus, the levels for the elements in the array
	/// might be {0, 1, 2, 2, 1, 2, 3}. If the object type list is out of order, <c>AccessCheckByTypeResultListAndAuditAlarmByHandle</c>
	/// fails, and GetLastError returns ERROR_INVALID_PARAMETER.
	/// </para>
	/// </param>
	/// <param name="ObjectTypeListLength">The number of elements in the ObjectTypeList array.</param>
	/// <param name="GenericMapping">
	/// A pointer to the GENERIC_MAPPING structure associated with the object for which access is being checked.
	/// </param>
	/// <param name="ObjectCreation">
	/// A flag that determines whether the calling application will create a new object when access is granted. A value of <c>TRUE</c>
	/// indicates the application will create a new object. A value of <c>FALSE</c> indicates the application will open an existing object.
	/// </param>
	/// <param name="GrantedAccess">
	/// A pointer to an array of access masks. The function sets each access mask to indicate the access rights granted to the
	/// corresponding element in the object type list. If the function fails, it does not set the access masks.
	/// </param>
	/// <param name="AccessStatusList">
	/// A pointer to an array of status codes for the corresponding elements in the object type list. The function sets an element to
	/// zero to indicate success or to a nonzero value to indicate the specific error during the access check. If the function fails, it
	/// does not set any of the elements in the array.
	/// </param>
	/// <param name="pfGenerateOnClose">
	/// A pointer to a flag set by the audit-generation routine when the function returns. Pass this flag to the ObjectCloseAuditAlarm
	/// function when the object handle is closed.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the function returns nonzero.</para>
	/// <para>If the function fails, it returns zero. To get extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>For more information, see the How AccessCheck Works overview.</para>
	/// <para>
	/// Like AccessCheckByTypeResultListAndAuditAlarm, the <c>AccessCheckByTypeResultListAndAuditAlarmByHandle</c> function is a
	/// combination of the AccessCheckByTypeResultList and AccessCheckAndAuditAlarm functions. However,
	/// <c>AccessCheckByTypeResultListAndAuditAlarmByHandle</c> also requires a client token handle to provide security information on
	/// the client.
	/// </para>
	/// <para>
	/// The ObjectTypeList array does not necessarily represent the entire defined object. Rather, it represents that subset of the
	/// object for which to check access. For instance, to check access to two properties in a property set, specify an object type list
	/// with four elements: the object itself at level zero, the property set at level 1, and the two properties at level 2.
	/// </para>
	/// <para>
	/// The <c>AccessCheckByTypeResultListAndAuditAlarmByHandle</c> function evaluates ACEs that apply to the object itself and
	/// object-specific ACEs for the object types listed in the ObjectTypeList array. The function ignores object-specific ACEs for
	/// object types not listed in the ObjectTypeList array.
	/// </para>
	/// <para>
	/// For more information about how a hierarchy of ACEs controls access to an object and its subobjects, see ACEs to Control Access to
	/// an Object's Properties.
	/// </para>
	/// <para>
	/// To generate audit messages in the security event log, the calling process must have the SE_AUDIT_NAME privilege enabled. The
	/// system checks for this privilege in the primary token of the calling process, not the impersonation token of the thread. If the
	/// Flags parameter includes the AUDIT_ALLOW_NO_PRIVILEGE flag, the function performs the access check without generating audit
	/// messages when the privilege is not enabled.
	/// </para>
	/// <para>
	/// The <c>AccessCheckByTypeResultListAndAuditAlarmByHandle</c> function fails if the calling thread is not impersonating a client.
	/// </para>
	/// <para>
	/// If the security descriptor does not contain owner and group SIDs, <c>AccessCheckByTypeResultListAndAuditAlarmByHandle</c> fails
	/// with ERROR_INVALID_SECURITY_DESCR.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winbase/nf-winbase-accesscheckbytyperesultlistandauditalarmbyhandlea BOOL
	// AccessCheckByTypeResultListAndAuditAlarmByHandleA( LPCSTR SubsystemName, LPVOID HandleId, HANDLE ClientToken, LPCSTR
	// ObjectTypeName, LPCSTR ObjectName, PSECURITY_DESCRIPTOR SecurityDescriptor, PSID PrincipalSelfSid, DWORD DesiredAccess,
	// AUDIT_EVENT_TYPE AuditType, DWORD Flags, POBJECT_TYPE_LIST ObjectTypeList, DWORD ObjectTypeListLength, PGENERIC_MAPPING
	// GenericMapping, BOOL ObjectCreation, LPDWORD GrantedAccess, LPDWORD AccessStatusList, LPBOOL pfGenerateOnClose );
	[DllImport(Lib.AdvApi32, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("winbase.h", MSDNShortId = "7d3ddce4-40a2-483d-8cff-48d89313b383")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool AccessCheckByTypeResultListAndAuditAlarmByHandle(string SubsystemName, [In] IntPtr HandleId, [In] HTOKEN ClientToken, string ObjectTypeName,
		[Optional] string? ObjectName, [In] PSECURITY_DESCRIPTOR SecurityDescriptor, [Optional] PSID PrincipalSelfSid,
		ACCESS_MASK DesiredAccess, AUDIT_EVENT_TYPE AuditType, AccessCheckFlags Flags,
		[In, Out, MarshalAs(UnmanagedType.LPArray)] OBJECT_TYPE_LIST[] ObjectTypeList, uint ObjectTypeListLength,
		in GENERIC_MAPPING GenericMapping, [MarshalAs(UnmanagedType.Bool)] bool ObjectCreation,
		[In, Out, MarshalAs(UnmanagedType.LPArray)] uint[] GrantedAccess,
		[In, Out, MarshalAs(UnmanagedType.LPArray)] uint[] AccessStatusList,
		[MarshalAs(UnmanagedType.Bool)] out bool pfGenerateOnClose);

	/// <summary>
	/// The <c>AddConditionalAce</c> function adds a conditional access control entry (ACE) to the specified access control list (ACL). A
	/// conditional ACE specifies a logical condition that is evaluated during access checks.
	/// </summary>
	/// <param name="pAcl">
	/// <para>A pointer to an ACL. This function adds an ACE to this ACL.</para>
	/// <para>The value of this parameter cannot be <c>NULL</c>.</para>
	/// </param>
	/// <param name="dwAceRevision">
	/// Specifies the revision level of the ACL being modified. This value can be ACL_REVISION or ACL_REVISION_DS. Use ACL_REVISION_DS if
	/// the ACL contains object-specific ACEs.
	/// </param>
	/// <param name="AceFlags">
	/// A set of bit flags that control ACE inheritance. The function sets these flags in the <c>AceFlags</c> member of the ACE_HEADER
	/// structure of the new ACE. This parameter can be a combination of the following values.
	/// </param>
	/// <param name="AceType">
	/// <para>The type of the ACE.</para>
	/// <para>This can be one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>ACCESS_ALLOWED_CALLBACK_ACE_TYPE 0x9</term>
	/// <term>Access-allowed callback ACE that uses the ACCESS_ALLOWED_CALLBACK_ACE structure.</term>
	/// </item>
	/// <item>
	/// <term>ACCESS_DENIED_CALLBACK_ACE_TYPE 0xA</term>
	/// <term>Access-denied callback ACE that uses the ACCESS_DENIED_CALLBACK_ACE structure.</term>
	/// </item>
	/// <item>
	/// <term>SYSTEM_AUDIT_CALLBACK_ACE_TYPE 0xD</term>
	/// <term>System audit callback ACE that uses the SYSTEM_AUDIT_CALLBACK_ACE structure.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="AccessMask">Specifies the mask of access rights to be granted to the specified SID.</param>
	/// <param name="pSid">A pointer to the SID that represents a user, group, or logon account being granted access.</param>
	/// <param name="ConditionStr">A string that specifies the conditional statement to be evaluated for the ACE.</param>
	/// <param name="ReturnLength">
	/// The size, in bytes, of the ACL. If the buffer specified by the pACL parameter is not of sufficient size, the value of this
	/// parameter is the required size.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, it returns <c>TRUE</c>.</para>
	/// <para>
	/// If the function fails, it returns <c>FALSE</c>. For extended error information, call GetLastError. The following are possible
	/// error values.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_INSUFFICIENT_BUFFER</term>
	/// <term>The new ACE does not fit into the pAcl buffer.</term>
	/// </item>
	/// </list>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winbase/nf-winbase-addconditionalace BOOL AddConditionalAce( PACL pAcl, DWORD
	// dwAceRevision, DWORD AceFlags, UCHAR AceType, DWORD AccessMask, PSID pSid, PWCHAR ConditionStr, DWORD *ReturnLength );
	[DllImport(Lib.AdvApi32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("winbase.h", MSDNShortId = "89f038be-d15c-4c0b-8145-ba531bdf87ce")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool AddConditionalAce([In, Out] PACL pAcl, uint dwAceRevision, AceFlags AceFlags, AceType AceType, ACCESS_MASK AccessMask, PSID pSid, [MarshalAs(UnmanagedType.LPWStr)] string ConditionStr, out uint ReturnLength);

	/// <summary>
	/// Closes an encrypted file after a backup or restore operation, and frees associated system resources. This is one of a group of
	/// Encrypted File System (EFS) functions that is intended to implement backup and restore functionality, while maintaining files in
	/// their encrypted state.
	/// </summary>
	/// <param name="pvContext">
	/// A pointer to a system-defined context block. The OpenEncryptedFileRaw function returns the context block.
	/// </param>
	/// <returns>This function does not return a value.</returns>
	/// <remarks>
	/// <para>
	/// The <c>CloseEncryptedFileRaw</c> function frees allocated system resources such as the system-defined context block and closes
	/// the file.
	/// </para>
	/// <para>The BackupRead and BackupWrite functions handle backup and restore of unencrypted files.</para>
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
	/// <para>Note that SMB 3.0 does not support EFS on shares with continuous availability capability.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winbase/nf-winbase-closeencryptedfileraw void CloseEncryptedFileRaw( PVOID
	// pvContext );
	[DllImport(Lib.AdvApi32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("winbase.h", MSDNShortId = "54bf7114-0ebb-4d9c-bc67-2ac351dbe55d")]
	public static extern void CloseEncryptedFileRaw(EncryptedFileContext pvContext);

	/// <summary>
	/// <para>
	/// Creates a new process and its primary thread. Then the new process runs the specified executable file in the security context of
	/// the specified credentials (user, domain, and password). It can optionally load the user profile for a specified user.
	/// </para>
	/// <para>
	/// This function is similar to the CreateProcessAsUser and CreateProcessWithTokenW functions, except that the caller does not need
	/// to call the LogonUser function to authenticate the user and get a token.
	/// </para>
	/// </summary>
	/// <param name="lpUsername">
	/// <para>
	/// The name of the user. This is the name of the user account to log on to. If you use the UPN format, user@DNS_domain_name, the
	/// lpDomain parameter must be NULL.
	/// </para>
	/// <para>
	/// The user account must have the Log On Locally permission on the local computer. This permission is granted to all users on
	/// workstations and servers, but only to administrators on domain controllers.
	/// </para>
	/// </param>
	/// <param name="lpDomain">
	/// The name of the domain or server whose account database contains the lpUsername account. If this parameter is NULL, the user name
	/// must be specified in UPN format.
	/// </param>
	/// <param name="lpPassword">The clear-text password for the lpUsername account.</param>
	/// <param name="dwLogonFlags">The logon option. This parameter can be 0 (zero) or one of the following values.</param>
	/// <param name="lpApplicationName">
	/// <para>
	/// The name of the module to be executed. This module can be a Windows-based application. It can be some other type of module (for
	/// example, MS-DOS or OS/2) if the appropriate subsystem is available on the local computer.
	/// </para>
	/// <para>
	/// The string can specify the full path and file name of the module to execute or it can specify a partial name. If it is a partial
	/// name, the function uses the current drive and current directory to complete the specification. The function does not use the
	/// search path. This parameter must include the file name extension; no default extension is assumed.
	/// </para>
	/// <para>
	/// The lpApplicationName parameter can be NULL, and the module name must be the first white space–delimited token in the
	/// lpCommandLine string. If you are using a long file name that contains a space, use quoted strings to indicate where the file name
	/// ends and the arguments begin; otherwise, the file name is ambiguous.
	/// </para>
	/// <para>For example, the following string can be interpreted in different ways:</para>
	/// <para>"c:\program files\sub dir\program name"</para>
	/// <para>The system tries to interpret the possibilities in the following order:</para>
	/// <list type="number">
	/// <item>
	/// <term><c>c:\program.exe</c> files\sub dir\program name</term>
	/// </item>
	/// <item>
	/// <term><c>c:\program files\sub.exe</c> dir\program name</term>
	/// </item>
	/// <item>
	/// <term><c>c:\program files\sub dir\program.exe</c> name</term>
	/// </item>
	/// <item>
	/// <term><c>c:\program files\sub dir\program name.exe</c></term>
	/// </item>
	/// </list>
	/// <para>
	/// If the executable module is a 16-bit application, lpApplicationName should be NULL, and the string pointed to by lpCommandLine
	/// should specify the executable module and its arguments.
	/// </para>
	/// </param>
	/// <param name="lpCommandLine">
	/// <para>
	/// The command line to be executed. The maximum length of this string is 1024 characters. If lpApplicationName is <c>NULL</c>, the
	/// module name portion of lpCommandLine is limited to <c>MAX_PATH</c> characters.
	/// </para>
	/// <para>
	/// The function can modify the contents of this string. Therefore, this parameter cannot be a pointer to read-only memory (such as a
	/// <c>const</c> variable or a literal string). If this parameter is a constant string, the function may cause an access violation.
	/// </para>
	/// <para>
	/// The lpCommandLine parameter can be <c>NULL</c>, and the function uses the string pointed to by lpApplicationName as the command line.
	/// </para>
	/// <para>
	/// If both lpApplicationName and lpCommandLine are non- <c>NULL</c>, *lpApplicationName specifies the module to execute, and
	/// *lpCommandLine specifies the command line. The new process can use GetCommandLine to retrieve the entire command line. Console
	/// processes written in C can use the argc and argv arguments to parse the command line. Because argv[0] is the module name, C
	/// programmers typically repeat the module name as the first token in the command line.
	/// </para>
	/// <para>
	/// If lpApplicationName is <c>NULL</c>, the first white space–delimited token of the command line specifies the module name. If you
	/// are using a long file name that contains a space, use quoted strings to indicate where the file name ends and the arguments begin
	/// (see the explanation for the lpApplicationName parameter). If the file name does not contain an extension, .exe is appended.
	/// Therefore, if the file name extension is .com, this parameter must include the .com extension. If the file name ends in a period
	/// with no extension, or if the file name contains a path, .exe is not appended. If the file name does not contain a directory path,
	/// the system searches for the executable file in the following sequence:
	/// </para>
	/// <list type="number">
	/// <item>
	/// <term>The directory from which the application loaded.</term>
	/// </item>
	/// <item>
	/// <term>The current directory for the parent process.</term>
	/// </item>
	/// <item>
	/// <term>The 32-bit Windows system directory. Use the GetSystemDirectory function to get the path of this directory.</term>
	/// </item>
	/// <item>
	/// <term>The 16-bit Windows system directory. There is no function that obtains the path of this directory, but it is searched.</term>
	/// </item>
	/// <item>
	/// <term>The Windows directory. Use the GetWindowsDirectory function to get the path of this directory.</term>
	/// </item>
	/// <item>
	/// <term>
	/// The directories that are listed in the PATH environment variable. Note that this function does not search the per-application
	/// path specified by the <c>App Paths</c> registry key. To include this per-application path in the search sequence, use the
	/// ShellExecute function.
	/// </term>
	/// </item>
	/// </list>
	/// <para>
	/// The system adds a null character to the command line string to separate the file name from the arguments. This divides the
	/// original string into two strings for internal processing.
	/// </para>
	/// </param>
	/// <param name="dwCreationFlags">
	/// <para>
	/// The flags that control how the process is created. The <c>CREATE_DEFAULT_ERROR_MODE</c>, <c>CREATE_NEW_CONSOLE</c>, and
	/// <c>CREATE_NEW_PROCESS_GROUP</c> flags are enabled by default— even if you do not set the flag, the system functions as if it were
	/// set. You can specify additional flags as noted.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>CREATE_DEFAULT_ERROR_MODE 0x04000000</term>
	/// <term>
	/// The new process does not inherit the error mode of the calling process. Instead, CreateProcessWithLogonW gives the new process
	/// the current default error mode. An application sets the current default error mode by calling SetErrorMode. This flag is enabled
	/// by default.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CREATE_NEW_CONSOLE 0x00000010</term>
	/// <term>
	/// The new process has a new console, instead of inheriting the parent's console. This flag cannot be used with the DETACHED_PROCESS
	/// flag. This flag is enabled by default.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CREATE_NEW_PROCESS_GROUP 0x00000200</term>
	/// <term>
	/// The new process is the root process of a new process group. The process group includes all processes that are descendants of this
	/// root process. The process identifier of the new process group is the same as the process identifier, which is returned in the
	/// lpProcessInfo parameter. Process groups are used by the GenerateConsoleCtrlEvent function to enable sending a CTRL+C or
	/// CTRL+BREAK signal to a group of console processes. This flag is enabled by default.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CREATE_SEPARATE_WOW_VDM 0x00000800</term>
	/// <term>
	/// This flag is only valid starting a 16-bit Windows-based application. If set, the new process runs in a private Virtual DOS
	/// Machine (VDM). By default, all 16-bit Windows-based applications run in a single, shared VDM. The advantage of running separately
	/// is that a crash only terminates the single VDM; any other programs running in distinct VDMs continue to function normally. Also,
	/// 16-bit Windows-based applications that run in separate VDMs have separate input queues, which means that if one application stops
	/// responding momentarily, applications in separate VDMs continue to receive input.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CREATE_SUSPENDED 0x00000004</term>
	/// <term>
	/// The primary thread of the new process is created in a suspended state, and does not run until the ResumeThread function is called.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CREATE_UNICODE_ENVIRONMENT 0x00000400</term>
	/// <term>
	/// Indicates the format of the lpEnvironment parameter. If this flag is set, the environment block pointed to by lpEnvironment uses
	/// Unicode characters. Otherwise, the environment block uses ANSI characters.
	/// </term>
	/// </item>
	/// </list>
	/// <para>
	/// This parameter also controls the new process's priority class, which is used to determine the scheduling priorities of the
	/// process's threads. For a list of values, see GetPriorityClass. If none of the priority class flags is specified, the priority
	/// class defaults to <c>NORMAL_PRIORITY_CLASS</c> unless the priority class of the creating process is <c>IDLE_PRIORITY_CLASS</c> or
	/// <c>BELOW_NORMAL_PRIORITY_CLASS</c>. In this case, the child process receives the default priority class of the calling process.
	/// </para>
	/// </param>
	/// <param name="lpEnvironment">
	/// <para>
	/// A pointer to an environment block for the new process. If this parameter is <c>NULL</c>, the new process uses an environment
	/// created from the profile of the user specified by lpUsername.
	/// </para>
	/// <para>An environment block consists of a null-terminated block of null-terminated strings. Each string is in the following form:</para>
	/// <para>name=value</para>
	/// <para>Because the equal sign (=) is used as a separator, it must not be used in the name of an environment variable.</para>
	/// <para>
	/// An environment block can contain Unicode or ANSI characters. If the environment block pointed to by lpEnvironment contains
	/// Unicode characters, ensure that dwCreationFlags includes <c>CREATE_UNICODE_ENVIRONMENT</c>. If this parameter is NULL and the
	/// environment block of the parent process contains Unicode characters, you must also ensure that dwCreationFlags includes <c>CREATE_UNICODE_ENVIRONMENT</c>.
	/// </para>
	/// <para>
	/// An ANSI environment block is terminated by two 0 (zero) bytes: one for the last string and one more to terminate the block. A
	/// Unicode environment block is terminated by four zero bytes: two for the last string and two more to terminate the block.
	/// </para>
	/// <para>To retrieve a copy of the environment block for a specific user, use the CreateEnvironmentBlock function.</para>
	/// </param>
	/// <param name="lpCurrentDirectory">
	/// <para>The full path to the current directory for the process. The string can also specify a UNC path.</para>
	/// <para>
	/// If this parameter is <c>NULL</c>, the new process has the same current drive and directory as the calling process. This feature
	/// is provided primarily for shells that need to start an application, and specify its initial drive and working directory.
	/// </para>
	/// </param>
	/// <param name="lpStartupInfo">
	/// <para>A pointer to a STARTUPINFO structure.</para>
	/// <para>
	/// The application must add permission for the specified user account to the specified window station and desktop, even for WinSta0\Default.
	/// </para>
	/// <para>
	/// If the <c>lpDesktop</c> member is <c>NULL</c> or an empty string, the new process inherits the desktop and window station of its
	/// parent process. The application must add permission for the specified user account to the inherited window station and desktop.
	/// </para>
	/// <para>
	/// <c>Windows XP:</c><c>CreateProcessWithLogonW</c> adds permission for the specified user account to the inherited window station
	/// and desktop.
	/// </para>
	/// <para>Handles in STARTUPINFO must be closed with CloseHandle when they are no longer needed.</para>
	/// <para>
	/// <c>Important</c> If the <c>dwFlags</c> member of the STARTUPINFO structure specifies <c>STARTF_USESTDHANDLES</c>, the standard
	/// handle fields are copied unchanged to the child process without validation. The caller is responsible for ensuring that these
	/// fields contain valid handle values. Incorrect values can cause the child process to misbehave or crash. Use the Application
	/// Verifier runtime verification tool to detect invalid handles.
	/// </para>
	/// </param>
	/// <param name="lpProcessInformation">
	/// <para>
	/// A pointer to a PROCESS_INFORMATION structure that receives identification information for the new process, including a handle to
	/// the process.
	/// </para>
	/// <para>Handles in PROCESS_INFORMATION must be closed with the CloseHandle function when they are not needed.</para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is 0 (zero). To get extended error information, call GetLastError.</para>
	/// <para>
	/// Note that the function returns before the process has finished initialization. If a required DLL cannot be located or fails to
	/// initialize, the process is terminated. To get the termination status of a process, call GetExitCodeProcess.
	/// </para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// By default, <c>CreateProcessWithLogonW</c> does not load the specified user profile into the <c>HKEY_USERS</c> registry key. This
	/// means that access to information in the <c>HKEY_CURRENT_USER</c> registry key may not produce results that are consistent with a
	/// normal interactive logon. It is your responsibility to load the user registry hive into <c>HKEY_USERS</c> before calling
	/// <c>CreateProcessWithLogonW</c>, by using <c>LOGON_WITH_PROFILE</c>, or by calling the LoadUserProfile function.
	/// </para>
	/// <para>
	/// If the lpEnvironment parameter is NULL, the new process uses an environment block created from the profile of the user specified
	/// by lpUserName. If the HOMEDRIVE and HOMEPATH variables are not set, <c>CreateProcessWithLogonW</c> modifies the environment block
	/// to use the drive and path of the user's working directory.
	/// </para>
	/// <para>
	/// When created, the new process and thread handles receive full access rights ( <c>PROCESS_ALL_ACCESS</c> and
	/// <c>THREAD_ALL_ACCESS</c>). For either handle, if a security descriptor is not provided, the handle can be used in any function
	/// that requires an object handle of that type. When a security descriptor is provided, an access check is performed on all
	/// subsequent uses of the handle before access is granted. If access is denied, the requesting process cannot use the handle to gain
	/// access to the process or thread.
	/// </para>
	/// <para>To retrieve a security token, pass the process handle in the PROCESS_INFORMATION structure to the OpenProcessToken function.</para>
	/// <para>
	/// The process is assigned a process identifier. The identifier is valid until the process terminates. It can be used to identify
	/// the process, or it can be specified in the OpenProcess function to open a handle to the process. The initial thread in the
	/// process is also assigned a thread identifier. It can be specified in the OpenThread function to open a handle to the thread. The
	/// identifier is valid until the thread terminates and can be used to uniquely identify the thread within the system. These
	/// identifiers are returned in PROCESS_INFORMATION.
	/// </para>
	/// <para>
	/// The calling thread can use the WaitForInputIdle function to wait until the new process has completed its initialization and is
	/// waiting for user input with no input pending. This can be useful for synchronization between parent and child processes, because
	/// <c>CreateProcessWithLogonW</c> returns without waiting for the new process to finish its initialization. For example, the
	/// creating process would use <c>WaitForInputIdle</c> before trying to find a window that is associated with the new process.
	/// </para>
	/// <para>
	/// The preferred way to shut down a process is by using the ExitProcess function, because this function sends notification of
	/// approaching termination to all DLLs attached to the process. Other means of shutting down a process do not notify the attached
	/// DLLs. Note that when a thread calls <c>ExitProcess</c>, other threads of the process are terminated without an opportunity to
	/// execute any additional code (including the thread termination code of attached DLLs). For more information, see Terminating a Process.
	/// </para>
	/// <para>
	/// <c>CreateProcessWithLogonW</c> accesses the specified directory and executable image in the security context of the target user.
	/// If the executable image is on a network and a network drive letter is specified in the path, the network drive letter is not
	/// available to the target user, as network drive letters can be assigned for each logon. If a network drive letter is specified,
	/// this function fails. If the executable image is on a network, use the UNC path.
	/// </para>
	/// <para>
	/// There is a limit to the number of child processes that can be created by this function and run simultaneously. For example, on
	/// Windows XP, this limit is <c>MAXIMUM_WAIT_OBJECTS</c>*4. However, you may not be able to create this many processes due to
	/// system-wide quota limits.
	/// </para>
	/// <para>
	/// <c>Windows XP with SP2,Windows Server 2003, or later:</c> You cannot call <c>CreateProcessWithLogonW</c> from a process that is
	/// running under the "LocalSystem" account, because the function uses the logon SID in the caller token, and the token for the
	/// "LocalSystem" account does not contain this SID. As an alternative, use the CreateProcessAsUser and LogonUser functions.
	/// </para>
	/// <para>
	/// To compile an application that uses this function, define <c>_WIN32_WINNT</c> as 0x0500 or later. For more information, see Using
	/// the Windows Headers.
	/// </para>
	/// <para>Security Remarks</para>
	/// <para>
	/// The lpApplicationName parameter can be <c>NULL</c>, and the executable name must be the first white space–delimited string in
	/// lpCommandLine. If the executable or path name has a space in it, there is a risk that a different executable could be run because
	/// of the way the function parses spaces. Avoid the following example, because the function attempts to run "Program.exe", if it
	/// exists, instead of "MyApp.exe".
	/// </para>
	/// <para>
	/// If a malicious user creates an application called "Program.exe" on a system, any program that incorrectly calls
	/// <c>CreateProcessWithLogonW</c> using the Program Files directory runs the malicious user application instead of the intended application.
	/// </para>
	/// <para>
	/// To avoid this issue, do not pass <c>NULL</c> for lpApplicationName. If you pass <c>NULL</c> for lpApplicationName, use quotation
	/// marks around the executable path in lpCommandLine, as shown in the following example:
	/// </para>
	/// <para>Examples</para>
	/// <para>The following example demonstrates how to call this function.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winbase/nf-winbase-createprocesswithlogonw BOOL CreateProcessWithLogonW(
	// LPCWSTR lpUsername, LPCWSTR lpDomain, LPCWSTR lpPassword, DWORD dwLogonFlags, LPCWSTR lpApplicationName, StrPtrUni lpCommandLine,
	// DWORD dwCreationFlags, LPVOID lpEnvironment, LPCWSTR lpCurrentDirectory, LPSTARTUPINFOW lpStartupInfo, LPPROCESS_INFORMATION
	// lpProcessInformation );
	[PInvokeData("winbase.h", MSDNShortId = "dcfdcd5b-0269-4081-b1db-e272171c27a2")]
	public static bool CreateProcessWithLogonW(string lpUsername, [Optional] string? lpDomain, string lpPassword, ProcessLogonFlags dwLogonFlags,
		[Optional] string? lpApplicationName, [Optional] StringBuilder? lpCommandLine, CREATE_PROCESS dwCreationFlags,
		[Optional] string[]? lpEnvironment, [Optional] string? lpCurrentDirectory, in STARTUPINFO lpStartupInfo, [NotNullWhen(true)] out SafePROCESS_INFORMATION? lpProcessInformation)
	{
		var ret = CreateProcessWithLogonW(lpUsername, lpDomain, lpPassword, dwLogonFlags, lpApplicationName, lpCommandLine, dwCreationFlags, lpEnvironment, lpCurrentDirectory, lpStartupInfo, out PROCESS_INFORMATION pi);
		lpProcessInformation = ret ? new SafePROCESS_INFORMATION(pi) : null;
		return ret;
	}

	/// <summary>
	/// <para>
	/// Creates a new process and its primary thread. The new process runs in the security context of the specified token. It can
	/// optionally load the user profile for the specified user.
	/// </para>
	/// <para>
	/// The process that calls <c>CreateProcessWithTokenW</c> must have the SE_IMPERSONATE_NAME privilege. If this function fails with
	/// ERROR_PRIVILEGE_NOT_HELD (1314), use the CreateProcessAsUser or CreateProcessWithLogonW function instead. Typically, the process
	/// that calls <c>CreateProcessAsUser</c> must have the SE_INCREASE_QUOTA_NAME privilege and may require the
	/// SE_ASSIGNPRIMARYTOKEN_NAME privilege if the token is not assignable. <c>CreateProcessWithLogonW</c> requires no special
	/// privileges, but the specified user account must be allowed to log on interactively. Generally, it is best to use
	/// <c>CreateProcessWithLogonW</c> to create a process with alternate credentials.
	/// </para>
	/// </summary>
	/// <param name="hToken">
	/// <para>
	/// A handle to the primary token that represents a user. The handle must have the TOKEN_QUERY, TOKEN_DUPLICATE, and
	/// TOKEN_ASSIGN_PRIMARY access rights. For more information, see Access Rights for Access-Token Objects. The user represented by the
	/// token must have read and execute access to the application specified by the lpApplicationName or the lpCommandLine parameter.
	/// </para>
	/// <para>
	/// To get a primary token that represents the specified user, call the LogonUser function. Alternatively, you can call the
	/// DuplicateTokenEx function to convert an impersonation token into a primary token. This allows a server application that is
	/// impersonating a client to create a process that has the security context of the client.
	/// </para>
	/// <para>
	/// <c>Terminal Services:</c> The process is run in the session specified in the token. By default, this is the same session that
	/// called LogonUser. To change the session, use the SetTokenInformation function.
	/// </para>
	/// </param>
	/// <param name="dwLogonFlags">The logon option. This parameter can be zero or one of the following values.</param>
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
	/// The lpApplicationName parameter can be NULL. In that case, the module name must be the first white space–delimited token in the
	/// lpCommandLine string. If you are using a long file name that contains a space, use quoted strings to indicate where the file name
	/// ends and the arguments begin; otherwise, the file name is ambiguous. For example, consider the string "c:\program files\sub
	/// dir\program name". This string can be interpreted in a number of ways. The system tries to interpret the possibilities in the
	/// following order:
	/// </para>
	/// <para>
	/// <c>c:\program.exe</c><c>c:\program files\sub.exe</c><c>c:\program files\sub dir\program.exe</c><c>c:\program files\sub
	/// dir\program name.exe</c> If the executable module is a 16-bit application, lpApplicationName should be NULL, and the string
	/// pointed to by lpCommandLine should specify the executable module as well as its arguments.
	/// </para>
	/// </param>
	/// <param name="lpCommandLine">
	/// <para>The command line to be executed.</para>
	/// <para>
	/// The maximum length of this string is 1024 characters. If lpApplicationName is NULL, the module name portion of lpCommandLine is
	/// limited to MAX_PATH characters.
	/// </para>
	/// <para>
	/// The function can modify the contents of this string. Therefore, this parameter cannot be a pointer to read-only memory (such as a
	/// <c>const</c> variable or a literal string). If this parameter is a constant string, the function may cause an access violation.
	/// </para>
	/// <para>
	/// The lpCommandLine parameter can be NULL. In that case, the function uses the string pointed to by lpApplicationName as the
	/// command line.
	/// </para>
	/// <para>
	/// If both lpApplicationName and lpCommandLine are non-NULL, *lpApplicationName specifies the module to execute, and *lpCommandLine
	/// specifies the command line. The new process can use GetCommandLine to retrieve the entire command line. Console processes written
	/// in C can use the argc and argv arguments to parse the command line. Because argv[0] is the module name, C programmers generally
	/// repeat the module name as the first token in the command line.
	/// </para>
	/// <para>
	/// If lpApplicationName is NULL, the first white space–delimited token of the command line specifies the module name. If you are
	/// using a long file name that contains a space, use quoted strings to indicate where the file name ends and the arguments begin
	/// (see the explanation for the lpApplicationName parameter). If the file name does not contain an extension, .exe is appended.
	/// Therefore, if the file name extension is .com, this parameter must include the .com extension. If the file name ends in a period
	/// (.) with no extension, or if the file name contains a path, .exe is not appended. If the file name does not contain a directory
	/// path, the system searches for the executable file in the following sequence:
	/// </para>
	/// <list type="number">
	/// <item>
	/// <term>The directory from which the application loaded.</term>
	/// </item>
	/// <item>
	/// <term>The current directory for the parent process.</term>
	/// </item>
	/// <item>
	/// <term>The 32-bit Windows system directory. Use the GetSystemDirectory function to get the path of this directory.</term>
	/// </item>
	/// <item>
	/// <term>The 16-bit Windows system directory. There is no function that obtains the path of this directory, but it is searched.</term>
	/// </item>
	/// <item>
	/// <term>The Windows directory. Use the GetWindowsDirectory function to get the path of this directory.</term>
	/// </item>
	/// <item>
	/// <term>
	/// The directories that are listed in the PATH environment variable. Note that this function does not search the per-application
	/// path specified by the <c>App Paths</c> registry key. To include this per-application path in the search sequence, use the
	/// ShellExecute function.
	/// </term>
	/// </item>
	/// </list>
	/// <para>
	/// The system adds a null character to the command line string to separate the file name from the arguments. This divides the
	/// original string into two strings for internal processing.
	/// </para>
	/// </param>
	/// <param name="dwCreationFlags">
	/// <para>
	/// The flags that control how the process is created. The CREATE_DEFAULT_ERROR_MODE, CREATE_NEW_CONSOLE, and
	/// CREATE_NEW_PROCESS_GROUP flags are enabled by default. You can specify additional flags as noted.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>CREATE_DEFAULT_ERROR_MODE 0x04000000</term>
	/// <term>
	/// The new process does not inherit the error mode of the calling process. Instead, the new process gets the current default error
	/// mode. An application sets the current default error mode by calling SetErrorMode. This flag is enabled by default.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CREATE_NEW_CONSOLE 0x00000010</term>
	/// <term>
	/// The new process has a new console, instead of inheriting the parent's console. This flag cannot be used with the DETACHED_PROCESS
	/// flag. This flag is enabled by default.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CREATE_NEW_PROCESS_GROUP 0x00000200</term>
	/// <term>
	/// The new process is the root process of a new process group. The process group includes all processes that are descendants of this
	/// root process. The process identifier of the new process group is the same as the process identifier, which is returned in the
	/// lpProcessInfo parameter. Process groups are used by the GenerateConsoleCtrlEvent function to enable sending a CTRL+C or
	/// CTRL+BREAK signal to a group of console processes. This flag is enabled by default.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CREATE_SEPARATE_WOW_VDM 0x00000800</term>
	/// <term>
	/// This flag is only valid starting a 16-bit Windows-based application. If set, the new process runs in a private Virtual DOS
	/// Machine (VDM). By default, all 16-bit Windows-based applications run in a single, shared VDM. The advantage of running separately
	/// is that a crash only terminates the single VDM; any other programs running in distinct VDMs continue to function normally. Also,
	/// 16-bit Windows-based applications that run in separate VDMs have separate input queues. That means that if one application stops
	/// responding momentarily, applications in separate VDMs continue to receive input.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CREATE_SUSPENDED 0x00000004</term>
	/// <term>
	/// The primary thread of the new process is created in a suspended state, and does not run until the ResumeThread function is called.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CREATE_UNICODE_ENVIRONMENT 0x00000400</term>
	/// <term>
	/// Indicates the format of the lpEnvironment parameter. If this flag is set, the environment block pointed to by lpEnvironment uses
	/// Unicode characters. Otherwise, the environment block uses ANSI characters.
	/// </term>
	/// </item>
	/// <item>
	/// <term>EXTENDED_STARTUPINFO_PRESENT 0x00080000</term>
	/// <term>
	/// The process is created with extended startup information; the lpStartupInfo parameter specifies a STARTUPINFOEX structure.
	/// Windows Server 2003: This value is not supported.
	/// </term>
	/// </item>
	/// </list>
	/// <para>
	/// This parameter also controls the new process's priority class, which is used to determine the scheduling priorities of the
	/// process's threads. For a list of values, see GetPriorityClass. If none of the priority class flags is specified, the priority
	/// class defaults to NORMAL_PRIORITY_CLASS unless the priority class of the creating process is IDLE_PRIORITY_CLASS or
	/// BELOW_NORMAL_PRIORITY_CLASS. In this case, the child process receives the default priority class of the calling process.
	/// </para>
	/// </param>
	/// <param name="lpEnvironment">
	/// <para>
	/// A pointer to an environment block for the new process. If this parameter is NULL, the new process uses an environment created
	/// from the profile of the user specified by lpUsername.
	/// </para>
	/// <para>An environment block consists of a null-terminated block of null-terminated strings. Each string is in the following form:</para>
	/// <para>name=value</para>
	/// <para>Because the equal sign (=) is used as a separator, it must not be used in the name of an environment variable.</para>
	/// <para>
	/// An environment block can contain Unicode or ANSI characters. If the environment block pointed to by lpEnvironment contains
	/// Unicode characters, be sure that dwCreationFlags includes CREATE_UNICODE_ENVIRONMENT. If this parameter is NULL and the
	/// environment block of the parent process contains Unicode characters, you must also ensure that dwCreationFlags includes CREATE_UNICODE_ENVIRONMENT.
	/// </para>
	/// <para>
	/// An ANSI environment block is terminated by two zero bytes: one for the last string, one more to terminate the block. A Unicode
	/// environment block is terminated by four zero bytes: two for the last string and two more to terminate the block.
	/// </para>
	/// <para>To retrieve a copy of the environment block for a specific user, use the CreateEnvironmentBlock function.</para>
	/// </param>
	/// <param name="lpCurrentDirectory">
	/// <para>The full path to the current directory for the process. The string can also specify a UNC path.</para>
	/// <para>
	/// If this parameter is NULL, the new process will have the same current drive and directory as the calling process. (This feature
	/// is provided primarily for shells that need to start an application and specify its initial drive and working directory.)
	/// </para>
	/// </param>
	/// <param name="lpStartupInfo">
	/// <para>A pointer to a STARTUPINFO or STARTUPINFOEX structure.</para>
	/// <para>
	/// If the <c>lpDesktop</c> member is NULL or an empty string, the new process inherits the desktop and window station of its parent
	/// process. The function adds permission for the specified user account to the inherited window station and desktop. Otherwise, if
	/// this member specifies a desktop, it is the responsibility of the application to add permission for the specified user account to
	/// the specified window station and desktop, even for WinSta0\Default.
	/// </para>
	/// <para>Handles in STARTUPINFO or STARTUPINFOEX must be closed with CloseHandle when they are no longer needed.</para>
	/// <para>
	/// <c>Important</c> If the <c>dwFlags</c> member of the STARTUPINFO structure specifies <c>STARTF_USESTDHANDLES</c>, the standard
	/// handle fields are copied unchanged to the child process without validation. The caller is responsible for ensuring that these
	/// fields contain valid handle values. Incorrect values can cause the child process to misbehave or crash. Use the Application
	/// Verifier runtime verification tool to detect invalid handles.
	/// </para>
	/// </param>
	/// <param name="lpProcessInformation">
	/// <para>
	/// A pointer to a PROCESS_INFORMATION structure that receives identification information for the new process, including a handle to
	/// the process.
	/// </para>
	/// <para>Handles in PROCESS_INFORMATION must be closed with the CloseHandle function when they are no longer needed.</para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
	/// <para>
	/// Note that the function returns before the process has finished initialization. If a required DLL cannot be located or fails to
	/// initialize, the process is terminated. To get the termination status of a process, call GetExitCodeProcess.
	/// </para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// By default, <c>CreateProcessWithTokenW</c> does not load the specified user's profile into the <c>HKEY_USERS</c> registry key.
	/// This means that access to information in the <c>HKEY_CURRENT_USER</c> registry key may not produce results consistent with a
	/// normal interactive logon. It is your responsibility to load the user's registry hive into <c>HKEY_USERS</c> by either using
	/// LOGON_WITH_PROFILE, or by calling the LoadUserProfile function before calling this function.
	/// </para>
	/// <para>
	/// If the lpEnvironment parameter is NULL, the new process uses an environment block created from the profile of the user specified
	/// by lpUserName. If the HOMEDRIVE and HOMEPATH variables are not set, <c>CreateProcessWithTokenW</c> modifies the environment block
	/// to use the drive and path of the user's working directory.
	/// </para>
	/// <para>
	/// When created, the new process and thread handles receive full access rights (PROCESS_ALL_ACCESS and THREAD_ALL_ACCESS). For
	/// either handle, if a security descriptor is not provided, the handle can be used in any function that requires an object handle of
	/// that type. When a security descriptor is provided, an access check is performed on all subsequent uses of the handle before
	/// access is granted. If access is denied, the requesting process cannot use the handle to gain access to the process or thread.
	/// </para>
	/// <para>To retrieve a security token, pass the process handle in the PROCESS_INFORMATION structure to the OpenProcessToken function.</para>
	/// <para>
	/// The process is assigned a process identifier. The identifier is valid until the process terminates. It can be used to identify
	/// the process, or specified in the OpenProcess function to open a handle to the process. The initial thread in the process is also
	/// assigned a thread identifier. It can be specified in the OpenThread function to open a handle to the thread. The identifier is
	/// valid until the thread terminates and can be used to uniquely identify the thread within the system. These identifiers are
	/// returned in PROCESS_INFORMATION.
	/// </para>
	/// <para>
	/// The calling thread can use the WaitForInputIdle function to wait until the new process has finished its initialization and is
	/// waiting for user input with no input pending. This can be useful for synchronization between parent and child processes, because
	/// <c>CreateProcessWithTokenW</c> returns without waiting for the new process to finish its initialization. For example, the
	/// creating process would use <c>WaitForInputIdle</c> before trying to find a window associated with the new process.
	/// </para>
	/// <para>
	/// The preferred way to shut down a process is by using the ExitProcess function, because this function sends notification of
	/// approaching termination to all DLLs attached to the process. Other means of shutting down a process do not notify the attached
	/// DLLs. Note that when a thread calls <c>ExitProcess</c>, other threads of the process are terminated without an opportunity to
	/// execute any additional code (including the thread termination code of attached DLLs). For more information, see Terminating a Process.
	/// </para>
	/// <para>
	/// To compile an application that uses this function, define _WIN32_WINNT as 0x0500 or later. For more information, see Using the
	/// Windows Headers.
	/// </para>
	/// <para>Security Remarks</para>
	/// <para>
	/// The lpApplicationName parameter can be NULL, in which case the executable name must be the first white space–delimited string in
	/// lpCommandLine. If the executable or path name has a space in it, there is a risk that a different executable could be run because
	/// of the way the function parses spaces. The following example is dangerous because the function will attempt to run "Program.exe",
	/// if it exists, instead of "MyApp.exe".
	/// </para>
	/// <para>
	/// If a malicious user were to create an application called "Program.exe" on a system, any program that incorrectly calls
	/// <c>CreateProcessWithTokenW</c> using the Program Files directory will run this application instead of the intended application.
	/// </para>
	/// <para>
	/// To avoid this problem, do not pass NULL for lpApplicationName. If you do pass NULL for lpApplicationName, use quotation marks
	/// around the executable path in lpCommandLine, as shown in the example below.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winbase/nf-winbase-createprocesswithtokenw BOOL CreateProcessWithTokenW(
	// HANDLE hToken, DWORD dwLogonFlags, LPCWSTR lpApplicationName, StrPtrUni lpCommandLine, DWORD dwCreationFlags, LPVOID lpEnvironment,
	// LPCWSTR lpCurrentDirectory, LPSTARTUPINFOW lpStartupInfo, LPPROCESS_INFORMATION lpProcessInformation );
	[PInvokeData("winbase.h", MSDNShortId = "b329866a-0c0d-4cb3-838c-36aac17c87ed")]
	public static bool CreateProcessWithTokenW(HTOKEN hToken, ProcessLogonFlags dwLogonFlags, string lpApplicationName, [Optional] StringBuilder? lpCommandLine, CREATE_PROCESS dwCreationFlags,
		[Optional] string[]? lpEnvironment, [Optional] string? lpCurrentDirectory, in STARTUPINFO lpStartupInfo, out SafePROCESS_INFORMATION? lpProcessInformation)
	{
		var ret = CreateProcessWithTokenW(hToken, dwLogonFlags, lpApplicationName, lpCommandLine, dwCreationFlags, lpEnvironment, lpCurrentDirectory, lpStartupInfo, out PROCESS_INFORMATION pi);
		lpProcessInformation = ret ? new SafePROCESS_INFORMATION(pi) : null;
		return ret;
	}

	/// <summary>Decrypts an encrypted file or directory.</summary>
	/// <param name="lpFileName">
	/// <para>The name of the file or directory to be decrypted.</para>
	/// <para>
	/// The caller must have the <c>FILE_READ_DATA</c>, <c>FILE_WRITE_DATA</c>, <c>FILE_READ_ATTRIBUTES</c>,
	/// <c>FILE_WRITE_ATTRIBUTES</c>, and <c>SYNCHRONIZE</c> access rights. For more information, see File Security and Access Rights.
	/// </para>
	/// </param>
	/// <param name="dwReserved">Reserved; must be zero.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The <c>DecryptFile</c> function requires exclusive access to the file being decrypted, and will fail if another process is using
	/// the file. If the file is not encrypted, <c>DecryptFile</c> simply returns a nonzero value, which indicates success.
	/// </para>
	/// <para>
	/// If lpFileName specifies a read-only file, the function fails and GetLastError returns <c>ERROR_FILE_READ_ONLY</c>. If lpFileName
	/// specifies a directory that contains a read-only file, the functions succeeds but the directory is not decrypted.
	/// </para>
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
	// https://docs.microsoft.com/en-us/windows/desktop/api/winbase/nf-winbase-decryptfilea BOOL DecryptFileA( LPCSTR lpFileName, DWORD
	// dwReserved );
	[DllImport(Lib.AdvApi32, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("winbase.h", MSDNShortId = "6b8f0ed0-8825-4c84-bf58-3a89cda882b4")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool DecryptFile(string lpFileName, uint dwReserved = 0);

	/// <summary>
	/// Encrypts a file or directory. All data streams in a file are encrypted. All new files created in an encrypted directory are encrypted.
	/// </summary>
	/// <param name="lpFileName">
	/// <para>The name of the file or directory to be encrypted.</para>
	/// <para>
	/// The caller must have the <c>FILE_READ_DATA</c>, <c>FILE_WRITE_DATA</c>, <c>FILE_READ_ATTRIBUTES</c>,
	/// <c>FILE_WRITE_ATTRIBUTES</c>, and <c>SYNCHRONIZE</c> access rights. For more information, see File Security and Access Rights.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The <c>EncryptFile</c> function requires exclusive access to the file being encrypted, and will fail if another process is using
	/// the file.
	/// </para>
	/// <para>
	/// If the file is already encrypted, <c>EncryptFile</c> simply returns a nonzero value, which indicates success. If the file is
	/// compressed, <c>EncryptFile</c> will decompress the file before encrypting it.
	/// </para>
	/// <para>
	/// If lpFileName specifies a read-only file, the function fails and GetLastError returns <c>ERROR_FILE_READ_ONLY</c>. If lpFileName
	/// specifies a directory that contains a read-only file, the functions succeeds but the directory is not encrypted.
	/// </para>
	/// <para>To decrypt an encrypted file, use the DecryptFile function.</para>
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
	// https://docs.microsoft.com/en-us/windows/desktop/api/winbase/nf-winbase-encryptfilea BOOL EncryptFileA( LPCSTR lpFileName );
	[DllImport(Lib.AdvApi32, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("winbase.h", MSDNShortId = "7620e9fa-74d6-4b41-93db-4a562be63202")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool EncryptFile(string lpFileName);

	/// <summary>Retrieves the encryption status of the specified file.</summary>
	/// <param name="lpFileName">The name of the file.</param>
	/// <param name="lpStatus">
	/// A pointer to a variable that receives the encryption status of the file. This parameter can be one of the following values.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
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
	// https://docs.microsoft.com/en-us/windows/desktop/api/winbase/nf-winbase-fileencryptionstatusa BOOL FileEncryptionStatusA( LPCSTR
	// lpFileName, LPDWORD lpStatus );
	[DllImport(Lib.AdvApi32, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("winbase.h", MSDNShortId = "96efe065-de62-4941-811d-610465cd7ef5")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool FileEncryptionStatus(string lpFileName, out EncryptionStatus lpStatus);

	/// <summary>Retrieves information about the current hardware profile for the local computer.</summary>
	/// <param name="lpHwProfileInfo">
	/// A pointer to an HW_PROFILE_INFO structure that receives information about the current hardware profile.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is a nonzero value.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The <c>GetCurrentHwProfile</c> function retrieves the display name and globally unique identifier (GUID) string for the hardware
	/// profile. The function also retrieves the reported docking state for portable computers with docking stations.
	/// </para>
	/// <para>
	/// The system generates a GUID for each hardware profile and stores it as a string in the registry. You can use
	/// <c>GetCurrentHwProfile</c> to retrieve the GUID string to use as a registry subkey under your application's configuration
	/// settings key in <c>HKEY_CURRENT_USER</c>. This enables you to store each user's settings for each hardware profile. For example,
	/// the Colors control panel application could use the subkey to store each user's color preferences for different hardware profiles,
	/// such as profiles for the docked and undocked states. Applications that use this functionality can check the current hardware
	/// profile when they start up, and update their settings accordingly.
	/// </para>
	/// <para>
	/// Applications can also update their settings when a system device message, such as DBT_CONFIGCHANGED, indicates that the hardware
	/// profile has changed.
	/// </para>
	/// <para>
	/// To compile an application that uses this function, define the _WIN32_WINNT macro as 0x0400 or later. For more information, see
	/// Using the Windows Headers.
	/// </para>
	/// <para>Examples</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winbase/nf-winbase-getcurrenthwprofilea BOOL GetCurrentHwProfileA(
	// LPHW_PROFILE_INFOA lpHwProfileInfo );
	[DllImport(Lib.AdvApi32, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("winbase.h", MSDNShortId = "152067bb-3896-43ef-a882-12a159f92cc7")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool GetCurrentHwProfile(out HW_PROFILE_INFO lpHwProfileInfo);

	/// <summary>
	/// <para>
	/// The <c>GetFileSecurity</c> function obtains specified information about the security of a file or directory. The information
	/// obtained is constrained by the caller's access rights and privileges.
	/// </para>
	/// <para>
	/// The GetNamedSecurityInfo function provides functionality similar to <c>GetFileSecurity</c> for files as well as other types of objects.
	/// </para>
	/// </summary>
	/// <param name="lpFileName">
	/// A pointer to a null-terminated string that specifies the file or directory for which security information is retrieved.
	/// </param>
	/// <param name="RequestedInformation">A SECURITY_INFORMATION value that identifies the security information being requested.</param>
	/// <param name="pSecurityDescriptor">
	/// A pointer to a buffer that receives a copy of the security descriptor of the object specified by the lpFileName parameter. The
	/// calling process must have permission to view the specified aspects of the object's security status. The SECURITY_DESCRIPTOR
	/// structure is returned in self-relative security descriptor format.
	/// </param>
	/// <param name="nLength">Specifies the size, in bytes, of the buffer pointed to by the pSecurityDescriptor parameter.</param>
	/// <param name="lpnLengthNeeded">
	/// A pointer to the variable that receives the number of bytes necessary to store the complete security descriptor. If the returned
	/// number of bytes is less than or equal to nLength, the entire security descriptor is returned in the output buffer; otherwise,
	/// none of the descriptor is returned.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// To read the owner, group, or DACL from the security descriptor for the specified file or directory, the DACL for the file or
	/// directory must grant READ_CONTROL access to the caller, or the caller must be the owner of the file or directory.
	/// </para>
	/// <para>To read the SACL of a file or directory, the SE_SECURITY_NAME privilege must be enabled for the calling process.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winbase/nf-winbase-getfilesecuritya BOOL GetFileSecurityA( LPCSTR lpFileName,
	// SECURITY_INFORMATION RequestedInformation, PSECURITY_DESCRIPTOR pSecurityDescriptor, DWORD nLength, LPDWORD lpnLengthNeeded );
	[DllImport(Lib.AdvApi32, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("winbase.h", MSDNShortId = "4043b76b-76b9-4111-8a29-a808b2412be0")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool GetFileSecurity(string lpFileName, SECURITY_INFORMATION RequestedInformation, SafePSECURITY_DESCRIPTOR pSecurityDescriptor, uint nLength, out uint lpnLengthNeeded);

	/// <summary>
	/// <para>
	/// The <c>GetFileSecurity</c> function obtains specified information about the security of a file or directory. The information
	/// obtained is constrained by the caller's access rights and privileges.
	/// </para>
	/// <para>
	/// The GetNamedSecurityInfo function provides functionality similar to <c>GetFileSecurity</c> for files as well as other types of objects.
	/// </para>
	/// </summary>
	/// <param name="lpFileName">
	/// A pointer to a null-terminated string that specifies the file or directory for which security information is retrieved.
	/// </param>
	/// <param name="RequestedInformation">A SECURITY_INFORMATION value that identifies the security information being requested.</param>
	/// <returns>
	/// The security descriptor of the object specified by the lpFileName parameter. The calling process must have permission to view the
	/// specified aspects of the object's security status. The SECURITY_DESCRIPTOR structure is returned in self-relative security
	/// descriptor format.
	/// </returns>
	[PInvokeData("winbase.h", MSDNShortId = "4043b76b-76b9-4111-8a29-a808b2412be0")]
	public static SafePSECURITY_DESCRIPTOR GetFileSecurity(string lpFileName, SECURITY_INFORMATION RequestedInformation = SECURITY_INFORMATION.OWNER_SECURITY_INFORMATION | SECURITY_INFORMATION.GROUP_SECURITY_INFORMATION | SECURITY_INFORMATION.DACL_SECURITY_INFORMATION)
	{
		if (!GetFileSecurity(lpFileName, RequestedInformation, SafePSECURITY_DESCRIPTOR.Null, 0, out var sz) && sz == 0)
			Win32Error.ThrowLastError();
		var sd = new SafePSECURITY_DESCRIPTOR((int)sz);
		if (!GetFileSecurity(lpFileName, RequestedInformation, sd, sd.Size, out _))
			Win32Error.ThrowLastError();
		return sd;
	}

	/// <summary>
	/// <para>Retrieves the name of the user associated with the current thread.</para>
	/// <para>
	/// Use the <see cref="Secur32.GetUserNameEx"/> function to retrieve the user name in a specified format. Additional information is
	/// provided by the IADsADSystemInfo interface.
	/// </para>
	/// </summary>
	/// <param name="lpBuffer">
	/// A pointer to the buffer to receive the user's logon name. If this buffer is not large enough to contain the entire user name, the
	/// function fails. A buffer size of (UNLEN + 1) characters will hold the maximum length user name including the terminating null
	/// character. UNLEN is defined in Lmcons.h.
	/// </param>
	/// <param name="pcbBuffer">
	/// <para>
	/// On input, this variable specifies the size of the lpBuffer buffer, in <c>TCHARs</c>. On output, the variable receives the number of
	/// <c>TCHARs</c> copied to the buffer, including the terminating null character.
	/// </para>
	/// <para>
	/// If lpBuffer is too small, the function fails and GetLastError returns ERROR_INSUFFICIENT_BUFFER. This parameter receives the required
	/// buffer size, including the terminating null character.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>
	/// If the function succeeds, the return value is a nonzero value, and the variable pointed to by lpnSize contains the number of
	/// <c>TCHARs</c> copied to the buffer specified by lpBuffer, including the terminating null character.
	/// </para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// If the current thread is impersonating another client, the <c>GetUserName</c> function returns the user name of the client that the
	/// thread is impersonating.
	/// </para>
	/// <para>
	/// If <c>GetUserName</c> is called from a process that is running under the "NETWORK SERVICE" account, the string returned in lpBuffer
	/// may be different depending on the version of Windows. On Windows XP, the "NETWORK SERVICE" string is returned. On Windows Vista, the
	/// “&lt;HOSTNAME&gt;$” string is returned.
	/// </para>
	/// <para>Examples</para>
	/// <para>For an example, see Getting System Information.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winbase/nf-winbase-getusernamea BOOL GetUserNameA( StrPtrAnsi lpBuffer, LPDWORD
	// pcbBuffer );
	[DllImport(Lib.AdvApi32, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("winbase.h", MSDNShortId = "87adc46a-c069-4ee5-900a-03b646306e64")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool GetUserName(StringBuilder lpBuffer, ref uint pcbBuffer);

	/// <summary>The <c>ImpersonateNamedPipeClient</c> function impersonates a named-pipe client application.</summary>
	/// <param name="hNamedPipe">A handle to a named pipe.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The <c>ImpersonateNamedPipeClient</c> function allows the server end of a named pipe to impersonate the client end. When this
	/// function is called, the named-pipe file system changes the thread of the calling process to start impersonating the security
	/// context of the last message read from the pipe. Only the server end of the pipe can call this function.
	/// </para>
	/// <para>The server can call the RevertToSelf function when the impersonation is complete.</para>
	/// <para>
	/// <c>Important</c> If the <c>ImpersonateNamedPipeClient</c> function fails, the client is not impersonated, and all subsequent
	/// client requests are made in the security context of the process that called the function. If the calling process is running as a
	/// privileged account, it can perform actions that the client would not be allowed to perform. To avoid security risks, the calling
	/// process should always check the return value. If the return value indicates that the function call failed, no client requests
	/// should be executed.
	/// </para>
	/// <para>
	/// All impersonate functions, including <c>ImpersonateNamedPipeClient</c> allow the requested impersonation if one of the following
	/// is true:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>
	/// The requested impersonation level of the token is less than <c>SecurityImpersonation</c>, such as <c>SecurityIdentification</c>
	/// or <c>SecurityAnonymous</c>.
	/// </term>
	/// </item>
	/// <item>
	/// <term>The caller has the <c>SeImpersonatePrivilege</c> privilege.</term>
	/// </item>
	/// <item>
	/// <term>
	/// A process (or another process in the caller's logon session) created the token using explicit credentials through LogonUser or
	/// LsaLogonUser function.
	/// </term>
	/// </item>
	/// <item>
	/// <term>The authenticated identity is same as the caller.</term>
	/// </item>
	/// </list>
	/// <para><c>Windows XP with SP1 and earlier:</c> The <c>SeImpersonatePrivilege</c> privilege is not supported.</para>
	/// <para>Examples</para>
	/// <para>For an example that uses this function, see Verifying Client Access with ACLs.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/namedpipeapi/nf-namedpipeapi-impersonatenamedpipeclient BOOL
	// ImpersonateNamedPipeClient( HANDLE hNamedPipe );
	[DllImport(Lib.AdvApi32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("namedpipeapi.h", MSDNShortId = "63fc90ac-536a-4d9b-ba0d-19dc0cc09e6b")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool ImpersonateNamedPipeClient(HPIPE hNamedPipe);

	/// <summary>Determines if a buffer is likely to contain a form of Unicode text.</summary>
	/// <param name="lpv">Pointer to the input buffer to examine.</param>
	/// <param name="iSize">Size, in bytes, of the input buffer indicated by lpv.</param>
	/// <param name="lpiResult">
	/// <para>
	/// On input, pointer to the tests to apply to the input buffer text. On output, this parameter receives the results of the specified
	/// tests: 1 if the contents of the buffer pass a test, 0 for failure. Only flags that are set upon input to the function are
	/// significant upon output.
	/// </para>
	/// <para>
	/// If lpiResult is <c>NULL</c>, the function uses all available tests to determine if the data in the buffer is likely to be Unicode text.
	/// </para>
	/// <para>This parameter can be one or more of the following values. Values can be combined with binary "OR".</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>IS_TEXT_UNICODE_ASCII16</term>
	/// <term>The text is Unicode, and contains only zero-extended ASCII values/characters.</term>
	/// </item>
	/// <item>
	/// <term>IS_TEXT_UNICODE_REVERSE_ASCII16</term>
	/// <term>Same as the preceding, except that the Unicode text is byte-reversed.</term>
	/// </item>
	/// <item>
	/// <term>IS_TEXT_UNICODE_STATISTICS</term>
	/// <term>
	/// The text is probably Unicode, with the determination made by applying statistical analysis. Absolute certainty is not guaranteed.
	/// See the Remarks section.
	/// </term>
	/// </item>
	/// <item>
	/// <term>IS_TEXT_UNICODE_REVERSE_STATISTICS</term>
	/// <term>Same as the preceding, except that the text that is probably Unicode is byte-reversed.</term>
	/// </item>
	/// <item>
	/// <term>IS_TEXT_UNICODE_CONTROLS</term>
	/// <term>
	/// The text contains Unicode representations of one or more of these nonprinting characters: RETURN, LINEFEED, SPACE, CJK_SPACE, TAB.
	/// </term>
	/// </item>
	/// <item>
	/// <term>IS_TEXT_UNICODE_REVERSE_CONTROLS</term>
	/// <term>Same as the preceding, except that the Unicode characters are byte-reversed.</term>
	/// </item>
	/// <item>
	/// <term>IS_TEXT_UNICODE_BUFFER_TOO_SMALL</term>
	/// <term>There are too few characters in the buffer for meaningful analysis (fewer than two bytes).</term>
	/// </item>
	/// <item>
	/// <term>IS_TEXT_UNICODE_SIGNATURE</term>
	/// <term>The text contains the Unicode byte-order mark (BOM) 0xFEFF as its first character.</term>
	/// </item>
	/// <item>
	/// <term>IS_TEXT_UNICODE_REVERSE_SIGNATURE</term>
	/// <term>The text contains the Unicode byte-reversed byte-order mark (Reverse BOM) 0xFFFE as its first character.</term>
	/// </item>
	/// <item>
	/// <term>IS_TEXT_UNICODE_ILLEGAL_CHARS</term>
	/// <term>
	/// The text contains one of these Unicode-illegal characters: embedded Reverse BOM, UNICODE_NUL, CRLF (packed into one word), or 0xFFFF.
	/// </term>
	/// </item>
	/// <item>
	/// <term>IS_TEXT_UNICODE_ODD_LENGTH</term>
	/// <term>The number of characters in the string is odd. A string of odd length cannot (by definition) be Unicode text.</term>
	/// </item>
	/// <item>
	/// <term>IS_TEXT_UNICODE_NULL_BYTES</term>
	/// <term>The text contains null bytes, which indicate non-ASCII text.</term>
	/// </item>
	/// <item>
	/// <term>IS_TEXT_UNICODE_UNICODE_MASK</term>
	/// <term>The value is a combination of IS_TEXT_UNICODE_ASCII16, IS_TEXT_UNICODE_STATISTICS, IS_TEXT_UNICODE_CONTROLS, IS_TEXT_UNICODE_SIGNATURE.</term>
	/// </item>
	/// <item>
	/// <term>IS_TEXT_UNICODE_REVERSE_MASK</term>
	/// <term>
	/// The value is a combination of IS_TEXT_UNICODE_REVERSE_ASCII16, IS_TEXT_UNICODE_REVERSE_STATISTICS,
	/// IS_TEXT_UNICODE_REVERSE_CONTROLS, IS_TEXT_UNICODE_REVERSE_SIGNATURE.
	/// </term>
	/// </item>
	/// <item>
	/// <term>IS_TEXT_UNICODE_NOT_UNICODE_MASK</term>
	/// <term>
	/// The value is a combination of IS_TEXT_UNICODE_ILLEGAL_CHARS, IS_TEXT_UNICODE_ODD_LENGTH, and two currently unused bit flags.
	/// </term>
	/// </item>
	/// <item>
	/// <term>IS_TEXT_UNICODE_NOT_ASCII_MASK</term>
	/// <term>The value is a combination of IS_TEXT_UNICODE_NULL_BYTES and three currently unused bit flags.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <returns>
	/// Returns a nonzero value if the data in the buffer passes the specified tests. The function returns 0 if the data in the buffer
	/// does not pass the specified tests.
	/// </returns>
	/// <remarks>
	/// <para>
	/// This function uses various statistical and deterministic methods to make its determination, under the control of flags passed in
	/// the lpiResult parameter. When the function returns, the results of such tests are reported using the same parameter.
	/// </para>
	/// <para>
	/// The IS_TEXT_UNICODE_STATISTICS and IS_TEXT_UNICODE_REVERSE_STATISTICS tests use statistical analysis. These tests are not
	/// foolproof. The statistical tests assume certain amounts of variation between low and high bytes in a string, and some ASCII
	/// strings can slip through. For example, if lpv indicates the ASCII string 0x41, 0x0A, 0x0D, 0x1D (A\n\r^Z), the string passes the
	/// IS_TEXT_UNICODE_STATISTICS test, although failure would be preferable.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winbase/nf-winbase-istextunicode BOOL IsTextUnicode( const VOID *lpv, int
	// iSize, LPINT lpiResult );
	[DllImport(Lib.AdvApi32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("winbase.h", MSDNShortId = "47e05b5b-a16b-4957-bc86-ed3cef4968ee")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool IsTextUnicode(byte[] lpv, int iSize, ref IS_TEXT_UNICODE lpiResult);

	/// <summary>Determines if a buffer is likely to contain a form of Unicode text.</summary>
	/// <param name="lpv">Pointer to the input buffer to examine.</param>
	/// <param name="iSize">Size, in bytes, of the input buffer indicated by lpv.</param>
	/// <param name="lpiResult">
	/// <para>
	/// On input, pointer to the tests to apply to the input buffer text. On output, this parameter receives the results of the specified
	/// tests: 1 if the contents of the buffer pass a test, 0 for failure. Only flags that are set upon input to the function are
	/// significant upon output.
	/// </para>
	/// <para>
	/// If lpiResult is <c>NULL</c>, the function uses all available tests to determine if the data in the buffer is likely to be Unicode text.
	/// </para>
	/// <para>This parameter can be one or more of the following values. Values can be combined with binary "OR".</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>IS_TEXT_UNICODE_ASCII16</term>
	/// <term>The text is Unicode, and contains only zero-extended ASCII values/characters.</term>
	/// </item>
	/// <item>
	/// <term>IS_TEXT_UNICODE_REVERSE_ASCII16</term>
	/// <term>Same as the preceding, except that the Unicode text is byte-reversed.</term>
	/// </item>
	/// <item>
	/// <term>IS_TEXT_UNICODE_STATISTICS</term>
	/// <term>
	/// The text is probably Unicode, with the determination made by applying statistical analysis. Absolute certainty is not guaranteed.
	/// See the Remarks section.
	/// </term>
	/// </item>
	/// <item>
	/// <term>IS_TEXT_UNICODE_REVERSE_STATISTICS</term>
	/// <term>Same as the preceding, except that the text that is probably Unicode is byte-reversed.</term>
	/// </item>
	/// <item>
	/// <term>IS_TEXT_UNICODE_CONTROLS</term>
	/// <term>
	/// The text contains Unicode representations of one or more of these nonprinting characters: RETURN, LINEFEED, SPACE, CJK_SPACE, TAB.
	/// </term>
	/// </item>
	/// <item>
	/// <term>IS_TEXT_UNICODE_REVERSE_CONTROLS</term>
	/// <term>Same as the preceding, except that the Unicode characters are byte-reversed.</term>
	/// </item>
	/// <item>
	/// <term>IS_TEXT_UNICODE_BUFFER_TOO_SMALL</term>
	/// <term>There are too few characters in the buffer for meaningful analysis (fewer than two bytes).</term>
	/// </item>
	/// <item>
	/// <term>IS_TEXT_UNICODE_SIGNATURE</term>
	/// <term>The text contains the Unicode byte-order mark (BOM) 0xFEFF as its first character.</term>
	/// </item>
	/// <item>
	/// <term>IS_TEXT_UNICODE_REVERSE_SIGNATURE</term>
	/// <term>The text contains the Unicode byte-reversed byte-order mark (Reverse BOM) 0xFFFE as its first character.</term>
	/// </item>
	/// <item>
	/// <term>IS_TEXT_UNICODE_ILLEGAL_CHARS</term>
	/// <term>
	/// The text contains one of these Unicode-illegal characters: embedded Reverse BOM, UNICODE_NUL, CRLF (packed into one word), or 0xFFFF.
	/// </term>
	/// </item>
	/// <item>
	/// <term>IS_TEXT_UNICODE_ODD_LENGTH</term>
	/// <term>The number of characters in the string is odd. A string of odd length cannot (by definition) be Unicode text.</term>
	/// </item>
	/// <item>
	/// <term>IS_TEXT_UNICODE_NULL_BYTES</term>
	/// <term>The text contains null bytes, which indicate non-ASCII text.</term>
	/// </item>
	/// <item>
	/// <term>IS_TEXT_UNICODE_UNICODE_MASK</term>
	/// <term>The value is a combination of IS_TEXT_UNICODE_ASCII16, IS_TEXT_UNICODE_STATISTICS, IS_TEXT_UNICODE_CONTROLS, IS_TEXT_UNICODE_SIGNATURE.</term>
	/// </item>
	/// <item>
	/// <term>IS_TEXT_UNICODE_REVERSE_MASK</term>
	/// <term>
	/// The value is a combination of IS_TEXT_UNICODE_REVERSE_ASCII16, IS_TEXT_UNICODE_REVERSE_STATISTICS,
	/// IS_TEXT_UNICODE_REVERSE_CONTROLS, IS_TEXT_UNICODE_REVERSE_SIGNATURE.
	/// </term>
	/// </item>
	/// <item>
	/// <term>IS_TEXT_UNICODE_NOT_UNICODE_MASK</term>
	/// <term>
	/// The value is a combination of IS_TEXT_UNICODE_ILLEGAL_CHARS, IS_TEXT_UNICODE_ODD_LENGTH, and two currently unused bit flags.
	/// </term>
	/// </item>
	/// <item>
	/// <term>IS_TEXT_UNICODE_NOT_ASCII_MASK</term>
	/// <term>The value is a combination of IS_TEXT_UNICODE_NULL_BYTES and three currently unused bit flags.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <returns>
	/// Returns a nonzero value if the data in the buffer passes the specified tests. The function returns 0 if the data in the buffer
	/// does not pass the specified tests.
	/// </returns>
	/// <remarks>
	/// <para>
	/// This function uses various statistical and deterministic methods to make its determination, under the control of flags passed in
	/// the lpiResult parameter. When the function returns, the results of such tests are reported using the same parameter.
	/// </para>
	/// <para>
	/// The IS_TEXT_UNICODE_STATISTICS and IS_TEXT_UNICODE_REVERSE_STATISTICS tests use statistical analysis. These tests are not
	/// foolproof. The statistical tests assume certain amounts of variation between low and high bytes in a string, and some ASCII
	/// strings can slip through. For example, if lpv indicates the ASCII string 0x41, 0x0A, 0x0D, 0x1D (A\n\r^Z), the string passes the
	/// IS_TEXT_UNICODE_STATISTICS test, although failure would be preferable.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winbase/nf-winbase-istextunicode BOOL IsTextUnicode( const VOID *lpv, int
	// iSize, LPINT lpiResult );
	[DllImport(Lib.AdvApi32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("winbase.h", MSDNShortId = "47e05b5b-a16b-4957-bc86-ed3cef4968ee")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool IsTextUnicode(IntPtr lpv, int iSize, ref IS_TEXT_UNICODE lpiResult);

	/// <summary>
	/// The LogonUser function attempts to log a user on to the local computer. The local computer is the computer from which LogonUser
	/// was called. You cannot use LogonUser to log on to a remote computer. You specify the user with a user name and domain and
	/// authenticate the user with a plain-text password. If the function succeeds, you receive a handle to a token that represents the
	/// logged-on user. You can then use this token handle to impersonate the specified user or, in most cases, to create a process that
	/// runs in the context of the specified user.
	/// </summary>
	/// <param name="lpszUserName">
	/// A pointer to a null-terminated string that specifies the name of the user. This is the name of the user account to log on to. If
	/// you use the user principal name (UPN) format, User@DNSDomainName, the lpszDomain parameter must be NULL.
	/// </param>
	/// <param name="lpszDomain">
	/// A pointer to a null-terminated string that specifies the name of the domain or server whose account database contains the
	/// lpszUsername account. If this parameter is NULL, the user name must be specified in UPN format. If this parameter is ".", the
	/// function validates the account by using only the local account database.
	/// </param>
	/// <param name="lpszPassword">
	/// A pointer to a null-terminated string that specifies the plain-text password for the user account specified by lpszUsername. When
	/// you have finished using the password, clear the password from memory by calling the SecureZeroMemory function. For more
	/// information about protecting passwords, see Handling Passwords.
	/// </param>
	/// <param name="dwLogonType">The type of logon operation to perform.</param>
	/// <param name="dwLogonProvider">Specifies the logon provider.</param>
	/// <param name="phObject">
	/// A pointer to a handle variable that receives a handle to a token that represents the specified user.
	/// <para>You can use the returned handle in calls to the ImpersonateLoggedOnUser function.</para>
	/// <para>
	/// In most cases, the returned handle is a primary token that you can use in calls to the CreateProcessAsUser function. However, if
	/// you specify the LOGON32_LOGON_NETWORK flag, LogonUser returns an impersonation token that you cannot use in CreateProcessAsUser
	/// unless you call DuplicateTokenEx to convert it to a primary token.
	/// </para>
	/// <para>When you no longer need this handle, close it by calling the CloseHandle function.</para>
	/// </param>
	/// <returns>
	/// If the function succeeds, the return value is nonzero. If the function fails, the return value is zero. To get extended error
	/// information, call GetLastError.
	/// </returns>
	[DllImport(Lib.AdvApi32, SetLastError = true, CharSet = CharSet.Auto)]
	[return: MarshalAs(UnmanagedType.Bool)]
	[PInvokeData("winbase.h", MSDNShortId = "aa378184")]
	public static extern bool LogonUser(string lpszUserName, [Optional] string? lpszDomain, [Optional] string? lpszPassword, LogonUserType dwLogonType, LogonUserProvider dwLogonProvider,
		out SafeHTOKEN phObject);

	/// <summary>
	/// The LogonUserEx function attempts to log a user on to the local computer. The local computer is the computer from which
	/// LogonUserEx was called. You cannot use LogonUserEx to log on to a remote computer. You specify the user with a user name and
	/// domain and authenticate the user with a plaintext password. If the function succeeds, you receive a handle to a token that
	/// represents the logged-on user. You can then use this token handle to impersonate the specified user or, in most cases, to create
	/// a process that runs in the context of the specified user.
	/// </summary>
	/// <param name="lpszUserName">
	/// A pointer to a null-terminated string that specifies the name of the user. This is the name of the user account to log on to. If
	/// you use the user principal name (UPN) format, user@DNS_domain_name, the lpszDomain parameter must be NULL.
	/// </param>
	/// <param name="lpszDomain">
	/// A pointer to a null-terminated string that specifies the name of the domain or server whose account database contains the
	/// lpszUsername account. If this parameter is NULL, the user name must be specified in UPN format. If this parameter is ".", the
	/// function validates the account by using only the local account database.
	/// </param>
	/// <param name="lpszPassword">
	/// A pointer to a null-terminated string that specifies the plaintext password for the user account specified by lpszUsername. When
	/// you have finished using the password, clear the password from memory by calling the SecureZeroMemory function. For more
	/// information about protecting passwords, see Handling Passwords.
	/// </param>
	/// <param name="dwLogonType">The type of logon operation to perform.</param>
	/// <param name="dwLogonProvider">The logon provider.</param>
	/// <param name="phObject">
	/// A pointer to a handle variable that receives a handle to a token that represents the specified user.
	/// <para>You can use the returned handle in calls to the ImpersonateLoggedOnUser function.</para>
	/// <para>
	/// In most cases, the returned handle is a primary token that you can use in calls to the CreateProcessAsUser function. However, if
	/// you specify the LOGON32_LOGON_NETWORK flag, LogonUser returns an impersonation token that you cannot use in CreateProcessAsUser
	/// unless you call DuplicateTokenEx to convert it to a primary token.
	/// </para>
	/// <para>When you no longer need this handle, close it by calling the CloseHandle function.</para>
	/// </param>
	/// <param name="ppLogonSid">
	/// A pointer to a pointer to a security identifier (SID) that receives the SID of the user logged on.
	/// <para>When you have finished using the SID, free it by calling the LocalFree function.</para>
	/// </param>
	/// <param name="ppProfileBuffer">
	/// A pointer to a pointer that receives the address of a buffer that contains the logged on user's profile.
	/// </param>
	/// <param name="pdwProfileLength">A pointer to a DWORD that receives the length of the profile buffer.</param>
	/// <param name="pQuotaLimits">
	/// A pointer to a QUOTA_LIMITS structure that receives information about the quotas for the logged on user.
	/// </param>
	/// <returns>
	/// If the function succeeds, the function returns nonzero. If the function fails, it returns zero. To get extended error
	/// information, call GetLastError.
	/// </returns>
	[DllImport(Lib.AdvApi32, SetLastError = true, CharSet = CharSet.Auto)]
	[return: MarshalAs(UnmanagedType.Bool)]
	[PInvokeData("winbase.h", MSDNShortId = "aa378189")]
	public static extern bool LogonUserEx(string lpszUserName, [Optional] string? lpszDomain, [Optional] string? lpszPassword, LogonUserType dwLogonType, LogonUserProvider dwLogonProvider,
		out SafeHTOKEN phObject, out SafePSID ppLogonSid, out SafeLsaReturnBufferHandle ppProfileBuffer, out uint pdwProfileLength, out QUOTA_LIMITS pQuotaLimits);

	/// <summary>
	/// <para>
	/// The <c>LogonUserExExW</c> function attempts to log a user on to the local computer. The local computer is the computer from which
	/// <c>LogonUserExExW</c> was called. You cannot use <c>LogonUserExExW</c> to log on to a remote computer. Specify the user by using
	/// a user name and domain and authenticate the user by using a plaintext password. If the function succeeds, it receives a handle to
	/// a token that represents the logged-on user. You can then use this token handle to impersonate the specified user or, in most
	/// cases, to create a process that runs in the context of the specified user.
	/// </para>
	/// <para>
	/// This function is similar to the <c>LogonUserEx</c> function, except that it takes the additional parameter, pTokenGroups, which
	/// is a set of one or more security identifiers (SIDs) that are added to the token returned to the caller when the logon is successful.
	/// </para>
	/// <para>
	/// This function is not declared in a public header and has no associated import library. You must use the <c>LoadLibrary</c> and
	/// <c>GetProcAddress</c> functions to dynamically link to Advapi32.dll.
	/// </para>
	/// </summary>
	/// <param name="lpszUserName">
	/// A pointer to a null-terminated string that specifies the name of the user. This is the name of the user account to log on to. If
	/// you use the user principal name (UPN) format, user@DNS_domain_name, the lpszDomain parameter must be NULL.
	/// </param>
	/// <param name="lpszDomain">
	/// A pointer to a null-terminated string that specifies the name of the domain or server whose account database contains the
	/// lpszUsername account. If this parameter is NULL, the user name must be specified in UPN format. If this parameter is ".", the
	/// function validates the account by using only the local account database.
	/// </param>
	/// <param name="lpszPassword">
	/// A pointer to a null-terminated string that specifies the plaintext password for the user account specified by lpszUsername. When
	/// you have finished using the password, clear the password from memory by calling the SecureZeroMemory function. For more
	/// information about protecting passwords, see Handling Passwords.
	/// </param>
	/// <param name="dwLogonType">The type of logon operation to perform.</param>
	/// <param name="dwLogonProvider">The logon provider.</param>
	/// <param name="pTokenGroups">
	/// A pointer to a TOKEN_GROUPS structure that specifies a list of group SIDs that are added to the token that this function receives
	/// upon successful logon. Any SIDs added to the token also effect group expansion. For example, if the added SIDs are members of
	/// local groups, those groups are also added to the received access token.
	/// <para>If this parameter is not NULL, the caller of this function must have the SE_TCB_PRIVILEGE privilege granted and enabled.</para>
	/// </param>
	/// <param name="phToken">
	/// A pointer to a handle variable that receives a handle to a token that represents the specified user.
	/// <para>You can use the returned handle in calls to the ImpersonateLoggedOnUser function.</para>
	/// <para>
	/// In most cases, the returned handle is a primary token that you can use in calls to the CreateProcessAsUser function.However, if
	/// you specify the LOGON32_LOGON_NETWORK flag, LogonUserExExW returns an impersonation token that you cannot use in
	/// CreateProcessAsUser unless you call DuplicateTokenEx to convert the impersonation token to a primary token.
	/// </para>
	/// <para>When you no longer need this handle, close it by calling the CloseHandle function.</para>
	/// </param>
	/// <param name="ppLogonSid">
	/// A pointer to a pointer to a SID that receives the SID of the user logged on.
	/// <para>When you have finished using the SID, free it by calling the LocalFree function.</para>
	/// </param>
	/// <param name="ppProfileBuffer">
	/// A pointer to a pointer that receives the address of a buffer that contains the logged on user's profile.
	/// </param>
	/// <param name="pdwProfileLength">A pointer to a DWORD that receives the length of the profile buffer.</param>
	/// <param name="pQuotaLimits">
	/// A pointer to a QUOTA_LIMITS structure that receives information about the quotas for the logged on user.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the function returns nonzero.</para>
	/// <para>If the function fails, it returns zero. To get extended error information, call <c>GetLastError</c>.</para>
	/// </returns>
	/// <remarks>
	/// <para>The <c>LOGON32_LOGON_NETWORK</c> logon type is fastest, but it has the following limitations:</para>
	/// <list type="bullet">
	/// <item>
	/// <term>
	/// The function returns an impersonation token, not a primary token. You cannot use this token directly in the
	/// <c>CreateProcessAsUser</c> function. However, you can call the <c>DuplicateTokenEx</c> function to convert the token to a primary
	/// token, and then use it in <c>CreateProcessAsUser</c>.
	/// </term>
	/// </item>
	/// <item>
	/// <term>
	/// If you convert the token to a primary token and use it in <c>CreateProcessAsUser</c> to start a process, the new process cannot
	/// access other network resources, such as remote servers or printers, through the redirector. An exception is that if the network
	/// resource is not access controlled, then the new process will be able to access it.
	/// </term>
	/// </item>
	/// </list>
	/// <para>
	/// The account specified by lpszUsername must have the necessary account rights. For example, to log on a user with the
	/// <c>LOGON32_LOGON_INTERACTIVE</c> flag, the user (or a group to which the user belongs) must have the
	/// <c>SE_INTERACTIVE_LOGON_NAME</c> account right. For a list of the account rights that affect the various logon operations, see
	/// Account Object Access Rights.
	/// </para>
	/// <para>
	/// A user is considered logged on if at least one token exists. If you call <c>CreateProcessAsUser</c> and then close the token, the
	/// user is still logged on until the process (and all child processes) have ended.
	/// </para>
	/// <para>If the optional pTokenGroups parameter is supplied, LSA will not add either the local SID or the logon SID automatically.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/SecAuthN/logonuserexexw BOOL WINAPI LogonUserExExW( _In_ StrPtrAuto lpszUsername,
	// _In_opt_ StrPtrAuto lpszDomain, _In_opt_ StrPtrAuto lpszPassword, _In_ DWORD dwLogonType, _In_ DWORD dwLogonProvider, _In_opt_
	// PTOKEN_GROUPS pTokenGroups, _Out_opt_ PHANDLE phToken, _Out_opt_ PSID *ppLogonSid, _Out_opt_ PVOID *ppProfileBuffer, _Out_opt_
	// LPDWORD pdwProfileLength, _Out_opt_ PQUOTA_LIMITS pQuotaLimits );
	[DllImport(Lib.AdvApi32, SetLastError = true, ExactSpelling = true, CharSet = CharSet.Unicode)]
	[PInvokeData("", MSDNShortId = "d90db4c6-a711-4519-8b91-5069cee07738")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool LogonUserExExW(string lpszUserName, [Optional] string? lpszDomain, [Optional] string? lpszPassword, LogonUserType dwLogonType, LogonUserProvider dwLogonProvider,
		[In, Optional] in TOKEN_GROUPS pTokenGroups, out SafeHTOKEN phToken, out SafePSID ppLogonSid, out SafeLsaReturnBufferHandle ppProfileBuffer, out uint pdwProfileLength, out QUOTA_LIMITS pQuotaLimits);

	/// <summary>
	/// The LookupAccountName function accepts the name of a system and an account as input. It retrieves a security identifier (SID) for
	/// the account and the name of the domain on which the account was found.
	/// </summary>
	/// <param name="lpSystemName">
	/// A pointer to a null-terminated character string that specifies the name of the system. This string can be the name of a remote
	/// computer. If this string is NULL, the account name translation begins on the local system. If the name cannot be resolved on the
	/// local system, this function will try to resolve the name using domain controllers trusted by the local system. Generally, specify
	/// a value for lpSystemName only when the account is in an untrusted domain and the name of a computer in that domain is known.
	/// </param>
	/// <param name="lpAccountName">
	/// A pointer to a null-terminated string that specifies the account name.
	/// <para>
	/// Use a fully qualified string in the domain_name\user_name format to ensure that LookupAccountName finds the account in the
	/// desired domain.
	/// </para>
	/// </param>
	/// <param name="Sid">
	/// A pointer to a buffer that receives the SID structure that corresponds to the account name pointed to by the lpAccountName
	/// parameter. If this parameter is NULL, cbSid must be zero.
	/// </param>
	/// <param name="cbSid">
	/// A pointer to a variable. On input, this value specifies the size, in bytes, of the Sid buffer. If the function fails because the
	/// buffer is too small or if cbSid is zero, this variable receives the required buffer size.
	/// </param>
	/// <param name="ReferencedDomainName">
	/// A pointer to a buffer that receives the name of the domain where the account name is found. For computers that are not joined to
	/// a domain, this buffer receives the computer name. If this parameter is NULL, the function returns the required buffer size.
	/// </param>
	/// <param name="cchReferencedDomainName">
	/// A pointer to a variable. On input, this value specifies the size, in TCHARs, of the ReferencedDomainName buffer. If the function
	/// fails because the buffer is too small, this variable receives the required buffer size, including the terminating null character.
	/// If the ReferencedDomainName parameter is NULL, this parameter must be zero.
	/// </param>
	/// <param name="peUse">A pointer to a SID_NAME_USE enumerated type that indicates the type of the account when the function returns.</param>
	/// <returns>
	/// If the function succeeds, the function returns nonzero. If the function fails, it returns zero. For extended error information,
	/// call GetLastError.
	/// </returns>
	[DllImport(Lib.AdvApi32, CharSet = CharSet.Auto, SetLastError = true)]
	[return: MarshalAs(UnmanagedType.Bool)]
	[PInvokeData("winbase.h", MSDNShortId = "aa379159")]
	public static extern bool LookupAccountName([Optional] string? lpSystemName, string lpAccountName, SafePSID Sid, ref int cbSid,
		[Optional] StringBuilder? ReferencedDomainName, ref int cchReferencedDomainName, out SID_NAME_USE peUse);

	/// <summary>
	/// The LookupAccountName function accepts the name of a system and an account as input. It retrieves a security identifier (SID) for
	/// the account and the name of the domain on which the account was found.
	/// </summary>
	/// <param name="systemName">
	/// A string that specifies the name of the system. This string can be the name of a remote computer. If this string is NULL, the
	/// account name translation begins on the local system. If the name cannot be resolved on the local system, this function will try
	/// to resolve the name using domain controllers trusted by the local system. Generally, specify a value for lpSystemName only when
	/// the account is in an untrusted domain and the name of a computer in that domain is known.
	/// </param>
	/// <param name="accountName">
	/// A string that specifies the account name.
	/// <para>
	/// Use a fully qualified string in the domain_name\user_name format to ensure that LookupAccountName finds the account in the
	/// desired domain.
	/// </para>
	/// </param>
	/// <param name="sid">A PSID class that corresponds to the account name pointed to by the lpAccountName parameter.</param>
	/// <param name="domainName">
	/// A string that receives the name of the domain where the account name is found. For computers that are not joined to a domain,
	/// this buffer receives the computer name.
	/// </param>
	/// <param name="snu">A SID_NAME_USE enumerated type that indicates the type of the account when the function returns.</param>
	/// <returns>
	/// If the function succeeds, the function returns nonzero. If the function fails, it returns zero. For extended error information,
	/// call GetLastError.
	/// </returns>
	[PInvokeData("winbase.h", MSDNShortId = "aa379159")]
	public static bool LookupAccountName([Optional] string? systemName, string accountName, out SafePSID sid, out string domainName, out SID_NAME_USE snu)
	{
		int sidSz = 0, sbSz = 0;
		LookupAccountName(systemName, accountName, SafePSID.Null, ref sidSz, null, ref sbSz, out _);
		var sb = new StringBuilder(sbSz);
		sid = new SafePSID((SizeT)sidSz);
		var ret = LookupAccountName(systemName, accountName, sid, ref sidSz, sb, ref sbSz, out snu);
		domainName = sb.ToString();
		return ret;
	}

	/// <summary>
	/// The LookupAccountSid function accepts a security identifier (SID) as input. It retrieves the name of the account for this SID and
	/// the name of the first domain on which this SID is found.
	/// </summary>
	/// <param name="lpSystemName">
	/// A pointer to a null-terminated character string that specifies the target computer. This string can be the name of a remote
	/// computer. If this parameter is NULL, the account name translation begins on the local system. If the name cannot be resolved on
	/// the local system, this function will try to resolve the name using domain controllers trusted by the local system. Generally,
	/// specify a value for lpSystemName only when the account is in an untrusted domain and the name of a computer in that domain is known.
	/// </param>
	/// <param name="lpSid">A pointer to the SID to look up.</param>
	/// <param name="lpName">
	/// A pointer to a buffer that receives a null-terminated string that contains the account name that corresponds to the lpSid parameter.
	/// </param>
	/// <param name="cchName">
	/// On input, specifies the size, in TCHARs, of the lpName buffer. If the function fails because the buffer is too small or if
	/// cchName is zero, cchName receives the required buffer size, including the terminating null character.
	/// </param>
	/// <param name="lpReferencedDomainName">
	/// A pointer to a buffer that receives a null-terminated string that contains the name of the domain where the account name was found.
	/// <para>
	/// On a server, the domain name returned for most accounts in the security database of the local computer is the name of the domain
	/// for which the server is a domain controller.
	/// </para>
	/// <para>
	/// On a workstation, the domain name returned for most accounts in the security database of the local computer is the name of the
	/// computer as of the last start of the system (backslashes are excluded). If the name of the computer changes, the old name
	/// continues to be returned as the domain name until the system is restarted.
	/// </para>
	/// <para>Some accounts are predefined by the system. The domain name returned for these accounts is BUILTIN.</para>
	/// </param>
	/// <param name="cchReferencedDomainName">
	/// On input, specifies the size, in TCHARs, of the lpReferencedDomainName buffer. If the function fails because the buffer is too
	/// small or if cchReferencedDomainName is zero, cchReferencedDomainName receives the required buffer size, including the terminating
	/// null character.
	/// </param>
	/// <param name="peUse">A pointer to a variable that receives a SID_NAME_USE value that indicates the type of the account.</param>
	/// <returns>
	/// If the function succeeds, the function returns nonzero. If the function fails, it returns zero. To get extended error
	/// information, call GetLastError.
	/// </returns>
	[DllImport(Lib.AdvApi32, CharSet = CharSet.Auto, SetLastError = true)]
	[return: MarshalAs(UnmanagedType.Bool)]
	[PInvokeData("winbase.h", MSDNShortId = "aa379166")]
	public static extern bool LookupAccountSid([Optional] string? lpSystemName, [In, MarshalAs(UnmanagedType.LPArray)] byte[] lpSid,
		[Out, Optional, MarshalAs(UnmanagedType.LPTStr)] StringBuilder? lpName, ref int cchName,
		[Out, Optional, MarshalAs(UnmanagedType.LPTStr)] StringBuilder? lpReferencedDomainName,
		ref int cchReferencedDomainName, out SID_NAME_USE peUse);

	/// <summary>
	/// The LookupAccountSid function accepts a security identifier (SID) as input. It retrieves the name of the account for this SID and
	/// the name of the first domain on which this SID is found.
	/// </summary>
	/// <param name="lpSystemName">
	/// A pointer to a null-terminated character string that specifies the target computer. This string can be the name of a remote
	/// computer. If this parameter is NULL, the account name translation begins on the local system. If the name cannot be resolved on
	/// the local system, this function will try to resolve the name using domain controllers trusted by the local system. Generally,
	/// specify a value for lpSystemName only when the account is in an untrusted domain and the name of a computer in that domain is known.
	/// </param>
	/// <param name="lpSid">A pointer to the SID to look up.</param>
	/// <param name="lpName">
	/// A pointer to a buffer that receives a null-terminated string that contains the account name that corresponds to the lpSid parameter.
	/// </param>
	/// <param name="cchName">
	/// On input, specifies the size, in TCHARs, of the lpName buffer. If the function fails because the buffer is too small or if
	/// cchName is zero, cchName receives the required buffer size, including the terminating null character.
	/// </param>
	/// <param name="lpReferencedDomainName">
	/// A pointer to a buffer that receives a null-terminated string that contains the name of the domain where the account name was found.
	/// <para>
	/// On a server, the domain name returned for most accounts in the security database of the local computer is the name of the domain
	/// for which the server is a domain controller.
	/// </para>
	/// <para>
	/// On a workstation, the domain name returned for most accounts in the security database of the local computer is the name of the
	/// computer as of the last start of the system (backslashes are excluded). If the name of the computer changes, the old name
	/// continues to be returned as the domain name until the system is restarted.
	/// </para>
	/// <para>Some accounts are predefined by the system. The domain name returned for these accounts is BUILTIN.</para>
	/// </param>
	/// <param name="cchReferencedDomainName">
	/// On input, specifies the size, in TCHARs, of the lpReferencedDomainName buffer. If the function fails because the buffer is too
	/// small or if cchReferencedDomainName is zero, cchReferencedDomainName receives the required buffer size, including the terminating
	/// null character.
	/// </param>
	/// <param name="peUse">A pointer to a variable that receives a SID_NAME_USE value that indicates the type of the account.</param>
	/// <returns>
	/// If the function succeeds, the function returns nonzero. If the function fails, it returns zero. To get extended error
	/// information, call GetLastError.
	/// </returns>
	[DllImport(Lib.AdvApi32, CharSet = CharSet.Auto, SetLastError = true)]
	[return: MarshalAs(UnmanagedType.Bool)]
	[PInvokeData("winbase.h", MSDNShortId = "aa379166")]
	public static extern bool LookupAccountSid([Optional] string? lpSystemName, [In] PSID lpSid,
		[Out, Optional, MarshalAs(UnmanagedType.LPTStr)] StringBuilder? lpName, ref int cchName,
		[Out, Optional, MarshalAs(UnmanagedType.LPTStr)] StringBuilder? lpReferencedDomainName,
		ref int cchReferencedDomainName, out SID_NAME_USE peUse);

	/// <summary>Retrieves the name of the account for the specified SID on the local machine.</summary>
	/// <param name="Sid">A pointer to the SID to look up.</param>
	/// <param name="Name">A pointer to a buffer that receives a <c>null</c>-terminated string that contains the account name that corresponds to the lpSid parameter.</param>
	/// <param name="cchName">On input, specifies the size, in <c>TCHAR</c>s, of the lpName buffer. If the function fails because the buffer is too small or if cchName is zero, cchName receives the required buffer size, including the terminating <c>null</c> character.</param>
	/// <param name="ReferencedDomainName">
	/// <para>A pointer to a buffer that receives a <c>null</c>-terminated string that contains the name of the domain where the account name was found.</para>
	/// <para>On a server, the domain name returned for most accounts in the security database of the local computer is the name of the domain for which the server is a domain controller.</para>
	/// <para>On a workstation, the domain name returned for most accounts in the security database of the local computer is the name of the computer as of the last start of the system (backslashes are excluded). If the name of the computer changes, the old name continues to be returned as the domain name until the system is restarted.</para>
	/// <para>Some accounts are predefined by the system. The domain name returned for these accounts is BUILTIN.</para>
	/// </param>
	/// <param name="cchReferencedDomainName">On input, specifies the size, in <c>TCHAR</c>s, of the lpReferencedDomainName buffer. If the function fails because the buffer is too small or if cchReferencedDomainName is zero, cchReferencedDomainName receives the required buffer size, including the terminating <c>null</c> character.</param>
	/// <param name="peUse">A pointer to a variable that receives a SID_NAME_USE value that indicates the type of the account.</param>
	/// <returns>
	/// <para>If the function succeeds, the function returns nonzero.</para>
	/// <para>If the function fails, it returns zero. To get extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>This function is similar to LookupAccountSid, but restricts the search to the local machine.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/winbase/nf-winbase-lookupaccountsidlocalw
	// BOOL LookupAccountSidLocalW( PSID Sid, StrPtrUni Name, LPDWORD cchName, StrPtrUni ReferencedDomainName, LPDWORD cchReferencedDomainName, PSID_NAME_USE peUse );
	[PInvokeData("winbase.h", MSDNShortId = "NF:winbase.LookupAccountSidLocalW")]
	public static bool LookupAccountSidLocal([In] PSID Sid, StringBuilder? Name, ref int cchName,
		StringBuilder? ReferencedDomainName, ref int cchReferencedDomainName, out SID_NAME_USE peUse) =>
		LookupAccountSid(null, Sid, Name, ref cchName, ReferencedDomainName, ref cchReferencedDomainName, out peUse);

	/// <summary>
	/// The LookupAccountSid2 function accepts a security identifier (SID) as input. It retrieves the name of the account for this SID
	/// and the name of the first domain on which this SID is found. It provides error handling beyond <c>LookupAccountSid</c>.
	/// </summary>
	/// <param name="lpSystemName">
	/// A pointer to a null-terminated character string that specifies the target computer. This string can be the name of a remote
	/// computer. If this parameter is NULL, the account name translation begins on the local system. If the name cannot be resolved on
	/// the local system, this function will try to resolve the name using domain controllers trusted by the local system. Generally,
	/// specify a value for lpSystemName only when the account is in an untrusted domain and the name of a computer in that domain is known.
	/// </param>
	/// <param name="lpSid">A pointer to the SID to look up.</param>
	/// <param name="lpName">Returns a string that contains the account name that corresponds to the lpSid parameter.</param>
	/// <param name="lpReferencedDomainName">
	/// Returns a string that contains the name of the domain where the account name was found.
	/// <para>
	/// On a server, the domain name returned for most accounts in the security database of the local computer is the name of the domain
	/// for which the server is a domain controller.
	/// </para>
	/// <para>
	/// On a workstation, the domain name returned for most accounts in the security database of the local computer is the name of the
	/// computer as of the last start of the system (backslashes are excluded). If the name of the computer changes, the old name
	/// continues to be returned as the domain name until the system is restarted.
	/// </para>
	/// <para>Some accounts are predefined by the system. The domain name returned for these accounts is BUILTIN.</para>
	/// </param>
	/// <param name="peUse">A pointer to a variable that receives a SID_NAME_USE value that indicates the type of the account.</param>
	/// <returns>
	/// If the function succeeds, the function returns STATUS_SUCCESS or STATUS_SOME_NOT_MAPPED. If the function fails, it returns an
	/// NTSTATUS error. For more information see <see cref="LsaLookupSids2"/>.
	/// </returns>
	[PInvokeData("winbase.h", MSDNShortId = "aa379166")]
	public static NTStatus LookupAccountSid2([Optional] string? lpSystemName, PSID lpSid, out string lpName,
		out string lpReferencedDomainName, out SID_NAME_USE peUse)
	{
		lpName = lpReferencedDomainName = string.Empty;
		peUse = default;
		using var pol = LsaOpenPolicy(LsaPolicyRights.POLICY_LOOKUP_NAMES, lpSystemName);
		var ret = LsaLookupSids2(pol, LsaLookupSidsFlags.LSA_LOOKUP_RETURN_LOCAL_NAMES, 1, new[] { lpSid }, out var refDom, out var names);
		using (refDom)
		using (names)
		{
			if (ret == NTStatus.STATUS_SUCCESS || ret == NTStatus.STATUS_SOME_NOT_MAPPED)
			{
				lpReferencedDomainName = refDom.ToStructure<LSA_REFERENCED_DOMAIN_LIST>().DomainList.FirstOrDefault().Name;
				var name = names.ToArray<LSA_TRANSLATED_NAME>(1)[0];
				lpName = name.Name;
				peUse = name.Use;
			}
		}
		return ret;
	}

	/// <summary>
	/// <para>The <c>LookupPrivilegeDisplayName</c> function retrieves the display name that represents a specified privilege.</para>
	/// </summary>
	/// <param name="lpSystemName">
	/// <para>
	/// A pointer to a null-terminated string that specifies the name of the system on which the privilege name is retrieved. If a null
	/// string is specified, the function attempts to find the display name on the local system.
	/// </para>
	/// </param>
	/// <param name="lpName">
	/// <para>
	/// A pointer to a null-terminated string that specifies the name of the privilege, as defined in Winnt.h. For example, this
	/// parameter could specify the constant, SE_REMOTE_SHUTDOWN_NAME, or its corresponding string, "SeRemoteShutdownPrivilege". For a
	/// list of values, see Privilege Constants.
	/// </para>
	/// </param>
	/// <param name="lpDisplayName">
	/// <para>
	/// A pointer to a buffer that receives a null-terminated string that specifies the privilege display name. For example, if the
	/// lpName parameter is SE_REMOTE_SHUTDOWN_NAME, the privilege display name is "Force shutdown from a remote system."
	/// </para>
	/// </param>
	/// <param name="cchDisplayName">
	/// <para>
	/// A pointer to a variable that specifies the size, in <c>TCHAR</c> s, of the lpDisplayName buffer. When the function returns, this
	/// parameter contains the length of the privilege display name, not including the terminating null character. If the buffer pointed
	/// to by the lpDisplayName parameter is too small, this variable contains the required size.
	/// </para>
	/// </param>
	/// <param name="lpLanguageId">
	/// <para>A pointer to a variable that receives the language identifier for the returned display name.</para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The <c>LookupPrivilegeDisplayName</c> function retrieves display names only for the privileges specified in the Defined
	/// Privileges section of Winnt.h.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winbase/nf-winbase-lookupprivilegedisplaynamea BOOL
	// LookupPrivilegeDisplayNameA( LPCSTR lpSystemName, LPCSTR lpName, StrPtrAnsi lpDisplayName, LPDWORD cchDisplayName, LPDWORD lpLanguageId );
	[DllImport(Lib.AdvApi32, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("winbase.h", MSDNShortId = "1fbb26b6-615e-4883-9f4b-3a1d05d9feaa")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool LookupPrivilegeDisplayName([Optional] string? lpSystemName, string lpName, StringBuilder? lpDisplayName, ref uint cchDisplayName, out uint lpLanguageId);

	/// <summary>
	/// <para>
	/// The <c>LookupPrivilegeName</c> function retrieves the name that corresponds to the privilege represented on a specific system by
	/// a specified locally unique identifier (LUID).
	/// </para>
	/// </summary>
	/// <param name="lpSystemName">
	/// <para>
	/// A pointer to a null-terminated string that specifies the name of the system on which the privilege name is retrieved. If a null
	/// string is specified, the function attempts to find the privilege name on the local system.
	/// </para>
	/// </param>
	/// <param name="lpLuid">
	/// <para>A pointer to the LUID by which the privilege is known on the target system.</para>
	/// </param>
	/// <param name="lpName">
	/// <para>
	/// A pointer to a buffer that receives a null-terminated string that represents the privilege name. For example, this string could
	/// be "SeSecurityPrivilege".
	/// </para>
	/// </param>
	/// <param name="cchName">
	/// <para>
	/// A pointer to a variable that specifies the size, in a <c>TCHAR</c> value, of the lpName buffer. When the function returns, this
	/// parameter contains the length of the privilege name, not including the terminating null character. If the buffer pointed to by
	/// the lpName parameter is too small, this variable contains the required size.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the function returns nonzero.</para>
	/// <para>If the function fails, it returns zero. To get extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The <c>LookupPrivilegeName</c> function supports only the privileges specified in the Defined Privileges section of Winnt.h. For
	/// a list of values, see Privilege Constants.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winbase/nf-winbase-lookupprivilegenamea BOOL LookupPrivilegeNameA( LPCSTR
	// lpSystemName, PLUID lpLuid, StrPtrAnsi lpName, LPDWORD cchName );
	[DllImport(Lib.AdvApi32, CharSet = CharSet.Auto, SetLastError = true)]
	[PInvokeData("winbase.h", MSDNShortId = "580fb58f-1470-4389-9f07-8f37403e2bdf")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool LookupPrivilegeName([Optional] string? lpSystemName, in LUID lpLuid, StringBuilder? lpName, ref uint cchName);

	/// <summary>
	/// <para>
	/// The <c>LookupPrivilegeValue</c> function retrieves the locally unique identifier (LUID) used on a specified system to locally
	/// represent the specified privilege name.
	/// </para>
	/// </summary>
	/// <param name="lpSystemName">
	/// <para>
	/// A pointer to a null-terminated string that specifies the name of the system on which the privilege name is retrieved. If a null
	/// string is specified, the function attempts to find the privilege name on the local system.
	/// </para>
	/// </param>
	/// <param name="lpName">
	/// <para>
	/// A pointer to a null-terminated string that specifies the name of the privilege, as defined in the Winnt.h header file. For
	/// example, this parameter could specify the constant, SE_SECURITY_NAME, or its corresponding string, "SeSecurityPrivilege".
	/// </para>
	/// </param>
	/// <param name="lpLuid">
	/// <para>
	/// A pointer to a variable that receives the LUID by which the privilege is known on the system specified by the lpSystemName parameter.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the function returns nonzero.</para>
	/// <para>If the function fails, it returns zero. To get extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The <c>LookupPrivilegeValue</c> function supports only the privileges specified in the Defined Privileges section of Winnt.h. For
	/// a list of values, see Privilege Constants.
	/// </para>
	/// <para>Examples</para>
	/// <para>For an example that uses this function, see Enabling and Disabling Privileges.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winbase/nf-winbase-lookupprivilegevaluea BOOL LookupPrivilegeValueA( LPCSTR
	// lpSystemName, LPCSTR lpName, PLUID lpLuid );
	[DllImport(Lib.AdvApi32, CharSet = CharSet.Auto, SetLastError = true)]
	[PInvokeData("winbase.h", MSDNShortId = "334b8ba8-101d-43a1-a8bf-1c7e0448c272")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool LookupPrivilegeValue([Optional] string? lpSystemName, string lpName, out LUID lpLuid);

	/// <summary>
	/// The <c>ObjectCloseAuditAlarm</c> function generates an audit message in the security event log when a handle to a private object
	/// is deleted. Alarms are not currently supported.
	/// </summary>
	/// <param name="SubsystemName">
	/// A pointer to a null-terminated string specifying the name of the subsystem calling the function. This string appears in any audit
	/// message that the function generates.
	/// </param>
	/// <param name="HandleId">
	/// A unique value representing the client's handle to the object. This should be the same value that was passed to the
	/// AccessCheckAndAuditAlarm or ObjectOpenAuditAlarm function.
	/// </param>
	/// <param name="GenerateOnClose">
	/// Specifies a flag set by a call to the AccessCheckAndAuditAlarm or <c>ObjectCloseAuditAlarm</c> function when the object handle is
	/// created. If this flag is <c>TRUE</c>, the function generates an audit message. If it is <c>FALSE</c>, the function does not
	/// generate an audit message.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// The <c>ObjectCloseAuditAlarm</c> function requires the calling application to have the SE_AUDIT_NAME privilege enabled. The test
	/// for this privilege is always performed against the primary token of the calling process, allowing the calling process to
	/// impersonate a client.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winbase/nf-winbase-objectcloseauditalarma BOOL ObjectCloseAuditAlarmA( LPCSTR
	// SubsystemName, LPVOID HandleId, BOOL GenerateOnClose );
	[DllImport(Lib.AdvApi32, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("winbase.h", MSDNShortId = "274f3a62-1833-402b-b362-f526b2bee14b")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool ObjectCloseAuditAlarm(string SubsystemName, IntPtr HandleId, [MarshalAs(UnmanagedType.Bool)] bool GenerateOnClose);

	/// <summary>
	/// The <c>ObjectOpenAuditAlarm</c> function generates audit messages when a client application attempts to gain access to an object
	/// or to create a new one. Alarms are not currently supported.
	/// </summary>
	/// <param name="SubsystemName">
	/// A pointer to a <c>null</c>-terminated string specifying the name of the subsystem calling the function. This string appears in
	/// any audit message that the function generates.
	/// </param>
	/// <param name="HandleId">
	/// <para>
	/// A pointer to a unique value representing the client's handle to the object. If the access is denied, this parameter is ignored.
	/// </para>
	/// <para>For cross-platform compatibility, the value addressed by this pointer must be sizeof(LPVOID) bytes long.</para>
	/// </param>
	/// <param name="ObjectTypeName">
	/// A pointer to a <c>null</c>-terminated string specifying the type of object to which the client is requesting access. This string
	/// appears in any audit message that the function generates.
	/// </param>
	/// <param name="ObjectName">
	/// A pointer to a <c>null</c>-terminated string specifying the name of the object to which the client is requesting access. This
	/// string appears in any audit message that the function generates.
	/// </param>
	/// <param name="pSecurityDescriptor">A pointer to the SECURITY_DESCRIPTOR structure for the object being accessed.</param>
	/// <param name="ClientToken">
	/// Identifies an access token representing the client requesting the operation. This handle must be obtained by opening the token of
	/// a thread impersonating the client. The token must be open for TOKEN_QUERY access.
	/// </param>
	/// <param name="DesiredAccess">
	/// Specifies the desired access mask. This mask must have been previously mapped by the MapGenericMask function to contain no
	/// generic access rights.
	/// </param>
	/// <param name="GrantedAccess">
	/// Specifies an access mask indicating which access rights are granted. This access mask is intended to be the same value set by one
	/// of the access-checking functions in its GrantedAccess parameter. Examples of access-checking functions include
	/// AccessCheckAndAuditAlarm and AccessCheck.
	/// </param>
	/// <param name="Privileges">
	/// A pointer to a PRIVILEGE_SET structure that specifies the set of privileges required for the access attempt. This parameter can
	/// be <c>NULL</c>.
	/// </param>
	/// <param name="ObjectCreation">
	/// Specifies a flag that determines whether the application creates a new object when access is granted. When this value is
	/// <c>TRUE</c>, the application creates a new object; when it is <c>FALSE</c>, the application opens an existing object.
	/// </param>
	/// <param name="AccessGranted">
	/// Specifies a flag indicating whether access was granted or denied in a previous call to an access-checking function, such as
	/// AccessCheck. If access was granted, this value is <c>TRUE</c>. If not, it is <c>FALSE</c>.
	/// </param>
	/// <param name="GenerateOnClose">
	/// A pointer to a flag set by the audit-generation routine when the function returns. This value must be passed to the
	/// ObjectCloseAuditAlarm function when the object handle is closed.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// The <c>ObjectOpenAuditAlarm</c> function requires the calling application to have the SE_AUDIT_NAME privilege enabled. The test
	/// for this privilege is always performed against the primary token of the calling process, not the impersonation token of the
	/// thread. This allows the calling process to impersonate a client during the call.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winbase/nf-winbase-objectopenauditalarma BOOL ObjectOpenAuditAlarmA( LPCSTR
	// SubsystemName, LPVOID HandleId, StrPtrAnsi ObjectTypeName, StrPtrAnsi ObjectName, PSECURITY_DESCRIPTOR pSecurityDescriptor, HANDLE
	// ClientToken, DWORD DesiredAccess, DWORD GrantedAccess, PPRIVILEGE_SET Privileges, BOOL ObjectCreation, BOOL AccessGranted, LPBOOL
	// GenerateOnClose );
	[DllImport(Lib.AdvApi32, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("winbase.h", MSDNShortId = "f3cb607b-a8fd-4a1b-9361-7ccd7cd8aac2")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool ObjectOpenAuditAlarm(string SubsystemName, IntPtr HandleId, string ObjectTypeName, string? ObjectName,
		PSECURITY_DESCRIPTOR pSecurityDescriptor, HTOKEN ClientToken, ACCESS_MASK DesiredAccess, ACCESS_MASK GrantedAccess,
		[In, Optional, MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(PRIVILEGE_SET.Marshaler))] PRIVILEGE_SET? Privileges,
		[MarshalAs(UnmanagedType.Bool)] bool ObjectCreation, [MarshalAs(UnmanagedType.Bool)] bool AccessGranted,
		[MarshalAs(UnmanagedType.Bool)] out bool GenerateOnClose);

	/// <summary>
	/// The <c>ObjectPrivilegeAuditAlarm</c> function generates an audit message in the security event log. A protected server can use
	/// this function to log attempts by a client to use a specified set of privileges with an open handle to a private object. Alarms
	/// are not currently supported.
	/// </summary>
	/// <param name="SubsystemName">
	/// A pointer to a null-terminated string specifying the name of the subsystem calling the function. This string appears in the audit message.
	/// </param>
	/// <param name="HandleId">A pointer to a unique value representing the client's handle to the object.</param>
	/// <param name="ClientToken">
	/// Identifies an access token representing the client that requested the operation. This handle must have been obtained by opening
	/// the token of a thread impersonating the client. The token must be open for TOKEN_QUERY access. The function uses this token to
	/// get the identity of the client for the audit message.
	/// </param>
	/// <param name="DesiredAccess">
	/// Specifies an access mask indicating the privileged access types being used or whose use is being attempted. The access mask can
	/// be mapped by the MapGenericMask function so it does not contain any generic access types.
	/// </param>
	/// <param name="Privileges">
	/// A pointer to a PRIVILEGE_SET structure containing the privileges that the client attempted to use. The names of the privileges
	/// appear in the audit message.
	/// </param>
	/// <param name="AccessGranted">
	/// Indicates whether the client's attempt to use the privileges was successful. If this value is <c>TRUE</c>, the audit message
	/// indicates success. If this value is <c>FALSE</c>, the audit message indicates failure.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The <c>ObjectPrivilegeAuditAlarm</c> function does not check the client's access to the object or check the client's access token
	/// to determine whether the privileges are held or enabled. Typically, you call the PrivilegeCheck function to determine whether the
	/// specified privileges are enabled in the access token, call the AccessCheck function to check the client's access to the object,
	/// and then call <c>ObjectPrivilegeAuditAlarm</c> to log the results.
	/// </para>
	/// <para>
	/// The <c>ObjectPrivilegeAuditAlarm</c> function requires the calling process to have SE_AUDIT_NAME privilege enabled. The test for
	/// this privilege is always performed against the primary token of the calling process, not the impersonation token of the thread.
	/// This allows the calling process to impersonate a client during the call.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winbase/nf-winbase-objectprivilegeauditalarma BOOL
	// ObjectPrivilegeAuditAlarmA( LPCSTR SubsystemName, LPVOID HandleId, HANDLE ClientToken, DWORD DesiredAccess, PPRIVILEGE_SET
	// Privileges, BOOL AccessGranted );
	[DllImport(Lib.AdvApi32, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("winbase.h", MSDNShortId = "76714ffe-be7c-4928-b7c9-e72441ada4c7")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool ObjectPrivilegeAuditAlarm(string SubsystemName, IntPtr HandleId, HTOKEN ClientToken, ACCESS_MASK DesiredAccess,
		[In, MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(PRIVILEGE_SET.Marshaler))] PRIVILEGE_SET Privileges,
		[MarshalAs(UnmanagedType.Bool)] bool AccessGranted);

	/// <summary>
	/// Opens an encrypted file in order to backup (export) or restore (import) the file. This is one of a group of Encrypted File System
	/// (EFS) functions that is intended to implement backup and restore functionality, while maintaining files in their encrypted state.
	/// </summary>
	/// <param name="lpFileName">
	/// The name of the file to be opened. The string must consist of characters from the Windows character set.
	/// </param>
	/// <param name="ulFlags">The operation to be performed. This parameter may be one of the following values.</param>
	/// <param name="pvContext">
	/// The address of a context block that must be presented in subsequent calls to ReadEncryptedFileRaw, WriteEncryptedFileRaw, or
	/// CloseEncryptedFileRaw. Do not modify it.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, it returns <c>ERROR_SUCCESS</c>.</para>
	/// <para>
	/// If the function fails, it returns a nonzero error code defined in WinError.h. You can use FormatMessage with the
	/// <c>FORMAT_MESSAGE_FROM_SYSTEM</c> flag to get a generic text description of the error.
	/// </para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The caller must either have read or write access to the file, or it must have backup privilege SeBackupPrivilege on the machine
	/// on which the files reside in order for the call to succeed.
	/// </para>
	/// <para>
	/// To back up an encrypted file, call <c>OpenEncryptedFileRaw</c> to open the file and then call ReadEncryptedFileRaw. When the
	/// backup is complete, call CloseEncryptedFileRaw.
	/// </para>
	/// <para>
	/// To restore an encrypted file, call <c>OpenEncryptedFileRaw</c>, specifying <c>CREATE_FOR_IMPORT</c> in the ulFlags parameter, and
	/// then call WriteEncryptedFileRaw once. When the operation is completed, call CloseEncryptedFileRaw.
	/// </para>
	/// <para>
	/// <c>OpenEncryptedFileRaw</c> fails if lpFileName exceeds <c>MAX_PATH</c> characters when opening an encrypted file on a remote machine.
	/// </para>
	/// <para>
	/// If the caller does not have access to the key for the file, the caller needs SeBackupPrivilege to export encrypted files or
	/// SeRestorePrivilege to import encrypted files.
	/// </para>
	/// <para>The BackupRead and BackupWrite functions handle backup and restore of unencrypted files.</para>
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
	// https://docs.microsoft.com/en-us/windows/desktop/api/winbase/nf-winbase-openencryptedfilerawa DWORD OpenEncryptedFileRawA( LPCSTR
	// lpFileName, ULONG ulFlags, PVOID *pvContext );
	[DllImport(Lib.AdvApi32, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("winbase.h", MSDNShortId = "f792f38d-783e-4f39-a9d8-0c378d508d97")]
	public static extern Win32Error OpenEncryptedFileRaw(string lpFileName, OpenRawFlags ulFlags, out SafeEncryptedFileContext pvContext);

	/// <summary>
	/// <para>Notifies the system that the application is about to end an operation</para>
	/// <para>
	/// Every call to OperationStart must be followed by a call to <c>OperationEnd</c>, otherwise the operation's record of file access
	/// patterns is discarded after 10 seconds.
	/// </para>
	/// </summary>
	/// <param name="OperationEndParams">
	/// An _OPERATION_END_PARAMETERS structure that specifies <c>VERSION</c>, <c>OPERATION_ID</c> and <c>FLAGS</c>.
	/// </param>
	/// <returns><c>TRUE</c> for all valid parameters and <c>FALSE</c> otherwise. To get extended error information, call <c>GetLastError</c>.</returns>
	/// <remarks>
	/// <para>The version of the _OPERATION_END_PARAMETERS structure is defined as <c>OPERATION_API_VERSION</c> in the Windows SDK.</para>
	/// <para>The <c>OperationEnd</c> function is safe to call on any thread.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winbase/nf-winbase-operationend BOOL OperationEnd( OPERATION_END_PARAMETERS
	// *OperationEndParams );
	[DllImport(Lib.AdvApi32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("winbase.h", MSDNShortId = "73C6FBDD-BB4A-46A5-8E39-7862A1938F47")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool OperationEnd(in OPERATION_END_PARAMETERS OperationEndParams);

	/// <summary>
	/// <para>Notifies the system that the application is about to start an operation.</para>
	/// <para>
	/// If an application calls <c>OperationStart</c> with a valid OPERATION_ID value, the system records the specified operation’s file
	/// access patterns until OperationEnd is called for the same operation ID. This record is stored in a filename.pf prefetch file.
	/// Every call to <c>OperationStart</c> must be followed by a call to <c>OperationEnd</c>, otherwise the operation's record is
	/// discarded after 10 seconds.
	/// </para>
	/// <para>
	/// If an application calls <c>OperationStart</c> for an operation ID for which a prefetch file exists, the system loads the
	/// operation's files into memory prior to running the operation. The recording process remains the same and the system updates the
	/// appropriate filename.pf prefetch file.
	/// </para>
	/// </summary>
	/// <param name="OperationStartParams">
	/// An _OPERATION_START_PARAMETERS structure that specifies <c>VERSION</c>, <c>OPERATION_ID</c> and <c>FLAGS</c>.
	/// </param>
	/// <returns><c>TRUE</c> for all valid parameters and <c>FALSE</c> otherwise. To get extended error information, call <c>GetLastError</c>.</returns>
	/// <remarks>
	/// <para>The version of the _OPERATION_START_PARAMETERS structure is defined as <c>OPERATION_API_VERSION</c> in the Windows SDK.</para>
	/// <para>
	/// Because the <c>OperationStart</c> function is synchronous, it can take several seconds to return. This should be avoided in UI
	/// threads for the best responsiveness.
	/// </para>
	/// <para>
	/// There is a single instance of the operation recorder in a process. Although the operation recorder APIs can be called from
	/// multiple threads within the process, all calls act on the single instance.
	/// </para>
	/// <para>
	/// Application launch tracing lasts for the first 10 second of the process lifetime. <c>OperationStart</c> should be called after
	/// the end of application launch tracing by the system.
	/// </para>
	/// <para>
	/// Every call to <c>OperationStart</c> must be followed by a call to OperationEnd. Otherwise, the operation trace will be discarded
	/// after about 10s.
	/// </para>
	/// <para>
	/// The maximum number of operations that can be recorded on a given system is configurable. If this maximum is exceeded, the least
	/// recently used prefetch files are replaced.
	/// </para>
	/// <para>
	/// On Windows 8, this functionality requires the Superfetch service to be enabled. Windows 8 will have the service enabled by
	/// default. For Windows Server 2012, this prefetching functionality needs to be enabled and disabled as required. This can be done
	/// using CIM based PowerShell cmdlets. The prefetcher functionality can be exposed using the CIM class of the <c>CIM_PrefetcherService</c>.
	/// </para>
	/// <para>Examples</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winbase/nf-winbase-operationstart BOOL OperationStart(
	// OPERATION_START_PARAMETERS *OperationStartParams );
	[DllImport(Lib.AdvApi32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("winbase.h", MSDNShortId = "3E67057E-D09F-48BA-A95A-5D00F4783D9C")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool OperationStart(in OPERATION_START_PARAMETERS OperationStartParams);

	/// <summary>
	/// <para>
	/// The <c>PrivilegedServiceAuditAlarm</c> function generates an audit message in the security event log. A protected server can use
	/// this function to log attempts by a client to use a specified set of privileges.
	/// </para>
	/// <para>Alarms are not currently supported.</para>
	/// </summary>
	/// <param name="SubsystemName">
	/// A pointer to a null-terminated string specifying the name of the subsystem calling the function. This information appears in the
	/// security event log record.
	/// </param>
	/// <param name="ServiceName">
	/// A pointer to a null-terminated string specifying the name of the privileged subsystem service. This information appears in the
	/// security event log record.
	/// </param>
	/// <param name="ClientToken">
	/// Identifies an access token representing the client that requested the operation. This handle must have been obtained by opening
	/// the token of a thread impersonating the client. The token must be open for TOKEN_QUERY access. The function uses this token to
	/// get the identity of the client for the security event log record.
	/// </param>
	/// <param name="Privileges">
	/// A pointer to a PRIVILEGE_SET structure containing the privileges that the client attempted to use. The names of the privileges
	/// appear in the security event log record.
	/// </param>
	/// <param name="AccessGranted">
	/// Indicates whether the client's attempt to use the privileges was successful. If this value is <c>TRUE</c>, the security event log
	/// record indicates success. If this value is <c>FALSE</c>, the security event log record indicates failure.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The <c>PrivilegedServiceAuditAlarm</c> function does not check the client's access token to determine whether the privileges are
	/// held or enabled. Typically, you first call the PrivilegeCheck function to determine whether the specified privileges are enabled
	/// in the access token, and then call <c>PrivilegedServiceAuditAlarm</c> to log the results.
	/// </para>
	/// <para>
	/// The <c>PrivilegedServiceAuditAlarm</c> function requires the calling process to have SE_AUDIT_NAME privilege enabled. The test
	/// for this privilege is always performed against the primary token of the calling process. This allows the calling process to
	/// impersonate a client during the call.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winbase/nf-winbase-privilegedserviceauditalarma BOOL
	// PrivilegedServiceAuditAlarmA( LPCSTR SubsystemName, LPCSTR ServiceName, HANDLE ClientToken, PPRIVILEGE_SET Privileges, BOOL
	// AccessGranted );
	[DllImport(Lib.AdvApi32, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("winbase.h", MSDNShortId = "a424c583-bb71-4bda-a27f-2389b89104d8")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool PrivilegedServiceAuditAlarm(string SubsystemName, string ServiceName, HTOKEN ClientToken,
		[In, MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(PRIVILEGE_SET.Marshaler))] PRIVILEGE_SET Privileges,
		[MarshalAs(UnmanagedType.Bool)] bool AccessGranted);

	/// <summary>
	/// Backs up (export) encrypted files. This is one of a group of Encrypted File System (EFS) functions that is intended to implement
	/// backup and restore functionality, while maintaining files in their encrypted state.
	/// </summary>
	/// <param name="pfExportCallback">
	/// A pointer to the export callback function. The system calls the callback function multiple times, each time passing a block of
	/// the file's data to the callback function until the entire file has been read. For more information, see ExportCallback.
	/// </param>
	/// <param name="pvCallbackContext">
	/// A pointer to an application-defined and allocated context block. The system passes this pointer to the callback function as a
	/// parameter so that the callback function can have access to application-specific data. This can be a structure and can contain any
	/// data the application needs, such as the handle to the file that will contain the backup copy of the encrypted file.
	/// </param>
	/// <param name="pvContext">
	/// A pointer to a system-defined context block. The context block is returned by the OpenEncryptedFileRaw function. Do not modify it.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is <c>ERROR_SUCCESS</c>.</para>
	/// <para>
	/// If the function fails, it returns a nonzero error code defined in WinError.h. You can use FormatMessage with the
	/// <c>FORMAT_MESSAGE_FROM_SYSTEM</c> flag to get a generic text description of the error.
	/// </para>
	/// </returns>
	/// <remarks>
	/// <para>The file being backed up is not decrypted; it is backed up in its encrypted state.</para>
	/// <para>
	/// To back up an encrypted file, call OpenEncryptedFileRaw to open the file. Then call <c>ReadEncryptedFileRaw</c>, passing it the
	/// address of an application-defined export callback function. The system calls this callback function multiple times until the
	/// entire file's contents have been read and backed up. When the backup is complete, call CloseEncryptedFileRaw to free resources
	/// and close the file. See ExportCallback for details about how to declare the export callback function.
	/// </para>
	/// <para>
	/// To restore an encrypted file, call OpenEncryptedFileRaw, specifying <c>CREATE_FOR_IMPORT</c> in the ulFlags parameter. Then call
	/// WriteEncryptedFileRaw, passing it the address of an application-defined import callback function. The system calls this callback
	/// function multiple times until the entire file's contents have been read and restored. When the restore is complete, call
	/// CloseEncryptedFileRaw to free resources and close the file. See ImportCallback for details about how to declare the import
	/// callback function.
	/// </para>
	/// <para>This function is intended for the backup of only encrypted files; see BackupRead for backup of unencrypted files.</para>
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
	// https://docs.microsoft.com/en-us/windows/desktop/api/winbase/nf-winbase-readencryptedfileraw DWORD ReadEncryptedFileRaw(
	// PFE_EXPORT_FUNC pfExportCallback, PVOID pvCallbackContext, PVOID pvContext );
	[DllImport(Lib.AdvApi32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("winbase.h", MSDNShortId = "15f6f617-969d-4a40-9038-b902a3c2518b")]
	public static extern Win32Error ReadEncryptedFileRaw(ExportCallback pfExportCallback, IntPtr pvCallbackContext, EncryptedFileContext pvContext);

	/// <summary>
	/// <para>The <c>SetFileSecurity</c> function sets the security of a file or directory object.</para>
	/// <para>This function is obsolete. Use the SetNamedSecurityInfo function instead.</para>
	/// </summary>
	/// <param name="lpFileName">
	/// A pointer to a null-terminated string that specifies the file or directory for which security is set. Note that security applied
	/// to a directory is not inherited by its children.
	/// </param>
	/// <param name="SecurityInformation">
	/// Specifies a SECURITY_INFORMATION structure that identifies the contents of the security descriptor pointed to by the
	/// pSecurityDescriptor parameter.
	/// </param>
	/// <param name="pSecurityDescriptor">A pointer to a SECURITY_DESCRIPTOR structure.</param>
	/// <returns>
	/// <para>If the function succeeds, the function returns nonzero.</para>
	/// <para>If the function fails, it returns zero. To get extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>The <c>SetFileSecurity</c> function is successful only if the following conditions are met:</remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winbase/nf-winbase-setfilesecuritya BOOL SetFileSecurityA( LPCSTR lpFileName,
	// SECURITY_INFORMATION SecurityInformation, PSECURITY_DESCRIPTOR pSecurityDescriptor );
	[DllImport(Lib.AdvApi32, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("winbase.h", MSDNShortId = "27766c97-7ac5-40fc-b798-7cd07e496c0d")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SetFileSecurity(string lpFileName, SECURITY_INFORMATION SecurityInformation, PSECURITY_DESCRIPTOR pSecurityDescriptor);

	/// <summary>
	/// Restores (import) encrypted files. This is one of a group of Encrypted File System (EFS) functions that is intended to implement
	/// backup and restore functionality, while maintaining files in their encrypted state.
	/// </summary>
	/// <param name="pfImportCallback">
	/// A pointer to the import callback function. The system calls the callback function multiple times, each time passing a buffer that
	/// will be filled by the callback function with a portion of backed-up file's data. When the callback function signals that the
	/// entire file has been processed, it tells the system that the restore operation is finished. For more information, see ImportCallback.
	/// </param>
	/// <param name="pvCallbackContext">
	/// A pointer to an application-defined and allocated context block. The system passes this pointer to the callback function as a
	/// parameter so that the callback function can have access to application-specific data. This can be a structure and can contain any
	/// data the application needs, such as the handle to the file that will contain the backup copy of the encrypted file.
	/// </param>
	/// <param name="pvContext">
	/// A pointer to a system-defined context block. The context block is returned by the OpenEncryptedFileRaw function. Do not modify it.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is <c>ERROR_SUCCESS</c>.</para>
	/// <para>
	/// If the function fails, it returns a nonzero error code defined in WinError.h. You can use FormatMessage with the
	/// <c>FORMAT_MESSAGE_FROM_SYSTEM</c> flag to get a generic text description of the error.
	/// </para>
	/// </returns>
	/// <remarks>
	/// <para>The file being restored is not decrypted; it is restored in its encrypted state.</para>
	/// <para>
	/// To back up an encrypted file, call OpenEncryptedFileRaw to open the file. Then call ReadEncryptedFileRaw, passing it the address
	/// of an application-defined export callback function. The system calls this callback function multiple times until the entire
	/// file's contents have been read and backed up. When the backup is complete, call CloseEncryptedFileRaw to free resources and close
	/// the file. See ExportCallback for details about how to declare the export callback function.
	/// </para>
	/// <para>
	/// To restore an encrypted file, call OpenEncryptedFileRaw, specifying <c>CREATE_FOR_IMPORT</c> in the ulFlags parameter. Then call
	/// <c>WriteEncryptedFileRaw</c>, passing it the address of an application-defined import callback function. The system calls this
	/// callback function multiple times until the entire file's contents have been read and restored. When the restore is complete, call
	/// CloseEncryptedFileRaw to free resources and close the file. See ImportCallback for details about how to declare the export
	/// callback function.
	/// </para>
	/// <para>
	/// If the file is a sparse file that was backed up from a volume with a smaller sparse allocation unit size than the volume it is
	/// being restored to, the sparse blocks in the middle of the file may not properly align with the larger blocks and the function
	/// call would fail and set an <c>ERROR_INVALID_PARAMETER</c> last error code. The sparse allocation unit size is either 16 clusters
	/// or 64 KB, whichever is smaller.
	/// </para>
	/// <para>This function is intended for restoring only encrypted files; see BackupWrite for restoring unencrypted files.</para>
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
	// https://docs.microsoft.com/en-us/windows/desktop/api/winbase/nf-winbase-writeencryptedfileraw DWORD WriteEncryptedFileRaw(
	// PFE_IMPORT_FUNC pfImportCallback, PVOID pvCallbackContext, PVOID pvContext );
	[DllImport(Lib.AdvApi32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("winbase.h", MSDNShortId = "f44e291e-dbc6-4a44-92ba-92a81e043764")]
	public static extern Win32Error WriteEncryptedFileRaw(ImportCallback pfImportCallback, IntPtr pvCallbackContext, EncryptedFileContext pvContext);

	/// <summary>
	/// <para>
	/// Creates a new process and its primary thread. Then the new process runs the specified executable file in the security context of
	/// the specified credentials (user, domain, and password). It can optionally load the user profile for a specified user.
	/// </para>
	/// <para>
	/// This function is similar to the CreateProcessAsUser and CreateProcessWithTokenW functions, except that the caller does not need
	/// to call the LogonUser function to authenticate the user and get a token.
	/// </para>
	/// </summary>
	/// <param name="lpUsername">
	/// <para>
	/// The name of the user. This is the name of the user account to log on to. If you use the UPN format, user@DNS_domain_name, the
	/// lpDomain parameter must be NULL.
	/// </para>
	/// <para>
	/// The user account must have the Log On Locally permission on the local computer. This permission is granted to all users on
	/// workstations and servers, but only to administrators on domain controllers.
	/// </para>
	/// </param>
	/// <param name="lpDomain">
	/// The name of the domain or server whose account database contains the lpUsername account. If this parameter is NULL, the user name
	/// must be specified in UPN format.
	/// </param>
	/// <param name="lpPassword">The clear-text password for the lpUsername account.</param>
	/// <param name="dwLogonFlags">The logon option. This parameter can be 0 (zero) or one of the following values.</param>
	/// <param name="lpApplicationName">
	/// <para>
	/// The name of the module to be executed. This module can be a Windows-based application. It can be some other type of module (for
	/// example, MS-DOS or OS/2) if the appropriate subsystem is available on the local computer.
	/// </para>
	/// <para>
	/// The string can specify the full path and file name of the module to execute or it can specify a partial name. If it is a partial
	/// name, the function uses the current drive and current directory to complete the specification. The function does not use the
	/// search path. This parameter must include the file name extension; no default extension is assumed.
	/// </para>
	/// <para>
	/// The lpApplicationName parameter can be NULL, and the module name must be the first white space–delimited token in the
	/// lpCommandLine string. If you are using a long file name that contains a space, use quoted strings to indicate where the file name
	/// ends and the arguments begin; otherwise, the file name is ambiguous.
	/// </para>
	/// <para>For example, the following string can be interpreted in different ways:</para>
	/// <para>"c:\program files\sub dir\program name"</para>
	/// <para>The system tries to interpret the possibilities in the following order:</para>
	/// <list type="number">
	/// <item>
	/// <term><c>c:\program.exe</c> files\sub dir\program name</term>
	/// </item>
	/// <item>
	/// <term><c>c:\program files\sub.exe</c> dir\program name</term>
	/// </item>
	/// <item>
	/// <term><c>c:\program files\sub dir\program.exe</c> name</term>
	/// </item>
	/// <item>
	/// <term><c>c:\program files\sub dir\program name.exe</c></term>
	/// </item>
	/// </list>
	/// <para>
	/// If the executable module is a 16-bit application, lpApplicationName should be NULL, and the string pointed to by lpCommandLine
	/// should specify the executable module and its arguments.
	/// </para>
	/// </param>
	/// <param name="lpCommandLine">
	/// <para>
	/// The command line to be executed. The maximum length of this string is 1024 characters. If lpApplicationName is <c>NULL</c>, the
	/// module name portion of lpCommandLine is limited to <c>MAX_PATH</c> characters.
	/// </para>
	/// <para>
	/// The function can modify the contents of this string. Therefore, this parameter cannot be a pointer to read-only memory (such as a
	/// <c>const</c> variable or a literal string). If this parameter is a constant string, the function may cause an access violation.
	/// </para>
	/// <para>
	/// The lpCommandLine parameter can be <c>NULL</c>, and the function uses the string pointed to by lpApplicationName as the command line.
	/// </para>
	/// <para>
	/// If both lpApplicationName and lpCommandLine are non- <c>NULL</c>, *lpApplicationName specifies the module to execute, and
	/// *lpCommandLine specifies the command line. The new process can use GetCommandLine to retrieve the entire command line. Console
	/// processes written in C can use the argc and argv arguments to parse the command line. Because argv[0] is the module name, C
	/// programmers typically repeat the module name as the first token in the command line.
	/// </para>
	/// <para>
	/// If lpApplicationName is <c>NULL</c>, the first white space–delimited token of the command line specifies the module name. If you
	/// are using a long file name that contains a space, use quoted strings to indicate where the file name ends and the arguments begin
	/// (see the explanation for the lpApplicationName parameter). If the file name does not contain an extension, .exe is appended.
	/// Therefore, if the file name extension is .com, this parameter must include the .com extension. If the file name ends in a period
	/// with no extension, or if the file name contains a path, .exe is not appended. If the file name does not contain a directory path,
	/// the system searches for the executable file in the following sequence:
	/// </para>
	/// <list type="number">
	/// <item>
	/// <term>The directory from which the application loaded.</term>
	/// </item>
	/// <item>
	/// <term>The current directory for the parent process.</term>
	/// </item>
	/// <item>
	/// <term>The 32-bit Windows system directory. Use the GetSystemDirectory function to get the path of this directory.</term>
	/// </item>
	/// <item>
	/// <term>The 16-bit Windows system directory. There is no function that obtains the path of this directory, but it is searched.</term>
	/// </item>
	/// <item>
	/// <term>The Windows directory. Use the GetWindowsDirectory function to get the path of this directory.</term>
	/// </item>
	/// <item>
	/// <term>
	/// The directories that are listed in the PATH environment variable. Note that this function does not search the per-application
	/// path specified by the <c>App Paths</c> registry key. To include this per-application path in the search sequence, use the
	/// ShellExecute function.
	/// </term>
	/// </item>
	/// </list>
	/// <para>
	/// The system adds a null character to the command line string to separate the file name from the arguments. This divides the
	/// original string into two strings for internal processing.
	/// </para>
	/// </param>
	/// <param name="dwCreationFlags">
	/// <para>
	/// The flags that control how the process is created. The <c>CREATE_DEFAULT_ERROR_MODE</c>, <c>CREATE_NEW_CONSOLE</c>, and
	/// <c>CREATE_NEW_PROCESS_GROUP</c> flags are enabled by default— even if you do not set the flag, the system functions as if it were
	/// set. You can specify additional flags as noted.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>CREATE_DEFAULT_ERROR_MODE 0x04000000</term>
	/// <term>
	/// The new process does not inherit the error mode of the calling process. Instead, CreateProcessWithLogonW gives the new process
	/// the current default error mode. An application sets the current default error mode by calling SetErrorMode. This flag is enabled
	/// by default.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CREATE_NEW_CONSOLE 0x00000010</term>
	/// <term>
	/// The new process has a new console, instead of inheriting the parent's console. This flag cannot be used with the DETACHED_PROCESS
	/// flag. This flag is enabled by default.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CREATE_NEW_PROCESS_GROUP 0x00000200</term>
	/// <term>
	/// The new process is the root process of a new process group. The process group includes all processes that are descendants of this
	/// root process. The process identifier of the new process group is the same as the process identifier, which is returned in the
	/// lpProcessInfo parameter. Process groups are used by the GenerateConsoleCtrlEvent function to enable sending a CTRL+C or
	/// CTRL+BREAK signal to a group of console processes. This flag is enabled by default.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CREATE_SEPARATE_WOW_VDM 0x00000800</term>
	/// <term>
	/// This flag is only valid starting a 16-bit Windows-based application. If set, the new process runs in a private Virtual DOS
	/// Machine (VDM). By default, all 16-bit Windows-based applications run in a single, shared VDM. The advantage of running separately
	/// is that a crash only terminates the single VDM; any other programs running in distinct VDMs continue to function normally. Also,
	/// 16-bit Windows-based applications that run in separate VDMs have separate input queues, which means that if one application stops
	/// responding momentarily, applications in separate VDMs continue to receive input.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CREATE_SUSPENDED 0x00000004</term>
	/// <term>
	/// The primary thread of the new process is created in a suspended state, and does not run until the ResumeThread function is called.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CREATE_UNICODE_ENVIRONMENT 0x00000400</term>
	/// <term>
	/// Indicates the format of the lpEnvironment parameter. If this flag is set, the environment block pointed to by lpEnvironment uses
	/// Unicode characters. Otherwise, the environment block uses ANSI characters.
	/// </term>
	/// </item>
	/// </list>
	/// <para>
	/// This parameter also controls the new process's priority class, which is used to determine the scheduling priorities of the
	/// process's threads. For a list of values, see GetPriorityClass. If none of the priority class flags is specified, the priority
	/// class defaults to <c>NORMAL_PRIORITY_CLASS</c> unless the priority class of the creating process is <c>IDLE_PRIORITY_CLASS</c> or
	/// <c>BELOW_NORMAL_PRIORITY_CLASS</c>. In this case, the child process receives the default priority class of the calling process.
	/// </para>
	/// </param>
	/// <param name="lpEnvironment">
	/// <para>
	/// A pointer to an environment block for the new process. If this parameter is <c>NULL</c>, the new process uses an environment
	/// created from the profile of the user specified by lpUsername.
	/// </para>
	/// <para>An environment block consists of a null-terminated block of null-terminated strings. Each string is in the following form:</para>
	/// <para>name=value</para>
	/// <para>Because the equal sign (=) is used as a separator, it must not be used in the name of an environment variable.</para>
	/// <para>
	/// An environment block can contain Unicode or ANSI characters. If the environment block pointed to by lpEnvironment contains
	/// Unicode characters, ensure that dwCreationFlags includes <c>CREATE_UNICODE_ENVIRONMENT</c>. If this parameter is NULL and the
	/// environment block of the parent process contains Unicode characters, you must also ensure that dwCreationFlags includes <c>CREATE_UNICODE_ENVIRONMENT</c>.
	/// </para>
	/// <para>
	/// An ANSI environment block is terminated by two 0 (zero) bytes: one for the last string and one more to terminate the block. A
	/// Unicode environment block is terminated by four zero bytes: two for the last string and two more to terminate the block.
	/// </para>
	/// <para>To retrieve a copy of the environment block for a specific user, use the CreateEnvironmentBlock function.</para>
	/// </param>
	/// <param name="lpCurrentDirectory">
	/// <para>The full path to the current directory for the process. The string can also specify a UNC path.</para>
	/// <para>
	/// If this parameter is <c>NULL</c>, the new process has the same current drive and directory as the calling process. This feature
	/// is provided primarily for shells that need to start an application, and specify its initial drive and working directory.
	/// </para>
	/// </param>
	/// <param name="lpStartupInfo">
	/// <para>A pointer to a STARTUPINFO structure.</para>
	/// <para>
	/// The application must add permission for the specified user account to the specified window station and desktop, even for WinSta0\Default.
	/// </para>
	/// <para>
	/// If the <c>lpDesktop</c> member is <c>NULL</c> or an empty string, the new process inherits the desktop and window station of its
	/// parent process. The application must add permission for the specified user account to the inherited window station and desktop.
	/// </para>
	/// <para>
	/// <c>Windows XP:</c><c>CreateProcessWithLogonW</c> adds permission for the specified user account to the inherited window station
	/// and desktop.
	/// </para>
	/// <para>Handles in STARTUPINFO must be closed with CloseHandle when they are no longer needed.</para>
	/// <para>
	/// <c>Important</c> If the <c>dwFlags</c> member of the STARTUPINFO structure specifies <c>STARTF_USESTDHANDLES</c>, the standard
	/// handle fields are copied unchanged to the child process without validation. The caller is responsible for ensuring that these
	/// fields contain valid handle values. Incorrect values can cause the child process to misbehave or crash. Use the Application
	/// Verifier runtime verification tool to detect invalid handles.
	/// </para>
	/// </param>
	/// <param name="lpProcessInformation">
	/// <para>
	/// A pointer to a PROCESS_INFORMATION structure that receives identification information for the new process, including a handle to
	/// the process.
	/// </para>
	/// <para>Handles in PROCESS_INFORMATION must be closed with the CloseHandle function when they are not needed.</para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is 0 (zero). To get extended error information, call GetLastError.</para>
	/// <para>
	/// Note that the function returns before the process has finished initialization. If a required DLL cannot be located or fails to
	/// initialize, the process is terminated. To get the termination status of a process, call GetExitCodeProcess.
	/// </para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// By default, <c>CreateProcessWithLogonW</c> does not load the specified user profile into the <c>HKEY_USERS</c> registry key. This
	/// means that access to information in the <c>HKEY_CURRENT_USER</c> registry key may not produce results that are consistent with a
	/// normal interactive logon. It is your responsibility to load the user registry hive into <c>HKEY_USERS</c> before calling
	/// <c>CreateProcessWithLogonW</c>, by using <c>LOGON_WITH_PROFILE</c>, or by calling the LoadUserProfile function.
	/// </para>
	/// <para>
	/// If the lpEnvironment parameter is NULL, the new process uses an environment block created from the profile of the user specified
	/// by lpUserName. If the HOMEDRIVE and HOMEPATH variables are not set, <c>CreateProcessWithLogonW</c> modifies the environment block
	/// to use the drive and path of the user's working directory.
	/// </para>
	/// <para>
	/// When created, the new process and thread handles receive full access rights ( <c>PROCESS_ALL_ACCESS</c> and
	/// <c>THREAD_ALL_ACCESS</c>). For either handle, if a security descriptor is not provided, the handle can be used in any function
	/// that requires an object handle of that type. When a security descriptor is provided, an access check is performed on all
	/// subsequent uses of the handle before access is granted. If access is denied, the requesting process cannot use the handle to gain
	/// access to the process or thread.
	/// </para>
	/// <para>To retrieve a security token, pass the process handle in the PROCESS_INFORMATION structure to the OpenProcessToken function.</para>
	/// <para>
	/// The process is assigned a process identifier. The identifier is valid until the process terminates. It can be used to identify
	/// the process, or it can be specified in the OpenProcess function to open a handle to the process. The initial thread in the
	/// process is also assigned a thread identifier. It can be specified in the OpenThread function to open a handle to the thread. The
	/// identifier is valid until the thread terminates and can be used to uniquely identify the thread within the system. These
	/// identifiers are returned in PROCESS_INFORMATION.
	/// </para>
	/// <para>
	/// The calling thread can use the WaitForInputIdle function to wait until the new process has completed its initialization and is
	/// waiting for user input with no input pending. This can be useful for synchronization between parent and child processes, because
	/// <c>CreateProcessWithLogonW</c> returns without waiting for the new process to finish its initialization. For example, the
	/// creating process would use <c>WaitForInputIdle</c> before trying to find a window that is associated with the new process.
	/// </para>
	/// <para>
	/// The preferred way to shut down a process is by using the ExitProcess function, because this function sends notification of
	/// approaching termination to all DLLs attached to the process. Other means of shutting down a process do not notify the attached
	/// DLLs. Note that when a thread calls <c>ExitProcess</c>, other threads of the process are terminated without an opportunity to
	/// execute any additional code (including the thread termination code of attached DLLs). For more information, see Terminating a Process.
	/// </para>
	/// <para>
	/// <c>CreateProcessWithLogonW</c> accesses the specified directory and executable image in the security context of the target user.
	/// If the executable image is on a network and a network drive letter is specified in the path, the network drive letter is not
	/// available to the target user, as network drive letters can be assigned for each logon. If a network drive letter is specified,
	/// this function fails. If the executable image is on a network, use the UNC path.
	/// </para>
	/// <para>
	/// There is a limit to the number of child processes that can be created by this function and run simultaneously. For example, on
	/// Windows XP, this limit is <c>MAXIMUM_WAIT_OBJECTS</c>*4. However, you may not be able to create this many processes due to
	/// system-wide quota limits.
	/// </para>
	/// <para>
	/// <c>Windows XP with SP2,Windows Server 2003, or later:</c> You cannot call <c>CreateProcessWithLogonW</c> from a process that is
	/// running under the "LocalSystem" account, because the function uses the logon SID in the caller token, and the token for the
	/// "LocalSystem" account does not contain this SID. As an alternative, use the CreateProcessAsUser and LogonUser functions.
	/// </para>
	/// <para>
	/// To compile an application that uses this function, define <c>_WIN32_WINNT</c> as 0x0500 or later. For more information, see Using
	/// the Windows Headers.
	/// </para>
	/// <para>Security Remarks</para>
	/// <para>
	/// The lpApplicationName parameter can be <c>NULL</c>, and the executable name must be the first white space–delimited string in
	/// lpCommandLine. If the executable or path name has a space in it, there is a risk that a different executable could be run because
	/// of the way the function parses spaces. Avoid the following example, because the function attempts to run "Program.exe", if it
	/// exists, instead of "MyApp.exe".
	/// </para>
	/// <para>
	/// If a malicious user creates an application called "Program.exe" on a system, any program that incorrectly calls
	/// <c>CreateProcessWithLogonW</c> using the Program Files directory runs the malicious user application instead of the intended application.
	/// </para>
	/// <para>
	/// To avoid this issue, do not pass <c>NULL</c> for lpApplicationName. If you pass <c>NULL</c> for lpApplicationName, use quotation
	/// marks around the executable path in lpCommandLine, as shown in the following example:
	/// </para>
	/// <para>Examples</para>
	/// <para>The following example demonstrates how to call this function.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winbase/nf-winbase-createprocesswithlogonw BOOL CreateProcessWithLogonW(
	// LPCWSTR lpUsername, LPCWSTR lpDomain, LPCWSTR lpPassword, DWORD dwLogonFlags, LPCWSTR lpApplicationName, StrPtrUni lpCommandLine,
	// DWORD dwCreationFlags, LPVOID lpEnvironment, LPCWSTR lpCurrentDirectory, LPSTARTUPINFOW lpStartupInfo, LPPROCESS_INFORMATION
	// lpProcessInformation );
	[DllImport(Lib.AdvApi32, SetLastError = true, ExactSpelling = true, CharSet = CharSet.Unicode)]
	[PInvokeData("winbase.h", MSDNShortId = "dcfdcd5b-0269-4081-b1db-e272171c27a2")]
	[return: MarshalAs(UnmanagedType.Bool)]
	private static extern bool CreateProcessWithLogonW(string lpUsername, [Optional] string? lpDomain, string lpPassword, ProcessLogonFlags dwLogonFlags,
		[Optional] string? lpApplicationName, [Optional] StringBuilder? lpCommandLine, CREATE_PROCESS dwCreationFlags,
		[In, Optional, MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(NullTermStringArrayMarshaler), MarshalCookie = "Auto")] string[]? lpEnvironment,
		[Optional] string? lpCurrentDirectory, in STARTUPINFO lpStartupInfo, out PROCESS_INFORMATION lpProcessInformation);

	/// <summary>
	/// <para>
	/// Creates a new process and its primary thread. The new process runs in the security context of the specified token. It can
	/// optionally load the user profile for the specified user.
	/// </para>
	/// <para>
	/// The process that calls <c>CreateProcessWithTokenW</c> must have the SE_IMPERSONATE_NAME privilege. If this function fails with
	/// ERROR_PRIVILEGE_NOT_HELD (1314), use the CreateProcessAsUser or CreateProcessWithLogonW function instead. Typically, the process
	/// that calls <c>CreateProcessAsUser</c> must have the SE_INCREASE_QUOTA_NAME privilege and may require the
	/// SE_ASSIGNPRIMARYTOKEN_NAME privilege if the token is not assignable. <c>CreateProcessWithLogonW</c> requires no special
	/// privileges, but the specified user account must be allowed to log on interactively. Generally, it is best to use
	/// <c>CreateProcessWithLogonW</c> to create a process with alternate credentials.
	/// </para>
	/// </summary>
	/// <param name="hToken">
	/// <para>
	/// A handle to the primary token that represents a user. The handle must have the TOKEN_QUERY, TOKEN_DUPLICATE, and
	/// TOKEN_ASSIGN_PRIMARY access rights. For more information, see Access Rights for Access-Token Objects. The user represented by the
	/// token must have read and execute access to the application specified by the lpApplicationName or the lpCommandLine parameter.
	/// </para>
	/// <para>
	/// To get a primary token that represents the specified user, call the LogonUser function. Alternatively, you can call the
	/// DuplicateTokenEx function to convert an impersonation token into a primary token. This allows a server application that is
	/// impersonating a client to create a process that has the security context of the client.
	/// </para>
	/// <para>
	/// <c>Terminal Services:</c> The process is run in the session specified in the token. By default, this is the same session that
	/// called LogonUser. To change the session, use the SetTokenInformation function.
	/// </para>
	/// </param>
	/// <param name="dwLogonFlags">The logon option. This parameter can be zero or one of the following values.</param>
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
	/// The lpApplicationName parameter can be NULL. In that case, the module name must be the first white space–delimited token in the
	/// lpCommandLine string. If you are using a long file name that contains a space, use quoted strings to indicate where the file name
	/// ends and the arguments begin; otherwise, the file name is ambiguous. For example, consider the string "c:\program files\sub
	/// dir\program name". This string can be interpreted in a number of ways. The system tries to interpret the possibilities in the
	/// following order:
	/// </para>
	/// <para>
	/// <c>c:\program.exe</c><c>c:\program files\sub.exe</c><c>c:\program files\sub dir\program.exe</c><c>c:\program files\sub
	/// dir\program name.exe</c> If the executable module is a 16-bit application, lpApplicationName should be NULL, and the string
	/// pointed to by lpCommandLine should specify the executable module as well as its arguments.
	/// </para>
	/// </param>
	/// <param name="lpCommandLine">
	/// <para>The command line to be executed.</para>
	/// <para>
	/// The maximum length of this string is 1024 characters. If lpApplicationName is NULL, the module name portion of lpCommandLine is
	/// limited to MAX_PATH characters.
	/// </para>
	/// <para>
	/// The function can modify the contents of this string. Therefore, this parameter cannot be a pointer to read-only memory (such as a
	/// <c>const</c> variable or a literal string). If this parameter is a constant string, the function may cause an access violation.
	/// </para>
	/// <para>
	/// The lpCommandLine parameter can be NULL. In that case, the function uses the string pointed to by lpApplicationName as the
	/// command line.
	/// </para>
	/// <para>
	/// If both lpApplicationName and lpCommandLine are non-NULL, *lpApplicationName specifies the module to execute, and *lpCommandLine
	/// specifies the command line. The new process can use GetCommandLine to retrieve the entire command line. Console processes written
	/// in C can use the argc and argv arguments to parse the command line. Because argv[0] is the module name, C programmers generally
	/// repeat the module name as the first token in the command line.
	/// </para>
	/// <para>
	/// If lpApplicationName is NULL, the first white space–delimited token of the command line specifies the module name. If you are
	/// using a long file name that contains a space, use quoted strings to indicate where the file name ends and the arguments begin
	/// (see the explanation for the lpApplicationName parameter). If the file name does not contain an extension, .exe is appended.
	/// Therefore, if the file name extension is .com, this parameter must include the .com extension. If the file name ends in a period
	/// (.) with no extension, or if the file name contains a path, .exe is not appended. If the file name does not contain a directory
	/// path, the system searches for the executable file in the following sequence:
	/// </para>
	/// <list type="number">
	/// <item>
	/// <term>The directory from which the application loaded.</term>
	/// </item>
	/// <item>
	/// <term>The current directory for the parent process.</term>
	/// </item>
	/// <item>
	/// <term>The 32-bit Windows system directory. Use the GetSystemDirectory function to get the path of this directory.</term>
	/// </item>
	/// <item>
	/// <term>The 16-bit Windows system directory. There is no function that obtains the path of this directory, but it is searched.</term>
	/// </item>
	/// <item>
	/// <term>The Windows directory. Use the GetWindowsDirectory function to get the path of this directory.</term>
	/// </item>
	/// <item>
	/// <term>
	/// The directories that are listed in the PATH environment variable. Note that this function does not search the per-application
	/// path specified by the <c>App Paths</c> registry key. To include this per-application path in the search sequence, use the
	/// ShellExecute function.
	/// </term>
	/// </item>
	/// </list>
	/// <para>
	/// The system adds a null character to the command line string to separate the file name from the arguments. This divides the
	/// original string into two strings for internal processing.
	/// </para>
	/// </param>
	/// <param name="dwCreationFlags">
	/// <para>
	/// The flags that control how the process is created. The CREATE_DEFAULT_ERROR_MODE, CREATE_NEW_CONSOLE, and
	/// CREATE_NEW_PROCESS_GROUP flags are enabled by default. You can specify additional flags as noted.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>CREATE_DEFAULT_ERROR_MODE 0x04000000</term>
	/// <term>
	/// The new process does not inherit the error mode of the calling process. Instead, the new process gets the current default error
	/// mode. An application sets the current default error mode by calling SetErrorMode. This flag is enabled by default.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CREATE_NEW_CONSOLE 0x00000010</term>
	/// <term>
	/// The new process has a new console, instead of inheriting the parent's console. This flag cannot be used with the DETACHED_PROCESS
	/// flag. This flag is enabled by default.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CREATE_NEW_PROCESS_GROUP 0x00000200</term>
	/// <term>
	/// The new process is the root process of a new process group. The process group includes all processes that are descendants of this
	/// root process. The process identifier of the new process group is the same as the process identifier, which is returned in the
	/// lpProcessInfo parameter. Process groups are used by the GenerateConsoleCtrlEvent function to enable sending a CTRL+C or
	/// CTRL+BREAK signal to a group of console processes. This flag is enabled by default.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CREATE_SEPARATE_WOW_VDM 0x00000800</term>
	/// <term>
	/// This flag is only valid starting a 16-bit Windows-based application. If set, the new process runs in a private Virtual DOS
	/// Machine (VDM). By default, all 16-bit Windows-based applications run in a single, shared VDM. The advantage of running separately
	/// is that a crash only terminates the single VDM; any other programs running in distinct VDMs continue to function normally. Also,
	/// 16-bit Windows-based applications that run in separate VDMs have separate input queues. That means that if one application stops
	/// responding momentarily, applications in separate VDMs continue to receive input.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CREATE_SUSPENDED 0x00000004</term>
	/// <term>
	/// The primary thread of the new process is created in a suspended state, and does not run until the ResumeThread function is called.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CREATE_UNICODE_ENVIRONMENT 0x00000400</term>
	/// <term>
	/// Indicates the format of the lpEnvironment parameter. If this flag is set, the environment block pointed to by lpEnvironment uses
	/// Unicode characters. Otherwise, the environment block uses ANSI characters.
	/// </term>
	/// </item>
	/// <item>
	/// <term>EXTENDED_STARTUPINFO_PRESENT 0x00080000</term>
	/// <term>
	/// The process is created with extended startup information; the lpStartupInfo parameter specifies a STARTUPINFOEX structure.
	/// Windows Server 2003: This value is not supported.
	/// </term>
	/// </item>
	/// </list>
	/// <para>
	/// This parameter also controls the new process's priority class, which is used to determine the scheduling priorities of the
	/// process's threads. For a list of values, see GetPriorityClass. If none of the priority class flags is specified, the priority
	/// class defaults to NORMAL_PRIORITY_CLASS unless the priority class of the creating process is IDLE_PRIORITY_CLASS or
	/// BELOW_NORMAL_PRIORITY_CLASS. In this case, the child process receives the default priority class of the calling process.
	/// </para>
	/// </param>
	/// <param name="lpEnvironment">
	/// <para>
	/// A pointer to an environment block for the new process. If this parameter is NULL, the new process uses an environment created
	/// from the profile of the user specified by lpUsername.
	/// </para>
	/// <para>An environment block consists of a null-terminated block of null-terminated strings. Each string is in the following form:</para>
	/// <para>name=value</para>
	/// <para>Because the equal sign (=) is used as a separator, it must not be used in the name of an environment variable.</para>
	/// <para>
	/// An environment block can contain Unicode or ANSI characters. If the environment block pointed to by lpEnvironment contains
	/// Unicode characters, be sure that dwCreationFlags includes CREATE_UNICODE_ENVIRONMENT. If this parameter is NULL and the
	/// environment block of the parent process contains Unicode characters, you must also ensure that dwCreationFlags includes CREATE_UNICODE_ENVIRONMENT.
	/// </para>
	/// <para>
	/// An ANSI environment block is terminated by two zero bytes: one for the last string, one more to terminate the block. A Unicode
	/// environment block is terminated by four zero bytes: two for the last string and two more to terminate the block.
	/// </para>
	/// <para>To retrieve a copy of the environment block for a specific user, use the CreateEnvironmentBlock function.</para>
	/// </param>
	/// <param name="lpCurrentDirectory">
	/// <para>The full path to the current directory for the process. The string can also specify a UNC path.</para>
	/// <para>
	/// If this parameter is NULL, the new process will have the same current drive and directory as the calling process. (This feature
	/// is provided primarily for shells that need to start an application and specify its initial drive and working directory.)
	/// </para>
	/// </param>
	/// <param name="lpStartupInfo">
	/// <para>A pointer to a STARTUPINFO or STARTUPINFOEX structure.</para>
	/// <para>
	/// If the <c>lpDesktop</c> member is NULL or an empty string, the new process inherits the desktop and window station of its parent
	/// process. The function adds permission for the specified user account to the inherited window station and desktop. Otherwise, if
	/// this member specifies a desktop, it is the responsibility of the application to add permission for the specified user account to
	/// the specified window station and desktop, even for WinSta0\Default.
	/// </para>
	/// <para>Handles in STARTUPINFO or STARTUPINFOEX must be closed with CloseHandle when they are no longer needed.</para>
	/// <para>
	/// <c>Important</c> If the <c>dwFlags</c> member of the STARTUPINFO structure specifies <c>STARTF_USESTDHANDLES</c>, the standard
	/// handle fields are copied unchanged to the child process without validation. The caller is responsible for ensuring that these
	/// fields contain valid handle values. Incorrect values can cause the child process to misbehave or crash. Use the Application
	/// Verifier runtime verification tool to detect invalid handles.
	/// </para>
	/// </param>
	/// <param name="lpProcessInformation">
	/// <para>
	/// A pointer to a PROCESS_INFORMATION structure that receives identification information for the new process, including a handle to
	/// the process.
	/// </para>
	/// <para>Handles in PROCESS_INFORMATION must be closed with the CloseHandle function when they are no longer needed.</para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
	/// <para>
	/// Note that the function returns before the process has finished initialization. If a required DLL cannot be located or fails to
	/// initialize, the process is terminated. To get the termination status of a process, call GetExitCodeProcess.
	/// </para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// By default, <c>CreateProcessWithTokenW</c> does not load the specified user's profile into the <c>HKEY_USERS</c> registry key.
	/// This means that access to information in the <c>HKEY_CURRENT_USER</c> registry key may not produce results consistent with a
	/// normal interactive logon. It is your responsibility to load the user's registry hive into <c>HKEY_USERS</c> by either using
	/// LOGON_WITH_PROFILE, or by calling the LoadUserProfile function before calling this function.
	/// </para>
	/// <para>
	/// If the lpEnvironment parameter is NULL, the new process uses an environment block created from the profile of the user specified
	/// by lpUserName. If the HOMEDRIVE and HOMEPATH variables are not set, <c>CreateProcessWithTokenW</c> modifies the environment block
	/// to use the drive and path of the user's working directory.
	/// </para>
	/// <para>
	/// When created, the new process and thread handles receive full access rights (PROCESS_ALL_ACCESS and THREAD_ALL_ACCESS). For
	/// either handle, if a security descriptor is not provided, the handle can be used in any function that requires an object handle of
	/// that type. When a security descriptor is provided, an access check is performed on all subsequent uses of the handle before
	/// access is granted. If access is denied, the requesting process cannot use the handle to gain access to the process or thread.
	/// </para>
	/// <para>To retrieve a security token, pass the process handle in the PROCESS_INFORMATION structure to the OpenProcessToken function.</para>
	/// <para>
	/// The process is assigned a process identifier. The identifier is valid until the process terminates. It can be used to identify
	/// the process, or specified in the OpenProcess function to open a handle to the process. The initial thread in the process is also
	/// assigned a thread identifier. It can be specified in the OpenThread function to open a handle to the thread. The identifier is
	/// valid until the thread terminates and can be used to uniquely identify the thread within the system. These identifiers are
	/// returned in PROCESS_INFORMATION.
	/// </para>
	/// <para>
	/// The calling thread can use the WaitForInputIdle function to wait until the new process has finished its initialization and is
	/// waiting for user input with no input pending. This can be useful for synchronization between parent and child processes, because
	/// <c>CreateProcessWithTokenW</c> returns without waiting for the new process to finish its initialization. For example, the
	/// creating process would use <c>WaitForInputIdle</c> before trying to find a window associated with the new process.
	/// </para>
	/// <para>
	/// The preferred way to shut down a process is by using the ExitProcess function, because this function sends notification of
	/// approaching termination to all DLLs attached to the process. Other means of shutting down a process do not notify the attached
	/// DLLs. Note that when a thread calls <c>ExitProcess</c>, other threads of the process are terminated without an opportunity to
	/// execute any additional code (including the thread termination code of attached DLLs). For more information, see Terminating a Process.
	/// </para>
	/// <para>
	/// To compile an application that uses this function, define _WIN32_WINNT as 0x0500 or later. For more information, see Using the
	/// Windows Headers.
	/// </para>
	/// <para>Security Remarks</para>
	/// <para>
	/// The lpApplicationName parameter can be NULL, in which case the executable name must be the first white space–delimited string in
	/// lpCommandLine. If the executable or path name has a space in it, there is a risk that a different executable could be run because
	/// of the way the function parses spaces. The following example is dangerous because the function will attempt to run "Program.exe",
	/// if it exists, instead of "MyApp.exe".
	/// </para>
	/// <para>
	/// If a malicious user were to create an application called "Program.exe" on a system, any program that incorrectly calls
	/// <c>CreateProcessWithTokenW</c> using the Program Files directory will run this application instead of the intended application.
	/// </para>
	/// <para>
	/// To avoid this problem, do not pass NULL for lpApplicationName. If you do pass NULL for lpApplicationName, use quotation marks
	/// around the executable path in lpCommandLine, as shown in the example below.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winbase/nf-winbase-createprocesswithtokenw BOOL CreateProcessWithTokenW(
	// HANDLE hToken, DWORD dwLogonFlags, LPCWSTR lpApplicationName, StrPtrUni lpCommandLine, DWORD dwCreationFlags, LPVOID lpEnvironment,
	// LPCWSTR lpCurrentDirectory, LPSTARTUPINFOW lpStartupInfo, LPPROCESS_INFORMATION lpProcessInformation );
	[DllImport(Lib.AdvApi32, SetLastError = true, ExactSpelling = true, CharSet = CharSet.Unicode)]
	[PInvokeData("winbase.h", MSDNShortId = "b329866a-0c0d-4cb3-838c-36aac17c87ed")]
	[return: MarshalAs(UnmanagedType.Bool)]
	private static extern bool CreateProcessWithTokenW(HTOKEN hToken, ProcessLogonFlags dwLogonFlags, string lpApplicationName, [Optional] StringBuilder? lpCommandLine, CREATE_PROCESS dwCreationFlags,
		[In, Optional, MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(NullTermStringArrayMarshaler), MarshalCookie = "Auto")] string[]? lpEnvironment,
		[Optional] string? lpCurrentDirectory, in STARTUPINFO lpStartupInfo, out PROCESS_INFORMATION lpProcessInformation);

	/// <summary>
	/// Contains information about a hardware profile. The GetCurrentHwProfile function uses this structure to retrieve the current
	/// hardware profile for the local computer.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winbase/ns-winbase-hw_profile_infow typedef struct tagHW_PROFILE_INFOW {
	// DWORD dwDockInfo; WCHAR szHwProfileGuid[HW_PROFILE_GUIDLEN]; WCHAR szHwProfileName[MAX_PROFILE_LEN]; } HW_PROFILE_INFOW, *LPHW_PROFILE_INFOW;
	[PInvokeData("winbase.h", MSDNShortId = "b1c8eb4c-8c62-4e3e-a7d2-0888512b3d4c")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	public struct HW_PROFILE_INFO
	{
		/// <summary>The reported docking state of the computer. This member can be a combination of the following bit values.</summary>
		public DOCKINFO dwDockInfo;

		/// <summary>
		/// <para>
		/// The globally unique identifier (GUID) string for the current hardware profile. The string returned by GetCurrentHwProfile
		/// encloses the GUID in curly braces, {}; for example:
		/// </para>
		/// <para>{12340001-4980-1920-6788-123456789012}</para>
		/// <para>
		/// You can use this string as a registry subkey under your application's configuration settings key in <c>HKEY_CURRENT_USER</c>.
		/// This enables you to store settings for each hardware profile.
		/// </para>
		/// </summary>
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 39)]
		public string szHwProfileGuid;

		/// <summary>The display name for the current hardware profile.</summary>
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 80)]
		public string szHwProfileName;
	}

	/// <summary>This structure is used by the OperationEnd function.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/winbase/ns-winbase-operation_end_parameters typedef struct
	// _OPERATION_END_PARAMETERS { ULONG Version; OPERATION_ID OperationId; ULONG Flags; } OPERATION_END_PARAMETERS, *POPERATION_END_PARAMETERS;
	[PInvokeData("winbase.h", MSDNShortId = "45ABFE6A-7B70-418F-8C3C-6388079D1306")]
	[StructLayout(LayoutKind.Sequential)]
	public struct OPERATION_END_PARAMETERS
	{
		/// <summary>
		/// <para>This parameter should be initialized to the <c>OPERATION_API_VERSION</c> defined in the Windows SDK.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>OPERATION_API_VERSION 1</term>
		/// <term>This API was introduced in Windows 8 and Windows Server 2012 as version 1.</term>
		/// </item>
		/// </list>
		/// </summary>
		public uint Version;

		/// <summary>
		/// Each operation has an OPERATION_ID namespace that is unique for each process. If two applications both use the same
		/// <c>OPERATION_ID</c> value to identify two operations, the system maintains separate contexts for each operation.
		/// </summary>
		public uint OperationId;

		/// <summary>
		/// <para>The value of this parameter can include any combination of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>OPERATION_END_DISCARD 1</term>
		/// <term>
		/// Specifies that the system should discard the information it has been tracking for this operation. Specify this flag when the
		/// operation either fails or does not follow the expected sequence of steps.
		/// </term>
		/// </item>
		/// </list>
		/// </summary>
		public uint Flags;

		/// <summary>Initializes a new instance of the <see cref="OPERATION_END_PARAMETERS"/> struct.</summary>
		/// <param name="opId">An OPERATION_ID namespace that is unique for each process.</param>
		/// <param name="singleThreadOnly">
		/// if set to <c>true</c> specifies that the system should discard the information it has been tracking for this operation.
		/// </param>
		public OPERATION_END_PARAMETERS(uint opId, bool singleThreadOnly = false)
		{
			Version = OPERATION_API_VERSION;
			OperationId = opId;
			Flags = singleThreadOnly ? 1U : 0U;
		}
	}

	/// <summary>This structure is used by the OperationStart function.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/winbase/ns-winbase-operation_start_parameters typedef struct
	// _OPERATION_START_PARAMETERS { ULONG Version; OPERATION_ID OperationId; ULONG Flags; } OPERATION_START_PARAMETERS, *POPERATION_START_PARAMETERS;
	[PInvokeData("winbase.h", MSDNShortId = "51AE0017-2CDE-4BCD-AE03-B366343DE558")]
	[StructLayout(LayoutKind.Sequential)]
	public struct OPERATION_START_PARAMETERS
	{
		/// <summary>
		/// <para>This parameter should be initialized to the <c>OPERATION_API_VERSION</c> value defined in the Windows SDK.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>OPERATION_API_VERSION 1</term>
		/// <term>This API was introduced in Windows 8 and Windows Server 2012 as version 1.</term>
		/// </item>
		/// </list>
		/// </summary>
		public uint Version;

		/// <summary>
		/// Each operation has an OPERATION_ID namespace that is unique for each process. If two applications both use the same
		/// <c>OPERATION_ID</c> value to identify two operations, the system maintains separate contexts for each operation.
		/// </summary>
		public uint OperationId;

		/// <summary>
		/// <para>The value of this parameter can include any combination of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>OPERATION_START_TRACE_CURRENT_THREAD 1</term>
		/// <term>
		/// Specifies that the system should only track the activities of the calling thread in a multi-threaded application. Specify
		/// this flag when the operation is performed on a single thread to isolate its activity from other threads in the process.
		/// </term>
		/// </item>
		/// </list>
		/// </summary>
		public uint Flags;

		/// <summary>Initializes a new instance of the <see cref="OPERATION_START_PARAMETERS"/> struct.</summary>
		/// <param name="opId">An OPERATION_ID namespace that is unique for each process.</param>
		/// <param name="singleThreadOnly">
		/// if set to <c>true</c> specifies that the system should only track the activities of the calling thread in a multi-threaded application.
		/// </param>
		public OPERATION_START_PARAMETERS(uint opId, bool singleThreadOnly = false)
		{
			Version = OPERATION_API_VERSION;
			OperationId = opId;
			Flags = singleThreadOnly ? 1U : 0U;
		}
	}
}