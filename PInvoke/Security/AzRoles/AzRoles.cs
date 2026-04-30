#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
using System.Collections;

namespace Vanara.PInvoke;

/// <summary>Contains the <see cref="IAzApplication"/>, <see cref="IAzApplication2"/>, and <see cref="IAzApplication3"/> interfaces.</summary>
public static partial class AzRoles
{
	/// <summary>Specifies the type of group used in Authorization Manager (AzMan) operations.</summary>
	[PInvokeData("azroles.h", MSDNShortId = "https://learn.microsoft.com/en-us/windows/win32/api/azroles/ne-azroles-az_prop_constants")]
	public enum AZ_GROUPTYPE
	{
		AZ_GROUPTYPE_LDAP_QUERY = 1,
		AZ_GROUPTYPE_BASIC = 2,
		AZ_GROUPTYPE_BIZRULE = 3,
	}

	/// <summary>
	/// The AZ_PROP_CONSTANTS enumeration defines constants used by Authorization Manager. For information about Authorization Manager, see
	/// Role-based Access Control.
	/// </summary>
	[PInvokeData("azroles.h", MSDNShortId = "https://learn.microsoft.com/en-us/windows/win32/api/azroles/ne-azroles-az_prop_constants")]
	public enum AZ_PROP_CONSTANTS
	{
		AZ_AZSTORE_DEFAULT_DOMAIN_TIMEOUT = 15000,
		AZ_AZSTORE_DEFAULT_MAX_SCRIPT_ENGINES = 120,
		AZ_AZSTORE_DEFAULT_SCRIPT_ENGINE_TIMEOUT = 45000,
		AZ_AZSTORE_FLAG_AUDIT_IS_CRITICAL = 8,
		AZ_AZSTORE_FLAG_BATCH_UPDATE = 4,
		AZ_AZSTORE_FLAG_CREATE = 1,
		AZ_AZSTORE_FLAG_MANAGE_ONLY_PASSIVE_SUBMIT = 32768,
		AZ_AZSTORE_FLAG_MANAGE_STORE_ONLY = 2,
		AZ_AZSTORE_FORCE_APPLICATION_CLOSE = 16,
		AZ_AZSTORE_MIN_DOMAIN_TIMEOUT = 500,
		AZ_AZSTORE_MIN_SCRIPT_ENGINE_TIMEOUT = 5000,
		AZ_AZSTORE_NT6_FUNCTION_LEVEL = 32,
		AZ_CLIENT_CONTEXT_GET_GROUP_RECURSIVE = 2,
		AZ_CLIENT_CONTEXT_GET_GROUPS_STORE_LEVEL_ONLY = 2,
		AZ_CLIENT_CONTEXT_SKIP_GROUP = 1,
		AZ_CLIENT_CONTEXT_SKIP_LDAP_QUERY = 1,
		AZ_MAX_APPLICATION_DATA_LENGTH = 4096,
		AZ_MAX_APPLICATION_NAME_LENGTH = 512,
		AZ_MAX_APPLICATION_VERSION_LENGTH = 512,
		AZ_MAX_BIZRULE_STRING = 65536,
		AZ_MAX_DESCRIPTION_LENGTH = 1024,
		AZ_MAX_GROUP_BIZRULE_IMPORTED_PATH_LENGTH = 512,
		AZ_MAX_GROUP_BIZRULE_LANGUAGE_LENGTH = 64,
		AZ_MAX_GROUP_BIZRULE_LENGTH = 65536,
		AZ_MAX_GROUP_LDAP_QUERY_LENGTH = 4096,
		AZ_MAX_GROUP_NAME_LENGTH = 64,
		AZ_MAX_NAME_LENGTH = 65536,
		AZ_MAX_OPERATION_NAME_LENGTH = 64,
		AZ_MAX_POLICY_URL_LENGTH = 65536,
		AZ_MAX_ROLE_NAME_LENGTH = 64,
		AZ_MAX_SCOPE_NAME_LENGTH = 65536,
		AZ_MAX_TASK_BIZRULE_IMPORTED_PATH_LENGTH = 512,
		AZ_MAX_TASK_BIZRULE_LANGUAGE_LENGTH = 64,
		AZ_MAX_TASK_BIZRULE_LENGTH = 65536,
		AZ_MAX_TASK_NAME_LENGTH = 64,

		[CorrespondingType(typeof(string), CorrespondingAction.GetSet)]
		AZ_PROP_APPLICATION_AUTHZ_INTERFACE_CLSID = 800,

		AZ_PROP_APPLICATION_BIZRULE_ENABLED = 803,

		[CorrespondingType(typeof(string), CorrespondingAction.GetSet)]
		AZ_PROP_APPLICATION_DATA = 4,

		AZ_PROP_APPLICATION_NAME = 802,

		[CorrespondingType(typeof(string), CorrespondingAction.GetSet)]
		AZ_PROP_APPLICATION_VERSION = 801,

		[CorrespondingType(typeof(string), CorrespondingAction.GetSet)]
		AZ_PROP_APPLY_STORE_SACL = 900,

		AZ_PROP_AZSTORE_DOMAIN_TIMEOUT = 100,
		AZ_PROP_AZSTORE_MAJOR_VERSION = 103,
		AZ_PROP_AZSTORE_MAX_SCRIPT_ENGINES = 102,
		AZ_PROP_AZSTORE_MINOR_VERSION = 104,
		AZ_PROP_AZSTORE_SCRIPT_ENGINE_TIMEOUT = 101,
		AZ_PROP_AZSTORE_TARGET_MACHINE = 105,
		AZ_PROP_AZTORE_IS_ADAM_INSTANCE = 106,

		[CorrespondingType(typeof(bool), CorrespondingAction.Get)]
		AZ_PROP_CHILD_CREATE = 5,

		AZ_PROP_CLIENT_CONTEXT_LDAP_QUERY_DN = 709,
		AZ_PROP_CLIENT_CONTEXT_ROLE_FOR_ACCESS_CHECK = 708,
		AZ_PROP_CLIENT_CONTEXT_USER_CANONICAL = 704,
		AZ_PROP_CLIENT_CONTEXT_USER_DISPLAY = 702,
		AZ_PROP_CLIENT_CONTEXT_USER_DN = 700,
		AZ_PROP_CLIENT_CONTEXT_USER_DNS_SAM_COMPAT = 707,
		AZ_PROP_CLIENT_CONTEXT_USER_GUID = 703,
		AZ_PROP_CLIENT_CONTEXT_USER_SAM_COMPAT = 701,
		AZ_PROP_CLIENT_CONTEXT_USER_UPN = 705,

		[CorrespondingType(typeof(string), CorrespondingAction.Get)]
		AZ_PROP_DELEGATED_POLICY_USERS = 904,

		[CorrespondingType(typeof(string), CorrespondingAction.Get)]
		AZ_PROP_DELEGATED_POLICY_USERS_NAME = 907,

		[CorrespondingType(typeof(string), CorrespondingAction.GetSet)]
		AZ_PROP_DESCRIPTION = 2,

		[CorrespondingType(typeof(string), CorrespondingAction.GetSet)]
		AZ_PROP_GENERATE_AUDITS = 901,

		AZ_PROP_GROUP_APP_MEMBERS = 401,
		AZ_PROP_GROUP_APP_NON_MEMBERS = 402,
		AZ_PROP_GROUP_BIZRULE = 408,
		AZ_PROP_GROUP_BIZRULE_IMPORTED_PATH = 410,
		AZ_PROP_GROUP_BIZRULE_LANGUAGE = 409,
		AZ_PROP_GROUP_LDAP_QUERY = 403,
		AZ_PROP_GROUP_MEMBERS = 404,
		AZ_PROP_GROUP_MEMBERS_NAME = 406,
		AZ_PROP_GROUP_NON_MEMBERS = 405,
		AZ_PROP_GROUP_NON_MEMBERS_NAME = 407,
		AZ_PROP_GROUP_TYPE = 400,

		[CorrespondingType(typeof(string), CorrespondingAction.GetSet)]
		AZ_PROP_NAME = 1,

		AZ_PROP_OPERATION_ID = 200,

		[CorrespondingType(typeof(string), CorrespondingAction.Get)]
		AZ_PROP_POLICY_ADMINS = 902,

		[CorrespondingType(typeof(string), CorrespondingAction.Get)]
		AZ_PROP_POLICY_ADMINS_NAME = 905,

		[CorrespondingType(typeof(string), CorrespondingAction.Get)]
		AZ_PROP_POLICY_READERS = 903,

		[CorrespondingType(typeof(string), CorrespondingAction.Get)]
		AZ_PROP_POLICY_READERS_NAME = 906,

		AZ_PROP_ROLE_APP_MEMBERS = 500,
		AZ_PROP_ROLE_MEMBERS = 501,
		AZ_PROP_ROLE_MEMBERS_NAME = 505,
		AZ_PROP_ROLE_OPERATIONS = 502,
		AZ_PROP_ROLE_TASKS = 504,
		AZ_PROP_SCOPE_BIZRULES_WRITABLE = 600,
		AZ_PROP_SCOPE_CAN_BE_DELEGATED = 601,
		AZ_PROP_TASK_BIZRULE = 301,
		AZ_PROP_TASK_BIZRULE_IMPORTED_PATH = 304,
		AZ_PROP_TASK_BIZRULE_LANGUAGE = 302,
		AZ_PROP_TASK_IS_ROLE_DEFINITION = 305,
		AZ_PROP_TASK_OPERATIONS = 300,
		AZ_PROP_TASK_TASKS = 303,

		[CorrespondingType(typeof(string), CorrespondingAction.Get)]
		AZ_PROP_WRITABLE = 3,
	}

	/// <summary>Specifies flags that control the behavior of a submit operation in the authorization framework.</summary>
	/// <remarks>
	/// This enumeration supports bitwise combination of its member values. Use these flags to indicate whether to abort or flush changes
	/// during a submit operation.
	/// </remarks>
	[Flags]
	public enum AZ_SUBMIT_FLAGS
	{
		/// <summary>Indicates that the changes to the object are discarded and the object is updated to match the underlying policy store.</summary>
		AZ_SUBMIT_FLAG_ABORT = 1,

		/// <summary>
		/// Force a flush of cached authorization data or pending changes to the policy store (e.g., Active Directory or XML files) upon submission.
		/// </summary>
		AZ_SUBMIT_FLAG_FLUSH = 2,
	}

	/// <summary>
	/// The <b>Microsoft.Interop.Security.Azroles.IAzApplication</b> interoperability wrapper methods and properties are documented under the
	/// COM version of the method or property. A link to the correlating COM documentation follows each member name.
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/secauthz/microsoft-interop-security-azroles-iazapplication-interface
	[PInvokeData("azroles.h")]
	[ComImport, Guid("987BC7C7-B813-4D27-BEDE-6BA5AE867E95")]
	public interface IAzApplication
	{
		/// <summary>
		/// <para>The <b>Name</b> property sets or retrieves the name of the application.</para>
		/// <para>This property is read/write.</para>
		/// </summary>
		/// <remarks>The maximum length of the <b>Name</b> property is 512 characters.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazapplication-get_name HRESULT get_Name( BSTR *pbstrName );
		[DispId(1610743808)]
		string Name
		{
			[DispId(1610743808)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
			[DispId(1610743808)]
			[param: In]
			[param: MarshalAs(UnmanagedType.BStr)]
			set;
		}

		/// <summary>
		/// <para>The <b>Description</b> property sets or retrieves a comment that describes the application.</para>
		/// <para>This property is read/write.</para>
		/// </summary>
		/// <remarks>The maximum length of the <b>Description</b> property is 1,024 characters.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazapplication-put_description HRESULT put_Description(
		// BSTR bstrDescription );
		[DispId(1610743810)]
		string Description
		{
			[DispId(1610743810)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
			[DispId(1610743810)]
			[param: In]
			[param: MarshalAs(UnmanagedType.BStr)]
			set;
		}

		/// <summary>
		/// <para>The <b>ApplicationData</b> property sets or retrieves an opaque field that can be used by the application to store information.</para>
		/// <para>This property is read/write.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// <b>Important</b>  Policy administrators can read from and write to this property. Applications should not store data in the
		/// <b>ApplicationData</b> property that should not be available to the policy administrator.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazapplication-get_applicationdata HRESULT
		// get_ApplicationData( BSTR *pbstrApplicationData );
		[DispId(1610743812)]
		string ApplicationData
		{
			[DispId(1610743812)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
			[DispId(1610743812)]
			[param: In]
			[param: MarshalAs(UnmanagedType.BStr)]
			set;
		}

		/// <summary>
		/// <para>
		/// The <b>AuthzInterfaceClsid</b> property sets or retrieves the class identifier (CLSID) of the interface that the user interface
		/// (UI) uses to perform application-specific operations.
		/// </para>
		/// <para>This property is read/write.</para>
		/// </summary>
		/// <remarks>A CLSID is a GUID associated with a COM class.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazapplication-get_authzinterfaceclsid HRESULT
		// get_AuthzInterfaceClsid( BSTR *pbstrProp );
		[DispId(1610743814)]
		string AuthzInterfaceClsid
		{
			[DispId(1610743814)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
			[DispId(1610743814)]
			[param: In]
			[param: MarshalAs(UnmanagedType.BStr)]
			set;
		}

		/// <summary>
		/// <para>The <b>Version</b> property sets or retrieves the version of the application.</para>
		/// <para>This property is read/write.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazapplication-get_version HRESULT get_Version( BSTR
		// *pbstrProp );
		[DispId(1610743816)]
		string Version
		{
			[DispId(1610743816)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
			[DispId(1610743816)]
			[param: In]
			[param: MarshalAs(UnmanagedType.BStr)]
			set;
		}

		/// <summary>
		/// <para>The <b>GenerateAudits</b> property sets or retrieves a value that indicates whether run-time audits should be generated.</para>
		/// <para>This property is read/write.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// The <b>GenerateAudits</b> property controls client context creation, client context deletion, and access check run-time auditing.
		/// The client context can be created by a <c>security identifier</c> (SID), name, or token.
		/// </para>
		/// <para>The <c>AzAuthorizationStore.GenerateAudits</c> property controls application initialization auditing.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazapplication-get_generateaudits HRESULT
		// get_GenerateAudits( BOOL *pbProp );
		[DispId(1610743818)]
		bool GenerateAudits
		{
			[DispId(1610743818)]
			[return: MarshalAs(UnmanagedType.Bool)]
			get;
			[DispId(1610743818)]
			[param: In, MarshalAs(UnmanagedType.Bool)]
			set;
		}

		/// <summary>
		/// <para>
		/// The <b>ApplyStoreSacl</b> property sets or retrieves a value that indicates whether policy audits should be generated when the
		/// authorization store is modified.
		/// </para>
		/// <para>This property is read/write.</para>
		/// </summary>
		/// <remarks>
		/// <para>Policy audits are generated when the underlying policy store is modified. Both success and failure audits are requested.</para>
		/// <para>This property controls policy auditing only for the <c>IAzApplication</c> object and its child objects.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazapplication-get_applystoresacl HRESULT
		// get_ApplyStoreSacl( BOOL *pbProp );
		[DispId(1610743820)]
		bool ApplyStoreSacl
		{
			[DispId(1610743820)]
			[return: MarshalAs(UnmanagedType.Bool)]
			get;
			[DispId(1610743820)]
			[param: In, MarshalAs(UnmanagedType.Bool)]
			set;
		}

		/// <summary>
		/// <para>
		/// The <b>Writable</b> property retrieves a value that indicates whether the object can be modified by the user context that
		/// initialized it.
		/// </para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazapplication-get_writable HRESULT get_Writable( BOOL
		// *pfProp );
		[DispId(1610743822)]
		bool Writable
		{
			[DispId(1610743822)]
			[return: MarshalAs(UnmanagedType.Bool)]
			get;
		}

		/// <summary>The <b>GetProperty</b> method returns the <c>IAzApplication</c> object property with the specified property ID.</summary>
		/// <param name="lPropId">
		/// <para>Property ID of the <c>IAzApplication</c> object property to return. The following table shows the possible values.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Value</description>
		/// <description>Meaning</description>
		/// </listheader>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_APPLICATION_AUTHZ_INTERFACE_CLSID</b></description>
		/// <description>Also accessed through the <c>AuthzInterfaceClsid</c> property</description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_APPLICATION_DATA</b></description>
		/// <description>Also accessed through the <c>ApplicationData</c> property</description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_APPLICATION_VERSION</b></description>
		/// <description>Also accessed through the <c>Version</c> property</description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_APPLY_STORE_SACL</b></description>
		/// <description>Also accessed through the <c>ApplyStoreSacl</c> property</description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_CHILD_CREATE</b></description>
		/// <description>
		/// Determines whether the current user has permission to create child objects. This value is <b>TRUE</b> if the current user has
		/// permission; otherwise, <b>FALSE</b>.
		/// </description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_DELEGATED_POLICY_USERS</b></description>
		/// <description>Also accessed through the <c>DelegatedPolicyUsers</c> property</description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_DELEGATED_POLICY_USERS_NAME</b></description>
		/// <description>Also accessed through the <c>DelegatedPolicyUsersName</c> property</description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_DESCRIPTION</b></description>
		/// <description>Also accessed through the <c>Description</c> property</description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_GENERATE_AUDITS</b></description>
		/// <description>Also accessed through the <c>GenerateAudits</c> property</description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_NAME</b></description>
		/// <description>Also accessed through the <c>Name</c> property</description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_POLICY_ADMINS</b></description>
		/// <description>Also accessed through the <c>PolicyAdministrators</c> property</description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_POLICY_ADMINS_NAME</b></description>
		/// <description>Also accessed through the <c>PolicyAdministratorsName</c> property</description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_POLICY_READERS</b></description>
		/// <description>Also accessed through the <c>PolicyReaders</c> property</description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_POLICY_READERS_NAME</b></description>
		/// <description>Also accessed through the <c>PolicyReadersName</c> property</description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_WRITABLE</b></description>
		/// <description>Also accessed through the <c>Writable</c> property</description>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="varReserved">Reserved for future use.</param>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazapplication-getproperty HRESULT GetProperty( [in] LONG
		// lPropId, [in, optional] VARIANT varReserved, [out] VARIANT *pvarProp );
		[DispId(1610743823)]
		[return: MarshalAs(UnmanagedType.Struct)]
		object GetProperty([In] AZ_PROP_CONSTANTS lPropId, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>
		/// The <b>SetProperty</b> method sets the specified value to the <c>IAzApplication</c> object property with the specified property ID.
		/// </summary>
		/// <param name="lPropId">
		/// <para>Property ID of the <c>IAzApplication</c> object property to set. The following table shows the possible values.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Value</description>
		/// <description>Meaning</description>
		/// </listheader>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_APPLICATION_DATA</b></description>
		/// <description>Also accessed through the <c>ApplicationData</c> property</description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_APPLICATION_AUTHZ_INTERFACE_CLSID</b></description>
		/// <description>Also accessed through the <c>AuthzInterfaceClsid</c> property</description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_APPLICATION_VERSION</b></description>
		/// <description>Also accessed through the <c>Version</c> property</description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_APPLY_STORE_SACL</b></description>
		/// <description>Also accessed through the <c>ApplyStoreSacl</c> property</description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_DESCRIPTION</b></description>
		/// <description>Also accessed through the <c>Description</c> property</description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_GENERATE_AUDITS</b></description>
		/// <description>Also accessed through the <c>GenerateAudits</c> property</description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_NAME</b></description>
		/// <description>Also accessed through the <c>Name</c> property</description>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="varProp">
		/// <para>
		/// Value to set to the <c>IAzApplication</c> object property specified by the <i>lPropId</i> parameter. The type of data that must
		/// be used depends on the value of the <i>lPropId</i> parameter.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <description><i>lPropId</i> value</description>
		/// <description>Data type (C++/Visual Basic)</description>
		/// </listheader>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_APPLICATION_DATA</b></description>
		/// <description><b>BSTR</b>/ <b>String</b></description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_APPLICATION_INTERFACE_CLSID</b></description>
		/// <description><b>BSTR</b>/ <b>String</b></description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_APPLICATION_VERSION</b></description>
		/// <description><b>BSTR</b>/ <b>String</b></description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_APPLY_STORE_SACL</b></description>
		/// <description><b>BSTR</b>/ <b>String</b></description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_DESCRIPTION</b></description>
		/// <description><b>BSTR</b>/ <b>String</b></description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_GENERATE_AUDITS</b></description>
		/// <description><b>BSTR</b>/ <b>String</b></description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_NAME</b></description>
		/// <description><b>BSTR</b>/ <b>String</b></description>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="varReserved">Reserved for future use.</param>
		/// <remarks>You must call the <c>Submit</c> method to persist any changes made by this method.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazapplication-setproperty HRESULT SetProperty( [in] LONG
		// lPropId, [in] VARIANT varProp, [in, optional] VARIANT varReserved );
		[DispId(1610743824)]
		void SetProperty([In] AZ_PROP_CONSTANTS lPropId, [In, MarshalAs(UnmanagedType.Struct)] object varProp, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>
		/// <para>
		/// The <b>PolicyAdministrators</b> property retrieves the <c>security identifiers</c> (SIDs) of principals that act as policy
		/// administrators in text form.
		/// </para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <remarks>
		/// <para>Policy administrators for an object can perform the following tasks:</para>
		/// <list type="bullet">
		/// <item>
		/// <description>Read the object</description>
		/// </item>
		/// <item>
		/// <description>Write attributes to the object</description>
		/// </item>
		/// <item>
		/// <description>Read attributes of child objects of the object</description>
		/// </item>
		/// <item>
		/// <description>Write attributes to child objects of the object</description>
		/// </item>
		/// <item>
		/// <description>Delete the object</description>
		/// </item>
		/// <item>
		/// <description>Delete child objects of the object</description>
		/// </item>
		/// <item>
		/// <description>Create child objects of the object</description>
		/// </item>
		/// </list>
		/// <para>In JScript, the returned <c>SAFEARRAY</c> must be converted to the JScript <c>Array</c> object.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazauthorizationstore-get_policyadministrators HRESULT
		// get_PolicyAdministrators( VARIANT *pvarAdmins );
		[DispId(1610743825)]
		object PolicyAdministrators
		{
			[DispId(1610743825)]
			[return: MarshalAs(UnmanagedType.Struct)]
			get;
		}

		/// <summary>
		/// <para>
		/// The <b>PolicyReaders</b> property retrieves the <c>security identifiers</c> (SIDs) of principals that act as policy readers in
		/// text form.
		/// </para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// Policy readers for an object can read attributes for the object and for child objects of the object. Readers can also use the
		/// policy; for example, readers can call the <c>AccessCheck</c> method. Readers cannot modify the object or its child objects.
		/// </para>
		/// <para>In JScript, the returned <c>SAFEARRAY</c> must be converted to the JScript <c>Array</c> object.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazauthorizationstore-get_policyreaders HRESULT
		// get_PolicyReaders( VARIANT *pvarReaders );
		[DispId(1610743826)]
		object PolicyReaders
		{
			[DispId(1610743826)]
			[return: MarshalAs(UnmanagedType.Struct)]
			get;
		}

		/// <summary>
		/// The <b>AddPolicyAdministrator</b> method adds the specified <c>security identifier</c> (SID) in text form to the list of
		/// principals that act as policy administrators.
		/// </summary>
		/// <param name="bstrAdmin">Text form of the SID to add to the list of policy administrators.</param>
		/// <param name="varReserved">Reserved for future use.</param>
		/// <remarks>
		/// <para>Policy administrators for an object can perform the following tasks:</para>
		/// <list type="bullet">
		/// <item>
		/// <description>Read the object</description>
		/// </item>
		/// <item>
		/// <description>Write attributes to the object</description>
		/// </item>
		/// <item>
		/// <description>Read attributes of child objects of the object</description>
		/// </item>
		/// <item>
		/// <description>Write attributes to child objects of the object</description>
		/// </item>
		/// <item>
		/// <description>Delete the object</description>
		/// </item>
		/// <item>
		/// <description>Delete child objects of the object</description>
		/// </item>
		/// <item>
		/// <description>Create child objects of the object</description>
		/// </item>
		/// </list>
		/// <para>To view the list of policy administrators, use the <c>PolicyAdministrators</c> property.</para>
		/// <para>You must call the <c>Submit</c> method to persist any changes made by this method.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazapplication-addpolicyadministrator HRESULT
		// AddPolicyAdministrator( [in] BSTR bstrAdmin, [in, optional] VARIANT varReserved );
		[DispId(1610743827)]
		void AddPolicyAdministrator([In, MarshalAs(UnmanagedType.BStr)] string bstrAdmin, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>
		/// The <b>DeletePolicyAdministrator</b> method removes the specified <c>security identifier</c> (SID) in text form from the list of
		/// principals that act as policy administrators.
		/// </summary>
		/// <param name="bstrAdmin">Text form of the SID to remove from the list of policy administrators.</param>
		/// <param name="varReserved">Reserved for future use.</param>
		/// <remarks>
		/// <para>Policy administrators for an object can perform the following tasks:</para>
		/// <list type="bullet">
		/// <item>
		/// <description>Read the object</description>
		/// </item>
		/// <item>
		/// <description>Write attributes to the object</description>
		/// </item>
		/// <item>
		/// <description>Read attributes of child objects of the object</description>
		/// </item>
		/// <item>
		/// <description>Write attributes to child objects of the object</description>
		/// </item>
		/// <item>
		/// <description>Delete the object</description>
		/// </item>
		/// <item>
		/// <description>Delete child objects of the object</description>
		/// </item>
		/// <item>
		/// <description>Create child objects of the object</description>
		/// </item>
		/// </list>
		/// <para>To view the list of policy administrators, use the <c>PolicyAdministrators</c> property.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazapplication-deletepolicyadministrator HRESULT
		// DeletePolicyAdministrator( [in] BSTR bstrAdmin, [in, optional] VARIANT varReserved );
		[DispId(1610743828)]
		void DeletePolicyAdministrator([In, MarshalAs(UnmanagedType.BStr)] string bstrAdmin, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>
		/// The <b>AddPolicyReader</b> method adds the specified <c>security identifier</c> (SID) in text form to the list of principals that
		/// act as policy readers.
		/// </summary>
		/// <param name="bstrReader">Text form of the SID to add to the list of policy readers.</param>
		/// <param name="varReserved">Reserved for future use.</param>
		/// <remarks>
		/// <para>
		/// Policy readers for an object can read attributes for the object and for child objects of the object. Readers can also use the
		/// policy; for example, readers can call the <c>AccessCheck</c> method. Readers cannot modify the object or its child objects.
		/// </para>
		/// <para>To view the list of policy readers, use the <c>PolicyReaders</c> property.</para>
		/// <para>You must call the <c>Submit</c> method to persist any changes made by this method.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazapplication-addpolicyreader HRESULT AddPolicyReader(
		// [in] BSTR bstrReader, [in, optional] VARIANT varReserved );
		[DispId(1610743829)]
		void AddPolicyReader([In, MarshalAs(UnmanagedType.BStr)] string bstrReader, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>
		/// The <b>DeletePolicyReader</b> method removes the specified <c>security identifier</c> (SID) in text form from the list of
		/// principals that act as policy readers.
		/// </summary>
		/// <param name="bstrReader">Text form of the SID to remove from the list of policy readers.</param>
		/// <param name="varReserved">Reserved for future use.</param>
		/// <remarks>
		/// <para>
		/// Policy readers for an object can read attributes for the object and for child objects of the object. Readers can also use the
		/// policy; for example, readers can call the <c>AccessCheck</c> method. Readers cannot modify the object or its child objects.
		/// </para>
		/// <para>To view the list of policy readers, use the <c>PolicyReaders</c> property.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazapplication-deletepolicyreader HRESULT
		// DeletePolicyReader( [in] BSTR bstrReader, [in, optional] VARIANT varReserved );
		[DispId(1610743830)]
		void DeletePolicyReader([In, MarshalAs(UnmanagedType.BStr)] string bstrReader, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>
		/// <para>
		/// The <b>Scopes</b> property retrieves an <c>IAzScopes</c> object that is used to enumerate <c>IAzScope</c> objects from the policy data.
		/// </para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <remarks>
		/// This property can be used only to enumerate <c>IAzScope</c> objects that are direct child objects of the <c>IAzApplication</c> object.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazapplication-get_scopes HRESULT get_Scopes( IAzScopes
		// **ppScopeCollection );
		[DispId(1610743831)]
		IAzScopes Scopes
		{
			[DispId(1610743831)]
			[return: MarshalAs(UnmanagedType.Interface)]
			get;
		}

		/// <summary>The <b>OpenScope</b> method opens an <c>IAzScope</c> object with the specified name.</summary>
		/// <param name="bstrScopeName">Name of the <c>IAzScope</c> object to open.</param>
		/// <param name="varReserved">Reserved for future use.</param>
		/// <returns>A pointer to a pointer to the opened <c>IAzScope</c> object.</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazapplication-openscope HRESULT OpenScope( [in] BSTR
		// bstrScopeName, [in, optional] VARIANT varReserved, [out] IAzScope **ppScope );
		[DispId(1610743832)]
		[return: MarshalAs(UnmanagedType.Interface)]
		IAzScope OpenScope([In, MarshalAs(UnmanagedType.BStr)] string bstrScopeName, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>The <b>CreateScope</b> method creates an <c>IAzScope</c> object with the specified name.</summary>
		/// <param name="bstrScopeName">Name for the new <c>IAzScope</c> object.</param>
		/// <param name="varReserved">Reserved for future use.</param>
		/// <returns>A pointer to a pointer to the created <c>IAzScope</c> object.</returns>
		/// <remarks>
		/// <para>You must call the <c>IAzScope::Submit</c> method to persist any changes made to the returned object.</para>
		/// <para>The returned <c>IAzScope</c> object is an immediate child object of the <c>IAzApplication</c> object.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazapplication-createscope HRESULT CreateScope( [in] BSTR
		// bstrScopeName, [in, optional] VARIANT varReserved, [out] IAzScope **ppScope );
		[DispId(1610743833)]
		[return: MarshalAs(UnmanagedType.Interface)]
		IAzScope CreateScope([In, MarshalAs(UnmanagedType.BStr)] string bstrScopeName, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>
		/// The <b>DeleteScope</b> method removes the <c>IAzScope</c> object with the specified name from the <c>IAzApplication</c> object.
		/// </summary>
		/// <param name="bstrScopeName">Name of the <c>IAzScope</c> object to delete.</param>
		/// <param name="varReserved">Reserved for future use.</param>
		/// <remarks>
		/// If there are any <c>IAzScope</c> references to an <b>IAzScope</b> object that has been deleted from the cache, the
		/// <b>IAzScope</b> object can no longer be used. In C++, you must release references to deleted <b>IAzScope</b> objects by calling
		/// the <c>IUnknown::Release</c> method. In C# and Visual Basic, references to deleted objects are automatically released.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazapplication-deletescope HRESULT DeleteScope( [in] BSTR
		// bstrScopeName, [in, optional] VARIANT varReserved );
		[DispId(1610743834)]
		void DeleteScope([In, MarshalAs(UnmanagedType.BStr)] string bstrScopeName, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>
		/// <para>
		/// The <b>Operations</b> property retrieves an <c>IAzOperations</c> object that is used to enumerate <c>IAzOperation</c> objects
		/// from the policy data.
		/// </para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <remarks>
		/// This property can be used only to enumerate <c>IAzOperation</c> objects that are direct child objects of the
		/// <c>IAzApplication</c> object.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazapplication-get_operations HRESULT get_Operations(
		// IAzOperations **ppOperationCollection );
		[DispId(1610743835)]
		IAzOperations Operations
		{
			[DispId(1610743835)]
			[return: MarshalAs(UnmanagedType.Interface)]
			get;
		}

		/// <summary>The <b>OpenOperation</b> method opens an <c>IAzOperation</c> object with the specified name.</summary>
		/// <param name="bstrOperationName">Name of the <c>IAzOperation</c> object to open.</param>
		/// <param name="varReserved">Reserved for future use.</param>
		/// <returns>A pointer to a pointer to the opened <c>IAzOperation</c> object.</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazapplication-openoperation HRESULT OpenOperation( [in]
		// BSTR bstrOperationName, [in, optional] VARIANT varReserved, [out] IAzOperation **ppOperation );
		[DispId(1610743836)]
		[return: MarshalAs(UnmanagedType.Interface)]
		IAzOperation OpenOperation([In, MarshalAs(UnmanagedType.BStr)] string bstrOperationName, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>The <b>CreateOperation</b> method creates an <c>IAzOperation</c> object with the specified name.</summary>
		/// <param name="bstrOperationName">Name for the new <c>IAzOperation</c> object.</param>
		/// <param name="varReserved">Reserved for future use.</param>
		/// <returns>A pointer to a pointer to the created <c>IAzOperation</c> object.</returns>
		/// <remarks>
		/// <para>You must call the <c>IAzOperation::Submit</c> method to persist any changes made to the returned object.</para>
		/// <para>The returned <c>IAzOperation</c> object is an immediate child object of the <c>IAzApplication</c> object.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazapplication-createoperation HRESULT CreateOperation(
		// [in] BSTR bstrOperationName, [in, optional] VARIANT varReserved, [out] IAzOperation **ppOperation );
		[DispId(1610743837)]
		[return: MarshalAs(UnmanagedType.Interface)]
		IAzOperation CreateOperation([In, MarshalAs(UnmanagedType.BStr)] string bstrOperationName, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>
		/// The <b>DeleteOperation</b> method removes the <c>IAzOperation</c> object with the specified name from the <c>IAzApplication</c> object.
		/// </summary>
		/// <param name="bstrOperationName">Name of the <c>IAzApplication</c> object to delete.</param>
		/// <param name="varReserved">Reserved for future use.</param>
		/// <remarks>
		/// If there are any <c>IAzApplication</c> references to an <b>IAzOperation</b> object that has been deleted from the cache, the
		/// <b>IAzOperation</b> object can no longer be used. In C++, you must release references to deleted <b>IAzOperation</b> objects by
		/// calling the <c>IUnknown::Release</c> method. In C# and Visual Basic, references to deleted objects are automatically released.
		/// </remarks>
		// https://learn.microsoft.com/sl-si/windows/win32/api/azroles/nf-azroles-iazapplication-deleteoperation HRESULT DeleteOperation(
		// [in] BSTR bstrOperationName, [in, optional] VARIANT varReserved );
		[DispId(1610743838)]
		void DeleteOperation([In, MarshalAs(UnmanagedType.BStr)] string bstrOperationName, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>
		/// <para>
		/// The <b>Tasks</b> property retrieves an <c>IAzTasks</c> object that is used to enumerate <c>IAzTask</c> objects from the policy data.
		/// </para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <remarks>
		/// This property can be used only to enumerate <c>IAzTask</c> objects that are direct child objects of the <c>IAzApplication</c> object.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazapplication-get_tasks HRESULT get_Tasks( IAzTasks
		// **ppTaskCollection );
		[DispId(1610743839)]
		IAzTasks Tasks
		{
			[DispId(1610743839)]
			[return: MarshalAs(UnmanagedType.Interface)]
			get;
		}

		/// <summary>The <b>OpenTask</b> method opens an <c>IAzTask</c> object with the specified name.</summary>
		/// <param name="bstrTaskName">Name of the <c>IAzTask</c> object to open.</param>
		/// <param name="varReserved">Reserved for future use.</param>
		/// <returns>A pointer to a pointer to the opened <c>IAzTask</c> object.</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazapplication-opentask HRESULT OpenTask( [in] BSTR
		// bstrTaskName, [in, optional] VARIANT varReserved, [out] IAzTask **ppTask );
		[DispId(1610743840)]
		[return: MarshalAs(UnmanagedType.Interface)]
		IAzTask OpenTask([In, MarshalAs(UnmanagedType.BStr)] string bstrTaskName, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>The <b>CreateTask</b> method creates an <c>IAzTask</c> object with the specified name.</summary>
		/// <param name="bstrTaskName">Name for the new <c>IAzTask</c> object.</param>
		/// <param name="varReserved">Reserved for future use.</param>
		/// <returns>A pointer to a pointer to the created <c>IAzTask</c> object.</returns>
		/// <remarks>
		/// <para>You must call the <c>IAzTask::Submit</c> method to persist any changes made to the returned object.</para>
		/// <para>The returned <c>IAzTask</c> object is an immediate child object of the <c>IAzApplication</c> object.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazapplication-createtask HRESULT CreateTask( [in] BSTR
		// bstrTaskName, [in, optional] VARIANT varReserved, [out] IAzTask **ppTask );
		[DispId(1610743841)]
		[return: MarshalAs(UnmanagedType.Interface)]
		IAzTask CreateTask([In, MarshalAs(UnmanagedType.BStr)] string bstrTaskName, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>
		/// The <b>DeleteTask</b> method removes the <c>IAzTask</c> object with the specified name from the <c>IAzApplication</c> object.
		/// </summary>
		/// <param name="bstrTaskName">Name of the <c>IAzTask</c> object to delete.</param>
		/// <param name="varReserved">Reserved for future use.</param>
		/// <remarks>
		/// If there are any <c>IAzTask</c> references to an <b>IAzTask</b> object that has been deleted from the cache, the <b>IAzTask</b>
		/// object can no longer be used. In C++, you must release references to deleted <b>IAzTask</b> objects by calling the
		/// <c>IUnknown::Release</c> method. In C# and Visual Basic, references to deleted objects are automatically released.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazapplication-deletetask HRESULT DeleteTask( [in] BSTR
		// bstrTaskName, [in, optional] VARIANT varReserved );
		[DispId(1610743842)]
		void DeleteTask([In, MarshalAs(UnmanagedType.BStr)] string bstrTaskName, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>
		/// <para>
		/// The <b>ApplicationGroups</b> property retrieves an <c>IAzApplicationGroups</c> object that is used to enumerate
		/// <c>IAzApplicationGroup</c> objects from the policy data.
		/// </para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <remarks>
		/// This property can be used only to enumerate <c>IAzApplicationGroup</c> objects that are direct child objects of the
		/// <c>IAzApplication</c> object.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazapplication-get_applicationgroups HRESULT
		// get_ApplicationGroups( IAzApplicationGroups **ppGroupCollection );
		[DispId(1610743843)]
		IAzApplicationGroups ApplicationGroups
		{
			[DispId(1610743843)]
			[return: MarshalAs(UnmanagedType.Interface)]
			get;
		}

		/// <summary>The <b>OpenApplicationGroup</b> method opens an <c>IAzApplicationGroup</c> object with the specified name.</summary>
		/// <param name="bstrGroupName">Name of the <c>IAzApplicationGroup</c> object to open.</param>
		/// <param name="varReserved">Reserved for future use.</param>
		/// <returns>A pointer to a pointer to the opened <c>IAzApplicationGroup</c> object.</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazapplication-openapplicationgroup HRESULT
		// OpenApplicationGroup( [in] BSTR bstrGroupName, [in, optional] VARIANT varReserved, [out] IAzApplicationGroup **ppGroup );
		[DispId(1610743844)]
		[return: MarshalAs(UnmanagedType.Interface)]
		IAzApplicationGroup OpenApplicationGroup([In, MarshalAs(UnmanagedType.BStr)] string bstrGroupName, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>The <b>CreateApplicationGroup</b> method creates an <c>IAzApplicationGroup</c> object with the specified name.</summary>
		/// <param name="bstrGroupName">Name for the new <c>IAzApplicationGroup</c> object.</param>
		/// <param name="varReserved">Reserved for future use.</param>
		/// <returns>A pointer to a pointer to the created <c>IAzApplicationGroup</c> object.</returns>
		/// <remarks>
		/// <para>You must call the <c>IAzApplicationGroup::Submit</c> method to persist any changes made to the returned object.</para>
		/// <para>The returned <c>IAzApplicationGroup</c> object is an immediate child object of the <c>IAzApplication</c> object.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazapplication-createapplicationgroup HRESULT
		// CreateApplicationGroup( [in] BSTR bstrGroupName, [in, optional] VARIANT varReserved, [out] IAzApplicationGroup **ppGroup );
		[DispId(1610743845)]
		[return: MarshalAs(UnmanagedType.Interface)]
		IAzApplicationGroup CreateApplicationGroup([In, MarshalAs(UnmanagedType.BStr)] string bstrGroupName, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>
		/// The <b>DeleteApplicationGroup</b> method removes the <c>IAzApplicationGroup</c> object with the specified name from the
		/// <c>IAzApplication</c> object.
		/// </summary>
		/// <param name="bstrGroupName">Name of the <c>IAzApplicationGroup</c> object to delete.</param>
		/// <param name="varReserved">Reserved for future use.</param>
		/// <remarks>
		/// If there are any <c>IAzApplicationGroup</c> references to an <b>IAzApplicationGroup</b> object that has been deleted from the
		/// cache, the <b>IAzApplicationGroup</b> object can no longer be used. In C++, you must release references to deleted
		/// <b>IAzApplicationGroup</b> objects by calling the <c>IUnknown::Release</c> method. In C# and Visual Basic, references to deleted
		/// objects are automatically released.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazapplication-deleteapplicationgroup HRESULT
		// DeleteApplicationGroup( [in] BSTR bstrGroupName, [in, optional] VARIANT varReserved );
		[DispId(1610743846)]
		void DeleteApplicationGroup([In, MarshalAs(UnmanagedType.BStr)] string bstrGroupName, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>
		/// <para>
		/// The <b>Roles</b> property retrieves an <c>IAzRoles</c> object that is used to enumerate <c>IAzRole</c> objects from the policy data.
		/// </para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <remarks>
		/// This property can be used only to enumerate <c>IAzRole</c> objects that are direct child objects of the <c>IAzApplication</c> object.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazapplication-get_roles HRESULT get_Roles( IAzRoles
		// **ppRoleCollection );
		[DispId(1610743847)]
		IAzRoles Roles
		{
			[DispId(1610743847)]
			[return: MarshalAs(UnmanagedType.Interface)]
			get;
		}

		/// <summary>The <b>OpenRole</b> method opens an <c>IAzRole</c> object with the specified name.</summary>
		/// <param name="bstrRoleName">Name of the <c>IAzRole</c> object to open.</param>
		/// <param name="varReserved">Reserved for future use.</param>
		/// <returns>A pointer to a pointer to the opened <c>IAzRole</c> object.</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazapplication-openrole HRESULT OpenRole( [in] BSTR
		// bstrRoleName, [in, optional] VARIANT varReserved, [out] IAzRole **ppRole );
		[DispId(1610743848)]
		[return: MarshalAs(UnmanagedType.Interface)]
		IAzRole OpenRole([In, MarshalAs(UnmanagedType.BStr)] string bstrRoleName, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>The <b>CreateRole</b> method creates an <c>IAzRole</c> object with the specified name.</summary>
		/// <param name="bstrRoleName">Name for the new <c>IAzRole</c> object.</param>
		/// <param name="varReserved">Reserved for future use.</param>
		/// <returns>A pointer to a pointer to the created <c>IAzRole</c> object.</returns>
		/// <remarks>
		/// <para>You must call the <c>IAzRole::Submit</c> method to persist any changes made to the returned object.</para>
		/// <para>The returned <c>IAzRole</c> object is an immediate child object of the <c>IAzApplication</c> object.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazapplication-createrole HRESULT CreateRole( [in] BSTR
		// bstrRoleName, [in, optional] VARIANT varReserved, [out] IAzRole **ppRole );
		[DispId(1610743849)]
		[return: MarshalAs(UnmanagedType.Interface)]
		IAzRole CreateRole([In, MarshalAs(UnmanagedType.BStr)] string bstrRoleName, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>
		/// The <b>DeleteRole</b> method removes the <c>IAzRole</c> object with the specified name from the <c>IAzApplication</c> object.
		/// </summary>
		/// <param name="bstrRoleName">Name of the <c>IAzRole</c> object to delete.</param>
		/// <param name="varReserved">Reserved for future use.</param>
		/// <remarks>
		/// If there are any <c>IAzRole</c> references to an <b>IAzRole</b> object that has been deleted from the cache, the <b>IAzRole</b>
		/// object can no longer be used. In C++, you must release references to deleted <b>IAzRole</b> objects by calling the
		/// <c>IUnknown::Release</c> method. In C# and Visual Basic, references to deleted objects are automatically released.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazapplication-deleterole HRESULT DeleteRole( [in] BSTR
		// bstrRoleName, [in, optional] VARIANT varReserved );
		[DispId(1610743850)]
		void DeleteRole([In, MarshalAs(UnmanagedType.BStr)] string bstrRoleName, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>
		/// The <b>InitializeClientContextFromToken</b> method gets an <c>IAzClientContext</c> object pointer from the specified client token.
		/// </summary>
		/// <param name="ullTokenHandle">
		/// A handle to a Windows token that specifies the client. If this parameter is <b>NULL</b>, the impersonation token of the caller's
		/// thread is used. If the thread does not have an impersonation token, the process token is used. The token must have been opened
		/// for TOKEN_QUERY, TOKEN_IMPERSONATE, and TOKEN_DUPLICATE access.
		/// </param>
		/// <param name="varReserved">Reserved for future use.</param>
		/// <returns>A pointer to a pointer to the returned <c>IAzClientContext</c> object.</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazapplication-initializeclientcontextfromtoken HRESULT
		// InitializeClientContextFromToken( [in] ULONGLONG ullTokenHandle, [in, optional] VARIANT varReserved, [out] IAzClientContext
		// **ppClientContext );
		[DispId(1610743851)]
		[return: MarshalAs(UnmanagedType.Interface)]
		IAzClientContext InitializeClientContextFromToken([In, Optional] ulong ullTokenHandle, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>The <b>AddPropertyItem</b> method adds the specified principal to the specified list of principals.</summary>
		/// <param name="lPropId">
		/// <para>
		/// Property ID of the list of principals to which to add the principal specified by the <i>varProp</i> parameter. The following
		/// table shows the possible values.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <description>Value</description>
		/// <description>Meaning</description>
		/// </listheader>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_POLICY_ADMINS</b></description>
		/// <description>Can also be added using the <c>AddPolicyAdministrator</c> method</description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_POLICY_ADMINS_NAME</b></description>
		/// <description>Can also be added using the <c>AddPolicyAdministratorName</c> method</description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_POLICY_READERS</b></description>
		/// <description>Can also be added using the <c>AddPolicyReader</c> method</description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_POLICY_READERS_NAME</b></description>
		/// <description>Can also be added using the <c>AddPolicyReaderName</c> method</description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_DELEGATED_POLICY_USERS</b></description>
		/// <description>Can also be added using the <c>AddDelegatedPolicyUser</c> method</description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_DELEGATED_POLICY_USERS_NAME</b></description>
		/// <description>Can also be added using the <c>AddDelegatedPolicyUserName</c> method</description>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="varProp">
		/// <para>Principal to add to the list of principals specified by the <i>lPropId</i> parameter.</para>
		/// <para>The variant must be a <b>BSTR</b> variant.</para>
		/// <para>
		/// If AZ_PROP_POLICY_ADMINS_NAME, AZ_PROP_POLICY_READERS_NAME, or AZ_PROP_DELEGATED_POLICY_USERS_NAME is specified for the
		/// <i>lPropId</i> parameter, the string is the account name of the account to add to the list. The account name must be in user
		/// principal name (UPN) format (for example, "someone@example.com").
		/// </para>
		/// </param>
		/// <param name="varReserved">Reserved for future use.</param>
		/// <remarks>You must call the <c>Submit</c> method to persist any changes made by this method.</remarks>
		// https://learn.microsoft.com/mt-mt/windows/win32/api/azroles/nf-azroles-iazapplication-addpropertyitem HRESULT AddPropertyItem(
		// [in] LONG lPropId, [in] VARIANT varProp, [in, optional] VARIANT varReserved );
		[DispId(1610743852)]
		void AddPropertyItem([In] AZ_PROP_CONSTANTS lPropId, [In, MarshalAs(UnmanagedType.Struct)] object varProp, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>The <b>DeletePropertyItem</b> method removes the specified principal from the specified list of principals.</summary>
		/// <param name="lPropId">
		/// <para>
		/// Property ID of the list of principals from which to remove the principal specified by the <i>varProp</i> parameter. The following
		/// table shows the possible values.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <description>Value</description>
		/// <description>Meaning</description>
		/// </listheader>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_POLICY_ADMINS</b></description>
		/// <description>Can also be removed using the <c>DeletePolicyAdministrator</c> method</description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_POLICY_ADMINS_NAME</b></description>
		/// <description>Can also be removed using the <c>DeletePolicyAdministratorName</c> method</description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_POLICY_READERS</b></description>
		/// <description>Can also be removed using the <c>DeletePolicyReader</c> method</description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_POLICY_READERS_NAME</b></description>
		/// <description>Can also be removed using the <c>DeletePolicyReaderName</c> method</description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_DELEGATED_POLICY_USERS</b></description>
		/// <description>Can also be removed using the <c>DeleteDelegatedPolicyUser</c> method</description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_DELEGATED_POLICY_USERS_NAME</b></description>
		/// <description>Can also be removed using the <c>DeleteDelegatedPolicyUserName</c> method</description>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="varProp">
		/// <para>Principal to remove from the list of principals specified by the <i>lPropId</i> parameter.</para>
		/// <para>The variant must be a <b>BSTR</b> variant.</para>
		/// <para>
		/// If AZ_PROP_POLICY_ADMINS, AZ_PROP_POLICY_READERS, or AZ_PROP_DELEGATED_POLICY_USERS is specified for the <i>lPropId</i>
		/// parameter, the string is the text form of the <c>security identifier</c> (SID) of the Windows account to remove from the list. If
		/// AZ_PROP_POLICY_ADMINS_NAME, AZ_PROP_POLICY_READERS_NAME, or AZ_PROP_DELEGATED_POLICY_USERS_NAME is specified for the
		/// <i>lPropId</i> parameter, the string is the account name of the account to remove from the list. The account name can be in
		/// either user principal name (UPN) format (for example, "someone@example.com") or in the format of "ExampleDomain\UserName".
		/// </para>
		/// </param>
		/// <param name="varReserved">Reserved for future use.</param>
		/// <remarks>You must call the <c>Submit</c> method to persist any changes made by this method.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazapplication-deletepropertyitem HRESULT
		// DeletePropertyItem( [in] LONG lPropId, [in] VARIANT varProp, [in, optional] VARIANT varReserved );
		[DispId(1610743853)]
		void DeletePropertyItem([In] AZ_PROP_CONSTANTS lPropId, [In, MarshalAs(UnmanagedType.Struct)] object varProp, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>The <b>Submit</b> method persists changes made to the <c>IAzApplication</c> object.</summary>
		/// <param name="lFlags">
		/// Flags that modify the behavior of the <b>Submit</b> method. The default value is zero. If the <b>AZ_SUBMIT_FLAG_ABORT</b> flag is
		/// specified, the changes to the object are discarded and the object is updated to match the underlying policy store.
		/// </param>
		/// <param name="varReserved">Reserved for future use.</param>
		/// <remarks>
		/// <para>Any additions or modifications to an <c>IAzApplication</c> object are not persisted until the <b>Submit</b> method is called.</para>
		/// <para>
		/// The <b>Submit</b> method does not extend to child objects; child objects must be individually persisted to the policy store. A
		/// created <c>IAzApplication</c> object must be submitted before it can be referenced or become a parent object. The destructor for
		/// an object silently discards unsubmitted changes.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazapplication-submit HRESULT Submit( [in] LONG lFlags,
		// [in, optional] VARIANT varReserved );
		[DispId(1610743854)]
		void Submit([Optional, DefaultParameterValue((AZ_SUBMIT_FLAGS)0), In] AZ_SUBMIT_FLAGS lFlags, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>
		/// <para>
		/// The <b>InitializeClientContextFromName</b> method gets an <c>IAzClientContext</c> object pointer from the client identity as a
		/// (domain name, client name) pair.
		/// </para>
		/// <para>
		/// <b>Note</b>  If possible, call the <c>InitializeClientContextFromToken</c> function instead of
		/// <b>InitializeClientContextFromName</b>. For more information, see Remarks.
		/// </para>
		/// <para></para>
		/// </summary>
		/// <param name="ClientName">Name of the security principal.</param>
		/// <param name="DomainName">Domain name in which the user account resides. The default value is <b>NULL</b>.</param>
		/// <param name="varReserved">
		/// <para>Reserved for future use. This parameter can be one of the following values:</para>
		/// <list type="bullet">
		/// <item>
		/// <description>varReserved.vt == VT_ERROR and varReserved.scode == DISP_E_PARAMNOTFOUND</description>
		/// </item>
		/// <item>
		/// <description>varReserved.vt == VT_EMPTY</description>
		/// </item>
		/// <item>
		/// <description>varReserved.vt == VT_NULL</description>
		/// </item>
		/// <item>
		/// <description>varReserved.vt == VT_I4 and varReserved.lVal == 0</description>
		/// </item>
		/// <item>
		/// <description>varReserved.vt == VT_I2 and varReserved.iVal == 0</description>
		/// </item>
		/// </list>
		/// </param>
		/// <returns>A pointer to a pointer to the returned <c>IAzClientContext</c> object.</returns>
		/// <remarks>
		/// <para>
		/// If possible, call the <c>InitializeClientContextFromToken</c> function instead of <b>InitializeClientContextFromName</b>.
		/// <b>InitializeClientContextFromName</b> attempts to retrieve the information available in a logon token had the client actually
		/// logged on. An actual logon token provides more information, such as logon type and logon properties, and reflects the behavior of
		/// the authentication package used for the logon. The client context created by <b>InitializeClientContextFromToken</b> uses a logon
		/// token, and the resulting client context is more complete and accurate than a client context created by <b>InitializeClientContextFromName</b>.
		/// </para>
		/// <para>The <i>DomainName</i> and <i>ClientName</i> parameters must combine to represent a <c>SidTypeUser</c>.</para>
		/// <para>The supported name formats are the same as those supported by the <c>LookupAccountName</c> function.</para>
		/// <para>
		/// <b>Important</b>  Applications should not assume that the calling context has permission to use this function. The
		/// <c>AuthzInitializeContextFromSid</c> function reads the tokenGroupsGlobalAndUniversal attribute of the SID specified in the call
		/// to determine the current user's group memberships. If the user's object is in <c>Active Directory</c>, the calling context must
		/// have read access to the tokenGroupsGlobalAndUniversal attribute on the user object. Read access to the
		/// tokenGroupsGlobalAndUniversal attribute is granted to the <b>Pre-Windows 2000 Compatible Access</b> group, but new domains
		/// contain an empty <b>Pre-Windows 2000 Compatible Access</b> group by default because the default setup selection is <b>Permissions
		/// compatible with Windows 2000 and Windows Server 2003</b>. Therefore, applications may not have access to the
		/// tokenGroupsGlobalAndUniversal attribute; in this case, the <b>AuthzInitializeContextFromSid</b> function fails with
		/// ACCESS_DENIED. Applications that use this function should correctly handle this error and provide supporting documentation. To
		/// simplify granting accounts permission to query a user's group information, add accounts that need the ability to look up group
		/// information to the Windows Authorization Access Group.
		/// </para>
		/// <para></para>
		/// <para>
		/// Applications calling this function should use the fully qualified domain name or <c>user principal name</c> (UPN). Otherwise,
		/// this method might fail across forests if the NetBIOS domain name is used and the two domains do not have a direct trust relationship.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazapplication-initializeclientcontextfromname HRESULT
		// InitializeClientContextFromName( [in] BSTR ClientName, [in, optional] BSTR DomainName, [in, optional] VARIANT varReserved, [out]
		// IAzClientContext **ppClientContext );
		[DispId(1610743855)]
		[return: MarshalAs(UnmanagedType.Interface)]
		IAzClientContext InitializeClientContextFromName([In, MarshalAs(UnmanagedType.BStr)] string ClientName, [Optional, DefaultParameterValue(null), In, MarshalAs(UnmanagedType.BStr)] string? DomainName,
			[Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>
		/// <para>
		/// The <b>DelegatedPolicyUsers</b> property retrieves the <c>security identifiers</c> (SIDs), in text form, of principals that act
		/// as delegated policy users.
		/// </para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// Delegated policy users are principals that are allowed to read the subset of the policy data that the policy administrator of an
		/// <c>IAzApplication</c> object uses to administer the delegated object.
		/// </para>
		/// <para><b>Note</b>  Delegated policy users are not supported for XML stores.</para>
		/// <para></para>
		/// <para>In JScript, the returned <c>SAFEARRAY</c> must be converted to the JScript <c>Array</c> object.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazapplication-get_delegatedpolicyusers HRESULT
		// get_DelegatedPolicyUsers( VARIANT *pvarDelegatedPolicyUsers );
		[DispId(1610743856)]
		object DelegatedPolicyUsers
		{
			[DispId(1610743856)]
			[return: MarshalAs(UnmanagedType.Struct)]
			get;
		}

		/// <summary>
		/// The <b>AddDelegatedPolicyUser</b> method adds the specified <c>security identifier</c> (SID) in text form to the list of
		/// principals that act as delegated policy users.
		/// </summary>
		/// <param name="bstrDelegatedPolicyUser">Text form of the SID to add to the list of delegated policy users.</param>
		/// <param name="varReserved">
		/// <para>Reserved for future use. This parameter can be any of the following values:</para>
		/// <list type="bullet">
		/// <item>
		/// <description>varReserved.vt == VT_ERROR and varReserved.scode == DISP_E_PARAMNOTFOUND</description>
		/// </item>
		/// <item>
		/// <description>varReserved.vt == VT_EMPTY</description>
		/// </item>
		/// <item>
		/// <description>varReserved.vt == VT_NULL</description>
		/// </item>
		/// <item>
		/// <description>varReserved.vt == VT_I4 and varReserved.lVal == 0</description>
		/// </item>
		/// <item>
		/// <description>varReserved.vt == VT_I2 and varReserved.iVal == 0</description>
		/// </item>
		/// </list>
		/// </param>
		/// <remarks>
		/// <para>
		/// Delegated policy users are principals that are allowed to read the subset of the policy data that the policy administrator of an
		/// <c>IAzApplication</c> object uses to administer the delegated object.
		/// </para>
		/// <para><b>Note</b>  Delegated policy users are not supported for XML stores.</para>
		/// <para></para>
		/// <para>To view the list of delegated policy users, use the <c>DelegatedPolicyUsers</c> property.</para>
		/// <para>You must call the <c>Submit</c> method to persist any changes made by this method.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazapplication-adddelegatedpolicyuser HRESULT
		// AddDelegatedPolicyUser( [in] BSTR bstrDelegatedPolicyUser, [in, optional] VARIANT varReserved );
		[DispId(1610743857)]
		void AddDelegatedPolicyUser([In, MarshalAs(UnmanagedType.BStr)] string bstrDelegatedPolicyUser, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>
		/// The <b>DeleteDelegatedPolicyUser</b> method removes the specified <c>security identifier</c> (SID) in text form from the list of
		/// principals that act as delegated policy users.
		/// </summary>
		/// <param name="bstrDelegatedPolicyUser">Text form of the SID to remove from the list of delegated policy users.</param>
		/// <param name="varReserved">Reserved for future use.</param>
		/// <remarks>
		/// <para>
		/// Delegated policy users are principals that are allowed to read the subset of the policy data that the policy administrator of an
		/// <c>IAzApplication</c> object uses to administer the delegated object.
		/// </para>
		/// <para>
		/// <para>Note</para>
		/// <para> Delegated policy users are not supported for XML stores.</para>
		/// </para>
		/// <para>To view the list of delegated policy users, use the <c>DelegatedPolicyUsers</c> property.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazapplication-deletedelegatedpolicyuser HRESULT
		// DeleteDelegatedPolicyUser( [in] BSTR bstrDelegatedPolicyUser, [in, optional] VARIANT varReserved );
		[DispId(1610743858)]
		void DeleteDelegatedPolicyUser([In, MarshalAs(UnmanagedType.BStr)] string bstrDelegatedPolicyUser, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>
		/// <para>
		/// The <b>InitializeClientContextFromStringSid</b> method gets an <c>IAzClientContext</c> object pointer from the specified
		/// <c>security identifier</c> (SID) in text form.
		/// </para>
		/// <para>
		/// <b>Note</b>  If possible, call the <c>InitializeClientContextFromToken</c> function instead of
		/// <b>InitializeClientContextFromStringSid</b>. For more information, see Remarks.
		/// </para>
		/// <para></para>
		/// </summary>
		/// <param name="SidString">
		/// A string that contains the text form of the SID of the security principal. This must be a valid string SID that can be converted
		/// by the <c>ConvertStringSidToSid</c> function.
		/// </param>
		/// <param name="lOptions">
		/// <para>Options for the context creation.</para>
		/// <para>
		/// If AZ_CLIENT_CONTEXT_SKIP_GROUP is specified, the SID specified in the <i>SidString</i> parameter is not necessarily a valid user
		/// account. The SID will be used to create the context without validation. The created context will be flagged as having been
		/// created from a SID, the SID string will be stored in the client name field, and the domain name field will be empty. Token groups
		/// will not be used in the client context creation. <c>Lightweight Directory Access Protocol</c> (LDAP) query groups are not
		/// supported when AZ_CLIENT_CONTEXT_SKIP_GROUP is specified. Because the account is not validated in Active Directory, the client
		/// context's user information properties, such as <c>UserSamCompat</c>, will not be valid, and when accessed, they will return
		/// ERROR_INVALID_HANDLE. The <c>RoleForAccessCheck</c> property and the <c>AccessCheck</c> method of <c>IAzClientContext</c> can
		/// still be used to specify a role for access checking. The <c>GetRoles</c> method of <b>IAzClientContext</b> can still be used to
		/// enumerate roles assigned to the context within a specific scope.
		/// </para>
		/// <para>If AZ_CLIENT_CONTEXT_SKIP_GROUP is not specified, the SID must represent a valid user account.</para>
		/// </param>
		/// <param name="varReserved">
		/// <para>Reserved for future use. This parameter can be one of the following values:</para>
		/// <list type="bullet">
		/// <item>
		/// <description>varReserved.vt == VT_ERROR and varReserved.scode == DISP_E_PARAMNOTFOUND</description>
		/// </item>
		/// <item>
		/// <description>varReserved.vt == VT_EMPTY</description>
		/// </item>
		/// <item>
		/// <description>varReserved.vt == VT_NULL</description>
		/// </item>
		/// <item>
		/// <description>varReserved.vt == VT_I4 and varReserved.lVal == 0</description>
		/// </item>
		/// <item>
		/// <description>varReserved.vt == VT_I2 and varReserved.iVal == 0</description>
		/// </item>
		/// </list>
		/// </param>
		/// <returns>A pointer to a pointer to the returned <c>IAzClientContext</c> object.</returns>
		/// <remarks>
		/// <para>
		/// If possible, call the <c>InitializeClientContextFromToken</c> function instead of <b>InitializeClientContextFromStringSid</b>.
		/// <b>InitializeClientContextFromStringSid</b> attempts to retrieve the information available in a logon token had the client
		/// actually logged on. An actual logon token provides more information, such as logon type and logon properties, and reflects the
		/// behavior of the authentication package used for the logon. The client context created by <b>InitializeClientContextFromToken</b>
		/// uses a logon token, and the resulting client context is more complete and accurate than a client context created by <b>InitializeClientContextFromStringSid</b>.
		/// </para>
		/// <para>
		/// <b>Important</b>  Applications should not assume that the calling context has permission to use this function. The
		/// <c>AuthzInitializeContextFromSid</c> function reads the tokenGroupsGlobalAndUniversal attribute of the SID specified in the call
		/// to determine the current user's group memberships. If the user's object is in <c>Active Directory</c>, the calling context must
		/// have read access to the tokenGroupsGlobalAndUniversal attribute on the user object. Read access to the
		/// tokenGroupsGlobalAndUniversal attribute is granted to the <b>Pre-Windows 2000 Compatible Access</b> group, but new domains
		/// contain an empty <b>Pre-Windows 2000 Compatible Access</b> group by default because the default setup selection is <b>Permissions
		/// compatible with Windows 2000 and Windows Server 2003</b>. Therefore, applications may not have access to the
		/// tokenGroupsGlobalAndUniversal attribute; in this case, the <b>AuthzInitializeContextFromSid</b> function fails with
		/// ACCESS_DENIED. Applications that use this function should correctly handle this error and provide supporting documentation. To
		/// simplify granting accounts permission to query a user's group information, add accounts that need the ability to look up group
		/// information to the Windows Authorization Access Group.
		/// </para>
		/// <para></para>
		/// <para>
		/// Applications calling this function should use the fully qualified domain name or <c>user principal name</c> (UPN). Otherwise,
		/// this method might fail across forests if the NetBIOS domain name is used and the two domains do not have a direct trust relationship.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazapplication-initializeclientcontextfromstringsid HRESULT
		// InitializeClientContextFromStringSid( [in] BSTR SidString, [in] LONG lOptions, [in, optional] VARIANT varReserved, [out]
		// IAzClientContext **ppClientContext );
		[DispId(1610743859)]
		[return: MarshalAs(UnmanagedType.Interface)]
		IAzClientContext InitializeClientContextFromStringSid([In, MarshalAs(UnmanagedType.BStr)] string SidString, [In] AZ_PROP_CONSTANTS lOptions, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>
		/// <para>The <b>PolicyAdministratorsName</b> property retrieves the account names of principals that act as policy administrators.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <remarks>
		/// <para>Policy administrators for an object can perform the following tasks:</para>
		/// <list type="bullet">
		/// <item>
		/// <description>Read the object</description>
		/// </item>
		/// <item>
		/// <description>Write attributes to the object</description>
		/// </item>
		/// <item>
		/// <description>Read attributes of child objects of the object</description>
		/// </item>
		/// <item>
		/// <description>Write attributes to child objects of the object</description>
		/// </item>
		/// <item>
		/// <description>Delete the object</description>
		/// </item>
		/// <item>
		/// <description>Delete child objects of the object</description>
		/// </item>
		/// <item>
		/// <description>Create child objects of the object</description>
		/// </item>
		/// </list>
		/// <para>In JScript, the returned <c>SAFEARRAY</c> must be converted to the JScript <c>Array</c> object.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazapplication-get_policyadministratorsname HRESULT
		// get_PolicyAdministratorsName( VARIANT *pvarAdmins );
		[DispId(1610743860)]
		object PolicyAdministratorsName
		{
			[DispId(1610743860)]
			[return: MarshalAs(UnmanagedType.Struct)]
			get;
		}

		/// <summary>
		/// <para>The <b>PolicyReadersName</b> property retrieves the account names of principals that act as policy readers.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// Policy readers for an object can read attributes for the object and for child objects of the object. Readers can also use the
		/// policy; for example, readers can call the <c>AccessCheck</c> method. Readers cannot modify the object or its child objects.
		/// </para>
		/// <para>In JScript, the returned <c>SAFEARRAY</c> must be converted to the JScript <c>Array</c> object.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazapplication-get_policyreadersname HRESULT
		// get_PolicyReadersName( VARIANT *pvarReaders );
		[DispId(1610743861)]
		object PolicyReadersName
		{
			[DispId(1610743861)]
			[return: MarshalAs(UnmanagedType.Struct)]
			get;
		}

		/// <summary>
		/// The <b>AddPolicyAdministratorName</b> method adds the specified account name to the list of principals that act as policy administrators.
		/// </summary>
		/// <param name="bstrAdmin">
		/// Account name to add to the list of policy administrators. The account name must be in user principal name (UPN) format (for
		/// example, "someone@example.com"). The <c>LookupAccountName</c> function is called to retrieve the domain.
		/// </param>
		/// <param name="varReserved">Reserved for future use.</param>
		/// <remarks>
		/// <para>Policy administrators for an object can perform the following tasks:</para>
		/// <list type="bullet">
		/// <item>
		/// <description>Read the object</description>
		/// </item>
		/// <item>
		/// <description>Write attributes to the object</description>
		/// </item>
		/// <item>
		/// <description>Read attributes of child objects of the object</description>
		/// </item>
		/// <item>
		/// <description>Write attributes to child objects of the object</description>
		/// </item>
		/// <item>
		/// <description>Delete the object</description>
		/// </item>
		/// <item>
		/// <description>Delete child objects of the object</description>
		/// </item>
		/// <item>
		/// <description>Create child objects of the object</description>
		/// </item>
		/// </list>
		/// <para>To view the list of policy administrators in account name format, use the <c>PolicyAdministratorsName</c> property.</para>
		/// <para>You must call the <c>Submit</c> method to persist any changes made by this method.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazapplication-addpolicyadministratorname HRESULT
		// AddPolicyAdministratorName( [in] BSTR bstrAdmin, [in, optional] VARIANT varReserved );
		[DispId(1610743862)]
		void AddPolicyAdministratorName([In, MarshalAs(UnmanagedType.BStr)] string bstrAdmin, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>
		/// The <b>DeletePolicyAdministratorName</b> method removes the specified account name from the list of principals that act as policy administrators.
		/// </summary>
		/// <param name="bstrAdmin">
		/// Account name to remove from the list of policy administrators. The account name can be in either user principal name (UPN) format
		/// (for example, "someone@example.com") or in the format of "ExampleDomain\UserName". If the domain is not in the
		/// "ExampleDomain\UserName" format, the <c>LookupAccountName</c> function is called to retrieve the domain.
		/// </param>
		/// <param name="varReserved">Reserved for future use.</param>
		/// <remarks>
		/// <para>Policy administrators for an object can perform the following tasks:</para>
		/// <list type="bullet">
		/// <item>
		/// <description>Read the object</description>
		/// </item>
		/// <item>
		/// <description>Write attributes to the object</description>
		/// </item>
		/// <item>
		/// <description>Read attributes of child objects of the object</description>
		/// </item>
		/// <item>
		/// <description>Write attributes to child objects of the object</description>
		/// </item>
		/// <item>
		/// <description>Delete the object</description>
		/// </item>
		/// <item>
		/// <description>Delete child objects of the object</description>
		/// </item>
		/// <item>
		/// <description>Create child objects of the object</description>
		/// </item>
		/// </list>
		/// <para>To view the list of policy administrators in account name format, use the <c>PolicyAdministratorsName</c> property.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazapplication-deletepolicyadministratorname HRESULT
		// DeletePolicyAdministratorName( [in] BSTR bstrAdmin, [in, optional] VARIANT varReserved );
		[DispId(1610743863)]
		void DeletePolicyAdministratorName([In, MarshalAs(UnmanagedType.BStr)] string bstrAdmin, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>
		/// The <b>AddPolicyReaderName</b> method adds the specified account name to the list of principals that act as policy readers.
		/// </summary>
		/// <param name="bstrReader">
		/// Account name to add to the list of policy readers. The account name must be in user principal name (UPN) format (for example,
		/// "someone@example.com"). The <c>LookupAccountName</c> function is called to retrieve the domain.
		/// </param>
		/// <param name="varReserved">Reserved for future use.</param>
		/// <remarks>
		/// <para>
		/// Policy readers for an object can read attributes for the object and for child objects of the object. Readers can also use the
		/// policy; for example, readers can call the <c>AccessCheck</c> method. Readers cannot modify the object or its child objects.
		/// </para>
		/// <para>To view the list of policy readers in account name format, use the <c>PolicyReadersName</c> property.</para>
		/// <para>You must call the <c>Submit</c> method to persist any changes made by this method.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazapplication-addpolicyreadername HRESULT
		// AddPolicyReaderName( [in] BSTR bstrReader, [in, optional] VARIANT varReserved );
		[DispId(1610743864)]
		void AddPolicyReaderName([In, MarshalAs(UnmanagedType.BStr)] string bstrReader, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>
		/// The <b>DeletePolicyReaderName</b> method removes the specified account name from the list of principals that act as policy readers.
		/// </summary>
		/// <param name="bstrReader">
		/// The account name to remove from the list of policy readers. The account name can be in either user principal name (UPN) format
		/// (for example, "someone@example.com") or in the format of "ExampleDomain\UserName". If the domain is not in the
		/// "ExampleDomain\UserName" format, the <c>LookupAccountName</c> function is called to retrieve the domain.
		/// </param>
		/// <param name="varReserved">Reserved for future use.</param>
		/// <remarks>
		/// <para>
		/// Policy readers for an object can read attributes for the object and for child objects of the object. Readers can also use the
		/// policy; for example, readers can call the <c>AccessCheck</c> method. Readers cannot modify the object or its child objects.
		/// </para>
		/// <para>To view the list of policy readers in account name format, use the <c>PolicyReadersName</c> property.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazapplication-deletepolicyreadername HRESULT
		// DeletePolicyReaderName( [in] BSTR bstrReader, [in, optional] VARIANT varReserved );
		[DispId(1610743865)]
		void DeletePolicyReaderName([In, MarshalAs(UnmanagedType.BStr)] string bstrReader, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>
		/// <para>The <b>DelegatedPolicyUsersName</b> property retrieves the account names of principals that act as delegated policy users.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// Delegated policy users are principals that are allowed to read the subset of the policy data that the policy administrator of an
		/// <c>IAzApplication</c> object uses to administer the delegated object.
		/// </para>
		/// <para><b>Note</b>  Delegated policy users are not supported for XML stores.</para>
		/// <para></para>
		/// <para>In JScript, the returned <c>SAFEARRAY</c> must be converted to the JScript <c>Array</c> object.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazapplication-get_delegatedpolicyusersname HRESULT
		// get_DelegatedPolicyUsersName( VARIANT *pvarDelegatedPolicyUsers );
		[DispId(1610743866)]
		object DelegatedPolicyUsersName
		{
			[DispId(1610743866)]
			[return: MarshalAs(UnmanagedType.Struct)]
			get;
		}

		/// <summary>
		/// The <b>AddDelegatedPolicyUserName</b> method adds the specified account name to the list of principals that act as delegated
		/// policy users.
		/// </summary>
		/// <param name="bstrDelegatedPolicyUser">
		/// Account name to add to the list of delegated policy users. The account name must be in user principal name (UPN) format (for
		/// example, "someone@example.com"). The <c>LookupAccountName</c> function is called to retrieve the domain.
		/// </param>
		/// <param name="varReserved">Reserved for future use.</param>
		/// <remarks>
		/// <para>
		/// Delegated policy users are principals that are allowed to read the subset of the policy data that the policy administrator of an
		/// <c>IAzApplication</c> object uses to administer the delegated object.
		/// </para>
		/// <para><b>Note</b>  Delegated policy users are not supported for XML stores.</para>
		/// <para></para>
		/// <para>To view the list of delegated policy users in account name format, use the <c>DelegatedPolicyUsersName</c> property.</para>
		/// <para>You must call the <c>Submit</c> method to persist any changes made by this method.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazapplication-adddelegatedpolicyusername HRESULT
		// AddDelegatedPolicyUserName( [in] BSTR bstrDelegatedPolicyUser, [in, optional] VARIANT varReserved );
		[DispId(1610743867)]
		void AddDelegatedPolicyUserName([In, MarshalAs(UnmanagedType.BStr)] string bstrDelegatedPolicyUser, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>
		/// The <b>DeleteDelegatedPolicyUserName</b> method removes the specified account name from the list of principals that act as
		/// delegated policy users.
		/// </summary>
		/// <param name="bstrDelegatedPolicyUser">
		/// The account name to remove from the list of delegated policy users. The account name must be in user principal name (UPN) format
		/// (for example, "someone@example.com"). The <c>LookupAccountName</c> function is called to retrieve the domain.
		/// </param>
		/// <param name="varReserved">Reserved for future use.</param>
		/// <remarks>
		/// <para>
		/// Delegated policy users are principals that are allowed to read the subset of the policy data that the policy administrator of an
		/// <c>IAzApplication</c> object uses to administer the delegated object.
		/// </para>
		/// <para><b>Note</b>  Delegated policy users are not supported for XML stores.</para>
		/// <para></para>
		/// <para>To view the list of delegated policy users in account name format, use the <c>DelegatedPolicyUsersName</c> property.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazapplication-deletedelegatedpolicyusername HRESULT
		// DeleteDelegatedPolicyUserName( [in] BSTR bstrDelegatedPolicyUser, [in, optional] VARIANT varReserved );
		[DispId(1610743868)]
		void DeleteDelegatedPolicyUserName([In, MarshalAs(UnmanagedType.BStr)] string bstrDelegatedPolicyUser, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);
	}

	/// <summary>
	/// The <b>IAzApplication2</b> interface inherits from the <c>IAzApplication</c> interface and implements additional methods to
	/// initialize <c>IAzClientContext2</c> objects.
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nn-azroles-iazapplication2
	[PInvokeData("azroles.h", MSDNShortId = "NN:azroles.IAzApplication2")]
	[ComImport, Guid("086A68AF-A249-437C-B18D-D4D86D6A9660")]
	public interface IAzApplication2 : IAzApplication
	{
		/// <summary>
		/// <para>The <b>Name</b> property sets or retrieves the name of the application.</para>
		/// <para>This property is read/write.</para>
		/// </summary>
		/// <remarks>The maximum length of the <b>Name</b> property is 512 characters.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazapplication-get_name HRESULT get_Name( BSTR *pbstrName );
		[DispId(1610743808)]
		new string Name
		{
			[DispId(1610743808)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
			[DispId(1610743808)]
			[param: In]
			[param: MarshalAs(UnmanagedType.BStr)]
			set;
		}

		/// <summary>
		/// <para>The <b>Description</b> property sets or retrieves a comment that describes the application.</para>
		/// <para>This property is read/write.</para>
		/// </summary>
		/// <remarks>The maximum length of the <b>Description</b> property is 1,024 characters.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazapplication-put_description HRESULT put_Description(
		// BSTR bstrDescription );
		[DispId(1610743810)]
		new string Description
		{
			[DispId(1610743810)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
			[DispId(1610743810)]
			[param: In]
			[param: MarshalAs(UnmanagedType.BStr)]
			set;
		}

		/// <summary>
		/// <para>The <b>ApplicationData</b> property sets or retrieves an opaque field that can be used by the application to store information.</para>
		/// <para>This property is read/write.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// <b>Important</b>  Policy administrators can read from and write to this property. Applications should not store data in the
		/// <b>ApplicationData</b> property that should not be available to the policy administrator.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazapplication-get_applicationdata HRESULT
		// get_ApplicationData( BSTR *pbstrApplicationData );
		[DispId(1610743812)]
		new string ApplicationData
		{
			[DispId(1610743812)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
			[DispId(1610743812)]
			[param: In]
			[param: MarshalAs(UnmanagedType.BStr)]
			set;
		}

		/// <summary>
		/// <para>
		/// The <b>AuthzInterfaceClsid</b> property sets or retrieves the class identifier (CLSID) of the interface that the user interface
		/// (UI) uses to perform application-specific operations.
		/// </para>
		/// <para>This property is read/write.</para>
		/// </summary>
		/// <remarks>A CLSID is a GUID associated with a COM class.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazapplication-get_authzinterfaceclsid HRESULT
		// get_AuthzInterfaceClsid( BSTR *pbstrProp );
		[DispId(1610743814)]
		new string AuthzInterfaceClsid
		{
			[DispId(1610743814)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
			[DispId(1610743814)]
			[param: In]
			[param: MarshalAs(UnmanagedType.BStr)]
			set;
		}

		/// <summary>
		/// <para>The <b>Version</b> property sets or retrieves the version of the application.</para>
		/// <para>This property is read/write.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazapplication-get_version HRESULT get_Version( BSTR
		// *pbstrProp );
		[DispId(1610743816)]
		new string Version
		{
			[DispId(1610743816)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
			[DispId(1610743816)]
			[param: In]
			[param: MarshalAs(UnmanagedType.BStr)]
			set;
		}

		/// <summary>
		/// <para>The <b>GenerateAudits</b> property sets or retrieves a value that indicates whether run-time audits should be generated.</para>
		/// <para>This property is read/write.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// The <b>GenerateAudits</b> property controls client context creation, client context deletion, and access check run-time auditing.
		/// The client context can be created by a <c>security identifier</c> (SID), name, or token.
		/// </para>
		/// <para>The <c>AzAuthorizationStore.GenerateAudits</c> property controls application initialization auditing.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazapplication-get_generateaudits HRESULT
		// get_GenerateAudits( BOOL *pbProp );
		[DispId(1610743818)]
		new bool GenerateAudits
		{
			[DispId(1610743818)]
			[return: MarshalAs(UnmanagedType.Bool)]
			get;
			[DispId(1610743818)]
			[param: In, MarshalAs(UnmanagedType.Bool)]
			set;
		}

		/// <summary>
		/// <para>
		/// The <b>ApplyStoreSacl</b> property sets or retrieves a value that indicates whether policy audits should be generated when the
		/// authorization store is modified.
		/// </para>
		/// <para>This property is read/write.</para>
		/// </summary>
		/// <remarks>
		/// <para>Policy audits are generated when the underlying policy store is modified. Both success and failure audits are requested.</para>
		/// <para>This property controls policy auditing only for the <c>IAzApplication</c> object and its child objects.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazapplication-get_applystoresacl HRESULT
		// get_ApplyStoreSacl( BOOL *pbProp );
		[DispId(1610743820)]
		new bool ApplyStoreSacl
		{
			[DispId(1610743820)]
			[return: MarshalAs(UnmanagedType.Bool)]
			get;
			[DispId(1610743820)]
			[param: In, MarshalAs(UnmanagedType.Bool)]
			set;
		}

		/// <summary>
		/// <para>
		/// The <b>Writable</b> property retrieves a value that indicates whether the object can be modified by the user context that
		/// initialized it.
		/// </para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazapplication-get_writable HRESULT get_Writable( BOOL
		// *pfProp );
		[DispId(1610743822)]
		new bool Writable
		{
			[DispId(1610743822)]
			[return: MarshalAs(UnmanagedType.Bool)]
			get;
		}

		/// <summary>The <b>GetProperty</b> method returns the <c>IAzApplication</c> object property with the specified property ID.</summary>
		/// <param name="lPropId">
		/// <para>Property ID of the <c>IAzApplication</c> object property to return. The following table shows the possible values.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Value</description>
		/// <description>Meaning</description>
		/// </listheader>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_APPLICATION_AUTHZ_INTERFACE_CLSID</b></description>
		/// <description>Also accessed through the <c>AuthzInterfaceClsid</c> property</description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_APPLICATION_DATA</b></description>
		/// <description>Also accessed through the <c>ApplicationData</c> property</description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_APPLICATION_VERSION</b></description>
		/// <description>Also accessed through the <c>Version</c> property</description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_APPLY_STORE_SACL</b></description>
		/// <description>Also accessed through the <c>ApplyStoreSacl</c> property</description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_CHILD_CREATE</b></description>
		/// <description>
		/// Determines whether the current user has permission to create child objects. This value is <b>TRUE</b> if the current user has
		/// permission; otherwise, <b>FALSE</b>.
		/// </description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_DELEGATED_POLICY_USERS</b></description>
		/// <description>Also accessed through the <c>DelegatedPolicyUsers</c> property</description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_DELEGATED_POLICY_USERS_NAME</b></description>
		/// <description>Also accessed through the <c>DelegatedPolicyUsersName</c> property</description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_DESCRIPTION</b></description>
		/// <description>Also accessed through the <c>Description</c> property</description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_GENERATE_AUDITS</b></description>
		/// <description>Also accessed through the <c>GenerateAudits</c> property</description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_NAME</b></description>
		/// <description>Also accessed through the <c>Name</c> property</description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_POLICY_ADMINS</b></description>
		/// <description>Also accessed through the <c>PolicyAdministrators</c> property</description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_POLICY_ADMINS_NAME</b></description>
		/// <description>Also accessed through the <c>PolicyAdministratorsName</c> property</description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_POLICY_READERS</b></description>
		/// <description>Also accessed through the <c>PolicyReaders</c> property</description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_POLICY_READERS_NAME</b></description>
		/// <description>Also accessed through the <c>PolicyReadersName</c> property</description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_WRITABLE</b></description>
		/// <description>Also accessed through the <c>Writable</c> property</description>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="varReserved">Reserved for future use.</param>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazapplication-getproperty HRESULT GetProperty( [in] LONG
		// lPropId, [in, optional] VARIANT varReserved, [out] VARIANT *pvarProp );
		[DispId(1610743823)]
		[return: MarshalAs(UnmanagedType.Struct)]
		new object GetProperty([In] AZ_PROP_CONSTANTS lPropId, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>
		/// The <b>SetProperty</b> method sets the specified value to the <c>IAzApplication</c> object property with the specified property ID.
		/// </summary>
		/// <param name="lPropId">
		/// <para>Property ID of the <c>IAzApplication</c> object property to set. The following table shows the possible values.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Value</description>
		/// <description>Meaning</description>
		/// </listheader>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_APPLICATION_DATA</b></description>
		/// <description>Also accessed through the <c>ApplicationData</c> property</description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_APPLICATION_AUTHZ_INTERFACE_CLSID</b></description>
		/// <description>Also accessed through the <c>AuthzInterfaceClsid</c> property</description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_APPLICATION_VERSION</b></description>
		/// <description>Also accessed through the <c>Version</c> property</description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_APPLY_STORE_SACL</b></description>
		/// <description>Also accessed through the <c>ApplyStoreSacl</c> property</description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_DESCRIPTION</b></description>
		/// <description>Also accessed through the <c>Description</c> property</description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_GENERATE_AUDITS</b></description>
		/// <description>Also accessed through the <c>GenerateAudits</c> property</description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_NAME</b></description>
		/// <description>Also accessed through the <c>Name</c> property</description>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="varProp">
		/// <para>
		/// Value to set to the <c>IAzApplication</c> object property specified by the <i>lPropId</i> parameter. The type of data that must
		/// be used depends on the value of the <i>lPropId</i> parameter.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <description><i>lPropId</i> value</description>
		/// <description>Data type (C++/Visual Basic)</description>
		/// </listheader>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_APPLICATION_DATA</b></description>
		/// <description><b>BSTR</b>/ <b>String</b></description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_APPLICATION_INTERFACE_CLSID</b></description>
		/// <description><b>BSTR</b>/ <b>String</b></description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_APPLICATION_VERSION</b></description>
		/// <description><b>BSTR</b>/ <b>String</b></description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_APPLY_STORE_SACL</b></description>
		/// <description><b>BSTR</b>/ <b>String</b></description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_DESCRIPTION</b></description>
		/// <description><b>BSTR</b>/ <b>String</b></description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_GENERATE_AUDITS</b></description>
		/// <description><b>BSTR</b>/ <b>String</b></description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_NAME</b></description>
		/// <description><b>BSTR</b>/ <b>String</b></description>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="varReserved">Reserved for future use.</param>
		/// <remarks>You must call the <c>Submit</c> method to persist any changes made by this method.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazapplication-setproperty HRESULT SetProperty( [in] LONG
		// lPropId, [in] VARIANT varProp, [in, optional] VARIANT varReserved );
		[DispId(1610743824)]
		new void SetProperty([In] AZ_PROP_CONSTANTS lPropId, [In, MarshalAs(UnmanagedType.Struct)] object varProp, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>
		/// <para>
		/// The <b>PolicyAdministrators</b> property retrieves the <c>security identifiers</c> (SIDs) of principals that act as policy
		/// administrators in text form.
		/// </para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <remarks>
		/// <para>Policy administrators for an object can perform the following tasks:</para>
		/// <list type="bullet">
		/// <item>
		/// <description>Read the object</description>
		/// </item>
		/// <item>
		/// <description>Write attributes to the object</description>
		/// </item>
		/// <item>
		/// <description>Read attributes of child objects of the object</description>
		/// </item>
		/// <item>
		/// <description>Write attributes to child objects of the object</description>
		/// </item>
		/// <item>
		/// <description>Delete the object</description>
		/// </item>
		/// <item>
		/// <description>Delete child objects of the object</description>
		/// </item>
		/// <item>
		/// <description>Create child objects of the object</description>
		/// </item>
		/// </list>
		/// <para>In JScript, the returned <c>SAFEARRAY</c> must be converted to the JScript <c>Array</c> object.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazauthorizationstore-get_policyadministrators HRESULT
		// get_PolicyAdministrators( VARIANT *pvarAdmins );
		[DispId(1610743825)]
		new object PolicyAdministrators
		{
			[DispId(1610743825)]
			[return: MarshalAs(UnmanagedType.Struct)]
			get;
		}

		/// <summary>
		/// <para>
		/// The <b>PolicyReaders</b> property retrieves the <c>security identifiers</c> (SIDs) of principals that act as policy readers in
		/// text form.
		/// </para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// Policy readers for an object can read attributes for the object and for child objects of the object. Readers can also use the
		/// policy; for example, readers can call the <c>AccessCheck</c> method. Readers cannot modify the object or its child objects.
		/// </para>
		/// <para>In JScript, the returned <c>SAFEARRAY</c> must be converted to the JScript <c>Array</c> object.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazauthorizationstore-get_policyreaders HRESULT
		// get_PolicyReaders( VARIANT *pvarReaders );
		[DispId(1610743826)]
		new object PolicyReaders
		{
			[DispId(1610743826)]
			[return: MarshalAs(UnmanagedType.Struct)]
			get;
		}

		/// <summary>
		/// The <b>AddPolicyAdministrator</b> method adds the specified <c>security identifier</c> (SID) in text form to the list of
		/// principals that act as policy administrators.
		/// </summary>
		/// <param name="bstrAdmin">Text form of the SID to add to the list of policy administrators.</param>
		/// <param name="varReserved">Reserved for future use.</param>
		/// <remarks>
		/// <para>Policy administrators for an object can perform the following tasks:</para>
		/// <list type="bullet">
		/// <item>
		/// <description>Read the object</description>
		/// </item>
		/// <item>
		/// <description>Write attributes to the object</description>
		/// </item>
		/// <item>
		/// <description>Read attributes of child objects of the object</description>
		/// </item>
		/// <item>
		/// <description>Write attributes to child objects of the object</description>
		/// </item>
		/// <item>
		/// <description>Delete the object</description>
		/// </item>
		/// <item>
		/// <description>Delete child objects of the object</description>
		/// </item>
		/// <item>
		/// <description>Create child objects of the object</description>
		/// </item>
		/// </list>
		/// <para>To view the list of policy administrators, use the <c>PolicyAdministrators</c> property.</para>
		/// <para>You must call the <c>Submit</c> method to persist any changes made by this method.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazapplication-addpolicyadministrator HRESULT
		// AddPolicyAdministrator( [in] BSTR bstrAdmin, [in, optional] VARIANT varReserved );
		[DispId(1610743827)]
		new void AddPolicyAdministrator([In, MarshalAs(UnmanagedType.BStr)] string bstrAdmin, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>
		/// The <b>DeletePolicyAdministrator</b> method removes the specified <c>security identifier</c> (SID) in text form from the list of
		/// principals that act as policy administrators.
		/// </summary>
		/// <param name="bstrAdmin">Text form of the SID to remove from the list of policy administrators.</param>
		/// <param name="varReserved">Reserved for future use.</param>
		/// <remarks>
		/// <para>Policy administrators for an object can perform the following tasks:</para>
		/// <list type="bullet">
		/// <item>
		/// <description>Read the object</description>
		/// </item>
		/// <item>
		/// <description>Write attributes to the object</description>
		/// </item>
		/// <item>
		/// <description>Read attributes of child objects of the object</description>
		/// </item>
		/// <item>
		/// <description>Write attributes to child objects of the object</description>
		/// </item>
		/// <item>
		/// <description>Delete the object</description>
		/// </item>
		/// <item>
		/// <description>Delete child objects of the object</description>
		/// </item>
		/// <item>
		/// <description>Create child objects of the object</description>
		/// </item>
		/// </list>
		/// <para>To view the list of policy administrators, use the <c>PolicyAdministrators</c> property.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazapplication-deletepolicyadministrator HRESULT
		// DeletePolicyAdministrator( [in] BSTR bstrAdmin, [in, optional] VARIANT varReserved );
		[DispId(1610743828)]
		new void DeletePolicyAdministrator([In, MarshalAs(UnmanagedType.BStr)] string bstrAdmin, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>
		/// The <b>AddPolicyReader</b> method adds the specified <c>security identifier</c> (SID) in text form to the list of principals that
		/// act as policy readers.
		/// </summary>
		/// <param name="bstrReader">Text form of the SID to add to the list of policy readers.</param>
		/// <param name="varReserved">Reserved for future use.</param>
		/// <remarks>
		/// <para>
		/// Policy readers for an object can read attributes for the object and for child objects of the object. Readers can also use the
		/// policy; for example, readers can call the <c>AccessCheck</c> method. Readers cannot modify the object or its child objects.
		/// </para>
		/// <para>To view the list of policy readers, use the <c>PolicyReaders</c> property.</para>
		/// <para>You must call the <c>Submit</c> method to persist any changes made by this method.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazapplication-addpolicyreader HRESULT AddPolicyReader(
		// [in] BSTR bstrReader, [in, optional] VARIANT varReserved );
		[DispId(1610743829)]
		new void AddPolicyReader([In, MarshalAs(UnmanagedType.BStr)] string bstrReader, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>
		/// The <b>DeletePolicyReader</b> method removes the specified <c>security identifier</c> (SID) in text form from the list of
		/// principals that act as policy readers.
		/// </summary>
		/// <param name="bstrReader">Text form of the SID to remove from the list of policy readers.</param>
		/// <param name="varReserved">Reserved for future use.</param>
		/// <remarks>
		/// <para>
		/// Policy readers for an object can read attributes for the object and for child objects of the object. Readers can also use the
		/// policy; for example, readers can call the <c>AccessCheck</c> method. Readers cannot modify the object or its child objects.
		/// </para>
		/// <para>To view the list of policy readers, use the <c>PolicyReaders</c> property.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazapplication-deletepolicyreader HRESULT
		// DeletePolicyReader( [in] BSTR bstrReader, [in, optional] VARIANT varReserved );
		[DispId(1610743830)]
		new void DeletePolicyReader([In, MarshalAs(UnmanagedType.BStr)] string bstrReader, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>
		/// <para>
		/// The <b>Scopes</b> property retrieves an <c>IAzScopes</c> object that is used to enumerate <c>IAzScope</c> objects from the policy data.
		/// </para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <remarks>
		/// This property can be used only to enumerate <c>IAzScope</c> objects that are direct child objects of the <c>IAzApplication</c> object.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazapplication-get_scopes HRESULT get_Scopes( IAzScopes
		// **ppScopeCollection );
		[DispId(1610743831)]
		new IAzScopes Scopes
		{
			[DispId(1610743831)]
			[return: MarshalAs(UnmanagedType.Interface)]
			get;
		}

		/// <summary>The <b>OpenScope</b> method opens an <c>IAzScope</c> object with the specified name.</summary>
		/// <param name="bstrScopeName">Name of the <c>IAzScope</c> object to open.</param>
		/// <param name="varReserved">Reserved for future use.</param>
		/// <returns>A pointer to a pointer to the opened <c>IAzScope</c> object.</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazapplication-openscope HRESULT OpenScope( [in] BSTR
		// bstrScopeName, [in, optional] VARIANT varReserved, [out] IAzScope **ppScope );
		[DispId(1610743832)]
		[return: MarshalAs(UnmanagedType.Interface)]
		new IAzScope OpenScope([In, MarshalAs(UnmanagedType.BStr)] string bstrScopeName, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>The <b>CreateScope</b> method creates an <c>IAzScope</c> object with the specified name.</summary>
		/// <param name="bstrScopeName">Name for the new <c>IAzScope</c> object.</param>
		/// <param name="varReserved">Reserved for future use.</param>
		/// <returns>A pointer to a pointer to the created <c>IAzScope</c> object.</returns>
		/// <remarks>
		/// <para>You must call the <c>IAzScope::Submit</c> method to persist any changes made to the returned object.</para>
		/// <para>The returned <c>IAzScope</c> object is an immediate child object of the <c>IAzApplication</c> object.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazapplication-createscope HRESULT CreateScope( [in] BSTR
		// bstrScopeName, [in, optional] VARIANT varReserved, [out] IAzScope **ppScope );
		[DispId(1610743833)]
		[return: MarshalAs(UnmanagedType.Interface)]
		new IAzScope CreateScope([In, MarshalAs(UnmanagedType.BStr)] string bstrScopeName, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>
		/// The <b>DeleteScope</b> method removes the <c>IAzScope</c> object with the specified name from the <c>IAzApplication</c> object.
		/// </summary>
		/// <param name="bstrScopeName">Name of the <c>IAzScope</c> object to delete.</param>
		/// <param name="varReserved">Reserved for future use.</param>
		/// <remarks>
		/// If there are any <c>IAzScope</c> references to an <b>IAzScope</b> object that has been deleted from the cache, the
		/// <b>IAzScope</b> object can no longer be used. In C++, you must release references to deleted <b>IAzScope</b> objects by calling
		/// the <c>IUnknown::Release</c> method. In C# and Visual Basic, references to deleted objects are automatically released.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazapplication-deletescope HRESULT DeleteScope( [in] BSTR
		// bstrScopeName, [in, optional] VARIANT varReserved );
		[DispId(1610743834)]
		new void DeleteScope([In, MarshalAs(UnmanagedType.BStr)] string bstrScopeName, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>
		/// <para>
		/// The <b>Operations</b> property retrieves an <c>IAzOperations</c> object that is used to enumerate <c>IAzOperation</c> objects
		/// from the policy data.
		/// </para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <remarks>
		/// This property can be used only to enumerate <c>IAzOperation</c> objects that are direct child objects of the
		/// <c>IAzApplication</c> object.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazapplication-get_operations HRESULT get_Operations(
		// IAzOperations **ppOperationCollection );
		[DispId(1610743835)]
		new IAzOperations Operations
		{
			[DispId(1610743835)]
			[return: MarshalAs(UnmanagedType.Interface)]
			get;
		}

		/// <summary>The <b>OpenOperation</b> method opens an <c>IAzOperation</c> object with the specified name.</summary>
		/// <param name="bstrOperationName">Name of the <c>IAzOperation</c> object to open.</param>
		/// <param name="varReserved">Reserved for future use.</param>
		/// <returns>A pointer to a pointer to the opened <c>IAzOperation</c> object.</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazapplication-openoperation HRESULT OpenOperation( [in]
		// BSTR bstrOperationName, [in, optional] VARIANT varReserved, [out] IAzOperation **ppOperation );
		[DispId(1610743836)]
		[return: MarshalAs(UnmanagedType.Interface)]
		new IAzOperation OpenOperation([In, MarshalAs(UnmanagedType.BStr)] string bstrOperationName, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>The <b>CreateOperation</b> method creates an <c>IAzOperation</c> object with the specified name.</summary>
		/// <param name="bstrOperationName">Name for the new <c>IAzOperation</c> object.</param>
		/// <param name="varReserved">Reserved for future use.</param>
		/// <returns>A pointer to a pointer to the created <c>IAzOperation</c> object.</returns>
		/// <remarks>
		/// <para>You must call the <c>IAzOperation::Submit</c> method to persist any changes made to the returned object.</para>
		/// <para>The returned <c>IAzOperation</c> object is an immediate child object of the <c>IAzApplication</c> object.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazapplication-createoperation HRESULT CreateOperation(
		// [in] BSTR bstrOperationName, [in, optional] VARIANT varReserved, [out] IAzOperation **ppOperation );
		[DispId(1610743837)]
		[return: MarshalAs(UnmanagedType.Interface)]
		new IAzOperation CreateOperation([In, MarshalAs(UnmanagedType.BStr)] string bstrOperationName, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>
		/// The <b>DeleteOperation</b> method removes the <c>IAzOperation</c> object with the specified name from the <c>IAzApplication</c> object.
		/// </summary>
		/// <param name="bstrOperationName">Name of the <c>IAzApplication</c> object to delete.</param>
		/// <param name="varReserved">Reserved for future use.</param>
		/// <remarks>
		/// If there are any <c>IAzApplication</c> references to an <b>IAzOperation</b> object that has been deleted from the cache, the
		/// <b>IAzOperation</b> object can no longer be used. In C++, you must release references to deleted <b>IAzOperation</b> objects by
		/// calling the <c>IUnknown::Release</c> method. In C# and Visual Basic, references to deleted objects are automatically released.
		/// </remarks>
		// https://learn.microsoft.com/sl-si/windows/win32/api/azroles/nf-azroles-iazapplication-deleteoperation HRESULT DeleteOperation(
		// [in] BSTR bstrOperationName, [in, optional] VARIANT varReserved );
		[DispId(1610743838)]
		new void DeleteOperation([In, MarshalAs(UnmanagedType.BStr)] string bstrOperationName, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>
		/// <para>
		/// The <b>Tasks</b> property retrieves an <c>IAzTasks</c> object that is used to enumerate <c>IAzTask</c> objects from the policy data.
		/// </para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <remarks>
		/// This property can be used only to enumerate <c>IAzTask</c> objects that are direct child objects of the <c>IAzApplication</c> object.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazapplication-get_tasks HRESULT get_Tasks( IAzTasks
		// **ppTaskCollection );
		[DispId(1610743839)]
		new IAzTasks Tasks
		{
			[DispId(1610743839)]
			[return: MarshalAs(UnmanagedType.Interface)]
			get;
		}

		/// <summary>The <b>OpenTask</b> method opens an <c>IAzTask</c> object with the specified name.</summary>
		/// <param name="bstrTaskName">Name of the <c>IAzTask</c> object to open.</param>
		/// <param name="varReserved">Reserved for future use.</param>
		/// <returns>A pointer to a pointer to the opened <c>IAzTask</c> object.</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazapplication-opentask HRESULT OpenTask( [in] BSTR
		// bstrTaskName, [in, optional] VARIANT varReserved, [out] IAzTask **ppTask );
		[DispId(1610743840)]
		[return: MarshalAs(UnmanagedType.Interface)]
		new IAzTask OpenTask([In, MarshalAs(UnmanagedType.BStr)] string bstrTaskName, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>The <b>CreateTask</b> method creates an <c>IAzTask</c> object with the specified name.</summary>
		/// <param name="bstrTaskName">Name for the new <c>IAzTask</c> object.</param>
		/// <param name="varReserved">Reserved for future use.</param>
		/// <returns>A pointer to a pointer to the created <c>IAzTask</c> object.</returns>
		/// <remarks>
		/// <para>You must call the <c>IAzTask::Submit</c> method to persist any changes made to the returned object.</para>
		/// <para>The returned <c>IAzTask</c> object is an immediate child object of the <c>IAzApplication</c> object.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazapplication-createtask HRESULT CreateTask( [in] BSTR
		// bstrTaskName, [in, optional] VARIANT varReserved, [out] IAzTask **ppTask );
		[DispId(1610743841)]
		[return: MarshalAs(UnmanagedType.Interface)]
		new IAzTask CreateTask([In, MarshalAs(UnmanagedType.BStr)] string bstrTaskName, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>
		/// The <b>DeleteTask</b> method removes the <c>IAzTask</c> object with the specified name from the <c>IAzApplication</c> object.
		/// </summary>
		/// <param name="bstrTaskName">Name of the <c>IAzTask</c> object to delete.</param>
		/// <param name="varReserved">Reserved for future use.</param>
		/// <remarks>
		/// If there are any <c>IAzTask</c> references to an <b>IAzTask</b> object that has been deleted from the cache, the <b>IAzTask</b>
		/// object can no longer be used. In C++, you must release references to deleted <b>IAzTask</b> objects by calling the
		/// <c>IUnknown::Release</c> method. In C# and Visual Basic, references to deleted objects are automatically released.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazapplication-deletetask HRESULT DeleteTask( [in] BSTR
		// bstrTaskName, [in, optional] VARIANT varReserved );
		[DispId(1610743842)]
		new void DeleteTask([In, MarshalAs(UnmanagedType.BStr)] string bstrTaskName, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>
		/// <para>
		/// The <b>ApplicationGroups</b> property retrieves an <c>IAzApplicationGroups</c> object that is used to enumerate
		/// <c>IAzApplicationGroup</c> objects from the policy data.
		/// </para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <remarks>
		/// This property can be used only to enumerate <c>IAzApplicationGroup</c> objects that are direct child objects of the
		/// <c>IAzApplication</c> object.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazapplication-get_applicationgroups HRESULT
		// get_ApplicationGroups( IAzApplicationGroups **ppGroupCollection );
		[DispId(1610743843)]
		new IAzApplicationGroups ApplicationGroups
		{
			[DispId(1610743843)]
			[return: MarshalAs(UnmanagedType.Interface)]
			get;
		}

		/// <summary>The <b>OpenApplicationGroup</b> method opens an <c>IAzApplicationGroup</c> object with the specified name.</summary>
		/// <param name="bstrGroupName">Name of the <c>IAzApplicationGroup</c> object to open.</param>
		/// <param name="varReserved">Reserved for future use.</param>
		/// <returns>A pointer to a pointer to the opened <c>IAzApplicationGroup</c> object.</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazapplication-openapplicationgroup HRESULT
		// OpenApplicationGroup( [in] BSTR bstrGroupName, [in, optional] VARIANT varReserved, [out] IAzApplicationGroup **ppGroup );
		[DispId(1610743844)]
		[return: MarshalAs(UnmanagedType.Interface)]
		new IAzApplicationGroup OpenApplicationGroup([In, MarshalAs(UnmanagedType.BStr)] string bstrGroupName, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>The <b>CreateApplicationGroup</b> method creates an <c>IAzApplicationGroup</c> object with the specified name.</summary>
		/// <param name="bstrGroupName">Name for the new <c>IAzApplicationGroup</c> object.</param>
		/// <param name="varReserved">Reserved for future use.</param>
		/// <returns>A pointer to a pointer to the created <c>IAzApplicationGroup</c> object.</returns>
		/// <remarks>
		/// <para>You must call the <c>IAzApplicationGroup::Submit</c> method to persist any changes made to the returned object.</para>
		/// <para>The returned <c>IAzApplicationGroup</c> object is an immediate child object of the <c>IAzApplication</c> object.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazapplication-createapplicationgroup HRESULT
		// CreateApplicationGroup( [in] BSTR bstrGroupName, [in, optional] VARIANT varReserved, [out] IAzApplicationGroup **ppGroup );
		[DispId(1610743845)]
		[return: MarshalAs(UnmanagedType.Interface)]
		new IAzApplicationGroup CreateApplicationGroup([In, MarshalAs(UnmanagedType.BStr)] string bstrGroupName, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>
		/// The <b>DeleteApplicationGroup</b> method removes the <c>IAzApplicationGroup</c> object with the specified name from the
		/// <c>IAzApplication</c> object.
		/// </summary>
		/// <param name="bstrGroupName">Name of the <c>IAzApplicationGroup</c> object to delete.</param>
		/// <param name="varReserved">Reserved for future use.</param>
		/// <remarks>
		/// If there are any <c>IAzApplicationGroup</c> references to an <b>IAzApplicationGroup</b> object that has been deleted from the
		/// cache, the <b>IAzApplicationGroup</b> object can no longer be used. In C++, you must release references to deleted
		/// <b>IAzApplicationGroup</b> objects by calling the <c>IUnknown::Release</c> method. In C# and Visual Basic, references to deleted
		/// objects are automatically released.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazapplication-deleteapplicationgroup HRESULT
		// DeleteApplicationGroup( [in] BSTR bstrGroupName, [in, optional] VARIANT varReserved );
		[DispId(1610743846)]
		new void DeleteApplicationGroup([In, MarshalAs(UnmanagedType.BStr)] string bstrGroupName, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>
		/// <para>
		/// The <b>Roles</b> property retrieves an <c>IAzRoles</c> object that is used to enumerate <c>IAzRole</c> objects from the policy data.
		/// </para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <remarks>
		/// This property can be used only to enumerate <c>IAzRole</c> objects that are direct child objects of the <c>IAzApplication</c> object.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazapplication-get_roles HRESULT get_Roles( IAzRoles
		// **ppRoleCollection );
		[DispId(1610743847)]
		new IAzRoles Roles
		{
			[DispId(1610743847)]
			[return: MarshalAs(UnmanagedType.Interface)]
			get;
		}

		/// <summary>The <b>OpenRole</b> method opens an <c>IAzRole</c> object with the specified name.</summary>
		/// <param name="bstrRoleName">Name of the <c>IAzRole</c> object to open.</param>
		/// <param name="varReserved">Reserved for future use.</param>
		/// <returns>A pointer to a pointer to the opened <c>IAzRole</c> object.</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazapplication-openrole HRESULT OpenRole( [in] BSTR
		// bstrRoleName, [in, optional] VARIANT varReserved, [out] IAzRole **ppRole );
		[DispId(1610743848)]
		[return: MarshalAs(UnmanagedType.Interface)]
		new IAzRole OpenRole([In, MarshalAs(UnmanagedType.BStr)] string bstrRoleName, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>The <b>CreateRole</b> method creates an <c>IAzRole</c> object with the specified name.</summary>
		/// <param name="bstrRoleName">Name for the new <c>IAzRole</c> object.</param>
		/// <param name="varReserved">Reserved for future use.</param>
		/// <returns>A pointer to a pointer to the created <c>IAzRole</c> object.</returns>
		/// <remarks>
		/// <para>You must call the <c>IAzRole::Submit</c> method to persist any changes made to the returned object.</para>
		/// <para>The returned <c>IAzRole</c> object is an immediate child object of the <c>IAzApplication</c> object.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazapplication-createrole HRESULT CreateRole( [in] BSTR
		// bstrRoleName, [in, optional] VARIANT varReserved, [out] IAzRole **ppRole );
		[DispId(1610743849)]
		[return: MarshalAs(UnmanagedType.Interface)]
		new IAzRole CreateRole([In, MarshalAs(UnmanagedType.BStr)] string bstrRoleName, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>
		/// The <b>DeleteRole</b> method removes the <c>IAzRole</c> object with the specified name from the <c>IAzApplication</c> object.
		/// </summary>
		/// <param name="bstrRoleName">Name of the <c>IAzRole</c> object to delete.</param>
		/// <param name="varReserved">Reserved for future use.</param>
		/// <remarks>
		/// If there are any <c>IAzRole</c> references to an <b>IAzRole</b> object that has been deleted from the cache, the <b>IAzRole</b>
		/// object can no longer be used. In C++, you must release references to deleted <b>IAzRole</b> objects by calling the
		/// <c>IUnknown::Release</c> method. In C# and Visual Basic, references to deleted objects are automatically released.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazapplication-deleterole HRESULT DeleteRole( [in] BSTR
		// bstrRoleName, [in, optional] VARIANT varReserved );
		[DispId(1610743850)]
		new void DeleteRole([In, MarshalAs(UnmanagedType.BStr)] string bstrRoleName, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>
		/// The <b>InitializeClientContextFromToken</b> method gets an <c>IAzClientContext</c> object pointer from the specified client token.
		/// </summary>
		/// <param name="ullTokenHandle">
		/// A handle to a Windows token that specifies the client. If this parameter is <b>NULL</b>, the impersonation token of the caller's
		/// thread is used. If the thread does not have an impersonation token, the process token is used. The token must have been opened
		/// for TOKEN_QUERY, TOKEN_IMPERSONATE, and TOKEN_DUPLICATE access.
		/// </param>
		/// <param name="varReserved">Reserved for future use.</param>
		/// <returns>A pointer to a pointer to the returned <c>IAzClientContext</c> object.</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazapplication-initializeclientcontextfromtoken HRESULT
		// InitializeClientContextFromToken( [in] ULONGLONG ullTokenHandle, [in, optional] VARIANT varReserved, [out] IAzClientContext
		// **ppClientContext );
		[DispId(1610743851)]
		[return: MarshalAs(UnmanagedType.Interface)]
		new IAzClientContext InitializeClientContextFromToken([In, Optional] ulong ullTokenHandle, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>The <b>AddPropertyItem</b> method adds the specified principal to the specified list of principals.</summary>
		/// <param name="lPropId">
		/// <para>
		/// Property ID of the list of principals to which to add the principal specified by the <i>varProp</i> parameter. The following
		/// table shows the possible values.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <description>Value</description>
		/// <description>Meaning</description>
		/// </listheader>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_POLICY_ADMINS</b></description>
		/// <description>Can also be added using the <c>AddPolicyAdministrator</c> method</description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_POLICY_ADMINS_NAME</b></description>
		/// <description>Can also be added using the <c>AddPolicyAdministratorName</c> method</description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_POLICY_READERS</b></description>
		/// <description>Can also be added using the <c>AddPolicyReader</c> method</description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_POLICY_READERS_NAME</b></description>
		/// <description>Can also be added using the <c>AddPolicyReaderName</c> method</description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_DELEGATED_POLICY_USERS</b></description>
		/// <description>Can also be added using the <c>AddDelegatedPolicyUser</c> method</description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_DELEGATED_POLICY_USERS_NAME</b></description>
		/// <description>Can also be added using the <c>AddDelegatedPolicyUserName</c> method</description>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="varProp">
		/// <para>Principal to add to the list of principals specified by the <i>lPropId</i> parameter.</para>
		/// <para>The variant must be a <b>BSTR</b> variant.</para>
		/// <para>
		/// If AZ_PROP_POLICY_ADMINS_NAME, AZ_PROP_POLICY_READERS_NAME, or AZ_PROP_DELEGATED_POLICY_USERS_NAME is specified for the
		/// <i>lPropId</i> parameter, the string is the account name of the account to add to the list. The account name must be in user
		/// principal name (UPN) format (for example, "someone@example.com").
		/// </para>
		/// </param>
		/// <param name="varReserved">Reserved for future use.</param>
		/// <remarks>You must call the <c>Submit</c> method to persist any changes made by this method.</remarks>
		// https://learn.microsoft.com/mt-mt/windows/win32/api/azroles/nf-azroles-iazapplication-addpropertyitem HRESULT AddPropertyItem(
		// [in] LONG lPropId, [in] VARIANT varProp, [in, optional] VARIANT varReserved );
		[DispId(1610743852)]
		new void AddPropertyItem([In] AZ_PROP_CONSTANTS lPropId, [In, MarshalAs(UnmanagedType.Struct)] object varProp, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>The <b>DeletePropertyItem</b> method removes the specified principal from the specified list of principals.</summary>
		/// <param name="lPropId">
		/// <para>
		/// Property ID of the list of principals from which to remove the principal specified by the <i>varProp</i> parameter. The following
		/// table shows the possible values.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <description>Value</description>
		/// <description>Meaning</description>
		/// </listheader>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_POLICY_ADMINS</b></description>
		/// <description>Can also be removed using the <c>DeletePolicyAdministrator</c> method</description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_POLICY_ADMINS_NAME</b></description>
		/// <description>Can also be removed using the <c>DeletePolicyAdministratorName</c> method</description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_POLICY_READERS</b></description>
		/// <description>Can also be removed using the <c>DeletePolicyReader</c> method</description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_POLICY_READERS_NAME</b></description>
		/// <description>Can also be removed using the <c>DeletePolicyReaderName</c> method</description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_DELEGATED_POLICY_USERS</b></description>
		/// <description>Can also be removed using the <c>DeleteDelegatedPolicyUser</c> method</description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_DELEGATED_POLICY_USERS_NAME</b></description>
		/// <description>Can also be removed using the <c>DeleteDelegatedPolicyUserName</c> method</description>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="varProp">
		/// <para>Principal to remove from the list of principals specified by the <i>lPropId</i> parameter.</para>
		/// <para>The variant must be a <b>BSTR</b> variant.</para>
		/// <para>
		/// If AZ_PROP_POLICY_ADMINS, AZ_PROP_POLICY_READERS, or AZ_PROP_DELEGATED_POLICY_USERS is specified for the <i>lPropId</i>
		/// parameter, the string is the text form of the <c>security identifier</c> (SID) of the Windows account to remove from the list. If
		/// AZ_PROP_POLICY_ADMINS_NAME, AZ_PROP_POLICY_READERS_NAME, or AZ_PROP_DELEGATED_POLICY_USERS_NAME is specified for the
		/// <i>lPropId</i> parameter, the string is the account name of the account to remove from the list. The account name can be in
		/// either user principal name (UPN) format (for example, "someone@example.com") or in the format of "ExampleDomain\UserName".
		/// </para>
		/// </param>
		/// <param name="varReserved">Reserved for future use.</param>
		/// <remarks>You must call the <c>Submit</c> method to persist any changes made by this method.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazapplication-deletepropertyitem HRESULT
		// DeletePropertyItem( [in] LONG lPropId, [in] VARIANT varProp, [in, optional] VARIANT varReserved );
		[DispId(1610743853)]
		new void DeletePropertyItem([In] AZ_PROP_CONSTANTS lPropId, [In, MarshalAs(UnmanagedType.Struct)] object varProp, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>The <b>Submit</b> method persists changes made to the <c>IAzApplication</c> object.</summary>
		/// <param name="lFlags">
		/// Flags that modify the behavior of the <b>Submit</b> method. The default value is zero. If the <b>AZ_SUBMIT_FLAG_ABORT</b> flag is
		/// specified, the changes to the object are discarded and the object is updated to match the underlying policy store.
		/// </param>
		/// <param name="varReserved">Reserved for future use.</param>
		/// <remarks>
		/// <para>Any additions or modifications to an <c>IAzApplication</c> object are not persisted until the <b>Submit</b> method is called.</para>
		/// <para>
		/// The <b>Submit</b> method does not extend to child objects; child objects must be individually persisted to the policy store. A
		/// created <c>IAzApplication</c> object must be submitted before it can be referenced or become a parent object. The destructor for
		/// an object silently discards unsubmitted changes.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazapplication-submit HRESULT Submit( [in] LONG lFlags,
		// [in, optional] VARIANT varReserved );
		[DispId(1610743854)]
		new void Submit([Optional, DefaultParameterValue((AZ_SUBMIT_FLAGS)0), In] AZ_SUBMIT_FLAGS lFlags, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>
		/// <para>
		/// The <b>InitializeClientContextFromName</b> method gets an <c>IAzClientContext</c> object pointer from the client identity as a
		/// (domain name, client name) pair.
		/// </para>
		/// <para>
		/// <b>Note</b>  If possible, call the <c>InitializeClientContextFromToken</c> function instead of
		/// <b>InitializeClientContextFromName</b>. For more information, see Remarks.
		/// </para>
		/// <para></para>
		/// </summary>
		/// <param name="ClientName">Name of the security principal.</param>
		/// <param name="DomainName">Domain name in which the user account resides. The default value is <b>NULL</b>.</param>
		/// <param name="varReserved">
		/// <para>Reserved for future use. This parameter can be one of the following values:</para>
		/// <list type="bullet">
		/// <item>
		/// <description>varReserved.vt == VT_ERROR and varReserved.scode == DISP_E_PARAMNOTFOUND</description>
		/// </item>
		/// <item>
		/// <description>varReserved.vt == VT_EMPTY</description>
		/// </item>
		/// <item>
		/// <description>varReserved.vt == VT_NULL</description>
		/// </item>
		/// <item>
		/// <description>varReserved.vt == VT_I4 and varReserved.lVal == 0</description>
		/// </item>
		/// <item>
		/// <description>varReserved.vt == VT_I2 and varReserved.iVal == 0</description>
		/// </item>
		/// </list>
		/// </param>
		/// <returns>A pointer to a pointer to the returned <c>IAzClientContext</c> object.</returns>
		/// <remarks>
		/// <para>
		/// If possible, call the <c>InitializeClientContextFromToken</c> function instead of <b>InitializeClientContextFromName</b>.
		/// <b>InitializeClientContextFromName</b> attempts to retrieve the information available in a logon token had the client actually
		/// logged on. An actual logon token provides more information, such as logon type and logon properties, and reflects the behavior of
		/// the authentication package used for the logon. The client context created by <b>InitializeClientContextFromToken</b> uses a logon
		/// token, and the resulting client context is more complete and accurate than a client context created by <b>InitializeClientContextFromName</b>.
		/// </para>
		/// <para>The <i>DomainName</i> and <i>ClientName</i> parameters must combine to represent a <c>SidTypeUser</c>.</para>
		/// <para>The supported name formats are the same as those supported by the <c>LookupAccountName</c> function.</para>
		/// <para>
		/// <b>Important</b>  Applications should not assume that the calling context has permission to use this function. The
		/// <c>AuthzInitializeContextFromSid</c> function reads the tokenGroupsGlobalAndUniversal attribute of the SID specified in the call
		/// to determine the current user's group memberships. If the user's object is in <c>Active Directory</c>, the calling context must
		/// have read access to the tokenGroupsGlobalAndUniversal attribute on the user object. Read access to the
		/// tokenGroupsGlobalAndUniversal attribute is granted to the <b>Pre-Windows 2000 Compatible Access</b> group, but new domains
		/// contain an empty <b>Pre-Windows 2000 Compatible Access</b> group by default because the default setup selection is <b>Permissions
		/// compatible with Windows 2000 and Windows Server 2003</b>. Therefore, applications may not have access to the
		/// tokenGroupsGlobalAndUniversal attribute; in this case, the <b>AuthzInitializeContextFromSid</b> function fails with
		/// ACCESS_DENIED. Applications that use this function should correctly handle this error and provide supporting documentation. To
		/// simplify granting accounts permission to query a user's group information, add accounts that need the ability to look up group
		/// information to the Windows Authorization Access Group.
		/// </para>
		/// <para></para>
		/// <para>
		/// Applications calling this function should use the fully qualified domain name or <c>user principal name</c> (UPN). Otherwise,
		/// this method might fail across forests if the NetBIOS domain name is used and the two domains do not have a direct trust relationship.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazapplication-initializeclientcontextfromname HRESULT
		// InitializeClientContextFromName( [in] BSTR ClientName, [in, optional] BSTR DomainName, [in, optional] VARIANT varReserved, [out]
		// IAzClientContext **ppClientContext );
		[DispId(1610743855)]
		[return: MarshalAs(UnmanagedType.Interface)]
		new IAzClientContext InitializeClientContextFromName([In, MarshalAs(UnmanagedType.BStr)] string ClientName, [Optional, DefaultParameterValue(null), In, MarshalAs(UnmanagedType.BStr)] string? DomainName,
			[Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>
		/// <para>
		/// The <b>DelegatedPolicyUsers</b> property retrieves the <c>security identifiers</c> (SIDs), in text form, of principals that act
		/// as delegated policy users.
		/// </para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// Delegated policy users are principals that are allowed to read the subset of the policy data that the policy administrator of an
		/// <c>IAzApplication</c> object uses to administer the delegated object.
		/// </para>
		/// <para><b>Note</b>  Delegated policy users are not supported for XML stores.</para>
		/// <para></para>
		/// <para>In JScript, the returned <c>SAFEARRAY</c> must be converted to the JScript <c>Array</c> object.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazapplication-get_delegatedpolicyusers HRESULT
		// get_DelegatedPolicyUsers( VARIANT *pvarDelegatedPolicyUsers );
		[DispId(1610743856)]
		new object DelegatedPolicyUsers
		{
			[DispId(1610743856)]
			[return: MarshalAs(UnmanagedType.Struct)]
			get;
		}

		/// <summary>
		/// The <b>AddDelegatedPolicyUser</b> method adds the specified <c>security identifier</c> (SID) in text form to the list of
		/// principals that act as delegated policy users.
		/// </summary>
		/// <param name="bstrDelegatedPolicyUser">Text form of the SID to add to the list of delegated policy users.</param>
		/// <param name="varReserved">
		/// <para>Reserved for future use. This parameter can be any of the following values:</para>
		/// <list type="bullet">
		/// <item>
		/// <description>varReserved.vt == VT_ERROR and varReserved.scode == DISP_E_PARAMNOTFOUND</description>
		/// </item>
		/// <item>
		/// <description>varReserved.vt == VT_EMPTY</description>
		/// </item>
		/// <item>
		/// <description>varReserved.vt == VT_NULL</description>
		/// </item>
		/// <item>
		/// <description>varReserved.vt == VT_I4 and varReserved.lVal == 0</description>
		/// </item>
		/// <item>
		/// <description>varReserved.vt == VT_I2 and varReserved.iVal == 0</description>
		/// </item>
		/// </list>
		/// </param>
		/// <remarks>
		/// <para>
		/// Delegated policy users are principals that are allowed to read the subset of the policy data that the policy administrator of an
		/// <c>IAzApplication</c> object uses to administer the delegated object.
		/// </para>
		/// <para><b>Note</b>  Delegated policy users are not supported for XML stores.</para>
		/// <para></para>
		/// <para>To view the list of delegated policy users, use the <c>DelegatedPolicyUsers</c> property.</para>
		/// <para>You must call the <c>Submit</c> method to persist any changes made by this method.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazapplication-adddelegatedpolicyuser HRESULT
		// AddDelegatedPolicyUser( [in] BSTR bstrDelegatedPolicyUser, [in, optional] VARIANT varReserved );
		[DispId(1610743857)]
		new void AddDelegatedPolicyUser([In, MarshalAs(UnmanagedType.BStr)] string bstrDelegatedPolicyUser, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>
		/// The <b>DeleteDelegatedPolicyUser</b> method removes the specified <c>security identifier</c> (SID) in text form from the list of
		/// principals that act as delegated policy users.
		/// </summary>
		/// <param name="bstrDelegatedPolicyUser">Text form of the SID to remove from the list of delegated policy users.</param>
		/// <param name="varReserved">Reserved for future use.</param>
		/// <remarks>
		/// <para>
		/// Delegated policy users are principals that are allowed to read the subset of the policy data that the policy administrator of an
		/// <c>IAzApplication</c> object uses to administer the delegated object.
		/// </para>
		/// <para>
		/// <para>Note</para>
		/// <para> Delegated policy users are not supported for XML stores.</para>
		/// </para>
		/// <para>To view the list of delegated policy users, use the <c>DelegatedPolicyUsers</c> property.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazapplication-deletedelegatedpolicyuser HRESULT
		// DeleteDelegatedPolicyUser( [in] BSTR bstrDelegatedPolicyUser, [in, optional] VARIANT varReserved );
		[DispId(1610743858)]
		new void DeleteDelegatedPolicyUser([In, MarshalAs(UnmanagedType.BStr)] string bstrDelegatedPolicyUser, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>
		/// <para>
		/// The <b>InitializeClientContextFromStringSid</b> method gets an <c>IAzClientContext</c> object pointer from the specified
		/// <c>security identifier</c> (SID) in text form.
		/// </para>
		/// <para>
		/// <b>Note</b>  If possible, call the <c>InitializeClientContextFromToken</c> function instead of
		/// <b>InitializeClientContextFromStringSid</b>. For more information, see Remarks.
		/// </para>
		/// <para></para>
		/// </summary>
		/// <param name="SidString">
		/// A string that contains the text form of the SID of the security principal. This must be a valid string SID that can be converted
		/// by the <c>ConvertStringSidToSid</c> function.
		/// </param>
		/// <param name="lOptions">
		/// <para>Options for the context creation.</para>
		/// <para>
		/// If AZ_CLIENT_CONTEXT_SKIP_GROUP is specified, the SID specified in the <i>SidString</i> parameter is not necessarily a valid user
		/// account. The SID will be used to create the context without validation. The created context will be flagged as having been
		/// created from a SID, the SID string will be stored in the client name field, and the domain name field will be empty. Token groups
		/// will not be used in the client context creation. <c>Lightweight Directory Access Protocol</c> (LDAP) query groups are not
		/// supported when AZ_CLIENT_CONTEXT_SKIP_GROUP is specified. Because the account is not validated in Active Directory, the client
		/// context's user information properties, such as <c>UserSamCompat</c>, will not be valid, and when accessed, they will return
		/// ERROR_INVALID_HANDLE. The <c>RoleForAccessCheck</c> property and the <c>AccessCheck</c> method of <c>IAzClientContext</c> can
		/// still be used to specify a role for access checking. The <c>GetRoles</c> method of <b>IAzClientContext</b> can still be used to
		/// enumerate roles assigned to the context within a specific scope.
		/// </para>
		/// <para>If AZ_CLIENT_CONTEXT_SKIP_GROUP is not specified, the SID must represent a valid user account.</para>
		/// </param>
		/// <param name="varReserved">
		/// <para>Reserved for future use. This parameter can be one of the following values:</para>
		/// <list type="bullet">
		/// <item>
		/// <description>varReserved.vt == VT_ERROR and varReserved.scode == DISP_E_PARAMNOTFOUND</description>
		/// </item>
		/// <item>
		/// <description>varReserved.vt == VT_EMPTY</description>
		/// </item>
		/// <item>
		/// <description>varReserved.vt == VT_NULL</description>
		/// </item>
		/// <item>
		/// <description>varReserved.vt == VT_I4 and varReserved.lVal == 0</description>
		/// </item>
		/// <item>
		/// <description>varReserved.vt == VT_I2 and varReserved.iVal == 0</description>
		/// </item>
		/// </list>
		/// </param>
		/// <returns>A pointer to a pointer to the returned <c>IAzClientContext</c> object.</returns>
		/// <remarks>
		/// <para>
		/// If possible, call the <c>InitializeClientContextFromToken</c> function instead of <b>InitializeClientContextFromStringSid</b>.
		/// <b>InitializeClientContextFromStringSid</b> attempts to retrieve the information available in a logon token had the client
		/// actually logged on. An actual logon token provides more information, such as logon type and logon properties, and reflects the
		/// behavior of the authentication package used for the logon. The client context created by <b>InitializeClientContextFromToken</b>
		/// uses a logon token, and the resulting client context is more complete and accurate than a client context created by <b>InitializeClientContextFromStringSid</b>.
		/// </para>
		/// <para>
		/// <b>Important</b>  Applications should not assume that the calling context has permission to use this function. The
		/// <c>AuthzInitializeContextFromSid</c> function reads the tokenGroupsGlobalAndUniversal attribute of the SID specified in the call
		/// to determine the current user's group memberships. If the user's object is in <c>Active Directory</c>, the calling context must
		/// have read access to the tokenGroupsGlobalAndUniversal attribute on the user object. Read access to the
		/// tokenGroupsGlobalAndUniversal attribute is granted to the <b>Pre-Windows 2000 Compatible Access</b> group, but new domains
		/// contain an empty <b>Pre-Windows 2000 Compatible Access</b> group by default because the default setup selection is <b>Permissions
		/// compatible with Windows 2000 and Windows Server 2003</b>. Therefore, applications may not have access to the
		/// tokenGroupsGlobalAndUniversal attribute; in this case, the <b>AuthzInitializeContextFromSid</b> function fails with
		/// ACCESS_DENIED. Applications that use this function should correctly handle this error and provide supporting documentation. To
		/// simplify granting accounts permission to query a user's group information, add accounts that need the ability to look up group
		/// information to the Windows Authorization Access Group.
		/// </para>
		/// <para></para>
		/// <para>
		/// Applications calling this function should use the fully qualified domain name or <c>user principal name</c> (UPN). Otherwise,
		/// this method might fail across forests if the NetBIOS domain name is used and the two domains do not have a direct trust relationship.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazapplication-initializeclientcontextfromstringsid HRESULT
		// InitializeClientContextFromStringSid( [in] BSTR SidString, [in] LONG lOptions, [in, optional] VARIANT varReserved, [out]
		// IAzClientContext **ppClientContext );
		[DispId(1610743859)]
		[return: MarshalAs(UnmanagedType.Interface)]
		new IAzClientContext InitializeClientContextFromStringSid([In, MarshalAs(UnmanagedType.BStr)] string SidString, [In] AZ_PROP_CONSTANTS lOptions, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>
		/// <para>The <b>PolicyAdministratorsName</b> property retrieves the account names of principals that act as policy administrators.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <remarks>
		/// <para>Policy administrators for an object can perform the following tasks:</para>
		/// <list type="bullet">
		/// <item>
		/// <description>Read the object</description>
		/// </item>
		/// <item>
		/// <description>Write attributes to the object</description>
		/// </item>
		/// <item>
		/// <description>Read attributes of child objects of the object</description>
		/// </item>
		/// <item>
		/// <description>Write attributes to child objects of the object</description>
		/// </item>
		/// <item>
		/// <description>Delete the object</description>
		/// </item>
		/// <item>
		/// <description>Delete child objects of the object</description>
		/// </item>
		/// <item>
		/// <description>Create child objects of the object</description>
		/// </item>
		/// </list>
		/// <para>In JScript, the returned <c>SAFEARRAY</c> must be converted to the JScript <c>Array</c> object.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazapplication-get_policyadministratorsname HRESULT
		// get_PolicyAdministratorsName( VARIANT *pvarAdmins );
		[DispId(1610743860)]
		new object PolicyAdministratorsName
		{
			[DispId(1610743860)]
			[return: MarshalAs(UnmanagedType.Struct)]
			get;
		}

		/// <summary>
		/// <para>The <b>PolicyReadersName</b> property retrieves the account names of principals that act as policy readers.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// Policy readers for an object can read attributes for the object and for child objects of the object. Readers can also use the
		/// policy; for example, readers can call the <c>AccessCheck</c> method. Readers cannot modify the object or its child objects.
		/// </para>
		/// <para>In JScript, the returned <c>SAFEARRAY</c> must be converted to the JScript <c>Array</c> object.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazapplication-get_policyreadersname HRESULT
		// get_PolicyReadersName( VARIANT *pvarReaders );
		[DispId(1610743861)]
		new object PolicyReadersName
		{
			[DispId(1610743861)]
			[return: MarshalAs(UnmanagedType.Struct)]
			get;
		}

		/// <summary>
		/// The <b>AddPolicyAdministratorName</b> method adds the specified account name to the list of principals that act as policy administrators.
		/// </summary>
		/// <param name="bstrAdmin">
		/// Account name to add to the list of policy administrators. The account name must be in user principal name (UPN) format (for
		/// example, "someone@example.com"). The <c>LookupAccountName</c> function is called to retrieve the domain.
		/// </param>
		/// <param name="varReserved">Reserved for future use.</param>
		/// <remarks>
		/// <para>Policy administrators for an object can perform the following tasks:</para>
		/// <list type="bullet">
		/// <item>
		/// <description>Read the object</description>
		/// </item>
		/// <item>
		/// <description>Write attributes to the object</description>
		/// </item>
		/// <item>
		/// <description>Read attributes of child objects of the object</description>
		/// </item>
		/// <item>
		/// <description>Write attributes to child objects of the object</description>
		/// </item>
		/// <item>
		/// <description>Delete the object</description>
		/// </item>
		/// <item>
		/// <description>Delete child objects of the object</description>
		/// </item>
		/// <item>
		/// <description>Create child objects of the object</description>
		/// </item>
		/// </list>
		/// <para>To view the list of policy administrators in account name format, use the <c>PolicyAdministratorsName</c> property.</para>
		/// <para>You must call the <c>Submit</c> method to persist any changes made by this method.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazapplication-addpolicyadministratorname HRESULT
		// AddPolicyAdministratorName( [in] BSTR bstrAdmin, [in, optional] VARIANT varReserved );
		[DispId(1610743862)]
		new void AddPolicyAdministratorName([In, MarshalAs(UnmanagedType.BStr)] string bstrAdmin, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>
		/// The <b>DeletePolicyAdministratorName</b> method removes the specified account name from the list of principals that act as policy administrators.
		/// </summary>
		/// <param name="bstrAdmin">
		/// Account name to remove from the list of policy administrators. The account name can be in either user principal name (UPN) format
		/// (for example, "someone@example.com") or in the format of "ExampleDomain\UserName". If the domain is not in the
		/// "ExampleDomain\UserName" format, the <c>LookupAccountName</c> function is called to retrieve the domain.
		/// </param>
		/// <param name="varReserved">Reserved for future use.</param>
		/// <remarks>
		/// <para>Policy administrators for an object can perform the following tasks:</para>
		/// <list type="bullet">
		/// <item>
		/// <description>Read the object</description>
		/// </item>
		/// <item>
		/// <description>Write attributes to the object</description>
		/// </item>
		/// <item>
		/// <description>Read attributes of child objects of the object</description>
		/// </item>
		/// <item>
		/// <description>Write attributes to child objects of the object</description>
		/// </item>
		/// <item>
		/// <description>Delete the object</description>
		/// </item>
		/// <item>
		/// <description>Delete child objects of the object</description>
		/// </item>
		/// <item>
		/// <description>Create child objects of the object</description>
		/// </item>
		/// </list>
		/// <para>To view the list of policy administrators in account name format, use the <c>PolicyAdministratorsName</c> property.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazapplication-deletepolicyadministratorname HRESULT
		// DeletePolicyAdministratorName( [in] BSTR bstrAdmin, [in, optional] VARIANT varReserved );
		[DispId(1610743863)]
		new void DeletePolicyAdministratorName([In, MarshalAs(UnmanagedType.BStr)] string bstrAdmin, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>
		/// The <b>AddPolicyReaderName</b> method adds the specified account name to the list of principals that act as policy readers.
		/// </summary>
		/// <param name="bstrReader">
		/// Account name to add to the list of policy readers. The account name must be in user principal name (UPN) format (for example,
		/// "someone@example.com"). The <c>LookupAccountName</c> function is called to retrieve the domain.
		/// </param>
		/// <param name="varReserved">Reserved for future use.</param>
		/// <remarks>
		/// <para>
		/// Policy readers for an object can read attributes for the object and for child objects of the object. Readers can also use the
		/// policy; for example, readers can call the <c>AccessCheck</c> method. Readers cannot modify the object or its child objects.
		/// </para>
		/// <para>To view the list of policy readers in account name format, use the <c>PolicyReadersName</c> property.</para>
		/// <para>You must call the <c>Submit</c> method to persist any changes made by this method.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazapplication-addpolicyreadername HRESULT
		// AddPolicyReaderName( [in] BSTR bstrReader, [in, optional] VARIANT varReserved );
		[DispId(1610743864)]
		new void AddPolicyReaderName([In, MarshalAs(UnmanagedType.BStr)] string bstrReader, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>
		/// The <b>DeletePolicyReaderName</b> method removes the specified account name from the list of principals that act as policy readers.
		/// </summary>
		/// <param name="bstrReader">
		/// The account name to remove from the list of policy readers. The account name can be in either user principal name (UPN) format
		/// (for example, "someone@example.com") or in the format of "ExampleDomain\UserName". If the domain is not in the
		/// "ExampleDomain\UserName" format, the <c>LookupAccountName</c> function is called to retrieve the domain.
		/// </param>
		/// <param name="varReserved">Reserved for future use.</param>
		/// <remarks>
		/// <para>
		/// Policy readers for an object can read attributes for the object and for child objects of the object. Readers can also use the
		/// policy; for example, readers can call the <c>AccessCheck</c> method. Readers cannot modify the object or its child objects.
		/// </para>
		/// <para>To view the list of policy readers in account name format, use the <c>PolicyReadersName</c> property.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazapplication-deletepolicyreadername HRESULT
		// DeletePolicyReaderName( [in] BSTR bstrReader, [in, optional] VARIANT varReserved );
		[DispId(1610743865)]
		new void DeletePolicyReaderName([In, MarshalAs(UnmanagedType.BStr)] string bstrReader, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>
		/// <para>The <b>DelegatedPolicyUsersName</b> property retrieves the account names of principals that act as delegated policy users.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// Delegated policy users are principals that are allowed to read the subset of the policy data that the policy administrator of an
		/// <c>IAzApplication</c> object uses to administer the delegated object.
		/// </para>
		/// <para><b>Note</b>  Delegated policy users are not supported for XML stores.</para>
		/// <para></para>
		/// <para>In JScript, the returned <c>SAFEARRAY</c> must be converted to the JScript <c>Array</c> object.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazapplication-get_delegatedpolicyusersname HRESULT
		// get_DelegatedPolicyUsersName( VARIANT *pvarDelegatedPolicyUsers );
		[DispId(1610743866)]
		new object DelegatedPolicyUsersName
		{
			[DispId(1610743866)]
			[return: MarshalAs(UnmanagedType.Struct)]
			get;
		}

		/// <summary>
		/// The <b>AddDelegatedPolicyUserName</b> method adds the specified account name to the list of principals that act as delegated
		/// policy users.
		/// </summary>
		/// <param name="bstrDelegatedPolicyUser">
		/// Account name to add to the list of delegated policy users. The account name must be in user principal name (UPN) format (for
		/// example, "someone@example.com"). The <c>LookupAccountName</c> function is called to retrieve the domain.
		/// </param>
		/// <param name="varReserved">Reserved for future use.</param>
		/// <remarks>
		/// <para>
		/// Delegated policy users are principals that are allowed to read the subset of the policy data that the policy administrator of an
		/// <c>IAzApplication</c> object uses to administer the delegated object.
		/// </para>
		/// <para><b>Note</b>  Delegated policy users are not supported for XML stores.</para>
		/// <para></para>
		/// <para>To view the list of delegated policy users in account name format, use the <c>DelegatedPolicyUsersName</c> property.</para>
		/// <para>You must call the <c>Submit</c> method to persist any changes made by this method.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazapplication-adddelegatedpolicyusername HRESULT
		// AddDelegatedPolicyUserName( [in] BSTR bstrDelegatedPolicyUser, [in, optional] VARIANT varReserved );
		[DispId(1610743867)]
		new void AddDelegatedPolicyUserName([In, MarshalAs(UnmanagedType.BStr)] string bstrDelegatedPolicyUser, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>
		/// The <b>DeleteDelegatedPolicyUserName</b> method removes the specified account name from the list of principals that act as
		/// delegated policy users.
		/// </summary>
		/// <param name="bstrDelegatedPolicyUser">
		/// The account name to remove from the list of delegated policy users. The account name must be in user principal name (UPN) format
		/// (for example, "someone@example.com"). The <c>LookupAccountName</c> function is called to retrieve the domain.
		/// </param>
		/// <param name="varReserved">Reserved for future use.</param>
		/// <remarks>
		/// <para>
		/// Delegated policy users are principals that are allowed to read the subset of the policy data that the policy administrator of an
		/// <c>IAzApplication</c> object uses to administer the delegated object.
		/// </para>
		/// <para><b>Note</b>  Delegated policy users are not supported for XML stores.</para>
		/// <para></para>
		/// <para>To view the list of delegated policy users in account name format, use the <c>DelegatedPolicyUsersName</c> property.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazapplication-deletedelegatedpolicyusername HRESULT
		// DeleteDelegatedPolicyUserName( [in] BSTR bstrDelegatedPolicyUser, [in, optional] VARIANT varReserved );
		[DispId(1610743868)]
		new void DeleteDelegatedPolicyUserName([In, MarshalAs(UnmanagedType.BStr)] string bstrDelegatedPolicyUser, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>
		/// The <b>InitializeClientContextFromToken2</b> method retrieves an <c>IAzClientContext2</c> object pointer from the specified
		/// client token.
		/// </summary>
		/// <param name="ulTokenHandleLowPart">
		/// Low byte of a handle to a token that specifies the client. If the values of both this parameter and the
		/// <i>ulTokenHandleHighPart</i> parameter are zero, the impersonation token of the caller's thread is used. If the thread does not
		/// have an impersonation token, the process token is used. The token must have been opened for TOKEN_QUERY, TOKEN_IMPERSONATE, or
		/// TOKEN_DUPLICATE access.
		/// </param>
		/// <param name="ulTokenHandleHighPart">
		/// High byte of a handle to a token that specifies the client. If the values of both this parameter and the
		/// <i>ulTokenHandleHighPart</i> parameter are zero, the impersonation token of the caller's thread is used. If the thread does not
		/// have an impersonation token, the process token is used. The token must have been opened for TOKEN_QUERY, TOKEN_IMPERSONATE, or
		/// TOKEN_DUPLICATE access.
		/// </param>
		/// <param name="varReserved">Reserved for future use.</param>
		/// <returns>A pointer to a pointer to the returned <c>IAzClientContext2</c> object.</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazapplication2-initializeclientcontextfromtoken2 HRESULT
		// InitializeClientContextFromToken2( [in] ULONG ulTokenHandleLowPart, [in] ULONG ulTokenHandleHighPart, [in, optional] VARIANT
		// varReserved, [out] IAzClientContext2 **ppClientContext );
		[DispId(1610809344)]
		[return: MarshalAs(UnmanagedType.Interface)]
		IAzClientContext2 InitializeClientContextFromToken2([In] uint ulTokenHandleLowPart, [In] uint ulTokenHandleHighPart, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>The <b>InitializeClientContext2</b> method retrieves an <c>IAzClientContext2</c> object pointer.</summary>
		/// <param name="IdentifyingString">
		/// A string that identifies the client context in the audit trail for client connection and object access audit entries.
		/// </param>
		/// <param name="varReserved">Reserved for future use.</param>
		/// <returns>A pointer to a pointer to the returned <c>IAzClientContext2</c> object.</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazapplication2-initializeclientcontext2 HRESULT
		// InitializeClientContext2( [in] BSTR IdentifyingString, [in, optional] VARIANT varReserved, [out] IAzClientContext2
		// **ppClientContext );
		[DispId(1610809345)]
		[return: MarshalAs(UnmanagedType.Interface)]
		IAzClientContext2 InitializeClientContext2([In, MarshalAs(UnmanagedType.BStr)] string IdentifyingString, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);
	}

	/// <summary>
	/// The <b>IAzApplication3</b> interface provides methods to manage <c>IAzRoleAssignment</c>, <c>IAzRoleDefinition</c>, and
	/// <c>IAzScope2</c> objects.
	/// </summary>
	// https://learn.microsoft.com/ka-ge/windows/win32/api/azroles/nn-azroles-iazapplication3
	[PInvokeData("azroles.h", MSDNShortId = "NN:azroles.IAzApplication3")]
	[ComImport, Guid("181C845E-7196-4A7D-AC2E-020C0BB7A303")]
	public interface IAzApplication3 : IAzApplication2
	{
		/// <summary>
		/// <para>The <b>Name</b> property sets or retrieves the name of the application.</para>
		/// <para>This property is read/write.</para>
		/// </summary>
		/// <remarks>The maximum length of the <b>Name</b> property is 512 characters.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazapplication-get_name HRESULT get_Name( BSTR *pbstrName );
		[DispId(1610743808)]
		new string Name
		{
			[DispId(1610743808)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
			[DispId(1610743808)]
			[param: In]
			[param: MarshalAs(UnmanagedType.BStr)]
			set;
		}

		/// <summary>
		/// <para>The <b>Description</b> property sets or retrieves a comment that describes the application.</para>
		/// <para>This property is read/write.</para>
		/// </summary>
		/// <remarks>The maximum length of the <b>Description</b> property is 1,024 characters.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazapplication-put_description HRESULT put_Description(
		// BSTR bstrDescription );
		[DispId(1610743810)]
		new string Description
		{
			[DispId(1610743810)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
			[DispId(1610743810)]
			[param: In]
			[param: MarshalAs(UnmanagedType.BStr)]
			set;
		}

		/// <summary>
		/// <para>The <b>ApplicationData</b> property sets or retrieves an opaque field that can be used by the application to store information.</para>
		/// <para>This property is read/write.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// <b>Important</b>  Policy administrators can read from and write to this property. Applications should not store data in the
		/// <b>ApplicationData</b> property that should not be available to the policy administrator.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazapplication-get_applicationdata HRESULT
		// get_ApplicationData( BSTR *pbstrApplicationData );
		[DispId(1610743812)]
		new string ApplicationData
		{
			[DispId(1610743812)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
			[DispId(1610743812)]
			[param: In]
			[param: MarshalAs(UnmanagedType.BStr)]
			set;
		}

		/// <summary>
		/// <para>
		/// The <b>AuthzInterfaceClsid</b> property sets or retrieves the class identifier (CLSID) of the interface that the user interface
		/// (UI) uses to perform application-specific operations.
		/// </para>
		/// <para>This property is read/write.</para>
		/// </summary>
		/// <remarks>A CLSID is a GUID associated with a COM class.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazapplication-get_authzinterfaceclsid HRESULT
		// get_AuthzInterfaceClsid( BSTR *pbstrProp );
		[DispId(1610743814)]
		new string AuthzInterfaceClsid
		{
			[DispId(1610743814)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
			[DispId(1610743814)]
			[param: In]
			[param: MarshalAs(UnmanagedType.BStr)]
			set;
		}

		/// <summary>
		/// <para>The <b>Version</b> property sets or retrieves the version of the application.</para>
		/// <para>This property is read/write.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazapplication-get_version HRESULT get_Version( BSTR
		// *pbstrProp );
		[DispId(1610743816)]
		new string Version
		{
			[DispId(1610743816)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
			[DispId(1610743816)]
			[param: In]
			[param: MarshalAs(UnmanagedType.BStr)]
			set;
		}

		/// <summary>
		/// <para>The <b>GenerateAudits</b> property sets or retrieves a value that indicates whether run-time audits should be generated.</para>
		/// <para>This property is read/write.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// The <b>GenerateAudits</b> property controls client context creation, client context deletion, and access check run-time auditing.
		/// The client context can be created by a <c>security identifier</c> (SID), name, or token.
		/// </para>
		/// <para>The <c>AzAuthorizationStore.GenerateAudits</c> property controls application initialization auditing.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazapplication-get_generateaudits HRESULT
		// get_GenerateAudits( BOOL *pbProp );
		[DispId(1610743818)]
		new bool GenerateAudits
		{
			[DispId(1610743818)]
			[return: MarshalAs(UnmanagedType.Bool)]
			get;
			[DispId(1610743818)]
			[param: In, MarshalAs(UnmanagedType.Bool)]
			set;
		}

		/// <summary>
		/// <para>
		/// The <b>ApplyStoreSacl</b> property sets or retrieves a value that indicates whether policy audits should be generated when the
		/// authorization store is modified.
		/// </para>
		/// <para>This property is read/write.</para>
		/// </summary>
		/// <remarks>
		/// <para>Policy audits are generated when the underlying policy store is modified. Both success and failure audits are requested.</para>
		/// <para>This property controls policy auditing only for the <c>IAzApplication</c> object and its child objects.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazapplication-get_applystoresacl HRESULT
		// get_ApplyStoreSacl( BOOL *pbProp );
		[DispId(1610743820)]
		new bool ApplyStoreSacl
		{
			[DispId(1610743820)]
			[return: MarshalAs(UnmanagedType.Bool)]
			get;
			[DispId(1610743820)]
			[param: In, MarshalAs(UnmanagedType.Bool)]
			set;
		}

		/// <summary>
		/// <para>
		/// The <b>Writable</b> property retrieves a value that indicates whether the object can be modified by the user context that
		/// initialized it.
		/// </para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazapplication-get_writable HRESULT get_Writable( BOOL
		// *pfProp );
		[DispId(1610743822)]
		new bool Writable
		{
			[DispId(1610743822)]
			[return: MarshalAs(UnmanagedType.Bool)]
			get;
		}

		/// <summary>The <b>GetProperty</b> method returns the <c>IAzApplication</c> object property with the specified property ID.</summary>
		/// <param name="lPropId">
		/// <para>Property ID of the <c>IAzApplication</c> object property to return. The following table shows the possible values.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Value</description>
		/// <description>Meaning</description>
		/// </listheader>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_APPLICATION_AUTHZ_INTERFACE_CLSID</b></description>
		/// <description>Also accessed through the <c>AuthzInterfaceClsid</c> property</description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_APPLICATION_DATA</b></description>
		/// <description>Also accessed through the <c>ApplicationData</c> property</description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_APPLICATION_VERSION</b></description>
		/// <description>Also accessed through the <c>Version</c> property</description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_APPLY_STORE_SACL</b></description>
		/// <description>Also accessed through the <c>ApplyStoreSacl</c> property</description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_CHILD_CREATE</b></description>
		/// <description>
		/// Determines whether the current user has permission to create child objects. This value is <b>TRUE</b> if the current user has
		/// permission; otherwise, <b>FALSE</b>.
		/// </description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_DELEGATED_POLICY_USERS</b></description>
		/// <description>Also accessed through the <c>DelegatedPolicyUsers</c> property</description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_DELEGATED_POLICY_USERS_NAME</b></description>
		/// <description>Also accessed through the <c>DelegatedPolicyUsersName</c> property</description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_DESCRIPTION</b></description>
		/// <description>Also accessed through the <c>Description</c> property</description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_GENERATE_AUDITS</b></description>
		/// <description>Also accessed through the <c>GenerateAudits</c> property</description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_NAME</b></description>
		/// <description>Also accessed through the <c>Name</c> property</description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_POLICY_ADMINS</b></description>
		/// <description>Also accessed through the <c>PolicyAdministrators</c> property</description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_POLICY_ADMINS_NAME</b></description>
		/// <description>Also accessed through the <c>PolicyAdministratorsName</c> property</description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_POLICY_READERS</b></description>
		/// <description>Also accessed through the <c>PolicyReaders</c> property</description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_POLICY_READERS_NAME</b></description>
		/// <description>Also accessed through the <c>PolicyReadersName</c> property</description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_WRITABLE</b></description>
		/// <description>Also accessed through the <c>Writable</c> property</description>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="varReserved">Reserved for future use.</param>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazapplication-getproperty HRESULT GetProperty( [in] LONG
		// lPropId, [in, optional] VARIANT varReserved, [out] VARIANT *pvarProp );
		[DispId(1610743823)]
		[return: MarshalAs(UnmanagedType.Struct)]
		new object GetProperty([In] AZ_PROP_CONSTANTS lPropId, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>
		/// The <b>SetProperty</b> method sets the specified value to the <c>IAzApplication</c> object property with the specified property ID.
		/// </summary>
		/// <param name="lPropId">
		/// <para>Property ID of the <c>IAzApplication</c> object property to set. The following table shows the possible values.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Value</description>
		/// <description>Meaning</description>
		/// </listheader>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_APPLICATION_DATA</b></description>
		/// <description>Also accessed through the <c>ApplicationData</c> property</description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_APPLICATION_AUTHZ_INTERFACE_CLSID</b></description>
		/// <description>Also accessed through the <c>AuthzInterfaceClsid</c> property</description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_APPLICATION_VERSION</b></description>
		/// <description>Also accessed through the <c>Version</c> property</description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_APPLY_STORE_SACL</b></description>
		/// <description>Also accessed through the <c>ApplyStoreSacl</c> property</description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_DESCRIPTION</b></description>
		/// <description>Also accessed through the <c>Description</c> property</description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_GENERATE_AUDITS</b></description>
		/// <description>Also accessed through the <c>GenerateAudits</c> property</description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_NAME</b></description>
		/// <description>Also accessed through the <c>Name</c> property</description>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="varProp">
		/// <para>
		/// Value to set to the <c>IAzApplication</c> object property specified by the <i>lPropId</i> parameter. The type of data that must
		/// be used depends on the value of the <i>lPropId</i> parameter.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <description><i>lPropId</i> value</description>
		/// <description>Data type (C++/Visual Basic)</description>
		/// </listheader>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_APPLICATION_DATA</b></description>
		/// <description><b>BSTR</b>/ <b>String</b></description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_APPLICATION_INTERFACE_CLSID</b></description>
		/// <description><b>BSTR</b>/ <b>String</b></description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_APPLICATION_VERSION</b></description>
		/// <description><b>BSTR</b>/ <b>String</b></description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_APPLY_STORE_SACL</b></description>
		/// <description><b>BSTR</b>/ <b>String</b></description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_DESCRIPTION</b></description>
		/// <description><b>BSTR</b>/ <b>String</b></description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_GENERATE_AUDITS</b></description>
		/// <description><b>BSTR</b>/ <b>String</b></description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_NAME</b></description>
		/// <description><b>BSTR</b>/ <b>String</b></description>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="varReserved">Reserved for future use.</param>
		/// <remarks>You must call the <c>Submit</c> method to persist any changes made by this method.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazapplication-setproperty HRESULT SetProperty( [in] LONG
		// lPropId, [in] VARIANT varProp, [in, optional] VARIANT varReserved );
		[DispId(1610743824)]
		new void SetProperty([In] AZ_PROP_CONSTANTS lPropId, [In, MarshalAs(UnmanagedType.Struct)] object varProp, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>
		/// <para>
		/// The <b>PolicyAdministrators</b> property retrieves the <c>security identifiers</c> (SIDs) of principals that act as policy
		/// administrators in text form.
		/// </para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <remarks>
		/// <para>Policy administrators for an object can perform the following tasks:</para>
		/// <list type="bullet">
		/// <item>
		/// <description>Read the object</description>
		/// </item>
		/// <item>
		/// <description>Write attributes to the object</description>
		/// </item>
		/// <item>
		/// <description>Read attributes of child objects of the object</description>
		/// </item>
		/// <item>
		/// <description>Write attributes to child objects of the object</description>
		/// </item>
		/// <item>
		/// <description>Delete the object</description>
		/// </item>
		/// <item>
		/// <description>Delete child objects of the object</description>
		/// </item>
		/// <item>
		/// <description>Create child objects of the object</description>
		/// </item>
		/// </list>
		/// <para>In JScript, the returned <c>SAFEARRAY</c> must be converted to the JScript <c>Array</c> object.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazauthorizationstore-get_policyadministrators HRESULT
		// get_PolicyAdministrators( VARIANT *pvarAdmins );
		[DispId(1610743825)]
		new object PolicyAdministrators
		{
			[DispId(1610743825)]
			[return: MarshalAs(UnmanagedType.Struct)]
			get;
		}

		/// <summary>
		/// <para>
		/// The <b>PolicyReaders</b> property retrieves the <c>security identifiers</c> (SIDs) of principals that act as policy readers in
		/// text form.
		/// </para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// Policy readers for an object can read attributes for the object and for child objects of the object. Readers can also use the
		/// policy; for example, readers can call the <c>AccessCheck</c> method. Readers cannot modify the object or its child objects.
		/// </para>
		/// <para>In JScript, the returned <c>SAFEARRAY</c> must be converted to the JScript <c>Array</c> object.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazauthorizationstore-get_policyreaders HRESULT
		// get_PolicyReaders( VARIANT *pvarReaders );
		[DispId(1610743826)]
		new object PolicyReaders
		{
			[DispId(1610743826)]
			[return: MarshalAs(UnmanagedType.Struct)]
			get;
		}

		/// <summary>
		/// The <b>AddPolicyAdministrator</b> method adds the specified <c>security identifier</c> (SID) in text form to the list of
		/// principals that act as policy administrators.
		/// </summary>
		/// <param name="bstrAdmin">Text form of the SID to add to the list of policy administrators.</param>
		/// <param name="varReserved">Reserved for future use.</param>
		/// <remarks>
		/// <para>Policy administrators for an object can perform the following tasks:</para>
		/// <list type="bullet">
		/// <item>
		/// <description>Read the object</description>
		/// </item>
		/// <item>
		/// <description>Write attributes to the object</description>
		/// </item>
		/// <item>
		/// <description>Read attributes of child objects of the object</description>
		/// </item>
		/// <item>
		/// <description>Write attributes to child objects of the object</description>
		/// </item>
		/// <item>
		/// <description>Delete the object</description>
		/// </item>
		/// <item>
		/// <description>Delete child objects of the object</description>
		/// </item>
		/// <item>
		/// <description>Create child objects of the object</description>
		/// </item>
		/// </list>
		/// <para>To view the list of policy administrators, use the <c>PolicyAdministrators</c> property.</para>
		/// <para>You must call the <c>Submit</c> method to persist any changes made by this method.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazapplication-addpolicyadministrator HRESULT
		// AddPolicyAdministrator( [in] BSTR bstrAdmin, [in, optional] VARIANT varReserved );
		[DispId(1610743827)]
		new void AddPolicyAdministrator([In, MarshalAs(UnmanagedType.BStr)] string bstrAdmin, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>
		/// The <b>DeletePolicyAdministrator</b> method removes the specified <c>security identifier</c> (SID) in text form from the list of
		/// principals that act as policy administrators.
		/// </summary>
		/// <param name="bstrAdmin">Text form of the SID to remove from the list of policy administrators.</param>
		/// <param name="varReserved">Reserved for future use.</param>
		/// <remarks>
		/// <para>Policy administrators for an object can perform the following tasks:</para>
		/// <list type="bullet">
		/// <item>
		/// <description>Read the object</description>
		/// </item>
		/// <item>
		/// <description>Write attributes to the object</description>
		/// </item>
		/// <item>
		/// <description>Read attributes of child objects of the object</description>
		/// </item>
		/// <item>
		/// <description>Write attributes to child objects of the object</description>
		/// </item>
		/// <item>
		/// <description>Delete the object</description>
		/// </item>
		/// <item>
		/// <description>Delete child objects of the object</description>
		/// </item>
		/// <item>
		/// <description>Create child objects of the object</description>
		/// </item>
		/// </list>
		/// <para>To view the list of policy administrators, use the <c>PolicyAdministrators</c> property.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazapplication-deletepolicyadministrator HRESULT
		// DeletePolicyAdministrator( [in] BSTR bstrAdmin, [in, optional] VARIANT varReserved );
		[DispId(1610743828)]
		new void DeletePolicyAdministrator([In, MarshalAs(UnmanagedType.BStr)] string bstrAdmin, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>
		/// The <b>AddPolicyReader</b> method adds the specified <c>security identifier</c> (SID) in text form to the list of principals that
		/// act as policy readers.
		/// </summary>
		/// <param name="bstrReader">Text form of the SID to add to the list of policy readers.</param>
		/// <param name="varReserved">Reserved for future use.</param>
		/// <remarks>
		/// <para>
		/// Policy readers for an object can read attributes for the object and for child objects of the object. Readers can also use the
		/// policy; for example, readers can call the <c>AccessCheck</c> method. Readers cannot modify the object or its child objects.
		/// </para>
		/// <para>To view the list of policy readers, use the <c>PolicyReaders</c> property.</para>
		/// <para>You must call the <c>Submit</c> method to persist any changes made by this method.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazapplication-addpolicyreader HRESULT AddPolicyReader(
		// [in] BSTR bstrReader, [in, optional] VARIANT varReserved );
		[DispId(1610743829)]
		new void AddPolicyReader([In, MarshalAs(UnmanagedType.BStr)] string bstrReader, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>
		/// The <b>DeletePolicyReader</b> method removes the specified <c>security identifier</c> (SID) in text form from the list of
		/// principals that act as policy readers.
		/// </summary>
		/// <param name="bstrReader">Text form of the SID to remove from the list of policy readers.</param>
		/// <param name="varReserved">Reserved for future use.</param>
		/// <remarks>
		/// <para>
		/// Policy readers for an object can read attributes for the object and for child objects of the object. Readers can also use the
		/// policy; for example, readers can call the <c>AccessCheck</c> method. Readers cannot modify the object or its child objects.
		/// </para>
		/// <para>To view the list of policy readers, use the <c>PolicyReaders</c> property.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazapplication-deletepolicyreader HRESULT
		// DeletePolicyReader( [in] BSTR bstrReader, [in, optional] VARIANT varReserved );
		[DispId(1610743830)]
		new void DeletePolicyReader([In, MarshalAs(UnmanagedType.BStr)] string bstrReader, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>
		/// <para>
		/// The <b>Scopes</b> property retrieves an <c>IAzScopes</c> object that is used to enumerate <c>IAzScope</c> objects from the policy data.
		/// </para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <remarks>
		/// This property can be used only to enumerate <c>IAzScope</c> objects that are direct child objects of the <c>IAzApplication</c> object.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazapplication-get_scopes HRESULT get_Scopes( IAzScopes
		// **ppScopeCollection );
		[DispId(1610743831)]
		new IAzScopes Scopes
		{
			[DispId(1610743831)]
			[return: MarshalAs(UnmanagedType.Interface)]
			get;
		}

		/// <summary>The <b>OpenScope</b> method opens an <c>IAzScope</c> object with the specified name.</summary>
		/// <param name="bstrScopeName">Name of the <c>IAzScope</c> object to open.</param>
		/// <param name="varReserved">Reserved for future use.</param>
		/// <returns>A pointer to a pointer to the opened <c>IAzScope</c> object.</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazapplication-openscope HRESULT OpenScope( [in] BSTR
		// bstrScopeName, [in, optional] VARIANT varReserved, [out] IAzScope **ppScope );
		[DispId(1610743832)]
		[return: MarshalAs(UnmanagedType.Interface)]
		new IAzScope OpenScope([In, MarshalAs(UnmanagedType.BStr)] string bstrScopeName, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>The <b>CreateScope</b> method creates an <c>IAzScope</c> object with the specified name.</summary>
		/// <param name="bstrScopeName">Name for the new <c>IAzScope</c> object.</param>
		/// <param name="varReserved">Reserved for future use.</param>
		/// <returns>A pointer to a pointer to the created <c>IAzScope</c> object.</returns>
		/// <remarks>
		/// <para>You must call the <c>IAzScope::Submit</c> method to persist any changes made to the returned object.</para>
		/// <para>The returned <c>IAzScope</c> object is an immediate child object of the <c>IAzApplication</c> object.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazapplication-createscope HRESULT CreateScope( [in] BSTR
		// bstrScopeName, [in, optional] VARIANT varReserved, [out] IAzScope **ppScope );
		[DispId(1610743833)]
		[return: MarshalAs(UnmanagedType.Interface)]
		new IAzScope CreateScope([In, MarshalAs(UnmanagedType.BStr)] string bstrScopeName, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>
		/// The <b>DeleteScope</b> method removes the <c>IAzScope</c> object with the specified name from the <c>IAzApplication</c> object.
		/// </summary>
		/// <param name="bstrScopeName">Name of the <c>IAzScope</c> object to delete.</param>
		/// <param name="varReserved">Reserved for future use.</param>
		/// <remarks>
		/// If there are any <c>IAzScope</c> references to an <b>IAzScope</b> object that has been deleted from the cache, the
		/// <b>IAzScope</b> object can no longer be used. In C++, you must release references to deleted <b>IAzScope</b> objects by calling
		/// the <c>IUnknown::Release</c> method. In C# and Visual Basic, references to deleted objects are automatically released.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazapplication-deletescope HRESULT DeleteScope( [in] BSTR
		// bstrScopeName, [in, optional] VARIANT varReserved );
		[DispId(1610743834)]
		new void DeleteScope([In, MarshalAs(UnmanagedType.BStr)] string bstrScopeName, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>
		/// <para>
		/// The <b>Operations</b> property retrieves an <c>IAzOperations</c> object that is used to enumerate <c>IAzOperation</c> objects
		/// from the policy data.
		/// </para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <remarks>
		/// This property can be used only to enumerate <c>IAzOperation</c> objects that are direct child objects of the
		/// <c>IAzApplication</c> object.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazapplication-get_operations HRESULT get_Operations(
		// IAzOperations **ppOperationCollection );
		[DispId(1610743835)]
		new IAzOperations Operations
		{
			[DispId(1610743835)]
			[return: MarshalAs(UnmanagedType.Interface)]
			get;
		}

		/// <summary>The <b>OpenOperation</b> method opens an <c>IAzOperation</c> object with the specified name.</summary>
		/// <param name="bstrOperationName">Name of the <c>IAzOperation</c> object to open.</param>
		/// <param name="varReserved">Reserved for future use.</param>
		/// <returns>A pointer to a pointer to the opened <c>IAzOperation</c> object.</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazapplication-openoperation HRESULT OpenOperation( [in]
		// BSTR bstrOperationName, [in, optional] VARIANT varReserved, [out] IAzOperation **ppOperation );
		[DispId(1610743836)]
		[return: MarshalAs(UnmanagedType.Interface)]
		new IAzOperation OpenOperation([In, MarshalAs(UnmanagedType.BStr)] string bstrOperationName, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>The <b>CreateOperation</b> method creates an <c>IAzOperation</c> object with the specified name.</summary>
		/// <param name="bstrOperationName">Name for the new <c>IAzOperation</c> object.</param>
		/// <param name="varReserved">Reserved for future use.</param>
		/// <returns>A pointer to a pointer to the created <c>IAzOperation</c> object.</returns>
		/// <remarks>
		/// <para>You must call the <c>IAzOperation::Submit</c> method to persist any changes made to the returned object.</para>
		/// <para>The returned <c>IAzOperation</c> object is an immediate child object of the <c>IAzApplication</c> object.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazapplication-createoperation HRESULT CreateOperation(
		// [in] BSTR bstrOperationName, [in, optional] VARIANT varReserved, [out] IAzOperation **ppOperation );
		[DispId(1610743837)]
		[return: MarshalAs(UnmanagedType.Interface)]
		new IAzOperation CreateOperation([In, MarshalAs(UnmanagedType.BStr)] string bstrOperationName, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>
		/// The <b>DeleteOperation</b> method removes the <c>IAzOperation</c> object with the specified name from the <c>IAzApplication</c> object.
		/// </summary>
		/// <param name="bstrOperationName">Name of the <c>IAzApplication</c> object to delete.</param>
		/// <param name="varReserved">Reserved for future use.</param>
		/// <remarks>
		/// If there are any <c>IAzApplication</c> references to an <b>IAzOperation</b> object that has been deleted from the cache, the
		/// <b>IAzOperation</b> object can no longer be used. In C++, you must release references to deleted <b>IAzOperation</b> objects by
		/// calling the <c>IUnknown::Release</c> method. In C# and Visual Basic, references to deleted objects are automatically released.
		/// </remarks>
		// https://learn.microsoft.com/sl-si/windows/win32/api/azroles/nf-azroles-iazapplication-deleteoperation HRESULT DeleteOperation(
		// [in] BSTR bstrOperationName, [in, optional] VARIANT varReserved );
		[DispId(1610743838)]
		new void DeleteOperation([In, MarshalAs(UnmanagedType.BStr)] string bstrOperationName, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>
		/// <para>
		/// The <b>Tasks</b> property retrieves an <c>IAzTasks</c> object that is used to enumerate <c>IAzTask</c> objects from the policy data.
		/// </para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <remarks>
		/// This property can be used only to enumerate <c>IAzTask</c> objects that are direct child objects of the <c>IAzApplication</c> object.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazapplication-get_tasks HRESULT get_Tasks( IAzTasks
		// **ppTaskCollection );
		[DispId(1610743839)]
		new IAzTasks Tasks
		{
			[DispId(1610743839)]
			[return: MarshalAs(UnmanagedType.Interface)]
			get;
		}

		/// <summary>The <b>OpenTask</b> method opens an <c>IAzTask</c> object with the specified name.</summary>
		/// <param name="bstrTaskName">Name of the <c>IAzTask</c> object to open.</param>
		/// <param name="varReserved">Reserved for future use.</param>
		/// <returns>A pointer to a pointer to the opened <c>IAzTask</c> object.</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazapplication-opentask HRESULT OpenTask( [in] BSTR
		// bstrTaskName, [in, optional] VARIANT varReserved, [out] IAzTask **ppTask );
		[DispId(1610743840)]
		[return: MarshalAs(UnmanagedType.Interface)]
		new IAzTask OpenTask([In, MarshalAs(UnmanagedType.BStr)] string bstrTaskName, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>The <b>CreateTask</b> method creates an <c>IAzTask</c> object with the specified name.</summary>
		/// <param name="bstrTaskName">Name for the new <c>IAzTask</c> object.</param>
		/// <param name="varReserved">Reserved for future use.</param>
		/// <returns>A pointer to a pointer to the created <c>IAzTask</c> object.</returns>
		/// <remarks>
		/// <para>You must call the <c>IAzTask::Submit</c> method to persist any changes made to the returned object.</para>
		/// <para>The returned <c>IAzTask</c> object is an immediate child object of the <c>IAzApplication</c> object.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazapplication-createtask HRESULT CreateTask( [in] BSTR
		// bstrTaskName, [in, optional] VARIANT varReserved, [out] IAzTask **ppTask );
		[DispId(1610743841)]
		[return: MarshalAs(UnmanagedType.Interface)]
		new IAzTask CreateTask([In, MarshalAs(UnmanagedType.BStr)] string bstrTaskName, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>
		/// The <b>DeleteTask</b> method removes the <c>IAzTask</c> object with the specified name from the <c>IAzApplication</c> object.
		/// </summary>
		/// <param name="bstrTaskName">Name of the <c>IAzTask</c> object to delete.</param>
		/// <param name="varReserved">Reserved for future use.</param>
		/// <remarks>
		/// If there are any <c>IAzTask</c> references to an <b>IAzTask</b> object that has been deleted from the cache, the <b>IAzTask</b>
		/// object can no longer be used. In C++, you must release references to deleted <b>IAzTask</b> objects by calling the
		/// <c>IUnknown::Release</c> method. In C# and Visual Basic, references to deleted objects are automatically released.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazapplication-deletetask HRESULT DeleteTask( [in] BSTR
		// bstrTaskName, [in, optional] VARIANT varReserved );
		[DispId(1610743842)]
		new void DeleteTask([In, MarshalAs(UnmanagedType.BStr)] string bstrTaskName, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>
		/// <para>
		/// The <b>ApplicationGroups</b> property retrieves an <c>IAzApplicationGroups</c> object that is used to enumerate
		/// <c>IAzApplicationGroup</c> objects from the policy data.
		/// </para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <remarks>
		/// This property can be used only to enumerate <c>IAzApplicationGroup</c> objects that are direct child objects of the
		/// <c>IAzApplication</c> object.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazapplication-get_applicationgroups HRESULT
		// get_ApplicationGroups( IAzApplicationGroups **ppGroupCollection );
		[DispId(1610743843)]
		new IAzApplicationGroups ApplicationGroups
		{
			[DispId(1610743843)]
			[return: MarshalAs(UnmanagedType.Interface)]
			get;
		}

		/// <summary>The <b>OpenApplicationGroup</b> method opens an <c>IAzApplicationGroup</c> object with the specified name.</summary>
		/// <param name="bstrGroupName">Name of the <c>IAzApplicationGroup</c> object to open.</param>
		/// <param name="varReserved">Reserved for future use.</param>
		/// <returns>A pointer to a pointer to the opened <c>IAzApplicationGroup</c> object.</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazapplication-openapplicationgroup HRESULT
		// OpenApplicationGroup( [in] BSTR bstrGroupName, [in, optional] VARIANT varReserved, [out] IAzApplicationGroup **ppGroup );
		[DispId(1610743844)]
		[return: MarshalAs(UnmanagedType.Interface)]
		new IAzApplicationGroup OpenApplicationGroup([In, MarshalAs(UnmanagedType.BStr)] string bstrGroupName, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>The <b>CreateApplicationGroup</b> method creates an <c>IAzApplicationGroup</c> object with the specified name.</summary>
		/// <param name="bstrGroupName">Name for the new <c>IAzApplicationGroup</c> object.</param>
		/// <param name="varReserved">Reserved for future use.</param>
		/// <returns>A pointer to a pointer to the created <c>IAzApplicationGroup</c> object.</returns>
		/// <remarks>
		/// <para>You must call the <c>IAzApplicationGroup::Submit</c> method to persist any changes made to the returned object.</para>
		/// <para>The returned <c>IAzApplicationGroup</c> object is an immediate child object of the <c>IAzApplication</c> object.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazapplication-createapplicationgroup HRESULT
		// CreateApplicationGroup( [in] BSTR bstrGroupName, [in, optional] VARIANT varReserved, [out] IAzApplicationGroup **ppGroup );
		[DispId(1610743845)]
		[return: MarshalAs(UnmanagedType.Interface)]
		new IAzApplicationGroup CreateApplicationGroup([In, MarshalAs(UnmanagedType.BStr)] string bstrGroupName, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>
		/// The <b>DeleteApplicationGroup</b> method removes the <c>IAzApplicationGroup</c> object with the specified name from the
		/// <c>IAzApplication</c> object.
		/// </summary>
		/// <param name="bstrGroupName">Name of the <c>IAzApplicationGroup</c> object to delete.</param>
		/// <param name="varReserved">Reserved for future use.</param>
		/// <remarks>
		/// If there are any <c>IAzApplicationGroup</c> references to an <b>IAzApplicationGroup</b> object that has been deleted from the
		/// cache, the <b>IAzApplicationGroup</b> object can no longer be used. In C++, you must release references to deleted
		/// <b>IAzApplicationGroup</b> objects by calling the <c>IUnknown::Release</c> method. In C# and Visual Basic, references to deleted
		/// objects are automatically released.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazapplication-deleteapplicationgroup HRESULT
		// DeleteApplicationGroup( [in] BSTR bstrGroupName, [in, optional] VARIANT varReserved );
		[DispId(1610743846)]
		new void DeleteApplicationGroup([In, MarshalAs(UnmanagedType.BStr)] string bstrGroupName, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>
		/// <para>
		/// The <b>Roles</b> property retrieves an <c>IAzRoles</c> object that is used to enumerate <c>IAzRole</c> objects from the policy data.
		/// </para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <remarks>
		/// This property can be used only to enumerate <c>IAzRole</c> objects that are direct child objects of the <c>IAzApplication</c> object.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazapplication-get_roles HRESULT get_Roles( IAzRoles
		// **ppRoleCollection );
		[DispId(1610743847)]
		new IAzRoles Roles
		{
			[DispId(1610743847)]
			[return: MarshalAs(UnmanagedType.Interface)]
			get;
		}

		/// <summary>The <b>OpenRole</b> method opens an <c>IAzRole</c> object with the specified name.</summary>
		/// <param name="bstrRoleName">Name of the <c>IAzRole</c> object to open.</param>
		/// <param name="varReserved">Reserved for future use.</param>
		/// <returns>A pointer to a pointer to the opened <c>IAzRole</c> object.</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazapplication-openrole HRESULT OpenRole( [in] BSTR
		// bstrRoleName, [in, optional] VARIANT varReserved, [out] IAzRole **ppRole );
		[DispId(1610743848)]
		[return: MarshalAs(UnmanagedType.Interface)]
		new IAzRole OpenRole([In, MarshalAs(UnmanagedType.BStr)] string bstrRoleName, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>The <b>CreateRole</b> method creates an <c>IAzRole</c> object with the specified name.</summary>
		/// <param name="bstrRoleName">Name for the new <c>IAzRole</c> object.</param>
		/// <param name="varReserved">Reserved for future use.</param>
		/// <returns>A pointer to a pointer to the created <c>IAzRole</c> object.</returns>
		/// <remarks>
		/// <para>You must call the <c>IAzRole::Submit</c> method to persist any changes made to the returned object.</para>
		/// <para>The returned <c>IAzRole</c> object is an immediate child object of the <c>IAzApplication</c> object.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazapplication-createrole HRESULT CreateRole( [in] BSTR
		// bstrRoleName, [in, optional] VARIANT varReserved, [out] IAzRole **ppRole );
		[DispId(1610743849)]
		[return: MarshalAs(UnmanagedType.Interface)]
		new IAzRole CreateRole([In, MarshalAs(UnmanagedType.BStr)] string bstrRoleName, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>
		/// The <b>DeleteRole</b> method removes the <c>IAzRole</c> object with the specified name from the <c>IAzApplication</c> object.
		/// </summary>
		/// <param name="bstrRoleName">Name of the <c>IAzRole</c> object to delete.</param>
		/// <param name="varReserved">Reserved for future use.</param>
		/// <remarks>
		/// If there are any <c>IAzRole</c> references to an <b>IAzRole</b> object that has been deleted from the cache, the <b>IAzRole</b>
		/// object can no longer be used. In C++, you must release references to deleted <b>IAzRole</b> objects by calling the
		/// <c>IUnknown::Release</c> method. In C# and Visual Basic, references to deleted objects are automatically released.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazapplication-deleterole HRESULT DeleteRole( [in] BSTR
		// bstrRoleName, [in, optional] VARIANT varReserved );
		[DispId(1610743850)]
		new void DeleteRole([In, MarshalAs(UnmanagedType.BStr)] string bstrRoleName, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>
		/// The <b>InitializeClientContextFromToken</b> method gets an <c>IAzClientContext</c> object pointer from the specified client token.
		/// </summary>
		/// <param name="ullTokenHandle">
		/// A handle to a Windows token that specifies the client. If this parameter is <b>NULL</b>, the impersonation token of the caller's
		/// thread is used. If the thread does not have an impersonation token, the process token is used. The token must have been opened
		/// for TOKEN_QUERY, TOKEN_IMPERSONATE, and TOKEN_DUPLICATE access.
		/// </param>
		/// <param name="varReserved">Reserved for future use.</param>
		/// <returns>A pointer to a pointer to the returned <c>IAzClientContext</c> object.</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazapplication-initializeclientcontextfromtoken HRESULT
		// InitializeClientContextFromToken( [in] ULONGLONG ullTokenHandle, [in, optional] VARIANT varReserved, [out] IAzClientContext
		// **ppClientContext );
		[DispId(1610743851)]
		[return: MarshalAs(UnmanagedType.Interface)]
		new IAzClientContext InitializeClientContextFromToken([In, Optional] ulong ullTokenHandle, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>The <b>AddPropertyItem</b> method adds the specified principal to the specified list of principals.</summary>
		/// <param name="lPropId">
		/// <para>
		/// Property ID of the list of principals to which to add the principal specified by the <i>varProp</i> parameter. The following
		/// table shows the possible values.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <description>Value</description>
		/// <description>Meaning</description>
		/// </listheader>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_POLICY_ADMINS</b></description>
		/// <description>Can also be added using the <c>AddPolicyAdministrator</c> method</description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_POLICY_ADMINS_NAME</b></description>
		/// <description>Can also be added using the <c>AddPolicyAdministratorName</c> method</description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_POLICY_READERS</b></description>
		/// <description>Can also be added using the <c>AddPolicyReader</c> method</description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_POLICY_READERS_NAME</b></description>
		/// <description>Can also be added using the <c>AddPolicyReaderName</c> method</description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_DELEGATED_POLICY_USERS</b></description>
		/// <description>Can also be added using the <c>AddDelegatedPolicyUser</c> method</description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_DELEGATED_POLICY_USERS_NAME</b></description>
		/// <description>Can also be added using the <c>AddDelegatedPolicyUserName</c> method</description>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="varProp">
		/// <para>Principal to add to the list of principals specified by the <i>lPropId</i> parameter.</para>
		/// <para>The variant must be a <b>BSTR</b> variant.</para>
		/// <para>
		/// If AZ_PROP_POLICY_ADMINS_NAME, AZ_PROP_POLICY_READERS_NAME, or AZ_PROP_DELEGATED_POLICY_USERS_NAME is specified for the
		/// <i>lPropId</i> parameter, the string is the account name of the account to add to the list. The account name must be in user
		/// principal name (UPN) format (for example, "someone@example.com").
		/// </para>
		/// </param>
		/// <param name="varReserved">Reserved for future use.</param>
		/// <remarks>You must call the <c>Submit</c> method to persist any changes made by this method.</remarks>
		// https://learn.microsoft.com/mt-mt/windows/win32/api/azroles/nf-azroles-iazapplication-addpropertyitem HRESULT AddPropertyItem(
		// [in] LONG lPropId, [in] VARIANT varProp, [in, optional] VARIANT varReserved );
		[DispId(1610743852)]
		new void AddPropertyItem([In] AZ_PROP_CONSTANTS lPropId, [In, MarshalAs(UnmanagedType.Struct)] object varProp, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>The <b>DeletePropertyItem</b> method removes the specified principal from the specified list of principals.</summary>
		/// <param name="lPropId">
		/// <para>
		/// Property ID of the list of principals from which to remove the principal specified by the <i>varProp</i> parameter. The following
		/// table shows the possible values.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <description>Value</description>
		/// <description>Meaning</description>
		/// </listheader>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_POLICY_ADMINS</b></description>
		/// <description>Can also be removed using the <c>DeletePolicyAdministrator</c> method</description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_POLICY_ADMINS_NAME</b></description>
		/// <description>Can also be removed using the <c>DeletePolicyAdministratorName</c> method</description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_POLICY_READERS</b></description>
		/// <description>Can also be removed using the <c>DeletePolicyReader</c> method</description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_POLICY_READERS_NAME</b></description>
		/// <description>Can also be removed using the <c>DeletePolicyReaderName</c> method</description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_DELEGATED_POLICY_USERS</b></description>
		/// <description>Can also be removed using the <c>DeleteDelegatedPolicyUser</c> method</description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_DELEGATED_POLICY_USERS_NAME</b></description>
		/// <description>Can also be removed using the <c>DeleteDelegatedPolicyUserName</c> method</description>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="varProp">
		/// <para>Principal to remove from the list of principals specified by the <i>lPropId</i> parameter.</para>
		/// <para>The variant must be a <b>BSTR</b> variant.</para>
		/// <para>
		/// If AZ_PROP_POLICY_ADMINS, AZ_PROP_POLICY_READERS, or AZ_PROP_DELEGATED_POLICY_USERS is specified for the <i>lPropId</i>
		/// parameter, the string is the text form of the <c>security identifier</c> (SID) of the Windows account to remove from the list. If
		/// AZ_PROP_POLICY_ADMINS_NAME, AZ_PROP_POLICY_READERS_NAME, or AZ_PROP_DELEGATED_POLICY_USERS_NAME is specified for the
		/// <i>lPropId</i> parameter, the string is the account name of the account to remove from the list. The account name can be in
		/// either user principal name (UPN) format (for example, "someone@example.com") or in the format of "ExampleDomain\UserName".
		/// </para>
		/// </param>
		/// <param name="varReserved">Reserved for future use.</param>
		/// <remarks>You must call the <c>Submit</c> method to persist any changes made by this method.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazapplication-deletepropertyitem HRESULT
		// DeletePropertyItem( [in] LONG lPropId, [in] VARIANT varProp, [in, optional] VARIANT varReserved );
		[DispId(1610743853)]
		new void DeletePropertyItem([In] AZ_PROP_CONSTANTS lPropId, [In, MarshalAs(UnmanagedType.Struct)] object varProp, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>The <b>Submit</b> method persists changes made to the <c>IAzApplication</c> object.</summary>
		/// <param name="lFlags">
		/// Flags that modify the behavior of the <b>Submit</b> method. The default value is zero. If the <b>AZ_SUBMIT_FLAG_ABORT</b> flag is
		/// specified, the changes to the object are discarded and the object is updated to match the underlying policy store.
		/// </param>
		/// <param name="varReserved">Reserved for future use.</param>
		/// <remarks>
		/// <para>Any additions or modifications to an <c>IAzApplication</c> object are not persisted until the <b>Submit</b> method is called.</para>
		/// <para>
		/// The <b>Submit</b> method does not extend to child objects; child objects must be individually persisted to the policy store. A
		/// created <c>IAzApplication</c> object must be submitted before it can be referenced or become a parent object. The destructor for
		/// an object silently discards unsubmitted changes.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazapplication-submit HRESULT Submit( [in] LONG lFlags,
		// [in, optional] VARIANT varReserved );
		[DispId(1610743854)]
		new void Submit([Optional, DefaultParameterValue((AZ_SUBMIT_FLAGS)0), In] AZ_SUBMIT_FLAGS lFlags, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>
		/// <para>
		/// The <b>InitializeClientContextFromName</b> method gets an <c>IAzClientContext</c> object pointer from the client identity as a
		/// (domain name, client name) pair.
		/// </para>
		/// <para>
		/// <b>Note</b>  If possible, call the <c>InitializeClientContextFromToken</c> function instead of
		/// <b>InitializeClientContextFromName</b>. For more information, see Remarks.
		/// </para>
		/// <para></para>
		/// </summary>
		/// <param name="ClientName">Name of the security principal.</param>
		/// <param name="DomainName">Domain name in which the user account resides. The default value is <b>NULL</b>.</param>
		/// <param name="varReserved">
		/// <para>Reserved for future use. This parameter can be one of the following values:</para>
		/// <list type="bullet">
		/// <item>
		/// <description>varReserved.vt == VT_ERROR and varReserved.scode == DISP_E_PARAMNOTFOUND</description>
		/// </item>
		/// <item>
		/// <description>varReserved.vt == VT_EMPTY</description>
		/// </item>
		/// <item>
		/// <description>varReserved.vt == VT_NULL</description>
		/// </item>
		/// <item>
		/// <description>varReserved.vt == VT_I4 and varReserved.lVal == 0</description>
		/// </item>
		/// <item>
		/// <description>varReserved.vt == VT_I2 and varReserved.iVal == 0</description>
		/// </item>
		/// </list>
		/// </param>
		/// <returns>A pointer to a pointer to the returned <c>IAzClientContext</c> object.</returns>
		/// <remarks>
		/// <para>
		/// If possible, call the <c>InitializeClientContextFromToken</c> function instead of <b>InitializeClientContextFromName</b>.
		/// <b>InitializeClientContextFromName</b> attempts to retrieve the information available in a logon token had the client actually
		/// logged on. An actual logon token provides more information, such as logon type and logon properties, and reflects the behavior of
		/// the authentication package used for the logon. The client context created by <b>InitializeClientContextFromToken</b> uses a logon
		/// token, and the resulting client context is more complete and accurate than a client context created by <b>InitializeClientContextFromName</b>.
		/// </para>
		/// <para>The <i>DomainName</i> and <i>ClientName</i> parameters must combine to represent a <c>SidTypeUser</c>.</para>
		/// <para>The supported name formats are the same as those supported by the <c>LookupAccountName</c> function.</para>
		/// <para>
		/// <b>Important</b>  Applications should not assume that the calling context has permission to use this function. The
		/// <c>AuthzInitializeContextFromSid</c> function reads the tokenGroupsGlobalAndUniversal attribute of the SID specified in the call
		/// to determine the current user's group memberships. If the user's object is in <c>Active Directory</c>, the calling context must
		/// have read access to the tokenGroupsGlobalAndUniversal attribute on the user object. Read access to the
		/// tokenGroupsGlobalAndUniversal attribute is granted to the <b>Pre-Windows 2000 Compatible Access</b> group, but new domains
		/// contain an empty <b>Pre-Windows 2000 Compatible Access</b> group by default because the default setup selection is <b>Permissions
		/// compatible with Windows 2000 and Windows Server 2003</b>. Therefore, applications may not have access to the
		/// tokenGroupsGlobalAndUniversal attribute; in this case, the <b>AuthzInitializeContextFromSid</b> function fails with
		/// ACCESS_DENIED. Applications that use this function should correctly handle this error and provide supporting documentation. To
		/// simplify granting accounts permission to query a user's group information, add accounts that need the ability to look up group
		/// information to the Windows Authorization Access Group.
		/// </para>
		/// <para></para>
		/// <para>
		/// Applications calling this function should use the fully qualified domain name or <c>user principal name</c> (UPN). Otherwise,
		/// this method might fail across forests if the NetBIOS domain name is used and the two domains do not have a direct trust relationship.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazapplication-initializeclientcontextfromname HRESULT
		// InitializeClientContextFromName( [in] BSTR ClientName, [in, optional] BSTR DomainName, [in, optional] VARIANT varReserved, [out]
		// IAzClientContext **ppClientContext );
		[DispId(1610743855)]
		[return: MarshalAs(UnmanagedType.Interface)]
		new IAzClientContext InitializeClientContextFromName([In, MarshalAs(UnmanagedType.BStr)] string ClientName, [Optional, DefaultParameterValue(null), In, MarshalAs(UnmanagedType.BStr)] string? DomainName,
			[Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>
		/// <para>
		/// The <b>DelegatedPolicyUsers</b> property retrieves the <c>security identifiers</c> (SIDs), in text form, of principals that act
		/// as delegated policy users.
		/// </para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// Delegated policy users are principals that are allowed to read the subset of the policy data that the policy administrator of an
		/// <c>IAzApplication</c> object uses to administer the delegated object.
		/// </para>
		/// <para><b>Note</b>  Delegated policy users are not supported for XML stores.</para>
		/// <para></para>
		/// <para>In JScript, the returned <c>SAFEARRAY</c> must be converted to the JScript <c>Array</c> object.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazapplication-get_delegatedpolicyusers HRESULT
		// get_DelegatedPolicyUsers( VARIANT *pvarDelegatedPolicyUsers );
		[DispId(1610743856)]
		new object DelegatedPolicyUsers
		{
			[DispId(1610743856)]
			[return: MarshalAs(UnmanagedType.Struct)]
			get;
		}

		/// <summary>
		/// The <b>AddDelegatedPolicyUser</b> method adds the specified <c>security identifier</c> (SID) in text form to the list of
		/// principals that act as delegated policy users.
		/// </summary>
		/// <param name="bstrDelegatedPolicyUser">Text form of the SID to add to the list of delegated policy users.</param>
		/// <param name="varReserved">
		/// <para>Reserved for future use. This parameter can be any of the following values:</para>
		/// <list type="bullet">
		/// <item>
		/// <description>varReserved.vt == VT_ERROR and varReserved.scode == DISP_E_PARAMNOTFOUND</description>
		/// </item>
		/// <item>
		/// <description>varReserved.vt == VT_EMPTY</description>
		/// </item>
		/// <item>
		/// <description>varReserved.vt == VT_NULL</description>
		/// </item>
		/// <item>
		/// <description>varReserved.vt == VT_I4 and varReserved.lVal == 0</description>
		/// </item>
		/// <item>
		/// <description>varReserved.vt == VT_I2 and varReserved.iVal == 0</description>
		/// </item>
		/// </list>
		/// </param>
		/// <remarks>
		/// <para>
		/// Delegated policy users are principals that are allowed to read the subset of the policy data that the policy administrator of an
		/// <c>IAzApplication</c> object uses to administer the delegated object.
		/// </para>
		/// <para><b>Note</b>  Delegated policy users are not supported for XML stores.</para>
		/// <para></para>
		/// <para>To view the list of delegated policy users, use the <c>DelegatedPolicyUsers</c> property.</para>
		/// <para>You must call the <c>Submit</c> method to persist any changes made by this method.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazapplication-adddelegatedpolicyuser HRESULT
		// AddDelegatedPolicyUser( [in] BSTR bstrDelegatedPolicyUser, [in, optional] VARIANT varReserved );
		[DispId(1610743857)]
		new void AddDelegatedPolicyUser([In, MarshalAs(UnmanagedType.BStr)] string bstrDelegatedPolicyUser, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>
		/// The <b>DeleteDelegatedPolicyUser</b> method removes the specified <c>security identifier</c> (SID) in text form from the list of
		/// principals that act as delegated policy users.
		/// </summary>
		/// <param name="bstrDelegatedPolicyUser">Text form of the SID to remove from the list of delegated policy users.</param>
		/// <param name="varReserved">Reserved for future use.</param>
		/// <remarks>
		/// <para>
		/// Delegated policy users are principals that are allowed to read the subset of the policy data that the policy administrator of an
		/// <c>IAzApplication</c> object uses to administer the delegated object.
		/// </para>
		/// <para>
		/// <para>Note</para>
		/// <para> Delegated policy users are not supported for XML stores.</para>
		/// </para>
		/// <para>To view the list of delegated policy users, use the <c>DelegatedPolicyUsers</c> property.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazapplication-deletedelegatedpolicyuser HRESULT
		// DeleteDelegatedPolicyUser( [in] BSTR bstrDelegatedPolicyUser, [in, optional] VARIANT varReserved );
		[DispId(1610743858)]
		new void DeleteDelegatedPolicyUser([In, MarshalAs(UnmanagedType.BStr)] string bstrDelegatedPolicyUser, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>
		/// <para>
		/// The <b>InitializeClientContextFromStringSid</b> method gets an <c>IAzClientContext</c> object pointer from the specified
		/// <c>security identifier</c> (SID) in text form.
		/// </para>
		/// <para>
		/// <b>Note</b>  If possible, call the <c>InitializeClientContextFromToken</c> function instead of
		/// <b>InitializeClientContextFromStringSid</b>. For more information, see Remarks.
		/// </para>
		/// <para></para>
		/// </summary>
		/// <param name="SidString">
		/// A string that contains the text form of the SID of the security principal. This must be a valid string SID that can be converted
		/// by the <c>ConvertStringSidToSid</c> function.
		/// </param>
		/// <param name="lOptions">
		/// <para>Options for the context creation.</para>
		/// <para>
		/// If AZ_CLIENT_CONTEXT_SKIP_GROUP is specified, the SID specified in the <i>SidString</i> parameter is not necessarily a valid user
		/// account. The SID will be used to create the context without validation. The created context will be flagged as having been
		/// created from a SID, the SID string will be stored in the client name field, and the domain name field will be empty. Token groups
		/// will not be used in the client context creation. <c>Lightweight Directory Access Protocol</c> (LDAP) query groups are not
		/// supported when AZ_CLIENT_CONTEXT_SKIP_GROUP is specified. Because the account is not validated in Active Directory, the client
		/// context's user information properties, such as <c>UserSamCompat</c>, will not be valid, and when accessed, they will return
		/// ERROR_INVALID_HANDLE. The <c>RoleForAccessCheck</c> property and the <c>AccessCheck</c> method of <c>IAzClientContext</c> can
		/// still be used to specify a role for access checking. The <c>GetRoles</c> method of <b>IAzClientContext</b> can still be used to
		/// enumerate roles assigned to the context within a specific scope.
		/// </para>
		/// <para>If AZ_CLIENT_CONTEXT_SKIP_GROUP is not specified, the SID must represent a valid user account.</para>
		/// </param>
		/// <param name="varReserved">
		/// <para>Reserved for future use. This parameter can be one of the following values:</para>
		/// <list type="bullet">
		/// <item>
		/// <description>varReserved.vt == VT_ERROR and varReserved.scode == DISP_E_PARAMNOTFOUND</description>
		/// </item>
		/// <item>
		/// <description>varReserved.vt == VT_EMPTY</description>
		/// </item>
		/// <item>
		/// <description>varReserved.vt == VT_NULL</description>
		/// </item>
		/// <item>
		/// <description>varReserved.vt == VT_I4 and varReserved.lVal == 0</description>
		/// </item>
		/// <item>
		/// <description>varReserved.vt == VT_I2 and varReserved.iVal == 0</description>
		/// </item>
		/// </list>
		/// </param>
		/// <returns>A pointer to a pointer to the returned <c>IAzClientContext</c> object.</returns>
		/// <remarks>
		/// <para>
		/// If possible, call the <c>InitializeClientContextFromToken</c> function instead of <b>InitializeClientContextFromStringSid</b>.
		/// <b>InitializeClientContextFromStringSid</b> attempts to retrieve the information available in a logon token had the client
		/// actually logged on. An actual logon token provides more information, such as logon type and logon properties, and reflects the
		/// behavior of the authentication package used for the logon. The client context created by <b>InitializeClientContextFromToken</b>
		/// uses a logon token, and the resulting client context is more complete and accurate than a client context created by <b>InitializeClientContextFromStringSid</b>.
		/// </para>
		/// <para>
		/// <b>Important</b>  Applications should not assume that the calling context has permission to use this function. The
		/// <c>AuthzInitializeContextFromSid</c> function reads the tokenGroupsGlobalAndUniversal attribute of the SID specified in the call
		/// to determine the current user's group memberships. If the user's object is in <c>Active Directory</c>, the calling context must
		/// have read access to the tokenGroupsGlobalAndUniversal attribute on the user object. Read access to the
		/// tokenGroupsGlobalAndUniversal attribute is granted to the <b>Pre-Windows 2000 Compatible Access</b> group, but new domains
		/// contain an empty <b>Pre-Windows 2000 Compatible Access</b> group by default because the default setup selection is <b>Permissions
		/// compatible with Windows 2000 and Windows Server 2003</b>. Therefore, applications may not have access to the
		/// tokenGroupsGlobalAndUniversal attribute; in this case, the <b>AuthzInitializeContextFromSid</b> function fails with
		/// ACCESS_DENIED. Applications that use this function should correctly handle this error and provide supporting documentation. To
		/// simplify granting accounts permission to query a user's group information, add accounts that need the ability to look up group
		/// information to the Windows Authorization Access Group.
		/// </para>
		/// <para></para>
		/// <para>
		/// Applications calling this function should use the fully qualified domain name or <c>user principal name</c> (UPN). Otherwise,
		/// this method might fail across forests if the NetBIOS domain name is used and the two domains do not have a direct trust relationship.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazapplication-initializeclientcontextfromstringsid HRESULT
		// InitializeClientContextFromStringSid( [in] BSTR SidString, [in] LONG lOptions, [in, optional] VARIANT varReserved, [out]
		// IAzClientContext **ppClientContext );
		[DispId(1610743859)]
		[return: MarshalAs(UnmanagedType.Interface)]
		new IAzClientContext InitializeClientContextFromStringSid([In, MarshalAs(UnmanagedType.BStr)] string SidString, [In] AZ_PROP_CONSTANTS lOptions, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>
		/// <para>The <b>PolicyAdministratorsName</b> property retrieves the account names of principals that act as policy administrators.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <remarks>
		/// <para>Policy administrators for an object can perform the following tasks:</para>
		/// <list type="bullet">
		/// <item>
		/// <description>Read the object</description>
		/// </item>
		/// <item>
		/// <description>Write attributes to the object</description>
		/// </item>
		/// <item>
		/// <description>Read attributes of child objects of the object</description>
		/// </item>
		/// <item>
		/// <description>Write attributes to child objects of the object</description>
		/// </item>
		/// <item>
		/// <description>Delete the object</description>
		/// </item>
		/// <item>
		/// <description>Delete child objects of the object</description>
		/// </item>
		/// <item>
		/// <description>Create child objects of the object</description>
		/// </item>
		/// </list>
		/// <para>In JScript, the returned <c>SAFEARRAY</c> must be converted to the JScript <c>Array</c> object.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazapplication-get_policyadministratorsname HRESULT
		// get_PolicyAdministratorsName( VARIANT *pvarAdmins );
		[DispId(1610743860)]
		new object PolicyAdministratorsName
		{
			[DispId(1610743860)]
			[return: MarshalAs(UnmanagedType.Struct)]
			get;
		}

		/// <summary>
		/// <para>The <b>PolicyReadersName</b> property retrieves the account names of principals that act as policy readers.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// Policy readers for an object can read attributes for the object and for child objects of the object. Readers can also use the
		/// policy; for example, readers can call the <c>AccessCheck</c> method. Readers cannot modify the object or its child objects.
		/// </para>
		/// <para>In JScript, the returned <c>SAFEARRAY</c> must be converted to the JScript <c>Array</c> object.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazapplication-get_policyreadersname HRESULT
		// get_PolicyReadersName( VARIANT *pvarReaders );
		[DispId(1610743861)]
		new object PolicyReadersName
		{
			[DispId(1610743861)]
			[return: MarshalAs(UnmanagedType.Struct)]
			get;
		}

		/// <summary>
		/// The <b>AddPolicyAdministratorName</b> method adds the specified account name to the list of principals that act as policy administrators.
		/// </summary>
		/// <param name="bstrAdmin">
		/// Account name to add to the list of policy administrators. The account name must be in user principal name (UPN) format (for
		/// example, "someone@example.com"). The <c>LookupAccountName</c> function is called to retrieve the domain.
		/// </param>
		/// <param name="varReserved">Reserved for future use.</param>
		/// <remarks>
		/// <para>Policy administrators for an object can perform the following tasks:</para>
		/// <list type="bullet">
		/// <item>
		/// <description>Read the object</description>
		/// </item>
		/// <item>
		/// <description>Write attributes to the object</description>
		/// </item>
		/// <item>
		/// <description>Read attributes of child objects of the object</description>
		/// </item>
		/// <item>
		/// <description>Write attributes to child objects of the object</description>
		/// </item>
		/// <item>
		/// <description>Delete the object</description>
		/// </item>
		/// <item>
		/// <description>Delete child objects of the object</description>
		/// </item>
		/// <item>
		/// <description>Create child objects of the object</description>
		/// </item>
		/// </list>
		/// <para>To view the list of policy administrators in account name format, use the <c>PolicyAdministratorsName</c> property.</para>
		/// <para>You must call the <c>Submit</c> method to persist any changes made by this method.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazapplication-addpolicyadministratorname HRESULT
		// AddPolicyAdministratorName( [in] BSTR bstrAdmin, [in, optional] VARIANT varReserved );
		[DispId(1610743862)]
		new void AddPolicyAdministratorName([In, MarshalAs(UnmanagedType.BStr)] string bstrAdmin, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>
		/// The <b>DeletePolicyAdministratorName</b> method removes the specified account name from the list of principals that act as policy administrators.
		/// </summary>
		/// <param name="bstrAdmin">
		/// Account name to remove from the list of policy administrators. The account name can be in either user principal name (UPN) format
		/// (for example, "someone@example.com") or in the format of "ExampleDomain\UserName". If the domain is not in the
		/// "ExampleDomain\UserName" format, the <c>LookupAccountName</c> function is called to retrieve the domain.
		/// </param>
		/// <param name="varReserved">Reserved for future use.</param>
		/// <remarks>
		/// <para>Policy administrators for an object can perform the following tasks:</para>
		/// <list type="bullet">
		/// <item>
		/// <description>Read the object</description>
		/// </item>
		/// <item>
		/// <description>Write attributes to the object</description>
		/// </item>
		/// <item>
		/// <description>Read attributes of child objects of the object</description>
		/// </item>
		/// <item>
		/// <description>Write attributes to child objects of the object</description>
		/// </item>
		/// <item>
		/// <description>Delete the object</description>
		/// </item>
		/// <item>
		/// <description>Delete child objects of the object</description>
		/// </item>
		/// <item>
		/// <description>Create child objects of the object</description>
		/// </item>
		/// </list>
		/// <para>To view the list of policy administrators in account name format, use the <c>PolicyAdministratorsName</c> property.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazapplication-deletepolicyadministratorname HRESULT
		// DeletePolicyAdministratorName( [in] BSTR bstrAdmin, [in, optional] VARIANT varReserved );
		[DispId(1610743863)]
		new void DeletePolicyAdministratorName([In, MarshalAs(UnmanagedType.BStr)] string bstrAdmin, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>
		/// The <b>AddPolicyReaderName</b> method adds the specified account name to the list of principals that act as policy readers.
		/// </summary>
		/// <param name="bstrReader">
		/// Account name to add to the list of policy readers. The account name must be in user principal name (UPN) format (for example,
		/// "someone@example.com"). The <c>LookupAccountName</c> function is called to retrieve the domain.
		/// </param>
		/// <param name="varReserved">Reserved for future use.</param>
		/// <remarks>
		/// <para>
		/// Policy readers for an object can read attributes for the object and for child objects of the object. Readers can also use the
		/// policy; for example, readers can call the <c>AccessCheck</c> method. Readers cannot modify the object or its child objects.
		/// </para>
		/// <para>To view the list of policy readers in account name format, use the <c>PolicyReadersName</c> property.</para>
		/// <para>You must call the <c>Submit</c> method to persist any changes made by this method.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazapplication-addpolicyreadername HRESULT
		// AddPolicyReaderName( [in] BSTR bstrReader, [in, optional] VARIANT varReserved );
		[DispId(1610743864)]
		new void AddPolicyReaderName([In, MarshalAs(UnmanagedType.BStr)] string bstrReader, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>
		/// The <b>DeletePolicyReaderName</b> method removes the specified account name from the list of principals that act as policy readers.
		/// </summary>
		/// <param name="bstrReader">
		/// The account name to remove from the list of policy readers. The account name can be in either user principal name (UPN) format
		/// (for example, "someone@example.com") or in the format of "ExampleDomain\UserName". If the domain is not in the
		/// "ExampleDomain\UserName" format, the <c>LookupAccountName</c> function is called to retrieve the domain.
		/// </param>
		/// <param name="varReserved">Reserved for future use.</param>
		/// <remarks>
		/// <para>
		/// Policy readers for an object can read attributes for the object and for child objects of the object. Readers can also use the
		/// policy; for example, readers can call the <c>AccessCheck</c> method. Readers cannot modify the object or its child objects.
		/// </para>
		/// <para>To view the list of policy readers in account name format, use the <c>PolicyReadersName</c> property.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazapplication-deletepolicyreadername HRESULT
		// DeletePolicyReaderName( [in] BSTR bstrReader, [in, optional] VARIANT varReserved );
		[DispId(1610743865)]
		new void DeletePolicyReaderName([In, MarshalAs(UnmanagedType.BStr)] string bstrReader, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>
		/// <para>The <b>DelegatedPolicyUsersName</b> property retrieves the account names of principals that act as delegated policy users.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// Delegated policy users are principals that are allowed to read the subset of the policy data that the policy administrator of an
		/// <c>IAzApplication</c> object uses to administer the delegated object.
		/// </para>
		/// <para><b>Note</b>  Delegated policy users are not supported for XML stores.</para>
		/// <para></para>
		/// <para>In JScript, the returned <c>SAFEARRAY</c> must be converted to the JScript <c>Array</c> object.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazapplication-get_delegatedpolicyusersname HRESULT
		// get_DelegatedPolicyUsersName( VARIANT *pvarDelegatedPolicyUsers );
		[DispId(1610743866)]
		new object DelegatedPolicyUsersName
		{
			[DispId(1610743866)]
			[return: MarshalAs(UnmanagedType.Struct)]
			get;
		}

		/// <summary>
		/// The <b>AddDelegatedPolicyUserName</b> method adds the specified account name to the list of principals that act as delegated
		/// policy users.
		/// </summary>
		/// <param name="bstrDelegatedPolicyUser">
		/// Account name to add to the list of delegated policy users. The account name must be in user principal name (UPN) format (for
		/// example, "someone@example.com"). The <c>LookupAccountName</c> function is called to retrieve the domain.
		/// </param>
		/// <param name="varReserved">Reserved for future use.</param>
		/// <remarks>
		/// <para>
		/// Delegated policy users are principals that are allowed to read the subset of the policy data that the policy administrator of an
		/// <c>IAzApplication</c> object uses to administer the delegated object.
		/// </para>
		/// <para><b>Note</b>  Delegated policy users are not supported for XML stores.</para>
		/// <para></para>
		/// <para>To view the list of delegated policy users in account name format, use the <c>DelegatedPolicyUsersName</c> property.</para>
		/// <para>You must call the <c>Submit</c> method to persist any changes made by this method.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazapplication-adddelegatedpolicyusername HRESULT
		// AddDelegatedPolicyUserName( [in] BSTR bstrDelegatedPolicyUser, [in, optional] VARIANT varReserved );
		[DispId(1610743867)]
		new void AddDelegatedPolicyUserName([In, MarshalAs(UnmanagedType.BStr)] string bstrDelegatedPolicyUser, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>
		/// The <b>DeleteDelegatedPolicyUserName</b> method removes the specified account name from the list of principals that act as
		/// delegated policy users.
		/// </summary>
		/// <param name="bstrDelegatedPolicyUser">
		/// The account name to remove from the list of delegated policy users. The account name must be in user principal name (UPN) format
		/// (for example, "someone@example.com"). The <c>LookupAccountName</c> function is called to retrieve the domain.
		/// </param>
		/// <param name="varReserved">Reserved for future use.</param>
		/// <remarks>
		/// <para>
		/// Delegated policy users are principals that are allowed to read the subset of the policy data that the policy administrator of an
		/// <c>IAzApplication</c> object uses to administer the delegated object.
		/// </para>
		/// <para><b>Note</b>  Delegated policy users are not supported for XML stores.</para>
		/// <para></para>
		/// <para>To view the list of delegated policy users in account name format, use the <c>DelegatedPolicyUsersName</c> property.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazapplication-deletedelegatedpolicyusername HRESULT
		// DeleteDelegatedPolicyUserName( [in] BSTR bstrDelegatedPolicyUser, [in, optional] VARIANT varReserved );
		[DispId(1610743868)]
		new void DeleteDelegatedPolicyUserName([In, MarshalAs(UnmanagedType.BStr)] string bstrDelegatedPolicyUser, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>
		/// The <b>InitializeClientContextFromToken2</b> method retrieves an <c>IAzClientContext2</c> object pointer from the specified
		/// client token.
		/// </summary>
		/// <param name="ulTokenHandleLowPart">
		/// Low byte of a handle to a token that specifies the client. If the values of both this parameter and the
		/// <i>ulTokenHandleHighPart</i> parameter are zero, the impersonation token of the caller's thread is used. If the thread does not
		/// have an impersonation token, the process token is used. The token must have been opened for TOKEN_QUERY, TOKEN_IMPERSONATE, or
		/// TOKEN_DUPLICATE access.
		/// </param>
		/// <param name="ulTokenHandleHighPart">
		/// High byte of a handle to a token that specifies the client. If the values of both this parameter and the
		/// <i>ulTokenHandleHighPart</i> parameter are zero, the impersonation token of the caller's thread is used. If the thread does not
		/// have an impersonation token, the process token is used. The token must have been opened for TOKEN_QUERY, TOKEN_IMPERSONATE, or
		/// TOKEN_DUPLICATE access.
		/// </param>
		/// <param name="varReserved">Reserved for future use.</param>
		/// <returns>A pointer to a pointer to the returned <c>IAzClientContext2</c> object.</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazapplication2-initializeclientcontextfromtoken2 HRESULT
		// InitializeClientContextFromToken2( [in] ULONG ulTokenHandleLowPart, [in] ULONG ulTokenHandleHighPart, [in, optional] VARIANT
		// varReserved, [out] IAzClientContext2 **ppClientContext );
		[DispId(1610809344)]
		[return: MarshalAs(UnmanagedType.Interface)]
		new IAzClientContext2 InitializeClientContextFromToken2([In] uint ulTokenHandleLowPart, [In] uint ulTokenHandleHighPart, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>The <b>InitializeClientContext2</b> method retrieves an <c>IAzClientContext2</c> object pointer.</summary>
		/// <param name="IdentifyingString">
		/// A string that identifies the client context in the audit trail for client connection and object access audit entries.
		/// </param>
		/// <param name="varReserved">Reserved for future use.</param>
		/// <returns>A pointer to a pointer to the returned <c>IAzClientContext2</c> object.</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazapplication2-initializeclientcontext2 HRESULT
		// InitializeClientContext2( [in] BSTR IdentifyingString, [in, optional] VARIANT varReserved, [out] IAzClientContext2
		// **ppClientContext );
		[DispId(1610809345)]
		[return: MarshalAs(UnmanagedType.Interface)]
		new IAzClientContext2 InitializeClientContext2([In, MarshalAs(UnmanagedType.BStr)] string IdentifyingString, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>The <b>ScopeExists</b> method indicates whether the specified scope exists in this <c>IAzApplication3</c> object.</summary>
		/// <param name="bstrScopeName">A string that contains the name of the scope to be checked.</param>
		/// <returns><b>VARIANT_TRUE</b> if the specified scope exists in this <c>IAzApplication3</c> object; otherwise, <b>VARIANT_FALSE</b>.</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazapplication3-scopeexists HRESULT ScopeExists( [in] BSTR
		// bstrScopeName, [out] VARIANT_BOOL *pbExist );
		[DispId(1610874880)]
		bool ScopeExists([In, MarshalAs(UnmanagedType.BStr)] string bstrScopeName);

		/// <summary>The <b>OpenScope2</b> method opens an <c>IAzScope2</c> object with the specified name.</summary>
		/// <param name="bstrScopeName">A string that contains the name of the <c>IAzScope2</c> object to open.</param>
		/// <returns>
		/// <para>The address of a pointer to the <c>IAzScope2</c> object that this method opens.</para>
		/// <para>When you have finished using the <c>IAzScope2</c> object, release it by calling the <c>IUnknown::Release</c> method.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazapplication3-openscope2 HRESULT OpenScope2( [in] BSTR
		// bstrScopeName, [out] IAzScope2 **ppScope2 );
		[DispId(1610874881)]
		[return: MarshalAs(UnmanagedType.Interface)]
		IAzScope2 OpenScope2([In, MarshalAs(UnmanagedType.BStr)] string bstrScopeName);

		/// <summary>The <b>CreateScope2</b> method creates a new <c>IAzScope2</c> object with the specified name.</summary>
		/// <param name="bstrScopeName">A string that contains the name of the new <c>IAzScope2</c> object.</param>
		/// <returns>
		/// <para>The address of a pointer to the <c>IAzScope2</c> object that this method creates.</para>
		/// <para>When you have finished using this <c>IAzScope2</c> object, release it by calling the <c>IUnknown::Release</c> method.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazapplication3-createscope2 HRESULT CreateScope2( [in]
		// BSTR bstrScopeName, [out] IAzScope2 **ppScope2 );
		[DispId(1610874882)]
		[return: MarshalAs(UnmanagedType.Interface)]
		IAzScope2 CreateScope2([In, MarshalAs(UnmanagedType.BStr)] string bstrScopeName);

		/// <summary>The <b>DeleteScope2</b> method removes the specified <c>IAzScope2</c> object from the <c>IAzApplication3</c> object.</summary>
		/// <param name="bstrScopeName">A string that contains the name of the <c>IAzScope2</c> object to remove.</param>
		/// <remarks>
		/// If any references to an <c>IAzScope2</c> object have been deleted from the cache, you can no longer use that object. In C++, you
		/// must release references to deleted <b>IAzScope2</b> objects by calling the <c>IUnknown::Release</c> method. In Visual Basic,
		/// references to deleted objects are automatically released.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazapplication3-deletescope2 HRESULT DeleteScope2( [in]
		// BSTR bstrScopeName );
		[DispId(1610874883)]
		void DeleteScope2([In, MarshalAs(UnmanagedType.BStr)] string bstrScopeName);

		/// <summary>
		/// <para>
		/// The <b>RoleDefinitions</b> property gets an <c>IAzRoleDefinitions</c> object that represents the collection of
		/// <c>IAzRoleDefinition</c> objects associated with the current <c>IAzApplication3</c> object.
		/// </para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazapplication3-get_roledefinitions HRESULT
		// get_RoleDefinitions( IAzRoleDefinitions **ppRoleDefinitions );
		[DispId(1610874884)]
		IAzRoleDefinitions RoleDefinitions
		{
			[DispId(1610874884)]
			[return: MarshalAs(UnmanagedType.Interface)]
			get;
		}

		/// <summary>The <b>CreateRoleDefinition</b> method creates a new <c>IAzRoleDefinition</c> object with the specified name.</summary>
		/// <param name="bstrRoleDefinitionName">A string that contains the name of the new <c>IAzRoleDefinition</c> object.</param>
		/// <returns>
		/// <para>The address of a pointer to the <c>IAzRoleDefinition</c> object that this method creates.</para>
		/// <para>When you have finished using this <c>IAzRoleDefinition</c> object, release it by calling the <c>IUnknown::Release</c> method.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazapplication3-createroledefinition?view=vs-2017 HRESULT
		// CreateRoleDefinition( [in] BSTR bstrRoleDefinitionName, [out] IAzRoleDefinition **ppRoleDefinitions );
		[DispId(1610874885)]
		[return: MarshalAs(UnmanagedType.Interface)]
		IAzRoleDefinition CreateRoleDefinition([In, MarshalAs(UnmanagedType.BStr)] string bstrRoleDefinitionName);

		/// <summary>The <b>OpenRoleDefinition</b> method opens an <c>IAzRoleDefinition</c> object with the specified name.</summary>
		/// <param name="bstrRoleDefinitionName">A string that contains the name of the <c>IAzRoleDefinition</c> object to open.</param>
		/// <returns>
		/// <para>The address of a pointer to the <c>IAzRoleDefinition</c> object that this method opens.</para>
		/// <para>When you have finished using this <c>IAzRoleDefinition</c> object, release it by calling the <c>IUnknown::Release</c> method.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazapplication3-openroledefinition HRESULT
		// OpenRoleDefinition( [in] BSTR bstrRoleDefinitionName, [out] IAzRoleDefinition **ppRoleDefinitions );
		[DispId(1610874886)]
		[return: MarshalAs(UnmanagedType.Interface)]
		IAzRoleDefinition OpenRoleDefinition([In, MarshalAs(UnmanagedType.BStr)] string bstrRoleDefinitionName);

		/// <summary>
		/// The <b>DeleteRoleDefinition</b> method removes the specified <c>IAzRoleDefinition</c> object from the <c>IAzApplication3</c> object.
		/// </summary>
		/// <param name="bstrRoleDefinitionName">A string that contains the name of the <c>IAzRoleDefinition</c> object to remove.</param>
		/// <remarks>
		/// If any references to an <c>IAzRoleDefinition</c> object have been deleted from the cache, you can no longer use that object. In
		/// C++, you must release references to deleted <b>IAzRoleDefinition</b> objects by calling the <c>IUnknown::Release</c> method. In
		/// Visual Basic, references to deleted objects are automatically released.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazapplication3-deleteroledefinition HRESULT
		// DeleteRoleDefinition( [in] BSTR bstrRoleDefinitionName );
		[DispId(1610874887)]
		void DeleteRoleDefinition([In, MarshalAs(UnmanagedType.BStr)] string bstrRoleDefinitionName);

		/// <summary>
		/// <para>
		/// The <b>RoleAssignments</b> property gets an <c>IAzRoleAssignments</c> object that represents the collection of
		/// <c>IAzRoleAssignment</c> objects associated with the current <c>IAzApplication3</c> object.
		/// </para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazapplication3-get_roleassignments HRESULT
		// get_RoleAssignments( IAzRoleAssignments **ppRoleAssignments );
		[DispId(1610874888)]
		IAzRoleAssignments RoleAssignments
		{
			[DispId(1610874888)]
			[return: MarshalAs(UnmanagedType.Interface)]
			get;
		}

		/// <summary>The <b>CreateRoleAssignment</b> method creates a new <c>IAzRoleAssignment</c> object with the specified name.</summary>
		/// <param name="bstrRoleAssignmentName">A string that contains the name of the new <c>IAzRoleAssignment</c> object.</param>
		/// <returns>
		/// <para>The address of a pointer to the <c>IAzRoleAssignment</c> object that this method creates.</para>
		/// <para>When you have finished using this <c>IAzRoleAssignment</c> object, release it by calling the <c>IUnknown::Release</c> method.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazapplication3-createroleassignment HRESULT
		// CreateRoleAssignment( [in] BSTR bstrRoleAssignmentName, [out] IAzRoleAssignment **ppRoleAssignment );
		[DispId(1610874889)]
		[return: MarshalAs(UnmanagedType.Interface)]
		IAzRoleAssignment CreateRoleAssignment([In, MarshalAs(UnmanagedType.BStr)] string bstrRoleAssignmentName);

		/// <summary>The <b>OpenRoleAssignment</b> method opens an <c>IAzRoleAssignment</c> object with the specified name.</summary>
		/// <param name="bstrRoleAssignmentName">A string that contains the name of the <c>IAzRoleAssignment</c> object to open.</param>
		/// <returns>
		/// <para>The address of a pointer to the <c>IAzRoleAssignment</c> object that this method opens.</para>
		/// <para>When you have finished using this <c>IAzRoleAssignment</c> object, release it by calling the <c>IUnknown::Release</c> method.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazapplication3-openroleassignment HRESULT
		// OpenRoleAssignment( [in] BSTR bstrRoleAssignmentName, [out] IAzRoleAssignment **ppRoleAssignment );
		[DispId(1610874890)]
		[return: MarshalAs(UnmanagedType.Interface)]
		IAzRoleAssignment OpenRoleAssignment([In, MarshalAs(UnmanagedType.BStr)] string bstrRoleAssignmentName);

		/// <summary>
		/// The <b>DeleteRoleAssignment</b> method removes the specified <c>IAzRoleAssignment</c> object from the <c>IAzApplication3</c> object.
		/// </summary>
		/// <param name="bstrRoleAssignmentName">A string that contains the name of the <c>IAzRoleAssignment</c> object to remove.</param>
		/// <remarks>
		/// If any references to an <c>IAzRoleAssignment</c> object have been deleted from the cache, you can no longer use that object. In
		/// C++, you must release references to deleted <b>IAzRoleAssignment</b> objects by calling the <c>IUnknown::Release</c> method. In
		/// Visual Basic, references to deleted objects are automatically released.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazapplication3-deleteroleassignment HRESULT
		// DeleteRoleAssignment( [in] BSTR bstrRoleAssignmentName );
		[DispId(1610874891)]
		void DeleteRoleAssignment([In, MarshalAs(UnmanagedType.BStr)] string bstrRoleAssignmentName);

		/// <summary>
		/// <para>Gets or sets a value that indicates whether business rules are enabled for this application.</para>
		/// <para>This property is read/write.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazapplication3-get_bizrulesenabled HRESULT
		// get_BizRulesEnabled( VARIANT_BOOL *pbEnabled );
		[DispId(1610874892)]
		bool BizRulesEnabled
		{
			[DispId(1610874892)]
			get;
			[DispId(1610874892)]
			[param: In]
			set;
		}
	}

	/// <summary>The <b>IAzApplicationGroup</b> interface defines a collection of principals.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nn-azroles-iazapplicationgroup
	[PInvokeData("azroles.h", MSDNShortId = "NN:azroles.IAzApplicationGroup")]
	[ComImport, Guid("F1B744CD-58A6-4E06-9FBF-36F6D779E21E")]
	public interface IAzApplicationGroup
	{
		/// <summary>
		/// <para>The <b>Name</b> property sets or retrieves the name of the application group.</para>
		/// <para>This property is read/write.</para>
		/// </summary>
		/// <remarks>The maximum length of the <b>Name</b> property is 64 characters.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazapplicationgroup-get_name HRESULT get_Name( BSTR
		// *pbstrName );
		[DispId(1610743808)]
		string Name
		{
			[DispId(1610743808)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
			[DispId(1610743808)]
			[param: In]
			[param: MarshalAs(UnmanagedType.BStr)]
			set;
		}

		/// <summary>
		/// <para>The <b>Type</b> property sets or retrieves the group type of the application group.</para>
		/// <para>This property is read/write.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazapplicationgroup-get_type HRESULT get_Type( LONG *plProp );
		[DispId(1610743810)]
		AZ_GROUPTYPE Type
		{
			[DispId(1610743810)]
			get;
			[DispId(1610743810)]
			[param: In]
			set;
		}

		/// <summary>
		/// <para>
		/// The <b>LdapQuery</b> property sets or retrieves the <c>Lightweight Directory Access Protocol</c> (LDAP) query used to define
		/// membership for an LDAP query application group.
		/// </para>
		/// <para>This property is read/write.</para>
		/// </summary>
		/// <remarks>
		/// <para>This property is ignored unless the <c>Type</c> property is AZ_GROUPTYPE_LDAP_QUERY.</para>
		/// <para>The maximum length of this property is 4,096 characters.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazapplicationgroup-get_ldapquery HRESULT get_LdapQuery(
		// BSTR *pbstrProp );
		[DispId(1610743812)]
		string LdapQuery
		{
			[DispId(1610743812)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
			[DispId(1610743812)]
			[param: In]
			[param: MarshalAs(UnmanagedType.BStr)]
			set;
		}

		/// <summary>
		/// <para>The <b>AppMembers</b> property retrieves the application groups that belong to this application group.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <remarks>
		/// <para>This property allows the nesting of <c>IAzApplicationGroup</c> objects within another <b>IAzApplicationGroup</b> object.</para>
		/// <para>In JScript, the returned <c>SAFEARRAY</c> must be converted to the JScript <c>Array</c> object.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazapplicationgroup-get_appmembers HRESULT get_AppMembers(
		// VARIANT *pvarProp );
		[DispId(1610743814)]
		object AppMembers
		{
			[DispId(1610743814)]
			[return: MarshalAs(UnmanagedType.Struct)]
			get;
		}

		/// <summary>
		/// <para>The <b>AppNonMembers</b> property retrieves the application groups that are refused membership in this application group.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// Denying membership to an account in an application group does not prevent that account from being assigned to a role through a
		/// different application group, nor from being granted permission to a resource through assignment to any other role.
		/// </para>
		/// <para>In JScript, the returned <c>SAFEARRAY</c> must be converted to the JScript <c>Array</c> object.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazapplicationgroup-get_appnonmembers HRESULT
		// get_AppNonMembers( VARIANT *pvarProp );
		[DispId(1610743815)]
		object AppNonMembers
		{
			[DispId(1610743815)]
			[return: MarshalAs(UnmanagedType.Struct)]
			get;
		}

		/// <summary>
		/// <para>
		/// The <b>Members</b> property retrieves the <c>security identifiers</c> (SIDs), in text form, of accounts that belong to the
		/// application group.
		/// </para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <remarks>
		/// <para>This property is ignored unless the <c>Type</c> property is AZ_GROUPTYPE_BASIC.</para>
		/// <para>In JScript, the returned <c>SAFEARRAY</c> must be converted to the JScript <c>Array</c> object.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazapplicationgroup-get_members HRESULT get_Members(
		// VARIANT *pvarProp );
		[DispId(1610743816)]
		object Members
		{
			[DispId(1610743816)]
			[return: MarshalAs(UnmanagedType.Struct)]
			get;
		}

		/// <summary>
		/// <para>
		/// The <b>NonMembers</b> property retrieves the <c>security identifiers</c> (SIDs), in text form, of accounts that are refused
		/// membership in the application group.
		/// </para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// The application group will never have an account specified by this property as a member, even if that account is specified
		/// directly or indirectly by the <c>Members</c> property.
		/// </para>
		/// <para>This property is ignored unless the <c>Type</c> property is AZ_GROUPTYPE_BASIC.</para>
		/// <para>In JScript, the returned <c>SAFEARRAY</c> must be converted to the JScript <c>Array</c> object.</para>
		/// <para>
		/// Denying membership to an account in an application group does not prevent that account from being assigned to a role through a
		/// different application group, nor from being granted permission to a resource through assignment to any other role.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazapplicationgroup-get_nonmembers HRESULT get_NonMembers(
		// VARIANT *pvarProp );
		[DispId(1610743817)]
		object NonMembers
		{
			[DispId(1610743817)]
			[return: MarshalAs(UnmanagedType.Struct)]
			get;
		}

		/// <summary>
		/// <para>The <b>Description</b> property sets or retrieves a comment that describes the application group.</para>
		/// <para>This property is read/write.</para>
		/// </summary>
		/// <remarks>The maximum length of the <b>Description</b> property is 1,024 characters.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazapplicationgroup-get_description HRESULT
		// get_Description( BSTR *pbstrDescription );
		[DispId(1610743818)]
		string Description
		{
			[DispId(1610743818)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
			[DispId(1610743818)]
			[param: In]
			[param: MarshalAs(UnmanagedType.BStr)]
			set;
		}

		/// <summary>
		/// The <b>AddAppMember</b> method adds the specified <c>IAzApplicationGroup</c> object to the list of application groups that belong
		/// to this application group.
		/// </summary>
		/// <param name="bstrProp">
		/// String that contains the <c>Name</c> property of the <c>IAzApplicationGroup</c> object to add to the list of the application
		/// groups that belong to this application group.
		/// </param>
		/// <param name="varReserved">Reserved for future use.</param>
		/// <remarks>
		/// <para>To view the list of application groups that belong to this application group, use the <c>AppMembers</c> property.</para>
		/// <para>You must call the <c>Submit</c> method to persist any changes made by this method.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazapplicationgroup-addappmember HRESULT AddAppMember( [in]
		// BSTR bstrProp, [in, optional] VARIANT varReserved );
		[DispId(1610743820)]
		void AddAppMember([In, MarshalAs(UnmanagedType.BStr)] string bstrProp, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>
		/// The <b>DeleteAppMember</b> method removes the specified <c>IAzApplicationGroup</c> object from the list of application groups
		/// that belong to this application group.
		/// </summary>
		/// <param name="bstrProp">
		/// String that contains the <c>Name</c> property of the <c>IAzApplicationGroup</c> object to remove from the list of application
		/// groups that belong to this application group.
		/// </param>
		/// <param name="varReserved">Reserved for future use.</param>
		/// <remarks>To view the list of application groups that belong to this application group, use the <c>AppMembers</c> property.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazapplicationgroup-deleteappmember HRESULT
		// DeleteAppMember( [in] BSTR bstrProp, [in, optional] VARIANT varReserved );
		[DispId(1610743821)]
		void DeleteAppMember([In, MarshalAs(UnmanagedType.BStr)] string bstrProp, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>
		/// The <b>AddAppNonMember</b> method adds the specified <c>IAzApplicationGroup</c> object to the list of application groups that are
		/// refused membership in this application group.
		/// </summary>
		/// <param name="bstrProp">
		/// String that contains the <c>Name</c> property of the <c>IAzApplicationGroup</c> object to add to the list of the application
		/// groups that are refused membership in this application group.
		/// </param>
		/// <param name="varReserved">Reserved for future use.</param>
		/// <remarks>
		/// <para>
		/// To view the list of application groups that are refused membership in this application group, use the <c>AppNonMembers</c> property.
		/// </para>
		/// <para>
		/// Denying membership to an account in an application group does not prevent that account from being assigned to a role through a
		/// different application group, nor from being granted permission to a resource through assignment to any other role.
		/// </para>
		/// <para>You must call the <c>Submit</c> method to persist any changes made by this method.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazapplicationgroup-addappnonmember HRESULT
		// AddAppNonMember( [in] BSTR bstrProp, [in, optional] VARIANT varReserved );
		[DispId(1610743822)]
		void AddAppNonMember([In, MarshalAs(UnmanagedType.BStr)] string bstrProp, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>
		/// The <b>DeleteAppNonMember</b> method removes the specified <c>IAzApplicationGroup</c> object from the list of application groups
		/// that are refused membership in this application group.
		/// </summary>
		/// <param name="bstrProp">
		/// String that contains the <c>Name</c> property of the <c>IAzApplicationGroup</c> object to remove from the list of the application
		/// groups that are refused membership in this application group.
		/// </param>
		/// <param name="varReserved">Reserved for future use.</param>
		/// <remarks>
		/// To view the list of application groups that are refused membership in this application group, use the <c>AppNonMembers</c> property.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazapplicationgroup-deleteappnonmember HRESULT
		// DeleteAppNonMember( [in] BSTR bstrProp, [in, optional] VARIANT varReserved );
		[DispId(1610743823)]
		void DeleteAppNonMember([In, MarshalAs(UnmanagedType.BStr)] string bstrProp, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>
		/// The <b>AddMember</b> method adds the specified <c>security identifier</c> (SID) in text form to the list of accounts that belong
		/// to the application group.
		/// </summary>
		/// <param name="bstrProp">
		/// String that contains the text form of the SID to add to the list of accounts that belong to the application group.
		/// </param>
		/// <param name="varReserved">Reserved for future use.</param>
		/// <remarks>
		/// <para>To view the list of SIDs of accounts that belong to this application group in text form, use the <c>Members</c> property.</para>
		/// <para>You must call the <c>Submit</c> method to persist any changes made by this method.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazapplicationgroup-addmember HRESULT AddMember( [in] BSTR
		// bstrProp, [in, optional] VARIANT varReserved );
		[DispId(1610743824)]
		void AddMember([In, MarshalAs(UnmanagedType.BStr)] string bstrProp, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>
		/// The <b>DeleteMember</b> method removes the specified <c>security identifier</c> (SID) in text form from the list of accounts that
		/// belong to the application group.
		/// </summary>
		/// <param name="bstrProp">
		/// String that contains the text form of the SID to remove from the list of accounts that belong to the application group.
		/// </param>
		/// <param name="varReserved">Reserved for future use.</param>
		/// <remarks>To view the list of SIDs of accounts that belong to this application group in text form, use the <c>Members</c> property.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazapplicationgroup-deletemember HRESULT DeleteMember( [in]
		// BSTR bstrProp, [in, optional] VARIANT varReserved );
		[DispId(1610743825)]
		void DeleteMember([In, MarshalAs(UnmanagedType.BStr)] string bstrProp, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>
		/// The <b>AddNonMember</b> method adds the specified <c>security identifier</c> (SID) in text form to the list of accounts that are
		/// refused membership in the application group.
		/// </summary>
		/// <param name="bstrProp">
		/// String that contains the text form of the SID to add to the list of accounts that are refused membership in the application group.
		/// </param>
		/// <param name="varReserved">Reserved for future use.</param>
		/// <remarks>
		/// <para>
		/// The application group will never have an account added using this method as a member, even if that account is specified directly
		/// or indirectly by the <c>Members</c> property.
		/// </para>
		/// <para>
		/// Denying membership to an account in an application group does not prevent that account from being assigned to a role through a
		/// different application group, nor from being granted permission to a resource through assignment to any other role.
		/// </para>
		/// <para>
		/// To view the list of SIDs of accounts that are refused membership in this application group in text form, use the
		/// <c>NonMembers</c> property.
		/// </para>
		/// <para>You must call the <c>Submit</c> method to persist any changes made by this method.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazapplicationgroup-addnonmember HRESULT AddNonMember( [in]
		// BSTR bstrProp, [in, optional] VARIANT varReserved );
		[DispId(1610743826)]
		void AddNonMember([In, MarshalAs(UnmanagedType.BStr)] string bstrProp, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>
		/// The <b>DeleteNonMember</b> method removes the specified <c>security identifier</c> (SID) in text form from the list of accounts
		/// that are refused membership in the application group.
		/// </summary>
		/// <param name="bstrProp">
		/// String that contains the text form of the SID to remove from the list of accounts that are refused membership in the application group.
		/// </param>
		/// <param name="varReserved">Reserved for future use.</param>
		/// <remarks>
		/// To view the list of SIDs of accounts that are refused membership in this application group in text form, use the
		/// <c>NonMembers</c> property.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazapplicationgroup-deletenonmember?view=vs-2017 HRESULT
		// DeleteNonMember( [in] BSTR bstrProp, [in, optional] VARIANT varReserved );
		[DispId(1610743827)]
		void DeleteNonMember([In, MarshalAs(UnmanagedType.BStr)] string bstrProp, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>
		/// <para>
		/// The <b>Writable</b> property retrieves a value that indicates whether the application group can be modified by the user context
		/// that initialized it.
		/// </para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazapplicationgroup-get_writable HRESULT get_Writable( BOOL
		// *pfProp );
		[DispId(1610743828)]
		bool Writable
		{
			[DispId(1610743828)]
			[return: MarshalAs(UnmanagedType.Bool)]
			get;
		}

		/// <summary>The GetProperty method returns the IAzApplicationGroup object property with the specified property ID.</summary>
		/// <param name="lPropId">
		/// <para>Property ID of the <c>IAzApplicationGroup</c> object property to return. The following table shows the possible values.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Value</description>
		/// <description>Meaning</description>
		/// </listheader>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_DESCRIPTION</b></description>
		/// <description>Also accessed through the <c>Description</c> property</description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_GROUP_TYPE</b></description>
		/// <description>Also accessed through the <c>Type</c> property</description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_GROUP_LDAP_QUERY</b></description>
		/// <description>Also accessed through the <c>LdapQuery</c> property</description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_NAME</b></description>
		/// <description>Also accessed through the <c>Name</c> property</description>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="varReserved">Reserved for future use.</param>
		/// <returns>A pointer to the returned IAzApplicationGroup object property.</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazapplicationgroup-setproperty
		[DispId(1610743829)]
		[return: MarshalAs(UnmanagedType.Struct)]
		object GetProperty([In] AZ_PROP_CONSTANTS lPropId, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>
		/// The <b>SetProperty</b> method sets the specified value to the <c>IAzApplicationGroup</c> object property with the specified
		/// property ID.
		/// </summary>
		/// <param name="lPropId">
		/// <para>Property ID of the <c>IAzApplicationGroup</c> object property to set. The following table shows the possible values.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Value</description>
		/// <description>Meaning</description>
		/// </listheader>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_DESCRIPTION</b></description>
		/// <description>Also accessed through the <c>Description</c> property</description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_GROUP_TYPE</b></description>
		/// <description>Also accessed through the <c>Type</c> property</description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_GROUP_LDAP_QUERY</b></description>
		/// <description>Also accessed through the <c>LdapQuery</c> property</description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_NAME</b></description>
		/// <description>Also accessed through the <c>Name</c> property</description>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="varProp">
		/// <para>
		/// Value to set to the <c>IAzApplicationGroup</c> object property specified by the <i>lPropId</i> parameter. The following table
		/// shows the type of data that must be used depending on the value of the <i>lPropId</i> parameter.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <description><i>lPropId</i> value</description>
		/// <description>Data type (C++/Visual Basic)</description>
		/// </listheader>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_DESCRIPTION</b></description>
		/// <description><b>BSTR</b>/ <b>String</b></description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_GROUP_LDAP_QUERY</b></description>
		/// <description><b>BSTR</b>/ <b>String</b></description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_GROUP_TYPE</b></description>
		/// <description><b>LONG</b>/ <b>Long</b></description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_NAME</b></description>
		/// <description><b>BSTR</b>/ <b>String</b></description>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="varReserved">Reserved for future use.</param>
		/// <remarks>You must call the <c>Submit</c> method to persist any changes made by this method.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazapplicationgroup-setproperty HRESULT SetProperty( [in]
		// LONG lPropId, [in] VARIANT varProp, [in, optional] VARIANT varReserved );
		[DispId(1610743830)]
		void SetProperty([In] AZ_PROP_CONSTANTS lPropId, [In, MarshalAs(UnmanagedType.Struct)] object varProp, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>The <b>AddPropertyItem</b> method adds the specified entity to the specified list.</summary>
		/// <param name="lPropId">
		/// <para>Property ID of the list to which to add the entity specified by the varProp parameter.</para>
		/// <para>The following table shows the possible values:</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Value</description>
		/// <description>Meaning</description>
		/// </listheader>
		/// <item>
		/// <description>
		/// <code>AZ_PROP_GROUP_APP_MEMBERS</code>
		/// </description>
		/// <description>Can also be added using the <c>AddAppMember</c> method.</description>
		/// </item>
		/// <item>
		/// <description>
		/// <code>AZ_PROP_GROUP_APP_NON_MEMBERS</code>
		/// </description>
		/// <description>Can also be added using the <c>AddAppNonMember</c> method.</description>
		/// </item>
		/// <item>
		/// <description>
		/// <code>AZ_PROP_GROUP_MEMBERS</code>
		/// </description>
		/// <description>Can also be added using the <c>AddMember</c> method.</description>
		/// </item>
		/// <item>
		/// <description>
		/// <code>AZ_PROP_GROUP_MEMBERS_NAME</code>
		/// </description>
		/// <description>Can also be added using the <c>AddMemberName</c> method.</description>
		/// </item>
		/// <item>
		/// <description>
		/// <code>AZ_PROP_GROUP_NON_MEMBERS</code>
		/// </description>
		/// <description>Can also be added using the <c>AddNonMember</c> method.</description>
		/// </item>
		/// <item>
		/// <description>
		/// <code>AZ_PROP_GROUP_NON_MEMBERS_NAME</code>
		/// </description>
		/// <description>Can also be added using the <c>AddNonMemberName</c> method.</description>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="varProp">TBD</param>
		/// <param name="varReserved">Reserved for future use.</param>
		/// <remarks>You must call the <c>Submit</c> method to persist any changes made by this method.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazapplicationgroup-addpropertyitem HRESULT
		// AddPropertyItem( [in] LONG lPropId, VARIANT varProp, [in, optional] VARIANT varReserved );
		[DispId(1610743831)]
		void AddPropertyItem([In] AZ_PROP_CONSTANTS lPropId, [In, MarshalAs(UnmanagedType.Struct)] object varProp, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>The <b>DeletePropertyItem</b> method removes the specified entity from the specified list.</summary>
		/// <param name="lPropId">
		/// <para>
		/// Property ID of the list from which to remove the entity specified by the <i>varProp</i> parameter. The following table shows the
		/// possible values.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <description>Value</description>
		/// <description>Meaning</description>
		/// </listheader>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_GROUP_APP_MEMBERS</b></description>
		/// <description>Can also be removed using the <c>DeleteAppMember</c> method</description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_GROUP_APP_NON_MEMBERS</b></description>
		/// <description>Can also be removed using the <c>DeleteAppNonMember</c> method</description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_GROUP_MEMBERS</b></description>
		/// <description>Can also be removed using the <c>DeleteMember</c> method</description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_GROUP_MEMBERS_NAME</b></description>
		/// <description>Can also be removed using the <c>DeleteMemberName</c> method</description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_GROUP_NON_MEMBERS</b></description>
		/// <description>Can also be removed using the <c>DeleteNonMember</c> method</description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_GROUP_NON_MEMBERS_NAME</b></description>
		/// <description>Can also be removed using the <c>DeleteNonMemberName</c> method</description>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="varProp">
		/// <para>The entity to remove from the list specified by the <i>lPropId</i> parameter.</para>
		/// <para>The variant must be a <b>BSTR</b> variant.</para>
		/// <para>
		/// If AZ_PROP_GROUP_MEMBERS_NAME or AZ_PROP_GROUP_NON_MEMBERS_NAME is specified for the <i>lPropId</i> parameter, the string is the
		/// account name of the account to remove from the list. The account name must be in user principal name (UPN) format (for example,
		/// "someone@example.com"). If AZ_PROP_GROUP_APP_MEMBERS or AZ_PROP_GROUP_APP_NON_MEMBERS is specified for the <i>lPropId</i>
		/// parameter, the string is the <c>Name</c> property of the <c>IAzApplicationGroup</c> object to remove from the list.
		/// </para>
		/// </param>
		/// <param name="varReserved">Reserved for future use.</param>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazapplicationgroup-deletepropertyitem HRESULT
		// DeletePropertyItem( [in] LONG lPropId, [in] VARIANT varProp, [in, optional] VARIANT varReserved );
		[DispId(1610743832)]
		void DeletePropertyItem([In] AZ_PROP_CONSTANTS lPropId, [In, MarshalAs(UnmanagedType.Struct)] object varProp, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>The <b>Submit</b> method persists changes made to the <c>IAzApplicationGroup</c> object.</summary>
		/// <param name="lFlags">
		/// Flags that modify the behavior of the <b>Submit</b> method. The default value is zero. If the <b>AZ_SUBMIT_FLAG_ABORT</b> flag is
		/// specified, the changes to the object are discarded and the object is updated to match the underlying policy store.
		/// </param>
		/// <param name="varReserved">Reserved for future use.</param>
		/// <remarks>
		/// <para>
		/// Any additions or modifications to an <c>IAzApplicationGroup</c> object are not persisted until the <b>Submit</b> method is called.
		/// </para>
		/// <para>
		/// A created <c>IAzApplicationGroup</c> object must be submitted before it can be referenced. The destructor for an object silently
		/// discards unsubmitted changes.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazapplicationgroup-submit HRESULT Submit( [in, optional]
		// LONG lFlags, [in, optional] VARIANT varReserved );
		[DispId(1610743833)]
		void Submit([Optional, DefaultParameterValue((AZ_PROP_CONSTANTS)0), In] AZ_PROP_CONSTANTS lFlags, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>
		/// The <b>AddMemberName</b> method adds the specified account name to the list of accounts that belong to the application group.
		/// </summary>
		/// <param name="bstrProp">
		/// String that contains the account name to add to the list of accounts that belong to the application group. The account name must
		/// be in user principal name (UPN) format. The <c>LookupAccountName</c> function is called to retrieve the domain.
		/// </param>
		/// <param name="varReserved">Reserved for future use.</param>
		/// <remarks>
		/// <para>To view the list of account names of accounts that belong to this application group, use the <c>MembersName</c> property.</para>
		/// <para>You must call the <c>Submit</c> method to persist any changes made by this method.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazapplicationgroup-addmembername HRESULT AddMemberName(
		// [in] BSTR bstrProp, [in, optional] VARIANT varReserved );
		[DispId(1610743834)]
		void AddMemberName([In, MarshalAs(UnmanagedType.BStr)] string bstrProp, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>
		/// The <b>DeleteMemberName</b> method removes the specified account name from the list of accounts that belong to the application group.
		/// </summary>
		/// <param name="bstrProp">
		/// String that contains the account name to remove from the list of accounts that belong to the application group. The account name
		/// must be in user principal name (UPN) format (for example, <c>someone@example.com</c>). The <c>LookupAccountName</c> function is
		/// called to retrieve the domain.
		/// </param>
		/// <param name="varReserved">Reserved for future use.</param>
		/// <remarks>To view the list of account names of accounts that belong to this application group, use the <c>MembersName</c> property.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazapplicationgroup-deletemembername HRESULT
		// DeleteMemberName( [in] BSTR bstrProp, [in, optional] VARIANT varReserved );
		[DispId(1610743835)]
		void DeleteMemberName([In, MarshalAs(UnmanagedType.BStr)] string bstrProp, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>
		/// The <b>AddNonMemberName</b> method adds the specified account name to the list of accounts that are refused membership in the
		/// application group.
		/// </summary>
		/// <param name="bstrProp">
		/// String that contains the SID to add to the list of accounts that are refused membership in the application group. The account
		/// name must be in user principal name (UPN) format (for example, <c>someone@example.com</c>). The <c>LookupAccountName</c> function
		/// is called to retrieve the domain.
		/// </param>
		/// <param name="varReserved">Reserved for future use.</param>
		/// <remarks>
		/// <para>
		/// The application group will never have an account added using this method as a member, even if that account is specified directly
		/// or indirectly by the <c>Members</c> property.
		/// </para>
		/// <para>
		/// Denying membership to an account in an application group does not prevent that account from being assigned to a role through a
		/// different application group, nor from being granted permission to a resource through assignment to any other role.
		/// </para>
		/// <para>
		/// To view the list of account names of accounts that are refused membership in this application group, use the
		/// <c>NonMembersName</c> property.
		/// </para>
		/// <para>You must call the <c>Submit</c> method to persist any changes made by this method.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazapplicationgroup-addnonmembername HRESULT
		// AddNonMemberName( [in] BSTR bstrProp, [in, optional] VARIANT varReserved );
		[DispId(1610743836)]
		void AddNonMemberName([In, MarshalAs(UnmanagedType.BStr)] string bstrProp, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>
		/// The <b>DeleteNonMemberName</b> method removes the specified account name from the list of accounts that are refused membership in
		/// the application group.
		/// </summary>
		/// <param name="bstrProp">
		/// String that contains the account name to remove from the list of accounts that are refused membership in the application group.
		/// The account name must be in user principal name (UPN) format (for example, <c>someone@example.com</c>). The
		/// <c>LookupAccountName</c> function is called to retrieve the domain.
		/// </param>
		/// <param name="varReserved">Reserved for future use.</param>
		/// <remarks>
		/// To view the list of account names of accounts that are refused membership in this application group, use the
		/// <c>NonMembersName</c> property.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazapplicationgroup-deletenonmembername HRESULT
		// DeleteNonMemberName( [in] BSTR bstrProp, [in, optional] VARIANT varReserved );
		[DispId(1610743837)]
		void DeleteNonMemberName([In, MarshalAs(UnmanagedType.BStr)] string bstrProp, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>
		/// <para>The <b>MembersName</b> property retrieves the account names of accounts that belong to the application group.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <remarks>
		/// <para>This property is ignored unless the <c>Type</c> property is AZ_GROUPTYPE_BASIC.</para>
		/// <para>In JScript, the returned <c>SAFEARRAY</c> must be converted to the JScript <c>Array</c> object.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazapplicationgroup-get_membersname HRESULT
		// get_MembersName( VARIANT *pvarProp );
		[DispId(1610743838)]
		object MembersName
		{
			[DispId(1610743838)]
			[return: MarshalAs(UnmanagedType.Struct)]
			get;
		}

		/// <summary>
		/// <para>
		/// The <b>NonMembersName</b> property retrieves the account names of accounts that are refused membership in the application group.
		/// </para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// The application group will never have an account specified by this property as a member, even if that account is specified
		/// directly or indirectly by the <c>Members</c> property.
		/// </para>
		/// <para>
		/// Denying membership to an account in an application group does not prevent that account from being assigned to a role through a
		/// different application group, nor from being granted permission to a resource through assignment to any other role.
		/// </para>
		/// <para>This property is ignored unless the <c>Type</c> property is AZ_GROUPTYPE_BASIC.</para>
		/// <para>In JScript, the returned <c>SAFEARRAY</c> must be converted to the JScript <c>Array</c> object.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazapplicationgroup-get_nonmembersname HRESULT
		// get_NonMembersName( VARIANT *pvarProp );
		[DispId(1610743839)]
		object NonMembersName
		{
			[DispId(1610743839)]
			[return: MarshalAs(UnmanagedType.Struct)]
			get;
		}
	}

	/// <summary>
	/// The <b>IAzApplicationGroup2</b> interface extends the <c>IAzApplicationGroup</c> interface by adding support for the <b>BizRule</b>
	/// group type. This interface also adds a method that gets the role assignments associated with the application group.
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nn-azroles-iazapplicationgroup2
	[PInvokeData("azroles.h", MSDNShortId = "NN:azroles.IAzApplicationGroup2")]
	[ComImport, Guid("3F0613FC-B71A-464E-A11D-5B881A56CEFA")]
	public interface IAzApplicationGroup2 : IAzApplicationGroup
	{
		/// <summary>
		/// <para>The <b>Name</b> property sets or retrieves the name of the application group.</para>
		/// <para>This property is read/write.</para>
		/// </summary>
		/// <remarks>The maximum length of the <b>Name</b> property is 64 characters.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazapplicationgroup-get_name HRESULT get_Name( BSTR
		// *pbstrName );
		[DispId(1610743808)]
		new string Name
		{
			[DispId(1610743808)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
			[DispId(1610743808)]
			[param: In]
			[param: MarshalAs(UnmanagedType.BStr)]
			set;
		}

		/// <summary>
		/// <para>The <b>Type</b> property sets or retrieves the group type of the application group.</para>
		/// <para>This property is read/write.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazapplicationgroup-get_type HRESULT get_Type( LONG *plProp );
		[DispId(1610743810)]
		new AZ_GROUPTYPE Type
		{
			[DispId(1610743810)]
			get;
			[DispId(1610743810)]
			[param: In]
			set;
		}

		/// <summary>
		/// <para>
		/// The <b>LdapQuery</b> property sets or retrieves the <c>Lightweight Directory Access Protocol</c> (LDAP) query used to define
		/// membership for an LDAP query application group.
		/// </para>
		/// <para>This property is read/write.</para>
		/// </summary>
		/// <remarks>
		/// <para>This property is ignored unless the <c>Type</c> property is AZ_GROUPTYPE_LDAP_QUERY.</para>
		/// <para>The maximum length of this property is 4,096 characters.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazapplicationgroup-get_ldapquery HRESULT get_LdapQuery(
		// BSTR *pbstrProp );
		[DispId(1610743812)]
		new string LdapQuery
		{
			[DispId(1610743812)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
			[DispId(1610743812)]
			[param: In]
			[param: MarshalAs(UnmanagedType.BStr)]
			set;
		}

		/// <summary>
		/// <para>The <b>AppMembers</b> property retrieves the application groups that belong to this application group.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <remarks>
		/// <para>This property allows the nesting of <c>IAzApplicationGroup</c> objects within another <b>IAzApplicationGroup</b> object.</para>
		/// <para>In JScript, the returned <c>SAFEARRAY</c> must be converted to the JScript <c>Array</c> object.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazapplicationgroup-get_appmembers HRESULT get_AppMembers(
		// VARIANT *pvarProp );
		[DispId(1610743814)]
		new object AppMembers
		{
			[DispId(1610743814)]
			[return: MarshalAs(UnmanagedType.Struct)]
			get;
		}

		/// <summary>
		/// <para>The <b>AppNonMembers</b> property retrieves the application groups that are refused membership in this application group.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// Denying membership to an account in an application group does not prevent that account from being assigned to a role through a
		/// different application group, nor from being granted permission to a resource through assignment to any other role.
		/// </para>
		/// <para>In JScript, the returned <c>SAFEARRAY</c> must be converted to the JScript <c>Array</c> object.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazapplicationgroup-get_appnonmembers HRESULT
		// get_AppNonMembers( VARIANT *pvarProp );
		[DispId(1610743815)]
		new object AppNonMembers
		{
			[DispId(1610743815)]
			[return: MarshalAs(UnmanagedType.Struct)]
			get;
		}

		/// <summary>
		/// <para>
		/// The <b>Members</b> property retrieves the <c>security identifiers</c> (SIDs), in text form, of accounts that belong to the
		/// application group.
		/// </para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <remarks>
		/// <para>This property is ignored unless the <c>Type</c> property is AZ_GROUPTYPE_BASIC.</para>
		/// <para>In JScript, the returned <c>SAFEARRAY</c> must be converted to the JScript <c>Array</c> object.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazapplicationgroup-get_members HRESULT get_Members(
		// VARIANT *pvarProp );
		[DispId(1610743816)]
		new object Members
		{
			[DispId(1610743816)]
			[return: MarshalAs(UnmanagedType.Struct)]
			get;
		}

		/// <summary>
		/// <para>
		/// The <b>NonMembers</b> property retrieves the <c>security identifiers</c> (SIDs), in text form, of accounts that are refused
		/// membership in the application group.
		/// </para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// The application group will never have an account specified by this property as a member, even if that account is specified
		/// directly or indirectly by the <c>Members</c> property.
		/// </para>
		/// <para>This property is ignored unless the <c>Type</c> property is AZ_GROUPTYPE_BASIC.</para>
		/// <para>In JScript, the returned <c>SAFEARRAY</c> must be converted to the JScript <c>Array</c> object.</para>
		/// <para>
		/// Denying membership to an account in an application group does not prevent that account from being assigned to a role through a
		/// different application group, nor from being granted permission to a resource through assignment to any other role.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazapplicationgroup-get_nonmembers HRESULT get_NonMembers(
		// VARIANT *pvarProp );
		[DispId(1610743817)]
		new object NonMembers
		{
			[DispId(1610743817)]
			[return: MarshalAs(UnmanagedType.Struct)]
			get;
		}

		/// <summary>
		/// <para>The <b>Description</b> property sets or retrieves a comment that describes the application group.</para>
		/// <para>This property is read/write.</para>
		/// </summary>
		/// <remarks>The maximum length of the <b>Description</b> property is 1,024 characters.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazapplicationgroup-get_description HRESULT
		// get_Description( BSTR *pbstrDescription );
		[DispId(1610743818)]
		new string Description
		{
			[DispId(1610743818)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
			[DispId(1610743818)]
			[param: In]
			[param: MarshalAs(UnmanagedType.BStr)]
			set;
		}

		/// <summary>
		/// The <b>AddAppMember</b> method adds the specified <c>IAzApplicationGroup</c> object to the list of application groups that belong
		/// to this application group.
		/// </summary>
		/// <param name="bstrProp">
		/// String that contains the <c>Name</c> property of the <c>IAzApplicationGroup</c> object to add to the list of the application
		/// groups that belong to this application group.
		/// </param>
		/// <param name="varReserved">Reserved for future use.</param>
		/// <remarks>
		/// <para>To view the list of application groups that belong to this application group, use the <c>AppMembers</c> property.</para>
		/// <para>You must call the <c>Submit</c> method to persist any changes made by this method.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazapplicationgroup-addappmember HRESULT AddAppMember( [in]
		// BSTR bstrProp, [in, optional] VARIANT varReserved );
		[DispId(1610743820)]
		new void AddAppMember([In, MarshalAs(UnmanagedType.BStr)] string bstrProp, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>
		/// The <b>DeleteAppMember</b> method removes the specified <c>IAzApplicationGroup</c> object from the list of application groups
		/// that belong to this application group.
		/// </summary>
		/// <param name="bstrProp">
		/// String that contains the <c>Name</c> property of the <c>IAzApplicationGroup</c> object to remove from the list of application
		/// groups that belong to this application group.
		/// </param>
		/// <param name="varReserved">Reserved for future use.</param>
		/// <remarks>To view the list of application groups that belong to this application group, use the <c>AppMembers</c> property.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazapplicationgroup-deleteappmember HRESULT
		// DeleteAppMember( [in] BSTR bstrProp, [in, optional] VARIANT varReserved );
		[DispId(1610743821)]
		new void DeleteAppMember([In, MarshalAs(UnmanagedType.BStr)] string bstrProp, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>
		/// The <b>AddAppNonMember</b> method adds the specified <c>IAzApplicationGroup</c> object to the list of application groups that are
		/// refused membership in this application group.
		/// </summary>
		/// <param name="bstrProp">
		/// String that contains the <c>Name</c> property of the <c>IAzApplicationGroup</c> object to add to the list of the application
		/// groups that are refused membership in this application group.
		/// </param>
		/// <param name="varReserved">Reserved for future use.</param>
		/// <remarks>
		/// <para>
		/// To view the list of application groups that are refused membership in this application group, use the <c>AppNonMembers</c> property.
		/// </para>
		/// <para>
		/// Denying membership to an account in an application group does not prevent that account from being assigned to a role through a
		/// different application group, nor from being granted permission to a resource through assignment to any other role.
		/// </para>
		/// <para>You must call the <c>Submit</c> method to persist any changes made by this method.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazapplicationgroup-addappnonmember HRESULT
		// AddAppNonMember( [in] BSTR bstrProp, [in, optional] VARIANT varReserved );
		[DispId(1610743822)]
		new void AddAppNonMember([In, MarshalAs(UnmanagedType.BStr)] string bstrProp, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>
		/// The <b>DeleteAppNonMember</b> method removes the specified <c>IAzApplicationGroup</c> object from the list of application groups
		/// that are refused membership in this application group.
		/// </summary>
		/// <param name="bstrProp">
		/// String that contains the <c>Name</c> property of the <c>IAzApplicationGroup</c> object to remove from the list of the application
		/// groups that are refused membership in this application group.
		/// </param>
		/// <param name="varReserved">Reserved for future use.</param>
		/// <remarks>
		/// To view the list of application groups that are refused membership in this application group, use the <c>AppNonMembers</c> property.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazapplicationgroup-deleteappnonmember HRESULT
		// DeleteAppNonMember( [in] BSTR bstrProp, [in, optional] VARIANT varReserved );
		[DispId(1610743823)]
		new void DeleteAppNonMember([In, MarshalAs(UnmanagedType.BStr)] string bstrProp, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>
		/// The <b>AddMember</b> method adds the specified <c>security identifier</c> (SID) in text form to the list of accounts that belong
		/// to the application group.
		/// </summary>
		/// <param name="bstrProp">
		/// String that contains the text form of the SID to add to the list of accounts that belong to the application group.
		/// </param>
		/// <param name="varReserved">Reserved for future use.</param>
		/// <remarks>
		/// <para>To view the list of SIDs of accounts that belong to this application group in text form, use the <c>Members</c> property.</para>
		/// <para>You must call the <c>Submit</c> method to persist any changes made by this method.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazapplicationgroup-addmember HRESULT AddMember( [in] BSTR
		// bstrProp, [in, optional] VARIANT varReserved );
		[DispId(1610743824)]
		new void AddMember([In, MarshalAs(UnmanagedType.BStr)] string bstrProp, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>
		/// The <b>DeleteMember</b> method removes the specified <c>security identifier</c> (SID) in text form from the list of accounts that
		/// belong to the application group.
		/// </summary>
		/// <param name="bstrProp">
		/// String that contains the text form of the SID to remove from the list of accounts that belong to the application group.
		/// </param>
		/// <param name="varReserved">Reserved for future use.</param>
		/// <remarks>To view the list of SIDs of accounts that belong to this application group in text form, use the <c>Members</c> property.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazapplicationgroup-deletemember HRESULT DeleteMember( [in]
		// BSTR bstrProp, [in, optional] VARIANT varReserved );
		[DispId(1610743825)]
		new void DeleteMember([In, MarshalAs(UnmanagedType.BStr)] string bstrProp, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>
		/// The <b>AddNonMember</b> method adds the specified <c>security identifier</c> (SID) in text form to the list of accounts that are
		/// refused membership in the application group.
		/// </summary>
		/// <param name="bstrProp">
		/// String that contains the text form of the SID to add to the list of accounts that are refused membership in the application group.
		/// </param>
		/// <param name="varReserved">Reserved for future use.</param>
		/// <remarks>
		/// <para>
		/// The application group will never have an account added using this method as a member, even if that account is specified directly
		/// or indirectly by the <c>Members</c> property.
		/// </para>
		/// <para>
		/// Denying membership to an account in an application group does not prevent that account from being assigned to a role through a
		/// different application group, nor from being granted permission to a resource through assignment to any other role.
		/// </para>
		/// <para>
		/// To view the list of SIDs of accounts that are refused membership in this application group in text form, use the
		/// <c>NonMembers</c> property.
		/// </para>
		/// <para>You must call the <c>Submit</c> method to persist any changes made by this method.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazapplicationgroup-addnonmember HRESULT AddNonMember( [in]
		// BSTR bstrProp, [in, optional] VARIANT varReserved );
		[DispId(1610743826)]
		new void AddNonMember([In, MarshalAs(UnmanagedType.BStr)] string bstrProp, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>
		/// The <b>DeleteNonMember</b> method removes the specified <c>security identifier</c> (SID) in text form from the list of accounts
		/// that are refused membership in the application group.
		/// </summary>
		/// <param name="bstrProp">
		/// String that contains the text form of the SID to remove from the list of accounts that are refused membership in the application group.
		/// </param>
		/// <param name="varReserved">Reserved for future use.</param>
		/// <remarks>
		/// To view the list of SIDs of accounts that are refused membership in this application group in text form, use the
		/// <c>NonMembers</c> property.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazapplicationgroup-deletenonmember?view=vs-2017 HRESULT
		// DeleteNonMember( [in] BSTR bstrProp, [in, optional] VARIANT varReserved );
		[DispId(1610743827)]
		new void DeleteNonMember([In, MarshalAs(UnmanagedType.BStr)] string bstrProp, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>
		/// <para>
		/// The <b>Writable</b> property retrieves a value that indicates whether the application group can be modified by the user context
		/// that initialized it.
		/// </para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazapplicationgroup-get_writable HRESULT get_Writable( BOOL
		// *pfProp );
		[DispId(1610743828)]
		new bool Writable
		{
			[DispId(1610743828)]
			[return: MarshalAs(UnmanagedType.Bool)]
			get;
		}

		/// <summary>The GetProperty method returns the IAzApplicationGroup object property with the specified property ID.</summary>
		/// <param name="lPropId">
		/// <para>Property ID of the <c>IAzApplicationGroup</c> object property to return. The following table shows the possible values.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Value</description>
		/// <description>Meaning</description>
		/// </listheader>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_DESCRIPTION</b></description>
		/// <description>Also accessed through the <c>Description</c> property</description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_GROUP_TYPE</b></description>
		/// <description>Also accessed through the <c>Type</c> property</description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_GROUP_LDAP_QUERY</b></description>
		/// <description>Also accessed through the <c>LdapQuery</c> property</description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_NAME</b></description>
		/// <description>Also accessed through the <c>Name</c> property</description>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="varReserved">Reserved for future use.</param>
		/// <returns>A pointer to the returned IAzApplicationGroup object property.</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazapplicationgroup-setproperty
		[DispId(1610743829)]
		[return: MarshalAs(UnmanagedType.Struct)]
		new object GetProperty([In] AZ_PROP_CONSTANTS lPropId, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>
		/// The <b>SetProperty</b> method sets the specified value to the <c>IAzApplicationGroup</c> object property with the specified
		/// property ID.
		/// </summary>
		/// <param name="lPropId">
		/// <para>Property ID of the <c>IAzApplicationGroup</c> object property to set. The following table shows the possible values.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Value</description>
		/// <description>Meaning</description>
		/// </listheader>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_DESCRIPTION</b></description>
		/// <description>Also accessed through the <c>Description</c> property</description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_GROUP_TYPE</b></description>
		/// <description>Also accessed through the <c>Type</c> property</description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_GROUP_LDAP_QUERY</b></description>
		/// <description>Also accessed through the <c>LdapQuery</c> property</description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_NAME</b></description>
		/// <description>Also accessed through the <c>Name</c> property</description>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="varProp">
		/// <para>
		/// Value to set to the <c>IAzApplicationGroup</c> object property specified by the <i>lPropId</i> parameter. The following table
		/// shows the type of data that must be used depending on the value of the <i>lPropId</i> parameter.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <description><i>lPropId</i> value</description>
		/// <description>Data type (C++/Visual Basic)</description>
		/// </listheader>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_DESCRIPTION</b></description>
		/// <description><b>BSTR</b>/ <b>String</b></description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_GROUP_LDAP_QUERY</b></description>
		/// <description><b>BSTR</b>/ <b>String</b></description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_GROUP_TYPE</b></description>
		/// <description><b>LONG</b>/ <b>Long</b></description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_NAME</b></description>
		/// <description><b>BSTR</b>/ <b>String</b></description>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="varReserved">Reserved for future use.</param>
		/// <remarks>You must call the <c>Submit</c> method to persist any changes made by this method.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazapplicationgroup-setproperty HRESULT SetProperty( [in]
		// LONG lPropId, [in] VARIANT varProp, [in, optional] VARIANT varReserved );
		[DispId(1610743830)]
		new void SetProperty([In] AZ_PROP_CONSTANTS lPropId, [In, MarshalAs(UnmanagedType.Struct)] object varProp, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>The <b>AddPropertyItem</b> method adds the specified entity to the specified list.</summary>
		/// <param name="lPropId">
		/// <para>Property ID of the list to which to add the entity specified by the varProp parameter.</para>
		/// <para>The following table shows the possible values:</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Value</description>
		/// <description>Meaning</description>
		/// </listheader>
		/// <item>
		/// <description>
		/// <code>AZ_PROP_GROUP_APP_MEMBERS</code>
		/// </description>
		/// <description>Can also be added using the <c>AddAppMember</c> method.</description>
		/// </item>
		/// <item>
		/// <description>
		/// <code>AZ_PROP_GROUP_APP_NON_MEMBERS</code>
		/// </description>
		/// <description>Can also be added using the <c>AddAppNonMember</c> method.</description>
		/// </item>
		/// <item>
		/// <description>
		/// <code>AZ_PROP_GROUP_MEMBERS</code>
		/// </description>
		/// <description>Can also be added using the <c>AddMember</c> method.</description>
		/// </item>
		/// <item>
		/// <description>
		/// <code>AZ_PROP_GROUP_MEMBERS_NAME</code>
		/// </description>
		/// <description>Can also be added using the <c>AddMemberName</c> method.</description>
		/// </item>
		/// <item>
		/// <description>
		/// <code>AZ_PROP_GROUP_NON_MEMBERS</code>
		/// </description>
		/// <description>Can also be added using the <c>AddNonMember</c> method.</description>
		/// </item>
		/// <item>
		/// <description>
		/// <code>AZ_PROP_GROUP_NON_MEMBERS_NAME</code>
		/// </description>
		/// <description>Can also be added using the <c>AddNonMemberName</c> method.</description>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="varProp">TBD</param>
		/// <param name="varReserved">Reserved for future use.</param>
		/// <remarks>You must call the <c>Submit</c> method to persist any changes made by this method.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazapplicationgroup-addpropertyitem HRESULT
		// AddPropertyItem( [in] LONG lPropId, VARIANT varProp, [in, optional] VARIANT varReserved );
		[DispId(1610743831)]
		new void AddPropertyItem([In] AZ_PROP_CONSTANTS lPropId, [In, MarshalAs(UnmanagedType.Struct)] object varProp, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>The <b>DeletePropertyItem</b> method removes the specified entity from the specified list.</summary>
		/// <param name="lPropId">
		/// <para>
		/// Property ID of the list from which to remove the entity specified by the <i>varProp</i> parameter. The following table shows the
		/// possible values.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <description>Value</description>
		/// <description>Meaning</description>
		/// </listheader>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_GROUP_APP_MEMBERS</b></description>
		/// <description>Can also be removed using the <c>DeleteAppMember</c> method</description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_GROUP_APP_NON_MEMBERS</b></description>
		/// <description>Can also be removed using the <c>DeleteAppNonMember</c> method</description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_GROUP_MEMBERS</b></description>
		/// <description>Can also be removed using the <c>DeleteMember</c> method</description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_GROUP_MEMBERS_NAME</b></description>
		/// <description>Can also be removed using the <c>DeleteMemberName</c> method</description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_GROUP_NON_MEMBERS</b></description>
		/// <description>Can also be removed using the <c>DeleteNonMember</c> method</description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_GROUP_NON_MEMBERS_NAME</b></description>
		/// <description>Can also be removed using the <c>DeleteNonMemberName</c> method</description>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="varProp">
		/// <para>The entity to remove from the list specified by the <i>lPropId</i> parameter.</para>
		/// <para>The variant must be a <b>BSTR</b> variant.</para>
		/// <para>
		/// If AZ_PROP_GROUP_MEMBERS_NAME or AZ_PROP_GROUP_NON_MEMBERS_NAME is specified for the <i>lPropId</i> parameter, the string is the
		/// account name of the account to remove from the list. The account name must be in user principal name (UPN) format (for example,
		/// "someone@example.com"). If AZ_PROP_GROUP_APP_MEMBERS or AZ_PROP_GROUP_APP_NON_MEMBERS is specified for the <i>lPropId</i>
		/// parameter, the string is the <c>Name</c> property of the <c>IAzApplicationGroup</c> object to remove from the list.
		/// </para>
		/// </param>
		/// <param name="varReserved">Reserved for future use.</param>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazapplicationgroup-deletepropertyitem HRESULT
		// DeletePropertyItem( [in] LONG lPropId, [in] VARIANT varProp, [in, optional] VARIANT varReserved );
		[DispId(1610743832)]
		new void DeletePropertyItem([In] AZ_PROP_CONSTANTS lPropId, [In, MarshalAs(UnmanagedType.Struct)] object varProp, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>The <b>Submit</b> method persists changes made to the <c>IAzApplicationGroup</c> object.</summary>
		/// <param name="lFlags">
		/// Flags that modify the behavior of the <b>Submit</b> method. The default value is zero. If the <b>AZ_SUBMIT_FLAG_ABORT</b> flag is
		/// specified, the changes to the object are discarded and the object is updated to match the underlying policy store.
		/// </param>
		/// <param name="varReserved">Reserved for future use.</param>
		/// <remarks>
		/// <para>
		/// Any additions or modifications to an <c>IAzApplicationGroup</c> object are not persisted until the <b>Submit</b> method is called.
		/// </para>
		/// <para>
		/// A created <c>IAzApplicationGroup</c> object must be submitted before it can be referenced. The destructor for an object silently
		/// discards unsubmitted changes.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazapplicationgroup-submit HRESULT Submit( [in, optional]
		// LONG lFlags, [in, optional] VARIANT varReserved );
		[DispId(1610743833)]
		new void Submit([Optional, DefaultParameterValue((AZ_PROP_CONSTANTS)0), In] AZ_PROP_CONSTANTS lFlags, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>
		/// The <b>AddMemberName</b> method adds the specified account name to the list of accounts that belong to the application group.
		/// </summary>
		/// <param name="bstrProp">
		/// String that contains the account name to add to the list of accounts that belong to the application group. The account name must
		/// be in user principal name (UPN) format. The <c>LookupAccountName</c> function is called to retrieve the domain.
		/// </param>
		/// <param name="varReserved">Reserved for future use.</param>
		/// <remarks>
		/// <para>To view the list of account names of accounts that belong to this application group, use the <c>MembersName</c> property.</para>
		/// <para>You must call the <c>Submit</c> method to persist any changes made by this method.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazapplicationgroup-addmembername HRESULT AddMemberName(
		// [in] BSTR bstrProp, [in, optional] VARIANT varReserved );
		[DispId(1610743834)]
		new void AddMemberName([In, MarshalAs(UnmanagedType.BStr)] string bstrProp, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>
		/// The <b>DeleteMemberName</b> method removes the specified account name from the list of accounts that belong to the application group.
		/// </summary>
		/// <param name="bstrProp">
		/// String that contains the account name to remove from the list of accounts that belong to the application group. The account name
		/// must be in user principal name (UPN) format (for example, <c>someone@example.com</c>). The <c>LookupAccountName</c> function is
		/// called to retrieve the domain.
		/// </param>
		/// <param name="varReserved">Reserved for future use.</param>
		/// <remarks>To view the list of account names of accounts that belong to this application group, use the <c>MembersName</c> property.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazapplicationgroup-deletemembername HRESULT
		// DeleteMemberName( [in] BSTR bstrProp, [in, optional] VARIANT varReserved );
		[DispId(1610743835)]
		new void DeleteMemberName([In, MarshalAs(UnmanagedType.BStr)] string bstrProp, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>
		/// The <b>AddNonMemberName</b> method adds the specified account name to the list of accounts that are refused membership in the
		/// application group.
		/// </summary>
		/// <param name="bstrProp">
		/// String that contains the SID to add to the list of accounts that are refused membership in the application group. The account
		/// name must be in user principal name (UPN) format (for example, <c>someone@example.com</c>). The <c>LookupAccountName</c> function
		/// is called to retrieve the domain.
		/// </param>
		/// <param name="varReserved">Reserved for future use.</param>
		/// <remarks>
		/// <para>
		/// The application group will never have an account added using this method as a member, even if that account is specified directly
		/// or indirectly by the <c>Members</c> property.
		/// </para>
		/// <para>
		/// Denying membership to an account in an application group does not prevent that account from being assigned to a role through a
		/// different application group, nor from being granted permission to a resource through assignment to any other role.
		/// </para>
		/// <para>
		/// To view the list of account names of accounts that are refused membership in this application group, use the
		/// <c>NonMembersName</c> property.
		/// </para>
		/// <para>You must call the <c>Submit</c> method to persist any changes made by this method.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazapplicationgroup-addnonmembername HRESULT
		// AddNonMemberName( [in] BSTR bstrProp, [in, optional] VARIANT varReserved );
		[DispId(1610743836)]
		new void AddNonMemberName([In, MarshalAs(UnmanagedType.BStr)] string bstrProp, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>
		/// The <b>DeleteNonMemberName</b> method removes the specified account name from the list of accounts that are refused membership in
		/// the application group.
		/// </summary>
		/// <param name="bstrProp">
		/// String that contains the account name to remove from the list of accounts that are refused membership in the application group.
		/// The account name must be in user principal name (UPN) format (for example, <c>someone@example.com</c>). The
		/// <c>LookupAccountName</c> function is called to retrieve the domain.
		/// </param>
		/// <param name="varReserved">Reserved for future use.</param>
		/// <remarks>
		/// To view the list of account names of accounts that are refused membership in this application group, use the
		/// <c>NonMembersName</c> property.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazapplicationgroup-deletenonmembername HRESULT
		// DeleteNonMemberName( [in] BSTR bstrProp, [in, optional] VARIANT varReserved );
		[DispId(1610743837)]
		new void DeleteNonMemberName([In, MarshalAs(UnmanagedType.BStr)] string bstrProp, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>
		/// <para>The <b>MembersName</b> property retrieves the account names of accounts that belong to the application group.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <remarks>
		/// <para>This property is ignored unless the <c>Type</c> property is AZ_GROUPTYPE_BASIC.</para>
		/// <para>In JScript, the returned <c>SAFEARRAY</c> must be converted to the JScript <c>Array</c> object.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazapplicationgroup-get_membersname HRESULT
		// get_MembersName( VARIANT *pvarProp );
		[DispId(1610743838)]
		new object MembersName
		{
			[DispId(1610743838)]
			[return: MarshalAs(UnmanagedType.Struct)]
			get;
		}

		/// <summary>
		/// <para>
		/// The <b>NonMembersName</b> property retrieves the account names of accounts that are refused membership in the application group.
		/// </para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// The application group will never have an account specified by this property as a member, even if that account is specified
		/// directly or indirectly by the <c>Members</c> property.
		/// </para>
		/// <para>
		/// Denying membership to an account in an application group does not prevent that account from being assigned to a role through a
		/// different application group, nor from being granted permission to a resource through assignment to any other role.
		/// </para>
		/// <para>This property is ignored unless the <c>Type</c> property is AZ_GROUPTYPE_BASIC.</para>
		/// <para>In JScript, the returned <c>SAFEARRAY</c> must be converted to the JScript <c>Array</c> object.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazapplicationgroup-get_nonmembersname HRESULT
		// get_NonMembersName( VARIANT *pvarProp );
		[DispId(1610743839)]
		new object NonMembersName
		{
			[DispId(1610743839)]
			[return: MarshalAs(UnmanagedType.Struct)]
			get;
		}

		/// <summary>
		/// <para>The <b>BizRule</b> property gets or sets the script that determines membership for this application group.</para>
		/// <para>This property is read/write.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazapplicationgroup2-get_bizrule HRESULT get_BizRule( BSTR
		// *pbstrProp );
		[DispId(1610809344)]
		string BizRule
		{
			[DispId(1610809344)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
			[DispId(1610809344)]
			[param: In]
			[param: MarshalAs(UnmanagedType.BStr)]
			set;
		}

		/// <summary>
		/// <para>
		/// The <b>BizRuleLanguage</b> method gets or sets the programming language of the business rule script associated with this
		/// application group. The value of this property can be either "VBScript" or "JScript".
		/// </para>
		/// <para>This property is read/write.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazapplicationgroup2-get_bizrulelanguage HRESULT
		// get_BizRuleLanguage( BSTR *pbstrProp );
		[DispId(1610809346)]
		string BizRuleLanguage
		{
			[DispId(1610809346)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
			[DispId(1610809346)]
			[param: In]
			[param: MarshalAs(UnmanagedType.BStr)]
			set;
		}

		/// <summary>
		/// <para>
		/// The <b>BizRuleImportedPath</b> method gets or sets the path of the file that contains the business rule script associated with
		/// this application group.
		/// </para>
		/// <para>This property is read/write.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazapplicationgroup2-get_bizruleimportedpath HRESULT
		// get_BizRuleImportedPath( BSTR *pbstrProp );
		[DispId(1610809348)]
		string BizRuleImportedPath
		{
			[DispId(1610809348)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
			[DispId(1610809348)]
			[param: In]
			[param: MarshalAs(UnmanagedType.BStr)]
			set;
		}

		/// <summary>
		/// <para>
		/// The <b>RoleAssignments</b> method gets a collection of <c>IAzRoleAssignment</c> objects associated with this application group.
		/// </para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <param name="bstrScopeName">
		/// Provides a scope name to include in the search for <b>IAzRoleAssignment</b> objects. If this parameter is <b>NULL</b>, the search
		/// is performed in the global scope.
		/// </param>
		/// <param name="bRecursive">Indicates if the search for <b>IAzRoleAssignment</b> objects should be performed recursively.</param>
		/// <returns>The list of <c>IAzRoleAssignment</c> objects associated with the specified application group.</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazapplicationgroup2-roleassignments HRESULT
		// RoleAssignments( BSTR bstrScopeName, VARIANT_BOOL bRecursive, IAzRoleAssignments **ppRoleAssignments );
		[DispId(1610809350)]
		[return: MarshalAs(UnmanagedType.Interface)]
		IAzRoleAssignments RoleAssignments([In, MarshalAs(UnmanagedType.BStr)] string? bstrScopeName, [In] bool bRecursive);
	}

	/// <summary>The <b>IAzApplicationGroups</b> interface represents a collection of <c>IAzApplicationGroup</c> objects.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nn-azroles-iazapplicationgroups
	[PInvokeData("azroles.h", MSDNShortId = "NN:azroles.IAzApplicationGroups")]
	[ComImport, Guid("4CE66AD5-9F3C-469D-A911-B99887A7E685")]
	public interface IAzApplicationGroups : IEnumerable
	{
		/// <summary>
		/// <para>
		/// The <b>Item</b> property retrieves the <c>IAzApplicationGroup</c> object at the specified index into the
		/// <c>IAzApplicationGroups</c> collection.
		/// </para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <value/>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazapplicationgroups-get_item HRESULT get_Item( LONG Index,
		// VARIANT *pvarObtPtr );
		[DispId(0)]
		object this[[In] int Index]
		{
			[DispId(0)]
			[return: MarshalAs(UnmanagedType.Struct)]
			get;
		}

		/// <summary>
		/// <para>The <b>Count</b> property retrieves the number of <c>IAzApplicationGroup</c> objects in the collection.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <remarks>
		/// The <b>Count</b> property can be used to specify the last <c>IAzApplicationGroup</c> object in a collection when retrieving a
		/// specific <b>IAzApplicationGroup</b> object using the <c>IAzApplicationGroups.Item</c> property.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazapplicationgroups-get_count HRESULT get_Count( LONG
		// *plCount );
		[DispId(1)]
		int Count
		{
			[DispId(1)]
			get;
		}

		/// <summary>
		/// The _NewEnum property retrieves an IEnumVARIANT interface on an object that can be used to enumerate the collection. This
		/// property is hidden within Visual Basic and Visual Basic Scripting Edition (VBScript).
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <returns>An <see cref="IEnumerator"/> that can be used to enumerate the collection.</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazapplicationgroups-get__newenum
		[DispId(-4)]
		[return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalType = "System.Runtime.InteropServices.CustomMarshalers.EnumeratorToEnumVariantMarshaler, CustomMarshalers, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
		new IEnumerator GetEnumerator();
	}

	/// <summary>The <b>IAzApplications</b> interface represents a collection of <c>IAzApplication</c> objects.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nn-azroles-iazapplications
	[PInvokeData("azroles.h", MSDNShortId = "NN:azroles.IAzApplications")]
	[ComImport, Guid("929B11A9-95C5-4A84-A29A-20AD42C2F16C")]
	public interface IAzApplications : IEnumerable
	{
		/// <summary>
		/// <para>
		/// The <b>Item</b> property retrieves the <c>IAzApplication</c> object at the specified index into the <c>IAzApplications</c> collection.
		/// </para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <value/>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazapplications-get_item HRESULT get_Item( long Index,
		// VARIANT *pvarObtPtr );
		[DispId(0)]
		object this[[In] int Index]
		{
			[DispId(0)]
			[return: MarshalAs(UnmanagedType.Struct)]
			get;
		}

		/// <summary>
		/// <para>The <b>Count</b> property retrieves the number of <c>IAzApplication</c> objects in the collection.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <remarks>
		/// The <b>Count</b> property can be used to specify the last <c>IAzApplication</c> object in a collection when retrieving a specific
		/// <b>IAzApplication</b> object using the <c>IAzApplications.Item</c> property.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazapplications-get_count HRESULT get_Count( long *plCount );
		[DispId(1)]
		int Count
		{
			[DispId(1)]
			get;
		}

		/// <summary>
		/// <para>
		/// The <b>_NewEnum</b> property retrieves an <c>IEnumVARIANT</c> interface on an object that can be used to enumerate the
		/// collection. This property is hidden within Visual Basic and Visual Basic Scripting Edition (VBScript).
		/// </para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <remarks>
		/// This property is provided for use by the <c>For Each</c> keyword in Visual Basic and the <c>foreach</c> keyword in Visual C#.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazapplications-get__newenum HRESULT get__NewEnum(
		// LPUNKNOWN *ppEnumPtr );
		[DispId(-4)]
		[return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalType = "System.Runtime.InteropServices.CustomMarshalers.EnumeratorToEnumVariantMarshaler, CustomMarshalers, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
		new IEnumerator GetEnumerator();
	}

	/// <summary>Defines the container that is the root of the authorization policy store.</summary>
	/// <remarks>
	/// <para>
	/// The <b>AzAuthorizationStore</b> object is named according to the URL passed to the <a
	/// href="https://docs.microsoft.com/windows/desktop/api/azroles/nf-azroles-iazauthorizationstore-initialize">Initialize</a> method. The
	/// object has no name within the policy store.
	/// </para>
	/// <para>
	/// The application must ensure that the user context from which the <a
	/// href="https://docs.microsoft.com/windows/desktop/api/azroles/nf-azroles-iazauthorizationstore-initialize">Initialize</a> method is
	/// called is used for all future access to the <b>AzAuthorizationStore</b> object, except for the <a
	/// href="https://docs.microsoft.com/windows/desktop/api/azroles/nf-azroles-iazapplication-initializeclientcontextfromtoken">IAzApplication::InitializeClientContextFromToken</a> method.
	/// </para>
	/// <para>
	/// <b>Note</b>  If an XML store is used over a network, the traffic is not automatically encrypted. IPsec can be used to encrypt the
	/// authorization information in transit.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/windows/win32/api/azroles/nn-azroles-iazauthorizationstore
	[PInvokeData("azroles.h", MSDNShortId = "NN:azroles.IAzAuthorizationStore")]
	[ComImport, Guid("EDBD9CA9-9B82-4F6A-9E8B-98301E450F14"), CoClass(typeof(AzAuthorizationStore))]
	public interface IAzAuthorizationStore
	{
		/// <summary>
		/// <para>The <b>Description</b> property sets or retrieves a comment that describes the operation.</para>
		/// <para>This property is read/write.</para>
		/// </summary>
		/// <remarks>The maximum length of the <b>Description</b> property is 1,024 characters.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazauthorizationstore-get_description HRESULT
		// get_Description( BSTR *pbstrDescription );
		[DispId(1610743808)]
		string Description
		{
			[DispId(1610743808)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
			[DispId(1610743808)]
			[param: In]
			[param: MarshalAs(UnmanagedType.BStr)]
			set;
		}

		/// <summary>
		/// <para>The <b>ApplicationData</b> property sets or retrieves an opaque field that can be used by the application to store information.</para>
		/// <para>This property is read/write.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// <b>Important</b>  Policy administrators can read from and write to this property. Applications should not store data in the
		/// <b>ApplicationData</b> property that should not be available to the policy administrator.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazauthorizationstore-put_applicationdata HRESULT
		// put_ApplicationData( BSTR bstrApplicationData );
		[DispId(1610743810)]
		string ApplicationData
		{
			[DispId(1610743810)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
			[DispId(1610743810)]
			[param: In]
			[param: MarshalAs(UnmanagedType.BStr)]
			set;
		}

		/// <summary>
		/// <para>The <b>DomainTimeout</b> property sets or retrieves the time in milliseconds after which a domain is determined to be unreachable.</para>
		/// <para>This property is read/write.</para>
		/// </summary>
		/// <remarks>After the specified time-out interval, LDAP query group membership will attempt to contact a domain controller again.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazauthorizationstore-put_domaintimeout HRESULT
		// put_DomainTimeout( LONG lProp );
		[DispId(1610743812)]
		int DomainTimeout
		{
			[DispId(1610743812)]
			get;
			[DispId(1610743812)]
			[param: In]
			set;
		}

		/// <summary>
		/// <para>
		/// The <b>ScriptEngineTimeout</b> property sets or retrieves the time in milliseconds that the <c>IAzClientContext::AccessCheck</c>
		/// method will wait for a Business Rule (BizRule) to complete execution before canceling it.
		/// </para>
		/// <para>This property is read/write.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazauthorizationstore-put_scriptenginetimeout HRESULT
		// put_ScriptEngineTimeout( LONG lProp );
		[DispId(1610743814)]
		int ScriptEngineTimeout
		{
			[DispId(1610743814)]
			get;
			[DispId(1610743814)]
			[param: In]
			set;
		}

		/// <summary>
		/// <para>
		/// The <b>MaxScriptEngines</b> property sets or retrieves the maximum number of Business Rule (BizRule) script engines that will be cached.
		/// </para>
		/// <para>This property is read/write.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazauthorizationstore-put_maxscriptengines HRESULT
		// put_MaxScriptEngines( LONG lProp );
		[DispId(1610743816)]
		int MaxScriptEngines
		{
			[DispId(1610743816)]
			get;
			[DispId(1610743816)]
			[param: In]
			set;
		}

		/// <summary>
		/// <para>The <b>GenerateAudits</b> property sets or retrieves a value that indicates whether run-time audits should be generated.</para>
		/// <para>This property is read/write.</para>
		/// </summary>
		/// <remarks>
		/// The <b>GenerateAudits</b> property controls application initialization, client context creation, client context deletion, and
		/// access check run-time auditing. The client context can be created by <c>security identifier</c> (SID), name, or token.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazauthorizationstore-put_generateaudits HRESULT
		// put_GenerateAudits( BOOL bProp );
		[DispId(1610743818)]
		bool GenerateAudits
		{
			[DispId(1610743818)]
			[return: MarshalAs(UnmanagedType.Bool)]
			get;
			[DispId(1610743818)]
			[param: In]
			[param: MarshalAs(UnmanagedType.Bool)]
			set;
		}

		/// <summary>
		/// <para>
		/// The <b>Writable</b> property retrieves a value that indicates whether the object can be modified by the user context that called
		/// the <c>Initialize</c> method.
		/// </para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazauthorizationstore-get_writable HRESULT get_Writable(
		// BOOL *pfProp );
		[DispId(1610743820)]
		bool Writable
		{
			[DispId(1610743820)]
			[return: MarshalAs(UnmanagedType.Bool)]
			get;
		}

		/// <summary>The GetProperty method returns the IAzApplicationGroup object property with the specified property ID.</summary>
		/// <param name="lPropId">
		/// <para>Property ID of the <c>IAzApplicationGroup</c> object property to return. The following table shows the possible values.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Value</description>
		/// <description>Meaning</description>
		/// </listheader>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_DESCRIPTION</b></description>
		/// <description>Also accessed through the <c>Description</c> property</description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_GROUP_TYPE</b></description>
		/// <description>Also accessed through the <c>Type</c> property</description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_GROUP_LDAP_QUERY</b></description>
		/// <description>Also accessed through the <c>LdapQuery</c> property</description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_NAME</b></description>
		/// <description>Also accessed through the <c>Name</c> property</description>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="varReserved">Reserved for future use.</param>
		/// <returns>A pointer to the returned IAzApplicationGroup object property.</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazapplicationgroup-getproperty
		[DispId(1610743821)]
		[return: MarshalAs(UnmanagedType.Struct)]
		object GetProperty([In] AZ_PROP_CONSTANTS lPropId, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>
		/// The <b>SetProperty</b> method sets the specified value to the <c>AzAuthorizationStore</c> object property with the specified
		/// property ID.
		/// </summary>
		/// <param name="lPropId">
		/// <para>Property ID of the <c>AzAuthorizationStore</c> object property to set. The following table shows the possible values.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Value</description>
		/// <description>Meaning</description>
		/// </listheader>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_AZSTORE_DOMAIN_TIMEOUT</b></description>
		/// <description>Also accessed through the <c>DomainTimeout</c> property</description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_AZSTORE_MAX_SCRIPT_ENGINES</b></description>
		/// <description>Also accessed through the <c>MaxScriptEngines</c> property</description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_AZSTORE_SCRIPT_ENGINE_TIMEOUT</b></description>
		/// <description>Also accessed through the <c>ScriptEngineTimeout</c> property</description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_APPLICATION_DATA</b></description>
		/// <description>Also accessed through the <c>ApplicationData</c> property</description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_APPLY_STORE_SACL</b></description>
		/// <description>Also accessed through the <c>ApplyStoreSacl</c> property</description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_DESCRIPTION</b></description>
		/// <description>Also accessed through the <c>Description</c> property</description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_GENERATE_AUDITS</b></description>
		/// <description>Also accessed through the <c>GenerateAudits</c> property</description>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="varProp">
		/// <para>
		/// Value to set to the <c>AzAuthorizationStore</c> object property specified by the <i>lPropId</i> parameter. The following table
		/// shows the type of data that must be used depending on the value of the <i>lPropId</i> parameter.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <description><i>lPropId</i> value</description>
		/// <description>Data type</description>
		/// </listheader>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_AZSTORE_DOMAIN_TIMEOUT</b></description>
		/// <description><b>LONG</b></description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_AZSTORE_MAX_SCRIPT_ENGINES</b></description>
		/// <description><b>LONG</b></description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_AZSTORE_SCRIPT_ENGINE_TIMEOUT</b></description>
		/// <description><b>LONG</b></description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_APPLICATION_DATA</b></description>
		/// <description><b>BSTR</b></description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_APPLY_STORE_SACL</b></description>
		/// <description><b>BOOL</b></description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_DESCRIPTION</b></description>
		/// <description><b>BSTR</b></description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_GENERATE_AUDITS</b></description>
		/// <description><b>BOOL</b></description>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="varReserved">Reserved for future use.</param>
		/// <remarks>You must call the <c>Submit</c> method to persist any changes made by this method.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazauthorizationstore-setproperty HRESULT SetProperty( [in]
		// LONG lPropId, [in] VARIANT varProp, [in, optional] VARIANT varReserved );
		[DispId(1610743822)]
		void SetProperty([In] AZ_PROP_CONSTANTS lPropId, [In, MarshalAs(UnmanagedType.Struct)] object varProp, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>The <b>AddPropertyItem</b> method adds the specified principal to the specified list of principals.</summary>
		/// <param name="lPropId">
		/// <para>
		/// Property ID of the list of principals to which to add the principal specified by the <i>varProp</i> parameter. This parameter can
		/// be one of the following values.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <description>Value</description>
		/// <description>Meaning</description>
		/// </listheader>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_POLICY_ADMINS</b></description>
		/// <description>Can also be added by using the <c>AddPolicyAdministrator</c> method.</description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_POLICY_ADMINS_NAME</b></description>
		/// <description>Can also be added by using the <c>AddPolicyAdministratorName</c> method.</description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_POLICY_READERS</b></description>
		/// <description>Can also be added by using the <c>AddPolicyReader</c> method.</description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_POLICY_READERS_NAME</b></description>
		/// <description>Can also be added by using the <c>AddPolicyReaderName</c> method.</description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_DELEGATED_POLICY_USERS</b></description>
		/// <description>Can also be added by using the <c>AddDelegatedPolicyUser</c> method.</description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_DELEGATED_POLICY_USERS_NAME</b></description>
		/// <description>Can also be added by using the <c>AddDelegatedPolicyUserName</c> method.</description>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="varProp">
		/// <para>Principal to add to the list of principals specified by the <i>lPropId</i> parameter.</para>
		/// <para>The variant must be a <b>BSTR</b> variant.</para>
		/// <para>
		/// If AZ_PROP_POLICY_ADMINS_NAME, AZ_PROP_POLICY_READERS_NAME, or AZ_PROP_DELEGATED_POLICY_USERS_NAME is specified for the
		/// <i>lPropId</i> parameter, the string is the account name of the account to add to the list. The account name must be in <c>user
		/// principal name</c> (UPN) format (for example, "someone@example.com").
		/// </para>
		/// </param>
		/// <param name="varReserved">Reserved for future use.</param>
		/// <remarks>You must call the <c>Submit</c> method to persist any changes made by this method.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazauthorizationstore-addpropertyitem HRESULT
		// AddPropertyItem( [in] LONG lPropId, [in] VARIANT varProp, [in, optional] VARIANT varReserved );
		[DispId(1610743823)]
		void AddPropertyItem([In] AZ_PROP_CONSTANTS lPropId, [In, MarshalAs(UnmanagedType.Struct)] object varProp, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>The <b>DeletePropertyItem</b> method removes the specified principal from the specified list of principals.</summary>
		/// <param name="lPropId">
		/// <para>
		/// Property ID of the list of principals from which to remove the principal specified by the <i>varProp</i> parameter. The following
		/// table shows the possible values.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <description>Value</description>
		/// <description>Meaning</description>
		/// </listheader>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_POLICY_ADMINS</b></description>
		/// <description>Can also be removed using the <c>DeletePolicyAdministrator</c> method</description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_POLICY_ADMINS_NAME</b></description>
		/// <description>Can also be removed using the <c>DeletePolicyAdministratorName</c> method</description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_POLICY_READERS</b></description>
		/// <description>Can also be removed using the <c>DeletePolicyReader</c> method</description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_POLICY_READERS_NAME</b></description>
		/// <description>Can also be removed using the <c>DeletePolicyReaderName</c> method</description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_DELEGATED_POLICY_USERS</b></description>
		/// <description>Can also be removed using the <c>DeleteDelegatedPolicyUser</c> method</description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_DELEGATED_POLICY_USERS_NAME</b></description>
		/// <description>Can also be removed using the <c>DeleteDelegatedPolicyUserName</c> method</description>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="varProp">
		/// <para>The principal to remove from the list of principals specified by the <i>lPropId</i> parameter.</para>
		/// <para>The variant must be a <b>BSTR</b> variant.</para>
		/// <para>
		/// If AZ_PROP_POLICY_ADMINS_NAME, AZ_PROP_POLICY_READERS_NAME, or AZ_PROP_DELEGATED_POLICY_USERS_NAME is specified for the
		/// <i>lPropId</i> parameter, the string is the account name of the account to remove from the list. The account name must be in user
		/// principal name (UPN) format (for example, "someone@example.com").
		/// </para>
		/// </param>
		/// <param name="varReserved">Reserved for future use.</param>
		/// <remarks>You must call the <c>Submit</c> method to persist any changes made by this method.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazauthorizationstore-deletepropertyitem HRESULT
		// DeletePropertyItem( [in] LONG lPropId, [in] VARIANT varProp, [in, optional] VARIANT varReserved );
		[DispId(1610743824)]
		void DeletePropertyItem([In] AZ_PROP_CONSTANTS lPropId, [In, MarshalAs(UnmanagedType.Struct)] object varProp, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>
		/// <para>
		/// The <b>PolicyAdministrators</b> property retrieves the <c>security identifiers</c> (SIDs) of principals that act as policy
		/// administrators in text form.
		/// </para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <remarks>
		/// <para>Policy administrators for an object can perform the following tasks:</para>
		/// <list type="bullet">
		/// <item>
		/// <description>Read the object</description>
		/// </item>
		/// <item>
		/// <description>Write attributes to the object</description>
		/// </item>
		/// <item>
		/// <description>Read attributes of child objects of the object</description>
		/// </item>
		/// <item>
		/// <description>Write attributes to child objects of the object</description>
		/// </item>
		/// <item>
		/// <description>Delete the object</description>
		/// </item>
		/// <item>
		/// <description>Delete child objects of the object</description>
		/// </item>
		/// <item>
		/// <description>Create child objects of the object</description>
		/// </item>
		/// </list>
		/// <para>In JScript, the returned <c>SAFEARRAY</c> must be converted to the JScript <c>Array</c> object.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazauthorizationstore-get_policyadministrators HRESULT
		// get_PolicyAdministrators( VARIANT *pvarAdmins );
		[DispId(1610743825)]
		object PolicyAdministrators
		{
			[DispId(1610743825)]
			[return: MarshalAs(UnmanagedType.Struct)]
			get;
		}

		/// <summary>
		/// <para>
		/// The <b>PolicyReaders</b> property retrieves the <c>security identifiers</c> (SIDs) of principals that act as policy readers in
		/// text form.
		/// </para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// Policy readers for an object can read attributes for the object and for child objects of the object. Readers can also use the
		/// policy; for example, readers can call the <c>AccessCheck</c> method. Readers cannot modify the object or its child objects.
		/// </para>
		/// <para>In JScript, the returned <c>SAFEARRAY</c> must be converted to the JScript <c>Array</c> object.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazauthorizationstore-get_policyreaders HRESULT
		// get_PolicyReaders( VARIANT *pvarReaders );
		[DispId(1610743826)]
		object PolicyReaders
		{
			[DispId(1610743826)]
			[return: MarshalAs(UnmanagedType.Struct)]
			get;
		}

		/// <summary>
		/// The <b>AddPolicyAdministrator</b> method adds the specified <c>security identifier</c> (SID) in text form to the list of
		/// principals that act as policy administrators.
		/// </summary>
		/// <param name="bstrAdmin">Text form of the SID to add to the list of policy administrators.</param>
		/// <param name="varReserved">Reserved for future use.</param>
		/// <remarks>
		/// <para>Policy administrators for an object can perform the following tasks:</para>
		/// <list type="bullet">
		/// <item>
		/// <description>Read the object</description>
		/// </item>
		/// <item>
		/// <description>Write attributes to the object</description>
		/// </item>
		/// <item>
		/// <description>Read attributes of child objects of the object</description>
		/// </item>
		/// <item>
		/// <description>Write attributes to child objects of the object</description>
		/// </item>
		/// <item>
		/// <description>Delete the object</description>
		/// </item>
		/// <item>
		/// <description>Delete child objects of the object</description>
		/// </item>
		/// <item>
		/// <description>Create child objects of the object</description>
		/// </item>
		/// </list>
		/// <para>To view the list of policy administrators, use the <c>PolicyAdministrators</c> property.</para>
		/// <para>You must call the <c>Submit</c> method to persist any changes made by this method.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazauthorizationstore-addpolicyadministrator HRESULT
		// AddPolicyAdministrator( [in] BSTR bstrAdmin, [in, optional] VARIANT varReserved );
		[DispId(1610743827)]
		void AddPolicyAdministrator([In, MarshalAs(UnmanagedType.BStr)] string bstrAdmin, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>
		/// The <b>DeletePolicyAdministrator</b> method removes the specified <c>security identifier</c> (SID) in text form from the list of
		/// principals that act as policy administrators.
		/// </summary>
		/// <param name="bstrAdmin">Text form of the SID to remove from the list of policy administrators.</param>
		/// <param name="varReserved">Reserved for future use.</param>
		/// <remarks>
		/// <para>Policy administrators for an object can perform the following tasks:</para>
		/// <list type="bullet">
		/// <item>
		/// <description>Read the object</description>
		/// </item>
		/// <item>
		/// <description>Write attributes to the object</description>
		/// </item>
		/// <item>
		/// <description>Read attributes of child objects of the object</description>
		/// </item>
		/// <item>
		/// <description>Write attributes to child objects of the object</description>
		/// </item>
		/// <item>
		/// <description>Delete the object</description>
		/// </item>
		/// <item>
		/// <description>Delete child objects of the object</description>
		/// </item>
		/// <item>
		/// <description>Create child objects of the object</description>
		/// </item>
		/// </list>
		/// <para>To view the list of policy administrators, use the <c>PolicyAdministrators</c> property.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazauthorizationstore-deletepolicyadministrator HRESULT
		// DeletePolicyAdministrator( [in] BSTR bstrAdmin, [in, optional] VARIANT varReserved );
		[DispId(1610743828)]
		void DeletePolicyAdministrator([In, MarshalAs(UnmanagedType.BStr)] string bstrAdmin, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>
		/// The <b>AddPolicyReader</b> method adds the specified <c>security identifier</c> (SID) in text form to the list of principals that
		/// act as policy readers.
		/// </summary>
		/// <param name="bstrReader">Text form of the SID to add to the list of policy readers.</param>
		/// <param name="varReserved">Reserved for future use.</param>
		/// <remarks>
		/// <para>
		/// Policy readers for an object can read attributes for the object and for child objects of the object. Readers can also use the
		/// policy; for example, readers can call the <c>AccessCheck</c> method. Readers cannot modify the object or its child objects.
		/// </para>
		/// <para>To view the list of policy readers, use the <c>PolicyReaders</c> property.</para>
		/// <para>You must call the <c>Submit</c> method to persist any changes made by this method.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazauthorizationstore-addpolicyreader HRESULT
		// AddPolicyReader( [in] BSTR bstrReader, [in, optional] VARIANT varReserved );
		[DispId(1610743829)]
		void AddPolicyReader([In, MarshalAs(UnmanagedType.BStr)] string bstrReader, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>
		/// The <b>DeletePolicyReader</b> method removes the specified <c>security identifier</c> (SID) in text form from the list of
		/// principals that act as policy readers.
		/// </summary>
		/// <param name="bstrReader">Text form of the SID to remove from the list of policy readers.</param>
		/// <param name="varReserved">Reserved for future use.</param>
		/// <remarks>
		/// <para>
		/// Policy readers for an object can read attributes for the object and for child objects of the object. Readers can also use the
		/// policy; for example, readers can call the <c>AccessCheck</c> method. Readers cannot modify the object or its child objects.
		/// </para>
		/// <para>To view the list of policy readers, use the <c>PolicyReaders</c> property.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazauthorizationstore-deletepolicyreader HRESULT
		// DeletePolicyReader( [in] BSTR bstrReader, [in, optional] VARIANT varReserved );
		[DispId(1610743830)]
		void DeletePolicyReader([In, MarshalAs(UnmanagedType.BStr)] string bstrReader, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>The Initialize method initializes the authorization manager.</summary>
		/// <param name="lFlags">Flags that control the behavior of the initialization.</param>
		/// <param name="bstrPolicyURL">Location of the persistent copy of the authorization policy database.</param>
		/// <param name="varReserved">Reserved for future use.</param>
		[DispId(1610743831)]
		void Initialize([In] AZ_PROP_CONSTANTS lFlags, [In, MarshalAs(UnmanagedType.BStr)] string bstrPolicyURL, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>The <b>UpdateCache</b> method updates the cache of objects and object attributes to match the underlying policy store.</summary>
		/// <param name="varReserved">Reserved for future use.</param>
		/// <remarks>
		/// <para>
		/// When the <b>UpdateCache</b> method is called, all changes to the persistent store after the last call to the <c>Initialize</c>
		/// method or to the <b>UpdateCache</b> method are incorporated into the cache. Any changes to the cache that have not been submitted
		/// using the <c>Submit</c> method override the changes to the store.
		/// </para>
		/// <para>
		/// Most stores should be stable and have few changes. Providers are expected to implement this method to efficiently determine
		/// whether changes have been written to the physical store since the last update.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazauthorizationstore-updatecache HRESULT UpdateCache( [in,
		// optional] VARIANT varReserved );
		[DispId(1610743832)]
		void UpdateCache([Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>The <b>Delete</b> method deletes the policy store currently in use by the <c>AzAuthorizationStore</c> object.</summary>
		/// <param name="varReserved">Reserved for future use.</param>
		/// <remarks>
		/// <para>
		/// When the <b>Delete</b> method is called, the <c>AzAuthorizationStore</c> object returns to an uninitialized state. The
		/// <c>Initialize</c> method can then be called to reinitialize the object.
		/// </para>
		/// <para>
		/// <para>Important</para>
		/// <para>
		/// All objects opened by clients on the policy store (for example, <c>IAzApplication</c> objects created using
		/// <c>CreateApplication</c>) must be released before you call the <b>Delete</b> method. If the <b>Delete</b> method is called on an
		/// <c>AzAuthorizationStore</c> object whose current policy store contains child objects,
		/// <b>HRESULT_FROM_WIN32(ERROR_SERVER_HAS_OPEN_HANDLES)</b> is returned.
		/// </para>
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazauthorizationstore-delete HRESULT Delete( [in, optional]
		// VARIANT varReserved );
		[DispId(1610743833)]
		void Delete([Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>
		/// <para>
		/// The <b>Applications</b> property retrieves an <c>IAzApplications</c> object that is used to enumerate <c>IAzApplication</c>
		/// objects from the policy store.
		/// </para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <remarks>
		/// This property can be used only to enumerate <c>IAzApplication</c> objects that are direct child objects of the
		/// <c>AzAuthorizationStore</c> object.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazauthorizationstore-get_applications HRESULT
		// get_Applications( IAzApplications **ppAppCollection );
		[DispId(1610743834)]
		IAzApplications Applications
		{
			[DispId(1610743834)]
			[return: MarshalAs(UnmanagedType.Interface)]
			get;
		}

		/// <summary>The <b>OpenApplication</b> method opens the <c>IAzApplication</c> object with the specified name.</summary>
		/// <param name="bstrApplicationName">Name of the <c>IAzApplication</c> object to open.</param>
		/// <param name="varReserved">Reserved for future use.</param>
		/// <returns>A pointer to a pointer to the opened <c>IAzApplication</c> object.</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazauthorizationstore-openapplication HRESULT
		// OpenApplication( [in] BSTR bstrApplicationName, [in, optional] VARIANT varReserved, [out] IAzApplication **ppApplication );
		[DispId(1610743835)]
		[return: MarshalAs(UnmanagedType.Interface)]
		IAzApplication OpenApplication([In, MarshalAs(UnmanagedType.BStr)] string bstrApplicationName, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>The <b>CreateApplication</b> method creates an <c>IAzApplication</c> object with the specified name.</summary>
		/// <param name="bstrApplicationName">Name for the new <c>IAzApplication</c> object.</param>
		/// <param name="varReserved">Reserved for future use.</param>
		/// <returns>A pointer to a pointer to the created <c>IAzApplication</c> object.</returns>
		/// <remarks>
		/// <para>You must call the <c>IAzApplication::Submit</c> method to persist any changes made by the returned object.</para>
		/// <para>The returned <c>IAzApplication</c> object is an immediate child object of the <c>AzAuthorizationStore</c> object.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazauthorizationstore-createapplication HRESULT
		// CreateApplication( [in] BSTR bstrApplicationName, [in, optional] VARIANT varReserved, [out] IAzApplication **ppApplication );
		[DispId(1610743836)]
		[return: MarshalAs(UnmanagedType.Interface)]
		IAzApplication CreateApplication([In, MarshalAs(UnmanagedType.BStr)] string bstrApplicationName, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>
		/// The <b>DeleteApplication</b> method removes the <c>IAzApplication</c> object with the specified name from the
		/// <c>AzAuthorizationStore</c> object.
		/// </summary>
		/// <param name="bstrApplicationName">Name of the <c>IAzApplication</c> object to delete.</param>
		/// <param name="varReserved">Reserved for future use.</param>
		/// <remarks>
		/// If the deleted <c>IAzApplication</c> object has child objects, those objects are deleted, as well. If there are any
		/// <b>IAzApplication</b> references to an <b>IAzApplication</b> object that has been deleted from the cache, the
		/// <b>IAzApplication</b> object can no longer be used. In C++, you must release references to deleted <b>IAzApplication</b> objects
		/// by calling the <c>IUnknown::Release</c> method. In C# and Visual Basic, references to deleted objects are automatically released.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazauthorizationstore-deleteapplication HRESULT
		// DeleteApplication( [in] BSTR bstrApplicationName, [in, optional] VARIANT varReserved );
		[DispId(1610743837)]
		void DeleteApplication([In, MarshalAs(UnmanagedType.BStr)] string bstrApplicationName, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>
		/// <para>
		/// The <b>ApplicationGroups</b> property retrieves an <c>IAzApplicationGroups</c> object that is used to enumerate
		/// <c>IAzApplicationGroup</c> objects from the policy data.
		/// </para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <remarks>
		/// This property can be used only to enumerate <c>IAzApplicationGroup</c> objects that are direct child objects of the
		/// <c>AzAuthorizationStore</c> object.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazauthorizationstore-get_applicationgroups HRESULT
		// get_ApplicationGroups( IAzApplicationGroups **ppGroupCollection );
		[DispId(1610743838)]
		IAzApplicationGroups ApplicationGroups
		{
			[DispId(1610743838)]
			[return: MarshalAs(UnmanagedType.Interface)]
			get;
		}

		/// <summary>The <b>CreateApplicationGroup</b> method creates an <c>IAzApplicationGroup</c> object with the specified name.</summary>
		/// <param name="bstrGroupName">Name for the new <c>IAzApplicationGroup</c> object.</param>
		/// <param name="varReserved">Reserved for future use.</param>
		/// <returns>A pointer to a pointer to the created <c>IAzApplicationGroup</c> object.</returns>
		/// <remarks>
		/// <para>You must call the <c>IAzApplicationGroup::Submit</c> method to persist any changes made to the returned object.</para>
		/// <para>The returned <c>IAzApplicationGroup</c> object is an immediate child object of the <c>AzAuthorizationStore</c> object.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazauthorizationstore-createapplicationgroup HRESULT
		// CreateApplicationGroup( [in] BSTR bstrGroupName, [in, optional] VARIANT varReserved, [out] IAzApplicationGroup **ppGroup );
		[DispId(1610743839)]
		[return: MarshalAs(UnmanagedType.Interface)]
		IAzApplicationGroup CreateApplicationGroup([In, MarshalAs(UnmanagedType.BStr)] string bstrGroupName, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>The <b>OpenApplicationGroup</b> method opens an <c>IAzApplicationGroup</c> object with the specified name.</summary>
		/// <param name="bstrGroupName">Name of the <c>IAzApplicationGroup</c> object to open.</param>
		/// <param name="varReserved">Reserved for future use.</param>
		/// <returns>A pointer to a pointer to the opened <c>IAzApplicationGroup</c> object.</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazauthorizationstore-openapplicationgroup HRESULT
		// OpenApplicationGroup( [in] BSTR bstrGroupName, [in, optional] VARIANT varReserved, [out] IAzApplicationGroup **ppGroup );
		[DispId(1610743840)]
		[return: MarshalAs(UnmanagedType.Interface)]
		IAzApplicationGroup OpenApplicationGroup([In, MarshalAs(UnmanagedType.BStr)] string bstrGroupName, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>
		/// The <b>DeleteApplicationGroup</b> method removes the <c>IAzApplicationGroup</c> object with the specified name from the
		/// <c>AzAuthorizationStore</c> object.
		/// </summary>
		/// <param name="bstrGroupName">Name of the <c>IAzApplicationGroup</c> object to delete.</param>
		/// <param name="varReserved">Reserved for future use.</param>
		/// <remarks>
		/// If there are any <c>IAzApplicationGroup</c> references to an <b>IAzApplicationGroup</b> object that has been deleted from the
		/// cache, the <b>IAzApplicationGroup</b> object can no longer be used. In C++, you must release references to deleted
		/// <b>IAzApplicationGroup</b> objects by calling the <c>IUnknown::Release</c> method. In C# and Visual Basic, references to deleted
		/// objects are automatically released.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazauthorizationstore-deleteapplicationgroup HRESULT
		// DeleteApplicationGroup( [in] BSTR bstrGroupName, [in, optional] VARIANT varReserved );
		[DispId(1610743841)]
		void DeleteApplicationGroup([In, MarshalAs(UnmanagedType.BStr)] string bstrGroupName, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>The <b>Submit</b> method persists changes made to the <c>AzAuthorizationStore</c> object.</summary>
		/// <param name="lFlags">
		/// Flags that modify the behavior of the <b>Submit</b> method. The default value is zero. If the <b>AZ_SUBMIT_FLAG_ABORT</b> flag is
		/// specified, the changes to the object are discarded and the object is updated to match the underlying policy store.
		/// </param>
		/// <param name="varReserved">Reserved for future use.</param>
		/// <remarks>
		/// <para>
		/// Any additions or modifications to an <c>AzAuthorizationStore</c> object are not persisted until the <b>Submit</b> method is
		/// called. The <c>Delete</c> method automatically submits changes.
		/// </para>
		/// <para>
		/// The <b>Submit</b> method does not extend to child objects; child objects must be individually persisted to the policy store. A
		/// created <c>AzAuthorizationStore</c> object must be submitted before it can be referenced or become a parent object. The
		/// destructor for an object silently discards unsubmitted changes.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazauthorizationstore-submit HRESULT Submit( [in] LONG
		// lFlags, [in, optional] VARIANT varReserved );
		[DispId(1610743842)]
		void Submit([Optional, DefaultParameterValue((AZ_PROP_CONSTANTS)0), In] AZ_PROP_CONSTANTS lFlags, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>
		/// <para>
		/// The <b>DelegatedPolicyUsers</b> property retrieves the <c>security identifiers</c> (SIDs) of principals that act as delegated
		/// policy users in text form.
		/// </para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// Delegated policy users are principals that are allowed to read the subset of the policy data that the policy administrator of an
		/// <c>IAzApplication</c> or <c>IAzScope</c> object uses to administer the delegated object.
		/// </para>
		/// <para><b>Note</b>  Delegated policy users are not supported for XML stores.</para>
		/// <para></para>
		/// <para>In JScript, the returned <c>SAFEARRAY</c> must be converted to the JScript <c>Array</c> object.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazauthorizationstore-get_delegatedpolicyusers HRESULT
		// get_DelegatedPolicyUsers( VARIANT *pvarDelegatedPolicyUsers );
		[DispId(1610743843)]
		object DelegatedPolicyUsers
		{
			[DispId(1610743843)]
			[return: MarshalAs(UnmanagedType.Struct)]
			get;
		}

		/// <summary>
		/// The <b>AddDelegatedPolicyUser</b> method adds the specified <c>security identifier</c> (SID) in text form to the list of
		/// principals that act as delegated policy users.
		/// </summary>
		/// <param name="bstrDelegatedPolicyUser">Text form of the SID to add to the list of delegated policy users.</param>
		/// <param name="varReserved">Reserved for future use.</param>
		/// <remarks>
		/// <para>
		/// Delegated policy users are principals that are allowed to read the subset of the policy data that the policy administrator of an
		/// <c>IAzApplication</c> or <c>IAzScope</c> object uses to administer the delegated object.
		/// </para>
		/// <para>
		/// <para>Note</para>
		/// <para>Delegated policy users are not supported for XML stores.</para>
		/// </para>
		/// <para>To view the list of delegated policy users, use the <c>DelegatedPolicyUsers</c> property.</para>
		/// <para>You must call the <c>Submit</c> method to persist any changes made by this method.</para>
		/// </remarks>
		// https://learn.microsoft.com/da-dk/windows/win32/api/azroles/nf-azroles-iazauthorizationstore-adddelegatedpolicyuser HRESULT
		// AddDelegatedPolicyUser( [in] BSTR bstrDelegatedPolicyUser, [in, optional] VARIANT varReserved );
		[DispId(1610743844)]
		void AddDelegatedPolicyUser([In, MarshalAs(UnmanagedType.BStr)] string bstrDelegatedPolicyUser, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>
		/// The <b>DeleteDelegatedPolicyUser</b> method removes the specified <c>security identifier</c> (SID) in text form from the list of
		/// principals that act as delegated policy users.
		/// </summary>
		/// <param name="bstrDelegatedPolicyUser">Text form of the SID to remove from the list of delegated policy users.</param>
		/// <param name="varReserved">Reserved for future use.</param>
		/// <remarks>
		/// <para>
		/// Delegated policy users are principals that are allowed to read the subset of the policy data that the policy administrator of an
		/// <c>IAzApplication</c> or <c>IAzScope</c> object uses to administer the delegated object.
		/// </para>
		/// <para>
		/// <para>Note</para>
		/// <para>Delegated policy users are not supported for XML stores.</para>
		/// </para>
		/// <para>To view the list of delegated policy users, use the <c>DelegatedPolicyUsers</c> property.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazauthorizationstore-deletedelegatedpolicyuser?view=vs-2017
		// HRESULT DeleteDelegatedPolicyUser( [in] BSTR bstrDelegatedPolicyUser, [in, optional] VARIANT varReserved );
		[DispId(1610743845)]
		void DeleteDelegatedPolicyUser([In, MarshalAs(UnmanagedType.BStr)] string bstrDelegatedPolicyUser, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>
		/// <para>The <b>TargetMachine</b> property retrieves the name of the computer on which account resolution should occur.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <remarks>
		/// Determination of the target computer takes into consideration active directories in local and remote domains, Distributed File
		/// System (DFS) shares, mount point, local drive, remote mapped shares, and so on.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazauthorizationstore-get_targetmachine HRESULT
		// get_TargetMachine( BSTR *pbstrTargetMachine );
		[DispId(1610743846)]
		string TargetMachine
		{
			[DispId(1610743846)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}

		/// <summary>
		/// <para>
		/// The <b>ApplyStoreSacl</b> property sets or retrieves a value that indicates whether policy audits should be generated when the
		/// authorization store is modified.
		/// </para>
		/// <para>This property is read/write.</para>
		/// </summary>
		/// <remarks>Policy audits are generated when the underlying policy store is modified. Both success and failure audits are requested.</remarks>
		// https://learn.microsoft.com/sr-latn-rs/windows/win32/api/azroles/nf-azroles-iazauthorizationstore-put_applystoresacl HRESULT
		// put_ApplyStoreSacl( BOOL bApplyStoreSacl );
		[DispId(1610743847)]
		bool ApplyStoreSacl
		{
			[DispId(1610743847)]
			[return: MarshalAs(UnmanagedType.Bool)]
			get;
			[DispId(1610743847)]
			[param: In]
			[param: MarshalAs(UnmanagedType.Bool)]
			set;
		}

		/// <summary>
		/// <para>The <b>PolicyAdministratorsName</b> property retrieves the account names of principals that act as policy administrators.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <remarks>
		/// <para>Policy administrators for an object can perform the following tasks:</para>
		/// <list type="bullet">
		/// <item>
		/// <description>Read the object</description>
		/// </item>
		/// <item>
		/// <description>Write attributes to the object</description>
		/// </item>
		/// <item>
		/// <description>Read attributes of child objects of the object</description>
		/// </item>
		/// <item>
		/// <description>Write attributes to child objects of the object</description>
		/// </item>
		/// <item>
		/// <description>Delete the object</description>
		/// </item>
		/// <item>
		/// <description>Delete child objects of the object</description>
		/// </item>
		/// <item>
		/// <description>Create child objects of the object</description>
		/// </item>
		/// </list>
		/// <para>In JScript, the returned <c>SAFEARRAY</c> must be converted to the JScript <c>Array</c> object.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazauthorizationstore-get_policyadministratorsname HRESULT
		// get_PolicyAdministratorsName( VARIANT *pvarAdmins );
		[DispId(1610743849)]
		object PolicyAdministratorsName
		{
			[DispId(1610743849)]
			[return: MarshalAs(UnmanagedType.Struct)]
			get;
		}

		/// <summary>
		/// <para>The <b>PolicyReadersName</b> property retrieves the account names of principals that act as policy readers.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// Policy readers for an object can read attributes for the object and for child objects of the object. Readers can also use the
		/// policy; for example, readers can call the <c>AccessCheck</c> method. Readers cannot modify the object or its child objects.
		/// </para>
		/// <para>In JScript, the returned <c>SAFEARRAY</c> must be converted to the JScript <c>Array</c> object.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazauthorizationstore-get_policyreadersname HRESULT
		// get_PolicyReadersName( VARIANT *pvarReaders );
		[DispId(1610743850)]
		object PolicyReadersName
		{
			[DispId(1610743850)]
			[return: MarshalAs(UnmanagedType.Struct)]
			get;
		}

		/// <summary>
		/// <para>
		/// The <b>AddPolicyAdministratorName</b> method adds the specified account name to the list of principals that act as policy administrators.
		/// </para>
		/// <para>This method is an alternate version of the <c>AddPolicyAdministrator</c> method.</para>
		/// </summary>
		/// <param name="bstrAdmin">
		/// Account name to add to the list of policy administrators. The account name must be in user principal name (UPN) format (for
		/// example, "someone@example.com"). The <c>LookupAccountName</c> function is called to retrieve the domain.
		/// </param>
		/// <param name="varReserved">Reserved for future use.</param>
		/// <remarks>
		/// <para>Policy administrators for an object can perform the following tasks:</para>
		/// <list type="bullet">
		/// <item>
		/// <description>Read the object</description>
		/// </item>
		/// <item>
		/// <description>Write attributes to the object</description>
		/// </item>
		/// <item>
		/// <description>Read attributes of child objects of the object</description>
		/// </item>
		/// <item>
		/// <description>Write attributes to child objects of the object</description>
		/// </item>
		/// <item>
		/// <description>Delete the object</description>
		/// </item>
		/// <item>
		/// <description>Delete child objects of the object</description>
		/// </item>
		/// <item>
		/// <description>Create child objects of the object</description>
		/// </item>
		/// </list>
		/// <para>To view the list of policy administrators in account name format, use the <c>PolicyAdministratorsName</c> property.</para>
		/// <para>You must call the <c>Submit</c> method to persist any changes made by this method.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazauthorizationstore-addpolicyadministratorname HRESULT
		// AddPolicyAdministratorName( [in] BSTR bstrAdmin, [in, optional] VARIANT varReserved );
		[DispId(1610743851)]
		void AddPolicyAdministratorName([In, MarshalAs(UnmanagedType.BStr)] string bstrAdmin, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>
		/// The <b>DeletePolicyAdministratorName</b> method removes the specified account name from the list of principals that act as policy administrators.
		/// </summary>
		/// <param name="bstrAdmin">
		/// The account name to remove from the list of policy administrators. The account name must be in user principal name (UPN) format
		/// (for example, "someone@example.com"). The <c>LookupAccountName</c> function is called to retrieve the domain.
		/// </param>
		/// <param name="varReserved">Reserved for future use.</param>
		/// <remarks>
		/// <para>Policy administrators for an object can perform the following tasks:</para>
		/// <list type="bullet">
		/// <item>
		/// <description>Read the object</description>
		/// </item>
		/// <item>
		/// <description>Write attributes to the object</description>
		/// </item>
		/// <item>
		/// <description>Read attributes of child objects of the object</description>
		/// </item>
		/// <item>
		/// <description>Write attributes to child objects of the object</description>
		/// </item>
		/// <item>
		/// <description>Delete the object</description>
		/// </item>
		/// <item>
		/// <description>Delete child objects of the object</description>
		/// </item>
		/// <item>
		/// <description>Create child objects of the object</description>
		/// </item>
		/// </list>
		/// <para>To view the list of policy administrators in account name format, use the <c>PolicyAdministratorsName</c> property.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazauthorizationstore-deletepolicyadministratorname HRESULT
		// DeletePolicyAdministratorName( [in] BSTR bstrAdmin, [in, optional] VARIANT varReserved );
		[DispId(1610743852)]
		void DeletePolicyAdministratorName([In, MarshalAs(UnmanagedType.BStr)] string bstrAdmin, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>
		/// The <b>AddPolicyReaderName</b> method adds the specified account name to the list of principals that act as policy readers.
		/// </summary>
		/// <param name="bstrReader">
		/// Account name to add to the list of policy readers. The account name must be in <c>user principal name</c> (UPN) format (for
		/// example, "someone@example.com"). The <c>LookupAccountName</c> function is called to retrieve the domain.
		/// </param>
		/// <param name="varReserved">Reserved for future use.</param>
		/// <remarks>
		/// <para>
		/// Policy readers for an object can read attributes for the object and for child objects of the object. Readers can also use the
		/// policy; for example, readers can call the <c>AccessCheck</c> method. Readers cannot modify the object or its child objects.
		/// </para>
		/// <para>To view the list of policy readers in account name format, use the <c>PolicyReadersName</c> property.</para>
		/// <para>You must call the <c>Submit</c> method to persist any changes made by this method.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazauthorizationstore-addpolicyreadername HRESULT
		// AddPolicyReaderName( [in] BSTR bstrReader, [in, optional] VARIANT varReserved );
		[DispId(1610743853)]
		void AddPolicyReaderName([In, MarshalAs(UnmanagedType.BStr)] string bstrReader, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>
		/// The <b>DeletePolicyReaderName</b> method removes the specified account name from the list of principals that act as policy readers.
		/// </summary>
		/// <param name="bstrReader">
		/// The account name to remove from the list of policy readers. The account name must be in user principal name (UPN) format (for
		/// example, "someone@example.com"). The <c>LookupAccountName</c> function is called to retrieve the domain.
		/// </param>
		/// <param name="varReserved">Reserved for future use.</param>
		/// <remarks>
		/// <para>
		/// Policy readers for an object can read attributes for the object and for child objects of the object. Readers can also use the
		/// policy; for example, readers can call the <c>AccessCheck</c> method. Readers cannot modify the object or its child objects.
		/// </para>
		/// <para>To view the list of policy readers in account name format, use the <c>PolicyReadersName</c> property.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazauthorizationstore-deletepolicyreadername HRESULT
		// DeletePolicyReaderName( [in] BSTR bstrReader, [in, optional] VARIANT varReserved );
		[DispId(1610743854)]
		void DeletePolicyReaderName([In, MarshalAs(UnmanagedType.BStr)] string bstrReader, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>
		/// <para>The <b>DelegatedPolicyUsersName</b> property retrieves the account names of principals that act as delegated policy users.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// Delegated policy users are principals that are allowed to read the subset of the policy data that the policy administrator of an
		/// <c>IAzApplication</c> or <c>IAzScope</c> object uses to administer the delegated object.
		/// </para>
		/// <para><b>Note</b>  Delegated policy users are not supported for XML stores.</para>
		/// <para></para>
		/// <para>In JScript, the returned <c>SAFEARRAY</c> must be converted to the JScript <c>Array</c> object.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazauthorizationstore-get_delegatedpolicyusersname HRESULT
		// get_DelegatedPolicyUsersName( VARIANT *pvarDelegatedPolicyUsers );
		[DispId(1610743855)]
		object DelegatedPolicyUsersName
		{
			[DispId(1610743855)]
			[return: MarshalAs(UnmanagedType.Struct)]
			get;
		}

		/// <summary>
		/// <para>
		/// The <b>AddDelegatedPolicyUserName</b> method adds the specified account name to the list of principals that act as delegated
		/// policy users.
		/// </para>
		/// <para>This method is an alternate version of the <c>AddDelegatedPolicyUser</c> method.</para>
		/// </summary>
		/// <param name="bstrDelegatedPolicyUser">
		/// Account name to add to the list of delegated policy users. The account name must be in <c>user principal name</c> (UPN) format
		/// (for example, "someone@example.com"). The <c>LookupAccountName</c> function is called to retrieve the domain.
		/// </param>
		/// <param name="varReserved">Reserved for future use.</param>
		/// <remarks>
		/// <para>
		/// Delegated policy users are principals that are allowed to read the subset of the policy data that the policy administrator of an
		/// <c>IAzApplication</c> or <c>IAzScope</c> object uses to administer the delegated object.
		/// </para>
		/// <para><b>Note</b>  Delegated policy users are not supported for XML stores.</para>
		/// <para></para>
		/// <para>To view the list of delegated policy users in account name format, use the <c>DelegatedPolicyUsersName</c> property.</para>
		/// <para>You must call the <c>Submit</c> method to persist any changes made by this method.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazauthorizationstore-adddelegatedpolicyusername HRESULT
		// AddDelegatedPolicyUserName( [in] BSTR bstrDelegatedPolicyUser, [in, optional] VARIANT varReserved );
		[DispId(1610743856)]
		void AddDelegatedPolicyUserName([In, MarshalAs(UnmanagedType.BStr)] string bstrDelegatedPolicyUser, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>
		/// The <b>DeleteDelegatedPolicyUserName</b> method removes the specified account name from the list of principals that act as
		/// delegated policy users.
		/// </summary>
		/// <param name="bstrDelegatedPolicyUser">
		/// Account name to remove from the list of delegated policy users. The account name must be in <c>user principal name</c> (UPN)
		/// format (for example, "someone@example.com"). The <c>LookupAccountName</c> function is called to retrieve the domain.
		/// </param>
		/// <param name="varReserved">Reserved for future use.</param>
		/// <remarks>
		/// <para>
		/// Delegated policy users are principals that are allowed to read the subset of the policy data that the policy administrator of an
		/// <c>IAzApplication</c> or <c>IAzScope</c> object uses to administer the delegated object.
		/// </para>
		/// <para><b>Note</b>  Delegated policy users are not supported for XML stores.</para>
		/// <para></para>
		/// <para>To view the list of delegated policy users in account name format, use the <c>DelegatedPolicyUsersName</c> property.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazauthorizationstore-deletedelegatedpolicyusername HRESULT
		// DeleteDelegatedPolicyUserName( [in] BSTR bstrDelegatedPolicyUser, [in, optional] VARIANT varReserved );
		[DispId(1610743857)]
		void DeleteDelegatedPolicyUserName([In, MarshalAs(UnmanagedType.BStr)] string bstrDelegatedPolicyUser, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>
		/// <para>The <b>CloseApplication</b> method unloads a specified <c>IAzApplication</c> object from the cache.</para>
		/// <para>This method is not supported for XML authorization policy stores.</para>
		/// </summary>
		/// <param name="bstrApplicationName">The name of the <c>IAzApplication</c> object to close.</param>
		/// <param name="lFlag">
		/// <para>Flags that control the behavior of the operation. The following table shows the possible values.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Value</description>
		/// <description>Meaning</description>
		/// </listheader>
		/// <item>
		/// <description><b>0</b></description>
		/// <description>
		/// Child objects of the specified <c>IAzApplication</c> object will be unloaded from the cache only when the user closes the last
		/// handle to the <b>IAzApplication</b> object.
		/// </description>
		/// </item>
		/// <item>
		/// <description><b>AZ_AZSTORE_FORCE_APPLICATION_CLOSE</b></description>
		/// <description>
		/// All child objects of the specified <c>IAzApplication</c> object will be forcefully closed. Attempts to reference an open handle
		/// to a child object of the specified <b>IAzApplication</b> object will result in an <b>HRESULT_FROM_WIN32(ERROR_INVALID_HANDLE)</b>
		/// error. This flag should be used only if the user has implemented code to gracefully handle the error.
		/// </description>
		/// </item>
		/// </list>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazauthorizationstore-closeapplication HRESULT
		// CloseApplication( [in] BSTR bstrApplicationName, [in] LONG lFlag );
		[DispId(1610743858)]
		void CloseApplication([In, MarshalAs(UnmanagedType.BStr)] string bstrApplicationName, [In] AZ_PROP_CONSTANTS lFlag);
	}

	/// <summary>Inherits from the AzAuthorizationStore object and implements methods to create and open IAzApplication2 objects.</summary>
	// https://learn.microsoft.com/windows/win32/api/azroles/nn-azroles-iazauthorizationstore2
	[PInvokeData("azroles.h", MSDNShortId = "NN:azroles.IAzAuthorizationStore2")]
	[ComImport, Guid("B11E5584-D577-4273-B6C5-0973E0F8E80D"), CoClass(typeof(AzAuthorizationStore))]
	public interface IAzAuthorizationStore2 : IAzAuthorizationStore
	{
		/// <summary>
		/// <para>The <b>Description</b> property sets or retrieves a comment that describes the operation.</para>
		/// <para>This property is read/write.</para>
		/// </summary>
		/// <remarks>The maximum length of the <b>Description</b> property is 1,024 characters.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazauthorizationstore-get_description HRESULT
		// get_Description( BSTR *pbstrDescription );
		[DispId(1610743808)]
		new string Description
		{
			[DispId(1610743808)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
			[DispId(1610743808)]
			[param: In]
			[param: MarshalAs(UnmanagedType.BStr)]
			set;
		}

		/// <summary>
		/// <para>The <b>ApplicationData</b> property sets or retrieves an opaque field that can be used by the application to store information.</para>
		/// <para>This property is read/write.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// <b>Important</b>  Policy administrators can read from and write to this property. Applications should not store data in the
		/// <b>ApplicationData</b> property that should not be available to the policy administrator.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazauthorizationstore-put_applicationdata HRESULT
		// put_ApplicationData( BSTR bstrApplicationData );
		[DispId(1610743810)]
		new string ApplicationData
		{
			[DispId(1610743810)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
			[DispId(1610743810)]
			[param: In]
			[param: MarshalAs(UnmanagedType.BStr)]
			set;
		}

		/// <summary>
		/// <para>The <b>DomainTimeout</b> property sets or retrieves the time in milliseconds after which a domain is determined to be unreachable.</para>
		/// <para>This property is read/write.</para>
		/// </summary>
		/// <remarks>After the specified time-out interval, LDAP query group membership will attempt to contact a domain controller again.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazauthorizationstore-put_domaintimeout HRESULT
		// put_DomainTimeout( LONG lProp );
		[DispId(1610743812)]
		new int DomainTimeout
		{
			[DispId(1610743812)]
			get;
			[DispId(1610743812)]
			[param: In]
			set;
		}

		/// <summary>
		/// <para>
		/// The <b>ScriptEngineTimeout</b> property sets or retrieves the time in milliseconds that the <c>IAzClientContext::AccessCheck</c>
		/// method will wait for a Business Rule (BizRule) to complete execution before canceling it.
		/// </para>
		/// <para>This property is read/write.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazauthorizationstore-put_scriptenginetimeout HRESULT
		// put_ScriptEngineTimeout( LONG lProp );
		[DispId(1610743814)]
		new int ScriptEngineTimeout
		{
			[DispId(1610743814)]
			get;
			[DispId(1610743814)]
			[param: In]
			set;
		}

		/// <summary>
		/// <para>
		/// The <b>MaxScriptEngines</b> property sets or retrieves the maximum number of Business Rule (BizRule) script engines that will be cached.
		/// </para>
		/// <para>This property is read/write.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazauthorizationstore-put_maxscriptengines HRESULT
		// put_MaxScriptEngines( LONG lProp );
		[DispId(1610743816)]
		new int MaxScriptEngines
		{
			[DispId(1610743816)]
			get;
			[DispId(1610743816)]
			[param: In]
			set;
		}

		/// <summary>
		/// <para>The <b>GenerateAudits</b> property sets or retrieves a value that indicates whether run-time audits should be generated.</para>
		/// <para>This property is read/write.</para>
		/// </summary>
		/// <remarks>
		/// The <b>GenerateAudits</b> property controls application initialization, client context creation, client context deletion, and
		/// access check run-time auditing. The client context can be created by <c>security identifier</c> (SID), name, or token.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazauthorizationstore-put_generateaudits HRESULT
		// put_GenerateAudits( BOOL bProp );
		[DispId(1610743818)]
		new bool GenerateAudits
		{
			[DispId(1610743818)]
			[return: MarshalAs(UnmanagedType.Bool)]
			get;
			[DispId(1610743818)]
			[param: In]
			[param: MarshalAs(UnmanagedType.Bool)]
			set;
		}

		/// <summary>
		/// <para>
		/// The <b>Writable</b> property retrieves a value that indicates whether the object can be modified by the user context that called
		/// the <c>Initialize</c> method.
		/// </para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazauthorizationstore-get_writable HRESULT get_Writable(
		// BOOL *pfProp );
		[DispId(1610743820)]
		new bool Writable
		{
			[DispId(1610743820)]
			[return: MarshalAs(UnmanagedType.Bool)]
			get;
		}

		/// <summary>The GetProperty method returns the IAzApplicationGroup object property with the specified property ID.</summary>
		/// <param name="lPropId">
		/// <para>Property ID of the <c>IAzApplicationGroup</c> object property to return. The following table shows the possible values.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Value</description>
		/// <description>Meaning</description>
		/// </listheader>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_DESCRIPTION</b></description>
		/// <description>Also accessed through the <c>Description</c> property</description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_GROUP_TYPE</b></description>
		/// <description>Also accessed through the <c>Type</c> property</description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_GROUP_LDAP_QUERY</b></description>
		/// <description>Also accessed through the <c>LdapQuery</c> property</description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_NAME</b></description>
		/// <description>Also accessed through the <c>Name</c> property</description>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="varReserved">Reserved for future use.</param>
		/// <returns>A pointer to the returned IAzApplicationGroup object property.</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazapplicationgroup-getproperty
		[DispId(1610743821)]
		[return: MarshalAs(UnmanagedType.Struct)]
		new object GetProperty([In] AZ_PROP_CONSTANTS lPropId, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>
		/// The <b>SetProperty</b> method sets the specified value to the <c>AzAuthorizationStore</c> object property with the specified
		/// property ID.
		/// </summary>
		/// <param name="lPropId">
		/// <para>Property ID of the <c>AzAuthorizationStore</c> object property to set. The following table shows the possible values.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Value</description>
		/// <description>Meaning</description>
		/// </listheader>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_AZSTORE_DOMAIN_TIMEOUT</b></description>
		/// <description>Also accessed through the <c>DomainTimeout</c> property</description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_AZSTORE_MAX_SCRIPT_ENGINES</b></description>
		/// <description>Also accessed through the <c>MaxScriptEngines</c> property</description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_AZSTORE_SCRIPT_ENGINE_TIMEOUT</b></description>
		/// <description>Also accessed through the <c>ScriptEngineTimeout</c> property</description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_APPLICATION_DATA</b></description>
		/// <description>Also accessed through the <c>ApplicationData</c> property</description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_APPLY_STORE_SACL</b></description>
		/// <description>Also accessed through the <c>ApplyStoreSacl</c> property</description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_DESCRIPTION</b></description>
		/// <description>Also accessed through the <c>Description</c> property</description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_GENERATE_AUDITS</b></description>
		/// <description>Also accessed through the <c>GenerateAudits</c> property</description>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="varProp">
		/// <para>
		/// Value to set to the <c>AzAuthorizationStore</c> object property specified by the <i>lPropId</i> parameter. The following table
		/// shows the type of data that must be used depending on the value of the <i>lPropId</i> parameter.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <description><i>lPropId</i> value</description>
		/// <description>Data type</description>
		/// </listheader>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_AZSTORE_DOMAIN_TIMEOUT</b></description>
		/// <description><b>LONG</b></description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_AZSTORE_MAX_SCRIPT_ENGINES</b></description>
		/// <description><b>LONG</b></description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_AZSTORE_SCRIPT_ENGINE_TIMEOUT</b></description>
		/// <description><b>LONG</b></description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_APPLICATION_DATA</b></description>
		/// <description><b>BSTR</b></description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_APPLY_STORE_SACL</b></description>
		/// <description><b>BOOL</b></description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_DESCRIPTION</b></description>
		/// <description><b>BSTR</b></description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_GENERATE_AUDITS</b></description>
		/// <description><b>BOOL</b></description>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="varReserved">Reserved for future use.</param>
		/// <remarks>You must call the <c>Submit</c> method to persist any changes made by this method.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazauthorizationstore-setproperty HRESULT SetProperty( [in]
		// LONG lPropId, [in] VARIANT varProp, [in, optional] VARIANT varReserved );
		[DispId(1610743822)]
		new void SetProperty([In] AZ_PROP_CONSTANTS lPropId, [In, MarshalAs(UnmanagedType.Struct)] object varProp, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>The <b>AddPropertyItem</b> method adds the specified principal to the specified list of principals.</summary>
		/// <param name="lPropId">
		/// <para>
		/// Property ID of the list of principals to which to add the principal specified by the <i>varProp</i> parameter. This parameter can
		/// be one of the following values.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <description>Value</description>
		/// <description>Meaning</description>
		/// </listheader>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_POLICY_ADMINS</b></description>
		/// <description>Can also be added by using the <c>AddPolicyAdministrator</c> method.</description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_POLICY_ADMINS_NAME</b></description>
		/// <description>Can also be added by using the <c>AddPolicyAdministratorName</c> method.</description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_POLICY_READERS</b></description>
		/// <description>Can also be added by using the <c>AddPolicyReader</c> method.</description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_POLICY_READERS_NAME</b></description>
		/// <description>Can also be added by using the <c>AddPolicyReaderName</c> method.</description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_DELEGATED_POLICY_USERS</b></description>
		/// <description>Can also be added by using the <c>AddDelegatedPolicyUser</c> method.</description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_DELEGATED_POLICY_USERS_NAME</b></description>
		/// <description>Can also be added by using the <c>AddDelegatedPolicyUserName</c> method.</description>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="varProp">
		/// <para>Principal to add to the list of principals specified by the <i>lPropId</i> parameter.</para>
		/// <para>The variant must be a <b>BSTR</b> variant.</para>
		/// <para>
		/// If AZ_PROP_POLICY_ADMINS_NAME, AZ_PROP_POLICY_READERS_NAME, or AZ_PROP_DELEGATED_POLICY_USERS_NAME is specified for the
		/// <i>lPropId</i> parameter, the string is the account name of the account to add to the list. The account name must be in <c>user
		/// principal name</c> (UPN) format (for example, "someone@example.com").
		/// </para>
		/// </param>
		/// <param name="varReserved">Reserved for future use.</param>
		/// <remarks>You must call the <c>Submit</c> method to persist any changes made by this method.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazauthorizationstore-addpropertyitem HRESULT
		// AddPropertyItem( [in] LONG lPropId, [in] VARIANT varProp, [in, optional] VARIANT varReserved );
		[DispId(1610743823)]
		new void AddPropertyItem([In] AZ_PROP_CONSTANTS lPropId, [In, MarshalAs(UnmanagedType.Struct)] object varProp, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>The <b>DeletePropertyItem</b> method removes the specified principal from the specified list of principals.</summary>
		/// <param name="lPropId">
		/// <para>
		/// Property ID of the list of principals from which to remove the principal specified by the <i>varProp</i> parameter. The following
		/// table shows the possible values.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <description>Value</description>
		/// <description>Meaning</description>
		/// </listheader>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_POLICY_ADMINS</b></description>
		/// <description>Can also be removed using the <c>DeletePolicyAdministrator</c> method</description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_POLICY_ADMINS_NAME</b></description>
		/// <description>Can also be removed using the <c>DeletePolicyAdministratorName</c> method</description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_POLICY_READERS</b></description>
		/// <description>Can also be removed using the <c>DeletePolicyReader</c> method</description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_POLICY_READERS_NAME</b></description>
		/// <description>Can also be removed using the <c>DeletePolicyReaderName</c> method</description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_DELEGATED_POLICY_USERS</b></description>
		/// <description>Can also be removed using the <c>DeleteDelegatedPolicyUser</c> method</description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_DELEGATED_POLICY_USERS_NAME</b></description>
		/// <description>Can also be removed using the <c>DeleteDelegatedPolicyUserName</c> method</description>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="varProp">
		/// <para>The principal to remove from the list of principals specified by the <i>lPropId</i> parameter.</para>
		/// <para>The variant must be a <b>BSTR</b> variant.</para>
		/// <para>
		/// If AZ_PROP_POLICY_ADMINS_NAME, AZ_PROP_POLICY_READERS_NAME, or AZ_PROP_DELEGATED_POLICY_USERS_NAME is specified for the
		/// <i>lPropId</i> parameter, the string is the account name of the account to remove from the list. The account name must be in user
		/// principal name (UPN) format (for example, "someone@example.com").
		/// </para>
		/// </param>
		/// <param name="varReserved">Reserved for future use.</param>
		/// <remarks>You must call the <c>Submit</c> method to persist any changes made by this method.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazauthorizationstore-deletepropertyitem HRESULT
		// DeletePropertyItem( [in] LONG lPropId, [in] VARIANT varProp, [in, optional] VARIANT varReserved );
		[DispId(1610743824)]
		new void DeletePropertyItem([In] AZ_PROP_CONSTANTS lPropId, [In, MarshalAs(UnmanagedType.Struct)] object varProp, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>
		/// <para>
		/// The <b>PolicyAdministrators</b> property retrieves the <c>security identifiers</c> (SIDs) of principals that act as policy
		/// administrators in text form.
		/// </para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <remarks>
		/// <para>Policy administrators for an object can perform the following tasks:</para>
		/// <list type="bullet">
		/// <item>
		/// <description>Read the object</description>
		/// </item>
		/// <item>
		/// <description>Write attributes to the object</description>
		/// </item>
		/// <item>
		/// <description>Read attributes of child objects of the object</description>
		/// </item>
		/// <item>
		/// <description>Write attributes to child objects of the object</description>
		/// </item>
		/// <item>
		/// <description>Delete the object</description>
		/// </item>
		/// <item>
		/// <description>Delete child objects of the object</description>
		/// </item>
		/// <item>
		/// <description>Create child objects of the object</description>
		/// </item>
		/// </list>
		/// <para>In JScript, the returned <c>SAFEARRAY</c> must be converted to the JScript <c>Array</c> object.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazauthorizationstore-get_policyadministrators HRESULT
		// get_PolicyAdministrators( VARIANT *pvarAdmins );
		[DispId(1610743825)]
		new object PolicyAdministrators
		{
			[DispId(1610743825)]
			[return: MarshalAs(UnmanagedType.Struct)]
			get;
		}

		/// <summary>
		/// <para>
		/// The <b>PolicyReaders</b> property retrieves the <c>security identifiers</c> (SIDs) of principals that act as policy readers in
		/// text form.
		/// </para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// Policy readers for an object can read attributes for the object and for child objects of the object. Readers can also use the
		/// policy; for example, readers can call the <c>AccessCheck</c> method. Readers cannot modify the object or its child objects.
		/// </para>
		/// <para>In JScript, the returned <c>SAFEARRAY</c> must be converted to the JScript <c>Array</c> object.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazauthorizationstore-get_policyreaders HRESULT
		// get_PolicyReaders( VARIANT *pvarReaders );
		[DispId(1610743826)]
		new object PolicyReaders
		{
			[DispId(1610743826)]
			[return: MarshalAs(UnmanagedType.Struct)]
			get;
		}

		/// <summary>
		/// The <b>AddPolicyAdministrator</b> method adds the specified <c>security identifier</c> (SID) in text form to the list of
		/// principals that act as policy administrators.
		/// </summary>
		/// <param name="bstrAdmin">Text form of the SID to add to the list of policy administrators.</param>
		/// <param name="varReserved">Reserved for future use.</param>
		/// <remarks>
		/// <para>Policy administrators for an object can perform the following tasks:</para>
		/// <list type="bullet">
		/// <item>
		/// <description>Read the object</description>
		/// </item>
		/// <item>
		/// <description>Write attributes to the object</description>
		/// </item>
		/// <item>
		/// <description>Read attributes of child objects of the object</description>
		/// </item>
		/// <item>
		/// <description>Write attributes to child objects of the object</description>
		/// </item>
		/// <item>
		/// <description>Delete the object</description>
		/// </item>
		/// <item>
		/// <description>Delete child objects of the object</description>
		/// </item>
		/// <item>
		/// <description>Create child objects of the object</description>
		/// </item>
		/// </list>
		/// <para>To view the list of policy administrators, use the <c>PolicyAdministrators</c> property.</para>
		/// <para>You must call the <c>Submit</c> method to persist any changes made by this method.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazauthorizationstore-addpolicyadministrator HRESULT
		// AddPolicyAdministrator( [in] BSTR bstrAdmin, [in, optional] VARIANT varReserved );
		[DispId(1610743827)]
		new void AddPolicyAdministrator([In, MarshalAs(UnmanagedType.BStr)] string bstrAdmin, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>
		/// The <b>DeletePolicyAdministrator</b> method removes the specified <c>security identifier</c> (SID) in text form from the list of
		/// principals that act as policy administrators.
		/// </summary>
		/// <param name="bstrAdmin">Text form of the SID to remove from the list of policy administrators.</param>
		/// <param name="varReserved">Reserved for future use.</param>
		/// <remarks>
		/// <para>Policy administrators for an object can perform the following tasks:</para>
		/// <list type="bullet">
		/// <item>
		/// <description>Read the object</description>
		/// </item>
		/// <item>
		/// <description>Write attributes to the object</description>
		/// </item>
		/// <item>
		/// <description>Read attributes of child objects of the object</description>
		/// </item>
		/// <item>
		/// <description>Write attributes to child objects of the object</description>
		/// </item>
		/// <item>
		/// <description>Delete the object</description>
		/// </item>
		/// <item>
		/// <description>Delete child objects of the object</description>
		/// </item>
		/// <item>
		/// <description>Create child objects of the object</description>
		/// </item>
		/// </list>
		/// <para>To view the list of policy administrators, use the <c>PolicyAdministrators</c> property.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazauthorizationstore-deletepolicyadministrator HRESULT
		// DeletePolicyAdministrator( [in] BSTR bstrAdmin, [in, optional] VARIANT varReserved );
		[DispId(1610743828)]
		new void DeletePolicyAdministrator([In, MarshalAs(UnmanagedType.BStr)] string bstrAdmin, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>
		/// The <b>AddPolicyReader</b> method adds the specified <c>security identifier</c> (SID) in text form to the list of principals that
		/// act as policy readers.
		/// </summary>
		/// <param name="bstrReader">Text form of the SID to add to the list of policy readers.</param>
		/// <param name="varReserved">Reserved for future use.</param>
		/// <remarks>
		/// <para>
		/// Policy readers for an object can read attributes for the object and for child objects of the object. Readers can also use the
		/// policy; for example, readers can call the <c>AccessCheck</c> method. Readers cannot modify the object or its child objects.
		/// </para>
		/// <para>To view the list of policy readers, use the <c>PolicyReaders</c> property.</para>
		/// <para>You must call the <c>Submit</c> method to persist any changes made by this method.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazauthorizationstore-addpolicyreader HRESULT
		// AddPolicyReader( [in] BSTR bstrReader, [in, optional] VARIANT varReserved );
		[DispId(1610743829)]
		new void AddPolicyReader([In, MarshalAs(UnmanagedType.BStr)] string bstrReader, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>
		/// The <b>DeletePolicyReader</b> method removes the specified <c>security identifier</c> (SID) in text form from the list of
		/// principals that act as policy readers.
		/// </summary>
		/// <param name="bstrReader">Text form of the SID to remove from the list of policy readers.</param>
		/// <param name="varReserved">Reserved for future use.</param>
		/// <remarks>
		/// <para>
		/// Policy readers for an object can read attributes for the object and for child objects of the object. Readers can also use the
		/// policy; for example, readers can call the <c>AccessCheck</c> method. Readers cannot modify the object or its child objects.
		/// </para>
		/// <para>To view the list of policy readers, use the <c>PolicyReaders</c> property.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazauthorizationstore-deletepolicyreader HRESULT
		// DeletePolicyReader( [in] BSTR bstrReader, [in, optional] VARIANT varReserved );
		[DispId(1610743830)]
		new void DeletePolicyReader([In, MarshalAs(UnmanagedType.BStr)] string bstrReader, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>The Initialize method initializes the authorization manager.</summary>
		/// <param name="lFlags">Flags that control the behavior of the initialization.</param>
		/// <param name="bstrPolicyURL">Location of the persistent copy of the authorization policy database.</param>
		/// <param name="varReserved">Reserved for future use.</param>
		// https://learn.microsoft.com/windows/win32/api/roapi/nf-roapi-initialize HRESULT Initialize( RO_INIT_TYPE initType );
		[DispId(1610743831)]
		new void Initialize([In] AZ_PROP_CONSTANTS lFlags, [In, MarshalAs(UnmanagedType.BStr)] string bstrPolicyURL, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>The <b>UpdateCache</b> method updates the cache of objects and object attributes to match the underlying policy store.</summary>
		/// <param name="varReserved">Reserved for future use.</param>
		/// <remarks>
		/// <para>
		/// When the <b>UpdateCache</b> method is called, all changes to the persistent store after the last call to the <c>Initialize</c>
		/// method or to the <b>UpdateCache</b> method are incorporated into the cache. Any changes to the cache that have not been submitted
		/// using the <c>Submit</c> method override the changes to the store.
		/// </para>
		/// <para>
		/// Most stores should be stable and have few changes. Providers are expected to implement this method to efficiently determine
		/// whether changes have been written to the physical store since the last update.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazauthorizationstore-updatecache HRESULT UpdateCache( [in,
		// optional] VARIANT varReserved );
		[DispId(1610743832)]
		new void UpdateCache([Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>The <b>Delete</b> method deletes the policy store currently in use by the <c>AzAuthorizationStore</c> object.</summary>
		/// <param name="varReserved">Reserved for future use.</param>
		/// <remarks>
		/// <para>
		/// When the <b>Delete</b> method is called, the <c>AzAuthorizationStore</c> object returns to an uninitialized state. The
		/// <c>Initialize</c> method can then be called to reinitialize the object.
		/// </para>
		/// <para>
		/// <para>Important</para>
		/// <para>
		/// All objects opened by clients on the policy store (for example, <c>IAzApplication</c> objects created using
		/// <c>CreateApplication</c>) must be released before you call the <b>Delete</b> method. If the <b>Delete</b> method is called on an
		/// <c>AzAuthorizationStore</c> object whose current policy store contains child objects,
		/// <b>HRESULT_FROM_WIN32(ERROR_SERVER_HAS_OPEN_HANDLES)</b> is returned.
		/// </para>
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazauthorizationstore-delete HRESULT Delete( [in, optional]
		// VARIANT varReserved );
		[DispId(1610743833)]
		new void Delete([Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>
		/// <para>
		/// The <b>Applications</b> property retrieves an <c>IAzApplications</c> object that is used to enumerate <c>IAzApplication</c>
		/// objects from the policy store.
		/// </para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <remarks>
		/// This property can be used only to enumerate <c>IAzApplication</c> objects that are direct child objects of the
		/// <c>AzAuthorizationStore</c> object.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazauthorizationstore-get_applications HRESULT
		// get_Applications( IAzApplications **ppAppCollection );
		[DispId(1610743834)]
		new IAzApplications Applications
		{
			[DispId(1610743834)]
			[return: MarshalAs(UnmanagedType.Interface)]
			get;
		}

		/// <summary>The <b>OpenApplication</b> method opens the <c>IAzApplication</c> object with the specified name.</summary>
		/// <param name="bstrApplicationName">Name of the <c>IAzApplication</c> object to open.</param>
		/// <param name="varReserved">Reserved for future use.</param>
		/// <returns>A pointer to a pointer to the opened <c>IAzApplication</c> object.</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazauthorizationstore-openapplication HRESULT
		// OpenApplication( [in] BSTR bstrApplicationName, [in, optional] VARIANT varReserved, [out] IAzApplication **ppApplication );
		[DispId(1610743835)]
		[return: MarshalAs(UnmanagedType.Interface)]
		new IAzApplication OpenApplication([In, MarshalAs(UnmanagedType.BStr)] string bstrApplicationName, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>The <b>CreateApplication</b> method creates an <c>IAzApplication</c> object with the specified name.</summary>
		/// <param name="bstrApplicationName">Name for the new <c>IAzApplication</c> object.</param>
		/// <param name="varReserved">Reserved for future use.</param>
		/// <returns>A pointer to a pointer to the created <c>IAzApplication</c> object.</returns>
		/// <remarks>
		/// <para>You must call the <c>IAzApplication::Submit</c> method to persist any changes made by the returned object.</para>
		/// <para>The returned <c>IAzApplication</c> object is an immediate child object of the <c>AzAuthorizationStore</c> object.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazauthorizationstore-createapplication HRESULT
		// CreateApplication( [in] BSTR bstrApplicationName, [in, optional] VARIANT varReserved, [out] IAzApplication **ppApplication );
		[DispId(1610743836)]
		[return: MarshalAs(UnmanagedType.Interface)]
		new IAzApplication CreateApplication([In, MarshalAs(UnmanagedType.BStr)] string bstrApplicationName, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>
		/// The <b>DeleteApplication</b> method removes the <c>IAzApplication</c> object with the specified name from the
		/// <c>AzAuthorizationStore</c> object.
		/// </summary>
		/// <param name="bstrApplicationName">Name of the <c>IAzApplication</c> object to delete.</param>
		/// <param name="varReserved">Reserved for future use.</param>
		/// <remarks>
		/// If the deleted <c>IAzApplication</c> object has child objects, those objects are deleted, as well. If there are any
		/// <b>IAzApplication</b> references to an <b>IAzApplication</b> object that has been deleted from the cache, the
		/// <b>IAzApplication</b> object can no longer be used. In C++, you must release references to deleted <b>IAzApplication</b> objects
		/// by calling the <c>IUnknown::Release</c> method. In C# and Visual Basic, references to deleted objects are automatically released.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazauthorizationstore-deleteapplication HRESULT
		// DeleteApplication( [in] BSTR bstrApplicationName, [in, optional] VARIANT varReserved );
		[DispId(1610743837)]
		new void DeleteApplication([In, MarshalAs(UnmanagedType.BStr)] string bstrApplicationName, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>
		/// <para>
		/// The <b>ApplicationGroups</b> property retrieves an <c>IAzApplicationGroups</c> object that is used to enumerate
		/// <c>IAzApplicationGroup</c> objects from the policy data.
		/// </para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <remarks>
		/// This property can be used only to enumerate <c>IAzApplicationGroup</c> objects that are direct child objects of the
		/// <c>AzAuthorizationStore</c> object.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazauthorizationstore-get_applicationgroups HRESULT
		// get_ApplicationGroups( IAzApplicationGroups **ppGroupCollection );
		[DispId(1610743838)]
		new IAzApplicationGroups ApplicationGroups
		{
			[DispId(1610743838)]
			[return: MarshalAs(UnmanagedType.Interface)]
			get;
		}

		/// <summary>The <b>CreateApplicationGroup</b> method creates an <c>IAzApplicationGroup</c> object with the specified name.</summary>
		/// <param name="bstrGroupName">Name for the new <c>IAzApplicationGroup</c> object.</param>
		/// <param name="varReserved">Reserved for future use.</param>
		/// <returns>A pointer to a pointer to the created <c>IAzApplicationGroup</c> object.</returns>
		/// <remarks>
		/// <para>You must call the <c>IAzApplicationGroup::Submit</c> method to persist any changes made to the returned object.</para>
		/// <para>The returned <c>IAzApplicationGroup</c> object is an immediate child object of the <c>AzAuthorizationStore</c> object.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazauthorizationstore-createapplicationgroup HRESULT
		// CreateApplicationGroup( [in] BSTR bstrGroupName, [in, optional] VARIANT varReserved, [out] IAzApplicationGroup **ppGroup );
		[DispId(1610743839)]
		[return: MarshalAs(UnmanagedType.Interface)]
		new IAzApplicationGroup CreateApplicationGroup([In, MarshalAs(UnmanagedType.BStr)] string bstrGroupName, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>The <b>OpenApplicationGroup</b> method opens an <c>IAzApplicationGroup</c> object with the specified name.</summary>
		/// <param name="bstrGroupName">Name of the <c>IAzApplicationGroup</c> object to open.</param>
		/// <param name="varReserved">Reserved for future use.</param>
		/// <returns>A pointer to a pointer to the opened <c>IAzApplicationGroup</c> object.</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazauthorizationstore-openapplicationgroup HRESULT
		// OpenApplicationGroup( [in] BSTR bstrGroupName, [in, optional] VARIANT varReserved, [out] IAzApplicationGroup **ppGroup );
		[DispId(1610743840)]
		[return: MarshalAs(UnmanagedType.Interface)]
		new IAzApplicationGroup OpenApplicationGroup([In, MarshalAs(UnmanagedType.BStr)] string bstrGroupName, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>
		/// The <b>DeleteApplicationGroup</b> method removes the <c>IAzApplicationGroup</c> object with the specified name from the
		/// <c>AzAuthorizationStore</c> object.
		/// </summary>
		/// <param name="bstrGroupName">Name of the <c>IAzApplicationGroup</c> object to delete.</param>
		/// <param name="varReserved">Reserved for future use.</param>
		/// <remarks>
		/// If there are any <c>IAzApplicationGroup</c> references to an <b>IAzApplicationGroup</b> object that has been deleted from the
		/// cache, the <b>IAzApplicationGroup</b> object can no longer be used. In C++, you must release references to deleted
		/// <b>IAzApplicationGroup</b> objects by calling the <c>IUnknown::Release</c> method. In C# and Visual Basic, references to deleted
		/// objects are automatically released.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazauthorizationstore-deleteapplicationgroup HRESULT
		// DeleteApplicationGroup( [in] BSTR bstrGroupName, [in, optional] VARIANT varReserved );
		[DispId(1610743841)]
		new void DeleteApplicationGroup([In, MarshalAs(UnmanagedType.BStr)] string bstrGroupName, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>The <b>Submit</b> method persists changes made to the <c>AzAuthorizationStore</c> object.</summary>
		/// <param name="lFlags">
		/// Flags that modify the behavior of the <b>Submit</b> method. The default value is zero. If the <b>AZ_SUBMIT_FLAG_ABORT</b> flag is
		/// specified, the changes to the object are discarded and the object is updated to match the underlying policy store.
		/// </param>
		/// <param name="varReserved">Reserved for future use.</param>
		/// <remarks>
		/// <para>
		/// Any additions or modifications to an <c>AzAuthorizationStore</c> object are not persisted until the <b>Submit</b> method is
		/// called. The <c>Delete</c> method automatically submits changes.
		/// </para>
		/// <para>
		/// The <b>Submit</b> method does not extend to child objects; child objects must be individually persisted to the policy store. A
		/// created <c>AzAuthorizationStore</c> object must be submitted before it can be referenced or become a parent object. The
		/// destructor for an object silently discards unsubmitted changes.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazauthorizationstore-submit HRESULT Submit( [in] LONG
		// lFlags, [in, optional] VARIANT varReserved );
		[DispId(1610743842)]
		new void Submit([Optional, DefaultParameterValue((AZ_PROP_CONSTANTS)0), In] AZ_PROP_CONSTANTS lFlags, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>
		/// <para>
		/// The <b>DelegatedPolicyUsers</b> property retrieves the <c>security identifiers</c> (SIDs) of principals that act as delegated
		/// policy users in text form.
		/// </para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// Delegated policy users are principals that are allowed to read the subset of the policy data that the policy administrator of an
		/// <c>IAzApplication</c> or <c>IAzScope</c> object uses to administer the delegated object.
		/// </para>
		/// <para><b>Note</b>  Delegated policy users are not supported for XML stores.</para>
		/// <para></para>
		/// <para>In JScript, the returned <c>SAFEARRAY</c> must be converted to the JScript <c>Array</c> object.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazauthorizationstore-get_delegatedpolicyusers HRESULT
		// get_DelegatedPolicyUsers( VARIANT *pvarDelegatedPolicyUsers );
		[DispId(1610743843)]
		new object DelegatedPolicyUsers
		{
			[DispId(1610743843)]
			[return: MarshalAs(UnmanagedType.Struct)]
			get;
		}

		/// <summary>
		/// The <b>AddDelegatedPolicyUser</b> method adds the specified <c>security identifier</c> (SID) in text form to the list of
		/// principals that act as delegated policy users.
		/// </summary>
		/// <param name="bstrDelegatedPolicyUser">Text form of the SID to add to the list of delegated policy users.</param>
		/// <param name="varReserved">Reserved for future use.</param>
		/// <remarks>
		/// <para>
		/// Delegated policy users are principals that are allowed to read the subset of the policy data that the policy administrator of an
		/// <c>IAzApplication</c> or <c>IAzScope</c> object uses to administer the delegated object.
		/// </para>
		/// <para>
		/// <para>Note</para>
		/// <para>Delegated policy users are not supported for XML stores.</para>
		/// </para>
		/// <para>To view the list of delegated policy users, use the <c>DelegatedPolicyUsers</c> property.</para>
		/// <para>You must call the <c>Submit</c> method to persist any changes made by this method.</para>
		/// </remarks>
		// https://learn.microsoft.com/da-dk/windows/win32/api/azroles/nf-azroles-iazauthorizationstore-adddelegatedpolicyuser HRESULT
		// AddDelegatedPolicyUser( [in] BSTR bstrDelegatedPolicyUser, [in, optional] VARIANT varReserved );
		[DispId(1610743844)]
		new void AddDelegatedPolicyUser([In, MarshalAs(UnmanagedType.BStr)] string bstrDelegatedPolicyUser, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>
		/// The <b>DeleteDelegatedPolicyUser</b> method removes the specified <c>security identifier</c> (SID) in text form from the list of
		/// principals that act as delegated policy users.
		/// </summary>
		/// <param name="bstrDelegatedPolicyUser">Text form of the SID to remove from the list of delegated policy users.</param>
		/// <param name="varReserved">Reserved for future use.</param>
		/// <remarks>
		/// <para>
		/// Delegated policy users are principals that are allowed to read the subset of the policy data that the policy administrator of an
		/// <c>IAzApplication</c> or <c>IAzScope</c> object uses to administer the delegated object.
		/// </para>
		/// <para>
		/// <para>Note</para>
		/// <para>Delegated policy users are not supported for XML stores.</para>
		/// </para>
		/// <para>To view the list of delegated policy users, use the <c>DelegatedPolicyUsers</c> property.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazauthorizationstore-deletedelegatedpolicyuser?view=vs-2017
		// HRESULT DeleteDelegatedPolicyUser( [in] BSTR bstrDelegatedPolicyUser, [in, optional] VARIANT varReserved );
		[DispId(1610743845)]
		new void DeleteDelegatedPolicyUser([In, MarshalAs(UnmanagedType.BStr)] string bstrDelegatedPolicyUser, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>
		/// <para>The <b>TargetMachine</b> property retrieves the name of the computer on which account resolution should occur.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <remarks>
		/// Determination of the target computer takes into consideration active directories in local and remote domains, Distributed File
		/// System (DFS) shares, mount point, local drive, remote mapped shares, and so on.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazauthorizationstore-get_targetmachine HRESULT
		// get_TargetMachine( BSTR *pbstrTargetMachine );
		[DispId(1610743846)]
		new string TargetMachine
		{
			[DispId(1610743846)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}

		/// <summary>
		/// <para>
		/// The <b>ApplyStoreSacl</b> property sets or retrieves a value that indicates whether policy audits should be generated when the
		/// authorization store is modified.
		/// </para>
		/// <para>This property is read/write.</para>
		/// </summary>
		/// <remarks>Policy audits are generated when the underlying policy store is modified. Both success and failure audits are requested.</remarks>
		// https://learn.microsoft.com/sr-latn-rs/windows/win32/api/azroles/nf-azroles-iazauthorizationstore-put_applystoresacl HRESULT
		// put_ApplyStoreSacl( BOOL bApplyStoreSacl );
		[DispId(1610743847)]
		new bool ApplyStoreSacl
		{
			[DispId(1610743847)]
			[return: MarshalAs(UnmanagedType.Bool)]
			get;
			[DispId(1610743847)]
			[param: In]
			[param: MarshalAs(UnmanagedType.Bool)]
			set;
		}

		/// <summary>
		/// <para>The <b>PolicyAdministratorsName</b> property retrieves the account names of principals that act as policy administrators.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <remarks>
		/// <para>Policy administrators for an object can perform the following tasks:</para>
		/// <list type="bullet">
		/// <item>
		/// <description>Read the object</description>
		/// </item>
		/// <item>
		/// <description>Write attributes to the object</description>
		/// </item>
		/// <item>
		/// <description>Read attributes of child objects of the object</description>
		/// </item>
		/// <item>
		/// <description>Write attributes to child objects of the object</description>
		/// </item>
		/// <item>
		/// <description>Delete the object</description>
		/// </item>
		/// <item>
		/// <description>Delete child objects of the object</description>
		/// </item>
		/// <item>
		/// <description>Create child objects of the object</description>
		/// </item>
		/// </list>
		/// <para>In JScript, the returned <c>SAFEARRAY</c> must be converted to the JScript <c>Array</c> object.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazauthorizationstore-get_policyadministratorsname HRESULT
		// get_PolicyAdministratorsName( VARIANT *pvarAdmins );
		[DispId(1610743849)]
		new object PolicyAdministratorsName
		{
			[DispId(1610743849)]
			[return: MarshalAs(UnmanagedType.Struct)]
			get;
		}

		/// <summary>
		/// <para>The <b>PolicyReadersName</b> property retrieves the account names of principals that act as policy readers.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// Policy readers for an object can read attributes for the object and for child objects of the object. Readers can also use the
		/// policy; for example, readers can call the <c>AccessCheck</c> method. Readers cannot modify the object or its child objects.
		/// </para>
		/// <para>In JScript, the returned <c>SAFEARRAY</c> must be converted to the JScript <c>Array</c> object.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazauthorizationstore-get_policyreadersname HRESULT
		// get_PolicyReadersName( VARIANT *pvarReaders );
		[DispId(1610743850)]
		new object PolicyReadersName
		{
			[DispId(1610743850)]
			[return: MarshalAs(UnmanagedType.Struct)]
			get;
		}

		/// <summary>
		/// <para>
		/// The <b>AddPolicyAdministratorName</b> method adds the specified account name to the list of principals that act as policy administrators.
		/// </para>
		/// <para>This method is an alternate version of the <c>AddPolicyAdministrator</c> method.</para>
		/// </summary>
		/// <param name="bstrAdmin">
		/// Account name to add to the list of policy administrators. The account name must be in user principal name (UPN) format (for
		/// example, "someone@example.com"). The <c>LookupAccountName</c> function is called to retrieve the domain.
		/// </param>
		/// <param name="varReserved">Reserved for future use.</param>
		/// <remarks>
		/// <para>Policy administrators for an object can perform the following tasks:</para>
		/// <list type="bullet">
		/// <item>
		/// <description>Read the object</description>
		/// </item>
		/// <item>
		/// <description>Write attributes to the object</description>
		/// </item>
		/// <item>
		/// <description>Read attributes of child objects of the object</description>
		/// </item>
		/// <item>
		/// <description>Write attributes to child objects of the object</description>
		/// </item>
		/// <item>
		/// <description>Delete the object</description>
		/// </item>
		/// <item>
		/// <description>Delete child objects of the object</description>
		/// </item>
		/// <item>
		/// <description>Create child objects of the object</description>
		/// </item>
		/// </list>
		/// <para>To view the list of policy administrators in account name format, use the <c>PolicyAdministratorsName</c> property.</para>
		/// <para>You must call the <c>Submit</c> method to persist any changes made by this method.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazauthorizationstore-addpolicyadministratorname HRESULT
		// AddPolicyAdministratorName( [in] BSTR bstrAdmin, [in, optional] VARIANT varReserved );
		[DispId(1610743851)]
		new void AddPolicyAdministratorName([In, MarshalAs(UnmanagedType.BStr)] string bstrAdmin, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>
		/// The <b>DeletePolicyAdministratorName</b> method removes the specified account name from the list of principals that act as policy administrators.
		/// </summary>
		/// <param name="bstrAdmin">
		/// The account name to remove from the list of policy administrators. The account name must be in user principal name (UPN) format
		/// (for example, "someone@example.com"). The <c>LookupAccountName</c> function is called to retrieve the domain.
		/// </param>
		/// <param name="varReserved">Reserved for future use.</param>
		/// <remarks>
		/// <para>Policy administrators for an object can perform the following tasks:</para>
		/// <list type="bullet">
		/// <item>
		/// <description>Read the object</description>
		/// </item>
		/// <item>
		/// <description>Write attributes to the object</description>
		/// </item>
		/// <item>
		/// <description>Read attributes of child objects of the object</description>
		/// </item>
		/// <item>
		/// <description>Write attributes to child objects of the object</description>
		/// </item>
		/// <item>
		/// <description>Delete the object</description>
		/// </item>
		/// <item>
		/// <description>Delete child objects of the object</description>
		/// </item>
		/// <item>
		/// <description>Create child objects of the object</description>
		/// </item>
		/// </list>
		/// <para>To view the list of policy administrators in account name format, use the <c>PolicyAdministratorsName</c> property.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazauthorizationstore-deletepolicyadministratorname HRESULT
		// DeletePolicyAdministratorName( [in] BSTR bstrAdmin, [in, optional] VARIANT varReserved );
		[DispId(1610743852)]
		new void DeletePolicyAdministratorName([In, MarshalAs(UnmanagedType.BStr)] string bstrAdmin, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>
		/// The <b>AddPolicyReaderName</b> method adds the specified account name to the list of principals that act as policy readers.
		/// </summary>
		/// <param name="bstrReader">
		/// Account name to add to the list of policy readers. The account name must be in <c>user principal name</c> (UPN) format (for
		/// example, "someone@example.com"). The <c>LookupAccountName</c> function is called to retrieve the domain.
		/// </param>
		/// <param name="varReserved">Reserved for future use.</param>
		/// <remarks>
		/// <para>
		/// Policy readers for an object can read attributes for the object and for child objects of the object. Readers can also use the
		/// policy; for example, readers can call the <c>AccessCheck</c> method. Readers cannot modify the object or its child objects.
		/// </para>
		/// <para>To view the list of policy readers in account name format, use the <c>PolicyReadersName</c> property.</para>
		/// <para>You must call the <c>Submit</c> method to persist any changes made by this method.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazauthorizationstore-addpolicyreadername HRESULT
		// AddPolicyReaderName( [in] BSTR bstrReader, [in, optional] VARIANT varReserved );
		[DispId(1610743853)]
		new void AddPolicyReaderName([In, MarshalAs(UnmanagedType.BStr)] string bstrReader, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>
		/// The <b>DeletePolicyReaderName</b> method removes the specified account name from the list of principals that act as policy readers.
		/// </summary>
		/// <param name="bstrReader">
		/// The account name to remove from the list of policy readers. The account name must be in user principal name (UPN) format (for
		/// example, "someone@example.com"). The <c>LookupAccountName</c> function is called to retrieve the domain.
		/// </param>
		/// <param name="varReserved">Reserved for future use.</param>
		/// <remarks>
		/// <para>
		/// Policy readers for an object can read attributes for the object and for child objects of the object. Readers can also use the
		/// policy; for example, readers can call the <c>AccessCheck</c> method. Readers cannot modify the object or its child objects.
		/// </para>
		/// <para>To view the list of policy readers in account name format, use the <c>PolicyReadersName</c> property.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazauthorizationstore-deletepolicyreadername HRESULT
		// DeletePolicyReaderName( [in] BSTR bstrReader, [in, optional] VARIANT varReserved );
		[DispId(1610743854)]
		new void DeletePolicyReaderName([In, MarshalAs(UnmanagedType.BStr)] string bstrReader, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>
		/// <para>The <b>DelegatedPolicyUsersName</b> property retrieves the account names of principals that act as delegated policy users.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// Delegated policy users are principals that are allowed to read the subset of the policy data that the policy administrator of an
		/// <c>IAzApplication</c> or <c>IAzScope</c> object uses to administer the delegated object.
		/// </para>
		/// <para><b>Note</b>  Delegated policy users are not supported for XML stores.</para>
		/// <para></para>
		/// <para>In JScript, the returned <c>SAFEARRAY</c> must be converted to the JScript <c>Array</c> object.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazauthorizationstore-get_delegatedpolicyusersname HRESULT
		// get_DelegatedPolicyUsersName( VARIANT *pvarDelegatedPolicyUsers );
		[DispId(1610743855)]
		new object DelegatedPolicyUsersName
		{
			[DispId(1610743855)]
			[return: MarshalAs(UnmanagedType.Struct)]
			get;
		}

		/// <summary>
		/// <para>
		/// The <b>AddDelegatedPolicyUserName</b> method adds the specified account name to the list of principals that act as delegated
		/// policy users.
		/// </para>
		/// <para>This method is an alternate version of the <c>AddDelegatedPolicyUser</c> method.</para>
		/// </summary>
		/// <param name="bstrDelegatedPolicyUser">
		/// Account name to add to the list of delegated policy users. The account name must be in <c>user principal name</c> (UPN) format
		/// (for example, "someone@example.com"). The <c>LookupAccountName</c> function is called to retrieve the domain.
		/// </param>
		/// <param name="varReserved">Reserved for future use.</param>
		/// <remarks>
		/// <para>
		/// Delegated policy users are principals that are allowed to read the subset of the policy data that the policy administrator of an
		/// <c>IAzApplication</c> or <c>IAzScope</c> object uses to administer the delegated object.
		/// </para>
		/// <para><b>Note</b>  Delegated policy users are not supported for XML stores.</para>
		/// <para></para>
		/// <para>To view the list of delegated policy users in account name format, use the <c>DelegatedPolicyUsersName</c> property.</para>
		/// <para>You must call the <c>Submit</c> method to persist any changes made by this method.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazauthorizationstore-adddelegatedpolicyusername HRESULT
		// AddDelegatedPolicyUserName( [in] BSTR bstrDelegatedPolicyUser, [in, optional] VARIANT varReserved );
		[DispId(1610743856)]
		new void AddDelegatedPolicyUserName([In, MarshalAs(UnmanagedType.BStr)] string bstrDelegatedPolicyUser, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>
		/// The <b>DeleteDelegatedPolicyUserName</b> method removes the specified account name from the list of principals that act as
		/// delegated policy users.
		/// </summary>
		/// <param name="bstrDelegatedPolicyUser">
		/// Account name to remove from the list of delegated policy users. The account name must be in <c>user principal name</c> (UPN)
		/// format (for example, "someone@example.com"). The <c>LookupAccountName</c> function is called to retrieve the domain.
		/// </param>
		/// <param name="varReserved">Reserved for future use.</param>
		/// <remarks>
		/// <para>
		/// Delegated policy users are principals that are allowed to read the subset of the policy data that the policy administrator of an
		/// <c>IAzApplication</c> or <c>IAzScope</c> object uses to administer the delegated object.
		/// </para>
		/// <para><b>Note</b>  Delegated policy users are not supported for XML stores.</para>
		/// <para></para>
		/// <para>To view the list of delegated policy users in account name format, use the <c>DelegatedPolicyUsersName</c> property.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazauthorizationstore-deletedelegatedpolicyusername HRESULT
		// DeleteDelegatedPolicyUserName( [in] BSTR bstrDelegatedPolicyUser, [in, optional] VARIANT varReserved );
		[DispId(1610743857)]
		new void DeleteDelegatedPolicyUserName([In, MarshalAs(UnmanagedType.BStr)] string bstrDelegatedPolicyUser, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>
		/// <para>The <b>CloseApplication</b> method unloads a specified <c>IAzApplication</c> object from the cache.</para>
		/// <para>This method is not supported for XML authorization policy stores.</para>
		/// </summary>
		/// <param name="bstrApplicationName">The name of the <c>IAzApplication</c> object to close.</param>
		/// <param name="lFlag">
		/// <para>Flags that control the behavior of the operation. The following table shows the possible values.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Value</description>
		/// <description>Meaning</description>
		/// </listheader>
		/// <item>
		/// <description><b>0</b></description>
		/// <description>
		/// Child objects of the specified <c>IAzApplication</c> object will be unloaded from the cache only when the user closes the last
		/// handle to the <b>IAzApplication</b> object.
		/// </description>
		/// </item>
		/// <item>
		/// <description><b>AZ_AZSTORE_FORCE_APPLICATION_CLOSE</b></description>
		/// <description>
		/// All child objects of the specified <c>IAzApplication</c> object will be forcefully closed. Attempts to reference an open handle
		/// to a child object of the specified <b>IAzApplication</b> object will result in an <b>HRESULT_FROM_WIN32(ERROR_INVALID_HANDLE)</b>
		/// error. This flag should be used only if the user has implemented code to gracefully handle the error.
		/// </description>
		/// </item>
		/// </list>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazauthorizationstore-closeapplication HRESULT
		// CloseApplication( [in] BSTR bstrApplicationName, [in] LONG lFlag );
		[DispId(1610743858)]
		new void CloseApplication([In, MarshalAs(UnmanagedType.BStr)] string bstrApplicationName, [In] AZ_PROP_CONSTANTS lFlag);

		/// <summary>The <b>OpenApplication2</b> method opens the <c>IAzApplication2</c> object with the specified name.</summary>
		/// <param name="bstrApplicationName">The name of the <c>IAzApplication2</c> object to open.</param>
		/// <param name="varReserved">Reserved for future use.</param>
		/// <returns>A pointer to a pointer to the opened <c>IAzApplication2</c> object.</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazauthorizationstore2-openapplication2 HRESULT
		// OpenApplication2( [in] BSTR bstrApplicationName, [in, optional] VARIANT varReserved, [out] IAzApplication2 **ppApplication );
		[DispId(1610809344)]
		[return: MarshalAs(UnmanagedType.Interface)]
		IAzApplication2 OpenApplication2([In, MarshalAs(UnmanagedType.BStr)] string bstrApplicationName, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>The <b>CreateApplication2</b> method creates an <c>IAzApplication2</c> object by using the specified name.</summary>
		/// <param name="bstrApplicationName">The name for the new <c>IAzApplication2</c> object.</param>
		/// <param name="varReserved">Reserved for future use.</param>
		/// <returns>A pointer to a pointer to the created <c>IAzApplication2</c> object.</returns>
		/// <remarks>
		/// <para>You must call the <c>IAzApplication::Submit</c> method to persist any changes made by the returned object.</para>
		/// <para>The returned <c>IAzApplication2</c> object is an immediate child object of the <c>IAzAuthorizationStore2</c> object.</para>
		/// </remarks>
		// https://learn.microsoft.com/ga-ie/windows/win32/api/azroles/nf-azroles-iazauthorizationstore2-createapplication2 HRESULT
		// CreateApplication2( [in] BSTR bstrApplicationName, [in, optional] VARIANT varReserved, [out] IAzApplication2 **ppApplication );
		[DispId(1610809345)]
		[return: MarshalAs(UnmanagedType.Interface)]
		IAzApplication2 CreateApplication2([In, MarshalAs(UnmanagedType.BStr)] string bstrApplicationName, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);
	}

	/// <summary>Extends the IAzAuthorizationStore2 interface with methods that manage business rule (BizRule) support and caching.</summary>
	// https://learn.microsoft.com/windows/win32/api/azroles/nn-azroles-iazauthorizationstore3
	[PInvokeData("azroles.h", MSDNShortId = "NN:azroles.IAzAuthorizationStore3")]
	[ComImport, Guid("ABC08425-0C86-4FA0-9BE3-7189956C926E"), CoClass(typeof(AzAuthorizationStore))]
	public interface IAzAuthorizationStore3 : IAzAuthorizationStore2
	{
		/// <summary>
		/// <para>The <b>Description</b> property sets or retrieves a comment that describes the operation.</para>
		/// <para>This property is read/write.</para>
		/// </summary>
		/// <remarks>The maximum length of the <b>Description</b> property is 1,024 characters.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazauthorizationstore-get_description HRESULT
		// get_Description( BSTR *pbstrDescription );
		[DispId(1610743808)]
		new string Description
		{
			[DispId(1610743808)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
			[DispId(1610743808)]
			[param: In]
			[param: MarshalAs(UnmanagedType.BStr)]
			set;
		}

		/// <summary>
		/// <para>The <b>ApplicationData</b> property sets or retrieves an opaque field that can be used by the application to store information.</para>
		/// <para>This property is read/write.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// <b>Important</b>  Policy administrators can read from and write to this property. Applications should not store data in the
		/// <b>ApplicationData</b> property that should not be available to the policy administrator.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazauthorizationstore-put_applicationdata HRESULT
		// put_ApplicationData( BSTR bstrApplicationData );
		[DispId(1610743810)]
		new string ApplicationData
		{
			[DispId(1610743810)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
			[DispId(1610743810)]
			[param: In]
			[param: MarshalAs(UnmanagedType.BStr)]
			set;
		}

		/// <summary>
		/// <para>The <b>DomainTimeout</b> property sets or retrieves the time in milliseconds after which a domain is determined to be unreachable.</para>
		/// <para>This property is read/write.</para>
		/// </summary>
		/// <remarks>After the specified time-out interval, LDAP query group membership will attempt to contact a domain controller again.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazauthorizationstore-put_domaintimeout HRESULT
		// put_DomainTimeout( LONG lProp );
		[DispId(1610743812)]
		new int DomainTimeout
		{
			[DispId(1610743812)]
			get;
			[DispId(1610743812)]
			[param: In]
			set;
		}

		/// <summary>
		/// <para>
		/// The <b>ScriptEngineTimeout</b> property sets or retrieves the time in milliseconds that the <c>IAzClientContext::AccessCheck</c>
		/// method will wait for a Business Rule (BizRule) to complete execution before canceling it.
		/// </para>
		/// <para>This property is read/write.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazauthorizationstore-put_scriptenginetimeout HRESULT
		// put_ScriptEngineTimeout( LONG lProp );
		[DispId(1610743814)]
		new int ScriptEngineTimeout
		{
			[DispId(1610743814)]
			get;
			[DispId(1610743814)]
			[param: In]
			set;
		}

		/// <summary>
		/// <para>
		/// The <b>MaxScriptEngines</b> property sets or retrieves the maximum number of Business Rule (BizRule) script engines that will be cached.
		/// </para>
		/// <para>This property is read/write.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazauthorizationstore-put_maxscriptengines HRESULT
		// put_MaxScriptEngines( LONG lProp );
		[DispId(1610743816)]
		new int MaxScriptEngines
		{
			[DispId(1610743816)]
			get;
			[DispId(1610743816)]
			[param: In]
			set;
		}

		/// <summary>
		/// <para>The <b>GenerateAudits</b> property sets or retrieves a value that indicates whether run-time audits should be generated.</para>
		/// <para>This property is read/write.</para>
		/// </summary>
		/// <remarks>
		/// The <b>GenerateAudits</b> property controls application initialization, client context creation, client context deletion, and
		/// access check run-time auditing. The client context can be created by <c>security identifier</c> (SID), name, or token.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazauthorizationstore-put_generateaudits HRESULT
		// put_GenerateAudits( BOOL bProp );
		[DispId(1610743818)]
		new bool GenerateAudits
		{
			[DispId(1610743818)]
			[return: MarshalAs(UnmanagedType.Bool)]
			get;
			[DispId(1610743818)]
			[param: In]
			[param: MarshalAs(UnmanagedType.Bool)]
			set;
		}

		/// <summary>
		/// <para>
		/// The <b>Writable</b> property retrieves a value that indicates whether the object can be modified by the user context that called
		/// the <c>Initialize</c> method.
		/// </para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazauthorizationstore-get_writable HRESULT get_Writable(
		// BOOL *pfProp );
		[DispId(1610743820)]
		new bool Writable
		{
			[DispId(1610743820)]
			[return: MarshalAs(UnmanagedType.Bool)]
			get;
		}

		/// <summary>The GetProperty method returns the IAzApplicationGroup object property with the specified property ID.</summary>
		/// <param name="lPropId">
		/// <para>Property ID of the <c>IAzApplicationGroup</c> object property to return. The following table shows the possible values.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Value</description>
		/// <description>Meaning</description>
		/// </listheader>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_DESCRIPTION</b></description>
		/// <description>Also accessed through the <c>Description</c> property</description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_GROUP_TYPE</b></description>
		/// <description>Also accessed through the <c>Type</c> property</description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_GROUP_LDAP_QUERY</b></description>
		/// <description>Also accessed through the <c>LdapQuery</c> property</description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_NAME</b></description>
		/// <description>Also accessed through the <c>Name</c> property</description>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="varReserved">Reserved for future use.</param>
		/// <returns>A pointer to the returned IAzApplicationGroup object property.</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazapplicationgroup-getproperty
		[DispId(1610743821)]
		[return: MarshalAs(UnmanagedType.Struct)]
		new object GetProperty([In] AZ_PROP_CONSTANTS lPropId, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>
		/// The <b>SetProperty</b> method sets the specified value to the <c>AzAuthorizationStore</c> object property with the specified
		/// property ID.
		/// </summary>
		/// <param name="lPropId">
		/// <para>Property ID of the <c>AzAuthorizationStore</c> object property to set. The following table shows the possible values.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Value</description>
		/// <description>Meaning</description>
		/// </listheader>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_AZSTORE_DOMAIN_TIMEOUT</b></description>
		/// <description>Also accessed through the <c>DomainTimeout</c> property</description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_AZSTORE_MAX_SCRIPT_ENGINES</b></description>
		/// <description>Also accessed through the <c>MaxScriptEngines</c> property</description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_AZSTORE_SCRIPT_ENGINE_TIMEOUT</b></description>
		/// <description>Also accessed through the <c>ScriptEngineTimeout</c> property</description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_APPLICATION_DATA</b></description>
		/// <description>Also accessed through the <c>ApplicationData</c> property</description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_APPLY_STORE_SACL</b></description>
		/// <description>Also accessed through the <c>ApplyStoreSacl</c> property</description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_DESCRIPTION</b></description>
		/// <description>Also accessed through the <c>Description</c> property</description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_GENERATE_AUDITS</b></description>
		/// <description>Also accessed through the <c>GenerateAudits</c> property</description>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="varProp">
		/// <para>
		/// Value to set to the <c>AzAuthorizationStore</c> object property specified by the <i>lPropId</i> parameter. The following table
		/// shows the type of data that must be used depending on the value of the <i>lPropId</i> parameter.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <description><i>lPropId</i> value</description>
		/// <description>Data type</description>
		/// </listheader>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_AZSTORE_DOMAIN_TIMEOUT</b></description>
		/// <description><b>LONG</b></description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_AZSTORE_MAX_SCRIPT_ENGINES</b></description>
		/// <description><b>LONG</b></description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_AZSTORE_SCRIPT_ENGINE_TIMEOUT</b></description>
		/// <description><b>LONG</b></description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_APPLICATION_DATA</b></description>
		/// <description><b>BSTR</b></description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_APPLY_STORE_SACL</b></description>
		/// <description><b>BOOL</b></description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_DESCRIPTION</b></description>
		/// <description><b>BSTR</b></description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_GENERATE_AUDITS</b></description>
		/// <description><b>BOOL</b></description>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="varReserved">Reserved for future use.</param>
		/// <remarks>You must call the <c>Submit</c> method to persist any changes made by this method.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazauthorizationstore-setproperty HRESULT SetProperty( [in]
		// LONG lPropId, [in] VARIANT varProp, [in, optional] VARIANT varReserved );
		[DispId(1610743822)]
		new void SetProperty([In] AZ_PROP_CONSTANTS lPropId, [In, MarshalAs(UnmanagedType.Struct)] object varProp, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>The <b>AddPropertyItem</b> method adds the specified principal to the specified list of principals.</summary>
		/// <param name="lPropId">
		/// <para>
		/// Property ID of the list of principals to which to add the principal specified by the <i>varProp</i> parameter. This parameter can
		/// be one of the following values.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <description>Value</description>
		/// <description>Meaning</description>
		/// </listheader>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_POLICY_ADMINS</b></description>
		/// <description>Can also be added by using the <c>AddPolicyAdministrator</c> method.</description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_POLICY_ADMINS_NAME</b></description>
		/// <description>Can also be added by using the <c>AddPolicyAdministratorName</c> method.</description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_POLICY_READERS</b></description>
		/// <description>Can also be added by using the <c>AddPolicyReader</c> method.</description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_POLICY_READERS_NAME</b></description>
		/// <description>Can also be added by using the <c>AddPolicyReaderName</c> method.</description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_DELEGATED_POLICY_USERS</b></description>
		/// <description>Can also be added by using the <c>AddDelegatedPolicyUser</c> method.</description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_DELEGATED_POLICY_USERS_NAME</b></description>
		/// <description>Can also be added by using the <c>AddDelegatedPolicyUserName</c> method.</description>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="varProp">
		/// <para>Principal to add to the list of principals specified by the <i>lPropId</i> parameter.</para>
		/// <para>The variant must be a <b>BSTR</b> variant.</para>
		/// <para>
		/// If AZ_PROP_POLICY_ADMINS_NAME, AZ_PROP_POLICY_READERS_NAME, or AZ_PROP_DELEGATED_POLICY_USERS_NAME is specified for the
		/// <i>lPropId</i> parameter, the string is the account name of the account to add to the list. The account name must be in <c>user
		/// principal name</c> (UPN) format (for example, "someone@example.com").
		/// </para>
		/// </param>
		/// <param name="varReserved">Reserved for future use.</param>
		/// <remarks>You must call the <c>Submit</c> method to persist any changes made by this method.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazauthorizationstore-addpropertyitem HRESULT
		// AddPropertyItem( [in] LONG lPropId, [in] VARIANT varProp, [in, optional] VARIANT varReserved );
		[DispId(1610743823)]
		new void AddPropertyItem([In] AZ_PROP_CONSTANTS lPropId, [In, MarshalAs(UnmanagedType.Struct)] object varProp, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>The <b>DeletePropertyItem</b> method removes the specified principal from the specified list of principals.</summary>
		/// <param name="lPropId">
		/// <para>
		/// Property ID of the list of principals from which to remove the principal specified by the <i>varProp</i> parameter. The following
		/// table shows the possible values.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <description>Value</description>
		/// <description>Meaning</description>
		/// </listheader>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_POLICY_ADMINS</b></description>
		/// <description>Can also be removed using the <c>DeletePolicyAdministrator</c> method</description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_POLICY_ADMINS_NAME</b></description>
		/// <description>Can also be removed using the <c>DeletePolicyAdministratorName</c> method</description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_POLICY_READERS</b></description>
		/// <description>Can also be removed using the <c>DeletePolicyReader</c> method</description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_POLICY_READERS_NAME</b></description>
		/// <description>Can also be removed using the <c>DeletePolicyReaderName</c> method</description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_DELEGATED_POLICY_USERS</b></description>
		/// <description>Can also be removed using the <c>DeleteDelegatedPolicyUser</c> method</description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_DELEGATED_POLICY_USERS_NAME</b></description>
		/// <description>Can also be removed using the <c>DeleteDelegatedPolicyUserName</c> method</description>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="varProp">
		/// <para>The principal to remove from the list of principals specified by the <i>lPropId</i> parameter.</para>
		/// <para>The variant must be a <b>BSTR</b> variant.</para>
		/// <para>
		/// If AZ_PROP_POLICY_ADMINS_NAME, AZ_PROP_POLICY_READERS_NAME, or AZ_PROP_DELEGATED_POLICY_USERS_NAME is specified for the
		/// <i>lPropId</i> parameter, the string is the account name of the account to remove from the list. The account name must be in user
		/// principal name (UPN) format (for example, "someone@example.com").
		/// </para>
		/// </param>
		/// <param name="varReserved">Reserved for future use.</param>
		/// <remarks>You must call the <c>Submit</c> method to persist any changes made by this method.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazauthorizationstore-deletepropertyitem HRESULT
		// DeletePropertyItem( [in] LONG lPropId, [in] VARIANT varProp, [in, optional] VARIANT varReserved );
		[DispId(1610743824)]
		new void DeletePropertyItem([In] AZ_PROP_CONSTANTS lPropId, [In, MarshalAs(UnmanagedType.Struct)] object varProp, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>
		/// <para>
		/// The <b>PolicyAdministrators</b> property retrieves the <c>security identifiers</c> (SIDs) of principals that act as policy
		/// administrators in text form.
		/// </para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <remarks>
		/// <para>Policy administrators for an object can perform the following tasks:</para>
		/// <list type="bullet">
		/// <item>
		/// <description>Read the object</description>
		/// </item>
		/// <item>
		/// <description>Write attributes to the object</description>
		/// </item>
		/// <item>
		/// <description>Read attributes of child objects of the object</description>
		/// </item>
		/// <item>
		/// <description>Write attributes to child objects of the object</description>
		/// </item>
		/// <item>
		/// <description>Delete the object</description>
		/// </item>
		/// <item>
		/// <description>Delete child objects of the object</description>
		/// </item>
		/// <item>
		/// <description>Create child objects of the object</description>
		/// </item>
		/// </list>
		/// <para>In JScript, the returned <c>SAFEARRAY</c> must be converted to the JScript <c>Array</c> object.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazauthorizationstore-get_policyadministrators HRESULT
		// get_PolicyAdministrators( VARIANT *pvarAdmins );
		[DispId(1610743825)]
		new object PolicyAdministrators
		{
			[DispId(1610743825)]
			[return: MarshalAs(UnmanagedType.Struct)]
			get;
		}

		/// <summary>
		/// <para>
		/// The <b>PolicyReaders</b> property retrieves the <c>security identifiers</c> (SIDs) of principals that act as policy readers in
		/// text form.
		/// </para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// Policy readers for an object can read attributes for the object and for child objects of the object. Readers can also use the
		/// policy; for example, readers can call the <c>AccessCheck</c> method. Readers cannot modify the object or its child objects.
		/// </para>
		/// <para>In JScript, the returned <c>SAFEARRAY</c> must be converted to the JScript <c>Array</c> object.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazauthorizationstore-get_policyreaders HRESULT
		// get_PolicyReaders( VARIANT *pvarReaders );
		[DispId(1610743826)]
		new object PolicyReaders
		{
			[DispId(1610743826)]
			[return: MarshalAs(UnmanagedType.Struct)]
			get;
		}

		/// <summary>
		/// The <b>AddPolicyAdministrator</b> method adds the specified <c>security identifier</c> (SID) in text form to the list of
		/// principals that act as policy administrators.
		/// </summary>
		/// <param name="bstrAdmin">Text form of the SID to add to the list of policy administrators.</param>
		/// <param name="varReserved">Reserved for future use.</param>
		/// <remarks>
		/// <para>Policy administrators for an object can perform the following tasks:</para>
		/// <list type="bullet">
		/// <item>
		/// <description>Read the object</description>
		/// </item>
		/// <item>
		/// <description>Write attributes to the object</description>
		/// </item>
		/// <item>
		/// <description>Read attributes of child objects of the object</description>
		/// </item>
		/// <item>
		/// <description>Write attributes to child objects of the object</description>
		/// </item>
		/// <item>
		/// <description>Delete the object</description>
		/// </item>
		/// <item>
		/// <description>Delete child objects of the object</description>
		/// </item>
		/// <item>
		/// <description>Create child objects of the object</description>
		/// </item>
		/// </list>
		/// <para>To view the list of policy administrators, use the <c>PolicyAdministrators</c> property.</para>
		/// <para>You must call the <c>Submit</c> method to persist any changes made by this method.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazauthorizationstore-addpolicyadministrator HRESULT
		// AddPolicyAdministrator( [in] BSTR bstrAdmin, [in, optional] VARIANT varReserved );
		[DispId(1610743827)]
		new void AddPolicyAdministrator([In, MarshalAs(UnmanagedType.BStr)] string bstrAdmin, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>
		/// The <b>DeletePolicyAdministrator</b> method removes the specified <c>security identifier</c> (SID) in text form from the list of
		/// principals that act as policy administrators.
		/// </summary>
		/// <param name="bstrAdmin">Text form of the SID to remove from the list of policy administrators.</param>
		/// <param name="varReserved">Reserved for future use.</param>
		/// <remarks>
		/// <para>Policy administrators for an object can perform the following tasks:</para>
		/// <list type="bullet">
		/// <item>
		/// <description>Read the object</description>
		/// </item>
		/// <item>
		/// <description>Write attributes to the object</description>
		/// </item>
		/// <item>
		/// <description>Read attributes of child objects of the object</description>
		/// </item>
		/// <item>
		/// <description>Write attributes to child objects of the object</description>
		/// </item>
		/// <item>
		/// <description>Delete the object</description>
		/// </item>
		/// <item>
		/// <description>Delete child objects of the object</description>
		/// </item>
		/// <item>
		/// <description>Create child objects of the object</description>
		/// </item>
		/// </list>
		/// <para>To view the list of policy administrators, use the <c>PolicyAdministrators</c> property.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazauthorizationstore-deletepolicyadministrator HRESULT
		// DeletePolicyAdministrator( [in] BSTR bstrAdmin, [in, optional] VARIANT varReserved );
		[DispId(1610743828)]
		new void DeletePolicyAdministrator([In, MarshalAs(UnmanagedType.BStr)] string bstrAdmin, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>
		/// The <b>AddPolicyReader</b> method adds the specified <c>security identifier</c> (SID) in text form to the list of principals that
		/// act as policy readers.
		/// </summary>
		/// <param name="bstrReader">Text form of the SID to add to the list of policy readers.</param>
		/// <param name="varReserved">Reserved for future use.</param>
		/// <remarks>
		/// <para>
		/// Policy readers for an object can read attributes for the object and for child objects of the object. Readers can also use the
		/// policy; for example, readers can call the <c>AccessCheck</c> method. Readers cannot modify the object or its child objects.
		/// </para>
		/// <para>To view the list of policy readers, use the <c>PolicyReaders</c> property.</para>
		/// <para>You must call the <c>Submit</c> method to persist any changes made by this method.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazauthorizationstore-addpolicyreader HRESULT
		// AddPolicyReader( [in] BSTR bstrReader, [in, optional] VARIANT varReserved );
		[DispId(1610743829)]
		new void AddPolicyReader([In, MarshalAs(UnmanagedType.BStr)] string bstrReader, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>
		/// The <b>DeletePolicyReader</b> method removes the specified <c>security identifier</c> (SID) in text form from the list of
		/// principals that act as policy readers.
		/// </summary>
		/// <param name="bstrReader">Text form of the SID to remove from the list of policy readers.</param>
		/// <param name="varReserved">Reserved for future use.</param>
		/// <remarks>
		/// <para>
		/// Policy readers for an object can read attributes for the object and for child objects of the object. Readers can also use the
		/// policy; for example, readers can call the <c>AccessCheck</c> method. Readers cannot modify the object or its child objects.
		/// </para>
		/// <para>To view the list of policy readers, use the <c>PolicyReaders</c> property.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazauthorizationstore-deletepolicyreader HRESULT
		// DeletePolicyReader( [in] BSTR bstrReader, [in, optional] VARIANT varReserved );
		[DispId(1610743830)]
		new void DeletePolicyReader([In, MarshalAs(UnmanagedType.BStr)] string bstrReader, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>The Initialize method initializes the authorization manager.</summary>
		/// <param name="lFlags">Flags that control the behavior of the initialization.</param>
		/// <param name="bstrPolicyURL">Location of the persistent copy of the authorization policy database.</param>
		/// <param name="varReserved">Reserved for future use.</param>
		// https://learn.microsoft.com/windows/win32/api/roapi/nf-roapi-initialize HRESULT Initialize( RO_INIT_TYPE initType );
		[DispId(1610743831)]
		new void Initialize([In] AZ_PROP_CONSTANTS lFlags, [In, MarshalAs(UnmanagedType.BStr)] string bstrPolicyURL, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>The <b>UpdateCache</b> method updates the cache of objects and object attributes to match the underlying policy store.</summary>
		/// <param name="varReserved">Reserved for future use.</param>
		/// <remarks>
		/// <para>
		/// When the <b>UpdateCache</b> method is called, all changes to the persistent store after the last call to the <c>Initialize</c>
		/// method or to the <b>UpdateCache</b> method are incorporated into the cache. Any changes to the cache that have not been submitted
		/// using the <c>Submit</c> method override the changes to the store.
		/// </para>
		/// <para>
		/// Most stores should be stable and have few changes. Providers are expected to implement this method to efficiently determine
		/// whether changes have been written to the physical store since the last update.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazauthorizationstore-updatecache HRESULT UpdateCache( [in,
		// optional] VARIANT varReserved );
		[DispId(1610743832)]
		new void UpdateCache([Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>The <b>Delete</b> method deletes the policy store currently in use by the <c>AzAuthorizationStore</c> object.</summary>
		/// <param name="varReserved">Reserved for future use.</param>
		/// <remarks>
		/// <para>
		/// When the <b>Delete</b> method is called, the <c>AzAuthorizationStore</c> object returns to an uninitialized state. The
		/// <c>Initialize</c> method can then be called to reinitialize the object.
		/// </para>
		/// <para>
		/// <para>Important</para>
		/// <para>
		/// All objects opened by clients on the policy store (for example, <c>IAzApplication</c> objects created using
		/// <c>CreateApplication</c>) must be released before you call the <b>Delete</b> method. If the <b>Delete</b> method is called on an
		/// <c>AzAuthorizationStore</c> object whose current policy store contains child objects,
		/// <b>HRESULT_FROM_WIN32(ERROR_SERVER_HAS_OPEN_HANDLES)</b> is returned.
		/// </para>
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazauthorizationstore-delete HRESULT Delete( [in, optional]
		// VARIANT varReserved );
		[DispId(1610743833)]
		new void Delete([Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>
		/// <para>
		/// The <b>Applications</b> property retrieves an <c>IAzApplications</c> object that is used to enumerate <c>IAzApplication</c>
		/// objects from the policy store.
		/// </para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <remarks>
		/// This property can be used only to enumerate <c>IAzApplication</c> objects that are direct child objects of the
		/// <c>AzAuthorizationStore</c> object.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazauthorizationstore-get_applications HRESULT
		// get_Applications( IAzApplications **ppAppCollection );
		[DispId(1610743834)]
		new IAzApplications Applications
		{
			[DispId(1610743834)]
			[return: MarshalAs(UnmanagedType.Interface)]
			get;
		}

		/// <summary>The <b>OpenApplication</b> method opens the <c>IAzApplication</c> object with the specified name.</summary>
		/// <param name="bstrApplicationName">Name of the <c>IAzApplication</c> object to open.</param>
		/// <param name="varReserved">Reserved for future use.</param>
		/// <returns>A pointer to a pointer to the opened <c>IAzApplication</c> object.</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazauthorizationstore-openapplication HRESULT
		// OpenApplication( [in] BSTR bstrApplicationName, [in, optional] VARIANT varReserved, [out] IAzApplication **ppApplication );
		[DispId(1610743835)]
		[return: MarshalAs(UnmanagedType.Interface)]
		new IAzApplication OpenApplication([In, MarshalAs(UnmanagedType.BStr)] string bstrApplicationName, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>The <b>CreateApplication</b> method creates an <c>IAzApplication</c> object with the specified name.</summary>
		/// <param name="bstrApplicationName">Name for the new <c>IAzApplication</c> object.</param>
		/// <param name="varReserved">Reserved for future use.</param>
		/// <returns>A pointer to a pointer to the created <c>IAzApplication</c> object.</returns>
		/// <remarks>
		/// <para>You must call the <c>IAzApplication::Submit</c> method to persist any changes made by the returned object.</para>
		/// <para>The returned <c>IAzApplication</c> object is an immediate child object of the <c>AzAuthorizationStore</c> object.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazauthorizationstore-createapplication HRESULT
		// CreateApplication( [in] BSTR bstrApplicationName, [in, optional] VARIANT varReserved, [out] IAzApplication **ppApplication );
		[DispId(1610743836)]
		[return: MarshalAs(UnmanagedType.Interface)]
		new IAzApplication CreateApplication([In, MarshalAs(UnmanagedType.BStr)] string bstrApplicationName, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>
		/// The <b>DeleteApplication</b> method removes the <c>IAzApplication</c> object with the specified name from the
		/// <c>AzAuthorizationStore</c> object.
		/// </summary>
		/// <param name="bstrApplicationName">Name of the <c>IAzApplication</c> object to delete.</param>
		/// <param name="varReserved">Reserved for future use.</param>
		/// <remarks>
		/// If the deleted <c>IAzApplication</c> object has child objects, those objects are deleted, as well. If there are any
		/// <b>IAzApplication</b> references to an <b>IAzApplication</b> object that has been deleted from the cache, the
		/// <b>IAzApplication</b> object can no longer be used. In C++, you must release references to deleted <b>IAzApplication</b> objects
		/// by calling the <c>IUnknown::Release</c> method. In C# and Visual Basic, references to deleted objects are automatically released.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazauthorizationstore-deleteapplication HRESULT
		// DeleteApplication( [in] BSTR bstrApplicationName, [in, optional] VARIANT varReserved );
		[DispId(1610743837)]
		new void DeleteApplication([In, MarshalAs(UnmanagedType.BStr)] string bstrApplicationName, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>
		/// <para>
		/// The <b>ApplicationGroups</b> property retrieves an <c>IAzApplicationGroups</c> object that is used to enumerate
		/// <c>IAzApplicationGroup</c> objects from the policy data.
		/// </para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <remarks>
		/// This property can be used only to enumerate <c>IAzApplicationGroup</c> objects that are direct child objects of the
		/// <c>AzAuthorizationStore</c> object.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazauthorizationstore-get_applicationgroups HRESULT
		// get_ApplicationGroups( IAzApplicationGroups **ppGroupCollection );
		[DispId(1610743838)]
		new IAzApplicationGroups ApplicationGroups
		{
			[DispId(1610743838)]
			[return: MarshalAs(UnmanagedType.Interface)]
			get;
		}

		/// <summary>The <b>CreateApplicationGroup</b> method creates an <c>IAzApplicationGroup</c> object with the specified name.</summary>
		/// <param name="bstrGroupName">Name for the new <c>IAzApplicationGroup</c> object.</param>
		/// <param name="varReserved">Reserved for future use.</param>
		/// <returns>A pointer to a pointer to the created <c>IAzApplicationGroup</c> object.</returns>
		/// <remarks>
		/// <para>You must call the <c>IAzApplicationGroup::Submit</c> method to persist any changes made to the returned object.</para>
		/// <para>The returned <c>IAzApplicationGroup</c> object is an immediate child object of the <c>AzAuthorizationStore</c> object.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazauthorizationstore-createapplicationgroup HRESULT
		// CreateApplicationGroup( [in] BSTR bstrGroupName, [in, optional] VARIANT varReserved, [out] IAzApplicationGroup **ppGroup );
		[DispId(1610743839)]
		[return: MarshalAs(UnmanagedType.Interface)]
		new IAzApplicationGroup CreateApplicationGroup([In, MarshalAs(UnmanagedType.BStr)] string bstrGroupName, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>The <b>OpenApplicationGroup</b> method opens an <c>IAzApplicationGroup</c> object with the specified name.</summary>
		/// <param name="bstrGroupName">Name of the <c>IAzApplicationGroup</c> object to open.</param>
		/// <param name="varReserved">Reserved for future use.</param>
		/// <returns>A pointer to a pointer to the opened <c>IAzApplicationGroup</c> object.</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazauthorizationstore-openapplicationgroup HRESULT
		// OpenApplicationGroup( [in] BSTR bstrGroupName, [in, optional] VARIANT varReserved, [out] IAzApplicationGroup **ppGroup );
		[DispId(1610743840)]
		[return: MarshalAs(UnmanagedType.Interface)]
		new IAzApplicationGroup OpenApplicationGroup([In, MarshalAs(UnmanagedType.BStr)] string bstrGroupName, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>
		/// The <b>DeleteApplicationGroup</b> method removes the <c>IAzApplicationGroup</c> object with the specified name from the
		/// <c>AzAuthorizationStore</c> object.
		/// </summary>
		/// <param name="bstrGroupName">Name of the <c>IAzApplicationGroup</c> object to delete.</param>
		/// <param name="varReserved">Reserved for future use.</param>
		/// <remarks>
		/// If there are any <c>IAzApplicationGroup</c> references to an <b>IAzApplicationGroup</b> object that has been deleted from the
		/// cache, the <b>IAzApplicationGroup</b> object can no longer be used. In C++, you must release references to deleted
		/// <b>IAzApplicationGroup</b> objects by calling the <c>IUnknown::Release</c> method. In C# and Visual Basic, references to deleted
		/// objects are automatically released.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazauthorizationstore-deleteapplicationgroup HRESULT
		// DeleteApplicationGroup( [in] BSTR bstrGroupName, [in, optional] VARIANT varReserved );
		[DispId(1610743841)]
		new void DeleteApplicationGroup([In, MarshalAs(UnmanagedType.BStr)] string bstrGroupName, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>The <b>Submit</b> method persists changes made to the <c>AzAuthorizationStore</c> object.</summary>
		/// <param name="lFlags">
		/// Flags that modify the behavior of the <b>Submit</b> method. The default value is zero. If the <b>AZ_SUBMIT_FLAG_ABORT</b> flag is
		/// specified, the changes to the object are discarded and the object is updated to match the underlying policy store.
		/// </param>
		/// <param name="varReserved">Reserved for future use.</param>
		/// <remarks>
		/// <para>
		/// Any additions or modifications to an <c>AzAuthorizationStore</c> object are not persisted until the <b>Submit</b> method is
		/// called. The <c>Delete</c> method automatically submits changes.
		/// </para>
		/// <para>
		/// The <b>Submit</b> method does not extend to child objects; child objects must be individually persisted to the policy store. A
		/// created <c>AzAuthorizationStore</c> object must be submitted before it can be referenced or become a parent object. The
		/// destructor for an object silently discards unsubmitted changes.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazauthorizationstore-submit HRESULT Submit( [in] LONG
		// lFlags, [in, optional] VARIANT varReserved );
		[DispId(1610743842)]
		new void Submit([Optional, DefaultParameterValue((AZ_PROP_CONSTANTS)0), In] AZ_PROP_CONSTANTS lFlags, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>
		/// <para>
		/// The <b>DelegatedPolicyUsers</b> property retrieves the <c>security identifiers</c> (SIDs) of principals that act as delegated
		/// policy users in text form.
		/// </para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// Delegated policy users are principals that are allowed to read the subset of the policy data that the policy administrator of an
		/// <c>IAzApplication</c> or <c>IAzScope</c> object uses to administer the delegated object.
		/// </para>
		/// <para><b>Note</b>  Delegated policy users are not supported for XML stores.</para>
		/// <para></para>
		/// <para>In JScript, the returned <c>SAFEARRAY</c> must be converted to the JScript <c>Array</c> object.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazauthorizationstore-get_delegatedpolicyusers HRESULT
		// get_DelegatedPolicyUsers( VARIANT *pvarDelegatedPolicyUsers );
		[DispId(1610743843)]
		new object DelegatedPolicyUsers
		{
			[DispId(1610743843)]
			[return: MarshalAs(UnmanagedType.Struct)]
			get;
		}

		/// <summary>
		/// The <b>AddDelegatedPolicyUser</b> method adds the specified <c>security identifier</c> (SID) in text form to the list of
		/// principals that act as delegated policy users.
		/// </summary>
		/// <param name="bstrDelegatedPolicyUser">Text form of the SID to add to the list of delegated policy users.</param>
		/// <param name="varReserved">Reserved for future use.</param>
		/// <remarks>
		/// <para>
		/// Delegated policy users are principals that are allowed to read the subset of the policy data that the policy administrator of an
		/// <c>IAzApplication</c> or <c>IAzScope</c> object uses to administer the delegated object.
		/// </para>
		/// <para>
		/// <para>Note</para>
		/// <para>Delegated policy users are not supported for XML stores.</para>
		/// </para>
		/// <para>To view the list of delegated policy users, use the <c>DelegatedPolicyUsers</c> property.</para>
		/// <para>You must call the <c>Submit</c> method to persist any changes made by this method.</para>
		/// </remarks>
		// https://learn.microsoft.com/da-dk/windows/win32/api/azroles/nf-azroles-iazauthorizationstore-adddelegatedpolicyuser HRESULT
		// AddDelegatedPolicyUser( [in] BSTR bstrDelegatedPolicyUser, [in, optional] VARIANT varReserved );
		[DispId(1610743844)]
		new void AddDelegatedPolicyUser([In, MarshalAs(UnmanagedType.BStr)] string bstrDelegatedPolicyUser, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>
		/// The <b>DeleteDelegatedPolicyUser</b> method removes the specified <c>security identifier</c> (SID) in text form from the list of
		/// principals that act as delegated policy users.
		/// </summary>
		/// <param name="bstrDelegatedPolicyUser">Text form of the SID to remove from the list of delegated policy users.</param>
		/// <param name="varReserved">Reserved for future use.</param>
		/// <remarks>
		/// <para>
		/// Delegated policy users are principals that are allowed to read the subset of the policy data that the policy administrator of an
		/// <c>IAzApplication</c> or <c>IAzScope</c> object uses to administer the delegated object.
		/// </para>
		/// <para>
		/// <para>Note</para>
		/// <para>Delegated policy users are not supported for XML stores.</para>
		/// </para>
		/// <para>To view the list of delegated policy users, use the <c>DelegatedPolicyUsers</c> property.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazauthorizationstore-deletedelegatedpolicyuser?view=vs-2017
		// HRESULT DeleteDelegatedPolicyUser( [in] BSTR bstrDelegatedPolicyUser, [in, optional] VARIANT varReserved );
		[DispId(1610743845)]
		new void DeleteDelegatedPolicyUser([In, MarshalAs(UnmanagedType.BStr)] string bstrDelegatedPolicyUser, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>
		/// <para>The <b>TargetMachine</b> property retrieves the name of the computer on which account resolution should occur.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <remarks>
		/// Determination of the target computer takes into consideration active directories in local and remote domains, Distributed File
		/// System (DFS) shares, mount point, local drive, remote mapped shares, and so on.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazauthorizationstore-get_targetmachine HRESULT
		// get_TargetMachine( BSTR *pbstrTargetMachine );
		[DispId(1610743846)]
		new string TargetMachine
		{
			[DispId(1610743846)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}

		/// <summary>
		/// <para>
		/// The <b>ApplyStoreSacl</b> property sets or retrieves a value that indicates whether policy audits should be generated when the
		/// authorization store is modified.
		/// </para>
		/// <para>This property is read/write.</para>
		/// </summary>
		/// <remarks>Policy audits are generated when the underlying policy store is modified. Both success and failure audits are requested.</remarks>
		// https://learn.microsoft.com/sr-latn-rs/windows/win32/api/azroles/nf-azroles-iazauthorizationstore-put_applystoresacl HRESULT
		// put_ApplyStoreSacl( BOOL bApplyStoreSacl );
		[DispId(1610743847)]
		new bool ApplyStoreSacl
		{
			[DispId(1610743847)]
			[return: MarshalAs(UnmanagedType.Bool)]
			get;
			[DispId(1610743847)]
			[param: In]
			[param: MarshalAs(UnmanagedType.Bool)]
			set;
		}

		/// <summary>
		/// <para>The <b>PolicyAdministratorsName</b> property retrieves the account names of principals that act as policy administrators.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <remarks>
		/// <para>Policy administrators for an object can perform the following tasks:</para>
		/// <list type="bullet">
		/// <item>
		/// <description>Read the object</description>
		/// </item>
		/// <item>
		/// <description>Write attributes to the object</description>
		/// </item>
		/// <item>
		/// <description>Read attributes of child objects of the object</description>
		/// </item>
		/// <item>
		/// <description>Write attributes to child objects of the object</description>
		/// </item>
		/// <item>
		/// <description>Delete the object</description>
		/// </item>
		/// <item>
		/// <description>Delete child objects of the object</description>
		/// </item>
		/// <item>
		/// <description>Create child objects of the object</description>
		/// </item>
		/// </list>
		/// <para>In JScript, the returned <c>SAFEARRAY</c> must be converted to the JScript <c>Array</c> object.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazauthorizationstore-get_policyadministratorsname HRESULT
		// get_PolicyAdministratorsName( VARIANT *pvarAdmins );
		[DispId(1610743849)]
		new object PolicyAdministratorsName
		{
			[DispId(1610743849)]
			[return: MarshalAs(UnmanagedType.Struct)]
			get;
		}

		/// <summary>
		/// <para>The <b>PolicyReadersName</b> property retrieves the account names of principals that act as policy readers.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// Policy readers for an object can read attributes for the object and for child objects of the object. Readers can also use the
		/// policy; for example, readers can call the <c>AccessCheck</c> method. Readers cannot modify the object or its child objects.
		/// </para>
		/// <para>In JScript, the returned <c>SAFEARRAY</c> must be converted to the JScript <c>Array</c> object.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazauthorizationstore-get_policyreadersname HRESULT
		// get_PolicyReadersName( VARIANT *pvarReaders );
		[DispId(1610743850)]
		new object PolicyReadersName
		{
			[DispId(1610743850)]
			[return: MarshalAs(UnmanagedType.Struct)]
			get;
		}

		/// <summary>
		/// <para>
		/// The <b>AddPolicyAdministratorName</b> method adds the specified account name to the list of principals that act as policy administrators.
		/// </para>
		/// <para>This method is an alternate version of the <c>AddPolicyAdministrator</c> method.</para>
		/// </summary>
		/// <param name="bstrAdmin">
		/// Account name to add to the list of policy administrators. The account name must be in user principal name (UPN) format (for
		/// example, "someone@example.com"). The <c>LookupAccountName</c> function is called to retrieve the domain.
		/// </param>
		/// <param name="varReserved">Reserved for future use.</param>
		/// <remarks>
		/// <para>Policy administrators for an object can perform the following tasks:</para>
		/// <list type="bullet">
		/// <item>
		/// <description>Read the object</description>
		/// </item>
		/// <item>
		/// <description>Write attributes to the object</description>
		/// </item>
		/// <item>
		/// <description>Read attributes of child objects of the object</description>
		/// </item>
		/// <item>
		/// <description>Write attributes to child objects of the object</description>
		/// </item>
		/// <item>
		/// <description>Delete the object</description>
		/// </item>
		/// <item>
		/// <description>Delete child objects of the object</description>
		/// </item>
		/// <item>
		/// <description>Create child objects of the object</description>
		/// </item>
		/// </list>
		/// <para>To view the list of policy administrators in account name format, use the <c>PolicyAdministratorsName</c> property.</para>
		/// <para>You must call the <c>Submit</c> method to persist any changes made by this method.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazauthorizationstore-addpolicyadministratorname HRESULT
		// AddPolicyAdministratorName( [in] BSTR bstrAdmin, [in, optional] VARIANT varReserved );
		[DispId(1610743851)]
		new void AddPolicyAdministratorName([In, MarshalAs(UnmanagedType.BStr)] string bstrAdmin, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>
		/// The <b>DeletePolicyAdministratorName</b> method removes the specified account name from the list of principals that act as policy administrators.
		/// </summary>
		/// <param name="bstrAdmin">
		/// The account name to remove from the list of policy administrators. The account name must be in user principal name (UPN) format
		/// (for example, "someone@example.com"). The <c>LookupAccountName</c> function is called to retrieve the domain.
		/// </param>
		/// <param name="varReserved">Reserved for future use.</param>
		/// <remarks>
		/// <para>Policy administrators for an object can perform the following tasks:</para>
		/// <list type="bullet">
		/// <item>
		/// <description>Read the object</description>
		/// </item>
		/// <item>
		/// <description>Write attributes to the object</description>
		/// </item>
		/// <item>
		/// <description>Read attributes of child objects of the object</description>
		/// </item>
		/// <item>
		/// <description>Write attributes to child objects of the object</description>
		/// </item>
		/// <item>
		/// <description>Delete the object</description>
		/// </item>
		/// <item>
		/// <description>Delete child objects of the object</description>
		/// </item>
		/// <item>
		/// <description>Create child objects of the object</description>
		/// </item>
		/// </list>
		/// <para>To view the list of policy administrators in account name format, use the <c>PolicyAdministratorsName</c> property.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazauthorizationstore-deletepolicyadministratorname HRESULT
		// DeletePolicyAdministratorName( [in] BSTR bstrAdmin, [in, optional] VARIANT varReserved );
		[DispId(1610743852)]
		new void DeletePolicyAdministratorName([In, MarshalAs(UnmanagedType.BStr)] string bstrAdmin, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>
		/// The <b>AddPolicyReaderName</b> method adds the specified account name to the list of principals that act as policy readers.
		/// </summary>
		/// <param name="bstrReader">
		/// Account name to add to the list of policy readers. The account name must be in <c>user principal name</c> (UPN) format (for
		/// example, "someone@example.com"). The <c>LookupAccountName</c> function is called to retrieve the domain.
		/// </param>
		/// <param name="varReserved">Reserved for future use.</param>
		/// <remarks>
		/// <para>
		/// Policy readers for an object can read attributes for the object and for child objects of the object. Readers can also use the
		/// policy; for example, readers can call the <c>AccessCheck</c> method. Readers cannot modify the object or its child objects.
		/// </para>
		/// <para>To view the list of policy readers in account name format, use the <c>PolicyReadersName</c> property.</para>
		/// <para>You must call the <c>Submit</c> method to persist any changes made by this method.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazauthorizationstore-addpolicyreadername HRESULT
		// AddPolicyReaderName( [in] BSTR bstrReader, [in, optional] VARIANT varReserved );
		[DispId(1610743853)]
		new void AddPolicyReaderName([In, MarshalAs(UnmanagedType.BStr)] string bstrReader, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>
		/// The <b>DeletePolicyReaderName</b> method removes the specified account name from the list of principals that act as policy readers.
		/// </summary>
		/// <param name="bstrReader">
		/// The account name to remove from the list of policy readers. The account name must be in user principal name (UPN) format (for
		/// example, "someone@example.com"). The <c>LookupAccountName</c> function is called to retrieve the domain.
		/// </param>
		/// <param name="varReserved">Reserved for future use.</param>
		/// <remarks>
		/// <para>
		/// Policy readers for an object can read attributes for the object and for child objects of the object. Readers can also use the
		/// policy; for example, readers can call the <c>AccessCheck</c> method. Readers cannot modify the object or its child objects.
		/// </para>
		/// <para>To view the list of policy readers in account name format, use the <c>PolicyReadersName</c> property.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazauthorizationstore-deletepolicyreadername HRESULT
		// DeletePolicyReaderName( [in] BSTR bstrReader, [in, optional] VARIANT varReserved );
		[DispId(1610743854)]
		new void DeletePolicyReaderName([In, MarshalAs(UnmanagedType.BStr)] string bstrReader, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>
		/// <para>The <b>DelegatedPolicyUsersName</b> property retrieves the account names of principals that act as delegated policy users.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// Delegated policy users are principals that are allowed to read the subset of the policy data that the policy administrator of an
		/// <c>IAzApplication</c> or <c>IAzScope</c> object uses to administer the delegated object.
		/// </para>
		/// <para><b>Note</b>  Delegated policy users are not supported for XML stores.</para>
		/// <para></para>
		/// <para>In JScript, the returned <c>SAFEARRAY</c> must be converted to the JScript <c>Array</c> object.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazauthorizationstore-get_delegatedpolicyusersname HRESULT
		// get_DelegatedPolicyUsersName( VARIANT *pvarDelegatedPolicyUsers );
		[DispId(1610743855)]
		new object DelegatedPolicyUsersName
		{
			[DispId(1610743855)]
			[return: MarshalAs(UnmanagedType.Struct)]
			get;
		}

		/// <summary>
		/// <para>
		/// The <b>AddDelegatedPolicyUserName</b> method adds the specified account name to the list of principals that act as delegated
		/// policy users.
		/// </para>
		/// <para>This method is an alternate version of the <c>AddDelegatedPolicyUser</c> method.</para>
		/// </summary>
		/// <param name="bstrDelegatedPolicyUser">
		/// Account name to add to the list of delegated policy users. The account name must be in <c>user principal name</c> (UPN) format
		/// (for example, "someone@example.com"). The <c>LookupAccountName</c> function is called to retrieve the domain.
		/// </param>
		/// <param name="varReserved">Reserved for future use.</param>
		/// <remarks>
		/// <para>
		/// Delegated policy users are principals that are allowed to read the subset of the policy data that the policy administrator of an
		/// <c>IAzApplication</c> or <c>IAzScope</c> object uses to administer the delegated object.
		/// </para>
		/// <para><b>Note</b>  Delegated policy users are not supported for XML stores.</para>
		/// <para></para>
		/// <para>To view the list of delegated policy users in account name format, use the <c>DelegatedPolicyUsersName</c> property.</para>
		/// <para>You must call the <c>Submit</c> method to persist any changes made by this method.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazauthorizationstore-adddelegatedpolicyusername HRESULT
		// AddDelegatedPolicyUserName( [in] BSTR bstrDelegatedPolicyUser, [in, optional] VARIANT varReserved );
		[DispId(1610743856)]
		new void AddDelegatedPolicyUserName([In, MarshalAs(UnmanagedType.BStr)] string bstrDelegatedPolicyUser, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>
		/// The <b>DeleteDelegatedPolicyUserName</b> method removes the specified account name from the list of principals that act as
		/// delegated policy users.
		/// </summary>
		/// <param name="bstrDelegatedPolicyUser">
		/// Account name to remove from the list of delegated policy users. The account name must be in <c>user principal name</c> (UPN)
		/// format (for example, "someone@example.com"). The <c>LookupAccountName</c> function is called to retrieve the domain.
		/// </param>
		/// <param name="varReserved">Reserved for future use.</param>
		/// <remarks>
		/// <para>
		/// Delegated policy users are principals that are allowed to read the subset of the policy data that the policy administrator of an
		/// <c>IAzApplication</c> or <c>IAzScope</c> object uses to administer the delegated object.
		/// </para>
		/// <para><b>Note</b>  Delegated policy users are not supported for XML stores.</para>
		/// <para></para>
		/// <para>To view the list of delegated policy users in account name format, use the <c>DelegatedPolicyUsersName</c> property.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazauthorizationstore-deletedelegatedpolicyusername HRESULT
		// DeleteDelegatedPolicyUserName( [in] BSTR bstrDelegatedPolicyUser, [in, optional] VARIANT varReserved );
		[DispId(1610743857)]
		new void DeleteDelegatedPolicyUserName([In, MarshalAs(UnmanagedType.BStr)] string bstrDelegatedPolicyUser, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>
		/// <para>The <b>CloseApplication</b> method unloads a specified <c>IAzApplication</c> object from the cache.</para>
		/// <para>This method is not supported for XML authorization policy stores.</para>
		/// </summary>
		/// <param name="bstrApplicationName">The name of the <c>IAzApplication</c> object to close.</param>
		/// <param name="lFlag">
		/// <para>Flags that control the behavior of the operation. The following table shows the possible values.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Value</description>
		/// <description>Meaning</description>
		/// </listheader>
		/// <item>
		/// <description><b>0</b></description>
		/// <description>
		/// Child objects of the specified <c>IAzApplication</c> object will be unloaded from the cache only when the user closes the last
		/// handle to the <b>IAzApplication</b> object.
		/// </description>
		/// </item>
		/// <item>
		/// <description><b>AZ_AZSTORE_FORCE_APPLICATION_CLOSE</b></description>
		/// <description>
		/// All child objects of the specified <c>IAzApplication</c> object will be forcefully closed. Attempts to reference an open handle
		/// to a child object of the specified <b>IAzApplication</b> object will result in an <b>HRESULT_FROM_WIN32(ERROR_INVALID_HANDLE)</b>
		/// error. This flag should be used only if the user has implemented code to gracefully handle the error.
		/// </description>
		/// </item>
		/// </list>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazauthorizationstore-closeapplication HRESULT
		// CloseApplication( [in] BSTR bstrApplicationName, [in] LONG lFlag );
		[DispId(1610743858)]
		new void CloseApplication([In, MarshalAs(UnmanagedType.BStr)] string bstrApplicationName, [In] AZ_PROP_CONSTANTS lFlag);

		/// <summary>The <b>OpenApplication2</b> method opens the <c>IAzApplication2</c> object with the specified name.</summary>
		/// <param name="bstrApplicationName">The name of the <c>IAzApplication2</c> object to open.</param>
		/// <param name="varReserved">Reserved for future use.</param>
		/// <returns>A pointer to a pointer to the opened <c>IAzApplication2</c> object.</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazauthorizationstore2-openapplication2 HRESULT
		// OpenApplication2( [in] BSTR bstrApplicationName, [in, optional] VARIANT varReserved, [out] IAzApplication2 **ppApplication );
		[DispId(1610809344)]
		[return: MarshalAs(UnmanagedType.Interface)]
		new IAzApplication2 OpenApplication2([In, MarshalAs(UnmanagedType.BStr)] string bstrApplicationName, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>The <b>CreateApplication2</b> method creates an <c>IAzApplication2</c> object by using the specified name.</summary>
		/// <param name="bstrApplicationName">The name for the new <c>IAzApplication2</c> object.</param>
		/// <param name="varReserved">Reserved for future use.</param>
		/// <returns>A pointer to a pointer to the created <c>IAzApplication2</c> object.</returns>
		/// <remarks>
		/// <para>You must call the <c>IAzApplication::Submit</c> method to persist any changes made by the returned object.</para>
		/// <para>The returned <c>IAzApplication2</c> object is an immediate child object of the <c>IAzAuthorizationStore2</c> object.</para>
		/// </remarks>
		// https://learn.microsoft.com/ga-ie/windows/win32/api/azroles/nf-azroles-iazauthorizationstore2-createapplication2 HRESULT
		// CreateApplication2( [in] BSTR bstrApplicationName, [in, optional] VARIANT varReserved, [out] IAzApplication2 **ppApplication );
		[DispId(1610809345)]
		[return: MarshalAs(UnmanagedType.Interface)]
		new IAzApplication2 CreateApplication2([In, MarshalAs(UnmanagedType.BStr)] string bstrApplicationName, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>
		/// The <b>IsUpdateNeeded</b> method checks whether the persisted version of this authorization store is newer than the cached
		/// version. If the cached version of the store is newer, the calling application can update the cached version by calling the
		/// <c>UpdateCache</c> method of the <c>AzAuthorizationStore</c> object.
		/// </summary>
		/// <returns>
		/// <b>VARIANT_TRUE</b> if the persisted version of this authorization store is newer than the cached version; otherwise, <b>VARIANT_FALSE</b>.
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazauthorizationstore3-isupdateneeded HRESULT
		// IsUpdateNeeded( [out] VARIANT_BOOL *pbIsUpdateNeeded );
		[DispId(1610874880)]
		bool IsUpdateNeeded();

		/// <summary>
		/// The <b>BizruleGroupSupported</b> method returns a Boolean value that specifies whether this <c>IAzAuthorizationStore3</c> object
		/// supports application groups that use business rule (BizRule) scripts.
		/// </summary>
		/// <returns>
		/// <b>VARIANT_TRUE</b> if the current <c>IAzAuthorizationStore3</c> object supports scripts that use business logic to determine
		/// group membership; otherwise, <b>VARIANT_FALSE</b>.
		/// </returns>
		// https://learn.microsoft.com/nb-no/windows/win32/api/azroles/nf-azroles-iazauthorizationstore3-bizrulegroupsupported HRESULT
		// BizruleGroupSupported( [out] VARIANT_BOOL *pbSupported );
		[DispId(1610874881)]
		bool BizruleGroupSupported();

		/// <summary>The <b>UpgradeStoresFunctionalLevel</b> method upgrades this authorization store from version 1 to version 2.</summary>
		/// <param name="lFunctionalLevel">
		/// Specifies the version to which to upgrade the authorization store. Set the value of this parameter to <b>AZ_AZSTORE_NT6_FUNCTION_LEVEL</b>
		/// </param>
		/// <remarks>
		/// If the authorization store being updated is an Active Directory store, this method checks whether the LDAP schema of the Active
		/// Directory store is updated. If the LDAP schema of the Active Directory store is not updated, the authorization store is not updated.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazauthorizationstore3-upgradestoresfunctionallevel HRESULT
		// UpgradeStoresFunctionalLevel( [in] LONG lFunctionalLevel );
		[DispId(1610874882)]
		void UpgradeStoresFunctionalLevel([In] AZ_PROP_CONSTANTS lFunctionalLevel);

		/// <summary>
		/// The <b>IsFunctionalLevelUpgradeSupported</b> method gets a Boolean value that indicates whether the version of this authorization
		/// store can be upgraded.
		/// </summary>
		/// <param name="lFunctionalLevel">The version to check. Set this parameter to <b>AZ_AZSTORE_NT6_FUNCTION_LEVEL</b>.</param>
		/// <returns><b>VARIANT_TRUE</b> if the underlying authorization store supports version 2 functionality; otherwise, <b>VARIANT_FALSE</b>.</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazauthorizationstore3-isfunctionallevelupgradesupported
		// HRESULT IsFunctionalLevelUpgradeSupported( [in] LONG lFunctionalLevel, [out] VARIANT_BOOL *pbSupported );
		[DispId(1610874883)]
		bool IsFunctionalLevelUpgradeSupported([In] AZ_PROP_CONSTANTS lFunctionalLevel);

		/// <summary>The <b>GetSchemaVersion</b> method gets the version number of this authorization store.</summary>
		/// <param name="plMajorVersion">
		/// The major version of the authorization store. Valid values are 1 and 2. A version 1 Authorization Manager (AzMan) runtime cannot
		/// read from or write to an authorization store with a major version of 2.
		/// </param>
		/// <param name="plMinorVersion">
		/// The minor version of the authorization store. Valid values are 1 and 2. A version 1 AzMan runtime can read from but not write to
		/// an authorization store with a minor version of 2.
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazauthorizationstore3-getschemaversion HRESULT
		// GetSchemaVersion( [out] LONG *plMajorVersion, [out] LONG *plMinorVersion );
		[DispId(1610874884)]
		void GetSchemaVersion(out int plMajorVersion, out int plMinorVersion);
	}
}