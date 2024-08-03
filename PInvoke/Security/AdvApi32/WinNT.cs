using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.AccessControl;
using static Vanara.PInvoke.Kernel32;

namespace Vanara.PInvoke;

public static partial class AdvApi32
{
	/// <summary/>
	public const uint SECURITY_DESCRIPTOR_REVISION = 1;
	/// <summary/>
	public const uint SECURITY_DESCRIPTOR_REVISION1 = 1;
	/// <summary/>
	public const int SID_MAX_SUB_AUTHORITIES = 15;
	/// <summary/>
	public const int SID_RECOMMENDED_SUB_AUTHORITIES = 1; // Will change to around 6
	/// <summary/>
	public const uint SID_REVISION = 1; // Current revision level

	private const int sizeofSID = 12;

	/// <summary>
	/// A CALLBACK ACE contains a conditional expression if the ApplicationData member is prefixed by ACE_CONDITION_SIGNATURE and the
	/// remainder of the data in the ApplicationData member immediately following the conditional ACE signature specifies a conditional
	/// expression.
	/// </summary>
	public static readonly byte[] ACE_CONDITION_SIGNATURE = [0x61, 0x72, 0x74, 0x78];

	/// <summary>The maximum size of a SID.</summary>
	public static readonly int SECURITY_MAX_SID_SIZE = SECURITY_SID_SIZE(SID_MAX_SUB_AUTHORITIES);

	/// <summary>Returns the number of bytes required for SID given the number of sub-authorities.</summary>
	/// <param name="SubAuthorityCount">The sub authority count.</param>
	/// <returns>The number of bytes required for ths SID.</returns>
	public static int SECURITY_SID_SIZE(int SubAuthorityCount) => sizeofSID + ((SubAuthorityCount - 1) * sizeof(uint));

	// 2 (S-)
	// 4 (Rev(max: 255)-)
	// 15 (
	//      If (Auth < 2^32): Auth(max:4294967295)-
	//      Else:             0xAuth(max:FFFFFFFFFFFF)-
	//    )
	// (11 * SID_MAX_SUB_AUTHORITIES) (SubN(max:4294967295)-)
	// 1 (NULL character)
	// = 187 (assuming SID_MAX_SUB_AUTHORITIES = 15)
	/// <summary>The maximum characters in a string representation of a SID.</summary>
	public const int SECURITY_MAX_SID_STRING_CHARACTERS = (2 + 4 + 15 + (11 * SID_MAX_SUB_AUTHORITIES) + 1);

	/// <summary>Specifies a set of ACE type-specific control flags.</summary>
	[PInvokeData("winnt.h")]
	[Flags]
	public enum ACE_FLAG : byte
	{
		/// <summary>
		/// Noncontainer child objects inherit the ACE as an effective ACE.
		/// <para>
		/// For child objects that are containers, the ACE is inherited as an inherit-only ACE unless the NO_PROPAGATE_INHERIT_ACE bit flag
		/// is also set.
		/// </para>
		/// </summary>
		OBJECT_INHERIT_ACE = 0x01,

		/// <summary>
		/// Child objects that are containers, such as directories, inherit the ACE as an effective ACE. The inherited ACE is inheritable
		/// unless the NO_PROPAGATE_INHERIT_ACE bit flag is also set.
		/// </summary>
		CONTAINER_INHERIT_ACE = 0x02,

		/// <summary>
		/// If the ACE is inherited by a child object, the system clears the OBJECT_INHERIT_ACE and CONTAINER_INHERIT_ACE flags in the
		/// inherited ACE. This prevents the ACE from being inherited by subsequent generations of objects.
		/// </summary>
		NO_PROPAGATE_INHERIT_ACE = 0x04,

		/// <summary>
		/// Indicates an inherit-only ACE, which does not control access to the object to which it is attached. If this flag is not set, the
		/// ACE is an effective ACE that controls access to the object to which it is attached.
		/// <para>Both effective and inherit-only ACEs can be inherited depending on the state of the other inheritance flags.</para>
		/// </summary>
		[SortOrder(1000)]
		INHERIT_ONLY_ACE = 0x08,

		/// <summary>Used to indicate that the ACE was inherited. See section 2.5.3.5 for processing rules for setting this flag.</summary>
		INHERITED_ACE = 0x10,

		/// <summary>Used only with access allowed ACE types to indicate that the ACE is critical and cannot be removed.</summary>
		CRITICAL_ACE_FLAG = 0x20,

		/// <summary>Used with system-audit ACEs in a SACL to generate audit messages for successful access attempts.</summary>
		SUCCESSFUL_ACCESS_ACE_FLAG = 0x40,

		/// <summary>
		/// Used only with SYSTEM_FILTERING_ACE_TYPE ACEs to indicate that this ACE may not be deleted/modified except when the, the current
		/// Trust Level dominates the one specified in the Ace SID. If this flag is set then the SID in the ACE should be a valid TrustLevelSid.
		/// </summary>
		TRUST_PROTECTED_FILTER_ACE_FLAG = 0x40,

		/// <summary>Used with system-audit ACEs in a system access control list (SACL) to generate audit messages for failed access attempts.</summary>
		FAILED_ACCESS_ACE_FLAG = 0x80,
	}   
	
	/// <summary>Indicates whether the ObjectTypeName and InheritedObjectTypeName members contain strings.</summary>
	[PInvokeData("winnt.h")]
	[Flags]
	public enum AceObjectPresence : uint
	{
		/// <summary>The ObjectTypeName member contains a string.</summary>
		ACE_OBJECT_TYPE_PRESENT = 0x1,

		/// <summary>The InheritedObjectTypeName member contains a string.</summary>
		ACE_INHERITED_OBJECT_TYPE_PRESENT = 0x2
	}

	/// <summary>Specifies the ACE type.</summary>
	[PInvokeData("winnt.h")]
	public enum ACE_TYPE : byte
	{
		/// <summary>Access-allowed ACE that uses the ACCESS_ALLOWED_ACE structure.</summary>
		[CorrespondingType(typeof(ACCESS_ALLOWED_ACE))]
		[SortOrder(100)]
		ACCESS_ALLOWED_ACE_TYPE = 0x0,

		/// <summary>Access-denied ACE that uses the ACCESS_DENIED_ACE structure.</summary>
		[CorrespondingType(typeof(ACCESS_DENIED_ACE))]
		ACCESS_DENIED_ACE_TYPE = 0x1,

		/// <summary>System-audit ACE that uses the SYSTEM_AUDIT_ACE structure.</summary>
		[CorrespondingType(typeof(SYSTEM_AUDIT_ACE))]
		SYSTEM_AUDIT_ACE_TYPE = 0x2,

		/// <summary>Reserved for future use. System-alarm ACE that uses the SYSTEM_ALARM_ACE structure.</summary>
		[CorrespondingType(typeof(SYSTEM_ALARM_ACE))]
		SYSTEM_ALARM_ACE_TYPE = 0x3,

		/// <summary>Reserved.</summary>
		[SortOrder(100)]
		ACCESS_ALLOWED_COMPOUND_ACE_TYPE = 0x4,

		/// <summary>Object-specific access-allowed ACE that uses the ACCESS_ALLOWED_OBJECT_ACE structure.</summary>
		[CorrespondingType(typeof(ACCESS_ALLOWED_OBJECT_ACE))]
		[SortOrder(100)]
		ACCESS_ALLOWED_OBJECT_ACE_TYPE = 0x5,

		/// <summary>Object-specific access-denied ACE that uses the ACCESS_DENIED_OBJECT_ACE structure.</summary>
		[CorrespondingType(typeof(ACCESS_DENIED_OBJECT_ACE))]
		ACCESS_DENIED_OBJECT_ACE_TYPE = 0x6,

		/// <summary>Object-specific system-audit ACE that uses the SYSTEM_AUDIT_OBJECT_ACE structure.</summary>
		[CorrespondingType(typeof(SYSTEM_AUDIT_OBJECT_ACE))]
		SYSTEM_AUDIT_OBJECT_ACE_TYPE = 0x7,

		/// <summary>Reserved for future use. Object-specific system-alarm ACE that uses the SYSTEM_ALARM_OBJECT_ACE structure.</summary>
		[CorrespondingType(typeof(SYSTEM_ALARM_OBJECT_ACE))]
		SYSTEM_ALARM_OBJECT_ACE_TYPE = 0x8,

		/// <summary>Access-allowed callback ACE that uses the ACCESS_ALLOWED_CALLBACK_ACE structure.</summary>
		[CorrespondingType(typeof(ACCESS_ALLOWED_CALLBACK_ACE))]
		[SortOrder(100)]
		ACCESS_ALLOWED_CALLBACK_ACE_TYPE = 0x9,

		/// <summary>Access-denied callback ACE that uses the ACCESS_DENIED_CALLBACK_ACE structure.</summary>
		[CorrespondingType(typeof(ACCESS_DENIED_CALLBACK_ACE))]
		ACCESS_DENIED_CALLBACK_ACE_TYPE = 0xA,

		/// <summary>Object-specific access-allowed callback ACE that uses the ACCESS_ALLOWED_CALLBACK_OBJECT_ACE structure.</summary>
		[CorrespondingType(typeof(ACCESS_ALLOWED_CALLBACK_OBJECT_ACE))]
		[SortOrder(100)]
		ACCESS_ALLOWED_CALLBACK_OBJECT_ACE_TYPE = 0xB,

		/// <summary>Object-specific access-denied callback ACE that uses the ACCESS_DENIED_CALLBACK_OBJECT_ACE structure.</summary>
		[CorrespondingType(typeof(ACCESS_DENIED_CALLBACK_OBJECT_ACE))]
		ACCESS_DENIED_CALLBACK_OBJECT_ACE_TYPE = 0xC,

		/// <summary>System-audit callback ACE that uses the SYSTEM_AUDIT_CALLBACK_ACE structure.</summary>
		[CorrespondingType(typeof(SYSTEM_AUDIT_CALLBACK_ACE))]
		SYSTEM_AUDIT_CALLBACK_ACE_TYPE = 0xD,

		/// <summary>Reserved for future use. System-alarm callback ACE that uses the SYSTEM_ALARM_CALLBACK_ACE structure.</summary>
		[CorrespondingType(typeof(SYSTEM_ALARM_CALLBACK_ACE))]
		SYSTEM_ALARM_CALLBACK_ACE_TYPE = 0xE,

		/// <summary>Object-specific system-audit callback ACE that uses the SYSTEM_AUDIT_CALLBACK_OBJECT_ACE structure.</summary>
		[CorrespondingType(typeof(SYSTEM_AUDIT_CALLBACK_OBJECT_ACE))]
		SYSTEM_AUDIT_CALLBACK_OBJECT_ACE_TYPE = 0xF,

		/// <summary>Reserved for future use. Object-specific system-alarm callback ACE that uses the SYSTEM_ALARM_CALLBACK_OBJECT_ACE structure.</summary>
		[CorrespondingType(typeof(SYSTEM_ALARM_CALLBACK_OBJECT_ACE))]
		SYSTEM_ALARM_CALLBACK_OBJECT_ACE_TYPE = 0x10,

		/// <summary>Mandatory label ACE that uses the SYSTEM_MANDATORY_LABEL_ACE structure.</summary>
		[CorrespondingType(typeof(SYSTEM_MANDATORY_LABEL_ACE))]
		SYSTEM_MANDATORY_LABEL_ACE_TYPE = 0x11,

		/// <summary>System resource attributes for a securable object.</summary>
		[CorrespondingType(typeof(SYSTEM_RESOURCE_ATTRIBUTE_ACE))]
		SYSTEM_RESOURCE_ATTRIBUTE_ACE_TYPE = 0x12,

		/// <summary>An access control entry (ACE) for the system access control list (SACL) that specifies the scoped policy identifier for a securable object.</summary>
		[CorrespondingType(typeof(SYSTEM_SCOPED_POLICY_ID_ACE))]
		SYSTEM_SCOPED_POLICY_ID_ACE_TYPE = 0x13,

		/// <summary></summary>
		[CorrespondingType(typeof(SYSTEM_PROCESS_TRUST_LABEL_ACE))]
		SYSTEM_PROCESS_TRUST_LABEL_ACE_TYPE = 0x14,

		/// <summary></summary>
		[CorrespondingType(typeof(SYSTEM_ACCESS_FILTER_ACE))]
		SYSTEM_ACCESS_FILTER_ACE_TYPE = 0x15,
	}

	/// <summary>Used by the <see cref="GetAclInformation(PACL, IntPtr, uint, ACL_INFORMATION_CLASS)"/> function.</summary>
	[PInvokeData("winnt.h")]
	public enum ACL_INFORMATION_CLASS : uint
	{
		/// <summary>Indicates ACL revision information.</summary>
		[CorrespondingType(typeof(ACL_REVISION_INFORMATION))]
		AclRevisionInformation = 1,

		/// <summary>Indicates ACL size information.</summary>
		[CorrespondingType(typeof(ACL_SIZE_INFORMATION))]
		AclSizeInformation
	}

	/// <summary>
	/// The attribute flags that are a 32-bitmask. Bits 16 through 31 may be set to any value. Bits 0 through 15 must be zero or a
	/// combination of one or more of the following mask values.
	/// </summary>
	[PInvokeData("winnt.h", MSDNShortId = "FDBB9B00-01C3-474A-81FF-97C5CBA3261B")]
	[Flags]
	public enum CLAIM_SECURITY_ATTRIBUTE_FLAG : uint
	{
		/// <summary>This attribute is ignored by the operating system. This claim security attribute is not inherited across processes.</summary>
		CLAIM_SECURITY_ATTRIBUTE_NON_INHERITABLE = 0x0001,

		/// <summary>
		/// The value of the claim security attribute is case sensitive. This flag is valid for values that contain string types.
		/// </summary>
		CLAIM_SECURITY_ATTRIBUTE_VALUE_CASE_SENSITIVE = 0x0002,

		/// <summary>The claim security attribute is considered only for deny access control entries (ACEs).</summary>
		CLAIM_SECURITY_ATTRIBUTE_USE_FOR_DENY_ONLY = 0x0004,

		/// <summary>The claim security attribute is disabled by default.</summary>
		CLAIM_SECURITY_ATTRIBUTE_DISABLED_BY_DEFAULT = 0x0008,

		/// <summary>The claim security attribute is disabled and will not be applied by the AccessCheck function.</summary>
		CLAIM_SECURITY_ATTRIBUTE_DISABLED = 0x0010,

		/// <summary>The claim security attribute is mandatory.</summary>
		CLAIM_SECURITY_ATTRIBUTE_MANDATORY = 0x0020,
	}

	/// <summary>A union tag value that indicates the type of information contained in the <c>Values</c> member.</summary>
	[PInvokeData("winnt.h", MSDNShortId = "FDBB9B00-01C3-474A-81FF-97C5CBA3261B")]
	public enum CLAIM_SECURITY_ATTRIBUTE_TYPE : ushort
	{
		/// <summary>The Values member refers to an array of LONG64 values.</summary>
		CLAIM_SECURITY_ATTRIBUTE_TYPE_INT64 = 0x0001,

		/// <summary>The Values member refers to an array of ULONG64 values.</summary>
		CLAIM_SECURITY_ATTRIBUTE_TYPE_UINT64 = 0x0002,

		/// <summary>The Values member refers to an array of pointers to Unicode string values.</summary>
		CLAIM_SECURITY_ATTRIBUTE_TYPE_STRING = 0x0003,

		/// <summary>The Values member refers to an array of CLAIM_SECURITY_ATTRIBUTE_FQBN_VALUE values.</summary>
		CLAIM_SECURITY_ATTRIBUTE_TYPE_FQBN = 0x0004,

		/// <summary>
		/// The Values member refers to an array of CLAIM_SECURITY_ATTRIBUTE_OCTET_STRING_VALUE values where the pValue member of each
		/// CLAIM_SECURITY_ATTRIBUTE_OCTET_STRING_VALUE is a PSID.
		/// </summary>
		CLAIM_SECURITY_ATTRIBUTE_TYPE_SID = 0x0005,

		/// <summary>
		/// The Values member refers to an array of ULONG64 values where each element indicates a Boolean value. The value 1 indicates
		/// TRUE and the value 0 indicates FALSE.
		/// </summary>
		CLAIM_SECURITY_ATTRIBUTE_TYPE_BOOLEAN = 0x0006,

		/// <summary>The Values member refers to an array of CLAIM_SECURITY_ATTRIBUTE_OCTET_STRING_VALUE values.</summary>
		CLAIM_SECURITY_ATTRIBUTE_TYPE_OCTET_STRING = 0x0010,
	}

	/// <summary>Flags that affect the behavior of <see cref="CheckTokenMembershipEx"/>.</summary>
	[PInvokeData("winnt.h")]
	[Flags]
	public enum CTMF : uint
	{
		/// <summary>
		/// Allows app containers to pass the call as long as the other requirements of the token are met, such as the group specified is
		/// present and enabled.
		/// </summary>
		CTMF_INCLUDE_APPCONTAINER = 0x00000001,

		/// <summary>Undocumented.</summary>
		CTMF_INCLUDE_LPAC = 0x00000002
	}

	/// <summary>The status of the event log.</summary>
	[PInvokeData("Winnt.h", MSDNShortId = "bb309024")]
	[Flags]
	public enum ELF_FLAGS
	{
		/// <summary>
		/// Indicates that records have been written to an event log, but the event log file has not been properly closed. For more
		/// information about this flag, see the Remarks section.
		/// </summary>
		ELF_LOGFILE_HEADER_DIRTY = 0x0001,

		/// <summary>Indicates that records in the event log have wrapped.</summary>
		ELF_LOGFILE_HEADER_WRAP = 0x0002,

		/// <summary>Indicates that the most recent write attempt failed due to insufficient space.</summary>
		ELF_LOGFILE_LOGFULL_WRITTEN = 0x0004,

		/// <summary>
		/// Indicates that the archive attribute has been set for the file. Normal file APIs can also be used to determine the value of
		/// this flag.
		/// </summary>
		ELF_LOGFILE_ARCHIVE_SET = 0x0008,
	}

	/// <summary>Indicate how to read the log file.</summary>
	[PInvokeData("winnt.h", MSDNShortId = "53706f83-6bc9-45d6-981c-bd0680d7bc08")]
	[Flags]
	public enum EVENTLOG_READ
	{
		/// <summary>The eventlog sequential read</summary>
		EVENTLOG_SEQUENTIAL_READ = 0x0001,

		/// <summary>
		/// Begin reading from the record specified in the dwRecordOffset parameter. This option may not work with large log files if the
		/// function cannot determine the log file's size. For details, see Knowledge Base article, 177199.
		/// </summary>
		EVENTLOG_SEEK_READ = 0x0002,

		/// <summary>The log is read in chronological order (oldest to newest).</summary>
		EVENTLOG_FORWARDS_READ = 0x0004,

		/// <summary>The log is read in reverse chronological order (newest to oldest).</summary>
		EVENTLOG_BACKWARDS_READ = 0x0008,
	}

	/// <summary>The type of event to be logged.</summary>
	[PInvokeData("winnt.h", MSDNShortId = "e39273c3-9e42-41a1-9ec1-1cdff2ab7b55")]
	public enum EVENTLOG_TYPE : ushort
	{
		/// <summary>Information event</summary>
		EVENTLOG_SUCCESS = 0x0000,

		/// <summary>Error event</summary>
		EVENTLOG_ERROR_TYPE = 0x0001,

		/// <summary>Warning event</summary>
		EVENTLOG_WARNING_TYPE = 0x0002,

		/// <summary>Information event</summary>
		EVENTLOG_INFORMATION_TYPE = 0x0004,

		/// <summary>Success Audit event</summary>
		EVENTLOG_AUDIT_SUCCESS = 0x0008,

		/// <summary>Failure Audit event</summary>
		EVENTLOG_AUDIT_FAILURE = 0x0010,
	}

	/// <summary>Group attributes.</summary>
	[Flags]
	[PInvokeData("winnt.h")]
	public enum GroupAttributes : uint
	{
		/// <summary>
		/// The SID cannot have the SE_GROUP_ENABLED attribute cleared by a call to the AdjustTokenGroups function. However, you can use
		/// the CreateRestrictedToken function to convert a mandatory SID to a deny-only SID.
		/// </summary>
		SE_GROUP_MANDATORY = 0x00000001,

		/// <summary>The SID is enabled by default.</summary>
		SE_GROUP_ENABLED_BY_DEFAULT = 0x00000002,

		/// <summary>
		/// The SID is enabled for access checks. When the system performs an access check, it checks for access-allowed and
		/// access-denied access control entries (ACEs) that apply to the SID. A SID without this attribute is ignored during an access
		/// check unless the SE_GROUP_USE_FOR_DENY_ONLY attribute is set.
		/// </summary>
		SE_GROUP_ENABLED = 0x00000004,

		/// <summary>
		/// The SID identifies a group account for which the user of the token is the owner of the group, or the SID can be assigned as
		/// the owner of the token or objects.
		/// </summary>
		SE_GROUP_OWNER = 0x00000008,

		/// <summary>
		/// The SID is a deny-only SID in a restricted token. When the system performs an access check, it checks for access-denied ACEs
		/// that apply to the SID; it ignores access-allowed ACEs for the SID. If this attribute is set, SE_GROUP_ENABLED is not set, and
		/// the SID cannot be reenabled.
		/// </summary>
		SE_GROUP_USE_FOR_DENY_ONLY = 0x00000010,

		/// <summary>The SID is a mandatory integrity SID.</summary>
		SE_GROUP_INTEGRITY = 0x00000020,

		/// <summary>The SID is enabled for mandatory integrity checks.</summary>
		SE_GROUP_INTEGRITY_ENABLED = 0x00000040,

		/// <summary>The SID is a logon SID that identifies the logon session associated with an access token.</summary>
		SE_GROUP_LOGON_ID = 0xC0000000,

		/// <summary>The SID identifies a domain-local group.</summary>
		SE_GROUP_RESOURCE = 0x20000000
	}

	/// <summary>
	/// The capability SID constants define for applications well-known capabilities by using the AllocateAndInitializeSid function.
	/// </summary>
	/// <remarks>
	/// When constructing a capability SID, you need to include the package authority, SECURITY_APP_PACKAGE_AUTHORITY {0,0,0,0,0,15}, in
	/// the call to the AllocateAndInitializeSid function. Additionally, you need the base RID and RID count for the built-in
	/// capabilities, SECURITY_CAPABILITY_BASE_RID (0x00000003L) and SECURITY_BUILTIN_CAPABILITY_RID_COUNT (2L).
	/// </remarks>
	public enum KnownSIDCapability
	{
		/// <summary>An account has access to the Internet from a client computer.</summary>
		SECURITY_CAPABILITY_INTERNET_CLIENT = 0x00000001,

		/// <summary>An account has access to the Internet from the client and server computers.</summary>
		SECURITY_CAPABILITY_INTERNET_CLIENT_SERVER = 0x00000002,

		/// <summary>An account has access to the Internet from a private network.</summary>
		SECURITY_CAPABILITY_PRIVATE_NETWORK_CLIENT_SERVER = 0x00000003,

		/// <summary>An account has access to the pictures library.</summary>
		SECURITY_CAPABILITY_PICTURES_LIBRARY = 0x00000004,

		/// <summary>An account has access to the videos library.</summary>
		SECURITY_CAPABILITY_VIDEOS_LIBRARY = 0x00000005,

		/// <summary>An account has access to the music library.</summary>
		SECURITY_CAPABILITY_MUSIC_LIBRARY = 0x00000006,

		/// <summary>An account has access to the documentation library.</summary>
		SECURITY_CAPABILITY_DOCUMENTS_LIBRARY = 0x00000007,

		/// <summary>An account has access to the default Windows credentials.</summary>
		SECURITY_CAPABILITY_ENTERPRISE_AUTHENTICATION = 0x00000008,

		/// <summary>An account has access to the shared user certificates.</summary>
		SECURITY_CAPABILITY_SHARED_USER_CERTIFICATES = 0x00000009,

		/// <summary>An account has access to removable storage.</summary>
		SECURITY_CAPABILITY_REMOVABLE_STORAGE = 0x0000000A,
	}

	/// <summary>The <c>MANDATORY_LEVEL</c> enumeration lists the possible security levels.
	/// <note>These values have been adjusted to equal the RID values of the mandatory SID label.</note>
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/winnt/ne-winnt-mandatory_level typedef enum _MANDATORY_LEVEL {
	// MandatoryLevelUntrusted, MandatoryLevelLow, MandatoryLevelMedium, MandatoryLevelHigh, MandatoryLevelSystem,
	// MandatoryLevelSecureProcess, MandatoryLevelCount } MANDATORY_LEVEL, *PMANDATORY_LEVEL;
	[PInvokeData("winnt.h", MSDNShortId = "NE:winnt._MANDATORY_LEVEL")]
	public enum MANDATORY_LEVEL : uint
	{
		/// <summary>Untrusted</summary>
		MandatoryLevelUntrusted = 0,

		/// <summary>Low</summary>
		MandatoryLevelLow = 0x1000,

		/// <summary>Medium</summary>
		MandatoryLevelMedium = 0x2000,

		/// <summary>Medium High</summary>
		MandatoryLevelMediumHigh = MandatoryLevelMedium + 0x100,

		/// <summary>High</summary>
		MandatoryLevelHigh = 0x3000,

		/// <summary>System</summary>
		MandatoryLevelSystem = 0x4000,

		/// <summary>Secure process</summary>
		MandatoryLevelSecureProcess = 0x5000,
	}

	/// <summary>
	/// A set of bit flags that indicate whether the <c>ObjectType</c> and <c>InheritedObjectType</c> members are present in an object ACE.
	/// </summary>
	[Flags]
	public enum ObjectAceFlags : uint
	{
		/// <summary>
		/// ObjectType is present and contains a GUID. If this value is not specified, the InheritedObjectType member follows immediately
		/// after the Flags member.
		/// </summary>
		ACE_OBJECT_TYPE_PRESENT = 0x1,

		/// <summary>
		/// InheritedObjectType is present and contains a GUID. If this value is not specified, all types of child objects can inherit
		/// the ACE.
		/// </summary>
		ACE_INHERITED_OBJECT_TYPE_PRESENT = 0x2
	}

	/// <summary>Privilege attributes.</summary>
	[Flags]
	[PInvokeData("winnt.h")]
	public enum PrivilegeAttributes : uint
	{
		/// <summary>The privilege is disabled.</summary>
		SE_PRIVILEGE_DISABLED = 0x00000000,

		/// <summary>The privilege is enabled by default.</summary>
		SE_PRIVILEGE_ENABLED_BY_DEFAULT = 0x00000001,

		/// <summary>The privilege is enabled.</summary>
		SE_PRIVILEGE_ENABLED = 0x00000002,

		/// <summary>Used to remove a privilege. The other privileges in the list are reordered to remain contiguous.</summary>
		SE_PRIVILEGE_REMOVED = 0x00000004,

		/// <summary>
		/// The privilege was used to gain access to an object or service. This flag is used to identify the relevant privileges in a set
		/// passed by a client application that may contain unnecessary privileges.
		/// </summary>
		SE_PRIVILEGE_USED_FOR_ACCESS = 0x80000000
	}

	/// <summary>Flags used by PRIVILEGE_SET.</summary>
	[PInvokeData("winnt.h")]
	public enum PrivilegeSetControl
	{
		/// <summary>The presence of any privileges in the user's access token grants the access.</summary>
		None = 0,

		/// <summary>Indicates that all of the specified privileges must be held by the process requesting access.</summary>
		PRIVILEGE_SET_ALL_NECESSARY = 1
	}

	/// <summary>Additional privilege options for <see cref="CreateRestrictedToken"/>.</summary>
	[PInvokeData("winnt.h")]
	public enum RestrictedPrivilegeOptions : uint
	{
		/// <summary>
		/// Disables all privileges in the new token except the SeChangeNotifyPrivilege privilege. If this value is specified, the
		/// DeletePrivilegeCount and PrivilegesToDelete parameters are ignored.
		/// </summary>
		DISABLE_MAX_PRIVILEGE = 0x1,

		/// <summary>
		/// If this value is used, the system does not check AppLocker rules or apply Software Restriction Policies. For AppLocker, this
		/// flag disables checks for all four rule collections: Executable, Windows Installer, Script, and DLL.
		/// <para>
		/// When creating a setup program that must run extracted DLLs during installation, use the flag SAFER_TOKEN_MAKE_INERT in the
		/// SaferComputeTokenFromLevel function.
		/// </para>
		/// <para>A token can be queried for existence of this flag by using GetTokenInformation.</para>
		/// <para>
		/// Windows Server 2008 R2, Windows 7, Windows Server 2008, Windows Vista, Windows Server 2003 and Windows XP: On systems with
		/// KB2532445 installed, the caller must be running as LocalSystem or TrustedInstaller or the system ignores this flag. For more
		/// information, see "You can circumvent AppLocker rules by using an Office macro on a computer that is running Windows 7 or
		/// Windows Server 2008 R2" in the Help and Support Knowledge Base at http://support.microsoft.com/kb/2532445.
		/// </para>
		/// <para>
		/// Windows Server 2008, Windows Vista, Windows Server 2003 and Windows XP: AppLocker is not supported. AppLocker was introduced
		/// in Windows 7 and Windows Server 2008 R2.
		/// </para>
		/// </summary>
		SANDBOX_INERT = 0x2,

		/// <summary>
		/// The new token is a LUA token.
		/// <para>Windows Server 2003 and Windows XP: This value is not supported.</para>
		/// </summary>
		LUA_TOKEN = 0x4,

		/// <summary>
		/// The new token contains restricting SIDs that are considered only when evaluating write access.
		/// <para>
		/// Windows XP with SP2 and later: The value of this constant is 0x4. For an application to be compatible with Windows XP with
		/// SP2 and later operating systems, the application should query the operating system by calling the GetVersionEx function to
		/// determine which value should be used.
		/// </para>
		/// <para>Windows Server 2003 and Windows XP with SP1 and earlier: This value is not supported.</para>
		/// </summary>
		WRITE_RESTRICTED = 0x8,
	}

	/// <summary>
	/// A set of bit flags that qualify the meaning of a security descriptor or its components. Each security descriptor has a Control
	/// member that stores the SECURITY_DESCRIPTOR_CONTROL bits.
	/// </summary>
	[Flags]
	public enum SECURITY_DESCRIPTOR_CONTROL : ushort
	{
		/// <summary>
		/// Indicates a required security descriptor in which the discretionary access control list (DACL) is set up to support automatic
		/// propagation of inheritable access control entries (ACEs) to existing child objects.
		/// <para>
		/// For access control lists (ACLs) that support auto inheritance, this bit is always set. Protected servers can call the
		/// ConvertToAutoInheritPrivateObjectSecurity function to convert a security descriptor and set this flag.
		/// </para>
		/// </summary>
		SE_DACL_AUTO_INHERIT_REQ = 0x0100,

		/// <summary>
		/// Indicates a security descriptor in which the discretionary access control list (DACL) is set up to support automatic
		/// propagation of inheritable access control entries (ACEs) to existing child objects.
		/// <para>
		/// For access control lists (ACLs) that support auto inheritance, this bit is always set. Protected servers can call the
		/// ConvertToAutoInheritPrivateObjectSecurity function to convert a security descriptor and set this flag.
		/// </para>
		/// </summary>
		SE_DACL_AUTO_INHERITED = 0x0400,

		/// <summary>
		/// Indicates a security descriptor with a default DACL. For example, if the creator an object does not specify a DACL, the
		/// object receives the default DACL from the access token of the creator. This flag can affect how the system treats the DACL
		/// with respect to ACE inheritance. The system ignores this flag if the SE_DACL_PRESENT flag is not set.
		/// <para>
		/// This flag is used to determine how the final DACL on the object is to be computed and is not stored physically in the
		/// security descriptor control of the securable object.
		/// </para>
		/// <para>To set this flag, use the SetSecurityDescriptorDacl function.</para>
		/// </summary>
		SE_DACL_DEFAULTED = 0x0008,

		/// <summary>
		/// Indicates a security descriptor that has a DACL. If this flag is not set, or if this flag is set and the DACL is NULL, the
		/// security descriptor allows full access to everyone.
		/// <para>
		/// This flag is used to hold the security information specified by a caller until the security descriptor is associated with a
		/// securable object. After the security descriptor is associated with a securable object, the SE_DACL_PRESENT flag is always set
		/// in the security descriptor control.
		/// </para>
		/// <para>To set this flag, use the SetSecurityDescriptorDacl function.</para>
		/// </summary>
		SE_DACL_PRESENT = 0x0004,

		/// <summary>
		/// Prevents the DACL of the security descriptor from being modified by inheritable ACEs. To set this flag, use the
		/// SetSecurityDescriptorControl function.
		/// </summary>
		SE_DACL_PROTECTED = 0x1000,

		/// <summary>
		/// Indicates that the security identifier (SID) of the security descriptor group was provided by a default mechanism. This flag
		/// can be used by a resource manager to identify objects whose security descriptor group was set by a default mechanism. To set
		/// this flag, use the SetSecurityDescriptorGroup function.
		/// </summary>
		SE_GROUP_DEFAULTED = 0x0002,

		/// <summary>
		/// Indicates that the SID of the owner of the security descriptor was provided by a default mechanism. This flag can be used by
		/// a resource manager to identify objects whose owner was set by a default mechanism. To set this flag, use the
		/// SetSecurityDescriptorOwner function.
		/// </summary>
		SE_OWNER_DEFAULTED = 0x0001,

		/// <summary>Indicates that the resource manager control is valid.</summary>
		SE_RM_CONTROL_VALID = 0x4000,

		/// <summary>
		/// Indicates a required security descriptor in which the system access control list (SACL) is set up to support automatic
		/// propagation of inheritable ACEs to existing child objects.
		/// <para>
		/// The system sets this bit when it performs the automatic inheritance algorithm for the object and its existing child objects.
		/// To convert a security descriptor and set this flag, protected servers can call the ConvertToAutoInheritPrivateObjectSecurity function.
		/// </para>
		/// </summary>
		SE_SACL_AUTO_INHERIT_REQ = 0x0200,

		/// <summary>
		/// Indicates a security descriptor in which the system access control list (SACL) is set up to support automatic propagation of
		/// inheritable ACEs to existing child objects.
		/// <para>
		/// The system sets this bit when it performs the automatic inheritance algorithm for the object and its existing child objects.
		/// To convert a security descriptor and set this flag, protected servers can call the ConvertToAutoInheritPrivateObjectSecurity function.
		/// </para>
		/// </summary>
		SE_SACL_AUTO_INHERITED = 0x0800,

		/// <summary>
		/// A default mechanism, rather than the original provider of the security descriptor, provided the SACL. This flag can affect
		/// how the system treats the SACL, with respect to ACE inheritance. The system ignores this flag if the SE_SACL_PRESENT flag is
		/// not set. To set this flag, use the SetSecurityDescriptorSacl function.
		/// </summary>
		SE_SACL_DEFAULTED = 0x0008,

		/// <summary>Indicates a security descriptor that has a SACL. To set this flag, use the SetSecurityDescriptorSacl function.</summary>
		SE_SACL_PRESENT = 0x0010,

		/// <summary>
		/// Prevents the SACL of the security descriptor from being modified by inheritable ACEs. To set this flag, use the
		/// SetSecurityDescriptorControl function.
		/// </summary>
		SE_SACL_PROTECTED = 0x2000,

		/// <summary>
		/// Indicates a self-relative security descriptor. If this flag is not set, the security descriptor is in absolute format. For
		/// more information, see Absolute and Self-Relative Security Descriptors.
		/// </summary>
		SE_SELF_RELATIVE = 0x8000
	}

	/// <summary>
	/// The SECURITY_IMPERSONATION_LEVEL enumeration contains values that specify security impersonation levels. Security impersonation
	/// levels govern the degree to which a server process can act on behalf of a client process.
	/// </summary>
	[PInvokeData("winnt.h")]
	public enum SECURITY_IMPERSONATION_LEVEL
	{
		/// <summary>
		/// The server process cannot obtain identification information about the client, and it cannot impersonate the client. It is
		/// defined with no value given, and thus, by ANSI C rules, defaults to a value of zero.
		/// </summary>
		SecurityAnonymous,

		/// <summary>
		/// The server process can obtain information about the client, such as security identifiers and privileges, but it cannot
		/// impersonate the client. This is useful for servers that export their own objects, for example, database products that export
		/// tables and views. Using the retrieved client-security information, the server can make access-validation decisions without
		/// being able to use other services that are using the client's security context.
		/// </summary>
		SecurityIdentification,

		/// <summary>
		/// The server process can impersonate the client's security context on its local system. The server cannot impersonate the
		/// client on remote systems.
		/// </summary>
		SecurityImpersonation,

		/// <summary>The server process can impersonate the client's security context on remote systems.</summary>
		SecurityDelegation
	}

	/// <summary>A set of bit flags that control how access control entries (ACEs) are inherited from ParentDescriptor.</summary>
	[PInvokeData("winnt.h")]
	[Flags]
	public enum SEF : uint
	{
		/// <summary>
		/// The new discretionary access control list (DACL) contains ACEs inherited from the DACL of ParentDescriptor, as well as any
		/// explicit ACEs specified in the DACL of CreatorDescriptor. If this flag is not set, the new DACL does not inherit ACEs.
		/// </summary>
		SEF_DACL_AUTO_INHERIT = 0x01,

		/// <summary>
		/// The new system access control list (SACL) contains ACEs inherited from the SACL of ParentDescriptor, as well as any explicit
		/// ACEs specified in the SACL of CreatorDescriptor. If this flag is not set, the new SACL does not inherit ACEs.
		/// </summary>
		SEF_SACL_AUTO_INHERIT = 0x02,

		/// <summary>
		/// CreatorDescriptor is the default descriptor for the types of objects specified by ObjectTypes. As such, CreatorDescriptor is
		/// ignored if ParentDescriptor has any object-specific ACEs for the types of objects specified by the ObjectTypes parameter. If
		/// no such ACEs are inherited, CreatorDescriptor is handled as though this flag were not specified.
		/// </summary>
		SEF_DEFAULT_DESCRIPTOR_FOR_OBJECT = 0x04,

		/// <summary>
		/// The function does not perform privilege checking. If the SEF_AVOID_OWNER_CHECK flag is also set, the Token parameter can be
		/// NULL. This flag is useful while implementing automatic inheritance to avoid checking privileges on each child updated.
		/// </summary>
		SEF_AVOID_PRIVILEGE_CHECK = 0x08,

		/// <summary>
		/// The function does not check the validity of the owner in the resultant NewDescriptor as described in the Remarks section. If
		/// the SEF_AVOID_PRIVILEGE_CHECK flag is also set, the Token parameter can be NULL.
		/// </summary>
		SEF_AVOID_OWNER_CHECK = 0x10,

		/// <summary>
		/// The owner of NewDescriptor defaults to the owner from ParentDescriptor. If not set, the owner of NewDescriptor defaults to
		/// the owner of the token specified by the Token parameter. The owner of the token is specified in the token itself. In either
		/// case, if the CreatorDescriptor parameter is not NULL, the NewDescriptor owner is set to the owner from CreatorDescriptor.
		/// </summary>
		SEF_DEFAULT_OWNER_FROM_PARENT = 0x20,

		/// <summary>
		/// The group of NewDescriptor defaults to the group from ParentDescriptor. If not set, the group of NewDescriptor defaults to
		/// the group of the token specified by the Token parameter. The group of the token is specified in the token itself. In either
		/// case, if the CreatorDescriptor parameter is not NULL, the NewDescriptor group is set to the group from CreatorDescriptor.
		/// </summary>
		SEF_DEFAULT_GROUP_FROM_PARENT = 0x40,

		/// <summary>A principal with a mandatory level lower than that of the object cannot write to the object.</summary>
		SEF_MACL_NO_WRITE_UP = 0x100,

		/// <summary>A principal with a mandatory level lower than that of the object cannot read the object.</summary>
		SEF_MACL_NO_READ_UP = 0x200,

		/// <summary>A principal with a mandatory level lower than that of the object cannot execute the object.</summary>
		SEF_MACL_NO_EXECUTE_UP = 0x400,

		/// <summary>Undocumented</summary>
		SEF_AI_USE_EXTRA_PARAMS = 0x800,

		/// <summary>
		/// Any restrictions specified by the ParentDescriptor parameter that would limit the caller's ability to specify a DACL in the
		/// CreatorDescriptor are ignored.
		/// </summary>
		SEF_AVOID_OWNER_RESTRICTION = 0x1000,

		/// <summary>Undocumented</summary>
		SEF_FORCE_USER_MODE = 0x2000
	}

	/// <summary>The SID_NAME_USE enumeration contains values that specify the type of a security identifier (SID).</summary>
	public enum SID_NAME_USE
	{
		/// <summary>A user SID.</summary>
		SidTypeUser = 1,

		/// <summary>A group SID</summary>
		SidTypeGroup,

		/// <summary>A domain SID.</summary>
		SidTypeDomain,

		/// <summary>An alias SID.</summary>
		SidTypeAlias,

		/// <summary>A SID for a well-known group.</summary>
		SidTypeWellKnownGroup,

		/// <summary>A SID for a deleted account.</summary>
		SidTypeDeletedAccount,

		/// <summary>A SID that is not valid.</summary>
		SidTypeInvalid,

		/// <summary>A SID of unknown type/.</summary>
		SidTypeUnknown,

		/// <summary>A SID for a computer.</summary>
		SidTypeComputer,

		/// <summary>A mandatory integrity label SID.</summary>
		SidTypeLabel,

		/// <summary/>
		SidTypeLogonSession
	}

	/// <summary>
	/// The access policy for principals with a mandatory integrity level lower than the object associated with the SACL that contains
	/// this ACE.
	/// </summary>
	[PInvokeData("winnt.h")]
	[Flags]
	public enum SYSTEM_MANDATORY_LABEL : uint
	{
		/// <summary>A principal with a lower mandatory level than the object cannot write to the object.</summary>
		SYSTEM_MANDATORY_LABEL_NO_WRITE_UP = 0x1,

		/// <summary>A principal with a lower mandatory level than the object cannot read the object.</summary>
		SYSTEM_MANDATORY_LABEL_NO_READ_UP = 0x2,

		/// <summary>A principal with a lower mandatory level than the object cannot execute the object.</summary>
		SYSTEM_MANDATORY_LABEL_NO_EXECUTE_UP = 0x4,
	}

	/// <summary>
	/// The TOKEN_ELEVATION_TYPE enumeration indicates the elevation type of token being queried by the GetTokenInformation function.
	/// </summary>
	[PInvokeData("winnt.h")]
	public enum TOKEN_ELEVATION_TYPE
	{
		/// <summary>The token does not have a linked token.</summary>
		TokenElevationTypeDefault = 1,

		/// <summary>The token is an elevated token.</summary>
		TokenElevationTypeFull,

		/// <summary>The token is a limited token.</summary>
		TokenElevationTypeLimited
	}

	/// <summary>
	/// The TOKEN_INFORMATION_CLASS enumeration contains values that specify the type of information being assigned to or retrieved from
	/// an access token.
	/// <para>The GetTokenInformation function uses these values to indicate the type of token information to retrieve.</para>
	/// <para>The SetTokenInformation function uses these values to set the token information.</para>
	/// </summary>
	[PInvokeData("winnt.h")]
	public enum TOKEN_INFORMATION_CLASS
	{
		/// <summary>The buffer receives a TOKEN_USER structure that contains the user account of the token.</summary>
		[CorrespondingType(typeof(TOKEN_USER), CorrespondingAction.Get)]
		TokenUser = 1,

		/// <summary>The buffer receives a TOKEN_GROUPS structure that contains the group accounts associated with the token.</summary>
		[CorrespondingType(typeof(TOKEN_GROUPS), CorrespondingAction.Get)]
		TokenGroups,

		/// <summary>The buffer receives a TOKEN_PRIVILEGES structure that contains the privileges of the token.</summary>
		[CorrespondingType(typeof(TOKEN_PRIVILEGES), CorrespondingAction.Get)]
		TokenPrivileges,

		/// <summary>
		/// The buffer receives a TOKEN_OWNER structure that contains the default owner security identifier (SID) for newly created objects.
		/// </summary>
		[CorrespondingType(typeof(TOKEN_OWNER), CorrespondingAction.GetSet)]
		TokenOwner,

		/// <summary>
		/// The buffer receives a TOKEN_PRIMARY_GROUP structure that contains the default primary group SID for newly created objects.
		/// </summary>
		[CorrespondingType(typeof(TOKEN_PRIMARY_GROUP), CorrespondingAction.GetSet)]
		TokenPrimaryGroup,

		/// <summary>The buffer receives a TOKEN_DEFAULT_DACL structure that contains the default DACL for newly created objects.</summary>
		[CorrespondingType(typeof(TOKEN_DEFAULT_DACL), CorrespondingAction.GetSet)]
		TokenDefaultDacl,

		/// <summary>
		/// The buffer receives a TOKEN_SOURCE structure that contains the source of the token. TOKEN_QUERY_SOURCE access is needed to
		/// retrieve this information.
		/// </summary>
		[CorrespondingType(typeof(TOKEN_SOURCE), CorrespondingAction.Get)]
		TokenSource,

		/// <summary>The buffer receives a TOKEN_TYPE value that indicates whether the token is a primary or impersonation token.</summary>
		[CorrespondingType(typeof(TOKEN_TYPE), CorrespondingAction.Get)]
		TokenType,

		/// <summary>
		/// The buffer receives a SECURITY_IMPERSONATION_LEVEL value that indicates the impersonation level of the token. If the access
		/// token is not an impersonation token, the function fails.
		/// </summary>
		[CorrespondingType(typeof(SECURITY_IMPERSONATION_LEVEL), CorrespondingAction.Get)]
		TokenImpersonationLevel,

		/// <summary>The buffer receives a TOKEN_STATISTICS structure that contains various token statistics.</summary>
		[CorrespondingType(typeof(TOKEN_STATISTICS), CorrespondingAction.Get)]
		TokenStatistics,

		/// <summary>The buffer receives a TOKEN_GROUPS structure that contains the list of restricting SIDs in a restricted token.</summary>
		[CorrespondingType(typeof(TOKEN_GROUPS), CorrespondingAction.Get)]
		TokenRestrictedSids,

		/// <summary>
		/// The buffer receives a DWORD value that indicates the Terminal Services session identifier that is associated with the token.
		/// <para>If the token is associated with the terminal server client session, the session identifier is nonzero.</para>
		/// <para>
		/// Windows Server 2003 and Windows XP: If the token is associated with the terminal server console session, the session
		/// identifier is zero.
		/// </para>
		/// <para>In a non-Terminal Services environment, the session identifier is zero.</para>
		/// <para>
		/// If TokenSessionId is set with SetTokenInformation, the application must have the Act As Part Of the Operating System
		/// privilege, and the application must be enabled to set the session ID in a token.
		/// </para>
		/// </summary>
		[CorrespondingType(typeof(uint), CorrespondingAction.GetSet)]
		TokenSessionId,

		/// <summary>
		/// The buffer receives a TOKEN_GROUPS_AND_PRIVILEGES structure that contains the user SID, the group accounts, the restricted
		/// SIDs, and the authentication ID associated with the token.
		/// </summary>
		[CorrespondingType(typeof(TOKEN_GROUPS_AND_PRIVILEGES), CorrespondingAction.Get)]
		TokenGroupsAndPrivileges,

		/// <summary>Reserved.</summary>
		[CorrespondingType(CorrespondingAction.Exception)]
		TokenSessionReference,

		/// <summary>The buffer receives a DWORD value that is nonzero if the token includes the SANDBOX_INERT flag.</summary>
		[CorrespondingType(typeof(uint), CorrespondingAction.Get)]
		TokenSandBoxInert,

		/// <summary>Reserved.</summary>
		[CorrespondingType(CorrespondingAction.Exception)]
		TokenAuditPolicy,

		/// <summary>
		/// The buffer receives a TOKEN_ORIGIN value.
		/// <para>
		/// If the token resulted from a logon that used explicit credentials, such as passing a name, domain, and password to the
		/// LogonUser function, then the TOKEN_ORIGIN structure will contain the ID of the logon session that created it.
		/// </para>
		/// <para>
		/// If the token resulted from network authentication, such as a call to AcceptSecurityContext or a call to LogonUser with
		/// dwLogonType set to LOGON32_LOGON_NETWORK or LOGON32_LOGON_NETWORK_CLEARTEXT, then this value will be zero.
		/// </para>
		/// </summary>
		[CorrespondingType(typeof(TOKEN_ORIGIN), CorrespondingAction.GetSet)]
		TokenOrigin,

		/// <summary>The buffer receives a TOKEN_ELEVATION_TYPE value that specifies the elevation level of the token.</summary>
		[CorrespondingType(typeof(TOKEN_ELEVATION_TYPE), CorrespondingAction.Get)]
		TokenElevationType,

		/// <summary>
		/// The buffer receives a TOKEN_LINKED_TOKEN structure that contains a handle to another token that is linked to this token.
		/// </summary>
		[CorrespondingType(typeof(TOKEN_LINKED_TOKEN), CorrespondingAction.GetSet)]
		TokenLinkedToken,

		/// <summary>The buffer receives a TOKEN_ELEVATION structure that specifies whether the token is elevated.</summary>
		[CorrespondingType(typeof(TOKEN_ELEVATION), CorrespondingAction.Get)]
		TokenElevation,

		/// <summary>The buffer receives a DWORD value that is nonzero if the token has ever been filtered.</summary>
		[CorrespondingType(typeof(uint), CorrespondingAction.Get)]
		TokenHasRestrictions,

		/// <summary>
		/// The buffer receives a TOKEN_ACCESS_INFORMATION structure that specifies security information contained in the token.
		/// </summary>
		[CorrespondingType(typeof(TOKEN_ACCESS_INFORMATION), CorrespondingAction.Get)]
		TokenAccessInformation,

		/// <summary>The buffer receives a DWORD value that is nonzero if virtualization is allowed for the token.</summary>
		[CorrespondingType(typeof(uint), CorrespondingAction.GetSet)]
		TokenVirtualizationAllowed,

		/// <summary>The buffer receives a DWORD value that is nonzero if virtualization is enabled for the token.</summary>
		[CorrespondingType(typeof(uint), CorrespondingAction.GetSet)]
		TokenVirtualizationEnabled,

		/// <summary>The buffer receives a TOKEN_MANDATORY_LABEL structure that specifies the token's integrity level.</summary>
		[CorrespondingType(typeof(TOKEN_MANDATORY_LABEL), CorrespondingAction.GetSet)]
		TokenIntegrityLevel,

		/// <summary>The buffer receives a DWORD value that is nonzero if the token has the UIAccess flag set.</summary>
		[CorrespondingType(typeof(uint), CorrespondingAction.GetSet)]
		TokenUIAccess,

		/// <summary>The buffer receives a TOKEN_MANDATORY_POLICY structure that specifies the token's mandatory integrity policy.</summary>
		[CorrespondingType(typeof(TOKEN_MANDATORY_POLICY), CorrespondingAction.GetSet)]
		TokenMandatoryPolicy,

		/// <summary>The buffer receives a TOKEN_GROUPS structure that specifies the token's logon SID.</summary>
		[CorrespondingType(typeof(TOKEN_GROUPS), CorrespondingAction.Get)]
		TokenLogonSid,

		/// <summary>
		/// The buffer receives a DWORD value that is nonzero if the token is an application container token. Any callers who check the
		/// TokenIsAppContainer and have it return 0 should also verify that the caller token is not an identify level impersonation
		/// token. If the current token is not an application container but is an identity level token, you should return AccessDenied.
		/// </summary>
		[CorrespondingType(typeof(uint), CorrespondingAction.Get)]
		TokenIsAppContainer,

		/// <summary>The buffer receives a TOKEN_GROUPS structure that contains the capabilities associated with the token.</summary>
		[CorrespondingType(typeof(TOKEN_GROUPS), CorrespondingAction.Get)]
		TokenCapabilities,

		/// <summary>
		/// The buffer receives a TOKEN_APPCONTAINER_INFORMATION structure that contains the AppContainerSid associated with the token.
		/// If the token is not associated with an application container, the TokenAppContainer member of the
		/// TOKEN_APPCONTAINER_INFORMATION structure points to NULL.
		/// </summary>
		[CorrespondingType(typeof(TOKEN_APPCONTAINER_INFORMATION), CorrespondingAction.Get)]
		TokenAppContainerSid,

		/// <summary>
		/// The buffer receives a DWORD value that includes the application container number for the token. For tokens that are not
		/// application container tokens, this value is zero.
		/// </summary>
		[CorrespondingType(typeof(uint), CorrespondingAction.Get)]
		TokenAppContainerNumber,

		/// <summary>
		/// The buffer receives a CLAIM_SECURITY_ATTRIBUTES_INFORMATION structure that contains the user claims associated with the token.
		/// </summary>
		[CorrespondingType(typeof(CLAIM_SECURITY_ATTRIBUTES_INFORMATION), CorrespondingAction.Get)]
		TokenUserClaimAttributes,

		/// <summary>
		/// The buffer receives a CLAIM_SECURITY_ATTRIBUTES_INFORMATION structure that contains the device claims associated with the token.
		/// </summary>
		[CorrespondingType(typeof(CLAIM_SECURITY_ATTRIBUTES_INFORMATION), CorrespondingAction.Get)]
		TokenDeviceClaimAttributes,

		/// <summary>This value is reserved.</summary>
		[CorrespondingType(CorrespondingAction.Exception)]
		TokenRestrictedUserClaimAttributes,

		/// <summary>This value is reserved.</summary>
		[CorrespondingType(CorrespondingAction.Exception)]
		TokenRestrictedDeviceClaimAttributes,

		/// <summary>The buffer receives a TOKEN_GROUPS structure that contains the device groups that are associated with the token.</summary>
		[CorrespondingType(typeof(TOKEN_GROUPS), CorrespondingAction.Get)]
		TokenDeviceGroups,

		/// <summary>
		/// The buffer receives a TOKEN_GROUPS structure that contains the restricted device groups that are associated with the token.
		/// </summary>
		[CorrespondingType(typeof(TOKEN_GROUPS), CorrespondingAction.Get)]
		TokenRestrictedDeviceGroups,

		/// <summary>This value is reserved.</summary>
		[CorrespondingType(CorrespondingAction.Exception)]
		TokenSecurityAttributes,

		/// <summary>This value is reserved.</summary>
		[CorrespondingType(CorrespondingAction.Exception)]
		TokenIsRestricted
	}

	/// <summary>The TOKEN_TYPE enumeration contains values that differentiate between a primary token and an impersonation token.</summary>
	[Serializable]
	[PInvokeData("winnt.h")]
	public enum TOKEN_TYPE
	{
		/// <summary>Indicates a primary token.</summary>
		TokenPrimary = 1,

		/// <summary>Indicates an impersonation token.</summary>
		TokenImpersonation = 2
	}

	/// <summary>Token access flags.</summary>
	[Flags]
	[PInvokeData("winnt.h")]
	public enum TokenAccess : uint
	{
		/// <summary>
		/// Required to attach a primary token to a process. The SE_ASSIGNPRIMARYTOKEN_NAME privilege is also required to accomplish this task.
		/// </summary>
		TOKEN_ASSIGN_PRIMARY = 0x0001,

		/// <summary>Required to duplicate an access token.</summary>
		TOKEN_DUPLICATE = 0x0002,

		/// <summary>Required to attach an impersonation access token to a process.</summary>
		TOKEN_IMPERSONATE = 0x0004,

		/// <summary>Required to query an access token.</summary>
		TOKEN_QUERY = 0x0008,

		/// <summary>Required to query the source of an access token.</summary>
		TOKEN_QUERY_SOURCE = 0x0010,

		/// <summary>Required to enable or disable the privileges in an access token.</summary>
		TOKEN_ADJUST_PRIVILEGES = 0x0020,

		/// <summary>Required to adjust the attributes of the groups in an access token.</summary>
		TOKEN_ADJUST_GROUPS = 0x0040,

		/// <summary>Required to change the default owner, primary group, or DACL of an access token.</summary>
		TOKEN_ADJUST_DEFAULT = 0x0080,

		/// <summary>Required to adjust the session ID of an access token. The SE_TCB_NAME privilege is required.</summary>
		TOKEN_ADJUST_SESSIONID = 0x0100,

		/// <summary>The token all access p</summary>
		TOKEN_ALL_ACCESS_P = 0x000F00FF,

		/// <summary>Combines all possible access rights for a token.</summary>
		TOKEN_ALL_ACCESS = 0x000F01FF,

		/// <summary>Combines STANDARD_RIGHTS_READ and TOKEN_QUERY.</summary>
		TOKEN_READ = 0x00020008,

		/// <summary>Combines STANDARD_RIGHTS_WRITE, TOKEN_ADJUST_PRIVILEGES, TOKEN_ADJUST_GROUPS, and TOKEN_ADJUST_DEFAULT.</summary>
		TOKEN_WRITE = 0x000200E0,

		/// <summary>Combines STANDARD_RIGHTS_EXECUTE and TOKEN_IMPERSONATE.</summary>
		TOKEN_EXECUTE = 0x00020000
	}

	/// <summary>The mandatory integrity access policy for the associated token.</summary>
	[PInvokeData("winnt.h", MSDNShortId = "f5fc438b-c4f0-46f6-a188-52ce660d13da")]
	public enum TokenMandatoryPolicy
	{
		/// <summary>No mandatory integrity policy is enforced for the token.</summary>
		TOKEN_MANDATORY_POLICY_OFF = 0x0,

		/// <summary>A process associated with the token cannot write to objects that have a greater mandatory integrity level.</summary>
		TOKEN_MANDATORY_POLICY_NO_WRITE_UP = 0x1,

		/// <summary>
		/// A process created with the token has an integrity level that is the lesser of the parent-process integrity level and the
		/// executable-file integrity level.
		/// </summary>
		TOKEN_MANDATORY_POLICY_NEW_PROCESS_MIN = 0x2,

		/// <summary>A combination of TOKEN_MANDATORY_POLICY_NO_WRITE_UP and TOKEN_MANDATORY_POLICY_NEW_PROCESS_MIN.</summary>
		TOKEN_MANDATORY_POLICY_VALID_MASK = 0x3,
	}

	/// <summary>
	/// <para>
	/// The <c>WELL_KNOWN_SID_TYPE</c> enumeration is a list of commonly used security identifiers (SIDs). Programs can pass these values
	/// to the CreateWellKnownSid function to create a SID from this list.
	/// </para>
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winnt/ne-winnt-well_known_sid_type
	[PInvokeData("winnt.h", MSDNShortId = "6f1fa59e-17c0-412b-937b-ddf746ed68bd")]
	public enum WELL_KNOWN_SID_TYPE
	{
		/// <summary>Indicates a null SID.</summary>
		WinNullSid,

		/// <summary>Indicates a SID that matches everyone.</summary>
		WinWorldSid,

		/// <summary>Indicates a local SID.</summary>
		WinLocalSid,

		/// <summary>Indicates a SID that matches the owner or creator of an object.</summary>
		WinCreatorOwnerSid,

		/// <summary>Indicates a SID that matches the creator group of an object.</summary>
		WinCreatorGroupSid,

		/// <summary>Indicates a creator owner server SID.</summary>
		WinCreatorOwnerServerSid,

		/// <summary>Indicates a creator group server SID.</summary>
		WinCreatorGroupServerSid,

		/// <summary>Indicates a SID for the Windows NT authority account.</summary>
		WinNtAuthoritySid,

		/// <summary>Indicates a SID for a dial-up account.</summary>
		WinDialupSid,

		/// <summary>
		/// Indicates a SID for a network account. This SID is added to the process of a token when it logs on across a network. The
		/// corresponding logon type is LOGON32_LOGON_NETWORK.
		/// </summary>
		WinNetworkSid,

		/// <summary>
		/// Indicates a SID for a batch process. This SID is added to the process of a token when it logs on as a batch job. The
		/// corresponding logon type is LOGON32_LOGON_BATCH.
		/// </summary>
		WinBatchSid,

		/// <summary>
		/// Indicates a SID for an interactive account. This SID is added to the process of a token when it logs on interactively. The
		/// corresponding logon type is LOGON32_LOGON_INTERACTIVE.
		/// </summary>
		WinInteractiveSid,

		/// <summary>
		/// Indicates a SID for a service. This SID is added to the process of a token when it logs on as a service. The corresponding
		/// logon type is LOGON32_LOGON_SERVICE.
		/// </summary>
		WinServiceSid,

		/// <summary>Indicates a SID for the anonymous account.</summary>
		WinAnonymousSid,

		/// <summary>Indicates a proxy SID.</summary>
		WinProxySid,

		/// <summary>Indicates a SID for an enterprise controller.</summary>
		WinEnterpriseControllersSid,

		/// <summary>Indicates a SID for self.</summary>
		WinSelfSid,

		/// <summary>Indicates a SID that matches any authenticated user.</summary>
		WinAuthenticatedUserSid,

		/// <summary>Indicates a SID for restricted code.</summary>
		WinRestrictedCodeSid,

		/// <summary>Indicates a SID that matches a terminal server account.</summary>
		WinTerminalServerSid,

		/// <summary>Indicates a SID that matches remote logons.</summary>
		WinRemoteLogonIdSid,

		/// <summary>Indicates a SID that matches logon IDs.</summary>
		WinLogonIdsSid,

		/// <summary>Indicates a SID that matches the local system.</summary>
		WinLocalSystemSid,

		/// <summary>Indicates a SID that matches a local service.</summary>
		WinLocalServiceSid,

		/// <summary>Indicates a SID that matches a network service.</summary>
		WinNetworkServiceSid,

		/// <summary>Indicates a SID that matches the domain account.</summary>
		WinBuiltinDomainSid,

		/// <summary>Indicates a SID that matches the administrator group.</summary>
		WinBuiltinAdministratorsSid,

		/// <summary>Indicates a SID that matches built-in user accounts.</summary>
		WinBuiltinUsersSid,

		/// <summary>Indicates a SID that matches the guest account.</summary>
		WinBuiltinGuestsSid,

		/// <summary>Indicates a SID that matches the power users group.</summary>
		WinBuiltinPowerUsersSid,

		/// <summary>Indicates a SID that matches the account operators account.</summary>
		WinBuiltinAccountOperatorsSid,

		/// <summary>Indicates a SID that matches the system operators group.</summary>
		WinBuiltinSystemOperatorsSid,

		/// <summary>Indicates a SID that matches the print operators group.</summary>
		WinBuiltinPrintOperatorsSid,

		/// <summary>Indicates a SID that matches the backup operators group.</summary>
		WinBuiltinBackupOperatorsSid,

		/// <summary>Indicates a SID that matches the replicator account.</summary>
		WinBuiltinReplicatorSid,

		/// <summary>Indicates a SID that matches pre-Windows 2000 compatible accounts.</summary>
		WinBuiltinPreWindows2000CompatibleAccessSid,

		/// <summary>Indicates a SID that matches remote desktop users.</summary>
		WinBuiltinRemoteDesktopUsersSid,

		/// <summary>Indicates a SID that matches the network operators group.</summary>
		WinBuiltinNetworkConfigurationOperatorsSid,

		/// <summary>Indicates a SID that matches the account administrator's account.</summary>
		WinAccountAdministratorSid,

		/// <summary>Indicates a SID that matches the account guest group.</summary>
		WinAccountGuestSid,

		/// <summary>Indicates a SID that matches account Kerberos target group.</summary>
		WinAccountKrbtgtSid,

		/// <summary>Indicates a SID that matches the account domain administrator group.</summary>
		WinAccountDomainAdminsSid,

		/// <summary>Indicates a SID that matches the account domain users group.</summary>
		WinAccountDomainUsersSid,

		/// <summary>Indicates a SID that matches the account domain guests group.</summary>
		WinAccountDomainGuestsSid,

		/// <summary>Indicates a SID that matches the account computer group.</summary>
		WinAccountComputersSid,

		/// <summary>Indicates a SID that matches the account controller group.</summary>
		WinAccountControllersSid,

		/// <summary>Indicates a SID that matches the certificate administrators group.</summary>
		WinAccountCertAdminsSid,

		/// <summary>Indicates a SID that matches the schema administrators group.</summary>
		WinAccountSchemaAdminsSid,

		/// <summary>Indicates a SID that matches the enterprise administrators group.</summary>
		WinAccountEnterpriseAdminsSid,

		/// <summary>Indicates a SID that matches the policy administrators group.</summary>
		WinAccountPolicyAdminsSid,

		/// <summary>Indicates a SID that matches the RAS and IAS server account.</summary>
		WinAccountRasAndIasServersSid,

		/// <summary>Indicates a SID present when the Microsoft NTLM authentication package authenticated the client.</summary>
		WinNTLMAuthenticationSid,

		/// <summary>Indicates a SID present when the Microsoft Digest authentication package authenticated the client.</summary>
		WinDigestAuthenticationSid,

		/// <summary>Indicates a SID present when the Secure Channel (SSL/TLS) authentication package authenticated the client.</summary>
		WinSChannelAuthenticationSid,

		/// <summary>
		/// Indicates a SID present when the user authenticated from within the forest or across a trust that does not have the selective
		/// authentication option enabled. If this SID is present, then WinOtherOrganizationSid cannot be present.
		/// </summary>
		WinThisOrganizationSid,

		/// <summary>
		/// Indicates a SID present when the user authenticated across a forest with the selective authentication option enabled. If this
		/// SID is present, then WinThisOrganizationSid cannot be present.
		/// </summary>
		WinOtherOrganizationSid,

		/// <summary>
		/// Indicates a SID that allows a user to create incoming forest trusts. It is added to the token of users who are a member of
		/// the Incoming Forest Trust Builders built-in group in the root domain of the forest.
		/// </summary>
		WinBuiltinIncomingForestTrustBuildersSid,

		/// <summary>Indicates a SID that matches the performance monitor user group.</summary>
		WinBuiltinPerfMonitoringUsersSid,

		/// <summary>Indicates a SID that matches the performance log user group.</summary>
		WinBuiltinPerfLoggingUsersSid,

		/// <summary>Indicates a SID that matches the Windows Authorization Access group.</summary>
		WinBuiltinAuthorizationAccessSid,

		/// <summary>Indicates a SID is present in a server that can issue terminal server licenses.</summary>
		WinBuiltinTerminalServerLicenseServersSid,

		/// <summary>Indicates a SID that matches the distributed COM user group.</summary>
		WinBuiltinDCOMUsersSid,

		/// <summary>Indicates a SID that matches the Internet built-in user group.</summary>
		WinBuiltinIUsersSid,

		/// <summary>Indicates a SID that matches the Internet user group.</summary>
		WinIUserSid,

		/// <summary>
		/// Indicates a SID that allows a user to use cryptographic operations. It is added to the token of users who are a member of the
		/// CryptoOperators built-in group.
		/// </summary>
		WinBuiltinCryptoOperatorsSid,

		/// <summary>Indicates a SID that matches an untrusted label.</summary>
		WinUntrustedLabelSid,

		/// <summary>Indicates a SID that matches an low level of trust label.</summary>
		WinLowLabelSid,

		/// <summary>Indicates a SID that matches an medium level of trust label.</summary>
		WinMediumLabelSid,

		/// <summary>Indicates a SID that matches a high level of trust label.</summary>
		WinHighLabelSid,

		/// <summary>Indicates a SID that matches a system label.</summary>
		WinSystemLabelSid,

		/// <summary>Indicates a SID that matches a write restricted code group.</summary>
		WinWriteRestrictedCodeSid,

		/// <summary>Indicates a SID that matches a creator and owner rights group.</summary>
		WinCreatorOwnerRightsSid,

		/// <summary>Indicates a SID that matches a cacheable principals group.</summary>
		WinCacheablePrincipalsGroupSid,

		/// <summary>Indicates a SID that matches a non-cacheable principals group.</summary>
		WinNonCacheablePrincipalsGroupSid,

		/// <summary>Indicates a SID that matches an enterprise wide read-only controllers group.</summary>
		WinEnterpriseReadonlyControllersSid,

		/// <summary>Indicates a SID that matches an account read-only controllers group.</summary>
		WinAccountReadonlyControllersSid,

		/// <summary>Indicates a SID that matches an event log readers group.</summary>
		WinBuiltinEventLogReadersGroup,

		/// <summary>Indicates a SID that matches a read-only enterprise domain controller.</summary>
		WinNewEnterpriseReadonlyControllersSid,

		/// <summary>Indicates a SID that matches the built-in DCOM certification services access group.</summary>
		WinBuiltinCertSvcDComAccessGroup,

		/// <summary>
		/// Indicates a SID that matches the medium plus integrity label. Windows Server 2008 R2, Windows 7, Windows Server 2008, Windows
		/// Vista, Windows Server 2003 and Windows XP: This value is not available.
		/// </summary>
		WinMediumPlusLabelSid,

		/// <summary>
		/// Indicates a SID that matches a local logon group. Windows Server 2008 R2, Windows 7, Windows Server 2008, Windows Vista,
		/// Windows Server 2003 and Windows XP: This value is not available.
		/// </summary>
		WinLocalLogonSid,

		/// <summary>
		/// Indicates a SID that matches a console logon group. Windows Server 2008 R2, Windows 7, Windows Server 2008, Windows Vista,
		/// Windows Server 2003 and Windows XP: This value is not available.
		/// </summary>
		WinConsoleLogonSid,

		/// <summary>Undocumented</summary>
		WinThisOrganizationCertificateSid,

		/// <summary>
		/// Indicates a SID that matches the application package authority. Windows Server 2008 R2, Windows 7, Windows Server 2008,
		/// Windows Vista, Windows Server 2003 and Windows XP: This value is not available.
		/// </summary>
		WinApplicationPackageAuthoritySid,

		/// <summary>Undocumented</summary>
		WinBuiltinAnyPackageSid,

		/// <summary>
		/// Indicates a SID of Internet client capability for app containers. Windows Server 2008 R2, Windows 7, Windows Server 2008,
		/// Windows Vista, Windows Server 2003 and Windows XP: This value is not available.
		/// </summary>
		WinCapabilityInternetClientSid,

		/// <summary>Undocumented</summary>
		WinCapabilityInternetClientServerSid,

		/// <summary>
		/// Indicates a SID of private network client and server capability for app containers. Windows Server 2008 R2, Windows 7,
		/// Windows Server 2008, Windows Vista, Windows Server 2003 and Windows XP: This value is not available.
		/// </summary>
		WinCapabilityPrivateNetworkClientServerSid,

		/// <summary>Undocumented</summary>
		WinCapabilityPicturesLibrarySid,

		/// <summary>
		/// Indicates a SID for videos library capability for app containers. Windows Server 2008 R2, Windows 7, Windows Server 2008,
		/// Windows Vista, Windows Server 2003 and Windows XP: This value is not available.
		/// </summary>
		WinCapabilityVideosLibrarySid,

		/// <summary>Undocumented</summary>
		WinCapabilityMusicLibrarySid,

		/// <summary>
		/// Indicates a SID for documents library capability for app containers. Windows Server 2008 R2, Windows 7, Windows Server 2008,
		/// Windows Vista, Windows Server 2003 and Windows XP: This value is not available.
		/// </summary>
		WinCapabilityDocumentsLibrarySid,

		/// <summary>Undocumented</summary>
		WinCapabilitySharedUserCertificatesSid,

		/// <summary>
		/// Indicates a SID for Windows credentials capability for app containers. Windows Server 2008 R2, Windows 7, Windows Server
		/// 2008, Windows Vista, Windows Server 2003 and Windows XP: This value is not available.
		/// </summary>
		WinCapabilityEnterpriseAuthenticationSid,

		/// <summary>Undocumented</summary>
		WinCapabilityRemovableStorageSid,

		/// <summary/>
		WinBuiltinRDSRemoteAccessServersSid,

		/// <summary/>
		WinBuiltinRDSEndpointServersSid,

		/// <summary/>
		WinBuiltinRDSManagementServersSid,

		/// <summary/>
		WinUserModeDriversSid,

		/// <summary/>
		WinBuiltinHyperVAdminsSid,

		/// <summary/>
		WinAccountCloneableControllersSid,

		/// <summary/>
		WinBuiltinAccessControlAssistanceOperatorsSid,

		/// <summary/>
		WinBuiltinRemoteManagementUsersSid,

		/// <summary/>
		WinAuthenticationAuthorityAssertedSid,

		/// <summary/>
		WinAuthenticationServiceAssertedSid,

		/// <summary/>
		WinLocalAccountSid,

		/// <summary/>
		WinLocalAccountAndAdministratorSid,

		/// <summary/>
		WinAccountProtectedUsersSid,

		/// <summary/>
		WinCapabilityAppointmentsSid,

		/// <summary/>
		WinCapabilityContactsSid,

		/// <summary/>
		WinAccountDefaultSystemManagedSid,

		/// <summary/>
		WinBuiltinDefaultSystemManagedGroupSid,

		/// <summary/>
		WinBuiltinStorageReplicaAdminsSid,

		/// <summary/>
		WinAccountKeyAdminsSid,

		/// <summary/>
		WinAccountEnterpriseKeyAdminsSid,

		/// <summary/>
		WinAuthenticationKeyTrustSid,

		/// <summary/>
		WinAuthenticationKeyPropertyMFASid,

		/// <summary/>
		WinAuthenticationKeyPropertyAttestationSid,

		/// <summary/>
		WinAuthenticationFreshKeyAuthSid,

		/// <summary/>
		WinBuiltinDeviceOwnersSid,
	}

	/// <summary>Interface to identify the various ACE types.</summary>
	public interface IAccessControlEntry
	{
	}

	/// <summary>Interface to identify the various object ACE types.</summary>
	public interface IObjectAccessControlEntry : IAccessControlEntry
	{
	}

	/// <summary>
	/// The <c>ACCESS_ALLOWED_ACE</c> structure defines an access control entry (ACE) for the discretionary access control list (DACL)
	/// that controls access to an object. An access-allowed ACE allows access to an object for a specific trustee identified by a
	/// security identifier (SID).
	/// </summary>
	/// <remarks>
	/// <para>
	/// ACE structures must be aligned on <c>DWORD</c> boundaries. All Windows memory-management functions return <c>DWORD</c>-aligned
	/// handles to memory.
	/// </para>
	/// <para>
	/// The access rights specified by the <c>Mask</c> member are granted to any trustee that possesses an enabled SID that matches the
	/// SID stored in the <c>SidStart</c> member.
	/// </para>
	/// <para>
	/// An <c>ACCESS_ALLOWED_ACE</c> structure can be created in an access control list (ACL) by a call to the AddAccessAllowedAce or
	/// AddAccessAllowedAceEx function. When these functions are used, the correct amount of memory needed to accommodate the trustee's
	/// SID is allocated and the values of the <c>Header.AceType</c> and <c>Header.AceSize</c> members are set automatically. If the
	/// <c>AddAccessAllowedAceEx</c> function is used, the <c>Header.AceFlags</c> member is also set. When an <c>ACCESS_ALLOWED_ACE</c>
	/// structure is created outside an ACL, sufficient memory must be allocated to accommodate the complete SID of the trustee in the
	/// <c>SidStart</c> member and the contiguous memory following it, and the values of the <c>Header.AceType</c>,
	/// <c>Header.AceFlags</c>, and <c>Header.AceSize</c> members must be set explicitly by the application.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/winnt/ns-winnt-access_allowed_ace typedef struct _ACCESS_ALLOWED_ACE {
	// ACE_HEADER Header; ACCESS_MASK Mask; DWORD SidStart; } ACCESS_ALLOWED_ACE;
	[PInvokeData("winnt.h", MSDNShortId = "002a3fa7-02a3-4832-948e-b048f5f5818f")]
	[StructLayout(LayoutKind.Sequential)]
	public struct ACCESS_ALLOWED_ACE : IAccessControlEntry
	{
		/// <summary>
		/// ACE_HEADER structure that specifies the size and type of ACE. It also contains flags that control inheritance of the ACE by
		/// child objects. The AceType member of the ACE_HEADER structure should be set to ACCESS_ALLOWED_ACE_TYPE, and the AceSize
		/// member should be set to the total number of bytes allocated for the ACCESS_ALLOWED_ACE structure.
		/// </summary>
		public ACE_HEADER Header;

		/// <summary>Specifies an ACCESS_MASK structure that specifies the access rights granted by this ACE.</summary>
		public ACCESS_MASK Mask;

		/// <summary>
		/// The first DWORD of a trustee's SID. The remaining bytes of the SID are stored in contiguous memory after the SidStart member.
		/// This SID can be appended with application data.
		/// </summary>
		public uint SidStart;
	}

	/// <summary>
	/// <para>
	/// The <c>ACCESS_ALLOWED_CALLBACK_ACE</c> structure defines an access control entry (ACE) for the discretionary access control list
	/// (DACL) that controls access to an object. An access-allowed ACE allows access to an object for a specific trustee identified by a
	/// security identifier (SID).
	/// </para>
	/// <para>
	/// When the AuthzAccessCheck function is called, each <c>ACCESS_ALLOWED_CALLBACK_ACE</c> structure contained in the DACL of a
	/// SECURITY_DESCRIPTOR structure passed through a pointer to the <c>AuthzAccessCheck</c> function invokes a call to the
	/// application-defined AuthzAccessCheckCallback function, in which a pointer to the <c>ACCESS_ALLOWED_CALLBACK_ACE</c> structure
	/// found is passed in the pAce parameter.
	/// </para>
	/// </summary>
	/// <remarks>
	/// <para>
	/// ACE structures must be aligned on <c>DWORD</c> boundaries. All Windows memory-management functions return <c>DWORD</c>-aligned
	/// handles to memory.
	/// </para>
	/// <para>
	/// The access rights specified by the <c>Mask</c> member are granted to any trustee that possesses an enabled SID that matches the
	/// SID stored in the <c>SidStart</c> member.
	/// </para>
	/// <para>
	/// When an <c>ACCESS_ALLOWED_CALLBACK_ACE</c> structure is created, sufficient memory must be allocated to accommodate the complete
	/// SID of the trustee in the <c>SidStart</c> member and the contiguous memory that follows it.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/winnt/ns-winnt-access_allowed_callback_ace typedef struct
	// _ACCESS_ALLOWED_CALLBACK_ACE { ACE_HEADER Header; ACCESS_MASK Mask; DWORD SidStart; } ACCESS_ALLOWED_CALLBACK_ACE, *PACCESS_ALLOWED_CALLBACK_ACE;
	[PInvokeData("winnt.h", MSDNShortId = "0dbca19b-4b54-4c55-920a-c00335692d68")]
	[StructLayout(LayoutKind.Sequential)]
	public struct ACCESS_ALLOWED_CALLBACK_ACE : IAccessControlEntry
	{
		/// <summary>
		/// ACE_HEADER structure that specifies the size and type of ACE. It also contains flags that control inheritance of the ACE by
		/// child objects. The <c>AceType</c> member of the <c>ACE_HEADER</c> structure should be set to
		/// ACCESS_ALLOWED_CALLBACK_ACE_TYPE, and the <c>AceSize</c> member should be set to the total number of bytes allocated for the
		/// <c>ACCESS_ALLOWED_CALLBACK_ACE</c> structure.
		/// </summary>
		public ACE_HEADER Header;

		/// <summary>Specifies an ACCESS_MASK structure that specifies the access rights granted by this ACE.</summary>
		public ACCESS_MASK Mask;

		/// <summary>The first <c>DWORD</c> of a trustee's SID.</summary>
		public uint SidStart;
	}

	/// <summary>
	/// <para>
	/// The <c>ACCESS_ALLOWED_CALLBACK_OBJECT_ACE</c> structure defines an access control entry (ACE) that controls allowed access to an
	/// object, property set, or property. The ACE contains a set of access rights, a <c>GUID</c> that identifies the type of object, and
	/// a security identifier (SID) that identifies the trustee to whom the system will grant access. The ACE also contains a <c>GUID</c>
	/// and a set of flags that control inheritance of the ACE by child objects.
	/// </para>
	/// <para>
	/// When the AuthzAccessCheck function is called, each <c>ACCESS_ALLOWED_CALLBACK_OBJECT_ACE</c> structure contained in the DACL of a
	/// SECURITY_DESCRIPTOR structure passed through a pointer to the <c>AuthzAccessCheck</c> function invokes a call to the
	/// application-defined AuthzAccessCheckCallback function, in which a pointer to the <c>ACCESS_ALLOWED_CALLBACK_OBJECT_ACE</c>
	/// structure found is passed in the pAce parameter.
	/// </para>
	/// </summary>
	/// <remarks>
	/// <para>
	/// If neither the <c>ObjectType</c> nor <c>InheritedObjectType</c><c>GUID</c> is specified, the
	/// <c>ACCESS_ALLOWED_CALLBACK_OBJECT_ACE</c> structure has the same semantics as those used by the ACCESS_ALLOWED_CALLBACK_ACE
	/// structure. In that case, use the <c>ACCESS_ALLOWED_CALLBACK_ACE</c> structure because it is smaller and more efficient.
	/// </para>
	/// <para>
	/// An ACL that contains an <c>ACCESS_ALLOWED_CALLBACK_OBJECT_ACE</c> must specify the ACL_REVISION_DS revision number in its ACL header.
	/// </para>
	/// <para>
	/// The access rights specified by the <c>Mask</c> member are granted to any trustee that possesses an enabled SID that matches the
	/// SID stored in the <c>SidStart</c> member.
	/// </para>
	/// <para>
	/// When an <c>ACCESS_ALLOWED_CALLBACK_OBJECT_ACE</c> structure is created, sufficient memory must be allocated to accommodate the
	/// GUID structures in the <c>ObjectType</c> and <c>InheritedObjectType</c> members, if one or both of them exists, as well as to
	/// accommodate the complete SID of the trustee in the <c>SidStart</c> member and the contiguous memory that follows it.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/winnt/ns-winnt-access_allowed_callback_object_ace typedef struct
	// _ACCESS_ALLOWED_CALLBACK_OBJECT_ACE { ACE_HEADER Header; ACCESS_MASK Mask; DWORD Flags; GUID ObjectType; GUID InheritedObjectType;
	// DWORD SidStart; } ACCESS_ALLOWED_CALLBACK_OBJECT_ACE, *PACCESS_ALLOWED_CALLBACK_OBJECT_ACE;
	[PInvokeData("winnt.h", MSDNShortId = "83b00ef3-f7b2-455e-8f3f-01b1da6024b7")]
	[StructLayout(LayoutKind.Sequential)]
	public struct ACCESS_ALLOWED_CALLBACK_OBJECT_ACE : IObjectAccessControlEntry
	{
		/// <summary>
		/// ACE_HEADER structure that specifies the size and type of ACE. It also contains flags that control inheritance of the ACE by
		/// child objects. The <c>AceType</c> member of the <c>ACE_HEADER</c> structure should be set to
		/// ACCESS_ALLOWED_CALLBACK_OBJECT_ACE_TYPE, and the <c>AceSize</c> member should be set to the total number of bytes allocated
		/// for the <c>ACCESS_ALLOWED_CALLBACK_OBJECT_ACE</c> structure.
		/// </summary>
		public ACE_HEADER Header;

		/// <summary>An ACCESS_MASK that specifies the access rights the system will allow to the trustee.</summary>
		public ACCESS_MASK Mask;

		/// <summary>
		/// <para>
		/// A set of bit flags that indicate whether the <c>ObjectType</c> and <c>InheritedObjectType</c> members are present. This
		/// parameter can be one or more of the following values.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>0</term>
		/// <term>Neither ObjectType nor InheritedObjectType are present. The SidStart member follows immediately after the Flags member.</term>
		/// </item>
		/// <item>
		/// <term>ACE_OBJECT_TYPE_PRESENT</term>
		/// <term>
		/// ObjectType is present and contains a GUID. If this value is not specified, the InheritedObjectType member follows immediately
		/// after the Flags member.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ACE_INHERITED_OBJECT_TYPE_PRESENT</term>
		/// <term>
		/// InheritedObjectType is present and contains a GUID. If this value is not specified, all types of child objects can inherit
		/// the ACE.
		/// </term>
		/// </item>
		/// </list>
		/// </summary>
		public ObjectAceFlags Flags;

		/// <summary>
		/// <para>
		/// This member exists only if the ACE_OBJECT_TYPE_PRESENT bit is set in the <c>Flags</c> member. Otherwise, the
		/// <c>InheritedObjectType</c> member follows immediately after the <c>Flags</c> member.
		/// </para>
		/// <para>
		/// If this member exists, it is a GUID structure that identifies a property set, property, extended right, or type of child
		/// object. The purpose of this <c>GUID</c> depends on the access rights specified in the <c>Mask</c> member.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>ADS_RIGHT_DS_CONTROL_ACCESS</term>
		/// <term>The ObjectType GUID identifies an extended access right.</term>
		/// </item>
		/// <item>
		/// <term>ADS_RIGHT_DS_CREATE_CHILD</term>
		/// <term>
		/// The ObjectType GUID identifies a type of child object. The ACE controls the trustee's right to create this type of child object.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ADS_RIGHT_DS_READ_PROP</term>
		/// <term>
		/// The ObjectType GUID identifies a property set or property of the object. The ACE controls the trustee's right to read the
		/// property or property set.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ADS_RIGHT_DS_WRITE_PROP</term>
		/// <term>
		/// The ObjectType GUID identifies a property set or property of the object. The ACE controls the trustee's right to write the
		/// property or property set.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ADS_RIGHT_DS_SELF</term>
		/// <term>The ObjectType GUID identifies a validated write.</term>
		/// </item>
		/// </list>
		/// </summary>
		public Guid ObjectType;

		/// <summary>
		/// <para>This member exists only if the ACE_INHERITED_OBJECT_TYPE_PRESENT bit is set in the <c>Flags</c> member.</para>
		/// <para>
		/// If this member exists, it is a GUID structure that identifies the type of child object that can inherit the ACE. Inheritance
		/// is also controlled by the inheritance flags in the ACE_HEADER, as well as by any protection against inheritance placed on the
		/// child objects.
		/// </para>
		/// <para>
		/// The offset of this member can vary. If the <c>Flags</c> member does not contain the ACE_OBJECT_TYPE_PRESENT flag, the
		/// <c>InheritedObjectType</c> member starts at the offset specified by the <c>ObjectType</c> member.
		/// </para>
		/// </summary>
		public Guid InheritedObjectType;

		/// <summary>
		/// The first <c>DWORD</c> of a trustee's SID. The remaining bytes of the SID are stored in contiguous memory after the
		/// <c>SidStart</c> member. This SID can be appended with application data.
		/// </summary>
		public uint SidStart;
	}

	/// <summary>
	/// The <c>ACCESS_ALLOWED_OBJECT_ACE</c> structure defines an access control entry (ACE) that controls allowed access to an object, a
	/// property set, or property. The ACE contains a set of access rights, a <c>GUID</c> that identifies the type of object, and a
	/// security identifier (SID) that identifies the trustee to whom the system will grant access. The ACE also contains a <c>GUID</c>
	/// and a set of flags that control inheritance of the ACE by child objects.
	/// </summary>
	/// <remarks>
	/// <para>
	/// If neither the <c>ObjectType</c> nor <c>InheritedObjectType</c> GUID is specified, the <c>ACCESS_ALLOWED_OBJECT_ACE</c> structure
	/// has the same semantics as those used by the ACCESS_ALLOWED_ACE structure. In that case, use the <c>ACCESS_ALLOWED_ACE</c>
	/// structure because it is smaller and more efficient.
	/// </para>
	/// <para>An ACL that contains an <c>ACCESS_ALLOWED_OBJECT_ACE</c> must specify the ACL_REVISION_DS revision number in its ACL header.</para>
	/// <para>
	/// The access rights specified by the <c>Mask</c> member are granted to any trustee that possesses an enabled SID that matches the
	/// SID stored in the <c>SidStart</c> member.
	/// </para>
	/// <para>
	/// An <c>ACCESS_ALLOWED_OBJECT_ACE</c> structure can be created in an access control list (ACL) by a call to the
	/// AddAccessAllowedObjectAce function. When this function is used, the correct amount of memory needed to accommodate the GUID
	/// structures in the <c>ObjectType</c> and <c>InheritedObjectType</c> members, if one or both of them exists, as well as to
	/// accommodate the trustee's SID is automatically allocated. In addition, the values of the <c>Header.AceType</c> and
	/// <c>Header.AceSize</c> members are set automatically. When an <c>ACCESS_ALLOWED_OBJECT_ACE</c> structure is created outside an
	/// ACL, sufficient memory must be allocated to accommodate the GUID structures in the <c>ObjectType</c> and
	/// <c>InheritedObjectType</c> members, if one or both of them exists, as well as to accommodate the complete SID of the trustee in
	/// the <c>SidStart</c> member and the contiguous memory following it. In addition, the values of the <c>Header.AceType</c> and
	/// <c>Header.AceSize</c> members must be set explicitly by the application.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winnt/ns-winnt-_access_allowed_object_ace typedef struct
	// _ACCESS_ALLOWED_OBJECT_ACE { ACE_HEADER Header; ACCESS_MASK Mask; DWORD Flags; GUID ObjectType; GUID InheritedObjectType; DWORD
	// SidStart; } ACCESS_ALLOWED_OBJECT_ACE, *PACCESS_ALLOWED_OBJECT_ACE;
	[PInvokeData("winnt.h", MSDNShortId = "ee91ca50-e81b-4872-95eb-349c2d5be004")]
	[StructLayout(LayoutKind.Sequential)]
	public struct ACCESS_ALLOWED_OBJECT_ACE : IObjectAccessControlEntry
	{
		/// <summary>
		/// ACE_HEADER structure that specifies the size and type of ACE. It also contains flags that control inheritance of the ACE by
		/// child objects. The <c>AceType</c> member of the <c>ACE_HEADER</c> structure should be set to ACCESS_ALLOWED_OBJECT_ACE_TYPE,
		/// and the <c>AceSize</c> member should be set to the total number of bytes allocated for the <c>ACCESS_ALLOWED_OBJECT_ACE</c> structure.
		/// </summary>
		public ACE_HEADER Header;

		/// <summary>An ACCESS_MASK that specifies the access rights the system will allow to the trustee.</summary>
		public ACCESS_MASK Mask;

		/// <summary>
		/// <para>
		/// A set of bit flags that indicate whether the <c>ObjectType</c> and <c>InheritedObjectType</c> members are present. This
		/// parameter can be one or more of the following values.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>0</term>
		/// <term>Neither ObjectType nor InheritedObjectType are present. The SidStart member follows immediately after the Flags member.</term>
		/// </item>
		/// <item>
		/// <term>ACE_OBJECT_TYPE_PRESENT</term>
		/// <term>
		/// ObjectType is present and contains a GUID. If this value is not specified, the InheritedObjectType member follows immediately
		/// after the Flags member.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ACE_INHERITED_OBJECT_TYPE_PRESENT</term>
		/// <term>
		/// InheritedObjectType is present and contains a GUID. If this value is not specified, all types of child objects can inherit
		/// the ACE.
		/// </term>
		/// </item>
		/// </list>
		/// </summary>
		public ObjectAceFlags Flags;

		/// <summary>
		/// <para>
		/// This member exists only if the ACE_OBJECT_TYPE_PRESENT bit is set in the <c>Flags</c> member. Otherwise, the
		/// <c>InheritedObjectType</c> member follows immediately after the <c>Flags</c> member.
		/// </para>
		/// <para>
		/// If this member exists, it is a GUID structure that identifies a property set, property, extended right, or type of child
		/// object. The purpose of this <c>GUID</c> depends on the access rights specified in the <c>Mask</c> member.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>ADS_RIGHT_DS_CONTROL_ACCESS</term>
		/// <term>The ObjectType GUID identifies an extended access right.</term>
		/// </item>
		/// <item>
		/// <term>ADS_RIGHT_DS_CREATE_CHILD</term>
		/// <term>
		/// The ObjectType GUID identifies a type of child object. The ACE controls the trustee's right to create this type of child object.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ADS_RIGHT_DS_READ_PROP</term>
		/// <term>
		/// The ObjectType GUID identifies a property set or property of the object. The ACE controls the trustee's right to read the
		/// property or property set.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ADS_RIGHT_DS_WRITE_PROP</term>
		/// <term>
		/// The ObjectType GUID identifies a property set or property of the object. The ACE controls the trustee's right to write the
		/// property or property set.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ADS_RIGHT_DS_SELF</term>
		/// <term>The ObjectType GUID identifies a validated write.</term>
		/// </item>
		/// </list>
		/// </summary>
		public Guid ObjectType;

		/// <summary>
		/// <para>This member exists only if the ACE_INHERITED_OBJECT_TYPE_PRESENT bit is set in the <c>Flags</c> member.</para>
		/// <para>
		/// If this member exists, it is a GUID structure that identifies the type of child object that can inherit the ACE. Inheritance
		/// is also controlled by the inheritance flags in the ACE_HEADER, as well as by any protection against inheritance placed on the
		/// child objects.
		/// </para>
		/// <para>
		/// The offset of this member can vary. If the <c>Flags</c> member does not contain the ACE_OBJECT_TYPE_PRESENT flag, the
		/// <c>InheritedObjectType</c> member starts at the offset specified by the <c>ObjectType</c> member.
		/// </para>
		/// </summary>
		public Guid InheritedObjectType;

		/// <summary>
		/// <para>
		/// Specifies the first <c>DWORD</c> of a SID that identifies the trustee to whom the access rights are granted. The remaining
		/// bytes of the SID are stored in contiguous memory after the <c>SidStart</c> member. This SID can be appended with application data.
		/// </para>
		/// <para>
		/// The offset of this member can vary. If the <c>Flags</c> member is zero, the <c>SidStart</c> member starts at the offset
		/// specified by the <c>ObjectType</c> member. If <c>Flags</c> contains only one flag (either ACE_OBJECT_TYPE_PRESENT or
		/// ACE_INHERITED_OBJECT_TYPE_PRESENT), the <c>SidStart</c> member starts at the offset specified by the
		/// <c>InheritedObjectType</c> member.
		/// </para>
		/// </summary>
		public uint SidStart;
	}

	/// <summary>
	/// The <c>ACCESS_DENIED_ACE</c> structure defines an access control entry (ACE) for the discretionary access control list (DACL)
	/// that controls access to an object. An access-denied ACE denies access to an object for a specific trustee identified by a
	/// security identifier (SID).
	/// </summary>
	/// <remarks>
	/// <para>
	/// ACE structures must be aligned on <c>DWORD</c> boundaries. All Windows memory-management functions return <c>DWORD</c>-aligned
	/// handles to memory.
	/// </para>
	/// <para>
	/// The access rights specified by the <c>Mask</c> member are denied to any trustee that possesses an enabled SID that matches the
	/// SID stored in the <c>SidStart</c> member.
	/// </para>
	/// <para>
	/// An <c>ACCESS_DENIED_ACE</c> structure can be created in an access control list (ACL) by a call to the AddAccessDeniedAce or
	/// AddAccessDeniedAceEx function. When these functions are used, the correct amount of memory needed to accommodate the trustee's
	/// SID is allocated and the values of the <c>Header.AceType</c> and <c>Header.AceSize</c> members are set automatically. If the
	/// <c>AddAccessDeniedAceEx</c> function is used, the <c>Header.AceFlags</c> member is also set. When an <c>ACCESS_DENIED_ACE</c>
	/// structure is created outside an ACL, sufficient memory must be allocated to accommodate the complete SID of the trustee in the
	/// <c>SidStart</c> member and the contiguous memory following it, and the values of the <c>Header.AceType</c>,
	/// <c>Header.AceFlags</c>, and <c>Header.AceSize</c> members must be set explicitly by the application.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/winnt/ns-winnt-access_denied_ace typedef struct _ACCESS_DENIED_ACE { ACE_HEADER
	// Header; ACCESS_MASK Mask; DWORD SidStart; } ACCESS_DENIED_ACE;
	[PInvokeData("winnt.h", MSDNShortId = "d76a92d0-ccd0-4e73-98b6-43bcd661134d")]
	[StructLayout(LayoutKind.Sequential)]
	public struct ACCESS_DENIED_ACE : IAccessControlEntry
	{
		/// <summary>
		/// An ACE_HEADER structure that specifies the size and type of ACE. It also contains flags that control inheritance of the ACE
		/// by child objects. The <c>AceType</c> member of the <c>ACE_HEADER</c> structure should be set to ACCESS_DENIED_ACE_TYPE, and
		/// the <c>AceSize</c> member should be set to the total number of bytes allocated for the <c>ACCESS_DENIED_ACE</c> structure.
		/// </summary>
		public ACE_HEADER Header;

		/// <summary>An ACCESS_MASK structure that specifies the access rights explicitly denied by this ACE.</summary>
		public ACCESS_MASK Mask;

		/// <summary>
		/// The first <c>DWORD</c> of a trustee's SID. The remaining bytes of the SID are stored in contiguous memory after the
		/// <c>SidStart</c> member. This SID can be appended with application data.
		/// </summary>
		public uint SidStart;
	}

	/// <summary>
	/// <para>
	/// The <c>ACCESS_DENIED_CALLBACK_ACE</c> structure defines an access control entry (ACE) for the discretionary access control list
	/// (DACL) that controls access to an object. An access-denied ACE denies access to an object for a specific trustee identified by a
	/// security identifier (SID).
	/// </para>
	/// <para>
	/// When the AuthzAccessCheck function is called, each <c>ACCESS_DENIED_CALLBACK_ACE</c> structure contained in the DACL of a
	/// SECURITY_DESCRIPTOR structure passed through a pointer to the <c>AuthzAccessCheck</c> function invokes a call to the
	/// application–defined AuthzAccessCheckCallback function, in which a pointer to the <c>ACCESS_DENIED_CALLBACK_ACE</c> structure
	/// found is passed in the pAce parameter.
	/// </para>
	/// </summary>
	/// <remarks>
	/// <para>
	/// ACE structures must be aligned on <c>DWORD</c> boundaries. All Windows memory-management functions return <c>DWORD</c>-aligned
	/// handles to memory.
	/// </para>
	/// <para>
	/// The access rights specified by the <c>Mask</c> member are granted to any trustee that possesses an enabled SID that matches the
	/// SID stored in the <c>SidStart</c> member.
	/// </para>
	/// <para>
	/// When an <c>ACCESS_DENIED_CALLBACK_ACE</c> structure is created, sufficient memory must be allocated to accommodate the complete
	/// SID of the trustee in the <c>SidStart</c> member and the contiguous memory that follows it.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/winnt/ns-winnt-access_denied_callback_ace typedef struct
	// _ACCESS_DENIED_CALLBACK_ACE { ACE_HEADER Header; ACCESS_MASK Mask; DWORD SidStart; } ACCESS_DENIED_CALLBACK_ACE, *PACCESS_DENIED_CALLBACK_ACE;
	[PInvokeData("winnt.h", MSDNShortId = "6df77b27-7aa3-455f-bffe-eeb90ba1bc15")]
	[StructLayout(LayoutKind.Sequential)]
	public struct ACCESS_DENIED_CALLBACK_ACE : IAccessControlEntry
	{
		/// <summary>
		/// ACE_HEADER structure that specifies the size and type of ACE. It also contains flags that control inheritance of the ACE by
		/// child objects. The <c>AceType</c> member of the <c>ACE_HEADER</c> structure should be set to ACCESS_DENIED_CALLBACK_ACE_TYPE,
		/// and the <c>AceSize</c> member should be set to the total number of bytes allocated for the <c>ACCESS_DENIED_CALLBACK_ACE</c> structure.
		/// </summary>
		public ACE_HEADER Header;

		/// <summary>Specifies an ACCESS_MASK structure that specifies the access rights explicitly denied by this ACE.</summary>
		public ACCESS_MASK Mask;

		/// <summary>
		/// The first <c>DWORD</c> of a trustee's SID. The remaining bytes of the SID are stored in contiguous memory after the
		/// <c>SidStart</c> member. This SID can be appended with application data.
		/// </summary>
		public uint SidStart;
	}

	/// <summary>
	/// <para>
	/// The <c>ACCESS_DENIED_CALLBACK_OBJECT_ACE</c> structure defines an access control entry (ACE) that controls denied access to an
	/// object, a property set, or property. The ACE contains a set of access rights, a <c>GUID</c> that identifies the type of object,
	/// and a security identifier (SID) that identifies the trustee to whom the system will deny access. The ACE also contains a
	/// <c>GUID</c> and a set of flags that control inheritance of the ACE by child objects.
	/// </para>
	/// <para>
	/// When the AuthzAccessCheck function is called, each <c>ACCESS_DENIED_CALLBACK_OBJECT_ACE</c> structure contained in the DACL of a
	/// SECURITY_DESCRIPTOR structure passed through a pointer to the <c>AuthzAccessCheck</c> function invokes a call to the
	/// application–defined AuthzAccessCheckCallback function, in which a pointer to the <c>ACCESS_DENIED_CALLBACK_OBJECT_ACE</c>
	/// structure found is passed in the pAce parameter.
	/// </para>
	/// </summary>
	/// <remarks>
	/// <para>
	/// If neither the <c>ObjectType</c> nor <c>InheritedObjectType</c><c>GUID</c> is specified, the
	/// <c>ACCESS_DENIED_CALLBACK_OBJECT_ACE</c> structure has the same semantics as those used by the ACCESS_DENIED_CALLBACK_ACE
	/// structure. In that case, use the <c>ACCESS_DENIED_CALLBACK_ACE</c> structure because it is smaller and more efficient.
	/// </para>
	/// <para>
	/// An ACL that contains an <c>ACCESS_DENIED_CALLBACK_OBJECT_ACE</c> must specify the ACL_REVISION_DS revision number in its ACL header.
	/// </para>
	/// <para>
	/// The access rights specified by the <c>Mask</c> member are denied to any trustee that possesses an enabled SID that matches the
	/// SID stored in the <c>SidStart</c> member.
	/// </para>
	/// <para>
	/// When an <c>ACCESS_DENIED_CALLBACK_OBJECT_ACE</c> structure is created, sufficient memory must be allocated to accommodate the
	/// GUID structures in the <c>ObjectType</c> and <c>InheritedObjectType</c> members, if one or both of them exists, as well as to
	/// accommodate the complete SID of the trustee in the <c>SidStart</c> member and the contiguous memory that follows it.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/winnt/ns-winnt-access_denied_callback_object_ace typedef struct
	// _ACCESS_DENIED_CALLBACK_OBJECT_ACE { ACE_HEADER Header; ACCESS_MASK Mask; DWORD Flags; GUID ObjectType; GUID InheritedObjectType;
	// DWORD SidStart; } ACCESS_DENIED_CALLBACK_OBJECT_ACE, *PACCESS_DENIED_CALLBACK_OBJECT_ACE;
	[PInvokeData("winnt.h", MSDNShortId = "945d9c3b-922f-481d-bb1d-3dca50fb9edb")]
	[StructLayout(LayoutKind.Sequential)]
	public struct ACCESS_DENIED_CALLBACK_OBJECT_ACE : IObjectAccessControlEntry
	{
		/// <summary>
		/// ACE_HEADER structure that specifies the size and type of ACE. It contains flags that control inheritance of the ACE by child
		/// objects. The <c>AceType</c> member of the <c>ACE_HEADER</c> structure should be set to ACCESS_DENIED_CALLBACK_ACE_TYPE, and
		/// the <c>AceSize</c> member should be set to the total number of bytes allocated for the
		/// <c>ACCESS_DENIED_CALLBACK_OBJECT_ACE</c> structure.
		/// </summary>
		public ACE_HEADER Header;

		/// <summary>An ACCESS_MASK that specifies the access rights the system will deny to the trustee.</summary>
		public ACCESS_MASK Mask;

		/// <summary>
		/// <para>
		/// A set of bit flags that indicate whether the <c>ObjectType</c> and <c>InheritedObjectType</c> members are present. This
		/// parameter can be one or more of the following values.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>0</term>
		/// <term>Neither ObjectType nor InheritedObjectType are present. The SidStart member follows immediately after the Flags member.</term>
		/// </item>
		/// <item>
		/// <term>ACE_OBJECT_TYPE_PRESENT</term>
		/// <term>
		/// ObjectType is present and contains a GUID. If this value is not specified, the InheritedObjectType member follows immediately
		/// after the Flags member.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ACE_INHERITED_OBJECT_TYPE_PRESENT</term>
		/// <term>
		/// InheritedObjectType is present and contains a GUID. If this value is not specified, all types of child objects can inherit
		/// the ACE.
		/// </term>
		/// </item>
		/// </list>
		/// </summary>
		public ObjectAceFlags Flags;

		/// <summary>
		/// <para>
		/// This member exists only if the ACE_OBJECT_TYPE_PRESENT bit is set in the <c>Flags</c> member. Otherwise, the
		/// <c>InheritedObjectType</c> member follows immediately after the <c>Flags</c> member.
		/// </para>
		/// <para>
		/// If this member exists, it is a GUID structure that identifies a property set, property, extended right, or type of child
		/// object. The purpose of this <c>GUID</c> depends on the access rights specified in the <c>Mask</c> member.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>ADS_RIGHT_DS_CONTROL_ACCESS</term>
		/// <term>The ObjectType GUID identifies an extended access right.</term>
		/// </item>
		/// <item>
		/// <term>ADS_RIGHT_DS_CREATE_CHILD</term>
		/// <term>
		/// The ObjectType GUID identifies a type of child object. The ACE controls the trustee's right to create this type of child object.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ADS_RIGHT_DS_READ_PROP</term>
		/// <term>
		/// The ObjectType GUID identifies a property set or property of the object. The ACE controls the trustee's right to read the
		/// property or property set.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ADS_RIGHT_DS_WRITE_PROP</term>
		/// <term>
		/// The ObjectType GUID identifies a property set or property of the object. The ACE controls the trustee's right to write the
		/// property or property set.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ADS_RIGHT_DS_SELF</term>
		/// <term>The ObjectType GUID identifies a validated write.</term>
		/// </item>
		/// </list>
		/// </summary>
		public Guid ObjectType;

		/// <summary>
		/// <para>This member exists only if the ACE_INHERITED_OBJECT_TYPE_PRESENT bit is set in the <c>Flags</c> member.</para>
		/// <para>
		/// If this member exists, it is a GUID structure that identifies the type of child object that can inherit the ACE. Inheritance
		/// is also controlled by the inheritance flags in the ACE_HEADER, as well as by any protection against inheritance placed on the
		/// child objects.
		/// </para>
		/// <para>
		/// The offset of this member can vary. If the <c>Flags</c> member does not contain the ACE_OBJECT_TYPE_PRESENT flag, the
		/// <c>InheritedObjectType</c> member starts at the offset specified by the <c>ObjectType</c> member.
		/// </para>
		/// </summary>
		public Guid InheritedObjectType;

		/// <summary>
		/// The first <c>DWORD</c> of a trustee's SID. The remaining bytes of the SID are stored in contiguous memory after the
		/// <c>SidStart</c> member. This SID can be appended with application data.
		/// </summary>
		public uint SidStart;
	}

	/// <summary>
	/// The <c>ACCESS_DENIED_OBJECT_ACE</c> structure defines an access control entry (ACE) that controls denied access to an object, a
	/// property set, or property. The ACE contains a set of access rights, a <c>GUID</c> that identifies the type of object, and a
	/// security identifier (SID) that identifies the trustee to whom the system will deny access. The ACE also contains a <c>GUID</c>
	/// and a set of flags that control inheritance of the ACE by child objects.
	/// </summary>
	/// <remarks>
	/// <para>
	/// If neither the <c>ObjectType</c> nor <c>InheritedObjectType</c><c>GUID</c> is specified, the <c>ACCESS_DENIED_OBJECT_ACE</c>
	/// structure has the same semantics as those used by the ACCESS_DENIED_ACE structure. In that case, use the <c>ACCESS_DENIED_ACE</c>
	/// structure because it is smaller and more efficient.
	/// </para>
	/// <para>An ACL that contains an <c>ACCESS_DENIED_OBJECT_ACE</c> must specify the ACL_REVISION_DS revision number in its ACL header.</para>
	/// <para>
	/// The access rights specified by the <c>Mask</c> member are denied to any trustee that possesses an enabled SID that matches the
	/// SID stored in the <c>SidStart</c> member.
	/// </para>
	/// <para>
	/// An <c>ACCESS_DENIED_OBJECT_ACE</c> structure can be created in an access control list (ACL) by a call to the
	/// AddAccessDeniedObjectAce function. When this function is used, the correct amount of memory needed to accommodate the GUID
	/// structures in the <c>ObjectType</c> and <c>InheritedObjectType</c> members, if one or both of them exists, as well as to
	/// accommodate the trustee's SID is automatically allocated. In addition, the values of the <c>Header.AceType</c> and
	/// <c>Header.AceSize</c> members are set automatically. When an <c>ACCESS_DENIED_OBJECT_ACE</c> structure is created outside an ACL,
	/// sufficient memory must be allocated to accommodate the GUID structures in the <c>ObjectType</c> and <c>InheritedObjectType</c>
	/// members, if one or both of them exists, as well as to accommodate the complete SID of the trustee in the <c>SidStart</c> member
	/// and the contiguous memory following it. In addition, the values of the <c>Header.AceType</c> and <c>Header.AceSize</c> members
	/// must be set explicitly by the application.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/winnt/ns-winnt-access_denied_object_ace typedef struct
	// _ACCESS_DENIED_OBJECT_ACE { ACE_HEADER Header; ACCESS_MASK Mask; DWORD Flags; GUID ObjectType; GUID InheritedObjectType; DWORD
	// SidStart; } ACCESS_DENIED_OBJECT_ACE, *PACCESS_DENIED_OBJECT_ACE;
	[PInvokeData("winnt.h", MSDNShortId = "80e00c2b-7c31-428d-96c1-c4e3d22619f3")]
	[StructLayout(LayoutKind.Sequential)]
	public struct ACCESS_DENIED_OBJECT_ACE : IObjectAccessControlEntry
	{
		/// <summary>
		/// ACE_HEADER structure that specifies the size and type of ACE. It contains flags that control inheritance of the ACE by child
		/// objects. The <c>AceType</c> member of the <c>ACE_HEADER</c> structure should be set to ACCESS_DENIED_OBJECT_ACE_TYPE, and the
		/// <c>AceSize</c> member should be set to the total number of bytes allocated for the <c>ACCESS_DENIED_OBJECT_ACE</c> structure.
		/// </summary>
		public ACE_HEADER Header;

		/// <summary>An ACCESS_MASK that specifies the access rights the system will deny to the trustee.</summary>
		public ACCESS_MASK Mask;

		/// <summary>
		/// <para>
		/// A set of bit flags that indicate whether the <c>ObjectType</c> and <c>InheritedObjectType</c> members are present. This
		/// parameter can be one or more of the following values.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>0</term>
		/// <term>Neither ObjectType nor InheritedObjectType are present. The SidStart member follows immediately after the Flags member.</term>
		/// </item>
		/// <item>
		/// <term>ACE_OBJECT_TYPE_PRESENT</term>
		/// <term>
		/// ObjectType is present and contains a GUID. If this value is not specified, the InheritedObjectType member follows immediately
		/// after the Flags member.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ACE_INHERITED_OBJECT_TYPE_PRESENT</term>
		/// <term>
		/// InheritedObjectType is present and contains a GUID. If this value is not specified, all types of child objects can inherit
		/// the ACE.
		/// </term>
		/// </item>
		/// </list>
		/// </summary>
		public ObjectAceFlags Flags;

		/// <summary>
		/// <para>
		/// This member exists only if the ACE_OBJECT_TYPE_PRESENT bit is set in the <c>Flags</c> member. Otherwise, the
		/// <c>InheritedObjectType</c> member follows immediately after the <c>Flags</c> member.
		/// </para>
		/// <para>
		/// If this member exists, it is a GUID structure that identifies a property set, property, extended right, or type of child
		/// object. The purpose of this <c>GUID</c> depends on the access rights specified in the <c>Mask</c> member.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>ADS_RIGHT_DS_CONTROL_ACCESS</term>
		/// <term>The ObjectType GUID identifies an extended access right.</term>
		/// </item>
		/// <item>
		/// <term>ADS_RIGHT_DS_CREATE_CHILD</term>
		/// <term>
		/// The ObjectType GUID identifies a type of child object. The ACE controls the trustee's right to create this type of child object.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ADS_RIGHT_DS_READ_PROP</term>
		/// <term>
		/// The ObjectType GUID identifies a property set or property of the object. The ACE controls the trustee's right to read the
		/// property or property set.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ADS_RIGHT_DS_WRITE_PROP</term>
		/// <term>
		/// The ObjectType GUID identifies a property set or property of the object. The ACE controls the trustee's right to write the
		/// property or property set.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ADS_RIGHT_DS_SELF</term>
		/// <term>The ObjectType GUID identifies a validated write.</term>
		/// </item>
		/// </list>
		/// </summary>
		public Guid ObjectType;

		/// <summary>
		/// <para>This member exists only if the ACE_INHERITED_OBJECT_TYPE_PRESENT bit is set in the <c>Flags</c> member.</para>
		/// <para>
		/// If this member exists, it is a GUID structure that identifies the type of child object that can inherit the ACE. Inheritance
		/// is also controlled by the inheritance flags in the ACE_HEADER, as well as by any protection against inheritance placed on the
		/// child objects.
		/// </para>
		/// <para>
		/// The offset of this member can vary. If the <c>Flags</c> member does not contain the ACE_OBJECT_TYPE_PRESENT flag, the
		/// <c>InheritedObjectType</c> member starts at the offset specified by the <c>ObjectType</c> member.
		/// </para>
		/// </summary>
		public Guid InheritedObjectType;

		/// <summary>
		/// <para>
		/// Specifies the first <c>DWORD</c> of a SID that identifies the trustee for whom the access rights are denied. The remaining
		/// bytes of the SID are stored in contiguous memory after the <c>SidStart</c> member. This SID can be appended with application data.
		/// </para>
		/// <para>
		/// The offset of this member can vary. If the <c>Flags</c> member is zero, the <c>SidStart</c> member starts at the offset
		/// specified by the <c>ObjectType</c> member. If <c>Flags</c> contains only one flag (either ACE_OBJECT_TYPE_PRESENT or
		/// ACE_INHERITED_OBJECT_TYPE_PRESENT), the <c>SidStart</c> member starts at the offset specified by the
		/// <c>InheritedObjectType</c> member.
		/// </para>
		/// </summary>
		public uint SidStart;
	}

	/// <summary>The ACE_HEADER structure describes the type and size of an access-control entry (ACE).</summary>
	/// <remarks>
	/// <para>The ACE_HEADER structure is the first member of the various types of ACE structures, such as ACCESS_ALLOWED_ACE.</para>
	/// <para>
	/// System-alarm ACEs are not currently supported. The <c>AceType</c> member cannot specify the SYSTEM_ALARM_ACE_TYPE. Do not use the
	/// SYSTEM_ALARM_ACE structure.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows-hardware/drivers/ddi/content/ntifs/ns-ntifs-_ace_header typedef struct _ACE_HEADER {
	// UCHAR AceType; UCHAR AceFlags; USHORT AceSize; } ACE_HEADER;
	[PInvokeData("ntifs.h", MSDNShortId = "f5f39310-8b15-4d6b-a985-3f25522a16b1")]
	[StructLayout(LayoutKind.Sequential)]
	public struct ACE_HEADER : IComparable<ACE_HEADER>
	{
		/// <summary>
		/// <para>ACE type. This member can be one of the following values:</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>ACCESS_ALLOWED_ACE_TYPE</term>
		/// <term>Access-allowed ACE that uses the ACCESS_ALLOWED_ACE structure.</term>
		/// </item>
		/// <item>
		/// <term>ACCESS_DENIED_ACE_TYPE</term>
		/// <term>Access-denied ACE that uses the ACCESS_DENIED_ACE structure.</term>
		/// </item>
		/// <item>
		/// <term>SYSTEM_AUDIT_ACE_TYPE</term>
		/// <term>System-audit ACE that uses the SYSTEM_AUDIT_ACE structure.</term>
		/// </item>
		/// </list>
		/// </summary>
		public AceType AceType;

		/// <summary>
		/// <para>Set of ACE type-specific control flags. This member can be a combination of the following values:</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>CONTAINER_INHERIT_ACE</term>
		/// <term>
		/// Child objects that are containers, such as directories, inherit the ACE as an effective ACE. The inherited ACE is inheritable
		/// unless the NO_PROPAGATE_INHERIT_ACE bit flag is also set.
		/// </term>
		/// </item>
		/// <item>
		/// <term>FAILED_ACCESS_ACE_FLAG</term>
		/// <term>Used with system-audit ACEs in a SACL to generate audit messages for failed access attempts.</term>
		/// </item>
		/// <item>
		/// <term>INHERIT_ONLY_ACE</term>
		/// <term>
		/// Indicates an inherit-only ACE which does not control access to the object to which it is attached. If this flag is not set,
		/// the ACE is an effective ACE which controls access to the object to which it is attached. Both effective and inherit-only ACEs
		/// can be inherited depending on the state of the other inheritance flags.
		/// </term>
		/// </item>
		/// <item>
		/// <term>INHERITED_ACE</term>
		/// <term>
		/// Microsoft Windows 2000 or later: Indicates that the ACE was inherited. The system sets this bit when it propagates an
		/// inherited ACE to a child object.
		/// </term>
		/// </item>
		/// <item>
		/// <term>NO_PROPAGATE_INHERIT_ACE</term>
		/// <term>
		/// If the ACE is inherited by a child object, the system clears the OBJECT_INHERIT_ACE and CONTAINER_INHERIT_ACE flags in the
		/// inherited ACE. This prevents the ACE from being inherited by subsequent generations of objects.
		/// </term>
		/// </item>
		/// <item>
		/// <term>OBJECT_INHERIT_ACE</term>
		/// <term>
		/// Noncontainer child objects inherit the ACE as an effective ACE. For child objects that are containers, the ACE is inherited
		/// as an inherit-only ACE unless the NO_PROPAGATE_INHERIT_ACE bit flag is also set.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SUCCESSFUL_ACCESS_ACE_FLAG</term>
		/// <term>Used with system-audit ACEs in a SACL to generate audit messages for successful access attempts.</term>
		/// </item>
		/// </list>
		/// </summary>
		public AceFlags AceFlags;

		/// <summary>Size, in bytes, of the ACE.</summary>
		public ushort AceSize;

		/// <summary>
		/// <para>Set of ACE type-specific control flags. This member can be a combination of the following values:</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>CONTAINER_INHERIT_ACE</term>
		/// <term>
		/// Child objects that are containers, such as directories, inherit the ACE as an effective ACE. The inherited ACE is inheritable
		/// unless the NO_PROPAGATE_INHERIT_ACE bit flag is also set.
		/// </term>
		/// </item>
		/// <item>
		/// <term>FAILED_ACCESS_ACE_FLAG</term>
		/// <term>Used with system-audit ACEs in a SACL to generate audit messages for failed access attempts.</term>
		/// </item>
		/// <item>
		/// <term>INHERIT_ONLY_ACE</term>
		/// <term>
		/// Indicates an inherit-only ACE which does not control access to the object to which it is attached. If this flag is not set,
		/// the ACE is an effective ACE which controls access to the object to which it is attached. Both effective and inherit-only ACEs
		/// can be inherited depending on the state of the other inheritance flags.
		/// </term>
		/// </item>
		/// <item>
		/// <term>INHERITED_ACE</term>
		/// <term>
		/// Microsoft Windows 2000 or later: Indicates that the ACE was inherited. The system sets this bit when it propagates an
		/// inherited ACE to a child object.
		/// </term>
		/// </item>
		/// <item>
		/// <term>NO_PROPAGATE_INHERIT_ACE</term>
		/// <term>
		/// If the ACE is inherited by a child object, the system clears the OBJECT_INHERIT_ACE and CONTAINER_INHERIT_ACE flags in the
		/// inherited ACE. This prevents the ACE from being inherited by subsequent generations of objects.
		/// </term>
		/// </item>
		/// <item>
		/// <term>OBJECT_INHERIT_ACE</term>
		/// <term>
		/// Noncontainer child objects inherit the ACE as an effective ACE. For child objects that are containers, the ACE is inherited
		/// as an inherit-only ACE unless the NO_PROPAGATE_INHERIT_ACE bit flag is also set.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SUCCESSFUL_ACCESS_ACE_FLAG</term>
		/// <term>Used with system-audit ACEs in a SACL to generate audit messages for successful access attempts.</term>
		/// </item>
		/// </list>
		/// </summary>
		public ACE_FLAG AceFlagsNative { get => (ACE_FLAG)AceFlags; set => AceFlags = (AceFlags)value; }

		/// <summary>ACE type with full native definition.</summary>
		public ACE_TYPE AceTypeNative { get => (ACE_TYPE)AceType; set => AceType = (AceType)value; }

		/// <summary>Initializes a new instance of the <see cref="ACE_HEADER"/> struct.</summary>
		/// <param name="aceType">ACE type.</param>
		/// <param name="aceFlags">Set of ACE type-specific control flags.</param>
		/// <param name="aceSize">Size, in bytes, of the ACE.</param>
		public ACE_HEADER(AceType aceType, AceFlags aceFlags, int aceSize)
		{
			AceType = aceType;
			AceFlags = aceFlags;
			AceSize = (ushort)aceSize;
		}

		/// <summary>Initializes a new instance of the <see cref="ACE_HEADER"/> struct.</summary>
		/// <param name="aceType">ACE type.</param>
		/// <param name="aceFlags">Set of ACE type-specific control flags.</param>
		/// <param name="aceSize">Size, in bytes, of the ACE.</param>
		public ACE_HEADER(ACE_TYPE aceType, ACE_FLAG aceFlags, int aceSize) : this((AceType)aceType, (AceFlags)aceFlags, aceSize) { }

		/// <inheritdoc/>
		public int CompareTo(ACE_HEADER other)
		{
			var ba = AceFlags.IsFlagSet(AceFlags.Inherited);
			var bb = other.AceFlags.IsFlagSet(AceFlags.Inherited);
			if (ba != bb) return ba ? 1000 : -1000;
			if (AceType != other.AceType) return AceTypeNative.IsAccessDeniedAceType() ? -500 : 500;
			return AceSize - other.AceSize;
		}
	}

	/// <summary>
	/// The ACL structure is the header of an access control list (ACL). A complete ACL consists of an ACL structure followed by an
	/// ordered list of zero or more access control entries (ACEs).
	/// </summary>
	/// <remarks>
	/// An ACL includes a sequential list of zero or more ACEs. The individual ACEs in an ACL are numbered from 0 to n, where n+1 is the
	/// number of ACEs in the ACL. When editing an ACL, an application refers to an ACE within the ACL by the ACE's index.
	/// <para>There are two types of ACL: discretionary and system.</para>
	/// <para>
	/// A discretionary access control list (DACL) is controlled by the owner of an object or anyone granted WRITE_DAC access to the
	/// object. It specifies the access particular users and groups can have to an object. For example, the owner of a file can use a
	/// DACL to control which users and groups can and cannot have access to the file.
	/// </para>
	/// <para>
	/// An object can also have system-level security information associated with it, in the form of a system access control list (SACL)
	/// controlled by a system administrator. A SACL allows the system administrator to audit any attempts to gain access to an object.
	/// </para>
	/// <para>For a list of currently defined ACE structures, see ACE.</para>
	/// <para>A fourth ACE structure, SYSTEM_ALARM_ACE, is not currently supported.</para>
	/// <para>
	/// The ACL structure is to be treated as though it were opaque and applications are not to attempt to work with its members
	/// directly. To ensure that ACLs are semantically correct, applications can use the functions listed in the See Also section to
	/// create and manipulate ACLs.
	/// </para>
	/// <para>Each ACL and ACE structure begins on a DWORD boundary.</para>
	/// <para>The maximum size for an ACL, including its ACEs, is 64 KB.</para>
	/// </remarks>
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	[PInvokeData("Winnt.h", MSDNShortId = "aa374931")]
	public struct ACL
	{
		/// <summary>
		/// Specifies the revision level of the ACL. This value should be ACL_REVISION, unless the ACL contains an object-specific ACE,
		/// in which case this value must be ACL_REVISION_DS. All ACEs in an ACL must be at the same revision level.
		/// </summary>
		public byte AclRevision;

		/// <summary>Specifies a zero byte of padding that aligns the AclRevision member on a 16-bit boundary.</summary>
		public byte Sbz1;

		/// <summary>Specifies the size, in bytes, of the ACL. This value includes both the ACL structure and all the ACEs.</summary>
		public ushort AclSize;

		/// <summary>Specifies the number of ACEs stored in the ACL.</summary>
		public ushort AceCount;

		/// <summary>Specifies two zero-bytes of padding that align the ACL structure on a 32-bit boundary.</summary>
		public ushort Sbz2;
	}

	/// <summary>The ACL_REVISION_INFORMATION structure contains revision information about an ACL structure.</summary>
	[StructLayout(LayoutKind.Sequential)]
	[PInvokeData("Winnt.h", MSDNShortId = "aa374942")]
	public struct ACL_REVISION_INFORMATION
	{
		/// <summary>Specifies a revision number. The current revision number is ACL_REVISION.</summary>
		public uint AclRevision;
	}

	/// <summary>The ACL_SIZE_INFORMATION structure contains information about the size of an ACL structure.</summary>
	[StructLayout(LayoutKind.Sequential)]
	[PInvokeData("Winnt.h", MSDNShortId = "aa374945")]
	public struct ACL_SIZE_INFORMATION
	{
		/// <summary>The number of access control entries (ACEs) in the access control list (ACL).</summary>
		public uint AceCount;

		/// <summary>
		/// The number of bytes in the ACL actually used to store the ACEs and ACL structure. This may be less than the total number of
		/// bytes allocated to the ACL.
		/// </summary>
		public uint AclBytesInUse;

		/// <summary>The number of unused bytes in the ACL.</summary>
		public uint AclBytesFree;
	}

	/// <summary>The <c>CLAIM_SECURITY_ATTRIBUTE_FQBN_VALUE</c> structure specifies the fully qualified binary name.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/winnt/ns-winnt-_claim_security_attribute_fqbn_value typedef struct
	// _CLAIM_SECURITY_ATTRIBUTE_FQBN_VALUE { DWORD64 Version; PWSTR Name; } CLAIM_SECURITY_ATTRIBUTE_FQBN_VALUE, *PCLAIM_SECURITY_ATTRIBUTE_FQBN_VALUE;
	[PInvokeData("winnt.h", MSDNShortId = "1FD9A519-40EA-4780-90F5-C9DF4ADAE72C")]
	[StructLayout(LayoutKind.Sequential)]
	public struct CLAIM_SECURITY_ATTRIBUTE_FQBN_VALUE
	{
		/// <summary>The version of the fully qualified binary name value.</summary>
		public ulong Version;

		/// <summary>A fully qualified binary name.</summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string Name;
	}

	/// <summary>
	/// The <c>CLAIM_SECURITY_ATTRIBUTE_OCTET_STRING_VALUE</c> structure specifies the <c>OCTET_STRING</c> value type of the claim
	/// security attribute.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/winnt/ns-winnt-claim_security_attribute_octet_string_value typedef struct
	// _CLAIM_SECURITY_ATTRIBUTE_OCTET_STRING_VALUE { PVOID pValue; DWORD ValueLength; } CLAIM_SECURITY_ATTRIBUTE_OCTET_STRING_VALUE, *PCLAIM_SECURITY_ATTRIBUTE_OCTET_STRING_VALUE;
	[PInvokeData("winnt.h", MSDNShortId = "6647CC4F-1A84-43B2-A80E-7B6BF3A2D7AD")]
	[StructLayout(LayoutKind.Sequential)]
	public struct CLAIM_SECURITY_ATTRIBUTE_OCTET_STRING_VALUE
	{
		/// <summary>
		/// A pointer buffer that contains the <c>OCTET_STRING</c> value. The value is a series of bytes of the length indicated in the
		/// <c>ValueLength</c> member.
		/// </summary>
		public IntPtr pValue;

		/// <summary>The length, in bytes, of the <c>OCTET_STRING</c> value.</summary>
		public uint ValueLength;
	}

	/// <summary>
	/// The <c>CLAIM_SECURITY_ATTRIBUTE_V1</c> structure defines a security attribute that can be associated with a token or
	/// authorization context.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/winnt/ns-winnt-_claim_security_attribute_v1 typedef struct
	// _CLAIM_SECURITY_ATTRIBUTE_V1 { PWSTR Name; WORD ValueType; WORD Reserved; DWORD Flags; DWORD ValueCount; union { PLONG64 pInt64;
	// PDWORD64 pUint64; PWSTR *ppString; PCLAIM_SECURITY_ATTRIBUTE_FQBN_VALUE pFqbn; PCLAIM_SECURITY_ATTRIBUTE_OCTET_STRING_VALUE
	// pOctetString; } Values; } CLAIM_SECURITY_ATTRIBUTE_V1, *PCLAIM_SECURITY_ATTRIBUTE_V1;
	[PInvokeData("winnt.h", MSDNShortId = "FDBB9B00-01C3-474A-81FF-97C5CBA3261B")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct CLAIM_SECURITY_ATTRIBUTE_V1
	{
		/// <summary>
		/// A pointer to a string of Unicode characters that contains the name of the security attribute. This string must be at least 4
		/// bytes in length.
		/// </summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string Name;

		/// <summary>
		/// <para>
		/// A union tag value that indicates the type of information contained in the <c>Values</c> member. The <c>ValueType</c> member
		/// must be one of the following values.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>CLAIM_SECURITY_ATTRIBUTE_TYPE_INT64 0x0001</term>
		/// <term>The Values member refers to an array of LONG64 values.</term>
		/// </item>
		/// <item>
		/// <term>CLAIM_SECURITY_ATTRIBUTE_TYPE_UINT64 0x0002</term>
		/// <term>The Values member refers to an array of ULONG64 values.</term>
		/// </item>
		/// <item>
		/// <term>CLAIM_SECURITY_ATTRIBUTE_TYPE_STRING 0x0003</term>
		/// <term>The Values member refers to an array of pointers to Unicode string values.</term>
		/// </item>
		/// <item>
		/// <term>CLAIM_SECURITY_ATTRIBUTE_TYPE_FQBN 0x0004</term>
		/// <term>The Values member refers to an array of CLAIM_SECURITY_ATTRIBUTE_FQBN_VALUE values.</term>
		/// </item>
		/// <item>
		/// <term>CLAIM_SECURITY_ATTRIBUTE_TYPE_SID 0x0005</term>
		/// <term>
		/// The Values member refers to an array of CLAIM_SECURITY_ATTRIBUTE_OCTET_STRING_VALUE values where the pValue member of each
		/// CLAIM_SECURITY_ATTRIBUTE_OCTET_STRING_VALUE is a PSID.
		/// </term>
		/// </item>
		/// <item>
		/// <term>CLAIM_SECURITY_ATTRIBUTE_TYPE_BOOLEAN 0x0006</term>
		/// <term>
		/// The Values member refers to an array of ULONG64 values where each element indicates a Boolean value. The value 1 indicates
		/// TRUE and the value 0 indicates FALSE.
		/// </term>
		/// </item>
		/// <item>
		/// <term>CLAIM_SECURITY_ATTRIBUTE_TYPE_OCTET_STRING 0x0010</term>
		/// <term>The Values member refers to an array of CLAIM_SECURITY_ATTRIBUTE_OCTET_STRING_VALUE values.</term>
		/// </item>
		/// </list>
		/// </summary>
		public CLAIM_SECURITY_ATTRIBUTE_TYPE ValueType;

		/// <summary>This member is reserved and must be set to zero when sent and must be ignored when received.</summary>
		public ushort Reserved;

		/// <summary>
		/// <para>
		/// The attribute flags that are a 32-bitmask. Bits 16 through 31 may be set to any value. Bits 0 through 15 must be zero or a
		/// combination of one or more of the following mask values.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>CLAIM_SECURITY_ATTRIBUTE_NON_INHERITABLE 0x0001</term>
		/// <term>This attribute is ignored by the operating system. This claim security attribute is not inherited across processes.</term>
		/// </item>
		/// <item>
		/// <term>CLAIM_SECURITY_ATTRIBUTE_VALUE_CASE_SENSITIVE 0x0002</term>
		/// <term>The value of the claim security attribute is case sensitive. This flag is valid for values that contain string types.</term>
		/// </item>
		/// <item>
		/// <term>CLAIM_SECURITY_ATTRIBUTE_USE_FOR_DENY_ONLY 0x0004</term>
		/// <term>The claim security attribute is considered only for deny access control entries (ACEs).</term>
		/// </item>
		/// <item>
		/// <term>CLAIM_SECURITY_ATTRIBUTE_DISABLED_BY_DEFAULT 0x0008</term>
		/// <term>The claim security attribute is disabled by default.</term>
		/// </item>
		/// <item>
		/// <term>CLAIM_SECURITY_ATTRIBUTE_DISABLED 0x0010</term>
		/// <term>The claim security attribute is disabled and will not be applied by the AccessCheck function.</term>
		/// </item>
		/// <item>
		/// <term>CLAIM_SECURITY_ATTRIBUTE_MANDATORY 0x0020</term>
		/// <term>The claim security attribute is mandatory.</term>
		/// </item>
		/// </list>
		/// </summary>
		public CLAIM_SECURITY_ATTRIBUTE_FLAG Flags;

		/// <summary>The number of values specified in the <c>Values</c> member.</summary>
		public uint ValueCount;

		/// <summary>An array of security attribute values of the type specified in the <c>ValueType</c> member.</summary>
		public VALUESUNION Values;

		/// <summary/>
		[StructLayout(LayoutKind.Explicit)]
		public struct VALUESUNION
		{
			/// <summary>Pointer to an array of <c>ValueCount</c> members where each member is a <c>LONG64</c> of type CLAIM_SECURITY_ATTRIBUTE_TYPE_INT64.</summary>
			[FieldOffset(0)]
			public IntPtr pInt64;

			/// <summary>Pointer to an array of <c>ValueCount</c> members where each member is a <c>ULONG64</c> of type CLAIM_SECURITY_ATTRIBUTE_TYPE_UINT64.</summary>
			[FieldOffset(0)]
			public IntPtr pUint64;

			/// <summary>Pointer to an array of <c>ValueCount</c> members where each member is a <c>PWSTR</c> of type CLAIM_SECURITY_ATTRIBUTE_TYPE_STRING.</summary>
			[FieldOffset(0)]
			public IntPtr ppString;

			/// <summary>
			/// Pointer to an array of <c>ValueCount</c> members where each member is a fully qualified binary name value of type CLAIM_SECURITY_ATTRIBUTE_FQBN_VALUE.
			/// </summary>
			[FieldOffset(0)]
			public IntPtr pFqbn;

			/// <summary>Pointer to an array of <c>ValueCount</c> members where each member is an octet string of type CLAIM_SECURITY_ATTRIBUTE_OCTET_STRING_VALUE.</summary>
			[FieldOffset(0)]
			public IntPtr pOctetString;
		}
	}

	/// <summary>The CLAIM_SECURITY_ATTRIBUTES_INFORMATION structure defines the security attributes for the claim.</summary>
	[StructLayout(LayoutKind.Sequential)]
	[PInvokeData("Winnt.h", MSDNShortId = "hh448481")]
	public struct CLAIM_SECURITY_ATTRIBUTES_INFORMATION
	{
		/// <summary>A default instance which sets the <see cref="Version"/> field.</summary>
		public static readonly CLAIM_SECURITY_ATTRIBUTES_INFORMATION Default = new() { Version = 1 };

		/// <summary>The version of the security attribute. This must be 1.</summary>
		public ushort Version;

		/// <summary>
		/// This member is currently reserved and must be zero when setting an attribute and is ignored when getting an attribute.
		/// </summary>
		public ushort Reserved;

		/// <summary>The number of values.</summary>
		public uint AttributeCount;

		/// <summary>The actual attribute.</summary>
		public ATTRUNION Attribute;

		/// <summary>The actual attribute.</summary>
		[StructLayout(LayoutKind.Explicit)]
		[PInvokeData("Winnt.h", MSDNShortId = "hh448481")]
		public struct ATTRUNION
		{
			/// <summary>Pointer to an array that contains the AttributeCount member of the CLAIM_SECURITY_ATTRIBUTE_V1 structure.</summary>
			[FieldOffset(0)]
			public IntPtr pAttributeV1;
		}
	}

	/// <summary>
	/// <para>Contains information that is included immediately after the newest event log record.</para>
	/// <para>
	/// The <c>ELF_EOF_RECORD</c> structure is used in an event log to enable the event-logging service to reconstruct the
	/// <c>ELF_LOGFILE_HEADER</c>. The event-logging service must add the <c>ELF_EOF_RECORD</c> to the event log. For more information
	/// about <c>ELF_EOF_RECORD</c>, see Event Log File Format.
	/// </para>
	/// </summary>
	// typedef struct _EVENTLOGEOF { ULONG RecordSizeBeginning; ULONG One; ULONG Two; ULONG Three; ULONG Four; ULONG BeginRecord; ULONG
	// EndRecord; ULONG CurrentRecordNumber; ULONG OldestRecordNumber; ULONG RecordSizeEnd;} EVENTLOGEOF, *PEVENTLOGEOF; https://msdn.microsoft.com/en-us/library/windows/desktop/bb309022(v=vs.85).aspx
	[PInvokeData("Winnt.h", MSDNShortId = "bb309022")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	public struct EVENTLOGEOF
	{
		/// <summary>The beginning size of the <c>ELF_EOF_RECORD</c>. The beginning size is always 0x28.</summary>
		public uint RecordSizeBeginning;

		/// <summary>
		/// An identifier that helps to differentiate this record from other records in the event log. The value is always set to 0x11111111.
		/// </summary>
		public uint One;

		/// <summary>
		/// An identifier that helps to differentiate this record from other records in the event log. The value is always set to 0x22222222.
		/// </summary>
		public uint Two;

		/// <summary>
		/// An identifier that helps to differentiate this record from other records in the event log. The value is always set to 0x33333333.
		/// </summary>
		public uint Three;

		/// <summary>
		/// An identifier that helps to differentiate this record from other records in the event log. The value is always set to 0x44444444.
		/// </summary>
		public uint Four;

		/// <summary>The offset to the oldest record. If the event log is empty, this is set to the start of this structure.</summary>
		public uint BeginRecord;

		/// <summary>The offset to the start of this structure.</summary>
		public uint EndRecord;

		/// <summary>The record number of the next event that will be written to the event log.</summary>
		public uint CurrentRecordNumber;

		/// <summary>The record number of the oldest record in the event log. The record number will be 0 if the event log is empty.</summary>
		public uint OldestRecordNumber;

		/// <summary>The ending size of the <c>ELF_EOF_RECORD</c>. The ending size is always 0x28.</summary>
		public uint RecordSizeEnd;
	}

	/// <summary>
	/// <para>Contains information that is included at the beginning of an event log.</para>
	/// <para>
	/// The <c>ELF_LOGFILE_HEADER</c> structure is used at the beginning of an event log to define information about the event log. The
	/// event-logging service must add the <c>ELF_LOGFILE_HEADER</c> to the event log. For more information about how the
	/// <c>ELF_LOGFILE_HEADER</c> is used, see Event Log File Format.
	/// </para>
	/// </summary>
	// typedef struct _EVENTLOGHEADER { ULONG HeaderSize; ULONG Signature; ULONG MajorVersion; ULONG MinorVersion; ULONG StartOffset;
	// ULONG EndOffset; ULONG CurrentRecordNumber; ULONG OldestRecordNumber; ULONG MaxSize; ULONG Flags; ULONG Retention; ULONG
	// EndHeaderSize;} EVENTLOGHEADER, *PEVENTLOGHEADER; https://msdn.microsoft.com/en-us/library/windows/desktop/bb309024(v=vs.85).aspx
	[PInvokeData("Winnt.h", MSDNShortId = "bb309024")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	public struct EVENTLOGHEADER
	{
		/// <summary>The size of the header structure. The size is always 0x30.</summary>
		public uint HeaderSize;

		/// <summary>The signature is always 0x654c664c, which is ASCII for eLfL.</summary>
		public uint Signature;

		/// <summary>The major version number of the event log. The major version number is always set to 1.</summary>
		public uint MajorVersion;

		/// <summary>The minor version number of the event log. The minor version number is always set to 1.</summary>
		public uint MinorVersion;

		/// <summary>The offset to the oldest record in the event log.</summary>
		public uint StartOffset;

		/// <summary>The offset to the <c>ELF_EOF_RECORD</c> in the event log.</summary>
		public uint EndOffset;

		/// <summary>The number of the next record that will be added to the event log.</summary>
		public uint CurrentRecordNumber;

		/// <summary>The number of the oldest record in the event log. For an empty file, the oldest record number is set to 0.</summary>
		public uint OldestRecordNumber;

		/// <summary>
		/// The maximum size, in bytes, of the event log. The maximum size is defined when the event log is created. The event-logging
		/// service does not typically update this value, it relies on the registry configuration. The reader of the event log can use
		/// normal file APIs to determine the size of the file. For more information about registry configuration values, see Eventlog Key.
		/// </summary>
		public uint MaxSize;

		/// <summary>
		/// <para>The status of the event log. This member can be one of the following values:</para>
		/// <para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>ELF_LOGFILE_HEADER_DIRTY0x0001</term>
		/// <term>
		/// Indicates that records have been written to an event log, but the event log file has not been properly closed. For more
		/// information about this flag, see the Remarks section.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ELF_LOGFILE_HEADER_WRAP0x0002</term>
		/// <term>Indicates that records in the event log have wrapped.</term>
		/// </item>
		/// <item>
		/// <term>ELF_LOGFILE_LOGFULL_WRITTEN0x0004</term>
		/// <term>Indicates that the most recent write attempt failed due to insufficient space.</term>
		/// </item>
		/// <item>
		/// <term>ELF_LOGFILE_ARCHIVE_SET0x0008</term>
		/// <term>
		/// Indicates that the archive attribute has been set for the file. Normal file APIs can also be used to determine the value of
		/// this flag.
		/// </term>
		/// </item>
		/// </list>
		/// </para>
		/// </summary>
		public ELF_FLAGS Flags;

		/// <summary>
		/// The retention value of the file when it is created. The event-logging service does not typically update this value, it relies
		/// on the registry configuration. For more information about registry configuration values, see Eventlog Key.
		/// </summary>
		public uint Retention;

		/// <summary>The ending size of the header structure. The size is always 0x30.</summary>
		public uint EndHeaderSize;
	}

	/// <summary>Contains information about an event record returned by the ReadEventLog function.</summary>
	/// <remarks>
	/// <para>
	/// The defined members are followed by the replacement strings for the message identified by the event identifier, the binary
	/// information, some pad bytes to make sure the full entry is on a <c>DWORD</c> boundary, and finally the length of the log entry
	/// again. Because the strings and the binary information can be of any length, no structure members are defined to reference them.
	/// The declaration of this structure in Winnt.h describes these members as follows:
	/// </para>
	/// <para>
	/// The source name is a variable-length string that specifies the name of the event source. The computer name is the name of the
	/// computer that generated the event. It may be followed with some padding bytes so that the user SID is aligned on a <c>DWORD</c>
	/// boundary. The user SID identifies the active user at the time this event was logged. If <c>UserSidLength</c> is zero, this field
	/// may be empty.
	/// </para>
	/// <para>
	/// The event identifier together with source name and a language identifier identify a string that describes the event in more
	/// detail. The strings are used as replacement strings and are merged into the message string to make a complete message. The
	/// message strings are contained in a message file specified in the source entry in the registry. To obtain the appropriate message
	/// string from the message file, load the message file with the LoadLibrary function and use the FormatMessage function.
	/// </para>
	/// <para>
	/// The binary information is information that is specific to the event. It could be the contents of the processor registers when a
	/// device driver got an error, a dump of an invalid packet that was received from the network, a dump of all the structures in a
	/// program (when the data area was detected to be corrupt), and so on. This information should be useful to the writer of the device
	/// driver or the application in tracking down bugs or unauthorized breaks into the application.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winnt/ns-winnt-_eventlogrecord typedef struct _EVENTLOGRECORD { DWORD Length;
	// DWORD Reserved; DWORD RecordNumber; DWORD TimeGenerated; DWORD TimeWritten; DWORD EventID; WORD EventType; WORD NumStrings; WORD
	// EventCategory; WORD ReservedFlags; DWORD ClosingRecordNumber; DWORD StringOffset; DWORD UserSidLength; DWORD UserSidOffset; DWORD
	// DataLength; DWORD DataOffset; } EVENTLOGRECORD, *PEVENTLOGRECORD;
	[PInvokeData("winnt.h", MSDNShortId = "669b182a-bc81-4386-9815-6ffa09e2e743")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct EVENTLOGRECORD
	{
		/// <summary>
		/// The size of this event record, in bytes. Note that this value is stored at both ends of the entry to ease moving forward or
		/// backward through the log. The length includes any pad bytes inserted at the end of the record for <c>DWORD</c> alignment.
		/// </summary>
		public uint Length;

		/// <summary>A DWORD value that is always set to <c>ELF_LOG_SIGNATURE</c> (the value is 0x654c664c), which is ASCII for eLfL.</summary>
		public uint Reserved;

		/// <summary>
		/// The number of the record. This value can be used with the EVENTLOG_SEEK_READ flag in the ReadEventLog function to begin
		/// reading at a specified record. For more information, see Event Log Records.
		/// </summary>
		public uint RecordNumber;

		/// <summary>
		/// The time at which this entry was submitted. This time is measured in the number of seconds elapsed since 00:00:00 January 1,
		/// 1970, Universal Coordinated Time.
		/// </summary>
		public uint TimeGenerated;

		/// <summary>
		/// The time at which this entry was received by the service to be written to the log. This time is measured in the number of
		/// seconds elapsed since 00:00:00 January 1, 1970, Universal Coordinated Time.
		/// </summary>
		public uint TimeWritten;

		/// <summary>
		/// The event identifier. The value is specific to the event source for the event, and is used with source name to locate a
		/// description string in the message file for the event source. For more information, see Event Identifiers.
		/// </summary>
		public uint EventID;

		/// <summary>
		/// <para>The type of event. This member can be one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>EVENTLOG_ERROR_TYPE 0x0001</term>
		/// <term>Error event</term>
		/// </item>
		/// <item>
		/// <term>EVENTLOG_AUDIT_FAILURE 0x0010</term>
		/// <term>Failure Audit event</term>
		/// </item>
		/// <item>
		/// <term>EVENTLOG_AUDIT_SUCCESS 0x0008</term>
		/// <term>Success Audit event</term>
		/// </item>
		/// <item>
		/// <term>EVENTLOG_INFORMATION_TYPE 0x0004</term>
		/// <term>Information event</term>
		/// </item>
		/// <item>
		/// <term>EVENTLOG_WARNING_TYPE 0x0002</term>
		/// <term>Warning event</term>
		/// </item>
		/// </list>
		/// <para>For more information, see Event Types.</para>
		/// </summary>
		public EVENTLOG_TYPE EventType;

		/// <summary>
		/// The number of strings present in the log (at the position indicated by <c>StringOffset</c>). These strings are merged into
		/// the message before it is displayed to the user.
		/// </summary>
		public ushort NumStrings;

		/// <summary>
		/// The category for this event. The meaning of this value depends on the event source. For more information, see Event Categories.
		/// </summary>
		public ushort EventCategory;

		/// <summary>Reserved.</summary>
		public ushort ReservedFlags;

		/// <summary>Reserved.</summary>
		public uint ClosingRecordNumber;

		/// <summary>The offset of the description strings within this event log record.</summary>
		public uint StringOffset;

		/// <summary>The size of the <c>UserSid</c> member, in bytes. This value can be zero if no security identifier was provided.</summary>
		public uint UserSidLength;

		/// <summary>
		/// The offset of the security identifier (SID) within this event log record. To obtain the user name for this SID, use the
		/// LookupAccountSid function.
		/// </summary>
		public uint UserSidOffset;

		/// <summary>The size of the event-specific data (at the position indicated by <c>DataOffset</c>), in bytes.</summary>
		public uint DataLength;

		/// <summary>
		/// The offset of the event-specific information within this event log record, in bytes. This information could be something
		/// specific (a disk driver might log the number of retries, for example), followed by binary information specific to the event
		/// being logged and to the source that generated the entry.
		/// </summary>
		public uint DataOffset;
	}

	/// <summary>
	/// Defines the mapping of generic access rights to specific and standard access rights for an object. When a client application
	/// requests generic access to an object, that request is mapped to the access rights defined in this structure.
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	[PInvokeData("Winnt.h", MSDNShortId = "aa446633")]
	public struct GENERIC_MAPPING
	{
		/// <summary>Specifies an access mask defining read access to an object.</summary>
		public uint GenericRead;

		/// <summary>Specifies an access mask defining write access to an object.</summary>
		public uint GenericWrite;

		/// <summary>Specifies an access mask defining execute access to an object.</summary>
		public uint GenericExecute;

		/// <summary>Specifies an access mask defining all possible types of access to an object.</summary>
		public uint GenericAll;

		/// <summary>Initializes a new instance of the <see cref="GENERIC_MAPPING"/> structure.</summary>
		/// <param name="read">The read mapping.</param>
		/// <param name="write">The write mapping.</param>
		/// <param name="execute">The execute mapping.</param>
		/// <param name="all">The 'all' mapping.</param>
		public GENERIC_MAPPING(uint read, uint write, uint execute, uint all)
		{
			GenericRead = read;
			GenericWrite = write;
			GenericExecute = execute;
			GenericAll = all;
		}

		/// <summary>The generic file mappings (FILE_GENERIC_READ, FILE_GENERIC_WRITE, FILE_GENERIC_READ, FILE_ALL_ACCESS).</summary>
		public static readonly GENERIC_MAPPING GenericFileMapping = new((uint)FileAccess.FILE_GENERIC_READ, (uint)FileAccess.FILE_GENERIC_WRITE, (uint)FileAccess.FILE_GENERIC_READ, (uint)FileAccess.FILE_ALL_ACCESS);
	}

	/// <summary>
	/// An LUID is a 64-bit value guaranteed to be unique only on the system on which it was generated. The uniqueness of a locally
	/// unique identifier (LUID) is guaranteed only until the system is restarted.
	/// <para>Applications must use functions and structures to manipulate LUID values.</para>
	/// </summary>
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	public struct LUID
	{
		/// <summary>Low order bits.</summary>
		public uint LowPart;

		/// <summary>High order bits.</summary>
		public int HighPart;

		/// <summary>Gets the privilege name for this LUID.</summary>
		/// <param name="systemName">
		/// Name of the system on which to perform the lookup. Specifying <c>null</c> will query the local system.
		/// </param>
		/// <returns>The name retrieved for the LUID.</returns>
		public string GetName(string? systemName = null)
		{
			var sb = new StringBuilder(1024);
			var sz = (uint)sb.Capacity;
			if (!LookupPrivilegeName(systemName, in this, sb, ref sz))
				Win32Error.ThrowLastError();
			return sb.ToString();
		}

		/// <summary>Creates a new LUID instance from a privilege name.</summary>
		/// <param name="name">The privilege name.</param>
		/// <param name="systemName">
		/// Name of the system on which to perform the lookup. Specifying <c>null</c> will query the local system.
		/// </param>
		/// <returns>The LUID instance corresponding to the <paramref name="name"/>.</returns>
		public static LUID FromName(string name, string? systemName = null) =>
			LookupPrivilegeValue(systemName, name, out var val) ? val : throw Win32Error.GetLastError().GetException()!;

		/// <summary>
		/// Creates a new LUID that is unique to the local system only, and uniqueness is guaranteed only until the system is next restarted.
		/// </summary>
		/// <returns>A new LUID.</returns>
		public static LUID NewLUID()
		{
			if (!AllocateLocallyUniqueId(out var ret))
				Win32Error.ThrowLastError();
			return ret;
		}

		/// <summary>Returns a <see cref="System.String"/> that represents this instance.</summary>
		/// <returns>A <see cref="System.String"/> that represents this instance.</returns>
		public override string ToString()
		{
			try { return GetName(); } catch { return $"0x{Macros.MAKELONG64(LowPart, (uint)HighPart):X}"; }
		}
	}

	/// <summary>The LUID_AND_ATTRIBUTES structure represents a locally unique identifier (LUID) and its attributes.</summary>
	/// <remarks>
	/// An LUID_AND_ATTRIBUTES structure can represent an LUID whose attributes change frequently, such as when the LUID is used to
	/// represent privileges in the PRIVILEGE_SET structure. Privileges are represented by LUIDs and have attributes indicating whether
	/// they are currently enabled or disabled.
	/// </remarks>
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	public struct LUID_AND_ATTRIBUTES
	{
		/// <summary>Specifies a LUID value.</summary>
		public LUID Luid;

		/// <summary>
		/// Specifies attributes of the LUID. This value contains up to 32 one-bit flags. Its meaning is dependent on the definition and
		/// use of the LUID.
		/// </summary>
		public PrivilegeAttributes Attributes;

		/// <summary>Initializes a new instance of the <see cref="LUID_AND_ATTRIBUTES"/> struct.</summary>
		/// <param name="luid">The LUID value.</param>
		/// <param name="attr">The attribute value.</param>
		public LUID_AND_ATTRIBUTES(LUID luid, PrivilegeAttributes attr)
		{
			Luid = luid;
			Attributes = attr;
		}

		/// <summary>Returns a <see cref="System.String"/> that represents this instance.</summary>
		/// <returns>A <see cref="System.String"/> that represents this instance.</returns>
		public override string ToString() => $"{Luid}:{Attributes}";
	}

	/// <summary>The QUOTA_LIMITS structure describes the amount of system resources available to a user.</summary>
	[StructLayout(LayoutKind.Sequential)]
	[PInvokeData("Winnt.h", MSDNShortId = "aa379363")]
	public struct QUOTA_LIMITS
	{
		/// <summary>
		/// Specifies the amount of paged pool memory assigned to the user. The paged pool is an area of system memory (physical memory
		/// used by the operating
		/// system) for objects that can be written to disk when they are not being used.
		/// <para>
		/// The value set in this member is not enforced by the LSA. You should set this member to 0, which causes the default value to
		/// be used.
		/// </para>
		/// </summary>
		public uint PagedPoolLimit;

		/// <summary>
		/// Specifies the amount of nonpaged pool memory assigned to the user. The nonpaged pool is an area of system memory for objects
		/// that cannot be written to disk but must remain in physical memory as long as they are allocated.
		/// <para>
		/// The value set in this member is not enforced by the LSA. You should set this member to 0, which causes the default value to
		/// be used.
		/// </para>
		/// </summary>
		public uint NonPagedPoolLimit;

		/// <summary>
		/// Specifies the minimum set size assigned to the user. The "working set" of a process is the set of memory pages currently
		/// visible to the process in physical RAM memory. These pages are present in memory when the application is running and
		/// available for an application to use without triggering a page fault.
		/// <para>
		/// The value set in this member is not enforced by the LSA. You should set this member to NULL, which causes the default value
		/// to be used.
		/// </para>
		/// </summary>
		public uint MinimumWorkingSetSize;

		/// <summary>
		/// Specifies the maximum set size assigned to the user.
		/// <para>
		/// The value set in this member is not enforced by the LSA. You should set this member to 0, which causes the default value to
		/// be used.
		/// </para>
		/// </summary>
		public uint MaximumWorkingSetSize;

		/// <summary>
		/// Specifies the maximum size, in bytes, of the paging file, which is a reserved space on disk that backs up committed physical
		/// memory on the computer.
		/// <para>
		/// The value set in this member is not enforced by the LSA. You should set this member to 0, which causes the default value to
		/// be used.
		/// </para>
		/// </summary>
		public uint PagefileLimit;

		/// <summary>
		/// Indicates the maximum amount of time the process can run.
		/// <para>
		/// The value set in this member is not enforced by the LSA. You should set this member to NULL, which causes the default value
		/// to be used.
		/// </para>
		/// </summary>
		public long TimeLimit;
	}

	/// <summary>
	/// The SECURITY_DESCRIPTOR structure contains the security information associated with an object. Applications use this structure to
	/// set and query an object's security status.
	/// <para>
	/// Because the internal format of a security descriptor can vary, we recommend that applications not modify the SECURITY_DESCRIPTOR
	/// structure directly.
	/// </para>
	/// </summary>
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	[PInvokeData("Winnt.h", MSDNShortId = "aa379561")]
	public struct SECURITY_DESCRIPTOR
	{
		/// <summary>Undocumented.</summary>
		public byte Revision;

		/// <summary>Undocumented.</summary>
		public byte Sbz1;

		/// <summary>Undocumented.</summary>
		public SECURITY_DESCRIPTOR_CONTROL Control;

		/// <summary>Undocumented.</summary>
		public PSID Owner;

		/// <summary>Undocumented.</summary>
		public PSID Group;

		/// <summary>Undocumented.</summary>
		public PACL Sacl;

		/// <summary>Undocumented.</summary>
		public PACL Dacl;
	}

	/// <summary>
	/// <para>The security identifier (SID) structure is a variable-length structure used to uniquely identify users or groups.</para>
	/// <para>
	/// Applications should not modify a SID directly. To create and manipulate a security identifier, use the functions listed in the
	/// See Also section.
	/// </para>
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/winnt/ns-winnt-sid typedef struct _SID { BYTE Revision; BYTE
	// SubAuthorityCount; SID_IDENTIFIER_AUTHORITY IdentifierAuthority; #if ... DWORD *SubAuthority[]; #else DWORD
	// SubAuthority[ANYSIZE_ARRAY]; #endif } SID, *PISID;
	[PInvokeData("winnt.h", MSDNShortId = "NS:winnt._SID")]
	[VanaraMarshaler(typeof(AnySizeStringMarshaler<SID>), nameof(SubAuthorityCount))]
	[StructLayout(LayoutKind.Sequential)]
	public struct SID
	{
		/// <summary />
		public byte Revision;
		/// <summary />
		public byte SubAuthorityCount;
		/// <summary />
		public SID_IDENTIFIER_AUTHORITY IdentifierAuthority;
		/// <summary />
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
		public uint[] SubAuthority;
	}

	/// <summary>
	/// The SID_AND_ATTRIBUTES structure represents a security identifier (SID) and its attributes. SIDs are used to uniquely identify
	/// users or groups.
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	public struct SID_AND_ATTRIBUTES
	{
		/// <summary>A pointer to a SID structure.</summary>
		public PSID Sid;

		/// <summary>
		/// Specifies attributes of the SID. This value contains up to 32 one-bit flags. Its meaning depends on the definition and use of
		/// the SID.
		/// </summary>
		public uint Attributes;

		/// <summary>Initializes a new instance of the <see cref="SID_AND_ATTRIBUTES"/> struct.</summary>
		/// <param name="sid">The SID.</param>
		/// <param name="attributes">The attributes of the SID.</param>
		public SID_AND_ATTRIBUTES(PSID sid, uint attributes)
		{
			Sid = sid;
			Attributes = attributes;
		}

		/// <summary>Returns a <see cref="System.String"/> that represents this instance.</summary>
		/// <returns>A <see cref="System.String"/> that represents this instance.</returns>
		public override string ToString() => $"{(Sid.IsValidSid() ? Sid.ToString("N") : "")}:{Attributes}";
	}

	/// <summary>The SID_IDENTIFIER_AUTHORITY structure represents the top-level authority of a security identifier (SID).</summary>
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	[PInvokeData("Winnt.h", MSDNShortId = "aa379598")]
	public struct SID_IDENTIFIER_AUTHORITY : IEquatable<PSID_IDENTIFIER_AUTHORITY>, IEquatable<SID_IDENTIFIER_AUTHORITY>, IEquatable<byte[]>
	{
		/// <summary>An array of 6 bytes specifying a SID's top-level authority.</summary>
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)] public byte[] Value;

		/// <summary>Implements the operator !=.</summary>
		/// <param name="h1">The first handle.</param>
		/// <param name="h2">The second handle.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator !=(SID_IDENTIFIER_AUTHORITY h1, SID_IDENTIFIER_AUTHORITY h2) => !(h1 == h2);

		/// <summary>Implements the operator ==.</summary>
		/// <param name="h1">The first handle.</param>
		/// <param name="h2">The second handle.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator ==(SID_IDENTIFIER_AUTHORITY h1, SID_IDENTIFIER_AUTHORITY h2) => h1.Equals(h2);

		/// <summary>Indicates whether the current object is equal to another object of the same type.</summary>
		/// <param name="other">An object to compare with this object.</param>
		/// <returns>
		/// <see langword="true"/> if the current object is equal to the <paramref name="other"/> parameter; otherwise, <see langword="false"/>.
		/// </returns>
		public bool Equals(PSID_IDENTIFIER_AUTHORITY? other) => PSID_IDENTIFIER_AUTHORITY.Equals6Bytes(Value, other?.Value);

		/// <summary>Indicates whether the current object is equal to another object of the same type.</summary>
		/// <param name="other">An object to compare with this object.</param>
		/// <returns>
		/// <see langword="true"/> if the current object is equal to the <paramref name="other"/> parameter; otherwise, <see langword="false"/>.
		/// </returns>
		public bool Equals(SID_IDENTIFIER_AUTHORITY other) => PSID_IDENTIFIER_AUTHORITY.Equals6Bytes(Value, other.Value);

		/// <summary>Indicates whether the current object is equal to another object of the same type.</summary>
		/// <param name="other">An object to compare with this object.</param>
		/// <returns>
		/// <see langword="true"/> if the current object is equal to the <paramref name="other"/> parameter; otherwise, <see langword="false"/>.
		/// </returns>
		public bool Equals(byte[]? other) => PSID_IDENTIFIER_AUTHORITY.Equals6Bytes(Value, other);

		/// <inheritdoc/>
		public override bool Equals(object? obj) => obj switch
		{
			PSID_IDENTIFIER_AUTHORITY h => Equals(h),
			SID_IDENTIFIER_AUTHORITY h => Equals(h),
			byte[] h => Equals(h),
			_ => ReferenceEquals(Value, obj),
		};

		/// <inheritdoc/>
		public override int GetHashCode() => Value.GetHashCode();
	}

	/// <summary>
	/// <para>Not supported.</para>
	/// <para>The <c>SYSTEM_ALARM_ACE</c> structure is reserved for future use.</para>
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/winnt/ns-winnt-system_alarm_ace typedef struct _SYSTEM_ALARM_ACE { ACE_HEADER
	// Header; ACCESS_MASK Mask; DWORD SidStart; } SYSTEM_ALARM_ACE;
	[PInvokeData("winnt.h", MSDNShortId = "491cc5c7-abb6-4d03-b3b0-ba5eedb5e2ba")]
	[StructLayout(LayoutKind.Sequential)]
	public struct SYSTEM_ALARM_ACE : IAccessControlEntry
	{
		/// <summary/>
		public ACE_HEADER Header;

		/// <summary/>
		public ACCESS_MASK Mask;

		/// <summary/>
		public uint SidStart;
	}

	/// <summary>
	/// <para>Not supported.</para>
	/// <para>The <c>SYSTEM_ALARM_CALLBACK_ACE</c> structure is reserved for future use.</para>
	/// </summary>
	/// <remarks>
	/// ACE structures must be aligned on <c>DWORD</c> boundaries. All Windows memory-management functions return <c>DWORD</c>-aligned
	/// handles to memory.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/winnt/ns-winnt-system_alarm_callback_ace typedef struct
	// _SYSTEM_ALARM_CALLBACK_ACE { ACE_HEADER Header; ACCESS_MASK Mask; DWORD SidStart; } SYSTEM_ALARM_CALLBACK_ACE, *PSYSTEM_ALARM_CALLBACK_ACE;
	[PInvokeData("winnt.h", MSDNShortId = "8bfb579f-4bee-454e-827b-63a800bccf85")]
	[StructLayout(LayoutKind.Sequential)]
	public struct SYSTEM_ALARM_CALLBACK_ACE : IAccessControlEntry
	{
		/// <summary>
		/// ACE_HEADER structure that specifies the size and type of ACE. It also contains flags that control inheritance of the ACE by
		/// child objects. The <c>AceType</c> member of the <c>ACE_HEADER</c> structure should be set to SYSTEM_ALARM_CALLBACK_ACE_TYPE.
		/// </summary>
		public ACE_HEADER Header;

		/// <summary>
		/// Specifies an ACCESS_MASK structure that gives the access rights that cause audit messages to be generated. The
		/// SUCCESSFUL_ACCESS_ACE_FLAG and FAILED_ACCESS_ACE_FLAG flags in the <c>AceFlags</c> member of the ACE_HEADER structure
		/// indicate whether messages are generated for successful access attempts, unsuccessful access attempts, or both.
		/// </summary>
		public ACCESS_MASK Mask;

		/// <summary>
		/// The first <c>DWORD</c> of a trustee's ACE. This ACE can be appended with application data. When the AuthzAccessCheckCallback
		/// function is called, this ACE is passed as the pAce parameter of that function.
		/// </summary>
		public uint SidStart;
	}

	/// <summary>
	/// <para>Not supported.</para>
	/// <para>The <c>SYSTEM_ALARM_CALLBACK_OBJECT_ACE</c> structure is reserved for future use.</para>
	/// </summary>
	/// <remarks>
	/// <para>
	/// If neither the <c>ObjectType</c> nor <c>InheritedObjectType</c> GUID is specified, the <c>SYSTEM_ALARM_CALLBACK_OBJECT_ACE</c>
	/// structure has the same semantics as the SYSTEM_ALARM_CALLBACK_ACE structure. In that case, use the
	/// <c>SYSTEM_ALARM_CALLBACK_ACE</c> structure because it is smaller and more efficient.
	/// </para>
	/// <para>
	/// An ACL that contains an <c>SYSTEM_ALARM_CALLBACK_OBJECT_ACE</c> must specify the ACL_REVISION_DS revision number in its
	/// ACE_HEADER structure.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/winnt/ns-winnt-system_alarm_callback_object_ace typedef struct
	// _SYSTEM_ALARM_CALLBACK_OBJECT_ACE { ACE_HEADER Header; ACCESS_MASK Mask; DWORD Flags; GUID ObjectType; GUID InheritedObjectType;
	// DWORD SidStart; } SYSTEM_ALARM_CALLBACK_OBJECT_ACE, *PSYSTEM_ALARM_CALLBACK_OBJECT_ACE;
	[PInvokeData("winnt.h", MSDNShortId = "3fdd0b75-666a-4064-95ed-9e708f34bed6")]
	[StructLayout(LayoutKind.Sequential)]
	public struct SYSTEM_ALARM_CALLBACK_OBJECT_ACE : IObjectAccessControlEntry
	{
		/// <summary>
		/// ACE_HEADER structure that specifies the size and type of ACE. It contains flags that control inheritance of the ACE by child
		/// objects. The structure also contains flags that indicate whether the ACE audits successful access attempts, failed access
		/// attempts, or both. The <c>AceType</c> member of the <c>ACE_HEADER</c> structure should be set to SYSTEM_ALARM_CALLBACK_OBJECT_ACE_TYPE.
		/// </summary>
		public ACE_HEADER Header;

		/// <summary>An ACCESS_MASK that specifies the access rights the system will audit for access attempts by the trustee.</summary>
		public ACCESS_MASK Mask;

		/// <summary>
		/// <para>
		/// A set of bit flags that indicate whether the <c>ObjectType</c> and <c>InheritedObjectType</c> members contain GUIDs. This
		/// parameter can be a combination of the following values. Set all undefined bits to zero.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>ACE_OBJECT_TYPE_PRESENT</term>
		/// <term>The ObjectType member contains a GUID.</term>
		/// </item>
		/// <item>
		/// <term>ACE_INHERITED_OBJECT_TYPE_PRESENT</term>
		/// <term>The InheritedObjectType member contains a GUID.</term>
		/// </item>
		/// </list>
		/// </summary>
		public ObjectAceFlags Flags;

		/// <summary>
		/// <para>A GUID structure that identifies a property set, property, extended right, or type of child object.</para>
		/// <para>
		/// This member is valid only if the ACE_OBJECT_TYPE_PRESENT bit is set in the <c>Flags</c> member. Otherwise, <c>ObjectType</c>
		/// is ignored.
		/// </para>
		/// <para>The purpose of this GUID depends on the access rights specified in the <c>Mask</c> member.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>ADS_RIGHT_DS_READ_PROP and/or ADS_RIGHT_DS_WRITE_PROP</term>
		/// <term>
		/// The ObjectType GUID identifies a property set or property of the object. The ACE controls auditing of the trustee's attempts
		/// to read or write the property or property set.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ADS_RIGHT_DS_CONTROL_ACCESS</term>
		/// <term>The ObjectType GUID identifies an extended access right.</term>
		/// </item>
		/// <item>
		/// <term>ADS_RIGHT_DS_CREATE_CHILD</term>
		/// <term>
		/// The ObjectType GUID identifies a type of child object. The ACE controls auditing of the trustee's attempts to create this
		/// type of child object.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ADS_RIGHT_DS_SELF</term>
		/// <term>The ObjectType GUID identifies a validated write.</term>
		/// </item>
		/// </list>
		/// </summary>
		public Guid ObjectType;

		/// <summary>
		/// <para>A GUID structure that identifies the type of child object that can inherit the ACE.</para>
		/// <para>
		/// This member is valid only if the ACE_INHERITED_OBJECT_TYPE_PRESENT bit is set in the <c>Flags</c> member. If that bit is not
		/// set, <c>InheritedObjectType</c> is ignored and all types of child objects can inherit the ACE. In either case, inheritance is
		/// also controlled by the inheritance flags in the ACE_HEADER, as well as by any protection against inheritance placed on the
		/// child objects.
		/// </para>
		/// </summary>
		public Guid InheritedObjectType;

		/// <summary>
		/// The first <c>DWORD</c> of a trustee's ACE. This ACE can be appended with application data. When the AuthzAccessCheckCallback
		/// function is called, this ACE is passed as the pAce parameter of that function.
		/// </summary>
		public uint SidStart;
	}

	/// <summary>The <c>SYSTEM_ALARM_OBJECT_ACE</c> structure is reserved for future use.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/winnt/ns-winnt-system_alarm_object_ace typedef struct _SYSTEM_ALARM_OBJECT_ACE
	// { ACE_HEADER Header; ACCESS_MASK Mask; DWORD Flags; GUID ObjectType; GUID InheritedObjectType; DWORD SidStart; }
	// SYSTEM_ALARM_OBJECT_ACE, *PSYSTEM_ALARM_OBJECT_ACE;
	[PInvokeData("winnt.h", MSDNShortId = "a55f6039-d1d2-4a7d-a6c9-e8f51b291582")]
	[StructLayout(LayoutKind.Sequential)]
	public struct SYSTEM_ALARM_OBJECT_ACE : IObjectAccessControlEntry
	{
		/// <summary/>
		public ACE_HEADER Header;

		/// <summary/>
		public ACCESS_MASK Mask;

		/// <summary/>
		public ObjectAceFlags Flags;

		/// <summary/>
		public Guid ObjectType;

		/// <summary/>
		public Guid InheritedObjectType;

		/// <summary/>
		public uint SidStart;
	}

	/// <summary>
	/// The <c>SYSTEM_AUDIT_ACE</c> structure defines an access control entry (ACE) for the system access control list (SACL) that
	/// specifies what types of access cause system-level notifications. A system-audit ACE causes an audit message to be logged when a
	/// specified trustee attempts to gain access to an object. The trustee is identified by a security identifier (SID).
	/// </summary>
	/// <remarks>
	/// <para>
	/// Audit messages are stored in an event log that can be manipulated by using the Windows API event-logging functions or by using
	/// the Event Viewer (Eventvwr.exe).
	/// </para>
	/// <para>
	/// ACE structures should be aligned on <c>DWORD</c> boundaries. All Windows memory-management functions return <c>DWORD</c>-aligned
	/// handles to memory.
	/// </para>
	/// <para>
	/// When a <c>SYSTEM_AUDIT_ACE</c> structure is created, sufficient memory must be allocated to accommodate the complete SID of the
	/// trustee in the <c>SidStart</c> member and the contiguous memory that follows it.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/winnt/ns-winnt-system_audit_ace typedef struct _SYSTEM_AUDIT_ACE { ACE_HEADER
	// Header; ACCESS_MASK Mask; DWORD SidStart; } SYSTEM_AUDIT_ACE;
	[PInvokeData("winnt.h", MSDNShortId = "c26b5856-5447-4606-8110-f24a4d235c64")]
	[StructLayout(LayoutKind.Sequential)]
	public struct SYSTEM_AUDIT_ACE : IAccessControlEntry
	{
		/// <summary>
		/// ACE_HEADER structure that specifies the size and type of ACE. It also contains flags that control inheritance of the ACE by
		/// child objects. The <c>AceType</c> member of the <c>ACE_HEADER</c> structure should be set to SYSTEM_AUDIT_ACE_TYPE, and the
		/// <c>AceSize</c> member should be set to the total number of bytes allocated for the <c>SYSTEM_AUDIT_ACE</c> structure.
		/// </summary>
		public ACE_HEADER Header;

		/// <summary>
		/// Specifies an ACCESS_MASK structure that gives the access rights that cause audit messages to be generated. The
		/// SUCCESSFUL_ACCESS_ACE_FLAG and FAILED_ACCESS_ACE_FLAG flags in the <c>AceFlags</c> member of the ACE_HEADER structure
		/// indicate whether messages are generated for successful access attempts, unsuccessful access attempts, or both.
		/// </summary>
		public ACCESS_MASK Mask;

		/// <summary>
		/// <para>
		/// The first <c>DWORD</c> of a trustee's SID. The remaining bytes of the SID are stored in contiguous memory after the
		/// <c>SidStart</c> member. This SID can be appended with application data.
		/// </para>
		/// <para>
		/// An access attempt of a kind specified by the <c>Mask</c> member by any trustee whose SID matches the <c>SidStart</c> member
		/// causes the system to generate an audit message. If an application does not specify a SID for this member, audit messages are
		/// generated for the specified access rights for all trustees.
		/// </para>
		/// </summary>
		public uint SidStart;
	}

	/// <summary>
	/// <para>
	/// The <c>SYSTEM_AUDIT_CALLBACK_ACE</c> structure defines an access control entry (ACE) for the system access control list (SACL)
	/// that specifies what types of access cause system-level notifications. A system-audit ACE causes an audit message to be logged
	/// when a specified trustee attempts to gain access to an object. The trustee is identified by a security identifier (SID).
	/// </para>
	/// <para>
	/// When the AuthzAccessCheck function is called, each <c>SYSTEM_AUDIT_CALLBACK_ACE</c> structure contained in the DACL of a
	/// SECURITY_DESCRIPTOR structure passed through a pointer to the <c>AuthzAccessCheck</c> function invokes a call to the
	/// application-defined AuthzAccessCheckCallback function, in which a pointer to the <c>SYSTEM_AUDIT_CALLBACK_ACE</c> structure found
	/// is passed in the pAce parameter.
	/// </para>
	/// </summary>
	/// <remarks>
	/// <para>
	/// ACE structures must be aligned on <c>DWORD</c> boundaries. All Windows memory-management functions return <c>DWORD</c>-aligned
	/// handles to memory.
	/// </para>
	/// <para>
	/// When a <c>SYSTEM_AUDIT_CALLBACK_ACE</c> structure is created, sufficient memory must be allocated to accommodate the complete SID
	/// of the trustee in the <c>SidStart</c> member and the contiguous memory that follows it.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/winnt/ns-winnt-system_audit_callback_ace typedef struct
	// _SYSTEM_AUDIT_CALLBACK_ACE { ACE_HEADER Header; ACCESS_MASK Mask; DWORD SidStart; } SYSTEM_AUDIT_CALLBACK_ACE, *PSYSTEM_AUDIT_CALLBACK_ACE;
	[PInvokeData("winnt.h", MSDNShortId = "4d1799b0-3e55-48d7-94ff-c0094945adea")]
	[StructLayout(LayoutKind.Sequential)]
	public struct SYSTEM_AUDIT_CALLBACK_ACE : IAccessControlEntry
	{
		/// <summary>
		/// ACE_HEADER structure that specifies the size and type of ACE. It also contains flags that control inheritance of the ACE by
		/// child objects. The <c>AceType</c> member of the <c>ACE_HEADER</c> structure should be set to SYSTEM_AUDIT_CALLBACK_ACE_TYPE,
		/// and the <c>AceSize</c> member should be set to the total number of bytes allocated for the <c>SYSTEM_AUDIT_CALLBACK_ACE</c> structure.
		/// </summary>
		public ACE_HEADER Header;

		/// <summary>
		/// Specifies an ACCESS_MASK structure that gives the access rights that cause audit messages to be generated. The
		/// SUCCESSFUL_ACCESS_ACE_FLAG and FAILED_ACCESS_ACE_FLAG flags in the <c>AceFlags</c> member of the ACE_HEADER structure
		/// indicate whether messages are generated for successful access attempts, unsuccessful access attempts, or both.
		/// </summary>
		public ACCESS_MASK Mask;

		/// <summary>
		/// The first <c>DWORD</c> of a trustee's SID. The remaining bytes of the SID are stored in contiguous memory after the
		/// <c>SidStart</c> member. This SID can be appended with application data.
		/// </summary>
		public uint SidStart;
	}

	/// <summary>
	/// <para>
	/// The <c>SYSTEM_AUDIT_CALLBACK_OBJECT_ACE</c> structure defines an access control entry (ACE) for a system access control list
	/// (SACL). The ACE can audit access to an object or subobjects such as property sets or properties. The ACE contains a set of access
	/// rights, a GUID that identifies the type of object or subobject, and a security identifier (SID) that identifies the trustee for
	/// whom the system will audit access. The ACE also contains a GUID and a set of flags that control inheritance of the ACE by child objects.
	/// </para>
	/// <para>
	/// When the AuthzAccessCheck function is called, each <c>SYSTEM_AUDIT_CALLBACK_OBJECT_ACE</c> structure contained in the DACL of a
	/// SECURITY_DESCRIPTOR structure passed through a pointer to the <c>AuthzAccessCheck</c> function invokes a call to the
	/// application-defined AuthzAccessCheckCallback function, in which a pointer to the <c>SYSTEM_AUDIT_CALLBACK_OBJECT_ACE</c>
	/// structure found is passed in the pAce parameter.
	/// </para>
	/// </summary>
	/// <remarks>
	/// <para>
	/// If neither the <c>ObjectType</c> nor <c>InheritedObjectType</c> GUID is specified, the <c>SYSTEM_AUDIT_CALLBACK_OBJECT_ACE</c>
	/// structure has the same semantics as the SYSTEM_AUDIT_CALLBACK_ACE structure. In that case, use the
	/// <c>SYSTEM_AUDIT_CALLBACK_ACE</c> structure because it is smaller and more efficient.
	/// </para>
	/// <para>
	/// An ACL that contains a <c>SYSTEM_AUDIT_CALLBACK_OBJECT_ACE</c> structure must specify the ACL_REVISION_DS revision number in its
	/// ACE_HEADER structure.
	/// </para>
	/// <para>
	/// When a <c>SYSTEM_AUDIT_CALLBACK_OBJECT_ACE</c> structure is created, sufficient memory must be allocated to accommodate the GUID
	/// structures in <c>ObjectType</c> and <c>InheritedObjectType</c> members, if one or both of them exists, as well as to accommodate
	/// the complete SID of the trustee in the <c>SidStart</c> member and the contiguous memory that follows it.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/winnt/ns-winnt-system_audit_callback_object_ace typedef struct
	// _SYSTEM_AUDIT_CALLBACK_OBJECT_ACE { ACE_HEADER Header; ACCESS_MASK Mask; DWORD Flags; GUID ObjectType; GUID InheritedObjectType;
	// DWORD SidStart; } SYSTEM_AUDIT_CALLBACK_OBJECT_ACE, *PSYSTEM_AUDIT_CALLBACK_OBJECT_ACE;
	[PInvokeData("winnt.h", MSDNShortId = "f547c928-4850-4072-be05-76a6c83b79bb")]
	[StructLayout(LayoutKind.Sequential)]
	public struct SYSTEM_AUDIT_CALLBACK_OBJECT_ACE : IObjectAccessControlEntry
	{
		/// <summary>
		/// ACE_HEADER structure that specifies the size and type of ACE. It contains flags that control inheritance of the ACE by child
		/// objects. The structure also contains flags that indicate whether the ACE audits successful access attempts, failed access
		/// attempts, or both. The <c>AceType</c> member of the <c>ACE_HEADER</c> structure should be set to
		/// SYSTEM_AUDIT_CALLBACK_OBJECT_ACE_TYPE, and the <c>AceSize</c> member should be set to the total number of bytes allocated for
		/// the <c>SYSTEM_AUDIT_CALLBACK_OBJECT_ACE</c> structure.
		/// </summary>
		public ACE_HEADER Header;

		/// <summary>An ACCESS_MASK that specifies the access rights the system will audit for access attempts by the trustee.</summary>
		public ACCESS_MASK Mask;

		/// <summary>
		/// <para>
		/// A set of bit flags that indicate whether the <c>ObjectType</c> and <c>InheritedObjectType</c> members contain GUIDs. This
		/// member can be a combination of the following values. Set all undefined bits to zero.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>ACE_OBJECT_TYPE_PRESENT</term>
		/// <term>The ObjectType member contains a GUID.</term>
		/// </item>
		/// <item>
		/// <term>ACE_INHERITED_OBJECT_TYPE_PRESENT</term>
		/// <term>The InheritedObjectType member contains a GUID.</term>
		/// </item>
		/// </list>
		/// </summary>
		public ObjectAceFlags Flags;

		/// <summary>
		/// <para>A GUID structure that identifies a property set, property, extended right, or type of child object.</para>
		/// <para>
		/// This member is valid only if the ACE_OBJECT_TYPE_PRESENT bit is set in the <c>Flags</c> member. Otherwise, <c>ObjectType</c>
		/// is ignored.
		/// </para>
		/// <para>The purpose of this GUID depends on the access rights specified in the <c>Mask</c> member.</para>
		/// <para>This member can be one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>ADS_RIGHT_DS_READ_PROP and/or ADS_RIGHT_DS_WRITE_PROP</term>
		/// <term>
		/// The ObjectType GUID identifies a property set or property of the object. The ACE controls auditing of the trustee's attempts
		/// to read or write the property or property set.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ADS_RIGHT_DS_CONTROL_ACCESS</term>
		/// <term>The ObjectType GUID identifies an extended access right.</term>
		/// </item>
		/// <item>
		/// <term>ADS_RIGHT_DS_CREATE_CHILD</term>
		/// <term>
		/// The ObjectType GUID identifies a type of child object. The ACE controls auditing of the trustee's attempts to create this
		/// type of child object.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ADS_RIGHT_DS_SELF</term>
		/// <term>The ObjectType GUID identifies a validated write.</term>
		/// </item>
		/// </list>
		/// </summary>
		public Guid ObjectType;

		/// <summary>
		/// <para>A GUID structure that identifies the type of child object that can inherit the ACE.</para>
		/// <para>
		/// This member is valid only if the ACE_INHERITED_OBJECT_TYPE_PRESENT bit is set in the <c>Flags</c> member. If that bit is not
		/// set, <c>InheritedObjectType</c> is ignored and all types of child objects can inherit the ACE. In either case, inheritance is
		/// also controlled by the inheritance flags in the ACE_HEADER, as well as by any protection against inheritance placed on the
		/// child objects.
		/// </para>
		/// </summary>
		public Guid InheritedObjectType;

		/// <summary>
		/// The first <c>DWORD</c> of a trustee's SID. The remaining bytes of the SID are stored in contiguous memory after the
		/// <c>SidStart</c> member. This SID can be appended with application data.
		/// </summary>
		public uint SidStart;
	}

	/// <summary>
	/// The <c>SYSTEM_AUDIT_OBJECT_ACE</c> structure defines an access control entry (ACE) for a system access control list (SACL). The
	/// ACE can audit access to an object or subobjects such as property sets or properties. The ACE contains a set of access rights, a
	/// GUID that identifies the type of object or subobject, and a security identifier (SID) that identifies the trustee for whom the
	/// system will audit access. The ACE also contains a GUID and a set of flags that control inheritance of the ACE by child objects.
	/// </summary>
	/// <remarks>
	/// <para>
	/// If neither the <c>ObjectType</c> nor <c>InheritedObjectType</c> GUID is specified, the <c>SYSTEM_AUDIT_OBJECT_ACE</c> structure
	/// has the same semantics as the SYSTEM_AUDIT_ACE structure. In that case, use the <c>SYSTEM_AUDIT_ACE</c> structure because it is
	/// smaller and more efficient.
	/// </para>
	/// <para>
	/// An ACL that contains an <c>SYSTEM_AUDIT_OBJECT_ACE</c> must specify the ACL_REVISION_DS revision number in its ACE_HEADER structure.
	/// </para>
	/// <para>
	/// When a <c>SYSTEM_AUDIT_OBJECT_ACE</c> structure is created, sufficient memory must be allocated to accommodate the GUID
	/// structures in <c>ObjectType</c> and <c>InheritedObjectType</c> members, if one or both of them exists, as well as to accommodate
	/// the complete SID of the trustee in the <c>SidStart</c> member and the contiguous memory that follows it.
	/// </para>
	/// <para>
	/// An <c>SYSTEM_AUDIT_OBJECT_ACE</c> structure can be created in an access control list (ACL) by a call to the
	/// AddAuditAccessObjectAce function. When this function is used, the correct amount of memory needed to accommodate the GUID
	/// structures in the <c>ObjectType</c> and <c>InheritedObjectType</c> members, if one or both of them exists, as well as to
	/// accommodate the trustee's SID is automatically allocated. In addition, the values of the <c>Header.AceType</c> and
	/// <c>Header.AceSize</c> members are set automatically. When an <c>SYSTEM_AUDIT_OBJECT_ACE</c> structure is created outside an ACL,
	/// sufficient memory must be allocated to accommodate the GUID structures in the <c>ObjectType</c> and <c>InheritedObjectType</c>
	/// members, if one or both of them exists, as well as to accommodate the complete SID of the trustee in the <c>SidStart</c> member
	/// and the contiguous memory following it. In addition, the values of the <c>Header.AceType</c> and <c>Header.AceSize</c> members
	/// must be set explicitly by the application.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/winnt/ns-winnt-system_audit_object_ace typedef struct _SYSTEM_AUDIT_OBJECT_ACE
	// { ACE_HEADER Header; ACCESS_MASK Mask; DWORD Flags; GUID ObjectType; GUID InheritedObjectType; DWORD SidStart; }
	// SYSTEM_AUDIT_OBJECT_ACE, *PSYSTEM_AUDIT_OBJECT_ACE;
	[PInvokeData("winnt.h", MSDNShortId = "de37bef6-e6c8-4455-856a-adebebda4cc7")]
	[StructLayout(LayoutKind.Sequential)]
	public struct SYSTEM_AUDIT_OBJECT_ACE : IObjectAccessControlEntry
	{
		/// <summary>
		/// An ACE_HEADER structure that specifies the size and type of ACE. It contains flags that control inheritance of the ACE by
		/// child objects. The structure also contains flags that indicate whether the ACE audits successful access attempts, failed
		/// access attempts, or both. The <c>AceType</c> member of the <c>ACE_HEADER</c> structure should be set to
		/// SYSTEM_AUDIT_OBJECT_ACE_TYPE, and the <c>AceSize</c> member should be set to the total number of bytes allocated for the
		/// <c>SYSTEM_AUDIT_OBJECT_ACE</c> structure.
		/// </summary>
		public ACE_HEADER Header;

		/// <summary>An ACCESS_MASK that specifies the access rights the system will audit for access attempts by the trustee.</summary>
		public ACCESS_MASK Mask;

		/// <summary>
		/// <para>
		/// A set of bit flags that indicate whether the <c>ObjectType</c> and <c>InheritedObjectType</c> members contain GUIDs. This
		/// member can be a combination of the following values. Set all undefined bits to zero.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>ACE_OBJECT_TYPE_PRESENT</term>
		/// <term>The ObjectType member contains a GUID.</term>
		/// </item>
		/// <item>
		/// <term>ACE_INHERITED_OBJECT_TYPE_PRESENT</term>
		/// <term>The InheritedObjectType member contains a GUID.</term>
		/// </item>
		/// </list>
		/// </summary>
		public ObjectAceFlags Flags;

		/// <summary>
		/// <para>A GUID structure that identifies a property set, property, extended right, or type of child object.</para>
		/// <para>
		/// This member is valid only if the ACE_OBJECT_TYPE_PRESENT bit is set in the <c>Flags</c> member. Otherwise, <c>ObjectType</c>
		/// is ignored.
		/// </para>
		/// <para>The purpose of this GUID depends on the access rights specified in the <c>Mask</c> member.</para>
		/// <para>This member can be one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>ADS_RIGHT_DS_READ_PROP and/or ADS_RIGHT_DS_WRITE_PROP</term>
		/// <term>
		/// The ObjectType GUID identifies a property set or property of the object. The ACE controls auditing of the trustee's attempts
		/// to read or write the property or property set.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ADS_RIGHT_DS_CONTROL_ACCESS</term>
		/// <term>The ObjectType GUID identifies an extended access right.</term>
		/// </item>
		/// <item>
		/// <term>ADS_RIGHT_DS_CREATE_CHILD</term>
		/// <term>
		/// The ObjectType GUID identifies a type of child object. The ACE controls auditing of the trustee's attempts to create this
		/// type of child object.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ADS_RIGHT_DS_SELF</term>
		/// <term>The ObjectType GUID identifies a validated write.</term>
		/// </item>
		/// </list>
		/// </summary>
		public Guid ObjectType;

		/// <summary>
		/// <para>A GUID structure that identifies the type of child object that can inherit the ACE.</para>
		/// <para>
		/// This member is valid only if the ACE_INHERITED_OBJECT_TYPE_PRESENT bit is set in the <c>Flags</c> member. If that bit is not
		/// set, <c>InheritedObjectType</c> is ignored and all types of child objects can inherit the ACE. In either case, inheritance is
		/// also controlled by the inheritance flags in the ACE_HEADER, as well as by any protection against inheritance placed on the
		/// child objects.
		/// </para>
		/// <para>
		/// The offset of this member can vary. If the <c>Flags</c> member does not contain the ACE_OBJECT_TYPE_PRESENT flag, the
		/// <c>InheritedObjectType</c> member starts at the offset specified by the <c>ObjectType</c> member.
		/// </para>
		/// </summary>
		public Guid InheritedObjectType;

		/// <summary>
		/// <para>
		/// Specifies the first <c>DWORD</c> of a SID that identifies the trustee for whom the access attempts are audited. The remaining
		/// bytes of the SID are stored in contiguous memory after the <c>SidStart</c> member. This SID can be appended with application data.
		/// </para>
		/// <para>
		/// The offset of this member can vary. If the <c>Flags</c> member is zero, the <c>SidStart</c> member starts at the offset
		/// specified by the <c>ObjectType</c> member. If <c>Flags</c> contains only one flag (either ACE_OBJECT_TYPE_PRESENT or
		/// ACE_INHERITED_OBJECT_TYPE_PRESENT), the <c>SidStart</c> member starts at the offset specified by the
		/// <c>InheritedObjectType</c> member.
		/// </para>
		/// </summary>
		public uint SidStart;
	}

	/// <summary>Reserved.</summary>
	[PInvokeData("winnt.h")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct SYSTEM_ACCESS_FILTER_ACE : IAccessControlEntry
	{
		/// <summary>
		/// An ACE_HEADER structure that specifies the size and type of the ACE. The structure also contains flags that control inheritance
		/// of the ACE by child objects. The <c>AceType</c> member of the <c>ACE_HEADER</c> structure must be set to
		/// <c>SYSTEM_PROCESS_TRUST_LABEL_ACE_TYPE</c>, and the <c>AceSize</c> member must be set to the total number of bytes allocated for
		/// the <c>SYSTEM_PROCESS_TRUST_LABEL_ACE_ACE</c> structure.
		/// </summary>
		public ACE_HEADER Header;

		/// <summary>The access policy associated with the SACL that contains this ACE.</summary>
		public ACCESS_MASK Mask;

		/// <summary>Specifies the first <c>DWORD</c> of a SID.</summary>
		public uint SidStart;
	}

	/// <summary>
	/// The <c>SYSTEM_MANDATORY_LABEL_ACE</c> structure defines an access control entry (ACE) for the system access control list (SACL) that
	/// specifies the mandatory access level and policy for a securable object.
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/winnt/ns-winnt-system_mandatory_label_ace typedef struct
	// _SYSTEM_MANDATORY_LABEL_ACE { ACE_HEADER Header; ACCESS_MASK Mask; DWORD SidStart; } SYSTEM_MANDATORY_LABEL_ACE, *PSYSTEM_MANDATORY_LABEL_ACE;
	[PInvokeData("winnt.h", MSDNShortId = "NS:winnt._SYSTEM_MANDATORY_LABEL_ACE")]
	[StructLayout(LayoutKind.Sequential)]
	public struct SYSTEM_MANDATORY_LABEL_ACE : IAccessControlEntry
	{
		/// <summary>
		/// An ACE_HEADER structure that specifies the size and type of the ACE. The structure also contains flags that control inheritance
		/// of the ACE by child objects. The <c>AceType</c> member of the <c>ACE_HEADER</c> structure must be set to
		/// <c>SYSTEM_MANDATORY_LABEL_ACE_TYPE</c>, and the <c>AceSize</c> member must be set to the total number of bytes allocated for the
		/// <c>SYSTEM_MANDATORY_LABEL_ACE</c> structure.
		/// </summary>
		public ACE_HEADER Header;

		/// <summary>
		/// <para>
		/// The access policy for principals with a mandatory integrity level lower than the object associated with the SACL that contains
		/// this ACE.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <description>Value</description>
		/// <description>Meaning</description>
		/// </listheader>
		/// <item>
		/// <description><c>SYSTEM_MANDATORY_LABEL_NO_WRITE_UP</c> 0x1</description>
		/// <description>A principal with a lower mandatory level than the object cannot write to the object.</description>
		/// </item>
		/// <item>
		/// <description><c>SYSTEM_MANDATORY_LABEL_NO_READ_UP</c> 0x2</description>
		/// <description>A principal with a lower mandatory level than the object cannot read the object.</description>
		/// </item>
		/// <item>
		/// <description><c>SYSTEM_MANDATORY_LABEL_NO_EXECUTE_UP</c> 0x4</description>
		/// <description>A principal with a lower mandatory level than the object cannot execute the object.</description>
		/// </item>
		/// </list>
		/// </summary>
		public ACCESS_MASK Mask;

		/// <summary>
		/// <para>
		/// Specifies the first <c>DWORD</c> of a SID. The remaining bytes of the <c>SID</c> are stored in contiguous memory after the
		/// <c>SidStart</c> member. The identifier authority of the <c>SID</c> must be <c>SECURITY_MANDATORY_LABEL_AUTHORITY</c>. The RID of
		/// the <c>SID</c> specifies the mandatory integrity level of the object associated with the SACL that contains this ACE. The
		/// <c>RID</c> must be one of the following values.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <description>Value</description>
		/// <description>Meaning</description>
		/// </listheader>
		/// <item>
		/// <description>0x1000</description>
		/// <description>Low integrity level.</description>
		/// </item>
		/// <item>
		/// <description>0x2000</description>
		/// <description>Medium integrity level.</description>
		/// </item>
		/// <item>
		/// <description>0x3000</description>
		/// <description>High integrity level.</description>
		/// </item>
		/// </list>
		/// </summary>
		public uint SidStart;
	}

	/// <summary>Reserved.</summary>
	// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/ntifs/ns-ntifs-_system_process_trust_label_ace typedef struct
	// _SYSTEM_PROCESS_TRUST_LABEL_ACE { ACE_HEADER Header; ACCESS_MASK Mask; ULONG SidStart; } SYSTEM_PROCESS_TRUST_LABEL_ACE, *PSYSTEM_PROCESS_TRUST_LABEL_ACE;
	[PInvokeData("winnt.h")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct SYSTEM_PROCESS_TRUST_LABEL_ACE : IAccessControlEntry
	{
		/// <summary>
		/// An ACE_HEADER structure that specifies the size and type of the ACE. The structure also contains flags that control inheritance
		/// of the ACE by child objects. The <c>AceType</c> member of the <c>ACE_HEADER</c> structure must be set to
		/// <c>SYSTEM_PROCESS_TRUST_LABEL_ACE_TYPE</c>, and the <c>AceSize</c> member must be set to the total number of bytes allocated for
		/// the <c>SYSTEM_PROCESS_TRUST_LABEL_ACE_ACE</c> structure.
		/// </summary>
		public ACE_HEADER Header;

		/// <summary>The access policy associated with the SACL that contains this ACE.</summary>
		public ACCESS_MASK Mask;

		/// <summary>Specifies the first <c>DWORD</c> of a SID.</summary>
		public uint SidStart;
	}

	/// <summary>
	/// The <c>SYSTEM_RESOURCE_ATTRIBUTE_ACE</c> structure defines an access control entry (ACE) for the system access control list (SACL)
	/// that specifies the system resource attributes for a securable object.
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/winnt/ns-winnt-system_resource_attribute_ace typedef struct
	// _SYSTEM_RESOURCE_ATTRIBUTE_ACE { ACE_HEADER Header; ACCESS_MASK Mask; DWORD SidStart; } SYSTEM_RESOURCE_ATTRIBUTE_ACE, *PSYSTEM_RESOURCE_ATTRIBUTE_ACE;
	[PInvokeData("winnt.h", MSDNShortId = "NS:winnt._SYSTEM_RESOURCE_ATTRIBUTE_ACE")]
	[StructLayout(LayoutKind.Sequential)]
	public struct SYSTEM_RESOURCE_ATTRIBUTE_ACE : IAccessControlEntry
	{
		/// <summary>
		/// An ACE_HEADER structure that specifies the size and type of the ACE. The structure also contains flags that control inheritance
		/// of the ACE by child objects. The <c>AceType</c> member of the <c>ACE_HEADER</c> structure must be set to
		/// <c>SYSTEM_RESOURCE_ATTRIBUTE_ACE</c>, and the <c>AceSize</c> member must be set to the total number of bytes allocated for the
		/// <c>SYSTEM_RESOURCE_ATTRIBUTE_ACE</c> structure.
		/// </summary>
		public ACE_HEADER Header;

		/// <summary>The access policy associated with the SACL that contains this ACE.</summary>
		public ACCESS_MASK Mask;

		/// <summary>
		/// Specifies the first <c>DWORD</c> of a SID. The remaining bytes of the <c>SID</c> are stored in contiguous memory after the
		/// <c>SidStart</c> member in a CLAIM_SECURITY_ATTRIBUTE_RELATIVE_V1 structure.
		/// </summary>
		public uint SidStart;
	}

	/// <summary>
	/// The <c>SYSTEM_SCOPED_POLICY_ID_ACE</c> structure defines an access control entry (ACE) for the system access control list (SACL) that
	/// specifies the scoped policy identifier for a securable object.
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/winnt/ns-winnt-system_scoped_policy_id_ace typedef struct
	// _SYSTEM_SCOPED_POLICY_ID_ACE { ACE_HEADER Header; ACCESS_MASK Mask; DWORD SidStart; } SYSTEM_SCOPED_POLICY_ID_ACE, *PSYSTEM_SCOPED_POLICY_ID_ACE;
	[PInvokeData("winnt.h", MSDNShortId = "NS:winnt._SYSTEM_SCOPED_POLICY_ID_ACE")]
	[StructLayout(LayoutKind.Sequential)]
	public struct SYSTEM_SCOPED_POLICY_ID_ACE : IAccessControlEntry
	{
		/// <summary>
		/// An ACE_HEADER structure that specifies the size and type of the ACE. The structure also contains flags that control inheritance
		/// of the ACE by child objects. The <c>AceType</c> member of the <c>ACE_HEADER</c> structure must be set to
		/// <c>SYSTEM_SCOPED_POLICY_ID_ACE</c>, and the <c>AceSize</c> member must be set to the total number of bytes allocated for the
		/// <c>SYSTEM_SCOPED_POLICY_ID_ACE</c> structure.
		/// </summary>
		public ACE_HEADER Header;

		/// <summary>The access policy associated with the SACL that contains this ACE.</summary>
		public ACCESS_MASK Mask;

		/// <summary>Specifies the first <c>DWORD</c> of a SID.</summary>
		public uint SidStart;
	}

	/// <summary>
	/// The TOKEN_ACCESS_INFORMATION structure specifies all the information in a token that is necessary to perform an access check.
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	[PInvokeData("WinNT.h", MSDNShortId = "bb394726")]
	public struct TOKEN_ACCESS_INFORMATION
	{
		/// <summary>A pointer to a SID_AND_ATTRIBUTES_HASH structure that specifies a hash of the token's security identifier (SID).</summary>
		public IntPtr SidHash;

		/// <summary>A pointer to a SID_AND_ATTRIBUTES_HASH structure that specifies a hash of the token's restricted SID.</summary>
		public IntPtr RestrictedSidHash;

		/// <summary>A pointer to a TOKEN_PRIVILEGES structure that specifies information about the token's privileges.</summary>
		public IntPtr Privileges;

		/// <summary>A LUID structure that specifies the token's identity.</summary>
		public LUID AuthenticationId;

		/// <summary>A value of the TOKEN_TYPE enumeration that specifies the token's type.</summary>
		public TOKEN_TYPE TokenType;

		/// <summary>A value of the SECURITY_IMPERSONATION_LEVEL enumeration that specifies the token's impersonation level.</summary>
		public SECURITY_IMPERSONATION_LEVEL ImpersonationLevel;

		/// <summary>A TOKEN_MANDATORY_POLICY structure that specifies the token's mandatory integrity policy.</summary>
		public TOKEN_MANDATORY_POLICY MandatoryPolicy;

		/// <summary>Reserved. Must be set to zero.</summary>
		public uint Flags;

		/// <summary>
		/// The app container number for the token or zero if this is not an app container token.
		/// <para><c>Windows Server 2008 R2, Windows 7, Windows Server 2008 and Windows Vista:</c> This member is not available.</para>
		/// </summary>
		public uint AppContainerNumber;

		/// <summary>
		/// The app container SID or NULL if this is not an app container token.
		/// <para><c>Windows Server 2008 R2, Windows 7, Windows Server 2008 and Windows Vista:</c> This member is not available.</para>
		/// </summary>
		public PSID PackageSid;

		/// <summary>
		/// Pointer to a SID_AND_ATTRIBUTES_HASH structure that specifies a hash of the token's capability SIDs.
		/// <para><c>Windows Server 2008 R2, Windows 7, Windows Server 2008 and Windows Vista:</c> This member is not available.</para>
		/// </summary>
		public IntPtr CapabilitiesHash;

		/// <summary>The protected process trust level of the token.</summary>
		public PSID TrustLevelSid;

		/// <summary>
		/// Reserved. Must be set to NULL.
		/// <para><c>Prior to Windows 10:</c> This member is not available.</para>
		/// </summary>
		public IntPtr SecurityAttributes;
	}

	/// <summary>
	/// The TOKEN_APPCONTAINER_INFORMATION structure specifies all the information in a token that is necessary for an app container.
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	public struct TOKEN_APPCONTAINER_INFORMATION
	{
		/// <summary>The security identifier (SID) of the app container.</summary>
		public PSID TokenAppContainer;
	}

	/// <summary>The TOKEN_DEFAULT_DACL structure specifies a discretionary access control list (DACL).</summary>
	[StructLayout(LayoutKind.Sequential)]
	[PInvokeData("WinNT.h", MSDNShortId = "aa379623")]
	public struct TOKEN_DEFAULT_DACL
	{
		/// <summary>
		/// A pointer to an ACL structure assigned by default to any objects created by the user. The user is represented by the access token.
		/// </summary>
		public PACL DefaultDacl;
	}

	/// <summary>The TOKEN_ELEVATION structure indicates whether a token has elevated privileges.</summary>
	[StructLayout(LayoutKind.Sequential)]
	public struct TOKEN_ELEVATION
	{
		/// <summary>A nonzero value if the token has elevated privileges; otherwise, a zero value.</summary>
		[MarshalAs(UnmanagedType.Bool)]
		public bool TokenIsElevated;
	}

	/// <summary>The TOKEN_GROUPS structure contains information about the group security identifiers (SIDs) in an access token.</summary>
	[VanaraMarshaler(typeof(SafeAnysizeStructMarshaler<TOKEN_GROUPS>), nameof(GroupCount))]
	[StructLayout(LayoutKind.Sequential)]
	public struct TOKEN_GROUPS
	{
		/// <summary>Specifies the number of groups in the access token.</summary>
		public uint GroupCount;

		/// <summary>Specifies an array of SID_AND_ATTRIBUTES structures that contain a set of SIDs and corresponding attributes.</summary>
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
		public SID_AND_ATTRIBUTES[] Groups;

		/// <summary>Initializes a new instance of the <see cref="TOKEN_GROUPS"/> struct.</summary>
		/// <param name="count">The number of groups.</param>
		public TOKEN_GROUPS(uint count = 0)
		{
			GroupCount = count;
			Groups = new SID_AND_ATTRIBUTES[count];
		}

		/// <summary>Initializes a new instance of the <see cref="TOKEN_GROUPS"/> struct with and array of SIDs and attributes.</summary>
		/// <param name="groups">An array of SID_AND_ATTRIBUTES structures that contain a set of SIDs and corresponding attributes.</param>
		public TOKEN_GROUPS(SID_AND_ATTRIBUTES[] groups)
		{
			Groups = groups;
			GroupCount = (uint)(groups?.Length ?? 0);
		}

		/// <summary>Initializes a new instance of the <see cref="TOKEN_GROUPS"/> struct with a single SID and attribute.</summary>
		/// <param name="sid">The SID.</param>
		/// <param name="attributes">The attributes of the SID.</param>
		public TOKEN_GROUPS(PSID sid, uint attributes = 0) : this(1U) => Groups[0] = new SID_AND_ATTRIBUTES(sid, attributes);
	}

	/// <summary>
	/// The TOKEN_GROUPS_AND_PRIVILEGES structure contains information about the group security identifiers (SIDs) and privileges in an
	/// access token.
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	[PInvokeData("WinNT.h", MSDNShortId = "aa379625")]
	public struct TOKEN_GROUPS_AND_PRIVILEGES
	{
		/// <summary>Number of SIDs in the access token.</summary>
		public uint SidCount;

		/// <summary>Length, in bytes, required to hold all of the user SIDs and the account SID for the group.</summary>
		public uint SidLength;

		/// <summary>A pointer to an array of SID_AND_ATTRIBUTES structures that contain a set of SIDs and corresponding attributes.</summary>
		public IntPtr Sids;

		/// <summary>Number of restricted SIDs.</summary>
		public uint RestrictedSidCount;

		/// <summary>Length, in bytes, required to hold all of the restricted SIDs.</summary>
		public uint RestrictedSidLength;

		/// <summary>
		/// A pointer to an array of SID_AND_ATTRIBUTES structures that contain a set of restricted SIDs and corresponding attributes.
		/// <para>
		/// The Attributes members of the SID_AND_ATTRIBUTES structures can have the same values as those listed for the preceding Sids member.
		/// </para>
		/// </summary>
		public IntPtr RestrictedSids;

		/// <summary>Number of privileges.</summary>
		public uint PrivilegeCount;

		/// <summary>Length, in bytes, needed to hold the privilege array.</summary>
		public uint PrivilegeLength;

		/// <summary>Array of privileges.</summary>
		public IntPtr Privileges;

		/// <summary>Locally unique identifier (LUID) of the authenticator of the token.</summary>
		public LUID AuthenticationId;
	}

	/// <summary>
	/// The TOKEN_LINKED_TOKEN structure contains a handle to a token. This token is linked to the token being queried by the
	/// GetTokenInformation function or set by the SetTokenInformation function.
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	[PInvokeData("WinNT.h", MSDNShortId = "bb530719")]
	public struct TOKEN_LINKED_TOKEN
	{
		/// <summary>A handle to the linked token. When you have finished using the handle, close it by calling the CloseHandle function.</summary>
		public HTOKEN LinkedToken;
	}

	/// <summary>The TOKEN_MANDATORY_LABEL structure specifies the mandatory integrity level for a token.</summary>
	[StructLayout(LayoutKind.Sequential)]
	public struct TOKEN_MANDATORY_LABEL
	{
		/// <summary>A SID_AND_ATTRIBUTES structure that specifies the mandatory integrity level of the token.</summary>
		public SID_AND_ATTRIBUTES Label;
	}

	/// <summary>The <c>TOKEN_MANDATORY_POLICY</c> structure specifies the mandatory integrity policy for a token.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/winnt/ns-winnt-token_mandatory_policy
	// typedef struct _TOKEN_MANDATORY_POLICY { DWORD Policy; } TOKEN_MANDATORY_POLICY, *PTOKEN_MANDATORY_POLICY;
	[PInvokeData("winnt.h", MSDNShortId = "f5fc438b-c4f0-46f6-a188-52ce660d13da")]
	[StructLayout(LayoutKind.Sequential)]
	public struct TOKEN_MANDATORY_POLICY
	{
		/// <summary>
		///   <para>The mandatory integrity access policy for the associated token. This can be one of the following values.</para>
		///   <list type="table">
		///     <listheader>
		///       <term>Value</term>
		///       <term>Meaning</term>
		///     </listheader>
		///     <item>
		///       <term>TOKEN_MANDATORY_POLICY_OFF 0x0</term>
		///       <term>No mandatory integrity policy is enforced for the token.</term>
		///     </item>
		///     <item>
		///       <term>TOKEN_MANDATORY_POLICY_NO_WRITE_UP 0x1</term>
		///       <term>A process associated with the token cannot write to objects that have a greater mandatory integrity level.</term>
		///     </item>
		///     <item>
		///       <term>TOKEN_MANDATORY_POLICY_NEW_PROCESS_MIN 0x2</term>
		///       <term>A process created with the token has an integrity level that is the lesser of the parent-process integrity level and the executable-file integrity level.</term>
		///     </item>
		///     <item>
		///       <term>TOKEN_MANDATORY_POLICY_VALID_MASK 0x3</term>
		///       <term>A combination of TOKEN_MANDATORY_POLICY_NO_WRITE_UP and TOKEN_MANDATORY_POLICY_NEW_PROCESS_MIN.</term>
		///     </item>
		///   </list>
		/// </summary>
		public TokenMandatoryPolicy Policy;
	}

	/// <summary>
	/// The TOKEN_ORIGIN structure contains information about the origin of the logon session. This structure is used by the
	/// GetTokenInformation function.
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	[PInvokeData("WinNT.h", MSDNShortId = "aa379627")]
	public struct TOKEN_ORIGIN
	{
		/// <summary>
		/// Locally unique identifier (LUID) for the logon session. If the token passed to GetTokenInformation resulted from a logon
		/// using explicit credentials, such as passing name, domain, and password to the LogonUser function, then this member will
		/// contain the ID of the logon session that created it. If the token resulted from network authentication, such as a call to
		/// AcceptSecurityContext, or a call to LogonUser with dwLogonType set to LOGON32_LOGON_NETWORK or
		/// LOGON32_LOGON_NETWORK_CLEARTEXT, then this member will be zero.
		/// </summary>
		public LUID OriginatingLogonSession;
	}

	/// <summary>
	/// The TOKEN_OWNER structure contains the default owner security identifier (SID) that will be applied to newly created objects.
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	[PInvokeData("WinNT.h", MSDNShortId = "aa379628")]
	public struct TOKEN_OWNER
	{
		/// <summary>
		/// A pointer to a SID structure representing a user who will become the owner of any objects created by a process using this
		/// access token. The SID must be one of the user or group SIDs already in the token.
		/// </summary>
		public PSID Owner;
	}

	/// <summary>The TOKEN_PRIMARY_GROUP structure specifies a group security identifier (SID) for an access token.</summary>
	[StructLayout(LayoutKind.Sequential)]
	[PInvokeData("WinNT.h", MSDNShortId = "aa379629")]
	public struct TOKEN_PRIMARY_GROUP
	{
		/// <summary>
		/// A pointer to a SID structure representing a group that will become the primary group of any objects created by a process
		/// using this access token. The SID must be one of the group SIDs already in the token.
		/// </summary>
		public PSID PrimaryGroup;
	}

	/// <summary>The <c>TOKEN_PRIVILEGES</c> structure contains information about a set of privileges for an access token.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/winnt/ns-winnt-token_privileges typedef struct _TOKEN_PRIVILEGES { DWORD
	// PrivilegeCount; LUID_AND_ATTRIBUTES Privileges[ANYSIZE_ARRAY]; } TOKEN_PRIVILEGES, *PTOKEN_PRIVILEGES;
	[PInvokeData("winnt.h", MSDNShortId = "c9016511-740f-44f3-92ed-17cc518c6612")]
	[StructLayout(LayoutKind.Sequential)]
	[VanaraMarshaler(typeof(SafeAnysizeStructMarshaler<TOKEN_PRIVILEGES>), nameof(PrivilegeCount))]
	public struct TOKEN_PRIVILEGES
	{
		/// <summary>This must be set to the number of entries in the <c>Privileges</c> array.</summary>
		public uint PrivilegeCount;

		/// <summary>
		/// <para>
		/// Specifies an array of LUID_AND_ATTRIBUTES structures. Each structure contains the LUID and attributes of a privilege. To get
		/// the name of the privilege associated with a <c>LUID</c>, call the LookupPrivilegeName function, passing the address of the
		/// <c>LUID</c> as the value of the lpLuid parameter.
		/// </para>
		/// <para>
		/// <c>Important</c> The constant <c>ANYSIZE_ARRAY</c> is defined as 1 in the public header Winnt.h. To create this array with
		/// more than one element, you must allocate sufficient memory for the structure to take into account additional elements.
		/// </para>
		/// <para>The attributes of a privilege can be a combination of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>SE_PRIVILEGE_ENABLED</term>
		/// <term>The privilege is enabled.</term>
		/// </item>
		/// <item>
		/// <term>SE_PRIVILEGE_ENABLED_BY_DEFAULT</term>
		/// <term>The privilege is enabled by default.</term>
		/// </item>
		/// <item>
		/// <term>SE_PRIVILEGE_REMOVED</term>
		/// <term>Used to remove a privilege. For details, see AdjustTokenPrivileges.</term>
		/// </item>
		/// <item>
		/// <term>SE_PRIVILEGE_USED_FOR_ACCESS</term>
		/// <term>
		/// The privilege was used to gain access to an object or service. This flag is used to identify the relevant privileges in a set
		/// passed by a client application that may contain unnecessary privileges.
		/// </term>
		/// </item>
		/// </list>
		/// </summary>
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
		public LUID_AND_ATTRIBUTES[] Privileges;

		/// <summary>Initializes a new instance of the <see cref="TOKEN_PRIVILEGES"/> structure with a single LUID_AND_ATTRIBUTES value.</summary>
		/// <param name="luid">The LUID value.</param>
		/// <param name="attribute">The attribute value.</param>
		public TOKEN_PRIVILEGES(LUID luid, PrivilegeAttributes attribute)
		{
			PrivilegeCount = 1;
			Privileges = new[] { new LUID_AND_ATTRIBUTES(luid, attribute) };
		}

		/// <summary>Initializes a new instance of the <see cref="TOKEN_PRIVILEGES"/> structure from a list of privileges.</summary>
		/// <param name="values">The values.</param>
		public TOKEN_PRIVILEGES(LUID_AND_ATTRIBUTES[] values)
		{
			PrivilegeCount = (uint)(values?.Length ?? 0);
			Privileges = (LUID_AND_ATTRIBUTES[]?)values?.Clone() ?? new LUID_AND_ATTRIBUTES[0];
		}
	}

	/// <summary>The TOKEN_SOURCE structure identifies the source of an access token.</summary>
	[StructLayout(LayoutKind.Sequential)]
	[PInvokeData("WinNT.h", MSDNShortId = "aa379631")]
	public struct TOKEN_SOURCE
	{
		private const int TOKEN_SOURCE_LENGTH = 8;

		/// <summary>
		/// Specifies an 8-byte character string used to identify the source of an access token. This is used to distinguish between such
		/// sources as Session Manager, LAN Manager, and RPC Server. A string, rather than a constant, is used to identify the source so
		/// users and developers can make extensions to the system, such as by adding other networks, that act as the source of access tokens.
		/// </summary>
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = TOKEN_SOURCE_LENGTH)]
		public char[] SourceName;

		/// <summary>
		/// Specifies a locally unique identifier (LUID) provided by the source component named by the SourceName member. This value aids
		/// the source component in relating context blocks, such as session-control structures, to the token. This value is typically,
		/// but not necessarily, an LUID.
		/// </summary>
		public LUID SourceIdentifier;
	}

	/// <summary>
	/// The TOKEN_STATISTICS structure contains information about an access token. An application can retrieve this information by
	/// calling the GetTokenInformation function.
	/// </summary>
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	[PInvokeData("WinNT.h", MSDNShortId = "aa379632")]
	public struct TOKEN_STATISTICS
	{
		/// <summary>Specifies a locally unique identifier (LUID) that identifies this instance of the token object.</summary>
		public LUID TokenId;

		/// <summary>
		/// Specifies an LUID assigned to the session this token represents. There can be many tokens representing a single logon session.
		/// </summary>
		public LUID AuthenticationId;

		/// <summary>Specifies the time at which this token expires. Expiration times for access tokens are not currently supported.</summary>
		public long ExpirationTime;

		/// <summary>Specifies a TOKEN_TYPE enumeration type indicating whether the token is a primary or impersonation token.</summary>
		public TOKEN_TYPE TokenType;

		/// <summary>
		/// Specifies a SECURITY_IMPERSONATION_LEVEL enumeration type indicating the impersonation level of the token. This member is
		/// valid only if the TokenType is TokenImpersonation.
		/// </summary>
		public SECURITY_IMPERSONATION_LEVEL ImpersonationLevel;

		/// <summary>Specifies the amount, in bytes, of memory allocated for storing default protection and a primary group identifier.</summary>
		public uint DynamicCharged;

		/// <summary>
		/// Specifies the portion of memory allocated for storing default protection and a primary group identifier not already in use.
		/// This value is returned as a count of free bytes.
		/// </summary>
		public uint DynamicAvailable;

		/// <summary>Specifies the number of supplemental group security identifiers (SIDs) included in the token.</summary>
		public uint GroupCount;

		/// <summary>Specifies the number of privileges included in the token.</summary>
		public uint PrivilegeCount;

		/// <summary>
		/// Specifies an LUID that changes each time the token is modified. An application can use this value as a test of whether a
		/// security context has changed since it was last used.
		/// </summary>
		public LUID ModifiedId;
	}

	/// <summary>The TOKEN_USER structure identifies the user associated with an access token.</summary>
	[StructLayout(LayoutKind.Sequential)]
	public struct TOKEN_USER
	{
		/// <summary>
		/// Specifies a SID_AND_ATTRIBUTES structure representing the user associated with the access token. There are currently no
		/// attributes defined for user security identifiers (SIDs).
		/// </summary>
		public SID_AND_ATTRIBUTES User;
	}

	/// <summary>Known SID authorities.</summary>
	public static class KnownSIDAuthority
	{
		/// <summary>The application package authority</summary>
		public static readonly PSID_IDENTIFIER_AUTHORITY SECURITY_APP_PACKAGE_AUTHORITY = new byte[] { 0, 0, 0, 0, 0, 15 };

		/// <summary>The authentication authority</summary>
		public static readonly PSID_IDENTIFIER_AUTHORITY SECURITY_AUTHENTICATION_AUTHORITY = new byte[] { 0, 0, 0, 0, 0, 18 };

		/// <summary>The identifier authority for the creator owner.</summary>
		public static readonly PSID_IDENTIFIER_AUTHORITY SECURITY_CREATOR_SID_AUTHORITY = new byte[] { 0, 0, 0, 0, 0, 3 };

		/// <summary>The identifier authority for locally connected users.</summary>
		public static readonly PSID_IDENTIFIER_AUTHORITY SECURITY_LOCAL_SID_AUTHORITY = new byte[] { 0, 0, 0, 0, 0, 2 };

		/// <summary>The mandatory label authority</summary>
		public static readonly PSID_IDENTIFIER_AUTHORITY SECURITY_MANDATORY_LABEL_AUTHORITY = new byte[] { 0, 0, 0, 0, 0, 16 };

		/// <summary>The non-unique identifier authority.</summary>
		public static readonly PSID_IDENTIFIER_AUTHORITY SECURITY_NON_UNIQUE_AUTHORITY = new byte[] { 0, 0, 0, 0, 0, 4 };

		/// <summary>The Windows security authority</summary>
		public static readonly PSID_IDENTIFIER_AUTHORITY SECURITY_NT_AUTHORITY = new byte[] { 0, 0, 0, 0, 0, 5 };

		/// <summary>The identifier authority with no members.</summary>
		public static readonly PSID_IDENTIFIER_AUTHORITY SECURITY_NULL_SID_AUTHORITY = new byte[] { 0, 0, 0, 0, 0, 0 };

		/// <summary>The process trust authority</summary>
		public static readonly PSID_IDENTIFIER_AUTHORITY SECURITY_PROCESS_TRUST_AUTHORITY = new byte[] { 0, 0, 0, 0, 0, 19 };

		/// <summary>The security resource manager authority</summary>
		public static readonly PSID_IDENTIFIER_AUTHORITY SECURITY_RESOURCE_MANAGER_AUTHORITY = new byte[] { 0, 0, 0, 0, 0, 9 };

		/// <summary>The scoped policy identifier authority</summary>
		public static readonly PSID_IDENTIFIER_AUTHORITY SECURITY_SCOPED_POLICY_ID_AUTHORITY = new byte[] { 0, 0, 0, 0, 0, 17 };

		/// <summary>The identifier authority all users.</summary>
		public static readonly PSID_IDENTIFIER_AUTHORITY SECURITY_WORLD_SID_AUTHORITY = new byte[] { 0, 0, 0, 0, 0, 1 };
	}

	/// <summary>Implements comparison and equality methods for <see cref="PACE"/> and <see cref="SafePACE"/>.</summary>
	/// <seealso cref="IComparer{T}"/>
	/// <seealso cref="IEqualityComparer{T}"/>
	public class AceComparer : IComparer<PACE>, IComparer<SafePACE>, IEqualityComparer<PACE>, IEqualityComparer<SafePACE>
	{
		/// <summary>Gets an instance of <see cref="AceComparer"/>.</summary>
		public static readonly AceComparer Instance = new();

		bool IEqualityComparer<PACE>.Equals(PACE x, PACE y) => WinNTExtensions.CompareTo(x, y) == 0;
		bool IEqualityComparer<SafePACE>.Equals(SafePACE? x, SafePACE? y) => WinNTExtensions.CompareTo(x is null ? PACE.NULL : (PACE)x, y is null ? PACE.NULL : (PACE)y) == 0;
		int IEqualityComparer<PACE>.GetHashCode(PACE obj) => obj.GetAceStruct()?.GetHashCode() ?? 0;
		int IEqualityComparer<SafePACE>.GetHashCode(SafePACE? obj) => obj is null ? 0 : ((IEqualityComparer<PACE>)this).GetHashCode((PACE)obj);
		int IComparer<PACE>.Compare(PACE x, PACE y) => WinNTExtensions.CompareTo(x, y);
		int IComparer<SafePACE>.Compare(SafePACE? x, SafePACE? y) => WinNTExtensions.CompareTo(x is null ? PACE.NULL : (PACE)x, y is null ? PACE.NULL : (PACE)y);
	}

	/// <summary>Known RIDs</summary>
	public static class KnownSIDRelativeID
	{
		/// <summary/>
		public const int SECURITY_APP_PACKAGE_BASE_RID = 0x00000002;

		/// <summary/>
		public const int SECURITY_CAPABILITY_APP_RID = 0x00000040;

		/// <summary/>
		public const int SECURITY_CAPABILITY_BASE_RID = 0x00000003;

		/// <summary>The security creator group rid</summary>
		public const int SECURITY_CREATOR_GROUP_RID = 0x00000001;

		/// <summary>The security creator group server rid</summary>
		public const int SECURITY_CREATOR_GROUP_SERVER_RID = 0x00000003;

		/// <summary>The security creator owner rid</summary>
		public const int SECURITY_CREATOR_OWNER_RID = 0x00000000;

		/// <summary>The security creator owner rights rid</summary>
		public const int SECURITY_CREATOR_OWNER_RIGHTS_RID = 0x00000004;

		/// <summary>The security creator owner server rid</summary>
		public const int SECURITY_CREATOR_OWNER_SERVER_RID = 0x00000002;

		/// <summary>The security local logon rid</summary>
		public const int SECURITY_LOCAL_LOGON_RID = 0x00000001;

		/// <summary>The security local rid</summary>
		public const int SECURITY_LOCAL_RID = 0x00000000;

		/// <summary>High integrity.</summary>
		public const int SECURITY_MANDATORY_HIGH_RID = 0x00003000;

		/// <summary>Low integrity.</summary>
		public const int SECURITY_MANDATORY_LOW_RID = 0x00001000;

		/// <summary>Medium-high integrity.</summary>
		public const int SECURITY_MANDATORY_MEDIUM_PLUS_RID = SECURITY_MANDATORY_MEDIUM_RID + 0x100;

		/// <summary>Medium integrity.</summary>
		public const int SECURITY_MANDATORY_MEDIUM_RID = 0x00002000;

		/// <summary>Protected process.</summary>
		public const int SECURITY_MANDATORY_PROTECTED_PROCESS_RID = 0x00005000;

		/// <summary>System integrity.</summary>
		public const int SECURITY_MANDATORY_SYSTEM_RID = 0x00004000;

		/// <summary>Untrusted.</summary>
		public const int SECURITY_MANDATORY_UNTRUSTED_RID = 0x00000000;

		/// <summary>The security null rid</summary>
		public const int SECURITY_NULL_RID = 0x00000000;

		/// <summary>The security world rid</summary>
		public const int SECURITY_WORLD_RID = 0x00000000;
	}

	/// <summary>
	/// The PRIVILEGE_SET structure specifies a set of privileges. It is also used to indicate which, if any, privileges are held by a
	/// user or group requesting access to an object.
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	public class PRIVILEGE_SET
	{
		/// <summary>Specifies the number of privileges in the privilege set.</summary>
		public uint PrivilegeCount;

		/// <summary>
		/// Specifies a control flag related to the privileges. The PRIVILEGE_SET_ALL_NECESSARY control flag is currently defined. It
		/// indicates that all of the specified privileges must be held by the process requesting access. If this flag is not set, the
		/// presence of any privileges in the user's access token grants the access.
		/// </summary>
		public PrivilegeSetControl Control;

		/// <summary>Specifies an array of LUID_AND_ATTRIBUTES structures describing the set's privileges.</summary>
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
		public LUID_AND_ATTRIBUTES[] Privilege;

		/// <summary>Initializes a new instance of the <see cref="PRIVILEGE_SET"/> class with a single LUID_AND_ATTRIBUTES value.</summary>
		/// <param name="control">The control flag. See <see cref="Control"/>.</param>
		/// <param name="luid">The LUID value.</param>
		/// <param name="attribute">The attribute value.</param>
		public PRIVILEGE_SET(PrivilegeSetControl control, LUID luid, PrivilegeAttributes attribute)
		{
			PrivilegeCount = 1;
			Control = control;
			Privilege = new[] { new LUID_AND_ATTRIBUTES(luid, attribute) };
		}

		/// <summary>Initializes a new instance of the <see cref="PRIVILEGE_SET"/> class.</summary>
		/// <param name="control">The control flag. See <see cref="Control"/>.</param>
		/// <param name="privileges">A list of privileges to assign to the structure.</param>
		public PRIVILEGE_SET(PrivilegeSetControl control, LUID_AND_ATTRIBUTES[]? privileges)
		{
			PrivilegeCount = (uint)(privileges?.Length ?? 0);
			Control = control;
			Privilege = (LUID_AND_ATTRIBUTES[]?)privileges?.Clone() ?? new LUID_AND_ATTRIBUTES[0];
		}

		/// <summary>Initializes a new instance of the <see cref="PRIVILEGE_SET"/> class.</summary>
		internal PRIVILEGE_SET() : this(PrivilegeSetControl.PRIVILEGE_SET_ALL_NECESSARY, null)
		{
		}

		/// <summary>Initializes a new instance of the <see cref="PRIVILEGE_SET"/> class from a pointer to allocated memory.</summary>
		internal PRIVILEGE_SET(IntPtr ptr)
		{
			int sz = 0;
			if (ptr != IntPtr.Zero)
			{
				sz = sizeof(uint);
				PrivilegeCount = (uint)Marshal.ReadInt32(ptr);
				Control = (PrivilegeSetControl)Marshal.ReadInt32(ptr, sz);
			}
			Privilege = PrivilegeCount > 0 ? ptr.ToArray<LUID_AND_ATTRIBUTES>((int)PrivilegeCount, sz * 2)! : new LUID_AND_ATTRIBUTES[0];
		}

		/// <summary>Gets the size in bytes of this instance.</summary>
		/// <value>The size in bytes.</value>
		public uint SizeInBytes => (uint)Marshal.SizeOf(typeof(uint)) * 2 + (uint)(Marshal.SizeOf(typeof(LUID_AND_ATTRIBUTES)) * (PrivilegeCount == 0 ? 1 : PrivilegeCount));

		/// <summary>Returns a <see cref="System.String"/> that represents this instance.</summary>
		/// <returns>A <see cref="System.String"/> that represents this instance.</returns>
		public override string ToString() => $"Count:{PrivilegeCount}";

		/// <summary>Initializes a new <c>PRIVILEGE_SET</c> the with capacity to hold the specified number of privileges.</summary>
		/// <param name="privilegeCount">The privilege count to allocate.</param>
		/// <returns>A <c>PRIVILEGE_SET</c> instance with sufficient capacity for marshaling.</returns>
		public static PRIVILEGE_SET InitializeWithCapacity(int privilegeCount = 1) => new() { PrivilegeCount = (uint)privilegeCount };

		internal class Marshaler : ICustomMarshaler
		{
			public static ICustomMarshaler GetInstance(string _) => new Marshaler();

			public void CleanUpManagedData(object ManagedObj)
			{
			}

			public void CleanUpNativeData(IntPtr pNativeData) => Marshal.FreeCoTaskMem(pNativeData);

			public int GetNativeDataSize() => -1;

			public IntPtr MarshalManagedToNative(object ManagedObj)
			{
				if (ManagedObj is not PRIVILEGE_SET ps) return IntPtr.Zero;
				var ptr = Marshal.AllocCoTaskMem((int)ps.SizeInBytes);
				if (ps.Privilege.Length != ps.PrivilegeCount)
					ptr.FillMemory(0, (int)ps.SizeInBytes);
				Marshal.WriteInt32(ptr, (int)ps.PrivilegeCount);
				Marshal.WriteInt32(ptr, Marshal.SizeOf(typeof(int)), (int)ps.Control);
				ptr.Write(ps.Privilege, Marshal.SizeOf(typeof(int)) * 2);
				return ptr;
			}

			public object MarshalNativeToManaged(IntPtr pNativeData) => new PRIVILEGE_SET(pNativeData);
		}
	}

	/// <summary>
	/// <para>The <c>SID_IDENTIFIER_AUTHORITY</c> structure represents the top-level authority of a security identifier (SID).</para>
	/// </summary>
	/// <remarks>
	/// <para>The identifier authority value identifies the agency that issued the SID. The following identifier authorities are predefined.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Identifier authority</term>
	/// <term>Value</term>
	/// </listheader>
	/// <item>
	/// <term>SECURITY_NULL_SID_AUTHORITY</term>
	/// <term>0</term>
	/// </item>
	/// <item>
	/// <term>SECURITY_WORLD_SID_AUTHORITY</term>
	/// <term>1</term>
	/// </item>
	/// <item>
	/// <term>SECURITY_LOCAL_SID_AUTHORITY</term>
	/// <term>2</term>
	/// </item>
	/// <item>
	/// <term>SECURITY_CREATOR_SID_AUTHORITY</term>
	/// <term>3</term>
	/// </item>
	/// <item>
	/// <term>SECURITY_NON_UNIQUE_AUTHORITY</term>
	/// <term>4</term>
	/// </item>
	/// <item>
	/// <term>SECURITY_NT_AUTHORITY</term>
	/// <term>5</term>
	/// </item>
	/// <item>
	/// <term>SECURITY_RESOURCE_MANAGER_AUTHORITY</term>
	/// <term>9</term>
	/// </item>
	/// </list>
	/// <para>A SID must contain a top-level authority and at least one relative identifier (RID) value.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winnt/ns-winnt-_sid_identifier_authority typedef struct
	// _SID_IDENTIFIER_AUTHORITY { BYTE Value[6]; } SID_IDENTIFIER_AUTHORITY, *PSID_IDENTIFIER_AUTHORITY;
	[PInvokeData("winnt.h", MSDNShortId = "450a6d2d-d2e4-4098-90af-a8024ddcfcb5")]
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	public class PSID_IDENTIFIER_AUTHORITY : IEquatable<PSID_IDENTIFIER_AUTHORITY>, IEquatable<SID_IDENTIFIER_AUTHORITY>, IEquatable<byte[]>
	{
		/// <summary>An array of 6 bytes specifying a SID's top-level authority.</summary>
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
		public byte[] Value = new byte[6];

		/// <summary>Initializes a new instance of the <see cref="SID_IDENTIFIER_AUTHORITY"/> struct.</summary>
		/// <param name="value">The value.</param>
		/// <exception cref="ArgumentOutOfRangeException">value</exception>
		public PSID_IDENTIFIER_AUTHORITY(byte[] value)
		{
			if (value == null || value.Length != 6)
				throw new ArgumentOutOfRangeException(nameof(value));
			Array.Copy(value, Value, 6);
		}

		/// <summary>Initializes a new instance of the <see cref="SID_IDENTIFIER_AUTHORITY"/> struct.</summary>
		/// <param name="value">The value.</param>
		public PSID_IDENTIFIER_AUTHORITY(long value) => LongValue = value;

		internal PSID_IDENTIFIER_AUTHORITY(IntPtr existingPtr)
		{
			if (existingPtr == IntPtr.Zero)
				Value = existingPtr.ToByteArray(6)!;
		}

		private PSID_IDENTIFIER_AUTHORITY()
		{
		}

		/// <summary>Gets or sets the long value.</summary>
		/// <value>The long value.</value>
		public long LongValue
		{
			get
			{
				long nAuthority = 0;
				for (var i = 0; i <= 5; i++)
					nAuthority |= (long)Value[i] << (8 * i);
				return nAuthority;
			}
			set
			{
				var bsia = BitConverter.GetBytes(value);
				for (var i = 0; i <= 5; i++)
					Value[i] = bsia[5 - i];
			}
		}

		/// <summary>Performs an implicit conversion from byte[] to <see cref="PSID_IDENTIFIER_AUTHORITY"/>.</summary>
		/// <param name="bytes">The bytes.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator PSID_IDENTIFIER_AUTHORITY(byte[] bytes) => new(bytes);

		/// <summary>Performs an implicit conversion from <see cref="SID_IDENTIFIER_AUTHORITY"/> to <see cref="PSID_IDENTIFIER_AUTHORITY"/>.</summary>
		/// <param name="sia">The sia.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator PSID_IDENTIFIER_AUTHORITY(SID_IDENTIFIER_AUTHORITY sia) => new(sia.Value);

		/// <summary>Implements the operator !=.</summary>
		/// <param name="h1">The first handle.</param>
		/// <param name="h2">The second handle.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator !=(PSID_IDENTIFIER_AUTHORITY h1, PSID_IDENTIFIER_AUTHORITY h2) => !(h1 == h2);

		/// <summary>Implements the operator ==.</summary>
		/// <param name="h1">The first handle.</param>
		/// <param name="h2">The second handle.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator ==(PSID_IDENTIFIER_AUTHORITY h1, PSID_IDENTIFIER_AUTHORITY h2) => h1.Equals(h2);

		/// <summary>Indicates whether the current object is equal to another object of the same type.</summary>
		/// <param name="other">An object to compare with this object.</param>
		/// <returns>
		/// <see langword="true"/> if the current object is equal to the <paramref name="other"/> parameter; otherwise, <see langword="false"/>.
		/// </returns>
		public bool Equals(PSID_IDENTIFIER_AUTHORITY? other) => Equals6Bytes(Value, other?.Value);

		/// <summary>Indicates whether the current object is equal to another object of the same type.</summary>
		/// <param name="other">An object to compare with this object.</param>
		/// <returns>
		/// <see langword="true"/> if the current object is equal to the <paramref name="other"/> parameter; otherwise, <see langword="false"/>.
		/// </returns>
		public bool Equals(SID_IDENTIFIER_AUTHORITY other) => Equals6Bytes(Value, other.Value);

		/// <summary>Indicates whether the current object is equal to another object of the same type.</summary>
		/// <param name="other">An object to compare with this object.</param>
		/// <returns>
		/// <see langword="true"/> if the current object is equal to the <paramref name="other"/> parameter; otherwise, <see langword="false"/>.
		/// </returns>
		public bool Equals(byte[]? other) => Equals6Bytes(Value, other);

		/// <inheritdoc/>
		public override bool Equals(object? obj) => obj switch
		{
			PSID_IDENTIFIER_AUTHORITY h => Equals(h),
			SID_IDENTIFIER_AUTHORITY h => Equals(h),
			byte[] h => Equals(h),
			_ => ReferenceEquals(Value, obj),
		};

		/// <inheritdoc/>
		public override int GetHashCode() => LongValue.GetHashCode();

		internal static bool Equals6Bytes(byte[]? a, byte[]? b)
		{
			if (a is null || b is null || a.Length != 6 || b.Length != 6)
				return false;
			for (int i = 0; i < 6; i++)
				if (a[i] != b[i])
					return false;
			return true;
		}
	}

	/// <summary>A SafeHandle for access control entries. If owned, will call LocalFree on the pointer when disposed.</summary>
	[DebuggerDisplay("{DebugString}")]
	public class SafePACE : SafeMemoryHandle<LocalMemoryMethods>, ISecurityObject, IComparable<SafePACE>, IComparable<PACE>, IEquatable<SafePACE>, IEquatable<PACE>
	{
		private static readonly int hdrSz = Marshal.SizeOf(typeof(ACE_HEADER));
		private static readonly int structSize = Marshal.SizeOf(typeof(ACCESS_ALLOWED_ACE));

		/// <summary>The null value for a SafePACE.</summary>
		public static readonly SafePACE Null = new();

		/// <summary>Initializes a new instance of the <see cref="SafePACE"/> class.</summary>
		public SafePACE() : base(IntPtr.Zero, 0, true) { }

		/// <summary>Initializes a new instance of the <see cref="SafePACE"/> class from an existing pointer, copying its content if owning.</summary>
		/// <param name="pAce">The access control entry pointer.</param>
		/// <param name="ownsHandle">if set to <see langword="true"/>, this instance will release the memory behind the <paramref name="pAce"/>.</param>
		public SafePACE(PACE pAce, bool ownsHandle = false) : base(IntPtr.Zero, 0, ownsHandle)
		{
			if (!ownsHandle)
			{
				SetHandle(((IntPtr)pAce));
				sz = pAce.Length();
			}
			else
			{
				Size = pAce.Length();
				((IntPtr)pAce).CopyTo(handle, sz);
			}
		}

		/// <summary>Initializes a new instance of the <see cref="SafePACE"/> class to an empty memory buffer.</summary>
		/// <param name="size">The size of the uninitialized access control entry.</param>
		public SafePACE(int size) : base(Macros.ALIGN_TO_MULTIPLE(size, 4))
		{
			if (size <= structSize)
				throw new ArgumentOutOfRangeException(nameof(size), $"The size must be larger than {structSize}.");
		}

		/// <summary>Initializes a new instance of the <see cref="SafePACE"/> class.</summary>
		/// <param name="bytes">An array of bytes that contain an existing access control entry.</param>
		public SafePACE(byte[] bytes) : this(bytes?.Length ?? 0)
		{
			if (bytes is null) return;
			Marshal.Copy(bytes, 0, handle, bytes.Length);
		}

		/// <summary>Initializes a new instance of the <see cref="SafePACE"/> class.</summary>
		/// <param name="type">Specifies the ACE type.</param>
		/// <param name="accessMask">
		/// A set of bit flags that use the ACCESS_MASK format. These flags specify the access rights that the new ACE allows for the
		/// specified security identifier (SID).
		/// </param>
		/// <param name="trusteeSid">A pointer to a SID that identifies the user, group, or logon session to which the new ACE allows access.</param>
		/// <param name="aceFlags">
		/// A set of bit flags that control ACE inheritance. The function sets these flags in the AceFlags member of the ACE_HEADER structure
		/// of the new ACE.
		/// </param>
		/// <param name="objectTypeGuid">
		/// An optional GUID structure that identifies the type of object, property set, or property protected by the new ACE. If this
		/// parameter is <see langword="null"/>, the new ACE protects the object to which the DACL is assigned.
		/// </param>
		/// <param name="inheritedObjectTypeGuid">
		/// An optional GUID structure that identifies the type of object that can inherit the new ACE. If this parameter is non-NULL, only
		/// the specified object type can inherit the ACE. If <see langword="null"/>, any type of child object can inherit the ACE. In either
		/// case, inheritance is also controlled by the value of the AceFlags parameter, as well as by any protection against inheritance
		/// placed on the child objects.
		/// </param>
		/// <param name="appData">The optional application data to append to the end of the ACE.</param>
		public SafePACE(ACE_TYPE type, ACCESS_MASK accessMask, PSID trusteeSid, ACE_FLAG aceFlags = 0, Guid? objectTypeGuid = null, Guid? inheritedObjectTypeGuid = null, byte[]? appData = null)
		{
			if (type.IsAlarmAceType()) throw new ArgumentException("Alarm ACEs are not supported.", nameof(type));
			if (!type.IsValid()) throw new ArgumentException("Invalid ACE type.", nameof(type));

			ACE_HEADER hdr = new() { AceType = (AceType)type, AceFlags = (AceFlags)aceFlags };
			var xSz = Macros.ALIGN_TO_MULTIPLE(trusteeSid.Length() + appData?.Length ?? 0, 4);
			if (type.IsObjectAceType() || (objectTypeGuid is null && inheritedObjectTypeGuid is null))
			{
				ACCESS_ALLOWED_ACE ace = new() { Header = hdr, Mask = accessMask };
				ace.Header.AceSize = Convert.ToUInt16(Marshal.SizeOf(ace) - sizeof(uint));
				Size = Macros.ALIGN_TO_MULTIPLE(ace.Header.AceSize + xSz, 4);
				handle.Write(ace);
			}
			else
			{
				ACCESS_ALLOWED_OBJECT_ACE ace = new() { Header = hdr, Mask = accessMask, ObjectType = objectTypeGuid.GetValueOrDefault(), InheritedObjectType = inheritedObjectTypeGuid.GetValueOrDefault() };
				ace.Header.AceSize = Convert.ToUInt16(Marshal.SizeOf(ace) - sizeof(uint));
				Size = Macros.ALIGN_TO_MULTIPLE(ace.Header.AceSize + xSz, 4);
				handle.Write(ace);
			}
			TrusteeSid = trusteeSid;
			if (appData is not null)
				ApplicationData = appData;
		}

		/// <summary>Gets the type of the ace.</summary>
		/// <value>The type of the ace.</value>
		public ACE_TYPE AceType => IsInvalid ? 0 : (ACE_TYPE)Marshal.ReadByte(handle);

		/// <summary>Gets or sets the SID for an ACE.</summary>
		/// <returns>A pointer to a SID value in memory.</returns>
		public byte[] ApplicationData
		{
			get
			{
				if (IsInvalid) throw new NullReferenceException("No allocated memory.");
				if (AceType.IsAlarmAceType())
					throw new InvalidOperationException("For Alarm ACEs, the application data can only be retrieved through the TrusteeAce.");
				var offset = SidOffset;
				if (offset + 8 > Size || !IsValidSid((PSID)handle.Offset(offset)))
					throw new InvalidOperationException("Invalid SID value is preventing the retreival of the data.");
				offset += GetLengthSid((PSID)handle.Offset(offset));
				return offset >= Length ? [] : handle.ToByteArray((int)Length - offset, offset, Size)!;
			}
			set
			{
				if (IsInvalid) throw new NullReferenceException("No allocated memory.");
				if (AceType.IsAlarmAceType())
					throw new InvalidOperationException("For Alarm ACEs, the application data must be set by adding a valid ACE with assigned data.");
				var offset = SidOffset;
				if (offset + 8 > Size || !IsValidSid((PSID)handle.Offset(offset)))
					throw new InvalidOperationException("The TrusteeSid value must be set before adding data.");
				offset += GetLengthSid((PSID)handle.Offset(offset));
				EnsureCapacity(value.Length);
				handle.Write(value, offset, Size);
				Length = Size;
			}
		}

		/// <summary>Gets the <see cref="ACE_HEADER"/> of this instance.</summary>
		/// <value>The header.</value>
		public ref ACE_HEADER Header => ref handle.AsRef<ACE_HEADER>(0, Size);

		/// <summary>Gets or sets the InheritedObjectType for an ACE, if possible.</summary>
		/// <returns>The InheritedObjectType value, if this is an object ACE, otherwise <see langword="null"/>.</returns>
		public Guid? InheritedObjectType
		{
			get => ((PACE)handle).GetInheritedObjectType();
			set
			{
				if (!IsObjectAce) throw new InvalidOperationException($"{nameof(InheritedObjectType)} can only be set on an Object ACE.");
				ref ACCESS_ALLOWED_OBJECT_ACE oa = ref handle.AsRef<ACCESS_ALLOWED_OBJECT_ACE>();
				oa.InheritedObjectType = value ?? Guid.Empty;
			}
		}

		/// <summary>Determines if a ACE is inhertied.</summary>
		/// <returns><see langword="true"/> if is this is inherited; otherwise, <see langword="false"/>.</returns>
		public bool IsInherited => IsInvalid ? false : ((AceFlags)Marshal.ReadByte(handle, 1)).IsFlagSet(AceFlags.Inherited);

		/// <summary>Determines if a ACE is an object ACE.</summary>
		/// <returns><see langword="true"/> if is this is an object ACE; otherwise, <see langword="false"/>.</returns>
		public bool IsObjectAce => ((PACE)handle).IsObjectAce();

		/// <summary>
		/// Gets the length, in bytes, of a structurally valid access control list. The length includes the length of all associated structures.
		/// </summary>
		public uint Length
		{
			get => IsInvalid ? 0U : (uint)unchecked((ushort)Marshal.ReadInt16(handle, 2));
			private set => Marshal.WriteInt16(handle, sizeof(ushort), unchecked((short)Macros.ALIGN_TO_MULTIPLE(value, 4)));
		}

		/// <summary>Gets or sets the mask for an ACE.</summary>
		/// <returns>The ACCESS_MASK value.</returns>
		public ACCESS_MASK Mask
		{
			get => ((PACE)handle).GetMask();
			set
			{
				if (IsInvalid) throw new NullReferenceException("No allocated memory.");
				Marshal.WriteInt32(handle, hdrSz, unchecked((int)value));
			}
		}

		/// <summary>Gets or sets the object flags for an ACE, if possible.</summary>
		/// <returns>The object flags value, if this is an object ACE, otherwise <see langword="null"/>.</returns>
		public ObjectAceFlags? ObjectAceFlags
		{
			get => IsObjectAce ? (ObjectAceFlags)unchecked((uint)Marshal.ReadInt32(handle, hdrSz + sizeof(uint))) : null;
			set
			{
				if (!IsObjectAce) throw new InvalidOperationException($"{nameof(ObjectAceFlags)} can only be set on an Object ACE.");
				ref ACCESS_ALLOWED_OBJECT_ACE oa = ref handle.AsRef<ACCESS_ALLOWED_OBJECT_ACE>();
				oa.Flags = value ?? 0;
			}
		}

		/// <summary>Gets or sets the ObjectType for an ACE, if possible.</summary>
		/// <returns>The ObjectType value, if this is an object ACE, otherwise <see langword="null"/>.</returns>
		public Guid? ObjectType
		{
			get => ((PACE)handle).GetObjectType();
			set
			{
				if (!IsObjectAce) throw new InvalidOperationException($"{nameof(ObjectType)} can only be set on an Object ACE.");
				ref ACCESS_ALLOWED_OBJECT_ACE oa = ref handle.AsRef<ACCESS_ALLOWED_OBJECT_ACE>();
				oa.ObjectType = value ?? Guid.Empty;
			}
		}

		/// <inheritdoc/>
		public override SizeT Size
		{
			get => base.Size;
			set
			{
				if (value == Size) return;
				if (value < Length)
					throw new ArgumentException("Current ACE consumes more space that has been specified.", nameof(Size));
				// Make sure divisible by 4.
				if (value % 4 != 0)
					throw new ArgumentOutOfRangeException(nameof(Size), "ACE values must be DWORD aligned. This value must be a multiple of 4.");
				// Use base property to copy and expand the underlying memory
				base.Size = value;
			}
		}

		/// <summary>Gets or sets the Trustee ACE for an Alarm ACE.</summary>
		/// <returns>A pointer to an ACE in memory.</returns>
		public SafePACE? TrusteeAce
		{
			get
			{
				if (IsInvalid) throw new NullReferenceException("No allocated memory.");
				if (!AceType.IsAlarmAceType()) return null;
				var offset = SidOffset;
				if (offset * 2 > Size)
					return SafePACE.Null;
				return new((PACE)handle.Offset(offset), true);
			}
			set
			{
				if (value is null || value.IsInvalid) throw new ArgumentNullException(nameof(TrusteeAce), "Only non-null values can be used to set TrusteeAce.");
				if (IsInvalid) throw new NullReferenceException("No allocated memory.");
				if (!AceType.IsAlarmAceType()) throw new InvalidOperationException("This value can only be set for Alarm ACEs");

				var offset = SidOffset;
				EnsureCapacity(value.Length);
				value.DangerousGetHandle().CopyTo(handle.Offset(offset), value.Length);
				Length = Size;
			}
		}

		/// <summary>Gets or sets the SID for an ACE.</summary>
		/// <returns>A pointer to a SID value in memory.</returns>
		public SafePSID TrusteeSid
		{
			get
			{
				if (IsInvalid) throw new NullReferenceException("No allocated memory.");
				if (AceType.IsAlarmAceType())
					throw new InvalidOperationException("For Alarm ACEs, the SID can only be retrieved through the TrusteeAce.");
				var offset = SidOffset;
				if (offset + 8 > Size)
					return SafePSID.Null;
				return SafePSID.CreateFromPtr(handle.Offset(offset));
			}
			set
			{
				if (IsInvalid) throw new NullReferenceException("No allocated memory.");
				if (AceType.IsAlarmAceType())
					throw new InvalidOperationException("For Alarm ACEs, the SID must be set by adding a valid ACE");
				var offset = SidOffset;
				EnsureCapacity(value.Length);
				value.DangerousGetHandle().CopyTo(handle.Offset(offset), value.Length);
				Length = Size;
			}
		}

		/// <summary>Gets an <see cref="IComparer{T}"/> for <see cref="SafePACE"/> values.</summary>
		/// <value>The comparer.</value>
		public static IComparer<SafePACE> Comparer => AceComparer.Instance;

		private int SidOffset => hdrSz + sizeof(uint) + (IsObjectAce ? sizeof(uint) + Marshal.SizeOf(typeof(Guid)) * 2 : 0);

		internal string DebugString => IsInvalid ? "NULL" : $"Principal: {TrusteeSid:N}, Type: {AceType}, Access: {Mask}, Flags: {Header.AceFlags}, Size:{Length}";

		/// <summary>Performs an explicit conversion from <see cref="SafePACE"/> to <see cref="PACE"/>.</summary>
		/// <param name="pAce">The access control entry.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator PACE(SafePACE pAce) => pAce.DangerousGetHandle();

		/// <summary>Performs an explicit conversion from <see cref="PACE"/> to <see cref="SafePACE"/>.</summary>
		/// <param name="pAce">The access control entry.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator SafePACE(PACE pAce) => new(pAce, true);

		/// <inheritdoc/>
		public int CompareTo(PACE other) => WinNTExtensions.CompareTo((PACE)this, other);

		/// <inheritdoc/>
		public int CompareTo(SafePACE? other) => other is null ? -1 : CompareTo((PACE)other);

		/// <inheritdoc/>
		public bool Equals(PACE other) => WinNTExtensions.Equals((PACE)this, other);

		/// <inheritdoc/>
		public bool Equals(SafePACE? other) => other is null ? false : Equals((PACE)other);

		/// <inheritdoc/>
		public override bool Equals(object? obj) => obj switch
		{
			SafePACL p => Equals(p),
			PACL p => Equals(p),
			IntPtr p => Equals((PACL)p),
			_ => base.Equals(obj)
		};

		/// <inheritdoc/>
		public override int GetHashCode() => Header.GetHashCode();

		private bool EnsureCapacity(SizeT addCap)
		{
			if (Length + addCap > Size)
				Size = Macros.ALIGN_TO_MULTIPLE(Length + addCap, 4);
			return true;
		}
	}

	/// <summary>A SafeHandle for access control lists. If owned, will call LocalFree on the pointer when disposed.</summary>
	[DebuggerDisplay("{DebugString}")]
	public class SafePACL : SafeMemoryHandle<LocalMemoryMethods>, ISecurityObject, IList<PACE>, IComparable<SafePACL>, IComparable<PACL>, IEquatable<SafePACL>, IEquatable<PACL>
	{
		private static readonly int AclStructSize = Marshal.SizeOf(typeof(ACL));

		/// <summary>The null value for a SafePACL.</summary>
		public static readonly SafePACL Null = new();

		/// <summary>Initializes a new instance of the <see cref="SafePACL"/> class.</summary>
		public SafePACL() : base(IntPtr.Zero, 0, true) { }

		/// <summary>
		/// Initializes a new instance of the <see cref="SafePACL"/> class from an existing pointer, copying its content if owning.
		/// </summary>
		/// <param name="pAcl">The access control list pointer.</param>
		public SafePACL(PACL pAcl) : this(pAcl, true) { }

		/// <summary>Initializes a new instance of the <see cref="SafePACL"/> class from an existing pointer, copying its content if owning.</summary>
		/// <param name="pAcl">The access control list pointer.</param>
		/// <param name="ownsHandle">if set to <see langword="true"/>, this instance will release the memory behind the <paramref name="pAcl"/>.</param>
		public SafePACL(PACL pAcl, bool ownsHandle) : base(IntPtr.Zero, 0, ownsHandle)
		{
			if (!IsValidAcl(pAcl))
				throw new ArgumentException("Invalid ACL.", nameof(pAcl));
			if (!ownsHandle)
			{
				SetHandle(((IntPtr)pAcl));
				sz = pAcl.Length();
			}
			else
			{
				Size = pAcl.Length();
				((IntPtr)pAcl).CopyTo(handle, sz);
			}
		}

		/// <summary>Initializes a new instance of the <see cref="SafePACL"/> class to an empty memory buffer.</summary>
		/// <param name="size">The size of the uninitialized access control list.</param>
		/// <param name="revision">ACL revision.</param>
		public SafePACL(int size, uint revision = ACL_REVISION) : base(size)
		{
			if (size % 4 != 0 || size < AclStructSize) throw new ArgumentOutOfRangeException(nameof(size), $"ACL structures must be DWORD aligned. This value must be a multiple of 4 and larger than {AclStructSize}.");
			InitializeAcl(handle, (uint)size, revision);
		}

		/// <summary>Initializes a new instance of the <see cref="SafePACL"/> class to an empty memory buffer.</summary>
		/// <param name="aces">The <see cref="EXPLICIT_ACCESS"/> entries to add to the access control list.</param>
		/// <param name="revision">ACL revision.</param>
		public SafePACL(IEnumerable<EXPLICIT_ACCESS> aces, uint revision = ACL_REVISION) : this(AclStructSize, revision) =>
			AddRange(aces);

		/// <summary>Initializes a new instance of the <see cref="SafePACL"/> class to an empty memory buffer.</summary>
		/// <param name="aces">The ACEs to add to the access control list.</param>
		/// <param name="revision">ACL revision.</param>
		public SafePACL(IReadOnlyList<PACE> aces, uint revision = ACL_REVISION) : this(AclStructSize + aces.Sum(a => (int)Macros.ALIGN_TO_MULTIPLE((int)a.Length(), 4)), revision)
		{
			for (int i = 0; i < aces.Count; i++)
				Add(aces[i]);
		}

		/// <summary>Initializes a new instance of the <see cref="SafePACL"/> class to an empty memory buffer.</summary>
		/// <param name="aces">The ACEs to add to the access control list.</param>
		/// <param name="revision">ACL revision.</param>
		public SafePACL(IReadOnlyList<SafePACE> aces, uint revision = ACL_REVISION) : this(aces.Select(a => (PACE)a).ToList(), revision)
		{
		}

		/// <summary>Initializes a new instance of the <see cref="SafePACL"/> class.</summary>
		/// <param name="bytes">An array of bytes that contain an existing access control list.</param>
		public SafePACL(byte[] bytes) : this(bytes?.Length ?? 0)
		{
			if (bytes is null) return;
			Marshal.Copy(bytes, 0, handle, bytes.Length);
		}

		/// <summary>Gets the number of ACEs held by this ACL.</summary>
		/// <value>The ace count.</value>
		public int AceCount => (int)((PACL)handle).AceCount();

		/// <summary>The number of unused bytes in the ACL.</summary>
		public uint BytesFree => ((PACL)handle).GetAclInformation<ACL_SIZE_INFORMATION>().AclBytesFree;

		/// <summary>
		/// The number of bytes in the ACL actually used to store the ACEs and ACL structure. This may be less than the total number of
		/// bytes allocated to the ACL.
		/// </summary>
		public uint BytesInUse => ((PACL)handle).GetAclInformation<ACL_SIZE_INFORMATION>().AclBytesInUse;

		/// <inheritdoc/>
		public int Count => AceCount;

		/// <summary>Determines whether the components of this access control list are valid.</summary>
		public bool IsValidAcl => IsValidAcl(handle);

		/// <summary>
		/// Gets the length, in bytes, of a structurally valid access control list. The length includes the length of all associated structures.
		/// </summary>
		public uint Length => ((PACL)handle).Length();

		/// <summary>Gets the revision number for the ACL.</summary>
		/// <value>The revision.</value>
		public uint Revision => ((PACL)handle).Revision();

		/// <inheritdoc/>
		public override SizeT Size
		{
			get => base.Size;
			set
			{
				if (value == Size) return;
				if (value < Length)
					throw new ArgumentException("Current ACL consumes more space that has been specified.", nameof(Size));
				// Make sure divisible by 4.
				if (value % 4 != 0)
					throw new ArgumentOutOfRangeException(nameof(Size), "ACL structures must be DWORD aligned. This value must be a multiple of 4.");
				// Use base property to copy and expand the underlying memory
				base.Size = value;
				handle.AsSpan<ACL>(1)[0].AclSize = (ushort)(ulong)value;
			}
		}

		internal string DebugString => IsInvalid ? "NULL" : $"Aces:{AceCount}, Size:{Length}";

		/// <inheritdoc/>
		bool ICollection<PACE>.IsReadOnly => false;

		/// <inheritdoc/>
		public PACE this[int index]
		{
			get => ((PACL)handle).GetAce((uint)index);
			set
			{
				if (index < 0 || index >= Count)
					throw new ArgumentOutOfRangeException(nameof(index), "index is not a valid item in the list.");
				Insert(index, value);
				RemoveAt(index + 1);
			}
		}

		/// <summary>Performs an explicit conversion from <see cref="SafePACL"/> to <see cref="PACL"/>.</summary>
		/// <param name="pAcl">The access control list.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator PACL(SafePACL pAcl) => pAcl.DangerousGetHandle();

		/// <summary>Performs an explicit conversion from <see cref="PACL"/> to <see cref="SafePACL"/>.</summary>
		/// <param name="pAcl">The access control list.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator SafePACL(PACL pAcl) => new(pAcl, true);

		/// <inheritdoc/>
		public void Add(PACE item) => AddAceInOrder(item);

		/// <summary>Adds a sequence of new ACEs to this ACL.</summary>
		/// <param name="items">The ACEs to add.</param>
		public void AddRange(IEnumerable<PACE> items)
		{
			Size += items.Sum(a => Macros.ALIGN_TO_MULTIPLE(a.Length(), 4));
			foreach (var a in items)
				Add(a);
		}

		/// <summary>Adds a sequence of new ACEs to this ACL.</summary>
		/// <param name="items">The ACEs to add.</param>
		public void AddRange(IEnumerable<EXPLICIT_ACCESS> items)
		{
			var ea = items.ToArray();
			SetEntriesInAcl((uint)ea.Length, ea, this, out var newHandle).ThrowIfFailed();
			//ReleaseHandle();
			SetHandle(newHandle.TakeOwnership());
			sz = newHandle.Length;
		}

		/// <inheritdoc/>
		public void Clear() { for (int i = AceCount - 1; i >= 0; i--) RemoveAt(i); }

		/// <summary>Clones this ACL into a new ACL performing a manual copy of each ACE rather than a memory copy.</summary>
		/// <returns>Newly allocated ACL with all ACEs copied from current ACL.</returns>
		public SafePACL Clone()
		{
			// Copy over new information
			uint acesLen = 0;
			PACE[] aces = ((PACL)this).EnumerateAces().Select(a => { acesLen += a.Length(); return a; }).ToArray();
			// Get bytes used and create new memory and initialize
			var rev = Revision;
			SafePACL pAcl = new(AclStructSize + (int)acesLen, Revision);
			// Copy over all ACEs
			for (int i = 0; i < aces.Length; i++)
				Win32Error.ThrowLastErrorIfFalse(AddAce(pAcl, rev, uint.MaxValue, (IntPtr)aces[i], aces[i].Length()));
			return pAcl;
		}

		/// <inheritdoc/>
		public int CompareTo(PACL other) => WinNTExtensions.CompareTo((PACL)this, other);

		/// <inheritdoc/>
		public int CompareTo(SafePACL? other) => other is null ? -1 : CompareTo((PACL)other);

		/// <inheritdoc/>
		public bool Contains(PACE item) => GetEnum().Contains(item, AceComparer.Instance);

		/// <inheritdoc/>
		public void CopyTo(PACE[] array, int arrayIndex)
		{
			if (array is null)
				throw new ArgumentNullException(nameof(array));
			if (arrayIndex < 0 || arrayIndex > array.Length)
				throw new ArgumentOutOfRangeException(nameof(arrayIndex));
			if (array.Length - arrayIndex < Count)
				throw new ArgumentException("The number of elements in the source ICollection<T> is greater than the available space from arrayIndex to the end of the destination array.");
			for (int i = 0; i < Count; i++)
				array[arrayIndex + i] = this[i];
		}

		/// <summary>Indicates whether the current object is equal to another object of the same type.</summary>
		/// <param name="other">An object to compare with this object.</param>
		/// <returns><see langword="true"/> if the current object is equal to the other parameter; otherwise, <see langword="false"/>.</returns>
		public bool Equals(PACL other) => WinNTExtensions.Equals((PACL)this, other);

		/// <summary>Indicates whether the current object is equal to another object of the same type.</summary>
		/// <param name="other">An object to compare with this object.</param>
		/// <returns><see langword="true"/> if the current object is equal to the other parameter; otherwise, <see langword="false"/>.</returns>
		public bool Equals(SafePACL? other) => other is null ? false : Equals((PACL)other);

		/// <inheritdoc/>
		public override bool Equals(object? obj) => obj switch
		{
			SafePACL p => Equals(p),
			PACL p => Equals(p),
			IntPtr p => Equals((PACL)p),
			_ => base.Equals(obj)
		};

		/// <inheritdoc/>
		public IEnumerator<PACE> GetEnumerator() => GetEnum().GetEnumerator();

		/// <inheritdoc/>
		public override int GetHashCode() => ((PACL)this).GetAclInformation<ACL_SIZE_INFORMATION>().GetHashCode();

		/// <inheritdoc/>
		public int IndexOf(PACE item) => GetEnum().Select((value, index) => new { value, index })
						.Where(pair => item.CompareTo(pair.value) == 0)
						.Select(pair => pair.index + 1).FirstOrDefault() - 1;

		/// <inheritdoc/>
		public void Insert(int index, PACE item) =>
			Win32Error.ThrowLastErrorIfFalse(EnsureCapacity(item.Length()) && AddAce(this, item, index == int.MaxValue || index == Count ? uint.MaxValue : (uint)index));

		/// <summary>Inserts an item to the IList{T} at the specified index.</summary>
		/// <typeparam name="TAce">The ACE structure.</typeparam>
		/// <param name="index">The zero-based index at which item should be inserted.</param>
		/// <param name="ace">The ACE to insert.</param>
		/// <param name="sid">A pointer to the SID representing a user, group, or logon account attached to the ACE.</param>
		/// <exception cref="ArgumentException">Alert ACEs cannot be added with just a SID., nameof(ace)</exception>
		public void Insert<TAce>(int index, in TAce ace, PSID sid) where TAce : struct, IAccessControlEntry
		{
			if (typeof(TAce).Name.Contains("ALERT"))
				throw new ArgumentException("Alert ACEs cannot be added with just a SID.", nameof(ace));
			using SafeCoTaskMemStruct<TAce> pAce = new(ace, Marshal.SizeOf(typeof(TAce)) + sid.Length() - sizeof(uint));
			pAce.GetFieldAddress("SidStart").Write(sid.GetBinaryForm());
			Insert(index, (PACE)pAce.DangerousGetHandle());
		}

		/// <inheritdoc/>
		public bool Remove(PACE item) { var idx = IndexOf(item); return idx != -1 && DeleteAce(this, (uint)idx); }

		/// <inheritdoc/>
		public void RemoveAt(int index) => Win32Error.ThrowLastErrorIfFalse(DeleteAce(this, (uint)index));

		/// <inheritdoc/>
		IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

		/// <summary>Add an ACE into the position it should belong. This method will not order inherited ACES correctly.</summary>
		/// <param name="ace">The ACE to add.</param>
		private void AddAceInOrder(PACE ace)
		{
			// Find ACE insert position.
			for (int i = 0; i < AceCount; i++)
			{
				var cmp = ace.CompareTo(this[i]);
				if (cmp < 0) continue;
				if (cmp > 0)
					Insert(i, ace);
				return;
			}
		}

		private bool EnsureCapacity(uint addCap)
		{
			if (Length + addCap > Size)
				Size = Length + Macros.ALIGN_TO_MULTIPLE(addCap, 4);
			return true;
		}

		private IEnumerable<PACE> GetEnum() => ((PACL)handle).EnumerateAces();
	}

	/// <summary>Contains information about an event record returned by the ReadEventLog function.</summary>
	/// <remarks>
	/// <para>
	/// The defined members are followed by the replacement strings for the message identified by the event identifier, the binary
	/// information, some pad bytes to make sure the full entry is on a <c>DWORD</c> boundary, and finally the length of the log entry
	/// again. Because the strings and the binary information can be of any length, no structure members are defined to reference them.
	/// The declaration of this structure in Winnt.h describes these members as follows:
	/// </para>
	/// <para>
	/// The source name is a variable-length string that specifies the name of the event source. The computer name is the name of the
	/// computer that generated the event. It may be followed with some padding bytes so that the user SID is aligned on a <c>DWORD</c>
	/// boundary. The user SID identifies the active user at the time this event was logged. If <c>UserSidLength</c> is zero, this field
	/// may be empty.
	/// </para>
	/// <para>
	/// The event identifier together with source name and a language identifier identify a string that describes the event in more
	/// detail. The strings are used as replacement strings and are merged into the message string to make a complete message. The
	/// message strings are contained in a message file specified in the source entry in the registry. To obtain the appropriate message
	/// string from the message file, load the message file with the LoadLibrary function and use the FormatMessage function.
	/// </para>
	/// <para>
	/// The binary information is information that is specific to the event. It could be the contents of the processor registers when a
	/// device driver got an error, a dump of an invalid packet that was received from the network, a dump of all the structures in a
	/// program (when the data area was detected to be corrupt), and so on. This information should be useful to the writer of the device
	/// driver or the application in tracking down bugs or unauthorized breaks into the application.
	/// </para>
	/// </remarks>
	[PInvokeData("winnt.h", MSDNShortId = "669b182a-bc81-4386-9815-6ffa09e2e743")]
	public class SafePEVENTLOGRECORD : SafeMemoryHandle<LocalMemoryMethods>
	{
		/// <summary>Initializes a new instance of the <see cref="SafePEVENTLOGRECORD"/> class.</summary>
		/// <param name="bytesToAllocate">The bytes to allocate.</param>
		public SafePEVENTLOGRECORD(int bytesToAllocate = 512) : base(bytesToAllocate) { }

		private SafePEVENTLOGRECORD()
		{
		}

		/// <summary>Reserved.</summary>
		public uint ClosingRecordNumber => handle.ToStructure<uint>(Size, 32);

		/// <summary>Gets the name of the computer that generated the event.</summary>
		public string ComputerName
		{
			get
			{
				var offset = 56 + (Source.Length + 1) * 2;
				return StringHelper.GetString(handle.Offset(offset), CharSet.Unicode, Size - offset)!;
			}
		}

		/// <summary>
		/// Gets the event-specific information within this event log record, in bytes. This information could be something specific (a
		/// disk driver might log the number of retries, for example), followed by binary information specific to the event being logged
		/// and to the source that generated the entry.
		/// </summary>
		public byte[]? Data => handle.ToByteArray(DataLength, DataOffset, Size);

		/// <summary>
		/// The category for this event. The meaning of this value depends on the event source. For more information, see Event Categories.
		/// </summary>
		public ushort EventCategory => handle.ToStructure<ushort>(Size, 28);

		/// <summary>
		/// The event identifier. The value is specific to the event source for the event, and is used with source name to locate a
		/// description string in the message file for the event source. For more information, see Event Identifiers.
		/// </summary>
		public uint EventID => handle.ToStructure<uint>(Size, 20);

		/// <summary>
		/// <para>The type of event. This member can be one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>EVENTLOG_ERROR_TYPE 0x0001</term>
		/// <term>Error event</term>
		/// </item>
		/// <item>
		/// <term>EVENTLOG_AUDIT_FAILURE 0x0010</term>
		/// <term>Failure Audit event</term>
		/// </item>
		/// <item>
		/// <term>EVENTLOG_AUDIT_SUCCESS 0x0008</term>
		/// <term>Success Audit event</term>
		/// </item>
		/// <item>
		/// <term>EVENTLOG_INFORMATION_TYPE 0x0004</term>
		/// <term>Information event</term>
		/// </item>
		/// <item>
		/// <term>EVENTLOG_WARNING_TYPE 0x0002</term>
		/// <term>Warning event</term>
		/// </item>
		/// </list>
		/// <para>For more information, see Event Types.</para>
		/// </summary>
		public EVENTLOG_TYPE EventType => handle.ToStructure<EVENTLOG_TYPE>(Size, 24);

		/// <summary>
		/// The number of strings present in the log (at the position indicated by <c>StringOffset</c>). These strings are merged into
		/// the message before it is displayed to the user.
		/// </summary>
		public ushort NumStrings => handle.ToStructure<ushort>(Size, 26);

		/// <summary>
		/// The number of the record. This value can be used with the EVENTLOG_SEEK_READ flag in the ReadEventLog function to begin
		/// reading at a specified record. For more information, see Event Log Records.
		/// </summary>
		public uint RecordNumber => handle.ToStructure<uint>(Size, 8);

		/// <summary>Gets a string that specifies the name of the event source.</summary>
		public string Source => StringHelper.GetString(handle.Offset(56), CharSet.Unicode, Size - 56)!;

		/// <summary>Gets the description strings within this event log record.</summary>
		public string[] Strings =>
			NumStrings == 0 ? new string[0] : handle.ToStringEnum(CharSet.Unicode, StringOffset, Size).ToArray();

		/// <summary>Gets the <see cref="DateTime"/> value at which this entry was submitted.</summary>
		public DateTime TimeGenerated => new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc) + TimeSpan.FromSeconds(handle.ToStructure<int>(Size, 12));

		/// <summary>Gets the <see cref="DateTime"/> value at which this entry was written.</summary>
		public DateTime TimeWritten => new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc) + TimeSpan.FromSeconds(handle.ToStructure<int>(Size, 16));

		/// <summary>Gets the security identifier (SID) within this event log record.</summary>
		public SafePSID UserSid => UserSidLength == 0 ? SafePSID.Null : new SafePSID(handle.ToByteArray(UserSidLength, UserSidOffset, Size));

		/// <summary>The size of the event-specific data (at the position indicated by <c>DataOffset</c>), in bytes.</summary>
		private int DataLength => handle.ToStructure<int>(Size, 48);

		/// <summary>
		/// The offset of the event-specific information within this event log record, in bytes. This information could be something
		/// specific (a disk driver might log the number of retries, for example), followed by binary information specific to the event
		/// being logged and to the source that generated the entry.
		/// </summary>
		private int DataOffset => handle.ToStructure<int>(Size, 52);

		/// <summary>The offset of the description strings within this event log record.</summary>
		private int StringOffset => handle.ToStructure<int>(Size, 36);

		/// <summary>The size of the <c>UserSid</c> member, in bytes. This value can be zero if no security identifier was provided.</summary>
		private int UserSidLength => handle.ToStructure<int>(Size, 40);

		/// <summary>
		/// The offset of the security identifier (SID) within this event log record. To obtain the user name for this SID, use the
		/// LookupAccountSid function.
		/// </summary>
		private int UserSidOffset => handle.ToStructure<int>(Size, 44);
	}

	/// <summary>A SafeHandle for security descriptors. If owned, will call LocalFree on the pointer when disposed.</summary>
	public class SafePSECURITY_DESCRIPTOR : SafeMemoryHandle<LocalMemoryMethods>, IEquatable<SafePSECURITY_DESCRIPTOR>, IEquatable<PSECURITY_DESCRIPTOR>, IEquatable<IntPtr>, ISecurityObject
	{
		/// <summary>The null value for a SafeSecurityDescriptor.</summary>
		public static readonly SafePSECURITY_DESCRIPTOR Null = new();

		private const SECURITY_INFORMATION defSecInfo = SECURITY_INFORMATION.DACL_SECURITY_INFORMATION | SECURITY_INFORMATION.SACL_SECURITY_INFORMATION | SECURITY_INFORMATION.OWNER_SECURITY_INFORMATION | SECURITY_INFORMATION.GROUP_SECURITY_INFORMATION;

		/// <summary>Initializes a new instance of the <see cref="SafePSECURITY_DESCRIPTOR"/> class.</summary>
		public SafePSECURITY_DESCRIPTOR() : base(IntPtr.Zero, 0, true) { }

		/// <summary>Initializes a new instance of the <see cref="SafePSECURITY_DESCRIPTOR"/> class from an existing pointer.</summary>
		/// <param name="pSecurityDescriptor">The security descriptor pointer.</param>
		/// <param name="own">if set to <c>true</c> indicates that this pointer should be freed when disposed.</param>
		public SafePSECURITY_DESCRIPTOR(PSECURITY_DESCRIPTOR pSecurityDescriptor, bool own = true) : base(IntPtr.Zero, 0, own)
		{
			if (pSecurityDescriptor.IsSelfRelative())
			{
				sz = (int)pSecurityDescriptor.Length();
				SetHandle((IntPtr)pSecurityDescriptor);
			}
			else if (own)
			{
				var newSz = 0U;
				if (!MakeSelfRelativeSD(pSecurityDescriptor, Null, ref newSz) && newSz == 0)
					Win32Error.ThrowLastError();
				Size = newSz;
				InitializeSecurityDescriptor(this, SECURITY_DESCRIPTOR_REVISION);
				if (!MakeSelfRelativeSD(pSecurityDescriptor, this, ref newSz))
					Win32Error.ThrowLastError();
			}
			else
				throw new InvalidOperationException("The supplied security descriptor is in absolute format and can only be copied if this class has ownership of the memory.");
		}

		/// <summary>Initializes a new instance of the <see cref="SafePSECURITY_DESCRIPTOR"/> class to an empty memory buffer.</summary>
		/// <param name="size">The size of the uninitialized security descriptor.</param>
		public SafePSECURITY_DESCRIPTOR(int size) : base(size) => InitializeSecurityDescriptor(this, SECURITY_DESCRIPTOR_REVISION);

		/// <summary>Initializes a new instance of the <see cref="SafePSECURITY_DESCRIPTOR"/> class.</summary>
		/// <param name="bytes">An array of bytes that contain an existing security descriptor.</param>
		public SafePSECURITY_DESCRIPTOR(byte[] bytes) : this(bytes?.Length ?? 0)
		{
			if (bytes is null) return;
			Marshal.Copy(bytes, 0, handle, bytes.Length);
		}

		/// <summary>Initializes a new instance of the <see cref="SafePSECURITY_DESCRIPTOR"/> class with an SDDL string.</summary>
		/// <param name="sddl">An SDDL value representing the security descriptor.</param>
		public SafePSECURITY_DESCRIPTOR(string sddl)
		{
			if (!ConvertStringSecurityDescriptorToSecurityDescriptor(sddl, SDDL_REVISION.SDDL_REVISION_1, out var sd, out var sdsz))
				Win32Error.ThrowLastError();
			handle = sd.TakeOwnership();
			sz = (int)sdsz;
		}

		/// <summary>Determines whether the components of this security descriptor are valid.</summary>
		public bool IsValidSecurityDescriptor => IsValidSecurityDescriptor(handle);

		/// <summary>Gets or sets the size in bytes of the security descriptor.</summary>
		/// <value>The size in bytes of the security descriptor.</value>
		public override SizeT Size
		{
			get
			{
				if (sz == 0 && Length > 0)
					sz = Length;
				return base.Size;
			}
			set => base.Size = value;
		}

		/// <summary>Determines whether the format of this security descriptor is self-relative.</summary>
		public bool IsSelfRelative => ((PSECURITY_DESCRIPTOR)handle).IsSelfRelative();

		/// <summary>
		/// Gets the length, in bytes, of a structurally valid security descriptor. The length includes the length of all associated structures.
		/// </summary>
		public uint Length => ((PSECURITY_DESCRIPTOR)handle).Length();

		/// <summary>Performs an explicit conversion from <see cref="SafePSECURITY_DESCRIPTOR"/> to <see cref="PSECURITY_DESCRIPTOR"/>.</summary>
		/// <param name="sd">The safe security descriptor.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator PSECURITY_DESCRIPTOR(SafePSECURITY_DESCRIPTOR sd) => sd.DangerousGetHandle();

		/// <summary>Implements the operator !=.</summary>
		/// <param name="psd1">The first value.</param>
		/// <param name="psd2">The second value.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator !=(SafePSECURITY_DESCRIPTOR psd1, SafePSECURITY_DESCRIPTOR psd2) => !(psd1 == psd2);

		/// <summary>Implements the operator ==.</summary>
		/// <param name="psd1">The first value.</param>
		/// <param name="psd2">The second value.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator ==(SafePSECURITY_DESCRIPTOR psd1, SafePSECURITY_DESCRIPTOR psd2)
		{
			if (ReferenceEquals(psd1, psd2)) return true;
			if (Equals(null, psd1) || Equals(null, psd2)) return false;
			return psd1.Equals(psd2);
		}

		/// <summary>Indicates whether the current object is equal to another object of the same type.</summary>
		/// <param name="other">An object to compare with this object.</param>
		/// <returns>true if the current object is equal to the <paramref name="other"/> parameter; otherwise, false.</returns>
		public bool Equals(SafePSECURITY_DESCRIPTOR? other) => Equals(other?.DangerousGetHandle());

		/// <summary>Indicates whether the current object is equal to another object of the same type.</summary>
		/// <param name="other">An object to compare with this object.</param>
		/// <returns>true if the current object is equal to the <paramref name="other"/> parameter; otherwise, false.</returns>
		public bool Equals(PSECURITY_DESCRIPTOR other) => Equals(other.DangerousGetHandle());

		/// <summary>Indicates whether the current object is equal to another object of the same type.</summary>
		/// <param name="other">An object to compare with this object.</param>
		/// <returns>true if the current object is equal to the <paramref name="other"/> parameter; otherwise, false.</returns>
		public bool Equals(IntPtr other)
		{
			if (GetSecurityDescriptorLength(handle) != GetSecurityDescriptorLength(other)) return false;
			var s1 = ConvertSecurityDescriptorToStringSecurityDescriptor(handle, defSecInfo);
			var s2 = ConvertSecurityDescriptorToStringSecurityDescriptor(other, defSecInfo);
			return string.CompareOrdinal(s1, s2) == 0;
		}

		/// <summary>Determines whether the specified <see cref="T:System.Object"/> is equal to the current <see cref="T:System.Object"/>.</summary>
		/// <param name="obj">The object to compare with the current object.</param>
		/// <returns>
		/// true if the specified <see cref="T:System.Object"/> is equal to the current <see cref="T:System.Object"/>; otherwise, false.
		/// </returns>
		public override bool Equals(object? obj)
		{
			if (obj is SafePSECURITY_DESCRIPTOR psid2)
				return Equals(psid2);
			if (obj is PSECURITY_DESCRIPTOR psidh)
				return Equals(psidh);
			if (obj is IntPtr ptr)
				return Equals(ptr);
			return false;
		}

		/// <summary>Gets the binary form of this SafePSECURITY_DESCRIPTOR.</summary>
		/// <returns>An array of bytes containing the entire security descriptor.</returns>
		public byte[] GetBinaryForm() => GetBytes(0, (int)Length);

		/// <summary>Returns a hash code for this instance.</summary>
		/// <returns>A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.</returns>
		public override int GetHashCode() => ToString().GetHashCode();

		/// <summary>
		/// The <c>MakeAbsoluteSD</c> function creates a security descriptor in absolute format by using a security descriptor in
		/// self-relative format as a template.
		/// </summary>
		/// <returns>
		/// <para>A tuple containing the following:</para>
		/// <list type="bullet">
		/// <item>
		/// <term><see cref="SafePSECURITY_DESCRIPTOR"/> pAbsoluteSecurityDescriptor</term>
		/// <description>
		/// The main body of an absolute-format security descriptor. This information is formatted as a SECURITY_DESCRIPTOR structure.
		/// </description>
		/// </item>
		/// <item>
		/// <term><see cref="SafePACL"/> pDacl</term>
		/// <description>
		/// The discretionary access control list (DACL) of the absolute-format security descriptor. The main body of the absolute-format
		/// security descriptor references this pointer.
		/// </description>
		/// </item>
		/// <item>
		/// <term><see cref="SafePACL"/> pSacl</term>
		/// <description>
		/// The system access control list (SACL) of the absolute-format security descriptor. The main body of the absolute-format
		/// security descriptor references this pointer.
		/// </description>
		/// </item>
		/// <item>
		/// <term><see cref="SafePSID"/> pOwner</term>
		/// <description>
		/// The security identifier (SID) of the owner of the absolute-format security descriptor. The main body of the absolute-format
		/// security descriptor references this pointer.
		/// </description>
		/// </item>
		/// <item>
		/// <term><see cref="SafePSID"/> pPrimaryGroup</term>
		/// <description>
		/// The absolute-format security descriptor's primary group. The main body of the absolute-format security descriptor references
		/// this pointer.
		/// </description>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// A security descriptor in absolute format contains pointers to the information it contains, rather than the information
		/// itself. A security descriptor in self-relative format contains the information in a contiguous block of memory. In a
		/// self-relative security descriptor, a SECURITY_DESCRIPTOR structure always starts the information, but the security
		/// descriptor's other components can follow the structure in any order. Instead of using memory addresses, the components of the
		/// self-relative security descriptor are identified by offsets from the beginning of the security descriptor. This format is
		/// useful when a security descriptor must be stored on a floppy disk or transmitted by means of a communications protocol.
		/// </para>
		/// <para>
		/// A server that copies secured objects to various media can use the <c>MakeAbsoluteSD</c> function to create an absolute
		/// security descriptor from a self-relative security descriptor and the MakeSelfRelativeSD function to create a self-relative
		/// security descriptor from an absolute security descriptor.
		/// </para>
		/// </remarks>
		public (SafePSECURITY_DESCRIPTOR pAbsoluteSecurityDescriptor, SafePACL pDacl, SafePACL pSacl, SafePSID pOwner, SafePSID pPrimaryGroup) MakeAbsolute()
		{
			uint cSD = 0, cOwn = 0, cGrp = 0, cDacl = 0, cSacl = 0;
			if (!MakeAbsoluteSD(this, Null, ref cSD, SafePACL.Null, ref cDacl, SafePACL.Null, ref cSacl, SafePSID.Null, ref cOwn, SafePSID.Null, ref cGrp))
				Win32Error.ThrowLastErrorUnless(Win32Error.ERROR_INSUFFICIENT_BUFFER);

			var pSD = new SafePSECURITY_DESCRIPTOR((int)cSD);
			var pDacl = new SafePACL((int)cDacl);
			var pSacl = new SafePACL((int)cSacl);
			var pOwn = new SafePSID((SizeT)cOwn);
			var pGrp = new SafePSID((SizeT)cGrp);
			if (!MakeAbsoluteSD(this, pSD, ref cSD, pDacl, ref cDacl, pSacl, ref cSacl, pOwn, ref cOwn, pGrp, ref cGrp))
				Win32Error.ThrowLastError();
			return (pSD, pDacl, pSacl, pOwn, pGrp);
		}

		/// <summary>Returns a <see cref="string"/> that represents this instance.</summary>
		/// <returns>A <see cref="string"/> that represents this instance.</returns>
		public override string ToString() => ToString(defSecInfo);

		/// <summary>Returns a <see cref="string"/> that represents this instance.</summary>
		/// <param name="secInfo">
		/// Specifies a combination of the SECURITY_INFORMATION bit flags to indicate the components of the security descriptor to include in
		/// the output string.
		/// </param>
		/// <returns>A <see cref="string"/> that represents this instance.</returns>
		public string ToString(SECURITY_INFORMATION secInfo) => ConvertSecurityDescriptorToStringSecurityDescriptor(handle, secInfo);
	}

	[System.AttributeUsage(AttributeTargets.Field, Inherited = false, AllowMultiple = false)]
	internal sealed class SortOrderAttribute(int order) : Attribute
	{
		public int Order { get; private set; } = order;
	}
}