namespace Vanara.PInvoke;

public static partial class ActiveDS
{
	/// <summary>
	/// <para>
	/// The <c>ADS_ACEFLAG_ENUM</c> enumeration is used to specify the behavior of an Access Control Entry (ACE) for an Active Directory object.
	/// </para>
	/// <para>
	/// For more information and possible values for file, file share and registry objects, see the <c>AceFlags</c> member of the ACE_HEADER structure.
	/// </para>
	/// </summary>
	/// <remarks>
	/// Because VBScript cannot read data from a type library, VBScript applications do not understand the symbolic constants as defined in
	/// these enumerations. You should use the numerical constants instead to set the appropriate flags in your VBScript applications. If you
	/// want to use the symbolic constants as a good programming practice, write explicit declarations of such constants, as done here, in
	/// your VBScript applications.
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/iads/ne-iads-ads_aceflag_enum typedef enum __MIDL___MIDL_itf_ads_0001_0048_0003 {
	// ADS_ACEFLAG_INHERIT_ACE = 0x2, ADS_ACEFLAG_NO_PROPAGATE_INHERIT_ACE = 0x4, ADS_ACEFLAG_INHERIT_ONLY_ACE = 0x8,
	// ADS_ACEFLAG_INHERITED_ACE = 0x10, ADS_ACEFLAG_VALID_INHERIT_FLAGS = 0x1f, ADS_ACEFLAG_SUCCESSFUL_ACCESS = 0x40,
	// ADS_ACEFLAG_FAILED_ACCESS = 0x80 } ADS_ACEFLAG_ENUM;
	[PInvokeData("iads.h", MSDNShortId = "NE:iads.__MIDL___MIDL_itf_ads_0001_0048_0003")]
	[Flags]
	public enum ADS_ACEFLAG : uint
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0x2</para>
		/// <para>
		/// Child objects will inherit this access-control entry (ACE). The inherited ACE is inheritable unless the
		/// ADS_ACEFLAG_NO_PROPAGATE_INHERIT_ACE flag is set.
		/// </para>
		/// </summary>
		ADS_ACEFLAG_INHERIT_ACE = 0x2,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x4</para>
		/// <para>
		/// The system will clear the ADS_ACEFLAG_INHERIT_ACE flag for the inherited ACEs of child objects. This prevents the ACE from being
		/// inherited by subsequent generations of objects.
		/// </para>
		/// </summary>
		ADS_ACEFLAG_NO_PROPAGATE_INHERIT_ACE = 0x4,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x8</para>
		/// <para>
		/// Indicates that an inherit-only ACE that does not exercise access control on the object to which it is attached. If this flag is
		/// not set, the ACE is an effective ACE that exerts access control on the object to which it is attached.
		/// </para>
		/// </summary>
		ADS_ACEFLAG_INHERIT_ONLY_ACE = 0x8,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x10</para>
		/// <para>Indicates whether or not the ACE was inherited. The system sets this bit.</para>
		/// </summary>
		ADS_ACEFLAG_INHERITED_ACE = 0x10,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x1f</para>
		/// <para>Indicates whether the inherit flags are valid. The system sets this bit.</para>
		/// </summary>
		ADS_ACEFLAG_VALID_INHERIT_FLAGS = 0x1f,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x40</para>
		/// <para>
		/// Generates audit messages for successful access attempts, used with ACEs that audit the system in a system access-control list (SACL).
		/// </para>
		/// </summary>
		ADS_ACEFLAG_SUCCESSFUL_ACCESS = 0x40,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x80</para>
		/// <para>Generates audit messages for failed access attempts, used with ACEs that audit the system in a SACL.</para>
		/// </summary>
		ADS_ACEFLAG_FAILED_ACCESS = 0x80,
	}

	/// <summary>
	/// <para>
	/// The <c>ADS_ACETYPE_ENUM</c> enumeration is used to specify the type of an access-control entry for Active Directory objects. The
	/// IADsAccessControlEntry.AceType property contains one of these values for an Active Directory object.
	/// </para>
	/// <para>
	/// For more information and possible values for file, file share and registry objects, see the <c>AceType</c> member of the ACE_HEADER structure.
	/// </para>
	/// </summary>
	/// <remarks>
	/// <para>
	/// A standard ACE is one defined and used in a Windows security descriptor. Windows enables the ACE to be applied to objects and
	/// properties identified by GUIDs.
	/// </para>
	/// <para>Use the IADsAccessControlEntry property method to determine the ACE type.</para>
	/// <para>
	/// <c>Note</c>  Because Visual Basic Scripting Edition (VBScript) cannot read data from a type library, VBScript applications cannot
	/// recognize symbolic constants as defined above. Use the numeric constants instead to set the appropriate flags in VBScript
	/// applications. To use the symbolic constants as a good programming practice, write explicit declarations of such constants, as done
	/// here, in VBScript applications.
	/// </para>
	/// <para></para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/iads/ne-iads-ads_acetype_enum typedef enum __MIDL___MIDL_itf_ads_0001_0048_0002 {
	// ADS_ACETYPE_ACCESS_ALLOWED = 0, ADS_ACETYPE_ACCESS_DENIED = 0x1, ADS_ACETYPE_SYSTEM_AUDIT = 0x2, ADS_ACETYPE_ACCESS_ALLOWED_OBJECT =
	// 0x5, ADS_ACETYPE_ACCESS_DENIED_OBJECT = 0x6, ADS_ACETYPE_SYSTEM_AUDIT_OBJECT = 0x7, ADS_ACETYPE_SYSTEM_ALARM_OBJECT = 0x8,
	// ADS_ACETYPE_ACCESS_ALLOWED_CALLBACK = 0x9, ADS_ACETYPE_ACCESS_DENIED_CALLBACK = 0xa, ADS_ACETYPE_ACCESS_ALLOWED_CALLBACK_OBJECT = 0xb,
	// ADS_ACETYPE_ACCESS_DENIED_CALLBACK_OBJECT = 0xc, ADS_ACETYPE_SYSTEM_AUDIT_CALLBACK = 0xd, ADS_ACETYPE_SYSTEM_ALARM_CALLBACK = 0xe,
	// ADS_ACETYPE_SYSTEM_AUDIT_CALLBACK_OBJECT = 0xf, ADS_ACETYPE_SYSTEM_ALARM_CALLBACK_OBJECT = 0x10 } ADS_ACETYPE_ENUM;
	[PInvokeData("iads.h", MSDNShortId = "NE:iads.__MIDL___MIDL_itf_ads_0001_0048_0002")]
	public enum ADS_ACETYPE
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0</para>
		/// <para>The ACE is of the standard ACCESS ALLOWED type, where the</para>
		/// <para>ObjectType</para>
		/// <para>and</para>
		/// <para>InheritedObjectType</para>
		/// <para>fields are</para>
		/// <para>NULL</para>
		/// <para>.</para>
		/// </summary>
		ADS_ACETYPE_ACCESS_ALLOWED = 0,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x1</para>
		/// <para>The ACE is of the standard system-audit type, where the</para>
		/// <para>ObjectType</para>
		/// <para>and</para>
		/// <para>InheritedObjectType</para>
		/// <para>fields are</para>
		/// <para>NULL</para>
		/// <para>.</para>
		/// </summary>
		ADS_ACETYPE_ACCESS_DENIED = 0x1,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x2</para>
		/// <para>The ACE is of the standard system type, where the</para>
		/// <para>ObjectType</para>
		/// <para>and</para>
		/// <para>InheritedObjectType</para>
		/// <para>fields are</para>
		/// <para>NULL</para>
		/// <para>.</para>
		/// </summary>
		ADS_ACETYPE_SYSTEM_AUDIT = 0x2,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x5</para>
		/// <para>The ACE grants access to an object or a subobject of the object, such as a property set or property.</para>
		/// <para>ObjectType</para>
		/// <para>or</para>
		/// <para>InheritedObjectType</para>
		/// <para>or both contain a GUID that identifies a property set, property, extended right, or type of child object.</para>
		/// </summary>
		ADS_ACETYPE_ACCESS_ALLOWED_OBJECT = 0x5,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x6</para>
		/// <para>The ACE denies access to an object or a subobject of the object, such as a property set or property.</para>
		/// <para>ObjectType</para>
		/// <para>or</para>
		/// <para>InheritedObjectType</para>
		/// <para>or both contain a GUID that identifies a property set, property, extended right, or type of child object.</para>
		/// </summary>
		ADS_ACETYPE_ACCESS_DENIED_OBJECT,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x7</para>
		/// <para>The ACE audits access to an object or a subobject of the object, such as a property set or property.</para>
		/// <para>ObjectType</para>
		/// <para>or</para>
		/// <para>InheritedObjectType</para>
		/// <para>or both contain a GUID that identifies a property set, property, extended right, or type of child object.</para>
		/// </summary>
		ADS_ACETYPE_SYSTEM_AUDIT_OBJECT,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x8</para>
		/// <para>Not used.</para>
		/// </summary>
		ADS_ACETYPE_SYSTEM_ALARM_OBJECT,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x9</para>
		/// <para>Same functionality as</para>
		/// <para>ADS_ACETYPE_ACCESS_ALLOWED</para>
		/// <para>, but used with applications that use Authz to verify ACEs.</para>
		/// </summary>
		ADS_ACETYPE_ACCESS_ALLOWED_CALLBACK,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0xa</para>
		/// <para>Same functionality as</para>
		/// <para>ADS_ACETYPE_ACCESS_DENIED</para>
		/// <para>, but used with applications that use Authz to verify ACEs.</para>
		/// </summary>
		ADS_ACETYPE_ACCESS_DENIED_CALLBACK,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0xb</para>
		/// <para>Same functionality as</para>
		/// <para>ADS_ACETYPE_ACCESS_ALLOWED_OBJECT</para>
		/// <para>, but used with applications that use Authz to verify ACEs.</para>
		/// </summary>
		ADS_ACETYPE_ACCESS_ALLOWED_CALLBACK_OBJECT,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0xc</para>
		/// <para>Same functionality as</para>
		/// <para>ADS_ACETYPE_ACCESS_DENIED_OBJECT</para>
		/// <para>, but used with applications that use Authz to check ACEs.</para>
		/// </summary>
		ADS_ACETYPE_ACCESS_DENIED_CALLBACK_OBJECT,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0xd</para>
		/// <para>Same functionality as</para>
		/// <para>ADS_ACETYPE_SYSTEM_AUDIT</para>
		/// <para>, but used with applications that use Authz to check ACEs.</para>
		/// </summary>
		ADS_ACETYPE_SYSTEM_AUDIT_CALLBACK,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0xe</para>
		/// <para>Not used.</para>
		/// </summary>
		ADS_ACETYPE_SYSTEM_ALARM_CALLBACK,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0xf</para>
		/// <para>Same functionality as</para>
		/// <para>ADS_ACETYPE_SYSTEM_AUDIT_OBJECT</para>
		/// <para>, but used with applications that use Authz to verify ACEs.</para>
		/// </summary>
		ADS_ACETYPE_SYSTEM_AUDIT_CALLBACK_OBJECT,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x10</para>
		/// <para>Not used.</para>
		/// </summary>
		ADS_ACETYPE_SYSTEM_ALARM_CALLBACK_OBJECT,
	}

	/// <summary>
	/// The following constants are used with the <c>dwControlCode</c> member of <c>ADS_ATTR_INFO</c> structure to specify the type of
	/// operation to be performed when an attribute is modified with the <c>IDirectoryObject::SetObjectAttributes</c> method. For more
	/// information about using these values, see Modifying Attributes with ADSI.
	/// </summary>
	/// <remarks>
	/// These constants are intended to be used with the <c>ADS_ATTR_INFO</c> structure in the <c>IDirectoryObject::SetObjectAttributes</c>
	/// method. These constants should not be confused with members of the <c>ADS_PROPERTY_OPERATION_ENUM</c> enumeration, which are intended
	/// to be used with the <c>IADs::PutEx</c> method.
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/adsi/adsi-attribute-modification-types
	[PInvokeData("Iads.h")]
	public enum ADS_ATTR
	{
		/// <summary>Causes all attribute values to be removed from an object.</summary>
		ADS_ATTR_CLEAR = 1,

		/// <summary>Causes the specified attribute values to be updated.</summary>
		ADS_ATTR_UPDATE = 2,

		/// <summary>Causes the specified attribute values to be appended to the existing attribute values.</summary>
		ADS_ATTR_APPEND = 3,

		/// <summary>Causes the specified attribute values to be removed from an object.</summary>
		ADS_ATTR_DELETE = 4,
	}

	/// <summary>
	/// The <c>ADS_AUTHENTICATION_ENUM</c> enumeration specifies authentication options used in ADSI for binding to directory service
	/// objects. When calling IADsOpenDSObject or ADsOpenObject to bind to an ADSI object, provide at least one of the options. In general,
	/// different providers will have different implementations. The options documented here apply to the providers supplied by Microsoft
	/// included with the ADSI SDK. For more information, see ADSI System Providers.
	/// </summary>
	/// <remarks>
	/// <para>
	/// The <c>ADS_SECURE_AUTHENTICATION</c> flag can be used in combination with other flags such as <c>ADS_READONLY_SERVER</c>,
	/// <c>ADS_PROMPT_CREDENTIALS</c>, <c>ADS_FAST_BIND</c>, and so on.
	/// </para>
	/// <para>
	/// Serverless binding refers to a process in which a client attempts to bind to an Active Directory object without explicitly specifying
	/// an Active Directory server in the binding string. This is possible because the LDAP provider relies on the locator services of
	/// Windows to find the best domain controller (DC) for the client. However, the client must have an account on the Active Directory
	/// domain controller to take advantage of the serverless binding feature, and the DC used by a serverless bind will always be located in
	/// the default domain; that is, the domain associated with the current security context of the thread that performs the binding.
	/// </para>
	/// <para>
	/// Because VBScript cannot read data from a type library, VBScript applications do not recognize the symbolic constants as defined
	/// above. Use the numerical constants instead to set the appropriate flags in your VBScript applications. To use the symbolic constants
	/// as a good programming practice, write explicit declarations of such constants, as done here, in your Visual Basic Scripting edition application.
	/// </para>
	/// <para>Examples</para>
	/// <para>
	/// The following code example shows how to use IADsOpenDSObject to open an object on fabrikam with secure authentication for the WinNT provider.
	/// </para>
	/// <para>
	/// The following code example shows how the <c>ADS_SECURE_AUTHENTICATION</c> flag is used with ADsOpenObject for validating the user
	/// bound as "JeffSmith". The user name can be of the UPN format: "JeffSmith@Fabrikam.com", as well as the distinguished name format: "CN=JeffSmith,DC=Fabrikam,DC=COM".
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/iads/ne-iads-ads_authentication_enum typedef enum
	// __MIDL___MIDL_itf_ads_0000_0000_0018 { ADS_SECURE_AUTHENTICATION = 0x1, ADS_USE_ENCRYPTION = 0x2, ADS_USE_SSL = 0x2,
	// ADS_READONLY_SERVER = 0x4, ADS_PROMPT_CREDENTIALS = 0x8, ADS_NO_AUTHENTICATION = 0x10, ADS_FAST_BIND = 0x20, ADS_USE_SIGNING = 0x40,
	// ADS_USE_SEALING = 0x80, ADS_USE_DELEGATION = 0x100, ADS_SERVER_BIND = 0x200, ADS_NO_REFERRAL_CHASING = 0x400, ADS_AUTH_RESERVED =
	// 0x80000000 } ADS_AUTHENTICATION_ENUM;
	[PInvokeData("iads.h", MSDNShortId = "NE:iads.__MIDL___MIDL_itf_ads_0000_0000_0018")]
	[Flags]
	public enum ADS_AUTHENTICATION : uint
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0x1</para>
		/// <para>
		/// Requests secure authentication. When this flag is set, the WinNT provider uses NT LAN Manager (NTLM) to authenticate the client.
		/// Active Directory will use Kerberos, and possibly NTLM, to authenticate the client. When the user name and password are <see
		/// langword="null"/>, ADSI binds to the object using the security context of the calling thread, which is either the security
		/// context of the user account under which the application is running or of the client user account that the calling thread represents.
		/// </para>
		/// </summary>
		ADS_SECURE_AUTHENTICATION = 0x01,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x2</para>
		/// <para>Requires ADSI to use encryption for data exchange over the network.</para>
		/// <note type="note">This option is not supported by the WinNT provider.</note>
		/// </summary>
		ADS_USE_ENCRYPTION = 0x02,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x2</para>
		/// <para>
		/// The channel is encrypted using Secure Sockets Layer (SSL). Active Directory requires that the Certificate Server be installed to
		/// support SSL. If this flag is not combined with the ADS_SECURE_AUTHENTICATION flag and the supplied credentials are NULL, the bind
		/// will be performed anonymously. If this flag is combined with the ADS_SECURE_AUTHENTICATION flag and the supplied credentials are
		/// NULL, then the credentials of the calling thread are used.
		/// </para>
		/// <note type="note">This option is not supported by the WinNT provider.</note>
		/// </summary>
		ADS_USE_SSL = 0x02,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x4</para>
		/// <para>
		/// A writable domain controller is not required. If your application only reads or queries data from Active Directory, you should
		/// use this flag to open the sessions. This allows the application to take advantage of Read-Only DCs (RODCs). In Windows Server
		/// 2008, ADSI attempts to connect to either Read-Only DCs (RODCs) or writable DCs. This allows the use of an RODC for the access and
		/// enables the application to run in a branch or perimeter network (also known as DMZ, demilitarized zone, and screened subnet),
		/// without the need for direct connectivity with a writable DC. For more information about programming for RODC compatibility, see
		/// the Read-Only Domain Controllers Application Compatibility Guide.
		/// </para>
		/// </summary>
		ADS_READONLY_SERVER = 0x04,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x8</para>
		/// <para>This flag is not supported.</para>
		/// </summary>
		ADS_PROMPT_CREDENTIALS = 0x08,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x10</para>
		/// <para>
		/// Request no authentication. The providers may attempt to bind the client, as an anonymous user, to the target object. The WinNT
		/// provider does not support this flag. Active Directory establishes a connection between the client and the targeted object, but
		/// will not perform authentication. Setting this flag amounts to requesting an anonymous binding, which indicates all users as the
		/// security context.
		/// </para>
		/// </summary>
		ADS_NO_AUTHENTICATION = 0x10,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x20</para>
		/// <para>
		/// When this flag is set, ADSI will not attempt to query the objectClass property and thus will only expose the base interfaces
		/// supported by all ADSI objects instead of the full object support. A user can use this option to increase the performance in a
		/// series of object manipulations that involve only methods of the base interfaces. However, ADSI will not verify that any of the
		/// requested objects actually exist on the server. For more information, see Fast Binding Options for Batch Write/Modify Operations .
		/// </para>
		/// <para>
		/// This option is also useful for binding to non-Active Directory directory services, for example Exchange 5.5, where the
		/// objectClass query would fail.
		/// </para>
		/// </summary>
		ADS_FAST_BIND = 0x20,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x40</para>
		/// <para>Verifies data integrity. The ADS_SECURE_AUTHENTICATION flag must also be set also to use signing.</para>
		/// <note type="note">This option is not supported by the WinNT provider.</note>
		/// </summary>
		ADS_USE_SIGNING = 0x40,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x80</para>
		/// <para>Encrypts data using Kerberos. The ADS_SECURE_AUTHENTICATION flag must also be set to use sealing.</para>
		/// <note>This option is not supported by the WinNT provider.</note>
		/// </summary>
		ADS_USE_SEALING = 0x80,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x100</para>
		/// <para>Enables ADSI to delegate the user security context, which is necessary for moving objects across domains.</para>
		/// </summary>
		ADS_USE_DELEGATION = 0x100,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x200</para>
		/// <para>If an Active Directory DNS server name is passed in the LDAP path, this forces an A-record lookup and bypasses any SRV record lookup when resolving the host name.</para>
		/// <note>This option is not supported by the WinNT provider.</note>
		/// </summary>
		ADS_SERVER_BIND = 0x200,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x400</para>
		/// <para>
		/// Specify this flag to turn referral chasing off for the life of the connection. However, even when this flag is specified, ADSI
		/// still allows the setting of referral chasing behavior for container enumeration when set using ADS_OPTION_REFERRALS in
		/// ADS_OPTION_ENUM (as documented in container enumeration with referral chasing in IADsObjectOptions::SetOption ) and searching
		/// separately (as documented in Referral Chasing with IDirectorySearch ).
		/// </para>
		/// <note>This option is not supported by the WinNT provider.</note>
		/// </summary>
		ADS_NO_REFERRAL_CHASING = 0x400,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x80000000</para>
		/// <para>Reserved.</para>
		/// </summary>
		ADS_AUTH_RESERVED = 0x80000000,
	}

	/// <summary>
	/// The <c>ADS_CHASE_REFERRALS_ENUM</c> enumeration specifies if, and how, referral chasing occurs. When a server determines that other
	/// servers hold relevant data, in part or as a whole, it may refer the client to another server to obtain the result. Referral chasing
	/// is the action taken by a client to contact the referred-to server to continue the directory search.
	/// </summary>
	/// <remarks>
	/// <para>
	/// Use the constants of this enumeration to set up search preferences for referral chasing. The action amounts to assigning the
	/// appropriate fields of the ADS_SEARCHPREF_INFO structure with elements of the <c>ADS_CHASE_REFERRALS_ENUM</c> and ADS_SEARCHPREF_ENUM
	/// enumerations. The values of this enumeration can also be used with IADsObjectOptions to specify whether referral chasing should take
	/// place when enumerating the objects under a container object.
	/// </para>
	/// <para>
	/// The IADsNameTranslate interface has a partial implementation of <c>ADS_CHASE_REFERRALS_ENUM</c> through the ChaseReferral property.
	/// If the <c>ChaseReferral</c> property is set to zero (0), it is the same as specifying <c>ADS_CHASE_REFERRALS_NEVER</c> (0). If a
	/// nonzero value is used, it is the same as specifying <c>ADS_CHASE_REFERRALS_ALWAYS</c> (0x60). <c>IADsNameTranslate</c> does not
	/// implement the <c>ADS_CHASE_REFERRALS_SUBORDINATE</c> (0x20) or <c>ADS_CHASE_REFERRALS_EXTERNAL</c> (0x40) options.
	/// </para>
	/// <para>The ADSI LDAP provider supports external referrals for paged searches, but does not support subordinate referrals during paging.</para>
	/// <para>
	/// <c>Note</c>  Because VBScript cannot read data from a type library, VBScript applications do not understand the symbolic constants as
	/// defined above. You should use the numerical constants instead to set the appropriate flags in your VBScript applications. If you want
	/// to use the symbolic constants as a good programming practice, you should make explicit declarations of such constants, as done here,
	/// in your VBScript applications.
	/// </para>
	/// <para></para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/iads/ne-iads-ads_chase_referrals_enum typedef enum
	// __MIDL___MIDL_itf_ads_0000_0000_0024 { ADS_CHASE_REFERRALS_NEVER = 0, ADS_CHASE_REFERRALS_SUBORDINATE = 0x20,
	// ADS_CHASE_REFERRALS_EXTERNAL = 0x40, ADS_CHASE_REFERRALS_ALWAYS } ADS_CHASE_REFERRALS_ENUM;
	[PInvokeData("iads.h", MSDNShortId = "NE:iads.__MIDL___MIDL_itf_ads_0000_0000_0024")]
	[Flags]
	public enum ADS_CHASE_REFERRALS
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0</para>
		/// <para>
		/// The client should never chase the referred-to server. Setting this option prevents a client from contacting other servers in a
		/// referral process.
		/// </para>
		/// </summary>
		ADS_CHASE_REFERRALS_NEVER = 0,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x20</para>
		/// <para>
		/// The client chases only subordinate referrals which are a subordinate naming context in a directory tree. For example, if the base
		/// search is requested for "DC=Fabrikam,DC=Com", and the server returns a result set and a referral of "DC=Sales,DC=Fabrikam,DC=Com"
		/// on the AdbSales server, the client can contact the AdbSales server to continue the search. The ADSI LDAP provider always turns
		/// off this flag for paged searches.
		/// </para>
		/// </summary>
		ADS_CHASE_REFERRALS_SUBORDINATE = 0x20,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x40</para>
		/// <para>
		/// The client chases external referrals. For example, a client requests server A to perform a search for "DC=Fabrikam,DC=Com".
		/// However, server A does not contain the object, but knows that an independent server, B, owns it. It then refers the client to
		/// server B.
		/// </para>
		/// </summary>
		ADS_CHASE_REFERRALS_EXTERNAL = 0x40,

		/// <summary>Referrals are chased for either the subordinate or external type.</summary>
		ADS_CHASE_REFERRALS_ALWAYS = ADS_CHASE_REFERRALS_SUBORDINATE | ADS_CHASE_REFERRALS_EXTERNAL,
	}

	/// <summary>The <c>ADS_DEREFENUM</c> enumeration specifies the process through which aliases are dereferenced.</summary>
	/// <remarks>
	/// <para>
	/// The IDirectorySearch interface uses these constants to set the alias dereferencing behavior. If no option is specified, the server
	/// defaults to <c>ADS_DEREF_NEVER</c>.
	/// </para>
	/// <para>
	/// <c>Note</c>  Because VBScript cannot read data from a type library, VBScript applications do not recognize the symbolic constants as
	/// defined above. Use the numerical constants, instead, to set the appropriate flags in your VBScript applications. To use the symbolic
	/// constants, as a good programming practice, explicitly declare constants, as done here.
	/// </para>
	/// <para></para>
	/// <para>Examples</para>
	/// <para>
	/// The following code example shows how to set the search preference for alias dereferencing. m_pSearch refers to a pointer to an object
	/// implementing the IDirectorySearch interface.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/iads/ne-iads-ads_derefenum typedef enum __MIDL___MIDL_itf_ads_0000_0000_0020 {
	// ADS_DEREF_NEVER = 0, ADS_DEREF_SEARCHING = 1, ADS_DEREF_FINDING = 2, ADS_DEREF_ALWAYS = 3 } ADS_DEREFENUM;
	[PInvokeData("iads.h", MSDNShortId = "NE:iads.__MIDL___MIDL_itf_ads_0000_0000_0020")]
	public enum ADS_DEREF
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0</para>
		/// <para>Does not dereference aliases when searching or locating the base object of the search.</para>
		/// </summary>
		ADS_DEREF_NEVER,

		/// <summary>
		/// <para>Value:</para>
		/// <para>1</para>
		/// <para>Dereferences aliases when searching subordinates of the base object, but not when locating the base itself.</para>
		/// </summary>
		ADS_DEREF_SEARCHING,

		/// <summary>
		/// <para>Value:</para>
		/// <para>2</para>
		/// <para>Dereferences aliases when locating the base object of the search, but not when searching its subordinates.</para>
		/// </summary>
		ADS_DEREF_FINDING,

		/// <summary>
		/// <para>Value:</para>
		/// <para>3</para>
		/// <para>Dereferences aliases when both searching subordinates and locating the base object of the search.</para>
		/// </summary>
		ADS_DEREF_ALWAYS,
	}

	/// <summary>The <c>ADS_DISPLAY_ENUM</c> enumeration specifies how a path is to be displayed.</summary>
	/// <remarks>
	/// <para>This enumeration is used in IADsPathname::SetDisplayType method to specify how a path is to be displayed.</para>
	/// <para>
	/// <c>Note</c>  Because VBScript cannot read data from a type library, VBScript applications do not understand the symbolic constants as
	/// defined above. You should use the numeric constants instead to set the appropriate flags in your VBScript applications. If you want
	/// to use the symbolic constants as a good programming practice, you should create explicit declarations of such constants, as done
	/// here, in your VBScript applications.
	/// </para>
	/// <para></para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/iads/ne-iads-ads_display_enum typedef enum __MIDL___MIDL_itf_ads_0001_0078_0003 {
	// ADS_DISPLAY_FULL = 1, ADS_DISPLAY_VALUE_ONLY = 2 } ADS_DISPLAY_ENUM;
	[PInvokeData("iads.h", MSDNShortId = "NE:iads.__MIDL___MIDL_itf_ads_0001_0078_0003")]
	public enum ADS_DISPLAY
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>1</para>
		/// <para>The path is displayed with both attributes and values. For example, CN=Jeff Smith.</para>
		/// </summary>
		ADS_DISPLAY_FULL = 1,

		/// <summary>
		/// <para>Value:</para>
		/// <para>2</para>
		/// <para>The path is displayed with values only. For example, Jeff Smith.</para>
		/// </summary>
		ADS_DISPLAY_VALUE_ONLY,
	}

	/// <summary>The <c>ADS_ESCAPE_MODE_ENUM</c> enumeration specifies how escape characters are displayed in a directory path.</summary>
	/// <remarks>
	/// <para>
	/// Special characters must be escaped when used for any unintended purposes. For example, LDAP special characters, the comma (,) and the
	/// equal sign (=), are intended as field separators in a distinguished name, "CN=user,CN=users,DC=Fabrikam,DC=com". When an attribute
	/// value uses such special characters, for example, "CN=users,last name=Smith", these special characters must be escaped as shown. This
	/// ensures that an LDAP-compliant directory, such as Active Directory, will parse the path properly. However, an escaped path string may
	/// not appear to be user-friendly on a display. In this case, you can set the <c>ADS_ESCAPE_MODE_ENUM</c> in such way that shows the
	/// path as an unescaped string, "CN=users,last name=Smith".
	/// </para>
	/// <para>
	/// Similarly, the ADSI special character, slash mark (/), separates ADSI-specific elements, "LDAP://server/CN=Jeff
	/// Smith,CN=Users,DC=Fabrikam,DC=com". Although it must be escaped when used for any other purposes, for example, "LDAP://server/CN=Jeff
	/// Smith/California,CN=Users,DC=Fabrikam,DC=com". You can choose an <c>ADS_ESCAPE_MODE_ENUM</c> option to display this escaped string in
	/// a human-readable form: "LDAP://server/CN=Jeff Smith/California,CN=Users,DC=Fabrikam,DC=com".
	/// </para>
	/// <para>
	/// Presently, the slash mark (/) is the only ADSI special character. ADSI escaping and unescaping applies to ADSI special characters
	/// only. The operation will not affect any LDAP special characters, that is, they are neither escaped nor unescaped. For more
	/// information and a list of special characters defined by LDAP, see LDAP Special Characters.
	/// </para>
	/// <para>
	/// To show unescaped path string, use the IADsPathname interface and its methods. All other ADSI APIs return the escaped path string.
	/// </para>
	/// <para>
	/// To obtain correct behavior, the LDAP special characters must be escaped before the ADSI special characters are escaped. The
	/// IADsPathname interface will escape the characters in the correct sequence.
	/// </para>
	/// <para>
	/// <c>Note</c>  Because VBScript cannot read data from a type library, Visual Basic Scripting Edition (VBScript) applications do not
	/// recognize symbolic, as constants defined above. Instead, use the numerical constants instead to set the appropriate flags in your
	/// VBScript applications. To use the symbolic constants, write explicit declarations of such constants, as done here.
	/// </para>
	/// <para></para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/iads/ne-iads-ads_escape_mode_enum typedef enum
	// __MIDL___MIDL_itf_ads_0001_0078_0004 { ADS_ESCAPEDMODE_DEFAULT = 1, ADS_ESCAPEDMODE_ON = 2, ADS_ESCAPEDMODE_OFF = 3,
	// ADS_ESCAPEDMODE_OFF_EX = 4 } ADS_ESCAPE_MODE_ENUM;
	[PInvokeData("iads.h", MSDNShortId = "NE:iads.__MIDL___MIDL_itf_ads_0001_0078_0004")]
	public enum ADS_ESCAPE_MODE
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>1</para>
		/// <para>
		/// The default escape mode provides a convenient option to specify the escape mode. It has the effect of minimal escape operation
		/// appropriate for a chosen format. Thus, the default behavior depends on the value that
		/// </para>
		/// <para>ADS_FORMAT_ENUM</para>
		/// <para>uses to retrieve the directory paths.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Retrieved path format</description>
		/// <description>Default escaped mode</description>
		/// </listheader>
		/// <item>
		/// <description><c>ADS_FORMAT_X500</c></description>
		/// <description><c>ADS_ESCAPEDMODE_ON</c></description>
		/// </item>
		/// <item>
		/// <description><c>ADS_FORMAT_X500_NO_SERVER</c></description>
		/// <description><c>ADS_ESCAPEDMODE_ON</c></description>
		/// </item>
		/// <item>
		/// <description><c>ADS_FORMAT_WINDOWS</c></description>
		/// <description><c>ADS_ESCAPEDMODE_ON</c></description>
		/// </item>
		/// <item>
		/// <description><c>ADS_FORMAT_WINDOWS_NO_SERVER</c></description>
		/// <description><c>ADS_ESCAPEDMODE_ON</c></description>
		/// </item>
		/// <item>
		/// <description><c>ADS_FORMAT_X500_DN</c></description>
		/// <description><c>ADS_ESCAPEDMODE_OFF</c></description>
		/// </item>
		/// <item>
		/// <description><c>ADS_FORMAT_X500_PARENT</c></description>
		/// <description><c>ADS_ESCAPEDMODE_OFF</c></description>
		/// </item>
		/// <item>
		/// <description><c>ADS_FORMAT_WINDOWS_DN</c></description>
		/// <description><c>ADS_ESCAPEDMODE_OFF</c></description>
		/// </item>
		/// <item>
		/// <description><c>ADS_FORMAT_WINDOWS_PARENT</c></description>
		/// <description><c>ADS_ESCAPEDMODE_OFF</c></description>
		/// </item>
		/// <item>
		/// <description><c>ADS_FORMAT_LEAF</c></description>
		/// <description><c>ADS_ESCAPEDMODE_ON</c></description>
		/// </item>
		/// </list>
		/// </summary>
		ADS_ESCAPEDMODE_DEFAULT = 1,

		/// <summary>
		/// <para>Value:</para>
		/// <para>2</para>
		/// <para>All special characters are displayed in the escape format; for example, "CN=date=yy/mm/dd,weekday" appears as is.</para>
		/// </summary>
		ADS_ESCAPEDMODE_ON,

		/// <summary>
		/// <para>Value:</para>
		/// <para>3</para>
		/// <para>ADSI special characters are displayed in the unescaped format; for example, "CN=date=yy/mm/dd,weekday" appears as "CN=date=yy/mm/dd,weekday".</para>
		/// </summary>
		ADS_ESCAPEDMODE_OFF,

		/// <summary>
		/// <para>Value:</para>
		/// <para>4</para>
		/// <para>
		/// ADSI and LDAP special characters are displayed in the unescaped format; for example, "CN=date=yy/mm/dd,weekday" appears as "CN=date=yy/mm/dd,weekday".
		/// </para>
		/// </summary>
		ADS_ESCAPEDMODE_OFF_EX,
	}

	/// <summary>Values for <see cref="IADsExtension.Operate"/>.</summary>
	public enum ADS_EXT
	{
		/// <summary>Verifies user credentials in the extension object.</summary>
		ADS_EXT_INITCREDENTIALS = 1,

		/// <summary></summary>
		ADS_EXT_INITIALIZE_COMPLETE = 2,
	}

	/// <summary>
	/// The <c>ADS_FLAGTYPE_ENUM</c> enumeration specifies values that can be used to indicate the presence of the <c>ObjectType</c> or
	/// <c>InheritedObjectType</c> fields in the access-control entry (ACE).
	/// </summary>
	/// <remarks>
	/// <para>
	/// <c>ObjectType</c> indicates what object type, property set, or property an ACE refers to. It takes a GUID as its value. The GUID
	/// referenced by <c>ObjectType</c> is not physically present in the ACE unless ADS_FLAGS_OBJECT_TYPE_PRESENT is set.
	/// </para>
	/// <para>
	/// <c>InheritedObjectType</c> specifies the GUID of an object that will inherit the ACE. The GUID is not physically present in the ACE
	/// unless the ADS_FLAG_INHERITED_OBJECT_TYPE_PRESENT bit is set.
	/// </para>
	/// <para>
	/// <c>Note</c>  Because VBScript cannot read information from a type library, VBScript applications do not understand the symbolic
	/// constants as defined above. You should use the numerical constants instead to set the appropriate flags in your VBScript
	/// applications. If you want to use the symbolic constants as a good programming practice, you should make explicit declarations of such
	/// constants, as done here, in your VBScript applications.
	/// </para>
	/// <para></para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/iads/ne-iads-ads_flagtype_enum typedef enum __MIDL___MIDL_itf_ads_0001_0048_0004 {
	// ADS_FLAG_OBJECT_TYPE_PRESENT = 0x1, ADS_FLAG_INHERITED_OBJECT_TYPE_PRESENT = 0x2 } ADS_FLAGTYPE_ENUM;
	[PInvokeData("iads.h", MSDNShortId = "NE:iads.__MIDL___MIDL_itf_ads_0001_0048_0004")]
	[Flags]
	public enum ADS_FLAGTYPE : uint
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0x1</para>
		/// <para>The</para>
		/// <para>ObjectType</para>
		/// <para>field is present in the ACE.</para>
		/// </summary>
		ADS_FLAG_OBJECT_TYPE_PRESENT = 0x1,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x2</para>
		/// <para>The</para>
		/// <para>InheritedObjectType</para>
		/// <para>field is present in the ACE.</para>
		/// </summary>
		ADS_FLAG_INHERITED_OBJECT_TYPE_PRESENT = 0x2,
	}

	/// <summary>The <c>ADS_FORMAT_ENUM</c> enumeration specifies the available path value types used by the IADsPathname::Retrieve method.</summary>
	/// <remarks>
	/// <para>The WinNT provider does not support any of the X.500 format specifiers.</para>
	/// <para>
	/// Because Visual Basic Scripting Edition cannot read data from a type library, VBScript applications cannot recognize the symbolic
	/// constants as defined above. You should use the numeric constants instead to set the appropriate flags in your VBScript applications.
	/// To use the symbolic constants as a good programming practice, write explicit declarations of such constants, as done here.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/iads/ne-iads-ads_format_enum typedef enum __MIDL___MIDL_itf_ads_0001_0078_0002 {
	// ADS_FORMAT_WINDOWS = 1, ADS_FORMAT_WINDOWS_NO_SERVER = 2, ADS_FORMAT_WINDOWS_DN = 3, ADS_FORMAT_WINDOWS_PARENT = 4, ADS_FORMAT_X500 =
	// 5, ADS_FORMAT_X500_NO_SERVER = 6, ADS_FORMAT_X500_DN = 7, ADS_FORMAT_X500_PARENT = 8, ADS_FORMAT_SERVER = 9, ADS_FORMAT_PROVIDER = 10,
	// ADS_FORMAT_LEAF = 11 } ADS_FORMAT_ENUM;
	[PInvokeData("iads.h", MSDNShortId = "NE:iads.__MIDL___MIDL_itf_ads_0001_0078_0002")]
	public enum ADS_FORMAT
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>1</para>
		/// <para>Returns the full path in Windows format, for example, "LDAP://servername/o=internet/…/cn=bar".</para>
		/// </summary>
		ADS_FORMAT_WINDOWS = 1,

		/// <summary>
		/// <para>Value:</para>
		/// <para>2</para>
		/// <para>Returns Windows format without server, for example, "LDAP://o=internet/…/cn=bar".</para>
		/// </summary>
		ADS_FORMAT_WINDOWS_NO_SERVER,

		/// <summary>
		/// <para>Value:</para>
		/// <para>3</para>
		/// <para>Returns Windows format of the distinguished name only, for example, "o=internet/…/cn=bar".</para>
		/// </summary>
		ADS_FORMAT_WINDOWS_DN,

		/// <summary>
		/// <para>Value:</para>
		/// <para>4</para>
		/// <para>Returns Windows format of Parent only, for example, "o=internet/…".</para>
		/// </summary>
		ADS_FORMAT_WINDOWS_PARENT,

		/// <summary>
		/// <para>Value:</para>
		/// <para>5</para>
		/// <para>Returns the full path in X.500 format, for example, "LDAP://servername/cn=bar,…,o=internet".</para>
		/// </summary>
		ADS_FORMAT_X500,

		/// <summary>
		/// <para>Value:</para>
		/// <para>6</para>
		/// <para>Returns the path without server in X.500 format, for example, "LDAP://cn=bar,…,o=internet".</para>
		/// </summary>
		ADS_FORMAT_X500_NO_SERVER,

		/// <summary>
		/// <para>Value:</para>
		/// <para>7</para>
		/// <para>Returns only the distinguished name in X.500 format. For example, "cn=bar,…,o=internet".</para>
		/// </summary>
		ADS_FORMAT_X500_DN,

		/// <summary>
		/// <para>Value:</para>
		/// <para>8</para>
		/// <para>Returns only the parent in X.500 format, for example, "…,o=internet".</para>
		/// </summary>
		ADS_FORMAT_X500_PARENT,

		/// <summary>
		/// <para>Value:</para>
		/// <para>9</para>
		/// <para>Returns the server name, for example, "servername".</para>
		/// </summary>
		ADS_FORMAT_SERVER,

		/// <summary>
		/// <para>Value:</para>
		/// <para>10</para>
		/// <para>Returns the name of the provider, for example, "LDAP".</para>
		/// </summary>
		ADS_FORMAT_PROVIDER,

		/// <summary>
		/// <para>Value:</para>
		/// <para>11</para>
		/// <para>Returns the name of the leaf, for example, "cn=bar".</para>
		/// </summary>
		ADS_FORMAT_LEAF,
	}

	/// <summary>The <c>ADS_GROUP_TYPE_ENUM</c> enumeration specifies the type of group objects in ADSI.</summary>
	/// <remarks>
	/// <para>
	/// Because VBScript cannot read data from a type library, VBScript applications do not understand recognize constants, as defined above.
	/// Use the numerical constants, instead, to set the appropriate flags in your VBScript application. To use the symbolic constants as a
	/// good programming practice, write explicit declarations of such constants, as done here, in your VBScript application.
	/// </para>
	/// <para>Examples</para>
	/// <para>The following code example shows how you might use elements of this enumeration.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/iads/ne-iads-ads_group_type_enum typedef enum __MIDL___MIDL_itf_ads_0001_0023_0001
	// { ADS_GROUP_TYPE_GLOBAL_GROUP = 0x2, ADS_GROUP_TYPE_DOMAIN_LOCAL_GROUP = 0x4, ADS_GROUP_TYPE_LOCAL_GROUP = 0x4,
	// ADS_GROUP_TYPE_UNIVERSAL_GROUP = 0x8, ADS_GROUP_TYPE_SECURITY_ENABLED = 0x80000000 } ADS_GROUP_TYPE_ENUM;
	[PInvokeData("iads.h", MSDNShortId = "NE:iads.__MIDL___MIDL_itf_ads_0001_0023_0001")]
	[Flags]
	public enum ADS_GROUP_TYPE : uint
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0x2</para>
		/// <para>
		/// Specifies a group that can contain accounts from the same domain and other global groups from the same domain. This type of group
		/// can be exported to a different domain.
		/// </para>
		/// </summary>
		ADS_GROUP_TYPE_GLOBAL_GROUP = 0x02,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x4</para>
		/// <para>
		/// Specifies a group that can contain accounts from any domain, other domain local groups from the same domain, global groups from
		/// any domain, and universal groups. This type of group should not be included in access-control lists of resources in other domains.
		/// </para>
		/// <para>This type of group is intended for use with the LDAP provider.</para>
		/// </summary>
		ADS_GROUP_TYPE_DOMAIN_LOCAL_GROUP = 0x04,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x4</para>
		/// <para>Specifies a group that is identical to the</para>
		/// <para>ADS_GROUP_TYPE_DOMAIN_LOCAL_GROUP</para>
		/// <para>group, but is intended for use with the WinNT provider.</para>
		/// </summary>
		ADS_GROUP_TYPE_LOCAL_GROUP = 0x04,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x8</para>
		/// <para>
		/// Specifies a group that can contain accounts from any domain, global groups from any domain, and other universal groups. This type
		/// of group cannot contain domain local groups.
		/// </para>
		/// </summary>
		ADS_GROUP_TYPE_UNIVERSAL_GROUP = 0x08,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x80000000</para>
		/// <para>
		/// Specifies a group that is security enabled. This group can be used to apply an access-control list on an ADSI object or a file system.
		/// </para>
		/// </summary>
		ADS_GROUP_TYPE_SECURITY_ENABLED = 0x80000000,
	}

	/// <summary>Values for <see cref="IADsPrintJobOperations.Status"/>.</summary>
	[Flags]
	public enum ADS_JOB_STATUS : uint
	{
		/// <summary>The print job is paused.</summary>
		ADS_JOB_PAUSED = 0x1,

		/// <summary>An error occurred.</summary>
		ADS_JOB_ERROR = 0x2,

		/// <summary>The print job is being deleted.</summary>
		ADS_JOB_DELETING = 0x4,

		/// <summary>The print job is being spooled.</summary>
		ADS_JOB_SPOOLING = 0x8,

		/// <summary>The print job is being printed.</summary>
		ADS_JOB_PRINTING = 0x10,

		/// <summary>The printer is offline.</summary>
		ADS_JOB_OFFLINE = 0x20,

		/// <summary>The printer is out of paper.</summary>
		ADS_JOB_PAPEROUT = 0x40,

		/// <summary>The print job has been printed.</summary>
		ADS_JOB_PRINTED = 0x80,

		/// <summary>The print job has been deleted.</summary>
		ADS_JOB_DELETED = 0x100,
	}

	/// <summary>
	/// The <c>ADS_NAME_INITTYPE_ENUM</c> enumeration specifies the types of initialization to perform on a <c>NameTranslate</c> object. It
	/// is used in the IADsNameTranslate interface.
	/// </summary>
	/// <remarks>
	/// <para>
	/// The IADsNameTranslate::Init method or IADsNameTranslate::InitEx method uses these options to initialize the <c>NameTranslate</c>
	/// object. When <c>ADS_NAME_INITTYPE_SERVER</c> is used, specify the machine name of a directory server. When
	/// <c>ADS_NAME_INITTYPE_DOMAIN</c> is set, supply the domain name within a directory forest. When <c>ADS_NAME_INITTYPE_GC</c> is issued,
	/// the second parameter in <c>IADsNameTranslate::Init</c> or <c>IADsNameTranslate::InitEx</c> is ignored. The Global Catalog server of
	/// the domain of the current computer is used to perform the name translate operations. The initialization fails if the host computer is
	/// not part of a domain because no global catalog will be found.
	/// </para>
	/// <para>
	/// <c>Note</c>  Because VBScript cannot read data from a type library, VBScript applications do not recognize the symbolic constants as
	/// defined above. Instead, use the numeric constants to set the appropriate flags in your VBScript applications. To use symbolic
	/// constants as a good programming practice, write explicit declarations of such constants, as done here, in your VBScript applications.
	/// </para>
	/// <para></para>
	/// <para>Examples</para>
	/// <para>
	/// The following C/C++ code example uses IADsNameTranslate::Init method to initialize a <c>NameTranslate</c> object through the global
	/// catalog, assuming the client running the application is within the directory forest. It then renders the distinguished name of a user
	/// object in the Windows format.
	/// </para>
	/// <para>
	/// The following Visual Basic code example uses the IADsNameTranslate::Init method to initialize a <c>NameTranslate</c> object through
	/// the global catalog, assuming the client running the application is within the directory forest. It then renders the distinguished
	/// name of a user object in the Windows format.
	/// </para>
	/// <para>
	/// The following VBScript/ASP code example uses IADsNameTranslate::Init method to initialize a <c>NameTranslate</c> object through the
	/// global catalog, assuming the client running the application is within the directory forest. It then renders the distinguished name of
	/// a user object in the Windows format.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/iads/ne-iads-ads_name_inittype_enum typedef enum
	// __MIDL___MIDL_itf_ads_0001_0050_0002 { ADS_NAME_INITTYPE_DOMAIN = 1, ADS_NAME_INITTYPE_SERVER = 2, ADS_NAME_INITTYPE_GC = 3 } ADS_NAME_INITTYPE_ENUM;
	[PInvokeData("iads.h", MSDNShortId = "NE:iads.__MIDL___MIDL_itf_ads_0001_0050_0002")]
	public enum ADS_NAME_INITTYPE
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>1</para>
		/// <para>Initializes a</para>
		/// <para>NameTranslate</para>
		/// <para>object by setting the domain that the object binds to.</para>
		/// </summary>
		ADS_NAME_INITTYPE_DOMAIN = 1,

		/// <summary>
		/// <para>Value:</para>
		/// <para>2</para>
		/// <para>Initializes a</para>
		/// <para>NameTranslate</para>
		/// <para>object by setting the server that the object binds to.</para>
		/// </summary>
		ADS_NAME_INITTYPE_SERVER,

		/// <summary>
		/// <para>Value:</para>
		/// <para>3</para>
		/// <para>Initializes a</para>
		/// <para>NameTranslate</para>
		/// <para>object by locating the global catalog that the object binds to.</para>
		/// </summary>
		ADS_NAME_INITTYPE_GC,
	}

	/// <summary>
	/// The <c>ADS_NAME_TYPE_ENUM</c> enumeration specifies the formats used for representing distinguished names. It is used by the
	/// IADsNameTranslate interface to convert the format of a distinguished name.
	/// </summary>
	/// <remarks>
	/// <para>Code examples written in C++, Visual Basic, and VBS/ASP can be found in the discussions of the IADsNameTranslate interface.</para>
	/// <para>
	/// Because VBScript cannot read data from a type library, an application must use the appropriate numeric constants, instead of the
	/// symbolic constants, to set the appropriate flags. To use the symbolic constants as a good programming practice, write explicit
	/// declarations of such constants, as done here, in VBScript applications.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/iads/ne-iads-ads_name_type_enum typedef enum __MIDL___MIDL_itf_ads_0001_0050_0001
	// { ADS_NAME_TYPE_1779 = 1, ADS_NAME_TYPE_CANONICAL = 2, ADS_NAME_TYPE_NT4 = 3, ADS_NAME_TYPE_DISPLAY = 4, ADS_NAME_TYPE_DOMAIN_SIMPLE =
	// 5, ADS_NAME_TYPE_ENTERPRISE_SIMPLE = 6, ADS_NAME_TYPE_GUID = 7, ADS_NAME_TYPE_UNKNOWN = 8, ADS_NAME_TYPE_USER_PRINCIPAL_NAME = 9,
	// ADS_NAME_TYPE_CANONICAL_EX = 10, ADS_NAME_TYPE_SERVICE_PRINCIPAL_NAME = 11, ADS_NAME_TYPE_SID_OR_SID_HISTORY_NAME = 12 } ADS_NAME_TYPE_ENUM;
	[PInvokeData("iads.h", MSDNShortId = "NE:iads.__MIDL___MIDL_itf_ads_0001_0050_0001")]
	public enum ADS_NAME_TYPE
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>1</para>
		/// <para>Name format as specified in RFC 1779. For example, "CN=Jeff Smith,CN=users,DC=Fabrikam,DC=com".</para>
		/// </summary>
		ADS_NAME_TYPE_1779 = 1,

		/// <summary>
		/// <para>Value:</para>
		/// <para>2</para>
		/// <para>Canonical name format. For example, "Fabrikam.com/Users/Jeff Smith".</para>
		/// </summary>
		ADS_NAME_TYPE_CANONICAL,

		/// <summary>
		/// <para>Value:</para>
		/// <para>3</para>
		/// <para>Account name format used in Windows. For example, "Fabrikam\JeffSmith".</para>
		/// </summary>
		ADS_NAME_TYPE_NT4,

		/// <summary>
		/// <para>Value:</para>
		/// <para>4</para>
		/// <para>Display name format. For example, "Jeff Smith".</para>
		/// </summary>
		ADS_NAME_TYPE_DISPLAY,

		/// <summary>
		/// <para>Value:</para>
		/// <para>5</para>
		/// <para>Simple domain name format. For example, "JeffSmith@Fabrikam.com".</para>
		/// </summary>
		ADS_NAME_TYPE_DOMAIN_SIMPLE,

		/// <summary>
		/// <para>Value:</para>
		/// <para>6</para>
		/// <para>Simple enterprise name format. For example, "JeffSmith@Fabrikam.com".</para>
		/// </summary>
		ADS_NAME_TYPE_ENTERPRISE_SIMPLE,

		/// <summary>
		/// <para>Value:</para>
		/// <para>7</para>
		/// <para>Global Unique Identifier format. For example, "{95ee9fff-3436-11d1-b2b0-d15ae3ac8436}".</para>
		/// </summary>
		ADS_NAME_TYPE_GUID,

		/// <summary>
		/// <para>Value:</para>
		/// <para>8</para>
		/// <para>Unknown name type. The system will estimate the format. This element is a meaningful option only with the</para>
		/// <para>IADsNameTranslate.Set</para>
		/// <para>or the</para>
		/// <para>IADsNameTranslate.SetEx</para>
		/// <para>method, but not with the</para>
		/// <para>IADsNameTranslate.Get</para>
		/// <para>or</para>
		/// <para>IADsNameTranslate.GetEx</para>
		/// <para>method.</para>
		/// </summary>
		ADS_NAME_TYPE_UNKNOWN,

		/// <summary>
		/// <para>Value:</para>
		/// <para>9</para>
		/// <para>User principal name format. For example, "JeffSmith@Fabrikam.com".</para>
		/// </summary>
		ADS_NAME_TYPE_USER_PRINCIPAL_NAME,

		/// <summary>
		/// <para>Value:</para>
		/// <para>10</para>
		/// <para>Extended canonical name format. For example, "Fabrikam.com/Users Jeff Smith".</para>
		/// </summary>
		ADS_NAME_TYPE_CANONICAL_EX,

		/// <summary>
		/// <para>Value:</para>
		/// <para>11</para>
		/// <para>Service principal name format. For example, "www/www.fabrikam.com@fabrikam.com".</para>
		/// </summary>
		ADS_NAME_TYPE_SERVICE_PRINCIPAL_NAME,

		/// <summary>
		/// <para>Value:</para>
		/// <para>12</para>
		/// <para>
		/// A SID string, as defined in the Security Descriptor Definition Language (SDDL), for either the SID of the current object or one
		/// from the object SID history. For example, "O:AOG:DAD:(A;;RPWPCCDCLCSWRCWDWOGA;;;S-1-0-0)" For more information, see
		/// </para>
		/// <para>Security Descriptor String Format</para>
		/// <para>.</para>
		/// </summary>
		ADS_NAME_TYPE_SID_OR_SID_HISTORY_NAME,
	}

	/// <summary>
	/// The <c>ADS_OPTION_ENUM</c> enumeration type contains values that indicate the options that can be retrieved or set with the
	/// IADsObjectOptions.GetOption and IADsObjectOptions.SetOption methods.
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/iads/ne-iads-ads_option_enum typedef enum __MIDL___MIDL_itf_ads_0001_0077_0001 {
	// ADS_OPTION_SERVERNAME = 0, ADS_OPTION_REFERRALS, ADS_OPTION_PAGE_SIZE, ADS_OPTION_SECURITY_MASK, ADS_OPTION_MUTUAL_AUTH_STATUS,
	// ADS_OPTION_QUOTA, ADS_OPTION_PASSWORD_PORTNUMBER, ADS_OPTION_PASSWORD_METHOD, ADS_OPTION_ACCUMULATIVE_MODIFICATION,
	// ADS_OPTION_SKIP_SID_LOOKUP } ADS_OPTION_ENUM;
	[PInvokeData("iads.h", MSDNShortId = "NE:iads.__MIDL___MIDL_itf_ads_0001_0077_0001")]
	public enum ADS_OPTION
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0</para>
		/// <para>Gets a</para>
		/// <para>VT_BSTR</para>
		/// <para>that contains the host name of the server for the current binding</para>
		/// <para>to this object. This option is not supported by the</para>
		/// <para>IADsObjectOptions.SetOption</para>
		/// <para>method.</para>
		/// </summary>
		ADS_OPTION_SERVERNAME,

		/// <summary>
		/// <para>Gets or sets a</para>
		/// <para>VT_I4</para>
		/// <para>value that indicates how referral chasing is performed in a</para>
		/// <para>query. This option can contain one of the</para>
		/// <para>values defined by the</para>
		/// <para>ADS_CHASE_REFERRALS_ENUM</para>
		/// <para>enumeration.</para>
		/// </summary>
		ADS_OPTION_REFERRALS,

		/// <summary>
		/// <para>Gets or sets a</para>
		/// <para>VT_I4</para>
		/// <para>value that indicates the page size in a paged search.</para>
		/// </summary>
		ADS_OPTION_PAGE_SIZE,

		/// <summary>
		/// <para>Gets or sets a</para>
		/// <para>VT_I4</para>
		/// <para>value that controls the security descriptor data that can be</para>
		/// <para>read on the object. This option can contain any combination of the values defined in the</para>
		/// <para>ADS_SECURITY_INFO_ENUM</para>
		/// <para>enumeration.</para>
		/// </summary>
		ADS_OPTION_SECURITY_MASK,

		/// <summary>
		/// <para>Gets a</para>
		/// <para>VT_I4</para>
		/// <para>value that determines if mutual authentication is performed by the</para>
		/// <para>SSPI layer. If the returned option value contains the</para>
		/// <para>ISC_RET_MUTUAL_AUTH</para>
		/// <para>flag,</para>
		/// <para>defined in Sspi.h, then mutual authentication has been performed. If the returned option value does not contain</para>
		/// <para>the</para>
		/// <para>ISC_RET_MUTUAL_AUTH</para>
		/// <para>flag, then mutual authentication has not been performed. For</para>
		/// <para>more information about mutual authentication, see</para>
		/// <para>SSPI</para>
		/// <para>. This</para>
		/// <para>option is not supported by the</para>
		/// <para>IADsObjectOptions.SetOption</para>
		/// <para>method.</para>
		/// </summary>
		ADS_OPTION_MUTUAL_AUTH_STATUS,

		/// <summary>
		/// <para>Enables the effective quota and used quota of a security principal to be read. This option takes a</para>
		/// <para>VT_BSTR</para>
		/// <para>value that contains the security principal that the quotas can be read for.</para>
		/// <para>If the security principal string is zero length or the value is a</para>
		/// <para>VT_EMPTY</para>
		/// <para>value,</para>
		/// <para>the security principal is the currently logged on user. This option is only supported by the</para>
		/// <para>IADsObjectOptions.SetOption</para>
		/// <para>method.</para>
		/// </summary>
		ADS_OPTION_QUOTA,

		/// <summary>
		/// <para>Retrieves or sets a</para>
		/// <para>VT_I4</para>
		/// <para>value that contains the port number that ADSI uses to</para>
		/// <para>establish a connection when the password is set or changed. By default, ADSI uses port 636 to establish a</para>
		/// <para>connection to set or change the password.</para>
		/// </summary>
		ADS_OPTION_PASSWORD_PORTNUMBER,

		/// <summary>
		/// <para>Retrieves or sets a</para>
		/// <para>VT_I4</para>
		/// <para>value that specifies the password encoding method.</para>
		/// <para>This option can contain one of the values defined in the</para>
		/// <para>ADS_PASSWORD_ENCODING_ENUM</para>
		/// <para>enumeration.</para>
		/// </summary>
		ADS_OPTION_PASSWORD_METHOD,

		/// <summary>
		/// <para>Contains a</para>
		/// <para>VT_BOOL</para>
		/// <para>value that specifies if attribute value change operations</para>
		/// <para>should be accumulated. By default, when an attribute value is modified more than one time, the previous value</para>
		/// <para>change operation is overwritten by the more recent operation. If this option is set to</para>
		/// <para>VARIANT_TRUE</para>
		/// <para>, each attribute value change operation is accumulated in the cache.</para>
		/// <para>When the attribute value updates are committed to the server with the</para>
		/// <para>IADs.SetInfo</para>
		/// <para>method, each individual accumulated</para>
		/// <para>operation is sent to the server.</para>
		/// <para>When this option has been set to</para>
		/// <para>VARIANT_TRUE</para>
		/// <para>, it cannot be reset to</para>
		/// <para>VARIANT_FALSE</para>
		/// <para>for the lifetime of the ADSI object. To reset this option, all</para>
		/// <para>references to the ADSI object must be released and the object must be bound to again. When the object is bound</para>
		/// <para>to again, this option will be set to</para>
		/// <para>VARIANT_FALSE</para>
		/// <para>by default.</para>
		/// <para>This option only affects attribute values modified with the</para>
		/// <para>IADs.PutEx</para>
		/// <para>and</para>
		/// <para>IADsPropertyList.PutPropertyItem</para>
		/// <para>methods. This option is ignored by the</para>
		/// <para>IADs.Put</para>
		/// <para>method.</para>
		/// </summary>
		ADS_OPTION_ACCUMULATIVE_MODIFICATION,

		/// <summary>
		/// <para>If this option is set on the object, no lookups will be performed (either during the retrieval or during</para>
		/// <para>modification). This option affects the</para>
		/// <para>IADs</para>
		/// <para>and</para>
		/// <para>IADsPropertyList</para>
		/// <para>interfaces. It is also applicable</para>
		/// <para>when retrieving the effective quota usage of a particular user.</para>
		/// </summary>
		ADS_OPTION_SKIP_SID_LOOKUP,
	}

	/// <summary>
	/// The <c>ADS_PASSWORD_ENCODING_ENUM</c> enumeration identifies the type of password encoding used with the
	/// <c>ADS_OPTION_PASSWORD_METHOD</c> option in the IADsObjectOptions::GetOption and IADsObjectOptions::SetOption methods.
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/iads/ne-iads-ads_password_encoding_enum typedef enum
	// __MIDL___MIDL_itf_ads_0000_0000_0026 { ADS_PASSWORD_ENCODE_REQUIRE_SSL = 0, ADS_PASSWORD_ENCODE_CLEAR = 1 } ADS_PASSWORD_ENCODING_ENUM;
	[PInvokeData("iads.h", MSDNShortId = "NE:iads.__MIDL___MIDL_itf_ads_0000_0000_0026")]
	public enum ADS_PASSWORD_ENCODING
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0</para>
		/// <para>Passwords are encoded using SSL.</para>
		/// </summary>
		ADS_PASSWORD_ENCODE_REQUIRE_SSL,

		/// <summary>
		/// <para>Value:</para>
		/// <para>1</para>
		/// <para>Passwords are not encoded and are transmitted in plaintext.</para>
		/// </summary>
		ADS_PASSWORD_ENCODE_CLEAR,
	}

	/// <summary>
	/// The <c>ADS_PATHTYPE_ENUM</c> enumeration specifies the type of object on which the IADsSecurityUtility interface is going to add or
	/// modify a security descriptor.
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/iads/ne-iads-ads_pathtype_enum typedef enum __MIDL___MIDL_itf_ads_0001_0088_0001 {
	// ADS_PATH_FILE = 1, ADS_PATH_FILESHARE = 2, ADS_PATH_REGISTRY = 3 } ADS_PATHTYPE_ENUM;
	[PInvokeData("iads.h", MSDNShortId = "NE:iads.__MIDL___MIDL_itf_ads_0001_0088_0001")]
	public enum ADS_PATHTYPE
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>1</para>
		/// <para>Indicates that the security descriptor will be retrieved or set on a file object.</para>
		/// </summary>
		ADS_PATH_FILE = 1,

		/// <summary>
		/// <para>Value:</para>
		/// <para>2</para>
		/// <para>Indicates that the security descriptor will be retrieved or set on a file share object.</para>
		/// </summary>
		ADS_PATH_FILESHARE,

		/// <summary>
		/// <para>Value:</para>
		/// <para>3</para>
		/// <para>Indicates that the security descriptor will be retrieved or set on a registry key object.</para>
		/// </summary>
		ADS_PATH_REGISTRY,
	}

	/// <summary>The <c>ADS_PREFERENCES_ENUM</c> enumeration specifies the query preferences of the OLE DB provider for ADSI.</summary>
	/// <remarks>
	/// Because VBScript cannot read data from a type library, VBScript applications do not recognize the symbolic constants as defined
	/// above. Instead, use the numerical constants to set the appropriate flags in your VBScript application. To use the symbolic constants,
	/// as a good programming practice, write explicit declarations of such constants, as done here, in your VBScript application.
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/iads/ne-iads-ads_preferences_enum typedef enum
	// __MIDL___MIDL_itf_ads_0000_0000_0022 { ADSIPROP_ASYNCHRONOUS = 0, ADSIPROP_DEREF_ALIASES = 0x1, ADSIPROP_SIZE_LIMIT = 0x2,
	// ADSIPROP_TIME_LIMIT = 0x3, ADSIPROP_ATTRIBTYPES_ONLY = 0x4, ADSIPROP_SEARCH_SCOPE = 0x5, ADSIPROP_TIMEOUT = 0x6, ADSIPROP_PAGESIZE =
	// 0x7, ADSIPROP_PAGED_TIME_LIMIT = 0x8, ADSIPROP_CHASE_REFERRALS = 0x9, ADSIPROP_SORT_ON = 0xa, ADSIPROP_CACHE_RESULTS = 0xb,
	// ADSIPROP_ADSIFLAG = 0xc } ADS_PREFERENCES_ENUM;
	[PInvokeData("iads.h", MSDNShortId = "NE:iads.__MIDL___MIDL_itf_ads_0000_0000_0022")]
	public enum ADS_PREFERENCES
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0</para>
		/// <para>Requests an asynchronous search.</para>
		/// </summary>
		ADSIPROP_ASYNCHRONOUS,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x1</para>
		/// <para>Specifies that aliases of found objects are to be resolved. Use</para>
		/// <para>ADS_DEREFENUM</para>
		/// <para>to specify how to perform this operation.</para>
		/// </summary>
		ADSIPROP_DEREF_ALIASES,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x2</para>
		/// <para>
		/// Specifies the size limit that the server should observe in a search. The size limit is the maximum number of returned objects. A
		/// zero value indicates that no size limit is imposed. The server stops searching once the size limit is reached and returns the
		/// results accumulated up to that point.
		/// </para>
		/// </summary>
		ADSIPROP_SIZE_LIMIT,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x3</para>
		/// <para>
		/// Specifies the time limit, in seconds, that the server should observe in a search. A zero value indicates that no time limit
		/// restriction is imposed. When the time limit is reached, the server stops searching and returns results accumulated to that point.
		/// </para>
		/// </summary>
		ADSIPROP_TIME_LIMIT,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x4</para>
		/// <para>Indicates that the search should obtain only the name of attributes to which values have been assigned.</para>
		/// </summary>
		ADSIPROP_ATTRIBTYPES_ONLY,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x5</para>
		/// <para>
		/// Specifies the search scope that should be observed by the server. For more information about the appropriate settings, see the
		/// </para>
		/// <para>ADS_SCOPEENUM</para>
		/// <para>enumeration.</para>
		/// </summary>
		ADSIPROP_SEARCH_SCOPE,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x6</para>
		/// <para>Specifies the time limit, in seconds, that a client will wait for the server to return the result.</para>
		/// </summary>
		ADSIPROP_TIMEOUT,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x7</para>
		/// <para>
		/// Specifies the page size in a paged search. For each request by the client, the server returns, at most, the number of objects as
		/// set by the page size.
		/// </para>
		/// </summary>
		ADSIPROP_PAGESIZE,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x8</para>
		/// <para>
		/// Specifies the time limit, in seconds, that the server should observe to search a page of results; this is opposed to the time
		/// limit for the entire search.
		/// </para>
		/// </summary>
		ADSIPROP_PAGED_TIME_LIMIT,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x9</para>
		/// <para>
		/// Specifies that referrals may be chased. If the root search is not specified in the naming context of the server or when the
		/// search results cross a naming context (for example, when you have child domains and search in the parent domain), the server
		/// sends a referral message to the client which the client can choose to ignore or chase. By default, this option is set to
		/// ADS_CHASE_REFERRALS_EXTERNAL. For more information about referrals chasing, see
		/// </para>
		/// <para>ADS_CHASE_REFERRALS_ENUM</para>
		/// <para>.</para>
		/// </summary>
		ADSIPROP_CHASE_REFERRALS,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0xa</para>
		/// <para>Specifies that the server sorts the result set. Use the</para>
		/// <para>ADS_SORTKEY</para>
		/// <para>structure to specify the sort keys.</para>
		/// </summary>
		ADSIPROP_SORT_ON,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0xb</para>
		/// <para>
		/// Specifies if the result should be cached on the client side. By default, ADSI caches the result set. Turning off this option may
		/// be more desirable for large result sets.
		/// </para>
		/// </summary>
		ADSIPROP_CACHE_RESULTS,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0xc</para>
		/// <para>Allows the OLEDB client to specify bind flags to use when binding to the server. Valid values are those allowed by</para>
		/// <para>ADsOpenObject</para>
		/// <para>. It is accessed from ADO scripts using the property name "ADSI Flag."</para>
		/// </summary>
		ADSIPROP_ADSIFLAG,
	}

	/// <summary>Values for <see cref="IADsPrintQueueOperations.Status"/>.</summary>
	public enum ADS_PRINT_QUEUE_STATUS
	{
		/// <summary/>
		ADS_PRINTER_PAUSED = 0x00000001,

		/// <summary/>
		ADS_PRINTER_PENDING_DELETION = 0x00000002,

		/// <summary/>
		ADS_PRINTER_ERROR = 0x00000003,

		/// <summary/>
		ADS_PRINTER_PAPER_JAM = 0x00000004,

		/// <summary/>
		ADS_PRINTER_PAPER_OUT = 0x00000005,

		/// <summary/>
		ADS_PRINTER_MANUAL_FEED = 0x00000006,

		/// <summary/>
		ADS_PRINTER_PAPER_PROBLEM = 0x00000007,

		/// <summary/>
		ADS_PRINTER_OFFLINE = 0x00000008,

		/// <summary/>
		ADS_PRINTER_IO_ACTIVE = 0x00000100,

		/// <summary/>
		ADS_PRINTER_BUSY = 0x00000200,

		/// <summary/>
		ADS_PRINTER_PRINTING = 0x00000400,

		/// <summary/>
		ADS_PRINTER_OUTPUT_BIN_FULL = 0x00000800,

		/// <summary/>
		ADS_PRINTER_NOT_AVAILABLE = 0x00001000,

		/// <summary/>
		ADS_PRINTER_WAITING = 0x00002000,

		/// <summary/>
		ADS_PRINTER_PROCESSING = 0x00004000,

		/// <summary/>
		ADS_PRINTER_INITIALIZING = 0x00008000,

		/// <summary/>
		ADS_PRINTER_WARMING_UP = 0x00010000,

		/// <summary/>
		ADS_PRINTER_TONER_LOW = 0x00020000,

		/// <summary/>
		ADS_PRINTER_NO_TONER = 0x00040000,

		/// <summary/>
		ADS_PRINTER_PAGE_PUNT = 0x00080000,

		/// <summary/>
		ADS_PRINTER_USER_INTERVENTION = 0x00100000,

		/// <summary/>
		ADS_PRINTER_OUT_OF_MEMORY = 0x00200000,

		/// <summary/>
		ADS_PRINTER_DOOR_OPEN = 0x00400000,

		/// <summary/>
		ADS_PRINTER_SERVER_UNKNOWN = 0x00800000,

		/// <summary/>
		ADS_PRINTER_POWER_SAVE = 0x01000000,
	}

	/// <summary>The <c>ADS_PROPERTY_OPERATION_ENUM</c> enumeration specifies ways to update a named property in the cache.</summary>
	/// <remarks>
	/// <para>
	/// The elements of this enumeration are used with the IADs.PutEx method, the document of which provides an example of how to use these
	/// enumerated constants.
	/// </para>
	/// <para>
	/// Because Visual Basic Scripting Edition (VBScript) cannot read data from a type library, VBScript applications do not recognize the
	/// symbolic constants as defined. Use the numeric constants instead to set the appropriate flags in your VBScript applications. To use
	/// the symbolic constants as a good programming practice, write explicit declarations of such constants, as done here.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/iads/ne-iads-ads_property_operation_enum typedef enum
	// __MIDL___MIDL_itf_ads_0000_0000_0027 { ADS_PROPERTY_CLEAR = 1, ADS_PROPERTY_UPDATE = 2, ADS_PROPERTY_APPEND = 3, ADS_PROPERTY_DELETE =
	// 4 } ADS_PROPERTY_OPERATION_ENUM;
	[PInvokeData("iads.h", MSDNShortId = "NE:iads.__MIDL___MIDL_itf_ads_0000_0000_0027")]
	public enum ADS_PROPERTY_OPERATION
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>1</para>
		/// <para>Instructs the directory service to remove all the property value(s) from the object.</para>
		/// </summary>
		ADS_PROPERTY_CLEAR = 1,

		/// <summary>
		/// <para>Value:</para>
		/// <para>2</para>
		/// <para>Instructs the directory service to replace the current value(s) with the specified value(s).</para>
		/// </summary>
		ADS_PROPERTY_UPDATE,

		/// <summary>
		/// <para>Value:</para>
		/// <para>3</para>
		/// <para>Instructs the directory service to append the specified value(s) to the existing values(s).</para>
		/// <para>When the</para>
		/// <para>ADS_PROPERTY_APPEND</para>
		/// <para>
		/// operation is specified, the new attribute value(s) are automatically committed to the directory service and removed from the
		/// local cache. This forces the local cache to be updated from the directory service the next time the attribute value(s) are retrieved.
		/// </para>
		/// </summary>
		ADS_PROPERTY_APPEND,

		/// <summary>
		/// <para>Value:</para>
		/// <para>4</para>
		/// <para>Instructs the directory service to delete the specified value(s) from the object.</para>
		/// </summary>
		ADS_PROPERTY_DELETE,
	}

	/// <summary>
	/// <para>
	/// The <c>ADS_RIGHTS_ENUM</c> enumeration specifies access rights assigned to an Active Directory object. The
	/// IADsAccessControlEntry.AccessMask property contains a combination of these values for an Active Directory object.
	/// </para>
	/// <para>
	/// For more information and a list of possible access right values for file or file share objects, see File Security and Access Rights.
	/// </para>
	/// <para>
	/// For more information and a list of possible access right values for registry objects, see Registry Key Security and Access Rights.
	/// </para>
	/// </summary>
	/// <remarks>
	/// <para>
	/// To assign access rights to an object, set the <c>AccessMask</c> field of an access-control entry (ACE) to a combination of the
	/// constants defined in this enumeration. In addition to the <c>AccessMask</c> field, an ACE can have other fields, including
	/// <c>ACEType</c>, <c>ACEFlags</c>, <c>ObjectType</c>, <c>InheritedObjectType</c>, <c>Flags</c>, and <c>Trustee</c>. The
	/// IADsAccessControlEntry interface provides property methods to obtain and modify these fields.
	/// </para>
	/// <para>
	/// The <c>ObjectType</c> field specifies a <c>GUID</c> that identifies the property set, property, extended right, or type of child
	/// object to which the ACE applies. The <c>InheritedObjectType</c> field specifies a <c>GUID</c> that identifies the type of child
	/// object that can inherit the ACE. The <c>Trustee</c> field identifies the security principal to whom the ACE allows or denies the
	/// specified access rights.
	/// </para>
	/// <para>For more information about <c>ACEType</c>, <c>ACEFlags</c>, and <c>Flags</c>, see ADS_ACETYPE_ENUM, ADS_ACEFLAG_ENUM.</para>
	/// <para>
	/// <c>Note</c>  Because VBScript cannot read data from a type library, VBScript applications do not recognize the symbolic constants as
	/// defined above. Instead, use the numerical constants to set the appropriate flags in your VBScript application. To use the symbolic
	/// constants as a good programming practice, write explicit declarations of such constants, as done here, in your VBScript applications.
	/// </para>
	/// <para></para>
	/// <para>
	/// The specific access rights granted by the four generic rights enumerations ( <c>ADS_RIGHT_GENERIC_xxx</c>) is dependent on the
	/// specific ADSI service provider being accessed. For Active Directory, these generic rights are defined in the Ntdsapi.h header file as
	/// <c>DS_GENERIC_READ</c>, <c>DS_GENERIC_WRITE</c>, <c>DS_GENERIC_EXECUTE</c>, and <c>DS_GENERIC_ALL</c>. For more information about how
	/// to use the Access Right and Access Masks, see Access Control.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/iads/ne-iads-ads_rights_enum typedef enum __MIDL___MIDL_itf_ads_0001_0048_0001 {
	// ADS_RIGHT_DELETE = 0x10000, ADS_RIGHT_READ_CONTROL = 0x20000, ADS_RIGHT_WRITE_DAC = 0x40000, ADS_RIGHT_WRITE_OWNER = 0x80000,
	// ADS_RIGHT_SYNCHRONIZE = 0x100000, ADS_RIGHT_ACCESS_SYSTEM_SECURITY = 0x1000000, ADS_RIGHT_GENERIC_READ = 0x80000000,
	// ADS_RIGHT_GENERIC_WRITE = 0x40000000, ADS_RIGHT_GENERIC_EXECUTE = 0x20000000, ADS_RIGHT_GENERIC_ALL = 0x10000000,
	// ADS_RIGHT_DS_CREATE_CHILD = 0x1, ADS_RIGHT_DS_DELETE_CHILD = 0x2, ADS_RIGHT_ACTRL_DS_LIST = 0x4, ADS_RIGHT_DS_SELF = 0x8,
	// ADS_RIGHT_DS_READ_PROP = 0x10, ADS_RIGHT_DS_WRITE_PROP = 0x20, ADS_RIGHT_DS_DELETE_TREE = 0x40, ADS_RIGHT_DS_LIST_OBJECT = 0x80,
	// ADS_RIGHT_DS_CONTROL_ACCESS = 0x100 } ADS_RIGHTS_ENUM;
	[PInvokeData("iads.h", MSDNShortId = "NE:iads.__MIDL___MIDL_itf_ads_0001_0048_0001")]
	[Flags]
	public enum ADS_RIGHTS : uint
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0x10000</para>
		/// <para>The right to delete the object.</para>
		/// </summary>
		ADS_RIGHT_DELETE = 0x10000,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x20000</para>
		/// <para>The right to read data from the security descriptor of the object, not including the data in the SACL.</para>
		/// </summary>
		ADS_RIGHT_READ_CONTROL = 0x20000,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x40000</para>
		/// <para>The right to modify the discretionary access-control list (DACL) in the object security descriptor.</para>
		/// </summary>
		ADS_RIGHT_WRITE_DAC = 0x40000,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x80000</para>
		/// <para>
		/// The right to assume ownership of the object. The user must be an object trustee. The user cannot transfer the ownership to other users.
		/// </para>
		/// </summary>
		ADS_RIGHT_WRITE_OWNER = 0x80000,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x100000</para>
		/// <para>The right to use the object for synchronization. This enables a thread to wait until the object is in the signaled state.</para>
		/// </summary>
		ADS_RIGHT_SYNCHRONIZE = 0x100000,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x1000000</para>
		/// <para>The right to get or set the SACL in the object security descriptor.</para>
		/// </summary>
		ADS_RIGHT_ACCESS_SYSTEM_SECURITY = 0x1000000,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x80000000</para>
		/// <para>
		/// The right to read permissions on this object, read all the properties on this object, list this object name when the parent
		/// container is listed, and list the contents of this object if it is a container.
		/// </para>
		/// </summary>
		ADS_RIGHT_GENERIC_READ = 0x80000000,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x40000000</para>
		/// <para>
		/// The right to read permissions on this object, write all the properties on this object, and perform all validated writes to this object.
		/// </para>
		/// </summary>
		ADS_RIGHT_GENERIC_WRITE = 0x40000000,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x20000000</para>
		/// <para>The right to read permissions on, and list the contents of, a container object.</para>
		/// </summary>
		ADS_RIGHT_GENERIC_EXECUTE = 0x20000000,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x10000000</para>
		/// <para>
		/// The right to create or delete child objects, delete a subtree, read and write properties, examine child objects and the object
		/// itself, add and remove the object from the directory, and read or write with an extended right.
		/// </para>
		/// </summary>
		ADS_RIGHT_GENERIC_ALL = 0x10000000,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x1</para>
		/// <para>The right to create child objects of the object. The</para>
		/// <para>ObjectType</para>
		/// <para>member of an ACE can contain a</para>
		/// <para>GUID</para>
		/// <para>that identifies the type of child object whose creation is controlled. If</para>
		/// <para>ObjectType</para>
		/// <para>does not contain a</para>
		/// <para>GUID</para>
		/// <para>, the ACE controls the creation of all child object types.</para>
		/// </summary>
		ADS_RIGHT_DS_CREATE_CHILD = 0x1,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x2</para>
		/// <para>The right to delete child objects of the object. The</para>
		/// <para>ObjectType</para>
		/// <para>member of an ACE can contain a</para>
		/// <para>GUID</para>
		/// <para>that identifies a type of child object whose deletion is controlled. If</para>
		/// <para>ObjectType</para>
		/// <para>does not contain a</para>
		/// <para>GUID</para>
		/// <para>, the ACE controls the deletion of all child object types.</para>
		/// </summary>
		ADS_RIGHT_DS_DELETE_CHILD = 0x2,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x4</para>
		/// <para>The right to list child objects of this object. For more information about this right, see</para>
		/// <para>Controlling Object Visibility</para>
		/// <para>.</para>
		/// </summary>
		ADS_RIGHT_ACTRL_DS_LIST = 0x4,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x8</para>
		/// <para>The right to perform an operation controlled by a validated write access right. The</para>
		/// <para>ObjectType</para>
		/// <para>member of an ACE can contain a</para>
		/// <para>GUID</para>
		/// <para>that identifies the validated write. If</para>
		/// <para>ObjectType</para>
		/// <para>does not contain a</para>
		/// <para>GUID</para>
		/// <para>, the ACE controls the rights to perform all valid write operations associated with the object.</para>
		/// </summary>
		ADS_RIGHT_DS_SELF = 0x8,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x10</para>
		/// <para>The right to read properties of the object. The</para>
		/// <para>ObjectType</para>
		/// <para>member of an ACE can contain a</para>
		/// <para>GUID</para>
		/// <para>that identifies a property set or property. If</para>
		/// <para>ObjectType</para>
		/// <para>does not contain a</para>
		/// <para>GUID</para>
		/// <para>, the ACE controls the right to read all of the object properties.</para>
		/// </summary>
		ADS_RIGHT_DS_READ_PROP = 0x10,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x20</para>
		/// <para>The right to write properties of the object. The</para>
		/// <para>ObjectType</para>
		/// <para>member of an ACE can contain a</para>
		/// <para>GUID</para>
		/// <para>that identifies a property set or property. If</para>
		/// <para>ObjectType</para>
		/// <para>does not contain a</para>
		/// <para>GUID</para>
		/// <para>, the ACE controls the right to write all of the object properties.</para>
		/// </summary>
		ADS_RIGHT_DS_WRITE_PROP = 0x20,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x40</para>
		/// <para>The right to delete all child objects of this object, regardless of the permissions of the child objects.</para>
		/// </summary>
		ADS_RIGHT_DS_DELETE_TREE = 0x40,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x80</para>
		/// <para>The right to list a particular object. If the user is not granted such a right, and the user does not have</para>
		/// <para>ADS_RIGHT_ACTRL_DS_LIST</para>
		/// <para>set on the object parent, the object is hidden from the user. This right is ignored if the third character of the</para>
		/// <para>dSHeuristics</para>
		/// <para>property is '0' or not set. For more information, see</para>
		/// <para>Controlling Object Visibility</para>
		/// <para>.</para>
		/// </summary>
		ADS_RIGHT_DS_LIST_OBJECT = 0x80,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x100</para>
		/// <para>The right to perform an operation controlled by an extended access right. The</para>
		/// <para>ObjectType</para>
		/// <para>member of an ACE can contain a</para>
		/// <para>GUID</para>
		/// <para>that identifies the extended right. If</para>
		/// <para>ObjectType</para>
		/// <para>does not contain a</para>
		/// <para>GUID</para>
		/// <para>, the ACE controls the right to perform all extended right operations associated with the object.</para>
		/// </summary>
		ADS_RIGHT_DS_CONTROL_ACCESS = 0x100,
	}

	/// <summary>The <c>ADS_SCOPEENUM</c> enumeration specifies the scope of a directory search.</summary>
	/// <remarks>
	/// <para>If you do not explicitly set the search scope, the default is <c>ADS_SCOPE_SUBTREE</c>.</para>
	/// <para>
	/// Because VBScript cannot read data from a type library, VBScript applications do not recognize the symbolic constants as defined
	/// above. Use the numerical constants, instead, to set the appropriate flags in your VBScript applications. To use the symbolic
	/// constants as a good programming practice, create explicit declarations of such constants, as done here, in your VBScript applications.
	/// </para>
	/// <para>Examples</para>
	/// <para>
	/// Search scope is one of the search preferences clients can specify. The following code example shows how to accomplish this using the
	/// ADS_SEARCHPREF_INFO structure, together with the elements defined in the ADS_SEARCHPREF_ENUM and this enumeration.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/iads/ne-iads-ads_scopeenum typedef enum __MIDL___MIDL_itf_ads_0000_0000_0021 {
	// ADS_SCOPE_BASE = 0, ADS_SCOPE_ONELEVEL = 1, ADS_SCOPE_SUBTREE = 2 } ADS_SCOPEENUM;
	[PInvokeData("iads.h", MSDNShortId = "NE:iads.__MIDL___MIDL_itf_ads_0000_0000_0021")]
	public enum ADS_SCOPE
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0</para>
		/// <para>Limits the search to the base object. The result contains, at most, one object.</para>
		/// </summary>
		ADS_SCOPE_BASE,

		/// <summary>
		/// <para>Value:</para>
		/// <para>1</para>
		/// <para>Searches one level of the immediate children, excluding the base object.</para>
		/// </summary>
		ADS_SCOPE_ONELEVEL,

		/// <summary>
		/// <para>Value:</para>
		/// <para>2</para>
		/// <para>Searches the whole subtree, including all the children and the base object itself.</para>
		/// </summary>
		ADS_SCOPE_SUBTREE,
	}

	/// <summary>The <c>ADS_SD_CONTROL_ENUM</c> enumeration specifies control flags for a security descriptor.</summary>
	/// <remarks>
	/// <para>For more information, see Access Control under Security in the Platform Software Development Kit (SDK).</para>
	/// <para>
	/// Since VBScript cannot read information from a type library, VBScript applications do not understand the symbolic constants as defined
	/// above. You should use the numerical constants instead to set the appropriate flags in your VBScript applications. If you want to use
	/// the symbolic constants as a good programming practice, you should make explicit declarations of such constants, as done here, in your
	/// VBScript applications.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/iads/ne-iads-ads_sd_control_enum typedef enum __MIDL___MIDL_itf_ads_0001_0048_0005
	// { ADS_SD_CONTROL_SE_OWNER_DEFAULTED = 0x1, ADS_SD_CONTROL_SE_GROUP_DEFAULTED = 0x2, ADS_SD_CONTROL_SE_DACL_PRESENT = 0x4,
	// ADS_SD_CONTROL_SE_DACL_DEFAULTED = 0x8, ADS_SD_CONTROL_SE_SACL_PRESENT = 0x10, ADS_SD_CONTROL_SE_SACL_DEFAULTED = 0x20,
	// ADS_SD_CONTROL_SE_DACL_AUTO_INHERIT_REQ = 0x100, ADS_SD_CONTROL_SE_SACL_AUTO_INHERIT_REQ = 0x200,
	// ADS_SD_CONTROL_SE_DACL_AUTO_INHERITED = 0x400, ADS_SD_CONTROL_SE_SACL_AUTO_INHERITED = 0x800, ADS_SD_CONTROL_SE_DACL_PROTECTED =
	// 0x1000, ADS_SD_CONTROL_SE_SACL_PROTECTED = 0x2000, ADS_SD_CONTROL_SE_SELF_RELATIVE = 0x8000 } ADS_SD_CONTROL_ENUM;
	[PInvokeData("iads.h", MSDNShortId = "NE:iads.__MIDL___MIDL_itf_ads_0001_0048_0005")]
	[Flags]
	public enum ADS_SD_CONTROL : uint
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0x1</para>
		/// <para>
		/// A default mechanism provides the owner security identifier (SID) of the security descriptor rather than the original provider of
		/// the security descriptor.
		/// </para>
		/// </summary>
		ADS_SD_CONTROL_SE_OWNER_DEFAULTED = 0x1,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x2</para>
		/// <para>
		/// A default mechanism provides the group SID of the security descriptor rather than the original provider of the security descriptor.
		/// </para>
		/// </summary>
		ADS_SD_CONTROL_SE_GROUP_DEFAULTED = 0x2,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x4</para>
		/// <para>
		/// The discretionary access-control list (DACL) is present in the security descriptor. If this flag is not set, or if this flag is
		/// set and the DACL is
		/// </para>
		/// <para>NULL</para>
		/// <para>, the security descriptor allows full access to everyone.</para>
		/// </summary>
		ADS_SD_CONTROL_SE_DACL_PRESENT = 0x4,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x8</para>
		/// <para>The security descriptor uses a default DACL built from the creator's access token.</para>
		/// </summary>
		ADS_SD_CONTROL_SE_DACL_DEFAULTED = 0x8,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x10</para>
		/// <para>The system access-control list (SACL) is present in the security descriptor.</para>
		/// </summary>
		ADS_SD_CONTROL_SE_SACL_PRESENT = 0x10,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x20</para>
		/// <para>The security descriptor uses a default SACL built from the creator's access token.</para>
		/// </summary>
		ADS_SD_CONTROL_SE_SACL_DEFAULTED = 0x20,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x100</para>
		/// <para>THE DACL of the security descriptor must be inherited.</para>
		/// </summary>
		ADS_SD_CONTROL_SE_DACL_AUTO_INHERIT_REQ = 0x100,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x200</para>
		/// <para>The SACL of the security descriptor must be inherited.</para>
		/// </summary>
		ADS_SD_CONTROL_SE_SACL_AUTO_INHERIT_REQ = 0x200,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x400</para>
		/// <para>
		/// The DACL of the security descriptor supports automatic propagation of inheritable access-control entries (ACEs) to existing child objects.
		/// </para>
		/// </summary>
		ADS_SD_CONTROL_SE_DACL_AUTO_INHERITED = 0x400,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x800</para>
		/// <para>The SACL of the security descriptor supports automatic propagation of inheritable ACEs to existing child objects.</para>
		/// </summary>
		ADS_SD_CONTROL_SE_SACL_AUTO_INHERITED = 0x800,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x1000</para>
		/// <para>The security descriptor will not allow inheritable ACEs to modify the DACL.</para>
		/// </summary>
		ADS_SD_CONTROL_SE_DACL_PROTECTED = 0x1000,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x2000</para>
		/// <para>The security descriptor will not allow inheritable ACEs to modify the SACL.</para>
		/// </summary>
		ADS_SD_CONTROL_SE_SACL_PROTECTED = 0x2000,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x8000</para>
		/// <para>The security descriptor is of self-relative format with all the security information in a continuous block of memory.</para>
		/// </summary>
		ADS_SD_CONTROL_SE_SELF_RELATIVE = 0x8000,
	}

	/// <summary>
	/// The <c>ADS_SD_FORMAT_ENUM</c> enumeration specifies the format that the security descriptor of an object will be converted to by the
	/// IADsSecurityUtility interface.
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/iads/ne-iads-ads_sd_format_enum typedef enum __MIDL___MIDL_itf_ads_0001_0088_0002
	// { ADS_SD_FORMAT_IID = 1, ADS_SD_FORMAT_RAW = 2, ADS_SD_FORMAT_HEXSTRING = 3 } ADS_SD_FORMAT_ENUM;
	[PInvokeData("iads.h", MSDNShortId = "NE:iads.__MIDL___MIDL_itf_ads_0001_0088_0002")]
	public enum ADS_SD_FORMAT
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>1</para>
		/// <para>Indicates that the security descriptor is to be converted to the</para>
		/// <para>IADsSecurityDescriptor</para>
		/// <para>interface format. If</para>
		/// <para>ADS_SD_FORMAT_IID</para>
		/// <para>
		/// is used as the input format when setting the security descriptor, the variant passed in is expected to be a VT_DISPATCH, where
		/// the dispatch pointer supports the
		/// </para>
		/// <para>IADsSecurityDescriptor</para>
		/// <para>interface.</para>
		/// </summary>
		ADS_SD_FORMAT_IID = 1,

		/// <summary>
		/// <para>Value:</para>
		/// <para>2</para>
		/// <para>Indicates that the security descriptor is to be converted to the binary format.</para>
		/// </summary>
		ADS_SD_FORMAT_RAW,

		/// <summary>
		/// <para>Value:</para>
		/// <para>3</para>
		/// <para>Indicates that the security descriptor is to be converted to the hex encoded string format.</para>
		/// </summary>
		ADS_SD_FORMAT_HEXSTRING,
	}

	/// <summary>
	/// The <c>ADS_SD_REVISION_ENUM</c> enumeration specifies the revision number of the access-control entry (ACE), or the access-control
	/// list (ACL), for Active Directory.
	/// </summary>
	/// <remarks>
	/// <para>The <c>ADS_SD_REVISION_DS</c> flag signifies that the related ACL contains object-specific ACEs.</para>
	/// <para>
	/// Because VBScript cannot read data from a type library, VBScript applications cannot recognize the symbolic constants as defined
	/// above. Use the numerical constants instead to set the appropriate flags in your VBScript applications. To use the symbolic constants
	/// as a good programming practice, write explicit declarations of such constants, as done here, in your VBScript applications.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/iads/ne-iads-ads_sd_revision_enum typedef enum
	// __MIDL___MIDL_itf_ads_0001_0048_0006 { ADS_SD_REVISION_DS = 4 } ADS_SD_REVISION_ENUM;
	[PInvokeData("iads.h", MSDNShortId = "NE:iads.__MIDL___MIDL_itf_ads_0001_0048_0006")]
	public enum ADS_SD_REVISION
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>4</para>
		/// <para>The revision number of the ACE, or the ACL, for Active Directory.</para>
		/// </summary>
		ADS_SD_REVISION_DS = 4,
	}

	/// <summary>
	/// The <c>ADS_SEARCHPREF_ENUM</c> enumeration specifies preferences for an IDirectorySearch object. This enumeration is used in the
	/// <c>dwSearchPref</c> member of the ADS_SEARCHPREF_INFO structure in the IDirectorySearch::SetSearchPreference method.
	/// </summary>
	/// <remarks>
	/// <para>
	/// To setup a search preference, assign appropriate values to the fields of an ADS_SEARCHPREF_INFO structure passed to the server. The
	/// <c>vValue</c> member of the <c>ADS_SEARCHPREF_INFO</c> structure is an ADSVALUE structure. The following list lists the
	/// <c>ADS_SEARCHPREF_ENUM</c> values, the corresponding values for the <c>dwType</c> member of the <c>ADSVALUE</c> structure, and the
	/// <c>ADSVALUE</c> member that is used for the specified type.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <description><c>ADS_SEARCHPREF_ENUM</c> value</description>
	/// <description><c>dwType</c> member of ADSVALUE</description>
	/// <description>ADSVALUE member</description>
	/// </listheader>
	/// <item>
	/// <description><c>ADS_SEARCHPREF_ASYNCHRONOUS</c></description>
	/// <description><c>ADSTYPE_BOOLEAN</c></description>
	/// <description><c>Boolean</c></description>
	/// </item>
	/// <item>
	/// <description><c>ADS_SEARCHPREF_DEREF_ALIASES</c></description>
	/// <description><c>ADSTYPE_INTEGER</c></description>
	/// <description><c>Integer</c></description>
	/// </item>
	/// <item>
	/// <description><c>ADS_SEARCHPREF_SIZE_LIMIT</c></description>
	/// <description><c>ADSTYPE_INTEGER</c></description>
	/// <description><c>Integer</c></description>
	/// </item>
	/// <item>
	/// <description><c>ADS_SEARCHPREF_TIME_LIMIT</c></description>
	/// <description><c>ADSTYPE_INTEGER</c></description>
	/// <description><c>Integer</c></description>
	/// </item>
	/// <item>
	/// <description><c>ADS_SEARCHPREF_ATTRIBTYPES_ONLY</c></description>
	/// <description><c>ADSTYPE_BOOLEAN</c></description>
	/// <description><c>Boolean</c></description>
	/// </item>
	/// <item>
	/// <description><c>ADS_SEARCHPREF_SEARCH_SCOPE</c></description>
	/// <description><c>ADSTYPE_INTEGER</c></description>
	/// <description><c>Integer</c></description>
	/// </item>
	/// <item>
	/// <description><c>ADS_SEARCHPREF_TIMEOUT</c></description>
	/// <description><c>ADSTYPE_INTEGER</c></description>
	/// <description><c>Integer</c></description>
	/// </item>
	/// <item>
	/// <description><c>ADS_SEARCHPREF_PAGESIZE</c></description>
	/// <description><c>ADSTYPE_INTEGER</c></description>
	/// <description><c>Integer</c></description>
	/// </item>
	/// <item>
	/// <description><c>ADS_SEARCHPREF_PAGED_TIME_LIMIT</c></description>
	/// <description><c>ADSTYPE_INTEGER</c></description>
	/// <description><c>Integer</c></description>
	/// </item>
	/// <item>
	/// <description><c>ADS_SEARCHPREF_CHASE_REFERRALS</c></description>
	/// <description><c>ADSTYPE_INTEGER</c></description>
	/// <description><c>Integer</c></description>
	/// </item>
	/// <item>
	/// <description><c>ADS_SEARCHPREF_SORT_ON</c></description>
	/// <description><c>ADSTYPE_PROV_SPECIFIC</c></description>
	/// <description><c>ProviderSpecific</c></description>
	/// </item>
	/// <item>
	/// <description><c>ADS_SEARCHPREF_CACHE_RESULTS</c></description>
	/// <description><c>ADSTYPE_BOOLEAN</c></description>
	/// <description><c>Boolean</c></description>
	/// </item>
	/// <item>
	/// <description><c>ADS_SEARCHPREF_DIRSYNC</c></description>
	/// <description><c>ADSTYPE_PROV_SPECIFIC</c></description>
	/// <description><c>ProviderSpecific</c></description>
	/// </item>
	/// <item>
	/// <description><c>ADS_SEARCHPREF_TOMBSTONE</c></description>
	/// <description><c>ADSTYPE_BOOLEAN</c></description>
	/// <description><c>Boolean</c></description>
	/// </item>
	/// <item>
	/// <description><c>ADS_SEARCHPREF_VLV</c></description>
	/// <description><c>ADSTYPE_PROV_SPECIFIC</c></description>
	/// <description><c>ProviderSpecific</c></description>
	/// </item>
	/// <item>
	/// <description><c>ADS_SEARCHPREF_ATTRIBUTE_QUERY</c></description>
	/// <description><c>ADSTYPE_CASE_IGNORE_STRING</c></description>
	/// <description><c>CaseIgnoreString</c></description>
	/// </item>
	/// <item>
	/// <description><c>ADS_SEARCHPREF_SECURITY_MASK</c></description>
	/// <description><c>ADSTYPE_INTEGER</c></description>
	/// <description><c>Integer</c></description>
	/// </item>
	/// <item>
	/// <description><c>ADS_SEARCHPREF_DIRSYNC_FLAG</c></description>
	/// <description><c>ADSTYPE_INTEGER</c></description>
	/// <description><c>Integer</c></description>
	/// </item>
	/// <item>
	/// <description><c>ADS_SEARCHPREF_EXTENDED_DN</c></description>
	/// <description><c>ADSTYPE_INTEGER</c></description>
	/// <description><c>Integer</c></description>
	/// </item>
	/// </list>
	/// <para></para>
	/// <para>
	/// To setup multiple preferences, use an array of ADS_SEARCHPREF_INFO structures. The member values of this enumeration are assigned to
	/// the <c>dwSearchPref</c> member of the <c>ADS_SEARCHPREF_INFO</c> structure.
	/// </para>
	/// <para>All options are supported by the LDAP system provider.</para>
	/// <para>
	/// Because VBScript cannot read data from a type library, VBScript applications do not recognize the symbolic constants as defined
	/// above. You should use the numerical constants, instead, to set the appropriate flags in your VBScript applications. To use the
	/// symbolic constants, as a good programming practice, explicitly declare such constants, as done here, in your VBScript applications.
	/// </para>
	/// <para>Examples</para>
	/// <para>The following code example shows how to set up search preferences using the ADS_SEARCHPREF_INFO enumeration.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/iads/ne-iads-ads_searchpref_enum typedef enum __MIDL___MIDL_itf_ads_0000_0000_0025
	// { ADS_SEARCHPREF_ASYNCHRONOUS = 0, ADS_SEARCHPREF_DEREF_ALIASES, ADS_SEARCHPREF_SIZE_LIMIT, ADS_SEARCHPREF_TIME_LIMIT,
	// ADS_SEARCHPREF_ATTRIBTYPES_ONLY, ADS_SEARCHPREF_SEARCH_SCOPE, ADS_SEARCHPREF_TIMEOUT, ADS_SEARCHPREF_PAGESIZE,
	// ADS_SEARCHPREF_PAGED_TIME_LIMIT, ADS_SEARCHPREF_CHASE_REFERRALS, ADS_SEARCHPREF_SORT_ON, ADS_SEARCHPREF_CACHE_RESULTS,
	// ADS_SEARCHPREF_DIRSYNC, ADS_SEARCHPREF_TOMBSTONE, ADS_SEARCHPREF_VLV, ADS_SEARCHPREF_ATTRIBUTE_QUERY, ADS_SEARCHPREF_SECURITY_MASK,
	// ADS_SEARCHPREF_DIRSYNC_FLAG, ADS_SEARCHPREF_EXTENDED_DN } ADS_SEARCHPREF_ENUM;
	[PInvokeData("iads.h", MSDNShortId = "NE:iads.__MIDL___MIDL_itf_ads_0000_0000_0025")]
	public enum ADS_SEARCHPREF
	{
		/// <summary>
		/// <para>Value: 0</para>
		/// <para>Specifies that searches should be performed asynchronously. By default, searches are synchronous.</para>
		/// <para>
		/// In a synchronous search, the IDirectorySearch::GetFirstRow and IDirectorySearch::GetNextRow methods do not return until the
		/// server returns the entire result, or for a paged search, the entire page.
		/// </para>
		/// <para>
		/// An asynchronous search blocks until one row of the search results is available, or until the timeout interval specified by the
		/// ADS_SEARCHPREF_TIMEOUT search preference elapses.
		/// </para>
		/// </summary>
		[CorrespondingType(typeof(bool))]
		ADS_SEARCHPREF_ASYNCHRONOUS,

		/// <summary>
		/// Specifies that aliases of found objects are to be resolved. Use the ADS_DEREFENUM enumeration to specify how this is performed.
		/// </summary>
		[CorrespondingType(typeof(bool))]
		ADS_SEARCHPREF_DEREF_ALIASES,

		/// <summary>
		/// <para>
		/// Specifies the size limit that the server should observe during a search. The server stops searching when the size limit is
		/// reached and returns the results accumulated to that point. If this value is zero, the size limit is determined by the directory
		/// service. The default for this value is zero. If this value is greater than the size limit determined by the directory service,
		/// the directory service limit takes precedence.
		/// </para>
		/// <para>
		/// For Active Directory, the size limit specifies the maximum number of objects to be returned by the search. Also for Active
		/// Directory, the maximum number of objects returned by a search is 1000 objects.
		/// </para>
		/// </summary>
		[CorrespondingType(typeof(int))]
		ADS_SEARCHPREF_SIZE_LIMIT,

		/// <summary>
		/// Specifies the number of seconds that the server waits for a search to complete. When the time limit is reached, the server stops
		/// searching and returns the results accumulated to that point. If this value is zero, the timeout period is infinite. The default
		/// for this value is 120 seconds.
		/// </summary>
		[CorrespondingType(typeof(int))]
		ADS_SEARCHPREF_TIME_LIMIT,

		/// <summary>
		/// Indicates that the search should obtain only the name of attributes to which values are assigned.
		/// </summary>
		[CorrespondingType(typeof(bool))]
		ADS_SEARCHPREF_ATTRIBTYPES_ONLY,

		/// <summary>
		/// Specifies the search scope that should be observed by the server. For more information about the appropriate settings, see the
		/// ADS_SCOPEENUM enumeration.
		/// </summary>
		[CorrespondingType(typeof(ADS_SCOPE))]
		ADS_SEARCHPREF_SEARCH_SCOPE,

		/// <summary>
		/// Specifies the time limit, in seconds, that a client will wait for the server to return the result. This option is set in an
		/// ADS_SEARCHPREF_INFO structure.
		/// </summary>
		[CorrespondingType(typeof(int))]
		ADS_SEARCHPREF_TIMEOUT,

		/// <summary>
		/// Specifies the page size in a paged search. For each request by the client, the server returns, at most, the number of objects as
		/// set by the page size. When page size is set, it is unnecessary to set the size limit. If a size limit is set, then the value for
		/// page size must be less than the value for size limit. If the value for page size exceeds size limit, then the
		/// ERROR_DS_SIZELIMIT_EXCEEDED error is returned with the number of rows specified by size limit.
		/// </summary>
		[CorrespondingType(typeof(int))]
		ADS_SEARCHPREF_PAGESIZE,

		/// <summary>
		/// Specifies the number of seconds that the server should wait for a page of search results, as opposed to the time limit for the
		/// entire search. When the time limit is reached, the server stops searching and returns the results obtained up to that point,
		/// along with a cookie that contains the data about where to resume searching. If this value is zero, the page timeout period is
		/// infinite. The default value for this limit is 120 seconds.
		/// </summary>
		[CorrespondingType(typeof(int))]
		ADS_SEARCHPREF_PAGED_TIME_LIMIT,

		/// <summary>
		/// Specifies that referrals may be chased. If the root search is not specified in the naming context of the server or when the
		/// search results cross a naming context, for example, when you have child domains and search in the parent domain, the server
		/// sends a referral message to the client which the client can choose to ignore or chase. For more information about referral
		/// chasing, see ADS_CHASE_REFERRALS_ENUM.
		/// </summary>
		[CorrespondingType(typeof(ADS_CHASE_REFERRALS))]
		ADS_SEARCHPREF_CHASE_REFERRALS,

		/// <summary>
		/// Specifies that the server sorts the result set. Use the ADS_SORTKEY structure to specify the sort keys. This search preference
		/// works only for directory servers that support the LDAP control for server-side sorting. Active Directory supports the sort
		/// control, but it can impact server performance, particularly if the results set is large. Active Directory supports only a single
		/// sort key.
		/// </summary>
		[CorrespondingType(typeof(ADS_SORTKEY))]
		ADS_SEARCHPREF_SORT_ON,

		/// <summary>
		/// Specifies if the result should be cached on the client side. By default, ADSI caches the result set. Disabling this option may
		/// be desirable for large result sets.
		/// </summary>
		[CorrespondingType(typeof(bool))]
		ADS_SEARCHPREF_CACHE_RESULTS,

		/// <summary>
		/// <para>
		/// Specifies a directory synchronization (DirSync) search, which returns all changes since a specified state. In the ADSVALUE
		/// structure, set the dwType member to ADS_PROV_SPECIFIC. The ProviderSpecific member is an ADS_PROV_SPECIFIC structure whose
		/// lpValue member specifies a cookie that indicates the state from which changes are retrieved. The first time you use the DirSync
		/// control, set the dwLength and lpValue members of the ADS_PROV_SPECIFIC structure to zero and NULL respectively. After reading
		/// the results set returned by the search until IDirectorySearch::GetNextRow returns S_ADS_NOMORE_ROWS, call
		/// IDirectorySearch::GetColumn to retrieve the ADS_DIRSYNC_COOKIE attribute which contains a cookie to use in the next DirSync
		/// search. For more information, see Polling for Changes Using the DirSync Control and LDAP_SERVER_DIRSYNC_OID.
		/// </para>
		/// <para>This flag cannot be combined with ADS_SEARCHPREF_PAGESIZE.</para>
		/// <para>The caller must have the SE_SYNC_AGENT_NAME privilege.</para>
		/// </summary>
		[CorrespondingType(typeof(ADS_PROV_SPECIFIC))]
		ADS_SEARCHPREF_DIRSYNC,

		/// <summary>
		/// <para>
		/// Specifies whether the search should also return deleted objects that match the search filter. When objects are deleted, Active
		/// Directory moves them to a "Deleted Objects" container. By default, deleted objects are not included in the search results. In
		/// the ADSVALUE structure, set the dwType member to ADSTYPE_BOOLEAN. To include deleted objects, set the Boolean member of the
		/// ADSVALUE structure to TRUE.
		/// </para>
		/// <para>
		/// Not all attributes are preserved when the object is deleted. You can retrieve the objectGUID and RDN attributes. The
		/// distinguishedName attribute is the DN of the object in the "Deleted Objects" container, not the previous DN. The isDeleted
		/// attribute is TRUE for a deleted object. For more information, see Retrieving Deleted Objects.
		/// </para>
		/// </summary>
		[CorrespondingType(typeof(bool))]
		ADS_SEARCHPREF_TOMBSTONE,

		/// <summary>
		/// <para>
		/// Specifies that the search should use the LDAP virtual list view (VLV) control. ADS_SEARCHPREF_VLV can be used to access both
		/// string-type and offset-type VLV searches, by setting the appropriate fields. These two options cannot be used simultaneously
		/// because it is not possible to set the VLV control to request a result set that is both located at a specific offset and follows
		/// a particular value in the sort sequence.
		/// </para>
		/// <para>
		/// To perform a string search, set the lpszTarget field in ADS_VLV to the string to be searched for. To perform an offset type
		/// search, set the dwOffset field in ADS_VLV. If you use an offset search, you must set lpszTarget to NULL.
		/// </para>
		/// <para>
		/// ADS_SEARCHPREF_SORT_ON must be set to TRUE when using ADS_SEARCHPREF_VLV. The sort order of the search results determines the
		/// order used for the VLV search. If performing an offset-type search, the offset is used as an index into the sorted list. If
		/// performing a string-type search, the server attempts to return the first entry which is greater-than-or-equal-to the string,
		/// based on the sort order.
		/// </para>
		/// <para>Caching of search results is disabled when ADS_SEARCHPREF_VLV is specified.</para>
		/// <para>
		/// If you assign ADS_SEARCHPREF_CACHE_RESULTS a TRUE, value when using ADS_SEARCHPREF_VLV, SetSearchPreference will fail and return
		/// the error E_ADS_BAD_PARAMETER.
		/// </para>
		/// </summary>
		[CorrespondingType(typeof(ADS_VLV))]
		ADS_SEARCHPREF_VLV,

		/// <summary>
		/// Specifies that an attribute-scoped query search should be performed. The search is performed against those objects named in a
		/// specified attribute of the base object. The vValue member of the ADS_SEARCHPREF_INFO structure contains a
		/// ADSTYPE_CASE_IGNORE_STRING value which contains the lDAPDisplayName of attribute to search. This attribute must be a
		/// ADS_DN_STRING attribute. Only one attribute may be specified. Search scope is automatically set to ADS_SCOPE_BASE when using
		/// this preference, and attempting to set the scope otherwise will fail with the error E_ADS_BAD_PARAMETER. With the exception of
		/// the ADS_SEARCHPREF_VLV preference, all other preferences that use LDAP controls, such as ADS_SEARCHPREF_DIRSYNC,
		/// ADS_SEARCHPREF_TOMBSTONE, and so on, are not allowed when this preference is specified.
		/// </summary>
		[CorrespondingType(typeof(string))]
		ADS_SEARCHPREF_ATTRIBUTE_QUERY,

		/// <summary>
		/// <para>
		/// Specifies that the search should return security access data for the specified attributes. The vValue member of the
		/// ADS_SEARCHPREF_INFO structure contains an ADS_INTEGER value that is a combination of one or more of the following values.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <description><c>ADS_SECURITY_INFO_OWNER</c></description>
		/// <description>Reads the owner data.</description>
		/// </item>
		/// <item>
		/// <description><c>ADS_SECURITY_INFO_GROUP</c></description>
		/// <description>Reads the group data.</description>
		/// </item>
		/// <item>
		/// <description><c>ADS_SECURITY_INFO_DACL</c></description>
		/// <description>Reads the discretionary access-control list (DACL).</description>
		/// </item>
		/// <item>
		/// <description><c>ADS_SECURITY_INFO_SACL</c></description>
		/// <description>Reads the system access-control list (SACL).</description>
		/// </item>
		/// </list>
		/// <para>
		/// If you read a security descriptor without explicitly specifying a security mask using ADS_SEARCHPREF_SECURITY_MASK, it defaults
		/// to the equivalent of ADS_SECURITY_INFO_OWNER
		/// </para>
		/// </summary>
		[CorrespondingType(typeof(ADS_SECURITY_INFO))]
		ADS_SEARCHPREF_SECURITY_MASK,

		/// <summary>
		/// <para>
		/// Contains optional flags for use with the ADS_SEARCHPREF_DIRSYNC search preference. The vValue member of the ADS_SEARCHPREF_INFO
		/// structure contains an ADSTYPE_INTEGER value that is zero or a combination of one or more of the following values. For more
		/// information about the DirSync control, see Polling for Changes Using the DirSync Control and LDAP_SERVER_DIRSYNC_OID.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Identifier</term>
		/// <term>Value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <description><c>LDAP_DIRSYNC_OBJECT_SECURITY</c></description>
		/// <description>1</description>
		/// <description>
		/// If this flag is not present, the caller must have the replicate changes right. If this flag is present,the caller requires no
		/// rights, but is only allowed to see objects and attributes which are accessible to the caller.
		/// </description>
		/// </item>
		/// <item>
		/// <description><c>LDAP_DIRSYNC_ANCESTORS_FIRST_ORDER</c></description>
		/// <description>2048 (0x00000800)</description>
		/// <description>
		/// Return parent objects before child objects, when parent objects would otherwise appear later in the replication stream.
		/// </description>
		/// </item>
		/// <item>
		/// <description><c>LDAP_DIRSYNC_PUBLIC_DATA_ONLY</c></description>
		/// <description>8192 (0x00002000)</description>
		/// <description>Do not return private data in the search results.</description>
		/// </item>
		/// <item>
		/// <description><c>LDAP_DIRSYNC_INCREMENTAL_VALUES</c></description>
		/// <description>2147483648 (0x80000000)</description>
		/// <description>
		/// If this flag is not present, all of the values, up to a server-specified limit, in a multi-valued attribute are returned when
		/// any value changes. If this flag is present, only the changed values are returned.
		/// </description>
		/// </item>
		/// </list>
		/// </summary>
		[CorrespondingType(typeof(int))]
		ADS_SEARCHPREF_DIRSYNC_FLAG,

		/// <summary>
		/// The search should return distinguished names in Active Directory extended format. The vValue member of the ADS_SEARCHPREF_INFO
		/// structure contains an ADSTYPE_INTEGER value that contains zero if the GUID and SID portions of the DN string should be in hex
		/// format or one if the GUID and SID portions of the DN string should be in standard format. For more information about extended
		/// distinguished names, see LDAP_SERVER_EXTENDED_DN_OID.
		/// </summary>
		[CorrespondingType(typeof(int))]
		ADS_SEARCHPREF_EXTENDED_DN,
	}

	/// <summary>The <c>ADS_SECURITY_INFO_ENUM</c> enumeration specifies the available options for examining security data of an object.</summary>
	/// <remarks>
	/// <para>The options defined in this enumeration are bit-masks. More than one option can be set using appropriate bitwise operations.</para>
	/// <para>
	/// To read the security data for an object, use the IADsObjectOptions interface, supplying the security data options listed in this enumeration.
	/// </para>
	/// <para>The following list lists common flag combinations and their use.</para>
	/// <list type="table">
	/// <listheader>
	/// <description>Flag combination</description>
	/// <description>Description</description>
	/// </listheader>
	/// <item>
	/// <description><c>ADS_SECURITY_INFO_OWNER</c>, <c>ADS_SECURITY_INFO_GROUP</c>, and <c>ADS_SECURITY_INFO_DACL</c></description>
	/// <description>
	/// Enable users to read the security data of the owner, group, or DACL of an object. This is the default setting when an object is created.
	/// </description>
	/// </item>
	/// <item>
	/// <description><c>ADS_SECURITY_INFO_OWNER</c>, <c>ADS_SECURITY_INFO_GROUP</c>, <c>ADS_SECURITY_INFO_DACL</c>, and <c>ADS_SECURITY_INFO_SACL</c></description>
	/// <description>Enable users to read the SACL. The <c>ADS_SECURITY_INFO_SACL</c> flag cannot be used by itself.</description>
	/// </item>
	/// </list>
	/// <para></para>
	/// <para>Presently, such options are available for Active Directory only.</para>
	/// <para>
	/// Because Visual Basic Scripting Edition (VBScript) cannot read data from a type library, an application must use the appropriate
	/// numeric constants, instead of the symbolic constants, to set the appropriate flags. To use the symbolic constants as a good
	/// programming practice, write explicit declarations of such constants, as done here.
	/// </para>
	/// <para>Examples</para>
	/// <para>The following code example displays the number of access control entries in a SACL.</para>
	/// <para>The following code example displays the number of access-control entries in a system ACL. For brevity, error checking is omitted.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/iads/ne-iads-ads_security_info_enum typedef enum
	// __MIDL___MIDL_itf_ads_0001_0077_0002 { ADS_SECURITY_INFO_OWNER = 0x1, ADS_SECURITY_INFO_GROUP = 0x2, ADS_SECURITY_INFO_DACL = 0x4,
	// ADS_SECURITY_INFO_SACL = 0x8 } ADS_SECURITY_INFO_ENUM;
	[PInvokeData("iads.h", MSDNShortId = "NE:iads.__MIDL___MIDL_itf_ads_0001_0077_0002")]
	[Flags]
	public enum ADS_SECURITY_INFO : uint
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0x1</para>
		/// <para>Reads or sets the owner data.</para>
		/// </summary>
		ADS_SECURITY_INFO_OWNER = 0x1,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x2</para>
		/// <para>Reads or sets the group data.</para>
		/// </summary>
		ADS_SECURITY_INFO_GROUP = 0x2,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x4</para>
		/// <para>Reads or sets the discretionary access-control list data.</para>
		/// </summary>
		ADS_SECURITY_INFO_DACL = 0x4,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x8</para>
		/// <para>Reads or sets the system access-control list data.</para>
		/// </summary>
		ADS_SECURITY_INFO_SACL = 0x8,
	}

	/// <summary>Values for <see cref="IADsService.ErrorControl"/>.</summary>
	public enum ADS_SERVICE_ERR
	{
		/// <summary>The startup program logs the error, but continues the startup operation.</summary>
		ADS_SERVICE_ERROR_IGNORE = 0,

		/// <summary>The startup program logs the error and presents a message box, but continues the startup operation.</summary>
		ADS_SERVICE_ERROR_NORMAL = 1,

		/// <summary>
		/// The startup program logs the error. If the last-known-good configuration is started, the startup operation continues. Otherwise,
		/// the system is restarted with the last-known-good configuration.
		/// </summary>
		ADS_SERVICE_ERROR_SEVERE = 2,

		/// <summary>
		/// The startup program logs the error, if possible. If the last-known-good configuration is being started, the startup operation
		/// fails. Otherwise, the system is restarted with the last-known good configuration.
		/// </summary>
		ADS_SERVICE_ERROR_CRITICAL = 3
	}

	/// <summary>Values for <see cref="IADsService.StartType"/>.</summary>
	public enum ADS_SERVICE_START
	{
		/// <summary>The service is a device driver started by the system loader. This value is valid only for driver services.</summary>
		ADS_SERVICE_BOOT_START = 0,

		/// <summary>The service is a device driver started by the IoInitSystem function. This value is valid only for driver services.</summary>
		ADS_SERVICE_SYSTEM_START = 1,

		/// <summary>The service will be started automatically by the service control manager during system startup.</summary>
		ADS_SERVICE_AUTO_START = 2,

		/// <summary>The service will be started by the service control manager when a process calls the StartService function.</summary>
		ADS_SERVICE_DEMAND_START = 3,

		/// <summary>The service cannot be started. Attempts to start the service result in the error code ERROR_SERVICE_DISABLED.</summary>
		ADS_SERVICE_DISABLED = 4,
	}

	/// <summary>Values for <see cref="IADsServiceOperations.Status"/>.</summary>
	public enum ADS_SERVICE_STATUS
	{
		/// <summary/>
		ADS_SERVICE_STOPPED = 0x00000001,

		/// <summary/>
		ADS_SERVICE_START_PENDING = 0x00000002,

		/// <summary/>
		ADS_SERVICE_STOP_PENDING = 0x00000003,

		/// <summary/>
		ADS_SERVICE_RUNNING = 0x00000004,

		/// <summary/>
		ADS_SERVICE_CONTINUE_PENDING = 0x00000005,

		/// <summary/>
		ADS_SERVICE_PAUSE_PENDING = 0x00000006,

		/// <summary/>
		ADS_SERVICE_PAUSED = 0x00000007,

		/// <summary/>
		ADS_SERVICE_ERROR = 0x00000008,
	}

	/// <summary>Values for <see cref="IADsService.ServiceType"/>.</summary>
	[Flags]
	public enum ADS_SERVICE_TYPE : uint
	{
		/// <summary></summary>
		ADS_SERVICE_KERNEL_DRIVER = 0x00000001,

		/// <summary></summary>
		ADS_SERVICE_FILE_SYSTEM_DRIVER = 0x00000002,

		/// <summary></summary>
		ADS_SERVICE_OWN_PROCESS = 0x00000010,

		/// <summary></summary>
		ADS_SERVICE_SHARE_PROCESS = 0x00000020,
	}

	/// <summary>The <c>ADS_SETTYPE_ENUM</c> enumeration specifies the available pathname format used by the IADsPathname::Set method.</summary>
	/// <remarks>
	/// Since VBScript cannot read information from a type library, VBScript applications do not understand the symbolic constants as defined
	/// above. You should use the numerical constants instead to set the appropriate flags in your VBScript applications. If you want to use
	/// the symbolic constants as a good programming practice, you should make explicit declarations of such constants, as done here, in your
	/// VBScript applications.
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/iads/ne-iads-ads_settype_enum typedef enum __MIDL___MIDL_itf_ads_0001_0078_0001 {
	// ADS_SETTYPE_FULL = 1, ADS_SETTYPE_PROVIDER = 2, ADS_SETTYPE_SERVER = 3, ADS_SETTYPE_DN = 4 } ADS_SETTYPE_ENUM;
	[PInvokeData("iads.h", MSDNShortId = "NE:iads.__MIDL___MIDL_itf_ads_0001_0078_0001")]
	public enum ADS_SETTYPE
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>1</para>
		/// <para>Sets the full path, for example, "LDAP://servername/o=internet/…/cn=bar".</para>
		/// </summary>
		ADS_SETTYPE_FULL = 1,

		/// <summary>
		/// <para>Value:</para>
		/// <para>2</para>
		/// <para>Updates the provider only, for example, "LDAP".</para>
		/// </summary>
		ADS_SETTYPE_PROVIDER,

		/// <summary>
		/// <para>Value:</para>
		/// <para>3</para>
		/// <para>Updates the server name only, for example, "servername".</para>
		/// </summary>
		ADS_SETTYPE_SERVER,

		/// <summary>
		/// <para>Value:</para>
		/// <para>4</para>
		/// <para>Updates the distinguished name only, for example, "o=internet/…/cn=bar".</para>
		/// </summary>
		ADS_SETTYPE_DN,
	}

	/// <summary>
	/// The <c>ADS_STATUSENUM</c> enumeration specifies the status of a search preference set with the IDirectorySearch::SetSearchPreference method.
	/// </summary>
	/// <remarks>
	/// <para>
	/// The IDirectorySearch::SetSearchPreference method sets the <c>dwStatus</c> member ADS_SEARCHPREF_INFO structure to one of the
	/// <c>ADS_STATUSENUM</c> values to indicate the status of the corresponding search preference. Callers can use this status value to
	/// decide whether to execute a search.
	/// </para>
	/// <para>
	/// The <c>ADS_STATUS_INVALID_SEARCHPREF</c> status value may be set if you set a valid search preference, but that preference is not
	/// supported. For example, if you set <c>ADS_SEARCHPREF_SORT_ON</c>, but the server you communicate with does not support the LDAP
	/// server-side sort control, the <c>dwStatus</c> member of the ADS_SEARCHPREF_INFO structure is set to
	/// <c>ADS_STATUS_INVALID_SEARCHPREF</c> by the IDirectorySearch::SetSearchPreference call.
	/// </para>
	/// <para>
	/// <c>Note</c>  Because VBScript cannot read data from a type library, VBScript applications do not recognize the symbolic constants as
	/// defined above. You should use the numeric constants instead to set the appropriate flags in your VBScript applications. To use the
	/// symbolic constants as a good programming practice, write explicit declarations of such constants, as done in the following code example.
	/// </para>
	/// <para></para>
	/// <para>Examples</para>
	/// <para>
	/// The following code example shows how to use the <c>ADS_STATUSENUM</c> enumeration with the IDirectorySearch::SetSearchPreference
	/// method to determine the status of a search preference.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/iads/ne-iads-ads_statusenum typedef enum __MIDL___MIDL_itf_ads_0000_0000_0019 {
	// ADS_STATUS_S_OK = 0, ADS_STATUS_INVALID_SEARCHPREF, ADS_STATUS_INVALID_SEARCHPREFVALUE } ADS_STATUSENUM;
	[PInvokeData("iads.h", MSDNShortId = "NE:iads.__MIDL___MIDL_itf_ads_0000_0000_0019")]
	public enum ADS_STATUS
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0</para>
		/// <para>The search preference was set successfully.</para>
		/// </summary>
		ADS_STATUS_S_OK,

		/// <summary>
		/// <para>The search preference specified in the</para>
		/// <para>dwSearchPref</para>
		/// <para>member of the</para>
		/// <para>ADS_SEARCHPREF_INFO</para>
		/// <para>structure is invalid. Search preferences must be taken from the</para>
		/// <para>ADS_SEARCHPREF_ENUM</para>
		/// <para>enumeration.</para>
		/// </summary>
		ADS_STATUS_INVALID_SEARCHPREF,

		/// <summary>
		/// <para>The value specified in the</para>
		/// <para>vValue</para>
		/// <para>member of the</para>
		/// <para>ADS_SEARCHPREF_INFO</para>
		/// <para>structure is invalid for the corresponding search preference.</para>
		/// </summary>
		ADS_STATUS_INVALID_SEARCHPREFVALUE,
	}

	/// <summary>
	/// The <c>ADS_SYSTEMFLAG_ENUM</c> enumeration defines some of the values that can be assigned to the <c>systemFlags</c> attribute. Some
	/// of the values in the enumeration are specific to <c>attributeSchema</c> objects; other values can be set on objects of any class.
	/// </summary>
	/// <remarks>
	/// <para>
	/// For <c>classSchema</c> and <c>attributeSchema</c> objects, the 0x10 bit of the <c>systemFlags</c> attribute indicates an object that
	/// is part of the base schema included with Active Directory. This bit cannot be set on new <c>classSchema</c> and
	/// <c>attributeSchema</c> objects. The <c>ADS_SYSTEMFLAG_ENUM</c> enumeration does not include a constant for this bit.
	/// </para>
	/// <para>
	/// <c>Note</c>  Because VBScript cannot read data from a type library, VBScript applications do not recognize the symbolic constants as
	/// defined above. Use the numeric constants instead to set the appropriate flags in your VBScript applications. To use the symbolic
	/// constants as a good programming practice, you should make explicit declarations of such constants, as done here, in your VBScript applications.
	/// </para>
	/// <para></para>
	/// <para>Examples</para>
	/// <para>
	/// The following code example shows how elements of the <c>ADS_SYSTEMFLAG_ENUM</c> enumeration, together with the IDirectorySearch
	/// interface, are used to search non-replicated properties.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/iads/ne-iads-ads_systemflag_enum typedef enum __MIDL___MIDL_itf_ads_0001_0017_0001
	// { ADS_SYSTEMFLAG_DISALLOW_DELETE = 0x80000000, ADS_SYSTEMFLAG_CONFIG_ALLOW_RENAME = 0x40000000, ADS_SYSTEMFLAG_CONFIG_ALLOW_MOVE =
	// 0x20000000, ADS_SYSTEMFLAG_CONFIG_ALLOW_LIMITED_MOVE = 0x10000000, ADS_SYSTEMFLAG_DOMAIN_DISALLOW_RENAME = 0x8000000,
	// ADS_SYSTEMFLAG_DOMAIN_DISALLOW_MOVE = 0x4000000, ADS_SYSTEMFLAG_CR_NTDS_NC = 0x1, ADS_SYSTEMFLAG_CR_NTDS_DOMAIN = 0x2,
	// ADS_SYSTEMFLAG_ATTR_NOT_REPLICATED = 0x1, ADS_SYSTEMFLAG_ATTR_IS_CONSTRUCTED = 0x4 } ADS_SYSTEMFLAG_ENUM;
	[PInvokeData("iads.h", MSDNShortId = "NE:iads.__MIDL___MIDL_itf_ads_0001_0017_0001")]
	[Flags]
	public enum ADS_SYSTEMFLAG : uint
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0x80000000</para>
		/// <para>Identifies an object that cannot be deleted.</para>
		/// </summary>
		ADS_SYSTEMFLAG_DISALLOW_DELETE = 0x80000000,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x40000000</para>
		/// <para>
		/// For objects in the configuration partition, if this flag is set, the object can be renamed; otherwise, the object cannot be
		/// renamed. By default, this flag is not set on new objects created under the configuration partition, and you can set this flag
		/// only during object creation.
		/// </para>
		/// </summary>
		ADS_SYSTEMFLAG_CONFIG_ALLOW_RENAME = 0x40000000,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x20000000</para>
		/// <para>
		/// For objects in the configuration partition, if this flag is set, the object can be moved; otherwise, the object cannot be moved.
		/// By default, this flag is not set on new objects created under the configuration partition, and you can set this flag only during
		/// object creation.
		/// </para>
		/// </summary>
		ADS_SYSTEMFLAG_CONFIG_ALLOW_MOVE = 0x20000000,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x10000000</para>
		/// <para>
		/// For objects in the configuration partition, if this flag is set, the object can be moved with restrictions; otherwise, the object
		/// cannot be moved. By default, this flag is not set on new objects created under the configuration partition, and you can set this
		/// flag only during object creation.
		/// </para>
		/// </summary>
		ADS_SYSTEMFLAG_CONFIG_ALLOW_LIMITED_MOVE = 0x10000000,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x8000000</para>
		/// <para>Identifies a domain object that cannot be renamed.</para>
		/// </summary>
		ADS_SYSTEMFLAG_DOMAIN_DISALLOW_RENAME = 0x8000000,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x4000000</para>
		/// <para>Identifies a domain object that cannot be moved.</para>
		/// </summary>
		ADS_SYSTEMFLAG_DOMAIN_DISALLOW_MOVE = 0x4000000,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x1</para>
		/// <para>Naming context is in NTDS.</para>
		/// </summary>
		ADS_SYSTEMFLAG_CR_NTDS_NC = 0x1,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x2</para>
		/// <para>Naming context is a domain.</para>
		/// </summary>
		ADS_SYSTEMFLAG_CR_NTDS_DOMAIN = 0x2,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x1</para>
		/// <para>If this flag is set in the</para>
		/// <para>systemFlags</para>
		/// <para>attribute of an</para>
		/// <para>attributeSchema</para>
		/// <para>object, the attribute is not to be replicated.</para>
		/// </summary>
		ADS_SYSTEMFLAG_ATTR_NOT_REPLICATED = 0x1,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x4</para>
		/// <para>If this flag is set in the</para>
		/// <para>systemFlags</para>
		/// <para>attribute of an</para>
		/// <para>attributeSchema</para>
		/// <para>object, the attribute is a constructed property.</para>
		/// </summary>
		ADS_SYSTEMFLAG_ATTR_IS_CONSTRUCTED = 0x4,
	}

	/// <summary>
	/// The <c>ADS_USER_FLAG_ENUM</c> enumeration defines the flags used for setting user properties in the directory. These flags correspond
	/// to values of the <c>userAccountControl</c> attribute in Active Directory when using the LDAP provider, and the <c>userFlags</c>
	/// attribute when using the WinNT system provider.
	/// </summary>
	/// <remarks>
	/// <para>For more information, see Managing Users.</para>
	/// <para>
	/// For more information, and a code example that shows how to set the <c>ADS_UF_DONT_EXPIRE_PASSWD</c> value on a user
	/// <c>userAccountControl</c> attribute, see Password Never Expires.
	/// </para>
	/// <para>
	/// <c>Note</c>  Because VBScript cannot read data from a type library, VBScript applications do not understand the symbolic constants as
	/// defined above. Use the numerical constants, instead, to set the appropriate flags in your VBScript applications. To use the symbolic
	/// constants as a good programming practice, create explicit declarations of such constants, as done here, in your VBScript applications.
	/// </para>
	/// <para></para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/iads/ne-iads-ads_user_flag_enum typedef enum ADS_USER_FLAG { ADS_UF_SCRIPT = 0x1,
	// ADS_UF_ACCOUNTDISABLE = 0x2, ADS_UF_HOMEDIR_REQUIRED = 0x8, ADS_UF_LOCKOUT = 0x10, ADS_UF_PASSWD_NOTREQD = 0x20,
	// ADS_UF_PASSWD_CANT_CHANGE = 0x40, ADS_UF_ENCRYPTED_TEXT_PASSWORD_ALLOWED = 0x80, ADS_UF_TEMP_DUPLICATE_ACCOUNT = 0x100,
	// ADS_UF_NORMAL_ACCOUNT = 0x200, ADS_UF_INTERDOMAIN_TRUST_ACCOUNT = 0x800, ADS_UF_WORKSTATION_TRUST_ACCOUNT = 0x1000,
	// ADS_UF_SERVER_TRUST_ACCOUNT = 0x2000, ADS_UF_DONT_EXPIRE_PASSWD = 0x10000, ADS_UF_MNS_LOGON_ACCOUNT = 0x20000,
	// ADS_UF_SMARTCARD_REQUIRED = 0x40000, ADS_UF_TRUSTED_FOR_DELEGATION = 0x80000, ADS_UF_NOT_DELEGATED = 0x100000, ADS_UF_USE_DES_KEY_ONLY
	// = 0x200000, ADS_UF_DONT_REQUIRE_PREAUTH = 0x400000, ADS_UF_PASSWORD_EXPIRED = 0x800000, ADS_UF_TRUSTED_TO_AUTHENTICATE_FOR_DELEGATION
	// = 0x1000000 } ADS_USER_FLAG_ENUM;
	[PInvokeData("iads.h", MSDNShortId = "NE:iads.ADS_USER_FLAG")]
	[Flags]
	public enum ADS_USER_FLAG : uint
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0x1</para>
		/// <para>The logon script is executed. This flag does not work for the ADSI LDAP provider on either read or write</para>
		/// <para>operations. For the ADSI WinNT provider, this flag is read-only data, and it cannot be set for user</para>
		/// <para>objects.</para>
		/// </summary>
		ADS_UF_SCRIPT = 0x1,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x2</para>
		/// <para>The user account is disabled.</para>
		/// </summary>
		ADS_UF_ACCOUNTDISABLE = 0x2,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x8</para>
		/// <para>The home directory is required.</para>
		/// </summary>
		ADS_UF_HOMEDIR_REQUIRED = 0x8,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x10</para>
		/// <para>The account is currently locked out.</para>
		/// </summary>
		ADS_UF_LOCKOUT = 0x10,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x20</para>
		/// <para>No password is required.</para>
		/// </summary>
		ADS_UF_PASSWD_NOTREQD = 0x20,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x40</para>
		/// <para>The user cannot change the password. This flag can be read, but not set directly. For more information and</para>
		/// <para>a code example that shows how to prevent a user from changing the password, see</para>
		/// <para>User Cannot Change Password</para>
		/// <para>.</para>
		/// </summary>
		ADS_UF_PASSWD_CANT_CHANGE = 0x40,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x80</para>
		/// <para>The user can send an encrypted password.</para>
		/// </summary>
		ADS_UF_ENCRYPTED_TEXT_PASSWORD_ALLOWED = 0x80,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x100</para>
		/// <para>This is an account for users whose primary account is in another domain. This account provides user access</para>
		/// <para>to this domain, but not to any domain that trusts this domain. Also known as a local user account.</para>
		/// </summary>
		ADS_UF_TEMP_DUPLICATE_ACCOUNT = 0x100,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x200</para>
		/// <para>This is a default account type that represents a typical user.</para>
		/// </summary>
		ADS_UF_NORMAL_ACCOUNT = 0x200,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x800</para>
		/// <para>This is a permit to trust account for a system domain that trusts other domains.</para>
		/// </summary>
		ADS_UF_INTERDOMAIN_TRUST_ACCOUNT = 0x800,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x1000</para>
		/// <para>This is a computer account for a Windows or Windows Server that is a member of this domain.</para>
		/// </summary>
		ADS_UF_WORKSTATION_TRUST_ACCOUNT = 0x1000,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x2000</para>
		/// <para>This is a computer account for a system backup domain controller that is a member of this domain.</para>
		/// </summary>
		ADS_UF_SERVER_TRUST_ACCOUNT = 0x2000,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x10000</para>
		/// <para>When set, the password will not expire on this account.</para>
		/// </summary>
		ADS_UF_DONT_EXPIRE_PASSWD = 0x10000,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x20000</para>
		/// <para>This is an Majority Node Set (MNS) logon account. With MNS, you can configure a multi-node Windows cluster</para>
		/// <para>without using a common shared disk.</para>
		/// </summary>
		ADS_UF_MNS_LOGON_ACCOUNT = 0x20000,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x40000</para>
		/// <para>When set, this flag will force the user to log on using a smart card.</para>
		/// </summary>
		ADS_UF_SMARTCARD_REQUIRED = 0x40000,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x80000</para>
		/// <para>When set, the service account (user or computer account), under which a service runs, is trusted for</para>
		/// <para>Kerberos delegation. Any such service can impersonate a client requesting the service. To enable a service for</para>
		/// <para>Kerberos delegation, set this flag on the</para>
		/// <para>userAccountControl</para>
		/// <para>property of the</para>
		/// <para>service account.</para>
		/// </summary>
		ADS_UF_TRUSTED_FOR_DELEGATION = 0x80000,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x100000</para>
		/// <para>When set, the security context of the user will not be delegated to a service even if the service account</para>
		/// <para>is set as trusted for Kerberos delegation.</para>
		/// </summary>
		ADS_UF_NOT_DELEGATED = 0x100000,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x200000</para>
		/// <para>Restrict this principal to use only Data Encryption Standard (DES) encryption types for keys.</para>
		/// </summary>
		ADS_UF_USE_DES_KEY_ONLY = 0x200000,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x400000</para>
		/// <para>This account does not require Kerberos preauthentication for logon.</para>
		/// </summary>
		ADS_UF_DONT_REQUIRE_PREAUTH = 0x400000,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x800000</para>
		/// <para>The user password has expired. This flag is created by the system using data from the password last set</para>
		/// <para>attribute and the domain policy. It is read-only and cannot be set. To manually set a user password as expired,</para>
		/// <para>use the</para>
		/// <para>NetUserSetInfo</para>
		/// <para>function with the</para>
		/// <para>USER_INFO_3</para>
		/// <para>(</para>
		/// <para>usri3_password_expired</para>
		/// <para>member) or</para>
		/// <para>USER_INFO_4</para>
		/// <para>(</para>
		/// <para>usri4_password_expired</para>
		/// <para>member) structure.</para>
		/// </summary>
		ADS_UF_PASSWORD_EXPIRED = 0x800000,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x1000000</para>
		/// <para>The account is enabled for delegation. This is a security-sensitive setting; accounts with this option</para>
		/// <para>enabled should be strictly controlled. This setting enables a service running under the account to assume a</para>
		/// <para>client identity and authenticate as that user to other remote servers on the network.</para>
		/// </summary>
		ADS_UF_TRUSTED_TO_AUTHENTICATE_FOR_DELEGATION = 0x1000000,
	}

	/// <summary>The <c>ADSI_DIALECT_ENUM</c> enumeration specifies query dialects used in the OLE DB provider for ADSI.</summary>
	/// <remarks>
	/// <para>
	/// An ActiveX Data Object (ADO) client can use one of the two ADSI query dialects to query a directory. For more information about the
	/// ADSI query dialects, see Searching with ActiveX Data Objects.
	/// </para>
	/// <para>
	/// <c>Note</c>  Because Visual Basic Script (VBScript) cannot read data from a type library, VBScript applications do not recognize the
	/// symbolic constants as defined above. Use the numerical constants to set the appropriate flags in your VBScript applications. To use
	/// the symbolic constants as a good programming practice, write explicit declarations of such constants, as done here.
	/// </para>
	/// <para></para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/iads/ne-iads-adsi_dialect_enum typedef enum __MIDL___MIDL_itf_ads_0000_0000_0023 {
	// ADSI_DIALECT_LDAP = 0, ADSI_DIALECT_SQL = 0x1 } ADSI_DIALECT_ENUM;
	[PInvokeData("iads.h", MSDNShortId = "NE:iads.__MIDL___MIDL_itf_ads_0000_0000_0023")]
	public enum ADSI_DIALECT
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0</para>
		/// <para>ADSI queries are based on the LDAP dialect.</para>
		/// </summary>
		ADSI_DIALECT_LDAP,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x1</para>
		/// <para>ADSI queries are based on the SQL dialect.</para>
		/// </summary>
		ADSI_DIALECT_SQL,
	}

	/// <summary>The <c>ADSTYPEENUM</c> enumeration is used to identify the data type of an ADSI property value.</summary>
	/// <remarks>
	/// <para>
	/// When extending the active directory schema to add ADS_DN_WITH_BINARY, you must also specify the "otherWellKnownGuid" attribute
	/// definition. Add the following to the ldf file attribute definition: "omObjectClass:: KoZIhvcUAQEBCw=="
	/// </para>
	/// <para>
	/// When extending the active directory schema to add ADS_DN_WITH_STRING, you must also specify the "otherWellKnownGuid" attribute
	/// definition. Add the following to the ldf file attribute definition: "omObjectClass:: KoZIhvcUAQEBDA=="
	/// </para>
	/// <para>
	/// Because VBScript cannot read data from a type library, VBScript applications do not recognize symbolic constants, as defined above.
	/// Use the numerical constants instead to set the appropriate flags in your VBScript application. To use the symbolic constants as a
	/// good programming practice, write explicit declarations of such constants, as done here, in your VBScript application.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/iads/ne-iads-adstypeenum typedef enum __MIDL___MIDL_itf_ads_0000_0000_0001 {
	// ADSTYPE_INVALID = 0, ADSTYPE_DN_STRING, ADSTYPE_CASE_EXACT_STRING, ADSTYPE_CASE_IGNORE_STRING, ADSTYPE_PRINTABLE_STRING,
	// ADSTYPE_NUMERIC_STRING, ADSTYPE_BOOLEAN, ADSTYPE_INTEGER, ADSTYPE_OCTET_STRING, ADSTYPE_UTC_TIME, ADSTYPE_LARGE_INTEGER,
	// ADSTYPE_PROV_SPECIFIC, ADSTYPE_OBJECT_CLASS, ADSTYPE_CASEIGNORE_LIST, ADSTYPE_OCTET_LIST, ADSTYPE_PATH, ADSTYPE_POSTALADDRESS,
	// ADSTYPE_TIMESTAMP, ADSTYPE_BACKLINK, ADSTYPE_TYPEDNAME, ADSTYPE_HOLD, ADSTYPE_NETADDRESS, ADSTYPE_REPLICAPOINTER, ADSTYPE_FAXNUMBER,
	// ADSTYPE_EMAIL, ADSTYPE_NT_SECURITY_DESCRIPTOR, ADSTYPE_UNKNOWN, ADSTYPE_DN_WITH_BINARY, ADSTYPE_DN_WITH_STRING } ADSTYPEENUM;
	[PInvokeData("iads.h", MSDNShortId = "NE:iads.__MIDL___MIDL_itf_ads_0000_0000_0001")]
	public enum ADSTYPE
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0</para>
		/// <para>The data type is not valid</para>
		/// </summary>
		ADSTYPE_INVALID,

		/// <summary>The string is of Distinguished Name (path) of a directory service object.</summary>
		ADSTYPE_DN_STRING,

		/// <summary>The string is of the case-sensitive type.</summary>
		ADSTYPE_CASE_EXACT_STRING,

		/// <summary>The string is of the case-insensitive type.</summary>
		ADSTYPE_CASE_IGNORE_STRING,

		/// <summary>The string is displayable on screen or in print.</summary>
		ADSTYPE_PRINTABLE_STRING,

		/// <summary>The string is of a numeral to be interpreted as text.</summary>
		ADSTYPE_NUMERIC_STRING,

		/// <summary>The data is of a Boolean value.</summary>
		ADSTYPE_BOOLEAN,

		/// <summary>The data is of an integer value.</summary>
		ADSTYPE_INTEGER,

		/// <summary>The string is of a byte array.</summary>
		ADSTYPE_OCTET_STRING,

		/// <summary>The data is of the universal time as expressed in Universal Time Coordinate (UTC).</summary>
		ADSTYPE_UTC_TIME,

		/// <summary>The data is of a long integer value.</summary>
		ADSTYPE_LARGE_INTEGER,

		/// <summary>The string is of a provider-specific string.</summary>
		ADSTYPE_PROV_SPECIFIC,

		/// <summary>Not used.</summary>
		ADSTYPE_OBJECT_CLASS,

		/// <summary>The data is of a list of case insensitive strings.</summary>
		ADSTYPE_CASEIGNORE_LIST,

		/// <summary>The data is of a list of octet strings.</summary>
		ADSTYPE_OCTET_LIST,

		/// <summary>The string is of a directory path.</summary>
		ADSTYPE_PATH,

		/// <summary>The string is of the postal address type.</summary>
		ADSTYPE_POSTALADDRESS,

		/// <summary>The data is of a time stamp in seconds.</summary>
		ADSTYPE_TIMESTAMP,

		/// <summary>The string is of a back link.</summary>
		ADSTYPE_BACKLINK,

		/// <summary>The string is of a typed name.</summary>
		ADSTYPE_TYPEDNAME,

		/// <summary>The data is of the Hold data structure.</summary>
		ADSTYPE_HOLD,

		/// <summary>The string is of a net address.</summary>
		ADSTYPE_NETADDRESS,

		/// <summary>The data is of a replica pointer.</summary>
		ADSTYPE_REPLICAPOINTER,

		/// <summary>The string is of a fax number.</summary>
		ADSTYPE_FAXNUMBER,

		/// <summary>The data is of an email message.</summary>
		ADSTYPE_EMAIL,

		/// <summary>The data is a Windows security descriptor as represented by a byte array.</summary>
		ADSTYPE_NT_SECURITY_DESCRIPTOR,

		/// <summary>The data is of an undefined type.</summary>
		ADSTYPE_UNKNOWN,

		/// <summary>
		/// <para>The data is of</para>
		/// <para>ADS_DN_WITH_BINARY</para>
		/// <para>used for mapping a distinguished name to a nonvarying GUID. For more information, see Remarks.</para>
		/// </summary>
		ADSTYPE_DN_WITH_BINARY,

		/// <summary>
		/// <para>The data is of</para>
		/// <para>ADS_DN_WITH_STRING</para>
		/// <para>used for mapping a distinguished name to a nonvarying string value. For more information, see Remarks.</para>
		/// </summary>
		ADSTYPE_DN_WITH_STRING,
	}

	/// <summary>Values for <see cref="IADsDomain.PasswordAttributes"/>.</summary>
	public enum PASSWORD_ATTR
	{
		/// <summary>No password restrictions.</summary>
		PASSWORD_ATTR_NONE = 0x00000000,

		/// <summary>The password must have mixed case letters.</summary>
		PASSWORD_ATTR_MIXED_CASE = 0x00000001,

		/// <summary>The password must include at least one punctuation mark or non-printable character.</summary>
		PASSWORD_ATTR_COMPLEX = 0x00000002,
	}
}