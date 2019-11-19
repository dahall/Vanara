using System;
using System.Runtime.InteropServices;
using Vanara.Extensions;
using Vanara.InteropServices;

namespace Vanara.PInvoke
{
	public static partial class AdvApi32
	{
		/// <summary>
		/// <para>
		/// The <c>ACCESS_MODE</c> enumeration contains values that indicate how the access rights in an EXPLICIT_ACCESS structure apply to
		/// the trustee. Functions such as SetEntriesInAcl and GetExplicitEntriesFromAcl use these values to set or retrieve information in
		/// an access control entry (ACE).
		/// </para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/accctrl/ne-accctrl-_access_mode typedef enum _ACCESS_MODE { NOT_USED_ACCESS,
		// GRANT_ACCESS, SET_ACCESS, DENY_ACCESS, REVOKE_ACCESS, SET_AUDIT_SUCCESS, SET_AUDIT_FAILURE } ACCESS_MODE;
		[PInvokeData("accctrl.h", MSDNShortId = "52d1b3a3-eed5-4603-9056-520320da2a52")]
		public enum ACCESS_MODE
		{
			/// <summary>Value not used.</summary>
			NOT_USED_ACCESS,

			/// <summary>
			/// Indicates an ACCESS_ALLOWED_ACE structure. The new ACE combines the specified rights with any existing allowed or denied
			/// rights of the trustee.
			/// </summary>
			GRANT_ACCESS,

			/// <summary>
			/// Indicates an ACCESS_ALLOWED_ACEstructure that allows the specified rights. On input, this value discards any existing access
			/// control information for the trustee.
			/// </summary>
			SET_ACCESS,

			/// <summary>
			/// Indicates an ACCESS_DENIED_ACEstructure that denies the specified rights. On input, this value denies the specified rights in
			/// addition to any currently denied rights of the trustee.
			/// </summary>
			DENY_ACCESS,

			/// <summary>
			/// Indicates that all existing ACCESS_ALLOWED_ACE or SYSTEM_AUDIT_ACE structures for the specified trustee are removed.
			/// </summary>
			REVOKE_ACCESS,

			/// <summary>
			/// Indicates a SYSTEM_AUDIT_ACEstructure that generates audit messages for successful attempts to use the specified access
			/// rights. On input, this value combines the specified rights with any existing audited access rights for the trustee.
			/// </summary>
			SET_AUDIT_SUCCESS,
		}

		/// <summary>
		/// Indicates how the access rights specified by the <c>Access</c> and <c>ProvSpecificAccess</c> members apply to the trustee.
		/// </summary>
		[PInvokeData("accctrl.h", MSDNShortId = "bcb2ad72-7b00-4582-b05e-e00720a4db77")]
		[Flags]
		public enum ACTRL_ACCESS_FLAGS : uint
		{
			/// <summary>The rights are allowed.</summary>
			ACTRL_ACCESS_ALLOWED = 0x00000001,

			/// <summary>The rights are denied.</summary>
			ACTRL_ACCESS_DENIED = 0x00000002,

			/// <summary>The system generates audit messages for failed attempts to use the rights.</summary>
			ACTRL_AUDIT_SUCCESS = 0x00000004,

			/// <summary>The system generates audit messages for successful attempts to use the rights.</summary>
			ACTRL_AUDIT_FAILURE = 0x00000008,
		}

		/// <summary>Flags that specify information about the pProperty property.</summary>
		[PInvokeData("accctrl.h", MSDNShortId = "90b13dd1-0ca6-4674-b9fa-a61aed4637d7")]
		[Flags]
		public enum ACTRL_PROPERTY_FLAGS : uint
		{
			/// <summary>Protects the object or property from inheriting access-control entries.</summary>
			ACTRL_ACCESS_PROTECTED = 0x00000001
		}

		/// <summary>
		/// A set of bit flags that determine whether other containers or objects can inherit the ACE from the primary object to which the
		/// ACL is attached. The value of this member corresponds to the inheritance portion (low-order byte) of the AceFlags member of the
		/// ACE_HEADER structure.
		/// </summary>
		[Flags]
		public enum INHERIT_FLAGS : uint
		{
			/// <summary>
			/// The specific access permissions will only be applied to the container, and will not be inherited by objects created within
			/// the container.
			/// </summary>
			NO_INHERITANCE = 0,

			/// <summary>Noncontainer objects contained by the primary object inherit the entry.</summary>
			OBJECT_INHERIT_ACE = 1,

			/// <summary>
			/// Noncontainer objects contained by the primary object inherit the ACE. This flag corresponds to the OBJECT_INHERIT_ACE flag.
			/// </summary>
			SUB_OBJECTS_ONLY_INHERIT = OBJECT_INHERIT_ACE,

			/// <summary>Other containers that are contained by the primary object inherit the entry.</summary>
			CONTAINER_INHERIT_ACE = 2,

			/// <summary>
			/// Other containers that are contained by the primary object inherit the ACE. This flag corresponds to the CONTAINER_INHERIT_ACE flag.
			/// </summary>
			SUB_CONTAINERS_ONLY_INHERIT = CONTAINER_INHERIT_ACE,

			/// <summary>
			/// Both containers and noncontainer objects that are contained by the primary object inherit the ACE. This flag corresponds to
			/// the combination of the CONTAINER_INHERIT_ACE and OBJECT_INHERIT_ACE flags.
			/// </summary>
			SUB_CONTAINERS_AND_OBJECTS_INHERIT = CONTAINER_INHERIT_ACE | OBJECT_INHERIT_ACE,

			/// <summary>The ObjectInheritAce and ContainerInheritAce bits are not propagated to an inherited ACE.</summary>
			NO_PROPAGATE_INHERIT_ACE = 4,

			/// <summary>
			/// The ACE does not apply to the primary object to which the ACL is attached, but objects contained by the primary object
			/// inherit the entry.
			/// </summary>
			INHERIT_ONLY_ACE = 8,

			/// <summary>
			/// The ACE is inherited. Operations that change the security on a tree of objects may modify inherited ACEs without changing
			/// ACEs that were directly applied to the object.
			/// </summary>
			INHERITED_ACE = 0x10,

			/// <summary>The access right is displayed on the advanced security pages.</summary>
			SI_ACCESS_SPECIFIC = 0x00010000,

			/// <summary>The access right is displayed on the basic security page.</summary>
			SI_ACCESS_GENERAL = 0x00020000,

			/// <summary>
			/// Indicates an access right that applies only to containers. If this flag is set, the access right is displayed on the basic
			/// security page only if the SI_CONTAINER flag is also set.
			/// </summary>
			SI_ACCESS_CONTAINER = 0x00040000,

			/// <summary>Indicates a property-specific access right.</summary>
			SI_ACCESS_PROPERTY = 0x00080000,
		}

		/// <summary>
		/// The MULTIPLE_TRUSTEE_OPERATION enumeration contains values that indicate whether a TRUSTEE structure is an impersonation trustee.
		/// </summary>
		[PInvokeData("AccCtrl.h", MSDNShortId = "aa379284")]
		public enum MULTIPLE_TRUSTEE_OPERATION
		{
			/// <summary>The trustee is not an impersonation trustee.</summary>
			NO_MULTIPLE_TRUSTEE,

			/// <summary>
			/// The trustee is an impersonation trustee. The pMultipleTrustee member of the TRUSTEE structure points to a trustee for a
			/// server that can impersonate the client trustee.
			/// </summary>
			TRUSTEE_IS_IMPERSONATE
		}

		/// <summary>
		/// <para>
		/// The <c>PROG_INVOKE_SETTING</c> enumeration indicates the initial setting of the function used to track the progress of a call to
		/// the TreeSetNamedSecurityInfo or TreeResetNamedSecurityInfo function.
		/// </para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/accctrl/ne-accctrl-_progress_invoke_setting typedef enum
		// _PROGRESS_INVOKE_SETTING { ProgressInvokeNever, ProgressInvokeEveryObject, ProgressInvokeOnError, ProgressCancelOperation,
		// ProgressRetryOperation, ProgressInvokePrePostError } PROG_INVOKE_SETTING, *PPROG_INVOKE_SETTING;
		[PInvokeData("accctrl.h", MSDNShortId = "3eee30d6-7d9d-468f-b6ba-e172da523169")]
		public enum PROG_INVOKE_SETTING
		{
			/// <summary>Never invoke the progress function.</summary>
			ProgressInvokeNever = 1,

			/// <summary>Invoke the progress function for every object.</summary>
			ProgressInvokeEveryObject,

			/// <summary>Invoke the progress function only when an error is encountered.</summary>
			ProgressInvokeOnError,

			/// <summary>Discontinue the tree operation.</summary>
			ProgressCancelOperation,

			/// <summary>Retry the tree operation.</summary>
			ProgressRetryOperation,

			/// <summary>Invoke the progress function before and after applying security on the object and on the error.</summary>
			ProgressInvokePrePostError,
		}

		/// <summary>
		/// The SE_OBJECT_TYPE enumeration contains values that correspond to the types of Windows objects that support security. The
		/// functions, such as GetSecurityInfo and SetSecurityInfo, that set and retrieve the security information of an object, use these
		/// values to indicate the type of object.
		/// </summary>
		[PInvokeData("AccCtrl.h", MSDNShortId = "aa379593")]
		public enum SE_OBJECT_TYPE
		{
			/// <summary>Unknown object type.</summary>
			SE_UNKNOWN_OBJECT_TYPE = 0,

			/// <summary>Indicates a file or directory. The name string that identifies a file or directory object can be in one of the following formats:
			/// <list type="bullet">
			/// <listItem><para>A relative path, such as FileName.dat or ..\FileName</para></listItem>
			/// <listItem><para>An absolute path, such as FileName.dat, C:\DirectoryName\FileName.dat, or G:\RemoteDirectoryName\FileName.dat.</para></listItem>
			/// <listItem><para>A UNC name, such as \\ComputerName\ShareName\FileName.dat.</para></listItem>
			/// </list>
			///</summary>
			SE_FILE_OBJECT,

			/// <summary>
			/// Indicates a Windows service. A service object can be a local service, such as ServiceName, or a remote service, such as \\ComputerName\ServiceName.
			/// </summary>
			SE_SERVICE,

			/// <summary>
			/// Indicates a printer. A printer object can be a local printer, such as PrinterName, or a remote printer, such as \\ComputerName\PrinterName.
			/// </summary>
			SE_PRINTER,

			/// <summary>
			/// Indicates a registry key. A registry key object can be in the local registry, such as CLASSES_ROOT\SomePath or in a remote
			/// registry, such as \\ComputerName\CLASSES_ROOT\SomePath.
			/// <para>
			/// The names of registry keys must use the following literal strings to identify the predefined registry keys: "CLASSES_ROOT",
			/// "CURRENT_USER", "MACHINE", and "USERS".
			/// </para>
			/// </summary>
			SE_REGISTRY_KEY,

			/// <summary>Indicates a network share. A share object can be local, such as ShareName, or remote, such as \\ComputerName\ShareName.</summary>
			SE_LMSHARE,

			/// <summary>
			/// Indicates a local kernel object. The GetSecurityInfo and SetSecurityInfo functions support all types of kernel objects. The
			/// GetNamedSecurityInfo and SetNamedSecurityInfo functions work only with the following kernel objects: semaphore, event, mutex,
			/// waitable timer, and file mapping.
			/// </summary>
			SE_KERNEL_OBJECT,

			/// <summary>
			/// Indicates a window station or desktop object on the local computer. You cannot use GetNamedSecurityInfo and
			/// SetNamedSecurityInfo with these objects because the names of window stations or desktops are not unique.
			/// </summary>
			SE_WINDOW_OBJECT,

			/// <summary>
			/// Indicates a directory service object or a property set or property of a directory service object. The name string for a
			/// directory service object must be in X.500 form, for example:
			/// <para>CN=SomeObject,OU=ou2,OU=ou1,DC=DomainName,DC=CompanyName,DC=com,O=internet</para>
			/// </summary>
			SE_DS_OBJECT,

			/// <summary>Indicates a directory service object and all of its property sets and properties.</summary>
			SE_DS_OBJECT_ALL,

			/// <summary>Indicates a provider-defined object.</summary>
			SE_PROVIDER_DEFINED_OBJECT,

			/// <summary>Indicates a WMI object.</summary>
			SE_WMIGUID_OBJECT,

			/// <summary>Indicates an object for a registry entry under WOW64.</summary>
			SE_REGISTRY_WOW64_32KEY
		}

		/// <summary>
		/// The TRUSTEE_FORM enumeration contains values that indicate the type of data pointed to by the ptstrName member of the <see
		/// cref="TRUSTEE"/> structure.
		/// </summary>
		[PInvokeData("AccCtrl.h", MSDNShortId = "aa379638")]
		public enum TRUSTEE_FORM
		{
			/// <summary>The ptstrName member is a pointer to a security identifier (SID) that identifies the trustee.</summary>
			TRUSTEE_IS_SID,

			/// <summary>The ptstrName member is a pointer to a null-terminated string that identifies the trustee.</summary>
			TRUSTEE_IS_NAME,

			/// <summary>Indicates a trustee form that is not valid.</summary>
			TRUSTEE_BAD_FORM,

			/// <summary>
			/// The ptstrName member is a pointer to an OBJECTS_AND_SID structure that contains the SID of the trustee and the GUIDs of the
			/// object types in an object-specific access control entry (ACE).
			/// </summary>
			TRUSTEE_IS_OBJECTS_AND_SID,

			/// <summary>
			/// The ptstrName member is a pointer to an OBJECTS_AND_NAME structure that contains the name of the trustee and the names of the
			/// object types in an object-specific ACE.
			/// </summary>
			TRUSTEE_IS_OBJECTS_AND_NAME
		}

		/// <summary>
		/// The TRUSTEE_TYPE enumeration contains values that indicate the type of trustee identified by a <see cref="TRUSTEE"/> structure.
		/// </summary>
		[PInvokeData("AccCtrl.h", MSDNShortId = "aa379639")]
		public enum TRUSTEE_TYPE
		{
			/// <summary>The trustee type is unknown, but it may be valid.</summary>
			TRUSTEE_IS_UNKNOWN,

			/// <summary>Indicates a user.</summary>
			TRUSTEE_IS_USER,

			/// <summary>Indicates a group.</summary>
			TRUSTEE_IS_GROUP,

			/// <summary>Indicates a domain.</summary>
			TRUSTEE_IS_DOMAIN,

			/// <summary>Indicates an alias.</summary>
			TRUSTEE_IS_ALIAS,

			/// <summary>Indicates a well-known group.</summary>
			TRUSTEE_IS_WELL_KNOWN_GROUP,

			/// <summary>Indicates a deleted account.</summary>
			TRUSTEE_IS_DELETED,

			/// <summary>Indicates a trustee type that is not valid.</summary>
			TRUSTEE_IS_INVALID,

			/// <summary>Indicates a computer.</summary>
			TRUSTEE_IS_COMPUTER
		}

		/// <summary>
		/// <para>
		/// Contains access-control information for a specified trustee. This structure stores information equivalent to the access-control
		/// information stored in an ACE.
		/// </para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/accctrl/ns-accctrl-_actrl_access_entrya typedef struct _ACTRL_ACCESS_ENTRYA {
		// TRUSTEE_A Trustee; ULONG fAccessFlags; ACCESS_RIGHTS Access; ACCESS_RIGHTS ProvSpecificAccess; INHERIT_FLAGS Inheritance; LPSTR
		// lpInheritProperty; } ACTRL_ACCESS_ENTRYA, *PACTRL_ACCESS_ENTRYA;
		[PInvokeData("accctrl.h", MSDNShortId = "bcb2ad72-7b00-4582-b05e-e00720a4db77")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
		public struct ACTRL_ACCESS_ENTRY
		{
			/// <summary>
			/// <para>
			/// A TRUSTEE structure that identifies the user, group, or program (such as a service) to which the access-control entry applies.
			/// </para>
			/// </summary>
			public TRUSTEE Trustee;

			/// <summary>
			/// <para>
			/// Indicates how the access rights specified by the <c>Access</c> and <c>ProvSpecificAccess</c> members apply to the trustee.
			/// This member can be one of the following values. If you are using this structure with the COM implementation of
			/// IAccessControl, this member must be ACTRL_ACCESS_ALLOWED or ACTRL_ACCESS_DENIED.
			/// </para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>ACTRL_ACCESS_ALLOWED 0x00000001</term>
			/// <term>The rights are allowed.</term>
			/// </item>
			/// <item>
			/// <term>ACTRL_ACCESS_DENIED 0x00000002</term>
			/// <term>The rights are denied.</term>
			/// </item>
			/// <item>
			/// <term>ACTRL_AUDIT_SUCCESS 0x00000004</term>
			/// <term>The system generates audit messages for failed attempts to use the rights.</term>
			/// </item>
			/// <item>
			/// <term>ACTRL_AUDIT_FAILURE 0x00000008</term>
			/// <term>The system generates audit messages for successful attempts to use the rights.</term>
			/// </item>
			/// </list>
			/// </summary>
			public ACTRL_ACCESS_FLAGS fAccessFlags;

			/// <summary>
			/// <para>A bitmask that specifies the access rights that the entry allows, denies, or audits for the trustee.</para>
			/// <para>
			/// This member must use the provider-independent access flags, such as ACTRL_READ_CONTROL, rather than access flags such as
			/// READ_CONTROL. The provider for the object type converts these provider-independent flags to the corresponding
			/// provider-specific flags.
			/// </para>
			/// <para>If you are using this structure with the COM implementation of IAccessControl, this member must be COM_RIGHTS_EXECUTE.</para>
			/// <para>ACTRL_SYSTEM_ACCESS</para>
			/// <para>ACTRL_DELETE</para>
			/// <para>ACTRL_READ_CONTROL</para>
			/// <para>ACTRL_CHANGE_ACCESS</para>
			/// <para>ACTRL_CHANGE_OWNER</para>
			/// <para>ACTRL_SYNCHRONIZE</para>
			/// <para>ACTRL_STD_RIGHTS_ALL</para>
			/// <para>ACTRL_STD_RIGHT_REQUIRED</para>
			/// <para>COM_RIGHTS_EXECUTE</para>
			/// <para>COM_RIGHTS_EXECUTE_LOCAL</para>
			/// <para>COM_RIGHTS_EXECUTE_REMOTE</para>
			/// <para>COM_RIGHTS_ACTIVATE_LOCAL</para>
			/// <para>COM_RIGHTS_ACTIVATE_REMOTE</para>
			/// </summary>
			public uint Access;

			/// <summary>
			/// <para>
			/// A bitmask that specifies access rights specific to the provider type. The functions that use the <c>ACTRL_ACCESS_ENTRY</c>
			/// structure pass these bits on to the provider without interpreting them. In most cases, this member should be 0.
			/// </para>
			/// </summary>
			public uint ProvSpecificAccess;

			/// <summary>
			/// <para>
			/// A set of bit flags that determines whether other containers or objects can inherit the access-control entry from the primary
			/// object to which the access list is attached. If you are using this structure with the COM implementation of IAccessControl,
			/// this value must be NO_INHERITANCE, which indicates that the access-control entry is not inheritable. Otherwise, this value
			/// can be NO_INHERITANCE or it can be a combination of the following values.
			/// </para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>CONTAINER_INHERIT_ACE 0x2</term>
			/// <term>Other containers that are contained by the primary object inherit the entry.</term>
			/// </item>
			/// <item>
			/// <term>INHERIT_ONLY_ACE 0x8</term>
			/// <term>
			/// The ACE does not apply to the primary object to which the ACL is attached, but objects contained by the primary object
			/// inherit the entry.
			/// </term>
			/// </item>
			/// <item>
			/// <term>NO_PROPAGATE_INHERIT_ACE 0x4</term>
			/// <term>The OBJECT_INHERIT_ACE and CONTAINER_INHERIT_ACE flags are not propagated to an inherited entry.</term>
			/// </item>
			/// <item>
			/// <term>OBJECT_INHERIT_ACE 0x1</term>
			/// <term>Noncontainer objects contained by the primary object inherit the entry.</term>
			/// </item>
			/// <item>
			/// <term>SUB_CONTAINERS_AND_OBJECTS_INHERIT 0x3</term>
			/// <term>
			/// Both containers and noncontainer objects that are contained by the primary object inherit the entry. This flag corresponds to
			/// the combination of the CONTAINER_INHERIT_ACE and OBJECT_INHERIT_ACE flags.
			/// </term>
			/// </item>
			/// <item>
			/// <term>SUB_CONTAINERS_ONLY_INHERIT 0x2</term>
			/// <term>
			/// Other containers that are contained by the primary object inherit the entry. This flag corresponds to the
			/// CONTAINER_INHERIT_ACE flag.
			/// </term>
			/// </item>
			/// <item>
			/// <term>SUB_OBJECTS_ONLY_INHERIT 0x1</term>
			/// <term>
			/// Noncontainer objects contained by the primary object inherit the entry. This flag corresponds to the OBJECT_INHERIT_ACE flag.
			/// </term>
			/// </item>
			/// </list>
			/// </summary>
			public INHERIT_FLAGS Inheritance;

			/// <summary>
			/// <para>
			/// A pointer to a null-terminated string that identifies the object types that can inherit the entry. If you are using this
			/// structure with the COM implementation of IAccessControl, this member must be <c>NULL</c>.
			/// </para>
			/// </summary>
			public string lpInheritProperty;
		}

		/// <summary>
		/// <para>Contains a list of access entries.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// To create an empty access list, set <c>cEntries</c> to zero and <c>pAccessList</c> to <c>NULL</c>. An empty list does not grant
		/// access to any trustee, and thus, denies all access to an object.
		/// </para>
		/// <para>
		/// To create a null access list, set the <c>pAccessEntryList</c> member of the ACTRL_PROPERTY_ENTRY structure to <c>NULL</c>. A null
		/// access list grants everyone full access to the object.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/accctrl/ns-accctrl-_actrl_access_entry_lista typedef struct
		// _ACTRL_ACCESS_ENTRY_LISTA { ULONG cEntries; ACTRL_ACCESS_ENTRYA *pAccessList; } ACTRL_ACCESS_ENTRY_LISTA, *PACTRL_ACCESS_ENTRY_LISTA;
		[PInvokeData("accctrl.h", MSDNShortId = "d0e71756-0247-4c6b-b8b5-a343121b7406")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
		public struct ACTRL_ACCESS_ENTRY_LIST
		{
			/// <summary>
			/// <para>The number of entries in the <c>pAccessList</c> array.</para>
			/// </summary>
			public uint cEntries;

			/// <summary>
			/// <para>
			/// A pointer to an array of ACTRL_ACCESS_ENTRY structures. Each structure specifies access-control information for a specified trustee.
			/// </para>
			/// </summary>
			public IntPtr pAccessList;
		}

		/// <summary>
		/// <para>Contains an array of access-control lists for an object and its properties.</para>
		/// </summary>
		/// <remarks>
		/// <para>Note the following type definition.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/accctrl/ns-accctrl-_actrl_alista typedef struct _ACTRL_ALISTA { ULONG
		// cEntries; PACTRL_PROPERTY_ENTRYA pPropertyAccessList; } ACTRL_ACCESSA, *PACTRL_ACCESSA, ACTRL_AUDITA, *PACTRL_AUDITA;
		[PInvokeData("accctrl.h", MSDNShortId = "d7fb10c1-ebb8-44cf-b61c-a70a787b324f")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
		public struct ACTRL_ALIST
		{
			/// <summary>
			/// <para>The number of entries in the <c>pPropertyAccessList</c> array.</para>
			/// </summary>
			public uint cEntries;

			/// <summary>
			/// <para>
			/// An array of ACTRL_PROPERTY_ENTRY structures. Each structure contains a list of access-control entries for an object or a
			/// specified property on the object.
			/// </para>
			/// </summary>
			public IntPtr pPropertyAccessList;
		}

		/// <summary>
		/// <para>Contains a list of access-control entries for an object or a specified property on an object.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// To create an <c>ACTRL_PROPERTY_ENTRY</c> structure that grants everyone full access to an object, set the <c>pAccessEntryList</c>
		/// member to <c>NULL</c>.
		/// </para>
		/// <para>
		/// To create an <c>ACTRL_PROPERTY_ENTRY</c> structure that denies all access to an object, set the <c>pAccessEntryList</c> member to
		/// point to an ACTRL_ACCESS_ENTRY_LIST structure whose <c>cEntries</c> member is 0 and <c>pAccessList</c> member is <c>NULL</c>.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/accctrl/ns-accctrl-_actrl_property_entrya typedef struct
		// _ACTRL_PROPERTY_ENTRYA { LPSTR lpProperty; PACTRL_ACCESS_ENTRY_LISTA pAccessEntryList; ULONG fListFlags; } ACTRL_PROPERTY_ENTRYA, *PACTRL_PROPERTY_ENTRYA;
		[PInvokeData("accctrl.h", MSDNShortId = "90b13dd1-0ca6-4674-b9fa-a61aed4637d7")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
		public struct ACTRL_PROPERTY_ENTRY
		{
			/// <summary>
			/// <para>
			/// The GUID of a property on an object. Use the UuidToString function to generate a string representation of a property GUID.
			/// </para>
			/// </summary>
			public string lpProperty;

			/// <summary>
			/// <para>A pointer to an ACTRL_ACCESS_ENTRY_LIST structure that contains a list of access-control entries.</para>
			/// </summary>
			public IntPtr pAccessEntryList;

			/// <summary>
			/// <para>Flags that specify information about the <c>pProperty</c> property. This member can be 0 or the following value.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>ACTRL_ACCESS_PROTECTED 0x00000001</term>
			/// <term>Protects the object or property from inheriting access-control entries.</term>
			/// </item>
			/// </list>
			/// </summary>
			public ACTRL_PROPERTY_FLAGS fListFlags;
		}

		/// <summary>
		/// <para>
		/// The <c>EXPLICIT_ACCESS</c> structure defines access control information for a specified trustee. Access control functions, such
		/// as SetEntriesInAcl and GetExplicitEntriesFromAcl, use this structure to describe the information in an access control entry(ACE)
		/// of an access control list (ACL).
		/// </para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/accctrl/ns-accctrl-_explicit_access_a typedef struct _EXPLICIT_ACCESS_A {
		// DWORD grfAccessPermissions; ACCESS_MODE grfAccessMode; DWORD grfInheritance; TRUSTEE_A Trustee; } EXPLICIT_ACCESS_A,
		// *PEXPLICIT_ACCESS_A, EXPLICIT_ACCESSA, *PEXPLICIT_ACCESSA;
		[PInvokeData("accctrl.h", MSDNShortId = "6fe09542-10dd-439c-adf8-a4e06943ddb2")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
		public struct EXPLICIT_ACCESS
		{
			/// <summary>
			/// <para>
			/// A set of bit flags that use the ACCESS_MASK format to specify the access rights that an ACE allows, denies, or audits for the
			/// trustee. The functions that use the <c>EXPLICIT_ACCESS</c> structure do not convert, interpret, or validate the bits in this mask.
			/// </para>
			/// </summary>
			public ACCESS_MASK grfAccessPermissions;

			/// <summary>
			/// <para>
			/// A value from the ACCESS_MODE enumeration. For a discretionary access control list (DACL), this flag indicates whether the ACL
			/// allows or denies the specified access rights. For a system access control list (SACL), this flag indicates whether the ACL
			/// generates audit messages for successful attempts to use the specified access rights, or failed attempts, or both. When
			/// modifying an existing ACL, you can specify the REVOKE_ACCESS flag to remove any existing ACEs for the specified trustee.
			/// </para>
			/// </summary>
			public ACCESS_MODE grfAccessMode;

			/// <summary>
			/// <para>
			/// A set of bit flags that determines whether other containers or objects can inherit the ACE from the primary object to which
			/// the ACL is attached. The value of this member corresponds to the inheritance portion (low-order byte) of the <c>AceFlags</c>
			/// member of the ACE_HEADER structure. This parameter can be NO_INHERITANCE to indicate that the ACE is not inheritable; or it
			/// can be a combination of the following values.
			/// </para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>CONTAINER_INHERIT_ACE</term>
			/// <term>Other containers that are contained by the primary object inherit the ACE.</term>
			/// </item>
			/// <item>
			/// <term>INHERIT_NO_PROPAGATE</term>
			/// <term>Inherit but do not propagate.</term>
			/// </item>
			/// <item>
			/// <term>INHERIT_ONLY</term>
			/// <term>Inherit only.</term>
			/// </item>
			/// <item>
			/// <term>INHERIT_ONLY_ACE</term>
			/// <term>
			/// The ACE does not apply to the primary object to which the ACL is attached, but objects contained by the primary object
			/// inherit the ACE.
			/// </term>
			/// </item>
			/// <item>
			/// <term>NO_INHERITANCE</term>
			/// <term>Do not inherit.</term>
			/// </item>
			/// <item>
			/// <term>NO_PROPAGATE_INHERIT_ACE</term>
			/// <term>The OBJECT_INHERIT_ACE and CONTAINER_INHERIT_ACE flags are not propagated to an inherited ACE.</term>
			/// </item>
			/// <item>
			/// <term>OBJECT_INHERIT_ACE</term>
			/// <term>Noncontainer objects contained by the primary object inherit the ACE.</term>
			/// </item>
			/// <item>
			/// <term>SUB_CONTAINERS_AND_OBJECTS_INHERIT</term>
			/// <term>
			/// Both containers and noncontainer objects that are contained by the primary object inherit the ACE. This flag corresponds to
			/// the combination of the CONTAINER_INHERIT_ACE and OBJECT_INHERIT_ACE flags.
			/// </term>
			/// </item>
			/// <item>
			/// <term>SUB_CONTAINERS_ONLY_INHERIT</term>
			/// <term>
			/// Other containers that are contained by the primary object inherit the ACE. This flag corresponds to the CONTAINER_INHERIT_ACE flag.
			/// </term>
			/// </item>
			/// <item>
			/// <term>SUB_OBJECTS_ONLY_INHERIT</term>
			/// <term>
			/// Noncontainer objects contained by the primary object inherit the ACE. This flag corresponds to the OBJECT_INHERIT_ACE flag.
			/// </term>
			/// </item>
			/// </list>
			/// </summary>
			public INHERIT_FLAGS grfInheritance;

			/// <summary>
			/// <para>A TRUSTEE structure that identifies the user, group, or program (such as a Windows service) to which the ACE applies.</para>
			/// </summary>
			public TRUSTEE Trustee;
		}

		/// <summary>Provides information about an object's inherited access control entry (ACE).</summary>
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
		[PInvokeData("AccCtrl.h", MSDNShortId = "aa378845")]
		public struct INHERITED_FROM
		{
			/// <summary>
			/// Number of levels, or generations, between the object and the ancestor. Set this to zero for an explicit ACE. If the ancestor
			/// cannot be determined for the inherited ACE, set this member to –1.
			/// </summary>
			public int GenerationGap;

			/// <summary>Name of the ancestor from which the ACE was inherited. For an explicit ACE, set this to <c>null</c>.</summary>
			[MarshalAs(UnmanagedType.LPTStr)]
			public string AncestorName;

			/// <summary>Initializes a new instance of the <see cref="INHERITED_FROM"/> structure.</summary>
			/// <param name="generationGap">The generation gap.</param>
			/// <param name="ancestorName">Name of the ancestor.</param>
			public INHERITED_FROM(int generationGap, string ancestorName)
			{
				GenerationGap = generationGap;
				AncestorName = ancestorName;
			}

			/// <summary>Returns a <see cref="System.String"/> that represents this instance.</summary>
			/// <returns>A <see cref="System.String"/> that represents this instance.</returns>
			public override string ToString() => $"{AncestorName} : 0x{GenerationGap:X}";

			/// <summary>ACE is explicit.</summary>
			public static readonly INHERITED_FROM Explicit = new INHERITED_FROM(0, null);

			/// <summary>ACE inheritance cannot be determined.</summary>
			public static readonly INHERITED_FROM Indeterminate = new INHERITED_FROM(-1, null);
		}

		/// <summary>
		/// <para>
		/// The <c>OBJECTS_AND_NAME</c> structure contains a string that identifies a trustee by name and additional strings that identify
		/// the object types of an object-specific access control entry (ACE).
		/// </para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// The <c>ptstrName</c> member of a TRUSTEE structure can be a pointer to an <c>OBJECTS_AND_NAME</c> structure. This enables
		/// functions such as SetEntriesInAcl and GetExplicitEntriesFromAcl to store object-specific ACE information in the <c>Trustee</c>
		/// member of an EXPLICIT_ACCESS structure.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/accctrl/ns-accctrl-_objects_and_name_a typedef struct _OBJECTS_AND_NAME_A {
		// DWORD ObjectsPresent; SE_OBJECT_TYPE ObjectType; LPSTR ObjectTypeName; LPSTR InheritedObjectTypeName; LPSTR ptstrName; }
		// OBJECTS_AND_NAME_A, *POBJECTS_AND_NAME_A;
		[PInvokeData("accctrl.h", MSDNShortId = "ad91a302-f693-44e9-9655-ec4488ff78c4")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto, Pack = 4)]
		public struct OBJECTS_AND_NAME
		{
			/// <summary>
			/// <para>
			/// Indicates whether the <c>ObjectTypeName</c> and <c>InheritedObjectTypeName</c> members contain strings. This parameter can be
			/// a combination of the following values.
			/// </para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>ACE_OBJECT_TYPE_PRESENT 0x1</term>
			/// <term>The ObjectTypeName member contains a string.</term>
			/// </item>
			/// <item>
			/// <term>ACE_INHERITED_OBJECT_TYPE_PRESENT 0x2</term>
			/// <term>The InheritedObjectTypeName member contains a string.</term>
			/// </item>
			/// </list>
			/// </summary>
			public AceObjectPresence ObjectsPresent;

			/// <summary>
			/// <para>Specifies a value from the SE_OBJECT_TYPE enumeration that indicates the type of object.</para>
			/// </summary>
			public SE_OBJECT_TYPE ObjectType;

			/// <summary>
			/// <para>A pointer to a null-terminated string that identifies the type of object to which the ACE applies.</para>
			/// <para>This string must be a valid LDAP display name in the Active Directory schema.</para>
			/// </summary>
			public StrPtrAuto ObjectTypeName;

			/// <summary>
			/// <para>A pointer to a null-terminated string that identifies the type of object that can inherit the ACE.</para>
			/// <para>This string must be a valid LDAP display name in the Active Directory schema.</para>
			/// <para>
			/// If the ACE_INHERITED_OBJECT_TYPE_PRESENT bit is not set in the <c>ObjectsPresent</c> member, the
			/// <c>InheritedObjectTypeName</c> member is ignored, and all types of child objects can inherit the ACE. Otherwise, only the
			/// specified object type can inherit the ACE. In either case, inheritance is also controlled by the inheritance flags in the
			/// ACE_HEADERstructure as well as by any protection against inheritance placed on the child objects.
			/// </para>
			/// </summary>
			public StrPtrAuto InheritedObjectTypeName;

			/// <summary>
			/// <para>A pointer to a null-terminated string that contains the name of the trustee.</para>
			/// </summary>
			public StrPtrAuto ptstrName;
		}

		/// <summary>
		/// <para>
		/// The <c>OBJECTS_AND_SID</c> structure contains a security identifier (SID) that identifies a trustee and GUIDs that identify the
		/// object types of an object-specific access control entry (ACE).
		/// </para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// The <c>ptstrName</c> member of a TRUSTEE structure can be a pointer to an <c>OBJECTS_AND_SID</c> structure. This enables
		/// functions such as SetEntriesInAcl and GetExplicitEntriesFromAcl to store object-specific ACE information in the <c>Trustee</c>
		/// member of an EXPLICIT_ACCESS structure.
		/// </para>
		/// <para>
		/// When you use this structure in a call to SetEntriesInAcl, <c>ObjectTypeGuid</c> and <c>InheritedObjectTypeGuid</c> must be valid
		/// schema identifiers in the Active Directory schema. The system does not verify the GUIDs; they are used as is.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/accctrl/ns-accctrl-_objects_and_sid typedef struct _OBJECTS_AND_SID { DWORD
		// ObjectsPresent; GUID ObjectTypeGuid; GUID InheritedObjectTypeGuid; SID *pSid; } OBJECTS_AND_SID, *POBJECTS_AND_SID;
		[PInvokeData("accctrl.h", MSDNShortId = "77ba8a3c-01e5-4a3e-835f-c7b9ef60035a")]
		[StructLayout(LayoutKind.Sequential, Pack = 4)]
		public struct OBJECTS_AND_SID
		{
			/// <summary>
			/// <para>
			/// Indicates whether the <c>ObjectTypeGuid</c> and <c>InheritedObjectTypeGuid</c> members contain GUIDs. This parameter can be a
			/// combination of the following values.
			/// </para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>ACE_OBJECT_TYPE_PRESENT 0x1</term>
			/// <term>The ObjectTypeGuid member contains a GUID.</term>
			/// </item>
			/// <item>
			/// <term>ACE_INHERITED_OBJECT_TYPE_PRESENT 0x2</term>
			/// <term>The InheritedObjectTypeGuid member contains a GUID.</term>
			/// </item>
			/// </list>
			/// </summary>
			public AceObjectPresence ObjectsPresent;

			/// <summary>
			/// <para>
			/// A GUID structure that identifies the type of object, property set, or property protected by the ACE. If this ACE is
			/// inherited, the GUID identifies the type of object, property set, or property protected by the inherited ACE. This GUID must
			/// be a valid schema identifier in the Active Directory schema.
			/// </para>
			/// <para>
			/// If the ACE_OBJECT_TYPE_PRESENT bit is not set in the <c>ObjectsPresent</c> member, the <c>ObjectTypeGuid</c> member is
			/// ignored, and the ACE protects the object to which the ACL is assigned.
			/// </para>
			/// </summary>
			public Guid ObjectTypeGuid;

			/// <summary>
			/// <para>
			/// A GUID structure that identifies the type of object that can inherit the ACE. This GUID must be a valid schema identifier in
			/// the Active Directory schema.
			/// </para>
			/// <para>
			/// If the ACE_INHERITED_OBJECT_TYPE_PRESENT bit is not set in the <c>ObjectsPresent</c> member, the
			/// <c>InheritedObjectTypeGuid</c> member is ignored, and all types of child objects can inherit the ACE. Otherwise, only the
			/// specified object type can inherit the ACE. In either case, inheritance is also controlled by the inheritance flags in the
			/// ACE_HEADERstructure as well as by any protection against inheritance placed on the child objects.
			/// </para>
			/// </summary>
			public Guid InheritedObjectTypeGuid;

			/// <summary>
			/// <para>A pointer to the SID of the trustee to whom the ACE applies.</para>
			/// </summary>
			public IntPtr pSid;
		}

		/// <summary>
		/// The TRUSTEE structure identifies the user account, group account, or logon session to which an access control entry (ACE)
		/// applies. The structure can use a name or a security identifier (SID) to identify the trustee.
		/// <para>
		/// Access control functions, such as SetEntriesInAcl and GetExplicitEntriesFromAcl, use this structure to identify the logon account
		/// associated with the access control or audit control information in an EXPLICIT_ACCESS structure.
		/// </para>
		/// </summary>
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto, Pack = 4)]
		[PInvokeData("AccCtrl.h", MSDNShortId = "aa379636")]
		public struct TRUSTEE
		{
			/// <summary>
			/// A pointer to a TRUSTEE structure that identifies a server account that can impersonate the user identified by the ptstrName
			/// member. This member is not currently supported and must be NULL.
			/// </summary>
			public IntPtr pMultipleTrustee;

			/// <summary>A value of the MULTIPLE_TRUSTEE_OPERATION enumeration type. Currently, this member must be NO_MULTIPLE_TRUSTEE.</summary>
			public MULTIPLE_TRUSTEE_OPERATION MultipleTrusteeOperation;

			/// <summary>A value from the TRUSTEE_FORM enumeration type that indicates the type of data pointed to by the ptstrName member.</summary>
			public TRUSTEE_FORM TrusteeForm;

			/// <summary>
			/// A value from the TRUSTEE_TYPE enumeration type that indicates whether the trustee is a user account, a group account, or an
			/// unknown account type.
			/// </summary>
			public TRUSTEE_TYPE TrusteeType;

			/// <summary>
			/// A pointer to a buffer that identifies the trustee and, optionally, contains information about object-specific ACEs. The type
			/// of data depends on the value of the TrusteeForm member. This member can be one of the following values.
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <description>Meaning</description>
			/// </listheader>
			/// <item>
			/// <term>TRUSTEE_IS_NAME</term>
			/// <description>A pointer to a null-terminated string that contains the name of the trustee.</description>
			/// </item>
			/// <item>
			/// <term>TRUSTEE_IS_OBJECTS_AND_NAME</term>
			/// <description>
			/// A pointer to an OBJECTS_AND_NAME structure that contains the name of the trustee and the names of the object types in an
			/// object-specific ACE.
			/// </description>
			/// </item>
			/// <item>
			/// <term>TRUSTEE_IS_OBJECTS_AND_SID</term>
			/// <description>
			/// A pointer to an OBJECTS_AND_SID structure that contains the SID of the trustee and the GUIDs of the object types in an
			/// object-specific ACE.
			/// </description>
			/// </item>
			/// <item>
			/// <term>TRUSTEE_IS_SID</term>
			/// <description>Pointer to the SID of the trustee.</description>
			/// </item>
			/// </list>
			/// </summary>
			public IntPtr ptstrName;

			/// <summary>Initializes a new instance of the <see cref="TRUSTEE"/> struct.</summary>
			/// <param name="pSid">The sid.</param>
			/// <param name="type">The sid type.</param>
			public TRUSTEE(PSID pSid, TRUSTEE_TYPE type = TRUSTEE_TYPE.TRUSTEE_IS_USER) : this() { ptstrName = (IntPtr)pSid; TrusteeForm = TRUSTEE_FORM.TRUSTEE_IS_SID; TrusteeType = type; }

			/// <summary>Gets the name of the trustee.</summary>
			/// <value>
			/// A trustee name can have any of the following formats:
			/// <list type="bullet">
			/// <item>
			/// <description>A fully qualified name, such as "g:\remotedir\abc".</description>
			/// </item>
			/// <item>
			/// <description>A domain account, such as "domain1\xyz".</description>
			/// </item>
			/// <item>
			/// <description>One of the predefined group names, such as "EVERYONE" or "GUEST".</description>
			/// </item>
			/// <item>
			/// <description>One of the following special names: "CREATOR GROUP", "CREATOR OWNER", "CURRENT_USER".</description>
			/// </item>
			/// </list>
			/// </value>
			public string Name => TrusteeForm == TRUSTEE_FORM.TRUSTEE_IS_NAME ? Marshal.PtrToStringAuto(ptstrName) : null;

			/// <summary>Gets the sid for the trustee</summary>
			/// <value>The Sid.</value>
			public PSID Sid => TrusteeForm == TRUSTEE_FORM.TRUSTEE_IS_SID ? ptstrName : PSID.NULL;

			/// <summary>Gets the <see cref="OBJECTS_AND_NAME"/> from the <see cref="ptstrName"/> field.</summary>
			/// <value>The structure.</value>
			public OBJECTS_AND_NAME ObjectsAndName => TrusteeForm == TRUSTEE_FORM.TRUSTEE_IS_OBJECTS_AND_NAME ? ptstrName.ToStructure<OBJECTS_AND_NAME>() : default;

			/// <summary>Gets the <see cref="OBJECTS_AND_SID"/> from the <see cref="ptstrName"/> field.</summary>
			/// <value>The structure.</value>
			public OBJECTS_AND_SID ObjectsAndSid => TrusteeForm == TRUSTEE_FORM.TRUSTEE_IS_OBJECTS_AND_SID ? ptstrName.ToStructure<OBJECTS_AND_SID>() : default;
		}
	}
}