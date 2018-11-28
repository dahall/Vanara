using System;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using Vanara.Extensions;
using Vanara.InteropServices;

namespace Vanara.PInvoke
{
	/// <summary>Platform invokable enumerated types, constants and functions from ntdsapi.h</summary>
	public static partial class NTDSApi
	{
		private const uint NO_ERROR = 0;

		/// <summary>
		/// Defines the errors returned by the status member of the <see cref="DS_NAME_RESULT_ITEM"/> structure. These are potential errors
		/// that may be encountered while a name is converted by the <see cref="DsCrackNames(SafeDsHandle, string[], DS_NAME_FORMAT,
		/// DS_NAME_FORMAT, DS_NAME_FLAGS)"/> function.
		/// </summary>
		[PInvokeData("NTDSApi.h", MSDNShortId = "ms676061")]
		public enum DS_NAME_ERROR
		{
			/// <summary>The conversion was successful.</summary>
			DS_NAME_NO_ERROR = 0,

			/// <summary>A generic processing error occurred.</summary>
			DS_NAME_ERROR_RESOLVING = 1,

			/// <summary>The name cannot be found or the caller does not have permission to access the name.</summary>
			DS_NAME_ERROR_NOT_FOUND = 2,

			/// <summary>
			/// The input name is mapped to more than one output name or the desired format did not have a single, unique value for the
			/// object found.
			/// </summary>
			DS_NAME_ERROR_NOT_UNIQUE = 3,

			/// <summary>
			/// The input name was found, but the associated output format cannot be found. This can occur if the object does not have all
			/// the required attributes.
			/// </summary>
			DS_NAME_ERROR_NO_MAPPING = 4,

			/// <summary>
			/// Unable to resolve entire name, but was able to determine in which domain object resides. The caller is expected to retry the
			/// call at a domain controller for the specified domain. The entire name cannot be resolved, but the domain that the object
			/// resides in could be determined. The pDomain member of the DS_NAME_RESULT_ITEM contains valid data when this error is specified.
			/// </summary>
			DS_NAME_ERROR_DOMAIN_ONLY = 5,

			/// <summary>A syntactical mapping cannot be performed on the client without transmitting over the network.</summary>
			DS_NAME_ERROR_NO_SYNTACTICAL_MAPPING = 6,

			/// <summary>The name is from an external trusted forest.</summary>
			DS_NAME_ERROR_TRUST_REFERRAL = 7
		}

		/// <summary>
		/// Used to define how the name syntax will be cracked. These flags are used by the <see cref="DsCrackNames(SafeDsHandle, string[],
		/// DS_NAME_FORMAT, DS_NAME_FORMAT, DS_NAME_FLAGS)"/> function.
		/// </summary>
		[Flags]
		[PInvokeData("NTDSApi.h", MSDNShortId = "ms676062")]
		public enum DS_NAME_FLAGS
		{
			/// <summary>Indicates that there are no associated flags.</summary>
			DS_NAME_NO_FLAGS = 0x0,

			/// <summary>
			/// Performs a syntactical mapping at the client without transferring over the network. The only syntactic mapping supported is
			/// from DS_FQDN_1779_NAME to DS_CANONICAL_NAME or DS_CANONICAL_NAME_EX. <see cref="DsCrackNames(SafeDsHandle, string[],
			/// DS_NAME_FORMAT, DS_NAME_FORMAT, DS_NAME_FLAGS)"/> returns the DS_NAME_ERROR_NO_SYNTACTICAL_MAPPING flag if a syntactical
			/// mapping is not possible.
			/// </summary>
			DS_NAME_FLAG_SYNTACTICAL_ONLY = 0x1,

			/// <summary>Forces a trip to the domain controller for evaluation, even if the syntax could be cracked locally.</summary>
			DS_NAME_FLAG_EVAL_AT_DC = 0x2,

			/// <summary>The call fails if the domain controller is not a global catalog server.</summary>
			DS_NAME_FLAG_GCVERIFY = 0x4,

			/// <summary>Enables cross forest trust referral.</summary>
			DS_NAME_FLAG_TRUST_REFERRAL = 0x8
		}

		/// <summary>
		/// Provides formats to use for input and output names for the <see cref="DsCrackNames(SafeDsHandle, string[], DS_NAME_FORMAT,
		/// DS_NAME_FORMAT, DS_NAME_FLAGS)"/> function.
		/// </summary>
		[PInvokeData("NTDSApi.h", MSDNShortId = "ms676245")]
		public enum DS_NAME_FORMAT
		{
			/// <summary>
			/// Indicates the name is using an unknown name type. This format can impact performance because it forces the server to attempt
			/// to match all possible formats. Only use this value if the input format is unknown.
			/// </summary>
			DS_UNKNOWN_NAME = 0,

			/// <summary>
			/// Indicates that the fully qualified distinguished name is used. For example: CN = someone, OU = Users, DC = Engineering, DC =
			/// Fabrikam, DC = Com
			/// </summary>
			DS_FQDN_1779_NAME = 1,

			/// <summary>
			/// Indicates a Windows NT 4.0 account name. For example: Engineering\someone The domain-only version includes two trailing
			/// backslashes (\\).
			/// </summary>
			DS_NT4_ACCOUNT_NAME = 2,

			/// <summary>
			/// Indicates a user-friendly display name, for example, Jeff Smith. The display name is not necessarily the same as relative
			/// distinguished name (RDN).
			/// </summary>
			DS_DISPLAY_NAME = 3,

			/// <summary>Indicates a GUID string that the IIDFromString function returns. For example: {4fa050f0-f561-11cf-bdd9-00aa003a77b6}</summary>
			DS_UNIQUE_ID_NAME = 6,

			/// <summary>
			/// Indicates a complete canonical name. For example: engineering.fabrikam.com/software/someone The domain-only version includes
			/// a trailing forward slash (/).
			/// </summary>
			DS_CANONICAL_NAME = 7,

			/// <summary>Indicates that it is using the user principal name (UPN). For example: someone@engineering.fabrikam.com</summary>
			DS_USER_PRINCIPAL_NAME = 8,

			/// <summary>
			/// This element is the same as DS_CANONICAL_NAME except that the rightmost forward slash (/) is replaced with a newline
			/// character (\n), even in a domain-only case. For example: engineering.fabrikam.com/software\nsomeone
			/// </summary>
			DS_CANONICAL_NAME_EX = 9,

			/// <summary>Indicates it is using a generalized service principal name. For example: www/www.fabrikam.com@fabrikam.com</summary>
			DS_SERVICE_PRINCIPAL_NAME = 10,

			/// <summary>
			/// Indicates a Security Identifier (SID) for the object. This can be either the current SID or a SID from the object SID
			/// history. The SID string can use either the standard string representation of a SID, or one of the string constants defined in
			/// Sddl.h. For more information about converting a binary SID into a SID string, see SID Strings. The following is an example of
			/// a SID string: S-1-5-21-397955417-626881126-188441444-501
			/// </summary>
			DS_SID_OR_SID_HISTORY_NAME = 11,

			/// <summary>Not supported by the Directory Service (DS) APIs.</summary>
			DS_DNS_DOMAIN_NAME = 12,

			/// <summary>
			/// This causes DsCrackNames to return the distinguished names of all naming contexts in the current forest. The formatDesired
			/// parameter is ignored. cNames must be at least one and all strings in rpNames must have a length greater than zero characters.
			/// The contents of the rpNames strings is ignored.
			/// </summary>
			DS_LIST_NCS = unchecked((int)0xfffffff6)
		}

		/// <summary>
		/// <para>The <c>DS_SPN_NAME_TYPE</c> enumeration is used by the DsGetSPN function to identify the format for composing SPNs.</para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/ntdsapi/ne-ntdsapi-ds_spn_name_type typedef enum DS_SPN_NAME_TYPE {
		// DS_SPN_DNS_HOST , DS_SPN_DN_HOST , DS_SPN_NB_HOST , DS_SPN_DOMAIN , DS_SPN_NB_DOMAIN , DS_SPN_SERVICE } ;
		[PInvokeData("ntdsapi.h", MSDNShortId = "7aab22a6-1fe1-4127-97d3-54287d770790")]
		public enum DS_SPN_NAME_TYPE
		{
			DS_SPN_DNS_HOST,
			DS_SPN_DN_HOST,
			DS_SPN_NB_HOST,
			DS_SPN_DOMAIN,
			DS_SPN_NB_DOMAIN,
			DS_SPN_SERVICE
		}

		/// <summary>
		/// <para>
		/// The <c>DS_SPN_WRITE_OP</c> enumeration identifies the type of write operation that should be performed by the DsWriteAccountSpn function.
		/// </para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/ntdsapi/ne-ntdsapi-ds_spn_write_op typedef enum DS_SPN_WRITE_OP {
		// DS_SPN_ADD_SPN_OP , DS_SPN_REPLACE_SPN_OP , DS_SPN_DELETE_SPN_OP } ;
		[PInvokeData("ntdsapi.h", MSDNShortId = "8367bdaf-3d8d-46b3-9d03-b9753e8e5a1a")]
		public enum DS_SPN_WRITE_OP
		{
			/// <summary>Adds the specified service principal names (SPNs) to the object identified by the pszAccount parameter in DsWriteAccountSpn.</summary>
			DS_SPN_ADD_SPN_OP,

			/// <summary>
			/// Removes all SPNs currently registered on the account identified by the pszAccount parameter in DsWriteAccountSpn and replaces
			/// them with the SPNs specified by the rpszSpn parameter in DsWriteAccountSpn.
			/// </summary>
			DS_SPN_REPLACE_SPN_OP,

			/// <summary>Deletes the specified SPNs from the object identified by the pszAccount parameter in DsWriteAccountSpn.</summary>
			DS_SPN_DELETE_SPN_OP,
		}

		/// <summary>
		/// <para>
		/// The <c>DsAddSidHistory</c> function retrieves the primary account security identifier (SID) of a security principal from one
		/// domain and adds it to the <c>sIDHistory</c> attribute of a security principal in another domain in a different forest. When the
		/// source domain is in Windows 2000 native mode, this function also retrieves the <c>sIDHistory</c> values of the source principal
		/// and adds them to the destination principal <c>sIDHistory</c>.
		/// </para>
		/// <para>
		/// The <c>DsAddSidHistory</c> function performs a security-sensitive function by adding the primary account SID of an existing
		/// security principal to the <c>sIDHistory</c> of a principal in a domain in a different forest, effectively granting to the latter
		/// access to all resources accessible to the former. For more information about the use and security implications of this function,
		/// see Using DsAddSidHistory.
		/// </para>
		/// </summary>
		/// <param name="hDS">
		/// <para>Contains a directory service handle obtained from either the DSBind or DSBindWithCred function.</para>
		/// </param>
		/// <param name="Flags">
		/// <para>Reserved for future use. Set to <c>NULL</c>.</para>
		/// </param>
		/// <param name="SrcDomain">
		/// <para>Pointer to a null-terminated string that specifies the name of the domain to query for the SID of SrcPrincipal.</para>
		/// <para>
		/// If the source domain runs on Windows Server operating systems, SrcDomain can be either a domain name system (DNS) name, for
		/// example, fabrikam.com, or a flat NetBIOS, for example, Fabrikam, name. DNS names should be used when possible.
		/// </para>
		/// </param>
		/// <param name="SrcPrincipal">
		/// <para>
		/// Pointer to a null-terminated string that specifies the name of a security principal, user or group, in the source domain. This
		/// name is a domain-relative Security Account Manager (SAM) name, for example: evacorets.
		/// </para>
		/// </param>
		/// <param name="SrcDomainController">
		/// <para>
		/// Pointer to a null-terminated string that specifies the name of the primary domain controller (PDC) Emulator in the source domain
		/// to use for secure retrieval of the source principal SID and audit generation.
		/// </para>
		/// <para>If this parameter is <c>NULL</c>, DSBindWithCred will select the primary domain controller.</para>
		/// <para>SrcDomainController can be either a DNS name or a flat NetBIOS name. DNS names should be used when possible.</para>
		/// </param>
		/// <param name="SrcDomainCreds">
		/// <para>
		/// Contains an identity handle that represents the identity and credentials of a user with administrative rights in the source
		/// domain. To obtain this handle, call DsMakePasswordCredentials. This user must be a member of either the Administrators or the
		/// Domain Administrators group. If this call is made from a remote computer to the destination DC, then both the remote computer and
		/// the destination DC must support 128-bit encryption to privacy-protect the credentials. If 128-bit encryption is unavailable and
		/// SrcDomainCreds are provided, then the call must be made on the destination DC.
		/// </para>
		/// <para>If this parameter is <c>NULL</c>, the credentials of the caller are used for access to the source domain.</para>
		/// </param>
		/// <param name="DstDomain">
		/// <para>
		/// Pointer to a null-terminated string that specifies the name of the destination domain in which DstPrincipal resides. This name
		/// can either be a DNS name, for example, fabrikam.com, or a NetBIOS name, for example, Fabrikam. The destination domain must run
		/// Windows 2000 native mode.
		/// </para>
		/// </param>
		/// <param name="DstPrincipal">
		/// <para>
		/// Pointer to a null-terminated string that specifies the name of a security principal, user or group, in the destination domain.
		/// This domain-relative SAM name identifies the principal whose <c>sIDHistory</c> attribute is updated with the SID of the SrcPrincipal.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Returns a Win32 error codes including the following.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/ntdsapi/nf-ntdsapi-dsaddsidhistorya NTDSAPI DWORD DsAddSidHistoryA( HANDLE
		// hDS, DWORD Flags, LPCSTR SrcDomain, LPCSTR SrcPrincipal, LPCSTR SrcDomainController, RPC_AUTH_IDENTITY_HANDLE SrcDomainCreds,
		// LPCSTR DstDomain, LPCSTR DstPrincipal );
		[DllImport(Lib.NTDSApi, SetLastError = false, CharSet = CharSet.Auto)]
		[PInvokeData("ntdsapi.h", MSDNShortId = "36ef8734-717a-4c3a-a839-6591d85c9734")]
		public static extern Win32Error DsAddSidHistory(SafeDsHandle hDS, uint Flags, string SrcDomain, string SrcPrincipal, string SrcDomainController, SafeAuthIdentityHandle SrcDomainCreds,
			string DstDomain, string DstPrincipal);

		/// <summary>
		/// The DsBind function binds to a domain controller.DsBind uses the default process credentials to bind to the domain controller. To
		/// specify alternate credentials, use the DsBindWithCred function.
		/// </summary>
		/// <remarks>
		/// The behavior of the DsBind function is determined by the contents of the DomainControllerName and DnsDomainName parameters. The
		/// following list describes the behavior of this function based on the contents of these parameters.
		/// <list type="table">
		/// <listheader>
		/// <description>DomainControllerName</description>
		/// <description>DnsDomainName</description>
		/// <description>Description</description>
		/// </listheader>
		/// <item>
		/// <description><c>NULL</c></description>
		/// <description><c>NULL</c></description>
		/// <description>DsBind will attempt to bind to a global catalog server in the forest of the local computer.</description>
		/// </item>
		/// <item>
		/// <description>(value)</description>
		/// <description><c>NULL</c></description>
		/// <description>DsBind will attempt to bind to the domain controller specified by the DomainControllerName parameter.</description>
		/// </item>
		/// <item>
		/// <description><c>NULL</c></description>
		/// <description>(value)</description>
		/// <description>DsBind will attempt to bind to any domain controller in the domain specified by DnsDomainName parameter.</description>
		/// </item>
		/// <item>
		/// <description>(value)</description>
		/// <description>(value)</description>
		/// <description>
		/// The DomainControllerName parameter takes precedence. DsBind will attempt to bind to the domain controller specified by the
		/// DomainControllerName parameter.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		/// <param name="DomainControllerName">
		/// Pointer to a null-terminated string that contains the name of the domain controller to bind to. This name can be the name of the
		/// domain controller or the fully qualified DNS name of the domain controller. Either name type can, optionally, be preceded by two
		/// backslash characters. All of the following examples represent correctly formatted domain controller names:
		/// <list type="bullet">
		/// <item><definition>"FAB-DC-01"</definition></item>
		/// <item><definition>"\\FAB-DC-01"</definition></item>
		/// <item><definition>"FAB-DC-01.fabrikam.com"</definition></item>
		/// <item><definition>"\\FAB-DC-01.fabrikam.com"</definition></item>
		/// </list>
		/// <para>This parameter can be NULL. For more information, see Remarks.</para>
		/// </param>
		/// <param name="DnsDomainName">
		/// Pointer to a null-terminated string that contains the fully qualified DNS name of the domain to bind to. This parameter can be
		/// NULL. For more information, see Remarks.
		/// </param>
		/// <param name="phDS">
		/// Address of a HANDLE value that receives the binding handle. To close this handle, pass it to the DsUnBind function.
		/// </param>
		/// <returns>Returns ERROR_SUCCESS if successful or a Windows or RPC error code otherwise.</returns>
		[DllImport(Lib.NTDSApi, CharSet = CharSet.Auto, SetLastError = true)]
		[PInvokeData("NTDSApi.h", MSDNShortId = "ms675931")]
		public static extern Win32Error DsBind([Optional] string DomainControllerName, [Optional] string DnsDomainName, out SafeDsHandle phDS);

		/// <summary>The DsBindByInstance function explicitly binds to any AD LDS or Active Directory instance.</summary>
		/// <param name="ServerName">
		/// (optional)Pointer to a null-terminated string that specifies the name of the instance. This parameter is required to bind to an
		/// AD LDS instance. If this parameter is NULL when binding to an Active Directory instance, then the DnsDomainName parameter must
		/// contain a value. If this parameter and the DnsDomainName parameter are both NULL, the function fails with the return value
		/// ERROR_INVALID_PARAMETER (87).
		/// </param>
		/// <param name="Annotation">
		/// (optional)Pointer to a null-terminated string that specifies the port number of the AD LDS instance or NULL when binding to an
		/// Active Directory instance. For example, "389".
		/// <para>
		/// If this parameter is NULL when binding by domain to an Active Directory instance, then the DnsDomainName parameter must be
		/// specified. If this parameter is NULL when binding to an AD LDS instance, then the InstanceGuid parameter must be specified.
		/// </para>
		/// </param>
		/// <param name="InstanceGuid">
		/// (optional)Pointer to a GUID value that contains the GUID of the AD LDS instance. The GUID value is the objectGUID property of the
		/// nTDSDSA object of the instance. If this parameter is NULL when binding to an AD LDS instance, the Annotation parameter must be specified.
		/// </param>
		/// <param name="DnsDomainName">
		/// (optional)Pointer to a null-terminated string that specifies the DNS name of the domain when binding to an Active Directory
		/// instance by domain. Set this parameter to NULL to bind to an Active Directory instance by server or to an AD LDS instance.
		/// </param>
		/// <param name="AuthIdentity">
		/// (optional)Handle to the credentials used to start the RPC session. Use the DsMakePasswordCredentials function to create a
		/// structure suitable for AuthIdentity.
		/// </param>
		/// <param name="ServicePrincipalName">
		/// (optional)Pointer to a null-terminated string that specifies the Service Principal Name to assign to the client. Passing NULL in
		/// ServicePrincipalName is equivalent to a call to the DsBindWithCred function.
		/// </param>
		/// <param name="BindFlags">
		/// (optional)Contains a set of flags that define the behavior of this function. This parameter can contain zero or a combination of
		/// the values listed in the following table.
		/// <para>NTDSAPI_BIND_ALLOW_DELEGATION, NTDSAPI_BIND_FIND_BINDING, NTDSAPI_BIND_FORCE_KERBEROS</para>
		/// </param>
		/// <param name="phDS">Address of a DsHandle value that receives the bind handle. To close this handle, call DsUnBind.</param>
		/// <returns>Returns NO_ERROR if successful or an RPC or Win32 error otherwise.</returns>
		[DllImport("Ntdsapi.dll", CharSet = CharSet.Auto, EntryPoint = "DsBindByInstance", SetLastError = false, ThrowOnUnmappableChar = true), SuppressUnmanagedCodeSecurity]
		public static extern Win32Error DsBindByInstance([Optional] string ServerName, [Optional] string Annotation, in Guid InstanceGuid, [Optional] string DnsDomainName,
			SafeAuthIdentityHandle AuthIdentity, [Optional] string ServicePrincipalName, DsBindFlags BindFlags, out SafeDsHandle phDS);

		/// <summary>
		/// <para>
		/// The <c>DsBindingSetTimeout</c> function sets the timeout value that is honored by all RPC calls that use the specified binding
		/// handle. RPC calls that required more time than the timeout value are canceled.
		/// </para>
		/// </summary>
		/// <param name="hDS">
		/// <para>Contains a directory service handle obtained from either the DSBind or DSBindWithCred function.</para>
		/// </param>
		/// <param name="cTimeoutSecs">
		/// <para>Contains the new timeout value, in seconds.</para>
		/// </param>
		/// <returns>
		/// <para>Returns <c>ERROR_SUCCESS</c> if successful or a Win32 or RPC error code otherwise. The following is a possible error code.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/ntdsapi/nf-ntdsapi-dsbindingsettimeout NTDSAPI_POSTXP DWORD
		// DsBindingSetTimeout( HANDLE hDS, ULONG cTimeoutSecs );
		[DllImport(Lib.NTDSApi, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("ntdsapi.h", MSDNShortId = "abdaae89-fba3-4949-92a9-acd62898ec24")]
		public static extern Win32Error DsBindingSetTimeout(SafeDsHandle hDS, uint cTimeoutSecs);

		/// <summary>
		/// <para>
		/// The <c>DsBindToISTG</c> function binds to the computer that holds the Inter-Site Topology Generator (ISTG) role in the domain of
		/// the local computer.
		/// </para>
		/// </summary>
		/// <param name="SiteName">
		/// <para>
		/// Pointer to a null-terminated string that contains the site name used when binding. If this parameter is <c>NULL</c>, the site of
		/// the nearest domain controller is used.
		/// </para>
		/// </param>
		/// <param name="phDS">
		/// <para>Address of a <c>HANDLE</c> value that receives the bind handle. To close this handle, call DsUnBind.</para>
		/// </param>
		/// <returns>
		/// <para>Returns <c>ERROR_SUCCESS</c> if successful or a Win32 or RPC error code otherwise. The following are possible error codes.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/ntdsapi/nf-ntdsapi-dsbindtoistga NTDSAPI_POSTXP DWORD DsBindToISTGA( LPCSTR
		// SiteName, HANDLE *phDS );
		[DllImport(Lib.NTDSApi, SetLastError = false, CharSet = CharSet.Auto)]
		[PInvokeData("ntdsapi.h", MSDNShortId = "bd53124c-8578-495d-b540-d4b4c09297c3")]
		public static extern Win32Error DsBindToISTG(string SiteName, out SafeDsHandle phDS);

		/// <summary>The DsBindWithCred function binds to a domain controller using the specified credentials.</summary>
		/// <param name="DomainControllerName">
		/// Pointer to a null-terminated string that contains the name of the domain controller to bind to. This name can be the name of the
		/// domain controller or the fully qualified DNS name of the domain controller. Either name type can, optionally, be preceded by two
		/// backslash characters. All of the following examples represent correctly formatted domain controller names:
		/// <list type="bullet">
		/// <item><definition>"FAB-DC-01"</definition></item>
		/// <item><definition>"\\FAB-DC-01"</definition></item>
		/// <item><definition>"FAB-DC-01.fabrikam.com"</definition></item>
		/// <item><definition>"\\FAB-DC-01.fabrikam.com"</definition></item>
		/// </list>
		/// <para>This parameter can be NULL. For more information, see Remarks.</para>
		/// </param>
		/// <param name="DnsDomainName">
		/// Pointer to a null-terminated string that contains the fully qualified DNS name of the domain to bind to. This parameter can be
		/// NULL. For more information, see Remarks.
		/// </param>
		/// <param name="AuthIdentity">
		/// Contains an RPC_AUTH_IDENTITY_HANDLE value that represents the credentials to be used for the bind. The DsMakePasswordCredentials
		/// function is used to obtain this value. If this parameter is NULL, the credentials of the calling thread are used.
		/// <para>DsUnBind must be called before freeing this handle with the DsFreePasswordCredentials function.</para>
		/// </param>
		/// <param name="phDS">
		/// Address of a HANDLE value that receives the binding handle. To close this handle, pass it to the DsUnBind function.
		/// </param>
		/// <returns>Returns ERROR_SUCCESS if successful or a Windows or RPC error code otherwise.</returns>
		[DllImport(Lib.NTDSApi, CharSet = CharSet.Auto, SetLastError = true)]
		[PInvokeData("NTDSApi.h", MSDNShortId = "ms675961")]
		public static extern Win32Error DsBindWithCred([Optional] string DomainControllerName, [Optional] string DnsDomainName, SafeAuthIdentityHandle AuthIdentity, out SafeDsHandle phDS);

		/// <summary>
		/// <para>
		/// The <c>DsBindWithSpn</c> function binds to a domain controller using the specified credentials and a specific service principal
		/// name (SPN) for mutual authentication.
		/// </para>
		/// <para>
		/// This function is provided for where complete control is required for mutual authentication. Do not use this function if you
		/// expect DsBind to find a server for you, because SPNs are computer-specific, and it is unlikely that the SPN you provide will
		/// match the server that <c>DsBind</c> finds for you. Providing a <c>NULL</c> ServicePrincipalName argument results in behavior that
		/// is identical to DsBindWithCred.
		/// </para>
		/// </summary>
		/// <param name="DomainControllerName">
		/// <para>
		/// Pointer to a null-terminated string that contains the fully qualified DNS name of the domain to bind to. For more information,
		/// see the DomainControllerName description in the DsBind topic.
		/// </para>
		/// </param>
		/// <param name="DnsDomainName">
		/// <para>
		/// Pointer to a null-terminated string that contains the fully qualified DNS name of the domain to bind to. For more information,
		/// see the DnsDomainName description in the DsBind topic.
		/// </para>
		/// </param>
		/// <param name="AuthIdentity">
		/// <para>Contains an RPC_AUTH_IDENTITY_HANDLE value that represents the credentials to be used for the bind. The</para>
		/// <para>
		/// DsMakePasswordCredentialsfunction is used to obtain this value. If this parameter is <c>NULL</c>, the credentials of the calling
		/// thread are used.
		/// </para>
		/// <para>DsUnBind must be called before freeing this handle with the DsFreePasswordCredentials function.</para>
		/// </param>
		/// <param name="ServicePrincipalName">
		/// <para>
		/// Pointer to a null-terminated string that specifies the Service Principal Name to assign to the client. Passing <c>NULL</c> in
		/// ServicePrincipalName is equivalent to a call to the DsBindWithCred function.
		/// </para>
		/// </param>
		/// <param name="phDS">
		/// <para>Address of a <c>HANDLE</c> value that receives the binding handle. To close this handle, pass it to the DsUnBind function.</para>
		/// </param>
		/// <returns>
		/// <para>
		/// Returns <c>ERROR_SUCCESS</c> if successful or a Windows or RPC error code otherwise. The following are the most common error codes.
		/// </para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/ntdsapi/nf-ntdsapi-dsbindwithspnw NTDSAPI DWORD DsBindWithSpnW( LPCWSTR
		// DomainControllerName, LPCWSTR DnsDomainName, RPC_AUTH_IDENTITY_HANDLE AuthIdentity, LPCWSTR ServicePrincipalName, HANDLE *phDS );
		[DllImport(Lib.NTDSApi, SetLastError = false, CharSet = CharSet.Auto)]
		[PInvokeData("ntdsapi.h", MSDNShortId = "9a149654-fd94-4b0c-b712-07fb827bef2f")]
		public static extern Win32Error DsBindWithSpn([Optional] string DomainControllerName, [Optional] string DnsDomainName, SafeAuthIdentityHandle AuthIdentity, string ServicePrincipalName, out SafeDsHandle phDS);

		/// <summary>
		/// <para>
		/// The <c>DsBindWithSpnEx</c> function binds to a domain controller using the specified credentials and a specific service principal
		/// name (SPN) for mutual authentication. This function is similar to the DsBindWithSpn function except this function allows more
		/// binding options with the BindFlags parameter.
		/// </para>
		/// <para>
		/// This function is provided where complete control is required over mutual authentication. Do not use this function if you expect
		/// DsBind to find a server for you, because SPNs are computer-specific, and it is unlikely that the SPN you provide will match the
		/// server that <c>DsBind</c> finds for you. Providing a <c>NULL</c> ServicePrincipalName argument results in behavior that is
		/// identical to DsBindWithCred.
		/// </para>
		/// </summary>
		/// <param name="DomainControllerName">
		/// <para>
		/// Pointer to a null-terminated string that contains the fully qualified DNS name of the domain to bind. For more information, see
		/// the DomainControllerName description in the DsBind topic.
		/// </para>
		/// </param>
		/// <param name="DnsDomainName">
		/// <para>
		/// Pointer to a null-terminated string that contains the fully qualified DNS name of the domain to bind. For more information, see
		/// the DnsDomainName description in the DsBind topic.
		/// </para>
		/// </param>
		/// <param name="AuthIdentity">
		/// <para>Contains an RPC_AUTH_IDENTITY_HANDLE value that represents the credentials to be used for the bind. The</para>
		/// <para>
		/// DsMakePasswordCredentialsfunction is used to obtain this value. If this parameter is <c>NULL</c>, the credentials of the calling
		/// thread are used.
		/// </para>
		/// <para>DsUnBind must be called before freeing this handle with the DsFreePasswordCredentials function.</para>
		/// </param>
		/// <param name="ServicePrincipalName">
		/// <para>
		/// Pointer to a null-terminated string that specifies the Service Principal Name to assign to the client. Passing <c>NULL</c> in
		/// ServicePrincipalName is equivalent to a call to the DsBindWithCred function.
		/// </para>
		/// </param>
		/// <param name="BindFlags">
		/// <para>
		/// Contains a set of flags that define the behavior of this function. This parameter can contain zero or a combination of the values
		/// listed in the following list.
		/// </para>
		/// <para>NTDSAPI_BIND_ALLOW_DELEGATION (1)</para>
		/// <para>
		/// Causes the bind to use the delegate impersonation level. This allows operations that require delegation, such as DsAddSidHistory,
		/// to succeed. Specifying this flag also causes <c>DsBindWithSpnEx</c> to operate like DsBindWithSpn.
		/// </para>
		/// <para>
		/// If this flag is not specified, the bind will use the impersonate impersonation level. For more information, see Impersonation Levels.
		/// </para>
		/// <para>
		/// Most operations do not require the delegate impersonation level, so this flag should only be specified if absolutely required.
		/// Binding to a rogue server with the delegate impersonation level will allow the rogue server to connect to a non-rogue server with
		/// your credentials and perform unintended operations.
		/// </para>
		/// <para>NTDSAPI_BIND_FIND_BINDING (2)</para>
		/// <para>Reserved.</para>
		/// <para>NTDSAPI_BIND_FORCE_KERBEROS (4)</para>
		/// <para>
		/// <c>Active Directory Lightweight Directory Services:</c> If this flag is specified, <c>DsBindWithSpnEx</c> forces Kerberos
		/// authentication to be used. If Kerberos authentication cannot be established, <c>DsBindWithSpnEx</c> will not attempt to
		/// authenticate with any other method.
		/// </para>
		/// </param>
		/// <param name="phDS">
		/// <para>Address of a <c>HANDLE</c> value that receives the binding handle. To close this handle, pass it to the DsUnBind function.</para>
		/// </param>
		/// <returns>
		/// <para>
		/// Returns <c>ERROR_SUCCESS</c> if successful or a Windows or RPC error code otherwise. The following list lists common error codes.
		/// </para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/ntdsapi/nf-ntdsapi-dsbindwithspnexw NTDSAPI_POSTXP DWORD DsBindWithSpnExW(
		// LPCWSTR DomainControllerName, LPCWSTR DnsDomainName, RPC_AUTH_IDENTITY_HANDLE AuthIdentity, LPCWSTR ServicePrincipalName, DWORD
		// BindFlags, HANDLE *phDS );
		[DllImport(Lib.NTDSApi, SetLastError = false, CharSet = CharSet.Auto)]
		[PInvokeData("ntdsapi.h", MSDNShortId = "52a5761d-5244-4bc9-8c09-fd08f10a9fff")]
		public static extern Win32Error DsBindWithSpnEx([Optional] string DomainControllerName, [Optional] string DnsDomainName, SafeAuthIdentityHandle AuthIdentity, string ServicePrincipalName,
			DsBindFlags BindFlags, out SafeDsHandle phDS);

		/// <summary>Flags for DsBindWithSpnEx and DsBindByInstance</summary>
		[PInvokeData("ntdsapi.h", MSDNShortId = "52a5761d-5244-4bc9-8c09-fd08f10a9fff")]
		[Flags]
		public enum DsBindFlags
		{
			/// <summary>
			/// <para>
			/// Causes the bind to use the delegate impersonation level. This enables operations that require delegation, such as
			/// DsAddSidHistory, to succeed. Specifying this flag also causes DsBindWithSpnEx to operate similar to DsBindWithSpn.
			/// </para>
			/// <para>
			/// If this flag is not specified, the bind will use the impersonate impersonation level. For more information about
			/// impersonation levels, see Impersonation Levels.
			/// </para>
			/// <para>
			/// Most operations do not require the delegate impersonation level; this flag should only be specified if it is required.
			/// Binding to a rogue server with the delegate impersonation level enables the rogue server to connect to a non-rogue server
			/// with your credentials and perform unintended operations.
			/// </para>
			/// </summary>
			NTDSAPI_BIND_ALLOW_DELEGATION = 0x00000001,
			/// <summary>
			/// With AD/AM, a single machine, could have multiple "AD's" on a single server. Since DsBindXxxx() will not pick an AD/AM
			/// instance without an instance specifier ( ":389" ), it can be difficult (well impossible) to determine from just a server
			/// name, what the instance annotation or instance guid is. This option will take a server name and find the first available AD
			/// or AD/AM instance. WARNING: The results could be non- deterministic on a server w/ multiple instances.
			/// </summary>
			NTDSAPI_BIND_FIND_BINDING = 0x00000002,
			/// <summary>
			/// Active Directory Lightweight Directory Services: If this flag is specified, DsBindWithSpnEx requires Kerberos authentication to be used. If Kerberos authentication cannot be established, DsBindWithSpnEx will not attempt to authenticate with any other mechanism.
			/// </summary>
			NTDSAPI_BIND_FORCE_KERBEROS = 0x00000004,
		}

		/// <summary>
		/// <para>
		/// The <c>DsClientMakeSpnForTargetServer</c> function constructs a service principal name (SPN) that identifies a specific server to
		/// use for authentication.
		/// </para>
		/// </summary>
		/// <param name="ServiceClass">
		/// <para>
		/// Pointer to a null-terminated string that contains the class of the service as defined by the service. This can be any string
		/// unique to the service.
		/// </para>
		/// </param>
		/// <param name="ServiceName">
		/// <para>
		/// Pointer to a null-terminated string that contains the distinguished name service (DNS) host name. This can either be a fully
		/// qualified name or an IP address in the Internet standard format.
		/// </para>
		/// <para>
		/// Use of an IP address for ServiceName is not recommended because this can create a security issue. Before the SPN is constructed,
		/// the IP address must be translated to a computer name through DNS name resolution. It is possible for the DNS name resolution to
		/// be spoofed, replacing the intended computer name with an unauthorized computer name.
		/// </para>
		/// </param>
		/// <param name="pcSpnLength">
		/// <para>
		/// Pointer to a <c>DWORD</c> value that, on entry, contains the size of the pszSpn buffer, in characters. On output, this parameter
		/// receives the number of characters copied to the pszSpn buffer, including the terminating <c>NULL</c>.
		/// </para>
		/// </param>
		/// <param name="pszSpn">
		/// <para>Pointer to a string buffer that receives the SPN.</para>
		/// </param>
		/// <returns>
		/// <para>This function returns standard Windows error codes.</para>
		/// </returns>
		/// <remarks>
		/// <para>When using this function, supply the service class and part of a DNS host name.</para>
		/// <para>
		/// This function is a simplified version of the DsMakeSpn function. The ServiceName is made canonical by resolving through DNS.
		/// </para>
		/// <para>GUID-based DNS names are not supported. When constructed, the simplified SPN is as follows:</para>
		/// <para>The instance name portion (second position) is always set to default. The port and referrer fields are not used.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/ntdsapi/nf-ntdsapi-dsclientmakespnfortargetserverw NTDSAPI DWORD
		// DsClientMakeSpnForTargetServerW( LPCWSTR ServiceClass, LPCWSTR ServiceName, DWORD *pcSpnLength, LPWSTR pszSpn );
		[DllImport(Lib.NTDSApi, SetLastError = false, CharSet = CharSet.Auto)]
		[PInvokeData("ntdsapi.h", MSDNShortId = "d205e7cc-4879-41a4-baa7-75e7dd177cd0")]
		public static extern Win32Error DsClientMakeSpnForTargetServer(string ServiceClass, string ServiceName, ref uint pcSpnLength, StringBuilder pszSpn);

		/// <summary>
		/// The DsCrackNames function converts an array of directory service object names from one format to another. Name conversion enables
		/// client applications to map between the multiple names used to identify various directory service objects. For example, user
		/// objects can be identified by SAM account names (Domain\UserName), user principal name (UserName@Domain.com), or distinguished
		/// name. <note type="note">This function uses many handles and memory allocations that can be unwieldy. It is recommended to use the
		/// <see cref="DsCrackNames(SafeDsHandle, string[], DS_NAME_FORMAT, DS_NAME_FORMAT, DS_NAME_FLAGS)"/> method instead.</note>
		/// </summary>
		/// <param name="hSafeDs">
		/// Contains a directory service handle obtained from either the DSBind or DSBindWithCred function. If flags contains
		/// DS_NAME_FLAG_SYNTACTICAL_ONLY, hDS can be NULL.
		/// </param>
		/// <param name="flags">Contains one or more of the DS_NAME_FLAGS values used to determine how the name syntax will be cracked.</param>
		/// <param name="formatOffered">Contains one of the DS_NAME_FORMAT values that identifies the format of the input names.</param>
		/// <param name="formatDesired">
		/// Contains one of the DS_NAME_FORMAT values that identifies the format of the output names. The DS_SID_OR_SID_HISTORY_NAME value is
		/// not supported.
		/// </param>
		/// <param name="cNames">Contains the number of elements in the rpNames array.</param>
		/// <param name="rpNames">Pointer to an array of pointers to null-terminated strings that contain names to be converted.</param>
		/// <param name="ppResult">
		/// Pointer to a PDS_NAME_RESULT value that receives a DS_NAME_RESULT structure that contains the converted names. The caller must
		/// free this memory, when it is no longer required, by calling DsFreeNameResult.
		/// </param>
		/// <returns>Returns a Win32 error value, an RPC error value, or one of the following.</returns>
		[DllImport(Lib.NTDSApi, CharSet = CharSet.Auto, SetLastError = true)]
		[PInvokeData("NTDSApi.h", MSDNShortId = "ms675970")]
		public static extern Win32Error DsCrackNames(SafeDsHandle hSafeDs, DS_NAME_FLAGS flags, DS_NAME_FORMAT formatOffered, DS_NAME_FORMAT formatDesired, uint cNames,
			[MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPTStr, SizeParamIndex = 4)] string[] rpNames, out SafeDsNameResult ppResult);

		/// <summary>A wrapper function for the DsCrackNames OS call</summary>
		/// <param name="hSafeDs">
		/// Contains a directory service handle obtained from either the DSBind or DSBindWithCred function. If flags contains
		/// DS_NAME_FLAG_SYNTACTICAL_ONLY, hDS can be NULL.
		/// </param>
		/// <param name="names">The names to be converted.</param>
		/// <param name="formatDesired">
		/// Contains one of the DS_NAME_FORMAT values that identifies the format of the output names. The DS_SID_OR_SID_HISTORY_NAME value is
		/// not supported.
		/// </param>
		/// <param name="formatOffered">Contains one of the DS_NAME_FORMAT values that identifies the format of the input names.</param>
		/// <param name="flags">Contains one or m ore of the DS_NAME_FLAGS values used to determine how the name syntax will be cracked.</param>
		/// <returns>The crack results.</returns>
		[PInvokeData("NTDSApi.h", MSDNShortId = "ms675970")]
		public static DS_NAME_RESULT_ITEM[] DsCrackNames(SafeDsHandle hSafeDs, string[] names,
			DS_NAME_FORMAT formatDesired = DS_NAME_FORMAT.DS_USER_PRINCIPAL_NAME,
			DS_NAME_FORMAT formatOffered = DS_NAME_FORMAT.DS_UNKNOWN_NAME,
			DS_NAME_FLAGS flags = DS_NAME_FLAGS.DS_NAME_NO_FLAGS)
		{
			var err = DsCrackNames(hSafeDs, flags, formatOffered, formatDesired, (uint)(names?.Length ?? 0), names, out var pResult);
			new Win32Error((int)err).ThrowIfFailed();
			return pResult.Items;
		}

		/// <summary>
		/// <para>
		/// The <c>DsFreeDomainControllerInfo</c> function frees memory that is allocated by DsGetDomainControllerInfo for data about the
		/// domain controllers in a domain.
		/// </para>
		/// </summary>
		/// <param name="InfoLevel">
		/// <para>
		/// Indicates what version of the <c>DS_DOMAIN_CONTROLLER_INFO</c> structure should be freed. This parameter can be one of the
		/// following values.
		/// </para>
		/// <para>1</para>
		/// <para>The function frees the structure that contains DS_DOMAIN_CONTROLLER_INFO_1 data.</para>
		/// <para>2</para>
		/// <para>The function frees the structure that contains DS_DOMAIN_CONTROLLER_INFO_2 data.</para>
		/// </param>
		/// <param name="cInfo">
		/// <para>Indicates the number of items in pInfo.</para>
		/// </param>
		/// <param name="pInfo">
		/// <para>Pointer to an array of DS_DOMAIN_CONTROLLER_INFO structures to be freed.</para>
		/// </param>
		/// <returns>
		/// <para>This function does not return a value.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/ntdsapi/nf-ntdsapi-dsfreedomaincontrollerinfoa NTDSAPI VOID
		// DsFreeDomainControllerInfoA( DWORD InfoLevel, DWORD cInfo, VOID *pInfo );
		[DllImport(Lib.NTDSApi, SetLastError = false, CharSet = CharSet.Auto)]
		[PInvokeData("ntdsapi.h", MSDNShortId = "1b6d3136-91e2-4653-a4b0-ae2f66a6c5a2")]
		public static extern void DsFreeDomainControllerInfo(uint InfoLevel, uint cInfo, DCInfoHandle pInfo);

		/// <summary>
		/// The DsFreeNameResult function frees the memory held by a DS_NAME_RESULT structure. Use this function to free the memory allocated
		/// by the DsCrackNames function.
		/// </summary>
		/// <param name="pResult">Pointer to the DS_NAME_RESULT structure to be freed.</param>
		[DllImport(Lib.NTDSApi, CharSet = CharSet.Auto)]
		[PInvokeData("NTDSApi.h", MSDNShortId = "ms675978")]
		public static extern void DsFreeNameResult(IntPtr pResult);

		/// <summary>Frees memory allocated for a credentials structure by the DsMakePasswordCredentials function.</summary>
		/// <param name="AuthIdentity">Handle of the credential structure to be freed.</param>
		[DllImport(Lib.NTDSApi, ExactSpelling = true)]
		[PInvokeData("NTDSApi.h", MSDNShortId = "ms675979")]
		public static extern void DsFreePasswordCredentials(IntPtr AuthIdentity);

		/// <summary>
		/// <para>The <c>DsFreeSpnArray</c> function frees an array returned from the DsGetSpn function.</para>
		/// </summary>
		/// <param name="cSpn">
		/// <para>Specifies the number of elements contained in rpszSpn.</para>
		/// </param>
		/// <param name="rpszSpn">
		/// <para>Pointer to an array returned from DsGetSpn.</para>
		/// </param>
		/// <returns>
		/// <para>This function does not return a value.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/ntdsapi/nf-ntdsapi-dsfreespnarraya void DsFreeSpnArrayA( DWORD cSpn, LPSTR
		// *rpszSpn );
		[DllImport(Lib.NTDSApi, SetLastError = false, CharSet = CharSet.Auto)]
		[PInvokeData("ntdsapi.h", MSDNShortId = "1c229933-432d-4ded-be3b-3bd339a0abe4")]
		public static extern void DsFreeSpnArray(uint cSpn, ref SpnArrayHandle rpszSpn);

		/// <summary>
		/// <para>The <c>DsGetDomainControllerInfo</c> function retrieves data about the domain controllers in a domain.</para>
		/// </summary>
		/// <param name="hDs">
		/// <para>Contains a directory service handle obtained from either the DSBind or DSBindWithCred function.</para>
		/// </param>
		/// <param name="DomainName">
		/// <para>Pointer to a null-terminated string that specifies the domain name.</para>
		/// </param>
		/// <param name="InfoLevel">
		/// <para>
		/// Contains a value that indicates the version of the <c>DS_DOMAIN_CONTROLLER_INFO</c> structure to return. This can be one of the
		/// following values.
		/// </para>
		/// <para>1</para>
		/// <para>The function provides the domain data in the DS_DOMAIN_CONTROLLER_INFO_1 structure format.</para>
		/// <para>2</para>
		/// <para>The function provides the domain data in the DS_DOMAIN_CONTROLLER_INFO_2 structure format.</para>
		/// <para>3</para>
		/// <para>The function provides the domain data in the DS_DOMAIN_CONTROLLER_INFO_3 structure format.</para>
		/// </param>
		/// <param name="pcOut">
		/// <para>Pointer to a <c>DWORD</c> variable that receives the number of items returned in ppInfo array.</para>
		/// </param>
		/// <param name="ppInfo">
		/// <para>
		/// Pointer to a pointer variable that receives an array of <c>DS_DOMAIN_CONTROLLER_INFO_*</c> structures. The type of structures in
		/// this array is defined by the InfoLevel parameter. The caller must free this array, when it is no longer required, by using the
		/// DsFreeDomainControllerInfo function.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>
		/// If the function returns domain controller data, the return value is <c>ERROR_SUCCESS</c>. If the caller does not have the
		/// privileges to access the server objects, the return value is <c>ERROR_SUCCESS</c>, but the <c>DS_DOMAIN_CONTROLLER_INFO</c>
		/// structures could be empty.
		/// </para>
		/// <para>If the function fails, the return value can be one of the following error codes.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/ntdsapi/nf-ntdsapi-dsgetdomaincontrollerinfoa NTDSAPI DWORD
		// DsGetDomainControllerInfoA( HANDLE hDs, LPCSTR DomainName, DWORD InfoLevel, DWORD *pcOut, VOID **ppInfo );
		[DllImport(Lib.NTDSApi, SetLastError = false, CharSet = CharSet.Auto)]
		[PInvokeData("ntdsapi.h", MSDNShortId = "52db3b25-e6b0-4a0d-831b-89a203580cf1")]
		public static extern Win32Error DsGetDomainControllerInfo(SafeDsHandle hDs, string DomainName, uint InfoLevel, out uint pcOut, out DCInfoHandle ppInfo);

		/// <summary>
		/// <para>
		/// The <c>DsGetSpn</c> function constructs an array of one or more service principal names (SPNs). Each name in the array identifies
		/// an instance of a service. These SPNs may be registered with the directory service (DS) using the DsWriteAccountSpn function.
		/// </para>
		/// </summary>
		/// <param name="ServiceType">
		/// <para>Identifies the format of the SPNs to compose. The ServiceType parameter can have one of the following values.</para>
		/// <para>DS_SPN_DNS_HOST, DS_SPN_DN_HOST, DS_SPN_NB_HOST</para>
		/// <para>The SPNs have the following format.</para>
		/// </param>
		/// <param name="ServiceClass/ InstanceName: InstancePort&#xA;">
		/// <para>
		/// The ServiceName parameter must be <c>NULL</c>. This is the SPN format for a host-based service, which provides services
		/// identified with its host computer. The InstancePort component is optional.
		/// </para>
		/// <para>DS_SPN_DOMAIN, DS_SPN_NB_DOMAIN</para>
		/// <para>The SPNs have the following format.</para>
		/// </param>
		/// <param name="ServiceClass/ InstanceName: InstancePort/ ServiceName&#xA;">
		/// <para>
		/// The ServiceName parameter must be the DNS name or DN of a domain. This format is used for a replicable service that provides
		/// services to the specified domain.
		/// </para>
		/// <para>DS_SPN_SERVICE</para>
		/// <para>The SPNs have the following format.</para>
		/// </param>
		/// <param name="ServiceClass/ InstanceName: InstancePort/ ServiceName&#xA;">
		/// <para>
		/// The ServiceName parameter must be a canonical DN or DNS name that identifies an instance of the service. For example, it could be
		/// a DNS name of a SRV record, or the distinguished name of the service connection point for this service instance.
		/// </para>
		/// </param>
		/// <param name="ServiceClass">
		/// <para>
		/// Pointer to a constant null-terminated string that specifies the class of the service; for example, http. Generally, this can be
		/// any string that is unique to the service.
		/// </para>
		/// </param>
		/// <param name="ServiceName">
		/// <para>
		/// Pointer to a constant null-terminated string that specifies the DNS name or distinguished name (DN) of the service. ServiceName
		/// is not required for a host-based service. For more information, see the description of the ServiceType parameter for the possible
		/// values of ServiceName.
		/// </para>
		/// </param>
		/// <param name="InstancePort">
		/// <para>Specifies the port number of the service instance. If this value is zero, the SPN does not include a port number.</para>
		/// </param>
		/// <param name="cInstanceNames">
		/// <para>
		/// Specifies the number of elements in the pInstanceNames and pInstancePorts arrays. If this value is zero, pInstanceNames must
		/// point to an array of cInstanceNames strings, and pInstancePorts can be either <c>NULL</c> or a pointer to an array of
		/// cInstanceNames port numbers. If this value is zero, <c>DsGetSpn</c> returns only one SPN in the prpszSpn array and pInstanceNames
		/// and pInstancePorts are ignored.
		/// </para>
		/// </param>
		/// <param name="pInstanceNames">
		/// <para>
		/// Pointer to an array of null-terminated strings that specify extra instance names (not used for host names). This parameter is
		/// ignored if cInstanceNames is zero. In that case, the InstanceName component of the SPN defaults to the fully qualified DNS name
		/// of the local computer or the NetBIOS name if <c>DS_SPN_NB_HOST</c> or <c>DS_SPN_NB_DOMAIN</c> is specified.
		/// </para>
		/// </param>
		/// <param name="pInstancePorts">
		/// <para>
		/// Pointer to an array of extra instance ports. If this value is non- <c>NULL</c>, it must point to an array of cInstanceNames port
		/// numbers. If this value is <c>NULL</c>, the SPNs do not include a port number. This parameter is ignored if cInstanceNames is zero.
		/// </para>
		/// </param>
		/// <param name="pcSpn">
		/// <para>Pointer to a variable that receives the number of SPNs contained in prpszSpn.</para>
		/// </param>
		/// <param name="prpszSpn">
		/// <para>Pointer to a variable that receives a pointer to an array of SPNs. This array must be freed with DsFreeSpnArray.</para>
		/// </param>
		/// <returns>
		/// <para>If the function returns an array of SPNs, the return value is <c>ERROR_SUCCESS</c>.</para>
		/// <para>If the function fails, the return value can be one of the following error codes.</para>
		/// </returns>
		/// <remarks>
		/// <para><c>To create SPNs for multiple instances of a replicated service running on multiple host computers</c></para>
		/// <list type="number">
		/// <item>
		/// <term>Set cInstanceNames to the number of instances.</term>
		/// </item>
		/// <item>
		/// <term>Specify the names of the host computers in the pInstanceNames array.</term>
		/// </item>
		/// </list>
		/// <para><c>To create SPNs for multiple instances of a service running on the same host computer</c></para>
		/// <list type="number">
		/// <item>
		/// <term>Set the cInstanceNames to the number of instances.</term>
		/// </item>
		/// <item>
		/// <term>Set each entry in the pInstanceNames array to the DNS name of the host computer.</term>
		/// </item>
		/// <item>
		/// <term>Use the pInstancePorts parameter to specify an array of unique port numbers for each instance to disambiguate the SPNs.</term>
		/// </item>
		/// </list>
		/// <para>String parameters cannot include the forward slash (/), which is used to separate the components of the SPN.</para>
		/// <para>
		/// An application with the appropriate privileges, which are usually those of a domain administrator, can call the DsWriteAccountSpn
		/// function to register one or more SPNs on the user or computer account where the service is running. Clients can then use the SPNs
		/// to authenticate the service.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/ntdsapi/nf-ntdsapi-dsgetspna NTDSAPI DWORD DsGetSpnA( DS_SPN_NAME_TYPE
		// ServiceType, LPCSTR ServiceClass, LPCSTR ServiceName, USHORT InstancePort, USHORT cInstanceNames, LPCSTR *pInstanceNames, const
		// USHORT *pInstancePorts, DWORD *pcSpn, LPSTR **prpszSpn );
		[DllImport(Lib.NTDSApi, SetLastError = false, CharSet = CharSet.Auto)]
		[PInvokeData("ntdsapi.h", MSDNShortId = "cbd53850-9b05-4f74-ab07-30dcad583fc5")]
		public static extern Win32Error DsGetSpn(DS_SPN_NAME_TYPE ServiceType, string ServiceClass, string ServiceName, ushort InstancePort, ushort cInstanceNames,
			string[] pInstanceNames, ushort[] pInstancePorts, ref uint pcSpn, out SpnArrayHandle prpszSpn);

		/// <summary>Constructs a credential handle suitable for use with the DsBindWithCred function.</summary>
		/// <remarks>
		/// A null, default credential handle is created if User, Domain and Password are all NULL. Otherwise, User must be present. The
		/// Domain parameter may be NULL when User is fully qualified, such as a user in UPN format; for example, "someone@fabrikam.com".
		/// <para>
		/// When the handle returned in pAuthIdentity is passed to DsBindWithCred, DsUnBind must be called before freeing the handle with DsFreePasswordCredentials.
		/// </para>
		/// </remarks>
		/// <param name="User">A string that contains the user name to use for the credentials.</param>
		/// <param name="Domain">A string that contains the domain that the user is a member of.</param>
		/// <param name="Password">A string that contains the password to use for the credentials.</param>
		/// <param name="pAuthIdentity">
		/// An RPC_AUTH_IDENTITY_HANDLE value that receives the credential handle. This handle is used in a subsequent call to
		/// DsBindWithCred. This handle must be freed with the DsFreePasswordCredentials function when it is no longer required.
		/// </param>
		/// <returns>Returns a Windows error code.</returns>
		[DllImport(Lib.NTDSApi, CharSet = CharSet.Auto)]
		[PInvokeData("NTDSApi.h", MSDNShortId = "ms676006")]
		public static extern Win32Error DsMakePasswordCredentials(string User, string Domain, string Password, out SafeAuthIdentityHandle pAuthIdentity);

		/// <summary>
		/// <para>
		/// The <c>DsUnBind</c> function finds an RPC session with a domain controller and unbinds a handle to the directory service (DS).
		/// </para>
		/// </summary>
		/// <param name="phDS">
		/// <para>Pointer to a bind handle to the directory service. This handle is provided by a call to DsBind, DsBindWithCred, or DsBindWithSpn.</para>
		/// </param>
		/// <returns>
		/// <para><c>NO_ERROR</c></para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/ntdsapi/nf-ntdsapi-dsunbinda NTDSAPI DWORD DsUnBindA( HANDLE *phDS );
		[DllImport(Lib.NTDSApi, SetLastError = false, CharSet = CharSet.Auto)]
		[PInvokeData("ntdsapi.h", MSDNShortId = "7106d67f-d421-4a7c-b775-440e5944f25e")]
		public static extern Win32Error DsUnBind(ref IntPtr phDS);

		/// <summary>
		/// <para>
		/// The <c>DsWriteAccountSpn</c> function writes an array of service principal names (SPNs) to the <c>servicePrincipalName</c>
		/// attribute of a specified user or computer account object in Active Directory Domain Services. The function can either register or
		/// unregister the SPNs.
		/// </para>
		/// </summary>
		/// <param name="hDS">
		/// <para>Contains a directory service handle obtained from either the DSBind or DSBindWithCred function.</para>
		/// </param>
		/// <param name="Operation">
		/// <para>Contains one of the DS_SPN_WRITE_OP values that specifies the operation that <c>DsWriteAccountSpn</c> will perform.</para>
		/// </param>
		/// <param name="pszAccount">
		/// <para>
		/// Pointer to a constant null-terminated string that specifies the distinguished name of a user or computer object in Active
		/// Directory Domain Services. The caller must have write access to the <c>servicePrincipalName</c> property of this object.
		/// </para>
		/// </param>
		/// <param name="cSpn">
		/// <para>
		/// Specifies the number of SPNs in rpszSpn. If this value is zero, and Operation contains <c>DS_SPN_REPLACE_SPN_OP</c>, the function
		/// removes all values from the <c>servicePrincipalName</c> attribute of the specified account.
		/// </para>
		/// </param>
		/// <param name="rpszSpn">
		/// <para>
		/// Pointer to an array of constant null-terminated strings that specify the SPNs to be added to or removed from the account
		/// identified by the pszAccount parameter. The DsGetSpn function is used to compose SPNs for a service.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Returns <c>ERROR_SUCCESS</c> if successful or a Win32, RPC or directory service error if unsuccessful.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The <c>DsWriteAccountSpn</c> function registers the SPNs for one or more instances of a service. SPNs are used by clients, in
		/// conjunction with a trusted authentication service, to authenticate the service. To protect against security attacks where an
		/// application or service fraudulently registers an SPN that identifies some other service, the default DACL on user and computer
		/// accounts allows only domain administrators to register SPNs in most cases.
		/// </para>
		/// <para>
		/// One exception to this rule is that a service running under the LocalSystem account can call <c>DsWriteAccountSpn</c> to register
		/// a simple SPN of the form "ServiceClass/Host:Port" if the host specified in the SPN is the DNS or NetBIOS name of the computer on
		/// which the service is running.
		/// </para>
		/// <para>
		/// Another exception is that the default DACL on computer accounts allows callers to register SPNs on themselves, subject to certain
		/// constraints. For example, a computer account can have SPNs relative to its computername, of the form "host/&lt;computername&gt;".
		/// Because the computername is contained in the SPN, the SPN is allowable.
		/// </para>
		/// <para>
		/// None of the rules above apply if the DSA is configured to allow any SPN to be written. This reduces security, however, so it is
		/// not recommended.
		/// </para>
		/// <para>
		/// SPNs passed to <c>DsWriteAccountSpn</c> are actually added to the <c>Service-Principal-Name</c> attribute of the computer object
		/// in pszAccount. This call is made using RPC to the domain controller where the account object is stored so it can securely enforce
		/// policy on what SPNs are allowed on the account. Using LDAP to write directly to the SPN property is not allowed; all writes must
		/// come through this RPC call. Reads using LDAP are allowed.
		/// </para>
		/// <para>Permissions required to set SPNs</para>
		/// <para>
		/// To write an arbitrary SPN on an account, the writer requires the "Write ServicePrincipalName" right, which is not granted by
		/// default to the person who created the account. That person has the 'Write validated SPN" right(present only on machine accounts).
		/// </para>
		/// <para>Below is a summary of rights per user on machine accounts:</para>
		/// <list type="table">
		/// <listheader>
		/// <term>User Type</term>
		/// <term>Rights</term>
		/// </listheader>
		/// <item>
		/// <term>Person creating the Account</term>
		/// <term>Write validated SPN</term>
		/// </item>
		/// <item>
		/// <term>Account Operators</term>
		/// <term>Write SPN and Write Validated SPN</term>
		/// </item>
		/// <item>
		/// <term>Authenticated Users</term>
		/// <term>None</term>
		/// </item>
		/// <item>
		/// <term>(self)</term>
		/// <term>Write Validated SPN</term>
		/// </item>
		/// </list>
		/// <para>
		/// On user accounts there is no "Validated SPN" property or "Write SPN" right. Rather, the "Write public information" property set
		/// grants the ability to create arbitrary SPNs.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/ntdsapi/nf-ntdsapi-dswriteaccountspna NTDSAPI DWORD DsWriteAccountSpnA(
		// HANDLE hDS, DS_SPN_WRITE_OP Operation, LPCSTR pszAccount, DWORD cSpn, LPCSTR *rpszSpn );
		[DllImport(Lib.NTDSApi, SetLastError = false, CharSet = CharSet.Auto)]
		[PInvokeData("ntdsapi.h", MSDNShortId = "2b555f6b-643d-4fa0-9aca-701e6b3313fa")]
		public static extern Win32Error DsWriteAccountSpn(SafeDsHandle hDS, DS_SPN_WRITE_OP Operation, string pszAccount, uint cSpn, SpnArrayHandle rpszSpn);

		/// <summary>Provides a handle to a domain controller info structure.</summary>
		[StructLayout(LayoutKind.Sequential)]
		public struct DCInfoHandle : IHandle
		{
			private IntPtr handle;

			/// <summary>Initializes a new instance of the <see cref="DCInfoHandle"/> struct.</summary>
			/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
			public DCInfoHandle(IntPtr preexistingHandle) => handle = preexistingHandle;

			/// <summary>Gets a value indicating whether this instance is a null handle.</summary>
			public bool IsNull => handle == IntPtr.Zero;

			/// <inheritdoc/>
			public IntPtr DangerousGetHandle() => handle;

			/// <summary>Gets a list of stored structures from this handle.</summary>
			/// <typeparam name="T">The type of structure found in the list.</typeparam>
			/// <param name="count">The count.</param>
			/// <returns>The list of structures.</returns>
			public IEnumerable<T> ToIEnum<T>(uint count) where T : struct => handle.ToIEnum<T>((int)count);
		}

		/// <summary>
		/// <para>
		/// The <c>DS_DOMAIN_CONTROLLER_INFO_1</c> structure contains data about a domain controller. This structure is returned by the
		/// DsGetDomainControllerInfo function.
		/// </para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// The DsGetDomainControllerInfo function can return different versions of this structure. For more information and a list of the
		/// currently supported versions, see the InfoLevel parameter of <c>DsGetDomainControllerInfo</c>.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/ntdsapi/ns-ntdsapi-ds_domain_controller_info_1a typedef struct
		// DS_DOMAIN_CONTROLLER_INFO_1A { #if ... CHAR *NetbiosName; #if ... CHAR *DnsHostName; #if ... CHAR *SiteName; #if ... CHAR
		// *ComputerObjectName; #if ... CHAR *ServerObjectName; #else LPSTR NetbiosName; #endif #else LPSTR DnsHostName; #endif #else LPSTR
		// SiteName; #endif #else LPSTR ComputerObjectName; #endif #else LPSTR ServerObjectName; #endif BOOL fIsPdc; BOOL fDsEnabled; } *PDS_DOMAIN_CONTROLLER_INFO_1A;
		[PInvokeData("ntdsapi.h", MSDNShortId = "6cc829ac-2aa6-49ef-b1ab-9c249249e0d6")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
		public struct DS_DOMAIN_CONTROLLER_INFO_1
		{
			public StrPtrAuto NetbiosName;
			public StrPtrAuto DnsHostName;
			public StrPtrAuto SiteName;
			public StrPtrAuto ComputerObjectName;
			public StrPtrAuto ServerObjectName;

			/// <summary>
			/// A Boolean value that indicates whether or not this domain controller is the primary domain controller. If this value is TRUE,
			/// the domain controller is the primary domain controller; otherwise, the domain controller is not the primary domain controller.
			/// </summary>
			[MarshalAs(UnmanagedType.Bool)]
			public bool fIsPdc;

			/// <summary>
			/// A Boolean value that indicates whether or not the domain controller is enabled. If this value is TRUE, the domain controller
			/// is enabled; otherwise, it is not enabled.
			/// </summary>
			[MarshalAs(UnmanagedType.Bool)]
			public bool fDsEnabled;
		}

		/// <summary>
		/// <para>
		/// The <c>DS_DOMAIN_CONTROLLER_INFO_2</c> structure contains data about a domain controller. This structure is returned by the
		/// DsGetDomainControllerInfo function.
		/// </para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// The DsGetDomainControllerInfo function can return different versions of this structure. For more information and a list of the
		/// currently supported versions, see the InfoLevel parameter of <c>DsGetDomainControllerInfo</c>.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/ntdsapi/ns-ntdsapi-ds_domain_controller_info_2a typedef struct
		// DS_DOMAIN_CONTROLLER_INFO_2A { #if ... CHAR *NetbiosName; #if ... CHAR *DnsHostName; #if ... CHAR *SiteName; #if ... CHAR
		// *SiteObjectName; #if ... CHAR *ComputerObjectName; #if ... CHAR *ServerObjectName; #if ... CHAR *NtdsDsaObjectName; #else LPSTR
		// NetbiosName; #endif #else LPSTR DnsHostName; #endif #else LPSTR SiteName; #endif #else LPSTR SiteObjectName; #endif #else LPSTR
		// ComputerObjectName; #endif #else LPSTR ServerObjectName; #endif #else LPSTR NtdsDsaObjectName; #endif BOOL fIsPdc; BOOL
		// fDsEnabled; BOOL fIsGc; GUID SiteObjectGuid; GUID ComputerObjectGuid; GUID ServerObjectGuid; GUID NtdsDsaObjectGuid; } *PDS_DOMAIN_CONTROLLER_INFO_2A;
		[PInvokeData("ntdsapi.h", MSDNShortId = "9d45b732-363d-4b20-ae5c-e9e76264bf1f")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
		public struct DS_DOMAIN_CONTROLLER_INFO_2
		{
			public StrPtrAuto NetbiosName;
			public StrPtrAuto DnsHostName;
			public StrPtrAuto SiteName;
			public StrPtrAuto SiteObjectName;
			public StrPtrAuto ComputerObjectName;
			public StrPtrAuto ServerObjectName;
			public StrPtrAuto NtdsDsaObjectName;

			/// <summary>
			/// A Boolean value that indicates whether or not this domain controller is the primary domain controller. If this value is TRUE,
			/// the domain controller is the primary domain controller; otherwise, the domain controller is not the primary domain controller.
			/// </summary>
			[MarshalAs(UnmanagedType.Bool)]
			public bool fIsPdc;

			/// <summary>
			/// A Boolean value that indicates whether or not the domain controller is enabled. If this value is TRUE, the domain controller
			/// is enabled; otherwise, it is not enabled.
			/// </summary>
			[MarshalAs(UnmanagedType.Bool)]
			public bool fDsEnabled;

			/// <summary>
			/// A Boolean value that indicates whether or not the domain controller is global catalog server. If this value is TRUE, the
			/// domain controller is a global catalog server; otherwise, it is not a global catalog server.
			/// </summary>
			[MarshalAs(UnmanagedType.Bool)]
			public bool fIsGc;

			/// <summary>Contains the GUID for the site object on the domain controller.</summary>
			public Guid SiteObjectGuid;

			/// <summary>Contains the GUID for the computer object on the domain controller.</summary>
			public Guid ComputerObjectGuid;

			/// <summary>Contains the GUID for the server object on the domain controller.</summary>
			public Guid ServerObjectGuid;

			/// <summary>Contains the GUID for the NTDS DSA object on the domain controller.</summary>
			public Guid NtdsDsaObjectGuid;
		}

		/// <summary>
		/// <para>
		/// The <c>DS_DOMAIN_CONTROLLER_INFO_3</c> structure contains data about a domain controller. This structure is returned by the
		/// DsGetDomainControllerInfo function.
		/// </para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// The DsGetDomainControllerInfo function can return different versions of this structure. For more information and a list of the
		/// currently supported versions, see the InfoLevel parameter of <c>DsGetDomainControllerInfo</c>.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/ntdsapi/ns-ntdsapi-ds_domain_controller_info_3a typedef struct
		// DS_DOMAIN_CONTROLLER_INFO_3A { #if ... CHAR *NetbiosName; #if ... CHAR *DnsHostName; #if ... CHAR *SiteName; #if ... CHAR
		// *SiteObjectName; #if ... CHAR *ComputerObjectName; #if ... CHAR *ServerObjectName; #if ... CHAR *NtdsDsaObjectName; #else LPSTR
		// NetbiosName; #endif #else LPSTR DnsHostName; #endif #else LPSTR SiteName; #endif #else LPSTR SiteObjectName; #endif #else LPSTR
		// ComputerObjectName; #endif #else LPSTR ServerObjectName; #endif #else LPSTR NtdsDsaObjectName; #endif BOOL fIsPdc; BOOL
		// fDsEnabled; BOOL fIsGc; BOOL fIsRodc; GUID SiteObjectGuid; GUID ComputerObjectGuid; GUID ServerObjectGuid; GUID NtdsDsaObjectGuid;
		// } *PDS_DOMAIN_CONTROLLER_INFO_3A;
		[PInvokeData("ntdsapi.h", MSDNShortId = "510f458e-4c08-41c7-b290-1372ac9c8beb")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
		public struct DS_DOMAIN_CONTROLLER_INFO_3
		{
			public StrPtrAuto NetbiosName;
			public StrPtrAuto DnsHostName;
			public StrPtrAuto SiteName;
			public StrPtrAuto SiteObjectName;
			public StrPtrAuto ComputerObjectName;
			public StrPtrAuto ServerObjectName;
			public StrPtrAuto NtdsDsaObjectName;

			/// <summary>
			/// A Boolean value that indicates whether or not this domain controller is the primary domain controller. If this value is TRUE,
			/// the domain controller is the primary domain controller; otherwise, the domain controller is not the primary domain controller.
			/// </summary>
			[MarshalAs(UnmanagedType.Bool)]
			public bool fIsPdc;

			/// <summary>
			/// A Boolean value that indicates whether or not the domain controller is enabled. If this value is TRUE, the domain controller
			/// is enabled; otherwise, it is not enabled.
			/// </summary>
			[MarshalAs(UnmanagedType.Bool)]
			public bool fDsEnabled;

			/// <summary>
			/// A Boolean value that indicates whether or not the domain controller is global catalog server. If this value is TRUE, the
			/// domain controller is a global catalog server; otherwise, it is not a global catalog server.
			/// </summary>
			[MarshalAs(UnmanagedType.Bool)]
			public bool fIsGc;

			/// <summary>
			/// A Boolean value that indicates if the domain controller is a read-only domain controller. If this value is TRUE, the domain
			/// controller is a read-only domain controller; otherwise, it is not a read-only domain controller.
			/// </summary>
			[MarshalAs(UnmanagedType.Bool)]
			public bool fIsRodc;

			/// <summary>Contains the GUID for the site object on the domain controller.</summary>
			public Guid SiteObjectGuid;

			/// <summary>Contains the GUID for the computer object on the domain controller.</summary>
			public Guid ComputerObjectGuid;

			/// <summary>Contains the GUID for the server object on the domain controller.</summary>
			public Guid ServerObjectGuid;

			/// <summary>Contains the GUID for the NTDS DSA object on the domain controller.</summary>
			public Guid NtdsDsaObjectGuid;
		}

		/// <summary>Used with the DsCrackNames function to contain the names converted by the function.</summary>
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
		[PInvokeData("NTDSApi.h", MSDNShortId = "ms676246")]
		public struct DS_NAME_RESULT
		{
			/// <summary>Contains the number of elements in the rItems array.</summary>
			public uint cItems;

			/// <summary>
			/// Contains an array of DS_NAME_RESULT_ITEM structure pointers. Each element of this array represents a single converted name.
			/// </summary>
			public IntPtr rItems; // PDS_NAME_RESULT_ITEM

			/// <summary>Enumeration of DS_NAME_RESULT_ITEM structures. Each element of this array represents a single converted name.</summary>
			public DS_NAME_RESULT_ITEM[] Items => rItems.ToArray<DS_NAME_RESULT_ITEM>((int)cItems);
		}

		/// <summary>Contains a name converted by the DsCrackNames function, along with associated error and domain data.</summary>
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
		[PInvokeData("NTDSApi.h", MSDNShortId = "ms676246")]
		public struct DS_NAME_RESULT_ITEM
		{
			/// <summary>Contains one of the DS_NAME_ERROR values that indicates the status of this name conversion.</summary>
			public DS_NAME_ERROR status;

			/// <summary>
			/// A string that specifies the DNS domain in which the object resides. This member will contain valid data if status contains
			/// DS_NAME_NO_ERROR or DS_NAME_ERROR_DOMAIN_ONLY.
			/// </summary>
			public string pDomain;

			/// <summary>A string that specifies the newly formatted object name.</summary>
			public string pName;

			/// <summary>Returns a <see cref="string"/> that represents this instance.</summary>
			/// <returns>A <see cref="string"/> that represents this instance.</returns>
			public override string ToString() => status == DS_NAME_ERROR.DS_NAME_NO_ERROR ? pName : $"{status}";
		}

		/// <summary>Provides a handle to an array of one or more service principal names (SPNs).</summary>
		[StructLayout(LayoutKind.Sequential)]
		public struct SpnArrayHandle : IHandle
		{
			private IntPtr handle;

			/// <summary>Initializes a new instance of the <see cref="SpnArrayHandle"/> struct.</summary>
			/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
			public SpnArrayHandle(IntPtr preexistingHandle) => handle = preexistingHandle;

			/// <inheritdoc/>
			public IntPtr DangerousGetHandle() => handle;

			/// <summary>Gets the list of service principle names (SPNs) from this handle.</summary>
			/// <param name="count">The count returned in the pcSpn parameter of <see cref="DsGetSpn"/>.</param>
			/// <returns>The list of SPNs.</returns>
			public IEnumerable<string> GetSPNs(uint count) => handle.ToStringEnum((int)count);
		}

		/// <summary>Provides a <see cref="SafeHandle"/> to an authentication identity that releases its handle at disposal using DsFreePasswordCredentials.</summary>
		public class SafeAuthIdentityHandle : HANDLE
		{
			/// <summary>Initializes a new instance of the <see cref="SafeAuthIdentityHandle"/> class and assigns an existing handle.</summary>
			/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
			/// <param name="ownsHandle">
			/// <see langword="true"/> to reliably release the handle during the finalization phase; otherwise, <see langword="false"/> (not recommended).
			/// </param>
			public SafeAuthIdentityHandle(IntPtr preexistingHandle, bool ownsHandle = true) : base(preexistingHandle, ownsHandle) { }

			/// <summary>Initializes a new instance of the <see cref="SafeAuthIdentityHandle"/> class.</summary>
			private SafeAuthIdentityHandle() : base() { }

			/// <inheritdoc/>
			protected override bool InternalReleaseHandle() { DsFreePasswordCredentials(handle); return true; }
		}

		/// <summary>A <see cref="SafeHandle"/> for handles bound to directory services.</summary>
		/// <seealso cref="Microsoft.Win32.SafeHandles.SafeHandleZeroOrMinusOneIsInvalid"/>
		[SuppressUnmanagedCodeSecurity, ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		[PInvokeData("NTDSApi.h")]
		public class SafeDsHandle : HANDLE
		{
			/// <summary>Initializes a new instance of the <see cref="SafeDsHandle"/> class and assigns an existing handle.</summary>
			/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
			/// <param name="ownsHandle">
			/// <see langword="true"/> to reliably release the handle during the finalization phase; otherwise, <see langword="false"/> (not recommended).
			/// </param>
			public SafeDsHandle(IntPtr preexistingHandle, bool ownsHandle = true) : base(preexistingHandle, ownsHandle) { }

			/// <summary>Initializes a new instance of the <see cref="SafeDsHandle"/> class.</summary>
			private SafeDsHandle() : base() { }

			/// <summary>Gets a <c>NULL</c> equivalent for a bound directory services handle.</summary>
			public static SafeDsHandle Null { get; } = new SafeDsHandle(IntPtr.Zero);

			/// <inheritdoc/>
			protected override bool InternalReleaseHandle() => DsUnBind(ref handle).Succeeded;
		}

		/// <summary>
		/// A <see cref="SafeHandle"/> for the results from <see
		/// cref="DsCrackNames(SafeDsHandle,DS_NAME_FLAGS,DS_NAME_FORMAT,DS_NAME_FORMAT,uint,string[],out SafeDsNameResult)"/>.
		/// </summary>
		/// <seealso cref="GenericSafeHandle"/>
		[PInvokeData("NTDSApi.h")]
		public class SafeDsNameResult : GenericSafeHandle
		{
			/// <summary>Initializes a new instance of the <see cref="SafeDsNameResult"/> class.</summary>
			public SafeDsNameResult() : base(h => { DsFreeNameResult(h); return true; }) { }

			/// <summary>An array of DS_NAME_RESULT_ITEM structures. Each element of this array represents a single converted name.</summary>
			public DS_NAME_RESULT_ITEM[] Items => IsInvalid ? new DS_NAME_RESULT_ITEM[0] : handle.ToStructure<DS_NAME_RESULT>().Items;
		}

		/*
		DsListDomainsInSite
		DsListRoles
		DsListServersForDomainInSite
		DsListServersInSite
		DsListSites
		DsMapSchemaGuids
		DsQuerySitesByCost
		DsQuerySitesFree
		DsRemoveDsDomain
		DsRemoveDsServer
		DsReplicaConsistencyCheck
		DsReplicaDel
		DsReplicaFreeInfo
		DsReplicaGetInfo2W
		DsReplicaGetInfoW
		DsReplicaModify
		DsReplicaSync
		DsReplicaSyncAll
		DsReplicaUpdateRefs
		DsReplicaVerifyObjects
		DsServerRegisterSpn
		*/
	}
}