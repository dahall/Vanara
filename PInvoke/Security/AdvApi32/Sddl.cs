using System.ComponentModel;

namespace Vanara.PInvoke;

public static partial class AdvApi32
{
	//
	// SDDL Component tags
	//
	/// <summary>Owner tag</summary>
	public const string SDDL_OWNER = "O";
	/// <summary>Group tag</summary>
	public const string SDDL_GROUP = "G";
	/// <summary>DACL tag</summary>
	public const string SDDL_DACL = "D";
	/// <summary>SACL tag</summary>
	public const string SDDL_SACL = "S";

	//
	// SDDL Security descriptor controls
	//
	/// <summary>DACL or SACL Protected</summary>
	public const string SDDL_PROTECTED = "P";
	/// <summary>Auto inherit request</summary>
	public const string SDDL_AUTO_INHERIT_REQ = "AR";
	/// <summary>DACL/SACL are auto inherited</summary>
	public const string SDDL_AUTO_INHERITED = "AI";
	/// <summary>Null ACL</summary>
	public const string SDDL_NULL_ACL = "NO_ACCESS_CONTROL";

	//
	// SDDL Ace types
	//
	/// <summary>Access allowed</summary>
	public const string SDDL_ACCESS_ALLOWED = "A";
	/// <summary>Access denied</summary>
	public const string SDDL_ACCESS_DENIED = "D";
	/// <summary>Object access allowed</summary>
	public const string SDDL_OBJECT_ACCESS_ALLOWED = "OA";
	/// <summary>Object access denied</summary>
	public const string SDDL_OBJECT_ACCESS_DENIED = "OD";
	/// <summary>Audit</summary>
	public const string SDDL_AUDIT = "AU";
	/// <summary>Alarm</summary>
	public const string SDDL_ALARM = "AL";
	/// <summary>Object audit</summary>
	public const string SDDL_OBJECT_AUDIT = "OU";
	/// <summary>Object alarm</summary>
	public const string SDDL_OBJECT_ALARM = "OL";
	/// <summary>Integrity label</summary>
	public const string SDDL_MANDATORY_LABEL = "ML";
	/// <summary>Process trust label</summary>
	public const string SDDL_PROCESS_TRUST_LABEL = "TL";
	/// <summary>Callback access allowed</summary>
	public const string SDDL_CALLBACK_ACCESS_ALLOWED = "XA";
	/// <summary>Callback access denied</summary>
	public const string SDDL_CALLBACK_ACCESS_DENIED = "XD";
	/// <summary>Resource attribute</summary>
	public const string SDDL_RESOURCE_ATTRIBUTE = "RA";
	/// <summary>Scoped policy</summary>
	public const string SDDL_SCOPED_POLICY_ID = "SP";
	/// <summary>Callback audit</summary>
	public const string SDDL_CALLBACK_AUDIT = "XU";
	/// <summary>Callback object access allowed</summary>
	public const string SDDL_CALLBACK_OBJECT_ACCESS_ALLOWED = "ZA";
	/// <summary>Access Filter</summary>
	public const string SDDL_ACCESS_FILTER = "FL";

	//
	// SDDL Resource attribute ace data types
	//

	/// <summary>Signed integer</summary>

	public const string SDDL_INT = "TI";
	/// <summary>Unsigned integer</summary>
	public const string SDDL_UINT = "TU";
	/// <summary>Wide string</summary>
	public const string SDDL_WSTRING = "TS";
	/// <summary>SID</summary>
	public const string SDDL_SID = "TD";
	/// <summary>Octet String</summary>
	public const string SDDL_BLOB = "TX";
	/// <summary>Boolean</summary>
	public const string SDDL_BOOLEAN = "TB";

	//
	// SDDL Ace flags
	//
	/// <summary>Container inherit</summary>
	public const string SDDL_CONTAINER_INHERIT = "CI";
	/// <summary>Object inherit</summary>
	public const string SDDL_OBJECT_INHERIT = "OI";
	/// <summary>Inherit no propagate</summary>
	public const string SDDL_NO_PROPAGATE = "NP";
	/// <summary>Inherit only</summary>
	public const string SDDL_INHERIT_ONLY = "IO";
	/// <summary>Inherited</summary>
	public const string SDDL_INHERITED = "ID";
	/// <summary>Critical</summary>
	public const string SDDL_CRITICAL = "CR";
	/// <summary>Trust Protected Filter</summary>
	public const string SDDL_TRUST_PROTECTED_FILTER = "TP";
	/// <summary>Audit success</summary>
	public const string SDDL_AUDIT_SUCCESS = "SA";
	/// <summary>Audit failure</summary>
	public const string SDDL_AUDIT_FAILURE = "FA";

	//
	// SDDL Rights
	//
	/// <summary/>
	public const string SDDL_READ_PROPERTY = "RP";
	/// <summary/>
	public const string SDDL_WRITE_PROPERTY = "WP";
	/// <summary/>
	public const string SDDL_CREATE_CHILD = "CC";
	/// <summary/>
	public const string SDDL_DELETE_CHILD = "DC";
	/// <summary/>
	public const string SDDL_LIST_CHILDREN = "LC";
	/// <summary/>
	public const string SDDL_SELF_WRITE = "SW";
	/// <summary/>
	public const string SDDL_LIST_OBJECT = "LO";
	/// <summary/>
	public const string SDDL_DELETE_TREE = "DT";
	/// <summary/>
	public const string SDDL_CONTROL_ACCESS = "CR";
	/// <summary/>
	public const string SDDL_READ_CONTROL = "RC";
	/// <summary/>
	public const string SDDL_WRITE_DAC = "WD";
	/// <summary/>
	public const string SDDL_WRITE_OWNER = "WO";
	/// <summary/>
	public const string SDDL_STANDARD_DELETE = "SD";
	/// <summary/>
	public const string SDDL_GENERIC_ALL = "GA";
	/// <summary/>
	public const string SDDL_GENERIC_READ = "GR";
	/// <summary/>
	public const string SDDL_GENERIC_WRITE = "GW";
	/// <summary/>
	public const string SDDL_GENERIC_EXECUTE = "GX";
	/// <summary/>
	public const string SDDL_FILE_ALL = "FA";
	/// <summary/>
	public const string SDDL_FILE_READ = "FR";
	/// <summary/>
	public const string SDDL_FILE_WRITE = "FW";
	/// <summary/>
	public const string SDDL_FILE_EXECUTE = "FX";
	/// <summary/>
	public const string SDDL_KEY_ALL = "KA";
	/// <summary/>
	public const string SDDL_KEY_READ = "KR";
	/// <summary/>
	public const string SDDL_KEY_WRITE = "KW";
	/// <summary/>
	public const string SDDL_KEY_EXECUTE = "KX";
	/// <summary/>
	public const string SDDL_NO_WRITE_UP = "NW";
	/// <summary/>
	public const string SDDL_NO_READ_UP = "NR";
	/// <summary/>
	public const string SDDL_NO_EXECUTE_UP = "NX";
	// SDDL User alias max size
	//      - currently, upto two supported eg. "DA"
	//      - modify this if more WCHARs need to be there in future e.g. "DAX"
	//

	/// <summary></summary>

	public const int SDDL_ALIAS_SIZE = 2;
	// SDDL User aliases
	//
	/// <summary>Domain admins</summary>
	public const string SDDL_DOMAIN_ADMINISTRATORS = "DA";
	/// <summary>Domain guests</summary>
	public const string SDDL_DOMAIN_GUESTS = "DG";
	/// <summary>Domain users</summary>
	public const string SDDL_DOMAIN_USERS = "DU";
	/// <summary>Enterprise domain controllers</summary>
	public const string SDDL_ENTERPRISE_DOMAIN_CONTROLLERS = "ED";
	/// <summary>Domain domain controllers</summary>
	public const string SDDL_DOMAIN_DOMAIN_CONTROLLERS = "DD";
	/// <summary>Domain computers</summary>
	public const string SDDL_DOMAIN_COMPUTERS = "DC";
	/// <summary>Builtin (local ) administrators</summary>
	public const string SDDL_BUILTIN_ADMINISTRATORS = "BA";
	/// <summary>Builtin (local ) guests</summary>
	public const string SDDL_BUILTIN_GUESTS = "BG";
	/// <summary>Builtin (local ) users</summary>
	public const string SDDL_BUILTIN_USERS = "BU";
	/// <summary>Local administrator account</summary>
	public const string SDDL_LOCAL_ADMIN = "LA";
	/// <summary>Local group account</summary>
	public const string SDDL_LOCAL_GUEST = "LG";
	/// <summary>Account operators</summary>
	public const string SDDL_ACCOUNT_OPERATORS = "AO";
	/// <summary>Backup operators</summary>
	public const string SDDL_BACKUP_OPERATORS = "BO";
	/// <summary>Printer operators</summary>
	public const string SDDL_PRINTER_OPERATORS = "PO";
	/// <summary>Server operators</summary>
	public const string SDDL_SERVER_OPERATORS = "SO";
	/// <summary>Authenticated users</summary>
	public const string SDDL_AUTHENTICATED_USERS = "AU";
	/// <summary>Personal self</summary>
	public const string SDDL_PERSONAL_SELF = "PS";
	/// <summary>Creator owner</summary>
	public const string SDDL_CREATOR_OWNER = "CO";
	/// <summary>Creator group</summary>
	public const string SDDL_CREATOR_GROUP = "CG";
	/// <summary>Local system</summary>
	public const string SDDL_LOCAL_SYSTEM = "SY";
	/// <summary>Power users</summary>
	public const string SDDL_POWER_USERS = "PU";
	/// <summary>Everyone ( World )</summary>
	public const string SDDL_EVERYONE = "WD";
	/// <summary>Replicator</summary>
	public const string SDDL_REPLICATOR = "RE";
	/// <summary>Interactive logon user</summary>
	public const string SDDL_INTERACTIVE = "IU";
	/// <summary>Nework logon user</summary>
	public const string SDDL_NETWORK = "NU";
	/// <summary>Service logon user</summary>
	public const string SDDL_SERVICE = "SU";
	/// <summary>Restricted code</summary>
	public const string SDDL_RESTRICTED_CODE = "RC";
	/// <summary>Write Restricted code</summary>
	public const string SDDL_WRITE_RESTRICTED_CODE = "WR";
	/// <summary>Anonymous Logon</summary>
	public const string SDDL_ANONYMOUS = "AN";
	/// <summary>Schema Administrators</summary>
	public const string SDDL_SCHEMA_ADMINISTRATORS = "SA";
	/// <summary>Certificate Server Administrators</summary>
	public const string SDDL_CERT_SERV_ADMINISTRATORS = "CA";
	/// <summary>RAS servers group</summary>
	public const string SDDL_RAS_SERVERS = "RS";
	/// <summary>Enterprise administrators</summary>
	public const string SDDL_ENTERPRISE_ADMINS = "EA";
	/// <summary>Group Policy administrators</summary>
	public const string SDDL_GROUP_POLICY_ADMINS = "PA";
	/// <summary>alias to allow previous windows 2000</summary>
	public const string SDDL_ALIAS_PREW2KCOMPACC = "RU";
	/// <summary>Local service account (for services)</summary>
	public const string SDDL_LOCAL_SERVICE = "LS";
	/// <summary>Network service account (for services)</summary>
	public const string SDDL_NETWORK_SERVICE = "NS";
	/// <summary>Remote desktop users (for terminal server)</summary>
	public const string SDDL_REMOTE_DESKTOP = "RD";
	/// <summary>Network configuration operators ( to manage configuration of networking features)</summary>
	public const string SDDL_NETWORK_CONFIGURATION_OPS = "NO";
	/// <summary>Performance Monitor Users</summary>
	public const string SDDL_PERFMON_USERS = "MU";
	/// <summary>Performance Log Users</summary>
	public const string SDDL_PERFLOG_USERS = "LU";
	/// <summary>Anonymous Internet Users</summary>
	public const string SDDL_IIS_USERS = "IS";
	/// <summary>Crypto Operators</summary>
	public const string SDDL_CRYPTO_OPERATORS = "CY";
	/// <summary>Owner Rights SID</summary>
	public const string SDDL_OWNER_RIGHTS = "OW";
	/// <summary>Event log readers</summary>
	public const string SDDL_EVENT_LOG_READERS = "ER";
	/// <summary>Enterprise Read-only domain controllers</summary>
	public const string SDDL_ENTERPRISE_RO_DCs = "RO";
	/// <summary>Users who can connect to certification authorities using DCOM</summary>
	public const string SDDL_CERTSVC_DCOM_ACCESS = "CD";
	/// <summary>All applications running in an app package context</summary>
	public const string SDDL_ALL_APP_PACKAGES = "AC";
	/// <summary>Servers in this group enable users of RemoteApp programs and personal virtual desktops access to these resources.</summary>
	public const string SDDL_RDS_REMOTE_ACCESS_SERVERS = "RA";
	/// <summary>Servers in this group run virtual machines and host sessions where users RemoteApp programs and personal virtual desktops run.</summary>
	public const string SDDL_RDS_ENDPOINT_SERVERS = "ES";
	/// <summary>Servers in this group can perform routine administrative actions on servers running Remote Desktop Services.</summary>
	public const string SDDL_RDS_MANAGEMENT_SERVERS = "MS";
	/// <summary>UserMode driver</summary>
	public const string SDDL_USER_MODE_DRIVERS = "UD";
	/// <summary>Members of this group have complete and unrestricted access to all features of Hyper-V.</summary>
	public const string SDDL_HYPER_V_ADMINS = "HA";
	/// <summary>Members of this group that are domain controllers may be cloned.</summary>
	public const string SDDL_CLONEABLE_CONTROLLERS = "CN";
	/// <summary>Members of this group can remotely query authorization attributes and permissions for resources on this computer.</summary>
	public const string SDDL_ACCESS_CONTROL_ASSISTANCE_OPS = "AA";
	/// <summary>Members of this group can access WMI resources over management protocols (such as WS-Management via the Windows Remote Management service). This applies only to WMI namespaces that grant access to the user.</summary>
	public const string SDDL_REMOTE_MANAGEMENT_USERS = "RM";
	/// <summary>Authentication Authority Asserted</summary>
	public const string SDDL_AUTHORITY_ASSERTED = "AS";
	/// <summary>Authentication Service Asserted</summary>
	public const string SDDL_SERVICE_ASSERTED = "SS";
	/// <summary>Members of this group are afforded additional protections against authentication security threats.</summary>
	public const string SDDL_PROTECTED_USERS = "AP";
	/// <summary>Members of this group have full control over all key credential objects in the domain</summary>
	public const string SDDL_KEY_ADMINS = "KA";
	/// <summary>Members of this group have full control over all key credential objects in the forest</summary>
	public const string SDDL_ENTERPRISE_KEY_ADMINS = "EK";
	/// <summary>Members of this group may operate hardware from user mode</summary>
	public const string SDDL_USER_MODE_HARDWARE_OPERATORS = "HO";
	/// <summary>Members of this group may connect to this computer using SSH</summary>
	public const string SDDL_OPENSSH_USERS = "SH";

	//
	// Note !! While making the above changes check if ScepReplaceNewAcronymsInSDDL
	// needs to be updated to allow the new SIDs to be translated on downlevel OS.
	//

	//
	// Integrity Labels
	//
	/// <summary>Low mandatory level</summary>
	public const string SDDL_ML_LOW = "LW";
	/// <summary>Medium mandatory level</summary>
	public const string SDDL_ML_MEDIUM = "ME";
	/// <summary>Medium Plus mandatory level</summary>
	public const string SDDL_ML_MEDIUM_PLUS = "MP";
	/// <summary>High mandatory level</summary>
	public const string SDDL_ML_HIGH = "HI";
	/// <summary>System mandatory level</summary>
	public const string SDDL_ML_SYSTEM = "SI";

	//
	// SDDL Seperators - character version
	//
	/// <summary/>
	public const char SDDL_SEPERATORC = ';';
	/// <summary/>
	public const char SDDL_DELIMINATORC = ':';
	/// <summary/>
	public const char SDDL_ACE_BEGINC = '(';
	/// <summary/>
	public const char SDDL_ACE_ENDC = ')';
	/// <summary/>
	public const char SDDL_SPACEC = ' ';
	/// <summary/>
	public const char SDDL_ACE_COND_BEGINC = '(';
	/// <summary/>
	public const char SDDL_ACE_COND_ENDC = ')';
	/// <summary/>
	public const char SDDL_ACE_COND_STRING_BEGINC = '"';
	/// <summary/>
	public const char SDDL_ACE_COND_STRING_ENDC = '"';
	/// <summary/>
	public const char SDDL_ACE_COND_COMPOSITEVALUE_BEGINC = '{';
	/// <summary/>
	public const char SDDL_ACE_COND_COMPOSITEVALUE_ENDC = '}';
	/// <summary/>
	public const char SDDL_ACE_COND_COMPOSITEVALUE_SEPERATORC = ',';
	/// <summary/>
	public const char SDDL_ACE_COND_BLOB_PREFIXC = '#';
	/// <summary/>
	public const char SDDL_ACE_COND_SID_BEGINC = '(';
	/// <summary/>
	public const char SDDL_ACE_COND_SID_ENDC = ')';
	// SDDL Seperators - string version
	//
	/// <summary/>
	public const string SDDL_SEPERATOR = ";";
	/// <summary/>
	public const string SDDL_DELIMINATOR = ":";
	/// <summary/>
	public const string SDDL_ACE_BEGIN = "(";
	/// <summary/>
	public const string SDDL_ACE_END = ")";
	/// <summary/>
	public const string SDDL_ACE_COND_BEGIN = "(";
	/// <summary/>
	public const string SDDL_ACE_COND_END = ")";
	/// <summary/>
	public const string SDDL_SPACE = " ";
	/// <summary/>
	public const string SDDL_ACE_COND_BLOB_PREFIX = "#";
	/// <summary/>
	public const string SDDL_ACE_COND_SID_PREFIX = "SID";
	/// <summary/>
	public const string SDDL_ACE_COND_ATTRIBUTE_PREFIX = "@";
	/// <summary/>
	public const string SDDL_ACE_COND_USER_ATTRIBUTE_PREFIX = "@USER.";
	/// <summary/>
	public const string SDDL_ACE_COND_RESOURCE_ATTRIBUTE_PREFIX = "@RESOURCE.";
	/// <summary/>
	public const string SDDL_ACE_COND_DEVICE_ATTRIBUTE_PREFIX = "@DEVICE.";
	/// <summary/>
	public const string SDDL_ACE_COND_TOKEN_ATTRIBUTE_PREFIX = "@TOKEN.";

	/// <summary>Contains values to indicate the requested SDDL format.</summary>
	public enum SDDL_REVISION
	{
		/// <summary>SDDL revision 1.</summary>
		SDDL_REVISION_1 = 1
	}

	/// <summary>
	/// <para>
	/// The <c>ConvertSecurityDescriptorToStringSecurityDescriptor</c> function converts a security descriptor to a string format. You
	/// can use the string format to store or transmit the security descriptor.
	/// </para>
	/// <para>
	/// To convert the string-format security descriptor back to a valid, functional security descriptor, call the
	/// ConvertStringSecurityDescriptorToSecurityDescriptor function.
	/// </para>
	/// </summary>
	/// <param name="SecurityDescriptor">
	/// <para>A pointer to the security descriptor to convert. The security descriptor can be in absolute or self-relative format.</para>
	/// </param>
	/// <param name="RequestedStringSDRevision">
	/// <para>Specifies the revision level of the output StringSecurityDescriptor string. Currently this value must be SDDL_REVISION_1.</para>
	/// </param>
	/// <param name="SecurityInformation">
	/// <para>
	/// Specifies a combination of the SECURITY_INFORMATION bit flags to indicate the components of the security descriptor to include in
	/// the output string.
	/// </para>
	/// </param>
	/// <param name="StringSecurityDescriptor">
	/// <para>
	/// A pointer to a variable that receives a pointer to a <c>null</c>-terminated security descriptor string. For a description of the
	/// string format, see Security Descriptor String Format. To free the returned buffer, call the LocalFree function.
	/// </para>
	/// </param>
	/// <param name="StringSecurityDescriptorLen">
	/// <para>
	/// A pointer to a variable that receives the size, in <c>TCHAR</c> s, of the security descriptor string returned in the
	/// StringSecurityDescriptor buffer. This parameter can be <c>NULL</c> if you do not need to retrieve the size. The size represents
	/// the size of the buffer in <c>WCHAR</c> s, not the number of <c>WCHAR</c> s in the string.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>
	/// If the function fails, the return value is zero. To get extended error information, call GetLastError. The <c>GetLastError</c>
	/// function may return one of the following error codes.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_INVALID_PARAMETER</term>
	/// <term>A parameter is not valid.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_UNKNOWN_REVISION</term>
	/// <term>The revision level is not valid.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_NONE_MAPPED</term>
	/// <term>A security identifier (SID) in the input security descriptor could not be found in an account lookup operation.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_ACL</term>
	/// <term>
	/// The access control list (ACL) is not valid. This error is returned if the SE_DACL_PRESENT flag is set in the input security
	/// descriptor and the DACL is NULL.
	/// </term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// If the DACL is <c>NULL</c>, and the SE_DACL_PRESENT control bit is set in the input security descriptor, the function fails.
	/// </para>
	/// <para>
	/// If the DACL is <c>NULL</c>, and the SE_DACL_PRESENT control bit is not set in the input security descriptor, the resulting
	/// security descriptor string does not have a D: component. For more information, see Security Descriptor String Format.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/sddl/nf-sddl-convertsecuritydescriptortostringsecuritydescriptora BOOL
	// ConvertSecurityDescriptorToStringSecurityDescriptorA( PSECURITY_DESCRIPTOR SecurityDescriptor, DWORD RequestedStringSDRevision,
	// SECURITY_INFORMATION SecurityInformation, PSTR *StringSecurityDescriptor, PULONG StringSecurityDescriptorLen );
	[DllImport(Lib.AdvApi32, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("sddl.h", MSDNShortId = "36140833-8e30-4c32-a88a-c10751b6c223")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool ConvertSecurityDescriptorToStringSecurityDescriptor(PSECURITY_DESCRIPTOR SecurityDescriptor, SDDL_REVISION RequestedStringSDRevision,
		SECURITY_INFORMATION SecurityInformation, out SafeLocalHandle StringSecurityDescriptor, out uint StringSecurityDescriptorLen);

	/// <summary>
	/// <para>
	/// The <c>ConvertSecurityDescriptorToStringSecurityDescriptor</c> function converts a security descriptor to a string format. You
	/// can use the string format to store or transmit the security descriptor.
	/// </para>
	/// <para>
	/// To convert the string-format security descriptor back to a valid, functional security descriptor, call the
	/// ConvertStringSecurityDescriptorToSecurityDescriptor function.
	/// </para>
	/// </summary>
	/// <param name="SecurityDescriptor">
	/// <para>A pointer to the security descriptor to convert. The security descriptor can be in absolute or self-relative format.</para>
	/// </param>
	/// <param name="SecurityInformation">
	/// <para>
	/// Specifies a combination of the SECURITY_INFORMATION bit flags to indicate the components of the security descriptor to include in
	/// the output string.
	/// </para>
	/// </param>
	/// <returns>A security descriptor string. For a description of the string format, see Security Descriptor String Format.</returns>
	/// <remarks>
	/// <para>
	/// If the DACL is <c>NULL</c>, and the SE_DACL_PRESENT control bit is set in the input security descriptor, the function fails.
	/// </para>
	/// <para>
	/// If the DACL is <c>NULL</c>, and the SE_DACL_PRESENT control bit is not set in the input security descriptor, the resulting
	/// security descriptor string does not have a D: component. For more information, see Security Descriptor String Format.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/sddl/nf-sddl-convertsecuritydescriptortostringsecuritydescriptora BOOL
	// ConvertSecurityDescriptorToStringSecurityDescriptorA( PSECURITY_DESCRIPTOR SecurityDescriptor, DWORD RequestedStringSDRevision,
	// SECURITY_INFORMATION SecurityInformation, PSTR *StringSecurityDescriptor, PULONG StringSecurityDescriptorLen );
	[PInvokeData("sddl.h", MSDNShortId = "36140833-8e30-4c32-a88a-c10751b6c223")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static string ConvertSecurityDescriptorToStringSecurityDescriptor(PSECURITY_DESCRIPTOR SecurityDescriptor, SECURITY_INFORMATION SecurityInformation)
	{
		if (!ConvertSecurityDescriptorToStringSecurityDescriptor(SecurityDescriptor, SDDL_REVISION.SDDL_REVISION_1, SecurityInformation, out var sd, out var len))
			throw new Win32Exception();
		using (sd)
			return sd.ToString((int)len, CharSet.Auto) ?? string.Empty;
	}

	/// <summary>
	/// The ConvertSidToStringSid function converts a security identifier (SID) to a string format suitable for display, storage, or transmission.
	/// </summary>
	/// <param name="Sid">A pointer to the SID structure to be converted.</param>
	/// <param name="StringSid">
	/// A pointer to a variable that receives a pointer to a null-terminated SID string. To free the returned buffer, call the LocalFree function.
	/// </param>
	/// <returns>
	/// If the function succeeds, the return value is nonzero. If the function fails, the return value is zero.To get extended error
	/// information, call GetLastError.
	/// </returns>
	[DllImport(Lib.AdvApi32, CharSet = CharSet.Auto, SetLastError = true, BestFitMapping = false, ThrowOnUnmappableChar = true)]
	[return: MarshalAs(UnmanagedType.Bool)]
	[PInvokeData("sddl.h", MSDNShortId = "aa376399")]
	public static extern bool ConvertSidToStringSid(PSID Sid, out SafeLocalHandle StringSid);

	/// <summary>Converts a security identifier (SID) to a string format suitable for display, storage, or transmission.</summary>
	/// <param name="Sid">The SID structure to be converted.</param>
	/// <returns>A null-terminated SID string.</returns>
	[PInvokeData("sddl.h", MSDNShortId = "aa376399")]
	public static string ConvertSidToStringSid(PSID Sid)
	{
		if (!ConvertSidToStringSid(Sid, out var str))
			throw new Win32Exception();
		using (str)
			return str.ToString(-1, CharSet.Auto) ?? string.Empty;
	}

	/// <summary>
	/// <para>
	/// The <c>ConvertStringSecurityDescriptorToSecurityDescriptor</c> function converts a string-format security descriptor into a
	/// valid, functional security descriptor. This function retrieves a security descriptor that the
	/// ConvertSecurityDescriptorToStringSecurityDescriptor function converted to string format.
	/// </para>
	/// </summary>
	/// <param name="StringSecurityDescriptor">
	/// <para>A pointer to a null-terminated string containing the string-format security descriptor to convert.</para>
	/// </param>
	/// <param name="StringSDRevision">
	/// <para>Specifies the revision level of the StringSecurityDescriptor string. Currently this value must be SDDL_REVISION_1.</para>
	/// </param>
	/// <param name="SecurityDescriptor">
	/// <para>
	/// A pointer to a variable that receives a pointer to the converted security descriptor. The returned security descriptor is
	/// self-relative. To free the returned buffer, call the LocalFree function. To convert the security descriptor to an absolute
	/// security descriptor, use the MakeAbsoluteSD function.
	/// </para>
	/// </param>
	/// <param name="SecurityDescriptorSize">
	/// <para>
	/// A pointer to a variable that receives the size, in bytes, of the converted security descriptor. This parameter can be NULL.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>
	/// If the function fails, the return value is zero. To get extended error information, call GetLastError. <c>GetLastError</c> may
	/// return one of the following error codes.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_INVALID_PARAMETER</term>
	/// <term>A parameter is not valid.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_UNKNOWN_REVISION</term>
	/// <term>The SDDL revision level is not valid.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_NONE_MAPPED</term>
	/// <term>A security identifier (SID) in the input security descriptor string could not be found in an account lookup operation.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// If <c>ace_type</c> is ACCESS_ALLOWED_OBJECT_ACE_TYPE and neither <c>object_guid</c> nor <c>inherit_object_guid</c> has a GUID
	/// specified, then <c>ConvertStringSecurityDescriptorToSecurityDescriptor</c> converts <c>ace_type</c> to ACCESS_ALLOWED_ACE_TYPE.
	/// For information about the <c>ace_type</c>, <c>object_guid</c>, and <c>inherit_object_guid</c> fields, see Ace Strings.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/sddl/nf-sddl-convertstringsecuritydescriptortosecuritydescriptora BOOL
	// ConvertStringSecurityDescriptorToSecurityDescriptorA( LPCSTR StringSecurityDescriptor, DWORD StringSDRevision,
	// PSECURITY_DESCRIPTOR *SecurityDescriptor, PULONG SecurityDescriptorSize );
	[DllImport(Lib.AdvApi32, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("sddl.h", MSDNShortId = "c5654148-fb4c-436d-9378-a1168fc82607")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool ConvertStringSecurityDescriptorToSecurityDescriptor(string StringSecurityDescriptor, SDDL_REVISION StringSDRevision, out SafeLocalHandle SecurityDescriptor, out uint SecurityDescriptorSize);

	/// <summary>
	/// <para>
	/// The <c>ConvertStringSecurityDescriptorToSecurityDescriptor</c> function converts a string-format security descriptor into a
	/// valid, functional security descriptor. This function retrieves a security descriptor that the
	/// ConvertSecurityDescriptorToStringSecurityDescriptor function converted to string format.
	/// </para>
	/// </summary>
	/// <param name="StringSecurityDescriptor">
	/// <para>A pointer to a null-terminated string containing the string-format security descriptor to convert.</para>
	/// </param>
	/// <returns>
	/// A pointer to the converted security descriptor. The returned security descriptor is self-relative. To convert the security
	/// descriptor to an absolute security descriptor, use the MakeAbsoluteSD function.
	/// </returns>
	/// <remarks>
	/// <para>
	/// If <c>ace_type</c> is ACCESS_ALLOWED_OBJECT_ACE_TYPE and neither <c>object_guid</c> nor <c>inherit_object_guid</c> has a GUID
	/// specified, then <c>ConvertStringSecurityDescriptorToSecurityDescriptor</c> converts <c>ace_type</c> to ACCESS_ALLOWED_ACE_TYPE.
	/// For information about the <c>ace_type</c>, <c>object_guid</c>, and <c>inherit_object_guid</c> fields, see Ace Strings.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/sddl/nf-sddl-convertstringsecuritydescriptortosecuritydescriptora BOOL
	// ConvertStringSecurityDescriptorToSecurityDescriptorA( LPCSTR StringSecurityDescriptor, DWORD StringSDRevision,
	// PSECURITY_DESCRIPTOR *SecurityDescriptor, PULONG SecurityDescriptorSize );
	[PInvokeData("sddl.h", MSDNShortId = "c5654148-fb4c-436d-9378-a1168fc82607")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static SafePSECURITY_DESCRIPTOR ConvertStringSecurityDescriptorToSecurityDescriptor(string StringSecurityDescriptor)
	{
		if (!ConvertStringSecurityDescriptorToSecurityDescriptor(StringSecurityDescriptor, SDDL_REVISION.SDDL_REVISION_1, out var sd, out var sz))
			throw new Win32Exception();
		using (sd)
			return new SafePSECURITY_DESCRIPTOR(sd.TakeOwnership(), true);
	}

	/// <summary>
	/// The ConvertStringSidToSid function converts a string-format security identifier (SID) into a valid, functional SID. You can use
	/// this function to retrieve a SID that the ConvertSidToStringSid function converted to string format.
	/// </summary>
	/// <param name="pStringSid">
	/// A pointer to a null-terminated string containing the string-format SID to convert. The SID string can use either the standard
	/// S-R-I-S-S… format for SID strings, or the SID string constant format, such as "BA" for built-in administrators. For more
	/// information about SID string notation, see SID Components.
	/// </param>
	/// <param name="sid">
	/// A pointer to a variable that receives a pointer to the converted SID. To free the returned buffer, call the LocalFree function.
	/// </param>
	/// <returns>
	/// If the function succeeds, the return value is nonzero. If the function fails, the return value is zero. To get extended error
	/// information, call GetLastError.
	/// </returns>
	[DllImport(Lib.AdvApi32, CharSet = CharSet.Auto, SetLastError = true, BestFitMapping = false, ThrowOnUnmappableChar = true)]
	[return: MarshalAs(UnmanagedType.Bool)]
	[PInvokeData("sddl.h", MSDNShortId = "aa376402")]
	public static extern bool ConvertStringSidToSid(string pStringSid, out SafeLocalHandle sid);

	/// <summary>
	/// The ConvertStringSidToSid function converts a string-format security identifier (SID) into a valid, functional SID. You can use
	/// this function to retrieve a SID that the ConvertSidToStringSid function converted to string format.
	/// </summary>
	/// <param name="pStringSid">
	/// A pointer to a null-terminated string containing the string-format SID to convert. The SID string can use either the standard
	/// S-R-I-S-S… format for SID strings, or the SID string constant format, such as "BA" for built-in administrators. For more
	/// information about SID string notation, see SID Components.
	/// </param>
	/// <returns>A pointer to the converted SID.</returns>
	[PInvokeData("sddl.h", MSDNShortId = "aa376402")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static SafePSID ConvertStringSidToSid(string pStringSid)
	{
		if (!ConvertStringSidToSid(pStringSid, out var psid))
			throw new Win32Exception();
		using (psid)
			return new SafePSID((PSID)psid.DangerousGetHandle());
	}
}